using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Masters;
using SEACC_PRODUCTION_POLY.Masters.Company;
using SEACC_PRODUCTION_POLY.Masters.Item;
using SEACC_PRODUCTION_POLY.Reports;
using SEACC_PRODUCTION_POLY.Transactions;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SEACC_PRODUCTION_POLY
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
            Close();
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

        #region Function Select - UI Open
        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;

            #region Production Masters
            //Masters
            if (SelectedForm == FormName.Prod_SectionActivity)
            {
                UC_ProductionSectionActivity US = new UC_ProductionSectionActivity();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_ProductCategory) // Item Category
            {
                UC_ProductCategory US = new UC_ProductCategory();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_JobTypes) // Item Class
            {
                UC_ProductionJobType US = new UC_ProductionJobType();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.CompanyDivitionMaster)
            {
                UC_Division US = new UC_Division();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.CompanyDepartmentMaster)
            {
                UC_Department US = new UC_Department();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.CompanySectionMaster)
            {
                UC_ProductionSections US = new UC_ProductionSections();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_ProductRanges) // Item Type
            {
                UC_ProductRange US = new UC_ProductRange();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_ProductSizes) // Item Type
            {
                UC_ProductSize US = new UC_ProductSize();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_ProductColours) // Item Colour
            {
                UC_ProductColour US = new UC_ProductColour();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_SemiFinishedOutsource) // Item Outsource Rate
            {
                UC_SemiFinished_Outsource US = new UC_SemiFinished_Outsource();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            #endregion

            #region Production Transactions
            //Transactions
            if (SelectedForm == FormName.Prod_ProductSpecSheet)
            {
                UC_FinishedGoodSpecSheet US = new UC_FinishedGoodSpecSheet();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_ProductonPlaning)
            {
                UC_ProductionPlaning US = new UC_ProductionPlaning();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_BOMCreation_Sales)
            {
                UC_BOMCreation US = new UC_BOMCreation();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_BOMDetails_Production)
            {
                UC_BOMDetails US = new UC_BOMDetails(FormName.Prod_BOMDetails_Production);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_BOMCosting_Finance)
            {
                UC_BOMCosting US = new UC_BOMCosting(FormName.Prod_BOMCosting_Finance);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_MeterialRequisition)
            {
                UC_MeterialRequisition US = new UC_MeterialRequisition();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_GoodsIssues)
            {
                UC_ProductionGoodsIssues US = new UC_ProductionGoodsIssues();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_GoodsReturns)
            {
                UC_ProductionGoodsReturns US = new UC_ProductionGoodsReturns();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_SubContract_Out)
            {
                UC_SubContract_Out US = new UC_SubContract_Out();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_SubContract_In)
            {
                UC_SubContract_In US = new UC_SubContract_In();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_WIP)
            {
                UC_WorkInProgress US = new UC_WorkInProgress();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_FGTN)
            {
                UC_FinishedGoodTransfers US = new UC_FinishedGoodTransfers();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_BOMClosure)
            {
                UC_ProductionJobClosure US = new UC_ProductionJobClosure();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                UC_BOMDetails US = new UC_BOMDetails(FormName.Prod_BOMDetails_Production_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
            {
                UC_BOMCosting US = new UC_BOMCosting(FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_BOM_PostCosting)
            {
                //UC_ProductSpecSheet US = new UC_ProductSpecSheet();
                //homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Prod_BOMRemoving)
            {
                UC_BOMRemoving US = new UC_BOMRemoving();
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

            #region User Profile
            //USER DASHBOARD
            if (SelectedForm == FormName.Prod_UserDashBoard)
            {
                UC_UserDashboard US = new UC_UserDashboard();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion
        } 
        #endregion

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

                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.IsEnable).OrderBy(p => p.SortOrder))
                {
                    if (oModule != null && oModule.IsEnable)
                        homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable && !p.IsReport).OrderBy(p => p.Function_Code))
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
            UC_Report US = new UC_Report();
            homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        } 
        #endregion

        #region Help Methods
        private void HomeMainPage_SystemShutDown()
        {
            Close();
        }
        private void ShowPassword()
        {
            txtVisiblePasswordbox.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Hidden;
            txtVisiblePasswordbox.Text = txtPassword.Password;
            lblShowPassword.Foreground = Brushes.Gray;
            txtPassword.Foreground = Brushes.Gray;
        }
        private void HidePassword()
        {
            txtVisiblePasswordbox.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Focus();
            lblShowPassword.Foreground = Brushes.Black;
            txtPassword.Foreground = Brushes.Black;
        }
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
        #endregion
    }
}
