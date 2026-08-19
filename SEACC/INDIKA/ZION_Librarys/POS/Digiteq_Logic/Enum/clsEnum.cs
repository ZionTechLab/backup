using System.ComponentModel;

namespace Digiteq_Logic
{
    #region Search Enum
    public enum Search
    {
        Doc_Code = 1,
        Txn_Code = 2,
        SoftwareModules = 10,
        SEACC_Users = 15,

        #region Common
        FinancialYear = 5440,
        FinancialYearMonth = 5441,
        CompanyAccount = 5060,
        CompanyBranch = 5007,
        Banks = 5050,
        BankBranch = 5051,
        CreditNote = 5061,
        Form = 5030,

        Counter = 5008,
        Currency = 5006,

        //Cashier = 5009,
        SalesRep = 5010,
        Collector = 5018,
        Account = 5011,
        Employees = 5014,
        Users = 5025,
        SalesManager = 5026,
        SalesExecutive = 5027,

        SalesNoteType = 5004,
        QuotationTerms = 5400,
        ChequeTypes = 5410,
        APNType = 5460,
        PaymentMethod = 5470,
        ChequeStatus = 5108,
        ChequeStatus_2 = 5109,
        ChequeNo = 5113,

        Country = 5240,
        Province = 5241,
        District = 5242,
        City = 5243,
        Town = 5244,
        Towns = 5245,
        Division = 5040,
        Route = 5090,
        #endregion

        #region font Enum
        Font = 5500,
        #endregion

        #region Cutomer Master with Cutomer Relevant Enums
        Customer = 5002,
        Customer_All = 5009,
        CustomerMaster = 5211,
        CustomerInquary = 5012,
        CustomerBranches = 5013,
        Customer_ByControlAcc = 5017,
        CustomerClass = 5200,
        CustomerType = 5201,
        CustomerCategory = 5202,
        CustomerAccounts = 5207,
        #endregion

        #region Supplier Master with supplier Relevant Enums
        Supplier = 5015,
        Supplier_ByControlAcc = 5016,
        Customer_Supplier = 5019,
        #endregion

        #region Item Master with Item Relevant Enums
        //ItemMaster = 5000,
        //ItemMasterByCatagoryID = 5204,
        //ItemMasterInactive = 5205,

        Items = 5020,
        AreaManger=5021,
        ItemMasterByCategories = 5209,
        ItemMaster_SalesItem= 5210,

        ItemMasterByItemCode = 5200,
        ItemMasterByCompanyBranchID = 5203,
        ItemByStore = 5223,

        ItemClass = 5215,
        ItemType = 5216,
        ItemCategory = 5217,

        ItemCategoryFloorStock = 5206,
        ItemTypeByClassID = 5201,
        ItemCategoryIDByTypeID = 5202,
        ItemCategoryIDByClassID = 5208,

        Brand = 5218,
        UOM = 5219,
        Tag1 = 5220,
        Tag2 = 5221,
        Model = 5222,

        #endregion

        #region Store Master with Store Relevant Enums
        StoresList = 5003,
        StoreMaster = 5300,
        DepartmentStore = 5305,
        StoreMaster_GTN = 5301,
        StoreMaster_Damaged = 5302,
        #endregion

        #region SAS
        CustomerOrder_Direct = 7005,
        DeliveryOrder_Direct = 7006,
        Invoice_Direct = 7007,
        Invoice_2 = 7013,
        ExternalGoodReceivedNote_Direct_NoteType = 7008,
        ExternalGoodReceivedNote_Direct = 7009,
        ExternalGoodIssuedNote_Direct = 7010,
        SalesReceipt_Direct = 7014,
        DebitNote_direct = 7015,
        RefundableNote_direct = 7016,
        Transaction_Invoice_CustomerID = 7011,
        DeliveryOrder = 7012,

        Inquiry = 5800,
        Quotation = 5810,
        Quotation_Direct = 5840,
        Inquiry_Direct = 5830,
        CustomerOrder = 5820,
        PerformaInvoice = 5850,
        SalesReturnNote = 5860,
        #endregion

        #region SCS
        TransactionPurchaseOrder_Direct = 5130,
        SCS_storeReq = 5350,
        SCS_storeGIN = 5351,
        SCS_storeGRN = 5349,
        PurchaseReturnNote = 5600,
        ItemSplitNoteNote = 5601,
        Barcode = 5352,
        SCS_GTN = 5353,
        #endregion

        #region GL Search
        GL = 5103,
        SubGL = 5104,
        AccountType = 5105,
        GLAccount = 5106,

        GLName = 5250,
        SubGLName = 5251,
        AccTypeName1 = 5252,
        AccTypeName2 = 5256,
        AccName = 5253,

        SubGLName_PnlOnly = 5254,
        AccName_ControlTypes = 5255,
        AccName_InterCompany = 5257,
        #endregion

        #region Accounts
        ChequeRegister = 5100,
        ChequeregisterByCheque = 5101,
        ChequeregisterByPV = 5112,
        CashDeposites = 5102,
        APN_Direct = 5210,
        JouranalEntry = 5420,
        AccountReceipt = 5430,
        AccDebitNote = 5450,
        PaymentVoucherDirect2 = 5110,
        PaymentVoucherDirect2_All = 5111,
        CostCentre1 = 5114,
        CostCentre2 = 5115,
        zCost_Centre1 = 5116,
        zCost_Center2 = 5117,
        zCost_Center3 = 5118,
        zCost_Center4 = 5119,
        zChequeFormat = 5120,

        #endregion

        #region Fixed Assets
        FixedAssets = 5480,
        AssetsTransferNote = 5481,
        #endregion

        #region SEACC PCB
        Expenditures = 7400,
        #endregion

        #region R2 Factoring System (From 5050 - 5100)
        FactoringAgreement = 5070,
        FactoringSchedule = 5080,
        #endregion

        #region R2 Tender System (From 6000 - 6400)
        Tender = 6000,
        //Ten_Source = 5250,
        //DocumentList = 5251,
        //Users = 5252,
        Ten_ProjectSponsor = 6001,
        Ten_Delivery = 6002,
        Ten_Document = 6003,
        Ten_Competitors = 6004,
        Ten_RenewalTypes = 6005,
        Ten_DocumentRenewal = 6006,
        Ten_PreBidMeeting = 6007,
        Ten_ApplicationCollection = 6008,
        Ten_OfferLetter = 6009,
        Ten_AcceptanceLetter = 6010,
        #endregion

        #region R2 PCB (From 6500 to 7000)
        PCB_ExpCategory = 6500,
        PCB_IOURequest = 6501,
        PCB_IOU = 6502,
        PCB_ReimbursmentRequest = 6503,
        PCB_TransactionExpenditure = 6504,
        PCB_IncomeType = 6505,
        PCB_PCAccount = 6506,
        PCB_IOURefund = 6507,
        #endregion

        #region R2 Production System Modules (From 8000 to 9000)

        #region Prod Apparel (8000 - 8199)
        //8000 - 8090 Master Searches
        Prod_ProductionJob = 2000,
        Prod_ProductionSectionActivities = 8000,
        Prod_productRange = 8001,
        Prod_ProductCategory = 8002,
        Prod_ProcductionSections = 8003,
        Prod_ProductionJobName = 8004,
        Prod_ProductionDivision = 8006,
        Prod_ProdCustomerOrder = 8005,
        Prod_ProductionDepartment = 8007,
        Prod_ProductSize = 8008,
        Prod_ProductionContractor = 8009,
        Prod_ProductColour = 8010,
        Prod_ProdUsers = 8011,
        Prod_JobTypes = 8012,

        //8091 - 8199 Transaction Searches
        Prod_ProductionBoMJobs = 8100,
        Prod_ProductionSubBoMs = 8101,
        Prod_ProductionMeterialRequisition = 8102,
        Prod_ProductionBoMJobsMeterials = 8103,
        Prod_ProductionFinishedGoods = 8104,
        Prod_ProductionMaterials = 8105,
        Prod_ProductionSemiFinisheds = 8106,
        Prod_ProductionBoMJobs_Store = 8107,
        Prod_ProductionBoMJobs_CostApproved = 8108,
        Prod_SemiFiniseds_FinishedGoods = 8109,
        Prod_Batch = 8110,
        Prod_FGTN = 8111,
        Prod_ClosedBatches = 8112,
        Prod_ProductionBoMJobs_Locked = 8113,
        Prod_FGTNforStoresAcceptance = 8114,
        Prod_AllBatches = 8115,
        //Prod_PGIN_MRs = 8116,
        Prod_ProductionMR_Stores = 8117,
        //Prod_ProductionUnSetteledMR = 8118,
        Prod_FGTNAcceptance = 8119,
        #endregion

