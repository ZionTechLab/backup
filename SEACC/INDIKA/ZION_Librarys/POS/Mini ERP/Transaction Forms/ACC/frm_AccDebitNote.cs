using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic;
using System.Data;
using CrystalDecisions.Shared;
using Digiteq.DataSets.ACC;
using DataTire;
using CrystalDecisions;
using System.Drawing;
using Digiteq.DataSets;
using System.Linq;

namespace Digiteq
{
    public partial class frm_AccDebitNote : SEACC_Form
    {
        #region Variables
        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        public decimal dExRate = 0;

        dts_DebitNote glb_dts_DebitNote = new dts_DebitNote();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        public string glbDebitNoteID = "";

        //for subTotal
        DataTable glb_dtGrandTotal;
        DataTable glb_dtSubTotal;
        DataTable glb_dtNBT;
        DataTable glb_dtVAT;
        DataTable glb_dtSubTotal_Temp;
        DataTable glb_dtSubTotal_Temp2;

        public DateTime glbApprovedDate;
        public DateTime glbCheckedDate;
        #endregion

        #region Form Load
        public frm_AccDebitNote(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accDebitNote);
            //iFormID = clsSecurity.getFormID(FormName.accDebitNote);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frm_AccDebitNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //clsFormatter.setFormatForm(this, "Supplier Debit Note", 2, iFormID);
            CreateDataTable();

            ClearFields();

            if (glbDebitNoteID != null && glbDebitNoteID.Length > 0)
                FillDetails(glbDebitNoteID);
        }
        #endregion

