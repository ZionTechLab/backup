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
    public partial class frmSetCostPrice : Form
    {
        public static string glbConfirmedUserName;
        public static string glbConfirmedUserID;
        public static decimal glbKiloPrice;
        public static bool bConfirmed;
        public static bool bReset;
        public static bool bCancel;
       public int iFormID;

        public frmSetCostPrice()
        {
            glbConfirmedUserName = "";
            glbConfirmedUserID = "";
            glbKiloPrice = 0;
            bConfirmed = false;
            bReset = false;          
            InitializeComponent();
        }

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (IsLoginOk())
                bConfirmed = true;           
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
                                glbConfirmedUserID = detail.User_ID;
                                glbConfirmedUserName = detail.UserName;
                                glbKiloPrice = decimal.Parse(txtKiloPrice.Text.Trim());
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
            txtKiloPrice.Clear();

            if (txtUserName.Enabled)
            {
                txtUserName.SelectAll();
                txtUserName.Focus();
            }
        }
        #endregion

        #region Events KeyPress
        private void txtKiloPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtKiloPrice, e, 14, 6);
        } 
        #endregion
        
    }
}
