using KRibbon.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesCollections;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.Logic.Generic.Metodos
{
    public class TabControlAndTabItemUtil
    {
        /// <summary>
        /// Devuelve el EOpcion del TabItem activo del Tabcontrol
        /// </summary>
        /// <returns></returns>
        public static EOpcion TabControlSelectedItemEOpcion()
        {
            EOpcion opcion = EOpcion.Default;
            try
            {
                TabItem tabitem = ((MainWindow)Application.Current.MainWindow).tbControl.SelectedItem as TabItem;
                TabItem tabitemfocus = tabitemdictionary.Where(t => t.Key.ToString() == tabitem.Name.ToString()).FirstOrDefault().Value.TbItem;
                opcion = tabitemdictionary.Where(t => t.Key.ToString() == tabitem.Name.ToString()).FirstOrDefault().Key;
                return opcion;
            }
            catch (Exception) { }

            return opcion;
        }
    }
}
