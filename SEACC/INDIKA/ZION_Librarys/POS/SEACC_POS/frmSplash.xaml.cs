using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;


namespace SEACC_POS
{
    /// <summary>
    /// Interaction logic for frmSplash.xaml
    /// </summary>
    public partial class frmSplash : Window
    {
        #region Class Variables
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        int validationStatus = 0;
        #endregion

        #region Splash Load
        public frmSplash()
        {
            /*
             * Only One instace for one terminal
             */
            //string thisprocessname = Process.GetCurrentProcess().ProcessName;
            //if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            //    Close();

            InitializeComponent();
                     
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
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
                    if (clsHelpMethods_POS.AutoAssignCompanyValue())
                    {
                        if (CheckValidity_Branch())
                            validationStatus = 1;
                    }
                }
                clsSecurity.TerminalID = clsHelpMethods_POS.GetMacAddress() + clsHelpMethods_POS.GetIPAddress();
            }

            if (validationStatus != 1)
                validationStatus = 2;
        }
        #endregion

        #region Btn Close
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        #endregion

        #region Check Validity Registry
        private bool CheckValidityRegistry()
        {
            bool isRegistryOk = true;
            try
            {
                string sProductType = ((AssemblyProductAttribute[])Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)).Single().Product.ToLower();
                clsSecurity.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

                #region Select Product type 
                if (sProductType == "epack")
                {
                    clsSecurity.RegRegistryName += "1212";
                }
                else if (sProductType == "epackt")
                {
                    clsSecurity.RegRegistryName += "1212t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (sProductType == "epackn2")
                {
                    clsSecurity.RegRegistryName += "1212n";
                }
                else if (sProductType == "crystal")
                {
                    clsSecurity.RegRegistryName += "1213";
                }
                else if (sProductType == "crystalt")
                {
                    clsSecurity.RegRegistryName += "1213t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (sProductType == "crystaln2")
                {
                    clsSecurity.RegRegistryName += "1213n";
                }
                else if (sProductType == "chemical")
                {
                    clsSecurity.RegRegistryName += "1215";
                }
                else if (sProductType == "chemicalt")
                {
                    clsSecurity.RegRegistryName += "1215t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (sProductType == "hrcm")
                {
                    clsSecurity.RegRegistryName += "1216";
                }
                else if (sProductType == "hrcmt")
                {
                    clsSecurity.RegRegistryName += "1216t";
                }
                else if (sProductType == "pvc")
                {
                    clsSecurity.RegRegistryName += "1214";
                }
                #endregion

             //   if (!clsSecurity.CheckRegName())
                {
                    SEACCMessageBox.Show(MessegeBoxType.RegistryError);
                    isRegistryOk = false;
                }
            }
            catch (Exception ex)
            {
                isRegistryOk = false;
                SEACCExeption.Show(ex);
            }

            return isRegistryOk;
        }

        #endregion

        #region PassDB Information
        private bool GetConnectionInformation()
        {
            bool status = false;
          //  if (clsSecurity.setRegistryValue(""))
            {
                DBHandling.DBConnection = "user id=" + clsSecurity.UserName + ";password=" + clsSecurity.Password + ";data source=" + clsSecurity.Server + ";persist security info=true;initial catalog=" + clsSecurity.Database;
                status = true;
            }
            return status;
        }
        #endregion

        #region Splash Timer
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            switch (validationStatus)
            {
                case 1:
                    ProgressBar1.Value += 1;
                    if (ProgressBar1.Value == 100)
                    {
                        dispatcherTimer.Stop();
                        frm_Login fLogin = new frm_Login();
                        fLogin.Show();
                        this.Close();
                    }
                    break;
                case 2:
                    Application.Current.Shutdown();
                    break;
            }
        }
        #endregion

        private bool CheckValidity_Branch()
        {
            bool bValid = false;
            try
            {
                tbl_genCompanyBranchMaster company_branch = tbl_genCompanyBranchMaster.SelectAll().FirstOrDefault(r => r.CompanyBranch_ID != "default");
                if (company_branch != null)
                {
                    clsSecurity.BranchID = company_branch.CompanyBranch_ID;
                    bValid = true;
                }

                if (!bValid)
                {
                    SEACCMessageBox.Show("Invalid Branch...", "");
                }
            }
            catch (Exception ex)
            {
                bValid = false;
                SEACCExeption.Show(ex);
            }
            return bValid;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}