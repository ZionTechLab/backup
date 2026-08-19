using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Linq;
using System.Windows.Media.Imaging;
using System.IO;
using SEACC_POS.UserManagement;
using Digiteq_Logic_POS;
using SEACC_POS.TransactionForms;
using SEACC_POS.Controls;
using SEACC_POS.Common;

namespace SEACC_POS
{
    /// <summary>
    /// Interaction logic for frm_Login.xaml
    /// </summary>
    public partial class frm_Login : Window
    {
        #region Class Variables
        frm_LandingPage homeMainPage;
        #endregion

        #region MyRegion
        public frm_Login()
        {
            InitializeComponent();
            clsBackProcess_POS.AutoAssignConfigStatus();
            clsBackProcess_POS.AutoAssignConfigStatus_POS();
            clsBackProcess_POS.AutoAssignConfigValue();
            clsBackProcess_POS.AutoAssignConfigValue_POS();
            clsSecurity.FinancialYearID = clsMethods_GL.getFinancialYear_ID_Current();
        }

        private void frmLogin_Loaded(object sender, RoutedEventArgs e)
        {
            if (!CheckValidity_Company())
                Application.Current.Shutdown();

            Refresh_BranchCmb();
            txtUserName.Focus();
        }

        private void Refresh_BranchCmb()
        {
            cmbCompanyBranchID.SelectedIndex = -1;

            foreach (tbl_genCompanyBranchMaster oDetail in tbl_genCompanyBranchMaster.SelectAll())
            {
                if (oDetail.CompanyBranch_ID != "default")
                {
                    System.Windows.Controls.ComboBoxItem item = new System.Windows.Controls.ComboBoxItem();
                    item.Content = oDetail.BranchName;
                    item.Tag = oDetail.CompanyBranch_ID;
                    cmbCompanyBranchID.Items.Add(item);
                }
            }
            if (cmbCompanyBranchID.Items.Count > 0)
                cmbCompanyBranchID.SelectedIndex = 0;
        }