        #region Prod Pharma (8200 - 8399)

        //8200 - 8290 Master Searches
        ProdPharma_ProductionSectionActivities = 8200,
        ProdPharma_productRange = 8201,
        ProdPharma_ProductCategory = 8202,
        ProdPharma_ProcductionSections = 8203,
        ProdPharma_ProductionJobName = 8204,
        ProdPharma_ProductionDivision = 8206,
        ProdPharma_ProdCustomerOrder = 8205,
        ProdPharma_ProductionDepartment = 8207,
        ProdPharma_ProductSize = 8208,
        ProdPharma_ProductionContractor = 8209,
        ProdPharma_ProductColour = 8210,
        ProdPharma_ProdUsers = 8211,
        ProdPharma_JobTypes = 8212,

        //8291 - 8399 Transaction Searches
        ProdPharma_ProductionBoMJobs = 8300,
        ProdPharma_ProductionSubBoMs = 8301,
        ProdPharma_ProductionMeterialRequisition = 8302,
        ProdPharma_ProductionBoMJobsMeterials = 8303,
        ProdPharma_ProductionFinishedGoods = 8304,
        ProdPharma_ProductionMaterials = 8305,
        ProdPharma_ProductionSemiFinisheds = 8306,
        ProdPharma_ProductionBoMJobs_Store = 8307,
        ProdPharma_ProductionBoMJobs_CostApproved = 8308,
        ProdPharma_SemiFiniseds_FinishedGoods = 8309,
        ProdPharma_Batch = 8310,
        ProdPharma_FGTN = 8311,
        ProdPharma_ClosedBatches = 8312,
        ProdPharma_AllBatches = 8313,
        #endregion

        #region Prod Poly General (8400 - 8599)
        //8200 - 8290 Master Searches
        Prod_PolyProductionSectionActivities = 8400,

        //8291 - 8399 Transaction Searches
        Prod_PolyProductionBoMJobs = 8500,
        Prod_PolyProductionSubBoMs = 8501,
        Prod_PolyProductionMeterialRequisition = 8502,
        Prod_PolyProdProductionBoMJobsMeterials = 8503,
        Prod_PolyProductionFinishedGoods = 8504,
        Prod_PolyProductionMaterials = 8505,
        Prod_PolyProductionSemiFinisheds = 8506,
        Prod_PolyProductionBoMJobs_Store = 8507,
        Prod_PolyProductionBoMJobs_CostApproved = 8508,
        Prod_PolyFinishedGoodSpecSheet = 8509,
        #endregion

        #region Prod Polythe / AKT (8600 - 8799)
        ProdPoly_ProductionJob = 8650,
        #endregion

        #endregion

        #region R2 Point of Sales (From 9100 to 9500)
        //add by janith -  those enums are used in older version of POS
        ReturnReceipt = 5001,
        Transactions = 5005,

        // Master Data Search (9100 - 9249)
        Pos_ItemSearch_Main = 9100,
        Pos_GiftVouchers_NotIssued = 9110,
        Pos_GiftVouchers_Issued = 9111,
        Pos_ItemRemarks = 9115,
        Pos_ShopBranches = 9120,
        Pos_CustomersWithBranches = 9130,
        Pos_ReportSearch = 9140,
        Pos_CreditPeriod = 9150,
        Pos_SesonalGreeting = 9160,
        Pos_Merchant_Device = 9170,

        // Transation Data Search (9250 - 9500)
        Pos_Transactions = 9250,
        Pos_Transactions_CancelFilter = 9251,
        Pos_SoldItems = 9255,
        POS_CRNs = 9260,
        POS_CRNs_NotRedeem = 9265,
        POS_Advance = 9270,
        POS_Advance_NotRedeem = 9275,
        #endregion
    }
    #endregion

    #region Message Types
    public enum MessageType
    {
        AskForSave = 0,
        SaveDone = 1,
        SaveCancel = 2,
        DataBaseError = 3,
        ErrorOnInput = 4,
        AskForModify = 5,
        ModifyDone = 6,
        ModifyCancel = 7,
        ValidateUserName = 8,
        ValidateUserGroup = 9,
        ValidatePassword = 10,
        Common = 11,
        IOErrors = 12,
        RegistryError = 13,
        ValidateaControlLength = 14,
        AskForDelete = 15,
        DeleteDone = 16,
        ItemNotFound = 17,
        IDIsEmpty = 18,
        PermissionToRead = 19,
        PermissionToWrite = 20,
        PermissionToUpdate = 38,
        PermissionToDelete = 21,
        PermissionToApprove = 22,
        PermissionToCheck = 23,
        RecordLocked = 24,
        DatabaseBackup = 25,
        FileCopied = 27,
        SoftwareExpired = 28,
        SoftwareUpdate = 29,
        SoftwareExpired9182 = 30,
        AskForLineClose = 31,
        LineCloseDone = 32,
        AskForSectionClose = 33,
        SectionCloseDone = 34,
        PermissionToSectionClose = 35,
        CreditLimitExceedMessage = 36,
        CreditLimitExceedLock = 37,
        AlreadyDeleted = 39,
        AlreadyPrinted = 40,
        RecordLockedCantDelete = 41,
        GINdoneForSRN = 42,
        GRNdoneForGIN = 43,
        AlreadyActive = 44,
        CustomerIsBlackListed = 45,
        SupplierIsBlackListed = 46,
        SupplierIsSuspended = 47,
        DucumentPrinted = 48,
        VersionInCompatible = 49,
        RecordUpdateIsBlock = 50,
        PermissionToPrint = 51,
        GLPostedtransactions = 61,
        UserIsBlocked = 62,
        GLInvalidFinancialYear = 63,
        PurgeDone = 64,
        GRNdoneForPO = 65,
        MainStoreNotAllowed = 66,
        ApproveProdibit = 67,
        AlreadyApproved = 68,
        PermissionToWrite_Store = 69,
        PermissionToUpdate_Store = 70,
        AskForChecked = 71,
        AskForApproved = 72,
        InvalidAmount = 73,
        EnterMinusValues = 74,
    }
    #endregion

    #region Message Type POS
    public enum MessageType_POS
    {
        AskForSave = 0,
        SaveDone = 1,
        SaveCancel = 2,
        DataBaseError = 3,
        ErrorOnInput = 4,
        AskForModify = 5,
        ModifyDone = 6,
        ModifyCancel = 7,
        ValidateUserName = 8,
        ValidateUserGroup = 9,
        ValidatePassword = 10,
        Common = 11,
        IOErrors = 12,
        RegistryError = 13,
        ValidateaControlLength = 14,
        AskForDelete = 15,
        DeleteDone = 16,
        ItemNotFound = 17,
        IDIsEmpty = 18,
        PermissionToRead = 19,
        PermissionToWrite = 20,
        PermissionToUpdate = 38,
        PermissionToDelete = 21,
        PermissionToApprove = 22,
        PermissionToCheck = 23,
        RecordLocked = 24,
        DatabaseBackup = 25,
        FileCopied = 27,
        SoftwareExpired = 28,
        SoftwareUpdate = 29,
        SoftwareExpired9182 = 30,
        AskForLineClose = 31,
        LineCloseDone = 32,
        AskForSectionClose = 33,
        SectionCloseDone = 34,
        PermissionToSectionClose = 35,
        CreditLimitExceedMessage = 36,
        CreditLimitExceedLock = 37,
        AlreadyDeleted = 39,
        AlreadyPrinted = 40,
        RecordLockedCantDelete = 41,
        GINdoneForSRN = 42,
        GRNdoneForGIN = 43,
        AlreadyActive = 44,
        CustomerIsBlackListed = 45,
        SupplierIsBlackListed = 46,
        SupplierIsSuspended = 47,
        DucumentPrinted = 48,
        VersionInCompatible = 49,
        RecordUpdateIsBlock = 50,
        PermissionToPrint = 51,
        GLPostedtransactions = 61,
        UserIsBlocked = 62,
        GLInvalidFinancialYear = 63,
        PurgeDone = 64,
        GRNdoneForPO = 65,
        MainStoreNotAllowed = 66,
        ApproveProdibit = 67,
    }
    #endregion

