using KRibbon.Model.Classes;
using KRibbon.Model.Generic;
using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.ObservableCollection
{
    public class TipoComisionistaViewModel : PropertyChangedBase
    {
        #region Constructores
        public TipoComisionistaViewModel()
        {
            tipoComisionistaObsCollection = new ObservableCollection<TipoComisionista>();
        }
        public TipoComisionistaViewModel(ObservableCollection<TipoComisionista> tipoComisionistaObsCollection)
        {
            this.tipoComisionistaObsCollection = tipoComisionistaObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<TipoComisionista> tipoComisionistaObsCollection = new ObservableCollection<TipoComisionista>();
        public ObservableCollection<TipoComisionista> TipoComisionistaObsCollection
        {
            get
            {
                return tipoComisionistaObsCollection;
            }
            set
            {
                tipoComisionistaObsCollection = value;
                OnPropertyChanged("TipoComisionistaObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.tipoComisionistaObsCollection.Add((TipoComisionista)item);
            }
        }
        #endregion
    }
}
