// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.Merch
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.IO;

namespace MasterBook4._0
{
  internal class Merch
  {
    public int GlobalID { get; private set; }

    public int LocalID { get; private set; }

    public int Price { get; private set; }

    public int Markup { get; private set; }

    public int Amount { get; private set; }

    public string Name { get; private set; }

    public string Comment { get; private set; }

    public Master Owner { get; private set; }

    public string CodeString => this.GlobalID.ToString() + ";" + this.LocalID.ToString() + ";" + this.Owner.GlobalID.ToString() + ";" + this.Name + ";" + this.Price.ToString() + ";" + this.Markup.ToString() + ";" + this.Amount.ToString() + ";" + this.Comment + ";";

    public string ListString => "ID:" + this.LocalID.ToString() + " " + this.Name + " (" + (this.Price - this.Markup).ToString() + "+" + this.Markup.ToString() + "=" + this.Price.ToString() + "р., " + this.Amount.ToString() + "шт., " + this.Owner.Name + ") " + this.Comment;

    public static Merch FromBase(StreamReader baseFile)
    {
      string[] strArray = baseFile.ReadLine().Split(';');
      return new Merch(Convert.ToInt32(strArray[0]), Convert.ToInt32(strArray[1]), Base.GetMasterByGlobalID(Convert.ToInt32(strArray[2])), strArray[3], Convert.ToInt32(strArray[4]), Convert.ToInt32(strArray[5]), Convert.ToInt32(strArray[6]), strArray[7]);
    }

    public static Merch FromOldBase(StreamReader baseFile, Master _owner)
    {
      string name = baseFile.ReadLine();
      string comment = baseFile.ReadLine();
      int int32_1 = Convert.ToInt32(baseFile.ReadLine());
      for (int index = 0; index < int32_1; ++index)
        baseFile.ReadLine();
      string[] strArray = baseFile.ReadLine().Split(' ');
      int int32_2 = Convert.ToInt32(strArray[0]);
      int int32_3 = Convert.ToInt32(strArray[1]);
      int int32_4 = Convert.ToInt32(strArray[2]);
      int int32_5 = Convert.ToInt32(strArray[3]);
      return new Merch(Base.NewGlobalMerchID, int32_2, _owner, name, int32_3, int32_4, int32_5, comment);
    }

    public Merch(
      int globalId,
      int localId,
      Master owner,
      string name,
      int price,
      int markup,
      int amount,
      string comment)
    {
      this.GlobalID = globalId;
      this.LocalID = localId;
      this.Owner = owner;
      this.Name = name;
      this.Price = price;
      this.Markup = markup;
      this.Amount = amount;
      this.Comment = comment;
    }

    public void Edit(string name, int price, int markup, string comment)
    {
      this.Name = name;
      this.Price = price;
      this.Markup = markup;
      this.Comment = comment;
    }

    public void Sell(int soldAmount)
    {
      this.Amount -= soldAmount;
      this.Owner.Debt += soldAmount * (this.Price - this.Markup);
    }

    public void ChangeAmount(int amountChanged) => this.Amount += amountChanged;
  }
}
