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

namespace SEACC_PRODUCTION_POLY.Transactions
{
    /// <summary>
    /// Developped By Gayan
    /// 2017-05-23
    /// </summary>
    public partial class UC_ProductionGoodsIssues : UserControl
    {
        #region Class Variables
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_ProductionGoodsIssues()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_GoodsIssues;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            #region Meterial Data Table
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("StoreBalance_Qty");
            dtMeterials.Columns.Add("PGIN_Qty");
            dtMeterials.Columns.Add("MR_Qty");
            #endregion

            #region Main Data Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("PGIN_NO");
            dgr_Main.dt.Columns.Add("PGIN_DATE");
            dgr_Main.dt.Columns.Add("ISSUED_LOCATION");
            dgr_Main.dt.Columns.Add("MR_NO");
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
            dgr_Main.Add_DatagridColoumn("pGIN No", "PGIN_NO", 80);
            dgr_Main.Add_DatagridColoumn("pGIN Date", "PGIN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Issued Store", "ISSUED_LOCATION", 150);
            dgr_Main.Add_DatagridColoumn("MR No", "MR_NO", 80);
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
            string sPGIN_No = "";
            if (CheckValidity())
            {
                try
                {
                    tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMR.Tag.ToString());
                    if (oMR != null)
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            if (SEACC_Form.CheckPermission_ToSave(true))
                            {
                                tbl_prodTxGoodIssueNote oOldPGIN = tbl_prodTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                                if (oOldPGIN != null)
                                {
                                    if (!oOldPGIN.IsApproved && !oOldPGIN.IsCanceled)
                                    {

                                        tbl_prodTxGoodIssueNote oPGIN = new tbl_prodTxGoodIssueNote(txtPGINId.Tag.ToString(), dtpPGIN_Date.GetDateTime(),
                                        txtIssuedStore.Tag != null ? txtIssuedStore.Tag.ToString() : "default",
                                        txtOrderedBy.Tag != null ? txtOrderedBy.Tag.ToString() : "default",
                                        txtMR.Tag.ToString(),
                                        txtItemsCollectedBy.Tag != null ? txtItemsCollectedBy.Tag.ToString() : "default", "",
                                        oOldPGIN.IsChecked, oOldPGIN.IsApproved, oOldPGIN.IsCanceled,
                                        oOldPGIN.CreateUser_ID, clsSecurity.UserIDLoged, oOldPGIN.CheckedUser_ID, oOldPGIN.ApprovedUser_ID, oOldPGIN.CanceldUser_ID,
                                        oOldPGIN.DateCreate, clsSecurity.getServerDateTime(), oOldPGIN.DateChecked, oOldPGIN.DateApproved, oOldPGIN.DateCanceled,
                                        oOldPGIN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldPGIN.CheckedUserTerminal_ID, oOldPGIN.ApprovedUserTerminal_ID, oOldPGIN.CanceledUserTerminal_ID,
                                        oOldPGIN.CompanyID, oOldPGIN.CompanyBranchID
                                        );
                                        oPGIN.Update();

                                        foreach (tbl_prodTxGoodIssueNote_Material oMat in tbl_prodTxGoodIssueNote_Material.SelectAllByPGIN_No(oPGIN.PGIN_No))
                                        {
                                            clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                            clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                            oMat.Delete();
                                        }

                                        PGIN_InsertMaterials(oMR);
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (oOldPGIN.IsApproved)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected PGIN has been approved", MessageBoxButton.OK, "Red");
                                        else if (oOldPGIN.IsCanceled)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected PGIN has been cancelled", MessageBoxButton.OK, "Red");
                                        else
                                            SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                    }
                                }
                                sPGIN_No = oOldPGIN.PGIN_No;
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.CheckPermission_ToSave(false))
                            {
                                tbl_prodTxGoodIssueNote oPGIN = new tbl_prodTxGoodIssueNote(txtPGINId.Tag.ToString(), dtpPGIN_Date.GetDateTime(),
                                       txtIssuedStore.Tag != null ? txtIssuedStore.Tag.ToString() : "default",
                                       txtOrderedBy.Tag != null ? txtOrderedBy.Tag.ToString() : "default",
                                       txtMR.Tag.ToString(),
                                       txtItemsCollectedBy.Tag != null ? txtItemsCollectedBy.Tag.ToString() : "default", "",
                                      false, false, false,
                                       clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                       clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                       clsSecurity.TerminalID, "default", "default", "default", "default",
                                       clsSecurity.CompanyID, clsSecurity.BranchID
                                       );
                                oPGIN.Insert();

                                PGIN_InsertMaterials(oMR);
                                sPGIN_No = oPGIN.PGIN_No;
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
                    fillDetails(sPGIN_No);
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
                            tbl_prodTxGoodIssueNote oPGIN = tbl_prodTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                            if (oPGIN != null)
                            {
                                if (!oPGIN.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oPGIN.IsApproved = true;
                                            oPGIN.DateApproved = clsSecurity.getServerDateTime();
                                            oPGIN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oPGIN.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oPGIN.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                    ClearFields();
                                    RefreshGrid();
                                    fillDetails(oPGIN.PGIN_No);
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
                            tbl_prodTxGoodIssueNote oPGIN = tbl_prodTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                            if (oPGIN != null)
                            {
                                if (!oPGIN.IsApproved)
                                {
                                    if (!oPGIN.IsCanceled)
                                    {
                                        tbl_prod_polyTxMaterialRequision oMR = tbl_prod_polyTxMaterialRequision.Select(txtMR.Tag.ToString());
                                        if (oMR != null)
                                        {
                                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                            if (bMessegeBoxResult)
                                            {
                                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                                frmTwoStepVerify.ShowDialog();
                                                if (frmTwoStepVerify.bVerified)
                                                {
                                                    oPGIN.IsCanceled = true;
                                                    oPGIN.DateCanceled = clsSecurity.getServerDateTime();
                                                    oPGIN.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                    oPGIN.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                    foreach (tbl_prodTxGoodIssueNote_Material oMat in tbl_prodTxGoodIssueNote_Material.SelectAllByPGIN_No(oPGIN.PGIN_No))
                                                    {
                                                        clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                                        clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                                    }

                                                    oPGIN.Update();
                                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                                }
                                                frmTwoStepVerify.Close();
                                            }
                                            ClearFields();
                                            RefreshGrid();
                                        }
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPGINId, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtIssuedStore, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMR, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtOrderedBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemsCollectedBy, true, false, false);

            txtPGINId.Tag = null;
            txtIssuedStore.Tag = null;
            txtMR.Tag = null;
            txtOrderedBy.Tag = null;
            txtItemsCollectedBy.Tag = null;

            txtPGINId.Text = "";
            txtIssuedStore.Text = "";
            txtMR.Text = "";
            txtOrderedBy.Text = "";
            txtItemsCollectedBy.Text = "";

            dtMeterials.Clear();
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;

            txtIssuedStore.IsEnabled = true;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPGINId.setReadOnlyStatus(true);
                txtPGINId.Text = "<Auto Generate>";
            }
            else
                txtPGINId.setReadOnlyStatus(false);
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
                foreach (tbl_prodTxGoodIssueNote oPGIN in tbl_prodTxGoodIssueNote.SelectAll().Where(p => p.Mr_No != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oPGIN.PGIN_No, oPGIN.PGIN_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Store(oPGIN.Store_ID), oPGIN.Mr_No, clsGenaralName.getName_User(oPGIN.CreateUser_ID), clsGenaralName.getName_User(oPGIN.ApprovedUser_ID), oPGIN.IsCanceled);
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

            if (!clsValidation.Validate_EmptyValue(txtPGINId))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtIssuedStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMR))
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
                    txtPGINId.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtPGINId.Text = txtPGINId.Tag.ToString();
                }

                tbl_prodTxGoodIssueNote oJob = tbl_prodTxGoodIssueNote.Select(txtPGINId.Text);
                if (oJob != null)
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
                tbl_prodTxGoodIssueNote oPGIN = tbl_prodTxGoodIssueNote.Select(sID);
                if (oPGIN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtPGINId.Tag = oPGIN.PGIN_No;
                    txtIssuedStore.Tag = oPGIN.Store_ID;
                    txtOrderedBy.Tag = oPGIN.Ordered_HOD;
                    txtMR.Tag = oPGIN.Mr_No;
                    txtItemsCollectedBy.Tag = oPGIN.ItemCollectedBy;

                    dtpPGIN_Date.SetTime(oPGIN.PGIN_Date);

                    txtPGINId.Text = oPGIN.PGIN_No;
                    txtIssuedStore.Text = clsGenaralName.getName_Store(oPGIN.Store_ID);
                    txtOrderedBy.Text = clsGenaralName.getName_Employee(oPGIN.Ordered_HOD);
                    txtMR.Text = oPGIN.Mr_No;
                    txtItemsCollectedBy.Text = clsGenaralName.getName_Employee(oPGIN.ItemCollectedBy);

                    txtIssuedStore.IsEnabled = false;

                    if (oPGIN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oPGIN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    fillMaterialGrid_form_PGIN(sID, oPGIN.Mr_No);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fillMaterialGrid_form_MR(string sMR_No)
        {
            dtMeterials.Clear();
            foreach (tbl_prod_polyTxMaterialRequision_Material oMaterial in tbl_prod_polyTxMaterialRequision_Material.SelectAllByMr_No(sMR_No).Where(r => r.Store_ID == txtIssuedStore.Tag.ToString()))
            {
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMaterial.Item_ID);
                decimal dstockQty = 0;
                if (oItem != null)
                {
                    dstockQty = clsProcessMethods.Get_StoreStockBalance_Qty(txtIssuedStore.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                }
                dtMeterials.Rows.Add("0", oMaterial.ProdJob_ID, oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID), oMaterial.Uom_ID, clsGenaralName.getName_Uom(oMaterial.Uom_ID), cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity), (dstockQty > oMaterial.Mr_Qty ? cls_Formater.FormatDecimal(oMaterial.Mr_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity)), cls_Formater.FormatDecimal(oMaterial.Mr_Qty, clsConfig.sDecimalPlaces_Quantity));
            }
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;
        }

        private void fillMaterialGrid_form_PGIN(string sPGIN_No, string sMR_No)
        {
            dtMeterials.Clear();
            foreach (tbl_prodTxGoodIssueNote_Material oMaterial in tbl_prodTxGoodIssueNote_Material.SelectAllByPGIN_No(sPGIN_No))
            {

                tbl_prod_polyTxMaterialRequision_Material oMR_Material = tbl_prod_polyTxMaterialRequision_Material.SelectAllByMr_No(sMR_No).Where(r => r.Item_ID == oMaterial.Item_ID && r.ProdJob_ID == oMaterial.ProdJob_ID).FirstOrDefault();

                dtMeterials.Rows.Add("0", oMaterial.ProdJob_ID, oMaterial.Item_ID, clsGenaralName.getName_Item(oMaterial.Item_ID), oMaterial.Uom_ID, clsGenaralName.getName_Uom(oMaterial.Uom_ID), cls_Formater.FormatDecimal(oMaterial.StoreBalance_Qty, clsConfig.sDecimalPlaces_Quantity), cls_Formater.FormatDecimal(oMaterial.PGIN_Qty, clsConfig.sDecimalPlaces_Quantity), oMR_Material != null ? cls_Formater.FormatDecimal(oMR_Material.Mr_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity));
            }
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;
        }
        #endregion

        #region Grid Events
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[7].ToString()))
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

        #region Meterial Grid
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }

