using DataTire;
using Digiteq_Logic;
using SEACC_Tender.Transactions;
using SEACC_WPFControls;
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

namespace SEACC_Tender
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
               // Application.Current.Shutdown();

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
        private void btn_FrogotMyPassword_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Request a New Account Button
        private void btn_RequestNewAccount_Click(object sender, RoutedEventArgs e)
        {

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
        private bool CheckValidity_Company()
        {
            bool bExpired = false;
            try
            {
                string sCom = clsSecurity.getRegDBComapanyName();
                tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(sCom);
                if (company != null)
                {
                    clsSecurity.CompanyID = company.CompanyID;

                    //Add Lock 
                    //company.Edition++;
                    //company.Update();                    
                    //if (company.Edition > 250)
                    //    bExpired = true;
                }
                else
                    bExpired = true;

                if (bExpired)
                    //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SoftwareExpired9182), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SEACCMessageBox.Show("", "", MessageBoxButton.OK, "");
            }
            catch (Exception ex)
            {
                bExpired = true;
                clsValidate.WriteErrorLog(ex.Message, 0);
                //MessageBox.Show(ex.ToString());
                //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DataBaseError, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SEACCMessageBox.Show("", "", MessageBoxButton.OK, "");
            }
            return bExpired;
        }
        private bool CheckValidity_Branch()
        {
            bool bValid = false;
            try
            {
                //        tbl_genCompanyBranchMaster company = tbl_genCompanyBranchMaster.Select("BRA/0000");
                //        if (company != null)
                //        {
                //            clsSecurity.BranchID = company.CompanyBranch_ID;
                //            bValid = true;
                //        }

                //    if (!bValid)
                //    {
                //        // MessageBox.Show("Invalid Branch Name", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        SEACCMessageBox.Show("", "", MessageBoxButton.OK, "");
                //    }

                clsSecurity.BranchID = "BRA/0000";
            }
            catch (Exception ex)
            {
                bValid = false;
                clsValidate.WriteErrorLog(ex.Message, 0);
                //MessageBox.Show(ex.ToString());
                //MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DataBaseError, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                SEACCMessageBox.Show("", "", MessageBoxButton.OK, "");
            }
            return bValid;
        } 
        #endregion

        #region Check Validity

        #region Check Validity Company
        //private bool CheckValidity_Company()
        //{
        //    bool bExpired = true;
        //    try
        //    {
        //        string sCom = clsSecurity.CompanyID;
        //        tbl_genCompanyInfo company = tbl_genCompanyInfo.Select(sCom);
        //        if (company != null)
        //        {
        //            clsSecurity.CompanyID = company.CompanyID;
        //        }
        //        else
        //        {
        //            SEACCMessageBox.Show("Registry Error....!", "Please contact your system administrator");
        //            bExpired = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // SEACCMessageBox.Show("Registry Error....!", ex.Message);
        //        bExpired = false;
        //    }
        //    return bExpired;
        //}
        #endregion

        #region Check Validity Terminal
        private bool CheckValidityTerminal(string sUserID)
        {
            bool bStatus = true;
            try
            {
                
            }
            catch (Exception )
            {
                
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
                            SEACCMessageBox.Show("Warning", "Incorrect Password", MessageBoxButton.OK);
                            txtPassword.SelectAll();
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Warning", "Incorrect User Name", MessageBoxButton.OK);
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
                if (CheckValidity_Branch())
                {
                    clsSecurity.FinancialYearID = clsMethods_Fin.getCurrentFinanceYearID();
                    //clsSecurity.LastFinancialYearID = clsMethods_Fin.getLastFinanceYearID();
                    //Program.IsLoginOk = true;
                    //Savetolog(true, "");
                    //this.Dispose();
                }

                homeMainPage = new frm_LandingPage();
                homeMainPage.usrIndicator.SetUser(clsSecurity.UserNameLoged, clsSecurity.UserGroupIDLoged, null, false);
                homeMainPage.FunctionSelected += HomeMainPage_FunctionSelected;
                homeMainPage.SystemShutDown += HomeMainPage_SystemShutDown;
                homeMainPage.Set_CompanyImage(clsCommon.getCompanyImage());

                if (!System.IO.Directory.Exists(@"Attachments\"))
                    System.IO.Directory.CreateDirectory(@"Attachments\");

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

            if (SelectedForm == FormName.Tender)
            {
                UC_ttsTxnTenderNotice US = new UC_ttsTxnTenderNotice();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.DocumentList)
            {
                UC_ttsApplicationCollection US = new UC_ttsApplicationCollection();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.TenderReading)
            {
                UC_TenderReadings US = new UC_TenderReadings();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Customer)
            {
                UC_genMasCustomer US = new UC_genMasCustomer();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.Item)
            {
                UC_genMasItem US = new UC_genMasItem();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.TenderItems)
            {
                UC_ttsTxnTenderDocuments US = new UC_ttsTxnTenderDocuments();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.TenderSecurity)
            {
                UC_TenderSecurity US = new UC_TenderSecurity();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.AcceptanceLetter)
            {
                UC_ttsTxnAcceptanceLetter US = new UC_ttsTxnAcceptanceLetter();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.OfferLetter)
            {
                UC_OfferLetter US = new UC_OfferLetter();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.PurchaseOrder)
            {
                UC_PurchaseOrder US = new UC_PurchaseOrder();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.PreBidMeeting)
            {
                UC_ttsPreBidMeeting US = new UC_ttsPreBidMeeting();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.ResponseDocList)
            {
                UC_ttsMasDocumentList US = new UC_ttsMasDocumentList();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.TenSupplierMaster)
            {
                UC_ttsMasSupplier US = new UC_ttsMasSupplier();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }

            if (SelectedForm == FormName.ProjectSponsor)
            {
                UC_ttsMasProjectSponsor US = new UC_ttsMasProjectSponsor();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.DocumentLicenceRenewal)
            {
                UC_ttsTxnDocumentRenewal US = new UC_ttsTxnDocumentRenewal();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.Competitors)
            {
                UC_ttsMasCompetitor US = new UC_ttsMasCompetitor();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.TenderClosure)
            {
                UC_TenderClosure US = new UC_TenderClosure();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.TenderDocumentLicenceViewer)
            {
                UC_TenderDocumentLicenceViewer US = new UC_TenderDocumentLicenceViewer();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.DocumentLicenceRenewal2)
            {
                UC_ttsTxnDocumentRenewal2 US = new UC_ttsTxnDocumentRenewal2();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.GRNBatchDetails)
            {
                UC_ttsTxnGRNBatchDetails US = new UC_ttsTxnGRNBatchDetails();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
            if (SelectedForm == FormName.TenManufacturer)
            {
                UC_ttsMasManufacturer US = new UC_ttsMasManufacturer();
                homeMainPage.Open_NewTabpage(US, US.SEACC_Form.PermissionTO_Read, US.SEACC_Form.FormName, US.SEACC_Form.FormID);
            }
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
    }
    
}
