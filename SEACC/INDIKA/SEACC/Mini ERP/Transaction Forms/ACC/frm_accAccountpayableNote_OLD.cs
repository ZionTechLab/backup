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
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets;
//using Zion.ERP.Reports.DataSets.ACC;
using ZION.ERP.Reports.DataSets.ACC;
using ZION.ERP.Reports.DataSets;
namespace Digiteq
{
    public partial class frm_accAccountpayableNote_OLD : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;
        //static bool IsUpdateMaterial = false;

        //form manage
        //string sFormConfigCode;
        //public     int iFormID;
        string s_FileName = "", CusSupEmpCode = "default";
        public static string glbJobID = "";
        public string glbAPNID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        public bool bHasCostingConfrimed;
        public bool bHasConfirmed;
        public bool isAutoFill = false;

        public decimal dExRate = 0;
        clsAlerts_Email email = new clsAlerts_Email();
        DateTime glbCostingConfirmedDate = clsSecurity.getServerDateTime();
        //    DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbConfirmedDate = clsSecurity.getServerDateTime();
        dts_Sales glb_dtsSales = new dts_Sales();
        dts_Apn glb_dts_Apn = new dts_Apn();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //for subTotal
        DataTable glb_dtSubTotal;
        DataTable glb_dtNBT;
        DataTable glb_dtVAT;
        DataTable glb_dtSVAT;
        DataTable glb_dtGrandTotal;

       

