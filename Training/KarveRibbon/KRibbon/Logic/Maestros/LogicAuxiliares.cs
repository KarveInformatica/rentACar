using KRibbon.Model;
using KRibbon.Model.Generic.ObservableCollection;
using KRibbon.Model.Sybase;
using KRibbon.Utility;
using KRibbon.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using static KRibbon.Utility.VariablesGlobales;
using System;
using KRibbon.ViewModel.ConfiguracionViewModel;

namespace KRibbon.Logic.Maestros
{
    public class LogicAuxiliares
    {
        /// <summary>
        /// Proceso de añadir un TabItem al TabControl según el tipo de auxiliar que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void prepareTabItemDataGrid(EOpcion opcion)
        {
            if (tabitemlist.Where(p => p.Key == opcion).Count() == 0)
            //if(!ifExistTabItem)
            {
                dgitemsobscollection = new ObservableCollection<object>();
                string tablaauxiliares = tiposauxiliaresdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.nombretabladb;

                switch (opcion)
                {
                    #region case Auxiliares Clientes
                    case EOpcion.rbtnBancosClientes:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, Banco.dbcriterioslist, new Banco());
                        BancoViewModel bancoviewmodel = new BancoViewModel();
                        bancoviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnBloqueFacturacion:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, BloqueFacturacion.dbcriterioslist, new BloqueFacturacion());
                        BloqueFacturacionViewModel bloquefacturacionviewmodel = new BloqueFacturacionViewModel();
                        bloquefacturacionviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnCanales:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CanalCliente.dbcriterioslist, new CanalCliente());
                        CanalClienteViewModel canalclienteviewmodel = new CanalClienteViewModel();
                        canalclienteviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnCargosPersonal:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CargoPersonal.dbcriterioslist, new CargoPersonal());
                        CargoPersonalViewModel cargopersonalviewmodel = new CargoPersonalViewModel();
                        cargopersonalviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Comisionistas
                    case EOpcion.rbtnTipoComisionista:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, TipoComisionista.dbcriterioslist, new TipoComisionista());
                        TipoComisionistaViewModel tipocomisionistaviewmodel = new TipoComisionistaViewModel();
                        tipocomisionistaviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Contratos
                    #endregion
                    #region case Auxiliares Proveedor
                    case EOpcion.rbtnFormaPagoProveedor:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, FormaPagoProveedor.dbcriterioslist, new FormaPagoProveedor());
                        FormaPagoProveedorViewModel formapagoproveedorviewmodel = new FormaPagoProveedorViewModel();
                        formapagoproveedorviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    #endregion
                    #region case Auxiliares Reservas
                    #endregion
                    #region case Auxiliares Tarifas
                    case EOpcion.rbtnGruposTarifa:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, GrupoTarifa.dbcriterioslist, new GrupoTarifa());
                        GrupoTarifaViewModel grupotarifaviewmodel = new GrupoTarifaViewModel();                        
                        grupotarifaviewmodel.GetCollection(dgitemsobscollection);
                        loadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
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
                tabitemlist.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem.Focus();
            }
        }

        public static void prepareTabItemUserControl(EOpcion opcion)
        {
            dgitemsobscollection = new ObservableCollection<object>();
            DatosAyudaTabItem tabitemauxiliares = new DatosAyudaTabItem(dgitemsobscollection);

            //Se crea el Tabitem
            TabItem tbitem = Generic.ManageTabItem.createTabItemDataGrid(opcion, tabitemauxiliares);
            //Creamos el DataGrid

            tbitem.Content = new CintaOpcionesUserControl();            
        }

        /// <summary>
        /// Carga los datos de una ObservableCollection (dgitemsobscollection) en un Datagrid dentro del TabItem (tbitem) recibido por parámetros.
        /// Tiene en cuenta el nombre de las propiedades (dbcriterioslist.nombrepropiedadobj) del objeto que debe cargar.
        /// </summary>
        /// <param name="tbitem"></param>
        /// <param name="datagriditemslist"></param>
        /// <param name="dbcriterioslist"></param>
        private static void loadTabItemDataGrid(ObservableCollection<object> dgitemsobscollection, EOpcion opcion, DatosAyudaTabItem tabitemauxiliares)
        {
            if (dgitemsobscollection.Count != 0)
            {                
                //Se crea el Tabitem
                TabItem tbitem = Generic.ManageTabItem.createTabItemDataGrid(opcion, tabitemauxiliares);
                //Creamos el DataGrid
                DataGridUserControl datagrid = new DataGridUserControl();

                #region Se añade la ObservableCollection<object> directamente como el datagrid.ItemsSource, rellena las columnas según las propiedades que tenga el object, tenga o no tenga datos; el header será el nombre de cada propiedad del object

                //SetTrigger(datagrid);
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

                datagrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("SelectedItem") { Source = dgitemsobscollection });

                datagrid.ItemsSource = dgitemsobscollection;
                tbitem.Content = datagrid;
            }
        }


        public static void SetTrigger(DataGrid contentControl)
        {
            // create the command action and bind the command to it
            var invokeCommandAction = new InvokeCommandAction { CommandParameter = "datagridcommandtest" };
            var binding = new Binding { Path = new PropertyPath("CloseWindowCommand") };
            BindingOperations.SetBinding(invokeCommandAction, InvokeCommandAction.CommandProperty, binding);

            // create the event trigger and add the command action to it
            var eventTrigger = new System.Windows.Interactivity.EventTrigger { EventName = "MouseEnter" };
            eventTrigger.Actions.Add(invokeCommandAction);

            // attach the trigger to the control
            var triggers = Interaction.GetTriggers(contentControl);
            triggers.Add(eventTrigger);
        }
    }
}