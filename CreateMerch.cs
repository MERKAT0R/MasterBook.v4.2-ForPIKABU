// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.CreateMerch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class CreateMerch : Operation
  {
    private int _globalID;
    private int _ownerGlobalID;
    private int _localID;
    private int _price;
    private int _markup;
    private int _amount;
    private 
    #nullable disable
    string _name;
    private string _comment;

    public CreateMerch(
      int ownerGlobalID,
      string name,
      int price,
      int markup,
      int amount,
      string comment)
    {
      int num1 = ownerGlobalID;
      string str1 = name;
      int num2 = price;
      int num3 = markup;
      int num4 = amount;
      string str2 = comment;
      this._ownerGlobalID = num1;
      this._name = str1;
      this._price = num2;
      this._markup = num3;
      this._amount = num4;
      this._comment = str2;
    }

    public CreateMerch(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._localID = Convert.ToInt32(strArray[2]);
      this._ownerGlobalID = Convert.ToInt32(strArray[3]);
      this._name = strArray[4];
      this._price = Convert.ToInt32(strArray[5]);
      this._markup = Convert.ToInt32(strArray[6]);
      this._amount = Convert.ToInt32(strArray[7]);
      this._comment = strArray[8];
      this.ExecutionTime = strArray[9];
    }

    public override int? MasterGlobalID => new int?(this._ownerGlobalID);

    public override int? MerchGlobalID => new int?(this._globalID);

    public int MerchLocalID => this._localID;

    public override string CodeString => 4.ToString() + ";" + this._globalID.ToString() + ";" + this._localID.ToString() + ";" + this._ownerGlobalID.ToString() + ";" + this._name + ";" + this._price.ToString() + ";" + this._markup.ToString() + ";" + this._amount.ToString() + ";" + this._comment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " СОЗДАН ТОВАР " + this._name + Operation.Comment(this._comment) + " ID:" + this._localID.ToString() + " " + (this._price - this._markup).ToString() + "+" + this._markup.ToString() + "=" + this._price.ToString() + "р. " + this._amount.ToString() + "шт. Мастер: " + Operation.MasterName(this._ownerGlobalID);

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        if (this._name.Contains(";") || this._comment.Contains(";"))
          return "Нельзя использовать точку с запятой!";
        return this._price >= 0 && this._markup >= 0 && this._amount >= 0 ? (string) null : "Цена, наценка и количество не могут быть отрицательными!";
      }
    }

    public override string? ValidateCancel => Base.GetMerchByGlobalID(this._globalID).Amount <= 0 ? (string) null : "Нельзя удалить не закончившийся товар!";

    protected override void Execute()
    {
      this._globalID = Base.NewGlobalMerchID;
      this._localID = Base.NewLocalMerchID;
      Base.AddMerch(new Merch(this._globalID, this._localID, Base.GetMasterByGlobalID(this._ownerGlobalID), this._name, this._price, this._markup, this._amount, this._comment));
    }

    public override void Cancel() => Base.DeleteMerch(this._globalID);
  }
}
