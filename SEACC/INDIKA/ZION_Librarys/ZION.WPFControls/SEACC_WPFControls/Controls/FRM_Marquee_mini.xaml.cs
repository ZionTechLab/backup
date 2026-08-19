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

namespace SEACC_WPFControls
{  
    public partial class FRM_Marquee_mini : Window
    {
        public delegate void Method();
        private static Method close;

        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        List<String> list = new List<String>();
        int i = 0;

        public static void CloseForm()
        {
            close.Invoke();
        }
        public FRM_Marquee_mini()
        {
            InitializeComponent();
            close = new Method(Close);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 20, 0);
            dispatcherTimer.Start();

            list.Add("Company special holiday to all employees on 24th September, for Hadji festival");
            list.Add("Shift No23 is cancel on 27th Sept.(Sunday)");
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            txtKron.Text = list[i];
            i++;
            if (i > (list.Count - 1))
                i = 0;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
