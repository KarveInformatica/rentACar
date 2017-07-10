using KRibbon.Utility;
using KRibbon.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static KRibbon.Utility.VariablesGlobalesCollections;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Generic
{
    public class ManageTabItem
    {
        /// <summary>
        /// Devuelve un nuevo TabItem según el tipo de auxiliar que recibe por param. Se le añade el Header, Name, Focus. 
        /// Se añade el nuevo TabItem al TabControl. Se añade el nuevo TabItem al Dictionary de TabItems (tabitemdictionary) 
        /// que almacena los TabItems activos.
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static TabItem createTabItemDataGrid(EOpcion opcion, DatosAyudaTabItem tabitemauxiliares)
        {
            //TabItem tbitem = new TabItem();
            TabItemUserControl tbitem = new TabItemUserControl();
            var binding = new Binding();
            binding.Path = new PropertyPath(tiposauxiliaresdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.propertiesresources);
            binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            tbitem.Name = opcion.ToString();
            tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;

            //Se añade el nuevo TabItem en la lista de items
            tabitemauxiliares.TbItem = tbitem;
            tabitemdictionary.Add(opcion, tabitemauxiliares);

            //Se añade el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
            ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);
            tbitem.Focus();
            return tbitem;
        }

        /// <summary>
        /// Elimina el TabItem según el EOpcion recibido por param.
        /// </summary>
        /// <param name="opcion"></param>
        public static void removeTabItem(EOpcion opcion)
        {
            if (opcion != null)
            {   //Se elimina el TabItem del TabControl
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem);
                //Se elimina el TabItem del Dictionary tabitemdictionary
                tabitemdictionary.Remove(tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Key);
            }
        }
    }
}
