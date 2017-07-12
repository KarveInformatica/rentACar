using KRibbon.Model.Sybase;
using KRibbon.Logic.Generic.Metodos;
using KRibbon.Logic.Generic.Propiedades;
using KRibbon.View;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Configuracion
{
    public class CintaOpcionesLogic
    {
        /// <summary>
        /// Proceso de añadir un UserControl al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void PrepareTabItemUserControl(EOpcion opcion)
        {
            try
            {
                if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
                {
                    dgitemsobscollection = new ObservableCollection<object>();
                    DatosAyudaTabItem tabitemusercontrol = new DatosAyudaTabItem(dgitemsobscollection);

                    CintaOpcionesUserControl cintaopcionesusercontrol = new CintaOpcionesUserControl();

                    //Se crea el Tabitem
                    TabItem tbitem = Generic.ManageTabItem.CreateTabItemDataGrid(opcion, tabitemusercontrol);
                    //Se añade un nuevo object CintaOpcionesUserControl al TabItem
                    tbitem.Content = cintaopcionesusercontrol;
                }
                else
                {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                    tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem.Focus();
                }
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Guarda la configuración por defecto (Variablesglobales.Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdefaultdictionary )
        /// de los RibbonGroups de los RibbonTab seleccionados
        /// </summary>
        /// <param name="opcion"></param>
        public static void GuardarCintaOpciones(EOpcion opcion)
        {
            try
            {
                TabItem tabitem = tabitemdictionary.Where(c => c.Key == opcion).FirstOrDefault().Value.TbItem;
                CintaOpcionesUserControl cintaopcionesusercontrol = tabitem.Content as CintaOpcionesUserControl;

                UserAndDefaultConfig.SetDefaultRibbonTabConfig(cintaopcionesusercontrol);
            }
            catch (Exception ex)
            {
                ErrorsGeneric.MessageError(ex);
            }
        }

        /// <summary>
        /// Desmarca todos los CheckBox
        /// </summary>
        /// <param name="opcion"></param>
        public static void CancelarCintaOpciones(EOpcion opcion)
        {
            try
            {
                TabItem tabitem = tabitemdictionary.Where(c => c.Key == opcion).FirstOrDefault().Value.TbItem;
                CintaOpcionesUserControl cintaopcionesusercontrol = tabitem.Content as CintaOpcionesUserControl;

                foreach (Control control in cintaopcionesusercontrol.grdCintaOpciones.Children)
                {
                    if (control is CheckBox)
                    {
                        CheckBox checkbox = control as CheckBox;
                        checkbox.IsChecked = false;
                    }
                }
            }
            catch (Exception ex)
            {            
                ErrorsGeneric.MessageError(ex);
            }
        }
    }
}