        #region Form Load
        public frm_accAccountpayableNote_OLD(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accAccountpayableNote);
            //iFormID = clsSecurity.getFormID(FormName.accAccountpayableNote);            
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frm_accAccountpayableNote_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);

            //clsFormatter.setFormatForm(this, "Account Payable Note", 6, iFormID);            
            //CreateDataTable();
            CreateDataTable(TransactionCategory.SubTotal);
            CreateDataTable(TransactionCategory.NBT);
            CreateDataTable(TransactionCategory.VAT);
            CreateDataTable(TransactionCategory.SVAT);
            CreateDataTable(TransactionCategory.GrandTotal);

            ClearFields();
            CusDataGridViewFormat();
            if (glbAPNID.Length > 0)
                FillDetails(glbAPNID);
        }
        #endregion

        #region Btn New
        private void frm_accAccountpayableNote_OLD_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_accAccountpayableNote_OLD_SF_cancelButton_Click(object sender, EventArgs e)
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
                                if (detail != null)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsReturnCheque)
                                        {
                                            if (!detail.IsDeleted)
                                            {
                                                //  if (clsValidate.CheckAccountPostingValidity(detail.AccountPayableNote_ID))
                                                // {
                                                //delete one record
                                                Cursor = Cursors.WaitCursor;
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, "  Account Payable Note : " + txtAPNID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    //detail.IsDeleted = true;
                                                    detail.IsDeleted = true;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();
                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();

                                                    //tbl_accGLPosting_Tmp tempHead = tbl_accGLPosting_Tmp.Select(detail.GlPosting_ID);
                                                    //if (tempHead != null)
                                                    //{
                                                    //    foreach (tbl_accGLPosting_Detail_Tmp postingTempDetail in tbl_accGLPosting_Detail_Tmp.SelectAllByGlPosting_ID(tempHead.GlPosting_ID))
                                                    //    {
                                                    //        postingTempDetail.Delete();
                                                    //    }
                                                    //    tempHead.Delete();
                                                    //}
                                                    // tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(detail.GlPosting_ID);

                                                    clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                                    clsHelpMethods_Local.RemovePVSattlementsFrom_APNID(detail.AccountPayableNote_ID);

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
                                                    tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                                                    if (oGRN != null && oGRN.ExternalGoodReceivedNote_ID != "default")
                                                    {
                                                        oGRN.SeattleAmount = oGRN.SeattleAmount - detail.GrandTotal;
                                                        oGRN.IsSeattled = false;
                                                        oGRN.Update();
                                                    }
                                                    #endregion

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                    email.createEmail_APN(detail.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteDeleted);
                                                }
                                                //}
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void frm_accAccountpayableNote_OLD_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    decimal dSettleAmount = 0;

                    #region update records
                    if (IsUpdate)
                    {
                        tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && !oldRecord.IsReturnCheque)// && clsValidate.CheckAccountPostingValidity(oldRecord.AccountPayableNote_ID))
                            {
                                if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text))
                                    {

                                        //tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                        // tbl_accGLPosting_Detail_Tmp.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                        clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);

                                        dSettleAmount = 0;

                                        #region Update tbl_accAccountPayableNote & tbl_accAccountPayableNote_SubTotal

                                        foreach (tbl_accAccountPayableNote_SubTotal APNdetail in
                                            tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(
                                                txtAPNID.Text.ToString()))
                                        {
                                            int iRow = 0;
                                            string sGLCode = "",
                                                sSubAcct1 = "",
                                                sSubAcct2 = "",
                                                sSubAcct1_ID = "",
                                                sSubAcct2_ID = "",
                                                sEmployee_ID = "",
                                                sOtherCr = "",
                                                sCategoryID = "",
                                                sRemarks = ""; //sEmployee = "",
                                            bool bIsCredit = false;
                                            decimal dAmount = 0;
                                            bool bHasItemInDB = false;


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
                                                sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee",
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

                                                if (iRow == APNdetail.Line_No &&
                                                    APNdetail.AccountPayableNote_ID == txtAPNID.Text.Trim() &&
                                                    sCategoryID == APNdetail.Tc_ID && sGLCode == APNdetail.Gl_ID)
                                                {
                                                    bHasItemInDB = true;
                                                    dgvDetail.Rows.RemoveAt(row.Index);
                                                    break; //database contain this item
                                                }
                                            }

                                            if (bHasItemInDB)
                                            {
                                                APNdetail.Line_No = iRow;
                                                APNdetail.Gl_ID = sGLCode;
                                                APNdetail.CostCenter1_ID = sSubAcct1_ID;
                                                APNdetail.CostCenter2_ID = sSubAcct2_ID;
                                                APNdetail.Employee_ID = sEmployee_ID;
                                                APNdetail.Customer_ID = sOtherCr;
                                                APNdetail.Tc_ID = sCategoryID;
                                                APNdetail.Amount = dAmount;
                                                //PVdetail.Remarks = sRemarks;
                                                APNdetail.Update();

                                                //#region GL Posting Detail
                                                //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.AccountPayableNote), txtAPNID.Text.Trim(), sGLCode,
                                                //                sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtAPNID.Text.Trim(), "default",
                                                //            dtpBillDate.Value, txtNarration.Text.Trim(), dAmount, bIsCredit, "", clsGenaralName.getName_Supplier(oldRecord.Supplier_ID));
                                                //#endregion
                                            }
                                            else
                                            {
                                                // clsProcessMethods.GLPostingDetailTempDelete(APNdetail.Line_No, oldRecord.GlPosting_ID);
                                                APNdetail.Delete();
                                            }
                                        }

                                        #endregion

                                        #region  Insert Detail - APN Details

                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                        {
                                            int iRow;
                                            string sGLCode = "",
                                                sSubAcct1 = "",
                                                sSubAcct2 = "",
                                                sSubAcct1_ID = "",
                                                sSubAcct2_ID = "",
                                                sEmployee_ID = "",
                                                sOtherCr = "",
                                                sCategoryID = "",
                                                sRemarks = ""; // sEmployee = "",
                                            bool bIsCredit;
                                            decimal dAmount;

                                            sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index,
                                                "");
                                            sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail, "subAcc1", row.Index,
                                                "");
                                            sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail, "subAcc2", row.Index,
                                                "");
                                            sCategoryID = clsValidate.ValidateGridValue(dgvDetail, "CategoryID",
                                                row.Index, "");
                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index,
                                                "");
                                            sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc1", row.Index,
                                                "default");
                                            sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail, "subAcc2", row.Index,
                                                "default");
                                            sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index,
                                                "default");
                                            sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr", row.Index,
                                                "default");
                                            bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index,
                                                true);
                                            iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                int.Parse("0"));
                                            if (bIsCredit)
                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount",
                                                    row.Index, decimal.Parse("0.00"));
                                            else
                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount",
                                                    row.Index, decimal.Parse("0.00"));

                                            #region Insert tbl_accAccountPayableNote_SubTotal

                                            tbl_accAccountPayableNote_SubTotal Insdetail =
                                                new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(),
                                                    sCategoryID,
                                                    sGLCode, sOtherCr, txtSupplierID.Tag.ToString(), sEmployee_ID,
                                                    "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                            Insdetail.Insert();

                                            #endregion

                                            //DateTime dtmPostingDate = (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString()) ? dtpBillDate.Value : dtpAPNDate.Value;
                                            //#region GL Posting Detail
                                            //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.AccountPayableNote), txtAPNID.Text.Trim(), sGLCode,
                                            //                    sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtAPNID.Text.Trim(), "default",
                                            //                    dtmPostingDate, txtNarration.Text.Trim(), dAmount, bIsCredit, "", txtSupplierID.Text.Trim());
                                            //#endregion

                                        }

                                        #endregion

                                        //#region Update GLPostingHeaderTemp
                                        //clsProcessMethods.GLPostingHeaderTempUpdate(oldRecord.GlPosting_ID, dtpBillDate.Value, txtNarration.Text.Trim());
                                        //#endregion

                                        #region  Insert Header - tbl_accAccountPayableNote

                                        tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(
                                            txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(),
                                            txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(),
                                            txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(),
                                            txtGRN.Tag.ToString().Trim(),
                                            txtPONo.Tag.ToString().Trim(), "default",
                                            txtSupplierID.Tag.ToString().Trim(), "default", "default",
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
                                            clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                            oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID,
                                            oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID,
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
                                        //   clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, true);

                                        #endregion

                                        //Attachments.Insert(iFormID, oldRecord.AccountPayableNote_ID);
                                        //Attachments.Remove(iFormID, oldRecord.AccountPayableNote_ID);

                                        //update GRN-issettle
                                        if (txtGRN.Text.Trim() != "" && txtGRN.Text.Trim() != "default")
                                            clsProcessMethods.SetSettle_GRN_From_APN(txtGRN.Tag.ToString().Trim(),
                                                clsHelpMethods_Local.getDisplayPrice(
                                                    dSettleAmount - oldRecord.GrandTotal, dExRate));
                                        else if (txtPONo.Text.Trim() != "" && txtPONo.Text.Trim() != "default")
                                            clsProcessMethods.SetSettle_PO_From_APN(txtPONo.Text.ToString().Trim(),
                                                clsHelpMethods_Local.getDisplayPrice(
                                                    dSettleAmount - oldRecord.GrandTotal, dExRate));

                                        clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                                        //Sent Maill
                                        email.createEmail_APN(AccAPN.AccountPayableNote_ID,
                                            enum_Alerts.AccountPayableNoteModified);
                                    }
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion

                    #region insert records
                    else //insert records
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtAPNID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAPNID.Text)) //if (txtAPNID.Text.Trim().Length > 0)
                        {
                            ////insert Header GL Posting
                            //string sPostingID = "default";
                            //sPostingID = clsProcessMethods.GLPostingHeaderTempInsert(dtpBillDate.Value, txtNarration.Text.Trim());

                            //insert Header
                            //tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(), txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(), txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(), txtGRN.Tag.ToString().Trim(), txtPONo.Tag.ToString().Trim(),
                            //    "default", txtSupplierID.Tag.ToString().Trim(), "default", "default", txtCostCenter1.Tag.ToString().Trim(), txtCostCenter2.Tag.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurCode.Tag.ToString().Trim(),
                            //    decimal.Parse(txtCurrencyRate.Text.ToString().Trim()), decimal.Parse(txtCreditDays.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Text.Trim()) * dExRate,
                            //    decimal.Parse(txtDiscount.Text.Trim()) * dExRate, decimal.Parse(txtNBT.Text.Trim()) * dExRate, decimal.Parse(txtVat.Text.Trim()) * dExRate, decimal.Parse(txtOtherTax.Text.Trim()) * dExRate, decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(),
                            //    txtApprovedBy.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                            //    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, false, false, false, false, false, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            tbl_accAccountPayableNote AccAPN = new tbl_accAccountPayableNote(txtAPNID.Text.Trim(), dtpAPNDate.Value, txtNarration.Text.Trim(), txtBillNo.Text.Trim(), dtpBillDate.Value, txtDeliveryOrderID.Text.Trim(), txtAWB.Text.Trim(), txtLCNo.Text.Trim(), txtAPNType.Tag.ToString().Trim(), txtGRN.Tag.ToString().Trim(), txtPONo.Tag.ToString().Trim(),
                                "default", txtSupplierID.Tag.ToString().Trim(), "default", "default", txtNoteType.Tag.ToString(), txtCostCenter1.Tag.ToString().Trim(), txtCostCenter2.Tag.ToString().Trim(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurCode.Tag.ToString().Trim(),
                                decimal.Parse(txtCurrencyRate.Text.ToString().Trim()), decimal.Parse(txtCreditDays.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Text.Trim()) * dExRate,
                                decimal.Parse(txtDiscount.Text.Trim()) * dExRate, decimal.Parse(txtNBT.Text.Trim()) * dExRate, decimal.Parse(txtVat.Text.Trim()) * dExRate, decimal.Parse(txtOtherTax.Text.Trim()) * dExRate, decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), true, false, bHasChecked, bHasApproved, false, false, false, false, false, 0, false, "default", false, 0, clsSecurity.CompanyID, clsSecurity.BranchID);
                            AccAPN.Insert();

                            //  Insert supplier outstanding amount
                            //    clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, true);

                            #region  Insert Detail - APN Details
                            int iRow;
                            string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";//sEmployee = "",
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
                                sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail, "employee", row.Index, "default");
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
                                DateTime dtmPostingDate = (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString()) ? dtpBillDate.Value : dtpAPNDate.Value;

                                #region Insert tbl_accAccountPayableNote_SubTotal
                                tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRow, txtAPNID.Text.Trim(), sCategoryID,
                                    sGLCode, sOtherCr, txtSupplierID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                Insdetail.Insert();
                                #endregion

                                //#region GL Posting Detail
                                //clsProcessMethods.GLPostingDetailTemp(iRow, sPostingID, clsAutocode.getAccSlotID(AccSlot.AccountPayableNote), txtAPNID.Text.Trim(), sGLCode,
                                //                    sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtAPNID.Text.Trim(), "default",
                                //                    dtmPostingDate, txtNarration.Text.Trim(), dAmount, bIsCredit, "default", txtSupplierID.Text.Trim());
                                //#endregion

                            }
                            #endregion

                            Attachments.Insert(txtAPNID.Text.ToString());

                            if (txtGRN.Text.Trim() != "" && txtGRN.Text.Trim() != "default")
                                clsProcessMethods.SetSettle_GRN_From_APN(txtGRN.Tag.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(dSettleAmount, dExRate));
                            else if (txtPONo.Text.Trim() != "" && txtPONo.Text.Trim() != "default")
                                clsProcessMethods.SetSettle_PO_From_APN(txtPONo.Text.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(dSettleAmount, dExRate));
                            //if (txtPONo.Text.Trim() != "" && txtPONo.Text.Trim() != "default")
                            //    clsProcessMethods.SetSettle_PO_From_APN(txtPONo.Text.ToString().Trim(), clsHelpMethods.getDisplayPrice(dSettleAmount, dExRate));

                            clsMethods_GL.PostTransaction_APN(txtAPNID.Text.Trim());
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Sent Maill
                   
                            email.createEmail_APN(AccAPN.AccountPayableNote_ID, enum_Alerts.AccountPayableNoteCreated);
                        }
                        //else
                        //    MessageBox.Show("APN No " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }//error may come because last row of the grid may not have information
                finally
                {
                    Cursor = Cursors.Default;
                    tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                    if (oldRecord != null)
                        FillDetails(txtAPNID.Text.Trim());
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_accAccountpayableNote_OLD_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_accAccountpayableNote_OLD_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtAPNID.Text.Trim().Length > 0 && txtAPNID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    //glb_dts_Apn.dts_AccountPaybleNote.Rows.Clear();
                    glb_dts_Apn.Clear();

                    bool bIsCanceled = false;
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sDuplicateCopy = "";
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
                        //if (oSup != null && oAPN_SubTotals != null && APN.Supplier_ID != "default")
                        if (oSup != null && oAPN_SubTotals != null)
                        {
                            sSupplierAddress = oSup.AddressRegister;
                            decimal dCreditVal = 0, dDebetVal = 0;

                            foreach (tbl_accAccountPayableNote_SubTotal oAPN_SubTotal in oAPN_SubTotals)
                            {
                                dCreditVal = 0;
                                dDebetVal = 0;
                                if (oAPN_SubTotal.IsCredit)
                                    dCreditVal = oAPN_SubTotal.Amount;
                                else
                                    dDebetVal = oAPN_SubTotal.Amount;

                                glb_dts_Apn.dts_AccountPaybleNote.Adddts_AccountPaybleNoteRow(APN.AccountPayableNote_ID, APN.AccountPayableNoteDate, clsGenaralName.getName_APNType(APN.ApnType_ID), APN.Narration, clsGenaralName.getName_Supplier(APN.Supplier_ID), APN.BillNo, APN.BillDate, APN.PurchaseOrder_ID, APN.ExternalGoodReceivedNote_ID, APN.NoDeliveryOrder, APN.NoAWB, APN.NoLC, APN.CreditDays.ToString(), APN.DiscountTotal, APN.NbtTotal, APN.VatTotal, APN.OtherTaxTotal, APN.SubTotal, APN.GrandTotal, oAPN_SubTotal.Line_No, oAPN_SubTotal.Gl_ID, clsGenaralName.getName_AccountName(oAPN_SubTotal.Gl_ID), dCreditVal, dDebetVal, "", 0, false, "", "", 0, 0, 0, 0);
                            }
                        }

                        if (bApprovalDone && bCheckingDone)
                        {
                            bOkToPrint = true;

                            sCreateUser = "[ " + clsGenaralName.getName_User(APN.CreateUser_ID) + " ] [ " + APN.DateCreate.ToShortDateString() + " ]";
                            if (APN.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(APN.CheckedUser_ID) + " ] [ " + APN.DateChecked.ToShortDateString() + " ]";
                            if (APN.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(APN.ApprovedUser_ID) + " ] [ " + APN.DateApproved.ToShortDateString() + " ]";

                            if (APN.IsDeleted)
                                bIsCanceled = true;

                            #region Print The Doc
                            if (bOkToPrint && bApprovalDone)
                            {
                                if (!bIsDraft)
                                {
                                    if (APN.PrintCount > 0)
                                        sDuplicateCopy = "Duplicate Copy " + APN.PrintCount;

                                    APN.PrintCount++;
                                    APN.Update();
                                }

                                string s_Path = "", sReportTitle = "ACCOUNT PAYABLE NOTE", sFormula = "";
                                if (txtAPNID.TextLength > 0)
                                    sFormula = " {vw_rpt_accAccountPayableNote.accountPayableNote_ID} = '" + txtAPNID.Text.Trim() + "'";
                                ReportDocument RD = new ReportDocument();

                                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                                string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));

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
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", clsCommon.fncsetstring(sCreateUser), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", clsCommon.fncsetstring(sCheckedUser), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", clsCommon.fncsetstring(sApprovedUser), true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDTitle", "APN No", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IDDateTitle", "APN Date", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberID", "GRN No", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("NumberDate", "GRN Date", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

                                    if (bIsCanceled)
                                    {
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "Canceled", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", "", true);
                                    }
                                    else
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Cancel", "", true);

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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true);
                                        }
                                    }
                                    glb_dts_Apn.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "", "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                    ReportViewer.print(s_Path, glb_dts_Apn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_AccountPayableNote));
                                    //print(s_Path, sReportTitle, glb_dts_Apn, sDraff, bIsCanceled, isDuplicate, sCreateUser);
                                }
                                else
                                {
                                    frm_ReportViewer viewer = new frm_ReportViewer();
                                    viewer.crystalReportViewer1.ShowExportButton = false;
                                    RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                                    //   clsSecurity.LogonServer(ref RD);
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
                                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = bIsCanceled ? "" : sDuplicateCopy;
                                    RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";

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
                    email.createEmail_APN(txtAPNID.Text.Trim(), enum_Alerts.AccountPayableNotePrinted);
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

        #region Btn Checked, Approved and History
        private void frm_accAccountpayableNote_OLD_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accAccountpayableNote_OLD_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accAccountpayableNote_OLD_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Temp
        private void frm_accAccountpayableNote_OLD_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtAPNID.TextLength > 0 && txtAPNID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
                clsCommon.SetEnableDisable_NormalDateTimePicker(dtpAPNDate, true);
                clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblJobDate, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblNoteType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, true);

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
            clsCommon.SetEnableDisable_NormalLabel(lblNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, true);

            clsCommon.SetEnableDisable_NormalTextbox(txtOtherTax, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtNBT, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtVat, false);

            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageOtherTax, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageNBT, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtPercentageVat, false);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPONo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtGRN, true);

            txtGRN.Visible = true;
            label18.Visible = true;
            txtPONo.Visible = true;
            label17.Visible = true;

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtAPNID.Tag = null;
            txtAPNType.Tag = null;
            txtNoteType.Tag = null;
            txtBillNo.Tag = null;
            txtSubTotal.Tag = null;
            txtPONo.Tag = null;
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
            lblPoNo.Text = null;

            txtSupplierID.Tag = null;
            txtSupplierID.Clear();

            //  txtOtherCr.Clear();
            //   txtOtherCr.Tag = null;

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
            txtPONo.Clear();
            txtAWB.Clear();
            txtGRN.Clear();
            txtLCNo.Clear();
            txtDeliveryOrderID.Clear();
            txtNarration.Clear();
            txtCreditAmount.Clear();
            txtDebitAmount.Clear();
            txtBalanceAmount.Clear();
            txtCreditDays.Clear();

            s_FileName = "";

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            txtPercentageDiscount.Text = "0";
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
            glb_dtSubTotal.Rows.Clear();

            userDetailsColorChanges();

            clsEvent.GLCode_TextChanged(pbxSubTot, "");
            clsEvent.GLCode_TextChanged(pbxNBT, "");
            clsEvent.GLCode_TextChanged(pbxVat, "");
            clsEvent.GLCode_TextChanged(pbxSVat, "");
            clsEvent.GLCode_TextChanged(pbxSupplier, "");
            //   clsEvent.GLCode_TextChanged(pbxOtherCr, "");
            clsEvent.GLCode_TextChanged(pbxCos1, "");
            clsEvent.GLCode_TextChanged(pbxCos2, "");

            dgvDetail.Rows.Clear();

            //Clear GLs                               
            glb_dtSubTotal.Rows.Clear();
            glb_dtNBT.Rows.Clear();
            glb_dtVAT.Rows.Clear();
            glb_dtSVAT.Rows.Clear();
            glb_dtGrandTotal.Rows.Clear();

            chkSettings2.Checked = true;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtAPNID.Text = "<Auto Generate>";
            else
                txtAPNID.Clear();
            if (txtAPNID.Enabled)
            {
                txtAPNID.SelectAll();
                txtAPNID.Focus();
            }
            txtAPNType.Text = clsGenaralName.getName_APNType(clsConfig.sDefaultAPNTypeID);
            txtAPNType.Tag = clsConfig.sDefaultAPNTypeID;
            lblPoNo.Visible = false;

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
                        //set the update flag and Locked
                        IsUpdate = true;
                        //if (detail.IsDeleted)
                        //lblCancelled.Visible = true;
                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            btnDraft.Enabled = false;
                        }
                        else
                            btnDraft.Enabled = true;

                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAPNID, false);

                        FillDetailsCurrency(detail.Currency_ID);

                        txtAPNID.Tag = detail.AccountPayableNote_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;
                        //txtOtherCr.Tag = detail.Employee_ID;
                        txtCostCenter1.Tag = detail.CostCenter1_ID;
                        txtCostCenter2.Tag = detail.CostCenter2_ID;
                        txtAPNType.Tag = detail.ApnType_ID;
                        txtNoteType.Tag = detail.StockNoteType_ID;

                        txtAPNID.Text = detail.AccountPayableNote_ID;
                        dtpAPNDate.Value = detail.AccountPayableNoteDate;
                        txtBillNo.Text = detail.BillNo;
                        dtpBillDate.Value = detail.BillDate;
                        txtNarration.Text = detail.Narration;

                        txtPONo.Text = clsCommon.GetForeignKeyValue(detail.PurchaseOrder_ID);
                        txtPONo.Tag = detail.PurchaseOrder_ID;
                        txtAWB.Text = detail.NoAWB;
                        txtGRN.Text = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtGRN.Tag = clsCommon.GetForeignKeyValue(detail.ExternalGoodReceivedNote_ID);
                        txtLCNo.Text = detail.NoLC;
                        txtDeliveryOrderID.Text = detail.NoDeliveryOrder;
                        txtCreditDays.Text = detail.CreditDays.ToString();
                        txtAPNType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_APNType(detail.ApnType_ID));
                        txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        //if (txtGRN.Text.Trim().Length > 0)
                        //{
                        //    tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(detail.ExternalGoodReceivedNote_ID);
                        //    if (oGRN != null)
                        //    {
                        //        string sPONo =oGRN.PurchaseOrder_ID;
                        //        foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID))
                        //        {
                        //            if (sPONo != oGRNDetail.PurchaseOrder_ID)
                        //            {
                        //                sPONo = "Multiple POs";
                        //                break;
                        //            }
                        //        }
                        //        lblPoNo.Visible = true;
                        //        lblPoNo.Text = sPONo;
                        //    }
                        //}

                        if (detail.PurchaseOrder_ID != "default")
                        {
                            txtGRN.Visible = false;
                            label18.Visible = false;
                        }
                        if (detail.ExternalGoodReceivedNote_ID != "default")
                        {
                            txtPONo.Visible = false;
                            label17.Visible = false;
                        }

                        txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        //    txtOtherCr.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(detail.Employee_ID));
                        txtCostCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                        txtCostCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));

                        //glb_dtSubTotal.Rows.Clear();
                        //User Security
                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        userDetailsColorChanges();

                        //Asign Taxes
                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;


                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, dExRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, dExRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, dExRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, dExRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, dExRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, dExRate));


                        clsEvent.GLCode_TextChanged(pbxSubTot, glb_dtSubTotal, txtSubTotal, null);
                        //Fill GL Codes
                        FillDetailGLCodes(sID);

                        CalculateSubTotal();
                        CalculateTaxesAndGrandTotal();
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, dExRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, dExRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, dExRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, dExRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, dExRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, dExRate));

                        RefreshGrid();

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

        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sAPN_ID)
        {
            try
            {
                //Clear GLs                               
                glb_dtSubTotal.Rows.Clear();
                glb_dtNBT.Rows.Clear();
                glb_dtVAT.Rows.Clear();
                glb_dtSVAT.Rows.Clear();
                glb_dtGrandTotal.Rows.Clear();

                //Fill GLs
                List<tbl_accAccountPayableNote_SubTotal> details = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(sAPN_ID);
                foreach (tbl_accAccountPayableNote_SubTotal detail in details)
                {
                    #region Fill
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal).ToString())
                    {
                        glb_dtGrandTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        if (detail.Supplier_ID != "default")
                        {
                            rdoSupplier.Checked = true;
                            clsEvent.GLCode_TextChanged(pbxSupplier, "Accept");
                        }
                        else
                        {
                            rdoOtherCr.Checked = true;
                            //    clsEvent.GLCode_TextChanged(pbxOtherCr, "Accept");
                        }
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal).ToString())
                    {
                        glb_dtSubTotal.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxSubTot, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.NBT).ToString())
                    {
                        glb_dtNBT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.VAT).ToString())
                    {
                        glb_dtVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxVat, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT).ToString())
                    {
                        glb_dtSVAT.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxSVat, "Accept");
                    }
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

        #region Fill Tax Detail By PO
        private void FillTaxDetailByPO(string sPurchaseOrderID)
        {
            try
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sPurchaseOrderID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                    //txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal-detail.DiscountTotal, detail.ForexRate));
                    //txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal - detail.DiscountTotal, detail.ForexRate));
                    ////txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.ForexRate));
                    //txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.ForexRate));
                    //txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.ForexRate));
                    //txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.ForexRate));
                    //txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.ForexRate));
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                    FillDetailsCurrency(txtCurCode.Tag.ToString());

                    txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    txtSupplierID.Tag = detail.Supplier_ID;
                    rdoSupplier.Checked = (detail.Supplier_ID != "default") ? true : false;
                    txtNoteType.Tag = detail.StockNoteType_ID;
                    txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                    //add 201-09-21 by janith
                    txtCreditDays.Text = detail.BalanceDays.ToString();
                    //txtCreditDays.Enabled = false;

                    //chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    CalculateTaxesAndGrandTotal();

                    //change 201-09-21 by janith
                    //tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());
                    //if (osup != null && osup.CreditPeriod > 0)
                    //    txtCreditDays.Text = osup.CreditPeriod.ToString();
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By GRN
        private void FillTaxDetailByGRN(string sGRNID)
        {
            try
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sGRNID);
                string sPONo = detail.PurchaseOrder_ID != "default" ? detail.PurchaseOrder_ID : "";
                if (detail != null)
                {
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                    //txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice((detail.SubTotal - detail.DiscountTotal), detail.CurrencyRate));
                    //txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal - detail.DiscountTotal, detail.CurrencyRate));
                    //txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    //txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    //txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                    //txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal - detail.DiscountTotal);
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

                    foreach (tbl_scsExternalGoodReceivedNote_Detail oGRNDetail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGRNID))
                    {
                        if (oGRNDetail.PurchaseOrder_ID != sPONo)
                        {
                            sPONo = "Multiple POs";
                            break;
                        }
                    }

                    lblPoNo.Text = sPONo;
                    lblPoNo.Visible = true;

                    txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    txtSupplierID.Tag = detail.Supplier_ID;
                    rdoSupplier.Checked = (detail.Supplier_ID != "default") ? true : false;

                    txtNoteType.Tag = detail.StockNoteType_ID;
                    txtNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                    //add 201-09-21 by janith
                    txtCreditDays.Text = detail.CreditPeriod;
                    //txtCreditDays.Enabled = false;

                    //chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    CalculateTaxesAndGrandTotal();
                    //FillDetailsCurrency(detail.Currency_ID.Trim());
                    FillDetailsCurrency(txtCurCode.Tag.ToString());

                    //change 201-09-21 by janith
                    //tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());
                    //if (osup != null && osup.CreditPeriod > 0)
                    //{
                    //    txtCreditDays.Text = osup.CreditPeriod.ToString();
                    //}

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
        private void RefreshGridByGRN(string sGRNID)
        {
            try
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(sGRNID);
                if (detail != null)
                {
                    if (detail.VatTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/001");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(1, Tdetail.ReceivableGl_ID,
                               decimal.Parse(txtVat.Text.Trim()) * dExRate,
                                "default", "default", "default", "default", TransactionCategory.VAT, detail.Supplier_ID);
                    }
                    if (detail.NbtTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/002");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(2, Tdetail.ReceivableGl_ID,
                                  decimal.Parse(txtNBT.Text.Trim()) * dExRate,
                                "default", "default", "default", "default", TransactionCategory.NBT, detail.Supplier_ID);
                    }
                    if (detail.OtherTaxTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/003");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(3, Tdetail.ReceivableGl_ID,
                                 decimal.Parse(txtOtherTax.Text.Trim()) * dExRate,
                                "default", "default", "default", "default", TransactionCategory.SVAT, detail.Supplier_ID);
                    }
                    if (detail.SubTotal > 0)
                    {
                        string sGLCode = "";
                        #region Asign GL Code
                        tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(detail.Supplier_ID);
                        if (oSupplier != null && oSupplier.Supplier_ID != "default")
                        {
                            if (oSupplier.SupplierAccountType_ID != null && oSupplier.SupplierAccountType_ID != "default")
                            {
                                //tbl_accAccountsType_Supplier oType = tbl_accAccountsType_Supplier.Select(oSupplier.SupplierAccountType_ID);
                                //if (oType != null && oType.Gl_ID != "default")
                                //{
                                //    sGLCode = oType.Gl_ID;
                                //}
                            }
                        }
                        if (sGLCode.Length > 0)
                        {
                            //foreach (tbl_accDoubleEntrySlotDetails item in tbl_accDoubleEntrySlotDetails.SelectAllBySlot_ID(clsAutocode.getAccSlotID(AccSlot.GoodReserveNote)))
                            //{
                            //    if (item.IsSubTotal)
                            //        sGLCode = item.Gl_ID;
                            //}
                        }
                        #endregion

                        if (sGLCode.Length > 0)
                            FilldataTable(4, sGLCode,
                                 decimal.Parse(txtSubTotal.Text.Trim()) * dExRate,
                                "default", "default", "default", "default", TransactionCategory.SubTotal, detail.Supplier_ID);
                    }
                    if (detail.GrandTotal > 0)
                    {
                        FilldataTable(5, clsMethods_GL.getAccountCode_Supplier(detail.Supplier_ID).Trim(),
                             decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate,
                            "default", "default", "default", "default", TransactionCategory.GrandTotal, detail.Supplier_ID);
                    }
                }
                RefreshGrid();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid By PRN
        private void RefreshGridByPRN(string sPRNID)
        {
            try
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sPRNID);
                if (detail != null)
                {
                    if (detail.VatTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/001");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(1, Tdetail.ReceivableGl_ID, detail.VatTotal * dExRate, "default", "default", "default", "default", TransactionCategory.VAT, "default");
                    }
                    if (detail.NbtTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/002");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(2, Tdetail.ReceivableGl_ID, detail.NbtTotal * dExRate, "default", "default", "default", "default", TransactionCategory.NBT, "default");
                    }
                    if (detail.OtherTaxTotal > 0)
                    {
                        tbl_zTax Tdetail = tbl_zTax.Select("TAX/003");
                        if (Tdetail != null && Tdetail.ReceivableGl_ID != "default" && Tdetail.ReceivableGl_ID != null)
                            FilldataTable(3, Tdetail.ReceivableGl_ID, detail.OtherTaxTotal * dExRate, "default", "default", "default", "default", TransactionCategory.SVAT, "default");
                    }
                    if (detail.SubTotal > 0)
                    {
                        string sGLCode = "";
                        foreach (tbl_accDoubleEntrySlotDetails item in tbl_accDoubleEntrySlotDetails.SelectAllBySlot_ID(clsAutocode.getAccSlotID(AccSlot.PurchaseOrder)))
                        {
                            if (item.IsSubTotal)
                                sGLCode = item.Gl_ID;
                        }
                        if (sGLCode.Length > 0)
                            FilldataTable(4, sGLCode, detail.SubTotal * dExRate, "default", "default", "default", "default", TransactionCategory.SubTotal, "default");
                    }
                    if (detail.GrandTotal > 0)
                    {
                        FilldataTable(5, clsMethods_GL.getAccountCode_Supplier(detail.Supplier_ID).Trim(), detail.GrandTotal * dExRate, "default", "default", "default", "default", TransactionCategory.GrandTotal, detail.Supplier_ID);
                    }
                }
                RefreshGrid();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sEmployee = "", sOtherCr = "", sCategoryID = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sRemarks = "";

                if (glb_dtSubTotal.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxSubTot, glb_dtSubTotal, txtSubTotal, null);
                    //int iRow;
                    //dgvDetail.Rows.Clear();
                    foreach (DataRow row in glb_dtSubTotal.Rows)
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
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, false);
                }

                if (glb_dtNBT.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxNBT, glb_dtNBT, txtNBT, null);
                    foreach (DataRow row in glb_dtNBT.Rows)
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

                if (glb_dtVAT.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxVat, glb_dtVAT, txtVat, null);
                    foreach (DataRow row in glb_dtVAT.Rows)
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
                if (glb_dtSVAT.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxSVat, glb_dtSVAT, txtOtherTax, null);
                    foreach (DataRow row in glb_dtSVAT.Rows)
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
                if (glb_dtGrandTotal.Rows.Count > 0)
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
                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                    }
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurCode, false);
                }

                //Calulate balance text boxes
                CalculateBalance();

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
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
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(dTotAmount, dExRate));
                txtSubTotal.Tag = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(dTotAmount, dExRate));
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        #endregion

        #region Check Validity
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValiditySubTotal())
            {
                if (CheckDataTableValidity())
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckStatusValidity())
                        {
                            if (CheckValidity_EmptyField())
                            {
                                if (CheckValiditySettleAmmount())
                                {
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpAPNDate.Value.Date))
                                    {
                                        //if (decimal.Parse(txtDebitAmount.Text) == decimal.Parse(txtGrandTotal.Text))
                                        //if (decimal.Parse(txtDebitAmount.Text) == clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate))
                                        //if (txtDebitAmount.Text == clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate)))

                                        if (clsFormatter.FormatDecimalPlaces_Price(decimal.Parse(txtDebitAmount.Text)) == clsFormatter.FormatDecimalPlaces_Price(
                                                                                                                                         clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate)))
                                        {
                                            bIsOk = true;
                                        }
                                        else
                                            MessageBox.Show("APN Grand total and GL Total not matching....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            return bIsOk;
        }
        private bool CheckValiditySettleAmmount()
        {
            bool bSettoffOk = false;
            try
            {
                decimal dSettleAmount = 0, dOldGrandTotal = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dSettleAmount += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
                }

                if (txtAPNID.Tag != null)
                {
                    tbl_accAccountPayableNote oldRecord = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                    if (oldRecord != null)
                        dOldGrandTotal = oldRecord.GrandTotal;
                }

                if (txtGRN.Tag != null && txtGRN.Tag.ToString().Trim().Length > 0 && txtGRN.Tag.ToString().Trim() != "default")
                    bSettoffOk = clsProcessMethods.Check_ARNTotal_With_GRNTotal(txtGRN.Text.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(dSettleAmount - dOldGrandTotal, dExRate));//dSettleAmount - dOldGrandTotal is it OK
                else if (txtPONo.Tag != null && txtPONo.Tag.ToString().Trim().Length > 0 && txtPONo.Tag.ToString().Trim() != "default")
                    bSettoffOk = clsProcessMethods.Check_ARNTotal_With_POTotal(txtPONo.Text.ToString().Trim(), clsHelpMethods_Local.getDisplayPrice(dSettleAmount - dOldGrandTotal, dExRate));
                else
                    bSettoffOk = true;

                if (!bSettoffOk)
                    MessageBox.Show("APN Amount cannot be greater than unsettled PO/GRN Amount....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bSettoffOk;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtAPNType, "APN Type"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtNoteType, "Note Type"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtBillNo, "Bill No"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCreditDays, "Credit days"))
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }
        private bool CheckStatusValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {

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

                if (txtBalanceAmount.Text.Trim() != "00.00")
                {
                    strMessage += "\n" + "Please enter GL Accounts ";
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
                if (decimal.Parse(txtSubTotal.Text.Trim()) > 0 && glb_dtSubTotal.Rows.Count == 0)
                {
                    strMessage += "\n Please Enter GL Codes for Sub Totals";
                    bStatus = false;
                }

                if (decimal.Parse(txtNBT.Text.Trim()) > 0 && glb_dtNBT.Rows.Count == 0)
                {
                    strMessage += "\n Please Enter GL Codes for NBT Amount OR Clear the  NBT Amount";
                    bStatus = false;
                }

                if (decimal.Parse(txtVat.Text.Trim()) > 0 && glb_dtVAT.Rows.Count == 0)
                {
                    strMessage += "\n Please Enter GL Codes for VAT Amount OR Clear the  VAT Amount";
                    bStatus = false;
                }

                //if (decimal.Parse(txtOtherTax.Text.Trim()) > 0 && glb_dtSVAT.Rows.Count == 0)
                //{
                //    strMessage += "\n Please Enter GL Codes for SVAT Amount OR Clear the SVAT Amount";
                //    bStatus = false;
                //}
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtAPNID);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                //    clsCommon.ValidateForeignKey(ref txtOtherCr);
                clsCommon.ValidateForeignKey(ref txtCostCenter1);
                clsCommon.ValidateForeignKey(ref txtCostCenter2);
                clsCommon.ValidateForeignKey(ref txtGRN);
                clsCommon.ValidateForeignKey(ref txtDeliveryOrderID);
                clsCommon.ValidateForeignKey(ref txtPONo);

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
        private void txtPONo_DoubleClick(object sender, EventArgs e)
        {
            if (!IsUpdate)
                Search_PurchesOrder();
        }
        private void txtGRN_DoubleClick(object sender, EventArgs e)
        {
            if (!IsUpdate)
                Search_GoodsRecivedNote();
        }
        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditySubTotal())
            {
                clearSubGLCodeExceptThis("Supplier");
                Search_Supplier();
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
            clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, chkShowSettle.Checked, "", "", false, false, false, false);
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

        private void txtPONo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtPONo_DoubleClick(sender, e);
        }
        #endregion

        #region  Event Text Changed

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtSubTotal.Text.Trim()) && decimal.Parse(txtSubTotal.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxSubTot, glb_dtSubTotal, txtSubTotal, null);
                pbxSubTot.Enabled = true;
            }
            else
            {
                pbxSubTot.Enabled = false;
            }
        }
        private void txtNBT_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtNBT.Text.Trim()) && decimal.Parse(txtNBT.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxNBT, glb_dtNBT, txtNBT, null);
                pbxNBT.Enabled = true;
            }
            else
            {
                pbxNBT.Enabled = false;
            }
        }
        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtVat.Text.Trim()) && decimal.Parse(txtVat.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxVat, glb_dtVAT, txtVat, null);
                pbxVat.Enabled = true;
            }
            else
            {
                pbxVat.Enabled = false;
            }
        }
        private void txtOtherTax_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtOtherTax.Text.Trim()) && decimal.Parse(txtOtherTax.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxSVat, glb_dtSVAT, txtOtherTax, null);
                pbxSVat.Enabled = true;
            }
            else
            {
                pbxSVat.Enabled = false;
            }
        }

        #endregion

        #region Events KeyUp
        private void txtSubTotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (clsCommon.isCurrency(txtSubTotal.Text.Trim()) && decimal.Parse(txtSubTotal.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxSubTot, glb_dtSubTotal, txtSubTotal, null);
                txtSubTotal.Tag = decimal.Parse(txtSubTotal.Text.ToString());

                CalculateTaxesAndGrandTotal();
            }
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            //Do nothing
        }
        private void txtNBT_KeyUp(object sender, KeyEventArgs e)
        {
            if (clsCommon.isCurrency(txtNBT.Text.Trim()) && decimal.Parse(txtNBT.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxNBT, glb_dtNBT, txtNBT, null);
                txtNBT.Tag = decimal.Parse(txtNBT.Text.ToString());

                //CalculateTaxesAndGrandTotal();
            }
        }
        #endregion

        #region Events Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            //Do Nothing
        }
        private void txtNBT_Leave(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtNBT.Text.Trim()) && decimal.Parse(txtNBT.Text.ToString()) > 0)
            {
                txtNBT.Tag = decimal.Parse(txtNBT.Text.ToString());

                decimal dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                // decimal dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                decimal dActualSubTotal = (dSubTotal);
                CalculatePesentage(ref txtPercentageNBT, decimal.Parse(txtNBT.Text.Trim()), dActualSubTotal);
                CalculateTaxesAndGrandTotal();
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
            }
        }
        private void txtOtherTax_Leave(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtOtherTax.Text.Trim()) && decimal.Parse(txtOtherTax.Text.ToString()) > 0)
            {
                txtOtherTax.Tag = decimal.Parse(txtOtherTax.Text.ToString());

                decimal dSubTotal = decimal.Parse(txtSubTotal.Text.Trim());
                //  decimal dDiscount = decimal.Parse(txtDiscount.Text.Trim());
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

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region  Event Click
        private void pbxOtherCr_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtGrandTotal, decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate, TransactionCategory.GrandTotal, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtGrandTotal, (decimal.Parse(txtGrandTotal.Text.Trim())), TransactionCategory.GrandTotal, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));

            if (glb_dtGrandTotal != null && glb_dtGrandTotal.Rows.Count > 0)
                RefreshGrid();
        }
        private void pbxSupplier_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtGrandTotal, (decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate), TransactionCategory.GrandTotal, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtGrandTotal, (decimal.Parse(txtGrandTotal.Text.Trim())), TransactionCategory.GrandTotal, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));

            if (glb_dtGrandTotal != null && glb_dtGrandTotal.Rows.Count > 0)
                RefreshGrid();
        }

        private void pbxSubTot1_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtSubTotal, (decimal.Parse(txtSubTotal.Text.Trim()) * dExRate), TransactionCategory.SubTotal, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtSubTotal, (decimal.Parse(txtSubTotal.Text.Trim())), TransactionCategory.SubTotal, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));

            if (glb_dtSubTotal != null && glb_dtSubTotal.Rows.Count > 0)
            {
                CalculateSubTotal();
                CalculateTaxesAndGrandTotal();
                RefreshGrid();
            }
        }
        private void pbxVat_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtVAT, decimal.Parse(txtVat.Text.Trim()) * dExRate, TransactionCategory.VAT, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtVAT, (decimal.Parse(txtVat.Text.Trim())), TransactionCategory.VAT, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtVAT != null && glb_dtVAT.Rows.Count > 0)
            {
                CalculateSubTotal();
                CalculateTaxesAndGrandTotal();
                RefreshGrid();
            }
        }
        private void pbxSVat_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtSVAT, decimal.Parse(txtOtherTax.Text.Trim()) * dExRate, TransactionCategory.VAT, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtSVAT, (decimal.Parse(txtOtherTax.Text.Trim())), TransactionCategory.VAT, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtSVAT != null && glb_dtSVAT.Rows.Count > 0)
            {
                CalculateSubTotal();
                CalculateTaxesAndGrandTotal();
                RefreshGrid();
            }
        }

        private void pbxNBT_Click(object sender, EventArgs e)
        {
            //clsEvent.PictureBox_Click(ref glb_dtNBT, decimal.Parse(txtNBT.Text.Trim()) * dExRate, TransactionCategory.NBT, iFormID, "", 1);
            clsEvent.PictureBox_Click(ref glb_dtNBT, (decimal.Parse(txtNBT.Text.Trim())), TransactionCategory.NBT, iFormID, txtCurCode.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtNBT != null && glb_dtNBT.Rows.Count > 0)
            {
                CalculateTaxesAndGrandTotal();
                RefreshGrid();
            }

        }
        #endregion

        #region Events Datagrid
        private void dgvDetailMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // FillDetailsItem(e.RowIndex);
                // txtmatRowNo.Text = e.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void dgvDetailMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailMaterial_CellClick(sender, e);
        }
        #endregion

        #region Events CheckedChanged
        private void rdoSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSupplier.Checked)
            {
                rdoSupplier.Enabled = true;
                txtSupplierID.Enabled = true;
                pbxSupplier.Enabled = true;

                rdoOtherCr.Checked = false;
                //   txtOtherCr.Clear();
                //   txtOtherCr.Enabled = true;
                //   pbxOtherCr.Enabled = true;
            }
        }
        private void rdoOtherCr_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOtherCr.Checked)
            {
                rdoOtherCr.Checked = true;
                //      txtOtherCr.Enabled = true;
                //      pbxOtherCr.Enabled = true;

                rdoSupplier.Checked = false;
                txtSupplierID.Clear();
                txtSupplierID.Enabled = false;
                pbxSupplier.Enabled = false;

            }
        }
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
                    {
                        string sGLCode = clsMethods_GL.getAccountCode_Supplier(txtSupplierID.Tag.ToString().Trim());
                        tbl_genSupplierMaster osup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString().Trim());

                        if (osup != null)
                            txtCreditDays.Text = osup.CreditPeriod.ToString();

                        FilldataTable(5, sGLCode,
                                decimal.Parse(txtGrandTotal.Text.Trim()) * dExRate,
                               "default", "default", "default", "default", TransactionCategory.GrandTotal, txtSupplierID.Tag.ToString().Trim());

                        RefreshGrid();
                    }
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




                    //clsSearch.Search_MasterAccountGLCode(ref txtSupplierID, "", clsAutocode.getControlAccount_Types(enum_ControlAccountType.Other));
                    //if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                    //{
                    //    List<tbl_accGLMaster_Supplier> oAccLink = tbl_accGLMaster_Supplier.SelectAllByGl_ID(txtSupplierID.Tag.ToString());
                    //}
                }


                //clsSearch.Search_MasterSupplier(ref txtSupplierID);
                //if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                //{

                //}

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
        private void Search_PurchesOrder()
        {
            clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPONo, txtSupplierID.Tag != null ? txtSupplierID.Tag.ToString() : "", false, true);
            if (txtPONo.Tag != null && txtPONo.Tag.ToString().Trim().Length > 0)
            {
                FillTaxDetailByPO(txtPONo.Text.Trim());
                RefreshGridByPRN(txtPONo.Text.Trim());
                Disable_POGRN();
                setEnableArea_StockNoteType(false);
            }
        }

        private void Search_GoodsRecivedNote()
        {
            clsSearch.Search_TransactionExternalGoodReceivedNote_Direct(ref txtGRN, false, true, txtSupplierID.Tag != null ? txtSupplierID.Tag.ToString() : "", "");
            if (txtGRN.Tag != null && txtGRN.Tag.ToString().Trim().Length > 0)
            {
                FillTaxDetailByGRN(txtGRN.Tag.ToString().Trim());
                RefreshGridByGRN(txtGRN.Tag.ToString().Trim());
                Disable_POGRN();
                setEnableArea_StockNoteType(false);
            }
        }

        private void txtNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtNoteType);
        }
        #region Old Approved n Checked
        private void Search_CheckedBy_OLD()
        {
            try
            {
                frmSetChecked login = new frmSetChecked();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetChecked.bChecked)
                {
                    bHasChecked = true;
                    glbCheckedDate = clsSecurity.getServerDateTime();
                    if (IsUpdate)
                    {
                        tbl_accAccountPayableNote objInvoice = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                        if (objInvoice != null)
                        {
                            objInvoice.IsChecked = true;
                            objInvoice.DateChecked = clsSecurity.getServerDateTime();
                            objInvoice.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                            objInvoice.Update();
                        }
                    }
                }
                else if (frmSetChecked.bReset)
                {
                    bHasChecked = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ApprovedBy_OLD()
        {
            try
            {
                frmSetApproved login = new frmSetApproved();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetApproved.bChecked)
                {
                    bHasApproved = true;
                    glbApprovedDate = clsSecurity.getServerDateTime();

                    tbl_accAccountPayableNote objInvoice = tbl_accAccountPayableNote.Select(txtAPNID.Text.Trim());
                    if (objInvoice != null)
                    {
                        objInvoice.IsApproved = true;
                        objInvoice.DateApproved = clsSecurity.getServerDateTime();
                        objInvoice.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                        objInvoice.Update();
                    }

                }
                else if (frmSetApproved.bReset)
                {
                    bHasApproved = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


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

                // txtOtherCr.Tag = null;
                //  txtOtherCr.Clear();
                //  pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                pbxCos1.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "Employee")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                pbxCos1.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                pbxCos2.Image = Digiteq.Properties.Resources.Free;

            }
            else if (sCategory == "CostCenter1")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                //  txtOtherCr.Tag = null;
                //  txtOtherCr.Clear();
                //  pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter2.Tag = null;
                txtCostCenter2.Clear();
                pbxCos2.Image = Digiteq.Properties.Resources.Free;
            }
            else if (sCategory == "CostCenter2")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                //   txtOtherCr.Tag = null;
                //   txtOtherCr.Clear();
                //   pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                txtCostCenter1.Tag = null;
                txtCostCenter1.Clear();
                pbxCos1.Image = Digiteq.Properties.Resources.Free;

            }
        }

        #endregion

        #region Disable PO / GRN
        private void Disable_POGRN()
        {
            txtPONo.Enabled = false;
            txtGRN.Enabled = false;
        }
        #endregion

        private void setEnableArea_StockNoteType(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtNoteType, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblNoteType, bActive);
        }

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

        #region Create Data Table
        private void CreateDataTable(TransactionCategory eTCategory)
        {
            if (TransactionCategory.SubTotal == eTCategory)
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
                glb_dtSubTotal.Columns.Add("remarks", typeof(string));
                glb_dtSubTotal.Columns.Add("APNID", typeof(string));
            }
            else if (TransactionCategory.NBT == eTCategory)
            {
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
                glb_dtNBT.Columns.Add("remarks", typeof(string));
                glb_dtNBT.Columns.Add("APNID", typeof(string));
            }
            else if (TransactionCategory.VAT == eTCategory)
            {
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
                glb_dtVAT.Columns.Add("remarks", typeof(string));
                glb_dtVAT.Columns.Add("APNID", typeof(string));
            }
            else if (TransactionCategory.SVAT == eTCategory)
            {
                glb_dtSVAT = new DataTable();
                glb_dtSVAT.Columns.Add("Line_No", typeof(int));
                glb_dtSVAT.Columns.Add("GLCode", typeof(string));
                glb_dtSVAT.Columns.Add("GLName", typeof(string));
                glb_dtSVAT.Columns.Add("GLAmount", typeof(decimal));
                glb_dtSVAT.Columns.Add("SubAcct1", typeof(string));
                glb_dtSVAT.Columns.Add("SubAcct2", typeof(string));
                glb_dtSVAT.Columns.Add("Employee", typeof(string));
                glb_dtSVAT.Columns.Add("OtherCr", typeof(string));
                glb_dtSVAT.Columns.Add("CategoryID", typeof(int));
                glb_dtSVAT.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtSVAT.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtSVAT.Columns.Add("Employee_ID", typeof(string));
                glb_dtSVAT.Columns.Add("remarks", typeof(string));
                glb_dtSVAT.Columns.Add("APNID", typeof(string));
            }
            else if (TransactionCategory.GrandTotal == eTCategory)
            {
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
                glb_dtGrandTotal.Columns.Add("remarks", typeof(string));
                glb_dtGrandTotal.Columns.Add("APNID", typeof(string));
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

        #region Calculate Credit Debit Amounts
        private void CalculateBalance()
        {
            decimal dCredit = 0, dDebit = 0, dAmount = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dCredit += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                dDebit += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
            }

            txtCreditAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCredit);
            txtDebitAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDebit);

            dAmount = dCredit - dDebit;

            if (dAmount > 0)
            {
                txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                //lblIsCredit.Visible = true;
                //lblIsCredit.Text = "Cr.";
            }
            else
            {
                txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount * (-1));
                //lblIsCredit.Visible = true;
                //lblIsCredit.Text = "Dr.";
            }

            if (dAmount == 0)
            {
                txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                //lblIsCredit.Visible = false;
                //lblIsCredit.Text = "";
            }

        }
        #endregion

        #region Fill Data Table
        private void FilldataTable(int Line_No, string Gl_ID, decimal Amount, string CostCenter1_ID, string CostCenter2_ID, string Employee_ID, string Customer_ID, TransactionCategory TransactionCategoryID, string Supplier_ID)
        {
            try
            {
                if (TransactionCategoryID == TransactionCategory.GrandTotal)
                {
                    glb_dtGrandTotal.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID);
                    if (Supplier_ID != "default")
                    {
                        rdoSupplier.Checked = true;
                        clsEvent.GLCode_TextChanged(pbxSupplier, "Accept");
                    }
                    else
                    {
                        rdoOtherCr.Checked = true;
                        //   clsEvent.GLCode_TextChanged(pbxOtherCr, "Accept");
                    }
                }
                else if (TransactionCategoryID == TransactionCategory.SubTotal)
                {
                    glb_dtSubTotal.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID);
                    clsEvent.GLCode_TextChanged(pbxSubTot, "Accept");
                }
                else if (TransactionCategoryID == TransactionCategory.NBT)
                {
                    glb_dtNBT.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.NBT)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID);
                    clsEvent.GLCode_TextChanged(pbxNBT, "Accept");
                }
                else if (TransactionCategoryID == TransactionCategory.VAT)
                {
                    glb_dtVAT.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.VAT)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID);
                    clsEvent.GLCode_TextChanged(pbxVat, "Accept");
                }
                else if (TransactionCategoryID == TransactionCategory.SVAT)
                {
                    glb_dtSVAT.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                        clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT)
                        , CostCenter1_ID, CostCenter2_ID, Employee_ID);
                    clsEvent.GLCode_TextChanged(pbxSVat, "Accept");
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
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

        private void frm_accAccountpayableNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
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

    }
}


