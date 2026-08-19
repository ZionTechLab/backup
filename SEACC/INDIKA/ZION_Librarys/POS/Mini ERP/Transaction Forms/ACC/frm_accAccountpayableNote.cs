using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Digiteq_Logic;
using Digiteq.DataSets;
using Digiteq.DataSets.ACC;

namespace Digiteq
{
    public partial class frm_accAccountpayableNote : SEACC_Form
    {
        #region Variables
        public string glbAPNID = "";
        public bool bHasCostingConfrimed;
        public bool bHasConfirmed;
        public bool isAutoFill = false;

        public decimal dExRate = 0;

        dts_Apn glb_dts_Apn = new dts_Apn();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        DataTable dt_GLP;
        DataTable dt_GRN;

        string sFormConfigCodeAPN;
        #endregion

        #region Form Load
        public frm_accAccountpayableNote(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
            sFormConfigCodeAPN = clsAutocode.getFormConfigCode(FormName.accAccountpayableNote);
        }
        private void frm_accAccountpayableNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);

            dt_GLP = new DataTable();
            dt_GLP.Columns.Add("Line_No", typeof(int));
            dt_GLP.Columns.Add("CategoryDesc", typeof(string));
            dt_GLP.Columns.Add("GLCode", typeof(string));
            dt_GLP.Columns.Add("GLName", typeof(string));
            dt_GLP.Columns.Add("GLDebit", typeof(decimal));
            dt_GLP.Columns.Add("GLCredit", typeof(decimal));
            dt_GLP.Columns.Add("SubAcct1", typeof(string));
            dt_GLP.Columns.Add("SubAcct2", typeof(string));
            dt_GLP.Columns.Add("Employee", typeof(string));
            dt_GLP.Columns.Add("OtherCr", typeof(string));
            dt_GLP.Columns.Add("CategoryID", typeof(int));
            dt_GLP.Columns.Add("SubAcct1_ID", typeof(string));
            dt_GLP.Columns.Add("SubAcct2_ID", typeof(string));
            dt_GLP.Columns.Add("Employee_ID", typeof(string));
            dt_GLP.Columns.Add("remarks", typeof(string));
            dt_GLP.Columns.Add("APNID", typeof(string));

            dgvDetail.AutoGenerateColumns = false;
            dgvDetail.DataSource = dt_GLP.DefaultView;

            dt_GRN = new DataTable();
            dt_GRN.Columns.Add("GRNID", typeof(string));
            dt_GRN.Columns.Add("ItemCode", typeof(string));
            dt_GRN.Columns.Add("ItemName", typeof(string));
            dt_GRN.Columns.Add("UnsettledAmount", typeof(decimal));
            dt_GRN.Columns.Add("AllocatedAmount", typeof(decimal));
            dt_GRN.Columns.Add("GLAccCode", typeof(string));

            dgvGRN.AutoGenerateColumns = false;
            dgvGRN.DataSource = dt_GRN.DefaultView;

            ClearFields();
            CusDataGridViewFormat();

