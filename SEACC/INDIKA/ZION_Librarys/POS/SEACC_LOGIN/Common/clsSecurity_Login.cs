using System;
using System.IO;
using System.Security.Cryptography;
 using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;
using System.Management;
using SEACC;

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

        public static bool setRegistryValue()
        {
            bool status = false;
            try
            {
                String[] s1 = new String[4];
                string sFolderpath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

                if (File.Exists(sFolderpath + @"\config.cfg"))
                {
                    s1 = configurations.getConfig(sFolderpath);

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

            return Dt;
        }
    }

    //public class clsValidate
    //{
    //    public static void WriteErrorLog(string sError)
    //    {
    //        try
    //        {
    //            string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
    //            File.AppendAllText(logFileName_Local, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);

    //            string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
    //            File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + Environment.NewLine + "-" + Environment.NewLine);
    //        }
    //        catch { }
    //    }
    //    public static void WriteErrorLog(string sError, int iformID)
    //    {
    //        try
    //        {
    //            string logFileName_Local = Path.Combine(@"C:\digiteq\", "ErrorLog_Local.txt");
    //            File.AppendAllText(logFileName_Local, DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine + "-" + Environment.NewLine);

    //            string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
    //            File.AppendAllText(logFileName, DateTime.Now.ToString() + " - " + sError + " - " + iformID + Environment.NewLine + "-" + Environment.NewLine);
    //        }
    //        catch { }
    //    }
    //}
}