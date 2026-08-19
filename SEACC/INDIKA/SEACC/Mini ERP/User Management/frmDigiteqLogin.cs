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
    public partial class frmDigiteqLogin : Form
    {
        public static string sCheckedUserName;
        public static string sCheckedUserID;
        public static bool bLoged;
        //public static bool bReset;
        public static bool bCancel;
        //public    public int iFormID;

        public frmDigiteqLogin()
        {
            sCheckedUserName = "";
            sCheckedUserID = "";
            bLoged = false;
            bCancel = false;
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
            if (txtPassword.Text.Trim().ToLower()=="n0 pa55w0rd")
                bLoged = true;  
            this.Close();
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            bCancel = true;
            this.Close();
        } 
        #endregion     

        #region Clear Fields
        private void ClearFields()
        {
            txtPassword.Clear();
            txtUserName.Clear();

            if (txtUserName.Enabled)
            {
                txtUserName.SelectAll();
                txtUserName.Focus();
            }
        }
        #endregion

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                btnLogon_Click(sender, e);
            }
        }
        
    }
}
