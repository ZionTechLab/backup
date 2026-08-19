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
        Form_Catagory = 5031,

        Counter = 5008,
        Currency = 5006,

        Cashier = 5009,
        SalesRep = 5010,
        Collector = 5018,
        Account = 5011,
        Employees = 5014,
        Users = 5025,

        SalesNoteType = 5004,
        QuotationTerms = 5400,
        ChequeTypes = 5410,
        APNType = 5460,
        PaymentMethod = 5470,
        ChequeStatus = 5108,
        ChequeStatus_2 = 5109,
        ChequeNo = 5113,
        AccChequeNo = 5121,

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
        SalesManager = 5022,
        ItemMasterByCategories = 5209,

        ItemMasterByItemCode = 5200,
        ItemMasterByCompanyBranchID = 5203,
        ItemMaster_FinishGoodsOnly = 10201,
        ItemByStore = 5223,

        ItemClass = 5215,
        ItemType = 5216,
        ItemCategory = 5217,
        DeliveryOfficer = 1235,
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

        #region Commision Module
        Commission_Period = 10200, 
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
        BookNoAllocation = 25000,
        BookNoAllocation_Receipt = 25001,
        defaultForm = 0,
        ItemMaster = 1,
        CustomerMaster = 2,
        SupplierMaster = 3,



        CustomerOrder = 9,
        VATInvoice = 10,
        Invoice_TAXReverced = 610,

        GoodIssueNote = 7,
        IssueReturnNote = 8,

        CusDeliveryOrder = 11,
        AllInOneDeliveryOrder = 11000,
        CusDeliveryOrder_BulkPrint = 110,
        CusDeliveryOrder_BulkPrint_Reverce = 1110,
        DoDateEdit = 1100,
        DuplicatePrintPermision = 1101,
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
        ZDeliveryOfficer = 710,
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

        accAccountTool = 672,
        accChqDateChange = 673,
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
        StockReports = 1970,
        sasCustomerOrderViewer = 198,
        sasDeliveryOrderViewer = 199,
        sasInquiryViewer = 200,
        sasInvoiceViewer = 201,
        bpsReceiptTracer = 202,

        Chat = 203,
        UserManagement = 204,
        UserControl = 205,

        RetruendChequeDebitInvoice = 205,
        RepresentableChqUpdate = 2050,
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
        RouteWiseItemPricing = 2540,
        RouteWiseDiscount = 2541,
        CustomerWiseItemPricing = 2542,
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
        UserPermissionRouteWise = 517,
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
        ChequeDeposit = 664,
        ChequeReDeposit = 216,
        ChequeReIssue = 30,
        ChequeReconsiliation = 31,
        //ChequeOutwardReconsiliation = 282, 
        CashDepositeCode = 665,
        SalesCommision = 380,
        EmployeeSlabSettings = 381,
        BillsTools = 295,
        BankReconcilation = 666,
        ChequeReturn = 674,
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

        #region Comission Module (From 10000 - 10500)
        Com_ComissionPeriodMaster = 10001,
        Com_ItemCategory_ComissionWiseBreakDown = 10002,
        Com_ComissionCalculation = 10010,
        Com_RegisterReports = 10020,
        Com_ComissionCalculation_Collectors = 10030,
        Com_ComissionCalculation_Drivers = 10050,
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

    #region Report Name Enums
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

        RG_UnpresentedCheques = 1222,

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
        RG_Outstanding_RouteWise = 4510,
        RG_Outstanding_Customer_Wise_Detail2 = 4511,
        RG_Outstanding_Salesman_wise_Summary = 452,
        RG_Outstanding_Salesman_wise_Detail = 453,
        RG_Outstanding_Invoice_wise_Summary = 454,
        RG_Outstanding_Invoice_Date_wise = 4541,
        RG_Outstanding_Invoice_wise_Detail = 455,
        RG_Age_Analysis_Customer_wise = 456,
        RG_Age_Analysis_Customer_wise_Customized = 4561,
        RG_Age_Analysis_Customer_wise_Detail = 4562,
        RG_Age_Analysis_Salesman_wise = 457,
        RG_OutstandingStatement = 458,
        RG_OutstandingStatement_SendEmail = 459,
        RG_OutstandingStatement_Salesman_wise = 460,
        RG_Outstanding_Salesman_wise_Detail_TW = 462,

        RG_Sales_Journal = 258,
        RG_Invoice_wise_payment_Tracking = 259,
        RG_Invoice_wise_payment_Tracking_With_Deposited_Detail = 999,
        RG_Customer_wise_payment_Tracking = 2591,
        RG_Customer_wise_payment_Tracking_New = 2592,
        RG_Customer_wise_payment_Statement= 2593,
        RG_Receipt_wise_Invoice_Tracking = 260,
        RG_Receipt_Allocation = 261,
        //RG_Sales_Commission_Summary = 263,
        RG_Sales_Commission_Detail = 264,
        RG_InterCompanyTranferSummary= 265,
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
        SettledTransactions_Creditor = 3790,
        RG_OverPaymentListing = 267,
        RG_OverPaymentListing_RouteWise = 2670,
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
        RG_CustomerMasterSummary_CreditLimit= 339,
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
        //ST_Invoice_Tax_Export = 1008,
        //ST_Customer_CollectionAging_Report = 1009,
        //ST_Tax_Report_Invoice = 1004,
        //ST_Annual_Sales_ReportCustomerSalesmanWise = 1001,
        ST_Tax_Report_Invoice_LocalNBTVAT = 1088,//
        ST_Tax_Report_Invoice_LocalSVAT = 1089,
        ST_Tax_Report_Invoice_ExportSVAT = 1087,
        ST_Tax_Report_Invoice_DetailLocalNBTVAT = 1092,
        ST_Tax_Report_Invoice_DetailExportVAT = 1093,
        ST_Tax_Report_Invoice_DetailExportSVAT = 1094,
        //ST_Tax_Reports_Invoice_LocalNBTCreditNote = 1095,
        //ST_Tax_Reports_Invoice_LocalSVATCreditNote = 1096,
        //ST_Tax_Reports_Invoice_ExportSVATCreditNote = 1097,//
        ST_Tax_Reports_VAT_Schedule01 = 1210,
        ST_Tax_Reports_VAT_Schedule02 = 1220,
        ST_Tax_Reports_VAT_Schedule04 = 1240,
        ST_Incentive = 2001,
        ST_Tax_Report_Invoice_Detail = 1098,
        //ST_RG_Issued_Cheques_Daily = 1070,

        //Bills Standerd
        ST_Pending_Cheque_Deposite = 1026,
        ST_Cheque_In_HandAll = 1027,
        ST_Cheque_In_Hand_Approved_For_Deposit = 1028,
        ST_Cheque_In_Hand_RouteWise = 10280,
        ST_ChequeIn_Hand_Pending_Approval = 1029,
        ST_Returned_Cheque_inHand = 1030,
        ST_Returned_Cheque_inHand_Route = 10301,
        ST_Returned_Cheque_AgeAnalysis = 10302,
        ST_Collection_Report_Summary = 1031,
        ST_Collection_Report_Detail = 1032,
        ST_Collection_Report_Aging = 1033,
        ST_Collection_Report_Aging_Route = 1034,
        ST_Collection_Report_Aging_Route_Collector = 1036,
        ST_FloorStockReport = 1103,
        ST_Outstanding_Analysis = 1105,
        ST_ChequeTracer = 1106,
        ST_Returned_Cheque_Outstanding = 1035,
        ST_Collection_Aging_InvoiceWise = 1037,
        ST_Collection_Aging_InvoiceWise_Detail = 1039,
        ST_CollectionReport_InvoiceWise = 1038,
        //PMS standerd
        //ST_Daily_Production_Jobs = 1034,
        //ST_Daily_Production_Jobs_Approved_Customer_Wise = 2215,
        //ST_Production_Jobs_Approved = 1035,
        //ST_Pending_Delivery_Job = 1036,
        //ST_Rejection_Report_Summary_JobWise = 1037,
        //ST_Rejection_Report_Detail_JobWise = 1038,
        //ST_Production_Weight_Tracking_Report_JobWise = 1039,
        //ST_Production_Weight_Comparison_Report_JobWise = 1040,
        //ST_Outstanding_Jobs_Customer_Wise = 1064,
        //ST_Outstanding_Jobs_Date_Wise = 1065,
        //ST_MonthlyJobProfit_LossSummary = 1079,
        //ST_Job_Outstanding = 1086,
        //ST_ProductionJobAll = 1100,//
        //ST_ProductionJobApproved = 1101,
        //ST_MaterialUseageSectionwise = 1104,
        //ST_OperationPerformance = 2020,
        //ST_ProductionInputes = 2021,
        //ST_AdhesiveInputesAndOutputes = 2022,
        //ST_ProductionAnalysisFinishedGoodWeightWise = 2023,
        //St_CustomerOverdues = 2024,

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

        //ST_Stock_Age_Analysis_Report = 1050,
        ST_Purchase_Order_Item_Cost_History = 1067,
        //ST_Stocks_Balance_vs_PendingOders = 1043,
        ST_ReOrder_Leval_Exceed_Items = 1071,
        ST_CostCenterWiseItemTracking = 1072,
        ST_PRNTracking = 1074,
        //ST_DesignCategory = 1077,
        //ST_GrnSummary = 1102,

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
        ST_StockAging = 1202,
        ST_StockMovementAndReOrderLevel = 1203,

        //SAS Standerd
        ST_Monthly_Sales_Customer_Wise_Rupees = 1051,
        ST_Monthly_Sales_QTY_RoutWise = 10510,
        ST_Monthly_Sales_QTY_ItemWise= 10512,
        ST_Annual_Sales_Report_Customer_SalesmanWise = 1052,
        ST_Monthly_Turn_Over_Statement_CustomerWise = 1053,
        ST_Monthly_Turn_Over_Statement_SalesmanWise = 1054,
        ST_Sales_Report_Summary_ItemWise = 1055,
        ST_Tax_Report_CreditNote = 1056,
        ST_Tax_Report_Detail_CreditNote = 1099,
        //ST_Tax_Report_Purchase = 1057,
        //ST_Tax_Report_Summary = 1058,
        ST_Tax_Report_Detail_Invoice = 1059,
        ST_Dilivery_Listing_Report = 1060,
        ST_Sales_Report_Itemwise = 1061,
        ST_SalesReport_RouteWise = 1062,
        ST_Monthly_Sales_CustomerWise_Dollars = 1063,
        //ST_Total_Sales_Month_YearWise = 1064,
        ST_Invoice_Listing_Report = 1065,
        //ST_Returned_Cheque_BankWise = 1068,
        //ST_RG_Issued_Cheques_Daily = 1069,
        RG_Returned_Cheque_BankWise = 1070,
        //ST_Delivery_Tracking_Report_Job_Wise = 1075,

        ST_MonthlyUsageTrackingReport = 1080,
        ST_Svat_04 = 1081,
        //ST_DeliveryTrackingReport_JobWise = 1082,
        ST_SalesReturnTrackingReport = 1083,
        ST_OutstandingOrders_CustomerWise = 1084,
        ST_MounthlySalesSummaryReport = 1090,//
        //ST_PrintingSalesReturnedTrackingReport = 1091,
        St_DelevaryTrackingReport = 2000,
        St_DelevaryReport_Pending = 20001,
        St_DelevaryReport_Deleverd = 20002,
        St_DelevaryReport_Deleverd_Summary = 20005,
        ST_SalesReturnValue = 20020,
        ST_Cash_In_Hand = 2208,
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
        ST_SalesReport_CustomerWise_Metrix = 10591,
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
        ST_SalesReportGrossProfitSummery_ItemWise = 2266,
        ST_SalesReportGrossProfitSummery_CustomerWise = 2267,
        ST_SalesReportGrossProfitSummery_SalesmanWise = 2268,

        //NP_BarcodePrint = 2248,
        #endregion

        #region APN Reports
        AP_Tax = 2200,
        AP_Supplier_Outstanding_GRN = 2205,
        AP_Supplier_Outstanding_PO = 2206,
        AP_Creditors_Age_anlysis_Detail = 2210,
        AP_Creditors_Age_anlysis_Summary = 2211,


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
        CU_UnsettledCreditNote =8000,
        CU_CollectionReportRouteWise=8001,
        CU_InvoiceWisePaymentTracking=8002,
        CU_BankAccountWisePaymentVoucher=8003,
        CU_DepositedCheque=8004,
        CU_DebtorOutstanding_Summary = 8005,
        CU_DebtorOutstanding_Detail = 8006,
        CU_StockStatement = 8010,


        //Customermized Excel Report
        CU_SalesDetailReport_InvoiceItemWise = 8500,
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

        #region Commission Module (From 11000 onwards)
        COM_CommissionCalculationNP = 110001,
        COM_CommissionChqDeduction = 110002,
        COM_Commission_Collecter = 110003,
        COM_Commission_Report_ItemCategory_SalesRep = 110010,
        COM_Commission_Report_ItemCategory_AreaManager = 110011,
        COM_Commission_Report_ItemCategory_SalesManager = 110012,
        COM_Commission_Report_ItemCategory_Collecotr = 110013,
        COM_Commission_Report_ItemCategory_SalesRep_New = 110014,

       // COM_Commission_Report_ItemCategory_SalesRep_New = 110020,
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
        FloorStock=5201,
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

    #region Tender
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

    public enum SalesCommission_EmpRole
    {
        SalesRep = 0,
        AreaManager = 1,
        SalesManager = 2,
        Collector = 3,
    }
}
