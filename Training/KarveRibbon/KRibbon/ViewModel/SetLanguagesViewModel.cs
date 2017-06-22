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
using KRibbon.Commands.Specific;
using KRibbon.Model;
using KRibbon.Utility;
using KRibbon.Properties;

namespace KRibbon.ViewModel
{
    public class SetLanguagesViewModel : ViewModelBase
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
        /// Cambia el idioma según el param recibido del xaml
        /// </summary>
        /// <param name="parameter"></param>
        public void SetLanguages(object parameter)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            ChangeLanguage.ChangeCulture(Thread.CurrentThread.CurrentUICulture);
        }
    }
}
