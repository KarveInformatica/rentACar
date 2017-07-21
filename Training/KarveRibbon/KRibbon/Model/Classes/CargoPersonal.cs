using KRibbon.Model.Generic;
using static KRibbon.Model.Generic.RecopilatorioEnumerations;

namespace KRibbon.Model.Classes
{
    public class CargoPersonal : GenericPropertyChanged, lControlCambioDataGrid
    {
        #region Constructores
        public CargoPersonal() { this.ControlCambioDataGrid = EControlCambioDataGrid.Null; }
        public CargoPersonal(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
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
