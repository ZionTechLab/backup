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
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_PHARMA.Transactions
{
    /// <summary>
    /// Developed by Gayan
    /// 2017-10-31
    /// </summary>
    public partial class UC_Production_BatchCreation : UserControl
    {
        #region Class Variables
        BrushConverter bc = new BrushConverter();
        DataTable dtMeterialReq = new DataTable();
        #endregion

        #region Form Load
        public UC_Production_BatchCreation()
        {
            #region Form Initializing
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_BatchCreation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("LineNo");
            dgr_Main.dt.Columns.Add("BatchID");
            dgr_Main.dt.Columns.Add("BoMID");
            dgr_Main.dt.Columns.Add("FGDescription");
            dgr_Main.dt.Columns.Add("UoM");
            dgr_Main.dt.Columns.Add("BatchQty");
            dgr_Main.dt.Columns.Add("Prepared_By");
            dgr_Main.dt.Columns.Add("Approved_By");
            dgr_Main.dt.Columns.Add("Is_Canceled");


            #region Material Grid
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("LineNoMain");
            dtMeterialReq.Columns.Add("LineNoSub1");
            dtMeterialReq.Columns.Add("LineNoSub2");
            //dtMeterialReq.Columns.Add("IsSelect");
            DataColumn dcSelectColumn = new DataColumn("IsSelect", typeof(string));
            dcSelectColumn.DefaultValue = "\uE003";
            dtMeterialReq.Columns.Add(dcSelectColumn);
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("ActivityID");
            dtMeterialReq.Columns.Add("ActivityName");
            dtMeterialReq.Columns.Add("IsSemiFinished", typeof(bool));
            dtMeterialReq.Columns.Add("SemiFinished_RawMeterials", typeof(frm_RawMeterialGroups_SemiFinished));
            dtMeterialReq.Columns.Add("SubstitueGroup");

            //Total Qty with respect to Batch Qty
            dtMeterialReq.Columns.Add("TotalQtyWithRespectBatchQty");
            #endregion

            #endregion

            #region Initialize Action Butons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Batch #", "BatchID", 75);
            dgr_Main.Add_DatagridColoumn("BoM #", "BoMID", 75);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "FGDescription", 200);
            dgr_Main.Add_DatagridColoumn("UoM", "UoM", 60);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Batch Qty", "BatchQty", 75, true, true);
            dgr_Main.Add_DatagridColoumn("Prepared By", "Prepared_By", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "Approved_By", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "Is_Canceled", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
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
                            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Text);
                            if (oBatch != null)
                            {
                                if (!oBatch.IsApproved)
                                {
                                    if (!oBatch.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oBatch.IsCanceled = true;
                                                oBatch.BatchStatus = (int)prod_Batch_Status.Cancel;
                                                oBatch.DateCanceled = clsSecurity.getServerDateTime();
                                                oBatch.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oBatch.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oBatch.Update();
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

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sBatch_No = "";
            if (CheckValidity())
            {
                try
                {
                    tbl_prod_pharmaTxJobCard oProdJobBoM = tbl_prod_pharmaTxJobCard.Select(txtBoMID.Tag.ToString());
                    if (oProdJobBoM != null)
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prod_pharmaTxBatch oOldBatch = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Text);
                                if (oOldBatch != null)
                                {
                                    if (!oOldBatch.IsApproved && !oOldBatch.IsCanceled)
                                    {
                                        tbl_prod_pharmaTxBatch_Material.DeleteAllByProdBatch_ID(txtProdBatchID.Text);

                                        tbl_prod_pharmaTxBatch oUpdateBatch = new tbl_prod_pharmaTxBatch(
                                            txtProdBatchID.Text,
                                            txtBoMID.Tag.ToString(),
                                            dtpbatchDate.GetDateTime(),
                                            (int)prod_Batch_Status.Open,
                                            txtCustomerCOSO.Tag?.ToString() ?? "default",
                                            clsValidation.Validate_DecimalNumber(txtSOQty.Text),
                                            clsValidation.Validate_DecimalNumber(txtBatchQty.Text),
                                            txtUoM.Tag?.ToString() ?? "default",
                                            txtFGDescription.Tag?.ToString() ?? "default",
                                            clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(txtBoMID.Tag.ToString()),
                                            txtInstructionProd.Text,
                                            txtInstructionStore.Text,
                                            oOldBatch.IsChecked, oOldBatch.IsApproved, oOldBatch.IsCanceled,
                                            oOldBatch.CreateUser_ID, clsSecurity.UserIDLoged, oOldBatch.CheckedUser_ID, oOldBatch.ApprovedUser_ID, oOldBatch.CanceldUser_ID,
                                            oOldBatch.DateCreate, clsSecurity.getServerDateTime(), oOldBatch.DateChecked, oOldBatch.DateApproved, oOldBatch.DateCanceled,
                                            oOldBatch.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldBatch.CheckedUserTerminal_ID, oOldBatch.ApprovedUserTerminal_ID, oOldBatch.CanceledUserTerminal_ID,
                                            oOldBatch.CompanyID, oOldBatch.CompanyBranchID
                                        );
                                        oUpdateBatch.Update();

                                        InsertBatchMaterials();

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldBatch.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected Batch has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldBatch.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected Batch has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                if (oOldBatch != null) sBatch_No = oOldBatch.ProdBatch_ID;
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                tbl_prod_pharmaTxBatch oBatch = new tbl_prod_pharmaTxBatch(
                                     txtProdBatchID.Text,
                                     txtBoMID.Tag.ToString(),
                                     dtpbatchDate.GetDateTime(),
                                     (int)prod_Batch_Status.Open,
                                     txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                     clsValidation.Validate_DecimalNumber(txtSOQty.Text),
                                     clsValidation.Validate_DecimalNumber(txtBatchQty.Text),
                                     txtUoM.Tag != null ? txtUoM.Tag.ToString() : "default",
                                     txtFGDescription.Tag != null ? txtFGDescription.Tag.ToString() : "default",
                                     clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(txtBoMID.Tag.ToString()),
                                     txtInstructionProd.Text,
                                     txtInstructionStore.Text,
                                     false, false, false,
                                     clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                     clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                     clsSecurity.TerminalID, "default", "default", "default", "default",
                                     clsSecurity.CompanyID, clsSecurity.BranchID
                                  );
                                oBatch.Insert();
                                sBatch_No = oBatch.ProdBatch_ID;

                                InsertBatchMaterials();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                        }
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                    FillDetails(sBatch_No);
                }
            }
        }

        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Text);
                            if (oBatch != null)
                            {
                                if (!oBatch.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oBatch.IsApproved = true;
                                            oBatch.DateApproved = clsSecurity.getServerDateTime();
                                            oBatch.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oBatch.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oBatch.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oBatch.ProdBatch_ID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected BoM has already been approved", MessageBoxButton.OK, "Red");
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

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProdBatchID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBoMID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtUoM, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCOSO, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSOQty, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPreviousBatchQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBatchQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtInstructionProd, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtInstructionStore, true, false, true);

            txtProdBatchID.Tag = null;
            txtBoMID.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFGDescription.Tag = null;
            txtFGSalesName.Tag = null;
            txtUoM.Tag = null;

            txtFGSalesName.ToolTip = null;

            txtProdBatchID.Text = "";
            txtBoMID.Text = "";
            txtCustomer.Text = "";
            txtCustomerCOSO.Text = "";
            txtFGDescription.Text = "";
            txtFGSalesName.Text = "";
            txtUoM.Text = "";
            txtSOQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtPreviousBatchQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtBatchQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtInstructionProd.Text = "";
            txtInstructionStore.Text = "";

            dtpBoMDate.SetTime(DateTime.Now);
            dtpbatchDate.SetTime(DateTime.Now);

            #region Material Grid Binding
            dtMeterialReq.Clear();
            CollectionViewSource mycollection = new CollectionViewSource();
            mycollection.Source = dtMeterialReq;
            mycollection.GroupDescriptions.Add(new PropertyGroupDescription("SubstitueGroup"));
            dgr_MererialReq.ItemsSource = mycollection.View;
            #endregion

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtProdBatchID.setReadOnlyStatus(true);
                txtProdBatchID.Text = "<Auto Generate>";
            }
            else
                txtProdBatchID.setReadOnlyStatus(false);
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
                foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAll().Where(p => p.ProdBatch_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oBatch.ProdBatch_ID, oBatch.ProdJob_ID, clsGenaralName.getName_Item(oBatch.Item_ID), clsGenaralName.getName_Uom(oBatch.Uom_ID), cls_Formater.FormatDecimal(oBatch.BatchQty, clsConfig.sDecimalPlaces_Quantity), clsGenaralName.getName_User(oBatch.CreateUser_ID), clsGenaralName.getName_User(oBatch.ApprovedUser_ID), oBatch.IsCanceled);
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
                if (CheckOptionsSelctionValidity_MainGrid())
                {
                    if (CheckOptionsSelctionValidity_SemiFinishedGrid())
                    {
                        if (CheckValidity_DuplicateFiled())
                        {
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtProdBatchID.Text))
                            {
                                bStatus = true;
                            }
                        }
                    }
                }
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtProdBatchID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBoMID))
                bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtFGDescription))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUoM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSOQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBatchQty))
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
                    txtProdBatchID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtProdBatchID.Text = txtProdBatchID.Tag.ToString();
                }

                tbl_prod_pharmaTxBatch oJob = tbl_prod_pharmaTxBatch.Select(txtProdBatchID.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckOptionsSelctionValidity_MainGrid()
        {
            bool bStatus = true;

            var vOptionGroups = (from r in dtMeterialReq.AsEnumerable() select r["SubstitueGroup"]).Distinct().ToList();
            foreach (var vOptionGroup in vOptionGroups)
            {
                var drSubstituteRows = dtMeterialReq.AsEnumerable().Where(row => row.Field<string>("SubstitueGroup") == vOptionGroup.ToString());
                DataTable dt = drSubstituteRows.CopyToDataTable();
                var vNotSelecteds = dt.Select("IsSelect = '\uE0A2' ");
                if (vNotSelecteds.Count() == 0)
                {
                    SEACCMessageBox.Show("Option Not Selected..!", "There is no any option for Item Name : " + vOptionGroup.ToString() + "\nPlease select a option...", MessageBoxButton.OK, "Red");
                    bStatus = false;

                    break;
                }
            }

            return bStatus;
        }

        private bool CheckOptionsSelctionValidity_SemiFinishedGrid()
        {
            bool bStatus = true;

            foreach (DataRow dr in dtMeterialReq.Rows)
            {
                frm_RawMeterialGroups_SemiFinished frm_Semi = dr.Field<frm_RawMeterialGroups_SemiFinished>("SemiFinished_RawMeterials");
                if (frm_Semi != null)
                {
                    var vOptionGroups = (from r in frm_Semi.dtMeterialReq.AsEnumerable() select r["SubstitueGroup"]).Distinct().ToList();
                    foreach (var vOptionGroup in vOptionGroups)
                    {
                        var drSubstituteRows = frm_Semi.dtMeterialReq.AsEnumerable().Where(row => row.Field<string>("SubstitueGroup") == vOptionGroup.ToString());
                        DataTable dt = drSubstituteRows.CopyToDataTable();
                        var vNotSelecteds = dt.Select("IsSelect = '\uE0A2' ");
                        if (vNotSelecteds.Count() == 0)
                        {
                            SEACCMessageBox.Show("Option Not Selected in Semi Finished Item..!", "There is no any option for Item Name : " + vOptionGroup.ToString() + "\nPlease select a option...", MessageBoxButton.OK, "Red");
                            bStatus = false;

                            break;
                        }
                    }
                }

                if (bStatus == false)
                    break;
            }

            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sBatchId)
        {
            try
            {
                Cursor = Cursors.Wait;

                tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(sBatchId);
                if (oBatch == null) return;

                tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(oBatch.ProdJob_ID);
                if (oBoM == null) return;

                SEACC_Form.IsUpdateMode = true;

                txtProdBatchID.Tag = oBatch.ProdBatch_ID;
                txtBoMID.Tag = oBatch.ProdJob_ID;
                txtCustomerCOSO.Tag = oBatch.CustomerOrder_ID;
                txtCustomer.Tag = clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID);
                txtFGDescription.Tag = oBatch.Item_ID;
                txtFGSalesName.Tag = oBatch.Item_ID;
                txtUoM.Tag = oBatch.Uom_ID;

                txtFGSalesName.ToolTip = oBatch.Item_ID; ;

                txtProdBatchID.Text = oBatch.ProdBatch_ID;
                txtBoMID.Text = oBatch.ProdJob_ID;
                txtCustomer.Text = clsGenaralName.getName_Customer(txtCustomer.Tag.ToString());
                txtCustomerCOSO.Text = oBatch.CustomerOrder_ID != "default" ? oBatch.CustomerOrder_ID : "-";
                txtFGDescription.Text = clsGenaralName.getDescription_Item(oBatch.Item_ID);
                txtFGSalesName.Text = clsGenaralName.getName_Item(oBatch.Item_ID);
                txtUoM.Text = clsGenaralName.getName_Uom(oBatch.Uom_ID);
                txtSOQty.Text = cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity);
                txtPreviousBatchQty.Text = cls_Formater.FormatDecimal((clsHelpMethods_Prod.GetTotalQtyofBatches_FromBoM(oBatch.ProdJob_ID, oBatch.DateCreate)), clsConfig.sDecimalPlaces_Quantity);
                txtBatchQty.Text = cls_Formater.FormatDecimal(oBatch.BatchQty, clsConfig.sDecimalPlaces_Quantity);
                txtInstructionProd.Text = oBatch.Remarks1;
                txtInstructionStore.Text = oBatch.Remarks2;

                dtpBoMDate.SetTime(oBoM.ProdJobDate);
                dtpbatchDate.SetTime(oBatch.BatchDate);

                FillRawMaterialGrid_byBatch(oBatch.ProdBatch_ID);

                if (oBatch.IsApproved)
                    SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                if (oBatch.IsChecked)
                    SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
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

        private void FillRawMaterialGrid_byBatch(string sBatch_ID)
        {
            dtMeterialReq.Rows.Clear();
            string sItemGroup_Name = "";
            string sIsSelect = "\uE003";
            foreach (tbl_prod_pharmaTxBatch_Material oBatch_Meterial in tbl_prod_pharmaTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID).Where(r1 => r1.Line_No_Sub1 == 0).OrderBy(r2 => r2.Line_No).ThenBy(r3 => r3.Line_No_Sub2))
            {
                string sItemName = clsGenaralName.getName_Item(oBatch_Meterial.Item_ID);
                string sUoMName = clsGenaralName.getName_Uom(oBatch_Meterial.Uom_ID);
                string sInputQty = cls_Formater.FormatDecimal(oBatch_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity);
                string sWastage_Pct = cls_Formater.FormatDecimal(oBatch_Meterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity);
                string sTotalInputQty = cls_Formater.FormatDecimal(oBatch_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity);
                string sSectionName = clsGenaralName.getName_Section(oBatch_Meterial.Section_ID);
                string sActivityName = clsGenaralName.getName_PharmaSectionActivity(oBatch_Meterial.Activity_ID);

                frm_RawMeterialGroups_SemiFinished oFrmMaterialsForSF = new frm_RawMeterialGroups_SemiFinished("Raw Meterial List for Semi-Finished Item ");

                #region Materials for Semi Finisheds
                string sSemiFG_ItemGroup_Name = "";
                string sSemiFG_IsSelect = "\uE003";
                foreach (tbl_prod_pharmaTxBatch_Material oBatch_Meterial_ForSemi in tbl_prod_pharmaTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID).Where(r => r.Line_No == oBatch_Meterial.Line_No && r.Line_No_Sub1 != 0).OrderBy(r2 => r2.Line_No_Sub1).ThenBy(r3 => r3.Line_No_Sub2))
                {
                    string sSemiFG_ItemName = clsGenaralName.getName_Item(oBatch_Meterial_ForSemi.Item_ID);
                    string sSemiFG_SectionName = clsGenaralName.getName_Section(oBatch_Meterial_ForSemi.Section_ID);
                    string sSemiFG_ActivityName = clsGenaralName.getName_PharmaSectionActivity(oBatch_Meterial_ForSemi.Activity_ID);

                    if (oBatch_Meterial_ForSemi.Line_No_Sub2 == 0)
                    {
                        sSemiFG_ItemGroup_Name = sSemiFG_SectionName + ", " + sSemiFG_ActivityName + ", " + sSemiFG_ItemName;
                    }

                    sSemiFG_IsSelect = oBatch_Meterial_ForSemi.IsSelected ? "\uE0A2" : "\uE003";

                    oFrmMaterialsForSF.dtMeterialReq.Rows.Add("",
                        oBatch_Meterial_ForSemi.Line_No,
                        oBatch_Meterial_ForSemi.Line_No_Sub1,
                        oBatch_Meterial_ForSemi.Line_No_Sub2,
                        sSemiFG_IsSelect,
                        oBatch_Meterial_ForSemi.Item_ID, sSemiFG_ItemName,
                        oBatch_Meterial_ForSemi.Uom_ID, clsGenaralName.getName_Uom(oBatch_Meterial_ForSemi.Uom_ID),
                        cls_Formater.FormatDecimal(oBatch_Meterial_ForSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oBatch_Meterial_ForSemi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oBatch_Meterial_ForSemi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                        oBatch_Meterial_ForSemi.Section_ID, sSemiFG_SectionName,
                        oBatch_Meterial_ForSemi.Activity_ID, sSemiFG_ActivityName,
                        sSemiFG_ItemGroup_Name,
                         cls_Formater.FormatDecimal(oBatch_Meterial_ForSemi.TotalInputQty * clsValidation.Validate_DecimalNumber(txtBatchQty.Text), clsConfig.sDecimalPlaces_Quantity)
                        );
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(oFrmMaterialsForSF.dtMeterialReq);
                #endregion

                if (oBatch_Meterial.Line_No_Sub2 == 0)
                {
                    sItemGroup_Name = sSectionName + ", " + sActivityName + ", " + sItemName;
                }

                sIsSelect = oBatch_Meterial.IsSelected ? "\uE0A2" : "\uE003";

                dtMeterialReq.Rows.Add("0", oBatch_Meterial.Line_No, oBatch_Meterial.Line_No_Sub1, oBatch_Meterial.Line_No_Sub2, sIsSelect,
                                    oBatch_Meterial.Item_ID, sItemName, oBatch_Meterial.Uom_ID, sUoMName,
                                    sInputQty, sWastage_Pct, sTotalInputQty, oBatch_Meterial.Section_ID, sSectionName, oBatch_Meterial.Activity_ID, sActivityName,
                                    oBatch_Meterial.IsSemiFinishItem, oFrmMaterialsForSF, sItemGroup_Name,
                                    cls_Formater.FormatDecimal(oBatch_Meterial.TotalInputQty * clsValidation.Validate_DecimalNumber(txtBatchQty.Text), clsConfig.sDecimalPlaces_Quantity)
                                    );

            }

        }

        private void FillRawMaterialGrid_byBoM(string sBoM_ID)
        {
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                dtMeterialReq.Rows.Clear();
                string sItemGroup_Name = "";
                string sIsSelect = "\uE003";
                foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r1 => r1.Line_No_Sub1 == 0).OrderBy(r2 => r2.Line_No).ThenBy(r3 => r3.Line_No_Sub2))
                {
                    string sItemName = clsGenaralName.getName_Item(oJob_Meterial.Item_ID);
                    string sUoMName = clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID);
                    string sInputQty = cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity);
                    string sWastage_Pct = cls_Formater.FormatDecimal(oJob_Meterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity);
                    string sTotalInputQty = cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity);
                    string sSectionName = clsGenaralName.getName_Section(oJob_Meterial.Section_ID);
                    string sActivityName = clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial.Activity_ID);

                    frm_RawMeterialGroups_SemiFinished oFrmMaterialsForSF = new frm_RawMeterialGroups_SemiFinished("Raw Meterial List for Semi-Finished Item ");

                    #region Materials for Semi Finisheds
                    string sSemiFG_ItemGroup_Name = "";
                    string sSemiFG_IsSelect = "\uE003";
                    foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial_ForSemi in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 != 0).OrderBy(r2 => r2.Line_No_Sub1).ThenBy(r3 => r3.Line_No_Sub2))
                    {
                        string sSemiFG_ItemName = clsGenaralName.getName_Item(oJob_Meterial_ForSemi.Item_ID);
                        string sSemiFG_SectionName = clsGenaralName.getName_Section(oJob_Meterial_ForSemi.Section_ID);
                        string sSemiFG_ActivityName = clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial_ForSemi.Activity_ID);

                        if (oJob_Meterial_ForSemi.Line_No_Sub2 == 0)
                        {
                            sSemiFG_ItemGroup_Name = sSemiFG_SectionName + ", " + sSemiFG_ActivityName + ", " + sSemiFG_ItemName;
                            if (clsHelpMethods_Prod.GetSubstituteMaterials(oJob_Meterial_ForSemi.Line_No, oJob_Meterial_ForSemi.Line_No_Sub1, oJob_Meterial_ForSemi.ProdJob_ID).Count == 1)
                                sSemiFG_IsSelect = "\uE0A2";
                            else
                                sSemiFG_IsSelect = "\uE003";
                        }
                        else
                            sSemiFG_IsSelect = "\uE003";


                        oFrmMaterialsForSF.dtMeterialReq.Rows.Add("",
                            oJob_Meterial_ForSemi.Line_No,
                            oJob_Meterial_ForSemi.Line_No_Sub1,
                            oJob_Meterial_ForSemi.Line_No_Sub2,
                            sSemiFG_IsSelect,
                            oJob_Meterial_ForSemi.Item_ID, sSemiFG_ItemName,
                            oJob_Meterial_ForSemi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSemi.Uom_ID),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                            oJob_Meterial_ForSemi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSemi.Section_ID),
                            oJob_Meterial_ForSemi.Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial_ForSemi.Activity_ID),
                            sSemiFG_ItemGroup_Name,
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalInputQty * clsValidation.Validate_DecimalNumber(txtBatchQty.Text), clsConfig.sDecimalPlaces_Quantity)
                            );
                    }

                    clsHelpMethods_Prod.OrderBy_DataGrid(oFrmMaterialsForSF.dtMeterialReq);
                    #endregion

                    if (oJob_Meterial.Line_No_Sub2 == 0)
                    {
                        sItemGroup_Name = sSectionName + ", " + sActivityName + ", " + sItemName; // sItemName;
                        if (clsHelpMethods_Prod.GetSubstituteMaterials(oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.ProdJob_ID).Count == 1)
                            sIsSelect = "\uE0A2";
                        else
                            sIsSelect = "\uE003";
                    }
                    else
                        sIsSelect = "\uE003";


                    dtMeterialReq.Rows.Add("0", oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.Line_No_Sub2, sIsSelect,
                                        oJob_Meterial.Item_ID, sItemName, oJob_Meterial.Uom_ID, sUoMName,
                                        sInputQty, sWastage_Pct, sTotalInputQty, oJob_Meterial.Section_ID, sSectionName, oJob_Meterial.Activity_ID, sActivityName,
                                        oJob_Meterial.IsSemiFinishItem, oFrmMaterialsForSF, sItemGroup_Name,
                                        cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty * clsValidation.Validate_DecimalNumber(txtBatchQty.Text), clsConfig.sDecimalPlaces_Quantity)
                                        );

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
        #endregion

        #region Grid Events
        #region Main Grid
        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[8].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch
            {
                // ignored
            }
        }

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
        #endregion

        #region Material Grid
        private void dgr_MererialReq_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);
        }

        private void dgr_MererialReq_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        private void dgr_MererialReq_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oSelectedItem = dgr_MererialReq.SelectedItem;
                var vDG_Cell = dgr_MererialReq.CurrentCell;
                if (oSelectedItem != null)
                {
                    string Grid_LineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(oSelectedItem) as TextBlock)?.Text;
                    DataRow drRow = dtMeterialReq.Select("LineNo = '" + Grid_LineNo + "'").FirstOrDefault();
                    if (drRow != null && (vDG_Cell.Column.SortMemberPath == "IsSelect" || vDG_Cell.Column.SortMemberPath == "Item_ID" || vDG_Cell.Column.SortMemberPath == "ItemName"))
                    {
                        string sSubstitueGroup = drRow["SubstitueGroup"].ToString();
                        //DataRow[] drSustituteRows = dtMeterialReq.Select(@"SubstitueGroup = '" + sSubstitueGroup + "'");

                        var drSustituteRows = dtMeterialReq.AsEnumerable().Where(row => row.Field<string>("SubstitueGroup") == sSubstitueGroup);

                        foreach (var vdr in drSustituteRows)
                            vdr["IsSelect"] = "\uE003";

                        bool bIsChecked = false;
                        bIsChecked = drRow["IsSelect"].ToString() == "\uE0A2" ? true : false;
                        drRow["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";
                    }

                }
            }
            catch (Exception) { }
        }

        private void dgr_MererialReq_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oSelectedItem = dgr_MererialReq.SelectedItem;
                var vDG_Cell = dgr_MererialReq.CurrentCell;
                if (oSelectedItem != null)
                {
                    string Grid_LineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(oSelectedItem) as TextBlock)?.Text;
                    DataRow drRow = dtMeterialReq.Select("LineNo = '" + Grid_LineNo + "'").FirstOrDefault();
                    if (drRow != null && (vDG_Cell.Column.SortMemberPath == "IsSemiFinished"))
                    {
                        bool bSemiFinished = bool.Parse(drRow["IsSemiFinished"].ToString());
                        if (bSemiFinished)
                        {
                            try
                            {
                                frm_RawMeterialGroups_SemiFinished frmSemi = drRow.Field<frm_RawMeterialGroups_SemiFinished>("SemiFinished_RawMeterials");
                                frmSemi.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                SEACCExeption.Show(ex);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
        #endregion

        #endregion

        #region Search Events
        private void txtBoMID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search rowDataSearch = new frm_search();
            rowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = rowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs_CostApproved);
            if (rowDataSearch.DialogResult == true)
            {
                ClearFields();

                tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(lstResult[0]);

                txtBoMID.Tag = oBoM.ProdJob_ID;
                txtFGDescription.Tag = oBoM.Item_ID_FG;
                txtFGSalesName.Tag = oBoM.Item_ID_FG;
                txtCustomer.Tag = oBoM.Customer_ID;
                txtCustomerCOSO.Tag = oBoM.CustomerOrder_ID;
                txtUoM.Tag = oBoM.Uom_ID;

                txtFGSalesName.ToolTip = oBoM.Item_ID_FG;

                dtpBoMDate.SetTime(oBoM.DateCreate);

                txtBoMID.Text = oBoM.ProdJob_ID;
                txtFGDescription.Text = clsGenaralName.getDescription_Item(oBoM.Item_ID_FG);
                txtFGSalesName.Text = clsGenaralName.getName_Item(oBoM.Item_ID_FG);
                txtCustomer.Text = clsGenaralName.getName_Customer(oBoM.Customer_ID);
                txtCustomerCOSO.Text = oBoM.CustomerOrder_ID != "default" ? oBoM.CustomerOrder_ID : "-";
                txtUoM.Text = clsGenaralName.getName_UomAndCode(oBoM.Uom_ID);
                txtSOQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetItemQty_FromCO(oBoM.CustomerOrder_ID, oBoM.Item_ID_FG), clsConfig.sDecimalPlaces_Quantity);
                txtPreviousBatchQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetTotalQtyofBatches_FromBoM(oBoM.ProdJob_ID, clsSecurity.getServerDateTime()), clsConfig.sDecimalPlaces_Quantity);
                txtBatchQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);  // cls_Formater.FormatDecimal(oBoM.FGoodQty, clsConfig.sDecimalPlaces_Quantity);

                tbl_prod_pharmaTxFinishedGoodSpecsSheet oProdSepec = tbl_prod_pharmaTxFinishedGoodSpecsSheet.Select(oBoM.Item_ID_FG);
                if (oProdSepec == null) return;
                txtInstructionProd.Text = oProdSepec.Instruction_Prod;
                txtInstructionStore.Text = oProdSepec.Instruction_Stores;

                FillRawMaterialGrid_byBoM(oBoM.ProdJob_ID);
            }
        }

        private void txtCustomerCOSO_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCustomer.Tag != null && txtCustomer.Text != "")
                lstParameeters.Add(txtCustomer.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProdCustomerOrder);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCOSO.Tag = lstResult[0];
                txtCustomerCOSO.Text = lstResult[0];

                txtCustomer.Tag = lstResult[2];
                txtCustomer.Text = lstResult[4];
                txtCustomer.IsEnabled = false;

                txtSOQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetItemQty_FromCO(lstResult[0], txtFGDescription.Tag.ToString()), clsConfig.sDecimalPlaces_Quantity);
            }
        }

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Customer);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[1];

                txtCustomerCOSO.Tag = null;
                txtCustomerCOSO.Text = "";

                txtSOQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
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

        #region Help Methods
        private void InsertBatchMaterials()
        {
            foreach (DataRow row in dtMeterialReq.Rows)
            {
                int iLineNoMain = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoMain", 0m));
                int iLineNoSub1 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub1", 0m));
                int iLineNoSub2 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub2", 0m));
                string sIsSelect = clsValidate.ValidateRowValue(row, "IsSelect", "\uE003");
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                decimal dWastagePct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                string sSectionID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                string sActivityID = clsValidate.ValidateRowValue(row, "ActivityID", "default");
                bool bIsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);
                frm_RawMeterialGroups_SemiFinished frm_Semi = row.Field<frm_RawMeterialGroups_SemiFinished>("SemiFinished_RawMeterials");

                tbl_prod_pharmaTxJobCard_Material oBoM_Material = tbl_prod_pharmaTxJobCard_Material.Select(iLineNoMain, iLineNoSub1, iLineNoSub2, txtBoMID.Tag.ToString());
                if (oBoM_Material != null)
                {
                    tbl_prod_pharmaTxBatch_Material oBatch_Materials = new tbl_prod_pharmaTxBatch_Material(
                        iLineNoMain, iLineNoSub1, iLineNoSub2, txtBoMID.Tag.ToString(), txtProdBatchID.Text,
                        sItem_ID, sUoM_ID, bIsSemiFinished, dQty, oBoM_Material.IsWastagePercent, dWastagePct, 0, dTotalQty, sSectionID, sActivityID, oBoM_Material.Smv_TimeMinutes, oBoM_Material.TotalLabour,
                        oBoM_Material.LowestCost, oBoM_Material.HighestCost, oBoM_Material.WeightedAvgCost, oBoM_Material.CostTypeSelection, oBoM_Material.Cost, oBoM_Material.AllowCostEdit,
                        oBoM_Material.EditedCost, (sIsSelect == "\uE0A2"));
                    oBatch_Materials.Insert();
                }

                if (frm_Semi != null)
                {
                    foreach (DataRow row_Semi in frm_Semi.dtMeterialReq.Rows)
                    {
                        int iLineNoMain_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_Semi, "LineNoMain", 0m));
                        int iLineNoSub1_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_Semi, "LineNoSub1", 0m));
                        int iLineNoSub2_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_Semi, "LineNoSub2", 0m));
                        string sIsSelect_Semi = clsValidate.ValidateRowValue(row_Semi, "IsSelect", "\uE003");
                        string sItem_ID_Semi = clsValidate.ValidateRowValue(row_Semi, "Item_ID", "default");
                        string sUoM_ID_Semi = clsValidate.ValidateRowValue(row_Semi, "UoM_ID", "default");
                        decimal dQty_Semi = clsValidate.ValidateRowValue(row_Semi, "Qty", 0m);
                        decimal dWastagePct_Semi = clsValidate.ValidateRowValue(row_Semi, "Wastage", 0m);
                        decimal dTotalQty_Semi = clsValidate.ValidateRowValue(row_Semi, "TotalQty", 0m);
                        string sSectionID_Semi = clsValidate.ValidateRowValue(row_Semi, "SectionID", "default");
                        string sActivityID_Semi = clsValidate.ValidateRowValue(row_Semi, "ActivityID", "default");

                        tbl_prod_pharmaTxJobCard_Material oBoM_Material_Semi = tbl_prod_pharmaTxJobCard_Material.Select(iLineNoMain_Semi, iLineNoSub1_Semi, iLineNoSub2_Semi, txtBoMID.Tag.ToString());
                        if (oBoM_Material != null)
                        {
                            tbl_prod_pharmaTxBatch_Material oBatch_Material_Semi = new tbl_prod_pharmaTxBatch_Material(
                                iLineNoMain_Semi, iLineNoSub1_Semi, iLineNoSub2_Semi, txtBoMID.Tag.ToString(), txtProdBatchID.Text,
                                sItem_ID_Semi, sUoM_ID_Semi, oBoM_Material_Semi.IsSemiFinishItem, dQty_Semi, oBoM_Material_Semi.IsWastagePercent, dWastagePct_Semi, 0, dTotalQty_Semi, sSectionID_Semi, sActivityID_Semi, oBoM_Material_Semi.Smv_TimeMinutes, oBoM_Material_Semi.TotalLabour,
                                oBoM_Material_Semi.LowestCost, oBoM_Material_Semi.HighestCost, oBoM_Material_Semi.WeightedAvgCost, oBoM_Material_Semi.CostTypeSelection, oBoM_Material_Semi.Cost, oBoM_Material_Semi.AllowCostEdit,
                                oBoM_Material_Semi.EditedCost, (sIsSelect_Semi == "\uE0A2"));
                            oBatch_Material_Semi.Insert();
                        }
                    }
                }
            }
        }
        #endregion

        private void txtBatchQty_TextBox_TextChanged(object sender, EventArgs e)
        {
            decimal dBatchQty = clsValidation.Validate_DecimalNumber(txtBatchQty.TextBox1.Text);
            foreach (DataRow row in dtMeterialReq.Rows)
            {
                decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                row["TotalQtyWithRespectBatchQty"] = cls_Formater.FormatDecimal(dTotalQty * dBatchQty, clsConfig.sDecimalPlaces_Quantity);


                frm_RawMeterialGroups_SemiFinished frm_Semi = row.Field<frm_RawMeterialGroups_SemiFinished>("SemiFinished_RawMeterials");
                if (frm_Semi != null)
                {
                    foreach (DataRow semi_row in frm_Semi.dtMeterialReq.Rows)
                    {
                        decimal dSemi_TotalQty = clsValidate.ValidateRowValue(semi_row, "TotalQty", 0m);
                        semi_row["TotalQtyWithRespectBatchQty"] = cls_Formater.FormatDecimal(dSemi_TotalQty * dBatchQty, clsConfig.sDecimalPlaces_Quantity);
                    }
                }

            }
        }
    }
}
