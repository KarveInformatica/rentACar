using KRibbon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model.Generic.ObservableCollection
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
