// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.Base
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MasterBook4._0
{
  internal static class Base
  {
    private static int lastGlobalMasterID;
    private static int lastGlobalMerchID;
    private static List<Master> Masters = new List<Master>();
    private static List<Merch> Merchs = new List<Merch>();
    private static List<Operation> History = new List<Operation>();

    public static int NewGlobalMasterID
    {
      get
      {
        ++Base.lastGlobalMasterID;
        return Base.lastGlobalMasterID;
      }
    }

    public static int NewGlobalMerchID
    {
      get
      {
        ++Base.lastGlobalMerchID;
        return Base.lastGlobalMerchID;
      }
    }

    public static int NewLocalMerchID
    {
      get
      {
        int id = 0;
        while (Base.Merchs.Find((Predicate<Merch>) (m => m.LocalID == id)) != null)
          id++;
        return id;
      }
    }

    public static int FullDebt
    {
      get
      {
        int num = 0;
        foreach (Master master in Base.Masters)
          num += master.Debt;
        return num;
      }
    }

    public static Master GetMasterByGlobalID(int globalID) => Base.Masters.Find((Predicate<Master>) (m => m.GlobalID == globalID));

    public static Master GetMasterByName(string name) => Base.Masters.Find((Predicate<Master>) (m => m.Name == name));

    public static void AddMaster(Master m) => Base.Masters.Add(m);

    public static void DeleteMaster(int globalID) => Base.Masters.RemoveAll((Predicate<Master>) (m => globalID == m.GlobalID));

    public static List<Master> FindMasterByName(string masterName) => Base.Masters.FindAll((Predicate<Master>) (m => m.Name.ToLower().Contains(masterName.ToLower())));

    public static Merch GetMerchByGlobalID(int globalID) => Base.Merchs.Find((Predicate<Merch>) (m => m.GlobalID == globalID));

    public static Merch GetMerchByLocalID(int localID) => Base.Merchs.Find((Predicate<Merch>) (m => m.LocalID == localID));

    public static void AddMerch(Merch m) => Base.Merchs.Add(m);

    public static void DeleteMerch(int globalID) => Base.Merchs.RemoveAll((Predicate<Merch>) (m => globalID == m.GlobalID));

    public static List<Merch> FindMerchByNameAndMasterName(
      string merchName,
      string masterName)
    {
      return Base.Merchs.FindAll((Predicate<Merch>) (m => m.Name.ToLower().Contains(merchName.ToLower()) && m.Owner.Name.ToLower().Contains(masterName.ToLower())));
    }

    public static List<Merch> FindMerchByMaster(Master owner) => Base.Merchs.FindAll((Predicate<Merch>) (m => m.Owner == owner));

    public static List<Merch> FindMerchByNameAndMaster(string merchName, Master owner) => Base.Merchs.FindAll((Predicate<Merch>) (m => m.Name.ToLower().Contains(merchName.ToLower()) && m.Owner == owner));

    public static List<Operation> GetMasterHistory(Master m) => Base.History.FindAll((Predicate<Operation>) (o =>
    {
      int? masterGlobalId = o.MasterGlobalID;
      int globalId = m.GlobalID;
      return masterGlobalId.GetValueOrDefault() == globalId & masterGlobalId.HasValue;
    }));

    public static List<Operation> GetMasterHistoryFromTo(
      Master m,
      string startTime,
      string endTime)
    {
      return Base.History.FindAll((Predicate<Operation>) (o =>
      {
        int? masterGlobalId = o.MasterGlobalID;
        int globalId = m.GlobalID;
        return masterGlobalId.GetValueOrDefault() == globalId & masterGlobalId.HasValue && string.Compare(o.ExecutionTime, startTime) > 0 && string.Compare(o.ExecutionTime, endTime) < 0;
      }));
    }

    public static List<Operation> GetMasterHistorySincePayment(Master m)
    {
      List<Operation> all = Base.History.FindAll((Predicate<Operation>) (o =>
      {
        int? masterGlobalId = o.MasterGlobalID;
        int globalId = m.GlobalID;
        return masterGlobalId.GetValueOrDefault() == globalId & masterGlobalId.HasValue;
      }));
      int index = all.FindIndex((Predicate<Operation>) (o => o.GetType() == typeof (PayDebt)));
      if (index == -1)
        return all;
      return index == all.Count - 1 ? new List<Operation>() : all.GetRange(index + 1, all.Count - index - 1);
    }

    public static List<Operation> GetMerchHistory(Merch m) => Base.History.FindAll((Predicate<Operation>) (o =>
    {
      int? merchGlobalId = o.MerchGlobalID;
      int globalId = m.GlobalID;
      return merchGlobalId.GetValueOrDefault() == globalId & merchGlobalId.HasValue;
    }));

    public static List<Operation> GetMerchHistoryFromTo(
      Merch m,
      string startTime,
      string endTime)
    {
      return Base.History.FindAll((Predicate<Operation>) (o =>
      {
        int? merchGlobalId = o.MerchGlobalID;
        int globalId = m.GlobalID;
        return merchGlobalId.GetValueOrDefault() == globalId & merchGlobalId.HasValue && string.Compare(o.ExecutionTime, startTime) > 0 && string.Compare(o.ExecutionTime, endTime) < 0;
      }));
    }

    public static Operation GetLastOperation() => Base.History.Count <= 0 ? (Operation) null : Base.History.Last<Operation>();

    public static void AddOperation(Operation o) => Base.History.Add(o);

    public static void CancelOperation(Operation o) => Base.History.Remove(o);

    public static void ExportOperationList(List<Operation> h)
    {
      StreamWriter streamWriter = new StreamWriter("history.txt");
      foreach (Operation operation in h)
        streamWriter.WriteLine(operation.HistoryString);
      streamWriter.Close();
    }

    public static void LoadOldBase(string fileName)
    {
      Controller.LogString(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " ЗАГРУЗКА БАЗЫ СТАРОГО ФОРМАТА " + fileName);
      StreamReader baseFile = new StreamReader(fileName);
      Base.Masters = new List<Master>();
      Base.Merchs = new List<Merch>();
      Base.History = new List<Operation>();
      int int32_1 = Convert.ToInt32(baseFile.ReadLine());
      for (int index1 = 0; index1 < int32_1; ++index1)
      {
        Master _owner = Master.FromOldBase(baseFile);
        Base.Masters.Add(_owner);
        int int32_2 = Convert.ToInt32(baseFile.ReadLine());
        for (int index2 = 0; index2 < int32_2; ++index2)
          Base.Merchs.Add(Merch.FromOldBase(baseFile, _owner));
      }
      baseFile.Close();
    }

    public static void LoadBase(string fileName)
    {
      Controller.LogString(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " ЗАГРУЗКА " + fileName);
      StreamReader baseFile = new StreamReader(fileName);
      string[] strArray = baseFile.ReadLine().Split(';');
      Base.lastGlobalMasterID = Convert.ToInt32(strArray[0]);
      Base.lastGlobalMerchID = Convert.ToInt32(strArray[1]);
      int int32_1 = Convert.ToInt32(strArray[2]);
      int int32_2 = Convert.ToInt32(strArray[3]);
      int int32_3 = Convert.ToInt32(strArray[4]);
      Base.Masters = new List<Master>();
      Base.Merchs = new List<Merch>();
      Base.History = new List<Operation>();
      for (int index = 0; index < int32_1; ++index)
        Base.Masters.Add(Master.FromBase(baseFile));
      for (int index = 0; index < int32_2; ++index)
        Base.Merchs.Add(Merch.FromBase(baseFile));
      for (int index = 0; index < int32_3; ++index)
        Base.History.Add(Operation.FromBase(baseFile));
      baseFile.Close();
    }

    public static void SaveBase(string fileName)
    {
      Controller.LogString(DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + " СОХРАНЕНИЕ " + fileName);
      StreamWriter streamWriter = new StreamWriter(fileName);
      streamWriter.WriteLine(Base.lastGlobalMasterID.ToString() + ";" + Base.lastGlobalMerchID.ToString() + ";" + Base.Masters.Count<Master>().ToString() + ";" + Base.Merchs.Count<Merch>().ToString() + ";" + Base.History.Count<Operation>().ToString());
      foreach (Master master in Base.Masters)
        streamWriter.WriteLine(master.CodeString);
      foreach (Merch merch in Base.Merchs)
        streamWriter.WriteLine(merch.CodeString);
      foreach (Operation operation in Base.History)
        streamWriter.WriteLine(operation.CodeString);
      streamWriter.Close();
    }
  }
}
