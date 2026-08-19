using System;
using System.Collections.Generic;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using SEACC.WinFormControls.Forms;
//using SEACC_WPFControls;

namespace Digiteq
{
    public class clsSearch
    {
        #region Old Methods
        #region Brand
        public static void passValue_Brand()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zBrand ";
            frmSearchMaster.s_Columns = " brand_ID [Brand Code], brandName [Brand Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "brand_ID != 'default'";
        }
        #endregion

        #region Item Category
        public static void passValue_ItemCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemCategory ";
            frmSearchMaster.s_Columns = " itemCategory_ID [Cat. Code], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "itemCategory_ID != 'default'";
        }

        #endregion

        #region Item Class
        public static void passValue_ItemClass()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemClass ";
            frmSearchMaster.s_Columns = " itemClass_ID [Class Code], ClassName [Class Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "itemClass_ID != 'default'";

        }
        #endregion

        #region Item
        public static void passValue_ItemMaster()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genItemMaster ";
            frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1";
        }
        public static void passValue_ItemMasterByTypeID(string sTypeID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genItemMaster ";
            frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 and itemType_ID = '" + sTypeID + "'";
        }

        #endregion



        #region Item Sub Category ByCategoryID
        public static void passValue_ItemSubCategoryByCategoryID(string sItemCategory_ID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemCategory_Sub";
            frmSearchMaster.s_Columns = " itemCategorySub_ID [ItemSubCategory Code], categorySubName [CategorySub Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "itemCategorySub_ID != 'default' and itemCategory_ID = '" + sItemCategory_ID + "' ";
        }
        #endregion



        #region Item Specification
        public static void passValue_ItemSpecification()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zItemSpecification";
            frmSearchMaster.s_Columns = " itemSepcification_ID [ItemSepcification Code] ,sepcificationName [Sepcification Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 175, 175 };
            frmSearchMaster.s_Criteria = "itemSepcification_ID != 'default' ";
        }
        #endregion

        #region Item Sub Category
        public static void passValue_ItemCategorySub()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemCategory_Sub ";
            frmSearchMaster.s_Columns = " itemCategorySub_ID [Sub Code], categorySubName [SubCategory Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "itemCategorySub_ID != 'default'";
        }

        public static void passValue_ItemCategorySubByCategoryID(string sID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemCategory_Sub ";
            frmSearchMaster.s_Columns = " itemCategorySub_ID [Sub Code], categorySubName [SubCategory Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "itemCategorySub_ID != 'default' AND itemCategory_ID='" + sID + "'";
        }
        #endregion

        #region Config Form
        public static void passValue_ConfigForm()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_securityConfigForms ";
            frmSearchTransaction.s_Columns = " configForm_ID [Form Code], configName [Form Name], prefix1 Prefix1, counter Counter";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 160, 100, 100 };
            frmSearchTransaction.s_Criteria = "configForm_ID != 'default'";
        }
        #endregion

        #region Tag
        public static void passValue_Tag1()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemTag1 ";
            frmSearchMaster.s_Columns = " tag1_ID [Tag Code], description [Description]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tag1_ID != 'default'";
        }
        public static void passValue_Tag2()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zItemTag2 ";
            frmSearchMaster.s_Columns = " tag2_ID [Tag Code], description [Description]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tag2_ID != 'default'";
        }
        #endregion

        #region Uom
        public static void passValue_UomForSales()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zUom ";
            frmSearchMaster.s_Columns = " uom_ID [Uom Code], uomCode [Uom Code], UomName [Uom Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150 };
            frmSearchMaster.s_Criteria = "uom_ID != 'default' and isVisible = 'true' and isForSales = 'true'";
        }
        public static void passValue_UomForPacking()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zUom ";
            frmSearchMaster.s_Columns = " uom_ID [Uom ID], uomCode [Uom Code], UomName [Uom Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150 };
            frmSearchMaster.s_Criteria = "uom_ID != 'default' and isVisible = 'true' and isForPacking = 'true'";
        }
        #endregion

        #region Uom Category
        public static void passValue_UomCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zUomCategory ";
            frmSearchMaster.s_Columns = " uomCategory_ID [Uom Code], categoryName [Category Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "uomCategory_ID != 'default'";
        }
        #endregion

        #region Country
        public static void passValue_CountryID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCountry ";
            frmSearchMaster.s_Columns = " country_ID [Country Code], countryName [Country Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "country_ID != 'default'";
        }
        #endregion

        #region District
        public static void passValue_District()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zDistrict ";
            frmSearchMaster.s_Columns = " district_ID [District Code], districtName [District Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "district_ID != 'default'";
        }
        public static void passValue_DistrictByProvinceID(string sProvinceID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zDistrict ";
            frmSearchMaster.s_Columns = " district_ID [District Code], districtName [District Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "district_ID != 'default' AND province_ID = '" + sProvinceID + "'";
        }
        #endregion

        #region Province
        public static void passValue_Province()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zProvince ";
            frmSearchMaster.s_Columns = " province_ID [Province Code], provinceName [Province Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "province_ID != 'default'";
        }
        public static void passValue_ProvinceByCountryID(string sCountryID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zProvince ";
            frmSearchMaster.s_Columns = " province_ID [Province Code], provinceName [Province Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "province_ID != 'default' AND country_ID = '" + sCountryID + "'";
        }
        #endregion

        #region City
        public static void passValue_City()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCity ";
            frmSearchMaster.s_Columns = " city_ID [City Code], cityName [City Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "city_ID != 'default'";
        }
        public static void passValue_CityByDistrictID(string sDistrictID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCity ";
            frmSearchMaster.s_Columns = " city_ID [City Code], cityName [City Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "city_ID != 'default' AND district_ID = '" + sDistrictID + "'";
        }
        #endregion

        #region Town
        public static void passValue_Town()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zTown ";
            frmSearchMaster.s_Columns = " town_ID [Town Code], townName [Town Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "town_ID != 'default'";
        }
        #endregion

        #region Area
        public static void passValue_Area()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zArea ";
            frmSearchMaster.s_Columns = " area_ID [Area Code], areaName [Area Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "area_ID != 'default'";
        }
        #endregion


        #region Supplier
        public static void passValue_SupplierMaster()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genSupplierMaster ";
            frmSearchMaster.s_Columns = " supplier_ID [Supplier Code], supplierName [Supplier Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "supplier_ID != 'default'";
        }

        public static void passValue_Supplier_ByCompanyBranchID(string companyBranchId)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_genSupplierMaster ";
            frmSearchTransaction.s_Columns = " supplier_ID [Supplier Code], supplierName [Supplier Name], telephone Telephone, businessRegistraionNo [Registraion No]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
            frmSearchTransaction.s_Criteria = "supplier_ID != 'default' AND isOtherCreditor = 0 AND companyBranch_ID = '" + companyBranchId + "'";
        }
        #endregion

        #region SupplierCategory
        public static void passValue_SupplierCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zSupplierCategory ";
            frmSearchMaster.s_Columns = " supplierCategory_ID [Category Code], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "supplierCategory_ID != 'default'";
        }
        #endregion

        #region SupplierClass
        public static void passValue_SupplierClass()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zSupplierClass ";
            frmSearchMaster.s_Columns = " supplierClass_ID [Class Code], ClassName [Class Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "supplierClass_ID != 'default'";
        }
        #endregion

        #region SupplierType
        public static void passValue_SupplierType()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zSupplierType ";
            frmSearchMaster.s_Columns = " supplierType_ID [Type Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "supplierType_ID != 'default'";
        }
        #endregion

        #region Bank
        public static void passValue_Bank()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zBank ";
            frmSearchMaster.s_Columns = " bank_ID [Bank Code], bankName [Bank Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "bank_ID != 'default'";
        }
        public static void passValue_BankCompany()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genCompanyAccount, tbl_zBank ";
            frmSearchMaster.s_Columns = " tbl_genCompanyAccount.bank_ID [Bank Code], bankName [Bank Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.bank_ID != 'default' and tbl_genCompanyAccount.bank_ID = tbl_zBank.bank_ID ";
        }

        #endregion

        #region BankBranches

        public static void passValue_BankBranchesByBankID(string sBankID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zBankBranches ";
            frmSearchMaster.s_Columns = " branch_ID [Branch Code], branchName [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "branch_ID != 'default' AND bank_ID = '" + sBankID + "'";
        }
        public static void passValue_CompanyBankBranches()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genCompanyAccount, tbl_zBankBranches ";
            frmSearchMaster.s_Columns = " tbl_genCompanyAccount.branch_ID [Branch Code], tbl_zBankBranches.branchName [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.branch_ID != 'default' AND tbl_genCompanyAccount.branch_ID = tbl_zBankBranches.branch_ID ";
        }
        public static void passValue_CompanyBankBranchesByBankID(string sBankID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genCompanyAccount, tbl_zBankBranches ";
            frmSearchMaster.s_Columns = " tbl_genCompanyAccount.branch_ID [Branch Code], tbl_zBankBranches.branchName [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.branch_ID != 'default' AND tbl_genCompanyAccount.branch_ID = tbl_zBankBranches.branch_ID AND tbl_genCompanyAccount.bank_ID = '" + sBankID + "'";
        }
        #endregion

        #region Customer
        public static void passValue_CustomerMaster()
        {
            passValue_CustomerMaster(false);
        }
        public static void passValue_CustomerMaster(bool showDeleted)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genCustomerMaster ";
            frmSearchMaster.s_Columns = " customer_ID [Cus Code], customerName [Customer Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "customer_ID != 'default' AND companyBranch_ID ='" + clsSecurity.BranchID + "' ";
            if (!showDeleted)
                frmSearchMaster.s_Criteria += " AND isDeleted = 'false'";
        }



        #endregion

        #region CustomerCategory
        public static void passValue_CustomerCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCustomerCategory ";
            frmSearchMaster.s_Columns = " customerCategory_ID [Category Code], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "customerCategory_ID != 'default'";
        }
        #endregion

        #region CustomerClass
        public static void passValue_CustomerClass()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCustomerClass ";
            frmSearchMaster.s_Columns = " customerClass_ID [Class Code], ClassName [Class Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "customerClass_ID != 'default'";
        }
        #endregion

        #region CustomerType
        public static void passValue_CustomerType()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zCustomerType ";
            frmSearchMaster.s_Columns = " customerType_ID [Type Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "customerType_ID != 'default'";
        }
        #endregion

        #region Inquiry


        #endregion

        #region Quotation

        public static void passValue_QuotationByCustomerID(string sCustomerID)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_sasQuotation, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " quotation_ID [Quotation Code], customerName CustomerName, grandTotal GrandTotal, quotationDate [Quotation Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.s_Criteria = "quotation_ID != 'default' AND tbl_sasQuotation.isDeleted = 'false' AND tbl_sasQuotation.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_sasQuotation.customer_ID = '" + sCustomerID + "'";
        }
        #endregion

        #region ProformaInvoice


        #endregion

        #region From Category
        public static void passValue_FromCategory()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_securityFormCategory ";
            frmSearchTransaction.s_Columns = " formCategory_ID [Category Code], categoryName CategoryName, displayName DisplayName, isEnable Activated";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 140, 140, 80 };
        }

        public static void passValue_FromCategoryMaster()
        {
            frmSearchMaster.s_TableName = " tbl_securityFormCategory ";
            frmSearchMaster.s_Columns = " formCategory_ID [Category Code], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        }
        #endregion

        #region From Form Master

        public static void passValue_FromMaster()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_zFormMaster";
            frmSearchTransaction.s_Columns = " form_ID [Form ID], formName [Form Name], displayName [Display Name], formCategory_ID [Category Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 120, 120, 120 };
            frmSearchTransaction.s_Criteria = "";
        }
        #endregion

        #region User
        public static void passValue_User(bool bExceptDigiteq)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityUserMaster ";
            frmSearchMaster.s_Columns = " user_ID [User ID], userName [User Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            string sCondition = "user_ID != 'default' and isBlocked = 0";
            if (bExceptDigiteq)
                sCondition += "and user_ID != 'digiteq'";
            frmSearchMaster.s_Criteria = sCondition;
        }
        #endregion

        #region Driver
        public static void passValue_Driver()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zDriver ";
            frmSearchMaster.s_Columns = " driver_ID [Driver Code], driverName [Driver Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "driver_ID != 'default'";
        }
        #endregion

        #region Assistant
        public static void passValue_Assistant()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zAssistant ";
            frmSearchMaster.s_Columns = " assistant_ID [Assistant Code], assistantName [Assistant Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "assistant_ID != 'default'";
        }
        #endregion

        #region Vehicle
        public static void passValue_Vehicle()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zVehicle ";
            frmSearchMaster.s_Columns = " vehicle_ID [Assistant Code], vehicleNumber [Vehicle Number], vehicleName, [Vehicle Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150 };
            frmSearchMaster.s_Criteria = "vehicle_ID != 'default'";
        }
        #endregion

        #region Invoice

        public static void passValue_InvoiceByCustomerID(string sCustomerID)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_sasInvoice, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " invoice_ID [Invoice Code], customerName [Customer Name], invoiceDate [Invoice Date], grandTotal [Invoice Total]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 100, 80 };
            frmSearchTransaction.s_Criteria = "invoice_ID != 'default' AND tbl_sasInvoice.isDeleted = 'false' AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_sasInvoice.customer_ID = '" + sCustomerID + "'";
        }
        #endregion

        #region ChequeRegister
        public static void passValue_ChequeRegister()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_bpsChequeRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Register Code], customerName [Customer Name], chequeNumber [Cheque Number], dateCheque [Cheque Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.s_Criteria = "  chequeRegister_ID != 'default' AND tbl_bpsChequeRegister.isDeleted = 'false' AND tbl_bpsChequeRegister.customer_ID = tbl_genCustomerMaster.customer_ID";
        }

        public static void passValue_ChequeRegisterOutward()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_accChequeRegister ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Register Code], payee [Supplier Name], chequeNumber [Cheque Number], dateCheque [Cheque Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.s_Criteria = "  chequeRegister_ID != 'default' AND tbl_accChequeRegister.isDeleted = 'false' ";
        }
        #endregion

        #region CustomerAccount
        public static void passValue_CustomerAccount()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_genCustomerAccount, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " accountNumber [Account Number], customerName [Customer Name], balanceAmount [Balance Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 140, 200, 120 };
            frmSearchTransaction.s_Criteria = "accountNumber != 'default' AND tbl_genCustomerAccount.customer_ID = tbl_genCustomerMaster.customer_ID";
        }
        public static void passValue_CustomerAccountByCustomerID(string sCustomerID)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_genCustomerAccount, tbl_genCustomerMaster, tbl_zBank";
            frmSearchTransaction.s_Columns = "tbl_genCustomerAccount.accountNumber [Account No], customerName [Customer Name], bankName [Bank Name],  returnedCount Returned";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 210, 80, 70 };
            frmSearchTransaction.s_Criteria = "accountNumber != 'default' AND tbl_genCustomerAccount.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_genCustomerAccount.customer_ID = '" + sCustomerID + "' and tbl_zBank.bank_ID = tbl_genCustomerAccount.bank_ID";
        }
        #endregion

        #region Company Account

        public static void SearchMaser_CompanyAccount(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genCompanyAccount, tbl_zBank, tbl_zBankBranches ";
            frmSearchMaster.s_Columns = "tbl_genCompanyAccount.accountNumber [Acc Number], tbl_zBank.bankName [Bank Name], tbl_zBankBranches.branchName [Branch Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250, 150 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.accountNumber != 'default' AND tbl_genCompanyAccount.bank_ID!='default' AND tbl_genCompanyAccount.bank_ID = tbl_zBank.bank_ID AND tbl_genCompanyAccount.branch_ID = tbl_zBankBranches.branch_ID";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }



        public static void passValue_CompanyAccount()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_genCompanyAccount, tbl_zBank, tbl_zBankBranches ";
            frmSearchTransaction.s_Columns = " accountNumber [Account Number], tbl_zBank.bankName [Bank Name], tbl_zBankBranches.branchName [Branch Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 140, 200, 120 };
            frmSearchTransaction.s_Criteria = "accountNumber != 'default' AND tbl_genCompanyAccount.bank_ID = tbl_zBank.bank_ID AND tbl_genCompanyAccount.branch_ID = tbl_zBankBranches.branch_ID";
        }



        public static void SearchMaster_CompanyBank(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "  tbl_genCompanyAccount, tbl_zBank  ";
            frmSearchMaster.s_Columns = "  tbl_genCompanyAccount.bank_ID [Bank Code], bankName [Bank Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.bank_ID != 'default' and tbl_genCompanyAccount.bank_ID = tbl_zBank.bank_ID ";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        #endregion

        #region ChequeRegister

        public static void passValue_ChequeDeposit(string companyID, string companyBranchID)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_bpsChequeDeposit, tbl_zBank ";
            frmSearchTransaction.s_Columns = " chequeDeposit_ID [Deposit Code], bankName [Bank Name], accountNumber [Account Number], dateDeposit [Deposit Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.s_Criteria = "chequeDeposit_ID != 'default' AND tbl_bpsChequeDeposit.isDeleted = 'false' AND tbl_bpsChequeDeposit.bank_ID = tbl_zBank.bank_ID AND tbl_bpsChequeDeposit.companyID = '" + companyID + "' AND tbl_bpsChequeDeposit.companyBranch_ID = '" + companyBranchID + "' ";
        }

        #endregion

        #region ChequeReIssue

        public static void passValue_ChequeReIssue(string companyID, string companyBranchID)
        {
            frmSearchTransaction.s_TableName = " tbl_bpsChequeReIssue, tbl_genSupplierMaster ";
            frmSearchTransaction.s_Columns = " reIssue_ID [ReIssue Code], supplierName [Supplier Name], receiverName [Receiver Name], dateReIssued [ReIssued Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 130, 100 };
            frmSearchTransaction.s_Criteria = "reIssue_ID != 'default' AND tbl_bpsChequeReIssue.isDeleted = 'false' AND tbl_bpsChequeReIssue.supplier_ID = tbl_genSupplierMaster.supplier_ID AND tbl_bpsChequeReIssue.companyID = '" + companyID + "' AND tbl_bpsChequeReIssue.companyBranch_ID = '" + companyBranchID + "'";
        }
        #endregion

        #region ChequeReconciliation

        public static void passValue_ChequeInwardReconciliation(string companyID, string companyBranchID)
        {
            frmSearchTransaction.s_TableName = " tbl_bpsChequeReconciliation ";
            frmSearchTransaction.s_Columns = " reconciliation_ID [Reconciliation Code], totalCheque [Total Cheque], totalAmount [Total Amount], dateReconciliation [Reconciliation Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 130, 100, 130 };
            frmSearchTransaction.s_Criteria = "reconciliation_ID != 'default' AND tbl_bpsChequeReconciliation.companyID = '" + companyID + "' AND tbl_bpsChequeReconciliation.companyBranch_ID = '" + companyBranchID + "'  ";
        }


        public static void passValue_ChequeOutwardReconciliation(string companyID, string companyBranchID)
        {
            frmSearchTransaction.s_TableName = " tbl_accChequeReconciliation ";
            frmSearchTransaction.s_Columns = " reconciliation_ID [Reconciliation Code], totalCheque [Total Cheque], totalAmount [Total Amount], dateReconciliation [Reconciliation Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 130, 100, 130 };
            frmSearchTransaction.s_Criteria = "reconciliation_ID != 'default' AND tbl_accChequeReconciliation.companyID = '" + companyID + "' AND tbl_accChequeReconciliation.companyBranch_ID = '" + companyBranchID + "'  ";
        }
        #endregion

        #region Employee
        public static void passValue_Employee()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_genEmployeeMaster ";
            frmSearchMaster.s_Columns = " employee_ID [Employee Code], employeeName [Employee Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "employee_ID != 'default'";
        }
        #endregion

        #region Group
        public static void passValue_Group()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_securityGroup";
            frmSearchMaster.s_Columns = " group_ID [Group Code], groupName [Group Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "group_ID != 'default'";
        }
        #endregion

        #region SalesManager
        public static void passValue_SalesManager()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_ZEmpSalesManager ";
            frmSearchMaster.s_Columns = " salesManager_ID [Manager ID], salesManagerName [SalesManager Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "salesManager_ID != 'default'";
        }
        #endregion

        #region SalesExecutive
        public static void passValue_SalesExecutive()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_ZEmpSalesExecutive ";
            frmSearchMaster.s_Columns = " salesExecutive_ID [SalesExecutive Code] , salesExecutiveName [SalesExecutive Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "salesExecutive_ID != 'default' ";
        }
        #endregion

        #region Area Manager
        public static void passValue_AreaManager()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_ZEmpAreaManager ";
            frmSearchMaster.s_Columns = " areaManager_ID [Manager Code], areaManagerName [AreaManager Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "areaManager_ID != 'default'";
        }
        #endregion

        #region Store Good Recive Note

        public static void Search_TransactionStoreReqositionNote_Use(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsStoreReqositionNote, tbl_genStoreMaster,tbl_scsStoreReqositionNote_Detail ";
            frmSearchTransaction.s_Columns = "tbl_scsStoreReqositionNote.StoreRecositionNote_ID [SRN Code], tbl_scsStoreReqositionNote_Detail.job_ID [Job Code] , storeName  [Store Name], StoreRecositionNoteDate [SRN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };

            string sCondition = "tbl_scsStoreReqositionNote.StoreRecositionNote_ID != 'default' and tbl_scsStoreReqositionNote.fromStore_ID = tbl_genStoreMaster.store_ID AND tbl_scsStoreReqositionNote.storeRecositionNote_ID=tbl_scsStoreReqositionNote_Detail.storeRecositionNote_ID ";
            if (true)
                sCondition += " AND tbl_scsStoreReqositionNote.isSeattled = 'false' AND tbl_scsStoreReqositionNote.isDeleted = 'false' ";
            if (true)
                sCondition += " AND tbl_scsStoreReqositionNote.isFinished = 'false' ";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsStoreReqositionNote.StoreRecositionNote_ID , storeName  , tbl_scsStoreReqositionNote_Detail.job_ID  , StoreRecositionNoteDate ORDER BY StoreRecositionNoteDate DESC  ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Department GoodStoreReqositionNote
        public static void passValue_DepartmentStoreReqositionNoteAll()
        {
            //passing values
            frmSearchTransaction.s_TableName = "tbl_scsDepartmentReqositionNote, tbl_genDepartmentMaster, tbl_securityUserMaster";
            frmSearchTransaction.s_Columns = "  departmentReqositionNote_ID [SRN Code], departmentName  [Department Name], tbl_securityUserMaster.userName [User Name] , departmentReqositionNoteDate [SRN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.s_Criteria = "departmentReqositionNote_ID != 'default' and tbl_scsDepartmentReqositionNote.fromDepartment_ID = tbl_genDepartmentMaster.department_ID AND tbl_scsDepartmentReqositionNote.createUser_ID = tbl_securityUserMaster.user_ID";
        }

        #endregion

        #region Uom
        public static void passValue_Uom()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zUom";
            frmSearchMaster.s_Columns = " uomCode [Uom Code], uomName [Uom Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "uom_ID != 'default'";
        }
        #endregion

        #region Costing Type
        public static void passValue_CostingType()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zCostingType";
            frmSearchMaster.s_Columns = " costingType_ID [Type Code], costingTypeName [CostingType Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "costingType_ID != 'default'";
        }
        #endregion

        #region Job Category
        public static void passValue_JobCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zJobCategory";
            frmSearchMaster.s_Columns = " jobCategory_ID [jobCategory Code], jobCategoryName [JobCategory Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "jobCategory_ID != 'default'";
        }
        #endregion

        #region Job Register
        public static void Search_Transaction_JobRegister_Direct(ref TextBox txtBox, bool ShowCanceled)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            frmSearchTransaction.s_TableName = " tbl_sasJobRegister, tbl_genCustomerMaster, tbl_genItemMaster ";
            frmSearchTransaction.s_Columns = " tbl_sasJobRegister.job_ID [Job Code], tbl_genCustomerMaster.customerName [Customer Name] , tbl_genItemMaster.itemName [Product Name], tbl_sasJobRegister.jobDate  [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 150, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };
            string sCondition = "tbl_sasJobRegister.job_ID != 'default' and tbl_sasJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID and tbl_genItemMaster.item_ID = tbl_sasJobRegister.item_ID";
            if (!ShowCanceled)
                sCondition += " AND tbl_sasJobRegister.isDeleted='false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        public static void passValue_JobRegister_PendingCosting()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_sasJobRegister, tbl_genCustomerMaster, tbl_genItemMaster";
            frmSearchTransaction.s_Columns = " job_ID [Job Code], customerName [Customer Name] , itemName [Product Name], jobDate  [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 150, 80 };
            frmSearchTransaction.s_Criteria = "job_ID != 'default' and tbl_sasJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID and tbl_genItemMaster.item_ID = tbl_sasJobRegister.item_ID and isSTSCostingPending = 'true' and isSTSCostingInProgress = 'false'";
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
        }
        public static void passValue_ConfirmedJobRegisterByCustomerID(string sCustomerID)
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_sasJobRegister, tbl_genCustomerMaster, tbl_genItemMaster";
            frmSearchTransaction.s_Columns = " job_ID [Job Code], customerName [Customer Name] , itemName [Product Name], jobDate  [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 150, 80 };
            frmSearchTransaction.s_Criteria = "job_ID != 'default' and tbl_sasJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID and tbl_genItemMaster.item_ID = tbl_sasJobRegister.item_ID and isSTSCostingConfirmed = 'true' and tbl_sasJobRegister.customer_ID = '" + sCustomerID + "'";
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
        }


        #endregion

        #region PreCosting
        public static void passValue_PreCosting()
        {
            //passing values
            frmSearchTransaction.s_TableName = " tbl_sasPreCosting ";
            frmSearchTransaction.s_Columns = " preCosting_ID [PreCosting Code], job_ID [Job Code], kiloPrice [Kilo Price], preCostingDate [Costing Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 120, 120, 120, 100 };
            frmSearchTransaction.s_Criteria = "preCosting_ID != 'default'";
        }
        #endregion

        #region MachineType
        public static void passValue_MachineType()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zMachineType ";
            frmSearchMaster.s_Columns = " machineType_ID [Type ID], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "machineType_ID != 'default'";
        }
        #endregion

        #region MachineClass
        public static void passValue_MachineClass()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zMachineClass ";
            frmSearchMaster.s_Columns = " machineClass_ID [Class ID], className [Class Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "machineClass_ID != 'default'";
        }
        #endregion

        #region MachineCategory
        public static void passValue_MachineCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zMachineCategory ";
            frmSearchMaster.s_Columns = " machineCategory_ID [Category ID], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "machineCategory_ID != 'default'";
        }
        #endregion

        #region Model
        public static void passValue_Model()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zModel ";
            frmSearchMaster.s_Columns = " model_ID [Model ID], modelName [Model Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "model_ID != 'default'";
        }
        #endregion

        #region Machine Sub Category
        public static void passValue_MachineSubCategory()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zMachineCategory_Sub ";
            frmSearchMaster.s_Columns = " machineCategorySub_ID [MachineCategorySub Code], categorySubName [CategorySub Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "MachineCategorySub_ID != 'default'";
        }
        #endregion

        #region Machine Sub Category
        public static void passValue_MachineSubCategoryByCategoryID(string sMachineCategory_ID)
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zMachineCategory_Sub ";
            frmSearchMaster.s_Columns = " machineCategorySub_ID [MachineCategorySub Code], categorySubName [CategorySub Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "MachineCategorySub_ID != 'default'  and machineCategory_ID = '" + sMachineCategory_ID + "' ";
        }
        #endregion

        #region Role
        public static void passValue_Role()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityUserRole ";
            frmSearchMaster.s_Columns = " userRole_ID [Role Code], userRoleName [Role Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "userRole_ID != 'default'";
        }
        #endregion

        #region Machine
        public static void passValue_MachineSpecification()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zMachineSpecification";
            frmSearchMaster.s_Columns = " machineSepcification_ID,machineCategory_ID MachineCategory Code";
            frmSearchMaster.i_ColumnWidth = new int[] { 175, 175 };
            frmSearchMaster.s_Criteria = "machineSepcification_ID != 'default' and machineCategory_ID != 'default'";

        }
        #endregion

        #region Driver
        public static void passValue_DriverID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zDriver ";
            frmSearchMaster.s_Columns = " driver_ID [driver Code], driverName [Driver Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "driver_ID != 'default'";
        }
        #endregion

        #region Company Info
        public static void passValue_Company()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genCompanyInfo";
            frmSearchMaster.s_Columns = " companyID [Company Code], companyName [Company Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "companyID != 'default'";
        }
        #endregion

        #region Company Country
        public static void passValue_CompanyCountry()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genCompanyCountryMaster";
            frmSearchMaster.s_Columns = " companyCountry_ID [CompanyCountry Code], countryName [Country Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "companyCountry_ID != 'default'";
        }
        #endregion

        #region Company Branch
        public static void passValue_CompanyBranch()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genCompanyBranchMaster";
            frmSearchMaster.s_Columns = "  companyBranch_ID [Branch Code], branchName [Branch Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "companyBranch_ID != 'default'";
            frmSearchMaster.s_Order = "Order By [LineNO]";
        }
        #endregion

        #region Company Divition
        public static void passValue_CompanyDivision()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genDivisionMaster";
            frmSearchMaster.s_Columns = " division_ID [CompanyBranch Code], divisionName [Division Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "division_ID != 'default'";
        }
        #endregion
        #region Company Divition
        public static void passValue_CommissionSlabSetting()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_zCommissionSlabSetting";
            frmSearchMaster.s_Columns = " slabID [Slab Code], slabName [Slab Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "slabID != 'default'";
        }
        #endregion

        #region Company Department
        public static void passValue_CompanyDepartment()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genDepartmentMaster";
            frmSearchMaster.s_Columns = " department_ID [Department Code], departmentName [Department Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "Department_ID != 'default'";
        }
        #endregion

        #region Company Section
        public static void passValue_CompanySection()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genSectionMaster";
            frmSearchMaster.s_Columns = " section_ID [Section Code], sectionName [Section Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "section_ID != 'default'";
        }
        #endregion


        #endregion



        #region Old Method 2
        //Alert


        //Employe

        #region  Search Employee
        public static void Search_MasterEmployee_Advance(ref TextBox txtBox, bool bShowMachineOperators, bool bShowSalesmen, bool bShowSaleAndAreaManagers, bool bShowDriversAndAssistant)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genEmployeeMaster ";
            frmSearchMaster.s_Columns = " employee_ID [Emp Code], employeeName [Employee Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            string sCondition = "employee_ID != 'default' AND isSalesExecutive = 0 ";

            if (!bShowMachineOperators)
                sCondition += " AND isOperator = 'false'";
            if (!bShowSalesmen)
                sCondition += " AND isSelesRep ='false'";
            if (!bShowSaleAndAreaManagers)
                sCondition += " AND (isSalesManager ='false' AND isAreaManager ='false')";
            if (!bShowDriversAndAssistant)
                sCondition += " AND (isDriver ='false' AND isAssistant ='false')";

            frmSearchMaster.s_Criteria = sCondition;
            frmSearchMaster.s_Order = "ORDER BY employeeName ASC";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }


        #endregion

        #region Master EmpSupervisor
        public static void Search_MasterEmpSupervisor(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = " tbl_zEmpSupervisor";
            frmSearchMaster.s_Columns = " supervisor_ID [Supervisor Code], supervisorName [Supervisor Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "supervisor_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master EmpOperator
        public static void Search_MasterEmpOperator(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = " tbl_zEmpOperator";
            frmSearchMaster.s_Columns = " operator_ID [Operator Code], operatorName [Operator Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "operator_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master Emp Assistant
        public static void Search_MasterEmpAssistant(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = " tbl_zEmpAssistant";
            frmSearchMaster.s_Columns = " assistant_ID [assistant Code], assistantName [assistant Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "assistant_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion




        #region Section
        public static void Search_MasterSection(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genSectionMaster";
            frmSearchMaster.s_Columns = " section_ID [Section Code], sectionName [Section Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "section_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Brand
        public static void Search_MasterBrand(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_zBrand ";
            frmSearchMaster.s_Columns = " brand_ID [Brand Code], brandName [Brand Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "brand_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Pre Plan
        public static void Search_TransactionPrePlane(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_pmsPrePlan ";
            frmSearchTransaction.s_Columns = " prePlan_ID [Plan Code], productionJob_ID [Job Code], prePlanDate [Plane Date], remark Remark";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };
            frmSearchTransaction.s_Criteria = "prePlan_ID != 'default' AND isDeleted=0";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;

        }
        #endregion

        #region Shift
        public static void Search_MasterShift(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_();
            frmSearchMaster.s_TableName = "tbl_genShiftMaster";
            frmSearchMaster.s_Columns = " shift_ID [Shift Code], shiftName [Shift Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "shift_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion


        //Sales











        #region  Search Delivery Order

        public static void Search_TransactionInvDeliveryOrder_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_sasInvDeliveryOrder, tbl_genCustomerMaster, tbl_zOrderRefNo ";
            frmSearchTransaction.s_Columns = " iDeliveryOrder_ID [D/O Code], customerName [Customer Name], orderRefNo [Ref No], iDeliveryOrderDate [D/O Date], tbl_sasInvDeliveryOrder.isDeleted ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 160, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_sasInvDeliveryOrder.iDeliveryOrder_ID != 'default' AND tbl_sasInvDeliveryOrder.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_zOrderRefNo.orderRefNo_ID = tbl_sasInvDeliveryOrder.orderRefNo_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_sasInvDeliveryOrder.isSeattled = 'false' AND tbl_sasInvDeliveryOrder.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_sasInvDeliveryOrder.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_sasDeliveryOrder.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }


        #endregion

        #region  Search Invoice


        public static void Search_TransactionInvoice_Use(ref TextBox txtBox, bool hasOrderRefNo, string sOrderRefNo, bool bDisplaySettled, bool bShowOppeningBalance, bool bShowRC, bool bShowInvoice)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_sasInvoice, tbl_genCustomerMaster,tbl_zOrderRefNo ";
            frmSearchTransaction.s_Columns = " invoice_ID [Invoice Code], customerName [Customer Name],invoiceDate [Invoice Date], grandTotal [Invoice Total],(grandTotal-SeattleAmount) [Unsettled Amount], CASE WHEN LEN(customerGrnNo) > 0 THEN customerGrnNo ELSE orderRefNo END AS [GRN/Ref No.]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 43, 145, 45, 60, 60, 58 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            string sCondition = "invoice_ID != 'default' AND tbl_sasInvoice.isDeleted = 'false' AND tbl_sasInvoice.customer_ID = tbl_genCustomerMaster.customer_ID  AND tbl_sasInvoice.orderRefNo_ID=tbl_zOrderRefNo.orderRefNo_ID AND tbl_sasInvoice.isDebitNote = 'false' AND tbl_sasInvoice.companyBranch_ID ='" + clsSecurity.BranchID + "' ";
            if (clsConfig.bApprovalEnabledInvoice)
                sCondition += " AND tbl_sasInvoice.isApproved = 'true'";
            if (!bDisplaySettled)
                sCondition += " AND tbl_sasInvoice.isSeattled = 'false'";
            if (!bShowOppeningBalance)
                sCondition += " AND tbl_sasInvoice.isOpeningBalance = 'false'";
            if (!bShowRC)
                sCondition += " AND tbl_sasInvoice.isReturnedCheque = 'false'";
            if (!bShowInvoice)
                sCondition += " AND (tbl_sasInvoice.isOpeningBalance = 'true' OR tbl_sasInvoice.isReturnedCheque = 'true')";
            if (hasOrderRefNo)
                sCondition += " AND tbl_sasInvoice.orderRefNo_ID = '" + sOrderRefNo + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_sasInvoice.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }


        #endregion


        #region Search DeliveryPlan
        public static void Search_TransactionDeliveryPlan_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_sasDeliveryPlan";
            frmSearchTransaction.s_Columns = " deliveryPlan_ID [DO Plan No.], deliveryPlanDate [DOP Date], grandTotal [DOP Amount], remark [remark], tbl_sasDeliveryPlan.isDeleted [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 160, 80, 100, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "deliveryPlan_ID != 'default'";
            if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                sCondition += " AND tbl_sasDeliveryPlan.isSeattled = 'false' AND tbl_sasDeliveryPlan.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_sasDeliveryPlan.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Master Order Ref
        public static void Search_MasterOrderReferance(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zOrderRefNo, tbl_genEmployeeMaster";
            frmSearchMaster.s_Columns = " orderRefNo_ID [Order Ref Code], orderRefNo [Order Ref No], employeeName [Sales Officer] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 75, 75, 200 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_zOrderRefNo.orderRefNo_ID != 'default' AND tbl_zOrderRefNo.employee_ID = tbl_genEmployeeMaster.employee_ID";

            if (!ShowSettled && clsConfig.bSettleEnabledInquiry)
                sCondition += " AND tbl_zOrderRefNo.isActive='True'";

            frmSearchMaster.s_Criteria = sCondition;
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search QuotatonType
        public static void Search_MasterQuotationType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zQuotationType ";
            frmSearchMaster.s_Columns = " quotationType_ID [Type ID], quotationTypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "quotationType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion



        #region Item SerialNo_GiftVoucher
        public static void Search_ItemSerialNo_GiftVoucher(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_zItemSerialNo_GiftVoucher, tbl_genItemMaster ";
            frmSearchTransaction.s_Columns = " tbl_zItemSerialNo_GiftVoucher.itemSerialNo [Item Serial No], tbl_zItemSerialNo_GiftVoucher.Item_ID [Item ID], tbl_genItemMaster.itemName [Item Name] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 230 };

            string sCondition = " tbl_zItemSerialNo_GiftVoucher.Item_ID != 'default' and tbl_zItemSerialNo_GiftVoucher.Item_ID  = tbl_genItemMaster.Item_ID ";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY tbl_zItemSerialNo_GiftVoucher.Item_ID ASC ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Sales Commission
        public static void Search_SalesCommission(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_sasSalesCommission, tbl_genEmployeeMaster ";
            frmSearchMaster.s_Columns = " commissionDate [commission Date], commission_ID [commission ID], employeeName [Employee Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 75, 75, 200 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "commission_ID != 'default' AND tbl_sasSalesCommission.employee_ID = tbl_genEmployeeMaster.employee_ID";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        //Bills



        #region  Search Cheque
        public static void Search_TransactionCheque_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsChequeRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Register Code], chequeNumber [Cheque Number], customerName [Customer Name], amount [Cheque Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_bpsChequeRegister.companyBranch_ID = '" + clsSecurity.BranchID + "' AND chequeRegister_ID != 'default' AND tbl_bpsChequeRegister.customer_ID = tbl_genCustomerMaster.customer_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_bpsChequeRegister.isSetteled = 'false' AND tbl_bpsChequeRegister.isDeleted = 'false'";
            //if (true)
             //   sCondition += " AND tbl_bpsChequeRegister.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsChequeRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionCheque_Use(ref TextBox txtBox, bool hasOrderRefNo, string sOrderRefNo, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsChequeRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Register Code], chequeNumber [Cheque Number], customerName [Customer Name], chequeAmount [Cheque Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_bpsChequeRegister.companyBranch_ID = '" + clsSecurity.BranchID + "' AND  chequeRegister_ID != 'default' AND tbl_bpsChequeRegister.isDeleted = 'false' AND tbl_bpsChequeRegister.customer_ID = tbl_genCustomerMaster.customer_ID";
            if (clsConfig.bApprovalEnabledInvoice)
                sCondition += " AND tbl_bpsChequeRegister.isApproved = 'true'";
            if (!ShowSettled)
                sCondition += " AND tbl_bpsChequeRegister.isSeattled = 'false'";
            if (hasOrderRefNo)
                sCondition += " AND tbl_bpsChequeRegister.orderRefNo_ID = '" + sOrderRefNo + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsChequeRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionChequeByCustomerID_Use(ref TextBox txtBox, string sCustomerID, bool hasOrderRefNo, string sOrderRefNo, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsChequeRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Register Code], chequeNumber [Cheque Number], customerName [Customer Name], chequeAmount [Cheque Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_bpsChequeRegister.companyBranch_ID = '" + clsSecurity.BranchID + "' AND   salesReturnedNote_ID != 'default' AND tbl_bpsChequeRegister.isDeleted = 'false' AND tbl_bpsChequeRegister.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_bpsChequeRegister.customer_ID = '" + sCustomerID + "'";
            if (clsConfig.bApprovalEnabledInvoice)
                sCondition += " AND tbl_bpsChequeRegister.isApproved = 'true'";
            if (!ShowSettled)
                sCondition += " AND tbl_bpsChequeRegister.isSeattled = 'false'";
            if (hasOrderRefNo)
                sCondition += " AND tbl_bpsChequeRegister.orderRefNo_ID = '" + sOrderRefNo + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsChequeRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion




        #region  Search Credit Note
        //public static void Search_TransactionCreditNote_Direct(ref TextBox txtBox, bool ShowSettled)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " tbl_bpsCreditNote, tbl_genCustomerMaster ";
        //    frmSearchTransaction.s_Columns = " creditNote_ID [Credit Code], customerName [Customer Name], totalAmount [Total Amount], creditNoteDate [CreditNote Date], tbl_bpsCreditNote.isDeleted [Canceled] ";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 70, 160, 80, 70, 40 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

        //    string sCondition = "creditNote_ID != 'default' AND tbl_bpsCreditNote.customer_ID = tbl_genCustomerMaster.customer_ID";
        //    if (!ShowSettled)
        //        sCondition += " AND tbl_bpsCreditNote.isSeattled = 'false' AND tbl_bpsCreditNote.isDeleted = 'false' AND chequeRegister_ID = 'default'";
        //    if (true)
        //        sCondition += " AND tbl_bpsCreditNote.isFinished = 'false' AND chequeRegister_ID = 'default' ";
        //    frmSearchTransaction.s_Criteria = sCondition;
        //    frmSearchTransaction.s_Order = "ORDER BY tbl_bpsCreditNote.dateCreate DESC";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchID;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}

        public static void Search_TransactionCreditNoteByCustomerID_Use(ref TextBox txtBox, string sCustomerID, bool hasOrderRefNo, string sOrderRefNo, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsCreditNote, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " creditNote_ID [Credit Code], customerName [Customer Name], totalAmount [Total Amount], creditNoteDate [CreditNote Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = "creditNote_ID != 'default' AND tbl_bpsCreditNote.isDeleted = 'false' AND tbl_bpsCreditNote.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_bpsCreditNote.advanceReceived_Index < 0 AND tbl_bpsCreditNote.posReturnTransaction_Index < 0 ";
            if (sCustomerID.Length > 0)
                sCondition += "AND tbl_bpsCreditNote.customer_ID = '" + sCustomerID + "'";
            if (clsConfig.bApprovalEnabledInvoice)
                sCondition += " AND tbl_bpsCreditNote.isApproved = 'true'";
            if (!ShowSettled)
                sCondition += " AND tbl_bpsCreditNote.isSeattled = 'false'";
            if (hasOrderRefNo)
                sCondition += " AND tbl_bpsCreditNote.orderRefNo_ID = '" + sOrderRefNo + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsCreditNote.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion





        #region Search Cheque
        public static void Search_TransactionChequeRegister_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsChequeRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " chequeRegister_ID [Cheque Register Code], customerName [Customer Name], chequeNumber [Cheque Number], dateCheque [Date Cheque]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_bpsChequeRegister.companyBranch_ID = '" + clsSecurity.BranchID + "' AND chequeRegister_ID != 'default' AND tbl_bpsChequeRegister.customer_ID = tbl_genCustomerMaster.customer_ID";
            if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
                sCondition += " AND tbl_bpsChequeRegister.isSetteled = 'false' AND tbl_bpsChequeRegister.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_bpsChequeRegister.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsChequeRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Company Branch
        public static void Search_MasterCompanyBranch(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_genCompanyBranchMaster";
            frmSearchMaster.s_Columns = " companyBranch_ID [Branch Code], branchName [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "companyBranch_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Factoring
        public static void Search_FactoringNo(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_bpsFactoringAgreement ";
            frmSearchMaster.s_Columns = "factoringAgreementNo [Agreement Code], accountNumber [Account], bank_ID [Bank Code], branch_ID [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 90, 90, 90, 90 };
            frmSearchMaster.s_Criteria = "factoringAgreementNo != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        public static void Search_Transaction_FactoringNo(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsFactoringSchedule ";
            frmSearchTransaction.s_Columns = " factoringSehedule_ID [Sehedule ID], factoringSeheduleDate [Sehedule Date],totalAmount [Amount] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 60, 70, 70 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue };

            string sCondition = " factoringSehedule_ID != 'default'";
            if (!ShowSettled)
                sCondition += " AND isDeleted = 'false' ";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY factoringSehedule_ID DESC ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region  Search Bank

        public static void SearchMaster_CompanyBankBranchesByBankID(ref TextBox txtBox, string sBankID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genCompanyAccount, tbl_zBankBranches ";
            frmSearchMaster.s_Columns = " tbl_genCompanyAccount.branch_ID [Branch Code], tbl_zBankBranches.branchName [Branch Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "tbl_genCompanyAccount.branch_ID != 'default' AND tbl_genCompanyAccount.branch_ID = tbl_zBankBranches.branch_ID AND tbl_genCompanyAccount.bank_ID = '" + sBankID + "'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion



        #region  Search Cheque Type
        public static void Search_ChequeType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zChequeType";
            frmSearchMaster.s_Columns = " chequeType_ID [Type Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "chequeType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }


        #endregion

        #region  Search Receipt
        public static void Search_Receipt(ref TextBox txtBox, bool bisDebitNote)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsReceipt, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " receipt_ID [Receipt Code], customerName [Customer Name], totalAmount [Total Amount], receiptDate [Receipt Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.s_Criteria = "receipt_ID != 'default' AND tbl_bpsReceipt.isDeleted = 'false' AND tbl_bpsReceipt.customer_ID = tbl_genCustomerMaster.customer_ID";

            if (bisDebitNote)
                frmSearchTransaction.s_Criteria += " AND tbl_bpsReceipt.isSeattled='false' ";

            frmSearchTransaction.s_Order = "ORDER BY tbl_bpsReceipt.receipt_ID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        #endregion

        #region Cash Deposite

        public static void Search_CashDeposite(string companyID, string companyBranchID, ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_bpsCashDeposit ";
            frmSearchMaster.s_Columns = " cashDeposit_ID [Deposite ID], accountHolder [Account Holder] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "cashDeposit_ID != 'default' AND tbl_bpsCashDeposit.companyID ='" + companyID + "' AND tbl_bpsCashDeposit.companyBranch_ID ='" + companyBranchID + "' ";
            frmhelpsearch.ShowDialog();


            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }

        }


        #endregion

        #region  Search_Settelment
        public static void Search_Settelment(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_sasInvoice_Sattled ";
            frmSearchTransaction.s_Columns = " allocationID [Allocation ID], settled_ID [Settled ID], invoice_ID [Invoice NO], receipt_ID [Receipt NO], sattledAmount [Settled Amount], isAdvancePayment [Adv], isOverPayment [Ovr] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 70, 70, 70, 40, 30, 30 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY allocationID DESC ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion


        //Stock



        #region Purchase Return Note
        public static void Search_MasterPurchaseReturnNote(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_scsPurchaseReturnedNote";
            frmSearchMaster.s_Columns = " purchaseReturnedNote_ID [PRN Code], purchaseReturnedNoteDate [PRN Date] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "purchaseReturnedNote_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion



        #region Damaged Goods Note
        public static void Search_TransactionDamagedGoodsNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsDamagedGoodNote, tbl_genStoreMaster";
            frmSearchTransaction.s_Columns = " DamagedGoodNote_ID [DGN Code], storeName [Store Name], DamagedGoodNoteDate [DGN Date], remark [Remarks], tbl_scsDamagedGoodNote.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 90, 40 };

            string sCondition = " tbl_scsDamagedGoodNote.DamagedGoodNote_ID != 'default' AND tbl_genStoreMaster.store_ID = tbl_scsDamagedGoodNote.store_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_scsDamagedGoodNote.isSeattled = 'false' AND tbl_scsDamagedGoodNote.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_scsDamagedGoodNote.dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region  Search MRP
        public static void Search_TransactionMRP_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsMatfor";
            frmSearchTransaction.s_Columns = "mrp_ID [MRP Code], mrpTitle [MRP Title], CONVERT(char(12), mrpStartDate, 103) [Start Date], CONVERT(char(12), mrpEndDate, 103) [End Date]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };

            string sCondition = "mrp_ID != 'default'";
            if (!ShowSettled)
                sCondition += " AND isSeattled = 'false' AND isDeleted = 'false'";
            if (true)
                sCondition += " AND isFinished = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionCustomerOrder_Use(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsMatfor";
            frmSearchTransaction.s_Columns = " mrp_ID [MRP Code], mrpTitle [MRP Title], CONVERT(char(12), mrpStartDate, 103) [Start Date], CONVERT(char(12), mrpEndDate, 103) [End Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };

            string sCondition = "mrp_ID != 'default'";
            if (true)
                sCondition += " AND isSeattled = 'false' AND isDeleted = 'false'";
            if (true)
                sCondition += " AND isFinished = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Stock Note type
        public static void Search_MasterStockNoteType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_zStockNoteType";
            frmSearchMaster.s_Columns = " stockNoteType_ID [Type Code], stockNoteName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "stockNoteType_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Credit Note/Debit Note
        public static void Search_MasterCreditNoteType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCreditNoteType";
            frmSearchMaster.s_Columns = " creditNoteType_ID [CRNType ID],creditNoteTypeName [CreditNoteType Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = " creditNoteType_ID !='default' AND creditNoteType_ID !='TP/003 '";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        #endregion

        #region Batch Approval Status
        public static void Search_MasterBatchApprovalStatus(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_zBatchApprovalStatus";
            frmSearchMaster.s_Columns = " batchApprovalStatus_ID [Status Code], batchApprovalStatus [Status Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "batchApprovalStatus_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Payment Method Master
        //public static void Search_MasterPaymentMethod(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_zPaymentMethod ";
        //    frmSearchMaster.s_Columns = " paymentMethod_ID [PaymentMethod ID], paymentMethodName [PaymentMethod Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "paymentMethod_ID != 'default'";
        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}
        #endregion


        #region Store
        //public static void Search_MasterStore_Old(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    //clsSearch.passValue_Section();
        //    frmSearchMaster.s_TableName = " tbl_genStoreMaster  ";
        //    frmSearchMaster.s_Columns = " tbl_genStoreMaster.store_ID [Store Code], tbl_genStoreMaster.storeName [Store Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
        //    frmSearchMaster.s_Criteria = "tbl_genStoreMaster.store_ID != 'default' AND tbl_genStoreMaster.isSalesRepStore = 'false'";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}


        public static void Search_MasterStore_DamagedStore(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_genStoreMaster join [tbl_genCompanyBranchMaster] on tbl_genStoreMaster.companyBranch_ID = tbl_genCompanyBranchMaster.[companyBranch_ID] ";
            frmSearchMaster.s_Columns = " tbl_genStoreMaster.store_ID [Store Code], tbl_genStoreMaster.storeName [Store Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tbl_genStoreMaster.store_ID != 'default' AND tbl_genStoreMaster.isSalesRepStore = 'false' and isDamagedStore = 1";
            frmSearchMaster.s_Order = " order by  tbl_genCompanyBranchMaster.Shortorder ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Department
        public static void Search_MasterDepartment(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genDepartmentMaster";
            frmSearchMaster.s_Columns = " department_ID [Department Code], departmentName [Department Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "department_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region UOM Master
        public static void Search_MasterUomForPacking(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zUom ";
            frmSearchMaster.s_Columns = " uom_ID [Uom ID], uomCode [Uom Code], UomName [Uom Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "uom_ID != 'default' AND isVisible = 'true' AND isForPacking = 'true'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }

        public static void Search_MasterUOM(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zUom";
            frmSearchMaster.s_Columns = " uom_ID [Uom Code], uomCode [Uom Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "uom_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Search Account
        //public static void Search_TransactionCustomerAccountByCustomerID(ref TextBox txtBox, string sCustomerID)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " tbl_genCustomerAccount, tbl_genCustomerMaster, tbl_zBank";
        //    frmSearchTransaction.s_Columns = " tbl_genCustomerAccount.accountNumber [Account Code], customerName [Customer Name], bankName [Bank Name],  returnedCount Returned";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 100, 210, 80, 70 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchTransaction.s_Criteria = "accountNumber != 'default' AND tbl_genCustomerAccount.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_genCustomerAccount.customer_ID = '" + sCustomerID + "' and tbl_zBank.bank_ID = tbl_genCustomerAccount.bank_ID";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchID;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}
        #endregion

        #region MRP Category
        public static void Search_MasterMRPCategory(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_zMRPCategory";
            frmSearchMaster.s_Columns = " mrpCategory_ID [Cat. Code], mrpCategoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "mrpCategory_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search JobRegister
        public static void Search_TransactionJobRegister(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_sasJobRegister, tbl_genCustomerMaster, tbl_genItemMaster";
            frmSearchTransaction.s_Columns = " job_ID [Job Code], jobDate  [Job Date], customerName [Customer Name] , itemName [Product Name] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 150, 150 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = "job_ID != 'default' and tbl_sasJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID and tbl_genItemMaster.item_ID = tbl_sasJobRegister.item_ID";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion


        //job Realated-----------------------------------------

        #region Polythine Type Master
        public static void Search_MasterPolythineType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zJobPolytheneType ";
            frmSearchMaster.s_Columns = " polytheneType_ID [PolytheneType Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "polytheneType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Polythine Material Type Master
        public static void Search_MasterPolythineMaterialType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zJobPolytheneMaterialType ";
            frmSearchMaster.s_Columns = " polytheneMaterailType_ID [PolytheneType Code], polytheneMaterailTypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "polytheneMaterailType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Lamination Type Master
        public static void Search_MasterLaminationType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobLaminationType";
            frmSearchMaster.s_Columns = " laminationType_ID [LaminationType Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "laminationType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Lamination Materail Type Master
        public static void Search_MasterLaminationMaterailType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zJobLaminationMaterialType ";
            frmSearchMaster.s_Columns = " laminationMaterailType_ID [LaminationType Code], laminationMaterailTypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "laminationMaterailType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Sealing Type Master
        public static void Search_MasterSealingType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobSealingType";
            frmSearchMaster.s_Columns = " sealingType_ID [Sealing Type], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "sealingType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Sealing Method Master
        public static void Search_MasterSealingMethod(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobSealingMethod";
            frmSearchMaster.s_Columns = " sealingMethod_ID [Sealing Method], sealingMethod [Method Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "sealingMethod_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Sliting Type Master
        public static void Search_MasterSlittingType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobSlittingType";
            frmSearchMaster.s_Columns = " slittingType_ID [Slitting Type], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "slittingType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Measurement Type Master
        public static void Search_MasterMeasurementType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobMeasurementType";
            frmSearchMaster.s_Columns = " measureType_ID [MeasureType Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "measureType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Treatment Type Master
        public static void Search_MasterTreatmentType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobTreatnmentStatus";
            frmSearchMaster.s_Columns = " treatnmentStatus_ID [TreatnmentStatus Code], treatnmentStatus [Treatnment Status] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "treatnmentStatus_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Pouch Type Master
        public static void Search_MasterPouchType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobPouchType";
            frmSearchMaster.s_Columns = " pouchType_ID [PouchType Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pouchType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Print Type Master
        public static void Search_MasterPrintType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobPrintingType";
            frmSearchMaster.s_Columns = " printingType_ID [printingType Code], typeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "printingType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Printing Method Master
        public static void Search_MasterPrintingMethod(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobPrintingMethod";
            frmSearchMaster.s_Columns = " printingMethod_ID [PrintingMethod Code], printingMethod [Method Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "printingMethod_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Gussest Type Master
        public static void Search_MasterGussestType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobGussestType";
            frmSearchMaster.s_Columns = " gussestType_ID [GussestType Code], gussestTypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "gussestType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Handle Type Master
        public static void Search_MasterHandleType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobHandleType";
            frmSearchMaster.s_Columns = " handleType_ID [HandleType Code], handleTypeeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "handleType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master Job Lamination
        public static void Search_MasterJobLamination(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = "tbl_zJobLaminationType";
            frmSearchMaster.s_Columns = " laminationType_ID [LaminationType Code], typeName [Type Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "laminationType_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master Job Lamination Material
        public static void Search_MasterJobLaminationMaterialType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = "tbl_zJobLaminationMaterialType";
            frmSearchMaster.s_Columns = " laminationMaterailType_ID [LaminationMaterailType Code], laminationMaterailTypeName [LaminationMaterailType Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "laminationMaterailType_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion


        //Machine -------------------

        #region Search Machine Master
        public static void Search_MasterMachine(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genMachineMaster";
            frmSearchMaster.s_Columns = " machine_ID [Machine Code], machineName [Machine Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "machine_ID != 'default' AND isSuspended = 'false' AND isOutOfDate = 'false' AND isSoldOut = 'false' AND isDeleted = 'false'";

            frmSearchMaster.s_Criteria = sCondition;
            frmSearchMaster.s_Order = "ORDER BY machineName";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
        }
        public static void Search_MasterMachineSectionID(ref TextBox txtBox, string sSectionID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genMachineMaster";
            frmSearchMaster.s_Columns = " machine_ID [Machine Code], machineName [Machine Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "machine_ID != 'default' AND section_ID='" + sSectionID + "' AND isSuspended = 'false' AND isOutOfDate = 'false' AND isSoldOut = 'false' AND isDeleted = 'false'";

            frmSearchMaster.s_Criteria = sCondition;
            frmSearchMaster.s_Order = "ORDER BY machineName";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
        }
        #endregion


        //Petty Cash -----------------

        #region  Search Petty Cash Income Type
        public static void Search_MasterPettyCashIncomeType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCashIncomeType ";
            frmSearchMaster.s_Columns = " pettyCashIncomeType_ID Type_ID, pettyCashIncomeTypeName IncomeTypeName ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCashIncomeType_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search Petty Cash ExpenditureType
        public static void Search_MasterPettyCashExpenditureType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCashExpenditureType ";
            frmSearchMaster.s_Columns = " pettyCashExpenditureType_ID Type_ID, pettyCashExpenditureTypeName pettyCashExpenditureTypeName ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCashExpenditureType_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        //public static void Search_MasterPettyCashExpenditureTypeWithLevel(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " vw_searchExpenditureType ";
        //    frmSearchTransaction.s_Columns = " pettyCashExpenditureType_ID [Exp ID] , pettyCashExpenditureTypeName [ExpenditureTitle] , pettyCash_Level_3Name [Level 3 Name] , pettyCash_Level_2Name  [Level 2 Name] ";
        //    //80, 200, 80, 100 
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 60, 200, 100, 100 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchTransaction.s_Criteria = " pettyCashExpenditureTypeName != 'default' ";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchText;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}
        public static void Search_MasterPettyCashLeval_1(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCash_Level_1 ";
            frmSearchMaster.s_Columns = " pettyCash_Level_1_ID Level_1_ID, pettyCash_Level_1Name Level_1_Name";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCash_Level_1_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterPettyCashLeval_2(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCash_Level_2 ";
            frmSearchMaster.s_Columns = " pettyCash_Level_2_ID Level_2_ID, pettyCash_Level_2Name Level_2_Name";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCash_Level_2_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterPettyCashLeval_3(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCash_Level_3 ";
            frmSearchMaster.s_Columns = " pettyCash_Level_3_ID Level_3_ID, pettyCash_Level_3Name Level_3_Name";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCash_Level_3_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterPettyCashLeval_4(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPettyCash_Level_4 ";
            frmSearchMaster.s_Columns = " pettyCash_Level_4_ID Level_4_ID, pettyCash_Level_4Name Level_4_Name";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCash_Level_4_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasteCost_CenterType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCost_Center";
            frmSearchMaster.s_Columns = " cost_Center_ID cost_Center_ID, cost_Center_Name Cost_Center_Name ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "cost_Center_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search Petty Cash Account
        public static void Search_TransactionPettyCashAccount(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashAccount";
            frmSearchMaster.s_Columns = " pettyCashAccount_ID Account_ID, pettyCashAccountName PettyAccountName, expireDate ExpireDate";
            frmSearchMaster.i_ColumnWidth = new int[] { 90, 150, 110 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchMaster.s_Criteria = "pettyCashAccount_ID != 'default' AND isDeleted <> 1";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

        #region  Search Petty Cash Account VoucherNo
        public static void Search_TransactionPettyCashAccountVoucherNo(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashAccount_Transaction";
            frmSearchMaster.s_Columns = " voucherNo VoucherNo, sum(amount) Amount";
            frmSearchMaster.i_ColumnWidth = new int[] { 250, 110 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "pettyCashAccount_ID != 'default' AND isDeleted <> 1 ";
            frmSearchMaster.s_Order = "GROUP BY tbl_bpsPettyCashAccount_Transaction.voucherNo";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        public static void Search_TransactionPettyCashAccountVoucherNoBypettyCashAccount(ref TextBox txtBox, string pettyCashAccount)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashAccount_Transaction";
            frmSearchMaster.s_Columns = " voucherNo VoucherNo, sum(amount) Amount";
            frmSearchMaster.i_ColumnWidth = new int[] { 250, 110 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            frmSearchMaster.s_Criteria = "pettyCashAccount_ID != 'default' AND isDeleted <> 1 and pettyCashAccount_ID = '" + pettyCashAccount + "'";
            frmSearchMaster.s_Order = "GROUP BY tbl_bpsPettyCashAccount_Transaction.voucherNo";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

        #region  Search Petty Cash Account spentUserName
        public static void Search_TransactionPettyCashAccountSpentUserName(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "vw_PettyCashAccountSpentUserName";
            frmSearchMaster.s_Columns = " spentUserName S , spentUserName SpentUserName, TotalAmount Amount ";
            frmSearchMaster.i_ColumnWidth = new int[] { 0, 200, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        public static void Search_TransactionPettyCashAccountSpentUserNameBypettyCashAccount(ref TextBox txtBox, string pettyCashAccount)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "vw_PettyCashAccountSpentUserName";
            frmSearchMaster.s_Columns = "  spentUserName S , spentUserName SpentUserName, TotalAmount Amount ";
            frmSearchMaster.i_ColumnWidth = new int[] { 0, 200, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

        #region PettyCashAccount_IOU
        public static void Search_TransactionPettyCashAccount_IOUByPettyCashID(ref TextBox txtBox, string sPettyCashID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashAccount_IOU , tbl_bpsPettyCashAccount";
            frmSearchMaster.s_Columns = " tbl_bpsPettyCashAccount_IOU.iouAccount_ID Account_ID, tbl_bpsPettyCashAccount_IOU.remark IOU_Name ,tbl_bpsPettyCashAccount_IOU.balanceAmount Balance_Amount";
            frmSearchMaster.i_ColumnWidth = new int[] { 80, 150, 120 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            frmSearchMaster.s_Criteria = "tbl_bpsPettyCashAccount_IOU.iouAccount_ID != 'default' and tbl_bpsPettyCashAccount.pettyCashAccount_ID = tbl_bpsPettyCashAccount_IOU.pettyCashAccount_ID and tbl_bpsPettyCashAccount.pettyCashAccount_ID = '" + sPettyCashID + "'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Cost Center
        public static void Search_MasteCost_CenterType(ref TextBox txtBox, string columName)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCost_Center";
            frmSearchMaster.s_Columns = " cost_Center_ID [" + columName + " ID], cost_Center_Name [" + columName + " Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "cost_Center_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasteCost_CenterType2(ref TextBox txtBox, string columName)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCost_Center2";
            frmSearchMaster.s_Columns = " cost_Center2_ID [" + columName + " ID], cost_Center2_Name [" + columName + " Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "cost_Center2_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasteCost_CenterType3(ref TextBox txtBox, string columName)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCost_Center3";
            frmSearchMaster.s_Columns = " cost_Center3_ID [" + columName + " ID], cost_Center3_Name [" + columName + " Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "cost_Center3_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search Petty Cash Account Name
        public static void Search_TransactionPettyCashAccountName(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashAccount";
            frmSearchMaster.s_Columns = " pettyCashAccount_ID Account_ID, pettyCashAccountName PettyAccountName, expireDate ExpireDate";
            frmSearchMaster.i_ColumnWidth = new int[] { 90, 150, 110 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchMaster.s_Criteria = "pettyCashAccount_ID != 'default' AND isDeleted <> 1";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        #endregion

        #region  Petty Cash Reimbursement
        public static void Search_TransactionPettyCashReimbursement(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_bpsPettyCashReimbursement";
            frmSearchMaster.s_Columns = " reimbRequest_ID [Reimb Request No], totalExpenditure [Expenditure Amount], reimbRequestDate [Reimb Request Date], tbl_bpsPettyCashReimbursement.isDeleted [Canceled] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 90, 100, 90, 55 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
            frmSearchMaster.s_Criteria = "reimbRequest_ID != 'default' ";

            string sCondition = "reimbRequest_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " AND tbl_bpsPettyCashReimbursement.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
        }
        #endregion

        #region APN Type
        public static void Search_AccountPayableNoteType_Direct(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_zAccAccountPaybleNoteType";
            frmSearchTransaction.s_Columns = " apnType_ID [APN Type ID],apnTypeName [APN type Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "apnType_ID != 'default'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY apnType_ID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_AccountPayableNoteType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccAccountPaybleNoteType ";
            frmSearchMaster.s_Columns = " apnType_ID [Type ID],apnTypeName [APN type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 254 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "apnType_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        #endregion

        //Money
        #region Master Tax
        public static void Search_MasterTax(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = "tbl_zTax";
            frmSearchMaster.s_Columns = " tax_ID [Tax Code], taxName [Tax Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tax_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion


        //PMS - Pro Tables
        #region Production Plan - Pro Tables
        public static void Search_TransactionPro_ProductionPlan_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_proProductionPlan ";
            frmSearchTransaction.s_Columns = " productionPlan_ID [productionPlan Code] , productionPlanRefNo [Plan Ref No] , productionPlanDate [Plan Date] , remarks [Remarks] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 100, 110, };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = " productionPlan_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " AND isDeleted = 'false' ";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY dateCreate DESC ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPro_WIP_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_proWorkInProgress ";
            frmSearchTransaction.s_Columns = " workInProgress_ID [WIP Code] , productionJob_ID [Job Code] , workInProgressDate [WIP Date] , remark [Remarks] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 100, 110, };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = " workInProgress_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " AND isDeleted = 'false' ";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY dateCreate DESC ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPro_Job_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_proProductionPlan_Job ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Job Code] , itemName [Item Name] , productionPlan_StartDate [WIP St.Date] , remark [Remarks] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 90, 140, 90, 90, };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = " productionJob_ID != 'default' AND tbl_genItemMaster.item_ID = tbl_proProductionPlan_Job.item_ID";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY productionPlan_StartDate DESC ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        //PMS
        #region Production Job
        public static void Search_MasterProductionJob(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_pmsProductionJobRegister ";
            frmSearchMaster.s_Columns = "  job_ID [Job Code], productionJob_ID [ProductionJob Code] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "productionJob_ID != 'default'";
            frmSearchMaster.s_Order = "ORDER BY productionOrderDate DESC";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchText;

        }
        public static void Search_TransactionProductionJobRegisterIsNotClosed(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Code], customerName [Customer Name], startDate [Start Date], productionOrderDate [ProductionOrder Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_pmsProductionJobRegister.isJobClosed = 'false'";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_MasterProductionJobForWorkInProgress(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_pmsProductionJobRegister ";
            frmSearchMaster.s_Columns = " job_ID [Job Code], productionJob_ID [ProductionJob Code]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "productionJob_ID != 'default' AND isJobWorkInProgress=0 AND isApproved=1 AND isPrePlaned = 1 AND isDeleted <> 1 AND isJobSuspended <> 1";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchText;

        }
        public static void Search_MasterProductionJobForPrePlan(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_pmsProductionJobRegister ";
            frmSearchMaster.s_Columns = " job_ID [Job Code], productionJob_ID [ProductionJob Code]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "productionJob_ID != 'default' AND isPrePlaned <> 1 AND isFinished <>1 AND isJobClosed <> 1 AND isApproved=1 AND isDeleted <> 1 AND isJobSuspended <> 1";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchText;

        }
        #endregion

        #region Production JobType Type Master
        public static void Search_MasterProductionJobType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zJobProductionJobType";
            frmSearchMaster.s_Columns = " productionJobType_ID [JobType Code], productionJobTypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "productionJobType_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Work in Progress
        public static void Search_TransactionWorkInProgress(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_pmsWorkInProgress ";
            frmSearchTransaction.s_Columns = " workInProgress_ID [WIP Code], productionJob_ID [Job Code], workInProgressDate [WIP Date], remark Remarks";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = "workInProgress_ID != 'default' AND isDeleted=0 ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchTransaction.s_SearchID;
            }
        }
        #endregion

        #region  Transation Production Job Order
        public static void Search_TransactionProductionJobRegister(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister as p, tbl_genCustomerMaster as c ,tbl_sasCustomerOrder as co ";
            frmSearchTransaction.s_Columns = " p.productionJob_ID [Production Job], co.purchaseOrder_ID [purchaseOrder ID], c.customerName [Customer Name], p.startDate [Start Date], p.productionOrderDate [Job Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 68, 68, 170, 60, 60 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = " p.productionJob_ID != 'default' AND p.isDeleted = 'false' AND p.customer_ID = c.customer_ID and p.customerOrder_ID=co.customerOrder_ID ";
            frmSearchTransaction.s_Order = "ORDER BY p.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionProductionJobRegisterByCustomerID(ref TextBox txtBox, string sCustomerID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Job], customerName [Customer Name], startDate [Start Date], productionOrderDate [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "tbl_pmsProductionJobRegister.productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID and tbl_pmsProductionJobRegister.customer_ID = '" + sCustomerID + "'";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionProductionJobRegisterPrePlan(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Job], customerName [Customer Name], startDate [Start Date], productionOrderDate [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "tbl_pmsProductionJobRegister.productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_pmsProductionJobRegister.isPrePlaned = 'True'";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionProductionJobRegisterWorkInProgress(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Job], customerName [Customer Name], startDate [Start Date], productionOrderDate [ProductionOrder Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "tbl_pmsProductionJobRegister.productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_pmsProductionJobRegister.isJobWorkInProgress = 'True'";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionProductionJobRegister_Use(ref TextBox txtBox, bool bShowSettle, bool bShowUnCloseJob)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_genCustomerMaster RIGHT OUTER JOIN tbl_sasCustomerOrder ON tbl_genCustomerMaster.customer_ID = tbl_sasCustomerOrder.customer_ID RIGHT OUTER JOIN tbl_pmsProductionJobRegister ON tbl_sasCustomerOrder.customerOrder_ID = tbl_pmsProductionJobRegister.customerOrder_ID";
            frmSearchTransaction.s_Columns = " tbl_genCustomerMaster.customerName [Customer Name], tbl_pmsProductionJobRegister.productionJob_ID [Job No], tbl_sasCustomerOrder.purchaseOrder_ID [PO No], tbl_pmsProductionJobRegister.productionOrderDate [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 200, 80, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = "tbl_pmsProductionJobRegister.productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_sasCustomerOrder.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_pmsProductionJobRegister.isApproved = 'true'";
            if (!bShowSettle)
                sCondition += " AND tbl_sasCustomerOrder.isSeattled = 'false'";
            if (!bShowUnCloseJob)
                sCondition += " AND tbl_pmsProductionJobRegister.isJobClosed ='true'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_pmsProductionJobRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchText;
        }
        public static void Search_TransactionProductionJobRegisterByCustomerID_Use(ref TextBox txtBox, string sCustomerID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_genCustomerMaster RIGHT OUTER JOIN tbl_sasCustomerOrder ON tbl_genCustomerMaster.customer_ID = tbl_sasCustomerOrder.customer_ID RIGHT OUTER JOIN tbl_pmsProductionJobRegister ON tbl_sasCustomerOrder.customerOrder_ID = tbl_pmsProductionJobRegister.customerOrder_ID";
            frmSearchTransaction.s_Columns = " tbl_genCustomerMaster.customerName [Customer Name], tbl_pmsProductionJobRegister.productionJob_ID [Job No], tbl_sasCustomerOrder.purchaseOrder_ID [PO No], tbl_pmsProductionJobRegister.productionOrderDate [Job Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 200, 80, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = "tbl_pmsProductionJobRegister.productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_sasCustomerOrder.isDeleted = 'false' AND tbl_sasCustomerOrder.customer_ID = '" + sCustomerID + "'";
            if (true)
                sCondition += " AND tbl_pmsProductionJobRegister.isApproved = 'true'";
            if (true)
                sCondition += " AND tbl_sasCustomerOrder.isSeattled='false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY tbl_pmsProductionJobRegister.dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchText;
        }
        public static void Search_ProductionJobAndCOID(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "  dbo.tbl_pmsProductionJobRegister INNER JOIN dbo.tbl_sasCustomerOrder ON dbo.tbl_pmsProductionJobRegister.customerOrder_ID = dbo.tbl_sasCustomerOrder.customerOrder_ID INNER JOIN dbo.tbl_genCustomerMaster ON dbo.tbl_sasCustomerOrder.customer_ID = dbo.tbl_genCustomerMaster.customer_ID";
            frmSearchTransaction.s_Columns = " dbo.tbl_sasCustomerOrder.customerOrder_ID [Order_ID], dbo.tbl_pmsProductionJobRegister.productionJob_ID [Production_ID],  dbo.tbl_genCustomerMaster.customerName [Customer_Name],dbo.tbl_pmsProductionJobRegister.productionOrderDate";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "dbo.tbl_pmsProductionJobRegister.productionJob_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Production Job Register All Jobs
        public static void Search_TransactionProductionJobRegisterAllJobs(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Job], customerName [Customer Name], startDate [Start Date], productionOrderDate [ProductionOrder Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "productionJob_ID != 'default' AND tbl_pmsProductionJobRegister.isDeleted = 'false' AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID ";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionProductionJobRegisterAllJobs(ref TextBox txtBox, bool bHideIsDelete, bool bShowStatus)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_pmsProductionJobRegister, tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " productionJob_ID [Production Job], customerName [Customer Name], startDate [Start Date], productionOrderDate [ProductionOrder Date]";
            if (bShowStatus)
            {
                frmSearchTransaction.s_Columns += ", CASE WHEN tbl_pmsProductionJobRegister.isDeleted = 1  THEN 'Deleted'  ELSE	(CASE WHEN tbl_pmsProductionJobRegister.isJobClosed = 1	THEN 'Closed' ELSE 'New' END) END AS [Status]";
                frmSearchTransaction.i_ColumnWidth = new int[] { 70, 200, 60, 60, 60 };
                frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };

            }
            else
            {
                frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
                frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.DateValue };
            }
            if (bHideIsDelete)
            {
                frmSearchTransaction.s_Criteria = " tbl_pmsProductionJobRegister.isDeleted = 'false' AND ";
            }
            frmSearchTransaction.s_Criteria += "productionJob_ID != 'default'  AND tbl_pmsProductionJobRegister.customer_ID = tbl_genCustomerMaster.customer_ID ";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Master Job Polythene Material
        public static void Search_MasterJobPolytheneMaterialType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //passing values
            frmSearchMaster.s_TableName = "tbl_zJobPolytheneMaterialType";
            frmSearchMaster.s_Columns = " polytheneMaterailType_ID [Type Code], polytheneMaterailTypeName [poly-MaterailType Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "polytheneMaterailType_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion


        //Item
        #region Advance Item Search
        //public static void Search_AdvanceItemMaster1(ref TextBox ItemBox, ref TextBox CategoryBox, ref TextBox SerialBox)
        //{
        //    frmItemSearch frm = new frmItemSearch();
        //    frm.ShowDialog();
        //    if (frmItemSearch.glbItemID.Length > 0)
        //    {
        //        ItemBox.Tag = frmItemSearch.glbItemID;
        //        ItemBox.Text = clsGenaralName.getName_Item(frmItemSearch.glbItemID);

        //        if (frmItemSearch.glbItemSubCategory.Length > 0)
        //            CategoryBox.Tag = frmItemSearch.glbItemSubCategory;
        //        if (frmItemSearch.glbItemSubCategory2.Length > 0)
        //            CategoryBox.Text = frmItemSearch.glbItemSubCategory2;

        //        if (frmItemSearch.glbSerialNo.Length > 0)
        //            SerialBox.Tag = frmItemSearch.glbSerialNo;
        //        if (frmItemSearch.glbSerialNo2.Length > 0)
        //            SerialBox.Text = frmItemSearch.glbSerialNo2;
        //    }
        //}
        //public static void Search_AdvanceItemMaster2(ref TextBox ItemBox, ref TextBox CategoryBox, ref TextBox SerialBox)
        //{
        //    frmItemSearchAdvance frm = new frmItemSearchAdvance();
        //    frm.ShowDialog();
        //    if (frmItemSearchAdvance.glbItemID.Length > 0)
        //    {
        //        ItemBox.Tag = frmItemSearchAdvance.glbItemID;
        //        ItemBox.Text = clsGenaralName.getName_Item(frmItemSearchAdvance.glbItemID);

        //        if (frmItemSearchAdvance.glbItemSubCategory.Length > 0)
        //            CategoryBox.Tag = frmItemSearchAdvance.glbItemSubCategory;
        //        if (frmItemSearchAdvance.glbItemSubCategory2.Length > 0)
        //            CategoryBox.Text = frmItemSearchAdvance.glbItemSubCategory2;

        //        if (frmItemSearchAdvance.glbSerialNo.Length > 0)
        //            SerialBox.Tag = frmItemSearchAdvance.glbSerialNo;
        //        if (frmItemSearchAdvance.glbSerialNo2.Length > 0)
        //            SerialBox.Text = frmItemSearchAdvance.glbSerialNo2;
        //    }
        //}
        public static void Search_AdvanceItemMasterStock(ref TextBox ItemBox, ref TextBox CategoryBox, ref TextBox SerialBox, string sStoreID, string sSectionID, string sDepartmentID)
        {
            frmItemSearchStock frm = new frmItemSearchStock();
            if (sStoreID.Length > 0)
                frm.sStoreID = sStoreID;
            if (sSectionID.Length > 0)
                frm.sSectionID = sSectionID;
            if (sDepartmentID.Length > 0)
                frm.sDepartmentID = sDepartmentID;
            frm.ShowDialog();

            if (frmItemSearchStock.glbItemID.Length > 0)
            {
                ItemBox.Tag = frmItemSearchStock.glbItemID;
                ItemBox.Text = clsGenaralName.getName_Item(frmItemSearchStock.glbItemID);

                if (frmItemSearchStock.glbItemSubCategory.Length > 0)
                    CategoryBox.Tag = frmItemSearchStock.glbItemSubCategory;
                if (frmItemSearchStock.glbItemSubCategory2.Length > 0)
                    CategoryBox.Text = frmItemSearchStock.glbItemSubCategory2;

                if (frmItemSearchStock.glbSerialNo.Length > 0)
                    SerialBox.Tag = frmItemSearchStock.glbSerialNo;
                if (frmItemSearchStock.glbSerialNo2.Length > 0)
                    SerialBox.Text = frmItemSearchStock.glbSerialNo2;
            }
        }
        #endregion

        #region Transaction Item By Item Serial No
        public static void Search_TransactionItemMasterByItemSerialNo(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            frmSearchTransaction.s_TableName = " tbl_zItemSerialNo, tbl_genItemMaster, tbl_genStore_Stock ";
            frmSearchTransaction.s_Columns = " tbl_zItemSerialNo.item_ID [Item Code], tbl_zItemSerialNo.itemSerialNo [item Serial No], tbl_genItemMaster.itemName [Item Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 90, 180, 200 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = " tbl_zItemSerialNo.item_ID != 'default' AND tbl_genItemMaster.isDeleted <> 1 AND tbl_genStore_Stock.availableQty > 0 AND tbl_zItemSerialNo.item_ID = tbl_genItemMaster.item_ID "
                + " And tbl_zItemSerialNo.item_ID = tbl_genStore_Stock.item_ID  And tbl_zItemSerialNo.itemSerialNo = tbl_genStore_Stock.itemSerialNo ";
            frmSearchTransaction.s_Order = " Order by tbl_zItemSerialNo.item_ID ";
            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Item Type Master
        public static void Search_MasterItemType_MultileSelect(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster_MultipleSelection();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster_MultipleSelection.s_TableName = " tbl_zItemType ";
            frmSearchMaster_MultipleSelection.s_Columns = " itemType_ID [Type Code], TypeName [Type Name] ";
            frmSearchMaster_MultipleSelection.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster_MultipleSelection.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster_MultipleSelection.s_Criteria = "itemType_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster_MultipleSelection.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster_MultipleSelection.s_SearchText;
            if (frmSearchMaster_MultipleSelection.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster_MultipleSelection.s_SearchID;
        }
        public static void Search_MasterItemTypeByExceptItemTypeID(ref TextBox txtBox, string sItemTypeID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemType ";
            frmSearchMaster.s_Columns = " itemType_ID [Type Code], TypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemType_ID != 'default' AND itemType_ID <> '" + sItemTypeID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterItemTypeByItemTypeID(ref TextBox txtBox, string sItemTypeID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemType ";
            frmSearchMaster.s_Columns = " itemType_ID [Type Code], TypeName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemType_ID != 'default' AND itemType_ID = '" + sItemTypeID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Item Master
        //public static void Search_ItemMaster(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_genItemMaster ";
        //    frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 AND companyBranch_ID ='" + clsSecurity.BranchID + "' ";
        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;

        //}

        public static void Search_ItemMasterByCatagoryID(ref TextBox txtBox, string Catagory_ID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genItemMaster,tbl_zItemCategory ";
            frmSearchMaster.s_Columns = " tbl_genItemMaster.item_ID [Item Code], tbl_genItemMaster.itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tbl_genItemMaster.item_ID != 'default' AND tbl_genItemMaster.isDeleted <> 1 AND tbl_genItemMaster.itemCategory_ID=tbl_zItemCategory.itemCategory_ID ";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }


        #endregion

        #region Item Master By Item Serial No
        public static void Search_ItemMasterItemSerialNo(ref TextBox txtBox, string sItemID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zItemSerialNo, tbl_genStore_Stock ";
            frmSearchMaster.s_Columns = " tbl_zItemSerialNo.item_ID [Item Code], tbl_zItemSerialNo.itemSerialNo [item Serial No] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tbl_zItemSerialNo.item_ID = '" + sItemID
                + "' And tbl_genStore_Stock.availableQty > 0  And  tbl_zItemSerialNo.item_ID = tbl_genStore_Stock.item_ID And tbl_zItemSerialNo.itemSerialNo = tbl_genStore_Stock.itemSerialNo ";
            frmSearchMaster.s_Order = " Order By tbl_zItemSerialNo.itemSerialNo ";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Master Section Stock Item
        public static void Search_TransactionSectionStockItem(ref TextBox txtBox, string sSectionID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_genItemMaster, tbl_genSection_Stock";
            frmSearchTransaction.s_Columns = " tbl_genSection_Stock.item_ID [Item Code], tbl_genItemMaster.itemName [Item Name],tbl_genSection_Stock.qty Qty,tbl_genSection_Stock.weight Weight ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            frmSearchTransaction.s_Criteria = "tbl_genSection_Stock.item_ID != 'default' AND tbl_genItemMaster.isDeleted <> 1 AND tbl_genSection_Stock.item_ID=tbl_genItemMaster.item_ID  AND tbl_genSection_Stock.section_ID='" + sSectionID + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Master Store Stock Item
        public static void Search_TransactionStoreStockItem(ref TextBox txtBox, string sStoreID)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_genItemMaster, tbl_genStore_Stock";
            frmSearchTransaction.s_Columns = " tbl_genStore_Stock.item_ID [Item Code], tbl_genItemMaster.itemName [Item Name],tbl_genStore_Stock.qty Qty,tbl_genStore_Stock.weight Weight ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 240, 55, 70 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            frmSearchTransaction.s_Criteria = "tbl_genStore_Stock.item_ID != 'default'  AND tbl_genItemMaster.isDeleted <> 1 AND tbl_genStore_Stock.item_ID=tbl_genItemMaster.item_ID  AND tbl_genStore_Stock.store_ID='" + sStoreID + "' AND tbl_genItemMaster.companyBranch_ID ='" + clsSecurity.BranchID + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        #endregion

        #region Master Store Stock Item
        public static void Search_TransactionByItemCodeStoreStockItem(ref TextBox txtBox, string sStoreID)
        {
            Form frmhelpsearch = new frmSearchTransaction(0);
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_genItemMaster, tbl_genStore_Stock";
            frmSearchTransaction.s_Columns = " tbl_genStore_Stock.item_ID [Item Code], tbl_genItemMaster.itemName [Item Name],tbl_genStore_Stock.qty Qty,tbl_genStore_Stock.weight Weight ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 240, 55, 70 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            frmSearchTransaction.s_Criteria = "tbl_genStore_Stock.item_ID != 'default'  AND tbl_genItemMaster.isDeleted <> 1 AND tbl_genStore_Stock.item_ID=tbl_genItemMaster.item_ID  AND tbl_genStore_Stock.store_ID='" + sStoreID + "' AND tbl_genItemMaster.companyBranch_ID ='" + clsSecurity.BranchID + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        #endregion

        #region Search Item By TypeID
        public static void Search_MasterItemByTypeID(ref TextBox txtBox, string sTypeID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genItemMaster ";
            frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 and itemType_ID = '" + sTypeID + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Search Item Category By Class ID
        public static void Search_MasterItemCategoryByClassID(ref TextBox txtBox, string sClassID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemCategory , tbl_zItemType ";
            frmSearchMaster.s_Columns = " tbl_zItemCategory.itemCategory_ID [ItemCategory Code], tbl_zItemCategory.categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tbl_zItemCategory.itemType_ID != 'default'and tbl_zItemType.itemType_ID = tbl_zItemCategory.itemType_ID and tbl_zItemType.itemClass_ID = '" + sClassID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Search Item By Category ID
        public static void Search_MasterItemByCategoryID(ref TextBox txtBox, string sCategory)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genItemMaster ";
            frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 and itemCategory_ID = '" + sCategory + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Search Item By ClassID
        public static void Search_MasterItemByClassID(ref TextBox txtBox, string sClass)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genItemMaster ";
            frmSearchMaster.s_Columns = " item_ID [Item Code], itemName [Item Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 and itemClass_ID = '" + sClass + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Item Category Master

        public static void Search_MasterItemCategoryByTypeID(ref TextBox txtBox, string sTypeID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemCategory";
            frmSearchMaster.s_Columns = " itemCategory_ID [ItemCategory Code], categoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemType_ID != 'default' and itemType_ID = '" + sTypeID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Item Category Sub Master
        public static void Search_MasterItemCategorySub(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemCategory_Sub";
            frmSearchMaster.s_Columns = " itemCategorySub_ID [SubCategory Code], categorySubName [SubCategory Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemCategorySub_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterItemCategorySubByCategoryID(ref TextBox txtBox, string sCategoryID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_ProductionJob();
            frmSearchMaster.s_TableName = " tbl_zItemCategory_Sub";
            frmSearchMaster.s_Columns = " itemCategorySub_ID [SubCategory Code], categorySubName [SubCategory Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemCategorySub_ID != 'default' and itemCategory_ID = '" + sCategoryID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Pre Plan Output Items
        public static void Search_TransactionPrePlanOutPutItems(ref TextBox txtBox, string sPrePlanID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_pmsPrePlan_SectionPath_OutputItem,tbl_genItemMaster,tbl_genSectionMaster ";
            frmSearchTransaction.s_Columns = " tbl_pmsPrePlan_SectionPath_OutputItem.item_ID [Item ID],tbl_genItemMaster.itemName [Item Name],tbl_pmsPrePlan_SectionPath_OutputItem.prePlan_ID [PrePlan ID],tbl_genSectionMaster.sectionName [Section Name] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = "tbl_pmsPrePlan_SectionPath_OutputItem.item_ID != 'default' AND tbl_genItemMaster.isDeleted <> 1 AND tbl_pmsPrePlan_SectionPath_OutputItem.item_ID=tbl_genItemMaster.item_ID AND tbl_pmsPrePlan_SectionPath_OutputItem.section_ID= tbl_genSectionMaster.section_ID  AND tbl_pmsPrePlan_SectionPath_OutputItem.prePlan_ID='" + sPrePlanID + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;

        }
        #endregion

        #region Item Colour
        public static void Search_MasterColour(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zColour";
            frmSearchMaster.s_Columns = " colour_ID [Colour Code], colourName [Colour Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "colour_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Item Size
        public static void Search_MasterItemSize(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zItemSize ";
            frmSearchMaster.s_Columns = " itemSize_ID [ItemSize Code], itemSizeName [itemSize Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemSize_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region  Search Item
        //public static void Search_MasterItemByItemType(ref TextBox txtBox, string sItemType)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " tbl_genItemMaster ";
        //    frmSearchTransaction.s_Columns = " item_ID [Item Code], itemName [Item Name], generateCode [Search Code], sellingPrice1 [Selling Price]";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

        //    frmSearchTransaction.s_Criteria = "item_ID != 'default' AND isDeleted <> 1 AND itemType_ID = '" + sItemType + "'";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchID;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}

        //public static void Search_MasterItem(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " tbl_genItemMaster ";
        //    frmSearchTransaction.s_Columns = " item_ID [Item Code], itemName [Item Name], generateCode [Search Code], sellingPrice1 [Selling Price]";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

        //    frmSearchTransaction.s_Criteria = "item_ID != 'default' AND isDeleted <> '1'";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchID;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}

        //public static void Search_MasterItem_ByCompanyBranchID(ref TextBox txtBox, string ComBranch_ID)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = " tbl_genItemMaster ";
        //    frmSearchTransaction.s_Columns = " item_ID [Item Code], itemName [Item Name], generateCode [Search Code], sellingPrice1 [Selling Price]";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 100, 150, 110, 100 };
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

        //    frmSearchTransaction.s_Criteria = "item_ID != 'default' AND isDeleted <> '1' AND companyBranch_ID = '" + ComBranch_ID + "' ";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchID;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}
        #endregion

        #region Item Class
        //public static void Search_MasterItemClass(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    //clsSearch.passValue_ProductionJob();
        //    frmSearchMaster.s_TableName = "tbl_zItemClass";
        //    frmSearchMaster.s_Columns = " itemClass_ID [ItemClass Code], className [class Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "itemClass_ID != 'default'";

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}
        #endregion

        #region Item Sub Category

        public static void Search_MasterItemSubCategory(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zItemSubCategory";
            frmSearchMaster.s_Columns = " itemSubCategory_ID [SubCategory Code], itemSubCategoryName [SubCategory Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemSubCategory_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Item Sub Category 2
        public static void Search_MasterItemSubCategory2(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_zItemSubCategory2";
            frmSearchMaster.s_Columns = " itemSubCategory2_ID [SubCategory Code], itemSubCategory2Name [SubCategory Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "itemSubCategory2_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion


        //User

        #region  Search User Master
        public static void Search_MasterUser(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityUserMaster";
            frmSearchMaster.s_Columns = " user_ID [User Code], userName [User Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "user_ID != 'default'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_MasterUserExceptByUserID(ref TextBox txtBox, string sUserID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityUserMaster";
            frmSearchMaster.s_Columns = " user_ID [User Code], userName [User Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "user_ID != 'default'and user_ID != '" + sUserID + "' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        //Terminal

        #region Terminal
        public static void passValue_Terminal(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityTerminalMaster ";
            frmSearchMaster.s_Columns = " terminal_ID [terminal_ID], terminal_Name [terminal_Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "terminal_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

            //  frmhelpsearch.ShowDialog();
        }
        #endregion

        #region Company and Branch
        public static void Search_Company(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_genCompanyInfo";
            frmSearchMaster.s_Columns = " companyID [Company Code], companyName [Company Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "companyID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }


        #endregion

        //Stock

        #region Transaction Section
        #region Transaction Section GTN
        public static void Search_TransactionGoodTransferNote(ref TextBox txtBox, bool bShowAll, object sFrmStoreID, object sToStoreID)
        {
            Form frmhelpsearch = new frmSearchTransaction();

            frmSearchTransaction.s_TableName = " tbl_scsGoodTransferNote ";
            frmSearchTransaction.s_Columns = " goodTransferNote_ID [GTN Code] , goodTransferNoteDate [GTN Date],isDeleted  [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsGoodTransferNote.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsGoodTransferNote.goodTransferNote_ID != 'default' ";

            if (!bShowAll)
                sCondition += "  AND tbl_scsGoodTransferNote.isDeleted = 'false' ";

            if (sFrmStoreID != null)
                sCondition += "  AND tbl_scsGoodTransferNote.storeID_From = '" + sFrmStoreID.ToString() + "' ";

            if (sToStoreID != null)
                sCondition += "  AND tbl_scsGoodTransferNote.storeID_To = '" + sToStoreID.ToString() + "' ";

            frmSearchTransaction.s_Criteria = sCondition;

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }


        #endregion
        #region Transaction Section GIN
        public static void Search_TransactionSectionGoodIssueNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_scsSectionGoodIssueNote, tbl_genSectionMaster, tbl_scsSectionGoodIssueNote_Detail ";
            frmSearchTransaction.s_Columns = " tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID [GIN Code], tbl_scsSectionGoodIssueNote_Detail.job_ID [Job Code], sectionName [Section Name], sectionGoodIssueNoteDate [GIN Date], tbl_scsSectionGoodIssueNote.isDeleted  [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID != 'default' AND tbl_scsSectionGoodIssueNote.fromSection_ID  = tbl_genSectionMaster.section_ID AND tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID=tbl_scsSectionGoodIssueNote_Detail.sectionGoodIssueNote_ID ";
            if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                sCondition += " AND tbl_scsSectionGoodIssueNote.isSeattled = 'false' AND tbl_scsSectionGoodIssueNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsSectionGoodIssueNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID , sectionName ,tbl_scsSectionGoodIssueNote_Detail.job_ID , sectionGoodIssueNoteDate , tbl_scsSectionGoodIssueNote.isDeleted ORDER BY sectionGoodIssueNoteDate DESC ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionSectionGoodIssueNoteBySectionID(ref TextBox txtBox, string sFromID, string sToID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsSectionGoodIssueNote, tbl_genSectionMaster";
            frmSearchTransaction.s_Columns = " sectionGoodIssueNote_ID [GIN Code], sectionName [Section Name], job_ID [Job Code], sectionGoodIssueNoteDate [GIN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "sectionGoodIssueNote_ID != 'default' AND tbl_scsSectionGoodIssueNote.isDeleted=0 AND tbl_scsSectionGoodIssueNote.isSeattled = 0 AND tbl_scsSectionGoodIssueNote.toSection_ID  = tbl_genSectionMaster.section_ID AND tbl_scsSectionGoodIssueNote.toSection_ID = '" + sToID + "' AND tbl_scsSectionGoodIssueNote.fromSection_ID= '" + sFromID + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionSectionGoodIssueNoteByStoreID(ref TextBox txtBox, string sFromID, string sToID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_scsSectionGoodIssueNote, tbl_genSectionMaster,tbl_scsSectionGoodIssueNote_Detail ";
            frmSearchTransaction.s_Columns = " tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID [GIN Code], sectionName [Section Name], tbl_scsSectionGoodIssueNote_Detail.job_ID [Job Code], sectionGoodIssueNoteDate [GIN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = " tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID != 'default' AND tbl_scsSectionGoodIssueNote.isDeleted=0 AND tbl_scsSectionGoodIssueNote.isSeattled = 0 AND tbl_scsSectionGoodIssueNote.fromSection_ID  = tbl_genSectionMaster.section_ID AND tbl_scsSectionGoodIssueNote.toStore_ID = '" + sToID + "' AND tbl_scsSectionGoodIssueNote.fromSection_ID= '" + sFromID + "' AND tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID= tbl_scsSectionGoodIssueNote_Detail.sectionGoodIssueNote_ID ";
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsSectionGoodIssueNote.sectionGoodIssueNote_ID, sectionName, tbl_scsSectionGoodIssueNote_Detail.job_ID , sectionGoodIssueNoteDate  ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Section SR
        public static void Search_TransactionSectionStoreReqositionNote(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);

            frmSearchTransaction.s_TableName = "tbl_scsSectionReqositionNote ,tbl_genSectionMaster,tbl_scsSectionReqositionNote_Detail";
            frmSearchTransaction.s_Columns = " tbl_scsSectionReqositionNote.SectionReqositionNote_ID [SRN Code], tbl_scsSectionReqositionNote_Detail.job_ID [Job Code] , sectionName  [Section Name], sectionReqositionNoteDate [SRN Date], tbl_scsSectionReqositionNote.isDeleted [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsSectionReqositionNote.SectionReqositionNote_ID != 'default' AND tbl_scsSectionReqositionNote.fromSection_ID = tbl_genSectionMaster.section_ID AND tbl_scsSectionReqositionNote.sectionReqositionNote_ID=tbl_scsSectionReqositionNote_Detail.sectionReqositionNote_ID ";
            if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                sCondition += " AND tbl_scsSectionReqositionNote.isSeattled = 'false' AND tbl_scsSectionReqositionNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsSectionReqositionNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsSectionReqositionNote.SectionReqositionNote_ID , sectionName  , tbl_scsSectionReqositionNote_Detail.job_ID  , sectionReqositionNoteDate , tbl_scsSectionReqositionNote.isDeleted   ORDER BY sectionReqositionNoteDate DESC ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;

        }
        public static void Search_TransactionSectionStoreReqositionNote_Use(ref TextBox txtBox, string SectionID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsSectionReqositionNote, tbl_genSectionMaster";
            frmSearchTransaction.s_Columns = " SectionReqositionNote_ID [SRN Code], sectionName  [Section Name], job_ID [Job Code] , sectionReqositionNoteDate [SRN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "SectionReqositionNote_ID != 'default' and tbl_scsSectionReqositionNote.isDeleted =0 and tbl_scsSectionReqositionNote.isSeattled =0 and tbl_scsSectionReqositionNote.fromSection_ID = tbl_genSectionMaster.section_ID and tbl_scsSectionReqositionNote.fromSection_ID  = '" + SectionID + "' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionSectionStoreReqositionNote_Use(ref TextBox txtBox, string SectionID, bool ShowUnPR)
        {
            Form frmhelpsearch = new frmSearchTransaction();

            frmSearchTransaction.s_TableName = "tbl_scsSectionReqositionNote ,tbl_genSectionMaster,tbl_scsSectionReqositionNote_Detail";
            frmSearchTransaction.s_Columns = " tbl_scsSectionReqositionNote.SectionReqositionNote_ID [SRN Code], tbl_scsSectionReqositionNote_Detail.job_ID [Job Code] , sectionName  [Section Name], sectionReqositionNoteDate [SRN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = "tbl_scsSectionReqositionNote.SectionReqositionNote_ID != 'default' AND tbl_scsSectionReqositionNote.fromSection_ID = tbl_genSectionMaster.section_ID AND tbl_scsSectionReqositionNote.sectionReqositionNote_ID=tbl_scsSectionReqositionNote_Detail.sectionReqositionNote_ID ";
            sCondition += " AND tbl_scsSectionReqositionNote.isDeleted = 'false' AND tbl_scsSectionReqositionNote.fromSection_ID  = '" + SectionID + "' ";
            if (ShowUnPR)
                sCondition += " AND tbl_scsSectionReqositionNote.isPRdone = 'false'";
            if (true)
                sCondition += " AND tbl_scsSectionReqositionNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsSectionReqositionNote.SectionReqositionNote_ID , sectionName  , tbl_scsSectionReqositionNote_Detail.job_ID  , sectionReqositionNoteDate  ORDER BY sectionReqositionNoteDate DESC ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;

        }
        #endregion

        #region Transaction Section GRN
        public static void Search_TransactionSectionGoodReceiveNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);

            frmSearchTransaction.s_TableName = " tbl_scsSectionGoodReceiveNote, tbl_genSectionMaster,tbl_scsSectionGoodReceiveNote_Detail ";
            frmSearchTransaction.s_Columns = " tbl_scsSectionGoodReceiveNote.sectionGoodReceiveNote_ID [GRN Code], tbl_scsSectionGoodReceiveNote_Detail.job_ID [Job Code], sectionName [Section Name], sectionGoodReceiveNoteDate [GRN Date], tbl_scsSectionGoodReceiveNote.isDeleted [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            //            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_scsSectionGoodReceiveNote.sectionGoodReceiveNote_ID != 'default' AND tbl_scsSectionGoodReceiveNote.toSection_ID  = tbl_genSectionMaster.section_ID AND tbl_scsSectionGoodReceiveNote.sectionGoodReceiveNote_ID=tbl_scsSectionGoodReceiveNote_Detail.sectionGoodReceiveNote_ID ";
            if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                sCondition += " AND tbl_scsSectionGoodReceiveNote.isDeleted = 'false' ";
            if (true)
                sCondition += " AND tbl_scsSectionGoodReceiveNote.isFinished = 'false' ";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsSectionGoodReceiveNote.sectionGoodReceiveNote_ID , sectionName , tbl_scsSectionGoodReceiveNote_Detail.job_ID , sectionGoodReceiveNoteDate, tbl_scsSectionGoodReceiveNote.isDeleted  ORDER BY sectionGoodReceiveNoteDate DESC ";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        #endregion
        #endregion

        #region Transaction Store

        #region Tranaction Store GIN
        public static void Search_TransactionStoreGoodIssueNoteByStoreID(ref TextBox txtBox, string sFromID, string sToID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsStoreGoodIssueNote, tbl_genStoreMaster";
            frmSearchTransaction.s_Columns = " storeGoodIssueNote_ID [GIN Code], storeName [Store Name], job_ID [Job Code], storeGoodIssueNoteDate [GIN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = " storeGoodIssueNote_ID != 'default' AND tbl_scsStoreGoodIssueNote.isFinished=0 AND tbl_scsStoreGoodIssueNote.isDeleted=0 AND tbl_scsStoreGoodIssueNote.isSeattled=0 AND tbl_scsStoreGoodIssueNote.toStore_ID  = tbl_genStoreMaster.store_ID  AND tbl_scsStoreGoodIssueNote.toStore_ID = '" + sToID + "' AND tbl_scsStoreGoodIssueNote.fromStore_ID = '" + sFromID + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionStoreGoodIssueNoteBySectionID(ref TextBox txtBox, string sFromID, string sToID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = " tbl_scsStoreGoodIssueNote, tbl_genStoreMaster, tbl_scsStoreGoodIssueNote_Detail ";
            frmSearchTransaction.s_Columns = " tbl_scsStoreGoodIssueNote.storeGoodIssueNote_ID [GIN Code], storeName [Store Name], tbl_scsStoreGoodIssueNote_Detail.job_ID [Job Code], storeGoodIssueNoteDate [GIN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = " tbl_scsStoreGoodIssueNote.storeGoodIssueNote_ID != 'default' AND tbl_scsStoreGoodIssueNote.isDeleted=0 AND tbl_scsStoreGoodIssueNote.isSeattled=0 AND tbl_scsStoreGoodIssueNote.isFinished=0 AND tbl_scsStoreGoodIssueNote.fromStore_ID  = tbl_genStoreMaster.store_ID  AND tbl_scsStoreGoodIssueNote.toSection_ID = '" + sToID + "' AND tbl_scsStoreGoodIssueNote.fromStore_ID = '" + sFromID + "' AND tbl_scsStoreGoodIssueNote.storeGoodIssueNote_ID=tbl_scsStoreGoodIssueNote_Detail.storeGoodIssueNote_ID ";
            frmSearchTransaction.s_Order = " GROUP BY tbl_scsStoreGoodIssueNote.storeGoodIssueNote_ID , storeName , tbl_scsStoreGoodIssueNote_Detail.job_ID, storeGoodIssueNoteDate  ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Store SR
        public static void Search_TransactionStoreStoreReqositionNote_Use(ref TextBox txtBox, string StoreID, bool ShowUnPR)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsStoreReqositionNote, tbl_genStoreMaster";
            frmSearchTransaction.s_Columns = " StoreRecositionNote_ID [SRN Code], storeName  [Store Name], job_ID [Job Code] , StoreRecositionNoteDate [SRN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = " StoreRecositionNote_ID != 'default' and tbl_scsStoreReqositionNote.isDeleted =0 AND tbl_scsStoreReqositionNote.fromStore_ID = tbl_genStoreMaster.store_ID and tbl_scsStoreReqositionNote.fromStore_ID  = '" + StoreID + "'";
            if (ShowUnPR)
                sCondition += " AND tbl_scsStoreReqositionNote.isPRdone = 'false'";
            if (true)
                sCondition += " AND tbl_scsStoreReqositionNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionStoreStoreReqositionNote_Use(ref TextBox txtBox, string StoreID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsStoreReqositionNote, tbl_genStoreMaster";
            frmSearchTransaction.s_Columns = " StoreRecositionNote_ID [SRN Code], storeName  [Store Name], job_ID [Job Code] , StoreRecositionNoteDate [SRN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = " StoreRecositionNote_ID != 'default' and tbl_scsStoreReqositionNote.isDeleted =0 AND tbl_scsStoreReqositionNote.isSeattled =0 AND tbl_scsStoreReqositionNote.fromStore_ID = tbl_genStoreMaster.store_ID and tbl_scsStoreReqositionNote.fromStore_ID  = '" + StoreID + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #endregion

        #region Transaction Purchase Requisition
        public static void Search_TransactionPurchaseReqositionNote_Direct(ref TextBox txtBox, bool ShowSettled, string sNoteType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseRequisition";
            frmSearchTransaction.s_Columns = " purchaseRequisitionNote_ID [PRN Code], job_ID [Job Code], remark [Remarks], purchaseRequisitionNoteDate [PR Date], tbl_scsPurchaseRequisition.isDeleted [Canceled]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 150, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsPurchaseRequisition.purchaseRequisitionNote_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " AND tbl_scsPurchaseRequisition.isSeattled='false' AND tbl_scsPurchaseRequisition.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseRequisition.isFinished = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseRequisition.stockNoteType_ID =  '" + sNoteType + "'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPurchaseReqositionNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseRequisition";
            frmSearchTransaction.s_Columns = " purchaseRequisitionNote_ID [PRN Code], job_ID [Job Code], remark [Remarks], purchaseRequisitionNoteDate [PR Date], tbl_scsPurchaseRequisition.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 150, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsPurchaseRequisition.purchaseRequisitionNote_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " AND tbl_scsPurchaseRequisition.isSeattled='false' AND tbl_scsPurchaseRequisition.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseRequisition.isFinished = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPurchaseReqositionNote_Use(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseRequisition";
            frmSearchTransaction.s_Columns = " purchaseRequisitionNote_ID [PRN Code], job_ID [Job Code], remark [Remarks], purchaseRequisitionNoteDate [PR Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = "tbl_scsPurchaseRequisition.purchaseRequisitionNote_ID != 'default'";
            if (true)
                sCondition += " AND tbl_scsPurchaseRequisition.isSeattled='false' AND tbl_scsPurchaseRequisition.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseRequisition.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Department

        #region Transaction Department SR
        public static void Search_TransactionDepartmentStoreReqositionNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsDepartmentReqositionNote, tbl_genDepartmentMaster, tbl_securityUserMaster";
            frmSearchTransaction.s_Columns = " departmentReqositionNote_ID [SRN Code], departmentName  [Department Name], tbl_securityUserMaster.userName [User Name] , departmentReqositionNoteDate [SRN Date], tbl_scsDepartmentReqositionNote.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 130, 100, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "departmentReqositionNote_ID != 'default' AND tbl_scsDepartmentReqositionNote.createUser_ID = tbl_securityUserMaster.user_ID and tbl_scsDepartmentReqositionNote.fromDepartment_ID = tbl_genDepartmentMaster.department_ID";

            if (!ShowSettled)
                sCondition += " AND tbl_scsDepartmentReqositionNote.isSeattled = 'false' AND tbl_scsDepartmentReqositionNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsDepartmentReqositionNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionDepartmentStoreReqositionNote_Use(ref TextBox txtBox, string DepartmentID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsDepartmentReqositionNote, tbl_genDepartmentMaster, tbl_securityUserMaster";
            frmSearchTransaction.s_Columns = " departmentReqositionNote_ID [SRN Code], departmentName  [Department Name], tbl_securityUserMaster.userName [User Name] , departmentReqositionNoteDate [SRN Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            string sCondition = "departmentReqositionNote_ID != 'default' AND tbl_scsDepartmentReqositionNote.createUser_ID = tbl_securityUserMaster.user_ID and tbl_scsDepartmentReqositionNote.fromDepartment_ID = tbl_genDepartmentMaster.department_ID and tbl_scsDepartmentReqositionNote.fromDepartment_ID = '" + DepartmentID + "' ";

            if (true)
                sCondition += " AND tbl_scsDepartmentReqositionNote.isSeattled = 'false' AND tbl_scsDepartmentReqositionNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsDepartmentReqositionNote.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Department GIN
        public static void Search_TransactionDepartmentGoodIssueNoteByDepartmentID(ref TextBox txtBox, string sFromID, string sToID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsDepartmentGoodIssueNote, tbl_genDepartmentMaster";
            frmSearchTransaction.s_Columns = " departmentGoodIssueNote_ID [GIN Code], departmentName  [Department Name], job_ID [Job Code] , departmentGoodIssueNoteDate [GIN Date] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchTransaction.s_Criteria = "departmentGoodIssueNote_ID != 'default' AND tbl_scsDepartmentGoodIssueNote.isFinished=0 AND tbl_scsDepartmentGoodIssueNote.toDepartment_ID = tbl_genDepartmentMaster.department_ID AND tbl_scsDepartmentGoodIssueNote.toDepartment_ID = '" + sToID + "' AND tbl_scsDepartmentGoodIssueNote.fromDepartment_ID = '" + sFromID + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
        }
        #endregion
        #endregion

        #region Transaction Stock Adjustment
        public static void Search_TransactionStockAdjustment(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsStockAdjustment, tbl_genStoreMaster ";
            frmSearchTransaction.s_Columns = " tbl_scsStockAdjustment.stockAdjustment_ID [Stock Adjs Code], tbl_genStoreMaster.storeName [Store Name], tbl_scsStockAdjustment.stockAdjustmentDate [Stock Adjs Date], tbl_scsStockAdjustment.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 110, 200, 100, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsStockAdjustment.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsStockAdjustment.stockAdjustment_ID != 'default' AND tbl_scsStockAdjustment.store_ID = tbl_genStoreMaster.store_ID";
            if (!ShowSettled)
            {
                sCondition += " AND tbl_scsStockAdjustment.isDeleted = 'false'";
            }

            //else
            //   sCondition += " AND tbl_scsStockAdjustment.isDeleted = 'true'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " order by tbl_scsStockAdjustment.stockAdjustmentDate desc";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Stock Add
        public static void Search_TransactionStockAdd(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = "tbl_scsStockAdd";
            frmSearchMaster.s_Columns = " stockAdd_ID [StockAdd Code], stockAddDate [stockAdd Date] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 130, 220 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchMaster.s_Criteria = "stockAdd_ID != 'default' and tbl_scsStockAdd.isDeleted = 'false'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Purchase Order
        public static void Search_TransactionPurchaseOrder_Direct(ref TextBox txtBox, bool ShowSettled, string sNoteType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseOrder, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " purchaseOrder_ID [PO Code], supplierName [Supplier Name], tbl_scsPurchaseOrder.grandTotal [Total Amount], purchaseOrderDate [PO Date], tbl_scsPurchaseOrder.isDeleted [Canceled]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 150, 90, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsPurchaseOrder.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsPurchaseOrder.purchaseOrder_ID != 'default' AND tbl_scsPurchaseOrder.supplier_ID  = tbl_genSupplierMaster.supplier_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_scsPurchaseOrder.isSeattled='false' AND tbl_scsPurchaseOrder.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.isFinished = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.stockNoteType_ID =  '" + sNoteType + "'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPurchaseOrder_Use(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseOrder, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " purchaseOrder_ID [PO Code], supplierName [Supplier Name], tbl_scsPurchaseOrder.grandTotal [Total Amount], purchaseOrderDate [PO Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 210, 90, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_scsPurchaseOrder.purchaseOrder_ID != 'default' AND tbl_scsPurchaseOrder.supplier_ID  = tbl_genSupplierMaster.supplier_ID AND tbl_scsPurchaseOrder.companyBranch_ID ='" + clsSecurity.BranchID + "' ";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.isSeattled='false' AND tbl_scsPurchaseOrder.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionPurchaseOrder_UseBySupplierID(ref TextBox txtBox, string sSupplier_ID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseOrder, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " purchaseOrder_ID [PO Code], supplierName [Supplier Name], tbl_scsPurchaseOrder.grandTotal [Total Amount], purchaseOrderDate [PO Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 210, 90, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_scsPurchaseOrder.purchaseOrder_ID != 'default' AND tbl_scsPurchaseOrder.supplier_ID  = tbl_genSupplierMaster.supplier_ID AND  tbl_scsPurchaseOrder.supplier_ID = '" + sSupplier_ID + "'";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.isSeattled='false' AND tbl_scsPurchaseOrder.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseOrder.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region StoreProduction
        public static void SearchStoreProduction()
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_scsStoreProduction ";
            frmSearchMaster.s_Columns = " storeProduction_ID [Product Code], storeProductionDate [Product Date]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue };

            frmSearchMaster.s_Criteria = "";
        }
        #endregion

        #region Transaction Store Production
        public static void Search_TransactionStoreProduction(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsStoreProduction, tbl_genStoreMaster";
            frmSearchTransaction.s_Columns = " storeProduction_ID [Production Code], tbl_genStoreMaster.storeName [Store Name], tbl_scsStoreProduction.remark Remark, storeProductionDate [Pro Date], tbl_scsStoreProduction.isDeleted [Canceled]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 100, 120, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };


            frmSearchTransaction.s_Criteria += " tbl_scsStoreProduction.companyBranch_ID = '" + clsSecurity.BranchID + "' AND storeProduction_ID != 'default'  AND tbl_scsStoreProduction.store_ID  = tbl_genStoreMaster.store_ID";

            if (!ShowSettled)
                frmSearchTransaction.s_Criteria += " AND  tbl_scsStoreProduction.isDeleted = 'false'";

            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Search Discarded Good Note
        public static void Search_TransactionDiscardedDoodNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsDiscardedGoodNote ,tbl_genStoreMaster ";
            frmSearchTransaction.s_Columns = " discardedGoodNote_ID [DGN Code], storeName [Store Name], discardedGoodNoteDate [DGN Date], remark Remarks, tbl_scsDiscardedGoodNote.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsDiscardedGoodNote.companyBranch_ID = '" + clsSecurity.BranchID + "' AND tbl_scsDiscardedGoodNote.discardedGoodNote_ID != 'default' AND tbl_scsDiscardedGoodNote.store_ID= tbl_genStoreMaster.store_ID ";
            if (!ShowSettled)
                sCondition += " AND tbl_scsDiscardedGoodNote.isSeattled = 'false' AND tbl_scsDiscardedGoodNote.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction Purchase Return Note
        public static void Search_TransactionPurchaseReturnNote_Direct(ref TextBox txtBoxPRN, string sSupplierID, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseReturnedNote, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " purchaseReturnedNote_ID [PRN Code], supplierName [Supplier Name], purchaseReturnedNoteDate [PRN Date], grandTotal Amount,(grandTotal-seattleAmount) [Unsettled Amount], tbl_scsPurchaseReturnedNote.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 130, 80, 40, 40, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsPurchaseReturnedNote.companyBranch_ID = '" + clsSecurity.BranchID + "' AND tbl_scsPurchaseReturnedNote.purchaseReturnedNote_ID != 'default' AND tbl_genSupplierMaster.supplier_ID = tbl_scsPurchaseReturnedNote.supplier_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_scsPurchaseReturnedNote.isSeattled = 'false' AND tbl_scsPurchaseReturnedNote.isDeleted = 'false'";

            if (sSupplierID != "default" && sSupplierID != "" && sSupplierID != null)
                sCondition += " AND tbl_scsPurchaseReturnedNote.supplier_ID='" + sSupplierID + "'";

            frmSearchTransaction.s_Criteria = sCondition;

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBoxPRN.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBoxPRN.Tag = frmSearchTransaction.s_SearchID;
        }



        public static void Search_TransactionPurchaseReturnNote_Direct(ref TextBox txtBox, bool ShowSettled, string sNoteType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsPurchaseReturnedNote, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " purchaseReturnedNote_ID [PRN Code], supplierName [Supplier Name], purchaseReturnedNoteDate [PRN Date], grandTotal Amount, tbl_scsPurchaseReturnedNote.isDeleted [Canceled]  ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsPurchaseReturnedNote.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsPurchaseReturnedNote.purchaseReturnedNote_ID != 'default' AND tbl_genSupplierMaster.supplier_ID = tbl_scsPurchaseReturnedNote.supplier_ID";
            if (!ShowSettled)
                sCondition += " AND tbl_scsPurchaseReturnedNote.isSeattled = 'false' AND tbl_scsPurchaseReturnedNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsPurchaseReturnedNote.stockNoteType_ID =  '" + sNoteType + "'";

            frmSearchTransaction.s_Criteria = sCondition;

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Transaction External GoodReceived Note
        public static void Search_TransactionExternalGoodReceivedNote_DirectDAPL(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsExternalGoodReceivedNote, tbl_genSupplierMaster, tbl_zStockNoteType, tbl_zIssuedRefNo ";
            frmSearchTransaction.s_Columns = " externalGoodReceivedNote_ID [GRN Code], externalGoodReceivedNoteDate [GRN Date], tbl_zStockNoteType.stockNoteName [GRN Type], tbl_zIssuedRefNo.IssuedRefNo [Ref No] , (case when tbl_scsExternalGoodReceivedNote.[isDeleted]=1 then 'canceled' else (case when tbl_scsExternalGoodReceivedNote.[isApproved]=1 then 'Approved' else (case when tbl_scsExternalGoodReceivedNote.[isChecked]=1 then 'Checked' else'new' end) end) end) [Status] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 100, 60, 60 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsExternalGoodReceivedNote.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsExternalGoodReceivedNote.externalGoodReceivedNote_ID != 'default' AND tbl_genSupplierMaster.supplier_ID = tbl_scsExternalGoodReceivedNote.supplier_ID AND tbl_zStockNoteType.stockNoteType_ID = tbl_scsExternalGoodReceivedNote.stockNoteType_ID AND tbl_zIssuedRefNo.IssuedRefNo_ID = tbl_scsExternalGoodReceivedNote.IssuedRefNo_ID ";
            if (!ShowSettled)
                sCondition += " AND tbl_scsExternalGoodReceivedNote.isSeattled = 'false' AND tbl_scsExternalGoodReceivedNote.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionExternalGoodReceivedNote_DirectDAPL(ref TextBox txtBox, bool ShowSettled, string sNoteType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsExternalGoodReceivedNote, tbl_genSupplierMaster,tbl_zStockNoteType, tbl_zIssuedRefNo";
            frmSearchTransaction.s_Columns = " externalGoodReceivedNote_ID [GRN Code], externalGoodReceivedNoteDate [GRN Date], tbl_zStockNoteType.stockNoteName [GRN Type], tbl_zIssuedRefNo.IssuedRefNo [Ref No], (case when tbl_scsExternalGoodReceivedNote.[isDeleted]=1 then 'canceled' else (case when tbl_scsExternalGoodReceivedNote.[isApproved]=1 then 'Approved' else (case when tbl_scsExternalGoodReceivedNote.[isChecked]=1 then 'Checked' else'new' end) end) end) [Status] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 100, 60, 60 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "tbl_scsExternalGoodReceivedNote.companyBranch_ID ='" + clsSecurity.BranchID + "' AND tbl_scsExternalGoodReceivedNote.externalGoodReceivedNote_ID != 'default' AND tbl_genSupplierMaster.supplier_ID = tbl_scsExternalGoodReceivedNote.supplier_ID AND tbl_zStockNoteType.stockNoteType_ID = tbl_scsExternalGoodReceivedNote.stockNoteType_ID AND tbl_zIssuedRefNo.IssuedRefNo_ID = tbl_scsExternalGoodReceivedNote.IssuedRefNo_ID ";
            if (!ShowSettled)
                sCondition += " AND tbl_scsExternalGoodReceivedNote.isSeattled = 'false' AND tbl_scsExternalGoodReceivedNote.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_scsExternalGoodReceivedNote.stockNoteType_ID =  '" + sNoteType + "'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }


        public static void Search_TransactionExternalGoodReceivedNote_Use(ref TextBox txtBox, bool hasIssuedRefNo, string sIssuedRefNo)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsExternalGoodReceivedNote, tbl_genSupplierMaster";
            frmSearchTransaction.s_Columns = " externalGoodReceivedNote_ID [GRN Code], supplierName [Supplier Name], externalGoodReceivedNoteDate [GRN Date], grandTotal Amount";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_scsExternalGoodReceivedNote.externalGoodReceivedNote_ID != 'default' AND tbl_scsExternalGoodReceivedNote.isDeleted = 'false' AND tbl_genSupplierMaster.supplier_ID = tbl_scsExternalGoodReceivedNote.supplier_ID";
            if (hasIssuedRefNo)
                sCondition += " AND tbl_scsExternalGoodReceivedNote.IssuedRefNo_ID = '" + sIssuedRefNo + "'";

            frmSearchTransaction.s_Criteria = sCondition;

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Search Loan In
        public static void Search_TransactionLoanIn_Direct(ref TextBox txtBox, bool ShowSettled, bool isSecondDocument)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsLoanIn ";
            frmSearchTransaction.s_Columns = " loanIn_ID [LoanIn Code], ReceiverName [Issuer Name], loanInDate [LoanIn Date], remark Remarks, tbl_scsLoanIn.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsLoanIn.loanIn_ID != 'default'";
            if (isSecondDocument)
                sCondition += "AND tbl_scsLoanIn.isFirstDocument = 'true'";
            if (!ShowSettled)
                sCondition += " AND tbl_scsLoanIn.isSeattled = 'false' AND tbl_scsLoanIn.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Search Loan Out
        public static void Search_TransactionLoanOut_Direct(ref TextBox txtBox, bool ShowSettled, bool isSecondDocument)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_scsLoanOut ";
            frmSearchTransaction.s_Columns = " loanOut_ID [LoanOut Code], ReceiverName [Receiver Name], loanOutDate [LoanOut Date], remark Remarks, tbl_scsLoanOut.isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_scsLoanOut.loanOut_ID != 'default' ";
            if (isSecondDocument)
                sCondition += "AND tbl_scsLoanOut.isFirstDocument='true'";
            if (!ShowSettled)
                sCondition += " AND tbl_scsLoanOut.isSeattled = 'false' AND tbl_scsLoanOut.isDeleted = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        //Supplier
        #region Supplier Dont Use
        public static void Search_DontUse_MasterSupplier(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_genSupplierMaster";
            frmSearchMaster.s_Columns = " supplier_ID [Creditor Code], supplierName [Creditor Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "supplier_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Supplier Old
        //public static void Search_MasterSupplier(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    //clsSearch.passValue_Section();
        //    frmSearchMaster.s_TableName = "tbl_genSupplierMaster";
        //    frmSearchMaster.s_Columns = " supplier_ID [Supplier Code], supplierName [Supplier Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "supplier_ID != 'default' AND companyBranch_ID ='" + clsSecurity.BranchID + "' ";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}
        //public static void Search_MasterSupplier(ref TextBox txtBox, ref TextBox txtBox2)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    //clsSearch.passValue_Section();
        //    frmSearchMaster.s_TableName = "tbl_genSupplierMaster";
        //    frmSearchMaster.s_Columns = " supplier_ID [Supplier Code], supplierName [Supplier Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "supplier_ID != 'default'";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox2.Text = frmSearchMaster.s_SearchID;
        //}

        #endregion

        //customer 
        #region Master Customer
        public static void Search_Customer(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genCustomerMaster ";
            frmSearchMaster.s_Columns = " customer_ID [Cus Code], customerName [Customer Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "customer_ID != 'default' AND isDeleted = 'false'";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master Route
        //public static void Search_MasterRoute(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    //clsSearch.passValue_Section();
        //    frmSearchMaster.s_TableName = "tbl_genRouteMaster";
        //    frmSearchMaster.s_Columns = " route_ID [Route ID], routeName [Route Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "route_ID != 'default'";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}
        #endregion

        #region Master Town
        public static void Search_MasterTown(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_zTown";
            frmSearchMaster.s_Columns = " town_ID [Town Code], townName [Town Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "town_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Town
        public static void Search_TransactionTown(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_zCity, tbl_zDistrict, tbl_zTown";
            frmSearchTransaction.s_Columns = " tbl_zTown.town_ID [Town ID], tbl_zTown.townName [Town Name], tbl_zCity.cityName [City Name], tbl_zDistrict.districtName [District Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 180, 100, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = "tbl_zCity.district_ID = tbl_zDistrict.district_ID AND tbl_zCity.city_ID = tbl_zTown.city_ID";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region  Search Contact Person
        public static void Search_MasterContactPersonByCustomerID(ref TextBox txtBox, string sCustomerID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_genCustomerAddressBook ";
            frmSearchMaster.s_Columns = " line_No [No], contactName [Contact Name], email [Email Address] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 25, 175, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "contactName != 'default' and customer_ID = '" + sCustomerID + "'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Master Schedule
        public static void Search_MasterSchedule(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_zSchedule";
            frmSearchMaster.s_Columns = " schedule_ID schedule_ID, scheduleName scheduleName ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "schedule_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }






        #endregion

        #region Route
        public static void passValue_Route()
        {
            //passing values
            frmSearchMaster.s_TableName = "tbl_genRouteMaster";
            frmSearchMaster.s_Columns = " route_ID [Route Code], routeName [Route Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "route_ID != 'default'";
        }
        #endregion

        #region Customer Branch
        //public static void passValue_CustomerBranch(string sCustomerID)
        //{
        //    //passing values
        //    frmSearchMaster.s_TableName = "tbl_genCustomerMaster_Branches";
        //    frmSearchMaster.s_Columns = " line_No [Branch Code], branchName [Branch Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "customer_ID = '" + sCustomerID + "'";
        //}
        #endregion



        //Reports

        #region Master Reports
        public static void Search_MasterReports(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = "tbl_securityReportMaster";
            frmSearchMaster.s_Columns = " report_ID [Report Code], reportName [Report Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Transaction Reports
        public static void Search_TransactionReports(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();

            frmSearchTransaction.s_TableName = " tbl_securityReportMaster, tbl_zReportCategory";
            frmSearchTransaction.s_Columns = " report_ID [Report ID], reportName [Report Name], reportCategoryName [Report Category Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 200, 200 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchTransaction.s_Criteria = "report_ID != 0";

            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Report Category
        public static void Search_MasterReportCategory(ref TextBox txtBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zReportCategory ";
            frmSearchMaster.s_Columns = " reportCategory_ID [Cat. Code], reportCategoryName [Category Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportCategory_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Printer
        public static void passValue_PrinterID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_zPrinterMaster ";
            frmSearchMaster.s_Columns = " Printer_ID [printer Code], PrinterName [Printer Name],PrinterPort [Printer Port]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 130, 100 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "Printer_ID != 'default'";
        }
        #endregion



        //Security

        #region SecurityConfigType_Status
        public static void Search_MasterSecurityConfigType_Status(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityConfigType_Status ";
            frmSearchMaster.s_Columns = " configTypeStatus_ID [ConfigStatus Code], configTypeStatus [Config Status] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "configTypeStatus_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;


        }
        #endregion

        #region SecurityConfigStatus
        public static void Search_MasterSecurityConfigStatus(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityConfigStatus ";
            frmSearchMaster.s_Columns = " valueID [Value Code], valueName [Value Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;


        }
        #endregion

        #region SecurityConfigType_Value
        public static void Search_MasterSecurityConfig_Value(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityConfigValue ";
            frmSearchMaster.s_Columns = " valueID [value Code],valueName [Value Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region SecurityConfig_Value
        public static void Search_MasterSecurityConfigType_Value(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityConfigType_Value ";
            frmSearchMaster.s_Columns = " configTypeValue_ID [TypeValue Code], configTypeValue [Type Value]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "configTypeValue_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region SecuritySoftwareModel
        public static void SecuritySoftwareModel()
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securitySoftwareModel ";
            frmSearchMaster.s_Columns = " softwareModel_ID [Model Code], softwareModelName [Model Name]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";
        }
        #endregion

        #region SecurityProjects
        public static void SecurityProjects()
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityProject ";
            frmSearchMaster.s_Columns = " projectID [Project ID], projectName [Project Name]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";

        }
        #endregion

        #region SecurityTerminal
        public static void SecurityTerminal()
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityTerminalMaster ";
            frmSearchMaster.s_Columns = " terminal_ID [Terminal Code], terminal_Name [Terminal Name]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";
        }
        #endregion

        #region SecurityItemExceedLock
        public static void SecurityItemExceedLock()
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_securityItemExceedLock ";
            frmSearchMaster.s_Columns = " valueID [value Code], valueName [Value Name]  ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "";
        }
        #endregion

        #region security Status
        public static void passValue_securityConfigValueID_Status()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityConfigStatus ";
            frmSearchMaster.s_Columns = " valueID [Value ID], valueName [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "valueID != '0'";// TO DO:
        }
        #endregion

        #region security Config Type
        public static void passValue_securityConfigValueID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityConfigType_Value ";
            frmSearchMaster.s_Columns = " configTypeValue_ID [Value Code], configTypeValue [Type Value] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "configTypeValue_ID != 'default'";
        }
        #endregion

        #region security Config Type
        public static void passValue_securityConfigStatusID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityConfigType_Status ";
            frmSearchMaster.s_Columns = " configTypeStatus_ID [Status Code], configTypeStatus [Type Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "configTypeStatus_ID != 'default'";
        }
        #endregion

        #region security Config Type
        public static void passValue_securityConfigValueID_Value()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_securityConfigValue ";
            frmSearchMaster.s_Columns = " valueID [Value ID], valueName [Value Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "valueID != '0'";
        }
        #endregion

        //Alert
        #region Alert Setting
        public static void Search_AlertSettingID(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_utlAlertSettings, tbl_utlAlert, tbl_securityUserMaster ";
            frmSearchMaster.s_Columns = " setting_ID [Setting No.], alertName [Alert Name], userName [User Name], personName [Person Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = " setting_ID != 'default' AND tbl_utlAlertSettings.alert_ID = tbl_utlAlert.alert_ID AND tbl_utlAlertSettings.user_ID = tbl_securityUserMaster.user_ID ";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Alerts
        public static void Search_Alert(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_utlAlert ";
            frmSearchMaster.s_Columns = " alert_ID [Alert ID], alertName [Alert Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "alert_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion



        #region User
        public static void Search_User(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityUserMaster ";
            frmSearchMaster.s_Columns = " user_ID [User ID], userName [User Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "user_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Gem
        public static void Search_TransactionMettal(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            frmSearchTransaction.s_TableName = " tbl_zGemMettle ";
            frmSearchTransaction.s_Columns = " MettleID [Mettle Code], Remarks [Shot Code], MettleName [Mettle Name] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 285 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "MettleID != 'default'";
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
            //if (true)
            //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY MettleID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionGem(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction(1);
            frmSearchTransaction.s_TableName = " tbl_zGemGem ";
            frmSearchTransaction.s_Columns = "  GemID [Gem Code], Remarks [Shot Code], GemName [Gem Name] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 285 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "GemID != 'default'";
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
            //if (true)
            //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY GemID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        #region Design Pattern
        public static void Search_TransactionDesignPettern_DirectByItemClass(ref TextBox txtBox, string sItemClass, ref DataTable dt_Search)
        {
            Form frmhelpsearch = new frmSearchTransaction(1, ref dt_Search);
            frmSearchTransaction.s_TableName = " tbl_genItemMaster_Gem ";
            frmSearchTransaction.s_Columns = " item_ID [Design Code], refNo [Ref No], description [Description]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 50, 50, 100, 285 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchTransaction.bActiveChequeBox = true;

            string sCondition = "isDeleted = 'false'";
            if (sItemClass.Length > 0)
                sCondition += " AND itemClass_ID = '" + sItemClass + "'";
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
            //if (true)
            //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY item_ID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
            frmSearchTransaction.bActiveChequeBox = false;
        }
        //public static void Search_TransactionDesignPettern_Direct(ref TextBox txtBox)
        //{ //frmSearchTransaction_DAPL for picture-frmSearchTransaction
        //    Form frmhelpsearch = new frmSearchTransaction_DAPL(1);
        //    frmSearchTransaction_DAPL.s_TableName = " tbl_genItemMaster_Gem ";
        //    frmSearchTransaction_DAPL.s_Columns = " item_ID [Design Code], refNo [Ref No], description [Description]";
        //    frmSearchTransaction_DAPL.i_ColumnWidth = new int[] { 100, 100, 265 };
        //    frmSearchTransaction_DAPL.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    string sCondition = "isDeleted = 'false'";
        //    //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
        //    //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
        //    //if (true)
        //    //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
        //    frmSearchTransaction_DAPL.s_Criteria = sCondition;
        //    frmSearchTransaction_DAPL.s_Order = "ORDER BY item_ID DESC";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction_DAPL.s_SearchID.Length > 0)
        //        txtBox.Text = frmSearchTransaction_DAPL.s_SearchID;
        //    if (frmSearchTransaction_DAPL.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction_DAPL.s_SearchID;
        //}
        public static void Search_TransactionDesignPettern_Direct(ref TextBox txtBox, ref DataTable dt_Search)
        {
            Form frmhelpsearch = new frmSearchTransaction(1, ref dt_Search);
            frmSearchTransaction.s_TableName = " tbl_genItemMaster_Gem ";
            frmSearchTransaction.s_Columns = " item_ID [Design Code], refNo [Ref No], description [Description]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 20, 100, 100, 265 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchTransaction.bActiveChequeBox = true;

            string sCondition = "isDeleted = 'false'";
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
            //if (true)
            //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY item_ID DESC";

            frmhelpsearch.ShowDialog();
            if (!frmSearchTransaction.bActiveChequeBox)
            {
                if (frmSearchTransaction.s_SearchID.Length > 0)
                    txtBox.Text = frmSearchTransaction.s_SearchID;
                if (frmSearchTransaction.s_SearchID.Length > 0)
                    txtBox.Tag = frmSearchTransaction.s_SearchID;
            }
            else
                dt_Search = frmSearchTransaction.dt_RefSearch;
            frmSearchTransaction.bActiveChequeBox = false;
        }
        //public static void Search_TransactionDesignPettern_ByItemTypeID_OrCategoryID(ref TextBox txtBox, string sItemTypeID, string sItemCategoryID)
        //{
        //    //frmSearchTransaction_DAPL for picture -frmSearchTransaction
        //    Form frmhelpsearch = new frmSearchTransaction_DAPL(1);
        //    frmSearchTransaction_DAPL.s_TableName = " tbl_genItemMaster_Gem ";
        //    frmSearchTransaction_DAPL.s_Columns = " item_ID [Design Code], refNo [Ref No], description [Description]";
        //    frmSearchTransaction_DAPL.i_ColumnWidth = new int[] { 100, 100, 285 };
        //    frmSearchTransaction_DAPL.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    string sCondition = "isDeleted = 'false'";
        //    if (sItemTypeID.Length > 0)
        //        sCondition += " AND itemType_ID = '" + sItemTypeID + "'";
        //    if (sItemCategoryID.Length > 0)
        //        sCondition += " AND itemCategory_ID = '" + sItemCategoryID + "'";
        //    frmSearchTransaction_DAPL.s_Criteria = sCondition;
        //    frmSearchTransaction_DAPL.s_Order = "ORDER BY item_ID DESC";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction_DAPL.s_SearchID.Length > 0)
        //        txtBox.Text = frmSearchTransaction_DAPL.s_SearchID;
        //    if (frmSearchTransaction_DAPL.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction_DAPL.s_SearchID;
        //}
        public static void Search_TransactionDesignPettern_Use(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_genItemMaster_Gem ";
            frmSearchTransaction.s_Columns = " item_ID [Design Code], refNo [Ref No], description [Description]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 285 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            string sCondition = "isDeleted = 'false'";
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    sCondition += " AND tbl_sasInvoice.isSeattled = 'false' AND tbl_sasInvoice.isDeleted = 'false'";
            //if (true)
            //    sCondition += " AND tbl_sasInvoice.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY item_ID DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchText.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion
        #endregion


       



        #region Year
        public static void Search_Year(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zYear ";
            frmSearchMaster.s_Columns = " yearNumber [Year Number], yearName [Year Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "yearName != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region Month
        public static void Search_Month(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zMonth ";
            frmSearchMaster.s_Columns = " monthNumber [Month Number], monthName [Month Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.s_Criteria = "monthName != 'default'";
            frmSearchMaster.s_Order = "ORDER BY monthNumber ASC";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion

        #region GL Master
        //public static void Search_MasterAccountType(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_zAccGLMaster_AccountType ";
        //    frmSearchMaster.s_Columns = " glAccountType_ID [Account Type Code], glAccountTypeName [Account Type Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "glAccountType_ID != 'default'";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}

        //public static void Search_MasterAccountGLCode_ForreportBuilder(TextBox txtBox, String report_ID)//used in report item settings only
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster ";
        //    frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.s_Criteria = "gl_ID != 'default' AND " + " gl_ID not in (select dbo.tbl_rbInsReportItem_Settings.gl_ID from dbo.tbl_rbInsReportItem_Settings) ";

        //    frmSearchMaster.b_IsStordProceder = false;

        //    //if (ShowBankAccountOnly)
        //    // frmSearchMaster.s_Criteria = report_ID;

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}
        //public static void Search_MasterAccountGLCodeByAccountType(ref TextBox txtBox, string sAccountType)//used in double entry slot only
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster, tbl_zAccGLMaster_AccountType ";
        //    frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "gl_ID != 'default' and tbl_zAccGLMaster_AccountType.glAccountType_ID = tbl_accGLMaster.glAccountType_ID";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //}

        //public static void passValue_AcctCodeNoArg(DataGridView dgv, string columName, int rowId)//did not used in anyforms
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster ";
        //    frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "gl_ID != 'default'";

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //    {
        //        dgv[columName, rowId].Tag = frmSearchMaster.s_SearchID;
        //    }
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //    {
        //        dgv[columName, rowId].Value = frmSearchMaster.s_SearchText;
        //    }
        //}
        //public static void passValue_AcctCodeNoArg(TextBox txtBox)//did not used in anyforms
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster ";
        //    frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //    {
        //        txtBox.Tag = frmSearchMaster.s_SearchID;
        //    }

        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //    {
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    }
        //}
        //public static void passValue_AcctCode(TextBox txtBox, string sClass)//did not used in anyforms
        //{
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster ";
        //    frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = "gl_ID != 'default' AND glAccountType_ID='" + sClass + "'";

        //    frmhelpsearch.ShowDialog();

        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //    {
        //        txtBox.Text = frmSearchMaster.s_SearchID;
        //    }
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //    {
        //        txtBox.Text = frmSearchMaster.s_SearchText;
        //    }
        //}
        //public static void Search_MasterAccountGLCode_WithNameTextBox(ref TextBox TextBox, ref TextBox TextBoxName) //used in set gl code only
        //{
        //    //passing values
        //    Form frmhelpsearch = new frmSearchMaster();
        //    frmSearchMaster.s_TableName = " tbl_accGLMaster ";
        //    frmSearchMaster.s_Columns = " gl_ID [GL Code], glName [GL Name] ";
        //    frmSearchMaster.i_ColumnWidth = new int[] { 80, 255 };
        //    frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

        //    frmSearchMaster.s_Criteria = " isActive = 'true' AND gl_ID != 'default' ";
        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchMaster.s_SearchID.Length > 0)
        //        TextBox.Text = frmSearchMaster.s_SearchID;
        //    if (frmSearchMaster.s_SearchText.Length > 0)
        //        TextBoxName.Text = frmSearchMaster.s_SearchText;
        //}

        #endregion

        #region Report Bilder
        public static void passValue_ReportID(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbReportMaster ";
            frmSearchMaster.s_Columns = " report_ID [Report No.], reportName [Report Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_ReportID(TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbReportMaster ";
            frmSearchMaster.s_Columns = " report_ID [Report No.], reportName [Report Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_ReportItemLevel1(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbReportItem_Level_1 ";
            frmSearchMaster.s_Columns = " reportItem_level1_ID [Item Level-1 No.], reportItem_level1Name [Item Level-1 Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_level1_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_ReportItemLevel2(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbReportItem_Level_2 ";
            frmSearchMaster.s_Columns = " reportItem_level2_ID [Item Level-2 No.], reportItem_level2Name [Item Level-2 Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_level2_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void Search_MasterReportItem(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbReportItem ";
            frmSearchMaster.s_Columns = " reportItem_ID [Item ID], reportItemName [Report Item Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Report Income Statement Bilder
        public static void passValue_InsReportID(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportMaster ";
            frmSearchMaster.s_Columns = " report_ID [Report No.], reportName [Report Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_InsReportID(TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportMaster ";
            frmSearchMaster.s_Columns = " report_ID [Report No.], reportName [Report Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_InsReportItemLevel1(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportItem_Level_1 ";
            frmSearchMaster.s_Columns = " reportItem_level1_ID [Item Level-1 No.], reportItem_level1Name [Item Level-1 Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_level1_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }

        public static void passValue_InsReportItemLevel1(TextBox txtBox, TextBox nameTextBox, int lineNumber)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportItem_Level_1 ";
            frmSearchMaster.s_Columns = " reportItem_level1_ID [Item Level-1 No.], reportItem_level1Name [Item Level-1 Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_level1_ID != 'default' AND  line_No < " + lineNumber + " ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_InsReportItemLevel2(TextBox txtBox, TextBox nameTextBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportItem_Level_2 ";
            frmSearchMaster.s_Columns = " reportItem_level2_ID [Item Level-2 No.], reportItem_level2Name [Item Level-2 Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_level2_ID != 'default' ";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                nameTextBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void Search_MasterInsReportItem(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_rbInsReportItem ";
            frmSearchMaster.s_Columns = " reportItem_ID [Item ID], reportItemName [Report Item Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "reportItem_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Sub Category
        public static void passValue_SubledgerSubGLCodeByGlMainCatagoryCode(TextBox SubGlCode, TextBox subGLName, string Code, bool isBudgetForm)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccGLMaster_SubCatagory ";
            frmSearchMaster.s_Columns = " glSubCatagory_ID [SubCatagory Code], glSubCatagoryName [SubCatagory Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glSubCatagory_ID != 'default' AND glMainCatagory_ID='" + Code + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                SubGlCode.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0 && !isBudgetForm)
            {
                SubGlCode.Text = frmSearchMaster.s_SearchID;
                subGLName.Text = frmSearchMaster.s_SearchText;
            }

            if (isBudgetForm)
            {
                SubGlCode.Tag = frmSearchMaster.s_SearchID;
                SubGlCode.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_SubledgerSubGLCode(TextBox SubGlCode, TextBox subGLName, bool isBudgetForm)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccGLMaster_SubCatagory ";
            frmSearchMaster.s_Columns = " glSubCatagory_ID [Sub General Ledger Code], glSubCatagoryName [Sub General Ledger Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glSubCatagory_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0 && !isBudgetForm)
            {
                SubGlCode.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0 && !isBudgetForm)
            {
                SubGlCode.Text = frmSearchMaster.s_SearchID;
                subGLName.Text = frmSearchMaster.s_SearchText;
            }
            if (isBudgetForm)
            {
                SubGlCode.Tag = frmSearchMaster.s_SearchID;
                SubGlCode.Text = frmSearchMaster.s_SearchText;
            }
        }
        public static void passValue_SubledgerSubGLCode(TextBox SubGlCode, string Code)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccGLMaster_SubCatagory ";
            frmSearchMaster.s_Columns = " glSubCatagory_ID [SubCatagory Code], glSubCatagoryName [SubCatagory Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glSubCatagory_ID != 'default' AND glMainCatagory_ID='" + Code + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                SubGlCode.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                SubGlCode.Text = frmSearchMaster.s_SearchID;
            }
        }
        public static void passValue_SubledgerSubGLCodeNoArg(TextBox txtBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccGLMaster_SubCatagory ";
            frmSearchMaster.s_Columns = " glSubCatagory_ID [Account Code], glSubCatagoryName [Account Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glSubCatagory_ID != 'default'";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Tag = frmSearchMaster.s_SearchID;
            }

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        #endregion

        #region Account Type
        public static void passValue_AcctType(TextBox txtAcctTypeCode, TextBox txtAccountName, string sSubGLCode)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccGLMaster_AccountType ";
            frmSearchMaster.s_Columns = " glAccountType_ID [AccountType Code], glAccountTypeName [AccountType Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glAccountType_ID != 'default' AND glSubCatagory_ID='" + sSubGLCode + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtAcctTypeCode.Tag = frmSearchMaster.s_SearchID;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {

                txtAcctTypeCode.Text = frmSearchMaster.s_SearchID;
                txtAccountName.Text = frmSearchMaster.s_SearchText;
            }
        }

        public static void passValue_AcctTypeToAcctCode(TextBox txtAcctCode, string sAcctType)
        {
            // Edit for 2012-06-12
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_accGLMaster ";
            frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "gl_ID != 'default' AND tbl_accGLMaster.glAccountType_ID='" + sAcctType + "'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtAcctCode.Tag = frmSearchMaster.s_SearchID;
            }
            //if (frmSearchMaster.s_SearchID.Length > 0)
            //{
            //    txtAcctCode.Text = frmSearchMaster.s_SearchID;
            //    txtAccountCodeName.Text = frmSearchMaster.s_SearchText;
            //}
        }
        public static void passValue_AccountID(TextBox txtBox)
        {
            #region Temp

            //passing values
            /*    Form frmhelpsearch = new frmSearchMaster();
                frmSearchMaster.s_TableName = " tbl_zAccGLMaster_AccountType ";
                frmSearchMaster.s_Columns = " glAccountType_ID [Account Type], glAccountTypeName [Account Type]";
                frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
                frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

                frmSearchMaster.s_Criteria = "glAccountType_ID != 'default'";
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtBox.Tag = frmSearchMaster.s_SearchID;
                }

                if (frmSearchMaster.s_SearchText.Length > 0)
                {
                    txtBox.Text = frmSearchMaster.s_SearchText;
                } */
            #endregion

            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_accGLMaster ";
            frmSearchMaster.s_Columns = " gl_ID [Account Code], glName [Account Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "gl_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;


        }
        #endregion

        #region ReceiptVoucher AcctCode
        public static void passValue_ReceiptVoucher()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_accGLMaster";
            frmSearchMaster.s_Columns = " gl_ID [GL Code], glName [GL Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 80, 255 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "gl_ID != 'default' AND isDebit = 'true' AND isActive = 'true'";
        }
        public static void passValue_ReceiptCrAcctID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_accGLMaster ";
            frmSearchMaster.s_Columns = " gl_ID [GL Code], glName [GL Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 80, 255 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = "gl_ID != 'default' AND isCredit = 'true' AND isActive = 'true'";
        }
        public static void MultipleChequeAdvance(ref TextBox txtDrAmount, ref TextBox txtNoOfCheque, ref System.Data.DataTable dtAllRecodes)
        {
            //frmMultipleCheque frm = new frmMultipleCheque();
            //frm.ShowDialog();
            //if (frmMultipleCheque.glbDrAmount != null && frmMultipleCheque.glbDrAmount.Length > 0)
            //{
            //    txtDrAmount.Text = frmMultipleCheque.glbDrAmount;
            //    dtAllRecodes = frmMultipleCheque.dtRecodes;
            //}
            //if (frmMultipleCheque.glbiChqueCounnt.ToString() != null && frmMultipleCheque.glbiChqueCounnt.ToString().Length > 0)
            //    txtNoOfCheque.Text = frmMultipleCheque.glbiChqueCounnt.ToString();
        }
        #endregion

        #region Note Posting
        public static void passValue_PostingNote(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_accGLPosting ";
            frmSearchMaster.s_Columns = " glPosting_ID [glPosting_ID], remark [remark] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glPosting_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

        }
        #endregion

        #region Master Account Slot
        public static void Search_MasterAccountSlot(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();

            frmSearchMaster.s_TableName = "tbl_accDoubleEntrySlotMaster";
            //, tbl_zAccSlotCategory
            frmSearchMaster.s_Columns = " tbl_accDoubleEntrySlotMaster.slot_ID [Slot Code], tbl_accDoubleEntrySlotMaster.slotName [Slot Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 50, 300 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "tbl_accDoubleEntrySlotMaster.slot_ID != 0 AND tbl_accDoubleEntrySlotMaster.IsDelete = 0";
            //AND tbl_zAccSlotCategory.slotCategory_ID = tbl_accDoubleEntrySlotMaster.slotCategory_ID

            //frmSearchMaster.s_TableName = "tbl_accDoubleEntrySlotMaster, tbl_zAccSlotCategory";
            //frmSearchMaster.s_Columns = " tbl_accDoubleEntrySlotMaster.slot_ID [Slot Code], tbl_accDoubleEntrySlotMaster.slotName [Slot Name], tbl_zAccSlotCategory.slotCategoryName [Category Name]";
            //frmSearchMaster.i_ColumnWidth = new int[] { 50, 200, 100 };
            //frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            //frmSearchMaster.s_Criteria = "tbl_accDoubleEntrySlotMaster.slot_ID != 0 AND tbl_zAccSlotCategory.slotCategory_ID = tbl_accDoubleEntrySlotMaster.slotCategory_ID AND tbl_accDoubleEntrySlotMaster.IsDelete = 0";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }

        #endregion

        #region Transaction Journal Voucher
        public static void Search_TransactionJournalVoucher_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accJournalEntry";
            frmSearchTransaction.s_Columns = " journalEntry_ID [JV. NO], journalEntryDate [JV. Date], remark [Remarks], grandTotal [Grand Total]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 200, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            // frmSearchTransaction.s_Criteria = "journalEntry_ID != 'default'";

            string sCondition = "journalEntry_ID != 'default'";
            if (!ShowSettled)
                sCondition += " AND tbl_accJournalEntry.isSeattled = 'false' AND tbl_accJournalEntry.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_accJournalEntry.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        #endregion

        #region Search Payment Voucher
        public static void Search_TransactionPaymentVoucher_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accPaymentVoucher ";
            frmSearchTransaction.s_Columns = " paymentVoucher_ID [PV No], Payee [Payee], totalAmount [Total Amount], paymentVoucherDate [paymentVoucher Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_accPaymentVoucher.paymentVoucher_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " and tbl_accPaymentVoucher.isSeattled = 'false' AND tbl_accPaymentVoucher.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_accPaymentVoucher.isFinished = 'false'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY paymentVoucherDate DESC ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }

        public static void Search_TransactionPaymentVoucher_Direct_NonPosted(ref TextBox txtBox, bool ShowPostedOnly)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accPaymentVoucher ";
            frmSearchTransaction.s_Columns = " paymentVoucher_ID [PV No], Payee [Payee], totalAmount [Total Amount], paymentVoucherDate [paymentVoucher Date]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };

            string sCondition = " tbl_accPaymentVoucher.paymentVoucher_ID != 'default' ";
            if (!ShowPostedOnly)
                sCondition += " and tbl_accPaymentVoucher.postingStatus_ID = '" + clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted) + "'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY paymentVoucherDate DESC ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchText;
        }
        #endregion

        #region Account Cheque Register
        public static void Search_MasterChequeRegister_Accounts(TextBox txtBox)
        {
            string sCurrentDisplayCheque = "";
            if (txtBox.Tag != null && txtBox.Tag.ToString().Length > 0)
                sCurrentDisplayCheque = txtBox.Tag.ToString().Trim();
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_accChequeRegister ";
            frmSearchMaster.s_Columns = " chequeRegister_ID [Cheque Register No.], chequeNumber [Cheque Number] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 200, 50 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "chequeRegister_ID != 'default' and chequeRegister_ID != '" + sCurrentDisplayCheque + "' ";
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchID;
            }

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                txtBox.Text = frmSearchMaster.s_SearchText;
            }
        }
        #endregion

        #region Account Cheque Register

        public static void Search_AccMasterChequeNo(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.AccChequeNo);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[1];
                txtBox.Text = lstResult[0];
            }
        }

        #endregion

        #region Transaction Journal Voucher
        public static void Search_TransactionJournalVoucher_Direct(ref TextBox txtBox, bool ShowSettled, string sJournalType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accJournalEntry";
            frmSearchTransaction.s_Columns = " journalEntry_ID [JV. NO], journalEntryDate [JV. Date], remark [Remarks], grandTotal [Grand Total], isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 80, 140, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            // frmSearchTransaction.s_Criteria = "journalEntry_ID != 'default'";

            string sCondition = "journalEntry_ID != 'default'";
            sCondition += " AND tbl_accJournalEntry.journalEntryType_ID = '" + sJournalType + "' ";

            if (!ShowSettled)
                sCondition += " AND tbl_accJournalEntry.isSeattled = 'false' ";// AND tbl_accJournalEntry.isDeleted = 'false'
            if (true)
                sCondition += " AND tbl_accJournalEntry.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region Search Cost Enter
        public static void Search_MasterCostCenter(ref TextBox TextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCost_Center ";
            frmSearchMaster.s_Columns = " cost_Center_ID [Cost Center ID], cost_Center_Name [Cost Center Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 80, 280 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = " cost_Center_ID != 'default' ";
            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                TextBox.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                TextBox.Text = frmSearchMaster.s_SearchText;
        }

        #endregion

        #region GLNote
        public static void SearchMaster_GLNoteID(ref TextBox TextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();

            frmSearchMaster.s_TableName = " tbl_accGLMaster_Note ";
            frmSearchMaster.s_Columns = " glNote_ID [GL Note Code],  glNoteName [GL Note Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glNote_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                TextBox.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                TextBox.Text = frmSearchMaster.s_SearchText;
        }
        public static void SearchMaster_GLNoteID(ref TextBox TextBox, string glAcc)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();

            frmSearchMaster.s_TableName = " tbl_accGLMaster_Note ";
            frmSearchMaster.s_Columns = " glNote_ID [GL Note Code],  glNoteName [GL Note Name]";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "glNote_ID != 'default' AND glAccountType_ID ='" + glAcc + "'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                TextBox.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                TextBox.Text = frmSearchMaster.s_SearchText;
        }
        #endregion

        #region Search Account Receipt
        public static void Search_TansactionAccountReceipt(ref TextBox txtBox, bool ShowSettled)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_accAccountReceipt ";
            frmSearchTransaction.s_Columns = " accountReceipt_ID [AR No],receivedof[Received from] , totalAmount [total Amount], accountReceiptDate [Receipt Date], isDeleted [Canceled] ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 130, 100, 80, 40 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_accAccountReceipt.accountReceipt_ID != 'default' ";
            if (!ShowSettled)
                sCondition += " and tbl_accAccountReceipt.isSeattled = 'false' AND tbl_accAccountReceipt.isDeleted = 'false'";
            if (true)
                sCondition += " AND tbl_accAccountReceipt.isFinished = 'false'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = " ORDER BY accountReceipt_ID DESC ";
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }


        #endregion

        #region Search Receipt Voucher
        public static void Search_TansactionReceiptVoucher(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            //clsSearch.passValue_PrePlane();
            frmSearchTransaction.s_TableName = "tbl_accReceiptVoucher ";
            frmSearchTransaction.s_Columns = " receiptVoucher_ID [RV No], receiptVoucherDate [Receipt Date], cashAmount [Amount], remark [Remarks]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 180, 100, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.NumaricValue, enum_GridFormat.TextValue };

            string sCondition = " tbl_accReceiptVoucher.receiptVoucher_ID != 'default' ";
            frmSearchTransaction.s_Criteria = sCondition;
            frmhelpsearch.ShowDialog();

            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        #region costCenters
        public static void Search_costCenter1(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccCostCenter1 ";
            frmSearchMaster.s_Columns = " costCenter1_ID [Cost Center Code], costCenter1Name [Cost Center Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "costCenter1_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        public static void Search_costCenter2(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zAccCostCenter2 ";
            frmSearchMaster.s_Columns = " costCenter2_ID [Cost Center Code], costCenter2Name [Cost Center Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "costCenter2_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Account Type - Customer
        public static void Search_MasterAccountTypeCustomer(ref TextBox txtbox)
        {

            Form frmhelpsearch = new frmSearchMaster();

            frmSearchMaster.s_TableName = "tbl_accAccountsType_Customer";
            frmSearchMaster.s_Columns = " customerAccountType_ID [Acc Type ID],customerAccountTypeName [Acc Type Name],gl_ID[Gl No]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250, 100 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "customerAccountType_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtbox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtbox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Account Type - Supplier
        public static void Search_TransactionAccountTypeSupplier(ref TextBox txtbox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountsType_Supplier, tbl_accGLMaster ";
            frmSearchTransaction.s_Columns = " supplierAccountType_ID [Acc Type ID], supplierAccountTypeName [Acc Type Name], tbl_accGLMaster.gl_ID[Acc Code], tbl_accGLMaster.glName [Acc Name]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200, 80, 100 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            // frmSearchTransaction.s_Criteria = "journalEntry_ID != 'default'";

            string sCondition = "tbl_accAccountsType_Supplier.gl_ID = tbl_accGLMaster.gl_ID";

            frmSearchTransaction.s_Criteria = sCondition;
            //  frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtbox.Text = frmSearchTransaction.s_SearchText;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtbox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion

        //Gem
        #region APN Type
        //public static void Search_AccountPayableNoteType_Direct(ref TextBox txtBox)
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    frmSearchTransaction.s_TableName = "tbl_zAccAccountPaybleNoteType";
        //    frmSearchTransaction.s_Columns = "apnType_ID [APN Type ID],apnTypeName [APN type Name]";
        //    frmSearchTransaction.i_ColumnWidth = new int[] { 80, 200};
        //    frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue};

        //    string sCondition = "apnType_ID != 'default'";

        //    frmSearchTransaction.s_Criteria = sCondition;
        //    frmSearchTransaction.s_Order = "ORDER BY apnType_ID DESC";

        //    frmhelpsearch.ShowDialog();
        //    if (frmSearchTransaction.s_SearchText.Length > 0)
        //        txtBox.Text = frmSearchTransaction.s_SearchText;
        //    if (frmSearchTransaction.s_SearchID.Length > 0)
        //        txtBox.Tag = frmSearchTransaction.s_SearchID;
        //}
        #endregion

        #region Transaction Account Payable Note
        public static void Search_TransactionAccountPayableNote_Direct(ref TextBox txtBox, bool ShowSettled, string sSupplierID)
        {
            Form frmhelpsearch = new frmSearchTransactionAdvance();
            frmSearchTransactionAdvance.s_TableName = "tbl_accAccountPayableNote, tbl_genSupplierMaster";
            //frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO], accountPayableNoteDate [APN Date],(CASE WHEN isDeleted ='1' THEN 'Cancel' ELSE 'Active' END)  [Status], Narration [Narration], grandTotal [Grand Total] ,(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransactionAdvance.s_Columns = " tbl_accAccountPayableNote.AccountPayableNote_ID [APN NO], tbl_accAccountPayableNote.billDate [Bill Date], tbl_accAccountPayableNote.billNo [Bill No], tbl_genSupplierMaster.supplierName [Supplier], tbl_accAccountPayableNote.isDeleted [Canceled] , tbl_accAccountPayableNote.Narration [Narration], tbl_accAccountPayableNote.grandTotal [Grand Total] ,(tbl_accAccountPayableNote.grandTotal-tbl_accAccountPayableNote.SettledAmount) [Unsettled Amount]";
            frmSearchTransactionAdvance.i_ColumnWidth = new int[] { 35, 45, 70, 160, 40, 160, 60, 60 };
            frmSearchTransactionAdvance.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = "tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.supplier_ID = tbl_genSupplierMaster.supplier_ID ";

            if (!ShowSettled)
                sCondition += " and tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.supplier_ID = '" + sSupplierID + "'";
            if (true)
                sCondition += " AND tbl_accAccountPayableNote.isFinished = 'false'";

            frmSearchTransactionAdvance.s_Criteria = sCondition;
            frmSearchTransactionAdvance.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransactionAdvance.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransactionAdvance.s_SearchID;
            if (frmSearchTransactionAdvance.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransactionAdvance.s_SearchID;
        }


        public static void Search_TransactionAccountPayableNote_Viewer(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransactionAdvance();
            frmSearchTransactionAdvance.s_TableName = "tbl_accAccountPayableNote, tbl_genSupplierMaster";
            frmSearchTransactionAdvance.s_Columns = " tbl_accAccountPayableNote.AccountPayableNote_ID [APN NO], tbl_accAccountPayableNote.billDate [Bill Date], tbl_accAccountPayableNote.billNo [Bill No], tbl_genSupplierMaster.supplierName [Supplier], tbl_accAccountPayableNote.isDeleted [Canceled] , tbl_accAccountPayableNote.Narration [Narration], tbl_accAccountPayableNote.grandTotal [Grand Total] ,(tbl_accAccountPayableNote.grandTotal-tbl_accAccountPayableNote.SettledAmount) [Unsettled Amount]";
            frmSearchTransactionAdvance.i_ColumnWidth = new int[] { 68, 45, 70, 160, 24, 140, 60, 60 };
            frmSearchTransactionAdvance.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = "tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.supplier_ID = tbl_genSupplierMaster.supplier_ID ";

            frmSearchTransactionAdvance.s_Criteria = sCondition;
            frmSearchTransactionAdvance.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransactionAdvance.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransactionAdvance.s_SearchID;
            if (frmSearchTransactionAdvance.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransactionAdvance.s_SearchID;
        }
        public static void Search_TransactionAccountPayableNote(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accAccountPayableNote";
            frmSearchTransaction.s_Columns = " accountPayableNote_ID [APN No], accountPayableNoteDate [APN Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 60, 50, 70, 150, 80, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " isDeleted = 'false' AND isSeattled = 'false' AND AccountPayableNote_ID != 'default'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAccountPayableNote_All(ref TextBox txtBox, string sSupplierID, string sType)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = "tbl_accAccountPayableNote";
            frmSearchTransaction.s_Columns = "  AccountPayableNote_ID [APN NO], accountPayableNoteDate [APN Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 60, 50, 70, 150, 80, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " isSeattled = 'false' AND AccountPayableNote_ID != 'default'";

            if (sType == "sup")
                sCondition += " AND isSeattled = 'false' AND AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.supplier_ID = tbl_genSupplierMaster.supplier_ID AND tbl_accAccountPayableNote.supplier_ID = '" + sSupplierID + "'";

            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAPNByCustomerID_Use(ref TextBox txtBox, string sCustomerID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountPayableNote,tbl_genCustomerMaster ";
            frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO], billDate [Bill Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 70, 70, 150, 90, 90 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.customer_ID = tbl_genCustomerMaster.customer_ID AND tbl_accAccountPayableNote.customer_ID = '" + sCustomerID + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAPNBySupplierID_Use(ref TextBox txtBox, string sSupplierID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountPayableNote,tbl_genSupplierMaster ";
            frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO], accountPayableNoteDate [APN Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 60, 50, 70, 150, 80, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.supplier_ID = tbl_genSupplierMaster.supplier_ID AND tbl_accAccountPayableNote.supplier_ID = '" + sSupplierID + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAPNByEmployeeID_Use(ref TextBox txtBox, string sEmployeeID)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountPayableNote,tbl_genEmployeeMaster ";
            frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO], billDate [Bill Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 70, 70, 150, 90, 90 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.employee_ID = tbl_genEmployeeMaster.employee_ID AND tbl_accAccountPayableNote.employee_ID = '" + sEmployeeID + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAPNByCostCenter1_Use(ref TextBox txtBox, string sCostCenter1)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountPayableNote,tbl_accGLMaster_CostCenter1 ";
            frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO],billDate [Bill Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 70, 70, 150, 90, 90 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.costCenter1_ID = tbl_accGLMaster_CostCenter1.costCenter1_ID AND tbl_accAccountPayableNote.costCenter1_ID = '" + sCostCenter1 + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        public static void Search_TransactionAPNByCostCenter2_Use(ref TextBox txtBox, string sCostCenter2)
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_accAccountPayableNote,tbl_accGLMaster_CostCenter1 ";
            frmSearchTransaction.s_Columns = " AccountPayableNote_ID [APN NO],billDate [Bill Date], billNo [Bill No], Narration [Narration], grandTotal [Grand Total],(grandTotal-SettledAmount) [Unsettled Amount]";
            frmSearchTransaction.i_ColumnWidth = new int[] { 70, 70, 70, 150, 90, 90 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.NumaricValue };

            string sCondition = " tbl_accAccountPayableNote.isDeleted = 'false' AND tbl_accAccountPayableNote.isSeattled = 'false' AND tbl_accAccountPayableNote.AccountPayableNote_ID != 'default' AND tbl_accAccountPayableNote.costCenter2_ID = tbl_accGLMaster_CostCenter2.costCenter2_ID AND tbl_accAccountPayableNote.costCenter2_ID = '" + sCostCenter2 + "'";
            frmSearchTransaction.s_Criteria = sCondition;
            frmSearchTransaction.s_Order = "ORDER BY dateCreate DESC";

            frmhelpsearch.ShowDialog();
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Text = frmSearchTransaction.s_SearchID;
            if (frmSearchTransaction.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchTransaction.s_SearchID;
        }
        #endregion


        //Audit
        #region Audit Users
        public static void Search_MasterAuditUser(ref TextBox txtBox, string sUserID)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_audAudit_Users,tbl_audAuditMaster ";
            frmSearchMaster.s_Columns = " tbl_audAudit_Users.audit_ID [Audit Code], auditName [Audit Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = " tbl_audAudit_Users.audit_ID != 'default' AND  tbl_audAudit_Users.audit_ID=tbl_audAuditMaster.audit_ID AND tbl_audAudit_Users.user_ID='" + sUserID + "'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        // Canceled Resons
        #region Cancel Resons D/O
        public static void Search_MasterCancelResonDeliveryOrder(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            //clsSearch.passValue_Section();
            frmSearchMaster.s_TableName = " tbl_zCancelReson_DO";
            frmSearchMaster.s_Columns = " cancelReason_ID_DO [Reson Code], cancelReasonName [Reson Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = " cancelReason_ID_DO != 'default' ";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Debit Note
        public static void passValue_DebitNoteID()
        {
            Form frmhelpsearch = new frmSearchTransaction();
            frmSearchTransaction.s_TableName = " tbl_bpsDebitNote,tbl_genCustomerMaster";
            frmSearchTransaction.s_Columns = " debitNote_ID DebitNote_No,invoice_ID Invoice_No,tbl_genCustomerMaster.customerName Customer_Name,totalAmount Amount ";
            frmSearchTransaction.i_ColumnWidth = new int[] { 100, 100, 180, 80 };
            frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue };

            frmSearchTransaction.s_Criteria = " DebitNote_ID !='default' AND tbl_genCustomerMaster.customer_ID=tbl_bpsDebitNote.customer_ID";
        }

        public static void passValue_DebitNoteTypeID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zDebitNoteType";
            frmSearchMaster.s_Columns = " debitNoteType_ID DebitNoteType,DebitNoteTypeName DebitNoteTypeName";
            frmSearchMaster.i_ColumnWidth = new int[] { 120, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = " debitNoteType_ID !='default' AND debitNoteType_ID !='ITC/001'";
        }
        #endregion

        #region Process Note
        public static void passValue_ProcessMasterNoArg(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityProcessNoteMaster ";
            frmSearchMaster.s_Columns = " processNote_ID [ProcessNote Code], processNoteName [ProcessNote Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "processNote_ID != '0'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

            //  frmhelpsearch.ShowDialog();
        }
        #endregion

        #region Revers Posting

        #endregion

        // Report
        #region Printer Name
        public static void passValue_Printer(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPrinterMaster ";
            frmSearchMaster.s_Columns = " printer_ID [printer_ID], printerName [printerName] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "printer_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

            //  frmhelpsearch.ShowDialog();
        }
        #endregion

        #region Report name
        public static void passValue_ReportMaster(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityReportMaster ";
            frmSearchMaster.s_Columns = " report_ID [report_ID], reportName [reportName] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "report_ID != '0'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

            //  frmhelpsearch.ShowDialog();
        }
        #endregion

        #region Paper Size
        public static void passValue_paperSize(TextBox CodeTextBox)
        {
            //passing values
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zPaperMaster ";
            frmSearchMaster.s_Columns = " paper_ID [paper_ID], paperName [paperName] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "paper_ID != 'default'";

            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
            {
                CodeTextBox.Text = frmSearchMaster.s_SearchText;
            }
            if (frmSearchMaster.s_SearchID.Length > 0)
            {
                CodeTextBox.Tag = frmSearchMaster.s_SearchID;
            }

            //  frmhelpsearch.ShowDialog();
        }
        #endregion

        //UTL
        #region Alert
        public static void passValue_AlertID()
        {
            //passing values
            frmSearchMaster.s_TableName = " tbl_utlAlert ";
            frmSearchMaster.s_Columns = " alertID [Alert Code], AlertName [Alert Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "alertID != 0";
        }
        #endregion

        #region Purge
        public static void Search_MasterPurge(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_securityPurge ";
            frmSearchMaster.s_Columns = " purge_ID [Purge Code], purgeDate [Purge Date], remark [Remarks]";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 100, 150 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "purge_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        //Bills
        #region Credit Note Type
        public static void Search_MasterCreditNoteType_Direct(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zCreditNoteType";
            frmSearchMaster.s_Columns = " creditNoteType_ID [CRNType ID],creditNoteTypeName [CreditNoteType Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = " creditNoteType_ID !='default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Debit Note Type
        public static void Search_MasterDebitNoteType_Direct(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zDebitNoteType";
            frmSearchMaster.s_Columns = " debitNoteType_ID [DBNType ID],debitNoteTypeName [DebitNoteType Name] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };
            frmSearchMaster.s_Criteria = " debitNoteType_ID !='default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Cheque Type
        public static void Search_MasterChequeType(ref TextBox txtBox)
        {
            Form frmhelpsearch = new frmSearchMaster();
            frmSearchMaster.s_TableName = " tbl_zChequeType ";
            frmSearchMaster.s_Columns = " chequeType_ID [Type Code], typeName [Thushari] ";
            frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            frmSearchMaster.s_Criteria = "chequeType_ID != 'default'";

            frmhelpsearch.ShowDialog();
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtBox.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtBox.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #endregion



        /*
         * New Search Methods
         * 
         * */

        #region New Search

        #region Masters
        #region Form 
        public static void Search_Form(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Form);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Security Form Category
        public static void Search_SecurityFormCategory(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Form_Catagory);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }

            //Form frmhelpsearch = new frmSearchMaster();
            //frmSearchMaster.s_TableName = "tbl_securityFormCategory";
            //frmSearchMaster.s_Columns = " formCategory_ID [FormCategory Code], categoryName [category Name] ";
            //frmSearchMaster.i_ColumnWidth = new int[] { 100, 250 };
            //frmSearchMaster.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue };

            //frmSearchMaster.s_Criteria = "formCategory_ID != 'default'";
            //frmhelpsearch.ShowDialog();

            //if (frmSearchMaster.s_SearchText.Length > 0)
            //    txtBox.Text = frmSearchMaster.s_SearchText;
            //if (frmSearchMaster.s_SearchID.Length > 0)
            //    txtBox.Tag = frmSearchMaster.s_SearchID;

        }
        #endregion


        #region User Master
        public static void Search_MasterUsers(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
                        
            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Users);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Company Bank Account New
        public static void SearchMaster_CompanyAccount(ref TextBox txtBox, string bankID, string bankBranchID)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;
            lstParameeters.Add(bankID);
            lstParameeters.Add(bankBranchID);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[0];
            }
        }
        #endregion

        #region Company Branch
        public static void Search_CompanyBranch(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyBranch);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region  Search Bank
        public static void Search_Bank(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Banks);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[2];
            }
        }
        #endregion

        #region  Search Bank Branch
        public static void Search_BankBranch(ref TextBox txtBox, string bankID)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;
            lstParameeters.Add(bankID);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.BankBranch);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[2];
                txtBox.Text = lstResult[3];
            }
        }
        #endregion

        #region Division
        public static void Search_MasterDivision(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Route
        public static void Search_MasterRoute(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Route);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Customer New
        public static void Search_MasterCustomer(ref TextBox txtBox, bool bShowInActiveCustomers)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(clsSecurity.BranchID);

            if (bShowInActiveCustomers)
                lstParameeters.Add("");
            else
                lstParameeters.Add("0");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Customer);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        public static void Search_MasterCustomerID_New(ref string sCustomerID, bool bShowInActiveCustomers)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(clsSecurity.BranchID);

            if(bShowInActiveCustomers)
                lstParameeters.Add("");
            else
                lstParameeters.Add("0");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Customer);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                sCustomerID = lstResult[0];
            }
        }
        #endregion

        #region Font
        public static void Search_FontType(ref string sFontType_ID, ref string sFontName)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Font);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                sFontType_ID = lstResult[0];
                sFontName = lstResult[1];
            }
        }

        #endregion

        #region ChequeFormat
        public static void Search_ChequeFormat(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.zChequeFormat);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1] + " - " + lstResult[2];
            }
        }
        #endregion

        #region Cost Center 1
        public static void Search_Cost1(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.zCost_Centre1);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        #endregion
        #region Cost Center 2
        public static void Search_Cost2(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.zCost_Center2);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion
        #region Cost Center 3

        public static void Search_Cost3(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.zCost_Center3);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        #endregion
        #region Cost Center 4
        public static void Search_Cost4(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.zCost_Center4);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Customer Branch New
        public static void Search_CustomerBranch(ref TextBox txtBox, string sCustomerID)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sCustomerID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.CustomerBranches);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[2];
            }
        }
        #endregion

        #region Search Customer Bank Account
        public static void Search_TransactionCustomerBankAccount(ref TextBox txtBox, string sCustomerID)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sCustomerID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.CustomerAccounts);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[0];
            }
        }
        #endregion

        #region Supplier New
        public static void Search_MasterSupplier(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(clsSecurity.BranchID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Supplier);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Sales Rep New
        public static void Search_MasterSalesRep(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SalesRep);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Commission Period 
        public static void Search_MasterComissionPeriod(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Commission_Period);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Collecter New
        public static void Search_MasterCollector(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Collector);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Area Manager
        public static void Search_AreaManager(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AreaManger);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Area Manager
        public static void Search_SalesManager(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SalesManager);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion



        #region Sales Note Type
        public static void Search_MasterSalesNoteType(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SalesNoteType);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Currency new
        public static void Search_MasterCurrency(ref TextBox txtCurrency)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Currency);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtCurrency.Tag = lstResult[0];
                txtCurrency.Text = lstResult[1];
            }
        }
        #endregion

        #region Payment Method Master
        public static void Search_MasterPaymentMethod(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PaymentMethod);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Cheque Status New
        public static void ChequeStatus(ref string txtChequeStatus, ref string txtChequeStatusID)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ChequeStatus);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtChequeStatusID = lstResult[0];
                txtChequeStatus = lstResult[1];
            }
        }

        public static void ChequeStatus_Outward(ref string txtChequeStatus, ref string txtChequeStatusID)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ChequeStatus_2);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtChequeStatusID = lstResult[0];
                txtChequeStatus = lstResult[1];
            }
        }
        #endregion

        #region Item Master / Class / Type / Category / Item Code
        public static void Search_MasterItemClass(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemClass);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemType(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(clsSecurity.BranchID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemType);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemTypeByClassID(ref TextBox txtBox, string sClassID)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sClassID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemTypeByClassID);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemCategory(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemCategory_FloorStock(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategoryFloorStock);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemCategory_ByType(ref TextBox txtBox, string sType)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sType);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategoryIDByTypeID);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterItemCategory_ByClass(ref TextBox txtBox, string sClass)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sClass);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemCategoryIDByClassID);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }


        //item master
        public static void Search_ItemMaster(ref TextBox txtBox, string sItemClass, string sItemType, string sItemCategory, bool bIsDeleteOk)
        {
            List<string> lstParameeters = new List<string>();

            if (clsConfig.enableBranchWiseItemSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");

            lstParameeters.Add(sItemClass == null ? "%%" : sItemClass);
            lstParameeters.Add(sItemType == null ? "%%" : sItemType);
            lstParameeters.Add(sItemCategory == null ? "%%" : sItemCategory);

            if (!bIsDeleteOk)
                lstParameeters.Add("0");
            else
                lstParameeters.Add("");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCategories);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        public static void Search_ItemMasterByBranch(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            if (clsConfig.enableBranchWiseFilterOnSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");


            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByCompanyBranchID);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_ItemMaster_FinishGoods(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            if (clsConfig.enableBranchWiseFilterOnSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");


            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemMaster_FinishGoodsOnly);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }


        public static List<string> Search_DeleveryOfficer(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            //if (clsConfig.enableBranchWiseFilterOnSearch)
            //    lstParameeters.Add(clsSecurity.BranchID);
            //else
            //    lstParameeters.Add("%%");


            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.DeliveryOfficer);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
            return lstResult;
        }
        public static void Search_TransactionItemMasterByStore(ref TextBox txtBox, string sStoreID)
        {
            List<string> lstParameeters = new List<string>();

            if (clsConfig.enableBranchWiseFilterOnSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");

            lstParameeters.Add(sStoreID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemByStore);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        public static void Search_TransactionItemMasterByStore2(ref TextBox txtBox, string sStoreID)
        {
            List<string> lstParameeters = new List<string>();

            if (clsConfig.enableBranchWiseItemSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");

            lstParameeters.Add(sStoreID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ItemByStore);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        public static void Search_TransactionByItemCodeItemMaster(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();

            if (clsConfig.enableBranchWiseFilterOnSearch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%%");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);


            List<string> lstResult = RowDataSearch.Show(Search.ItemMasterByItemCode);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Employee Master
        public static void Search_MasterEmployee(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employees);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Store Master New
        public static void Search_MasterStore(ref TextBox txtBox, bool bEnableBranch)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            if (bEnableBranch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.StoreMaster);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterStore_GTN(ref TextBox txtBox, bool bEnableBranch)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            if (bEnableBranch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.StoreMaster_GTN);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterStore_DamagedStore(ref TextBox txtBox, bool bEnableBranch)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            if (bEnableBranch)
                lstParameeters.Add(clsSecurity.BranchID);
            else
                lstParameeters.Add("%");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.StoreMaster_Damaged);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterStoreDepartment(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.DepartmentStore);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }

        }
        #endregion

        #region Quotation Terms New
        public static void Search_MasterQuotationTerms(ref TextBox txtQuotationTerms)
        {
            frmSearch RowDataSearch = RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.QuotationTerms);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtQuotationTerms.Tag = lstResult[0];
                txtQuotationTerms.Text = lstResult[1];
            }
        }
        #endregion

        #region Financial Year New
        public static void Search_FinancialID(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FinancialYear);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Financial Year New
        public static void Search_FinancialMonth_ID(ref TextBox txtBox, string sFinYear)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;
            lstParameeters.Add(sFinYear);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.FinancialYearMonth);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[1];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region Cheque Type New
        public static void Search_ChequeType_New(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ChequeTypes);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region APN Type New
        public static void Search_AccountPayableNoteType_New(ref TextBox txtBox)
        {

            frmSearch RowDataSearch = new frmSearch();
            RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.APNType);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #region GL Master New
        public static void Search_MasterAccountGLCode(ref TextBox txtBox, string SAccType, string sControlAccType)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(SAccType);
            lstParameeters.Add(sControlAccType);
            lstParameeters.Add("-");

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AccName);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        public static void Search_MasterAccountGLCode_ControlTypes(ref TextBox txtBox, string sControlAccType)
        {
            //5255
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sControlAccType);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AccName_ControlTypes);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        public static void Search_GLCode(TextBox txtBox, TextBox nameTxtBox, bool isNameTextBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.GLName);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                if (isNameTextBox)
                {
                    txtBox.Text = lstResult[0];
                    nameTxtBox.Text = lstResult[1];
                }
                else
                {
                    txtBox.Text = lstResult[1];
                    txtBox.Tag = lstResult[0];
                }
            }
        }
        public static void Search_SubGLCode(TextBox txtBox, TextBox nameTxtBox, string GLCode, bool isNameTextBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(GLCode);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.SubGLName);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                if (isNameTextBox)
                {
                    txtBox.Text = lstResult[0];
                    nameTxtBox.Text = lstResult[1];
                }
                else
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[1];
                }
            }
        }
        public static void Search_AccountType(TextBox txtBox, TextBox nameTxtBox, string sSubCategoryID, bool isNameTextBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sSubCategoryID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AccTypeName1);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                if (isNameTextBox)
                {
                    txtBox.Text = lstResult[0];
                    nameTxtBox.Text = lstResult[1];
                }
                else
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[1];
                }
            }
        }
        public static void Search_AccountType2(TextBox txtBox, TextBox nameTxtBox, string sSubCategoryID, bool isNameTextBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(sSubCategoryID);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AccTypeName2);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                if (isNameTextBox)
                {
                    txtBox.Text = lstResult[0];
                    nameTxtBox.Text = lstResult[1];
                }
                else
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[1];
                }
            }
        }
        public static void Search_MasterAccountGLCode_Intercompany(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            lstParameeters.Add(clsConfig.accType_InterCompany);

            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AccName_InterCompany);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }
        #endregion

        #endregion

        #region Transaction
        #region Accounts
        #region Journal Entry Tx New
        public static void Search_JournalEntry_Trasaction(ref TextBox txtBox, bool ShowSettled, string JV_Type)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                lstParameeters.Add(JV_Type);

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.JouranalEntry);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        public static void Search_TransactionJournalVoucher2(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch fSearch = null;

                fSearch = new frmSearch(lstParameeters);
                List<string> lstResult = fSearch.Show(Search.Txn_Code);
                if (fSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[2];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region APN Tx New
        public static void Search_TransactionAccountPayableNote_Direct(ref TextBox txtBox, bool ShowSettled, string sSupplierID, string sCustomerID, bool isReturnCheque, bool ShowReimbursement, bool IsSAPN, bool IsShowAll)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                lstParameeters.Add(sSupplierID);
                lstParameeters.Add(sCustomerID);

                if (isReturnCheque)
                    lstParameeters.Add("");
                else
                    lstParameeters.Add("0");

                if (ShowReimbursement)
                    lstParameeters.Add("");
                else
                    lstParameeters.Add("0");

                if (IsShowAll)
                    lstParameeters.Add("");
                else
                {
                    // if (IsSAPN)
                    lstParameeters.Add("");
                    // else
                    //      lstParameeters.Add("0");
                }

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.APN_Direct);

                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Payment Voucher Tx New
        public static void Search_TransactionPaymentVoucher_Direct2(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.PaymentVoucherDirect2);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Account Receipt Tx New
        public static void Search_TansactionAccountReceipt_New(ref TextBox txtBox, bool bShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                if (!bShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.AccountReceipt);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[1];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Supplier Debit Note
        public static void Search_Transaction_AccDebitNote_New(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.AccDebitNote);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        #region Sales
        #region Inquiry Tx New
        public static void Search_TransactionInquiry_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled && clsConfig.bSettleEnabledInquiry)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Inquiry_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        public static void Search_TransactionInquiry_Use(ref TextBox txtBox, string sCustomerID, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(sCustomerID);

                if (clsConfig.bApprovalEnabledInquiry)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!ShowSettled && clsConfig.bSettleEnabledInquiry)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Inquiry);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Quotation Tx New
        public static void Search_TransactionQuotation_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled && clsConfig.bSettleEnabledQuotation)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Quotation_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        public static void Search_TransactionQuotation_Use(ref TextBox txtBox, string sCustomerID, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(sCustomerID);

                if (clsConfig.bApprovalEnabledQuotation)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                //    if (!ShowSettled && clsConfig.bSettleEnabledQuotation)
                lstParameeters.Add("");
                //  else
                //      lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Quotation);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Customer Order Tx New
        public static void Search_TransactionCustomerOrder_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");
            //    lstParameeters.Add(NoteType.ToString());

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.CustomerOrder_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        public static void Search_TransactionCustomerOrder_Use(ref TextBox txtBox, string sCustomer, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);
                lstParameeters.Add(sCustomer);

                if (clsConfig.bApprovalEnabledCustomerOrder)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!ShowSettled && clsConfig.bSettleEnabledCustomerOrder)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.CustomerOrder);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Delivery Order Tx New
        public static void Search_TransactionDeliveryOrder_Direct(ref TextBox txtBox, bool ShowSettled, int NoteType)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled && clsConfig.bSettleEnabledDeliveryOrder)
                    lstParameeters.Add("0");

                else
                    lstParameeters.Add("");

                lstParameeters.Add(NoteType.ToString());

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.DeliveryOrder_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }
        public static void Search_TransactionDeliveryOrder_Use(ref TextBox txtBox, string sCustomer, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);
                lstParameeters.Add(sCustomer);

                if (clsConfig.bApprovalEnabledDeliveryOrder)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!ShowSettled && clsConfig.bSettleEnabledDeliveryOrder)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.DeliveryOrder);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Invoice Tx New
        public static void Search_TransactionInvoice_Direct(ref TextBox txtBox, bool ShowSettled, bool isTaxExcludingInvoice, bool isInvoice2)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (isTaxExcludingInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("0");

                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult;

                if (isInvoice2)
                    lstResult = RowDataSearch.Show(Search.Invoice_2);
                else
                    lstResult = RowDataSearch.Show(Search.Invoice_Direct);

                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        public static void Search_TransactionInvoiceByCustomerID_Use(ref TextBox txtBox, string sCustomerID, bool hasOrderRefNo, string sOrderRefNo, bool bDisplaySettled, bool bShowOppeningBalance, bool bShowRC, bool bShowDebitNote, bool bShowInvoice, string sSalesNoteID)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (sCustomerID != "")
                    lstParameeters.Add(sCustomerID);
                else
                    lstParameeters.Add("");

                if (clsConfig.bApprovalEnabledInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!bDisplaySettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowOppeningBalance)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowRC)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowDebitNote)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (hasOrderRefNo)
                    lstParameeters.Add(sOrderRefNo);
                else
                    lstParameeters.Add("");

                if (sSalesNoteID != null && sSalesNoteID != "")
                    lstParameeters.Add(sSalesNoteID);
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Transaction_Invoice_CustomerID);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        public static string Search_TransactionInvoiceByCustomerID_Use(string sCustomerID, bool hasOrderRefNo, string sOrderRefNo, bool bDisplaySettled, bool bShowOppeningBalance, bool bShowRC, bool bShowDebitNote, bool bShowInvoice, string sSalesNoteID)
        {
            string sInvoice_ID = "default";

            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (sCustomerID != "")
                    lstParameeters.Add(sCustomerID);
                else
                    lstParameeters.Add("");

                if (clsConfig.bApprovalEnabledInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!bDisplaySettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowOppeningBalance)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowRC)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowDebitNote)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bShowInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (hasOrderRefNo)
                    lstParameeters.Add(sOrderRefNo);
                else
                    lstParameeters.Add("");

                if (sSalesNoteID != null && sSalesNoteID != "")
                    lstParameeters.Add(sSalesNoteID);
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.Transaction_Invoice_CustomerID);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                    sInvoice_ID = lstResult[0];

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }

            return sInvoice_ID;
        }
        #endregion

        #region Receipt Tx New
        public static void Search_TransactionReceipt_Direct(ref TextBox txtBox, bool ShowSettled, bool bIsSalesReceipt, bool isAdvanceReceipt, bool isEnableReceiptSort_ByReceiptID)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (isAdvanceReceipt)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("0");
                if (bIsSalesReceipt)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("0");

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.SalesReceipt_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Performa Invoice Tx New
        public static void Search_TransactionPerfomanceInvoice(ref TextBox txtBox, string sCustomerID, bool bApproved, bool ShowSettled, bool Canceled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(sCustomerID);

                if (bApproved && clsConfig.bApprovalEnabledInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!ShowSettled && clsConfig.bSettleEnabledProforemaInvoice)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!Canceled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.PerformaInvoice);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

                //Form frmhelpsearch = new frmSearchTransaction();
                //frmSearchTransaction.s_TableName = " tbl_sasProformaInvoice, tbl_genCustomerMaster ";
                //frmSearchTransaction.s_Columns = " proformaInvoice_ID [PI Code], customerName [Customer Name], grandTotal [perform Total], proformaInvoiceDate [PI Date],  tbl_sasProformaInvoice.isDeleted [Canceled]";
                //frmSearchTransaction.i_ColumnWidth = new int[] { 80, 160, 80, 80, 40 };
                //frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue };
                //string sCondition = "proformaInvoice_ID != 'default' AND tbl_sasProformaInvoice.customer_ID = tbl_genCustomerMaster.customer_ID";
                //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
                //    sCondition += " AND tbl_sasProformaInvoice.isSeattled = 'false' AND tbl_sasProformaInvoice.isDeleted = 'false'";
                //if (true)
                //    sCondition += " AND tbl_sasProformaInvoice.isFinished = 'false'";
                //frmSearchTransaction.s_Criteria = sCondition;
                //frmSearchTransaction.s_Order = "ORDER BY tbl_sasProformaInvoice.dateCreate DESC";

                //frmhelpsearch.ShowDialog();
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtBox.Text = frmSearchTransaction.s_SearchID;
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtBox.Tag = frmSearchTransaction.s_SearchID;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Sales Return Note tx New
        public static void Search_TransactionSalesReturnNote(ref TextBox txtBox, string sCustomerID, bool bApproved, bool ShowSettled, bool Canceled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(clsSecurity.BranchID);
                lstParameeters.Add(sCustomerID);

                if (bApproved && clsConfig.bApprovalEnabledInvoice)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!Canceled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.SalesReturnNote);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

                //Form frmhelpsearch = new frmSearchTransaction();
                //frmSearchTransaction.s_TableName = " tbl_sasSalesReturnedNote, tbl_genCustomerMaster ";
                //frmSearchTransaction.s_Columns = " salesReturnedNote_ID [SRN Code], customerName [Customer Name], grandTotal [SRN Total], salesReturnedNoteDate [SRN Date], tbl_sasSalesReturnedNote.isDeleted [Canceled] ";
                //frmSearchTransaction.i_ColumnWidth = new int[] { 80, 150, 80, 80, 40 };
                //frmSearchTransaction.e_ColomnAlignment = new enum_GridFormat[] { enum_GridFormat.TextValue, enum_GridFormat.TextValue, enum_GridFormat.NumaricValue, enum_GridFormat.DateValue, enum_GridFormat.TextValue };

                //string sCondition = "salesReturnedNote_ID != 'default' AND tbl_sasSalesReturnedNote.customer_ID = tbl_genCustomerMaster.customer_ID";
                //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
                //    sCondition += " AND tbl_sasSalesReturnedNote.isSeattled = 'false' AND tbl_sasSalesReturnedNote.isDeleted = 'false'";
                //if (true)
                //    sCondition += " AND tbl_sasSalesReturnedNote.isFinished = 'false'";
                //frmSearchTransaction.s_Criteria = sCondition + "AND tbl_sasSalesReturnedNote.companyBranch_ID ='" + companyBranchId + "'";
                //frmSearchTransaction.s_Order = "ORDER BY tbl_sasSalesReturnedNote.dateCreate DESC";

                //frmhelpsearch.ShowDialog();
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtBox.Text = frmSearchTransaction.s_SearchID;
                //if (frmSearchTransaction.s_SearchID.Length > 0)
                //    txtBox.Tag = frmSearchTransaction.s_SearchID;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion

        #region Bills
        #region Debit Note Tx New
        public static void Search_TransactionDebitNote_Direct(ref TextBox txtBox, bool ShowSettled, bool IsInterCompanyTransfer, bool IsRefundableNote)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!IsInterCompanyTransfer)
                {
                    if (IsRefundableNote)
                        lstParameeters.Add("1");
                    else
                        lstParameeters.Add("0");
                }

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                if (IsInterCompanyTransfer)
                {
                    List<string> lstResult = RowDataSearch.Show(Search.RefundableNote_direct);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        txtBox.Tag = lstResult[0];
                        txtBox.Text = lstResult[0];
                    }
                }
                else
                {
                    List<string> lstResult = RowDataSearch.Show(Search.DebitNote_direct);
                    if (RowDataSearch.DialogResult == DialogResult.OK)
                    {
                        txtBox.Tag = lstResult[0];
                        txtBox.Text = lstResult[0];
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refundable Note Tx New
        public static void Search_TransactionRefundableNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");


                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                //if (IsRefundableNote)
                //{
                List<string> lstResult = RowDataSearch.Show(Search.RefundableNote_direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
                //}
                //else
                //{
                //    List<string> lstResult = RowDataSearch.Show(Search.DebitNote_direct);
                //    if (RowDataSearch.DialogResult == DialogResult.OK)
                //    {
                //        txtBox.Tag = lstResult[0];
                //        txtBox.Text = lstResult[0];
                //    }
                //}

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        public static void Search_ChequeNo(ref TextBox txtBox)
        {
            try
            {
                frmSearch RowDataSearch = new frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.ChequeNo);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        public static void Search_TransactionCreditNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                //if(clsConfig.bEnableSalesReturn_DirectPosting)
                //    lstParameeters.Add("TP/002");
                //else
                lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch();
                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.CreditNote);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Stock
        #region Purchase Order Tx New
        public static void Search_TransactionPurchaseOrder_Direct(ref TextBox txtBox, string sSupplierID, bool ShowSettled, bool bIsCheckApproved)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                lstParameeters.Add(sSupplierID);

                if (bIsCheckApproved && clsConfig.bApprovalEnabledPurchaseOrder)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.TransactionPurchaseOrder_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Good Received Note Tx New
        public static void Search_TransactionExternalGoodReceivedNote_Direct(ref TextBox txtBox, bool ShowSettled, bool CheckApprove, string sSupID, string sNoteType)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (CheckApprove)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                if (sSupID != null)
                    lstParameeters.Add(sSupID);
                else
                    lstParameeters.Add("");

                lstParameeters.Add(sNoteType);

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.ExternalGoodReceivedNote_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                    //txtBox.Text = lstResult[1];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        public static void Search_TransactionExternalGoodReceivedNote_Direct(ref TextBox txtBox, bool ShowSettled, string sNoteType)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (sNoteType == "")
                    lstParameeters.Add("");
                else
                    lstParameeters.Add(sNoteType);

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.ExternalGoodReceivedNote_Direct_NoteType);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region External Good Issued Note Tx New
        public static void Search_TransactionExternalGoodIssuedNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(clsSecurity.BranchID);
                if (!ShowSettled)
                    lstParameeters.Add("0");

                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.ExternalGoodIssuedNote_Direct);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Purchase Return Note Tx New
        public static void Search_TransactionPurchaseReturnNote_New(ref TextBox txtBox, string sSupplierID, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(sSupplierID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                frmSearch RowDataSearch = new frmSearch(lstParameeters);

                List<string> lstResult = RowDataSearch.Show(Search.PurchaseReturnNote);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Store Requisition Tx New
        public static void Search_TransactionStoreReqositionNote(ref TextBox txtBox, bool ShowSettled, bool bIsDirectTransaction, string sStoreID)
        {
            try
            {
                List<string> lstParameeters = new List<string>();

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (!bIsDirectTransaction && clsConfig.bApprovalNeedForInternalTransferNoteSearch)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                lstParameeters.Add(sStoreID);

                frmSearch RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.SCS_storeReq);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Store Good Issue Note Tx New
        public static void Search_TransactionStoreGoodsIssueNote(ref TextBox txtBox, bool ShowSettled, bool bIsDirectTransaction, string sFrmStoreID, string sToStoreID)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;
                lstParameeters.Add(clsSecurity.BranchID);

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                lstParameeters.Add(sFrmStoreID);
                lstParameeters.Add(sToStoreID);

                if (!bIsDirectTransaction && clsConfig.bApprovalNeedForInternalTransferNoteSearch)
                    lstParameeters.Add("1");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.SCS_storeGIN);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Store Good Received Note
        public static void Search_TransactionStoreGoodsReceiveNote_Direct(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.SCS_storeGRN);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Good Transfer Note
        public static void Search_TransactionGoodsTransferNote_Direct(ref TextBox txtBox, bool bShowAll, object sFrmStoreID, object sToStoreID)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                lstParameeters.Add(clsSecurity.BranchID);

                if (!bShowAll)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                if (sFrmStoreID != null)
                    lstParameeters.Add(sFrmStoreID.ToString());
                else
                    lstParameeters.Add("");

                if (sToStoreID != null)
                    lstParameeters.Add(sToStoreID.ToString());
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.SCS_GTN);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Split Note Tx New
        public static void Search_TransactionItemSpradeNote(ref TextBox txtBox, bool ShowSettled)
        {
            try
            {
                List<string> lstParameeters = new List<string>();
                frmSearch RowDataSearch = null;

                if (!ShowSettled)
                    lstParameeters.Add("0");
                else
                    lstParameeters.Add("");

                RowDataSearch = new frmSearch(lstParameeters);
                List<string> lstResult = RowDataSearch.Show(Search.ItemSplitNoteNote);
                if (RowDataSearch.DialogResult == DialogResult.OK)
                {
                    txtBox.Tag = lstResult[0];
                    txtBox.Text = lstResult[0];
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
        #endregion
        #endregion

        public static void Search_MasterPettyCashExpenditureTypeWithLevel(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Expenditures);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }
        }

        //R2 Search
        #region R2 Production Modules

        #region Apparel Production
        public static void SearchProdApparel_ItemFromProdJobBom_StoreFilter(ref TextBox txtProdJob, string sCustomer, string sStore)
        {
            List<string> lstParameeters = new List<string>();

            frmSearch RowDataSearch = null;
            lstParameeters.Add(sCustomer);
            lstParameeters.Add(sStore);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Prod_ProductionBoMJobs_Store);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtProdJob.Tag = lstResult[0]; //Production Job Bom
                txtProdJob.Text = lstResult[0];//Production Job Bom
            }
        }
        public static void SearchProdApparel_ItemFromProdJobBom_CostApproved(ref TextBox txtProdJob, string sCustomer, string sStore)
        {
            List<string> lstParameeters = new List<string>();

            frmSearch RowDataSearch = null;
            lstParameeters.Add(sCustomer);
            lstParameeters.Add(sStore);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Prod_ProductionBoMJobs_CostApproved);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtProdJob.Tag = lstResult[0]; //Production Job Bom
                txtProdJob.Text = lstResult[0];//Production Job Bom
            }
        }
        #endregion

        #region Pharma Production
        public static void SearchProdPharma_ItemFromProdJobBom_StoreFilter(ref TextBox txtProdJob, string sCustomer, string sStore)
        {
            List<string> lstParameeters = new List<string>();

            frmSearch RowDataSearch = null;
            lstParameeters.Add(sCustomer);
            lstParameeters.Add(sStore);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Prod_ProductionBoMJobs_Store);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtProdJob.Tag = lstResult[0]; //Production Job Bom
                txtProdJob.Text = lstResult[0];//Production Job Bom
            }
        }
        public static void SearchProdPhama_ItemFromProdJobBom_CostApproved(ref TextBox txtProdJob, string sCustomer, string sStore)
        {
            List<string> lstParameeters = new List<string>();

            frmSearch RowDataSearch = null;
            lstParameeters.Add(sCustomer);
            lstParameeters.Add(sStore);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.ProdPharma_ProductionBoMJobs_CostApproved);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtProdJob.Tag = lstResult[0]; //Production Job Bom
                txtProdJob.Text = lstResult[0];//Production Job Bom
            }
        }
        #endregion

        #region Job Register by Customer
        public static void passValue_ConfirmedJobRegisterByCustomerID_New(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;
            //lstParameeters.Add(clsSecurity.BranchID);
            //if (!ShowSettled && clsConfig.bSettleEnabledInvoice)
            //    lstParameeters.Add("0");

            //else
            //    lstParameeters.Add("");

            //if (isTaxExcludingInvoice)
            //    lstParameeters.Add("1");
            //else
            //    lstParameeters.Add("0");

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Prod_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[0];
            }
        }
        #endregion

        #endregion

        //Fixed Assets
        public static void Search_FixedAssets(ref TextBox txtBox)
        {
            frmSearch RowDataSearch = new frmSearch();

            List<string> lstResult = RowDataSearch.Show(Search.FixedAssets);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[0];
            }
        }

        public static void Search_AssetsTransferNote(ref TextBox txtBox)
        {
            List<string> lstParameeters = new List<string>();
            frmSearch RowDataSearch = null;

            lstParameeters.Add(clsSecurity.BranchID);

            RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.AssetsTransferNote);
            if (RowDataSearch.DialogResult == DialogResult.OK)
            {
                txtBox.Tag = lstResult[0];
                txtBox.Text = lstResult[1];
            }

        }
        #endregion

    }
}