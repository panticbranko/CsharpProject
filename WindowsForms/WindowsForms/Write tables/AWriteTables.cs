using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WindowsForms
{
    public abstract class AWriteTables
    {
        public string upperLeftTablePosition, upperRightTablePosition, lowerLeftTablePosition, lowerRightTablePosition;
        public int upperLeftTablesNumber, upperRightTablesNumber, lowerLeftTablesNumber, lowerRightTablesNumber;

        public int StartingPoint(string filePath, string triger) // triger string is beging of the line after wich we should place table posistions
        {
            int lineCounter = 0;
            int start = 0;
            var file = new List<string>(File.ReadAllLines(filePath));
            foreach (var line in File.ReadAllLines(filePath))
            {
                lineCounter++;
                char tab = '\u0009';
                line.Replace(tab.ToString(), string.Empty);
                string test = line.Trim();
                if (test.StartsWith(triger))
                {
                    start = lineCounter;
                }
            }

            return start;
        }

        public void DeleteTables(string filePath)
        {
            File.Create(filePath).Close();
        }

        public void DeleteTables(string filePath, string triger) // trigher is beging of the string that we need to delete in text file
        {
            var file = new List<string>(File.ReadAllLines(filePath));
            int lineCounter = 0;
            foreach (var line in File.ReadAllLines(filePath))
            {
                char tab = '\u0009';
                line.Replace(tab.ToString(), string.Empty);
                string trimed = line.Trim();
                lineCounter++;
                if (trimed.StartsWith(triger))
                {
                    file.RemoveAt(lineCounter - 1);
                    lineCounter--;
                }
            }

            File.WriteAllLines(filePath, file.ToArray());
        }

        public void SetTablesNumberForTwoCasinos(string ConfigurationFile, string casino1, string casino2)
        {
            TableLayout currentLayout = new TableLayout();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jason = File.ReadAllText(ConfigurationFile);
            currentLayout = ser.Deserialize<TableLayout>(jason);
            if (currentLayout.Region1.Casino == casino1)
            {
                this.upperLeftTablesNumber = currentLayout.Region1.TableNumbers;
            }
            else if (currentLayout.Region1.Casino == casino2)
                {
                    this.upperLeftTablesNumber = currentLayout.Region1.TableNumbers;
                }
            else
            {
                this.upperLeftTablesNumber = 0;
            }

            if (currentLayout.Region2.Casino == casino1)
            {
                this.upperRightTablesNumber = currentLayout.Region2.TableNumbers;
            }
            else if (currentLayout.Region2.Casino == casino2)
            {
                this.upperRightTablesNumber = currentLayout.Region2.TableNumbers;
            }
            else
            {
                this.upperRightTablesNumber = 0;
            }

            if (currentLayout.Region3.Casino == casino1)
            {
                this.lowerLeftTablesNumber = currentLayout.Region3.TableNumbers;
            }
            else if (currentLayout.Region3.Casino == casino2)
            {
                this.lowerLeftTablesNumber = currentLayout.Region3.TableNumbers;
            }
            else
            {
                this.lowerLeftTablesNumber = 0;
            }

            if (currentLayout.Region4.Casino == casino1)
            {
                this.lowerRightTablesNumber = currentLayout.Region4.TableNumbers;
            }
            else if (currentLayout.Region4.Casino == casino2)
            {
                this.lowerRightTablesNumber = currentLayout.Region4.TableNumbers;
            }
            else
            {
                this.lowerRightTablesNumber = 0;
            }
        }

        public void SetTablesNumber(string configurationFile, string casino)
        {
            TableLayout currentLayout = new TableLayout();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            string jason = File.ReadAllText(configurationFile);
            currentLayout = ser.Deserialize<TableLayout>(jason);
            if (currentLayout.Region1.Casino == casino)
            {
                this.upperLeftTablesNumber = currentLayout.Region1.TableNumbers;
            }
            else
            {
                this.upperLeftTablesNumber = 0;
            }

            if (currentLayout.Region2.Casino == casino)
            {
                this.upperRightTablesNumber = currentLayout.Region2.TableNumbers;
            }
            else
            {
                this.upperRightTablesNumber = 0;
            }

            if (currentLayout.Region3.Casino == casino)
            {
                this.lowerLeftTablesNumber = currentLayout.Region3.TableNumbers;
            }
            else
            {
                this.lowerLeftTablesNumber = 0;
            }

            if (currentLayout.Region4.Casino == casino)
            {
                this.lowerRightTablesNumber = currentLayout.Region4.TableNumbers;
            }
            else
            {
                this.lowerRightTablesNumber = 0;
            }
        }

        public void AddTablesToText(string tablePosition, int tablesNumber, string configurationFile, int startingPosition)
        {
            var file = new List<string>(File.ReadAllLines(configurationFile));
            for (int i = 0; i < tablesNumber; i++)
            {
                file.Insert(startingPosition + i, tablePosition);
            }

            File.WriteAllLines(configurationFile, file.ToArray());
        }

        public void CompareAndSet(string casino, string filePath, int startPoint, TableLayout currentLayout)
        {
            if (this.upperLeftTablesNumber > 0)
            {
                this.AddTablesToText(this.upperLeftTablePosition, this.upperLeftTablesNumber, filePath, startPoint);
            }
            else if (currentLayout.Region1.Casino == casino)
            {
                this.upperLeftTablesNumber = currentLayout.Region1.TableNumbers;
                this.AddTablesToText(this.upperLeftTablePosition, this.upperLeftTablesNumber, filePath, startPoint);
            }

            if (this.upperRightTablesNumber > 0)
            {
                this.AddTablesToText(this.upperRightTablePosition, this.upperRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber);
            }
            else if (currentLayout.Region2.Casino == casino)
            {
                this.upperRightTablesNumber = currentLayout.Region1.TableNumbers;
                this.AddTablesToText(this.upperRightTablePosition, this.upperRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber);
            }

            if (this.lowerLeftTablesNumber > 0)
            {
                this.AddTablesToText(this.lowerLeftTablePosition, this.lowerLeftTablesNumber, filePath, startPoint + this.upperLeftTablesNumber + this.upperRightTablesNumber);
            }
            else if (currentLayout.Region2.Casino == casino)
            {
                this.lowerLeftTablesNumber = currentLayout.Region1.TableNumbers;
                this.AddTablesToText(this.upperRightTablePosition, this.lowerLeftTablesNumber, filePath, startPoint + this.upperLeftTablesNumber);
            }

            if (this.lowerRightTablesNumber > 0)
            {
                this.AddTablesToText(this.lowerRightTablePosition, this.lowerRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber + this.upperRightTablesNumber + this.lowerLeftTablesNumber);
            }
            else if (currentLayout.Region2.Casino == casino)
            {
                this.lowerRightTablesNumber = currentLayout.Region1.TableNumbers;
                this.AddTablesToText(this.upperRightTablePosition, this.lowerRightTablesNumber, filePath, startPoint + this.upperLeftTablesNumber);
            }
        }
    }
}
