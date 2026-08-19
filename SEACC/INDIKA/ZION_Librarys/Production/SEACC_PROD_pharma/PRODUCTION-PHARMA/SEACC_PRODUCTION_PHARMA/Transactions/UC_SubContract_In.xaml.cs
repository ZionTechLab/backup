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

namespace SEACC_PRODUCTION_PHARMA.Transactions
{
    /// <summary>
    /// Interaction logic for UC_SubContractOut.xaml
    /// </summary>
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
            SEACC_Form.enmFormName = FormName.ProdPharma_SubContract_In;
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
            #endregion

            #region Main 
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("SON_NO");
            dgr_Main.dt.Columns.Add("SON_DATE");
            dgr_Main.dt.Columns.Add("CONTRACTOR");
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
            dgr_Main.Add_DatagridColoumn("Sub IN NO", "SON_NO", 80);
            dgr_Main.Add_DatagridColoumn("Sub IN DATE", "SON_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Contractor", "CONTRACTOR", 150);
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
            if (CheckValidity())
            {
                string sSub_IN_ID = "";
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxSubContractInNote oOld_SIN = tbl_prod_pharmaTxSubContractInNote.Select(txtSubInID.Tag.ToString());
                            if (oOld_SIN != null)
                            {
                                if (!oOld_SIN.IsApproved && !oOld_SIN.IsCanceled)
                                {
                                    tbl_prod_pharmaTxSubContractInNote oSIN = new tbl_prod_pharmaTxSubContractInNote(txtSubInID.Tag.ToString(), dtpSIN_Date.GetDateTime(),
                                        txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                        txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                        txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                        clsValidation.Validate_DecimalNumber(txtSupplierRate.Text),
                                        txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                        txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                        txtFG_Description.Tag != null ? txtFG_Description.Tag.ToString() : "default",
                                        txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                        txtSemiItemUoM.Tag != null ? txtSemiItemUoM.Tag.ToString() : "default",
                                        clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text), oOld_SIN.Remark,
                                        oOld_SIN.IsChecked, oOld_SIN.IsApproved, oOld_SIN.IsCanceled,
                                        oOld_SIN.CreateUser_ID, clsSecurity.UserIDLoged, oOld_SIN.CheckedUser_ID, oOld_SIN.ApprovedUser_ID, oOld_SIN.CanceldUser_ID,
                                        oOld_SIN.DateCreate, clsSecurity.getServerDateTime(), oOld_SIN.DateChecked, oOld_SIN.DateApproved, oOld_SIN.DateCanceled,
                                        oOld_SIN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOld_SIN.CheckedUserTerminal_ID, oOld_SIN.ApprovedUserTerminal_ID, oOld_SIN.CanceledUserTerminal_ID,
                                        oOld_SIN.CompanyID, oOld_SIN.CompanyBranchID
                                        );
                                    oSIN.Update();

                                    clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oOld_SIN.SemiFG_item_ID, (clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text) - oOld_SIN.SubIn_Qty));

