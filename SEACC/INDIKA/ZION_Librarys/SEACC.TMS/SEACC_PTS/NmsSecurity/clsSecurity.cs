using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using SEACC_PTS.NmsEnum;
using System.Security.Cryptography;
using System.IO;
namespace SEACC_PTS.NmsSecurity
{
    class clsSecurity
    {
        public static DateTime getServerDateTime()
        {
            DateTime Dt;
            string x;
            dbConnection oDbCon = new dbConnection();
            OleDbConnection scon = oDbCon.scon;
            scon.Open();
            OleDbCommand scom = new OleDbCommand("select getdate()", scon);
            Dt = DateTime.Parse(scom.ExecuteScalar().ToString().Trim());
            x = Dt.ToString("yyyy-MM-dd HH:mm:ss.ms");
            Dt = DateTime.Parse(x);
            scon.Close();
            return Dt;

        }
        public static bool IsAlerts_SheduleEnable(int shId )
        {
            bool value = false;
            try
            {
                tbl_altAlert_Shedule detail = tbl_altAlert_Shedule.Select(shId);
                if (detail != null && detail.isActive)
                {
                    DateTime dtLastUpdateTime = detail.lastAlert_SentTime, dtNow = clsSecurity.getServerDateTime();
                    int iHour = detail.sheduledTime.Hour;
                    if (dtNow.Date > dtLastUpdateTime.Date && dtNow.Hour >= iHour)
                    {

                        value = true;                       
                        detail.Update();
                    }
                }
            }
            catch (Exception)
            {

            }
            return value;
        }

        //public static DateTime GetSystemExpireDate()
        //{
        //    DateTime dtmExpire = getServerDateTime();
        //    tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(CompanyID);
        //    if (oCompany != null && oCompany.ProductKey != null)
        //    {
        //        string sDate = decryptPassword(oCompany.ProductKey).Split(new string[] { "|~|" }, StringSplitOptions.None)[1];
        //        try
        //        {
        //            dtmExpire = DateTime.Parse(sDate);
        //        }
        //        catch { }
        //    }
        //    return dtmExpire;
        //}

        #region Encryption
        public static string encryptPassword(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
        }
        public static string decryptPassword(string str)
        {
            return Decrypt(str, "&%#@?,:*");
        }
        private static string Encrypt(string strText, string strEncrypt)
        {
            byte[] byKey = new byte[20];
            byte[] dv = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputArray = System.Text.Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, dv), CryptoStreamMode.Write);
                cs.Write(inputArray, 0, inputArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string Decrypt(string strText, string strEncrypt)
        {
            byte[] bKey = new byte[20];
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            try
            {
                bKey = System.Text.Encoding.UTF8.GetBytes(strEncrypt.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                Byte[] inputByteArray = inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(bKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception)
            {
                return "";
            }
        }
        #endregion
    }
}
