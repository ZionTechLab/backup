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
    /// Interaction logic for UC_SubContractIn.xaml
    /// </summary>
    public partial class UC_SubContract_Out : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        DataTable dtSemiFinishedItems = new DataTable();
        DataTable dtMeterials = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_SubContract_Out()
        {
            #region Initialize User Control
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ProdPharma_SubContract_Out;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table

            #region BoM Table Initialize
            dtBoM.Columns.Add("LineNo", typeof(int));
            dtBoM.Columns.Add("IsSelect");
            dtBoM.Columns.Add("BoM_No");
            dtBoM.Columns.Add("Batch_No");
            dtBoM.Columns.Add("FG_ItemID");
            dtBoM.Columns.Add("FG_Item");
            dtBoM.Columns.Add("FG_UoM");
            dtBoM.Columns.Add("FG_Qty");
            dtBoM.Columns.Add("Customer");
            dtBoM.Columns.Add("COQty");
            dtBoM.Columns.Add("CO_ID");
            dtBoM.Columns.Add("SOut_Qty");
            #endregion

            #region Semi Finished 
            dtSemiFinishedItems.Columns.Add("LineNo", typeof(int));
            dtSemiFinishedItems.Columns.Add("IsSelect");
            dtSemiFinishedItems.Columns.Add("BoM_No");
            dtSemiFinishedItems.Columns.Add("Batch_No");
            dtSemiFinishedItems.Columns.Add("SFG_ID");
            dtSemiFinishedItems.Columns.Add("SFG_Item");
            dtSemiFinishedItems.Columns.Add("SFG_UoM_ID");
            dtSemiFinishedItems.Columns.Add("SFG_UoM");
            dtSemiFinishedItems.Columns.Add("RequiredQty");//RequiredQty or BoMQty
            dtSemiFinishedItems.Columns.Add("UndeliveredQty");
            dtSemiFinishedItems.Columns.Add("SubOutQty");
            dtSemiFinishedItems.Columns.Add("ContractorRate");
            dtSemiFinishedItems.Columns.Add("ContractorPrice");
            #endregion

            #region Meterial Table
            dtMeterials.Columns.Add("LineNo", typeof(int));
            dtMeterials.Columns.Add("BoM_No");
            dtMeterials.Columns.Add("Batch_No");
            dtMeterials.Columns.Add("SFG_ID");
            dtMeterials.Columns.Add("SFG_Item");
            dtMeterials.Columns.Add("ItemNo");
            dtMeterials.Columns.Add("ItemName");
            dtMeterials.Columns.Add("UoM_ID");
            dtMeterials.Columns.Add("UoM");
            dtMeterials.Columns.Add("RequiredQty");//RequiredQty or BoMQty
            dtMeterials.Columns.Add("StockQty");
            dtMeterials.Columns.Add("IssuedQty");
            dtMeterials.Columns.Add("BalanceQty");
            dtMeterials.Columns.Add("SONQty");
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("SOUT_NO");
            dgr_Main.dt.Columns.Add("SOUT_DATE");
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
            dgr_Main.Add_DatagridColoumn("Sub Out No", "SOUT_NO", 90);
            dgr_Main.Add_DatagridColoumn("Sub Out Date", "SOUT_DATE", 90);
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
            string sSON_ID = "";
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxSubContractOutNote oOld_SubOUT = tbl_prod_pharmaTxSubContractOutNote.Select(txtSubOutID.Tag.ToString());
                            if (oOld_SubOUT != null)
                            {
                                if (!oOld_SubOUT.IsApproved && !oOld_SubOUT.IsCanceled)
                                {
                                    tbl_prod_pharmaTxSubContractOutNote oSubOUT = new tbl_prod_pharmaTxSubContractOutNote(txtSubOutID.Tag.ToString(), dtpSubOut_Date.GetDateTime(),
                                        txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                        txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                        txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                        oOld_SubOUT.Remark,
                                        oOld_SubOUT.IsChecked, oOld_SubOUT.IsApproved, oOld_SubOUT.IsCanceled,
                                        oOld_SubOUT.CreateUser_ID, clsSecurity.UserIDLoged, oOld_SubOUT.CheckedUser_ID, oOld_SubOUT.ApprovedUser_ID, oOld_SubOUT.CanceldUser_ID,
                                        oOld_SubOUT.DateCreate, clsSecurity.getServerDateTime(), oOld_SubOUT.DateChecked, oOld_SubOUT.DateApproved, oOld_SubOUT.DateCanceled,
                                        oOld_SubOUT.CreateUserTerminal_ID, clsSecurity.TerminalID, oOld_SubOUT.CheckedUserTerminal_ID, oOld_SubOUT.ApprovedUserTerminal_ID, oOld_SubOUT.CanceledUserTerminal_ID,
                                        oOld_SubOUT.CompanyID, oOld_SubOUT.CompanyBranchID
                                        );
                                    oSubOUT.Update();

                                    foreach (tbl_prod_pharmaTxSubContractOutNote_Material oMat in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllBySubOut_ID(oSubOUT.SubOut_ID))
                                    {
                                        if (oMat.Item_ID != oMat.SemiFG_item_ID)
                                            clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oMat.Item_ID, oMat.Son_Qty);

                                        oMat.Delete();
                                    }

                                    tbl_prod_pharmaTxSubContractOutNote_SemiFinished.DeleteAllBySubOut_ID(txtSubOutID.Text);
                                    tbl_prod_pharmaTxSubContractOutNote_JobCard.DeleteAllBySubOut_ID(txtSubOutID.Text);

                                    SOut_InsertMaterials();
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oOld_SubOUT.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Sub-Out has been approved", MessageBoxButton.OK, "Red");
                                    else if (oOld_SubOUT.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Sub-Out has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            sSON_ID = oOld_SubOUT.SubOut_ID;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prod_pharmaTxSubContractOutNote oSubOUT = new tbl_prod_pharmaTxSubContractOutNote(txtSubOutID.Tag.ToString(), dtpSubOut_Date.GetDateTime(),
                                    txtDepartmet.Tag != null ? txtDepartmet.Tag.ToString() : "default",
                                    txtSection.Tag != null ? txtSection.Tag.ToString() : "default",
                                    txtSupplier.Tag != null ? txtSupplier.Tag.ToString() : "default",
                                     ""/*Remark*/,
                                    false, false, false,
                                    clsSecurity.UserIDLoged, "default", "default", "default", "default",
                                    clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                    clsSecurity.TerminalID, "default", "default", "default", "default",
                                    clsSecurity.CompanyID, clsSecurity.BranchID
                                    );
                            oSubOUT.Insert();
                            SOut_InsertMaterials();

                            sSON_ID = oSubOUT.SubOut_ID;
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
                    FillDetails(sSON_ID);
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
                        tbl_prod_pharmaTxSubContractOutNote oSOUT = tbl_prod_pharmaTxSubContractOutNote.Select(txtSubOutID.Tag.ToString());
                        if (oSOUT != null)
                        {
                            if (!oSOUT.IsApproved)
                            {
                                bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                if (bMessegeBoxResult)
                                {
                                    frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                    frmTwoStepVerify.ShowDialog();
                                    if (frmTwoStepVerify.bVerified)
                                    {
                                        oSOUT.IsApproved = true;
                                        oSOUT.DateApproved = clsSecurity.getServerDateTime();
                                        oSOUT.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                        oSOUT.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                        oSOUT.Update();
                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                    }
                                    frmTwoStepVerify.Close();
                                }
                                ClearFields();
                                RefreshGrid();
                                FillDetails(oSOUT.SubOut_ID);
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
                            tbl_prod_pharmaTxSubContractOutNote oSOut = tbl_prod_pharmaTxSubContractOutNote.Select(txtSubOutID.Tag.ToString());
                            if (oSOut != null)
                            {
                                if (!oSOut.IsApproved)
                                {
                                    if (!oSOut.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oSOut.IsCanceled = true;
                                                oSOut.DateCanceled = clsSecurity.getServerDateTime();
                                                oSOut.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oSOut.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oSOut.Update();

                                                foreach (tbl_prod_pharmaTxSubContractOutNote_Material oMat in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllBySubOut_ID(oSOut.SubOut_ID))
                                                {
                                                    clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), oMat.Item_ID, oMat.Son_Qty);
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

        #region Meterial Grid Buttons
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSection.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials, true);
                RowDataSearch.RowSelected += RowDataSearch_RowSelected;
            }
            else
                SEACCMessageBox.Show("Released Section Can not be Empty", "Please select a Released Section before adding items", MessageBoxButton.OK, "Red");
        }

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
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
            }
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSubOutID, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartmet, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSupplier, true, false, false);

            txtSubOutID.Tag = null;
            txtDepartmet.Tag = null;
            txtSection.Tag = null;
            txtSupplier.Tag = null;

            txtSubOutID.Text = "";
            txtSupplier.Text = "";
            txtDepartmet.Text = "";
            txtSection.Text = "";

            dtpSubOut_Date.SetTime(DateTime.Now);

            chk_selectAllBoMs.IsChecked = false;
            chk_selectAllSemiFinished.IsChecked = false;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSubOutID.setReadOnlyStatus(true);
                txtSubOutID.Text = "<Auto Generate>";
            }
            else
                txtSubOutID.setReadOnlyStatus(false);
            #endregion

            dtBoM.Clear();
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;

            dtSemiFinishedItems.Clear();
            dgr_SemiFinisheds.ItemsSource = dtSemiFinishedItems.DefaultView;

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
                foreach (tbl_prod_pharmaTxSubContractOutNote oSOut in tbl_prod_pharmaTxSubContractOutNote.SelectAll().Where(p => p.SubOut_ID != "default").OrderByDescending(o => o.DateCreate))
                {
                    dgr_Main.dt.Rows.Add(++iCount, oSOut.SubOut_ID, oSOut.SubOut_Date.ToString(clsValidation.Format_Date), clsGenaralName.getName_Supplier(oSOut.Supplier_ID), clsGenaralName.getName_User(oSOut.CreateUser_ID), clsGenaralName.getName_User(oSOut.ApprovedUser_ID), oSOut.IsCanceled);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Refresh_BOM_Grid(string sProdSection_ID)
        {
            dtBoM.Clear();
            foreach (tbl_prod_pharmaTxJobCard oJob in tbl_prod_pharmaTxJobCard.SelectAll().Where(r => !r.IsCanceled && r.IsLocked && r.IsApproved3 && r.ProdJob_ID != "default" &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Cancelled &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Closed &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Suspended &&
                                                                                        r.ProdJobStatus != (int)prod_BoM_Status.Obsolete).OrderByDescending(o => o.DateCreate))
            {

                if (tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oJob.ProdJob_ID).Count(r => r.IsSemiFinishItem && r.Section_ID == sProdSection_ID) < 1)
                    continue;


                foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => !r.IsCanceled))
                {
                    if (oBatch.BatchStatus == (int)prod_Batch_Status.Open)
                    {
                        dtBoM.Rows.Add("0", "\uE003", oJob.ProdJob_ID,
                            oBatch.ProdBatch_ID, oJob.Item_ID_FG,
                            clsGenaralName.getName_Item(oJob.Item_ID_FG),
                            clsGenaralName.getName_Uom(oJob.Uom_ID),
                            cls_Formater.FormatDecimal(oBatch.BatchQty * oJob.FGoodQty, 0),
                            clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID)),
                            cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetItemQty_FromCO(oBatch.CustomerOrder_ID, oBatch.Item_ID), 0),
                            oBatch.CustomerOrder_ID == "default" ? "-" : oBatch.CustomerOrder_ID,
                            cls_Formater.FormatDecimal(oBatch.BatchQty * oJob.FGoodQty, 0));
                    }
                }
            }

            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (CheckFloorStock())
                    if (CheckValidity_DuplicateFiled())
                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSubOutID.Text))
                            bStatus = true;


            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtSubOutID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDepartmet))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSection))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSupplier))
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
                    txtSubOutID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtSubOutID.Text = txtSubOutID.Tag.ToString();
                }

                tbl_prod_pharmaTxSubContractOutNote oSubOUT = tbl_prod_pharmaTxSubContractOutNote.Select(txtSubOutID.Text);
                if (oSubOUT != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckFloorStock()
        {
            bool bReturn = true;

            DataTable dtFloorStock = new DataTable();
            dtFloorStock = clsHelpMethods_Prod.GetItemGroupedItemFloorstockTable(dtMeterials, "ItemNo", "SONQty", clsGenaralName.getStoreID_Section(txtSection.Tag.ToString()));

            if (SEACC_Form.IsUpdateMode)
            {
                foreach (DataRow dr in dtFloorStock.Rows)
                {
                    string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                    dr["IssuedQty"] = cls_Formater.FormatDecimal(tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllBySubOut_ID(txtSubOutID.Text).Where(r => r.Item_ID == sItem_ID).Sum(x => x.Son_Qty), clsConfig.sDecimalPlaces_Quantity);
                }
            }

            bReturn = clsHelpMethods_Prod.CheckItemFloorStockTable(dtFloorStock);

            return bReturn;
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_prod_pharmaTxSubContractOutNote oSOUT = tbl_prod_pharmaTxSubContractOutNote.Select(sID);
                if (oSOUT != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSubOutID.Tag = oSOUT.SubOut_ID;
                    txtSupplier.Tag = oSOUT.Supplier_ID;
                    txtDepartmet.Tag = oSOUT.Release_Dept_ID;
                    txtSection.Tag = oSOUT.Release_Section_ID;

                    txtSubOutID.Text = oSOUT.SubOut_ID;
                    txtSupplier.Text = clsGenaralName.getName_Supplier(oSOUT.Supplier_ID);
                    txtDepartmet.Text = clsGenaralName.getName_Department(oSOUT.Release_Dept_ID);
                    txtSection.Text = clsGenaralName.getName_Section(oSOUT.Release_Section_ID);

                    dtpSubOut_Date.SetTime(oSOUT.SubOut_Date);

                    if (oSOUT.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oSOUT.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    dtBoM.Clear();
                    dtSemiFinishedItems.Clear();
                    dtMeterials.Rows.Clear();

                    #region Fill BoM / Batch
                    foreach (tbl_prod_pharmaTxSubContractOutNote_JobCard oSubOut_ProdJobBoM in tbl_prod_pharmaTxSubContractOutNote_JobCard.SelectAllBySubOut_ID(sID))
                    {
                        tbl_prod_pharmaTxJobCard oProdJobBoM = tbl_prod_pharmaTxJobCard.Select(oSubOut_ProdJobBoM.ProdJob_ID);
                        tbl_prod_pharmaTxBatch oProdBatch = tbl_prod_pharmaTxBatch.Select(oSubOut_ProdJobBoM.ProdBatch_ID);

                        if (oProdJobBoM != null && oProdJobBoM.ProdJob_ID != "default")
                        {
                            dtBoM.Rows.Add("0",
                                "\uE0A2",
                                oProdJobBoM.ProdJob_ID,
                                oSubOut_ProdJobBoM.ProdBatch_ID, oProdJobBoM.Item_ID_FG,
                                clsGenaralName.getName_Item(oProdJobBoM.Item_ID_FG),
                                clsGenaralName.getName_Uom(oProdJobBoM.Uom_ID),
                                cls_Formater.FormatDecimal(oProdBatch.BatchQty * oProdJobBoM.FGoodQty, 0),
                                clsGenaralName.getName_Customer(oProdJobBoM.Customer_ID),
                                cls_Formater.FormatDecimal(clsHelpMethods_Prod.GetItemQtyInCO_FromJob(oProdJobBoM.ProdJob_ID, oProdBatch.ProdBatch_ID) * oProdJobBoM.FGoodQty, 0),
                                oProdJobBoM.CustomerOrder_ID == "default" ? "-" : oProdJobBoM.CustomerOrder_ID,
                                cls_Formater.FormatDecimal(oSubOut_ProdJobBoM.SubOut_FGQty, 0));
                        }
                    }
                    #endregion

                    #region Fill Semi Finished
                    foreach (tbl_prod_pharmaTxSubContractOutNote_SemiFinished oSOUT_SF in tbl_prod_pharmaTxSubContractOutNote_SemiFinished.SelectAllBySubOut_ID(oSOUT.SubOut_ID))
                    {
                        decimal dDeliverQty = Get_DeliveredSemiFinishedQty_SOut(oSOUT_SF.ProdBatch_ID, oSOUT_SF.SemiFinishedItem_ID);
                        decimal dRequiredQty = clsHelpMethods_Prod.GetRequiredMaterialQty(oSOUT_SF.ProdJob_ID, oSOUT_SF.SemiFinishedItem_ID, clsHelpMethods_Prod.GetProdBatchQty(oSOUT_SF.ProdBatch_ID));
                        decimal dBalanceQty = dRequiredQty - dDeliverQty;

                        dtSemiFinishedItems.Rows.Add("0",
                            "\uE0A2",
                            oSOUT_SF.ProdJob_ID == "default" ? "-" : oSOUT_SF.ProdJob_ID,
                            oSOUT_SF.ProdBatch_ID == "default" ? "-" : oSOUT_SF.ProdBatch_ID,
                            oSOUT_SF.SemiFinishedItem_ID,
                            clsGenaralName.getName_Item(oSOUT_SF.SemiFinishedItem_ID),
                             oSOUT_SF.Uom_ID,
                            clsGenaralName.getName_Uom(oSOUT_SF.Uom_ID),
                            cls_Formater.FormatDecimal(dRequiredQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(dBalanceQty < 0 ? 0 : dBalanceQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSOUT_SF.SubOut_SFGQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oSOUT_SF.SupplierRate, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                            cls_Formater.FormatDecimal(oSOUT_SF.SupplierTotalAmount, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
                    }
                    #endregion

                    #region Fill Material
                    foreach (tbl_prod_pharmaTxSubContractOutNote_Material oSOUT_Meterial in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllBySubOut_ID(oSOUT.SubOut_ID))
                    {
                        if (!oSOUT_Meterial.IsSemiFG_item)
                            dtMeterials.Rows.Add("0",
                                oSOUT_Meterial.ProdJob_ID == "default" ? "-" : oSOUT_Meterial.ProdJob_ID,
                                oSOUT_Meterial.ProdBatch_ID == "default" ? "-" : oSOUT_Meterial.ProdBatch_ID,
                                oSOUT_Meterial.SemiFG_item_ID,
                                clsGenaralName.getName_Item(oSOUT_Meterial.SemiFG_item_ID),
                                oSOUT_Meterial.Item_ID,
                                clsGenaralName.getName_Item(oSOUT_Meterial.Item_ID),
                                oSOUT_Meterial.Uom_ID,
                                clsGenaralName.getName_Uom(oSOUT_Meterial.Uom_ID),
                                cls_Formater.FormatDecimal(oSOUT_Meterial.Bom_Qty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(oSOUT_Meterial.Available_Qty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(oSOUT_Meterial.Bom_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(oSOUT_Meterial.Bom_Balance_Qty, clsConfig.sDecimalPlaces_Quantity),
                                cls_Formater.FormatDecimal(oSOUT_Meterial.Son_Qty, clsConfig.sDecimalPlaces_Quantity));

                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_SemiFinishedGrid_FromBoMs()
        {
            try
            {
                if (txtSection.Tag != null && txtSection.Tag.ToString() != "default")
                {

                    Cursor = Cursors.Wait;
                    dtSemiFinishedItems.Rows.Clear();

                    var vSelectedBoMs = dtBoM.Select("IsSelect = '\uE0A2'");
                    foreach (DataRow rowBoM in vSelectedBoMs)
                    {
                        string sBoM_No = rowBoM["BoM_No"].ToString();
                        string sBatch_No = rowBoM["Batch_No"].ToString();
                        decimal dSOut_Qty = clsValidation.Validate_DecimalNumber(rowBoM["SOut_Qty"].ToString());
                        decimal dBatch_Qty = clsHelpMethods_Prod.GetProdBatchQty(sBatch_No);

                        foreach (tbl_prod_pharmaTxJobCard_Material oBoM_SF in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                        {
                            if (dtSemiFinishedItems.Select("BoM_No = '" + sBoM_No + "' AND Batch_No = '" + sBatch_No + "' AND SFG_ID ='" + oBoM_SF.Item_ID + "'").Count() > 0)
                                continue;

                            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(sBoM_No);
                            decimal dQty_Ratio = decimal.Round(oBoM_SF.TotalInputQty / oBoM.FGoodQty, 3);

                            decimal dRequiredQty = dBatch_Qty * oBoM_SF.TotalInputQty;
                            decimal dUndeliveredQty = dRequiredQty - Get_DeliveredSemiFinishedQty_SOut(sBatch_No, oBoM_SF.Item_ID);

                            dtSemiFinishedItems.Rows.Add("0",
                                     "\uE003",
                                     oBoM_SF.ProdJob_ID,
                                     sBatch_No,
                                     oBoM_SF.Item_ID,
                                     clsGenaralName.getName_Item(oBoM_SF.Item_ID),
                                     oBoM_SF.Uom_ID,
                                     clsGenaralName.getName_Uom(oBoM_SF.Uom_ID),
                                     cls_Formater.FormatDecimal(dRequiredQty, clsConfig.sDecimalPlaces_Quantity),     // Required or Batch Qty
                                     cls_Formater.FormatDecimal(dUndeliveredQty < 0 ? 0 : dUndeliveredQty, clsConfig.sDecimalPlaces_Quantity),  //Undelivered Qty
                                     cls_Formater.FormatDecimal(dSOut_Qty * dQty_Ratio, clsConfig.sDecimalPlaces_Quantity),     //SON Qty
                                     cls_Formater.FormatDecimal((oBoM_SF.Cost), clsConfig.sCurrencyDecimalPlaces_UnitPrice),   //Contractor Price
                                     cls_Formater.FormatDecimal((dSOut_Qty * dQty_Ratio * oBoM_SF.Cost), clsConfig.sCurrencyDecimalPlaces_UnitPrice)
                                     );
                        }

                        Calculate_ContractorPrice();
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Section not selected...", "Please select a production section", MessageBoxButton.OK, "Red");
                    dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
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

        private void Fill_Materials_FromSemiFinisheds()
        {
            try
            {
                Cursor = Cursors.Wait;
                dtMeterials.Rows.Clear();

                var vUnselectedSFGs = dtSemiFinishedItems.Select("IsSelect = '\uE003'");
                foreach (DataRow rowBoM in vUnselectedSFGs)
                {
                    string sBoM_No = rowBoM["BoM_No"].ToString();
                    string sSemiFinised_ID = rowBoM["SFG_ID"].ToString();
                    string sBatch_No = rowBoM["Batch_No"].ToString();

                    var rows = dtMeterials.Select("BoM_No = '" + sBoM_No + "' AND Batch_No = '" + sBatch_No + "'  AND SFG_ID ='" + sSemiFinised_ID + "'");
                    foreach (var row in rows)
                        row.Delete();
                }

                var vSelectedSemiFinisheds = dtSemiFinishedItems.Select("IsSelect = '\uE0A2'");
                foreach (DataRow rowSemiFinished in vSelectedSemiFinisheds)
                {
                    string sProdJobBoM_No = rowSemiFinished["BoM_No"].ToString();
                    string sBatch_No = rowSemiFinished["Batch_No"].ToString();
                    string sSemiFinised_ID = rowSemiFinished["SFG_ID"].ToString();
                    decimal dBatch_Qty = clsHelpMethods_Prod.GetProdBatchQty(sBatch_No);
                    decimal dSOut_Qty = clsValidation.Validate_DecimalNumber(rowSemiFinished["SubOutQty"].ToString());

                    tbl_prod_pharmaTxJobCard_Material oMeteril = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJobBoM_No).Where(r => r.Item_ID == sSemiFinised_ID).FirstOrDefault();
                    if (oMeteril != null)
                    {
                        decimal sSF_QtyRatio = oMeteril.TotalInputQty;

                        foreach (tbl_prod_pharmaTxJobCard_Material oMateril_forSemi in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJobBoM_No).Where(r => r.Line_No == oMeteril.Line_No && r.Line_No_Sub1 != 0))
                        {
                            decimal dMateril_forSF_Ratio = (oMateril_forSemi.TotalInputQty / sSF_QtyRatio);

                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oMateril_forSemi.Item_ID);
                            decimal dRequiredQty = 0;
                            decimal dStockQty = 0;
                            decimal dIssuedQty = 0;
                            decimal dBalanceQty = 0;
                            decimal dSONQty = 0;
                            if (oItem != null)
                            {
                                dRequiredQty = (oMateril_forSemi.TotalInputQty * dBatch_Qty);
                                dStockQty = clsProcessMethods.Get_SectionStoreStockBalance_Qty(txtSection.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                                dIssuedQty = Get_IssuedMaterialQty_SOut(sBatch_No, oMateril_forSemi.Item_ID);
                                dBalanceQty = dRequiredQty - dIssuedQty;
                                dSONQty = dSOut_Qty * dMateril_forSF_Ratio;

                                dtMeterials.Rows.Add("0",
                                    oMeteril.ProdJob_ID,
                                    sBatch_No,
                                    oMeteril.Item_ID,
                                    clsGenaralName.getName_Item(oMeteril.Item_ID),
                                    oMateril_forSemi.Item_ID,
                                    clsGenaralName.getName_Item(oMateril_forSemi.Item_ID),
                                    oMateril_forSemi.Uom_ID,
                                    clsGenaralName.getName_Uom(oMateril_forSemi.Uom_ID),
                                    cls_Formater.FormatDecimal(dRequiredQty, clsConfig.sDecimalPlaces_Quantity),
                                    cls_Formater.FormatDecimal(dStockQty, clsConfig.sDecimalPlaces_Quantity),
                                    cls_Formater.FormatDecimal(dIssuedQty, clsConfig.sDecimalPlaces_Quantity),
                                    cls_Formater.FormatDecimal(dBalanceQty < 0 ? 0 : dBalanceQty, clsConfig.sDecimalPlaces_Quantity),
                                    cls_Formater.FormatDecimal(dSONQty < 0 ? 0 : dSONQty, clsConfig.sDecimalPlaces_Quantity));
                            }
                        }
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

        #region Grid Events

        #region BoM Grid Events
        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }
        private void dgr_BoMs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_BoMs.SelectedIndex;
            var vDG_Cell = dgr_BoMs.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                {
                    bool bIsChecked = false;
                    bIsChecked = dtBoM.Rows[irowID]["IsSelect"].ToString() == "\uE0A2" ? true : false;
                    dtBoM.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";

                    Fill_SemiFinishedGrid_FromBoMs();
                    Fill_Materials_FromSemiFinisheds();
                    Validate_CheckBoxes();
                }
            }
            catch (Exception) { }
        }
        private void dgr_BoMs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "SOut_Qty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    dQty = decimal.Parse(t.Text);
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, 0);

                Fill_SemiFinishedGrid_FromBoMs();
                Fill_Materials_FromSemiFinisheds();
                Validate_CheckBoxes();
            }

        }
        #endregion

        #region Semifinished Item Grid Events
        private void dgr_SemiFinisheds_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtSemiFinishedItems);
        }
        private void dgr_SemiFinisheds_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_SemiFinisheds.SelectedIndex;
            var vDG_Cell = dgr_SemiFinisheds.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect")
                {
                    bool bIsChecked = false;
                    bIsChecked = dtSemiFinishedItems.Rows[irowID]["IsSelect"].ToString() == "\uE0A2" ? true : false;
                    dtSemiFinishedItems.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";

                    Fill_Materials_FromSemiFinisheds();
                    Validate_CheckBoxes();
                }
            }
            catch (Exception) { }
        }
        private void dgr_SemiFinisheds_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "SubOutQty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    dQty = decimal.Parse(t.Text);
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                Fill_Materials_FromSemiFinisheds();
                Validate_CheckBoxes();
            }
            else if (sColumnSortMember == "ContractorRate")
            {
                t = e.EditingElement as TextBox;
                decimal dRate = 0m;
                try
                {
                    dRate = decimal.Parse(t.Text);
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dRate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                Calculate_ContractorPrice();
            }
        }
        #endregion

        #region Meterial Grid Events
        private void dgr_Meterial_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterials);
        }
        private void dgr_Meterial_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;
            if (sColumnName == "SONQty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    object item = dgr_Meterial.SelectedItem;
                    if (item != null)
                    {
                        string sItemID = (dgr_Meterial.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);

                        if (oItem != null)
                        {
                            dQty = decimal.Parse(t.Text);
                            //decimal dSection_Qty = clsHelpMethods_Prod.Get_SectionStockBalance_Qty(txtSection.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                            //if (dSection_Qty < dQty)
                            //{
                            //    dQty = dSection_Qty;
                            //    SEACCMessageBox.Show("Oops..!", "Physical Quantity : " + cls_Formater.FormatDecimal(dSection_Qty, clsConfig.sDecimalPlaces_Quantity) + "\nQuantity should be less than or equal to Physical Quantity", MessageBoxButton.OK);
                            //}
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
                    decimal dStockQty = 0;
                    if (oItem != null)
                    {
                        dStockQty = clsProcessMethods.Get_SectionStoreStockBalance_Qty(txtSection.Tag.ToString(), oItem.Item_ID, "default", oItem.ItemCategorySub_ID, "default", "0", "0");
                        dtMeterials.Rows.Add("0",
                            "-",
                            "default",
                            "-",
                            oItem.Item_ID,
                            clsGenaralName.getName_Item(oItem.Item_ID),
                            oItem.Uom_ID,
                            clsGenaralName.getName_Uom(oItem.Uom_ID),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //RequiredQty
                            cls_Formater.FormatDecimal(dStockQty, clsConfig.sDecimalPlaces_Quantity), //StockQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //IssuedQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity), //BalanceQty
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity) //SONQty
                            );
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

                dtSemiFinishedItems.Rows.Clear();
                dtMeterials.Rows.Clear();

                Refresh_BOM_Grid(lstResult[0]);
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

        #endregion

        #region Help Methods
        private void SOut_InsertMaterials()
        {

            foreach (DataRow row in dtBoM.Rows)
            {
                if (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE003")
                    continue;

                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                decimal dSOut_Qty = clsValidate.ValidateRowValue(row, "SOut_Qty", 0m);

                tbl_prod_pharmaTxSubContractOutNote_JobCard oBatch = new tbl_prod_pharmaTxSubContractOutNote_JobCard(iLine_no,
                    txtSubOutID.Text, sBoM_No, sBatch_No,
                    clsGenaralName.getID_PharmaBoM_FinishedGood(sBoM_No),
                    (sCO_ID == "-" ? "default" : sCO_ID),
                    clsGenaralName.getID_PharmaBoM_UoM(sBoM_No), dSOut_Qty, clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(sBoM_No));
                oBatch.Insert();
            }


            foreach (DataRow row in dtSemiFinishedItems.Rows)
            {
                if (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE003")
                    continue;

                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                string sSFG_ID = clsValidate.ValidateRowValue(row, "SFG_ID", "default");
                string sSFG_UoM_ID = clsValidate.ValidateRowValue(row, "SFG_UoM_ID", "default");
                decimal dRequiredQty = clsValidate.ValidateRowValue(row, "RequiredQty", 0m);
                decimal dUndeliveredQty = clsValidate.ValidateRowValue(row, "UndeliveredQty", 0m);
                decimal dSubOutQty = clsValidate.ValidateRowValue(row, "SubOutQty", 0m);
                decimal dContractorRate = clsValidate.ValidateRowValue(row, "ContractorRate", 0m);
                decimal dContractorPrice = clsValidate.ValidateRowValue(row, "ContractorPrice", 0m);

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sSFG_ID);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sSFG_ID);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dSubOutQty;
                }

                tbl_prod_pharmaTxSubContractOutNote_SemiFinished oSOUT_SFs = new tbl_prod_pharmaTxSubContractOutNote_SemiFinished(iLine_no, txtSubOutID.Text, sBoM_No, sBatch_No, sSFG_ID, sSFG_UoM_ID, dSubOutQty, dUnitPrice, dContractorRate, dTotalAmount, dContractorPrice);
                oSOUT_SFs.Insert();

            }

            foreach (DataRow row in dtMeterials.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                string sSFG_ID = clsValidate.ValidateRowValue(row, "SFG_ID", "default");
                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                decimal dRequiredQty = clsValidate.ValidateRowValue(row, "RequiredQty", 0m);
                decimal dStockQty = clsValidate.ValidateRowValue(row, "StockQty", 0m);
                decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0m);
                decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0m);
                decimal dSONQty = clsValidate.ValidateRowValue(row, "SONQty", 0m);

                decimal dUnitPrice = 0;
                decimal dTotalAmount = 0;
                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemNo);
                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItemNo);
                if (oItem_Finance != null)
                {
                    dUnitPrice = oItem_Finance.WeightedAverageCostPrice;
                    dTotalAmount = dUnitPrice * dSONQty;
                }

                tbl_prod_pharmaTxSubContractOutNote_Material oSOUT_Materials = new tbl_prod_pharmaTxSubContractOutNote_Material(iLine_no, txtSubOutID.Text, false, (sBoM_No == "-" ? "default" : sBoM_No), (sBatch_No == "-" ? "default" : sBatch_No), sSFG_ID, sItemNo, sUoM_ID, dStockQty, dRequiredQty, dIssuedQty, dBalanceQty, dSONQty, 0, dUnitPrice, 0, dTotalAmount, "");
                oSOUT_Materials.Insert();

                clsHelpMethods_Prod.UpdateSectionFloorStock(txtSection.Tag.ToString(), sItemNo, -dSONQty);
            }
        }

        private decimal Get_IssuedMaterialQty_SOut(string sProdBatch_ID, string sItemID)
        {
            decimal dIssuedQty = 0;
            foreach (tbl_prod_pharmaTxSubContractOutNote_Material oSOut_Material in tbl_prod_pharmaTxSubContractOutNote_Material.SelectAllByProdBatch_ID(sProdBatch_ID).Where(r => r.Item_ID == sItemID))
            {
                if (oSOut_Material.IsSemiFG_item)
                    continue;

                tbl_prod_pharmaTxSubContractOutNote oSON = tbl_prod_pharmaTxSubContractOutNote.Select(oSOut_Material.SubOut_ID);
                if (oSON != null && !oSON.IsCanceled)
                    dIssuedQty += oSOut_Material.Son_Qty;
            }
            return dIssuedQty;
        }

        private decimal Get_DeliveredSemiFinishedQty_SOut(string sProdBatch_ID, string sSemiFinishItem_ID)
        {
            decimal dDeliverQty = 0;
            foreach (tbl_prod_pharmaTxSubContractOutNote_SemiFinished oSOut_SFG in tbl_prod_pharmaTxSubContractOutNote_SemiFinished.SelectAllByProdBatch_ID(sProdBatch_ID).Where(r => r.SemiFinishedItem_ID == sSemiFinishItem_ID))
            {

                tbl_prod_pharmaTxSubContractOutNote oSON = tbl_prod_pharmaTxSubContractOutNote.Select(oSOut_SFG.SubOut_ID);
                if (oSON != null && !oSON.IsCanceled)
                    dDeliverQty += oSOut_SFG.SubOut_SFGQty;
            }
            return dDeliverQty;
        }

        private decimal Get_ContractorPrice(string sProdJobBom, string sSemiFinishItem_ID)
        {
            decimal dContractorPrice = 0;
            tbl_prod_pharmaTxJobCard_Material oProdJobMaterial = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJobBom).Where(r => r.Item_ID == sSemiFinishItem_ID).FirstOrDefault();
            if (oProdJobMaterial != null)
                dContractorPrice = oProdJobMaterial.Cost;

            return dContractorPrice;
        }

        private void Validate_CheckBoxes()
        {
            if (dtSemiFinishedItems.Rows.Count < 1)
                chk_selectAllSemiFinished.IsChecked = false;

            if (dtSemiFinishedItems.Select("IsSelect = '\uE003' ").Count() > 0)
                chk_selectAllSemiFinished.IsChecked = false;

            if (dtBoM.Rows.Count < 1)
                chk_selectAllBoMs.IsChecked = false;

            if (dtBoM.Select("IsSelect = '\uE003' ").Count() > 0)
                chk_selectAllBoMs.IsChecked = false;
        }

        private void Calculate_ContractorPrice()
        {
            foreach (DataRow row in dtSemiFinishedItems.Rows)
            {
                decimal dSubOutQty = clsValidate.ValidateRowValue(row, "SubOutQty", 0m);
                decimal dContractorRate = clsValidate.ValidateRowValue(row, "ContractorRate", 0m);
                row["ContractorPrice"] = cls_Formater.FormatDecimal(dSubOutQty * dContractorRate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
        }

        #endregion

        #region Check Box Events
        private void chk_selectAllSemiFinished_Checked(object sender, RoutedEventArgs e)
        {
            dtSemiFinishedItems.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
            Fill_Materials_FromSemiFinisheds();
        }

        private void chk_selectAllBoM_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
            Fill_SemiFinishedGrid_FromBoMs();
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

