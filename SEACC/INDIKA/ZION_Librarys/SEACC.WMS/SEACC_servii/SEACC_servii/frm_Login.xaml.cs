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
using SEACC_servii.Widgets;
using SEACC_servii.Master_Forms;
using SEACC_servii.User_Management;
using SEACC_servii.User_Management_Forms;

namespace SEACC_servii
{
    /// <summary>
    /// Interaction logic for frm_Login.xaml
    /// </summary>
    public partial class frm_Login : Window
    {
        SEACC_WPFControls.frm_LandingPage homeMainPage;
        #region Login form Load
        public frm_Login()
        {
            InitializeComponent();
            clsBackProcess.AutoAssignConfigValue();
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
                // MessageBox.Show(ex.Message.ToString(), cls_Formater.GetMessageCaption(), MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return bStatus;
        }

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
                                    clsSecurity.UserImageLoged = cls_Formater.Convert_ByteToBitMap(detail.Image);
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

        #region Check Validity User bneand Password_Employee
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
                                    clsSecurity.UserImageLoged = cls_Formater.Convert_ByteToBitMap(detail.Image);
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

        private void UserLogin()
        {
            Cursor = Cursors.Wait;
            if (CheckValidityUserbneandPassword_Employee())
            {
                frm_DashBord employeeDashboards = new frm_DashBord();
                employeeDashboards.Show();
                this.Close();
            }
            else if (CheckValidityUsernameAndPassword())
            {
                homeMainPage = new SEACC_WPFControls.frm_LandingPage();
                homeMainPage.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsRef_Name.get_UserGroup_Name(clsSecurity.UserGroupIDLoged), clsSecurity.UserImageLoged, false);
                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll())
                {
                    homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }

                foreach (tbl_securityFormMaster oForm in tbl_securityFormMaster.SelectAll().Where(p=>p.IsEnable).OrderBy(p => p.SortOrder))
                {
                    try
                    {
                        homeMainPage.tbl_Functions.Rows.Add(oForm.Form_ID, oForm.FormName, (cls_Formater.Convert_ByteToBitMap(oForm.Image)), oForm.FormCategory_ID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                homeMainPage.Show();
                //homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());
                this.Close();
            }
        }

        private void HomeMainPage_SystemShutDown()
        {
            this.Close();
        }

        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;

            #region Master Forms
            if (SelectedForm == FormName.CountryMaster)
            {
                UC_CountryMaster US = new UC_CountryMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.ProvinceCreation)
            {
                UC_Province US = new UC_Province();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.DistrictMaster)
            {
                UC_DistrictMaster US = new UC_DistrictMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CityMaster)
            {
                UC_CityMaster US = new UC_CityMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.TownCreation)
            {
                UC_TownMaster US = new UC_TownMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }


            else if (SelectedForm == FormName.TaxMaster)
            {
                UC_TaxMaster US = new UC_TaxMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CategoryOfUnitOfMeasureMaster)
            {
                UC_UomCategoryMaster US = new UC_UomCategoryMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.UnitOfMeasureMaster)
            {
                UC_UomMaster US = new UC_UomMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }


            else if (SelectedForm == FormName.ItemClassMaster)
            {
                UC_ItemClassMaster US = new UC_ItemClassMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ItemTypeMaster)
            {
                UC_ItemTypeMaster US = new UC_ItemTypeMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ItemCategoryMaster)
            {
                UC_ItemCategoryMaster US = new UC_ItemCategoryMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ItemBrandMaster)
            {
                UC_ItemBrandMaster US = new UC_ItemBrandMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ItemCreationMaster)
            {
                UC_ItemMaster US = new UC_ItemMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            else if (SelectedForm == FormName.BrokerMaster)
            {
                UC_BrokerMaster US = new UC_BrokerMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CustomerClassMaster)
            {
                UC_CustomerClassMater US = new UC_CustomerClassMater();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CustomerTypeMaster)
            {
                UC_CustomerTypeMaster US = new UC_CustomerTypeMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CustomerCategoryMaster)
            {
                UC_CustomerCategoryMaster US = new UC_CustomerCategoryMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CustomerMaster)
            {
                UC_CustomerMaster US = new UC_CustomerMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.WarehouseMaster)
            {
                UC_WarehouseMaster US = new UC_WarehouseMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.VehicleCheckInOut)
            {
                UC_VehicleCheckInOut US = new UC_VehicleCheckInOut();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Estimation)
            {
                UC_Estimation US = new UC_Estimation();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.GRN)
            {
                UC_GoodReceivedNote US = new UC_GoodReceivedNote();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.GIN)
            {
                UC_GoodIssueNote US = new UC_GoodIssueNote();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Report)
            {
                UC_Report US = new UC_Report();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region User Management
            else if (SelectedForm == FormName.UserCreation)
            {
                UC_UserMaster US = new UC_UserMaster();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.UserPermissionSetup)
            {
                UC_UserPermission US = new UC_UserPermission();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.SystemBackup)
            {
                UC_SystemBackup US = new UC_SystemBackup();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion
        }

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

        private void txtUserName_KeyUp(object sender, KeyEventArgs e)
        {
            ////grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;
            ////try
            ////{
            ////    if (e.Key == Key.Escape)
            ////        txtUserName.Text = "";
            ////    else if (e.Key == Key.Enter)
            ////        sfds_MouseLeftButtonUp(dgv_Search, null);
            ////    else if (e.Key == Key.Up)
            ////        Up(true);
            ////    else if (e.Key == Key.Down)
            ////        Up(false);
            ////    else
            ////    {
            ////        tbl_Search.DefaultView.RowFilter = "FormName" + " Like '%" + txtUserName.Text + "%'";
            ////        RefreshUserName();
            ////    }
            ////}
            ////catch (Exception ex)
            ////{
            ////    SEACCExeption.Show(ex);
            ////}
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            //grd_popSubMenus.Visibility = System.Windows.Visibility.Collapsed;
            //try
            //{
            //    if (e.Key == Key.Escape)
            //        txtPassword.Text = "";
            //    else if (e.Key == Key.Enter)
            //        sfds_MouseLeftButtonUp(dgv_Search, null);
            //    else if (e.Key == Key.Up)
            //        Up(true);
            //    else if (e.Key == Key.Down)
            //        Up(false);
            //    else
            //    {
            //        tbl_Search.DefaultView.RowFilter = "FormName" + " Like '%" + txtPassword.Text + "%'";
            //        RefreshPassword();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }

        private void RefreshUserName()
        {
            ////if (txtUserName.Text.Length != 0)
            ////{
            ////    btnSearch_Launch.Content = "";
            ////    btnSearch_Launch.Tag = "1";
            ////    Grd_Search.Height = 150;
            ////    dgv_Search.SelectedIndex = 0;
            ////}
            ////else
            ////{
            ////    btnSearch_Launch.Content = "";
            ////    btnSearch_Launch.Tag = "0";
            ////    Grd_Search.Height = 0;
            ////}
        }

        private void RefreshPassword()
        {
            ////if (txtPassword.Text.Length != 0)
            ////{
            ////    btnSearch_Launch.Content = "";
            ////    btnSearch_Launch.Tag = "1";
            ////    Grd_Search.Height = 150;
            ////    dgv_Search.SelectedIndex = 0;
            ////}
            ////else
            ////{
            ////    btnSearch_Launch.Content = "";
            ////    btnSearch_Launch.Tag = "0";
            ////    Grd_Search.Height = 0;
            ////}
        }

        private void txtPassword_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
                lblPwd.Visibility = Visibility.Hidden;
            else
                lblPwd.Visibility = Visibility.Visible;
        }
    }
}
