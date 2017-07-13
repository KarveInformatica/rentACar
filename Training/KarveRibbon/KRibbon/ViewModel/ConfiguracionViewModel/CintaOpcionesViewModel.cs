﻿using KRibbon.Commands.ConfiguracionCommand;
using KRibbon.Logic.Configuracion;
using KRibbon.Model.Generic;
using System.Linq;
using System.Windows.Input;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.ViewModel.ConfiguracionViewModel
{
    public class CintaOpcionesViewModel : GenericPropertyChanged
    {
        #region Variables
        private CintaOpcionesCommand cintaopcionescommand;
        #endregion

        #region Constructor
        public CintaOpcionesViewModel()
        {
            this.cintaopcionescommand = new CintaOpcionesCommand(this);
        }
        #endregion

        #region Commands
        public ICommand CintaOpcionesCommand
        {
            get
            {
                return cintaopcionescommand;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Muestra los RibbonTab de los cuales se deseen guardar la configuración por defecto de los RibbonGroups 
        /// </summary>
        /// <param name="parameter"></param>
        public void CintaOpciones(object parameter)
        {
            EOpcion opcion = ribbonbuttondictionary.Where(z => z.Key.ToString() == parameter.ToString()).FirstOrDefault().Key;          

            //Si el param no se encuentra en la Enum EOpcion, no hace nada, sino mostraría 
            //la Tab correspondiente al primer valor de la Enum EOpcion
            if (opcion.ToString() == parameter.ToString())
            {
                CintaOpcionesLogic.PrepareTabItemUserControl(opcion);
            }
        }
        #endregion
    }
}