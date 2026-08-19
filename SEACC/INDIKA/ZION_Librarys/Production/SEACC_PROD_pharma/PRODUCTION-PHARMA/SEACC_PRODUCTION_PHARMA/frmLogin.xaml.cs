using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Masters;
using SEACC_PRODUCTION_PHARMA.Masters.Company;
using SEACC_PRODUCTION_PHARMA.Masters.Item;
using SEACC_PRODUCTION_PHARMA.Reports;
using SEACC_PRODUCTION_PHARMA.Transactions;
using SEACC_PRODUCTION_PHARMA.UserManagement;
using SEACC_WPFControls;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class frmLogin : Window
    {
        #region Class Variables
        frm_LandingPage homeMainPage;
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public frmLogin()
        {
            InitializeComponent();
            SetModuleImage("PROD/018");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string path2 = "Attachments";
            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);

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

        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;

            #region Production Masters
            //Masters
            if (SelectedForm == FormName.CompanyDivitionMaster)
            {
                UC_Division US = new UC_Division();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.CompanyDepartmentMaster)
            {
                UC_Department US = new UC_Department();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if(SelectedForm == FormName.ProdPharma_Sections)
            {
                UC_Section US = new UC_Section();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_SectionActivity)
            {
                UC_SectionActivity US = new UC_SectionActivity();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_JobNames) // Item Class
            {
                UC_JobName US = new UC_JobName();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_JobTypes)
            {
                UC_JobType US = new UC_JobType();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if(SelectedForm == FormName.ProdPharma_ProductRanges)
            {
                UC_ProductRange US = new UC_ProductRange();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_ProductCategory) // Item Category
            {
                UC_ProductCategory US = new UC_ProductCategory();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_ProductSizes) 
            {
                UC_ProductSize US = new UC_ProductSize();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_ProductColours) // Item Colour
            {
                UC_ProductColour US = new UC_ProductColour();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_SemiFinishedOutsource) // Item Outsource Rate
            {
                UC_SemiFinished_Outsource US = new UC_SemiFinished_Outsource();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region Production Transactions
            //Transactions
            else if (SelectedForm == FormName.ProdPharma_ProductSpecSheet)
            {
                UC_FinishedGood_SpecSheet US = new UC_FinishedGood_SpecSheet();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMCreation_Sales)
            {
                UC_BOM_Sales US = new UC_BOM_Sales();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMDetails_Production)
            {
                UC_BOM_Production US = new UC_BOM_Production(FormName.ProdPharma_BOMDetails_Production);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMCosting_Finance)
            {
                UC_BOM_Finance US = new UC_BOM_Finance(FormName.ProdPharma_BOMCosting_Finance);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BatchCreation)
            {
                UC_Production_BatchCreation US = new UC_Production_BatchCreation();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_MeterialRequisition)
            {
                UC_Production_MeterialRequisition US = new UC_Production_MeterialRequisition();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_GoodsIssues)
            {
                UC_Production_GoodsIssues US = new UC_Production_GoodsIssues();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_GoodsReturns)
            {
                UC_Production_GoodsReturns US = new UC_Production_GoodsReturns();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_SubContract_Out)
            {
                UC_SubContract_Out US = new UC_SubContract_Out();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_SubContract_In)
            {
                UC_SubContract_In US = new UC_SubContract_In();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_WIP)
            {
                UC_Production_WorkInProgress US = new UC_Production_WorkInProgress();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_FGTN)
            {
                UC_FinishedGood_Transfers US = new UC_FinishedGood_Transfers();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_FGTN_DetailView)
            {
                UC_FinishedGood_Transfers_DetailView US = new UC_FinishedGood_Transfers_DetailView();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_FGTN_Acceptance)
            {
                UC_FinishedGood_Transfers_Acceptance US = new UC_FinishedGood_Transfers_Acceptance();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMClosure)
            {
                UC_Production_BatchClosure US = new UC_Production_BatchClosure();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMDetails_SpecialPermission)
            {
                UC_BOM_Production US = new UC_BOM_Production(FormName.ProdPharma_BOMDetails_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOMCosting_SpecialPermission)
            {
                UC_BOM_Finance US = new UC_BOM_Finance(FormName.ProdPharma_BOMCosting_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_BOM_PostCosting)
            {
                //Need to Implement
            }
            else if (SelectedForm == FormName.ProdPharma_BOMRemoving)
            {
                UC_BOM_Obsolete US = new UC_BOM_Obsolete();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.ProdPharma_SplitNote)
            {
                UC_SplitNote US = new UC_SplitNote();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region Administrator
            //ADMINSTRATOR
            else if (SelectedForm == FormName.UserPermission)
            {
                UC_UserPermission US = new UC_UserPermission();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region User Profile
            //USER DASHBOARD
            else if (SelectedForm == FormName.Prod_UserDashBoard)
            {
                UC_UserDashboard US = new UC_UserDashboard();
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
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

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
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();

                #region Load modules
                foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.IsEnable).OrderBy(p => p.SortOrder))
                {
                    if (oModule != null && oModule.IsEnable)
                        homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
                }
                #endregion

                foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable && !p.IsReport && !p.FunctionName.Contains("Reports")).OrderBy(p => p.Function_Code))
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

        private void SetModuleImage(string sModule_ID)
        {
            BitmapImage bm = null;
            tbl_cfgModule oModule = tbl_cfgModule.Select(sModule_ID);
            if (oModule != null)
            {
                if (oModule.Image != null)
                {
                    if (oModule.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(oModule.Image);
                        bm = new BitmapImage();
                        bm.BeginInit();
                        bm.CacheOption = BitmapCacheOption.OnLoad;
                        bm.StreamSource = (ms);
                        bm.EndInit();
                        bm.Freeze();
                        imgBackground.Source = bm;
                    }
                }
            }
        }
    }
}
