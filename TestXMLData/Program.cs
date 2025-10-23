using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using TestXMLData.Models;
//using Microsoft.Win32;
//using System.Windows.Forms;

//OpenFileDialog openFileDialog = new OpenFileDialog();
//openFileDialog.Multiselect = true;
//openFileDialog.Filter = "Json files (*.json)|*.json";
//if (openFileDialog.ShowDialog() == true)
//{
//    UserModel.ClearAll();
//    SetInfoDays(openFileDialog.FileNames);
//}
string path = "competitions.xml";

Competition competition = new Competition();
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
                    if(byffer != "-")
                    {
                        cTour.Weight = Convert.ToDouble(byffer);

                    }
                    continue;


                case "Place":
                    byffer = reader.ReadElementContentAsString();
                    if (byffer != "-")
                    {
                        cTour.Place = Convert.ToInt16(byffer);

                    }
          
                    cFisher.Tours.Add(cTour);
                    first_tour = false;
                    continue;

            }

        }

    }

    foreach (var team in competition.teams)
    {
        Console.WriteLine(team.Name);
        foreach (var fisher in team.Fishers)
        {
            Console.WriteLine(fisher.FIO);
            for (int i = 0; i < fisher.Tours.Count; i++) {
                Console.WriteLine($"Тур {i}");
                Console.WriteLine($"Зона {fisher.Tours[i].Zone}");
                Console.WriteLine($"Вес {fisher.Tours[i].Weight}");
                Console.WriteLine($"Место {fisher.Tours[i].Place}");

                

            }

        }

    }
}


  