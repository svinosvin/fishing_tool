using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class XMLReader : ITransient
    {
        #region data_parser    
        public static bool readDataXML (ref Competition competition)
        {
    
            string path = getPath();
            competition.teams = new List<Team>();
            Team cTeam = new Team();
            Fisher cFisher = new Fisher();
            Tour cTour = new Tour();
            string byffer = "";
            bool first_tour = true;

            if (File.Exists(path))
            {
                using (XmlReader reader = XmlReader.Create(path))
                {
                    while (reader.Read())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "Tournament":
                                string title = reader.GetAttribute("name");
                                continue;
                           
                            case "Description":
                                string description = reader.Value;
                                continue;


                            case "Team":
                                string team_name = reader.GetAttribute("name");
                                Console.WriteLine(team_name);
                                cTeam = new Team(team_name);
                                competition.teams.Add(cTeam);
                                continue;
                            case "Fisher":
                                string fisher_name = reader.GetAttribute("name");
                                cFisher = new Fisher(fisher_name);
                                cTeam.Fishers.Add(cFisher);
                                continue;

                            case "Tour1":
                                cTour = new Tour();
                                first_tour = true;
                                continue;

                            case "Tour2":
                                cTour = new Tour();
                                first_tour = false;
                                continue;

                            case "Zone":
                                cTour.Zone = reader.Value;
                                continue;

                            case "Weight":
                                byffer = reader.ReadElementContentAsString();
                                if (byffer != "-")
                                    cTour.Weight = Convert.ToDouble(byffer);

                                continue;

                            case "Place":
                                byffer = reader.ReadElementContentAsString();
                                if (byffer != "-")
                                    cTour.Place = Convert.ToInt16(byffer);

                                cFisher.Tours.Add(cTour);
                                first_tour = false;
                                continue;

                        }

                    }

                }
            }

            return false;
        }
        
        public static string getPath()
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {

                return openFileDialog.FileName;
            }
            return "";
        }
        #endregion
    }
}
