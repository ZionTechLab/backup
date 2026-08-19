using System;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Management;
using System.Configuration;

namespace SEACC_LOGIN
{
    public class clsSecurity_Login
    {
        public static string SoftwareBy = "Software By : DigiteQ";
        public static string DigiteqName = "Digiteq Solutions (Pvt) Ltd.";
        public static string DigiteqEmail = "info@digiteq.biz";
        public static string DigiteqTelephone = "+94-115-730077";

        public static string RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

        public static string UserName;
        public static string Password;
        public static string Database;
        public static string Server;
        public static string Domain;


        public static string CompanyID;
        public static string CompanyBranchID;
        public static string TerminalID;
        public static string UserGroupLoged;
        public static string UserGroupIDLoged;
        public static string UserNameLoged;
        public static string UserIDLoged;
        public static string LoginSession_Index;

        public static string MacAddress;
        public static string IPAddress;
        public static string HostName;
        public static System.Drawing.Color color;

        public static bool setRegistryValue()
        {
            bool status = false;
            try
            {
           //     RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);
              //  if (key != null)
              //  {

                    
                    UserName = ConfigurationManager.AppSettings["dbuser"]; // decryptPassword(key.GetValue("dbuser").ToString());
                    Password = ConfigurationManager.AppSettings["dbpassword"];// decryptPassword(key.GetValue("dbpassword").ToString());
                    Database = ConfigurationManager.AppSettings["database"];// decryptPassword(key.GetValue("database").ToString());
                    Server = ConfigurationManager.AppSettings["servername"];// key.GetValue("servername").ToString();
                    Domain = ConfigurationManager.AppSettings["domainName"];// key.GetValue("domainName").ToString();
                    CompanyID = ConfigurationManager.AppSettings["companyname"];// key.GetValue("companyname").ToString();
                    color = System.Drawing.Color.FromName(ConfigurationManager.AppSettings["color"]);//(((int)(((byte)(160)))), ((int)(((byte)(70)))), ((int)(((byte)(10)))));
                    status = true;
               // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registry Error....!", ex.Message);
                //   clsValidate.WriteErrorLog("", 0,ex);
            }
            return status;
        }
        public static string decryptPassword(string str)
        {
            return Decrypt(str, "&%#@?,:*");
        }
        public static string encryptPassword(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
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


        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        public static string GetIPAddress()
        {
            string sIPAddress = "";
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (CheckValidityIPAddress(curAdd.ToString()))
                    {
                        sIPAddress = curAdd.ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
            return sIPAddress;
        }
        public static string GetHostName()
        {
            string macAddresses = Dns.GetHostName();
            return macAddresses;
        }
        public static bool CheckValidityIPAddress(string sIPAddress)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (sIPAddress == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(sIPAddress, 0);
            }
            //return the results
            return valid;
        }

        public static DateTime getServerDateTime()
        {
            DateTime Dt = DateTime.Now;
            string x;
            //SqlConnection scon = DBHandling.GetConnection();
            //scon.Open();
            //SqlCommand scom = new SqlCommand("select getdate()", scon);
            //Dt = DateTime.Parse(scom.ExecuteScalar().ToString().Trim());
            //x = Dt.ToString("yyyy-MM-dd HH:mm:ss.ms");
            //Dt = DateTime.Parse(x);
            //scon.Close();

            return Dt;
        }

        //public static string GetMotherBoardID()
        //{
        //    string motherboardID = "";
        //    ManagementClass bmc = new ManagementClass("Win32_BaseBoard");
        //    ManagementObjectCollection bmoc = bmc.GetInstances();
        //    foreach (ManagementObject bmo in bmoc)
        //    {
        //        motherboardID = bmo.Properties["SerialNumber"].Value.ToString();
        //        Console.WriteLine(motherboardID);
        //    }
        //    return motherboardID;
        //}

        //public static string GetMotherBoardID()
        //{
        //    string mbInfo = String.Empty;
        //    ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
        //    scope.Connect();
        //    ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

        //    foreach (PropertyData propData in wmiClass.Properties)
        //    {
        //        if (propData.Name == "SerialNumber")
        //            mbInfo = String.Format("{0,-25}{1}", propData.Name, Convert.ToString(propData.Value));
        //    }

        //    return mbInfo;
        //}
    }

    public class clsValidate
    {
        //public static void WriteErrorLog(string sError)
        //{
        //    try
        //    {
        //        string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
        //        File.AppendAllText(logFileName_Local, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);

        //        string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
        //        File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);
        //    }
        //    catch { }
        //}
        public static void WriteErrorLog(string sError, int iformID, Exception ex)
        {
            try
            {
                string smsg = DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine +ex.Message+ Environment.NewLine+ ex.StackTrace + "-" + Environment.NewLine+ Environment.NewLine;

                string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
                File.AppendAllText(logFileName_Local, smsg);

                string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                File.AppendAllText(logFileName, smsg);
            }
            catch { }
        }
    }
}