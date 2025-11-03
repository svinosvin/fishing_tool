using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class EXELexport : ITransient
    {



        public void ExportData(ref Competition competition)
        {


            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Результаты");
            CreateHeader(ref sheet, competition);

            FileStream file = File.Create("CellsMerge.xlsx");
            workbook.Write(file, false);
            file.Close();

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

        }
        #endregion


    }


}