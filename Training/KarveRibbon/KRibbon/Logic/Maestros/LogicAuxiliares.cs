using KRibbon.Commands.Specific;
using KRibbon.Model;
using KRibbon.Model.Generic;
using KRibbon.Model.Sybase;
using KRibbon.Utility;
using static KRibbon.Utility.VariablesGlobales;
using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Data;
using iAnywhere.Data.SQLAnywhere;
using System.Windows.Input;
using System.Data.Linq;
using System.Windows.Interactivity;

namespace KRibbon.Logic.Maestros
{
    public class LogicAuxiliares
    {
        /// <summary>
        /// Proceso de añadir un TabItem al TabControl según el tipo de auxiliar que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="tipoauxiliar"></param>
        public static void addTabItem(ETipoAuxiliar tipoauxiliar)
        {
            //Se comprueba que la TabItem del tipo de auxiliar no esté ya mostrado
            if (!tabitemdictionary.ContainsKey(tipoauxiliar))
            {
                dgitemsobscollection = new ObservableCollection<object>();
                string tablaauxiliares = tiposauxiliaresdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.nombretabladb;

                switch (tipoauxiliar)
                {
                    #region case Auxiliares Clientes
                    case ETipoAuxiliar.rbttBancosClientes:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, Banco.dbcriterioslist, new Banco());
                        loadDataGrid(dgitemsobscollection, Banco.dbcriterioslist, tipoauxiliar);
                        break;
                    case ETipoAuxiliar.rbttBloqueFacturacion:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, BloqueFacturacion.dbcriterioslist, new BloqueFacturacion());
                        loadDataGrid(dgitemsobscollection, BloqueFacturacion.dbcriterioslist, tipoauxiliar);
                        break;
                    case ETipoAuxiliar.rbttCanales:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CanalCliente.dbcriterioslist, new CanalCliente());
                        loadDataGrid(dgitemsobscollection, CanalCliente.dbcriterioslist, tipoauxiliar);
                        break;
                    case ETipoAuxiliar.rbttCargosPersonal:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CargoPersonal.dbcriterioslist, new CargoPersonal());
                        loadDataGrid(dgitemsobscollection, CargoPersonal.dbcriterioslist, tipoauxiliar);
                        break;
                    #endregion
                    #region case Auxiliares Comisionistas
                    case ETipoAuxiliar.rbttTipoComisionista:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, TipoComisionista.dbcriterioslist, new TipoComisionista());
                        loadDataGrid(dgitemsobscollection, TipoComisionista.dbcriterioslist, tipoauxiliar);
                        break;
                    #endregion
                    #region case Auxiliares Contratos
                    #endregion
                    #region case Auxiliares Proveedor
                    case ETipoAuxiliar.rbttFormasPagoProveedor:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, FormaPagoProveedor.dbcriterioslist, new FormaPagoProveedor());
                        loadDataGrid(dgitemsobscollection, FormaPagoProveedor.dbcriterioslist, tipoauxiliar);
                        break;
                    #endregion
                    #region case Auxiliares Reservas
                    #endregion
                    #region case Auxiliares Tarifas
                    case ETipoAuxiliar.rbttGruposTarifa:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, GrupoTarifa.dbcriterioslist, new GrupoTarifa());
                        loadDataGrid(dgitemsobscollection, GrupoTarifa.dbcriterioslist, tipoauxiliar);
                        break;
                    #endregion
                    #region case Auxiliares Vehículos
                    #endregion
                    #region case Auxiliares Varios
                    #endregion
                    default:
                        break;
                }
            }
            else
            {   //Si el TabItem del tipo de auxiliar ya está mostrado, no se carga
                //de nuevo, simplemente se establece el foco en ese TabItem
                TabItem tabitem = tabitemdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value;
                tabitem.Focus();
            }
        }

        /// <summary>
        /// Elimina el TabItem recibido por param del TabControl.
        /// </summary>
        /// <param name="tbitem"></param>
        public static void removeTabItem(TabItem tbitem)
        {
            if (tbitem != null)
            {   //Eliminamos el TabItem del TabControl
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tbitem);
                //Eliminamos el TabItem del Dictionary tabitemdictionary
                tabitemdictionary.Remove(tiposauxiliaresdictionary.Where(z => z.Key.ToString() == tbitem.ToString()).FirstOrDefault().Key);
            }
        }

        /// <summary>
        /// Pending
        /// </summary>
        /// <param name="name"></param>
        public void updateItem(string name)
        {
            ItemCollection collection = ((MainWindow)Application.Current.MainWindow).tbControl.Items;
            foreach (var item in collection)
            {
                TabItem tab = (TabItem)item;
            }
        }

        /// <summary>
        /// Devuelve un nuevo TabItem según el tipo de auxiliar que recibe por param. Se le añade el Header, Name, Focus. 
        /// Se añade el nuevo TabItem al TabControl. Se añade el nuevo TabItem al Dictionary de TabItems (tabitemdictionary) 
        /// que almacena los TabItems activos.
        /// </summary>
        /// <param name="tipoauxiliar"></param>
        /// <returns></returns>
        private static TabItem createTabItem(ETipoAuxiliar tipoauxiliar)
        {
            TabItem tbitem = new TabItem();

            tbitem.Header = tiposauxiliaresdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.propertiesresources;
            tbitem.Name   = tipoauxiliar.ToString();
            tbitem.HeaderTemplate = ((MainWindow)Application.Current.MainWindow).tbControl.FindResource("TabHeader") as DataTemplate;

            //Añadimos el nuevo TabItem en la lista de items
            tabitemdictionary.Add(tipoauxiliar, tbitem);            

            //Añadimos el nuevo TabItem al TabControl, le ponemos el focus y devolvemos el nuevo TabItem
            ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);
            tbitem.Focus();
            return tbitem;
        }

        /// <summary>
        /// Carga los datos de una ObservableCollection (dgitemsobscollection) en un Datagrid dentro del TabItem (tbitem) recibido por parámetros.
        /// Tiene en cuenta el nombre de las propiedades (dbcriterioslist.nombrepropiedadobj) del objeto que debe cargar.
        /// </summary>
        /// <param name="tbitem"></param>
        /// <param name="datagriditemslist"></param>
        /// <param name="dbcriterioslist"></param>
        private static void loadDataGrid(ObservableCollection<object> dgitemslist, List<DBCriterios> dbcriterioslist, ETipoAuxiliar tipoauxiliar)
        {
            if (dgitemslist.Count != 0)
            {
                //Se crea el Tabitem
                TabItem tbitem = createTabItem(tipoauxiliar);
                //Creamos el DataGrid
                DataGrid datagrid = new DataGrid();
                datagrid.HorizontalAlignment = HorizontalAlignment.Left;
                datagrid.AlternatingRowBackground = Brushes.WhiteSmoke;                

                #region Se añade la ObservableCollection<object> directamente como el datagrid.ItemsSource, rellena las columnas según las propiedades que tenga el object, tenga o no tenga datos; el header será el nombre de cada propiedad del object
                datagrid.CanUserAddRows = false;
                datagrid.CanUserDeleteRows = true;

                //********************
                // create the command action and bind the command to it
                var invokeCommandAction = new InvokeCommandAction ();
                var binding = new Binding { Path = new PropertyPath("CloseWindowCommand") };
                BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);

                // create the event trigger and add the command action to it
                var eventTrigger = new System.Windows.Interactivity.EventTrigger { EventName = "SelectedCellsChanged" };
                eventTrigger.Actions.Add(invokeCommandAction);

                // attach the trigger to the control
                var triggers = Interaction.GetTriggers(datagrid);
                triggers.Add(eventTrigger);
                //********************



                datagrid.ItemsSource = dgitemslist;
                //datagrid.IsReadOnly = true;
                #endregion

                #region Se crean los DataGridTextColumn dinámicamente, dándole el nombre al header, y binding cada columna según establecido en la List<DBCriterios> del object; se añade cada columna individualmente al DataGrid
                ////Creamos los DataGridTextColumn
                //DataGridTextColumn col;

                //foreach (var item in dbcriterioslist)
                //{
                //    col = new DataGridTextColumn();
                //    col.Header = item.datagridheader; // new KarveDataGridTextColum(item.datagridheader);
                //    col.Binding = new Binding(item.nombrepropiedadobj);
                //    datagrid.Columns.Add(col);
                //}

                ////Añadimos los valores al Datagrid
                //foreach (var item in dgitemslist)
                //{
                //    datagrid.Items.Add(item);
                //}
                #endregion

                tbitem.Content = datagrid;
            }
        }
    }
}