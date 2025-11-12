using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class CompetitionService: ISingleton
    {

        public readonly EXELexport _xlExporter;
        public readonly XMLReader _xmlReader;

        public Competition? CurrentCompetition = null;
        public CompetitionService(EXELexport xlExporter, XMLReader xmlReader) { 
        
            _xlExporter = xlExporter;
            _xmlReader = xmlReader;
            
        }

        public Competition GetCompetition()
        {
            CurrentCompetition = new Competition();
            if (_xmlReader.readDataXML(ref CurrentCompetition))
            {
                return CurrentCompetition;
            }
            CurrentCompetition = null;

            return CurrentCompetition;
        }

        public bool exportCompetition(ref Competition competition)
        {
             if(competition!=null)
            {
                CurrentCompetition = competition;
                return _xlExporter.ExportData(ref CurrentCompetition);

            }

            return false;

        }

    }
}
