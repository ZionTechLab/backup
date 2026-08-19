using System.ComponentModel;

namespace Digiteq_Logic
{
    #region Gender
    public enum Gender
    {
        Male = 1,
        Female = 2
    } 
    #endregion

    #region Civil State
    public enum CivilState
    {
        Unmarried = 1,
        Married = 2,
        Widower = 3,
        Widow = 4,
        Divorced = 5,
    } 
    #endregion

    #region Employee Status
    public enum EmployeeStatus
    {
        [Description("Active")]
        Active = 0,
        [Description("Resigned")]
        Resigned = 1,
        [Description("Suspended With Pay")]
        Suspended_With_Pay = 2,
        [Description("Suspended Without Pay")]
        Suspended_Without_Pay = 3,
        [Description("Hired")]
        Hired = 4,
        [Description("Rehired")]
        ReHired = 5,
    } 
    #endregion

    #region Holiday Duration Type
    public enum holidayDurationType
    {
        N_A = 0,
        FullDay = 1,
        HalfDay_Morning = 2,
        HalfDay_Evening = 3,
        ShortHoliday = 4,
        Other = 5,
    } 
    #endregion

    #region Day Types
    public enum DayTypes
    {
        WorkingDay = 0,
        Saturday = 1,
        Sunday = 2,
        Holiday = 3,
        CompanyHoliday = 4,
    }
    #endregion

    #region Attendance Status
    public enum AttendanceStatus
    {
        Present = 0,
        Absent = 1,
        Late = 2,
        Error = 3
    } 
    #endregion

    #region OT Rounding Mode
    public enum OTRoundingMode
    {
        Disable = 0,
        Round = 1,
        RoundUp = 2,
        RoundDown = 3,
    } 
    #endregion

    #region Shift Types
    public enum ShiftTypes
    {
        OneDayShift = 0,
        TwoDayShift = 1,
        FlexibalShift = 2,
        MidnightCross = 3,
    } 
    #endregion

    #region PAYE Status
    public enum PAYE_Status
    {
        Active = 0,
        Inactive = 1,
        Suspended = 2,
    } 
    #endregion

    //to be remove
    #region Shift Details
    public enum ShiftDetails
    {
        Shift_ID = 0,
        Shift_Name = 1,
        shiftStartTime = 2,
        ShiftMins = 3,
    } 
    #endregion

    #region GreetType
    public enum GreetType
    {
        [Description("Birthday")]
        Birthday = 0,
        [Description("World New Year")]
        World_New_Year = 1,
        [Description("Sri Lankan New Year")]
        Sri_Lankan_New_Year = 2,
        [Description("Christmas")]
        Christmas = 3,
        [Description("Thaipongal")]
        Thaipongal = 4,
        [Description("Maha Siva Rathri")]
        Maha_Siva_Rathri = 5,
        [Description("Company Anniversary")]
        Company_Anniversary = 6,
        [Description("Id-Ul-Fitr (Ramazan)")]
        Id_Ul_Fitr_Ramazan = 7,
        [Description("Deepavali")]
        Deepavali = 8,
        [Description("Milad Un Nabi")]
        Milad_Un_Nabi = 9,
        [Description("Holy Prophet's Birthday")]
        Holy_Prophets_Birthday = 10,
    } 
    #endregion

    #region GreetParty
    public enum GreetParty
    {
        Employees = 0,
        Customers = 1,
        Suppliers = 2,
    } 
    #endregion

    #region Email Alert Status
    public enum EmailAlertStatus
    {
        NewMail = 0,
        SentMail = 1,
        Error = 2,
        Error_Reception = 3,
        CancelEmail = 4,
    } 
    #endregion

    #region General

    #region User Groups
    public enum UserGroups
    {
        Administrator = 1,
        Director = 2,
        Manager = 3,
        Executive = 4,
        Assitant = 5,
        Employee = 6,
    } 
    #endregion

    #region Search
    public enum Search
    {
        Device_Master = 10,
        Employee_Master = 20,
        HolyDayType_Master = 30,
        HRYear = 40,
        HRMonth = 50,
        HRMonth_BY_Year = 51,
        HRWeek = 52,

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

