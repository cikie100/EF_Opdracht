
using Library.Objects;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library
{
    public class DatabankInitialiseer
    {
        string path = @"D:\Users\ciki3\Desktop\SCHOOL 19-20\Prog3\EF opgave\EF-Opgave\foot.csv";

        public LibraryClass lc = new LibraryClass();

        public void InitialiseerDatabank()
        {
            Dictionary<String, Speler> spelerDict = new Dictionary<string, Speler>();
            Dictionary<String, Team> teamDict = new Dictionary<string, Team>();
            //Dictionary<String, Transfer> transDict = new Dictionary<string, Transfer>(); //er zijn er geen
            
            List<Team> teamlist= new List<Team>();
            List<Speler> spelerlist = new List<Speler>();

            //de bestand oplezen en er een "List<Speler> spelerlist" uit ophalen
            using (StreamReader r = new StreamReader(path))
            {
                String line;

                String naam;
                String nummer;
                String club;
                String waarde;
                String stamnr;
                String trainer;
                r.ReadLine();
                while ((line = r.ReadLine()) != null)
                {
                    String[] ss = line.Split(',').Select(x => x.Trim()).ToArray();
                    naam = ss[0];
                    nummer = ss[1];
                    club = ss[2];
                    waarde = ss[3].Replace(" ", "");
                    stamnr = ss[4];
                    trainer = ss[5];
                    //voegt speler toe
                    Speler spelerx = new Speler(naam, Convert.ToInt32(nummer), Convert.ToInt32(waarde));
                    
                    
                    //voegt clubs toe
                    if (!teamDict.ContainsKey(club))
                    {
                        teamDict.Add(club, new Team(Convert.ToInt32(stamnr), trainer));
                        teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value.spelers.Add(spelerx);
                        spelerx.team = teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value;
                    }
                    else {
                        teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value.spelers.Add(spelerx);
                        spelerx.team = teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value;
                    }
                    spelerDict.Add(naam, spelerx);


                }

                foreach (KeyValuePair<string, Speler> entry in spelerDict) {
                    spelerlist.Add(entry.Value);
                                }
                foreach (KeyValuePair<string, Team> entry in teamDict)
                {
                    teamlist.Add(entry.Value);
                }
            }

            //naar databank schrijven
            using (VoetbalContext ctx = new VoetbalContext())
            {
                //NOTE: teams is blijkbaar niet nodig geweest sinds spelers al de teams al bevat
                // ctx.teams.AddRange(teamlist);
                ctx.spelers.AddRange(spelerlist);
                ctx.SaveChanges();

            }




        }
    }
}