        private void dgr_Meterial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;

            if (sColumnName == "PGIN_Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    object item = dgr_Meterial.SelectedItem;
                    if (item != null)
                    {
                        dQty = decimal.Parse(t.Text);
                        string sStock_Qty = (dgr_Meterial.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                        decimal dStock_Qty = clsValidation.Validate_DecimalNumber(sStock_Qty);
                        if (dStock_Qty < dQty)
                        {
                            dQty = dStock_Qty;
                            SEACCMessageBox.Show("Oops..!", "Store Balance Quantity : " + dStock_Qty + "\nQuantity should be less than or equal to Store Balance Quantity", MessageBoxButton.OK);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }
        }

        #endregion
        #endregion

        #region Search Events
        private void txtIssuedLocation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtIssuedStore.Tag = lstResult[0];
                txtIssuedStore.Text = lstResult[1];
            }
        }

        private void txtMR_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtIssuedStore.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMeterialRequisition);
                if (RowDataSearch.DialogResult == true)
                {
                    txtMR.Tag = lstResult[0];
                    txtMR.Text = lstResult[0];

                    fillMaterialGrid_form_MR(lstResult[0]);

                    txtIssuedStore.IsEnabled = false;
                }
            }
            else
            {
                SEACCMessageBox.Show("Issued Location Can not Empty", "Please select an issued location/store before selecting a MR", MessageBoxButton.OK, "Red");
            }
        }

        private void txtOrderedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Employees);
            if (RowDataSearch.DialogResult == true)
            {
                txtOrderedBy.Tag = lstResult[0];
                txtOrderedBy.Text = lstResult[1];
            }
        }

        private void txtItemsCollectedBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Employees);
            if (RowDataSearch.DialogResult == true)
            {
                txtItemsCollectedBy.Tag = lstResult[0];
                txtItemsCollectedBy.Text = lstResult[1];
            }
        }
        #endregion

        #region Help Methods
        private void PGIN_InsertMaterials(tbl_prod_polyTxMaterialRequision oMR)
        {
            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItemID = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dStoreBalance_Qty = clsValidate.ValidateRowValue(row, "StoreBalance_Qty", 0);
                decimal dPGIN_Qty = clsValidate.ValidateRowValue(row, "PGIN_Qty", 0);
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Finance oItem_Finance = tbl_genItemMaster_Finance.Select(sItemID, (oItem != null ? oItem.ItemCategorySub_ID : "default"), "default", "0", "0");
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dPGIN_Qty;
                }

                tbl_prodTxGoodIssueNote_Material oPGIN_Materials = new tbl_prodTxGoodIssueNote_Material(iLine_no, txtPGINId.Tag.ToString(), sItemID, sUoM_ID, dStoreBalance_Qty, dPGIN_Qty, 0, dUnitPrice, 0, dTotalAmount, false, "", sBoM_No);
                oPGIN_Materials.Insert();

                clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), sItemID, -dPGIN_Qty);
                clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, sItemID, dPGIN_Qty);
            }
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
    }
}
