using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Native;
using fishing_tool.Core.Python;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
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

            var dialog = new OpenFolderDialog()
            {
                Title = "Select Folder",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Multiselect = false
            };

            string path;
            if (dialog.ShowDialog() == true)
            {
                path = dialog.FolderName;
                if (_pythonService.exec_script(path))
                {
                    MessageBox.Show("Пример успешно сохранен рядом с запускаемым файлом");
                }
                else
                {
                    MessageBox.Show("Что-то пошло не так");

                }
            }




        });

    }
}
