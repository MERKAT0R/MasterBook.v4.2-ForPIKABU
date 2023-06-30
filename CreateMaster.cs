// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.CreateMaster
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;


#nullable enable
namespace MasterBook4._0
{
  internal class CreateMaster : Operation
  {
    private 
    #nullable disable
    string _name;
    private string _comment;
    private int _globalID;

    public CreateMaster(string name, string comment)
    {
      this._name = name;
      this._comment = comment;
    }

    public CreateMaster(string codeString)
    {
      string[] strArray = codeString.Split(';');
      this._globalID = Convert.ToInt32(strArray[1]);
      this._name = strArray[2];
      this._comment = strArray[3];
      this.ExecutionTime = strArray[4];
    }

    public override int? MasterGlobalID => new int?(this._globalID);

    public override int? MerchGlobalID => new int?();

    public override string CodeString => 0.ToString() + ";" + this._globalID.ToString() + ";" + this._name + ";" + this._comment + ";" + this.ExecutionTime;

    public override string HistoryString => this.ExecutionTime + " СОЗДАН МАСТЕР " + this._name + Operation.Comment(this._comment);

    public override 
    #nullable enable
    string? Validate
    {
      get
      {
        if (this._name.Contains(";") || this._comment.Contains(";"))
          return "Нельзя использовать точку с запятой!";
        return Base.GetMasterByName(this._name) == null ? (string) null : "Мастер с таким именем уже существует!";
      }
    }

    public override 
    #nullable disable
    string ValidateCancel
    {
      get
      {
        Master masterByGlobalId = Base.GetMasterByGlobalID(this._globalID);
        return Base.FindMerchByMaster(masterByGlobalId).Count > 0 ? "Нельзя удалить мастера с неудалёнными товарами!" : (masterByGlobalId.Debt != 0 ? "Нельзя удалить мастера с невыплаченным долгом!" : (string) null);
      }
    }

    protected override void Execute()
    {
      this._globalID = Base.NewGlobalMasterID;
      Base.AddMaster(new Master(this._globalID, this._name, this._comment));
    }

    public override void Cancel() => Base.DeleteMaster(this._globalID);
  }
}
