using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SEACC_LOGIN.Common;
using SEACC_LOGIN.DataTire;

namespace SEACC_LOGIN
{
    public partial class frmSplash : Form
    {
        
        private int intStatus = 1;
        Timer t = new Timer();
 

        #region Form Load
        public frmSplash()
        {
            InitializeComponent();
            this.BackColor = clsSecurity_Login.color;
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            t.Interval = 300;
            t.Tick += new EventHandler(t_Tick);
            label1.Text = "Loading......";
            t.Start();
        }
        #endregion

        #region Events TimerTick
        public void t_Tick(object sender, EventArgs e)
        {
            switch (intStatus)
            {
                case 1:
                    label1.Text = "Checking Registry......";
                    t.Stop();
                    if (!CheckValidityRegistry())
                    {
                        Program.IsLoginOk = false;
                        this.Dispose();
                        Application.Exit();
                    }
                    t.Start();
                    break;
                case 2:
                    label1.Text = "Checking Company settings......";
                    t.Stop();
                    if (CheckValidity_Company())
                    {
                        this.Dispose();
                        Application.Exit();
                    }
                    t.Start();
                    break;
                case 3:
                    label1.Text = "Checking Terminal......";
                    t.Stop();
                    GetUserPC_Details();
                    t.Start();
                    break;
                case 4:
                    label1.Text = "Checking Modules......";
                    Program.IsFlashOk = true;
                    t.Stop();
                    this.Close();
                    break;
            }

            intStatus++;
        }
        #endregion

        #region Check Validity
        private bool CheckValidityRegistry()
        {
            bool isRegistryOK = true;
            try
            {
                clsSecurity_Login.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

                switch (Application.ProductName.ToLower())
                {
                    case "epack":
                        clsSecurity_Login.RegRegistryName += "1212";
                        break;
                    case "epackt":
                        clsSecurity_Login.RegRegistryName += "1212t";
                        break;
                    case "epackn2":
                        clsSecurity_Login.RegRegistryName += "1212n";
                        break;
                    case "crystal":
                        clsSecurity_Login.RegRegistryName += "1213";
                        break;
                    case "crystalt":
                        clsSecurity_Login.RegRegistryName += "1213t";
                        break;
                    case "crystaln2":
                        clsSecurity_Login.RegRegistryName += "1213n";
                        break;
                    case "max":
                        clsSecurity_Login.RegRegistryName += "2000";
                        break;
                    case "maxt":
                        clsSecurity_Login.RegRegistryName += "2000t";
                        break;
                    case "maxn2":
                        clsSecurity_Login.RegRegistryName += "2000n";
                        break;
                    case "dtq":
                        clsSecurity_Login.RegRegistryName += "2001";
                        break;
                    case "dtqt":
                        clsSecurity_Login.RegRegistryName += "2001t";
                        break;
                    case "dtqn2":
                        clsSecurity_Login.RegRegistryName += "2001n";
                        break;
                    case "chemical":
                        clsSecurity_Login.RegRegistryName += "1215";
                        break;
                    case "chemicalt":
                        clsSecurity_Login.RegRegistryName += "1215t";
                        break;
                    case "chemicaln2":
                        clsSecurity_Login.RegRegistryName += "1215n";
                        break;
                    case "pvc":
                        clsSecurity_Login.RegRegistryName += "1214";
                        break;
                    case "backup":
                        clsSecurity_Login.RegRegistryName += "119";
                        break;
                    default:
                        isRegistryOK = false;
                        break;
                }

                clsSecurity_Login.setRegistryValue();
                DBHandling.DBConnection = "user id=" + clsSecurity_Login.UserName + ";password=" + clsSecurity_Login.Password + ";data source=" + clsSecurity_Login.Server + ";persist security info=true;initial catalog=" + clsSecurity_Login.Database;
            }
            catch (Exception ex)
            {
                isRegistryOK = false;
                clsValidate.WriteErrorLog("", 0,ex);
                string sMsg = " registry error occurred. Please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity_Login.DigiteqTelephone + " Email: " + clsSecurity_Login.DigiteqEmail;
                MessageBox.Show(sMsg, "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isRegistryOK;
        }

        private bool CheckValidity_Company()
        {
            bool bExpired = false;
            try
            {
                tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(clsSecurity_Login.CompanyID);
                if (company == null)
                    bExpired = true;

                if (bExpired)
                    MessageBox.Show("9182 : Data mismatch in tables, Please optimize the database or restore last backup or please contact helpdesk at Digiteq Solution (Pvt) Ltd. Tel: " + clsSecurity_Login.DigiteqTelephone + " Email: " + clsSecurity_Login.DigiteqEmail, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                bExpired = true;
                clsValidate.WriteErrorLog("", 0,ex);
                string sMsg = "Unable to connect with the database. Please exit the system and log again or call your Systems Administrator";

                MessageBox.Show(sMsg, "SEACC Messaging System - [Digiteq]", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bExpired;
        }

        private void GetUserPC_Details()
        {
            try
            {
                clsSecurity_Login.MacAddress = clsSecurity_Login.GetMacAddress();
                clsSecurity_Login.IPAddress = clsSecurity_Login.GetIPAddress();
                clsSecurity_Login.HostName = clsSecurity_Login.GetHostName();

                if (clsRemoteLogin.GetTerminalServerClientNameWTSAPI() != "")
                    clsSecurity_Login.TerminalID = clsRemoteLogin.GetTerminalServerClientNameWTSAPI();
                else
                    clsSecurity_Login.TerminalID = Environment.MachineName;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            
        }
        #endregion
    }
}