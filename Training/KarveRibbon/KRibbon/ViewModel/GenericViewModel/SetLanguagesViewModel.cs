﻿using KRibbon.Commands.Generic;
using KRibbon.Model.Generic;
using KRibbon.Utility;
using System.Globalization;
using System.Threading;
using System.Windows.Input;

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

            // Se guarda el idioma según el param recibido del xaml en app.config
            UserConfig.SetCurrentUserLanguage("Language", parameter.ToString());
        }
    }
}
