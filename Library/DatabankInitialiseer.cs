
using Library.Model;
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

        public void InitialiseerDatabank()
        {
            Dictionary<String, Speler> spelerDict = new Dictionary<string, Speler>();
            Dictionary<String, Team> teamDict = new Dictionary<string, Team>();
            //HashSet<Team> 

            List<Team> teamlist= new List<Team>();
            List<Speler> spelerlist = new List<Speler>();
            HashSet<SpelerTeam> spelerTeamsSet = new HashSet<SpelerTeam>();

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
                    Speler spelerx = new Speler(naam, Convert.ToInt32(nummer), Convert.ToInt32(waarde), Convert.ToInt32(stamnr));
                    
                    
                    //voegt clubs toe
                    if (!teamDict.ContainsKey(club))
                    {
                        teamDict.Add(club, new Team(Convert.ToInt32(stamnr), club, trainer));
                        teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value.spelers.Add(spelerx);
                        spelerx.team = teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value;

                      
                    }
                    else {
                        teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value.spelers.Add(spelerx);
                        spelerx.team = teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value;
                    }
                    spelerDict.Add(naam, spelerx);


                    SpelerTeam st = new SpelerTeam(spelerx, teamDict.Where(t => t.Key.Equals(club)).FirstOrDefault().Value);
                    spelerTeamsSet.Add(st);

                }


                foreach (KeyValuePair<string, Speler> entry in spelerDict)
                {
                    spelerlist.Add(entry.Value);
                }
                foreach (KeyValuePair<string, Team> entry in teamDict)
                {
                    teamlist.Add(entry.Value);
                }
            }

            //naar databank schrijven
            using (var ctx = new VoetbalContext())
            {
                //NOTE: teams is blijkbaar niet nodig geweest sinds spelers al de teams al bevat
                // ctx.teams.AddRange(teamlist);
                foreach (Team te in teamlist)
                {
                    LibraryClass lc = new LibraryClass();
                    
                    lc.VoegTeamToe(te);
                }

                ////ctx.spelers.AttachRange(spelerlist);
                foreach (Speler speler in spelerlist)
                {
                    speler.spelerid = spelerlist.IndexOf(speler)+1;
                    speler.team = ctx.teams.Find(speler.teamId);
                    speler.teamId = speler.team.stamnummer;
                    ctx.SaveChanges();
                }
                //ctx.spelers.AttachRange(spelerlist);
              //


            }


            LibraryClass voetbalLib = new LibraryClass();
            voetbalLib.linkSpelerTeams();


        }
    }
}
