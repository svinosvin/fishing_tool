using fishing_tool.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_tool
{
    public class ViewModelLocator
    {
        private ViewModelLocator() { }
        public static ViewModelLocator Current { get; } = new();


        public MainViewModel MainViewModel => Ioc.Resolve<MainViewModel>();

    }
}
