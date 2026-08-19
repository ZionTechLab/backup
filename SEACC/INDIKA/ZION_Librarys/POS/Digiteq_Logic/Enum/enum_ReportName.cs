namespace Digiteq_Logic
{
    public enum enum_ReportName
    {
        #region NotePrinting
        NP_CustomerOrder = 4,
        NP_AccountPayableNote = 8,
        NP_JournalVoucher = 9,
        NP_ReceiptVoucher = 10,
        NP_PaymentVoucher = 11,
        //NP_PostingInterface = 12,
        //NP_ChequeManagement_ChequeDeposit = 13,
        //NP_ChequeManagement_CashDeposit = 14,
        //NP_ChequeManagement_ReDeposit = 15,
        //NP_ChequeManagement_ReIssues = 16,
        //NP_ChequeManagement_Reconciliation = 17,
        //NP_InvoiceSettlement = 18,
        NP_CreditNote = 19,
        NP_DebitNote = 20,
        NP_InterimReceipt = 21,

        NP_ProductionProfit = 22,
        NP_OfficeProfit = 23,
        NP_DeliveryProfit = 24,
        NP_Preplan_Section = 25,
        NP_WorkInProgress = 26,

        NP_SalesInquiry = 27,
        NP_SalesJobEntry_Inquiry = 28,
        //NP_CustomerQuotation = 29,
        NP_DeliveryOrder = 31,
        NP_SalesInvoice = 32,
        NP_SalesReturnNote = 33,
        NP_SalesReceipt = 34,
        //NP_LoanIn = 35,
        //NP_LoanOut = 36,


        NP_PurchaseRequisitionNote = 37,
        NP_PurchaseOrder = 38,
        NP_GoodsReceivedNote = 39,
        NP_GoodsIssuedNote = 40,
        NP_PurchaseReturnNote = 41,
        NP_DamagedGoodsNote = 42,
        NP_DiscardedItemNote = 43,
        NP_ItemSplitNote = 44,
        NP_StockAdjustment = 45,
        NP_ProformaInvoice = 46,
        NP_Invoice = 47,
        NP_Invoice_2 = 50,
        NP_Invoice_Preprint = 52,
        NP_DeliveryOrder_BrackDown = 48,
        NP_JobViewer = 49,
        NP_InterimReceipt_Temp = 51,
        NP_iSRN = 2300,
        NP_iGrn = 2301,
        NP_eGIN = 2302,
        NP_FinishedGoodsTransferNote = 2303,
        NP_Quotation = 2304,

        NP_SalesReceipt_ChequeList = 2308,
        NP_GoodsTransferNote = 2309,
        NP_AccountDebitNote = 2310,//suplier debit note enum - janith - 2017-09-26
        #endregion

        #region Register

        RG_InquirySummary = 201,
        RG_InquiryDetail = 202,
        RG_QuotationSummary = 203,
        RG_QuotationDetails = 204,
        RG_PerformaInvoiceSummary = 205,
        RG_PerformaInvoiceDetails = 206,
        RG_CustomerOrderSummary = 207,
        RG_CustomerOrderDetail = 208,
        RG_DeliveryOrderSummary = 209,
        RG_DeliveryOrderDetail = 210,
        RG_InvoiceSummary = 211,
        RG_InvoiceDetail = 212,
        RG_SalesReturnSummary = 213,
        RG_SalesReturnDetail = 214,

        RG_ChequeRegisterCheque_Weekly_ByReceiptDate = 215,
        RG_ChequeRegisteredCheque_Daily = 216,
        RG_ChequeRegisteredCheque_Weekly_ByChequeDate = 217,
        RG_DepositedChequesBankAcct_Wise = 218,
        RG_DepositedCashBankAcct_Wise = 219,
        RG_RedepositChequesBankAcct_Wise = 220,
        RG_ReIssuedChequesSummary = 221,
        RG_REIssuedChequesDaily = 222,

        RG_ReceiptSummary = 223,
        RG_SalesReceiptSummary = 224,
        RG_InterimReceiptSummary = 225,
        RG_CreditNoteSummary = 226,
        RG_DebitNoteSummary = 227,

        RG_PurchaseRequisitionSummary = 228,
        RG_PurchaseRequisitionDetail = 229,
        RG_POSummary = 230,
        RG_PODetail = 231,
        RG_GRNSummary = 232,
        RG_GRNDetail = 233,
        RG_ItemSplitSummary = 234,
        RG_ItemSplitDetail = 235,
        RG_GIN_Summary = 236,
        RG_GIN_Detail = 237,
        RG_DGN_Summary = 238,
        RG_DGN_Detail = 239,
        RG_DIN_Summary = 240,
        RG_DIN_Detail = 241,
        RG_Internal_Store_ISRSummary = 242,
        RG_Internal_Store_ISR_Detail = 243,
        RG_Internal_Store_GIN_Summary = 244,
        RG_Internal_Store_GIN_Detail = 245,
        RG_Internal_Store_GRN_Summary = 246,
        RG_Internal_Store_GRN_Detail = 247,
        RG_Internal_Section_iSR_Summary = 248,
        RG_Internal_Section_iSR_Detail = 249,
        RG_Internal_Section_GINSummary = 250,
        RG_Internal_Section_GIN_Detail = 251,
        RG_Internal_Section_GRNSummary = 252,
        RG_Internal_Section_GRNDetail = 253,

        RG_DepositedCashBankAcct_Wise_Detail = 461,

        //RG_ChequeTracking = 254,
        RG_PRNDetails = 255,
        RG_PRNSummary = 256,
        //RG_LoanIN = 257,
        //RG_LoanOut = 258,

        RG_Outstanding_Customer_Wise_Summary = 450,
        RG_Outstanding_Customer_Wise_Detail = 451,
        RG_Outstanding_Salesman_wise_Summary = 452,
        RG_Outstanding_Salesman_wise_Detail = 453,
        RG_Outstanding_Invoice_wise_Summary = 454,
        RG_Outstanding_Invoice_wise_Detail = 455,
        RG_Age_Analysis_Customer_wise = 456,
        RG_Age_Analysis_Salesman_wise = 457,
        RG_OutstandingStatement = 458,
        RG_OutstandingStatement_SendEmail = 459,
        RG_OutstandingStatement_Salesman_wise = 460,
        RG_Outstanding_Salesman_wise_Detail_TW = 462,

        RG_Sales_Journal = 258,
        RG_Invoice_wise_payment_Tracking = 259,
        RG_Invoice_wise_payment_Tracking_With_Deposited_Detail = 999,
        RG_Customer_wise_payment_Tracking = 2591,
        RG_Receipt_wise_Invoice_Tracking = 260,
        RG_Receipt_Allocation = 261,
        //RG_Sales_Commission_Summary = 263,
        RG_Sales_Commission_Detail = 264,
        RG_InterCompanyTranferSummary = 265,
        RG_InterCompanyTranferDetail = 266,
        RG_Sales_Commision_Invoice_wise = 2305,
        //RG_Sales_Commission_Summary_DateWise = 2306,
        RG_Sales_Commission_Statement = 2307,
        RG_Realized_Cheque = 268,
        RG_Stock_Adjustment_Summery = 269,
        RG_Stock_Adjustment_Details = 270,
        RG_Good_Transfer_Note_Details = 376,
        RG_Good_Transfer_Note_Summery = 377,
        RG_Supplier_wise_Outstanding_Summary = 378,
        RG_Supplier_wise_Outstanding_Detail = 379,
        RG_OverPaymentListing = 267,
        RG_AdvanceListing = 271,


        //RG_Returned_Cheque_BankWise = 272,
        RG_PendingDeliverySummary_TownWise = 284,
        RG_Pending_Delivery_Details_TownWise = 285,
        RG_Pending_Delivery_Item_Summary = 286,
        RG_Pending_Delivery_ItemforCustomers = 287,
        RG_Pending_Delivery_Item_Datewise = 288,
        //RG_Item_Prise_List_CustomerWise = 289,
        //RG_Customer_Wise_DeliveryReport = 290,
        //RG_Job_wise_DeliveryReport = 291,
        //RG_Delivery_TrackingReport = 292,
        //RG_Store = 293,
        //RG_Section = 294,
        //RG_Department = 295,
        //RG_User_Master_Report = 296,
        //RG_Permission_Report_UserWise = 297,
        //RG_Permission_Report_FormWise = 298,
        RG_Item_Master = 299,
        RG_Customer_Master = 300,
        RG_Supplier_Master = 301,
        RG_Supplier_Class = 302,
        RG_Supplier_Type = 303,
        RG_Supplier_Category = 304,
        RG_Customer_Class = 305,
        RG_Customer_Type = 306,
        RG_Customer_Category = 307,
        RG_Item_Class = 308,
        RG_Item_Type = 309,
        RG_ItemCategory = 310, // 
        RG_Brand = 311,
        RG_Uom = 312,
        RG_Uom_Category = 313,
        RG_Bank = 314,
        RG_Branch = 315,
        RG_Currency = 316,
        RG_Tax = 317,
        RG_County = 318,
        RG_Province = 319,
        RG_District = 320,
        RG_City = 321,
        RG_Town = 322,
        RG_Employee = 323,
        RG_Sales_Manger = 324,
        RG_Area_Manager = 325,
        RG_Sales_Rep = 326,
        RG_Sales_Executive = 327,
        RG_Vehicles = 328,
        RG_Driver = 329,
        RG_Assistant = 330,
        RG_Area = 331,
        RG_Root = 332,
        RG_Item_Category = 333,
        RG_Cheque_Status = 334,
        RG_CustomerMasterSummary_CustomerWise = 335,
        RG_CustomerMasterSummary_RouterWise = 336,
        RG_CustomerMasterSummary_SelesRepWise = 337,
        RG_CustomerMasterSummary_TownWise = 338,
        RG_Customer_SelesRepWise = 2243,
        RG_CustomerProfile_CustomerWise = 2244,
        //RG_Trail_Balance = 339,
        //RG_Balance_Sheet = 340,
        //RG_ProfitAndLoss_Statement = 341,
        //RG_GL_posting = 342,
        //RG_Ledger_Listing = 343,
        //RG_GL_DetailedReport_AccCodeWise = 344,
        //RG_PaymentVoucher_Summary = 345,
        //RG_PaymentVoucher_Detail = 346,
        RG_Financial_Year = 347,
        RG_General_Ledger = 348,
        RG_SubLedger_Debtors = 349,
        RG_SubLedger_Creditors = 352,
        RG_Account_Type = 350,
        RG_Account_Type2 = 353,
        RG_Account_Code = 351,
        RG_Cheque_Type = 360,
        //RG_Annual_Sales_Report = 370,
        //RG_Cash_Book_Account = 371,
        //RG_Petty_Cash_Account = 373,
        RG_Finished_Goods_Transfer_Note_Summary = 374,
        RG_Finished_Goods_Transfer_Note_Details = 375,

        //ACC Register Report
        RG_Account_Payable_Note_Summary_Report = 2201,
        RG_Account_Payable_Note_Detail_Report = 2202,
        RG_Payment_Voucher_Summary_Report = 2203,
        RG_Payment_Voucher_Detail_Report = 2204,
        RG_Debit_Note_Summery_Report_Supplier = 2245,
        RG_Debit_Note_Detail_Report_Supplier = 2246,
        RG_ChartOfAccount_GL = 2248,
        RG_ChartOfAccount_SubAcc1 = 2249,
        RG_ChartOfAccount_SubAcc2 = 2250,
        RG_ChartOfAccount_Tagging = 2251,
        RG_JournalVoucher_Summary_Report = 2256,
        RG_JournalVoucher_Detail_Report = 2257,
        RG_AccountReceipt_Summary_Report = 2258,
        RG_AccountReceipt_Detail_Report = 2259,
        RG_ChartOfAccount_GeneralLedger = 2264,
        RG_ChartOfAccount_SugLedger = 2265,

        RG_APN_Settlement_Report = 2255,

        //new enum start 2017-09-29
        RG_SubLedger_Debtors_Summary = 2400,
        RG_SubLedger_Creditors_Summary = 2405,

        //new enums for bills report
        RG_CreditNoteDetail = 2410,
        RG_ReceiptDetails = 2415,
        RG_DebitNoteDetails = 2420,

        //ADM_Print_Log = 2253,
        ADM_Cancel_Transactions = 2275,
        #endregion

        #region Pretycash
        PT_Level_1_Titles = 900,
        PT_Level_2_Titles = 901,
        PT_Level_3_Titles = 902,
        PT_Expenditure_Types = 903,
        PT_Cost_Centers = 904,
        PT_Activitys_Items = 905,
        PT_Suppliers = 906,
        PT_Income_Types = 907,

        #endregion

        #region Standed Report
        ST_Tax_Report_Invoice_LocalNBTVAT = 1088,
        ST_Tax_Report_Invoice_LocalSVAT = 1089,
        ST_Tax_Report_Invoice_ExportSVAT = 1087,
        ST_Tax_Report_Invoice_DetailLocalNBTVAT = 1092,
        ST_Tax_Report_Invoice_DetailExportVAT = 1093,
        ST_Tax_Report_Invoice_DetailExportSVAT = 1094,

        ST_Tax_Reports_VAT_Schedule01 = 1210,
        ST_Tax_Reports_VAT_Schedule02 = 1220,
        ST_Tax_Reports_VAT_Schedule04 = 1240,
        ST_Tax_Reports_SVAT_Schedule04 = 1250,
        ST_Tax_Reports_SVAT_Schedule05 = 1260,
        ST_Tax_Reports_SVAT_Schedule05a = 1261,
        ST_Tax_Reports_SVAT_Schedule05b = 1262,
        ST_Tax_Reports_SVAT_Schedule06 = 1270,
        ST_Tax_Reports_SVAT_Schedule07 = 1280,

        ST_Incentive = 2001,
        ST_Tax_Report_Invoice_Detail = 1098,

        //Bills Standerd
        ST_Pending_Cheque_Deposite = 1026,
        ST_Cheque_In_HandAll = 1027,
        ST_Cheque_In_Hand_Approved_For_Deposit = 1028,
        ST_ChequeIn_Hand_Pending_Approval = 1029,
        ST_Returned_Cheque_inHand = 1030,
        ST_Collection_Report_Summary = 1031,
        ST_Collection_Report_Detail = 1032,
        ST_Collection_Report_Aging = 1033,
        ST_FloorStockReport = 1103,
        ST_Outstanding_Analysis = 1105,
        ST_ChequeTracer = 1106,
        ST_Returned_Cheque_Outstanding = 1035,


        //SCS Standerd
        ST_Stocks_MovementReport = 2350,
        ST_Stocks_MovementReport_Detail = 2351,
        ST_Items_Card = 2352,
        ST_Stock_Statement = 2353,

        ST_Stocks_TrackingReport_Qty = 1041,
        ST_Stocks_TrackingReport_Weight = 1042,

        ST_Opening_StockReport = 1044,
        ST_Item_SplitNote_DeltaReport = 1045,
        ST_Store_Requests_vs_Issues = 1046,

        ST_Stock_Value_Report = 1066,
        ST_Stock_Value_Report_Qty = 10660,
        ST_Stock_Value_Report_Qty_Detail = 10661,
        ST_Stock_Value_Report_Waight = 10662,
        ST_Stock_Value_Report_Waight_Detail = 10663,
        ST_Stock_Value_Report_Item_Type_Wice = 1073,

        ST_Purchase_Order_Item_Cost_History = 1067,
        ST_ReOrder_Leval_Exceed_Items = 1071,
        ST_CostCenterWiseItemTracking = 1072,
        ST_PRNTracking = 1074,

        ST_Pending_LoanOut = 1047,
        ST_Pending_LoanIn = 1048,
        ST_LoanIN = 2219,
        ST_LoanOut = 2220,

        ST_Fast_Moving_Items = 2230,
        ST_Slow_Moving_Items = 2228,
        ST_Item_Price_List = 2233,

        ST_Purchase_Order_Tracking_Report = 1049,
        ST_PurchaseOrderSummaryReport = 1078,
        ST_PurchaseOrderSummaryReport_SupplierWise = 2354,
        ST_PurchaseOrderSummaryReport_Foreign = 2355,
        ST_ReOrder_Level_ItemsWise = 1200,
        ST_iGIN_vs_iGRN_Report = 1201,

        //SAS Standerd
        ST_Monthly_Sales_Customer_Wise_Rupees = 1051,
        ST_Annual_Sales_Report_Customer_SalesmanWise = 1052,
        ST_Monthly_Turn_Over_Statement_CustomerWise = 1053,
        ST_Monthly_Turn_Over_Statement_SalesmanWise = 1054,
        ST_Sales_Report_Summary_ItemWise = 1055,
        ST_Tax_Report_CreditNote = 1056,
        ST_Tax_Report_Detail_CreditNote = 1099,
        ST_Tax_Report_Detail_Invoice = 1059,
        ST_Dilivery_Listing_Report = 1060,
        ST_Sales_Report_Itemwise = 1061,
        ST_SalesReport_RouteWise = 1062,
        ST_Monthly_Sales_CustomerWise_Dollars = 1063,
        ST_Invoice_Listing_Report = 1065,
        RG_Returned_Cheque_BankWise = 1070,

        ST_MonthlyUsageTrackingReport = 1080,
        ST_Svat_04 = 1081,
        ST_SalesReturnTrackingReport = 1083,
        ST_OutstandingOrders_CustomerWise = 1084,
        ST_MounthlySalesSummaryReport = 1090,//
        St_DelevaryTrackingReport = 2000,
        ST_SalesReturnValue = 20020,
        ST_Cheque_In_Hand = 2208,
        ST_Cheques_Age_Analysis = 2209,
        ST_SalesReport_NoteTypeWise = 2221,
        ST_SalesReport_Invoice_Wise = 2222,
        ST_SalesReport_SalesmanWise = 2223,
        ST_SalesReport_ItemWise_HTML = 2224,
        ST_SalesReport_ItemWise_Cr = 2225,
        ST_Sales_Register_Details = 2226,
        ST_SalesPriceList_MRP = 2227,
        ST_DiscountedItem = 2229,
        ST_FreeItem = 2241,
        ST_DONotInvoiced = 2232,
        ST_SalesProfitability = 2234,
        ST_CustomerOrderTrackingReport = 2250,
        ST_SalesReport_SalesRepWise = 1059,

        //indika reports
        ST_MonthlyReturnsAgainst_Sales = 20021,
        ST_MonthlySalesCalendar_RouteSalesRepWise = 20022,




        //ACC 
        ST_Acc_BudgetPlaningMonthWise = 2213,
        ST_Acc_BudgetPlaningQuarterWise = 2214,
        ST_Acc_ProfitAndLoss_Cus = 2216,
        ST_Acc_ProfitAndLoss_Std = 2236,
        ST_Acc_BalanceSheet = 2217,
        ST_Acc_Notes = 2218,
        ST_ACC_Trail_Balance = 2231,
        ST_ACC_Trail_Balance_Advance = 2235,
        ST_AccountOpeningBalance = 1076,
        ST_CashBook = 2240,
        ST_BankBook = 2254,
        ST_CashBankDetailBook = 2260,
        ST_SubAcc1Statement = 2261,
        ST_BankReconcilation = 2242,
        ST_BankReconcilationWithoutAdjustment = 2262,
        ST_SubAccWise = 2263,
        ST_GLCodeWise_SubAccounts = 2247,
        ST_ItemSalesReport_SalesRepWise = 2252,

        //NP_BarcodePrint = 2248,
        #endregion

        #region APN Reports
        AP_Tax = 2200,
        AP_Supplier_Outstanding_GRN = 2205,
        AP_Supplier_Outstanding_PO = 2206,
        AP_Creditors_Age_anlysis_Detail = 2210,
        AP_Creditors_Age_anlysis_Summary = 2211,
        AP_SupplierJournalTrackingReport = 2500,

        #endregion

        #region Master Report
        Mas_Customer = 2212,
        #endregion

        #region Factoring Reports
        factoringAgreement = 100,
        factoringSchedule = 5051,
        FactoringDetailsReport = 101,
        MarginReport = 102,
        PendingMarginReport = 103,
        FactoringSummaryReport = 104,
        FactoringReconcilationReport = 105,
        #endregion

        #region PCB Reports
        #region Note print
        pcb_Expenditure = 850,
        pcb_IOU = 851,
        pcb_IOURequst = 852,
        pcb_Refund = 856,
        pcb_Reimbursement = 858,
        #endregion

        #region Registry
        pcb_ExpenditureSummary = 853,
        pcb_IOUSummary = 854,
        pcb_IOURequstSummary = 855,
        pcb_RefundSummery = 857,
        pcb_ExpenditureDetails = 859,
        #endregion

        #endregion

        #region Customized Reports(From 8000 onwards)
        CU_UnsettledCreditNote = 8000,
        CU_CollectionReportRouteWise = 8001,
        CU_InvoiceWisePaymentTracking = 8002,
        CU_BankAccountWisePaymentVoucher = 8003,
        CU_DepositedCheque = 8004,

        CU_StockStatement = 8010,


        //Customermized Excel Report
        CU_SalesDetailReport_InvoiceItemWise = 8500,
        CU_SalesDetailReport_InvoiceItemWiseCR = 85001,
        CU_SalesDetailReport_InvoiceWise = 8501,
        CU_SalesSummaryReport = 8502,
        CU_SalesSummaryReport_YTD = 8503,
        CU_CollectionReportSummary_RepWise = 8504,
        CU_PendingOrders = 8505,
        #endregion

        #region R2 Production System Reports (From 17,000 onwards)

        //17000 - 17199 (Apparel)
        ProdApparel_InputMaterialsMovement = 17000,
        ProdApparel_WorkInProgressSummary = 17001,
        ProdApparel_WorkInProgressStockTracking = 17002,
        ProdApparel_BoMSheet = 17003,

        //Apparel Note Print
        ProdApparel_BoMDetail = 17100,

        //17200 - 17399 (Pharma)
        ProdPharma_InputMaterialsMovement = 17200,
        ProdPharma_WorkInProgressSummary = 17201,
        ProdPharma_WorkInProgressStockTracking = 17202,


        //Pharma Note Print
        ProdPharma_PGIN = 17300,
        ProdPharma_MR = 17301,
        #endregion

        #region R2 Point of Sales (From 9510 - 9999)
        POS_Bill_NotePrint = 9510,
        POS_Return_NotePrint = 9515,
        POS_Advance_NotePrint = 9516,
        POS_TransactionSummary = 9520,
        POS_TransactionDetail = 9530,
        POS_DailyCollectionReport = 9540,
        POS_FreeItemReport = 9550,
        POS_DailySalesDetail = 9560,
        POS_TransactionSummary_SalesRepWise = 9570,
        #endregion
    }
}