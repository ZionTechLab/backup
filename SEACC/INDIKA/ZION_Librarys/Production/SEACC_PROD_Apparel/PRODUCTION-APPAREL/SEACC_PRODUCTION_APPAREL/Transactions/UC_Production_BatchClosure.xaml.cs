using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL
{
    /// <summary>
    /// Interaction logic for UC_ProductionJobClosure.xaml
    /// </summary>
    public partial class UC_Production_BatchClosure : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        //DataTable dtBoM_Meterials = new DataTable();
        //DataTable dtFinished_Goods = new DataTable();
        #endregion

        #region Form Load
        public UC_Production_BatchClosure()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_BOMClosure;
            SEACC_Form.Initialize();

            #region Meterial Table
            //dtBoM_Meterials.Columns.Add("LineNo");
            //dtBoM_Meterials.Columns.Add("ItemCode");
            //dtBoM_Meterials.Columns.Add("ItemName");
            //dtBoM_Meterials.Columns.Add("UoM_ID");
            //dtBoM_Meterials.Columns.Add("UoM");
            //dtBoM_Meterials.Columns.Add("BoMQty");
            //dtBoM_Meterials.Columns.Add("MRQty");
            //dtBoM_Meterials.Columns.Add("pGINQty");
            //dtBoM_Meterials.Columns.Add("pGRNQty");
            //dtBoM_Meterials.Columns.Add("UsedQty");//Net Qty
            //dtBoM_Meterials.Columns.Add("WIPQty");
            //dtBoM_Meterials.Columns.Add("DifQty");//Difference
            #endregion

            #region Batch Table Initialize
            dtBoM.Columns.Add("LineNo", typeof(int));
            dtBoM.Columns.Add("IsClose", typeof(bool));
            dtBoM.Columns.Add("IsSuspend", typeof(bool));
            dtBoM.Columns.Add("IsCanceled", typeof(bool));
            dtBoM.Columns.Add("BoM_No");
            dtBoM.Columns.Add("Batch_No");
            dtBoM.Columns.Add("FG_ItemID");
            dtBoM.Columns.Add("FG_Item");
            dtBoM.Columns.Add("FG_UoM");
            dtBoM.Columns.Add("FG_Qty", typeof(decimal));
            dtBoM.Columns.Add("Customer");
            dtBoM.Columns.Add("COQty", typeof(decimal));
            dtBoM.Columns.Add("CO_ID");
            #endregion

            #region Finished Good Table
            //dtFinished_Goods.Columns.Add("LineNo");
            //dtFinished_Goods.Columns.Add("ItemCode");
            //dtFinished_Goods.Columns.Add("ItemName");
            //dtFinished_Goods.Columns.Add("UoM_ID");
            //dtFinished_Goods.Columns.Add("UoM");
            //dtFinished_Goods.Columns.Add("SOQty");
            //dtFinished_Goods.Columns.Add("WIP_Qty");
            //dtFinished_Goods.Columns.Add("FGTN_Qty");
            //dtFinished_Goods.Columns.Add("ProdFloorQty");
            #endregion

            #region Initialize Main Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("Closure#");
            dgr_Main.dt.Columns.Add("ClosureDate");
            dgr_Main.dt.Columns.Add("CreateBy");
            dgr_Main.dt.Columns.Add("CreateDate");
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
            dgr_Main.Add_DatagridColoumn("Closure Date", "ClosureDate", 100);
            dgr_Main.Add_DatagridColoumn("Create By", "CreateBy", 80);
            dgr_Main.Add_DatagridColoumn("Create Date", "CreateDate", 100);
            #endregion

            #region Initialize Batch DataGrid
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ClearFields();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                Cursor = Cursors.Wait;
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

                                tbl_prodTxBatch_Closure oOldProdJobClosure =
                                    tbl_prodTxBatch_Closure.Select(txtBatchClosure_ID.Tag.ToString());
                                if (oOldProdJobClosure != null)
                                {
                                    foreach (tbl_prodTxBatch_Closure_Detail oDetail in tbl_prodTxBatch_Closure_Detail.SelectAllByClosure_ID(oOldProdJobClosure.Closure_ID))
                                    {
                                        tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(oDetail.ProdBatch_ID);
                                        if (oBatch != null)
                                        {
                                            oBatch.BatchStatus = (int)prod_Batch_Status.Open;
                                            if (oDetail.BatchStatus == (int)prod_Batch_Status.Cancel)
                                            {
                                                oBatch.IsCanceled = false;
                                                oBatch.DateCanceled = clsValidation.defaultDateTime;
                                                oBatch.CanceldUser_ID = "default";
                                                oBatch.CanceledUserTerminal_ID = "default";
                                            }
                                            oBatch.Update();
                                        }
                                        oDetail.Delete();
                                    }

                                    tbl_prodTxBatch_Closure oProdJobClosure = new tbl_prodTxBatch_Closure(
                                        txtBatchClosure_ID.Text,
                                        dtpBatchClose_Date.GetDateTime(),
                                        txtRemarks.Text,
                                        oOldProdJobClosure.IsChecked,
                                        oOldProdJobClosure.IsApproved,
                                        oOldProdJobClosure.IsCanceled,
                                        oOldProdJobClosure.CreateUser_ID,
                                        clsSecurity.UserIDLoged,
                                        oOldProdJobClosure.CheckedUser_ID,
                                        oOldProdJobClosure.ApprovedUser_ID,
                                        oOldProdJobClosure.CanceldUser_ID,
                                        oOldProdJobClosure.DateCreate,
                                        clsSecurity.getServerDateTime(),
                                        oOldProdJobClosure.DateChecked,
                                        oOldProdJobClosure.DateApproved,
                                        oOldProdJobClosure.DateCanceled,
                                        oOldProdJobClosure.CreateUserTerminal_ID,
                                        clsSecurity.TerminalID,
                                        oOldProdJobClosure.CheckedUserTerminal_ID,
                                        oOldProdJobClosure.ApprovedUserTerminal_ID,
                                        oOldProdJobClosure.CanceledUserTerminal_ID, oOldProdJobClosure.CompanyID,
                                        oOldProdJobClosure.CompanyBranchID);
                                    oProdJobClosure.Update();

                                    foreach (var vDr in dtBoM.Select("IsSuspend = true OR IsCanceled = true OR IsClose = true"))
                                    {
                                        int iLineNo = int.Parse(vDr["LineNo"].ToString());
                                        string sBatch_No = vDr["Batch_No"].ToString();//clsValidate.ValidateDataTableValue(vDr, "Batch_No", "default");
                                        bool bIsClose = bool.Parse(vDr["IsClose"].ToString());
                                        bool bIsSuspend = bool.Parse(vDr["IsSuspend"].ToString());
                                        bool bIsCanceled = bool.Parse(vDr["IsCanceled"].ToString());

                                        decimal dBatchQty_All = 0;
                                        decimal dTotalCost_ForBatch = 0;
                                        decimal dunit_Cost_Actual = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_No, ref dTotalCost_ForBatch, ref dBatchQty_All);

                                        tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sBatch_No);
                                        if (oBatch != null)
                                        {
                                            if (bIsClose)
                                                oBatch.BatchStatus = (int)prod_Batch_Status.Close;
                                            if (bIsSuspend)
                                                oBatch.BatchStatus = (int)prod_Batch_Status.Suspend;
                                            if (bIsCanceled)
                                            {
                                                oBatch.BatchStatus = (int)prod_Batch_Status.Cancel;
                                                oBatch.IsCanceled = true;
                                                oBatch.DateCanceled = clsSecurity.getServerDateTime();
                                                oBatch.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oBatch.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                            }
                                            oBatch.Update();

                                            tbl_prodTxBatch_Closure_Detail oClosureDetail = new tbl_prodTxBatch_Closure_Detail(iLineNo, oProdJobClosure.Closure_ID, oBatch.ProdJob_ID, oBatch.ProdBatch_ID, oBatch.Item_ID, oBatch.Uom_ID, oBatch.BatchStatus, dunit_Cost_Actual, dBatchQty_All, dTotalCost_ForBatch);
                                            oClosureDetail.Insert();
                                        }
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
                                tbl_prodTxBatch_Closure oBatchClosure = new tbl_prodTxBatch_Closure(
                                    txtBatchClosure_ID.Text,
                                    dtpBatchClose_Date.GetDateTime(),
                                    txtRemarks.Text,
                                    false, false, false,
                                    clsSecurity.UserIDLoged,
                                    "default",
                                    "default",
                                    "default",
                                    "default",
                                    clsSecurity.getServerDateTime(),
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID,
                                    "default",
                                    "default",
                                    "default",
                                    "default",
                                    clsSecurity.CompanyID,
                                    clsSecurity.BranchID);
                                oBatchClosure.Insert();


                                foreach (var vDr in dtBoM.Select("IsSuspend = true OR IsCanceled = true OR IsClose = true"))
                                {
                                    int iLineNo = int.Parse(vDr["LineNo"].ToString());
                                    string sBatch_No = vDr["Batch_No"].ToString();// clsValidate.ValidateDataTableValue(vDr, "Batch_No", "default");
                                    bool bIsClose = bool.Parse(vDr["IsClose"].ToString());
                                    bool bIsSuspend = bool.Parse(vDr["IsSuspend"].ToString());
                                    bool bIsCanceled = bool.Parse(vDr["IsCanceled"].ToString());

                                    decimal dBatchQty_All = 0;
                                    decimal dTotalCost_ForBatch = 0;
                                    decimal dunit_Cost_Actual = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_No, ref dTotalCost_ForBatch, ref dBatchQty_All);


                                    tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sBatch_No);
                                    if (oBatch != null)
                                    {
                                        if (bIsClose)
                                            oBatch.BatchStatus = (int)prod_Batch_Status.Close;
                                        if (bIsSuspend)
                                            oBatch.BatchStatus = (int)prod_Batch_Status.Suspend;
                                        if (bIsCanceled)
                                        {
                                            oBatch.BatchStatus = (int)prod_Batch_Status.Cancel;
                                            oBatch.IsCanceled = true;
                                            oBatch.DateCanceled = clsSecurity.getServerDateTime();
                                            oBatch.CanceldUser_ID = clsSecurity.UserIDLoged;
                                            oBatch.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                        }
                                        oBatch.Update();

                                        tbl_prodTxBatch_Closure_Detail oClosureDetail = new tbl_prodTxBatch_Closure_Detail(iLineNo, oBatchClosure.Closure_ID, oBatch.ProdJob_ID, oBatch.ProdBatch_ID, oBatch.Item_ID, oBatch.Uom_ID, oBatch.BatchStatus, dunit_Cost_Actual, dBatchQty_All, dTotalCost_ForBatch);
                                        oClosureDetail.Insert();
                                    }
                                }
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                sClosure_Id = oBatchClosure.Closure_ID;
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
                    Cursor = Cursors.Arrow;
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
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            cls_Formater.SetEnableDisable_LableTextbox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFGSalesName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtBatch_ID, true, false, false);

            txtBatchClosure_ID.Tag = null;
            txtProdJobID.Tag = null;
            txtFGSalesName.Tag = null;
            txtBatch_ID.Tag = null;

            txtFGSalesName.ToolTip = null;

            txtBatchClosure_ID.Text = "";
            txtProdJobID.Text = "";
            txtFGSalesName.Text = "";
            txtBatch_ID.Text = "";
            txtRemarks.Text = "";

            dtpBatchClose_Date.SetTime(DateTime.Now);

            //cmbProdBatchStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_Batch_Status));
            //cmbProdBatchStatus.SetSelectedIndex(-1);

            Refresh_BOM_Grid();

            //dtBoM_Meterials.Clear();
            //dgr_RawMererials.ItemsSource = dtBoM_Meterials.DefaultView;

            //dtFinished_Goods.Clear();
            //dgr_FinishGoods.ItemsSource = dtFinished_Goods.DefaultView;

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
                foreach (tbl_prodTxBatch_Closure oJobClosure in tbl_prodTxBatch_Closure.SelectAll().Where(p => p.Closure_ID != "default" && !p.IsCanceled).OrderByDescending(o => o.Closure_DateTime))
                {
                    dgr_Main.dt.Rows.Add(
                        ++iCount,
                        oJobClosure.Closure_ID,
                        oJobClosure.Closure_DateTime.ToString(clsValidation.Format_Date),
                        clsGenaralName.getName_User(oJobClosure.CreateUser_ID),
                        oJobClosure.DateCreate.ToString(clsValidation.Format_Date));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Refresh_BOM_Grid()
        {
            Cursor = Cursors.Wait;
            try
            {
                dtBoM.Clear();
                dtBoM.Merge(DBHandling.ExecQuery("Exec sp_Open_Batches").Tables[0]);
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
                        bStatus = true;
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

                tbl_prodTxBatch_Closure oClosure = tbl_prodTxBatch_Closure.Select(txtBatchClosure_ID.Text);
                if (oClosure != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails_FromClosure(string sClouserId)
        {
            Cursor = Cursors.Wait;
            try
            {
                tbl_prodTxBatch_Closure oBatch_Closure = tbl_prodTxBatch_Closure.Select(sClouserId);
                if (oBatch_Closure != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtBatchClosure_ID.Tag = oBatch_Closure.Closure_ID;

                    txtBatchClosure_ID.Text = oBatch_Closure.Closure_ID;
                    txtRemarks.Text = oBatch_Closure.Remarks;
                    dtpBatchClose_Date.SetTime(oBatch_Closure.Closure_DateTime);

                    dtBoM.Rows.Clear();
                    foreach (tbl_prodTxBatch_Closure_Detail oDetail in tbl_prodTxBatch_Closure_Detail.SelectAllByClosure_ID(oBatch_Closure.Closure_ID))
                    {
                        tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(oDetail.ProdBatch_ID);
                        if (oBatch != null)
                        {
                            dtBoM.Rows.Add(oDetail.Line_No,
                                oDetail.BatchStatus == (int)prod_Batch_Status.Close,
                                oDetail.BatchStatus == (int)prod_Batch_Status.Suspend,
                                oDetail.BatchStatus == (int)prod_Batch_Status.Cancel,
                                oDetail.ProdJob_ID,
                                oDetail.ProdBatch_ID,
                                oDetail.Item_ID_FG,
                                clsGenaralName.getName_Item(oDetail.Item_ID_FG),
                                clsGenaralName.getName_Uom(oDetail.Uom_ID_FG),
                                cls_Formater.FormatDecimal(oBatch.BatchQty, clsConfig.sDecimalPlaces_Quantity),
                                clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID)),
                                cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity),
                                oBatch.CustomerOrder_ID
                                );
                        }
                    }

                    //fill_FinishedGoodGrid(oBatch);
                    //fill_MeterialGrid(oBatch);
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

        //private void fill_MeterialGrid(tbl_prodTxBatch oProdJobBatch)
        //{
        //dtBoM_Meterials.Rows.Clear();


        //decimal dCustomerOrder_Qty = oProdJobBatch.CustomerOrder_Qty;
        //foreach (tbl_prodTxBatch_Material oJob_Meterial in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(oProdJobBatch.ProdBatch_ID).Where(r => r.IsSelected && !r.IsSemiFinishItem))
        //{
        //    decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oJob_Meterial.Item_ID);
        //    decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oJob_Meterial.Item_ID);
        //    decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyReturnedQty_formPGRNs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oJob_Meterial.Item_ID);
        //    decimal dUsedQty = dpGIN_MeterialQty - dpGRN_MeterialQty;
        //    decimal dWIPQty = clsHelpMethods_Prod.AlreadyConsumedQty_formWIPs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID, oJob_Meterial.Item_ID);
        //    decimal dDifferenceQty = oJob_Meterial.Line_No_Sub1 > 0 ? 0 : (dUsedQty - dWIPQty);
        //    dtBoM_Meterials.Rows.Add("0",
        //        oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID),
        //        oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
        //        cls_Formater.FormatDecimal((oJob_Meterial.TotalInputQty * dCustomerOrder_Qty), clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dMR_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dpGIN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dpGRN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dUsedQty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dWIPQty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dDifferenceQty, clsConfig.sDecimalPlaces_Quantity));
        //}
        //}

        //private void fill_FinishedGoodGrid(tbl_prodTxBatch oProdJobBatch)
        //{
        //dtFinished_Goods.Rows.Clear();
        //tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(oProdJobBatch.ProdJob_ID);
        //if (oBoM != null)
        //{
        //    decimal dCustomerOrder_Qty = oProdJobBatch.CustomerOrder_Qty;
        //    decimal dFGTN_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formFGTNs(oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID);
        //    decimal dWIP_Qty = clsHelpMethods_Prod.AlreadyMadeFG_formWIPs("", oProdJobBatch.ProdJob_ID, oProdJobBatch.ProdBatch_ID);

        //    dtFinished_Goods.Rows.Add("0",
        //        oBoM.Item_ID_FG, clsGenaralName.getName_Item(oBoM.Item_ID_FG),
        //        oBoM.Uom_ID, clsGenaralName.getName_Uom(oBoM.Uom_ID),
        //        cls_Formater.FormatDecimal(oBoM.FGoodQty * dCustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dWIP_Qty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal(dFGTN_Qty, clsConfig.sDecimalPlaces_Quantity),
        //        cls_Formater.FormatDecimal((dWIP_Qty - dFGTN_Qty), clsConfig.sDecimalPlaces_Quantity)
        //        );
        //}
        //}
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

        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        private void dgr_RawMererials_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM_Meterials);
        }

        private void dgr_FinishGoods_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            //clsHelpMethods_Prod.OrderBy_DataGrid(dtFinished_Goods);
        }


        #endregion

        #region Search Events
        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs_Locked);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                //txtFGSalesName.Tag = lstResult[2];

                txtProdJobID.Text = lstResult[0];
                //txtFGSalesName.Text = lstResult[3];

                //txtFGSalesName.ToolTip = lstResult[2];
            }
        }

        private void TxtFGSalesName_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionFinishedGoods);
            if (RowDataSearch.DialogResult == true)
            {
                //txtProdJobID.Tag = lstResult[0];
                //txtFGSalesName.Tag = lstResult[2];

                //txtProdJobID.Text = lstResult[0];
                //txtFGSalesName.Text = lstResult[3];

                //txtFGSalesName.ToolTip = lstResult[2];

                //txtProdJobID.Tag = lstResult[0];
                txtFGSalesName.Tag = lstResult[0];
                txtFGSalesName.Text = lstResult[2];
                txtFGSalesName.ToolTip = lstResult[0];
            }
        }

        private void TxtBatch_ID_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_Batch);
            if (RowDataSearch.DialogResult == true)
            {
                txtBatch_ID.Tag = lstResult[0];
                txtBatch_ID.Text = lstResult[0];

                tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(lstResult[0]);
                if (oBatch == null) return;
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

        #region Check Box Events
        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsClose"] = false; });
        }

        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsClose"] = true; });
        }

        private void chk_SuspendselectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsSuspend"] = true; });
        }

        private void chk_SuspendselectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsSuspend"] = false; });
        }

        private void chk_CancelselectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsCanceled"] = true; });
        }

        private void chk_CancelselectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select("BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%' AND FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%' AND Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'").ToList().ForEach(r => { r["IsCanceled"] = false; });
        }
        #endregion

        #region Textbox Text Change Event
        private void txtProdJobID_TextBox_TextChanged(object sender, EventArgs e)
        {
            BoM_Filter();
        }
        #endregion

        #region Help Methods
        private void BoM_Filter()
        {
            string sFinalQuary = "";
            Cursor = Cursors.Wait;

            if (txtProdJobID.TextBox1.Text != "" && txtProdJobID.TextBox1.Text.Length > 0)
                sFinalQuary = " BoM_No LIKE '%" + txtProdJobID.TextBox1.Text.Trim() + "%'";
            if (txtFGSalesName.TextBox1.Text != "" && txtFGSalesName.TextBox1.Text.Length > 0)
                sFinalQuary = " FG_Item LIKE '%" + clsHelpMethods.CheckValue(txtFGSalesName.TextBox1.Text.Trim()) + "%'";
            if (txtBatch_ID.TextBox1.Text != "" && txtBatch_ID.TextBox1.Text.Length > 0)
                sFinalQuary = " Batch_No LIKE '%" + txtBatch_ID.TextBox1.Text.Trim() + "%'";

            try
            {
                dtBoM.DefaultView.RowFilter = sFinalQuary;
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


    }
}
