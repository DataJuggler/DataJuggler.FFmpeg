
#region using statements

using DataJuggler.Shared;
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
            public static ProcessResult CleanseVideo(string inputPath, string outputPath, StatusUpdate callback)
            {
                // initial value
                ProcessResult result = new ProcessResult();
                result.MethodName = "CleanseVideo";

                try
                {
                    // get ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // verify input and output
                    if (FileHelper.Exists(inputPath) && TextHelper.Exists(outputPath) && FileHelper.Exists(ffmpegPath))
                    {
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

                        Process process = new Process { StartInfo = startInfo };

                        DateTime startTime = DateTime.Now;

                        process.Start();
                        string ffmpegOutput = process.StandardError.ReadToEnd();
                        process.WaitForExit();

                        result.Process = process;
                        result.OutputText = ""; // stdout isn't used
                        result.ErrorText = ffmpegOutput.Trim();
                        result.ExitCode = process.ExitCode;
                        result.Duration = DateTime.Now - startTime;
                        result.Success = (File.Exists(outputPath) && process.ExitCode == 0);

                        if (NullHelper.Exists(callback))
                        {
                            string summary = result.Success ? "Cleanse succeeded." : "Cleanse failed.";
                            callback("FFmpegHelper", $"{summary} ExitCode: {result.ExitCode} Output: {result.ErrorText}");
                        }
                    }
                    else
                    {
                        result.ErrorText = "Invalid input or missing ffmpeg path or output path.";
                        if (NullHelper.Exists(callback))
                        {
                            callback("FFmpegHelper", result.ErrorText);
                        }
                    }
                }
                catch (Exception error)
                {
                    result.ErrorText = "Exception: " + error.Message;

                    if (NullHelper.Exists(callback))
                    {
                        callback("FFmpegHelper", result.ErrorText);
                    }
                }

                // return value
                return result;
            }
            #endregion

            #region ConvertToImageSequence(string inputPath, string outputFolder, StatusUpdate callback)
            /// <summary>
            /// Converts an MP4 to an image sequence of PNGs.
            /// </summary>                                   
            public static ProcessResult ConvertToImageSequence(string inputPath, string outputFolder, StatusUpdate callback)
            {
                // initial value
                ProcessResult result = new ProcessResult();
                result.MethodName = "ConvertToImageSequence";

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // If the Directory exists
                    if (FolderHelper.Exists(outputFolder))
                    {
                        // create a temp file
                        string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputPath, 12);

                        // cleanse the video
                        ProcessResult cleanseResult = CleanseVideo(inputPath, cleansedFilePath, callback);

                        // if cleansed
                        if (cleanseResult.Success)
                        {
                            Process process = new Process();
                            process.StartInfo.FileName = ffmpegPath;
                            process.StartInfo.Arguments = $"-i \"{cleansedFilePath}\" \"{Path.Combine(outputFolder, "Image%d.png")}\"";
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.RedirectStandardOutput = false;
                            process.StartInfo.RedirectStandardError = true;

                            // Start timing
                            DateTime startTime = DateTime.Now;

                            process.Start();
                            process.WaitForExit();

                            // Fill result
                            result.Process = process;
                            result.ExitCode = process.ExitCode;
                            result.Duration = DateTime.Now - startTime;
                            result.Success = (process.ExitCode == 0);

                            if (!result.Success)
                            {
                                result.ErrorText = process.StandardError.ReadToEnd();
                            }
                        }
                        else
                        {
                            result.ErrorText = "Video cleansing failed.";
                        }
                    }
                    else
                    {
                        result.ErrorText = "Output folder not found: " + outputFolder;
                    }
                }
                catch (Exception error)
                {
                    result.ErrorText = "Exception: " + error.ToString();

                    if (NullHelper.Exists(callback))
                    {
                        callback("FFmpegHelper - ConvertToImageSequence", "Error: " + result.ErrorText);
                    }
                }

                // return value
                return result;
            }
            #endregion
            
            #region CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 14, int frameRate = 30)
            /// <summary>
            /// Creates an MP4 from a sequence of images using FFmpeg.
            /// </summary>
            public static ProcessResult CreateMP4FromImages(string imageFolder, string outputMp4Path, StatusUpdate statusUpdate, int crf = 14, int frameRate = 30)
            {
                // initial value
                ProcessResult result = new ProcessResult();

                // Set the method name
                result.MethodName = "CreateMP4FromImages";

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    Process process = new Process();
                    process.StartInfo.FileName = ffmpegPath;

                    // assumes filenames like Image1.png, Image2.png ...
                    process.StartInfo.Arguments = $"-framerate {frameRate} -i \"{Path.Combine(imageFolder, "Image%d.png")}\" " +
                        $"-c:v libx264 -crf {crf} -preset slow -pix_fmt yuv420p -loglevel error -progress pipe:1 " +
                        $"\"{outputMp4Path}\"";

                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    // Collect output text
                    string outputText = string.Empty;
                    string errorText = string.Empty;

                    // send error messages
                    process.ErrorDataReceived += (sender, e) =>
                    {
                        if (TextHelper.Exists(e.Data))
                        {
                            errorText += e.Data + Environment.NewLine;

                            if (NullHelper.Exists(statusUpdate))
                            {
                                statusUpdate("FFmpegHelper", "[stderr] " + e.Data);
                            }
                        }
                    };

                    // send info back to caller
                    process.OutputDataReceived += (sender, e) =>
                    {
                        if (TextHelper.Exists(e.Data))
                        {
                            outputText += e.Data + Environment.NewLine;

                            if (NullHelper.Exists(statusUpdate))
                            {
                                statusUpdate("FFmpegHelper", e.Data);
                            }
                        }
                    };

                    DateTime startTime = DateTime.Now;

                    process.Start();
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();

                    // fill in result
                    result.Process = process;
                    result.OutputText = outputText.Trim();
                    result.ErrorText = errorText.Trim();
                    result.ExitCode = process.ExitCode;
                    result.Duration = DateTime.Now - startTime;
                    result.Success = (process.ExitCode == 0 && File.Exists(outputMp4Path));
                }
                catch (Exception error)
                {
                    result.ErrorText = "Exception: " + error.ToString();
                    DebugHelper.WriteDebugError("CreateMP4FromImages", "FFmpegHelper", error);
                }

                // return value
                return result;
            }
            #endregion

            #region ExtractLastFrame(string inputPath, string outputPath, StatusUpdate callback)
            /// <summary>
            /// Extracts the last frame of a video using FFmpeg.
            /// </summary>
            public static ProcessResult ExtractLastFrame(string inputPath, string outputPath, StatusUpdate callback)
            {
                // initial value
                ProcessResult result = new ProcessResult();
                result.MethodName = "ExtractLastFrame";

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // create a temp file
                    string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputPath, 12);

                   // cleanse the video
                    ProcessResult cleanseResult = CleanseVideo(inputPath, cleansedFilePath, callback);

                    // if cleansed
                    if (cleanseResult.Success)
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = ffmpegPath;
                        process.StartInfo.Arguments = $"-sseof -1 -i \"{cleansedFilePath}\" -update 1 -q:v 1 \"{outputPath}\"";
                        process.StartInfo.CreateNoWindow = true;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.RedirectStandardOutput = true;
                        process.StartInfo.RedirectStandardError = true;

                        DateTime startTime = DateTime.Now;

                        process.Start();

                        string errorText = process.StandardError.ReadToEnd();

                        process.WaitForExit();

                        result.Process = process;
                        result.ExitCode = process.ExitCode;
                        result.ErrorText = errorText.Trim();
                        result.OutputText = ""; // Not used in this case
                        result.Duration = DateTime.Now - startTime;
                        result.Success = (process.ExitCode == 0 && File.Exists(outputPath));
                    }
                    else
                    {
                        result.ErrorText = "Video cleansing failed.";
                    }
                }
                catch (Exception error)
                {
                    result.ErrorText = "Exception: " + error.ToString();
                    DebugHelper.WriteDebugError("ExtractLastFrame", "FFmpegHelper", error);
                }

                // return value
                return result;
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
            public static ProcessResult SplitVideo(string inputFilePath, string outputFolder, StatusUpdate statusUpdate, int chunkLengthSeconds = 15)
            {
                // initial value
                ProcessResult result = new ProcessResult();
                result.MethodName = "SplitVideo";

                try
                {
                    // determine ffmpeg path
                    string ffmpegPath = GetFFmpegPath();

                    // validate input
                    if (FileHelper.Exists(inputFilePath) && FileHelper.Exists(ffmpegPath) && Directory.Exists(outputFolder))
                    {
                        // create a temp file
                        string cleansedFilePath = FileHelper.CreateFileNameWithPartialGuid(inputFilePath, 12);

                        // cleanse the video
                        ProcessResult cleanseResult = CleanseVideo(inputFilePath, cleansedFilePath, statusUpdate);

                        // if cleansed
                        if (cleanseResult.Success)
                        {
                            if (NullHelper.Exists(statusUpdate))
                            {
                                statusUpdate("FFmpegHelper", $"Splitting video into {chunkLengthSeconds} second chunks...");
                            }

                            string outputPattern = Path.Combine(outputFolder, "chunk_%03d.mp4");

                            Process process = new Process();
                            process.StartInfo.FileName = ffmpegPath;
                            process.StartInfo.Arguments = $"-i \"{cleansedFilePath}\" -c copy -map 0 -f segment -segment_time {chunkLengthSeconds} \"{outputPattern}\"";
                            process.StartInfo.UseShellExecute = false;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.RedirectStandardError = true;

                            string outputText = string.Empty;
                            string errorText = string.Empty;

                            process.OutputDataReceived += (sender, e) =>
                            {
                                if (TextHelper.Exists(e.Data))
                                {
                                    outputText += e.Data + Environment.NewLine;
                                    if (NullHelper.Exists(statusUpdate))
                                    {
                                        statusUpdate("FFmpegHelper", e.Data);
                                    }
                                }
                            };

                            process.ErrorDataReceived += (sender, e) =>
                            {
                                if (TextHelper.Exists(e.Data))
                                {
                                    errorText += e.Data + Environment.NewLine;
                                    if (NullHelper.Exists(statusUpdate))
                                    {
                                        statusUpdate("FFmpegHelper", e.Data);
                                    }
                                }
                            };

                            DateTime startTime = DateTime.Now;

                            process.Start();
                            process.BeginOutputReadLine();
                            process.BeginErrorReadLine();
                            process.WaitForExit();

                            result.Process = process;
                            result.OutputText = outputText.Trim();
                            result.ErrorText = errorText.Trim();
                            result.ExitCode = process.ExitCode;
                            result.Duration = DateTime.Now - startTime;
                            result.Success = (process.ExitCode == 0);

                            if (NullHelper.Exists(statusUpdate))
                            {
                                string message = result.Success ? "Video split complete." : "Video split failed.";
                                statusUpdate("FFmpegHelper", message);
                            }
                        }
                        else
                        {
                            result.ErrorText = "Video cleansing failed.";
                        }
                    }
                    else
                    {
                        result.ErrorText = "Missing file, FFmpeg path, or output folder.";
                    }
                }
                catch (Exception error)
                {
                    result.ErrorText = "Exception: " + error.Message;

                    if (NullHelper.Exists(statusUpdate))
                    {
                        statusUpdate("FFmpegHelper", "Error: " + result.ErrorText);
                    }
                    else
                    {
                        DebugHelper.WriteDebugError("SplitVideo", "FFmpegHelper", error);
                    }
                }

                // return value
                return result;
            }
            #endregion
                        
        #endregion
        
    }
    #endregion

}