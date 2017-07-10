﻿using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace KRibbon.Utility
{
    public class DatosAyudaTabItem
    {
        #region Constructores
        public DatosAyudaTabItem() { }

        public DatosAyudaTabItem(ObservableCollection<object> obscollectionsource)
        {
            this.obscollectionsource = obscollectionsource;
        }

        public DatosAyudaTabItem(ObservableCollection<object> obscollectionsource, TabItem tbitem)
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
