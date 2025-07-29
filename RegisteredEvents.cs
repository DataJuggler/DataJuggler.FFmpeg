

namespace DataJuggler.FFmpeg
{

    #region StatusUpdate(string sender, string data);
    /// <summary>
    /// This delegate is used to send info from FFmpeg back to MainForm
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="data"></param>
    public delegate void StatusUpdate(string sender, string data);
    #endregion

}
