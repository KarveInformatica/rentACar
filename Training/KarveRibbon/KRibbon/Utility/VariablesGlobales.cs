using KRibbon;
using KRibbon.Model;
using KRibbon.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace KRibbon.Utility
{
    public class VariablesGlobales
    {
        /// <summary>
        /// Enumeración de los tipos de auxiliares
        /// </summary>
        public enum ETipoAuxiliar
        {
            #region Auxiliares Clientes
            //Banco,
            //BloqueFacturacion,
            //CanalCliente,
                rbttBancosClientes,
                rbttBloqueFacturacion,
                rbttCanales,
                rbttCargosPersonal,
            #endregion

            #region Auxiliares Comisionistas
                rbttTipoComisionista,
            #endregion

            #region Auxiliares Contratos
            #endregion

            #region Auxiliares Proveedores
                rbttFormasPagoProveedor,
            #endregion

            #region Auxiliares Reservas        
            #endregion

            #region Auxiliares Tarifas
                rbttGruposTarifa 
            #endregion

            #region Auxiliares Vehículos
            #endregion

            #region Auxiliares Varios
            #endregion
        }

        public static Dictionary<ETipoAuxiliar, TabItem> tabitemdictionary = new Dictionary<ETipoAuxiliar, TabItem>();
        
        ///          
        public static Dictionary<ETipoAuxiliar, TablaAuxiliares> tiposauxiliaresdictionary = new Dictionary<ETipoAuxiliar, TablaAuxiliares>()
        {
            #region Auxiliares Clientes
            { ETipoAuxiliar.rbttBancosClientes,     new TablaAuxiliares { propertiesresources = Resources.lrbttBancosClientes,       nombretabladb = "BANCO" } },
            { ETipoAuxiliar.rbttBloqueFacturacion,  new TablaAuxiliares { propertiesresources = Resources.lrbttBloqueFacturacion,    nombretabladb = "BLOQUEFAC" } },
            { ETipoAuxiliar.rbttCanales,            new TablaAuxiliares { propertiesresources = Resources.lrbttCanales,              nombretabladb = "CANAL" } },
            { ETipoAuxiliar.rbttCargosPersonal,     new TablaAuxiliares { propertiesresources = Resources.lrbttCargosPersonal,       nombretabladb = "CATEGOPER" } },
            #endregion

            #region Auxiliares Comisionistas
            { ETipoAuxiliar.rbttTipoComisionista,   new TablaAuxiliares { propertiesresources = Resources.lrbttTipoComisionista,     nombretabladb =  "TIPOCOMI" } },
            #endregion

            #region Auxiliares Contratos
            #endregion

            #region Auxiliares Proveedores
            { ETipoAuxiliar.rbttFormasPagoProveedor, new TablaAuxiliares { propertiesresources = Resources.lrbttFormasPagoProveedor,  nombretabladb = "FORPRO" } },
            #endregion

            #region Auxiliares Reservas
            #endregion

            #region Auxiliares Tarifas
            { ETipoAuxiliar.rbttGruposTarifa,        new TablaAuxiliares { propertiesresources = Resources.lrbttGruposTarifa,         nombretabladb = "GRUPOS_TARI" } }
            #endregion

            #region Auxiliares Vehículos
            #endregion
            
            #region Auxiliares Varios
            #endregion
        };        

        public static ObservableCollection<object> dgitemsobscollection;

        public enum ETiposDatoColumnaDB
        {
            DBstring,
            DBbool,
            DBbyte, //byte en C# = tinyint en la DB
            DBsmallint,
            DBint,
            DBlong,
            DBdecimal,
            DBdouble,
            DBdate,
            DBdatetime,
            DBsmalldatetime,
            DBtime
        }
    }
}
