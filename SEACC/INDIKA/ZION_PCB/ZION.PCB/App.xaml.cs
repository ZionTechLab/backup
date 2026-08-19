using DataTire;
using Digiteq_Logic;
using SEACC_PCB.Reports;
//using SEACC_PCB.Reports;
using SEACC_PCB.Transaction_Forms;
using SEACC_PCB.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using ZION.PCB;

namespace SEACC_PCB
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Class Variables
        frm_LandingPage homeMainPage; 
        int iNetworkDisconnectMsg = 0;
        #endregion

        #region Module Load
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region Module Initialize 
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

             //   clsBackProcess.AutoAssignCompanyValue();
                clsBackProcess.AutoAssignConfigStatus();
                clsBackProcess.AutoAssignConfigValue();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            #endregion

            #region Load modules
            foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().
                Where(p =>
                        p.Module_ID.Trim() != "FCT/014"
                        && p.Module_ID.Trim() != "ERP/001"
                        && p.Module_ID.Trim() != "PROD/016"
                        && p.Module_ID.Trim() != "FCT/013"
                        && p.IsEnable).OrderBy(p => p.SortOrder))
            {
                //if (oModule != null && oModule.IsEnable)
                if (oModule != null && oModule.IsEnable && (oModule.Module_ID == "ADM/000" || oModule.Module_ID == "PCB/025"))
                    homeMainPage.Addmenubutton(oModule.ModuleName, oModule.Module_ID);
            }
            #endregion

            #region Load Functions
            foreach (tbl_securityFunctionMaster oForm in tbl_securityFunctionMaster.SelectAll().Where(p => p.IsEnable && !p.IsReport && p.IsVisible).OrderBy(p => p.Function_Code))
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
            #endregion

            homeMainPage.Show();
        } 
        #endregion

        #region User Pool Check
        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tbl_utlUserPool oUpool = tbl_utlUserPool.Select(clsSecurity.iLoginSession_Index, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                if (oUpool == null)
                {
                  //  Application.Current.Shutdown();
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



        #region System ShutDown Event
        private void HomeMainPage_SystemShutDown()
        {
            //MessageBox.Show("Test");
        } 
        #endregion

        #region Report UI
        private void GotoReports(object sender, EventArgs e)
        {
            UC_Report US = new UC_Report();
            homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
        }
        #endregion

        #region Master & Transaction UIs
        private void HomeMainPage_FunctionSelected(int iFormID)
        {
            FormName SelectedForm = (FormName)iFormID;
            //bool bLoadForm = false;

            //if (SelectedForm == FormName.PCB_PettyCashBook || SelectedForm == FormName.PCB_ReimbursmentRequest)
            //{
            //    List<tbl_pcbMasAccount> oPCAccounts = tbl_pcbMasAccount.SelectAllByAssignedUser_ID(clsSecurity.UserIDLoged).Where(p=>!p.IsCanceled).ToList();
            //    if (oPCAccounts.Count > 0)
            //    {
            //        //tbl_securityFunctionMaster oForm = tbl_securityFunctionMaster.Select(807);
            //        //oForm.FunctionName = "Petty Cash Book - " + oPCAccounts.FirstOrDefault().PcbAccountName;
            //        //oForm.Update();
            //        bLoadForm = true;
            //    }
            //    else
            //        SEACCMessageBox.Show("No Account Assigned..", "You do not have an account", MessageBoxButton.OK);
            //}

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
                UC_PettyCashBook US = new UC_PettyCashBook();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
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
        #endregion

        #region Help Methods
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
        #endregion
    }
}
