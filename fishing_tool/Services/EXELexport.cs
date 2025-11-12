using MathNet.Numerics.Distributions;
using Microsoft.Win32;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class EXELexport : ITransient
    {

        //protected List<IRow> rows = new List<IRow>();

        public bool ExportData(ref Competition competition)
        {

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Результаты");
            CreateHeader(ref sheet, competition);

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




            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook(*.xlsx)| *.xlsx | Excel 97 - 2003 Workbook(*.xls) | *.xls | CSV(Comma delimited)(*.csv) | *.csv | All Files(*.*) | *.* ";
            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    workbook.Write(fs, false);
                    return true;
                }
            }
            return false;
        }
        #region header  

        public void CreateHeader(ref ISheet sheet, Competition competition)
        {
          


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


        }
        #endregion

        protected void CellsStyler(ref List<IRow> rows)
        {

        }
    }


}