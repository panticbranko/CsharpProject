namespace WindowsForms
{
    public class TableLayout
    {
        public TableLayout()
        {
            this.Region1 = new Region();
            this.Region2 = new Region();
            this.Region3 = new Region();
            this.Region4 = new Region();
        }

        public Region Region1 { get; set; }

        public Region Region2 { get; set; }

        public Region Region3 { get; set; }

        public Region Region4 { get; set; }

        public void Update_Regions(int numbTablesReg1, string casinoItemReg1, string minLevelReg1, string maxLevelReg1, int numbTablesReg2, string casinoItemReg2, string minLevelReg2, string maxLevelReg2, int numbTablesReg3, string casinoItemReg3, string minLevelReg3, string maxLevelReg3, int numbTablesReg4, string casinoItemReg4, string minLevelReg4, string maxLevelReg4)
        {
            this.Region1.UpdateRegion(numbTablesReg1, casinoItemReg1, minLevelReg1, maxLevelReg1);
            this.Region2.UpdateRegion(numbTablesReg2, casinoItemReg2, minLevelReg2, maxLevelReg2);
            this.Region3.UpdateRegion(numbTablesReg3, casinoItemReg3, minLevelReg3, maxLevelReg3);
            this.Region4.UpdateRegion(numbTablesReg4, casinoItemReg4, minLevelReg4, maxLevelReg4);
        }
    }
}
