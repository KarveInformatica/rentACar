using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using KRibbon.ViewModel;
namespace KRibbon.ViewModel.Generic
{

    class BanksViewModel: PropertyChangedBase
    {
        private ObservableCollection<Banco> auxBanksList = new ObservableCollection<Banco>();
        public BanksViewModel()
        {
            auxBanksList  = new ObservableCollection<Banco>();
        }

        //ObservableCollection<Banco> Banks get 
        //{
        //}

    }
}
