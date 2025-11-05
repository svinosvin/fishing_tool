
using MathNet.Numerics.Distributions;
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
                        if(team_name != null)
                        {
                            int id = Convert.ToInt32(reader.GetAttribute("id"));
                            cTeam = new Team(team_name);
                            cTeam.id = id;
                            competition.Teams.Add(cTeam);
                        }
                      
                        continue;

                    case "Fisher":
                        string fisher_name = reader.GetAttribute("name");
                        if (fisher_name != null) 
                        {
                            cFisher = new Fisher(fisher_name);
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
        //#region styles
        //style.BorderTop = BorderStyle.Thick;

        //style.TopBorderColor = 256;

        //style.BorderLeft = BorderStyle.Thick;

        //style.LeftBorderColor = 256;

        //style.BorderRight = BorderStyle.Thick;

        //style.RightBorderColor = 256;

        //style.BorderBottom = BorderStyle.Thick;

        //style.BottomBorderColor = 256;
        //foreach (var item in header.Cells)
        //{
        //    item.CellStyle = style;
        //}
        //foreach (var item in subheader.Cells)
        //{
        //    item.CellStyle = style;
        //}

        //#endregion



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
        ICellStyle style = workbook.CreateCellStyle();


        header.CreateCell(0).SetCellValue("#");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 0, 0)); //номер

        header.CreateCell(1).SetCellValue("Команда");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 1, 1));//команда

        header.CreateCell(2).SetCellValue("Участник");
        sheet.AddMergedRegion(new CellRangeAddress(5, 6, 2, 2));//участник

        header.CreateCell(3).SetCellValue("Первый тур");

        subheader.CreateCell(3).SetCellValue("Зона");
        subheader.CreateCell(4).SetCellValue("Вес");
        subheader.CreateCell(5).SetCellValue("Место на водоеме");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 3, 5));//Первый тур


        subheader.CreateCell(6).SetCellValue("Зона");
        subheader.CreateCell(7).SetCellValue("Вес");
        subheader.CreateCell(8).SetCellValue("Место на водоеме");
        header.CreateCell(6).SetCellValue("Второй тур");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 6, 8));//Второй тур


        subheader.CreateCell(9).SetCellValue("Сумма баллов");
        subheader.CreateCell(10).SetCellValue("Место");
        header.CreateCell(9).SetCellValue("Личный зачет");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 9, 10));//Личный зачет

        subheader.CreateCell(11).SetCellValue("Сумма баллов");
        subheader.CreateCell(12).SetCellValue("Место");
        header.CreateCell(12).SetCellValue("Командый зачет");
        sheet.AddMergedRegion(new CellRangeAddress(5, 5, 11, 12));//Командый зачет
   

        #endregion

        int firstRow = 7;
        int lastRow = 7;

        List<Team> teams = competition.resultTable().ToList();

        for (int i = 0; i < teams.Count; i++)
        {
            firstRow = lastRow;
            List<Fisher> f = teams[i].resultTable();
            for (int j = 0; j < f.Count; j++)
            {
                IRow row = sheet.CreateRow(lastRow);
                if (firstRow == lastRow)
                {
                    row.CreateCell(0).SetCellValue(teams[i].id);
                    row.CreateCell(1).SetCellValue(teams[i].Name);

                    row.CreateCell(11).SetCellValue(teams[i].TeamScore);
                    row.CreateCell(12).SetCellValue(i + 1);

                }
                row.CreateCell(2).SetCellValue(f[j].FIO);
                int currentRow = 3;

                for (int k = 0; k < f[j].Tours.Count; k++)
                {

                    row.CreateCell(currentRow).SetCellValue(f[j].Tours[k].Zone); currentRow++;
                    row.CreateCell(currentRow).SetCellValue(f[j].Tours[k].Weight ?? 0); currentRow++;
                    row.CreateCell(currentRow).SetCellValue(f[j].Tours[k].Place ?? 0); currentRow++;
                }

                row.CreateCell(currentRow).SetCellValue(f[j].Score); currentRow++; // Сумма баллов конкретного фишера
                row.CreateCell(currentRow).SetCellValue(j); currentRow++; //
                if (j != f.Count - 1)
                    lastRow++;

              
            }

            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, 0, 0));//Номер
            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, 1, 1));//Команда
            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, 11, 11));//Сумма баллов
            sheet.AddMergedRegion(new CellRangeAddress(firstRow, lastRow, 12, 12));//Место
            lastRow += 1;
        }
        //foreach (var team in teams)
        //{
                     
        //    for (var fisher in team.Fish)
        //    {
             
        //        Console.WriteLine(fisher.FIO);
        //        for (int i = 0; i < fisher.Tours.Count; i++)
        //        {
        //            Console.WriteLine($"Тур {i}");
        //            Console.WriteLine($"Зона {fisher.Tours[i].Zone}");
        //            Console.WriteLine($"Вес {fisher.Tours[i].Weight}");
        //            Console.WriteLine($"Место {fisher.Tours[i].Place}");
        //        }
        //        lastRow++;
        //    }

        //}


        FileStream file = File.Create("CellsMerge.xlsx");
        workbook.Write(file, false);
        file.Close();

    }
}


readXml();


