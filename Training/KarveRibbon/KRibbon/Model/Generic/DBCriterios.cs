﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KRibbon.Utility.VariablesGlobales;

namespace KRibbon.Model.Generic
{
    /// <summary>
    /// Criterios para los campos de la datagrid, y de su correspondiente campo en la DB:<para/>
    /// nombrepropiedadobj -> nombre de la propiedad dentro del objeto<para/>
    /// nombrecolumnadb    -> nombre de la columna en la DB<para/>
    /// tipodatocolumnadb  -> tipo de dato de la columna en la DB<para/>
    /// datagridheader     -> header de la columna del datagrid que mostrará los datos devueltos desde la DB<para/>
    /// </summary>
    public class DBCriterios
    {
        public string nombrepropiedadobj { get; set; }
        public string nombrecolumnadb { get; set ; }
        public ETiposDatoColumnaDB tipodatocolumnadb { get; set; }
        public string datagridheader { get; set; }  
    }
}