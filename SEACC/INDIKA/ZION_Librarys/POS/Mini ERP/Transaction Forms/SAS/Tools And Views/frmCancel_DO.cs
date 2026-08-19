using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmCancel_DO : Form
    {
       public int iFormID;
        public string glbNoteID = "", glbSystemResonID = "";
        public bool glbSystemReson = false, glbValied = false;


        public frmCancel_DO()
        {               
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
                glbValied = true;
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
            if (txtSystemMessage.Tag != null && txtSystemMessage.Tag.ToString().Trim().Length > 0)
            {
                tbl_zCancelReson_DO detail = tbl_zCancelReson_DO.Select(txtSystemMessage.Tag.ToString());
                if (detail != null)
                {
                    glbSystemResonID = detail.CancelReason_ID_DO;
                    glbSystemReson = true;
                    value = true;
                }
            }
            else
            {
                glbSystemResonID = "";
                glbSystemReson = false;
                value = false;
            }
            return value;
        } 
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            txtUserID.Text = clsSecurity.UserIDLoged;
            txtUserName.Text = clsSecurity.UserNameLoged;

            txtSystemMessage.Tag = null;
            txtSystemMessage.Clear();

            rdoSystem.Checked = true;

           
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
        #endregion

        #region Events CheckedChanged
        private void rdoSystem_CheckedChanged(object sender, EventArgs e)
        {
            txtSystemMessage.Tag = null;
            txtManualMessage.Clear();
            txtSystemMessage.Clear();

            if (rdoSystem.Checked)
            {
                txtManualMessage.Enabled = false;
                txtSystemMessage.Enabled = true;


                glbSystemReson = true;
                if (txtSystemMessage.Enabled)
                {
                    txtSystemMessage.SelectAll();
                    txtSystemMessage.Focus();
                }

                txtSystemMessage_KeyDown(sender, new KeyEventArgs(Keys.F1));
            }
        }

        private void rdoManual_CheckedChanged(object sender, EventArgs e)
        {
            txtSystemMessage.Tag = null;
            txtManualMessage.Clear();
            txtSystemMessage.Clear();

            if (rdoManual.Checked)
            {
                txtManualMessage.Enabled = true;
                txtSystemMessage.Enabled = false;

                glbSystemReson = false;
                if (txtManualMessage.Enabled)
                {
                    txtManualMessage.SelectAll();
                    txtManualMessage.Focus();
                }
            }
        } 
        #endregion

        private void txtSystemMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterCancelResonDeliveryOrder(ref txtSystemMessage);
            }
        }

        private void txtSystemMessage_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterCancelResonDeliveryOrder(ref txtSystemMessage);
        }

       
        
    }
}
