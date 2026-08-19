using DataTire;
using Digiteq_Logic;
using SEACC_POS.Search_Forms;
using SEACC_WPFControls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace SEACC_POS.Controls
{
    /// <summary>
    /// Interaction logic for frm_TwoStepVerification.xaml
    /// </summary>
    public partial class frm_TwoStepVerification_UserChange : Window
    {
        public bool bVerified = false;

        private int iTXFunction_ID = -1;
        private bool bTx_Checked = false;
        private bool bTx_Approved = false;
        private bool bTx_Canceled = false;

        public frm_TwoStepVerification_UserChange( int iTXFunction_ID,  bool bChecked, bool bApproved, bool bCanceled)
        {
            InitializeComponent();

            this.iTXFunction_ID = iTXFunction_ID;
            this.bTx_Checked = bChecked;
            this.bTx_Approved = bApproved;
            this.bTx_Canceled = bCanceled;

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
            if (txtUsername.Tag != null)
            {
                string UserID = txtUsername.Tag.ToString();

                tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(UserID);
                tbl_securityFunctionMaster_Permission oPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, oSecurityUser.User_ID, iTXFunction_ID);

                if (oSecurityUser != null )
                {
                    if (oPermission != null)
                    {
                        bool bContinue_status = false;

                        if ((oPermission.AllowCheckable && bTx_Checked) || (oPermission.AllowApprovable && bTx_Approved) || (oPermission.AllowDelete && bTx_Canceled))
                            bContinue_status = true;
                        else
                            SEACCMessageBox.Show("Oops", "You don't have permission !", MessageBoxButton.OK, "Red");

                        if (bContinue_status)
                        {
                            if (txtPassword.Password.Length > 0)
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
                                        SEACCMessageBox.Show("Oops", "Current PIN is Wrong !", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Oops", "You don't have a PIN! \nPlease set up your PIN first...", MessageBoxButton.OK, "Red");
                                }
                            }
                            else
                            {
                                SEACCMessageBox.Show("Oops", "PIN can not be empty !", MessageBoxButton.OK, "Red");
                            }
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Oops", "You don't have permission !", MessageBoxButton.OK, "Red");
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("Oops", "Username can not be empty !", MessageBoxButton.OK , "Red");
            }
        }

        private void txtUsername_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearchForm RowDataSearch = new frmSearchForm();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtUsername.Tag = lstResult[0];
                txtUsername.Text = lstResult[1];
            }
        }

        
    }
}
