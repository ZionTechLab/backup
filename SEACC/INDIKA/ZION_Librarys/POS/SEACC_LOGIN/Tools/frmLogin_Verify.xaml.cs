using DataTire;
using Digiteq_Logic;
using SEACC_LOGIN.Common;
using SEACC_LOGIN.Search;
using SEACC_WPFControls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Digiteq;

using System.Windows.Input;

namespace SEACC_LOGIN
{
    /// <summary>
    /// Interaction logic for frmLogin_Verify.xaml
    /// </summary>
    public partial class frmLogin_Verify : Window
    {
        #region Form Intialize
        public frmLogin_Verify()
        {
            InitializeComponent();

            //sUserName = "";
            //sUserID = "";
            //bOK = false;
            //bReset = false;

            ClearFields();

            //tbl_securityUserMaster detail = tbl_securityUserMaster.Select(userID);
            //if (detail != null)
            //{
            //    txtUserName.Text = userID;
            //    txtPassword.Text = clsSecurity.decryptPassword(detail.Password);
            //}
        }
        #endregion

        #region Drag Move
        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

        #region Btn Login
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (IsLoginOk())
            {
                if (Save_Workstation())
                {
                    this.DialogResult = true;
                    this.Close();
                }
            }
        }
        #endregion

        #region Btn Reset
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Login Validate Method
        private bool IsLoginOk()
        {
            bool value = false;
            try
            {
                if (txtUserName.Text.Length > 0)
                {
                    tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserName.Text.Trim());
                    if (detail != null)
                    {
                        if (string.Compare(detail.Password, clsSecurity.encryptPassword(txtPassword.Password.Trim()), true) == 0)
                        {
                            value = true;
                            //if (detail.Group_ID == "1")
                            //    value = true;
                            //else
                            //{
                            //    System.Windows.MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption(), MessageBoxButton.OK, MessageBoxImage.Information);
                            //    value = false;
                            //}
                        }
                        else
                        {
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        txtUserName.SelectAll();
                        txtUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            return value;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            txtUserName.Focus();

            txtCompanyBranch.Text = "<Select Company Branch>";
            txtCompanyBranch.Tag = null;

            lblTerminalID.Content = clsSecurity_Login.TerminalID;
        }
        #endregion

        #region Btn Close
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        #endregion

        #region Key Down Event
        private void txtPassword_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnLogin_Click(sender, e);
        }
        #endregion

        #region Save Method
        private bool Save_Workstation()
        {
            bool bStatus = false;
            try
            {
                if (CheckValidity_EmptyFields())
                {
                    if (CheckValidity_DuplicateRecord())
                    {
                        tbl_securityWorkstationRegister oDetail = new tbl_securityWorkstationRegister(lblTerminalID.Content.ToString(), clsSecurity_Login.CompanyID, txtCompanyBranch.Tag.ToString(), false);
                        oDetail.Insert();

                        bStatus = true;
                        Program.sCompanyBranchID = txtCompanyBranch.Tag.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_DuplicateRecord()
        {
            bool bStatus = true;
            try
            {
                tbl_securityWorkstationRegister oSection = tbl_securityWorkstationRegister.SelectAll().Where(p => p.Terminal_ID == lblTerminalID.Content.ToString()).FirstOrDefault();
                if (oSection != null)
                    bStatus = false;


                if (!bStatus)
                    SEACCMessageBox.Show("This workstation already registerd", "", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            bool bStatus = true;
            if (txtCompanyBranch.Text.Length == 0 || txtCompanyBranch.Tag == null)
            {
                txtCompanyBranch.BorderBrush = System.Windows.Media.Brushes.Red;
                bStatus = false;
            }
            if (lblTerminalID.Content.ToString() == "")
            {
                bStatus = false;
                System.Windows.MessageBox.Show("Blank Terminal ID", clsFormatter.GetMessageCaption(), MessageBoxButton.OK, MessageBoxImage.Information);
            }

            return bStatus;
        }

        #endregion

        #region Double Click Event
        private void txtCompanyBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            System.Collections.Generic.List<string> lstResult = RowDataSearch.Show(5007);
            if (RowDataSearch.DialogResult == true)
            {
                txtCompanyBranch.Tag = lstResult[0];
                txtCompanyBranch.Text = lstResult[1];
            }
        }
        #endregion

    }

    #region Class Message
    public static class SEACCVerifyMessageBox
    {
        public static bool Show()
        {
            frmLogin_Verify oVerifyMsg = new frmLogin_Verify();
            oVerifyMsg.ShowDialog();

            return (bool)oVerifyMsg.DialogResult;
        }
    }
    #endregion

}
