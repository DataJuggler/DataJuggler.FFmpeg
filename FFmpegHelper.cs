
#region using statements

using DataJuggler.UltimateHelper;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

#endregion

namespace DataJuggler.FFmpeg
{

    #region class FFmpegHelper
    /// <summary>
    /// This class is used to get frames from an mp4
    /// </summary>
    public static class FFmpegHelper
    {
        
        #region Methods

            #region CleanseVideo(string inputPath, string outputPath, StatusUpdate callback)
            /// <summary>
            /// Cleanses an MP4 by remuxing with FFmpeg to fix missing metadata or indexing issues.
            /// </summary>
            /// <param name="inputPath">The path to the AI-generated or problematic MP4 file.</param>
            /// <param name="outputPath">The path where the cleaned MP4 will be saved.</param>
            /// <param name="callback">A callback delegate (optional)</param>
            /// <returns>True if successful; otherwise false.</returns>
            public static bool CleanseVideo(string inputPath, string outputPath, StatusUpdate callback)
            {
                // initial value
                bool isSuccess = false;

                // local
                string ffmpegOutput = "";

                try
                {
                    // get ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // verify input and output
                    if ((FileHelper.Exists(inputPath)) && (TextHelper.Exists(outputPath)) && (FileHelper.Exists(ffmpegPath)))
                    { 
                        // build args
                        string args = $"-i \"{inputPath}\" -map 0 -c copy -movflags +faststart \"{outputPath}\"";

                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = ffmpegPath,
                            Arguments = args,
                            RedirectStandardError = true,
                            RedirectStandardOutput = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = new Process { StartInfo = startInfo })
                        {
                            process.Start();

                            // capture ffmpeg output
                            ffmpegOutput = process.StandardError.ReadToEnd();
                            process.WaitForExit();
                        }

                        // set return value
                        if (File.Exists(outputPath))
                        {
                            isSuccess = true;
                        }

                        // capture error
                        if (NullHelper.Exists(callback))
                        {
                            // call back
                            callback("FFmpegHelper", "Cleanse: " + " " + isSuccess + " " +ffmpegOutput);
                        }
                    }
                }
                catch (Exception error)
                {
                    // capture error
                    if (NullHelper.Exists(callback))
                    {
                        callback("FFmpegHelper", "Error: " + error.Message);
                    }
                }

                // return value
                return isSuccess;
            }
            #endregion