    #region Message Type General Error
    public enum MessageTypes_GenaralError
    {
        BackDateError = 1,
        ForwardDateError = 2,
    }
    #endregion

    #region Status Strip Message Types
    public enum StatusStripMessageTypes
    {
        WhenInsert = 0,
        WhenUpdate = 1,
        WhenDelete = 2,
        Afterinsert = 3,
        AfterCancel = 4,
        DataGridClick = 5,
        Afterupdate = 6,
        WhenInserNumber = 7,
    }
    #endregion

    #region Date Formats
    public enum DateFormats
    {
        DD_MM_YYYY = 0,
        DD_MM_YYYYF1 = 1,
        DD_MM = 2,
        DD_MMF1 = 3,
        MM_DD_YYYY = 4,
        MM_DD_YYYYF1 = 5,
        MM_DD = 6,
        MM_DDF1 = 7,
        Wednestady_March_15_2007 = 8,
    }
    #endregion

    #region Form Name Enums
    public enum FormName
    {
        UC_psmWorkInProgress = 900000,

        defaultForm = 0,
        ItemMaster = 1,
        CustomerMaster = 2,
        SupplierMaster = 3,

        //SupPurchaseOrder = 4,
        //GoodReceiveNote = 5,
        //SupplierReturnNote = 6,

        CustomerOrder = 9,
        VATInvoice = 10,
        Invoice_TAXReverced = 610,

        GoodIssueNote = 7,
        IssueReturnNote = 8,

        CusDeliveryOrder = 11,
        JobOrder = 12,
        StoreRequisitionNote = 13,
        //GoodTransferNote = 14,
        scsGoodTransferNote = 14,
        LoanIn = 15,
        LoanOut = 16,
        DamageGoodIssue = 17,
        //DamageDiscard = 18,
        ChequeRegister = 19,

        Receipt = 21,
        CusSalesInquary = 22,
        CusQuotation = 23,
        CusProformaInvoice = 24,
        CompanyInfor = 25,
        UserMaster = 26,
        UserPermission = 27,
        CompanyBankAcc = 660,

        ReportMaster = 29,


        ReportChequeManagement = 32,
        MasterOther = 33,
        ZCountry = 34,
        ZBank = 35,
        ZCustomerCategory = 36,
        ZCustomerType = 37,
        ZCustomerClass = 38,
        ZSupplierClass = 39,
        ZSupplierType = 40,
        ZSupplierCategory = 41,
        ZItemClass = 42,
        ZFontType = 1999,
        ZChequeFormat = 1998,
        ZItemType = 43,
        ZItemCategory = 44,
        DatabaseBackup = 45,
        ZArea = 46,
        ZRoute = 47,
        ZBranch = 48,
        ZDistrict = 49,
        ZProvince = 50,
        ZCity = 51,
        ZTwon = 52,
        EmployeeMasterViewer = 53,
        ZUomCategory = 54,
        ZUom = 55,
        ZEmpSalesManager = 56,
        ZEmpAreaManager = 57,
        ZEmpSalesExecutive = 58,
        ZEmpSalesRep = 59,
        ChequeTracer = 60,
        ReportSalesRegistry = 61,
        sasGRNTradingStock = 62,
        sasGINTradingStock = 63,
        sasSRNTradingStock = 64,
        ReportBankManagement = 65,
        ReportBillsRegister = 80,
        ReportCustomized=81,
        ReportChequeStanded = 66,
        ReportSalesStanded = 67,
        PreCosting = 68,
        MachineMaster = 69,
        JobRegister = 70,
        ZDriver = 71,
        ZAssistant = 72,
        ZVehicle = 73,
        ZMachineClass = 74,
        ZMachineType = 75,
        ZMachineCategory = 76,
        ZMachineSpecification = 77,
        ItemRowMaterial = 78,
        ItemSemiFinishedGood = 79,
        JobViewer = 82,
        ZMachineSubCategory = 83,
        ZMachineSubSpecification = 84,
        ZItemSpecification = 85,
        ZItemSubCategory = 86,
        ZItemSubSpecification = 87,
        ItemFinishedGood = 88,
        CompanyCountryMasrter = 89,
        CompanyBranchMaster = 90,
        CompanyDivitionMaster = 91,
        CompanyDepartmentMaster = 92,
        CompanySectionMaster = 93,
        CompanyMaster = 94,
        PrePlanSection = 95,
        Alerts = 96,
        CompanyStoreMaster = 97,
        CashRecipts = 98,
        ItemCombinationMaterail = 99,
        ProductJobRejister = 100,
        WorkInProgress = 101,
        PettyCashAccount = 102,
        UpdatePettyCashAccounts = 103,
        zPettyCashIncomeType = 104,
        zPettyCashExpenditureType = 105,
        PettyCashPermission = 106,
        ViewerCombinationMaterial = 11106,
        ViewerFinishedGood = 107,
        ViewerRawMaterial = 108,
        ViewerLaminatedMaterial = 109,
        ViewerSemiFinished = 110,
        ViewerSectionViwer = 111,
        ViewerMachineLineViwer = 112,
        scsGRNSectionStock = 113,
        scsGINSectionStock = 114,
        scsSRNSectionStock = 115,
        ProductionItemMaster = 116,
        ReportPettyCashAccount = 117,
        ReportItemSummery = 118,
        ReportFlowStock = 119,
        OffcutEntry = 120,
        ViewerSemiFinishedGood = 121,
        ReportDailyPlanning = 122,
        ReportDailyProduction = 123,
        ReportSectionStockTransfer = 124,
        ReportStoreStockTransfer = 125,
        //scsGoodTransferNote = 126,

        scsQuotaionRequest = 127,
        scsPOSupplier = 128,
        scsGRNSupplier = 129,
        scsPRNSupplier = 130,
        scsGINExternal = 131,
        scsDamagedGoodsNote = 132,
        scsDiscardedGoodsNote = 133,
        sasSRNCustomer = 134,
        bssCreditNote = 135,
        bssCreditNote_TW = 671,
        bssInvoiceSettlement = 136,
        bssCashPayment = 137,
        bssChequePayment = 138,
        bssChequeReturn = 139,
        bssDebitNote = 140,
        bssDebitNoteNew = 638,
        bssGRNSettlement = 141,
        ReportDailyProductionProgress = 142,
        ReportJobCostAnalysis = 143,
        scsGTNSummaryReport = 438,
        scsGRNGemTool = 439,
        accContraVoucher = 440,
        bssCustomerRefundableNote = 441,
        scsAddBarcode = 443,
        bssIntercomapnyTransaction = 663,

        AccountCashBookReceipt = 144,
        AccountMasterCategory = 145,
        AccountSubCategory = 146,
        AccountFicalYear = 147,
        AccountHead = 148,
        AccountTypes = 149,
        AccountMaster = 150,
        AccountCashBookPaymente = 151,
        PaymentAdvice = 152,
        ItemLaminatedMaterial = 153,
        EmployeeMaster = 154,
        sasInquiry = 155,
        scsStockAdjusment = 156,
        zTax = 157,
        ViewerInvoice = 158,
        scsStockAdd = 159,

        //scsTradingGoodReceiveNote = 160,

        ZLaminationType = 162,
        ZLaminationMaterialType = 163,
        zBrand = 164,
        zEmpSupervisor = 165,
        zEmpOperator = 166,
        zEmpAssistant = 167,
        zOrderRefNo = 168,
        ReportSalesPendingOrder = 169,
        ReportSalesRegister = 170,
        ViewerCustomer = 171,
        NonTaxInvoice = 172,
        zSchedule = 173,
        ManageRoute = 174,
        ReportSalesStranded = 175,
        sasSalesReturenNote = 176,
        ProductionJobClose = 177,
        GroupApproval = 178,
        zIssuedRefNo = 179,
        ReportProdutionJobWiseInputOutput = 180,
        zPaper = 181,
        zPaymentMethod = 182,
        ReportPmsDelivery = 183,
        ViewerCustomerOrder = 279,

