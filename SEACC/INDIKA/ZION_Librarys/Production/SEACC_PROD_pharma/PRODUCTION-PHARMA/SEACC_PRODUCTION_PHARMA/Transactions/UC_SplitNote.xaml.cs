using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using DataTire;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.UserManagement;

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Interaction logic for UC_SplitNote.xaml
    /// </summary>
    public partial class UC_SplitNote : UserControl
    {
        #region Class Variables
        DataTable dtInputs = new DataTable();
        DataTable dtOutputs = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_SplitNote()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_SplitNote;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables

            #region Input Item Table
            dtInputs.Columns.Add("LineNo");
            dtInputs.Columns.Add("Output_ItemID");
            dtInputs.Columns.Add("Output_ItemName");
            dtInputs.Columns.Add("Input_ItemID");
            dtInputs.Columns.Add("Input_ItemName");
            dtInputs.Columns.Add("UoM_ID");
            dtInputs.Columns.Add("UoM");
            dtInputs.Columns.Add("InputQtyRate");
            dtInputs.Columns.Add("InputQty");
            dtInputs.Columns.Add("FloorQty");
            #endregion

            #region Output Item Table
            dtOutputs.Columns.Add("LineNo");
            dtOutputs.Columns.Add("Input_ItemID");
            dtOutputs.Columns.Add("Input_ItemName");
            dtOutputs.Columns.Add("Output_ItemID");
            dtOutputs.Columns.Add("Output_ItemName");
            dtOutputs.Columns.Add("UoM_ID");
            dtOutputs.Columns.Add("UoM");
            dtOutputs.Columns.Add("OutputQtyRate");
            dtOutputs.Columns.Add("OutputQty");
            dtOutputs.Columns.Add("FloorQty");
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("FGSN#");
            dgr_Main.dt.Columns.Add("FGSN_Date");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion

            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("Split Note #", "FGSN#", 100);
            dgr_Main.Add_DatagridColoumn("Split Note Date", "FGSN_Date", 120);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(420);
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
                            tbl_prod_pharmaTxItemSplitNote oSplitNote = tbl_prod_pharmaTxItemSplitNote.Select(txtSpliteNote_ID.Tag.ToString());
                            if (oSplitNote != null)
                            {
                                if (!oSplitNote.IsApproved)
                                {
                                    if (!oSplitNote.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oSplitNote.IsCanceled = true;
                                                oSplitNote.DateCanceled = clsSecurity.getServerDateTime();
                                                oSplitNote.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oSplitNote.CanceledUserTerminal_ID = clsSecurity.TerminalID;

                                                foreach (tbl_prod_pharmaTxItemSplitNote_Input oSplitNote_Input in tbl_prod_pharmaTxItemSplitNote_Input.SelectAllBySplit_ID(txtSpliteNote_ID.Text))
                                                    clsHelpMethods_Prod.UpdateStock(oSplitNote.Store_ID, oSplitNote_Input.Item_ID, oSplitNote_Input.InputQty);

                                                foreach (tbl_prod_pharmaTxItemSplitNote_Output oSplitNote_Output in tbl_prod_pharmaTxItemSplitNote_Output.SelectAllBySplit_ID(txtSpliteNote_ID.Text))
                                                    clsHelpMethods_Prod.UpdateStock(oSplitNote.Store_ID, oSplitNote_Output.Item_ID, -oSplitNote_Output.OutputQty);


                                                oSplitNote.Update();
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
            string sSpliNote_ID = "";
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxItemSplitNote oOldSpliteNote = tbl_prod_pharmaTxItemSplitNote.Select(txtSpliteNote_ID.Text);
                            if (oOldSpliteNote != null)
                            {
                                if (!oOldSpliteNote.IsApproved && !oOldSpliteNote.IsCanceled)
                                {

                                    foreach (tbl_prod_pharmaTxItemSplitNote_Input oSplitNote_Input in
                                        tbl_prod_pharmaTxItemSplitNote_Input.SelectAllBySplit_ID(txtSpliteNote_ID.Text))
                                    {
                                        clsHelpMethods_Prod.UpdateStock(oOldSpliteNote.Store_ID,
                                            oSplitNote_Input.Item_ID, oSplitNote_Input.InputQty);
                                        oSplitNote_Input.Delete();
                                    }
                                    foreach (tbl_prod_pharmaTxItemSplitNote_Output oSplitNote_Output in
                                        tbl_prod_pharmaTxItemSplitNote_Output.SelectAllBySplit_ID(txtSpliteNote_ID.Text))
                                    {
                                        clsHelpMethods_Prod.UpdateStock(oOldSpliteNote.Store_ID,
                                            oSplitNote_Output.Item_ID, -oSplitNote_Output.OutputQty);
                                        oSplitNote_Output.Delete();
                                    }

                                    tbl_prod_pharmaTxItemSplitNote oSplitNote = new tbl_prod_pharmaTxItemSplitNote(
                                        txtSpliteNote_ID.Text, dtpSplitNoteDate.GetDateTime(),
                                        clsGenaralName.getStoreID_Section(txtProdSection.Tag.ToString()),
                                        txtRemark.Text, oOldSpliteNote.IsChecked, oOldSpliteNote.IsApproved,
                                        oOldSpliteNote.IsCanceled, oOldSpliteNote.CreateUser_ID,
                                        clsSecurity.UserIDLoged, oOldSpliteNote.CheckedUser_ID,
                                        oOldSpliteNote.ApprovedUser_ID, oOldSpliteNote.CanceldUser_ID,
                                        oOldSpliteNote.DateCreate, clsSecurity.getServerDateTime(),
                                        oOldSpliteNote.DateChecked, oOldSpliteNote.DateApproved,
                                        oOldSpliteNote.DateCanceled, oOldSpliteNote.CreateUserTerminal_ID,
                                        clsSecurity.TerminalID,
                                        oOldSpliteNote.CheckedUserTerminal_ID, oOldSpliteNote.ApprovedUserTerminal_ID,
                                        oOldSpliteNote.CanceledUserTerminal_ID, oOldSpliteNote.CompanyID,
                                        oOldSpliteNote.CompanyBranchID);
                                    oSplitNote.Update();

                                    SplitNote_InsertDetails();
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oOldSpliteNote.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Split Note has been approved", MessageBoxButton.OK, "Red");
                                    else if (oOldSpliteNote.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Split Note has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }

                                sSpliNote_ID = oOldSpliteNote.Split_ID;
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prod_pharmaTxItemSplitNote oSplitNote = new tbl_prod_pharmaTxItemSplitNote(
                                txtSpliteNote_ID.Text, dtpSplitNoteDate.GetDateTime(),
                                clsGenaralName.getStoreID_Section(txtProdSection.Tag.ToString()),
                                txtRemark.Text, false, false,
                                false, clsSecurity.UserIDLoged,
                                "default", "default",
                                "default", "default",
                                clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                clsValidation.defaultDateTime, clsSecurity.TerminalID,
                                "default", "default", "default","default", clsSecurity.CompanyID, clsSecurity.BranchID);
                            oSplitNote.Insert();

                            SplitNote_InsertDetails();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);

                            sSpliNote_ID = oSplitNote.Split_ID;
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
                    FillDetails(sSpliNote_ID);
                }
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
                        tbl_prod_pharmaTxItemSplitNote oItemSplitNote = tbl_prod_pharmaTxItemSplitNote.Select(txtSpliteNote_ID.Tag.ToString());
                        if (oItemSplitNote != null)
                        {
                            if (!oItemSplitNote.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        oItemSplitNote.IsApproved = true;
                                        oItemSplitNote.DateApproved = clsSecurity.getServerDateTime();
                                        oItemSplitNote.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                        oItemSplitNote.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                        oItemSplitNote.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    }
                                    frmTwoStepVerify.Close();
                                }
                                ClearFields();
                                RefreshGrid();
                                FillDetails(oItemSplitNote.Split_ID);
                            }
                            else
                            {
                                SEACCMessageBox.Show("Alreay Approved", "Selected Split Note has already been approved", MessageBoxButton.OK, "Red");
                            }
                        }
                    }
                }
            }
        }

        #region Input Item Grid Buttons
        private void BtnInputItem_GridItemAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (txtProdSection.Tag != null)
            {
                frm_search frmInputItemSearch = new frm_search();
                frmInputItemSearch.Show(Digiteq_Logic.Search.ItemMasterByCompanyBranchID, true);
                frmInputItemSearch.RowSelected += Frm_Inputs_Search_RowSelected;
            }
            else
            {
                SEACCMessageBox.Show("Production section not selected...", "Please select a production section...", MessageBoxButton.OK, "Red");
            }
        }

        private void BtnInput_GridItemDelete_OnClick(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrInput_Item.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrInput_Item.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] drInputs = dtInputs.Select("LineNo ='" + sLineNo + "'");
                if (drInputs.Length > 0)
                {
                    foreach (DataRow drInput in drInputs)
                    {
                        foreach (DataRow drOutput in dtOutputs.Select("Input_ItemID ='" + drInput["Input_ItemID"] + "'"))
                            dtOutputs.Rows.Remove(drOutput);

                        dtInputs.Rows.Remove(drInput);
                    }
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtInputs);
                clsHelpMethods_Prod.OrderBy_DataGrid(dtOutputs);
            }
        }
        #endregion

        #region Output Item Grid Buttons

        private void btnOutputItem_GridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtProdSection.Tag != null)
            {
                frm_search frmOutputItemSearch = new frm_search();
                frmOutputItemSearch.Show(Digiteq_Logic.Search.ItemMasterByCompanyBranchID, true);
                frmOutputItemSearch.RowSelected += FrmOutputItemSearchOnRowSelected;
            }
            else
            {
                SEACCMessageBox.Show("Production section not selected...", "Please select a production section...", MessageBoxButton.OK, "Red");
            }
        }

        private void btnOutput_GridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgrOutput_Item.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgrOutput_Item.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock)?.Text;
                DataRow[] drOutputs = dtOutputs.Select("LineNo ='" + sLineNo + "'");
                if (drOutputs.Length > 0)
                {
                    foreach (DataRow drOutput in drOutputs)
                    {
                        foreach (DataRow drInput in dtInputs.Select("Output_ItemID ='" + drOutput["Output_ItemID"] + "'"))
                            dtInputs.Rows.Remove(drInput);

                        dtOutputs.Rows.Remove(drOutput);
                    }
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtOutputs);
                clsHelpMethods_Prod.OrderBy_DataGrid(dtInputs);
            }
        }

        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSpliteNote_ID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProdSection, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtSpliteNote_ID.Tag = null;
            txtProdSection.Tag = null;

            txtSpliteNote_ID.Text = "";
            txtProdSection.Text = "";
            txtRemark.Text = "";

            dtpSplitNoteDate.SetTime(clsSecurity.getServerDateTime());

            dtInputs.Clear();
            dgrInput_Item.ItemsSource = dtInputs.DefaultView;

            dtOutputs.Clear();
            dgrOutput_Item.ItemsSource = dtOutputs.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSpliteNote_ID.setReadOnlyStatus(true);
                txtSpliteNote_ID.Text = "<Auto Generate>";
            }
            else
                txtSpliteNote_ID.setReadOnlyStatus(false);
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
                foreach (tbl_prod_pharmaTxItemSplitNote oSplitNote in tbl_prod_pharmaTxItemSplitNote.SelectAll().Where(p => p.Split_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oSplitNote.Split_ID, oSplitNote.Split_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_User(oSplitNote.CreateUser_ID), clsGenaralName.getName_User(oSplitNote.ApprovedUser_ID), oSplitNote.IsCanceled);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField()) 
                    if (CheckInputOutputs())
                        if (CheckFloorStock())
                            if (CheckValidity_DuplicateFiled())
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtSpliteNote_ID.Text))
                                bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtSpliteNote_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtProdSection))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
        {
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtSpliteNote_ID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtSpliteNote_ID.Text = txtSpliteNote_ID.Tag.ToString();
                }
            }
            return true;
        }

        private bool CheckInputOutputs()
        {
            bool bSelectOutputSection = true;
            if (dtInputs.Rows.Count <= 0)
            {
                bSelectOutputSection = false;
                SEACCMessageBox.Show("Oops..!", "Please Select Input Items....", MessageBoxButton.OK, "Red");
            }
            else if (dtOutputs.Rows.Count <= 0)
            {
                bSelectOutputSection = false;
                SEACCMessageBox.Show("Oops..!", "Please Select Output Items....", MessageBoxButton.OK, "Red");
            }
            return bSelectOutputSection;
        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            DataTable dtFloorStock = new DataTable();
            dtFloorStock = clsHelpMethods_Prod.GetItemGroupedItemFloorstockTable(dtInputs, "Input_ItemID", "InputQty", clsGenaralName.getStoreID_Section(txtProdSection.Tag.ToString()));

            if (SEACC_Form.IsUpdateMode)
            {
                foreach (DataRow dr in dtFloorStock.Rows)
                {
                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                    dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_prod_pharmaTxItemSplitNote_Input.SelectAllBySplit_ID(txtSpliteNote_ID.Text).Where(r => r.Item_ID == sItem_ID).Sum(x => x.InputQty), clsConfig.sDecimalPlaces_Quantity);
                }
            }

            bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);

            return bReturn;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sSpliNote_ID)
        {
            try
            {
                tbl_prod_pharmaTxItemSplitNote oSplitNote = tbl_prod_pharmaTxItemSplitNote.Select(sSpliNote_ID);
                if (oSplitNote != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSpliteNote_ID.Tag = oSplitNote.Split_ID;
                    txtProdSection.Tag = tbl_genSectionMaster.SelectAllByStore_ID(oSplitNote.Store_ID).FirstOrDefault()?.Section_ID;

                    txtSpliteNote_ID.Text = oSplitNote.Split_ID;
                    if (txtProdSection.Tag != null)
                        txtProdSection.Text = clsGenaralName.getName_Section(txtProdSection.Tag.ToString());
                    txtRemark.Text = oSplitNote.Remark;

                    dtpSplitNoteDate.SetTime(oSplitNote.Split_Date);

                    foreach (tbl_prod_pharmaTxItemSplitNote_Input oInput in tbl_prod_pharmaTxItemSplitNote_Input.SelectAllBySplit_ID(oSplitNote.Split_ID))
                    {
                        dtInputs.Rows.Add(oInput.Line_No,
                            oInput.LinkedOutputItem_ID, //Manually Add Input Items
                            clsGenaralName.getName_Item(oInput.LinkedOutputItem_ID), //Manually Add Input Items
                            oInput.Item_ID,
                            clsGenaralName.getName_Item(oInput.Item_ID),
                            oInput.Uom_ID,
                            clsGenaralName.getName_Uom(oInput.Uom_ID),
                            oInput.InputQtyRate, //Manually Add Input Items
                            cls_Formater.FormatDecimal(oInput.InputQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oInput.FloorQty, clsConfig.sDecimalPlaces_Quantity)
                        );
                    }

                    foreach (tbl_prod_pharmaTxItemSplitNote_Output oOutput in tbl_prod_pharmaTxItemSplitNote_Output.SelectAllBySplit_ID(oSplitNote.Split_ID))
                    {
                        dtOutputs.Rows.Add(oOutput.Line_No,
                            oOutput.LinkedInputItem_ID, //Manually Add Input Items
                            clsGenaralName.getName_Item(oOutput.LinkedInputItem_ID), //Manually Add Input Items
                            oOutput.Item_ID,
                            clsGenaralName.getName_Item(oOutput.Item_ID),
                            oOutput.Uom_ID,
                            clsGenaralName.getName_Uom(oOutput.Uom_ID),
                            oOutput.OutputQtyRate, //Manually Add Input Items
                            cls_Formater.FormatDecimal(oOutput.OutputQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oOutput.FloorQty, clsConfig.sDecimalPlaces_Quantity)
                        );
                    }


                    if (oSplitNote.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oSplitNote.IsChecked)
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

        #region Main Grid

        private void Dgr_Main_OnMouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string sSplitId = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;
                    ClearFields();
                    FillDetails(sSplitId);
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
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[5].ToString()))
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

        #region Output Grid

        private void dgrOutput_Mats_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sSortMemberPath = e.Column.SortMemberPath;
            object item = dgrOutput_Item.SelectedItem;
            string sItem = (dgrOutput_Item.SelectedCells[3].Column.GetCellContent(item) as TextBlock)?.Text;

            switch (sSortMemberPath)
            {
                case "OutputQty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;
                    try
                    {
                        if (t != null) dQty = decimal.Parse(t.Text);
                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }

                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                    UpdateInputItemQty(sItem);
                    break;
            }
        }

        private void DgrOutputs_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtOutputs);
        }

        #endregion

        #region Input Item
        private void dgrInput_Item_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sSortMemberPath = e.Column.SortMemberPath;
            object item = dgrInput_Item.SelectedItem;
            string sItem = (dgrInput_Item.SelectedCells[3].Column.GetCellContent(item) as TextBlock)?.Text;

            switch (sSortMemberPath)
            {
                case "InputQty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;
                    try
                    {
                        if (t != null) dQty = decimal.Parse(t.Text);
                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }

                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                    UpdateOuputItemQty(sItem);
                    break;
            }
        }

        private void DgrInputs_OnLoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtInputs);
        }
        #endregion

        #endregion

        #region Search Events
        private void TxtProdSection_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtProdSection.Tag = lstResult[0];
                txtProdSection.Text = lstResult[1];
            }
        }

        private void Frm_Inputs_Search_RowSelected(List<string> lstResult)
        {
            try
            {
                Cursor = Cursors.Wait;

                bool bAddItem = false;
                DataRow[] items = dtInputs.Select("Input_ItemID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    SEACCMessageBox.Show("Item Already Exist in Line No: " + sLineNo, "You can not add it again.", MessageBoxButton.OK, "Red");
                }

                if (bAddItem)
                {
                    dtInputs.Rows.Add("0",
                        "default", //Manually Add Input Items
                        "",        //Manually Add Input Items
                        lstResult[0],
                        lstResult[1],
                        clsGenaralName.getName_ItemUOMID(lstResult[0]),
                        clsGenaralName.getName_ItemUOMName(lstResult[0]),
                        "0", //Manually Add Input Items
                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), lstResult[0]), clsConfig.sDecimalPlaces_Quantity)
                        );

                    string sBoM_ID = clsHelpMethods_Prod.GetBoM_formFinishedGood(lstResult[0]);
                    foreach (tbl_prod_pharmaTxJobCard_Material oMaterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(p => p.Line_No_Sub1 == 0 && p.Line_No_Sub2 == 0))
                    {
                        dtOutputs.Rows.Add("0",
                            lstResult[0], //Automatically Add Output Items
                            lstResult[1], //Automatically Add Output Items
                            oMaterial.Item_ID,
                            clsGenaralName.getName_Item(oMaterial.Item_ID),
                            oMaterial.Uom_ID,
                            clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                            oMaterial.TotalInputQty, //Automatically Add Output Items
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), oMaterial.Item_ID), clsConfig.sDecimalPlaces_Quantity)
                        );
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

        private void FrmOutputItemSearchOnRowSelected(List<string> lstResult)
        {
            try
            {
                Cursor = Cursors.Wait;

                bool bAddItem = false;
                DataRow[] items = dtOutputs.Select("Output_ItemID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    SEACCMessageBox.Show("Item Already Exist in Line No: " + sLineNo, "You can not add it again.", MessageBoxButton.OK, "Red");
                }

                if (bAddItem)
                {
                    dtOutputs.Rows.Add("0",
                        "default", //Manually Add Output Items
                        "", //Manually Add Output Items
                        lstResult[0],
                        lstResult[1],
                        clsGenaralName.getName_ItemUOMID(lstResult[0]),
                        clsGenaralName.getName_ItemUOMName(lstResult[0]),
                        0, //Manually Add Output Items
                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), lstResult[0]), clsConfig.sDecimalPlaces_Quantity)
                    );

                    string sBoM_ID = clsHelpMethods_Prod.GetBoM_formFinishedGood(lstResult[0]);
                    foreach (tbl_prod_pharmaTxJobCard_Material oMaterial in tbl_prod_pharmaTxJobCard_Material
                        .SelectAllByProdJob_ID(sBoM_ID).Where(p => p.Line_No_Sub1 == 0 && p.Line_No_Sub2 == 0))
                    {
                        dtInputs.Rows.Add("0",
                            lstResult[0], //Automatically Add Input Items
                            lstResult[1], //Automatically Add Input Items
                            oMaterial.Item_ID,
                            clsGenaralName.getName_Item(oMaterial.Item_ID),
                            oMaterial.Uom_ID,
                            clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                            oMaterial.TotalInputQty, //Automatically Add Input Items
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtProdSection.Tag.ToString(), oMaterial.Item_ID), clsConfig.sDecimalPlaces_Quantity)
                        );
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

        #endregion

        #region Key Event
        private void SEACC_Form_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

        #region Help Methods
        private void UpdateOuputItemQty(string sItem_ID)
        {
            foreach (DataRow drRowOutput in dtOutputs.Select("Input_ItemID = '" + sItem_ID + "' "))
            {
                decimal dQtyInput = 0;

                DataRow drRowInput = dtInputs.Select("Input_ItemID ='" + drRowOutput["Input_ItemID"] + "'").FirstOrDefault();
                if (drRowInput != null)
                    dQtyInput = clsValidation.Validate_DecimalNumber(drRowInput["InputQty"].ToString());

                decimal dQtyInputRate = clsValidation.Validate_DecimalNumber(drRowOutput["OutputQtyRate"].ToString());
                drRowOutput["OutputQty"] = cls_Formater.FormatDecimal(dQtyInputRate * dQtyInput, clsConfig.sDecimalPlaces_Quantity);
            }
        }

        private void UpdateInputItemQty(string sItem_ID)
        {
            foreach (DataRow drRowInput in dtInputs.Select("Output_ItemID = '" + sItem_ID + "' "))
            {
                decimal dQtyOutput = 0;

                DataRow drRowOutput = dtOutputs.Select("Output_ItemID ='" + drRowInput["Output_ItemID"] + "'").FirstOrDefault();
                if (drRowOutput != null)
                    dQtyOutput = clsValidation.Validate_DecimalNumber(drRowOutput["OutputQty"].ToString());

                decimal dQtyInputRate = clsValidation.Validate_DecimalNumber(drRowInput["InputQtyRate"].ToString());
                drRowInput["InputQty"] = cls_Formater.FormatDecimal(dQtyInputRate * dQtyOutput, clsConfig.sDecimalPlaces_Quantity);
            }
        }

        private void SplitNote_InsertDetails()
        {
            foreach (DataRow row in dtInputs.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sOutput_ItemID = clsValidate.ValidateRowValue(row, "Output_ItemID", "default");
                string sInput_ItemID = clsValidate.ValidateRowValue(row, "Input_ItemID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dInputQtyRate = clsValidate.ValidateRowValue(row, "InputQtyRate", 0m);
                decimal dInputQty = clsValidate.ValidateRowValue(row, "InputQty", 0m);
                decimal dFloorQty = clsValidate.ValidateRowValue(row, "FloorQty", 0m);

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sInput_ItemID);
                tbl_genItemMaster_Pricing oItemFinance = tbl_genItemMaster_Pricing.Select(sInput_ItemID);
                if (oItemFinance != null)
                {
                    dUnitPrice = oItemFinance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dInputQty;
                }

                tbl_prod_pharmaTxItemSplitNote_Input oInput = new tbl_prod_pharmaTxItemSplitNote_Input(iLine_no, txtSpliteNote_ID.Text, sInput_ItemID, sUoM_ID, dFloorQty, dInputQtyRate , dInputQty, 0, dUnitPrice, 0, dTotalAmount,"", sOutput_ItemID);
                oInput.Insert();

                clsHelpMethods_Prod.UpdateSectionFloorStock(txtProdSection.Tag.ToString(), sInput_ItemID, -dInputQty);
            }

            foreach (DataRow row in dtOutputs.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sInput_ItemID = clsValidate.ValidateRowValue(row, "Input_ItemID", "default");
                string sOutput_ItemID = clsValidate.ValidateRowValue(row, "Output_ItemID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dOutputQtyRate = clsValidate.ValidateRowValue(row, "OutputQtyRate", 0m);
                decimal dOutputQty = clsValidate.ValidateRowValue(row, "OutputQty", 0m);
                decimal dFloorQty = clsValidate.ValidateRowValue(row, "FloorQty", 0m);


                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sInput_ItemID);
                tbl_genItemMaster_Pricing oItemFinance = tbl_genItemMaster_Pricing.Select(sInput_ItemID);
                if (oItemFinance != null)
                {
                    dUnitPrice = oItemFinance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dOutputQty;
                }

                tbl_prod_pharmaTxItemSplitNote_Output oOutput = new tbl_prod_pharmaTxItemSplitNote_Output(iLine_no, txtSpliteNote_ID.Text, sOutput_ItemID, sUoM_ID, dFloorQty, dOutputQtyRate, dOutputQty, 0, dUnitPrice, 0, dTotalAmount, "", sInput_ItemID);
                oOutput.Insert();

                clsHelpMethods_Prod.UpdateSectionFloorStock(txtProdSection.Tag.ToString(), sOutput_ItemID, dOutputQty);
            }
        }
        #endregion

    }
}
