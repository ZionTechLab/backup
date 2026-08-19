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

namespace SEACC_FACTORING.Masters
{
    /// <summary>
    /// Interaction logic for UC_BankBranch.xaml
    /// </summary>
    public partial class UC_BankBranch : UserControl
    {
        #region Form Load
        public UC_BankBranch()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_BankBranch;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("BankID");
            dgr_Main.dt.Columns.Add("BankCode");
            dgr_Main.dt.Columns.Add("BranchID");
            dgr_Main.dt.Columns.Add("BranchCode");
            dgr_Main.dt.Columns.Add("branchName");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Bank ID", "BankID", 50, false);
            dgr_Main.Add_DatagridColoumn("Bank Code", "BankCode", 100);
            dgr_Main.Add_DatagridColoumn("Branch ID ", "BranchID", 70, false);
            dgr_Main.Add_DatagridColoumn("Branch Code", "BranchCode", 100);
            dgr_Main.Add_DatagridColoumn("Branch Name", "branchName", 250);
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
                            tbl_zBankBranches oBankMaster = tbl_zBankBranches.Select(txtBranchCode.Tag.ToString());
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
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
                        {
                            tbl_zBankBranches oldRecord = tbl_zBankBranches.Select(txtBranchCode.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_zBankBranches oBankBranch = new tbl_zBankBranches(txtBranchCode.Tag.ToString(), txtBank.Tag.ToString(), txtBranchName.Text, txtBranchCode.Text);
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

                        tbl_zBankBranches oBankBranch = new tbl_zBankBranches(txtBranchCode.Tag.ToString(), txtBank.Tag.ToString(), txtBranchName.Text, txtBranchCode.Text );
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
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtBranchCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBranchName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBank, true, false, false);

            txtBank.Text = "";
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
            txtBank.Tag = null;
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
                
                foreach (tbl_zBankBranches detail in tbl_zBankBranches.SelectAll().Where(p => p.Branch_ID != "Default").OrderBy(o => o.Bank_ID))
                {
                    dgr_Main.dt.Rows.Add(detail.Bank_ID, clsRef_Name.get_Bank_Code(detail.Bank_ID), detail.Branch_ID, detail.OriginalBranchCode, detail.BranchName);
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

            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtBranchCode))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBranchName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode) { 
                    txtBranchCode.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_zBankBranches oDetail = tbl_zBankBranches.Select(txtBranchCode.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
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
                    tbl_zBankBranches details = tbl_zBankBranches.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtBranchCode.IsEnabled = true;
                        txtBranchCode.Text = details.OriginalBranchCode;
                        txtBranchCode.Tag = details.Branch_ID;
                        txtBank.Text = clsRef_Name.get_Bank_Code(details.Bank_ID);
                        txtBank.Tag = details.Bank_ID;
                        txtBranchName.Text = details.BranchName;
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
                    string GridID = (dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
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
        private void txtBank_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks);
            if (RowDataSearch.DialogResult == true)
            {
                cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtBranchCode, true, false, false);
                cls_Formater.SetEnableDisable_LableTextbox(txtBranchName, true, false, false);

                txtBranchCode.Text = "";
                txtBranchName.Text = "";
                txtBranchCode.Tag = null;

                txtBank.Tag = lstResult[0];
                txtBank.Text = lstResult[1];
            }
        }

        private void txtBranchCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                txtBranchCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }

            //Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.FactoringBankBranch);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    txtBranchCode.Text = lstResult[0];
            //    fillDetails(lstResult[0]);
            //}
        }
        #endregion
    }
}
