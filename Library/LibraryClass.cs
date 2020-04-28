
using Library.Objects;
using System;

namespace Library
{
    public class LibraryClass
    {   //toevoegen
        public void VoegSpelerToe(Speler speler) { }
        public void VoegTeamToe(Team team) { }
        public void VoegTransferToe(Transfer transfer) { }

        //updaten
        public void UpdateSpeler(Speler speler) { }
        public void UpdateTeam(Team team) { }

        //selecteren
        public Speler SelecteerSpeler(int spelerID) { }
        public Team SelecteerTeam(int stamnummer) { }
        public Transfer SelecteerTransfer(int transferID) { }
    }
}
