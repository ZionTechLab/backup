using DataTire;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SAS;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZION.ERP.Reports.DataSets.SAS;
using SEACC.DATA.Data.MAS;

namespace Digiteq
{
    public partial class UC_bpsReceiptSales : SEACC_Form
    {
        bool IsSelectedCardGridRow = false;
        bool IsSelectedBankTransferGridRow = false;
        bool IsSelectedChequeGridRow = false;
        bool IsSalesReceipt = false;

        public string glbReceiptID = "", glbInvoiceID = "";

        string sFormConfigCardRegisterCode = clsAutocode.getFormConfigCode(FormName.CardRegister);
        string sFormConfigBankTransferRegisterCode = clsAutocode.getFormConfigCode(FormName.BankTransferRegister);
        string sFormConfigChequeRegisterCode = clsAutocode.getFormConfigCode(FormName.ChequeRegister);
        string sFormConfigCashRegisterCode = clsAutocode.getFormConfigCode(FormName.CashRegister);

        int iNewRow = 0;

        //DataTables
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_sasReceiptAllocation glb_dts_sasReceiptAllocation = new dts_sasReceiptAllocation();
        clsAlerts_Email email = new clsAlerts_Email();
        BookNoData oData = new BookNoData();
        #region Form Load
        public UC_bpsReceiptSales()
        {
            InitializeComponent();
        }
        public UC_bpsReceiptSales(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void UC_bpsReceiptSales_Load(object sender, EventArgs e)
        {   
            if (enmForm == FormName.UCReceipt)
                IsSalesReceipt = true;

            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            ClearFields();
            CusDataGridViewFormat();
            CusExpanderFormat();

            if (glbInvoiceID.Length > 0)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(glbInvoiceID);
                if (detail != null)
                {
                    txtCustomerID.Tag = detail.Customer_ID;
                    txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));

                    txtInvoiceID.Tag = detail.Invoice_ID;
                    FillInvoiceDetails(txtInvoiceID.Tag.ToString());
                }
            }
            else if (glbReceiptID.Length > 0)
                FillDetails(glbReceiptID);
        }
        #endregion

        #region Action Buttons
        #region Button New
        private void UC_bpsReceiptSales_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Button Save
        private void UC_bpsReceiptSales_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {

                try
                {
                    Cursor = Cursors.WaitCursor;

                    List<string> sInvoiceList = new List<string>();
                    foreach (DataGridViewRow DRow in dgvInvoice.Rows)
                    {
                        string sInvoiceID = dgvInvoice["InvoiceID", DRow.Index].Value.ToString();
                        if (sInvoiceID.Length > 0 && sInvoiceID != "default")
                            sInvoiceList.Add(sInvoiceID);
                    }

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_bpsReceipt oldRecord = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                        if (oldRecord != null && CheckValidity_Printing(oldRecord.PrintCount))
                        {
                            if (CheckValidity_Dependancies(oldRecord.Receipt_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsChecked && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtReceiptID.Text))
                                    {
                                        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oldRecord.Receipt_ID))
                                        {
                                            clsMethods_GL.GLPosting_Delete(oCheque.GlPosting_ID);
                                        }

                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.Receipt), oldRecord.Receipt_ID, "Receipt");
                                        clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID(txtReceiptID.Text.Trim());

                                        #region update Order Ref No

                                        tbl_zOrderRefNo orf = new tbl_zOrderRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text.Trim(),
                                            clsGenaralName.getName_RouteIDByCustomerID(txtCustomerID.Tag.ToString()), clsGenaralName.getName_TownIDByCustomerID(txtCustomerID.Tag.ToString()),
                                            txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                                        orf.Update();
                                        #endregion

                                        #region Update Receipt
                                        tbl_bpsReceipt detail = new tbl_bpsReceipt(txtReceiptID.Text.Trim(), dtpReceiptDate.Value, txtRemark.Text.Trim(), txtTmpReceiptNo.Text, txtCustomerID.Tag.ToString(), txtInvoiceID.Tag.ToString(), "default", "default", "default",
                                            txtOrderRefNo.Tag.ToString(), oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID, oldRecord.PostingStatus_ID2, oldRecord.FinancialYear_ID, txtSalesNoteType.Tag != null ? txtSalesNoteType.Tag.ToString() : "default", txtCollector1.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                                            decimal.Parse(txtCurrencyRate.Text.Trim()), 0, 0, 0, clsHelpMethods_Local.getSavePrice(decimal.Parse(lblTotalAmount.Text.Trim()), txtCurrencyRate), txtAmountInWord.Text.Trim(),
                                            oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.PrintedUser_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DatePrinted,
                                            oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.PrintCount, oldRecord.IsAdvance, oldRecord.IsOverPayment, oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.IsSalesReceipt,
                                            clsHelpMethods_Local.getOldedInvoiceDate(sInvoiceList), clsHelpMethods_Local.getInvoiceList(sInvoiceList), oldRecord.IsCashDeposited, oldRecord.DateDeposited, oldRecord.CompanyID, oldRecord.CompanyBranch_ID,txtCollector2.Tag.ToString(),txtCollector3.Tag.ToString(), txtCollector4.Tag.ToString(),txtPageNo.Text);
                                        detail.Update();
                                        #endregion

                                        #region Update Invoices

                                        tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oldRecord.Receipt_ID);

                                        int ilineNo = 0;
                                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                                        {
                                            string sInvoiceID = "", sOrderRefNo = "";
                                            sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                                            sOrderRefNo = clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo", row.Index, "default");
                                            ilineNo = row.Index + 1;

                                            tbl_bpsReceipt_Invoice ReceiptInvoicedetail = new tbl_bpsReceipt_Invoice(ilineNo, txtReceiptID.Text, sInvoiceID, false, sOrderRefNo);
                                            ReceiptInvoicedetail.Insert();
                                        }
                                        #endregion

                                        #region Update n Insert Cheque Register

                                        Insert_Cash();
                                        Update_Cheque();
                                        Update_Card();
                                        Update_BankTransfer();

                                        #endregion

                                        clsMethods_GL.PostTransaction_SalesReciept(txtReceiptID.Text);
                                        setPaymentAllocation(txtReceiptID.Text.Trim(), true);
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                                    }
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        #region Generate Serial Number
                        if (IsSalesReceipt)
                        {
                            clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCode, txtSalesNoteType.Tag.ToString(), ref txtReceiptID);
                        }
                        else
                        {
                            if (clsConfig.bUseSeperateSerialNoInterimReceipt)
                            {
                                string sCode = clsAutocode.getFormConfigCode(FormName.InterimReceipt);
                                if (clsAutocode.IsAutoGenerated(sCode))
                                    txtReceiptID.Text = clsAutocode.getAutoGeneratedCode(sCode);
                            }
                            else if (clsConfig.bUseSeperateSerialNo_AdvancedAndPartpaymentReceipt)
                            {
                                string sCode = clsAutocode.getFormConfigCode(FormName.InterimReceipt);
                                if (clsAutocode.IsAutoGenerated(sCode))
                                    txtReceiptID.Text = clsAutocode.getAutoGeneratedCode(sCode);
                            }
                            else
                            {
                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    txtReceiptID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                            }
                        }
                        #endregion

                        #region Create order ref number
                        #region Auto Generated Order Ref No
                        txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                        #endregion

                        #region Insert Order Ref No
                        tbl_zOrderRefNo orf = new tbl_zOrderRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text.Trim(), clsGenaralName.getName_RouteIDByCustomerID(txtCustomerID.Tag.ToString()),
                                                        clsGenaralName.getName_TownIDByCustomerID(txtCustomerID.Tag.ToString()), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                        orf.Insert();
                        #endregion
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtReceiptID.Text))
                        {
                            #region Insert Receipt Header
                            tbl_bpsReceipt detail = new tbl_bpsReceipt(txtReceiptID.Text.Trim(), dtpReceiptDate.Value, txtRemark.Text.Trim(), txtTmpReceiptNo.Text.Trim(), txtCustomerID.Tag.ToString(), txtInvoiceID.Tag.ToString(), "default", "default", "default", txtOrderRefNo.Tag.ToString(),
                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted), clsSecurity.FinancialYearID, txtSalesNoteType.Tag != null ? txtSalesNoteType.Tag.ToString() : "default",
                                txtCollector1.Tag.ToString(), txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), 0, 0, 0, clsHelpMethods_Local.getSavePrice(decimal.Parse(lblTotalAmount.Text.Trim()), txtCurrencyRate), txtAmountInWord.Text.Trim(),
                                clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", "default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                false, false, false, false, false, 0, rdoAdvancePayment.Checked, false, 0, false, IsSalesReceipt, clsHelpMethods_Local.getOldedInvoiceDate(sInvoiceList), clsHelpMethods_Local.getInvoiceList(sInvoiceList), false, clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, txtCollector2.Tag.ToString(), txtCollector3.Tag.ToString(), txtCollector4.Tag.ToString(), txtPageNo.Text);
                            detail.Insert();
                            #endregion

                            #region Insert Invoice
                            int ilineNo = 0;
                            foreach (DataGridViewRow row in dgvInvoice.Rows)
                            {
                                string sInvoiceID = "", sOrderRefNo = "";
                                sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                                sOrderRefNo = clsValidate.ValidateGridValue(dgvInvoice, "OrderRefNo", row.Index, "default");

                                ilineNo = row.Index + 1;
                                tbl_bpsReceipt_Invoice oReceiptInvoice = new tbl_bpsReceipt_Invoice(ilineNo, txtReceiptID.Text, sInvoiceID, false, sOrderRefNo);
                                oReceiptInvoice.Insert();
                            }
                            if (dgvInvoice.Rows.Count <= 0)
                            {
                                tbl_bpsReceipt_Invoice ReceiptInvoicedetail = new tbl_bpsReceipt_Invoice(ilineNo, txtReceiptID.Text, "default", false, "default");
                                ReceiptInvoicedetail.Insert();
                            }
                            #endregion

                            #region Insert Cheque Register
                            if (txtCashAmount.Text.Trim() != "" && decimal.Parse(txtCashAmount.Text) > 0m)
                                Insert_Cash();
                            if (dgvCheq.Rows.Count > 0)
                                Insert_Cheques();
                            if (dgvCard.Rows.Count > 0)
                                Insert_Cards();
                            if (dgvBankTransfer.Rows.Count > 0)
                                Insert_BankTransfer();
                            #endregion

                            Attachments.Insert(txtReceiptID.Text);
                            clsMethods_GL.PostTransaction_SalesReciept(txtReceiptID.Text);
                            setPaymentAllocation(txtReceiptID.Text.Trim(), true);
                            email.createEmail_Receipt(txtReceiptID.Text.Trim(), enum_Alerts.ReceiptCreated);

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                    if (detail != null)
                        FillDetails(detail.Receipt_ID);
                }
            }
        }

        #region Payment Method Update/Insert
        private void Update_Cheque()
        {
            try
            {
                #region Update Cheques which are in DB
                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(txtReceiptID.Text.Trim()).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cheque))
                {
                    if (oCheque != null)
                    {
                        string sAccountNo = "", sBankID = "", sBranchID = "", sChequeTypeID = "", sChequeNo = "", sGridChequeStatus = "", sRemark = "", sChequeRegisterCode = "";
                        decimal dAmount = 0;
                        int iCompanyAccount_ID = -1;
                        bool bHasChequeInGrid = false;
                        DateTime dChequeDate = clsSecurity.getServerDateTime();

                        foreach (DataGridViewRow row in dgvCheq.Rows)
                        {
                            sChequeRegisterCode = clsValidate.ValidateGridValue(dgvCheq, "ChequeRegisterCode", row.Index, "");
                            if (oCheque.ChequeRegister_ID == sChequeRegisterCode)
                            {
                                bHasChequeInGrid = true;

                                sAccountNo = clsValidate.ValidateGridValue(dgvCheq, "AccountNo", row.Index, "");
                                sBankID = clsValidate.ValidateGridValue(dgvCheq, "BankID", row.Index, "default");
                                sBranchID = clsValidate.ValidateGridValue(dgvCheq, "BranchID", row.Index, "default");
                                sChequeTypeID = clsValidate.ValidateGridValue(dgvCheq, "ChequeTypeID", row.Index, "default");
                                sChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "");
                                dAmount = clsValidate.ValidateGridValue(dgvCheq, "Amount", row.Index, decimal.Parse("0.00"));
                                sGridChequeStatus = clsValidate.ValidateGridTag(dgvCheq, "GridChequeStatus", row.Index, "default");
                                dChequeDate = DateTime.Parse(dgvCheq["ChequeDate", row.Index].Value.ToString());
                                sRemark = clsValidate.ValidateGridValue(dgvCheq, "Remark", row.Index, "");

                                iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);

                                dgvCheq.Rows.RemoveAt(row.Index);
                                break;
                            }
                        }

                        if (bHasChequeInGrid)
                        {
                            tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sChequeRegisterCode, sRemark, dtpReceiptDate.Value, oCheque.PaymentMethod_ID, oCheque.TransferType, oCheque.TransferRefNo, oCheque.GiftVoucherID, oCheque.Merchant_DeviceID,
                                oCheque.LastFourDigits, oCheque.CardOwnerName, oCheque.CardType, oCheque.CardCategory, dChequeDate, txtCustomerID.Tag.ToString(),
                                sAccountNo, oCheque.DepositedAccountNumber, iCompanyAccount_ID, sBankID, oCheque.DepositedBank_ID, sBranchID, oCheque.DepositedBranch_ID, sGridChequeStatus, sChequeTypeID,
                                oCheque.Invoice_ID, oCheque.PosTransaction_ID, txtReceiptID.Text, oCheque.PosReceipt_ID, "default", txtOrderRefNo.Tag.ToString(), sChequeNo,
                                oCheque.GlPosting_ID, oCheque.PostingStatus_ID, oCheque.PostingStatus_ID2, oCheque.FinancialYear_ID, dAmount,
                                oCheque.IsSetteled, oCheque.IsSetteledReturned, oCheque.IsDepositted, oCheque.IsReIssued, oCheque.IsReconcilied, oCheque.IsReturned, oCheque.IsReturnedToSender, oCheque.CreateUser_ID, clsSecurity.UserIDLoged, oCheque.DateCreate, clsSecurity.getServerDateTime(),
                                oCheque.IsDeleted, oCheque.IsLocked, oCheque.DepositCount, oCheque.PaneltyAmount, oCheque.SetteledAmount, oCheque.DepositedCashAmount,
                                oCheque.DateDeposited, oCheque.DateReconcilied, oCheque.DateReIssued, oCheque.DateReturnedToSender, oCheque.CompanyID, oCheque.CompanyBranch_ID, oCheque.PosReturnTransaction_Index, oCheque.AdvanceReceived_Index, oCheque.RecSerialNo);
                            RegisterDetails.Update();
                        }
                        else
                            oCheque.Delete();
                    }
                }
                #endregion

                #region Insert Newly Added Cheques
                foreach (DataGridViewRow row in dgvCheq.Rows)
                {
                    string sAccountNo = "", sBankID = "", sBranchID = "", sChequeTypeID = "", sChequeNo = "", sGridChequeStatus = "", sRemark = "", sChequeRegisterCode = "";
                    decimal dAmount = 0;
                    int iCompanyAccount_ID = -1;
                    DateTime dChequeDate;

                    sAccountNo = clsValidate.ValidateGridValue(dgvCheq, "AccountNo", row.Index, "");
                    sBankID = clsValidate.ValidateGridValue(dgvCheq, "BankID", row.Index, "default");
                    sBranchID = clsValidate.ValidateGridValue(dgvCheq, "BranchID", row.Index, "default");
                    sChequeTypeID = clsValidate.ValidateGridValue(dgvCheq, "ChequeTypeID", row.Index, "default");
                    sChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "");
                    dAmount = clsValidate.ValidateGridValue(dgvCheq, "Amount", row.Index, decimal.Parse("0.00"));
                    sGridChequeStatus = clsValidate.ValidateGridTag(dgvCheq, "GridChequeStatus", row.Index, "default");
                    dChequeDate = DateTime.Parse(dgvCheq["ChequeDate", row.Index].Value.ToString());
                    sRemark = clsValidate.ValidateGridValue(dgvCheq, "Remark", row.Index, "");
                    sChequeRegisterCode = clsValidate.ValidateGridValue(dgvCheq, "ChequeRegisterCode", row.Index, "default");
                    iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);

                    {
                        sChequeRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigChequeRegisterCode);

                        tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sChequeRegisterCode, sRemark, dtpReceiptDate.Value, (int)PaymentMethod.Cheque, (-1), "", (-1), (-1), "", "", (-1), (-1),
                            dChequeDate, txtCustomerID.Tag.ToString(), sAccountNo, "", iCompanyAccount_ID, sBankID, "default", sBranchID, "default", sGridChequeStatus, sChequeTypeID, "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(),
                            sChequeNo, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                            dAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                            false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                        RegisterDetails.Insert();
                    }

                    #region insert And Update Customer Account
                    {
                        tbl_genCustomerAccount acc = tbl_genCustomerAccount.Select(txtCustomerID.Tag.ToString(), sAccountNo);
                        if (acc == null)
                        {
                            tbl_genCustomerAccount account = new tbl_genCustomerAccount(txtCustomerID.Tag.ToString(), sAccountNo,                                 sBankID, sBranchID, 0, 0, 0);
                            account.Insert();
                        }
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Update_BankTransfer()
        {
            try
            {
                #region Update old details
                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(txtReceiptID.Text.Trim()).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Bank_Transfer))
                {
                    if (oCheque != null)
                    {
                        string sAccountNo = "", sBankID = "", sBranchID = "", sTRefNo = "", sRegisterCode = "";
                        decimal dAmount = 0;
                        int sTTypeID = 0, iCompanyAccount_ID = -1;
                        bool bHasChequeInGrid = false;
                        DateTime dChequeDate = clsSecurity.getServerDateTime();

                        foreach (DataGridViewRow row in dgvBankTransfer.Rows)
                        {
                            sRegisterCode = clsValidate.ValidateGridValue(dgvBankTransfer, "BTChequeRegisterCode", row.Index, "");
                            if (oCheque.ChequeRegister_ID == sRegisterCode)
                            {
                                bHasChequeInGrid = true;

                                sAccountNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAccountNo", row.Index, "");
                                sBankID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBankID", row.Index, "default");
                                sBranchID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBranchID", row.Index, "default");
                                sTTypeID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTTypeID", row.Index, -1);
                                sTRefNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTRefNo", row.Index, "");
                                dAmount = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAmount", row.Index, decimal.Parse("0.00"));
                                dChequeDate = DateTime.Parse(dgvBankTransfer["BTDate", row.Index].Value.ToString());
                                iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);
                                dgvBankTransfer.Rows.RemoveAt(row.Index);
                                break;
                            }
                        }

                        if (bHasChequeInGrid)
                        {
                            #region Update Rows
                            tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dChequeDate, oCheque.PaymentMethod_ID, sTTypeID, sTRefNo, oCheque.GiftVoucherID, oCheque.Merchant_DeviceID,
                                                            oCheque.LastFourDigits, oCheque.CardOwnerName, oCheque.CardType, oCheque.CardCategory, dChequeDate, txtCustomerID.Tag.ToString(), oCheque.AccountNumber, sAccountNo, iCompanyAccount_ID, sBankID, oCheque.DepositedBank_ID, sBranchID, oCheque.DepositedBranch_ID,
                                                            oCheque.ChequeStatus_ID, oCheque.ChequeType_ID, oCheque.Invoice_ID, oCheque.PosTransaction_ID, txtReceiptID.Text, oCheque.PosReceipt_ID, oCheque.AccountReceipt_ID, txtOrderRefNo.Tag.ToString(),
                                                            oCheque.ChequeNumber, oCheque.GlPosting_ID, oCheque.PostingStatus_ID, oCheque.PostingStatus_ID2, oCheque.FinancialYear_ID,                                                            dAmount, oCheque.IsSetteled, oCheque.IsSetteledReturned, oCheque.IsDepositted, oCheque.IsReIssued, oCheque.IsReconcilied, oCheque.IsReturned, oCheque.IsReturnedToSender,
                                                            oCheque.CreateUser_ID, clsSecurity.UserIDLoged, oCheque.DateCreate, clsSecurity.getServerDateTime(), oCheque.IsDeleted, oCheque.IsLocked, oCheque.DepositCount, oCheque.PaneltyAmount, oCheque.SetteledAmount, oCheque.DepositedCashAmount,
                                                            dChequeDate, dChequeDate, oCheque.DateReIssued, oCheque.DateReturnedToSender, oCheque.CompanyID, oCheque.CompanyBranch_ID, oCheque.PosReturnTransaction_Index, oCheque.AdvanceReceived_Index, oCheque.RecSerialNo);
                            RegisterDetails.Update();
                            #endregion
                        }
                        else
                            oCheque.Delete();
                    }
                }
                #endregion

                #region Insert grid - bank transfer details
                foreach (DataGridViewRow row in dgvBankTransfer.Rows)
                {
                    string sAccountNo = "", sBankID = "", sBranchID = "", sTRefNo = "", sRegisterCode = "";
                    decimal dAmount = 0;
                    int sTTypeID = 0, iCompanyAccount_ID = -1;
                    DateTime dChequeDate;

                    sAccountNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAccountNo", row.Index, "");
                    sBankID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBankID", row.Index, "default");
                    sBranchID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBranchID", row.Index, "default");
                    sTTypeID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTTypeID", row.Index, -1);
                    sTRefNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTRefNo", row.Index, "");
                    dAmount = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAmount", row.Index, decimal.Parse("0.00"));
                    dChequeDate = DateTime.Parse(dgvBankTransfer["BTDate", row.Index].Value.ToString());
                    iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);

                    #region Insert New Rows
                    sRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigBankTransferRegisterCode);

                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dChequeDate, (int)PaymentMethod.Bank_Transfer, sTTypeID, sTRefNo, (-1), (-1), "", "", (-1), (-1), dChequeDate, txtCustomerID.Tag.ToString(),
                        "", sAccountNo, iCompanyAccount_ID, sBankID, "default", sBranchID, "default",clsAutocode.getChequeStatusID(ChequeStatus.Deposited), "default",
                        "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(), "", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                        dAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, 0, 0, 0, 0,
                        dChequeDate, dChequeDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                    RegisterDetails.Insert();
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Update_Card()
        {
            try
            {
                #region Update old details
                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(txtReceiptID.Text.Trim()).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Card))
                {
                    if (oCheque != null)
                    {
                        string sName = "", sBankID = "", sLastFourDigits = "", sRegisterCode = "";
                        int sTypeID = 0;
                        decimal dAmount = 0;
                        DateTime dChequeDate = clsSecurity.getServerDateTime();
                        bool bHasChequeInGrid = false;

                        foreach (DataGridViewRow row in dgvCard.Rows)
                        {
                            sRegisterCode = clsValidate.ValidateGridValue(dgvCard, "crdChequeRegisterCode", row.Index, "");
                            if (oCheque.ChequeRegister_ID == sRegisterCode)
                            {
                                bHasChequeInGrid = true;

                                sName = clsValidate.ValidateGridValue(dgvCard, "crdName", row.Index, "");
                                sBankID = clsValidate.ValidateGridValue(dgvCard, "crdBankID", row.Index, "default");
                                sTypeID = clsValidate.ValidateGridValue(dgvCard, "crdTypeID", row.Index, -1);
                                dAmount = clsValidate.ValidateGridValue(dgvCard, "crdAmount", row.Index, decimal.Parse("0.00"));
                                sLastFourDigits = clsValidate.ValidateGridValue(dgvCard, "crdLastFourDigits", row.Index, "default");

                                dgvCard.Rows.RemoveAt(row.Index);
                                break;
                            }
                        }

                        if (bHasChequeInGrid)
                        {
                            tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dtpReceiptDate.Value, oCheque.PaymentMethod_ID,                                oCheque.TransferType, oCheque.TransferRefNo, oCheque.GiftVoucherID, oCheque.Merchant_DeviceID,
                                sLastFourDigits, sName, sTypeID, oCheque.CardCategory,                                dChequeDate, txtCustomerID.Tag.ToString(),                                oCheque.AccountNumber, oCheque.DepositedAccountNumber, -1, sBankID, oCheque.DepositedBank_ID, oCheque.Branch_ID, oCheque.DepositedBranch_ID,
                                oCheque.ChequeStatus_ID, oCheque.ChequeType_ID,                                oCheque.Invoice_ID, oCheque.PosTransaction_ID, txtReceiptID.Text, oCheque.PosReceipt_ID, oCheque.AccountReceipt_ID, txtOrderRefNo.Tag.ToString(),
                                oCheque.ChequeNumber,                                oCheque.GlPosting_ID, oCheque.PostingStatus_ID, oCheque.PostingStatus_ID2, oCheque.FinancialYear_ID,                                dAmount,                                oCheque.IsSetteled, oCheque.IsSetteledReturned, oCheque.IsDepositted, oCheque.IsReIssued, oCheque.IsReconcilied, oCheque.IsReturned, oCheque.IsReturnedToSender,
                                oCheque.CreateUser_ID, clsSecurity.UserIDLoged, oCheque.DateCreate, clsSecurity.getServerDateTime(),                                oCheque.IsDeleted, oCheque.IsLocked, oCheque.DepositCount, oCheque.PaneltyAmount, oCheque.SetteledAmount, oCheque.DepositedCashAmount,
                                oCheque.DateDeposited, oCheque.DateReconcilied, oCheque.DateReIssued, oCheque.DateReturnedToSender, oCheque.CompanyID, oCheque.CompanyBranch_ID, oCheque.PosReturnTransaction_Index, oCheque.AdvanceReceived_Index,oCheque.RecSerialNo);
                            RegisterDetails.Update();
                        }
                        else
                            oCheque.Delete();
                    }
                }
                #endregion

                #region Insert Grid - Card Details
                foreach (DataGridViewRow row in dgvCard.Rows)
                {
                    string sName = "", sBankID = "", sLastFourDigits = "", sRegisterCode = "";
                    int sTypeID = 0;
                    decimal dAmount = 0;
                    DateTime dChequeDate = clsSecurity.getServerDateTime();

                    sName = clsValidate.ValidateGridValue(dgvCard, "crdName", row.Index, "");
                    sBankID = clsValidate.ValidateGridValue(dgvCard, "crdBankID", row.Index, "default");
                    sTypeID = clsValidate.ValidateGridValue(dgvCard, "crdTypeID", row.Index, -1);
                    dAmount = clsValidate.ValidateGridValue(dgvCard, "crdAmount", row.Index, decimal.Parse("0.00"));
                    sLastFourDigits = clsValidate.ValidateGridValue(dgvCard, "crdLastFourDigits", row.Index, "default");

                    sRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigCardRegisterCode);

                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dtpReceiptDate.Value, (int)PaymentMethod.Card, (-1), "", (-1), (-1), sLastFourDigits, sName, sTypeID, (-1),
                        dChequeDate, txtCustomerID.Tag.ToString(), "", "", -1, sBankID, "default", "default", "default", clsAutocode.getChequeStatusID(ChequeStatus.New), "default", "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(),
                        "", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, dAmount, false, false, false, false, false, false, false,
                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                        false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                    RegisterDetails.Insert();

                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Insert_Cash()
        {
            try
            {
                string sChequeRegisterCode = "";
                if (txtCashChequeRegisterID.Text.Trim() != "")
                {
                    sChequeRegisterCode = txtCashChequeRegisterID.Text;
                    tbl_bpsChequeRegister.DeleteAllByChequeRegister_ID(sChequeRegisterCode);
                }
                else if (decimal.Parse(txtCashAmount.Text.Trim()) > 0)
                    sChequeRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigCashRegisterCode);

                if (decimal.Parse(txtCashAmount.Text.Trim()) > 0)
                {
                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sChequeRegisterCode, "", dtpReceiptDate.Value.Date, (int)PaymentMethod.Cash,
                    (-1), "", (-1), (-1), "", "", (-1), (-1), dtpReceiptDate.Value.Date, txtCustomerID.Tag.ToString(), "default", "", -1, "default", "default", "default", "default",
                    clsAutocode.getChequeStatusID(ChequeStatus.New), "default", "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(), "", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction),
                    clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, decimal.Parse(txtCashAmount.Text.Trim()),
                    false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                    false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1),(-1));
                    RegisterDetails.Insert();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Insert_Cheques()
        {
            try
            {
                #region insert Grid - Cheque Register Details
                foreach (DataGridViewRow row in dgvCheq.Rows)
                {
                    DateTime dChequeDate;

                    string sAccountNo = clsValidate.ValidateGridValue(dgvCheq, "AccountNo", row.Index, "");
                    string sBankID = clsValidate.ValidateGridValue(dgvCheq, "BankID", row.Index, "default");
                    string sBranchID = clsValidate.ValidateGridValue(dgvCheq, "BranchID", row.Index, "default");
                    string sChequeTypeID = clsValidate.ValidateGridValue(dgvCheq, "ChequeTypeID", row.Index, "default");
                    string sChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "");
                    decimal dAmount = clsValidate.ValidateGridValue(dgvCheq, "Amount", row.Index, decimal.Parse("0.00"));
                    string sGridChequeStatus = clsValidate.ValidateGridTag(dgvCheq, "GridChequeStatus", row.Index, "default");
                    dChequeDate = DateTime.Parse(dgvCheq["ChequeDate", row.Index].Value.ToString());
                    string sRemark = clsValidate.ValidateGridValue(dgvCheq, "Remark", row.Index, "");
                    int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);

                    string sRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigChequeRegisterCode);

                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, sRemark, dtpReceiptDate.Value, (int)PaymentMethod.Cheque,
                        (-1), "", (-1), (-1), "", "", (-1), (-1),
                        dChequeDate, txtCustomerID.Tag.ToString(),
                        sAccountNo, "", iCompanyAccount_ID, sBankID, "default", sBranchID, "default",
                        sGridChequeStatus, sChequeTypeID,
                        "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(),
                        sChequeNo,
                        "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                        dAmount,
                        false, false, false, false, false, false, false,
                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                        false, false, 0, 0, 0, 0,
                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1),(-1));
                    RegisterDetails.Insert();

                    #region insert And Update Customer Account
                    if (sAccountNo.Length > 0)
                    {
                        tbl_genCustomerAccount acc = tbl_genCustomerAccount.Select(txtCustomerID.Tag.ToString(), sAccountNo);
                        if (acc == null)
                        {
                            tbl_genCustomerAccount account = new tbl_genCustomerAccount(txtCustomerID.Tag.ToString(), sAccountNo,
                                 sBankID, sBranchID, 0, 0, 0);
                            account.Insert();
                        }
                    }
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Insert_BankTransfer()
        {
            try
            {
                #region insert Grid - Bank Transfer Details
                foreach (DataGridViewRow row in dgvBankTransfer.Rows)
                {
                    string sAccountNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAccountNo", row.Index, "");
                    string sBankID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBankID", row.Index, "default");
                    string sBranchID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTBranchID", row.Index, "default");
                    int sTTypeID = clsValidate.ValidateGridValue(dgvBankTransfer, "BTTypeID", row.Index, -1);
                    string sTRefNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTRefNo", row.Index, "");
                    decimal dAmount = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAmount", row.Index, decimal.Parse("0.00"));
                    DateTime dBTDate = DateTime.Parse(dgvBankTransfer["BTDate", row.Index].Value.ToString());
                    int iCompanyAccount_ID = clsGenaralName.getName_CompanyAccount_IDByAccountNo(sAccountNo);
                    string sRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigBankTransferRegisterCode);

                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dBTDate, (int)PaymentMethod.Bank_Transfer, sTTypeID, sTRefNo, (-1), (-1), "", "", (-1), (-1),
                        dBTDate, txtCustomerID.Tag.ToString(),"", sAccountNo, iCompanyAccount_ID, sBankID, "default", sBranchID, "default",clsAutocode.getChequeStatusID(ChequeStatus.Deposited), "default", "default",
                        "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(), "","default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), 
                        clsSecurity.FinancialYearID, dAmount, false, false, false, false, false, false, false, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                        false, false, 0, 0, 0, 0, dBTDate, dBTDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1),(-1));
                    RegisterDetails.Insert();
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Insert_Cards()
        {
            try
            {
                #region Insert Grid - Card Details
                foreach (DataGridViewRow row in dgvCard.Rows)
                {
                    DateTime dChequeDate = clsSecurity.getServerDateTime();

                    string sName = clsValidate.ValidateGridValue(dgvCard, "crdName", row.Index, "");
                    string sBankID = clsValidate.ValidateGridValue(dgvCard, "crdBankID", row.Index, "default");
                    int sTypeID = clsValidate.ValidateGridValue(dgvCard, "crdTypeID", row.Index, -1);
                    decimal dAmount = clsValidate.ValidateGridValue(dgvCard, "crdAmount", row.Index, decimal.Parse("0.00"));
                    string sLastFourDigits = clsValidate.ValidateGridValue(dgvCard, "crdLastFourDigits", row.Index, "default");

                    string sRegisterCode = clsAutocode.getAutoGeneratedCode(sFormConfigCardRegisterCode);

                    tbl_bpsChequeRegister RegisterDetails = new tbl_bpsChequeRegister(sRegisterCode, "", dtpReceiptDate.Value, (int)PaymentMethod.Card,
                        (-1), "", (-1), (-1), sLastFourDigits, sName, sTypeID, (-1),
                        dChequeDate, txtCustomerID.Tag.ToString(), "", "", -1, sBankID, "default", "default", "default",
                        clsAutocode.getChequeStatusID(ChequeStatus.New), "default", "default", "-1", txtReceiptID.Text, "default", "default", txtOrderRefNo.Tag.ToString(),
                        "", "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                        dAmount, false, false, false, false, false, false, false,
                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                        false, false, 0, 0, 0, 0, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.CompanyID, clsSecurity.BranchID, (-1), (-1), (-1));
                    RegisterDetails.Insert();
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        #region Button Cancel
        private void UC_bpsReceiptSales_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiptID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpReceiptDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                            if (detail != null && CheckValidity_Dependancies(detail.Receipt_ID))
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, txtCustomerID.Tag.ToString()))
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Receipt : " + detail.Receipt_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();

                                                #region Update Cheques
                                                clsHelpMethods_Local.RemoveSattlementsFrom_ReceiptID_CashAndCheque(txtReceiptID.Text.Trim());//need to rewrite

                                                tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(detail.Receipt_ID);
                                                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(txtReceiptID.Text.Trim()))
                                                {
                                                    oCheque.IsDeleted = true;
                                                    oCheque.DateModified = clsSecurity.getServerDateTime();
                                                    oCheque.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    oCheque.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Deleted);
                                                    oCheque.Update();
                                                }
                                                #endregion

                                                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID))
                                                {
                                                    clsMethods_GL.GLPosting_Delete(oCheque.GlPosting_ID);
                                                }

                                                Cursor = Cursors.Default;
                                                email.createEmail_Receipt(txtReceiptID.Text.Trim(), enum_Alerts.ReceiptCanceled);

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
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
                Cursor = Cursors.Default;
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Button Print
        private void UC_bpsReceiptSales_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Button Draft
        private void UC_bpsReceiptSales_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Button Checked
        private void UC_bpsReceiptSales_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        #endregion

        #region Button Approved
        private void UC_bpsReceiptSales_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        #endregion

        #region Button History
        private void UC_bpsReceiptSales_SF_History_Click(object sender, EventArgs e)
        {
            UserHistory();
        }
        #endregion

        #region Button Add n Remove - Cheque
        private void btnChqAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidity_ChequeEmptyField())
                {
                    if (CheckValidity_ReceptDateAndChequeDate())
                    {
                        if (CheckFunctionValidity())
                        {
                            int iRow;

                            if (IsSelectedChequeGridRow)
                            {
                                iRow = int.Parse(txtChqRowNo.Text.Trim());
                            }
                            else
                            {
                                dgvCheq.Rows.Add();
                                iRow = dgvCheq.Rows.Count - 1;
                                dgvCheq["GridChequeStatus", iRow].Value = "New";
                                dgvCheq["GridChequeStatus", iRow].Tag = clsAutocode.getChequeStatusID(ChequeStatus.New);
                            }

                            dgvCheq["AccountNo", iRow].Value = txtAccountID.Text;
                            dgvCheq["Bank", iRow].Value = txtBankID.Text;
                            dgvCheq["Branch", iRow].Value = txtBranchID.Text;
                            dgvCheq["ChequeType", iRow].Value = txtChequeTypeID.Text;
                            dgvCheq["ChequeNo", iRow].Value = txtChequeNo.Text;
                            dgvCheq["ChequeDate", iRow].Value = dtpChequeDate.Text;
                            dgvCheq["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtAmount.Text));
                            dgvCheq["Remark", iRow].Value = txtChequeRemarks.Text;

                            if (txtBankID.Tag != null)
                                dgvCheq["BankID", iRow].Value = txtBankID.Tag.ToString();
                            else
                                dgvCheq["BankID", iRow].Value = "default";

                            if (txtBranchID.Tag != null)
                                dgvCheq["BranchID", iRow].Value = txtBranchID.Tag.ToString();
                            else
                                dgvCheq["BranchID", iRow].Value = "default";

                            if (txtChequeTypeID.Tag != null)
                                dgvCheq["ChequeTypeID", iRow].Value = txtChequeTypeID.Tag.ToString();
                            else
                                dgvCheq["ChequeTypeID", iRow].Value = "default";

                            CalculateChequesAmount();
                            ClearChequeDetail();
                        }
                    }
                }
            }
            catch (Exception ex) { SEACCException.Show(ex); clsValidate.WriteErrorLog("", iFormID, ex); }
        }

        private void btnChqRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCheq.SelectedCells.Count != 0)
                {
                    if (dgvCheq.Rows.Count > 0)
                    {
                        dgvCheq.Rows.RemoveAt(dgvCheq.SelectedCells[0].RowIndex);

                        ClearChequeDetail();
                        CalculateChequesAmount();
                    }
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
        #endregion

        #region Button Add n Remove - Card
        private void btnCrdAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidity_CardEmptyField())
                {
                    int iRow;

                    if (IsSelectedCardGridRow)
                        iRow = int.Parse(txtCrdRowNo.Text.Trim());

                    else
                    {
                        dgvCard.Rows.Add();
                        iRow = dgvCard.Rows.Count - 1;
                    }

                    dgvCard["crdName", iRow].Value = txtCrdName.Text;
                    dgvCard["crdBank", iRow].Value = txtCrdBank.Text;
                    dgvCard["crdLastFourDigits", iRow].Value = txtCrdLastDigits.Text;
                    dgvCard["crdType", iRow].Value = cmbCrdType.SelectedValue;
                    dgvCard["crdAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtCrdAmount.Text));
                    dgvCard["crdTypeID", iRow].Value = cmbCrdType.SelectedIndex;

                    if (txtCrdBank.Tag != null)
                        dgvCard["crdBankID", iRow].Value = txtCrdBank.Tag.ToString();
                    else
                        dgvCard["crdBankID", iRow].Value = "default";

                    CalculateCardAmount();
                    ClearCardDetail();
                }
            }
            catch (Exception ex) { SEACCException.Show(ex); clsValidate.WriteErrorLog("", iFormID, ex); }
        }

        private void btnCrdRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCard.SelectedCells.Count != 0)
                {
                    if (dgvCard.Rows.Count > 0)
                    {
                        dgvCard.Rows.RemoveAt(dgvCard.SelectedRows[0].Index);
                        CalculateCardAmount();
                        ClearCardDetail();
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

        #region Button Add n Remove - Bank Transfer
        private void btnBTAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidity_BankTransferEmptyField())
                {
                    int iRow;
                    if (IsSelectedBankTransferGridRow)
                    {
                        iRow = int.Parse(txtBTRowNo.Text.Trim());
                    }
                    else
                    {
                        dgvBankTransfer.Rows.Add();
                        iRow = dgvBankTransfer.Rows.Count - 1;
                    }

                    dgvBankTransfer["BTAccountNo", iRow].Value = txtBTAccountNo.Text;
                    dgvBankTransfer["BTBank", iRow].Value = txtBTBank.Text;
                    dgvBankTransfer["BTBranch", iRow].Value = txtBTBranch.Text;
                    dgvBankTransfer["BTRefNo", iRow].Value = txtBTRefNo.Text;
                    dgvBankTransfer["BTType", iRow].Value = cmbBTType.SelectedValue;
                    dgvBankTransfer["BTDate", iRow].Value = dtpBTDate.Value.ToShortDateString();
                    dgvBankTransfer["BTAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(txtBTAmount.Text));
                    dgvBankTransfer["BTTypeID", iRow].Value = cmbBTType.SelectedIndex;

                    if (txtBTBank.Tag != null)
                        dgvBankTransfer["BTBankID", iRow].Value = txtBTBank.Tag.ToString();
                    else
                        dgvBankTransfer["BTBankID", iRow].Value = "default";

                    if (txtBTBranch.Tag != null)
                        dgvBankTransfer["BTBranchID", iRow].Value = txtBTBranch.Tag.ToString();
                    else
                        dgvBankTransfer["BTBranchID", iRow].Value = "default";

                    CalculateBankTransferAmount();
                    ClearBankTransferDetail();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex); SEACCException.Show(ex);
            }
        }

        private void btnBTRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBankTransfer.SelectedCells.Count != 0)
                {
                    if (dgvBankTransfer.Rows.Count > 0)
                    {
                        dgvBankTransfer.Rows.RemoveAt(dgvBankTransfer.SelectedCells[0].RowIndex);
                      //  dgvBankTransfer.Rows.RemoveAt(dgvBankTransfer.SelectedRows[0].RowIndex);
                        CalculateBankTransferAmount();
                        ClearBankTransferDetail();
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

        #region Button Add n Remove - Invoice
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Search_Invoice();
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvInvoice.SelectedCells.Count != 0)
                {
                    if (dgvInvoice.Rows.Count > 0)
                    {
                        dgvInvoice.Rows.RemoveAt(dgvInvoice.SelectedCells[0].RowIndex);
                        CalculateInvoiceTotal();
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

        #region Button Customer Viewer
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            {
                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                frm.glbCustomerID = txtCustomerID.Tag.ToString();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();

            }
        }
        #endregion

        #region Button Receipt Viewer
        private void btnReceiptID_Click(object sender, EventArgs e)
        {
            if (txtReceiptID.TextLength > 0)
            {
                frm_bpsReceiptAgeingViewer frm = new frm_bpsReceiptAgeingViewer();
                frm.glbReceiptID = txtReceiptID.Text.Trim();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();

            }
        }
        #endregion

        #region Button Refundable Note
        private void btnRefundableNote_Click(object sender, EventArgs e)
        {
            if (txtReceiptID.Text.Trim().Length > 0)
            {
                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptID.Text);
                if (detail != null && detail.Receipt_ID != "default" && !detail.IsDeleted)
                {
                    bool bAllowDetail = true;
                    string message = "";

                    if (detail.IsSeattled)
                    {
                        bAllowDetail = false;
                        message = "Already Settled";
                    }

                    if (bAllowDetail)
                    {
                        frm_bpsIntercompanyTransactions frm = new frm_bpsIntercompanyTransactions(FormName.bssIntercomapnyTransaction);
                        frm.glbReceiptID = detail.Receipt_ID;
                        frm.gbl_bIsRefundableNote = true;
                        clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                    }
                    else
                        MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Btn Temp
        private void UC_bpsReceiptSales_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtReceiptID.TextLength > 0 && txtReceiptID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                rdoPartPayment.Checked = true;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesExecutiveID, true);

                clsCommon.SetEnableDisable_NormalLabel(lblReceiptID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesExecutiveID, true);

                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);

                txtReceiptID.Tag = null;
                dtpReceiptDate.Value = clsSecurity.getServerDateTime();

                ClearChequeDetail();
                ClearCardDetail();
                ClearBankTransferDetail();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtReceiptID.Text = "<Auto Generate>";
                else
                    txtReceiptID.Clear();
                if (txtReceiptID.Enabled)
                {
                    txtReceiptID.SelectAll();
                    txtReceiptID.Focus();
                }

                ucSasProcessFlow.ClearFlow();
                Attachments.Clear();
            }
        }
        #endregion
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvCheq, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvCard, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgvBankTransfer, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormatWithSize_New(dgvInvoice, clsFormatter.colorGrid, UI_Color, 7.25F);
        }
        #endregion

        #region Expander Format
        private void CusExpanderFormat()
        {
            try
            {
                expanderBankTransfer.InitializeSize();
                expanderCard.InitializeSize();
                expanderCash.InitializeSize();
                expanderCheque.InitializeSize();

                expanderBankTransfer.ThemeColor = Color.FromArgb(117, 82, 107);
                expanderCard.ThemeColor = Color.FromArgb(117, 82, 107);
                expanderCash.ThemeColor = Color.FromArgb(117, 82, 107);
                expanderCheque.ThemeColor = Color.FromArgb(117, 82, 107);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        #region Clear Fields - All
        private void ClearFields()
        {
            IsUpdate = false;
            lblCancelled.Visible = false;

            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesExecutiveID, true);

            clsCommon.SetEnableDisable_NormalLabel(lblReceiptID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesExecutiveID, true);

            rdoPartPayment.Checked = true;

            //Header
            txtCustomerID.Tag = null;
            txtReceiptID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtSalesNoteType.Tag = null;
            txtCollector1.Tag = null;

            txtReceiptID.Clear();
            txtChequeRemarks.Clear();
            txtSalesExecutiveID.Clear();
            txtOrderRefNo.Clear();
            txtSalesNoteType.Clear();
            txtCollector1.Clear();
            txtCustomerID.Clear();
            txtAmountInWord.Clear();
            txtRemark.Clear();
            txtTmpReceiptNo.Clear();
            dtpReceiptDate.Value = clsSecurity.getServerDateTime();

            txtSalesNoteType.Visible = false;
            lblSalesNoteType.Visible = false;

            lblTotalAmount.Text = "0.00";

            //Cash
            expanderCash.DisplayAmount = "0.00";
            txtCashAmount.Text = "0.00";
            txtCashChequeRegisterID.Clear();

            //Cheque
            expanderCheque.DisplayAmount = "0.00";

            //Bank Transfers
            expanderBankTransfer.DisplayAmount = "0.00";

            //Card
            expanderCard.DisplayAmount = "0.00";

            ClearChequeDetail();
            ClearCardDetail();
            ClearBankTransferDetail();

            dgvCheq.Rows.Clear();
            dgvBankTransfer.Rows.Clear();
            dgvCard.Rows.Clear();
            dgvInvoice.Rows.Clear();

            //Reset Order Ref No
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtReceiptID.Text = "<Auto Generate>";
            else
                txtReceiptID.Clear();

            btnRefundableNote.Visible = clsConfig.bDisplay_RefundableButton;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            ucSasProcessFlow.ClearFlow();

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            Attachments.Clear();

            txtPageNo.Clear();
            txtPageNo.Enabled = true;
        }
        #endregion

        #region Clear Cheque Detail
        private void ClearChequeDetail()
        {
            IsSelectedChequeGridRow = false;

            txtChqRowNo.Clear();
            txtChequeRemarks.Clear();
            txtAccountID.Clear();
            txtBankID.Clear();
            txtBranchID.Clear();
            txtChequeTypeID.Clear();
            txtChequeNo.Clear();
            txtAmount.Clear();

            txtAccountID.Tag = null;
            txtBankID.Tag = null;
            txtBranchID.Tag = null;
            txtChequeTypeID.Tag = null;
            txtChequeNo.Tag = null;
        }
        #endregion

        #region Clear Bank Transfer Detail
        private void ClearBankTransferDetail()
        {
            IsSelectedBankTransferGridRow = false;

            cmbBTType.DataSource = clsHelpMethods.GetEnumDescription(typeof(BankTransferTypes));
            cmbBTType.SelectedIndex = -1;

            txtBTAccountNo.Tag = null;
            txtBTBank.Tag = null;
            txtBTBranch.Tag = null;

            txtBTAccountNo.Clear();
            txtBTAmount.Clear();
            txtBTBank.Clear();
            txtBTBranch.Clear();
            txtBTRefNo.Clear();
        }
        #endregion

        #region Clear Card Detail
        private void ClearCardDetail()
        {
            IsSelectedCardGridRow = false;

            cmbCrdType.DataSource = clsHelpMethods.GetEnumDescription(typeof(PaymentCardTypes));
            cmbCrdType.SelectedIndex = -1;

            txtCrdAmount.Clear();
            txtCrdBank.Clear();
            txtCrdLastDigits.Clear();
            txtCrdName.Clear();

            txtCrdBank.Tag = null;
        }
        #endregion
        #endregion

        #region Refresh Grid
        private void RefreshChequeGrid_ByReceiptID(string sReceiptID)
        {
            try
            {
                int iRow = 0;
                decimal dAmount = 0;
                dgvCheq.Rows.Clear();

                List<tbl_bpsChequeRegister> oListCheque = tbl_bpsChequeRegister.SelectAllByReceipt_ID(sReceiptID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cheque).ToList();
                foreach (tbl_bpsChequeRegister detail in oListCheque)
                {
                    dgvCheq.Rows.Add();
                    iRow = dgvCheq.Rows.Count - 1;

                    dgvCheq["ChequeRegisterCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.ChequeRegister_ID);
                    dgvCheq["ChequeType", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ChequeType(detail.ChequeType_ID));
                    dgvCheq["Branch", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BankBranch(detail.Branch_ID));
                    dgvCheq["Bank", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Bank(detail.Bank_ID));

                    dgvCheq["AccountNo", iRow].Value = detail.AccountNumber;
                    dgvCheq["ChequeNo", iRow].Value = detail.ChequeNumber;
                    dgvCheq["ChequeDate", iRow].Value = detail.DateCheque.ToShortDateString();
                    dgvCheq["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dgvCheq["GridChequeStatus", iRow].Value = clsGenaralName.getName_ChequeStatus(detail.ChequeStatus_ID);
                    dgvCheq["Remark", iRow].Value = detail.Remark;

                    dgvCheq["GridChequeStatus", iRow].Tag = detail.ChequeStatus_ID;
                    dgvCheq["ChequeTypeID", iRow].Value = detail.ChequeType_ID;
                    dgvCheq["BankID", iRow].Value = detail.Bank_ID;
                    dgvCheq["BranchID", iRow].Value = detail.Branch_ID;

                    dAmount += detail.Amount;
                }

                if (oListCheque.Count > 0)
                    expanderCheque.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshCardGrid_ByReceiptID(string sReceiptID)
        {
            try
            {
                int iRow = 0;
                decimal dAmount = 0;
                dgvCard.Rows.Clear();

                List<tbl_bpsChequeRegister> oListCard = tbl_bpsChequeRegister.SelectAllByReceipt_ID(sReceiptID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Card).ToList();
                foreach (tbl_bpsChequeRegister detail in oListCard)
                {
                    dgvCard.Rows.Add();
                    iRow = dgvCard.Rows.Count - 1;

                    dgvCard["crdName", iRow].Value = detail.CardOwnerName;
                    dgvCard["crdBank", iRow].Value = clsGenaralName.getName_Bank(detail.Bank_ID);
                    dgvCard["crdLastFourDigits", iRow].Value = detail.LastFourDigits;
                    dgvCard["crdType", iRow].Value = clsHelpMethods.GetEnumDescription_Name((PaymentCardTypes)detail.CardType);
                    dgvCard["crdAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dgvCard["crdBankID", iRow].Value = detail.Bank_ID;
                    dgvCard["crdTypeID", iRow].Value = detail.CardType;
                    dgvCard["crdChequeRegisterCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.ChequeRegister_ID);

                    dAmount += detail.Amount;
                }

                if (oListCard.Count > 0)
                    expanderCard.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshBankTransferGrid_ByReceiptID(string sReceiptID)
        {
            try
            {
                int iRow = 0;
                decimal dAmount = 0;
                dgvBankTransfer.Rows.Clear();

                List<tbl_bpsChequeRegister> oListBankTransfer = tbl_bpsChequeRegister.SelectAllByReceipt_ID(sReceiptID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Bank_Transfer).ToList();
                foreach (tbl_bpsChequeRegister detail in oListBankTransfer)
                {
                    dgvBankTransfer.Rows.Add();
                    iRow = dgvBankTransfer.Rows.Count - 1;

                    dgvBankTransfer["BTAccountNo", iRow].Value = detail.DepositedAccountNumber;

                    tbl_genCompanyAccount oCompanyAcc = tbl_genCompanyAccount.Select(detail.DepositedAccountNumber);
                    if (detail != null)
                    {
                        dgvBankTransfer["BTBankID", iRow].Value = oCompanyAcc.Bank_ID;
                        dgvBankTransfer["BTBranchID", iRow].Value = oCompanyAcc.Branch_ID;

                        dgvBankTransfer["BTBank", iRow].Value = clsGenaralName.getName_Bank(oCompanyAcc.Bank_ID);
                        dgvBankTransfer["BTBranch", iRow].Value = clsGenaralName.getName_BankBranch(oCompanyAcc.Branch_ID);
                    }

                    dgvBankTransfer["BTRefNo", iRow].Value = detail.TransferRefNo;
                    dgvBankTransfer["BTType", iRow].Value = clsHelpMethods.GetEnumDescription_Name((BankTransferTypes)detail.TransferType);
                    dgvBankTransfer["BTDate", iRow].Value = detail.DateRegister.ToShortDateString();
                    dgvBankTransfer["BTAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);

                    dgvBankTransfer["BTTypeID", iRow].Value = detail.TransferType;
                    dgvBankTransfer["BTChequeRegisterCode", iRow].Value = clsCommon.GetForeignKeyValue(detail.ChequeRegister_ID);

                    dAmount += detail.Amount;
                }

                if (oListBankTransfer.Count > 0)
                    expanderBankTransfer.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshInvoiceGrid(string sReceipt)
        {
            try
            {
                int iRow;
                dgvInvoice.Rows.Clear();

                foreach (tbl_bpsReceipt_Invoice detail in tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(sReceipt))
                {
                    if (detail.Receipt_ID != "default" && detail.Invoice_ID != "default")
                    {
                        tbl_sasInvoice invoicedetail = tbl_sasInvoice.Select(detail.Invoice_ID);
                        if (invoicedetail != null && invoicedetail.Invoice_ID != "default" && !invoicedetail.IsDeleted)
                        {
                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;

                            decimal dBalanceAmount = (invoicedetail.GrandTotal - invoicedetail.SeattleAmount) / invoicedetail.CurrencyRate;
                            decimal dAllocatedAmount = 0;
                            foreach (tbl_sasInvoice_Sattled oSettlement in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(invoicedetail.Invoice_ID).Where(p => p.Receipt_ID == sReceipt))
                                dAllocatedAmount += oSettlement.SattledAmount / invoicedetail.CurrencyRate;

                            dgvInvoice["InvoiceID", iRow].Value = detail.Invoice_ID;
                            dgvInvoice["OrderRefNo", iRow].Value = detail.OrderRefNo_ID;
                            dgvInvoice["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalanceAmount);
                            dgvInvoice["AllocatedAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);
                        }
                    }
                }

                if (dgvInvoice.Rows.Count > 4)
                {
                    dgvInvoice.Columns["InvoiceAmount"].Width = 92;
                    dgvInvoice.Columns["AllocatedAmount"].Width = 92;
                }
                CalculateInvoiceTotal();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Details
        #region Fill Details - All
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, false);

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        txtCustomerID.Enabled = false;
                        txtSalesNoteType.Enabled = false;

                        lblReceiptID.Enabled = false;
                        lblCustomerID.Enabled = false;
                        lblSalesNoteType.Enabled = false;

                        txtReceiptID.Text = detail.Receipt_ID;
                        dtpReceiptDate.Value = detail.ReceiptDate;

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtCollector1.Tag = detail.Collector_ID;
                        txtCollector2.Tag = detail.collector_ID2;
                        txtCollector3.Tag = detail.collector_ID3;
                        txtCollector4.Tag = detail.collector_ID4;

                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType.Text = clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID);
                        txtCollector1.Text = clsGenaralName.getName_Employee(detail.Collector_ID);
                        txtCollector2.Text = clsGenaralName.getName_Employee(detail.collector_ID2);
                        txtCollector3.Text = clsGenaralName.getName_Employee(detail.collector_ID3);
                        txtCollector4.Text = clsGenaralName.getName_Employee(detail.collector_ID4);
                        txtPageNo.Text = detail.PageNo;
                        txtPageNo.Enabled = false;
                        rdoAdvancePayment.Checked = detail.IsAdvance;
                        rdoPartPayment.Checked = (!detail.IsAdvance && !detail.IsOverPayment) ? true : false;

                        txtRemark.Text = detail.Remark;
                        txtTmpReceiptNo.Text = detail.TmpReceipt_ID;

                        txtAmountInWord.Text = detail.TatalAmountInWord;
                        lblTotalAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate));

                        FillDetailsCurrency(detail.Currency_ID);

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

                        //fill cash amount
                        List<tbl_bpsChequeRegister> oListCash = tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID).Where(p => p.PaymentMethod_ID == (int)PaymentMethod.Cash).ToList();
                        foreach (tbl_bpsChequeRegister detailCash in oListCash)
                        {
                            txtCashAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detailCash.Amount);
                            expanderCash.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(detailCash.Amount);
                            txtCashChequeRegisterID.Text = detailCash.ChequeRegister_ID;
                        }

                        RefreshInvoiceGrid(detail.Receipt_ID); //Refresh Invoice Grid
                        RefreshChequeGrid_ByReceiptID(detail.Receipt_ID); //Refresh Cheques Grid
                        RefreshBankTransferGrid_ByReceiptID(detail.Receipt_ID); //Refresh Bank Transfer Grid
                        RefreshCardGrid_ByReceiptID(detail.Receipt_ID); //Refresh Card Grid

                        ucSasProcessFlow.SetProcessFlowBySalesReceipt(detail.Receipt_ID);//process flow

                        Attachments.FillAttachments(sID);//attachment
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

        #region Fill Invoice Details
        private void FillInvoiceDetails(string sInvID)
        {
            try
            {
                if (sInvID != null && sInvID.Length > 0)
                {
                    if (CheckInvoiceValidity(sInvID))
                    {
                        tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvID);
                        if (detail != null)
                        {
                            int iRow;

                            dgvInvoice.Rows.Add();
                            iRow = dgvInvoice.Rows.Count - 1;

                            decimal dAllocatedAmount = 0;
                            decimal dBalanceAmount = detail.CurrencyRate > 0 && (detail.GrandTotal - detail.SeattleAmount) != 0 ? (detail.GrandTotal - detail.SeattleAmount) / detail.CurrencyRate : 0;

                            dgvInvoice["InvoiceID", iRow].Value = detail.Invoice_ID;
                            dgvInvoice["OrderRefNo", iRow].Value = detail.OrderRefNo_ID;
                            dgvInvoice["InvoiceAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalanceAmount);
                            dgvInvoice["AllocatedAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);
                            if (detail.Currency_ID != null)
                            {
                                txtCurrencyID.Tag = detail.Currency_ID;
                                FillDetailsCurrency(detail.Currency_ID);
                            }

                            txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                            txtSalesNoteType.Text = clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID);


                            CalculateInvoiceTotal();
                            txtInvoiceID.Clear();

                            //set the orderdetail/salesrep                        
                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                            if (order != null)
                            {
                                if (order.Employee_ID != "default")
                                {
                                    txtSalesExecutiveID.Tag = order.Employee_ID;
                                    txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));

                                    txtCollector1.Tag = order.Employee_ID;
                                    txtCollector1.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                                }

                                txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                                txtSalesExecutiveID.Enabled = false;
                            }

                            if (dgvInvoice.Rows.Count > 4)
                            {
                                dgvInvoice.Columns["InvoiceAmount"].Width = 92;
                                dgvInvoice.Columns["AllocatedAmount"].Width = 92;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Customer Detials
        private void FillDetailsCustomer(string sCustomerID)
        {
            try
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();

                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = customer.CustomerName;

                    if (customer.SalesRep_ID != null && customer.SalesRep_ID != "default")
                    {
                        string sRepName = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);
                        txtSalesExecutiveID.Tag = customer.SalesRep_ID;
                        txtSalesExecutiveID.Text = sRepName;

                        tbl_ZEmpSalesRep oRep = tbl_ZEmpSalesRep.Select(customer.SalesRep_ID);
                        if (oRep != null && oRep.IsCollector)
                        {
                            txtCollector1.Tag = customer.SalesRep_ID;
                            txtCollector1.Text = sRepName;
                        }
                        else
                        {
                            txtCollector1.Tag = "default";
                            txtCollector1.Text = "-";
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

        #region Fill Cheque Register Details
        private void FillChequeRegisterDetails(int iRow)
        {
            try
            {
                //Fill records
                txtAccountID.Text = dgvCheq["AccountNo", iRow].Value.ToString();
                txtBankID.Text = dgvCheq["Bank", iRow].Value.ToString();
                txtBranchID.Text = dgvCheq["Branch", iRow].Value.ToString();
                txtChequeTypeID.Text = dgvCheq["ChequeType", iRow].Value.ToString();
                txtChequeRemarks.Text = dgvCheq["Remark", iRow].Value.ToString();
                txtChequeNo.Text = dgvCheq["ChequeNo", iRow].Value.ToString();
                txtAmount.Text = dgvCheq["Amount", iRow].Value.ToString();
                dtpChequeDate.Text = dgvCheq["ChequeDate", iRow].Value.ToString();

                txtChequeRegisterID.Text = clsValidate.ValidateGridValue(dgvCheq, "ChequeRegisterCode", iRow, "");

                txtBankID.Tag = dgvCheq["BankID", iRow].Value.ToString();
                txtBranchID.Tag = dgvCheq["BranchID", iRow].Value.ToString();
                txtChequeTypeID.Tag = dgvCheq["ChequeTypeID", iRow].Value.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Card Payment Details
        private void FillCardPaymentDetails(int iRow)
        {
            try
            {
                //Fill records
                txtCrdAmount.Text = dgvCard["crdAmount", iRow].Value.ToString();
                txtCrdBank.Text = dgvCard["crdBank", iRow].Value.ToString();
                txtCrdLastDigits.Text = dgvCard["crdLastFourDigits", iRow].Value.ToString();
                txtCrdName.Text = dgvCard["crdName", iRow].Value.ToString();
                txtCardChequeRegisterID.Text = clsValidate.ValidateGridValue(dgvCard, "crdChequeRegisterCode", iRow, "");

                txtCrdBank.Tag = dgvCard["crdBankID", iRow].Value.ToString();
                cmbCrdType.SelectedIndex = int.Parse(dgvCard["crdTypeID", iRow].Value.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Bank Transfer Details
        private void FillBankTransferDetails(int iRow)
        {
            try
            {
                //Fill records
                txtBTAccountNo.Text = dgvBankTransfer["BTAccountNo", iRow].Value.ToString();
                txtBTBank.Text = dgvBankTransfer["BTBank", iRow].Value.ToString();
                txtBTBranch.Text = dgvBankTransfer["BTBranch", iRow].Value.ToString();
                txtBTRefNo.Text = dgvBankTransfer["BTRefNo", iRow].Value.ToString();
                dtpBTDate.Text = dgvBankTransfer["BTDate", iRow].Value.ToString();
                txtBTAmount.Text = dgvBankTransfer["BTAmount", iRow].Value.ToString();
                txtBankTransferChequeRegisterID.Text = clsValidate.ValidateGridValue(dgvCheq, "BTChequeRegisterCode", iRow, "");

                txtBankID.Tag = dgvBankTransfer["BTBankID", iRow].Value.ToString();
                txtBranchID.Tag = dgvBankTransfer["BTBranchID", iRow].Value.ToString();
                cmbBTType.SelectedIndex = int.Parse(dgvBankTransfer["BTTypeID", iRow].Value.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Account Detail
        private void FillBankAccountDetails(string sCustomerID, string sAccountID, ref TextBox txtBox2, ref TextBox txtBox3)
        {
            try
            {
                if (sAccountID != null)
                {
                    tbl_genCustomerAccount detail = tbl_genCustomerAccount.Select(sCustomerID, sAccountID);
                    if (detail != null)
                    {
                        txtBox2.Tag = detail.Bank_ID;
                        txtBox2.Text = clsGenaralName.getName_Bank(detail.Bank_ID);
                        txtBox3.Tag = detail.Branch_ID;
                        txtBox3.Text = clsGenaralName.getName_BankBranch(detail.Branch_ID);
                    }
                    else
                    {
                        txtBox2.Tag = null;
                        txtBox2.Text = "";
                        txtBox3.Tag = null;
                        txtBox3.Text = "";
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
                tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                if (currency != null)
                {
                    txtCurrencyID.Tag = currency.Currency_ID;
                    txtCurrencyID.Text = currency.CurrencyName;
                    txtCurrencyCode.Text = currency.CurrencyCode;
                    txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Company Bank Account
        private void FillCompanyAccountDetails(string sAccountID, ref TextBox txtBox2, ref TextBox txtBox3)
        {
            try
            {
                if (sAccountID != null)
                {
                    tbl_genCompanyAccount detail = tbl_genCompanyAccount.Select(sAccountID);
                    if (detail != null)
                    {
                        txtBox2.Tag = detail.Bank_ID;
                        txtBox2.Text = clsGenaralName.getName_Bank(detail.Bank_ID);
                        txtBox3.Tag = detail.Branch_ID;
                        txtBox3.Text = clsGenaralName.getName_BankBranch(detail.Branch_ID);
                    }
                    else
                    {
                        txtBox2.Tag = null;
                        txtBox2.Text = "";
                        txtBox3.Tag = null;
                        txtBox3.Text = "";
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
        #endregion

        #region Events Double Click
        private void txtReceiptID_DoubleClick(object sender, EventArgs e)
        {
            Search_ReceiptID();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null)
                ClearFields();
            Search_CustomerID();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtChequeTypeID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_ChequeType_New(ref txtChequeTypeID);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtCollector_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector1);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtAccountID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerBankAccount(ref txtAccountID, ref txtBankID, ref txtBranchID);
        }
        private void txtBankID_DoubleClick(object sender, EventArgs e)
        {
            Search_Bank(ref txtBankID);
        }
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_Branch(ref txtBranchID, txtBankID.Tag.ToString());
        }

        private void txtCrdBank_DoubleClick(object sender, EventArgs e)
        {
            Search_Bank(ref txtCrdBank);
        }
        private void txtBTAccountNo_DoubleClick(object sender, EventArgs e)
        {
            Search_CompanyBankAccount(ref txtBTAccountNo, ref txtBTBank, ref txtBTBranch);
        }
        #endregion

        #region Events KeyDown
        private void frm_bpsReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        private void txtReceiptID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ReceiptID();
            }
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtCustomerID.Tag != null)
                    ClearFields();
                Search_CustomerID();
            }
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesExecutiveID();
        }
        private void txtChequeTypeID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_ChequeType_New(ref txtChequeTypeID);
            }
        }
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }
        private void txtAccountID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerBankAccount(ref txtAccountID, ref txtBankID, ref txtBranchID);
        }
        private void txtBankID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Bank(ref txtBankID);
        }
        private void txtBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Branch(ref txtBranchID, txtBankID.Tag.ToString());
        }
        private void txtCrdBank_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Bank(ref txtCrdBank);
        }
        private void txtBTAccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CompanyBankAccount(ref txtBTAccountNo, ref txtBTBank, ref txtBTBranch);
        }
        //private void txtBTBank_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //        Search_Bank(ref txtBTBank);
        //}
        //private void txtBTBranch_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.F1)
        //        Search_Branch(ref txtBTBranch, txtBTBank.Tag.ToString());
        //}

        private void txtCashAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                decimal dCashAmount = decimal.Parse(txtCashAmount.Text);
                txtCashAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dCashAmount);
            }
        }
        #endregion

        #region Events Key Up
        private void txtCashAmount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                CalculateCashAmount();
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Events Kep Press
        private void txtCashAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtCashAmount.Text, e);
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtAmount.Text, e);
        }

        private void txtCrdAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtCrdAmount.Text, e);
        }

        private void txtBTAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtBTAmount.Text, e);
        }
        #endregion

        #region Event Data Grid
        #region Data Grid Cell Click
        private void dgvCheq_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    FillChequeRegisterDetails(e.RowIndex);
                    txtChqRowNo.Text = e.RowIndex.ToString();
                    IsSelectedChequeGridRow = true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvCard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    FillCardPaymentDetails(e.RowIndex);
                    txtCrdRowNo.Text = e.RowIndex.ToString();
                    IsSelectedCardGridRow = true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvBankTransfer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    FillBankTransferDetails(e.RowIndex);
                    txtBTRowNo.Text = e.RowIndex.ToString();
                    IsSelectedBankTransferGridRow = true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Cell Content Click
        private void dgvCheq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCheq_CellClick(sender, e);
        }

        private void dgvCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCard_CellClick(sender, e);
        }

        private void dgvBankTransfer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvBankTransfer_CellClick(sender, e);
        }
        #endregion

        private void dgvInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    CalculateInvoiceTotal();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Event Text Changed
        private void lblTotalAmount_TextChanged(object sender, EventArgs e)
        {
            if (decimal.Parse(lblTotalAmount.Text.Trim()) > 0)
                txtAmountInWord.Text = clsCommon.CurrencyToWord(decimal.Parse(lblTotalAmount.Text.Trim()));
        }
        #endregion

        #region Search Methods
        private void Search_ReceiptID()
        {
            try
            {
                clsSearch.Search_TransactionReceipt_Direct(ref txtReceiptID, chkShowSettle.Checked, IsSalesReceipt, rdoAdvancePayment.Checked, clsConfig.bEnableReceiptSort_ByReceiptID);
                if (txtReceiptID.TextLength > 0 && txtReceiptID.Text != "<Auto Generate>")
                    FillDetails(txtReceiptID.Text.Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Invoice()
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {

                    if (IsSalesReceipt)
                        clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), false, "", false, true, false, true, true, "");
                    else
                        clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), false, "", false, false, true, true, false, "");

                    if (txtInvoiceID.Tag != null && txtInvoiceID.TextLength > 0)
                        FillInvoiceDetails(txtInvoiceID.Tag.ToString());
                }
                else
                    MessageBox.Show("Please Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
                if (txtCustomerID.Tag != null && txtCustomerID.Text.Length > 0)
                    FillDetailsCustomer(txtCustomerID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CompanyBankAccount(ref TextBox txtBox, ref TextBox txtBox2, ref TextBox txtBox3)
        {
            try
            {
                clsSearch.SearchMaster_CompanyAccount(ref txtBox, "", "");
                if (txtBox.Tag != null && txtBox.TextLength > 0)
                    FillCompanyAccountDetails(txtBox.Tag.ToString(), ref txtBox2, ref txtBox3);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerBankAccount(ref TextBox txtBox, ref TextBox txtBox2, ref TextBox txtBox3)
        {
            try
            {
                if (CheckValiditeCustomer())
                {
                    clsSearch.Search_TransactionCustomerBankAccount(ref txtBox, txtCustomerID.Tag.ToString());
                    if (txtBox.Tag != null && txtBox.TextLength > 0)
                        FillBankAccountDetails(txtCustomerID.Tag.ToString(), txtBox.Tag.ToString(), ref txtBox2, ref txtBox3);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Bank(ref TextBox txtBox)
        {
            try
            {
                clsSearch.Search_Bank(ref txtBox);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Branch(ref TextBox txtBox, string sBankID)
        {
            try
            {
                if (sBankID != null && sBankID.Length > 0)
                    clsSearch.Search_BankBranch(ref txtBox, sBankID);
                else
                    MessageBox.Show("Please Enter Select the Bank Name First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Currency()
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
        private void Search_SalesNoteType()
        {
            try
            {
                clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
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
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                if (CheckValidity_EmptyField())
                {
                    if (CheckValidity_Number())
                    {
                        if (CheckValidity_ZeroNumber())
                        {
                            if (CheckValidity_InvoiceCurencyRate())
                            {
                                if (CheckValidity_ChequeNo())
                                {
                                    if (CheckValidity_Posting())// need to rewrite
                                    {
                                        if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, txtCustomerID.Tag.ToString()))
                                        {
                                     
                                            if (clsMethods_GL.CheckValidity_FinancialYear(dtpReceiptDate.Value.Date))
                                                bStatus = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            ValidateEmptyForeignKey();

            //var x = oData.CheckValidity_BookNo_Receipt(txtPageNo.Text, txtSalesExecutiveID.Tag.ToString(), txtReceiptID.Text, IsUpdate);
            //if (!x.IsSuccess)
            //{ 
            //    MessageBox.Show(x.OutMsg);
            //    return false;
            //}

            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;

            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsConfig.bReceipt_isCollectorMandatory)
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtCollector1, "Collector 1"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCollector2, "Collector 2"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtCollector3, "Collector 3"))
                            {
                                if (clsValidate.ValidateTextBox_EmptyValue(txtCollector4, "Collector 4"))
                                {
                                    if (clsValidate.ValidateTextBox_EmptyValue(txtPageNo, "Page No"))
                                    {
                                        bStatus = true;
                                    }
                                }
                            }
                        }
                    }
                        
                        bStatus = true;

                }
                else
                    bStatus = true;
            }

            return bStatus;
        }
        private bool CheckValidity_Number()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(lblTotalAmount.Text.Trim()))
                {
                    strMessage += "\n Total Amount";
                    bStatus = false;
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
        private bool CheckValidity_ZeroNumber()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isValueZero(lblTotalAmount.Text.Trim()))
                {
                    strMessage += "\n Total Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show("Receipt total cannot be zero (0) ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckValidity_InvoiceCurencyRate()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                string sInvoiceID = "";
                decimal dAmount = 0;

                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                    if (sInvoiceID != "default")
                    {
                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                        if (oInvoice != null && oInvoice.Invoice_ID != "default")
                        {
                            if (dAmount != 0)
                            {
                                if (oInvoice.CurrencyRate != dAmount)
                                {
                                    strMessage = "Different Currency Rate Invoices are having in this Receipt ";
                                    bStatus = false;
                                }
                            }
                            else
                                dAmount = oInvoice.CurrencyRate;
                        }
                    }
                }

                if (IsUpdate)
                {
                    if (dgvInvoice.Rows.Count > 0)
                    {
                        if (txtReceiptID.Text != "" || txtReceiptID.Tag != null)
                        {
                            tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(txtReceiptID.Text);
                            if (oReceipt != null && oReceipt.Receipt_ID != "default")
                            {
                                if (dAmount != oReceipt.CurrencyRate)
                                {
                                    bStatus = false;
                                    strMessage = "Invoice Currency Rates are not matching with Currency rate in the Receipt ";
                                }
                            }
                        }
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
        private bool CheckValidity_ChequeNo()
        {
            bool bIsValied = true;
            int iCount = 0;
            string sAccNo = "", sChequeNo = "";

            bool isGridOk = true;

            try
            {
                string sAccNo_Or_Bank = "AccountNo";
                if (!clsConfig.bRecipt_Validate_AccountNo)
                    sAccNo_Or_Bank = "BankID";

                #region validation for duplicate cheques In Grid
                foreach (DataGridViewRow row in dgvCheq.Rows)
                {
                    iCount = 0;
                    string sAccountNo = clsValidate.ValidateGridValue(dgvCheq, sAccNo_Or_Bank, row.Index, "default");
                    string sTempChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "default");
                    string sTempCode = (sAccountNo + sTempChequeNo).Trim();

                    #region Internal Validation
                    foreach (DataGridViewRow gRow in dgvCheq.Rows)
                    {
                        if (row.Index == gRow.Index)
                            continue;

                        string GAccountNo = clsValidate.ValidateGridValue(dgvCheq, sAccNo_Or_Bank, gRow.Index, "default");
                        string sGCheque = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", gRow.Index, "default");
                        string sGCode = (GAccountNo + sGCheque).Trim();

                        if (sTempCode == sGCode)
                            iCount++;
                    }
                    #endregion

                    if (iCount > 1)
                    {
                        bIsValied = false;
                        MessageBox.Show("Cheque No is duplicating in the Grid.......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        isGridOk = false;
                        break;
                    }
                }
                #endregion

                #region validation for duplicate cheques In Database
                if (isGridOk)
                {
                    foreach (DataGridViewRow row in dgvCheq.Rows)
                    {
                        iCount = 0;
                        sAccNo = clsValidate.ValidateGridValue(dgvCheq, sAccNo_Or_Bank, row.Index, "default");
                        sChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "default");

                        foreach (tbl_bpsChequeRegister oChequeReg in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted))//filter cheques only
                        {
                            if (oChequeReg.ChequeNumber == sChequeNo)
                            {
                                if (IsUpdate)
                                {
                                    if (txtReceiptID.Text == oChequeReg.Receipt_ID)
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
                        }

                        if (iCount > 0)
                        {
                            bIsValied = false;
                            MessageBox.Show("This Cheque No is already in the System.......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                bIsValied = false;
                SEACCException.Show(ex);
            }
            return bIsValied;
        }
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtAccountID);
            clsCommon.ValidateForeignKey(ref txtInvoiceID);
            clsCommon.ValidateForeignKey(ref txtInvoiceID);
            clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
            clsCommon.ValidateForeignKey(ref txtSalesNoteType);
            clsCommon.ValidateForeignKey(ref txtOrderRefNo);
            clsCommon.ValidateForeignKey(ref txtCollector1);
            clsCommon.ValidateForeignKey(ref txtCollector2);
            clsCommon.ValidateForeignKey(ref txtCollector3);
            clsCommon.ValidateForeignKey(ref txtCollector4);
        }
        private bool CheckValidity_ChequeEmptyField()
        {
            bool bStatus = false;

            bool bStatus_AccNo = true;
            if (clsConfig.bRecipt_Validate_AccountNo)
            {
                if (!clsValidate.ValidateTextBox_EmptyValue(txtAccountID, "Bank Account"))
                    bStatus_AccNo = false;
            }

            if (bStatus_AccNo)
            {

                if (clsValidate.ValidateTextBox_EmptyValue(txtBankID, "Bank"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtChequeTypeID, "Cheque Type"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtChequeNo, "Cheque Number"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtAmount, "Cheque Amount"))
                                bStatus = true;
                        }
                    }
                }
            }

            return bStatus;
        }
        private bool CheckValidity_CardEmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateComboBox_Value(cmbCrdType, "Card Type"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtCrdBank, "Card Bank"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtCrdLastDigits, "Card Last Four Digits"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtCrdName, "Card Owner Name"))
                            {
                                if (clsValidate.ValidateTextBox_EmptyValue(txtCrdAmount, "Card Amount"))
                                    bStatus = true;
                            }
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_BankTransferEmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtBTAccountNo, "Bank Account"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtBTBank, "Bank"))
                    {
                        if (clsValidate.ValidateComboBox_Value(cmbBTType, "Bank Transfer Type"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtBTAmount, "Bank Transfer Amount"))
                                bStatus = true;
                        }
                    }
                }
            }
            return bStatus;
        }
        #endregion

        #region Check Validity Printing
        private bool CheckValidity_Printing(int iPrintCount)
        {
            bool bOk = true;
            try
            {
                if (iPrintCount > 0)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bOk;
        }
        #endregion

        #region Check Validity Receipt Date and Cheque Date validity
        private bool CheckValidity_ReceptDateAndChequeDate()
        {
            bool isValid = false;
            try
            {
                if (clsConfig.bEnableReceiptDateAndChequeDateValidater)
                {
                    if (dtpReceiptDate.Value.Date <= dtpChequeDate.Value.Date)
                        isValid = true;
                    else
                    {
                        isValid = false;
                        MessageBox.Show("Cheque Date can't be less than the Receipt Date......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    isValid = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return isValid;
        }
        #endregion

        #region Check Validity Dependencies
        private bool CheckValidity_Dependancies(string sReceiptId)
        {
            bool Status = true, bCashDeposited = false;
            string sDepositedCheques = "", sBankTransfers = "", sCard = "", sICTID = "";

            try
            {
                foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByReceipt_ID(sReceiptId).Where(p => p.ChequeRegister_ID != "default"))
                {
                    #region Cash
                    if (detail.PaymentMethod_ID == (int)PaymentMethod.Cash)
                    {
                        if (detail.IsDepositted)
                        {
                            Status = false;
                            bCashDeposited = true;
                        }
                    }
                    #endregion
                    #region Cheque
                    else if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                    {
                        if (detail.IsDepositted)
                        {
                            Status = false;
                            sDepositedCheques += (sDepositedCheques != "" ? " | " : "") + detail.ChequeNumber;
                        }
                    }
                    #endregion
                    #region Bank_Transfer
                    else if (detail.PaymentMethod_ID == (int)PaymentMethod.Bank_Transfer)
                    {
                        if (detail.IsReconcilied)
                        {
                            Status = false;
                            sBankTransfers += (sBankTransfers != "" ? " | " : "") + detail.TransferRefNo;
                        }
                    }
                    #endregion
                    #region Card
                    else if (detail.PaymentMethod_ID == (int)PaymentMethod.Card)
                    {
                        if (detail.IsDepositted)
                        {
                            Status = false;
                            sCard += (sCard != "" ? " | " : "") + detail.ChequeRegister_ID;
                        }
                    }
                    #endregion

                }

                if (Status)
                    foreach (tbl_bpsDebitNote oDBN in tbl_bpsDebitNote.SelectAll().Where(p => p.ReceiptNoteID == sReceiptId && !p.IsDeleted))
                    {
                        Status = false;
                        sICTID = oDBN.DebitNote_ID;
                        break;
                    }

                if (!Status)
                {
                    string sMsg = "Record Is Locked!";
                    if (sDepositedCheques != "")
                        sMsg += "\n\nFollowing Cheque(s) already deposited or Locked\n" + sDepositedCheques;
                    if (sBankTransfers != "")
                        sMsg += "\n\nFollowing Bank trnsfer(s) already deposited\n" + sBankTransfers;
                    if (sCard != "")
                        sMsg += "\n\nFollowing Card Transaction(s) already deposited\n" + sCard;
                    if (bCashDeposited)
                        sMsg += "\n\nCash already deposited\n";
                    if (sICTID != "")
                        sMsg += "\n\nThis Receipt has assigned Inter Company Transfer Notes";

                    MessageBox.Show(sMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return Status;
        }
        #endregion

        #region Validate Customer
        private bool CheckValiditeCustomer()
        {
            bool rtn = true;
            if (txtCustomerID.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Customer Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
            }
            return rtn;
        }
        #endregion

        #region Function Validity
        private bool CheckFunctionValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtCustomerID.Tag != null || txtCustomerID.Tag != "")
                {
                    foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString()).Where(p => !p.IsDeleted))
                    {
                        if (detail.ChequeNumber == txtChequeNo.Text.Trim() && !IsSelectedChequeGridRow && detail.Bank_ID != txtBankID.Tag.ToString())
                        {
                            strMessage = "This Cheque is Already Registered Before";
                            bStatus = false;
                        }
                    }

                    foreach (DataGridViewRow row in dgvCheq.Rows)
                    {
                        string sBank_ID = clsValidate.ValidateGridValue(dgvCheq, "BankID", row.Index, "").ToString();
                        string sChequeNo = clsValidate.ValidateGridValue(dgvCheq, "ChequeNo", row.Index, "").ToString();

                        if (sBank_ID == txtBankID.Tag.ToString() && sChequeNo == txtChequeNo.Text && !IsSelectedChequeGridRow)
                        {
                            strMessage += "\n" + " You Cannot Enter Same Account Number And Cheque Number ";
                            bStatus = false;
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
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Invoice Validity
        private bool CheckInvoiceValidity(string sInvID)
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                foreach (DataGridViewRow row in dgvInvoice.Rows)
                {
                    if (clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "").ToString() == sInvID.Trim())
                    {
                        strMessage += "\n" + "You have already entered this invoice  " + sInvID;
                        bStatus = false;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Posting
        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            try
            {
                if (clsConfig.bAutoPostingEnable)
                {
                    #region Credit Account validity
                    bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                    #endregion

                    #region Debit Account validity
                    bool bSlotStatus_Cash = clsMethods_GL.CheckAccountLink(AccSlot.PartPaymentReceipt_Cash, false);
                    bool bSlotStatus_Cheque = clsMethods_GL.CheckAccountLink(AccSlot.PartPaymentReceipt_Cheque, false);
                    bool bSlotStatus_ADVCash = clsMethods_GL.CheckAccountLink(AccSlot.AdvanceReceipt_Cash, false);
                    bool bSlotStatus_ADVCheque = clsMethods_GL.CheckAccountLink(AccSlot.AdvanceReceipt_Cheque, false);
                    bool bSlotStatus_Card = clsMethods_GL.CheckAccountLink(AccSlot.Receipt_CreditCard, false);

                    #region Bank Account
                    List<string> Accounts = new List<string>();
                    bool bSlotStatus_Bank = true;
                    foreach (DataGridViewRow row in dgvBankTransfer.Rows)
                    {
                        string sAccountNo = clsValidate.ValidateGridValue(dgvBankTransfer, "BTAccountNo", row.Index, "");
                        Accounts.Add(sAccountNo);
                    }
                    foreach (string sAcc in Accounts.Distinct())
                    {
                        bSlotStatus_Bank = clsMethods_GL.CheckAccountLink_Bank(sAcc);
                        if (!bSlotStatus_Bank)
                            break;
                    }
                    #endregion
                    #endregion

                    if (bSlotStatus_Customer && bSlotStatus_Cash && bSlotStatus_Cheque && bSlotStatus_ADVCash && bSlotStatus_ADVCheque && bSlotStatus_Card && bSlotStatus_Bank)
                        bStatus = true;
                }
                else
                    bStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            if (txtReceiptID.TextLength > 0 && txtReceiptID.Text != "<Auto Generate>")
            {
                #region New Code
                try
                {
                    //update receipt
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCreateUserID = "", sCheckedUser = "", sCheckedUserID = "", sApprovedUser = "", sApprovedUserID = "", sDuplicateCopy = "";
                    string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sReportTitle = "", sDeleted = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true, bisCanceled = false;
                    string sReportID = "";
                    if (IsSalesReceipt)
                        sReportID = clsAutocode.getReportID(enum_ReportName.NP_SalesReceipt);
                    else
                        sReportID = clsAutocode.getReportID(enum_ReportName.NP_InterimReceipt);

                    if (clsHelpMethods_Local.GetReportPath(sReportID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                    {
                        tbl_bpsReceipt receipt = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                        if (receipt != null)
                        {
                            if (receipt.PrintCount > 0)
                            {
                                if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 1101, true, false))
                                {
                                    MessageBox.Show("Access Denied ! \n\nUser does not have access to Print duplicates, Please get permission from the system administrator ");
                                    return;
                                }
                            }
                            //Write Audit Trial Log
                            clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.Receipt), receipt.Receipt_ID);
                            if (!bIsDraft)
                            {
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintReceipt)
                                {
                                    if (!receipt.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the Receipt Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion

                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintReceipt)
                                {
                                    if (!receipt.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the Receipt Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone && bCheckingDone)
                            {
                                glb_dts_sasReceiptAllocation.Clear();

                                #region Validate Duplicate Print
                                #region old
                                //if (receipt.PrintCount > 0) // if already printed before
                                //{
                                //    sDuplicateCopy = "Duplicate Copy";
                                //    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                                //    {
                                //        bOkToPrint = true;
                                //        if (chkPrintOriginal.Checked)
                                //            sDuplicateCopy = "";
                                //    }
                                //    else
                                //    {
                                //        frmSetApproved login = new frmSetApproved();
                                //        login.iFormID = iFormID;
                                //        login.ShowDialog();
                                //        if (frmSetApproved.bChecked)
                                //        {
                                //            bOkToPrint = true;
                                //            if (chkPrintOriginal.Checked)
                                //                sDuplicateCopy = "";
                                //        }
                                //    }
                                //}
                                //else
                                //    bOkToPrint = true; 
                                #endregion

                                if (!bIsDraft)
                                {
                                    //if (receipt.PrintCount > 0) // if already printed before
                                    //{
                                    //sDuplicateCopy = "Duplicate Copy " + receipt.PrintCount;
                                    sDuplicateCopy = receipt.PrintCount > 0 ? "Duplicate Copy " + receipt.PrintCount : "";
                                    receipt.PrintCount++;

                                    if (chkPrintOriginal.Checked)
                                    {
                                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                                        {
                                            bOkToPrint = true;
                                            if (bOkToPrint)
                                                sDuplicateCopy = "";
                                        }
                                        else
                                        {
                                            frmSetApproved login = new frmSetApproved();
                                            login.iFormID = iFormID;
                                            login.userID = clsSecurity.UserIDLoged;
                                            login.ShowDialog();
                                            if (frmSetApproved.bChecked)
                                            {
                                                bOkToPrint = true;
                                                if (bOkToPrint)
                                                    sDuplicateCopy = "";
                                            }
                                        }
                                    }
                                    else
                                        bOkToPrint = true;
                                    //}
                                    //else
                                    //    bOkToPrint = true;
                                }
                                #endregion

                                if (bApprovalDone && bCheckingDone)
                                {
                                    bOkToPrint = true;
                                }

                                #region Print The Doc
                                if (bOkToPrint)
                                {
                                    #region User Details
                                    sCreateUser = "[ " + clsGenaralName.getName_User(receipt.CreateUser_ID) + " ] [ " + receipt.DateCreate.ToString("yyyy-MMM-dd") + " ]";
                                    sCreateUserID = "[ " + receipt.CreateUser_ID + " ] [ " + receipt.DateCreate.ToString("yyyy-MMM-dd") + " ]";
                                    if (receipt.CheckedUser_ID != "default")
                                    {
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(receipt.CheckedUser_ID) + " ] [ " + receipt.DateChecked.ToString("yyyy-MMM-dd") + " ]";
                                        sCheckedUserID = "[ " + receipt.CheckedUser_ID + " ] [ " + receipt.DateChecked.ToString("yyyy-MMM-dd") + " ]";
                                    }
                                    if (receipt.ApprovedUser_ID != "default")
                                    {
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(receipt.ApprovedUser_ID) + " ] [ " + receipt.DateApproved.ToString("yyyy-MMM-dd") + " ]";
                                        sApprovedUserID = "[ " + receipt.ApprovedUser_ID + " ] [ " + receipt.DateApproved.ToString("yyyy-MMM-dd") + " ]";
                                    }
                                    #endregion

                                    receipt.DatePrinted = clsSecurity.getServerDateTime();
                                    receipt.PrintedUser_ID = clsSecurity.UserIDLoged;
                                    receipt.Update();

                                    #region Fill Details
                                    string sCustomerName = string.Empty, sAddressRegister = string.Empty, sSalesRep = string.Empty, sTelephone = string.Empty, sFax = string.Empty, sEmployee_ID = string.Empty, sCurrencyCode = string.Empty;

                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(receipt.Customer_ID);
                                    if (oCustomer != null)
                                    {
                                        sCustomerName = oCustomer.CustomerName;
                                        sAddressRegister = oCustomer.AddressRegister;
                                        sTelephone = oCustomer.Telephone;
                                        sFax = oCustomer.Fax;
                                        sSalesRep = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                                    }

                                    tbl_zOrderRefNo oOrderRefNo = tbl_zOrderRefNo.Select(receipt.OrderRefNo_ID);
                                    if (oOrderRefNo != null)
                                        sEmployee_ID = oOrderRefNo.Employee_ID;

                                    tbl_zCurrency oCurrency = tbl_zCurrency.Select(receipt.Currency_ID);
                                    if (oCurrency != null)
                                        sCurrencyCode = oCurrency.CurrencyCode;

                                    if (rdoPartPayment.Checked)
                                        sReportTitle = "SALES RECEIPT";
                                    else if (rdoAdvancePayment.Checked)
                                        sReportTitle = "Advanced Receipt";

                                    foreach (tbl_sasInvoice_Sattled oInvSettled in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(receipt.Receipt_ID).Where(p => !p.IsAdvancePayment && !p.IsOverPayment))
                                    {
                                        string sChequRegisterID = string.Empty;
                                        DateTime dtmInvoiceDate = clsSecurity.getServerDateTime();

                                        tbl_bpsChequeRegister oChqRegister = tbl_bpsChequeRegister.Select(oInvSettled.ChequeRegister_ID);
                                        if (oChqRegister != null)
                                            sChequRegisterID = oChqRegister.ChequeNumber;

                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oInvSettled.Invoice_ID);
                                        if (oInvoice != null)
                                            dtmInvoiceDate = oInvoice.InvoiceDate;

                                        glb_dts_sasReceiptAllocation.dt_sasSalesInvoiceSettled.Adddt_sasSalesInvoiceSettledRow(oInvSettled.Settled_ID, oInvSettled.Invoice_ID, receipt.Receipt_ID,
                                            oInvSettled.ChequeRegister_ID, oInvSettled.CreditNote_ID, oInvSettled.AllocationDate, oInvSettled.SattledAmount, oInvSettled.IsDebit, sChequRegisterID,
                                            dtmInvoiceDate, oInvSettled.IsAdvancePayment, oInvSettled.IsOverPayment, oInvSettled.AllocationID);
                                    }

                                    #region Cheque Register
                                    decimal dCash = 0, dCheque = 0, dBankTransfer = 0, dCard = 0;
                                    foreach (tbl_bpsChequeRegister oChq in tbl_bpsChequeRegister.SelectAllByReceipt_ID(receipt.Receipt_ID))
                                    {
                                        switch (oChq.PaymentMethod_ID)
                                        {
                                            case (int)PaymentMethod.Cash:
                                                dCash += oChq.Amount;
                                                break;
                                            case (int)PaymentMethod.Cheque:
                                                dCheque += oChq.Amount;
                                                break;
                                            case (int)PaymentMethod.Card:
                                                dCard += oChq.Amount;
                                                break;
                                            case (int)PaymentMethod.Bank_Transfer:
                                                dBankTransfer += oChq.Amount;
                                                break;
                                        }
                                        glb_dts_sasReceiptAllocation.dt_sasSalesReceiptDetails.Adddt_sasSalesReceiptDetailsRow(receipt.Receipt_ID, oChq.AccountNumber,
                                            oChq.Bank_ID, clsGenaralName.getName_Bank(oChq.Bank_ID), oChq.Branch_ID, oChq.Branch_ID,
                                            oChq.ChequeNumber, oChq.DateCheque, oChq.Amount, clsGenaralName.getName_ChequeType(oChq.ChequeType_ID), oChq.ChequeStatus_ID);
                                    }
                                    #endregion

                                    glb_dts_sasReceiptAllocation.dt_sasSalesReceiptHeader.Adddt_sasSalesReceiptHeaderRow(receipt.Receipt_ID, receipt.ReceiptDate, receipt.Remark,
                                        sCustomerName, sAddressRegister, sSalesRep, dCash, dCheque, dCard, dBankTransfer, receipt.TotalAmount, sTelephone, sFax,
                                        oCustomer.Customer_ID, sEmployee_ID, receipt.InvoiceList,
                                        receipt.DateCreate, receipt.CurrencyRate, sCurrencyCode, receipt.IsDeleted, receipt.IsSalesReceipt, receipt.IsAdvance);
                                    #endregion

                                    #region Invoice List, Cheque No n Date Add to Formula Fields
                                    List<string> sDateLst = new List<string>();
                                    List<string> sChequNoLst = new List<string>();
                                    List<string> sInvoiceNoLst = new List<string>();
                                    string sDate = "", sChequNo = "", sinvoiceno = "";

                                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(receipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                    {
                                        sDateLst.Add(clsFormatter.FormatDate_SL(oCheque.DateCheque));
                                        sChequNoLst.Add(oCheque.ChequeNumber);
                                    }

                                    sDateLst.RemoveAll(p => p == "" || p == null);
                                    sChequNoLst.RemoveAll(p => p == "" || p == null);

                                    sChequNo = string.Join(",", sChequNoLst);
                                    sDate = string.Join(",", sDateLst);

                                    var oinvoice = tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(txtReceiptID.Text.Trim()).GroupBy(cm => new { cm.Invoice_ID }, (key, group) => new { Invoice_ID = key.Invoice_ID });
                                    foreach (var oinv in oinvoice)
                                    {
                                        sInvoiceNoLst.Add(oinv.Invoice_ID);
                                    }
                                    sInvoiceNoLst.RemoveAll(p => p == "" || p == null);
                                    sinvoiceno = string.Join(",", sInvoiceNoLst);
                                    #endregion

                                    #region Fill Report
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo ", clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo()), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.fncsetstring(clsCommon.getCompanyVAT()), true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", receipt.IsDeleted ? "CANCELLED" : "", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                    //glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? clsCommon.fncsetstring("DRAFT") : "", true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ChequeNo", clsCommon.fncsetstring(sChequNo), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ChequeDate", clsCommon.fncsetstring(sDate), true);

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("InvoiceId", clsCommon.fncsetstring(sinvoiceno), true);

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

                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo ", "", true);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true);
                                        }
                                    }
                                    glb_dts_sasReceiptAllocation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, IsSalesReceipt ? sReportTitle : "Interim Receipt", "", "", clsSecurity.UserNameLoged, "");
                                    #endregion

                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dts_sasReceiptAllocation, glb_dtsReportExport.dt_rptParameter, sReportID);
                                    #endregion
                                }
                                #endregion
                            }
                        }
           
                        email.createEmail_Receipt(txtReceiptID.Text.Trim(), enum_Alerts.ReceiptPrinted);
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
                #endregion
            }
            else
                MessageBox.Show("Please Select the Customer and Receipt Number To Print the Customer Receipt", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Calculation
        #region Calculate Invoice Total
        private void CalculateInvoiceTotal()
        {
            decimal dAllocatedAmount = 0, dInvoiceAmount = 0;
            foreach (DataGridViewRow row in dgvInvoice.Rows)
            {
                dInvoiceAmount += clsValidate.ValidateGridValue(dgvInvoice, "InvoiceAmount", row.Index, decimal.Parse("0.00"));
                dAllocatedAmount += clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", row.Index, decimal.Parse("0.00"));
            }
            txtTotalAllocated.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAllocatedAmount);
            txtBalanceAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dInvoiceAmount);
        }
        #endregion

        #region Calculate Cash Total
        private void CalculateCashAmount()
        {
            decimal dCashAmount = 0;
            if (decimal.TryParse(txtCashAmount.Text, out dCashAmount))
                expanderCash.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dCashAmount);

            CalculateTotalAmount();
        }
        #endregion

        #region Calculate Cheques Total
        private void CalculateChequesAmount()
        {
            decimal dCheque = 0;
            foreach (DataGridViewRow row in dgvCheq.Rows)
            {
                dCheque += clsValidate.ValidateGridValue(dgvCheq, "Amount", row.Index, decimal.Parse("0.00"));
            }
            expanderCheque.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dCheque);

            CalculateTotalAmount();
        }
        #endregion

        #region Calculate Card Total
        private void CalculateCardAmount()
        {
            decimal dCardAmount = 0;
            foreach (DataGridViewRow row in dgvCard.Rows)
            {
                dCardAmount += clsValidate.ValidateGridValue(dgvCard, "crdAmount", row.Index, decimal.Parse("0.00"));
            }
            expanderCard.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dCardAmount);

            CalculateTotalAmount();
        }
        #endregion

        #region Calculate Bank Transfer Total
        private void CalculateBankTransferAmount()
        {
            decimal dBankTransferAmount = 0;
            foreach (DataGridViewRow row in dgvBankTransfer.Rows)
            {
                dBankTransferAmount += clsValidate.ValidateGridValue(dgvBankTransfer, "BTAmount", row.Index, decimal.Parse("0.00"));
            }
            expanderBankTransfer.DisplayAmount = clsFormatter.FormatToCurrecyWithThousendSep(dBankTransferAmount);

            CalculateTotalAmount();
        }
        #endregion

        #region Calculate Grand Total
        private void CalculateTotalAmount()
        {
            decimal dCashAmount = 0, dTotalAmount = 0, dCheque = 0, dCardAmount = 0, dBankTransferAmount = 0;
            try
            {
                if (clsCommon.isCurrency(txtCashAmount.Text.Trim()))
                    dCashAmount += decimal.Parse(txtCashAmount.Text.Trim());

                if (dgvCheq.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvCheq.Rows)
                    {
                        dCheque += clsValidate.ValidateGridValue(dgvCheq, "Amount", row.Index, decimal.Parse("0.00"));
                    }
                }

                if (dgvCard.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvCard.Rows)
                    {
                        dCardAmount += clsValidate.ValidateGridValue(dgvCard, "crdAmount", row.Index, decimal.Parse("0.00"));
                    }
                }

                if (dgvBankTransfer.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvBankTransfer.Rows)
                    {
                        dBankTransferAmount += clsValidate.ValidateGridValue(dgvBankTransfer, "BTAmount", row.Index, decimal.Parse("0.00"));
                    }
                }

                dTotalAmount = dCashAmount + dCheque + dCardAmount + dBankTransferAmount;

                lblTotalAmount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        #region User Checked Approve Details
        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpReceiptDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtReceiptID.Text != null && txtReceiptID.TextLength > 0 && txtReceiptID.Text != "<Auto Generate>")
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

                                        tbl_bpsReceipt objSRN = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                                        if (objSRN != null)
                                        {
                                            objSRN.IsApproved = true;
                                            objSRN.DateApproved = clsSecurity.getServerDateTime();
                                            objSRN.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objSRN.Update();
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpReceiptDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtReceiptID.Text != null && txtReceiptID.TextLength > 0 && txtReceiptID.Text != "<Auto Generate>")
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

                                        tbl_bpsReceipt objSRN = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
                                        if (objSRN != null)
                                        {
                                            objSRN.IsChecked = true;
                                            objSRN.DateChecked = clsSecurity.getServerDateTime();
                                            objSRN.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objSRN.Update();
                                        }
                                    }

                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
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

        #region History
        private void UserHistory()
        {
            try
            {
                if (txtReceiptID.Text != "" || txtReceiptID.Text != "<Auto Generate>")
                {
                    tbl_bpsReceipt detail = tbl_bpsReceipt.Select(txtReceiptID.Text.Trim());
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
        #endregion

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

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void txtCollector2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector2);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCollector3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector3);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtCollector4_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                clsSearch.Search_MasterCollector(ref txtCollector4);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Invoice Settlement
        private void setPaymentAllocation(string sReceiptID, bool bIsCheckByAllocation)
        {
            try
            {
                if (dgvInvoice.Rows.Count > 0)
                {
                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
                    if (oReceipt != null && oReceipt.Receipt_ID != "default")
                    {
                        #region Allocation ID
                        string sAllocationID = "";

                        if (bIsCheckByAllocation)
                            sAllocationID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment));

                        else
                        {
                            if (frm_toolPaymentAllocate.sAllocateCode.Length == 0)
                            {
                                string sFormConfigCode1 = frm_toolPaymentAllocate.bAdvancePayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_AdvancePyament) : frm_toolPaymentAllocate.bPartPayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment) : frm_toolPaymentAllocate.bOverPayment ? clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_OverPayment) : clsAutocode.getFormConfigCode(FormName.ReceiptAllocation_PartPayment);
                                sAllocationID = clsAutocode.getAutoGeneratedCode(sFormConfigCode1);
                            }
                            else
                                sAllocationID = frm_toolPaymentAllocate.sAllocateCode;
                        }
                        #endregion

                        #region Settle Invoices
                        foreach (DataGridViewRow row in dgvInvoice.Rows)
                        {
                            string sInvoiceID = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceID", row.Index, "default");
                            decimal dAmount = clsValidate.ValidateGridValue(dgvInvoice, "InvoiceAmount", row.Index, decimal.Parse("0.0"));
                            decimal AllocationAmount = clsValidate.ValidateGridValue(dgvInvoice, "AllocatedAmount", row.Index, decimal.Parse("0.0"));
                            decimal dAmountToBeSettle = 0;

                            if (IsUpdate)
                            {

                                if (AllocationAmount == 0)
                                    dAmount = 0;
                                else
                                    dAmount += AllocationAmount;
                            }

                            dAmountToBeSettle = (AllocationAmount > 0) ? AllocationAmount : dAmount;

                            foreach (tbl_bpsChequeRegister oPaymentRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted))
                            {
                                dAmountToBeSettle -= clsHelpMethods_Local.AutoSettledInvoiceWithCheque(sInvoiceID, oPaymentRegister.ChequeRegister_ID, dAmountToBeSettle, sAllocationID, frm_toolPaymentAllocate.bAdvancePayment, frm_toolPaymentAllocate.bOverPayment);

                                if (dAmountToBeSettle == 0)
                                    break;
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
        }
        #endregion
    }
}