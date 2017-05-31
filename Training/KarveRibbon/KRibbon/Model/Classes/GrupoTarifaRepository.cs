using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace KRibbon.Model
{
    public class GrupoTarifaRepository
    {
        private static ObservableCollection<IAuxiliares> grupostarifa;

        public GrupoTarifaRepository() { }

        public ObservableCollection<IAuxiliares> GetGruposTarifa()
        {
            if (grupostarifa == null)
                LoadGruposTarifa();
            return grupostarifa;
        }

        private void LoadGruposTarifa()
        {
            grupostarifa = new ObservableCollection<IAuxiliares>()
            {
                new GrupoTarifa () { CodigoAux = "C", NombreAux = "CORPORATIVAS" },
                new GrupoTarifa () { CodigoAux = "I", NombreAux = "INDUSTRIALES" },
                new GrupoTarifa () { CodigoAux = "O", NombreAux = "OCIO" },
                new GrupoTarifa () { CodigoAux = "R", NombreAux = "REPOSICION" },
                new GrupoTarifa () { CodigoAux = "T", NombreAux = "TURISMO" }
            };
        }
    }
}
