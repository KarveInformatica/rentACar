using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Globalization;
using System.Threading;
using KRibbon;
using KRibbon.Commands.Specific;
using KRibbon.Model;
using KRibbon.Utility;
using KRibbon.Properties;
using KRibbon.Logic.Maestros;
using static KRibbon.Utility.VariablesGlobales;
using KRibbon.Logic.Generic;

namespace KRibbon.ViewModel
{
    public class CloseItemViewModel : ViewModelBase
    {
        private CloseItemCommand closeitemcommand;

        public CloseItemViewModel()
        {
            this.closeitemcommand = new CloseItemCommand(this);
        }

        public ICommand CloseItemCommand
        {
            get
            {
                return closeitemcommand;
            }
        }

        public void CloseItem(object parameter)
        {
            if(parameter.ToString().Equals("Window"))
            {
                CloseWindow.closeWindow();
            }
            else
            {
                LogicAuxiliares.removeTabItem(tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key);
            }
        }
    }
}
