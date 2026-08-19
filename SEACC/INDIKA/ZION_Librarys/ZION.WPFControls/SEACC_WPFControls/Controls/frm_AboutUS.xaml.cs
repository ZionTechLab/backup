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
    /// <summary>
    /// Interaction logic for frm_AboutUS.xaml
    /// </summary>
    public partial class frm_AboutUS : Window
    {
        public frm_AboutUS()
        {
            InitializeComponent();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
