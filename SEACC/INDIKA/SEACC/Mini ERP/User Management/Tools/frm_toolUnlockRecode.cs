using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_toolUnlockRecode : Form
    {        
            public int iFormID;

        public frm_toolUnlockRecode()
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
            DialogResult msgResult = MessageBox.Show("Do You Want To Unlock This Record? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;    

                    #region Pre-plan
                    if (rdoPrePlan.Checked)
                    {
                        //tbl_pmsPrePlan oldRecord = tbl_pmsPrePlan.Select(txtRecodeID.Text.Trim());
                        //if (oldRecord != null)
                        //{
                        //    oldRecord.IsLocked = false;
                        //    oldRecord.Update();
                        //}
                    }
                    #endregion

                    #region Work-in-progress
                    if (rdoWip.Checked)
                    {
                        //tbl_pmsWorkInProgress oldRecord = tbl_pmsWorkInProgress.Select(txtRecodeID.Text.Trim());
                        //if (oldRecord != null)
                        //{
                        //    oldRecord.IsLocked = false;
                        //    oldRecord.Update();
                        //}
                    }
                    #endregion

                    #region Inquery
                    if (rdbInquery.Checked)
                    {
                        tbl_sasInquiry oldRecord = tbl_sasInquiry.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region Customer Order
                    if (rdbCustomerOrder.Checked)
                    {
                        tbl_sasCustomerOrder oldRecord = tbl_sasCustomerOrder.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region Invoice
                    if (rdoInvoice.Checked)
                    {
                        tbl_sasInvoice oldRecord = tbl_sasInvoice.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region old records
                    if (rdoReceipt.Checked)
                    {
                        tbl_bpsReceipt oldRecord = tbl_bpsReceipt.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region cheque
                    if (rdoCheque.Checked)
                    {
                        tbl_bpsChequeRegister oldRecord = tbl_bpsChequeRegister.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region credit note
                    if (rdoCreditNote.Checked)
                    {
                        tbl_bpsCreditNote oldRecord = tbl_bpsCreditNote.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    #region debit note
                    if (rdoDebit.Checked)
                    {
                        tbl_bpsDebitNote oldRecord = tbl_bpsDebitNote.Select(txtRecodeID.Text.Trim());
                        if (oldRecord != null)
                        {
                            oldRecord.IsLocked = false;
                            oldRecord.Update();
                        }
                    }
                    #endregion

                    ClearFields();
                    MessageBox.Show("Record Unlocked Successfully.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;                    
                }
            }
        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        } 
        #endregion
               
        #region Btn Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtRecodeID.Tag = null;
            txtRecodeID.Clear();
            rdoPrePlan.Checked = true;
        }
        #endregion

        #region Event Double Click
        private void txtRecodeID_DoubleClick(object sender, EventArgs e)
        {
            if (rdoPrePlan.Checked)
                clsSearch.Search_TransactionPrePlane(ref txtRecodeID);
            if (rdoWip.Checked)
                clsSearch.Search_TransactionWorkInProgress(ref txtRecodeID);
            if (rdbInquery.Checked)
                clsSearch.Search_TransactionInquiry_Direct(ref txtRecodeID,true);
            if (rdbCustomerOrder.Checked)
                clsSearch.Search_TransactionCustomerOrder_Direct(ref txtRecodeID, true);

           if (rdoInvoice.Checked)
              clsSearch.Search_TransactionInvoice_Direct(ref txtRecodeID, true,false,false);
            if (rdoReceipt.Checked)
                clsSearch.Search_Receipt(ref txtRecodeID,false);
            if (rdoCheque.Checked)
                clsSearch.Search_TransactionCheque_Direct(ref txtRecodeID, true);
            if (rdoCreditNote.Checked)
                clsSearch.Search_TransactionCreditNote_Direct(ref txtRecodeID, true);
            if (rdoDebit.Checked)
                clsSearch.Search_TransactionDebitNote_Direct(ref txtRecodeID, true, false, false);

        } 
        #endregion

        #region Event Key Press
        private void txtRecodeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtRecodeID_DoubleClick(null, null);
                //if (rdoPrePlan.Checked)
                //    clsSearch.Search_TransactionPrePlane(ref txtRecodeID);
                //if (rdoWip.Checked)
                //    clsSearch.Search_TransactionWorkInProgress(ref txtRecodeID);
                //if (rdbInquery.Checked)
                //    clsSearch.Search_TransactionInquiry_Direct(ref txtRecodeID, true);
                //if (rdbCustomerOrder.Checked)
                //    clsSearch.Search_TransactionCustomerOrder_Direct(ref txtRecodeID, true);

                //if (rdoInvoice.Checked)
                //    clsSearch.Search_TransactionInvoice_Direct(ref txtRecodeID, true,false,false);
                //if (rdoReceipt.Checked)
                //    clsSearch.Search_Receipt(ref txtRecodeID,false);
                //if (rdoCheque.Checked)
                //    clsSearch.Search_TransactionCheque_Direct(ref txtRecodeID, true);
                //if (rdoCreditNote.Checked)
                //    clsSearch.Search_TransactionCreditNote_Direct(ref txtRecodeID, true);
                //if (rdoDebit.Checked)
                //    clsSearch.Search_TransactionDebitNote_Direct(ref txtRecodeID, true,false);
            }
        } 
        #endregion
        
    }
}
