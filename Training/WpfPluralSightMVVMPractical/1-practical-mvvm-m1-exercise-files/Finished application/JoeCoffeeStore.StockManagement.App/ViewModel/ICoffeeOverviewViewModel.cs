using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public interface ICoffeeOverviewViewModel
    {
        ObservableCollection<Coffee> Coffees { get; set; }
        Coffee SelectedCoffee { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        ICommand EditCommand { get; set; }
    }
}
