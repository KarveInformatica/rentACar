using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading;

namespace Karve.SplashScreenModule
{
    /// <summary>
    /// 
    /// </summary>
    public class Loader
    {
        private static Application App;

        public Loader(Application app)
        {
            App = app;
        }
        /// <summary>
        /// 
        /// </summary>
        [STAThread ( )]
        static void Main ( )
        {
            Splasher.Splash = new NewSplashScreen ( );
            Splasher.ShowSplash();

            for ( int i = 0; i < 1000; i++ )
            {
                MessageListener.Instance.ReceiveMessage ( string.Format ( "Load module {0}", i ) );
                Thread.Sleep ( 1 );
            }
            App.MainWindow.Show();
        }
    
     
    }
}
