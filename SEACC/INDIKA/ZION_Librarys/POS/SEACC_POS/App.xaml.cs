using DataTire;
using Digiteq_Logic;
using Digiteq_Logic_POS;
using SEACC_POS.Controls;
using SEACC_POS.TransactionForms;
using SEACC_POS.UserManagement;
using SEACC_WPFControls;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace SEACC_POS
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
                //clsSecurity.Domain = clsSecurity.decryptPassword(e.Args[7]);

                string s = clsSecurity.decryptPassword(e.Args[7]);
                clsSecurity.bIsLive = (s == "1") ? true : false;

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
                clsBackProcess_POS.AutoAssignConfigStatus();
                clsBackProcess_POS.AutoAssignConfigStatus_POS();
                clsBackProcess_POS.AutoAssignConfigValue();
                clsBackProcess_POS.AutoAssignConfigValue_POS();
                clsSecurity.FinancialYearID = clsMethods_GL.getFinancialYear_ID_Current();

                //One Galleface Server Update
                #region Galleface Server Update
                if (clsSecurity.BranchID == "BRA/0007")
                {
                    DispatcherTimer dt_OGF = new DispatcherTimer();
                    dt.Tick += new EventHandler(timer2_Tick);
                    dt.Interval = new TimeSpan(0, 15, 0); // execute every 14 mins
                    dt.Start();
                }
                #endregion
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

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
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Common.clsOneGalleFaceUpload.Send_Sales();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tbl_utlUserPool oUpool = tbl_utlUserPool.Select(clsSecurity.iLoginSession_Index, clsSecurity.UserIDLoged, clsSecurity.TerminalID);
                if (oUpool == null)
                {
                    if (clsSecurity.UserIDLoged.Trim().ToUpper() != "DIGITEQ")
                    {
                        //Application.Current.Shutdown();
                    }
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

        private void HomeMainPage_SystemShutDown()
        {
            //Shutdown Code
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
                                    OpenPOS_Transaction_Window(oCashierSignIn_Activated.DayDetail_Index);
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

                case FormName.POS_SalesReturn:
                    tbl_posDayStartAndEnd_Detail oCashierSignIn_Activated_PSRN = tbl_posDayStartAndEnd_Detail.SelectAll()
                                                                                .Where(r => r.SignInCashier_ID == clsSecurity.UserIDLoged &&
                                                                                            !r.IsMgtSignOffCreated && !r.IsCanceled &&
                                                                                            r.PosTerminal_ID.Trim() == clsSecurity.TerminalID.Trim() &&
                                                                                            r.PosDate.Date == clsSecurity.getServerDateTime().Date)
                                                                                .OrderByDescending(r => r.DateCreated).FirstOrDefault();
                    if (oCashierSignIn_Activated_PSRN != null)
                    {
                        tbl_posDayStartAndEnd oBranchDay = tbl_posDayStartAndEnd.Select(oCashierSignIn_Activated_PSRN.DayIndex);
                        if (oBranchDay.CompanyBranch_ID == clsSecurity.BranchID)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation...", "Are you sure to open the POS Sales Return window ?", MessageBoxButton.YesNo, "#FF5B6B76");
                            if (bMessegeBoxResult)
                            {
                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                frmTwoStepVerify.ShowDialog();
                                if (frmTwoStepVerify.bVerified)
                                {
                                    OpenPOS_Return_Window(oCashierSignIn_Activated_PSRN.DayDetail_Index);
                                }
                                frmTwoStepVerify.Close();
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Restricted...", "You don't have valid session for open POS Sales Return Window...", MessageBoxButton.OK, "Red");
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Restricted...", "You don't have valid session for open POS Sales Return Window...", MessageBoxButton.OK, "Red");
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

                case FormName.POS_AdvancePayment:
                    tbl_posDayStartAndEnd_Detail oCashierSignIn_Activated_Advance = tbl_posDayStartAndEnd_Detail.SelectAll()
                                                                                .Where(r => r.SignInCashier_ID == clsSecurity.UserIDLoged &&
                                                                                            !r.IsMgtSignOffCreated && !r.IsCanceled &&
                                                                                            r.PosTerminal_ID.Trim() == clsSecurity.TerminalID.Trim() &&
                                                                                            r.PosDate.Date == clsSecurity.getServerDateTime().Date)
                                                                                .OrderByDescending(r => r.DateCreated).FirstOrDefault();
                    if (oCashierSignIn_Activated_Advance != null)
                    {
                        tbl_posDayStartAndEnd oBranchDay = tbl_posDayStartAndEnd.Select(oCashierSignIn_Activated_Advance.DayIndex);
                        if (oBranchDay.CompanyBranch_ID == clsSecurity.BranchID)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation...", "Are you sure to open the POS Advance Tab ?", MessageBoxButton.YesNo, "#FF5B6B76");
                            if (bMessegeBoxResult)
                            {
                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                frmTwoStepVerify.ShowDialog();
                                if (frmTwoStepVerify.bVerified)
                                {
                                    UC_AdavaceReceive uc9125 = new UC_AdavaceReceive(oCashierSignIn_Activated_Advance.DayDetail_Index);
                                    homeMainPage.Open_NewTabpage(uc9125, uc9125.SEACC_Form.PermissionTO_Read, uc9125.SEACC_Form.FormName, uc9125.SEACC_Form.FormID);
                                }
                                frmTwoStepVerify.Close();
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Restricted...", "You don't have valid session for open POS Advance Window...", MessageBoxButton.OK, "Red");
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Restricted...", "You don't have valid session for open POS Advance Window...", MessageBoxButton.OK, "Red");
                    }
                    break;
            }

            #region Check Expiration Date
            if (clsConfig.dtmDateExpiration < DateTime.Now)
            {
                MessageBox.Show("Product has been Expired..... \nPlease contact Digiteq for more details");
                // Application.Current.Shutdown();
            }
            #endregion
        }

        private void OpenPOS_Transaction_Window(int iSession_dayDetail_Index)
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
                    else
                        frmPosSales.Close();
                }
                else
                {
                    SEACCMessageBox.Show("Something Went Wrong in Item Store...!!!", "Please set the main store of this POS branch...", MessageBoxButton.OK, "Red");
                }
            }
        }

        private void OpenPOS_Return_Window(int iSession_dayDetail_Index)
        {
            Frm_Item_Returns frmPosReturnOld = Application.Current.Windows.OfType<Frm_Item_Returns>().FirstOrDefault(w => w.Name.Equals("frmPosReturnsWindow"));
            if (frmPosReturnOld != null)
            {
                SEACCMessageBox.Show("'POS Return Window' already opened...!!!", "You can not open it again...", MessageBoxButton.OK, "Red");
                homeMainPage.Topmost = false;
                frmPosReturnOld.WindowState = WindowState.Maximized;
                frmPosReturnOld.Topmost = true;
            }
            else
            {
                tbl_genStoreMaster oBranchMainStore = tbl_genStoreMaster.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).Where(p => !p.IsDeleted && p.IsMainStore).ToList().FirstOrDefault();
                if (oBranchMainStore != null)
                {
                    Frm_Item_Returns frmPosReturns = new Frm_Item_Returns(iSession_dayDetail_Index);
                    if (frmPosReturns.SEACC_Form.PermissionTO_Read)
                        frmPosReturns.Show();
                    else
                        frmPosReturns.Close();
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
    }
}