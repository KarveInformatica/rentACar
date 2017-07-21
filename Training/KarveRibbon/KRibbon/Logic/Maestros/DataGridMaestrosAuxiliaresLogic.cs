using KRibbon.Model.Generic;
using KRibbon.Utility;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Logic.Maestros
{
    public class DataGridMaestrosAuxiliaresLogic
    {
        /// <summary>
        /// Se marcan como delete la propiedad ControlCambioDataGrid de los SelectedItem del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridDelete(object sender, KeyEventArgs e)
        {
            try
            {
                EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                DataGrid datagrid = tabitem.Content as DataGrid;
                
                if (e.Key == Key.Delete )
                {   //Se consulta si realmente se desea eliminar el registro
                    if (!(MessageBox.Show("Estás seguro?", "Eliminar registros", MessageBoxButton.YesNo) == MessageBoxResult.No))
                    {
                        foreach (var itemdatagrid in datagrid.SelectedItems)
                        {
                            foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                            {   //Se comprueba que el SelectedItem corresponda con el object del GenericObservableCollection
                                if (itemdatagrid == itemobscollection)
                                {   //Se marca como delete la propiedad ControlCambioDataGrid del object del GenericObservableCollection
                                    lControlCambioDataGrid lcontrolcambiodatagrid = itemobscollection as lControlCambioDataGrid;
                                    lcontrolcambiodatagrid.ControlCambioDataGrid = EControlCambioDataGrid.Delete;

                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Se marca como insert/update la propiedad ControlCambioDataGrid del SelectedItem del DataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void DataGridInsertEdit(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {   //Se recupera la EOpcion, el GenericObservableCollection, el TabItem y el DataGrid del TabItem activo
                EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                DataGrid datagrid = tabitem.Content as DataGrid;

                foreach (var itemdatagrid in datagrid.SelectedItems)
                {
                    foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                    {   //Se comprueba que el SelectedItem corresponda con el object del GenericObservableCollection
                        if (itemdatagrid == itemobscollection)
                        {   //Se marca como insert/update según corresponda la propiedad ControlCambioDataGrid
                            //del object del GenericObservableCollection
                            lControlCambioDataGrid lcontrolcambiodatagrid = itemobscollection as lControlCambioDataGrid;
                            lcontrolcambiodatagrid.ControlCambioDataGrid = e.Row.IsNewItem ? EControlCambioDataGrid.Insert : EControlCambioDataGrid.Update;
                            break;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }    
}
