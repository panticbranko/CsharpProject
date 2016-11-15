namespace WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Web.Script.Serialization;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private const string RootOfConfigurationFile = @"c:\\Nenad\root.txt";
        private string pathOfConfigurationFile;
        private TableLayout startLayout;

        public Form1()
        {
            this.InitializeComponent();

            CasinoAndTables list1 = new CasinoAndTables(); //we need more lists becasue of datasource binding
            CasinoAndTables list2 = new CasinoAndTables();
            CasinoAndTables list3 = new CasinoAndTables();
            CasinoAndTables list4 = new CasinoAndTables();
            list1.pushCasinoList(this.ChooseCasinoRegion1);
            list2.pushCasinoList(this.ChooseCasinoRegion2);
            list3.pushCasinoList(this.ChooseCasinoRegion3);
            list4.pushCasinoList(this.ChooseCasinoRegion4);
            list1.pushNumberList(this.NumbTablesRegion1);
            list2.pushNumberList(this.NumbTablesRegion2);
            list3.pushNumberList(this.NumbTablesRegion3);
            list4.pushNumberList(this.NumbTablesRegion4);
            this.startLayout = new TableLayout();
            this.pathOfConfigurationFile = @"c:\\Nenad\configuration.txt";
            if (!File.Exists(RootOfConfigurationFile) || !File.Exists(this.pathOfConfigurationFile) || new FileInfo(this.pathOfConfigurationFile).Length == 0)
            {
                File.Create(this.pathOfConfigurationFile).Close();
                File.WriteAllText(RootOfConfigurationFile, this.pathOfConfigurationFile);
                this.WriteCurrentLayoutToFile();
            }
            else
            {
                this.pathOfConfigurationFile = File.ReadAllText(RootOfConfigurationFile);
                if (!File.Exists(this.pathOfConfigurationFile))
                {
                    File.Create(this.pathOfConfigurationFile).Close();
                    File.WriteAllText(RootOfConfigurationFile, this.pathOfConfigurationFile);
                    this.WriteCurrentLayoutToFile();
                }
                else
                {
                    this.WriteCurrentFileValuesToLayout(this.pathOfConfigurationFile);
                }
            }
        }

        public void WriteCurrentFileValuesToLayout(string path)
        {
            JavaScriptSerializer start_ser = new JavaScriptSerializer();
            string jason = File.ReadAllText(path);
            this.startLayout = start_ser.Deserialize<TableLayout>(jason);
            this.FillLayout(this.startLayout);
        }

        public void WriteCurrentLayoutToFile()
        {
            TableLayout layout = new TableLayout();
            this.InitLyaout(layout);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string json = ser.Serialize(layout);
            File.WriteAllText(this.pathOfConfigurationFile, json);
        }

        public void FillLayout(TableLayout startingTableLayout)
        {
            LevelRanges setLevel = new LevelRanges();
            this.NumbTablesRegion1.SelectedItem = startingTableLayout.Region1.TableNumbers.ToString();
            this.NumbTablesRegion2.SelectedItem = startingTableLayout.Region2.TableNumbers.ToString();
            this.NumbTablesRegion3.SelectedItem = startingTableLayout.Region3.TableNumbers.ToString();
            this.NumbTablesRegion4.SelectedItem = startingTableLayout.Region4.TableNumbers.ToString();
            this.ChooseCasinoRegion1.SelectedItem = startingTableLayout.Region1.Casino;
            this.ChooseCasinoRegion2.SelectedItem = startingTableLayout.Region2.Casino;
            this.ChooseCasinoRegion3.SelectedItem = startingTableLayout.Region3.Casino;
            this.ChooseCasinoRegion4.SelectedItem = startingTableLayout.Region4.Casino;
            setLevel.SetLevels(startingTableLayout.Region1.MinLevel, startingTableLayout.Region1.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);
            setLevel.SetLevels(startingTableLayout.Region2.MinLevel, startingTableLayout.Region2.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);
            setLevel.SetLevels(startingTableLayout.Region3.MinLevel, startingTableLayout.Region3.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);
            setLevel.SetLevels(startingTableLayout.Region4.MinLevel, startingTableLayout.Region4.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
        }

        public void InitLyaout(TableLayout o)
        {
            LevelRanges setLevel = new LevelRanges();
            int numbTablesReg1 = 0, numbTablesReg2 = 0, numbTablesReg3 = 0, numbTablesReg4 = 0;
            string casinoItemReg1 = string.Empty, minLevelReg1 = string.Empty, maxLevelReg1 = string.Empty, casinoItemReg2 = string.Empty, minLevelReg2 = string.Empty, maxLevelReg2 = string.Empty, casinoItemReg3 = string.Empty, minLevelReg3 = string.Empty, maxLevelReg3 = string.Empty, casinoItemReg4 = string.Empty, minLevelReg4 = string.Empty, maxLevelReg4 = string.Empty;
            this.ReadIntValue(this.NumbTablesRegion1, ref numbTablesReg1);
            this.ReadIntValue(this.NumbTablesRegion2, ref numbTablesReg2);
            this.ReadIntValue(this.NumbTablesRegion3, ref numbTablesReg3);
            this.ReadIntValue(this.NumbTablesRegion4, ref numbTablesReg4);
            this.ReadStringValue(this.ChooseCasinoRegion1, ref casinoItemReg1);
            this.ReadStringValue(this.ChooseCasinoRegion2, ref casinoItemReg2);
            this.ReadStringValue(this.ChooseCasinoRegion3, ref casinoItemReg3);
            this.ReadStringValue(this.ChooseCasinoRegion4, ref casinoItemReg4);
            if (this.MinimumLevelRegion1.Text == string.Empty)
            {
                this.MinimumLevelRegion1.Text = "NL2";
                this.ReadStringValue(this.MinimumLevelRegion1, ref minLevelReg1);
            }
            else
            {
                this.ReadStringValue(this.MinimumLevelRegion1, ref minLevelReg1);
            }

            if (this.MinimumLevelRegion2.Text == string.Empty)
            {
                this.MinimumLevelRegion2.Text = "NL2";
                this.ReadStringValue(this.MinimumLevelRegion2, ref minLevelReg2);
            }
            else
            {
                this.ReadStringValue(this.MinimumLevelRegion2, ref minLevelReg2);
            }

            if (this.MinimumLevelRegion3.Text == string.Empty)
            {
                this.MinimumLevelRegion3.Text = "NL2";
                this.ReadStringValue(this.MinimumLevelRegion3, ref minLevelReg3);
            }
            else
            {
                this.ReadStringValue(this.MinimumLevelRegion3, ref minLevelReg3);
            }

            if (this.MinimumLevelRegion4.Text == string.Empty)
            {
                this.MinimumLevelRegion4.Text = "NL2";
                this.ReadStringValue(this.MinimumLevelRegion4, ref minLevelReg4);
            }
            else
            {
                this.ReadStringValue(this.MinimumLevelRegion4, ref minLevelReg4);
            }

            if (this.MaximumLevelRegion1.Text == string.Empty)
            {
                this.MaximumLevelRegion1.Text = "NL2";
                this.ReadStringValuePlus(this.MaximumLevelRegion1, ref maxLevelReg1);
            }
            else
            {
                this.ReadStringValuePlus(this.MaximumLevelRegion1, ref maxLevelReg1);
            }

            if (this.MaximumLevelRegion2.Text == string.Empty)
            {
                this.MaximumLevelRegion2.Text = "NL2";
                this.ReadStringValuePlus(this.MaximumLevelRegion2, ref maxLevelReg2);
            }
            else
            {
                this.ReadStringValuePlus(this.MaximumLevelRegion2, ref maxLevelReg2);
            }

            if (this.MaximumLevelRegion3.Text == string.Empty)
            {
                this.MaximumLevelRegion3.Text = "NL2";
                this.ReadStringValuePlus(this.MaximumLevelRegion3, ref maxLevelReg3);
            }
            else
            {
                this.ReadStringValuePlus(this.MaximumLevelRegion3, ref maxLevelReg3);
            }

            if (this.MaximumLevelRegion4.Text == string.Empty)
            {
                this.MaximumLevelRegion4.Text = "NL2";
                this.ReadStringValuePlus(this.MaximumLevelRegion4, ref maxLevelReg4);
            }
            else
            {
                this.ReadStringValuePlus(this.MaximumLevelRegion4, ref maxLevelReg4);
            }

            o.Update_Regions(numbTablesReg1, casinoItemReg1, minLevelReg1, maxLevelReg1, numbTablesReg2, casinoItemReg2, minLevelReg2, maxLevelReg2, numbTablesReg3, casinoItemReg3, minLevelReg3, maxLevelReg3, numbTablesReg4, casinoItemReg4, minLevelReg4, maxLevelReg4);

            setLevel.SetLevels(o.Region1.MinLevel, o.Region1.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);

            setLevel.SetLevels(o.Region2.MinLevel, o.Region2.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);

            setLevel.SetLevels(o.Region3.MinLevel, o.Region3.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);

            setLevel.SetLevels(o.Region4.MinLevel, o.Region4.GetMaxLevel);
            setLevel.setItems();
            setLevel.LoadList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
        }

        public void CompareLevels(ComboBox minLevel, ComboBox maxLevel)
        {
            if (minLevel.SelectedIndex > maxLevel.SelectedIndex)
            {
                minLevel.SelectedIndex = 0;
                maxLevel.SelectedIndex = 1;
            }
        }

        private void ReadIntValue(ComboBox comboBox, ref int value)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                comboBox.SelectedIndex = 0;
            }
            else
            {
                value = int.Parse(comboBox.Text.ToString());
            }
        }

        private void ReadStringValue(ComboBox comboBox, ref string value)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                comboBox.SelectedIndex = 0;
            }
            else
            {
                value = comboBox.Text.ToString();
            }
        }

        private void ReadStringValuePlus(ComboBox comboBox, ref string value)
        {
            if (string.IsNullOrEmpty(comboBox.Text))
            {
                comboBox.SelectedIndex = 1;
            }
            else
            {
                value = comboBox.Text.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void MinimumLevelRegion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);
            range.LoadList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);
        }

        private void MinimumLevelRegion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);
            range.LoadList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);
        }

        private void MinimumLevelRegion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);
            range.LoadList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);
        }

        private void MinimumLevelRegion4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
            range.LoadList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
        }

        private void MaximumLevelRegion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);
            range.LoadList(this.MinimumLevelRegion1, this.MaximumLevelRegion1);
        }

        private void MaximumLevelRegion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);
            range.LoadList(this.MinimumLevelRegion2, this.MaximumLevelRegion2);
        }

        private void MaximumLevelRegion3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);
            range.LoadList(this.MinimumLevelRegion3, this.MaximumLevelRegion3);
        }

        private void MaximumLevelRegion4_SelectedIndexChanged(object sender, EventArgs e)
        {
            LevelRanges range = new LevelRanges();
            range.InitiateList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
            range.LoadList(this.MinimumLevelRegion4, this.MaximumLevelRegion4);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.WriteCurrentLayoutToFile();
            Thread.Sleep(500);
            this.Cursor = Cursors.Default;
            this.statusLabel1.Text = "Configuration is saved";
            this.statusStrip1.Refresh();
        }

        private void SaveFileToLocation_Click(object sender, EventArgs e)
        {
            this.statusLabel1.Text = string.Empty;
            this.statusStrip1.Refresh();
            this.SaveAs.ShowDialog();
        }

        private void SaveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.pathOfConfigurationFile = this.SaveAs.FileName.ToString();
            File.WriteAllText(RootOfConfigurationFile, this.pathOfConfigurationFile);
            File.Create(this.pathOfConfigurationFile).Close();
            this.WriteCurrentLayoutToFile();
            Thread.Sleep(100);
            this.Cursor = Cursors.Default;
            this.statusLabel1.Text = "Configuration is saved";
            this.statusStrip1.Refresh();
        }

        private void OpenFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.pathOfConfigurationFile = this.OpenFile.FileName.ToString();
            File.WriteAllText(RootOfConfigurationFile, this.pathOfConfigurationFile);
            this.WriteCurrentFileValuesToLayout(this.pathOfConfigurationFile);
            Thread.Sleep(100);
            this.Cursor = Cursors.Default;
            this.statusLabel1.Text = "Configuration is loaded";
            this.statusStrip1.Refresh();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            this.statusLabel1.Text = string.Empty;
            this.statusStrip1.Refresh();
            this.OpenFile.ShowDialog();
        }

        private void LoadTables_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Poker888WriteTables loadMicroPoker = new Poker888WriteTables();
            loadMicroPoker.Start(this.pathOfConfigurationFile);
            PartyNetworkWriteTables loadPartyPoker = new PartyNetworkWriteTables();
            loadPartyPoker.Start(this.pathOfConfigurationFile);
            Thread.Sleep(100);
            this.Cursor = Cursors.Default;
            this.statusLabel1.Text = "Tables are loaded";
            this.statusStrip1.Refresh();
        }
    }
}
