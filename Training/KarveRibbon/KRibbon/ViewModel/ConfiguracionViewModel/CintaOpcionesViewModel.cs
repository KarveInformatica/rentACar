using KRibbon.Commands.ConfiguracionCommand;
using KRibbon.Logic.Configuracion;
using KRibbon.Utility;
using KRibbon.View;
using KRibbon.ViewModel.Generic;
using System.Linq;
using System.Windows.Input;
using static KRibbon.Utility.VariablesGlobalesCollections;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.ViewModel.ConfiguracionViewModel
{
    public class CintaOpcionesViewModel : PropertyChangedBase
    {
        private CintaOpcionesCommand cintaopcionescommand;
        private SaveCintaOpcionesCommand savecintaopcionescommand;

        public CintaOpcionesViewModel()
        {
            this.cintaopcionescommand = new CintaOpcionesCommand(this);
            this.savecintaopcionescommand = new SaveCintaOpcionesCommand(this);
        }

        public ICommand CintaOpcionesCommand
        {
            get
            {
                return cintaopcionescommand;
            }
        }

        public ICommand SaveCintaOpcionesCommand
        {
            get
            {
                return savecintaopcionescommand;
            }
        }

        /// <summary>
        /// Muestra los RibbonTab de los cuales se deseen guardar la configuración por defecto de los RibbonGroups 
        /// </summary>
        /// <param name="parameter"></param>
        public void CintaOpciones(object parameter)
        {
            EOpcion opcion = tiposauxiliaresdictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;          

            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                LogicCintaOpciones.prepareTabItemUserControl(opcion);
            }
        }

        /// <summary>
        /// Guarda la configuración por defecto de los RibbonGroups de los RibbonTab seleccionados
        /// </summary>
        /// <param name="parameter"></param>
        public void SaveCintaOpciones(object parameter)
        {
            CintaOpcionesUserControl cintaopcionesusercontrol = parameter as CintaOpcionesUserControl;
            UserAndDefaultConfig.SetDefaultRibbonTabConfig(cintaopcionesusercontrol);
        }
    }
}
