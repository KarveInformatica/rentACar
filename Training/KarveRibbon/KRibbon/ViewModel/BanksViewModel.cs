using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using KRibbon.Model;
namespace KRibbon.ViewModel
{

    class BanksViewModel: ViewModelBase
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
