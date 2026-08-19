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
using Digiteq;

namespace SEACC_FACTORING
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
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
                    if (clsSecurity.AutoAssignCompanyValue())
                        validationStatus = 1;
                }
                clsSecurity.TerminalID = Common.clsHelpMethods.GetMacAddress() + Common.clsHelpMethods.GetIPAddress();
            }

            if (validationStatus != 1)
                validationStatus = 2;
        } 
        #endregion

        #region Button Events
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                if (ProductType == "epack")
                {
                    clsSecurity.RegRegistryName += "1212";
                }
                else if (ProductType == "epackt")
                {
                    clsSecurity.RegRegistryName += "1212t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "epackn2")
                {
                    clsSecurity.RegRegistryName += "1212n";
                }
                else if (ProductType == "crystal")
                {
                    clsSecurity.RegRegistryName += "1213";
                }
                else if (ProductType == "crystalt")
                {
                    clsSecurity.RegRegistryName += "1213t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "crystaln2")
                {
                    clsSecurity.RegRegistryName += "1213n";
                }
                else if (ProductType == "chemical")
                {
                    clsSecurity.RegRegistryName += "1215";
                }
                else if (ProductType == "chemicalt")
                {
                    clsSecurity.RegRegistryName += "1215t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "hrcm")
                {
                    clsSecurity.RegRegistryName += "1216";
                    //   clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "hrcmt")
                {
                    clsSecurity.RegRegistryName += "1216t";
                    //   clsConfig.bIsTestLabelVisibleInMainForm = true;
                }
                else if (ProductType == "pvc")
                {
                    clsSecurity.RegRegistryName += "1214";
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
                DBHandling.DBConnection = "user id=" + clsSecurity.UserName + ";password=" + clsSecurity.Password + ";data source=" + clsSecurity.Server + ";persist security info=true;initial catalog=" + clsSecurity.Database;
                // DBHandling.DBConnection = "Data Source=220.247.241.183\\DTQ,4533;Initial Catalog=SEACC_HRCM;User ID=sa;Password=nimda@123;";
                status = true;
            }
            return status;
        }
        #endregion

        #region Splash Timer
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (validationStatus == 1)
            {
                ProgressBar1.Value += 1;
                if (ProgressBar1.Value == 100)
                {
                    dispatcherTimer.Stop();
                    frm_Login fLogin = new frm_Login();
                    fLogin.Show();
                    this.Close();
                }
            }
            else if (validationStatus == 2)
            {
                Application.Current.Shutdown();
            }
        }       
        #endregion
    }
}