using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public interface IAuxiliares : INotifyPropertyChanged
    {
        string CodigoAux { get; set; }
        string NombreAux { get; set; }

        event PropertyChangedEventHandler PropertyChanged;
    }
}
