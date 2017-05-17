using System.Windows;
using System.Windows.Controls;

namespace TextBoxSpellCheck
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            // Xaml:
            //   <TextBox Width="300" SpellCheck.IsEnabled="True" />
            //   <TextBox Height="23" Margin="21,52,21,0" Name="myTextBox" VerticalAlignment="Top" />
            //SpellCheck.SetIsEnabled(myTextBox, true);

            //myTextBox.SpellCheck.IsEnabled = true;
        }
    }
}
