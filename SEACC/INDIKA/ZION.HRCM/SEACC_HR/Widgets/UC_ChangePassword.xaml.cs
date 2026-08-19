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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_ChangePassword.xaml
    /// </summary>
    public partial class UC_ChangePassword : UserControl
    {
        public UC_ChangePassword()
        {
            InitializeComponent();
            
            ClearField(); 
        }

        private void ClearField()
        {
            txtCurrentPassword.Password = "";
            txtPassword.Password = "";
            txtPassword2.Password = "";
        }

        private void SEACC_Button_Click(object sender, RoutedEventArgs e)
        {
            string UserID = clsSecurity.UserIDLoged;
            if (UserID != null)
            {
                tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(UserID);
                if (oSecurityUser != null)
                {
                    if ((clsSecurity.decryptPassword(oSecurityUser.Password) == txtCurrentPassword.Password))
                    {
                        if (txtPassword.Password == txtPassword2.Password)
                        {
                            oSecurityUser.Password = clsSecurity.encryptPassword(txtPassword.Password);
                            oSecurityUser.Update();
                            clsAlerts_Email.CreateEmail_ChangedPassword(oSecurityUser.User_ID, txtPassword.Password);
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Changed);
                            ClearField();
                        }
                        else
                        {
                            SEACCMessageBox.Show(MessegeBoxType.PasswordsNotMatched);
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Oops", "Current Password is Wrong !", MessageBoxButton.OK);
                    }
                }
            }
        }
    }
}
