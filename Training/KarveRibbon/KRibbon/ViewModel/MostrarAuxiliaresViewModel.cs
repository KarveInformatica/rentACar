using KRibbon.Commands.Specific;
using KRibbon.Logic.Maestros;
using static KRibbon.Utility.VariablesGlobales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// Añade/pone foco en la Tab correspondiente según el param recibido desde el xaml, del cual se recupera su ETipoAuxiliar
        /// </summary>
        /// <param name="parameter"></param>
        public void MostrarAux(object parameter)
        {
            ETipoAuxiliar tipoaux = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;

            //Si el param no se encuentra en la Enum ETipoAuxiliar, no hace nada, sino mostraría la Tab correspondiente al 
            //primer valor de la Enum ETipoAuxiliar
            if (tipoaux.ToString() == parameter.ToString())
            {
                LogicAuxiliares.addTabItem(tipoaux);
            }           
        }
    }
}
