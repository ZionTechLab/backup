using System;
 using System.Windows.Forms;
using DataTire;
using SEACC_LOGIN.Common;
using Digiteq_Logic;
using Digiteq;
namespace SEACC_LOGIN
{
    public partial class frmSplash : Form
    {
        #region Variables
        private int intStatus = 1;
        Timer t = new Timer();
        #endregion

        #region Form Load
        public frmSplash()
        {
            InitializeComponent();
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
                isRegistryOK = clsSecurity_Login.setRegistryValue();
                if (isRegistryOK)
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