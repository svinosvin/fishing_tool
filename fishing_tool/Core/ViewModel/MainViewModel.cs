using DevExpress.Mvvm;
using fishing_tool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace fishing_tool.Core.ViewModel
{
    public class MainViewModel: BindableBase, ISingleton
    {

        private readonly XmlReader _reader;
        private readonly EXELexport exporter;



        public MainViewModel()
        {
            
        }

    }
}
