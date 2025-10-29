using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class EXELexport : ITransient
    {
        
        public byte[] Generate(ref readonly Competition competition)
        {
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets
                .Add("Лист 1");
            sheet.Cells["A1"].Value = "ПРОТОКОЛ ТЕХНИЧЕСКИХ РЕЗУЛЬТАТОВ";
            sheet.Cells["A2"].Value = competition.Title;
            sheet.Cells["A3"].Value = competition.Description;



            return package.GetAsByteArray();
        }



    }
}
