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
    /// Developped By Gayan
    /// 2017-05-23
    /// </summary>
    public partial class UC_Production_GoodsIssues_MultipleMR : UserControl
    {
        #region Class Variables
        DataTable dtMeterials = new DataTable();
        DataTable dtMeterials_summary = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_Production_GoodsIssues_MultipleMR()
        {
            #region Initialize User Control
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_GoodsIssues;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region Meterial Data Table
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("MR_No");
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("Batch_No");
            dtMeterials.Columns.Add("Item_ID");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("StoreBalance_Qty");
            dtMeterials.Columns.Add("PGIN_Qty");
            dtMeterials.Columns.Add("MR_Qty");
            dtMeterials.Columns.Add("PrvPGIN_Qty");
            dtMeterials.Columns.Add("Balance_Qty");
            #endregion

            #region Material Summary Data Table
            dtMeterials_summary.Columns.Add("LineNo", typeof(int));
            dtMeterials_summary.Columns.Add("Item_ID");
            dtMeterials_summary.Columns.Add("ItemName");
            dtMeterials_summary.Columns.Add("UoM_ID");
            dtMeterials_summary.Columns.Add("UoM");
            dtMeterials_summary.Columns.Add("PGIN_TotQty");
            dtMeterials_summary.Columns.Add("Edited_Qty");
            #endregion

            #region Main Data Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("PGIN_NO");
            dgr_Main.dt.Columns.Add("PGIN_DATE");
            dgr_Main.dt.Columns.Add("ISSUED_LOCATION");
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("pGIN No", "PGIN_NO", 80);
            dgr_Main.Add_DatagridColoumn("pGIN Date", "PGIN_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Issued Store", "ISSUED_LOCATION", 150);
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
                            tbl_prodTxGoodIssueNote oOldPGIN = tbl_prodTxGoodIssueNote.Select(txtPGINId.Tag.ToString());
                            if (oOldPGIN != null)
                            {
                                if (!oOldPGIN.IsApproved && !oOldPGIN.IsCanceled)
                                {
                                    tbl_prodTxGoodIssueNote oPGIN = new tbl_prodTxGoodIssueNote(txtPGINId.Tag.ToString(), dtpPGIN_Date.GetDateTime(),
                                    txtIssuedStore.Tag != null ? txtIssuedStore.Tag.ToString() : "default",
                                    txtOrderedBy.Tag != null ? txtOrderedBy.Tag.ToString() : "default",
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
                                        tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(oMat.Mr_No);
                                        if (oMR != null)
                                        {
                                            clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                            clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                        }
                                        oMat.Delete();
                                    }

                                    PGIN_InsertMaterials();
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
                                   txtItemsCollectedBy.Tag != null ? txtItemsCollectedBy.Tag.ToString() : "default", "",
                                  false, false, false,
                                   clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                   clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                   clsSecurity.TerminalID, "default", "default", "default", "default",
                                   clsSecurity.CompanyID, clsSecurity.BranchID
                                   );
                            oPGIN.Insert();

                            PGIN_InsertMaterials();
                            sPGIN_No = oPGIN.PGIN_No;
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
                    if (txtPGINId.Tag != null)
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
                                                    tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(oMat.Mr_No);
                                                    if (oMR != null)
                                                    {
                                                        clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, oMat.Item_ID, -oMat.PGIN_Qty);
                                                        clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), oMat.Item_ID, oMat.PGIN_Qty);
                                                    }
                                                }

                                                oPGIN.Update();
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPGINId, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtIssuedStore, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMR.txtLabelTextBox, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtOrderedBy, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtItemsCollectedBy, true, false, true);

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

            txtMR.SearchEmunId = (int)Digiteq_Logic.Search.Prod_ProductionMeterialRequisition;
            txtMR.lstSearchParam.Add("");
            txtMR.SelectedList = null;

            dtpPGIN_Date.SetTime(DateTime.Now);

            dtMeterials.Clear();
            DataView dv = dtMeterials.DefaultView;
            dv.Sort = "Item_ID , MR_No";
            dgr_Meterial.ItemsSource = dv;

            dtMeterials_summary.Clear();
            dgr_MeterialSumary.ItemsSource = dtMeterials_summary.DefaultView;

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
                dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_PGINDetails").Tables[0]);
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
                if (Check_MinusPGIN_Qty())
                    if (Check_ZeroPGIN_Qty())
                        if (CheckFloorStock())
                            if (CheckValidity_DuplicateFiled())
                                if (clsValidate.CheckValidity_TransactionCodeLength(txtPGINId.Text))
                                    bStatus = true;

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtPGINId))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtIssuedStore))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMR.txtLabelTextBox))
                bStatus = false;

            return bStatus;
        }

        private bool CheckValidity_DuplicateFiled()
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

        private bool Check_MinusPGIN_Qty()
        {
            bool bReturn = true;
            string sMinusQty_Items = "";

            foreach (DataRow dr in dtMeterials.Rows)
            {
                decimal dPGIN_Qty = clsValidate.ValidateRowValue(dr, "PGIN_Qty", 0m);

                if (dPGIN_Qty < 0)
                {
                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(dr, "LineNo", 0));
                    string sItem_Name = clsValidate.ValidateRowValue(dr, "ItemName", "-");
                    sMinusQty_Items += "Line No : " + iLine_no + "  Item Name : " + sItem_Name + "\n";
                }
            }

            if (sMinusQty_Items.Length < 1)
            {
                bReturn = true;
            }
            else
            {
                bReturn = false;
                SEACCMessageBox.Show("Something Went Wrong...", "PGIN Qty. of Following Material(s) is less than zero \n" + sMinusQty_Items, MessageBoxButton.OK, "#FF5B6B76");
            }

            return bReturn;
        }

        private bool Check_ZeroPGIN_Qty()
        {
            bool bReturn = true;
            string sZeroQty_Items = "";

            foreach (DataRow dr in dtMeterials.Rows)
            {
                decimal dPGIN_Qty = clsValidate.ValidateRowValue(dr, "PGIN_Qty", 0m);

                if (dPGIN_Qty == 0)
                {
                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(dr, "LineNo", 0));
                    string sItem_Name = clsValidate.ValidateRowValue(dr, "ItemName", "-");
                    sZeroQty_Items += "Line No : " + iLine_no + "  Item Name : " + sItem_Name + "\n";
                }
            }

            if (sZeroQty_Items.Length < 1)
                bReturn = true;
            else
                bReturn = SEACCMessageBox.Show("Are you sure to continue ?", "PGIN Qty. of Following Material(s) is not valid \n" + sZeroQty_Items, MessageBoxButton.YesNo, "#FF5B6B76");


            return bReturn;
        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            DataTable dtFloorStock = new DataTable();
            dtFloorStock = clsHelpMethods_Prod.Get_ItemGroupedItemFloorstockTable(dtMeterials, "PGIN_Qty", txtIssuedStore.Tag.ToString());

            if (SEACC_Form.IsUpdateMode)
            {
                foreach (DataRow dr in dtFloorStock.Rows)
                {
                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                    dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_prodTxGoodIssueNote_Material.SelectAllByPGIN_No(txtPGINId.Text).Where(r => r.Item_ID == sItem_ID).Sum(x => x.PGIN_Qty), clsConfig.sDecimalPlaces_Quantity);
                }
            }

            bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);

            return bReturn;
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
                    txtItemsCollectedBy.Tag = oPGIN.ItemCollectedBy;

                    dtpPGIN_Date.SetTime(oPGIN.PGIN_Date);

                    txtPGINId.Text = oPGIN.PGIN_No;
                    txtIssuedStore.Text = clsGenaralName.getName_Store(oPGIN.Store_ID);
                    txtOrderedBy.Text = clsGenaralName.getName_Employee(oPGIN.Ordered_HOD);
                    txtItemsCollectedBy.Text = clsGenaralName.getName_Employee(oPGIN.ItemCollectedBy);

                    if (oPGIN.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oPGIN.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    fillMaterialGrid_form_PGIN(sID);

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fillMaterialGrid_form_MR(DataRow[] drMR_Nos, string sStore_ID)
        {
            try
            {
                foreach (var vMR_No in drMR_Nos)
                {
                    string sMR_No = vMR_No["MR_No"].ToString();
                    foreach (tbl_prodTxMaterialRequision_Material oMaterial in tbl_prodTxMaterialRequision_Material.SelectAllByMr_No(sMR_No).Where(r => r.Store_ID == sStore_ID))
                    {
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMaterial.Item_ID);
                        decimal dstockQty = 0, dPrvIssuedPGINQty = 0, dPGIN_Qty = oMaterial.Mr_Qty, dBalanceQty = 0;
                        if (oItem != null)
                        {
                            dstockQty = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(txtIssuedStore.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                            dPrvIssuedPGINQty = AlreadyIssuedQty_formPGINs_AgainstMR(sMR_No, oMaterial.Item_ID, sStore_ID);

                            if (oMaterial.Mr_Qty > dPrvIssuedPGINQty)
                                dBalanceQty = oMaterial.Mr_Qty - dPrvIssuedPGINQty;

                            dPGIN_Qty -= dPrvIssuedPGINQty;
                            if (dPGIN_Qty < 0)
                                dPGIN_Qty = 0;
                        }
                        dtMeterials.Rows.Add("0", sMR_No, oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID, oMaterial.Item_ID,
                            clsGenaralName.getName_Item(oMaterial.Item_ID), oMaterial.Uom_ID,
                            clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                            cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity),
                            (dstockQty > dPGIN_Qty ? cls_Formater.FormatDecimal(dPGIN_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity)),
                            cls_Formater.FormatDecimal(oMaterial.Mr_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(dPrvIssuedPGINQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(dBalanceQty, clsConfig.sDecimalPlaces_Quantity));
                    }
                }

                Refresh_PGIN_Summary();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void fillMaterialGrid_form_PGIN(string sPGIN_No)
        {
            var vPGIN_Mats = tbl_prodTxGoodIssueNote_Material.SelectAllByPGIN_No(sPGIN_No).OrderBy(r => clsGenaralName.getName_Item(r.Item_ID));
            foreach (tbl_prodTxGoodIssueNote_Material oMaterial in vPGIN_Mats)
            {
                tbl_prodTxMaterialRequision_Material oMR_Material = tbl_prodTxMaterialRequision_Material.SelectAllByMr_No(oMaterial.Mr_No).Where(r => r.Item_ID == oMaterial.Item_ID && r.ProdJob_ID == oMaterial.ProdJob_ID).FirstOrDefault();
                decimal dstockQty = oMaterial.StoreBalance_Qty, dBalanceQty = 0;

                if (oMR_Material.Mr_Qty > oMaterial.Issued_Qty)
                    dBalanceQty = oMR_Material.Mr_Qty - oMaterial.Issued_Qty;

                dtMeterials.Rows.Add("0", oMaterial.Mr_No, oMaterial.ProdJob_ID, oMaterial.ProdBatch_ID, oMaterial.Item_ID,
                    clsGenaralName.getName_Item(oMaterial.Item_ID), oMaterial.Uom_ID, clsGenaralName.getName_Uom(oMaterial.Uom_ID),
                    cls_Formater.FormatDecimal(dstockQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oMaterial.PGIN_Qty, clsConfig.sDecimalPlaces_Quantity),
                    oMR_Material != null ? cls_Formater.FormatDecimal(oMR_Material.Mr_Qty, clsConfig.sDecimalPlaces_Quantity) : cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oMaterial.Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(dBalanceQty, clsConfig.sDecimalPlaces_Quantity));
            }

            #region Selected MRs
            DataTable dtMRs = new DataTable();
            dtMRs.Columns.Add("mr_No");
            string sMR_Nos = "";
            foreach (var vMR in vPGIN_Mats.GroupBy(e => new { mrn = e.Mr_No }).Select(g => g.FirstOrDefault()))
            {
                if (sMR_Nos.Length > 3)
                    sMR_Nos += ", " + vMR.Mr_No;
                else
                    sMR_Nos = vMR.Mr_No;
                dtMRs.Rows.Add(vMR.Mr_No);
            }
            txtMR.Text = sMR_Nos;
            txtMR.SelectedList = dtMRs.Select();
            #endregion

            Refresh_PGIN_Summary();
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

        #region Meterial Grid
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials, "Item_ID", "MR_No");
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

                        if (dQty >= 0)
                        {
                            string sStock_Qty = (dgr_Meterial.SelectedCells[8].Column.GetCellContent(item) as TextBlock)?.Text;
                            decimal dStock_Qty = clsValidation.Validate_DecimalNumber(sStock_Qty);
                            if (dStock_Qty < dQty)
                            {
                                dQty = dStock_Qty;
                                SEACCMessageBox.Show("Oops..!", "Store Balance Quantity : " + dStock_Qty + "\nQuantity should be less than or equal to Store Balance Quantity", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            dQty = 0;
                            SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity...", MessageBoxButton.OK, "Red");
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                Refresh_PGIN_Summary();
            }
        }
        #endregion

        #region Material Summary Grid
        private void dgr_MeterialSumary_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials_summary);
        }
        private void dgr_MeterialSumary_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            int irowID = dgr_MeterialSumary.SelectedIndex;
            TextBox t;

            if (sColumnName == "Edited_Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                string sItem_ID = "";
                try
                {
                    object item = dgr_MeterialSumary.SelectedItem;
                    if (item != null)
                    {
                        dQty = clsValidation.Validate_DecimalNumber(t.Text);
                        if (dQty >= 0)
                        {
                            sItem_ID = (dgr_MeterialSumary.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;

                            Fill_PGIN_DetailQty_FromSummary(sItem_ID, dQty);
                        }
                        else
                        {
                            dQty = 0;
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

        private void txtMR_SearchBoxClose()
        {
            string sText = "";
            foreach (var dr in txtMR.SelectedList)
            {
                if (sText.Length == 0)
                    sText = dr["mr_No"].ToString();
                else
                    sText += ", " + dr["mr_No"].ToString();
            }
            txtMR.Text = sText;

            if (txtIssuedStore.Tag != null)
            {
                dtMeterials_summary.Clear();
                dtMeterials.Clear();
                fillMaterialGrid_form_MR(txtMR.SelectedList, txtIssuedStore.Tag.ToString());
            }
        }

        private void txtIssuedLocation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtMR.SelectedList != null && txtMR.SelectedList.Length > 0)
            {
                List<string> lstParameeters = new List<string>();
                string sParms = "";
                foreach (var dr in txtMR.SelectedList)
                {
                    if (sParms.Length == 0)
                        sParms += "'" + dr["mr_No"].ToString() + "'";
                    else
                        sParms += ", '" + dr["mr_No"].ToString() + "'";
                }
                lstParameeters.Add("(" + sParms + ")");

                frm_search RowDataSearch = new frm_search(lstParameeters);
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMR_Stores);//8117
                if (RowDataSearch.DialogResult == true)
                {
                    txtIssuedStore.Tag = lstResult[0];
                    txtIssuedStore.Text = lstResult[1];

                    dtMeterials_summary.Clear();
                    dtMeterials.Clear();
                    fillMaterialGrid_form_MR(txtMR.SelectedList, lstResult[0]);
                }
            }
            else
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
                if (RowDataSearch.DialogResult == true)
                {
                    txtIssuedStore.Tag = lstResult[0];
                    txtIssuedStore.Text = lstResult[1];

                    txtMR.lstSearchParam.Clear();
                    txtMR.lstSearchParam.Add(lstResult[0]);
                }
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
        private void PGIN_InsertMaterials()
        {
            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                string sItemID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dStoreBalance_Qty = clsValidate.ValidateRowValue(row, "StoreBalance_Qty", 0m);
                decimal dPGIN_Qty = clsValidate.ValidateRowValue(row, "PGIN_Qty", 0m);
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                string sMR_No = clsValidate.ValidateRowValue(row, "MR_No", "default");
                decimal dIssuedPGIN_Qty = clsValidate.ValidateRowValue(row, "PrvPGIN_Qty", 0m);

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItemID);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dPGIN_Qty;
                }

                tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(sMR_No);
                if (oMR != null)
                {
                    tbl_prodTxGoodIssueNote_Material oPGIN_Materials = new tbl_prodTxGoodIssueNote_Material(iLine_no, txtPGINId.Tag.ToString(), sItemID, sUoM_ID, dIssuedPGIN_Qty, dStoreBalance_Qty, dPGIN_Qty, 0, dUnitPrice, 0, dTotalAmount, false, "", sBoM_No, sBatch_No, sMR_No);
                    oPGIN_Materials.Insert();
                    clsHelpMethods_Prod.UpdateStock(txtIssuedStore.Tag.ToString(), sItemID, -dPGIN_Qty);
                    clsHelpMethods_Prod.UpdateSectionFloorStock(oMR.Section_ID, sItemID, dPGIN_Qty);
                }
            }
        }

        private void Refresh_PGIN_Summary()
        {
            try
            {
                dtMeterials_summary.Rows.Clear();
                var newResults = from row in dtMeterials.AsEnumerable()
                                 group row by new
                                 {
                                     ItemID = row.Field<string>("Item_ID"),
                                     ItemName = row.Field<string>("ItemName"),
                                     UoM_ID = row.Field<string>("UoM_ID"),
                                     UoM = row.Field<string>("UoM")
                                 } into grp
                                 select new
                                 {
                                     Item_ID = grp.Key.ItemID,
                                     ItemName = grp.Key.ItemName,
                                     UoM_ID = grp.Key.UoM_ID,
                                     UoM = grp.Key.UoM,
                                     Quantity = grp.Sum((r) => decimal.Parse(r["PGIN_Qty"].ToString())),
                                     EditedQuantity = grp.Sum((r) => decimal.Parse(r["PGIN_Qty"].ToString())),
                                 };

                foreach (var record in newResults.OrderBy(r => r.Item_ID))
                    dtMeterials_summary.Rows.Add("0", record.Item_ID, record.ItemName, record.UoM_ID, record.UoM, record.Quantity, record.EditedQuantity);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_PGIN_DetailQty_FromSummary(string sItemID, decimal dQty)
        {
            try
            {
                var vFilterItem = dtMeterials.AsEnumerable().Where(p => p.Field<string>("Item_ID") == sItemID).OrderBy(p => p.Field<int>("LineNo"));
                int i = 1;
                foreach (DataRow dr in vFilterItem)
                {
                    decimal dBalanceQty = clsValidation.Validate_DecimalNumber(dr["Balance_Qty"].ToString());

                    //---------------------------------------------------------
                    if (dBalanceQty >= 0 && dQty >= 0 && dBalanceQty <= dQty)
                        dr["PGIN_Qty"] = dBalanceQty;
                    else if (dQty < 0 || dBalanceQty < 0)
                        dr["PGIN_Qty"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    else
                        dr["PGIN_Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                    //---------------------------------------------------------

                    //----------------------------------
                    if (i == vFilterItem.Count())
                        dr["PGIN_Qty"] = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
                    else
                        dQty -= dBalanceQty;
                    //----------------------------------

                    //------------------------------------------------------------
                    string sFinal_PGIN_Qty = dr["PGIN_Qty"].ToString();
                    decimal dFinal_PGIN_Qty = clsValidation.Validate_DecimalNumber(sFinal_PGIN_Qty);
                    if (dFinal_PGIN_Qty < 0)
                        dr["PGIN_Qty"] = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
                    //------------------------------------------------------------

                    i++;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private decimal AlreadyIssuedQty_formPGINs_AgainstMR(string sMR_ID, string sItem_ID, string sStore_ID)
        {
            string sQty = "0";
            try
            {
                string sQuary = "select [dbo].[GetPrvPGIN_Qty] ('" + sMR_ID + "', '" + sItem_ID + "' , '" + sStore_ID + "')";
                sQty = DBHandling.ExecQuery_ReturnString(sQuary);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            return clsValidation.Validate_DecimalNumber(sQty);
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

    }
}
