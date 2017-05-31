using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    public class LanguagesCommand : ICommand
    {
        private SetLanguagesViewModel setlanguagesvm;

        public LanguagesCommand(SetLanguagesViewModel vm)
        {
            this.setlanguagesvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            setlanguagesvm.SetLanguages(parameter);         
        }
    }
}
