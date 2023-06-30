// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.DeleteMerch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class DeleteMerch : Operation
  {
    private int _globalID;
    private int _ownerGlobalID;
    private int _localID;
    private int _price;
    private int _markup;
    private 
    #nullable disable
    string _name;
    private string _comment;

    public DeleteMerch(int globalID)
    {
      this._globalID = globalID;
      Merch merchByGlobalId = Base.GetMerchByGlobalID(this._globalID);
      int globalId = merchByGlobalId.Owner.GlobalID;
      int localId = merchByGlobalId.LocalID;
      string name = merchByGlobalId.Name;
      int price = merchByGlobalId.Price;
      int markup = merchByGlobalId.Markup;
      string comment = merchByGlobalId.Comment;
      this._ownerGlobalID = globalId;
      this._localID = localId;
      this._name = name;
      this._price = price;
      this._markup = markup;
      this._comment = comment;
    }

    public DeleteMerch(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._localID = Convert.ToInt32(strArray[2]);
      this._ownerGlobalID = Convert.ToInt32(strArray[3]);
      this._name = strArray[4];
      this._price = Convert.ToInt32(strArray[5]);
      this._markup = Convert.ToInt32(strArray[6]);
      this._comment = strArray[7];
      this.ExecutionTime = strArray[8];
    }

    public override int? MasterGlobalID => new int?(this._ownerGlobalID);

    public override int? MerchGlobalID => new int?(this._globalID);

    public override string CodeString => 9.ToString() + ";" + this._globalID.ToString() + ";" + this._localID.ToString() + ";" + this._ownerGlobalID.ToString() + ";" + this._name + ";" + this._price.ToString() + ";" + this._markup.ToString() + ";" + this._comment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " УДАЛЁН ТОВАР " + this._name + " ID: " + this._localID.ToString() + " " + (this._price - this._markup).ToString() + "+" + this._markup.ToString() + "=" + this._price.ToString() + "р. Мастер: " + Operation.MasterName(this._ownerGlobalID);

    public override 
    #nullable enable
    string? Validate => Base.GetMerchByGlobalID(this._globalID).Amount <= 0 ? (string) null : "Нельзя удалить не закончившийся товар!";

    public override string? ValidateCancel
    {
      get
      {
        if (Base.GetMasterByGlobalID(this._globalID) == null)
          return "Мастер, которому принадлежал этот товар, удалён!";
        return Base.GetMerchByLocalID(this._localID) == null ? (string) null : "ID этого товара уже занят!";
      }
    }

    protected override void Execute() => Base.DeleteMerch(this._globalID);

    public override void Cancel() => Base.AddMerch(new Merch(this._globalID, this._localID, Base.GetMasterByGlobalID(this._ownerGlobalID), this._name, this._price, this._markup, 0, this._comment));
  }
}
