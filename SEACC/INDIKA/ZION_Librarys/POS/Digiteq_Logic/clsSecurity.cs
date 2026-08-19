//#################################
// Created By : Jayasuriya
// Date : 03/12/2010
// Purpose : to keep the security values in a common place and security handle methods
//#################################

using System;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using DataTire;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;
using System.Reflection;
using SEACC;

namespace Digiteq_Logic
{
    public class clsSecurity
    {
        public static string SoftwareBy = "Software By : DigiteQ";
        public static string DigiteqName = "Digiteq Solutions (Pvt) Ltd.";
        public static string DigiteqEmail = "info@digiteq.biz";
        public static string DigiteqTelephone = "+94-117-820080";
        
        //DB Login Variables        
        public static string UserName;
        public static string Password;
        public static string Database;
        public static string Server;
        public static string Domain;
        public static string SoftwareModle;
        //Login Information
        public static string CompanyID;
        public static string CompanyName = "";
        public static string CompanyAddress1 = "";
        public static string CompanyAddress2 = "";
        public static string BranchID = "default";
        public static string BranchName = "";
        public static string FinancialYearID = "default";
        public static string LastFinancialYearID;
        public static string TerminalID;
        public static string UserNameLoged;
        public static string UserIDLoged;
      //  public static string UserPasswordLoged;
        public static string UserGroupLoged;
        public static string UserGroupIDLoged;
        public static int AccessCategory;
        public static int iLoginSession_Index;
        public static bool bIsLive = false;

        #region Logon Report
        public static void LogonServer(ref ReportDocument crReportDocument)
        {

            CrystalDecisions.CrystalReports.Engine.Database oCRDb = crReportDocument.Database;
            CrystalDecisions.CrystalReports.Engine.Tables oCRTables = crReportDocument.Database.Tables;


            CrystalDecisions.Shared.TableLogOnInfo oCRTableLogonInfo;


            CrystalDecisions.Shared.ConnectionInfo oCRConnectionInfo = new CrystalDecisions.Shared.ConnectionInfo();
            int iCnt;


            #region Set Connection Parameters for View Reports
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(DBHandling.DBConnection);
            Server = builder.DataSource;
            Database = builder.InitialCatalog;
            UserName = builder.UserID;
            Password = builder.Password;
            #endregion

            //plese change back to this
            oCRConnectionInfo.DatabaseName = Database;
            oCRConnectionInfo.ServerName = Server;
            oCRConnectionInfo.UserID = UserName;
            oCRConnectionInfo.Password = Password;
            //oCRConnectionInfo.DatabaseName = getRegDatabaseName();
            //oCRConnectionInfo.ServerName = getRegServerName();
            //oCRConnectionInfo.UserID = getRegDBUserName(); ;
            //oCRConnectionInfo.Password = getRegDBUserPassword();


            foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTable in oCRTables)
            {
                oCRTableLogonInfo = oCRTable.LogOnInfo;
                oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                oCRTable.ApplyLogOnInfo(oCRTableLogonInfo);
            }


