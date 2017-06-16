using KRibbon.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace KRibbon.Logic.Generic
{
    public class CloseWindow
    {
        public static void closeWindow()
        {
            try
            {
                if (MessageBox.Show(Resources.msgSalir, Resources.lrapmnitSalir, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    ((MainWindow)Application.Current.MainWindow).Close();
                }
            }
            catch { }
        }
    }
}
