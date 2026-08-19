using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using SEACC_WPFControls;
using DataTire;
using SEACC_PRODUCTION_APPAREL.Common;
using System.Data;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.UserManagement;

namespace SEACC_PRODUCTION_APPAREL
{
    /// <summary>
    /// Interaction logic for UC_FinishedGood_Transfers_DetailView.xaml
    /// </summary>
    public partial class UC_FinishedGood_Transfers_DetailView : UserControl
    {
        #region Class Variables
        BrushConverter bc = new BrushConverter();
        private DataTable dtFG_Details = new DataTable();
        #endregion

        #region Form Load
        public UC_FinishedGood_Transfers_DetailView()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_FGTN_DetailView;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Meterial Grid
            dtFG_Details.Columns.Add("LineNo", typeof(int));
            dtFG_Details.Columns.Add("Item_ID");
            dtFG_Details.Columns.Add("ItemNameFG");
            dtFG_Details.Columns.Add("UoM_ID");
            dtFG_Details.Columns.Add("UoM");
            dtFG_Details.Columns.Add("Qty");
            dtFG_Details.Columns.Add("Remarks");
            #endregion

            #region Main Grid
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("FGTN_NO");
            dgr_Main.dt.Columns.Add("FGTN_DATE");
            dgr_Main.dt.Columns.Add("ITEM_DESCRIPTION");
            dgr_Main.dt.Columns.Add("QTY");
            dgr_Main.dt.Columns.Add("FROM_STORE");
            dgr_Main.dt.Columns.Add("TO_STORE");
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
            dgr_Main.Add_DatagridColoumn("FGTN #", "FGTN_NO", 80);
            dgr_Main.Add_DatagridColoumn("Date", "FGTN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Item", "ITEM_DESCRIPTION", 150);
            dgr_Main.Add_DatagridColoumn("Qty.", "QTY", 60);
            dgr_Main.Add_DatagridColoumn("From Store", "FROM_STORE", 100);
            dgr_Main.Add_DatagridColoumn("To Store", "TO_STORE", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region From Responsiveness
        private void SEACC_Form_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Button

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
                            tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(txtFGTN_ID.Tag.ToString());
                            if (oFGTN != null)
                            {
                                if (!oFGTN.IsApproved)
                                {
                                    if (!oFGTN.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oFGTN.IsCanceled = true;
                                                oFGTN.DateCanceled = clsSecurity.getServerDateTime();
                                                oFGTN.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oFGTN.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oFGTN.Update();

                                                clsHelpMethods_Prod.UpdateStock(oFGTN.From_Store_ID, oFGTN.Item_ID_FG, oFGTN.FgtnQty);

                                                foreach (tbl_prodTxFinishedGoodTransferNote_Detail oFGTN_Item in tbl_prodTxFinishedGoodTransferNote_Detail.SelectAllByFgtn_ID(txtFGTN_ID.Text))
                                                    clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), oFGTN_Item.Item_ID, -oFGTN_Item.FgtnQty);

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
                SEACCExeption.Show(ex);
            }
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sFgtnId = "";
            if (CheckValidity())
            {
                bool bExecClearFields = true;

                decimal dCurrentlyIssuingQty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtFGDescription.Tag.ToString());
                decimal dSectionPhysicalQty = clsProcessMethods.Get_SectionStoreStockBalance_Qty(txtFromSection.Tag.ToString(), txtFGDescription.Tag.ToString(), "default", oItem.ItemCategorySub_ID, "default", "0", "0");

                try
                {
                    #region Update

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxFinishedGoodTransferNote oOldFGTN = tbl_prodTxFinishedGoodTransferNote.Select(txtFGTN_ID.Tag.ToString());
                            if (oOldFGTN != null)
                            {
                                if ((dSectionPhysicalQty + oOldFGTN.FgtnQty) >= dCurrentlyIssuingQty)
                                {
                                    if (!oOldFGTN.IsApproved && !oOldFGTN.IsCanceled)
                                    {
                                        decimal dAlreadyBatchQty = 0;
                                        decimal dAlreadyTotalCost = 0;
                                        string sBatch_ID = txtBatch_ID.Tag != null ? txtBatch_ID.Tag.ToString() : "default";
                                        decimal dunit_Cost = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_ID , ref dAlreadyBatchQty, ref dAlreadyTotalCost );
                                        decimal dCurrentFGTN_Qty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);

                                        clsHelpMethods_Prod.UpdateStock(oOldFGTN.From_Store_ID, oOldFGTN.Item_ID_FG, oOldFGTN.FgtnQty);

                                        foreach (tbl_prodTxFinishedGoodTransferNote_Detail oFGTN_Item in tbl_prodTxFinishedGoodTransferNote_Detail.SelectAllByFgtn_ID(txtFGTN_ID.Text))
                                        {
                                            clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), oFGTN_Item.Item_ID, -oFGTN_Item.FgtnQty);
                                            oFGTN_Item.Delete();
                                        }

                                        tbl_prodTxFinishedGoodTransferNote oFGTN =
                                            new tbl_prodTxFinishedGoodTransferNote(txtFGTN_ID.Text,
                                                dtpFGTN_Date.GetDateTime(),
                                                txtProdJob_ID.Tag?.ToString() ?? "default",
                                                sBatch_ID,
                                                txtFGDescription.Tag?.ToString() ?? "default",
                                                txtFG_UoM.Tag?.ToString() ?? "default",
                                                clsValidation.Validate_DecimalNumber(txtSoQty.Text),
                                                clsValidation.Validate_DecimalNumber(txtPreviouslyIssuedQty.Text),
                                                dCurrentlyIssuingQty,
                                                oOldFGTN.FgtnWeight, dunit_Cost, oOldFGTN.WeightPrice,
                                                dCurrentFGTN_Qty * dunit_Cost,
                                                txtFromSection.Tag != null ? clsHelpMethods_Prod.GetStoreID_FromSectionID(txtFromSection.Tag.ToString()) : "default",
                                                txtToStore.Tag?.ToString() ?? "default",
                                                txtRemarks.Text,
                                                oOldFGTN.IsChecked, oOldFGTN.IsApproved, oOldFGTN.IsCanceled,
                                                oOldFGTN.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oOldFGTN.CheckedUser_ID, oOldFGTN.ApprovedUser_ID,
                                                oOldFGTN.CanceldUser_ID,
                                                oOldFGTN.DateCreate, clsSecurity.getServerDateTime(),
                                                oOldFGTN.DateChecked, oOldFGTN.DateApproved, oOldFGTN.DateCanceled,
                                                oOldFGTN.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                                oOldFGTN.CheckedUserTerminal_ID, oOldFGTN.ApprovedUserTerminal_ID,
                                                oOldFGTN.CanceledUserTerminal_ID,
                                                oOldFGTN.CompanyID, oOldFGTN.CompanyBranchID);
                                        oFGTN.Update();

                                        clsHelpMethods_Prod.UpdateSectionFloorStock(txtFromSection.Tag.ToString(), txtFGDescription.Tag.ToString(), -dCurrentlyIssuingQty);

                                        Insert_FGTN_Detail();

                                        sFgtnId = oOldFGTN.Fgtn_ID;
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldFGTN.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..",
                                                "Selected FGTN has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldFGTN.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..",
                                                "Selected FGTN has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Oops..!",
                                            "WIP Floor FG Quantity : " + cls_Formater.FormatDecimal(dSectionPhysicalQty, clsConfig.sDecimalPlaces_Quantity) +
                                            "\nAll Currently Issuing Quantity should be less than or equal to WIP Floor FG Quantity",
                                            MessageBoxButton.OK, "Red");

