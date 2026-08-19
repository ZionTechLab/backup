using DataTire;
using System;
using System.Linq;
 using System.Windows.Forms;
using Digiteq_Logic;
using Digiteq;

namespace SEACC_LOGIN
{
    static class Program
    {
        public static bool isRegistryOK = false;
        public static bool IsFlashOk = false;
        public static bool IsWS_Reg = false;
        public static bool IsLoginOk = false;
        public static bool IsLogOff = false;
        public static string sCompanyBranchID = "";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplash());


            if (IsFlashOk)
            {
                CheckValidityWorkStation();
            }
            if (IsWS_Reg)
            {
                Application.Run(new frmLogin());
            }
            if (IsLoginOk)
            {
                Application.Run(new frmMain(clsSecurity_Login.LoginSession_Index));
            }

        }

        #region Check Validity Workstation
        private static void CheckValidityWorkStation()
        {
            try
            {
                tbl_securityWorkstationRegister oWorkstation = tbl_securityWorkstationRegister.SelectAll().Where(p => p.Terminal_ID == clsSecurity_Login.TerminalID).FirstOrDefault();
                if (oWorkstation == null)
                {
                    bool bPrev_UPool = SEACC_WPFControls.SEACCMessageBox.Show("This Workstation is not Registered.",
                        "\nDo you want to register your workstation?", System.Windows.MessageBoxButton.OKCancel, "#FF5B6B76");

                    if (bPrev_UPool)
                    {
                        bool bDialogResult = SEACCVerifyMessageBox.Show();
                        if (bDialogResult)
                        {
                            SEACC_WPFControls.SEACCMessageBox.Show("Workstation Saved Successfully!",
                                "Your Workstation ID - " + clsSecurity_Login.TerminalID + "\n\nPlease contact your system administrator to approve your workstation", System.Windows.MessageBoxButton.OK);
                        }
                    }
                }
                else if(oWorkstation != null && oWorkstation.IsApproved == false)
                {
                    SEACC_WPFControls.SEACCMessageBox.Show("Workstation Approval Pending!",
                        "Your Workstation ID - " + clsSecurity_Login.TerminalID + "\n\nPlease contact your system administrator to approve your workstation", System.Windows.MessageBoxButton.OK);
                }
                else
                {
                    Program.sCompanyBranchID = oWorkstation.CompanyBranch_ID;
                    Program.IsWS_Reg = true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion
    }
}