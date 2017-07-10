using KRibbon.Properties;
using KRibbon.ViewModel.Generic;
using System.Collections.Generic;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.ViewModel
{
    public class GrupoTarifa : PropertyChangedBase
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
