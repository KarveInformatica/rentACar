﻿using KRibbon.Properties;
using KRibbon.ViewModel.Generic;
using System.Collections.Generic;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.ViewModel
{
    public class Banco : PropertyChangedBase
    {
        #region List<DBCriterios>
        public static List<DBCriterios> dbcriterioslist = new List<DBCriterios>()
        {
            new DBCriterios(){ nombrepropiedadobj = "Codigo",
                               nombrecolumnadb    = "CODBAN",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcCodigo },
            new DBCriterios(){ nombrepropiedadobj = "Nombre",
                               nombrecolumnadb    = "NOMBRE",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcDefinicion },
            new DBCriterios(){ nombrepropiedadobj = "Swift",
                               nombrecolumnadb    = "SWIFT",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcBicSwift }
        };
        #endregion

        #region Constructores
        public Banco() { }
        public Banco(string codigo, string nombre, string swift)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.swift  = swift;
        }
        #endregion

        #region Propiedades
        private string codigo;
        public string Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                OnPropertyChanged("Codigo");
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }


        private string swift;
        public string Swift
        {
            get { return swift; }
            set
            {
                swift = value;
                OnPropertyChanged("Swift");
            }
        }
        #endregion
    }
}
