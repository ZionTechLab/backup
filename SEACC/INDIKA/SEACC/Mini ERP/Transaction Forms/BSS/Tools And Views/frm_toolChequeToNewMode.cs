using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_toolChequeToNewMode : Form
    {
        #region Public variables
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        private void frm_toolCheckToDepositeMode1_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        public frm_toolChequeToNewMode()
        {
            iFormID = clsSecurity.getFormID(FormName.ChequeToNewMode);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
        }
        #endregion

        #region  Btn Save
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (txtRecodeID.Tag != null)
            {
                DialogResult msgResult = MessageBox.Show("Do You Want To Set this cheque to New mode? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    string sRemark = "Error", sActivity = "Error";
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        #region Cheque
                        tbl_bpsChequeRegister oldRecord = tbl_bpsChequeRegister.Select(txtRecodeID.Tag.ToString().Trim());
                        if (oldRecord == null || oldRecord.ChequeRegister_ID == "default" || oldRecord.IsDeleted)
                        {
                            sActivity = "Cheque is  Deleted or not found";
                            MessageBox.Show("This Cheque is  Deleted or not found........!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        if (!clsMethods_GL.CheckValidity_FinancialYear(oldRecord.DateDeposited) && clsMethods_GL.CheckValidity_FinancialYear(oldRecord.DateReconcilied))
                        {
                            return;
                        }

                        sRemark = "Cheque New mode || Cheque Number - " + oldRecord.ChequeNumber + " || Cheque Reg No - " + oldRecord.ChequeRegister_ID + " || Receipt ID - " + oldRecord.Receipt_ID + " || Order Ref. No - " + oldRecord.OrderRefNo_ID + " || Amount - " + clsFormatter.FormatDecimalPlaces_UnitPrice(oldRecord.Amount);
                        if (oldRecord.IsReconcilied && oldRecord.RecSerialNo != -1)
                        {
                            sActivity = "Reconciled  Cheque, It is Not Allow To Set To New Mode";
                            MessageBox.Show("This is a Reconciled  Cheque, It is Not Allow To Set To New Mode .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (oldRecord.IsReIssued)
                        {
                            sActivity = "ReIssued  Cheque, It is Not Allow To Set To New Mode";
                            MessageBox.Show("This is a ReIssued  Cheque, It is Not Allow To Set To New Mode .", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
          
                        #region tbl_bpsChequeReconciliation
                        foreach (tbl_bpsChequeReconciliation_Detail oReconDetail in tbl_bpsChequeReconciliation_Detail.SelectAllByChequeRegister_ID(txtRecodeID.Tag.ToString()))
                        {
                         //   clsMethods_GL.GLPosting_Delete(oReconDetail.GlPosting_ID);
                            tbl_bpsChequeReconciliation oRecon = tbl_bpsChequeReconciliation.Select(oReconDetail.Reconciliation_ID);
                            if (oRecon != null)
                            {
                                oRecon.TotalAmount -= oldRecord.Amount;
                                oReconDetail.Delete();
                            }
                        }
                        #endregion

                        #region tbl_bpsChequeDeposit
                        foreach (tbl_bpsChequeDeposit_Detail oDepositDetai in tbl_bpsChequeDeposit_Detail.SelectAllByChequeRegister_ID(txtRecodeID.Tag.ToString()))
                        {
                       //     clsMethods_GL.GLPosting_Delete(oDepositDetai.GlPosting_ID);
                            tbl_bpsChequeDeposit oDept = tbl_bpsChequeDeposit.Select(oDepositDetai.ChequeDeposit_ID);
                            if (oDept != null)
                            {
                                oDept.TotalAmount -= oldRecord.Amount;
                                oDepositDetai.Delete();
                            }

                        }
                        #endregion

                        foreach (tbl_bpsCreditNote oCR in tbl_bpsCreditNote.SelectAllByChequeRegister_IDy(oldRecord.ChequeRegister_ID))
                        {
                            tbl_bpsCreditNote_Invoice.DeleteAllByCreditNote_ID(oCR.CreditNote_ID);
                            tbl_sasInvoice_Sattled.DeleteAllByCreditNote_ID(oCR.CreditNote_ID);
                            oCR.Delete();
                        }

                        foreach (tbl_sasInvoice oInv in tbl_sasInvoice.SelectAllByChequeRegister_ID(oldRecord.ChequeRegister_ID))
                        {
                            tbl_sasInvoice_Sattled.DeleteAllByInvoice_ID(oInv.Invoice_ID);
                            tbl_bpsReceipt_Invoice.DeleteAllByInvoice_ID(oInv.Invoice_ID);

                            foreach (tbl_bpsReceipt oRe in tbl_bpsReceipt.SelectAllByInvoice_ID(oInv.Invoice_ID))
                            {
                                oRe.Invoice_ID = "default";
                                oRe.Update();
                            }

                            oInv.Delete();
                        }

                        foreach (var opost in tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oldRecord.ChequeRegister_ID).Where(p=>p.Slot_ID !=6))
                        {
                            clsMethods_GL.GLPosting_Delete(opost.GlPosting_ID);
                        }

                        oldRecord.AccountNumber = "";
                        oldRecord.DepositedAccountNumber = "";
                        oldRecord.CompanyAccount_ID = -1;
                        oldRecord.DepositedBank_ID = "default";
                        oldRecord.DepositedBranch_ID = "default";

                        oldRecord.ChequeStatus_ID = "0";
                        oldRecord.IsReconcilied = false;
                        oldRecord.IsDepositted = false;
                        oldRecord.IsReturned = false;
                        oldRecord.DepositCount = 0;
                        oldRecord.IsSetteled = false;
                        oldRecord.SetteledAmount = 0;

                        oldRecord.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction);
                        oldRecord.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction);

                        oldRecord.Update();

                        sActivity = "Cheque Has Set To New Mode.";
                        MessageBox.Show(sActivity, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        arc_audAuditTrailLog oAdutLog = new arc_audAuditTrailLog(clsSecurity.getServerDateTime(), clsSecurity.CompanyID + " || " + clsSecurity.BranchID, clsSecurity.UserIDLoged, clsSecurity.TerminalID, "", "", "", sActivity, sRemark);
                        oAdutLog.Insert();
                        ClearFields();
                        Cursor = Cursors.Default;
                    }
                }
            }
        }
        #endregion

        #region Btn Close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region btn Reset
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            // clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtRecodeID, false);
            txtRecodeID.ReadOnly = true;
            txtRecodeID.Tag = null;
            txtRecodeID.Clear();
        }
        #endregion

        #region Event Double Click
        private void txtRecodeID_DoubleClick(object sender, EventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ChequeregisterByCheque);

            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtRecodeID.Tag = lstResult[0];
                txtRecodeID.Text = lstResult[1];
            }
        }
        #endregion

        #region Event Key Press
        private void txtRecodeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtRecodeID_DoubleClick(null, null);
        }
        #endregion

        private void txtRecodeID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}