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
using Digiteq_Logic;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for wj_TestMail.xaml
    /// </summary>
    public partial class wj_TestMail : UserControl
    {
        public wj_TestMail()
        {
            InitializeComponent();
        }

        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            //clsAlerts_Email.CreateEmail_Test(txttext.Text,txtemail.Text);
        }
    }
}
