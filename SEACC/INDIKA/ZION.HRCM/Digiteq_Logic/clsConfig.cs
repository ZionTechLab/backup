using System;

namespace Digiteq_Logic
{
    public class clsConfig
    {
        public static string SoftwareVersion = "";
        public static string CompanyName = "";
        public static string CompanyAddress1 = "";
        public static string CompanyAddress2 = "";

        public static DateTime SystemExpireDate = clsConfig.defaultDateTime;

        public static string Format_Date = "yyyy/MM/dd";
        public static string Format_Date2 = "yyyy-MMM-dd";
        public static string Format_Time = "HH:mm";
        public static string Format_DateTime = "yyyy/MM/dd HH:mm";

        public static DateTime defaultDateTime = new DateTime(1800, 1, 1);

        public static string DefaultCountry = "cnty211";
        public static string DefaultNationality = "Na/166";
        public static string DefaultEmployeeStatus = "EST/005";

        

        #region Config Values

        public static string sAdminCategoryID = "";

        //HRCM Backup Settings
        public static string sSeaccBackupPath_Server = "";
        public static string sSeaccBackupPath_Network = "";
        public static string sSeaccBackup_SourceFolder_1 = "";
        public static string sSeaccBackup_SourceFolder_2 = "";
        public static string sSeaccBackup_SourceFolder_3 = "";

        //Remort Desktop Printer
        public static string sRemortDesktopExportPath = "";        //HRCM
        public static string sImportAttendanceDataSW_path = "";
        public static string sHRCM_BackupPath_Server = "";
        public static string sHRCM_BackupPreFix = "";
        public static string sHRCM_Backup_SourceFolder_1 = "";
        public static string sHRCM_Backup_SourceFolder_2 = "";
        public static string sHRCM_Backup_SourceFolder_3 = "";

        //shift
        public static string DefaultShift = "SFT/002";
        public static string sLadiesNightShift = "";
        public static string s24NightShifts = "";
        public static string sNightShifts = "";
        //Leave
        public static decimal dShortLeave_Hours = 0;
        public static decimal dShortLeave_GrassPeriod = 0;
        public static decimal dHalfDay_Hours = 0;
        public static decimal dHalfDay_GrassPeriod = 0;
        public static bool bIsEnableShortLeaveRoundUp = false;
        public static bool bIsEnablehalfDayRoundUp = false;
        public static string sNoPayLeaveID = "";
        public static string sShortLeaveID = "";
        public static string sLeaveTypes = "";


        //Attendance Control
        public static bool bEnableGetInOutTimeMethod_Old = false;
        public static bool bEnableDoubleOT = false;
        public static bool bEnableDoubleOT_InWorkingDays = false;
        public static bool bEnableDoubleOT_Holidays = false;
        public static bool bEnableLateNopayBreakDown = false;
        public static decimal dMaximumLateMins_Office_PerDay = 0;
        public static decimal dMaximumLateMins_Factory = 0;
        public static bool bEnableLateHrs_Edit = false;
        public static bool bEnableShiftEnd_Actual_forEarlyExit = false;

        public static bool bEnableDivision = false;
        public static bool bEnableDepartment = false;
        public static bool bEnableSection = false;
        public static bool bEnableAttendanceGroup1 = false;

        public static bool bEnable_Roster = false;//roster enable in attendance control panel
        public static bool bEnableShiftRules_Selmo = false;

        public static bool bEnable_DivideLateNopay = false;//indika enterprises developments
        public static bool bEnable_ShiftGracePeriod_Deduction = false;


        //Enable months for payroll period
        public static bool bEnable_MonthPayrollPeriod = false;

        //PAYROLL
        public static string sFactory_Employees_Category2_ID_i = "";
        public static string sFactory_Employees_Category2_ID_ii = "";

        public static string sCashPaymentMethod = "";
        public static string sBankTranferMethod = "";
        public static string sChequePaymentMethod = "";

        public static decimal dMaximumLateDays_Office = 0;
        public static decimal dMaximumLateDays_Factory = 0;
        public static string sLateGracePeriodPerDay_Office = "0";
        public static string sLateGracePeriodPerDay_Factory = "0";

        public static bool bEnable_LateMins_LateDays_GraceMins = false;

        //COMMON-PAYSLIP-ITEMS
        public static string sBasicSalary = "";
        public static string sBasicSalaryIncrement1 = "";
        public static string sBRA2 = "";
        public static string sBRA3 = "";
        public static string sBRA1 = "";

        public static string sOT_Normal = "";
        public static string sOT_Double = "";
        public static string sOT_Triple = "";

        public static string sNopay = "";
        public static string sLate = "";
        public static string sSaving = "";
        public static string sAdvance = "";
        public static string sLoan = "";
        public static string sPAYE = "";

        public static string sEPF_Employee = "";
        public static string sEPF_Company = "";
        public static string sETF = "";

        //CELCIUS PAYSLIP ITEMS
        public static string sShiftAllowance = "";
        public static string sFuelAllowance = "";
        public static string sPerformanceAllowance = "";
        public static string sAttendanceAllowance_CEL = "";

