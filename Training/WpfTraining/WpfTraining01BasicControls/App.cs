using System;
using System.Windows;
using WpfTraining01BasicControls;

namespace WpfTraining
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            // The OpenFile() method is just an example of what you could do with the
            // parameter. The method should be declared on your MainWindow class, where
            // you could use a range of methods to process the passed file path
            //if (e.Args.Length == 1)
            //    wnd.OpenFile(e.Args[0]);
            //wnd.Show();
        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An UNHANDLED exception just occurred: \n" + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true; //Esto le dice a WPF que hemos terminado de tratar esta excepción y no se debe hacer nada más al respecto
        }
    }
}
