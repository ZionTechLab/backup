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
    /// Interaction logic for UC_ProductionGoodsReturns.xaml
    /// </summary>
    public partial class UC_ProductionGoodsReturns : UserControl
    {
        #region Class Variables
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_ProductionGoodsReturns()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_GoodsReturns;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            #region Meterial Grid
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            //dtMeterials.Columns.Add("FloorQty");
            dtMeterials.Columns.Add("Qty");
            dtMeterials.Columns.Add("IsDamaged", typeof(bool));
            dtMeterials.Columns.Add("Remarks");
            #endregion

            #region Main Grid
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("PGRN_NO");
            dgr_Main.dt.Columns.Add("PGRN_DATE");
            dgr_Main.dt.Columns.Add("RETURNED_LOCATION");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion

            #endregion

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("PGRN No", "PGRN_NO", 80);
            dgr_Main.Add_DatagridColoumn("PGRN Date", "PGRN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Returned From", "RETURNED_LOCATION", 150);
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
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxGoodReturnNote oOldPGRN = tbl_prodTxGoodReturnNote.Select(txtPGRNId.Tag.ToString());
                            if (oOldPGRN != null)
                            {
                                if (!oOldPGRN.IsApproved && !oOldPGRN.IsCanceled)
                                {

                                    tbl_prodTxGoodReturnNote oPGRN = new tbl_prodTxGoodReturnNote(txtPGRNId.Tag.ToString(), dtpPGRN_Date.GetDateTime(),
                                      txtReturnedFrom_ProdSection.Tag != null ? txtReturnedFrom_ProdSection.Tag.ToString() : "default",
                                      txtReturnedBy_HOD.Tag != null ? txtReturnedBy_HOD.Tag.ToString() : "default",
                                      txtReturnedToStore.Tag != null ? txtReturnedToStore.Tag.ToString() : "default",
                                      txtProdJobNo.Tag != null ? txtProdJobNo.Tag.ToString() : "default", txtComments.Text,
                                      oOldPGRN.IsChecked, oOldPGRN.IsApproved, oOldPGRN.IsCanceled,
                                      oOldPGRN.CreateUser_ID, clsSecurity.UserIDLoged, oOldPGRN.CheckedUser_ID, oOldPGRN.ApprovedUser_ID, oOldPGRN.CanceldUser_ID,
                                      oOldPGRN.DateCreate, clsSecurity.getServerDateTime(), oOldPGRN.DateChecked, oOldPGRN.DateApproved, oOldPGRN.DateCanceled,
                                     oOldPGRN.CreateUserTerminal_ID, clsSecurity.TerminalID, oOldPGRN.CheckedUserTerminal_ID, oOldPGRN.ApprovedUserTerminal_ID, oOldPGRN.CanceledUserTerminal_ID,
                                      oOldPGRN.CompanyID, oOldPGRN.CompanyBranchID
                                      );
                                    oPGRN.Update();

                                    //tbl_prodTxGoodReturnNote_Material.DeleteAllByPGRN_No(oPGRN.PGRN_No);
                                    //foreach (DataRow row in dtMeterials.Rows)
                                    //{
                                    //    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                    //    string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                    //    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                    //    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                                    //    bool bIsDamaged = clsValidate.ValidateRowValue(row, "IsDamaged", false);
                                    //    string sRemarks = clsValidate.ValidateRowValue(row, "Remarks", "");

                                    //    tbl_prodTxGoodReturnNote_Material oPGRN_Materials = new tbl_prodTxGoodReturnNote_Material(iLine_no, oPGRN.PGRN_No, sItemNo, sUoM_ID, dQty, bIsDamaged, sRemarks);
                                    //    oPGRN_Materials.Insert();
                                    //}

                                    foreach (tbl_prodTxGoodReturnNote_Material oMat in tbl_prodTxGoodReturnNote_Material.SelectAllByPGRN_No(txtPGRNId.Tag.ToString()))
                                    {
                                        clsHelpMethods_Prod.UpdateSectionFloorStock(txtReturnedFrom_ProdSection.Tag.ToString(), oMat.Item_ID, -oMat.PGRN_Qty);
                                        clsHelpMethods_Prod.UpdateStock(txtReturnedToStore.Tag.ToString(), oMat.Item_ID, oMat.PGRN_Qty);
                                        oMat.Delete();
                                    }

                                    PGRN_InsertMaterials();
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oOldPGRN.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected PGRN has been approved", MessageBoxButton.OK, "Red");
                                    else if (oOldPGRN.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected PGRN has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            sPGIN_No = oOldPGRN.PGRN_No;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prodTxGoodReturnNote oPGRN = new tbl_prodTxGoodReturnNote(txtPGRNId.Tag.ToString(), dtpPGRN_Date.GetDateTime(),
                                   txtReturnedFrom_ProdSection.Tag != null ? txtReturnedFrom_ProdSection.Tag.ToString() : "default",
                                   txtReturnedBy_HOD.Tag != null ? txtReturnedBy_HOD.Tag.ToString() : "default",
                                   txtReturnedToStore.Tag != null ? txtReturnedToStore.Tag.ToString() : "default",
                                   txtProdJobNo.Tag != null ? txtProdJobNo.Tag.ToString() : "default", txtComments.Text,
                                   false, false, false,
                                   clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                   clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                   clsSecurity.TerminalID, "default", "default", "default", "default",
                                   clsSecurity.CompanyID, clsSecurity.BranchID
                                   );
                            oPGRN.Insert();

                            //foreach (DataRow row in dtMeterials.Rows)
                            //{
                            //    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                            //    string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                            //    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                            //    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                            //    bool bIsDamaged = clsValidate.ValidateRowValue(row, "IsDamaged", false);
                            //    string sRemarks = clsValidate.ValidateRowValue(row, "Remarks", "");

                            //    tbl_prodTxGoodReturnNote_Material oPGRN_Materials = new tbl_prodTxGoodReturnNote_Material(iLine_no, oPGRN.PGRN_No, sItemNo, sUoM_ID, dQty, bIsDamaged, sRemarks);
                            //    oPGRN_Materials.Insert();
                            //}

                            PGRN_InsertMaterials();
                            sPGIN_No = oPGRN.PGRN_No;
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
            if (SEACC_Form.CheckPermission_ToApproved())
            {
                if (CheckValidity())
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        tbl_prodTxGoodReturnNote oPGRN = tbl_prodTxGoodReturnNote.Select(txtPGRNId.Tag.ToString());
                        if (oPGRN != null)
                        {
                            if (!oPGRN.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        oPGRN.IsApproved = true;
                                        oPGRN.DateApproved = clsSecurity.getServerDateTime();
                                        oPGRN.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                        oPGRN.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                        oPGRN.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    }
                                    frmTwoStepVerify.Close();
                                }
                                ClearFields();
                                RefreshGrid();
                                fillDetails(oPGRN.PGRN_No);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Alreay Approved", "Selected pGRN has already been approved", MessageBoxButton.OK, "Red");
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
                            tbl_prodTxGoodReturnNote oPGRN = tbl_prodTxGoodReturnNote.Select(txtPGRNId.Tag.ToString());
                            if (oPGRN != null)
                            {
                                if (!oPGRN.IsApproved)
                                {
                                    if (!oPGRN.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oPGRN.IsCanceled = true;
                                                oPGRN.DateCanceled = clsSecurity.getServerDateTime();
                                                oPGRN.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oPGRN.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                foreach (tbl_prodTxGoodReturnNote_Material oMat in tbl_prodTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No))
                                                {
                                                    clsHelpMethods_Prod.UpdateSectionFloorStock(oPGRN.FromSection_ID, oMat.Item_ID, -oMat.PGRN_Qty);
                                                    clsHelpMethods_Prod.UpdateStock(oPGRN.Store_ID, oMat.Item_ID, oMat.PGRN_Qty);
                                                }

                                                oPGRN.Update();
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

        #region Meterial Grid Buttons
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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (txtReturnedFrom_ProdSection.Tag != null && txtReturnedToStore.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMaterials, true);
                RowDataSearch.RowSelected += RowDataSearch_RowSelected;
            }
            else
            {
                if (txtReturnedFrom_ProdSection.Tag == null)
                    SEACCMessageBox.Show("Returned Section not selected", "Please select Returned Section...", MessageBoxButton.OK, "Red");
                else if (txtReturnedToStore.Tag == null)
                    SEACCMessageBox.Show("Store not selected", "Please select store...", MessageBoxButton.OK, "Red");
            }
        }

        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPGRNId, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReturnedFrom_ProdSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReturnedBy_HOD, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReturnedToStore, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdJobNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);

            txtPGRNId.Tag = null;
            txtReturnedFrom_ProdSection.Tag = null;
            txtReturnedBy_HOD.Tag = null;
            txtReturnedToStore.Tag = null;
            txtProdJobNo.Tag = null;

            txtPGRNId.Text = "";
            txtReturnedFrom_ProdSection.Text = "";
            txtReturnedBy_HOD.Text = "";
            txtReturnedToStore.Text = "";
            txtProdJobNo.Text = "";
            txtComments.Text = "";

            dtMeterials.Clear();
            dgr_Meterial.ItemsSource = dtMeterials.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtPGRNId.setReadOnlyStatus(true);
                txtPGRNId.Text = "<Auto Generate>";
            }
            else
                txtPGRNId.setReadOnlyStatus(false);
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
                foreach (tbl_prodTxGoodReturnNote oJob in tbl_prodTxGoodReturnNote.SelectAll().Where(p => p.PGRN_No != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oJob.PGRN_No, oJob.PGRN_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Section(oJob.FromSection_ID), clsGenaralName.getName_User(oJob.CreateUser_ID), clsGenaralName.getName_User(oJob.ApprovedUser_ID), oJob.IsCanceled);
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

            if (!clsValidation.Validate_EmptyValue(txtPGRNId))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReturnedFrom_ProdSection))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReturnedToStore))
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
                    txtPGRNId.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtPGRNId.Text = txtPGRNId.Tag.ToString();
                }

                tbl_prodTxGoodReturnNote oPGRN = tbl_prodTxGoodReturnNote.Select(txtPGRNId.Text);
                if (oPGRN != null)
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
                tbl_prodTxGoodReturnNote oPGRN = tbl_prodTxGoodReturnNote.Select(sID);
                if (oPGRN != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtPGRNId.Tag = oPGRN.PGRN_No;
                    txtReturnedFrom_ProdSection.Tag = oPGRN.FromSection_ID;
                    txtReturnedBy_HOD.Tag = oPGRN.FromSection_HOD_ID;
                    txtReturnedToStore.Tag = oPGRN.Store_ID;
                    txtProdJobNo.Tag = oPGRN.ProdJob_ID;

                    dtpPGRN_Date.SetTime(oPGRN.PGRN_Date);

                    txtPGRNId.Text = oPGRN.PGRN_No;
                    txtReturnedFrom_ProdSection.Text = clsGenaralName.getName_Section(oPGRN.FromSection_ID);
                    txtReturnedBy_HOD.Text = clsGenaralName.getName_Employee(oPGRN.FromSection_HOD_ID);
                    txtReturnedToStore.Text = clsGenaralName.getName_Store(oPGRN.Store_ID);
                    txtProdJobNo.Text = oPGRN.ProdJob_ID != "default" ? oPGRN.ProdJob_ID : "-";
                    txtComments.Text = oPGRN.Remark;

                    if (oPGRN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oPGRN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    dtMeterials.Rows.Clear();
                    foreach (tbl_prodTxGoodReturnNote_Material oPGRN_Meterials in tbl_prodTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No))
                    {
                        dtMeterials.Rows.Add("0", oPGRN_Meterials.Item_ID, clsGenaralName.getName_Item(oPGRN_Meterials.Item_ID), oPGRN_Meterials.Uom_ID, clsGenaralName.getName_Uom(oPGRN_Meterials.Uom_ID), cls_Formater.FormatDecimal(oPGRN_Meterials.PGRN_Qty, 3), oPGRN_Meterials.IsDamage, oPGRN_Meterials.Remark);
                    }
                    dgr_Meterial.ItemsSource = dtMeterials.DefaultView;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
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

        #region Meterial Grid
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }

        private void dgr_Meterial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;

            if (sColumnName == "Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    object item = dgr_Meterial.SelectedItem;
                    if (item != null)
                    {
                        string sItemID = (dgr_Meterial.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);

                        if (oItem != null)
                        {
                            dQty = decimal.Parse(t.Text);
                            //decimal dSection_Qty = clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtReturnedFrom_ProdSection.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                            //if (dSection_Qty < dQty || true)
                            //{
                            //    dQty = dSection_Qty;
                            //    SEACCMessageBox.Show("Oops..!", "Physical Quantity : " + cls_Formater.FormatDecimal(dSection_Qty, 3) + "\nQuantity should be less than or equal to Physical Quantity", MessageBoxButton.OK);
                            //}
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, 3);
            }
        }

        #endregion

        #endregion

        #region Search Events

        private void RowDataSearch_RowSelected(List<string> lstResult)
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
                    dtMeterials.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID), "0.000", false, "");
                }
            }
        }

        private void txtProdSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtReturnedFrom_ProdSection.Tag = lstResult[0];
                txtReturnedFrom_ProdSection.Text = lstResult[1];
            }
        }

        private void txtReturnedBy_HOD_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Employees);
            if (RowDataSearch.DialogResult == true)
            {
                txtReturnedBy_HOD.Tag = lstResult[0];
                txtReturnedBy_HOD.Text = lstResult[1];
            }
        }

        private void txtReturnedToStore_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
            if (RowDataSearch.DialogResult == true)
            {
                txtReturnedToStore.Tag = lstResult[0];
                txtReturnedToStore.Text = lstResult[1];
            }
        }

        private void txtJobNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdJobNo.Tag = lstResult[0];
                txtProdJobNo.Text = lstResult[0];
            }
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
        private void PGRN_InsertMaterials()
        {
            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                bool bIsDamaged = clsValidate.ValidateRowValue(row, "IsDamaged", false);
                string sRemarks = clsValidate.ValidateRowValue(row, "Remarks", "");

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemNo);
                tbl_genItemMaster_Finance oItem_Finance = tbl_genItemMaster_Finance.Select(sItemNo, (oItem != null ? oItem.ItemCategorySub_ID : "default"), "default", "0", "0");
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dQty;
                }
                tbl_prodTxGoodReturnNote_Material oPGRN_Materials = new tbl_prodTxGoodReturnNote_Material(iLine_no, txtPGRNId.Text, sItemNo, sUoM_ID, dQty, dUnitPrice, 0, 0, dTotalAmount, bIsDamaged, sRemarks);
                oPGRN_Materials.Insert();

                clsHelpMethods_Prod.UpdateStock(txtReturnedToStore.Tag.ToString(), sItemNo, dQty);
                clsHelpMethods_Prod.UpdateSectionFloorStock(txtReturnedFrom_ProdSection.Tag.ToString(), sItemNo, -dQty);
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
