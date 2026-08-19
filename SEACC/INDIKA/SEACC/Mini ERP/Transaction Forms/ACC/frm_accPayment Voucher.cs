using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
//using Zion.ERP.Reports.DataSets.ACC;
using System.Drawing;
using Zion.ERP.Reports.DataSets;
using ZION.ERP.Reports.DataSets.ACC;

namespace Digiteq
{
    public partial class frm_accPaymentVoucher : SEACC_Form
    {
        
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
        //string sFormConfigCode;
        //public int iFormID;
        decimal dGridAmount = 0;
        decimal dExRate = 0;
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbCustomerOrderID = "", glbQuotationID = "";
        public string glbPamentVoucher = "", glbRefundableID = "";
        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;

        private bool bIsLockChequeDetails;

        public bool bActiveProcessFlowAPN = false;

        string sFormConfigBatchCode;
        //    DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //     DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        dts_accPaymentVoucher glb_dts_accPaymentVoucher = new dts_accPaymentVoucher();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        public TextBox txtBalance { get; set; }
        //for Bank Accounts
        DataTable glb_dtSubTotal;

        DataTable glb_dtCash;
        DataTable glb_dtCheque;
        DataTable glb_dtOther_Cr;
        DataTable glb_dtSupplier;

        DataTable dtAPNDetail_old = new DataTable();
        clsAlerts_Email email = new clsAlerts_Email();
        //frmMultipleCheque MC = new frmMultipleCheque();


        #region From Load
        public frm_accPaymentVoucher(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accPaymentVoucher);
            sFormConfigBatchCode = clsAutocode.getFormConfigCode(FormName.accBatchPosting);

            dtAPNDetail_old.Columns.Add("APNID", typeof(string));
            dtAPNDetail_old.Columns.Add("Amount", typeof(int));

            //iFormID = clsSecurity.getFormID(FormName.accPaymentVoucher);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //    bNoAccess = true;

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        //public frm_accPaymentVoucher(FormName enmForms)
        //{
        //    sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accPaymentVoucher);
        //    sFormConfigBatchCode = clsAutocode.getFormConfigCode(FormName.accBatchPosting);

        //    iFormID = clsSecurity.getFormID(enmForms);
        //    if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
        //        bNoAccess = true;

        //    InitializeComponent();
        //}

        private void frm_trnPayment_Voucher_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //clsFormatter.setFormatForm(this, "Payment Voucher [PV]", 6, iFormID);

            CreateDataTable(TransactionCategory.Cash);
            CreateDataTable(TransactionCategory.Cheque);
            CreateDataTable(TransactionCategory.Other_Cr);
            CreateDataTable(TransactionCategory.Supplier);

            CusDataGridViewFormat();
            clsConfig.bIsCompanyChequeBankType = true;
            ClearFileds();
            if (glbPamentVoucher.Length > 0)
                FillDetails(glbPamentVoucher);
            else if (glbRefundableID.Length > 0)
            {
                tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(glbRefundableID);
                if (detail != null)
                {
                    txtRefundebleNoteId.Tag = detail.DebitNote_ID;
                    txtRefundebleNoteId.Text = detail.DebitNote_ID;

                    if (txtRefundebleNoteId.Tag != null && txtRefundebleNoteId.Tag.ToString().Trim().Length > 0)
                    {
                        if (IsValidateGridIsExsistingRow(txtRefundebleNoteId.Tag.ToString()))
                            FillDetailByCRN(txtRefundebleNoteId.Text.Trim());

                    }
                }
            }

            //if(glbPamentVoucher != "")
            //{
            //    clsHelpMethods.SetProcessFlowAPN(glbPamentVoucher, txtFlow2Quotation);
            //}

        }
        #endregion

