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

            //Demo purposes only
            //due to how this demo was implemented this code runs after the OnInitialezed
            //of our custom control. Meaning this won;t accurately update the ChildCount value.
            _stackPanel.SetValue(MyCustomControl.IncludeChildCountProperty, true);
            MyCustomControl.SetIncludeChildCount(_stackPanel, true);
        }
    }
}
