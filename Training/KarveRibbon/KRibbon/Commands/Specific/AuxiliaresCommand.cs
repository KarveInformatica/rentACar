using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    public class AuxiliaresCommand : ICommand
    {
        private MostrarAuxiliaresViewModel mostrarauxiliaresvm;

        public AuxiliaresCommand(MostrarAuxiliaresViewModel vm)
        {
            this.mostrarauxiliaresvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mostrarauxiliaresvm.MostrarAux(parameter);        
        }
    }
}
