
using Microsoft.EntityFrameworkCore;
using Model.Objects;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class LeagueProgram 
    {
        List<Speler> spelers { get; set; }
        List<Team> teams { get; set; }
        List<Transfer> transfers { get; set; }

        

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
