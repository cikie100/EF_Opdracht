using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Objects
{
    public class Transfer
    {
        public int transferid { get; set; }
        public Speler speler { get; set; }
        public int spelerID { get; set; }
        public int transferPrijs { get; set; }
        public Team oude_team { get; set; }
        public int oude_teamID { get; set; }
        public Team nieuwe_team { get; set; }
        public int nieuwe_teamID { get; set; }

        public Transfer(Speler speler, int transferPrijs, Team nieuwe_team)
        {
            this.speler = speler;
            this.transferPrijs = transferPrijs;
            this.oude_team = speler.team;
            this.nieuwe_team = nieuwe_team;
        }

        public Transfer(int spelerID, int transferPrijs, int oude_teamID, int nieuwe_teamID)
        {
            this.spelerID = spelerID;
            this.transferPrijs = transferPrijs;
            this.oude_teamID = oude_teamID;
            this.nieuwe_teamID = nieuwe_teamID;
        }
    }
}