        SecurityConfigType_Status = 184,
        SecurityConfigTypeValue = 185,
        SecurityConfigValue = 186,
        SecurityConfigStatus = 187,
        SecuritySoftwareModel = 188,
        SecurityProjects = 189,
        SecurityTerminal = 190,
        SecurityItemExceedLock = 191,
        scsStoreProduction = 192,
        ZCurrency = 193,
        PrinterMaster = 194,
        ReportPermission = 195,
        sasItemSparadeNote = 196,
        scsStockStandedReport = 197,

        sasCustomerOrderViewer = 198,
        sasDeliveryOrderViewer = 199,
        sasInquiryViewer = 200,
        sasInvoiceViewer = 201,
        bpsReceiptTracer = 202,

        Chat = 203,
        UserManagement = 204,
        UserControl = 205,

        RetruendChequeDebitInvoice = 205,
        ReDepositeChequeCreditNote = 671,
        ReportPsmJobWise = 206,
        DocumentAudit = 207,
        AccountReceivableReports = 208,
        AccountReceivableReports_New = 1208,
        TaxReports = 1200,
        AccountPayableReports = 378,
        ReportPsmSectionWise = 209,
        StockRegisterReport = 210,
        CustomerOrderEdit = 211,
        PendingApproval = 212,
        PendingChecking = 213,
        UserPermission_PendingApproval = 214,
        UserPermission_PendingChecking = 215,


        itemSubCateogry1 = 217,
        itemSubCateogry2 = 218,
        UserPermission_Audit = 219,


        Level_1 = 220,
        Level_2 = 221,
        Level_3 = 222,
        Level_4 = 223,
        Cost = 224,

        SectionCloser = 225,
        ProgressReport = 226,
        DeliveryPlan = 227,

        Cost_Center1 = 625,
        Cost_Center2 = 228,
        Cost_Center3 = 229,
        Cost_Center4 = 230,

        ProfitAndLost = 231,
        PettyCashMasterReport = 232,
        ReportSetting = 233,
        AutoGenarateNumberSetting = 234,
        PettyCashAccountBasic = 235,
        JobPolytheneMeterialType = 236,
        JobMarckupPrecentage = 237,
        ColourMaster = 238,
        DateSettings = 239,
        DeliveryOrderMenualSettings = 240,
        ConfigMail = 241,
        OrderReferanceUpdate = 242,

        bssChequeReDeposite = 244,
        AccountRegisterReports = 245,
        SalesTools = 246,
        FinanceMaster = 247,
        ReportJobCostAnalysisSummary = 248,
        CustomReport = 249,
        Alert = 250,
        AlertHome = 280,
        AlertMaster = 281,
        bpsReceiptPaymentAdviceSubAgent = 251,
        StockControlPanel = 252,
        PurchaseRequisition = 253,
        ItemMasterFinance = 254,
        InterimReceipt = 255,
        SVATInvoice = 256,

        Invoice_FreeIssues = 607,
        Invoice_LineDiscount = 608,
        Customer_wice_discount_Permishion = 609,

        CustomerMasterReport = 257,
        StockTransferManualSettle = 258,
        StockTool = 259,
        scsGRNDeparmentStock = 260,
        scsGINDeparmentStock = 261,
        scsSRNDeparmentStock = 262,
        detailsStockStaement = 263,
        MISReports = 264,
        Matfor = 265,
        MatforDataEntry = 266,
        MatforForecast = 267,
        sasCustomerOrderEditPO = 268,
        sasInvoiceOrderRefEdit = 270,
        PettyCashReimbursement = 271,
        AdminStandardReport = 272,
        AdminRegisterReport = 399,
        MessageDongleSettings = 273,
        SampleIssued = 274,
        AlertConfiguration = 275,
        SalesReturndForReturnable = 276,
        sasGINTradingStockUPL = 277,
        ProductionJobManualSettle = 278,
        PurgeTool = 279,
        PatternSize = 283,
        PatternLength = 284,
        ChequeType = 285,
        CreditNoteType = 286,
        DebitNoteType = 287,
        zGiftVoucherMaster = 288,
        bssOverPaymentReceipt = 289,
        ReceiptAllocation_PartPayment = 290,
        ReceiptAllocation_AdvancePyament = 291,
        ReceiptAllocation_OverPayment = 292,
        CreditNoteAllocation = 293,
        ReportFlowStock_DAPL = 294,
        UserPermissionStoreWise = 516,
        //acc
        accFinancial = 400,
        accGeneralLedger = 401,
        accSubGeneralLedger = 402,
        accAccountType1 = 403,
        accAccountType2 = 470,
        accAccount = 404,
        accAccountCode = 450,
        ReportChartOfAccounts = 405,
        ReportAccountStanderd = 600,
        accReceiptVoucher = 406,
        accDoubleEntrySlot = 407,
        PendingSlotPosting = 408,

        accPaymentVoucher = 410,
        accGLNote = 411,
        zAccCostCenter = 412,
        zAccCostCenter2 = 413,
        AccountsMaster = 414,
        accAccountpayableNote = 415,
        AccountRegisterReport = 416,

        accOpeningBalance = 419,
        accBatchPosting = 420,
        AccCostCenter = 421,
        accReportBuilder = 422,
        accReportItemLevel1 = 423,
        accReportItemLevel2 = 424,
        accReportItem = 425,
        accChequeRegister = 426,
        accIncReportBuilder = 427,
        accIncReportItemLevel1 = 428,
        accIncReportItemLevel2 = 429,
        accIncReportItem = 430,
        accRevercePosting = 434,
        ReverceSlotPosting = 435,
        accDebitNote = 437,
        accDebitNote_New = 1437,
        accSystemSynchronization = 450,
        accReports = 451,
        accUpdateOpbalance = 452,
        accAPNSettlement = 453,
        accCreditorSettlement = 350,
        accSupplierJournalTrackingReport = 454,
        accNotPostedTransactions = 461,
        accAccountpayableNote_Allocation = 661,

        accJournalEntry = 409,
        accJournalEntry_Standard = 417,
        accJournalEntry_Bank = 418,
        accJournalEntry_Creditor = 630,
        accJournalEntry_Debtor = 631,
        accFixedAssetRegistration = 632,
        accAssetTransferNote = 633,
        accJournalEntry_Advance = 637,

        accSupplierOB = 634,
        accCustomerOB = 635,

        //financial year creation - 2017-11-07
        accFinancialCreation = 662,

        //POS TRANSACTION LEDGER POSTING
        POS_TransactionLedgerPosting = 670,


        //Bills
        ChequeManage = 20,
        ChequeDeposit = 28,
        ChequeReDeposit = 216,
        ChequeReIssue = 30,
        ChequeReconsiliation = 31,
        //ChequeOutwardReconsiliation = 282, 
        CashDepositeCode = 243,
        SalesCommision = 380,
        EmployeeSlabSettings = 381,
        BillsTools = 295,
        BankReconcilation = 666,

        BankReconcilationStatement = 668,

        

        scsBarcodePrint = 669,

        //gem
        ZGem = 431,
        ZMettle = 432,
        CustomerReport_Stock = 436,


        //Old Pos
        POSStoreCommomGrid = 500,
        POSCustomerCommomGrid = 501,
        POSDOCommomGrid = 502,
        POSCOCommomGrid = 503,
        POSCardPayment = 504,
        POSRedeem = 505,
        POSDiscount = 506,
        POSBillReprintAndReturn = 507,
        POSAdvanceSearch_Item = 508,

        //Tolls
        sasAllocationRemove = 509,

        pmsSectionPlanning = 510,
        zCommissionSlabSetting = 511,
        AccReciptGlAccountTaging = 512,
        LoanSettlement = 513,
        Budget = 514,
        zTheme = 515,

        //Production
        proProductionPlan = 601,
        proWorkInProgress = 602,

        //SAS Toll
        DeliveryOrderRemarkEdit = 603,
        ChequeToNewMode = 615,
        CashDepositCancelation = 616,
        sasCustomerOrderManuallySettleTool = 617,
        ChequeToNewModePV = 618,
        ChequeToNewMode_NewVersion = 626,
        CashDepositCancelation_NewVersion = 627,

