using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiteq_Logic;
using DataTire;

namespace Digiteq
{
    public partial class frm_bpsNewReconcilation : Form
    {
        int iCompanyAccID;
       
        #region Form Load
        public frm_bpsNewReconcilation(int iCompanyAccID_)
        {
            InitializeComponent();
            iCompanyAccID = iCompanyAccID_;
        }

        private void frm_bpsNewReconcilation_Load(object sender, EventArgs e)
        {
            ClearFields();

            txtStatementNo.Text = "";
            txtStatementNo.Focus();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_NormalLabel(lblAccountNo, false);
            clsCommon.SetEnableDisable_NormalLabel(lblBank, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtStatementNo, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtLastBalance, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtStatementBalance, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpFromDate, false);
            dtpStatementDate.Value = clsSecurity.getServerDateTime();
            txtStatementBalance.Text = "0.00";
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                this.DialogResult = DialogResult.Yes;
            }
        }

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_StatementNo())
                {
                    if (CheckValidity_StatementDate())
                    {
                        bStatus = true;
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtStatementNo, "Statement No"))
            {
                bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_StatementNo()
        {
            bool bStatus = true;

            List<tbl_bpsBankReconciliation> oReconcilation = tbl_bpsBankReconciliation.SelectAll().Where(p => p.StatementNo == txtStatementNo.Text && p.CompanyAccount_ID == iCompanyAccID).ToList();
            if (oReconcilation.Count >= 1)
            {
                MessageBox.Show("This Statement No. is already added.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bStatus = false;
            }

            return bStatus;
        }

        private bool CheckValidity_StatementBalance()
        {
            bool bStatus = false;
            //if (decimal.Parse(txtStatementBalance.Text) > 0)
            //{
            //    bStatus = true;
            //}
            //else
            //{
            //    MessageBox.Show("Statement Balance should be greater than 0.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    bStatus = false;
            //}

            return bStatus;
        }

        private bool CheckValidity_StatementDate()
        {
            bool bStatus = false;
            if (dtpFromDate.Value.Date < dtpStatementDate.Value.Date)
            {
                bStatus = true;
            }
            else
            {
                MessageBox.Show("From Date should be less.. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                bStatus = false;
            }

            return bStatus;
        }
        #endregion

        private void txtStatementBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtStatementBalance.Text, e);
        }

        private void txtStatementBalance_Enter(object sender, EventArgs e)
        {
            txtStatementBalance.SelectAll();
        }
    }
}