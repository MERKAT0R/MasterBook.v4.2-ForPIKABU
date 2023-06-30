// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.Controller
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MasterBook4._0
{
  internal static class Controller
  {
    public static void LogString(string s)
    {
      StreamWriter streamWriter = new StreamWriter("log.txt", true, Encoding.Unicode);
      streamWriter.WriteLine(s);
      streamWriter.Close();
    }

    public static bool Execute(Operation o)
    {
      string validate = o.Validate;
      if (validate != null)
      {
        int num = (int) MessageBox.Show(validate, "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        o.DoIt();
        Base.AddOperation(o);
        Controller.LogString(o.HistoryString);
      }
      return validate == null;
    }

    public static bool Cancel(Operation o)
    {
      string validateCancel = o.ValidateCancel;
      if (validateCancel != null)
      {
        int num = (int) MessageBox.Show(validateCancel, "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        o.Cancel();
        Base.CancelOperation(o);
        Controller.LogString(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " ОТМЕНЕНО " + o.HistoryString);
      }
      return validateCancel == null;
    }
  }
}
