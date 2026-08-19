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
    public partial class UC_SubContract_In : UserControl
    {
        #region Class Variables
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_SubContract_In()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_SubContract_In;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Meterial 
            dtMeterials.Columns.Add("LineNo");
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemDescription");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("Consumption");
            dtMeterials.Columns.Add("TotalIsuuedQty");
            dtMeterials.Columns.Add("RetrnedQty");
            dtMeterials.Columns.Add("Remark");
            dtMeterials.Columns.Add("ContractorStore_Qty");
            #endregion

            #region Main 
            dgr_Main.dt.Columns.Add("LineNo");
            dgr_Main.dt.Columns.Add("SON_NO");
            dgr_Main.dt.Columns.Add("SON_DATE");
            dgr_Main.dt.Columns.Add("CONTRACTOR");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("PREPARED_DATE");
            dgr_Main.dt.Columns.Add("MODIFIED_BY");
            dgr_Main.dt.Columns.Add("MODIFIED_DATE");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_DATE");
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LineNo", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Sub IN NO", "SON_NO", 80);
            dgr_Main.Add_DatagridColoumn("Sub IN DATE", "SON_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Contractor", "CONTRACTOR", 150);
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
                string sSub_IN_ID = "";
                try
                {
                    decimal dSubQty = clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text);

                    tbl_genSupplierMaster oContractor = tbl_genSupplierMaster.Select(txtSupplier.Tag.ToString());
                    if (oContractor != null && oContractor.Store_ID != "default")
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prodTxSubContractInNote oOld_SIN = tbl_prodTxSubContractInNote.Select(txtSubInID.Tag.ToString());
                                if (oOld_SIN != null)
                                {
                                    tbl_genSupplierMaster oOldContractor = tbl_genSupplierMaster.Select(oOld_SIN.Supplier_ID);
                                    if (oOldContractor.Store_ID != "default")
                                    {

                                        if (!oOld_SIN.IsApproved && !oOld_SIN.IsCanceled)
                                        {
                                            decimal dSIn_Unitcost = clsValidation.Validate_DecimalNumber(txtSupplierRate.Text) + Get_SubIn_Item_Cost(txtSemiItem.Tag.ToString(), txtProdBatchID.Tag.ToString());
                                            decimal dSIn_Qty = clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text);

                                            tbl_prodTxSubContractInNote oSIN = new tbl_prodTxSubContractInNote(txtSubInID.Tag.ToString(), dtpSIN_Date.GetDateTime(),
                                                txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                                txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                                txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                                clsValidation.Validate_DecimalNumber(txtSupplierRate.Text),
                                                txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                                txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                                txtFG_Description.Tag != null ? txtFG_Description.Tag.ToString() : "default",
                                                txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                                txtSemiItemUoM.Tag != null ? txtSemiItemUoM.Tag.ToString() : "default",
                                                dSIn_Qty, dSIn_Unitcost, 0, (dSIn_Qty * dSIn_Unitcost), oOld_SIN.Remark,
                                                oOld_SIN.IsChecked, oOld_SIN.IsApproved, oOld_SIN.IsCanceled,
                                                oOld_SIN.CreateUser_ID, clsSecurity.UserIDLoged, oOld_SIN.CheckedUser_ID, oOld_SIN.ApprovedUser_ID, oOld_SIN.CanceldUser_ID,
                                                oOld_SIN.DateCreate, clsSecurity.getServerDateTime(), oOld_SIN.DateChecked, oOld_SIN.DateApproved, oOld_SIN.DateCanceled,
                                                oOld_SIN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOld_SIN.CheckedUserTerminal_ID, oOld_SIN.ApprovedUserTerminal_ID, oOld_SIN.CanceledUserTerminal_ID,
                                                oOld_SIN.CompanyID, oOld_SIN.CompanyBranchID
                                                );
                                            oSIN.Update();

                                            foreach (DataRow dr in SemiItem_MaterialConsumption(oOld_SIN.ProdBatch_ID, oOld_SIN.SemiFG_item_ID, oOld_SIN.SubIn_Qty).Rows)
                                            {
                                                string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                                                decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);
                                                clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, sItem_ID, dQty);
                                            }
                                            tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.DeleteAllBySubIn_ID(oOld_SIN.SubIn_ID);

                                            clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oOld_SIN.SemiFG_item_ID, (clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text) - oOld_SIN.SubIn_Qty));
                                            foreach (tbl_prodTxSubContractInNote_Material oMat in tbl_prodTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIN.SubIn_ID))
                                            {
                                                clsHelpMethods_Prod.UpdateSectionFloorStock(oOld_SIN.Return_Section_ID, oMat.Item_ID, -oMat.Returned_Qty);
                                                clsHelpMethods_Prod.UpdateStock(oOldContractor.Store_ID, oMat.Item_ID, oMat.Returned_Qty);
                                                oMat.Delete();
                                            }

                                            int iLn = 0;
                                            foreach (DataRow dr in SemiItem_MaterialConsumption(txtProdBatchID.Tag.ToString(), txtSemiItem.Tag.ToString(), dSubQty).Rows)
                                            {
                                                string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                                                decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);

                                                tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF oConsumed_Item = new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(
                                                    ++iLn, txtSubInID.Tag.ToString(), txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                                    sItem_ID, clsGenaralName.getName_ItemUOMID(sItem_ID), 0, 0, dQty, 0, 0, 0
                                                    );
                                                oConsumed_Item.Insert();
                                                clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, sItem_ID, -dQty);
                                            }
                                            SIn_Insert_ReturnMaterials();

                                            clsHelpMethods_Prod.Update_ItemFinanceCosts(txtSemiItem.Tag.ToString(), dSIn_Unitcost, dSIn_Qty, oOld_SIN.SubIn_Qty);
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                        }
                                        else
                                        {
                                            if (oOld_SIN.IsApproved)
                                                SEACCMessageBox.Show("Cannot Update..", "Selected Sub-In has been approved", MessageBoxButton.OK, "Red");
                                            else if (oOld_SIN.IsCanceled)
                                                SEACCMessageBox.Show("Cannot Update..", "Selected Sub-In has been cancelled", MessageBoxButton.OK, "Red");
                                            else
                                                SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                        }
                                    }
                                    sSub_IN_ID = oOld_SIN.SubIn_ID;
                                }
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                decimal dSIn_Unitcost = clsValidation.Validate_DecimalNumber(txtSupplierRate.Text) + Get_SubIn_Item_Cost(txtSemiItem.Tag.ToString(), txtProdBatchID.Tag.ToString());
                                decimal dSIn_Qty = clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text);

                                tbl_prodTxSubContractInNote oSIN = new tbl_prodTxSubContractInNote(txtSubInID.Tag.ToString(), dtpSIN_Date.GetDateTime(),
                                        txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                        txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                        txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                        decimal.Parse(txtSupplierRate.Text),
                                        txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                        txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                        txtFG_Description.Tag != null ? txtFG_Description.Tag.ToString() : "default",
                                        txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                        txtSemiItemUoM.Tag != null ? txtSemiItemUoM.Tag.ToString() : "default",
                                        dSIn_Qty, dSIn_Unitcost, 0, (dSIn_Qty * dSIn_Unitcost), ""/*Remark*/,
                                        false, false, false,
                                        clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                        clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                        clsSecurity.TerminalID, "default", "default", "default", "default",
                                        clsSecurity.CompanyID, clsSecurity.BranchID
                                        );
                                oSIN.Insert();

                                clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), (txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default"), (clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text)));
                                int iLn = 0;
                                foreach (DataRow dr in SemiItem_MaterialConsumption(txtProdBatchID.Tag.ToString(), txtSemiItem.Tag.ToString(), dSubQty).Rows)
                                {
                                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                                    decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);

                                    tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF oConsumed_Item = new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(
                                        ++iLn, txtSubInID.Tag.ToString(), txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                        sItem_ID, clsGenaralName.getName_ItemUOMID(sItem_ID), 0, 0, dQty, 0, 0, 0
                                        );
                                    oConsumed_Item.Insert();
                                    clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, sItem_ID, -dQty);
                                }

                                SIn_Insert_ReturnMaterials();

                                clsHelpMethods_Prod.Update_ItemFinanceCosts(txtSemiItem.Tag.ToString(), dSIn_Unitcost, dSIn_Qty, 0);

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

                                sSub_IN_ID = oSIN.SubIn_ID;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        SEACCMessageBox.Show("No Sub Contractor Location..!", "Please select valid sub contractor...", MessageBoxButton.OK, "Red");
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
                    FillDetails(sSub_IN_ID);
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
                if (CheckValidity_EmptyField())
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        tbl_prodTxSubContractInNote oSIN = tbl_prodTxSubContractInNote.Select(txtSubInID.Tag.ToString());
                        if (oSIN != null)
                        {
                            if (!oSIN.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        oSIN.IsApproved = true;
                                        oSIN.DateApproved = clsSecurity.getServerDateTime();
                                        oSIN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                        oSIN.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                        oSIN.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    }
                                    frmTwoStepVerify.Close();
                                }
                                ClearFields();
                                RefreshGrid();
                                FillDetails(oSIN.SubIn_ID);
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
                    if (CheckValidity_EmptyField())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxSubContractInNote oSIn = tbl_prodTxSubContractInNote.Select(txtSubInID.Tag.ToString());
                            if (oSIn != null)
                            {
                                if (!oSIn.IsApproved)
                                {
                                    if (!oSIn.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oSIn.IsCanceled = true;
                                                oSIn.DateCanceled = clsSecurity.getServerDateTime();
                                                oSIn.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oSIn.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oSIn.Update();

                                                if (txtSupplier.Tag != null && txtSupplier.Tag.ToString() != "default")
                                                {
                                                    tbl_genSupplierMaster oContractor = tbl_genSupplierMaster.Select(txtSupplier.Tag.ToString());
                                                    if (oContractor != null && oContractor.Store_ID != "default")
                                                    {
                                                        foreach (DataRow dr in SemiItem_MaterialConsumption(oSIn.ProdBatch_ID, oSIn.SemiFG_item_ID, oSIn.SubIn_Qty).Rows)
                                                        {
                                                            string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                                                            decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);
                                                            clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, sItem_ID, dQty);
                                                        }

                                                        foreach (tbl_prodTxSubContractInNote_Material oMat in tbl_prodTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIn.SubIn_ID))
                                                        {
                                                            clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oMat.Item_ID, -oMat.Returned_Qty);
                                                            clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, oMat.Item_ID, oMat.Returned_Qty);
                                                        }
                                                    }
                                                }
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

        #region Grid Buttons
        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Meterial.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_Meterial.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtMeterials.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtMeterials.Rows.Remove(item);
                }
                Common.clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
            }


        }

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSection.Tag != null && txtProdJobID.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials, true);
                RowDataSearch.RowSelected += RowDataSearch_RowSelected; ;
            }
            else
            {
                if (txtSection.Tag == null)
                    SEACCMessageBox.Show("Production Section Can not be Empty", "Please select a Production Section before adding items", MessageBoxButton.OK, "Red");
                else if (txtProdJobID.Tag == null)
                    SEACCMessageBox.Show("BoM Can not be Empty", "Please select a BoM before adding items", MessageBoxButton.OK, "Red");
            }
        }
        #endregion

        #endregion

        #region Clear Field
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSubInID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartmet, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSupplier, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdBatchID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_Description, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFG_SalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSemiItem, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSemiItemUoM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSemiItemQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSF_PrevIssuedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSupplierRate, true, true, false);

            #region Collapsed In UI
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFG, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtBalance, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtDamaged, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtExcessed, true, true, false);
            #endregion

            txtSubInID.Tag = null;
            txtSupplier.Tag = null;
            txtProdJobID.Tag = null;
            txtProdBatchID.Tag = null;
            txtFG_Description.Tag = null;
            txtFG_SalesName.Tag = null;
            txtSemiItem.Tag = null;
            txtDepartmet.Tag = null;
            txtSection.Tag = null;
            txtSemiItemUoM.Tag = null;
            txtFG.Tag = null;

            txtFG_SalesName.ToolTip = null;

            txtSubInID.Text = "";
            txtSupplier.Text = "";
            txtProdJobID.Text = "";
            txtProdBatchID.Text = "";
            txtFG_Description.Text = "";
            txtFG_SalesName.Text = "";
            txtSemiItem.Text = "";
            txtDepartmet.Text = "";
            txtSection.Text = "";
            txtSemiItemUoM.Text = "";
            txtSF_PrevIssuedQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtSemiItemQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtSupplierRate.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            txtBalance.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtDamaged.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtExcessed.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtFG.Tag = "";

            dtpSIN_Date.SetTime(clsSecurity.getServerDateTime());

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSubInID.setReadOnlyStatus(true);
                txtSubInID.Text = "<Auto Generate>";
            }
            else
                txtSubInID.setReadOnlyStatus(false);
            #endregion

            dtMeterials.Clear();
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;

            if (clsSecurity.UserIDLoged != "digiteq")
                btnDataPatch.Visibility = Visibility.Hidden;

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                //int iCount = 0;
                //foreach (tbl_prodTxSubContractInNote oSubIn in tbl_prodTxSubContractInNote.SelectAll().Where(p => p.SubIn_ID != "default").OrderByDescending(o => o.DateCreate))
                //{
                //    dgr_Main.dt.Rows.Add(++iCount, oSubIn.SubIn_ID, oSubIn.SubIn_Date.ToString(clsValidation.Format_Date),
                //        clsGenaralName.getName_Supplier(oSubIn.Supplier_ID),
                //        clsGenaralName.getName_User(oSubIn.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oSubIn.DateCreate),
                //        clsGenaralName.getName_User(oSubIn.ModifiedUser_ID), clsHelpMethods_Prod.Format_DateTime(oSubIn.DateModified),
                //        clsGenaralName.getName_User(oSubIn.ApprovedUser_ID), clsHelpMethods_Prod.Format_DateTime(oSubIn.DateApproved),
                //        oSubIn.IsCanceled);
                //}
                dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_SubInDetails").Tables[0]);
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
                if (CheckFloorStock())
                {
                    if (CheckValidity_DuplicateFiled())
                    {
                        if (CheckValidity_SubInQty())
                        {
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtSubInID.Text))
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

            if (!clsValidation.Validate_EmptyValue(txtSubInID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDepartmet))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSection))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSupplier))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdBatchID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSemiItem))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSemiItemQty))
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
                    txtSubInID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtSubInID.Text = txtSubInID.Tag.ToString();
                }

                tbl_prodTxSubContractInNote oSubOUT = tbl_prodTxSubContractInNote.Select(txtSubInID.Text);
                if (oSubOUT != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool CheckValidity_SubInQty()
        {
            bool bStatus = true;
            try
            {
                decimal dQty = decimal.Parse(txtSemiItemQty.Text);
                if (dQty < 0)
                    bStatus = false;

            }
            catch (Exception ex)
            {
                bStatus = false;
            }

            if (!bStatus)
                SEACCMessageBox.Show("Sub In Qty is not Valid..!", "Please enter correct quantity....", MessageBoxButton.OK, "Red");

            return bStatus;

        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            try
            {
                decimal dSubQty = clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text);
                tbl_genSupplierMaster oContractor = tbl_genSupplierMaster.Select(txtSupplier.Tag.ToString());
                if (oContractor != null)
                {
                    DataTable dtFloorStock = new DataTable();
                    dtFloorStock = clsHelpMethods_Prod.Get_ItemGroupedItemFloorstockTable(
                        SemiItem_MaterialConsumption(txtProdBatchID.Tag.ToString(), txtSemiItem.Tag.ToString(), dSubQty),
                        "Qty", oContractor.Store_ID);

                    foreach (DataRow dr_Return in dtMeterials.Rows)
                    {
                        string sItem_ID = clsValidate.ValidateRowValue(dr_Return, "ItemNo", "default");
                        DataRow dr = dtFloorStock.Select("Item_ID = '" + sItem_ID + "'").FirstOrDefault();
                        dr["Qty"] = cls_Formater.FormatDecimal(
                            clsValidation.Validate_DecimalNumber(dr["Qty"].ToString())
                            + clsValidation.Validate_DecimalNumber(dr_Return["RetrnedQty"].ToString()),
                            clsConfig.sDecimalPlaces_Quantity);
                    }

                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (txtSubInID.Tag != null)
                        {
                            tbl_prodTxSubContractInNote oOld_SIN = tbl_prodTxSubContractInNote.Select(txtSubInID.Tag.ToString());
                            if (oOld_SIN != null)
                            {
                                DataTable dtOld_RecordQtities = SemiItem_MaterialConsumption(txtProdBatchID.Tag.ToString(), txtSemiItem.Tag.ToString(), oOld_SIN.SubIn_Qty);
                                foreach (DataRow dr in dtFloorStock.Rows)
                                {
                                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                                    var drs = dtOld_RecordQtities.Select("Item_ID = '" + sItem_ID + "'");
                                    decimal dTot_OldQty = 0;
                                    if (drs.Length > 0)
                                    {
                                        dTot_OldQty = drs.Sum(x => clsValidation.Validate_DecimalNumber(x.Field<string>("Qty")));
                                    }

                                    foreach (tbl_prodTxSubContractInNote_Material oMat in tbl_prodTxSubContractInNote_Material.SelectAllByItem_ID(sItem_ID).Where(r => r.SubIn_ID == oOld_SIN.SubIn_ID))
                                    {
                                        dTot_OldQty += oMat.Returned_Qty;
                                    }

                                    dr["IssuedQty"] = cls_Formater.FormatDecimal(dTot_OldQty, clsConfig.sDecimalPlaces_Quantity);
                                }
                            }
                        }
                    }

                    bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);
                }
            }
            catch (Exception e)
            {
                SEACCExeption.Show(e);
                bReturn = false;
            }

            return bReturn;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_prodTxSubContractInNote oSIN = tbl_prodTxSubContractInNote.Select(sID);
                if (oSIN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSubInID.Tag = oSIN.SubIn_ID;
                    txtSupplier.Tag = oSIN.Supplier_ID;
                    txtProdJobID.Tag = oSIN.ProdJob_ID;
                    txtProdBatchID.Tag = oSIN.ProdBatch_ID;
                    txtFG_Description.Tag = oSIN.FG_Item_ID;
                    txtFG_SalesName.Tag = oSIN.FG_Item_ID;
                    txtDepartmet.Tag = oSIN.Return_Dept_ID;
                    txtSection.Tag = oSIN.Return_Section_ID;
                    txtSemiItem.Tag = oSIN.SemiFG_item_ID;
                    txtSemiItemUoM.Tag = oSIN.Uom_ID;

                    dtpSIN_Date.SetTime(oSIN.SubIn_Date);

                    txtFG_SalesName.ToolTip = oSIN.FG_Item_ID;

                    txtSubInID.Text = oSIN.SubIn_ID;
                    txtSupplier.Text = clsGenaralName.getName_Supplier(oSIN.Supplier_ID);
                    txtProdJobID.Text = oSIN.ProdJob_ID;
                    txtProdBatchID.Text = oSIN.ProdBatch_ID;
                    txtFG_Description.Text = clsGenaralName.getDescription_Item(oSIN.FG_Item_ID);
                    txtFG_SalesName.Text = clsGenaralName.getName_Item(oSIN.FG_Item_ID);
                    txtDepartmet.Text = clsGenaralName.getName_Department(oSIN.Return_Dept_ID);
                    txtSection.Text = clsGenaralName.getName_Section(oSIN.Return_Section_ID);
                    txtSemiItem.Text = clsGenaralName.getName_Item(oSIN.SemiFG_item_ID);
                    txtSemiItemUoM.Text = clsGenaralName.getName_UomAndCode(oSIN.Uom_ID);
                    txtSupplierRate.Text = cls_Formater.FormatDecimal(oSIN.Supplier_Rate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                    txtSemiItemQty.Text = cls_Formater.FormatDecimal(oSIN.SubIn_Qty, clsConfig.sDecimalPlaces_Quantity);
                    txtBalance.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    txtDamaged.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    txtExcessed.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);

                    if (oSIN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oSIN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    dtMeterials.Rows.Clear();
                    foreach (tbl_prodTxSubContractInNote_Material oSIN_Meterial in tbl_prodTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIN.SubIn_ID))
                    {
                        decimal dConsumption = 0;
                        tbl_prodTxBatch_Material oProd_Material = tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(oSIN.ProdBatch_ID).Where(r => r.Item_ID == oSIN_Meterial.Item_ID).FirstOrDefault();
                        if (oProd_Material != null)
                            dConsumption += oProd_Material.InputQty; //Consuption

                        dtMeterials.Rows.Add("0",
                            oSIN_Meterial.Item_ID,
                            clsGenaralName.getName_Item(oSIN_Meterial.Item_ID),
                            oSIN_Meterial.Uom_ID,
                            clsGenaralName.getName_Uom(oSIN_Meterial.Uom_ID),
                            cls_Formater.FormatDecimal(dConsumption, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSIN_Meterial.Total_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSIN_Meterial.Returned_Qty, clsConfig.sDecimalPlaces_Quantity),
                            oSIN_Meterial.Remark,
                            cls_Formater.FormatDecimal(oSIN_Meterial.ContractorStore_Qty, clsConfig.sDecimalPlaces_Quantity)
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_RawMeterialGrid_FromSemiFinishedItem(string sJobID, string sBatch_ID, string sSemiItemID)
        {
            dtMeterials.Rows.Clear();

            if (txtSupplier.Tag != null)
            {
                tbl_genSupplierMaster oContractor = tbl_genSupplierMaster.Select(txtSupplier.Tag.ToString());
                if (oContractor != null && oContractor.Supplier_ID != "default")
                {
                    //Semi finished and Raw meterials are saved in same meterial table
                    tbl_prodTxBatch_Material oMeterail = tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID).Where(r => r.Item_ID == sSemiItemID).FirstOrDefault();
                    if (oMeterail != null)
                    {
                        foreach (tbl_prodTxBatch_Material oMaterils_forSemi in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID).Where(r => r.Line_No == oMeterail.Line_No && r.Line_No_Sub1 != 0))
                        {
                            dtMeterials.Rows.Add("0",
                                oMaterils_forSemi.Item_ID,
                                clsGenaralName.getName_Item(oMaterils_forSemi.Item_ID),
                                oMaterils_forSemi.Uom_ID,
                                clsGenaralName.getName_Uom(oMaterils_forSemi.Uom_ID),
                                cls_Formater.FormatDecimal(oMaterils_forSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(Get_TotalIssuedQty_Material(oMaterils_forSemi.ProdJob_ID, oMaterils_forSemi.Item_ID),
                                clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                "", cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_StoreStockBalance_Qty(oContractor.Store_ID, oMaterils_forSemi.Item_ID, "default", "default", "default", "0", "0"), clsConfig.sDecimalPlaces_Quantity)
                                );
                        }
                    }

                    //WIP SF Outsourcing
                    //foreach (tbl_prodTxJobCard_WIPFlow oWipSF in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.IsSubOut))
                    //{
                    //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                    //    if (oItem != null)
                    //    {
                    //        dtMeterials.Rows.Add("0",
                    //             oWipSF.Item_ID,
                    //             clsGenaralName.getName_Item(oWipSF.Item_ID),
                    //             oWipSF.Uom_ID,
                    //             clsGenaralName.getName_Uom(oWipSF.Uom_ID),
                    //             cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                    //             cls_Formater.FormatDecimal(Get_TotalIssuedQty_Material(oWipSF.ProdJob_ID, oWipSF.Item_ID), clsConfig.sDecimalPlaces_Quantity),
                    //             cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                    //             "", cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_StoreStockBalance_Qty(oContractor.Store_ID, oItem.Item_ID, "default", "default", "default", "0", "0"), clsConfig.sDecimalPlaces_Quantity)
                    //             );
                    //    }
                    //}
                    var vDr_WIP_SF_Items = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Text);
                    if (vDr_WIP_SF_Items.Count() == 1)
                    {
                        //WIP SF Outsourcing
                        foreach (tbl_prodTxJobCard_WIPFlow oWipSF in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.InSectionID == txtSection.Tag.ToString() && r.IsSubOut))
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                            if (oItem != null)
                            {
                                dtMeterials.Rows.Add("0",
                                     oWipSF.Item_ID,
                                     clsGenaralName.getName_Item(oWipSF.Item_ID),
                                     oWipSF.Uom_ID,
                                     clsGenaralName.getName_Uom(oWipSF.Uom_ID),
                                     cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                     cls_Formater.FormatDecimal(Get_TotalIssuedQty_Material(oWipSF.ProdJob_ID, oWipSF.Item_ID), clsConfig.sDecimalPlaces_Quantity),
                                     cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                     "", cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_StoreStockBalance_Qty(oContractor.Store_ID, oItem.Item_ID, "default", "default", "default", "0", "0"), clsConfig.sDecimalPlaces_Quantity)
                                     );
                            }
                        }
                    }
                    else if (vDr_WIP_SF_Items.Count() > 1)
                    {
                        //WIP SF Outsourcing
                        tbl_prodTxJobCard_SubIn_SFG oSubInSFG = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.SubIn_item_ID == txtSemiItem.Tag.ToString()).FirstOrDefault();
                        if (oSubInSFG != null)
                        {
                            foreach (tbl_prodTxJobCard_SubIn_SFG_Material oSubInSFG_Material in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID_Line_no(oSubInSFG.ProdJob_ID, oSubInSFG.Line_no).Where(r => !r.IsSubOutRawMaterial && r.IsSelect))
                            {
                                tbl_prodTxJobCard_WIPFlow oWipSF = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.Item_ID == oSubInSFG_Material.Item_ID).FirstOrDefault();
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                                if (oItem != null)
                                {
                                    dtMeterials.Rows.Add("0",
                                        oWipSF.Item_ID,
                                        clsGenaralName.getName_Item(oWipSF.Item_ID),
                                        oWipSF.Uom_ID,
                                        clsGenaralName.getName_Uom(oWipSF.Uom_ID),
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(Get_TotalIssuedQty_Material(oWipSF.ProdJob_ID, oWipSF.Item_ID), clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                                        "", cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_StoreStockBalance_Qty(oContractor.Store_ID, oItem.Item_ID, "default", "default", "default", "0", "0"), clsConfig.sDecimalPlaces_Quantity)
                                    );
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Grid Events
        #region Meterial Grid
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Common.clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }

        private void dgr_Meterial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;
            if (sColumnName == "RetrnedQty")
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row["IS_CANCELLED"].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
                else
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFFFFF");
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
                DataRow[] items = dtMeterials.Select("ItemNo ='" + lstResult[0] + "'");
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
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(lstResult[0]);
                    if (oItem != null)
                    {
                        dtMeterials.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID),
                            cls_Formater.FormatDecimal(Get_TotalIssuedQty_Material(txtProdJobID.Tag.ToString(), oItem.Item_ID), clsConfig.sDecimalPlaces_Quantity),
                            "0.000", "");
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtDepartmet_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionDepartment);
            if (RowDataSearch.DialogResult == true)
            {
                txtDepartmet.Tag = lstResult[0];
                txtDepartmet.Text = lstResult[1];
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Tag = lstResult[0];
                txtSection.Text = lstResult[1];
            }
        }

        private void txtContractor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionContractor);
            if (RowDataSearch.DialogResult == true)
            {
                txtSupplier.Tag = lstResult[0];
                txtSupplier.Text = lstResult[1];
            }
        }

        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs_Locked);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobID.Tag = lstResult[0];
                txtFG_Description.Tag = lstResult[2];
                txtFG_SalesName.Tag = lstResult[2];
                txtProdBatchID.Tag = null;
                txtSemiItem.Tag = null;
                txtSemiItemUoM.Tag = null;

                txtFG_SalesName.ToolTip = lstResult[2];

                txtProdJobID.Text = lstResult[0];
                txtFG_Description.Text = clsGenaralName.getDescription_Item(lstResult[2]);
                txtFG_SalesName.Text = clsGenaralName.getName_Item(lstResult[2]);
                txtProdBatchID.Text = "";
                txtSemiItem.Text = "";
                txtSemiItemUoM.Text = "";
                txtSemiItemQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);

                dtMeterials.Rows.Clear();
            }
        }

        private void txtBatchID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobID.Tag != null)
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtProdJobID.Tag.ToString());

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_Batch);
                if (RowDataSearch.DialogResult == true)
                {
                    txtProdBatchID.Tag = lstResult[0];
                    txtProdBatchID.Text = lstResult[0];
                }
            }
            else
            {
                SEACCMessageBox.Show("BoM not selected...", "Please select a BoM...", MessageBoxButton.OK, "Red");
            }
        }

        private void txtSemiItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobID.Tag != null && txtProdJobID.Text != "" && txtProdBatchID.Tag != null && txtProdBatchID.Text != "")
            {
                List<string> lstParameeters = new List<string>();
                lstParameeters.Add(txtProdJobID.Tag.ToString());

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionSubBoMs);
                if (RowDataSearch.DialogResult == true)
                {
                    txtSemiItem.Tag = lstResult[1];
                    txtSemiItemUoM.Tag = lstResult[3];

                    txtSemiItem.Text = lstResult[2];
                    txtSemiItemUoM.Text = lstResult[4] + " - " + lstResult[5];
                    txtSF_PrevIssuedQty.Text = cls_Formater.FormatDecimal(Get_TotalIssuedQty_SemiFinished(txtProdJobID.Tag.ToString(), lstResult[1]), clsConfig.sDecimalPlaces_Quantity);
                    txtSemiItemQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);

                    if (txtSupplier.Tag != null)
                    {
                        tbl_genItemMaster_Outsorce oItemOutSource = tbl_genItemMaster_Outsorce.Select(lstResult[1], txtSupplier.Tag.ToString());
                        if (oItemOutSource != null)
                            txtSupplierRate.Text = cls_Formater.FormatDecimal(oItemOutSource.Outsource_Rate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                    }

                    Fill_RawMeterialGrid_FromSemiFinishedItem(lstResult[0], txtProdBatchID.Tag.ToString(), lstResult[1]);
                }
            }
            else
                SEACCMessageBox.Show("Production Job can not be Empty", "Please select a Job before selecting semi finished item", MessageBoxButton.OK, "Red");

        }
        #endregion

        #region Key Events
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

        #region Other Textbox Events
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
        private void SIn_Insert_ReturnMaterials()
        {
            if (txtSupplier.Tag != null && txtSupplier.Tag.ToString() != "default")
            {
                tbl_genSupplierMaster oContractor = tbl_genSupplierMaster.Select(txtSupplier.Tag.ToString());
                if (oContractor != null && oContractor.Store_ID != "default")
                {
                    foreach (DataRow row in dtMeterials.Rows)
                    {
                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                        string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                        decimal dTotalIsuuedQty = clsValidate.ValidateRowValue(row, "TotalIsuuedQty", 0m);
                        decimal dRetrnedQty = clsValidate.ValidateRowValue(row, "RetrnedQty", 0m);
                        string sRemark = clsValidate.ValidateRowValue(row, "Remark", "");
                        decimal dContractorStore_Qty = clsValidate.ValidateRowValue(row, "ContractorStore_Qty", 0m);

                        decimal dUnitPrice = 0;
                        decimal dTotalAmount = 0;
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemNo);
                        tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItemNo);
                        if (oItem_Finance != null)
                        {
                            dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                            dTotalAmount = dUnitPrice * dRetrnedQty;
                        }

                        tbl_prodTxSubContractInNote_Material oPGIN_Materials = new tbl_prodTxSubContractInNote_Material(iLine_no, txtSubInID.Text, sItemNo, sUoM_ID, dTotalIsuuedQty, dRetrnedQty, 0, dUnitPrice, 0, dTotalAmount, sRemark, dContractorStore_Qty);
                        oPGIN_Materials.Insert();

                        clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), sItemNo, dRetrnedQty);
                        clsHelpMethods_Prod.UpdateStock(oContractor.Store_ID, sItemNo, -dRetrnedQty);
                    }
                }
            }
        }

        private DataTable SemiItem_MaterialConsumption(string sBatch_No, string sSemiFinised_ID, decimal dSF_Qty)
        {
            DataTable dt_Mats = new DataTable();
            dt_Mats.Columns.Add("Item_ID");
            dt_Mats.Columns.Add("Qty");

            tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sBatch_No);
            tbl_prodTxBatch_Material oSF_Material = tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.IsSelected && r.Item_ID == sSemiFinised_ID).FirstOrDefault();
            if (oSF_Material != null && oBatch != null)
            {
                decimal dMaterial_Qty = 0;
                decimal dSF_QtyRatio = oSF_Material.TotalInputQty;

                foreach (tbl_prodTxBatch_Material oMateril_forSemi in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.IsSelected && r.Line_No == oSF_Material.Line_No && r.Line_No_Sub1 != 0))
                {
                    decimal dMateril_forSF_Ratio = 0;
                    if (dSF_QtyRatio != 0)
                        dMateril_forSF_Ratio = decimal.Round((oMateril_forSemi.TotalInputQty / dSF_QtyRatio), 3);

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMateril_forSemi.Item_ID);
                    if (oItem != null)
                    {
                        dMaterial_Qty = dMateril_forSF_Ratio * dSF_Qty;
                        dt_Mats.Rows.Add(oItem.Item_ID, dMaterial_Qty);
                    }
                }

                //WIP SF Outsourcing
                //foreach (tbl_prodTxJobCard_WIPFlow oWipSF in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBatch.ProdJob_ID).Where(r => r.IsSubOut))
                //{
                //    decimal dWipSF_forSF_Ratio = 0;
                //    if (dSF_QtyRatio != 0)
                //        dWipSF_forSF_Ratio = decimal.Round((oWipSF.OutQty / dSF_QtyRatio), 3);

                //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                //    decimal d_WIP_SF_Qty = 0;
                //    if (oItem != null)
                //    {
                //        d_WIP_SF_Qty = dWipSF_forSF_Ratio * dSF_Qty;
                //        dt_Mats.Rows.Add(oItem.Item_ID, d_WIP_SF_Qty);
                //    }
                //}
                var vDr_WIP_SF_Items = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Text);
                var vSubInSFG = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Text);

                if ((vSubInSFG == null) || vDr_WIP_SF_Items.Count() == 1)
                {
                    //WIP SF Outsourcing
                    foreach (tbl_prodTxJobCard_WIPFlow oWipSF in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBatch.ProdJob_ID).Where(r => r.IsSubOut))
                    {
                        decimal dWipSF_forSF_Ratio = 0;
                        if (dSF_QtyRatio != 0)
                            dWipSF_forSF_Ratio = decimal.Round((oWipSF.OutQty / dSF_QtyRatio), 3);

                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                        decimal d_WIP_SF_Qty = 0;
                        if (oItem != null)
                        {
                            d_WIP_SF_Qty = dWipSF_forSF_Ratio * dSF_Qty;
                            dt_Mats.Rows.Add(oItem.Item_ID, d_WIP_SF_Qty);
                        }
                    }

                }
                else
                {
                    //WIP SF Outsourcing
                    tbl_prodTxJobCard_SubIn_SFG oSubInSFG = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.SubIn_item_ID == txtSemiItem.Tag.ToString()).FirstOrDefault();
                    if (oSubInSFG != null)
                    {
                        foreach (tbl_prodTxJobCard_SubIn_SFG_Material oSubInSFG_Material in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID_Line_no(oSubInSFG.ProdJob_ID, oSubInSFG.Line_no).Where(r => !r.IsSubOutRawMaterial && r.IsSelect))
                        {
                            tbl_prodTxJobCard_WIPFlow oWipSF = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.Item_ID == oSubInSFG_Material.Item_ID).FirstOrDefault();
                            decimal dWipSF_forSF_Ratio = 0;
                            if (dSF_QtyRatio != 0)
                                dWipSF_forSF_Ratio = decimal.Round((oWipSF.OutQty / dSF_QtyRatio), 3);

                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oWipSF.Item_ID);
                            decimal d_WIP_SF_Qty = 0;
                            if (oItem != null)
                            {
                                d_WIP_SF_Qty = dWipSF_forSF_Ratio * dSF_Qty;
                                dt_Mats.Rows.Add(oItem.Item_ID, d_WIP_SF_Qty);
                            }
                        }
                    }
                }

            }

            return dt_Mats;
        }

        private decimal Get_TotalIssuedQty_Material(string sProdJobBom, string sItemID)
        {
            decimal dIssuedQty = 0;
            foreach (tbl_prodTxSubContractOutNote_Material oSOut_Material in tbl_prodTxSubContractOutNote_Material.SelectAllByProdJob_ID(sProdJobBom).Where(r => r.Item_ID == sItemID))
            {
                tbl_prodTxSubContractOutNote oSOut = tbl_prodTxSubContractOutNote.Select(oSOut_Material.SubOut_ID);
                if (oSOut != null && !oSOut.IsCanceled && !oSOut_Material.IsSemiFG_item)
                    dIssuedQty += oSOut_Material.Son_Qty;
            }
            return dIssuedQty;
        }

        private decimal Get_TotalIssuedQty_SemiFinished(string sProdJobBom, string sSemiFinishedItemID)
        {
            decimal dSFGQty = 0;
            foreach (tbl_prodTxSubContractInNote oSIn in tbl_prodTxSubContractInNote.SelectAllByProdJob_ID(sProdJobBom).Where(r => r.SubIn_ID != txtSubInID.Text && !r.IsCanceled && r.SemiFG_item_ID == sSemiFinishedItemID))
            {
                dSFGQty += oSIn.SubIn_Qty;
            }
            return dSFGQty;
        }

        private decimal Get_SubIn_Item_Cost(string sSubInItem_ID, string sBatch_ID)
        {
            decimal dCost = 0;
            tbl_prodTxBatch_Material oSubIn_Mat = tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID).Where(r => r.Item_ID == sSubInItem_ID && r.IsSelected).FirstOrDefault();

            if (oSubIn_Mat != null)
            {
                decimal dSubIn_MatQty = oSubIn_Mat.TotalInputQty;

                //RowMat Cost
                foreach (tbl_prodTxBatch_Material oMateril_forSemi in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(oSubIn_Mat.ProdBatch_ID).Where(r => r.IsSelected && r.Line_No == oSubIn_Mat.Line_No && r.Line_No_Sub1 != 0))
                {
                    dCost += oMateril_forSemi.EditedCost;
                }

                //WIP SF Cost
                foreach (tbl_prodTxJobCard_WIPFlow oWipSF in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oSubIn_Mat.ProdJob_ID).Where(r => r.InSectionID == txtSection.Tag.ToString() && r.IsSubOut))
                {
                    decimal dSF_Qty = 0;
                    decimal dSF_UnitCost = 0;
                    foreach (tbl_prodTxWorkInProgress oWIP in tbl_prodTxWorkInProgress.SelectAllByProdBatch_ID(oSubIn_Mat.ProdBatch_ID).Where(r => !r.IsCanceled))
                    {
                        foreach (tbl_prodTxWorkInProgress_Material oWIP_Mat in tbl_prodTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Output_Section_ID == oWipSF.InSectionID && r.Item_ID == oWipSF.Item_ID))
                        {
                            dSF_Qty += oWIP_Mat.InputOutput_Qty;
                            dSF_UnitCost += oWIP_Mat.TotalAmount;
                        }
                    }
                    dSF_UnitCost = dSF_Qty != 0 ? (dSF_UnitCost / dSF_Qty) : 0;
                    dCost += (dSF_UnitCost) * (oWipSF.OutQty);
                }

                if (dSubIn_MatQty != 0)
                    dCost = (decimal.Round(dCost / dSubIn_MatQty, 2));
                else
                    dCost = 0;

            }


            return dCost;
        }

        #endregion

        private void btnDataPatch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Cursor = Cursors.Wait;

                foreach (tbl_prodTxSubContractInNote oSubIn in tbl_prodTxSubContractInNote.SelectAll().Where(r => !r.IsCanceled))
                {
                    //tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF oSubMats_consumed = tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.SelectAll().FirstOrDefault(r => r.SubIn_ID == oSubIn.SubIn_ID);
                    //if (oSubMats_consumed != null)
                    //    continue;

                    tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF.DeleteAllBySubIn_ID(oSubIn.SubIn_ID);

                    int iLn = 0;
                    foreach (DataRow dr in SemiItem_MaterialConsumption(oSubIn.ProdBatch_ID, oSubIn.SemiFG_item_ID, oSubIn.SubIn_Qty).Rows)
                    {
                        string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                        decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);

                        tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF oConsumed_Item = new tbl_prodTxSubContractInNote_ConsumedMaterial_ForSF(
                            ++iLn, oSubIn.SubIn_ID, oSubIn.SemiFG_item_ID,
                            sItem_ID, clsGenaralName.getName_ItemUOMID(sItem_ID), 0, 0, dQty, 0, 0, 0
                            );
                        oConsumed_Item.Insert();
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
