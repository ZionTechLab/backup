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
    /// Developed By Gayan
    /// 2017-05-22
    /// </summary>
    public partial class UC_Production_MeterialRequisition : UserControl
    {
        #region Class Variables
        DataTable dtBoM = new DataTable();
        DataTable dtMaterials = new DataTable();
        DataTable dtMaterial_Summary = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_Production_MeterialRequisition()
        {
            #region Usercontrol Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Prod_MeterialRequisition;
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
            dtBoM.Columns.Add("MRQty");
            #endregion

            #region Meterial Table Initialize
            dtMaterials.Columns.Add("LineNo", typeof(int));
            dtMaterials.Columns.Add("BoM_No");
            dtMaterials.Columns.Add("BoM_Line_No");
            dtMaterials.Columns.Add("Batch_No");
            dtMaterials.Columns.Add("ItemNo");
            dtMaterials.Columns.Add("ItemName");
            dtMaterials.Columns.Add("UoM_ID");
            dtMaterials.Columns.Add("UoM");
            dtMaterials.Columns.Add("PlannedQty");
            dtMaterials.Columns.Add("IssuedQty");
            dtMaterials.Columns.Add("BalanceQty");
            dtMaterials.Columns.Add("MRQty");
            dtMaterials.Columns.Add("ReqdDate");
            dtMaterials.Columns.Add("Instructions");
            dtMaterials.Columns.Add("StoreID");
            dtMaterials.Columns.Add("StroreName");
            #endregion

            #region Meterial Summary Table Initialize
            dtMaterial_Summary.Columns.Add("LineNo", typeof(int));
            dtMaterial_Summary.Columns.Add("ItemNo");
            dtMaterial_Summary.Columns.Add("ItemName");
            dtMaterial_Summary.Columns.Add("UoM_ID");
            dtMaterial_Summary.Columns.Add("UoM");
            dtMaterial_Summary.Columns.Add("MRQty");
            #endregion

            #region Main Table Initialize
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("MR_NO");
            dgr_Main.dt.Columns.Add("MR_DATE");
            dgr_Main.dt.Columns.Add("SECTION");
            dgr_Main.dt.Columns.Add("PLAN_DATE_FROM");
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
            dgr_Main.Add_DatagridColoumn("MR NO", "MR_NO", 80);
            dgr_Main.Add_DatagridColoumn("MR DATE", "MR_DATE", 80);
            dgr_Main.Add_DatagridColoumn("SECTION", "SECTION", 150);
            dgr_Main.Add_DatagridColoumn("PLAN DATE", "PLAN_DATE_FROM", 80);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "PREPARED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "MODIFIED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "MODIFIED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved Date", "APPROVED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            #endregion

            ClearFields();
            Refresh_MainGrid();
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            Refresh_MainGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            string sMR_ID = "";
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved && !oMR.IsCanceled)
                                {

                                    tbl_prodTxMaterialRequision oOldMR = new tbl_prodTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), oMR.IsChecked, oMR.IsApproved, oMR.IsCanceled, oMR.CreateUser_ID, clsSecurity.UserIDLoged, oMR.CheckedUser_ID, oMR.ApprovedUser_ID, oMR.CanceldUser_ID, oMR.DateCreate, clsSecurity.getServerDateTime(), oMR.DateChecked, oMR.DateApproved, oMR.DateCanceled, oMR.CreateUserTerminal_ID, clsSecurity.TerminalID, oMR.CheckedUserTerminal_ID, oMR.ApprovedUserTerminal_ID, oMR.CanceledUserTerminal_ID, oMR.CompanyID, oMR.CompanyBranchID);
                                    oOldMR.Update();

                                    tbl_prodTxMaterialRequision_JobCard.DeleteAllByMr_No(oMR.Mr_No);
                                    tbl_prodTxMaterialRequision_Material.DeleteAllByMr_No(oMR.Mr_No);

                                    foreach (DataRow row in dtBoM.Rows)
                                    {
                                        bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                        if (bSelect)
                                        {
                                            string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                            string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                            string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                            decimal dMR_FG_Qty = clsValidate.ValidateRowValue(row, "MRQty", 0m);

                                            tbl_prodTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prodTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, sBatch_No, (sCO_ID == "-" ? "default" : sCO_ID), dMR_FG_Qty, clsGenaralName.getID_ApparelBoM_UoM(sBoM_No), clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(sBoM_No));
                                            oNewMR_JobCard.Insert();
                                        }
                                    }

                                    foreach (DataRow row in dtMaterials.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                        int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0));
                                        string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                        string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0m);
                                        decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0m);
                                        decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0m);
                                        decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                        DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                        string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                        string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                        tbl_prodTxMaterialRequision_Material oProdMR_Materials = new tbl_prodTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sBatch_No, sItemNo, sUoM_ID, dPlannedQty, dIssuedQty, dBalanceQty, dMRQty, dtmReqdDate, sInstructions, sStoreID);
                                        oProdMR_Materials.Insert();
                                    }
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    if (oMR.IsApproved)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected MR has been approved", MessageBoxButton.OK, "Red");
                                    else if (oMR.IsCanceled)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected Mr has been cancelled", MessageBoxButton.OK, "Red");
                                    else
                                        SEACCMessageBox.Show("Cannot Update..", "", MessageBoxButton.OK, "Red");
                                }
                            }
                            sMR_ID = oMR.Mr_No;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_prodTxMaterialRequision oNewProdMR = new tbl_prodTxMaterialRequision(txtMRNo.Text, dtpMR_Date.GetDateTime(), txtSection.Tag.ToString(), dtpProdPlan_Date_From.GetDateTime(), dtpProdPlan_Date_To.GetDateTime(), false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                            oNewProdMR.Insert();

                            foreach (DataRow row in dtBoM.Rows)
                            {
                                bool bSelect = (clsValidate.ValidateRowValue(row, "IsSelect", "\uE003") == "\uE0A2");
                                if (!bSelect)
                                    continue;

                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                string sCO_ID = clsValidate.ValidateRowValue(row, "CO_ID", "default");
                                decimal dMR_FG_Qty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");

                                tbl_prodTxMaterialRequision_JobCard oNewMR_JobCard = new tbl_prodTxMaterialRequision_JobCard(txtMRNo.Text, sBoM_No, sBatch_No, (sCO_ID == "-" ? "default" : sCO_ID), dMR_FG_Qty, clsGenaralName.getID_ApparelBoM_UoM(sBoM_No), clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(sBoM_No));
                                oNewMR_JobCard.Insert();
                            }

                            foreach (DataRow row in dtMaterials.Rows)
                            {
                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                string sBoM_No = clsValidate.ValidateRowValue(row, "BoM_No", "default");
                                int iBoM_Line_No = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BoM_Line_No", 0));
                                string sBatch_No = clsValidate.ValidateRowValue(row, "Batch_No", "default");
                                string sItemNo = clsValidate.ValidateRowValue(row, "ItemNo", "default");
                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                decimal dPlannedQty = clsValidate.ValidateRowValue(row, "PlannedQty", 0m);
                                decimal dIssuedQty = clsValidate.ValidateRowValue(row, "IssuedQty", 0m);
                                decimal dBalanceQty = clsValidate.ValidateRowValue(row, "BalanceQty", 0m);
                                decimal dMRQty = clsValidate.ValidateRowValue(row, "MRQty", 0m);
                                DateTime dtmReqdDate = clsValidate.ValidateRowValue(row, "ReqdDate", clsValidation.defaultDateTime);
                                string sInstructions = clsValidate.ValidateRowValue(row, "Instructions", "");
                                string sStoreID = clsValidate.ValidateRowValue(row, "StoreID", "default");

                                tbl_prodTxMaterialRequision_Material oNewProdMR_Materials = new tbl_prodTxMaterialRequision_Material(iLine_no, txtMRNo.Text, sBoM_No, iBoM_Line_No, sBatch_No, sItemNo, sUoM_ID, dPlannedQty, dIssuedQty, dBalanceQty, dMRQty, dtmReqdDate, sInstructions, sStoreID);
                                oNewProdMR_Materials.Insert();
                            }

                            sMR_ID = oNewProdMR.Mr_No;
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
                    Refresh_MainGrid();
                    fillDetails(sMR_ID);
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
                            tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oMR.IsApproved = true;
                                            oMR.DateApproved = clsSecurity.getServerDateTime();
                                            oMR.ApprovedUser_ID = clsSecurity.UserIDLoged;
                                            oMR.ApprovedUserTerminal_ID = clsSecurity.TerminalID;
                                            oMR.Update();
                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                        }
                                        frmTwoStepVerify.Close();
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Alreay Approved", "Selected MR has already been approved", MessageBoxButton.OK, "Red");
                                }
                                ClearFields();
                                Refresh_MainGrid();
                                fillDetails(oMR.Mr_No);
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
                            tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(txtMRNo.Tag.ToString());
                            if (oMR != null)
                            {
                                if (!oMR.IsApproved)
                                {
                                    if (!oMR.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oMR.IsCanceled = true;
                                                oMR.DateCanceled = clsSecurity.getServerDateTime();
                                                oMR.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oMR.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oMR.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        Refresh_MainGrid();
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

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtMRNo, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);

            txtMRNo.Tag = null;
            txtSection.Tag = null;

            txtMRNo.Text = "";
            txtSection.Text = "";

            dtpMR_Date.SetTime(clsSecurity.getServerDateTime());
            dtpProdPlan_Date_From.SetTime(clsSecurity.getServerDateTime());
            dtpProdPlan_Date_To.SetTime(clsSecurity.getServerDateTime());

            dtBoM.Clear();
            dgr_BoMs.ItemsSource = dtBoM.DefaultView;

            dtMaterials.Clear();
            dgr_Meterials.ItemsSource = dtMaterials.DefaultView;

            dtMaterial_Summary.Clear();
            dgr_MeterialSummary.ItemsSource = dtMaterial_Summary.DefaultView;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            chk_selectAll.IsChecked = false;
            chk_selectAll.IsEnabled = false;

            txtSection.IsEnabled = true;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtMRNo.setReadOnlyStatus(true);
                txtMRNo.Text = "<Auto Generate>";
            }
            else
                txtMRNo.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void Refresh_MainGrid()
        {
            try
            {
                Cursor = Cursors.Wait;

                dgr_Main.dt.Clear();
                string sSection = "%%";

                if (txtSection.Tag != null)
                    sSection = txtSection.Tag.ToString();

                string sQuery = "Exec sp_MRDetails '" + sSection + "'";
                dgr_Main.dt.Merge(DBHandling.ExecQuery(sQuery).Tables[0]);
                dgr_Main.RefreshGrid();
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

        private void Refresh_BOM_Grid(string sProdSection_ID)
        {
            //dtBoM.Clear();
            //foreach (tbl_prodTxJobCard oJob in tbl_prodTxJobCard.SelectAll().Where(r => !r.IsCanceled && r.IsLocked && r.IsApproved3 && r.ProdJob_ID != "default" &&
            //                                                                            r.ProdJobStatus != (int)prod_BoM_Status.Cancelled &&
            //                                                                            r.ProdJobStatus != (int)prod_BoM_Status.Closed &&
            //                                                                            r.ProdJobStatus != (int)prod_BoM_Status.Suspended &&
            //                                                                            r.ProdJobStatus != (int)prod_BoM_Status.Obsolete).OrderByDescending(o => o.DateCreate))
            //{

            //    if (tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oJob.ProdJob_ID).Count(r => r.Section_ID == sProdSection_ID) < 1)
            //        continue;

            //    foreach (tbl_prodTxBatch oBatch in tbl_prodTxBatch.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.IsApproved && !r.IsCanceled).OrderByDescending(o => o.DateCreate))
            //    {
            //        if (oBatch.BatchStatus == (int)prod_Batch_Status.Open)
            //        {
            //            dtBoM.Rows.Add("0", "\uE003",
            //                oJob.ProdJob_ID, oBatch.ProdBatch_ID, oJob.Item_ID_FG,
            //                clsGenaralName.getName_Item(oJob.Item_ID_FG), clsGenaralName.getName_Uom(oJob.Uom_ID),
            //                cls_Formater.FormatDecimal(oBatch.BatchQty, 0),
            //                clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID)),
            //                cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, 0),
            //                oBatch.CustomerOrder_ID == "default" ? "-" : oBatch.CustomerOrder_ID,
            //                cls_Formater.FormatDecimal(oBatch.BatchQty, 0)
            //            );
            //        }
            //    }
            //}
            //dgr_BoMs.ItemsSource = dtBoM.DefaultView;



            dtBoM.Clear();



            foreach (tbl_prodTxBatch oBatch in tbl_prodTxBatch.SelectAll().Where(r => r.IsApproved && !r.IsCanceled).OrderByDescending(o => o.DateCreate))
            {
                if (oBatch.BatchStatus == (int)prod_Batch_Status.Open)
                {
                    if (tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oBatch.ProdJob_ID).Count(r => r.Section_ID == sProdSection_ID) < 1)
                        continue;

                    dtBoM.Rows.Add("0", "\uE003",
                        oBatch.ProdJob_ID, oBatch.ProdBatch_ID, oBatch.Item_ID,
                            clsGenaralName.getName_Item(oBatch.Item_ID), clsGenaralName.getName_Uom(oBatch.Item_ID),
                            cls_Formater.FormatDecimal(oBatch.BatchQty, 0),
                            clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oBatch.CustomerOrder_ID)),
                            cls_Formater.FormatDecimal(oBatch.CustomerOrder_Qty, 0),
                            oBatch.CustomerOrder_ID == "default" ? "-" : oBatch.CustomerOrder_ID,
                            cls_Formater.FormatDecimal(oBatch.BatchQty, 0)
                        );
                }
            }

            dgr_BoMs.ItemsSource = dtBoM.DefaultView;
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
                    if (clsValidate.CheckValidity_TransactionCodeLength(txtMRNo.Text))
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

            if (!clsValidation.Validate_EmptyValue(txtMRNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSection))
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
                    txtMRNo.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtMRNo.Text = txtMRNo.Tag.ToString();
                }

                tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(txtMRNo.Text);
                if (oMR != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details

        private void fillDetails(string sMR_ID)
        {
            try
            {
                tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(sMR_ID);
                if (oMR != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtMRNo.Tag = oMR.Mr_No;
                    txtSection.Tag = oMR.Section_ID;

                    txtMRNo.Text = oMR.Mr_No;
                    txtSection.Text = clsGenaralName.getName_Section(oMR.Section_ID);
                    dtpMR_Date.SetTime(oMR.Mr_Date);
                    dtpProdPlan_Date_From.SetTime(oMR.PlanDate_from);
                    dtpProdPlan_Date_To.SetTime(oMR.PlanDate_to);

                    txtSection.IsEnabled = false;

                    dtBoM.Rows.Clear();
                    foreach (tbl_prodTxMaterialRequision_JobCard oDetail in tbl_prodTxMaterialRequision_JobCard.SelectAllByMr_No(sMR_ID))
                    {
                        tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.Select(oDetail.ProdJob_ID);
                        tbl_prodTxBatch oProdBatch = tbl_prodTxBatch.Select(oDetail.ProdBatch_ID);
                        dtBoM.Rows.Add("0", true, oProdJob.ProdJob_ID, oDetail.ProdBatch_ID, oProdJob.Item_ID_FG,
                            clsGenaralName.getName_Item(oProdJob.Item_ID_FG),
                            clsGenaralName.getName_Uom(oProdJob.Uom_ID),
                            cls_Formater.FormatDecimal(oProdBatch.BatchQty, 0),
                            clsGenaralName.getName_Customer(clsGenaralName.getCustomerID_FromCO(oProdBatch.CustomerOrder_ID)),
                            cls_Formater.FormatDecimal(oProdBatch.CustomerOrder_Qty, 0),
                            oDetail.CustomerOrder_ID == "default" ? "-" : oDetail.CustomerOrder_ID,
                            cls_Formater.FormatDecimal(oDetail.Mr_FGQty, 0));
                    }

                    dtMaterials.Rows.Clear();
                    foreach (tbl_prodTxMaterialRequision_Material oMR_Meterials in tbl_prodTxMaterialRequision_Material.SelectAllByMr_No(oMR.Mr_No))
                    {
                        var row = dtBoM.Select("BoM_No = '" + oMR_Meterials.ProdJob_ID + "' AND Batch_No = '" + oMR_Meterials.ProdBatch_ID + "'").FirstOrDefault();
                        if (row != null)
                            row["IsSelect"] = "\uE0A2";

                        dtMaterials.Rows.Add(oMR_Meterials.Line_No, oMR_Meterials.ProdJob_ID,
                            oMR_Meterials.Line_No_JobWise, oMR_Meterials.ProdBatch_ID,
                            oMR_Meterials.Item_ID, clsGenaralName.getName_Item(oMR_Meterials.Item_ID),
                            oMR_Meterials.Uom_ID, clsGenaralName.getName_Uom(oMR_Meterials.Uom_ID),
                            cls_Formater.FormatDecimal(oMR_Meterials.Bom_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Issued_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Balance_Qty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oMR_Meterials.Mr_Qty, clsConfig.sDecimalPlaces_Quantity),
                            oMR_Meterials.Required_Date.ToString(clsValidation.Format_Date),
                            oMR_Meterials.Instructions,
                            oMR_Meterials.Store_ID,
                            clsGenaralName.getName_Store(oMR_Meterials.Store_ID));
                    }
                    Fill_Material_SummaryGrid();

                    if (oMR.IsApproved)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oMR.IsChecked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void Fill_MeterialGrid_ForSelectedBoMs()
        {
            try
            {
                Cursor = Cursors.Wait;
                dtMaterials.Rows.Clear();
                var vSelectedBoMs = dtBoM.Select("IsSelect = '\uE0A2'");

                string sMainStore_ID = "default";
                string sMainStore_Name = "<Select a Store>";
                tbl_genStoreMaster oMainStore = tbl_genStoreMaster.SelectAllByCompanyID(clsSecurity.CompanyID).FirstOrDefault(r => r.IsMainStore);
                if (oMainStore != null)
                {
                    sMainStore_ID = oMainStore.Store_ID;
                    sMainStore_Name = oMainStore.StoreName;
                }

                foreach (DataRow rowBoM in vSelectedBoMs)
                {
                    int iBoM_Wise_Count = 0;
                    string sBoM_No = rowBoM["BoM_No"].ToString();
                    string sBatch_No = rowBoM["Batch_No"].ToString();
                    decimal dMR_FG_Qty = clsValidation.Validate_DecimalNumber(rowBoM["MRQty"].ToString());
                    decimal dJob_FG_Qty = clsValidation.Validate_DecimalNumber(rowBoM["FG_Qty"].ToString());

                    foreach (tbl_prodTxBatch_Material oBoM_Meterial in tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.IsSelected && !r.IsSemiFinishItem && r.Section_ID == txtSection.Tag.ToString()))
                    {
                        decimal dPrevious_Issued_Qty = 0;
                        if (!SEACC_Form.IsUpdateMode)
                            dPrevious_Issued_Qty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(sBoM_No, sBatch_No, oBoM_Meterial.Item_ID);
                        else
                            dPrevious_Issued_Qty = clsHelpMethods_Prod.AlreadyRequestedQty_formMRs(sBoM_No, sBatch_No, txtMRNo.Text.Trim(), oBoM_Meterial.Item_ID);

                        decimal dBalance_Qty = (oBoM_Meterial.TotalInputQty * dJob_FG_Qty) - dPrevious_Issued_Qty;

                        dtMaterials.Rows.Add("0", oBoM_Meterial.ProdJob_ID, ++iBoM_Wise_Count, sBatch_No, oBoM_Meterial.Item_ID, clsGenaralName.getName_Item(oBoM_Meterial.Item_ID), oBoM_Meterial.Uom_ID,
                            clsGenaralName.getName_Uom(oBoM_Meterial.Uom_ID),
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dJob_FG_Qty, clsConfig.sDecimalPlaces_Quantity), //BoM Qty (Planed Qty)
                            cls_Formater.FormatDecimal(dPrevious_Issued_Qty, clsConfig.sDecimalPlaces_Quantity),        //Issued Qty
                            cls_Formater.FormatDecimal(dBalance_Qty < 0 ? 0 : dBalance_Qty, clsConfig.sDecimalPlaces_Quantity), //Balance Qty
                            cls_Formater.FormatDecimal(oBoM_Meterial.TotalInputQty * dMR_FG_Qty, clsConfig.sDecimalPlaces_Quantity), //MR Qty
                            clsSecurity.getServerDateTime().ToString(clsValidation.Format_Date), "",
                            sMainStore_ID,
                            sMainStore_Name);
                    }
                }

                Fill_Material_SummaryGrid();
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

        private void Fill_Material_SummaryGrid()
        {
            dtMaterial_Summary.Clear();
            if (dtMaterials.Rows.Count > 0)
                dtMaterial_Summary = dtMaterials.AsEnumerable()
                  .GroupBy(r => r.Field<string>("ItemNo"))
                  .Select(g =>
                  {
                      var row = dtMaterial_Summary.NewRow();
                      row["ItemNo"] = g.Key;
                      row["ItemName"] = clsGenaralName.getName_Item(g.Key);
                      row["UoM_ID"] = clsGenaralName.getName_ItemUOMID(g.Key);
                      row["UoM"] = clsGenaralName.getName_ItemUOMName(g.Key);
                      row["MRQty"] = cls_Formater.FormatDecimal(g.Sum(r => clsValidation.Validate_DecimalNumber(r.Field<string>("MRQty"))), clsConfig.sDecimalPlaces_Quantity);
                      return row;
                  }).CopyToDataTable();

            dgr_MeterialSummary.ItemsSource = dtMaterial_Summary.DefaultView;
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

        #region BOM Grid
        private void dgr_BoMs_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtBoM);
        }

        private void dgr_BoMs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            switch (sColumnName)
            {
                case "MRQty":
                    var t = e.EditingElement as TextBox;
                    decimal dQty = 0m;

                    object item = dgr_BoMs.SelectedItem;
                    if (item != null)
                    {
                        try
                        {
                            if (t != null) dQty = decimal.Parse(t.Text);

                            if (dQty < 0)
                            {
                                dQty = 0;
                                SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity...", MessageBoxButton.OK, "Red");
                            }

                        }
                        catch
                        {
                            SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                        }
                    }
                    if (t != null) t.Text = cls_Formater.FormatDecimal(dQty, 0);

                    Fill_MeterialGrid_ForSelectedBoMs();
                    break;
            }
        }

        private void dgr_BoMs_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_BoMs.SelectedIndex;
            var vDG_Cell = dgr_BoMs.CurrentCell;
            try
            {
                switch (vDG_Cell.Column.SortMemberPath)
                {
                    case "IsSelect":
                        bool bIsChecked;
                        bIsChecked = dtBoM.Rows[irowID]["IsSelect"].ToString() == "\uE0A2";
                        dtBoM.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";

                        Fill_MeterialGrid_ForSelectedBoMs();

                        if (dtBoM.Select("IsSelect = '\uE10A' ").Any())
                            chk_selectAll.IsChecked = false;
                        break;
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region Material Summary Grid
        private void dgr_MeterialSummary_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMaterial_Summary);
        }
        #endregion

        #region Meterial Grid
        private void dgr_Meterials_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            TextBox t;

            if (sColumnName == "MRQty")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;

                object item = dgr_Meterials.SelectedItem;
                if (item != null)
                {
                    try
                    {
                        dQty = decimal.Parse(t.Text);

                        if (dQty >= 0)
                        {
                            string sItem_ID = (dgr_Meterials.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                            string sItem_Name = (dgr_Meterials.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                            string sBalanceQty = (dgr_Meterials.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
                            decimal dBalanceQty = clsValidation.Validate_DecimalNumber(sBalanceQty);

                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                            if (oItem != null && oItem.IsAccessories)
                            {
                                if (dBalanceQty < dQty)
                                {
                                    SEACCMessageBox.Show("Oops..!", sItem_Name + " is an accessory. It can not be exceeded Balance Quantity", MessageBoxButton.OK, "Red");
                                    dQty = dBalanceQty;
                                }
                            }
                        }
                        else
                        {
                            dQty = 0;
                            SEACCMessageBox.Show("Oops..!", "Please Enter Valid Quantity...", MessageBoxButton.OK, "Red");
                        }
                    }
                    catch (Exception)
                    {
                        SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                    }
                }
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);

                Fill_Material_SummaryGrid();
            }

            if (sColumnName == "ReqdDate")
            {
                t = e.EditingElement as TextBox;
                DateTime dtmTime = clsSecurity.getServerDateTime();
                try
                {
                    dtmTime = DateTime.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter valid date", MessageBoxButton.OK);
                }
                t.Text = dtmTime.ToString(clsValidation.Format_Date);
            }
        }

        private void dgr_Meterials_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMaterials);
        }

        private void dgr_Meterials_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //int irowID = dgr_Meterials.SelectedIndex;
            var vDG_Cell = dgr_Meterials.CurrentCell;
            try
            {
                var vSelectedItems = dgr_Meterials.SelectedItems;
                if (vDG_Cell.Column.SortMemberPath == "StroreName")
                {
                    if (vSelectedItems.Count >= 1)
                    {
                        frm_search RowDataSearch = new frm_search();
                        RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                        RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.StoresList);
                        if (RowDataSearch.DialogResult == true)
                        {
                            foreach (var vItem in vSelectedItems)
                            {
                                string sGrid_LineNo = (dgr_Meterials.SelectedCells[0].Column.GetCellContent(vItem) as TextBlock).Text;
                                foreach (DataRow dr in dtMaterials.Select("LineNo = " + sGrid_LineNo))
                                {
                                    dr["StoreID"] = lstResult[0];
                                    dr["StroreName"] = lstResult[1];
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #endregion

        #region Search Events
        private void txtMRNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMeterialRequisition);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
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

                dtMaterials.Rows.Clear();
                Refresh_MainGrid();
                Refresh_BOM_Grid(lstResult[0]);
                chk_selectAll.IsEnabled = true;
            }
        }
        #endregion

        #region Check Box Events
        private void chk_selectAll_Checked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE0A2");
            Fill_MeterialGrid_ForSelectedBoMs();
        }

        private void chk_selectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            dtBoM.Select().ToList().ForEach(r => r["IsSelect"] = "\uE003");
            Fill_MeterialGrid_ForSelectedBoMs();
        }
        #endregion

        #region Other Text Box Events
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
