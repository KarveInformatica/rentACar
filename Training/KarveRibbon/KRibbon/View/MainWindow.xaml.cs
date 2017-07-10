﻿using KRibbon.Utility;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Windows.Controls.Ribbon;
using KRibbon.Model.Sybase;

namespace KRibbon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        //public static RibbonWindow ribbonWindow = new RibbonWindow()
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.stInicio.Text = "Aquí ponemos algún texto, p.e.: " + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss");
                this.Title = "Aquí ponemos algún texto, p.e.: KarveWin[Versión: " 
                            + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss" + "]         C1[PRUEBA, S.A].USUARIO: JORDI");
            }, this.Dispatcher);

            //Carga la configuración personalizada del usuario (idioma y RibbonTabs/RibbonGroups). En caso que no exista configuración personalizada,
            //se cargará la configuración por defecto según app.exe.config y VariablesGlobales.ribbontabdefaultdictionary
            UserConfig.LoadCurrentUserRibbonTabConfig();
        }

        public void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí va nuestro mensaje de ayuda", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region RibbonGroup Drag&Drop
        private void RibbonGroup_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            RibbonGroupDragDrop.RibbonGroup_PreviewMouseMove(sender, e);
        }

        private void RibbonGroup_Drop(object sender, DragEventArgs e)
        {
            RibbonGroupDragDrop.RibbonGroup_Drop(sender, e);
        }
        #endregion

        #region Cierre de la Applicación
        private void mainwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Logic.Generic.CloseWindow.closeWindow(sender, e);
        }
        #endregion
    }
}
