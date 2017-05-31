using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class RelayCommand : ICommand
    {
        private Action commandTask;

        public RelayCommand(Action myaction)
        {
            commandTask = myaction;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
    }
}