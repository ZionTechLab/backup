using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SEACC_WPFControls
{
    /// <summary>
    /// Interaction logic for frm_WaitingMessege.xaml
    /// </summary>
    public partial class frm_WaitingMessege : Window
    {
        Stopwatch stopWatch = new Stopwatch();
        //double dClosingSeconds = -2;

        public frm_WaitingMessege()
        {
            InitializeComponent();
            this.Show();

            // int i = 1;
            //TimeSpan ts = new TimeSpan();
            //TimeSpan ts2 = new TimeSpan(0, 0, 1);
            //DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 0, 1), DispatcherPriority.Normal, delegate
            //{
            //    ts += ts2;
            //    txt_Timer.Text = ts.ToString();

            //    // lblDate.Content = DateTime.Now.ToString("yyyy-MMM-dd");
            //    // dateText.Content = DateTime.Now.ToString("HH:mm tt");
            //    //  lblDay.Content = DateTime.Now.ToString("dddd");
            //}, this.Dispatcher);
        }

        public frm_WaitingMessege(string sCaption)
        {
            InitializeComponent();

            textBlock5.Text = sCaption;
            // dClosingSeconds = dClosingSecs;

            //DispatcherTimer dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            //dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            //dispatcherTimer.Start();

            this.Show();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        //private void dispatcherTimer_Tick(object sender, EventArgs e)
        //{
        //    TimeSpan ts = stopWatch.Elapsed;
        //    string currentTime = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        //    txt_Timer.Text = currentTime;
        //    if (ts.TotalSeconds == dClosingSeconds)
        //        this.Close();
        //}
    }
}
