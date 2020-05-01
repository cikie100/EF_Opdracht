using Library.Objects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Library
{
    public class LibraryClass 
    {

        private VoetbalContext ctx = new VoetbalContext();
        public LibraryClass()
        {
            //geeft alle spelers hun team object
            // anders blijft speler geen team hebben en team geen spelers?
            //de originele db.InitialiseerDatabank() context had die wel maar gaf die niet door
            linkSpelerTeams();
        }


        //toevoegen
        public void VoegSpelerToe(Speler speler) {
                //geeft het een team object
                UpdateSpeler(speler);
                ctx.spelers.Add(speler);
                
                ctx.SaveChanges();
        }

        public void VoegTeamToe(Team team) {
            ctx.teams.Add(team);
            ctx.SaveChanges();
                  }

        public void VoegTransferToe(Transfer transfer) {
            
            Speler speler = ctx.spelers.Where(s => s.spelerid == transfer.spelerID).FirstOrDefault();
            //Geef speler object
            transfer.speler = speler;
            //Geef (oude) team object mee
            transfer.oude_team = speler.team;

            //Geef speler de nieuwe teamID
            ctx.spelers.Where(s => s.spelerid == transfer.spelerID).FirstOrDefault().teamId = transfer.nieuwe_teamID;
            UpdateSpeler(speler);
            ////Geef (nieuwe) team object mee
            transfer.nieuwe_team = speler.team;

            //verwijder speler uit de oude team
            ctx.teams.Where(t => t.stamnummer == transfer.oude_team.stamnummer).FirstOrDefault().spelers.Remove(speler);
            //voeg speler toe aan de nieuwe team
            ctx.teams.Where(t => t.stamnummer == transfer.nieuwe_team.stamnummer).FirstOrDefault().spelers.Add(speler);

            ctx.transfers.Add(transfer);
            ctx.SaveChanges();
        }

        //updaten 
       public void UpdateSpeler(Speler speler) {
            //Geef speler team object
            speler.team = SelecteerTeam(speler.teamId);
            ctx.Update(speler);
        }
       public void UpdateTeam(Team team) {
                  }

        //selecteren
        public Speler SelecteerSpeler(int spelerID) {
            Speler speler = ctx.spelers.Where(s => s.spelerid == spelerID).FirstOrDefault();
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
            //geeft alle spelers hun team object
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
