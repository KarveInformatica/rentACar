using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    public class CloseItemCommand : ICommand
    {
        private CloseItemViewModel closeitemvm;

        public CloseItemCommand() {}
        public CloseItemCommand(CloseItemViewModel vm)
        {
            this.closeitemvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            closeitemvm.CloseItem(parameter);         
        }
    }
}
