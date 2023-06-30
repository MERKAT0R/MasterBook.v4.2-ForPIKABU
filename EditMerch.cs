// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.EditMerch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class EditMerch : Operation
  {
    private int _globalID;
    private int _localID;
    private int _oldPrice;
    private int _newPrice;
    private int _oldMarkup;
    private int _newMarkup;
    private int _ownerGlobalID;
    private 
    #nullable disable
    string _oldName;
    private string _newName;
    private string _oldComment;
    private string _newComment;

    public EditMerch(int globalID, string name, int price, int markup, string comment)
    {
      Merch merchByGlobalId = Base.GetMerchByGlobalID(globalID);
      int num1 = globalID;
      string str1 = name;
      int num2 = price;
      int num3 = markup;
      string str2 = comment;
      this._globalID = num1;
      this._newName = str1;
      this._newPrice = num2;
      this._newMarkup = num3;
      this._newComment = str2;
      this._localID = merchByGlobalId.LocalID;
      this._ownerGlobalID = merchByGlobalId.Owner.GlobalID;
      this._oldName = merchByGlobalId.Name;
      this._oldComment = merchByGlobalId.Comment;
      this._oldPrice = merchByGlobalId.Price;
      this._oldMarkup = merchByGlobalId.Markup;
    }

    public EditMerch(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._localID = Convert.ToInt32(strArray[2]);
      this._ownerGlobalID = Convert.ToInt32(strArray[3]);
      this._newName = strArray[4];
      this._newPrice = Convert.ToInt32(strArray[5]);
      this._newMarkup = Convert.ToInt32(strArray[6]);
      this._newComment = strArray[7];
      this._oldName = strArray[8];
      this._oldPrice = Convert.ToInt32(strArray[9]);
      this._oldMarkup = Convert.ToInt32(strArray[10]);
      this._oldComment = strArray[11];
      this.ExecutionTime = strArray[12];
    }

    public override int? MasterGlobalID => new int?(this._ownerGlobalID);

    public override int? MerchGlobalID => new int?(this._globalID);

    public override string CodeString => 5.ToString() + ";" + this._globalID.ToString() + ";" + this._localID.ToString() + ";" + this._ownerGlobalID.ToString() + ";" + this._newName + ";" + this._newPrice.ToString() + ";" + this._newMarkup.ToString() + ";" + this._newComment + ";" + this._oldName + ";" + this._oldPrice.ToString() + ";" + this._oldMarkup.ToString() + ";" + this._oldComment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " ОТРЕДАКТИРОВАН ТОВАР  ID: " + this._localID.ToString() + " Мастер: " + Operation.MasterName(this._ownerGlobalID) + " " + this._oldName + Operation.Comment(this._oldComment) + " " + (this._oldPrice - this._oldMarkup).ToString() + "+" + this._oldMarkup.ToString() + "=" + this._oldPrice.ToString() + "р. => " + this._newName + Operation.Comment(this._newComment) + " " + (this._newPrice - this._newMarkup).ToString() + "+" + this._newMarkup.ToString() + "=" + this._newPrice.ToString() + "р.";

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        if (this._newName.Contains(";") || this._newComment.Contains(";"))
          return "Нельзя использовать точку с запятой!";
        return this._newPrice >= 0 && this._newMarkup >= 0 ? (string) null : "Цена и наценка не могут быть отрицательными!";
      }
    }

    public override string? ValidateCancel => Base.GetMerchByGlobalID(this._globalID) != null ? (string) null : "Этот товар удалён!";

    protected override void Execute() => Base.GetMerchByGlobalID(this._globalID).Edit(this._newName, this._newPrice, this._newMarkup, this._newComment);

    public override void Cancel() => Base.GetMerchByGlobalID(this._globalID).Edit(this._oldName, this._oldPrice, this._oldMarkup, this._oldComment);
  }
}
