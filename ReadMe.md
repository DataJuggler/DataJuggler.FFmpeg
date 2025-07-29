# DataJuggler.FFmpeg

This project supports **Leonard** — a video upscaler that converts
an MP4 to an image sequence using FFmpeg, upscales those images with
**Real-ESRGAN Vulkan**, and then renders them back into a new MP4.

Project Leonard is coming soon. I hope to release Leonard by Tuesday, July 29th 
unless I get busy at work
https://github.com/DatgaJuggler/Leonard

Leonard also includes a **"Get Last Frame"** feature, which is useful for
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
is happening using FFmpeg or also RealESRGANHelper used for upscaling using Vulkan *

* Vulkan is where the name Leonard came from (Spock came from Vulcan). 

    // This delegate is used to receive info from long running processes 
    public delegate void StatusUpdate(string sender, string data);

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

If you find this prfoject, or any of my 100+ other projects worth the price, please leave a star!

https://github.com/DataJuggler/
