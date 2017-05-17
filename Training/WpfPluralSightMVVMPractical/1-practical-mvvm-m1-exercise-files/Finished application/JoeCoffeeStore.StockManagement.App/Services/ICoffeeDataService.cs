using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JoeCoffeeStore.StockManagement.App.Services
{
    public interface ICoffeeDataService
    {
        Coffee GetCoffeeDetail(int coffeeId);
        List<Coffee> GetAllCoffees();
        void DeleteCoffee(Coffee coffee);
        void UpdateCoffee(Coffee coffee);
    }
}
