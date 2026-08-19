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
using System.Windows.Shapes;
using System.Reflection;
using System.Threading;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Configuration;

namespace Digiteq
{
    public partial class frmSplash : Window
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int validationStatus = 0;

        #region Form Load
        public frmSplash()
        {
            InitializeComponent();

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            ProgressBar1.Value = 99;
            dispatcherTimer.Start();

            Thread initThread = new Thread(new ThreadStart(InitializationThread));
            initThread.SetApartmentState(ApartmentState.STA);
            initThread.Start();
        }

        public void InitializationThread()
        {
            clsSecurity.DB_UserName = ConfigurationManager.AppSettings["dbuser"];// clsSecurity.decryptPassword(key.GetValue("dbuser").ToString());
            clsSecurity.DB_Password = ConfigurationManager.AppSettings["dbpassword"]; //clsSecurity.decryptPassword(key.GetValue("dbpassword").ToString());
            clsSecurity.DB_Database = ConfigurationManager.AppSettings["database"]; //clsSecurity.decryptPassword(key.GetValue("database").ToString());
            clsSecurity.DB_Server = ConfigurationManager.AppSettings["servername"];// key.GetValue("servername").ToString();
            clsSecurity.DB_Domain = ConfigurationManager.AppSettings["domainName"];// key.GetValue("domainName").ToString();
            clsSecurity.CompanyID = ConfigurationManager.AppSettings["companyname"];// key.GetValue("companyname").ToString();
            DBHandling.DBConnection = "user id=" + clsSecurity.DB_UserName + ";password=" + clsSecurity.DB_Password + ";data source=" + clsSecurity.DB_Server + ";persist security info=true;initial catalog=" + clsSecurity.DB_Database;
            ZION.HRCM.DATA.    DBHandling.ConnectionString =DBHandling.DBConnection;
            if (clsSecurity.AutoAssignCompanyValue())
            {
                validationStatus = 1;
            }
            clsSecurity.TerminalID = clsHelpMethods.GetMacAddress() + clsHelpMethods.GetIPAddress();

            if (validationStatus != 1)
                validationStatus = 2;
        }
        #endregion


        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (validationStatus == 1)
            {
                ProgressBar1.Value += 1;
                if (ProgressBar1.Value == 100)
                {
                    dispatcherTimer.Stop();
                    frm_Login fLogin = new frm_Login();

                    #region Check Product expire date
                    clsBackProcess.AutoAssignConfigValue();
                    clsBackProcess.AutoAssignConfigStatus();

                    //DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();
                    //if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date.AddDays(-7).Date)
                    //{
                       fLogin.Show();
                       this.Close();
                    //}
                    //else if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date.AddDays(-7).Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date)
                    //{
                    //    SEACCMessageBox.Show("Software will be expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK);
                    //    fLogin.Show();
                    //    this.Close();
                    //}
                    //else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.AddDays(7))
                    //{
                    //    SEACCMessageBox.Show("Software has been expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz' Unless the product will be stopped on " + clsValidation.GetDisplayValue_Date(dtmProductExpire.AddDays(7)), MessageBoxButton.OK, "Red");

                    //    tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(7);
                    //    if (oConfig != null)
                    //    {
                    //        oConfig.ConfigValue = false;
                    //        oConfig.Update();

                    //        fLogin.Show();
                    //        this.Close();
                    //    }
                    //    else
                    //    {
                    //        Application.Current.Shutdown();
                    //    }
                    //}
                    //else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.AddDays(7))
                    //{
                    //    SEACCMessageBox.Show("Software has been expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK, "Red");

                    //    tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(7);
                    //    if (oConfig != null)
                    //    {
                    //        oConfig.ConfigValue = false;
                    //        oConfig.Update();
                    //    }

                    //    Application.Current.Shutdown();
                    //}
                    //else if (clsConfig.bProductActivated == false)
                    //{
                    //    SEACCMessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK, "Red");
                    //    Application.Current.Shutdown();
                    //}
                    #endregion
                }
            }
            else if (validationStatus == 2)
            {
                Application.Current.Shutdown();
            }
        }

        private void Btn_Name_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}