                                    bExecClearFields = false;
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
                            if (dSectionPhysicalQty >= dCurrentlyIssuingQty)
                            {
                                decimal dAlreadyBatchQty = 0;
                                decimal dAlreadyTotalCost = 0;
                                string sBatch_ID = txtBatch_ID.Tag != null ? txtBatch_ID.Tag.ToString() : "default";
                                decimal dunit_Cost = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_ID ,ref dAlreadyBatchQty, ref dAlreadyTotalCost);
                                decimal dCurrentFGTN_Qty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);

                                tbl_prodTxFinishedGoodTransferNote oNewFGTN =
                                    new tbl_prodTxFinishedGoodTransferNote(txtFGTN_ID.Text,
                                        dtpFGTN_Date.GetDateTime(),
                                        txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                        sBatch_ID,
                                        txtFGDescription.Tag != null ? txtFGDescription.Tag.ToString() : "default",
                                        txtFG_UoM.Tag != null ? txtFG_UoM.Tag.ToString() : "default",
                                        clsValidation.Validate_DecimalNumber(txtBatchQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtPreviouslyIssuedQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text), 0,
                                        dunit_Cost,
                                        0,
                                        dunit_Cost * dCurrentFGTN_Qty,
                                        txtFromSection.Tag != null ? clsHelpMethods_Prod.GetStoreID_FromSectionID(txtFromSection.Tag.ToString()) : "default",
                                        txtToStore.Tag != null ? txtToStore.Tag.ToString() : "default",
                                        txtRemarks.Text, false, false, false,
                                        clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                        clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                        clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                        clsValidation.defaultDateTime,
                                        clsSecurity.TerminalID, "default", "default", "default", "default",
                                        clsSecurity.CompanyID, clsSecurity.BranchID);