        //SCS Toll
        PoDiscountEdit = 604,
        TemporaryProductionJobCreation = 605,

        PmsWeeklySectionPlaning = 606,

        ZItemTag1 = 612,
        ZItemTag2 = 611,
        ItemMasterCustomerWiseSalesCode = 613,


        //Sales 
        SalesInvoice2 = 620,
        UCReceipt = 621,

        CashRegister = 622,
        CardRegister = 623,
        BankTransferRegister = 624,

        ReportSalesCustom = 628,
        ReportStockCustom = 629,


        //Cheque Factoring
        #region Factoring Forms (6000-6200)
        Fac_Agrement = 6000,
        Fac_Interest = 6001,
        Fac_Schedule = 6002,
        Fac_Settings = 6003,
        Fac_Bank = 6050,
        Fac_BankBranch = 6051,
        Fac_ChequeMgt = 6052,
        Fac_ChequeMgt_Confirmation = 6053,
        Fac_ChequeMgt_Deposit = 6054,
        Fac_ChequeMgt_Reconcilation = 6055,
        Fac_CompanyAccount = 6060,
        Fac_InterestRateHistory = 6080,
        #endregion

        #region Tender (6200-6500)
        //Forms
        Tender = 6200,
        DocumentList = 6201,
        TenderReading = 6202,
        PreBidMeeting = 6203,
        TenderItems = 6204,
        OfferLetter = 6205,
        PurchaseOrder = 6206,
        AcceptanceLetter = 6207,
        TenderSecurity = 6208,
        DocumentLicenceRenewal = 6209,
        DocumentLicenceRenewal2 = 6211,
        TenderClosure = 6210,
        GRNBatchDetails = 6212,

        //Viewers
        TenderDocumentLicenceViewer = 6290,


        //Masters
        Customer = 6225,
        Item = 6230,
        ResponseDocList = 6235,
        ProjectSponsor = 6240,
        TenSupplierMaster = 6245,
        Competitors = 6250,
        TenManufacturer = 6255,

        #endregion

        EmailBox = 1000,

        Report = 1100,

        Attachments = 1050,
        AttachmentsConfiguration = 636,

        accSupplierJournalTrackingReport2 = 680,

        #region R2 Production System Modules (From 7000 - 8000)
        //started from March 2017 - Gayan

        #region Prod Apparel (7000 - 7199)
        //7000 - 7089 for Masters
        Prod_SectionActivity = 7000,
        Prod_ProductCategory = 7001,
        Prod_JobNames = 7002,
        Prod_Sections = 7003,
        Prod_ProductRanges = 7004,
        Prod_ProductSizes = 7005,
        Prod_ProductColours = 7006,
        Prod_SemiFinishedOutsource = 7007,
        Prod_JobTypes = 7008,

        //7090 - 7199 for Transactions
        Prod_ProductSpecSheet = 7090,
        Prod_ProductonPlaning = 7095,
        Prod_BOMCreation_Sales = 7100,
        Prod_BOMDetails_Production = 7101,
        Prod_BOMCosting_Finance = 7102,
        Prod_MeterialRequisition = 7103,
        Prod_GoodsIssues = 7104,
        Prod_GoodsReturns = 7105,
        Prod_SubContract_Out = 7106,
        Prod_SubContract_In = 7107,
        Prod_WIP = 7108,
        Prod_FGTN = 7109,
        Prod_BOMClosure = 7110,
        Prod_BOMDetails_Production_SpecialPermission = 7111,
        Prod_Prod_BOMCosting_Finance_SpecialPermission = 7112,
        Prod_BOMRemoving = 7113,
        Prod_BOM_PostCosting = 7114,
        Prod_BatchCreation = 7115,
        Prod_FGTN_Acceptance = 7116,
        Prod_SplitNote = 7117,
        Prod_FGTN_DetailView = 7118,
        #endregion

        #region Prod Pharma (7200 - 7399)
        //7200 - 7289 for Masters
        ProdPharma_SectionActivity = 7200,
        ProdPharma_ProductCategory = 7201,
        ProdPharma_JobNames = 7202,
        ProdPharma_Sections = 7203,
        ProdPharma_ProductRanges = 7204,
        ProdPharma_ProductSizes = 7205,
        ProdPharma_ProductColours = 7206,
        ProdPharma_SemiFinishedOutsource = 7207,
        ProdPharma_JobTypes = 7208,

        //7290 - 7399 for Transactions
        ProdPharma_ProductSpecSheet = 7290,
        ProdPharma_ProductonPlaning = 7295,
        ProdPharma_BOMCreation_Sales = 7300,
        ProdPharma_BOMDetails_Production = 7301,
        ProdPharma_BOMCosting_Finance = 7302,
        ProdPharma_MeterialRequisition = 7303,
        ProdPharma_GoodsIssues = 7304,
        ProdPharma_GoodsReturns = 7305,
        ProdPharma_SubContract_Out = 7306,
        ProdPharma_SubContract_In = 7307,
        ProdPharma_WIP = 7308,
        ProdPharma_FGTN = 7309,
        ProdPharma_BOMClosure = 7310,
        ProdPharma_BOMDetails_SpecialPermission = 7311,
        ProdPharma_BOMCosting_SpecialPermission = 7312,
        ProdPharma_BOMRemoving = 7313,
        ProdPharma_BOM_PostCosting = 7314,
        ProdPharma_BatchCreation = 7315,
        ProdPharma_FGTN_Acceptance = 7316,
        ProdPharma_SplitNote = 7317,
        ProdPharma_FGTN_DetailView = 7318,

        #endregion

        #region Prod Ploythene / From AKT - (7600 - 7799)
        prodPoly_WorkingProgress = 7625,
        ProdPoly_proWeigningSerial = 7650, 
        prodPoly_WorkingProgress_Input = 7660,
        prodPoly_WorkingProgress_Output = 7665,
        #endregion

        #region Prod User Management (7800 onwards)
        //7800 - Onwards for User Management Activities
        Prod_UserDashBoard = 7800,
        #endregion

        #endregion

        #region R2 Point of Sales Module (From 9090 to 9500)

        POS_CashierSignIn = 9090,
        POS_Transaction = 9100,
        POS_SalesReturn = 9105,
        POS_GiftVoucherCreation = 9110,
        POS_ManagerSignOff = 9115,
        POS_BranchDayEnd = 9117,
        POS_BranchWiseStoreStock = 9120,
        POS_AdvancePayment = 9125,
        

        POS_UserDashBoard = 9480,
        POS_Reports = 9500,
        #endregion


        #region R2 Petty Cash (From 800 - 900)
        PCB_IncomeType = 800,
        PCB_ExpenditureType = 801,
        PCB_ExpenditureCategory = 802,
        PCB_PettyCashAccCreation = 803,
        PCB_IOURefund = 805,
        PCB_IOURequest = 806,
        PCB_PettyCashBook = 807,
        PCB_AddExpenditure = 808,
        PCB_AddIOU = 809,
        PCB_ReimbursmentRequest = 810,
        PCB_IOUSettlement = 811,
        pcb_Reports = 812,
        
        #endregion

    }
    #endregion

    #region Cheque Status
    public enum ChequeStatus
    {
        New = 0,
        Deposited = 1,
        ReIssued = 2,
        Realized = 3,
        Returned_R = 4,
        Returned_NR_C = 5,
        Returned_NR_O = 6,
        ReDeposited = 7,
        ReturnedToSender = 8,
        Deleted = 9,
        Default = 10,
        Reserved_For_Factoring = 20,
        Factored = 21,
        Factoring_Deposited = 22
    }
    #endregion



    //Cheque Register Transfers
    #region Payment Methods
    public enum PaymentMethod
    {
        Cash = 0,
        Cheque = 1,
        Card = 2,
        Loyality_Card = 3,
        Voucher = 4,
        Gift_Voucher = 5,
        Bank_Transfer = 6,
        Credit_Note = 9,
        Advance_Receive = 10,
        OneGalleFaceRwards = 11,
    }
    #endregion