            #region ConvertToImageSequence(string inputPath, string outputFolder, StatusUpdate callback)
            /// <summary>
            /// Converts an MP4 to an image sequence of PNGs.
            /// </summary>                                   
            public static bool ConvertToImageSequence(string inputPath, string outputFolder, StatusUpdate callback)
            {
                // initial value
                bool converted = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // If the Directory exists
                    if (FolderHelper.Exists(outputFolder))
                    {
                        // create at temp file
                        string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputPath, 12);

                        // cleanse the video
                        bool cleansed = CleanseVideo(inputPath, cleansedFilePath, callback);

                        // if cleansed
                        if (cleansed)
                        {
                            var process = new Process();
                            process.StartInfo.FileName = ffmpegPath;
                            process.StartInfo.Arguments = $"-i \"{cleansedFilePath}\" \"{Path.Combine(outputFolder, "Image%d.png")}\"";
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardOutput = false;
                            process.StartInfo.RedirectStandardError = true;

                            process.Start();
                            process.WaitForExit();

                            // set return value
                            converted = (process.ExitCode == 0);
                        }
                    }
                }
                catch (Exception error)
                {
                    // If the callback object exists
                    if (NullHelper.Exists(callback))
                    {
                        // send info back to the user
                        callback("FFmpegHelper - ConvertToImageSequence ", "Error: " + error.ToString());
                    }
                }

                // return value
                return converted;
            }
            #endregion
            
            #region CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 14, int frameRate = 30)
            /// <summary>
            /// Creates an MP4 from a sequence of images using FFmpeg.
            /// </summary>
            public static bool CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 14, int frameRate = 30)
            {
                // initial value
                bool created = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    var process = new Process();
                    process.StartInfo.FileName = ffmpegPath;

                    // assumes filenames like Image1.png, Image2.png ...
                   process.StartInfo.Arguments = $"-framerate {frameRate} -i \"{Path.Combine(imageFolder, "Image%d.png")}\" " +
                    $"-c:v libx264 -crf {crf} -preset slow -pix_fmt yuv420p -loglevel error -progress pipe:1 " +
                    $"\"{outputMp4Path}\"";

                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    // send error messages
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if ((TextHelper.Exists(e.Data)) && (NullHelper.Exists(statusUpdate)))
                        {
                            statusUpdate("FFmpegHelper", "[stderr] " + e.Data);
                        }
                    };

                    // send info back to caller
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if ((TextHelper.Exists(e.Data)) && (NullHelper.Exists(statusUpdate)))
                        {
                            statusUpdate("FFmpegHelper", e.Data);
                        }
                    };

                    process.Start();
                    process.BeginOutputReadLine();
                    process.WaitForExit();

                    // set return value
                    created = (process.ExitCode == 0 && File.Exists(outputMp4Path));
                }
                catch (Exception error)
                {
                    // For debugging only for now
                    DebugHelper.WriteDebugError("CreateMP4FromImages", "FFmpegHelper", error);
                }

                // return value
                return created;
            }
            #endregion

            #region ExtractLastFrame(string inputPath, string outputPath)
            /// <summary>
            /// Extracts the last frame of a video using FFmpeg.
            /// </summary>
            public static bool ExtractLastFrame(string inputPath, string outputPath)
            {
                // initial value
                bool extracted = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // create a temp file
                    string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputPath, 12);

                    // cleanse the video
                    bool cleansed = CleanseVideo(inputPath, cleansedFilePath, null);

                    // if cleansed
                    if (cleansed)
                    {
                        var process = new Process();
                        process.StartInfo.FileName = ffmpegPath;
                        process.StartInfo.Arguments = $"-sseof -1 -i \"{cleansedFilePath}\" -update 1 -q:v 1 \"{outputPath}\"";
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;

                        process.Start();
                        string output = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        // set return value
                        extracted = (process.ExitCode == 0 && File.Exists(outputPath));
                    }
                }
                catch (Exception error)
                {
                    DebugHelper.WriteDebugError("ExtractLastFrame", "FFmpegHelper", error);
                }

                // return value
                return extracted;
            }
            #endregion

            #region GetFFmpegPath()
            /// <summary>
            /// method returns the F Fmpeg Path
            /// </summary>
            public static string GetFFmpegPath()
            {
                // return the Path to the FFmpeg folder
                return Path.Combine(AppContext.BaseDirectory, "FFmpeg", "bin", "ffmpeg.exe");
            }
            #endregion
            
            #region SplitVideo(string inputFilePath, string outputFolder, StatusUpdate statusUpdate, int chunkLengthSeconds = 15)
            /// <summary>
            /// Splits a video file into equal-length chunks using FFmpeg.
            /// </summary>
            /// <param name="inputFilePath">The full path to the video to split.</param>
            /// <param name="outputFolder">The folder where the chunks will be saved.</param>
            /// <param name="statusUpdate">An optional delegate for reporting status updates.</param>
            /// <param name="chunkLengthSeconds">The duration in seconds for each output chunk. Default is 15.</param>
            /// <returns>True if the split was successful; otherwise, false.</returns>            
            public static bool SplitVideo(string inputFilePath, string outputFolder, StatusUpdate statusUpdate, int chunkLengthSeconds = 15)
            {
                // initial value
                bool split = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // if the file and the Directory exist
                    if (FileHelper.Exists(inputFilePath) && FileHelper.Exists(ffmpegPath) && Directory.Exists(outputFolder))
                    {
                        // create a temp file
                        string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputFilePath, 12);

                        // cleanse the video
                        bool cleansed = CleanseVideo(inputFilePath, cleansedFilePath, statusUpdate);

                        // if cleansed
                        if (cleansed)
                        {
                            if (NullHelper.Exists(statusUpdate))
                            {
                                statusUpdate.Invoke("FFmpegHelper", $"Splitting video into {chunkLengthSeconds} second chunks...");
                            }

                            string outputPattern = Path.Combine(outputFolder, "chunk_%03d.mp4");

                            Process process = new Process();
                            process.StartInfo.FileName = ffmpegPath;
                            process.StartInfo.Arguments = $"-i \"{cleansedFilePath}\" -c copy -map 0 -f segment -segment_time {chunkLengthSeconds} \"{outputPattern}\"";
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;

                            process.OutputDataReceived += (sender, e) =>
                            {
                                if ((TextHelper.Exists(e.Data)) && (NullHelper.Exists(statusUpdate)))
                                {
                                    statusUpdate.Invoke("FFmpegHelper", e.Data);
                                }
                            };

                            process.ErrorDataReceived += (sender, e) =>
                            {
                                if ((TextHelper.Exists(e.Data)) && (NullHelper.Exists(statusUpdate)))
                                {
                                    statusUpdate.Invoke("FFmpegHelper", e.Data);
                                }
                            };

                            process.Start();
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();
                            process.WaitForExit();

                            // set return value
                            split = (process.ExitCode == 0);

                            // if the callback exists
                            if (NullHelper.Exists(statusUpdate))
                            {
                                if (split)
                                {
                                    statusUpdate.Invoke("FFmpegHelper", "Video split complete.");
                                }
                                else
                                {
                                    statusUpdate.Invoke("FFmpegHelper", "Video split failed.");
                                }
                            }
                        }
                    }
                }
                catch (Exception error)
                {
                    // if the callback exists
                    if (NullHelper.Exists(statusUpdate))
                    {
                        statusUpdate.Invoke("FFmpegHelper", "Error: " + error.Message);
                    }
                    else
                    {
                        DebugHelper.WriteDebugError("SplitVideo", "FFmpegHelper", error);
                    }
                }

                // return value
                return split;
            }
            #endregion
                        
        #endregion
        
    }
    #endregion

}