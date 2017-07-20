using System.Windows.Controls;

namespace KRibbon.Model.Generic
{
    /// <summary>
    /// Plantilla con la info de los TabItem:<para/>
    /// genericobscollection -> GenericObservableCollection con la información original recogida de la BBDD<para/>
    /// tabitem              -> TabItem que contendrá el usercontrol que corresponda<para/>
    /// obj                  -> object del tipo de dato que corresponda<para/>
    /// </summary>
    public class TemplateInfoTabItem : GenericPropertyChanged
    {
        #region Constructores
        public TemplateInfoTabItem() { }

        public TemplateInfoTabItem(TabItem tabitem)
        {
            this.tabitem = tabitem;
        }

        public TemplateInfoTabItem(object obj)
        {
            this.obj = obj;
        }

        public TemplateInfoTabItem(GenericObservableCollection genericobscollection, TabItem tabitem, object obj)
        {
            this.genericobscollection = genericobscollection;
            this.tabitem = tabitem;
            this.obj = obj;
        }
        #endregion

        #region Propiedades
        private GenericObservableCollection genericobscollection;
        public GenericObservableCollection GenericObsCollection
        {
            get
            {
                return genericobscollection;
            }
            set
            {
                genericobscollection = value;
                OnPropertyChanged("GenericObsCollection");
            }
        }



        private TabItem tabitem;        
        public TabItem TabItem
        {
            get
            {
                return tabitem;
            }
            set
            {
                tabitem = value;
                OnPropertyChanged("TabItem");
            }
        }

        private object obj;
        public object Obj
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                OnPropertyChanged("Obj");
            }
        }
        #endregion
    }
}
