// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.Master
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.IO;

namespace MasterBook4._0
{
  internal class Master
  {
    public int GlobalID { get; private set; }

    public string Name { get; private set; }

    public string Comment { get; private set; }

    public int Debt { get; set; }

    public string CodeString => this.GlobalID.ToString() + ";" + this.Name + ";" + this.Comment + ";" + this.Debt.ToString();

    public string ListString => this.Name + " (долг: " + this.Debt.ToString() + "р.)  " + this.Comment;

    public static Master FromBase(StreamReader baseFile)
    {
      string[] strArray = baseFile.ReadLine().Split(';');
      return new Master(Convert.ToInt32(strArray[0]), strArray[1], strArray[2])
      {
        Debt = Convert.ToInt32(strArray[3])
      };
    }

    public static Master FromOldBase(StreamReader baseFile)
    {
      string name = baseFile.ReadLine();
      string comment = baseFile.ReadLine();
      int int32_1 = Convert.ToInt32(baseFile.ReadLine());
      for (int index = 0; index < int32_1; ++index)
        baseFile.ReadLine();
      int int32_2 = Convert.ToInt32(baseFile.ReadLine());
      return new Master(Base.NewGlobalMasterID, name, comment)
      {
        Debt = int32_2
      };
    }

    public Master(int globalId, string name, string comment)
    {
      this.GlobalID = globalId;
      this.Name = name;
      this.Comment = comment;
      this.Debt = 0;
    }

    public void Edit(string name, string comment)
    {
      this.Name = name;
      this.Comment = comment;
    }
  }
}
