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
            if (CheckValidityRegistry())
            {
                if (GetConnectionInformation())
                {
                    if (clsSecurity.AutoAssignCompanyValue())
                    {
                        validationStatus = 1;
                    }
                }
                clsSecurity.TerminalID = clsHelpMethods.GetMacAddress() + clsHelpMethods.GetIPAddress();
            }

            if (validationStatus != 1)
                validationStatus = 2;
        }
        #endregion

        #region Check Validity Registry
        private bool CheckValidityRegistry()
        {
            bool isRegistryOK = true;
            try
            {
                string ProductType = ((AssemblyProductAttribute[])Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)).Single().Product.ToLower();
                clsSecurity.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

                #region Select Product type
                switch (ProductType)
                {
                    case "hrcm":
                        clsSecurity.RegRegistryName += "1216";
                        break;
                    case "hrcm1":
                        clsSecurity.RegRegistryName += "12161";
                        break;
                    case "hrcm2":
                        clsSecurity.RegRegistryName += "12162";
                        break;
                    case "hrcm3":
                        clsSecurity.RegRegistryName += "12163";
                        break;
                    case "hrcm4":
                        clsSecurity.RegRegistryName += "12164";
                        break;
                    case "hrcmt":
                        clsSecurity.RegRegistryName += "1216t";
                        break;
                    case "hrcm1t":
                        clsSecurity.RegRegistryName += "12161t";
                        break;
                    case "hrcm2t":
                        clsSecurity.RegRegistryName += "12162t";
                        break;
                    case "hrcm3t":
                        clsSecurity.RegRegistryName += "12163t";
                        break;
                    case "hrcm4t":
                        clsSecurity.RegRegistryName += "12164t";
                        break;
                    case "hrcmn2":
                        clsSecurity.RegRegistryName += "1216n";
                        break;
                    case "hrcm1n2":
                        clsSecurity.RegRegistryName += "12161n";
                        break;
                    case "hrcm2n2":
                        clsSecurity.RegRegistryName += "12162n";
                        break;
                    case "hrcm3n2":
                        clsSecurity.RegRegistryName += "12163n";
                        break;
                    case "hrcm4n2":
                        clsSecurity.RegRegistryName += "12164n";
                        break;
                    default:
                        break;
                }
                #endregion

                if (!clsSecurity.CheckRegName())
                {
                    SEACCMessageBox.Show(MessegeBoxType.RegistryError);
                    isRegistryOK = false;
                }
            }
            catch (Exception ex)
            {
                isRegistryOK = false;
                clsValidation.WriteErrorLog(ex.Message, 0);
                SEACCMessageBox.Show(MessegeBoxType.RegistryError);
            }

            return isRegistryOK;
        }
        #endregion

        #region PassDB Information
        private bool GetConnectionInformation()
        {
            bool status = false;
            if (clsSecurity.setRegistryValue())
            {
                DBHandling.DBConnection = "user id=" + clsSecurity.DB_UserName + ";password=" + clsSecurity.DB_Password + ";data source=" + clsSecurity.DB_Server + ";persist security info=true;initial catalog=" + clsSecurity.DB_Database;
                // DBHandling.DBConnection = "Data Source=220.247.241.183\\DTQ,4533;Initial Catalog=SEACC_HRCM;User ID=sa;Password=nimda@123;";
                status = true;
            }
            return status;
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

                    DateTime dtmProductExpire = clsSecurity.GetSystemExpireDate();
                    if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date.AddDays(-7).Date)
                    {
                        fLogin.Show();
                        this.Close();
                    }
                    else if (clsConfig.bProductActivated == true && clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date.AddDays(-7).Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.Date)
                    {
                        SEACCMessageBox.Show("Software will be expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK);
                        fLogin.Show();
                        this.Close();
                    }
                    else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsSecurity.getServerDateTime().Date < dtmProductExpire.AddDays(7))
                    {
                        SEACCMessageBox.Show("Software has been expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz' Unless the product will be stopped on " + clsValidation.GetDisplayValue_Date(dtmProductExpire.AddDays(7)), MessageBoxButton.OK, "Red");

                        tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(7);
                        if (oConfig != null)
                        {
                            oConfig.ConfigValue = false;
                            oConfig.Update();

                            fLogin.Show();
                            this.Close();
                        }
                        else
                        {
                            Application.Current.Shutdown();
                        }
                    }
                    else if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.AddDays(7))
                    {
                        SEACCMessageBox.Show("Software has been expired on " + clsValidation.GetDisplayValue_Date(dtmProductExpire), "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK, "Red");

                        tbl_securityConfigStatus oConfig = tbl_securityConfigStatus.Select(7);
                        if (oConfig != null)
                        {
                            oConfig.ConfigValue = false;
                            oConfig.Update();
                        }

                        Application.Current.Shutdown();
                    }
                    else if (clsConfig.bProductActivated == false)
                    {
                        SEACCMessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz'", MessageBoxButton.OK, "Red");
                        Application.Current.Shutdown();
                    }
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

        private void WelcomeNote()
        {
            int stepCounter = 0;
            string sText = "Welcome to the real world of Office ERP Software";
            string sDisplayTest = string.Empty;


            foreach (char item in sText)
            {
                // lblDisplay.Visibility = Visibility.Hidden;
                //sDisplayTest += item;
                //lblDisplay.Content = sDisplayTest;
                //Thread.Sleep(10);
                //lblDisplay.Visibility = Visibility.Visible;
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}