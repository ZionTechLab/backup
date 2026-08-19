using System;
using System.Collections.Generic;
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
    /// Interaction logic for SEACC_MessegeBox.xaml
    /// </summary>
    public partial class SEACC_LoggingOffBox : Window
    {
        static BrushConverter bc = new BrushConverter();
        DispatcherTimer _timer;
        TimeSpan _time;

        public SEACC_LoggingOffBox()
        {
            InitializeComponent();
        }

        public SEACC_LoggingOffBox(string Caption, string Messege, MessageBoxButton btn)
        {
            InitializeComponent();

            lbl_Caption.Text = Caption;
            lblMessege.Text = Messege;
        }

        private void Btn_OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (_timer != null)
                _timer.Stop();
            this.Close();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            Btn_OK.Background = (Brush)bc.ConvertFrom("#FF5B6B76");
            grdHeader.Background = (Brush)bc.ConvertFrom("#FF5B6B76");

            _time = TimeSpan.FromSeconds(10);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Loaded, delegate
            {
                tbTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                {
                    _timer.Stop();
                    this.DialogResult = false;
                    this.Close();                   
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            },
            Application.Current.Dispatcher);

            _timer.Start();
        }

        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
