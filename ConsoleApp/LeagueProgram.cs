using Library;
using Library.Objects;
using System;

namespace ConsoleApp
{
    public class LeagueProgram 
    {
        static void Main(string[] args)
        {
            #region databank vullen
            //databank vullen met de csv.
            //  DatabankInitialiseer db = new DatabankInitialiseer();
            // db.InitialiseerDatabank();
            #endregion

            //Spelers gemaakt van de gegeven .csv bestand, heeft id's 9 tot 16 (8 spelers dus)
            //Bestaande stamnummers : 3, 7, 35
  
            LibraryClass voetbalLib = new LibraryClass();


            //nu zijn er 9 spelers
            #region spelerToevoegen test
            // Speler spelerNieuw = new Speler("Luc Vervoort", 99, 4000000, 7);
            // voetbalLib.VoegSpelerToe(spelerNieuw);
            // Speler spelerNieuwGeselecteerd = voetbalLib.SelecteerSpeler(17);
            #endregion

            #region teamToevoegen Test
            //Team nieuweTeam = new Team(16, "LeerkrachtenClub", "Tom VDW");
            // voetbalLib.VoegTeamToe(nieuweTeam);
            #endregion

            #region TransferToevoegen
            // Transfer trans = new Transfer(17, 50000000, 16);
            // voetbalLib.VoegTransferToe(trans);

            Transfer ToonTransfer = voetbalLib.SelecteerTransfer(1);
            #endregion


            Console.ReadLine();
        }

    
    }
}
