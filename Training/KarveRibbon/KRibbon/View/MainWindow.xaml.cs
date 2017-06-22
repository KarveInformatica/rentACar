using Microsoft.Windows.Controls.Ribbon;
using KRibbon.Properties;
using KRibbon.Utility;
using KRibbon.Logic.Generic;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Threading;
using System.Globalization;
using KRibbon.Model.Sybase;
using System.Collections.Generic;
using System.Windows.Controls;

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
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
            //AddTab.addRibbonTabAcciones(rbInicio);
            //AddTab.addRibbonTabFavoritos(rbInicio, this);

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                this.stInicio.Text = "Aquí ponemos algún texto, p.e.: " + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss");
                this.Title = "Aquí ponemos algún texto, p.e.: KarveWin[Versión: " 
                            + DateTime.Now.ToString("dd/MMMM/yyyy HH:mm:ss" + "]         C1[PRUEBA, S.A].USUARIO: JORDI");
            }, this.Dispatcher);
        }


        public void bttHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí va nuestro mensaje de ayuda", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region RibbonGroup Drag and Drop
        private void RibbonGroup_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var ribbongroup = e.Source as RibbonGroup;

                if (ribbongroup == null)
                    return;

                if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(ribbongroup, ribbongroup, DragDropEffects.All);
                }
            }
            catch (Exception) { }            
        }

        private void RibbonGroup_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var ribbongrouptarget = e.Source as RibbonGroup;
                var ribbongroupsource = e.Data.GetData(typeof(RibbonGroup)) as RibbonGroup;

                if (!ribbongrouptarget.Equals(ribbongroupsource))
                {
                    var ribbontab = ribbongrouptarget.Parent as RibbonTab;
                    int sourceIndex = ribbontab.Items.IndexOf(ribbongroupsource);
                    int targetIndex = ribbontab.Items.IndexOf(ribbongrouptarget);

                    ribbontab.Items.Remove(ribbongroupsource);
                    ribbontab.Items.Insert(targetIndex, ribbongroupsource);

                    ribbontab.Items.Remove(ribbongrouptarget);
                    ribbontab.Items.Insert(sourceIndex, ribbongrouptarget);
                }
            }
            catch (Exception) { }
        }
        #endregion
    }
}