//#region Fill Product Details
//private void FillDetailsProduct(string sID)
//{
//    try
//    {
//        if (sID.Length > 0)
//        {
//            tbl_genItemMaster detail = tbl_genItemMaster.Select(sID);
//            if (detail != null)
//            {                      
//                if (!IsUpdate)
//                {

//                }                        

//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
//#endregion            

//private bool CheckValidityAPN()
//{
//    string strMessage = "";
//    bool bStatus = true;
//    try
//    {
//        if (txtAPNID.TextLength == 0)
//        {
//            strMessage += "\n" + "APN No ";
//            bStatus = false;
//        }

//        if (bStatus == false)
//            MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//    return bStatus;
//}

//#region Validate GL TextBoxes
//private void ValidateGLTextBox(TextBox txtGlCode)
//{
//    try
//    {
//        if (txtGlCode.Text.Trim().Length == 0)                
//            txtGlCode.Text = "default";
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
//#endregion

//private void txtEmployeeID_DoubleClick(object sender, EventArgs e)
//{
//    if (CheckValiditySubTotal())
//    {
//        //clearSubGLCodeExceptThis("Employee");
//        //clsSearch.Search_MasterEmployee(ref txtOtherCr);
//        //if (txtOtherCr.Tag != null)
//        //{
//        //    FillGLAccountBEmployee();
//        //}
//    }            
//}
//private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
//{
//    Search_CheckedBy();
//}

