using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.IO;
using SEACC_PRODUCTION_APPAREL.UserManagement;
using SEACC_PRODUCTION_APPAREL.Transactions;
using SEACC_PRODUCTION_APPAREL.Masters.Company;
using SEACC_PRODUCTION_APPAREL.Tools;
using SEACC_PRODUCTION_APPAREL.Masters.Item;
using SEACC_PRODUCTION_APPAREL.Masters;
using SEACC_PRODUCTION_APPAREL.Reports;

namespace SEACC_PRODUCTION_APPAREL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //R2 Landing Page
        frm_LandingPage homeMainPage;
        //Network Disconnect Messages Count
        int iNetworkDisconnectMsg = 0;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                DBHandling.ConnectionString = clsSecurity.decryptPassword(e.Args[0]);          
                clsSecurity.TerminalID = clsSecurity.decryptPassword(e.Args[1]);           
                clsSecurity.UserIDLoged = clsSecurity.decryptPassword(e.Args[2]);        
                clsSecurity.iLoginSession_Index = int.Parse(clsSecurity.decryptPassword(e.Args[3]));       
                clsSecurity.CompanyID = clsSecurity.decryptPassword(e.Args[4]);
                clsSecurity.BranchID = clsSecurity.decryptPassword(e.Args[5]);
                clsSecurity.Server = clsSecurity.decryptPassword(e.Args[6]);
                clsSecurity.Domain = clsSecurity.decryptPassword(e.Args[7]);
              
                homeMainPage = new frm_LandingPage();
                homeMainPage.btnLogout.Visibility = Visibility.Hidden;

                #region Dispacture Timer - User Pool Chekc
                DispatcherTimer dt = new DispatcherTimer();
                dt.Tick += new EventHandler(timer_Tick);
                dt.Interval = new TimeSpan(0, 0, 1); // execute every second
                dt.Start();
                #endregion

                tbl_securityUserMaster oUserLoged = tbl_securityUserMaster.Select(clsSecurity.UserIDLoged);
                if (oUserLoged != null)
                {
                    clsSecurity.UserNameLoged = oUserLoged.UserName;
                    clsSecurity.UserGroupIDLoged = oUserLoged.Group_ID;
                    homeMainPage.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsSecurity.UserGroupIDLoged, GetUserImage(clsSecurity.UserIDLoged), false);
                }

                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.BtnReportClick += GotoReports;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

                clsBackProcess.AutoAssignCompanyValue();
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            #region Load modules
            foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(p => p.Module_ID.Trim() == "PROD/016" || p.Module_ID.Trim() == "ADM/000" ||
                        p.Module_ID.Trim() == "USER/017" &&  p.IsEnable).OrderBy(p => p.SortOrder))
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
        }

        private void GotoReports(object sender, EventArgs e)
        {
            UC_Report US = new UC_Report();
            homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }

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
            else if (SelectedForm == FormName.CompanySectionMaster)
            {
                UC_Section US = new UC_Section();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_SectionActivity)
            {
                UC_SectionActivity US = new UC_SectionActivity();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_JobNames) // Item Class
            {
                UC_JobName US = new UC_JobName();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_JobTypes)
            {
                UC_JobType US = new UC_JobType();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_ProductRanges)
            {
                UC_ProductRange US = new UC_ProductRange();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_ProductCategory) // Item Category
            {
                UC_ProductCategory US = new UC_ProductCategory();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_ProductSizes)
            {
                UC_ProductSize US = new UC_ProductSize();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_ProductColours) // Item Colour
            {
                UC_ProductColour US = new UC_ProductColour();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_SemiFinishedOutsource) // Item Outsource Rate
            {
                UC_SemiFinished_Outsource US = new UC_SemiFinished_Outsource();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            #endregion

            #region Production Transactions
            //Transactions
            else if (SelectedForm == FormName.Prod_ProductSpecSheet)
            {
                UC_FinishedGood_SpecSheet US = new UC_FinishedGood_SpecSheet();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMCreation_Sales)
            {
                UC_BOM_Sales US = new UC_BOM_Sales();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMDetails_Production)
            {
                UC_BOM_Production US = new UC_BOM_Production(FormName.Prod_BOMDetails_Production);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMCosting_Finance)
            {
                UC_BOM_Finance US = new UC_BOM_Finance(FormName.Prod_BOMCosting_Finance);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BatchCreation)
            {
                UC_Production_BatchCreation US = new UC_Production_BatchCreation();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_MeterialRequisition)
            {
                UC_Production_MeterialRequisition US = new UC_Production_MeterialRequisition();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_GoodsIssues)
            {
                UC_Production_GoodsIssues_MultipleMR US = new UC_Production_GoodsIssues_MultipleMR();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_GoodsReturns)
            {
                UC_Production_GoodsReturns US = new UC_Production_GoodsReturns();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_SubContract_Out)
            {
                UC_SubContract_Out US = new UC_SubContract_Out();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_SubContract_In)
            {
                UC_SubContract_In US = new UC_SubContract_In();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_WIP)
            {
                UC_Production_WorkInProgress US = new UC_Production_WorkInProgress();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_FGTN)
            {
                UC_FinishedGood_Transfers US = new UC_FinishedGood_Transfers();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_FGTN_DetailView)
            {
                UC_FinishedGood_Transfers_DetailView US = new UC_FinishedGood_Transfers_DetailView();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_FGTN_Acceptance)
            {
                UC_FinishedGood_Transfers_Acceptance US = new UC_FinishedGood_Transfers_Acceptance();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMClosure)
            {
                UC_Production_BatchClosure US = new UC_Production_BatchClosure();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                UC_BOM_Production US = new UC_BOM_Production(FormName.Prod_BOMDetails_Production_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
            {
                UC_BOM_Finance US = new UC_BOM_Finance(FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission);
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOM_PostCosting)
            {
                UC_Production_BatchDetails US = new UC_Production_BatchDetails();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_BOMRemoving)
            {
                UC_BOM_Obsolete US = new UC_BOM_Obsolete();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            else if (SelectedForm == FormName.Prod_SplitNote)
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

        #region Timer Tick Event - Check User Pool
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tbl_utlUserPool oUpool = tbl_utlUserPool.Select(clsSecurity.iLoginSession_Index, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                if (oUpool == null)
                {
                   //Application.Current.Shutdown();
                }
                iNetworkDisconnectMsg = 0;
            }
            catch (Exception ex)
            {
                if (iNetworkDisconnectMsg == 0)
                {
                    ++iNetworkDisconnectMsg;
                    SEACCExeption.Show(ex);
                }
            }
        } 
        #endregion

        private void HomeMainPage_SystemShutDown()
        {
            MessageBox.Show("Test");
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
                        bm.StreamSource = (ms);// ms;
                        bm.EndInit();
                        bm.Freeze();
                    }
                }
            }
            return bm;
        }
    }
}
