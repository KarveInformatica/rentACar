using KRibbon.Commands.Generic;
using KRibbon.Logic.Maestros;
using KRibbon.Model.Generic;
using System.Linq;
using System.Windows.Input;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.ViewModel.MaestrosViewModel
{
    public class MostrarAuxiliaresViewModel : PropertyChangedBase
    {
        private MostrarAuxiliaresCommand mostrarauxiliarescommand;

        public MostrarAuxiliaresViewModel()
        {
            this.mostrarauxiliarescommand = new MostrarAuxiliaresCommand(this);
        }

        public ICommand MostrarAuxCommand
        {
            get
            {
                return mostrarauxiliarescommand;
            }
        }
 
        /// <summary>
        /// Añade/pone foco en la Tab correspondiente según el param recibido desde el xaml, del cual se recupera su EOpcion
        /// </summary>
        /// <param name="parameter"></param>
        public void MostrarAuxiliares(object parameter)
        {
            EOpcion opcion = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;

            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                AuxiliaresLogic.PrepareTabItemDataGrid(opcion);
            }           
        }
    }
}