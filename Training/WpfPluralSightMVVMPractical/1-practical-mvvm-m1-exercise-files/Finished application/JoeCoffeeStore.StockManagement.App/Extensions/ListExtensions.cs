using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoeCoffeeStore.StockManagement.App.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumCollection)
        {
            var obsCollection = new ObservableCollection<T>();
            foreach (var item in enumCollection)
                obsCollection.Add(item);
            return obsCollection;
        }

    }
}
