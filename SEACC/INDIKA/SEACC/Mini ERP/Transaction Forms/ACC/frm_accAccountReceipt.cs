using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
//using Zion.ERP.Reports.DataSets.ACC;
using Zion.ERP.Reports.DataSets;
using ZION.ERP.Reports.DataSets.ACC;

namespace Digiteq
{
    public partial class frm_accAccountReceipt : SEACC_Form
    {

        
        decimal dGridAmount = 0;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbCustomerOrderID = "", glbQuotationID = "", glbAccReceiptID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //     DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //     DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        string PayMode = "default", CusSupEmpCode = "default";

        //for Bank Accounts
        DataTable glb_dtSubTotal;

        DataTable glb_dtCash;
        DataTable glb_dtCheque;
        DataTable glb_dtOther_Cr;
        DataTable glb_dtSupplier;
        DataTable glb_dtSup;
        dts_accReciept glb_dts_accReciept = new dts_accReciept();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //frmMultipleCheque MC = new frmMultipleCheque();
        frm_accReceiptMultipleCheque MC = new frm_accReceiptMultipleCheque();

        //For Reports
        string sCreateUser = "", sCreateUserID = "", sApprovedUser = "", sCheckedUser = "";
      

        #region From Load
        public frm_accAccountReceipt(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.accReceiptVoucher);

            //iFormID = clsSecurity.getFormID(FormName.accReceiptVoucher);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frm_trnPayment_Voucher_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //clsFormatter.setFormatForm(this, "Account Receipt [AR]", 6, iFormID);

            CreateDataTable(TransactionCategory.Cash);
            CreateDataTable(TransactionCategory.Cheque);
            CreateDataTable(TransactionCategory.Other_Cr);
            CreateDataTable(TransactionCategory.Supplier);
            CreateDataTable(TransactionCategory.Customer);

            CusDataGridViewFormat();
            clsConfig.bIsCompanyChequeBankType = true;
            ClearFileds();

            if (glbAccReceiptID != null && glbAccReceiptID.Length > 0)
                FillDetails(glbAccReceiptID);
        }
        #endregion

