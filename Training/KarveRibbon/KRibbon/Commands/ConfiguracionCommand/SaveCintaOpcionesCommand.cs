using KRibbon.ViewModel.ConfiguracionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KRibbon.Commands.ConfiguracionCommand
{
    public class SaveCintaOpcionesCommand : ICommand
    {
        private CintaOpcionesViewModel cintaopcionesvm;

        public SaveCintaOpcionesCommand(CintaOpcionesViewModel vm)
        {
            this.cintaopcionesvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            cintaopcionesvm.SaveCintaOpciones(parameter);
        }
    }
}
