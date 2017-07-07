using KRibbon.Utility;
using KRibbon.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static KRibbon.Utility.VariablesGlobales;

namespace KRibbon.Logic.Generic
{
    public class ManageTabItem
    {
        /// <summary>
        /// Devuelve un nuevo TabItem según el tipo de auxiliar que recibe por param. Se le añade el Header, Name, Focus. 
        /// Se añade el nuevo TabItem al TabControl. Se añade el nuevo TabItem al Dictionary de TabItems (tabitemlist) 
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

            //Añadimos el nuevo TabItem en la lista de items
            tabitemauxiliares.TbItem = tbitem;
            tabitemlist.Add(opcion, tabitemauxiliares);

            //Añadimos el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
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
            {   //Eliminamos el TabItem del TabControl
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tabitemlist.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem);
                //Eliminamos el TabItem del Dictionary tabitemlist
                tabitemlist.Remove(tabitemlist.Where(z => z.Key == opcion).FirstOrDefault().Key);
            }
        }
    }
}
