using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using DataTire;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows;
using SEACC_WPFControls;
using System.Net.Mail;
using SEACC_WPFControls;

namespace Digiteq_Logic
{
    public class clsSecurity
    {
        public static string SoftwareBy = "Software By : DigiteQ";
        public static string DigiteqName = "Digiteq Solutions (Pvt) Ltd.";
        public static string DigiteqEmail = "info@digiteq.biz";
        public static string DigiteqTelephone = "+94-117-820080";

        //DB Login Variables        
        public static string DB_UserName;
        public static string DB_Password;
        public static string DB_Database;
        public static string DB_Server;
        public static string DB_Domain;

        //Login Information
        public static string CompanyID;
        public static string CompanyName = "";
        public static string CompanyAddress1 = "";
        public static string CompanyAddress2 = "";
        public static string BranchID="default";
        public static string BranchName = "";
        public static string FinancialYearID;
        public static string LastFinancialYearID;

        public static string TerminalID;
        public static string UserNameLoged;
        public static string UserIDLoged;
        public static string EmployeeIDLoged;
        public static string UserPasswordLoged;
        public static string UserGroupLoged;
        public static string UserGroupIDLoged;
        public static int AccessCategory;
        public static System.Windows.Media.Imaging.BitmapImage UserImageLoged;

        public static string Version_EXE = "";

        #region Registry Area
        private static string regDBUserName;
        private static string regDBUserPassword;
        private static string regDatabaseName;
        private static string regServerName;
        private static string regOutlet;
        private static string regTerminal;

        private static string regCompanyName;
        private static string regValied;
        private static string regRegistryName = "Software\\52465123-sys\\456465465461312313111321";// + "1212";
        private static string regDomainName;

        #region Get Setter Methods

        public static string RegRegistryName
        {
            get { return clsSecurity.regRegistryName; }
            set { clsSecurity.regRegistryName = value; }
        }
        public static string RegDomainName
        {
            get { return clsSecurity.regDomainName; }
            set { clsSecurity.regDomainName = value; }
        }
        public static string RegValied
        {
            get { return clsSecurity.regValied; }
            set { clsSecurity.regValied = value; }
        }
        public static string RegCompanyName
        {
            get { return clsSecurity.regCompanyName; }
            set { clsSecurity.regCompanyName = value; }
        }
        public static string RegDBUserName
        {
            get { return clsSecurity.regDBUserName; }
            set { clsSecurity.regDBUserName = value; }
        }
        public static string RegDBUserPassword
        {
            get { return clsSecurity.regDBUserPassword; }
            set { clsSecurity.regDBUserPassword = value; }
        }
        public static string RegDatabaseName
        {
            get { return clsSecurity.regDatabaseName; }
            set { clsSecurity.regDatabaseName = value; }
        }
        public static string RegServerName
        {
            get { return clsSecurity.regServerName; }
            set { clsSecurity.regServerName = value; }
        }
        public static string RegOutlet
        {
            get { return clsSecurity.regOutlet; }
            set { clsSecurity.regOutlet = value; }
        }
        public static string RegTerminal
        {
            get { return clsSecurity.regTerminal; }
            set { clsSecurity.regTerminal = value; }
        }
        #endregion


