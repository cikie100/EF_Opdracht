using LeagueApp.Migrations;
using Library.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Library
{
    public class DatabankInitialiseer
    {
        string path = @"D:\Users\ciki3\Desktop\SCHOOL 19-20\Prog3\EF opgave\EF-Opgave\foot.csv";
        
        public void InitialiseerDatabank() {
            Dictionary<String, Speler> spelerDict = new Dictionary<string, Speler>();
            Dictionary<String, Team> teamDict = new Dictionary<string, Team>();
            Dictionary<String, Transfer> transDict = new Dictionary<string, Transfer>();

            using (StreamReader r = new StreamReader(path)) {
                String line; 
                
                String naam;
                  String nummer;
                       String club;    
                          String waarde; 
                             String stamnr;
                                String trainer;
                r.ReadLine();
                while ((line = r.ReadLine()) != null) {
                    String[] ss = line.Split(',').Select(x => x.Trim()).ToArray();
                    naam = ss[0];
                    nummer = ss[1];
                    club = ss[2];
                    waarde = ss[3].Replace(" ","");
                    stamnr = ss[4];
                    trainer = ss[5];

                    spelerDict.Add(naam, new Speler(naam,Convert.ToInt32(nummer), Convert.ToInt32(waarde)));
                }

            
            
            }
        }
    }
}
