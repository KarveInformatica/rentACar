using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.Generic.ObservableCollection
{
    public class BancoViewModel : PropertyChangedBase
    {
        #region Constructores
        public BancoViewModel()
        {
            bancoObsCollection = new ObservableCollection<Banco>();
        }
        public BancoViewModel(ObservableCollection<Banco> bancoObsCollection)
        {
            this.bancoObsCollection = bancoObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<Banco> bancoObsCollection = new ObservableCollection<Banco>();
        public ObservableCollection<Banco> BancoObsCollection
        {
            get
            {
                return bancoObsCollection;
            }
            set
            {
                bancoObsCollection = value;
                OnPropertyChanged("BancoObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.bancoObsCollection.Add((Banco)item);
            }
        }
        #endregion
    }
}