            if (glbAPNID.Length > 0)
                FillDetails(glbAPNID);
        }
        #endregion

        #region Btn New
        private void frm_accAccountpayableNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_accAccountpayableNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAPNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                    {
                        if (ValidateForDependancies())
                        {
                            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                            {
                                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                if (detail != null && !detail.IsDeleted)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "  Account Payable Note : " + txtAPNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            detail.IsDeleted = true;
                                            detail.DateDeleted = clsSecurity.getServerDateTime();
                                            detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                            detail.Update();

                                            clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                            clsHelpMethods.RemovePVSattlementsFrom_APNID(detail.AccountPayableNote_ID);

                                            #region unsettle PO
                                            tbl_scsPurchaseOrder oPo = tbl_scsPurchaseOrder.Select(detail.PurchaseOrder_ID);
                                            if (oPo != null && oPo.PurchaseOrder_ID != "default")
                                            {
                                                oPo.SeattleAmount = oPo.SeattleAmount - detail.GrandTotal;
                                                oPo.IsSeattled = false;
                                                oPo.Update();
                                            }
                                            #endregion

                                            #region unsettle GRN
                                            //tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                                            //if (oGRN != null && oGRN.ExternalGoodReceivedNote_ID != "default")
                                            //{
                                            //    oGRN.SeattleAmount = oGRN.SeattleAmount - detail.GrandTotal;
                                            //    oGRN.IsSeattled = false;
                                            //    oGRN.Update();
                                            //}

                                            foreach (tbl_accAccountPayableNote_Allocation oldoAPNAllo in tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == txtAPNID.Text.Trim()))
                                            {
                                                tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oldoAPNAllo.ExternalGoodReceivedNote_ID);
                                                if (oGRN != null)
                                                {
                                                    oGRN.SeattleAmount -= oldoAPNAllo.AllocatedAmount;
                                                    if (oGRN.SeattleAmount == oGRN.SubTotal)
                                                        oGRN.IsSeattled = true;
                                                    else
                                                        oGRN.IsSeattled = false;

                                                    oGRN.Update();
                                                }
                                            }
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                            clsAlerts_Email.createEmail_APN(detail.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteDeleted);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Save
        private void frm_accAccountpayableNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ValidateEmptyForeignKey();

                if (ValidateSave())
                {
                    decimal dSettleAmount = 0;

                    #region update records
                    if (IsUpdate)
                    {
                        tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text))
                                {
                                    tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                    tbl_accAccountPayableNote_SubTotal.DeleteAllByAccountPayableNote_ID(txtAPNID.Text);

                                    dSettleAmount = 0;

                                    #region  Insert Detail - APN Details - OLD

                                    //foreach (DataGridViewRow row in dgvDetail.Rows)
                                    //{
                                    //    int iRow;
                                    //    string sGLCode = "", sCategoryID = "", sRemarks = "", sSubAcct1_ID = "", sSubAcct2_ID = "";
                                    //    bool bIsCredit = false;
                                    //    decimal dAmount;

                                    //    iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                    //    sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                    //    //sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                    //    //sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                    //    sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                    //    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                    //    sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct1_ID", row.Index, "default");
                                    //    sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct2_ID", row.Index, "default");
                                    //    //sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                                    //    //sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");

                                    //    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));

                                    //    if (dAmount > 0)
                                    //        bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                    //    else
                                    //        dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                    //    #region Insert tbl_accAccountPayableNote_SubTotal
                                    //    tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(), sCategoryID,
                                    //        sGLCode, "default", txtSupplierID.Tag.ToString(), "default", "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                    //    Insdetail.Insert();
                                    //    #endregion

                                    //}

                                    #endregion

                                    #region  Insert Detail - APN Details

                                    int iRow;
                                    string sGLCode = "",
                                        sCategoryID = "",
                                        sRemarks = "",
                                        sSubAcct1_ID = "",
                                        sSubAcct2_ID = "";
                                    bool bIsCredit = false;
                                    decimal dAmount;

                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                    {
                                        iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index,
                                            int.Parse("0"));
                                        sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                        sCategoryID =
                                            clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                        sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct1_ID",
                                            row.Index, "default");
                                        sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct2_ID",
                                            row.Index, "default");
                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index,
                                            decimal.Parse("0.00"));

                                        if (dAmount > 0)
                                            bIsCredit = true;
                                        else
                                        {
                                            bIsCredit = false;
                                            dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index,
                                                decimal.Parse("0.00"));
                                        }

                                        #region Insert tbl_accAccountPayableNote_SubTotal

                                        tbl_accAccountPayableNote_SubTotal Insdetail =
                                            new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(),
                                                sCategoryID,
                                                sGLCode, "default", txtSupplierID.Tag.ToString(), "default", "default",
                                                sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                        Insdetail.Insert();

                                        #endregion
                                    }

                                    #endregion

                                    #region Update APN Allocation

                                    List<tbl_accAccountPayableNote_Allocation> oAPNAllo =
                                        tbl_accAccountPayableNote_Allocation.SelectAll()
                                            .Where(p => p.AccountPayableNote_ID == txtAPNID.Text).ToList();
                                    if (oAPNAllo.Count > 0)
                                    {
                                        decimal dOldAllocatedAmnt = 0;
                                        foreach (tbl_accAccountPayableNote_Allocation oldoAPNAllo in oAPNAllo)
                                        {
                                            tbl_scsExternalGoodReceivedNote oGRN =
                                                tbl_scsExternalGoodReceivedNote.Select(oldoAPNAllo
                                                    .ExternalGoodReceivedNote_ID);
                                            if (oGRN != null)
                                            {
                                                oGRN.SeattleAmount -= oldoAPNAllo.AllocatedAmount;
                                                if (oGRN.SeattleAmount == oGRN.SubTotal)
                                                    oGRN.IsSeattled = true;
                                                else
                                                    oGRN.IsSeattled = false;

                                                oGRN.Update();
                                            }

                                            //dOldAllocatedAmnt = oldoAPNAllo.AllocatedAmount;                                        
                                            oldoAPNAllo.Delete();
                                        }

                                        string sGRNCode = "", sItemCode = "";
                                        decimal dAllocatedAmnt;
                                        decimal dGRNSettleAmount = 0;


                                        foreach (DataGridViewRow row in dgvGRN.Rows)
                                        {
                                            sGRNCode = clsValidate.ValidateGridValue(dgvGRN, "GRNID", row.Index, "");
                                            sItemCode = clsValidate.ValidateGridValue(dgvGRN, "ItemCode", row.Index,
                                                "");
                                            dAllocatedAmnt = clsValidate.ValidateGridValue(dgvGRN, "AllocatedAmount",
                                                row.Index, decimal.Parse("0.00"));

                                            //tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(sGRNCode);
                                            //if (dAllocatedAmnt <= oGRN.GrandTotal - oGRN.SeattleAmount + dOldAllocatedAmnt)
                                            //{
                                            tbl_accAccountPayableNote_Allocation APNAllo =
                                                new tbl_accAccountPayableNote_Allocation(txtAPNID.Text.Trim(), sGRNCode,
                                                    sItemCode, dAllocatedAmnt);
                                            APNAllo.Insert();
                                            //}
                                            //dGRNSettleAmount += dAllocatedAmnt;

                                            tbl_scsExternalGoodReceivedNote oGRN =
                                                tbl_scsExternalGoodReceivedNote.Select(sGRNCode);
                                            oGRN.SeattleAmount += dAllocatedAmnt;
                                            if (oGRN.SeattleAmount == oGRN.SubTotal)
                                                oGRN.IsSeattled = true;
                                            oGRN.Update();

                                        }
                                    }

                                    #endregion

                                    #region  Insert Header - tbl_accAccountPayableNote

                                    tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(
                                        txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(),
                                        txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(),
                                        txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(),
                                        txtGRN.Tag.ToString().Trim(),
                                        "default", "default", txtSupplierID.Tag.ToString().Trim(), "default", "default",
                                        txtNoteType.Tag.ToString(), txtCostCenter1.Tag.ToString().Trim(),
                                        txtCostCenter2.Tag.ToString().Trim(), oldRecord.GlPosting_ID,
                                        clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                        clsSecurity.FinancialYearID,
                                        txtCurCode.Tag.ToString().Trim(),
                                        decimal.Parse(txtCurrencyRate.Text.ToString().Trim()),
                                        decimal.Parse(txtCreditDays.Text.Trim()),
                                        decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                        decimal.Parse(txtPercentageNBT.Text.Trim()),
                                        decimal.Parse(txtPercentageVat.Text.Trim()),
                                        decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                        decimal.Parse(txtSubTotal.Text.Trim()) * dExRate,
                                        decimal.Parse(txtDiscount.Text.Trim()) * dExRate,
                                        decimal.Parse(txtNBT.Text.Trim()) * dExRate,
                                        decimal.Parse(txtVat.Text.Trim()) * dExRate,
                                        decimal.Parse(txtOtherTax.Text.Trim()) * dExRate,
                                        decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, oldRecord.CreateUser_ID,
                                        clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                        oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID,
                                        clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID,
                                        oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                                        clsSecurity.getServerDateTime(), oldRecord.DateChecked,
                                        oldRecord.DateApproved, oldRecord.DateDeleted, oldRecord.DatePrinted,
                                        oldRecord.IsAdvancePayment, oldRecord.IsPartPayment, oldRecord.IsChecked,
                                        oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                        oldRecord.IsLocked, oldRecord.IsPettyCashReimbursment, oldRecord.IsSAPN, 0,
                                        oldRecord.IsSeattled, oldRecord.ChequeRegister_ID, oldRecord.IsReturnCheque,
                                        oldRecord.PrintCount, clsSecurity.CompanyID, clsSecurity.BranchID);
                                    AccAPN.Update();

                                    //    Update supplier outstanding amount
                                    //   clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), oldRecord.GrandTotal, 0, false);
                                    //    clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, true);

                                    #endregion

                                    //update GRN-issettle
                                    //if (txtGRN.Text.Trim() != "" && txtGRN.Text.Trim() != "default")
                                    //    clsProcessMethods.SetSettle_GRN_From_APN(txtGRN.Tag.ToString().Trim(), clsHelpMethods.getDisplayPrice(dSettleAmount - oldRecord.GrandTotal, dExRate));

                                    clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                                    //Sent Maill
                                    clsAlerts_Email.createEmail_APN(AccAPN.AccountPayableNote_ID,
                                        enum_Alerts.AccountPayableNoteModified);
                                }
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion

                    #region insert records
                    else
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCodeAPN))
                            txtAPNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCodeAPN);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text)) //if (txtAPNID.Text.Trim().Length > 0)
                        {
                            tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(), txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(), txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(), txtGRN.Tag.ToString().Trim(), "default",
                                "default", txtSupplierID.Tag.ToString().Trim(), "default", "default", txtNoteType.Tag.ToString(), txtCostCenter1.Tag.ToString().Trim(), txtCostCenter2.Tag.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurCode.Tag.ToString().Trim(),
                                decimal.Parse(txtCurrencyRate.Text.ToString().Trim()), decimal.Parse(txtCreditDays.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Text.Trim()) * dExRate,
                                decimal.Parse(txtDiscount.Text.Trim()) * dExRate, decimal.Parse(txtNBT.Text.Trim()) * dExRate, decimal.Parse(txtVat.Text.Trim()) * dExRate, decimal.Parse(txtOtherTax.Text.Trim()) * dExRate, decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, bHasChecked, bHasApproved, false, false, false, false, true, 0, false, "default", false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            AccAPN.Insert();

                            //  Insert supplier outstanding amount
                            //       clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, true);

                            #region  Insert Detail - APN Details
                            int iRow;
                            string sGLCode = "", sCategoryID = "", sRemarks = "", sSubAcct1_ID = "", sSubAcct2_ID = "";
                            bool bIsCredit = false;
                            decimal dAmount;
                            //   dSettleAmount = 0;

                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                iRow = clsValidate.ValidateGridValue(dgvDetail, "Line_No", row.Index, int.Parse("0"));
                                sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                //sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                //sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                sSubAcct1_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct1_ID", row.Index, "default");
                                sSubAcct2_ID = clsValidate.ValidateGridValue(dgvDetail, "SubAcct2_ID", row.Index, "default");
                                //   sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
                                //   sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");

                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));

                                //if (dAmount > 0)
                                //    bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                //else
                                //    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                if (dAmount > 0)
                                    bIsCredit = true;
                                else
                                {
                                    bIsCredit = false;
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                }

                                #region Insert tbl_accAccountPayableNote_SubTotal
                                tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(), sCategoryID,
                                    sGLCode, "default", txtSupplierID.Tag.ToString(), "default", "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            #region  Insert APN Allocation
                            string sGRNCode = "", sItemCode = "";
                            decimal dAllocatedAmnt = 0;
                            decimal dGRNSettleAmount = 0;


                            foreach (DataGridViewRow row in dgvGRN.Rows)
                            {
                                sGRNCode = clsValidate.ValidateGridValue(dgvGRN, "GRNID", row.Index, "");
                                sItemCode = clsValidate.ValidateGridValue(dgvGRN, "ItemCode", row.Index, "");
                                dAllocatedAmnt = clsValidate.ValidateGridValue(dgvGRN, "AllocatedAmount", row.Index, decimal.Parse("0.00"));

                                tbl_accAccountPayableNote_Allocation APNAllo = new tbl_accAccountPayableNote_Allocation(txtAPNID.Text.Trim(), sGRNCode, sItemCode, dAllocatedAmnt);
                                APNAllo.Insert();

                                tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(sGRNCode);
                                oGRN.SeattleAmount += dAllocatedAmnt;
                                if (oGRN.SeattleAmount == oGRN.SubTotal)
                                    oGRN.IsSeattled = true;
                                oGRN.Update();

                                //dGRNSettleAmount += dAllocatedAmnt;     

                            }

                            #endregion

                            Attachments.Insert(txtAPNID.Text.ToString());

                            //if (txtGRN.Text.Trim() != "" && txtGRN.Text.Trim() != "default")
                            //    clsProcessMethods.SetSettle_GRN_From_APN(txtGRN.Tag.ToString().Trim(), clsHelpMethods.getDisplayPrice(dSettleAmount, dExRate));

                            clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Sent Maill
                            clsAlerts_Email.createEmail_APN(AccAPN.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteCreated);
                        }
                        //else
                        //    MessageBox.Show("APN No " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                if (oldRecord != null)
                    FillDetails(txtAPNID.Text.Trim());
            }
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_accAccountpayableNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accAccountpayableNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accAccountpayableNote_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Print/Draft
        private void frm_accAccountpayableNote_SF_printButton_Click(object sender, EventArgs e)
        {
            tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Transaction Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_accAccountpayableNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Temp
        private void frm_accAccountpayableNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblJobDate, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);

                txtAPNID.Tag = null;
                dtpAPNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtAPNID.Text = "<Auto Generate>";
                else
                    txtAPNID.Clear();
                if (txtAPNID.Enabled)
                {
                    txtAPNID.SelectAll();
                    txtAPNID.Focus();
                }
                // uC_Supplier.UnlockFields();
                Attachments.Clear();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpAPNDate, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblJobDate, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);

            clsCommon.SetEnableDisable_NormalTextbox(txtOtherTax, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtNBT, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtVat, false);

            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageOtherTax, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageNBT, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageVat, false);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGRN, true);

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtSubTotal.Enabled = true;
            txtGrandTotal.Enabled = false;

            txtAPNID.Tag = null;
            txtAPNType.Tag = null;
            txtBillNo.Tag = null;
            txtNoteType.Tag = null;
            txtSubTotal.Tag = null;
            txtAWB.Tag = null;
            txtGRN.Tag = null;
            txtLCNo.Tag = null;
            txtDeliveryOrderID.Tag = null;
            txtNarration.Tag = null;
            txtCreditAmount.Tag = null;
            txtDebitAmount.Tag = null;
            txtBalanceAmount.Tag = null;
            txtCreditDays.Tag = null;
            txtCreditDays.Enabled = true;
            txtGLAccSubTotal.Clear();
            txtSupplierID.Tag = null;
            txtSupplierID.Clear();

            txtCostCenter1.Tag = null;
            txtCostCenter1.Clear();

            txtCostCenter2.Tag = null;
            txtCostCenter2.Clear();

            txtAPNType.Clear();

            txtNarration.Clear();
            txtBillNo.Clear();
            txtNoteType.Clear();
            txtSubTotal.Clear();
            txtSubTotal.Text = "";
            txtAWB.Clear();
            txtGRN.Clear();
            txtLCNo.Clear();
            txtDeliveryOrderID.Clear();
            txtNarration.Clear();
            txtCreditAmount.Clear();
            txtDebitAmount.Clear();
            txtBalanceAmount.Clear();
            txtCreditDays.Clear();


            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            txtSubTotal.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtVat.Text = "0.00";
            txtGrandTotal.Text = "0.00";

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            chkShowSettle.Checked = false;

            bHasCostingConfrimed = false;
            bHasChecked = false;
            bHasApproved = false;
            bHasConfirmed = false;
            userDetailsColorChanges();

            dt_GRN.Rows.Clear();
            dt_GLP.Rows.Clear();

            chkSettings2.Checked = true;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            rdoOtherCr.Enabled = true;
            rdoSupplier.Enabled = true;
            rdoSupplier.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCodeAPN))
                txtAPNID.Text = "<Auto Generate>";
            else
                txtAPNID.Clear();
            if (txtAPNID.Enabled)
            {
                txtAPNID.SelectAll();
                txtAPNID.Focus();
            }

            rdoSupplier.Checked = true;

            txtAPNType.Text = clsGenaralName.getName_APNType(clsConfig.sDefaultAPNTypeID);
            txtAPNType.Tag = clsConfig.sDefaultAPNTypeID;

            dtpAPNDate.Value = clsSecurity.getServerDateTime();
            dtpBillDate.Value = clsSecurity.getServerDateTime();

            Attachments.Clear();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            this.btnDraft.Enabled = false;
                        }
                        else
                            this.btnDraft.Enabled = true;

                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, false);

                        FillDetailsCurrency(detail.Currency_ID);

                        txtAPNID.Tag = detail.AccountPayableNote_ID;

                        txtCostCenter1.Tag = detail.CostCenter1_ID;
                        txtCostCenter2.Tag = detail.CostCenter2_ID;
                        txtAPNType.Tag = detail.ApnType_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;

                        txtAPNID.Text = detail.AccountPayableNote_ID;
                        dtpAPNDate.Value = detail.AccountPayableNoteDate;
                        txtBillNo.Text = detail.BillNo;
                        dtpBillDate.Value = detail.BillDate;
                        txtNarration.Text = detail.Narration;

                        txtAWB.Text = detail.NoAWB;
                        txtGRN.Text = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtGRN.Tag = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtLCNo.Text = detail.NoLC;
                        txtDeliveryOrderID.Text = detail.NoDeliveryOrder;
                        txtCreditDays.Text = detail.CreditDays.ToString();
                        txtAPNType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_APNType(detail.ApnType_ID));

                        txtNoteType.Tag = detail.StockNoteType_ID;
                        txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));



                        if (txtGRN.Text.Trim().Length > 0)
                        {
                            tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                            if (oGRN != null)
                            {
                                string sPONo = oGRN.PurchaseOrder_ID;
                                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID))
                                {
                                    if (sPONo != oGRNDetail.PurchaseOrder_ID)
                                    {
                                        sPONo = "Multiple POs";
                                        break;
                                    }
                                }
                            }
                        }

                        #region Fill GRN Grid
                        dt_GRN.Rows.Clear();
                        decimal dAllocatedAmnt = 0;
                        foreach (tbl_accAccountPayableNote_Allocation oAPN_Allo in tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == detail.AccountPayableNote_ID))
                        {
                            //tbl_scsExternalGoodReceivedNote_Detail oGRNDetail = tbl_scsExternalGoodReceivedNote_Detail.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID == oAPN_Allo.ExternalGoodReceivedNote_ID && p.Item_ID == oAPN_Allo.Item_ID).FirstOrDefault();
                            //if (oGRNDetail != null)
                            //{
                            //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oGRNDetail.Item_ID);
                            //    if (oItem != null)
                            //    {
                            //        foreach (tbl_accAccountPayableNote_Allocation Allo in tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.ExternalGoodReceivedNote_ID == oAPN_Allo.ExternalGoodReceivedNote_ID && p.Item_ID == oGRNDetail.Item_ID))
                            //        {
                            //            dAllocatedAmnt += Allo.AllocatedAmount;
                            //        }
                            //        DataRow newRow = dt_GRN.NewRow();

                            //        newRow["GRNID"] = oAPN_Allo.ExternalGoodReceivedNote_ID;
                            //        newRow["ItemCode"] = oAPN_Allo.Item_ID;
                            //        newRow["ItemName"] = oItem.ItemName;
                            //        newRow["UnsettledAmount"] = oGRNDetail.TatalAmount - dAllocatedAmnt;
                            //        newRow["AllocatedAmount"] = oAPN_Allo.AllocatedAmount;
                            //        newRow["GLAccCode"] = oItem.ControlAcc;

                            //        dt_GRN.Rows.Add(newRow);

                            //        dAllocatedAmnt = 0;
                            //    }
                            //}

                            bool bGrnDuplicationValidity = true;
                            foreach (DataRow row in dt_GRN.Rows)
                            {
                                string sGrnNo = clsValidate.ValidateRowValue(row, "GRNID", "");
                                if (oAPN_Allo.ExternalGoodReceivedNote_ID == sGrnNo)
                                {
                                    bGrnDuplicationValidity = false;
                                    break;
                                }
                            }
                            if (bGrnDuplicationValidity)
                                dt_GRN.Merge(DBHandling.ExecQuery("exec [Get_AllocatedGRN] '" + oAPN_Allo.ExternalGoodReceivedNote_ID + "', '" + detail.AccountPayableNote_ID + "' ").Tables[0]);
                        }

                        CalculateGrnTotal();
                        #endregion


                        txtCostCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                        txtCostCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));
                        

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        userDetailsColorChanges();

                        foreach (tbl_accAccountPayableNote_SubTotal oGL in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID))
                        {
                            if (oGL.Tc_ID == "1")
                                txtGLAccSubTotal.Text = oGL.Gl_ID;
                        }

                        tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(detail.Supplier_ID);
                        if (oSupplier != null)
                        {
                            txtSupplierID.Tag = detail.Supplier_ID;
                            if (oSupplier.IsOtherCreditor)
                                rdoOtherCr.Checked = true;

                            txtSupplierID.Tag = detail.Supplier_ID;
                            txtSupplierID.Text = clsCommon.GetForeignKeyValue(oSupplier.SupplierName);
                        }
                        rdoOtherCr.Enabled = false;
                        rdoSupplier.Enabled = false;

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;


                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, dExRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, dExRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, dExRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, dExRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, dExRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, dExRate));

                        CalculateSubTotal();
                        CalculateTaxesAndGrandTotal();
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, dExRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, dExRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, dExRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, dExRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, dExRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, dExRate));

                        Attachments.FillAttachments(sID);

                        //Fill Sub Account Details to the Grid View.
                        //This is a temporary solution for this filling
                        //As a permentent solutin, please recheck the filling method and try to fill the whole grid using DB table.
                        //2018-09-25 Commented by Gayan
                        foreach (tbl_accAccountPayableNote_SubTotal accAPN_ST in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID))
                        {
                            foreach (var dr in dt_GLP.Select("CategoryID = '" + accAPN_ST.Tc_ID + "' AND GLCode = '" + accAPN_ST.Gl_ID + "'"))
                            {
                                dr["SubAcct1_ID"] = accAPN_ST.CostCenter1_ID;
                                dr["SubAcct2_ID"] = accAPN_ST.CostCenter2_ID;
                                dr["SubAcct1"] = clsGenaralName.getName_AccCostCenter1(accAPN_ST.CostCenter1_ID);
                                dr["SubAcct2"] = clsGenaralName.getName_AccCostCenter2(accAPN_ST.CostCenter2_ID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void CalculateGrnTotal()
        {
            decimal dUnsettledAmount = 0, dAllocatedAmount = 0;

            foreach (DataRow row in dt_GRN.Rows)
            {
                dUnsettledAmount += clsValidate.ValidateRowValue(row, "UnsettledAmount", decimal.Parse("0.00"));
                dAllocatedAmount += clsValidate.ValidateRowValue(row, "AllocatedAmount", decimal.Parse("0.00"));
            }

            txtTotalUnsettled.Text = clsFormatter.FormatToCurrecyWithThousendSep(dUnsettledAmount);
            txtTotalAllocated.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);
            txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);

            if (dgvGRN.Rows.Count == 0)
                txtSubTotal.Enabled = true;
            else
                txtSubTotal.Enabled = false;
        }
        private bool CheckValidity_AccountLink_ITEM(string ExternalGoodReceivedNote_ID)
        {
            bool status = true;
            try
            {
                foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(ExternalGoodReceivedNote_ID))
                {
                    if (!clsMethods_GL.CheckAccountLink_Item(oGRNDetail.Item_ID))
                    {
                        status = false;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return status;
        }
        private bool fillSupplierCode(string Supplier_ID)
        {
            bool Status = false;
            try
            {
                if (clsMethods_GL.CheckAccountLink_Supplier(Supplier_ID))
                {
                    tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(Supplier_ID);
                    if (osup != null)
                    {
                        rdoOtherCr.Enabled = false;
                        rdoSupplier.Enabled = false;
                        rdoSupplier.Checked = true;

                        txtSupplierID.Text = osup.SupplierName;
                        txtSupplierID.Tag = osup.Supplier_ID;
                        txtCreditDays.Text = osup.CreditPeriod.ToString();

                        chkOtherTax.Checked = osup.IsSVATenable ? true : false;
                        chkVat.Checked = osup.IsVATenable ? true : false;
                        chkNBT.Checked = osup.IsNBTenable ? true : false;

                        Status = true;
                    }
                }
                else
                {
                    txtSupplierID.Tag = null;
                    txtSupplierID.Clear();
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return Status;
        }

        #region Fill Tax Detail By GRN
        private void FillDetailByGRN(string sGRNID)
        {
            try
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sGRNID);
                if (detail != null && clsMethods_GL.CheckAccountLink_Supplier(detail.Supplier_ID))
                {
                    if (CheckValidity_AccountLink_ITEM(detail.ExternalGoodReceivedNote_ID))
                    {
                        if (fillSupplierCode(detail.Supplier_ID))
                        {
                            bool bGrnDuplicationValidity = true;
                            foreach (DataRow row in dt_GRN.Rows)
                            {
                                string sGrnNo = clsValidate.ValidateRowValue(row, "GRNID", "");
                                if (detail.ExternalGoodReceivedNote_ID == sGrnNo)
                                {
                                    bGrnDuplicationValidity = false;
                                    MessageBox.Show("GRN # - " + detail.ExternalGoodReceivedNote_ID + " Already allocated", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                            if (bGrnDuplicationValidity)
                            {
                                #region Fill GRN Grid
                                //  decimal dAmount = 0;
                                //foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID))
                                //{
                                //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oGRNDetail.Item_ID);
                                //    if (oItem != null)
                                //    {
                                //        DataRow newRow = dt_GRN.NewRow();

                                //        dAmount = DBHandling.ExecQuery_ReturnDecimal("select [dbo].[GetAllocatedAmount]('" + oGRNDetail.Item_ID + "','" + detail.ExternalGoodReceivedNote_ID + "')");

                                //        newRow["GRNID"] = detail.ExternalGoodReceivedNote_ID;
                                //        newRow["ItemCode"] = oGRNDetail.Item_ID;
                                //        newRow["ItemName"] = oItem.ItemName;
                                //        newRow["UnsettledAmount"] = oGRNDetail.TatalAmount - dAmount;
                                //        newRow["AllocatedAmount"] = oGRNDetail.TatalAmount - dAmount;


                                //        newRow["GLAccCode"] = oItem.ControlAcc;

                                //        dt_GRN.Rows.Add(newRow);
                                //        dAmount = 0;
                                //    }
                                //}
                                //  dt_GRN.datas
                                dt_GRN.Merge(DBHandling.ExecQuery("exec [Get_GRN] '" + detail.ExternalGoodReceivedNote_ID + "'").Tables[0]);
                                // source.DataSource = dtAllRecodes;
                                // dgvDetail.DataSource = source;
                                #endregion

                                txtNoteType.Tag = detail.StockNoteType_ID;
                                txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));
                                CalculateGrnTotal();
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid By GRN
        private void Refresh_PostingEntys()
        {
            try
            {
                decimal dTotalDebit = 0, dTotalCredit = 0;
                if (txtSupplierID.Tag != null && txtSupplierID.Text != "")
                {
                    dt_GLP.Clear();
                    string sAccountCode_Supplier = clsMethods_GL.getAccountCode_Supplier(txtSupplierID.Tag.ToString().Trim());

                    decimal dAmount_VAT = clsHelpMethods.getSavePrice(txtVat, txtCurrencyRate);
                    decimal dAmount_NBT = clsHelpMethods.getSavePrice(txtNBT, txtCurrencyRate);
                    decimal dAmount_GrandTotal = clsHelpMethods.getSavePrice(txtGrandTotal, txtCurrencyRate);

                    int iLineNo = 0;

                    if (dAmount_VAT > 0)
                        FilldataTable(iLineNo++, clsConfig.sVATGLCode_Payable, dAmount_VAT, 0, "default", "default", "default", "default", TransactionCategory.VAT, txtSupplierID.Tag.ToString());
                    if (dAmount_NBT > 0)
                        FilldataTable(iLineNo++, clsConfig.sNBTGLCode_Payable, dAmount_NBT, 0, "default", "default", "default", "default", TransactionCategory.NBT, txtSupplierID.Tag.ToString());
                    if (dAmount_GrandTotal > 0 && sAccountCode_Supplier != "default")
                        FilldataTable(iLineNo++, sAccountCode_Supplier, 0, dAmount_GrandTotal, "default", "default", "default", "default", TransactionCategory.GrandTotal, txtSupplierID.Tag.ToString());

                    dTotalCredit = dAmount_VAT + dAmount_NBT;
                    dTotalDebit = dAmount_GrandTotal;
                    #region Sub Total

                    if (dt_GRN.Rows.Count == 0)
                    {
                        //if (txtGLAccSubTotal.Text == "")
                        //{
                        //    DialogResult msgResult = MessageBox.Show("Please select Account for Sub Total..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    if (msgResult == DialogResult.OK)
                        //    {
                        //        List<string> lstParameeters = new List<string>();
                        //        lstParameeters.Add("");
                        //        lstParameeters.Add("");

                        //        frmSearch RowDataSearch = new frmSearch(lstParameeters);
                        //        List<string> lstResult = RowDataSearch.Show(Search.AccName);
                        //        if (RowDataSearch.DialogResult == DialogResult.OK)
                        //        {
                        //            txtGLAccSubTotal.Text = lstResult[0];
                        //        }
                        //    }
                        //}
                        //  if (txtGLAccSubTotal.Text != "")
                        // {
                        decimal sUnsettledAmount = clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text), dExRate);
                        FilldataTable(iLineNo++, txtGLAccSubTotal.Text, sUnsettledAmount, 0, "default", "default", "default", "default", TransactionCategory.SubTotal, txtSupplierID.Tag.ToString());
                        dTotalCredit += sUnsettledAmount;
                        // }

                    }
                    else
                    {
                        var newDt = dt_GRN.AsEnumerable().GroupBy(r => r.Field<string>("GLAccCode"))
                            .Select(g =>
                      {
                          var row = dt_GRN.NewRow();

                          row["GLAccCode"] = g.Key;
                          row["UnsettledAmount"] = g.Sum(r => r.Field<decimal>("UnsettledAmount"));
                          row["AllocatedAmount"] = g.Sum(r => r.Field<decimal>("AllocatedAmount"));
                          return row;
                      }).CopyToDataTable();

                        foreach (DataRow row in newDt.Rows)
                        {
                            string sAccCode = clsValidate.ValidateRowValue(row, "GLAccCode", "");
                            decimal sUnsettledAmount = clsHelpMethods.getSavePrice(clsValidate.ValidateRowValue(row, "AllocatedAmount", (decimal)0), dExRate);
                            FilldataTable(iLineNo++, sAccCode, sUnsettledAmount, 0, "default", "default", "default", "default", TransactionCategory.SubTotal, txtSupplierID.Tag.ToString());
                            dTotalCredit += sUnsettledAmount;
                        }
                    }
                    #endregion


                    txtCreditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalCredit);
                    txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalDebit);
                }
                else
                {
                    foreach (DataRow row in dt_GLP.Rows)
                    {
                        string sCategoryDesc = clsValidate.ValidateRowValue(row, "CategoryDesc", "");
                        if (sCategoryDesc == GetEnumDescription(TransactionCategory.GrandTotal))
                        {
                            row.Delete();
                            break;
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void CalculateSubTotal()
        {
            try
            {
                decimal dTotAmount = 0;

                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dTotAmount, dExRate));
                txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dTotAmount, dExRate));
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        #endregion

        private bool ValidateForDependancies()
        {
            bool bValue = true;

            try
            {
                foreach (tbl_accPaymentVoucher_Detail oDBN_Detail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(txtAPNID.Text.Trim()).Where(p => p.PaymentVoucher_ID == "default"))
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(oDBN_Detail.DebitNote_ID);
                    if (detail != null && detail.DebitNote_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.DebitNote_ID + "] SRN is already created for this APN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }

        #region Check Validity
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValiditySubTotal())
            {
                if (CheckNumberValidity())
                {
                    if (CheckDataTableValidity())
                    {
                        if (CheckValidity_EmptyField())
                        {
                            if (CheckValiditySettleAmmount())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                                {
                                    if (decimal.Parse(txtDebitAmount.Text) == decimal.Parse(txtCreditAmount.Text))
                                        bIsOk = true;
                                    else
                                        MessageBox.Show("Debit / Credit Total not matching....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    CheckValidity_ForignKey();
                                }
                            }
                        }
                    }
                }
            }
            return bIsOk;
        }
        private void CheckValidity_ForignKey()
        {
            if (txtNoteType.Tag == null)
                txtNoteType.Tag = "default";
        }
        private bool CheckValiditySubTotal()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtSubTotal.TextLength == 0)
                {
                    strMessage += "\n" + "Sub Total ";
                    bStatus = false;
                }

                if (bStatus == false)
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n Sub Total";
                    bStatus = false;
                }

                if (decimal.Parse(txtSubTotal.Text.Trim()) <= 0)
                {
                    strMessage += "\n Enter Sub Total";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckDataTableValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (decimal.Parse(txtSubTotal.Text.Trim()) > 0 && GetRecordCount_Posting(TransactionCategory.SubTotal) == 0)
                {
                    strMessage += "\n Please Enter GL Codes for Sub Total";
                    bStatus = false;
                }

                if (decimal.Parse(txtNBT.Text.Trim()) > 0 && GetRecordCount_Posting(TransactionCategory.NBT) == 0)
                {
                    strMessage += "\n Please Enter GL Codes for NBT Amount OR Clear the  NBT Amount";
                    bStatus = false;
                }

                if (decimal.Parse(txtVat.Text.Trim()) > 0 && GetRecordCount_Posting(TransactionCategory.VAT) == 0)
                {
                    strMessage += "\n Please Enter GL Codes for VAT Amount OR Clear the  VAT Amount";
                    bStatus = false;
                }

                if (decimal.Parse(txtOtherTax.Text.Trim()) > 0 && GetRecordCount_Posting(TransactionCategory.SVAT) == 0)
                {
                    strMessage += "\n Please Enter GL Codes for SVAT Amount OR Clear the SVAT Amount";
                    bStatus = false;
                }
                if (decimal.Parse(txtGrandTotal.Text.Trim()) > 0 && GetRecordCount_Posting(TransactionCategory.GrandTotal) == 0)
                {
                    strMessage += "\n Please Enter GL Codes for Grand Total";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtAPNType, "APN Type"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtBillNo, "Bill No"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtCreditDays, "Credit days"))
                    {
                        bStatus = true;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            if (clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "") == "")
                            {
                                string sCategoryDesc = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", row.Index, "");
                                MessageBox.Show("Link Account code for <" + sCategoryDesc + ">", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                bStatus = false;
                                break;
                            }
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool CheckValiditySettleAmmount()
        {
            bool bSettoffOk = true;
            try
            {
                foreach (DataRow row in dt_GRN.Rows)
                {
                    string sGRNCode = clsValidate.ValidateRowValue(row, "GRNID", "");
                    string sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "");
                    decimal dAllocatedAmount = clsValidate.ValidateRowValue(row, "AllocatedAmount", decimal.Parse("0.00"));

                    tbl_scsExternalGoodReceivedNote details = tbl_scsExternalGoodReceivedNote.Select(sGRNCode);
                    if (details != null && details.ExternalGoodReceivedNote_ID != "default")
                    {
                        decimal dOldAllocationAmount = 0;
                        if (IsUpdate)
                        {
                            tbl_accAccountPayableNote_Allocation oAllocation = tbl_accAccountPayableNote_Allocation.Select(txtAPNID.Text.ToString(), sGRNCode, sItemCode);
                            if (oAllocation != null)
                            {
                                dOldAllocationAmount = oAllocation.AllocatedAmount;
                            }
                        }
                        if ((details.GrandTotal - details.SeattleAmount) + dOldAllocationAmount < dAllocatedAmount)
                        {
                            MessageBox.Show("Allocated Amount cannot be greater than unsettled GRN Amount....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            bSettoffOk = false;
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalied GRN <<" + sGRNCode + ">>", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        bSettoffOk = false;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bSettoffOk;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtAPNID);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                // clsCommon.ValidateForeignKey(ref txtOtherCr);
                clsCommon.ValidateForeignKey(ref txtCostCenter1);
                clsCommon.ValidateForeignKey(ref txtCostCenter2);
                clsCommon.ValidateForeignKey(ref txtGRN);
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                //   clsCommon.ValidateForeignKey(ref txtPONo);

                if (txtPercentageDiscount.Text.Trim().Length == 0)
                    txtPercentageDiscount.Text = "0";
                else if (!clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                    txtPercentageDiscount.Text = "0";

                if (txtPercentageNBT.Text.Trim().Length == 0)
                    txtPercentageNBT.Text = "0";
                else if (!clsCommon.isCurrency(txtPercentageNBT.Text.Trim()))
                    txtPercentageNBT.Text = "0";

                if (txtPercentageVat.Text.Trim().Length == 0)
                    txtPercentageVat.Text = "0";
                else if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                    txtPercentageVat.Text = "0";

                if (txtPercentageOtherTax.Text.Trim().Length == 0)
                    txtPercentageOtherTax.Text = "0";
                else if (!clsCommon.isCurrency(txtPercentageOtherTax.Text.Trim()))
                    txtPercentageOtherTax.Text = "0";

                if (txtCreditDays.Text.Trim().Length == 0)
                    txtCreditDays.Text = "0";
                //else if (!clsCommon.isCurrency(txtCreditDays.Text.Trim()) || decimal.Parse(txtCreditDays.Text.Trim()) > 0)
                //    txtCreditDays.Text = "0";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region  Event Double Click
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtAPNType_DoubleClick(object sender, EventArgs e)
        {
            Search_APN_Type();
        }

        private void txtGRN_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionExternalGoodReceivedNote_Direct(ref txtGRN, false, true, txtSupplierID.Tag != null ? txtSupplierID.Tag.ToString() : "", txtNoteType.Tag != null ? txtNoteType.Tag.ToString() : "");
                if (txtGRN.Tag != null && txtGRN.Tag.ToString().Trim().Length > 0)
                    FillDetailByGRN(txtGRN.Tag.ToString().Trim());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditySubTotal())
            {
                if (dgvGRN.RowCount == 0)
                {
                    clearSubGLCodeExceptThis("Supplier");
                    Search_Supplier();
                }
            }
        }
        private void txtCostCenter1_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditySubTotal())
            {
                clearSubGLCodeExceptThis("CostCenter1");
                Search_CostCenter1ID();
            }
        }
        private void txtCostCenter2_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditySubTotal())
            {
                clearSubGLCodeExceptThis("CostCenter2");
                Search_CostCenter2ID();
            }
        }

        private void txtAPNID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, chkShowSettle.Checked, "", "", false, false, true, false);
            if (txtAPNID.Tag != null)
                FillDetails(txtAPNID.Tag.ToString());
        }
        #endregion

        #region  Event Key Down
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }

        private void txtAPNType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAPNType_DoubleClick(sender, e);
        }

        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtSupplierID_DoubleClick(sender, e);
        }

        private void txtAPNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAPNID_DoubleClick(sender, e);
        }

        private void txtGRN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtGRN_DoubleClick(null, null);
        }
        #endregion

        #region Events KeyUp
        private void txtSubTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (clsCommon.isCurrency(txtSubTotal.Text.Trim()) && decimal.Parse(txtSubTotal.Text.ToString()) > 0)
            {
                txtSubTotal.Tag = decimal.Parse(txtSubTotal.Text.ToString());
                CalculateTaxesAndGrandTotal();
            }
        }

        private void txtNBT_KeyUp(object sender, KeyEventArgs e)
        {
            if (clsCommon.isCurrency(txtNBT.Text.Trim()) && decimal.Parse(txtNBT.Text.ToString()) > 0)
            {
                txtNBT.Tag = decimal.Parse(txtNBT.Text.ToString());
            }
        }
        #endregion

        #region Events Leave

        private void txtNBT_Leave(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtNBT.Text.Trim()) && decimal.Parse(txtNBT.Text.ToString()) > 0)
            {
                txtNBT.Tag = decimal.Parse(txtNBT.Text.ToString());

                decimal dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                decimal dActualSubTotal = (dSubTotal);
                CalculatePesentage(ref txtPercentageNBT, decimal.Parse(txtNBT.Text.Trim()), dActualSubTotal);
                CalculateTaxesAndGrandTotal();
                Refresh_PostingEntys();
            }
        }
        private void txtVat_Leave(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtVat.Text.Trim()) && decimal.Parse(txtVat.Text.ToString()) > 0)
            {
                txtVat.Tag = decimal.Parse(txtVat.Text.ToString());
                decimal dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                decimal dNBT = decimal.Parse(txtNBT.Text.Trim());
                decimal dActualSubTotal = (dSubTotal) + dNBT;
                CalculatePesentage(ref txtPercentageVat, decimal.Parse(txtVat.Text.Trim()), dActualSubTotal);
                CalculateTaxesAndGrandTotal();
                Refresh_PostingEntys();
            }
        }
        private void txtOtherTax_Leave(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtOtherTax.Text.Trim()) && decimal.Parse(txtOtherTax.Text.ToString()) > 0)
            {
                txtOtherTax.Tag = decimal.Parse(txtOtherTax.Text.ToString());

                decimal dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                decimal dNBT = decimal.Parse(txtNBT.Text.Trim());
                decimal dVAT = decimal.Parse(txtVat.Text.Trim());
                decimal dActualSubTotal = (dSubTotal) + dNBT + dVAT;
                CalculatePesentage(ref txtPercentageOtherTax, decimal.Parse(txtOtherTax.Text.Trim()), dActualSubTotal);
                CalculateTaxesAndGrandTotal();

            }
        }
        #endregion

        #region Events KeyPress

        private void txtCreditDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowInteger(e);
        }
        private void txtSubTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        private void txtNBT_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        private void txtVat_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        private void txtOtherTax_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength((TextBox)sender, e, 18, 6);
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                chkVat.Checked = true;
                txtNBT.Enabled = true;

                if (clsConfig.bEnable_TAX_ManualMode)
                    txtPercentageNBT.Enabled = true;
            }
            else
            {
                txtPercentageNBT.Enabled = false;
                txtNBT.Enabled = false;
            }
            CalculateTaxesAndGrandTotal();
            Refresh_PostingEntys();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;
                txtVat.Enabled = true;

                if (clsConfig.bEnable_TAX_ManualMode)
                    txtPercentageVat.Enabled = true;
            }
            else
            {
                txtVat.Enabled = false;
                txtPercentageVat.Enabled = false;
            }
            CalculateTaxesAndGrandTotal();
            Refresh_PostingEntys();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;
                CalculateTaxesAndGrandTotal();
                txtOtherTax.Enabled = true;

                if (clsConfig.bEnable_TAX_ManualMode)
                    txtPercentageOtherTax.Enabled = true;
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtOtherTax.Enabled = false;
            }
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Search Methods
        private void Search_Supplier()
        {
            try
            {
                if (rdoSupplier.Checked)
                {
                    clsSearch.Search_MasterSupplier(ref txtSupplierID);
                    if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                        fillSupplierCode(txtSupplierID.Tag.ToString());
                }
                else
                {
                    clsSearch.Search_MasterAccountGLCode(ref txtSupplierID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
                    if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                    {
                        List<tbl_accGLMaster_Supplier> oAccLink = tbl_accGLMaster_Supplier.SelectAllByGl_ID(txtSupplierID.Tag.ToString());


                        if (oAccLink.Count > 1)
                        {
                            MessageBox.Show("Sorry..! You cannot use this ledger code as a creaditor, As it is linked to more than one suppliers", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtSupplierID.Tag = null;
                            txtSupplierID.Text = "";
                        }
                        else if (oAccLink.Count == 1)
                        {
                            txtSupplierID.Tag = oAccLink.FirstOrDefault().Supplier_ID;
                        }
                        else
                        {
                            tbl_genSupplierMaster oSupplier = new tbl_genSupplierMaster(txtSupplierID.Tag.ToString(), clsGenaralName.getName_AccountName(txtSupplierID.Tag.ToString()), "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, false, false, false, "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", new byte[1], 0, false, false, false, "default", "default", "default", true, false, "default");
                            oSupplier.Insert();
                            tbl_accGLMaster_Supplier oAcc = new tbl_accGLMaster_Supplier(txtSupplierID.Tag.ToString(), txtSupplierID.Tag.ToString(), true);
                            oAcc.Insert();
                        }
                    }
                }
                Refresh_PostingEntys();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_APN_Type()
        {
            clsSearch.Search_AccountPayableNoteType_New(ref txtAPNType);
        }

        private void Search_CostCenter1ID()
        {
            try
            {
                clsSearch.Search_costCenter1(ref txtCostCenter1);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CostCenter2ID()
        {
            try
            {
                clsSearch.Search_costCenter2(ref txtCostCenter2);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void clearSubGLCodeExceptThis(string sCategory)
        {
            if (sCategory == "Supplier")
            {
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                //    pbxCos1.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                //    pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "Employee")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                //  pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                //  pbxCos1.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                //   pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "CostCenter1")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                //   pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                // txtOtherCr.Tag = null;
                //  txtOtherCr.Clear();
                //  pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                //  pbxCos2.Image = Digiteq.Properties.Resources.Free;
            }
            else if (sCategory == "CostCenter2")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                //  pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                //   txtOtherCr.Tag = null;
                //   txtOtherCr.Clear();
                //  pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                //      pbxCos1.Image = Digiteq.Properties.Resources.Free;

            }
        }

        #endregion


        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Calculate Tax Pesentage
        private void CalculatePesentage(ref TextBox txtPesentage, decimal dAmount, decimal dSubTotal)
        {
            txtPesentage.Text = ((dAmount / dSubTotal) * 100).ToString();
        }
        #endregion


        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                bool bIsCanceled = false;
                if (txtAPNID.Text.Trim().Length > 0 && txtAPNID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    glb_dts_Apn.Clear();
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDraff = "";
                    string sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true, bisDataset = false; ;
                    tbl_accAccountPayableNote APN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                    if (APN != null)
                    {

                        if (!bIsDraft)
                        {
                            #region Validate Approval
                            if (clsConfig.bApprovalNeedToPrintCreditNote)
                                bApprovalDone = true;
                            else
                                bApprovalDone = true;
                            #endregion
                            #region Validate Checking
                            if (clsConfig.bCheckingNeedToPrintCreditNote)
                                bCheckingDone = true;
                            else
                                bCheckingDone = true;
                            #endregion
                        }

                        decimal dWithNBTAmount = 0, dSubTotal = 0, dNBTAmount = 0, dVatAmount = 0;
                        clsHelpMethods.SetVATandNBTValues_FromGrandTotal(APN.SubTotal, APN.VatTotal, APN.NbtPercentage, ref dWithNBTAmount, ref dSubTotal, ref dNBTAmount, ref dVatAmount);

                        string sSupplierAddress = "";
                        tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(APN.Customer_ID);
                        List<tbl_accAccountPayableNote_SubTotal> oAPN_SubTotals = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(APN.AccountPayableNote_ID);
                        if (oSup != null && oAPN_SubTotals != null)
                        {
                            sSupplierAddress = oSup.AddressRegister;
                            //decimal dCreditVal = 0, dDebetVal = 0;
                            if (APN.IsDeleted)
                                bIsCanceled = true;

                            glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(APN.AccountPayableNote_ID, APN.AccountPayableNoteDate, clsGenaralName.getName_APNType(APN.ApnType_ID), APN.Narration, clsGenaralName.getName_Supplier(APN.Supplier_ID),
                                APN.BillNo, APN.BillDate, APN.PurchaseOrder_ID, APN.ExternalGoodReceivedNote_ID, APN.NoDeliveryOrder, APN.NoAWB, APN.NoLC, APN.CreditDays.ToString(),
                                APN.DiscountTotal, APN.NbtTotal, APN.VatTotal, APN.OtherTaxTotal, APN.SubTotal, APN.GrandTotal, 0, "", "", 0, 0, "", APN.CreditDays, APN.IsDeleted, clsGenaralName.getName_SupplierPayee(APN.Supplier_ID), clsGenaralName.getSupplierAddressRegister(APN.Supplier_ID),
                                APN.DiscountPercentage, APN.VatPercentage, APN.NbtPercentage, APN.OtherTaxPercentage);

                            //foreach (tbl_accAccountPayableNote_SubTotal oAPN_SubTotal in oAPN_SubTotals)
                            //{
                            //    dCreditVal = 0;
                            //    dDebetVal = 0;
                            //    if (oAPN_SubTotal.IsCredit)
                            //        dCreditVal = oAPN_SubTotal.Amount;
                            //    else
                            //        dDebetVal = oAPN_SubTotal.Amount;

                            //    glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(APN.AccountPayableNote_ID, APN.AccountPayableNoteDate, clsGenaralName.getName_APNType(APN.ApnType_ID), APN.Narration, clsGenaralName.getName_Supplier(APN.Supplier_ID), APN.BillNo, APN.BillDate, APN.PurchaseOrder_ID, APN.ExternalGoodReceivedNote_ID, APN.NoDeliveryOrder, APN.NoAWB, APN.NoLC, APN.CreditDays.ToString(), APN.DiscountTotal, APN.NbtTotal, APN.VatTotal, APN.OtherTaxTotal, APN.SubTotal, APN.GrandTotal, oAPN_SubTotal.Line_No, oAPN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oAPN_SubTotal.Gl_ID), dCreditVal, dDebetVal, "", 0, false, "", clsGenaralName.getSupplierAddressRegister(APN.Supplier_ID), 0, 0, 0, 0);
                            //}
                        }

                        foreach (tbl_accAccountPayableNote_SubTotal oAPN_SubTotal in oAPN_SubTotals)
                        {
                            decimal dCreditVal = 0, dDebetVal = 0;
                            dCreditVal = 0;
                            dDebetVal = 0;
                            if (oAPN_SubTotal.IsCredit)
                                dCreditVal = oAPN_SubTotal.Amount;
                            else
                                dDebetVal = oAPN_SubTotal.Amount;

                            glb_dts_Apn.dts_AccountPaybleNoteDetail.Adddts_AccountPaybleNoteDetailRow(APN.AccountPayableNote_ID, oAPN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oAPN_SubTotal.Gl_ID), clsGenaralName.getName_AccCostCenter1(oAPN_SubTotal.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oAPN_SubTotal.CostCenter2_ID), "", oAPN_SubTotal.IsCredit, oAPN_SubTotal.Amount);
                        }

                        List<tbl_accAccountPayableNote_Allocation> oAllDetail = tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == APN.AccountPayableNote_ID).ToList();
                        var oAllocation = oAllDetail.GroupBy(gb => new { gb.ExternalGoodReceivedNote_ID }, (Key, group) =>
                                            new { ExternalGoodReceivedNote_ID = Key.ExternalGoodReceivedNote_ID, SettledAmount = group.Sum(p => p.AllocatedAmount) });

                        foreach (var oGRNAllocation in oAllocation.OrderBy(p => (p.ExternalGoodReceivedNote_ID)))
                        {
                            string sPOID = "";
                            foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(oGRNAllocation.ExternalGoodReceivedNote_ID))
                            {
                                sPOID = oGRNDetail.PurchaseOrder_ID;
                            }
                            tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(oGRNAllocation.ExternalGoodReceivedNote_ID);
                            tbl_scsPurchaseOrder oPO = tbl_scsPurchaseOrder.Select(sPOID);
                            if (oGRN != null && oPO != null)
                            {
                                glb_dts_Apn.dt_GrnDetail.Adddt_GrnDetailRow(APN.AccountPayableNote_ID, oPO.PurchaseOrderDate, sPOID, oGRN.ExternalGoodReceivedNoteDate, oGRN.ExternalGoodReceivedNote_ID, oGRN.DeliveryOrderNumber, oPO.GrandTotal, oGRNAllocation.SettledAmount, oGRNAllocation.SettledAmount);

                            }
                        }

                        if (bApprovalDone && bCheckingDone)
                        {
                            bOkToPrint = true;

                            #region Print The Doc
                            if (bOkToPrint && bApprovalDone)
                            {
                                if (!bIsDraft)
                                {
                                    sDuplicateCopy = APN.PrintCount > 0 ? "Duplicate Copy " + APN.PrintCount : "";

                                    APN.PrintCount++;
                                    APN.Update();
                                }

                                sCreateUser = "[ " + clsGenaralName.getName_User(APN.CreateUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(APN.DateCreate) + " ]";
                                if (APN.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(APN.CheckedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(APN.DateChecked) + " ]";
                                if (APN.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(APN.ApprovedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(APN.DateApproved) + " ]";


                                string s_Path = "", sReportTitle = "SUPPLIER ACCOUNT PAYABLE NOTE", sFormula = "";
                                if (txtAPNID.TextLength > 0)
                                    sFormula = " {vw_rpt_accAccountPayableNote.accountPayableNote_ID} = '" + txtAPNID.Text.Trim() + "'";
                                ReportDocument RD = new ReportDocument();

                                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));

                                if (sGetRptPath != null && sGetRptPath.Length > 0)
                                    s_Path = sGetRptPath;
                                else
                                {
                                    s_Path = "\\Reports\\BSS\\NotePrinting\\rpt_bpsAPN.rpt";
                                }
                                bisDataset = true;

                                //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //{
                                //    s_Path = "\\Reports\\BSS\\NotePrinting\\rpt_bpsCreditNote_AKT.rpt";
                                //    bIsDataset = true;
                                //}
                                //else
                                //    s_Path += "\\Reports\\ACC\\NotePrinting\\rpt_accAPNote.rpt";

                                if (bisDataset)
                                {
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsSecurity.DigiteqEmail, true,false);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);

                                    if (bIsCanceled)
                                    {
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "Canceled", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", "", true,false);
                                    }
                                    else
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "", true,false);

                                    #region Company Details Fill
                                    string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                    byte[] bCompanyImage = clsCommon.getCompanyImage();
                                    if (bIsDraft)
                                    {
                                        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                        {
                                            sCompanyName = "";
                                            sCompanyAddress1 = "";
                                            sCompanyAddress2 = "";
                                            bCompanyImage = null;

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                        }
                                    }

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true,false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true,false);

                                    glb_dts_Apn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle, "", "", clsSecurity.UserNameLoged, "");

                                    #endregion

                                    frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                    ReportViewer.print(s_Path, glb_dts_Apn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));
                                    //print(s_Path, sReportTitle, glb_dts_Apn, sDraff, bIsCanceled, isDuplicate, sCreateUser);
                                }
                                else
                                {
                                    frm_ReportViewer viewer = new frm_ReportViewer();
                                    viewer.crystalReportViewer1.ShowExportButton = false;
                                    RD.Load(s_Path);
                                    clsSecurity.LogonServer(ref RD);
                                    RD.Refresh();

                                    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);

                                    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());

                                    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                    RD.DataDefinition.FormulaFields["IsCreditNote"].Text = clsCommon.fncsetstring("False");

                                    RD.DataDefinition.FormulaFields["Bank2"].Text = bIsCanceled ? "Cancelled" : "";
                                    RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = bIsCanceled ? "" : sDuplicateCopy;

                                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    {
                                        RD.DataDefinition.FormulaFields["APN_Type"].Text = clsCommon.fncsetstring(txtAPNType.Text);
                                        RD.DataDefinition.FormulaFields["GRN_No"].Text = clsCommon.fncsetstring(txtGRN.Text);
                                    }

                                    if (bIsDraft)
                                    {
                                        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                        {
                                            RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                                        }
                                    }
                                    viewer.crystalReportViewer1.ReportSource = RD;
                                    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                    viewer.crystalReportViewer1.Visible = true;
                                    viewer.crystalReportViewer1.DisplayToolbar = true;
                                    viewer.crystalReportViewer1.CloseView(false);
                                    viewer.WindowState = FormWindowState.Maximized;

                                    viewer.ShowDialog();

                                    RD.Close();
                                    RD.Dispose();
                                }
                            }
                            #endregion
                        }
                    }

                    // Sent Maill
                    clsAlerts_Email.createEmail_APN(txtAPNID.Text.Trim(), enum_Alerts.AccountPayableNotePrinted);
                }
                else
                    MessageBox.Show("Please Select the Credit Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sDraff, bool isCanceled, bool isDuplicate, string sCreateUserName)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUserName);
                objRpt.DataDefinition.FormulaFields["IsDraft"].Text = clsCommon.fncsetstring(sDraff);
                objRpt.DataDefinition.FormulaFields["IDTitle"].Text = clsCommon.fncsetstring("APN No");
                objRpt.DataDefinition.FormulaFields["IDDateTitle"].Text = clsCommon.fncsetstring("APN Date");
                objRpt.DataDefinition.FormulaFields["NumberID"].Text = clsCommon.fncsetstring("GRN No");
                objRpt.DataDefinition.FormulaFields["NumberDate"].Text = clsCommon.fncsetstring("GRN Date");


                if (isDuplicate)
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

                if (isCanceled)
                {
                    objRpt.DataDefinition.FormulaFields["Cancel"].Text = clsCommon.fncsetstring("Canceled");
                    objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("");
                }
                else
                    objRpt.DataDefinition.FormulaFields["Cancel"].Text = "";



                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        public string GetEnumDescription(Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();

        }

        #region Fill Data Table
        private void FilldataTable(int Line_No, string Gl_ID, decimal Debit, decimal Credit, string CostCenter1_ID, string CostCenter2_ID, string Employee_ID, string Customer_ID, TransactionCategory TransactionCategoryID, string Supplier_ID)
        {
            dt_GLP.Rows.Add(Line_No, GetEnumDescription(TransactionCategoryID), Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Debit, Credit, clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategoryID), CostCenter1_ID, CostCenter2_ID, Employee_ID);
        }
        #endregion

        private void chkSettings2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSettings2.Checked)
            {
                pnlSetting1.Visible = true;
                pnlSetting1.BringToFront();
                chkSettings2.Image = Digiteq.Properties.Resources.security;
            }
            else
            {
                pnlSetting1.Visible = false;
                pnlSetting1.SendToBack();
                chkSettings2.Image = Digiteq.Properties.Resources.settings;
            }
        }

        #region Currency Detials

        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurCode);
            if (txtCurCode.Tag != null)
                FillDetailsCurrency(txtCurCode.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }

        private void txtPercentageNBT_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void txtPercentageVat_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void txtPercentageOtherTax_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurCode.Tag = null;
                txtCurCode.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurCode.Tag = currency.Currency_ID;
                        txtCurCode.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                    }
                }
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvGRN.SelectedCells.Count != 0)
                {
                    if (dgvGRN.Rows.Count > 0)
                    {
                        dgvGRN.Rows.RemoveAt(dgvGRN.SelectedCells[0].RowIndex);
                        CalculateGrnTotal();

                        if (dgvGRN.Rows.Count == 0)
                        {
                            txtSubTotal.Enabled = true;
                            rdoOtherCr.Enabled = true;
                            rdoSupplier.Enabled = true;
                        }
                        else
                        {
                            txtSubTotal.Enabled = false;
                            rdoOtherCr.Enabled = false;
                            rdoSupplier.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dt_GRN.Rows.Clear();
            CalculateGrnTotal();
        }

        #region User Details
        #region Search Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtAPNID.Text != null && txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    glbApprovedDate = clsSecurity.getServerDateTime();
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accAccountPayableNote objAPN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                        if (objAPN != null)
                                        {
                                            objAPN.IsApproved = true;
                                            objAPN.DateApproved = clsSecurity.getServerDateTime();
                                            objAPN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objAPN.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtAPNID.Text != null && txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    glbCheckedDate = clsSecurity.getServerDateTime();

                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_accAccountPayableNote objAPN = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                                        if (objAPN != null)
                                        {
                                            objAPN.IsChecked = true;
                                            objAPN.DateChecked = clsSecurity.getServerDateTime();
                                            objAPN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objAPN.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void UserDetails()
        {
            try
            {
                if (txtAPNID.Text != "" || txtAPNID.Text != "<Auto Generate>")
                {
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtAPNID.Text);
                    if (detail != null)
                    {
                        DataTable dt_UserDetails = new DataTable();
                        dt_UserDetails.Columns.Add("usertype", typeof(string));
                        dt_UserDetails.Columns.Add("Column1", typeof(string));
                        dt_UserDetails.Columns.Add("user", typeof(string));
                        dt_UserDetails.Columns.Add("Column2", typeof(string));
                        dt_UserDetails.Columns.Add("datetime", typeof(string));

                        dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                        if (detail.DateCreate != detail.DateModified)
                            dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                        if (detail.IsChecked)
                            dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                        if (detail.IsApproved)
                            dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                        if (detail.IsDeleted)
                            dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                        Point startPoint = this.PointToScreen(new Point());

                        frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                        frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnApproved.BackColor = System.Drawing.Color.LightGray;
        //        this.btnChecked.BackColor = System.Drawing.Color.LightGray;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion

        private int GetRecordCount_Posting(TransactionCategory enm)
        {
            int iCount = 0;
            try
            {
                iCount = dt_GLP.Select("CategoryDesc ='" + GetEnumDescription(enm) + "'").CopyToDataTable().Rows.Count;
            }
            catch (Exception)
            {
            }
            return iCount;
        }

        private void dgvGRN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalculateGrnTotal();
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
            Refresh_PostingEntys();
        }

        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    string sColName = "";

                    if (e.ColumnIndex >= 0)
                        sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                    if (sColName == "accCode" || sColName == "accName")
                    {
                        string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                        if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                        {
                            List<string> lstParameeters = new List<string>();
                            lstParameeters.Add("");
                            lstParameeters.Add("");
                            lstParameeters.Add("-");

                            frmSearch RowDataSearch = new frmSearch(lstParameeters);
                            List<string> lstResult = RowDataSearch.Show(Search.AccName);
                            if (RowDataSearch.DialogResult == DialogResult.OK)
                            {
                                txtGLAccSubTotal.Text = lstResult[0];

                                dgvDetail["AccCode", e.RowIndex].Value = lstResult[0];
                                dgvDetail["AccName", e.RowIndex].Value = lstResult[1];
                            }
                        }
                    }

                    if (sColName == "SubAcct1")
                    {
                        //string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                        //if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                        {
                            frmSearch RowDataSearch = new frmSearch();
                            List<string> lstResult = RowDataSearch.Show(Search.CostCentre1);
                            if (RowDataSearch.DialogResult == DialogResult.OK)
                            {
                                txtGLAccSubTotal.Text = lstResult[0];

                                dgvDetail["SubAcct1_ID", e.RowIndex].Value = lstResult[0];
                                dgvDetail["SubAcct1", e.RowIndex].Value = lstResult[1];
                            }
                        }
                    }

                    if (sColName == "SubAcct2")
                    {
                        //string sType = clsValidate.ValidateGridValue(dgvDetail, "CategoryDesc", e.RowIndex, "");
                        //if (sType == GetEnumDescription(TransactionCategory.SubTotal))
                        {

                            frmSearch RowDataSearch = new frmSearch();
                            List<string> lstResult = RowDataSearch.Show(Search.CostCentre2);
                            if (RowDataSearch.DialogResult == DialogResult.OK)
                            {
                                txtGLAccSubTotal.Text = lstResult[0];

                                dgvDetail["SubAcct2_ID", e.RowIndex].Value = lstResult[0];
                                dgvDetail["SubAcct2", e.RowIndex].Value = lstResult[1];
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void btnSettlement_Click(object sender, EventArgs e)
        {
            if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString() != "default")
            {
                frm_accCreditorSettlement frm = new frm_accCreditorSettlement(FormName.accCreditorSettlement);
                frm.glbSupplier_ID = txtSupplierID.Tag.ToString();
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, (this.Parent as Form).MdiParent);
            }
        }

        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierID.Tag = null;
            txtSupplierID.Clear();
            Refresh_PostingEntys();
        }
    }
}