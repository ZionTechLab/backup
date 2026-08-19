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
    /// <summary>
    /// Interaction logic for UC_PAYE_TaxTable_1.xaml
    /// </summary>
    public partial class UC_PAYE_TaxTable_1 : UserControl
    {

        #region Form Load
        public UC_PAYE_TaxTable_1()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Paye_Tax_Table;
            SEACC_Form.Initialize();

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("TaxTableID");
            dgr_Main.dt.Columns.Add("TaxTableCode");
            dgr_Main.dt.Columns.Add("TaxTableName");
            dgr_Main.dt.Columns.Add("TaxTableStartRange");
            dgr_Main.dt.Columns.Add("TaxTableEndRange");
            dgr_Main.dt.Columns.Add("TaxTableTaxRate");
            dgr_Main.dt.Columns.Add("TaxTableCOLAAmt");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Tax Table ID", "TaxTableID", 70, false);
            dgr_Main.Add_DatagridColoumn("Tax Table Code", "TaxTableCode", 110);
            dgr_Main.Add_DatagridColoumn("Tax Table Name", "TaxTableName", 250);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Tax Table Start Range", "TaxTableStartRange", 140, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Tax Table End Range", "TaxTableEndRange", 140, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Tax Table Tax Rate", "TaxTableTaxRate", 70, false, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Tax Table COLA Amt", "TaxTableCOLAAmt", 90, false, true);
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
            else if (SEACC_Form.ActualWidth < 960)
                coloumnA.Width = new GridLength(470);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons
        #region Save
        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                string sTaxID = "";
                try
                {
                    Cursor = Cursors.Wait;

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_payMas_PAYE_TaxTable_1 oldRecord = tbl_payMas_PAYE_TaxTable_1.Select(txtPAYETaxtableID.Tag.ToString());
                            if (oldRecord != null)
                            {
                                int iPayeStatus = (int)PAYE_Status.Active;

                                tbl_payMas_PAYE_TaxTable_1 oPAYE_Tax = new tbl_payMas_PAYE_TaxTable_1(txtPAYETaxtableID.Tag.ToString(), txtPAYETaxtableCode.Text, txtPAYETaxtableName.Text, decimal.Parse(txtPAYETaxStartRange.Text), decimal.Parse(txtPAYETaxEndRange.Text), decimal.Parse(txtPAYETaxRate.Text), decimal.Parse(txtPAYECOLAAmt.Text), dtpPAYEStartDate.GetDateTime(), dtpPAYEEndDate.GetDateTime(), txtPAYEGLCODECR.Text, txtPAYEGLCODEDR.Text,
                                    iPayeStatus,
                                    false, false, false,
                                    oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Checked, oldRecord.UserID_Approved, oldRecord.UserID_Canceled,
                                    oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Checked, oldRecord.TerminalID_Approved, oldRecord.TerminalID_Canceled,
                                    oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Checked, oldRecord.Date_Approved, oldRecord.Date_Canceled);
                                oPAYE_Tax.Update();

                                sTaxID = oPAYE_Tax.Tax_table_ID;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert 
                    else
                    {
                        tbl_payMas_PAYE_TaxTable_1 oPAYE_Tax = new tbl_payMas_PAYE_TaxTable_1(txtPAYETaxtableID.Tag.ToString(), txtPAYETaxtableCode.Text, txtPAYETaxtableName.Text, decimal.Parse(txtPAYETaxStartRange.Text), decimal.Parse(txtPAYETaxEndRange.Text), decimal.Parse(txtPAYETaxRate.Text), decimal.Parse(txtPAYECOLAAmt.Text), dtpPAYEStartDate.GetDateTime(), dtpPAYEEndDate.GetDateTime(), txtPAYEGLCODECR.Text, txtPAYEGLCODEDR.Text,
                            (int)PAYE_Status.Active,
                            false, false, false,
                            clsSecurity.UserIDLoged, "default", "default", "default", "default",
                            clsSecurity.TerminalID, "default", "default", "default", "default",
                            clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);

                        oPAYE_Tax.Insert();
                        sTaxID = oPAYE_Tax.Tax_table_ID;
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
                    fillDetails(sTaxID);
                    Cursor = Cursors.Arrow;
                }
            }
        }
        #endregion

        #region Cancel
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtPAYETaxtableID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_payMas_PAYE_TaxTable_1 OTax = tbl_payMas_PAYE_TaxTable_1.Select(txtPAYETaxtableID.Text.Trim());
                            if (OTax != null)
                            {
                                OTax.IsCanceled = true;
                                OTax.Date_Canceled = clsSecurity.getServerDateTime();
                                OTax.TerminalID_Canceled = clsSecurity.TerminalID;
                                OTax.UserID_Canceled = clsSecurity.UserIDLoged;
                                OTax.Update();

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
        #endregion

        #region New
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_payMas_PAYE_TaxTable_1 detail in tbl_payMas_PAYE_TaxTable_1.SelectAll().Where(p => p.IsCanceled == false && p.Tax_table_ID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Tax_table_ID, detail.Tax_tableCode, detail.Tax_tableName, cls_Formater.FormatDecimal(detail.Tax_StartRange, 2), cls_Formater.FormatDecimal(detail.Tax_EndRange, 2), cls_Formater.FormatDecimal(detail.Tax_Rate, 2), cls_Formater.FormatDecimal(detail.Cola_Amt, 2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPAYETaxtableID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYETaxtableCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYETaxtableName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYETaxStartRange, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYETaxEndRange, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYETaxRate, true, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpPAYEStartDate, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpPAYEEndDate, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYECOLAAmt, true, true, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYEGLCODECR, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYEGLCODEDR, true, false, true);

            txtPAYETaxtableID.Tag = null;

            txtPAYETaxtableCode.Text = "";
            txtPAYETaxtableID.Text = "";
            txtPAYETaxtableName.Text = "";
            txtPAYETaxStartRange.Text = "0.00";
            txtPAYETaxEndRange.Text = "0.00";
            txtPAYETaxRate.Text = "0.00";
            txtPAYECOLAAmt.Text = "0.00";
            txtPAYEGLCODECR.Text = "";
            txtPAYEGLCODEDR.Text = "";

            dtpPAYEStartDate.SetTime(DateTime.Now);
            dtpPAYEEndDate.SetTime(DateTime.Now);
        }
        #endregion

        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (CheckValidity_DuplicateFiled())
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtPAYETaxtableCode))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtPAYETaxtableName))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtPAYETaxStartRange))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtPAYETaxEndRange))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtPAYETaxRate))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtPAYECOLAAmt))
                    bStatus = false;
                //if (!clsValidation.Validate_EmptyValue(txtPAYEGLCODECR))
                //    bStatus = false;
                //if (!clsValidation.Validate_EmptyValue(txtPAYEGLCODEDR))
                //    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtPAYETaxtableID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtPAYETaxtableID.Text = txtPAYETaxtableID.Tag.ToString();
                }

                tbl_payMas_PAYE_TaxTable_1 oTax = tbl_payMas_PAYE_TaxTable_1.Select(txtPAYETaxtableID.Text);
                if (oTax != null)
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
            foreach (tbl_payMas_PAYE_TaxTable_1 oTax in tbl_payMas_PAYE_TaxTable_1.SelectAll().Where(p => p.Tax_table_ID != txtPAYETaxtableID.Text && p.Tax_tableCode == txtPAYETaxtableCode.Text && p.IsCanceled == false))
            {
                if (oTax != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
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
                    tbl_payMas_PAYE_TaxTable_1 detail = tbl_payMas_PAYE_TaxTable_1.Select(sID);
                    if (detail != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtPAYETaxtableID.IsEnabled = false;

                        txtPAYETaxtableID.Tag = detail.Tax_table_ID;

                        txtPAYETaxtableID.Text = detail.Tax_table_ID;
                        txtPAYETaxtableCode.Text = detail.Tax_tableCode;
                        txtPAYETaxtableName.Text = detail.Tax_tableName;
                        txtPAYETaxStartRange.Text = cls_Formater.FormatDecimal(detail.Tax_StartRange, 2);
                        txtPAYETaxEndRange.Text = cls_Formater.FormatDecimal(detail.Tax_EndRange, 2);
                        txtPAYETaxRate.Text = cls_Formater.FormatDecimal(detail.Tax_Rate, 2);
                        txtPAYECOLAAmt.Text = cls_Formater.FormatDecimal(detail.Cola_Amt, 2);
                        txtPAYEGLCODECR.Text = detail.Glcode_CR;
                        txtPAYEGLCODEDR.Text = detail.Glcode_DR;

                        dtpPAYEStartDate.SetTime(detail.StartDate);
                        dtpPAYEEndDate.SetTime(detail.EndDate);

                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
    }
}
