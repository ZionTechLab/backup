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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_POLY.Transactions
{
    /// <summary>
    /// Developped by Gayan
    /// 2017-05-25
    /// </summary>
    public partial class UC_FinishedGoodTransfers : UserControl
    {
        #region Class Variables
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_FinishedGoodTransfers()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_FGTN;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
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

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sFGTN_ID = "";
            if (CheckValidity())
            {
                decimal dCurrentlyIssuingQty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtFGItem.Tag.ToString());
                decimal dSectionPhysicalQty = clsProcessMethods.Get_SectionStoreStockBalance_Qty(txtFromSection.Tag.ToString(), txtFGItem.Tag.ToString(), "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                if (dCurrentlyIssuingQty <= dSectionPhysicalQty || true)
                {
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
                                    if (!oOldFGTN.IsApproved && !oOldFGTN.IsCanceled)
                                    {
                                        clsHelpMethods_Prod.UpdateStock(oOldFGTN.To_Store_ID, oOldFGTN.Item_ID_FG, -oOldFGTN.FgtnQty);
                                        clsHelpMethods_Prod.UpdateStock(oOldFGTN.From_Store_ID, oOldFGTN.Item_ID_FG, oOldFGTN.FgtnQty);

                                        tbl_prodTxFinishedGoodTransferNote oFGTN = new tbl_prodTxFinishedGoodTransferNote(txtFGTN_ID.Text, dtpFGTN_Date.GetDateTime(),
                                        txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                        txtFGItem.Tag != null ? txtFGItem.Tag.ToString() : "default",
                                        txtFG_QtyUoM.Tag != null ? txtFG_QtyUoM.Tag.ToString() : "default",
                                        decimal.Parse(txtSoQty.Text), decimal.Parse(txtPreviouslyIssuedQty.Text), dCurrentlyIssuingQty, oOldFGTN.FgtnWeight, oOldFGTN.UnitPrice, oOldFGTN.WeightPrice, oOldFGTN.TotalAmount,
                                        txtFromSection.Tag != null ? clsHelpMethods_Prod.GetStoreID_FromSectionID(txtFromSection.Tag.ToString()) : "default",
                                        txtToStore.Tag != null ? txtToStore.Tag.ToString() : "default",
                                        txtRemarks.Text,
                                        oOldFGTN.IsChecked, oOldFGTN.IsApproved, oOldFGTN.IsCanceled,
                                        oOldFGTN.CreateUser_ID, clsSecurity.UserIDLoged, oOldFGTN.CheckedUser_ID, oOldFGTN.ApprovedUser_ID, oOldFGTN.CanceldUser_ID,
                                        oOldFGTN.DateCreate, clsSecurity.getServerDateTime(), oOldFGTN.DateChecked, oOldFGTN.DateApproved, oOldFGTN.DateCanceled,
                                        oOldFGTN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldFGTN.CheckedUserTerminal_ID, oOldFGTN.ApprovedUserTerminal_ID, oOldFGTN.CanceledUserTerminal_ID,
                                        oOldFGTN.CompanyID, oOldFGTN.CompanyBranchID
                                        );
                                        oFGTN.Update();

                                        clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), txtFGItem.Tag.ToString(), dCurrentlyIssuingQty);
                                        clsHelpMethods_Prod.UpdateSectionFloorStock(txtFromSection.Tag.ToString(), txtFGItem.Tag.ToString(), -dCurrentlyIssuingQty);

                                        sFGTN_ID = oOldFGTN.Fgtn_ID;
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldFGTN.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldFGTN.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
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
                                tbl_prodTxFinishedGoodTransferNote oNewFGTN = new tbl_prodTxFinishedGoodTransferNote(txtFGTN_ID.Text, dtpFGTN_Date.GetDateTime(),
                                    txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                    txtFGItem.Tag != null ? txtFGItem.Tag.ToString() : "default",
                                    txtFG_QtyUoM.Tag != null ? txtFG_QtyUoM.Tag.ToString() : "default",
                                    decimal.Parse(txtSoQty.Text), decimal.Parse(txtPreviouslyIssuedQty.Text), decimal.Parse(txtCurrentlyIssuingQty.Text), 0, 0, 0, 0,
                                    txtFromSection.Tag != null ? clsHelpMethods_Prod.GetStoreID_FromSectionID(txtFromSection.Tag.ToString()) : "default",
                                    txtToStore.Tag != null ? txtToStore.Tag.ToString() : "default",
                                    txtRemarks.Text,
                                    false, false, false,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID
                                    );
                                oNewFGTN.Insert();
                                sFGTN_ID = oNewFGTN.Fgtn_ID;

                                clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), txtFGItem.Tag.ToString(), dCurrentlyIssuingQty);
                                clsHelpMethods_Prod.UpdateSectionFloorStock(txtFromSection.Tag.ToString(), txtFGItem.Tag.ToString(), -dCurrentlyIssuingQty);

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                        }
                        #endregion

                        if (txtProdJob_ID.Tag != null)
                        {
                            tbl_prod_polyTxJobCard oProdJob = tbl_prod_polyTxJobCard.Select(txtProdJob_ID.Tag.ToString());
                            oProdJob.ProdJobStatus = ((int)prod_JobStatus.FGTN);
                            oProdJob.Update();
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
                        fillDetails(sFGTN_ID);
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Oops..!", "Physical Quantity : " + dSectionPhysicalQty + "\nCurrently Issuing Quantity should be less than or equal to Physical Quantity", MessageBoxButton.OK, "Red");
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
                                    fillDetails(oFGTN.Fgtn_ID);
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
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
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

                                                clsHelpMethods_Prod.UpdateStock(oFGTN.To_Store_ID, oFGTN.Item_ID_FG, -oFGTN.FgtnQty);
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oFGTN.From_Store_ID, oFGTN.Item_ID_FG, oFGTN.FgtnQty);

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

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtFGTN_ID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGItem, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJob_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_QtyUoM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSoQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPreviouslyIssuedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCurrentlyIssuingQty, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_WeiUoM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSoWeight, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPreviouslyIssuedWeight, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCurrentlyIssuingWeight, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFromSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtToStore, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtFGTN_ID.Tag = null;
            txtFGItem.Tag = null;
            txtProdJob_ID.Tag = null;
            txtFG_QtyUoM.Tag = null;
            txtFG_WeiUoM.Tag = null;
            txtFromSection.Tag = null;
            txtToStore.Tag = null;

            dtpFGTN_Date.SetTime(DateTime.Now);
            txtFGTN_ID.Text = "";
            txtFGItem.Text = "";
            txtProdJob_ID.Text = "";
            txtFG_QtyUoM.Text = "";
            txtFG_WeiUoM.Text = "";
            txtFromSection.Text = "";
            txtToStore.Text = "";
            txtSoQty.Text = "0.000";
            txtPreviouslyIssuedQty.Text = "0.000";
            txtCurrentlyIssuingQty.Text = "0.000";
            txtSoWeight.Text = "0.000";
            txtPreviouslyIssuedWeight.Text = "0.000";
            txtCurrentlyIssuingWeight.Text = "0.000";
            txtRemarks.Text = "";

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
                    dgr_Main.dt.Rows.Add(++iCount, oFGTN.Fgtn_ID, oFGTN.Fgtn_Date.ToString(clsValidation.Format_Date), clsGenaralName.getDescription_Item(oFGTN.Item_ID_FG), cls_Formater.FormatDecimal(oFGTN.FgtnQty, 3), clsGenaralName.getName_Store(oFGTN.From_Store_ID), clsGenaralName.getName_Store(oFGTN.To_Store_ID), clsGenaralName.getName_User(oFGTN.CreateUser_ID), clsGenaralName.getName_User(oFGTN.ApprovedUser_ID), oFGTN.IsCanceled);
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
            if (!clsValidation.Validate_EmptyValue(txtFGItem))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFG_QtyUoM))
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
        private void fillDetails(string sID)
        {
            try
            {
                tbl_prodTxFinishedGoodTransferNote oFGTN = tbl_prodTxFinishedGoodTransferNote.Select(sID);
                if (oFGTN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtFGTN_ID.Tag = oFGTN.Fgtn_ID;
                    txtFGItem.Tag = oFGTN.Item_ID_FG;
                    txtProdJob_ID.Tag = oFGTN.ProdJob_ID;
                    txtFG_QtyUoM.Tag = oFGTN.Uom_ID;
                    txtFG_WeiUoM.Tag = oFGTN.Uom_ID;
                    txtFromSection.Tag = oFGTN.From_Store_ID;
                    txtToStore.Tag = oFGTN.To_Store_ID;

                    dtpFGTN_Date.SetTime(oFGTN.Fgtn_Date);
                    txtFGTN_ID.Text = oFGTN.Fgtn_ID;
                    txtFGItem.Text = clsGenaralName.getDescription_Item(oFGTN.Item_ID_FG);
                    txtProdJob_ID.Text = oFGTN.ProdJob_ID != null ? oFGTN.ProdJob_ID : "-";
                    txtFG_QtyUoM.Text = clsGenaralName.getName_UomAndCode(oFGTN.Uom_ID);
                    txtFG_WeiUoM.Text = "Kg - Kilogram";
                    txtFromSection.Text = clsGenaralName.getName_Store(oFGTN.From_Store_ID);
                    txtToStore.Text = clsGenaralName.getName_Store(oFGTN.To_Store_ID); ;
                    txtSoQty.Text = cls_Formater.FormatDecimal(oFGTN.FGoodQty, 3);
                    txtPreviouslyIssuedQty.Text = cls_Formater.FormatDecimal(oFGTN.PreviousIssuedQty, 3);
                    txtCurrentlyIssuingQty.Text = cls_Formater.FormatDecimal(oFGTN.FgtnQty, 3);
                    txtRemarks.Text = oFGTN.Remark;

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

        #region Search Events
        private void txtJob_ID_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJob_ID.Tag = lstResult[0];
                txtProdJob_ID.Text = lstResult[0];

                txtFGItem.Tag = lstResult[2];
                txtFGItem.Text = lstResult[3];

                txtFG_QtyUoM.Tag = lstResult[8];
                txtFG_QtyUoM.Text = lstResult[4];

                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(lstResult[0]);
                if (oJob != null)
                {
                    txtFG_WeiUoM.Tag = oJob.Item_Weight_UoM_ID;
                    txtFG_WeiUoM.Text = clsGenaralName.getName_UomAndCode(oJob.Item_Weight_UoM_ID);
                    txtSoQty.Text = cls_Formater.FormatDecimal(oJob.FGoodWeight, clsConfig.sDecimalPlaces_Weight);
                }


                decimal dCustomerOrder_Qty = clsHelpMethods_Prod.GetItemQtyInCustomerOrder_FromJob(lstResult[0]);
                txtSoQty.Text = cls_Formater.FormatDecimal(decimal.Parse(lstResult[6]) * dCustomerOrder_Qty, 3);
                txtPreviouslyIssuedQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyIssuedQty_formFGTNs(lstResult[0]), 3);
            }
        }

        private void txtFGItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJob_ID.Tag = lstResult[0];
                txtProdJob_ID.Text = lstResult[0];

                txtFGItem.Tag = lstResult[2];
                txtFGItem.Text = lstResult[3];

                txtFG_QtyUoM.Text = lstResult[4];

                txtSoQty.Text = cls_Formater.FormatDecimal(decimal.Parse(lstResult[6]), 3);
            }
        }

        private void txtFromStore_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

        private void txtToStore_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
        #endregion

        private void SEACC_Form_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }
}
