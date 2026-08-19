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
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.Diagnostics;
using System.Reflection;
using Digiteq.Widgets;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_Login.xaml
    /// </summary>
    public partial class frm_Login : Window
    {
        #region Form Load
        public frm_Login()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!CheckValidity_Company())
                Application.Current.Shutdown();

            txtUserName.Focus();
        }
        #endregion

        #region Form Drag
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Action Buttons in Login
        #region Sign In Button Click
        private void Btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserLogin();
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog(ex.Message, 0);
                MessageBox.Show("Error", ex.ToString(), MessageBoxButton.OK);
            }
        }
        #endregion

        #region Forgot My Password Button
        private void FotgotMyPassword_Button_Click_1(object sender, RoutedEventArgs e)
        {
            frm_forgetPassword oForm = new frm_forgetPassword();
            oForm.ShowDialog();
        }
        #endregion

        #region Request a New Account Button
        private void btn_RequestNewAccount_Click(object sender, RoutedEventArgs e)
        {
            frm_RequestNewAccount oForm = new frm_RequestNewAccount();
            oForm.ShowDialog();
        }
        #endregion

        #region Form Close Button
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion

        #region Check Validity

        #region Check Validity Company
        private bool CheckValidity_Company()
        {
            bool bExpired = true;
            try
            {
                string sCom = clsSecurity.CompanyID;
                tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(sCom);
                if (company != null)
                {
                    clsSecurity.CompanyID = company.CompanyID;
                    clsSecurity.CompanyRegNo = company.BusinessRegisterNo;
                    clsSecurity.CompanyEPFNo = company.Epf_RegNo;
                }
                else
                {
                    SEACCMessageBox.Show("Registry Error....!", "Please contact your system administrator");
                    bExpired = false;
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Registry Error....!", ex.Message);
                bExpired = false;
            }
            return bExpired;
        }
        #endregion

        #region Check Validity Terminal
        private bool CheckValidityTerminal(string sUserID)
        {
            bool bStatus = true;
            try
            {
                //create terminal
                string sTerminalID = "", sMacAddress = "", sIPAddress = "", sHostName = "";
                sMacAddress = clsHelpMethods.GetMacAddress();
                sIPAddress = clsHelpMethods.GetIPAddress();
                sHostName = clsHelpMethods.GetHostName();
                sTerminalID = sMacAddress + sIPAddress;

                tbl_securityTerminalMaster objTerminal = tbl_securityTerminalMaster.Select(sTerminalID);
                if (objTerminal == null)
                {
                    tbl_securityTerminalMaster objTerminalNew = new tbl_securityTerminalMaster(sTerminalID, sHostName, sIPAddress, sMacAddress);
                    objTerminalNew.Insert();
                }

                //user pool 
                bool bInThePool = false;
                List<tbl_utlUserPool> uPools = tbl_utlUserPool.SelectAllByUser_ID(sUserID);
                foreach (tbl_utlUserPool uPool in uPools)
                {
                    if (sUserID != "admin" && sUserID != "digiteq")
                    {
                        bInThePool = true;
                        uPool.IsForceShoutdown = true;
                        uPool.Update();
                        //Thread.Sleep(7000);
                        break;
                    }
                }
                if (!bInThePool)
                {
                    tbl_utlUserPool pool = tbl_utlUserPool.Select(sUserID, sTerminalID);
                    if (pool == null)
                    {
                        tbl_utlUserPool uPoolNew = new tbl_utlUserPool(sUserID, sTerminalID, 1, getLoginStatusID(LoginStatus.Online), clsSecurity.getServerDateTime(), false, false, true);
                        uPoolNew.Insert();
                    }
                }

                if (bStatus)
                    clsSecurity.TerminalID = sTerminalID;
            }
            catch (Exception ex)
            {
                clsValidation.WriteErrorLog(ex.Message, 0);
                // frmMesageBox Msgfrm = new frmMesageBox(ex.Message.ToString(), true, enum_MessageBoxImage.Error);
                // Msgfrm.ShowDialog();
                // MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return bStatus;
        }
        #endregion

        #region Check Validity Username and Password
        private bool CheckValidityUsernameAndPassword()
        {
            bool bIsPass = false;

            try
            {
                if (txtUserName.Text.Length > 0)
                {
                    tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserName.Text.Trim());
                    if (detail != null)
                    {
                        if (string.Compare(detail.Password, clsSecurity.encryptPassword(txtPassword.Password.Trim()), true) == 0)
                        {
                            if (CheckValidityTerminal(detail.User_ID))
                            {
                                if (detail.IsBlocked)
                                {
                                    SEACCMessageBox.Show("Oops", "Dear User \n Your Account has blocked by System Administrator Plase Contact Administrator to Activate Your Account", MessageBoxButton.OK);
                                }

                                else
                                {
                                    clsSecurity.UserIDLoged = detail.User_ID;
                                    clsSecurity.UserNameLoged = detail.UserName;
                                    clsSecurity.EmployeeIDLoged = detail.EmployeeID;
                                    clsSecurity.UserImageLoged = clsCommon.Convert_ByteToBitMap(detail.Image);
                                    clsSecurity.UserGroupIDLoged = detail.Group_ID;

                                    bIsPass = true;
                                }
                            }
                        }
                        else
                        {
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        txtUserName.SelectAll();
                        txtUserName.Focus();
                    }
                }
                else
                    txtUserName.Focus();
            }
            catch (Exception ex)
            {
                bIsPass = false;
                clsValidation.WriteErrorLog(ex.Message, 0);
                SEACCMessageBox.Show("Oops", ex.Message, MessageBoxButton.OK);
            }
            return bIsPass;

        }
        #endregion

        #region Check Validity User Name and Password Employees
        private bool CheckValidityUserbneandPassword_Employee()
        {
            bool bPass = false;
            try
            {
                if (txtUserName.Text.Length > 0)
                {
                    tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserName.Text.Trim());
                    if (detail != null)
                    {
                        if (string.Compare(detail.Password, clsSecurity.encryptPassword(txtPassword.Password.Trim()), true) == 0)
                        {
                            if (CheckValidityTerminal(detail.User_ID))
                            {
                                if (detail.IsBlocked)
                                {

                                }
                                else if (detail.Group_ID == "6")
                                {
                                    clsSecurity.UserIDLoged = detail.User_ID;
                                    clsSecurity.UserNameLoged = detail.UserName;
                                    clsSecurity.EmployeeIDLoged = detail.EmployeeID;
                                    clsSecurity.UserImageLoged = clsCommon.Convert_ByteToBitMap(detail.Image);
                                    clsSecurity.UserGroupIDLoged = detail.Group_ID;
                                    bPass = true;
                                }
                            }
                        }
                        else
                        {
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        txtUserName.SelectAll();
                        txtUserName.Focus();
                    }
                }
                else
                    txtUserName.Focus();
            }
            catch (Exception ex)
            {
                bPass = false;
                clsValidation.WriteErrorLog(ex.Message, 0);
                SEACCMessageBox.Show("Oops", ex.Message, MessageBoxButton.OK);
            }
            return bPass;
        }
        #endregion
        #endregion

        #region User Login
        private void UserLogin()
        {
            Cursor = Cursors.Wait;
            if (CheckValidityUserbneandPassword_Employee())
            {
                frm_DashBord db = new frm_DashBord(2);
                db.Show();
                this.Close();

            }
            else if (CheckValidityUsernameAndPassword())
            {

                frm_LandingPage Home = new frm_LandingPage();
                Home.Show();
                this.Close();

            }
            Cursor = Cursors.Arrow;
        }
        #endregion

        #region Other Events
        private void lblShowPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }
        private void lblShowPassword_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }
        private void lblShowPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }
        void ShowPassword()
        {
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Hidden;
            txtVisiblePasswordbox.Text = txtPassword.Password;
            lblShowPassword.Foreground = Brushes.Gray;
            txtPassword.Foreground = Brushes.Gray;
        }
        void HidePassword()
        {
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Focus();
            lblShowPassword.Foreground = Brushes.Black;
            txtPassword.Foreground = Brushes.Black;
        }
        #endregion

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show(vk_login.KeyboardOut);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SEACC_WPFControls.frm_LandingPage lp = new SEACC_WPFControls.frm_LandingPage();
            lp.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsRef_Name.get_UserGroup_Name(clsSecurity.UserGroupIDLoged), clsSecurity.UserImageLoged, false);
            lp.Show();
        }

        #region Get Login Status
        string getLoginStatusID(LoginStatus status)
        {
            string sStatusID = "default";
            switch (status)
            {
                case LoginStatus.Online:
                    sStatusID = "1";
                    break;
                case LoginStatus.Idle:
                    sStatusID = "2";
                    break;
                case LoginStatus.Offline:
                    sStatusID = "3";
                    break;
            }
            return sStatusID;
        }
        #endregion

    }
}