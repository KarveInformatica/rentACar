using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace KRibbon.Logic.Maestros
{
    class KarveDataGridTextColumn: DataGridTextColumn
    {
        private string datagridheader;

        public KarveDataGridTextColumn() : base() { }

        public KarveDataGridTextColumn(string datagridheader) : base()
        {
            base.Header = datagridheader;
        }

        public object Header
        {
            get
            {
                return base.Header;
            }
            set
            {
                base.Header = value;
                OnPropertyChanged("Header");
            }
        }

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
