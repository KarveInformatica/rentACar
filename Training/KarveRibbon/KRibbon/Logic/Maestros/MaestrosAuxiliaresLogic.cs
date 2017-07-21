﻿using KRibbon.Logic.Generic;
using KRibbon.Logic.ToolBar;
using KRibbon.Model.Generic;
using KRibbon.Model.Sybase;
using KRibbon.View;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Logic.Maestros
{
    public class MaestrosAuxiliaresLogic
    {
        /// <summary>
        /// Añade un nuevo TabItem al TabControl según la EOpcion que recibe por param. Si el TabItem ya está mostrado, 
        /// no se carga de nuevo, simplemente se establece el foco en ese TabItem.
        /// </summary>
        /// <param name="opcion"></param>
        public static void PrepareTabItemDataGrid(EOpcion opcion)
        {
            if (tabitemdictionary.Where(p => p.Key == opcion).Count() == 0)
            {
                //Se recuperan los datos de la correspondiente tabla de la BBDD según la EOpcion recibida por params
                GenericObservableCollection genericobscollection = MaestrosAuxiliaresModel.GetMaestrosAuxiliares(opcion);
                //Se crea un nuevo DataGrid dentro de un nuevo TabItem con los datos del GenericObservableCollection
                CreateTabItemDataGrid(opcion, genericobscollection);                
            }
            else
            {   //Si el TabItem ya está mostrado, no se carga de nuevo, simplemente se establece el foco en ese TabItem
                tabitemdictionary.Where(z => z.Key == opcion).FirstOrDefault().Value.TabItem.Focus();
            }
        }

        /// <summary>
        /// Añade a un nuevo DataGridUserControl los datos del GenericObservableCollection (genericobscollection) recibido por params. 
        /// El nombre de las propiedades del object del GenericObservableCollection (genericobscollection) corresponderán con los 
        /// respectivos Headers. Se añade el DataGridUserControl en un nuevo TabItem (tbitem).
        /// Se añade el EOpcion, el GenericObservableCollection recibido por params (como origin y copy) y el nuevo TabItem,  
        /// al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="genericobscollection"></param>
        private static void CreateTabItemDataGrid(EOpcion opcion, GenericObservableCollection genericobscollection)
        {
            if (genericobscollection.GenericObsCollection.Count != 0)
            {                
                //Creamos el DataGrid
                DataGridUserControl datagrid = new DataGridUserControl();

                //datagrid.HorizontalAlignment = HorizontalAlignment.Left;
                //datagrid.AlternatingRowBackground = Brushes.WhiteSmoke;
                //datagrid.AutoGenerateColumns = true;
                //datagrid.CanUserAddRows = true;
                //datagrid.CanUserDeleteRows = true;
                //datagrid.IsReadOnly = false;
                //datagrid.SelectionMode = DataGridSelectionMode.Extended;
                //datagrid.SelectionUnit = DataGridSelectionUnit.FullRow;
                //datagrid.CanUserReorderColumns = true;
                //datagrid.CanUserResizeColumns = true;
                //datagrid.CanUserResizeRows = true;
                //datagrid.CanUserSortColumns = true;
                //datagrid.FrozenColumnCount = 1;

                #region Se añade la ObservableCollection<object> directamente como el datagrid.ItemsSource, rellena las columnas según las propiedades que tenga el object, tenga o no tenga datos; el header será el nombre de cada propiedad del object

                //SetTrigger(datagrid);
                #endregion

                #region Se crean los DataGridTextColumn dinámicamente, dándole el nombre al header, y binding cada columna según establecido en la List<DBCriterios> del object; se añade cada columna individualmente al DataGrid
                ////Creamos los DataGridTextColumn
                //DataGridTextColumn column;
                //foreach (var item in templateinfodb)
                //{
                //    //var binding = new Binding();
                //    //binding.Path = new PropertyPath(item.datagridheader);
                //    //binding.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");

                //    column = new DataGridTextColumn();
                //    column.Header = item.datagridheader; //binding.Path;
                //    column.Binding = new Binding(item.nombrepropiedadobj);
                //    datagrid.Columns.Add(column);
                //}

                ////Añadimos los valores al Datagrid
                //foreach (var item in genericobscollection.GenericObsCollection)
                //{
                //    datagrid.Items.Add(item);
                //}
                #endregion

                //datagrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("SelectedItem") { Source = genericobscollection });
                //Se añade al DataGridUserControl el GenericObservableCollection recibido por params como ItemsSource
                datagrid.ItemsSource = genericobscollection.GenericObsCollection;

                //Se crea el Tabitem
                TabItem tabitem = TabItemLogic.CreateTabItemDataGrid(opcion);

                //Se añade el EOpcion, el GenericObservableCollection recibido por params (como origin y copy) y el nuevo TabItem,  
                //al Dictionary de TabItems(tabitemdictionary) que almacena los TabItems activos
                tabitemdictionary.Add(opcion, new TemplateInfoTabItem(genericobscollection, tabitem));

                //Se añade el DataGridUserControl al TabItem
                tabitem.Content = datagrid;

                //Se habilitan/deshabilitan los Buttons del ToolBar según corresponda
                ToolBarLogic.EnabledDisabledToolBarButtonsByEOpcion(opcion);
            }
        }

        public static void SetTrigger(DataGrid contentControl) //***Posiblemente se pueda eliminar este método
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