                                oNewFGTN.Insert();
                                clsHelpMethods_Prod.UpdateSectionFloorStock(txtFromSection.Tag.ToString(), txtFGDescription.Tag.ToString(), -dCurrentlyIssuingQty);

                                Insert_FGTN_Detail();

                                sFgtnId = oNewFGTN.Fgtn_ID;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Oops..!",
                                    "WIP Floor FG Quantity : " + cls_Formater.FormatDecimal(dSectionPhysicalQty, clsConfig.sDecimalPlaces_Quantity) +
                                    "\nAll Currently Issuing Quantity should be less than or equal to WIP Floor FG Quantity",
                                    MessageBoxButton.OK, "Red");

                                bExecClearFields = false;
                            }
                        }
                    }

                    #endregion

                    if (txtProdJob_ID.Tag != null)
                    {
                        tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.Select(txtProdJob_ID.Tag.ToString());
                        oProdJob.ProdJobStatus = ((int)prod_BoM_Status.FGTN);
                        oProdJob.Update();
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    if (bExecClearFields)
                    {
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sFgtnId);
                    }
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
                            tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(txtFGTN_ID.Tag.ToString());
                            if (oFGTN != null)
                            {
                                if (!oFGTN.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oFGTN.IsApproved = true;
                                            oFGTN.DateApproved = clsSecurity.getServerDateTime();
                                            oFGTN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oFGTN.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oFGTN.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oFGTN.Fgtn_ID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected FGTN has already been approved", MessageBoxButton.OK, "Red");
                                }
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

        #region Finished Good Grid Buttons
        private void BtnAddItem_OnClick(object sender, RoutedEventArgs e)
        {
            frm_search frmWIP_SF_search = new frm_search();
            frmWIP_SF_search.Show(Digiteq_Logic.Search.Prod_SemiFiniseds_FinishedGoods, true);
            frmWIP_SF_search.RowSelected += FrmWIP_SF_Search_RowSelected;
        }

        private void BtnGridItemDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Meterial.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_Meterial.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] items = dtFG_Details.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtFG_Details.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtFG_Details);
            }
        }
        #endregion

        #endregion

        #region Clear Field
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtFGTN_ID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJob_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_UoM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSoQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBatchQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPreviouslyIssuedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCurrentlyIssuingQty, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFromSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtToStore, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtFGTN_ID.Tag = null;
            txtFGDescription.Tag = null;
            txtFGSalesName.Tag = null;
            txtProdJob_ID.Tag = null;
            txtBatch_ID.Tag = null;
            txtFG_UoM.Tag = null;
            txtFromSection.Tag = null;
            txtToStore.Tag = null;

            txtFGSalesName.ToolTip = null;

            dtpFGTN_Date.SetTime(DateTime.Now);
            txtFGTN_ID.Text = "";
            txtFGDescription.Text = "";
            txtFGSalesName.Text = "";
            txtProdJob_ID.Text = "";
            txtBatch_ID.Text = "";
            txtFG_UoM.Text = "";
            txtFromSection.Text = "";
            txtToStore.Text = "";
            txtSoQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtBatchQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtPreviouslyIssuedQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtCurrentlyIssuingQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtRemarks.Text = "";

            dtFG_Details.Clear();
            dgr_Meterial.ItemsSource = dtFG_Details.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtFGTN_ID.setReadOnlyStatus(true);
                txtFGTN_ID.Text = "<Auto Generate>";
            }
            else
                txtFGTN_ID.setReadOnlyStatus(false);
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
                foreach (tbl_prodTxFinishedGoodTransferNote oFGTN in tbl_prodTxFinishedGoodTransferNote.SelectAll().Where(p => p.Fgtn_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oFGTN.Fgtn_ID, oFGTN.Fgtn_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Item(oFGTN.Item_ID_FG), cls_Formater.FormatDecimal(oFGTN.FgtnQty, 3), clsGenaralName.getName_Store(oFGTN.From_Store_ID), clsGenaralName.getName_Store(oFGTN.To_Store_ID), clsGenaralName.getName_User(oFGTN.CreateUser_ID), clsGenaralName.getName_User(oFGTN.ApprovedUser_ID), oFGTN.IsCanceled);
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

            if (!clsValidation.Validate_EmptyValue(txtFGTN_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJob_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBatch_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFGDescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFG_UoM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPreviouslyIssuedQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCurrentlyIssuingQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFromSection))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtToStore))
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
                    txtFGTN_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtFGTN_ID.Text = txtFGTN_ID.Tag.ToString();
                }

                tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(txtFGTN_ID.Text);
                if (oFGTN != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(sID);
                if (oFGTN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtFGTN_ID.Tag = oFGTN.Fgtn_ID;
                    txtFGDescription.Tag = oFGTN.Item_ID_FG;
                    txtFGSalesName.Tag = oFGTN.Item_ID_FG;
                    txtProdJob_ID.Tag = oFGTN.ProdJob_ID;
                    txtBatch_ID.Tag = oFGTN.ProdBatch_ID;
                    txtFG_UoM.Tag = oFGTN.Uom_ID;
                    txtFromSection.Tag = oFGTN.From_Store_ID != "default" ? tbl_genSectionMaster.SelectAllByStore_ID(oFGTN.From_Store_ID).FirstOrDefault()?.Section_ID : "default";
                    txtToStore.Tag = oFGTN.To_Store_ID;

                    txtFGSalesName.ToolTip = oFGTN.Item_ID_FG;

                    dtpFGTN_Date.SetTime(oFGTN.Fgtn_Date);
                    txtFGTN_ID.Text = oFGTN.Fgtn_ID;
                    txtBatch_ID.Text = oFGTN.ProdBatch_ID;
                    txtFGDescription.Text = clsGenaralName.getDescription_Item(oFGTN.Item_ID_FG);
                    txtFGSalesName.Text = clsGenaralName.getName_Item(oFGTN.Item_ID_FG);
                    txtProdJob_ID.Text = oFGTN.ProdJob_ID ?? "-";
                    txtFG_UoM.Text = clsGenaralName.getName_UomAndCode(oFGTN.Uom_ID);
                    txtFromSection.Text = txtFromSection.Tag != null ? clsGenaralName.getName_Section(txtFromSection.Tag.ToString()) : "-";
                    txtToStore.Text = clsGenaralName.getName_Store(oFGTN.To_Store_ID);
                    txtSoQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetItemQtyInCO_FromJob(oFGTN.ProdJob_ID, oFGTN.ProdBatch_ID), clsConfig.sDecimalPlaces_Quantity);
                    txtBatchQty.Text = cls_Formater.FormatDecimal(oFGTN.BatchQty, clsConfig.sDecimalPlaces_Quantity);
                    txtPreviouslyIssuedQty.Text = cls_Formater.FormatDecimal(oFGTN.PreviousIssuedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtCurrentlyIssuingQty.Text = cls_Formater.FormatDecimal(oFGTN.FgtnQty, clsConfig.sDecimalPlaces_Quantity);
                    txtRemarks.Text = oFGTN.Remark;

                    dtFG_Details.Rows.Clear();
                    foreach (tbl_prodTxFinishedGoodTransferNote_Detail oFGTN_Item in tbl_prodTxFinishedGoodTransferNote_Detail.SelectAllByFgtn_ID(oFGTN.Fgtn_ID))
                    {
                        dtFG_Details.Rows.Add(oFGTN_Item.Line_No, oFGTN_Item.Item_ID,
                            clsGenaralName.getName_Item(oFGTN_Item.Item_ID), oFGTN_Item.Uom_ID, clsGenaralName.getName_Uom(oFGTN_Item.Uom_ID),
                            cls_Formater.FormatDecimal(oFGTN_Item.FgtnQty, clsConfig.sDecimalPlaces_Quantity),
                            oFGTN_Item.Remark);
                    }

                    if (oFGTN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oFGTN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Grid Events

        #region Main Grid Events
        private void Dgr_Main_OnMouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string gridId = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;
                    ClearFields();
                    FillDetails(gridId);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Dgr_Main_OnLoadingRow(object sender, DataGridRowEventArgs e)
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

        #region Finished Good Grid
        private void Dgr_Meterial_OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            switch (sColumnName)
            {
                case "Qty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;
                    try
                    {
                        var vItem = dgr_Meterial.SelectedItem;
                        if (vItem != null)
                        {
                            dQty = decimal.Parse(t.Text);
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                    break;
            }
        }

        private void Dgr_Meterial_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtFG_Details);
        }
        #endregion

        #endregion

        #region Search Events
        private void TxtProdJob_ID_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs_Locked);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJob_ID.Tag = lstResult[0];
                txtProdJob_ID.Text = lstResult[0];

                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtFGSalesName.ToolTip = lstResult[2];

                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];

                txtFG_UoM.Tag = lstResult[8];
                txtFG_UoM.Text = lstResult[4];
            }
        }

        private void TxtFGDescription_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJob_ID.Tag = lstResult[0];
                txtProdJob_ID.Text = lstResult[0];

                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtFGSalesName.ToolTip = lstResult[2];

                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];

                txtFG_UoM.Tag = lstResult[8];
                txtFG_UoM.Text = lstResult[4];
            }
        }

        private void TxtBatch_ID_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJob_ID.Tag != null)
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtProdJob_ID.Tag.ToString());

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ClosedBatches);
                if (RowDataSearch.DialogResult == true)
                {
                    txtBatch_ID.Tag = lstResult[0];
                    txtBatch_ID.Text = lstResult[0];

                    tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(lstResult[0]);
                    if (oBatch != null)
                    {
                        txtPreviouslyIssuedQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyIssuedQty_formFGTNs(oBatch.ProdJob_ID, oBatch.ProdBatch_ID), clsConfig.sDecimalPlaces_Quantity);
                        txtBatchQty.Text = cls_Formater.FormatDecimal(oBatch.BatchQty, clsConfig.sDecimalPlaces_Quantity);
                        txtSoQty.Text = cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, clsConfig.sDecimalPlaces_Quantity);
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void TxtFromSection_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtFromSection.Tag = lstResult[0];
                txtFromSection.Text = lstResult[1];
            }
        }

        private void TxtToStore_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtToStore.Tag = lstResult[0];
                txtToStore.Text = lstResult[1];
            }
        }

        private void TxtFGSalesName_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJob_ID.Tag = lstResult[0];
                txtProdJob_ID.Text = lstResult[0];

                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];

                txtFGSalesName.ToolTip = lstResult[2];

                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];

                txtFG_UoM.Tag = lstResult[8];
                txtFG_UoM.Text = lstResult[4];
            }
        }

        private void FrmWIP_SF_Search_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtFG_Details.Select("Item_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Item Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    dtFG_Details.Rows.Add("0",
                        lstResult[0],
                        lstResult[2],
                        lstResult[6],
                        clsGenaralName.getName_Uom(lstResult[6]),
                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                        "");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Key Press Events

        private void SEACC_Form_OnPreviewKeyDown(object sender, KeyEventArgs e)
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

        #region Other Events
        private void EventSetter_OnHandler(object sender, KeyEventArgs e)
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
        private void Insert_FGTN_Detail()
        {
            foreach (DataRow row in dtFG_Details.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                string sRemarks = clsValidate.ValidateRowValue(row, "Remarks", "");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dQty;
                }
                tbl_prodTxFinishedGoodTransferNote_Detail oFGTN_Detail = new tbl_prodTxFinishedGoodTransferNote_Detail(iLine_no, txtFGTN_ID.Text, sItem_ID, sUoM_ID, dQty, 0, dUnitPrice, 0, dTotalAmount, sRemarks);
                oFGTN_Detail.Insert();

                clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), sItem_ID, dQty);
            }
        }
        #endregion
    }
}
