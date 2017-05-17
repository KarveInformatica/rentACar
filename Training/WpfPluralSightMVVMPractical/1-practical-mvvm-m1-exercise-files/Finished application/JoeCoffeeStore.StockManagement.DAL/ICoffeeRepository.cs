using JoeCoffeeStore.StockManagement.Model;
using System;
using System.Collections.Generic;
namespace JoeCoffeeStore.StockManagement.DAL
{
    public interface ICoffeeRepository
    {
        Coffee GetACoffee();
        List<Coffee> GetCoffees();
        Coffee GetCoffeeById(int id);
        void DeleteCoffee(Coffee coffee);
        void UpdateCoffee(Coffee coffee);
    }
}
