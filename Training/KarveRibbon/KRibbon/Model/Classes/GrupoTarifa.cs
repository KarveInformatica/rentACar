using KRibbon.Properties;
using KRibbon.Model.Generic;
using static KRibbon.Utility.VariablesGlobales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class GrupoTarifa : PropertyChangedBase//, IAuxiliares
    {       
        #region List<DBCriterios>
        public static List<DBCriterios> dbcriterioslist = new List<DBCriterios>()
        {
            new DBCriterios(){ nombrepropiedadobj = "Codigo",
                               nombrecolumnadb    = "COD_GT",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcCodigo },
            new DBCriterios(){ nombrepropiedadobj = "Nombre",
                               nombrecolumnadb    = "NOMBRE",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcDefinicion },
            new DBCriterios(){ nombrepropiedadobj = "UltModi",
                               nombrecolumnadb    = "ULTMODI",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcUltModi }
        };
        #endregion

        #region Constructores
        public GrupoTarifa() { }
        public GrupoTarifa(string codigoAux, string nombre, string ultmodi)
        {
            this.codigo = codigoAux;
            this.nombre = nombre;
            this.ultmodi = ultmodi;
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

        private string ultmodi;
        public string UltModi
        {
            get { return ultmodi; }
            private set
            {
                ultmodi = value;
                OnPropertyChanged("UltModi");
            }
        }
        #endregion
    }
}
