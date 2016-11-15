using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    class LevelItems
    {
        readonly string[] itemsRange = { "NL2", "NL4", "NL5", "NL10", "NL25", "NL50", "NL100", "NL200" };
        string[] currentMinRange;
        string[] currentMaxRange;
        public LevelItems()
        {
            this.currentMinRange = new string[8]
        {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty ,
            string.Empty ,
            string.Empty
        };
            this.currentMaxRange = new string[8]
            {
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty ,
            string.Empty ,
            string.Empty
            };

        }
        public void initCurrentRange(ComboBox currentComboBox)
        {
            int i,indexValue = currentComboBox.SelectedIndex;
            for (i = 0; i < indexValue; i++)
            {
                this.currentMinRange[i] = this.itemsRange[i];
            }
            for (i = 0; i == (7 - indexValue); i++)
            {
                this.currentMaxRange[i] = this.itemsRange[(7 - indexValue + i)]; 
            }
        }
        public void setCurrentRange(ComboBox minLevel, ComboBox maxLevel)
        {
            minLevel.DataSource = this.currentMinRange;
            maxLevel.DataSource = this.currentMaxRange;
        }
    }
}
