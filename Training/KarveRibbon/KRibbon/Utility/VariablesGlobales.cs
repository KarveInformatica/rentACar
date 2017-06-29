using KRibbon;
using KRibbon.Model;
using KRibbon.Properties;
using KRibbon.Model.Generic.ObservableCollection;
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
                rbtnBancosClientes,
                rbtnBloqueFacturacion,
                rbtnCanales,
                rbtnCargosPersonal,
            #endregion

            #region Auxiliares Comisionistas
                rbtnTipoComisionista,
            #endregion

            #region Auxiliares Contratos
            #endregion

            #region Auxiliares Proveedores
                rbtnFormaPagoProveedor,
            #endregion

            #region Auxiliares Reservas        
            #endregion

            #region Auxiliares Tarifas
                rbtnGruposTarifa 
            #endregion

            #region Auxiliares Vehículos
            #endregion

            #region Auxiliares Varios
            #endregion
        }

        public static Dictionary<ETipoAuxiliar, TabItemAuxiliares> tabitemlist = new Dictionary<ETipoAuxiliar,TabItemAuxiliares>();
        
        public static Dictionary<ETipoAuxiliar, TablaAuxiliares> tiposauxiliaresdictionary = new Dictionary<ETipoAuxiliar, TablaAuxiliares>()
        {
            #region Auxiliares Clientes
            { ETipoAuxiliar.rbtnBancosClientes,     new TablaAuxiliares { propertiesresources = "lrbtnBancosClientes",
                                                                          nombretabladb = "BANCO",
                                                                          viewmodelbase = new BancoViewModel() } },
            { ETipoAuxiliar.rbtnBloqueFacturacion,  new TablaAuxiliares { propertiesresources = "lrbtnBloqueFacturacion",
                                                                          nombretabladb = "BLOQUEFAC",
                                                                          viewmodelbase = new BloqueFacturacionViewModel() } },
            { ETipoAuxiliar.rbtnCanales,            new TablaAuxiliares { propertiesresources = "lrbtnCanales",
                                                                          nombretabladb = "CANAL",
                                                                          viewmodelbase = new CanalClienteViewModel() } },
            { ETipoAuxiliar.rbtnCargosPersonal,     new TablaAuxiliares { propertiesresources = "lrbtnCargosPersonal",
                                                                          nombretabladb = "CATEGOPER",
                                                                          viewmodelbase = new CargoPersonalViewModel() } },
            #endregion

            #region Auxiliares Comisionistas
            { ETipoAuxiliar.rbtnTipoComisionista,   new TablaAuxiliares { propertiesresources = "lrbtnTipoComisionista",
                                                                          nombretabladb =  "TIPOCOMI",
                                                                          viewmodelbase = new TipoComisionistaViewModel() } },
            #endregion

            #region Auxiliares Contratos
            #endregion

            #region Auxiliares Proveedores
            { ETipoAuxiliar.rbtnFormaPagoProveedor, new TablaAuxiliares { propertiesresources = "lrbtnFormaPagoProveedor",
                                                                          nombretabladb = "FORPRO",
                                                                          viewmodelbase = new FormaPagoProveedorViewModel() } },
            #endregion

            #region Auxiliares Reservas
            #endregion

            #region Auxiliares Tarifas
            { ETipoAuxiliar.rbtnGruposTarifa,       new TablaAuxiliares { propertiesresources = "lrbtnGruposTarifa",
                                                                          nombretabladb = "GRUPOS_TARI",
                                                                          viewmodelbase = new GrupoTarifaViewModel() } },
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
