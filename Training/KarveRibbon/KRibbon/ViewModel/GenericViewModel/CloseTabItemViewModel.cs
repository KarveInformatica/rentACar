using KRibbon.Commands.Generic;
using KRibbon.Logic.Generic;
using KRibbon.Model.Generic;
using System.Linq;
using System.Windows.Input;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

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

        /// <summary>
        /// Cierra el TabItem según la EOpcion recibida por params
        /// </summary>
        /// <param name="parameter"></param>
        public void CloseTabItem(object parameter)
        {
            EOpcion tipoaux = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;
            ManageTabItem.RemoveTabItem(tipoaux);
        }
    }
}
