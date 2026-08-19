using DataTire;

namespace Digiteq_Logic
{
    public class clsRef_Name
    {        
        public static string get_Company_Branch(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genCompanyBranchMaster", "branchName", "companyBranch_ID", ID));
        }

        public static string get_Bank_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBank", "bankName", "bank_ID", ID));
        }

        public static string get_Bank_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBank", "sortName", "bank_ID", ID));
        }

        public static string get_Branch_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBankBranches", "branchName", "branch_ID", ID));
        }
        public static string get_OriginalBranch_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBankBranches", "originalBranchCode", "branch_ID", ID));
        }

        public static string get_BankBranch_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBankBranches", "branchName", "branch_ID", ID));
        }

        //public static string get_Country_Name(string ID)
        //{
        //    return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasCountry", "countryName", "country_ID", ID));
        //}

        public static string get_Currency_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCurrency", "currencyCode", "currency_ID", ID));
        }

        public static string get_Factoring_AccNo(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_bpsFactoringAgreement", "accountNumber_Factoring", "factoringAgreement_ID", ID));
        }

        public static string get_Factoring_Bank(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_bpsFactoringAgreement", "bank_ID", "factoringAgreement_ID", ID));
        }

        public static string get_Factoring_Branch(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_bpsFactoringAgreement", "branch_ID", "factoringAgreement_ID", ID));
        }

        public static string get_Cheque_Register_BankID(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_bpsChequeRegister", "bank_ID", "chequeRegister_ID", ID));
        }

        public static string get_Cheque_Register_BranchID(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_bpsChequeRegister", "branch_ID", "chequeRegister_ID", ID));
        }

        public static string get_Customer_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genCustomerMaster", "customerName", "customer_ID", ID));
        }

        public static string get_Customer_Class(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerClass", "className", "customerClass_ID", ID));
        }

        public static string get_Customer_Type(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerType", "typeName", "customerType_ID", ID));
        }

        public static string get_Customer_Category(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCustomerCategory", "categoryName", "customerCategory_ID", ID));
        }

        public static string get_Item_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genItemMaster", "itemName", "item_ID", ID));
        }

        public static string get_Item_Class(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemClass", "className", "itemClass_ID", ID));
        }

        public static string get_Item_Type(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemType", "typeName", "itemType_ID", ID));
        }

        public static string get_Item_Category(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemCategory", "categoryName", "itemCategory_ID", ID));
        }

        public static string get_Item_SubCategory(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemCategory_Sub", "categoryName", "itemCategory_ID", ID));
        }

        public static string get_Item_Brand(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zBrand", "brandName", "brand_ID", ID));
        }

        public static string get_Item_Uom(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zUom", "uomCode", "uom_ID", ID));
        }

        public static string get_Item_Tag1(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemTag1", "description", "tag1_ID", ID));
        }

        public static string get_Item_Tag2(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zItemTag2", "description", "tag2_ID", ID));
        }

        public static string get_Renewal_Types(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderRenewalType", "renewal_Name", "renewal_ID", ID));
        }

        public static string get_Sponsor_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderSponsor", "sponsor_Name", "sponsor_ID", ID));
        }

        public static string get_Country_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCountry", "countryName", "country_ID", ID));
        }

        public static string get_City_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zCity", "cityName", "city_ID", ID));
        }

        public static string get_Town_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zTown", "townName", "town_ID", ID));
        }

        public static string get_Bid_No(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderNotice", "bidReference_No1", "tender_ID", ID));
        }

        public static string get_Notice_Date(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderNotice", "noticeDate", "tender_ID", ID));
        }

        public static string get_UoM_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_zUom", "uomCode", "uom_ID", ID));
        }

        public static string get_Document_Type(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderDocumentMaster", "doc_Type", "doc_ID", ID));
        }

        public static object get_Document_Code(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderDocumentMaster", "doc_Code", "doc_ID", ID));
        }

        public static string get_Document_Description(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderDocumentMaster", "doc_Description", "doc_ID", ID));
        }
        public static string get_Tender_Source(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_ttsTenderSource", "tenderSourceName", "tenderSource_ID", ID));
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