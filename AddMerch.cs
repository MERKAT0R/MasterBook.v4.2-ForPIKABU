// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.AddMerch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class AddMerch : Operation
  {
    private int _globalID;
    private int _localID;
    private int _ownerGlobalID;
    private int _addedAmount;
    private 
    #nullable disable
    string _name;

    public AddMerch(int globalID, int addedAmount)
    {
      int num1 = globalID;
      int num2 = addedAmount;
      this._globalID = num1;
      this._addedAmount = num2;
      Merch merchByGlobalId = Base.GetMerchByGlobalID(this._globalID);
      int localId = merchByGlobalId.LocalID;
      int globalId = merchByGlobalId.Owner.GlobalID;
      string name = merchByGlobalId.Name;
      this._localID = localId;
      this._ownerGlobalID = globalId;
      this._name = name;
    }

    public AddMerch(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._localID = Convert.ToInt32(strArray[2]);
      this._ownerGlobalID = Convert.ToInt32(strArray[3]);
      this._addedAmount = Convert.ToInt32(strArray[4]);
      this._name = strArray[5];
      this.ExecutionTime = strArray[6];
    }

    public override int? MasterGlobalID => new int?(this._ownerGlobalID);

    public override int? MerchGlobalID => new int?(this._globalID);

    public override string CodeString => 8.ToString() + ";" + this._globalID.ToString() + ";" + this._localID.ToString() + ";" + this._ownerGlobalID.ToString() + ";" + this._addedAmount.ToString() + ";" + this._name + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " ДОБАВЛЕНО " + this._addedAmount.ToString() + "шт. Товара " + this._name + " ID:" + this._localID.ToString() + " мастера " + Operation.MasterName(this._ownerGlobalID);

    public override 
    #nullable enable
    string? Validate => this._addedAmount >= 1 ? (string) null : "Нельзя вернуть не положительное количество товара!";

    public override string? ValidateCancel
    {
      get
      {
        Merch merchByGlobalId = Base.GetMerchByGlobalID(this._globalID);
        return merchByGlobalId == null ? "Этого товара уже не существует!" : (merchByGlobalId.Amount < this._addedAmount ? "Недостаточно товара!" : (string) null);
      }
    }

    protected override void Execute() => Base.GetMerchByGlobalID(this._globalID).ChangeAmount(this._addedAmount);

    public override void Cancel() => Base.GetMerchByGlobalID(this._globalID).ChangeAmount(-this._addedAmount);
  }
}
