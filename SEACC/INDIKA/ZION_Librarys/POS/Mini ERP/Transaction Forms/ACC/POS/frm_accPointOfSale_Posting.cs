using DataTire;
using Digiteq_Logic;
//using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEACC_Functions;

namespace Digiteq
{
    public partial class frm_accPointOfSale_Posting : MettroForm
    {
        #region Class Variables
        //form manage
        public int iFormID;
        public bool bNoAccess;

        DataTable dtPOS_Transaction = new DataTable();
        #endregion

        #region Form Load
        public frm_accPointOfSale_Posting()
        {
            #region Initialize Form
            iFormID = clsSecurity.getFormID(FormName.POS_TransactionLedgerPosting);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
            #endregion

            #region Initialize Data Table
            dtPOS_Transaction.Columns.Add("LineNo");
            dtPOS_Transaction.Columns.Add("Tx_Date");
            dtPOS_Transaction.Columns.Add("Tx_Index");
            dtPOS_Transaction.Columns.Add("Tx_ID");
            dtPOS_Transaction.Columns.Add("Tx_Mode");
            dtPOS_Transaction.Columns.Add("Customer_ID");
            dtPOS_Transaction.Columns.Add("Customer_Name");
            dtPOS_Transaction.Columns.Add("Company_BranchID");
            dtPOS_Transaction.Columns.Add("Company_BranchName");
            dtPOS_Transaction.Columns.Add("NetSales");
            dtPOS_Transaction.Columns.Add("NBT");
            dtPOS_Transaction.Columns.Add("VAT");
            dtPOS_Transaction.Columns.Add("Sales_Total");
            dtPOS_Transaction.Columns.Add("Invoice_Return_Total");
            dtPOS_Transaction.Columns.Add("GV_sales");
            dtPOS_Transaction.Columns.Add("AdvancePayment");
            dtPOS_Transaction.Columns.Add("Tx_PM_Cash");
            dtPOS_Transaction.Columns.Add("Tx_PM_Card");
            dtPOS_Transaction.Columns.Add("Tx_PM_Cheque");
            dtPOS_Transaction.Columns.Add("Tx_PM_GV");
            dtPOS_Transaction.Columns.Add("Tx_PM_AdvSettlement");
            dtPOS_Transaction.Columns.Add("Tx_PM_CRN");
            dtPOS_Transaction.Columns.Add("Tx_SalesEx_CRN");
            #endregion

            #region Initialize Data Grid
            dgvPOS_LedgerPosting.AutoGenerateColumns = false;
            #endregion

            ClearFields();
            RefreshGrid();
            AddTotals();
        }
        #endregion

        #region Action Button

