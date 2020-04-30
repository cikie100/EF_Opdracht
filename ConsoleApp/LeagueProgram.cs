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

            //Spelerid is gemaakt van de gegeven .csv bestand, heeft id's 9 tot 16 (8 spelers dus)
            //Bestaande stamnummers : 3, 7, 35
  


            LibraryClass voetbalLib = new LibraryClass();
            //anders blijft speler geen team hebben en team geen spelers?
            //de db.InitialiseerDatabank() context had die wel maar gaf die niet door?
            voetbalLib.linkSpelerTeams();
             
            
           // Console.WriteLine( voetbalLib.SelecteerSpeler(9).ToString());
            Console.WriteLine(voetbalLib.SelecteerTeam(7).ToString());






            Console.ReadLine();
        }

    
    }
}
