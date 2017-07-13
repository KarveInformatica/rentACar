﻿using KRibbon.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static KRibbon.Model.Generic.RecopilatorioCollections;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Utility
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
                opcion = tabitemdictionary.Where(t => t.Key.ToString() == tabitem.Name.ToString()).FirstOrDefault().Key;
                return opcion;
            }
            catch (Exception) { }

            return opcion;
        }
    }
}
