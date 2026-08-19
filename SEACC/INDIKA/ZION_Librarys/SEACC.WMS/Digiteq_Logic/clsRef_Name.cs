using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;

namespace Digiteq_Logic
{
    public class clsRef_Name
    {
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
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasEmployee", "initails , surName", "employee_ID", ID));
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
        public static string get_Item_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "itemName", "item_ID", ID));
        }
        public static string get_Item_Description(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "description", "item_ID", ID));
        }
        public static string get_Item_UnitPriceD15(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "sellingPrice1", "item_ID", ID));
        }
        public static string get_Item_UnitPriceD30(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "sellingPrice2", "item_ID", ID));
        }
        public static string get_Item_UnitWeight(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "unitWeight", "item_ID", ID));
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

        public static string get_ItemClass_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemClass", "className", "itemClass_ID", ID));
        }

        public static string get_ItemType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemType", "typeName", "itemType_ID", ID));
        }

        public static string get_ItemCategory_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemCategory", "categoryName", "itemCategory_ID", ID));
        }

        public static string get_ItemBrand_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBrand", "brandName", "brand_ID", ID));
        }

        public static string get_UomCategory_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zUomCategory", "categoryName", "uomCategory_ID", ID));
        }
        public static string get_UoM_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zUom", "uomName", "uom_ID", ID));
        }
        public static string get_UoM_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zUom", "uomCode", "uom_ID", ID));
        }
        public static string get_UoM_ID(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "uom_ID", "item_ID", ID));
        }

        public static string get_CustomerClass_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerClass", "className", "customerClass_ID", ID));
        }

        public static string get_CustomerType_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerType", "typeName", "customerType_ID", ID));
        }

        public static string get_CustomerCategory_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerCategory", "categoryName", "customerCategory_ID", ID));
        }
        public static string get_Customer_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genCustomerMaster", "customerName", "customer_ID", ID));
        }
        public static string get_Customer_Address(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genCustomerMaster", "addressRegister", "customer_ID", ID));
        }
        public static string get_Store_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genStoreMaster", "storeName", "store_ID", ID));
        }
        public static string get_Vehicle_No(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "vehicle_No", "vehicleTracking_ID", ID));
        }
        public static string get_Vehicle_Date_In(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "checkinTime", "vehicleTracking_ID", ID));
        }
        public static string get_Vehicle_Date_Out(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "checkoutTime", "vehicleTracking_ID", ID));
        }
        public static string get_Container_No(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "container_No", "vehicleTracking_ID", ID));
        }
        public static string get_Driver_NIC(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "driverNic", "vehicleTracking_ID", ID));
        }
        public static string get_Driver_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_whTxn_VehicleTracker", "driverName", "vehicleTracking_ID", ID));
        }

        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
                    return "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "'"; 
            else
                return "";
        }
    }
}