            //Setting Sub Report Log on information
            for (iCnt = 0; iCnt <= crReportDocument.Subreports.Count - 1; iCnt++)
            {

                oCRTables = crReportDocument.Subreports[iCnt].Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table oCRTable in oCRTables)
                {
                    oCRTableLogonInfo = oCRTable.LogOnInfo;
                    oCRTableLogonInfo.ConnectionInfo = oCRConnectionInfo;
                    oCRTable.ApplyLogOnInfo(oCRTableLogonInfo);
                }
            }

        }
        #endregion

        #region Get Report Field
        public static object GetField(Object obj, String fieldName)
        {
            System.Reflection.FieldInfo fi = obj.GetType().GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            return fi.GetValue(obj);
        }
        #endregion

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

        public static bool isLive = false;

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

        public static bool setRegistryValue(bool _isLive)
        {
            bool status = false;
            try
            {
                isLive = _isLive;

                String[] s1 = new String[4];
                string sFolderpath = Path.GetDirectoryName(Path.GetDirectoryName(Application.ExecutablePath)) + "\\LOGIN";
                string sConfiFile = @"\config_" + (isLive ? "Live" : "Test") + ".cfg";

                if (File.Exists(sFolderpath + sConfiFile))
                {

                    s1 = configurations.getConfig(sFolderpath + sConfiFile);

                    UserName = crypt.decryptPassword(s1[1]);
                    Password = crypt.decryptPassword(s1[2]);
                    Database = crypt.decryptPassword(s1[3]);
                    Server = crypt.decryptPassword(s1[0]);
                    CompanyID = "company1";
                    status = true;
                }
                else
                    MessageBox.Show("Registry Error....!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registry Error....!", ex.Message);
            }
            return status;
        }
        //public static bool setRegistryValue(string DirectoryPath)
        //{
        //    bool status = false;
        //    try
        //    {
        //        String[] s1 = new String[4];


        //        if (File.Exists(DirectoryPath + @"\config.cfg"))
        //        {
        //            s1 = configurations.getConfig(DirectoryPath);

        //            UserName = crypt.decryptPassword(s1[1]);
        //            Password = crypt.decryptPassword(s1[2]);
        //            Database = crypt.decryptPassword(s1[3]);
        //            Server = crypt.decryptPassword(s1[0]);
        //            Domain = "";
        //            CompanyID = "company1";
        //            status = true;
        //        }
        //        else
        //            MessageBox.Show("Registry Error....!");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Registry Error....!", ex.Message);
        //        clsValidate.WriteErrorLog("", 0,ex);
        //    }
        //    return status;
        //}

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
                    MessageBox.Show("Company Not exist....!", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Network Connection Error....!");
                clsValidate.WriteErrorLog("", 0,ex);
            }
            return status;
        }


        #endregion

        #region Encryption
        public static string encryptPassword(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
        }
        public static DateTime GetSystemExpireDate()
        {
            DateTime dtmExpire = getServerDateTime();
            tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(CompanyID);
            if (oCompany != null && oCompany.ProductKey != null)
            {
                string sDate = decryptPassword(oCompany.ProductKey).Split(new string[] { "|~|" }, StringSplitOptions.None)[1];
                try
                {
                    dtmExpire = DateTime.Parse(sDate);
                }
                catch { }
            }
            return dtmExpire;
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

        #region Date/Time For Month
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

        public static DateTime FirstDayOfMonthFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        public static DateTime LastDayOfMonthFromDateTime(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        #endregion

        public static string GetCofigValue(int iConfigID)
        {
            string sValue = "default";
            tbl_securityConfigValue oConfig = tbl_securityConfigValue.Select(iConfigID);
            if (oConfig != null && oConfig.ConfigValue != "")
                sValue = oConfig.ConfigValue;

            return sValue;
        }
        public static void SetCofigValue(int iConfigID, string Value)
        {
            tbl_securityConfigValue oConfig = tbl_securityConfigValue.Select(iConfigID);
            if (oConfig != null && oConfig.ConfigValue != "")
            {
                oConfig.ConfigValue = Value;
                oConfig.Update();
            }
            else
            {
                tbl_securityConfigValue oNew = new tbl_securityConfigValue(iConfigID, Value, Value, "default", 0);
                oNew.Insert();
            }
        }

        public static void SetConfigStatus(int iConfigID, bool Value)
        {
            tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(iConfigID);
            if (oConfig != null)
            {
                oConfig.ConfigValue = Value;
                oConfig.Update();
            }
            else
            {
                tbl_securityConfigStatus oNew = new tbl_securityConfigStatus(iConfigID, "", Value, "default");
                oNew.Insert();
            }
        }

        public static bool GetCofigStatus(int iConfigID)
        {
            bool bValue = false;
            tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(iConfigID);
            if (oConfig != null)
                bValue = oConfig.ConfigValue;

            return bValue;
        }

        #region Get Form ID
        public static int getFormID(FormName configForm)
        {
            int iFormID = (int)configForm;
            return iFormID;
        }
        #endregion

        #region Form Permission Area
        public static bool PermissionToRead(string sUserID, int iFormID)
        {
            bool value = false;
            tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowRead)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToSave(string sUserID, int iFormID, bool bIsUpdate)
        {
            return PermissionToSave(sUserID, iFormID, bIsUpdate, true);
        }

        public static bool PermissionToSave(string sUserID, int iFormID, bool bIsUpdate, bool bIsShowMesseges)
        {
            bool value = false;
            tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (bIsUpdate) //if try to update
                {
                    if (detail.AllowUpdate)
                        value = true;
                    else
                    {
                        if (bIsShowMesseges)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToUpdate), iFormID + " - " + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else //if try to insert
                {
                    if (detail.AllowWrite)
                        value = true;
                    else
                    {
                        if (bIsShowMesseges)
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), iFormID + " - " + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToWrite), iFormID + " - " + clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return value;
        }
        public static bool PermissionToDelete(string sUserID, int iFormID)
        {
            bool value = false;
            tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowDelete)
                    value = true;
            }

            if (!value)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return value;
        }
        public static bool PermissionToChecked(string sUserID, int iFormID)
        {
            bool value = false;
            tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowCheckable)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToApproved(string sUserID, int iFormID)
        {
            bool value = false;
            tbl_securityUserPermission detail = tbl_securityUserPermission.Select(sUserID, iFormID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowApprovable)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToApproveProcessNote(string sUserID, int iProcessNoteID)
        {
            bool value = false;
            tbl_securityApprovalPermission detail = tbl_securityApprovalPermission.Select(sUserID, iProcessNoteID);
            if (detail != null)
            {
                if (detail.IsAllow)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToCheckProcessNote(string sUserID, int iProcessNoteID)
        {
            bool value = false;
            tbl_securityCheckingPermission detail = tbl_securityCheckingPermission.Select(sUserID, iProcessNoteID);
            if (detail != null)
            {
                if (detail.IsAllow)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToAuditProcessNote(string sUserID, int iProcessNoteID)
        {
            bool value = false;
            tbl_securityAuditPermission detail = tbl_securityAuditPermission.Select(sUserID, iProcessNoteID);
            if (detail != null)
            {
                if (detail.IsAllow)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToLogging_Branch(string sUserID, string sBranchID)
        {
            bool value = false;
            tbl_securityBranchPermission detail = tbl_securityBranchPermission.Select(sBranchID);
            if (detail != null)
            {
                if (detail.User_ID == sUserID && detail.AllowLogin)
                    value = true;
            }
            return value;
        }
        #endregion

        #region Stock Permission
        //public static bool permissionToRead_StorWise(string sUserID, string sStoreID)
        //{
        //    bool bIsValide = false;
        //    tbl_securityStorePermission oSecurity = tbl_securityStorePermission.Select(sUserID, sStoreID);
        //    if (oSecurity != null && oSecurity.User_ID != "default")
        //        if (oSecurity.AllowRead)
        //            bIsValide = true;
        //    // else
        //    //   MessageBox.Show("You have not Permission to Read", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    return bIsValide;
        //}
        public static bool permissionToSave_Store(string sUserID, string sStoreID, bool bIsUpdate)
        {
            bool bIsValide = false;
            if (sStoreID == "default")
            {
                bIsValide = true;
            }
            else
            {
                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(sStoreID);
                if (oStore != null && oStore.Store_ID != "default")
                {
                    if (!oStore.IsDeleted)
                    {
                        tbl_securityStorePermission oSecurity = tbl_securityStorePermission.Select(sUserID, sStoreID);
                        if (oSecurity != null && oSecurity.User_ID != "default")
                        {
                            if (!bIsUpdate)
                            {
                                if (oSecurity.AllowWrite)
                                    bIsValide = true;
                            }
                            else
                            {
                                if (oSecurity.AllowUpdate)
                                    bIsValide = true;
                            }
                        }
                    }
                }
            }
            if (!bIsValide)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToUpdate_Store), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bIsValide;
        }
        #endregion

        #region Report Permission Area
        public static bool PermissionToPrint(string sUserID, string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(sUserID, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowPrint)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToPrint_WithMessage(string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(clsSecurity.UserIDLoged, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowPrint)
                    value = true;
            }
            if (!value)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToPrint), clsFormatter.GetMessageCaption() + " [" + sReportID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return value;
        }
        public static bool PermissionToPrintOriginal_WithMessage(string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(clsSecurity.UserIDLoged, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowPrintOriginal)
                    value = true;
            }
            if (!value)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToPrint), clsFormatter.GetMessageCaption() + " [" + sReportID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return value;
        }

        public static bool PermissionToRePrint(string sUserID, string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(sUserID, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowRePrint)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToExportReport(string sUserID, string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(sUserID, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowExport)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToViewReport(string sUserID, string sReportID)
        {
            bool value = false;
            tbl_securityReportPermission detail = tbl_securityReportPermission.Select(sUserID, sReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
            if (detail != null)
            {
                if (detail.AllowView)
                    value = true;
            }
            return value;
        }
        #endregion

        #region Report Enable Disable
        public static bool isEnableReportRadioButton(string sUserID, enum_ReportName enm_RPT)
        {
            bool bIsEnable = false;
            tbl_securityReportPermission oUsPermission = tbl_securityReportPermission.Select(sUserID, clsAutocode.getReportID(enm_RPT), clsSecurity.CompanyID, clsSecurity.BranchID);
            if (oUsPermission != null && oUsPermission.User_ID != "default")
                bIsEnable = oUsPermission.AllowView;

            return bIsEnable;
        }
        public static bool isEnableReportRadioButton(enum_ReportName enm_RPT)
        {
            bool bIsEnable = false;
            tbl_securityReportMaster oRpt = tbl_securityReportMaster.Select(clsAutocode.getReportID(enm_RPT));
            if (oRpt != null && oRpt.Report_ID != "default")
                bIsEnable = oRpt.IsEnable;

            return bIsEnable;
        }
        #endregion

        #region Form Petty Cash Permission
        public static bool PermissionToReadPettyCash(string PettyCashAccount, string sUserID)
        {
            bool value = false;
            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(PettyCashAccount, sUserID);
            if (detail != null)
            {
                if (detail.AllowRead)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToWritePettyCash(string PettyCashAccount, string sUserID)
        {
            bool value = false;
            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(PettyCashAccount, sUserID);
            if (detail != null)
            {
                if (detail.AllowWrite)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToDeletePettyCash(string PettyCashAccount, string sUserID)
        {
            bool value = false;
            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(PettyCashAccount, sUserID);
            if (detail != null)
            {
                if (detail.AllowDelete)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToCheckedPettyCash(string PettyCashAccount, string sUserID)
        {
            bool value = false;
            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(PettyCashAccount, sUserID);
            if (detail != null)
            {
                if (detail.AllowCheckable)
                    value = true;
            }
            return value;
        }
        public static bool PermissionToApprovedPettyCash(string PettyCashAccount, string sUserID)
        {
            bool value = false;
            tbl_bpsPettyCashAccount_Permission detail = tbl_bpsPettyCashAccount_Permission.Select(PettyCashAccount, sUserID);
            if (detail != null)
            {
                if (detail.AllowApprovable)
                    value = true;
            }
            return value;
        }
        #endregion

        #region Alert
        public static bool IsAlerts_SheduleEnable(int iSchedule_ID, enum_Alerts enAlert)
        {
            bool value = false;
            try
            {
                string sAlertID = clsAutocode.getAlertID(enAlert);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_utlAlert_Shedule detail = tbl_utlAlert_Shedule.Select(iSchedule_ID, clsAutocode.getAlertID(enAlert), "default");
                    if (detail != null && detail.IsActive)
                    {
                        DateTime dtNow = clsSecurity.getServerDateTime();

                        #region monthly
                        if (detail.IsMonthly)
                        {
                            if (detail.LastAlert_SentTime.Month != dtNow.Month)
                            {
                                DateTime dtmSheduleTime = new DateTime(dtNow.Year, dtNow.Month, detail.SheduledTime.Day, detail.SheduledTime.Hour, detail.SheduledTime.Minute, 0);
                                if (dtmSheduleTime <= dtNow)
                                    value = true;
                            }
                        }
                        #endregion

                        #region daily
                        else if (detail.IsDaily)
                        {
                            int iHour = detail.SheduledTime.Hour;
                            if (dtNow.Date > detail.LastAlert_SentTime.Date && dtNow.Hour >= iHour)
                                value = true;
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(enAlert + " - " + enAlert.ToString() + " Schedule Issue ," ,-1,ex);
            }
            return value;
        }

        public static bool IsAlerts_SheduleEnable(enum_Alerts enAlert)
        {
            return IsAlerts_SheduleEnable(1, enAlert);
        }

        public static void UpdateAlertSentTime(int iSchedule_ID, enum_Alerts enAlert, string AlertID, bool bStatus, string sBranch_ID)
        {
            tbl_utlAlert_Shedule detail = tbl_utlAlert_Shedule.Select(iSchedule_ID, sBranch_ID, AlertID);
            if (bStatus)
            {
                if (detail != null && detail.IsActive)
                {
                    detail.LastAlert_SentTime = clsSecurity.getServerDateTime();
                    detail.IsLocked = false;
                    detail.Update();
                    clsValidate.WriteErrorLog(AlertID + " - " + enAlert.ToString() + " Generated Succesfully ", -1,null);
                }
            }
            else
                clsValidate.WriteErrorLog(AlertID + " - " + enAlert.ToString() + " Generate Failed", -1, null);
        }

        public static void UpdateAlertSentTime(enum_Alerts enAlert, string AlertID, bool bStatus, string sBranch_ID)
        {
            UpdateAlertSentTime(1, enAlert, AlertID, bStatus, sBranch_ID);
        }
        #endregion

        #region Check Product expire date
        public static bool CheckExpireDate()
        {
            bool bIsExpired = false;



            DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();

            if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date.AddDays(-7).Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date)
            {
                MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software will be expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.AddDays(7))
            {
                MessageBox.Show("Please contact 'hepldesk@digiteq.biz' Unless the product will be stopped on " + clsFormatter.FormatDate_Short(dtmProductExpire.AddDays(7)), "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RemoveUsersAfterProductExpired();
            }
            else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.AddDays(7))
            {
                MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired on " + clsFormatter.FormatDate_Short(dtmProductExpire), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                RemoveUsersAfterProductExpired();

                bIsExpired = true;
            }
            else if (clsConfig.bProductActivated == false)
            {
                MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                bIsExpired = true;
            }

            return bIsExpired;
        }
        #endregion

        #region Remove User After Product
        private static void RemoveUsersAfterProductExpired()
        {
            tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(281);
            if (oConfig != null)
            {
                oConfig.ConfigValue = false;
                oConfig.Update();
            }

            foreach (tbl_utlUserPool oPool in tbl_utlUserPool.SelectAll().Where(r => r.LoginStatus_ID != ((int)LoginStatus.Offline).ToString()))
                oPool.IsForceShoutdown = true;

        }
        #endregion
    }
}