using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using DataTire;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Microsoft.Win32;
using Ionic.Zip;

namespace BackupService
{

}

namespace Digiteq_Logic
{
    class clsValidate
    {
       
    }

    class clsSecurity
    {
        //public static string UserName;
        //public static string Password;
        public static string Database;
        //public static string Server;
        //public static string Domain;
        private static string regRegistryName = "Software\\52465123-sys\\456465465461312313111321";// + "1212";

        public static void setRegName()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);
            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(RegRegistryName);
            }






        }
        public static string getRegDBDomainName()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("domainName").ToString();

            return result;
        }
        public static string RegRegistryName
        {
            get { return clsSecurity.regRegistryName; }
            set { clsSecurity.regRegistryName = value; }
        }
        public static string getRegServerName()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("servername").ToString();

            return result;
        }
        public static string getRegDatabaseName()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("database").ToString();

            return result;
        }
        public static string getRegDBUserPassword()
        {
            // Attempt to open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);

            string result = key.GetValue("dbpassword").ToString();

            return result;
        }
        public static string getRegDBUserName()
        {
            // Attempt to open the key
            string result = "";
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(RegRegistryName);
                result = key.GetValue("dbuser").ToString();
            }
            catch { }
            return result;
        }
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
        public static string decryptPassword(string str)
        {
            return Decrypt(str, "&%#@?,:*");
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
    }

    class clsFormatter
    {
        public static string DigiteqTitle = "";
    }
    class clsProcessMethods
    {
        public static void ArchiveDirectory(string DirectryPath, string ZipFileName)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = "d1g1t3q@123@456";
                zip.AddDirectory(DirectryPath);
             //   zip.MaxOutputSegmentSize = 50*1024 * 1024;//50mb
                zip.SaveProgress += zip_SaveProgress;
                zip.UseZip64WhenSaving = Zip64Option.AsNecessary;
                zip.Save(ZipFileName);
            }
        }
        public static void scon_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            //sb.AppendLine(clsSecurity.getServerDateTime() + " - " + e.Message);
            int iPresentage = 0;
            if (e.Message.Contains(" percent processed."))
            {
                iPresentage = int.Parse(e.Message.Replace(" percent processed.", ""));
            }

        }
        public static void zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                // MessageBox.Show("Begin Saving: " + e.ArchiveName);
            }

            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {

            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                //    MessageBox.Show("Done: " + e.ArchiveName);
            }
        }
    }
}
