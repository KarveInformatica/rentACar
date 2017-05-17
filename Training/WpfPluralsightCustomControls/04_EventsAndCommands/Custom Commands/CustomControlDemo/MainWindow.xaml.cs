using CustomControlLib;
using System.Windows;

namespace CustomControlDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ControlCommands.UpdateTextCommand.Execute("Updated from code", _ctrl1);
        }
    }
}
