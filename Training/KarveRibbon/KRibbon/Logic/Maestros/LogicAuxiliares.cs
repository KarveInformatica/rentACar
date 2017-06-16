using KRibbon.Model;
using KRibbon.Model.Generic;
using KRibbon.Model.Sybase;
using KRibbon.Utility;
using static KRibbon.Utility.VariablesGlobales;
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
using KRibbon.Commands.Specific;
using KRibbon.ViewModel;

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
                //Se crea el Tabitem
                TabItem tbitem = createTabItem(tipoauxiliar);

                datagriditemsobscollection = new ObservableCollection<object>();
                string tablaauxiliares = tiposauxiliaresdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value.nombretabladb;

                switch (tipoauxiliar)
                {
                    #region case Auxiliares Clientes
                    case ETipoAuxiliar.rbttBancosClientes:
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, Banco.dbcriterioslist, new Banco());
                        loadDataGrid(tbitem, datagriditemsobscollection, Banco.dbcriterioslist);
                        break;
                    case ETipoAuxiliar.rbttBloqueFacturacion:
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, BloqueFacturacion.dbcriterioslist, new BloqueFacturacion());
                        loadDataGrid(tbitem, datagriditemsobscollection, BloqueFacturacion.dbcriterioslist);
                        break;
                    case ETipoAuxiliar.rbttCanales:
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CanalCliente.dbcriterioslist, new CanalCliente());
                        loadDataGrid(tbitem, datagriditemsobscollection, CanalCliente.dbcriterioslist);
                        break;
                    case ETipoAuxiliar.rbttCargosPersonal:                        
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, CargoPersonal.dbcriterioslist, new CargoPersonal());
                        loadDataGrid(tbitem, datagriditemsobscollection, CargoPersonal.dbcriterioslist);
                        break;
                    #endregion
                    #region case Auxiliares Comisionistas
                    case ETipoAuxiliar.rbttTipoComisionista:
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, TipoComisionista.dbcriterioslist, new TipoComisionista());
                        loadDataGrid(tbitem, datagriditemsobscollection, TipoComisionista.dbcriterioslist);
                        break;
                    #endregion
                    #region case Auxiliares Contratos
                    #endregion
                    #region case Auxiliares Proveedor
                    case ETipoAuxiliar.rbttFormasPagoProveedor:                        
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, FormaPagoProveedor.dbcriterioslist, new FormaPagoProveedor());
                        loadDataGrid(tbitem, datagriditemsobscollection, FormaPagoProveedor.dbcriterioslist);
                        break;
                    #endregion
                    #region case Auxiliares Reservas
                    #endregion
                    #region case Auxiliares Tarifas
                    case ETipoAuxiliar.rbttGruposTarifa:
                        datagriditemsobscollection = AuxiliaresModel.GetAuxiliares(tablaauxiliares, GrupoTarifa.dbcriterioslist, new GrupoTarifa());
                        loadDataGrid(tbitem, datagriditemsobscollection, GrupoTarifa.dbcriterioslist);
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
            {   //Si el TabItem del tipo de auxiliar ya se está mostrado, no se carga
                //de nuevo, simplemente se establece el foco en ese TabItem
                TabItem tabitem = tabitemdictionary.Where(z => z.Key == tipoauxiliar).FirstOrDefault().Value;
                tabitem.Focus();
            }
        }

        /// <summary>
        /// Elimina un TabItem del TabControl según el tipo de auxiliar que recibe por param.
        /// </summary>
        /// <param name="tipoauxiliar"></param>
        public static void removeTabItem(ETipoAuxiliar tipoauxiliar)
        {
            TabItem tbitem = tabitemdictionary.Where(z => z.Key.ToString() == tipoauxiliar.ToString()).FirstOrDefault().Value;

            if(tbitem != null)
            {
                ((MainWindow)Application.Current.MainWindow).tbControl.Items.Remove(tbitem);
                tabitemdictionary.Remove(tipoauxiliar);
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

            tabitemdictionary.Add(tipoauxiliar, tbitem);            

            ((MainWindow)Application.Current.MainWindow).tbControl.Items.Add(tbitem);
            tbitem.Focus();
            return tbitem;
        }

        /// <summary>
        /// Carga los datos de una ObservableCollection (datagriditemsobscollection) en un Datagrid dentro del TabItem (tbitem) recibido por parámetros.
        /// Tiene en cuenta el nombre de las propiedades (dbcriterioslist.nombrepropiedadobj) del objeto que debe cargar.
        /// </summary>
        /// <param name="tbitem"></param>
        /// <param name="datagriditemslist"></param>
        /// <param name="dbcriterioslist"></param>
        private static void loadDataGrid(TabItem tbitem, ObservableCollection<object> datagriditemslist, List<DBCriterios> dbcriterioslist)
        {            
            //Creamos el DataGrid
            DataGrid datagrid = new DataGrid();
            datagrid.HorizontalAlignment = HorizontalAlignment.Left;
            datagrid.AlternatingRowBackground = Brushes.LightGray;

            //Creamos los DataGridTextColumn
            DataGridTextColumn col;

            foreach (var item in dbcriterioslist)
            {
                col = new DataGridTextColumn();
                col.Header = item.datagridheader;
                col.Binding = new Binding(item.nombrepropiedadobj);
                datagrid.Columns.Add(col);
            }

            //Añadimos los valores al Datagrid
            foreach (var item in datagriditemslist)
            {
                datagrid.Items.Add(item);
            }
            tbitem.Content = datagrid;
        }
    }
}