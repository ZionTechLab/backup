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

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Interaction logic for UC_FinishedGood_Transfers_Acceptance.xaml
    /// </summary>
    public partial class UC_FinishedGood_Transfers_Acceptance : UserControl
    {
        #region Class Variables
        BrushConverter bcon = new BrushConverter();
        #endregion

        #region Form Load
        public UC_FinishedGood_Transfers_Acceptance()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_FGTN_Acceptance;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("Acpt_No");
            dgr_Main.dt.Columns.Add("Acpt_Date");
            dgr_Main.dt.Columns.Add("Item_Description");
            dgr_Main.dt.Columns.Add("Qty");
            dgr_Main.dt.Columns.Add("Store");
            dgr_Main.dt.Columns.Add("Prepared_By");
            dgr_Main.dt.Columns.Add("Approved_By");
            dgr_Main.dt.Columns.Add("Is_Cancelled");
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
            dgr_Main.Add_DatagridColoumn("Acceptance #", "Acpt_No", 80);
            dgr_Main.Add_DatagridColoumn("Date", "Acpt_Date", 80);
            dgr_Main.Add_DatagridColoumn("Item", "Item_Description", 150);
            dgr_Main.Add_DatagridColoumn("Qty.", "Qty", 60);
            dgr_Main.Add_DatagridColoumn("Store", "Store", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "Prepared_By", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "Approved_By", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "Is_Cancelled", 100, false);
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
                            tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAcceptance = tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oAcceptance != null)
                            {
                                if (!oAcceptance.IsApproved)
                                {
                                    if (!oAcceptance.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oAcceptance.IsCanceled = true;
                                                oAcceptance.DateCanceled = clsSecurity.getServerDateTime();
                                                oAcceptance.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oAcceptance.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                oAcceptance.Update();

                                                clsHelpMethods_Prod.UpdateStock(oAcceptance.To_Store_ID, oAcceptance.Item_ID_FG, -oAcceptance.AcceptanceQty);

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
            string sAcceptance_ID = "";
            if (CheckValidity())
            {
                bool bExecClearFields = true;
                try
                {
                    decimal dPendingQty = clsValidation.Validate_DecimalNumber(txtPendingFGTNQty.Text);
                    decimal dAccptQty = clsValidation.Validate_DecimalNumber(txtAcptQty.Text);
                    decimal dAccepted_Qty = clsValidation.Validate_DecimalNumber(txtAcptQty.Text);
                    decimal dItem_Id_FG_UnitCost = 0;
                    tbl_prod_pharmaTxFinishedGoodTransferNote oFGTN = tbl_prod_pharmaTxFinishedGoodTransferNote.Select(txtFGTN_ID.Text);
                    if (oFGTN != null)
                        dItem_Id_FG_UnitCost = oFGTN.UnitPrice;

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxFinishedGoodTransferAcceptance oOldAcceptance = tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oOldAcceptance != null)
                            {
                                if (dAccptQty < (dPendingQty + oOldAcceptance.AcceptanceQty))
                                {
                                    if (!oOldAcceptance.IsApproved && !oOldAcceptance.IsCanceled)
                                    {
                                        clsHelpMethods_Prod.UpdateStock(oOldAcceptance.To_Store_ID, oOldAcceptance.Item_ID_FG, -oOldAcceptance.AcceptanceQty);

                                        tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAccepatnce = new tbl_prod_pharmaTxFinishedGoodTransferAcceptance(
                                                txtAcceptance_ID.Text, dtpAcpt_Date.GetDateTime(),
                                                txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                                txtBatch_ID.Tag != null ? txtBatch_ID.Tag.ToString() : "default",
                                                txtFGTN_ID.Tag != null ? txtFGTN_ID.Tag.ToString() : "default",
                                                txtFGDescription.Tag != null
                                                    ? txtFGDescription.Tag.ToString()
                                                    : "default",
                                                txtFG_UoM.Tag != null ? txtFG_UoM.Tag.ToString() : "default",
                                                clsValidation.Validate_DecimalNumber(txtFGTNQty.Text),
                                                clsValidation.Validate_DecimalNumber(txtPendingFGTNQty.Text),
                                                dAccepted_Qty,
                                                oOldAcceptance.AcceptanceWeight, dItem_Id_FG_UnitCost,
                                                oOldAcceptance.WeightPrice, (dItem_Id_FG_UnitCost * dAccepted_Qty),
                                                txtFromStore.Tag != null ? (txtFromStore.Tag.ToString()) : "default",
                                                txtToStore.Tag != null ? txtToStore.Tag.ToString() : "default",
                                                txtRemarks.Text,
                                                oOldAcceptance.IsChecked, oOldAcceptance.IsApproved,
                                                oOldAcceptance.IsCanceled,
                                                oOldAcceptance.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oOldAcceptance.CheckedUser_ID, oOldAcceptance.ApprovedUser_ID,
                                                oOldAcceptance.CanceldUser_ID,
                                                oOldAcceptance.DateCreate, clsSecurity.getServerDateTime(),
                                                oOldAcceptance.DateChecked, oOldAcceptance.DateApproved,
                                                oOldAcceptance.DateCanceled,
                                                oOldAcceptance.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                                oOldAcceptance.CheckedUserTerminal_ID,
                                                oOldAcceptance.ApprovedUserTerminal_ID,
                                                oOldAcceptance.CanceledUserTerminal_ID,
                                                oOldAcceptance.CompanyID, oOldAcceptance.CompanyBranchID);
                                        oAccepatnce.Update();

                                        clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), txtFGDescription.Tag.ToString(), clsValidation.Validate_DecimalNumber(txtAcptQty.Text));

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        sAcceptance_ID = oOldAcceptance.Acceptance_ID;
                                    }
                                    else
                                    {
                                        if (oOldAcceptance.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been approved",
                                                MessageBoxButton.OK, "Red");
                                        else if (oOldAcceptance.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected FGTN has been cancelled",
                                                MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity for FGTN Acceptance....", MessageBoxButton.OK, "Red");
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
                            if (dAccptQty <= dPendingQty)
                            {

                                tbl_prod_pharmaTxFinishedGoodTransferAcceptance oNew_FGTN_Accepatance =
                                    new tbl_prod_pharmaTxFinishedGoodTransferAcceptance(
                                        txtAcceptance_ID.Text, dtpAcpt_Date.GetDateTime(),
                                        txtProdJob_ID.Tag != null ? txtProdJob_ID.Tag.ToString() : "default",
                                        txtBatch_ID.Tag != null ? txtBatch_ID.Tag.ToString() : "default",
                                        txtFGTN_ID.Tag != null ? txtFGTN_ID.Tag.ToString() : "default",
                                        txtFGDescription.Tag != null ? txtFGDescription.Tag.ToString() : "default",
                                        txtFG_UoM.Tag != null ? txtFG_UoM.Tag.ToString() : "default",
                                        clsValidation.Validate_DecimalNumber(txtFGTNQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtPendingFGTNQty.Text),
                                        dAccepted_Qty,
                                        0, dItem_Id_FG_UnitCost, 0, dItem_Id_FG_UnitCost * dAccepted_Qty,
                                        txtFromStore.Tag != null ? (txtFromStore.Tag.ToString()) : "default",
                                        txtToStore.Tag != null ? txtToStore.Tag.ToString() : "default",
                                        txtRemarks.Text,
                                        false, false, false,
                                        clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                        clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                        clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                        clsValidation.defaultDateTime,
                                        clsSecurity.TerminalID, "default", "default", "default", "default",
                                        clsSecurity.CompanyID, clsSecurity.BranchID);

                                oNew_FGTN_Accepatance.Insert();

                                clsHelpMethods_Prod.UpdateStock(txtToStore.Tag.ToString(), txtFGDescription.Tag.ToString(), clsValidation.Validate_DecimalNumber(txtAcptQty.Text));

                                sAcceptance_ID = oNew_FGTN_Accepatance.Acceptance_ID;
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity for FGTN Acceptance....", MessageBoxButton.OK, "Red");
                                bExecClearFields = false;
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
                    if (bExecClearFields)
                    {
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sAcceptance_ID);
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
                            tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAccepatance = tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                            if (oAccepatance != null)
                            {
                                if (!oAccepatance.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oAccepatance.IsApproved = true;
                                            oAccepatance.DateApproved = clsSecurity.getServerDateTime();
                                            oAccepatance.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oAccepatance.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oAccepatance.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }

                                    ClearFields();
                                    RefreshGrid();
                                    FillDetails(oAccepatance.Acceptance_ID);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected FGTN Accepatance has already been approved", MessageBoxButton.OK, "Red");
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtAcceptance_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJob_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBatch_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_UoM, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFGTN_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFromStore, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtToStore, false, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFGTNQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPreviousAcptQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPendingFGTNQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAcptQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtAcceptance_ID.Tag = null;
            txtFGTN_ID.Tag = null;
            txtProdJob_ID.Tag = null;
            txtBatch_ID.Tag = null;
            txtFGDescription.Tag = null;
            txtFGSalesName.Tag = null;
            txtFG_UoM.Tag = null;
            txtFromStore.Tag = null;
            txtToStore.Tag = null;

            txtFGSalesName.ToolTip = null;

            txtAcceptance_ID.Text = "";
            txtFGTN_ID.Text = "";
            txtProdJob_ID.Text = "";
            txtBatch_ID.Text = "";
            txtFGDescription.Text = "";
            txtFGSalesName.Text = "";
            txtFG_UoM.Text = "";
            txtFromStore.Text = "";
            txtToStore.Text = "";
            txtFGTNQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtPreviousAcptQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtPendingFGTNQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtAcptQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtRemarks.Text = "";

            dtpAcpt_Date.SetTime(DateTime.Now);

            SEACC_Form.btn_Approved.Background = (Brush)bcon.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bcon.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtAcceptance_ID.setReadOnlyStatus(true);
                txtAcceptance_ID.Text = "<Auto Generate>";
            }
            else
                txtAcceptance_ID.setReadOnlyStatus(false);
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
                foreach (tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAcceptance in tbl_prod_pharmaTxFinishedGoodTransferAcceptance.SelectAll().Where(p => p.Acceptance_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oAcceptance.Acceptance_ID, oAcceptance.Acceptance_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Item(oAcceptance.Item_ID_FG), cls_Formater.FormatDecimal(oAcceptance.AcceptanceQty, clsConfig.sDecimalPlaces_Quantity), clsGenaralName.getName_Store(oAcceptance.To_Store_ID), clsGenaralName.getName_User(oAcceptance.CreateUser_ID), clsGenaralName.getName_User(oAcceptance.ApprovedUser_ID), oAcceptance.IsCanceled);
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
                if (CheckValidity_AcptQty())
                {
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (clsValidate.CheckValidity_TransactionCodeLength(txtAcceptance_ID.Text))
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

            if (!clsValidation.Validate_EmptyValue(txtAcceptance_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJob_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBatch_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFGTN_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAcptQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPreviousAcptQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFGTNQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPendingFGTNQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFromStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtToStore))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_AcptQty()
        {
            bool bStatus = true;
            decimal dAccptQty = clsValidation.Validate_DecimalNumber(txtAcptQty.Text);
            if (dAccptQty < 0)
            {
                SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity for FGTN Acceptance....", MessageBoxButton.OK, "Red");
                bStatus = false;
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
                    txtAcceptance_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtAcceptance_ID.Text = txtAcceptance_ID.Tag.ToString();
                }

                tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAccepatance = tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Select(txtAcceptance_ID.Text);
                if (oAccepatance != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sId)
        {
            try
            {
                tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAcceptance = tbl_prod_pharmaTxFinishedGoodTransferAcceptance.Select(sId);
                if (oAcceptance != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtAcceptance_ID.Tag = oAcceptance.Acceptance_ID;
                    txtFGTN_ID.Tag = oAcceptance.Fgtn_ID;
                    txtProdJob_ID.Tag = oAcceptance.ProdJob_ID;
                    txtBatch_ID.Tag = oAcceptance.ProdBatch_ID;
                    txtFGDescription.Tag = oAcceptance.Item_ID_FG;
                    txtFGSalesName.Tag = oAcceptance.Item_ID_FG;
                    txtFG_UoM.Tag = oAcceptance.Uom_ID;
                    txtFromStore.Tag = oAcceptance.From_Store_ID;
                    txtToStore.Tag = oAcceptance.To_Store_ID;

                    txtFGSalesName.ToolTip = oAcceptance.Item_ID_FG; 

                    txtAcceptance_ID.Text = oAcceptance.Acceptance_ID;
                    txtFGTN_ID.Text = oAcceptance.Fgtn_ID;
                    txtProdJob_ID.Text = oAcceptance.ProdJob_ID;
                    txtBatch_ID.Text = oAcceptance.ProdBatch_ID;
                    txtFGDescription.Text = clsGenaralName.getDescription_Item(oAcceptance.Item_ID_FG);
                    txtFGSalesName.Text = clsGenaralName.getName_Item(oAcceptance.Item_ID_FG);
                    txtFG_UoM.Text = clsGenaralName.getName_UomAndCode(oAcceptance.Uom_ID);
                    txtFromStore.Text = clsGenaralName.getName_Store(oAcceptance.From_Store_ID);
                    txtToStore.Text = clsGenaralName.getName_Store(oAcceptance.To_Store_ID);
                    txtFGTNQty.Text = cls_Formater.FormatDecimal(oAcceptance.FgtnQty, clsConfig.sDecimalPlaces_Quantity);
                    txtPreviousAcptQty.Text = cls_Formater.FormatDecimal(oAcceptance.FgtnQty - oAcceptance.Fgtn_PendigQty, clsConfig.sDecimalPlaces_Quantity);
                    txtPendingFGTNQty.Text = cls_Formater.FormatDecimal(oAcceptance.Fgtn_PendigQty, clsConfig.sDecimalPlaces_Quantity);
                    txtAcptQty.Text = cls_Formater.FormatDecimal(oAcceptance.AcceptanceQty, clsConfig.sDecimalPlaces_Quantity);
                    txtRemarks.Text = oAcceptance.Remark;

                    dtpAcpt_Date.SetTime(DateTime.Now);

                    if (oAcceptance.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bcon.ConvertFrom("#3DFF3D");
                    if (oAcceptance.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bcon.ConvertFrom("#3DFF3D");
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

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[8].ToString()))
                {
                    e.Row.Foreground = (Brush)bcon.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtFGTN_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtProdJob_ID.Tag != null)
            {
                lstParameeters.Add(txtProdJob_ID.Tag.ToString());
                if (txtBatch_ID.Tag != null)
                    lstParameeters.Add(txtBatch_ID.Tag.ToString());
            }

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_FGTN);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();

                txtFGTN_ID.Tag = lstResult[0];
                txtProdJob_ID.Tag = lstResult[1];
                txtBatch_ID.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[3];
                txtFGDescription.Tag = lstResult[3];
                txtFG_UoM.Tag = clsGenaralName.getName_ItemUOMID(lstResult[3]);
                txtFromStore.Tag = lstResult[6];
                txtToStore.Tag = lstResult[7];

                txtFGSalesName.ToolTip = lstResult[3];

                txtFGTN_ID.Text = lstResult[0];
                txtProdJob_ID.Text = lstResult[1];
                txtBatch_ID.Text = lstResult[2];
                txtFGSalesName.Text = lstResult[4];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[3]);
                txtFG_UoM.Text = clsGenaralName.getName_ItemUOM(lstResult[3]);
                txtFromStore.Text = clsGenaralName.getName_Store(lstResult[6]);
                txtToStore.Text = clsGenaralName.getName_Store(lstResult[7]);
                txtFGTNQty.Text = lstResult[5];
                txtPreviousAcptQty.Text = cls_Formater.FormatDecimal(clsHelpMethods_Prod.AlreadyAcceptedQty_fromFGTN_Accepatance(lstResult[2]), clsConfig.sDecimalPlaces_Quantity);
                txtPendingFGTNQty.Text = cls_Formater.FormatDecimal(clsValidation.Validate_DecimalNumber(lstResult[5]) - clsValidation.Validate_DecimalNumber(txtPreviousAcptQty.Text), clsConfig.sDecimalPlaces_Quantity);
                txtAcptQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            }
        }

        private void txtProdJob_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();

                txtProdJob_ID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];
                txtFG_UoM.Tag = lstResult[8];

                txtFGSalesName.ToolTip = lstResult[2];

                txtProdJob_ID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
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
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ClosedBatches);
                if (RowDataSearch.DialogResult == true)
                {
                    txtBatch_ID.Tag = lstResult[0];
                    txtBatch_ID.Text = lstResult[0];
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void txtFGDescription_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();

                txtProdJob_ID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];
                txtFG_UoM.Tag = lstResult[8];

                txtFGSalesName.ToolTip = lstResult[2];

                txtProdJob_ID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
                txtFG_UoM.Text = lstResult[4];

            }
        }

        private void txtFGSalesName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();

                txtProdJob_ID.Tag = lstResult[0];
                txtFGDescription.Tag = lstResult[2];
                txtFGSalesName.Tag = lstResult[2];
                txtFG_UoM.Tag = lstResult[8];

                txtFGSalesName.ToolTip = lstResult[2];

                txtProdJob_ID.Text = lstResult[0];
                txtFGDescription.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFGSalesName.Text = lstResult[3];
                txtFG_UoM.Text = lstResult[4];

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
    }
}
