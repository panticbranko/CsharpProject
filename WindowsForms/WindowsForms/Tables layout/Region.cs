namespace WindowsForms
{
    public class Region
    {
        private string minLevel = string.Empty;
        private string maxLevel = string.Empty;
        private string casino = string.Empty;
        private int tableNumbers = 0;

        public Region()
        {
            this.minLevel = "NL2";
            this.maxLevel = "NL4";
            this.casino = "Party Poker";
            this.tableNumbers = 1;
        }

        public Region(int numbTables, string casinoItem, string minimumLevel, string maximumLevel)
        {
            this.tableNumbers = numbTables;
            this.casino = casinoItem;
            this.minLevel = minimumLevel;
            this.maxLevel = maximumLevel;
        }

        public string MinLevel
        {
            get { return this.minLevel; }
            set { this.minLevel = value; }
        }

        public string GetMaxLevel
        {
            get { return this.maxLevel; }
            set { this.maxLevel = value; }
        }

        public string Casino
        {
            get { return this.casino; }
            set { this.casino = value; }
        }

        public int TableNumbers
        {
            get { return this.tableNumbers; }
            set { this.tableNumbers = value; }
        }

        public void UpdateRegion(int numbTables, string casinoItem, string minimumLevel, string maximumLevel)
        {
            this.tableNumbers = numbTables;
            this.Casino = casinoItem;
            this.minLevel = minimumLevel;
            this.maxLevel = maximumLevel;
        }
    }
}
