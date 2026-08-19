using System;
using System.Data;
using DataTire;
using System.Collections.Generic;

namespace Digiteq_Logic
{
    public class clsRef_Name
    {
        public static string get_FunctionCategory_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_securityFunctionCategory", "categoryName", "functionCategory_ID", ID));
        }

        public static string get_leaveType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasLeaveTypes", "leaveType_Name", "leaveType_ID", ID));
        }

        public static string get_Department_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasDepartment", "DepartmentName", "department_ID", ID));
        }

        public static string get_Designation_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasDesignation", "Designation_name", "designation_ID", ID));
        }

        public static string get_Shift_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_tasShiftMaster", "shift_Name", "shift_ID", ID));
        }

        public static string get_PayemntMethode_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasPaymentMethod", "paymentMethodName", "paymentMethod_ID", ID));
        }

        public static string get_Bank_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasBank", "bankName", "bank_ID", ID));
        }

        public static string get_BankBranch_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasBankBranch", "branchName", "bankBranch_ID", ID));
        }
        public static string get_BankBranch_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasBankBranch", "bankBranch_code", "bankBranch_ID", ID));
        }

        public static string get_EmployeeName(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "fullName", "employee_ID", ID));
        }
        public static string get_EmployeeAliasName(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "aliasName", "employee_ID", ID));
        }
        public static string get_EmployeeShortName(string ID)
        {
            string surName = DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "surName", "employee_ID", ID));
            string initials = DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "initails", "employee_ID", ID));

            return surName + " ," + initials;
        }
        public static string get_EmployeeShortName_initialsFirst(string ID)
        {
            string surName = DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "surName", "employee_ID", ID));
            string initials = DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "initails", "employee_ID", ID));

            return initials + " " + surName;
        }

        public static string get_EmployeeEPFNo(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "epfNo", "employee_ID", ID));
        }
        public static string get_EmployeeNICNo(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "nicNo", "employee_ID", ID));
        }

        public static string get_MealType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrm_MealType", "mealType", "mealType_ID", ID));
        }

        public static string get_MenuType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrm_MenuType", "menu_Name", "menuType_ID", ID));
        }

        public static string get_EmployeeTitle_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasTitle", "title", "titleID", ID));
        }

        public static string get_Nationality_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasNationality", "nationality", "nationality_ID", ID));
        }

        public static string get_Religion_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasReligion", "religion", "religion_ID", ID));
        }

        public static string get_EmployeeCategory1_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasEmployeeCategory1", "empCatagory1_Name", "empCatagory1_ID", ID));
        }

        public static string get_EmployeeCategory2_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasEmployeeCategory2", "empCatagory2_Name", "empCatagory2_ID", ID));
        }

        public static string get_EmployeeCategory3_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasEmployeeCategory3", "empCatagory3_Name", "empCatagory3_ID", ID));
        }

        public static string get_Section_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasSection", "section_Name", "sectionID", ID));
        }

        public static string get_SubSection_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasSubSection", "subSectionName", "subSectionID", ID));
        }

        public static string get_RecuirtmentType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasRecuirtmentType", "recuirtmentType", "recuirtmentType_ID", ID));
        }

        public static string get_HolidayType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_tasHolidayType", "holydayType_Name", "holydayType_ID", ID));
        }

        public static string get_City_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasCity", "cityName", "city_ID", ID));
        }

        public static string get_District_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasDistrict", "districtName", "district_ID", ID));
        }

        public static string get_PostalCode_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasPostalCode", "town", "postalCode_ID", ID));
        }

        //public static string get_Nationality_Name(string ID)
        //{
        //    return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasNationality", "nationality", "nationality_ID", ID));
        //}

        public static string get_Country_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasCountry", "countryName", "country_ID", ID));
        }

        public static string get_HomeTown_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasTown", "townName", "town_ID", ID));
        }

        public static string get_Division_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasDivision", "divisionName", "division_ID", ID));
        }

        public static string get_Town_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasTown", "townName", "town_ID", ID));
        }

        public static string get_EmployeeStatus_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasEmployeeStatus", "emp_status_Name", "emp_statusID", ID));
        }

        public static string get_ProllLevel_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_PayMasPayrollLaval", "PayrollLavel", "payrollLevelID", ID));
        }

        public static string get_Province_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasProvince", "provinceName", "province_ID", ID));
        }
        public static string get_processGroup_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_ProcessGroup", "processGroup_Title", "processGroup_ID", ID));
        }
        public static string get_processPeriodMain_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_ProcessPeriod_Main", "processPeriod_Title", "processPeriod_ID", ID));
        }


        public static string get_GN_Division_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hr_MasGramaNiladhariUnit", "gn_DivisionName", "gn_DivisionCode", ID));
        }

        public static string get_UserGroup_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_securityGroup", "groupName", "group_ID", ID));
        }
        public static string get_Device_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrMasDevice", "device_Name", "device_ID", ID));
        }

        public static string get_PaySlipItems_Statutary_Title(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_StatutaryItems", "statutaryPayItem_Title", "statutaryPayItem_ID", ID));
        }
        public static string get_PaySlipItem_Title(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems", "payItem_Title", "payItem_ID", ID));
        }
        public static string get_PaySlipItem_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems", "payItem_Code", "payItem_ID", ID));
        }
        public static string get_PaySlipItem_Class_Title(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems_Class", "payItem_Class_Title", "payItem_Class_ID", ID));
        }
        public static string get_PaySlipItem_Class_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems_Class", "payItem_Class_Code", "payItem_Class_ID", ID));
        }
        public static string get_PaySlipItem_Type_Title(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems_Type", "payItem_Type_Title", "payItem_Type_ID", ID));
        }
        public static string get_PaySlipItem_Type_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_PaySlipItems_Type", "payItem_Type_Code", "payItem_Type_ID", ID));
        }
        public static string get_PayrollProcessGroup_Title(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_ProcessGroup", "processGroup_Title", "processGroup_ID", ID));
        }
        public static string get_PayrollProcessGroup_SubTitle(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_payMas_ProcessPeriod_Main", "processPeriod_Title", "processPeriod_ID", ID));
        }
        public static string get_MonthName(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrPeriod_Month", "month_Name", "month_ID", ID));
        }
        public static string get_YearName(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrPeriod_Year", "year_Name", "year_ID", ID));
        }
        public static string get_RegisterationDetails(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genRegistrationInfo", "companyCode", "reg_ID", ID));
        }

        public static string get_Attendance_ProcessGroup1(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmpAttendanceProcessGroup1", "attendanceGroup1_Name", "attendanceGroup1_ID", ID));
        }
        public static string get_Attendance_ProcessGroup2(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmpAttendanceProcessGroup2", "attendanceGroup2_Name", "attendanceGroup2_ID", ID));
        }
        public static string get_Attendance_ProcessPeriod(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmpAttendanceProcessPeriod", "attenProcessPeriod_Title", "attenProcessPeriod_ID", ID));
        }



        //Generate Query
        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
                return "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "'";
            else
                return "";
        }

        
    }
}