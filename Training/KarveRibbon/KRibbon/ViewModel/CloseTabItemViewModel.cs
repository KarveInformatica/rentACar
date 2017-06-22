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
using System.Windows.Controls;

namespace KRibbon.ViewModel
{
    public class CloseTabItemViewModel : ViewModelBase
    {
        private CloseTabItemCommand closetabitemcommand;

        public CloseTabItemViewModel()
        {
            this.closetabitemcommand = new CloseTabItemCommand(this);
        }

        public ICommand CloseTabItemCommand
        {
            get
            {
                return closetabitemcommand;
            }
        }

        public void CloseTabItem(object parameter)
        {
            LogicAuxiliares.removeTabItem((TabItem)parameter);
        }
    }
}
