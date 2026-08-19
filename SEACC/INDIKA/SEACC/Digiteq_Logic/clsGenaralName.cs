using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;

namespace Digiteq_Logic
{
    public class clsGenaralName
    {
        public static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
            {
                string sResult = "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "' AND " + Key + " <> 'default'";
                return sResult != null ? sResult : "-";
            }
            else
                return "";
        }

        public static string GenarateQuery(string table, string field, string Key, int value)
        {
            if (value > 0)
            {
                string sResult = "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "' AND " + Key + " <> -1";
                return sResult != null ? sResult : "-";
            }
            else
                return "";
        }


        #region Item
        public static string getName_Item(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemName", "item_ID", Item_ID));
            return valueName;
        }
        public static string getDescription_Item(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "description", "item_ID", Item_ID));
            return valueName == "default" ? "-" : valueName;
        }
        public static string getItemClass_ID(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemClass_ID", "item_ID", Item_ID));
            return valueName;
        }
        public static string getItemCategory_ID(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemCategory_ID", "item_ID", Item_ID));
            return valueName;
        }

        public static string getItemCategorySub_ID(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemCategorySub_ID", "item_ID", Item_ID));
            return valueName;
        }

        public static string getCode_Item(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "generateCode", "item_ID", Item_ID));
            return valueName;
        }
        public static string getName_ItemUnitPrice(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "sellingPrice1", "item_ID", Item_ID));
            return valueName;
        }
        public static string getName_ItemUOM(string ItemID)
        {
            string valueName = getName_Uom(getName_ItemUOMID(ItemID));
            return valueName;
        }
        public static string getName_ItemUOMName(string ItemID)
        {
            string valueName = getName_Uom(getName_ItemUOMID(ItemID));
            return valueName;
        }
        public static string getName_ItemUOMID(string ItemID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "uom_ID", "item_ID", ItemID));
            return valueName;
        }
        public static string getName_ItemBrand(string ItemID)
        {
            string valueName = getName_Brand(getName_ItemBrandID(ItemID));
            return valueName;
        }
        public static string getName_ItemBrandID(string ItemID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "brand_ID", "item_ID", ItemID));
            return valueName;
        }
        public static string getName_ItemTypeIDByItemID(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemType_ID", "item_ID", Item_ID));
            return valueName;
        }
       
        public static string getItemCategorySub_ID_ByItemID(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemCategorySub_ID", "item_ID", Item_ID));
            return valueName;
        }
        #endregion

        #region ItemClass
        public static string getName_ItemClass(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemClass", "className", "itemClass_ID", ID));
            //tbl_zItemClass detail = tbl_zItemClass.Select(ID);
            //if (detail != null && detail.ItemClass_ID != "default")
            //    valueName = detail.ClassName;
            return valueName;
        }

        public static string getName_ItemClassPrefix(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemClass", "prefrix", "itemClass_ID", ID));
            //tbl_zItemClass detail = tbl_zItemClass.Select(ID);
            //if (detail != null && detail.ItemClass_ID != "default")
            //    valueName = detail.Prefrix;
            return valueName;
        }

        public static string getName_ItemClassPrefix2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemClass", "prefrix2", "itemClass_ID", ID));
            //tbl_zItemClass detail = tbl_zItemClass.Select(ID);
            //if (detail != null && detail.ItemClass_ID != "default")
            //    valueName = detail.Prefrix2;
            return valueName;
        }
        #endregion

        #region ItemType
        public static string getName_ItemType(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemType", "typeName", "itemType_ID", ID));
            //tbl_zItemType detail = tbl_zItemType.Select(ID);
            //if (detail != null && detail.ItemType_ID != "default")
            //    valueName = detail.TypeName;
            return valueName;
        }
        public static string getName_ItemTypePrefix(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemType", "prefrix", "itemType_ID", ID));
            //tbl_zItemType detail = tbl_zItemType.Select(ID);
            //if (detail != null && detail.ItemType_ID != "default")
            //    valueName = detail.Prefrix;
            return valueName;
        }
        public static string getName_ItemTypePrefix2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemType", "prefrix2", "itemType_ID", ID));
            //tbl_zItemType detail = tbl_zItemType.Select(ID);
            //if (detail != null && detail.ItemType_ID != "default")
            //    valueName = detail.Prefrix2;
            return valueName;
        }
        #endregion

        #region ItemCategory
        public static string getName_ItemCategory(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemCategory", "categoryName", "itemCategory_ID", ID));
            //tbl_zItemCategory detail = tbl_zItemCategory.Select(ID);
            //if (detail != null && detail.ItemCategory_ID != "default")
            //    valueName = detail.CategoryName;
            return valueName;
        }
        public static string getName_ItemCategoryPrefix(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemCategory", "prefrix", "itemCategory_ID", ID));
            //tbl_zItemCategory detail = tbl_zItemCategory.Select(ID);
            //if (detail != null && detail.ItemCategory_ID != "default")
            //    valueName = detail.Prefrix;
            return valueName;
        }
        public static string getName_ItemCategoryPrefix2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemCategory", "prefrix2", "itemCategory_ID", ID));
            //tbl_zItemCategory detail = tbl_zItemCategory.Select(ID);
            //if (detail != null && detail.ItemCategory_ID != "default")
            //    valueName = detail.Prefrix2;
            return valueName;
        }
        #endregion

        #region Brand
        public static string getName_Brand(string ID)
        {
            //string valueName = DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBrand", "itemType_ID", "item_ID", ID));
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zBrand", "brandName", "brand_ID", ID));
            //tbl_zBrand detail = tbl_zBrand.Select(ID);
            //if (detail != null)
            //    valueName = detail.BrandName;
            return valueName;
        }
        #endregion

        #region Tag
        public static string getName_Tag1(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag1", "description", "tag1_ID", ID));
            return valueName;
        }
        public static string getName_Tag2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag2", "description", "tag2_ID", ID));
            return valueName;
        }

        public static string getName_Tag3(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag3", "description", "tag3_ID", ID));
            return valueName;
        }
        public static string getName_Tag3Prefix(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag3", "prefix", "tag3_ID", ID));
            return valueName;
        }
        public static string getName_Tag3Prefix2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag3", "prefrix2", "tag3_ID", ID));
            return valueName;
        }

        public static string getName_Tag4(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag4", "description", "tag4_ID", ID));
            return valueName;
        }
        public static string getName_Tag4Prefix(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag4", "prefix", "tag4_ID", ID));
            return valueName;
        }
        public static string getName_Tag4Prefix2(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zItemTag4", "prefrix2", "tag4_ID", ID));
            return valueName;
        }
        #endregion

        #region Uom
        public static string getName_Uom(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zUom", "uomCode", "uom_ID", ID));
            return valueName;
        }

        public static string getName_UomAndCode(string ID)
        {
            string valueName = "-";
            tbl_zUom detail = tbl_zUom.Select(ID);
            if (detail != null && detail.Uom_ID != "default")
                valueName = detail.UomCode + " - " + detail.UomName;
            return valueName;
        }
        #endregion

        #region Uom Category
        public static string getName_UomCategory(string ID)
        {
            string valueName = "";
            tbl_zUomCategory detail = tbl_zUomCategory.Select(ID);
            if (detail != null)
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region Area
        public static string getName_Area(string ID)
        {
            string valueName = "";
            tbl_zArea detail = tbl_zArea.Select(ID);
            if (detail != null)
                valueName = detail.AreaName;
            return valueName;
        }
        #endregion

        #region Route
        //public static string getName_Route(string ID)
        //{
        //    string valueName = "";
        //    tbl_genRouteMaster detail = tbl_genRouteMaster.Select(ID);
        //    if (detail != null)
        //        valueName = detail.RouteName;
        //    return valueName;
        //}
        public static string getCode_Route(int ID)
        {
            string valueName = "";
            tbl_genRoute detail = tbl_genRoute.Select(ID);
            if (detail != null)
                valueName = detail.Route_Code;
            return valueName;
        }
        public static string get_RouteName(int ID)
        {
            string valueName = "";
            tbl_genRoute detail = tbl_genRoute.Select(ID);
            if (detail != null)
                valueName = detail.RouteName;
            return valueName;
        }
        public static string getSalesNoteType_ByRoute(string salesNoteName)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zSalesNoteType", "salesNoteType_ID", "salesNoteName", salesNoteName));
            return valueName;
        }
        #endregion

        #region City
        public static string getName_City(string ID)
        {
            string valueName = "";
            tbl_zCity detail = tbl_zCity.Select(ID);
            if (detail != null)
                valueName = detail.CityName;
            return valueName;
        }
        #endregion

        #region Town
        public static string getName_Town(string ID)
        {
            string valueName = "";
            tbl_zTown detail = tbl_zTown.Select(ID);
            if (detail != null)
                valueName = detail.TownName;
            return valueName;
        }
        #endregion

        #region TownID by CustomerID
        public static string getName_TownIDByCustomerID(string sCustomerID)
        {
            string valueName = "default";
            try
            {
                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    if (customer.Town_ID != null && customer.Town_ID != "default")
                        valueName = customer.Town_ID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
            }
            return valueName;
        }
        #endregion

        #region RouteID by CustomerID
        public static string getName_RouteIDByCustomerID(string sCustomerID)
        {
            string valueName = "default";
            try
            {
                List<tbl_genCustomerMaster_Route> cusRoutes = tbl_genCustomerMaster_Route.SelectAllByCustomer_ID(sCustomerID);
                foreach (tbl_genCustomerMaster_Route cusRoute in cusRoutes)
                {
                    if (cusRoute.Route_ID != "default")
                    {
                        valueName = cusRoute.Route_ID;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
            }
            return valueName;
        }

        
        #endregion

        #region Country
        public static string getName_Country(string ID)
        {
            string valueName = "";
            tbl_zCountry detail = tbl_zCountry.Select(ID);
            if (detail != null)
                valueName = detail.CountryName;
            return valueName;
        }
        #endregion

        #region Currency
        public static string getName_Currency(string Currency_ID)
        {
            string valueName = "";
            tbl_zCurrency detail = tbl_zCurrency.Select(Currency_ID);
            if (detail != null && detail.Currency_ID != "default")
                valueName = detail.CurrencyName;
            return valueName;
        }
        public static string getName_CurrencyCode(string Currency_ID)
        {
            string valueName = "";
            tbl_zCurrency detail = tbl_zCurrency.Select(Currency_ID);
            if (detail != null)
                valueName = detail.CurrencyCode;
            return valueName;
        }
        #endregion

        #region District
        public static string getName_District(string ID)
        {
            string valueName = "";
            tbl_zDistrict detail = tbl_zDistrict.Select(ID);
            if (detail != null)
                valueName = detail.DistrictName;
            return valueName;
        }
        #endregion

        #region Province
        public static string getName_Province(string ID)
        {
            string valueName = "";
            tbl_zProvince detail = tbl_zProvince.Select(ID);
            if (detail != null)
                valueName = detail.ProvinceName;
            return valueName;
        }
        #endregion

        #region Order Ref No
        public static string getName_OrderRefNo(string ID)
        {
            string valueName = "";
            if (ID != null && ID != "")
            {
                tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(ID);
                if (detail != null && detail.OrderRefNo_ID != "default")
                    valueName = detail.OrderRefNo;
            }
            return valueName;
        }
        #endregion

        #region Issued Ref No
        public static string getName_IssuedRefNo(string ID)
        {
            string valueName = "";
            tbl_zIssuedRefNo detail = tbl_zIssuedRefNo.Select(ID);
            if (detail != null)
                valueName = detail.IssuedRefNo;
            return valueName;
        }
        #endregion

        #region Schedule
        public static string getName_Schedule(string ID)
        {
            string valueName = "";
            tbl_zSchedule detail = tbl_zSchedule.Select(ID);
            if (detail != null)
                valueName = detail.ScheduleName;
            return valueName;
        }
        #endregion

        #region Month Number
        public static int getMonthNumber(string Name)
        {
            int valueName = 1;
            tbl_zMonth detail = tbl_zMonth.Select(Name);
            if (detail != null)
                valueName = detail.MonthNumber;

            return valueName;
        }
        #endregion


        #region Supplier
        public static string getName_Supplier(string ID)
        {
            string valueName = "";
            tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(ID);
            if (detail != null)
                valueName = detail.SupplierName;
            return valueName;
        }
        #endregion

        #region Payee
        public static string getName_SupplierPayee(string ID)
        {
            string valueName = "";
            tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(ID);
            if (detail != null)
                valueName = detail.Payee;
            return valueName;
        }
        #endregion

        #region SupplierClass
        public static string getName_SupplierClass(string ID)
        {
            string valueName = "";
            tbl_zSupplierClass detail = tbl_zSupplierClass.Select(ID);
            if (detail != null)
                valueName = detail.ClassName;
            return valueName;
        }
        #endregion

        #region SupplierType
        public static string getName_SupplierType(string ID)
        {
            string valueName = "";
            tbl_zSupplierType detail = tbl_zSupplierType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region SupplierCategory
        public static string getName_SupplierCategory(string ID)
        {
            string valueName = "";
            tbl_zSupplierCategory detail = tbl_zSupplierCategory.Select(ID);
            if (detail != null)
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region Bank
        public static string getName_Bank(string ID)
        {
            string valueName = "";
            tbl_zBank detail = tbl_zBank.Select(ID);
            if (detail != null)
                valueName = detail.BankName;
            return valueName;
        }
        public static string getShortName_Bank(string ID)
        {
            string valueName = "";
            tbl_zBank detail = tbl_zBank.Select(ID);
            if (detail != null)
                valueName = detail.SortName;
            return valueName;
        }
        #endregion

        #region BankBranch
        public static string getName_BankBranch(string ID)
        {
            string valueName = "";
            tbl_zBankBranches detail = tbl_zBankBranches.Select(ID);
            if (detail != null)
                valueName = detail.BranchName;
            return valueName;
        }
        #endregion

        #region ChequeType
        public static string getName_ChequeType(string ID)
        {
            string valueName = "";
            tbl_zChequeType detail = tbl_zChequeType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region ChequeStatus
        public static string getName_ChequeStatus(string ID)
        {
            string valueName = "";
            tbl_zChequeStatus detail = tbl_zChequeStatus.Select(ID);
            if (detail != null)
                valueName = detail.StatusName;
            return valueName;
        }
        #endregion

        #region ChequeRegister
        public static string getName_ChequeNo(string ID)
        {
            string valueName = "";
            tbl_bpsChequeRegister detail = tbl_bpsChequeRegister.Select(ID);
            if (detail != null && detail.ChequeRegister_ID != "default")
                valueName = detail.ChequeNumber;
            return valueName;
        }
        #endregion

        #region Customer
        public static string getName_Customer(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "customerName", "customer_ID", ID));
            return valueName;
        }

        public static string getName_CustomerCode(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "customerCode", "customer_ID", ID));
            return valueName;
        }

        public static string getName_CustomerDeliveryAddress(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "addressDelivery", "customer_ID", ID));
            return valueName;
        }
        public static string getName_CustomerRegisterAddress(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "addressRegister", "customer_ID", ID));
            return valueName;
        }
        public static string getName_BranchCustomer(string CustomerID, int iLineNo)
        {
            string valueName = "";
            tbl_genCustomerMaster_Branches detail = tbl_genCustomerMaster_Branches.Select(CustomerID, iLineNo);
            if (detail != null)
                valueName = detail.BranchName;
            return valueName;
        }
        public static string getName_CustomerTelephone(string CustomerID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "telephone", "customer_ID", CustomerID));
            return valueName;
        }
        public static string getVATRegNo_Customer(string CustomerID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCustomerMaster", "vatRegistrationNo", "customer_ID", CustomerID));
            return valueName;
        }

        public static string getCustomerID_FromCO(string sCustomerOrderId)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_sasCustomerOrder", "customer_ID", "customerOrder_ID", sCustomerOrderId));
            return valueName;
        }

        #endregion

        #region CustomerClass
        public static string getName_CustomerClass(string ID)
        {
            string valueName = "-";
            tbl_zCustomerClass detail = tbl_zCustomerClass.Select(ID);
            if (detail != null && detail.CustomerClass_ID.ToLower() != "default")
                valueName = detail.ClassName;
            return valueName;
        }
        #endregion

        #region CustomerType
        public static string getName_CustomerType(string ID)
        {
            string valueName = "-";
            tbl_zCustomerType detail = tbl_zCustomerType.Select(ID);
            if (detail != null && detail.CustomerType_ID.ToLower() != "default")
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region CustomerCategory
        public static string getName_CustomerCategory(string ID)
        {
            string valueName = "-";
            tbl_zCustomerCategory detail = tbl_zCustomerCategory.Select(ID);
            if (detail != null && detail.CustomerCategory_ID.ToLower() != "default")
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region User        
        public static string getName_User(string ID)
        {
            string valueName = "";
            valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_securityUserMaster", "userName", "user_ID", ID));
            return valueName;
        }
        #endregion

        #region Employee
        public static string getName_Employee(string ID)
        {
            string valueName = "-";
            tbl_genEmployeeMaster detail = tbl_genEmployeeMaster.Select(ID);
            if (detail != null && detail.Employee_ID != "default")
                valueName = detail.EmployeeName;
            return valueName;
        }
        #endregion

        #region Sales Manager
        public static string getName_SalesManager(string ID)
        {
            string valueName = "";
            tbl_ZEmpSalesManager detail = tbl_ZEmpSalesManager.Select(ID);
            if (detail != null)
                valueName = detail.SalesManagerName;
            return valueName;
        }
        #endregion

        #region Sales Manager
        public static string getName_SalesExecutive(string ID)
        {
            string valueName = "";
            tbl_ZEmpSalesExecutive detail = tbl_ZEmpSalesExecutive.Select(ID);
            if (detail != null)
                valueName = detail.SalesExecutiveName;
            return valueName;
        }
        #endregion


        #region Area Manager
        public static string getName_AreaManager(string ID)
        {
            string valueName = "";
            tbl_ZEmpAreaManager detail = tbl_ZEmpAreaManager.Select(ID);
            if (detail != null)
                valueName = detail.AreaManagerName;
            return valueName;
        }
        #endregion

        #region UserDepartment
        public static string getName_UserDepartment(string ID)
        {
            string valueName = "";
            tbl_securityGroup detail = tbl_securityGroup.Select(ID);
            if (detail != null)
            {
                valueName = detail.GroupName;
            }
            return valueName;
        }
        #endregion

        #region Group
        public static string getName_Group(string ID)
        {
            string valueName = "";
            tbl_securityGroup detail = tbl_securityGroup.Select(ID);
            if (detail != null)
            {
                valueName = detail.GroupName;
            }
            return valueName;
        }
        #endregion

        #region FormMaster
        public static string getName_FormMaster(int iFormID)
        {
            string valueName = "";
            tbl_securityFormMaster detail = tbl_securityFormMaster.Select(iFormID);
            if (detail != null)
                valueName = detail.FormName;
            return valueName;
        }
        #endregion

        #region Driver
        public static string getName_Driver(string ID)
        {
            string valueName = "";
            tbl_zDriver detail = tbl_zDriver.Select(ID);
            if (detail != null)
                valueName = detail.DriverName;
            return valueName;
        }
        #endregion

        #region Driver NIC
        public static string getName_DriverNIC(string ID)
        {
            string valueName = "";
            tbl_zDriver detail = tbl_zDriver.Select(ID);
            if (detail != null)
                valueName = detail.NicNo;
            return valueName;
        }
        #endregion

        #region Assistant
        public static string getName_Assistant(string ID)
        {
            string valueName = "";
            tbl_zAssistant detail = tbl_zAssistant.Select(ID);
            if (detail != null)
                valueName = detail.AssistantName;
            return valueName;
        }
        #endregion

        #region Vehicle
        public static string getName_Vahicle(string ID)
        {
            string valueName = "";
            tbl_zVehicle detail = tbl_zVehicle.Select(ID);
            if (detail != null)
                valueName = detail.VehicleName;
            return valueName;
        }
        #endregion

        #region Department
        public static string getName_Department(string ID)
        {
            string valueName = "";
            tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(ID);
            if (detail != null && detail.Department_ID != "default")
                valueName = detail.DepartmentName;
            return valueName;
        }
        #endregion

        #region Section
        public static string getName_Section(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genSectionMaster", "sectionName", "section_ID", ID));
            return valueName;
        }

        public static string getStoreID_Section(string sSectionID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genSectionMaster", "store_ID", "section_ID", sSectionID));
            return valueName;
        }


        #endregion

       
        #region Store
        public static string getName_Store(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genStoreMaster", "storeName", "store_ID", ID));
            return valueName;
        }
        public static string getName_Store_Short(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genStoreMaster", "store_ShortName", "store_ID", ID));
            return valueName;
        }
        public static string getAddress_Store(string ID)
        {
            string valueAdress = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genStoreMaster", "adress", "store_ID", ID));
            return valueAdress;
        }
        public static string getCompanyBranchID_Store(string sStore_ID)
        {
            string bBranch_ID = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genStoreMaster", "companyBranch_ID", "store_ID", sStore_ID));
            return bBranch_ID;
        }
        #endregion

        #region Quotation Type
        public static string getName_QuotationType(string ID)
        {
            string valueName = "";
            tbl_zQuotationType detail = tbl_zQuotationType.Select(ID);
            if (detail != null)
                valueName = detail.QuotationTypeName;
            return valueName;
        }

        public static string getName_QuotationTerms(string ID)
        {
            string valueName = "";
            tbl_zQuotationTerms detail = tbl_zQuotationTerms.Select(ID);
            if (detail != null)
                valueName = detail.QTerm_DESC;
            return valueName;
        }
        #endregion

        #region Financial Year
        public static string getName_FinancialYear(string ID)
        {
            string valueName = "";
            tbl_accFinancialYearMaster detail = tbl_accFinancialYearMaster.Select(ID);
            if (detail != null)
                valueName = detail.FinancialYearName;
            return valueName;
        }
        #endregion

        // Employe

        #region SalesRep
        public static string getName_SalesRep(string ID)
        {
            string valueName = "-";
            tbl_ZEmpSalesRep detail = tbl_ZEmpSalesRep.Select(ID);
            if (detail != null && detail.SelesRep_ID.ToLower() != "default")
                valueName = detail.SelesRepName;
            return valueName;
        }
        #endregion

        #region Emp Supervisor Name
        public static string getName_EmpSupervisorName(string ID)
        {
            string valueName = "";
            tbl_zEmpSupervisor detail = tbl_zEmpSupervisor.Select(ID);
            if (detail != null)
                valueName = detail.SupervisorName;
            return valueName;
        }
        #endregion

        #region Sales Emp Operator
        public static string getName_EmpOperatorName(string ID)
        {
            string valueName = "";
            tbl_zEmpOperator detail = tbl_zEmpOperator.Select(ID);
            if (detail != null)
                valueName = detail.OperatorName;
            return valueName;
        }
        #endregion


        // Job Detail Area

        #region Polythine Type
        public static string getName_PolytheneType(string ID)
        {
            string valueName = "";
            tbl_zJobPolytheneType detail = tbl_zJobPolytheneType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Polythine Materail Type
        public static string getName_PolytheneMaterailType(string ID)
        {
            string valueName = "";
            tbl_zJobPolytheneMaterialType detail = tbl_zJobPolytheneMaterialType.Select(ID);
            if (detail != null)
                valueName = detail.PolytheneMaterailTypeName;
            return valueName;
        }
        #endregion

        #region Sealing Type
        public static string getName_SealingType(string ID)
        {
            string valueName = "";
            tbl_zJobSealingType detail = tbl_zJobSealingType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Sealing Method
        public static string getName_SealingMethod(string ID)
        {
            string valueName = "";
            tbl_zJobSealingMethod detail = tbl_zJobSealingMethod.Select(ID);
            if (detail != null)
                valueName = detail.SealingMethod;
            return valueName;
        }
        #endregion

        #region Slitting Type
        public static string getName_SlittingType(string ID)
        {
            string valueName = "";
            tbl_zJobSlittingType detail = tbl_zJobSlittingType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Mesurement Type
        public static string getName_MesurementType(string ID)
        {
            string valueName = "";
            tbl_zJobMeasurementType detail = tbl_zJobMeasurementType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Lamination Type
        public static string getName_LaminationType(string ID)
        {
            string valueName = "";
            tbl_zJobLaminationType detail = tbl_zJobLaminationType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Lamination Materail Type
        public static string getName_LaminationMaterailType(string ID)
        {
            string valueName = "";
            tbl_zJobLaminationMaterialType detail = tbl_zJobLaminationMaterialType.Select(ID);
            if (detail != null)
                valueName = detail.LaminationMaterailTypeName;
            return valueName;
        }
        #endregion

        #region Pouch Type
        public static string getName_PouchType(string ID)
        {
            string valueName = "";
            tbl_zJobPouchType detail = tbl_zJobPouchType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Print Type
        public static string getName_PrintType(string ID)
        {
            string valueName = "";
            tbl_zJobPrintingType detail = tbl_zJobPrintingType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Job Category
        public static string getName_JobCategory(string ID)
        {
            string valueName = "";
            tbl_zJobCategory detail = tbl_zJobCategory.Select(ID);
            if (detail != null)
                valueName = detail.JobCategoryName;
            return valueName;
        }
        #endregion

        #region Printing Type
        public static string getName_PrintingType(string ID)
        {
            string valueName = "";
            tbl_zJobPrintingType detail = tbl_zJobPrintingType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Printer
        public static string getName_Printer(string ID)
        {
            string valueName = "";
            tbl_zPrinterMaster detail = tbl_zPrinterMaster.Select(ID);
            if (detail != null)
                valueName = detail.PrinterName;
            return valueName;
        }
        #endregion

        #region Paper
        public static string getName_Paper(string ID)
        {
            string valueName = "";
            tbl_zPaperMaster detail = tbl_zPaperMaster.Select(ID);
            if (detail != null)
                valueName = detail.PaperName;
            return valueName;
        }
        #endregion

        #region Printing PrintMethod
        public static string getName_PrintMethod(string ID)
        {
            string valueName = "";
            tbl_zJobPrintingMethod detail = tbl_zJobPrintingMethod.Select(ID);
            if (detail != null)
                valueName = detail.PrintingMethod;
            return valueName;

        }
        #endregion

        #region Gussest Type
        public static string getName_GussestType(string ID)
        {
            string valueName = "";
            tbl_zJobGussestType detail = tbl_zJobGussestType.Select(ID);
            if (detail != null)
                valueName = detail.GussestTypeName;
            return valueName;
        }
        #endregion

        #region Handle Type
        public static string getName_HandleType(string ID)
        {
            string valueName = "";
            tbl_zJobHandleType detail = tbl_zJobHandleType.Select(ID);
            if (detail != null)
                valueName = detail.HandleTypeeName;
            return valueName;
        }
        #endregion

        #region Treatment Status
        public static string getName_TreatnmentStates(string ID)
        {
            string valueName = "";
            tbl_zJobTreatnmentStatus detail = tbl_zJobTreatnmentStatus.Select(ID);
            if (detail != null)
                valueName = detail.TreatnmentStatus;
            return valueName;
        }
        #endregion

        #region Production Job Type
        public static string getName_ProductionJobType(string ProductionJobTypeID)
        {
            string valueName = "";
            //tbl_zJobProductionJobType detail = tbl_zJobProductionJobType.Select(ProductionJobTypeID);
            //if (detail != null && detail.ProductionJobType_ID != "default")
            //    valueName = detail.ProductionJobTypeName;
            return valueName;
        }
        public static string getName_ProductionJobTypeGroup(string ProductionJobTypeID)
        {
            string valueName = "";

            if (ProductionJobTypeID == "PJT/001" || ProductionJobTypeID == "PJT/002")
                valueName = "Kandana";
            else if (ProductionJobTypeID == "PJT/003" || ProductionJobTypeID == "PJT/004")
                valueName = "Pettah";
            else if (ProductionJobTypeID == "PJT/009" || ProductionJobTypeID == "PJT/010")
                valueName = "Direct";
            else if (ProductionJobTypeID == "PJT/013" || ProductionJobTypeID == "PJT/014")
                valueName = "Block";

            return valueName;
        }
        #endregion

        #region Colour
        public static string getName_Colour(string ID)
        {
            string valueName = "-";
            tbl_zColour detail = tbl_zColour.Select(ID);
            if (detail != null && detail.Colour_ID != "default")
                valueName = detail.ColourName;
            return valueName;
        }
        public static string getName_ColourPrefix(string ID)
        {
            string valueName = "-";
            tbl_zColour detail = tbl_zColour.Select(ID);
            if (detail != null && detail.Colour_ID != "default")
                valueName = detail.Prefrix;
            return valueName;
        }
        public static string getName_ColourPrefix2(string ID)
        {
            string valueName = "-";
            tbl_zColour detail = tbl_zColour.Select(ID);
            if (detail != null && detail.Colour_ID != "default")
                valueName = detail.Prefrix2;
            return valueName;
        }
        #endregion


        //Stock
        #region Colour
        public static string getName_MRPCateogry(string ID)
        {
            string valueName = "";
            tbl_zMachineCategory detail = tbl_zMachineCategory.Select(ID);
            if (detail != null)
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region Stock Note Type
        public static string getName_StockNoteType(string ID)
        {
            string valueName = "";
            tbl_zStockNoteType detail = tbl_zStockNoteType.Select(ID);
            if (detail != null)
                valueName = detail.StockNoteName;
            return valueName;
        }
        #endregion


        //Sales
        #region Sales Note Type
        public static string getName_SalesNoteType(string ID)
        {
            string valueName = "";
            tbl_zSalesNoteType detail = tbl_zSalesNoteType.Select(ID);
            if (detail != null)
                valueName = detail.SalesNoteName;
            return valueName;
        }
        #endregion


        #region Item
        #region ItemCategory_Sub
        public static string getName_ItemCategorySub(string ID)
        {
            string valueName = "";
            tbl_zItemCategory_Sub detail = tbl_zItemCategory_Sub.Select(ID);
            if (detail != null)
                valueName = detail.CategorySubName;
            return valueName;
        }
        #endregion

        #region Item Class By Item TypeID
        public static string getName_ItemClassByItemTypeID(string ID)
        {
            string valueName = "";
            tbl_zItemType detail = tbl_zItemType.Select(ID);
            if (detail != null)
                valueName = detail.ItemClass_ID;
            return valueName;
        }
        #endregion

        #region Item Type By Item CategoryID
        public static string getName_ItemTypeByItemCategoryID(string ID)
        {
            string valueName = "";
            tbl_zItemCategory detail = tbl_zItemCategory.Select(ID);
            if (detail != null)
                valueName = detail.ItemType_ID;
            return valueName;
        }
        #endregion

        #region Item Category By Item ID
        public static string getName_ItemCategoryByItemID(string ID)
        {
            string valueName = "";
            tbl_genItemMaster detail = tbl_genItemMaster.Select(ID);
            if (detail != null)
                valueName = detail.ItemCategory_ID;
            return valueName;
        }
        #endregion

        #region Item Sub Category By Item ID
        public static string getID_ItemCategorySubByItemID(string sItem_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "itemCategorySub_ID", "item_ID", sItem_ID));
            return valueName;
        }
        #endregion

        #region Item Sub Category
        public static string getName_ItemSubCategory(string ID)
        {
            string valueName = "";
            tbl_zItemSubCategory detail = tbl_zItemSubCategory.Select(ID);
            if (detail != null && detail.ItemSubCategory_ID != "default")
                valueName = detail.ItemSubCategoryName;
            return valueName;
        }
        #endregion

        #region Item Sub Category 2
        public static string getName_ItemSubCategory2(string ID)
        {
            string valueName = "";
            tbl_zItemSubCategory2 detail = tbl_zItemSubCategory2.Select(ID);
            if (detail != null && detail.ItemSubCategory2_ID != "default")
                valueName = detail.ItemSubCategory2Name;
            return valueName;
        }
        #endregion

        #region Item getCategoryID
        public static string getCategoryID_ItemSubCategory(string ID)
        {
            string valueName = "";
            tbl_zItemCategory_Sub detail = tbl_zItemCategory_Sub.Select(ID);
            if (detail != null)
                valueName = detail.ItemCategory_ID;
            return valueName;
        }
        #endregion

        #region Item getSpesificationID
        public static string getName_SpesificationID(string ID)
        {
            string valueName = "";
            tbl_zItemSpecification detail = tbl_zItemSpecification.Select(ID);
            if (detail != null)
                valueName = detail.SepcificationName;
            return valueName;
        }
        #endregion

        #region Item Size
        public static string getName_ItemSize(string ID)
        {
            string valueName = "";
            tbl_zItemSize detail = tbl_zItemSize.Select(ID);
            if (detail != null)
                valueName = detail.ItemSizeName;
            return valueName;
        }
        #endregion

        #region Item Image
        public static string getName_ItemImagePath_ByItemID(string ID)
        {
            string valueName = "";
            tbl_genItemMaster detail = tbl_genItemMaster.Select(ID);
            if (detail != null)
                valueName = detail.ImagePath;
            return valueName;
        }
        #endregion 
        #endregion

        #region Machines
        #region Machine get CategoryID
        public static string getCategoryID_MachineSubCategory(string ID)
        {
            string valueName = "";
            tbl_zMachineCategory_Sub detail = tbl_zMachineCategory_Sub.Select(ID);
            if (detail != null)
                valueName = detail.MachineCategory_ID;
            return valueName;
        }
        #endregion

        #region Machine SubCategory
        public static string getName_MachineSubCategory(string ID)
        {
            string valueName = "";
            tbl_zMachineCategory_Sub detail = tbl_zMachineCategory_Sub.Select(ID);
            if (detail != null)
                valueName = detail.CategorySubName;
            return valueName;
        }
        #endregion

        #region Machine Master
        public static string getName_MachineMaster(string ID)
        {
            string valueName = "";
            tbl_genMachineMaster detail = tbl_genMachineMaster.Select(ID);
            if (detail != null)
                valueName = detail.MachineName;
            return valueName;
        }
        #endregion

        #region Machine Specification
        public static string getName_MachineSpecification(string sID)
        {
            string valueName = "";
            tbl_zMachineSpecification detail = tbl_zMachineSpecification.Select(sID);
            if (detail != null)
                valueName = detail.SepcificationName;
            return valueName;
        }
        #endregion

        #region Machine Type
        public static string getName_MachineType(string ID)
        {
            string valueName = "";
            tbl_zMachineType detail = tbl_zMachineType.Select(ID);
            if (detail != null)
                valueName = detail.TypeName;
            return valueName;
        }
        #endregion

        #region Machine Class
        public static string getName_MachineClass(string ID)
        {
            string valueName = "";
            tbl_zMachineClass detail = tbl_zMachineClass.Select(ID);
            if (detail != null)
                valueName = detail.ClassName;
            return valueName;
        }
        #endregion

        #region Machine Category
        public static string getName_MachineCategory(string ID)
        {
            string valueName = "";
            tbl_zMachineCategory detail = tbl_zMachineCategory.Select(ID);
            if (detail != null)
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region Machine Model
        public static string getName_Model(string ID)
        {
            string valueName = "";
            tbl_zModel detail = tbl_zModel.Select(ID);
            if (detail != null)
                valueName = detail.ModelName;
            return valueName;
        }
        #endregion

        #region Terminal
        public static string getName_Terminal(string ID)
        {
            string valueName = "";
            tbl_securityTerminalMaster detail = tbl_securityTerminalMaster.Select(ID);
            if (detail != null)
                valueName = detail.Terminal_Name;
            return valueName;
        }
        #endregion 
        #endregion

        #region Company Details
        #region Company
        public static string getName_Company(string ID)
        {
            string valueName = "";
            tbl_genCompanyInfo detail = tbl_genCompanyInfo.Select(ID);
            if (detail != null)
                valueName = detail.CompanyName;
            return valueName;
        }
        #endregion

        #region CompanyCountry
        public static string getName_CompanyCountry(string ID)
        {
            string valueName = "";
            tbl_genCompanyCountryMaster detail = tbl_genCompanyCountryMaster.Select(ID);
            if (detail != null)
                valueName = detail.CountryName;
            return valueName;
        }
        #endregion

        #region Company Divition
        public static string getName_DivisionMaster(string ID)
        {
            string valueName = "";
            tbl_genDivisionMaster detail = tbl_genDivisionMaster.Select(ID);
            if (detail != null)
                valueName = detail.DivisionName;
            return valueName;
        }
        #endregion

        #region Company Branch
        public static string getName_CompanyBranchMaster(string ID)
        {
            string valueName = "";
            tbl_genCompanyBranchMaster detail = tbl_genCompanyBranchMaster.Select(ID);
            if (detail != null)
                valueName = detail.BranchName;
            return valueName;
        }
        #endregion

        #region Company Division
        public static string getName_CompanyDivision(string ID)
        {
            string valueName = "";
            tbl_genDivisionMaster detail = tbl_genDivisionMaster.Select(ID);
            if (detail != null)
                valueName = detail.DivisionName;
            return valueName;
        }
        #endregion

        #region Company Department
        public static string getName_CompanyDepartment(string ID)
        {
            string valueName = "";
            tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(ID);
            if (detail != null)
                valueName = detail.DepartmentName;
            return valueName;
        }
        #endregion

        #region Company Bank
        public static string getName_CompanyBankNameByAccountNo(string sAccountNo)
        {
            string valueName = "";
            tbl_genCompanyAccount detail = tbl_genCompanyAccount.Select(sAccountNo);
            if (detail != null)
                valueName = clsGenaralName.getName_Bank(detail.Bank_ID);

            return valueName;
        }
        public static int getName_CompanyAccount_IDByAccountNo(string sAccountNo)
        {
            int value = -1;
            tbl_genCompanyAccount detail = tbl_genCompanyAccount.Select(sAccountNo);
            if (detail != null)
                value = detail.CompanyAccount_ID; ;

            return value;
        }
        public static int getName_CompanyAccount_IDByGLAccountNo(string sGLID)
        {
            int value = -1;
            tbl_accGLMaster_Bank oGl = tbl_accGLMaster_Bank.SelectAllByGl_ID(sGLID).FirstOrDefault();
            if (oGl != null)
            {
                tbl_genCompanyAccount detail = tbl_genCompanyAccount.Select(oGl.AccountNumber);
                if (detail != null)
                    value = detail.CompanyAccount_ID; ;
            }
          
            return value;
        }
        #endregion 
        #endregion

        #region
        public static string getName_ExpenditureCategory(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_pcbRefExpenditureCategory", "pcbExpenditureCategoryName", "pcbExpenditureCategory_ID", ID));
            return valueName;
        }
        #endregion
        //Petty Cash
        #region Font Type
        public static string getName_FontTypeName(string ID)
        {
            string valueName = "";
            tbl_zFont detail = tbl_zFont.Select(ID);
            if (detail != null)
                valueName = detail.FontType_Name;
            return valueName;
        }
        #endregion


        #region PettyCash Account
        public static string getName_PettyCashAccount(string ID)
        {
            string valueName = "";
            tbl_bpsPettyCashAccount detail = tbl_bpsPettyCashAccount.Select(ID);
            if (detail != null)
                valueName = detail.PettyCashAccountName;
            return valueName;
        }
        #endregion

        #region Expenditure Type
        public static string getName_ExpenditureType(string ID)
        {
            string valueName = "";
            tbl_zPettyCashExpenditureType detail = tbl_zPettyCashExpenditureType.Select(ID);
            if (detail != null)
                valueName = detail.PettyCashExpenditureTypeName;
            return valueName;
        }
        #endregion

        #region Income Type
        public static string getName_IncomeType(string ID)
        {
            string valueName = "";
            tbl_zPettyCashIncomeType detail = tbl_zPettyCashIncomeType.Select(ID);
            if (detail != null)
                valueName = detail.PettyCashIncomeTypeName;
            return valueName;
        }
        #endregion

        #region Petty Cash_Level_1
        public static string getName_PettyCash_Level_1(string ID)
        {
            string valueName = "";
            tbl_zPettyCash_Level_1 detail = tbl_zPettyCash_Level_1.Select(ID);
            if (detail != null)
                valueName = detail.PettyCash_Level_1Name;
            return valueName;
        }
        #endregion

        #region Petty Cash_Level_2
        public static string getName_PettyCash_Level_2(string ID)
        {
            string valueName = "";
            tbl_zPettyCash_Level_2 detail = tbl_zPettyCash_Level_2.Select(ID);
            if (detail != null)
                valueName = detail.PettyCash_Level_2Name;
            return valueName;
        }
        #endregion

        #region Petty Cash_Level_3
        public static string getName_PettyCash_Level_3(string ID)
        {
            string valueName = "";
            tbl_zPettyCash_Level_3 detail = tbl_zPettyCash_Level_3.Select(ID);
            if (detail != null)
                valueName = detail.PettyCash_Level_3Name;
            return valueName;
        }
        #endregion

        #region Petty Cash_Level_4
        public static string getName_PettyCash_Level_4(string ID)
        {
            string valueName = "";
            tbl_zPettyCash_Level_4 detail = tbl_zPettyCash_Level_4.Select(ID);
            if (detail != null)
                valueName = detail.PettyCash_Level_4Name;
            return valueName;
        }
        #endregion

        #region Cost Center
        public static string getName_CostCenter1(string ID)
        {
            string valueName = "";
            tbl_zCost_Center1 detail = tbl_zCost_Center1.Select(ID);
            if (detail != null && detail.Cost_Center1_ID.Trim() != "default")
                valueName = detail.Cost_Center1_Name;

            return valueName;
        }
        public static string getName_CostCenter2(string ID)
        {
            string valueName = "";
            tbl_zCost_Center2 detail = tbl_zCost_Center2.Select(ID);
            if (detail != null && detail.Cost_Center2_ID.Trim() != "default")
                valueName = detail.Cost_Center2_Name;

            return valueName;
        }

        public static string getName_CostCenter3(string ID)
        {
            string valueName = "";
            tbl_zCost_Center3 detail = tbl_zCost_Center3.Select(ID);
            if (detail != null && detail.Cost_Center3_ID.Trim() != "default")
                valueName = detail.Cost_Center3_Name;

            return valueName;
        }

        public static string getName_CostCenter4(string ID)
        {
            string valueName = "";
            tbl_zCost_Center4 detail = tbl_zCost_Center4.Select(ID);
            if (detail != null && detail.Cost_Center4_ID.Trim() != "default")
                valueName = detail.Cost_Center4_Name;
            else
                valueName = "default";//here put default

            return valueName;
        }
        #endregion



        #region Measurment Type
        public static string getName_ItemJobMeasurementTypeName(string ItemID)
        {
            string valueName = "";
            tbl_genItemMaster detail = tbl_genItemMaster.Select(ItemID);
            if (detail != null)
            {
                tbl_zJobMeasurementType uom = tbl_zJobMeasurementType.Select(detail.MeasureType_ID);
                if (uom != null)
                    valueName = uom.TypeName;
            }
            return valueName;
        }
        public static string getID_ItemJobMeasurementTypeID(string ItemID)
        {
            string valueName = "";
            tbl_genItemMaster detail = tbl_genItemMaster.Select(ItemID);
            if (detail != null)
                valueName = detail.MeasureType_ID;
            return valueName;
        }

        public static string getName_JobMeasurementTypeName(string MeasurementTypeID)
        {
            string valueName = "";
            tbl_zJobMeasurementType uom = tbl_zJobMeasurementType.Select(MeasurementTypeID);
            if (uom != null)
                valueName = uom.TypeName;
            return valueName;
        }
        #endregion

        #region Payment Method
        public static string getName_PaymentMethod(string ID)
        {
            string valueName = "";
            tbl_zPaymentMethod detail = tbl_zPaymentMethod.Select(ID);
            if (detail != null)
                valueName = detail.PaymentMethodName;
            return valueName;
        }
        #endregion


        //Security
        #region From Category
        public static string getName_FormCategory(string ID)
        {
            string valueName = "";
            tbl_securityFormCategory detail = tbl_securityFormCategory.Select(ID);
            if (detail != null)
                valueName = detail.CategoryName;
            return valueName;
        }
        #endregion

        #region Report Master
        public static string getName_ReportMaster(string ID)
        {
            string valueName = "";
            tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ID);
            if (detail != null)
                valueName = detail.ReportName;
            return valueName;
        }
        #endregion

        #region Report Category
        public static string getName_ReportCategory(string ID)
        {
            string valueName = "";
            tbl_zReportCategory detail = tbl_zReportCategory.Select(ID);
            if (detail != null)
                valueName = detail.ReportCategoryName;
            return valueName;
        }
        #endregion

        #region Value ID
        public static string getName_SecurityValue(int ID)
        {
            string valueName = "";
            tbl_securityConfigValue detail = tbl_securityConfigValue.Select(ID);
            if (detail != null)
                valueName = detail.ValueName;
            return valueName;
        }
        #endregion

        #region Type Value ID
        public static string getName_SecurityConfigType_Value(string ID)
        {
            string valueName = "";
            tbl_securityConfigType_Value detail = tbl_securityConfigType_Value.Select(ID);
            if (detail != null)
                valueName = detail.ConfigTypeValue;
            return valueName;
        }
        #endregion

        #region Status Value ID
        public static string getName_SecurityConfigType_Status(string ID)
        {
            string valueName = "";
            tbl_securityConfigType_Status detail = tbl_securityConfigType_Status.Select(ID);
            if (detail != null)
                valueName = detail.ConfigTypeStatus;
            return valueName;
        }
        #endregion

        #region Process Note
        public static string getName_ProcessNote(int ID)
        {
            string valueName = "";
            tbl_securityProcessNoteMaster detail = tbl_securityProcessNoteMaster.Select(ID);
            if (detail != null)
                valueName = detail.ProcessNoteName;
            return valueName;
        }
        #endregion

        #region Process Note
        public static string getName_ProcessNoteCategory(int ID)
        {
            string valueName = "";
            tbl_securityProcessNoteCatogory detail = tbl_securityProcessNoteCatogory.Select(ID);
            if (detail != null)
                valueName = detail.ProcessNoteCategoryName;
            return valueName;
        }
        #endregion

        #region GetStatusName
        public static String GetStatusName(int statusID)
        {
            String sStatusName = "";
            tbl_zStatus status = tbl_zStatus.Select(statusID);
            if (status != null)
                sStatusName = status.StatusName;
            return sStatusName;
        }
        #endregion

        #region GetPostingStatusName
        public static String GetPostingStatusName(string statusID)
        {
            string sStatusName = "";
            tbl_zAccPostingStatus status = tbl_zAccPostingStatus.Select(statusID);
            if (status != null)
                sStatusName = status.PostingStatusName;
            return sStatusName;
        }
        #endregion

        #region Get Alert Name
        public static string getName_Alert(string alertID)
        {
            string valueName = "";
            tbl_utlAlert detail = tbl_utlAlert.Select(alertID);
            if (detail != null)
                valueName = detail.AlertName;
            return valueName;
        }
        #endregion


        //Accounts

        #region Main Category
        public static string getName_GLMainCatagory(string ID)
        {
            string valueName = "";
            tbl_zAccGLMaster_MainCatagory detail = tbl_zAccGLMaster_MainCatagory.Select(ID);
            if (detail != null)
                valueName = detail.GlMainCatagoryName;
            return valueName;
        }
        public static string getID_GLMainCatagoryBySubGLID(string ID)
        {
            string valueName = "";
            tbl_zAccGLMaster_SubCatagory detail = tbl_zAccGLMaster_SubCatagory.Select(ID);
            if (detail != null)
                valueName = detail.GlMainCatagory_ID;
            return valueName;
        }
        #endregion

        #region Sub Category
        public static string getName_GLSubCatagory(string ID)
        {
            string valueName = "";
            tbl_zAccGLMaster_SubCatagory detail = tbl_zAccGLMaster_SubCatagory.Select(ID);
            if (detail != null)
                valueName = detail.GlSubCatagoryName;
            return valueName;
        }
        public static string getName_GLSubCatagoryByAccountTypeID(string ID)
        {
            string valueName = "";
            tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select(ID);
            if (detail != null)
                valueName = detail.GlSubCatagory_ID;
            return valueName;
        }
        public static string getID_GLSubCatagoryByGLID(string ID)
        {
            string valueName = "";
            tbl_accGLMaster detail = tbl_accGLMaster.Select(ID);
            if (detail != null)
            {
                tbl_zAccGLMaster_AccountType oType = tbl_zAccGLMaster_AccountType.Select(detail.GlAccountType_ID);
                if (oType != null)
                    valueName = oType.GlSubCatagory_ID;
            }
            return valueName;
        }
        #endregion

        #region Account Type 1
        public static string getName_GlAccountType1(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zAccGLMaster_AccountType", "glAccountTypeName", "glAccountType_ID", ID));
            return valueName;
        }
        public static string getID_GlAccountType2ByParentID(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zAccGLMaster_AccountType", "glAccountType_ID", "parent_ID", ID));
            return valueName;
        }
        public static string getID_GlAccountType2ParentID(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zAccGLMaster_AccountType", "parent_ID", "glAccountType_ID", ID));
            return valueName;
        }
        #endregion

        #region Account Type - Customer
        //public static string getName_AccountType_Customer(string ID)
        //{
        //    string valueName = "";
        //    tbl_accAccountsType_Customer detail = tbl_accAccountsType_Customer.Select(ID);
        //    if (detail != null)
        //        valueName = detail.CustomerAccountTypeName;
        //    return valueName;
        //}
        //public static string getName_getGLCode_AccountType(string ID)
        //{
        //    string valueName = "";
        //    tbl_accAccountsType_Customer detail = tbl_accAccountsType_Customer.Select(ID);
        //    if (detail != null)
        //        valueName = detail.Gl_ID;
        //    return valueName;
        //}
        #endregion

        #region Account Type - Supplier
        //public static string getName_AccountType_Supplier(string ID)
        //{
        //    string valueName = "";
        //    tbl_accAccountsType_Supplier detail = tbl_accAccountsType_Supplier.Select(ID);
        //    if (detail != null)
        //        valueName = detail.SupplierAccountTypeName;
        //    return valueName;
        //}
        //public static string getName_getGLCode_AccountType_Supplier(string ID)
        //{
        //    string valueName = "";
        //    tbl_accAccountsType_Supplier detail = tbl_accAccountsType_Supplier.Select(ID);
        //    if (detail != null)
        //        valueName = detail.Gl_ID;
        //    return valueName;
        //}
        #endregion

        #region Account Code
        public static string getName_AccountName(string ID)
        {
            string valueName = "";
            tbl_accGLMaster detail = tbl_accGLMaster.Select(ID);
            if (detail != null)
                valueName = detail.GlName;
            return valueName;
        }
        #endregion

        #region Control Acc Type
        public static string getName_controlAccountTypeByGLID(string ID)
        {
            string valueName = "";
            tbl_accGLMaster detail = tbl_accGLMaster.Select(ID);
            if (detail != null)
                valueName = detail.ControlAcc_Type;

            return valueName;
        } 
        #endregion

        #region APN Type
        public static string getName_APNType(string ID)
        {
            string valueName = "";
            tbl_zAccAccountPaybleNoteType detail = tbl_zAccAccountPaybleNoteType.Select(ID);
            if (detail != null)
                valueName = detail.ApnTypeName;
            return valueName;
        }
        #endregion



        #region Double Entry Slot Name
        public static string getName_AcctSlotName(int ID)
        {
            string valueName = "";
            tbl_accDoubleEntrySlotMaster detail = tbl_accDoubleEntrySlotMaster.Select(ID);
            if (detail != null)
                valueName = detail.SlotName;
            return valueName;
        }
        #endregion

        #region GL Note
        public static string getName_GLNoteID(int ID)
        {
            string valueName = "";
            tbl_accGLMaster_Note detail = tbl_accGLMaster_Note.Select(ID);
            // if (detail != null)
            //    valueName = detail.GlNoteName;
            return valueName;
        }
        #endregion

        #region Account CostCenter 1
        public static string getName_AccCostCenter1(string ID)
        {
            string valueName = "-";
            tbl_zAccCostCenter1 detail = tbl_zAccCostCenter1.Select(ID);
            if (detail != null)
                valueName = detail.CostCenter1Name;
            return valueName;
        }
        #endregion

        #region Account CostCenter 2
        public static string getName_AccCostCenter2(string ID)
        {
            string valueName = "-";
            tbl_zAccCostCenter2 detail = tbl_zAccCostCenter2.Select(ID);
            if (detail != null)
                valueName = detail.CostCenter2Name;
            return valueName;
        }
        #endregion

        #region financial year
        public static string getName_FinancialYearName(string ID)
        {
            string valueName = "";
            tbl_accFinancialYearMaster detail = tbl_accFinancialYearMaster.Select(ID);
            if (detail != null)
                valueName = detail.FinancialYearName;
            return valueName;
        }
        #endregion


        #region Report Item Level1
        public static string getName_ReportItemLevel1(string ID)
        {
            string valueName = "";
            tbl_rbReportItem_Level_1 detail = tbl_rbReportItem_Level_1.Select(ID);
            if (detail != null)
                valueName = detail.ReportItem_level1Name;
            return valueName;
        }
        #endregion




        #region Report Item Level2
        public static string getName_ReportItemLevel2(string ID)
        {
            string valueName = "";
            tbl_rbReportItem_Level_2 detail = tbl_rbReportItem_Level_2.Select(ID);
            if (detail != null)
                valueName = detail.ReportItem_level2Name;
            return valueName;
        }
        #endregion



        #region Report Item
        public static string getName_ReportItem(string ID)
        {
            string valueName = "";
            tbl_rbReportItem detail = tbl_rbReportItem.Select(ID);
            if (detail != null)
                valueName = detail.ReportItemName;
            return valueName;
        }
        #endregion



        #region Report Master Name
        public static string getName_rbReportMaster(string ID)
        {
            string valueName = "";
            tbl_rbReportMaster detail = tbl_rbReportMaster.Select(ID);
            if (detail != null)
                valueName = detail.ReportName;
            return valueName;
        }
        #endregion

        #region Report Ins Master Name
        public static string getName_rbInsReportMaster(string ID)
        {
            string valueName = "";
            tbl_rbInsReportMaster detail = tbl_rbInsReportMaster.Select(ID);
            if (detail != null)
                valueName = detail.ReportName;
            return valueName;
        }
        #endregion

        //Bills

        #region CreditNote Type
        public static string getName_CreditNoteType(string ID)
        {
            string valueName = "";
            tbl_zCreditNoteType detail = tbl_zCreditNoteType.Select(ID);
            if (detail != null)
                valueName = detail.CreditNoteTypeName;
            return valueName;
        }
        #endregion

        #region DebitNote Type
        public static string getName_DebitNoteType(string ID)
        {
            string valueName = "";
            tbl_zDebitNoteType detail = tbl_zDebitNoteType.Select(ID);
            if (detail != null)
                valueName = detail.DebitNoteTypeName;
            return valueName;
        }


        public static string getName_DebitNoteTypeOfDebitNote(string DebitNoteID)
        {
            string valueName = "";
            tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(DebitNoteID);
            if (detail != null)
            {
                valueName = getName_DebitNoteType(detail.DebitNoteType_ID);
            }
            return valueName;
        }
        #endregion
        //Supplier

        #region Supplier Address Register
        public static string getSupplierAddressRegister(string ID)
        {
            string valueName = "";
            tbl_genSupplierMaster detail = tbl_genSupplierMaster.Select(ID);
            if (detail != null)
                valueName = detail.AddressRegister;
            return valueName;
        }
        #endregion

        #region Shift
        public static string getName_Shift(string ID)
        {
            string valueName = "";
            tbl_genShiftMaster detail = tbl_genShiftMaster.Select(ID);
            if (detail != null)
                valueName = detail.ShiftName;
            return valueName;
        }
        #endregion

        #region Cheque Format
        public static string getChequeFormat_Code(int chequeFormat_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_zChequeFormat", "chequeFormat_Code", "chequeFormat_ID", chequeFormat_ID));
            return valueName;
        } 
        #endregion

        public static string getName_ConfigForm(string ID)
        {
            string valueName = "";
            tbl_securityConfigForms detail = tbl_securityConfigForms.Select(ID);
            if (detail != null)
                valueName = detail.ConfigName;
            return valueName;
        }

        #region R2 Production

        #region Apparel
        public static string getID_ApparelBoM_UoM(string sBoM_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxJobCard", "uom_ID", "prodJob_ID", sBoM_ID));
            return valueName;
        }
        public static string getID_ApparelBoM_FinishedGood(string sBoM_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxJobCard", "item_ID_FG", "prodJob_ID", sBoM_ID));
            return valueName;
        }
        //public static string getDescription_ApparelBoM_Item(string sBoM_ID)
        //{
        //    string valueName = "-";
        //    tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(sBoM_ID);
        //    if (oJob != null)
        //    {
        //        valueName = getDescription_Item(oJob.Item_ID_FG);
        //    }
        //    return valueName == "default" ? " - " : valueName;
        //}
        public static string getID_ApparelBoM_Customer(string sBoMID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxJobCard", "customer_ID", "prodJob_ID", sBoMID));
            return valueName;
        }

        #region Prod Apparel Section Activity
        public static string getName_ApparelSectionActivity(string ActivityID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodMasSectionActivity", "description", "activity_ID", ActivityID));
            return valueName;
        }
        #endregion
        #endregion

        #region Pharma
        public static string getID_PharmaBoM_UoM(string sBoM_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxJobCard", "uom_ID", "prodJob_ID", sBoM_ID));
            return valueName;
        }
        public static string getID_PharmaBoM_FinishedGood(string sBoM_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxJobCard", "item_ID_FG", "prodJob_ID", sBoM_ID));
            return valueName;
        }
        //public static string getDescription_PharmaBoM_Item(string sBoM_ID)
        //{
        //    string valueName = "-";
        //    tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(sBoM_ID);
        //    if (oJob != null)
        //    {
        //        valueName = getDescription_Item(oJob.Item_ID_FG);
        //    }
        //    return valueName == "default" ? " - " : valueName;
        //}
        public static string getID_PharmaBoM_Customer(string sBoMID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxJobCard", "customer_ID", "prodJob_ID", sBoMID));
            return valueName;
        }
        #region Prod Apparel Section Activity
        public static string getName_PharmaSectionActivity(string ActivityID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaMasSectionActivity", "description", "activity_ID", ActivityID));
            return valueName;
        }
        #endregion
        #endregion 

        #endregion


        #region PCB
        public static string getName_PCAccount(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_pcbMasAccount", "pcbAccountName", "pcbAccount_ID", ID));
            return valueName;
        }

        public static string getName_ExpCategory(string ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_pcbRefExpenditureCategory", "pcbExpenditureCategoryName", "pcbExpenditureCategory_ID", ID));
            return valueName;
        }
        #endregion

    }
}