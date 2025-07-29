# DataJuggler.FFmpeg

This project is used in conjunction with Project Leonard — a video upscaler that converts
an MP4 to an image sequence using FFmpeg, upscales those images with
Real-ESRGAN Vulkan, and then renders them back into a new MP4.

The core of this project is a static helper class called FFmpegHelper.
This is the class you'll use to split videos, convert MP4s into image sequences, 
extract the last frame, or render a directory of images back into an MP4.

(Optional) You can pass in a callback method using the `StatusUpdate` delegate to receive 
real-time updates from FFmpeg during processing.

Project Leonard is coming soon. I hope to release Leonard by Thursday, July 31st.
https://github.com/DatgaJuggler/Leonard

This project also includes a "Get Last Frame" feature, which is useful for
creating continuing videos (where the first frame of the next video matches
the last frame of the previous one).

---

## Project Structure

DataJuggler.FFmpeg/
├── FFmpegHelper.cs
├── RegisteredEvents.cs
├── FFmpeg/
│   └── bin/
│       └── ffmpeg.exe


# StatusUpdate - Callback delegate to receive notifcations from long running processes. 

Also included in this project is a delegate called StatusUpdate, used to notify callers something
is happening using FFmpeg or also RealESRGANHelper used for upscaling using Vulkan.

Note: Vulkan is where the name Leonard came from (Spock came from Vulcan). 

    // This delegate is used to receive info from long running processes 
    public delegate void StatusUpdate(string sender, string data);

Create a method to receive callbacks, and pass in that method name in place of StatusUpdate

# Example Callback Method
    
To receive notifications, create a method in your project such as:

    /// <summary>
    /// This method is used to receive data from FFmpegHelper or RealESRGANHelper
    /// </summary>
    public void Callback(string senderName, string data)
    {
        // Path to a log file
        string temp = @"c:\Temp\Log.txt";

        // Log the messages coming in
        File.AppendAllText(temp, data);    
    }

Then to call any of the FFmpegHelper methods, pass in your Callback method for StatusUpdate.

If you do not need to receive notifications, pass in null for the StatusUpdate delegate.

If you find this project, or any of my 100+ other projects worth the price, please leave a star!

https://github.com/DataJuggler/

## Sample Code. This sesction provides guidance on how to call the methods in this project

## ConvertToImageSequence

Converts an MP4 into a numbered PNG sequence. The output will be in the format Image1.png,
Image2.png, etc.

     // modify the paths
    string inputPath = @"C:\Videos\MyInput.mp4";
    string outputFolder = @"C:\Frames\Output";

    // Perform convert from an mp4 to an image sequence
    bool result = FFmpegHelper.ConvertToImageSequence(inputPath, outputFolder);


## CreateMP4FromImages

The CreateMP4FromImages method will convert a directory of images into an MP4. 

    // modify the paths
    string inputPath = @"C:\Temp\Upscaled";
    string outputMp4Path = @"C:\Videos\Waterfall.mp4";

    // Create an MP4 from a directory of images
    bool result = FFmpegHelper.CreateMP4FromImages(inputPath, outputMp4Path, Callback, crf: 14, framerate: 30);


## ExtractLastFrame

The ExtractLastFrame method is useful with AI videos where you want to use the last frame
from one video as the first image in another continuing video. 

# This method will launch the last frame in your default image editor for .png's

    // change to your paths
    string inputPath = @"C:\Videos\MyInput.mp4";
    string outputPath = @"C:\Temp\LastFrame.png";

    // Extract the last frame
    bool result = FFmpegHelper.ExtractLastFrame(inputPath, outputPath);


## #region GetFFmpegPath()

This method is used internally to get the path to ffmpeg.exe, which is stored in this NuGet 
package. In most cases you should not have to call this method. It's only included for
documentation purposes.

        /// <summary>
        /// method returns the F Fmpeg Path
        /// </summary>
        public static string GetFFmpegPath()
        {
            // return the Path to the FFmpeg folder
            return Path.Combine(AppContext.BaseDirectory, "FFmpeg", "bin", "ffmpeg.exe");
        }
        
        
## SplitVideo

This method is used to split a video into smaller chunks. The Upscaling portion of Leonard is
extrremely slow. A 2 minute video at 30 FPS is 3,600 images. Splitting the video up into
smaller chunks is recommended. 

    // modify the paths
    string inputPath = @"C:\Videos\MyInput.mp4";
    string outputFolder = @"C:\Videos\Chunks";
    int chunkLength = 15;

    // Split the video into sections
    bool result = FFmpegHelper.SplitVideo(inputPath, outputFolder, Callback, chunkLength);

    If you have any problems or questions, please create an issue on GitHub.

# Credits

This project would not be possible without the incredible work of the FFmpeg team.

FFmpeg is a powerful multimedia framework used for video and audio processing. This 
project uses FFmpeg to extract frames, convert videos to image sequences, and 
reassemble videos. All video-related operations in this tool are powered by FFmpeg.

We do not modify or redistribute FFmpeg’s source. FFmpeg is included as a standalone 
executable, and all credit for its capabilities goes to the FFmpeg community.

FFmpeg is licensed under the GNU LGPL or GPL, depending on configuration.

Learn more at:  
<a href="https://ffmpeg.org/">https://ffmpeg.org/</a>  
<a href="https://github.com/FFmpeg/FFmpeg/blob/master/CREDITS">
FFmpeg contributor credits</a>