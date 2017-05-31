using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class FormaPagoProveedorRepository
    {
        private static ObservableCollection<IAuxiliares> formaspagoproveedor;

        public FormaPagoProveedorRepository() { }

        public ObservableCollection<IAuxiliares> GetFormaPagoProveedor()
        {
            if (formaspagoproveedor == null)
                LoadFormaPagoProveedor();
            return formaspagoproveedor;
        }

        private void LoadFormaPagoProveedor()
        {
            formaspagoproveedor = new ObservableCollection<IAuxiliares>()
            {
                new FormaPagoProveedor () { CodigoAux = "1", NombreAux = "CONTADO" },
                new FormaPagoProveedor () { CodigoAux = "2", NombreAux = "RECIBO DOMICILIADO" },
                new FormaPagoProveedor () { CodigoAux = "3", NombreAux = "TRANSFERENCIA" },
                new FormaPagoProveedor () { CodigoAux = "4", NombreAux = "ENVÍO TALÓN" },
                new FormaPagoProveedor () { CodigoAux = "5", NombreAux = "PAGARÉ" },
                new FormaPagoProveedor () { CodigoAux = "0", NombreAux = "NO RECIBO" }
            };
        }
    }
}
