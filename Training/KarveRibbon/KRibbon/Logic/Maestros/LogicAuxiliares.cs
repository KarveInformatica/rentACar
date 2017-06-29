using KRibbon.Commands.Specific;
using KRibbon.Model;
using KRibbon.Model.Generic;
using KRibbon.Model.Sybase;
using KRibbon.Utility;
using static KRibbon.Utility.VariablesGlobales;
using KRibbon.Model.Generic;
using KRibbon.Model.Generic.ObservableCollection;
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
            //bool ifExistTabItem = false;
            //if (tabitemlist.Count > 0)
            //{
            //    foreach (var item in tabitemlist)
            //    {
            //        if (item.TipoAuxiliar == tipoauxiliar)
            //        {
            //            ifExistTabItem = true;
            //            break;
            //        }
            //    }
            //}

            if (tabitemlist.Where(p => p.Key == tipoauxiliar).Count() == 0)
            //if(!ifExistTabItem)
            {
                dgitemsobscollection = new ObservableCollection<object>();
                string tablaauxiliares = tiposauxiliaresdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.nombretabladb;

                switch (tipoauxiliar)
                {
                    #region case Auxiliares Clientes
                    case ETipoAuxiliar.rbtnBancosClientes:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, Banco.dbcriterioslist, new Banco());
                        BancoViewModel bancoviewmodel = new BancoViewModel();
                        bancoviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    case ETipoAuxiliar.rbtnBloqueFacturacion:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, BloqueFacturacion.dbcriterioslist, new BloqueFacturacion());
                        BloqueFacturacionViewModel bloquefacturacionviewmodel = new BloqueFacturacionViewModel();
                        bloquefacturacionviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    case ETipoAuxiliar.rbtnCanales:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CanalCliente.dbcriterioslist, new CanalCliente());
                        CanalClienteViewModel canalclienteviewmodel = new CanalClienteViewModel();
                        canalclienteviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    case ETipoAuxiliar.rbtnCargosPersonal:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CargoPersonal.dbcriterioslist, new CargoPersonal());
                        CargoPersonalViewModel cargopersonalviewmodel = new CargoPersonalViewModel();
                        cargopersonalviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Comisionistas
                    case ETipoAuxiliar.rbtnTipoComisionista:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, TipoComisionista.dbcriterioslist, new TipoComisionista());
                        TipoComisionistaViewModel tipocomisionistaviewmodel = new TipoComisionistaViewModel();
                        tipocomisionistaviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Contratos
                    #endregion
                    #region case Auxiliares Proveedor
                    case ETipoAuxiliar.rbtnFormaPagoProveedor:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, FormaPagoProveedor.dbcriterioslist, new FormaPagoProveedor());
                        FormaPagoProveedorViewModel formapagoproveedorviewmodel = new FormaPagoProveedorViewModel();
                        formapagoproveedorviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Reservas
                    #endregion
                    #region case Auxiliares Tarifas
                    case ETipoAuxiliar.rbtnGruposTarifa:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, GrupoTarifa.dbcriterioslist, new GrupoTarifa());
                        GrupoTarifaViewModel grupotarifaviewmodel = new GrupoTarifaViewModel();                        
                        grupotarifaviewmodel.GetCollection(dgitemsobscollection);
                        loadDataGrid(dgitemsobscollection, tipoauxiliar, new TabItemAuxiliares(dgitemsobscollection));
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
                tabitemlist.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.TbItem.Focus();
            }
        }

        /// <summary>
        /// Elimina el TabItem según el ETipoAuxiliar recibido por param.
        /// </summary>
        /// <param name="tipoauxiliar"></param>
        public static void removeTabItem(ETipoAuxiliar tipoauxiliar)
        {
            if (tipoauxiliar != null)
            {   //Eliminamos el TabItem del TabControl
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tabitemlist.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.TbItem);
                //Eliminamos el TabItem del Dictionary tabitemlist
                tabitemlist.Remove(tabitemlist.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Key);
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
        /// Se añade el nuevo TabItem al TabControl. Se añade el nuevo TabItem al Dictionary de TabItems (tabitemlist) 
        /// que almacena los TabItems activos.
        /// </summary>
        /// <param name="tipoauxiliar"></param>
        /// <returns></returns>
        private static TabItem createTabItem(ETipoAuxiliar tipoauxiliar, TabItemAuxiliares tabitemauxiliares)
        {
            TabItem tbitem = new TabItem();

            var binding = new Binding();
            binding.Path = new PropertyPath(tiposauxiliaresdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.propertiesresources);
            binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
            tbitem.SetBinding(TabItem.HeaderProperty, binding);
            tbitem.Name   = tipoauxiliar.ToString();
            tbitem.HeaderTemplate = ((MainWindow)Application.Current.MainWindow).tbControl.FindResource("TabHeader") as DataTemplate;

            //Añadimos el nuevo TabItem en la lista de items
            tabitemauxiliares.TbItem = tbitem;
            tabitemlist.Add(tipoauxiliar, tabitemauxiliares);

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
        private static void loadDataGrid(ObservableCollection<object> dgitemsobscollection, ETipoAuxiliar tipoauxiliar, TabItemAuxiliares tabitemauxiliares)
        {
            if (dgitemsobscollection.Count != 0)
            {                
                //Se crea el Tabitem
                TabItem tbitem = createTabItem(tipoauxiliar, tabitemauxiliares);
                //Creamos el DataGrid
                DataGrid datagrid = new DataGrid();
                datagrid.HorizontalAlignment = HorizontalAlignment.Left;
                datagrid.AlternatingRowBackground = Brushes.WhiteSmoke;                

                #region Se añade la ObservableCollection<object> directamente como el datagrid.ItemsSource, rellena las columnas según las propiedades que tenga el object, tenga o no tenga datos; el header será el nombre de cada propiedad del object
                datagrid.CanUserAddRows = false;
                datagrid.CanUserDeleteRows = true;
                

                //********************
                // create the command action and bind the command to it
                //var invokeCommandAction = new InvokeCommandAction ();
                //var binding = new Binding { Path = new PropertyPath("CloseWindowCommand") };
                //BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);

                //// create the event trigger and add the command action to it
                //var eventTrigger = new System.Windows.Interactivity.EventTrigger { EventName = "SelectedCellsChanged" };
                //eventTrigger.Actions.Add(invokeCommandAction);

                //// attach the trigger to the control
                //var triggers = Interaction.GetTriggers(datagrid);
                //triggers.Add(eventTrigger);
                //********************


                datagrid.ItemsSource = dgitemsobscollection;
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