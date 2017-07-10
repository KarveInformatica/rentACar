using KRibbon.ViewModel.Generic.ObservableCollection;
using KRibbon.ViewModel.ConfiguracionViewModel;
using Microsoft.Windows.Controls.Ribbon;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using static KRibbon.Utility.VariablesGlobalesEnumerations;

namespace KRibbon.Utility
{
    public class VariablesGlobalesCollections
    {
        /// <summary>
        /// Dictionary donde se guardan los TabItem activos. Key=EOpcion, Value=DatosAyudaTabItem(ObservableCollection<object>, TabItem)
        /// </summary>
        public static Dictionary<EOpcion, DatosAyudaTabItem> tabitemdictionary = new Dictionary<EOpcion,DatosAyudaTabItem>();

        /// <summary>
        /// Dictionary que recopila la información de los RibbonButtons (la referencia en Resources, el nombre de la tabla de la BBDD, el ViewModel)
        /// Key=EOpcion, Value=DatosAyudaOpciones(string propertiesresources, string nombretabladb, PropertyChangedBase viewmodelbase)
        /// </summary>
        public static Dictionary<EOpcion, DatosAyudaOpciones> tiposauxiliaresdictionary = new Dictionary<EOpcion, DatosAyudaOpciones>()
        {
            #region Maestros
            { EOpcion.rbtnBancosClientes,     new DatosAyudaOpciones { propertiesresources = "lrbtnBancosClientes",
                                                                       nombretabladb = "BANCO",
                                                                       viewmodelbase = new BancoViewModel() } },
            { EOpcion.rbtnBloqueFacturacion,  new DatosAyudaOpciones { propertiesresources = "lrbtnBloqueFacturacion",
                                                                       nombretabladb = "BLOQUEFAC",
                                                                       viewmodelbase = new BloqueFacturacionViewModel() } },
            { EOpcion.rbtnCanales,            new DatosAyudaOpciones { propertiesresources = "lrbtnCanales",
                                                                       nombretabladb = "CANAL",
                                                                       viewmodelbase = new CanalClienteViewModel() } },
            { EOpcion.rbtnCargosPersonal,     new DatosAyudaOpciones { propertiesresources = "lrbtnCargosPersonal",
                                                                       nombretabladb = "CATEGOPER",
                                                                       viewmodelbase = new CargoPersonalViewModel() } },

            { EOpcion.rbtnTipoComisionista,   new DatosAyudaOpciones { propertiesresources = "lrbtnTipoComisionista",
                                                                       nombretabladb =  "TIPOCOMI",
                                                                       viewmodelbase = new TipoComisionistaViewModel() } },           

            { EOpcion.rbtnFormaPagoProveedor, new DatosAyudaOpciones { propertiesresources = "lrbtnFormaPagoProveedor",
                                                                       nombretabladb = "FORPRO",
                                                                       viewmodelbase = new FormaPagoProveedorViewModel() } },

            { EOpcion.rbtnGruposTarifa,       new DatosAyudaOpciones { propertiesresources = "lrbtnGruposTarifa",
                                                                       nombretabladb = "GRUPOS_TARI",
                                                                       viewmodelbase = new GrupoTarifaViewModel() } },
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
            { EOpcion.rbtnCinta,            new DatosAyudaOpciones { propertiesresources = "lrbtnCinta",
                                                                     nombretabladb = string.Empty,
                                                                     viewmodelbase = new CintaOpcionesViewModel() } },
            #endregion
        };

        public static ObservableCollection<object> dgitemsobscollection;

        /// <summary>
        /// Dictionary que recopila la información de los RibbonTab (el RibbonTab, sus correspondientes RibbonGroups, el CheckBox de la opción CintaOpciones)
        /// Key=ERibbonTab, Value=RibbonTabAndGroup(RibbonTab ribbontab, string checkbox, List<RibbonGroup> ribbongroup)
        /// </summary>
        public static Dictionary<ERibbonTab, RibbonTabAndGroup> ribbontabdefaultdictionary = new Dictionary<ERibbonTab, RibbonTabAndGroup> ()
        {
            { ERibbonTab.tbMaestros,      new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbMaestros,
                                                                  checkbox  = "ckbCintaOpcionesMaestros",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrCentrosAlquiler ,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrClientes,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrComisionistas,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrProveedores,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrTarifas,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrVehiculos,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrAuxiliares } }},

            { ERibbonTab.tbContratos,     new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbContratos,
                                                                  checkbox  = "ckbCintaOpcionesContratos",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrContratos,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrCambiosContratos,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrVariosContratos } } },

            { ERibbonTab.tbReservas,      new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbReservas,
                                                                  checkbox  = "ckbCintaOpcionesReservas",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrReservas } } },
            { ERibbonTab.tbAtipicos,      new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbAtipicos,
                                                                  checkbox  = "ckbCintaOpcionesAtipicos",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrAtipicos } } },
            { ERibbonTab.tbComercial,     new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbComercial,
                                                                  checkbox  = "ckbCintaOpcionesComercial",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrComercial } } },

            { ERibbonTab.tbFacturacion,   new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbFacturacion,
                                                                  checkbox  = "ckbCintaOpcionesFacturacion",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrFacturacion,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrRecibosCartera,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrRemesas,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrEnlacesContables,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrExportacion,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrImpresion,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrEstadisticasFacturas } } },        

            { ERibbonTab.tbFlota,         new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbFlota,
                                                                  checkbox  = "ckbCintaOpcionesFlota",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrInmovilizaciones,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrUtilidades,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrVariosFlota } } },

            { ERibbonTab.tbIncidencias,   new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbIncidencias,
                                                                  checkbox  = "ckbCintaOpcionesIncidencias",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrIncidencias } } },
            { ERibbonTab.tbEstadisticas,  new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbEstadisticas,
                                                                  checkbox  = "ckbCintaOpcionesEstadisticas",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrEstadisticas } } },
            { ERibbonTab.tbListados,      new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbListados,
                                                                  checkbox  = "ckbCintaOpcionesListados",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrListados } } },

            { ERibbonTab.tbConfiguracion, new RibbonTabAndGroup { ribbontab = ((MainWindow)Application.Current.MainWindow).tbConfiguracion,
                                                                  checkbox  = "ckbCintaOpcionesConfiguracion",
                                                                  ribbongroup = new List<RibbonGroup>() {
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrConfiguracion,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrIdiomas,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrPersonal,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrUtilitarios,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrVariosConfiguracion,
                                                                                    ((MainWindow)Application.Current.MainWindow).rgrKarve } } }
        };


        /// <summary>
        /// List que recopila los RibbonTab
        /// </summary>
        public static List<RibbonTab> ribbontablist = new List<RibbonTab>()
        {
            ((MainWindow)Application.Current.MainWindow).tbMaestros,
            ((MainWindow)Application.Current.MainWindow).tbContratos,
            ((MainWindow)Application.Current.MainWindow).tbReservas,
            ((MainWindow)Application.Current.MainWindow).tbAtipicos,
            ((MainWindow)Application.Current.MainWindow).tbComercial,
            ((MainWindow)Application.Current.MainWindow).tbFacturacion,
            ((MainWindow)Application.Current.MainWindow).tbFlota,
            ((MainWindow)Application.Current.MainWindow).tbIncidencias,
            ((MainWindow)Application.Current.MainWindow).tbListados,
            ((MainWindow)Application.Current.MainWindow).tbConfiguracion
        };
    }
}
