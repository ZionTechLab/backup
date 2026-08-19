using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmSetChecked : Form
    {
        
        public static string sCheckedUserName;
        public static string sCheckedUserID;
        public static bool bChecked;
        public static bool bReset;
        public static bool bCancel;
        public int iFormID;
        public string userID; 


        #region Form Load
        public frmSetChecked()
        {
            sCheckedUserName = "";
            sCheckedUserID = "";
            bChecked = false;
            bReset = false;
            
            InitializeComponent();
        }
       
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            ucTittleBar1.DisplayName = "Checked - Done / Reset";
            ClearFields();

            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(userID);
            if (detail != null)
            {
                txtUserName.Text = userID;
                txtPassword.Text = clsSecurity.decryptPassword(detail.Password);
            }

            txtPassword.SelectAll();
            txtPassword.Focus();
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (IsLoginOk())
                bChecked = true;           
            this.Close();
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {           
            this.Close();
        } 
        #endregion

        #region Login Validate Method
        private bool IsLoginOk()
        {
            bool value = false;
            try
            {
                if (txtUserName.TextLength > 0)
                {
                    tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserName.Text.Trim());
                    if (detail != null)
                    {
                        if (string.Compare(detail.Password, clsSecurity.encryptPassword(txtPassword.Text.Trim()), true) == 0)
                        {
                            if (clsSecurity.PermissionToChecked(detail.User_ID, iFormID))
                            {
                                //validate is correct
                                value = true;
                                sCheckedUserID = detail.User_ID;
                                sCheckedUserName = detail.UserName;
                            }
                            else
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                if (txtUserName.Enabled)
                                {
                                    txtUserName.SelectAll();
                                    txtUserName.Focus();
                                }
                            }

                        }
                        else
                        {
                            MessageBox.Show("Invalid Password", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (txtPassword.Enabled)
                            {
                                txtPassword.SelectAll();
                                txtPassword.Focus();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserID", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (txtUserName.Enabled)
                        {
                            txtUserName.SelectAll();
                            txtUserName.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            return value;
        } 
        #endregion

        #region Btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (IsLoginOk())
                bReset = true;
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtPassword.Clear();
            txtUserName.Clear();

            if (txtPassword.Enabled)
            {
                txtPassword.SelectAll();
                txtPassword.Focus();
            }
        }
        #endregion

        #region Events KeyDown
        private void frmSetChecked_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogon_Click(sender, e);
        }
        #endregion

        #region Btn Close
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
        #endregion       
    }
}
