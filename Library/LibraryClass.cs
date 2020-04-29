using Library.Objects;
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
        public void UpdateSpeler(Speler speler) { }
        public void UpdateTeam(Team team) { }

        //selecteren
        public Speler SelecteerSpeler(int spelerID) {
            Speler speler = ctx.spelers.Single(s => s.spelerid == spelerID);
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
    }
}
