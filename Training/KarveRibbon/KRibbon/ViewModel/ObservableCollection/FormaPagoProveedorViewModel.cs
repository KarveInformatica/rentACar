using KRibbon.Model.Classes;
using KRibbon.Model.Generic;
using System.Collections.ObjectModel;

namespace KRibbon.ViewModel.ObservableCollection
{
    public class FormaPagoProveedorViewModel : PropertyChangedBase
    {
        #region Constructores
        public FormaPagoProveedorViewModel()
        {
            formaPagoProveedorObsCollection = new ObservableCollection<FormaPagoProveedor>();
        }
        public FormaPagoProveedorViewModel(ObservableCollection<FormaPagoProveedor> formaPagoProveedorObsCollection)
        {
            this.formaPagoProveedorObsCollection = formaPagoProveedorObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<FormaPagoProveedor> formaPagoProveedorObsCollection = new ObservableCollection<FormaPagoProveedor>();
        public ObservableCollection<FormaPagoProveedor> FormaPagoProveedorObsCollection
        {
            get
            {
                return formaPagoProveedorObsCollection;
            }
            set
            {
                formaPagoProveedorObsCollection = value;
                OnPropertyChanged("FormaPagoProveedorObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.formaPagoProveedorObsCollection.Add((FormaPagoProveedor)item);
            }
        }
        #endregion
    }
}
