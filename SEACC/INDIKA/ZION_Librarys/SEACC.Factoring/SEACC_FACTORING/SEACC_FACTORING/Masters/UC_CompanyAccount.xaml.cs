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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;

namespace SEACC_FACTORING
{
    /// <summary>
    /// Interaction logic for UC_CompanyAccount.xaml
    /// </summary>
    public partial class UC_CompanyAccount : UserControl
    {
        #region Form Load
        public UC_CompanyAccount()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_CompanyAccount;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("AccountNo");
            dgr_Main.dt.Columns.Add("BankID");
            dgr_Main.dt.Columns.Add("BankCode");
            dgr_Main.dt.Columns.Add("BranchID");
            dgr_Main.dt.Columns.Add("BranchCode");
           // dgr_Main.dt.Columns.Add("BalanceAmount");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Account No", "AccountNo", 100);
            dgr_Main.Add_DatagridColoumn("Bank ID", "BankID", 50, false);
            dgr_Main.Add_DatagridColoumn("Bank", "BankCode", 200);
            dgr_Main.Add_DatagridColoumn("Branch ID ", "BranchID", 80, false);
            dgr_Main.Add_DatagridColoumn("Branch", "BranchCode", 120);
           // dgr_Main.Add_DatagridColoumn("Balance Amount", "BalanceAmount", 75);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion


        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtBank.Tag != null)
                    {
                        bool MessageBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (MessageBoxResult)
                        {
                            tbl_genCompanyAccount oBankMaster = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, txtAccNo.Text);
                            if (oBankMaster != null)
                            {
                                //oBankMaster.IsCanceled = true;
                                //oBankMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                //oBankMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                //oBankMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oBankMaster.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    enum_ReportName Report = enum_ReportName.BankBranchList;

            //    //tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
            //    //  if (oReports != null)
            //    {
            //        string sFilter = "";

            //        DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();

            //        //Company table filling
            //        // glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

            //        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

            //        //BankBranch table fill 
            //        glb_dts_Masters.Tables["dt_BankBranch"].Merge(DBHandling.ExecQuery("Exec sp_GetBankBranch").Tables[0]);

            //        frm_ReportViwer CRViwer = new frm_ReportViwer();
            //        //  CRViwer.Print(oReports.ReportPath, glb_dts_Masters, glb_dts_ExportReport.dt_rptParameter);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                string sAcc = "";
                try
                {
                    sAcc = txtAccNo.Text;
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
                        {
                            tbl_genCompanyAccount oldRecord = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, txtAccNo.Text);
                            if (oldRecord != null)
                            {
                                tbl_genCompanyAccount oBankBranch = new tbl_genCompanyAccount(oldRecord.CompanyID, txtAccNo.Text, txtBank.Tag.ToString(), txtBranch.Tag.ToString(), decimal.Parse(txtBalanceAmnt.Text), "default");
                                oBankBranch.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }

                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        //if (SEACC_Form.isAutoGenaratedCode)
                        //    txtBranchCode.Tag = SEACC_Form.getAutoGeneratedCode();

                        tbl_genCompanyAccount oBankBranch = new tbl_genCompanyAccount(clsSecurity.CompanyID,txtAccNo.Text, txtBank.Tag.ToString(), txtBranch.Tag.ToString(), decimal.Parse(txtBalanceAmnt.Text), "default");
                        oBankBranch.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    RefreshGrid();
                    ClearFields();
                    fillDetails(sAcc);
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtAccNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBank, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranch, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBalanceAmnt, true, false, false);

            txtBank.Tag = null;
            txtBranch.Tag = null;

            txtAccNo.Text = "";
            txtBank.Text = "";
            txtBranch.Text = "";
            txtBalanceAmnt.Text = "0.0";
            
            //row_BranchID.Width = -1;


            //#region Set Auto Genarate Key fields
            //if (SEACC_Form.isAutoGenaratedCode)
            //{
            //    txtBranchCode.Text = "<Auto Generate>";
            //    txtBranchCode.setReadOnlyStatus(true);
            //}
            //else
            //    txtBranchCode.setReadOnlyStatus(false);
            //#endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_genCompanyAccount detail in tbl_genCompanyAccount.SelectAll().Where(p => p.AccountNumber != "default" && p.AccountNumber !=""))
                {
                    dgr_Main.dt.Rows.Add(detail.AccountNumber, detail.Bank_ID, clsRef_Name.get_Bank_Name(detail.Bank_ID), detail.Branch_ID, clsRef_Name.get_Branch_Code(detail.Branch_ID));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }

            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtAccNo))
                bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtBalanceAmnt))
            //    bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genCompanyAccount oDetail = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, txtAccNo.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genCompanyAccount details = tbl_genCompanyAccount.Select(clsSecurity.CompanyID, sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtAccNo.IsEnabled = true;
                        txtAccNo.Text = details.AccountNumber;
                        txtBank.Text = clsRef_Name.get_Bank_Code(details.Bank_ID);
                        txtBank.Tag = details.Bank_ID;
                        txtBranch.Tag = details.Branch_ID;
                        txtBranch.Text = clsRef_Name.get_BankBranch_Name(details.Branch_ID);
                        txtBalanceAmnt.Text = details.BalanceAmount.ToString();
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtAccNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CompanyAccount);
            if (RowDataSearch.DialogResult == true)
            {
                txtAccNo.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtBank_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks); 
            if (RowDataSearch.DialogResult == true)
            {
                txtBank.Tag = lstResult[0];
                txtBank.Text = lstResult[1];
            }
        }

        private void txtBranch_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtBank.Tag != null && txtBank.Text != "")
            {
                lstParameeters.Add(txtBank.Tag.ToString());
            }
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBankBranch);
            if (RowDataSearch.DialogResult == true)
            {
                txtBranch.Tag = lstResult[0];
                txtBranch.Text = lstResult[4];
                txtBank.Tag = lstResult[1];
                txtBank.Text = lstResult[2];
            }
        }
        #endregion
    }
}
