using KRibbon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model.Generic.ObservableCollection
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
