using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    public class SetLanguagesCommand : ICommand
    {
        private SetLanguagesViewModel setlanguagesvm;

        public SetLanguagesCommand(SetLanguagesViewModel vm)
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