//private void txtJobID_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F1)
//        Search_JobID();
//}

//private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F1)
//        Search_CheckedBy();
//}
//private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
//{
//    //if (e.KeyCode == Keys.F1) 
//    //{
//    ////    txtEmployeeID_DoubleClick(sender, e);
//    //}
//} 
//private void txtCostCenter1_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F1)           
//        txtCostCenter1_DoubleClick(sender, e);          
//}

//private void txtCostCenter2_KeyDown(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.F1)              
//        txtCostCenter2_DoubleClick(sender, e);         
//}


//private void Search_JobTemplate()
//{
//    try
//    {
//        frm_sasJobRegisterTemplate detail = new frm_sasJobRegisterTemplate();
//        detail.ShowDialog();
//        txtSupplierID.Text = glbJobID;                
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
//private void Search_JobID()
//{
//    try
//    {
//        Form frmhelpsearch = new frmSearchTransaction();
//        clsSearch.passValue_JobRegister_Normal();
//        frmhelpsearch.ShowDialog();

//        if (frmSearchTransaction.s_SearchText.Length > 0)
//            txtAPNID.Tag = frmSearchMaster.s_SearchID;

//        if (frmSearchTransaction.s_SearchID.Length > 0)
//        {
//            txtAPNID.Text = frmSearchTransaction.s_SearchID;
//            FillDetails(frmSearchTransaction.s_SearchID);
//        }
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
#region old method
//private void Search_CheckedBy()
//{
//    try
//    {
//        frmSetChecked login = new frmSetChecked();
//        login.iFormID = iFormID;
//        login.ShowDialog();
//        if (frmSetChecked.bChecked)
//        {
//            bHasChecked = true;
//            glbCheckedDate = clsSecurity.getServerDateTime();
//            dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
//            dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
//            txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
//            txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
//            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
//            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
//        }
//        else if (frmSetChecked.bReset)
//        {
//            txtCheckedBy.Text = "";
//            txtCheckedBy.Tag = null;
//            bHasChecked = false;
//            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
//            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
//        }
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
#endregion
//private void FillGLAccountBEmployee()
//{

