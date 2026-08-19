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

namespace Digiteq
{
    /* Developed by - Lasantha
     * Checked and code freeze by - Anoj [2015-10-12]
    */

    public partial class UC_BankBranch : UserControl
    {
        #region Form Load
        public UC_BankBranch()
        {

            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Bank_Branch_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Branch ID", "bankBranch_ID", 50, false);
            dgr_Main.Add_DatagridColoumn("Bank Code ", "bank_ID", 70);
            dgr_Main.Add_DatagridColoumn("Short Name", "bankShortName", 75);
            dgr_Main.Add_DatagridColoumn("Branch Name", "bankBranch_code", 75);
            dgr_Main.Add_DatagridColoumn("Branch Code", "branchName", 220); 
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
                    if (txtBankCode.Tag != null)
                    {
                        bool MessageBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (MessageBoxResult)
                        {
                            tbl_genMasBankBranch oBankMaster = tbl_genMasBankBranch.Select(txtBankCode.Tag.ToString());
                            if (oBankMaster != null)
                            {
                                oBankMaster.IsCanceled = true;
                                oBankMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oBankMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oBankMaster.TerminalID_Canceled = clsSecurity.TerminalID;
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
            try
            {
                enum_ReportName Report = enum_ReportName.BankBranchList;

                //tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
              //  if (oReports != null)
                {
                    string sFilter = "";

                    DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();

                    //Company table filling
                  // glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

                    DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

                    //BankBranch table fill 
                    glb_dts_Masters.Tables["dt_BankBranch"].Merge(DBHandling.ExecQuery("Exec sp_GetBankBranch").Tables[0]);

                    frm_ReportViwer CRViwer = new frm_ReportViwer();
                  //  CRViwer.Print(oReports.ReportPath, glb_dts_Masters, glb_dts_ExportReport.dt_rptParameter);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
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
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genMasBankBranch oldRecord = tbl_genMasBankBranch.Select(txtBankCode.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_genMasBankBranch oBankBranch = new tbl_genMasBankBranch(txtBankCode.Tag.ToString(), txtBranchCode.Text, txtBankCode.Tag.ToString(), txtBranchName.Text, "", false, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.UserID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                oBankBranch.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }

                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtBankCode.Tag = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasBankBranch oBankBranch = new tbl_genMasBankBranch(txtBankCode.Tag.ToString(), txtBranchCode.Text, txtBankCode.Tag.ToString(), txtBranchName.Text, "", false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
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

            cls_Formater.SetEnableDisable_LableTextbox(txtBranchCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBankCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBranchName, true, false, false);

            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtBranchName.Text = "";
            txtBankCode.Tag = null;
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
                dgr_Main.dt = DBHandling.ExecQuery("Exec sp_GetBankBranch").Tables[0];
                if (dgr_Main.dt != null && dgr_Main.dt.Rows.Count > 0)
                {
                    dgr_Main.RefreshGrid();
                }
                
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

            if (!clsValidation.Validate_EmptyValue(txtBranchCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBankCode))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasBankBranch oDetail = tbl_genMasBankBranch.Select(txtBranchCode.Text);
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
                    tbl_genMasBankBranch details = tbl_genMasBankBranch.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtBranchCode.IsEnabled = false;
                        txtBranchCode.Text = details.BankBranch_code;
                        txtBranchCode.Tag = details.BankBranch_code;
                        txtBankCode.Text = clsRef_Name.get_Bank_Name(details.Bank_ID);
                        txtBankCode.Tag = details.Bank_ID;
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
        private void grdMain_BB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
        private void txtBranchCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtBankCode.Tag != null && txtBankCode.Text != "")
            {
                lstParameeters.Add(txtBankCode.Tag.ToString());
            }
            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.BankBranch);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtBranchCode.Text = lstResult[2];
                txtBranchCode.Tag = lstResult[2];
                txtBankCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtBankCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Banks);
            if (RowDataSearch.DialogResult == true)
            {
                txtBankCode.Text = clsRef_Name.get_Bank_Name(lstResult[0]);
                txtBankCode.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