        #region Btn Clear
        private void frm_accPaymentVoucher_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFileds();
        }
        #endregion

        #region Btn Save
        private void frm_accPaymentVoucher_SF_saveButton_Click(object sender, EventArgs e)
        {
            bool saveDone = false;
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    #region Update Records
                    if (IsUpdate)
                    {
                        tbl_accPaymentVoucher oldRecord = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
                        if (oldRecord != null)
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    tbl_accChequeRegister chequedetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(oldRecord.PaymentVoucher_ID).Where(p => !p.IsDeleted).ToList().FirstOrDefault();
                                    if (chequedetails != null && chequedetails.ChequeStatus_ID == "0" ||
                                        (oldRecord.CashAmount > 0))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPaymentVoucherID.Text))
                                        {

                                            clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);

                                            #region Delete & Insert Detail - APN/CreditNote + Settlement

                                            string sAPNorCreditNo = "";
                                            decimal dApnAmountOld = 0;
                                            DateTime dtmPostingDate = dtpVoucherDate.Value;

                                            clsHelpMethods_Local.RemoveAPNSattlementsFrom_PaymentVoucherID(
                                                oldRecord.PaymentVoucher_ID);
                                            tbl_accPaymentVoucher_Detail.DeleteAllByPaymentVoucher_ID(
                                                txtPaymentVoucherID.Text.ToString().Trim());
                                            dtAPNDetail_old.Clear();

                                            #endregion

                                            #region Delete & Insert Cheque Detials

                                            string sChequeNo = "", sRegisterID = "";
                                            if (decimal.Parse(txtChequeAmount.Text.Trim()) > 0)
                                            {
                                                string BankID = "",
                                                    BranchID = "",
                                                    AccountNo = "",
                                                    chequeType = "",
                                                    sRemark = "";
                                                DateTime dCDate = dtpVoucherDate.Value;
                                                decimal Amount;

                                                foreach (DataRow dRow in frmMultipleCheque.dtRecodes.Rows)
                                                {
                                                    sRegisterID = dRow["ChequeRegisterID"].ToString();
                                                    sChequeNo = dRow["ChequeNo"].ToString();
                                                    BankID = dRow["BankID"].ToString();
                                                    BranchID = dRow["BranchID"].ToString();
                                                    AccountNo = dRow["AccountNo"].ToString();
                                                    chequeType = dRow["ChequeType"].ToString();
                                                    dCDate = DateTime.Parse(dRow["ChequeDate"].ToString());
                                                    Amount = Convert.ToDecimal(dRow["Amount"]);
                                                    dtmPostingDate = dCDate;
                                                    sRemark = dRow["Remarks"].ToString();

                                                    int iCompanyAccount_ID =
                                                        clsGenaralName.getName_CompanyAccount_IDByAccountNo(AccountNo);

                                                    if (chequedetails.PrintCount == 0)
                                                    {

                                                        #region acc Payment Voucher Cheque Amount Update

                                                        tbl_accPaymentVoucher_ChequeAmount PVCdetail =
                                                            tbl_accPaymentVoucher_ChequeAmount.Select(
                                                                txtPaymentVoucherID.Text.ToString(), AccountNo);
                                                        if (PVCdetail != null)
                                                        {
                                                            tbl_accPaymentVoucher_ChequeAmount JVdetail =
                                                                new tbl_accPaymentVoucher_ChequeAmount(
                                                                    txtPaymentVoucherID.Text.Trim(), AccountNo, Amount);
                                                            JVdetail.Update();
                                                        }
                                                        else
                                                        {
                                                            tbl_accPaymentVoucher_ChequeAmount JVdetail =
                                                                new tbl_accPaymentVoucher_ChequeAmount(
                                                                    txtPaymentVoucherID.Text.Trim(), AccountNo, Amount);
                                                            JVdetail.Insert();
                                                        }

                                                        #endregion

                                                        #region Update tbl_accChequeRegister


                                                        tbl_accChequeRegister objCheque =
                                                            tbl_accChequeRegister.Select(sRegisterID);
                                                        if (objCheque != null)
                                                        {
                                                            if (iCompanyAccount_ID != objCheque.CompanyAccount_ID)
                                                            {
                                                                sRegisterID =
                                                                    clsAutocode.getAutoGeneratedCode_ChequeRegisterNo(
                                                                        AccountNo);
                                                                objCheque.IsDeleted = true;
                                                                objCheque.ChequeStatus_ID =
                                                                    clsAutocode.getChequeStatusID(ChequeStatus.Deleted);
                                                                objCheque.Update();
                                                            }
                                                            else
                                                                objCheque.Delete();

                                                            //tbl_accChequeRegister objNewCheque = new tbl_accChequeRegister(sRegisterID, sRemark, txtPayee.Text.Trim(), dtpVoucherDate.Value, dCDate, iCompanyAccount_ID, sChequeNo, clsAutocode.getChequeStatusID(ChequeStatus.New), chequeType,
                                                            //    "default", txtPaymentVoucherID.Text.ToString(), clsSecurity.FinancialYearID, clsSecurity.CompanyID, Amount,
                                                            //    objCheque.CreateUser_ID, clsSecurity.UserIDLoged, objCheque.CheckedUser_ID, objCheque.ApprovedUser_ID, objCheque.DeletedUser_ID, objCheque.PrintedUser_ID,
                                                            //    objCheque.CreateTerminal_ID, clsSecurity.TerminalID, objCheque.DeletedTerminal_ID, objCheque.PrintedTerminal_ID,
                                                            //    objCheque.DateCreate, clsSecurity.getServerDateTime(), objCheque.DateChecked, objCheque.DateApproved, objCheque.DateDeleted, objCheque.DatePrinted,
                                                            //    objCheque.IsChecked, objCheque.IsApproved, objCheque.IsFinished, objCheque.IsDeleted, objCheque.IsLocked, objCheque.IsSeattled,
                                                            //    objCheque.PrintCount, objCheque.SetteledAmount, objCheque.ReconcilationDate, objCheque.RecSerialNo);
                                                            //objNewCheque.Update();
                                                        }
                                                        else
                                                            sRegisterID =
                                                                clsAutocode.getAutoGeneratedCode_ChequeRegisterNo(
                                                                    AccountNo);
                                                        //  else
                                                        // {


                                                        tbl_accChequeRegister objNewCheque = new tbl_accChequeRegister(
                                                            sRegisterID, sRemark, txtPayee.Text.Trim(),
                                                            dtpVoucherDate.Value, dCDate, iCompanyAccount_ID, sChequeNo,
                                                            clsAutocode.getChequeStatusID(ChequeStatus.New), chequeType,
                                                            "default", txtPaymentVoucherID.Text.ToString(),
                                                            clsSecurity.FinancialYearID, clsSecurity.CompanyID, Amount,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default",
                                                            "default",
                                                            clsSecurity.TerminalID, clsSecurity.TerminalID, "default",
                                                            "default",
                                                            clsSecurity.getServerDateTime(),
                                                            clsSecurity.getServerDateTime(), glbCheckedDate,
                                                            glbApprovedDate, clsSecurity.getServerDateTime(),
                                                            clsSecurity.getServerDateTime(),
                                                            false, false, false, false, false, false, 0, 0,
                                                            clsSecurity.getServerDateTime(), -1);
                                                        objNewCheque.Insert();
                                                        // }

                                                        #endregion

                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("This cheque is already printed",
                                                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information);
                                                        break;
                                                    }
                                                }
                                            }

                                            #endregion

                                            #region Insert Payment Voucher Detail

                                            foreach (DataGridViewRow row in dgvAPN.Rows)
                                            {
                                                int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(
                                                    clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                                                sAPNorCreditNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode",
                                                    row.Index, "default");
                                                dApnAmountOld = decimal.Parse(
                                                    clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, "0"));
                                                dtAPNDetail_old.Rows.Add(sAPNorCreditNo, dApnAmountOld);

                                                tbl_accPaymentVoucher_Detail details = new tbl_accPaymentVoucher_Detail(
                                                    iLineNo, txtPaymentVoucherID.Text,
                                                    (txtAPNID.Enabled ? sAPNorCreditNo : "default"),
                                                    (sRegisterID == "" ? "Default" : sRegisterID), "Default",
                                                    (txtRefundebleNoteId.Enabled ? sAPNorCreditNo : "default"),
                                                    "default", -1, "default", -1, "", dApnAmountOld, false);
                                                details.Insert();
                                            }

                                            #endregion

                                            #region Update Payment Voucher SubTotal

                                            dtmPostingDate =
                                                (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                                    ? dtmPostingDate
                                                    : dtpVoucherDate.Value;

                                            //#region Update GLPostingHeaderTemp
                                            //clsProcessMethods.GLPostingHeaderTempUpdate(oldRecord.GlPosting_ID, dtmPostingDate, txtNarration.Text.Trim());
                                            //#endregion

                                            foreach (tbl_accPaymentVoucher_SubTotal PVSubTotal in
                                                tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(
                                                    txtPaymentVoucherID.Text.ToString()))
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
                                                    sRemarks = ""; // sEmployee = "",
                                                bool bIsCredit = false;
                                                decimal dAmount = 0;
                                                bool bHasItemInDB = false;

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode",
                                                        row.Index, "");
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
                                                    sOtherCr = clsValidate.ValidateGridTag(dgvDetail, "otherCr",
                                                        row.Index, "default");
                                                    bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit",
                                                        row.Index, true);
                                                    iRow = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                        int.Parse("0"));

                                                    if (bIsCredit)
                                                        dAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                            "creditAmount", row.Index, decimal.Parse("0.00"));
                                                    else
                                                        dAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                            "debitAmount", row.Index, decimal.Parse("0.00"));

                                                    if (iRow == PVSubTotal.Line_No &&
                                                        PVSubTotal.PaymentVoucher_ID ==
                                                        txtPaymentVoucherID.Text.Trim() &&
                                                        sCategoryID == PVSubTotal.Tc_ID && sGLCode == PVSubTotal.Gl_ID)
                                                    {
                                                        bHasItemInDB = true;
                                                        dgvDetail.Rows.RemoveAt(row.Index);
                                                        break; //database contain this item
                                                    }
                                                }

                                                if (bHasItemInDB)
                                                {
                                                    PVSubTotal.Line_No = iRow;
                                                    PVSubTotal.Gl_ID = sGLCode;
                                                    PVSubTotal.CostCenter1_ID = sSubAcct1_ID;
                                                    PVSubTotal.CostCenter2_ID = sSubAcct2_ID;
                                                    PVSubTotal.Employee_ID = sEmployee_ID;
                                                    PVSubTotal.Customer_ID = sOtherCr;
                                                    PVSubTotal.Tc_ID = sCategoryID;
                                                    PVSubTotal.Amount = dAmount;
                                                    PVSubTotal.Remarks = sRemarks;
                                                    PVSubTotal.Update();

                                                    //#region GL Posting Detail
                                                    //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.PaymetVoucher), txtPaymentVoucherID.Text.Trim(), sGLCode,
                                                    //                sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtPaymentVoucherID.Text.Trim(), "default",
                                                    //              dtmPostingDate, txtNarration.Text.Trim() == "" ? sRemarks : txtNarration.Text.Trim(), dAmount, bIsCredit, sChequeNo, txtPayee.Text.Trim());
                                                    //#endregion
                                                }
                                                else
                                                {
                                                    //clsProcessMethods.GLPostingDetailTempDelete(PVSubTotal.Line_No, oldRecord.GlPosting_ID);
                                                    PVSubTotal.Delete();
                                                }
                                            }

                                            #endregion

                                            #region  newly Insert Detail - Journal Details

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                int iRow;
                                                string sGLCode = "",
                                                    sSubAcct1 = "",
                                                    sSubAcct2 = "",
                                                    sSubAcct1_ID = "",
                                                    sSubAcct2_ID = "",
                                                    sEmployee = "",
                                                    sEmployee_ID = "",
                                                    sOtherCr = "",
                                                    sCategoryID = "",
                                                    sRemarks = "",
                                                    sApnId = "";
                                                bool bIsCredit;
                                                decimal dAmount;

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
                                                sApnId = clsValidate.ValidateGridTag(dgvDetail, "APNID", row.Index,
                                                    "default");
                                                if (bIsCredit)
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount",
                                                        row.Index, decimal.Parse("0.00"));
                                                else
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount",
                                                        row.Index, decimal.Parse("0.00"));

                                                #region Insert tbl_accPaymentVoucher_SubTotal

                                                tbl_accPaymentVoucher_SubTotal Insdetail =
                                                    new tbl_accPaymentVoucher_SubTotal(iRow,
                                                        txtPaymentVoucherID.Text.Trim(), sCategoryID,
                                                        sGLCode, sOtherCr, "Default", sEmployee_ID, "default",
                                                        sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit, sApnId,
                                                        sRemarks);
                                                Insdetail.Insert();

                                                #endregion

                                                //#region GL Posting Detail
                                                //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.PaymetVoucher), txtPaymentVoucherID.Text.Trim(), sGLCode,
                                                //                    sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtPaymentVoucherID.Text.Trim(), "default",
                                                //                   dtmPostingDate, txtNarration.Text.Trim(), dAmount, bIsCredit, sChequeNo, txtPayee.Text.Trim());
                                                //#endregion
                                            }

                                            #endregion

                                            #region  Update Header - tbl_accPaymentVoucher

                                            tbl_accPaymentVoucher detail = new tbl_accPaymentVoucher(
                                                txtPaymentVoucherID.Text.Trim(), dtpVoucherDate.Value,
                                                txtRemarks.Text.Trim(), txtNarration.Text.Trim(), txtPayee.Text.Trim(),
                                                "default", "default", txtOtherCreditor.Tag.ToString(),
                                                txtSupplierID.Tag.ToString().Trim(),
                                                txtEmployeeID.Tag.ToString().Trim(), "default",
                                                txtCostCenter1.Tag.ToString().Trim(),
                                                txtCostCenter2.Tag.ToString().Trim(), "defaut", "default",
                                                oldRecord.GlPosting_ID,
                                                clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                                clsSecurity.FinancialYearID, txtCurrencyID.Tag.ToString().Trim(),
                                                decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtCashAmount.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtChequeAmount.Text.Trim()), txtCurrencyRate),
                                                GetPVAmount(), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                oldRecord.DeletedUser_ID,
                                                oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID,
                                                clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID,
                                                oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                                                clsSecurity.getServerDateTime(), oldRecord.DateChecked,
                                                oldRecord.DateApproved,
                                                oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsChecked,
                                                oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                                oldRecord.IsLocked, false, chkAdvancedPV.Checked ? true : false,
                                                oldRecord.PrintCount, 0, oldRecord.CompanyID,
                                                oldRecord.CompanyBranch_ID, txtAPNType.Tag.ToString());
                                            detail.Update();

                                            //Update supplier outstanding amount
                                            //  clsHelpMethods.updateRecords_SupplierOutstandingTracking(txtSupplierID.Tag.ToString(), txtPaymentVoucherID.Text.Trim(), clsAutocode.GetProcessNoteID(ProcessNote.PaymentVoucher), dtpVoucherDate.Value, decimal.Parse(txtCreditAmount.Text.Trim()), 0,false,iFormID);
                                            //      clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString(), oldRecord.TotalAmount, 0, true);
                                            //       clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, false);

                                            #endregion

                                            #region Update Detail tbl_accPaymentVoucher_PO

                                            List<tbl_accPaymentVoucher_PO> oPV_PO = tbl_accPaymentVoucher_PO.SelectAll()
                                                .Where(p => p.PaymentVoucher_ID == oldRecord.PaymentVoucher_ID)
                                                .ToList();
                                            if (oPV_PO.Count > 0)
                                            {
                                                foreach (tbl_accPaymentVoucher_PO oldDetailPV_PO in oPV_PO)
                                                {
                                                    string sPONo = "";
                                                    decimal dPOAmount = 0;

                                                    foreach (DataGridViewRow row in dgvPO.Rows)
                                                    {
                                                        sPONo = clsValidate.ValidateGridValue(dgvPO, "PONo", row.Index,
                                                            "default");
                                                        dPOAmount = clsValidate.ValidateGridValue(dgvPO, "Amount",
                                                            row.Index, decimal.Parse("0"));

                                                        //dgvPO.Rows.RemoveAt(row.Index);
                                                        //tbl_accPaymentVoucher_PO detailPV_PO = new tbl_accPaymentVoucher_PO(sPONo, txtPaymentVoucherID.Text, dPOAmount);
                                                        //detailPV_PO.Insert();
                                                    }

                                                    oldDetailPV_PO.Delete();
                                                }
                                            }

                                            if (txtPONo != null)
                                            {
                                                foreach (DataGridViewRow row in dgvPO.Rows)
                                                {
                                                    string sPONo = "";
                                                    decimal dPOAmount = 0;

                                                    sPONo = clsValidate.ValidateGridValue(dgvPO, "PONo", row.Index,
                                                        "default");
                                                    dPOAmount = clsValidate.ValidateGridValue(dgvPO, "Amount",
                                                        row.Index, decimal.Parse("0"));

                                                    tbl_accPaymentVoucher_PO detailPV_PO =
                                                        new tbl_accPaymentVoucher_PO(sPONo, txtPaymentVoucherID.Text,
                                                            dPOAmount);
                                                    detailPV_PO.Insert();
                                                }
                                            }

                                            #endregion

                                            #region  Update Settlement details

                                            clsHelpMethods_Local.AutoSettledAPN_WithCheque_PV(txtPaymentVoucherID.Text);

                                            #endregion

                                            //Attachments.Remove(iFormID, oldRecord.PaymentVoucher_ID);
                                            //Attachments.Insert(iFormID, oldRecord.PaymentVoucher_ID);

                                            clsMethods_GL.PostTransaction_PV(txtPaymentVoucherID.Text.Trim());

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                        }
                                    }

                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked) + "\nThis Cheque is already Reconciled..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //}
                                    //else
                                    //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked) + "\nYou cannot change total amount as the cheque is printed…", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    #endregion

                    #region Insert Records
                    else
                    {
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtPaymentVoucherID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPaymentVoucherID.Text)) //(txtPaymentVoucherID.Text.Length > 0)
                        {
                            #region Insert Header PV
                            tbl_accPaymentVoucher detail = new tbl_accPaymentVoucher(txtPaymentVoucherID.Text.Trim(), dtpVoucherDate.Value, txtRemarks.Text.Trim(), txtNarration.Text.Trim(), txtPayee.Text.Trim(), "default", "default", txtOtherCreditor.Tag.ToString(),
                                txtSupplierID.Tag.ToString().Trim(), txtEmployeeID.Tag.ToString().Trim(), "default", txtCostCenter1.Tag.ToString().Trim(), txtCostCenter2.Tag.ToString().Trim(), "defaut", "default", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                clsSecurity.FinancialYearID, txtCurrencyID.Tag.ToString().Trim(), decimal.Parse(txtCurrencyRate.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtCashAmount.Text.Trim()), txtCurrencyRate),
                                clsHelpMethods_Local.getSavePrice(decimal.Parse(txtChequeAmount.Text.Trim()), txtCurrencyRate), GetPVAmount(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged,
                                clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, chkAdvancedPV.Checked ? true : false, 0, 0, clsSecurity.CompanyID, clsSecurity.BranchID,
                                txtAPNType.Tag.ToString());
                            detail.Insert();
                            //
                            //                clsBackProcess.UpdateSupplierMaster_OutstandingAmount(txtSupplierID.Tag.ToString().Trim(), decimal.Parse(txtCreditAmount.Text.Trim()), 0, false);
                            #endregion

                            #region Insert Cheque Detials
                            string sChequeNo = "", sRegisterID = "";

                            if (decimal.Parse(txtChequeAmount.Text.Trim()) > 0)
                            {
                                string BankID = "", BranchID = "", AccountNo = "", chequeType = "", sRemark = "";
                                sRegisterID = "";
                                DateTime dCDate;
                                decimal Amount;

                                foreach (DataRow dRow in frmMultipleCheque.dtRecodes.Rows)
                                {
                                    sRegisterID = dRow["ChequeRegisterID"].ToString();
                                    sChequeNo = dRow["ChequeNo"].ToString();
                                    BankID = dRow["BankID"].ToString();
                                    BranchID = dRow["BranchID"].ToString();
                                    AccountNo = dRow["AccountNo"].ToString();
                                    chequeType = dRow["ChequeType"].ToString();
                                    dCDate = DateTime.Parse(dRow["ChequeDate"].ToString());
                                    Amount = Convert.ToDecimal(dRow["Amount"]);
                                    sRemark = dRow["Remarks"].ToString();
                                    int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(AccountNo);
                                    tbl_accPaymentVoucher_ChequeAmount details = new tbl_accPaymentVoucher_ChequeAmount(txtPaymentVoucherID.Text.Trim(), AccountNo, Amount);
                                    details.Insert();
                                    if (sRegisterID.Length == 0 || !IsUpdate)
                                    {
                                        // if (clsAutocode.IsAutoGenerated(clsAutocode.getFormConfigCode(FormName.accChequeRegister)))
                                        sRegisterID = clsAutocode.getAutoGeneratedCode_ChequeRegisterNo(AccountNo);
                                    }
                                    tbl_accChequeRegister objCheque = tbl_accChequeRegister.Select(sRegisterID);
                                    if (objCheque == null)
                                    {
                                        tbl_accChequeRegister objNewCheque = new tbl_accChequeRegister(sRegisterID, sRemark, txtPayee.Text.Trim(), dtpVoucherDate.Value, dCDate, iCompanyAccount_ID, sChequeNo, clsAutocode.getChequeStatusID(ChequeStatus.New), chequeType, "default",
                                            txtPaymentVoucherID.Text.ToString(), clsSecurity.FinancialYearID, clsSecurity.CompanyID, Amount, clsSecurity.UserIDLoged,
                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.TerminalID, clsSecurity.TerminalID, "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                            glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, 0, 0, clsSecurity.getServerDateTime(), -1);
                                        objNewCheque.Insert();
                                    }
                                }
                            }
                            #endregion

                            #region  Insert Detail - Journal Details
                            int iRow;
                            string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "", sApnId = "";
                            bool bIsCredit;
                            decimal dAmount;

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
                                sApnId = clsValidate.ValidateGridValue(dgvDetail, "APNID", row.Index, "default");
                                if (bIsCredit)
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                else
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                #region  tbl_accPaymentVoucher_SubTotal
                                tbl_accPaymentVoucher_SubTotal Insdetail = new tbl_accPaymentVoucher_SubTotal(iRow, txtPaymentVoucherID.Text.Trim(), sCategoryID,
                                sGLCode, sOtherCr, txtSupplierID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit, sApnId, sRemarks);
                                Insdetail.Insert();
                                #endregion
                            }
                            #endregion

                            #region Insert Detail - APN/CreditNote + Settlement
                            string sDocumentNo = "";
                            decimal dApnAmount = 0;

                            foreach (DataGridViewRow row in dgvAPN.Rows)
                            {
                                int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                                sDocumentNo = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "default");
                                dApnAmount = clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, decimal.Parse("0"));
                                tbl_accPaymentVoucher_Detail details = new tbl_accPaymentVoucher_Detail(iLineNo, txtPaymentVoucherID.Text, (txtAPNID.Enabled ? sDocumentNo : "default"), (sRegisterID == "" ? "Default" : sRegisterID), "Default", (txtRefundebleNoteId.Enabled ? sDocumentNo : "default"), "default", -1, "default", -1, "", dApnAmount, false);
                                details.Insert();
                            }
                            clsHelpMethods_Local.AutoSettledAPN_WithCheque_PV(txtPaymentVoucherID.Text);
                            #endregion

                            #region Insert Detail tbl_accPaymentVoucher_PO
                            if (txtPONo.Tag != null)
                            {
                                string sPONo = "";
                                decimal dPOAmount = 0;

                                foreach (DataGridViewRow row in dgvPO.Rows)
                                {
                                    sPONo = clsValidate.ValidateGridValue(dgvPO, "PONo", row.Index, "default");
                                    dPOAmount = clsValidate.ValidateGridValue(dgvPO, "Amount", row.Index, decimal.Parse("0"));
                                    tbl_accPaymentVoucher_PO detailPV_PO = new tbl_accPaymentVoucher_PO(sPONo, txtPaymentVoucherID.Text, dPOAmount);
                                    detailPV_PO.Insert();
                                }
                            }
                            #endregion

                            clsMethods_GL.PostTransaction_PV(txtPaymentVoucherID.Text.Trim());
                            Attachments.Insert(txtPaymentVoucherID.Text.ToString());

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            saveDone = true;
                            email.createEmail_PV(txtPaymentVoucherID.Text.ToString(), enum_Alerts.PaymentVoucherCreated);
                        }
                        //else
                        //    MessageBox.Show("Voucher Number " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_accPaymentVoucher Fdetail = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.ToString());
                    if (Fdetail != null)
                        FillDetails(Fdetail.PaymentVoucher_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_accPaymentVoucher_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_accPaymentVoucher_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region btn Delete
        private void frm_accPaymentVoucher_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                bool bstatus = false;

                if (txtPaymentVoucherID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        Cursor = Cursors.WaitCursor;
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Payment Voucher : " + txtPaymentVoucherID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            #region Update Other Tables
                                            #region tbl acc ChequeRegister Delete
                                            foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtPaymentVoucherID.Text.Trim()))
                                            {
                                                if (!oCheque.IsLocked && oCheque.ChequeStatus_ID == "0")
                                                {
                                                    oCheque.IsDeleted = true;
                                                    oCheque.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deleted);
                                                    oCheque.DateModified = clsSecurity.getServerDateTime();
                                                    oCheque.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    oCheque.Update();
                                                    bstatus = true;
                                                }
                                            }

                                            if (detail.CashAmount > 0)
                                                bstatus = true;

                                            #endregion
                                            #endregion

                                            if (bstatus)
                                            {
                                                clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                                #region  Un Settle Account Payable Note
                                                clsHelpMethods_Local.RemoveAPNSattlementsFrom_PaymentVoucherID(detail.PaymentVoucher_ID);
                                                #endregion

                                                detail.IsDeleted = true;
                                                detail.IsSeattled = false;
                                                detail.SettledAmount = 0;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                detail.Update();

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                email.createEmail_PV(txtPaymentVoucherID.Text.ToString(), enum_Alerts.PaymentVoucherCanceled);
                                                ClearFileds();
                                            }
                                            else
                                                MessageBox.Show("Payment Voucher Cannot be deleted as this cheque is Returned or Realized", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Btn Checked, Approved and History
        private void frm_accPaymentVoucher_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accPaymentVoucher_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accPaymentVoucher_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn APN Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAPN.SelectedCells.Count != 0)
                {
                    if (dgvAPN.Rows.Count > 0)
                    {
                        dgvAPN.Rows.RemoveAt(dgvAPN.SelectedCells[0].RowIndex);
                        setAPNsTotal();
                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNID, true);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Btn Remove
        private void btnremovePO_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPO.SelectedCells.Count != 0)
                {
                    if (dgvPO.Rows.Count > 0)
                    {
                        dgvPO.Rows.RemoveAt(dgvPO.SelectedCells[0].RowIndex);
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

        #region Btn Temp
        private void frm_accPaymentVoucher_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtPaymentVoucherID.TextLength > 0 && txtPaymentVoucherID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPaymentVoucherID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtNarration, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtRemarks, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtOtherCreditor, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtEmployeeID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurrencyID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRefundebleNoteId, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNType, true);

                txtAPNID.Text = "";
                txtPaymentVoucherID.Tag = null;
                dtpVoucherDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtPaymentVoucherID.Text = "<Auto Generate>";
                else
                    txtPaymentVoucherID.Clear();
                if (txtPaymentVoucherID.Enabled)
                {
                    txtPaymentVoucherID.SelectAll();
                    txtPaymentVoucherID.Focus();
                }

                dgvAPN.Rows.Clear();

                txtChqRefNo.Clear();

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvAPN, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_NewWithWhiteBackground(dgvPO, clsFormatter.colorGrid, UI_Color);

            //clsFormatter.ApplyGridFormat_New(dgvDetail, UI_Color, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fileds
        private void ClearFileds()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;
            llblChequePrint.Enabled = false;
            //llblChequeDetail.Enabled = true;
            bIsLockChequeDetails = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPaymentVoucherID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtNarration, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtRemarks, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtOtherCreditor, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtEmployeeID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurrencyID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRefundebleNoteId, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNType, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCashAmount, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOtherCreditor, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoCashAmount, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoChequeAmount, true);

            clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRefundableNote, true);

            clsCommon.SetEnableDisable_NormalCheckBox(chkAdvancedPV, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkNonAdvanced, true);

            txtPaymentVoucherID.Tag = null;
            txtOtherCreditor.Tag = null;
            txtSupplierID.Tag = null;
            txtCustomer.Tag = null;
            txtEmployeeID.Tag = null;
            txtCostCenter1.Tag = null;
            txtCostCenter2.Tag = null;
            txtCashAmount.Tag = null;
            txtChequeAmount.Tag = null;
            txtPONo.Tag = null;
            txtAPNType.Tag = null;

            txtEmployeeID_GLCode.Tag = null;
            txtCostCenter1_GLCode.Tag = null;
            txtCostCenter2_GLCode.Tag = null;
            txtCash_GLCode.Tag = null;
            txtCheque_GLCode.Tag = null;

            txtAPNID.Tag = null;
            txtRefundebleNoteId.Tag = null;
            txtCreditNote.Tag = null;

            txtOtherCreditor.Clear();
            txtSupplierID.Clear();
            txtCustomer.Clear();
            txtEmployeeID.Clear();
            txtCostCenter1.Clear();
            txtCostCenter2.Clear();

            txtEmployeeID_GLCode.Clear();
            txtCostCenter1_GLCode.Clear();
            txtCostCenter2_GLCode.Clear();
            txtAPNType.Clear();

            txtCashAmount.Clear();
            txtCash_GLCode.Clear();
            txtChequeAmount.Clear();
            txtCheque_GLCode.Clear();
            txtChqRefNo.Clear();

            dtpVoucherDate.Value = clsSecurity.getServerDateTime();

            txtPaymentVoucherID.Clear();
            txtNarration.Clear();
            txtRemarks.Clear();
            txtPayee.Clear();
            txtAPNID.Clear();
            txtRefundebleNoteId.Clear();
            txtCreditNote.Clear();
            txtPONo.Clear();

            txtChequeAmount.Text = "0.00";
            txtCashAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";
            txtChqRefNo.Text = "";

            pbxCashAmount.Enabled = false;
            chkShowSettle.Checked = false;
            rdoChequeAmount.Checked = true;
            chkNonAdvanced.Checked = false;
            chkAdvancedPV.Checked = false;
            chkPrintOriginal.Checked = false;

            dgvDetail.Rows.Clear();
            dgvPO.Rows.Clear();
            txtCreditAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";
            txtBalanceAmount.Text = "0.00";

            pbxSupplier.Image = Digiteq.Properties.Resources.accept;
            pbxEmployee.Image = Digiteq.Properties.Resources.accept;
            pbxOtherCr.Image = Digiteq.Properties.Resources.accept;
            pbxCashAmount.Image = Digiteq.Properties.Resources.accept;
            pbxChequeAmount.Image = Digiteq.Properties.Resources.accept;

            frmMultipleCheque.dtRecodes.Rows.Clear();
            frmMultipleCheque.bClear = false;

            glb_dtCheque.Rows.Clear();
            glb_dtCash.Rows.Clear();
            glb_dtSupplier.Rows.Clear();
            glb_dtOther_Cr.Rows.Clear();

            dGridAmount = 0;
            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            clsEvent.GLCode_TextChanged(pbxOtherCr, "");
            clsEvent.GLCode_TextChanged(pbxSupplier, "");
            clsEvent.GLCode_TextChanged(pbxEmployee, "");
            clsEvent.GLCode_TextChanged(pbxCashAmount, "");
            clsEvent.GLCode_TextChanged(pbxChequeAmount, "");

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPaymentVoucherID.Text = "<Auto Generate>";
            else
                txtPaymentVoucherID.Clear();
            if (txtPaymentVoucherID.Enabled)
            {
                txtPaymentVoucherID.SelectAll();
                txtPaymentVoucherID.Focus();
            }

            //chkSettings2.Checked = true;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            Attachments.Clear();

            dgvAPN.Rows.Clear();
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

                if (glb_dtCash.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxCashAmount, glb_dtCash, txtCashAmount, txtCurrencyRate);
                    foreach (DataRow row in glb_dtCash.Rows)
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
                        sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount, "");
                    }
                }
                if (glb_dtCheque.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxChequeAmount, glb_dtCheque, txtChequeAmount, txtCurrencyRate);
                    foreach (DataRow row in glb_dtCheque.Rows)
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
                        sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount, "");
                    }
                }
                if (glb_dtOther_Cr.Rows.Count > 0)
                {
                    TextBox txt;
                    if (decimal.Parse(txtChequeAmount.Text) > 0)
                        txt = txtChequeAmount;
                    else
                        txt = txtCashAmount;

                    clsEvent.GLCode_TextChanged(pbxOtherCr, glb_dtOther_Cr, txt, txtCurrencyRate);
                    foreach (DataRow row in glb_dtOther_Cr.Rows)
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
                        sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount, "");
                    }
                }
                if (glb_dtSupplier.Rows.Count > 0)
                {
                    TextBox txt;
                    if (decimal.Parse(txtChequeAmount.Text) > 0)
                        txt = txtChequeAmount;
                    else
                        txt = txtCashAmount;

                    clsEvent.GLCode_TextChanged(pbxSupplier, glb_dtSupplier, txt, txtCurrencyRate);
                    foreach (DataRow row in glb_dtSupplier.Rows)
                    {
                        string sAPNID = "";
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
                        sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();
                        sAPNID = row["APN_ID"].ToString();
                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount, sAPNID);
                    }
                }
                CalculateBalance();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                    tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(sID);
                    if (detail != null)
                    {
                        #region Currency
                        txtCurrencyID.Tag = detail.Currency_ID;
                        txtCurrencyID.Text = clsGenaralName.getName_Currency(detail.Currency_ID);
                        txtCurCode.Text = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        dExRate = detail.CurrencyRate;
                        #endregion

                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            btnDraft.Enabled = false;
                        }
                        else
                            btnDraft.Enabled = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPaymentVoucherID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOtherCreditor, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoCashAmount, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoChequeAmount, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCurrencyID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCurCode, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCurrencyRate, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtAPNType, false);

                        //tbl_accChequeRegister chequedetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(sID).ToList().FirstOrDefault();
                        //if (chequedetails != null && chequedetails.ChequeStatus_ID == "0")
                        //{
                        //    if (chequedetails.PrintCount != 0)
                        //        bIsLockChequeDetails = true;
                        //        //llblChequeDetail.Enabled = false;
                        //}

                        txtPaymentVoucherID.Tag = detail.PaymentVoucher_ID;
                        glbPamentVoucher = detail.PaymentVoucher_ID;
                        txtOtherCreditor.Tag = detail.Customer_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtEmployeeID.Tag = detail.Employee_ID;
                        txtCostCenter1.Tag = detail.CostCenter1_ID;
                        txtCostCenter2.Tag = detail.CostCenter2_ID;
                        txtAPNType.Tag = detail.ApnType_ID;

                        txtPaymentVoucherID.Text = detail.PaymentVoucher_ID;
                        dtpVoucherDate.Value = detail.PaymentVoucherDate;
                        txtOtherCreditor.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtEmployeeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(detail.Employee_ID));
                        txtCostCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                        txtCostCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));
                        txtNarration.Text = detail.Narration;
                        txtRemarks.Text = detail.Remark;
                        txtPayee.Text = detail.Payee;

                        txtAPNType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_APNType(detail.ApnType_ID));

                        rdoChequeAmount.Checked = (detail.ChequeAmount > 0) ? true : false;
                        rdoCashAmount.Checked = (detail.CashAmount > 0) ? true : false;
                        chkAdvancedPV.Checked = detail.IsAdvancePayment;
                        chkNonAdvanced.Checked = !detail.IsAdvancePayment;

                        llblChequePrint.Enabled = (detail.ChequeAmount > 0) ? true : false;

                        txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.ChequeAmount, dExRate));
                        txtCashAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.CashAmount, dExRate));

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

                        //Fill APN Details
                        dgvAPN.Rows.Clear();
                        foreach (tbl_accPaymentVoucher_Detail oPVD in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(sID))
                        {
                            int iRow;
                            if (oPVD.AccountPayableNote_ID != "default")
                            {
                                txtRefundebleNoteId.Enabled = false;
                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(oPVD.AccountPayableNote_ID);
                                if (oAPN != null)
                                {
                                    dgvAPN.Rows.Add();
                                    iRow = dgvAPN.Rows.Count - 1;

                                    dgvAPN["APNCode", iRow].Value = oAPN.AccountPayableNote_ID;
                                    dgvAPN["APNDate", iRow].Value = oAPN.BillDate;
                                    dgvAPN["APNAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(oPVD.SettleAmount, dExRate));
                                }
                            }
                            else if (oPVD.CustomerRefundableNote_ID != "default")
                            {
                                txtAPNID.Enabled = false;
                                tbl_bpsDebitNote oDBN = tbl_bpsDebitNote.Select(oPVD.CustomerRefundableNote_ID);
                                if (oDBN != null)
                                {
                                    dgvAPN.Rows.Add();
                                    iRow = dgvAPN.Rows.Count - 1;

                                    dgvAPN["APNCode", iRow].Value = oDBN.DebitNote_ID;
                                    dgvAPN["APNDate", iRow].Value = oDBN.DebitNoteDate;
                                    dgvAPN["APNAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(oPVD.SettleAmount, dExRate));
                                }
                            }
                        }

                        #region Fill PO detail
                        dgvPO.Rows.Clear();
                        int iRowPO;

                        List<tbl_accPaymentVoucher_PO> oPV_POs = tbl_accPaymentVoucher_PO.SelectAll().Where(p => detail.PaymentVoucher_ID == p.PaymentVoucher_ID).ToList();
                        if (oPV_POs.Count > 0)
                        {
                            foreach (tbl_accPaymentVoucher_PO oPV_PO in oPV_POs)
                            {
                                if (oPV_PO != null)
                                {
                                    tbl_scsPurchaseOrder oPO = tbl_scsPurchaseOrder.Select(oPV_PO.PurchaseOrder_ID);

                                    dgvPO.Rows.Add();
                                    iRowPO = dgvPO.Rows.Count - 1;
                                    dgvPO["PONo", iRowPO].Value = oPV_PO.PurchaseOrder_ID;
                                    dgvPO["PODate", iRowPO].Value = clsFormatter.FormatDate_Short(oPO.PurchaseOrderDate);
                                    dgvPO["Amount", iRowPO].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(oPV_PO.Amount, dExRate));
                                }
                            }
                        }

                        #endregion

                        //Fill Cheque Detial
                        FillMultipleCheck(sID);

                        //Fill GL Codes
                        FillDetailGLCodes(sID);

                        RefreshGrid();

                        Attachments.FillAttachments(sID);

                        List<tbl_accPaymentVoucher_Detail> oPVDetail = tbl_accPaymentVoucher_Detail.SelectAll().Where(p => p.PaymentVoucher_ID == detail.PaymentVoucher_ID && p.AccountPayableNote_ID != "default").ToList();
                        if (oPVDetail.Count > 0)
                        {
                            txtFlow2Quotation.ForeColor = Color.Red;
                            bActiveProcessFlowAPN = true;
                        }
                        else
                        {
                            txtFlow2Quotation.ForeColor = Color.Gray;
                            bActiveProcessFlowAPN = false;
                        }

                        //clsHelpMethods_Local.SetProcessFlowAPN(detail.AccountPayableNote_ID, txtFlow2Quotation);
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

        #region Fill Detail By APN / CRN / PO
        private void FillDetailByAPN(string sID)
        {
            try
            {
                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                if (detail != null)
                {
                    if (CheckCurrencyRate(detail.Currency_ID, detail.CurrencyRate))
                    {
                        txtAPNType.Tag = detail.ApnType_ID;
                        txtOtherCreditor.Tag = detail.Customer_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtEmployeeID.Tag = detail.Employee_ID;
                        txtCostCenter1.Tag = detail.CostCenter1_ID;
                        txtCostCenter2.Tag = detail.CostCenter2_ID;

                        txtAPNType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_APNType(detail.ApnType_ID));
                        txtOtherCreditor.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Customer_ID));
                        txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtEmployeeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(detail.Employee_ID));
                        txtCostCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                        txtCostCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));

                        var oAPNSubTotal = tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID).Where(p => p.IsCredit && p.Tc_ID == "6");
                        foreach (tbl_accAccountPayableNote_SubTotal oAPNSub in oAPNSubTotal)
                        {
                            FilldataTable(1, oAPNSub.Gl_ID, oAPNSubTotal.Count() == 1 ? oAPNSub.Amount - detail.SettledAmount : oAPNSub.Amount, "default", "default", "default", "default", sID);
                        }

                        #region Fill APN Detail
                        dgvAPN.Rows.Add();
                        int iRow;
                        iRow = dgvAPN.Rows.Count - 1;

                        dgvAPN["APNCode", iRow].Value = detail.AccountPayableNote_ID;
                        dgvAPN["APNDate", iRow].Value = detail.BillDate;
                        dgvAPN["APNAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal - detail.SettledAmount, dExRate));

                        if (dgvAPN.RowCount >= 1 && txtAPNType.Tag.ToString() == "A000")
                            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNID, false);

                        #endregion

                        setAPNsTotal();
                        RefreshGrid();

                        tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString());
                        txtPayee.Text = oSup.Payee;
                        //txtPayee.Text = txtSupplierID.Text.Trim();

                        clsCommon.SetEnableDisable_NormalTextbox(txtAPNType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtRefundebleNoteId, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRefundableNote, false);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void FillDetailByPO(string sID)
        {
            try
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sID);
                if (detail != null)
                {
                    txtSupplierID.Tag = detail.Supplier_ID;
                    txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));

                    #region Fill PO Detail
                    dgvPO.Rows.Add();
                    int iRow;
                    iRow = dgvPO.Rows.Count - 1;

                    dgvPO["PONo", iRow].Value = detail.PurchaseOrder_ID;
                    dgvPO["PODate", iRow].Value = clsFormatter.FormatDate_Short(detail.PurchaseOrderDate);
                    dgvPO["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal - detail.SeattleAmount, dExRate));
                    #endregion

                    setPOsTotal();
                    //RefreshGrid();

                    tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString());
                    txtPayee.Text = oSup.Payee;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private bool CheckCurrencyRate(string CurrencyID, decimal CurrencyRate)
        {
            bool isCurrencyOk = false;
            try
            {
                if (dgvAPN.RowCount == 0)
                {
                    txtCurrencyID.Tag = CurrencyID;
                    txtCurrencyID.Text = clsGenaralName.getName_Currency(CurrencyID);
                    txtCurCode.Text = clsGenaralName.getName_CurrencyCode(CurrencyID);
                    txtCurrencyRate.Text = CurrencyRate.ToString();
                    dExRate = CurrencyRate;
                    isCurrencyOk = true;
                }
                else
                {
                    if (CurrencyID != txtCurrencyID.Tag.ToString().Trim())
                        MessageBox.Show("Currency Type Not matching ....!  ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (CurrencyRate != dExRate)
                            MessageBox.Show("Currency Rate Not matching ....!  ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            isCurrencyOk = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return isCurrencyOk;
        }

        private void FillDetailByCRN(string sID)
        {
            try
            {
                tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sID);
                if (detail != null)
                {
                    if (CheckCurrencyRate(detail.Currency_ID, detail.CurrencyRate))
                    {
                        txtCustomer.Tag = detail.Customer_ID;
                        txtCustomer.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtOtherCreditor.Tag = detail.Customer_ID;
                        txtOtherCreditor.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));

                        #region Fill APN Detail
                        dgvAPN.Rows.Add();
                        int iRow;
                        iRow = dgvAPN.Rows.Count - 1;

                        dgvAPN["APNCode", iRow].Value = detail.DebitNote_ID;
                        dgvAPN["APNDate", iRow].Value = detail.DebitNoteDate;
                        dgvAPN["APNAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.TotalAmount - detail.SeattleAmount, dExRate));
                        #endregion

                        setAPNsTotal();
                        RefreshGrid();
                        txtPayee.Text = txtSupplierID.Text.Trim();

                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtAPNID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblAPNNo, false);
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
        private void FillDetailGLCodes(string sPaymentVoucher_ID)
        {
            try
            {
                //Clear GLs
                glb_dtCash.Rows.Clear();
                glb_dtCheque.Rows.Clear();
                glb_dtOther_Cr.Rows.Clear();
                glb_dtSupplier.Rows.Clear();

                foreach (tbl_accPaymentVoucher_SubTotal detail in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(sPaymentVoucher_ID))
                {
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr).ToString())
                    {
                        glb_dtOther_Cr.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.APNID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxOtherCr, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier).ToString())
                    {
                        glb_dtSupplier.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.APNID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxSupplier, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cash).ToString())
                    {
                        glb_dtCash.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Cash)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.APNID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxCashAmount, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque).ToString())
                    {
                        glb_dtCheque.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID, detail.APNID, detail.Remarks);
                        clsEvent.GLCode_TextChanged(pbxChequeAmount, "Accept");
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

        #region Fill Multiple Cheque
        private void FillMultipleCheck(string sPvID)
        {
            try
            {
                decimal chequeTotal = 0;
                if (frmMultipleCheque.dtRecodes.Rows.Count == 0)
                    frmMultipleCheque.CreateDataTable();
                frmMultipleCheque.dtRecodes.Clear();
                List<tbl_accChequeRegister> Cdetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(sPvID);
                foreach (tbl_accChequeRegister Cdetail in Cdetails)
                {
                    if (Cdetail != null && !Cdetail.IsDeleted)
                    {
                        tbl_genCompanyAccount oAcc = tbl_genCompanyAccount.Select(Cdetail.CompanyAccount_ID);
                        if (oAcc != null)
                        {
                            frmMultipleCheque.dtRecodes.Rows.Add(oAcc.AccountNumber, clsGenaralName.getName_Bank(oAcc.Bank_ID), Cdetail.ChequeNumber, Cdetail.DateCheque, Cdetail.ChequeType_ID, Cdetail.ChequeAmount, oAcc.Bank_ID, oAcc.Branch_ID, clsGenaralName.getName_BankBranch(oAcc.Branch_ID), 1, Cdetail.ChequeRegister_ID, Cdetail.Remark);
                            chequeTotal += Cdetail.ChequeAmount;
                            txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(chequeTotal, dExRate));
                            txtChqRefNo.Text = Cdetail.ChequeRegister_ID;
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

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string sGLCode, string sSubAcct1, string sSubAcct2, string sSubAcct1_ID, string sSubAcct2_ID, string sEmployee, string sEmployee_ID, string sOtherCr, string sCategoryID, string Remarks, bool bIsCredit, decimal dAmount, string sAPN_ID)
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
                dgvDetail["APNID", iRow].Value = sAPN_ID;
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

                //dgvDetail.Columns["accName"].Width = 340;
                //if (iRow >= 3)
                //    dgvDetail.Columns["accName"].Width = 340 - 16;

                dgvDetail.Columns["accName"].Width = 365;
                if (iRow >= 3)
                    dgvDetail.Columns["accName"].Width = 365 - 30;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Search Methods
        private void clearSubGLCodeExceptThis(string sCategory)
        {
            if (sCategory == "Supplier")
            {
                txtOtherCreditor.Tag = null;
                txtOtherCreditor.Clear();
                pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                glb_dtOther_Cr.Clear();
            }
            else if (sCategory == "OtherCreditor")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                glb_dtSupplier.Clear();
            }
        }

        private void Search_OtherCreditorID()
        {
            try
            {
                if (GetPVAmount() > 0)
                {
                    clsSearch.Search_MasterAccountGLCode(ref txtOtherCreditor, "", "");
                    if (txtOtherCreditor.Tag != null && txtOtherCreditor.Tag.ToString().Trim().Length > 0)
                    {

                    }
                }
                else
                    MessageBox.Show("Please Input the Credit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_Supplier()
        {
            try
            {
                if (GetPVAmount() > 0)
                {
                    clsSearch.Search_MasterSupplier(ref txtSupplierID);
                    if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                    {
                        if (txtPayee.Text == "")
                        {
                            tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString());
                            txtPayee.Text = oSup.Payee;
                        }
                        //txtPayee.Text = txtSupplierID.Text.Trim();
                        string sGLCode = clsMethods_GL.getAccountCode_Supplier(txtSupplierID.Tag.ToString().Trim());
                        string sGlName = clsGenaralName.getName_AccountName(sGLCode);
                        glb_dtSupplier.Rows.Clear();
                        #region old
                        //if (sGLCode != null && !sGLCode.Equals("default"))
                        //{

                        //}
                        //else
                        //{
                        //    FilldataTable(1, sGLCode, 0, "default", "default", "default", "default", "");
                        //    clsEvent.GLCode_TextChanged(pbxSupplier, "default");
                        //} 
                        #endregion

                        if (sGLCode != null && !sGLCode.Equals("default"))
                        {
                            FilldataTable(1, sGLCode, GetPVAmount(), "default", "default", "default", "default", "");
                            RefreshGrid();
                            clsEvent.GLCode_TextChanged(pbxSupplier, "default");
                        }
                    }
                }
                else
                    MessageBox.Show("Please Input the Credit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_Employee()
        {
            try
            {
                if (txtCostCenter2.Tag != null && txtCostCenter2.Tag.ToString().Trim().Length > 0)
                    txtCostCenter2_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter2ID(txtCostCenter2.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CostCenter1ID()
        {
            try
            {
                clsSearch.Search_costCenter1(ref txtCostCenter1);
                if (txtCostCenter1.Tag != null && txtCostCenter1.Tag.ToString().Trim().Length > 0)
                    txtCostCenter1_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter1ID(txtCostCenter1.Tag.ToString().Trim());
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
                if (txtCostCenter2.Tag != null && txtCostCenter2.Tag.ToString().Trim().Length > 0)
                    txtCostCenter2_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter2ID(txtCostCenter2.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private bool IsValidateGridIsExsistingRow(string sNewAPNID)
        {
            bool isExisting = true;

            try
            {
                foreach (DataGridViewRow row in dgvAPN.Rows)
                {
                    string sAPNID = "";
                    sAPNID = clsValidate.ValidateGridValue(dgvAPN, "APNCode", row.Index, "default");

                    if (sAPNID == sNewAPNID)
                    {
                        isExisting = false;
                        break;
                    }
                }
                if (isExisting == false)
                    MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return isExisting;
        }

        private bool IsValidateGridIsExsistingRowDetail(string sNewGLCode)
        {
            bool isExisting = true;

            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sGLCode = clsValidate.ValidateGridValue(dgvDetail, "accCode", row.Index, "default");
                    if (sGLCode == sNewGLCode)
                    {
                        isExisting = false;
                        break;
                    }
                }
                if (isExisting == false)
                    MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return isExisting;
        }

        private void setAPNsTotal()
        {
            decimal dAPNorCreditValue = 0;
            foreach (DataGridViewRow row in dgvAPN.Rows)
            {
                dAPNorCreditValue += clsValidate.ValidateGridValue(dgvAPN, "APNAmount", row.Index, decimal.Parse("0.00"));
            }
            txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAPNorCreditValue);
        }

        private void setPOsTotal()
        {
            decimal dAPNorCreditValue = 0;
            foreach (DataGridViewRow row in dgvPO.Rows)
            {
                dAPNorCreditValue += clsValidate.ValidateGridValue(dgvPO, "Amount", row.Index, decimal.Parse("0.00"));
            }
            txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAPNorCreditValue);
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                string sDuplicate = "";
                if (txtPaymentVoucherID.Text.Trim().Length > 0 && txtPaymentVoucherID.Text.Trim() != "<Auto Generate>")
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sApprovedUser = "[ None ]", sCreateUserID = "[ None ]", sCheckedUserID = "[ None ]", sApprovedUserID = "[ None ]";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true, isDuplicate = false;
                    DateTime dtmChequeDate = clsSecurity.getServerDateTime();
                    bool bPermissinOkToPrint = true;

                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_PaymentVoucher));
                    if (bPermissinOkToPrint)
                    {
                        tbl_accPaymentVoucher PV = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
                        if (PV != null)
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

                            if (bApprovalDone && bCheckingDone)
                            {
                                bOkToPrint = true;

                                sCreateUser = "[ " + clsGenaralName.getName_User(PV.CreateUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(PV.DateCreate) + " ]";
                                sCreateUserID = "[ " + PV.CreateUser_ID + " ] [ " + PV.DateCreate.ToShortDateString() + " ]";
                                if (PV.CheckedUser_ID != "default")
                                {
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(PV.CheckedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(PV.DateChecked) + " ]";
                                    sCheckedUserID = "[ " + PV.CheckedUser_ID + " ] [ " + PV.DateChecked.ToShortDateString() + " ]";
                                }
                                if (PV.ApprovedUser_ID != "default")
                                {
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(PV.ApprovedUser_ID) + " ] [ " + clsFormatter.FormatDate_Short(PV.DateApproved) + " ]";
                                    sApprovedUserID = "[ " + PV.ApprovedUser_ID + " ] [ " + PV.DateApproved.ToShortDateString() + " ]";
                                }

                                if (bOkToPrint && bApprovalDone)
                                {
                                    if (!bIsDraft)
                                    {
                                        if (PV.PrintCount > 0)
                                        {
                                            //if (!chkPrintOriginal.Checked)
                                            //    sDuplicate = "Duplicate Copy " + PV.PrintCount;

                                            if (!chkPrintOriginal.Checked)
                                                sDuplicate = (PV.PrintCount > 0) ? "Duplicate Copy " + PV.PrintCount : "";

                                            isDuplicate = true;
                                        }

                                        PV.PrintCount++;
                                        PV.Update();
                                    }

                                    #region View
                                   
                                    #endregion

                                    #region Dataset
                                    //  else
                                    {
                                        try
                                        {
                                            glb_dts_accPaymentVoucher.Clear();
                                            bool bisGLPV = true, bIsAllocatedAPN = false;

                                            string sSupplierName = "", sSupplierAddress = "", sSupplierAccount = "", sChequeRefNo = "", sBankName = "", sAccountNo = "", sChequeNo = "", sRemark = "";

                                            tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(PV.Supplier_ID);
                                            if (oSupplier != null && oSupplier.Supplier_ID != "default")
                                            {
                                                sSupplierName = oSupplier.SupplierName;
                                                sSupplierAddress = oSupplier.AddressRegister;
                                                bisGLPV = false;
                                            }

                                            int iDetailCoubt = 0;
                                            string sGLCode = "", sGLCodeName = "", sEmployee_ID = "", sRemarks = "", sAccTypeID = "";
                                            bool bIsCredit = false;
                                            decimal dAmount = 0;

                                            foreach (tbl_accPaymentVoucher_SubTotal oPvSubTotal in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(PV.PaymentVoucher_ID))
                                            {
                                                sGLCode = oPvSubTotal.Gl_ID;
                                                sAccTypeID = tbl_accGLMaster.Select(sGLCode).GlAccountType_ID;
                                                sGLCodeName = clsGenaralName.getName_AccountName(oPvSubTotal.Gl_ID);
                                                sEmployee_ID = oPvSubTotal.Employee_ID;
                                                bIsCredit = oPvSubTotal.IsCredit;
                                                sRemarks = oPvSubTotal.Remarks;
                                                dAmount = oPvSubTotal.Amount;

                                                if (oPvSubTotal.IsCredit)
                                                {
                                                    if (iDetailCoubt == 0)
                                                    {
                                                        sSupplierAccount = bisGLPV ? oPvSubTotal.Gl_ID : clsGenaralName.getName_AccountName(oPvSubTotal.Gl_ID) + " (" + oPvSubTotal.Gl_ID + ")";
                                                        sSupplierName = bisGLPV ? clsGenaralName.getName_AccountName(oPvSubTotal.Gl_ID) : sSupplierName;
                                                    }
                                                    else
                                                    {
                                                        sSupplierAccount += " , " + (bisGLPV ? oPvSubTotal.Gl_ID : clsGenaralName.getName_AccountName(oPvSubTotal.Gl_ID) + " (" + oPvSubTotal.Gl_ID + ")");
                                                        sSupplierName += bisGLPV ? " , " + clsGenaralName.getName_AccountName(oPvSubTotal.Gl_ID) : "";
                                                    }

                                                    glb_dts_accPaymentVoucher.dt_accPaymentVoucherDetail.Adddt_accPaymentVoucherDetailRow(PV.PaymentVoucher_ID, sGLCode, sGLCodeName, clsGenaralName.getName_GlAccountType1(sAccTypeID), sEmployee_ID, clsGenaralName.getName_AccCostCenter2(oPvSubTotal.CostCenter2_ID), clsGenaralName.getName_AccCostCenter1(oPvSubTotal.CostCenter1_ID), dAmount, bIsCredit, sRemarks);
                                                }
                                                else
                                                    glb_dts_accPaymentVoucher.dt_accPaymentVoucherDetail.Adddt_accPaymentVoucherDetailRow(PV.PaymentVoucher_ID, sGLCode, sGLCodeName, clsGenaralName.getName_GlAccountType1(sAccTypeID), sEmployee_ID, clsGenaralName.getName_AccCostCenter2(oPvSubTotal.CostCenter2_ID), clsGenaralName.getName_AccCostCenter1(oPvSubTotal.CostCenter1_ID), dAmount, bIsCredit, sRemarks);

                                            }

                                            sChequeRefNo = ""; sBankName = ""; sAccountNo = ""; sChequeNo = "";
                                            foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(PV.PaymentVoucher_ID).Where(p => p.ChequeNumber != "default" && p.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Deleted)))
                                            {
                                                tbl_genCompanyAccount oAcc = tbl_genCompanyAccount.Select(oCheque.CompanyAccount_ID);
                                                if (oAcc != null)
                                                {
                                                    sChequeRefNo = oCheque.ChequeRegister_ID;
                                                    sBankName = clsGenaralName.getName_Bank(oAcc.Bank_ID);
                                                    sAccountNo = oAcc.AccountNumber;
                                                    sChequeNo = oCheque.ChequeNumber;
                                                    dtmChequeDate = oCheque.DateCheque;
                                                    sRemark = oCheque.Remark;
                                                }
                                            }

                                            string sSupTel = "";
                                            string sSupEmail = "";
                                            string sSupAddress = "";
                                            string sSupName = "";
                                            tbl_genSupplierMaster oSup = tbl_genSupplierMaster.Select(PV.Supplier_ID);
                                            if (oSup != null)
                                            {
                                                sSupName = oSup.SupplierName;
                                                sSupTel = oSup.Telephone;
                                                sSupEmail = oSup.Email;
                                                sSupAddress = oSup.AddressRegister;
                                            }

                                            glb_dts_accPaymentVoucher.dt_accPaymentVoucher.Adddt_accPaymentVoucherRow(PV.PaymentVoucher_ID, PV.PaymentVoucherDate, sSupName, sSupAddress, sSupTel, sSupEmail, PV.TotalAmount,
                                                sSupplierName, "", sSupplierAccount, PV.CostCenter1_ID, PV.CostCenter2_ID, PV.PaymentVoucherDate, PV.Employee_ID, sBankName,
                                                sAccountNo, sChequeRefNo, sChequeNo, dtmChequeDate, PV.ChequeAmount, PV.CashAmount, PV.IsDeleted, (PV.Narration == "") ? sRemark : PV.Narration, (PV.Remark == "") ? sRemark : PV.Remark, isDuplicate,
                                               clsCommon.CurrencyToWord(decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(PV.TotalAmount))),
                                                //clsCommon.CurrencyToWord(PV.TotalAmount), 
                                                txtCurCode.Text.ToString(), PV.Payee, "");

                                            //bool PrintAPNDetail = false;
                                            foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(PV.PaymentVoucher_ID).Where(p => p.AccountPayableNote_ID != "default"))
                                            {
                                                tbl_accAccountPayableNote apn = tbl_accAccountPayableNote.Select(detail.AccountPayableNote_ID);
                                                string sGRNNo = "";
                                                DateTime dtmGRN = clsSecurity.getServerDateTime();

                                                if (apn.ExternalGoodReceivedNote_ID != "default")
                                                {
                                                    tbl_scsExternalGoodReceivedNote oGRN = tbl_scsExternalGoodReceivedNote.Select(apn.ExternalGoodReceivedNote_ID);
                                                    sGRNNo = oGRN.ExternalGoodReceivedNote_ID;
                                                    dtmGRN = oGRN.ExternalGoodReceivedNoteDate;
                                                }
                                                if (apn != null && apn.AccountPayableNote_ID != "default")
                                                {
                                                    glb_dts_accPaymentVoucher.dt_accPaymentVoucherAllocation.Adddt_accPaymentVoucherAllocationRow(PV.PaymentVoucher_ID, apn.AccountPayableNote_ID, apn.BillDate, clsHelpMethods_Local.getDisplayPrice(detail.SettleAmount, txtCurrencyRate), detail.Narration);
                                                    glb_dts_accPaymentVoucher.dts_PaymentVoucherDetail_APN.Adddts_PaymentVoucherDetail_APNRow(PV.PaymentVoucher_ID, apn.AccountPayableNote_ID, apn.AccountPayableNoteDate, apn.BillNo, apn.BillDate, sGRNNo, dtmGRN);
                                                    //PrintAPNDetail = true;
                                                }
                                            }

                                            foreach (tbl_accPaymentVoucher_Detail oPVDetail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(PV.PaymentVoucher_ID))
                                            {
                                                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(oPVDetail.AccountPayableNote_ID);
                                                if (oAPN != null)
                                                {
                                                    bIsAllocatedAPN = true;

                                                    DateTime dtBillDate = oAPN.BillDate.AddDays(int.Parse(oAPN.CreditDays.ToString()));
                                                    glb_dts_accPaymentVoucher.dt_APNDetail.Adddt_APNDetailRow(PV.PaymentVoucher_ID, oAPN.AccountPayableNote_ID, oAPN.BillNo, oAPN.NbtTotal, oAPN.VatTotal, oAPN.BillDate, oAPN.GrandTotal,
                                                        dtBillDate, (dtBillDate - clsSecurity.getServerDateTime()).TotalDays);
                                                    //decimal.Parse((oAPN.BillDate.AddDays(int.Parse(oAPN.CreditDays.ToString())).Date - clsSecurity.getServerDateTime().Date).ToString()));
                                                    //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DueDate", oAPN.BillDate.AddDays(int.Parse(oAPN.CreditDays.ToString())).ToString(), true);                                               
                                                    //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("OverDueDays", clsCommon.getCompanySVAT(), true);
                                                }
                                            }

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
                                                }
                                            }
                                            glb_dts_accPaymentVoucher.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, " PAYMENT VOUCHER ", "", "", clsSecurity.UserNameLoged, "");
                                            #endregion

                                            //For Print User Data
                                            InclsUserDetail oUserData = new InclsUserDetail(sCreateUser, sCheckedUser, sApprovedUser);

                                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_PaymentVoucher));
                                            string s_Path = "";
                                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                                s_Path += sGetRptPath;
                                            else
                                                s_Path = "\\Reports\\ACC\\NotePrinting\\rpt_accPaymentVoucher_AKT.rpt";


                                            print(s_Path, " Payment Voucher ", glb_dts_accPaymentVoucher, bIsDraft, oUserData, sDuplicate, clsAutocode.getReportID(enum_ReportName.NP_PaymentVoucher), bIsAllocatedAPN);

                                            //if (clsConfig.bCheckingNeedToPrintAPNDetail && PrintAPNDetail)
                                            //{
                                            //    print("\\Reports\\ACC\\NotePrinting\\rpt_accPaymentVoucher_CEL2.rpt", " Payment Voucher ", glb_dts_accPaymentVoucher, bIsDraft, oUserData, sDuplicate, clsAutocode.getReportID(enum_ReportName.NP_PaymentVoucher));
                                            //}
                                        }
                                        catch (Exception ex)
                                        {
                                            SEACCException.Show(ex);
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                        }
                                        finally
                                        {
                                            glb_dts_accPaymentVoucher.Clear();
                                            Cursor = Cursors.Default;
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                  
                        email.createEmail_PV(txtPaymentVoucherID.Text.ToString(), enum_Alerts.PaymentVoucherPrinted);
                    }
                }
                else
                    MessageBox.Show("Please Select the Payment Voucher To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Calculate Credit Debit Amounts
        private void CalculateBalance()
        {
            try
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
                    txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                else
                    txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount * (-1));

                if (dAmount == 0)
                    txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Reset Paymode
        private void ResetPayMethod()
        {
            txtCashAmount.Text = "0.00";
            txtChequeAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";

            frmMultipleCheque.dtRecodes.Clear();
        }
        #endregion

        #region Event Double Click
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCurrency(ref txtCurrencyID);
                if (txtCurrencyID.Tag != null)
                    FillDetailsCurrency(txtCurrencyID.Tag.ToString());
                else
                    FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtVoucher_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionPaymentVoucher_Direct2(ref txtPaymentVoucherID, chkShowSettle.Checked);
                if (txtPaymentVoucherID.Tag != null)
                    FillDetails(txtPaymentVoucherID.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("OtherCreditor");
            Search_OtherCreditorID();
        }

        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("Supplier");
            Search_Supplier();
        }

        private void txtEmployeeID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("Employee");
            clsSearch.Search_MasterEmployee(ref txtEmployeeID);
            if (txtEmployeeID.Tag != null && txtEmployeeID.Tag.ToString().Trim().Length > 0)
                txtEmployeeID_GLCode.Text = clsMethods_GL.getGLCode_ByEmployeeID(txtEmployeeID.Tag.ToString().Trim());
        }

        private void txtRefundebleNoteId_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionDebitNote_Direct(ref txtRefundebleNoteId, false, false, true);
                if (txtRefundebleNoteId.Tag != null && txtRefundebleNoteId.Tag.ToString().Trim().Length > 0)
                {
                    if (IsValidateGridIsExsistingRow(txtRefundebleNoteId.Tag.ToString()))
                        FillDetailByCRN(txtRefundebleNoteId.Text.Trim());

                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtAPNID_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (txtSupplierID.Tag != null && txtSupplierID.TextLength > 0 && txtSupplierID.Tag.ToString() != "default")
                    //clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, false, txtSupplierID.Tag.ToString());
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, false, txtSupplierID.Tag.ToString(), "", true, true, false, true);

                else if (txtOtherCreditor.Tag != null && txtOtherCreditor.TextLength > 0 && txtOtherCreditor.Tag.ToString() != "default")
                    //clsSearch.Search_TransactionAPNByCustomerID_Use(ref txtAPNID, txtOtherCreditor.Tag.ToString());
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, false, "", txtOtherCreditor.Tag.ToString(), true, true, false, true);

                else if (txtEmployeeID.Tag != null && txtEmployeeID.TextLength > 0)
                    clsSearch.Search_TransactionAPNByEmployeeID_Use(ref txtAPNID, txtEmployeeID.Tag.ToString());
                else if (txtCostCenter1.Tag != null && txtCostCenter1.TextLength > 0 && txtCostCenter1.Tag.ToString() != "default")
                    clsSearch.Search_TransactionAPNByCostCenter1_Use(ref txtAPNID, txtCostCenter1.Tag.ToString());
                else if (txtCostCenter2.Tag != null && txtCostCenter2.TextLength > 0 && txtCostCenter2.Tag.ToString() != "default")
                    clsSearch.Search_TransactionAPNByCostCenter2_Use(ref txtAPNID, txtCostCenter2.Tag.ToString());
                else
                    clsSearch.Search_TransactionAccountPayableNote_Direct(ref txtAPNID, false, "", "", true, true, false, true);

                if (txtAPNID.Tag != null && txtAPNID.Tag.ToString().Trim().Length > 0)
                {
                    if (IsValidateGridIsExsistingRow(txtAPNID.Tag.ToString()))
                        if (ValidateAPNType(txtAPNID.Tag.ToString()))

                            if (dgvAPN.RowCount >= 1)
                            {
                                if (txtAPNType.Tag.ToString() != "A000")
                                    FillDetailByAPN(txtAPNID.Text.Trim());
                            }
                            else
                                FillDetailByAPN(txtAPNID.Text.Trim());


                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtPONo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPONo, txtSupplierID.Tag != null ? txtSupplierID.Tag.ToString() : "", false, true);
                if (txtPONo.Tag != null && txtPONo.Tag.ToString().Trim().Length > 0)
                {
                    bool bAdd = true;
                    #region Check for existing PO No.
                    string sPONo = "";
                    foreach (DataGridViewRow row in dgvPO.Rows)
                    {
                        sPONo = clsValidate.ValidateGridValue(dgvPO, "PONo", row.Index, "default");
                        if (sPONo == txtPONo.Tag.ToString())
                        {
                            bAdd = false;
                            break;
                        }
                    }
                    #endregion

                    if (bAdd)
                        FillDetailByPO(txtPONo.Text.Trim());
                    else
                        MessageBox.Show("This PO is already added..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtAPNType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_AccountPayableNoteType_New(ref txtAPNType);
        }
        #endregion

        #region  Event Text Changed
        private void txtEmployeeID_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxEmployee, txtEmployeeID_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtEmployeeID_GLCode.Text.Trim()))
                RefreshGrid();
            else
                txtEmployeeID_GLCode.Text = "default";
        }
        private void txtCostCenter1_GLCode_TextChanged(object sender, EventArgs e)
        {
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCostCenter1_GLCode.Text.Trim()))
                RefreshGrid();
            else
                txtCostCenter1_GLCode.Text = "default";
        }
        private void txtCash_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxCashAmount, txtCash_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCash_GLCode.Text.Trim()))
                RefreshGrid();
            else
                txtCash_GLCode.Text = "default";
        }
        private void txtCheque_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxChequeAmount, txtCheque_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCheque_GLCode.Text.Trim()))
                RefreshGrid();
            else
                txtCheque_GLCode.Text = "default";
        }
        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxCashAmount, glb_dtCash, txtCashAmount, txtCurrencyRate);
                pbxCashAmount.Enabled = true;
            }
            else
                pbxCashAmount.Enabled = false;
        }
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
                pbxChequeAmount.Enabled = true;
            else
                pbxChequeAmount.Enabled = false;
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

        #region Event Key Down
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCurrencyID_DoubleClick(null, null);
        }
        private void txtRefundebleNoteId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtRefundebleNoteId_DoubleClick(null, null);
        }
        private void txtAPNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAPNID_DoubleClick(null, null);
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("Customer");
                Search_OtherCreditorID();
            }
        }
        private void txtSupplierID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("Supplier");
                Search_Supplier();
            }
        }
        private void txtEmployeeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("Employee");
                clsSearch.Search_MasterEmployee(ref txtEmployeeID);
                if (txtEmployeeID.Tag != null && txtEmployeeID.Tag.ToString().Trim().Length > 0)
                    txtEmployeeID_GLCode.Text = clsMethods_GL.getGLCode_ByEmployeeID(txtEmployeeID.Tag.ToString().Trim());
            }
        }
        private void txtCostCenter1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("CostCenter1");
                Search_CostCenter1ID();
            }
        }
        private void txtCostCenter2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("CostCenter2");
                Search_CostCenter2ID();
            }
        }
        private void txtChequeAmount1_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtChequeAmount, e, 15, 2);
        }
        private void txtCashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtCashAmount, e, 15, 2);
        }
        private void txtVoucher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtVoucher_DoubleClick(sender, e);
        }
        private void txtAPNType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtAPNType_DoubleClick(sender, e);
        }
        #endregion

        #region Event Validate
        private void txtCashAmount_Validated(object sender, EventArgs e)
        {
            if (txtCashAmount.Text.Trim().Length <= 0)
                txtCashAmount.Text = "0.00";
        }
        #endregion

        #region Event Checked Changed
        private void rdoCashAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCashAmount.Checked)
            {
                rdoCashAmount.Enabled = true;
                txtCashAmount.Enabled = true;
                txtCash_GLCode.Enabled = true;

                rdoChequeAmount.Checked = false;
                txtChequeAmount.Enabled = false;
                txtCheque_GLCode.Enabled = false;
                txtChequeAmount.Text = "0.00";
                txtCheque_GLCode.Clear();
                pbxChequeAmount.Enabled = false;
                txtCheque_GLCode.Text = "";
                llblChequeDetail.Enabled = false;
            }
        }

        private void rdoChequeAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChequeAmount.Checked)
            {
                rdoChequeAmount.Enabled = true;
                txtCheque_GLCode.Enabled = true;
                txtChequeAmount.Enabled = true;
                llblChequeDetail.Enabled = true;

                rdoCashAmount.Checked = false;
                txtCashAmount.Enabled = false;
                txtCash_GLCode.Enabled = false;
                txtCashAmount.Text = "0.00";
                txtCash_GLCode.Clear();
                txtCash_GLCode.Text = "";
            }
        }

        private void chkSetting_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSetting.Checked)
            //{
            //    xFlow.SendToBack();
            //    chkSetting.Image = Digiteq.Properties.Resources.security;
            //}
            //else
            //{
            //    xSettings.SendToBack();
            //    chkSetting.Image = Digiteq.Properties.Resources.settings;
            //}
        }

        #region Check Advanced PO
        private void chkAdvancedPV_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAdvancedPV.Checked)
            //{
            //    xpanel2.SendToBack();
            //    chkSetting.Image = Digiteq.Properties.Resources.security;
            //}
            //else
            //{
            //    xPanelPO.SendToBack();
            //    chkSetting.Image = Digiteq.Properties.Resources.settings;
            //}
        }
        #endregion
        #endregion

        #region Link Label Click
        private void llblChequeDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtPaymentVoucherID.Tag != null)
                {
                    tbl_accChequeRegister chequedetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtPaymentVoucherID.Tag.ToString()).ToList().FirstOrDefault();
                    if (chequedetails != null && chequedetails.ChequeStatus_ID == "0")
                    {
                        if (chequedetails.PrintCount != 0)
                            bIsLockChequeDetails = true;
                    }
                }

                if (IsUpdate)
                    FillMultipleCheck(txtPaymentVoucherID.Text.Trim());
                frmMultipleCheque MC = new frmMultipleCheque(bIsLockChequeDetails);

                MC.txtAmount.Text = txtChequeAmount.Text;
                MC.txtExRate.Text = dExRate.ToString();
                MC.ShowDialog();
                if (MC.DialogResult == DialogResult.OK)
                {
                    txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(MC.dTotal);
                    glb_dtCheque = MC.glb_dtSubTotal;
                    if (glb_dtCheque != null && glb_dtCheque.Rows.Count > 0)
                        RefreshGrid();
                }
                txtCurrencyID.Enabled = false;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtPaymentVoucherID.Text.Trim().Length > 0 && txtPaymentVoucherID.Text.Trim() != "<Auto Generate>")
                {
                    if (rdoChequeAmount.Checked == true)
                    {
                        if (clsConfig.bEnable_AutomatedChequePrint)//Automated cheque print
                        {
                            frm_masAccChequePrinting_New frm = new frm_masAccChequePrinting_New();
                            if (txtPaymentVoucherID.TextLength > 0)
                            {
                                foreach (tbl_accChequeRegister Cdetail in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtPaymentVoucherID.Text.Trim()))
                                {
                                    if (Cdetail != null && !Cdetail.IsDeleted)
                                    {
                                        frm.accChequeRegister_ID = Cdetail.ChequeRegister_ID;
                                    }
                                }
                            }

                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                frm.ShowDialog();
                        }
                        else
                        {
                            frm_masAccChequePrinting frm = new frm_masAccChequePrinting();
                            if (txtPaymentVoucherID.TextLength > 0)
                            {
                                foreach (tbl_accChequeRegister Cdetail in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtPaymentVoucherID.Text.Trim()))
                                {
                                    if (Cdetail != null && !Cdetail.IsDeleted)
                                    {
                                        frm.accChequeRegister_ID = Cdetail.ChequeRegister_ID;
                                    }
                                }
                            }

                            if (frm.bNoAccess)
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                frm.ShowDialog();
                        }
                    }
                    else
                        MessageBox.Show("There is no cheque to print ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Please Select the Payment Voucher To Print Cheque ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_AdvancePayment())
            {
                if (CheckValidity_EmptyFields())
                {
                    if (CheckValidity_DuplicateCheques())
                    {
                        if (CheckValidity_APNValueVsPVValue())
                        {
                            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                            {
                                if (CheckValidity_PVPrinting())
                                {
                                    if (CheckValidity_ChequePrinting())
                                    {
                                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
                                            bStatus = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_AdvancePayment()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (!chkAdvancedPV.Checked)
                {
                    if (!chkNonAdvanced.Checked)
                    {
                        strMessage += "Please Select Advance Payments or Part/ Final payment ";
                        bStatus = false;
                    }
                }
                if (bStatus == false)
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_PVPrinting()
        {
            bool bStatus = true;

            try
            {
                if (IsUpdate)
                {
                    tbl_accPaymentVoucher PVdetails = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
                    if (PVdetails != null)
                    {
                        if (PVdetails.PrintCount > 0)
                            bStatus = false;
                    }
                }

                if (!bStatus)
                    MessageBox.Show("This Payment Voucher is already printed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckValidity_ChequePrinting()
        {
            bool bStatus = true;
            if (IsUpdate)
            {
                tbl_accChequeRegister chequedetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtPaymentVoucherID.Text.Trim()).ToList().FirstOrDefault();
                if (chequedetails != null && chequedetails.ChequeStatus_ID == "0")
                {
                    if (chequedetails.PrintCount != 0)
                        bStatus = false;
                }
            }

            if (!bStatus)
                MessageBox.Show("This cheque is already printed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtPaymentVoucherID.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Voucher No ";
                    bStatus = false;
                }
                if (txtPayee.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Payee ";
                    bStatus = false;
                }
                if (decimal.Parse(txtCashAmount.Text) == 0 && decimal.Parse(txtChequeAmount.Text) == 0)
                {
                    strMessage += "\n" + "Cash Amounts \n Cheque Amounts ";
                    bStatus = false;
                }
                if (dgvDetail.Rows.Count <= 0)
                {
                    strMessage += "\n" + " Debit/s and Credit/s Items need to complete ";
                    bStatus = false;
                }
                if (decimal.Parse(txtBalanceAmount.Text.Trim()) != 0)
                {
                    strMessage += "\n" + "Amounts Not Tallying !!! Please Check Amounts ";
                    bStatus = false;
                }
                if (rdoChequeAmount.Checked)
                {
                    if (frmMultipleCheque.dtRecodes.Rows.Count <= 0)
                    {
                        strMessage += "\n" + " Please fill cheque details !!! ";
                        bStatus = false;
                    }
                }
                if (decimal.Parse(txtCashAmount.Text) != 0)
                {
                    decimal dAmount = 0;
                    foreach (DataRow row in glb_dtCash.Rows)
                    {
                        dAmount = dAmount + decimal.Parse(row["GLAmount"].ToString());
                    }
                    if (dAmount != clsHelpMethods_Local.getSavePrice(decimal.Parse(txtCashAmount.Text), txtCurrencyRate))
                    {
                        strMessage += "\n" + "Total credit amounts not equal to Cash Amounts ";
                        bStatus = false;
                    }
                }
                if (decimal.Parse(txtChequeAmount.Text) != 0)
                {
                    decimal dAmount = 0;
                    foreach (DataRow row in glb_dtCheque.Rows)
                    {
                        dAmount = dAmount + decimal.Parse(row["GLAmount"].ToString());
                    }
                    if (dAmount != clsHelpMethods_Local.getSavePrice(decimal.Parse(txtChequeAmount.Text), txtCurrencyRate))
                    {
                        strMessage += "\n" + "Total credit amounts not equal to Cheque Amounts ";
                        bStatus = false;
                    }
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
        private bool CheckValidityChequeCash()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (decimal.Parse(txtCashAmount.Text.ToString()) > 0 && clsCommon.isCurrency(txtCashAmount.Text.Trim()))
                {
                    strMessage += "\n" + "Cash Or Cheque Total ";
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
        private bool CheckValidity_DuplicateCheques()
        {
            bool bStatus = true;
            if (rdoChequeAmount.Checked && frmMultipleCheque.dtRecodes.Rows.Count == 0)
            {
                bStatus = false;
                MessageBox.Show("Please fill Cheque details", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (rdoChequeAmount.Checked && frmMultipleCheque.dtRecodes.Rows.Count > 0 && !IsUpdate)
            {
                string BankID = "", AccountNo = "", sChequeNo = "";
                foreach (DataRow dRow in frmMultipleCheque.dtRecodes.Rows)
                {
                    string sRegisterID = dRow["ChequeRegisterID"].ToString();
                    sChequeNo = dRow["ChequeNo"].ToString();
                    BankID = dRow["BankID"].ToString();
                    AccountNo = dRow["AccountNo"].ToString();
                    int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(AccountNo);
                    foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAll().Where(p => p.ChequeRegister_ID != "default" && !p.IsDeleted && p.ChequeNumber.Trim() == sChequeNo))
                    {
                        if (oCheque.CompanyAccount_ID == iCompanyAccount_ID)
                        {
                            bStatus = false;
                            MessageBox.Show(sChequeNo + " Cheque is already Issued. ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }

            return bStatus;
        }
        private bool CheckValidity_APNValueVsPVValue()
        {
            bool bStatus = true;
            decimal dAPNAmount = 0;
            tbl_accAccountPayableNote detail = null;
            tbl_accPaymentVoucher pvDetail = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text);

            foreach (DataGridViewRow dRow in dgvAPN.Rows)
            {
                string sAPNID = clsValidate.ValidateGridValue(dgvAPN, "APNCode", dRow.Index, "");
                if (sAPNID.Length > 0)
                {
                    detail = tbl_accAccountPayableNote.Select(sAPNID);
                    if (detail != null && detail.AccountPayableNote_ID != "default" && !detail.IsDeleted)
                    {
                        dAPNAmount += (detail.GrandTotal - detail.SettledAmount);
                    }

                }
            }

            decimal dCreditValue = 0, dDebitValue = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                bool bIsCredit = clsValidate.ValidateGridValue(dgvDetail, "IsCredit", row.Index, true);

                if (bIsCredit)
                    dCreditValue += clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                else
                    dDebitValue += clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));
            }

            if (dCreditValue != dDebitValue)
            {
                bStatus = false;
                MessageBox.Show("Credit Amount and Debit Amount are not equal", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (IsUpdate)
            {
                if (dAPNAmount > 0 && (detail.SettledAmount - pvDetail.TotalAmount + dCreditValue) > detail.GrandTotal)
                {
                    bStatus = false;
                    MessageBox.Show("Payment Voucher value is not allowed to exceed APN(s) balance value", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                if (dAPNAmount > 0 && dAPNAmount < dCreditValue)
                {
                    bStatus = false;
                    MessageBox.Show("Payment Voucher value is not allowed to exceed APN(s) balance value", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return bStatus;
        }
        #endregion

        #region Check Validity Grid Panel
        private bool CheckValidityGridPanel()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                CheckGridViewAmount();

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
        #endregion

        #region Check Validity Grid
        private bool ValidateGrid()
        {
            bool bNoRows = true;
            string strMessage = "";

            if (dgvDetail.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dgvDetail.Rows)
                {
                    string Gl_Code = dgvDetail["GLCode", iRow.Index].Value.ToString();
                }
            }

            if (bNoRows == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bNoRows;
        }
        #endregion

        #region Validate Empty Foreing Key
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtPaymentVoucherID);
            clsCommon.ValidateForeignKey(ref txtOtherCreditor);
            clsCommon.ValidateForeignKey(ref txtSupplierID);
            clsCommon.ValidateForeignKey(ref txtEmployeeID);
            clsCommon.ValidateForeignKey(ref txtCostCenter1);
            clsCommon.ValidateForeignKey(ref txtCostCenter2);
            clsCommon.ValidateForeignKey(ref txtAPNType);
        }
        #endregion

        #region Calculate Credit Debit Amounts
        private void CalculateCreditDebitAmounts()
        {
            txtCreditAmount.Text = dGridAmount.ToString();
        }
        #endregion

        #region Calculate Paymet Mode Amount
        private decimal GetPVAmount()
        {
            decimal value = 0;
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
                value = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtChequeAmount.Text.Trim()), txtCurrencyRate);
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
                value = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtCashAmount.Text.Trim()), txtCurrencyRate);
            return value;
        }
        #endregion

        #region Check Grid View Amount
        private void CheckGridViewAmount()
        {
            dGridAmount = 0;

            if (dgvDetail.Rows.Count > 0)
            {
                foreach (DataGridViewRow iRow in dgvDetail.Rows)
                {
                    dGridAmount += decimal.Parse(clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(dgvDetail["Amount", iRow.Index].Value.ToString())));
                }
                dGridAmount += decimal.Parse(clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtDebitAmount.Text.Trim())));
            }
            else
                dGridAmount = decimal.Parse(clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtDebitAmount.Text.Trim())));
        }
        #endregion

        #region  Event Click
        private void pbxCustomer_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtOther_Cr, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Other_Cr, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
                if (glb_dtOther_Cr != null && glb_dtOther_Cr.Rows.Count > 0)
                    RefreshGrid();
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtOther_Cr, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Other_Cr, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
                if (glb_dtOther_Cr != null && glb_dtOther_Cr.Rows.Count > 0)
                    RefreshGrid();
            }
            txtCurrencyID.Enabled = false;
        }

        private void pbxSupplier_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSupplier, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Supplier, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
                if (glb_dtSupplier != null && glb_dtSupplier.Rows.Count > 0)
                {
                    RefreshGrid();

                    if (glb_dtSupplier.Rows.Count > 0)
                    {
                        foreach (DataRow row in glb_dtSupplier.Rows)
                        {
                            foreach (DataGridViewRow grow in dgvAPN.Rows)
                            {
                                if (row["APN_ID"].ToString() == grow.Cells[0].Value.ToString())
                                    grow.Cells["APNAmount"].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(row["GLAmount"].ToString()));
                            }
                        }
                    }
                }
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSupplier, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Supplier, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
                if (glb_dtSupplier != null && glb_dtSupplier.Rows.Count > 0)
                    RefreshGrid();
            }
            txtCurrencyID.Enabled = false;
        }

        private void pbxEmployee_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtEmployeeID_GLCode, txtChequeAmount);
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtEmployeeID_GLCode, txtCashAmount);
        }

        private void pbxCostCenter1_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtCostCenter1_GLCode, txtChequeAmount);
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtCostCenter1_GLCode, txtCashAmount);
        }

        private void pbxCostCenter2_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtCostCenter2_GLCode, txtChequeAmount);
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
                clsEvent.PictureBox_Click(txtCostCenter2_GLCode, txtCashAmount);
        }

        private void pbxCashAmount_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtCash, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Cash, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtCash != null && glb_dtCash.Rows.Count > 0)
                RefreshGrid();
        }

        private void pbxChequeAmount_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtCheque, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Cheque, iFormID, txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text));
            if (glb_dtCheque != null && glb_dtCheque.Rows.Count > 0)
                RefreshGrid();
        }

        private void txtFlow2Quotation_MouseClick(object sender, MouseEventArgs e)
        {
            //if (bActiveProcessFlowAPN)
            //    clsHelpMethods_Local.MouseClick_APN(sender, e, glbPamentVoucher);
        }
        #endregion

        #region Create Data Table
        private void CreateDataTable(TransactionCategory eTCategory)
        {
            if (TransactionCategory.Cash == eTCategory)
            {
                glb_dtCash = new DataTable();
                glb_dtCash.Columns.Add("Line_No", typeof(int));
                glb_dtCash.Columns.Add("GLCode", typeof(string));
                glb_dtCash.Columns.Add("GLName", typeof(string));
                glb_dtCash.Columns.Add("GLAmount", typeof(decimal));
                glb_dtCash.Columns.Add("SubAcct1", typeof(string));
                glb_dtCash.Columns.Add("SubAcct2", typeof(string));
                glb_dtCash.Columns.Add("Employee", typeof(string));
                glb_dtCash.Columns.Add("OtherCr", typeof(string));
                glb_dtCash.Columns.Add("CategoryID", typeof(int));
                glb_dtCash.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtCash.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtCash.Columns.Add("Employee_ID", typeof(string));
                glb_dtCash.Columns.Add("APN_ID", typeof(string));
                glb_dtCash.Columns.Add("Remarks", typeof(string));
            }
            if (TransactionCategory.Cheque == eTCategory)
            {
                glb_dtCheque = new DataTable();
                glb_dtCheque.Columns.Add("Line_No", typeof(int));
                glb_dtCheque.Columns.Add("GLCode", typeof(string));
                glb_dtCheque.Columns.Add("GLName", typeof(string));
                glb_dtCheque.Columns.Add("GLAmount", typeof(decimal));
                glb_dtCheque.Columns.Add("SubAcct1", typeof(string));
                glb_dtCheque.Columns.Add("SubAcct2", typeof(string));
                glb_dtCheque.Columns.Add("Employee", typeof(string));
                glb_dtCheque.Columns.Add("OtherCr", typeof(string));
                glb_dtCheque.Columns.Add("CategoryID", typeof(int));
                glb_dtCheque.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtCheque.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtCheque.Columns.Add("Employee_ID", typeof(string));
                glb_dtCheque.Columns.Add("APN_ID", typeof(string));
                glb_dtCheque.Columns.Add("Remarks", typeof(string));
            }
            if (TransactionCategory.Other_Cr == eTCategory)
            {
                glb_dtOther_Cr = new DataTable();
                glb_dtOther_Cr.Columns.Add("Line_No", typeof(int));
                glb_dtOther_Cr.Columns.Add("GLCode", typeof(string));
                glb_dtOther_Cr.Columns.Add("GLName", typeof(string));
                glb_dtOther_Cr.Columns.Add("GLAmount", typeof(decimal));
                glb_dtOther_Cr.Columns.Add("SubAcct1", typeof(string));
                glb_dtOther_Cr.Columns.Add("SubAcct2", typeof(string));
                glb_dtOther_Cr.Columns.Add("Employee", typeof(string));
                glb_dtOther_Cr.Columns.Add("OtherCr", typeof(string));
                glb_dtOther_Cr.Columns.Add("CategoryID", typeof(int));
                glb_dtOther_Cr.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtOther_Cr.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtOther_Cr.Columns.Add("Employee_ID", typeof(string));
                glb_dtOther_Cr.Columns.Add("APN_ID", typeof(string));
                glb_dtOther_Cr.Columns.Add("Remarks", typeof(string));
            }
            if (TransactionCategory.Supplier == eTCategory)
            {
                glb_dtSupplier = new DataTable();
                glb_dtSupplier.Columns.Add("Line_No", typeof(int));
                glb_dtSupplier.Columns.Add("GLCode", typeof(string));
                glb_dtSupplier.Columns.Add("GLName", typeof(string));
                glb_dtSupplier.Columns.Add("GLAmount", typeof(decimal));
                glb_dtSupplier.Columns.Add("SubAcct1", typeof(string));
                glb_dtSupplier.Columns.Add("SubAcct2", typeof(string));
                glb_dtSupplier.Columns.Add("Employee", typeof(string));
                glb_dtSupplier.Columns.Add("OtherCr", typeof(string));
                glb_dtSupplier.Columns.Add("CategoryID", typeof(int));
                glb_dtSupplier.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtSupplier.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtSupplier.Columns.Add("Employee_ID", typeof(string));
                glb_dtSupplier.Columns.Add("APN_ID", typeof(string));
                glb_dtSupplier.Columns.Add("Remarks", typeof(string));
            }
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, bool bIsDraft, InclsUserDetail oUser, string sDuplicate, string sReportID, bool bHasAPNDetails)
        {
            try
            {
                if (path != "" && path != null)
                {
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);

                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsSecurity.DigiteqEmail, true);

                    


                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("HideAPNSummery", bHasAPNDetails ? "" : "Hide", true);

                    //isData set Actived
                    if (oUser != null)
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", oUser.sCreateUser, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", oUser.sCheckedUser, true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", oUser.sApprovedUser, true);
                    }

                    try
                    {
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true);
                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true);
                    }
                    catch { }

                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true);
                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

                    if (bIsDraft)
                    {
                        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                        {
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                        }
                    }

                    frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                    ReportViewer.print(path, ojbDataSet, glb_dtsReportExport.dt_rptParameter, sReportID);

                }
                else
                {
                    MessageBox.Show("Report doesn't Exist.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }

        //private void print(string path, string sReportTitle, DataSet ojbDataSet, string sDraff, InclsUserDetail oUser)
        //{
        //    try
        //    {
        //        Cursor = Cursors.WaitCursor;
        //        string s_Path = "";
        //        if (path != "" && path != null)
        //        {
        //            ReportDocument objRpt = new ReportDocument();

        //            s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
        //            s_Path += path;

        //            objRpt.Load(s_Path);
        //            objRpt.SetDataSource(ojbDataSet);

        //            objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //            objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
        //            objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
        //            objRpt.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
        //            objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
        //            objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
        //            objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
        //            objRpt.DataDefinition.FormulaFields["IsDraft"].Text = clsCommon.fncsetstring(sDraff);

        //            //isData set Actived
        //            if (oUser != null)
        //            {
        //                objRpt.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(oUser.sCreateUser);
        //                objRpt.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(oUser.sCheckedUser);
        //                objRpt.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(oUser.sApprovedUser);
        //            }

        //            try
        //            {
        //                objRpt.DataDefinition.FormulaFields["BusinessRegNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo());
        //                objRpt.DataDefinition.FormulaFields["CompanyVatNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
        //            }
        //            catch { }

        //            frm_ReportViewer ReportViewer = new frm_ReportViewer();
        //            ReportViewer.crystalReportViewer1.ReportSource = objRpt;
        //            ReportViewer.crystalReportViewer1.Refresh();
        //            ReportViewer.crystalReportViewer1.DisplayToolbar = true;
        //            ReportViewer.crystalReportViewer1.CloseView(false);
        //            ReportViewer.WindowState = FormWindowState.Maximized;
        //            ReportViewer.ShowDialog();

        //            objRpt.Close();
        //            objRpt.Dispose();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Report doesn't Exist.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
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

        #region Fill Data Table
        private void FilldataTable(int Line_No, string Gl_ID, decimal Amount, string CostCenter1_ID, string CostCenter2_ID, string Employee_ID, string Customer_ID, string sAPN_ID)
        {
            glb_dtSupplier.Rows.Add(Line_No, Gl_ID, clsGenaralName.getName_AccountName(Gl_ID), Amount,
                clsGenaralName.getName_AccCostCenter1(CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(CostCenter2_ID), clsGenaralName.getName_Employee(Employee_ID), Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier)
                , CostCenter1_ID, CostCenter2_ID, Employee_ID, sAPN_ID);

            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCurrencyID, false);
        }
        #endregion

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrencyID.Tag = null;
                txtCurrencyID.Clear();
                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrencyID.Tag = currency.Currency_ID;
                        txtCurrencyID.Text = currency.CurrencyName;
                        txtCurCode.Text = clsGenaralName.getName_CurrencyCode(sCurrencyID);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region Check Validity
        private bool ValidateSave()
        {
            string strMessage = "";
            bool bStatus = true;
            decimal bBalanceAmount = clsValidate.DecimalValidate(txtBalance);

            try
            {
                if (bBalanceAmount != 0)
                {
                    strMessage = "There is a  Difference between credit amount and debit amount";
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

        private bool ValidateAPNType(string sAPNID)
        {
            bool bStatus = true;

            try
            {
                if (txtAPNType.Tag != null)
                {
                    tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
                    if (oAPN != null)
                    {
                        if (oAPN.ApnType_ID != txtAPNType.Tag.ToString())
                        {
                            bStatus = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

            if (bStatus == false)
                MessageBox.Show("Payment voucher type is different than selected APN.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        #endregion

        private void chkFlow_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkFlow.Checked)
            //{
            //    //xSetting.SendToBack();
            //    xSetting.BringToFront();
            //    //xFlow.SendToBack();
            //    chkFlow.BringToFront();
            //    chkFlow.Image = Digiteq.Properties.Resources.security;
            //}
            //else
            //{
            //    //xFlow.SendToBack();
            //    //xSetting.SendToBack();
            //    xFlow.BringToFront();
            //    chkFlow.BringToFront();
            //    chkFlow.Image = Digiteq.Properties.Resources.settings;
            //}
        }

        private void chkAdvancedPV_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkAdvancedPV.Checked)
            {
                panelPO.BringToFront();
                chkNonAdvanced.Checked = false;
                //panelPO.Visible = true;
            }
            else
            {
                xpanel2.BringToFront();
                //panelPO.Visible = false;
            }
        }

        private void chkNonAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNonAdvanced.Checked)
            {
                chkAdvancedPV.Checked = false;
            }
        }

        private void frm_accPaymentVoucher_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtPaymentVoucherID.Text != null && txtPaymentVoucherID.TextLength > 0 && txtPaymentVoucherID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
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

                                        tbl_accPaymentVoucher objDO = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
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
                if (txtPaymentVoucherID.Text != null && txtPaymentVoucherID.TextLength > 0 && txtPaymentVoucherID.Text != "<Auto Generate>")
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
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

                                        tbl_accPaymentVoucher objDO = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID, ex); clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void UserDetails()
        {
            if (txtPaymentVoucherID.Text != "" || txtPaymentVoucherID.Text != "<Auto Generate>")
            {
                tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Text);
                if (detail != null)
                {
                    DataTable dt_UserDetails = new DataTable();
                    dt_UserDetails.Columns.Add("usertype", typeof(string));
                    dt_UserDetails.Columns.Add("Column1", typeof(string));
                    dt_UserDetails.Columns.Add("user", typeof(string));
                    dt_UserDetails.Columns.Add("Column2", typeof(string));
                    dt_UserDetails.Columns.Add("datetime", typeof(string));

                    dt_UserDetails.Rows.Add("Created By ", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                    if (detail.DateCreate != detail.DateModified)
                        dt_UserDetails.Rows.Add("Last Modified By ", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                    if (detail.IsChecked)
                        dt_UserDetails.Rows.Add("Checked By ", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                    if (detail.IsApproved)
                        dt_UserDetails.Rows.Add("Approved By ", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                    if (detail.IsDeleted)
                        dt_UserDetails.Rows.Add("Cancelled By ", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                    Point startPoint = this.PointToScreen(new Point());

                    frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                    frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                }
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

    #region Class for pass PrintUser Data
    public class InclsUserDetail
    {
        public string sCreateUser = "";
        public string sCheckedUser = "";
        public string sApprovedUser = "";
        public InclsUserDetail()
        {
        }
        public InclsUserDetail(string _sCreateUser, string _sCheckedUser, string _sApprovedUser)
        {
            sCreateUser = _sCreateUser;
            sApprovedUser = _sApprovedUser;
            sCheckedUser = _sCheckedUser;
        }
    }
    #endregion
}

#region MyRegion
//private void btnSavePost_Click(object sender, EventArgs e)
//{
//    //if (SavePaymentVoucherData() == true)
//    //{
//    //    if (ValidateSave())
//    //    {
//    //        try
//    //        {
//    //            Cursor = Cursors.WaitCursor;
//    //            if (sPostingID != "default")
//    //            {
//    //                tbl_accGLPosting_Tmp oGLPostingTemp = tbl_accGLPosting_Tmp.Select(sPostingID);
//    //                if (oGLPostingTemp != null)
//    //                {
//    //                    tbl_accGLPosting oPosting = new tbl_accGLPosting();
//    //                    oPosting.GlPosting_ID = oGLPostingTemp.GlPosting_ID;
//    //                    oPosting.GlPostingDate = oGLPostingTemp.GlPostingDate;
//    //                    oPosting.Batch_ID = clsAutocode.getAutoGeneratedCode(sFormConfigBatchCode);
//    //                    string sRemark = oGLPostingTemp.Remark;
//    //                    if (sRemark.Length == 0 || sRemark == null)
//    //                        sRemark = "default";
//    //                    oPosting.Remark = sRemark;
//    //                    oPosting.Insert();
//    //                    foreach (tbl_accGLPosting_Detail_Tmp oDetail in tbl_accGLPosting_Detail_Tmp.SelectAllByGlPosting_ID(sPostingID))
//    //                    {
//    //                        tbl_accGLPosting_Detail oPostingDetail = new tbl_accGLPosting_Detail();
//    //                        oPostingDetail.Line_No = oDetail.Line_No;
//    //                        oPostingDetail.GlPosting_ID = oDetail.GlPosting_ID;
//    //                        oPostingDetail.Batch_ID = oPosting.Batch_ID;
//    //                        oPostingDetail.Slot_ID = oDetail.Slot_ID;
//    //                        oPostingDetail.Transaction_ID = oDetail.Transaction_ID;
//    //                        oPostingDetail.Gl_ID = oDetail.Gl_ID;
//    //                        oPostingDetail.IsCanceled = oDetail.IsCanceled;
//    //                        oPostingDetail.TransactionDate = oDetail.TransactionDate;
//    //                        oPostingDetail.Remark = oDetail.Remark;
//    //                        oPostingDetail.MainTransaction_ID = oDetail.MainTransaction_ID;
//    //                        oPostingDetail.CostCenter1_ID = oDetail.CostCenter1_ID;
//    //                        oPostingDetail.CostCenter2_ID = oDetail.CostCenter2_ID;
//    //                        oPostingDetail.Customer_ID = oDetail.Customer_ID;
//    //                        oPostingDetail.Supplier_ID = oDetail.Supplier_ID;
//    //                        oPostingDetail.Employee_ID = oDetail.Employee_ID;
//    //                        oPostingDetail.BankAcc_No = oDetail.BankAcc_No;
//    //                        oPostingDetail.CusSupEmpName = oDetail.CusSupEmpName;
//    //                        oPostingDetail.FinancialYear_ID = oDetail.FinancialYear_ID;
//    //                        oPostingDetail.CompanyID = oDetail.CompanyID;
//    //                        oPostingDetail.Cheq_No = oDetail.Cheq_No;
//    //                        oPostingDetail.Narration = oDetail.Narration;
//    //                        oPostingDetail.Amount = oDetail.Amount;
//    //                        oPostingDetail.IsCredit = oDetail.IsCredit;
//    //                        oPostingDetail.Insert();
//    //                        oDetail.Delete();
//    //                    }
//    //                    if (txtPaymentVoucherID.Tag != null)
//    //                    {
//    //                        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(txtPaymentVoucherID.Tag.ToString().Trim());
//    //                        if (oPV != null)
//    //                        {
//    //                            oPV.IsLocked = true;
//    //                            oPV.Update();
//    //                        }
//    //                    }
//    //                    oGLPostingTemp.Delete();
//    //                }
//    //            }
//    //        }

//    //        catch (Exception ex)
//    //        {
//    //            SEACCException.Show(ex);
//    //            clsValidate.WriteErrorLog("", iFormID,ex);
//    //        }
//    //        finally
//    //        {
//    //            Cursor = Cursors.Default;
//    //        }
//    //    }
//    //}
//}

//#region Btn Add Grid
//private void btnAddGrid_Click(object sender, EventArgs e)
//{
//    if (CheckValidityGridPanel())
//    {
//        if (ValidateGrid())
//        {
//            int iRow = 0;
//            dgvDetail.Rows.Add();
//            iRow = dgvDetail.Rows.Count - 1;

//            FillGrid(iRow, "", "", "", "", 0);
//            CalculateCreditDebitAmounts();
//        }
//    }
//}
//#endregion

//#region Btn Delete Grid
//private void btnGridDelete_Click(object sender, EventArgs e)
//{
//    try
//    {
//        if (dgvDetail.SelectedCells.Count != 0)
//        {
//            if (dgvDetail.Rows.Count > 0)
//                dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
//            CheckGridViewAmount();
//            CalculateCreditDebitAmounts();
//        }
//    }
//    catch (Exception ex)
//    {
//        clsValidate.WriteErrorLog("", iFormID,ex);
//        SEACCException.Show(ex);
//    }
//}
//#endregion

//private void RefreshGridSubTotal()
//{
//    try
//    {
//        decimal dTotAmount = 0;
//        foreach (DataRow row in glb_dtSubTotal.Rows)
//        {
//            decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
//            dTotAmount += dAmount;
//        }
//        txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotAmount);
//        txtChequeAmount.Tag = clsFormatter.FormatToCurrecyWithThousendSep(dTotAmount);
//    }
//    catch (Exception ex)
//    {
//        SEACCException.Show(ex);
//        clsValidate.WriteErrorLog("", iFormID,ex);
//    }
//}

//#region Fill Grid
//private void FillGrid(int iRow, string sGlCode, string sAccountName, string sCostCenterCodeName, string sCostCenterCode, decimal Amount)
//{
//    dgvDetail["GLCode", iRow].Value = clsCommon.GetForeignKeyValue(sGlCode);
//    dgvDetail["AccountName", iRow].Value = sAccountName;
//    dgvDetail["CostCenterCode", iRow].Value = sCostCenterCodeName;
//    dgvDetail["CostCenterCode", iRow].Tag = clsCommon.GetForeignKeyValue(sCostCenterCode);
//    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
//}
//#endregion 
#endregion