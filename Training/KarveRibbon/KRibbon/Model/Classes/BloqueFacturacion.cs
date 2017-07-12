using KRibbon.Model.Generic;
using KRibbon.Properties;
using System.Collections.Generic;
using static KRibbon.Logic.Generic.Propiedades.VariablesGlobalesEnumerations;

namespace KRibbon.Model.Classes
{
    public class BloqueFacturacion : PropertyChangedBase
    {
        #region List<DBCriterios>
        public static List<DBCriterios> dbcriterioslist = new List<DBCriterios>()
        {
            new DBCriterios(){ nombrepropiedadobj = "Codigo",
                               nombrecolumnadb    = "CODIGO",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcCodigo },
            new DBCriterios(){ nombrepropiedadobj = "Nombre",
                               nombrecolumnadb    = "NOMBRE",
                               tipodatocolumnadb  = ETiposDatoColumnaDB.DBstring,
                               datagridheader     = Resources.dttcDefinicion }
        };
        #endregion

        #region Constructores
        public BloqueFacturacion() { }
        public BloqueFacturacion(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
        #endregion

        #region Propiedades
        private string codigo;
        public string Codigo
        {
            get  { return codigo; }
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
        #endregion
    }
}
