using KRibbon.Commands.Generic;
using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    class CloseWindowCommand : ICommand
    {
        private CloseWindowViewModel closewindowvm;

        public CloseWindowCommand() {}
        public CloseWindowCommand(CloseWindowViewModel vm)
        {
            this.closewindowvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            closewindowvm.CloseWindow(parameter);         
        }
    }
}
