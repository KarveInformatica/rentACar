using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
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
        private LanguagesCommand setlanguagesCommand;

        public SetLanguagesViewModel()
        {
            this.setlanguagesCommand = new LanguagesCommand(this);
        }

        public ICommand SetLanguagesCommand
        {
            get
            {
                return setlanguagesCommand;
            }
        }

        public void SetLanguages(object parameter)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(parameter.ToString());
            ChangeLanguage.ChangeCulture(Thread.CurrentThread.CurrentUICulture);
        }
    }
}
