using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class TipoComisionista : IAuxiliares
    {
        #region Propiedades
        private string codigoAux;
        public string CodigoAux
        {
            get
            {
                return codigoAux;
            }
            set
            {
                codigoAux = value;
                OnPropertyChanged("CodigoAux");
            }
        }

        private string nombreAux;
        public string NombreAux
        {
            get
            {
                return nombreAux;
            }
            set
            {
                nombreAux = value;
                OnPropertyChanged("NombreAux");
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
