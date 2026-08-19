using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Windows;
using System.Windows.Input;

namespace SEACC_POS.Controls
{
    /// <summary>
    /// Interaction logic for frm_TwoStepVerification.xaml
    /// </summary>
    public partial class frm_TwoStepVerification : Window
    {
        public bool bVerified = false;

        public frm_TwoStepVerification()
        {
            InitializeComponent();

            ClearFields();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtPassword.Focusable = true;
            txtPassword.Focus();
        }

        #region Clearfield
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUsername, true, false, false);

            txtUsername.Tag = null;

            txtUsername.Text = "<Select a user>";
            txtPassword.Password = "";

            #region User Name Assign
            tbl_securityUserMaster oUser = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
            if (oUser != null)
            {
                txtUsername.Tag = oUser.User_ID;
                txtUsername.Text = oUser.UserName;
            }
            #endregion

        }
        #endregion

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnVerify_Click(sender, e);
            }
        }

        private void btnVerify_Click(object sender, RoutedEventArgs e)
        {
            string UserID = clsSecurity.UserIDLoged;
            if (UserID != null)
            {
                if (txtPassword.Password.Length > 0)
                {
                    tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(UserID);
                    if (oSecurityUser != null)
                    {
                        if (oSecurityUser.Password2.Length > 3)
                        {

                            if (((oSecurityUser.Password2) == clsSecurity.encryptPassword(txtPassword.Password)))
                            {
                                bVerified = true;
                                Visibility = Visibility.Hidden;
                            }
                            else
                            {
                                SEACCMessageBox.Show("Oops", "Current PIN is Wrong !", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Oops", "You don't have a PIN! \nPlease set up your PIN first...", MessageBoxButton.OK);
                        }

                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops", "PIN can not be empty !", MessageBoxButton.OK);
                }
            }
        }

        
    }
}