    #region Transaction Activity
    public enum TxnActivity
    {
        Insert=0,
        Update=1,
        Cancel=2,
        CheckBy=3,
        ApprovedBy=4,
        PrintDraft=5,
        PrintOriginal=6
    }
    #endregion

    #region Select Area
    public enum SelectArea
    {
        Default = 0,
        Department = 1,
        Section = 2,
        Store = 3,
    }
    #endregion


    #region Config Status
    public enum ConfigStatus
    {
        DOBreakdownQtyIsDOQty = 1,
        DOBreakdownWeightIsDOWeight = 2,
        AutoInvoiceSettleWhenChequeRegister = 3,
        AutoInvoiceSettleWhenCashReceipt = 4,
        AutoInvoiceSettleWithCreditNote = 5,
    }
    #endregion

    #region Config Active Value
    public enum ConfigActiveValue
    {
        DisplayCustormizedGrid = 1,
    }
    #endregion

    #region Item Types
    public enum ItemTypes
    {
        Default = 0,
        RawMaterial = 1,
        SemiFinishedGood = 2,
        FinishGood = 3,
        CombinationMaterial = 4,
        LaminatedMaterial = 5,
    }
    #endregion

    #region Item Search Types
    public enum ItemSearchType
    {
        Basic = 0,
        Transaction = 1,
        Advance1 = 2,
        Advance2 = 3,
        Stock = 4,
        Transaction_SearchBYItemCode = 5,
    }
    #endregion

    #region Item Class
    public enum ItemClass
    {
        Default = 0,
        Production = 1,
        Trading = 2,
    }
    #endregion

    #region Config Item Exceed Lock
    public enum ConfigItemExceedLock
    {
        Inquiry = 0,
        Quotation = 1,
        CustomerOrder = 2,
        ProformaInvoice = 3,
        DeliveryOrder = 4,
        Invoice = 5,
    }
    #endregion


    #region Software Model Sales
    public enum SoftwareModel_Sales
    {
        ePackWithDimension = 0,
        ePackWithoutDimension = 1,
        ePackWithSubCategory = 2,
        ePackWithSerialNumber = 3,
        ePackWithRemark = 4,
        ceilingAndWallPanal = 5,
        idealWheels = 6,
        akt = 7,
        aktN2 = 8,
        //   gem = 9,
        jj = 10,
        trading = 11,
        production = 12,
    }
    #endregion

    #region Job Measurement Types
    public enum JobMeasurementType
    {
        Milimeter = 0,
        Centimeter = 1,
        Inch = 2,
        Meter = 3,
        Yard = 4,
    }
    #endregion

    #region Approval Status
    public enum ApprovalStatus
    {
        PendingApproval = 0,
        Approved = 1,
        Rejected = 2,
        OnHold = 3,
    }
    #endregion

    #region Weight Calculation Types
    public enum WeightCalculation_Types
    {
        AKT = 0,
        PolyPS = 1
    }
    #endregion

    #region Process Note
    public enum ProcessNote
    {
        Inquiry = 1,
        Quotation = 2,
        SalesJob = 3,
        CustomerOrder = 4,
        PickingNote = 5,
        ProductionJob = 6,
        DeliveryOrder = 7,
        ProforemaInvoice = 8,
        Invoice = 9,
        Receipt = 10,
        Cheque = 11,
        SalesReturned = 12,
        CreditNote = 13,
        bssDebitNote = 14,
        ReturnedCheque = 15,
        iSR_Store = 16,
        iGIN_Store = 17,
        iGRN_Store = 18,
        SupplierGoodReceive = 19,
        PurchaseOrder = 20,
        PurchaseReturned = 21,
        StockAdjustment = 22,
        iSR_Dept = 23,
        iGIN_Dept = 24,
        iGRN_Dept = 25,
        LoanIn = 26,
        LoanOut = 27,
        FinishedGoodsTransferNote = 28,
        ExternalGoodReceivedNote = 29,
        AlertConfiguration = 30,
        CustomerMaster = 31,
        SupplierMaster = 32,
        ItemMaster = 33,
        accDebitNote = 34,
        AccountPayableNote = 35,
        PaymentVoucher = 36,
        BudgetPlan = 37,
        ExternalGoodIssuedNote = 38,
        PurchaseRequisition = 39,
        GoodsTransferNote = 40,
        ItemSplitNote = 41,
        DamageGoodNote = 42,
        DisGoodNote = 43,
    }
    #endregion

    #region Login Status
    public enum LoginStatus
    {
        Online = 1,
        Idle = 2,
        Offline = 3,
    }
    #endregion

    #region GL Values
    public enum GLValues
    {
        SubGLReduNumber = 1,
        SubGLAddNumber = 2,
        AcctTypeReduNumber = 3,
        AcctTypeAddNumber = 4,
        AcctCodeReduNumber = 5,
        AcctCodeAddNumber = 6,
        GLAddNumber = 7,
    }
    #endregion

    #region Audit Message
    public enum AuditStatus
    {
        RecordSave = 1,
        RecordDelete = 2,
        RecordModify = 3,
        ViewReport = 10,
        PrintReport = 11,
        ExportReport = 12,
    }
    #endregion

    #region Credit Note Type
    public enum CreditNoteType
    {
        OpenningBalance = 0,
        SalesReturnsLocal = 1,
        ReturnedChequeDeposit = 2,
        InvoiceAdjustment = 3,
        CoinAdjustment = 4,
        BankCharges = 5,
        SalesReturnsExport = 6,
        BlockChages = 7,
        BadDebts = 8,
    }
    #endregion

    #region Debit Note Type
    public enum DebitNoteType
    {

        OpenningBalance = 0,
        ChequeReturns = 1,
        UnderInvoice = 2,
        AdvanceRefund = 3,
        OverpaymentRefund = 4,
        Inter_Company_Transfer = 5
    }
    #endregion

    #region Recommended Unit Price
    public enum RecommendedUnitPrice
    {
        sellingPrice1 = 0,
        sellingPrice2 = 1,
        sellingPrice3 = 2,
        sellingPrice4 = 3,
        wholesalePrice = 4,
        sellingPrice1_WithTaxCalculation = 5
    }
    #endregion

    #region Weight Price
    public enum RecommendedWeightPrice
    {
        kiloPrice = 0,
    }
    #endregion

    #region Tax
    public enum Tax
    {
        NBT = 0,
        VAT = 1,
        NONE = 2,
    }
    #endregion

    #region GL Posting Status
    public enum GLPostingStatus
    {
        NewTransaction = 1,
        Unposted = 2,
        Posted = 3,
        Error = 4,
        ReChqDeposite = 5,
        ReChqReturn = 6,
    }
    #endregion

    #region Job Percentage
    public enum JobPercentage
    {
        JobMarckup = 37,
        JobGenaralOverhead = 38,
    }
    #endregion

    #region Accounts Slot
    public enum AccSlot
    {
        NonTaxInvoice = 1,
        TaxInvoice = 2,


        PaymetVoucher = 7,
        AccountReceipt = 8,
        AccountPayableNote = 9,
        JournalVoucher = 10,
        Customer_DebitNote = 11,
        Customer_CreditNote = 12,
        ChequeDeposit = 13,
        SalesReturnNote = 14,
        DeliveryNote = 15,
        PurchaseReturn = 16,
        StandardJournalEntries = 17,
        GoodReceivedNote = 18,
        BankAdjustmentEntries = 19,
        PurchaseOrder = 20,
        ExportSVATSales = 21,
        ExportTaxSales = 22,
        LocalNonTaxSales = 23,
        LocalTaxSales = 24,
        CashDeposit = 25,
        PaymetVoucherChequeRealized = 26,
        ReissuedCheques = 27,
        ChequeReturned = 28,
        Supplier_DebitNote = 29,
        //   ReDeposit = 30,
        Invoice_CustomerTypeWise = 31,
        AdvanceAllocation = 32,
        ChequeRealized = 33,
        ChequeReDeposit = 34,
        Invoice_SalesNoteType = 35,
        Invoice2 = 36,
        Factoring_Approval = 40,
        factoring_Deposit = 41,
        CRN_Settlement = 42,

        JournalEntry = 100,
        JournalEntry_Std = 101,
        JournalEntry_Bank = 102,
        JournalEntry_Creditor = 103,
        JournalEntry_Debtor = 104,
        Inter_Company_Transfer = 105,
        Outward_cheque_Cancellation = 106,

