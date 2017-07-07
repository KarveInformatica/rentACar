using KRibbon.Utility;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Windows.Controls.Ribbon;

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

            LoadCurrentUserRibbonTabConfig();
            //LoadDefaultRibbonTabConfig();
        }

        public void LoadCurrentUserRibbonTabConfig()
        {
            foreach (var item in VariablesGlobales.ribbontabdefaultdictionary)
            {
                if (item.Value.ribbontab != null)
                {
                    UserConfig.GetCurrentUserRibbonTabConfig(item.Value.ribbontab);
                }
            }
        }

        public void LoadDefaultRibbonTabConfig()
        {
            foreach (var item in VariablesGlobales.ribbontabdefaultdictionary)
            {
                if (item.Value.ribbontab != null)
                {
                    UserConfig.GetDefaultRibbonTabConfig(item.Value.ribbontab);
                }
            }
        }

        public void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí va nuestro mensaje de ayuda", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        #region RibbonGroup Drag&Drop
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
                var target = e.Source as RibbonGroup;
                var origin = e.Data.GetData(typeof(RibbonGroup)) as RibbonGroup;

                if (!target.Equals(origin))
                {
                    var ribbontab = target.Parent as RibbonTab;
                    int originIndex = ribbontab.Items.IndexOf(origin);
                    int targetIndex = ribbontab.Items.IndexOf(target);

                    ribbontab.Items.Remove(origin);
                    ribbontab.Items.Insert(targetIndex, origin);

                    ribbontab.Items.Remove(target);
                    ribbontab.Items.Insert(originIndex, target);

                    UserConfig.SetCurrentUserRibbonTabConfig(ribbontab);
                }
            }
            catch (Exception) { }
        }
        #endregion
    }
}
