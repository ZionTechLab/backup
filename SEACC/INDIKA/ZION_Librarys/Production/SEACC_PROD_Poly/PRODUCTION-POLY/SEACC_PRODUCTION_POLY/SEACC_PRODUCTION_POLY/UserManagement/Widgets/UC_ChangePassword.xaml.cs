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

namespace SEACC_PRODUCTION_POLY.UserManagement.Widgets
{
    /// <summary>
    /// Interaction logic for UC_ChangePassword.xaml
    /// </summary>
    public partial class UC_ChangePassword : UserControl
    {
        public event EventHandler BtnApplyClick;

        public UC_ChangePassword()
        {
            InitializeComponent();

            ClearField();
        }

        public void ClearField()
        {
            txtCurrentPassword.Password = "";
            txtPassword.Password = "";
            txtPassword2.Password = "";
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            BtnApplyClick(sender, e);
        }
    }
}
