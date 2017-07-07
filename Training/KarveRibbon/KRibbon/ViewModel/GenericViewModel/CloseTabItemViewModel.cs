using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Globalization;
using System.Threading;
using System.Windows.Controls;
using KRibbon;
using KRibbon.Commands.Generic;
using KRibbon.Model;
using KRibbon.Utility;
using KRibbon.Properties;
using KRibbon.Logic.Maestros;
using static KRibbon.Utility.VariablesGlobales;
using KRibbon.Logic.Generic;
using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;

namespace KRibbon.ViewModel.GenericViewModel
    {
    public class CloseTabItemViewModel : PropertyChangedBase
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
            EOpcion tipoaux = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;
            ManageTabItem.removeTabItem(tipoaux);
            //ManageTabItem.removeTabItem((TabItem)parameter);
        }
    }
}
