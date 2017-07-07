using KRibbon.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace KRibbon.Utility
{
    public class ChangeLanguage
    {
        private static ObjectDataProvider _objectdataprovider;

        public ChangeLanguage() { }

        //Devuelve una instancia nueva de nuestros recursos
        public Resources GetResource()
        {
            return new Resources();
        }

        //Esta propiedad devuelve el ObjectDataProvider en uso
        public static ObjectDataProvider objectdataprovider
        {
            get
            {
                if (_objectdataprovider == null)
                {
                    _objectdataprovider = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
                }
                return _objectdataprovider;
            }
        }

        //Este método cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        public static void ChangeCulture(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
            objectdataprovider.Refresh();
        }
    }
}
