using DataTire;

namespace Digiteq_Logic
{
    public class clsRef_Name
    {
        public static string get_Customer_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genCustomerMaster", "customerName", "customer_ID", ID));
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

        public static string get_Country_Name(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_genMasCountry", "countryName", "country_ID", ID));
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

        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
                return "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "'";
            else
                return "";
        }
    }
}