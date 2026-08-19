using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEACC_PTS
{
    static class configNames
    {
        #region Auto Assign Config Values
        public static void AutoAssignConfigValue()
        {
            List<tbl_cfgConfiguration> details = tbl_cfgConfiguration.SelectAll();
            foreach (tbl_cfgConfiguration detail in details)
            {
                switch (detail.ConfigID)
                {
                    case 1:
                        clsConfig.sIsExpiry = bool.Parse(detail.ConfigValue.Trim());
                        break;
                    case 2:
                        clsConfig.sExpiryDate = detail.ConfigValue;
                        break;
                    case 100:
                        settings.AutoAlert_SenderAddress = detail.ConfigValue;
                        break;
                    case 101:
                        settings.AutoAlert_Host = detail.ConfigValue;
                        break;
                    case 102:
                        settings.AutoAlert_port = int.Parse(detail.ConfigValue);
                        break;
                    case 103:
                        settings.AutoAlert_SSLEnabled = bool.Parse(detail.ConfigValue.Trim());
                        break;
                    case 104:
                        settings.AutoAlert_PassWord = detail.ConfigValue;
                        break;
                }
            }
        }
        #endregion
        public static string GetStatus(int Status_ID)
        {
            string Value = "";
            tbl_refStatus oStatus = tbl_refStatus.Select(Status_ID);
            if (oStatus != null)
                Value = oStatus.Status;

            return Value;
        }

        public static string GetType(int Status_ID)
        {
            string Value = "";
            tbl_refType oStatus = tbl_refType.Select(Status_ID);
            if (oStatus != null)
                Value = oStatus.Type;

            return Value;
        }

        public static string GetPriority(int Status_ID)
        {
            string Value = "";
            tbl_masPriority oStatus = tbl_masPriority.Select(Status_ID);
            if (oStatus != null)
                Value = oStatus.priorityType;

            return Value;
        }

        public static string GetUserName(int User_ID)
        {
            string Value = "";
            tbl_masUser oUser = tbl_masUser.Select(User_ID);
            if (oUser != null)
                Value = oUser.Display_Name;

            return Value;
        }

        public static string GetClientCode(int User_ID)
        {
            string Value = "";
            tbl_masClient oUser = tbl_masClient.Select(User_ID);
            if (oUser != null)
                Value = oUser.Client_Code;

            return Value;
        }

        public static string GetProductName(int Product_ID)
        {
            string Value = "";
            tbl_masProduct oUser = tbl_masProduct.Select(Product_ID);
            if (oUser != null)
                Value = oUser.Product_Code;

            return Value;
        }

        public static string GetFunctionName(int Function_ID)
        {
            string Value = "";
            tbl_refFunction oUser = tbl_refFunction.Select(Function_ID);
            if (oUser != null)
                Value = oUser.Function_Name;

            return Value;
        }
    }
}