//    txtSupplierID.Tag = null;
//    txtSupplierID.Clear();

//    tbl_genEmployeeMaster EmpDetail = tbl_genEmployeeMaster.Select(txtOtherCr.Tag.ToString());
//    if (EmpDetail != null)
//    {
//        if (EmpDetail.Gl_ID != "default")
//            CusSupEmpCode = txtOtherCr.Text.Trim();
//    }
//}

//private void Search_AccountForDeposit(TextBox myTextBox)
//{
//    try
//    {
//        Form frmhelpsearch = new frmSearchTransaction();                
//        clsSearch.passValue_CompanyAccount();

//        frmhelpsearch.ShowDialog();
//        if (frmSearchTransaction.s_SearchID.Length > 0)
//        {
//            if (frmSearchTransaction.s_SearchText.Length > 0)
//                myTextBox.Text = frmSearchTransaction.s_SearchID +" - " + frmSearchTransaction.s_SearchText;
//            if (frmSearchTransaction.s_SearchID.Length > 0)
//                myTextBox.Tag = frmSearchTransaction.s_SearchID;                    
//        }
//    }

//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);

//    }
//}
#region old method
//private void Search_ApprovedBy()
//{
//    try
//    {
//        frmSetChecked login = new frmSetChecked();
//        login.iFormID = iFormID;
//        login.ShowDialog();
//        if (frmSetChecked.bChecked)
//        {
//            bHasApproved = true;
//            glbApprovedDate = clsSecurity.getServerDateTime();
//            dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
//            dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
//            txtApprovedBy.Text = frmSetChecked.sCheckedUserName;
//            txtApprovedBy.Tag = frmSetChecked.sCheckedUserID;
//            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
//            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
//        }
//        else if (frmSetChecked.bReset)
//        {
//            txtApprovedBy.Text = "";
//            txtApprovedBy.Tag = null;
//            bHasApproved = false;
//            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
//            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
//        }
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
#endregion
//private bool IsValidateGridIsExsistingRow(string sNewAcctCode)
//{
//    bool isExisting = true;
//    foreach (DataGridViewRow row in dgvDetail.Rows)
//    {
//        string sAcctCode = "";
//        sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "default");

