using Library.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Objects
{
    public class Speler
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int spelerid { get; set; }
        public String naam { get; set; }
        public int rugnummer { get; set; }

        public int waarde { get; set; } //(geschatte transferwaarde).

        
        public Team team { get; set; }

        [Required]
        [ForeignKey("stamnummer")]
        public int teamId { get; set; }


        public Speler(string naam, int rugnummer, int waarde, int teamId)
        {
            this.naam = naam;
            this.rugnummer = rugnummer;
            this.waarde = waarde;
            this.teamId = teamId;
        }

        public Speler(string naam, int rugnummer, int waarde, Team team)
        {
            this.naam = naam;
            this.rugnummer = rugnummer;
            this.waarde = waarde;
            this.teamId = team.stamnummer;
            this.team = team;
        }

        public override string ToString()
        {
            return ("SpelerId: " + spelerid.ToString()) +
                (" , naam: " + naam) +
                (" , rugnummer: " + rugnummer.ToString()) +
                (" , waarde: " + waarde.ToString())+
                (" , teamnaam: " + team.naamClub);
        }
    }
}
