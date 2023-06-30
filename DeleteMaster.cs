// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.DeleteMaster
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class DeleteMaster : Operation
  {
    private int _globalID;
    private 
    #nullable disable
    string _name;
    private string _comment;

    public DeleteMaster(int globalID)
    {
      this._globalID = globalID;
      Master masterByGlobalId = Base.GetMasterByGlobalID(this._globalID);
      this._name = masterByGlobalId.Name;
      this._comment = masterByGlobalId.Comment;
    }

    public DeleteMaster(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._name = strArray[2];
      this._comment = strArray[3];
      this.ExecutionTime = strArray[4];
    }

    public override int? MasterGlobalID => new int?(this._globalID);

    public override int? MerchGlobalID => new int?();

    public override string CodeString => 3.ToString() + ";" + this._globalID.ToString() + ";" + this._name + ";" + this._comment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " УДАЛЁН МАСТЕР " + this._name;

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        Master masterByGlobalId = Base.GetMasterByGlobalID(this._globalID);
        return Base.FindMerchByMaster(masterByGlobalId).Count > 0 ? "Нельзя удалить мастера с неудалёнными товарами!" : (masterByGlobalId.Debt != 0 ? "Нельзя удалить мастера с невыплаченным долгом!" : (string) null);
      }
    }

    public override string? ValidateCancel => Base.GetMasterByName(this._name) != null ? (string) null : "Мастер с таким именем уже существует!";

    protected override void Execute() => Base.DeleteMaster(this._globalID);

    public override void Cancel() => Base.AddMaster(new Master(this._globalID, this._name, this._comment));
  }
}
