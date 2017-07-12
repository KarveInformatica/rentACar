using KRibbon.Model.Classes;
using KRibbon.Model.Generic;
using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.ObservableCollection
{
    public class BloqueFacturacionViewModel : PropertyChangedBase
    {
        #region Constructores
        public BloqueFacturacionViewModel()
        {
            bloqueFacturacionObsCollection = new ObservableCollection<BloqueFacturacion>();
        }
        public BloqueFacturacionViewModel(ObservableCollection<BloqueFacturacion> bloqueFacturacionObsCollection)
        {
            this.bloqueFacturacionObsCollection = bloqueFacturacionObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<BloqueFacturacion> bloqueFacturacionObsCollection = new ObservableCollection<BloqueFacturacion>();
        public ObservableCollection<BloqueFacturacion> BloqueFacturacionObsCollection
        {
            get
            {
                return bloqueFacturacionObsCollection;
            }
            set
            {
                bloqueFacturacionObsCollection = value;
                OnPropertyChanged("BloqueFacturacionObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.bloqueFacturacionObsCollection.Add((BloqueFacturacion)item);
            }
        }
        #endregion
    }
}
