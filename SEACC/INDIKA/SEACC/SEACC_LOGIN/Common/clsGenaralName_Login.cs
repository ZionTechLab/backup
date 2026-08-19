
using SEACC_LOGIN.DataTire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC_LOGIN.Common
{
    class clsGenaralName_Login
    {
        public static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
            {
                string sResult = "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "' AND " + Key + " <> 'default'";
                return sResult != null ? sResult : "";
            }
            else
                return "";
        }

        public static string GenarateQuery(string table, string field, string Key, int value)
        {
            if (value >=0)
            {
                string sResult = "select [" + field + "] from [" + table + "] where " + Key + "= '" + value.ToString() + "' AND " + Key + " >= '0'";
                return sResult != null ? sResult : "";
            }
            else
                return "";
        }

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

        #region Company Branch
        public static string getName_CompanyBranchMaster(string ID)
        {
            string bBranch_ID = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genCompanyBranchMaster", "branchName", "companyBranch_ID", ID));
            return bBranch_ID;
        }
        #endregion

        public static string getLocation_ModuleExe(int iModIndex_ID)
        {
            string sExe_Location = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_cfgModule", "exe_location", "module_Index", iModIndex_ID));
            return sExe_Location;
        }
    }
}
