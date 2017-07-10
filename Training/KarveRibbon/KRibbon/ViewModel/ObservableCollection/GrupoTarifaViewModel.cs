using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.Generic.ObservableCollection
{
    public class GrupoTarifaViewModel : PropertyChangedBase
    {
        #region Constructores
        public GrupoTarifaViewModel()
        {
            grupoTarifaObsCollection = new ObservableCollection<GrupoTarifa>();
        }
        public GrupoTarifaViewModel(ObservableCollection<GrupoTarifa> grupoTarifaObsCollection)
        {
            this.grupoTarifaObsCollection = grupoTarifaObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<GrupoTarifa> grupoTarifaObsCollection = new ObservableCollection<GrupoTarifa>();
        public ObservableCollection<GrupoTarifa> GrupoTarifaObsCollection
        {
            get
            {
                return grupoTarifaObsCollection;
            }
            set
            {
                grupoTarifaObsCollection = value;
                OnPropertyChanged("GrupoTarifaObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.grupoTarifaObsCollection.Add((GrupoTarifa)item);
            }
        }
        #endregion
    }
}
