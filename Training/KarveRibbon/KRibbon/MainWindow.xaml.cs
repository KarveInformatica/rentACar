using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KRibbon
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {                       
            this.WindowState = WindowState.Maximized;            
            InitializeComponent();
            //addTab();
            addTabAcciones();
        }

        private void addTabAcciones()
        {
            var list = new ObservableCollection<myRibbonButton>();         
            list.Add(new myRibbonButton { Label = "Nuevo", KeyTip = "N", Img = "new", Name = "btttbitNuevo" });
            list.Add(new myRibbonButton { Label = "Guardar", KeyTip = "G", Img = "save", Name = "btttbitGuardar" });
            list.Add(new myRibbonButton { Label = "Cancelar", KeyTip = "B", Img = "cancel", Name = "btttbitCancelar" });
            list.Add(new myRibbonButton { Label = "Imprimir", KeyTip = "I", Img = "print", Name = "btttbitImprimir" });
            list.Add(new myRibbonButton { Label = "Eliminar", KeyTip = "D", Img = "delete", Name = "btttbitEliminar" });
            list.Add(new myRibbonButton { Label = "Siguiente", KeyTip = "S", Img = "next", Name = "btttbitSiguiente" });
            list.Add(new myRibbonButton { Label = "Anterior", KeyTip = "A", Img = "previous", Name = "btttbitAnterior" });
            list.Add(new myRibbonButton { Label = "Salir", KeyTip = "Q", Img = "exit", Name = "btttbitSalir" });

            RibbonTab tbAcciones = new RibbonTab();
            tbAcciones.SetValue(FrameworkElement.NameProperty, "tbAcciones");
            tbAcciones.Header = "Acciones";
            tbAcciones.KeyTip = "N";

            RibbonGroup tbgrAcciones = new RibbonGroup();
            tbgrAcciones.SetValue(FrameworkElement.NameProperty, "tbgrAcciones");
            tbgrAcciones.Header = "Acciones";

            RibbonButton rbButton = null;
            foreach (myRibbonButton item in list)
            {
                rbButton = new RibbonButton();
                rbButton.Label = item.Label;
                rbButton.KeyTip = item.KeyTip;
                rbButton.LargeImageSource = new BitmapImage(new Uri(@"Images\" + item.Img + ".png", UriKind.Relative));
                rbButton.SetValue(FrameworkElement.NameProperty, item.Name);
                tbgrAcciones.Items.Add(rbButton);
            }

            tbAcciones.Items.Add(tbgrAcciones);
            //rbInicio.Items.Add(tbAcciones); //Añade la Tab al final del todo
            rbInicio.Items.Insert(0, tbAcciones); //añade la Tab en la posición que deseemos
        }

        private void addTab()
        {
            Random rd = new Random();
            RibbonTab mytab = new RibbonTab();
            RibbonGroup mygroup = null;
            RibbonMenuButton mymenu = null;
            RibbonButton mybutton = null;
            mytab.Header = "Favoritos";

            for (int i = 0; i < 5; i++)
            {
                mygroup = new RibbonGroup();
                mygroup.Header = "Grupo " + (i + 1);
                int aux = rd.Next(1, 7);

                for (int j = 0; j < aux; j++)
                {
                    if (j == 3)
                    {
                        mymenu = new RibbonMenuButton();
                        mymenu.Label = "MenuButton " + (j + 1);
                        mymenu.LargeImageSource = new BitmapImage(new Uri(@"Images\new.png", UriKind.Relative));

                        mybutton = new RibbonButton();
                        mybutton.Label = "Button " + (j + 1);
                        mybutton.SmallImageSource = new BitmapImage(new Uri(@"Images\open.png", UriKind.Relative));

                        mymenu.Items.Add(mybutton);
                        mygroup.Items.Add(mymenu);
                    }
                    else
                    {
                        mybutton = new RibbonButton();
                        mybutton.Label = "Button " + (j + 1);
                        mybutton.SmallImageSource = new BitmapImage(new Uri(@"Images\open.png", UriKind.Relative));
                        mybutton.SetValue(FrameworkElement.NameProperty, "bttButton");
                        mybutton.Click += new RoutedEventHandler(this.bttHelp_Click);

                        mygroup.Items.Add(mybutton);
                    }
                }
                mytab.Items.Add(mygroup);
            }
            rbInicio.Items.Add(mytab);
        }

        private void bttHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mensaje de Ayuda y tal y tal", "Ayuda", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void bttSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void bttButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mi bttButton");
        }

        #region ToggleButton Expand/Collapse Ribbon
        /*private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = FindVisualChildByName<ContentControl>(rbInicio, "mainItemsPresenterHost");
            contentControl.Visibility = System.Windows.Visibility.Collapsed;
            var image = new Image();
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri("Images/expand.png", UriKind.Relative);
            bmi.EndInit();
            image.Source = bmi;
            tgbttExpandCollase.Content = image;
            tgbttExpandCollase.ToolTip = "Expande la cinta";
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            ContentControl contentControl = FindVisualChildByName<ContentControl>(rbInicio, "mainItemsPresenterHost");
            contentControl.Visibility = System.Windows.Visibility.Visible;
            //var tb = new ToggleButton();
            var image = new Image();
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri("Images/collapse.png", UriKind.Relative);
            bmi.EndInit();
            image.Source = bmi;
            tgbttExpandCollase.Content = image;
            tgbttExpandCollase.ToolTip = "Contrae la cinta";
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
        public class myRibbonButton
    {
        string label;
        string keytip;
        string img;
        string name;

        public myRibbonButton() { }

        public string Label { get { return label; } set { label = value; } }
        public string KeyTip { get { return keytip; } set { keytip = value; } }
        public string Img { get { return img; } set { img = value; } }
        public string Name { get { return name; } set { name = value; } }
    }
}
