using System;
using System.Windows;
using System.Windows.Controls;

namespace SEACC_POS.UserManagement.Widgets
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
