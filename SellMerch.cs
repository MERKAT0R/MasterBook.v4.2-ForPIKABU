// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.SellMerch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class SellMerch : Operation
  {
    private int _globalID;
    private int _localID;
    private int _ownerGlobalID;
    private int _soldAmount;
    private int _price;
    private int _markup;
    private 
    #nullable disable
    string _name;

    public SellMerch(int globalID, int soldAmount)
    {
      int num1 = globalID;
      int num2 = soldAmount;
      this._globalID = num1;
      this._soldAmount = num2;
      Merch merchByGlobalId = Base.GetMerchByGlobalID(this._globalID);
      int localId = merchByGlobalId.LocalID;
      int globalId = merchByGlobalId.Owner.GlobalID;
      string name = merchByGlobalId.Name;
      int price = merchByGlobalId.Price;
      int markup = merchByGlobalId.Markup;
      this._localID = localId;
      this._ownerGlobalID = globalId;
      this._name = name;
      this._price = price;
      this._markup = markup;
    }

    public SellMerch(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._localID = Convert.ToInt32(strArray[2]);
      this._ownerGlobalID = Convert.ToInt32(strArray[3]);
      this._soldAmount = Convert.ToInt32(strArray[4]);
      this._name = strArray[5];
      this._price = Convert.ToInt32(strArray[6]);
      this._markup = Convert.ToInt32(strArray[7]);
      this.ExecutionTime = strArray[8];
    }

    public override int? MasterGlobalID => new int?(this._ownerGlobalID);

    public override int? MerchGlobalID => new int?(this._globalID);

    public override string CodeString => 6.ToString() + ";" + this._globalID.ToString() + ";" + this._localID.ToString() + ";" + this._ownerGlobalID.ToString() + ";" + this._soldAmount.ToString() + ";" + this._name + ";" + this._price.ToString() + ";" + this._markup.ToString() + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " ПРОДАНО " + this._soldAmount.ToString() + "шт. Товара " + this._name + " ID:" + this._localID.ToString() + " за " + (this._price * this._soldAmount).ToString() + "р. Долг мастеру " + Operation.MasterName(this._ownerGlobalID) + " увеличился на " + ((this._price - this._markup) * this._soldAmount).ToString() + "р. ";

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        if (this._soldAmount < 1)
          return "Нельзя продать не положительное количество товара!";
        return this._soldAmount <= Base.GetMerchByGlobalID(this._globalID).Amount ? (string) null : "Недостаточно товара!";
      }
    }

    public override string? ValidateCancel => Base.GetMerchByGlobalID(this._globalID) != null ? (string) null : "Этого товара уже не существует!";

    protected override void Execute() => Base.GetMerchByGlobalID(this._globalID).Sell(this._soldAmount);

    public override void Cancel() => Base.GetMerchByGlobalID(this._globalID).Sell(-this._soldAmount);
  }
}
