using KRibbon.Model.Classes;
using KRibbon.ViewModel.ObservableCollection;
using KRibbon.Model.Sybase;
using KRibbon.Logic.Generic.Propiedades;
using KRibbon.View;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Maestros
{
    public class AuxiliaresLogic
    {
        /// <summary>
        /// Proceso de añadir un TabItem al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void PrepareTabItemDataGrid(EOpcion opcion)
        {
            if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
            {   //Se crea un nuevo ObservableCollection<object> donde guardaremos los datos recibidos de la BBDD
                dgitemsobscollection = new ObservableCollection<object>();
                //Se recupera el nombre de la tabla de la BBDD
                string tablaauxiliares = tiposauxiliaresdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.nombretabladb;
                //Según la opcion recibida por params, se recuperan los datos de su correspondiente tabla de la BBDD, se crea un 
                //ObservableCollectionViewModel del tipo que corresponde y se le cargan los datos recuperados desde la BBDD, se carga una nueva
                //DataGrid dentro de un nuevo TabItem con los datos del ObservableCollectionViewModel según el tipo de dato que corresponda
                switch (opcion)
                {
                    #region Centros de Alquiler
                    case EOpcion.rbtnEmpresas:
                        break;
                    case EOpcion.rbtnOficinas:
                        break;
                    case EOpcion.rbtnZonasOficina:
                        break;
                    #endregion

                    #region Clientes
                    case EOpcion.rbtnClientes:
                        break;
                    case EOpcion.rbtnCambioCodigoCliente:
                        break;
                    case EOpcion.rbtnEntradaRapida:
                        break;
                    #endregion

                    #region Comisionistas
                    case EOpcion.rbtnComisionistas:
                        break;
                    #endregion

                    #region Proveedores
                    case EOpcion.rbtnProveedores:
                        break;
                    #endregion

                    #region Tarifas
                    case EOpcion.rbtnTarifas:
                        break;
                    case EOpcion.rbtnCambioCodigoTarifas:
                        break;
                    case EOpcion.rbtnCrearTarifaDesdeOtraTarifa:
                        break;
                    case EOpcion.rbtnIncrementoPrecios:
                        break;
                    case EOpcion.rbtnTarifaCliente:
                        break;
                    case EOpcion.rbtnTarifasComisionista:
                        break;
                    case EOpcion.rbtnVerTarifa:
                        break;
                    case EOpcion.rbtnVincularClienteTarifa:
                        break;
                    #endregion

                    #region Vehiculos
                    case EOpcion.rbtnVehiculos:
                        break;
                    case EOpcion.rbtnCambioCodigoVehiculo:
                        break;
                    case EOpcion.rbtnModificacionMasivaAux:
                        break;
                    case EOpcion.rbtnRecalculoMantenimiento:
                        break;
                    #endregion

                    #region Auxiliares Clientes
                    case EOpcion.rbtnBancosClientes:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, Banco.dbcriterioslist, new Banco());
                        BancoViewModel bancoviewmodel = new BancoViewModel();
                        bancoviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnBloqueFacturacion:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, BloqueFacturacion.dbcriterioslist, new BloqueFacturacion());
                        BloqueFacturacionViewModel bloquefacturacionviewmodel = new BloqueFacturacionViewModel();
                        bloquefacturacionviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnCanales:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CanalCliente.dbcriterioslist, new CanalCliente());
                        CanalClienteViewModel canalclienteviewmodel = new CanalClienteViewModel();
                        canalclienteviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnCargosPersonal:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CargoPersonal.dbcriterioslist, new CargoPersonal());
                        CargoPersonalViewModel cargopersonalviewmodel = new CargoPersonalViewModel();
                        cargopersonalviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnClavesPresupuesto:
                        break;
                    case EOpcion.rbtnFormasCobroClientes:
                        break;
                    case EOpcion.rbtnMercados:
                        break;
                    case EOpcion.rbtnNegocios:
                        break;
                    case EOpcion.rbtnOrigenClientes:
                        break;
                    case EOpcion.rbtnPaises:
                        break;
                    case EOpcion.rbtnPoblaciones:
                        break;
                    case EOpcion.rbtnProvincias:
                        break;
                    case EOpcion.rbtnSectoresActividad:
                        break;
                    case EOpcion.rbtnTarjetasCredito:
                        break;
                    case EOpcion.rbtnTarjetasEmpresa:
                        break;
                    case EOpcion.rbtnTiposCliente:
                        break;
                    case EOpcion.rbtnTiposContacto:
                        break;
                    case EOpcion.rbtnTiposVisita:
                        break;
                    case EOpcion.rbtnUsoAlquiler:
                        break;
                    case EOpcion.rbtnVendedores:
                        break;
                    case EOpcion.rbtnZonas:
                        break;
                    #endregion

                    #region Auxiliares Comisionistas
                    case EOpcion.rbtnEmpleadosAgencia:
                        break;
                    case EOpcion.rbtnTipoComisionista:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, TipoComisionista.dbcriterioslist, new TipoComisionista());
                        TipoComisionistaViewModel tipocomisionistaviewmodel = new TipoComisionistaViewModel();
                        tipocomisionistaviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    #endregion

                    #region Auxiliares Contratos
                    case EOpcion.rbtnAccesorios:
                        break;
                    case EOpcion.rbtnLugaresEntrega:
                        break;
                    case EOpcion.rbtnMotivosAnulacionContratos:
                        break;
                    case EOpcion.rbtnMotivosCambioVehiculo:
                        break;
                    case EOpcion.rbtnMotivosCancelacion:
                        break;
                    case EOpcion.rbtnMotivosImproductivo:
                        break;
                    case EOpcion.rbtnTipoImpresoContrato:
                        break;
                    #endregion

                    #region Auxiliares Incidencias
                    case EOpcion.rbtnTiposIncidenciasClientes:
                        break;
                    case EOpcion.rbtnTiposIncidenciasContratos:
                        break;
                    case EOpcion.rbtnTiposIncidenciasProveedores:
                        break;
                    case EOpcion.rbtnTiposIncidenciasReservas:
                        break;
                    #endregion

                    #region Auxiliares Proveedores
                    case EOpcion.rbtnDivisas:
                        break;
                    case EOpcion.rbtnFormaPagoProveedor:                        
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, FormaPagoProveedor.dbcriterioslist, new FormaPagoProveedor());
                        FormaPagoProveedorViewModel formapagoproveedorviewmodel = new FormaPagoProveedorViewModel();
                        formapagoproveedorviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    case EOpcion.rbtnTiposProveedores:
                        break;
                    #endregion

                    #region Auxiliares Reservas
                    case EOpcion.rbtnClavesFee:
                        break;
                    case EOpcion.rbtnMediosRecepcion:
                        break;
                    case EOpcion.rbtnMotivosAnulacionReservas:
                        break;
                    case EOpcion.rbtnMotivosNoServicio:
                        break;
                    #endregion

                    #region Auxiliares Tarifas
                    case EOpcion.rbtnConceptosFacturacion:
                        break;
                    case EOpcion.rbtnGruposTarifa:
                        dgitemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, GrupoTarifa.dbcriterioslist, new GrupoTarifa());
                        GrupoTarifaViewModel grupotarifaviewmodel = new GrupoTarifaViewModel();                        
                        grupotarifaviewmodel.GetCollection(dgitemsobscollection);
                        LoadTabItemDataGrid(dgitemsobscollection, opcion, new DatosAyudaTabItem(dgitemsobscollection));
                        break;
                    #endregion

                    #region Auxiliares Vehículos
                    case EOpcion.rbtnAccesoriosVehiculos:
                        break;
                    case EOpcion.rbtnActividadesVehiculos:
                        break;
                    case EOpcion.rbtnCodigosInmovilizacion:
                        break;
                    case EOpcion.rbtnCodigosMantenimiento:
                        break;
                    case EOpcion.rbtnColores:
                        break;
                    case EOpcion.rbtnExtras:
                        break;
                    case EOpcion.rbtnFormasTraslado:
                        break;
                    case EOpcion.rbtnGruposVehiculos:
                        break;
                    case EOpcion.rbtnMarcas:
                        break;
                    case EOpcion.rbtnModelos:
                        break;
                    case EOpcion.rbtnMotivosRepostaje:
                        break;
                    case EOpcion.rbtnPropietarios:
                        break;
                    case EOpcion.rbtnTiposVehiculos:
                        break;
                    #endregion

                    #region Auxiliares Varios
                    case EOpcion.rbtnCategoriasPersonal:
                        break;
                    case EOpcion.rbtnConceptosSalidaCaja:
                        break;
                    case EOpcion.rbtnTextosEstandars:
                        break;
                    case EOpcion.rbtnbitTipoContacto:
                        break;
                    case EOpcion.rbtnTiposDocumentos:
                        break;
                    case EOpcion.rbtnTipoImpresoFactura:
                        break;
                    #endregion
                    default:
                        break;
                }
            }
            else
            {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TbItem.Focus();
            }
        }

        /// <summary>
        /// Añade a un nuevo DataGridUserControl los datos del ObservableCollection (dgitemsobscollection) recibida por params. 
        /// El nombre de las propiedades del object del ObservableCollection (dgitemsobscollection) corresponderán con los 
        /// respectivos Headers. Se añade el DataGridUserControl en un nuevo TabItem (tbitem). 
        /// </summary>
        /// <param name="tbitem"></param>
        /// <param name="datagriditemslist"></param>
        /// <param name="dbcriterioslist"></param>
        private static void LoadTabItemDataGrid(ObservableCollection<object> dgitemsobscollection, EOpcion opcion, DatosAyudaTabItem tabitemauxiliares)
        {
            if (dgitemsobscollection.Count != 0)
            {                
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

                //datagrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("SelectedItem") { Source = dgitemsobscollection });
                //Se añade al DataGridUserControl el ObservableCollection<object> recibido por params como ItemsSource
                datagrid.ItemsSource = dgitemsobscollection;

                //Se crea el Tabitem
                TabItem tbitem = Generic.ManageTabItem.CreateTabItemDataGrid(opcion, tabitemauxiliares);

                //Se añade el DataGridUserControl al TabItem
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