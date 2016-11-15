using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WindowsForms
{
    class PartyNetworkWriteTables : AWriteTables
    {
        public PartyNetworkWriteTables()
        {
            this.upperLeftTablePosition = "Table, 0#0#708#504";
            this.upperRightTablePosition = "Table, 708#0#708#504";
            this.lowerLeftTablePosition = "Table, 0#505#708#504";
            this.lowerRightTablePosition = "Table, 708#505#708#504";
            this.upperLeftTablesNumber = 0;
            this.upperRightTablesNumber = 0;
            this.lowerLeftTablesNumber = 0;
            this.lowerRightTablesNumber = 0;
        }

        public void InsertTables(string filePath, string rootFilePath) // rootFilePath is configuration file for tableLayout
        {
            string casino = "Party Poker";
            string casino1 = "Bwin";
            string trigerStart = string.Empty;
            this.SetTablesNumberForTwoCasinos(rootFilePath, casino, casino1);
            this.DeleteTables(filePath);
            int startPoint = this.StartingPoint(filePath, trigerStart);
            if (this.upperLeftTablesNumber > 0)
            {
                this.AddTablesToText(this.upperLeftTablePosition, this.upperLeftTablesNumber, filePath, startPoint);
            }

            if (this.upperRightTablesNumber > 0)
            {
                this.AddTablesToText(this.upperRightTablePosition, this.upperRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber);
            }

            if (this.lowerLeftTablesNumber > 0)
            {
                this.AddTablesToText(this.lowerLeftTablePosition, this.lowerLeftTablesNumber, filePath, startPoint + this.upperLeftTablesNumber + this.upperRightTablesNumber);
            }

            if (this.lowerRightTablesNumber > 0)
            {
                this.AddTablesToText(this.lowerRightTablePosition, this.lowerRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber + this.upperRightTablesNumber + this.lowerLeftTablesNumber);
            }
        }

        public void Start(string insertPathOfConfigurationFile)
        {
            string userSettingsConfiguration = @"c:\\Nenad\TablePositions.txt";
            string nullConfiguration = string.Empty;
            PartyNetworkWriteTables tester = new PartyNetworkWriteTables();
            if (!File.Exists(userSettingsConfiguration))
            {
                File.Create(userSettingsConfiguration).Close();
                File.WriteAllText(userSettingsConfiguration, nullConfiguration);
                tester.InsertTables(userSettingsConfiguration, insertPathOfConfigurationFile);
            }
            else
            {
                tester.InsertTables(userSettingsConfiguration, insertPathOfConfigurationFile);
            }
        }
    }
}
