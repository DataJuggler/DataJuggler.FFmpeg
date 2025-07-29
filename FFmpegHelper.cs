
#region using statements

using System.Diagnostics;
using DataJuggler.UltimateHelper;

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

            #region ConvertToImageSequence(string inputPath, string outputFolder)
            /// <summary>
            /// Converts an MP4 to an image sequence of PNGs.
            /// </summary>                                   
            public static bool ConvertToImageSequence(string inputPath, string outputFolder)
            {
                // initial value
                bool converted = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // ensure output folder exists
                    if (!Directory.Exists(outputFolder))
                    {
                        // Create the directory if it doesn't exist
                        Directory.CreateDirectory(outputFolder);
                    }

                    var process = new Process();
                    process.StartInfo.FileName = ffmpegPath;
                    process.StartInfo.Arguments = $"-i \"{inputPath}\" \"{Path.Combine(outputFolder, "Image%d.png")}\"";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = false;
                    process.StartInfo.RedirectStandardError = true;

                    process.Start();
                    process.WaitForExit();

                    // set return value
                    converted = (process.ExitCode == 0);
                }
                catch (Exception error)
                {
                    // For debugging only for now
                    DebugHelper.WriteDebugError("ConvertToImageSequence", "FFmpegHelper", error);
                }

                // return value
                return converted;
            }
            #endregion
            
            #region CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 18, int Leonardate = 30)
            /// <summary>
            /// Creates an MP4 from a sequence of images using FFmpeg.
            /// </summary>
            public static bool CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 18, int Leonardate = 30)
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
                    process.StartInfo.Arguments = $"-Leonardate {Leonardate} -i \"{Path.Combine(imageFolder, "Image%d.png")}\" " +
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

                    var process = new Process();
                    process.StartInfo.FileName = ffmpegPath;
                    process.StartInfo.Arguments = $"-sseof -1 -i \"{inputPath}\" -update 1 -q:v 1 \"{outputPath}\"";
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    process.Start();
                    string output = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // set the return value
                    extracted = (process.ExitCode == 0 && File.Exists(outputPath));
                }
                catch (Exception error)
                {
                    // for debugging only for now
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
                bool split = false;

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // if the file and the Directory exist
                    if (FileHelper.Exists(inputFilePath) && FileHelper.Exists(ffmpegPath) && Directory.Exists(outputFolder))
                    {
                        // If the statusUpdate object exists
                        if (NullHelper.Exists(statusUpdate))
                        {
                            statusUpdate.Invoke("FFmpegHelper", "Splitting video into " + chunkLengthSeconds + " second chunks...");
                        }

                        // output pattern like chunk_000.mp4, chunk_001.mp4, etc.
                        string outputPattern = Path.Combine(outputFolder, "chunk_%03d.mp4");

                        Process process = new Process();
                        process.StartInfo.FileName = ffmpegPath;
                        process.StartInfo.Arguments = "-i \"" + inputFilePath + "\" -c copy -map 0 -f segment -segment_time " + chunkLengthSeconds + " \"" + outputPattern + "\"";
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

                        split = process.ExitCode == 0;

                        if (NullHelper.Exists(statusUpdate))
                        {
                            string message = split ? "Video split complete." : "Video split failed.";
                            statusUpdate.Invoke("FFmpegHelper", message);
                        }
                    }
                }
                catch (Exception error)
                {
                    DebugHelper.WriteDebugError("SplitVideo", "FFmpegHelper", error);
                }

                // return value
                return split;
            }
            #endregion
                        
        #endregion
        
    }
    #endregion

}