using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace SEACC_PRODUCTION_POLY.Transactions
{
    /// <summary>
    /// Interaction logic for UC_WorkInProgress.xaml
    /// </summary>
    public partial class UC_WorkInProgress : UserControl
    {
        #region Class Variables
        DataTable dtItems = new DataTable();
        BrushConverter bc = new BrushConverter();
        frm_search RowDataSearch;
        #endregion

        #region Form Load
        public UC_WorkInProgress()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_WIP;
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
            dtItems.Columns.Add("Comments");
            dtItems.Columns.Add("SubBoM_ID");
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("WIP#");
            dgr_Main.dt.Columns.Add("WIP_DATE");
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
            dgr_Main.Add_DatagridColoumn("WIP Date", "WIP_DATE", 75);
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
                                tbl_prod_polyTxWorkInProgress oOldWIP = tbl_prod_polyTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
                                if (oOldWIP != null)
                                {
                                    if (!oOldWIP.IsApproved && !oOldWIP.IsCanceled)
                                    {

                                        tbl_prod_polyTxWorkInProgress oWIP = new tbl_prod_polyTxWorkInProgress(txtWIP_ID.Tag.ToString(), dtpWIP_Date.GetDateTime(), dtpProdJob_Date.GetDateTime(),
                                        txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                        txtFG_Item.Tag != null ? txtFG_Item.Tag.ToString() : "default",
                                        txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                        txtFinishGoodUOM_weight.Tag != null ? txtFinishGoodUOM_weight.Tag.ToString() : "default",
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodWeight.Text),
                                        txtProdSection.Tag != null ? txtProdSection.Tag.ToString() : "default",
                                        dtpJobInTime.GetDateTime(), txtProdSupervisor.Text, txtQA_Officer.Text, txtMachineOperator.Text, txtMachineOfficer.Text,
                                        (txtCheckedBy.Tag != null ? true : false), oOldWIP.IsApproved, oOldWIP.IsCanceled,
                                         oOldWIP.CreateUser_ID, (txtEnteredBy.Tag != null ? txtEnteredBy.Tag.ToString() : clsSecurity.UserIDLoged), (txtCheckedBy.Tag != null ? txtCheckedBy.Tag.ToString() : "default"), oOldWIP.ApprovedUser_ID, oOldWIP.CanceldUser_ID,
                                         oOldWIP.DateCreate, clsSecurity.getServerDateTime(), oOldWIP.DateChecked, oOldWIP.DateApproved, oOldWIP.DateCanceled,
                                         oOldWIP.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldWIP.CheckedUserTerminal_ID, oOldWIP.ApprovedUserTerminal_ID, oOldWIP.CanceledUserTerminal_ID,
                                         oOldWIP.CompanyID, oOldWIP.CompanyBranchID);
                                        oWIP.Update();

                                        foreach (tbl_prod_polyTxWorkInProgress_Material oWIP_Items in tbl_prod_polyTxWorkInProgress_Material.SelectAllByWip_ID(txtWIP_ID.Tag.ToString()))
                                        {
                                            if (oWIP_Items.Is_Output)
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oWIP_Items.Output_Section_ID, oWIP_Items.Item_ID, -oWIP_Items.InputOutput_Qty);
                                            else
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oOldWIP.Section_ID, oWIP_Items.Item_ID, oWIP_Items.InputOutput_Qty);
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
                                tbl_prod_polyTxWorkInProgress oNewWIP = new tbl_prod_polyTxWorkInProgress(txtWIP_ID.Tag.ToString(), dtpWIP_Date.GetDateTime(), dtpProdJob_Date.GetDateTime(),
                                    txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                    txtFG_Item.Tag != null ? txtFG_Item.Tag.ToString() : "default",
                                    txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                    txtFinishGoodUOM_weight.Tag != null ? txtFinishGoodUOM_weight.Tag.ToString() : "default",
                                    clsValidation.Validate_DecimalNumber(txtFinishGoodQty.Text),
                                    clsValidation.Validate_DecimalNumber(txtFinishGoodWeight.Text),
                                    txtProdSection.Tag != null ? txtProdSection.Tag.ToString() : "default",
                                    dtpJobInTime.GetDateTime(), txtProdSupervisor.Text, txtQA_Officer.Text, txtMachineOperator.Text, txtMachineOfficer.Text,
                                    (txtCheckedBy.Tag != null ? true : false), false, false,
                                    txtEnteredBy.Tag != null ? txtEnteredBy.Tag.ToString() : clsSecurity.UserIDLoged, "default", txtCheckedBy.Tag != null ? txtCheckedBy.Tag.ToString() : "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID
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
                        fillDetails(sWIP_ID);
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
                        tbl_prod_polyTxWorkInProgress oWIP = tbl_prod_polyTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
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
                                fillDetails(oWIP.Wip_ID);
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
                            tbl_prod_polyTxWorkInProgress oWIP = tbl_prod_polyTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
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

                                                foreach (tbl_prod_polyTxWorkInProgress_Material oWIP_Items in tbl_prod_polyTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID))
                                                {
                                                    if (oWIP_Items.Is_Output)
                                                        clsHelpMethods_Prod.UpdateSectionFloorStock(oWIP_Items.Output_Section_ID, oWIP_Items.Item_ID, -oWIP_Items.InputOutput_Qty);
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
            if (txtProdSection.Tag != null && txtProdJobID.Tag != null)
            {
                RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMaterials, true);
                RowDataSearch.RowSelected += RowDataSearch_RowSelected;

            }
            else
            {
                if (txtProdSection.Tag == null)
                    SEACCMessageBox.Show("Production Section Can not be Empty", "Please select a Production Section before adding items", MessageBoxButton.OK, "Red");
                else if (txtProdJobID.Tag == null)
                    SEACCMessageBox.Show("BoM Can not be Empty", "Please select a BoM before adding items", MessageBoxButton.OK, "Red");
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Item, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodWeight, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM_weight, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodUOM_weight, true, true, false);

            cls_Formater.SetEnableDisable_LableTextbox(txtProdSupervisor, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtQA_Officer, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMachineOperator, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtMachineOfficer, true, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEnteredBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCheckedBy, true, false, false);


            txtWIP_ID.Tag = null;
            txtProdJobID.Tag = null;
            txtFG_Item.Tag = null;
            txtFinishGoodUOM.Tag = null;
            txtFinishGoodUOM_weight.Tag = null;
            txtProdSection.Tag = null;
            txtProdSupervisor.Tag = null;
            txtQA_Officer.Tag = null;
            txtMachineOperator.Tag = null;
            txtMachineOfficer.Tag = null;

            txtEnteredBy.Tag = clsSecurity.UserIDLoged;
            txtCheckedBy.Tag = null;


            txtWIP_ID.Text = "";
            txtProdJobID.Text = "";
            txtFG_Item.Text = "";
            txtFinishGoodUOM.Text = "";
            txtFinishGoodQty.Text = "0.000";
            txtFinishGoodUOM_weight.Text = "";
            txtFinishGoodWeight.Text = "0.000";
            txtProdSection.Text = "";
            txtProdSupervisor.Text = "";
            txtQA_Officer.Text = "";
            txtMachineOperator.Text = "";
            txtMachineOfficer.Text = "";

            txtEnteredBy.Text = clsSecurity.UserNameLoged;
            txtCheckedBy.Text = "";

            dtpWIP_Date.SetTime(DateTime.Now);
            dtpJobInTime.SetTime(DateTime.Now);
            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpWorkStartTime.SetTime(DateTime.Now);

            dtItems.Clear();
            dgr_Items.ItemsSource = dtItems.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

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
                foreach (tbl_prod_polyTxWorkInProgress oWIP in tbl_prod_polyTxWorkInProgress.SelectAll().Where(p => p.Wip_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oWIP.Wip_ID, oWIP.Wip_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_User(oWIP.CreateUser_ID), clsGenaralName.getName_User(oWIP.ApprovedUser_ID), oWIP.IsCanceled);
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
                if (CheckValidity_DuplicateFiled())
                    if (CheckOutputSectionSelect())
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
            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFG_Item))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodQty))
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

        private bool CheckOutputSectionSelect()
        {
            bool bSelectOutputSection = true;
            if (dtItems.Select("OutputSectionName <> '<Select Section>'").Count()  < 1)
            {
                bSelectOutputSection = false;
                SEACCMessageBox.Show("Oops..!", "Please select Output Section....", MessageBoxButton.OK, "Red");
            }
            return bSelectOutputSection;
        }

        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                tbl_prod_polyTxWorkInProgress oWIP = tbl_prod_polyTxWorkInProgress.Select(sID);
                if (oWIP != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtWIP_ID.Tag = oWIP.Wip_ID;
                    txtProdJobID.Tag = oWIP.ProdJob_ID;
                    txtFG_Item.Tag = oWIP.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oWIP.Uom_ID;
                    txtProdSection.Tag = oWIP.Section_ID;

                    txtEnteredBy.Tag = oWIP.CreateUser_ID;
                    txtCheckedBy.Tag = oWIP.CheckedUser_ID;

                    dtpWIP_Date.SetTime(oWIP.Wip_Date);
                    dtpJobInTime.SetTime(oWIP.Job_InTime);
                    dtpProdJob_Date.SetTime(oWIP.Prod_Date);
                    dtpWorkStartTime.SetTime(oWIP.Job_InTime);


                    txtWIP_ID.Text = oWIP.Wip_ID;
                    txtProdJobID.Text = oWIP.ProdJob_ID;
                    txtFG_Item.Text = clsGenaralName.getDescription_Item(oWIP.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oWIP.Uom_ID);
                    txtFinishGoodQty.Text = cls_Formater.FormatDecimal(oWIP.FGoodQty, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishGoodUOM_weight.Text = clsGenaralName.getName_UomAndCode(oWIP.Uom_ID_Weight);
                    txtFinishGoodWeight.Text = cls_Formater.FormatDecimal(oWIP.FGoodWeight, clsConfig.sDecimalPlaces_Weight);
                    txtProdSection.Text = clsGenaralName.getName_Section(oWIP.Section_ID);
                    txtProdSupervisor.Text = oWIP.Supervisor;
                    txtQA_Officer.Text = oWIP.Qa_Officer;
                    txtMachineOperator.Text = oWIP.Machine_Operator;
                    txtMachineOfficer.Text = oWIP.Maintainance_Officer;

                    txtEnteredBy.Text = clsGenaralName.getName_User(oWIP.CreateUser_ID);
                    txtCheckedBy.Text = clsGenaralName.getName_User(oWIP.CheckedUser_ID);

                    dtItems.Rows.Clear();
                    foreach (tbl_prod_polyTxWorkInProgress_Material oWIP_Item in tbl_prod_polyTxWorkInProgress_Material.SelectAll().Where(r => r.Wip_ID == sID))
                    {
                        dtItems.Rows.Add("0",
                            oWIP_Item.Item_ID,
                            clsGenaralName.getName_Item(oWIP_Item.Item_ID),
                            oWIP_Item.Is_Output ? 1 : 0,
                            oWIP_Item.Uom_ID,
                            clsGenaralName.getName_Uom(oWIP_Item.Uom_ID),
                            cls_Formater.FormatDecimal(oWIP_Item.Planned_Qty, clsConfig.sDecimalPlaces_Quantity),//PlannedQty
                            cls_Formater.FormatDecimal(oWIP_Item.Floor_Qty, clsConfig.sDecimalPlaces_Quantity), //ProdFloorQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //UtilizedQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //WastagePct
                            cls_Formater.FormatDecimal(oWIP_Item.Waste_Qty, clsConfig.sDecimalPlaces_Quantity), //Wastage
                            cls_Formater.FormatDecimal(oWIP_Item.Qc_Qty, clsConfig.sDecimalPlaces_Quantity), //QA_SampleQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                            cls_Formater.FormatDecimal(oWIP_Item.InputOutput_Qty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty
                            oWIP_Item.Output_Section_ID,
                            clsGenaralName.getName_Section(oWIP_Item.Output_Section_ID),
                            oWIP_Item.Remark, "-");
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

        private void Fill_MeterialGrid_ForSelectedBoM(string sProdJobBoMID, string sProdSectionID)
        {
            try
            {
                Cursor = Cursors.Wait;
                dtItems.Rows.Clear();

                //    tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sProdSectionID);

                //    if (oSection != null)
                //    {
                //        foreach (tbl_prodTxJobCard_Material oBoM_Meterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJobBoMID).Where(r => r.Section_ID == oSection.Section_ID))
                //        {
                //            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oBoM_Meterial.Item_ID);
                //            if (oItem != null)
                //            {
                //                decimal dFloor_Qty = clsProcessMethods.Get_StoreStockBalance_Qty(oSection.Store_ID, oBoM_Meterial.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                //                decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(txtProdJobID.Tag.ToString());
                //                dtItems.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), 0, oBoM_Meterial.Uom_ID, clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                //                    cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dCustomerOrder_Qty, 3), //BoM Qty ,(Planned Qty)
                //                    cls_Formater.FormatDecimal(dFloor_Qty, 3),        //Floor Qty
                //                    cls_Formater.FormatDecimal(0, 3), //Utilized Qty
                //                    cls_Formater.FormatDecimal(0, 3), //Inputwastage Pct
                //                    cls_Formater.FormatDecimal(0, 3), //Inputwastage Qty
                //                    cls_Formater.FormatDecimal(0, 3), //QA_Sample Qty
                //                    cls_Formater.FormatDecimal(0, 3), //IO (Input Output) Qty
                //                    "default", "", "");
                //            }
                //        }

                //        foreach (tbl_prod_polyTxWorkInProgress oWIP in tbl_prod_polyTxWorkInProgress.SelectAllByProdJob_ID(sProdJobBoMID))
                //        {
                //            foreach (tbl_prod_polyTxWorkInProgress_Material oWIP_Detail in tbl_prod_polyTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Is_Output && r.Output_Section_ID == sProdSectionID))
                //            {
                //                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWIP_Detail.Item_ID);
                //                if (oItem != null)
                //                {
                //                    decimal dFloor_Qty = clsProcessMethods.Get_StoreStockBalance_Qty(oSection.Store_ID, oWIP_Detail.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");

                //                    dtItems.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), 0, oWIP_Detail.Uom_ID, clsGenaralName.getName_Uom(oWIP_Detail.Uom_ID),
                //                        cls_Formater.FormatDecimal(oWIP_Detail.InputOutput_Qty, 3), //BoM Qty
                //                        cls_Formater.FormatDecimal(dFloor_Qty, 3),        //Floor Qty
                //                        cls_Formater.FormatDecimal(0, 3), //Utilized Qty
                //                        cls_Formater.FormatDecimal(0, 3), //Inputwastage Qty
                //                        cls_Formater.FormatDecimal(0, 3), //QA_Sample Qty
                //                        cls_Formater.FormatDecimal(0, 3), //IO (Input Output) Qty
                //                        "default", "", "");
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        SEACCMessageBox.Show("Section not selected...", "Please select a production section", MessageBoxButton.OK, "Red");
                //    }

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
                        tbl_prod_polyTxJobCard oProdJob = tbl_prod_polyTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).FirstOrDefault();
                        if (oProdJob != null)
                        {
                            dOutputItem_wastagePCt = oProdJob.WastePercent;
                            sSubBoM_ID = oProdJob.ProdJob_ID;
                        }

                        dProdFloorQty = clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");

                        dtItems.Rows.Add(0, oItem.Item_ID, oItem.ItemName, 1, oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID),
                            cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity), //PlannedQty
                            cls_Formater.FormatDecimal(dProdFloorQty, clsConfig.sDecimalPlaces_Quantity), //ProdFloorQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //UtilizedQty
                            cls_Formater.FormatDecimal(dOutputItem_wastagePCt, clsConfig.sDecimalPlaces_Quantity), //InputwastagePct
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //QA_SampleQty
                            cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate
                            cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity), //IO_Qty
                            "default", "<Select Section>", "", sSubBoM_ID);

                        if (oItem.IsSemiFinishGood)
                        {
                            if (oProdJob != null)
                            {
                                foreach (tbl_prodTxJobCard_Material oProJobMaterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oProdJob.ProdJob_ID))
                                {
                                    dProdFloorQty = clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), oProJobMaterial.Item_ID, "default", "default", "default", "0", "0");

                                    dtItems.Rows.Add(0, oProJobMaterial.Item_ID, clsGenaralName.getName_Item(oProJobMaterial.Item_ID), 0, oProJobMaterial.Uom_ID, clsGenaralName.getName_Uom(oProJobMaterial.Uom_ID),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //PlannedQty
                                        cls_Formater.FormatDecimal(dProdFloorQty, clsConfig.sDecimalPlaces_Quantity),//ProdFloorQty
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //UtilizedQty
                                        cls_Formater.FormatDecimal(oProJobMaterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity), //InputwastagePct
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //Inputwastage
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //QA_SampleQty
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty_Rate (In future task => Need to divide BoM Qty, Celcius All Bom are Bom Qty is 1)
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity), //IO_Qty
                                        "default", "-", "", oProdJob.ProdJob_ID);
                                }
                            }
                        }
                    }
                }
                RowDataSearch.Close();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtProdSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobID.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                if (RowDataSearch.DialogResult == true)
                {
                    txtProdSection.Tag = lstResult[0];
                    txtProdSection.Text = lstResult[1];
                    //Fill_MeterialGrid_ForSelectedBoM(txtProdJobID.Tag.ToString(), lstResult[0]);
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void txtJob_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtProdJobID.Text = lstResult[0];

                txtFG_Item.Tag = lstResult[2];
                txtFG_Item.Text = lstResult[3];

                txtFinishGoodUOM.Tag = lstResult[8];
                txtFinishGoodUOM.Text = lstResult[4];


                decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(txtProdJobID.Tag.ToString());
                tbl_prod_polyTxJobCard oBom = tbl_prod_polyTxJobCard.Select(lstResult[0]);
                if (oBom != null)
                {
                    txtFinishGoodUOM_weight.Tag = oBom.Item_Weight_UoM_ID;
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oBom.Item_Weight_UoM_ID);
                    txtFinishGoodWeight.Text = cls_Formater.FormatDecimal( oBom.OrderedWeight, clsConfig.sDecimalPlaces_Quantity);
                }


                
                txtFinishGoodQty.Text = cls_Formater.FormatDecimal(decimal.Parse(lstResult[6]) * dCustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity);

                dtItems.Rows.Clear();
                txtProdSection.Tag = null;
                txtProdSection.Text = "";
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

        #region Grid Events

        #region Item Grid Events
        private void dgr_Items_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Common.clsHelpMethods_Prod.OrderBy_DataGrid(dtItems);
        }

        private void dgr_Items_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //int irowID = dgr_Items.SelectedIndex;
            //var vDG_Cell = dgr_Items.CurrentCell;
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnName == "ProdFloorQty" || sColumnName == "UtilizedQty" || sColumnName == "Inputwastage" || sColumnName == "QA_SampleQty" || sColumnName == "IO_Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    dQty = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }

            CalculateIOQty();
            //CalculateIOQty(dtItems.Rows[irowID]["SubBoM_ID"].ToString());
        }

        private void dgr_Items_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_Items.SelectedIndex;
            var vDG_Cell = dgr_Items.CurrentCell;
            try
            {
                bool bOutPutItem = (dtItems.Rows[irowID]["InputOutput"].ToString() == "1");
                if (vDG_Cell.Column.SortMemberPath == "OutputSectionName" && bOutPutItem)
                {
                    frm_search RowDataSearch = new frm_search();
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtItems.Rows[irowID]["OutputSectionID"] = lstResult[0];
                        dtItems.Rows[irowID]["OutputSectionName"] = lstResult[1];
                    }
                }
            }
            catch (Exception ex)
            { }
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
                    fillDetails(GridID);
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[5].ToString()))
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

        #region MyRegion
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
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

        #region Help Methods

        private bool WIP_ValidateIOQty()
        {
            bool bReturn = false;
            string sMsg = "";
            foreach (DataRow row in dtItems.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sItem_Name = clsValidate.ValidateRowValue(row, "Item_Name", "-");
                decimal dIO_Qty = clsValidate.ValidateRowValue(row, "IO_Qty", 0);

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
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                int iInputOutput = Convert.ToInt32(clsValidate.ValidateRowValue(row, "InputOutput", 0));
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0);
                decimal dProdFloorQty = clsValidate.ValidateRowValue(row, "ProdFloorQty", 0);
                decimal dUtilizedQty = clsValidate.ValidateRowValue(row, "UtilizedQty", 0);
                decimal dWastage = clsValidate.ValidateRowValue(row, "Wastage", 0);
                decimal dQA_SampleQty = clsValidate.ValidateRowValue(row, "QA_SampleQty", 0);
                decimal dIO_Qty = clsValidate.ValidateRowValue(row, "IO_Qty", 0);
                string sUoM_ID_Weight = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dPlanned_Weight = clsValidate.ValidateRowValue(row, "PlannedQty", 0);
                decimal dProdFloor_Weight = clsValidate.ValidateRowValue(row, "ProdFloorQty", 0);
                decimal dUtilized_Weight = clsValidate.ValidateRowValue(row, "UtilizedQty", 0);
                decimal dWastage_Weight = clsValidate.ValidateRowValue(row, "Wastage", 0);
                decimal dQA_Sample_Weight = clsValidate.ValidateRowValue(row, "QA_SampleQty", 0);
                decimal dIO_Weight = clsValidate.ValidateRowValue(row, "IO_Qty", 0);
                string sOutputSectionID = clsValidate.ValidateRowValue(row, "OutputSectionID", "default");
                string sRemark = clsValidate.ValidateRowValue(row, "Comments", "");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                tbl_genItemMaster_Finance oItem_Finance = tbl_genItemMaster_Finance.Select(sItem_ID, (oItem != null ? oItem.ItemCategorySub_ID : "default"), "default", "0", "0");
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dIO_Qty;
                }

                tbl_prod_polyTxWorkInProgress_Material oWIP_Materials = new tbl_prod_polyTxWorkInProgress_Material(iLine_no, txtWIP_ID.Tag.ToString(), sItem_ID, sUoM_ID, sUoM_ID_Weight,
                    dPlannedQty, dProdFloorQty, dWastage, dQA_SampleQty, dIO_Qty,
                    dPlanned_Weight, dProdFloor_Weight, dWastage, dQA_Sample_Weight, dIO_Weight, dUnitPrice, 0, dTotalAmount,
                    sRemark, iInputOutput == 1 ? true : false, sOutputSectionID);
                oWIP_Materials.Insert();

                if (iInputOutput == 1)
                    clsHelpMethods_Prod.UpdateSectionFloorStock(sOutputSectionID, sItem_ID, dIO_Qty);
                else
                    clsHelpMethods_Prod.UpdateSectionFloorStock(txtProdSection.Tag.ToString(), sItem_ID, -dIO_Qty);
            }
        }
        #endregion

        private void CalculateIOQty() // CalculateIOQty(string sSubBomID)
        {
            try
            {
                //DataRow drOutput = dtItems.Select("InputOutput = 1 AND SubBoM_ID = '" + sSubBomID + "' ").FirstOrDefault();
                DataRow drOutput = dtItems.Select("InputOutput = 1").FirstOrDefault();
                decimal dOutputItem_OutputQty = clsValidate.ValidateRowValue(drOutput, "IO_Qty", 0);
                decimal dOutputItem_InputWastagePct = clsValidate.ValidateRowValue(drOutput, "WastagePct", 0);

                if (dOutputItem_InputWastagePct < 100)
                {
                    decimal dOutputItem_InputQty = decimal.Round(((dOutputItem_OutputQty * 100) / (100 - dOutputItem_InputWastagePct)), int.Parse(clsConfig.sDecimalPlaces_Quantity));

                    drOutput["PlannedQty"] = cls_Formater.FormatDecimal(dOutputItem_InputQty, clsConfig.sDecimalPlaces_Quantity);
                    drOutput["Wastage"] = cls_Formater.FormatDecimal(dOutputItem_InputQty - dOutputItem_OutputQty, clsConfig.sDecimalPlaces_Quantity);
                }
                else
                {
                    drOutput["PlannedQty"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    drOutput["Wastage"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                }

                foreach (DataRow drInput in dtItems.Select("InputOutput = 0"))
                {
                    decimal dInputItem_Qty_Rate = clsValidate.ValidateRowValue(drInput, "IO_Qty_Rate", 0);
                    decimal dInputItem_InputWastagePct = clsValidate.ValidateRowValue(drInput, "WastagePct", 0);
                    decimal dIOQty = decimal.Round((dInputItem_Qty_Rate * dOutputItem_OutputQty), int.Parse(clsConfig.sDecimalPlaces_Quantity));

                    drInput["IO_Qty"] = cls_Formater.FormatDecimal(dIOQty, clsConfig.sDecimalPlaces_Quantity);

                    if (dInputItem_InputWastagePct < 100)
                    {
                        decimal dInputputItem_InputQty = decimal.Round(((dIOQty * 100) / (100 - dInputItem_InputWastagePct)), int.Parse(clsConfig.sDecimalPlaces_Quantity));

                        drInput["PlannedQty"] = cls_Formater.FormatDecimal(dInputputItem_InputQty, clsConfig.sDecimalPlaces_Quantity);
                        drInput["Wastage"] = cls_Formater.FormatDecimal(dInputputItem_InputQty - dIOQty, clsConfig.sDecimalPlaces_Quantity);
                    }
                    else
                    {
                        drInput["PlannedQty"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                        drInput["Wastage"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

    }
}
