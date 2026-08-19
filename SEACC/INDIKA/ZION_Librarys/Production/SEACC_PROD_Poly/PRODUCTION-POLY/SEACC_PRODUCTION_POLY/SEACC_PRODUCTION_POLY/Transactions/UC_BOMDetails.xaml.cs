using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_PRODUCTION_POLY.UserControls;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_POLY.Transactions
{
    /// <summary>
    /// Developed by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class UC_BOMDetails : UserControl
    {
        #region Class Variables
        DataTable dtMeterialReq = new DataTable();
        DataTable dtSMV_BreakDown = new DataTable();
        BrushConverter bc = new BrushConverter();
        private bool bIsSpecialPermission_EditBoM = false;
        #endregion

        #region Form Load
        public UC_BOMDetails(FormName enmForm)
        {
            AppDomainInitializer(enmForm);
        }

        public UC_BOMDetails(string sBoM_ID, FormName enmForm)
        {
            AppDomainInitializer(enmForm);
            fillDetails(sBoM_ID);
        }

        private void AppDomainInitializer(FormName enmForm)
        {
            #region Initialize UserControl
            InitializeComponent();
            SEACC_Form.enmFormName = enmForm;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            #region Meterial Table
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("UoM_ID_Weight");
            dtMeterialReq.Columns.Add("UoM_Weight");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Weight");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("TotalWeight");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("EstTime");
            dtMeterialReq.Columns.Add("LabourCount");
            dtMeterialReq.Columns.Add("IsSemiFinished", typeof(bool));
            dtMeterialReq.Columns.Add("SemiFinished_RawMeterials", typeof(frm_RawMeterial_SemiFinished));
            #endregion

            dtSMV_BreakDown.Columns.Add("LineNo");
            dtSMV_BreakDown.Columns.Add("Operation_ID");
            dtSMV_BreakDown.Columns.Add("Operation_Name");
            dtSMV_BreakDown.Columns.Add("SMV_PerPC");

            #region Main Table
            dgr_Main.dt.Columns.Add("##");
            dgr_Main.dt.Columns.Add("JOB#");
            dgr_Main.dt.Columns.Add("JOB_DATE");
            dgr_Main.dt.Columns.Add("ITEM");
            dgr_Main.dt.Columns.Add("ORDERED_QTY");
            dgr_Main.dt.Columns.Add("STORES_QTY");
            dgr_Main.dt.Columns.Add("CUSTOMER");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion
            #endregion

            #region Initialize Action Buttons
            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, true);
                SEACC_Form.btn_New.Click += btn_New_Click;
                SEACC_Form.btn_Save.Click += btn_Save_Click;
                //SEACC_Form.btn_Approved.Click += btn_Approved_click;
                //SEACC_Form.btn_Print.Click += btn_Print_Click;
                SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            }
            else
            {
                SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
                SEACC_Form.btn_New.Click += btn_New_Click;
                SEACC_Form.btn_Save.Click += btn_Save_Click;
                SEACC_Form.btn_Approved.Click += btn_Approved_click;
                SEACC_Form.btn_Print.Click += btn_Print_Click;
                SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            }
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job #", "JOB#", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JOB_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "ITEM", 200);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Ordered Qty", "ORDERED_QTY", 90, true, true);
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "Stores Qty", "STORES_QTY", 90, true, true);
            dgr_Main.Add_DatagridColoumn("Customer", "CUSTOMER", 100);
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
            string sProdJob_ID = "";
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.Wait;

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (oJob.IsApproved1 || bIsSpecialPermission_EditBoM)
                                {
                                    if ((!oJob.IsApproved2 && !oJob.IsApproved3) || bIsSpecialPermission_EditBoM)
                                    {
                                        tbl_prod_polyTxJobCard oOldJob = new tbl_prod_polyTxJobCard(
                                            oJob.ProdJob_ID, dtpProdJob_Date.GetDateTime(), cmbProdJobStatus.GetSelectedIndex(),
                                            oJob.Salesman_ID,
                                            oJob.Customer_ID,
                                            txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                            txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                            txtComments.Text,
                                            txtReEditComments.Text,
                                            oJob.JobType_ID, oJob.ProdRange_ID, oJob.ProdCategory_ID, oJob.ProdSize_ID, oJob.Colour_ID, oJob.Item_ID_Previous, oJob.Item_ID_FG,
                                            txtFinishGoodUOMQty.Tag != null ? txtFinishGoodUOMQty.Tag.ToString() : "default",
                                            oJob.Item_Length, oJob.Item_Length_UoM_ID, oJob.Item_Width, oJob.Item_Weight_UoM_ID, oJob.Item_Height, oJob.Item_Height_UoM_ID, oJob.Item_Diameter, oJob.Item_Diameter_UoM_ID, oJob.Item_Radius, oJob.Item_Radius_UoM_ID, oJob.Item_Thickness, oJob.Item_Thickness_UoM_ID, oJob.Item_Weight, oJob.Item_Weight_UoM_ID,
                                            decimal.Parse(txtFinishGoodOrderedQty.Text),
                                            decimal.Parse(txtFinishGoodOrderedWeight.Text),
                                            decimal.Parse(txtFinishedGoodPlannedQty.Text),
                                            decimal.Parse(txtFinishedGoodPlannedWeight.Text),
                                            decimal.Parse(txtFinishedGoodEstWastage.Text), oJob.WasteQty, oJob.WasteWeight, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
                                            oJob.EstProdHrs,
                                            oJob.IsChecked1, oJob.IsChecked2, oJob.IsChecked3,
                                            oJob.IsApproved1, oJob.IsApproved2, oJob.IsApproved3,
                                            oJob.IsCanceled, oJob.IsLocked,
                                            oJob.CreateUser_ID, clsSecurity.UserIDLoged,
                                            oJob.Checked1User_ID, oJob.Checked2User_ID, oJob.Checked3User_ID,
                                            oJob.Approved1User_ID, oJob.Approved2User_ID, oJob.Approved3User_ID,
                                            oJob.CanceldUser_ID, oJob.LockedUser_ID,
                                            oJob.DateCreate, clsSecurity.getServerDateTime(),
                                            oJob.DateChecked1, oJob.DateChecked2, oJob.DateChecked3,
                                            oJob.DateApproved1, oJob.DateApproved2, oJob.DateApproved3,
                                            oJob.DateCanceled, oJob.DateLocked,
                                            oJob.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                            oJob.Checked1UserTerminal_ID, oJob.Checked2UserTerminal_ID, oJob.Checked3UserTerminal_ID,
                                            oJob.Approved1UserTerminal_ID, oJob.Approved2UserTerminal_ID, oJob.Approved3UserTerminal_ID,
                                            oJob.CanceledUserTerminal_ID, oJob.LockedUserTerminal_ID, oJob.CompanyID, oJob.CompanyBranchID);
                                        oOldJob.Update();

                                        foreach (tbl_prod_polyTxJobCard_Material_Outsource oItem_Outsource in tbl_prod_polyTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtProdJobID.Text))
                                            oItem_Outsource.Delete();
                                        tbl_prod_polyTxJobCard_Material.DeleteAllByProdJob_ID(oJob.ProdJob_ID);
                                        foreach (DataRow row in dtMeterialReq.Rows)
                                        {
                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                            string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                            string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                            string sUoM_ID_Weight = clsValidate.ValidateRowValue(row, "UoM_ID_Weight", "default");
                                            decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0);
                                            decimal dConsumption_Weight = clsValidate.ValidateRowValue(row, "Weight", 0);
                                            decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0);
                                            decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0);
                                            decimal dTotalWeight = clsValidate.ValidateRowValue(row, "TotalWeight", 0);
                                            string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                            decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0);
                                            decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0);
                                            bool IsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);

                                            decimal dItemWAvgCost = 0;
                                            decimal dLowestCost = 0;
                                            decimal dHighestCost = 0;
                                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                            if (oItem != null && IsSemiFinished)
                                            {
                                                oItem.IsSemiFinishGood = true;
                                                oItem.Update();
                                            }
                                            tbl_genItemMaster_Finance oItem_Finance = tbl_genItemMaster_Finance.Select(sItem_ID, (oItem != null ? oItem.ItemCategorySub_ID : "default"), "default", "0", "0");
                                            if (oItem_Finance != null)
                                            {
                                                dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;
                                                dLowestCost = oItem_Finance.LovesetPurchaseCostPrice;
                                                dHighestCost = oItem_Finance.HighestPurchaseCostPrice;
                                            }

                                            tbl_prod_polyTxJobCard_Material oNewProdMaterial = new tbl_prod_polyTxJobCard_Material(iLine_no, 0, 0, oJob.ProdJob_ID, sItem_ID, sUoM_ID, sUoM_ID_Weight, IsSemiFinished, dConsumption, dConsumption_Weight, 0, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, 0, (dItemWAvgCost * dTotalQty), false);
                                            oNewProdMaterial.Insert();

                                            #region SF Outsource Rate

                                            if (IsSemiFinished && oNewProdMaterial != null)
                                            {
                                                List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                decimal dSF_MaxOutsouceRate = 0;
                                                if (oList_ItemOutsource.Count > 0)
                                                    dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                tbl_prod_polyTxJobCard_Material_Outsource oSF_Outsource = new tbl_prod_polyTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Uom_ID_Weight, oNewProdMaterial.Consumption, oNewProdMaterial.InputWeight, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                oSF_Outsource.Insert();
                                            }
                                            #endregion


                                            frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                            if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                            {
                                                foreach (DataRow row_sub in frmSemi.dtMeterialReq.Rows)
                                                {
                                                    int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_sub, "LineNo", 0));
                                                    string sItem_ID_sub = clsValidate.ValidateRowValue(row_sub, "Item_ID", "default");
                                                    string sUoM_ID_sub = clsValidate.ValidateRowValue(row_sub, "UoM_ID", "default");
                                                    string sUoM_ID_Weight_sub = clsValidate.ValidateRowValue(row_sub, "UoM_ID_Weight", "default");
                                                    decimal dQty_sub = clsValidate.ValidateRowValue(row_sub, "Qty", 0);
                                                    decimal dConsumption_Weight_sub = clsValidate.ValidateRowValue(row_sub, "Weight", 0);
                                                    decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_sub, "Wastage", 0);
                                                    decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_sub, "TotalQty", 0);
                                                    decimal dTotalWeight_sub = clsValidate.ValidateRowValue(row, "TotalWeight", 0);
                                                    string sSection_ID_sub = clsValidate.ValidateRowValue(row_sub, "SectionID", "default");
                                                    decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_sub, "EstTime", 0);
                                                    decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_sub, "LabourCount", 0);

                                                    decimal dItemWAvgCost_sub = 0;
                                                    decimal dLowestCost_sub = 0;
                                                    decimal dHighestCost_sub = 0;
                                                    tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                    tbl_genItemMaster_Finance oItem_Finance_sub = tbl_genItemMaster_Finance.Select(sItem_ID_sub, (oItem_sub != null ? oItem_sub.ItemCategorySub_ID : "default"), "default", "0", "0");
                                                    if (oItem_Finance_sub != null)
                                                    {
                                                        dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                        dLowestCost_sub = oItem_Finance_sub.LovesetPurchaseCostPrice;
                                                        dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                    }

                                                    tbl_prod_polyTxJobCard_Material oNewDelivery_Sub = new tbl_prod_polyTxJobCard_Material(iLine_no, iLine_no_sub, 0, oJob.ProdJob_ID, sItem_ID_sub,
                                                       sUoM_ID_sub,
                                                       sUoM_ID_Weight_sub,
                                                       false,
                                                       dQty_sub, dConsumption_Weight_sub, dQty_sub,
                                                       true,
                                                       dWastage_Pct_sub, 0, dTotalQty_sub,
                                                       sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, 0, (dItemWAvgCost_sub * dTotalQty_sub), false);
                                                    oNewDelivery_Sub.Insert();
                                                }
                                            }
                                        }

                                        decimal dTotSMV = 0;
                                        foreach (DataRow row in dtSMV_BreakDown.Rows)
                                        {
                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                            string sOperation_ID = clsValidate.ValidateRowValue(row, "Operation_ID", "default");
                                            decimal dSMV_PerPC = clsValidate.ValidateRowValue(row, "SMV_PerPC", 0);

                                            tbl_prod_polyTxJobCard_ProductionOperation oProdOperation = tbl_prod_polyTxJobCard_ProductionOperation.Select(iLine_no, txtProdJobID.Text);
                                            if (oProdOperation != null)
                                            {
                                                oProdOperation.Smv_Per_Pc = dSMV_PerPC;
                                                dTotSMV += dSMV_PerPC;
                                                oProdOperation.Update();
                                            }
                                        }
                                        foreach (tbl_prod_polyTxJobCard_CostCenter oProdCostCenter in tbl_prod_polyTxJobCard_CostCenter.SelectAllByProdJob_ID(txtProdJobID.Text))
                                        {
                                            oProdCostCenter.Smv = dTotSMV;
                                            oProdCostCenter.Update();
                                        }

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (SEACC_Form.enmFormName != FormName.Prod_BOMDetails_Production_SpecialPermission)
                                            SEACCMessageBox.Show("Cannot Update..", "Selected BoM has already been approved", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Not Approved from Sales Team", "Selected BoM hasn't already been approved by sales team", MessageBoxButton.OK, "Red");
                                }
                                sProdJob_ID = oJob.ProdJob_ID;
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            //SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
                    fillDetails(sProdJob_ID);
                    Cursor = Cursors.Arrow;
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
                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (oJob.IsApproved1)
                                {
                                    if (!oJob.IsApproved2)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oJob.IsApproved2 = true;
                                                oJob.ProdJobStatus = (int)prod_JobStatus.BoMFin;
                                                oJob.DateApproved2 = clsSecurity.getServerDateTime();
                                                oJob.Approved2User_ID = clsSecurity.UserIDLoged;
                                                oJob.Approved2UserTerminal_ID = clsSecurity.TerminalID;
                                                oJob.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        RefreshGrid();
                                        fillDetails(oJob.ProdJob_ID);
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show("Alreay Approved", "Selected BoM has already been approved", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Not Approved from Sales Team", "Selected BoM hasn't been approved by sales team", MessageBoxButton.OK, "Red");
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
                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (!oJob.IsApproved2 && !oJob.IsApproved3)
                                {
                                    if (!oJob.IsCanceled)
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oJob.ProdJobStatus = (int)prod_JobStatus.Cancelled;
                                                oJob.IsCanceled = true;
                                                oJob.DateCanceled = clsSecurity.getServerDateTime();
                                                oJob.CanceldUser_ID = clsSecurity.UserIDLoged;
                                                oJob.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                                oJob.Update();
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

        #region Meterial Grid - Buttons

        private void btnMeterialGridAdd_Button_Click(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionMaterials, true);
            RowDataSearch.RowSelected += RowDataSearch_RowSelected;
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_MererialReq.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtMeterialReq.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtMeterialReq.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);
            }
        }

        #endregion

        #endregion

        #region Clear Fields

        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, false, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerInquiry, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCOSO, false, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtReEditComments, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishedGoodItemDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOMQty, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOMWeight, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedWeight, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodEstWastage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodPlannedQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodPlannedWeight, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtTotSMVTimeMins, false, true);

            txtProdJobID.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFinishedGoodItemDescription.Tag = null;
            txtFinishGoodUOMQty.Tag = null;
            txtFinishGoodUOMWeight.Tag = null;
            txtTotSMVTimeMins.Tag = null;

            txtCustomer.Uid = "";

            txtProdJobID.Text = "";
            txtCustomer.Text = "";
            txtCustomerInquiry.Text = "";
            txtCustomerCOSO.Text = "";
            txtFinishedGoodItemDescription.Text = "";
            txtFinishGoodUOMQty.Text = "";
            txtFinishGoodUOMWeight.Text = "";
            txtComments.Text = "";
            txtReEditComments.Text = "";
            txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);
            txtFinishGoodOrderedWeight.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);
            txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);
            txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);
            txtFinishedGoodPlannedWeight.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);

            txtTotSMVTimeMins.Text = "0.00";

            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpExFac_Date.SetTime(DateTime.Now);
            dtpProductionStart_Date.SetTime(DateTime.Now);

            dtMeterialReq.Clear();
            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;

            dtSMV_BreakDown.Clear();
            dgr_SmvBreakDown.ItemsSource = dtSMV_BreakDown.DefaultView;

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_JobStatus));
            cmbProdJobStatus.SetSelectedIndex((int)prod_JobStatus.BoMProd);

            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                btnGridItemDelete.Visibility = Visibility.Collapsed;
                txtReEditComments.Visibility = Visibility.Visible;
            }
            else
            {
                btnGridItemDelete.Visibility = Visibility.Visible;
                txtReEditComments.Visibility = Visibility.Collapsed;
            }

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtProdJobID.setReadOnlyStatus(true);
                txtProdJobID.Text = "<Auto Generate>";
            }
            else
                txtProdJobID.setReadOnlyStatus(false);
            #endregion

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

        }

        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                Cursor = Cursors.Wait;
                dgr_Main.dt.Clear();

                List<tbl_prod_polyTxJobCard> lstProdJobs;
                if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                    lstProdJobs = tbl_prod_polyTxJobCard.SelectAll().Where(p => p.ProdJob_ID != "default" && p.IsApproved2).OrderByDescending(o => o.DateCreate).ToList();
                else
                    lstProdJobs = tbl_prod_polyTxJobCard.SelectAll().Where(p => p.ProdJob_ID != "default" && p.IsApproved1).OrderByDescending(o => o.DateCreate).ToList();

                int iCount = 0;
                foreach (tbl_prod_polyTxJobCard oJob in lstProdJobs)
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                    if (oItem != null)
                    {
                        decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oJob.Item_ID_FG, oItem.ItemCategorySub_ID, "default", "0", "0");
                        dgr_Main.dt.Rows.Add(++iCount, oJob.ProdJob_ID, oJob.ProdJobDate.ToString(clsValidation.Format_Date), clsGenaralName.getDescription_Item(oJob.Item_ID_FG), clsFormatter.FormatDecimalPlaces_Quantity(oJob.OrderedQty), clsFormatter.FormatDecimalPlaces_Quantity(dStockQty), clsGenaralName.getName_Customer(oJob.Customer_ID), clsGenaralName.getName_User(oJob.CreateUser_ID), clsGenaralName.getName_User(oJob.Approved2User_ID), oJob.IsCanceled);
                    }
                }
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

            CheckSpecialPermision_EditBoM();
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishedGoodItemDescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOMQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodOrderedQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishedGoodPlannedQty))
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
                    txtProdJobID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtProdJobID.Text = txtProdJobID.Tag.ToString();
                }

                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private void CheckSpecialPermision_EditBoM()
        {
            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                if (txtReEditComments.TextBox1.Text.Length > 0)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "All BoM costing data is going to be reset\n  Are you sure you want to edit this BOM?", MessageBoxButton.YesNo);
                    if (bMessegeBoxResult)
                    {
                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                        frmTwoStepVerify.ShowDialog();
                        if (frmTwoStepVerify.bVerified)
                            bIsSpecialPermission_EditBoM = true;

                        frmTwoStepVerify.Close();
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Why do you edit?", "Please, add a comment....", MessageBoxButton.OK, "Red");
                    txtReEditComments.Focus();
                }
            }
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                Cursor = Cursors.Wait;

                ClearFields();
                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sID);
                if (oJob != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOMQty.Tag = oJob.Uom_ID;
                    txtFinishGoodUOMWeight.Tag = oJob.Item_Weight_UoM_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID);

                    txtProdJobID.Text = oJob.ProdJob_ID;
                    txtComments.Text = oJob.Remarks;
                    txtReEditComments.Text = oJob.Remarks2;
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID == "default" ? "" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID == "default" ? "" : oJob.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOMQty.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodUOMWeight.Text = clsGenaralName.getName_UomAndCode(oJob.Item_Weight_UoM_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(oJob.WastePercent, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(oJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    if (oJob.IsApproved2)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oJob.IsChecked2)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    fillMaterialGrid(oJob.ProdJob_ID);
                    fillProdOperationGrid(oJob.ProdJob_ID);

                    txtFinishedGoodEstWastage_LostFocus(null, null);
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

        private void fillMaterialGrid(string sProdJob_ID)
        {
            dtMeterialReq.Clear();
            foreach (tbl_prod_polyTxJobCard_Material oJob_Meterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No_Sub1 == 0 && r.Line_No_Sub2 == 0))
            {
                frm_RawMeterial_SemiFinished frmSemi = new frm_RawMeterial_SemiFinished("");
                dtMeterialReq.Rows.Add("", oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID),
                    oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
                    oJob_Meterial.Uom_ID_Weight, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID_Weight),
                    cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.InputWeight, clsConfig.sDecimalPlaces_Weight),
                    cls_Formater.FormatDecimal(oJob_Meterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal((oJob_Meterial.InputWeight * (100 + oJob_Meterial.WastagePercent) / 100), clsConfig.sDecimalPlaces_Weight),
                    oJob_Meterial.Section_ID, clsGenaralName.getName_Section(oJob_Meterial.Section_ID),
                    cls_Formater.FormatDecimal(oJob_Meterial.Smv_TimeMinutes, 2),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalLabour, 2),
                    oJob_Meterial.IsSemiFinishItem, frmSemi);
                foreach (tbl_prod_polyTxJobCard_Material oJob_Meterial_ForSemi in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 != 0 && r.Line_No_Sub2 == 0))
                {
                    frmSemi.dtMeterialReq.Rows.Add("", oJob_Meterial_ForSemi.Item_ID, clsGenaralName.getName_Item(oJob_Meterial_ForSemi.Item_ID), 
                        oJob_Meterial_ForSemi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSemi.Uom_ID),
                        oJob_Meterial_ForSemi.Uom_ID_Weight, clsGenaralName.getName_Uom(oJob_Meterial_ForSemi.Uom_ID_Weight),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.InputWeight, clsConfig.sDecimalPlaces_Weight),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                         cls_Formater.FormatDecimal((oJob_Meterial_ForSemi.InputWeight * (100 + oJob_Meterial_ForSemi.WastagePercent) / 100), clsConfig.sDecimalPlaces_Weight),
                        oJob_Meterial_ForSemi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSemi.Section_ID),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.Smv_TimeMinutes, 2),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalLabour, 2));
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(frmSemi.dtMeterialReq);
            }

            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;
        }

        private void fillProdOperationGrid(string sProdJob_ID)
        {
            dtSMV_BreakDown.Clear();
            foreach (tbl_prod_polyTxJobCard_ProductionOperation oProdOperation in tbl_prod_polyTxJobCard_ProductionOperation.SelectAllByProdJob_ID(sProdJob_ID))
            {
                tbl_prod_polyMasProductionOperation oMasOper = tbl_prod_polyMasProductionOperation.Select(oProdOperation.Operation_ID);
                if (oMasOper != null)
                {
                    dtSMV_BreakDown.Rows.Add(oProdOperation.Line_No, oProdOperation.Operation_ID, oMasOper.Description, cls_Formater.FormatDecimal(oProdOperation.Smv_Per_Pc, 2));
                }
            }
            dgr_SmvBreakDown.ItemsSource = dtSMV_BreakDown.DefaultView;

            CalculateTotalSMVTime();
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
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Meterial Grid

        private void dgr_MererialReq_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_MererialReq.SelectedIndex;
            var vDG_Cell = dgr_MererialReq.CurrentCell;
            try
            {
                bool bSemiFinished = bool.Parse(dtMeterialReq.Rows[irowID]["IsSemiFinished"].ToString());
                if ((vDG_Cell.Column.SortMemberPath == "ItemName" || vDG_Cell.Column.SortMemberPath == "IsSemiFinished") && bSemiFinished)
                {
                    try
                    {
                        frm_RawMeterial_SemiFinished frmSemi = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                        frmSemi.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                }
                else if (vDG_Cell.Column.SortMemberPath == "SectionName")
                {
                    frm_search RowDataSearch = new frm_search();
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtMeterialReq.Rows[irowID]["SectionID"] = lstResult[0];
                        dtMeterialReq.Rows[irowID]["SectionName"] = lstResult[1];
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void dgr_MererialReq_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);
        }

        private void dgr_MererialReq_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "Qty" || sColumnSortMember == "Weight" || sColumnSortMember == "Wastage" || sColumnSortMember == "LabourCount" || sColumnSortMember == "EstTime")
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

                if (sColumnSortMember == "EstTime" || sColumnSortMember == "LabourCount")
                    t.Text = cls_Formater.FormatDecimal(dQty, 2);
                else
                    t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }
            CalculateTotalQty();
            CalculateTotalSMVTime();
        }

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[9].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#FFA0A0");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_SmvBreakDown_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "SMV_PerPC")
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
            CalculateTotalSMVTime();

        }

        #endregion

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

        #region Search Events
        private void RowDataSearch_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtMeterialReq.Select("Item_ID ='" + lstResult[0] + "'");
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
                        frm_RawMeterial_SemiFinished frmSemi = new frm_RawMeterial_SemiFinished(txtFinishedGoodItemDescription.Tag.ToString());
                        if (oItem.IsSemiFinishGood)
                        {
                            tbl_prod_polyTxJobCard oProdJob = tbl_prod_polyTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).FirstOrDefault();
                            if (oProdJob != null)
                            {
                                foreach (tbl_prod_polyTxJobCard_Material oProJobMaterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(oProdJob.ProdJob_ID))
                                {
                                    frmSemi.dtMeterialReq.Rows.Add("", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID),
                                        oItem.Uom_ID,
                                        clsGenaralName.getName_Uom(oItem.Uom_ID),
                                        oProJobMaterial.Uom_ID_Weight,
                                        clsGenaralName.getName_Uom(oProJobMaterial.Uom_ID_Weight),
                                        cls_Formater.FormatDecimal(oProJobMaterial.InputQty, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(oProJobMaterial.InputWeight, clsConfig.sDecimalPlaces_Weight),
                                        cls_Formater.FormatDecimal(oProJobMaterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Weight),
                                        oProJobMaterial.Section_ID, clsGenaralName.getName_Section(oProJobMaterial.Section_ID),
                                        cls_Formater.FormatDecimal(oProJobMaterial.Smv_TimeMinutes, 2),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalLabour, 2));
                                }

                                clsHelpMethods_Prod.OrderBy_DataGrid(frmSemi.dtMeterialReq);
                            }
                        }

                        dtMeterialReq.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID),
                            oItem.Uom_ID,
                            clsGenaralName.getName_Uom(oItem.Uom_ID),
                            txtFinishGoodUOMWeight.Tag != null ? txtFinishGoodUOMWeight.Tag.ToString() : "default",
                            txtFinishGoodUOMWeight.Tag != null ? clsGenaralName.getName_Uom(txtFinishGoodUOMWeight.Tag.ToString()) : "-",
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Weight),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Weight),
                            "default",
                            "<Select Section>",
                            "0.00",
                            "0.00",
                            oItem.IsSemiFinishGood, frmSemi);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                fillDetails(lstResult[0]);
            }
        }

        #endregion

        #region Other Text Box Events
        private void txtFinishedGoodEstWastage_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dInputQty = clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedQty.Text);
            decimal dInputWeight = clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedWeight.Text);
            decimal dWastagePct = clsValidation.Validate_DecimalNumber(txtFinishedGoodEstWastage.TextBox1.Text);
            decimal dPlannedQty = (dInputQty * (dWastagePct + 100) / 100);
            decimal dPlannedWeight = (dInputWeight * (dWastagePct + 100) / 100);

            txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(dPlannedQty, clsConfig.sDecimalPlaces_Quantity);
            txtFinishedGoodPlannedWeight.Text = cls_Formater.FormatDecimal(dPlannedWeight, clsConfig.sDecimalPlaces_Quantity);

        }

        private void txtFinishedGoodEstWastage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtFinishedGoodEstWastage_LostFocus(sender, e);
            }
        }
        #endregion

        #region Other Events

        private void lblNextUI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_BOMCosting UC;
            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOMCosting(txtProdJobID.Tag.ToString(), FormName.Prod_BOMDetails_Production_SpecialPermission);
                else
                    UC = new UC_BOMCosting(FormName.Prod_BOMDetails_Production_SpecialPermission);
            }
            else
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOMCosting(txtProdJobID.Tag.ToString(), FormName.Prod_BOMCosting_Finance);
                else
                    UC = new UC_BOMCosting(FormName.Prod_BOMCosting_Finance);
            }
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            SW.ShowDialog();
        }

        #endregion

        #region Help Methods
        private void CalculateTotalSMVTime()
        {
            try
            {
                string sSum = dtSMV_BreakDown.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("SMV_PerPC"))).ToString();
                txtTotSMVTimeMins.Text = cls_Formater.FormatDecimal(decimal.Parse(sSum.ToString()), 2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void CalculateTotalQty()
        {
            try
            {
                foreach (DataRow row in dtMeterialReq.Rows)
                {
                    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                    decimal dWeight = clsValidate.ValidateRowValue(row, "Weight", 0);
                    decimal dwastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0);

                    row["TotalQty"] = cls_Formater.FormatDecimal(dQty * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Quantity);
                    row["TotalWeight"] = cls_Formater.FormatDecimal(dWeight * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Weight);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

    }
}
