using Library.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class SpelerTeam
    {
        public SpelerTeam(Speler speler, Team team)
        {
            this.speler = speler;
            this.team = team;
        }

        public SpelerTeam(int spelerid, int stamnummer)
        {
            this.spelerid = spelerid;
            this.stamnummer = stamnummer;
        }

        public int spelerid { get; set; }
        public Speler speler { get; set; }

        public int stamnummer { get; set; }
        public Team team { get; set; }
    }
}
