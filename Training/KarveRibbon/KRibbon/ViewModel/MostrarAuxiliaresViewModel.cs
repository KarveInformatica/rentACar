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

namespace KRibbon.Model.Generic
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
        /// Añade/pone foco en la Tab correspondiente según el param recibido desde el xaml, del cual se recupera su ETipoAuxiliar
        /// </summary>
        /// <param name="parameter"></param>
        public void MostrarAuxiliares(object parameter)
        {
            ETipoAuxiliar tipoaux = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;

            //Si el param no se encuentra en la Enum ETipoAuxiliar, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum ETipoAuxiliar
            if (tipoaux.ToString() == parameter.ToString())
            {
                LogicAuxiliares.addTabItem(tipoaux);
            }           
        }
    }
}