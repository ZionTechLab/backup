using System;

namespace Digiteq_Logic
{
    public class clsConfig
    {
        public static string SoftwareVersion = "";
        public static string CompanyName = "";
        public static string CompanyAddress1 = "";
        public static string CompanyAddress2 = "";


        public static string CurrentHRYearID = DateTime.Now.Year.ToString();
        public static DateTime CurrentHRYear_StartDate = new DateTime(DateTime.Now.Year, 1, 1);
        //Convert.ToDateTime("01/01/2016");
        public static DateTime CurrentHRYear_EndDate = new DateTime(DateTime.Now.Year, 12, 31);
        //Convert.ToDateTime("12/31/2016");

        public static DateTime SystemExpireDate = clsConfig.defaultDateTime;

        public static string Format_Date = "yyyy/MM/dd";
        public static string Format_Time = "HH:mm";
        public static string Format_DateTime = "yyyy/MM/dd HH:mm";

        public static DateTime defaultDateTime = new DateTime(1800, 1, 1);

        public static string DefaultCountry = "cnty211";
        public static string DefaultNationality = "Na/166";
        public static string DefaultEmployeeStatus = "EST/005";

        public static string DefaultShift = "SFT/002";

        #region Config Values

        public static string sAdminCategoryID = "";

        //Remort Backup
        public static string sRemortDesktopExportPath = "";        //HRCM
        public static string sImportAttendanceDataSW_path = "";
        public static string sSERVII_BackupPath_Server = "";
        public static string sSERVII_BackupPreFix = "";
        public static string sSERVII_Backup_SourceFolder_1 = "";
        public static string sSERVII_Backup_SourceFolder_2 = "";
        public static string sSERVII_Backup_SourceFolder_3 = "";

        //Leave
        public static decimal dShortLeave_Hours = 0;
        public static decimal dShortLeave_GrassPeriod = 0;
        public static decimal dHalfDay_Hours = 0;
        public static decimal dHalfDay_GrassPeriod = 0;
        public static bool bIsEnableShortLeaveRoundUp = false;
        public static bool bIsEnablehalfDayRoundUp = false;


        //PAYROLL
        public static string sBasicSalary = "";
        public static string sIncrement1 = "";
        public static string sBRA2 = "";
        public static string sBRA3 = "";
        public static string sBRA1 = "";

        public static string sAttendance = "";
        public static string sOT_Normal = "";
        public static string sOT_Double = "";

        public static string sNopay = "";
        public static string sLate = "";
        public static string sSaving = "";
        public static string sAdvance = "";
        public static string sLoan = "";

        public static string sEPF_Employee = "";
        public static string sEPF_Company = "";
        public static string sETF = "";

        public static string sAllowance1 = "";
        public static string sIncrementAllowance = "";
        public static string sSlugRemoveAllowance = "";
        public static string sFoodAllowance = "";
        public static string sTeaMakingAllowance = "";
        public static string sMobileAllowance = "";
        public static string sTeleAllowance = "";
        public static string sBordingAllowance = "";
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
        #endregion
    }
}