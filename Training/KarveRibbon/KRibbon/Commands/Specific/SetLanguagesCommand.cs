using KRibbon.Commands.Generic;
using KRibbon.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace KRibbon.Commands.Specific
{
    public class SetLanguagesCommand : ICommand
    {
        private SetLanguagesViewModel setlanguagesvm;

        public SetLanguagesCommand(SetLanguagesViewModel vm)
        {
            this.setlanguagesvm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            setlanguagesvm.SetLanguages(parameter);
            ItemCollection collection = ((MainWindow)Application.Current.MainWindow).tbControl.Items;
            foreach (var item in collection)
            {
                TabItem tab = (TabItem)item;
                //string localizedMessage = (string)Application.Current.FindResource("ResourceLanguage");
                //Binding bnd = new Binding("lrbttBancosClientes");
                //bnd.Source = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
                //bnd.Source = new ResourceLanguage("");
                //tab.SetBinding(TextBlock.TextProperty, bnd);
                //tab.Header = ;
            }
        }
    }
}
