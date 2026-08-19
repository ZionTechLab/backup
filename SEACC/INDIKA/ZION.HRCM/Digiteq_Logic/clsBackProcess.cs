using DataTire;
using System;
using System.Collections.Generic;
using System.Data;

namespace Digiteq_Logic
{
    public class clsBackProcess
    {
        public static void AutoAssignConfigValue()
        {
            foreach (tbl_securityConfigValue detail in tbl_securityConfigValue.SelectAll())
            {
                switch (detail.ValueID)
                {
                    #region SETTINGS
                    case 1://System Expire Date
                        clsConfig.SystemExpireDate = DateTime.Parse(detail.ConfigValue).Date;
                        break;
                    case 2://Admin Category ID
                        clsConfig.sAdminCategoryID = detail.ConfigValue;
                        break;
                    case 3://Form Title Name
                        //clsConfig. = detail.ConfigValue;
                        break;
                    case 207:
                        clsConfig.sImportAttendanceDataSW_path = detail.ConfigValue;
                        break;

                    //Holyday Type
                    case 215:
                        clsConfig.sPoyaDay = detail.ConfigValue;
                        break;
                    case 216:
                        clsConfig.sMercantile = detail.ConfigValue;
                        break;
                    case 217:
                        clsConfig.sPublic = detail.ConfigValue;
                        break;
                    case 218:
                        clsConfig.sBank = detail.ConfigValue;
                        break;
                    case 219:
                        clsConfig.sCompany = detail.ConfigValue;
                        break;
                    #endregion

                    #region TAS
                    case 10:
                        clsConfig.dShortLeave_Hours = decimal.Parse(detail.ConfigValue);
                        break;
                    case 11:
                        clsConfig.dShortLeave_GrassPeriod = decimal.Parse(detail.ConfigValue);
                        break;
                    case 12:
                        clsConfig.dHalfDay_Hours = decimal.Parse(detail.ConfigValue);
                        break;
                    case 13:
                        clsConfig.dHalfDay_GrassPeriod = decimal.Parse(detail.ConfigValue);
                        break;
                    case 14:
                        clsConfig.sNoPayLeaveID = detail.ConfigValue;
                        break;
                    case 15:
                        clsConfig.dMaximumLateMins_Office_PerDay = decimal.Parse(detail.ConfigValue);
                        break;
                    case 16:
                        clsConfig.dMaximumLateMins_Factory = decimal.Parse(detail.ConfigValue);
                        break;
                    #endregion

                    #region PAYROLL
                    case 18:
                        clsConfig.sFactory_Employees_Category2_ID_i = detail.ConfigValue;
                        break;
                    case 19:
                        clsConfig.sFactory_Employees_Category2_ID_ii = detail.ConfigValue;
                        break;

                    #region Payslips
                    case 20:
                        clsConfig.sBasicSalary = detail.ConfigValue;
                        break;
                    case 21:
                        clsConfig.sBasicSalaryIncrement1 = detail.ConfigValue;
                        break;
                    case 22:
                        clsConfig.sNopay = detail.ConfigValue;
                        break;
                    case 23:
                        clsConfig.sLate = detail.ConfigValue;
                        break;
                    case 24:
                        clsConfig.sAttendance = detail.ConfigValue;
                        break;
                    case 25:
                        clsConfig.sBRA1 = detail.ConfigValue;
                        break;
                    case 26:
                        clsConfig.sBRA2 = detail.ConfigValue;
                        break;
                    case 27:
                        clsConfig.sBRA3 = detail.ConfigValue;
                        break;
                    case 28:
                        clsConfig.sOT_Normal = detail.ConfigValue;
                        break;
                    case 29:
                        clsConfig.sOT_Double = detail.ConfigValue;
                        break;
                    case 30:
                        clsConfig.sSaving = detail.ConfigValue;
                        break;
                    case 31:
                        clsConfig.sAdvance = detail.ConfigValue;
                        break;
                    case 32:
                        clsConfig.sEPF_Company = detail.ConfigValue;
                        break;
                    case 33:
                        clsConfig.sEPF_Employee = detail.ConfigValue;
                        break;
                    case 34:
                        clsConfig.sETF = detail.ConfigValue;
                        break;
                    case 36:
                        clsConfig.sLoan = detail.ConfigValue;
                        break;
                    case 37:
                        clsConfig.sPAYE = detail.ConfigValue;
                        break;
                    case 38:
                        clsConfig.sLastMonthCoinage = detail.ConfigValue;
                        break;
                    case 39:
                        clsConfig.sCurrentMonthCoinage = detail.ConfigValue;
                        break;
                    case 40:
                        clsConfig.sAllowance1 = detail.ConfigValue;
                        break;
                    case 41:
                        clsConfig.sSlugRemoveAllowance = detail.ConfigValue;
                        break;
                    case 42:
                        clsConfig.sFoodAllowance = detail.ConfigValue;
                        break;
                    case 43:
                        clsConfig.sTeaMakingAllowance = detail.ConfigValue;
                        break;
                    case 44:
                        clsConfig.sMobileAllowance = detail.ConfigValue;
                        break;
                    case 45:
                        clsConfig.sTeleAllowance = detail.ConfigValue;
                        break;
                    case 46:
                        clsConfig.sBordingAllowance = detail.ConfigValue;
                        break;
                    case 47:
                        clsConfig.sIncrementAllowance = detail.ConfigValue;
                        break;
                    case 48:
                        clsConfig.sHeatingAllowance = detail.ConfigValue;
                        break;
                    case 49:
                        clsConfig.sNightAllowance = detail.ConfigValue;
                        break;
                    case 50:
                        clsConfig.sAllowance1_Deduction = detail.ConfigValue;
                        break;
                    case 51:
                        clsConfig.sTeaMakingAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 52:
                        clsConfig.sBordingAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 53:
                        clsConfig.sCocuntAllowance = detail.ConfigValue;
                        break;
                    case 54:
                        clsConfig.sCocuntAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 55:
                        clsConfig.sCocountLoadingAllowance = detail.ConfigValue;
                        break;
                    case 56:
                        clsConfig.sLineLeaderAllowance = detail.ConfigValue;
                        break;
                    case 57:
                        clsConfig.sFilterClothAllowance = detail.ConfigValue;
                        break;
                    case 58:
                        clsConfig.sCleaningSalary = detail.ConfigValue;
                        break;
                    case 59:
                        clsConfig.sShellremovingAllowance = detail.ConfigValue;
                        break;
                    case 60:
                        clsConfig.sTravellingAllowance = detail.ConfigValue;
                        break;
                    case 61:
                        clsConfig.sStoresAllowance = detail.ConfigValue;
                        break;
                    case 62:
                        clsConfig.sStoresAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 63:
                        clsConfig.sIncrementAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 64:
                        clsConfig.sStampDuty_Deduction = detail.ConfigValue;
                        break;
                    case 65:
                        clsConfig.sOT_Triple = detail.ConfigValue;
                        break;
                    case 66:
                        clsConfig.sDryerAllowance = detail.ConfigValue;
                        break;
                    case 67:
                        clsConfig.sDryerAllowance_Deduction = detail.ConfigValue;
                        break;
                    case 68:
                        clsConfig.sShiftAllowance = detail.ConfigValue;
                        break;
                    case 69:
                        clsConfig.sFuelAllowance = detail.ConfigValue;
                        break;
                    case 70:
                        clsConfig.sPerformanceAllowance = detail.ConfigValue;
                        break;
                    case 71:
                        clsConfig.sAttendanceAllowance_CEL = detail.ConfigValue;
                        break;

                    //indika - allowances
                    case 72:
                        clsConfig.sRiskAllowance = detail.ConfigValue;
                        break;
                    case 73:
                        clsConfig.sStockAllowance = detail.ConfigValue;
                        break;
                    case 74:
                        clsConfig.sReimbursementAllowance = detail.ConfigValue;
                        break;
                    case 75:
                        clsConfig.sTransportAllowance = detail.ConfigValue;
                        break;

                    //Indika Allowance - Entitlements
                    case 76:
                        clsConfig.EntitlementOne = detail.ConfigValue;
                        break;
                    case 77:
                        clsConfig.EntitlementTwo = detail.ConfigValue;
                        break;
                    case 78:
                        clsConfig.EntitlementThree = detail.ConfigValue;
                        break;
                    case 79:
                        clsConfig.EntitlementFour = detail.ConfigValue;
                        break;


                    case 85:
                        clsConfig.sLadiesNightShift_Allowance = detail.ConfigValue;
                        break;

                    #endregion

                    case 100:
                        clsConfig.sDivisionRate_OTimeClaculation_Office = detail.ConfigValue;
                        break;
                    case 101:
                        clsConfig.sDivisionRate_OTimeClaculation_Factory = detail.ConfigValue;
                        break;
                    case 102:
                        clsConfig.sDivisionRate_AllowanceClaculation_Office = detail.ConfigValue;
                        break;
                    case 103:
                        clsConfig.sDivisionRate_AllowanceClaculation_Factory = detail.ConfigValue;
                        break;
                    case 104:
                        clsConfig.dMaximumLateDays_Office = decimal.Parse(detail.ConfigValue);
                        break;
                    case 105:
                        clsConfig.dMaximumLateDays_Factory = decimal.Parse(detail.ConfigValue);
                        break;
                    case 106:
                        clsConfig.sLateGracePeriodPerDay_Office = detail.ConfigValue;
                        break;
                    case 107:
                        clsConfig.sLateGracePeriodPerDay_Factory = detail.ConfigValue;
                        break;


                    //attendance configs
                    case 108:
                        clsConfig.sAttendance_LessThan_HalfDay = detail.ConfigValue;
                        break;
                    case 109:
                        clsConfig.sAttendance_LessThan_OneDay = detail.ConfigValue;
                        break;
                    case 110:
                        clsConfig.sAttendance_LessThan_OneAndHalfDay = detail.ConfigValue;
                        break;


                    //Employee Categorys
                    case 120:
                        clsConfig.sCategoryItem1 = detail.ConfigValue;
                        break;
                    case 121:
                        clsConfig.sCategoryItem2 = detail.ConfigValue;
                        break;
                    case 122:
                        clsConfig.sCategoryItem3 = detail.ConfigValue;
                        break;


                    //shifts
                    case 200:
                        clsConfig.DefaultShift = detail.ConfigValue;
                        break;
                    case 201:
                        clsConfig.sLadiesNightShift = detail.ConfigValue;
                        break;
                    case 202:
                        clsConfig.s24NightShifts = detail.ConfigValue;
                        break;
                    case 203:
                        clsConfig.sNightShifts = detail.ConfigValue;
                        break;

                    //payment method configs
                    case 204:
                        clsConfig.sChequePaymentMethod = detail.ConfigValue;
                        break;
                    case 205:
                        clsConfig.sBankTranferMethod = detail.ConfigValue;
                        break;
                    case 206:
                        clsConfig.sCashPaymentMethod = detail.ConfigValue;
                        break;
                    #endregion

                    #region Backup Configs
                    case 208:
                        clsConfig.sHRCM_BackupPath_Server = detail.ConfigValue;
                        break;
                    case 209:
                        clsConfig.sHRCM_Backup_SourceFolder_1 = detail.ConfigValue;
                        break;
                    case 210:
                        clsConfig.sHRCM_Backup_SourceFolder_2 = detail.ConfigValue;
                        break;
                    case 211:
                        clsConfig.sHRCM_Backup_SourceFolder_3 = detail.ConfigValue;
                        break;
                    case 212:
                        clsConfig.sHRCM_BackupPreFix = detail.ConfigValue;
                        break;

                    #endregion

                    #region E-mail
                    case 250:
                        clsConfig.sAlert_Designation = detail.ConfigValue;
                        break;
                    case 251:
                        clsConfig.sAlert_Email_MD = detail.ConfigValue;
                        break;
                    case 252:
                        clsConfig.tsAlertTime = TimeSpan.Parse(detail.ConfigValue);
                        break;
                    #endregion

                    case 260:
                        clsConfig.sShortLeaveID = detail.ConfigValue;
                        break;

                    //celcius attendance bonus calculation
                    case 300:
                        clsConfig.sCel_AttendanceBonus_Rate = detail.ConfigValue;
                        break;
                    case 301:
                        clsConfig.sAttendanceAllowanceApplyRate_One = detail.ConfigValue;
                        break;
                    case 302:
                        clsConfig.sAttendanceAllowanceApplyRate_Two = detail.ConfigValue;
                        break;
                    case 303:
                        clsConfig.sAttendanceAllowanceApplyRate_Three = detail.ConfigValue;
                        break;

                    //celcius shift allowance calculation 
                    case 310:
                        clsConfig.sCel_ShiiftAllowance_Rate = detail.ConfigValue;
                        break;

                    case 320:
                        clsConfig.sShift_Day_Configuration = detail.ConfigValue;
                        break;
                    case 321:
                        clsConfig.sShift_Night_Configuration = detail.ConfigValue;
                        break;
                    case 322:
                        clsConfig.sShift_Off_Configuration = detail.ConfigValue;
                        break;
                    case 333:
                        clsConfig.sShift24_Configuration = detail.ConfigValue;
                        break;

                    //add margin time to head count report
                    case 330:
                        clsConfig.sEmployeeHeadCounts_MarginTime = detail.ConfigValue;
                        break;
                    case 340:
                        clsConfig.sLate_DeductionRate = decimal.Parse(detail.ConfigValue);
                        break;

                    case 350:
                        clsConfig.dWorkingDaysForMonth = decimal.Parse(detail.ConfigValue);
                        break;

                    //Indika - department wise attendance
                    case 360:
                        clsConfig.sDepartmentID_One = detail.ConfigValue;
                        break;
                    case 361:
                        clsConfig.sDepartmentID_Two = detail.ConfigValue;
                        break;
                    case 362:
                        clsConfig.sDepartmentID_Three = detail.ConfigValue;
                        break;
                    case 363:
                        clsConfig.sDepartmentID_Four = detail.ConfigValue;
                        break;
                    case 364:
                        clsConfig.sLeaveTypes = detail.ConfigValue;
                        break;





                    #region Coconut Cutting System

                    #region Daily Configurations
                    case 400:
                        clsConfig.sCC_CutoffNutsWeekDay = detail.ConfigValue;
                        break;
                    case 401:
                        clsConfig.sCC_CutoffNutsSatureday = detail.ConfigValue;
                        break;
                    case 402:
                        clsConfig.sCC_CutoffNutsHoliday = detail.ConfigValue;
                        break;
                    case 403:
                        clsConfig.sCC_RateWeekDay = detail.ConfigValue;
                        break;
                    case 404:
                        clsConfig.sCC_RateSatureday = detail.ConfigValue;
                        break;
                    case 405:
                        clsConfig.sCC_RateHoliday = detail.ConfigValue;
                        break;
                    #endregion


                    #region Week Configurations
                    case 420:
                        clsConfig.sCC_DailyTargetNuts = detail.ConfigValue;
                        break;
                    case 421:
                        clsConfig.sCC_DailyMarginNuts = detail.ConfigValue;
                        break;
                    case 422:
                        clsConfig.sCC_IncrementRatePerNut = detail.ConfigValue;
                        break;
                    case 423:
                        clsConfig.sCC_SalaryGereratingRate = detail.ConfigValue;
                        break;
                    case 424:
                        clsConfig.sCC_BRA1Amount = detail.ConfigValue;
                        break;
                    case 425:
                        clsConfig.sCC_BRA2Amount = detail.ConfigValue;
                        break;
                    case 426:
                        clsConfig.sCC_BRA3Amount = detail.ConfigValue;
                        break;
                    case 427:
                        clsConfig.sCC_AttendanceAllowanceAmount = detail.ConfigValue;
                        break;
                        #endregion

                        #endregion


                }
            }
        }

