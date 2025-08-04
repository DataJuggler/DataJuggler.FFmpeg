

#region using statements

using System;
using System.Diagnostics;

#endregion

namespace DataJuggler.Shared
{

    #region class ProcessResult
    /// <summary>
    /// Represents the result of a long-running or background-launched external process like FFmpeg or Real-ESRGAN.
    /// </summary>
    public class ProcessResult
    {
        
        #region Private Variables
        private TimeSpan duration;
        private string errorText;
        private int exitCode;
        private string methodName;
        private string outputText;
        private Process process;
        private bool success;
        #endregion
        
        #region Events
            
        #endregion
        
        #region Methods

            #region KillProcess
            /// <summary>
            /// Attempts to kill the process if it exists and hasn't exited.
            /// </summary>
            public void KillProcess()
            {
                if (HasProcess)
                {
                    try
                    {
                        process.Kill(true); // 'true' kills entire process tree
                        process.WaitForExit(); // ensure it has exited
                    }
                    catch (Exception ex)
                    {
                        // Optionally store the error
                        this.errorText = "KillProcess Exception: " + ex.Message;
                    }
                }
            }
            #endregion
            
        #endregion
        
        #region Properties
            
            #region Duration
            /// <summary>
            /// This property gets or sets the value for 'Duration'.
            /// </summary>
            public TimeSpan Duration
            {
                get { return duration; }
                set { duration = value; }
            }
            #endregion
            
            #region ErrorText
            /// <summary>
            /// This property gets or sets the value for 'ErrorText'.
            /// </summary>
            public string ErrorText
            {
                get { return errorText; }
                set { errorText = value; }
            }
            #endregion
            
            #region ExitCode
            /// <summary>
            /// This property gets or sets the value for 'ExitCode'.
            /// </summary>
            public int ExitCode
            {
                get { return exitCode; }
                set { exitCode = value; }
            }
            #endregion
            
            #region HasProcess
            /// <summary>
            /// This property returns true if this object has a 'Process'.
            /// </summary>
            public bool HasProcess
            {
                get
                {
                    // initial value
                    bool hasProcess = (Process != null);

                    // return value
                    return hasProcess;
                }
            }
            #endregion
            
            #region MethodName
            /// <summary>
            /// This property gets or sets the value for 'MethodName'.
            /// </summary>
            public string MethodName
            {
                get { return methodName; }
                set { methodName = value; }
            }
            #endregion
            
            #region OutputText
            /// <summary>
            /// This property gets or sets the value for 'OutputText'.
            /// </summary>
            public string OutputText
            {
                get { return outputText; }
                set { outputText = value; }
            }
            #endregion
            
            #region Process
            /// <summary>
            /// This property gets or sets the value for 'Process'.
            /// </summary>
            public Process Process
            {
                get { return process; }
                set { process = value; }
            }
            #endregion
            
            #region Success
            /// <summary>
            /// This property gets or sets the value for 'Success'.
            /// </summary>
            public bool Success
            {
                get { return success; }
                set { success = value; }
            }
            #endregion
            
        #endregion
        
    }
    #endregion

}
