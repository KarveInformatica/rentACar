using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MadeInBlend
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Insert code required on object creation below this point.
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //myButton.Content = "Please do not click this again!";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //figure.Stroke = new SolidColorBrush(Colors.Red);
            //figure.Fill = new SolidColorBrush(Colors.Yellow);
        }
    }
}
