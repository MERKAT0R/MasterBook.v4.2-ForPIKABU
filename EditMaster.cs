// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.EditMaster
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class EditMaster : Operation
  {
    private 
    #nullable disable
    string _oldName;
    private string _oldComment;
    private string _newName;
    private string _newComment;
    private int _globalID;

    public EditMaster(int globalID, string name, string comment)
    {
      this._globalID = globalID;
      Master masterByGlobalId = Base.GetMasterByGlobalID(this._globalID);
      this._oldName = masterByGlobalId.Name;
      this._oldComment = masterByGlobalId.Comment;
      this._newName = name;
      this._newComment = comment;
    }

    public EditMaster(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._oldName = strArray[2];
      this._oldComment = strArray[3];
      this._newName = strArray[4];
      this._newComment = strArray[5];
      this.ExecutionTime = strArray[6];
    }

    public override int? MasterGlobalID => new int?(this._globalID);

    public override int? MerchGlobalID => new int?();

    public override string CodeString => 1.ToString() + ";" + this._globalID.ToString() + ";" + this._oldName + ";" + this._oldComment + ";" + this._newName + ";" + this._newComment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " ОТРЕДАКТИРОВАН МАСТЕР " + this._oldName + Operation.Comment(this._oldComment) + " => " + this._newName + Operation.Comment(this._newComment);

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        Master masterByName = Base.GetMasterByName(this._newName);
        return this._newName.Contains(";") || this._newComment.Contains(";") ? "Нельзя использовать точку с запятой!" : (masterByName == null || masterByName.GlobalID == this._globalID ? (string) null : "Мастер с таким именем уже существует!");
      }
    }

    public override string? ValidateCancel
    {
      get
      {
        Master masterByName = Base.GetMasterByName(this._oldName);
        return masterByName == null || masterByName.GlobalID == this._globalID ? (string) null : "Мастер с таким именем уже существует!";
      }
    }

    protected override void Execute() => Base.GetMasterByGlobalID(this._globalID).Edit(this._newName, this._newComment);

    public override void Cancel() => Base.GetMasterByGlobalID(this._globalID).Edit(this._oldName, this._oldComment);
  }
}