        #region Ledger Posting Button
        private void btnLedgerPosting_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (cmbComBranch.SelectedItem != null)
                {
                    string sCompanyBranchID = ((ComboBoxItem)cmbComBranch.SelectedItem).Value;
                    string sBranchSalesAcc_ID = "", sBranchCreditCardControlAcc_ID = "", sBranchCashInHandAcc_ID = "", sBranchChequeInHandAcc_ID = "", sBranchAdvanceControlAcc_ID = "", sBranchCRNControlAcc_ID = "";

                    tbl_accGLMaster_CompanyBranch oComapnyBranch_Acc = tbl_accGLMaster_CompanyBranch.Select(sCompanyBranchID);
                    if (oComapnyBranch_Acc != null)
                    {
                        sBranchSalesAcc_ID = oComapnyBranch_Acc.Sales_Acc;
                        sBranchCashInHandAcc_ID = oComapnyBranch_Acc.CashInHand_Acc;
                        sBranchCreditCardControlAcc_ID = oComapnyBranch_Acc.CreditCard_ControlAcc;
                        sBranchChequeInHandAcc_ID = oComapnyBranch_Acc.ChequeInHand_Acc;
                        sBranchAdvanceControlAcc_ID = oComapnyBranch_Acc.Advance_ControlAcc;
                        sBranchCRNControlAcc_ID = oComapnyBranch_Acc.CreditNote_ControlAcc;

                        if (clsMethods_GL.CheckAccountValidity(sBranchSalesAcc_ID) &&
                            clsMethods_GL.CheckAccountValidity(sBranchCashInHandAcc_ID) &&
                            clsMethods_GL.CheckAccountValidity(sBranchCreditCardControlAcc_ID) &&
                            clsMethods_GL.CheckAccountValidity(sBranchChequeInHandAcc_ID) &&
                            clsMethods_GL.CheckAccountValidity(sBranchAdvanceControlAcc_ID) &&
                            clsMethods_GL.CheckAccountValidity(sBranchCRNControlAcc_ID))
                        {
                            if (CheckValidity_Customer_GL_Code())
                            {
                                foreach (DataRow row in dtPOS_Transaction.Rows)
                                {
                                    #region Transaction Row Variables
                                    int iTransaction_Index = clsValidate.ValidateRowValue(row, "Tx_Index", -1);//
                                    string sTx_Mode = clsValidate.ValidateRowValue(row, "Tx_Mode", "");
                                    decimal dNetSales = clsValidate.ValidateRowValue(row, "NetSales", 0m);//With out Tax
                                    decimal dNBT = clsValidate.ValidateRowValue(row, "NBT", 0m);
                                    decimal dVAT = clsValidate.ValidateRowValue(row, "VAT", 0m);
                                    decimal dSales_Total = clsValidate.ValidateRowValue(row, "Sales_Total", 0m);
                                    decimal dInvoice_Return_Total = clsValidate.ValidateRowValue(row, "Invoice_Return_Total", 0m);
                                    decimal dGV_sales = clsValidate.ValidateRowValue(row, "GV_sales", 0m);
                                    decimal dAdvancePayment = clsValidate.ValidateRowValue(row, "AdvancePayment", 0m);
                                    decimal dTx_PM_Cash = clsValidate.ValidateRowValue(row, "Tx_PM_Cash", 0m);
                                    decimal dTx_PM_Card = clsValidate.ValidateRowValue(row, "Tx_PM_Card", 0m);
                                    decimal dTx_PM_Cheque = clsValidate.ValidateRowValue(row, "Tx_PM_Cheque", 0m);
                                    decimal dTx_PM_GV = clsValidate.ValidateRowValue(row, "Tx_PM_GV", 0m);
                                    decimal dTx_PM_AdvSettlement = clsValidate.ValidateRowValue(row, "Tx_PM_AdvSettlement", 0m);
                                    decimal dTx_PM_CRN = clsValidate.ValidateRowValue(row, "Tx_PM_CRN", 0m);
                                    #endregion

                                    switch (sTx_Mode)
                                    {
                                        case "ADVANCE":
                                            tbl_posAdvanceReceived oPoS_Adv = tbl_posAdvanceReceived.Select(iTransaction_Index);
                                            if (oPoS_Adv != null && oPoS_Adv.AdvanceReceived_Index > 0)
                                            {
                                                string sCustomer_sale = clsGenaralName.getName_Customer(oPoS_Adv.Customer_ID);
                                                string sRemarks =
                                                        "POS" +
                                                        " | Date <" + (oPoS_Adv.PaymentDate.ToString(cls_Formater.Format_Date2)) + "/>" +
                                                        " | Adv payment No: <" + oPoS_Adv.AdvanceReceived_ID + "/>" +
                                                        " | Customer Name <" + oPoS_Adv.Customer_ID + " - " + sCustomer_sale + "/>" +
                                                        " | Contact No: <" + clsGenaralName.getName_CustomerTelephone(oPoS_Adv.Customer_ID) + "/>" +
                                                        " | Branch Name <" + clsGenaralName.getName_CompanyBranchMaster(oPoS_Adv.CompanyBranchID) + "/>";

                                                #region Posting for Advance (Transaction)
                                                int iSlotID_sale = clsAutocode.getAccSlotID(AccSlot.POS_Adavnce);
                                                string sGLPostingID_sale = clsMethods_GL.Update_Primary_TXN(oPoS_Adv.GlPosting_ID, iSlotID_sale, oPoS_Adv.AdvanceReceived_ID, oPoS_Adv.PaymentDate, oPoS_Adv.Customer_ID, "default", oPoS_Adv.Remark);
                                                if (sGLPostingID_sale != "")
                                                {
                                                    int iLineNo = 0;

                                                    //TRADE DEBTOR
                                                    string sAccountCode_Customer = clsMethods_GL.GetAccountCode_Customer(oPoS_Adv.Customer_ID);

                                                    #region Debit Entry

                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,      //Line No 
                                                        sGLPostingID_sale,   //Posting Id 
                                                        iSlotID_sale,        //Slot ID 
                                                        sAccountCode_Customer, //sGL Code
                                                        "default",      //Cost Center 1
                                                        "default",      //Cost Center 2
                                                        oPoS_Adv.Customer_ID, //Customer Id
                                                        "default",      // Supplier Id
                                                        "default",      //Employee Id
                                                        "default",      //Bank Account Id
                                                        "-",            //Cus Sup Emp Name
                                                        oPoS_Adv.AdvanceReceived_ID, //Transaction Id
                                                        oPoS_Adv.AdvanceReceived_ID, //Main Transaction Id
                                                        oPoS_Adv.PaymentDate,//Transaction Date
                                                        sRemarks,     //Remarks
                                                        dAdvancePayment,   //Amount
                                                        false,          // Is Credit
                                                        "",             //Cheque Number
                                                        sCustomer_sale + " - TRADE DEBTOR",      //Narration
                                                        oPoS_Adv.CompanyBranchID   //Company Branch
                                                        );
                                                    #endregion

                                                    #region Credit Entries

                                                    //SALES - S/R
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_sale,
                                                        iSlotID_sale,
                                                        sAccountCode_Customer,
                                                        "default",
                                                        "default",
                                                        oPoS_Adv.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Adv.AdvanceReceived_ID,
                                                        oPoS_Adv.AdvanceReceived_ID,
                                                        oPoS_Adv.PaymentDate,
                                                        sRemarks,
                                                        dAdvancePayment,
                                                        true,
                                                        "",
                                                        sCustomer_sale + " - TRADE DEBTOR",
                                                        oPoS_Adv.CompanyBranchID);
                                                    #endregion

                                                    oPoS_Adv.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                    oPoS_Adv.GlPosting_ID = sGLPostingID_sale;
                                                    oPoS_Adv.Update();
                                                }
                                                #endregion

                                                #region Posting for collection (Settlement)
                                                int iSlotID_collection = clsAutocode.getAccSlotID(AccSlot.POS_Collection);
                                                var oAdvReceipt_First = tbl_posReceipt.SelectAllByAdvanceReceived_Index(oPoS_Adv.AdvanceReceived_Index).FirstOrDefault();
                                                string sOldPosting_ID_Adv = oAdvReceipt_First != null ? oAdvReceipt_First.GlPosting_ID : "default";

                                                string sGLPostingID_collection = clsMethods_GL.Update_Primary_TXN(sOldPosting_ID_Adv, iSlotID_collection, oPoS_Adv.AdvanceReceived_ID, oPoS_Adv.PaymentDate, oPoS_Adv.Customer_ID, "default", oPoS_Adv.Remark);
                                                if (sGLPostingID_collection != "")
                                                {
                                                    int iLineNo = 0;
                                                    string sAccountCode_Customer = clsMethods_GL.GetAccountCode_Customer(oPoS_Adv.Customer_ID);

                                                    #region Debit Entries
                                                    if (dTx_PM_Cash != 0)
                                                    {
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                            iLineNo++,      //Line No 
                                                            sGLPostingID_collection,   //Posting Id 
                                                            iSlotID_collection,        //Slot ID 
                                                            sBranchCashInHandAcc_ID, //sGL Code
                                                            "default",      //Cost Center 1
                                                            "default",      //Cost Center 2
                                                            oPoS_Adv.Customer_ID, //Customer Id
                                                            "default",      // Supplier Id
                                                            "default",      //Employee Id
                                                            "default",      //Bank Account Id
                                                            "-",            //Cus Sup Emp Name
                                                            oPoS_Adv.AdvanceReceived_ID, //Transaction Id
                                                            oPoS_Adv.AdvanceReceived_ID, //Main Transaction Id
                                                            oPoS_Adv.PaymentDate,//Transaction Date
                                                            sRemarks,     //Remarks
                                                            dTx_PM_Cash,    //Amount
                                                            false,          // Is Credit
                                                            "",             //Cheque Number
                                                            "CASH IN HAND - SHOWROOM", //Narration
                                                            oPoS_Adv.CompanyBranchID   //Company Branch
                                                            );
                                                    }
                                                    if (dTx_PM_Card != 0)
                                                    {
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                            iLineNo++,      //Line No 
                                                            sGLPostingID_collection,   //Posting Id 
                                                            iSlotID_collection,        //Slot ID 
                                                            sBranchCreditCardControlAcc_ID, //sGL Code
                                                            "default",      //Cost Center 1
                                                            "default",      //Cost Center 2
                                                            oPoS_Adv.Customer_ID, //Customer Id
                                                            "default",      // Supplier Id
                                                            "default",      //Employee Id
                                                            "default",      //Bank Account Id
                                                            "-",            //Cus Sup Emp Name
                                                            oPoS_Adv.AdvanceReceived_ID, //Transaction Id
                                                            oPoS_Adv.AdvanceReceived_ID, //Main Transaction Id
                                                            oPoS_Adv.PaymentDate,//Transaction Date
                                                            sRemarks,     //Remarks
                                                            dTx_PM_Card,    //Amount
                                                            false,          // Is Credit
                                                            "",             //Cheque Number
                                                            "CREDIT CARD CONTROL A/C", //Narration
                                                            oPoS_Adv.CompanyBranchID   //Company Branch
                                                            );
                                                    }
                                                    if (dTx_PM_Cheque != 0)
                                                    {
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                            iLineNo++,      //Line No 
                                                            sGLPostingID_collection,   //Posting Id 
                                                            iSlotID_collection,        //Slot ID 
                                                            sBranchChequeInHandAcc_ID, //sGL Code
                                                            "default",      //Cost Center 1
                                                            "default",      //Cost Center 2
                                                            oPoS_Adv.Customer_ID, //Customer Id
                                                            "default",      // Supplier Id
                                                            "default",      //Employee Id
                                                            "default",      //Bank Account Id
                                                            "-",            //Cus Sup Emp Name
                                                            oPoS_Adv.AdvanceReceived_ID, //Transaction Id
                                                            oPoS_Adv.AdvanceReceived_ID, //Main Transaction Id
                                                            oPoS_Adv.PaymentDate,//Transaction Date
                                                            sRemarks,     //Remarks
                                                            dTx_PM_Cheque,    //Amount
                                                            false,          //Is Credit
                                                            "",             //Cheque Number
                                                            "CHEQUE IN HAND - SHOWROOM", //Narration
                                                            oPoS_Adv.CompanyBranchID   //Company Branch
                                                            );
                                                    }
                                                    if (dTx_PM_AdvSettlement != 0)
                                                    {
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                            iLineNo++,      //Line No 
                                                            sGLPostingID_collection,   //Posting Id 
                                                            iSlotID_collection,        //Slot ID 
                                                            sBranchAdvanceControlAcc_ID, //sGL Code
                                                            "default",      //Cost Center 1
                                                            "default",      //Cost Center 2
                                                            oPoS_Adv.Customer_ID, //Customer Id
                                                            "default",      // Supplier Id
                                                            "default",      //Employee Id
                                                            "default",      //Bank Account Id
                                                            "-",            //Cus Sup Emp Name
                                                            oPoS_Adv.AdvanceReceived_ID, //Transaction Id
                                                            oPoS_Adv.AdvanceReceived_ID, //Main Transaction Id
                                                            oPoS_Adv.PaymentDate,//Transaction Date
                                                            sRemarks,     //Remarks
                                                            dTx_PM_AdvSettlement,    //Amount
                                                            false,          //Is Credit
                                                            "",             //Cheque Number
                                                            "ADVANCE CONTROL A/C - SHOWROOM ", //Narration
                                                            oPoS_Adv.CompanyBranchID   //Company Branch
                                                            );
                                                    }

                                                    #endregion

                                                    #region Credit Entry
                                                    //Trade Debtor
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_collection,
                                                        iSlotID_collection,
                                                        sBranchAdvanceControlAcc_ID,
                                                        "default",
                                                        "default",
                                                        oPoS_Adv.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Adv.AdvanceReceived_ID,
                                                        oPoS_Adv.AdvanceReceived_ID,
                                                        oPoS_Adv.PaymentDate,
                                                        sRemarks,
                                                        dAdvancePayment,
                                                        true,
                                                        "",
                                                        "ADVANCE CONTROL A/C - SHOWROOM ",
                                                        oPoS_Adv.CompanyBranchID
                                                        );
                                                    #endregion

                                                    foreach (tbl_posReceipt oPosAdvReceipt in tbl_posReceipt.SelectAllByAdvanceReceived_Index(oPoS_Adv.AdvanceReceived_Index))
                                                    {
                                                        foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosAdvReceipt.PosReceipt_ID))
                                                        {
                                                            oPayReg.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                            oPayReg.GlPosting_ID = sGLPostingID_collection;
                                                            oPayReg.Update();
                                                        }

