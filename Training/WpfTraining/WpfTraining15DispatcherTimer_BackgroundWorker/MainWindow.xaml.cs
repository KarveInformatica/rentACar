using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfTraining15DispatcherTimer_BackgroundWorker
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int max = 1000;
        private BackgroundWorker worker = null;
        public MainWindow()
        {
            InitializeComponent();
            //DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromMilliseconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

        }

        #region DispatcherTimer
        /*void timer_Tick(object sender, EventArgs e)
        {
            //lblTime.Content = DateTime.Now.ToLongTimeString();
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss.fff");
        }

        private void bttStart_Click(object sender, RoutedEventArgs e)
        {
            if(DateTime.Now >= new DateTime(2017, 5, 3, 13, 19, 30))
                timer.Start();
        }

        private void bttStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            lblTime.Content = "Click again start button...";
        }*/
        #endregion

        #region BackgroundWorker
        /*private void btnDoSynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {            
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            int result = 0;
            for (int i = 0; i < max; i++)
            {
                if (i % 42 == 0)
                {
                    lbResults.Items.Add(i);
                    result++;
                }
                System.Threading.Thread.Sleep(1);
                pbCalculationProgress.Value = Convert.ToInt32(((double)i / max) * 100);
            }
            lblTime.Content = "Numbers between 0 and " + max + " divisible By 7 are " + result;
            //MessageBox.Show("Numbers between 0 and " + max + " divisible By 7 are " + result);
        }
        private void btnDoAsynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(max);
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument;
            int result = 0;
            for (int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % 42 == 0)
                {
                    result++;
                    (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                }
                else
                    ((BackgroundWorker) sender).ReportProgress(progressPercentage);
                System.Threading.Thread.Sleep(1);
            }
            e.Result = result;
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Value = e.ProgressPercentage;
            if (e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblTime.Content = "Numbers between 0 and " + max + " divisible By 7 are " + e.Result;
            //MessageBox.Show("Numbers between 0 and " + max + " divisible By 7 are " + e.Result);
        }*/
        #endregion

        #region Cancelling BackgroundWorker
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                lblStatus.Foreground = Brushes.Green;
                worker.RunWorkerAsync();
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (worker.IsBusy)
            {
                lblStatus.Foreground = Brushes.Red;
                worker.CancelAsync();
            }
        }
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int i;
            for (i = 0; i <= max; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                worker.ReportProgress(i);
                System.Threading.Thread.Sleep(1);
            }
            e.Result = "ok, " + (i - 1) + " steps";
        }
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progressPercentage = Convert.ToInt32(((double)e.ProgressPercentage / max) * 100);
            lblStatus.Text = "Working... (" + progressPercentage + "%)";
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //lblStatus.Foreground = Brushes.Red;
                lblStatus.Text = "Cancelled by user...";
            }
            else
            {
                //lblStatus.Foreground = Brushes.Green;
                lblStatus.Text = "Done..., calc result is " + e.Result;
            }
        }
        #endregion
    }
}
