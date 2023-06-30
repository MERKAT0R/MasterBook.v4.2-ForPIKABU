// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.Operation
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.IO;


#nullable enable
namespace MasterBook4._0
{
  internal abstract class Operation
  {
    protected static 
    #nullable disable
    string Comment(
    #nullable enable
    string? comment) => comment == null || !(comment != "") ? "" : " (" + comment + ")";

    protected static 
    #nullable disable
    string MasterName(int masterGlobalID) => Base.GetMasterByGlobalID(masterGlobalID)?.Name ?? "<УДАЛЕНО>";

    public string ExecutionTime { get; protected set; }

    public abstract int? MasterGlobalID { get; }

    public abstract int? MerchGlobalID { get; }

    public abstract string CodeString { get; }

    public abstract string HistoryString { get; }

    public abstract 
    #nullable enable
    string? Validate { get; }

    public abstract string? ValidateCancel { get; }

    protected abstract void Execute();

    public abstract void Cancel();

    public void DoIt()
    {
      this.ExecutionTime = DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss");
      this.Execute();
    }

    public static 
    #nullable disable
    Operation FromBase(StreamReader baseFile)
    {
      string codeString = baseFile.ReadLine();
      OperationEnum int32 = (OperationEnum) Convert.ToInt32(codeString.Split(';')[0]);
      if (true)
        ;
      Operation operation;
      switch (int32)
      {
        case OperationEnum.CreateMaster:
          operation = (Operation) new CreateMaster(codeString);
          break;
        case OperationEnum.EditMaster:
          operation = (Operation) new EditMaster(codeString);
          break;
        case OperationEnum.PayDebt:
          operation = (Operation) new PayDebt(codeString);
          break;
        case OperationEnum.DeleteMaster:
          operation = (Operation) new DeleteMaster(codeString);
          break;
        case OperationEnum.CreateMerch:
          operation = (Operation) new CreateMerch(codeString);
          break;
        case OperationEnum.EditMerch:
          operation = (Operation) new EditMerch(codeString);
          break;
        case OperationEnum.SellMerch:
          operation = (Operation) new SellMerch(codeString);
          break;
        case OperationEnum.GiveBackMerch:
          operation = (Operation) new GiveBackMerch(codeString);
          break;
        case OperationEnum.AddMerch:
          operation = (Operation) new AddMerch(codeString);
          break;
        case OperationEnum.DeleteMerch:
          operation = (Operation) new DeleteMerch(codeString);
          break;
        default:
          operation = (Operation) null;
          break;
      }
      if (true)
        ;
      return operation;
    }
  }
}
