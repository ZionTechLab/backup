using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Digiteq_Logic
{
    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    public enum CheckingType
    {
        Loading = 0,
        Unloading = 1
    }

    public enum StoragePeriod
    {
        
        [Description("15 Days")] D15 = 0,
        [Description("30 Days")] D30 = 1,
        [Description("Daily")] Daily = 2
    }

    public enum CivilState
    {
        Unmarried = 1,
        Married = 2,
        widower = 3,
        widow = 4,
        Divorced = 5,
    }

  
    public enum UserGroups
    {
        Administrator = 1,
        Director = 2,
        Manager = 3,
        Executive = 4,
        Assitant = 5,
        Employee = 6,
    }

    public enum Search
    {
        ItemType = 901,
        ItemCategory = 902,
        ItemClass = 903,
        ItemBrand = 904,
        Items = 905,
        Items_StoreStock = 906,

        Brokers = 911,
        CustomerClass = 912,
        CustomerType = 913,
        CustomerCategory = 914,
        Customers = 1200,
        CustomerEstimation = 915,
        GrnEstimationCustomer = 916,
        Grn = 917,
        Gin = 918,

        Tax = 920,
        UOM_Categories = 921,
        UOM = 922,

        Warehouse = 951,

        Device_Master = 10,
        Employee_Master = 20,
        HolyDayType_Master = 30,
        HRYear = 40,
        HRMonth = 50,
        HRMonth_BY_Year = 51,
        Title = 60,
        CivilStatus = 70,
        Departments = 80,
        Sections = 90,
        SubSections = 100,
        RecruitmentTypes = 110,
        Shift = 120,
        PayemntTypes = 130,
        Naltonality = 140,
        Religions = 150,
        Banks = 160,
        BankBranch = 170,
        CityMaster = 180,
        CountryMaster = 190,
        Designations = 200,
        Districts = 210,
        ProvinceCode = 220,
        EmployeeCategory = 230,
        PayrollLevel = 240,
        LeaveTypes = 250,
        PostalCode = 260,
        Users = 270,
        UserGroups = 280,
        Currency = 290,
        EmployeeCategory2 = 300,
        EmployeeCategory3 = 310,
        HomeTown = 320,
        MealType = 340,
        MealPlan = 350,
        MealMenu = 360,
        EnD = 370,
        EmployeeStatus = 380,
        Division = 390,
        Calender = 400,
        Holiday_Type = 410,
        Town = 420,
        Status = 430,
        DocumentType = 440,
        GatePass = 450,
        GN_Division = 460,
        Configuration = 53,

        VehicleTracker = 1000,
        Store = 1050,
        Estimation = 1100,
    }


    public enum enum_Alerts
    {
        GatePass_Applied = 1,
        GatePass_updated = 2,
        GatePass_Canceled = 3,
        GatePass_Approved = 4,
        GatePass_Rejected = 5,
        LeaveApplied = 6,
        LeaveUpdated = 7,
        LeaveCancel = 8,
        LeaveReject = 9,
        LeaveApproved = 10,
        AttendanceRecordUpdate = 3,

        PasswordChanged = 11,
        ForgotPassword = 12,
        RequestNewAccount = 13,
    }

    public enum FormName
    {
       
        DefaultForm = 9999,

        CountryMaster = 1000,
        ProvinceCreation = 1001,
        DistrictMaster = 1002,
        CityMaster = 1003,
        TownCreation = 1004,

        TaxMaster = 1101,
        CategoryOfUnitOfMeasureMaster = 1102,
        UnitOfMeasureMaster = 1103,


        ItemTypeMaster = 1201,
        ItemClassMaster = 1202,
        ItemCategoryMaster = 1203,
        ItemCreationMaster = 1204,
        ItemBrandMaster = 1205,

        CustomerClassMaster = 1301,
        CustomerTypeMaster = 1302,
        CustomerCategoryMaster = 1303,
        CustomerMaster = 1304,

        BrokerMaster = 1401,

        WarehouseMaster = 1501,
        
        UserCreation = 2001,
        UserPermissionSetup = 2002,
        SystemBackup = 2003,

        VehicleCheckInOut = 2050,

        Estimation = 2100,
        GRN = 2200,
        GIN = 2300,
        Report = 2500,

    }

       

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

    public enum TimeFormats
    {
        SS_MM_HH = 0,
        HH_MM_SS = 1,
        HH_MM_SS_MS = 2,
    }

    public enum enum_ReportName
    {
        Employee_Demography_Personal_Details = 1,
        Employee_Information_Sheet = 2,
        Device_Raw_Data = 3,
        Device_Raw_Data_Employee_Wise = 4,
        Device_Detail = 5,
        AttendanceSummary = 6,
        AttendanceSummary_EmployeeWise1 = 7,
        AttendanceSummary_EmployeeWise_WH = 8,
        DeviceRawData = 1000,
        AttendanceSummary_EmployeeWise = 9,
        DailyMispunchReport = 10,
        Daily_Absenteeism_Report = 11,
        Daily_MissedPunchReport_New = 12,
        LeaveCard = 13,
        GatePassDetails = 14,
        LateEmployees = 15,
        HeadCountReport = 16,
        BankList = 17,
        CityList = 18,
        CountryList = 19,
        DistrictList = 20,
        DesignationList = 21,
        BankBranchList = 22,
        GatePassList = 23,
        MonthlyAttendanceSheetExcel = 24,
        TimeAttendaceLaboursEmployed = 25,
        AttendanceSummary_EmployeeWise_Detail = 26,
        EstimationDetail = 27,
        GRNSummary = 30,
        GRNSummaryCustomerWise = 31,
        GINSummary = 32,
        GINSummaryCustomerWise = 33,
        //GINSummaryDetail = 33,
        GRNStockSummery = 34,
        VehicleDetail = 35,
        
    }

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
    }

    public enum PaymentMethods
    {
        Cash = 0,
        Cheque = 1,
        Visa = 2,
        Master = 3,
        LoyalityCard = 4,
        Voucher = 5,
        Bank_Slip = 6,
        Bank_Swift = 7,
        Amex = 8,
        DinersClub = 9,
        GiftVoucher = 10,
        StarPoints = 11,
        CreditNote = 12,

    }
    public enum SelectArea
    {
        Default = 0,
        Department = 1,
        Section = 2,
        Store = 3,
    }
    public enum ConfigValue
    {
        ServerBackupFolder = 1,
        AdminCategoryID = 2,
        DigiteqTitle = 3,
        NotYet = 4,
        ProjectType = 5,
        AutoBackupTargetPath = 50,

    }
    public enum ConfigStatus
    {
        DOBreakdownQtyIsDOQty = 1,
        DOBreakdownWeightIsDOWeight = 2,
        AutoInvoiceSettleWhenChequeRegister = 3,
        AutoInvoiceSettleWhenCashReceipt = 4,
        AutoInvoiceSettleWithCreditNote = 5,
    }
    public enum ConfigActiveValue
    {
        DisplayCustormizedGrid = 1,
    }
    public enum ItemTypes
    {
        Default = 0,
        RawMaterial = 1,
        SemiFinishedGood = 2,
        FinishGood = 3,
        CombinationMaterial = 4,
        LaminatedMaterial = 5,
    }
    public enum ItemSearchType
    {
        Basic = 0,
        Transaction = 1,
        Advance1 = 2,
        Advance2 = 3,
        Stock = 4,
    }
    public enum ItemClass
    {
        Default = 0,
        Production = 1,
        Trading = 2,
    }
    public enum ConfigItemExceedLock
    {
        Inquiry = 0,
        Quotation = 1,
        CustomerOrder = 2,
        ProformaInvoice = 3,
        DeliveryOrder = 4,
        Invoice = 5,
    }
    public enum ConfigStockAvailabilityLock
    {

    }
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
        gem = 9,
        jj = 10,
        trading = 11,
        production = 12,
    }
    public enum JobMeasurementType
    {
        Milimeter = 0,
        Centimeter = 1,
        Inch = 2,
        Meter = 3,
        Yard = 4,

    }
    public enum ApprovalStatus
    {
        PendingApproval = 0,
        Approved = 1,
        Rejected = 2,
        OnHold = 3,
    }

    public enum WeightCalculation_Types
    {
        AKT = 0,
        PolyPS = 1
    }
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
        BudgetPlan = 37
    }
    public enum LoginStatus
    {
        Online = 1,
        Idle = 2,
        Offline = 3,
    }
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
    public enum AuditMessage
    {
        RecordSave = 1,
        RecordDelete = 2,
        RecordModify = 3,
        ViewReport = 4,
    }
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
    }
    public enum DebitNoteType
    {
        OpenningBalance = 0,
        ChequeReturns = 1,
        UnderInvoice = 2,
        AdvanceRefund = 3,
        OverpaymentRefund = 4,
    }
    public enum RecommendedUnitPrice
    {
        sellingPrice1 = 0,
        sellingPrice2 = 1,
        sellingPrice3 = 2,
        sellingPrice4 = 3,
        wholesalePrice = 4,
    }
    public enum RecommendedWeightPrice
    {
        kiloPrice = 0,
    }
    public enum Tax
    {
        NBT = 0,
        VAT = 1,
        NONE = 2,
    }
    public enum GLPostingStatus
    {
        NewTransaction = 1,
        Unposted = 2,
        Posted = 3,
        Error = 4,
        ReChqDeposite = 5,
        ReChqReturn = 6,
    }
    public enum JobPercentage
    {
        JobMarckup = 37,
        JobGenaralOverhead = 38,
    }
    public enum AccSlot
    {
        NonTaxInvoice = 1,
        TaxInvoice = 2,
        AdvancePaymentReceipt_Cash = 3,
        PartPaymentReceipt_Cash = 4,
        AdvancePaymentReceipt_Cheque = 5,
        PartPaymentReceiptCheque = 6,
        PaymetVoucher = 7,
        AccountReceipt = 8,
        AccountPayableNote = 9,
        JournalVoucher = 10,
        bssDebitNote = 11,
        CreditNote = 12,
        ChequeDeposit = 13,
        SalesReturnNote = 14,
        DeliveryNote = 15,
        PurchaseReturn = 16,
        StandardJournalEntries = 17,
        GoodReserveNote = 18,
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
        SupplierDebitNote = 29,
        ReDeposit = 30,
        Invoice_CustomerTypeWise = 31,
        AdvanceAllocation = 32,
        ChequeRealized = 33,

    }
    public enum TransactionCategory
    {
        SubTotal = 1,
        NBT = 2,
        VAT = 3,
        SVAT = 4,
        Discount = 5,
        GrandTotal = 6,
        Cash = 7,
        Cheque = 8,
        Other_Cr = 9,
        Supplier = 10,
        CreditEntry = 11,
        DebitEntry = 12,
    }
    public enum JournalEntryType
    {
        StandardJournalEntry = 1,
        BankAdjustmentEntry = 2,
        JournalVoucher = 3,
    }
    public enum ReportName
    {
        NP_Inquiry = 1,
        NP_Quotation = 2,
        NP_ProforemaInvoice = 3,
        NP_CustomerOrder = 4,
        NP_DeliveryOrder = 5,
        NP_Invoice = 6,
        NP_JobRegister = 7,
    }

    public enum enum_GridFormat
    {
        TextValue,
        NumaricValue,
        DateValue
    }
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
    public enum enum_CompanyCode
    {
        JNJ = 42,
    }
    public enum enum_POSMode
    {
        ItemCode = 1,
        Qty = 2,
        Discount = 3,
        Payment = 4,
        RowSelect_Item = 5,
        BillSettle = 6,
        BillDiscount = 7,
        UnitPrice = 8,

        //Discount
        ItemDiscountFlat = 20,
        ItemDiscountPresentage = 21,
        BillDiscountFlat = 22,
        BillDiscountPresentage = 23,
        BillPromoDiscountFlat = 24,
        BillPromoDiscountPresentage = 25,

        //CommonWindow
        selectStore = 10,
        selectCustomer = 11,
        selectCustomerOrder = 12,
        selectDeliveryOrder = 13,

    }
    public enum enum_DesignPatterEditMode
    {
        CustomerOrder = 1,
        ItemEdit = 2,
        SerialNumberEdit = 3,
    }
    public enum enum_MessageBoxImage
    {
        NoImage = 1,
        Information = 2,
        Error = 3,
        Warning = 4,
    }

}
       