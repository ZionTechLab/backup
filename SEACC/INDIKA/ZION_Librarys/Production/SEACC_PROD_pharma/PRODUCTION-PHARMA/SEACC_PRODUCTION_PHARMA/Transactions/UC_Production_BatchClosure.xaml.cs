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

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Interaction logic for UC_ProductionJobClosure.xaml
    /// </summary>
    public partial class UC_Production_BatchClosure : UserControl
    {
        #region Class Variables
        DataTable dtBoM_Meterials = new DataTable();
        DataTable dtFinished_Goods = new DataTable();
        #endregion

        #region Form Load
        public UC_Production_BatchClosure()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_BOMClosure;
            SEACC_Form.Initialize();

            #region Meterial Table
            dtBoM_Meterials.Columns.Add("LineNo");
            dtBoM_Meterials.Columns.Add("ItemCode");
            dtBoM_Meterials.Columns.Add("ItemName");
            dtBoM_Meterials.Columns.Add("UoM_ID");
            dtBoM_Meterials.Columns.Add("UoM");
            dtBoM_Meterials.Columns.Add("BoMQty");
            dtBoM_Meterials.Columns.Add("MRQty");
            dtBoM_Meterials.Columns.Add("pGINQty");
            dtBoM_Meterials.Columns.Add("pGRNQty");
            dtBoM_Meterials.Columns.Add("UsedQty");//Net Qty
            dtBoM_Meterials.Columns.Add("WIPQty");
            dtBoM_Meterials.Columns.Add("DifQty");//Difference
            #endregion

            #region Finished Good Table
            dtFinished_Goods.Columns.Add("LineNo");
            dtFinished_Goods.Columns.Add("ItemCode");
            dtFinished_Goods.Columns.Add("ItemName");
            dtFinished_Goods.Columns.Add("UoM_ID");
            dtFinished_Goods.Columns.Add("UoM");
            dtFinished_Goods.Columns.Add("SOQty");
            dtFinished_Goods.Columns.Add("WIP_Qty");
            dtFinished_Goods.Columns.Add("FGTN_Qty");
            dtFinished_Goods.Columns.Add("ProdFloorQty");
            #endregion

            #region Initialize Main Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("Closure#");
            dgr_Main.dt.Columns.Add("BoM#");
            dgr_Main.dt.Columns.Add("Batch#");
            dgr_Main.dt.Columns.Add("JobDate");
            dgr_Main.dt.Columns.Add("ClosureDate");
            dgr_Main.dt.Columns.Add("ITEM");
            #endregion

            #region Initialize Action Butons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Closure #", "Closure#", 80);
            dgr_Main.Add_DatagridColoumn("BoM #", "BoM#", 80);
            dgr_Main.Add_DatagridColoumn("Job #", "Batch#", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JobDate", 80);
            dgr_Main.Add_DatagridColoumn("Closure Date", "ClosureDate", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Sales Name", "ITEM", 200);
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
            if (CheckValidity())
            {
                string sClosure_Id = "";
                try
                {
                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                    frmTwoStepVerify.ShowDialog();
                    if (frmTwoStepVerify.bVerified)
                    {
                        #region Update

                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prod_pharmaTxBatch_Closure oOldProdJobClosure = tbl_prod_pharmaTxBatch_Closure.Select(txtBatchClosure_ID.Tag.ToString());
                                if (oOldProdJobClosure != null)
                                {
                                    decimal dBatchQty_All = 0;
                                    decimal dTotalCost_ForBatch = 0;
                                    decimal dunit_Cost_Actual = clsHelpMethods_Prod.Get_FG_UnitCost(txtBatch_ID.Tag.ToString(), ref dBatchQty_All, ref dTotalCost_ForBatch);

                                    tbl_prod_pharmaTxBatch_Closure oProdJobClosure = new tbl_prod_pharmaTxBatch_Closure(
                                        txtBatchClosure_ID.Text, txtProdJobID.Tag.ToString(),
                                        txtBatch_ID.Tag.ToString(), cmbProdBatchStatus.GetSelectedIndex(),
                                        dtpBatchClose_Date.GetDateTime(), txtRemarks.Text,
                                        oOldProdJobClosure.IsChecked, oOldProdJobClosure.IsApproved,
                                        oOldProdJobClosure.IsCanceled, oOldProdJobClosure.CreateUser_ID,
                                        clsSecurity.UserIDLoged, oOldProdJobClosure.CheckedUser_ID,
                                        oOldProdJobClosure.ApprovedUser_ID, oOldProdJobClosure.CanceldUser_ID,
                                        oOldProdJobClosure.DateCreate, clsSecurity.getServerDateTime(),
                                        oOldProdJobClosure.DateChecked, oOldProdJobClosure.DateApproved,
                                        oOldProdJobClosure.DateCanceled,
                                        oOldProdJobClosure.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                        oOldProdJobClosure.CheckedUserTerminal_ID,
                                        oOldProdJobClosure.ApprovedUserTerminal_ID,
                                        oOldProdJobClosure.CanceledUserTerminal_ID, oOldProdJobClosure.CompanyID,
                                        oOldProdJobClosure.CompanyBranchID, txtFGSalesName.Tag.ToString(), dunit_Cost_Actual, dBatchQty_All, clsGenaralName.getName_ItemUOMID(txtFGSalesName.Tag.ToString()), dTotalCost_ForBatch);
                                    oProdJobClosure.Update();

                                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtBatch_ID.Tag.ToString());
                                    if (oBatch != null)
                                    {
                                        oBatch.BatchStatus = cmbProdBatchStatus.GetSelectedIndex();
                                        oBatch.Update();
                                    }

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    sClosure_Id = oOldProdJobClosure.Closure_ID;
                                }

                            }
                        }

                        #endregion

                        #region Insert

                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                decimal dBatchQty_All = 0;
                                decimal dTotalCost_ForBatch = 0;
                                decimal dunit_Cost_Actual = clsHelpMethods_Prod.Get_FG_UnitCost(txtBatch_ID.Tag.ToString(), ref dBatchQty_All, ref dTotalCost_ForBatch);

                                tbl_prod_pharmaTxBatch_Closure oProdJobClosure = new tbl_prod_pharmaTxBatch_Closure(
                                    txtBatchClosure_ID.Text, txtProdJobID.Tag.ToString(),
                                    txtBatch_ID.Tag.ToString(), cmbProdBatchStatus.GetSelectedIndex(),
                                    dtpBatchClose_Date.GetDateTime(), txtRemarks.Text,
                                    false, false, false, clsSecurity.UserIDLoged, "default", "default",
                                    "default", "default", clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID, txtFGSalesName.Tag.ToString(), dunit_Cost_Actual, dBatchQty_All, clsGenaralName.getName_ItemUOMID(txtFGSalesName.Tag.ToString()), dTotalCost_ForBatch);
                                oProdJobClosure.Insert();


                                tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtBatch_ID.Tag.ToString());
                                if (oBatch != null)
                                {
                                    oBatch.BatchStatus = cmbProdBatchStatus.GetSelectedIndex();
                                    oBatch.Update();
                                }

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                sClosure_Id = oProdJobClosure.Closure_ID;
                            }
                        }

                        #endregion
                    }
                    frmTwoStepVerify.Close();
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                    fillDetails_FromClosure(sClosure_Id);
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

                    }
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (SEACC_Form.CheckPermission_ToCancel())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtBatchClosure_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch_ID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtBatchClosure_ID.Tag = null;
            txtProdJobID.Tag = null;
            txtFGDescription.Tag = null;
            txtFGSalesName.Tag = null;
            txtCustomer.Tag = null;
            txtBatch_ID.Tag = null;

            txtCustomer.Uid = "";

            txtFGSalesName.ToolTip = null;
            txtCustomer.ToolTip = null;

            txtBatchClosure_ID.Text = "";
            txtProdJobID.Text = "";
            txtFGDescription.Text = "";
            txtFGSalesName.Text = "";
            txtCustomer.Text = "";
            txtBatch_ID.Text = "";
            txtRemarks.Text = "";

            dtpBatchClose_Date.SetTime(DateTime.Now);

            cmbProdBatchStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_Batch_Status));
            cmbProdBatchStatus.SetSelectedIndex(-1);

            dtBoM_Meterials.Clear();
            dgr_RawMererials.ItemsSource = dtBoM_Meterials.DefaultView;

            dtFinished_Goods.Clear();
            dgr_FinishGoods.ItemsSource = dtFinished_Goods.DefaultView;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtBatchClosure_ID.setReadOnlyStatus(true);
                txtBatchClosure_ID.Text = "<Auto Generate>";
            }
            else
                txtBatchClosure_ID.setReadOnlyStatus(false);
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
                foreach (tbl_prod_pharmaTxBatch_Closure oJobClosure in tbl_prod_pharmaTxBatch_Closure.SelectAll().Where(p => p.Closure_ID != "default" && !p.IsCanceled).OrderByDescending(o => o.Closure_DateTime))
                {
                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(oJobClosure.ProdBatch_ID);
                    dgr_Main.dt.Rows.Add(++iCount, oJobClosure.Closure_ID, oJobClosure.ProdJob_ID, oBatch.ProdBatch_ID, oBatch.BatchDate.ToString(clsValidation.Format_Date), oJobClosure.Closure_DateTime.ToString(clsValidation.Format_Date), clsGenaralName.getName_Item(oBatch.Item_ID));
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
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (clsValidate.CheckValidity_TransactionCodeLength(txtBatchClosure_ID.Text))
                    {
                        if (CheckValidity_BatchClose())
                        {
                            bStatus = true;
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtBatchClosure_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBatch_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFGSalesName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtBatchClosure_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtBatchClosure_ID.Text = txtBatchClosure_ID.Tag.ToString();
                }

                tbl_prod_pharmaTxBatch_Closure oClosure = tbl_prod_pharmaTxBatch_Closure.Select(txtBatchClosure_ID.Text);
                if (oClosure != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckValidity_BatchClose()
        {
            bool bReturn = false;
            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtBatch_ID.Tag.ToString());
            if (oBatch != null)
            {
                if (oBatch.BatchStatus == (int)prod_Batch_Status.Close)
                {
                    SEACCMessageBox.Show("Already Closed", "This is already closed", MessageBoxButton.OK, "Red");
                }

                else if (oBatch.BatchStatus == (int)prod_Batch_Status.Cancel || oBatch.IsCanceled)
                {
                    SEACCMessageBox.Show("Already Cancelled", "This is already cancelled", MessageBoxButton.OK, "Red");
                }

                else if (oBatch.BatchStatus == (int)prod_Batch_Status.Suspend && cmbProdBatchStatus.GetSelectedIndex() == (int)prod_Batch_Status.Open)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to Open this Job?", MessageBoxButton.YesNo, "#FF5B6B76");
                    if (bMessegeBoxResult)
                    {
                        oBatch.BatchStatus = (int)prod_Batch_Status.Open;
                        oBatch.DateModified = clsSecurity.getServerDateTime();
                        oBatch.ModifiedUser_ID = clsSecurity.UserIDLoged;
                        oBatch.ModifiedUserTerminal_ID = clsSecurity.TerminalID;
                        oBatch.Update();
                        bReturn = true;
                    }

                }

                else if (cmbProdBatchStatus.GetSelectedIndex() == (int)prod_Batch_Status.Close || cmbProdBatchStatus.GetSelectedIndex() == (int)prod_Batch_Status.Suspend || cmbProdBatchStatus.GetSelectedIndex() == (int)prod_Batch_Status.Cancel)
                {
                    if (oBatch.BatchStatus == (int)prod_Batch_Status.Suspend && cmbProdBatchStatus.GetSelectedIndex() == (int)prod_Batch_Status.Suspend)
                    {
                        SEACCMessageBox.Show("Already Suspended", "This is already suspended", MessageBoxButton.OK, "Red");
                    }

                    else if (!oBatch.IsCanceled && oBatch.BatchStatus != ((int)prod_Batch_Status.Close) && cmbProdBatchStatus.GetSelectedIndex() == ((int)prod_Batch_Status.Close))
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to close?", MessageBoxButton.YesNo, "#FF5B6B76");
                        if (bMessegeBoxResult)
                        {
                            oBatch.BatchStatus = (int)prod_Batch_Status.Close;
                            oBatch.DateModified = clsSecurity.getServerDateTime();
                            oBatch.ModifiedUser_ID = clsSecurity.UserIDLoged;
                            oBatch.ModifiedUserTerminal_ID = clsSecurity.TerminalID;
                            oBatch.Update();
                            bReturn = true;
                        }
                    }

                    else if ((!oBatch.IsCanceled && oBatch.BatchStatus != ((int)prod_Batch_Status.Suspend)) && cmbProdBatchStatus.GetSelectedIndex() == ((int)prod_Batch_Status.Suspend))
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to suspend?", MessageBoxButton.YesNo, "#FF5B6B76");
                        if (bMessegeBoxResult)
                        {
                            oBatch.BatchStatus = (int)prod_Batch_Status.Suspend;
                            oBatch.DateModified = clsSecurity.getServerDateTime();
                            oBatch.ModifiedUser_ID = clsSecurity.UserIDLoged;
                            oBatch.ModifiedUserTerminal_ID = clsSecurity.TerminalID;
                            oBatch.Update();
                            bReturn = true;
                        }
                    }

                    else if ((!oBatch.IsCanceled && oBatch.BatchStatus != ((int)prod_Batch_Status.Cancel)) && cmbProdBatchStatus.GetSelectedIndex() == ((int)prod_Batch_Status.Cancel))
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to cancel?", MessageBoxButton.YesNo, "#FF5B6B76");
                        if (bMessegeBoxResult)
                        {
                            oBatch.BatchStatus = (int)prod_Batch_Status.Cancel;
                            oBatch.DateModified = clsSecurity.getServerDateTime();
                            oBatch.ModifiedUser_ID = clsSecurity.UserIDLoged;
                            oBatch.ModifiedUserTerminal_ID = clsSecurity.TerminalID;

                            oBatch.IsCanceled = true;
                            oBatch.DateCanceled = clsSecurity.getServerDateTime();
                            oBatch.CanceldUser_ID = clsSecurity.UserIDLoged;
                            oBatch.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                            oBatch.Update();
                            bReturn = true;
                        }
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Can not change the status...", " You need to change BoM status to Close or Suspend or Cancel", MessageBoxButton.OK, "Red");
                }

            }
            return bReturn;
        }

        #endregion

        #region Fill Details
        private void fillDetails_FromClosure(string sClouserId)
        {
            try
            {
                tbl_prod_pharmaTxBatch_Closure oBatch_Closure = tbl_prod_pharmaTxBatch_Closure.Select(sClouserId);
                if (oBatch_Closure != null)
                {
                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(oBatch_Closure.ProdBatch_ID);
                    SEACC_Form.IsUpdateMode = true;

                    txtBatchClosure_ID.Tag = oBatch_Closure.Closure_ID;
                    txtProdJobID.Tag = oBatch_Closure.ProdJob_ID;
                    txtFGDescription.Tag = oBatch.Item_ID;
                    txtFGSalesName.Tag = oBatch.Item_ID;
                    txtCustomer.Tag = clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID);
                    txtBatch_ID.Tag = oBatch.ProdBatch_ID;

                    txtFGSalesName.ToolTip = oBatch.Item_ID;
                    txtCustomer.ToolTip = txtCustomer.Tag.ToString();

                    txtBatchClosure_ID.Text = oBatch_Closure.Closure_ID;
                    txtProdJobID.Text = oBatch_Closure.ProdJob_ID;
                    txtFGDescription.Text = clsGenaralName.getDescription_Item(oBatch.Item_ID);
                    txtFGSalesName.Text = clsGenaralName.getName_Item(oBatch.Item_ID);
                    txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                    txtBatch_ID.Text = oBatch.ProdBatch_ID;
                    txtRemarks.Text = oBatch_Closure.Remarks;

                    dtpBatchClose_Date.SetTime(oBatch_Closure.Closure_DateTime);
                    cmbProdBatchStatus.SetSelectedIndex(oBatch_Closure.BatchStatus);

                    fill_FinishedGoodGrid(oBatch);
                    fill_MeterialGrid(oBatch);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fill_MeterialGrid(tbl_prod_pharmaTxBatch oProdJobBatch)
        {
            dtBoM_Meterials.Rows.Clear();


            decimal dCustomerOrder_Qty = oProdJobBatch.CustomerOrder_Qty;
            foreach (tbl_prod_pharmaTxBatch_Material oBatch_Meterial in tbl_prod_pharmaTxBatch_Material.SelectAllByProdJob_ID(oProdJobBatch.ProdJob_ID).Where(r => r.IsSelected && !r.IsSemiFinishItem))
            {
                decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oBatch_Meterial.Item_ID, oBatch_Meterial.Section_ID);
                decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oBatch_Meterial.Item_ID);
                decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyReturnedQty_formPGRNs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oBatch_Meterial.Item_ID);
                decimal dUsedQty = dpGIN_MeterialQty - dpGRN_MeterialQty;
                decimal dWIPQty = clsHelpMethods_Prod.AlreadyConsumedQty_formWIPs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oBatch_Meterial.Item_ID);
                decimal dDifferenceQty = oBatch_Meterial.Line_No_Sub1 > 0 ? 0 : dUsedQty - dWIPQty;
                dtBoM_Meterials.Rows.Add("0",
                    oBatch_Meterial.Item_ID, clsGenaralName.getName_Item(oBatch_Meterial.Item_ID),
                    oBatch_Meterial.Uom_ID, clsGenaralName.getName_Uom(oBatch_Meterial.Uom_ID),
                    cls_Formater.FormatDecimal((oBatch_Meterial.TotalInputQty * dCustomerOrder_Qty), clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dMR_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dpGIN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dpGRN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dUsedQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dWIPQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dDifferenceQty, clsConfig.sDecimalPlaces_Quantity));
            }
        }

        private void fill_FinishedGoodGrid(tbl_prod_pharmaTxBatch oProdJobBatch)
        {
            dtFinished_Goods.Rows.Clear();
            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(oProdJobBatch.ProdJob_ID);
            if (oBoM != null)
            {
                decimal dCustomerOrder_Qty = oProdJobBatch.CustomerOrder_Qty;
                decimal dFGTN_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formFGTNs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID);
                decimal dWIP_Qty = clsHelpMethods_Prod.AlreadyMadeFG_formWIPs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID);

                dtFinished_Goods.Rows.Add("0",
                    oBoM.Item_ID_FG, clsGenaralName.getName_Item(oBoM.Item_ID_FG),
                    oBoM.Uom_ID, clsGenaralName.getName_Uom(oBoM.Uom_ID),
                    cls_Formater.FormatDecimal(oBoM.FGoodQty * dCustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dWIP_Qty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dFGTN_Qty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal((dWIP_Qty - dFGTN_Qty), clsConfig.sDecimalPlaces_Quantity)
                    );
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
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails_FromClosure(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        private void dgr_RawMererials_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM_Meterials);
        }

        private void dgr_FinishGoods_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtFinished_Goods);
        }


        #endregion

        #region Search Events
        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtProdJobID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
                txtCustomer.Text = lstResult[7];

                txtFGSalesName.ToolTip = lstResult[2];
            }
        }

        private void TxtFGDescription_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtProdJobID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
                txtCustomer.Text = lstResult[7];

                txtFGSalesName.ToolTip = lstResult[2];
            }
        }

        private void TxtFGSalesName_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtProdJobID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
                txtCustomer.Text = lstResult[7];

                txtFGSalesName.ToolTip = lstResult[2];
            }
        }

        private void TxtBatch_ID_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobID.Tag != null)
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtProdJobID.Tag.ToString());

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_Batch);
                if (RowDataSearch.DialogResult == true)
                {
                    txtBatch_ID.Tag = lstResult[0];
                    txtBatch_ID.Text = lstResult[0];

                    tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(lstResult[0]);
                    if (oBatch == null) return;
                    txtCustomer.Tag = clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID);
                    txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                    cmbProdBatchStatus.SetSelectedIndex(oBatch.BatchStatus);

                    fill_FinishedGoodGrid(oBatch);
                    fill_MeterialGrid(oBatch);
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }
        #endregion

        #region Key Press Event
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
    }
}
