using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace JoeCoffeeStore.StockManagement.App.ViewModel
{
    public interface ICoffeeDetailViewModel
    {
        Coffee SelectedCoffee { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        ICommand SaveCommand { get; set; }
        ICommand DeleteCommand { get; set; }
    }
}
