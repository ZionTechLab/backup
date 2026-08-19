using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

using System.Security.Cryptography;

namespace SEACC_Reg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        private string GetRegistryName()
        {
            // bool isRegistryOK = true;
            string RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";
            switch (txtRegType.Text.ToLower())
            {
                case "epack":
                    RegRegistryName += "1212";
                    break;
                case "epackt":
                    RegRegistryName += "1212t";
                    break;
                case "epackn2":
                    RegRegistryName += "1212n";
                    break;
                case "crystal":
                    RegRegistryName += "1213";
                    break;
                case "crystalt":
                    RegRegistryName += "1213t";
                    break;
                case "crystaln2":
                    RegRegistryName += "1213n";
                    break;
                case "max":
                    RegRegistryName += "2000";
                    break;
                case "maxt":
                    RegRegistryName += "2000t";
                    break;
                case "maxn2":
                    RegRegistryName += "2000n";
                    break;
                case "dtq":
                    RegRegistryName += "2001";
                    break;
                case "dtqt":
                    RegRegistryName += "2001t";
                    break;
                case "dtqn2":
                    RegRegistryName += "2001n";
                    break;
                case "chemical":
                    RegRegistryName += "1215";
                    break;
                case "chemicalt":
                    RegRegistryName += "1215t";
                    break;
                case "chemicaln2":
                    RegRegistryName += "1215n";
                    break;
                case "hrcm":
                    RegRegistryName += "1216";
                    break;
                case "hrcm1":
                    RegRegistryName += "12161";
                    break;
                case "hrcm2":
                    RegRegistryName += "12162";
                    break;
                case "hrcm3":
                    RegRegistryName += "12163";
                    break;
                case "hrcm4":
                    RegRegistryName += "12164";
                    break;
                case "hrcmt":
                    RegRegistryName += "1216t";
                    break;
                case "hrcm1t":
                    RegRegistryName += "12161t";
                    break;
                case "hrcm2t":
                    RegRegistryName += "12162t";
                    break;
                case "hrcm3t":
                    RegRegistryName += "12163t";
                    break;
                case "hrcm4t":
                    RegRegistryName += "12164t";
                    break;
                case "hrcmn2":
                    RegRegistryName += "1216n";
                    break;
                case "hrcm1n2":
                    RegRegistryName += "12161n";
                    break;
                case "hrcm2n2":
                    RegRegistryName += "12162n";
                    break;
                case "hrcm3n2":
                    RegRegistryName += "12163n";
                    break;
                case "hrcm4n2":
                    RegRegistryName += "12164n";
                    break;
                case "pvc":
                    RegRegistryName += "1214";
                    break;
                case "backup":
                    RegRegistryName += "119";
                    break;
                default:
                    break;
            }
            setRegName(RegRegistryName);
            return RegRegistryName;
        }
      
        public void setRegName(string Reg)
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(Reg);

            if (key == null)
            {
                key = Registry.LocalMachine.CreateSubKey(Reg);
            }

        }

        public  void setRegValues(string reg)
        {

            // Open the key
            RegistryKey key = Registry.LocalMachine.OpenSubKey(reg, true);

            // Set the registry values to correspond to the form's coordinates on the
            // screen.
            key.SetValue("servername", txtServer.Text.Trim());
            key.SetValue("database", encryptPassword(txtDB.Text.Trim()));
            key.SetValue("dbuser", encryptPassword(txtUser.Text.Trim()));
            key.SetValue("dbpassword", encryptPassword(txtPW.Password.Trim()));
            key.SetValue("outlet", "");
            key.SetValue("terminal", "");
            key.SetValue("companyname", txtCom.Text.Trim());
            key.SetValue("valied", "");
            key.SetValue("registryName", reg);
            key.SetValue("domainName", "");

        }

        public  bool setRegistryValue(string reg)
        {
            bool status = false;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(reg);

                txtUser.Text = decryptPassword(key.GetValue("dbuser").ToString());
                txtPW.Password= decryptPassword(key.GetValue("dbpassword").ToString());
                txtDB.Text = decryptPassword(key.GetValue("database").ToString());
                txtServer.Text = key.GetValue("servername").ToString();
              //  clsSecurity.DB_Domain = key.GetValue("domainName").ToString();
                txtCom.Text = key.GetValue("companyname").ToString();
                status = true;
            }
            catch (Exception ex)
            {
               // SEACCMessageBox.Show("Registry Error....!", ex.Message);
              //  clsValidate.WriteErrorLog(ex.Message, 0);
            }
            return status;
        }
    
        public  string encryptPassword(string strText)
        {
            return Encrypt(strText, "&%#@?,:*");
        }

        public  string decryptPassword(string str)
        {
            return Decrypt(str, "&%#@?,:*");
        }

        private  string Encrypt(string strText, string strEncrypt)
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
        private  string Decrypt(string strText, string strEncrypt)
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
                // throw ex;
            }
        }
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (txtRegType.Text.ToLower() != "")
            {
                setRegValues(GetRegistryName());
                MessageBox.Show("Registry Created", "SEACC Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnRetreve_Click(object sender, RoutedEventArgs e)
        {
           if( txtRegType.Text.ToLower()!="")
            setRegistryValue(GetRegistryName());
        }

        private void GRD_Titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.DragMove();
            //    bIsmaximized = false;
                this.Margin = new Thickness(8);
            }
            catch (Exception)
            {
            }
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            //if (bIsmaximized)
            //{
            //    System.Windows.Forms.Screen Scr = System.Windows.Forms.Screen.FromPoint(System.Windows.Forms.Cursor.Position);
            //    bIsmaximized = false;
            //    this.Height = Scr.WorkingArea.Height / 2;
            //    this.Width = Scr.WorkingArea.Width / 2;
            //    this.Left = Scr.Bounds.Location.X + Scr.Bounds.Width / 4;
            //    this.Top = Scr.Bounds.Location.Y + Scr.WorkingArea.Height / 4;
            //    this.Margin = new Thickness(8);
            //}
            //else
            //{
            //    this.WindowState = WindowState.Maximized;
            //    bIsmaximized = true;

            //}
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}