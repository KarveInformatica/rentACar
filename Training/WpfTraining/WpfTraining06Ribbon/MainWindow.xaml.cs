using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Windows;
using System.Windows.Input;


using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Threading;
using System.Globalization;

namespace WpfTraining06Ribbon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }      

        #region ToggleButton collapse/Expand
        /*private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = FindVisualChildByName<ContentControl>(Ribbon, "mainItemsPresenterHost");
            contentControl.Visibility = System.Windows.Visibility.Collapsed;
            var image = new Image();
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri("Images/expand.png", UriKind.Relative);
            bmi.EndInit();
            image.Source = bmi;
            pbStations.Content = image;
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = FindVisualChildByName<ContentControl>(Ribbon, "mainItemsPresenterHost");
            contentControl.Visibility = System.Windows.Visibility.Visible;
            //var tb = new ToggleButton();
            var image = new Image();
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri("Images/collapse.png", UriKind.Relative);
            bmi.EndInit();
            image.Source = bmi;
            pbStations.Content = image;
        }

        private T FindVisualChildByName<T>(DependencyObject parent, string name) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                string controlName = child.GetValue(Control.NameProperty) as string;
                if (controlName == name)
                {
                    return child as T;
                }
                else
                {
                    T result = FindVisualChildByName<T>(child, name);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }*/
        #endregion

        #region Ribbon Drag and Drop
        private void Ribbon_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                var ribbongroup = e.Source as RibbonTab;

                if (ribbongroup == null)
                    return;

                if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
                {
                    DragDrop.DoDragDrop(ribbongroup, ribbongroup, DragDropEffects.All);
                }
            }
            catch (Exception) { }
        }

        private void Ribbon_Drop(object sender, DragEventArgs e)
        {
            try
            {
                var ribbongrouptarget = e.Source as RibbonTab;
                var ribbongroupsource = e.Data.GetData(typeof(RibbonTab)) as RibbonTab;

                if (!ribbongrouptarget.Equals(ribbongroupsource))
                {
                    var ribbontab = ribbongrouptarget.Parent as Ribbon;
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