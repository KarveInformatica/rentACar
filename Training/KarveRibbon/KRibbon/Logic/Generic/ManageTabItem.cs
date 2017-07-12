using KRibbon.Logic.Generic.Propiedades;
using KRibbon.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Generic
{
    public class ManageTabItem
    {
        /// <summary>
        /// Devuelve un nuevo TabItem según el tipo de auxiliar que recibe por param. Se le añade el Header, Name, Focus.
        /// Se añade el nuevo TabItem a DatosAyudaTabItem tabitemauxiliares. Se añade el nuevo TabItem al TabControl. 
        /// Se añade el nuevo TabItem al Dictionary de TabItems (tabitemdictionary) que almacena los TabItems activos. 
        /// Se añade el Resource "ResourceLanguage" para que pueda cambiar el idioma del Header del TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public static TabItem CreateTabItemDataGrid(EOpcion opcion, DatosAyudaTabItem tabitemauxiliares)
        {
            //TabItem tbitem = new TabItem();
            TabItemUserControl tbitem = new TabItemUserControl();
            var binding = new Binding();
            binding.Path = new PropertyPath(tiposauxiliaresdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.propertiesresources);
            binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            tbitem.Name = opcion.ToString();
            tbitem.HeaderTemplate = tbitem.FindResource("TabHeader") as DataTemplate;

            //Se añaden el nuevo TabItem a DatosAyudaTabItem tabitemauxiliares
            tabitemauxiliares.TbItem = tbitem;
            
            //Se añade el nuevo TabItem en la lista de items recibida por params
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
        public static void RemoveTabItem(EOpcion opcion)
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
