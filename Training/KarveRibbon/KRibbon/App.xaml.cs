using KRibbon.Utility;
using Microsoft.Windows.Controls.Ribbon;
using System.Windows;
using KRibbon;


namespace KRibbon
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            UserConfig.LoadLanguage();
            //UserConfig.LoadRibbonTabs(Current.MainWindow);
        }
    }
}
