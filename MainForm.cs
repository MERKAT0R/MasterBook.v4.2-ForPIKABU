// Decompiled with JetBrains decompiler
// Type: MasterBook4._0.MainForm
// Assembly: MasterBook4.0, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F88D8398-7BF9-481D-89E8-47D6AC30A6E2
// Assembly location: E:\soft\MasterBook.v4.2\MasterBook.v4.2.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MasterBook4._0
{
  public class MainForm : Form
  {
    private Master chosenMaster = (Master) null;
    private Merch chosenMerch = (Merch) null;
    private List<Merch> searchMerchResults = (List<Merch>) null;
    private List<Merch> chosenMasterMerchList = (List<Merch>) null;
    private List<Master> searchMasterResults = (List<Master>) null;
    private List<Master> searchMasterForNewMerchResults = (List<Master>) null;
    private List<Operation> chosenMerchOperations = (List<Operation>) null;
    private List<Operation> chosenMasterOperations = (List<Operation>) null;
    private Merch chosenMerchOfChosenMaster = (Merch) null;
    private Panel currentPanel = (Panel) null;
    private bool baseIsSaved = true;
    private const string BANK_ACCOUNT_NUMBER = "4081 7810 6551 7105 6241";
    private IContainer components = (IContainer) null;
    private Button button_Menu_Merch;
    private Button button_Menu_Master;
    private Button button_Menu_NewMerch;
    private Button button_Menu_NewMaster;
    private Panel panel_Menu;
    private Panel panel_Merch;
    private RadioButton radioButton_Merch_FindByData;
    private RadioButton radioButton_Merch_FindByID;
    private ListBox listBox_Merch_List;
    private Label label_Merch_Name;
    private TextBox textBox_Merch_Name;
    private TextBox textBox_Merch_Master;
    private Label label_Merch_Master;
    private Label label_Merch_ID;
    private TextBox textBox_Merch_ID;
    private Button button_Menu_Exit;
    private Button button_Menu_Load;
    private Button button_Menu_Save;
    private Label label_Merch_Title;
    private Panel panel_Merch_Chosen;
    private Label label_Merch_Chosen_History;
    private Button button_Merch_Chosen_Master;
    private Button button_Merch_Chosen_Edit;
    private Label label_Merch_Chosen_Comment;
    private Button button_Merch_Chosen_Delete;
    private Button button_Merch_Chosen_GiveBack;
    private Button button_Merch_Chosen_Add;
    private Button button_Merch_Chosen_Sell;
    private ListBox listBox_Merch_Chosen_History;
    private Label label_Merch_Chosen_Amount;
    private Label label_Merch_Chosen_Price;
    private Label label_Merch_Chosen_Master;
    private Label label_Merch_Chosen_Name;
    private Panel panel_Master;
    private Label label_Master_Title;
    private Panel panel_Master_Chosen;
    private Button button_Master_Chosen_ToChosenMerch;
    private Button button_Master_Chosen_Delete;
    private Button button_Master_Chosen_Edit;
    private ListBox listBox_Master_Chosen_Merch;
    private Label label_Master_Chosen_Merch;
    private ListBox listBox_Master_Chosen_History;
    private Label label_Master_Chosen_History;
    private Button button_Master_Chosen_Debt;
    private TextBox textBox_Master_Chosen_Debt;
    private Label label_Master_Chosen_Debt;
    private Label label_Master_Chosen_Comment;
    private Label label_Master_Chosen_Name;
    private ListBox listBox_Master_List;
    private Label label_Master_Name;
    private TextBox textBox_Master_Name;
    private Panel panel_NewMerch;
    private Label label_NewMerch_Title;
    private CheckBox checkBox_NewMerch_ToMerch;
    private Button button_NewMerch_Cancel;
    private Button button_NewMerch_Edit;
    private Button button_NewMerch_Add;
    private TextBox textBox_NewMerch_Comment;
    private Label label_NewMerch_Comment;
    private Label label1;
    private TextBox textBox_NewMerch_Markup;
    private Label label_NewMerch_Markup;
    private TextBox textBox_NewMerch_PriceBefore;
    private Label label_NewMerch_PriceBefore;
    private TextBox textBox_NewMerch_Name;
    private Label label_NewMerch_Name;
    private ListBox listBox_NewMerch_Master;
    private TextBox textBox_NewMerch_Master;
    private Label label_NewMerch_Master;
    private Panel panel_NewMaster;
    private Button button_NewMaster_Add;
    private TextBox textBox_NewMaster_Comment;
    private Label label_NewMaster_Comment;
    private TextBox textBox_NewMaster_Name;
    private Label label_NewMaster_Name;
    private Label label_NewMaster_Title;
    private Button button_NewMaster_Edit;
    private Button button_NewMaster_Cancel;
    private CheckBox checkBox_NewMaster_ToMaster;
    private Button button_Master_Chosen_NewMerch;
    private Button button_Merch_Clean;
    private Button button_Master_Chosen_Export;
    private Button button_Merch_Chosen_Export;
    private Label label_Menu_FullDebt;
    private Label label_Merch_Chosen_N;
    private TextBox textBox_Merch_Chosen_Number;
    private Button button_Master_Chosen_Cancel;
    private TextBox textBox_NewMerch_Amount;
    private Label label_NewMerch_Amount;
    private Button button_Merch_Chosen_Cancel;
    private Button button_Cancel;
    private Label label_Donations;

    private bool MenuIsEnabled
    {
      set
      {
        this.button_Menu_Merch.Enabled = value;
        this.button_Menu_Master.Enabled = value;
        this.button_Menu_NewMerch.Enabled = value;
        this.button_Menu_NewMaster.Enabled = value;
      }
    }

    public MainForm()
    {
      this.InitializeComponent();
      this.label_Donations.Text = "Автор программы: vk.com/kellendros95     Буду рад донатам на 4081 7810 6551 7105 6241 (Сбер)";
      this.panel_Merch.Location = new Point(198, 32);
      this.panel_Master.Location = new Point(198, 32);
      this.panel_NewMerch.Location = new Point(198, 32);
      this.panel_NewMaster.Location = new Point(198, 32);
      string str = "Base.base";
      if (!File.Exists(str))
      {
        int num = (int) MessageBox.Show("Файл с базой (" + str + ") не обнаружен", "Книга Мастеров", MessageBoxButtons.OK);
      }
      else
        Base.LoadBase(str);
      this.UpdateFullDebt();
      this.ToPanel(this.panel_Merch);
      this.ChangeCancelButtonText();
    }

    private void ToPanel(Panel p)
    {
      this.currentPanel = p;
      this.panel_Merch.Enabled = p == this.panel_Merch;
      this.panel_Merch.Visible = p == this.panel_Merch;
      this.button_Menu_Merch.FlatStyle = p == this.panel_Merch ? FlatStyle.Flat : FlatStyle.Standard;
      this.panel_Master.Enabled = p == this.panel_Master;
      this.panel_Master.Visible = p == this.panel_Master;
      this.button_Menu_Master.FlatStyle = p == this.panel_Master ? FlatStyle.Flat : FlatStyle.Standard;
      this.panel_NewMerch.Enabled = p == this.panel_NewMerch;
      this.panel_NewMerch.Visible = p == this.panel_NewMerch;
      this.button_Menu_NewMerch.FlatStyle = p == this.panel_NewMerch ? FlatStyle.Flat : FlatStyle.Standard;
      this.panel_NewMaster.Enabled = p == this.panel_NewMaster;
      this.panel_NewMaster.Visible = p == this.panel_NewMaster;
      this.button_Menu_NewMaster.FlatStyle = p == this.panel_NewMaster ? FlatStyle.Flat : FlatStyle.Standard;
    }

    private void UpdateFullDebt() => this.label_Menu_FullDebt.Text = "Сумма долга: " + Base.FullDebt.ToString() + "р.";

    private void button_Menu_Merch_Click(object sender, EventArgs e)
    {
      this.ToPanel(this.panel_Merch);
      if (this.chosenMerch == null)
        return;
      if (this.radioButton_Merch_FindByID.Checked)
      {
        this.textBox_Merch_ID.Text = this.chosenMerch.LocalID.ToString();
        this.SearchMerchByID();
      }
      else
      {
        this.textBox_Merch_Name.Text = this.chosenMerch.Name;
        this.textBox_Merch_Master.Text = this.chosenMerch.Owner.Name;
        this.SearchMerchByNameAndMasterName();
      }
    }

    private void button_Menu_Master_Click(object sender, EventArgs e)
    {
      this.ToPanel(this.panel_Master);
      this.textBox_Master_Name.Text = this.chosenMaster?.Name ?? "";
      this.SearchMaster();
      this.UpdateChosenMasterInfo();
    }

    private void button_Menu_NewMerch_Click(object sender, EventArgs e)
    {
      this.ToPanel(this.panel_NewMerch);
      this.ChooseNewMerchPanelMode(false, false);
    }

    private void button_Menu_NewMaster_Click(object sender, EventArgs e)
    {
      this.ToPanel(this.panel_NewMaster);
      this.ChooseNewMasterPanelMode(false);
    }

    private void button_Menu_Save_Click(object sender, EventArgs e)
    {
      Base.SaveBase("Base.base");
      int num = (int) MessageBox.Show("База сохранена", "Книга мастеров");
      this.baseIsSaved = true;
    }

    private void button_Menu_Load_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "Файлы base|*.base|Файлы txt|*.txt|Все файлы|*";
      if (openFileDialog.ShowDialog() != DialogResult.OK)
        return;
      if (!this.baseIsSaved && MessageBox.Show("База не сохранена! Сохранить базу перед выходом?", "Книга мастеров", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        Base.SaveBase("base.base");
        int num = (int) MessageBox.Show("База сохранена", "Книга мастеров");
      }
      Base.LoadBase(openFileDialog.FileName);
      this.chosenMerch = (Merch) null;
      this.chosenMaster = (Master) null;
      this.chosenMerchOfChosenMaster = (Merch) null;
      int num1 = (int) MessageBox.Show("База загружена", "Книга мастеров", MessageBoxButtons.OK);
      this.baseIsSaved = true;
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this.baseIsSaved)
        return;
      switch (MessageBox.Show("База не сохранена! Сохранить базу перед выходом?", "Книга мастеров", MessageBoxButtons.YesNoCancel))
      {
        case DialogResult.Cancel:
          e.Cancel = true;
          break;
        case DialogResult.Yes:
          Base.SaveBase("base.base");
          int num = (int) MessageBox.Show("База сохранена", "Книга мастеров");
          break;
      }
    }

    private void button_Menu_Exit_Click(object sender, EventArgs e) => this.Close();

    private void button_Cancel_Click(object sender, EventArgs e)
    {
      Operation lastOperation = Base.GetLastOperation();
      if (lastOperation == null || !Controller.Cancel(lastOperation))
        return;
      this.baseIsSaved = false;
      this.ChangeCancelButtonText();
      if (this.currentPanel == this.panel_Merch)
      {
        if (this.radioButton_Merch_FindByData.Checked)
        {
          this.SearchMerchByNameAndMasterName();
          if (this.listBox_Merch_List.SelectedIndex == -1)
          {
            if (Base.GetMerchByGlobalID(this.chosenMerch.GlobalID) == null)
            {
              this.chosenMerch = (Merch) null;
            }
            else
            {
              this.textBox_Merch_Name.Text = this.chosenMerch.Name;
              this.SearchMerchByNameAndMasterName();
            }
          }
        }
        else if (Base.GetMerchByGlobalID(this.chosenMerch.GlobalID) == null)
          this.chosenMerch = (Merch) null;
        this.UpdateChosenMerchInfo();
      }
      else if (this.currentPanel == this.panel_Master)
      {
        this.SearchMaster();
        if (this.listBox_Master_List.SelectedIndex == -1)
        {
          if (Base.GetMasterByGlobalID(this.chosenMaster.GlobalID) == null)
          {
            this.chosenMaster = (Master) null;
          }
          else
          {
            this.textBox_Master_Name.Text = this.chosenMaster.Name;
            this.SearchMaster();
          }
        }
        this.UpdateChosenMasterInfo();
      }
      else if (this.currentPanel == this.panel_NewMerch)
        this.SearchMasterForNewMerch((Master) null);
    }

    private void ChangeCancelButtonText() => this.button_Cancel.Text = "ОТМЕНИТЬ\n\n" + Base.GetLastOperation()?.HistoryString;

    private void textBox_Master_Chosen_Debt_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || e.KeyChar == '-';

    private void textBox_NewMerch_PriceBefore_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || e.KeyChar == '-';

    private void textBox_NewMerch_Markup_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || e.KeyChar == '-';

    private void textBox_Merch_ID_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || e.KeyChar == '-';

    private void textBox_Merch_Chosen_Number_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != '\b' || e.KeyChar == '-';

    private void SearchMerchByNameAndMasterName()
    {
      this.searchMerchResults = Base.FindMerchByNameAndMasterName(this.textBox_Merch_Name.Text, this.textBox_Merch_Master.Text);
      this.listBox_Merch_List.Items.Clear();
      foreach (Merch searchMerchResult in this.searchMerchResults)
        this.listBox_Merch_List.Items.Add((object) searchMerchResult.ListString);
      if (!this.searchMerchResults.Contains(this.chosenMerch))
        this.chosenMerch = (Merch) null;
      this.listBox_Merch_List.SelectedIndex = this.chosenMerch == null ? -1 : this.searchMerchResults.IndexOf(this.chosenMerch);
      this.UpdateChosenMerchInfo();
    }

    private void SearchMerchByID()
    {
      this.chosenMerch = this.textBox_Merch_ID.Text != "" ? Base.GetMerchByLocalID(Convert.ToInt32(this.textBox_Merch_ID.Text)) : (Merch) null;
      this.UpdateChosenMerchInfo();
    }

    private void radioButton_Merch_FindByData_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton_Merch_FindByData.Checked)
        return;
      this.textBox_Merch_ID.Enabled = false;
      this.textBox_Merch_Name.Enabled = true;
      this.textBox_Merch_Master.Enabled = true;
      this.listBox_Merch_List.Enabled = true;
      this.SearchMerchByNameAndMasterName();
    }

    private void radioButton_Merch_FindByID_CheckedChanged(object sender, EventArgs e)
    {
      if (!this.radioButton_Merch_FindByID.Checked)
        return;
      this.textBox_Merch_ID.Enabled = true;
      this.textBox_Merch_Name.Enabled = false;
      this.textBox_Merch_Master.Enabled = false;
      this.listBox_Merch_List.Enabled = false;
      this.SearchMerchByID();
    }

    private void textBox_Merch_ID_TextChanged(object sender, EventArgs e) => this.SearchMerchByID();

    private void listBox_Merch_List_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.chosenMerch = this.searchMerchResults[this.listBox_Merch_List.SelectedIndex];
      this.UpdateChosenMerchInfo();
    }

    private void textBox_Merch_Name_TextChanged(object sender, EventArgs e) => this.SearchMerchByNameAndMasterName();

    private void textBox_Merch_Master_TextChanged(object sender, EventArgs e) => this.SearchMerchByNameAndMasterName();

    private void button_Merch_Clean_Click(object sender, EventArgs e)
    {
      this.textBox_Merch_ID.Text = "";
      this.textBox_Merch_Master.Text = "";
      this.textBox_Merch_Name.Text = "";
      if (this.radioButton_Merch_FindByData.Checked)
        this.SearchMerchByNameAndMasterName();
      else
        this.SearchMerchByID();
    }

    private void UpdateChosenMerchInfo()
    {
      this.label_Merch_Chosen_Name.Text = this.chosenMerch?.Name ?? "Название";
      this.label_Merch_Chosen_Comment.Text = this.chosenMerch?.Comment ?? "";
      Label merchChosenPrice = this.label_Merch_Chosen_Price;
      int num;
      string str1;
      if (this.chosenMerch == null)
      {
        str1 = "Цена";
      }
      else
      {
        string[] strArray = new string[6]
        {
          (this.chosenMerch.Price - this.chosenMerch.Markup).ToString(),
          " + ",
          this.chosenMerch.Markup.ToString(),
          " = ",
          null,
          null
        };
        num = this.chosenMerch.Price;
        strArray[4] = num.ToString();
        strArray[5] = " р.";
        str1 = string.Concat(strArray);
      }
      merchChosenPrice.Text = str1;
      Label merchChosenAmount = this.label_Merch_Chosen_Amount;
      string str2;
      if (this.chosenMerch == null)
      {
        str2 = "Количество";
      }
      else
      {
        num = this.chosenMerch.Amount;
        str2 = num.ToString() + " шт.";
      }
      merchChosenAmount.Text = str2;
      this.label_Merch_Chosen_Master.Text = this.chosenMerch?.Owner.Name ?? "Мастер";
      this.listBox_Merch_Chosen_History.Items.Clear();
      if (this.chosenMerch == null)
        return;
      this.chosenMerchOperations = Base.GetMerchHistory(this.chosenMerch);
      this.chosenMerchOperations.Reverse();
      foreach (Operation chosenMerchOperation in this.chosenMerchOperations)
        this.listBox_Merch_Chosen_History.Items.Add((object) chosenMerchOperation.HistoryString);
    }

    private void SimpleMerchOperation(OperationEnum t)
    {
      if (this.chosenMerch == null)
      {
        int num1 = (int) MessageBox.Show("Товар не выбран!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        int num2 = this.textBox_Merch_Chosen_Number.Text != "" ? Convert.ToInt32(this.textBox_Merch_Chosen_Number.Text) : 0;
        if (true)
          ;
        Operation o;
        switch (t)
        {
          case OperationEnum.SellMerch:
            o = (Operation) new SellMerch(this.chosenMerch.GlobalID, num2);
            break;
          case OperationEnum.GiveBackMerch:
            o = (Operation) new GiveBackMerch(this.chosenMerch.GlobalID, num2);
            break;
          case OperationEnum.AddMerch:
            o = (Operation) new AddMerch(this.chosenMerch.GlobalID, num2);
            break;
          default:
            o = (Operation) null;
            break;
        }
        if (true)
          ;
        if (Controller.Execute(o))
        {
          this.UpdateChosenMerchInfo();
          this.baseIsSaved = false;
          this.ChangeCancelButtonText();
          this.textBox_Merch_Chosen_Number.Text = "1";
        }
      }
    }

    private void button_Merch_Chosen_Sell_Click(object sender, EventArgs e)
    {
      this.SimpleMerchOperation(OperationEnum.SellMerch);
      this.UpdateFullDebt();
    }

    private void button_Merch_Chosen_Add_Click(object sender, EventArgs e) => this.SimpleMerchOperation(OperationEnum.AddMerch);

    private void button_Merch_Chosen_GiveBack_Click(object sender, EventArgs e) => this.SimpleMerchOperation(OperationEnum.GiveBackMerch);

    private void button_Merch_Chosen_Delete_Click(object sender, EventArgs e)
    {
      if (this.chosenMerch == null)
      {
        int num = (int) MessageBox.Show("Товар не выбран!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else if (MessageBox.Show("Вы уверены, что хотите удалить товар " + this.chosenMerch.Name + "?", "Книга мастеров", MessageBoxButtons.YesNoCancel) == DialogResult.Yes && Controller.Execute((Operation) new DeleteMerch(this.chosenMerch.GlobalID)))
      {
        this.baseIsSaved = false;
        this.ChangeCancelButtonText();
        this.chosenMerch = (Merch) null;
        if (this.radioButton_Merch_FindByID.Checked)
          this.SearchMerchByID();
        else
          this.SearchMerchByNameAndMasterName();
        this.textBox_Merch_Chosen_Number.Text = "1";
      }
    }

    private void button_Merch_Chosen_Edit_Click(object sender, EventArgs e)
    {
      if (this.chosenMerch == null)
      {
        int num = (int) MessageBox.Show("Товар не выбран!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        this.ToPanel(this.panel_NewMerch);
        this.ChooseNewMerchPanelMode(true, false);
      }
    }

    private void button_Merch_Chosen_Master_Click(object sender, EventArgs e)
    {
      if (this.chosenMerch == null)
      {
        int num = (int) MessageBox.Show("Товар не выбран!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        this.chosenMaster = this.chosenMerch.Owner;
        this.ToPanel(this.panel_Master);
        this.textBox_Master_Name.Text = this.chosenMaster.Name;
        this.SearchMaster();
      }
    }

    private void button_Merch_Chosen_Cancel_Click(object sender, EventArgs e)
    {
      if (this.chosenMerch == null || this.listBox_Merch_Chosen_History.SelectedIndex == -1 || !Controller.Cancel(this.chosenMerchOperations[this.listBox_Merch_Chosen_History.SelectedIndex]))
        return;
      this.baseIsSaved = false;
      this.ChangeCancelButtonText();
      if (this.radioButton_Merch_FindByData.Checked)
      {
        this.SearchMerchByNameAndMasterName();
        if (this.listBox_Merch_List.SelectedIndex == -1)
        {
          if (Base.GetMerchByGlobalID(this.chosenMerch.GlobalID) == null)
          {
            this.chosenMerch = (Merch) null;
          }
          else
          {
            this.textBox_Merch_Name.Text = this.chosenMerch.Name;
            this.SearchMerchByNameAndMasterName();
          }
        }
      }
      else if (Base.GetMerchByGlobalID(this.chosenMerch.GlobalID) == null)
        this.chosenMerch = (Merch) null;
      this.UpdateChosenMerchInfo();
    }

    private void button_Merch_Chosen_Export_Click(object sender, EventArgs e)
    {
      if (this.chosenMerch == null)
        return;
      Base.ExportOperationList(Base.GetMerchHistory(this.chosenMerch));
      int num = (int) MessageBox.Show("История экспортирована в файл history.txt", "Книга мастеров", MessageBoxButtons.OK);
    }

    private void SearchMaster()
    {
      this.searchMasterResults = Base.FindMasterByName(this.textBox_Master_Name.Text);
      this.listBox_Master_List.Items.Clear();
      foreach (Master searchMasterResult in this.searchMasterResults)
        this.listBox_Master_List.Items.Add((object) searchMasterResult.ListString);
      this.listBox_Master_List.SelectedIndex = this.chosenMaster == null ? -1 : this.searchMasterResults.IndexOf(this.chosenMaster);
    }

    private void textBox_Master_Name_TextChanged(object sender, EventArgs e) => this.SearchMaster();

    private void listBox_Master_List_SelectedIndexChanged(object sender, EventArgs e)
    {
      this.chosenMaster = this.searchMasterResults[this.listBox_Master_List.SelectedIndex];
      this.UpdateChosenMasterInfo();
    }

    private void UpdateChosenMasterInfo()
    {
      this.label_Master_Chosen_Name.Text = this.chosenMaster?.Name ?? "Имя";
      this.label_Master_Chosen_Comment.Text = this.chosenMaster?.Comment ?? "Комментарий";
      this.label_Master_Chosen_Debt.Text = "Долг: " + this.chosenMaster?.Debt.ToString();
      this.listBox_Master_Chosen_History.Items.Clear();
      this.listBox_Master_Chosen_Merch.Items.Clear();
      if (this.chosenMaster == null)
        return;
      this.chosenMasterOperations = Base.GetMasterHistory(this.chosenMaster);
      this.chosenMasterOperations.Reverse();
      foreach (Operation chosenMasterOperation in this.chosenMasterOperations)
        this.listBox_Master_Chosen_History.Items.Add((object) chosenMasterOperation.HistoryString);
      this.chosenMasterMerchList = Base.FindMerchByMaster(this.chosenMaster);
      foreach (Merch chosenMasterMerch in this.chosenMasterMerchList)
        this.listBox_Master_Chosen_Merch.Items.Add((object) chosenMasterMerch.ListString);
      int num = this.chosenMasterMerchList.IndexOf(this.chosenMerchOfChosenMaster);
      this.listBox_Master_Chosen_Merch.SelectedIndex = num;
      if (num == -1)
        this.chosenMerchOfChosenMaster = (Merch) null;
    }

    private void button_Master_Chosen_Debt_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null)
      {
        int num = (int) MessageBox.Show("Выберите мастера!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else if (Controller.Execute((Operation) new PayDebt(this.chosenMaster.GlobalID, this.textBox_Master_Chosen_Debt.Text != "" ? Convert.ToInt32(this.textBox_Master_Chosen_Debt.Text) : 0)))
      {
        this.baseIsSaved = false;
        this.ChangeCancelButtonText();
        this.textBox_Master_Chosen_Debt.Text = "";
        this.UpdateChosenMasterInfo();
        this.UpdateFullDebt();
      }
    }

    private void button_Master_Chosen_Edit_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null)
      {
        int num = (int) MessageBox.Show("Выберите мастера!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        this.ToPanel(this.panel_NewMaster);
        this.ChooseNewMasterPanelMode(true);
      }
    }

    private void button_Master_Chosen_Delete_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null)
      {
        int num = (int) MessageBox.Show("Выберите мастера!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else if (MessageBox.Show("Вы уверены, что хотите удалить мастера " + this.chosenMaster.Name + "?", "Книга мастеров", MessageBoxButtons.YesNoCancel) == DialogResult.Yes && Controller.Execute((Operation) new DeleteMaster(this.chosenMaster.GlobalID)))
      {
        this.baseIsSaved = false;
        this.ChangeCancelButtonText();
        this.chosenMaster = (Master) null;
        this.SearchMaster();
      }
    }

    private void listBox_Master_Chosen_Merch_SelectedIndexChanged(object sender, EventArgs e) => this.chosenMerchOfChosenMaster = this.listBox_Master_Chosen_Merch.SelectedIndex == -1 ? (Merch) null : this.chosenMasterMerchList[this.listBox_Master_Chosen_Merch.SelectedIndex];

    private void button_Master_Chosen_ToChosenMerch_Click(object sender, EventArgs e)
    {
      if (this.chosenMerchOfChosenMaster == null)
      {
        int num = (int) MessageBox.Show("Товар не выбран!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        this.chosenMerch = this.chosenMerchOfChosenMaster;
        this.button_Menu_Merch_Click((object) null, (EventArgs) null);
      }
    }

    private void button_Master_Chosen_NewMerch_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null)
      {
        int num = (int) MessageBox.Show("Выберите мастера!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        this.ToPanel(this.panel_NewMerch);
        this.ChooseNewMerchPanelMode(false, true);
      }
    }

    private void button_Master_Chosen_Cancel_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null || this.listBox_Master_Chosen_History.SelectedIndex == -1 || !Controller.Cancel(this.chosenMasterOperations[this.listBox_Master_Chosen_History.SelectedIndex]))
        return;
      this.baseIsSaved = false;
      this.ChangeCancelButtonText();
      this.SearchMaster();
      if (this.listBox_Master_List.SelectedIndex == -1)
      {
        if (Base.GetMasterByGlobalID(this.chosenMaster.GlobalID) == null)
        {
          this.chosenMaster = (Master) null;
        }
        else
        {
          this.textBox_Master_Name.Text = this.chosenMaster.Name;
          this.SearchMaster();
        }
      }
      this.UpdateChosenMasterInfo();
    }

    private void button_Master_Chosen_Export_Click(object sender, EventArgs e)
    {
      if (this.chosenMaster == null)
        return;
      Base.ExportOperationList(Base.GetMasterHistory(this.chosenMaster));
      int num = (int) MessageBox.Show("История экспортирована в файл history.txt", "Книга мастеров", MessageBoxButtons.OK);
    }

    private void ChooseNewMerchPanelMode(bool editMode, bool forChosenMaster)
    {
      this.MenuIsEnabled = !editMode;
      this.button_NewMerch_Add.Enabled = !editMode;
      this.button_NewMerch_Add.Visible = !editMode;
      this.label_NewMerch_Amount.Enabled = !editMode;
      this.label_NewMerch_Amount.Visible = !editMode;
      this.textBox_NewMerch_Amount.Enabled = !editMode;
      this.textBox_NewMerch_Amount.Visible = !editMode;
      this.button_NewMerch_Edit.Enabled = editMode;
      this.button_NewMerch_Edit.Visible = editMode;
      this.button_NewMerch_Cancel.Enabled = editMode;
      this.button_NewMerch_Cancel.Visible = editMode;
      this.textBox_NewMerch_Name.Text = editMode ? this.chosenMerch.Name : "";
      this.textBox_NewMerch_Comment.Text = editMode ? this.chosenMerch.Comment : "";
      TextBox merchPriceBefore = this.textBox_NewMerch_PriceBefore;
      int num;
      string str1;
      if (!editMode)
      {
        str1 = "";
      }
      else
      {
        num = this.chosenMerch.Price - this.chosenMerch.Markup;
        str1 = num.ToString();
      }
      merchPriceBefore.Text = str1;
      TextBox boxNewMerchMarkup = this.textBox_NewMerch_Markup;
      string str2;
      if (!editMode)
      {
        str2 = "";
      }
      else
      {
        num = this.chosenMerch.Markup;
        str2 = num.ToString();
      }
      boxNewMerchMarkup.Text = str2;
      this.textBox_NewMerch_Amount.Text = "";
      this.textBox_NewMerch_Master.Text = editMode ? this.chosenMerch.Owner.Name : (forChosenMaster ? this.chosenMaster.Name : "");
      this.textBox_NewMerch_Master.Enabled = !editMode;
      this.listBox_NewMerch_Master.Enabled = !editMode;
      this.checkBox_NewMerch_ToMerch.Enabled = !editMode;
      this.checkBox_NewMerch_ToMerch.Visible = !editMode;
      if (editMode)
        return;
      this.SearchMasterForNewMerch(forChosenMaster ? this.chosenMaster : (Master) null);
    }

    private void SearchMasterForNewMerch(Master defaultFind)
    {
      this.searchMasterForNewMerchResults = Base.FindMasterByName(this.textBox_NewMerch_Master.Text);
      this.listBox_NewMerch_Master.Items.Clear();
      foreach (Master forNewMerchResult in this.searchMasterForNewMerchResults)
        this.listBox_NewMerch_Master.Items.Add((object) forNewMerchResult.ListString);
      if (defaultFind == null)
        return;
      this.listBox_NewMerch_Master.SelectedIndex = this.searchMasterForNewMerchResults.IndexOf(defaultFind);
    }

    private void textBox_NewMerch_Master_TextChanged(object sender, EventArgs e) => this.SearchMasterForNewMerch((Master) null);

    private void button_NewMerch_Add_Click(object sender, EventArgs e)
    {
      if (this.textBox_NewMerch_Name.Text == "" || this.textBox_NewMerch_PriceBefore.Text == "" || this.textBox_NewMerch_Markup.Text == "" || this.textBox_NewMerch_Amount.Text == "" || this.listBox_NewMerch_Master.SelectedIndex == -1)
      {
        int num1 = (int) MessageBox.Show("Не все необходимые поля заполнены!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        int globalId = this.searchMasterForNewMerchResults[this.listBox_NewMerch_Master.SelectedIndex].GlobalID;
        int int32_1 = Convert.ToInt32(this.textBox_NewMerch_PriceBefore.Text);
        int int32_2 = Convert.ToInt32(this.textBox_NewMerch_Markup.Text);
        int int32_3 = Convert.ToInt32(this.textBox_NewMerch_Amount.Text);
        CreateMerch createMerch = new CreateMerch(globalId, this.textBox_NewMerch_Name.Text, int32_1 + int32_2, int32_2, int32_3, this.textBox_NewMerch_Comment.Text);
        bool flag = Controller.Execute((Operation) createMerch);
        if (flag)
        {
          this.baseIsSaved = false;
          this.ChangeCancelButtonText();
          int num2 = (int) MessageBox.Show("Товар получил ID:" + createMerch.MerchLocalID.ToString(), "Книга мастеров", MessageBoxButtons.OK);
        }
        if (flag && this.checkBox_NewMerch_ToMerch.Checked)
        {
          this.chosenMerch = Base.GetMerchByGlobalID(createMerch.MerchGlobalID.Value);
          this.button_Menu_Merch_Click((object) null, (EventArgs) null);
        }
      }
    }

    private void button_NewMerch_Cancel_Click(object sender, EventArgs e)
    {
      this.MenuIsEnabled = true;
      this.ToPanel(this.panel_Merch);
    }

    private void button_NewMerch_Edit_Click(object sender, EventArgs e)
    {
      if (this.textBox_NewMerch_Name.Text == "" || this.textBox_NewMerch_PriceBefore.Text == "" || this.textBox_NewMerch_Markup.Text == "")
      {
        int num = (int) MessageBox.Show("Не все необходимые поля заполнены!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else
      {
        int int32_1 = Convert.ToInt32(this.textBox_NewMerch_PriceBefore.Text);
        int int32_2 = Convert.ToInt32(this.textBox_NewMerch_Markup.Text);
        if (Controller.Execute((Operation) new EditMerch(this.chosenMerch.GlobalID, this.textBox_NewMerch_Name.Text, int32_1 + int32_2, int32_2, this.textBox_NewMerch_Comment.Text)))
        {
          this.baseIsSaved = false;
          this.ChangeCancelButtonText();
          this.MenuIsEnabled = true;
          this.button_Menu_Merch_Click((object) null, (EventArgs) null);
        }
      }
    }

    private void ChooseNewMasterPanelMode(bool editMode)
    {
      this.MenuIsEnabled = !editMode;
      this.button_NewMaster_Add.Enabled = !editMode;
      this.button_NewMaster_Add.Visible = !editMode;
      this.button_NewMaster_Edit.Enabled = editMode;
      this.button_NewMaster_Edit.Visible = editMode;
      this.button_NewMaster_Cancel.Enabled = editMode;
      this.button_NewMaster_Cancel.Visible = editMode;
      this.checkBox_NewMaster_ToMaster.Enabled = !editMode;
      this.checkBox_NewMaster_ToMaster.Visible = !editMode;
      this.textBox_NewMaster_Name.Text = editMode ? this.chosenMaster.Name : "";
      this.textBox_NewMaster_Comment.Text = editMode ? this.chosenMaster.Comment : "";
      this.label_NewMaster_Title.Text = editMode ? "Редактировать мастера" : "Добавить нового мастера";
    }

    private void button_NewMaster_Add_Click(object sender, EventArgs e)
    {
      if (this.textBox_NewMaster_Name.Text == "")
      {
        int num = (int) MessageBox.Show("У мастера должно быть имя!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else if (Controller.Execute((Operation) new CreateMaster(this.textBox_NewMaster_Name.Text, this.textBox_NewMaster_Comment.Text)))
      {
        this.baseIsSaved = false;
        this.ChangeCancelButtonText();
        if (this.checkBox_NewMaster_ToMaster.Checked)
        {
          this.chosenMaster = Base.GetMasterByName(this.textBox_NewMaster_Name.Text);
          this.button_Menu_Master_Click((object) null, (EventArgs) null);
        }
      }
    }

    private void button_NewMaster_Edit_Click(object sender, EventArgs e)
    {
      if (this.textBox_NewMaster_Name.Text == "")
      {
        int num = (int) MessageBox.Show("У мастера должно быть имя!", "Книга мастеров", MessageBoxButtons.OK);
      }
      else if (Controller.Execute((Operation) new EditMaster(this.chosenMaster.GlobalID, this.textBox_NewMaster_Name.Text, this.textBox_NewMaster_Comment.Text)))
      {
        this.baseIsSaved = false;
        this.ChangeCancelButtonText();
        this.MenuIsEnabled = true;
        this.button_Menu_Master_Click((object) null, (EventArgs) null);
      }
    }

    private void button_NewMaster_Cancel_Click(object sender, EventArgs e)
    {
      this.MenuIsEnabled = true;
      this.ToPanel(this.panel_Master);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.button_Menu_Merch = new Button();
      this.button_Menu_Master = new Button();
      this.button_Menu_NewMerch = new Button();
      this.button_Menu_NewMaster = new Button();
      this.panel_Menu = new Panel();
      this.button_Cancel = new Button();
      this.label_Menu_FullDebt = new Label();
      this.button_Menu_Exit = new Button();
      this.button_Menu_Load = new Button();
      this.button_Menu_Save = new Button();
      this.panel_Merch = new Panel();
      this.button_Merch_Clean = new Button();
      this.listBox_Merch_List = new ListBox();
      this.label_Merch_ID = new Label();
      this.label_Merch_Title = new Label();
      this.panel_Merch_Chosen = new Panel();
      this.button_Merch_Chosen_Cancel = new Button();
      this.textBox_Merch_Chosen_Number = new TextBox();
      this.label_Merch_Chosen_N = new Label();
      this.button_Merch_Chosen_Export = new Button();
      this.label_Merch_Chosen_History = new Label();
      this.button_Merch_Chosen_Master = new Button();
      this.button_Merch_Chosen_Edit = new Button();
      this.label_Merch_Chosen_Comment = new Label();
      this.button_Merch_Chosen_Delete = new Button();
      this.button_Merch_Chosen_GiveBack = new Button();
      this.button_Merch_Chosen_Add = new Button();
      this.button_Merch_Chosen_Sell = new Button();
      this.listBox_Merch_Chosen_History = new ListBox();
      this.label_Merch_Chosen_Amount = new Label();
      this.label_Merch_Chosen_Price = new Label();
      this.label_Merch_Chosen_Master = new Label();
      this.label_Merch_Chosen_Name = new Label();
      this.textBox_Merch_ID = new TextBox();
      this.label_Merch_Name = new Label();
      this.textBox_Merch_Name = new TextBox();
      this.radioButton_Merch_FindByData = new RadioButton();
      this.radioButton_Merch_FindByID = new RadioButton();
      this.label_Merch_Master = new Label();
      this.textBox_Merch_Master = new TextBox();
      this.panel_Master = new Panel();
      this.label_Master_Title = new Label();
      this.panel_Master_Chosen = new Panel();
      this.button_Master_Chosen_Cancel = new Button();
      this.button_Master_Chosen_Export = new Button();
      this.button_Master_Chosen_NewMerch = new Button();
      this.button_Master_Chosen_ToChosenMerch = new Button();
      this.button_Master_Chosen_Delete = new Button();
      this.button_Master_Chosen_Edit = new Button();
      this.listBox_Master_Chosen_Merch = new ListBox();
      this.label_Master_Chosen_Merch = new Label();
      this.listBox_Master_Chosen_History = new ListBox();
      this.label_Master_Chosen_History = new Label();
      this.button_Master_Chosen_Debt = new Button();
      this.textBox_Master_Chosen_Debt = new TextBox();
      this.label_Master_Chosen_Debt = new Label();
      this.label_Master_Chosen_Comment = new Label();
      this.label_Master_Chosen_Name = new Label();
      this.listBox_Master_List = new ListBox();
      this.label_Master_Name = new Label();
      this.textBox_Master_Name = new TextBox();
      this.panel_NewMerch = new Panel();
      this.textBox_NewMerch_Amount = new TextBox();
      this.label_NewMerch_Amount = new Label();
      this.label_NewMerch_Title = new Label();
      this.checkBox_NewMerch_ToMerch = new CheckBox();
      this.button_NewMerch_Cancel = new Button();
      this.button_NewMerch_Edit = new Button();
      this.button_NewMerch_Add = new Button();
      this.textBox_NewMerch_Comment = new TextBox();
      this.label_NewMerch_Comment = new Label();
      this.label1 = new Label();
      this.textBox_NewMerch_Markup = new TextBox();
      this.label_NewMerch_Markup = new Label();
      this.textBox_NewMerch_PriceBefore = new TextBox();
      this.label_NewMerch_PriceBefore = new Label();
      this.textBox_NewMerch_Name = new TextBox();
      this.label_NewMerch_Name = new Label();
      this.listBox_NewMerch_Master = new ListBox();
      this.textBox_NewMerch_Master = new TextBox();
      this.label_NewMerch_Master = new Label();
      this.panel_NewMaster = new Panel();
      this.checkBox_NewMaster_ToMaster = new CheckBox();
      this.button_NewMaster_Cancel = new Button();
      this.button_NewMaster_Edit = new Button();
      this.button_NewMaster_Add = new Button();
      this.textBox_NewMaster_Comment = new TextBox();
      this.label_NewMaster_Comment = new Label();
      this.textBox_NewMaster_Name = new TextBox();
      this.label_NewMaster_Name = new Label();
      this.label_NewMaster_Title = new Label();
      this.label_Donations = new Label();
      this.panel_Menu.SuspendLayout();
      this.panel_Merch.SuspendLayout();
      this.panel_Merch_Chosen.SuspendLayout();
      this.panel_Master.SuspendLayout();
      this.panel_Master_Chosen.SuspendLayout();
      this.panel_NewMerch.SuspendLayout();
      this.panel_NewMaster.SuspendLayout();
      this.SuspendLayout();
      this.button_Menu_Merch.Location = new Point(3, 3);
      this.button_Menu_Merch.Name = "button_Menu_Merch";
      this.button_Menu_Merch.Size = new Size(174, 23);
      this.button_Menu_Merch.TabIndex = 0;
      this.button_Menu_Merch.Text = "Операции с товарами";
      this.button_Menu_Merch.UseVisualStyleBackColor = true;
      this.button_Menu_Merch.Click += new EventHandler(this.button_Menu_Merch_Click);
      this.button_Menu_Master.Location = new Point(3, 33);
      this.button_Menu_Master.Name = "button_Menu_Master";
      this.button_Menu_Master.Size = new Size(174, 23);
      this.button_Menu_Master.TabIndex = 1;
      this.button_Menu_Master.Text = "Операции с мастерами";
      this.button_Menu_Master.UseVisualStyleBackColor = true;
      this.button_Menu_Master.Click += new EventHandler(this.button_Menu_Master_Click);
      this.button_Menu_NewMerch.Location = new Point(3, 63);
      this.button_Menu_NewMerch.Name = "button_Menu_NewMerch";
      this.button_Menu_NewMerch.Size = new Size(174, 23);
      this.button_Menu_NewMerch.TabIndex = 2;
      this.button_Menu_NewMerch.Text = "Добавить новый товар";
      this.button_Menu_NewMerch.UseVisualStyleBackColor = true;
      this.button_Menu_NewMerch.Click += new EventHandler(this.button_Menu_NewMerch_Click);
      this.button_Menu_NewMaster.Location = new Point(3, 93);
      this.button_Menu_NewMaster.Name = "button_Menu_NewMaster";
      this.button_Menu_NewMaster.Size = new Size(174, 23);
      this.button_Menu_NewMaster.TabIndex = 3;
      this.button_Menu_NewMaster.Text = "Добавить нового мастера";
      this.button_Menu_NewMaster.UseVisualStyleBackColor = true;
      this.button_Menu_NewMaster.Click += new EventHandler(this.button_Menu_NewMaster_Click);
      this.panel_Menu.Controls.Add((Control) this.button_Cancel);
      this.panel_Menu.Controls.Add((Control) this.label_Menu_FullDebt);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_Exit);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_Load);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_Save);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_Merch);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_NewMaster);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_Master);
      this.panel_Menu.Controls.Add((Control) this.button_Menu_NewMerch);
      this.panel_Menu.Location = new Point(12, 12);
      this.panel_Menu.Name = "panel_Menu";
      this.panel_Menu.Size = new Size(180, 500);
      this.panel_Menu.TabIndex = 4;
      this.button_Cancel.Location = new Point(4, 357);
      this.button_Cancel.Name = "button_Cancel";
      this.button_Cancel.Size = new Size(170, 140);
      this.button_Cancel.TabIndex = 10;
      this.button_Cancel.Text = "ОТМЕНИТЬ";
      this.button_Cancel.UseVisualStyleBackColor = true;
      this.button_Cancel.Click += new EventHandler(this.button_Cancel_Click);
      this.label_Menu_FullDebt.AutoSize = true;
      this.label_Menu_FullDebt.Location = new Point(4, 251);
      this.label_Menu_FullDebt.Name = "label_Menu_FullDebt";
      this.label_Menu_FullDebt.Size = new Size(76, 13);
      this.label_Menu_FullDebt.TabIndex = 9;
      this.label_Menu_FullDebt.Text = "Сумма долга:";
      this.button_Menu_Exit.Location = new Point(4, 221);
      this.button_Menu_Exit.Name = "button_Menu_Exit";
      this.button_Menu_Exit.Size = new Size(173, 23);
      this.button_Menu_Exit.TabIndex = 8;
      this.button_Menu_Exit.Text = "Выйти";
      this.button_Menu_Exit.UseVisualStyleBackColor = true;
      this.button_Menu_Exit.Click += new EventHandler(this.button_Menu_Exit_Click);
      this.button_Menu_Load.Location = new Point(4, 191);
      this.button_Menu_Load.Name = "button_Menu_Load";
      this.button_Menu_Load.Size = new Size(173, 23);
      this.button_Menu_Load.TabIndex = 7;
      this.button_Menu_Load.Text = "Загрузить базу";
      this.button_Menu_Load.UseVisualStyleBackColor = true;
      this.button_Menu_Load.Click += new EventHandler(this.button_Menu_Load_Click);
      this.button_Menu_Save.Location = new Point(3, 161);
      this.button_Menu_Save.Name = "button_Menu_Save";
      this.button_Menu_Save.Size = new Size(174, 23);
      this.button_Menu_Save.TabIndex = 6;
      this.button_Menu_Save.Text = "Сохранить базу";
      this.button_Menu_Save.UseVisualStyleBackColor = true;
      this.button_Menu_Save.Click += new EventHandler(this.button_Menu_Save_Click);
      this.panel_Merch.BorderStyle = BorderStyle.FixedSingle;
      this.panel_Merch.Controls.Add((Control) this.button_Merch_Clean);
      this.panel_Merch.Controls.Add((Control) this.listBox_Merch_List);
      this.panel_Merch.Controls.Add((Control) this.label_Merch_ID);
      this.panel_Merch.Controls.Add((Control) this.label_Merch_Title);
      this.panel_Merch.Controls.Add((Control) this.panel_Merch_Chosen);
      this.panel_Merch.Controls.Add((Control) this.textBox_Merch_ID);
      this.panel_Merch.Controls.Add((Control) this.label_Merch_Name);
      this.panel_Merch.Controls.Add((Control) this.textBox_Merch_Name);
      this.panel_Merch.Controls.Add((Control) this.radioButton_Merch_FindByData);
      this.panel_Merch.Controls.Add((Control) this.radioButton_Merch_FindByID);
      this.panel_Merch.Controls.Add((Control) this.label_Merch_Master);
      this.panel_Merch.Controls.Add((Control) this.textBox_Merch_Master);
      this.panel_Merch.Enabled = false;
      this.panel_Merch.Location = new Point(230, 56);
      this.panel_Merch.Name = "panel_Merch";
      this.panel_Merch.Size = new Size(983, 637);
      this.panel_Merch.TabIndex = 5;
      this.panel_Merch.Visible = false;
      this.button_Merch_Clean.Location = new Point(405, 29);
      this.button_Merch_Clean.Name = "button_Merch_Clean";
      this.button_Merch_Clean.Size = new Size(100, 23);
      this.button_Merch_Clean.TabIndex = 13;
      this.button_Merch_Clean.Text = "Очистить поля";
      this.button_Merch_Clean.UseVisualStyleBackColor = true;
      this.button_Merch_Clean.Click += new EventHandler(this.button_Merch_Clean_Click);
      this.listBox_Merch_List.Enabled = false;
      this.listBox_Merch_List.FormattingEnabled = true;
      this.listBox_Merch_List.Location = new Point(10, 82);
      this.listBox_Merch_List.Name = "listBox_Merch_List";
      this.listBox_Merch_List.Size = new Size(965, 251);
      this.listBox_Merch_List.TabIndex = 10;
      this.listBox_Merch_List.SelectedIndexChanged += new EventHandler(this.listBox_Merch_List_SelectedIndexChanged);
      this.label_Merch_ID.AutoSize = true;
      this.label_Merch_ID.Location = new Point(10, 61);
      this.label_Merch_ID.Name = "label_Merch_ID";
      this.label_Merch_ID.Size = new Size(21, 13);
      this.label_Merch_ID.TabIndex = 4;
      this.label_Merch_ID.Text = "ID:";
      this.label_Merch_Title.AutoSize = true;
      this.label_Merch_Title.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Title.Location = new Point(4, 4);
      this.label_Merch_Title.Name = "label_Merch_Title";
      this.label_Merch_Title.Size = new Size(193, 20);
      this.label_Merch_Title.TabIndex = 12;
      this.label_Merch_Title.Text = "Операции с товарами";
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Cancel);
      this.panel_Merch_Chosen.Controls.Add((Control) this.textBox_Merch_Chosen_Number);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_N);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Export);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_History);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Master);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Edit);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_Comment);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Delete);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_GiveBack);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Add);
      this.panel_Merch_Chosen.Controls.Add((Control) this.button_Merch_Chosen_Sell);
      this.panel_Merch_Chosen.Controls.Add((Control) this.listBox_Merch_Chosen_History);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_Amount);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_Price);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_Master);
      this.panel_Merch_Chosen.Controls.Add((Control) this.label_Merch_Chosen_Name);
      this.panel_Merch_Chosen.Location = new Point(5, 344);
      this.panel_Merch_Chosen.Name = "panel_Merch_Chosen";
      this.panel_Merch_Chosen.Size = new Size(975, 287);
      this.panel_Merch_Chosen.TabIndex = 11;
      this.button_Merch_Chosen_Cancel.Location = new Point(806, 52);
      this.button_Merch_Chosen_Cancel.Name = "button_Merch_Chosen_Cancel";
      this.button_Merch_Chosen_Cancel.Size = new Size(161, 46);
      this.button_Merch_Chosen_Cancel.TabIndex = 17;
      this.button_Merch_Chosen_Cancel.Text = "Отменить выбранную операцию";
      this.button_Merch_Chosen_Cancel.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Cancel.Click += new EventHandler(this.button_Merch_Chosen_Cancel_Click);
      this.textBox_Merch_Chosen_Number.Location = new Point(457, 30);
      this.textBox_Merch_Chosen_Number.MaxLength = 3;
      this.textBox_Merch_Chosen_Number.Name = "textBox_Merch_Chosen_Number";
      this.textBox_Merch_Chosen_Number.Size = new Size(30, 20);
      this.textBox_Merch_Chosen_Number.TabIndex = 16;
      this.textBox_Merch_Chosen_Number.Text = "1";
      this.textBox_Merch_Chosen_Number.KeyPress += new KeyPressEventHandler(this.textBox_Merch_Chosen_Number_KeyPress);
      this.label_Merch_Chosen_N.AutoSize = true;
      this.label_Merch_Chosen_N.Location = new Point(493, 33);
      this.label_Merch_Chosen_N.Name = "label_Merch_Chosen_N";
      this.label_Merch_Chosen_N.Size = new Size(23, 13);
      this.label_Merch_Chosen_N.TabIndex = 15;
      this.label_Merch_Chosen_N.Text = "шт.";
      this.button_Merch_Chosen_Export.Location = new Point(806, 4);
      this.button_Merch_Chosen_Export.Name = "button_Merch_Chosen_Export";
      this.button_Merch_Chosen_Export.Size = new Size(161, 23);
      this.button_Merch_Chosen_Export.TabIndex = 14;
      this.button_Merch_Chosen_Export.Text = "Экспортировать историю";
      this.button_Merch_Chosen_Export.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Export.Click += new EventHandler(this.button_Merch_Chosen_Export_Click);
      this.label_Merch_Chosen_History.AutoSize = true;
      this.label_Merch_Chosen_History.Location = new Point(5, 90);
      this.label_Merch_Chosen_History.Name = "label_Merch_Chosen_History";
      this.label_Merch_Chosen_History.Size = new Size(104, 13);
      this.label_Merch_Chosen_History.TabIndex = 12;
      this.label_Merch_Chosen_History.Text = "История операций:";
      this.button_Merch_Chosen_Master.Location = new Point(521, 54);
      this.button_Merch_Chosen_Master.Name = "button_Merch_Chosen_Master";
      this.button_Merch_Chosen_Master.Size = new Size(75, 23);
      this.button_Merch_Chosen_Master.TabIndex = 11;
      this.button_Merch_Chosen_Master.Text = "К мастеру";
      this.button_Merch_Chosen_Master.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Master.Click += new EventHandler(this.button_Merch_Chosen_Master_Click);
      this.button_Merch_Chosen_Edit.Location = new Point(521, 28);
      this.button_Merch_Chosen_Edit.Name = "button_Merch_Chosen_Edit";
      this.button_Merch_Chosen_Edit.Size = new Size(75, 23);
      this.button_Merch_Chosen_Edit.TabIndex = 10;
      this.button_Merch_Chosen_Edit.Text = "Изменить";
      this.button_Merch_Chosen_Edit.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Edit.Click += new EventHandler(this.button_Merch_Chosen_Edit_Click);
      this.label_Merch_Chosen_Comment.AutoSize = true;
      this.label_Merch_Chosen_Comment.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Chosen_Comment.Location = new Point(3, 64);
      this.label_Merch_Chosen_Comment.Name = "label_Merch_Chosen_Comment";
      this.label_Merch_Chosen_Comment.Size = new Size(124, 20);
      this.label_Merch_Chosen_Comment.TabIndex = 9;
      this.label_Merch_Chosen_Comment.Text = "Комментарий";
      this.button_Merch_Chosen_Delete.Location = new Point(521, 3);
      this.button_Merch_Chosen_Delete.Name = "button_Merch_Chosen_Delete";
      this.button_Merch_Chosen_Delete.Size = new Size(75, 23);
      this.button_Merch_Chosen_Delete.TabIndex = 8;
      this.button_Merch_Chosen_Delete.Text = "Удалить";
      this.button_Merch_Chosen_Delete.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Delete.Click += new EventHandler(this.button_Merch_Chosen_Delete_Click);
      this.button_Merch_Chosen_GiveBack.Location = new Point(376, 54);
      this.button_Merch_Chosen_GiveBack.Name = "button_Merch_Chosen_GiveBack";
      this.button_Merch_Chosen_GiveBack.Size = new Size(75, 23);
      this.button_Merch_Chosen_GiveBack.TabIndex = 7;
      this.button_Merch_Chosen_GiveBack.Text = "Вернуть";
      this.button_Merch_Chosen_GiveBack.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_GiveBack.Click += new EventHandler(this.button_Merch_Chosen_GiveBack_Click);
      this.button_Merch_Chosen_Add.Location = new Point(376, 28);
      this.button_Merch_Chosen_Add.Name = "button_Merch_Chosen_Add";
      this.button_Merch_Chosen_Add.Size = new Size(75, 23);
      this.button_Merch_Chosen_Add.TabIndex = 6;
      this.button_Merch_Chosen_Add.Text = "Добавить";
      this.button_Merch_Chosen_Add.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Add.Click += new EventHandler(this.button_Merch_Chosen_Add_Click);
      this.button_Merch_Chosen_Sell.Location = new Point(376, 3);
      this.button_Merch_Chosen_Sell.Name = "button_Merch_Chosen_Sell";
      this.button_Merch_Chosen_Sell.Size = new Size(75, 23);
      this.button_Merch_Chosen_Sell.TabIndex = 5;
      this.button_Merch_Chosen_Sell.Text = "Продать";
      this.button_Merch_Chosen_Sell.UseVisualStyleBackColor = true;
      this.button_Merch_Chosen_Sell.Click += new EventHandler(this.button_Merch_Chosen_Sell_Click);
      this.listBox_Merch_Chosen_History.FormattingEnabled = true;
      this.listBox_Merch_Chosen_History.Location = new Point(5, 106);
      this.listBox_Merch_Chosen_History.Name = "listBox_Merch_Chosen_History";
      this.listBox_Merch_Chosen_History.Size = new Size(962, 173);
      this.listBox_Merch_Chosen_History.TabIndex = 4;
      this.label_Merch_Chosen_Amount.AutoSize = true;
      this.label_Merch_Chosen_Amount.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Chosen_Amount.Location = new Point(3, 44);
      this.label_Merch_Chosen_Amount.Name = "label_Merch_Chosen_Amount";
      this.label_Merch_Chosen_Amount.Size = new Size(109, 20);
      this.label_Merch_Chosen_Amount.TabIndex = 3;
      this.label_Merch_Chosen_Amount.Text = "Количество";
      this.label_Merch_Chosen_Price.AutoSize = true;
      this.label_Merch_Chosen_Price.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Chosen_Price.Location = new Point(118, 44);
      this.label_Merch_Chosen_Price.Name = "label_Merch_Chosen_Price";
      this.label_Merch_Chosen_Price.Size = new Size(52, 20);
      this.label_Merch_Chosen_Price.TabIndex = 2;
      this.label_Merch_Chosen_Price.Text = "Цена";
      this.label_Merch_Chosen_Master.AutoSize = true;
      this.label_Merch_Chosen_Master.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Chosen_Master.Location = new Point(4, 24);
      this.label_Merch_Chosen_Master.Name = "label_Merch_Chosen_Master";
      this.label_Merch_Chosen_Master.Size = new Size(72, 20);
      this.label_Merch_Chosen_Master.TabIndex = 1;
      this.label_Merch_Chosen_Master.Text = "Мастер";
      this.label_Merch_Chosen_Name.AutoSize = true;
      this.label_Merch_Chosen_Name.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Merch_Chosen_Name.Location = new Point(4, 4);
      this.label_Merch_Chosen_Name.Name = "label_Merch_Chosen_Name";
      this.label_Merch_Chosen_Name.Size = new Size(91, 20);
      this.label_Merch_Chosen_Name.TabIndex = 0;
      this.label_Merch_Chosen_Name.Text = "Название";
      this.textBox_Merch_ID.Location = new Point(37, 58);
      this.textBox_Merch_ID.MaxLength = 4;
      this.textBox_Merch_ID.Name = "textBox_Merch_ID";
      this.textBox_Merch_ID.Size = new Size(100, 20);
      this.textBox_Merch_ID.TabIndex = 2;
      this.textBox_Merch_ID.TextChanged += new EventHandler(this.textBox_Merch_ID_TextChanged);
      this.textBox_Merch_ID.KeyPress += new KeyPressEventHandler(this.textBox_Merch_ID_KeyPress);
      this.label_Merch_Name.AutoSize = true;
      this.label_Merch_Name.Location = new Point(339, 61);
      this.label_Merch_Name.Name = "label_Merch_Name";
      this.label_Merch_Name.Size = new Size(60, 13);
      this.label_Merch_Name.TabIndex = 5;
      this.label_Merch_Name.Text = "Название:";
      this.textBox_Merch_Name.Enabled = false;
      this.textBox_Merch_Name.Location = new Point(405, 58);
      this.textBox_Merch_Name.MaxLength = 100;
      this.textBox_Merch_Name.Name = "textBox_Merch_Name";
      this.textBox_Merch_Name.Size = new Size(100, 20);
      this.textBox_Merch_Name.TabIndex = 3;
      this.textBox_Merch_Name.TextChanged += new EventHandler(this.textBox_Merch_Name_TextChanged);
      this.radioButton_Merch_FindByData.AutoSize = true;
      this.radioButton_Merch_FindByData.Location = new Point(160, 28);
      this.radioButton_Merch_FindByData.Name = "radioButton_Merch_FindByData";
      this.radioButton_Merch_FindByData.Size = new Size(210, 17);
      this.radioButton_Merch_FindByData.TabIndex = 1;
      this.radioButton_Merch_FindByData.Text = "Найти товар по названию и мастеру";
      this.radioButton_Merch_FindByData.UseVisualStyleBackColor = true;
      this.radioButton_Merch_FindByData.CheckedChanged += new EventHandler(this.radioButton_Merch_FindByData_CheckedChanged);
      this.radioButton_Merch_FindByID.AutoSize = true;
      this.radioButton_Merch_FindByID.Checked = true;
      this.radioButton_Merch_FindByID.Location = new Point(13, 29);
      this.radioButton_Merch_FindByID.Name = "radioButton_Merch_FindByID";
      this.radioButton_Merch_FindByID.Size = new Size(117, 17);
      this.radioButton_Merch_FindByID.TabIndex = 0;
      this.radioButton_Merch_FindByID.TabStop = true;
      this.radioButton_Merch_FindByID.Text = "Найти товар по ID";
      this.radioButton_Merch_FindByID.UseVisualStyleBackColor = true;
      this.radioButton_Merch_FindByID.CheckedChanged += new EventHandler(this.radioButton_Merch_FindByID_CheckedChanged);
      this.label_Merch_Master.AutoSize = true;
      this.label_Merch_Master.Location = new Point(179, 61);
      this.label_Merch_Master.Name = "label_Merch_Master";
      this.label_Merch_Master.Size = new Size(48, 13);
      this.label_Merch_Master.TabIndex = 6;
      this.label_Merch_Master.Text = "Мастер:";
      this.textBox_Merch_Master.Enabled = false;
      this.textBox_Merch_Master.Location = new Point(233, 58);
      this.textBox_Merch_Master.MaxLength = 100;
      this.textBox_Merch_Master.Name = "textBox_Merch_Master";
      this.textBox_Merch_Master.Size = new Size(100, 20);
      this.textBox_Merch_Master.TabIndex = 7;
      this.textBox_Merch_Master.TextChanged += new EventHandler(this.textBox_Merch_Master_TextChanged);
      this.panel_Master.BorderStyle = BorderStyle.FixedSingle;
      this.panel_Master.Controls.Add((Control) this.label_Master_Title);
      this.panel_Master.Controls.Add((Control) this.panel_Master_Chosen);
      this.panel_Master.Controls.Add((Control) this.listBox_Master_List);
      this.panel_Master.Controls.Add((Control) this.label_Master_Name);
      this.panel_Master.Controls.Add((Control) this.textBox_Master_Name);
      this.panel_Master.Enabled = false;
      this.panel_Master.Location = new Point(879, 68);
      this.panel_Master.Name = "panel_Master";
      this.panel_Master.Size = new Size(983, 645);
      this.panel_Master.TabIndex = 6;
      this.panel_Master.Visible = false;
      this.label_Master_Title.AutoSize = true;
      this.label_Master_Title.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Master_Title.Location = new Point(3, 5);
      this.label_Master_Title.Name = "label_Master_Title";
      this.label_Master_Title.Size = new Size(204, 20);
      this.label_Master_Title.TabIndex = 4;
      this.label_Master_Title.Text = "Операции с мастерами";
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_Cancel);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_Export);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_NewMerch);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_ToChosenMerch);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_Delete);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_Edit);
      this.panel_Master_Chosen.Controls.Add((Control) this.listBox_Master_Chosen_Merch);
      this.panel_Master_Chosen.Controls.Add((Control) this.label_Master_Chosen_Merch);
      this.panel_Master_Chosen.Controls.Add((Control) this.listBox_Master_Chosen_History);
      this.panel_Master_Chosen.Controls.Add((Control) this.label_Master_Chosen_History);
      this.panel_Master_Chosen.Controls.Add((Control) this.button_Master_Chosen_Debt);
      this.panel_Master_Chosen.Controls.Add((Control) this.textBox_Master_Chosen_Debt);
      this.panel_Master_Chosen.Controls.Add((Control) this.label_Master_Chosen_Debt);
      this.panel_Master_Chosen.Controls.Add((Control) this.label_Master_Chosen_Comment);
      this.panel_Master_Chosen.Controls.Add((Control) this.label_Master_Chosen_Name);
      this.panel_Master_Chosen.Location = new Point(3, 282);
      this.panel_Master_Chosen.Name = "panel_Master_Chosen";
      this.panel_Master_Chosen.Size = new Size(972, 355);
      this.panel_Master_Chosen.TabIndex = 3;
      this.button_Master_Chosen_Cancel.Location = new Point(816, 73);
      this.button_Master_Chosen_Cancel.Name = "button_Master_Chosen_Cancel";
      this.button_Master_Chosen_Cancel.Size = new Size(153, 38);
      this.button_Master_Chosen_Cancel.TabIndex = 13;
      this.button_Master_Chosen_Cancel.Text = "Отменить выбранную операцию";
      this.button_Master_Chosen_Cancel.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_Cancel.Click += new EventHandler(this.button_Master_Chosen_Cancel_Click);
      this.button_Master_Chosen_Export.Location = new Point(816, 6);
      this.button_Master_Chosen_Export.Name = "button_Master_Chosen_Export";
      this.button_Master_Chosen_Export.Size = new Size(153, 23);
      this.button_Master_Chosen_Export.TabIndex = 12;
      this.button_Master_Chosen_Export.Text = "Экспортировать историю";
      this.button_Master_Chosen_Export.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_Export.Click += new EventHandler(this.button_Master_Chosen_Export_Click);
      this.button_Master_Chosen_NewMerch.Location = new Point(390, 326);
      this.button_Master_Chosen_NewMerch.Name = "button_Master_Chosen_NewMerch";
      this.button_Master_Chosen_NewMerch.Size = new Size(104, 23);
      this.button_Master_Chosen_NewMerch.TabIndex = 11;
      this.button_Master_Chosen_NewMerch.Text = "Добавить товар";
      this.button_Master_Chosen_NewMerch.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_NewMerch.Click += new EventHandler(this.button_Master_Chosen_NewMerch_Click);
      this.button_Master_Chosen_ToChosenMerch.Location = new Point(7, 326);
      this.button_Master_Chosen_ToChosenMerch.Name = "button_Master_Chosen_ToChosenMerch";
      this.button_Master_Chosen_ToChosenMerch.Size = new Size(75, 23);
      this.button_Master_Chosen_ToChosenMerch.TabIndex = 4;
      this.button_Master_Chosen_ToChosenMerch.Text = "К товару";
      this.button_Master_Chosen_ToChosenMerch.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_ToChosenMerch.Click += new EventHandler(this.button_Master_Chosen_ToChosenMerch_Click);
      this.button_Master_Chosen_Delete.Location = new Point(419, 38);
      this.button_Master_Chosen_Delete.Name = "button_Master_Chosen_Delete";
      this.button_Master_Chosen_Delete.Size = new Size(75, 23);
      this.button_Master_Chosen_Delete.TabIndex = 10;
      this.button_Master_Chosen_Delete.Text = "Удалить";
      this.button_Master_Chosen_Delete.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_Delete.Click += new EventHandler(this.button_Master_Chosen_Delete_Click);
      this.button_Master_Chosen_Edit.Location = new Point(419, 9);
      this.button_Master_Chosen_Edit.Name = "button_Master_Chosen_Edit";
      this.button_Master_Chosen_Edit.Size = new Size(75, 23);
      this.button_Master_Chosen_Edit.TabIndex = 9;
      this.button_Master_Chosen_Edit.Text = "Изменить";
      this.button_Master_Chosen_Edit.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_Edit.Click += new EventHandler(this.button_Master_Chosen_Edit_Click);
      this.listBox_Master_Chosen_Merch.FormattingEnabled = true;
      this.listBox_Master_Chosen_Merch.Location = new Point(7, 238);
      this.listBox_Master_Chosen_Merch.Name = "listBox_Master_Chosen_Merch";
      this.listBox_Master_Chosen_Merch.Size = new Size(962, 82);
      this.listBox_Master_Chosen_Merch.TabIndex = 8;
      this.listBox_Master_Chosen_Merch.SelectedIndexChanged += new EventHandler(this.listBox_Master_Chosen_Merch_SelectedIndexChanged);
      this.label_Master_Chosen_Merch.AutoSize = true;
      this.label_Master_Chosen_Merch.Location = new Point(7, 221);
      this.label_Master_Chosen_Merch.Name = "label_Master_Chosen_Merch";
      this.label_Master_Chosen_Merch.Size = new Size(49, 13);
      this.label_Master_Chosen_Merch.TabIndex = 7;
      this.label_Master_Chosen_Merch.Text = "Товары:";
      this.listBox_Master_Chosen_History.FormattingEnabled = true;
      this.listBox_Master_Chosen_History.Location = new Point(7, 121);
      this.listBox_Master_Chosen_History.Name = "listBox_Master_Chosen_History";
      this.listBox_Master_Chosen_History.Size = new Size(962, 82);
      this.listBox_Master_Chosen_History.TabIndex = 6;
      this.label_Master_Chosen_History.AutoSize = true;
      this.label_Master_Chosen_History.Location = new Point(4, 102);
      this.label_Master_Chosen_History.Name = "label_Master_Chosen_History";
      this.label_Master_Chosen_History.Size = new Size(104, 13);
      this.label_Master_Chosen_History.TabIndex = 5;
      this.label_Master_Chosen_History.Text = "История операций:";
      this.button_Master_Chosen_Debt.Location = new Point(7, 73);
      this.button_Master_Chosen_Debt.Name = "button_Master_Chosen_Debt";
      this.button_Master_Chosen_Debt.Size = new Size(75, 23);
      this.button_Master_Chosen_Debt.TabIndex = 4;
      this.button_Master_Chosen_Debt.Text = "Выплатить:";
      this.button_Master_Chosen_Debt.UseVisualStyleBackColor = true;
      this.button_Master_Chosen_Debt.Click += new EventHandler(this.button_Master_Chosen_Debt_Click);
      this.textBox_Master_Chosen_Debt.Location = new Point(88, 75);
      this.textBox_Master_Chosen_Debt.Name = "textBox_Master_Chosen_Debt";
      this.textBox_Master_Chosen_Debt.Size = new Size(65, 20);
      this.textBox_Master_Chosen_Debt.TabIndex = 3;
      this.textBox_Master_Chosen_Debt.KeyPress += new KeyPressEventHandler(this.textBox_Master_Chosen_Debt_KeyPress);
      this.label_Master_Chosen_Debt.AutoSize = true;
      this.label_Master_Chosen_Debt.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Master_Chosen_Debt.Location = new Point(3, 50);
      this.label_Master_Chosen_Debt.Name = "label_Master_Chosen_Debt";
      this.label_Master_Chosen_Debt.Size = new Size(50, 20);
      this.label_Master_Chosen_Debt.TabIndex = 2;
      this.label_Master_Chosen_Debt.Text = "Долг";
      this.label_Master_Chosen_Comment.AutoSize = true;
      this.label_Master_Chosen_Comment.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Master_Chosen_Comment.Location = new Point(3, 29);
      this.label_Master_Chosen_Comment.Name = "label_Master_Chosen_Comment";
      this.label_Master_Chosen_Comment.Size = new Size(124, 20);
      this.label_Master_Chosen_Comment.TabIndex = 1;
      this.label_Master_Chosen_Comment.Text = "Комментарий";
      this.label_Master_Chosen_Name.AutoSize = true;
      this.label_Master_Chosen_Name.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_Master_Chosen_Name.Location = new Point(3, 9);
      this.label_Master_Chosen_Name.Name = "label_Master_Chosen_Name";
      this.label_Master_Chosen_Name.Size = new Size(42, 20);
      this.label_Master_Chosen_Name.TabIndex = 0;
      this.label_Master_Chosen_Name.Text = "Имя";
      this.listBox_Master_List.FormattingEnabled = true;
      this.listBox_Master_List.Location = new Point(3, 64);
      this.listBox_Master_List.Name = "listBox_Master_List";
      this.listBox_Master_List.Size = new Size(969, 212);
      this.listBox_Master_List.TabIndex = 2;
      this.listBox_Master_List.SelectedIndexChanged += new EventHandler(this.listBox_Master_List_SelectedIndexChanged);
      this.label_Master_Name.AutoSize = true;
      this.label_Master_Name.Location = new Point(3, 41);
      this.label_Master_Name.Name = "label_Master_Name";
      this.label_Master_Name.Size = new Size(32, 13);
      this.label_Master_Name.TabIndex = 1;
      this.label_Master_Name.Text = "Имя:";
      this.textBox_Master_Name.Location = new Point(41, 38);
      this.textBox_Master_Name.MaxLength = 50;
      this.textBox_Master_Name.Name = "textBox_Master_Name";
      this.textBox_Master_Name.Size = new Size(456, 20);
      this.textBox_Master_Name.TabIndex = 0;
      this.textBox_Master_Name.TextChanged += new EventHandler(this.textBox_Master_Name_TextChanged);
      this.panel_NewMerch.BorderStyle = BorderStyle.FixedSingle;
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_Amount);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Amount);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Title);
      this.panel_NewMerch.Controls.Add((Control) this.checkBox_NewMerch_ToMerch);
      this.panel_NewMerch.Controls.Add((Control) this.button_NewMerch_Cancel);
      this.panel_NewMerch.Controls.Add((Control) this.button_NewMerch_Edit);
      this.panel_NewMerch.Controls.Add((Control) this.button_NewMerch_Add);
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_Comment);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Comment);
      this.panel_NewMerch.Controls.Add((Control) this.label1);
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_Markup);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Markup);
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_PriceBefore);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_PriceBefore);
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_Name);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Name);
      this.panel_NewMerch.Controls.Add((Control) this.listBox_NewMerch_Master);
      this.panel_NewMerch.Controls.Add((Control) this.textBox_NewMerch_Master);
      this.panel_NewMerch.Controls.Add((Control) this.label_NewMerch_Master);
      this.panel_NewMerch.Enabled = false;
      this.panel_NewMerch.Location = new Point(1193, 219);
      this.panel_NewMerch.Name = "panel_NewMerch";
      this.panel_NewMerch.Size = new Size(983, 481);
      this.panel_NewMerch.TabIndex = 7;
      this.panel_NewMerch.Visible = false;
      this.textBox_NewMerch_Amount.Location = new Point(386, 400);
      this.textBox_NewMerch_Amount.MaxLength = 3;
      this.textBox_NewMerch_Amount.Name = "textBox_NewMerch_Amount";
      this.textBox_NewMerch_Amount.Size = new Size(59, 20);
      this.textBox_NewMerch_Amount.TabIndex = 18;
      this.label_NewMerch_Amount.AutoSize = true;
      this.label_NewMerch_Amount.Location = new Point(311, 403);
      this.label_NewMerch_Amount.Name = "label_NewMerch_Amount";
      this.label_NewMerch_Amount.Size = new Size(69, 13);
      this.label_NewMerch_Amount.TabIndex = 17;
      this.label_NewMerch_Amount.Text = "Количество:";
      this.label_NewMerch_Title.AutoSize = true;
      this.label_NewMerch_Title.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_NewMerch_Title.Location = new Point(6, 7);
      this.label_NewMerch_Title.Name = "label_NewMerch_Title";
      this.label_NewMerch_Title.Size = new Size(240, 20);
      this.label_NewMerch_Title.TabIndex = 8;
      this.label_NewMerch_Title.Text = "Добавление нового товара";
      this.checkBox_NewMerch_ToMerch.AutoSize = true;
      this.checkBox_NewMerch_ToMerch.Location = new Point(6, 426);
      this.checkBox_NewMerch_ToMerch.Name = "checkBox_NewMerch_ToMerch";
      this.checkBox_NewMerch_ToMerch.Size = new Size(115, 17);
      this.checkBox_NewMerch_ToMerch.TabIndex = 16;
      this.checkBox_NewMerch_ToMerch.Text = "Перейти к товару";
      this.checkBox_NewMerch_ToMerch.UseVisualStyleBackColor = true;
      this.button_NewMerch_Cancel.Enabled = false;
      this.button_NewMerch_Cancel.Location = new Point(260, 450);
      this.button_NewMerch_Cancel.Name = "button_NewMerch_Cancel";
      this.button_NewMerch_Cancel.Size = new Size(75, 23);
      this.button_NewMerch_Cancel.TabIndex = 15;
      this.button_NewMerch_Cancel.Text = "Назад";
      this.button_NewMerch_Cancel.UseVisualStyleBackColor = true;
      this.button_NewMerch_Cancel.Visible = false;
      this.button_NewMerch_Cancel.Click += new EventHandler(this.button_NewMerch_Cancel_Click);
      this.button_NewMerch_Edit.Enabled = false;
      this.button_NewMerch_Edit.Location = new Point(341, 450);
      this.button_NewMerch_Edit.Name = "button_NewMerch_Edit";
      this.button_NewMerch_Edit.Size = new Size(75, 23);
      this.button_NewMerch_Edit.TabIndex = 14;
      this.button_NewMerch_Edit.Text = "Изменить";
      this.button_NewMerch_Edit.UseVisualStyleBackColor = true;
      this.button_NewMerch_Edit.Visible = false;
      this.button_NewMerch_Edit.Click += new EventHandler(this.button_NewMerch_Edit_Click);
      this.button_NewMerch_Add.Enabled = false;
      this.button_NewMerch_Add.Location = new Point(422, 450);
      this.button_NewMerch_Add.Name = "button_NewMerch_Add";
      this.button_NewMerch_Add.Size = new Size(75, 23);
      this.button_NewMerch_Add.TabIndex = 13;
      this.button_NewMerch_Add.Text = "Добавить";
      this.button_NewMerch_Add.UseVisualStyleBackColor = true;
      this.button_NewMerch_Add.Click += new EventHandler(this.button_NewMerch_Add_Click);
      this.textBox_NewMerch_Comment.Location = new Point(92, 369);
      this.textBox_NewMerch_Comment.MaxLength = 100;
      this.textBox_NewMerch_Comment.Name = "textBox_NewMerch_Comment";
      this.textBox_NewMerch_Comment.Size = new Size(405, 20);
      this.textBox_NewMerch_Comment.TabIndex = 12;
      this.label_NewMerch_Comment.AutoSize = true;
      this.label_NewMerch_Comment.Location = new Point(6, 372);
      this.label_NewMerch_Comment.Name = "label_NewMerch_Comment";
      this.label_NewMerch_Comment.Size = new Size(80, 13);
      this.label_NewMerch_Comment.TabIndex = 11;
      this.label_NewMerch_Comment.Text = "Комментарий:";
      this.label1.AutoSize = true;
      this.label1.Location = new Point(10, 416);
      this.label1.Name = "label1";
      this.label1.Size = new Size(0, 13);
      this.label1.TabIndex = 10;
      this.textBox_NewMerch_Markup.Location = new Point(238, 400);
      this.textBox_NewMerch_Markup.MaxLength = 5;
      this.textBox_NewMerch_Markup.Name = "textBox_NewMerch_Markup";
      this.textBox_NewMerch_Markup.Size = new Size(64, 20);
      this.textBox_NewMerch_Markup.TabIndex = 8;
      this.textBox_NewMerch_Markup.KeyPress += new KeyPressEventHandler(this.textBox_NewMerch_Markup_KeyPress);
      this.label_NewMerch_Markup.AutoSize = true;
      this.label_NewMerch_Markup.Location = new Point(178, 403);
      this.label_NewMerch_Markup.Name = "label_NewMerch_Markup";
      this.label_NewMerch_Markup.Size = new Size(54, 13);
      this.label_NewMerch_Markup.TabIndex = 7;
      this.label_NewMerch_Markup.Text = "Наценка:";
      this.textBox_NewMerch_PriceBefore.Location = new Point(108, 400);
      this.textBox_NewMerch_PriceBefore.MaxLength = 5;
      this.textBox_NewMerch_PriceBefore.Name = "textBox_NewMerch_PriceBefore";
      this.textBox_NewMerch_PriceBefore.Size = new Size(64, 20);
      this.textBox_NewMerch_PriceBefore.TabIndex = 6;
      this.textBox_NewMerch_PriceBefore.KeyPress += new KeyPressEventHandler(this.textBox_NewMerch_PriceBefore_KeyPress);
      this.label_NewMerch_PriceBefore.AutoSize = true;
      this.label_NewMerch_PriceBefore.Location = new Point(6, 403);
      this.label_NewMerch_PriceBefore.Name = "label_NewMerch_PriceBefore";
      this.label_NewMerch_PriceBefore.Size = new Size(96, 13);
      this.label_NewMerch_PriceBefore.TabIndex = 5;
      this.label_NewMerch_PriceBefore.Text = "Цена до наценки:";
      this.textBox_NewMerch_Name.Location = new Point(72, 343);
      this.textBox_NewMerch_Name.MaxLength = 50;
      this.textBox_NewMerch_Name.Name = "textBox_NewMerch_Name";
      this.textBox_NewMerch_Name.Size = new Size(425, 20);
      this.textBox_NewMerch_Name.TabIndex = 4;
      this.label_NewMerch_Name.AutoSize = true;
      this.label_NewMerch_Name.Location = new Point(6, 346);
      this.label_NewMerch_Name.Name = "label_NewMerch_Name";
      this.label_NewMerch_Name.Size = new Size(60, 13);
      this.label_NewMerch_Name.TabIndex = 3;
      this.label_NewMerch_Name.Text = "Название:";
      this.listBox_NewMerch_Master.FormattingEnabled = true;
      this.listBox_NewMerch_Master.Location = new Point(6, 58);
      this.listBox_NewMerch_Master.Name = "listBox_NewMerch_Master";
      this.listBox_NewMerch_Master.Size = new Size(974, 277);
      this.listBox_NewMerch_Master.TabIndex = 2;
      this.textBox_NewMerch_Master.Location = new Point(57, 34);
      this.textBox_NewMerch_Master.MaxLength = 50;
      this.textBox_NewMerch_Master.Name = "textBox_NewMerch_Master";
      this.textBox_NewMerch_Master.Size = new Size(923, 20);
      this.textBox_NewMerch_Master.TabIndex = 1;
      this.textBox_NewMerch_Master.TextChanged += new EventHandler(this.textBox_NewMerch_Master_TextChanged);
      this.label_NewMerch_Master.AutoSize = true;
      this.label_NewMerch_Master.Location = new Point(3, 37);
      this.label_NewMerch_Master.Name = "label_NewMerch_Master";
      this.label_NewMerch_Master.Size = new Size(48, 13);
      this.label_NewMerch_Master.TabIndex = 0;
      this.label_NewMerch_Master.Text = "Мастер:";
      this.panel_NewMaster.BorderStyle = BorderStyle.FixedSingle;
      this.panel_NewMaster.Controls.Add((Control) this.checkBox_NewMaster_ToMaster);
      this.panel_NewMaster.Controls.Add((Control) this.button_NewMaster_Cancel);
      this.panel_NewMaster.Controls.Add((Control) this.button_NewMaster_Edit);
      this.panel_NewMaster.Controls.Add((Control) this.button_NewMaster_Add);
      this.panel_NewMaster.Controls.Add((Control) this.textBox_NewMaster_Comment);
      this.panel_NewMaster.Controls.Add((Control) this.label_NewMaster_Comment);
      this.panel_NewMaster.Controls.Add((Control) this.textBox_NewMaster_Name);
      this.panel_NewMaster.Controls.Add((Control) this.label_NewMaster_Name);
      this.panel_NewMaster.Controls.Add((Control) this.label_NewMaster_Title);
      this.panel_NewMaster.Location = new Point(1222, 36);
      this.panel_NewMaster.Name = "panel_NewMaster";
      this.panel_NewMaster.Size = new Size(983, 148);
      this.panel_NewMaster.TabIndex = 8;
      this.checkBox_NewMaster_ToMaster.AutoSize = true;
      this.checkBox_NewMaster_ToMaster.Checked = true;
      this.checkBox_NewMaster_ToMaster.CheckState = CheckState.Checked;
      this.checkBox_NewMaster_ToMaster.Location = new Point(13, 91);
      this.checkBox_NewMaster_ToMaster.Name = "checkBox_NewMaster_ToMaster";
      this.checkBox_NewMaster_ToMaster.Size = new Size(123, 17);
      this.checkBox_NewMaster_ToMaster.TabIndex = 8;
      this.checkBox_NewMaster_ToMaster.Text = "Перейти к мастеру";
      this.checkBox_NewMaster_ToMaster.UseVisualStyleBackColor = true;
      this.button_NewMaster_Cancel.Enabled = false;
      this.button_NewMaster_Cancel.Location = new Point(261, 88);
      this.button_NewMaster_Cancel.Name = "button_NewMaster_Cancel";
      this.button_NewMaster_Cancel.Size = new Size(75, 23);
      this.button_NewMaster_Cancel.TabIndex = 7;
      this.button_NewMaster_Cancel.Text = "Назад";
      this.button_NewMaster_Cancel.UseVisualStyleBackColor = true;
      this.button_NewMaster_Cancel.Visible = false;
      this.button_NewMaster_Cancel.Click += new EventHandler(this.button_NewMaster_Cancel_Click);
      this.button_NewMaster_Edit.Enabled = false;
      this.button_NewMaster_Edit.Location = new Point(342, 88);
      this.button_NewMaster_Edit.Name = "button_NewMaster_Edit";
      this.button_NewMaster_Edit.Size = new Size(75, 23);
      this.button_NewMaster_Edit.TabIndex = 6;
      this.button_NewMaster_Edit.Text = "Изменить";
      this.button_NewMaster_Edit.UseVisualStyleBackColor = true;
      this.button_NewMaster_Edit.Visible = false;
      this.button_NewMaster_Edit.Click += new EventHandler(this.button_NewMaster_Edit_Click);
      this.button_NewMaster_Add.Enabled = false;
      this.button_NewMaster_Add.Location = new Point(423, 89);
      this.button_NewMaster_Add.Name = "button_NewMaster_Add";
      this.button_NewMaster_Add.Size = new Size(75, 23);
      this.button_NewMaster_Add.TabIndex = 5;
      this.button_NewMaster_Add.Text = "Добавить";
      this.button_NewMaster_Add.UseVisualStyleBackColor = true;
      this.button_NewMaster_Add.Click += new EventHandler(this.button_NewMaster_Add_Click);
      this.textBox_NewMaster_Comment.Location = new Point(97, 63);
      this.textBox_NewMaster_Comment.MaxLength = 100;
      this.textBox_NewMaster_Comment.Name = "textBox_NewMaster_Comment";
      this.textBox_NewMaster_Comment.Size = new Size(876, 20);
      this.textBox_NewMaster_Comment.TabIndex = 4;
      this.label_NewMaster_Comment.AutoSize = true;
      this.label_NewMaster_Comment.Location = new Point(10, 66);
      this.label_NewMaster_Comment.Name = "label_NewMaster_Comment";
      this.label_NewMaster_Comment.Size = new Size(80, 13);
      this.label_NewMaster_Comment.TabIndex = 3;
      this.label_NewMaster_Comment.Text = "Комментарий:";
      this.textBox_NewMaster_Name.Location = new Point(48, 37);
      this.textBox_NewMaster_Name.MaxLength = 50;
      this.textBox_NewMaster_Name.Name = "textBox_NewMaster_Name";
      this.textBox_NewMaster_Name.Size = new Size(925, 20);
      this.textBox_NewMaster_Name.TabIndex = 2;
      this.label_NewMaster_Name.AutoSize = true;
      this.label_NewMaster_Name.Location = new Point(10, 40);
      this.label_NewMaster_Name.Name = "label_NewMaster_Name";
      this.label_NewMaster_Name.Size = new Size(32, 13);
      this.label_NewMaster_Name.TabIndex = 1;
      this.label_NewMaster_Name.Text = "Имя:";
      this.label_NewMaster_Title.AutoSize = true;
      this.label_NewMaster_Title.Font = new Font("Microsoft Sans Serif", 12.25f);
      this.label_NewMaster_Title.Location = new Point(9, 8);
      this.label_NewMaster_Title.Name = "label_NewMaster_Title";
      this.label_NewMaster_Title.Size = new Size(251, 20);
      this.label_NewMaster_Title.TabIndex = 0;
      this.label_NewMaster_Title.Text = "Добавление нового мастера";
      this.label_Donations.AutoSize = true;
      this.label_Donations.ForeColor = Color.Blue;
      this.label_Donations.Location = new Point(198, 12);
      this.label_Donations.Name = "label_Donations";
      this.label_Donations.Size = new Size(83, 13);
      this.label_Donations.TabIndex = 9;
      this.label_Donations.Text = "label_Donations";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1194, 711);
      this.Controls.Add((Control) this.label_Donations);
      this.Controls.Add((Control) this.panel_NewMaster);
      this.Controls.Add((Control) this.panel_NewMerch);
      this.Controls.Add((Control) this.panel_Master);
      this.Controls.Add((Control) this.panel_Merch);
      this.Controls.Add((Control) this.panel_Menu);
      this.Name = nameof (MainForm);
      this.Text = " Книга мастеров";
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.panel_Menu.ResumeLayout(false);
      this.panel_Menu.PerformLayout();
      this.panel_Merch.ResumeLayout(false);
      this.panel_Merch.PerformLayout();
      this.panel_Merch_Chosen.ResumeLayout(false);
      this.panel_Merch_Chosen.PerformLayout();
      this.panel_Master.ResumeLayout(false);
      this.panel_Master.PerformLayout();
      this.panel_Master_Chosen.ResumeLayout(false);
      this.panel_Master_Chosen.PerformLayout();
      this.panel_NewMerch.ResumeLayout(false);
      this.panel_NewMerch.PerformLayout();
      this.panel_NewMaster.ResumeLayout(false);
      this.panel_NewMaster.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
