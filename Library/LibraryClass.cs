using Library.Objects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library
{
    public class LibraryClass 
    {

        private VoetbalContext ctx = new VoetbalContext();
  

        //toevoegen
        public void VoegSpelerToe(Speler speler) {
            //using (var transaction = ctx.Database.BeginTransaction())
            //{
           //     ctx.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.teams ON");
                ctx.spelers.Add(speler);
                ctx.SaveChanges();
            //}
        }
        public void VoegTeamToe(Team team) {
            ctx.teams.Add(team);
            ctx.SaveChanges();
                  }

        public void VoegTransferToe(Transfer transfer) {
            ctx.transfers.Add(transfer);
            ctx.SaveChanges();
        }

        //updaten ?
        /// <Volgensdeleerkracht>
        /// "In de opgave wordt er enkel gevraagd om een speler op te vragen op basis van zijn ID. 
        /// Ik weet niet in welke context het nodig is om een speler op te vragen als de id niet gekend is."
        public void UpdateSpeler(Speler speler) {
           
        }
       public void UpdateTeam(Team team) {
           
        }

        //selecteren
        public Speler SelecteerSpeler(int spelerID) {
            Speler speler = ctx.spelers.Where(s => s.spelerid == spelerID).FirstOrDefault();
          //  speler.team = SelecteerTeam(speler.teamId);

            return speler;

        }
        public Team SelecteerTeam(int stamnummer) {
            Team team = ctx.teams.Single(s => s.stamnummer == stamnummer);
            return team;
        }
        public Transfer SelecteerTransfer(int transferID) {
            Transfer transfer = ctx.transfers.Single(s => s.transferid == transferID);
            return transfer;
        }

        public void linkSpelerTeams() {

            using (VoetbalContext ctxx = new VoetbalContext()) { 
                foreach (Speler speler in ctxx.spelers)
            {
                speler.team = SelecteerTeam(speler.teamId);
                ctx.Update(speler);
            }
            }
        }
    }
}
