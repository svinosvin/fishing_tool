using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXMLData.Models;

namespace fishing_tool.Services
{
    public class CompetitionService: ISingleton
    {

        public readonly EXELexport _xlExporter;
        public readonly XMLReader _xmlReaderl;
        public Competition CurrentCompetition { get; set; }
        public CompetitionService(EXELexport xlExporter, XMLReader xmlReaderl) { 
        
            _xlExporter = xlExporter;
            _xmlReaderl = xmlReaderl;
        
        }

    

    }
}