//        if (sAcctCode == sNewAcctCode)
//        {
//            isExisting = false;
//            break;
//        }
//    }
//    if (isExisting==false)
//    {
//        MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);                
//    }
//    return isExisting;
//}
//private void RemoveGridIsExsistingRow()
//{   
//    bool isExisting = false;
//    foreach (DataRow Row in glb_dtSubTotal.Rows)
//    {
//        string sNewAcctCode = Row["GLCode"].ToString();

//        isExisting = false;

//        //check whether exist 
//        foreach (DataGridViewRow row in dgvDetail.Rows)
//        {
//            string sAcctCode = "";
//            sAcctCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "default");

//            if (sAcctCode == sNewAcctCode)
//            {
//                isExisting = true;
//                break;
//            }                    
//        }

//        if (isExisting)
//        {
//            //remove from table
//           // Row.;                    
//        }                
//    }

//    if (isExisting == true)
//    {
//        MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
//    }            
//}
//private void SavePV_GLCode(DataTable dtDataTable, string sPostingID, bool bIsCredit)
//{
//    string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sEmployee = "", sOtherCr = "", sCategoryID = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "";
//    int iRowNo;
//    decimal dGLAmount = 0;


//    foreach (DataRow dRow in dtDataTable.Rows)  //Cash
//    {
//        iRowNo = int.Parse(dRow["Line_No"].ToString());
//        sGLCode = dRow["GLCode"].ToString();
//        sSubAcct1 = dRow["SubAcct1"].ToString();
//        sSubAcct2 = dRow["SubAcct2"].ToString();
//        sSubAcct1_ID = dRow["SubAcct1_ID"].ToString();
//        sSubAcct2_ID = dRow["SubAcct2_ID"].ToString();
//        sEmployee = dRow["Employee"].ToString();
//        sEmployee_ID = dRow["Employee_ID"].ToString();
//        sOtherCr = dRow["OtherCr"].ToString();
//        sCategoryID = dRow["CategoryID"].ToString();
//        dGLAmount = Convert.ToDecimal(dRow["GLAmount"]);

