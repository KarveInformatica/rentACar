using KRibbon.Utility;
using KRibbon.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows.Controls;
using static KRibbon.Utility.VariablesGlobalesCollections;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Configuracion
{
    public class LogicCintaOpciones
    {
        /// <summary>
        /// Proceso de añadir un UserControl al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void prepareTabItemUserControl(EOpcion opcion)
        {
            if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
            {
                dgitemsobscollection = new ObservableCollection<object>();
                DatosAyudaTabItem tabitemusercontrol = new DatosAyudaTabItem(dgitemsobscollection);

                //Se crea el Tabitem
                TabItem tbitem = Generic.ManageTabItem.createTabItemDataGrid(opcion, tabitemusercontrol);
                //Se añade un nuevo object CintaOpcionesUserControl al TabItem
                tbitem.Content = new CintaOpcionesUserControl();
            }
            else
            {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem.Focus();
            }
        }
    }
}
