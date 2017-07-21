using System.Collections.Generic;

namespace KRibbon.Model.Generic
{
    /// <summary>
    /// Plantilla con la info de los RibbonButton:<para/>
    /// propertiesresources -> nombre del resource para mostrar el idioma según corresponda<para/>
    /// nombretabladb       -> nombre de la tabla en la DB<para/>
    /// obj                 -> object del tipo de dato que corresponda<para/>
    /// templateinfodb      -> Plantilla con la info para los campos de la datagrid, y de su correspondiente campo en la DB<para/>
    /// </summary>
    public class TemplateInfoRibbonButton
    {        
        public string propertiesresources { get; set; }
        public string nombretabladb { get; set; }
        public object obj { get; set; }
        public List<TemplateInfoDB> templateinfodb { get; set; }
    }
}
