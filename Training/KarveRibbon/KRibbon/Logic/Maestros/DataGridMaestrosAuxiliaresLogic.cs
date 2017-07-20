using KRibbon.Model.Generic;
using KRibbon.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;
using KRibbon.Model.Classes;
using System;
using System.Reflection;
using KRibbon.View;

namespace KRibbon.Logic.Maestros
{
    public class DataGridMaestrosAuxiliaresLogic
    {
        public static void DataGridDelete(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Delete)
                {
                    EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                    GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                    TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                    DataGrid datagrid = tabitem.Content as DataGrid;

                    if (!(MessageBox.Show("Estás seguro?", "Eliminar registros", MessageBoxButton.YesNo) == MessageBoxResult.No))
                    {
                        foreach (var itemdatagrid in datagrid.SelectedItems)
                        {
                            foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                            {
                                if (itemdatagrid == itemobscollection)
                                {
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

        public static void DataGridInsertEdit(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                EOpcion opcion = TabControlAndTabItemUtil.TabControlSelectedItemEOpcion();
                GenericObservableCollection auxobscollection = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.GenericObsCollection;
                TabItem tabitem = tabitemdictionary.Where(g => g.Key == opcion).FirstOrDefault().Value.TabItem;
                DataGrid datagrid = tabitem.Content as DataGrid;

                foreach (var itemdatagrid in datagrid.SelectedItems)
                {
                    foreach (var itemobscollection in auxobscollection.GenericObsCollection)
                    {
                        if (itemdatagrid == itemobscollection)
                        {
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
