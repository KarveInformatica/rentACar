﻿using KRibbon.Properties;
using System.Globalization;
using System.Windows.Data;

namespace KRibbon.Logic.Generic
{
    public class ChangeLanguage
    {
        private static ObjectDataProvider _objectdataprovider;

        public ChangeLanguage() { }

        /// <summary>
        /// Devuelve una instancia nueva de nuestros recursos
        /// </summary>
        /// <returns></returns>
        public Resources GetResourceLanguage()
        {
            return new Resources();
        }

        /// <summary>
        /// Devuelve el ObjectDataProvider en uso
        /// </summary>
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

        /// <summary>
        /// Cambia la cultura aplicada a los recursos y refresca la propiedad ResourceProvider
        /// </summary>
        /// <param name="culture"></param>
        public static void ChangeCulture(CultureInfo culture)
        {
            Properties.Resources.Culture = culture;
            objectdataprovider.Refresh();
        }
    }
}