        AdvanceReceipt_Cash = 3,
        PartPaymentReceipt_Cash = 4,
        AdvanceReceipt_Cheque = 5,
        PartPaymentReceipt_Cheque = 6,
        Receipt_CreditCard = 43,
        Receipt_BankTransfer = 44,

        POS_SalesTransaction = 45,
        POS_Collection = 46,
        POS_Adavnce = 47,
        POS_Return = 48,
        POS_GiftVouchers = 49,
    }
    #endregion

    #region Transaction Category
    public enum TransactionCategory
    {
        [Description("Sub Tot.")]
        SubTotal = 1,
        [Description("NBT")]
        NBT = 2,
        [Description("VAT")]
        VAT = 3,
        [Description("SVAT")]
        SVAT = 4,
        [Description("Discount")]
        Discount = 5,
        [Description("Grand Tot.")]
        GrandTotal = 6,
        Cash = 7,
        Cheque = 8,
        Other_Cr = 9,
        [Description("Creditor")]
        Supplier = 10,
        CreditEntry = 11,
        DebitEntry = 12,
        [Description("Debtor")]
        Customer = 13,
    }
    #endregion

    #region Journal Entry Type
    public enum JournalEntryType
    {
        StandardJournalEntry = 1,
        BankAdjustmentEntry = 2,
        JournalVoucher = 3,
    }
    #endregion


    #region Alerts
    public enum enum_Alerts
    {

        blank = 0,
        JITAlert_ProductionJobConfirmed = 1,
        DailyStatusAlert = 2,
        InvoiceCreated = 3,
        ReceiptCreated = 4,
        SalesReternCreated = 5,
        CreditNoteCreated = 6,
        InvoiceCanceled = 7,
        SalesReternCancel = 8,
        CreditNoteCancel = 9,
        DebitNoteCreate = 10,
        DebitNoteCancel = 11,
        DeliveryOrderCreate = 12,
        DeliveryOrderCancel = 13,
        ReceiptCanceled = 14,
        StockAdjustmentCreate = 15,
        StockAdjustmentCancel = 18,
        ItemSpliteCreate = 16,
        ItemSpliteCancel = 17,
        SheduleAlert_ChequePendingDeposit = 19,
        SheduleAlert_CashSalesNotDeposited = 20,
        SheduleAlert_DONoteInvoiced = 21,
        SheduleAlert_CustomerExceededCredit = 22,
        SheduleAlert_DepositedChequesNotRealized = 23,
        SheduleAlert_DailyStatusAlert_Gen = 24,
        SheduleAlert_SalesAgeAnalysis = 25,
        SheduleAlert_UnsettleReturnedCheques = 26,
        StatusAlert_InvoicesExceededCreditPeriod = 27,
        SheduleAlert_InvoiceSummary = 28,
        SheduleAlert_ReceiptSummary = 29,
        ProductionJobClose = 30,
        SheduleAlert_TurnOverDetail_SalesmanWise = 31,
        SheduleAlert_TurnOverDetail_SalesmanWiseSummary = 32,
        SheduleAlert_UnallocatedResipt = 33,
        SheduleAlert_OutstandingJobs_SalesmanWise = 34,
        SheduleAlert_JobCloseSummary = 35,
        SheduleAlert_SalseReturnSummary = 36,
        SheduleAlert_SalseReturn_SalesmanWise = 37,
        DailySectionPlan = 38,
        ChequeInHand = 40,
        CustomerOrderCreate = 41,
        CustomerOrderCancel = 42,
        CustomerOrderPrinted = 43,
        CustomerOrderDiscountedItemCreate = 44,
        CustomerOrderDiscountedItemCancel = 45,
        CustomerOrderDiscountedItemPrinted = 46,
        //for GRN
        Good_RecivedNote_Created = 503,
        Good_RecivedNote_Modified = 504,
        Good_RecivedNote_Cancel = 505,

        DeliveryOrderPrinted = 506,
        InvoicePrinted = 507,
        SalesReturnNotePrint = 508,
        Good_RecivedNote_Print = 509,

        AccountPayableNoteCreated = 510,
        AccountPayableNoteDeleted = 511,
        AccountPayableNoteModified = 513,
        AccountPayableNotePrinted = 514,
        ReceiptPrinted = 515,

        PaymentVoucherCreated = 516,
        PaymentVoucherCanceled = 517,
        PaymentVoucherPrinted = 518,
        PaymentVoucherModified = 519,

        //SMS
        sms_CreatingWIP = 501,
        sms_CreateInvoice = 502,

        Invoice_CreaditDaysExeedAlert = 520,

        CustomerOutstandingAlert_ToCustomer = 600,

        POS_TransactionDetails = 65,
        EventLog = 1000,
        AutoBackup = 1010,
    }
    #endregion

    #region Grid Format
    public enum enum_GridFormat
    {
        TextValue,
        NumaricValue,
        DateValue
    }
    #endregion

    #region Cost Price Types
    public enum enum_CostPriceType
    {
        WeightedAverage = 1,
        LIFO = 2,
        FIFO = 3,
        HighestPurchaseCost = 4,
        LovestPurchaseCost = 5,
        CostPrice1 = 6,
        CostPrice2 = 7,
    }
    #endregion

    public enum enum_CompanyCode
    {
        JNJ = 42,
    }


    #region Company Value
    public enum enum_CompanyValue
    {
        companyName = 7,
        companyEmail = 6,
    }
    #endregion

    //public enum enum_Company
    #region Cheque Data
    public enum enum_ChequeData
    {
        Payee1 = 1, Payee2 = 2, Payee3 = 3, Payee4 = 4,
        Amount1 = 5, Amount2 = 6,
        Rupee1 = 7, Rupee2 = 8, Rupee3 = 9,
        Date = 10,
        Day1 = 11, Day2 = 12, Month1 = 13, Month2 = 14, Year1 = 15, Year2 = 16, Year3 = 17, Year4 = 18,
        AccountPayee = 19,
        TopLine = 20,
        BottomLine = 21,
    }
    #endregion

    #region Serial Type
    public enum enum_SerialType
    {
        Standerd = 1,
        BranchWice = 2,
        NoteType = 3,
        BranchWise_NoteType = 4,
        other = 5,
    }
    #endregion

    #region Customer Price Mode
    public enum enum_CustomerPrice_Mode
    {
        [Description("Std. Price")]
        Standard_Price = 0,
        [Description("Cus. Price Category")]
        Customer_Wise_PriceCategory = 1,
        [Description("Cus. Price")]
        Customer_Wise_Price = 2,
    }
    #endregion

    #region tender
    #region Document Type
    public enum DocumentType
    {
        [Description("Registration")]
        Registration = 0,
        [Description("License")]
        License = 1,
        [Description("Certification")]
        Certification = 2,
        [Description("Authorization")]
        Authorization = 3,
        [Description("Bank Document")]
        BankDocument = 4,
        [Description("Legal")]
        Legal = 5,
        [Description("Other")]
        Other = 6,
    }
    #endregion

    #region Renewal Type One
    public enum RenewalTypeOne
    {
        [Description("One-Time")]
        Onetime = 0,
        [Description("Life-Time")]
        Lifetime = 1,
        [Description("Annual")]
        Annual = 2,
        [Description("Quarterly")]
        Quarterly = 3,
        [Description("Monthly")]
        Monthly = 4,
        [Description("Other")]
        Other = 5,
    }
    #endregion

    #region Renewal Type Two
    public enum RenewalTypeTwo
    {
        [Description("Entire Tender")]
        EntireTender = 0,
        [Description("All Product Categories")]
        AllProductsCategories = 1,
        [Description("Single Product Category")]
        SingleProductCategory = 2,
        [Description("Single Item")]
        SingleItem = 3,
    }
    #endregion

    #region Notice Source
    public enum NoticeSource
    {
        [Description("News Papers")]
        NewsPapers = 0,
        [Description("Ad Advertistment")]
        Advertistment = 1,
        [Description("Web Site")]
        WebSite = 2,
        [Description("Magazine")]
        Magazine = 3,
        [Description("Email")]
        Email = 4,
        [Description("Other")]
        Other = 5,
    }
    #endregion

