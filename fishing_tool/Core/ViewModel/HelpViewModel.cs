using DevExpress.Mvvm;
using fishing_tool.Core.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace fishing_tool.Core.ViewModel
{
    public class HelpViewModel : BindableBase, ISingleton
    {

        private readonly PythonService _pythonService;
        public HelpViewModel(PythonService pythonService) { 
            
           _pythonService = pythonService; 

        }

        public ICommand generateExample => new DelegateCommand(() =>
        {
            if (_pythonService.exec_script())
            {
                MessageBox.Show("Пример успешно сохранен рядом с запускаемым файлом");
            }
            else
            {
                MessageBox.Show("Что-то пошло не так");

            }
        });

    }
}
