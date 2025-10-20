using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace fishing_tool.Core.Base.Command
{
    public interface IDelegateCommand : ICommand
    {
        public void RaiseCanExecuteChange();

    }
}