using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;
using KRibbon.ViewModel.MaestrosViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace KRibbon.Commands.Generic
{
    public class MostrarAuxiliaresCommand : ICommand
    {
        private MostrarAuxiliaresViewModel mostrarauxiliaresvm;

        public MostrarAuxiliaresCommand(MostrarAuxiliaresViewModel vm)
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
            mostrarauxiliaresvm.MostrarAuxiliares(parameter);        
        }
    }
}