        public static bool AutoAssignCompanyValue()
        {
            bool status = false;
            try
            {
                tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                if (com != null)
                {
                    clsSecurity.CompanyName = clsSecurity.decryptPassword(com.CompanyName);
                    clsSecurity.CompanyAddress1 = clsSecurity.decryptPassword(com.Address);
                    clsSecurity.CompanyAddress2 = "";
                    if (com.Telephone1.Length > 0)
                        clsSecurity.CompanyAddress2 = "Tel:" + com.Telephone1;
                    if (com.Telephone2.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + com.Telephone2;
                    if (com.Fax.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + " FAX:" + com.Fax;
                    status = true;
                }
                else
                {
                    SEACCMessageBox.Show("Company Not exist....!", "");
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Company Error....!", ex.Message, MessageBoxButton.OK);
             //   clsValidation.WriteErrorLog(ex.Message, 0);
            }
            return status;
        }
        //#region Set Values
        public static bool CheckRegName()
        {
            bool Status = true;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            if (key == null)
                Status = false;

            return Status;
        }

        public static bool setRegName()
        {
            bool Status = true;
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            if (key == null)
            {
                SEACCMessageBox.Show("Registry Error....!", "Please contact your system Administrator");
                Status = false;
            }
            return Status;
        }
        //public static void setRegValues()
        //{
        //    // Open the key
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

        //    // Set the registry values to correspond to the form's coordinates on the
        //    // screen.
        //    key.SetValue("servername", RegServerName.Trim());
        //    key.SetValue("database", RegDatabaseName.Trim());
        //    key.SetValue("dbuser", RegDBUserName.Trim());
        //    key.SetValue("dbpassword", RegDBUserPassword.Trim());
        //    key.SetValue("outlet", regOutlet.Trim());
        //    key.SetValue("terminal", RegTerminal.Trim());
        //    key.SetValue("companyname", RegCompanyName.Trim());
        //    key.SetValue("valied", RegValied);
        //    key.SetValue("registryName", RegRegistryName);
        //    key.SetValue("domainName", RegDomainName);

        //}
        public static void setRegValuesServername(string ServerName)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegServerName = ServerName;
            key.SetValue("servername", RegServerName.Trim());
        }
        public static void setRegValuesDatabasename(string DatabaseName)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegDatabaseName = DatabaseName;
            key.SetValue("database", RegDatabaseName.Trim());
        }
        public static void setRegValuesUsername(string UserName)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegDBUserName = UserName;
            key.SetValue("dbuser", RegDBUserName.Trim());
        }
        public static void setRegValuesPassword(string UserPassword)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegDBUserPassword = UserPassword;
            key.SetValue("dbpassword", RegDBUserPassword.Trim());
        }
        public static void setRegValuesValidKey(string ValidKey)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            regValied = ValidKey;
            key.SetValue("valied", regValied.Trim());
        }
        public static void setRegValuesOutlet(string OutletID)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegOutlet = OutletID;
            key.SetValue("outlet", RegOutlet.Trim());
        }
        public static void setRegValuesTerminal(string TerminalID)
        {
            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName, true);

            // Set the registry values to correspond to the form's coordinates on the
            RegTerminal = TerminalID;
            key.SetValue("terminal", RegTerminal.Trim());
        }
       
        //public static bool setRegistryValue()
        //{
        //    bool status = false;
        //    try
        //    {
        //        RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

        //        clsSecurity.DB_UserName = clsSecurity.decryptPassword(key.GetValue("dbuser").ToString());
        //        clsSecurity.DB_Password = clsSecurity.decryptPassword(key.GetValue("dbpassword").ToString());
        //        clsSecurity.DB_Database = clsSecurity.decryptPassword(key.GetValue("database").ToString());
        //        clsSecurity.DB_Server = key.GetValue("servername").ToString();
        //        clsSecurity.DB_Domain = key.GetValue("domainName").ToString();
        //        clsSecurity.CompanyID = key.GetValue("companyname").ToString();
        //        status = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCMessageBox.Show("Registry Error....!", ex.Message);
        //        clsValidate.WriteErrorLog(ex.Message, 0);
        //    }
        //    return status;
        //}
        //public static bool  AutoAssignCompanyValue()
        //{
        //    bool status = false;
        //    try
        //    {
        //        tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
        //        if (com != null)
        //        {
        //            clsSecurity.CompanyName = clsSecurity.decryptPassword(com.CompanyName);
        //            clsSecurity.CompanyAddress1 = clsSecurity.decryptPassword(com.Address);
        //            clsSecurity.CompanyAddress2 = "";
        //            if (com.Telephone1.Length > 0)
        //                clsSecurity.CompanyAddress2 = "Tel:" + com.Telephone1;
        //            if (com.Telephone2.Length > 0)
        //                clsSecurity.CompanyAddress2 += "," + com.Telephone2;
        //            if (com.Fax.Length > 0)
        //                clsSecurity.CompanyAddress2 += "," + " FAX:" + com.Fax; 
        //            status = true;
        //        }
        //        else
        //        {
        //            SEACCMessageBox.Show("Company Not exist....!","");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCMessageBox.Show("Company Error....!", ex.Message,MessageBoxButton.OK);
        //        clsValidate.WriteErrorLog(ex.Message, 0);
        //    }
        //    return status;
        //}

        public static string getRegDBOutlet()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("outlet").ToString();

            return result;
        }
        //#endregion

        //#region get version

        public static string getRegDBTerminal()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("terminal").ToString();

            return result;
        }
        //#endregion


        public static string getRegDBValied()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("valied").ToString();

            return result;
        }
        //#endregion

        //#region get regirstry name

        public static string getRegDBRegistryName()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("registryName").ToString();

            return result;
        }
        //#endregion

        //#region get domain name

        //public static string getRegDBDomainName()
        //{
        //    // Attempt to open the key
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

        //    string result = key.GetValue("domainName").ToString();

        //    return result;
        //}
        //#endregion
        //#endregion
        //#endregion

        //#region Encryption
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //#endregion

        #region Date/Time
        public static DateTime getServerDateTime()
        {
            DateTime Dt;
            string x;
            SqlConnection scon = DBHandling.GetConnection();
            scon.Open();
            SqlCommand scom = new SqlCommand("select getdate()", scon);
            Dt = DateTime.Parse(scom.ExecuteScalar().ToString().Trim());
            x = Dt.ToString("yyyy-MM-dd HH:mm:ss.ms");
            Dt = DateTime.Parse(x);
            scon.Close();
            return Dt;

        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
        #endregion

       

        ////#region Form Permission Area
        //public static bool PermissionToRead(string sUserID, FormName iFormID)
        //{
        //    bool value = false;
        //    tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, (int)iFormID);
        //    if (detail != null)
        //    {
        //        if (detail.AllowRead)
        //            value = true;
        //    }
        //    return value;
        //}
        //public static bool PermissionToSave(string sUserID, int iFormID, bool bIsUpdate)
        //{
        //    bool value = false;
        //    tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID);
        //    if (detail != null)
        //    {
        //        if (bIsUpdate) //if try to update
        //        {
        //            if (detail.AllowUpdate)
        //                value = true;
        //            else
        //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToUpdate), clsFormatter.GetMessageCaption(),MessageBoxButton.OK, MessageBoxImage.Information);
                       
        //        }
        //        else //if try to insert
        //        {
        //            if (detail.AllowWrite)
        //                value = true;
        //            else
        //                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), clsFormatter.GetMessageCaption(),MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //    }
        //    else
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), clsFormatter.GetMessageCaption(),MessageBoxButton.OK, MessageBoxImage.Information);
        //    return value;
        //}
        //public static bool PermissionToDelete(string sUserID, int iFormID)
        //{
        //    bool value = false;
        //    tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID);
        //    if (detail != null)
        //    {
        //        if (detail.AllowDelete)
        //            value = true;
        //    }
        //    return value;
        //}
        //public static bool PermissionToChecked(string sUserID, int iFormID)
        //{
        //    bool value = false;
        //    tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID);
        //    if (detail != null)
        //    {
        //        if (detail.AllowCheckable)
        //            value = true;
        //    }
        //    return value;
        //}
        ////public static bool PermissionToPrint_WithMessage(string sReportID)
        //{
        //    bool value = false;
        //    tbl_securityReportPermission detail = tbl_securityReportPermission.Select(clsSecurity.UserIDLoged, sReportID);
        //    if (detail != null)
        //    {
        //        if (detail.AllowPrint)
        //            value = true;
        //    }
        //    if (!value)
        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToPrint), clsFormatter.GetMessageCaption() + " [" + sReportID + "]",MessageBoxButton.OK, MessageBoxImage.Information);

        //    return value;
        //}
        #endregion

        //public static void gMailSendings(MailMessage objeto_mail)
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.Port = 587;
        //    client.EnableSsl = true;
        //    client.Host = "smtp.gmail.com";
        //    client.Timeout = 10000;
        //    client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    client.UseDefaultCredentials = false;
        //    client.Credentials = new System.Net.NetworkCredential(DigiteqEmail, "");
        //    client.Send(objeto_mail);
        //}

    }
}