    #region Security Items
    public enum SecurityItems
    {
        [Description("Perform Bond")]
        PerformBond = 0,
        [Description("BID Bond")]
        BIDBond = 1,
        [Description("Bank Guarantee")]
        BankGuarantee = 2,
        [Description("Advance Payment Guarantee")]
        AdvancePaymentGuarantee = 3,
    }
    #endregion

    #region Frequence
    public enum Frequence
    {
        [Description("Daily")]
        Daily = 0,
        [Description("Weekly")]
        Weekly = 1,
        [Description("Monthly")]
        Monthly = 2,
        [Description("Sunday")]
        Sunday = 3,
        [Description("Monday")]
        Monday = 4,
        [Description("Tuesday")]
        Tuesday = 5,
        [Description("Wednesday")]
        Wednesday = 6,
        [Description("Thursday")]
        Thursday = 3,
        [Description("Friday")]
        Friday = 8,
        [Description("Saturday")]
        Saturday = 9,
    }
    #endregion

    #region Renewals
    public enum Renewals
    {
        [Description("Document Based")]
        DocumentBased = 0,
        [Description("Item Based")]
        ItemBased = 1,
        [Description("Manufacturer Based")]
        ManufacturerBased = 2,
    }
    #endregion 
    #endregion

    #region Enum Control Account Type
    public enum enum_ControlAccountType
    {
        Other = 0,
        Debtor = 1,
        Creditor = 2,
        Bank = 3,
        Cash = 4,
        Inventory = 5,
        SalesAccount = 6,
        Tax = 7,
    }

    public enum enum_ControlAccountType_Description
    {
        [Description("Other")]
        Other = 0,
        [Description("Debtor")]
        Debtor = 1,
        [Description("Creditor")]
        Creditor = 2,
        [Description("Bank")]
        Bank = 3,
        [Description("Cash")]
        Cash = 4,
        [Description("Inventory")]
        Inventory = 5,
        [Description("Sales Account")]
        SalesAccount = 6,
        [Description("Tax")]
        Tax = 7,
    }
    #endregion

    #region Bank Transfer Types
    public enum BankTransferTypes
    {
        [Description("SLIPS")]
        SLIPS = 0,

        [Description("SWIFT")]
        SWIFT = 1,
    }
    #endregion

    #region R2 Production System Enums
    public enum prod_BoM_Status
    {
        [Description("BoM - Sales")]
        BoMSales = 0,

        [Description("BoM - Production")]
        BoMProd = 1,

        [Description("BoM - Costing")]
        BoMFin = 2,

        [Description("BoM - Locked")]
        WIP = 3,

        [Description("Finished Good Transfer")]
        FGTN = 4,

        [Description("Close")]
        Closed = 5,

        [Description("Cancel")]
        Cancelled = 6,

        [Description("Obsolete")]
        Obsolete = 7,

        [Description("Suspend")]
        Suspended = 8
    }

    public enum prod_Batch_Status
    {
        [Description("Open")]
        Open = 0,

        [Description("Close")]
        Close = 1,

        [Description("Cancel")]
        Cancel = 2,

        [Description("Suspend")]
        Suspend = 3
    }

    public enum prod_Costing_Mode
    {
        [Description("Weighted Avg Cost")]
        Weighted_Avg_Cost = 0,
        [Description("Lowest Cost")]
        Lowest_Cost = 1,
        [Description("Highest Cost")]
        Highest_Cost = 2,
        [Description("BoM Cost")]
        BoM_Cost = 3,
    }

    public enum ProdIndustry
    {
        [Description("Apparell")]
        Apperal = 0,
        [Description("Shoes")]
        Shoes = 1,
        [Description("NonWoven")]
        NonWoven = 2,
        [Description("Coilware(Carpets, Ornaments)")]
        Coilware = 3,
        [Description("Ornaments")]
        Ornaments = 4,
        [Description("Jewellery-Metal")]
        Jewellery_Metal = 5,
        [Description("Jewellery-Costume")]
        Jewellery_Costume = 6,
        [Description("Polythene")]
        Polythene = 7,
        [Description("Plastic")]
        Plastic = 8,
        [Description("Chemical-Liquids")]
        Chemical_Liquids = 9,
        [Description("Chemical-Solids")]
        Chemical_Solids = 10,
        [Description("Chemical-Powder")]
        Chemical_Powder = 11,
        [Description("Chemical-Gas")]
        Chemical_Gas = 12,
        [Description("Oil-Natural")]
        Oil_Natural = 13,
        [Description("Oil-Synthetic")]
        Oil_Synthetic = 14,
        [Description("Electrical")]
        Electrical = 15,
        [Description("Electronics")]
        Electronics = 16,
        [Description("Computers")]
        Computers = 17,
        [Description("Machinery")]
        Machinery = 18,
        [Description("Automobile")]
        Automobile = 19,
        [Description("Toys")]
        Toys = 20,
        [Description("Paper")]
        Paper = 21,
        [Description("Paint")]
        Paint = 22,
        [Description("Furniture")]
        Furniture = 23,
        [Description("Steel")]
        Steel = 24,
        [Description("F&B-Food")]
        FB_Food = 25,
        [Description("F&B-Beverage")]
        FB_Beverage = 26,
        [Description("F&B:Other")]
        FB_Other = 27,
        [Description("Pharmaceutical")]
        Pharmaceutical = 28

    }

    #endregion

    #region R2 Point of Sales System Enums
    public enum PaymentCardTypes
    {
        [Description("Visa")]
        Visa = 0,

        [Description("Master")]
        MasterCard = 1,

        [Description("American Express")]
        Amex = 2,

        [Description("Discover")]
        Discover = 3,

        [Description("JCB")]
        JCB = 4,

        [Description("Other")]
        Other = 5,
    }
    #endregion

}

#region Synchronizable Note Types
//public enum SynchronizableNoteTypes
//{
//    ALL = 0,
//    INVOICE = 1,
//    SRN = 2,
//    RECEIPT = 3,
//    APN = 4,
//    DBN = 5,
//    CRN = 6,
//}
#endregion

//public enum TimeFormats
//{
//    SS_MM_HH = 0,
//    HH_MM_SS = 1,
//    HH_MM_SS_MS = 2,
//}

//public enum ConfigValue
//{
//    ServerBackupFolder = 1,
//    AdminCategoryID = 2,
//    DigiteqTitle = 3,
//    NotYet = 4,
//    ProjectType = 5,
//    AutoBackupTargetPath = 50,
//}

//public enum PricingMode
//{
//    [Description("Std. Price")]
//    Standard_Price = 0,
//    [Description("Cus. Price Category")]
//    Customer_Wise_PriceCategory = 1,
//    [Description("Cus. Price")]
//    Customer_Wise_Price = 2,
//}


//public enum ReportName
//{
//    NP_Inquiry = 1,
//    NP_Quotation = 2,
//    NP_ProforemaInvoice = 3,
//    NP_CustomerOrder = 4,
//    NP_DeliveryOrder = 5,
//    NP_Invoice = 6,
//    NP_JobRegister = 7,
//}

//public enum enum_POSMode
//{
//    ItemCode = 1,
//    Qty = 2,
//    Discount = 3,
//    Payment = 4,
//    RowSelect_Item = 5,
//    BillSettle = 6,
//    BillDiscount = 7,
//    UnitPrice = 8,

//    //Discount
//    ItemDiscountFlat = 20,
//    ItemDiscountPresentage = 21,
//    BillDiscountFlat = 22,
//    BillDiscountPresentage = 23,
//    BillPromoDiscountFlat = 24,
//    BillPromoDiscountPresentage = 25,

//    //CommonWindow
//    selectStore = 10,
//    selectCustomer = 11,
//    selectCustomerOrder = 12,
//    selectDeliveryOrder = 13,

//}

#region Design Patter Edit Mode
//public enum enum_DesignPatterEditMode
//{
//    CustomerOrder = 1,
//    ItemEdit = 2,
//    SerialNumberEdit = 3,
//} 
#endregion

//public enum enum_MessageBoxImage
//{
//    NoImage = 1,
//    Information = 2,
//    Error = 3,
//    Warning = 4,
//}