        #region Btn Clear
        private void frm_accAccountReceipt_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFileds();
        }
        #endregion

        #region Btn Save
        private void frm_accAccountReceipt_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
            {
                if (CheckValidity())
                {
                    if (CheckValidity_ChequeNo())
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            try
                            {
                                if (txtAccountReceiptID.Text.Length > 0)
                                {
                                    Cursor = Cursors.WaitCursor;
                                    ValidateEmptyForeignKey();
                                    #region Update
                                    if (IsUpdate)
                                    {
                                        tbl_accAccountReceipt oldRecord = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
                                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                        {
                                            if (CheckValidity_Dependancies(oldRecord.AccountReceipt_ID))
                                            {
                                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)//&& clsValidate.CheckAccountPostingValidity(oldRecord.AccountReceipt_ID))
                                                {
                                                    if (!oldRecord.IsChecked ||
                                                        (oldRecord.IsChecked &&
                                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged,
                                                             iFormID)))
                                                    {
                                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAccountReceiptID.Text))
                                                        {
                                                            //tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                                            // tbl_accGLPosting_Detail_Tmp.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                                            clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);

                                                            string sChequeNo = "";

                                                            #region Delete & Insert Cheque Detials

                                                            if (decimal.Parse(txtChequeAmount.Text.Trim()) > 0)
                                                            {
                                                                string sRegisterID = "",
                                                                    BankID = "",
                                                                    BranchID = "",
                                                                    AccountNo = "",
                                                                    chequeType = "",
                                                                    sChequeRemarks = "";
                                                                DateTime dCDate;
                                                                decimal Amount;

                                                                foreach (DataRow dRow in frm_accReceiptMultipleCheque
                                                                    .dtRecodes.Rows)
                                                                {
                                                                    sRegisterID = dRow["ChequeRegisterID"].ToString();
                                                                    sChequeNo = dRow["ChequeNo"].ToString();
                                                                    BankID = dRow["BankID"].ToString();
                                                                    BranchID = dRow["BranchID"].ToString();
                                                                    AccountNo = dRow["AccountNo"].ToString();
                                                                    chequeType = dRow["ChequeType"].ToString();
                                                                    dCDate = DateTime.Parse(dRow["ChequeDate"]
                                                                        .ToString());
                                                                    Amount = Convert.ToDecimal(dRow["Amount"]);
                                                                    sChequeRemarks = dRow["Remarks"].ToString();

                                                                    int iCompanyAccount_ID =
                                                                        clsGenaralName
                                                                            .getName_CompanyAccount_IDByAccountNo(
                                                                                AccountNo);

                                                                    #region acc Account Receipt Cheque Amount Update

                                                                    tbl_accAccountReceipt_ChequeAmount ARCdetail =
                                                                        tbl_accAccountReceipt_ChequeAmount.Select(
                                                                            txtAccountReceiptID.Text.ToString(),
                                                                            AccountNo);
                                                                    if (ARCdetail != null)
                                                                    {
                                                                        tbl_accAccountReceipt_ChequeAmount ARdetail =
                                                                            new tbl_accAccountReceipt_ChequeAmount(
                                                                                txtAccountReceiptID.Text.Trim(),
                                                                                AccountNo, Amount);
                                                                        ARdetail.Update();
                                                                    }
                                                                    else
                                                                    {
                                                                        tbl_accAccountReceipt_ChequeAmount ARdetail =
                                                                            new tbl_accAccountReceipt_ChequeAmount(
                                                                                txtAccountReceiptID.Text.Trim(),
                                                                                AccountNo, Amount);
                                                                        ARdetail.Insert();
                                                                    }

                                                                    #endregion

                                                                    #region Update tbl_bpsChequeRegister

                                                                    tbl_bpsChequeRegister objChequeOld =
                                                                        tbl_bpsChequeRegister.Select(sRegisterID);
                                                                    if (objChequeOld != null)
                                                                    {
                                                                        tbl_bpsChequeRegister objNewCheque =
                                                                            new tbl_bpsChequeRegister(sRegisterID,
                                                                                sChequeRemarks, dtpVoucherDate.Value,
                                                                                objChequeOld.PaymentMethod_ID,
                                                                                objChequeOld.TransferType, "",
                                                                                objChequeOld.GiftVoucherID,
                                                                                objChequeOld.Merchant_DeviceID,
                                                                                objChequeOld.LastFourDigits,
                                                                                objChequeOld.CardOwnerName,
                                                                                objChequeOld.CardType,
                                                                                objChequeOld.CardCategory, dCDate,
                                                                                txtCustomerID.Tag.ToString(),
                                                                                AccountNo, "default",
                                                                                iCompanyAccount_ID, BankID, "default",
                                                                                BranchID, "default",
                                                                                clsAutocode.getChequeStatusID(
                                                                                    ChequeStatus.New),
                                                                                clsAutocode.getChequeStatusID(
                                                                                    ChequeStatus.New),
                                                                                "default",
                                                                                objChequeOld.PosTransaction_ID,
                                                                                "default", "default",
                                                                                txtAccountReceiptID.Text.ToString(),
                                                                                "default", sChequeNo,
                                                                                objChequeOld.GlPosting_ID,
                                                                                clsAutocode.getGLPostingStatusID(
                                                                                    GLPostingStatus.NewTransaction),
                                                                                objChequeOld.PostingStatus_ID2,
                                                                                clsSecurity.FinancialYearID,
                                                                                Amount, objChequeOld.IsSetteled,
                                                                                objChequeOld.IsSetteledReturned,
                                                                                objChequeOld.IsDepositted,
                                                                                objChequeOld.IsReIssued,
                                                                                objChequeOld.IsReconcilied,
                                                                                objChequeOld.IsReturned,
                                                                                objChequeOld.IsReturnedToSender,
                                                                                objChequeOld.CreateUser_ID,
                                                                                clsSecurity.UserIDLoged,
                                                                                objChequeOld.DateCreate,
                                                                                clsSecurity.getServerDateTime(),
                                                                                objChequeOld.IsDeleted,
                                                                                objChequeOld.IsLocked,
                                                                                objChequeOld.DepositCount,
                                                                                objChequeOld.PaneltyAmount,
                                                                                objChequeOld.SetteledAmount,
                                                                                objChequeOld.DepositedCashAmount,
                                                                                objChequeOld.DateDeposited,
                                                                                objChequeOld.DateReconcilied,
                                                                                objChequeOld.DateReIssued,
                                                                                objChequeOld.DateReturnedToSender,
                                                                                objChequeOld.CompanyID,
                                                                                objChequeOld.CompanyBranch_ID,
                                                                                objChequeOld.PosReturnTransaction_Index,
                                                                                objChequeOld.AdvanceReceived_Index,
                                                                             objChequeOld.RecSerialNo);
                                                                        objNewCheque.Update();
                                                                    }

                                                                    #endregion
                                                                }
                                                            }

                                                            #endregion

                                                            #region Insert Cash Detials

                                                            if (decimal.Parse(txtCashAmount.Text.Trim()) > 0)
                                                            {
                                                                #region Update tbl_bpsChequeRegister

                                                                tbl_bpsChequeRegister objChequeOld =
                                                                    tbl_bpsChequeRegister.Select(oldRecord
                                                                        .ChequeRegister_ID);
                                                                if (objChequeOld != null)
                                                                {
                                                                    tbl_bpsChequeRegister objNewCash =
                                                                        new tbl_bpsChequeRegister(
                                                                            oldRecord.ChequeRegister_ID, "",
                                                                            dtpVoucherDate.Value,
                                                                            (int) PaymentMethod.Cash,
                                                                            (-1), "", (-1), (-1), "", "", (-1), (-1),
                                                                            dtpVoucherDate.Value,
                                                                            txtCustomerID.Tag.ToString(), "default", "",
                                                                            -1, "default", "default", "default",
                                                                            "default",
                                                                            "default", "default", "default", "-1",
                                                                            "default", "default",
                                                                            txtAccountReceiptID.Text, "default", "",
                                                                            objChequeOld.GlPosting_ID,
                                                                            objChequeOld.PostingStatus_ID,
                                                                            objChequeOld.PostingStatus_ID2,
                                                                            clsSecurity.FinancialYearID,
                                                                            decimal.Parse(txtCashAmount.Text),
                                                                            objChequeOld.IsSetteled,
                                                                            objChequeOld.IsSetteledReturned,
                                                                            objChequeOld.IsDepositted,
                                                                            objChequeOld.IsReIssued,
                                                                            objChequeOld.IsReconcilied,
                                                                            objChequeOld.IsReturned,
                                                                            objChequeOld.IsReturnedToSender,
                                                                            objChequeOld.CreateUser_ID,
                                                                            clsSecurity.UserIDLoged,
                                                                            objChequeOld.DateCreate,
                                                                            clsSecurity.getServerDateTime(),
                                                                            objChequeOld.IsDeleted,
                                                                            objChequeOld.IsLocked,
                                                                            objChequeOld.DepositCount,
                                                                            objChequeOld.PaneltyAmount,
                                                                            objChequeOld.SetteledAmount,
                                                                            objChequeOld.DepositedCashAmount,
                                                                            objChequeOld.DateDeposited,
                                                                            objChequeOld.DateReconcilied,
                                                                            objChequeOld.DateReIssued,
                                                                            objChequeOld.DateReturnedToSender,
                                                                            objChequeOld.CompanyID,
                                                                            objChequeOld.CompanyBranch_ID,
                                                                            objChequeOld.PosReturnTransaction_Index,
                                                                            objChequeOld.AdvanceReceived_Index,
                                                                            objChequeOld.RecSerialNo);
                                                                    objNewCash.Update();
                                                                }

                                                                #endregion

                                                            }

                                                            #endregion

                                                            #region Update tbl_accAccountReceipt & tbl_accAccountReceipt_Details

                                                            foreach (tbl_accAccountReceipt_Details ARdetail in
                                                                tbl_accAccountReceipt_Details
                                                                    .SelectAllByAccountReceipt_ID(txtAccountReceiptID
                                                                        .Text.ToString()))
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
                                                                    sGLCode = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "accCode", row.Index, "");
                                                                    sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "subAcc1", row.Index, "");
                                                                    sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "subAcc2", row.Index, "");
                                                                    sCategoryID =
                                                                        clsValidate.ValidateGridValue(dgvDetail,
                                                                            "CategoryID", row.Index, "");
                                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "Remarks", row.Index, "");
                                                                    sSubAcct1_ID =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "subAcc1", row.Index, "default");
                                                                    sSubAcct2_ID =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "subAcc2", row.Index, "default");
                                                                    sEmployee_ID =
                                                                        clsValidate.ValidateGridTag(dgvDetail,
                                                                            "employee", row.Index, "default");
                                                                    sOtherCr = clsValidate.ValidateGridTag(dgvDetail,
                                                                        "otherCr", row.Index, "default");
                                                                    bIsCredit = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "IsCredit", row.Index, true);
                                                                    iRow = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "LineNo", row.Index, int.Parse("0"));

                                                                    if (bIsCredit)
                                                                        dAmount = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "creditAmount", row.Index,
                                                                            decimal.Parse("0.00"));
                                                                    else
                                                                        dAmount = clsValidate.ValidateGridValue(
                                                                            dgvDetail, "debitAmount", row.Index,
                                                                            decimal.Parse("0.00"));

                                                                    if (iRow == ARdetail.Line_No &&
                                                                        ARdetail.AccountReceipt_ID ==
                                                                        txtAccountReceiptID.Text.Trim() &&
                                                                        sCategoryID == ARdetail.Tc_ID &&
                                                                        sGLCode == ARdetail.Gl_ID)
                                                                    {
                                                                        bHasItemInDB = true;
                                                                        dgvDetail.Rows.RemoveAt(row.Index);
                                                                        break; //database contain this item
                                                                    }
                                                                }

                                                                if (bHasItemInDB)
                                                                {
                                                                    ARdetail.Line_No = iRow;
                                                                    ARdetail.Gl_ID = sGLCode;
                                                                    ARdetail.CostCenter1_ID = sSubAcct1_ID;
                                                                    ARdetail.CostCenter2_ID = sSubAcct2_ID;
                                                                    ARdetail.Employee_ID = sEmployee_ID;
                                                                    ARdetail.Customer_ID = sOtherCr;
                                                                    ARdetail.Tc_ID = sCategoryID;
                                                                    ARdetail.Amount = dAmount;
                                                                    //PVdetail.Remarks = sRemarks;
                                                                    ARdetail.Update();

                                                                    //#region GL Posting Detail
                                                                    //clsProcessMethods.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.AccountReceipt), txtAccountReceiptID.Text.Trim(), sGLCode,
                                                                    //                sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtAccountReceiptID.Text.Trim(), "default",
                                                                    //                dtpVoucherDate.Value, txtNarration.Text.Trim(), dAmount, bIsCredit, sChequeNo, txtReceivedOf.Text.Trim());
                                                                    //#endregion
                                                                }
                                                                else
                                                                {
                                                                    //clsMethods_Fin.GLPostingDetailTempDelete(ARdetail.Line_No, oldRecord.GlPosting_ID);
                                                                    ARdetail.Delete();
                                                                }
                                                            }

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
                                                                    sRemarks = "";
                                                                bool bIsCredit;
                                                                decimal dAmount;

                                                                sGLCode = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "accCode", row.Index, "");
                                                                sSubAcct1 = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "subAcc1", row.Index, "");
                                                                sSubAcct2 = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "subAcc2", row.Index, "");
                                                                sCategoryID = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "CategoryID", row.Index, "");
                                                                sRemarks = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "Remarks", row.Index, "");
                                                                sSubAcct1_ID = clsValidate.ValidateGridTag(dgvDetail,
                                                                    "subAcc1", row.Index, "default");
                                                                sSubAcct2_ID = clsValidate.ValidateGridTag(dgvDetail,
                                                                    "subAcc2", row.Index, "default");
                                                                sEmployee_ID = clsValidate.ValidateGridTag(dgvDetail,
                                                                    "employee", row.Index, "default");
                                                                sOtherCr = clsValidate.ValidateGridTag(dgvDetail,
                                                                    "otherCr", row.Index, "default");
                                                                bIsCredit = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "IsCredit", row.Index, true);
                                                                iRow = clsValidate.ValidateGridValue(dgvDetail,
                                                                    "LineNo", row.Index, int.Parse("0"));
                                                                if (bIsCredit)
                                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "creditAmount", row.Index,
                                                                        decimal.Parse("0.00"));
                                                                else
                                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail,
                                                                        "debitAmount", row.Index,
                                                                        decimal.Parse("0.00"));

                                                                #region Insert tbl_accAccountReceipt_Details

                                                                tbl_accAccountReceipt_Details Insdetail =
                                                                    new tbl_accAccountReceipt_Details(iRow,
                                                                        txtAccountReceiptID.Text.Trim(), sCategoryID,
                                                                        sGLCode, sOtherCr, "Default", sEmployee_ID,
                                                                        "default", sSubAcct1_ID, sSubAcct2_ID, dAmount,
                                                                        bIsCredit);
                                                                Insdetail.Insert();

                                                                #endregion

                                                                #region GL Posting Detail

                                                                //clsMethods_Fin.GLPostingDetailTemp(iRow, oldRecord.GlPosting_ID, clsAutocode.getAccSlotID(AccSlot.AccountReceipt), txtAccountReceiptID.Text.Trim(), sGLCode,
                                                                //sSubAcct1_ID, sSubAcct2_ID, "default", "default", sEmployee_ID, "default", "-", txtAccountReceiptID.Text.Trim(), "default", dtpVoucherDate.Value, txtNarration.Text.Trim(), dAmount, bIsCredit, sChequeNo, txtReceivedOf.Text.Trim());

                                                                #endregion
                                                            }

                                                            #endregion

                                                            #region Update GLPostingHeaderTemp

                                                            //clsMethods_Fin.GLPostingHeaderTempUpdate(oldRecord.GlPosting_ID, dtpVoucherDate.Value, txtNarration.Text.Trim());

                                                            #endregion

                                                            #region  Insert Header - tbl_accAccountReceipt

                                                            decimal dTotal = GetARAmount();
                                                            tbl_accAccountReceipt detail = new tbl_accAccountReceipt(
                                                                txtAccountReceiptID.Text.Trim(), dtpVoucherDate.Value,
                                                                txtRemarks.Text.Trim(), txtNarration.Text.Trim(),
                                                                txtReceivedOf.Text.Trim(),
                                                                oldRecord
                                                                    .ChequeRegister_ID, //befotr cheque register Id 'default'
                                                                txtCustomerID.Tag.ToString().Trim(),
                                                                txtSupplierID.Tag.ToString().Trim(),
                                                                txtEmployeeID.Tag.ToString().Trim(), "default",
                                                                txtRevenueCenter1.Tag.ToString().Trim(),
                                                                txtRevenueCenter2.Tag.ToString().Trim(), "defaut",
                                                                "default",
                                                                oldRecord.GlPosting_ID,
                                                                clsAutocode.getGLPostingStatusID(GLPostingStatus
                                                                    .NewTransaction), clsSecurity.FinancialYearID,
                                                                clsSecurity.CompanyID, clsSecurity.BranchID,
                                                                clsConfig.sLocalCurrencyCode, decimal.Parse("0"),
                                                                decimal.Parse(txtCashAmount.Text.Trim()),
                                                                oldRecord.DepositedCashAmount,
                                                                decimal.Parse(txtChequeAmount.Text.Trim()), dTotal,
                                                                oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                                oldRecord.CheckedUser_ID,
                                                                oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID,
                                                                oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID,
                                                                clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID,
                                                                oldRecord.PrintedTerminal_ID,
                                                                oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                                oldRecord.DateChecked, oldRecord.DateApproved,
                                                                oldRecord.DateDeleted, oldRecord.DatePrinted,
                                                                oldRecord.IsChecked, oldRecord.IsApproved,
                                                                oldRecord.IsFinished, oldRecord.IsDeleted,
                                                                oldRecord.IsLocked, oldRecord.IsSeattled,
                                                                oldRecord.PrintCount, oldRecord.IsCashDeposited,
                                                                oldRecord.DateDeposited,
                                                                oldRecord.PostingStatus_CashDeposit);
                                                            detail.Update();

                                                            #endregion

                                                            #endregion

                                                            clsMethods_GL.PostTransaction_AccountsReciept(
                                                                txtAccountReceiptID.Text.ToString());

                                                            //Attachments.Insert(iFormID, oldRecord.AccountReceipt_ID);
                                                            //Attachments.Remove(iFormID, oldRecord.AccountReceipt_ID);

                                                            MessageBox.Show(
                                                                clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                                MessageBoxIcon.Information);
                                                        }
                                                    }
                                                    else
                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    }
                                    #endregion

                                    #region Insert
                                    else
                                    {
                                        if (clsConfig.bBranchMaster_SerialNoActiveFor_SalesReceipt)
                                            txtAccountReceiptID.Text = clsAutocode.getAutoGeneratedCode_FromCompanyBranch_SalesReceipt(clsSecurity.BranchID);
                                        else if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                            txtAccountReceiptID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAccountReceiptID.Text)) //if (txtAccountReceiptID.Text.Length > 0)
                                        {
                                            string sChequeNo = "";

                                            #region Insert Header AR
                                            decimal dTotal = GetARAmount();
                                            tbl_accAccountReceipt detail = new tbl_accAccountReceipt(txtAccountReceiptID.Text.Trim(), dtpVoucherDate.Value, txtRemarks.Text.Trim(), txtNarration.Text.Trim(), txtReceivedOf.Text.Trim(), "default",
                                                 txtCustomerID.Tag.ToString().Trim(), txtSupplierID.Tag.ToString().Trim(), txtEmployeeID.Tag.ToString().Trim(), "default", txtRevenueCenter1.Tag.ToString().Trim(), txtRevenueCenter2.Tag.ToString().Trim(), "defaut", "default",
                                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, clsConfig.sLocalCurrencyCode, decimal.Parse("0"), decimal.Parse(txtCashAmount.Text.Trim()), 0, decimal.Parse(txtChequeAmount.Text.Trim()), dTotal,
                                                clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                false, false, false, false, false, false, 0, false, clsSecurity.getServerDateTime(), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction));
                                            detail.Insert();
                                            #endregion

                                            #region Insert Cheque Detials
                                            if (decimal.Parse(txtChequeAmount.Text.Trim()) > 0)
                                            {
                                                string sRegisterID = "", BankID = "", BranchID = "", AccountNo = "", chequeType = "", sChequeRemarks = "";
                                                DateTime dCDate;
                                                decimal Amount;

                                                foreach (DataRow dRow in frm_accReceiptMultipleCheque.dtRecodes.Rows)
                                                {
                                                    sRegisterID = dRow["ChequeRegisterID"].ToString();
                                                    sChequeNo = dRow["ChequeNo"].ToString();
                                                    BankID = dRow["BankID"].ToString();
                                                    BranchID = dRow["BranchID"].ToString();
                                                    AccountNo = dRow["AccountNo"].ToString();
                                                    chequeType = dRow["ChequeType"].ToString();
                                                    dCDate = DateTime.Parse(dRow["ChequeDate"].ToString());
                                                    Amount = Convert.ToDecimal(dRow["Amount"]);
                                                    sChequeRemarks = dRow["Remarks"].ToString();

                                                    int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(AccountNo);

                                                    tbl_accAccountReceipt_ChequeAmount details = new tbl_accAccountReceipt_ChequeAmount(txtAccountReceiptID.Text.Trim(), AccountNo, Amount);
                                                    details.Insert();
                                                    if (sRegisterID.Length == 0)
                                                    {
                                                        // if (clsAutocode.IsAutoGenerated(clsAutocode.getFormConfigCode(FormName.ChequeRegister)))
                                                        sRegisterID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ChequeRegister));
                                                    }
                                                    tbl_bpsChequeRegister objCheque = tbl_bpsChequeRegister.Select(sRegisterID);
                                                    if (objCheque == null)
                                                    {
                                                        tbl_bpsChequeRegister objNewCheque = new tbl_bpsChequeRegister(sRegisterID, sChequeRemarks, dtpVoucherDate.Value, (int)PaymentMethod.Cheque, (-1), "", (-1), (-1), "", "", (-1), (-1), dCDate, txtCustomerID.Tag.ToString(), AccountNo, "default", iCompanyAccount_ID, BankID, "default", BranchID, "default", clsAutocode.getChequeStatusID(ChequeStatus.New),
                                                            chequeType, "default", "-1", "default", "default", txtAccountReceiptID.Text.ToString(), "default", sChequeNo, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                                                            Amount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                            false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1),(-1));
                                                        objNewCheque.Insert();

                                                        //update Receipt header table
                                                        dTotal = GetARAmount();
                                                        detail = new tbl_accAccountReceipt(txtAccountReceiptID.Text.Trim(), dtpVoucherDate.Value, txtRemarks.Text.Trim(), txtNarration.Text.Trim(), txtReceivedOf.Text.Trim(), sRegisterID,
                                                            txtCustomerID.Tag.ToString().Trim(), txtSupplierID.Tag.ToString().Trim(), txtEmployeeID.Tag.ToString().Trim(), "default", txtRevenueCenter1.Tag.ToString().Trim(), txtRevenueCenter2.Tag.ToString().Trim(), "defaut", "default",
                                                            "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, clsConfig.sLocalCurrencyCode, decimal.Parse("0"), decimal.Parse(txtCashAmount.Text.Trim()), 0, decimal.Parse(txtChequeAmount.Text.Trim()), dTotal,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                            clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                            false, false, false, false, false, false, 0, false, clsSecurity.getServerDateTime(), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction));
                                                        detail.Update();
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region Insert Cash Detials
                                            if (decimal.Parse(txtCashAmount.Text.Trim()) > 0)
                                            {
                                                string sChequeRegisterCode = "";
                                                sChequeRegisterCode = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.CashRegister));

                                                tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sChequeRegisterCode, "", dtpVoucherDate.Value, (int)PaymentMethod.Cash,
                                                      (-1), "", (-1), (-1), "", "", (-1), (-1), dtpVoucherDate.Value, txtCustomerID.Tag.ToString(), "default", "", -1, "default", "default", "default", "default",
                                                      "default", "default", "default", "default", "default", "default", txtAccountReceiptID.Text, "default", "", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                                                      clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, decimal.Parse(txtCashAmount.Text.Trim()),
                                                      false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                      false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1),(-1));
                                                RegisterDetails.Insert();

                                                //update Receipt header table
                                                dTotal = GetARAmount();
                                                tbl_accAccountReceipt oAR = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text);
                                                oAR.ChequeRegister_ID = sChequeRegisterCode;
                                                oAR.TotalAmount = dTotal;
                                                oAR.Update();
                                            }
                                            #endregion

                                            #region  Insert Detail - Journal Details
                                            int iRow;
                                            string sGLCode = "", sSubAcct1 = "", sSubAcct2 = "", sSubAcct1_ID = "", sSubAcct2_ID = "", sEmployee = "", sEmployee_ID = "", sOtherCr = "", sCategoryID = "", sRemarks = "";
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

                                                if (bIsCredit)
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "creditAmount", row.Index, decimal.Parse("0.00"));
                                                else
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "debitAmount", row.Index, decimal.Parse("0.00"));

                                                #region  tbl_accAccountReceipt_Details
                                                tbl_accAccountReceipt_Details Insdetail = new tbl_accAccountReceipt_Details(iRow, txtAccountReceiptID.Text.Trim(), sCategoryID,
                                                sGLCode, txtCustomerID.Tag.ToString(), sOtherCr, sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dAmount, bIsCredit);
                                                Insdetail.Insert();
                                                #endregion
                                            }
                                            #endregion

                                            clsMethods_GL.PostTransaction_AccountsReciept(txtAccountReceiptID.Text.ToString());
                                            Attachments.Insert(txtAccountReceiptID.Text.ToString());

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        //else
                                        //    MessageBox.Show("Account Receipt Number " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                tbl_accAccountReceipt Fdetail = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.ToString());
                                if (Fdetail != null)
                                {
                                    ClearFileds();
                                    FillDetails(Fdetail.AccountReceipt_ID);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_accAccountReceipt_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_accAccountReceipt_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_accAccountReceipt_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Add Grid
        private void btnAddGrid_Click(object sender, EventArgs e)
        {
            if (CheckValidityGridPanel())
            {
                if (ValidateGrid())
                {
                    int iRow = 0;
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    FillGrid(iRow, "", "", "", "", 0);
                    CalculateCreditDebitAmounts();
                }
            }
        }
        #endregion

        #region Btn Delete Grid
        private void btnGridDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count != 0)
                {
                    if (dgvDetail.Rows.Count > 0)
                        dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                    CheckGridViewAmount();
                    CalculateCreditDebitAmounts();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Print
        private void frm_accAccountReceipt_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_accAccountReceipt_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Temp
        private void frm_accAccountReceipt_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtAccountReceiptID.TextLength > 0 && txtAccountReceiptID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_NormalLabel(lblReceiptNo, true);
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccountReceiptID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtNarration, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtRemarks, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtOtherCreditor, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtEmployeeID, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOtherCreditor, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);

                txtAccountReceiptID.Tag = null;
                dtpVoucherDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtAccountReceiptID.Text = "<Auto Generate>";
                else
                    txtAccountReceiptID.Clear();
                if (txtAccountReceiptID.Enabled)
                {
                    txtAccountReceiptID.SelectAll();
                    txtAccountReceiptID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorAccount2, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fileds
        private void ClearFileds()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;
            //llblChequePrint.Enabled = false;

            clsCommon.SetEnableDisable_NormalLabel(lblReceiptNo, true);
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccountReceiptID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtNarration, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtRemarks, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtOtherCreditor, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtEmployeeID, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOtherCreditor, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoCashAmount, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoChequeAmount, true);
            
            txtAccountReceiptID.Tag = null;
            txtOtherCreditor.Tag = null;
            txtCustomerID.Tag = null;
            txtSupplierID.Tag = null;
            txtEmployeeID.Tag = null;
            txtRevenueCenter1.Tag = null;
            txtRevenueCenter2.Tag = null;
            txtCashAmount.Tag = null;
            txtChequeAmount.Tag = null;

            txtEmployeeID_GLCode.Tag = null;
            txtCostCenter1_GLCode.Tag = null;
            txtCostCenter2_GLCode.Tag = null;
            txtCash_GLCode.Tag = null;
            txtCheque_GLCode.Tag = null;

            //txtAPNID.Tag = null;
            //txtCreditNote.Tag = null;

            txtOtherCreditor.Clear();
            txtCustomerID.Clear();
            txtSupplierID.Clear();
            txtEmployeeID.Clear();
            txtRevenueCenter1.Clear();
            txtRevenueCenter2.Clear();

            txtEmployeeID_GLCode.Clear();
            txtCostCenter1_GLCode.Clear();
            txtCostCenter2_GLCode.Clear();

            txtCashAmount.Clear();
            txtCash_GLCode.Clear();
            txtChequeAmount.Clear();
            txtCheque_GLCode.Clear();

            dtpVoucherDate.Value = clsSecurity.getServerDateTime();

            txtAccountReceiptID.Clear();
            txtNarration.Clear();
            txtRemarks.Clear();
            txtReceivedOf.Clear();
            //txtAPNID.Clear();
            //txtCreditNote.Clear();

            txtChequeAmount.Text = "0.00";
            txtCashAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";

            pbxCashAmount.Enabled = false;
            chkShowSettle.Checked = false;
            rdoCashAmount.Checked = true;

            chkPrintOriginal.Checked = false;

            dgvDetail.Rows.Clear();
            txtCreditAmount.Text = "0.00";
            txtDebitAmount.Text = "0.00";
            txtBalanceAmount.Text = "0.00";

            pbxSupplier.Image = Digiteq.Properties.Resources.accept;
            pbxSup.Image = Digiteq.Properties.Resources.accept;
            pbxEmployee.Image = Digiteq.Properties.Resources.accept;
            pbxOtherCr.Image = Digiteq.Properties.Resources.accept;
            pbxCashAmount.Image = Digiteq.Properties.Resources.accept;
            pbxChequeAmount.Image = Digiteq.Properties.Resources.accept;

            frm_accReceiptMultipleCheque.dtRecodes.Rows.Clear();
            glb_dtCheque.Rows.Clear();
            glb_dtCash.Rows.Clear();
            glb_dtSupplier.Rows.Clear();
            glb_dtSup.Rows.Clear();
            glb_dtOther_Cr.Rows.Clear();

            dGridAmount = 0;
            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            clsEvent.GLCode_TextChanged(pbxOtherCr, "");
            clsEvent.GLCode_TextChanged(pbxSupplier, "");
            clsEvent.GLCode_TextChanged(pbxSup, "");
            clsEvent.GLCode_TextChanged(pbxEmployee, "");
            clsEvent.GLCode_TextChanged(pbxCashAmount, "");
            clsEvent.GLCode_TextChanged(pbxChequeAmount, "");

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtAccountReceiptID.Text = "<Auto Generate>";
            else
                txtAccountReceiptID.Clear();
            if (txtAccountReceiptID.Enabled)
            {
                txtAccountReceiptID.SelectAll();
                txtAccountReceiptID.Focus();
            }
            EnableDisablePaymentModePanel();

            Attachments.Clear();
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
                    clsEvent.GLCode_TextChanged(pbxCashAmount, glb_dtCash, txtCashAmount, null);
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
                        //sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount);
                    }
                }
                if (glb_dtCheque.Rows.Count > 0)
                {
                    clsEvent.GLCode_TextChanged(pbxChequeAmount, glb_dtCheque, txtChequeAmount, null);
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
                        //sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, false, dAmount);
                    }
                }
                if (glb_dtOther_Cr.Rows.Count > 0)
                {
                    TextBox txt;
                    if (decimal.Parse(txtChequeAmount.Text) > 0)
                        txt = txtChequeAmount;
                    else
                        txt = txtCashAmount;

                    clsEvent.GLCode_TextChanged(pbxOtherCr, glb_dtOther_Cr, txt, null);
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
                        //sRemarks = row["Remarks"].ToString();
                        sCategoryID = row["CategoryID"].ToString();

                        decimal dAmount = decimal.Parse(row["GLAmount"].ToString());

                        Fill_Datagrid(iRow, sGLCode, sSubAcct1, sSubAcct2, sSubAcct1_ID, sSubAcct2_ID, sEmployee, sEmployee_ID, sOtherCr, sCategoryID, sRemarks, true, dAmount);
                    }
                }
                if (glb_dtSupplier.Rows.Count > 0)
                {
                    TextBox txt;
                    if (decimal.Parse(txtChequeAmount.Text) > 0)
                        txt = txtChequeAmount;
                    else
                        txt = txtCashAmount;

                    clsEvent.GLCode_TextChanged(pbxSupplier, glb_dtSupplier, txt, null);
                    foreach (DataRow row in glb_dtSupplier.Rows)
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
                }

                if (glb_dtSup.Rows.Count > 0)
                {
                    TextBox txt;
                    if (decimal.Parse(txtChequeAmount.Text) > 0)
                        txt = txtChequeAmount;
                    else
                        txt = txtCashAmount;

                    clsEvent.GLCode_TextChanged(pbxSup, glb_dtSup, txt, null);
                    foreach (DataRow row in glb_dtSup.Rows)
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
                }
                CalculateBalance();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }

        private void RefreshGridSubTotal()
        {
            try
            {
                decimal dTotAmount = 0;
                foreach (DataRow row in glb_dtSubTotal.Rows)
                {
                    decimal dAmount = decimal.Parse(row["GLAmount"].ToString());
                    dTotAmount += dAmount;
                }
                txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotAmount);
                txtChequeAmount.Tag = clsFormatter.FormatToCurrecyWithThousendSep(dTotAmount);
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
                    tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_NormalLabel(lblReceiptNo, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAccountReceiptID, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOtherCreditor, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);

                        clsCommon.SetEnableDisable_NormalRadioButton(rdoCashAmount, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoChequeAmount, false);

                        //txtAccountReceiptID.Tag = detail.AccountReceipt_ID;
                        //txtOtherCreditor.Tag = detail.Customer_ID;
                        //txtCustomerID.Tag = detail.Supplier_ID;
                        //txtEmployeeID.Tag = detail.Employee_ID;
                        //txtRevenueCenter1.Tag = detail.CostCenter1_ID;
                        //txtRevenueCenter2.Tag = detail.CostCenter2_ID;
                        txtAccountReceiptID.Tag = detail.AccountReceipt_ID;

                        if (detail.Supplier_ID == "default" && detail.Customer_ID == "default")
                        {
                            foreach (tbl_accAccountReceipt_Details oDetail in tbl_accAccountReceipt_Details.SelectAllByAccountReceipt_ID(sID).Where(p => p.IsCredit))
                            {
                                txtOtherCreditor.Tag = oDetail.Gl_ID;
                                txtOtherCreditor.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccountName(oDetail.Gl_ID));
                            }
                        }

                        txtCustomerID.Tag = detail.Customer_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtEmployeeID.Tag = detail.Employee_ID;
                        txtRevenueCenter1.Tag = detail.CostCenter1_ID;
                        txtRevenueCenter2.Tag = detail.CostCenter2_ID;

                        txtAccountReceiptID.Text = detail.AccountReceipt_ID;

                        //txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSupplierID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                        txtEmployeeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(detail.Employee_ID));
                        txtRevenueCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                        txtRevenueCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));
                        txtNarration.Text = detail.Narration;
                        txtRemarks.Text = detail.Remark;
                        txtReceivedOf.Text = detail.Receivedof;

                        rdoChequeAmount.Checked = (detail.ChequeAmount > 0) ? true : false;
                        rdoCashAmount.Checked = (detail.CashAmount > 0) ? true : false;

                        //llblChequePrint.Enabled = (detail.ChequeAmount > 0) ? true : false;

                        if (detail.ChequeAmount > 0)
                            txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount);
                        if (detail.CashAmount > 0)
                            txtCashAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount);

                        dtpVoucherDate.Value = detail.AccountReceiptDate;

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
                        //dgvAPN.Rows.Clear();

                        //Fill Cheque Detial
                        FillMultipleCheck(sID);

                        //Fill GL Codes
                        FillDetailGLCodes(sID);

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

        #region Fill Detail By APN
        private void FillDetailByAPN(string sID)
        {
            try
            {
                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(sID);
                if (detail != null)
                {
                    txtOtherCreditor.Tag = detail.Customer_ID;
                    txtCustomerID.Tag = detail.Supplier_ID;
                    txtEmployeeID.Tag = detail.Employee_ID;
                    txtRevenueCenter1.Tag = detail.CostCenter1_ID;
                    txtRevenueCenter2.Tag = detail.CostCenter2_ID;

                    txtOtherCreditor.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Customer_ID));
                    txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Supplier(detail.Supplier_ID));
                    txtEmployeeID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(detail.Employee_ID));
                    txtRevenueCenter1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID));
                    txtRevenueCenter2.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID));

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

        #region Fill Detail GL Code
        private void FillDetailGLCodes(string sAccountReceipt_ID)
        {
            try
            {
                //Clear GLs
                glb_dtCash.Rows.Clear();
                glb_dtCheque.Rows.Clear();
                glb_dtOther_Cr.Rows.Clear();
                glb_dtSupplier.Rows.Clear();
                glb_dtSup.Rows.Clear();

                //Fill GLs
                //List<tbl_accPaymentVoucher_SubTotal> details = tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(sPaymentVoucher_ID);
                List<tbl_accAccountReceipt_Details> details = tbl_accAccountReceipt_Details.SelectAllByAccountReceipt_ID(sAccountReceipt_ID);
                foreach (tbl_accAccountReceipt_Details detail in details)
                {
                    if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr).ToString())
                    {
                        glb_dtOther_Cr.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxOtherCr, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Customer).ToString())
                    {
                        glb_dtSupplier.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Customer)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxSupplier, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier).ToString())
                    {
                        glb_dtSup.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxSup, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cash).ToString())
                    {
                        glb_dtCash.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Cash)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
                        clsEvent.GLCode_TextChanged(pbxCashAmount, "Accept");
                    }
                    else if (detail.Tc_ID == clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque).ToString())
                    {
                        glb_dtCheque.Rows.Add(detail.Line_No, detail.Gl_ID, clsGenaralName.getName_AccountName(detail.Gl_ID), detail.Amount,
                            clsGenaralName.getName_AccCostCenter1(detail.CostCenter1_ID), clsGenaralName.getName_AccCostCenter2(detail.CostCenter2_ID), clsGenaralName.getName_Employee(detail.Employee_ID), detail.Customer_ID, clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque)
                            , detail.CostCenter1_ID, detail.CostCenter2_ID, detail.Employee_ID);
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

        #region Fill Grid
        private void FillGrid(int iRow, string sGlCode, string sAccountName, string sCostCenterCodeName, string sCostCenterCode, decimal Amount)
        {
            dgvDetail["GLCode", iRow].Value = clsCommon.GetForeignKeyValue(sGlCode);
            dgvDetail["AccountName", iRow].Value = sAccountName;
            dgvDetail["CostCenterCode", iRow].Value = sCostCenterCodeName;
            dgvDetail["CostCenterCode", iRow].Tag = clsCommon.GetForeignKeyValue(sCostCenterCode);
            dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
        }
        #endregion

        #region Fill Multiple Cheque
        private void FillMultipleCheck(string sID)
        {
            try
            {
                decimal chequeTotal = 0;
                frm_accReceiptMultipleCheque.CreateDataTable();
                frm_accReceiptMultipleCheque.dtRecodes.Clear();
                List<tbl_bpsChequeRegister> Cdetails = tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(sID);
                foreach (tbl_bpsChequeRegister Cdetail in Cdetails)
                {
                    if (Cdetail != null && !Cdetail.IsDeleted && Cdetail.PaymentMethod_ID == 1)
                    {
                        frm_accReceiptMultipleCheque.dtRecodes.Rows.Add(Cdetail.AccountNumber, clsGenaralName.getName_Bank(Cdetail.Bank_ID), Cdetail.ChequeNumber, Cdetail.DateCheque, Cdetail.ChequeType_ID, Cdetail.Amount, Cdetail.Bank_ID, Cdetail.Branch_ID, clsGenaralName.getName_BankBranch(Cdetail.Branch_ID), 1, Cdetail.ChequeRegister_ID);
                        chequeTotal += Cdetail.Amount;
                        txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(chequeTotal);
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
                {
                    dgvDetail.Columns["accName"].Width = 340 - 16;
                }
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
            //if (sCategory == "Customer")
            //{
            //    txtOtherCreditor.Tag = null;
            //    txtOtherCreditor.Clear();
            //    pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
            //    glb_dtOther_Cr.Clear();

            //}
            //else if (sCategory == "Supplier")
            //{
            //    txtSupplierID.Tag = null;
            //    txtSupplierID.Clear();
            //    pbxSup.Image = Digiteq.Properties.Resources.Free;
            //    glb_dtSup.Clear();
            //}
            //else if (sCategory == "OtherCreditor")
            //{
            //    txtCustomerID.Tag = null;
            //    txtCustomerID.Clear();
            //    pbxSupplier.Image = Digiteq.Properties.Resources.Free;
            //    glb_dtSupplier.Clear();
            //}

            if (sCategory == "OtherCreditor")
            {
                txtOtherCreditor.Tag = null;
                txtOtherCreditor.Clear();
                pbxOtherCr.Image = Digiteq.Properties.Resources.Free;
                glb_dtOther_Cr.Clear();

            }
            else if (sCategory == "Supplier")
            {
                txtSupplierID.Tag = null;
                txtSupplierID.Clear();
                pbxSup.Image = Digiteq.Properties.Resources.Free;
                glb_dtSup.Clear();
            }
            else if (sCategory == "Customer")
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();
                pbxSupplier.Image = Digiteq.Properties.Resources.Free;
                glb_dtSupplier.Clear();
            }

        }
        private void Search_OtherCreditorID()
        {
            try
            {
                if (GetARAmount() > 0)
                {
                    clsSearch.Search_MasterAccountGLCode(ref txtOtherCreditor, "", "");
                    if (txtOtherCreditor.Tag != null && txtOtherCreditor.Tag.ToString().Trim().Length > 0)
                    {
                        //txtPayee.Text = txtOtherCreditor.Text.Trim();
                        //string sGLCode = txtOtherCreditor.Tag.ToString().Trim();
                        //string sGlName = clsGenaralName.getName_AccountName(sGLCode);
                        //glb_dtOther_Cr.Rows.Clear();
                        //glb_dtOther_Cr.Rows.Add(1, sGLCode, sGlName, GetPVAmount(), "default", "default", "default", "default", TransactionCategory.Other_Cr, "default", "default");
                        //clsEvent.GLCode_TextChanged(pbxOtherCr, txtOtherCreditor.Tag.ToString().Trim());
                        //RefreshGrid();

                        string sGLCode = txtOtherCreditor.Tag.ToString().Trim();
                        string sGlName = clsGenaralName.getName_AccountName(sGLCode);
                        decimal dAmount = 0;
                        dAmount = decimal.Parse(txtCashAmount.Text) > 0 ? decimal.Parse(txtCashAmount.Text) : decimal.Parse(txtChequeAmount.Text);

                        glb_dtOther_Cr.Rows.Clear();
                        glb_dtOther_Cr.Rows.Add(1, sGLCode, sGlName, dAmount, "default", "default", "default", "default", TransactionCategory.Other_Cr, "default", "default");
                        clsEvent.GLCode_TextChanged(pbxOtherCr, txtOtherCreditor.Tag.ToString().Trim());
                        RefreshGrid();
                    }
                }
                else
                    MessageBox.Show("Please Input the Debit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SupplierID()
        {
            try
            {
                if (GetARAmount() > 0)
                {
                    clsSearch.Search_MasterSupplier(ref txtSupplierID);
                    if (txtSupplierID.Tag != null && txtSupplierID.Tag.ToString().Trim().Length > 0)
                    {
                        clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtCustomerID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        //txtPayee.Text = txtOtherCreditor.Text.Trim();
                        //string sGLCode = txtOtherCreditor.Tag.ToString().Trim();
                        //string sGlName = clsGenaralName.getName_AccountName(sGLCode);
                        //glb_dtOther_Cr.Rows.Clear();
                        //glb_dtOther_Cr.Rows.Add(1, sGLCode, sGlName, GetPVAmount(), "default", "default", "default", "default", TransactionCategory.Other_Cr, "default", "default");
                        //clsEvent.GLCode_TextChanged(pbxOtherCr, txtOtherCreditor.Tag.ToString().Trim());
                        //RefreshGrid();

                        clsEvent.GLCode_TextChanged(pbxSup, txtSupplierID.Tag.ToString().Trim());
                    }
                }
                else
                    MessageBox.Show("Please Input the Debit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #region Supplier, Customer and Employee
        private void Search_Supplier()
        {
            try
            {
                if (GetARAmount() > 0)
                {
                    clsSearch.Search_MasterSupplier(ref txtCustomerID);
                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                    {
                        txtReceivedOf.Text = txtCustomerID.Text.Trim();
                        string sGLCode = clsMethods_GL.getAccountCode_Supplier(txtCustomerID.Tag.ToString().Trim());
                        string sGlName = clsGenaralName.getName_AccountName(sGLCode);
                        glb_dtSupplier.Rows.Clear();
                        if (sGLCode != null && !sGLCode.Equals("default"))
                        {
                            //clsEvent.GLCode_TextChanged(pbxSupplier, txtSupplierID.Tag.ToString().Trim());
                            //glb_dtSupplier.Rows.Add(1, sGLCode, sGlName, GetPVAmount(), "default", "default", "default", "default", TransactionCategory.Supplier, "default", "default");
                            //RefreshGrid();
                        }
                        else
                        {
                            clsEvent.GLCode_TextChanged(pbxSupplier, "default");
                        }
                    }
                }
                else
                    MessageBox.Show("Please Input the Debit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (txtRevenueCenter2.Tag != null && txtRevenueCenter2.Tag.ToString().Trim().Length > 0)
                    txtCostCenter2_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter2ID(txtRevenueCenter2.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Customer()
        {
            try
            {
                if (GetARAmount() > 0)
                {
                    clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtSupplierID, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, false);
                    clsEvent.GLCode_TextChanged(pbxSupplier, txtCustomerID.Tag.ToString().Trim());
                }
                else
                    MessageBox.Show("Please Input the Debit Amount", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                clsSearch.Search_costCenter1(ref txtRevenueCenter1);
                if (txtRevenueCenter1.Tag != null && txtRevenueCenter1.Tag.ToString().Trim().Length > 0)
                    txtCostCenter1_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter1ID(txtRevenueCenter1.Tag.ToString().Trim());
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
                clsSearch.Search_costCenter2(ref txtRevenueCenter2);
                if (txtRevenueCenter2.Tag != null && txtRevenueCenter2.Tag.ToString().Trim().Length > 0)
                    txtCostCenter2_GLCode.Text = clsMethods_GL.getGLCode_ByCostCenter2ID(txtRevenueCenter2.Tag.ToString().Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
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
                {
                    MessageBox.Show("Value is existing", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return isExisting;
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Enable Disable Payment Panel
        private void EnableDisablePaymentModePanel()
        {
            //if (rdoCash.Checked)
            //{
            //    ResetPayMethod();
            //    clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, false);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCashAmount, true);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtChequeAmount1, false);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtCashAmount, true);
            //    llblChequeDetail.Enabled = false;
            //    PayMode = clsAutocode.getPaymentMethodCode(PaymentMethods.Cash);
            //}
            //else if (rdoCheque.Checked)
            //{
            //    ResetPayMethod();
            //    clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCashAmount, false);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtChequeAmount1, true);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtCashAmount, false);

            //    llblChequeDetail.Enabled = true;
            //    PayMode = clsAutocode.getPaymentMethodCode(PaymentMethods.Cheque);
            //    if (!IsUpdate)
            //    {
            //        MC.ShowDialog();
            //        if (MC.DialogResult == DialogResult.OK)
            //        {
            //            txtChequeAmount1.Text = clsFormatter.FormatToCurrecyWithThousendSep(MC.dTotal);
            //        }
            //    }
            //}
            //else if (rdoCashAndCheque.Checked)
            //{
            //    ResetPayMethod();
            //    clsCommon.SetEnableDisable_NormalLabel(lblChequeAmount, true);
            //    clsCommon.SetEnableDisable_NormalLabel(lblCashAmount, true);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtChequeAmount1, true);
            //    clsCommon.SetEnableDisable_NormalTextbox(txtCashAmount, true);
            //    llblChequeDetail.Enabled = true;
            //    PayMode = clsAutocode.getPaymentMethodCode(PaymentMethods.CashAndCheque);
            //}
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
        //private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_Customer(ref txtCustomerID);
        //    if (txtCustomerID.Tag != null)
        //    {
        //        FillGLAccountByCustomer();
        //    }
        //}

        //private void txtSupplier_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterSupplier(ref txtSupplierID);
        //    if (txtSupplierID.Tag != null)
        //    {
        //        FillGLAccountBySupplier();
        //    }
        //}

        //private void txtEmployee_DoubleClick(object sender, EventArgs e)
        //{
        //    clsSearch.Search_MasterEmployee(ref txtEmployeeID);
        //    if (txtEmployeeID.Tag != null)
        //    {
        //        FillGLAccountBEmployee();
        //    }
        //}

        private void txtVoucher_DoubleClick(object sender, EventArgs e)
        {

        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("Customer");
            Search_Customer();

        }

        private void txtSupplierID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("Supplier");
            Search_SupplierID();
        }

        private void txtCostCenter1_DoubleClick(object sender, EventArgs e)
        {
            //clearSubGLCodeExceptThis("CostCenter1");
            //Search_CostCenter1ID();
        }

        private void txtCostCenter2_DoubleClick(object sender, EventArgs e)
        {
            // clearSubGLCodeExceptThis("CostCenter2");
            // Search_CostCenter2ID();
        }

        private void txtEmployeeID_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("Employee");
            clsSearch.Search_MasterEmployee(ref txtEmployeeID);
            if (txtEmployeeID.Tag != null && txtEmployeeID.Tag.ToString().Trim().Length > 0)
                txtEmployeeID_GLCode.Text = clsMethods_GL.getGLCode_ByEmployeeID(txtEmployeeID.Tag.ToString().Trim());
        }

        private void txtOtherCreditor_DoubleClick(object sender, EventArgs e)
        {
            clearSubGLCodeExceptThis("OtherCreditor");
            Search_OtherCreditorID();
        }

        private void txtAccountReceiptID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TansactionAccountReceipt_New(ref txtAccountReceiptID, chkShowSettle.Checked);
            if (txtAccountReceiptID.Tag != null)
            {
                FillDetails(txtAccountReceiptID.Tag.ToString());
            }
        }
        #endregion

        #region  Event Text Changed
        private void txtCustomerID_GLCode_TextChanged_1(object sender, EventArgs e)
        {
            //clsEvent.GLCode_TextChanged(pbxOtherCr, txtCustomerID_GLCode.Text);
            //CalculateBalance();
            //if (IsValidateGridIsExsistingRowDetail(txtCustomerID_GLCode.Text.Trim()))
            //{
            //    RefreshGrid();
            //}
            //else 
            //{
            //    txtCustomerID_GLCode.Text = "default";
            //}                        
        }
        private void txtSupplierID_GLCode_TextChanged(object sender, EventArgs e)
        {
            //clsEvent.GLCode_TextChanged(pbxSupplier, txtSupplierID_GLCode.Text);
            //CalculateBalance();
            //if (IsValidateGridIsExsistingRowDetail(txtSupplierID_GLCode.Text.Trim()))
            //{
            //    RefreshGrid();
            //}
            //else 
            //{
            //    txtSupplierID_GLCode.Text = "default";
            //}                        
        }
        private void txtEmployeeID_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxEmployee, txtEmployeeID_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtEmployeeID_GLCode.Text.Trim()))
            {
                RefreshGrid();
            }
            else
            {
                txtEmployeeID_GLCode.Text = "default";
            }
        }
        private void txtCostCenter1_GLCode_TextChanged(object sender, EventArgs e)
        {
            //clsEvent.GLCode_TextChanged(pbxCostCenter1, txtCostCenter1_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCostCenter1_GLCode.Text.Trim()))
            {
                RefreshGrid();
            }
            else
            {
                txtCostCenter1_GLCode.Text = "default";
            }
        }
        private void txtCostCenter2_GLCode_TextChanged(object sender, EventArgs e)
        {
            //clsEvent.GLCode_TextChanged(pbxCostCenter2, txtCostCenter2_GLCode.Text);
            //CalculateBalance();
            //if (IsValidateGridIsExsistingRowDetail(txtSupplierID_GLCode.Text.Trim()))
            //{
            //    RefreshGrid();
            //}
            //else 
            //{
            //    txtCostCenter2_GLCode.Text = "default";
            //}                        
        }
        private void txtCash_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxCashAmount, txtCash_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCash_GLCode.Text.Trim()))
            {
                //RefreshGridSubTotal();
                RefreshGrid();
            }
            else
            {
                txtCash_GLCode.Text = "default";
            }
        }
        private void txtCheque_GLCode_TextChanged(object sender, EventArgs e)
        {
            clsEvent.GLCode_TextChanged(pbxChequeAmount, txtCheque_GLCode.Text);
            CalculateBalance();
            if (IsValidateGridIsExsistingRowDetail(txtCheque_GLCode.Text.Trim()))
            {
                //RefreshGridSubTotal();                
                RefreshGrid();
            }
            else
            {
                txtCheque_GLCode.Text = "default";
            }
        }
        private void txtCashAmount_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.GLCode_TextChanged(pbxCashAmount, glb_dtCash, txtCashAmount, null);
                pbxCashAmount.Enabled = true;
                //RefreshGrid();
            }
            else
            {
                pbxCashAmount.Enabled = false;
            }
        }
        private void txtChequeAmount_TextChanged(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                pbxChequeAmount.Enabled = true;
            }
            else
            {
                pbxChequeAmount.Enabled = false;
            }
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
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("Customer");
                Search_Customer();
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
        private void txtOtherCreditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clearSubGLCodeExceptThis("Customer");
                Search_OtherCreditorID();
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

        }

        private void txtAccountReceiptID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtAccountReceiptID_DoubleClick(sender, e);
            }
        }
        #endregion

        #region Event Key Up
        private void txtChequeAmount1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCashAmount_KeyUp(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Event Validate
        private void txtCashAmount_Validated(object sender, EventArgs e)
        {
            if (txtCashAmount.Text.Trim().Length <= 0)
            {
                txtCashAmount.Text = "0.00";
            }
        }
        private void txtCrAmount_Validated(object sender, EventArgs e)
        {
            //if (txtCrAmount.Text.Trim().Length <= 0)
            //{
            //    txtCrAmount.Text = "0.00";
            //}
        }
        #endregion

        #region Link Label Click
        private void llblChequeDetail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MC.ShowDialog();
            if (MC.DialogResult == DialogResult.OK)
            {
                txtChequeAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(MC.dTotal);
                //glb_dtCheque = MC.glb_dtSubTotal;
                //if (glb_dtCheque != null && glb_dtCheque.Rows.Count > 0)
                //{
                //RefreshGrid();
                //}
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (txtAccountReceiptID.Text.Trim().Length > 0 && txtAccountReceiptID.Text.Trim() != "<Auto Generate>")
                {
                    if (rdoChequeAmount.Checked == true)
                    {
                        frm_masAccChequePrinting frm = new frm_masAccChequePrinting();
                        if (txtAccountReceiptID.TextLength > 0)
                        {
                            List<tbl_accChequeRegister> Cdetails = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(txtAccountReceiptID.Text.Trim());
                            foreach (tbl_accChequeRegister Cdetail in Cdetails)
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
                        MessageBox.Show("There is no cheque to print ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Payment Voucher To Print Cheque ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtAccountReceiptID.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Account Receipt No ";
                    bStatus = false;
                }
                if (txtReceivedOf.Text.Trim().Length <= 0)
                {
                    strMessage += "\n" + "Received from ";
                    bStatus = false;
                }
                if (decimal.Parse(txtCashAmount.Text) == 0 && decimal.Parse(txtChequeAmount.Text) == 0)
                {
                    strMessage += "\n" + "Cash Amounts \n Cheque Amounts ";
                    bStatus = false;
                }
                if (dgvDetail.Rows.Count <= 0)
                {
                    strMessage += "\n" + "Fill Entries ";
                    bStatus = false;
                }
                if (decimal.Parse(txtBalanceAmount.Text.Trim()) != 0)
                {
                    strMessage += "\n" + "Amounts Not Tallying !!! Please Check Amounts ";
                    bStatus = false;
                }
                if (rdoChequeAmount.Checked)
                {
                    if (frm_accReceiptMultipleCheque.dtRecodes.Rows.Count <= 0)
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
                    if (dAmount != decimal.Parse(txtCashAmount.Text))
                    {
                        strMessage += "\n" + "Total credit amounts not equal to Cash Amounts ";
                        bStatus = false;
                    }
                }
                if (decimal.Parse(txtChequeAmount.Text) != 0)
                {
                    decimal dAmount = 0;
                    //foreach (DataRow row in glb_dtCheque.Rows)
                    foreach (DataRow row in frm_accReceiptMultipleCheque.dtRecodes.Rows)
                    {
                        dAmount = dAmount + decimal.Parse(row["Amount"].ToString());
                    }
                    if (dAmount != decimal.Parse(txtChequeAmount.Text))
                    {
                        strMessage += "\n" + "Total credit amounts not equal to Cheque Amounts ";
                        bStatus = false;
                    }
                }
                if (bStatus == false)
                {
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
        private bool CheckValidityChequeCash()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                //if ((clsCommon.isCurrency(txtCashAmount.Text.Trim()) && (decimal.Parse(txtCashAmount.Text.ToString()) > 0) || clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0))
                if (decimal.Parse(txtCashAmount.Text.ToString()) > 0 && clsCommon.isCurrency(txtCashAmount.Text.Trim()))
                {
                    strMessage += "\n" + "Cash Or Cheque Total ";
                    bStatus = false;
                }

                if (bStatus == false)
                {
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
        private bool CheckValidityForCheque()
        {
            bool bStatus = true;
            if (!rdoCashAmount.Checked && frmMultipleCheque.dtRecodes.Rows.Count > 0)
            {
                bStatus = false;
                MessageBox.Show("Please fill Cheque details", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bStatus;
        }
        private bool CheckValidity_Dependancies(string sReceiptId)
        {
            bool bValue = true;
            try
            {
                #region check deposited chques
                foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(sReceiptId))
                {
                    if (detail != null && detail.ChequeRegister_ID != "default" && detail.IsDepositted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.ChequeNumber + "] Cheque deposite is already done for this Receipt", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }
                #endregion

                #region check cash deposits
                foreach (tbl_bpsCashDeposit_Detail detail in tbl_bpsCashDeposit_Detail.SelectAllByReceipt_ID(sReceiptId))
                {
                    if (detail != null)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.CashDeposit_ID + "] Cash deposite is already done for this Receipt", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }
                #endregion

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        public bool CheckValidity_DepositedReceipts(string sReceipt)
        {
            bool bStatus = true;
            try
            {
                tbl_bpsChequeRegister register = tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(sReceipt).Where(p => p.IsDeleted != true && p.AccountReceipt_ID != "default").FirstOrDefault();
                if (register != null)
                {
                    if (register.IsDepositted == true && (register.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.New) || register.ChequeStatus_ID != clsAutocode.getChequeStatusID(ChequeStatus.Default)))
                        bStatus = false;
                    else
                        bStatus = true;
                }

                if (bStatus == false)
                    MessageBox.Show("Cannot Delete this Receipt! " + sReceipt + " \n\n Contact Your Systems Administrator Or Helpdesk at Digiteq Solution (Pvt) Ltd", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_ChequeNo()
        {
            bool bIsValied = true;
            //if (!IsUpdate)
            //{
            int iCount = 0;
            string sAccNo = "", sChequeNo = "";

            try
            {
                if (decimal.Parse(txtChequeAmount.Text) > 0)
                {
                    string sAccNo_Or_Bank = "AccountNo";
                    if (!clsConfig.bRecipt_Validate_AccountNo)
                        sAccNo_Or_Bank = "BankID";

                    foreach (DataRow dRow in frm_accReceiptMultipleCheque.dtRecodes.Rows)
                    {
                        iCount = 0;
                        sChequeNo = dRow["ChequeNo"].ToString();
                        sAccNo = dRow[sAccNo_Or_Bank].ToString();

                        foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeNumber == sChequeNo))
                        {
                            if (IsUpdate)
                            {
                                if (txtAccountReceiptID.Text == oChequeReg.AccountReceipt_ID)
                                    continue;
                            }

                            if (clsConfig.bRecipt_Validate_AccountNo)
                            {
                                if (oChequeReg.AccountNumber == sAccNo)
                                    iCount++;
                            }
                            else
                            {
                                if (oChequeReg.Bank_ID == sAccNo)
                                    iCount++;
                            }
                        }

                        if (iCount > 0)
                        {
                            bIsValied = false;
                            MessageBox.Show("This Cheque No is already in the System.......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bIsValied = false;
                SEACCException.Show(ex);
            }
            //}
            return bIsValied;
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
                {
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
        #endregion

        #region Check Validity Grid
        private bool ValidateGrid()
        {
            bool bNoRows = true;

            try
            {
                string strMessage = "";

                if (dgvDetail.Rows.Count > 0)
                {
                    foreach (DataGridViewRow iRow in dgvDetail.Rows)
                    {
                        string Gl_Code = dgvDetail["GLCode", iRow.Index].Value.ToString();

                        //if (txtCrAccountCode.Text == Gl_Code)
                        //{
                        //    bNoRows = false;
                        //    strMessage = "Credit Account Code Alredy in List";
                        //    break;
                        //}
                    }
                }

                if (bNoRows == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bNoRows;
        }
        #endregion

        #region Validate Empty Foreing Key
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtAccountReceiptID);
            clsCommon.ValidateForeignKey(ref txtOtherCreditor);
            clsCommon.ValidateForeignKey(ref txtCustomerID);
            clsCommon.ValidateForeignKey(ref txtSupplierID);
            clsCommon.ValidateForeignKey(ref txtEmployeeID);
            clsCommon.ValidateForeignKey(ref txtRevenueCenter1);
            clsCommon.ValidateForeignKey(ref txtRevenueCenter2);
        }
        #endregion

        #region Calculate Credit Debit Amounts
        private void CalculateCreditDebitAmounts()
        {
            txtCreditAmount.Text = dGridAmount.ToString();
        }
        #endregion

        #region Calculate Paymet Mode Amount
        private decimal GetARAmount()
        {
            decimal value = 0;
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                value = decimal.Parse(txtChequeAmount.Text.Trim());
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                //value = Convert.ToString(decimal.Parse(txtChequeAmount.Text.Trim()) + decimal.Parse(txtCashAmount.Text.Trim()));
                value = decimal.Parse(txtCashAmount.Text.Trim());
            }
            return value;
        }
        #endregion

        #region Check Grid View Amount
        private void CheckGridViewAmount()
        {
            try
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
                {
                    dGridAmount = decimal.Parse(clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtDebitAmount.Text.Trim())));
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region  Event Click
        private void pbxCustomer_Click(object sender, EventArgs e)
        {

            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtOther_Cr, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Other_Cr, iFormID, "", 1);
                if (glb_dtOther_Cr != null && glb_dtOther_Cr.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }
            //else if (txtCashAmount.Text.Length > 0)
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtOther_Cr, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Other_Cr, iFormID, "", 1);
                if (glb_dtOther_Cr != null && glb_dtOther_Cr.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }


        }

        private void pbxSupplier_Click(object sender, EventArgs e)
        {

            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSupplier, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Customer, iFormID, "", 1);
                if (glb_dtSupplier != null && glb_dtSupplier.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSupplier, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Customer, iFormID, "", 1);
                if (glb_dtSupplier != null && glb_dtSupplier.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }

        }

        private void pbxSup_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSup, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Supplier, iFormID, "", 1);
                if (glb_dtSup != null && glb_dtSup.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(ref glb_dtSup, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Supplier, iFormID, "", 1);
                if (glb_dtSup != null && glb_dtSup.Rows.Count > 0)
                {
                    RefreshGrid();
                }
            }
        }

        private void pbxEmployee_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtEmployeeID_GLCode, txtChequeAmount);
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtEmployeeID_GLCode, txtCashAmount);
            }
        }

        private void pbxCostCenter1_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtCostCenter1_GLCode, txtChequeAmount);
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtCostCenter1_GLCode, txtCashAmount);
            }
        }

        private void pbxCostCenter2_Click(object sender, EventArgs e)
        {
            if (clsCommon.isCurrency(txtChequeAmount.Text.Trim()) && decimal.Parse(txtChequeAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtCostCenter2_GLCode, txtChequeAmount);
            }
            else if (clsCommon.isCurrency(txtCashAmount.Text.Trim()) && decimal.Parse(txtCashAmount.Text.ToString()) > 0)
            {
                clsEvent.PictureBox_Click(txtCostCenter2_GLCode, txtCashAmount);
            }
        }

        private void pbxCashAmount_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtCash, decimal.Parse(txtCashAmount.Text.Trim()), TransactionCategory.Cash, iFormID, "", 1);
            if (glb_dtCash != null && glb_dtCash.Rows.Count > 0)
            {
                RefreshGrid();
            }
        }

        private void pbxChequeAmount_Click(object sender, EventArgs e)
        {
            clsEvent.PictureBox_Click(ref glb_dtCheque, decimal.Parse(txtChequeAmount.Text.Trim()), TransactionCategory.Cheque, iFormID, "", 1);
            if (glb_dtCheque != null && glb_dtCheque.Rows.Count > 0)
            {
                RefreshGrid();
            }
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
                glb_dtCash.Columns.Add("Remarks", typeof(string));//Remarks - Added by Gayan 2017-01-21
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
                glb_dtCheque.Columns.Add("Remarks", typeof(string));//Remarks - Added by Gayan 2017-01-21
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
                glb_dtOther_Cr.Columns.Add("Remarks", typeof(string));//Remarks - Added by Gayan 2017-01-21
            }
            if (TransactionCategory.Customer == eTCategory)
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
                glb_dtSupplier.Columns.Add("Remarks", typeof(string));//Remarks - Added by Gayan 2017-01-21
            }
            if (TransactionCategory.Supplier == eTCategory)
            {
                glb_dtSup = new DataTable();
                glb_dtSup.Columns.Add("Line_No", typeof(int));
                glb_dtSup.Columns.Add("GLCode", typeof(string));
                glb_dtSup.Columns.Add("GLName", typeof(string));
                glb_dtSup.Columns.Add("GLAmount", typeof(decimal));
                glb_dtSup.Columns.Add("SubAcct1", typeof(string));
                glb_dtSup.Columns.Add("SubAcct2", typeof(string));
                glb_dtSup.Columns.Add("Employee", typeof(string));
                glb_dtSup.Columns.Add("OtherCr", typeof(string));
                glb_dtSup.Columns.Add("CategoryID", typeof(int));
                glb_dtSup.Columns.Add("SubAcct1_ID", typeof(string));
                glb_dtSup.Columns.Add("SubAcct2_ID", typeof(string));
                glb_dtSup.Columns.Add("Employee_ID", typeof(string));
                glb_dtSup.Columns.Add("Remarks", typeof(string));//Remarks - Added by Gayan 2017-01-21
            }
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            #region Old Method
          
            #endregion

            #region New Method
            try
            {

                if (txtAccountReceiptID.Text.Trim().Length > 0 && txtAccountReceiptID.Text.Trim() != "<Auto Generate>")
                {
                    glb_dts_accReciept.Clear();
                    Cursor = Cursors.WaitCursor;
                    bool bApprovalDone = true, bCheckingDone = true, bOkToPrint = false, bIsCheque = false;
                    string sRecivedFrom = "", sNarration = "", sRemark = "", sArNo = "", sBank = "", sChequeNo = "", sDuplicate = "";
                    DateTime dtmChequDate = new DateTime();
                    DateTime dtmArDate = new DateTime();
                    decimal dAmount = 0, dTotalAmount = 0; // dTotChequ = 0 , dTotCash = 0 , dGrandTotal=0 
                    bool bPermissinOkToPrint = true;

                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_ReceiptVoucher));
                    if (bPermissinOkToPrint)
                    {
                        #region Check Approved
                        tbl_accAccountReceipt PV = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
                        if (PV != null)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintCreditNote)
                                {
                                    bApprovalDone = true;
                                }
                                else
                                    bApprovalDone = true;
                                #endregion
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintCreditNote)
                                {
                                    bCheckingDone = true;
                                }
                                else
                                    bCheckingDone = true;
                                #endregion
                            }
                        }
                        #endregion

                        #region Header Section
                        tbl_accAccountReceipt oAccountReceipt = tbl_accAccountReceipt.Select(txtAccountReceiptID.Tag.ToString().Trim());
                        if (oAccountReceipt != null && oAccountReceipt.AccountReceipt_ID != "default")
                        {
                            sRecivedFrom = oAccountReceipt.Receivedof;
                            sArNo = oAccountReceipt.AccountReceipt_ID.Trim();
                            sNarration = oAccountReceipt.Narration;
                            sRemark = oAccountReceipt.Remark;
                            dtmArDate = oAccountReceipt.AccountReceiptDate;
                            dTotalAmount = oAccountReceipt.TotalAmount;

                            tbl_bpsChequeRegister oChequeRegister = tbl_bpsChequeRegister.Select(oAccountReceipt.ChequeRegister_ID);
                            if (oChequeRegister != null && oChequeRegister.ChequeRegister_ID != "default")
                            {
                                sBank = clsGenaralName.getName_Bank(oChequeRegister.Bank_ID);
                                dtmChequDate = oChequeRegister.DateCheque;
                                dAmount = oChequeRegister.Amount;
                                sChequeNo = oChequeRegister.ChequeNumber;
                            }

                            glb_dts_accReciept.dt_AccountRecieptVoucher.Adddt_AccountRecieptVoucherRow(sArNo, sNarration, sRemark, sRecivedFrom, dtmArDate, sBank, sChequeNo, dtmChequDate, dAmount, dTotalAmount, 0, 0, oAccountReceipt.IsDeleted);

                            #region Fill Detail Section
                            if (oAccountReceipt.AccountReceipt_ID != oChequeRegister.AccountReceipt_ID)
                                bIsCheque = false;
                            else
                                bIsCheque = true;

                            foreach (tbl_accAccountReceipt_Details oDetail in tbl_accAccountReceipt_Details.SelectAllByAccountReceipt_ID(oAccountReceipt.AccountReceipt_ID))
                            {
                                string sEmpName = "";     //clsGenaralName.getName_Employee(oDetail.Employee_ID);
                                string sGlName = clsGenaralName.getName_AccountName(oDetail.Gl_ID);
                                string sCostCenter1 = "";     //clsGenaralName.getName_CostCenter(oDetail.CostCenter1_ID);
                                string sCostCenter2 = "";     // clsGenaralName.getName_CostCenter2(oDetail.CostCenter2_ID);
                                string sGlID = oDetail.Gl_ID;
                                glb_dts_accReciept.dt_AccountRecieptVoucher_Detail.Adddt_AccountRecieptVoucher_DetailRow(oDetail.AccountReceipt_ID, sGlID, sGlName, sEmpName, sCostCenter1, sCostCenter2, oDetail.Amount, oDetail.IsCredit, "", bIsCheque);
                            }
                            #endregion
                        }
                        #endregion

                        #region Set footer Detail
                        if (bApprovalDone && bCheckingDone)
                        {
                            bOkToPrint = true;

                            sCreateUserID = "[ " + PV.CreateUser_ID + " ] [ " + PV.DateCreate.ToShortDateString() + " ]";
                            sCreateUser = "[ " + clsGenaralName.getName_User(PV.CreateUser_ID) + " ] [ " + PV.DateCreate.ToShortDateString() + " ]";
                            if (PV.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(PV.CheckedUser_ID) + " ] [ " + PV.DateChecked.ToShortDateString() + " ]";
                            if (PV.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(PV.ApprovedUser_ID) + " ] [ " + PV.DateApproved.ToShortDateString() + " ]";
                        }
                        #endregion

                        if (bOkToPrint && bApprovalDone)
                        {
                            if (!bIsDraft)
                            {
                                #region Check Duplicate or New
                                //if (PV.PrintCount > 0)
                                //    sDuplicate = "Duplicate Copy " + PV.PrintCount;

                                if (!chkPrintOriginal.Checked)
                                    sDuplicate = (PV.PrintCount > 0) ? "Duplicate Copy " + PV.PrintCount : "";

                                PV.PrintCount++;
                                PV.Update();
                                #endregion
                            }

                            string s_Path = "";
                            string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_ReceiptVoucher));//NP_ReceiptVoucher
                            if (sGetRptPath != null && sGetRptPath.Length > 0)
                                s_Path = sGetRptPath;
                            else
                                s_Path = "\\Reports\\ACC\\NotePrinting\\rpt_accAccountReceipt.rpt";

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", "ACCOUNT RECEIPT", true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserID", sCreateUserID, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsSecurity.DigiteqEmail, true);

                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true);
                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

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
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                }
                            }
                            glb_dts_accReciept.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "", "", "", clsSecurity.UserNameLoged, "");
                            #endregion

                            //print(s_Path, "", "ACCOUNT RECEIPT", glb_dts_accReciept, bIsDuplicate);
                            frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                            ReportViewer.print(s_Path, glb_dts_accReciept, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_ReceiptVoucher));
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
                glb_dts_accReciept.Clear();
                Cursor = Cursors.Default;
            }
            #endregion
        }     
        #endregion

        #region Button Delete
        private void frm_accAccountReceipt_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAccountReceiptID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpVoucherDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        if (CheckValidity_Dependancies(detail.AccountReceipt_ID))
                                        {
                                            if (CheckValidity_DepositedReceipts(txtAccountReceiptID.Text.Trim()))
                                            {
                                                //   if (clsValidate.CheckAccountPostingValidity(detail.AccountReceipt_ID))
                                                // {
                                                //delete one record
                                                Cursor = Cursors.WaitCursor;
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Account Receipt : " + txtAccountReceiptID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    #region Update Other Tables

                                                    #region GL Posting Detail Temp Delete
                                                    //List<tbl_accAccountReceipt_Details> ARdetails = tbl_accAccountReceipt_Details.SelectAllByAccountReceipt_ID(txtAccountReceiptID.Text.ToString());
                                                    //foreach (tbl_accAccountReceipt_Details ARdetail in ARdetails)
                                                    //{
                                                    // //   clsMethods_Fin.GLPostingDetailTempDelete(ARdetail.Line_No, detail.GlPosting_ID);
                                                    //}
                                                    #endregion
                                                    clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);

                                                    #region tbl bps ChequeRegister Delete
                                                    List<tbl_bpsChequeRegister> oCheques = tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(txtAccountReceiptID.Text.Trim());
                                                    foreach (tbl_bpsChequeRegister oCheque in oCheques)
                                                    {
                                                        if (!oCheque.IsLocked)
                                                        {
                                                            //Remove Invoice Settlement
                                                            clsHelpMethods_Local.RemoveSattlementsFrom_ChequeID(oCheque.ChequeRegister_ID);

                                                            oCheque.IsDeleted = true;
                                                            oCheque.DateModified = clsSecurity.getServerDateTime();
                                                            oCheque.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                            oCheque.Update();
                                                        }
                                                    }
                                                    #endregion

                                                    #endregion

                                                    detail.IsDeleted = true;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFileds();
                                                }
                                                // }
                                            }
                                        }
                                        //else
                                        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        #region Cash and Cheque Amount
        private void rdoCashAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCashAmount.Checked)
            {
                rdoCashAmount.Enabled = true;
                txtCashAmount.Enabled = true;
                txtCash_GLCode.Enabled = true;
                //pbxCashAmount.Enabled = true;

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
                //pbxChequeAmount.Enabled = false;
                llblChequeDetail.Enabled = true;

                rdoCashAmount.Checked = false;
                txtCashAmount.Enabled = false;
                txtCash_GLCode.Enabled = false;
                txtCashAmount.Text = "0.00";
                txtCash_GLCode.Clear();
                txtCash_GLCode.Text = "";
            }
        }
        #endregion

        #region Print
        private void print(string sPath, string sFillter, string sReportTitle, DataSet dts, bool isDuplicate)
        {
            try
            {
                string s_Path = "";
                ReportDocument RD = new ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += sPath;
                RD.Load(s_Path);
                RD.SetDataSource(dts);


                //  RD.Refresh();          
                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                RD.DataDefinition.FormulaFields["CreateUserID"].Text = clsCommon.fncsetstring(sCreateUserID);
                RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                if (isDuplicate)
                    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");


                frm_ReportViewer viewer = new frm_ReportViewer();
                viewer.crystalReportViewer1.ShowExportButton = false;
                viewer.crystalReportViewer1.ReportSource = RD;
                viewer.crystalReportViewer1.Visible = true;
                viewer.crystalReportViewer1.DisplayToolbar = true;
                viewer.crystalReportViewer1.CloseView(false);
                viewer.WindowState = FormWindowState.Maximized;

                viewer.ShowDialog();

                //viewer.MdiParent = this.MdiParent;
                //viewer.Show();

                RD.Close();
                RD.Dispose();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void frm_accAccountReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (txtAccountReceiptID.Text != null && txtAccountReceiptID.TextLength > 0 && txtAccountReceiptID.Text != "<Auto Generate>")
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

                                        tbl_accAccountReceipt objDO = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
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
                if (txtAccountReceiptID.Text != null && txtAccountReceiptID.TextLength > 0 && txtAccountReceiptID.Text != "<Auto Generate>")
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

                                        tbl_accAccountReceipt objDO = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text.Trim());
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
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (txtAccountReceiptID.Text != "" || txtAccountReceiptID.Text != "<Auto Generate>")
                {
                    tbl_accAccountReceipt detail = tbl_accAccountReceipt.Select(txtAccountReceiptID.Text);
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

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (xSetting.Visible == true)
                xSetting.Visible = false;
            else
            {
                xSetting.Visible = true;
                xSetting.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion
    }
}

#region Changes
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

//        tbl_accPaymentVoucher_SubTotal detail = tbl_accPaymentVoucher_SubTotal.Select(iRowNo, txtAccountReceiptID.Text.Trim(), sCategoryID, sGLCode);

//        #region update tbl_accPaymentVoucher_SubTotal
//        if (detail != null)
//        {
//            tbl_accPaymentVoucher_SubTotal Insdetail = new tbl_accPaymentVoucher_SubTotal(iRowNo, txtAccountReceiptID.Text.Trim(), sCategoryID,
//                sGLCode, sOtherCr, txtCustomerID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dGLAmount, bIsCredit);
//            Insdetail.Update();
//        }
//        #endregion

//        #region Insert tbl_accPaymentVoucher_SubTotal
//        else
//        {
//            tbl_accPaymentVoucher_SubTotal Insdetail = new tbl_accPaymentVoucher_SubTotal(iRowNo, txtAccountReceiptID.Text.Trim(), sCategoryID,
//                sGLCode, sOtherCr, txtCustomerID.Tag.ToString(), sEmployee_ID, "default", sSubAcct1_ID, sSubAcct2_ID, dGLAmount, bIsCredit);
//            Insdetail.Insert();
//        }
//        #endregion

//        //#region GL Posting Detail
//        //clsProcessMethods.GLPostingDetailTemp(iRowNo, sPostingID, clsAutocode.getAccSlotID(AccSlot.PaymetVoucher), txtAccountReceiptID.Text.Trim(), sGLCode,
//        //                sSubAcct1_ID, sSubAcct2_ID, "default", txtCustomerID.Tag.ToString(), sEmployee_ID, "default", "-", txtAccountReceiptID.Text.Trim(), "default",
//        //                dtpVoucherDate.Value, txtNarration.Text.Trim(), dGLAmount, bIsCredit, sChequeNo);
//        //#endregion
//    }
//} 
#endregion