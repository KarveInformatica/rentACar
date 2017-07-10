using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KRibbon.Utility
{
    public class VariablesGlobalesEnumerations
    {
        /// <summary>
        /// Enumeración de los tipos de auxiliares
        /// </summary>
        public enum EOpcion
        {
            #region Maestros
            rbtnBancosClientes,
            rbtnBloqueFacturacion,
            rbtnCanales,
            rbtnCargosPersonal,

            rbtnTipoComisionista,

            rbtnFormaPagoProveedor,

            rbtnGruposTarifa,
            #endregion

            #region Contratos
            #endregion

            #region Reservas
            #endregion

            #region Atipicos
            #endregion

            #region Comercial
            #endregion

            #region Facturación
            #endregion

            #region Flota
            #endregion

            #region Incidencias
            #endregion

            #region Estadísticas
            #endregion

            #region Listados
            #endregion

            #region Configuración
            rbtnCinta,
            #endregion
        }


        /// <summary>
        /// Enumeración de los RibbonTab
        /// </summary>
        public enum ERibbonTab
        {
            tbMaestros,
            tbContratos,
            tbReservas,
            tbAtipicos,
            tbComercial,
            tbFacturacion,
            tbFlota,
            tbIncidencias,
            tbEstadisticas,
            tbListados,
            tbConfiguracion
        }

        /// <summary>
        /// Enumeración con los tipos de datos de las columnas de la BBDD
        /// </summary>
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
