using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class TipoComisionistaRepository
    {
        private static ObservableCollection<IAuxiliares> tiposcomisionista;

        public TipoComisionistaRepository() { }

        public ObservableCollection<IAuxiliares> GetTiposComisionista()
        {
            if (tiposcomisionista == null)
                LoadTiposComisionista();
            return tiposcomisionista;
        }

        private void LoadTiposComisionista()
        {
            tiposcomisionista = new ObservableCollection<IAuxiliares>()
            {
                new TipoComisionista () { CodigoAux = "1", NombreAux = "GENERAL" },
                new TipoComisionista () { CodigoAux = "2", NombreAux = "AGENCIA DE VIAJES" },
                new TipoComisionista () { CodigoAux = "3", NombreAux = "TALLER MECÁNICO" },
                new TipoComisionista () { CodigoAux = "4", NombreAux = "HOTEL" },
                new TipoComisionista () { CodigoAux = "5", NombreAux = "EMPRESAS DEL GRUPO" }
            };
        }
    }
}