        public static void AutoAssignConfigStatus()
        {
            foreach (tbl_securityConfigStatus detail in tbl_securityConfigStatus.SelectAll())
            {
                switch (detail.ValueID)
                {
                    case 1:
                        clsConfig.bIsEnableShortLeaveRoundUp = detail.ConfigValue;
                        break;
                    case 2:
                        clsConfig.bIsEnablehalfDayRoundUp = detail.ConfigValue;
                        break;
                    case 3:
                        clsConfig.bLateCalculate_EndOfPayrollPeriod = detail.ConfigValue;
                        break;
                    case 4:
                        clsConfig.bEnableDivision = detail.ConfigValue;
                        break;
                    case 5:
                        clsConfig.bEnableDepartment = detail.ConfigValue;
                        break;
                    case 6:
                        clsConfig.bEnableSection = detail.ConfigValue;
                        break;
                    case 7:
                        clsConfig.bProductActivated = detail.ConfigValue;
                        break;
                    case 8:
                        clsConfig.bPayrollRawDataShow_HoursOnly = detail.ConfigValue;
                        break;
                    case 9:
                        clsConfig.bPayrollReports_OldMethodActive = detail.ConfigValue;
                        break;
                    case 10:
                        clsConfig.bEnableLateHrs_Edit = detail.ConfigValue;
                        break;
                    case 11:
                        clsConfig.bEnableShiftEnd_Actual_forEarlyExit = detail.ConfigValue;
                        break;
                    case 12:
                        clsConfig.bLateCalculation_DeductGivenLateMaxTime = detail.ConfigValue;
                        break;
                    case 13:
                        clsConfig.bEnable_ShiftGracePeriod_Deduction = detail.ConfigValue;
                        break;
                    case 300:
                        clsConfig.bEnableGetInOutTimeMethod_Old = detail.ConfigValue;
                        break;
                    case 301:
                        clsConfig.bEnableDoubleOT = detail.ConfigValue;
                        break;
                    case 302:
                        clsConfig.bEnableLateNopayBreakDown = detail.ConfigValue;
                        break;
                    case 303:
                        clsConfig.bEnableDoubleOT_InWorkingDays = detail.ConfigValue;
                        break;
                    case 304:
                        clsConfig.bEnableDoubleOT_Holidays = detail.ConfigValue;
                        break;
                    case 305:
                        clsConfig.bEnable_Roster = detail.ConfigValue;
                        break;
                    case 306:
                        clsConfig.bEnable_DaysCalculation = detail.ConfigValue;
                        break;
                    case 307:
                        clsConfig.bDisable_ZeroAttendance_Employees = detail.ConfigValue;
                        break;
                    case 308:
                        clsConfig.bEnableAttendanceData_Payslip = detail.ConfigValue;
                        break;
                    case 309:
                        clsConfig.bEnable_MonthPayrollPeriod = detail.ConfigValue;
                        break;
                    case 500:
                        clsConfig.bHideCompanyImageInReports = detail.ConfigValue;
                        break;
                    case 120:
                        clsConfig.bEnable_LateMins_LateDays_GraceMins = detail.ConfigValue;
                        break;
                    case 125:
                        clsConfig.bEnableAttendanceGroup1 = detail.ConfigValue;
                        break;
                    case 130:
                        clsConfig.bEnableShiftRules_Selmo = detail.ConfigValue;
                        break;
                    case 140:
                        clsConfig.bEnable_DivideLateNopay = detail.ConfigValue;
                        break;
                    case 150:
                        clsConfig.bEnableAllowance_Hero = detail.ConfigValue;
                        break;
                    case 151:
                        clsConfig.bEnableAllowance_Celcius = detail.ConfigValue;
                        break;
                    case 152:
                        clsConfig.bEnableAllowance_Indika = detail.ConfigValue;
                        break;
                    case 153:
                        clsConfig.bEnableAllowance_AKT = detail.ConfigValue;
                        break;
                }
            }
        }
    }
}
