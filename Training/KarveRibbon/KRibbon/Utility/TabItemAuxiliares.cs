using KRibbon.Model.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using static KRibbon.Utility.VariablesGlobales;
using KRibbon.Model.Generic.ObservableCollection;
using System.Collections.ObjectModel;

namespace KRibbon.Utility
{
    public class TabItemAuxiliares
    {
        #region Constructores
        public TabItemAuxiliares() { }

        //public TabItemAuxiliares(ETipoAuxiliar tipoauxiliar, ObservableCollection<object> obscollectionsource)
        //{
        //    this.tipoauxiliar = tipoauxiliar;
        //    this.obscollectionsource = obscollectionsource;
        //}

        //public TabItemAuxiliares(ETipoAuxiliar tipoauxiliar, ObservableCollection<object> obscollectionsource, TabItem tbitem)
        //{
        //    this.tipoauxiliar = tipoauxiliar;
        //    this.obscollectionsource = obscollectionsource;
        //    this.tbitem = tbitem;
        //}

        public TabItemAuxiliares(ObservableCollection<object> obscollectionsource)
        {
            this.obscollectionsource = obscollectionsource;
        }

        public TabItemAuxiliares(ObservableCollection<object> obscollectionsource, TabItem tbitem)
        {
            this.obscollectionsource = obscollectionsource;
            this.tbitem = tbitem;
        }
        #endregion

        #region Propiedades
        private ObservableCollection<object> obscollectionsource;
        public ObservableCollection<object> ObsCollectionSource
        {
            get
            {
                return obscollectionsource;
            }
            set
            {
                obscollectionsource = value;
            }
        }

        private ObservableCollection<object> obscollectioncopy;
        public ObservableCollection<object> ObsCollectionCopy
        {
            get
            {
                return obscollectioncopy;
            }
            set
            {
                obscollectioncopy = value;
            }
        }

        private TabItem tbitem;        
        public TabItem TbItem
        {
            get
            {
                return tbitem;
            }
            set
            {
                tbitem = value;
            }
        }

        private DataGrid datagrid;
        public DataGrid DataGrid
        {
            get
            {
                return datagrid;
            }
            set
            {
                datagrid = value;
            }
        }
        #endregion
    }
}
