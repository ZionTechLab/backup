using System.IO;
using SEACC_PCB.UserManagement;
using DataTire;
using Digiteq_Logic;
using SEACC_PCB.Transaction_Forms;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using SEACC_PCB.Reports;
using ZION.PCB;
//using SEACC_PCB.Reports;

namespace SEACC_PCB
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        #region Class Variables
        frm_LandingPage homeMainPage; 
        #endregion

        #region Form Load
        public frmLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserName.Focus();
        }
        #endregion

        #region Window Drag
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

        #region Btn Close
        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            //Application.Current.Shutdown();
            this.Close();
        }
        #endregion

        #region Btn SignIn
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

        #region Label Events

        private void lblShowPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void lblShowPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void lblShowPassword_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        #endregion

        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;
            bool bLoadForm = false;
            string sPCBAccountID = "";

            if (SelectedForm == FormName.PCB_PettyCashBook || SelectedForm == FormName.PCB_ReimbursmentRequest)
            {
                List<tbl_pcbMasAccount> oPCAccounts = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(clsSecurity.UserIDLoged).ToList();
                if (oPCAccounts.Count > 0)
                {
                    //tbl_securityFunctionMaster oForm = tbl_securityFunctionMaster.Select(807);
                    //oForm.FunctionName = "Petty Cash Book - " + oPCAccounts.FirstOrDefault().PcbAccountName;
                    //oForm.Update();
                    bLoadForm = true;
                }
                else
                    SEACCMessageBox.Show("No Account Assigned..", "You do not have an account", MessageBoxButton.OK);
            }

            #region Masters
            if (SelectedForm == FormName.PCB_IncomeType)
            {
                UC_IncomeType US = new UC_IncomeType();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.PCB_ExpenditureType)
            {
                UC_ExpenditureType US = new UC_ExpenditureType();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.PCB_PettyCashAccCreation)
            {
                UC_AccountCreation US = new UC_AccountCreation();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region Transactions
            if (SelectedForm == FormName.PCB_IOURequest)
            {
                UC_IOURequest US = new UC_IOURequest();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }            
            if (SelectedForm == FormName.PCB_PettyCashBook)
            {                
                if (bLoadForm)
                {
                    UC_PettyCashBook US = new UC_PettyCashBook();
                    homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                }                
            }
            if (SelectedForm == FormName.PCB_ReimbursmentRequest)
            {
                if (bLoadForm)
                {
                    //UC_PCReimbursmentRequest US = new UC_PCReimbursmentRequest();
                 //   homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
                }
            }
            #endregion

            #region Reports
            else if (SelectedForm == FormName.pcb_Reports)
            {
                UC_Report US = new UC_Report();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            } 
            #endregion

            #region Administrator
            //ADMINSTRATOR
            if (SelectedForm == FormName.UserPermission)
            {
                UC_UserPermission US = new UC_UserPermission();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion
            
        }

        #region Check Validity
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

        #region User Login
        private void UserLogin()
        {

            if (CheckValidityUsernameAndPassword())
            {
                homeMainPage = new frm_LandingPage();
                homeMainPage.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsSecurity.UserGroupIDLoged, GetUserImage(clsSecurity.UserIDLoged), false);//GetUserImage(clsSecurity.UserIDLoged)
                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.BtnReportClick += GotoReports;
                //homeMainPage.UserSettingsClick += GotoUserDashboard;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

                
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();

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

                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.IsEnable).OrderBy(p => p.SortOrder))
                {
                    if (oModule != null && (oModule.Module_ID == "ADM/000" || oModule.Module_ID == "PCB/025"))
                        homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable && p.IsVisible && !p.IsReport).OrderBy(p => p.Function_Code))
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
        }
        #endregion

        #region Reports
        private void GotoReports(object sender, EventArgs e)
        {
            //UC_Report US = new UC_Report();
            //homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        } 
        #endregion

        #region Help Methods
        private void HomeMainPage_SystemShutDown()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
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

        private BitmapImage GetUserImage(string sUserID)
        {
            BitmapImage bm = null;
            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sUserID);
            if (detail != null)
            {
                if (detail.Image != null)
                {
                    if (detail.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(detail.Image);

                        bm = new BitmapImage();
                        bm.BeginInit();
                        bm.CacheOption = BitmapCacheOption.OnLoad;
                        bm.StreamSource =(ms);// ms;
                        bm.EndInit();
                        bm.Freeze();
                    }
                }
            }
            return bm;
        }
    }
}
