using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace fishing_tool.Services
{
    public class PageService : ISingleton
    {

        public event Action<Page> OnPageChanged;
        public void ChangePage(Page page)=>OnPageChanged?.Invoke(page);

    }
}
