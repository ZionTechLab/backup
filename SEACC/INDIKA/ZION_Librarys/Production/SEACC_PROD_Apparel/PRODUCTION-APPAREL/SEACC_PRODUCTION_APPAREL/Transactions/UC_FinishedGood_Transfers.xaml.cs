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
using System.Windows.Media;

namespace SEACC_PRODUCTION_APPAREL.Transactions
{
    /// <summary>
    /// Developped by Gayan
    /// 2017-05-25
    /// </summary>
    public partial class UC_FinishedGood_Transfers : UserControl
    {
        #region Class Variables
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_FinishedGood_Transfers()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_FGTN;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("FGTN_NO");
            dgr_Main.dt.Columns.Add("FGTN_DATE");
            dgr_Main.dt.Columns.Add("ITEM_DESCRIPTION");
            dgr_Main.dt.Columns.Add("QTY");
            dgr_Main.dt.Columns.Add("FROM_STORE");
            dgr_Main.dt.Columns.Add("TO_STORE");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("PREPARED_DATE");
            dgr_Main.dt.Columns.Add("MODIFIED_BY");
            dgr_Main.dt.Columns.Add("MODIFIED_DATE");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_DATE");
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("FGTN #", "FGTN_NO", 80);
            dgr_Main.Add_DatagridColoumn("Date", "FGTN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Item", "ITEM_DESCRIPTION", 150);
            dgr_Main.Add_DatagridColoumn("Qty.", "QTY", 60);
            dgr_Main.Add_DatagridColoumn("From Store", "FROM_STORE", 100);
            dgr_Main.Add_DatagridColoumn("To Store", "TO_STORE", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "PREPARED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "MODIFIED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "MODIFIED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved Date", "APPROVED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
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
                                        decimal dunit_Cost = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_ID, ref dAlreadyBatchQty, ref dAlreadyTotalCost);
                                        decimal dCurrentFGTN_Qty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);
                                        
                                        clsHelpMethods_Prod.UpdateStock(oOldFGTN.From_Store_ID, oOldFGTN.Item_ID_FG, oOldFGTN.FgtnQty);

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
                                decimal dunit_Cost = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_ID, ref dAlreadyBatchQty, ref dAlreadyTotalCost);
                                decimal dCurrentFGTN_Qty = clsValidation.Validate_DecimalNumber(txtCurrentlyIssuingQty.Text);

                                tbl_prodTxFinishedGoodTransferNote oNewFGTN =
                                    new tbl_prodTxFinishedGoodTransferNote(txtFGTN_ID.Text,
                                        dtpFGTN_Date.GetDateTime(),
                                        txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                        sBatch_ID,
                                        txtFGDescription.Tag != null ? txtFGDescription.Tag.ToString() : "default",
                                        txtFG_UoM.Tag != null ? txtFG_UoM.Tag.ToString() : "default",
                                        decimal.Parse(txtBatchQty.Text),
                                        decimal.Parse(txtPreviouslyIssuedQty.Text),
                                        decimal.Parse(txtCurrentlyIssuingQty.Text), 0,
                                        dunit_Cost,
                                        0,
                                        dunit_Cost * dCurrentFGTN_Qty,
                                        txtFromSection.Tag != null
                                            ? clsHelpMethods_Prod.GetStoreID_FromSectionID(txtFromSection.Tag
                                                .ToString())
                                            : "default",
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
                //int iCount = 0;
                //foreach (tbl_prodTxFinishedGoodTransferNote oFGTN in tbl_prodTxFinishedGoodTransferNote.SelectAll().Where(p => p.Fgtn_ID != "default").OrderByDescending(o => o.DateCreate))
                //{
                //    dgr_Main.dt.Rows.Add(++iCount, oFGTN.Fgtn_ID, oFGTN.Fgtn_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Item(oFGTN.Item_ID_FG), 
                //        cls_Formater.FormatDecimal(oFGTN.FgtnQty, 3), clsGenaralName.getName_Store(oFGTN.From_Store_ID), clsGenaralName.getName_Store(oFGTN.To_Store_ID), 
                //        clsGenaralName.getName_User(oFGTN.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oFGTN.DateCreate),
                //        clsGenaralName.getName_User(oFGTN.ModifiedUser_ID), clsHelpMethods_Prod.Format_DateTime(oFGTN.DateModified),
                //        clsGenaralName.getName_User(oFGTN.ApprovedUser_ID), clsHelpMethods_Prod.Format_DateTime(oFGTN.DateApproved),
                //        oFGTN.IsCanceled);
                //}

                string sQuery = "Exec sp_FGTNDetails";
                dgr_Main.dt.Merge(DBHandling.ExecQuery(sQuery).Tables[0]);
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
                    if (clsValidate.CheckValidity_TransactionCodeLength(txtFGTN_ID.Text))
                    {
                        if (CheckValidity_WATollarance())
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

        private bool CheckValidity_WATollarance()
        {
            //#region Variables
            //DataTable dtGrid = new DataTable();
            //dtGrid.Columns.Add("LineNo");
            //dtGrid.Columns.Add("ItemCode");
            //dtGrid.Columns.Add("Quantity");
            //dtGrid.Columns.Add("UnitPrice");

            //List<tbl_Detail> DB = new List<tbl_Detail>();
            //#endregion

            //#region Copy grid
            //decimal dAlreadyBatchQty = 0;
            //decimal dAlreadyTotalCost = 0;
            //string sBatch_ID = txtBatch_ID.Tag != null ? txtBatch_ID.Tag.ToString() : "default";
            //decimal dunit_Cost = clsHelpMethods_Prod.Get_FG_UnitCost(sBatch_ID, ref dAlreadyBatchQty, ref dAlreadyTotalCost);

            //dtGrid.Rows.Add(0, 
            //    txtFGDescription.Tag != null ? txtFGDescription.Tag.ToString() : "default", 
            //    decimal.Parse(txtCurrentlyIssuingQty.Text),
            //    dunit_Cost);
            //#endregion

            //#region Copy Saved value
            //tbl_prodTxFinishedGoodTransferNote oDetail = tbl_prodTxFinishedGoodTransferNote.Select(txtFGTN_ID.Text);
            //if (oDetail != null)
            //{
            //    DB.Add(new tbl_Detail(0, oDetail.Item_ID_FG, oDetail.FgtnQty, oDetail.UnitPrice));
            //}
            //#endregion

            //return clsHelpMethods.CheckValidity_WATollarance(dtGrid, DB);

            return true;
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row["IS_CANCELLED"].ToString()))
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

        private void txtBatch_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJob_ID.Tag != null)
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtProdJob_ID.Tag.ToString());

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_Batch);
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

                        SetLastOutputSection(oBatch.ProdJob_ID, ref txtFromSection);
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void txtFGItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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

                txtFG_UoM.Text = lstResult[4];

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

        #region Key Events
        private void SEACC_Form_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        private void SetLastOutputSection(string sBoM_ID , ref SEACC_LableTextBox txtBox)
        {
            var vLastSection_FG = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.InSectionID == r.OutSectionID).FirstOrDefault();
            if (vLastSection_FG != null)
            {
                txtBox.Text = clsGenaralName.getName_Section(vLastSection_FG.OutSectionID);
                txtBox.Tag = vLastSection_FG.OutSectionID;
            }
        }

    }
}
