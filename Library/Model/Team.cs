using Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Library.Objects
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int stamnummer { get; set; } //geen automatisch uniek id
        public String naamClub { get; set; }
        public String naamTrainer { get; set; }
        public ICollection<Speler> spelers { get; set; } = new List<Speler>();
        



        public Team(int stamnummer, string naamClub, string naamTrainer)
        {
            this.naamClub = naamClub;
            this.stamnummer = stamnummer;
            this.naamTrainer = naamTrainer;
        }
        public Team(int stamnummer, string naamClub, string naamTrainer, List<Speler> spelers)
        {
            this.naamClub = naamClub;
            this.stamnummer = stamnummer;
            this.naamTrainer = naamTrainer;
            this.spelers = spelers;
        }


        public void VoegSpelerToe(Speler speler) {
            spelers.Add(speler);
        }

        public override string ToString()
        {
            String namen="";

            List<String> x = spelers.Select(s => s.naam.ToString()).ToList();
            x.ForEach(xx => namen = namen + "\n\t *" +xx);

            return ("team: " + naamClub) +
                 (" , stamnummer: " + stamnummer.ToString()) +
                 (" , naamTrainer: " + naamTrainer) +
                 (" , heeft spelers: " + spelers.Count.ToString()) + namen;


                 ;
        }
    }
}
