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
        public bool readDataXML (ref Competition? competition)
        {
    
            string path = getPath();
            if (path != null)
            {
                competition.Teams = new List<Team>();
                Team cTeam = new Team();
                Fisher cFisher = new Fisher();
                Tour cTour = new Tour();
                string byffer = "";
                bool first_tour = true;
                bool k = false;
                if (File.Exists(path))
                {
                    try
                    {

                        using (XmlReader reader = XmlReader.Create(path))
                        {
                            while (!reader.EOF)
                             {
                                if (!k)
                                    reader.Read();
                                if (reader.IsStartElement())
                                    switch (reader.Name.ToString())
                                {
                                    case "Tournament":

                                        string title1 = reader.GetAttribute("name");
                                        if (competition.Title == null)
                                            competition.Title = title1;
                                        continue;

                                    case "Description":

                                            byffer = reader.ReadElementContentAsString();
                                            competition.Description = byffer;
                                            k = true;
                                        continue;


                                    case "Team":
                                        string team_name = reader.GetAttribute("name");
                                        if (team_name != null)
                                        {
                                            int id = Convert.ToInt32(reader.GetAttribute("id"));
                                            cTeam = new Team(team_name);
                                            cTeam.id = id;
                                            competition.Teams.Add(cTeam);
                                        }
                                        k = false;
                                        continue;

                                    case "Fisher":
                                        string fisher_name = reader.GetAttribute("name");
                                        if (fisher_name != null)
                                        {
                                            cFisher = new Fisher(fisher_name);
                                            cFisher.TeamName = cTeam.Name;
                                            cTeam.Fishers.Add(cFisher);

                                        }

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
                                        cTour.Zone = reader.ReadElementContentAsString();
                                            k = true;
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
                                        k = false;
                                        continue;
                                }
                            }
                        }
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return false;
                    }
                }
            }
         
            return false;
        }
        
        public string getPath()
        {   
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {

                return openFileDialog.FileName;
            }
            return null;
        }
        #endregion
    }
}
