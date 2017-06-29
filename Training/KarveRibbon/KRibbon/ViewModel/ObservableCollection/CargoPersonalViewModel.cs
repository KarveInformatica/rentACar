using KRibbon.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model.Generic.ObservableCollection
{
    public class CargoPersonalViewModel : PropertyChangedBase
    {
        #region Constructores
        public CargoPersonalViewModel()
        {
            cargoPersonalObsCollection = new ObservableCollection<CargoPersonal>();
        }
        public CargoPersonalViewModel(ObservableCollection<CargoPersonal> cargoPersonalObsCollection)
        {
            this.cargoPersonalObsCollection = cargoPersonalObsCollection;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<CargoPersonal> cargoPersonalObsCollection = new ObservableCollection<CargoPersonal>();
        public ObservableCollection<CargoPersonal> CargoPersonalObsCollection
        {
            get
            {
                return cargoPersonalObsCollection;
            }
            set
            {
                cargoPersonalObsCollection = value;
                OnPropertyChanged("CargoPersonalObsCollection");
            }
        }
        #endregion

        #region Metodos
        public void GetCollection(ObservableCollection<object> dgitemsobscollection)
        {
            foreach (var item in dgitemsobscollection)
            {
                this.cargoPersonalObsCollection.Add((CargoPersonal)item);
            }
        }
        #endregion
    }
}