        private void frmLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

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
            catch (Exception ex)
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
                        if (string.Compare(detail.Password, clsSecurity.encryptPassword(txtPassword.Password.Trim()), StringComparison.Ordinal) == 0)
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
                clsValidate.WriteErrorLog("",0,ex);
                SEACCMessageBox.Show("Oops", ex.Message, MessageBoxButton.OK);
            }
            return bIsPass;

        }
        #endregion
        #endregion

        #region Action Buttons
        private void Btn_SignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsSecurity.BranchID = ((System.Windows.Controls.ComboBoxItem)cmbCompanyBranchID.SelectedItem).Tag.ToString();
                UserLogin();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Something went wrong...", ex.ToString(), MessageBoxButton.OK);
                this.Close();
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion

        #region User Login
        private void UserLogin()
        {
            if (clsSecurity.CheckExpireDate())
            {
                Application.Current.Shutdown();
            }

            Cursor = Cursors.Wait;
            if (CheckValidityUsernameAndPassword())
            {
                tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                if (oCompany != null)
                {
                    clsSecurity.CompanyName = clsCript.Decrypt(oCompany.CompanyName);
                    clsSecurity.CompanyAddress1 = clsCript.Decrypt(oCompany.Address);

                    clsSecurity.CompanyAddress2 = "";
                    if (oCompany.Telephone1.Length > 0)
                        clsSecurity.CompanyAddress2 = "Tel:" + oCompany.Telephone1;
                    if (oCompany.Telephone2.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + oCompany.Telephone2;
                    if (oCompany.Fax.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + " FAX:" + oCompany.Fax;
                }

                //if (clsConfig_POS.bRemoteDesktopMode)
                //{
                //    try
                //    {
                //        clsSecurity.TerminalID = RemoteLogin.GetTerminalServerClientNameWTSAPI();
                //    }
                //    catch (Exception ex)
                //    {
                //        SEACCExeption.Show(ex);
                //    }
                //}

                homeMainPage = new frm_LandingPage(int.Parse(clsConfig_POS.sPoS_SystemLogout_IdleSeconds));
                homeMainPage.usrIndicator.SetUser(clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID) + " - " + clsSecurity.UserIDLoged, clsSecurity.UserGroupIDLoged, GetUserImage(clsSecurity.UserIDLoged), false);//GetUserImage(clsSecurity.UserIDLoged)
                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.BtnReportClick += GotoReports;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => (p.Module_ID == "FCT/013" || p.Module_ID == "ADM/000" || p.Module_ID == "USER/017") && p.IsEnable).OrderBy(p => p.SortOrder))
                {
                    if (oModule.IsEnable)
                        homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll()
                                                                                            .Where(r => r.IsEnable && !r.IsReport &&
                                                                                                   !r.FunctionName.Contains("Report")).OrderBy(p => p.Function_Code))
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
                Close();

            }
            Cursor = Cursors.Arrow;
        }

        private void HomeMainPage_SystemShutDown()
        {
            Application.Current.Shutdown();
        }

        private void GotoReports(object sender, EventArgs e)
        {
            UC_Reports US = new UC_Reports();
            homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }

        private void HomeMainPage_FunctionSelected(int iFormId)
        {
            FormName selectedForm = (FormName)iFormId;

            switch (selectedForm)
            {
                case FormName.POS_UserDashBoard:
                    UC_UserDashboard uc9480 = new UC_UserDashboard();
                    homeMainPage.Open_NewTabpage(uc9480, uc9480.SEACC_Form.PermissionTO_Read, uc9480.SEACC_Form.FormName, uc9480.SEACC_Form.FormID);
                    break;

                case FormName.UserPermission:
                    UC_UserPermission uc27 = new UC_UserPermission();
                    homeMainPage.Open_NewTabpage(uc27, uc27.SEACC_Form.PermissionTO_Read, uc27.SEACC_Form.FormName, uc27.SEACC_Form.FormID);
                    break;

                case FormName.POS_CashierSignIn:
                    UC_Cashier_SignIn uc9090 = new UC_Cashier_SignIn();
                    homeMainPage.Open_NewTabpage(uc9090, uc9090.SEACC_Form.PermissionTO_Read, uc9090.SEACC_Form.FormName, uc9090.SEACC_Form.FormID);
                    break;

                case FormName.POS_Transaction:
                    tbl_posDayStartAndEnd_Detail oCashierSignIn_Activated = tbl_posDayStartAndEnd_Detail.SelectAll()
                                                                                .Where(r => r.SignInCashier_ID == clsSecurity.UserIDLoged &&
                                                                                            !r.IsMgtSignOffCreated && !r.IsCanceled &&
                                                                                            r.PosTerminal_ID.Trim() == clsSecurity.TerminalID.Trim() &&
                                                                                            r.PosDate.Date == clsSecurity.getServerDateTime().Date)
                                                                                .OrderByDescending(r => r.DateCreated).FirstOrDefault();
                    if (oCashierSignIn_Activated != null)
                    {
                        tbl_posDayStartAndEnd oBranchDay = tbl_posDayStartAndEnd.Select(oCashierSignIn_Activated.DayIndex);
                        if (oBranchDay.CompanyBranch_ID == clsSecurity.BranchID)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation...", "Are you sure to open the POS Transaction window ?", MessageBoxButton.YesNo, "#FF5B6B76");
                            if (bMessegeBoxResult)
                            {
                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                frmTwoStepVerify.ShowDialog();
                                if (frmTwoStepVerify.bVerified)
                                {
                                    OpenPOS_TransactionWndow(oCashierSignIn_Activated.DayDetail_Index);
                                }
                                frmTwoStepVerify.Close();
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Restricted...", "You don't have valid session for start POS Transactions...", MessageBoxButton.OK, "Red");
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Restricted...", "You don't have valid session for start POS Transactions...", MessageBoxButton.OK, "Red");
                    }
                    break;

                case FormName.POS_GiftVoucherCreation:
                    UC_GiftVoucher_Creation uc9110 = new UC_GiftVoucher_Creation();
                    homeMainPage.Open_NewTabpage(uc9110, uc9110.SEACC_Form.PermissionTO_Read, uc9110.SEACC_Form.FormName, uc9110.SEACC_Form.FormID);
                    break;

                case FormName.POS_ManagerSignOff:
                    UC_Manager_SignOff uc9115 = new UC_Manager_SignOff();
                    homeMainPage.Open_NewTabpage(uc9115, uc9115.SEACC_Form.PermissionTO_Read, uc9115.SEACC_Form.FormName, uc9115.SEACC_Form.FormID);
                    break;

                case FormName.POS_BranchDayEnd:
                    UC_Branch_DayEnd uc9117 = new UC_Branch_DayEnd();
                    homeMainPage.Open_NewTabpage(uc9117, uc9117.SEACC_Form.PermissionTO_Read, uc9117.SEACC_Form.FormName, uc9117.SEACC_Form.FormID);
                    break;

                case FormName.POS_BranchWiseStoreStock:
                    UC_BranchStoreStock uc9120 = new UC_BranchStoreStock();
                    homeMainPage.Open_NewTabpage(uc9120, uc9120.SEACC_Form.PermissionTO_Read, uc9120.SEACC_Form.FormName, uc9120.SEACC_Form.FormID);
                    break;
            }

            #region Check Expiration Date
            if (clsConfig.dtmDateExpiration < DateTime.Now)
            {
                MessageBox.Show("Product has been Expired..... \nPlease contact Digiteq for more details");
                Application.Current.Shutdown();
            }
            #endregion
        }

        private void OpenPOS_TransactionWndow(int iSession_dayDetail_Index)
        {
            Frm_Item_Sales frmPosSalesOld = Application.Current.Windows.OfType<Frm_Item_Sales>().FirstOrDefault(w => w.Name.Equals("frmPosSalesWindow"));
            if (frmPosSalesOld != null)
            {
                SEACCMessageBox.Show("'POS Transaction Window' already opened...!!!", "You can not open it again...", MessageBoxButton.OK, "Red");
                homeMainPage.Topmost = false;
                frmPosSalesOld.WindowState = WindowState.Maximized;
                frmPosSalesOld.Topmost = true;
            }
            else
            {
                tbl_genStoreMaster oBranchMainStore = tbl_genStoreMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.IsMainStore).ToList().FirstOrDefault();
                if (oBranchMainStore != null)
                {
                    Frm_Item_Sales frmPosSales = new Frm_Item_Sales(iSession_dayDetail_Index);
                    if (frmPosSales.SEACC_Form.PermissionTO_Read)
                        frmPosSales.Show();
                }
                else
                {
                    SEACCMessageBox.Show("Something Went Wrong in Item Store...!!!", "Please set the main store of this POS branch...", MessageBoxButton.OK, "Red");
                }
            }
        }

        private BitmapImage GetUserImage(string userIdLoged)
        {
            BitmapImage bmpUserImg = null;
            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(userIdLoged);
            if (detail?.Image?.Length > 0)
            {
                MemoryStream msUserImg = new MemoryStream(detail.Image);
                bmpUserImg = new BitmapImage();
                bmpUserImg.BeginInit();
                bmpUserImg.CacheOption = BitmapCacheOption.OnLoad;
                bmpUserImg.StreamSource = (msUserImg);
                bmpUserImg.EndInit();
                bmpUserImg.Freeze();
            }
            return bmpUserImg;
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
