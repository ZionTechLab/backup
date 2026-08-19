using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEACC_Cryptography
{
    public partial class frmMain : Form
    {
        //  string path = "config.ini";
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtServer;
            txtServer.Focus();

            //   if (!File.Exists(path))
            //     File.Create(path);
        }
        private void btnGenerated_Click(object sender, EventArgs e)
        {
            try
            {
                string logFileName = Path.Combine(Application.StartupPath, "config.ini");
                if (File.Exists(logFileName))
                    File.Delete(logFileName);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(encryptPassword(txtServer.Text));
                sb.AppendLine(encryptPassword(txtDatabase.Text));
                sb.AppendLine(encryptPassword(txtUserName.Text));
                sb.AppendLine(encryptPassword(txtPassword.Text));

                File.AppendAllText(logFileName, sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //if (File.Exists(path))
            //{
            //    //using (StreamWriter sw = File.CreateText(path))
            //    {
            //        sw.WriteLine(encryptPassword(txtServer.Text));
            //        sw.WriteLine(encryptPassword(txtDatabase.Text));
            //        sw.WriteLine(encryptPassword(txtUserName.Text));
            //        sw.WriteLine(encryptPassword(txtPassword.Text));
            //    }
            //}

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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Dispose();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGenerated_Click(null, null);

        }

        

    }
}