                                    foreach (tbl_prod_pharmaTxSubContractInNote_Material oMat in tbl_prod_pharmaTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIN.SubIn_ID))
                                    {
                                        clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oMat.Item_ID, -oMat.Returned_Qty);
                                        oMat.Delete();
                                    }
                                    SIn_InsertMaterials();

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
                            tbl_prod_pharmaTxSubContractInNote oSIN = new tbl_prod_pharmaTxSubContractInNote(txtSubInID.Tag.ToString(), dtpSIN_Date.GetDateTime(),
                                    txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                    txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                    txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                    decimal.Parse(txtSupplierRate.Text),
                                    txtProdJobID.Tag != null ? txtProdJobID.Tag.ToString() : "default",
                                    txtProdBatchID.Tag != null ? txtProdBatchID.Tag.ToString() : "default",
                                    txtFG_Description.Tag != null ? txtFG_Description.Tag.ToString() : "default",
                                    txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default",
                                    txtSemiItemUoM.Tag != null ? txtSemiItemUoM.Tag.ToString() : "default",
                                    decimal.Parse(txtSemiItemQty.Text), ""/*Remark*/,
                                    false, false, false,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID
                                    );
                            oSIN.Insert();

                            clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), (txtSemiItem.Tag != null ? txtSemiItem.Tag.ToString() : "default"), (clsValidation.Validate_DecimalNumber(txtSemiItemQty.Text)));

                            SIn_InsertMaterials();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

                            sSub_IN_ID = oSIN.SubIn_ID;
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
                if (CheckValidity())
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        tbl_prod_pharmaTxSubContractInNote oSIN = tbl_prod_pharmaTxSubContractInNote.Select(txtSubInID.Tag.ToString());
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
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxSubContractInNote oSIn = tbl_prod_pharmaTxSubContractInNote.Select(txtSubInID.Tag.ToString());
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

                                                foreach (tbl_prod_pharmaTxSubContractInNote_Material oMat in tbl_prod_pharmaTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIn.SubIn_ID))
                                                {
                                                    clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oMat.Item_ID, -oMat.Returned_Qty);
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
                RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials, true);
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
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_pharmaTxSubContractInNote oSubIn in tbl_prod_pharmaTxSubContractInNote.SelectAll().Where(p => p.SubIn_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oSubIn.SubIn_ID, oSubIn.SubIn_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Supplier(oSubIn.Supplier_ID), clsGenaralName.getName_User(oSubIn.CreateUser_ID), clsGenaralName.getName_User(oSubIn.ApprovedUser_ID), oSubIn.IsCanceled);
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
                    if (clsValidate.CheckValidity_TransactionCodeLength(txtSubInID.Text))
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

                tbl_prod_pharmaTxSubContractInNote oSubOUT = tbl_prod_pharmaTxSubContractInNote.Select(txtSubInID.Text);
                if (oSubOUT != null)
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
                tbl_prod_pharmaTxSubContractInNote oSIN = tbl_prod_pharmaTxSubContractInNote.Select(sID);
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
                    foreach (tbl_prod_pharmaTxSubContractInNote_Material oSIN_Meterial in tbl_prod_pharmaTxSubContractInNote_Material.SelectAllBySubIn_ID(oSIN.SubIn_ID))
                    {
                        decimal dConsumption = 0;
                        tbl_prod_pharmaTxJobCard_Material oProd_Material = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oSIN.ProdJob_ID).Where(r => r.Item_ID == oSIN_Meterial.Item_ID).FirstOrDefault();
                        if (oProd_Material != null)
                            dConsumption += oProd_Material.InputQty; //Consuption

                        dtMeterials.Rows.Add("0",
                            oSIN_Meterial.Item_ID,
                            clsGenaralName.getName_Item(oSIN_Meterial.Item_ID),
                            oSIN_Meterial.Uom_ID,
                            clsGenaralName.getName_Uom(oSIN_Meterial.Uom_ID),
                            cls_Formater.FormatDecimal(dConsumption, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSIN_Meterial.Total_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSIN_Meterial.Returned_Qty,
                            clsConfig.sDecimalPlaces_Quantity), oSIN_Meterial.Remark);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_RawMeterialGrid_FromSemiFinishedItem(string sJobID, string sSemiItemID)
        {
            dtMeterials.Rows.Clear();
            //Semi finished and Raw meterials are saved in same meterial table
            tbl_prod_pharmaTxJobCard_Material oMeterail = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sJobID).Where(r => r.Item_ID == sSemiItemID).FirstOrDefault();
            if (oMeterail != null)
            {
                foreach (tbl_prod_pharmaTxJobCard_Material oMaterils_forSemi in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sJobID).Where(r => r.Line_No == oMeterail.Line_No && r.Line_No_Sub1 != 0))
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
                        "");
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
                t.Text = cls_Formater.FormatDecimal(dQty, 2);
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[6].ToString()))
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionDepartment);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionContractor);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
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
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_Batch);
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
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSubBoMs);
                if (RowDataSearch.DialogResult == true)
                {
                    txtSemiItem.Tag = lstResult[1];
                    txtSemiItemUoM.Tag = lstResult[3];

                    txtSemiItem.Text = lstResult[2];
                    txtSemiItemUoM.Text = lstResult[4] + " - " + lstResult[5];
                    txtSF_PrevIssuedQty.Text = cls_Formater.FormatDecimal(Get_TotalIssuedQty_SemiFinished(txtProdJobID.Tag.ToString(), lstResult[1]), clsConfig.sDecimalPlaces_Quantity);
                    txtSemiItemQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);

                    Fill_RawMeterialGrid_FromSemiFinishedItem(lstResult[0], lstResult[1]);
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
        private void SIn_InsertMaterials()
        {
            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dTotalIsuuedQty = clsValidate.ValidateRowValue(row, "TotalIsuuedQty", 0m);
                decimal dRetrnedQty = clsValidate.ValidateRowValue(row, "RetrnedQty", 0m);
                string sRemark = clsValidate.ValidateRowValue(row, "Remark", "");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemNo);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItemNo);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dRetrnedQty;
                }

                tbl_prod_pharmaTxSubContractInNote_Material oPGIN_Materials = new tbl_prod_pharmaTxSubContractInNote_Material(iLine_no, txtSubInID.Text, sItemNo, sUoM_ID, dTotalIsuuedQty, dRetrnedQty, 0, dUnitPrice, 0, dTotalAmount, sRemark);
                oPGIN_Materials.Insert();

                clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), sItemNo, dRetrnedQty);
            }
        }

        private decimal Get_TotalIssuedQty_Material(string sProdJobBom, string sItemID)
        {
            decimal dIssuedQty = 0;
            foreach (tbl_prod_pharmaTxSubContractOutNote_Material oSOut_Material in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllByProdJob_ID(sProdJobBom).Where(r => r.Item_ID == sItemID))
            {
                tbl_prod_pharmaTxSubContractOutNote oSOut = tbl_prod_pharmaTxSubContractOutNote.Select(oSOut_Material.SubOut_ID);
                if (oSOut != null && !oSOut.IsCanceled && !oSOut_Material.IsSemiFG_item)
                    dIssuedQty += oSOut_Material.Son_Qty;
            }
            return dIssuedQty;
        }

        private decimal Get_TotalIssuedQty_SemiFinished(string sProdJobBom, string sSemiFinishedItemID)
        {
            decimal dSFGQty = 0;
            foreach (tbl_prod_pharmaTxSubContractOutNote_Material oSOut_Material in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllByProdJob_ID(sProdJobBom).Where(r => r.Item_ID == sSemiFinishedItemID))
            {
                tbl_prod_pharmaTxSubContractOutNote oSOut = tbl_prod_pharmaTxSubContractOutNote.Select(oSOut_Material.SubOut_ID);
                if (oSOut != null && !oSOut.IsCanceled && oSOut_Material.IsSemiFG_item)
                    dSFGQty += oSOut_Material.Son_Qty;
            }
            return dSFGQty;
        }

        #endregion

    }
}
