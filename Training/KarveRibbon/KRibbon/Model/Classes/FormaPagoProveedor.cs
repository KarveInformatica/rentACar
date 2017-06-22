﻿using KRibbon.Properties;
using KRibbon.Model.Generic;
using static KRibbon.Utility.VariablesGlobales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class FormaPagoProveedor //: IAuxiliares
    {
        #region List<DBCriterios>
        public static List<DBCriterios> dbcriterioslist = new List<DBCriterios>()
        {
            new DBCriterios(){ nombrepropiedadobj = "Codigo",
                               nombrecolumnadb    = "CODIGO",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBbyte,
                               datagridheader     = Resources.dttcCodigo },
            new DBCriterios(){ nombrepropiedadobj = "Nombre",
                               nombrecolumnadb    = "NOMBRE",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcDefinicion }
        };
        #endregion

        #region Constructores
        public FormaPagoProveedor() { }
        public FormaPagoProveedor(byte codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        private byte codigo;
        public byte Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        private string nombre;
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
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