                                                        oPosAdvReceipt.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                        oPosAdvReceipt.GlPosting_ID = sGLPostingID_collection;
                                                        oPosAdvReceipt.Update();
                                                    }
                                                }
                                                #endregion
                                            }
                                            break;

                                        case "RETURN":
                                            tbl_posTransaction oPoS_Rtn = tbl_posTransaction.Select(iTransaction_Index);
                                            if (oPoS_Rtn != null && oPoS_Rtn.PosTransaction_Index > 0)
                                            {
                                                tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPoS_Rtn.PosTransaction_Index).FirstOrDefault();
                                                string sCreditNote_ID = oCRN != null ? oCRN.CreditNote_ID : "";

                                                string sCustomer_sale = clsGenaralName.getName_Customer(oPoS_Rtn.Customer_ID);
                                                string sRemarks =
                                                        "POS" +
                                                        " | Date <" + (oPoS_Rtn.PosTransactiondate.ToString(cls_Formater.Format_Date2)) + "/>" +
                                                        " | Credit Note No: <" + sCreditNote_ID + "/>" +
                                                        " | Customer Name <" + oPoS_Rtn.Customer_ID + " - " + sCustomer_sale + "/>" +
                                                        " | Contact No: <" + clsGenaralName.getName_CustomerTelephone(oPoS_Rtn.Customer_ID) + "/>" +
                                                        " | Branch Name <" + clsGenaralName.getName_CompanyBranchMaster(oPoS_Rtn.CompanyBranch_ID) + "/>";

                                                #region Posting for Return (Transaction)
                                                int iSlotID_sale = clsAutocode.getAccSlotID(AccSlot.POS_Return);

                                                string sGLPostingID_Return = clsMethods_GL.Update_Primary_TXN(oPoS_Rtn.GlPosting_ID, iSlotID_sale, oPoS_Rtn.PosTransaction_ID, oPoS_Rtn.PosTransactiondate, oPoS_Rtn.Customer_ID, "default", oPoS_Rtn.Remark);
                                                if (sGLPostingID_Return != "")
                                                {
                                                    int iLineNo = 0;

                                                    #region Debit Entries
                                                    //NBT OUTPUT
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_Return,
                                                        iSlotID_sale,
                                                        clsConfig.sNBTGLCode_Receivable,
                                                        "default",
                                                        "default",
                                                        oPoS_Rtn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransactiondate,
                                                        sRemarks,
                                                        -dNBT,
                                                        false,
                                                        "NBT OUTPUT",
                                                        sCustomer_sale,
                                                        oPoS_Rtn.CompanyBranch_ID
                                                        );

                                                    //VAT OUTPUT
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_Return,
                                                        iSlotID_sale,
                                                        clsConfig.sVATGLCode_Receivable,
                                                        "default",
                                                        "default",
                                                        oPoS_Rtn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransactiondate,
                                                        sRemarks,
                                                        -dVAT,
                                                        false,
                                                        "VAT OUTPUT",
                                                        sCustomer_sale,
                                                        oPoS_Rtn.CompanyBranch_ID
                                                        );

                                                    //SALES - S/R
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_Return,
                                                        iSlotID_sale,
                                                        sBranchSalesAcc_ID,
                                                        "default",
                                                        "default",
                                                        oPoS_Rtn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransactiondate,
                                                        sRemarks,
                                                        -dNetSales,
                                                        false,
                                                        "SALES - S/R",
                                                        sCustomer_sale,
                                                        oPoS_Rtn.CompanyBranch_ID);

                                                    //TRADE DEBTOR
                                                    string sAccountCode_Customer = clsMethods_GL.GetAccountCode_Customer(oPoS_Rtn.Customer_ID);
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,      //Line No 
                                                        sGLPostingID_Return,   //Posting Id 
                                                        iSlotID_sale,        //Slot ID 
                                                        sAccountCode_Customer, //sGL Code
                                                        "default",      //Cost Center 1
                                                        "default",      //Cost Center 2
                                                        oPoS_Rtn.Customer_ID, //Customer Id
                                                        "default",      // Supplier Id
                                                        "default",      //Employee Id
                                                        "default",      //Bank Account Id
                                                        "-",            //Cus Sup Emp Name
                                                        oPoS_Rtn.PosTransaction_ID, //Transaction Id
                                                        oPoS_Rtn.PosTransaction_ID, //Main Transaction Id
                                                        oPoS_Rtn.PosTransactiondate,//Transaction Date
                                                        sRemarks,     //Remarks
                                                        -dSales_Total,   //Amount
                                                        false,          // Is Credit
                                                        "",             //Cheque Number
                                                        sCustomer_sale + " - TRADE DEBTOR",      //Narration
                                                        oPoS_Rtn.CompanyBranch_ID   //Company Branch
                                                        );
                                                    #endregion

                                                    #region Credit Entry
                                                    //TRADE DEBTOR
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,      //Line No 
                                                        sGLPostingID_Return,   //Posting Id 
                                                        iSlotID_sale,        //Slot ID 
                                                        sAccountCode_Customer, //sGL Code
                                                        "default",      //Cost Center 1
                                                        "default",      //Cost Center 2
                                                        oPoS_Rtn.Customer_ID, //Customer Id
                                                        "default",      // Supplier Id
                                                        "default",      //Employee Id
                                                        "default",      //Bank Account Id
                                                        "-",            //Cus Sup Emp Name
                                                        oPoS_Rtn.PosTransaction_ID, //Transaction Id
                                                        oPoS_Rtn.PosTransaction_ID, //Main Transaction Id
                                                        oPoS_Rtn.PosTransactiondate,//Transaction Date
                                                        sRemarks,     //Remarks
                                                        -dSales_Total,   //Amount
                                                        true,          // Is Credit
                                                        "",             //Cheque Number
                                                        sCustomer_sale + " - TRADE DEBTOR",      //Narration
                                                        oPoS_Rtn.CompanyBranch_ID   //Company Branch
                                                        );

                                                    //CRN Control Account
                                                    tbl_accGLMaster_CompanyBranch oGL_Com_Branch_SRN = tbl_accGLMaster_CompanyBranch.Select(oCRN.CompanyBranch_ID);
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_Return,
                                                        iSlotID_sale,
                                                        oGL_Com_Branch_SRN.CreditNote_ControlAcc,
                                                        "default",
                                                        "default",
                                                        oPoS_Rtn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransaction_ID,
                                                        oPoS_Rtn.PosTransactiondate,
                                                        sRemarks,
                                                        -dInvoice_Return_Total,
                                                        true,
                                                        "",
                                                        "CEDIT NOTE CONTROL A/C - SHOWROOM",
                                                        oPoS_Rtn.CompanyBranch_ID);
                                                    #endregion

                                                    oPoS_Rtn.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                    oPoS_Rtn.GlPosting_ID = sGLPostingID_Return;
                                                    oPoS_Rtn.Update();
                                                }
                                                #endregion
                                            }
                                            break;

                                        default: // Gift Voucher Sales and ITEM Sales
                                            tbl_posTransaction oPoS_Txn = tbl_posTransaction.Select(iTransaction_Index);
                                            if (oPoS_Txn != null && oPoS_Txn.PosTransaction_Index > 0)
                                            {
                                                string sCustomer_sale = clsGenaralName.getName_Customer(oPoS_Txn.Customer_ID);
                                                string sRemarks =
                                                        "POS" +
                                                        " | Date <" + (oPoS_Txn.PosTransactiondate.ToString(cls_Formater.Format_Date2)) + "/>" +
                                                        " | Invoice No: <" + oPoS_Txn.PosTransaction_ID + "/>" +
                                                        " | Customer Name <" + oPoS_Txn.Customer_ID + " - " + sCustomer_sale + "/>" +
                                                        " | Contact No: <" + clsGenaralName.getName_CustomerTelephone(oPoS_Txn.Customer_ID) + "/>" +
                                                        " | Branch Name <" + clsGenaralName.getName_CompanyBranchMaster(oPoS_Txn.CompanyBranch_ID) + "/>";

                                                #region Posting for sale (Transaction)
                                                int iSlotID_sale = -1;
                                                if (sTx_Mode == "ITEM")
                                                    iSlotID_sale = clsAutocode.getAccSlotID(AccSlot.POS_SalesTransaction);
                                                else
                                                    iSlotID_sale = clsAutocode.getAccSlotID(AccSlot.POS_GiftVouchers);


                                                string sGLPostingID_sale = clsMethods_GL.Update_Primary_TXN(oPoS_Txn.GlPosting_ID, iSlotID_sale, oPoS_Txn.PosTransaction_ID, oPoS_Txn.PosTransactiondate, oPoS_Txn.Customer_ID, "default", oPoS_Txn.Remark);
                                                if (sGLPostingID_sale != "")
                                                {
                                                    int iLineNo = 0;

                                                    #region Debit Entry
                                                    string sAccountCode_Customer = clsMethods_GL.GetAccountCode_Customer(oPoS_Txn.Customer_ID);

                                                    //TRADE DEBTOR
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,      //Line No 
                                                        sGLPostingID_sale,   //Posting Id 
                                                        iSlotID_sale,        //Slot ID 
                                                        sAccountCode_Customer, //sGL Code
                                                        "default",      //Cost Center 1
                                                        "default",      //Cost Center 2
                                                        oPoS_Txn.Customer_ID, //Customer Id
                                                        "default",      // Supplier Id
                                                        "default",      //Employee Id
                                                        "default",      //Bank Account Id
                                                        "-",            //Cus Sup Emp Name
                                                        oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                        oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                        oPoS_Txn.PosTransactiondate,//Transaction Date
                                                        sRemarks,     //Remarks
                                                        dSales_Total,   //Amount
                                                        false,          // Is Credit
                                                        "",             //Cheque Number
                                                        sCustomer_sale + " - TRADE DEBTOR",      //Narration
                                                        oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                        );
                                                    #endregion

                                                    #region Credit Entries
                                                    //NBT OUTPUT
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_sale,
                                                        iSlotID_sale,
                                                        clsConfig.sNBTGLCode_Receivable,
                                                        "default",
                                                        "default",
                                                        oPoS_Txn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransactiondate,
                                                        sRemarks,
                                                        dNBT,
                                                        true,
                                                        "",
                                                        "NBT OUTPUT",
                                                        oPoS_Txn.CompanyBranch_ID
                                                        );

                                                    //VAT OUTPUT
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_sale,
                                                        iSlotID_sale,
                                                        clsConfig.sVATGLCode_Receivable,
                                                        "default",
                                                        "default",
                                                        oPoS_Txn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransactiondate,
                                                        sRemarks,
                                                        dVAT,
                                                        true,
                                                        "",
                                                        "VAT OUTPUT",
                                                        oPoS_Txn.CompanyBranch_ID
                                                        );

                                                    //SALES - S/R
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_sale,
                                                        iSlotID_sale,
                                                        sBranchSalesAcc_ID,
                                                        "default",
                                                        "default",
                                                        oPoS_Txn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransactiondate,
                                                        sRemarks,
                                                        dNetSales,
                                                        true,
                                                        "",
                                                        "SALES - S/R",
                                                        oPoS_Txn.CompanyBranch_ID);
                                                    #endregion

                                                    oPoS_Txn.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                    oPoS_Txn.GlPosting_ID = sGLPostingID_sale;
                                                    oPoS_Txn.Update();
                                                }
                                                #endregion

                                                #region Posting for collection (settlement)
                                                var oReceipt_First = tbl_posReceipt.SelectAllByPosTransaction_Index(oPoS_Txn.PosTransaction_Index).FirstOrDefault();
                                                string sOldPosting_ID = oReceipt_First != null ? oReceipt_First.GlPosting_ID : "default";

                                                int iSlotID_collection = clsAutocode.getAccSlotID(AccSlot.POS_Collection);
                                                string sGLPostingID_collection = clsMethods_GL.Update_Primary_TXN(sOldPosting_ID, iSlotID_collection, oPoS_Txn.PosTransaction_ID, oPoS_Txn.PosTransactiondate, oPoS_Txn.Customer_ID, "default", oPoS_Txn.Remark);
                                                if (sGLPostingID_collection != "")
                                                {
                                                    int iLineNo = 0;

                                                    #region Debit Entries
                                                    if (dTx_PM_Cash != 0)
                                                    {
                                                        #region Cash
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                                                                    iLineNo++,      //Line No 
                                                                                                    sGLPostingID_collection,   //Posting Id 
                                                                                                    iSlotID_collection,        //Slot ID 
                                                                                                    sBranchCashInHandAcc_ID, //sGL Code
                                                                                                    "default",      //Cost Center 1
                                                                                                    "default",      //Cost Center 2
                                                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                                                    "default",      // Supplier Id
                                                                                                    "default",      //Employee Id
                                                                                                    "default",      //Bank Account Id
                                                                                                    "-",            //Cus Sup Emp Name
                                                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                                                    sRemarks,     //Remarks
                                                                                                    dTx_PM_Cash,    //Amount
                                                                                                    false,          // Is Credit
                                                                                                    "",             //Cheque Number
                                                                                                    "CASH IN HAND - SHOWROOM",             //Narration
                                                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                                                    );
                                                        #endregion
                                                    }
                                                    if (dTx_PM_Card != 0)
                                                    {
                                                        #region Card
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                                                                    iLineNo++,      //Line No 
                                                                                                    sGLPostingID_collection,   //Posting Id 
                                                                                                    iSlotID_collection,        //Slot ID 
                                                                                                    sBranchCreditCardControlAcc_ID, //sGL Code
                                                                                                    "default",      //Cost Center 1
                                                                                                    "default",      //Cost Center 2
                                                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                                                    "default",      // Supplier Id
                                                                                                    "default",      //Employee Id
                                                                                                    "default",      //Bank Account Id
                                                                                                    "-",            //Cus Sup Emp Name
                                                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                                                    sRemarks,     //Remarks
                                                                                                    dTx_PM_Card,    //Amount
                                                                                                    false,          // Is Credit
                                                                                                    "",             //Cheque Number
                                                                                                    "CREDIT CARD CONTROL A/C",             //Narration
                                                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                                                    );
                                                        #endregion
                                                    }
                                                    if (dTx_PM_Cheque != 0)
                                                    {
                                                        #region Cheque
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                                                                    iLineNo++,      //Line No 
                                                                                                    sGLPostingID_collection,   //Posting Id 
                                                                                                    iSlotID_collection,        //Slot ID 
                                                                                                    sBranchChequeInHandAcc_ID, //sGL Code
                                                                                                    "default",      //Cost Center 1
                                                                                                    "default",      //Cost Center 2
                                                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                                                    "default",      // Supplier Id
                                                                                                    "default",      //Employee Id
                                                                                                    "default",      //Bank Account Id
                                                                                                    "-",            //Cus Sup Emp Name
                                                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                                                    sRemarks,     //Remarks
                                                                                                    dTx_PM_Cheque,    //Amount
                                                                                                    false,          //Is Credit
                                                                                                    "",             //Cheque Number
                                                                                                    "CHEQUE IN HAND - SHOWROOM",             //Narration
                                                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                                                    );
                                                        #endregion
                                                    }
                                                    if (dTx_PM_AdvSettlement != 0)
                                                    {
                                                        #region Advace
                                                        clsMethods_GL.Update_Secondary_TXN(
                                                                                                    iLineNo++,      //Line No 
                                                                                                    sGLPostingID_collection,   //Posting Id 
                                                                                                    iSlotID_collection,        //Slot ID 
                                                                                                    sBranchAdvanceControlAcc_ID, //sGL Code
                                                                                                    "default",      //Cost Center 1
                                                                                                    "default",      //Cost Center 2
                                                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                                                    "default",      // Supplier Id
                                                                                                    "default",      //Employee Id
                                                                                                    "default",      //Bank Account Id
                                                                                                    "-",            //Cus Sup Emp Name
                                                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                                                    sRemarks,     //Remarks
                                                                                                    dTx_PM_AdvSettlement, //Amount
                                                                                                    false,          //Is Credit
                                                                                                    "",             //Cheque Number
                                                                                                    "ADVANCE CONTROL A/C - SHOWROOM ",  //Narration
                                                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                                                    );
                                                        foreach (tbl_bpsChequeRegister oAdv_Settle in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Advance_Receive && r.PosTransaction_ID == oPoS_Txn.PosTransaction_Index.ToString() && !r.IsDeleted))
                                                        {
                                                            foreach (tbl_bpsCreditNote oCRN_Adv in tbl_bpsCreditNote.SelectAllByAdvanceReceived_Index(oAdv_Settle.AdvanceReceived_Index))
                                                            {
                                                                oCRN_Adv.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                                oCRN_Adv.GlPosting_ID = sGLPostingID_collection;
                                                                oCRN_Adv.Update();
                                                            }
                                                        }

                                                        #endregion
                                                    }
                                                    if (dTx_PM_GV != 0)
                                                    {
                                                        #region Gift Vouchers
                                                        //GIFT VOUCHER SETTLEMENT
                                                        foreach (tbl_bpsChequeRegister oGV_Settle in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Gift_Voucher && r.PosTransaction_ID == oPoS_Txn.PosTransaction_Index.ToString() && !r.IsDeleted))
                                                        {
                                                            tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(oGV_Settle.GiftVoucherID);
                                                            if (oGV != null)
                                                            {
                                                                tbl_accGLMaster_CompanyBranch oGL_Com_Branch = tbl_accGLMaster_CompanyBranch.Select(oGV.CompanyBranchID);

                                                                decimal dGV_VAT = 0, dGV_SVAT = 0, dGV_NBT = 0, dGV_Discount = 0, dGV_Sales = 0;
                                                                clsHelpMethods.CalculateGrandTotalReverce(
                                                                    oGV.VoucherAmount,
                                                                    ref dGV_VAT, oPoS_Txn.VatPercentage, true,
                                                                    ref dGV_SVAT, oPoS_Txn.OtherTaxPercentage, false,
                                                                    ref dGV_NBT, oPoS_Txn.NbtPercentage, true,
                                                                    ref dGV_Discount, 0,
                                                                    ref dGV_Sales
                                                                );

                                                                //NBT - GV
                                                                clsMethods_GL.Update_Secondary_TXN(
                                                                    iLineNo++,
                                                                    sGLPostingID_collection,
                                                                    iSlotID_collection,
                                                                    clsConfig.sNBTGLCode_Receivable,
                                                                    "default",
                                                                    "default",
                                                                    oPoS_Txn.Customer_ID,
                                                                    "default",
                                                                    "default",
                                                                    "default",
                                                                    "-",
                                                                    oPoS_Txn.PosTransaction_ID,
                                                                    oPoS_Txn.PosTransaction_ID,
                                                                    oPoS_Txn.PosTransactiondate,
                                                                    sRemarks,
                                                                    dGV_NBT,
                                                                    false,
                                                                    "",
                                                                    "GIFT VOUCHER REDEEM - NBT AMOUNT",
                                                                    oPoS_Txn.CompanyBranch_ID
                                                                    );

                                                                //VAT - GV
                                                                clsMethods_GL.Update_Secondary_TXN(
                                                                    iLineNo++,
                                                                    sGLPostingID_collection,
                                                                    iSlotID_collection,
                                                                    clsConfig.sVATGLCode_Receivable,
                                                                    "default",
                                                                    "default",
                                                                    oPoS_Txn.Customer_ID,
                                                                    "default",
                                                                    "default",
                                                                    "default",
                                                                    "-",
                                                                    oPoS_Txn.PosTransaction_ID,
                                                                    oPoS_Txn.PosTransaction_ID,
                                                                    oPoS_Txn.PosTransactiondate,
                                                                    sRemarks,
                                                                    dGV_VAT,
                                                                    false,
                                                                    "",
                                                                    "GIFT VOUCHER REDEEM - VAT AMOUNT",
                                                                    oPoS_Txn.CompanyBranch_ID
                                                                    );

                                                                //Sales - GV
                                                                clsMethods_GL.Update_Secondary_TXN(
                                                                    iLineNo++,      //Line No 
                                                                    sGLPostingID_collection,   //Posting Id 
                                                                    iSlotID_collection,        //Slot ID 
                                                                    oGL_Com_Branch.Sales_Acc, //sGL Code
                                                                    "default",      //Cost Center 1
                                                                    "default",      //Cost Center 2
                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                    "default",      // Supplier Id
                                                                    "default",      //Employee Id
                                                                    "default",      //Bank Account Id
                                                                    "-",            //Cus Sup Emp Name
                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                    sRemarks,     //Remarks
                                                                    dGV_Sales,      //Amount
                                                                    false,          //Is Credit
                                                                    "",             //Cheque Number
                                                                    "GIFT VOUCHER REDEEM - SALES ACCOUNT - SHOWROOM",//Narration
                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                    );

                                                                //oGV.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                                //oGV.GlPosting_ID = sGLPostingID_collection;
                                                                //oGV.Update();
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    if (dTx_PM_CRN != 0)
                                                    {
                                                        #region Sales Return Credit Note Settlement
                                                        //SALES RETURN SETTLEMENT
                                                        foreach (tbl_bpsChequeRegister oSRN_Settle in tbl_bpsChequeRegister.SelectAll().Where(r => r.PaymentMethod_ID == (int)PaymentMethod.Credit_Note && r.PosTransaction_ID == oPoS_Txn.PosTransaction_Index.ToString() && !r.IsDeleted))
                                                        {
                                                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oSRN_Settle.PosReturnTransaction_Index))
                                                            {
                                                                //tbl_accGLMaster_CompanyBranch oGL_Com_Branch = tbl_accGLMaster_CompanyBranch.Select(oCRN.CompanyBranch_ID);

                                                                clsMethods_GL.Update_Secondary_TXN(
                                                                    iLineNo++,      //Line No 
                                                                    sGLPostingID_collection,   //Posting Id 
                                                                    iSlotID_collection,        //Slot ID 
                                                                    sBranchCRNControlAcc_ID, //sGL Code
                                                                    "default",      //Cost Center 1
                                                                    "default",      //Cost Center 2
                                                                    oPoS_Txn.Customer_ID, //Customer Id
                                                                    "default",      // Supplier Id
                                                                    "default",      //Employee Id
                                                                    "default",      //Bank Account Id
                                                                    "-",            //Cus Sup Emp Name
                                                                    oPoS_Txn.PosTransaction_ID, //Transaction Id
                                                                    oPoS_Txn.PosTransaction_ID, //Main Transaction Id
                                                                    oPoS_Txn.PosTransactiondate,//Transaction Date
                                                                    sRemarks,     //Remarks
                                                                    oCRN.TotalAmount, //Amount
                                                                    false,          //Is Credit
                                                                    "",             //Cheque Number
                                                                    "CEDIT NOTE CONTROL A/C - SHOWROOM", //Narration
                                                                    oPoS_Txn.CompanyBranch_ID   //Company Branch
                                                                    );
                                                                
                                                                oCRN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                                oCRN.GlPosting_ID = sGLPostingID_collection;
                                                                oCRN.Update();
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region Credit Entries
                                                    string sAccountCode_Customer = clsMethods_GL.GetAccountCode_Customer(oPoS_Txn.Customer_ID);

                                                    //Trade Debtor
                                                    clsMethods_GL.Update_Secondary_TXN(
                                                        iLineNo++,
                                                        sGLPostingID_collection,
                                                        iSlotID_collection,
                                                        sAccountCode_Customer,
                                                        "default",
                                                        "default",
                                                        oPoS_Txn.Customer_ID,
                                                        "default",
                                                        "default",
                                                        "default",
                                                        "-",
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransaction_ID,
                                                        oPoS_Txn.PosTransactiondate,
                                                        sRemarks,
                                                        dSales_Total,
                                                        true,
                                                        "",
                                                        sCustomer_sale + " - TRADE DEBTOR",
                                                        oPoS_Txn.CompanyBranch_ID
                                                        );
                                                    #endregion

                                                    foreach (tbl_posReceipt oPosReceipt in tbl_posReceipt.SelectAllByPosTransaction_Index(oPoS_Txn.PosTransaction_Index))
                                                    {
                                                        foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByPosReceipt_ID(oPosReceipt.PosReceipt_ID))
                                                        {
                                                            oPayReg.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                            oPayReg.GlPosting_ID = sGLPostingID_collection;
                                                            oPayReg.Update();
                                                        }

                                                        oPosReceipt.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                                        oPosReceipt.GlPosting_ID = sGLPostingID_collection;
                                                        oPosReceipt.Update();
                                                    }
                                                }

                                                #endregion
                                            }
                                            break;
                                    }
                                }
                                Update_DayEnd_PostingStatus();
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            //Company Branch GL Master not configured
                            MessageBox.Show("Company Branch GL Master Configurations has not completed...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //Company Branch GL Master not configured
                        MessageBox.Show("Company Branch GL Master Configurations has not completed...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Company Branch not selected
                    MessageBox.Show("Company Branch Not Selected...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                RefreshGrid();
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Refersh Button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
            AddTotals();
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dtpDateFrom.Value = DateTime.Now.Date.AddDays(-1);
            dtpDateTo.Value = DateTime.Now.Date.AddDays(-1);

            lblNetSales_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblNbt_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblVat_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblSales_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblInvSRN_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblGV_salesTotal.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblAdv_RecivedTotal.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblCash_PM_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblCardPM_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblCheqePM_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lbl_GV_PM_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblAdvSettlement.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);
            lblCRN_PM_Total.Text = cls_Formater.FormatDecimal(0, clsConfig.sPOSBillDecimalPoint);


            #region Combo Box - Company Branch
            cmbComBranch.Items.Clear();
            cmbComBranch.DisplayMember = "Value";
            cmbComBranch.ValueMember = "Text";

            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                    cmbComBranch.Items.Add(new ComboBoxItem(oDetail.CompanyBranch_ID, oDetail.BranchName));
            }
            if (cmbComBranch.Items.Count > 0)
                cmbComBranch.SelectedIndex = cmbComBranch.FindStringExact(clsSecurity.BranchName);
            #endregion

            dgvPOS_LedgerPosting.Columns["Tx_ID"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Company_BranchName"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_Cash"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_Card"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_Cheque"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_GiftVoucher"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_AdvSettlement"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvPOS_LedgerPosting.Columns["Tx_PM_CRN"].DefaultCellStyle.BackColor = Color.LightGray;

            dgvPOS_LedgerPosting.DataSource = dtPOS_Transaction.DefaultView;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                dtPOS_Transaction.Rows.Clear();

                int iLineNo = 0;
                string sCompanyBranchID = "";
                string sPaymentModeID = "";
                if (cmbComBranch.SelectedItem != null)
                    sCompanyBranchID = ((ComboBoxItem)cmbComBranch.SelectedItem).Value;

                #region POS Sales Transactions
                foreach (tbl_posTransaction oPOS_Tx in tbl_posTransaction.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => r.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction) && r.PosTransactiondate.Date >= dtpDateFrom.Value.Date && r.PosTransactiondate.Date <= dtpDateTo.Value.Date && !r.IsReturnedPOS_Invoice && !r.IsHold && !r.IsDeleted && r.GrandTotal != 0m))
                {
                    tbl_posDayStartAndEnd_Detail oPosSession = tbl_posDayStartAndEnd_Detail.Select(oPOS_Tx.DayDetail_Index);
                    if (oPosSession != null)
                    {
                        tbl_posDayStartAndEnd oPosDayEnd = tbl_posDayStartAndEnd.Select(oPosSession.DayIndex);
                        if (oPosDayEnd != null && oPosDayEnd.IsApproved)
                        {
                            decimal dNetSales = 0;
                            decimal dDiscount = 0;
                            decimal dNBT = 0;
                            decimal dVAT = 0;
                            decimal dSVAT = 0;
                            decimal dSales_Total = 0;
                            decimal dInvoice_Return_Total = 0;
                            decimal dGV_Sales = 0;
                            decimal dAdv_Received = 0;
                            decimal dTx_PM_Cash = 0;
                            decimal dTx_PM_Card = 0;
                            decimal dTx_PM_Cheque = 0;
                            decimal dTx_PM_GV = 0;
                            decimal dTx_PM_AdvSettlement = 0;
                            decimal dTx_PM_CRN = 0;
                            decimal dTx_SalesEx_CRN = 0;
                            string sTx_Mode = "ITEM";

                            dSales_Total = oPOS_Tx.GrandTotal;
                            dNetSales = oPOS_Tx.SubTotal;

                            dDiscount = oPOS_Tx.DiscountTotal;
                            decimal dDiscountPresentage = oPOS_Tx.DiscountPercentage;


                            clsHelpMethods.CalculateGrandTotalReverce(
                                dSales_Total,
                                ref dVAT, oPOS_Tx.VatPercentage, true,
                                ref dSVAT, oPOS_Tx.OtherTaxPercentage, false,
                                ref dNBT, oPOS_Tx.NbtPercentage, true,
                                ref dDiscount, dDiscountPresentage,
                                ref dNetSales
                                );

                            if (oPOS_Tx.IsGV_POS_invoice)
                            {
                                dGV_Sales = oPOS_Tx.GrandTotal;
                                sTx_Mode = "GIFT VOUCHER";
                            }
                            else
                            {
                                dInvoice_Return_Total = oPOS_Tx.GrandTotal;
                            }

                            //Advance Payment
                            dAdv_Received = 0;

                            foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => r.PosTransaction_ID == oPOS_Tx.PosTransaction_Index.ToString() && !r.IsDeleted))
                            {
                                switch (oPayReg.PaymentMethod_ID)
                                {
                                    case (int)PaymentMethod.Cash:
                                        dTx_PM_Cash += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Card:
                                        dTx_PM_Card += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Cheque:
                                        dTx_PM_Cheque += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Gift_Voucher:
                                        dTx_PM_GV += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Credit_Note:
                                        dTx_PM_CRN += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Advance_Receive:
                                        dTx_PM_AdvSettlement += oPayReg.Amount;
                                        break;
                                }
                            }

                            //2019-05-13 Return Settlement When Invoice Amount less than Return CRN Amount
                            if ((dTx_PM_Cash < 0) && (dTx_PM_CRN > 0) && ((-dTx_PM_Cash) < dTx_PM_CRN))
                            {
                                dTx_PM_CRN = dTx_PM_CRN + dTx_PM_Cash;
                                dTx_PM_Cash = 0;
                            }

                            dtPOS_Transaction.Rows.Add(
                                ++iLineNo,
                                oPOS_Tx.PosTransactiondate.ToString(cls_Formater.Format_Date2),
                                oPOS_Tx.PosTransaction_Index,
                                oPOS_Tx.PosTransaction_ID,
                                sTx_Mode,
                                oPOS_Tx.Customer_ID,
                                oPOS_Tx.CustomerName + " - " + clsGenaralName.getName_CustomerTelephone(oPOS_Tx.Customer_ID),
                                oPOS_Tx.CompanyBranch_ID,
                                clsGenaralName.getName_CompanyBranchMaster(oPOS_Tx.CompanyBranch_ID),
                                cls_Formater.FormatDecimal(dNetSales - dDiscount, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dNBT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dVAT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dSales_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dInvoice_Return_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dGV_Sales, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dAdv_Received, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Cash, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Card, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Cheque, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_GV, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_AdvSettlement, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_CRN, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_SalesEx_CRN, clsConfig.sPOSBillDecimalPoint)
                                );
                        }
                    }
                }
                #endregion

                #region POS Return Transactions
                foreach (tbl_posTransaction oPOS_Tx in tbl_posTransaction.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => r.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction) && r.PosTransactiondate.Date >= dtpDateFrom.Value.Date && r.PosTransactiondate.Date <= dtpDateTo.Value.Date && r.IsReturnedPOS_Invoice && !r.IsHold && !r.IsDeleted && r.GrandTotal != 0m))
                {
                    tbl_posDayStartAndEnd_Detail oPosSession = tbl_posDayStartAndEnd_Detail.Select(oPOS_Tx.DayDetail_Index);
                    if (oPosSession != null)
                    {
                        tbl_posDayStartAndEnd oPosDayEnd = tbl_posDayStartAndEnd.Select(oPosSession.DayIndex);
                        if (oPosDayEnd != null && oPosDayEnd.IsApproved)
                        {
                            decimal dNetSales = 0;
                            decimal dDiscount = 0;
                            decimal dNBT = 0;
                            decimal dVAT = 0;
                            decimal dSVAT = 0;
                            decimal dSales_Total = 0;
                            decimal dInvoice_Return_Total = 0;
                            decimal dGV_Sales = 0;
                            decimal dAdv_Received = 0;
                            decimal dTx_PM_Cash = 0;
                            decimal dTx_PM_Card = 0;
                            decimal dTx_PM_Cheque = 0;
                            decimal dTx_PM_GV = 0;
                            decimal dTx_PM_AdvSettlement = 0;
                            decimal dTx_PM_CRN = 0;
                            decimal dTx_SalesEx_CRN = 0;

                            dSales_Total = -oPOS_Tx.GrandTotal;
                            dNetSales = -oPOS_Tx.SubTotal;
                            clsHelpMethods.CalculateGrandTotalReverce(dSales_Total, ref dVAT, oPOS_Tx.VatPercentage, true, ref dSVAT, oPOS_Tx.OtherTaxPercentage, false, ref dNBT, oPOS_Tx.NbtPercentage, true, ref dDiscount, oPOS_Tx.DiscountPercentage, ref dNetSales);

                            dInvoice_Return_Total = -oPOS_Tx.GrandTotal;
                            dAdv_Received = 0;

                            //foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => r.PosTransaction_ID == oPOS_Tx.PosTransaction_ID && !r.IsDeleted))
                            //{
                            //    switch (oPayReg.PaymentMethod_ID)
                            //    {
                            //        case (int)PaymentRegisterTransfers.Cash:
                            //            dTx_PM_Cash += oPayReg.Amount;
                            //            break;
                            //        case (int)PaymentRegisterTransfers.Card:
                            //            dTx_PM_Card += oPayReg.Amount;
                            //            break;
                            //        case (int)PaymentRegisterTransfers.Cheque:
                            //            dTx_PM_Cheque += oPayReg.Amount;
                            //            break;
                            //        case (int)PaymentRegisterTransfers.Gift_Voucher:
                            //            dTx_PM_GV += oPayReg.Amount;
                            //            break;
                            //        case (int)PaymentRegisterTransfers.Credit_Note:
                            //            dTx_PM_CRN += oPayReg.Amount;
                            //            break;
                            //        case (int)PaymentRegisterTransfers.Advance_Receive:
                            //            dTx_PM_AdvSettlement += oPayReg.Amount;
                            //            break;
                            //    }
                            //}
                            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAllByPosReturnTransaction_Index(oPOS_Tx.PosTransaction_Index).Where(r => !r.IsDeleted))
                            {
                                dTx_PM_CRN += oCRN.TotalAmount;
                            }


                            dtPOS_Transaction.Rows.Add(
                                ++iLineNo,
                                oPOS_Tx.PosTransactiondate.ToString(cls_Formater.Format_Date2),
                                oPOS_Tx.PosTransaction_Index,
                                oPOS_Tx.PosTransaction_ID,
                                "RETURN",
                                oPOS_Tx.Customer_ID,
                                oPOS_Tx.CustomerName + " - " + clsGenaralName.getName_CustomerTelephone(oPOS_Tx.Customer_ID),
                                oPOS_Tx.CompanyBranch_ID,
                                clsGenaralName.getName_CompanyBranchMaster(oPOS_Tx.CompanyBranch_ID),
                                cls_Formater.FormatDecimal(-(dNetSales - dDiscount), clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dNBT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dVAT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dSales_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dInvoice_Return_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dGV_Sales, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dAdv_Received, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_PM_Cash, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_PM_Card, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_PM_Cheque, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_PM_GV, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_PM_AdvSettlement, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_CRN, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(-dTx_SalesEx_CRN, clsConfig.sPOSBillDecimalPoint)
                                );
                        }
                    }
                }
                #endregion

                #region POS Advance
                foreach (tbl_posAdvanceReceived oPOS_Advance in tbl_posAdvanceReceived.SelectAllByCompanyBranchID(sCompanyBranchID).Where(r => r.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction) && r.PaymentDate.Date >= dtpDateFrom.Value.Date && r.PaymentDate.Date <= dtpDateTo.Value.Date && !r.IsCanceled && r.AdvanceAmount != 0m))
                {
                    tbl_posDayStartAndEnd_Detail oPosSession = tbl_posDayStartAndEnd_Detail.Select(oPOS_Advance.DayDetail_Index);
                    if (oPosSession != null)
                    {
                        tbl_posDayStartAndEnd oPosDayEnd = tbl_posDayStartAndEnd.Select(oPosSession.DayIndex);
                        if (oPosDayEnd != null && oPosDayEnd.IsApproved)
                        {
                            decimal dNetSales = 0;
                            decimal dDiscount = 0;
                            decimal dNBT = 0;
                            decimal dVAT = 0;
                            decimal dSVAT = 0;
                            decimal dSales_Total = 0;
                            decimal dInvoice_Return_Total = 0;
                            decimal dGV_Sales = 0;
                            decimal dAdv_Received = 0;
                            decimal dTx_PM_Cash = 0;
                            decimal dTx_PM_Card = 0;
                            decimal dTx_PM_Cheque = 0;
                            decimal dTx_PM_GV = 0;
                            decimal dTx_PM_AdvSettlement = 0;
                            decimal dTx_PM_CRN = 0;
                            decimal dTx_SalesEx_CRN = 0;


                            dNBT = 0;
                            dVAT = 0;
                            dSales_Total = 0;
                            dInvoice_Return_Total = 0;
                            dGV_Sales = 0;
                            dAdv_Received = oPOS_Advance.AdvanceAmount;

                            foreach (tbl_bpsChequeRegister oPayReg in tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => (r.PosTransaction_ID == "default" || r.PosTransaction_ID == "-1") && r.AdvanceReceived_Index == oPOS_Advance.AdvanceReceived_Index && !r.IsDeleted))
                            {
                                switch (oPayReg.PaymentMethod_ID)
                                {
                                    case (int)PaymentMethod.Cash:
                                        dTx_PM_Cash += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Card:
                                        dTx_PM_Card += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Cheque:
                                        dTx_PM_Cheque += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Gift_Voucher:
                                        dTx_PM_GV += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Credit_Note:
                                        dTx_PM_CRN += oPayReg.Amount;
                                        break;
                                    case (int)PaymentMethod.Advance_Receive:
                                        dTx_PM_AdvSettlement += oPayReg.Amount;
                                        break;
                                }
                            }

                            dtPOS_Transaction.Rows.Add(
                                ++iLineNo,
                                oPOS_Advance.PaymentDate.ToString(cls_Formater.Format_Date2),
                                oPOS_Advance.AdvanceReceived_Index,
                                oPOS_Advance.AdvanceReceived_ID,
                                "ADVANCE",
                                oPOS_Advance.Customer_ID,
                                clsGenaralName.getName_Customer(oPOS_Advance.Customer_ID) + " - " + clsGenaralName.getName_CustomerTelephone(oPOS_Advance.Customer_ID),
                                oPOS_Advance.CompanyBranchID,
                                clsGenaralName.getName_CompanyBranchMaster(oPOS_Advance.CompanyBranchID),
                                cls_Formater.FormatDecimal(dNetSales, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dNBT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dVAT, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dSales_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dInvoice_Return_Total, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dGV_Sales, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dAdv_Received, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Cash, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Card, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_Cheque, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_GV, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_AdvSettlement, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_PM_CRN, clsConfig.sPOSBillDecimalPoint),
                                cls_Formater.FormatDecimal(dTx_SalesEx_CRN, clsConfig.sPOSBillDecimalPoint)
                                );
                        }
                    }
                }
                #endregion

                DataRow[] dataRows = dtPOS_Transaction.Select().OrderBy(u => u["Tx_Date"]).ToArray();
                DataTable dt = new DataTable();
                if (dataRows.Count() > 0)
                {
                    dt = dataRows.CopyToDataTable();
                    OrderBy_DataGrid(dt);
                }
                dgvPOS_LedgerPosting.DataSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Link Click Events
        private void lblStdJE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Standard);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.ParentForm);
        }

        private void lblBankAjustEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Bank);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.ParentForm);
        }

        private void lblReceipt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.ParentForm);
        }

        private void lblCashDeposit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_bpsCashDeposit frm = new frm_bpsCashDeposit(FormName.CashDepositeCode);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, this.ParentForm);
        }

        private void lblJE_Advance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UC_AccJournalEntry frm = new UC_AccJournalEntry(FormName.accJournalEntry_Advance);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.ParentForm);
        }

        private void lblDebtoeSettlement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_bpsInvoiceSettlement frm = new frm_bpsInvoiceSettlement(FormName.bssInvoiceSettlement);
            clsHelpMethods_Local.DisplayForm(frm, Color.Empty, this.ParentForm);
        }

        private void lblAccountReceipt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_accAccountReceipt frm = new frm_accAccountReceipt(FormName.accReceiptVoucher);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorAccounts, this.ParentForm);
        }

        private void lblChequeDeposit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_bpsChequeDeposit frm = new frm_bpsChequeDeposit(FormName.ChequeDeposit);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, this.ParentForm);
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_Customer_GL_Code()
        {
            bool bReturn = true;

            foreach (DataRow row in dtPOS_Transaction.Rows)
            {
                string sCustomer_ID = clsValidate.ValidateRowValue(row, "Customer_ID", "default");
                string sCustomer_Name = clsValidate.ValidateRowValue(row, "Customer_Name", "-");
                string sGL_Customer = clsMethods_GL.GetAccountCode_Customer(sCustomer_ID);
                if (!clsMethods_GL.CheckAccountValidity(sGL_Customer))
                {
                    MessageBox.Show("Account Code not found for... \nCustomer ID : " + sCustomer_ID + "\nCustomer Name :" + sCustomer_Name, clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    bReturn = false;
                    break;
                }
            }

            return bReturn;
        }
        #endregion

        #region Help Methods
        private void OrderBy_DataGrid(DataTable dt)
        {
            long i = 0;
            foreach (DataRow row in dt.Rows)
                row["LineNo"] = ++i;
        }

        private void AddTotals()
        {
            decimal dNetSales_Total = 0;
            decimal dNBT_Total = 0;
            decimal dVAT_Total = 0;
            decimal dSales_Total_Total = 0;
            decimal dInvoice_Return_Total_Total = 0;
            decimal dGV_sales_Total = 0;
            decimal dAdvancePayment_Total = 0;
            decimal dTx_PM_Cash_Total = 0;
            decimal dTx_PM_Card_Total = 0;
            decimal dTx_PM_Cheque_Total = 0;
            decimal dTx_PM_GV_Total = 0;
            decimal dTx_PM_AdvSettlement_Total = 0;
            decimal dTx_PM_CRN_Total = 0;
            //decimal dTx_SalesEx_CRN_Total = 0;

            if (dtPOS_Transaction.Rows.Count > 0)
            {
                dNetSales_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["NetSales"].ToString())) as IEnumerable<decimal>).Sum();
                dNBT_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["NBT"].ToString())) as IEnumerable<decimal>).Sum();
                dVAT_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["VAT"].ToString())) as IEnumerable<decimal>).Sum();
                dSales_Total_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Sales_Total"].ToString())) as IEnumerable<decimal>).Sum();
                dInvoice_Return_Total_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Invoice_Return_Total"].ToString())) as IEnumerable<decimal>).Sum();
                dGV_sales_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["GV_sales"].ToString())) as IEnumerable<decimal>).Sum();
                dAdvancePayment_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["AdvancePayment"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_Cash_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_Cash"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_Card_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_Card"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_Cheque_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_Cheque"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_GV_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_GV"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_AdvSettlement_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_AdvSettlement"].ToString())) as IEnumerable<decimal>).Sum();
                dTx_PM_CRN_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_PM_CRN"].ToString())) as IEnumerable<decimal>).Sum();
                //dTx_SalesEx_CRN_Total = ((from s in dtPOS_Transaction.AsEnumerable() select decimal.Parse(s["Tx_SalesEx_CRN"].ToString())) as IEnumerable<decimal>).Sum();
            }

            lblNetSales_Total.Text = cls_Formater.FormatDecimal(dNetSales_Total, clsConfig.sPOSBillDecimalPoint);
            lblNbt_Total.Text = cls_Formater.FormatDecimal(dNBT_Total, clsConfig.sPOSBillDecimalPoint);
            lblVat_Total.Text = cls_Formater.FormatDecimal(dVAT_Total, clsConfig.sPOSBillDecimalPoint);
            lblSales_Total.Text = cls_Formater.FormatDecimal(dSales_Total_Total, clsConfig.sPOSBillDecimalPoint);
            lblInvSRN_Total.Text = cls_Formater.FormatDecimal(dInvoice_Return_Total_Total, clsConfig.sPOSBillDecimalPoint);
            lblGV_salesTotal.Text = cls_Formater.FormatDecimal(dGV_sales_Total, clsConfig.sPOSBillDecimalPoint);
            lblAdv_RecivedTotal.Text = cls_Formater.FormatDecimal(dAdvancePayment_Total, clsConfig.sPOSBillDecimalPoint);
            lblCash_PM_Total.Text = cls_Formater.FormatDecimal(dTx_PM_Cash_Total, clsConfig.sPOSBillDecimalPoint);
            lblCardPM_Total.Text = cls_Formater.FormatDecimal(dTx_PM_Card_Total, clsConfig.sPOSBillDecimalPoint);
            lblCheqePM_Total.Text = cls_Formater.FormatDecimal(dTx_PM_Cheque_Total, clsConfig.sPOSBillDecimalPoint);
            lbl_GV_PM_Total.Text = cls_Formater.FormatDecimal(dTx_PM_GV_Total, clsConfig.sPOSBillDecimalPoint);
            lblAdvSettlement.Text = cls_Formater.FormatDecimal(dTx_PM_AdvSettlement_Total, clsConfig.sPOSBillDecimalPoint);
            lblCRN_PM_Total.Text = cls_Formater.FormatDecimal(dTx_PM_CRN_Total, clsConfig.sPOSBillDecimalPoint);
        }

        private void Update_DayEnd_PostingStatus()
        {
            string sCompanyBranchID = ((ComboBoxItem)cmbComBranch.SelectedItem).Value;
            foreach (tbl_posDayStartAndEnd oPOS_Day in tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(r => r.IsApproved &&
               r.DateCreated.Date >= dtpDateFrom.Value.Date && r.DateCreated.Date <= dtpDateTo.Value.Date && r.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)))
            {
                oPOS_Day.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                oPOS_Day.Update();
            }
        }
        #endregion
    }
}

