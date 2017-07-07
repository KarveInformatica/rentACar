using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

using System.Globalization;
using System.Threading;

using KRibbon;
using KRibbon.Commands.Generic;
using KRibbon.Model;
using KRibbon.Utility;
using KRibbon.Properties;
using System.Configuration;
using System.IO;
using KRibbon.Model.Generic;

namespace KRibbon.ViewModel.GenericViewModel
{
    public class SetLanguagesViewModel : PropertyChangedBase
    {
        private SetLanguagesCommand setlanguagescommand;

        public SetLanguagesViewModel()
        {
            this.setlanguagescommand = new SetLanguagesCommand(this);
        }

        public ICommand SetLanguagesCommand
        {
            get
            {
                return setlanguagescommand;
            }
        }

        /// <summary>
        /// Cambia el idioma según el param recibido del xaml, y guardamos el idioma en app.config
        /// </summary>
        /// <param name="parameter"></param>
        public void SetLanguages(object parameter)
        {
            //Cambia el idioma según el param recibido del xaml
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            ChangeLanguage.ChangeCulture(Thread.CurrentThread.CurrentUICulture);

            // Guardamos el idioma según el param recibido del xaml en app.config
            UserConfig.SetCurrentUserLanguage("Language", parameter.ToString());
        }
    }
}
