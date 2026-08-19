using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using SEACC_FACTORING.Masters;

namespace SEACC_FACTORING
{
    public partial class frm_Login : Window
    {
        frm_LandingPage homeMainPage;

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
                SEACCMessageBox.Show("Something went wrong...!", ex.ToString(), MessageBoxButton.OK, "#009ACD");
            }
        }
        #endregion

        #region Forgot My Password Button
        private void FotgotMyPassword_Button_Click_1(object sender, RoutedEventArgs e)
        {
            //  frm_forgetPassword oForm = new frm_forgetPassword();
            // oForm.ShowDialog();
        }
        #endregion

        #region Request a New Account Button
        private void btn_RequestNewAccount_Click(object sender, RoutedEventArgs e)
        {
            // frm_RequestNewAccount oForm = new frm_RequestNewAccount();
            // oForm.ShowDialog();
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
                //string sCom = clsSecurity.CompanyID;
                //tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(sCom);
                //if (company != null)
                //{
                //    clsSecurity.CompanyID = company.CompanyID;
                //}
                //else
                //{
                //    SEACCMessageBox.Show("Registry Error....!", "Please contact your system administrator");
                //    bExpired = false;
                //}
            }
            catch (Exception)
            {
                // SEACCMessageBox.Show("Registry Error....!", ex.Message);
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
                //string sTerminalID = "", sMacAddress = "", sIPAddress = "", sHostName = "";
                //sMacAddress = clsHelpMethods.GetMacAddress();
                //sIPAddress = clsHelpMethods.GetIPAddress();
                //sHostName = clsHelpMethods.GetHostName();
                //sTerminalID = sMacAddress + sIPAddress;

                //tbl_securityTerminalMaster objTerminal = tbl_securityTerminalMaster.Select(sTerminalID);
                //if (objTerminal == null)
                //{
                //    tbl_securityTerminalMaster objTerminalNew = new tbl_securityTerminalMaster(sTerminalID, sHostName, sIPAddress, sMacAddress);
                //    objTerminalNew.Insert();
                //}

                ////user pool 
                //bool bInThePool = false;
                //List<tbl_utlUserPool> uPools = tbl_utlUserPool.SelectAllByUser_ID(sUserID);
                //foreach (tbl_utlUserPool uPool in uPools)
                //{
                //    if (sUserID != "admin" && sUserID != "digiteq")
                //    {
                //        bInThePool = true;
                //        uPool.IsForceShoutdown = true;
                //        uPool.Update();
                //        //Thread.Sleep(7000);
                //        break;
                //    }
                //}
                //if (!bInThePool)
                //{
                //    tbl_utlUserPool pool = tbl_utlUserPool.Select(sUserID, sTerminalID);
                //    if (pool == null)
                //    {
                //        tbl_utlUserPool uPoolNew = new tbl_utlUserPool(sUserID, sTerminalID, 1, clsAutocode.getLoginStatusID(LoginStatus.Online), clsSecurity.getServerDateTime(), false, false, true);
                //        uPoolNew.Insert();
                //    }
                //}

                //if (bStatus)
                //    clsSecurity.TerminalID = sTerminalID;
            }
            catch (Exception)
            {
                // clsValidate.WriteErrorLog(ex.Message, 0);
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
                                    SEACCMessageBox.Show("Oops", "Dear User \n Your Account has blocked by System Administrator Plase Contact Administrator to Activate Your Account", MessageBoxButton.OK);

                                else
                                {
                                    clsSecurity.UserIDLoged = detail.User_ID;
                                    clsSecurity.UserNameLoged = detail.UserName;
                                    // clsSecurity.EmployeeIDLoged = detail.EmployeeID;
                                    // clsSecurity.UserImageLoged = clsCommon.Convert_ByteToBitMap(detail.Image);
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

        #endregion

        #region User Login
        private void UserLogin()
        {
            if (CheckValidityUsernameAndPassword())
            {
                homeMainPage = new frm_LandingPage();
                homeMainPage.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsSecurity.UserGroupIDLoged, null, false);
                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.BtnReportClick += GotoReports;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                //homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.IsEnable))
                {
                    if (oModule != null && oModule.IsEnable)
                        homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable).OrderBy(p => p.Function_Code))
                {
                    try
                    {
                        homeMainPage.tbl_Functions.Rows.Add(oForm.Function_ID, oForm.FunctionName, null, oForm.FunctionCategory_ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                homeMainPage.Show();
                this.Close();
            }
        }
        #endregion

        private void HomeMainPage_SystemShutDown()
        {
            this.Close();
        }

        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;

            if (SelectedForm == FormName.Fac_Agrement)
            {
                UC_Factoring_Agreement US = new UC_Factoring_Agreement();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
          
            else if (SelectedForm == FormName.Fac_Schedule)
            {
                UC_FactoringSchedule US = new UC_FactoringSchedule();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            else if (SelectedForm == FormName.Fac_Bank)
            {
                UC_Bank US = new UC_Bank();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            else if (SelectedForm == FormName.Fac_BankBranch)
            {
                UC_BankBranch US = new UC_BankBranch();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            else if (SelectedForm == FormName.Fac_CompanyAccount)
            {
                UC_CompanyAccount US = new UC_CompanyAccount();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Fac_ChequeMgt)
            {
                UC_ChequeManagement US = new UC_ChequeManagement();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Report)
            {
                UC_Report US = new UC_Report();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Fac_Settings)
            {

                UC_AccSettings US = new UC_AccSettings();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
        }

        #region Reports
        private void GotoReports(object sender, EventArgs e)
        {
            UC_Report US = new UC_Report();
            homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
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
    }
}