using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTraining
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
        InitializeComponent();
            //pnlMainGrid.MouseMove += PnlMainGrid_MouseMove;
            /*TextBlock tb = new TextBlock();
             *tb.TextWrapping = TextWrapping.Wrap;
             *tb.Margin = new Thickness(10);
             *tb.Inlines.Add("An example on ");
             *tb.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
             *tb.Inlines.Add("using ");
             *tb.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });
             *tb.Inlines.Add(new Run("text formatting ") { Foreground = Brushes.Blue });
             *tb.Inlines.Add("from ");
             *tb.Inlines.Add(new Run("Code-Behind") { TextDecorations = TextDecorations.Underline });
             *tb.Inlines.Add(".");
             *this.Content = tb;*/
        }

        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{
        //    // Create the interop host control.
        //    System.Windows.Forms.Integration.WindowsFormsHost host =
        //        new System.Windows.Forms.Integration.WindowsFormsHost();

        //    // Create the MaskedTextBox control.
        //    MaskedTextBox mtbDate = new MaskedTextBox(DateTime.Now.ToString());

        //    // Assign the MaskedTextBox control as the host control's child.
        //    host.Child = mtbDate;

        //    // Add the interop host control to the Grid
        //    // control's collection of child controls.
        //    //this.grid1.Children.Add(host);
        //}

        //private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    System.Windows.Forms.MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        //}

        //private void pnlMainGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        //{
        //    System.Windows.Forms.MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        //}

        private void PnlMainGrid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }
        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Items.Clear();
            lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            lbResult.Items.Add(this.FindResource("strWindow").ToString());
            lbResult.Items.Add(System.Windows.Application.Current.FindResource("strApp").ToString());
            cbResult.Items.Clear();
            cbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
            cbResult.Items.Add(this.FindResource("strWindow").ToString());
            cbResult.Items.Add(pnlMain.FindResource("strWindow").ToString());
            cbResult.Items.Add(System.Windows.Application.Current.FindResource("strApp").ToString());
            cbResult.Items.Add(pnlMain.FindResource("strApp").ToString());
        }
        private void btnException_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim(); //Se lanza la exception através del try/catch
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("A HANDLED exception just occurred: \n" + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            s.Trim(); //Se lanza la exception através de App.xaml y la class App            
        }
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            txtStatus.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
            txtStatus.Text += "Selection is " + textBox.SelectionLength + " character(s) long\n"; // \n = Environment.NewLine;
            txtStatus.Text += "Selected text: '" + textBox.SelectedText + "'";
        }

        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = cbAllFeatures.IsChecked == true? true : false;
            cbFeatureAbc.IsChecked = newVal;
            cbFeatureXyz.IsChecked = newVal;
            cbFeatureWww.IsChecked = newVal;
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;
            if ((cbFeatureAbc.IsChecked == true) && (cbFeatureXyz.IsChecked == true) && (cbFeatureWww.IsChecked == true))
                cbAllFeatures.IsChecked = true;
            if ((cbFeatureAbc.IsChecked == false) && (cbFeatureXyz.IsChecked == false) && (cbFeatureWww.IsChecked == false))
                cbAllFeatures.IsChecked = false;
        }
    }    
}

