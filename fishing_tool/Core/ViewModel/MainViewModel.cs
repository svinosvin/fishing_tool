using DevExpress.Mvvm;
using fishing_tool.Core.Pages;
using fishing_tool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;

namespace fishing_tool.Core.ViewModel
{
    public class MainViewModel : BindableBase, ISingleton
    {

        private readonly PageService _pageService;
       
        public Page PageSource { get; set; }
        public MainViewModel(PageService pageService)
        {
            _pageService = pageService;
            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new MainPage());
        }

        public ICommand GoToHelpPage => new DelegateCommand(() =>
        {
            _pageService.ChangePage(new HelpPage());
        });

        public ICommand GoToFirstPage => new DelegateCommand(() =>
        {
            _pageService.ChangePage(new MainPage());
        });
     
        
        
    }
}
