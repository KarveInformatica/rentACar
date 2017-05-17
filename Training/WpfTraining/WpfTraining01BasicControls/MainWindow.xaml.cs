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

namespace WpfTraining01BasicControls
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //pnlMainGrid.MouseUp += new MouseButtonEventHandler(pnlMainGrid_MouseUp);
            #region Formatting text from code-behind   
            /*TextBlock tb = new TextBlock();
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Margin = new Thickness(10);
            tb.Inlines.Add("An example on ");
            tb.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
            tb.Inlines.Add("using ");
            tb.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });
            tb.Inlines.Add(new Run("text formatting ") { Foreground = Brushes.Blue });
            tb.Inlines.Add("from ");
            tb.Inlines.Add(new Run("Code-Behind") { TextDecorations = TextDecorations.Underline });
            tb.Inlines.Add(".");
            this.Content = tb;*/
            #endregion
        }
        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }
        //private void btnClickMe_Click(object sender, RoutedEventArgs e)
        //{
        //    lbResult.Items.Add(pnlMain.FindResource("strPanel").ToString());
        //    lbResult.Items.Add(this.FindResource("strWindow").ToString());
        //    lbResult.Items.Add(Application.Current.FindResource("strApp").ToString());
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A handled exception just occurred: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //s.Trim();
        }
        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
        //private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;
        //    txtStatus.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
        //    txtStatus.Text += "Selection is " + textBox.SelectionLength + " character(s) long" + Environment.NewLine;
        //    txtStatus.Text += "Selected text: '" + textBox.SelectedText + "'";
        //}
        //private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    bool newVal = (cbAllFeatures.IsChecked == true);
        //    cbFeatureAbc.IsChecked = newVal;
        //    cbFeatureXyz.IsChecked = newVal;
        //    cbFeatureWww.IsChecked = newVal;
        //}
        //private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        //{
        //    cbAllFeatures.IsChecked = null;
        //    if ((cbFeatureAbc.IsChecked == true) && (cbFeatureXyz.IsChecked == true) && (cbFeatureWww.IsChecked == true))
        //        cbAllFeatures.IsChecked = true;
        //    if ((cbFeatureAbc.IsChecked == false) && (cbFeatureXyz.IsChecked == false) && (cbFeatureWww.IsChecked == false))
        //        cbAllFeatures.IsChecked = false;
        //}

    }
}
