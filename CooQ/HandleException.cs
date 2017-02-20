using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CooQGenerate
{
  class HandleException
  {
    #region Impl for global exception
    public static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
      ShowMessage(e.Exception);
    }

    public static void MyHandler(object sender, UnhandledExceptionEventArgs args)
    {
      try
      {
        Exception e = (Exception)args.ExceptionObject;
        ShowMessage(e);
      }
      finally
      {
        Application.ExitThread();
        Application.Exit();
      }
    }

    public static void ShowMessage(Exception e, String message = "")
    {
      LogMessage(e, message);
      System.Windows.Forms.MessageBox.Show(
        e.Message ?? message,
        "CooQ Generator",
        MessageBoxButtons.OK,
        MessageBoxIcon.Error);
    }

    public static void LogMessage(Exception e, String message = "")
    {
      Logs.LogFactory.Error(e.Message ?? message, e);
      Debug.Print(">>LangMessage: " + message + "\r\n" +
                  ">>ExceptionMessage: " + e.Message + "\r\n" +
                  ">>Stacktrace: " + e.StackTrace);      
    }

    #endregion

    internal static void Init()
    {
      #region Hook for global exception
      //hook for exception from UI thread 
      Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(
        HandleException.Application_ThreadException);
      //hook for exception from non UI thread                                         
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException.MyHandler);
      #endregion
    }
  }
}
