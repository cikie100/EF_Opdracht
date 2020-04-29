using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Objects
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stamnummer { get; set; } //geen automatisch uniek id
        public String naamTrainer { get; set; }
        public List<Speler> spelers { get; set; } = new List<Speler>();



        public Team(int stamnummer, string naamTrainer)
        {
            this.stamnummer = stamnummer;
            this.naamTrainer = naamTrainer;
        }

        public void VoegSpelerToe(Speler speler) {
            spelers.Add(speler);
        }
    }
}
