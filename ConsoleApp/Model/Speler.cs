using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Objects
{
    public class Speler
    {
        public int spelerid { get; set; }
        public String naam { get; set; }
        public int rugnummer { get; set; }
        public int waarde { get; set; } //(geschatte transferwaarde).
        public Team team { get; set; } 

        public Speler(string naam, int rugnummer, int waarde)
        {
            this.naam = naam;
            this.rugnummer = rugnummer;
            this.waarde = waarde;
        }
    }
}
