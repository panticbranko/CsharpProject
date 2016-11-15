using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class CasinoAndTables
    {
        string poker888 = "888Poker";
        List<string> casinoList = new List<string>();
        List<string> numberOfTablesList = new List<string>();

        public enum Casino { [Description("Party Poker")]Partypoker, [Description("888Poker")]Poker, [Description("Bwin")]Bwin, [Description("Chico")]Chico, [Description("Microgaming")]Microgaming }

        public enum NumberOfTables { [Description("0")]_0, [Description("1")]_1, [Description("2")]_2, [Description("3")]_3, [Description("4")]_4, [Description("5")]_5, [Description("6")]_6, [Description("7")]_7, [Description("8")]_8, [Description("9")]_9, [Description("10")]_10, [Description("11")]_11, [Description("12")]_12, [Description("13")]_13, [Description("14")]_14, [Description("15")]_15, [Description("16")]_16, [Description("17")]_17, [Description("18")]_18, [Description("19")]_19, [Description("20")]_20 }

        public CasinoAndTables()
        {
            this.SetCasinoList();
            this.SetNumberOfTablesList();
        }

        public void pushNumberList(ComboBox combobox)
        {
            combobox.DataSource = this.numberOfTablesList;
        }

        public void pushCasinoList(ComboBox combobox)
        {
            combobox.DataSource = this.casinoList;
        }

        private string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        private void SetCasinoList()
        {
            foreach (Casino casino in Casino.GetValues(typeof(Casino)))
            {
                this.casinoList.Add(this.GetEnumDescription(casino));
            }
        }

        private void SetNumberOfTablesList()
        {
            foreach (NumberOfTables number in NumberOfTables.GetValues(typeof(NumberOfTables)))
            {
                this.numberOfTablesList.Add(this.GetEnumDescription(number));
            }
        }
    }
}