        //HERO-PAYSLIP-ITEMS 
        public static string sAttendance = "";
        public static string sAllowance1 = "";
        public static string sAllowance1_Deduction = "";
        public static string sIncrementAllowance = "";
        public static string sIncrementAllowance_Deduction = "";
        public static string sSlugRemoveAllowance = "";
        public static string sFoodAllowance = "";
        public static string sTeaMakingAllowance = "";
        public static string sTeaMakingAllowance_Deduction = "";
        public static string sMobileAllowance = "";
        public static string sTeleAllowance = "";
        public static string sBordingAllowance = "";
        public static string sBordingAllowance_Deduction = "";
        public static string sNightAllowance = "";
        public static string sHeatingAllowance = "";
        //Hero-Nature
        public static string sCocuntAllowance = "";
        public static string sCocuntAllowance_Deduction = "";
        public static string sCocountLoadingAllowance = "";
        public static string sLineLeaderAllowance = "";
        public static string sFilterClothAllowance = "";
        public static string sCleaningSalary = "";
        public static string sShellremovingAllowance = "";
        public static string sTravellingAllowance = "";
        public static string sStoresAllowance = "";
        public static string sStoresAllowance_Deduction = "";
        public static string sDryerAllowance = "";
        public static string sDryerAllowance_Deduction = "";

        //AKT-PAYSLIP ITEMS
        public static string sStampDuty_Deduction = "";
        public static string sLastMonthCoinage = "";
        public static string sCurrentMonthCoinage = "";
        public static string sLadiesNightShift_Allowance = "";

        //Payroll - Calculation Variables
        public static string sDivisionRate_OTimeClaculation_Factory = "0";
        public static string sDivisionRate_OTimeClaculation_Office = "0";
        public static string sDivisionRate_AllowanceClaculation_Factory = "0";
        public static string sDivisionRate_AllowanceClaculation_Office = "0";
        public static bool bLateCalculate_EndOfPayrollPeriod = false;
        public static bool bPayrollRawDataShow_HoursOnly = false;
        public static bool bPayrollReports_OldMethodActive = false;
        public static bool bLateCalculation_DeductGivenLateMaxTime = false;

        //Payroll - Calculation Variables - Hero Only
        public static string sAttendance_LessThan_HalfDay = "0";
        public static string sAttendance_LessThan_OneDay = "0";
        public static string sAttendance_LessThan_OneAndHalfDay = "0";

        //Holyday Type
        public static string sPoyaDay = "";
        public static string sMercantile = "";
        public static string sPublic = "";
        public static string sBank = "";
        public static string sCompany = "";

        //ALert Email for MD
        public static string sAlert_Email_MD = "";
        public static string sAlert_Designation = "";
        public static TimeSpan tsAlertTime = TimeSpan.Zero;

        //celcius attendance bonus calculation
        public static string sCel_AttendanceBonus_Rate = "0";

        public static string sAttendanceAllowanceApplyRate_One = "0";
        public static string sAttendanceAllowanceApplyRate_Two = "0";
        public static string sAttendanceAllowanceApplyRate_Three = "0";

        //celcius shift allowance calucation
        public static string sCel_ShiiftAllowance_Rate = "0";

        //Coconut Cutting System (Daily Configurations)
        public static string sCC_CutoffNutsWeekDay = "0";
        public static string sCC_CutoffNutsSatureday = "0";
        public static string sCC_CutoffNutsHoliday = "0";
        public static string sCC_RateWeekDay = "0";
        public static string sCC_RateSatureday = "0";
        public static string sCC_RateHoliday = "0";
        //Coconut Cutting System (Weekend Configurations)
        public static string sCC_DailyTargetNuts = "0";
        public static string sCC_DailyMarginNuts = "0";
        public static string sCC_IncrementRatePerNut = "0";
        public static string sCC_SalaryGereratingRate = "0";
        public static string sCC_BRA1Amount = "0";
        public static string sCC_BRA2Amount = "0";
        public static string sCC_BRA3Amount = "0";
        public static string sCC_AttendanceAllowanceAmount = "0";

        //headcount report margin times
        public static string sEmployeeHeadCounts_MarginTime = "0";

        //selmo roster shifts 2018-05-01
        public static string sShift_Day_Configuration = "default";
        public static string sShift_Night_Configuration = "default";
        public static string sShift_Off_Configuration = "default";
        public static string sShift24_Configuration = "default";

        //indika 
        public static decimal sLate_DeductionRate = 0;
        public static decimal dWorkingDaysForMonth = 0;

        //indika - departments
        public static string sDepartmentID_One = "";
        public static string sDepartmentID_Two = "";
        public static string sDepartmentID_Three = "";
        public static string sDepartmentID_Four = "";

        

        //indika - allowances
        public static string sRiskAllowance = "";
        public static string sStockAllowance = "";
        public static string sReimbursementAllowance = "";
        public static string sTransportAllowance = "";

        //Entitlement Allowances
        public static string EntitlementOne = "";
        public static string EntitlementTwo = "";
        public static string EntitlementThree = "";
        public static string EntitlementFour = "";
        
        //enable allowance - company
        public static bool bEnableAllowance_Hero = false;
        public static bool bEnableAllowance_Indika = false;
        public static bool bEnableAllowance_Celcius = false;
        public static bool bEnableAllowance_AKT = false;

        //enable - mandatory days 
        public static bool bEnable_DaysCalculation = false;

        //Enable Zero Attendance - Employees
        public static bool bDisable_ZeroAttendance_Employees = false;
        
        //Enable Attendance Data in Payslip
        public static bool bEnableAttendanceData_Payslip;

        public static string sCategoryItem1 = "";
        public static string sCategoryItem2 = "";
        public static string sCategoryItem3 = "";

        #endregion

        #region Company Values
        //Quotation
        public static string sCmp_qQuotationSubject = "";
        public static string sCmp_qPaymentTerms = "";
        public static string sCmp_qValidityPeriod = "";
        public static string sCmp_qDeliveryPeriod = "";
        public static string sCmp_qContactTelephone = "";
        public static string sCmp_qContactEmail = "";
        public static string sCmp_companyCode = "";
        public static bool bHideCompanyImageInReports = false;
        #endregion

        #region Other
        public static bool bIsTestLabelVisibleInMainForm = false;
        public static bool bProductActivated = false;
        

        #endregion


    }
}