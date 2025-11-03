
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
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





 void readXml()
{
    string path = "competitions.xml";

    Competition competition = new Competition();
    competition.Teams = new List<Team>();
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
                        
                        string title1 = reader.GetAttribute("name");
                        if(competition.Title == null)                       
                             competition.Title = title1;
                        continue;

                    case "Description":
                        string description1 = reader.ReadElementContentAsString();
                        competition.Description = description1;

                        continue;


                    case "Team":
                        string team_name = reader.GetAttribute("name");
                        int id = Convert.ToInt32(reader.GetAttribute("id"));
                        cTeam = new Team(team_name);
                        competition.Teams.Add(cTeam);
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



        //var sheet = package.Workbook.Worksheets
        //    .Add("Лист 1");
        //sheet.Cells["A1"].Value = "ПРОТОКОЛ ТЕХНИЧЕСКИХ РЕЗУЛЬТАТОВ";
        //sheet.Cells["A2"].Value = competition.Title;
        //sheet.Cells["A3"].Value = competition.Description;


        IWorkbook workbook = new XSSFWorkbook();
        ISheet sheet = workbook.CreateSheet("Результаты");
        #region header  
        IRow protocol = sheet.CreateRow(0);
        IRow title = sheet.CreateRow(1);
        IRow description = sheet.CreateRow(2);
        protocol.CreateCell(0).SetCellValue("ПРОТОКОЛ ТЕХНИЧЕСКИХ РЕЗУЛЬТАТОВ");
        title.CreateCell(0).SetCellValue(competition.Title);
        description.CreateCell(0).SetCellValue(competition.Description);

        IRow header = sheet.CreateRow(5);
        IRow subheader = sheet.CreateRow(6);

        header.CreateCell(0).SetCellValue("#");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 0, 0)); //номер

        header.CreateCell(1).SetCellValue("Команда");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 1, 1));//команда

        header.CreateCell(2).SetCellValue("Участник");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 2, 2));//участник

        header.CreateCell(3).SetCellValue("Первый тур");

        subheader.CreateCell(3).SetCellValue("Зона");
        subheader.CreateCell(4).SetCellValue("Вес");
        subheader.CreateCell(5).SetCellValue("Место");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 3, 5));//Первый тур


        subheader.CreateCell(6).SetCellValue("Зона");
        subheader.CreateCell(7).SetCellValue("Вес");
        subheader.CreateCell(8).SetCellValue("Место");
        header.CreateCell(6).SetCellValue("Второй тур");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 6, 8));//Второй тур


        subheader.CreateCell(9).SetCellValue("Сумма баллов");
        subheader.CreateCell(10).SetCellValue("Сумма мест");
        subheader.CreateCell(11).SetCellValue("Место");
        header.CreateCell(9).SetCellValue("Личный зачет");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 9, 11));//Личный зачет

        subheader.CreateCell(12).SetCellValue("Сумма баллов");
        subheader.CreateCell(13).SetCellValue("Сумма мест");
        subheader.CreateCell(14).SetCellValue("Место");
        header.CreateCell(12).SetCellValue("Командый зачет");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 12, 14));//Командый зачет

        FileStream file = File.Create("CellsMerge.xlsx");
        workbook.Write(file, false);
        file.Close();


        #endregion

        foreach (var team in competition.Teams)
        {   

           
            foreach (var fisher in team.Fishers)
            {
                Console.WriteLine(fisher.FIO);
                for (int i = 0; i < fisher.Tours.Count; i++)
                {
                    Console.WriteLine($"Тур {i}");
                    Console.WriteLine($"Зона {fisher.Tours[i].Zone}");
                    Console.WriteLine($"Вес {fisher.Tours[i].Weight}");
                    Console.WriteLine($"Место {fisher.Tours[i].Place}");
                }

            }

        }



    }
}


readXml();


