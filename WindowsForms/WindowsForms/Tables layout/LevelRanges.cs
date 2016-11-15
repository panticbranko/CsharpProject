namespace WindowsForms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class LevelRanges
    {
        private enum Level
        {
            NL2, NL4, NL5, NL10, NL20, NL25, NL50, NL100, NL200
        }

        private List<string> minLevel;
        private List<string> maxLevel;
        private string currentMinLevel;
        private string currentMaxLevel;
        private int minLevelIndex;
        private int maxLevelIndex;

        public LevelRanges()
        {
            this.minLevel = new List<string>();
            this.maxLevel = new List<string>();
            this.currentMinLevel = string.Empty;
            this.currentMaxLevel = string.Empty;
            this.minLevelIndex = 0;
            this.maxLevelIndex = 0;
        }

        public void SetLevels(string minLevel, string maxLevel)
        {
            this.currentMaxLevel = maxLevel;
            this.currentMinLevel = minLevel;
        }

        public void setItems()
        {
            this.minLevel.Clear();
            this.maxLevel.Clear();
            foreach (Level level in Level.GetValues(typeof(Level)))
            {
                if (level.ToString() != this.currentMaxLevel)
                {
                    this.minLevel.Add(level.ToString());
                }
                else
                {
                    this.minLevel.Add(level.ToString());
                    break;
                }
            }

            foreach (Level level in Level.GetValues(typeof(Level)))
            {
                if (level.ToString() != this.currentMinLevel)
                {
                    this.maxLevel.Add(level.ToString());
                }
            }

            foreach (Level level in Level.GetValues(typeof(Level)))
            {
                if (level.ToString() != this.currentMinLevel)
                {
                    this.maxLevel.Remove(level.ToString());
                }
                else
                {
                    this.maxLevel.Insert(0, level.ToString());
                    break;
                }
            }
        }

        public void InitiateList(ComboBox minLevelCombo, ComboBox maxLevelCombo)
        {
            if (minLevelCombo.SelectedItem.ToString() == null)
            {
                if (minLevelCombo.Text == null)
                {
                    this.currentMinLevel = "NL2";
                }
                else
                {
                    this.currentMinLevel = minLevelCombo.Text;
                }
             }
            else
            {
                this.currentMinLevel = minLevelCombo.SelectedItem.ToString();
            }

            if (maxLevelCombo.SelectedItem.ToString() == null)
            {
                if (maxLevelCombo.Text == null)
                {
                    this.currentMaxLevel = "NL200";
                }
                else
                {
                    this.currentMaxLevel = maxLevelCombo.Text;
                }
            }
            else
            {
                this.currentMaxLevel = maxLevelCombo.SelectedItem.ToString();
            }

            this.setItems();
        }

       public void LoadList(ComboBox minLevelBox, ComboBox maxLevelBox)
        {
            minLevelBox.DataSource = this.minLevel.ToList();
            maxLevelBox.DataSource = this.maxLevel.ToList();
            this.minLevelIndex = this.minLevel.IndexOf(this.currentMinLevel);
            minLevelBox.SelectedIndex = this.minLevelIndex;
            this.maxLevelIndex = this.maxLevel.IndexOf(this.currentMaxLevel);
            maxLevelBox.SelectedIndex = this.maxLevelIndex;
        }
    }
}