        #region Events Click
        #region Button New
        private void frm_AccDebitNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Save
        private void frm_AccDebitNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                {
                    try
                    {
                        decimal dSettleAmount = 0;
                        string sPRNID = rdoReturnGoods.Checked ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0) ? txtSPRNNo.Tag.ToString() : "default" : "default";
                        string sAPNID = (txtPRNNo.Tag != null && txtPRNNo.Tag.ToString().Length > 0) ? txtPRNNo.Tag.ToString().Trim() : "default";

                        #region update records
                        if (IsUpdate)  //update records
                        {
                            tbl_accDebitNote oOldRecord = tbl_accDebitNote.Select(txtDebitNoteID.Tag.ToString().Trim());
                            if (oOldRecord != null && clsValidate.CheckPrintingValidity(oOldRecord.PrintCount))
                            {
                                //  if (clsValidate.CheckAccountPostingValidity(oOldRecord.DebitNote_ID))
                                //  {
                                if (!oOldRecord.IsLocked && !oOldRecord.IsApproved && !oOldRecord.IsFinished && !oOldRecord.IsDeleted)
                                {
                                    if (!oOldRecord.IsChecked ||
                                        (oOldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text))
                                        {

                                            #region debit Note Header update

                                            tbl_accDebitNote AccDBN = new tbl_accDebitNote(txtDebitNoteID.Text.Trim(),
                                                dtpDabitNoteDate.Value, txtNarration.Text, sPRNID, sAPNID,
                                                oOldRecord.PaymentVoucher_ID, oOldRecord.Invoice_ID,
                                                oOldRecord.CreditNote_ID, txtSupplierID.Tag.ToString().Trim(),
                                                txtCurCode.Tag.ToString(),
                                                decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), dExRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtOtherTax.Text.Trim()), dExRate),
                                                clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()),
                                                    dExRate),
                                                clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()),
                                                    dExRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtDiscount.Text.Trim()), dExRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtSubTotal.Text.Trim()), dExRate),
                                                decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                decimal.Parse(txtPercentageVat.Text.Trim()),
                                                decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                                oOldRecord.CompanyID, oOldRecord.CompanyBranch_ID,
                                                oOldRecord.FinancialYear_ID, oOldRecord.PostingStatus_ID,
                                                oOldRecord.GlPosting_ID, oOldRecord.CostCenter1_ID,
                                                oOldRecord.CostCenter2_ID, oOldRecord.CreateUser_ID,
                                                clsSecurity.UserIDLoged, oOldRecord.CheckedUser_ID,
                                                oOldRecord.ApprovedUser_ID, oOldRecord.DeletedUser_ID,
                                                oOldRecord.PrintedUser_ID,
                                                clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                oOldRecord.DeletedTerminal_ID, oOldRecord.PrintedTerminal_ID,
                                                oOldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                oOldRecord.DateChecked, oOldRecord.DateApproved, oOldRecord.DateDeleted,
                                                oOldRecord.DatePrinted,
                                                oOldRecord.IsChecked, oOldRecord.IsApproved, oOldRecord.IsFinished,
                                                oOldRecord.IsDeleted, rdoReturnGoods.Checked, oOldRecord.IsSalesNote,
                                                rdoAPNAdjustment.Checked, oOldRecord.SettledAmount,
                                                oOldRecord.IsSettled, oOldRecord.IsLocked, oOldRecord.PrintCount);
                                            AccDBN.Update();

                                            #endregion

                                            #region Insert Debit Note Detail

                                            #region Reverce APN/SRN settlement

                                            foreach (tbl_accPaymentVoucher_Detail oPvdetailOld in
                                                tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(txtDebitNoteID.Tag
                                                    .ToString().Trim()))
                                            {
                                                if (oPvdetailOld.AccountPayableNote_ID != "default"
                                                ) //reverce APN Settlement
                                                {
                                                    tbl_accAccountPayableNote detail =
                                                        tbl_accAccountPayableNote.Select(oPvdetailOld
                                                            .AccountPayableNote_ID);
                                                    if (detail != null)
                                                    {
                                                        detail.SettledAmount -= oPvdetailOld.SettleAmount;
                                                        detail.IsSeattled = false;
                                                        detail.Update();
                                                    }
                                                }
                                                else // reverce srn settlement
                                                {
                                                    //Check This 
                                                    // tbl_scsPurchaseReturnedNote oPrn = tbl_scsPurchaseReturnedNote.Select(oOldRecord.PurchaseReturnedNote_ID);
                                                    //if (oPrn != null && oPrn.PurchaseReturnedNote_ID != "default")
                                                    //{
                                                    // oPrn.SeattleAmount
                                                    //}



                                                    //need to fill
                                                }
                                            }

                                            #endregion

                                            #region Delete and recreate payment voucher detail records

                                            tbl_accPaymentVoucher_Detail.DeleteAllByDebitNote_ID(
                                                oOldRecord.DebitNote_ID);

                                            string sApnId = "", sPrnId = "";
                                            decimal dApnAmount = 0;
                                            int iRowCount = 0;
                                            foreach (DataGridViewRow row in dgvAPN.Rows)
                                            {

                                                sApnId = rdoAPNAdjustment.Checked
                                                    ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "")
                                                    : clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                                sPrnId = !rdoAPNAdjustment.Checked
                                                    ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0
                                                        ? txtPRNNo.Tag.ToString()
                                                        : "default")
                                                    : "default";

                                                dApnAmount = clsHelpMethods.getSavePrice(
                                                    decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount",
                                                        row.Index, "0.00")), dExRate);
                                                tbl_accPaymentVoucher_Detail oPvDetail =
                                                    new tbl_accPaymentVoucher_Detail(iRowCount, "default", sApnId,
                                                        "default", txtDebitNoteID.Text.Trim(), "default", "default", -1,
                                                        "default", -1, "", dApnAmount, true);
                                                oPvDetail.Insert();
                                                iRowCount++;

                                                if (sApnId != "default" && sApnId.Length > 0)
                                                {
                                                    tbl_accAccountPayableNote detail =
                                                        tbl_accAccountPayableNote.Select(sApnId);
                                                    if (detail != null)
                                                    {
                                                        detail.SettledAmount += dApnAmount;
                                                        if (detail.GrandTotal <= detail.SettledAmount)
                                                            detail.IsSeattled = true;
                                                        detail.Update();
                                                    }
                                                }

                                                if (sPrnId != "default" && sPrnId.Length > 0)
                                                {
                                                    tbl_scsPurchaseReturnedNote detail =
                                                        tbl_scsPurchaseReturnedNote.Select(sPrnId);
                                                    if (detail != null)
                                                    {
                                                        detail.SeattleAmount += dApnAmount;
                                                        if (detail.GrandTotal <= detail.SeattleAmount)
                                                            detail.IsSeattled = true;
                                                        detail.Update();
                                                    }
                                                }
                                            }

                                            #endregion

                                            #endregion

                                            #region Insert supplier outstanding amount

                                            //  clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), oOldRecord.GrandTotal, 0, true);
                                            //   clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, false);

                                            #endregion

                                            #region  Insert Detail - DEBIT NOTE Account Details

                                            //tbl_accGLPosting_Detail_Tmp.DeleteAllByGlPosting_ID(oOldRecord.GlPosting_ID);
                                            //tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oOldRecord.GlPosting_ID);
                                            clsMethods_GL.GLPosting_Delete(oOldRecord.GlPosting_ID);


                                            //tbl_accGLPosting_Tmp oGL = tbl_accGLPosting_Tmp.Select(oOldRecord.GlPosting_ID);
                                            //if (oGL != null && oGL.GlPosting_ID != "default")
                                            //{
                                            //    oGL.Remark = txtNarration.Text.Trim();
                                            //    oGL.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            //    oGL.ModifiedTerminal_ID = clsSecurity.TerminalID;
                                            //    oGL.DateModified = clsSecurity.getServerDateTime();
                                            //    oGL.Update();
                                            //}

                                            tbl_accDebitNote_SubTotal.DeleteAllByDebitNote_ID(oOldRecord.DebitNote_ID);

                                            int iRow;
                                            string sGLCode = "",
                                                sSubAcct1 = "",
                                                sSubAcct2 = "",
                                                sSubAcct1_ID = "",
                                                sSubAcct2_ID = "",
                                                sOtherCr = "",
                                                sCategoryID = "",
                                                sRemarks = "";
                                            bool bIsCredit;
                                            decimal dAmount;
                                            dSettleAmount = 0;

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index,
                                                    "");
                                                sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1",
                                                    row.Index, "");
                                                sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2",
                                                    row.Index, "");
                                                sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID",
                                                    row.Index, "");
                                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks",
                                                    row.Index, "");
                                                sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1",
                                                    row.Index, "default");
                                                sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2",
                                                    row.Index, "default");
                                                sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index,
                                                    "default");
                                                bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit",
                                                    row.Index, true);
                                                iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                    int.Parse("0"));

                                                if (bIsCredit)
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount",
                                                        row.Index, decimal.Parse("0.00"));
                                                else
                                                {
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dSettleAmount += clsValidate.ValidateGridValue(dgvDetail,
                                                        "debitAmount", row.Index, decimal.Parse("0.00"));
                                                }

                                                #region Insert Debit Note SubTotal

                                                //this method
                                                tbl_accDebitNote_SubTotal Insdetail = new tbl_accDebitNote_SubTotal(
                                                    iRow, txtDebitNoteID.Text.Trim(), sCategoryID, sGLCode,
                                                    txtSupplierID.Tag.ToString(), sSubAcct1_ID, sSubAcct2_ID, dAmount,
                                                    bIsCredit);
                                                Insdetail.Insert();

                                                #endregion

                                                //#region GL Posting Detail
                                                ////update this method
                                                //clsProcessMethods.GLPostingDetailTemp(iRow, oOldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.Supplier_DebitNote), txtDebitNoteID.Text.Trim(), sGLCode,
                                                //                    sSubAcct1_ID, sSubAcct2_ID, "default", txtSupplierID.Tag.ToString(), "default", "default", "-", txtDebitNoteID.Text.Trim(), "default",
                                                //                    dtpDabitNoteDate.Value, txtNarration.Text, dAmount, bIsCredit, "default", txtSupplierID.Text.Trim());
                                                //#endregion
                                            }

                                            #endregion

                                            #region Debit Note settlement

                                            //need to implement -atp-

                                            #endregion

                                            clsMethods_GL.PostTransaction_SuplierDBN(txtDebitNoteID.Text.Trim());

                                            //Attachments.Insert(iFormID, oOldRecord.DebitNote_ID);
                                            //Attachments.Remove(iFormID, oOldRecord.DebitNote_ID);

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);//locked

                                //  }
                            }
                        }
                        #endregion

                        #region insert records
                        else
                        {
                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                txtDebitNoteID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                            if (clsValidate.CheckValidity_TransactionCodeLength(txtDebitNoteID.Text)) //if (txtDebitNoteID.Text.Trim().Length > 0)
                            {
                                #region debit Note Header
                                tbl_accDebitNote AccDBN = new tbl_accDebitNote(txtDebitNoteID.Text.Trim(), dtpDabitNoteDate.Value, txtNarration.Text, sPRNID, sAPNID, "default", "default", "default", txtSupplierID.Tag.ToString().Trim(), txtCurCode.Tag.ToString(),
                                    decimal.Parse(txtCurrencyRate.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), dExRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), dExRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()), dExRate), clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), dExRate), clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), dExRate),
                                    clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), dExRate), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                    clsSecurity.CompanyID, clsSecurity.BranchID, clsSecurity.FinancialYearID, clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), "default", "default", "default", clsSecurity.UserIDLoged, "default", "default", "default", "default", "default",
                                    clsSecurity.TerminalID, "default", "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                    false, false, false, false, rdoReturnGoods.Checked, false, rdoAPNAdjustment.Checked, 0, false, false, 0);
                                AccDBN.Insert();
                                #endregion

                                #region Insert Debit Note Detail
                                string sApnId = "", sPrnId = "";
                                decimal dApnAmount = 0;
                                int iRowCount = 0;
                                foreach (DataGridViewRow row in dgvAPN.Rows)
                                {
                                    //sApnId = rdoAPNAdjustment.Checked ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "") : "default";                                    
                                    // sPrnId = !rdoAPNAdjustment.Checked ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "") : "default";

                                    sApnId = rdoAPNAdjustment.Checked ? clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "") : clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                    sPrnId = !rdoAPNAdjustment.Checked ? (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0 ? txtPRNNo.Tag.ToString() : "default") : "default";

                                    iRowCount = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));

                                    dApnAmount = clsHelpMethods.getSavePrice(decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, "0.00")), dExRate);
                                    tbl_accPaymentVoucher_Detail oPvDetail = new tbl_accPaymentVoucher_Detail(iRowCount, "default", sApnId, "default", txtDebitNoteID.Text.Trim(), "default", "default", -1, "default", -1, "", dApnAmount, true);
                                    oPvDetail.Insert();

                                    if (sApnId != "default" && sApnId.Length > 0)
                                    {
                                        tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sApnId);
                                        if (detail != null)
                                        {
                                            detail.SettledAmount += dApnAmount;
                                            if (detail.GrandTotal <= detail.SettledAmount)
                                                detail.IsSeattled = true;
                                            detail.Update();
                                        }
                                    }
                                    if (sPrnId != "default" && sPrnId.Length > 0)
                                    {
                                        tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sPrnId);
                                        if (detail != null)
                                        {
                                            detail.SeattleAmount += dApnAmount;
                                            if (detail.GrandTotal <= detail.SeattleAmount)
                                                detail.IsSeattled = true;
                                            detail.Update();
                                        }
                                    }
                                }
                                #endregion

                                //#region insert GLPostingHeaderTemp
                                //string sPostingID = "default";
                                //sPostingID = clsProcessMethods.GLPostingHeaderTempInsert(dtpDabitNoteDate.Value, txtNarration.Text.Trim());
                                ////Set GlPosting
                                //AccDBN.GlPosting_ID = sPostingID.Trim();
                                //AccDBN.Update();
                                //#endregion

                                #region Insert supplier outstanding amount
                                //     clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, false);
                                #endregion

                                #region  Insert Detail - DEBIT NOTE Account Details
                                int iRow;
                                string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";
                                bool bIsCredit;
                                decimal dAmount;
                                dSettleAmount = 0;

                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "");
                                    sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index, "");
                                    sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index, "");
                                    sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", row.Index, "");
                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                    sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index, "default");
                                    sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index, "default");
                                    sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index, "default");
                                    bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);
                                    iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));

                                    if (bIsCredit)
                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                    else
                                    {
                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                        dSettleAmount += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                                    }

                                    #region Insert Debit Note SubTotal
                                    tbl_accDebitNote_SubTotal Insdetail = new tbl_accDebitNote_SubTotal(iRow, txtDebitNoteID.Text.Trim(), sCategoryID, sGLCode,
                                    txtSupplierID.Tag.ToString(), sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                    Insdetail.Insert();
                                    #endregion

                                    //#region GL Posting Detail
                                    //clsProcessMethods.GLPostingDetailTemp(iRow, sPostingID, clsAutocode.getAccSlotID(AccSlot.Supplier_DebitNote), txtDebitNoteID.Text.Trim(), sGLCode,
                                    //                    sSubAcct1_ID, sSubAcct2_ID, "default", txtSupplierID.Tag.ToString(), "default", "default", "-", txtDebitNoteID.Text.Trim(), "default",
                                    //                    dtpDabitNoteDate.Value, txtNarration.Text, dAmount, bIsCredit, "default", txtSupplierID.Text.Trim());
                                    //#endregion

                                }
                                #endregion

                                #region Debit Note settlement

                                //need to implement -atp-

                                #endregion

                                clsMethods_GL.PostTransaction_SuplierDBN(txtDebitNoteID.Text.Trim());
                                Attachments.Insert(txtDebitNoteID.Text.ToString());

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            //else
                            //    MessageBox.Show("Debit Note ID " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                        tbl_accDebitNote Fdetail = tbl_accDebitNote.Select(txtDebitNoteID.Text.ToString());
                        if (Fdetail != null)
                        {
                            ClearFields();
                            FillDetails(Fdetail.DebitNote_ID);
                        }
                    }
                }
            }
        }
        #endregion

        #region Button Delete
        private void frm_AccDebitNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDebitNoteID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsDeleted)
                                {
                                    //if (clsValidate.CheckAccountPostingValidity(detail.DebitNote_ID))
                                    //{
                                    //delete one record
                                    Cursor = Cursors.WaitCursor;
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "  Debit Note : " + txtPRNNo.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        #region Remove Settlement
                                        foreach (tbl_accPaymentVoucher_Detail oDbnDetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                                        {
                                            if (rdoAPNAdjustment.Checked)
                                            {
                                                #region Remove APN Settlement
                                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(oDbnDetail.AccountPayableNote_ID);
                                                if (oAPN != null)
                                                {
                                                    oAPN.SettledAmount -= oDbnDetail.SettleAmount;
                                                    if (oAPN.GrandTotal > oAPN.SettledAmount)
                                                        oAPN.IsSeattled = false;
                                                    oAPN.Update();
                                                }
                                                #endregion
                                            }
                                            oDbnDetail.IsSettled = false;
                                            oDbnDetail.SettleAmount = 0;
                                            oDbnDetail.Update();
                                            //else
                                            //{
                                            //    #region Remove PRN Settlement
                                            //    tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(oDbnDetail.PurchaseReturnedNote_ID);
                                            //    if (detail != null)
                                            //    {
                                            //        oPRN.SeattleAmount -= oDbnDetail.SettledAmount;
                                            //        if (oPRN.GrandTotal > oPRN.SeattleAmount)
                                            //            oPRN.IsSeattled = false;
                                            //        oPRN.Update();
                                            //    } 
                                            //    #endregion
                                            //}
                                        }
                                        #endregion

                                        //detail.IsDeleted = true;
                                        detail.IsDeleted = true;
                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.Update();

                                        //tbl_accGLPosting_Tmp tempHead = tbl_accGLPosting_Tmp.Select(detail.GlPosting_ID);
                                        //if (tempHead != null)
                                        //{
                                        //    List<tbl_accGLPosting_Detail_Tmp> tempDetail = tbl_accGLPosting_Detail_Tmp.SelectAllByGlPosting_ID(tempHead.GlPosting_ID);
                                        //    foreach (tbl_accGLPosting_Detail_Tmp postingTempDetail in tempDetail)
                                        //    {
                                        //        postingTempDetail.Delete();
                                        //    }
                                        //    tempHead.Delete();
                                        //}
                                        clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        ClearFields();
                                    }
                                    //}
                                }//deleted
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                            else // not found
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ItemNotFound), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Btn Remove APN Grid
        private void btnRemoveAPNGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAPN.SelectedCells.Count != 0)
                {
                    if (dgvAPN.Rows.Count > 0)
                    {
                        dgvAPN.Rows.RemoveAt(dgvAPN.SelectedCells[0].RowIndex);
                        UpdateApnTotal();
                        CalcualteTotalAmount();
                        CalculateTaxesAndSubTotal();
                        RefreshGridByPRN();
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

        #region Button Print
        private void frm_AccDebitNote_SF_printButton_Click(object sender, EventArgs e)
        {
            tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Transaction Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Draft
        private void frm_AccDebitNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_AccDebitNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_AccDebitNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_AccDebitNote_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Sub Total and Grand Total
        private void pbxSubTot_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtSubTotal, (decimal.Parse(txtSubTotal.Text.Trim()) * dExRate), TransactionCategory.SubTotal, iFormID, "", 1);
            if (glb_dtSubTotal != null && glb_dtSubTotal.Rows.Count > 0)
            {
                CalculateSubTotal();
                CalculateTaxesAndSubTotal();
                RefreshGrid();
            }
        }

        private void pbxNBT_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtNBT, (decimal.Parse(txtNBT.Text.Trim())), TransactionCategory.NBT, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtNBT != null && glb_dtNBT.Rows.Count > 0)
            {
                CalculateTaxesAndSubTotal();
                RefreshGrid();
            }
        }

        private void pbxVAT_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtVAT, (decimal.Parse(txtVat.Text.Trim())), TransactionCategory.VAT, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtVAT != null && glb_dtVAT.Rows.Count > 0)
            {
                CalculateSubTotal();
                CalculateTaxesAndSubTotal();
                RefreshGrid();
            }
        }
        private void pbxGrandTotal_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtGrandTotal, decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, TransactionCategory.GrandTotal, iFormID, "", 1);
            if (glb_dtGrandTotal != null && glb_dtGrandTotal.Rows.Count > 0)
            {
                CalculateTaxesAndSubTotal();
                RefreshGrid();
            }
        }
        #endregion

        #region Btn Temp
        private void frm_AccDebitNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteType, false);

                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSPRNNo, true);

                txtDebitNoteID.Tag = null;
                dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

                SetDisableControl(true);

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDebitNoteID.Text = "<Auto Generate>";
                else
                    txtDebitNoteID.Clear();
                if (txtDebitNoteID.Enabled)
                {
                    txtDebitNoteID.SelectAll();
                    txtDebitNoteID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteType, false);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSPRNNo, true);
            //  txtSPRNNo
            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, true);

            btnallocattion.Visible = false;

            SetDisableControl(true);

            txtCurCode.Tag = null;
            txtDebitNoteID.Tag = null;
            txtPRNNo.Tag = null;
            txtTrackingNo.Tag = null;
            txtDebitNoteType.Tag = null;
            lblDebitNoteType.Tag = null;
            lblAPNNo.Tag = null;
            dtpDabitNoteDate.Tag = null;

            txtSupplierID.Tag = null;
            txtCurCode.Clear();
            txtTrackingNo.Clear();
            txtDebitNoteType.Clear();
            txtPRNNo.Clear();
            txtDebitNoteType.Clear();
            txtTotalAmount.Clear();
            txtPRNNo.Clear();
            txtSubTotal.Clear();
            txtPercentageDiscount.Clear();
            txtPercentageNBT.Clear();
            txtNBT.Clear();
            txtPercentageVat.Clear();
            txtPercentageOtherTax.Clear();
            txtOtherTax.Clear();
            //txtGrandTotal.Text = 0;
            txtSupplierID.Clear();
            txtNarration.Clear();

            dtpDabitNoteDate.Value = clsSecurity.getServerDateTime();

            txtDiscount.Text = "0.00";

            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtVat.Text = "0.00";
            txtCreditAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";
            txtBalanceAmount.Text = "0.00";
            txtGrandTotal.Text = "0.00";

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            txtSPRNNo.Text = "";
            txtSPRNNo.Tag = null;
            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            chkShowSettle.Checked = false;
            rdoAPNAdjustment.Checked = true;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkSettings.Checked = true;

            chkPrintOriginal.Checked = false;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDebitNoteID.Text = "<Auto Generate>";
            else
                txtDebitNoteID.Clear();
            if (txtDebitNoteID.Enabled)
            {
                txtDebitNoteID.SelectAll();
                txtDebitNoteID.Focus();
            }
            dgvAPN.Rows.Clear();
            dgvDetail.Rows.Clear();

            glb_dtSubTotal.Rows.Clear();
            glb_dtNBT.Rows.Clear();
            glb_dtVAT.Rows.Clear();
            glb_dtGrandTotal.Rows.Clear();

            clsEvent.GLCode_TextChanged(pbxGrandTotal, "");
            clsEvent.GLCode_TextChanged(pbxNBT, "");
            clsEvent.GLCode_TextChanged(pbxSubTot, "");
            clsEvent.GLCode_TextChanged(pbxVAT, "");

            rdoAPNAdjustment.Checked = true;
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
            txtPercentageVat.Enabled = false;
            txtVat.Enabled = false;
            txtPercentageNBT.Enabled = false;
            txtNBT.Enabled = false;
            txtPercentageDiscount.Enabled = false;
            txtDiscount.Enabled = false;
            UpdateApnTotal();
            // clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);

            Attachments.Clear();
        }
        private void Clear_Vat()
        {
            txtPercentageVat.Enabled = false;
            txtVat.Enabled = false;
            txtVat.Text = "0.00";
            chkVat.Checked = false;
        }
        private void Clear_SVat()
        {
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
            txtOtherTax.Text = "0.00";
            chkOtherTax.Checked = false;
        }
        private void Clear_NBT()
        {
            txtPercentageNBT.Enabled = false;
            txtNBT.Enabled = false;
            txtNBT.Text = "0.00";
        }
        private void Clear_Discount()
        {
            txtPercentageDiscount.Enabled = false;
            txtDiscount.Enabled = false;
            txtDiscount.Text = "0.00";
            txtDiscount.Tag = "0.00";
            txtPercentageDiscount.Text = "0.00";
        }
        private void clearSubGLCodeExceptThis(string sCategory)
        {
            if (sCategory == "Supplier")
            {

                //txtOtherCr.Tag = null;
                //txtOtherCr.Clear();
                //pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                //txtCostCenter1.Tag = null;
                //txtCostCenter1.Clear();
                //pbxCos1.Image = Digiteq.Properties.Resources.Free;
                //txtCostCenter2.Tag = null;
                //txtCostCenter2.Clear();
                //pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "Employee")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                //pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                //txtCostCenter1.Tag = null;
                //txtCostCenter1.Clear();
                //pbxCos1.Image = Digiteq.Properties.Resources.Free;
                //txtCostCenter2.Tag = null;
                //txtCostCenter2.Clear();
                //pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "CostCenter1")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                //pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                //txtOtherCr.Tag = null;
                //txtOtherCr.Clear();
                //pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                //txtCostCenter2.Tag = null;
                //txtCostCenter2.Clear();
                //pbxCos2.Image = Digiteq.Properties.Resources.Free;
            }
            else if (sCategory == "CostCenter2")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();


            }
        }
        #endregion

        #region Fill
        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sDebitNote_ID)
        {
            try
            {
                glb_dtSubTotal.Rows.Clear();
                glb_dtNBT.Rows.Clear();
                glb_dtVAT.Rows.Clear();
                glb_dtGrandTotal.Rows.Clear();
                foreach (tbl_accDebitNote_SubTotal detail in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(sDebitNote_ID))
                {
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal).ToString()) //Debit Entry
                    {
                        glb_dtGrandTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), "", "default", clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, "default", false);
                        clsEvent.GLCode_TextChanged(pbxGrandTotal, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal).ToString()) //Credit Entry
                    {
                        glb_dtSubTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), "", "default", clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, "default", true);
                        clsEvent.GLCode_TextChanged(pbxSubTot, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT).ToString()) //Credit Entry
                    {
                        glb_dtNBT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), "", "default", clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, "default", true);
                        clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT).ToString()) //Credit Entry
                    {
                        glb_dtVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), "", "default", clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, "default", true);
                        clsEvent.GLCode_TextChanged(pbxVAT, "Accept");
                    }
                }
                //RefreshGrid();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(sID);
                    if (detail != null && detail.DebitNote_ID != "default")
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDebitNoteID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtPRNNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTrackingNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNNo, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblTrackingNo, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, true);
                        SetDisableControl(false);

                        //asign values
                        txtDebitNoteID.Tag = detail.DebitNote_ID;
                        dtpDabitNoteDate.Value = detail.DebitNote_Date;

                        //txtPRNNo.Text = detail.PurchaseReturnedNote_ID;
                        txtPRNNo.Text = "";
                        txtSupplierID.Tag = detail.Supplier_ID;

                        txtDebitNoteID.Text = detail.DebitNote_ID;
                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        txtNarration.Text = detail.Remarks;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();

                        if (detail.IsAPNAdjustment)
                        {
                            rdoAPNAdjustment.Checked = true;
                            rdoReturnGoods.Checked = false;
                        }
                        else
                        {
                            rdoAPNAdjustment.Checked = false;
                            rdoReturnGoods.Checked = true;
                        }
                        //Security Details

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

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;
                        if (chkDiscount.Checked)
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        if (chkNBT.Checked)
                            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        if (chkVat.Checked)
                            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        if (chkOtherTax.Checked)
                            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));


                        if (detail.IsReturnedGoods)
                        {
                            txtSPRNNo.Text = detail.PurchaseReturnedNote_ID;
                            txtSPRNNo.Tag = detail.PurchaseReturnedNote_ID; ;
                        }

                        string sTransactionId = "";
                        DateTime dtmTransactionDate = clsSecurity.getServerDateTime();
                        decimal dAmount = 0;

                        foreach (tbl_accPaymentVoucher_Detail APNdetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(detail.DebitNote_ID))
                        {
                            if (APNdetail.AccountPayableNote_ID != "default" && APNdetail.AccountPayableNote_ID != "")
                            {
                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(APNdetail.AccountPayableNote_ID);
                                if (oAPN.AccountPayableNote_ID != "default" && oAPN != null)
                                {
                                    sTransactionId = oAPN.AccountPayableNote_ID;
                                    dtmTransactionDate = oAPN.AccountPayableNoteDate;
                                }
                            }
                            dAmount = clsHelpMethods.getDisplayPrice(APNdetail.SettleAmount, dExRate);
                            dgvAPN.Rows.Add(sTransactionId, clsFormatter.FormatDate_Short(dtmTransactionDate), clsFormatter.FormatDecimalPlaces_Price(dAmount));
                        }

                        FillDetailGLCodes(detail.DebitNote_ID);
                        CalculateSubTotal();
                        CalculateTaxesAndSubTotal();
                        RefreshGrid();
                        UpdateApnTotal();

                        Attachments.FillAttachments(sID);
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
        #region Fill Currency Detials
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
                        dExRate = currency.CurrencyRate;
                        txtCurrencyRate.Text = dExRate.ToString();
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
        private void FillDetailsAPN(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                    if (detail != null)
                    {

                        clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);

                        txtPRNNo.Tag = detail.AccountPayableNote_ID;
                        txtPRNNo.Text = detail.AccountPayableNote_ID;

                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);

                        if (txtPRNNo.Tag != null)
                        {
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);
                        }

                        txtSubTotal.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                        //txtCurCode.Tag = detail.Currency_ID;
                        //txtCurCode.Text = clsGenaralName.getName_Currency(detail.Currency_ID);

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                        txtPercentageDiscount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);


                        //FillDetailsCurrency(clsConfig.sLocalCurrencyCode);//Implement Later For Forign Currancy.....
                        FillDetailsCurrency(detail.Currency_ID);
                        FillDetailGLCodesAPN(sID);

                        //dgvAPN.Rows.Add(detail.AccountPayableNote_ID, clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate), clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal - detail.SettledAmount));
                        decimal dUnSettledAmount = detail.GrandTotal - detail.SettledAmount;
                        dgvAPN.Rows.Add(detail.AccountPayableNote_ID, clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate), clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(dUnSettledAmount, dExRate)));
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void FillDetailsPRN(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsPurchaseReturnedNote detail = tbl_scsPurchaseReturnedNote.Select(sID);
                    if (detail != null & detail.PurchaseReturnedNote_ID != "default")
                    {
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPRNNo, true);

                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        if (txtPRNNo.Tag != null)
                        {
                            //clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, false);
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoAPNAdjustment, false);
                            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnGoods, false);
                        }

                        //FillDetailsCurrency(clsConfig.sLocalCurrencyCode);//Implement Later For Forign Currancy.....
                        FillDetailsCurrency(detail.Currency_ID);

                        // dgvAPN.Rows.Add(detail.PurchaseReturnedNote_ID, clsFormatter.FormatDate_Short(detail.PurchaseReturnedNoteDate), clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal));
                        txtTotalAmount.Text = (detail.GrandTotal - detail.SeattleAmount).ToString(); //this is only for single PRN 
                        txtTotalAmount.Tag = (detail.GrandTotal - detail.SeattleAmount).ToString(); //this is only for single PRN 

                        txtSubTotal.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                        txtPercentageDiscount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #region Fill Data Table
        private void FilldataTable(int Line_No, string Gl_ID, decimal Amount, string CostCenter1_ID, string CostCenter2_ID, string Employee_ID, string Customer_ID, TransactionCategory TransactionCategoryID, string Supplier_ID, bool IsCredit)
        {
            try
            {
                if (TransactionCategoryID == TransactionCategory.GrandTotal) //Debit Entry
                {
                    glb_dtGrandTotal.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID, false);
                    clsEvent.GLCode_TextChanged(pbxGrandTotal, "Accept");

                }
                else if (TransactionCategoryID == TransactionCategory.SubTotal) //Credit Entry
                {
                    glb_dtSubTotal.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID, true);
                    clsEvent.GLCode_TextChanged(pbxSubTot, "Accept");
                }
                else if (TransactionCategoryID == TransactionCategory.NBT) //Credit Entry
                {
                    glb_dtNBT.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID, true);
                    clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                }
                else if (TransactionCategoryID == TransactionCategory.VAT) //Credit Entry
                {
                    glb_dtVAT.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID, true);
                    clsEvent.GLCode_TextChanged(pbxVAT, "Accept");
                }
                //if (TransactionCategoryID == TransactionCategory.GrandTotal || TransactionCategoryID == TransactionCategory.SubTotal || TransactionCategoryID == TransactionCategory.Discount || TransactionCategoryID == TransactionCategory.NBT || TransactionCategoryID == TransactionCategory.VAT || TransactionCategoryID == TransactionCategory.SVAT)
                //{
                //    glb_dtSubTotal.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                //        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategoryID)
                //        , CostCenter1_ID, CostCenter2_ID, Employee_ID, IsCredit);
                //}

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string sGLCode, string sSubAcct1, string sSubAcct2, string sSubAcct1_ID, string sSubAcct2_ID, string sEmployee, string sEmployee_ID, string sOtherCr, string sCategoryID, string Remarks, bool bIsCredit, decimal dAmount)
        {
            try
            {
                dgvDetail["accCode", iRow].Value = sGLCode;
                dgvDetail["accName", iRow].Value = clsGenaralName.getName_AccountName(sGLCode);
                dgvDetail["subAcc1", iRow].Value = sSubAcct1;
                dgvDetail["subAcc2", iRow].Value = sSubAcct2;
                dgvDetail["employee", iRow].Value = sEmployee;
                dgvDetail["otherCr", iRow].Value = sOtherCr;
                dgvDetail["CategoryID", iRow].Value = sCategoryID;
                dgvDetail["Remarks", iRow].Value = Remarks;
                dgvDetail["IsCredit", iRow].Value = bIsCredit;
                dgvDetail["LineNo", iRow].Value = iRow + 1;
                dgvDetail["Remarks", iRow].Value = Remarks;

                dgvDetail["subAcc1", iRow].Tag = sSubAcct1_ID;
                dgvDetail["subAcc2", iRow].Tag = sSubAcct2_ID;
                dgvDetail["employee", iRow].Tag = sEmployee_ID;

                if (bIsCredit)
                {
                    dgvDetail["creditAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["debitAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                else
                {
                    dgvDetail["debitAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["creditAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }

                dgvDetail.Columns["accName"].Width = 340;
                if (iRow >= 3)
                    dgvDetail.Columns["accName"].Width = 340 - 16;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        #region Refresh
        #region Refresh Grid By PRN
        private void RefreshGridByPRN()
        {
            //glb_dtSubTotal.Rows.Clear();
            //decimal dGrandTotal = txtGrandTotal.Text.Length > 0 ? decimal.Parse(txtGrandTotal.Text) : 0;
            //decimal dVat = txtVat.Text.Length > 0 ? decimal.Parse(txtVat.Text) : 0;
            //decimal dNBT = txtNBT.Text.Length > 0 ? decimal.Parse(txtNBT.Text) : 0;
            //decimal dDiscount = txtDiscount.Text.Length > 0 ? decimal.Parse(txtDiscount.Text) : 0;
            //decimal dSubTotal = txtSubTotal.Text.Length > 0 ? decimal.Parse(txtSubTotal.Text) : 0;

            //if (dVat > 0)//Vat
            //{
            //    tbl_zTax Tdetail = tbl_zTax.Select("TAX/001");
            //    if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
            //        FilldataTable(4, Tdetail.ReceivableGl_ID, dVat, "default", "default", "default", "default", TransactionCategory.VAT, "default", true);
            //}
            //if (dNBT > 0)//Nbt
            //{
            //    tbl_zTax Tdetail = tbl_zTax.Select("TAX/002");
            //    if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
            //        FilldataTable(2, Tdetail.ReceivableGl_ID, dNBT, "default", "default", "default", "default", TransactionCategory.NBT, "default", true);
            //}

            //if (dSubTotal > 0)//sub total
            //{
            //    string sGLCode = "";
            //    foreach (tbl_accDoubleEntrySlotDetails item in tbl_accDoubleEntrySlotDetails.SelectAllBySlot_ID(clsAutocode.getAccSlotID(AccSlot.Supplier_DebitNote)))
            //    {
            //        if (item.IsSubTotal)
            //            sGLCode = item.Gl_ID;
            //    }
            //    if (sGLCode.Length > 0 && sGLCode != "default")
            //        FilldataTable(1, sGLCode, dSubTotal, "default", "default", "default", "default", TransactionCategory.SubTotal, "default", true);//
            //}

            //if (dGrandTotal > 0)//grand total
            //{
            //    string sSupplierGLCode = clsMethods_GL.getAccountCode_Supplier(txtSupplierID.Tag.ToString().Trim()).Trim();
            //    if (sSupplierGLCode.Length > 0 && sSupplierGLCode != "default")
            //        FilldataTable(6, sSupplierGLCode, dGrandTotal, "default", "default", "default", "default", TransactionCategory.GrandTotal, txtSupplierID.Tag.ToString().Trim(), false);
            //}

            RefreshGrid();
            CalculateDebitTotalAmount();
        }
        #endregion
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sEmployee = "", sOtherCr = "", sCategoryID = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sRemarks = "";

                //  decimal dGrandTotal = 0, dSubTotal = 0, dVatTotal = 0, dNbtTotal = 0;
                if (glb_dtSubTotal != null)
                {
                    if (glb_dtSubTotal.Rows.Count > 0)
                    {
                        foreach (DataRow row in glb_dtSubTotal.Rows) //Credit Area
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            sGLCode = row["GLCode"].ToString();
                            sSubAcct1 = row["SubAcct1"].ToString();
                            sSubAcct2 = row["SubAcct2"].ToString();
                            sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                            sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                            sEmployee = row["Employee"].ToString();
                            sEmployee_ID = row["Employee_ID"].ToString();
                            sOtherCr = row["OtherCr"].ToString();
                            sCategoryID = row["CategoryID"].ToString();
                            decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                            Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                        }
                    }
                }
                if (glb_dtNBT != null)
                {
                    if (glb_dtNBT.Rows.Count > 0)
                    {
                        foreach (DataRow row in glb_dtNBT.Rows) //Credit Area
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            sGLCode = row["GLCode"].ToString();
                            sSubAcct1 = row["SubAcct1"].ToString();
                            sSubAcct2 = row["SubAcct2"].ToString();
                            sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                            sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                            sEmployee = row["Employee"].ToString();
                            sEmployee_ID = row["Employee_ID"].ToString();
                            sOtherCr = row["OtherCr"].ToString();
                            sCategoryID = row["CategoryID"].ToString();
                            decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                            Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                        }
                    }
                }
                if (glb_dtVAT != null)
                {
                    if (glb_dtVAT.Rows.Count > 0)
                    {
                        foreach (DataRow row in glb_dtVAT.Rows) //Credit Area
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            sGLCode = row["GLCode"].ToString();
                            sSubAcct1 = row["SubAcct1"].ToString();
                            sSubAcct2 = row["SubAcct2"].ToString();
                            sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                            sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                            sEmployee = row["Employee"].ToString();
                            sEmployee_ID = row["Employee_ID"].ToString();
                            sOtherCr = row["OtherCr"].ToString();
                            sCategoryID = row["CategoryID"].ToString();
                            decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                            Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                        }
                    }
                }
                if (glb_dtGrandTotal.Rows.Count > 0) //Debit Area
                {
                    foreach (DataRow row in glb_dtGrandTotal.Rows)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        sGLCode = row["GLCode"].ToString();
                        sSubAcct1 = row["SubAcct1"].ToString();
                        sSubAcct2 = row["SubAcct2"].ToString();
                        sSubAcct1_ID = row["SubAcct1_ID"].ToString();
                        sSubAcct2_ID = row["SubAcct2_ID"].ToString();
                        sEmployee = row["Employee"].ToString();
                        sEmployee_ID = row["Employee_ID"].ToString();
                        sOtherCr = row["OtherCr"].ToString();
                        //sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();
                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount);
                    }
                }
                formatPBX();
                CalculateBalance();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private string formatPBX()
        {
            string sCategoryID = "", sMessege = "";

            try
            {
                decimal dGrandTotal = 0, dSubTotal = 0, dVatTotal = 0, dNbtTotal = 0;
                if (glb_dtSubTotal != null)
                {
                    foreach (DataRow row in glb_dtSubTotal.Rows)
                    {
                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                        sCategoryID = row["CategoryID"].ToString();
                        if (Enum.IsDefined(typeof(TransactionCategory), int.Parse(sCategoryID)))
                        {
                            if ((TransactionCategory)int.Parse(sCategoryID) == TransactionCategory.GrandTotal)
                                dGrandTotal += dAmount;
                            if ((TransactionCategory)int.Parse(sCategoryID) == TransactionCategory.SubTotal)
                                dSubTotal += dAmount;
                            if ((TransactionCategory)int.Parse(sCategoryID) == TransactionCategory.NBT)
                                dNbtTotal += dAmount;
                            if ((TransactionCategory)int.Parse(sCategoryID) == TransactionCategory.VAT)
                                dVatTotal += dAmount;
                        }
                    }
                    if (!formatPBX(ref pbxSubTot, (decimal.Parse(txtSubTotal.Text.Trim()) == dSubTotal)))
                        sMessege += "\n Sub Total is not matching";
                    if (!formatPBX(ref pbxNBT, (decimal.Parse(txtNBT.Text.Trim()) == dNbtTotal)))
                        sMessege += "\n NBT is not matching";
                    if (!formatPBX(ref pbxVAT, (decimal.Parse(txtVat.Text.Trim()) == dVatTotal)))
                        sMessege += "\n VAT is not matching";
                    if (!formatPBX(ref pbxGrandTotal, (decimal.Parse(txtGrandTotal.Text.Trim()) == dGrandTotal)))
                        sMessege += "\n Grand Total is not matching";
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return sMessege;
        }

        private bool formatPBX(ref PictureBox pbx, bool isOk)
        {
            //if (isOk)
            //    pbx.Image = global::Digiteq.Properties.Resources.accept;
            //else
            //    pbx.Image = global::Digiteq.Properties.Resources.Stop;
            return isOk;
        }

        #endregion

        #region Create Data Table
        private void CreateDataTable()
        {
            glb_dtSubTotal = new DataTable();
            glb_dtSubTotal.Columns.Add("Line_No", typeof(int));
            glb_dtSubTotal.Columns.Add("GLCode", typeof(string));
            glb_dtSubTotal.Columns.Add("GLName", typeof(string));
            glb_dtSubTotal.Columns.Add("GLAmount", typeof(decimal));
            glb_dtSubTotal.Columns.Add("SubAcct1", typeof(string));
            glb_dtSubTotal.Columns.Add("SubAcct2", typeof(string));
            glb_dtSubTotal.Columns.Add("Employee", typeof(string));
            glb_dtSubTotal.Columns.Add("OtherCr", typeof(string));
            glb_dtSubTotal.Columns.Add("CategoryID", typeof(int));
            glb_dtSubTotal.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("Employee_ID", typeof(string));
            glb_dtSubTotal.Columns.Add("isCredit", typeof(string));

            glb_dtSubTotal_Temp = new DataTable();
            glb_dtSubTotal_Temp.Columns.Add("Line_No", typeof(int));
            glb_dtSubTotal_Temp.Columns.Add("GLCode", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("GLName", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("GLAmount", typeof(decimal));
            glb_dtSubTotal_Temp.Columns.Add("SubAcct1", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("SubAcct2", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("Employee", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("OtherCr", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("CategoryID", typeof(int));
            glb_dtSubTotal_Temp.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("Employee_ID", typeof(string));
            glb_dtSubTotal_Temp.Columns.Add("isCredit", typeof(string));

            glb_dtSubTotal_Temp2 = new DataTable();
            glb_dtSubTotal_Temp2.Columns.Add("Line_No", typeof(int));
            glb_dtSubTotal_Temp2.Columns.Add("GLCode", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("GLName", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("GLAmount", typeof(decimal));
            glb_dtSubTotal_Temp2.Columns.Add("SubAcct1", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("SubAcct2", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("Employee", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("OtherCr", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("CategoryID", typeof(int));
            glb_dtSubTotal_Temp2.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("Employee_ID", typeof(string));
            glb_dtSubTotal_Temp2.Columns.Add("isCredit", typeof(string));

            glb_dtGrandTotal = new DataTable();
            glb_dtGrandTotal.Columns.Add("Line_No", typeof(int));
            glb_dtGrandTotal.Columns.Add("GLCode", typeof(string));
            glb_dtGrandTotal.Columns.Add("GLName", typeof(string));
            glb_dtGrandTotal.Columns.Add("GLAmount", typeof(decimal));
            glb_dtGrandTotal.Columns.Add("SubAcct1", typeof(string));
            glb_dtGrandTotal.Columns.Add("SubAcct2", typeof(string));
            glb_dtGrandTotal.Columns.Add("Employee", typeof(string));
            glb_dtGrandTotal.Columns.Add("OtherCr", typeof(string));
            glb_dtGrandTotal.Columns.Add("CategoryID", typeof(int));
            glb_dtGrandTotal.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtGrandTotal.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtGrandTotal.Columns.Add("Employee_ID", typeof(string));
            glb_dtGrandTotal.Columns.Add("isCredit", typeof(string));

            glb_dtNBT = new DataTable();
            glb_dtNBT.Columns.Add("Line_No", typeof(int));
            glb_dtNBT.Columns.Add("GLCode", typeof(string));
            glb_dtNBT.Columns.Add("GLName", typeof(string));
            glb_dtNBT.Columns.Add("GLAmount", typeof(decimal));
            glb_dtNBT.Columns.Add("SubAcct1", typeof(string));
            glb_dtNBT.Columns.Add("SubAcct2", typeof(string));
            glb_dtNBT.Columns.Add("Employee", typeof(string));
            glb_dtNBT.Columns.Add("OtherCr", typeof(string));
            glb_dtNBT.Columns.Add("CategoryID", typeof(int));
            glb_dtNBT.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtNBT.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtNBT.Columns.Add("Employee_ID", typeof(string));
            glb_dtNBT.Columns.Add("isCredit", typeof(string));

            glb_dtVAT = new DataTable();
            glb_dtVAT.Columns.Add("Line_No", typeof(int));
            glb_dtVAT.Columns.Add("GLCode", typeof(string));
            glb_dtVAT.Columns.Add("GLName", typeof(string));
            glb_dtVAT.Columns.Add("GLAmount", typeof(decimal));
            glb_dtVAT.Columns.Add("SubAcct1", typeof(string));
            glb_dtVAT.Columns.Add("SubAcct2", typeof(string));
            glb_dtVAT.Columns.Add("Employee", typeof(string));
            glb_dtVAT.Columns.Add("OtherCr", typeof(string));
            glb_dtVAT.Columns.Add("CategoryID", typeof(int));
            glb_dtVAT.Columns.Add("SubAcct1_ID", typeof(string));
            glb_dtVAT.Columns.Add("SubAcct2_ID", typeof(string));
            glb_dtVAT.Columns.Add("Employee_ID", typeof(string));
            glb_dtVAT.Columns.Add("isCredit", typeof(string));
        }

        #endregion

        #region Events Other

        #region Events KeyDown
        private void txtDebitNoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtDebitNoteID_DoubleClick(null, null);
        }
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCurrencyID_DoubleClick(sender, e);
        }
        private void txtPRNNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtPRNNo_DoubleClick(sender, e);
        }
        private void txtSPRNNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtSRNNo_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtPRNNo_DoubleClick(object sender, EventArgs e)
        {
            #region Removed -2015/12/08
            /* if (rdoReturnGoods.Checked)
              {
                  clsSearch.Search_TransactionPurchaseReturnNote_Direct(ref txtPRNNo, (txtSupplierID.Tag) != null ? txtSupplierID.Tag.ToString() : "", false);
                  if (txtPRNNo.Tag != null && txtPRNNo.Tag.ToString().Trim().Length > 0)
                      FillDetailsPRN(txtPRNNo.Tag.ToString());
              }
              else
              {
                  if (txtSupplierID.Tag != null)
                      clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, txtSupplierID.Tag.ToString());
                  else
                      clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false);
                  if (txtPRNNo.Tag != null && CheckValidateDuplicateAPNNo(txtPRNNo.Tag.ToString()))
                  {
                      FillDetailsAPN(txtPRNNo.Tag.ToString());
                  }
              }
              */

            #endregion

            #region For APN Ajustment
            if (!rdoReturnGoods.Checked)
            {
                if (txtSupplierID.Tag != null)
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, txtSupplierID.Tag.ToString(), "", false, false, false, true);
                else
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, "", "", false, false, false, true);
                if (txtPRNNo.Tag != null && CheckValidateDuplicateAPNNo(txtPRNNo.Tag.ToString()))
                {
                    FillDetailsAPN(txtPRNNo.Tag.ToString());
                }

                UpdateApnTotal();
                //CalcualteTotalAmount();
                //CalculateTaxesAndSubTotal();
                RefreshGridByPRN();
            }
            #endregion

            #region For Return Good Ajustment
            else
            {

                if (clsValidate.ValidateTextBox_EmptyValue(txtSPRNNo, "Supplier Name"))
                {
                    if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Length > 0)
                        clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, txtSupplierID.Tag.ToString(), "", false, false, false, true);
                    else
                        clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtPRNNo, false, "", "", false, false, false, true);
                    if (txtPRNNo.Tag != null && CheckValidateDuplicateAPNNo(txtPRNNo.Tag.ToString()))
                    {
                        tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(txtPRNNo.Tag.ToString());
                        if (detail != null)
                        {
                            dgvAPN.Rows.Add(detail.AccountPayableNote_ID, clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate), clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal - detail.SettledAmount));
                        }
                    }
                }
            }
            #endregion
        }
        private void txtDebitNoteID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_Transaction_AccDebitNote_New(ref txtDebitNoteID, chkShowSettle.Checked);
                if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDebitNoteID.Tag.ToString());
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
                clearSubGLCodeExceptThis("Supplier");
                Search_Supplier();
            }
        }
        private void txtSRNNo_DoubleClick(object sender, EventArgs e)
        {
            if (rdoReturnGoods.Checked)
            {
                try
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier Name"))
                        clsSearch.Search_TransactionPurchaseReturnNote_New(ref txtSPRNNo, txtSupplierID.Tag.ToString(), false);

                    if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                    {
                        FillDetailsPRN(txtSPRNNo.Tag.ToString().Trim());

                        //CalculateTaxesAndSubTotal();
                        RefreshGridByPRN();
                        /*tbl_scsPurchaseReturnedNote oSPRN = tbl_scsPurchaseReturnedNote.Select(txtSPRNNo.Tag.ToString());
                        if (oSPRN != null && oSPRN.PurchaseReturnedNote_ID != "default")
                        {
                           // txtTotalAmount.Text = oSPRN.SubTotal.ToString();
                            FillDetailsPRN(string sID);
                        }*/
                    }

                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Change DBN Type to Return Goods ........!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Events CheckedChanged
        private void rdoAPNAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAPNAdjustment.Checked)
                lblAPNNo.Text = "APN No";
            else
                lblAPNNo.Text = "PRN No";
        }
        #endregion

        #region Events CellEndEdit
        private void dgvAPN_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (rdoAPNAdjustment.Checked)
            {
                CalcualteTotalAmount();
                CalculateTaxesAndSubTotal();
                RefreshGridByPRN();
            }
            else
            {
                //try
                //{
                //    dgvAPN.Rows[e.RowIndex].Tag = true;
                //}
                //catch (Exception ex)
                //{ }
            }
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
            }
            else
                Clear_Discount();

            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                txtPercentageNBT.Enabled = true;
            }
            else
                Clear_NBT();

            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                txtPercentageVat.Enabled = true;
                Clear_SVat();
            }
            else
                Clear_Vat();

            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                txtPercentageOtherTax.Enabled = true;
                Clear_Vat();
            }
            else
                Clear_SVat();

            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        #endregion

        #region Events Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }

        private void txtPercentageNBT_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void txtPercentageVat_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void txtPercentageOtherTax_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        private void txtPercentageDiscount_Leave(object sender, EventArgs e)
        {
            CalculateTaxesAndSubTotal();
            RefreshGridByPRN();
        }
        #endregion

        #endregion

        #region Search Methods
        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurCode);
            if (txtCurCode.Tag != null)
                FillDetailsCurrency(txtCurCode.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        private void Search_Supplier()
        {
            try
            {
                clsSearch.Search_MasterSupplier(ref txtSupplierID);
                if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                {
                    string sGLCode = clsMethods_GL.getAccountCode_Supplier(txtSupplierID.Tag.ToString().Trim());
                    tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());

                    if (osup != null)
                        RefreshGrid();
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidityAPN()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtPRNNo.TextLength == 0)
                {
                    strMessage += "\n" + "APN No ";
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
        private bool CheckValidity_GrandTotalVsDebit()
        {
            bool bStatus = true;

            try
            {
                //if (decimal.Parse(txtDebitAmount.Text) !=  decimal.Parse(txtGrandTotal.Text))
                //if (decimal.Parse(txtDebitAmount.Text) != clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate))
                //if (decimal.Parse(txtDebitAmount.Text) != clsHelpMethods.getSavePrice(decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(txtGrandTotal.Text.Trim()))), txtCurrencyRate))
                //if (decimal.Parse(txtDebitAmount.Text) != decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate))))
                if (txtDebitAmount.Text != clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate)))
                    bStatus = false;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show("Debit Amount Not Matched With Grand Total.......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
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
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                if (glb_dtSubTotal != null)
                {
                    if (decimal.Parse(txtSubTotal.Text.Trim()) > 0 && glb_dtSubTotal.Rows.Count == 0)
                    {
                        strMessage += "\n Please Enter GL Codes for Sub Totals";
                        bStatus = false;
                    }
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
        private bool CheskDoubleEntryValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (decimal.Parse(txtBalanceAmount.Text.Trim()) != 0)
                {
                    strMessage += "\n Please check GL Debit / Credit Amount..";
                    bStatus = false;
                }
                else
                {
                    //strMessage = formatPBX();
                    //if (strMessage.Trim().Length > 0)
                    //    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckApnAmountValidity()
        {
            bool bIsOk = true;
            try
            {
                decimal dTemp = 0;
                foreach (DataGridViewRow row in dgvAPN.Rows)
                {
                    string sDgvApnNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                    decimal dDgvApnAmount = clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, dTemp);
                    decimal dOldSettlementAmmount = 0;

                    if (sDgvApnNo.Length > 0)
                    {
                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sDgvApnNo);
                        if (oAPN != null && oAPN.AccountPayableNote_ID != "default")
                        {
                            #region Insert
                            if (!IsUpdate)
                            {
                            }
                            #endregion
                            #region Update
                            else
                            {
                                foreach (tbl_accPaymentVoucher_Detail oPVD in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(txtDebitNoteID.Text.Trim()))
                                {
                                    if (oPVD.AccountPayableNote_ID == sDgvApnNo)
                                    {
                                        dOldSettlementAmmount = oPVD.SettleAmount;
                                    }
                                }
                            }
                            #endregion

                            if ((oAPN.GrandTotal - oAPN.SettledAmount + dOldSettlementAmmount) < dDgvApnAmount)
                            {
                                bIsOk = false;
                                MessageBox.Show("Settlement Note Amount Cannot be Greater than APN  <<" + sDgvApnNo + ">>" + " Outstanding ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
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

            return bIsOk;

        }
        private bool CheckValidity_PRNAmount()
        {
            bool bIsValid = true;
            try
            {
                decimal dPrnGrandTotal = decimal.Parse(txtGrandTotal.Text.ToString());
                if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                {
                    tbl_scsPurchaseReturnedNote OPRN = tbl_scsPurchaseReturnedNote.Select(txtSPRNNo.Tag.ToString());
                    if (OPRN != null && OPRN.PurchaseReturnedNote_ID != "default")
                    {
                        #region Update
                        if (IsUpdate)
                        {
                            //  decimal dSettleAmount = 0;


                        }
                        #endregion
                        #region Insert

                        else
                        {
                            //if (dPrnGrandTotal > (OPRN.GrandTotal - OPRN.SeattleAmount))
                            //{
                            //    bIsValid = false;
                            //    MessageBox.Show("Debit Amount must be less than or equal to PRN Amount....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}

                            decimal dUnSettledAmount = decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(OPRN.GrandTotal - OPRN.SeattleAmount));
                            if (dPrnGrandTotal > dUnSettledAmount)
                            {
                                bIsValid = false;
                                MessageBox.Show("Debit Amount must be less than or equal to PRN Amount....! ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        #endregion
                    }

                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bIsValid;
        }
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValiditySubTotal())
            {
                if (CheckDataTableValidity())
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckValidity_GrandTotalVsDebit())
                        {
                            if (CheskDoubleEntryValidity())
                            {
                                if (CheckApnAmountValidity())
                                {
                                    if (CheckValidity_PRNAmount())
                                    {
                                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                                            bIsOk = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bIsOk;
        }
        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtPRNNo);
                clsCommon.ValidateForeignKey(ref txtSupplierID);


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

                //if (txtCreditDays.Text.Trim().Length == 0)
                //    txtCreditDays.Text = "0";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        private bool CheckValidateDuplicateAPNNo(string sAPNNo)
        {
            bool bIsOk = true;
            foreach (DataGridViewRow r in dgvAPN.Rows)
            {
                if (r.Cells["APNCode"].Value.ToString() == sAPNNo)
                {
                    bIsOk = false;
                    break;
                }
            }
            return bIsOk;
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicate = "";
                string sCreateUserAndDate = "", sCheckedUserAndDate = "", sApprovedUserAndDate = "";
                if (txtDebitNoteID.Text.Trim().Length > 0 && txtDebitNoteID.Text.Trim() != "<Auto Generate>")
                {
                    #region Using Dataset
                    Cursor = Cursors.WaitCursor;
                    glb_dts_DebitNote.Clear();
                    bool bPermissinOkToPrint = true;

                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_AccountDebitNote));
                    if (bPermissinOkToPrint)
                    {
                        tbl_accDebitNote oDebit = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                        if (oDebit != null && oDebit.DebitNote_ID != "default")
                        {
                            //sCreateUserAndDate = oDebit.CreateUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.CreateUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateCreate) : "";
                            //sApprovedUserAndDate = oDebit.ApprovedUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.ApprovedUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateApproved) : "";
                            //sCheckedUserAndDate = oDebit.CheckedUser_ID.Length > 0 ? clsGenaralName.getName_User(oDebit.CheckedUser_ID) + " - " + clsFormatter.FormatDate_Short(oDebit.DateChecked) : "";

                            sCreateUserAndDate = oDebit.CreateUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.CreateUser_ID) + " ] [ " + clsFormatter.FormatDate_SL2(oDebit.DateCreate) + "]" : "" ;
                            sApprovedUserAndDate = oDebit.ApprovedUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.ApprovedUser_ID) + " ] [ " + clsFormatter.FormatDate_SL2(oDebit.DateApproved) + "]" : "" ;
                            sCheckedUserAndDate = oDebit.CheckedUser_ID.Length > 0 ? "[ " + clsGenaralName.getName_User(oDebit.CheckedUser_ID) + " ] [ " + clsFormatter.FormatDate_SL2(oDebit.DateChecked) + "]" : "" ;

                            if (!bIsDraft)
                            {
                                //if (oDebit.PrintCount > 0)
                                //    sDuplicate = "Duplicate Copy" + oDebit.PrintCount;

                                if (!chkPrintOriginal.Checked)
                                    sDuplicate = (oDebit.PrintCount > 0) ? "Duplicate Copy " + oDebit.PrintCount : "";

                                oDebit.PrintCount++;
                                oDebit.Update();
                            }

                            glb_dts_DebitNote.dt_acc_DebitNote.Adddt_acc_DebitNoteRow(oDebit.DebitNote_ID, oDebit.DebitNote_Date, clsGenaralName.getName_Supplier(oDebit.Supplier_ID), clsGenaralName.getSupplierAddressRegister(oDebit.Supplier_ID)
                                , oDebit.Remarks, oDebit.DiscountPercentage, oDebit.NbtPercentage, oDebit.SubTotal, oDebit.VatPercentage, oDebit.DiscountTotal, oDebit.NbtTotal, oDebit.VatTotal, oDebit.GrandTotal, oDebit.Currency_ID, oDebit.CurrencyRate, oDebit.Invoice_ID, "", DateTime.MinValue, "", 0, "", "", DateTime.MinValue, 0, oDebit.IsDeleted);

                            #region APN
                            if (oDebit.AccountPayableNote_ID != "default")
                            {
                                foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                                {
                                    DateTime dtAPNDate;
                                    if (detail.AccountPayableNote_ID != "default")
                                    {
                                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(detail.AccountPayableNote_ID);
                                        if (oAPN != null)
                                            dtAPNDate = oAPN.AccountPayableNoteDate;
                                        else
                                            dtAPNDate = DateTime.MinValue;
                                        glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.AccountPayableNote_ID, dtAPNDate, detail.SettleAmount, true);

                                    }
                                    //else if (detail.PurchaseReturnedNote_ID != "default")
                                    //{
                                    //    tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(detail.PurchaseReturnedNote_ID);
                                    //    if (oPRN != null)
                                    //        dtAPNDate = oPRN.PurchaseReturnedNoteDate;
                                    //    else
                                    //        dtAPNDate = DateTime.MinValue;
                                    //    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(detail.DebitNote_ID, detail.PurchaseReturnedNote_ID, dtAPNDate, detail.SettledAmount);
                                    //}
                                }
                            }
                            #endregion

                            #region PRN
                            else if (oDebit.PurchaseReturnedNote_ID != "default")
                            {
                                tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(oDebit.PurchaseReturnedNote_ID);
                                if (oPRN != null)
                                    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(oDebit.DebitNote_ID, oDebit.PurchaseReturnedNote_ID, oPRN.PurchaseReturnedNoteDate, oPRN.SeattleAmount, false);
                            }
                            #endregion

                            #region Others
                            else
                            {
                                foreach (tbl_accDebitNote_SubTotal oDBNSub in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                                {
                                    glb_dts_DebitNote.dt_acc_DebitNote_Detail.Adddt_acc_DebitNote_DetailRow(oDebit.DebitNote_ID, "default", DateTime.Now, oDebit.SettledAmount, false);
                                }
                            }
                            #endregion

                            #region GL Detalls
                            foreach (tbl_accDebitNote_SubTotal oDBN_SubTotal in tbl_accDebitNote_SubTotal.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                            {
                                decimal dCreditVal = 0, dDebetVal = 0;
                                dCreditVal = 0;
                                dDebetVal = 0;
                                if (oDBN_SubTotal.IsCredi)
                                    dCreditVal = oDBN_SubTotal.Amount;
                                else
                                    dDebetVal = oDBN_SubTotal.Amount;

                                glb_dts_DebitNote.dt_acc_DoubleEntry.Adddt_acc_DoubleEntryRow(oDebit.DebitNote_ID, oDBN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oDBN_SubTotal.Gl_ID), "", clsGenaralName.getName_AccCostCenter1(oDBN_SubTotal.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(oDBN_SubTotal.CostCenter2_ID), oDBN_SubTotal.Amount, oDBN_SubTotal.IsCredi, "");
                            }
                            #endregion

                            #region PO / GRN Detail
                            foreach (tbl_accPaymentVoucher_Detail PVdetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDebit.DebitNote_ID))
                            {
                                List<tbl_accAccountPayableNote_Allocation> oAllDetail = tbl_accAccountPayableNote_Allocation.SelectAll().Where(p => p.AccountPayableNote_ID == PVdetail.AccountPayableNote_ID).ToList();
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
                                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(PVdetail.AccountPayableNote_ID);
                                    if (oGRN != null && oPO != null && oAPN != null)
                                    {
                                        glb_dts_DebitNote.dt_GrnDetail.Adddt_GrnDetailRow(PVdetail.AccountPayableNote_ID, oAPN.AccountPayableNoteDate, oPO.PurchaseOrderDate, sPOID, oGRN.ExternalGoodReceivedNoteDate, oGRN.ExternalGoodReceivedNote_ID, "", oPO.GrandTotal, oGRNAllocation.SettledAmount, oGRNAllocation.SettledAmount);

                                    }
                                }

                                //if(oAllDetail.Count == 0)
                                //    glb_dts_DebitNote.dt_GrnDetail.Adddt_GrnDetailRow("", DateTime.MinValue, "", DateTime.MinValue, "", "", 0, 0, 0);
                            }
                            #endregion

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

                            glb_dts_DebitNote.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "SUPPLIER DEBIT NOTE", "", "", clsSecurity.UserNameLoged, "");

                            #endregion


                        }
                        string s_Path = "";
                        string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_AccountDebitNote));

                        if (sGetRptPath != null && sGetRptPath.Length > 0)
                            s_Path = sGetRptPath;
                        else
                        {
                            s_Path = "\\Reports\\ACC\\NotePrinting\\rpt_accDebitNotes.rpt";
                        }

                        print(s_Path, " Debit Note ", glb_dts_DebitNote, sCreateUserAndDate, sCheckedUserAndDate, sApprovedUserAndDate, sDuplicate, oDebit.IsDeleted, bIsDraft, clsAutocode.getReportID(enum_ReportName.NP_AccountDebitNote));
                        
                    }
                    #endregion
                }
                else
                    MessageBox.Show("Please Select the Debit Note To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Set Disable Control
        private void SetDisableControl(bool bEnable)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDebitNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblDebitNoteID, bEnable);
            clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, bEnable);
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sCreateUserNameAndDate, string sChekcedUserNameAndDate, string sApprovedUserNameAndDate, string sDuplicate, bool isCancel, bool bIsDraft, string sReportID)
        {
            try
            {
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", isCancel ? "CANCELLED" : "", true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);

                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUserNameAndDate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sChekcedUserNameAndDate, true,false);
                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUserNameAndDate, true,false);

                if (bIsDraft)
                {
                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                    }
                }

                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);
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

        //private void print(string path, string sReportTitle, DataSet ojbDataSet, string sCreateUserNameAndDate, string sChekcedUserNameAndDate, string sApprovedUserNameAndDate, bool isDuplicate, bool isCancel)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "";// sHeaderTitle = "Standed Reports", sReportFilter = "";
        //        ReportDocument objRpt = new ReportDocument();

        //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //        s_Path += path;

        //        objRpt.Load(s_Path);
        //        objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

        //        objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //        objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //        objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUserNameAndDate);
        //        objRpt.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sChekcedUserNameAndDate);
        //        objRpt.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUserNameAndDate);
        //        if (isCancel)
        //            objRpt.DataDefinition.FormulaFields["Cancel"].Text = clsCommon.fncsetstring("Canceled");
        //        if (isDuplicate)
        //            objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

        //        frm_ReportViewer ReportViewer = new frm_ReportViewer();
        //        ReportViewer.crystalReportViewer1.ReportSource = objRpt;
        //        ReportViewer.crystalReportViewer1.Refresh();
        //        ReportViewer.crystalReportViewer1.DisplayToolbar = true;
        //        ReportViewer.crystalReportViewer1.CloseView(false);
        //        ReportViewer.WindowState = FormWindowState.Maximized;
        //        ReportViewer.ShowDialog();

        //        objRpt.Close();
        //        objRpt.Dispose();
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //    }
        //    finally
        //    {
        //        Cursor = Cursors.Default;
        //    }
        //}
        #endregion

        private void UpdateApnTotal()
        {
            Decimal dAmount = 0;
            int iApnCount = 0;
            foreach (DataGridViewRow row in dgvAPN.Rows)
            {
                iApnCount++;
                dAmount += decimal.Parse(clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, "0.00"));
            }
            if (iApnCount > 0)
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, false);

            txtTotalAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dAmount);
        }

        private void CalculateSubTotal()
        {
            try
            {
                decimal dTotAmount = 0;
                foreach (DataRow row in glb_dtSubTotal.Rows)
                {
                    decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                    dTotAmount += dAmount;
                }
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dTotAmount, dExRate));
                txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(dTotAmount, dExRate));
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }

        #region Calcualte Total Amount
        private void CalcualteTotalAmount()
        {
            try
            {
                decimal Amount = 0;
                for (int i = 0; i < dgvAPN.Rows.Count; i++)
                {
                    string s = dgvAPN["APNAmount", i].Value.ToString();
                    if (dgvAPN["APNAmount", i].Value != null && dgvAPN["APNAmount", i].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvAPN["APNAmount", i].Value.ToString()))
                            Amount += decimal.Parse(dgvAPN["APNAmount", i].Value.ToString());
                    }
                }
                txtTotalAmount.Text = Amount.ToString();
                txtTotalAmount.Tag = Amount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }

        private void CalculateTaxesAndSubTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));

            //decimal dGrandTotal = 0, dDiscount = 0, dAmountWithNBT = 0, dAmountNBT = 0, dAmountVat = 0, dSubTotal = 0;

            //decimal dPercentageVat = chkVat.Checked ? (txtPercentageVat.Text.Length > 0 ? decimal.Parse(txtPercentageVat.Text) : 0) : 0;
            //decimal dPercentageNBT = chkNBT.Checked ? (txtPercentageNBT.Text.Length > 0 ? decimal.Parse(txtPercentageNBT.Text) : 0) : 0;
            //decimal dPercentageSVat = chkOtherTax.Checked ? (txtPercentageOtherTax.Text.Length > 0 ? decimal.Parse(txtPercentageOtherTax.Text) : 0) : 0;

            //dGrandTotal = txtTotalAmount.Text.Length > 0 ? decimal.Parse(txtTotalAmount.Text) : 0;

            //dDiscount = dGrandTotal * (txtPercentageDiscount.Text.Length > 0 ? decimal.Parse(txtPercentageDiscount.Text) : 0) / 100;
            //dGrandTotal -= dDiscount;

            //clsHelpMethods.SetVATandNBTValues_FromGrandTotal(dGrandTotal, dPercentageVat, dPercentageNBT, ref dAmountWithNBT, ref dSubTotal, ref dAmountNBT, ref dAmountVat);

            //txtGrandTotal.Text = clsFormatter.FormatDecimalPlaces_Price(dGrandTotal);
            //txtDiscount.Text = clsFormatter.FormatDecimalPlaces_Price(dDiscount);
            //txtSubTotal.Text = clsFormatter.FormatDecimalPlaces_Price(dSubTotal);
            //txtNBT.Text = clsFormatter.FormatDecimalPlaces_Price(dAmountNBT);
            //txtVat.Text = clsFormatter.FormatDecimalPlaces_Price(dAmountVat);
            //txtOtherTax.Text = clsFormatter.FormatDecimalPlaces_Price(dGrandTotal * dPercentageSVat / 100);
        }
        #region Calculate Credit Debit Amounts
        private void CalculateBalance()
        {
            decimal dCredit = 0, dDebit = 0, dAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dCredit += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                dDebit += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
            }
            dAmount = dCredit - dDebit;

            // txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit);
            txtCreditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCredit);
            txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit);
            txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
        }
        #endregion
        private void CalculateDebitTotalAmount()
        {
            decimal dCreditAmu = 0, dDebitAmu = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dCreditAmu += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, 0m);
                dDebitAmu += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, 0m);
            }

            txtCreditAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dCreditAmu);
            txtDebitAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dDebitAmu);
            txtBalanceAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dCreditAmu - dDebitAmu);
        }
        #endregion

        #region Fill Detail GL Code
        private void FillDetailGLCodesAPN(string sAPN_ID)
        {
            try
            {
                glb_dtSubTotal.Rows.Clear();
                glb_dtNBT.Rows.Clear();
                glb_dtVAT.Rows.Clear();
                glb_dtGrandTotal.Rows.Clear();
                List<tbl_accAccountPayableNote_SubTotal> details = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(sAPN_ID);
                foreach (tbl_accAccountPayableNote_SubTotal detail in details)
                {
                    #region Fill
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal).ToString()) //Credit Area - Reverse Of the APN
                    {
                        glb_dtGrandTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, true);
                        clsEvent.GLCode_TextChanged(pbxGrandTotal, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal).ToString()) //Debit Area - Reverse Of the APN
                    {
                        glb_dtSubTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, false);
                        clsEvent.GLCode_TextChanged(pbxSubTot, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT).ToString()) //Debit Area - Reverse Of the APN
                    {
                        glb_dtNBT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, false);
                        clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT).ToString()) //Debit Area - Reverse Of the APN
                    {
                        glb_dtVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, false);
                        clsEvent.GLCode_TextChanged(pbxVAT, "Accept");
                    }

                    //else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT).ToString())
                    //{
                    //    glb_dtNBT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                    //        clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                    //        , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                    //    clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                    //}
                    //else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT).ToString())
                    //{
                    //    glb_dtVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                    //        clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                    //        , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                    //    clsEvent.GLCode_TextChanged(pbxVat, "Accept");
                    //}
                    //else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT).ToString())
                    //{
                    //    glb_dtSVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                    //        clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT)
                    //        , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                    //    clsEvent.GLCode_TextChanged(pbxSVat, "Accept");
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void txtGrandTotal_TextChanged(object sender, EventArgs e)
        {
            formatPBX();
        }

        #region Button Allocation
        private void btnallocattion_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                if (rdoReturnGoods.Checked)
                {
                    #region Settle DBN With APN
                    if (txtSPRNNo.Tag != null && txtSPRNNo.Tag.ToString().Length > 0)
                    {
                        if (txtDebitNoteID.Tag != null && txtDebitNoteID.Tag.ToString().Length > 0)
                        {

                            try
                            {
                                tbl_accDebitNote oDBN = tbl_accDebitNote.Select(txtDebitNoteID.Tag.ToString());
                                tbl_scsPurchaseReturnedNote oPRN = tbl_scsPurchaseReturnedNote.Select(txtSPRNNo.Tag.ToString());

                                if ((oPRN != null && oPRN.PurchaseReturnedNote_ID != "default") && (oDBN != null && oDBN.DebitNote_ID != "default"))
                                {
                                    string sTempApnNO = "";
                                    decimal dAllocatedAmount = 0;
                                    bool bIsEnoughDbnAmountToSettledApn = true;
                                    foreach (DataGridViewRow row in dgvAPN.Rows)
                                    {
                                        string sApnNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "");
                                        decimal dApnAmountTobeSettle = clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, decimal.Parse("0.00"));

                                        if (clsHelpMethods.RemoveSattlementsFrom_DebitNoteWithAPN("default", sApnNo, "default", oDBN.DebitNote_ID, "default"))
                                        {
                                            dAllocatedAmount += clsHelpMethods.AutoSettleDebitNoteWithAPN(sApnNo, oDBN.DebitNote_ID, DateTime.Now.Date, dApnAmountTobeSettle, "", row.Index + 1, ref bIsEnoughDbnAmountToSettledApn);
                                            sTempApnNO += dAllocatedAmount > 0 ? sApnNo + " , " : "";
                                            if (!bIsEnoughDbnAmountToSettledApn)//To stop The operation When DBN Amount lesthan APN to be Settled amount.
                                                break;
                                        }
                                    }
                                    if (dAllocatedAmount > 0)
                                        MessageBox.Show("PRN No-" + "<<" + txtSPRNNo.Tag.ToString() + ">>" + "Successfully Settled With" + "This APN" + "<<" + sTempApnNO + ">>", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }

                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", iFormID, ex);
                                SEACCException.Show(ex);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please Select Debit Note To Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Select PRN To Settle......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                else
                    MessageBox.Show("Please check the Return good Redio Button......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Please Save Note Before Settle the Note......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
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

                                        tbl_accDebitNote objDO = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsApproved = true;
                                            objDO.DateApproved = clsSecurity.getServerDateTime();
                                            objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDO.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (txtDebitNoteID.Text != null && txtDebitNoteID.TextLength > 0 && txtDebitNoteID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDabitNoteDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
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

                                        tbl_accDebitNote objDO = tbl_accDebitNote.Select(txtDebitNoteID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsChecked = true;
                                            objDO.DateChecked = clsSecurity.getServerDateTime();
                                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDO.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }

                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (txtDebitNoteID.Text != "" || txtDebitNoteID.Text != "<Auto Generate>")
                {
                    tbl_accDebitNote detail = tbl_accDebitNote.Select(txtDebitNoteID.Text);
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
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion
        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            xSetting.Visible = true;
            xSetting.Focus();
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        #endregion



    }
}