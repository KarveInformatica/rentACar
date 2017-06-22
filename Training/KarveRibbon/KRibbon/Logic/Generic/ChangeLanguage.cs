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
        private static ObjectDataProvider odp;

        public ChangeLanguage() { }

        //Devuelve una instancia nueva de nuestros recursos
        public Resources GetResource()
        {
            return new Resources();
        }

        //Esta propiedad devuelve el ObjectDataProvider en uso
        public static ObjectDataProvider ResourceProvider
        {
            get
            {
                if (odp == null)
                {
                    odp = (ObjectDataProvider)App.Current.FindResource("ResourceLanguage");
                }
                return odp;
            }
        }

        //Este método cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        public static void ChangeCulture(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;            
            ResourceProvider.Refresh();
        }
    }
}
