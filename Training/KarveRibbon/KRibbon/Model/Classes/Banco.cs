﻿using KRibbon.Model.Generic;
using KRibbon.Properties;
using System.Collections.Generic;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Model.Classes
{
    public class Banco : GenericPropertyChanged, lControlCambioDataGrid
    {
        #region List<DBCriterios>
        public static List<TemplateInfoDB> templateinfodb = new List<TemplateInfoDB>()
        {
            new TemplateInfoDB(){ nombrepropiedadobj = "Codigo",
                                  nombrecolumnadb    = "CODBAN",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcCodigo },
            new TemplateInfoDB(){ nombrepropiedadobj = "Nombre",
                                  nombrecolumnadb    = "NOMBRE",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcDefinicion },
            new TemplateInfoDB(){ nombrepropiedadobj = "Swift",
                                  nombrecolumnadb    = "SWIFT",
                                  tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                                  datagridheader     = Resources.dttcBicSwift }
        };
        #endregion

        #region Constructores
        public Banco() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
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

        private EControlCambioDataGrid controlcambiodatagrid;
        public EControlCambioDataGrid ControlCambioDataGrid
        {
            get { return controlcambiodatagrid; }
            set
            {
                controlcambiodatagrid = value;
                OnPropertyChanged("ControlCambioDataGrid");
            }
        }
        #endregion
    }
}
