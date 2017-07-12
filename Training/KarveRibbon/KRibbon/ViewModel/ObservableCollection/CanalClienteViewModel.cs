using KRibbon.Model.Classes;
using KRibbon.Model.Generic;
using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.ObservableCollection
{
    public class CanalClienteViewModel : PropertyChangedBase
    {
        #region Constructores
        public CanalClienteViewModel()
        {
            canalClienteObsCollection = new ObservableCollection<CanalCliente>();
        }
        public CanalClienteViewModel(ObservableCollection<CanalCliente> canalClienteObsCollection)
        {
            this.canalClienteObsCollection = canalClienteObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<CanalCliente> canalClienteObsCollection = new ObservableCollection<CanalCliente>();
        public ObservableCollection<CanalCliente> CanalClienteObsCollection
        {
            get
            {
                return canalClienteObsCollection;
            }
            set
            {
                canalClienteObsCollection = value;
                OnPropertyChanged("CanalClienteObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.canalClienteObsCollection.Add((CanalCliente)item);
            }
        }
        #endregion
    }
}
