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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_Clock.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for UC_Clock.xaml
    /// </summary>
    public partial class UC_Clock : UserControl
    {
        public UC_Clock()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lblDate.Content = DateTime.Now.ToString("yyyy-MMM-dd");
                dateText.Content = DateTime.Now.ToString("HH:mm:ss");
                lblDay.Content = DateTime.Now.ToString("dddd");
            }, this.Dispatcher);
        }
    }
}