//        tbl_accAccountPayableNote_SubTotal detail = tbl_accAccountPayableNote_SubTotal.Select(iRowNo, txtAPNID.Text.Trim(), sCategoryID, sGLCode);

//        #region update tbl_accAccountPayableNote_SubTotal
//        if (detail != null)
//        {
//            tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRowNo, txtAPNID.Text.Trim(), sCategoryID,
//                sGLCode, sOtherCr, txtSupplierID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dGLAmount, bIsCredit);
//            Insdetail.Update();
//        }
//        #endregion

//        #region Insert tbl_accAccountPayableNote_SubTotal
//        else
//        {
//            tbl_accAccountPayableNote_SubTotal Insdetail = new tbl_accAccountPayableNote_SubTotal(iRowNo, txtAPNID.Text.Trim(), sCategoryID,
//                sGLCode, sOtherCr, txtSupplierID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dGLAmount, bIsCredit);
//            Insdetail.Insert();
//        }
//        #endregion

//        #region GL Posting Detail
//        //clsProcessMethods.GLPostingDetailTemp(iRowNo, sPostingID, clsAutocode.getAccSlotID(AccSlot.AccountPayableNote), txtAPNID.Text.Trim(), sGLCode,
//        //                sSubAcct1_ID, sSubAcct2_ID, "default", txtSupplierID.Tag.ToString(), sEmployee_ID, "default", "-", txtAPNID.Text.Trim(), "default",
//        //                dtpAPNDate.Value, txtNarration.Text.Trim(), dGLAmount, bIsCredit);
//        #endregion
//    }
//}