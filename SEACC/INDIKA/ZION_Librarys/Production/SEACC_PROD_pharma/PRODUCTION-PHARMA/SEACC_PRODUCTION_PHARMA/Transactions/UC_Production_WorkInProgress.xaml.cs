using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_PRODUCTION_PHARMA.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_PHARMA.Transactions
{
    /// <summary>
    /// Interaction logic for UC_WorkInProgress.xaml
    /// </summary>
    public partial class UC_Production_WorkInProgress : UserControl
    {
        #region Class Variables
        DataTable dtItems = new DataTable();
        BrushConverter bc = new BrushConverter();
        frm_search RowDataSearch;
        #endregion

        #region Form Load
        public UC_Production_WorkInProgress()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_WIP;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Material Data Table
            dtItems.Columns.Add("LineNo", typeof(int));
            dtItems.Columns.Add("Item_ID");
            dtItems.Columns.Add("Item_Name");
            dtItems.Columns.Add("InputOutput", typeof(int));
            dtItems.Columns.Add("UoM_ID");
            dtItems.Columns.Add("UoM");
            dtItems.Columns.Add("PlannedQty");
            dtItems.Columns.Add("ProdFloorQty");
            dtItems.Columns.Add("UtilizedQty");
            dtItems.Columns.Add("WastagePct");
            dtItems.Columns.Add("Wastage");
            dtItems.Columns.Add("QA_SampleQty");
            dtItems.Columns.Add("IO_Qty_Rate");
            dtItems.Columns.Add("IO_Qty");
            dtItems.Columns.Add("OutputSectionID");
            dtItems.Columns.Add("OutputSectionName");
            dtItems.Columns.Add("OutputActivityID");
            dtItems.Columns.Add("OutputActivityName");
            dtItems.Columns.Add("Comments");
            dtItems.Columns.Add("TotalQty");
            dtItems.Columns.Add("unitPrice");
            dtItems.Columns.Add("weightPrice");
            DataColumn dc = new DataColumn("ManuallyAdd", typeof(string)) { DefaultValue = "false" };
            dtItems.Columns.Add(dc);
            dtItems.Columns.Add("PreviousWIP_OutQty");
            #endregion

            #region Initialize Main Data Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("WIP#");
            dgr_Main.dt.Columns.Add("WIP_DATE");
            dgr_Main.dt.Columns.Add("BOM_ID");
            dgr_Main.dt.Columns.Add("BATCH_ID");
            dgr_Main.dt.Columns.Add("UOM");
            dgr_Main.dt.Columns.Add("BATCH_QTY");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("WIP #", "WIP#", 75);
            dgr_Main.Add_DatagridColoumn("WIP Date", "WIP_DATE", 85);
            dgr_Main.Add_DatagridColoumn("BoM", "BOM_ID", 85);
            dgr_Main.Add_DatagridColoumn("Batch/Job", "BATCH_ID", 85);
            dgr_Main.Add_DatagridColoumn("UOM", "UOM", 60, false);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Batch Qty.", "BATCH_QTY", 75, false, true);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sWIP_ID = "";
            if (CheckValidity())
                if (WIP_ValidateIOQty())
                {
                    try
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prod_pharmaTxWorkInProgress oOldWIP = tbl_prod_pharmaTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
                                if (oOldWIP != null)
                                {
                                    if (!oOldWIP.IsApproved && !oOldWIP.IsCanceled)
                                    {

                                        tbl_prod_pharmaTxWorkInProgress oWIP = new tbl_prod_pharmaTxWorkInProgress(txtWIP_ID.Tag.ToString(), dtpWIP_Date.GetDateTime(), dtpProdJob_Date.GetDateTime(),
                                        txtProdJobBoMID.Tag != null ? txtProdJobBoMID.Tag.ToString() : "default",
                                        txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                        txtFG_Item.Tag != null ? txtFG_Item.Tag.ToString() : "default",
                                        txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                        decimal.Parse(txtBatchQty.Text),
                                        txtProdSection.Tag != null ? txtProdSection.Tag.ToString() : "default",
                                        txtSectionActivity.Tag != null ? txtSectionActivity.Tag.ToString() : "default",
                                        dtpJobInTime.GetDateTime(), txtProdSupervisor.Text, txtQA_Officer.Text, txtMachineOperator.Text, txtMachineOfficer.Text,
                                        (txtCheckedBy.Tag != null ? true : false), oOldWIP.IsApproved, oOldWIP.IsCanceled,
                                         oOldWIP.CreateUser_ID, (txtEnteredBy.Tag != null ? txtEnteredBy.Tag.ToString() : clsSecurity.UserIDLoged), (txtCheckedBy.Tag != null ? txtCheckedBy.Tag.ToString() : "default"), oOldWIP.ApprovedUser_ID, oOldWIP.CanceldUser_ID,
                                         oOldWIP.DateCreate, clsSecurity.getServerDateTime(), oOldWIP.DateChecked, oOldWIP.DateApproved, oOldWIP.DateCanceled,
                                         oOldWIP.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldWIP.CheckedUserTerminal_ID, oOldWIP.ApprovedUserTerminal_ID, oOldWIP.CanceledUserTerminal_ID,
                                         oOldWIP.CompanyID, oOldWIP.CompanyBranchID, txtRemarks.Text);
                                        oWIP.Update();

                                        foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Items in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(txtWIP_ID.Tag.ToString()))
                                        {
                                            if (oWIP_Items.Is_Output)
                                            {
                                                clsHelpMethods_Prod.Update_ItemFinanceCosts(oWIP_Items.Item_ID, 0m, 0m, oWIP_Items.UnitPrice, oWIP_Items.InputOutput_Qty);
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oWIP_Items.Output_Section_ID, oWIP_Items.Item_ID, -oWIP_Items.InputOutput_Qty);
                                            }
                                            else
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oOldWIP.Section_ID, oWIP_Items.Item_ID, (oWIP_Items.InputOutput_Qty + oWIP_Items.Qc_Qty + oWIP_Items.Waste_Qty));
                                            oWIP_Items.Delete();
                                        }

                                        WIP_InsertMaterials();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldWIP.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected WIP has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldWIP.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected WIP has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                sWIP_ID = oOldWIP.Wip_ID;
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                tbl_prod_pharmaTxWorkInProgress oNewWIP = new tbl_prod_pharmaTxWorkInProgress(txtWIP_ID.Tag.ToString(), dtpWIP_Date.GetDateTime(), dtpProdJob_Date.GetDateTime(),
                                    txtProdJobBoMID.Tag != null ? txtProdJobBoMID.Tag.ToString() : "default",
                                    txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                    txtFG_Item.Tag != null ? txtFG_Item.Tag.ToString() : "default",
                                    txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                    decimal.Parse(txtBatchQty.Text),
                                    txtProdSection.Tag != null ? txtProdSection.Tag.ToString() : "default",
                                    txtSectionActivity.Tag != null ? txtSectionActivity.Tag.ToString() : "default",
                                    dtpJobInTime.GetDateTime(), txtProdSupervisor.Text, txtQA_Officer.Text, txtMachineOperator.Text, txtMachineOfficer.Text,
                                    (txtCheckedBy.Tag != null ? true : false), false, false,
                                    txtEnteredBy.Tag != null ? txtEnteredBy.Tag.ToString() : clsSecurity.UserIDLoged, "default", txtCheckedBy.Tag != null ? txtCheckedBy.Tag.ToString() : "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID, txtRemarks.Text
                                    );
                                oNewWIP.Insert();

                                WIP_InsertMaterials();
                                sWIP_ID = oNewWIP.Wip_ID;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
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
                        FillDetails(sWIP_ID);
                    }
                }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (SEACC_Form.CheckPermission_ToPrint())
                    {
                        //Not Implemented
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermission_ToApproved())
            {
                if (CheckValidity())
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        tbl_prod_pharmaTxWorkInProgress oWIP = tbl_prod_pharmaTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
                        if (oWIP != null)
                        {
                            if (!oWIP.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        oWIP.IsApproved = true;
                                        oWIP.DateApproved = clsSecurity.getServerDateTime();
                                        oWIP.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                        oWIP.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                        oWIP.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    }
                                    frmTwoStepVerify.Close();
                                }
                                ClearFields();
                                RefreshGrid();
                                FillDetails(oWIP.Wip_ID);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Alreay Approved", "Selected pGIN has already been approved", MessageBoxButton.OK, "Red");
                            }
                        }
                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxWorkInProgress oWIP = tbl_prod_pharmaTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
                            if (oWIP != null)
                            {
                                if (!oWIP.IsApproved)
                                {
                                    if (!oWIP.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oWIP.IsCanceled = true;
                                                oWIP.DateCanceled = clsSecurity.getServerDateTime();
                                                oWIP.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oWIP.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Items in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID))
                                                {
                                                    if (oWIP_Items.Is_Output)
                                                    {
                                                        clsHelpMethods_Prod.Update_ItemFinanceCosts(oWIP_Items.Item_ID, 0m, 0m, oWIP_Items.UnitPrice, oWIP_Items.InputOutput_Qty);
                                                        clsHelpMethods_Prod.UpdateSectionFloorStock(oWIP_Items.Output_Section_ID, oWIP_Items.Item_ID, -oWIP_Items.InputOutput_Qty);
                                                    }
                                                    else
                                                        clsHelpMethods_Prod.UpdateSectionFloorStock(oWIP.Section_ID, oWIP_Items.Item_ID, oWIP_Items.InputOutput_Qty);
                                                }

                                                oWIP.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        RefreshGrid();
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyCanceled);
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show(MessegeBoxType.CannotCancel_AlreadyApproved);
                                }
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

        #region Item Grid Buttons
        private void btnGridAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtProdSection.Tag != null && txtSectionActivity.Tag != null && txtProdBatchID.Tag != null && txtProdJobBoMID.Tag != null)
            {
                RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials, true);
                RowDataSearch.RowSelected += RowDataSearch_RowSelected;
            }
            else
            {
                if (txtProdSection.Tag == null)
                    SEACCMessageBox.Show("Production Section Can not be Empty", "Please select a Production Section before adding items", MessageBoxButton.OK, "Red");
                else if (txtProdJobBoMID.Tag == null)
                    SEACCMessageBox.Show("BoM Can not be Empty", "Please select a BoM before adding items", MessageBoxButton.OK, "Red");
                else if (txtProdBatchID.Tag == null)
                    SEACCMessageBox.Show("Job/Batch Can not be Empty", "Please select a job/batch before adding items", MessageBoxButton.OK, "Red");
                else if (txtSectionActivity.Tag == null)
                    SEACCMessageBox.Show("Section Activity Can not be Empty", "Please select a section activity before adding items", MessageBoxButton.OK, "Red");
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Items.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_Items.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtItems.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtItems.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtItems);
            }
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtWIP_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobBoMID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdBatchID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Item, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSectionActivity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatchQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtProdSupervisor, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtQA_Officer, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMachineOperator, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtMachineOfficer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEnteredBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCheckedBy, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtWIP_ID.Tag = null;
            txtProdJobBoMID.Tag = null;
            txtProdBatchID.Tag = null;
            txtFG_Item.Tag = null;
            txtFinishGoodUOM.Tag = null;
            txtProdSection.Tag = null;
            txtSectionActivity.Tag = null;
            txtProdSupervisor.Tag = null;
            txtQA_Officer.Tag = null;
            txtMachineOperator.Tag = null;
            txtMachineOfficer.Tag = null;
            txtEnteredBy.Tag = clsSecurity.UserIDLoged;
            txtCheckedBy.Tag = null;

            txtFG_Item.ToolTip = null;

            txtWIP_ID.Text = "";
            txtProdJobBoMID.Text = "";
            txtProdBatchID.Text = "";
            txtFG_Item.Text = "";
            txtFinishGoodUOM.Text = "";
            txtBatchQty.Text = "0.00";
            txtProdSection.Text = "";
            txtSectionActivity.Text = "";
            txtProdSupervisor.Text = "";
            txtQA_Officer.Text = "";
            txtMachineOperator.Text = "";
            txtMachineOfficer.Text = "";
            txtRemarks.Text = "";

            txtEnteredBy.Text = clsSecurity.UserNameLoged;
            txtCheckedBy.Text = "";

            dtpWIP_Date.SetTime(DateTime.Now);
            dtpJobInTime.SetTime(DateTime.Now);
            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpWorkStartTime.SetTime(DateTime.Now);

            dtItems.Clear();
            //dtItems.DefaultView.Sort = "InputOutput desc";
            dgr_Items.ItemsSource = dtItems.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            if (clsSecurity.UserIDLoged != "digiteq")
            {
                btnPostCostingCalc.Visibility = Visibility.Hidden;
            }

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtWIP_ID.setReadOnlyStatus(true);
                txtWIP_ID.Text = "<Auto Generate>";
            }
            else
                txtWIP_ID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAll().Where(p => p.Wip_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(
                        ++iCount,
                        oWIP.Wip_ID,
                        oWIP.Wip_Date.ToString(clsValidation.Format_Date),
                        oWIP.ProdJob_ID,
                        oWIP.ProdBatch_ID,
                        clsGenaralName.getName_Uom(clsGenaralName.getID_PharmaBoM_UoM(oWIP.ProdJob_ID)),
                        cls_Formater.FormatDecimal(oWIP.FGoodQty, clsConfig.sDecimalPlaces_Quantity),
                        clsGenaralName.getName_User(oWIP.CreateUser_ID),
                        clsGenaralName.getName_User(oWIP.ApprovedUser_ID),
                        oWIP.IsCanceled);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (CheckOutputQty_WithBatchQty())
                    if (CheckOutputActivitySelect())
                        if (CheckFloorStock())
                            if (CheckValidity_DuplicateFiled())
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtWIP_ID.Text))
                                    if (CheckValidity_WATollarance())
                                        bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtWIP_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdSection))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSectionActivity))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJobBoMID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdBatchID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFG_Item))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBatchQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEnteredBy))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtWIP_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtWIP_ID.Text = txtWIP_ID.Tag.ToString();
                }
            }
            return bStatus;
        }

        private bool CheckOutputActivitySelect()
        {
            bool bSelectOutputSection = true;
            if (dtItems.Select("OutputActivityName = '<Select Activity>'").Count() > 0)
            {
                bSelectOutputSection = false;
                SEACCMessageBox.Show("Oops..!", "Please Select Output Activity....", MessageBoxButton.OK, "Red");
            }
            return bSelectOutputSection;
        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            DataTable dtFloorStock = new DataTable();
            var vInputs = dtItems.Select("InputOutput = 0");
            if (vInputs.Length > 0)
                dtFloorStock = clsHelpMethods_Prod.GetItemGroupedItemFloorstockTable_FloorStockGetFromUI_Grid(vInputs.AsEnumerable().CopyToDataTable(), "TotalQty", clsGenaralName.getStoreID_Section(txtProdSection.Tag.ToString()));

            if (SEACC_Form.IsUpdateMode)
            {
                foreach (DataRow dr in dtFloorStock.Rows)
                {
                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                    dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(txtWIP_ID.Text).Where(r => r.Item_ID == sItem_ID).Sum(x => x.InputOutput_Qty), clsConfig.sDecimalPlaces_Quantity);
                }
            }

            bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);

            return bReturn;
            //return true;
        }

        private bool CheckOutputQty_WithBatchQty()
        {

            bool bReutrn = true;
            try
            {
                var vOutputs = dtItems.Select("InputOutput = 1");
                var vFG = vOutputs.Where(dr => dr.Field<string>("Item_ID") == txtFG_Item.Tag.ToString()).FirstOrDefault();
                if (vFG != null)
                {
                    string sWip_ID = "";
                    if (SEACC_Form.IsUpdateMode)
                        sWip_ID = txtWIP_ID.Tag.ToString();

                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Tag.ToString());
                    decimal dPreviousFG_Qty = clsHelpMethods_Prod.AlreadyMadeFG_formWIPs(sWip_ID, txtProdJobBoMID.Tag.ToString(), txtProdBatchID.Tag.ToString());
                    decimal dCurrentFG_Qty = clsValidation.Validate_DecimalNumber(vFG.Field<string>("IO_Qty"));
                    decimal dBoM_Qty = clsHelpMethods_Prod.GetProdBoMQty(oBatch.ProdJob_ID);
                    string sUoM = clsGenaralName.getName_ItemUOM(oBatch.Item_ID);
                    if ((oBatch.BatchQty * dBoM_Qty) < (dPreviousFG_Qty + dCurrentFG_Qty))
                    {
                        if (!(SEACCMessageBox.Show("Are you sure to Continue...?", "Job Qty is Exceeding...!\n" +
                                                                      "\n" + "Previously WIP FG Qty : " + cls_Formater.FormatDecimal(dPreviousFG_Qty, clsConfig.sDecimalPlaces_Quantity) + " " + sUoM +
                                                                      "\n" + "Current WIP FG Qty     : " + cls_Formater.FormatDecimal(dCurrentFG_Qty, clsConfig.sDecimalPlaces_Quantity) + " " + sUoM +
                                                                      "\n" + "Total WIP FG Qty         : " + cls_Formater.FormatDecimal(dCurrentFG_Qty + dPreviousFG_Qty, clsConfig.sDecimalPlaces_Quantity) + " " + sUoM +
                                                                      "\n" + "But Job FG Qty             : " + cls_Formater.FormatDecimal(oBatch.BatchQty * dBoM_Qty, clsConfig.sDecimalPlaces_Quantity) + " " + sUoM
                            , MessageBoxButton.YesNo, "#FF5B6B76")))
                        {
                            bReutrn = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                bReutrn = false;
                SEACCExeption.Show(ex);
            }
            return bReutrn;
        }

        private bool CheckValidity_WATollarance()
        {
            #region Variables
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("LineNo");
            dtGrid.Columns.Add("ItemCode");
            dtGrid.Columns.Add("Quantity");
            dtGrid.Columns.Add("UnitPrice");

            List<tbl_Detail> DB = new List<tbl_Detail>();
            #endregion

            #region Copy grid
            foreach (DataRow row in dtItems.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                decimal dIO_Qty = clsValidate.ValidateRowValue(row, "IO_Qty", 0m);
                decimal dUnitPrice = clsValidate.ValidateRowValue(row, "unitPrice", 0m);

                dtGrid.Rows.Add(iLine_no, sItem_ID, dIO_Qty, dUnitPrice);
            }
            #endregion

            #region Copy Saved value
            foreach (tbl_prod_pharmaTxWorkInProgress_Material oDetail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(txtWIP_ID.Text.Trim()))
            {
                DB.Add(new tbl_Detail(oDetail.Line_No, oDetail.Item_ID, oDetail.InputOutput_Qty, oDetail.UnitPrice));
            }
            #endregion

            return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sWIP_ID)
        {
            try
            {
                tbl_prod_pharmaTxWorkInProgress oWIP = tbl_prod_pharmaTxWorkInProgress.Select(sWIP_ID);
                if (oWIP != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtWIP_ID.Tag = oWIP.Wip_ID;
                    txtProdJobBoMID.Tag = oWIP.ProdJob_ID;
                    txtProdBatchID.Tag = oWIP.ProdBatch_ID;
                    txtFG_Item.Tag = oWIP.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oWIP.Uom_ID;
                    txtProdSection.Tag = oWIP.Section_ID;
                    txtSectionActivity.Tag = oWIP.Activity_ID;
                    txtEnteredBy.Tag = oWIP.CreateUser_ID;
                    txtCheckedBy.Tag = oWIP.CheckedUser_ID;

                    txtFG_Item.ToolTip = oWIP.Item_ID_FG;

                    dtpWIP_Date.SetTime(oWIP.Wip_Date);
                    dtpJobInTime.SetTime(oWIP.Job_InTime);
                    dtpProdJob_Date.SetTime(oWIP.Prod_Date);
                    dtpWorkStartTime.SetTime(oWIP.Job_InTime);

                    txtWIP_ID.Text = oWIP.Wip_ID;
                    txtProdJobBoMID.Text = oWIP.ProdJob_ID;
                    txtProdBatchID.Text = oWIP.ProdBatch_ID;
                    txtFG_Item.Text = clsGenaralName.getName_Item(oWIP.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oWIP.Uom_ID);
                    txtBatchQty.Text = cls_Formater.FormatDecimal(oWIP.FGoodQty, clsConfig.sDecimalPlaces_Quantity);
                    txtProdSection.Text = clsGenaralName.getName_Section(oWIP.Section_ID);
                    txtSectionActivity.Text = clsGenaralName.getName_PharmaSectionActivity(oWIP.Activity_ID);
                    txtProdSupervisor.Text = oWIP.Supervisor;
                    txtQA_Officer.Text = oWIP.Qa_Officer;
                    txtMachineOperator.Text = oWIP.Machine_Operator;
                    txtMachineOfficer.Text = oWIP.Maintainance_Officer;
                    txtRemarks.Text = oWIP.Remarks;

                    txtEnteredBy.Text = clsGenaralName.getName_User(oWIP.CreateUser_ID);
                    txtCheckedBy.Text = clsGenaralName.getName_User(oWIP.CheckedUser_ID);

                    dtItems.Rows.Clear();

                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Item in tbl_prod_pharmaTxWorkInProgress_Material.SelectAll().Where(r => r.Wip_ID == sWIP_ID))
                    {
                        decimal dFloor_Qty = oWIP_Item.Floor_Qty;
                        decimal dTotal_Qty = oWIP_Item.Waste_Qty + oWIP_Item.Qc_Qty + oWIP_Item.InputOutput_Qty;

                        dtItems.Rows.Add("0",
                            oWIP_Item.Item_ID,
                            clsGenaralName.getName_Item(oWIP_Item.Item_ID),
                            oWIP_Item.Is_Output ? 1 : 0,
                            oWIP_Item.Uom_ID,
                            clsGenaralName.getName_Uom(oWIP_Item.Uom_ID),
                            cls_Formater.FormatDecimal(oWIP_Item.Planned_Qty, clsConfig.sDecimalPlaces_Quantity),   //PlannedQty
                            cls_Formater.FormatDecimal(dFloor_Qty, clsConfig.sDecimalPlaces_Quantity),              //ProdFloorQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),                       //UtilizedQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),                       //WastagePct
                            cls_Formater.FormatDecimal(oWIP_Item.Waste_Qty, clsConfig.sDecimalPlaces_Quantity),     //Wastage
                            cls_Formater.FormatDecimal(oWIP_Item.Qc_Qty, clsConfig.sDecimalPlaces_Quantity),        //QA_SampleQty
                            cls_Formater.FormatDecimal(oWIP_Item.InputOutput_QtyRate, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                            cls_Formater.FormatDecimal(oWIP_Item.InputOutput_Qty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty
                            oWIP_Item.Output_Section_ID, clsGenaralName.getName_Section(oWIP_Item.Output_Section_ID), //Output Section
                            oWIP_Item.Output_Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oWIP_Item.Output_Activity_ID), //Output Activity
                            oWIP_Item.Remark,                                                                       //Remark
                            cls_Formater.FormatDecimal(dTotal_Qty, clsConfig.sDecimalPlaces_Quantity),              //Total_Qty
                            cls_Formater.FormatDecimal(oWIP_Item.UnitPrice, clsConfig.sDecimalPlaces_Quantity),     //Unit Price
                            cls_Formater.FormatDecimal(oWIP_Item.WeightPrice, clsConfig.sDecimalPlaces_Quantity),   //Weight Price
                            (oWIP_Item.InputOutput_QtyRate < 0 ? "true" : "false"),
                            oWIP_Item.Is_Output ? cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyMadeSemiFG_fromWIPs(txtWIP_ID.Text.Trim(), txtProdJobBoMID.Tag.ToString(), txtProdBatchID.Tag.ToString(), txtSectionActivity.Tag.ToString(), oWIP_Item.Item_ID), clsConfig.sDecimalPlaces_Quantity) : ""
                            );
                    }

                    if (oWIP.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oWIP.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_MeterialGrid_ForSelectedBoM_WithActivity(string sProdJobBoMID, string sProdBatchID, string sProdActivityID)
        {
            try
            {
                Cursor = Cursors.Wait;
                dtItems.Rows.Clear();

                tbl_prod_pharmaMasSectionActivity oActivity = tbl_prod_pharmaMasSectionActivity.Select(sProdActivityID);
                if (oActivity != null)
                {
                    #region Using WIP Flow in BoM Production
                    if (tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(sProdJobBoMID).Any())
                    {
                        foreach (tbl_prod_pharmaTxJobCard_WIPFlow oMat in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(sProdJobBoMID).Where(r => r.OutActivityID == sProdActivityID))
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMat.Item_ID);
                            if (oItem != null)
                            {
                                //Production Section Floor Qty
                                decimal dFloorQty = clsHelpMethods_Prod.Get_FloorQty_WIP_SemiFGs(sProdJobBoMID, sProdBatchID, oMat.Item_ID, sProdActivityID);

                                //WIP Semi Finished Unit Cost Calculation
                                decimal dWipOutSfUnitCost = clsHelpMethods_Prod.Get_WIP_SF_UnitCost(oMat, sProdBatchID);

                                //Add Data Grid to WIP Semi Finished As a Output Item
                                dtItems.Rows.Add("0",
                                    oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID),
                                    1, //Outputs
                                    oMat.Uom_ID, clsGenaralName.getName_Uom(oMat.Uom_ID),
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                    cls_Formater.FormatDecimal(dFloorQty, clsConfig.sDecimalPlaces_Quantity), //Floor Qty
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Utilized Qty
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage Pct
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage Qty
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //QA_Sample Qty
                                    cls_Formater.FormatDecimal(oMat.OutQty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //IO (Input Output) Qty
                                    oMat.InSectionID, clsGenaralName.getName_Section(oMat.InSectionID),                 //Next Section 
                                    oMat.InActivityID, clsGenaralName.getName_PharmaSectionActivity(oMat.InActivityID), //Next Activity
                                    "",
                                    cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),                         //Total Qty
                                    cls_Formater.FormatDecimal(dWipOutSfUnitCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice), //Unit Price
                                    cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice),                //Weight Price
                                    (clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate),
                                    cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyMadeSemiFG_fromWIPs(txtWIP_ID.Text.Trim(), txtProdJobBoMID.Tag.ToString(), txtProdBatchID.Tag.ToString(), txtSectionActivity.Tag.ToString(), oItem.Item_ID), clsConfig.sDecimalPlaces_Quantity)
                                );


                                //WIP Prevoious Semi Finisheds which are linked to this Semi Finished as Inputs
                                foreach (tbl_prod_pharmaTxJobCard_WIPFlow_Detail oMatDetail in tbl_prod_pharmaTxJobCard_WIPFlow_Detail.SelectAllBySf_Index(oMat.Sf_Index))
                                {
                                    tbl_prod_pharmaTxJobCard_WIPFlow oWipSemiMat = tbl_prod_pharmaTxJobCard_WIPFlow.Select(oMatDetail.Wipout_sf_Index);
                                    tbl_genItemMaster oDetailItem = tbl_genItemMaster.Select(oWipSemiMat.Item_ID);
                                    if (oDetailItem != null)
                                    {
                                        //Production Section Floor Qty
                                        decimal dDetailFloorQty = clsHelpMethods_Prod.Get_FloorQty_WIP_SemiFGs(sProdJobBoMID, sProdBatchID, oMatDetail.Item_ID, sProdActivityID);

                                        //WIP Semi Finished Unit Cost Calculation 
                                        decimal dWipSemiMatCost = clsHelpMethods_Prod.Get_WIP_SF_UnitCost(oWipSemiMat, sProdBatchID);

                                        //Add Data Grid to Prevoious WIP Semi Finisheds As a Input Items
                                        dtItems.Rows.Add("0",
                                            oDetailItem.Item_ID, clsGenaralName.getName_Item(oDetailItem.Item_ID),
                                            0, //Inputs
                                            oDetailItem.Uom_ID, clsGenaralName.getName_Uom(oDetailItem.Uom_ID),
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                            cls_Formater.FormatDecimal(dDetailFloorQty, clsConfig.sDecimalPlaces_Quantity), //Floor Qty
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Utilized Qty
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage Pct
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage Qty
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //QA_Sample Qty
                                            cls_Formater.FormatDecimal(oWipSemiMat.OutQty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //IO (Input Output) Qty
                                            "default", "",//Next Section (Always "default' because this is an input item)
                                            "default", "",//Next Activity (Always "default" because this is an input item)
                                            "",
                                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),                        //Total Qty
                                            cls_Formater.FormatDecimal(dWipSemiMatCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice), //Unit Price
                                            cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice),                //Weight Price
                                            (clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate),
                                            ""
                                        );
                                    }
                                }


                                //WIP Raw Materials are added as Inputs
                                foreach (tbl_prod_pharmaTxJobCard_Material oBoMMeterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByWipout_sf_Index(oMat.Sf_Index))
                                {
                                    //Identify the selected material at the Job/Batch creation stage.
                                    tbl_prod_pharmaTxBatch_Material oBatchMaterial = clsHelpMethods_Prod.GetBatchSelected_Material(oBoMMeterial.Line_No, oBoMMeterial.Line_No_Sub1, oBoMMeterial.ProdJob_ID, sProdBatchID);
                                    if (oBatchMaterial != null)
                                    {
                                        tbl_genItemMaster oBoMItem = tbl_genItemMaster.Select(oBatchMaterial.Item_ID);
                                        if (oBoMItem != null)
                                        {
                                            //Set Production Section Floor Quantity
                                            decimal dBoMMatFloorQty = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(clsGenaralName.getStoreID_Section(txtProdSection.Tag.ToString()), oBoMItem.Item_ID);

                                            //Material Unit Cost
                                            decimal dMaterialUnitCost = clsHelpMethods_Prod.GetWeightedAvgCostPrice(oBoMItem);
                                            if (oBatchMaterial.IsSemiFinishItem)
                                            {
                                                dMaterialUnitCost = clsHelpMethods_Prod.Get_FG_UnitCost_BoM(clsHelpMethods_Prod.GetBoM_formFinishedGood(oBatchMaterial.Item_ID));
                                                if (dMaterialUnitCost == 0)
                                                {
                                                    //Sub Out/In Item cost (Need to consider SubOut, SunIn Process)
                                                    dMaterialUnitCost = clsHelpMethods_Prod.Get_SOutItem_UnitCost(oBatchMaterial.ProdJob_ID, oBatchMaterial.Item_ID);
                                                }
                                            }

                                            dtItems.Rows.Add("0", oBoMItem.Item_ID,
                                                clsGenaralName.getName_Item(oBoMItem.Item_ID),
                                                0, //Inputs
                                                oBatchMaterial.Uom_ID, clsGenaralName.getName_Uom(oBatchMaterial.Uom_ID),
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                                cls_Formater.FormatDecimal(dBoMMatFloorQty, clsConfig.sDecimalPlaces_Quantity), //Floor Qty
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //Utilized Qty
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //Inputwastage Pct
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //Inputwastage Qty
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //QA_Sample Qty
                                                cls_Formater.FormatDecimal(oBatchMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //IO (Input Output) Qty
                                                "default", "",//Next Section (Always "default' because this is an input item)
                                                "default", "",//Next Activity (Always "default" because this is an input item)
                                                "",
                                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),               //Total Qty
                                                cls_Formater.FormatDecimal(dMaterialUnitCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice), //Unit Price
                                                cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice),      //Weight Price
                                                (clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate),
                                                ""
                                            );
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    SEACCMessageBox.Show("Activity not selected...", "Please select a production activity", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }

        #endregion

        #region Grid Events

        #region Item Grid Events
        private void dgr_Items_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                clsHelpMethods_Prod.OrderBy_DataGrid(dtItems);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            object item = dgr_Items.SelectedItem;
            string sColumnName = e.Column.SortMemberPath;
            string sOutputItemId = "default";
            switch (sColumnName)
            {
                case "IO_Qty":
                case "Wastage":
                case "QA_SampleQty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;
                    try
                    {
                        dQty = decimal.Parse(t.Text);

                        if (sColumnName == "IO_Qty")
                        {
                            string sItem_ID = ((dgr_Items.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text);
                            string sOutPutSection = ((dgr_Items.SelectedCells[9].Column.GetCellContent(item) as TextBlock)?.Text);
                            string sManualAddItem = ((dgr_Items.SelectedCells[16].Column.GetCellContent(item) as TextBlock)?.Text);
                            string sPrevious_OutputQty = ((dgr_Items.SelectedCells[13].Column.GetCellContent(item) as TextBlock)?.Text);
                            bool bQty_Validation_With_BoM_Qty = true;

                            #region Validation with BoM and Batch Quantities

                            if (sOutPutSection != "default")
                            {
                                decimal dPrevious_OutputQty = clsValidation.Validate_DecimalNumber(sPrevious_OutputQty);
                                tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(txtProdJobBoMID.Tag.ToString());
                                tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Tag.ToString());
                                tbl_prod_pharmaTxJobCard_WIPFlow oWip_OutPut_Item = tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID).FirstOrDefault(r => r.OutActivityID == txtSectionActivity.Tag.ToString() && r.Item_ID == sItem_ID);

                                if (oWip_OutPut_Item != null && !clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate)
                                {
                                    decimal dQty_Validation_Ratio_OutPutItem = 0;
                                    if (oBoM.FGoodQty > 0)
                                        dQty_Validation_Ratio_OutPutItem = (dPrevious_OutputQty + dQty) / oWip_OutPut_Item.OutQty;

                                    if (dQty_Validation_Ratio_OutPutItem % 1 != 0)
                                    {
                                        SEACCMessageBox.Show("Oops..!", "Entered Qty. is not valid for Production...", MessageBoxButton.OK, "Red");
                                        bQty_Validation_With_BoM_Qty = false;
                                        dQty = 0;
                                    }
                                    else if (dQty_Validation_Ratio_OutPutItem > oBatch.BatchQty)
                                    {
                                        SEACCMessageBox.Show("Oops..!", "Entered Qty. is exceeding with respect to planned Batch Qty....", MessageBoxButton.OK, "Red");
                                        bQty_Validation_With_BoM_Qty = false;
                                        dQty = 0;
                                    }
                                }
                            }
                            #endregion

                            if (bQty_Validation_With_BoM_Qty)
                            {
                                if (sOutPutSection == "default" && sManualAddItem == "false" && !clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate)
                                {
                                    SEACCMessageBox.Show("Oops..!", "Can not change BoM Input Material Qty.", MessageBoxButton.OK, "Red");
                                    dQty = 0;
                                }
                                else if (dQty < 0)
                                {
                                    SEACCMessageBox.Show("Oops..!", "Please enter valid value \n I/O Qty. can not be less than zero.", MessageBoxButton.OK, "Red");
                                    dQty = 0;
                                }
                                else
                                {
                                    if (sManualAddItem == "false")
                                        sOutputItemId = ((dgr_Items.SelectedCells[15].Column.GetCellContent(item) as TextBlock)?.Text);
                                }
                            }
                        }
                        else if (sColumnName == "Wastage")
                        {
                            if (dQty < 0)
                            {
                                SEACCMessageBox.Show("Oops..!", "Please enter valid value \n Wastage Qty. can not be less than zero.", MessageBoxButton.OK, "Red");
                                dQty = 0;
                            }
                        }
                        else if (sColumnName == "QA_SampleQty")
                        {
                            if (dQty < 0)
                            {
                                SEACCMessageBox.Show("Oops..!", "Please enter valid value \n QC Qty. can not be less than zero.", MessageBoxButton.OK, "Red");
                                dQty = 0;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }
                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                    break;
            }
            CalculateIOQty(sOutputItemId);
        }

        private void dgr_Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate)
            {
                var vItem = dgr_Items.SelectedItem;
                var vDgCell = dgr_Items.CurrentCell;
                string sLineNo = ((dgr_Items.SelectedCells[0].Column.GetCellContent(vItem) as TextBlock)?.Text);
                DataRow drSelected = sLineNo != null ? dtItems.Select("LineNo = " + sLineNo + "").FirstOrDefault() : null;
                bool bOutPutItem = drSelected != null && (drSelected["InputOutput"].ToString() == "1");

                try
                {
                    if (vDgCell.Column.SortMemberPath != "PlannedQty" &&
                        vDgCell.Column.SortMemberPath != "ProdFloorQty" &&
                        vDgCell.Column.SortMemberPath != "UoM" &&
                        vDgCell.Column.SortMemberPath != "UtilizedQty" &&
                        vDgCell.Column.SortMemberPath != "Wastage" &&
                        vDgCell.Column.SortMemberPath != "QA_SampleQty" &&
                        vDgCell.Column.SortMemberPath != "IO_Qty" &&
                        vDgCell.Column.SortMemberPath != "OutputSectionName" &&
                        vDgCell.Column.SortMemberPath != "OutputActivityName" &&
                        vDgCell.Column.SortMemberPath != "Comments" &&
                        vDgCell.Column.SortMemberPath != "LineNo")
                    {

                        if (drSelected != null)
                            drSelected["InputOutput"] = drSelected["InputOutput"].ToString() == "1" ? "0" : "1";

                        if (drSelected != null && drSelected["InputOutput"].ToString() == "0")
                        {
                            drSelected["OutputSectionID"] = "default";
                            drSelected["OutputSectionName"] = "";

                            drSelected["OutputActivityID"] = "default";
                            drSelected["OutputActivityName"] = "";
                        }
                        else if (drSelected != null && (drSelected["OutputSectionID"].ToString() == "default") && drSelected["InputOutput"].ToString() == "1")
                        {
                            drSelected["OutputSectionName"] = "<Select Section>";
                            drSelected["OutputActivityName"] = "<Select Activity>";
                        }

                    }
                    else if (vDgCell.Column.SortMemberPath == "OutputSectionName" && bOutPutItem)
                    {
                        frm_search RowDataSearch = new frm_search();
                        RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                        RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
                        if (RowDataSearch.DialogResult == true)
                        {
                            drSelected["OutputSectionID"] = lstResult[0];
                            drSelected["OutputSectionName"] = lstResult[1];
                        }
                    }
                    else if (vDgCell.Column.SortMemberPath == "OutputActivityName" && bOutPutItem)
                    {
                        string sSection_ID = drSelected["OutputSectionID"].ToString();
                        List<string> lstParameeters = new List<string>();
                        if (sSection_ID != "default" && sSection_ID != "")
                            lstParameeters.Add(sSection_ID);

                        frm_search RowDataSearch = new frm_search(lstParameeters);
                        RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                        RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSectionActivities);
                        if (RowDataSearch.DialogResult == true)
                        {
                            drSelected["OutputSectionID"] = lstResult[0];
                            drSelected["OutputSectionName"] = lstResult[1];

                            drSelected["OutputActivityID"] = lstResult[2];
                            drSelected["OutputActivityName"] = lstResult[3];
                        }
                    }

                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
        #endregion

        #region Main Grid
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    ClearFields();
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[9].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #endregion

        #region Search Events
        private void RowDataSearch_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtItems.Select("Item_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Meterial Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    decimal dProdFloorQty = 0;
                    decimal dOutputItem_wastagePCt = 0;

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(lstResult[0]);
                    if (oItem != null)
                    {
                        string sSubBoM_ID = "default";
                        tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).FirstOrDefault();
                        if (oProdJob != null)
                        {
                            dOutputItem_wastagePCt = oProdJob.WastePercent;
                            sSubBoM_ID = oProdJob.ProdJob_ID;
                        }

                        dProdFloorQty = clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), oItem.Item_ID);


                        dtItems.Rows.Add(0, oItem.Item_ID, oItem.ItemName, 0, oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //PlannedQty
                            cls_Formater.FormatDecimal(dProdFloorQty, clsConfig.sDecimalPlaces_Quantity), //ProdFloorQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //UtilizedQty
                            cls_Formater.FormatDecimal(dOutputItem_wastagePCt, clsConfig.sDecimalPlaces_Quantity), //InputwastagePct
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //QA_SampleQty
                            cls_Formater.FormatDecimal(-1, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //IO_Qty
                            "default",  //OutputSectionID
                            "",         //OutputSectionName
                            "default",  //OutputActivityID
                            "",         //OutputActivityName
                            "",         //Comments
                            0,          //TotalQty
                            clsHelpMethods_Prod.GetWeightedAvgCostPrice(oItem.Item_ID), //unitPrice
                            0,         //weightPrice
                            "true"

                            );
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtJob_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobBoMID.Tag = lstResult[0];
                txtFG_Item.Tag = lstResult[2];
                txtFinishGoodUOM.Tag = lstResult[8];

                txtFG_Item.ToolTip = lstResult[2];

                txtProdJobBoMID.Text = lstResult[0];
                txtFG_Item.Text = lstResult[3];
                txtFinishGoodUOM.Text = lstResult[4];

                dtItems.Rows.Clear();
                txtProdSection.Tag = null;
                txtProdSection.Text = "";
                txtSectionActivity.Tag = null;
                txtSectionActivity.Text = "";
            }
        }

        private void txtProdSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobBoMID.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
                if (RowDataSearch.DialogResult == true)
                {
                    txtProdSection.Tag = lstResult[0];
                    txtProdSection.Text = lstResult[1];
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void txtSectionActivity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (txtProdBatchID.Tag != null)
                {

                    List<string> lstParameeters = new List<string>();
                    if (txtProdSection.Tag != null && txtProdSection.Tag.ToString() != "default")
                        lstParameeters.Add(txtProdSection.Tag.ToString());

                    frm_search RowDataSearch = new frm_search(lstParameeters);
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSectionActivities);
                    if (RowDataSearch.DialogResult == true)
                    {
                        txtProdSection.Tag = lstResult[0];
                        txtProdSection.Text = lstResult[1];

                        txtSectionActivity.Tag = lstResult[2];
                        txtSectionActivity.Text = lstResult[3];

                        Fill_MeterialGrid_ForSelectedBoM_WithActivity(txtProdJobBoMID.Tag.ToString(), txtProdBatchID.Tag.ToString(), lstResult[2]);
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Job/Batch not selected...", "Please select a Job/Batch...", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtProdBatchID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                if (txtProdJobBoMID.Tag != null)
                {
                    List<string> lstParameeters = new List<string>();
                    lstParameeters.Add(txtProdJobBoMID.Tag.ToString());

                    frm_search RowDataSearch = new frm_search(lstParameeters);
                    RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_Batch);
                    if (RowDataSearch.DialogResult == true)
                    {
                        txtProdBatchID.Tag = lstResult[0];
                        txtProdBatchID.Text = lstResult[0];

                        tbl_prod_pharmaTxBatch oProd_Batch = tbl_prod_pharmaTxBatch.Select(lstResult[0]);
                        tbl_prod_pharmaTxJobCard oProd_BoM = tbl_prod_pharmaTxJobCard.Select(oProd_Batch.ProdJob_ID);
                        txtBatchQty.Text = cls_Formater.FormatDecimal(oProd_Batch.BatchQty * oProd_BoM.FGoodQty, clsConfig.sDecimalPlaces_Quantity);
                    }
                }
                else
                {
                    SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtEnteredBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtEnteredBy.Text = lstResult[1];
                txtEnteredBy.Tag = lstResult[0];
            }
        }

        private void txtCheckedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SEACC_Form.CheckPermission_ToChecked())
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Users);
                if (RowDataSearch.DialogResult == true)
                {
                    txtCheckedBy.Text = lstResult[1];
                    txtCheckedBy.Tag = lstResult[0];
                }
            }
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        #region Scroll Event
        private void UIElement_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scv = sender as ScrollViewer;
            if (scv == null) return;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        #endregion

        #region Other Text Box Events
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (Key.Return == e.Key &&
                0 < (ModifierKeys.Shift & e.KeyboardDevice.Modifiers))
            {
                var tb = (TextBox)sender;
                var caret = tb.CaretIndex;
                tb.Text = tb.Text.Insert(caret, Environment.NewLine);
                tb.CaretIndex = caret + 1;
                e.Handled = true;
            }
        }

        #endregion

        #region Other Events
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //CalculateIOQty();
        }
        #endregion

        #region Help Methods

        private void CalculateIOQty(string sOutputItem_ID)
        {
            try
            {
                DataRow drOutputItem;
                if (sOutputItem_ID != "default")
                    drOutputItem = dtItems.Select("Item_ID = '" + sOutputItem_ID + "'").FirstOrDefault();
                else
                    drOutputItem = dtItems.Select("InputOutput = 1").FirstOrDefault();

                if (drOutputItem != null)
                {
                    decimal dOutQty_rate = clsValidate.ValidateRowValue(drOutputItem, "IO_Qty_Rate", 0m);
                    decimal dOutQty = clsValidate.ValidateRowValue(drOutputItem, "IO_Qty", 0m);
                    decimal dMultiplyRatio = dOutQty_rate != 0m ? decimal.Round(dOutQty / dOutQty_rate, clsConfig.sDecimalPlaces_Quantity) : 1m;

                    if (!clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate)
                    {

                        foreach (DataRow drInput in dtItems.Select("ManuallyAdd = 'false'"))
                        {
                            decimal dWastage = clsValidate.ValidateRowValue(drInput, "Wastage", 0m);
                            decimal dQA_SampleQty = clsValidate.ValidateRowValue(drInput, "QA_SampleQty", 0m);
                            //decimal dIOQty = clsValidate.ValidateRowValue(drInput, "IO_Qty", 0);

                            string sOutput_SectionID = clsValidate.ValidateRowValue(drInput, "OutputSectionID", "default");
                            decimal dIO_Rate = clsValidate.ValidateRowValue(drInput, "IO_Qty_Rate", 0m);
                            decimal dIOQty = dIO_Rate * dMultiplyRatio;
                            drInput["IO_Qty"] = cls_Formater.FormatDecimal(dIOQty, clsConfig.sDecimalPlaces_Quantity);
                            drInput["TotalQty"] = cls_Formater.FormatDecimal(dIOQty + dWastage + dQA_SampleQty, clsConfig.sDecimalPlaces_Quantity);
                        }

                        foreach (DataRow drInput in dtItems.Select("ManuallyAdd = 'true'"))
                        {
                            decimal dWastage = clsValidate.ValidateRowValue(drInput, "Wastage", 0m);
                            decimal dQA_SampleQty = clsValidate.ValidateRowValue(drInput, "QA_SampleQty", 0m);
                            decimal dIO_Qty = clsValidate.ValidateRowValue(drInput, "IO_Qty", 0m);

                            drInput["TotalQty"] = cls_Formater.FormatDecimal(dIO_Qty + dWastage + dQA_SampleQty, clsConfig.sDecimalPlaces_Quantity);
                        }
                    }
                    else if (clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate)
                    {
                        foreach (DataRow drInput in dtItems.Select())
                        {
                            decimal dWastage = clsValidate.ValidateRowValue(drInput, "Wastage", 0m);
                            decimal dQA_SampleQty = clsValidate.ValidateRowValue(drInput, "QA_SampleQty", 0m);
                            decimal dIO_Qty = clsValidate.ValidateRowValue(drInput, "IO_Qty", 0m);

                            drInput["TotalQty"] = cls_Formater.FormatDecimal(dIO_Qty + dWastage + dQA_SampleQty, clsConfig.sDecimalPlaces_Quantity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private bool WIP_ValidateIOQty()
        {
            bool bReturn = false;
            string sMsg = "";
            foreach (DataRow row in dtItems.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sItem_Name = clsValidate.ValidateRowValue(row, "Item_Name", "-");
                decimal dIO_Qty = clsValidate.ValidateRowValue(row, "IO_Qty", 0m);

                if (dIO_Qty == 0)
                {
                    sMsg += "Line No : " + iLine_no + "  " + sItem_ID + " - " + sItem_Name + "\n";
                }
            }

            if (sMsg.Length > 1)
                bReturn = SEACCMessageBox.Show("Not Set Material I/O Qty", sMsg + "\nAre you sure to continue? ", MessageBoxButton.YesNo, "Red");
            else
                bReturn = true;

            return bReturn;
        }

        private void WIP_InsertMaterials()
        {
            foreach (DataRow row in dtItems.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                int iInputOutput = Convert.ToInt32(clsValidate.ValidateRowValue(row, "InputOutput", 0m));
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0m);
                decimal dProdFloorQty = clsValidate.ValidateRowValue(row, "ProdFloorQty", 0m);
                decimal dUtilizedQty = clsValidate.ValidateRowValue(row, "UtilizedQty", 0m);
                decimal dWastage = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                decimal dQA_SampleQty = clsValidate.ValidateRowValue(row, "QA_SampleQty", 0m);
                decimal dIO_Qty_Rate = clsValidate.ValidateRowValue(row, "IO_Qty_Rate", 0m);
                decimal dIO_Qty = clsValidate.ValidateRowValue(row, "IO_Qty", 0m);
                string sOutputSectionID = clsValidate.ValidateRowValue(row, "OutputSectionID", "default");
                string sOutputActivityID = clsValidate.ValidateRowValue(row, "OutputActivityID", "default");
                string sRemark = clsValidate.ValidateRowValue(row, "Comments", "");
                decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                decimal dUnitPrice = clsValidate.ValidateRowValue(row, "unitPrice", 0m);
                decimal dWeightPrice = clsValidate.ValidateRowValue(row, "weightPrice", 0m);
                decimal dTotalAmount = (iInputOutput == 0) ? dUnitPrice * (dIO_Qty + dWastage) : 0;

                tbl_prod_pharmaTxWorkInProgress_Material oWipMaterials = new tbl_prod_pharmaTxWorkInProgress_Material(iLine_no, txtWIP_ID.Tag.ToString(), sItem_ID, sUoM_ID, dPlannedQty, dProdFloorQty, dWastage, dQA_SampleQty, dIO_Qty_Rate, dIO_Qty, 0, dUnitPrice, dWeightPrice, dTotalAmount, sRemark, iInputOutput == 1, sOutputSectionID, sOutputActivityID);
                oWipMaterials.Insert();

                if (iInputOutput == 1)
                {
                    clsHelpMethods_Prod.Update_ItemFinanceCosts(sItem_ID, dUnitPrice, dIO_Qty, dUnitPrice, 0m);
                    clsHelpMethods_Prod.UpdateSectionFloorStock(sOutputSectionID, sItem_ID, dIO_Qty);
                }
                else
                    clsHelpMethods_Prod.UpdateSectionFloorStock(txtProdSection.Tag.ToString(), sItem_ID, -dTotalQty);

                OutputItem_CostingCalculation_with_Wastage();
            }
        }
        #endregion

        private void OutputItem_CostingCalculation_with_Wastage()
        {
            decimal dInputs_Cost = 0m;
            foreach (tbl_prod_pharmaTxWorkInProgress_Material oInput in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(txtWIP_ID.Tag.ToString()).Where(r => !r.Is_Output))
                dInputs_Cost += oInput.TotalAmount;

            tbl_prod_pharmaTxWorkInProgress_Material oOutput = tbl_prod_pharmaTxWorkInProgress_Material
                .SelectAllByWip_ID(txtWIP_ID.Tag.ToString()).Where(r => r.Is_Output).FirstOrDefault();
            if (oOutput != null && oOutput.InputOutput_Qty != 0)
            {
                oOutput.TotalAmount = dInputs_Cost;
                oOutput.UnitPrice = dInputs_Cost / oOutput.InputOutput_Qty;
                oOutput.Update();
            }


        }

        private void btnPostCostingCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;

                foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAll())
                {
                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oMaterial in
                        tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID))
                    {
                        if (oMaterial.Item_ID == oWIP.Item_ID_FG)
                        {
                            decimal dFG_totalCost = 0m;
                            foreach (tbl_prod_pharmaTxWorkInProgress_Material oMaterial_PC in
                                tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID)
                                    .Where(r => !r.Is_Output))
                            {
                                dFG_totalCost += oMaterial_PC.TotalAmount;
                            }

                            oMaterial.TotalAmount = Math.Round(dFG_totalCost, 2);
                            oMaterial.UnitPrice = Math.Round(oMaterial.TotalAmount / oMaterial.InputOutput_Qty, 2);
                            oMaterial.Update();

                            foreach (tbl_prod_pharmaTxFinishedGoodTransferNote oFGTN in tbl_prod_pharmaTxFinishedGoodTransferNote.SelectAllByProdBatch_ID(oWIP.ProdBatch_ID))
                            {
                                oFGTN.UnitPrice = oMaterial.UnitPrice;
                                oFGTN.TotalAmount = oFGTN.FgtnQty * oMaterial.UnitPrice;
                                oFGTN.Update();
                            }

                            foreach (tbl_prod_pharmaTxBatch_Closure oClosure in tbl_prod_pharmaTxBatch_Closure.SelectAllByProdJob_ID(oWIP.ProdJob_ID).Where(r => r.ProdBatch_ID == oWIP.ProdBatch_ID))
                            {
                                oClosure.UnitCost_Actual_FG = oMaterial.UnitPrice;
                                oClosure.TotalCost_Actual_FG = oClosure.Qty_Actual_FG * oMaterial.UnitPrice;
                                oClosure.Update();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }
        }
    }
}
