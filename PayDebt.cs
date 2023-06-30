// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.PayDebt
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class PayDebt : Operation
  {
    private int _globalID;
    private int _debt;
    private 
    #nullable disable
    string _name;

    public PayDebt(int globalID, int debt)
    {
      this._globalID = globalID;
      this._debt = debt;
      this._name = Base.GetMasterByGlobalID(this._globalID).Name;
    }

    public PayDebt(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._name = strArray[2];
      this._debt = Convert.ToInt32(strArray[3]);
      this.ExecutionTime = strArray[4];
    }

    public override int? MasterGlobalID => new int?(this._globalID);

    public override int? MerchGlobalID => new int?();

    public override string CodeString => 2.ToString() + ";" + this._globalID.ToString() + ";" + this._name + ";" + this._debt.ToString() + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " ВЫПЛАЧЕН ДОЛГ " + this._debt.ToString() + "р. Мастеру " + this._name;

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        if (this._debt <= 0)
          return "Нельзя выплатить нулевой долг!";
        return Base.GetMasterByGlobalID(this._globalID).Debt >= this._debt ? (string) null : "Нельзя выплатить больше, чем есть!";
      }
    }

    public override string? ValidateCancel => Base.GetMasterByGlobalID(this._globalID) != null ? (string) null : "Этот мастер удалён!";

    protected override void Execute() => Base.GetMasterByGlobalID(this._globalID).Debt -= this._debt;

    public override void Cancel() => Base.GetMasterByGlobalID(this._globalID).Debt += this._debt;
  }
}
