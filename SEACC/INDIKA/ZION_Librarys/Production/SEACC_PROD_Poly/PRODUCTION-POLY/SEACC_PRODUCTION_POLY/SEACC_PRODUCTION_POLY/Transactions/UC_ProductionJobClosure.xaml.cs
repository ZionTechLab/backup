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

namespace SEACC_PRODUCTION_POLY
{
    /// <summary>
    /// Interaction logic for UC_ProductionJobClosure.xaml
    /// </summary>
    public partial class UC_ProductionJobClosure : UserControl
    {
        #region Class Variables
        DataTable dtBoM_Meterials = new DataTable();
        DataTable dtFinished_Goods = new DataTable();
        #endregion

        public UC_ProductionJobClosure()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_BOMClosure;
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
            dgr_Main.dt.Columns.Add("JC#");
            dgr_Main.dt.Columns.Add("JOB#");
            dgr_Main.dt.Columns.Add("CLOSURE_DATE");
            dgr_Main.dt.Columns.Add("ITEM");
            dgr_Main.dt.Columns.Add("ORDERED_QTY");
            dgr_Main.dt.Columns.Add("STORES_QTY");
            #endregion

            #region Initialize Action Butons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;

            SEACC_Form.btn_Save.Content = "Close";
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Job Closure#", "JC#", 80);
            dgr_Main.Add_DatagridColoumn("BoM/Job#", "JOB#", 80);
            dgr_Main.Add_DatagridColoumn("Closure Date", "CLOSURE_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "ITEM", 200);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Ordered Qty", "ORDERED_QTY", 90, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Stores Qty", "STORES_QTY", 90, true, true);
            #endregion

            ClearFields();
            RefreshGrid();
        }

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
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            if (Validation_JobClose())
                            {
                                tbl_prod_polyTxJobCard_Closure oOldProdJobClosure = tbl_prod_polyTxJobCard_Closure.Select(txtJobClosure_ID.Tag.ToString());
                                if (oOldProdJobClosure != null)
                                {
                                    if (!oOldProdJobClosure.IsApproved && !oOldProdJobClosure.IsCanceled)
                                    {
                                        tbl_prod_polyTxJobCard_Closure oProdJobClosure = new tbl_prod_polyTxJobCard_Closure(txtJobClosure_ID.Text, txtProdJobID.Tag.ToString(), dtpJobClose_Date.GetDateTime(),
                                            oOldProdJobClosure.IsChecked, oOldProdJobClosure.IsApproved, oOldProdJobClosure.IsCanceled, oOldProdJobClosure.CreateUser_ID, clsSecurity.UserIDLoged, oOldProdJobClosure.CheckedUser_ID,
                                            oOldProdJobClosure.ApprovedUser_ID, oOldProdJobClosure.CanceldUser_ID, oOldProdJobClosure.DateCreate, clsSecurity.getServerDateTime(), oOldProdJobClosure.DateChecked, oOldProdJobClosure.DateApproved, oOldProdJobClosure.DateCanceled,
                                            oOldProdJobClosure.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldProdJobClosure.CheckedUserTerminal_ID, oOldProdJobClosure.ApprovedUserTerminal_ID, oOldProdJobClosure.CanceledUserTerminal_ID, oOldProdJobClosure.CompanyID, oOldProdJobClosure.CompanyBranchID);
                                        oProdJobClosure.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldProdJobClosure.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected BoM/Job Closure has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldProdJobClosure.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected BoM/Job has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            if (Validation_JobClose())
                            {
                                tbl_prod_polyTxJobCard_Closure oProdJobClosure = new tbl_prod_polyTxJobCard_Closure(txtJobClosure_ID.Text, txtProdJobID.Tag.ToString(), dtpJobClose_Date.GetDateTime(),
                                        false, false, false, clsSecurity.UserIDLoged, "default", "default",
                                         "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                         clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                                oProdJobClosure.Insert();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
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
                        //tbl_prodTxWorkInProgress oWIP = tbl_prodTxWorkInProgress.Select(txtWIP_ID.Tag.ToString());
                        //if (oWIP != null)
                        //{
                        //    if (!oWIP.IsApproved)
                        //    {
                        //        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                        //        if (bMessegeBoxResult)
                        //        {
                        //            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                        //            frmTwoStepVerify.ShowDialog();
                        //            if (frmTwoStepVerify.bVerified)
                        //            {
                        //                oWIP.IsApproved = true;
                        //                oWIP.DateApproved = clsSecurity.getServerDateTime();
                        //                oWIP.ApprovedUser_ID = clsSecurity.UserIDLoged;
                        //                oWIP.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                        //                oWIP.Update();
                        //                SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                        //            }
                        //            frmTwoStepVerify.Close();
                        //        }
                        //    }
                        //    else
                        //    {
                        //        SEACCMessageBox.Show("Alreay Approved", "Selected pGIN has already been approved", MessageBoxButton.OK, "Red");
                        //    }
                        //}
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
                        //if (txtJobTypeID.Tag != null)
                        //{
                        //    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        //    if (bMessegeBoxResult)
                        //    {
                        //        tbl_zJobProductionJobType oOldType = tbl_zJobProductionJobType.Select(txtJobTypeID.Tag.ToString());
                        //        if (oOldType != null)
                        //        {
                        //            oOldType.IsDeleted = true;
                        //            oOldType.Update();

                        //            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                        //            ClearFields();
                        //            RefreshGrid();
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #endregion

        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtJobClosure_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItem, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtJobClosure_ID.Tag = null;
            txtProdJobID.Tag = null;
            txtItem.Tag = null;
            txtCustomer.Tag = null;

            txtCustomer.Uid = "";
            txtCustomer.ToolTip = null;

            txtJobClosure_ID.Text = "";
            txtProdJobID.Text = "";
            txtItem.Text = "";
            txtCustomer.Text = "";
            txtRemarks.Text = "";

            dtpJobClose_Date.SetTime(DateTime.Now);

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_JobStatus));
            cmbProdJobStatus.SetSelectedIndex((int)prod_JobStatus.Closed);
            cmbProdJobStatus.IsEnabled = false;

            dtBoM_Meterials.Clear();
            dgr_RawMererials.ItemsSource = dtBoM_Meterials.DefaultView;

            dtFinished_Goods.Clear();
            dgr_FinishGoods.ItemsSource = dtFinished_Goods.DefaultView;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtJobClosure_ID.setReadOnlyStatus(true);
                txtJobClosure_ID.Text = "<Auto Generate>";
            }
            else
                txtJobClosure_ID.setReadOnlyStatus(false);
            #endregion
        }

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_polyTxJobCard_Closure oJob_Closure in tbl_prod_polyTxJobCard_Closure.SelectAll().Where(p => p.Closure_ID != "default" && !p.IsCanceled).OrderByDescending(o => o.Closure_DateTime))
                {
                    tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(oJob_Closure.ProdJob_ID);
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                    decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oJob.Item_ID_FG, oItem.ItemCategorySub_ID, "default", "0", "0");
                    dgr_Main.dt.Rows.Add(++iCount, oJob_Closure.Closure_ID, oJob_Closure.ProdJob_ID, oJob_Closure.Closure_DateTime.ToString(clsValidation.Format_Date), clsGenaralName.getDescription_Item(oJob.Item_ID_FG), cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity), cls_Formater.FormatDecimal(dStockQty, clsConfig.sDecimalPlaces_Quantity));
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
                    bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtJobClosure_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtItem))
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
                    txtJobClosure_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtJobClosure_ID.Text = txtJobClosure_ID.Tag.ToString();
                }

                //tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Text);
                //if (oJob != null)
                //{
                //    bStatus = false;
                //    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                //}
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails_fromBoMClosure(string sClouserID)
        {
            try
            {
                tbl_prod_polyTxJobCard_Closure oJob_Closure = tbl_prod_polyTxJobCard_Closure.Select(sClouserID);
                if (oJob_Closure != null)
                {
                    tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(oJob_Closure.ProdJob_ID);
                    SEACC_Form.IsUpdateMode = true;

                    txtJobClosure_ID.Tag = oJob_Closure.Closure_ID;
                    txtProdJobID.Tag = oJob_Closure.ProdJob_ID;
                    txtItem.Tag = oJob.Item_ID_FG;
                    txtCustomer.Tag = oJob.Customer_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID);
                    txtCustomer.ToolTip = txtCustomer.Uid;

                    txtJobClosure_ID.Text = oJob_Closure.Closure_ID;
                    txtProdJobID.Text = oJob_Closure.ProdJob_ID;
                    txtItem.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtRemarks.Text = oJob.Remarks;

                    dtpJobClose_Date.SetTime(oJob_Closure.Closure_DateTime);
                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    fill_FinishedGoodGrid(oJob_Closure.ProdJob_ID);
                    fill_MeterialGrid(oJob_Closure.ProdJob_ID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fillDetails_fromBOM(string sBoM_No)
        {
            try
            {
                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sBoM_No);
                if (oJob != null)
                {
                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtItem.Tag = oJob.Item_ID_FG;
                    txtCustomer.Tag = oJob.Customer_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID);
                    txtCustomer.ToolTip = txtCustomer.Uid;

                    txtProdJobID.Text = oJob.ProdJob_ID;
                    txtItem.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtRemarks.Text = oJob.Remarks;

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    fill_FinishedGoodGrid(oJob.ProdJob_ID);
                    fill_MeterialGrid(oJob.ProdJob_ID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fill_MeterialGrid(string sProdJobBoM)
        {
            dtBoM_Meterials.Rows.Clear();
            decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(sProdJobBoM);
            foreach (tbl_prod_polyTxJobCard_Material oJob_Meterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sProdJobBoM).Where(r => !r.IsSemiFinishItem))
            {
                decimal dMR_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formMRs(oJob_Meterial.ProdJob_ID, oJob_Meterial.Item_ID);
                decimal dpGIN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGINs(oJob_Meterial.ProdJob_ID, oJob_Meterial.Item_ID);
                decimal dpGRN_MeterialQty = clsHelpMethods_Prod.AlreadyIssuedQty_formPGRNs(oJob_Meterial.ProdJob_ID, oJob_Meterial.Item_ID);
                decimal dUsedQty = dpGIN_MeterialQty - dpGRN_MeterialQty;
                decimal dWIPQty = clsHelpMethods_Prod.AlreadyIssuedQty_formWIPs(oJob_Meterial.ProdJob_ID, oJob_Meterial.Item_ID);
                decimal dDifferenceQty = dUsedQty - dWIPQty;
                dtBoM_Meterials.Rows.Add("0",
                    oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID),
                    oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
                    cls_Formater.FormatDecimal((oJob_Meterial.TotalInputQty * dCustomerOrder_Qty), clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dMR_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dpGIN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dpGRN_MeterialQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dUsedQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dWIPQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dDifferenceQty , clsConfig.sDecimalPlaces_Quantity));
            }
        }

        private void fill_FinishedGoodGrid(string sProdJobBoM)
        {
            dtFinished_Goods.Rows.Clear();
            foreach (tbl_prod_polyTxJobCard oJob in tbl_prod_polyTxJobCard.SelectAllByProdJob_ID(sProdJobBoM).Where(r => !r.IsCanceled))
            {
                decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(sProdJobBoM);
                decimal dFGTN_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formFGTNs(sProdJobBoM);
                decimal dWIP_Qty = clsHelpMethods_Prod.AlreadyIssuedQty_formWIPs(oJob.ProdJob_ID, oJob.Item_ID_FG);

                dtFinished_Goods.Rows.Add("0",
                    oJob.Item_ID_FG, clsGenaralName.getDescription_Item(oJob.Item_ID_FG),
                    oJob.Uom_ID, clsGenaralName.getName_Uom(oJob.Uom_ID),
                    cls_Formater.FormatDecimal(oJob.FGoodQty * dCustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity),
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
                    fillDetails_fromBoMClosure(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Search Events
        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails_fromBOM(lstResult[0]);
            }
        }

        #endregion

        private void dgr_RawMererials_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM_Meterials);
        }

        private void dgr_FinishGoods_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtFinished_Goods);
        }

        private bool Validation_JobClose()
        {
            bool bReturn = false;
            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
            if (oJob != null)
            {
                if (!oJob.IsCanceled && oJob.ProdJobStatus != ((int)prod_JobStatus.Closed))
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation..", "Are you sure to close this BoM?", MessageBoxButton.YesNo, "Red");
                    if (bMessegeBoxResult)
                    {
                        oJob.ProdJobStatus = (int)prod_JobStatus.Closed;
                        oJob.DateModified = clsSecurity.getServerDateTime();
                        oJob.ModifiedUser_ID = clsSecurity.UserIDLoged;
                        oJob.ModifiedUserTerminal_ID = clsSecurity.TerminalID;
                        oJob.Update();
                        bReturn = true;
                    }
                }
                else
                {
                    if (oJob.IsCanceled)
                        SEACCMessageBox.Show("BoM can not be closed", "Selected BoM has been cancelled", MessageBoxButton.OK, "Red");
                    else if (oJob.ProdJobStatus == ((int)prod_JobStatus.Closed))
                        SEACCMessageBox.Show("BoM can not be closed", "Selected BoM has already been closed", MessageBoxButton.OK, "Red");
                    else
                        SEACCMessageBox.Show("BoM can not be closed", "", MessageBoxButton.OK, "Red");
                }
            }
            return bReturn;
        }

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }
}
