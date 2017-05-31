using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KRibbon.Commands.Specific;
using System.Windows.Input;
using System.Windows;
using KRibbon.Model;
using KRibbon.Utility;

namespace KRibbon.ViewModel
{
    public class MostrarAuxiliaresViewModel : ViewModelBase
    {
        private AuxiliaresCommand auxiliaresCommand;

        public MostrarAuxiliaresViewModel()
        {
            this.auxiliaresCommand = new AuxiliaresCommand(this);
        }

        public ICommand MostrarAuxCommand
        {
            get
            {
                return auxiliaresCommand;
            }
        }

        public void MostrarAux(object parameter)
        {
            AddTab.addTabItem(parameter);
        }
    }
}