        RegistrationDetails = 385,
        Division = 390,
        Calender = 400,
        Holiday_Type = 410,
        Town = 420,
        Status = 430,
        DocumentType = 440,
        GatePass = 450,
        GN_Division = 460,
        CompanyInfo = 470,
        CompanyAccount = 480,
        Configuration = 53,
        ProcessPeriod_Week = 45,

        PayslipItems = 500,
        PaySlipItemsClass = 501,
        PaySlipItemsType = 502,
        PaySlipItemsStatutary = 503,

        PayrollProcessGroup = 505,
        PayrollProcessPeriodMain = 506,
        PayrollProcessPeriodSub = 507,

        FunctionCategory = 508,

        AttendanceProcessGroup1 = 550,
        AttendanceProcessGroup2 = 551,

        AttendanceProcessPeriod = 552,

    } 
    #endregion

    #region Alerts
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
        EmployeeBirthdayListDaily = 25,

        //Security Alerts
        PasswordChanged = 11,
        ForgotPassword = 12,
        RequestNewAccount = 13,

        //Payroll Alerts
        Payroll_Processed = 15,
        Monthly_Software_Payment = 16,

        //Shedule Alerts
        DailyHeadCount = 20,
        DailyPrecences = 21,
        ProbationPeriod_End = 22,


    } 
    #endregion

    #region Form Names
    public enum FormName
    {
        #region Masters
        Alert = 2000,
        accAccount = 404,
        User_Creation = 100,
        User_Permission = 105,
        Company_Creation = 110,
        Company_Account = 111,
        Company_Branch_Creation = 115,
        Registration_Details = 120,
        Payroll__Year = 1000,
        Payroll_Month = 1005,
        Payroll_Week = 1006,
        Holiday_Type_Creation = 1010,
        Company_Calender = 1015,
        Country_Creation = 1020,
        Province_Creation = 1025,
        District_Creation = 1030,
        City_Creation = 1035,
        Town_Creation = 1040,
        Postal_Code_Creation = 1045,
        Grama_Niladari_Unit_Creation = 1050,
        Nationality_Creation = 1055,
        Religion_Creation = 1060,
        Title_Creation = 1065,
        Division_Creation = 1070,
        Department_Creation = 1080,
        Section_Creation = 1085,
        Sub_Section_Creation = 1090,
        Designation_Creation = 1095,
        Employee_Category_1 = 1100,
        Employee_Category_2 = 1105,
        Employee_Category_3 = 1110,
        Leave_Apply = 1115,
        Bank_Creation = 1120,
        Bank_Branch_Creation = 1125,
        Skill_Category = 1130,
        Recruitment_Type_Creation = 1135,
        Employee_Status_Creation = 1140,
        Cadre_Request = 1145,
        Device_Creation = 1150,
        Budget_Plan = 1155,
        Leave_Types_Creation = 1160,
        Shift_Creation = 1165,
        Employee_Demography = 1170,
        Holiday_Creation = 1175,
        Year_End_Process = 1205,
        Reference_Masters = 1402,
        Reports = 1404,
        Dash_Board_Employee = 1407,
        PF_Reports = 1409,
        Dash_Board_IT_Admin = 1410,
        Dash_Board_Management = 1411,
        Company_Brands = 1413,
        Company_Event = 1414,
        Vacancy = 1415,
        Meal_Plan_Rate = 1600,
        Canteen = 1605,

        AttendanceGroup1 = 1610,
        AttendanceGroup2 = 1620,
        #endregion

        Web_Links = 2001,
        Notes = 2002,
        Request_For_Letter = 2003,
        Change_Password = 2004,
        Employee_Salary_Master = 2005,
        Security_Form = 2006,
        Test_Form = 2007,
        Test_Form_2 = 2008,
        Salary_Sheet_Detailed = 2010,
        Documents = 2011,

        Loan_Type_Master = 3000,
        Staff_Loan = 3005,
        Company_Awards_And_Certification = 3500,
        Employee_Incidental_Diary = 3505,
        Employee_Entitle_Leaves = 4000,
        Import_Attendance_Data = 4005,
        GatePass_Official_Leave = 4010,
        Personal_Leave = 4015,
        Employee_Shift_Adjustment = 4020,
        Device_Raw_Data = 4025,
        Attendance_Control_Panel = 4030,
        Approve_GatePass = 4035,
        Approvals = 4040,
        OT_Approval = 4045,
        Greetings_Email_Schedular = 4050,
        Roster_ControlPanel = 4060,
        Attendance_Control_Panel_Roster = 4065,
        Weekly_AttendanceControl_Panel = 4070,
        Monthly_AttendanceControl_Panel = 4075,
        EmployeeAttendance_Monthly = 4080,
        Attendance_ProcessPeriod = 4085,

        Carder_Count = 10401,

        Form_Tool_Kit = 20051,
        DTQ_Test_Kit = 20052,
        Security_Report = 20101,
        System_Backup = 20102,

        RollbackPayroll = 20103,
        RollbackTimeAttendance = 20104,

        #region Cocount Cuttings
        CoconutCuttingDailyEntry = 5000,
        CoconutCuttingEndofWeekProcess = 5001,
        CoconutWashingDailyEntry = 5002,
        CoconutWashingEndofWeekProcess = 5003,
        CoconutLoadingTemporayWorkers = 5004,
        #endregion

        #region Payroll Forms
        Payroll_Deduction_Creation = 2015,
        Payroll_Deduction_Taxes = 2020,
        Payroll_Earnings_Creation = 2025,
        Lump_Sum_Earnings_Creation = 2030,

        Payslip_Items_Class = 2100,
        Payslip_Items_Type = 2101,
        Payslip_Items_Statutary = 2102,
        Payslip_Items = 2105,

        Payroll_Process_Group = 2150,
        Payroll_ProcessPeriod_Main = 2151,
        Payroll_ProcessPeriod_Sub = 2152,
        Employee_PaySlipItems = 2155,
        Employee_PayslipItem_Amounts = 2156,

        Payroll_ControlPannel = 2200,
        Employee_PayrollRowData = 2201,

        Payroll_User_Permissions = 2250,
        Paye_Tax_Table = 2202,
        #endregion

        //Test 
        ReportsTest = 20200,
        Function_Master = 20205,
    } 
    #endregion

    #region Report Names
    public enum enum_ReportName
    {
        #region Reports which Run in Form Print Method
        Device_Detail = 5,
        BankList = 17,
        CityList = 18,
        CountryList = 19,
        DistrictList = 20,
        DesignationList = 21,
        BankBranchList = 22,
        #endregion

        #region Master Reports
        Employee_Demography_Personal_Details = 1,
        Employee_Information_Sheet = 2,
        Employee_Resigned_Sheet = 6,
        Employee_Birthday_List = 27,
        Employee_Birthday_Calendar = 29,
        Employee_Service_Record = 31,
        Employee_JoingMonthListing = 32,
        Employee_Retirement_Record = 34,
        #endregion

        #region Time Management System Reports
        Device_Raw_Data_Employee_Wise = 4,
        AttendanceSummary_EmployeeWise = 9,
        MonthlyAttendanceSheetExcel = 24,
        CheckRoll_LabourersEmployed = 25,
        AttendanceSummary_EmployeeWise_Detail = 26,
        AttendanceReportEntitleYear = 28,
        AttendanceSummary_DeviceRawData = 30,

        Daily_Absenteeism_Report = 11,
        Daily_MissedPunchReport_New = 12,
        LeaveCard = 13,
        GatePassDetails = 14,
        LateEmployees = 15,
        HeadCountReport = 16,
        LeaveEncashment_EmployeeWise = 17,
        OverTimeDetails = 18,
        LeaveBalance = 33,
        AttendanceSummary_DeviceRawData_Details = 35,
        FingerPrints_MoreThanTwo_Reports = 36,
        Nopay_Report = 37,
        AttendanceIncentive = 38,
        #endregion

        #region Payroll / Check Roll Reports

        EPF_C_Form = 41,
        ETF_R1_Form = 42,
        NetSalary_ElectronicFormat = 43,
        SignatureSheet_SalaryPayable = 44,
        ReturnForHalf_YearEnding = 45,
        EPF_ElectronicFormat = 46,
        ETF_ElectronicFormat = 47,
        PaidEmployeeList = 48,
        EmployeePAYE_Deduction = 49,
        SingleEarningDeductionStatement = 50,

        #region C.C. Check Roll Reports - Hero Nature
        DeShellingClearingDailyOutput_CC = 51,
        ShellRemovingPayments_CC = 52,
        ShellRemovingWorkersSalary_CC = 53,
        ShellRemovingWorkersTravellingAllowance_CC = 54,
        ShellRemovingWorkersSalary_Denomination_CC = 55,
        ShellRemovingWorkersAllowance_CC = 56,
        EmployeePaySlip_CC = 60,
        ShellRemovingPayments_NightTime_CC = 61,
        CoconutWashingPayment_CC = 62,
        ShellRemovingMonthlySummary = 63,
        ShellRemovingEPFSummary = 64,
        ShellRemovingMonthlySummary_PermenentWorkers = 65,
        ShellRemovingWorkersAttendanceAllowance_CC = 66,
        TemporaryWorkers_CC = 67,
        #endregion

        CoinAnalysisReport_SalaryPayable = 68,
        CoinAnalysisReport_SalaryAdvance = 69,
        SalaryIncrementReport = 70,
        SalaryRegisterReport = 71,
        AllowanceSheet = 72,
        EPF_ETFSheet = 73,
        EmployeePayslip = 74,
        EmployeePayslip_Basic = 741,
        EmployeePayslip_Allowance = 742,
        SalaryDenomination = 75,
        SalaryDenomination_Allowance = 76,
        SalaryBankTranfer = 77,
        TotalEarningsLabour = 78,
        Unprocessed_PayslipItem_ElectronicFormat = 79,
        SalaryRegisterSummary = 80,
        SalaryRegisterdetail = 81,
        PayslipItemAmount_SignatureSheet = 82,
        PayslipItemAmount_EmployeeWise = 83,
        UnprocessedPayslipItems_SignatureSheet = 84,
        UnprocessedCoinAnalysisReport = 85,
        PayrollSummary = 86,
        PayrollDetail = 87,
        NetSalary_ExcelFormat = 88,
        OverTimeAmount_Details = 89,
        OverTimeAmount_Summary = 90,
        PayrollSummary_CategoryWise = 91,
        HeadCountDetailReport = 92,
        PayrollDetail_ResignNewEmployeeWise = 93,
        #endregion
    }
    #endregion

    #region Activities Payslip Items
    public enum enum_Activities_PayslipItems
    {
        Open = 0,
        AddNewItem = 1,
        RemoveItem = 2,
        ChangeAmount = 3,
        Save = 4,
        Close = 5
    } 
    #endregion
    #endregion

    #region CC - Coconut Cutting system
    public enum Target
    {
        acived = 0,
        notAchived = 1
    }

    public enum Grade
    {
        Good = 0,
        Damage = 1
    }

    public enum rateSlab
    {
        S1 = 0,
        S2 = 1
    }

    public enum CC_WeekStatus
    {
        New = 0,
        InProgress = 1,
        Completed = 2,
    }

    public enum CC_PaymentPeriod
    {
        [Description("Daily Payments")]
        Daily = 0,
        [Description("Weekly Payments")]
        Weekly = 1,
        [Description("Monthly Payments")]
        Monthly = 2,
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

    #region Time Formats
    public enum TimeFormats
    {
        SS_MM_HH = 0,
        HH_MM_SS = 1,
        HH_MM_SS_MS = 2,
    } 
    #endregion

    #region Payment Methods
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
    #endregion

    #region Input Mode
    public enum InputMode
    {
        [Description("Auto - No Edit")]
        Auto_NoEdit = 0,
        [Description("Auto - Allow Edit")]
        Auto_AllowEdit = 1,
        [Description("Manual")]
        Manual = 2
    } 
    #endregion

    #region Payment Period
    public enum PaymentPeriod
    {
        Hourly = 0,
        Daily = 1,
        DayTime = 2,
        NightTime = 3,
        Weekdays = 4,
        Weekends = 5,
        Bi_Weekly = 6,
        Monthly = 7,
        Quarterly = 8,
        Annually = 9,
        Other = 10
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
        gem = 9,
        jj = 10,
        trading = 11,
        production = 12,
    } 
    #endregion

    #region Approval Status
    public enum ApprovalStatus
    {
        PendingApproval = 0,
        Approved = 1,
        Rejected = 2,
        OnHold = 3,
        Override = 4,
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

    #region Tax
    public enum Tax
    {
        NBT = 0,
        VAT = 1,
        NONE = 2,
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

    #region Cost Price Type
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

    #region POS Mode
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
    #endregion
}