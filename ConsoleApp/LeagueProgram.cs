using Library;
using System;

namespace ConsoleApp
{
    public class LeagueProgram 
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DatabankInitialiseer db = new DatabankInitialiseer();
            db.InitialiseerDatabank();

            Console.ReadLine();
        }
    }
}
