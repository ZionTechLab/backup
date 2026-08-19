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
    public partial class frmPendingApprovals : SEACC_Form
    {
        #region variables
        public DataTable dtCheckPending = new DataTable();
        public DataTable dtForm = new DataTable();
        public DataTable dtApprovalPending = new DataTable();
        public DataTable dtFormApprove = new DataTable();
        #endregion

        #region Form Load
        public frmPendingApprovals(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmPendingApprovals_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, false, false, false, false, false, false);
            clsFormatter.ApplyGridFormat_New(dgvApprovalPending, clsFormatter.colorGrid, clsFormatter.colorAdmin);
            clsFormatter.ApplyGridFormat_New(dgvCheckPending, clsFormatter.colorGrid, clsFormatter.colorAdmin);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvFormApprove, clsFormatter.colorGrid, clsFormatter.colorAdmin);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvFormCheck, clsFormatter.colorGrid, clsFormatter.colorAdmin);

            dgvFormCheck.AutoGenerateColumns = false;
            dgvCheckPending.AutoGenerateColumns = false;
            dgvFormApprove.AutoGenerateColumns = false;
            dgvApprovalPending.AutoGenerateColumns = false;

            Refresh_ModuleCmbCheck();
            Refresh_BranchCmbCheck();

            Refresh_ModuleCmbApprove();
            Refresh_BranchCmbApprove();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridCheckPending(string sUserID)
        {
            try
            {
                if (((ComboBoxItem)cmbComBranchCheck.SelectedItem) != null && ((ComboBoxItem)cmbModuleCheck.SelectedItem) != null)
                {
                    Cursor = Cursors.WaitCursor;
                    dtCheckPending.Rows.Clear();
                    dtForm.Rows.Clear();
                    dtCheckPending.DefaultView.RowFilter = "";

                    dtForm.Merge(DBHandling.ExecQuery("exec sp_CheckPending '" + sUserID + "', '" + ((ComboBoxItem)cmbModuleCheck.SelectedItem).Value + "', '" + ((ComboBoxItem)cmbComBranchCheck.SelectedItem).Value + "'").Tables[0]);
                    if (dtForm.Rows.Count > 0)
                    {
                        dtCheckPending.Merge(dtForm);
                        dtForm = dtForm.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["formID"] })
                                    .Select(g => g.OrderBy(r => r["formID"]).First())
                                    .CopyToDataTable();
                        dgvFormCheck.DataSource = dtForm;
                        dgvCheckPending.DataSource = dtCheckPending;

                        dgvFormCheck_CellMouseClick(dgvCheckPending, new DataGridViewCellMouseEventArgs(1, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        private void RefreshGridApprovalPending(string sUserID)
        {
            try
            {
                if (((ComboBoxItem)cmbComBranchApprove.SelectedItem) != null && ((ComboBoxItem)cmbModuleApprove.SelectedItem) != null)
                {
                    Cursor = Cursors.WaitCursor;
                    dtApprovalPending.Rows.Clear();
                    dtFormApprove.Rows.Clear();
                    dtApprovalPending.DefaultView.RowFilter = "";

                    dtFormApprove.Merge(DBHandling.ExecQuery("exec sp_ApprovalPending '" + sUserID + "', '" + ((ComboBoxItem)cmbModuleApprove.SelectedItem).Value + "', '" + ((ComboBoxItem)cmbComBranchApprove.SelectedItem).Value + "'").Tables[0]);
                    if (dtFormApprove.Rows.Count > 0)
                    {
                        dtApprovalPending.Merge(dtFormApprove);
                        dtFormApprove = dtFormApprove.AsEnumerable()
                                            .GroupBy(r => new { Col1 = r["formIDApp"] })
                                            .Select(g => g.OrderBy(r => r["formIDApp"]).First())
                                            .CopyToDataTable();
                        dgvFormApprove.DataSource = dtFormApprove;
                        dgvApprovalPending.DataSource = dtApprovalPending;

                        dgvFormApprove_CellMouseClick(dgvFormApprove, new DataGridViewCellMouseEventArgs(1, 0, 0, 0, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally { Cursor = Cursors.Default; }
        }
        #endregion

        #region btn Clear
        private void btnClearCheck_Click(object sender, EventArgs e)
        {
            Refresh_ModuleCmbCheck();
            Refresh_BranchCmbCheck();

            RefreshGridCheckPending(clsSecurity.UserIDLoged);
            chkCheck.Checked = false;
        }

        private void btnClearApprove_Click(object sender, EventArgs e)
        {
            Refresh_ModuleCmbApprove();
            Refresh_BranchCmbApprove();

            RefreshGridApprovalPending(clsSecurity.UserIDLoged);
            chkApprove.Checked = false;
        }
        #endregion

        #region btn Save

        #region Save Check pending
        private void btnSaveCheck_Click(object sender, EventArgs e)
        {
            if (CheckValidityGridSelection_CheckPending())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    #region Upadate Tables
                    foreach (DataGridViewRow row in dgvCheckPending.Rows)
                    {
                        bool bSelected = clsValidate.ValidateGridValue(dgvCheckPending, "isCheck", row.Index, false);

                        if (bSelected)
                        {
                            string sFormID = clsValidate.ValidateGridValue(dgvCheckPending, "formID", row.Index, "");
                            string sTransactionID = clsValidate.ValidateGridValue(dgvCheckPending, "txnID", row.Index, "default");

                            #region ERP 

                            #region CO
                            if (sFormID == "9" && sTransactionID != "default")
                            {
                                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region DO
                            else if (sFormID == "11" && sTransactionID != "default")
                            {
                                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Invoice
                            else if (sFormID == "10" || sFormID == "620" && sTransactionID != "default")
                            {
                                tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sales Receipt / iReceipt
                            else if (sFormID == "621" || sFormID == "255" && sTransactionID != "default")
                            {
                                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sales Return
                            else if (sFormID == "176" && sTransactionID != "default")
                            {
                                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Quotation
                            else if (sFormID == "23" && sTransactionID != "default")
                            {
                                tbl_sasQuotation detail = tbl_sasQuotation.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PO
                            else if (sFormID == "128" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GRN
                            else if (sFormID == "129" && sTransactionID != "default")
                            {
                                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GIN
                            else if (sFormID == "131" && sTransactionID != "default")
                            {
                                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Adj.
                            else if (sFormID == "156" && sTransactionID != "default")
                            {
                                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region DGN.
                            else if (sFormID == "132" && sTransactionID != "default")
                            {
                                tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Dis.GN
                            else if (sFormID == "133" && sTransactionID != "default")
                            {
                                tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Split Note
                            else if (sFormID == "196" && sTransactionID != "default")
                            {
                                tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PRN
                            else if (sFormID == "130" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PRquisition
                            else if (sFormID == "253" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iGRN
                            else if (sFormID == "62" && sTransactionID != "default")
                            {
                                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iGIN
                            else if (sFormID == "63" && sTransactionID != "default")
                            {
                                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iSR
                            else if (sFormID == "64" && sTransactionID != "default")
                            {
                                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GTN
                            else if (sFormID == "14" && sTransactionID != "default")
                            {
                                tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region FGTN
                            else if (sFormID == "192" && sTransactionID != "default")
                            {
                                tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Credit note
                            else if (sFormID == "135" && sTransactionID != "default")
                            {
                                tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Debit note/ Cus. Refund note
                            else if (sFormID == "140" || sFormID == "441" && sTransactionID != "default")
                            {
                                tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region APN
                            else if (sFormID == "378" && sTransactionID != "default")
                            {
                                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PV
                            else if (sFormID == "410" && sTransactionID != "default")
                            {
                                tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Acc. Receipt
                            else if (sFormID == "406" && sTransactionID != "default")
                            {
                                tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sup. DBN
                            else if (sFormID == "437" && sTransactionID != "default")
                            {
                                tbl_accDebitNote detail = tbl_accDebitNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region BAE/ Jornal entry
                            else if (sFormID == "418" || sFormID == "630" || sFormID == "631" && sTransactionID != "default")
                            {
                                tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #endregion

                            #region Prod Apparel
                            //BOM Sales
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7100" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked1 = true;
                                    detail.DateChecked1 = clsSecurity.getServerDateTime();
                                    detail.Checked1User_ID = clsSecurity.UserIDLoged;
                                    detail.Checked1UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //BOM Detail
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7101" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked2 = true;
                                    detail.DateChecked2 = clsSecurity.getServerDateTime();
                                    detail.Checked2User_ID = clsSecurity.UserIDLoged;
                                    detail.Checked2UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //BOM Finamce
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7102" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked3 = true;
                                    detail.DateChecked3 = clsSecurity.getServerDateTime();
                                    detail.Checked3User_ID = clsSecurity.UserIDLoged;
                                    detail.Checked3UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //MR
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7103" && sTransactionID != "default")
                            {
                                tbl_prodTxMaterialRequision detail = tbl_prodTxMaterialRequision.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //PGIN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7104" && sTransactionID != "default")
                            {
                                tbl_prodTxGoodIssueNote detail = tbl_prodTxGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //PGRN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7105" && sTransactionID != "default")
                            {
                                tbl_prodTxGoodReturnNote detail = tbl_prodTxGoodReturnNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //S-OUT
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7106" && sTransactionID != "default")
                            {
                                tbl_prodTxSubContractOutNote detail = tbl_prodTxSubContractOutNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //S-IN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7107" && sTransactionID != "default")
                            {
                                tbl_prodTxSubContractInNote detail = tbl_prodTxSubContractInNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //WIP
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7108" && sTransactionID != "default")
                            {
                                tbl_prodTxWorkInProgress detail = tbl_prodTxWorkInProgress.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //FGTN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7109" && sTransactionID != "default")
                            {
                                tbl_prodTxFinishedGoodTransferNote detail = tbl_prodTxFinishedGoodTransferNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //FGTN ACPT
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7116" && sTransactionID != "default")
                            {
                                tbl_prodTxFinishedGoodTransferAcceptance detail = tbl_prodTxFinishedGoodTransferAcceptance.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.CheckedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            #endregion
                        }

                    }
                    #endregion

                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    RefreshGridCheckPending(clsSecurity.UserIDLoged);
                }
            }
        }
        #endregion

        #region Save Approve pending
        private void btn_SaveApprove_Click(object sender, EventArgs e)
        {
            if (CheckValidityGridSelection_ApprovalPending())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    #region Upadate Tables
                    foreach (DataGridViewRow row in dgvApprovalPending.Rows)
                    {
                        bool bSelected = clsValidate.ValidateGridValue(dgvApprovalPending, "isApprove", row.Index, false);

                        if (bSelected)
                        {
                            string sFormID = clsValidate.ValidateGridValue(dgvApprovalPending, "formIDApp", row.Index, "");
                            string sTransactionID = clsValidate.ValidateGridValue(dgvApprovalPending, "txnIDApp", row.Index, "default");

                            #region ERP Tx

                            #region CO
                            if (sFormID == "9" && sTransactionID != "default")
                            {
                                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region DO
                            else if (sFormID == "11" && sTransactionID != "default")
                            {
                                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Invoice
                            else if (sFormID == "10" || sFormID == "620" && sTransactionID != "default")
                            {
                                tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsChecked = true;
                                    detail.DateChecked = clsSecurity.getServerDateTime();
                                    detail.CheckedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sales Receipt / iReceipt
                            else if (sFormID == "621" || sFormID == "255" && sTransactionID != "default")
                            {
                                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sales Return
                            else if (sFormID == "176" && sTransactionID != "default")
                            {
                                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Quotation
                            else if (sFormID == "23" && sTransactionID != "default")
                            {
                                tbl_sasQuotation detail = tbl_sasQuotation.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PO
                            else if (sFormID == "128" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GRN
                            else if (sFormID == "129" && sTransactionID != "default")
                            {
                                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GIN
                            else if (sFormID == "131" && sTransactionID != "default")
                            {
                                tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Adj.
                            else if (sFormID == "156" && sTransactionID != "default")
                            {
                                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region DGN.
                            else if (sFormID == "132" && sTransactionID != "default")
                            {
                                tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Dis.GN
                            else if (sFormID == "133" && sTransactionID != "default")
                            {
                                tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Split Note
                            else if (sFormID == "196" && sTransactionID != "default")
                            {
                                tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PRN
                            else if (sFormID == "130" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PRquisition
                            else if (sFormID == "253" && sTransactionID != "default")
                            {
                                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iGRN
                            else if (sFormID == "62" && sTransactionID != "default")
                            {
                                tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iGIN
                            else if (sFormID == "63" && sTransactionID != "default")
                            {
                                tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region iSR
                            else if (sFormID == "64" && sTransactionID != "default")
                            {
                                tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region GTN
                            else if (sFormID == "14" && sTransactionID != "default")
                            {
                                tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region FGTN
                            else if (sFormID == "192" && sTransactionID != "default")
                            {
                                tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Credit note
                            else if (sFormID == "135" && sTransactionID != "default")
                            {
                                tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Debit note/ Cus. Refund note
                            else if (sFormID == "140" || sFormID == "441" && sTransactionID != "default")
                            {
                                tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region APN
                            else if (sFormID == "378" && sTransactionID != "default")
                            {
                                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region PV
                            else if (sFormID == "410" && sTransactionID != "default")
                            {
                                tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Acc. Receipt
                            else if (sFormID == "406" && sTransactionID != "default")
                            {
                                tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region Sup. DBN
                            else if (sFormID == "437" && sTransactionID != "default")
                            {
                                tbl_accDebitNote detail = tbl_accDebitNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #region BAE/ Jornal entry
                            else if (sFormID == "418" || sFormID == "630" || sFormID == "631" && sTransactionID != "default")
                            {
                                tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.Update();
                                }
                            }
                            #endregion

                            #endregion

                            #region Prod Apparel
                            //BOM Sales
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7100" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved1 = true;
                                    detail.DateApproved1 = clsSecurity.getServerDateTime();
                                    detail.Approved1User_ID = clsSecurity.UserIDLoged;
                                    detail.Approved1UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //BOM Detail
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7101" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved2 = true;
                                    detail.DateApproved2 = clsSecurity.getServerDateTime();
                                    detail.Approved2User_ID = clsSecurity.UserIDLoged;
                                    detail.Approved2UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //BOM Finamce
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7102" && sTransactionID != "default")
                            {
                                tbl_prodTxJobCard detail = tbl_prodTxJobCard.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved3 = true;
                                    detail.DateApproved3 = clsSecurity.getServerDateTime();
                                    detail.Approved3User_ID = clsSecurity.UserIDLoged;
                                    detail.Approved3UserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //MR
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7103" && sTransactionID != "default")
                            {
                                tbl_prodTxMaterialRequision detail = tbl_prodTxMaterialRequision.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //PGIN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7104" && sTransactionID != "default")
                            {
                                tbl_prodTxGoodIssueNote detail = tbl_prodTxGoodIssueNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //PGRN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7105" && sTransactionID != "default")
                            {
                                tbl_prodTxGoodReturnNote detail = tbl_prodTxGoodReturnNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //S-OUT
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7106" && sTransactionID != "default")
                            {
                                tbl_prodTxSubContractOutNote detail = tbl_prodTxSubContractOutNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //S-IN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7107" && sTransactionID != "default")
                            {
                                tbl_prodTxSubContractInNote detail = tbl_prodTxSubContractInNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //WIP
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7108" && sTransactionID != "default")
                            {
                                tbl_prodTxWorkInProgress detail = tbl_prodTxWorkInProgress.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //FGTN
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7109" && sTransactionID != "default")
                            {
                                tbl_prodTxFinishedGoodTransferNote detail = tbl_prodTxFinishedGoodTransferNote.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }

                            //FGTN ACPT
                            if (clsHelpMethods.Check_ProdApparel_Enable() && sFormID == "7116" && sTransactionID != "default")
                            {
                                tbl_prodTxFinishedGoodTransferAcceptance detail = tbl_prodTxFinishedGoodTransferAcceptance.Select(sTransactionID);
                                if (detail != null)
                                {
                                    detail.IsApproved = true;
                                    detail.DateApproved = clsSecurity.getServerDateTime();
                                    detail.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                    detail.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                    detail.Update();
                                }
                            }
                        }
                        #endregion

                    }
                    #endregion

                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    RefreshGridApprovalPending(clsSecurity.UserIDLoged);
                }
            }
        }
        #endregion

        #endregion

        #region Check Validity
        private bool CheckValidityGridSelection_CheckPending()
        {
            bool bStatus = false;

            foreach (DataGridViewRow row1 in dgvCheckPending.Rows)
            {
                bool cb = (bool)row1.Cells[6].FormattedValue;
                if (cb == true)
                {
                    bStatus = true;
                    break;
                }
            }
            if (!bStatus)
                MessageBox.Show("Please select transaction/s to check......!", "Validation Error");
            return bStatus;
        }

        private bool CheckValidityGridSelection_ApprovalPending()
        {
            bool bStatus = false;

            foreach (DataGridViewRow row1 in dgvApprovalPending.Rows)
            {
                bool cb = (bool)row1.Cells[7].FormattedValue;
                if (cb == true)
                {
                    bStatus = true;
                    break;
                }
            }
            if (!bStatus)
                MessageBox.Show("Please select transaction/s to approve......!", "Validation Error");
            return bStatus;
        }
        #endregion

        #region Grid events
        private void dgvFormCheck_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvFormCheck.Columns[e.ColumnIndex].Name;

                    if (sColName == "formName")
                    {
                        string sFormName = clsValidate.ValidateGridValue(dgvFormCheck, "formName", e.RowIndex, "");
                        string sFormID = clsValidate.ValidateGridValue(dgvFormCheck, "no", e.RowIndex, "");


                        StringBuilder sFilter = new StringBuilder();
                        string sFilteredValue = clsHelpMethods.CheckValue(sFormID);
                        sFilter.Append("formID = '" + sFilteredValue + "' ");
                        dtCheckPending.DefaultView.RowFilter = sFilter.ToString();

                        if (chkCheck.Checked)
                            chkCheck.Checked = false;
                        for (int x = 0; x < dgvCheckPending.Rows.Count; x++)
                            dgvCheckPending["isCheck", x].Value = false;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvFormApprove_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvFormApprove.Columns[e.ColumnIndex].Name;

                    if (sColName == "formNameApp")
                    {
                        string sFormName = clsValidate.ValidateGridValue(dgvFormApprove, "formNameApp", e.RowIndex, "");
                        string sFormID = clsValidate.ValidateGridValue(dgvFormApprove, "noApp", e.RowIndex, "");


                        StringBuilder sFilter = new StringBuilder();
                        string sFilteredValue = clsHelpMethods.CheckValue(sFormID);
                        sFilter.Append("formIDApp = '" + sFilteredValue + "'");
                        dtApprovalPending.DefaultView.RowFilter = sFilter.ToString();

                        if (chkApprove.Checked)
                            chkApprove.Checked = false;
                        for (int x = 0; x < dgvApprovalPending.Rows.Count; x++)
                            dgvApprovalPending["isApprove", x].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvCheckPending_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvCheckPending.Columns[e.ColumnIndex].Name;

                    if (sColName == "isCheck")
                    {
                        bool bstatus = clsValidate.ValidateGridValue(dgvCheckPending, "isCheck", e.RowIndex, false);
                        dgvCheckPending[e.ColumnIndex, e.RowIndex].Value = !bstatus;
                    }

                    if (sColName == "txnID")
                    {
                        string sFormID = clsValidate.ValidateGridValue(dgvCheckPending, "formID", e.RowIndex, "");
                        string sTransactionID = clsValidate.ValidateGridValue(dgvCheckPending, "txnID", e.RowIndex, "");


                        #region Customer Order
                        if (sFormID == "9")
                        {
                            tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                                frm.glbCustomerOrderID = detail.CustomerOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Delivery order
                        else if (sFormID == "11")
                        {
                            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                                frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Invoice
                        else if (sFormID == "10")
                        {
                            tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                                frm.glbInvoiceID = detail.Invoice_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Invoice
                        else if (sFormID == "620")
                        {
                            tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasInvoice2 frm = new frm_sasInvoice2(FormName.SalesInvoice2);
                                frm.glbInvoiceID = detail.Invoice_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Sales Receipt / iReceipt
                        if (sFormID == "621" || sFormID == "255")
                        {
                            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.IsSalesReceipt)
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                                    frm.glbReceiptID = detail.Receipt_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                                else
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                    frm.glbReceiptID = detail.Receipt_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                        #region SRN
                        else if (sFormID == "176")
                        {
                            tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasSalseReturnNote frm = new frm_sasSalseReturnNote(FormName.sasSalesReturenNote);
                                frm.glbSalesReturnedNoteID = detail.SalesReturnedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Quotation
                        else if (sFormID == "23")
                        {
                            tbl_sasQuotation detail = tbl_sasQuotation.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasQuotation frm = new frm_sasQuotation(FormName.CusQuotation);
                                frm.glbQuotationID = detail.Quotation_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PO
                        else if (sFormID == "128")
                        {
                            tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(FormName.scsPOSupplier);
                                frm.glbPurchaseOrderID = detail.PurchaseOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GRN
                        else if (sFormID == "129")
                        {
                            tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
                                frm.glbGoodReceiveNote = detail.ExternalGoodReceivedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GIN
                        else if (sFormID == "131")
                        {
                            tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsExternalGoodIssueNote frm = new frm_scsExternalGoodIssueNote(FormName.scsGINExternal);
                                frm.glbGINNo = detail.ExternalGoodIssueNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Adj
                        else if (sFormID == "156")
                        {
                            tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStockAdjustment frm = new frm_scsStockAdjustment(FormName.scsStockAdjusment);
                                frm.glbStockAdjustmentNo = detail.StockAdjustment_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region DGN
                        else if (sFormID == "132")
                        {
                            tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsDamageGoodsNote frm = new frm_scsDamageGoodsNote(FormName.scsStockAdjusment);
                                frm.glbDGNNo = detail.DamagedGoodNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Dis.GN
                        else if (sFormID == "133")
                        {
                            tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsDiscardedGoodNote frm = new frm_scsDiscardedGoodNote(FormName.scsDiscardedGoodsNote);
                                frm.glbDisGnNo = detail.DiscardedGoodNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Split Note
                        else if (sFormID == "196")
                        {
                            tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasItemSpradeNote frm = new frm_sasItemSpradeNote(FormName.sasItemSparadeNote);
                                frm.glbSplitNoteID = detail.ItemSpred_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PRN
                        else if (sFormID == "130")
                        {
                            tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
                                frm.glbPRNNo = detail.PurchaseReturnedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region P. Requisition
                        else if (sFormID == "253")
                        {
                            tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote(FormName.PurchaseRequisition);
                                frm.glbPRNo = detail.PurchaseRequisitionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iGRN
                        else if (sFormID == "62")
                        {
                            tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
                                frm.glbGRNNo = detail.StoreGoodReceiveNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iGIN
                        else if (sFormID == "63")
                        {
                            tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                                frm.glbGINNo = detail.StoreGoodIssueNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iSRN
                        else if (sFormID == "64")
                        {
                            tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
                                frm.glbSRNo = detail.StoreRecositionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GTN
                        else if (sFormID == "14")
                        {
                            tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsGoodTransferNote_new frm = new frm_scsGoodTransferNote_new(FormName.scsGoodTransferNote);
                                frm.glbGTNNo = detail.GoodTransferNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region FGTN
                        else if (sFormID == "192")
                        {
                            tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreProduction frm = new frm_scsStoreProduction(FormName.scsStoreProduction);
                                frm.glbFGTNID = detail.StoreProduction_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region CRN
                        else if (sFormID == "135")
                        {
                            tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_bpsCreditNote2 frm = new frm_bpsCreditNote2(FormName.bssCreditNote);
                                frm.glbCreditNoteID = detail.CreditNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region DBN
                        else if (sFormID == "140" || sFormID == "441")
                        {
                            tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.IsCustomerRefundableNote)
                                {
                                    frm_bpsDebitNote frm = new frm_bpsDebitNote(FormName.bssCustomerRefundableNote);
                                    frm.glbDebiNoteID = detail.DebitNote_ID;
                                    frm.gbl_bIsRefundableNote = true;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                                else
                                {
                                    frm_bpsDebitNote frm = new frm_bpsDebitNote(FormName.bssDebitNote);
                                    frm.glbDebiNoteID = detail.DebitNote_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                        #region APN
                        else if (sFormID == "378")
                        {
                            tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accAccountpayableNote frm = new frm_accAccountpayableNote(FormName.accAccountpayableNote_Allocation);
                                frm.glbAPNID = detail.AccountPayableNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PV
                        else if (sFormID == "410")
                        {
                            tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accPaymentVoucher frm = new frm_accPaymentVoucher(FormName.accPaymentVoucher);
                                frm.glbPamentVoucher = detail.PaymentVoucher_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region AReceipt
                        else if (sFormID == "406")
                        {
                            tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accAccountReceipt frm = new frm_accAccountReceipt(FormName.accReceiptVoucher);
                                frm.glbAccReceiptID = detail.AccountReceipt_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region SDBN
                        else if (sFormID == "437")
                        {
                            tbl_accDebitNote detail = tbl_accDebitNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_AccDebitNote frm = new frm_AccDebitNote(FormName.accDebitNote);
                                frm.glbDebitNoteID = detail.DebitNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region BE / JE Cr / Db
                        if (sFormID == "418" || sFormID == "630" || sFormID == "631")
                        {
                            tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.JournalEntryType_ID == "CON/017")
                                {
                                    frm_accJournalVoucher frm = new frm_accJournalVoucher(FormName.accJournalEntry_Bank);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                                else if (detail.JournalEntryType_ID == "CON/630")
                                {
                                    UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Creditor);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                                else if (detail.JournalEntryType_ID == "CON/631")
                                {
                                    UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Debtor);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvApprovalPending_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvApprovalPending.Columns[e.ColumnIndex].Name;

                    if (sColName == "isApprove")
                    {
                        bool bstatus = clsValidate.ValidateGridValue(dgvApprovalPending, "isApprove", e.RowIndex, false);
                        dgvApprovalPending[e.ColumnIndex, e.RowIndex].Value = !bstatus;
                    }

                    if (sColName == "txnIDApp")
                    {
                        string sFormID = clsValidate.ValidateGridValue(dgvApprovalPending, "formIDAPP", e.RowIndex, "");
                        string sTransactionID = clsValidate.ValidateGridValue(dgvApprovalPending, "txnIDApp", e.RowIndex, "");


                        #region Customer Order
                        if (sFormID == "9")
                        {
                            tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                                frm.glbCustomerOrderID = detail.CustomerOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Delivery order
                        else if (sFormID == "11")
                        {
                            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                                frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Invoice
                        else if (sFormID == "10")
                        {
                            int iFormID_Inv2 = (int)FormName.SalesInvoice2;
                            tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                            if (detail != null)
                            {
                                tbl_securityFormMaster oForm = tbl_securityFormMaster.Select(iFormID_Inv2);
                                if (oForm.IsEnable == true)
                                {
                                    frm_sasInvoice frm = new frm_sasInvoice(FormName.Invoice_TAXReverced);
                                    frm.glbInvoiceID = detail.Invoice_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                                else
                                {
                                    frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                                    frm.glbInvoiceID = detail.Invoice_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                        #region Invoice 2
                        else if (sFormID == "620")
                        {
                            tbl_sasInvoice detail = tbl_sasInvoice.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasInvoice2 frm = new frm_sasInvoice2(FormName.SalesInvoice2);
                                frm.glbInvoiceID = detail.Invoice_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Sales Receipt / iReceipt
                        if (sFormID == "621" || sFormID == "255")
                        {
                            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.IsSalesReceipt)
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                                    frm.glbReceiptID = detail.Receipt_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                                else
                                {
                                    UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                    frm.glbReceiptID = detail.Receipt_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                        #region SRN
                        else if (sFormID == "176")
                        {
                            tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasSalseReturnNote frm = new frm_sasSalseReturnNote(FormName.sasSalesReturenNote);
                                frm.glbSalesReturnedNoteID = detail.SalesReturnedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Quotation
                        else if (sFormID == "23")
                        {
                            tbl_sasQuotation detail = tbl_sasQuotation.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasQuotation frm = new frm_sasQuotation(FormName.CusQuotation);
                                frm.glbQuotationID = detail.Quotation_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PO
                        else if (sFormID == "128")
                        {
                            tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseOrder frm = new frm_scsPurchaseOrder(FormName.scsPOSupplier);
                                frm.glbPurchaseOrderID = detail.PurchaseOrder_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GRN
                        else if (sFormID == "129")
                        {
                            tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
                                frm.glbGoodReceiveNote = detail.ExternalGoodReceivedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GIN
                        else if (sFormID == "131")
                        {
                            tbl_scsExternalGoodIssueNote detail = tbl_scsExternalGoodIssueNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsExternalGoodIssueNote frm = new frm_scsExternalGoodIssueNote(FormName.scsGINExternal);
                                frm.glbGINNo = detail.ExternalGoodIssueNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Adj
                        else if (sFormID == "156")
                        {
                            tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStockAdjustment frm = new frm_scsStockAdjustment(FormName.scsStockAdjusment);
                                frm.glbStockAdjustmentNo = detail.StockAdjustment_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region DGN
                        else if (sFormID == "132")
                        {
                            tbl_scsDamagedGoodNote detail = tbl_scsDamagedGoodNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsDamageGoodsNote frm = new frm_scsDamageGoodsNote(FormName.scsStockAdjusment);
                                frm.glbDGNNo = detail.DamagedGoodNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Dis.GN
                        else if (sFormID == "133")
                        {
                            tbl_scsDiscardedGoodNote detail = tbl_scsDiscardedGoodNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsDiscardedGoodNote frm = new frm_scsDiscardedGoodNote(FormName.scsDiscardedGoodsNote);
                                frm.glbDisGnNo = detail.DiscardedGoodNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region Split Note
                        else if (sFormID == "196")
                        {
                            tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_sasItemSpradeNote frm = new frm_sasItemSpradeNote(FormName.sasItemSparadeNote);
                                frm.glbSplitNoteID = detail.ItemSpred_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PRN
                        else if (sFormID == "130")
                        {
                            tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseReturnNote frm = new frm_scsPurchaseReturnNote(FormName.scsPRNSupplier);
                                frm.glbPRNNo = detail.PurchaseReturnedNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region P. Requisition
                        else if (sFormID == "253")
                        {
                            tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsPurchaseRequisitionNote frm = new frm_scsPurchaseRequisitionNote(FormName.PurchaseRequisition);
                                frm.glbPRNo = detail.PurchaseRequisitionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iGRN
                        else if (sFormID == "62")
                        {
                            tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreGoodReceiveNote frm = new frm_scsStoreGoodReceiveNote(FormName.sasGRNTradingStock);
                                frm.glbGRNNo = detail.StoreGoodReceiveNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iGIN
                        else if (sFormID == "63")
                        {
                            tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreGoodIssueNote frm = new frm_scsStoreGoodIssueNote(FormName.sasGINTradingStock);
                                frm.glbGINNo = detail.StoreGoodIssueNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region iSRN
                        else if (sFormID == "64")
                        {
                            tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreRequisitionNote frm = new frm_scsStoreRequisitionNote(FormName.sasSRNTradingStock);
                                frm.glbSRNo = detail.StoreRecositionNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region GTN
                        else if (sFormID == "14")
                        {
                            tbl_scsGoodTransferNote detail = tbl_scsGoodTransferNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsGoodTransferNote_new frm = new frm_scsGoodTransferNote_new(FormName.scsGoodTransferNote);
                                frm.glbGTNNo = detail.GoodTransferNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region FGTN
                        else if (sFormID == "192")
                        {
                            tbl_scsStoreProduction detail = tbl_scsStoreProduction.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_scsStoreProduction frm = new frm_scsStoreProduction(FormName.scsStoreProduction);
                                frm.glbFGTNID = detail.StoreProduction_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region CRN
                        else if (sFormID == "135")
                        {
                            tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_bpsCreditNote2 frm = new frm_bpsCreditNote2(FormName.bssCreditNote);
                                frm.glbCreditNoteID = detail.CreditNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region DBN
                        else if (sFormID == "140" || sFormID == "441")
                        {
                            tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.IsCustomerRefundableNote)
                                {
                                    frm_bpsDebitNote frm = new frm_bpsDebitNote(FormName.bssCustomerRefundableNote);
                                    frm.glbDebiNoteID = detail.DebitNote_ID;
                                    frm.gbl_bIsRefundableNote = true;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                                }
                                else
                                {
                                    frm_bpsDebitNote frm = new frm_bpsDebitNote(FormName.bssDebitNote);
                                    frm.glbDebiNoteID = detail.DebitNote_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                        #region APN
                        else if (sFormID == "378")
                        {
                            tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accAccountpayableNote frm = new frm_accAccountpayableNote(FormName.accAccountpayableNote_Allocation);
                                frm.glbAPNID = detail.AccountPayableNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region PV
                        else if (sFormID == "410")
                        {
                            tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accPaymentVoucher frm = new frm_accPaymentVoucher(FormName.accPaymentVoucher);
                                frm.glbPamentVoucher = detail.PaymentVoucher_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region AReceipt
                        else if (sFormID == "406")
                        {
                            tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_accAccountReceipt frm = new frm_accAccountReceipt(FormName.accReceiptVoucher);
                                frm.glbAccReceiptID = detail.AccountReceipt_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region SDBN
                        else if (sFormID == "437")
                        {
                            tbl_accDebitNote detail = tbl_accDebitNote.Select(sTransactionID);
                            if (detail != null)
                            {
                                frm_AccDebitNote frm = new frm_AccDebitNote(FormName.accDebitNote);
                                frm.glbDebitNoteID = detail.DebitNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        #endregion

                        #region BE / JE Cr / Db
                        if (sFormID == "418" || sFormID == "630" || sFormID == "631")
                        {
                            tbl_accJournalEntry detail = tbl_accJournalEntry.Select(sTransactionID);
                            if (detail != null)
                            {
                                if (detail.JournalEntryType_ID == "CON/017")
                                {
                                    frm_accJournalVoucher frm = new frm_accJournalVoucher(FormName.accJournalEntry_Bank);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                                else if (detail.JournalEntryType_ID == "CON/630")
                                {
                                    UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Creditor);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                                else if (detail.JournalEntryType_ID == "CON/631")
                                {
                                    UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Debtor);
                                    frm.glbJournalEntryID = detail.JournalEntry_ID;
                                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
                                }
                            }
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion       

        #region Check event
        private void chkCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCheck.Checked)
            {
                for (int x = 0; x < dgvCheckPending.Rows.Count; x++)
                    dgvCheckPending["isCheck", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvCheckPending.Rows.Count; x++)
                    dgvCheckPending["isCheck", x].Value = true;
            }
        }
        private void chkApprove_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkApprove.Checked)
            {
                for (int x = 0; x < dgvApprovalPending.Rows.Count; x++)
                    dgvApprovalPending["isApprove", x].Value = false;
            }
            else
            {
                for (int x = 0; x < dgvApprovalPending.Rows.Count; x++)
                    dgvApprovalPending["isApprove", x].Value = true;
            }
        }
        #endregion

        #region combo box events
        private void cmbComBranchCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridCheckPending(clsSecurity.UserIDLoged);
        }

        private void cmbComBranchApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridApprovalPending(clsSecurity.UserIDLoged);
        }

        private void cmbModuleCheck_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridCheckPending(clsSecurity.UserIDLoged);
        }

        private void cmbModuleApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGridApprovalPending(clsSecurity.UserIDLoged);
        }
        #endregion

        #region Fill combo
        private void Refresh_BranchCmbCheck()
        {
            cmbComBranchCheck.Items.Clear();
            cmbComBranchCheck.DisplayMember = "Value";
            cmbComBranchCheck.ValueMember = "Text";

            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                    cmbComBranchCheck.Items.Add(new ComboBoxItem(oDetail.CompanyBranch_ID, oDetail.BranchName.ToUpper()));
            }
            if (cmbComBranchCheck.Items.Count > 0)
                cmbComBranchCheck.SelectedIndex = cmbComBranchCheck.FindStringExact(clsSecurity.BranchName);
        }

        private void Refresh_BranchCmbApprove()
        {
            cmbComBranchApprove.Items.Clear();
            cmbComBranchApprove.DisplayMember = "Value";
            cmbComBranchApprove.ValueMember = "Text";

            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                    cmbComBranchApprove.Items.Add(new ComboBoxItem(oDetail.CompanyBranch_ID, oDetail.BranchName.ToUpper()));
            }
            if (cmbComBranchApprove.Items.Count > 0)
                cmbComBranchApprove.SelectedIndex = cmbComBranchApprove.FindStringExact(clsSecurity.BranchName);
        }

        private void Refresh_ModuleCmbCheck()
        {
            cmbModuleCheck.Items.Clear();
            cmbModuleCheck.DisplayMember = "Value";
            cmbModuleCheck.ValueMember = "Text";

            foreach (tbl_securityFormCategory oDetail in tbl_securityFormCategory.SelectAll().Where(r => r.IsEnable && r.IsVisible))
            {
                if (oDetail.FormCategory_ID != "default")
                    cmbModuleCheck.Items.Add(new ComboBoxItem(oDetail.FormCategory_ID, oDetail.CategoryName.ToUpper()));
            }
            foreach (tbl_cfgModule oDetail in tbl_cfgModule.SelectAll().Where(r => r.IsEnable))
            {
                //PROD/016 - Still Prod Apparel Only
                //To Do for Other R2 Modules
                if (oDetail.Module_ID == "PROD/016")
                    cmbModuleCheck.Items.Add(new ComboBoxItem(oDetail.Module_ID, oDetail.ModuleName.ToUpper()));
            }

            if (cmbModuleCheck.Items.Count > 0)
                cmbModuleCheck.SelectedIndex = cmbModuleCheck.FindStringExact("Sales Account System [SAS]");
        }

        private void Refresh_ModuleCmbApprove()
        {
            cmbModuleApprove.Items.Clear();
            cmbModuleApprove.DisplayMember = "Value";
            cmbModuleApprove.ValueMember = "Text";

            foreach (tbl_securityFormCategory oDetail in tbl_securityFormCategory.SelectAll().Where(r => r.IsEnable && r.IsVisible))
            {
                if (oDetail.FormCategory_ID != "default")
                    cmbModuleApprove.Items.Add(new ComboBoxItem(oDetail.FormCategory_ID, oDetail.CategoryName.ToUpper()));
            }
            foreach (tbl_cfgModule oDetail in tbl_cfgModule.SelectAll().Where(r => r.IsEnable))
            {
                //PROD/016 - Still Prod Apparel Only
                //To Do for Other R2 Modules
                if (oDetail.Module_ID == "PROD/016")
                    cmbModuleApprove.Items.Add(new ComboBoxItem(oDetail.Module_ID, oDetail.ModuleName.ToUpper()));
            }

            if (cmbModuleApprove.Items.Count > 0)
                cmbModuleApprove.SelectedIndex = cmbModuleApprove.FindStringExact("Sales Account System [SAS]");
        }
        #endregion

        private void tbControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh_ModuleCmbCheck();
            Refresh_BranchCmbCheck();

            Refresh_ModuleCmbApprove();
            Refresh_BranchCmbApprove();
        }


    }
}
