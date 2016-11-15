using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WindowsForms
{
    public class Poker888WriteTables : AWriteTables
    {
        public Poker888WriteTables()
        {
            this.upperLeftTablePosition = "<WindowPlacement>0;8;30;690;467</WindowPlacement>";
            this.upperRightTablePosition = "<WindowPlacement>0;714;30;690;467</WindowPlacement>";
            this.lowerLeftTablePosition = "<WindowPlacement>0;8;535;690;467</WindowPlacement";
            this.lowerRightTablePosition = "<WindowPlacement>0;714;535;690;467</WindowPlacement>";
            this.upperLeftTablesNumber = 0;
            this.upperRightTablesNumber = 0;
            this.lowerLeftTablesNumber = 0;
            this.lowerRightTablesNumber = 0;
        }

        public void InsertTables(string filePath, string rootFilePath) // rootFilePath is configuration file for tableLayout
        {
            string casino = "888Poker";
            string trigerDelete = "<WindowPlacement>";
            string trigerStart = "<Layout";
            this.SetTablesNumber(rootFilePath, casino);
            this.DeleteTables(filePath, trigerDelete);
            int startPoint = this.StartingPoint(filePath,trigerStart);
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
            string userSettingsConfiguration = @"c:\\Nenad\UserSettings.txt";
            string nullConfiguration = "<WindowsLayouts>\n\t\t<Layout typename=\"Table\" type=\"2\">\n\t\t</Layout>\n</WindowsLayouts>";
            Poker888WriteTables tester = new Poker888WriteTables();
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
