using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;

namespace SEACC_FACTORING.Masters
{
    public partial class UC_Bank : UserControl
    {
        #region Form Load
        public UC_Bank()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_Bank;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("BankID");
            dgr_Main.dt.Columns.Add("BankShortName");
            dgr_Main.dt.Columns.Add("BankName");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Bank Code", "BankID", 100);
            dgr_Main.Add_DatagridColoumn("Short Name", "BankShortName", 100);
            dgr_Main.Add_DatagridColoumn("Name", "BankName", 200);
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
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtBankID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_zBank detail = tbl_zBank.Select(txtBankID.Text.Trim());
                            if (detail != null)
                            {
                                detail.Delete();

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
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    enum_ReportName Report = enum_ReportName.BankList;

            //    // tbl_securityReportMaster oReports = tbl_securityReportMaster.Select(((int)Report));
            //    //  if (oReports != null)
            //    {
            //        string sFilter = "";

            //        DataSets.dts_Masters glb_dts_Masters = new DataSets.dts_Masters();

            //        //Company table filling
            //        // glb_dts_Masters.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsSecurity.CompanyAddress2, clsCommon.getCompanyImage(), oReports.DisplayName, oReports.DisplayName2, "", clsSecurity.UserNameLoged, sFilter == "" ? "-" : sFilter);

            //        DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();

            //        //Bank table filling
            //        foreach (tbl_genMasBank detail in tbl_genMasBank.SelectAll().Where(p => p.IsCanceled == false && p.Bank_ID != "default"))
            //        {
            //            glb_dts_Masters.dt_Bank.Adddt_BankRow(detail.Bank_ID, detail.BankShortName, detail.BankName);
            //        }
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
                            tbl_zBank oldRecord = tbl_zBank.Select(txtBankID.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_zBank detail = new tbl_zBank(txtBankID.Text.Trim(), txtBankName.Text, txtBankSortName.Text);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        //if (SEACC_Form.isAutoGenaratedCode)
                        //    txtBankID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_zBank detail = new tbl_zBank(txtBankID.Text.Trim(), txtBankName.Text, txtBankSortName.Text);
                        detail.Insert();
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
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            txtBankID.IsEnabled = true;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtBankID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBankName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBankSortName, true, false, false);

            txtBankID.Tag = null;

            txtBankID.Text = "";
            txtBankName.Text = "";
            txtBankSortName.Text = "";

            //#region Set Auto Genarate Key fields
            //if (SEACC_Form.isAutoGenaratedCode)
            //{
            //    txtBankID.setReadOnlyStatus(true);
            //    txtBankID.Text = "<Auto Generate>";
            //}
            //else
            //    txtBankID.setReadOnlyStatus(false);
            //#endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_zBank detail in tbl_zBank.SelectAll().Where(p => p.Bank_ID != "default").OrderBy(p => p.BankName))
                {
                    dgr_Main.dt.Rows.Add(detail.Bank_ID, detail.SortName, detail.BankName);
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
                if (!ChekValidity_DuplicateNames())
                    bStatus = false;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtBankID))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtBankName))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_zBank detail = tbl_zBank.Select(txtBankID.Text);
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_zBank detail1 in tbl_zBank.SelectAll().Where(p => p.BankName == txtBankName.Text && p.Bank_ID != txtBankID.Text))
            {
                if (detail1 != null)
                {
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    bStatus = false;
                    break;
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
                    tbl_zBank detail = tbl_zBank.Select(sID);
                    if (detail != null)
                    {
                        txtBankID.IsEnabled = false;
                        SEACC_Form.IsUpdateMode = true;
                        txtBankID.Text = detail.Bank_ID;
                        txtBankID.Tag = detail.Bank_ID;
                        txtBankName.Text = detail.BankName;
                        txtBankSortName.Text = detail.SortName;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
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
        private void txtBankID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.FactoringBanks);
            if (RowDataSearch.DialogResult == true)
            {
                txtBankID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}