using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_APPAREL.Common;
using SEACC_PRODUCTION_APPAREL.Search;
using SEACC_PRODUCTION_APPAREL.Controls;
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
using SEACC_PRODUCTION_APPAREL.DataSets;

namespace SEACC_PRODUCTION_APPAREL.Transactions
{
    /// <summary>
    /// Developed by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class UC_BOM_Production : UserControl
    {
        #region Class Variables
        dts_BoM glb_dtsBoMs = new dts_BoM();
        dts_ReportExport glb_dts_ExportReport = new dts_ReportExport();

        DataTable dtMeterialReq = new DataTable();
        DataTable dtSMV_BreakDown = new DataTable();
        DataTable dtWIP_Flow = new DataTable();
        DataTable dtSubIn_Items = new DataTable();
        BrushConverter bc = new BrushConverter();
        private bool bEditAfterApproved_Mode = false;
        #endregion

        #region Form Load
        public UC_BOM_Production(FormName enmForm)
        {
            AppDomainInitializer(enmForm);
        }

        public UC_BOM_Production(string sBoM_ID, FormName enmForm)
        {
            AppDomainInitializer(enmForm);
            FillDetails(sBoM_ID);
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
            dtMeterialReq.Columns.Add("LineNo",typeof(int));
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("EstTime");
            dtMeterialReq.Columns.Add("LabourCount");
            dtMeterialReq.Columns.Add("IsSemiFinished", typeof(bool));
            dtMeterialReq.Columns.Add("SemiFinished_RawMeterials", typeof(frm_RawMeterial_SemiFinished));
            dtMeterialReq.Columns.Add("Substitute_RawMeterials", typeof(frm_RawMeterial_SemiFinished));
            dtMeterialReq.Columns.Add("MatOption_Count");
            #endregion

            #region WIP Flow Table
            dtWIP_Flow.Columns.Add("LineNo");
            dtWIP_Flow.Columns.Add("Item_ID");
            dtWIP_Flow.Columns.Add("ItemName");
            dtWIP_Flow.Columns.Add("UoM_ID");
            dtWIP_Flow.Columns.Add("UoM_Name");
            dtWIP_Flow.Columns.Add("Qty");
            dtWIP_Flow.Columns.Add("InSection_ID");
            dtWIP_Flow.Columns.Add("InSection_Name");
            dtWIP_Flow.Columns.Add("OutSection_ID");
            dtWIP_Flow.Columns.Add("OutSection_Name");
            dtWIP_Flow.Columns.Add("Material_Count");
            dtWIP_Flow.Columns.Add("Materials", typeof(List<cls_BoMDetailMaterial>));
            dtWIP_Flow.Columns.Add("isSubOut");
            #endregion

            #region Sub In Item Table
            dtSubIn_Items.Columns.Add("LineNo");
            dtSubIn_Items.Columns.Add("MatGrid_LineNo");
            dtSubIn_Items.Columns.Add("Item_ID");
            dtSubIn_Items.Columns.Add("ItemName");
            dtSubIn_Items.Columns.Add("UoM_ID");
            dtSubIn_Items.Columns.Add("UoM_Name");
            dtSubIn_Items.Columns.Add("Qty");
            dtSubIn_Items.Columns.Add("Section_ID");
            dtSubIn_Items.Columns.Add("Section");
            dtSubIn_Items.Columns.Add("Material_Count");
            dtSubIn_Items.Columns.Add("Materials", typeof(frm_MaterialSelection_SubIn));
            #endregion

            #region SMV Break Down
            dtSMV_BreakDown.Columns.Add("LineNo");
            dtSMV_BreakDown.Columns.Add("Operation_ID");
            dtSMV_BreakDown.Columns.Add("Operation_Name");
            dtSMV_BreakDown.Columns.Add("SMV_PerPC");
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("JOBNO");
            dgr_Main.dt.Columns.Add("JOB_DATE");
            dgr_Main.dt.Columns.Add("ITEM");
            dgr_Main.dt.Columns.Add("CUSTOMER");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("PREPARED_DATE");
            dgr_Main.dt.Columns.Add("MODIFIED_BY");
            dgr_Main.dt.Columns.Add("MODIFIED_DATE");
            dgr_Main.dt.Columns.Add("APPROVED2_BY");
            dgr_Main.dt.Columns.Add("APPROVED2_DATE");
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job #", "JOBNO", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JOB_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "ITEM", 200);
            dgr_Main.Add_DatagridColoumn("Customer", "CUSTOMER", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "PREPARED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "MODIFIED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "MODIFIED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED2_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved Date", "APPROVED2_DATE", 100);
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
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oBoM != null)
                            {
                                if (oBoM.IsApproved1 || bEditAfterApproved_Mode)
                                {
                                    if ((!oBoM.IsApproved2 && !oBoM.IsApproved3) || bEditAfterApproved_Mode)
                                    {
                                        #region BoM Status Set up
                                        int iBoM_Status = 0;
                                        if (oBoM.ProdJobStatus < (int)prod_BoM_Status.BoMProd)
                                            iBoM_Status = (int)prod_BoM_Status.BoMProd;
                                        else
                                            iBoM_Status = oBoM.ProdJobStatus;
                                        #endregion

                                        #region BoM Header Table Update
                                        tbl_prodTxJobCard oOldJob = new tbl_prodTxJobCard(
                                                                    oBoM.ProdJob_ID, dtpProdJob_Date.GetDateTime(), iBoM_Status, //cmbProdJobStatus.GetSelectedIndex(),
                                                                    oBoM.Salesman_ID,
                                                                    oBoM.Customer_ID,
                                                                    txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                                                    txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                                                    txtComments.Text,
                                                                    txtReEditComments.Text,
                                                                    oBoM.JobType_ID, oBoM.ProdRange_ID, oBoM.ProdCategory_ID, oBoM.ProdSize_ID, oBoM.Colour_ID,
                                                                    txtPreviousBoMTemplate.Tag != null ? txtPreviousBoMTemplate.Tag.ToString() : "default",
                                                                    oBoM.Item_ID_FG,
                                                                    txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                                                    oBoM.Item_Length, oBoM.Item_Length_UoM_ID, oBoM.Item_Width, oBoM.Item_Weight_UoM_ID, oBoM.Item_Height, oBoM.Item_Height_UoM_ID, oBoM.Item_Diameter, oBoM.Item_Diameter_UoM_ID, oBoM.Item_Radius, oBoM.Item_Radius_UoM_ID, oBoM.Item_Thickness, oBoM.Item_Thickness_UoM_ID, oBoM.Item_Weight, oBoM.Item_Weight_UoM_ID,
                                                                    decimal.Parse(txtFinishGoodOrderedQty.Text), decimal.Parse(txtFinishedGoodPlannedQty.Text), decimal.Parse(txtFinishedGoodEstWastage.Text), oBoM.WasteQty, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
                                                                    oBoM.EstProdHrs,
                                                                    oBoM.IsChecked1, oBoM.IsChecked2, oBoM.IsChecked3,
                                                                    oBoM.IsApproved1, oBoM.IsApproved2, oBoM.IsApproved3,
                                                                    oBoM.IsCanceled, oBoM.IsLocked,
                                                                    oBoM.CreateUser_ID, clsSecurity.UserIDLoged,
                                                                    oBoM.Checked1User_ID, oBoM.Checked2User_ID, oBoM.Checked3User_ID,
                                                                    oBoM.Approved1User_ID, oBoM.Approved2User_ID, oBoM.Approved3User_ID,
                                                                    oBoM.CanceldUser_ID, oBoM.LockedUser_ID,
                                                                    oBoM.DateCreate, clsSecurity.getServerDateTime(),
                                                                    oBoM.DateChecked1, oBoM.DateChecked2, oBoM.DateChecked3,
                                                                    oBoM.DateApproved1, oBoM.DateApproved2, oBoM.DateApproved3,
                                                                    oBoM.DateCanceled, oBoM.DateLocked,
                                                                    oBoM.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                                                    oBoM.Checked1UserTerminal_ID, oBoM.Checked2UserTerminal_ID, oBoM.Checked3UserTerminal_ID,
                                                                    oBoM.Approved1UserTerminal_ID, oBoM.Approved2UserTerminal_ID, oBoM.Approved3UserTerminal_ID,
                                                                    oBoM.CanceledUserTerminal_ID, oBoM.LockedUserTerminal_ID, oBoM.CompanyID, oBoM.CompanyBranchID, oBoM.CustomerOrder_Qty);
                                        oOldJob.Update();
                                        #endregion

                                        DataTable dtItemCost_EditAfterApproved_Mode = Get_ItemCosting_ForEditAfterApproved(oBoM.ProdJob_ID, bEditAfterApproved_Mode);

                                        if (!oBoM.IsApproved2 && !oBoM.IsApproved3)
                                        {
                                            #region Normal BoM Detail Save
                                            Delete_SubInb_Data();
                                            if (clsHelpMethods_Prod.Get_BatchCount_ForBoM(oBoM.ProdJob_ID) < 1) //Check Batch Count and There is no any batch related to the BoM
                                            {
                                                #region Delete Exist Raw Material Data
                                                foreach (tbl_prodTxJobCard_Material_Outsource oItem_Outsource in tbl_prodTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtProdJobID.Text))
                                                {
                                                    oItem_Outsource.Delete();
                                                }

                                                tbl_prodTxJobCard_Material.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                foreach (tbl_prodTxJobCard_WIPFlow oObj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                                    tbl_prodTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);

                                                tbl_prodTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                #endregion

                                                #region BoM Material Insert
                                                foreach (DataRow row in dtMeterialReq.Rows)
                                                {
                                                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                    string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                    decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                    decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                    decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                    string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                    decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                    decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
                                                    bool IsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);

                                                    decimal dItemWAvgCost = 0;
                                                    decimal dLowestCost = 0;
                                                    decimal dHighestCost = 0;
                                                    decimal dBoMCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID));
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                    if (oItem != null && IsSemiFinished)
                                                    {
                                                        oItem.IsSemiFinishGood = true;
                                                        oItem.Update();
                                                    }
                                                    tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                    if (oItem_Finance != null)
                                                    {
                                                        dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;
                                                        dLowestCost = oItem_Finance.LowestPurchaseCostPrice;
                                                        dHighestCost = oItem_Finance.HighestPurchaseCostPrice;
                                                    }

                                                    #region Total Cost Without Tax for Semi Finisheds and Row Material Cost
                                                    tbl_prodTxJobCard_Material oNewProdMaterial;
                                                    if (IsSemiFinished)
                                                    {
                                                        //SF Items
                                                        oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dBoMCost, (int)prod_Costing_Mode.BoM_Cost, dBoMCost, false, 0, 1);
                                                        oNewProdMaterial.Insert();
                                                    }
                                                    else
                                                    {
                                                        decimal dEditedCost = (dItemWAvgCost * dTotalQty);
                                                        decimal dSF_BoMCost = 0;
                                                        int iCostType = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                        if (oItem.IsSemiFinishGood)
                                                        {
                                                            if (dSF_BoMCost > 0)
                                                            {
                                                                dEditedCost = (dSF_BoMCost * dTotalQty);
                                                                iCostType = (int)prod_Costing_Mode.BoM_Cost;
                                                            }
                                                        }
                                                        oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dSF_BoMCost, iCostType, dEditedCost, false, dEditedCost, 1);
                                                        oNewProdMaterial.Insert();
                                                    }
                                                    #endregion

                                                    #region Semi Finisheds Outsource Rate

                                                    if (IsSemiFinished && oNewProdMaterial != null)
                                                    {
                                                        List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                        decimal dSF_MaxOutsouceRate = 0;
                                                        if (oList_ItemOutsource.Count > 0)
                                                            dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                        tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                        oSF_Outsource.Insert();
                                                    }
                                                    #endregion

                                                    //Items Saving of a Semi Finished 
                                                    frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                    if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                    {
                                                        foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                            string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                            string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                            decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                            decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                            decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                            string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                            decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                            decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_sub = 0;
                                                            decimal dLowestCost_sub = 0;
                                                            decimal dHighestCost_sub = 0;
                                                            decimal dBoMCost_sub = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID_sub));
                                                            tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                            tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                            if (oItem_Finance_sub != null)
                                                            {
                                                                dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                            }

                                                            tbl_prodTxJobCard_Material oNewMat_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                            oNewMat_Semi.Insert();

                                                            //Substitute Materials for Semi Finisheds Saving
                                                            frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                            if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                            {
                                                                foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                {
                                                                    int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                    string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                    string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                    decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                    decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                    decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                    string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                    decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                    decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                    decimal dItemWAvgCost_substitute_Semi = 0;
                                                                    decimal dLowestCost_substitute_Semi = 0;
                                                                    decimal dHighestCost_substitute_Semi = 0;
                                                                    decimal dBoMCost_substitute_Semi = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID_substitute_Semi));
                                                                    tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                    if (oItem_Finance_substitute_Semi != null)
                                                                    {
                                                                        dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                        dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                        dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                    oNewMat_Substitute_Semi.Insert();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    //Substitute Materials Saving
                                                    frm_RawMeterial_SemiFinished frmSubtitute_Main = row.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                    if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                            string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                            string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                            decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                            decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                            decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                            string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                            decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                            decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_substitute_Main = 0;
                                                            decimal dLowestCost_substitute_Main = 0;
                                                            decimal dHighestCost_substitute_Main = 0;
                                                            decimal dBoMCost_substitute_Main = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID_substitute_Main));
                                                            tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                            if (oItem_Finance_substitute_Main != null)
                                                            {
                                                                dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                                dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                                dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                            }

                                                            tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                            oNewMat_Substitute_Main.Insert();
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            else //Check Batch Count and There are batches related to the BoM
                                            {
                                                #region Update Exist Data

                                                #region Raw Materials
                                                foreach (DataRow row in dtMeterialReq.Rows)
                                                {
                                                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                    string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                    decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                    decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                    decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                    string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                    decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                    decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
                                                    bool IsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);
                                                    frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                    frm_RawMeterial_SemiFinished frmSubtitute_Main = row.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                    tbl_prodTxJobCard_Material oMaterial = tbl_prodTxJobCard_Material.Select(iLine_no, 0, 0, txtProdJobID.Text.Trim());

                                                    #region Already Exist
                                                    if (oMaterial != null)
                                                    {
                                                        #region Main Item
                                                        oMaterial.InputQty = dConsumption;
                                                        oMaterial.Consumption = dConsumption;
                                                        oMaterial.WastagePercent = dWastage_Pct;
                                                        oMaterial.TotalInputQty = dTotalQty;
                                                        oMaterial.Section_ID = sSection_ID;
                                                        oMaterial.Smv_TimeMinutes = dSMV_Time;
                                                        oMaterial.TotalLabour = dLabourCount;
                                                        oMaterial.IsSemiFinishItem = IsSemiFinished;
                                                        oMaterial.Wipout_sf_Index = 1;

                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                        if (oItem != null && IsSemiFinished)
                                                        {
                                                            oItem.IsSemiFinishGood = true;
                                                            oItem.Update();
                                                        }
                                                        tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                        if (oItem_Finance != null)
                                                        {
                                                            oMaterial.WeightedAvgCost = oItem_Finance.WeightedAverageCostPrice;
                                                            oMaterial.LowestCost = oItem_Finance.LowestPurchaseCostPrice;
                                                            oMaterial.HighestCost = oItem_Finance.HighestPurchaseCostPrice;
                                                            oMaterial.BomCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance.Item_ID));
                                                        }

                                                        #region Total Cost (Without Tax for Semi Finisheds)

                                                        if (IsSemiFinished)
                                                        {
                                                            //SF Items
                                                            decimal dCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID));
                                                            oMaterial.CostTypeSelection = (int)prod_Costing_Mode.BoM_Cost;
                                                            oMaterial.BomCost = dCost;
                                                            oMaterial.Cost = dCost;
                                                            oMaterial.EditedCost = 0;
                                                        }
                                                        else
                                                        {
                                                            //Row Materials
                                                            decimal dEditedCost = (oMaterial.WeightedAvgCost * dTotalQty);
                                                            oMaterial.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                            oMaterial.Cost = dEditedCost;
                                                            oMaterial.EditedCost = dEditedCost;
                                                        }
                                                        #endregion

                                                        oMaterial.Update();
                                                        #endregion

                                                        #region SF Item's Materials
                                                        if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                        {
                                                            foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                                string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                                string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                                decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                                decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                                decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                                string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                                decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                                decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);
                                                                frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                                tbl_prodTxJobCard_Material oNewMat_Semi = tbl_prodTxJobCard_Material.Select(iLine_no, iLine_no_semi, 0, txtProdJobID.Text.Trim());
                                                                if (oNewMat_Semi != null)
                                                                {
                                                                    #region Semi Finished Item Materials
                                                                    oNewMat_Semi.InputQty = dQty_sub;
                                                                    oNewMat_Semi.Consumption = dQty_sub;
                                                                    oNewMat_Semi.WastagePercent = dWastage_Pct_sub;
                                                                    oNewMat_Semi.TotalInputQty = dTotalQty_sub;
                                                                    oNewMat_Semi.Section_ID = sSection_ID_sub;
                                                                    oNewMat_Semi.Smv_TimeMinutes = dSMV_Time_sub;
                                                                    oNewMat_Semi.TotalLabour = dLabourCount_sub;
                                                                    oNewMat_Semi.Wipout_sf_Index = 1;

                                                                    tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                    if (oItem_Finance_sub != null)
                                                                    {
                                                                        oNewMat_Semi.WeightedAvgCost = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                        oNewMat_Semi.LowestCost = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                        oNewMat_Semi.HighestCost = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                                        oNewMat_Semi.BomCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_sub.Item_ID));
                                                                    }

                                                                    oNewMat_Semi.CostTypeSelection = 0;
                                                                    oNewMat_Semi.Cost = (oNewMat_Semi.WeightedAvgCost * dTotalQty_sub);
                                                                    oNewMat_Semi.EditedCost = oNewMat_Semi.Cost;

                                                                    oNewMat_Semi.Update();
                                                                    #endregion

                                                                    #region Substitutes of SF Raw Materilas
                                                                    if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                        {
                                                                            int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                            string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                            string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                            decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                            decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                            decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                            string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                            decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                            decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                            tbl_prodTxJobCard_Material oSubstitute_Mat_Semi = tbl_prodTxJobCard_Material.Select(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, txtProdJobID.Text.Trim());
                                                                            if (oSubstitute_Mat_Semi != null)
                                                                            {
                                                                                #region Semi Finished Item Materials
                                                                                oSubstitute_Mat_Semi.InputQty = dQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Consumption = dQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.WastagePercent = dWastage_Pct_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.TotalInputQty = dTotalQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Section_ID = sSection_ID_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Smv_TimeMinutes = dSMV_Time_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.TotalLabour = dLabourCount_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Wipout_sf_Index = 1;

                                                                                tbl_genItemMaster oItem_sub_semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                                tbl_genItemMaster_Pricing oItem_Finance_sub_semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                                if (oItem_Finance_sub_semi != null)
                                                                                {
                                                                                    oSubstitute_Mat_Semi.WeightedAvgCost = oItem_Finance_sub_semi.WeightedAverageCostPrice;
                                                                                    oSubstitute_Mat_Semi.LowestCost = oItem_Finance_sub_semi.LowestPurchaseCostPrice;
                                                                                    oSubstitute_Mat_Semi.HighestCost = oItem_Finance_sub_semi.HighestPurchaseCostPrice;
                                                                                    oSubstitute_Mat_Semi.BomCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_sub_semi.Item_ID));
                                                                                }

                                                                                oSubstitute_Mat_Semi.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                                                oSubstitute_Mat_Semi.Cost = (oSubstitute_Mat_Semi.WeightedAvgCost * dTotalQty_substitute_Semi);
                                                                                oSubstitute_Mat_Semi.EditedCost = oSubstitute_Mat_Semi.Cost;

                                                                                oSubstitute_Mat_Semi.Update();
                                                                                #endregion
                                                                            }
                                                                            else
                                                                            {
                                                                                decimal dItemWAvgCost_substitute_Semi = 0;
                                                                                decimal dLowestCost_substitute_Semi = 0;
                                                                                decimal dHighestCost_substitute_Semi = 0;
                                                                                decimal dBoMCost_substitute_Semi = 0;
                                                                                tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                                if (oItem_Finance_substitute_Semi != null)
                                                                                {
                                                                                    dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                                    dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                                    dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                                    dBoMCost_substitute_Semi = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Semi.Item_ID));
                                                                                }

                                                                                tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                                oNewMat_Substitute_Semi.Insert();

                                                                            }
                                                                        }
                                                                    }
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    decimal dItemWAvgCost_sub = 0;
                                                                    decimal dLowestCost_sub = 0;
                                                                    decimal dHighestCost_sub = 0;
                                                                    decimal dBoMCost_sub = 0;
                                                                    tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                    if (oItem_Finance_sub != null)
                                                                    {
                                                                        dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                        dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                        dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                                        dBoMCost_sub = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_sub.Item_ID));
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_forSemi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                                    oNewMat_forSemi.Insert();

                                                                    //Substitute Materials for Semi Finisheds Saving
                                                                    if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                        {
                                                                            int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                            string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                            string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                            decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                            decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                            decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                            string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                            decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                            decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                            decimal dItemWAvgCost_substitute_Semi = 0;
                                                                            decimal dLowestCost_substitute_Semi = 0;
                                                                            decimal dHighestCost_substitute_Semi = 0;
                                                                            decimal dBoMCost_substitute_Semi = 0;
                                                                            tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                            if (oItem_Finance_substitute_Semi != null)
                                                                            {
                                                                                dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                                dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                                dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                                dBoMCost_substitute_Semi = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Semi.Item_ID));
                                                                            }

                                                                            tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                            oNewMat_Substitute_Semi.Insert();
                                                                        }
                                                                    }
                                                                }

                                                            }

                                                        }
                                                        #endregion

                                                        #region Substitues for Main Items
                                                        if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                                string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                                string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                                decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                                decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                                decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                                string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                                decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                                decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);


                                                                tbl_prodTxJobCard_Material oSubstituteMeterial = tbl_prodTxJobCard_Material.Select(iLine_no, 0, iLine_no_substitute_Main, txtProdJobID.Text.Trim());
                                                                if (oSubstituteMeterial != null)
                                                                {
                                                                    #region Semi Finished Item Materials
                                                                    oSubstituteMeterial.InputQty = dQty_substitute_Main;
                                                                    oSubstituteMeterial.Consumption = dQty_substitute_Main;
                                                                    oSubstituteMeterial.WastagePercent = dWastage_Pct_substitute_Main;
                                                                    oSubstituteMeterial.TotalInputQty = dTotalQty_substitute_Main;
                                                                    oSubstituteMeterial.Section_ID = sSection_ID_substitute_Main;
                                                                    oSubstituteMeterial.Smv_TimeMinutes = dSMV_Time_substitute_Main;
                                                                    oSubstituteMeterial.TotalLabour = dLabourCount_substitute_Main;
                                                                    oSubstituteMeterial.Wipout_sf_Index = 1;

                                                                    tbl_genItemMaster oItem_sub_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_sub_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                    if (oItem_Finance_sub_Main != null)
                                                                    {
                                                                        oSubstituteMeterial.WeightedAvgCost = oItem_Finance_sub_Main.WeightedAverageCostPrice;
                                                                        oSubstituteMeterial.LowestCost = oItem_Finance_sub_Main.LowestPurchaseCostPrice;
                                                                        oSubstituteMeterial.HighestCost = oItem_Finance_sub_Main.HighestPurchaseCostPrice;
                                                                        oSubstituteMeterial.BomCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_sub_Main.Item_ID));
                                                                    }

                                                                    oSubstituteMeterial.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                                    oSubstituteMeterial.Cost = (oSubstituteMeterial.WeightedAvgCost * dTotalQty_substitute_Main);
                                                                    oSubstituteMeterial.EditedCost = oSubstituteMeterial.Cost;

                                                                    oSubstituteMeterial.Update();
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    decimal dItemWAvgCost_substitute_Main = 0;
                                                                    decimal dLowestCost_substitute_Main = 0;
                                                                    decimal dHighestCost_substitute_Main = 0;
                                                                    decimal dBoMCost_substitute_Main = 0;
                                                                    tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                    if (oItem_Finance_substitute_Main != null)
                                                                    {
                                                                        dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                                        dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                                        dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                                        dBoMCost_substitute_Main = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Main.Item_ID));
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                                    oNewMat_Substitute_Main.Insert();
                                                                }

                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region Newly Add
                                                    else
                                                    {
                                                        decimal dItemWAvgCost = 0;
                                                        decimal dLowestCost = 0;
                                                        decimal dHighestCost = 0;
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                        if (oItem != null && IsSemiFinished)
                                                        {
                                                            oItem.IsSemiFinishGood = true;
                                                            oItem.Update();
                                                        }
                                                        tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                        if (oItem_Finance != null)
                                                        {
                                                            dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;
                                                            dLowestCost = oItem_Finance.LowestPurchaseCostPrice;
                                                            dHighestCost = oItem_Finance.HighestPurchaseCostPrice;
                                                        }

                                                        #region Total Cost Without Tax for Semi Finisheds
                                                        tbl_prodTxJobCard_Material oNewProdMaterial;
                                                        if (IsSemiFinished)
                                                        {
                                                            //SF Item
                                                            decimal dCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID));

                                                            oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dCost, (int)prod_Costing_Mode.BoM_Cost, dCost, false, 0, 1);
                                                            oNewProdMaterial.Insert();
                                                        }
                                                        else
                                                        {   //Raw Materials
                                                            decimal dEditedCost = (dItemWAvgCost * dTotalQty);
                                                            oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, 0, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost * dTotalQty), false, dEditedCost, 1);
                                                            oNewProdMaterial.Insert();
                                                        }

                                                        #endregion

                                                        #region Semi Finisheds Outsource Rate

                                                        if (IsSemiFinished && oNewProdMaterial != null)
                                                        {
                                                            List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                            decimal dSF_MaxOutsouceRate = 0;
                                                            if (oList_ItemOutsource.Count > 0)
                                                                dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                            tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                            oSF_Outsource.Insert();
                                                        }
                                                        #endregion

                                                        //Semi Finished Items Saving
                                                        if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                        {
                                                            foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                                string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                                string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                                decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                                decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                                decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                                string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                                decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                                decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                                decimal dItemWAvgCost_sub = 0;
                                                                decimal dLowestCost_sub = 0;
                                                                decimal dHighestCost_sub = 0;
                                                                decimal dBoMCost_sub = 0;
                                                                tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                if (oItem_Finance_sub != null)
                                                                {
                                                                    dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                    dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                    dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                                    dBoMCost_sub = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_sub.Item_ID));
                                                                }

                                                                tbl_prodTxJobCard_Material oNewMat_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                                oNewMat_Semi.Insert();

                                                                //Substitute Materials for Semi Finisheds Saving
                                                                frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                                if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                    {
                                                                        int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                        string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                        string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                        decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                        decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                        decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                        string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                        decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                        decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                        decimal dItemWAvgCost_substitute_Semi = 0;
                                                                        decimal dLowestCost_substitute_Semi = 0;
                                                                        decimal dHighestCost_substitute_Semi = 0;
                                                                        decimal dBoMcost_substitute_Semi = 0;
                                                                        tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                        tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                        if (oItem_Finance_substitute_Semi != null)
                                                                        {
                                                                            dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                            dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                            dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                            dBoMcost_substitute_Semi = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Semi.Item_ID));
                                                                        }

                                                                        tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMcost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                        oNewMat_Substitute_Semi.Insert();
                                                                    }
                                                                }

                                                            }

                                                        }

                                                        //Substitute Materials Saving
                                                        if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                                string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                                string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                                decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                                decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                                decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                                string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                                decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                                decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                                decimal dItemWAvgCost_substitute_Main = 0;
                                                                decimal dLowestCost_substitute_Main = 0;
                                                                decimal dHighestCost_substitute_Main = 0;
                                                                decimal dBoMCost_substitute_Main = 0;
                                                                tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                if (oItem_Finance_substitute_Main != null)
                                                                {
                                                                    dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                                    dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                                    dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                                    dBoMCost_substitute_Main = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Main.Item_ID));
                                                                }

                                                                tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                                oNewMat_Substitute_Main.Insert();
                                                            }
                                                        }
                                                        #endregion

                                                    }

                                                }
                                                #endregion

                                                foreach (tbl_prodTxJobCard_WIPFlow oObj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                                    tbl_prodTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);

                                                tbl_prodTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                #endregion
                                            }

                                            #region WIP Flow
                                            foreach (DataRow row in dtWIP_Flow.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                string sInSection_ID = clsValidate.ValidateRowValue(row, "InSection_ID", "default");
                                                string sOutSection_ID = clsValidate.ValidateRowValue(row, "OutSection_ID", "default");
                                                List<cls_BoMDetailMaterial> lstMats = row.Field<List<cls_BoMDetailMaterial>>("Materials");
                                                bool bSubOut = clsValidate.ValidateRowValue(row, "isSubOut", false);

                                                decimal dItemWAvgCost = 0;
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                if (oItem_Finance != null)
                                                    dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;


                                                tbl_prodTxJobCard_WIPFlow oSF_WIP = new tbl_prodTxJobCard_WIPFlow(iLine_no, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, dQty, 0, dItemWAvgCost, 0, (dQty * dItemWAvgCost), sInSection_ID, sOutSection_ID, bSubOut);
                                                oSF_WIP.Insert();

                                                foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => !r.BIsWIP_SF))
                                                {
                                                    tbl_prodTxJobCard_Material oProdMat = tbl_prodTxJobCard_Material.Select(oMat.ILineNo, oMat.ILine_No_Sub1, oMat.ILine_No_Sub2, oBoM.ProdJob_ID);
                                                    if (oProdMat != null)
                                                    {
                                                        tbl_prodTxJobCard_WIPFlow oSF_WIP_ForUpdateMats = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No == oSF_WIP.Line_No && r.Item_ID == oSF_WIP.Item_ID).FirstOrDefault();
                                                        oProdMat.Wipout_sf_Index = oSF_WIP_ForUpdateMats.Sf_Index;
                                                        oProdMat.Update();
                                                    }

                                                    //foreach (tbl_prodTxJobCard_Material oProdMat_Substitute in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.Line_No == oMat.ILineNo && r.Line_No_Sub1 == oMat.ILine_No_Sub1))
                                                    //{
                                                    //    /*
                                                    //     * As use of auto generated int for the primary key of this table, It is required to again call the method.
                                                    //     * Commented by Gayan
                                                    //     */
                                                    //    tbl_prodTxJobCard_WIPFlow oSF_WIP_ForUpdateMats = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.Line_No == oSF_WIP.Line_No && r.Item_ID == oSF_WIP.Item_ID).FirstOrDefault();
                                                    //    oProdMat_Substitute.Wipout_sf_Index = oSF_WIP_ForUpdateMats.Sf_Index;
                                                    //    oProdMat_Substitute.Update();
                                                    //}
                                                }
                                            }

                                            foreach (tbl_prodTxJobCard_WIPFlow oWIP_Obj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                            {
                                                DataRow row = dtWIP_Flow.Select("LineNo = " + oWIP_Obj.Line_No + " AND  Item_ID = '" + oWIP_Obj.Item_ID + "'").FirstOrDefault();
                                                if (row != null)
                                                {
                                                    List<cls_BoMDetailMaterial> lstMats = row.Field<List<cls_BoMDetailMaterial>>("Materials");
                                                    foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => r.BIsWIP_SF))
                                                    {
                                                        DataRow row_detail = dtWIP_Flow.Select("LineNo = " + oMat.ILineNo + " AND  Item_ID = '" + oMat.SItem_ID + "'").FirstOrDefault();
                                                        if (row_detail != null)
                                                        {
                                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row_detail, "LineNo", 0));
                                                            string sItem_ID = clsValidate.ValidateRowValue(row_detail, "Item_ID", "default");
                                                            tbl_prodTxJobCard_WIPFlow oWIP_Obj_Detail = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No == iLine_no && r.Item_ID == sItem_ID).FirstOrDefault();

                                                            if (oWIP_Obj_Detail != null)
                                                            {
                                                                tbl_prodTxJobCard_WIPFlow_Detail oWIPFlow_Detail = new tbl_prodTxJobCard_WIPFlow_Detail(oWIP_Obj.Sf_Index, oWIP_Obj_Detail.Sf_Index, sItem_ID);
                                                                oWIPFlow_Detail.Insert();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region SMV & Other Cost
                                            decimal dTotSMV = 0;
                                            foreach (DataRow row in dtSMV_BreakDown.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                string sOperation_ID = clsValidate.ValidateRowValue(row, "Operation_ID", "default");
                                                decimal dSMV_PerPC = clsValidate.ValidateRowValue(row, "SMV_PerPC", 0m);

                                                tbl_prodTxJobCard_ProductionOperation oProdOperation = tbl_prodTxJobCard_ProductionOperation.Select(iLine_no, txtProdJobID.Text);
                                                if (oProdOperation != null)
                                                {
                                                    oProdOperation.Smv_Per_Pc = dSMV_PerPC;
                                                    dTotSMV += dSMV_PerPC;
                                                    oProdOperation.Update();
                                                }
                                            }
                                            foreach (tbl_prodTxJobCard_CostCenter oProdCostCenter in tbl_prodTxJobCard_CostCenter.SelectAllByProdJob_ID(txtProdJobID.Text))
                                            {
                                                oProdCostCenter.Smv = dTotSMV;
                                                oProdCostCenter.Update();
                                            }
                                            #endregion

                                            Save_SubIn_Data();

                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

                                            #endregion
                                        }
                                        else if (bEditAfterApproved_Mode)
                                        {
                                            #region Edit After Approved BoM Detail Save

                                            if (clsHelpMethods_Prod.Get_BatchCount_ForBoM(oBoM.ProdJob_ID) < 1) //Check Batch Count and There is no any batch related to the BoM
                                            {
                                                #region Delete Exist Raw Material Data
                                                foreach (tbl_prodTxJobCard_Material_Outsource oItem_Outsource in tbl_prodTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtProdJobID.Text))
                                                {
                                                    oItem_Outsource.Delete();
                                                }

                                                tbl_prodTxJobCard_Material.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                foreach (tbl_prodTxJobCard_WIPFlow oObj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                                    tbl_prodTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);

                                                tbl_prodTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                #endregion

                                                #region BoM Material Insert
                                                foreach (DataRow row in dtMeterialReq.Rows)
                                                {
                                                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                    string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                    decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                    decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                    decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                    string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                    decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                    decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
                                                    bool IsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);

                                                    decimal dItemWAvgCost = 0;
                                                    decimal dLowestCost = 0;
                                                    decimal dHighestCost = 0;
                                                    decimal dBoMCost = 0;
                                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                    if (oItem != null && IsSemiFinished)
                                                    {
                                                        oItem.IsSemiFinishGood = true;
                                                        oItem.Update();
                                                    }

                                                    //Get_ItemPriceCost_ForEditAfterApproved()
                                                    tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                    if (oItem_Finance != null)
                                                    {
                                                        dItemWAvgCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                        dLowestCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                        dHighestCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                        dBoMCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                    }

                                                    #region Total Cost Without Tax for Semi Finisheds and Row Material Cost
                                                    tbl_prodTxJobCard_Material oNewProdMaterial;
                                                    if (IsSemiFinished)
                                                    {
                                                        //SF Items
                                                        oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dBoMCost, (int)prod_Costing_Mode.BoM_Cost, dBoMCost, false, 0, 1);
                                                        oNewProdMaterial.Insert();
                                                    }
                                                    else
                                                    {
                                                        decimal dEditedCost = (dItemWAvgCost * dTotalQty);
                                                        decimal dSF_BoMCost = 0;
                                                        int iCostType = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                        if (oItem.IsSemiFinishGood)
                                                        {
                                                            if (dSF_BoMCost > 0)
                                                            {
                                                                dEditedCost = (dSF_BoMCost * dTotalQty);
                                                                iCostType = (int)prod_Costing_Mode.BoM_Cost;
                                                            }
                                                        }
                                                        oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dSF_BoMCost, iCostType, dEditedCost, false, dEditedCost, 1);
                                                        oNewProdMaterial.Insert();
                                                    }
                                                    #endregion

                                                    #region Semi Finisheds Outsource Rate

                                                    if (IsSemiFinished && oNewProdMaterial != null)
                                                    {
                                                        List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                        decimal dSF_MaxOutsouceRate = 0;
                                                        if (oList_ItemOutsource.Count > 0)
                                                            dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                        tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                        oSF_Outsource.Insert();
                                                    }
                                                    #endregion

                                                    //Items Saving of a Semi Finished 
                                                    frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                    if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                    {
                                                        foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                            string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                            string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                            decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                            decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                            decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                            string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                            decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                            decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_sub = 0;
                                                            decimal dLowestCost_sub = 0;
                                                            decimal dHighestCost_sub = 0;
                                                            decimal dBoMCost_sub = 0;
                                                            tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                            tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                            if (oItem_Finance_sub != null)
                                                            {
                                                                dItemWAvgCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                dLowestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                dHighestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                dBoMCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                            }

                                                            tbl_prodTxJobCard_Material oNewMat_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                            oNewMat_Semi.Insert();

                                                            //Substitute Materials for Semi Finisheds Saving
                                                            frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                            if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                            {
                                                                foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                {
                                                                    int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                    string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                    string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                    decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                    decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                    decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                    string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                    decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                    decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                    decimal dItemWAvgCost_substitute_Semi = 0;
                                                                    decimal dLowestCost_substitute_Semi = 0;
                                                                    decimal dHighestCost_substitute_Semi = 0;
                                                                    decimal dBoMCost_substitute_Semi = 0;
                                                                    tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                    if (oItem_Finance_substitute_Semi != null)
                                                                    {
                                                                        dItemWAvgCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                        dLowestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                        dHighestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                        dBoMCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                    oNewMat_Substitute_Semi.Insert();
                                                                }
                                                            }
                                                        }
                                                    }

                                                    //Substitute Materials Saving
                                                    frm_RawMeterial_SemiFinished frmSubtitute_Main = row.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                    if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                    {
                                                        foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                            string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                            string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                            decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                            decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                            decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                            string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                            decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                            decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_substitute_Main = 0;
                                                            decimal dLowestCost_substitute_Main = 0;
                                                            decimal dHighestCost_substitute_Main = 0;
                                                            decimal dBoMCost_substitute_Main = 0;
                                                            tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                            if (oItem_Finance_substitute_Main != null)
                                                            {
                                                                dItemWAvgCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                dLowestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                dHighestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                dBoMCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                            }

                                                            tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                            oNewMat_Substitute_Main.Insert();
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            else //Check Batch Count and There are batches related to the BoM
                                            {
                                                #region Update Exist Data

                                                #region Raw Materials
                                                foreach (DataRow row in dtMeterialReq.Rows)
                                                {
                                                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                    string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                    string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                    decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                    decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                    decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                    string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                    decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                    decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
                                                    bool IsSemiFinished_SubIn = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);
                                                    frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                    frm_RawMeterial_SemiFinished frmSubtitute_Main = row.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                    tbl_prodTxJobCard_Material oMaterial = tbl_prodTxJobCard_Material.Select(iLine_no, 0, 0, txtProdJobID.Text.Trim());

                                                    #region Already Exist
                                                    if (oMaterial != null)
                                                    {
                                                        #region Main Item
                                                        oMaterial.InputQty = dConsumption;
                                                        oMaterial.Consumption = dConsumption;
                                                        oMaterial.WastagePercent = dWastage_Pct;
                                                        oMaterial.TotalInputQty = dTotalQty;
                                                        oMaterial.Section_ID = sSection_ID;
                                                        oMaterial.Smv_TimeMinutes = dSMV_Time;
                                                        oMaterial.TotalLabour = dLabourCount;
                                                        oMaterial.IsSemiFinishItem = IsSemiFinished_SubIn;
                                                        oMaterial.Wipout_sf_Index = 1;

                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                        if (oItem != null && IsSemiFinished_SubIn)
                                                        {
                                                            oItem.IsSemiFinishGood = true;
                                                            oItem.Update();
                                                        }

                                                        #region Total Cost (Without Tax for Semi Finisheds)

                                                        if (IsSemiFinished_SubIn)
                                                        {
                                                            //SF Items
                                                            decimal dCost = oMaterial.Cost;// clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(sItem_ID));
                                                            oMaterial.CostTypeSelection = (int)prod_Costing_Mode.BoM_Cost;
                                                            oMaterial.BomCost = dCost;
                                                            //oMaterial.Cost = dCost;
                                                            oMaterial.EditedCost = 0;
                                                        }
                                                        else
                                                        {
                                                            //Row Materials
                                                            decimal dEditedCost = (oMaterial.WeightedAvgCost * dTotalQty);
                                                            oMaterial.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                            oMaterial.Cost = dEditedCost;
                                                            oMaterial.EditedCost = dEditedCost;
                                                        }
                                                        #endregion

                                                        oMaterial.Update();
                                                        #endregion

                                                        #region SF Item's Materials
                                                        if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished_SubIn)
                                                        {
                                                            foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                                string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                                string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                                decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                                decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                                decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                                string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                                decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                                decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);
                                                                frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                                tbl_prodTxJobCard_Material oNewMat_Semi = tbl_prodTxJobCard_Material.Select(iLine_no, iLine_no_semi, 0, txtProdJobID.Text.Trim());
                                                                if (oNewMat_Semi != null)
                                                                {
                                                                    #region Semi Finished Item Materials
                                                                    oNewMat_Semi.InputQty = dQty_sub;
                                                                    oNewMat_Semi.Consumption = dQty_sub;
                                                                    oNewMat_Semi.WastagePercent = dWastage_Pct_sub;
                                                                    oNewMat_Semi.TotalInputQty = dTotalQty_sub;
                                                                    oNewMat_Semi.Section_ID = sSection_ID_sub;
                                                                    oNewMat_Semi.Smv_TimeMinutes = dSMV_Time_sub;
                                                                    oNewMat_Semi.TotalLabour = dLabourCount_sub;
                                                                    oNewMat_Semi.Wipout_sf_Index = 1;
                                                                    oNewMat_Semi.CostTypeSelection = 0;
                                                                    oNewMat_Semi.Cost = (oNewMat_Semi.WeightedAvgCost * dTotalQty_sub);
                                                                    oNewMat_Semi.EditedCost = oNewMat_Semi.Cost;

                                                                    oNewMat_Semi.Update();
                                                                    #endregion

                                                                    #region Substitutes of SF Raw Materilas
                                                                    if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                        {
                                                                            int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                            string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                            string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                            decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                            decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                            decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                            string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                            decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                            decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                            tbl_prodTxJobCard_Material oSubstitute_Mat_Semi = tbl_prodTxJobCard_Material.Select(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, txtProdJobID.Text.Trim());
                                                                            if (oSubstitute_Mat_Semi != null)
                                                                            {
                                                                                #region Semi Finished Item Materials
                                                                                oSubstitute_Mat_Semi.InputQty = dQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Consumption = dQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.WastagePercent = dWastage_Pct_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.TotalInputQty = dTotalQty_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Section_ID = sSection_ID_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Smv_TimeMinutes = dSMV_Time_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.TotalLabour = dLabourCount_substitute_Semi;
                                                                                oSubstitute_Mat_Semi.Wipout_sf_Index = 1;

                                                                                oSubstitute_Mat_Semi.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                                                oSubstitute_Mat_Semi.Cost = (oSubstitute_Mat_Semi.WeightedAvgCost * dTotalQty_substitute_Semi);
                                                                                oSubstitute_Mat_Semi.EditedCost = oSubstitute_Mat_Semi.Cost;

                                                                                oSubstitute_Mat_Semi.Update();
                                                                                #endregion
                                                                            }
                                                                            else
                                                                            {
                                                                                decimal dItemWAvgCost_substitute_Semi = 0;
                                                                                decimal dLowestCost_substitute_Semi = 0;
                                                                                decimal dHighestCost_substitute_Semi = 0;
                                                                                decimal dBoMCost_substitute_Semi = 0;
                                                                                tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                                if (oItem_Finance_substitute_Semi != null)
                                                                                {
                                                                                    dItemWAvgCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                    dLowestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                    dHighestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                    dBoMCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                }

                                                                                tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                                oNewMat_Substitute_Semi.Insert();
                                                                            }
                                                                        }
                                                                    }
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    decimal dItemWAvgCost_sub = 0;
                                                                    decimal dLowestCost_sub = 0;
                                                                    decimal dHighestCost_sub = 0;
                                                                    decimal dBoMCost_sub = 0;
                                                                    tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                    if (oItem_Finance_sub != null)
                                                                    {
                                                                        dItemWAvgCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                        dLowestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                        dHighestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                        dBoMCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_forSemi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                                    oNewMat_forSemi.Insert();

                                                                    //Substitute Materials for Semi Finisheds Saving
                                                                    if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                    {
                                                                        foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                        {
                                                                            int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                            string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                            string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                            decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                            decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                            decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                            string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                            decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                            decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                            decimal dItemWAvgCost_substitute_Semi = 0;
                                                                            decimal dLowestCost_substitute_Semi = 0;
                                                                            decimal dHighestCost_substitute_Semi = 0;
                                                                            decimal dBoMCost_substitute_Semi = 0;
                                                                            tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                            if (oItem_Finance_substitute_Semi != null)
                                                                            {
                                                                                dItemWAvgCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                dLowestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                dHighestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                                dBoMCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                            }

                                                                            tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMCost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                            oNewMat_Substitute_Semi.Insert();
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        #endregion

                                                        #region Substitues for Main Items
                                                        if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                                string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                                string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                                decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                                decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                                decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                                string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                                decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                                decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);


                                                                tbl_prodTxJobCard_Material oSubstituteMeterial = tbl_prodTxJobCard_Material.Select(iLine_no, 0, iLine_no_substitute_Main, txtProdJobID.Text.Trim());
                                                                if (oSubstituteMeterial != null)
                                                                {
                                                                    #region Semi Finished Item Materials
                                                                    oSubstituteMeterial.InputQty = dQty_substitute_Main;
                                                                    oSubstituteMeterial.Consumption = dQty_substitute_Main;
                                                                    oSubstituteMeterial.WastagePercent = dWastage_Pct_substitute_Main;
                                                                    oSubstituteMeterial.TotalInputQty = dTotalQty_substitute_Main;
                                                                    oSubstituteMeterial.Section_ID = sSection_ID_substitute_Main;
                                                                    oSubstituteMeterial.Smv_TimeMinutes = dSMV_Time_substitute_Main;
                                                                    oSubstituteMeterial.TotalLabour = dLabourCount_substitute_Main;
                                                                    oSubstituteMeterial.Wipout_sf_Index = 1;

                                                                    oSubstituteMeterial.CostTypeSelection = (int)prod_Costing_Mode.Weighted_Avg_Cost;
                                                                    oSubstituteMeterial.Cost = (oSubstituteMeterial.WeightedAvgCost * dTotalQty_substitute_Main);
                                                                    oSubstituteMeterial.EditedCost = oSubstituteMeterial.Cost;

                                                                    oSubstituteMeterial.Update();
                                                                    #endregion
                                                                }
                                                                else
                                                                {
                                                                    decimal dItemWAvgCost_substitute_Main = 0;
                                                                    decimal dLowestCost_substitute_Main = 0;
                                                                    decimal dHighestCost_substitute_Main = 0;
                                                                    decimal dBoMCost_substitute_Main = 0;
                                                                    tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                    if (oItem_Finance_substitute_Main != null)
                                                                    {
                                                                        dItemWAvgCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                        dLowestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                        dHighestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                        dBoMCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                    }

                                                                    tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                                    oNewMat_Substitute_Main.Insert();
                                                                }

                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region Newly Add
                                                    else
                                                    {
                                                        decimal dItemWAvgCost = 0;
                                                        decimal dLowestCost = 0;
                                                        decimal dHighestCost = 0;
                                                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                        if (oItem != null && IsSemiFinished_SubIn)
                                                        {
                                                            oItem.IsSemiFinishGood = true;
                                                            oItem.Update();
                                                        }
                                                        tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                        if (oItem_Finance != null)
                                                        {
                                                            dItemWAvgCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                            dLowestCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                            dHighestCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);
                                                        }

                                                        #region Total Cost Without Tax for Semi Finisheds
                                                        tbl_prodTxJobCard_Material oNewProdMaterial;
                                                        if (IsSemiFinished_SubIn)
                                                        {
                                                            //SF Item
                                                            decimal dCost = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance);

                                                            oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished_SubIn, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, dCost, (int)prod_Costing_Mode.BoM_Cost, dCost, false, 0, 1);
                                                            oNewProdMaterial.Insert();
                                                        }
                                                        else
                                                        {   //Raw Materials
                                                            decimal dEditedCost = (dItemWAvgCost * dTotalQty);
                                                            oNewProdMaterial = new tbl_prodTxJobCard_Material(iLine_no, 0, 0, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished_SubIn, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, 0, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost * dTotalQty), false, dEditedCost, 1);
                                                            oNewProdMaterial.Insert();
                                                        }

                                                        #endregion

                                                        #region Semi Finisheds Outsource Rate

                                                        if (IsSemiFinished_SubIn && oNewProdMaterial != null)
                                                        {
                                                            List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                            decimal dSF_MaxOutsouceRate = 0;
                                                            if (oList_ItemOutsource.Count > 0)
                                                                dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                            tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                            oSF_Outsource.Insert();
                                                        }
                                                        #endregion

                                                        //Semi Finished Items Saving
                                                        if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished_SubIn)
                                                        {
                                                            foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0));
                                                                string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                                string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                                decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                                decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                                decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                                string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                                decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                                decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                                decimal dItemWAvgCost_sub = 0;
                                                                decimal dLowestCost_sub = 0;
                                                                decimal dHighestCost_sub = 0;
                                                                decimal dBoMCost_sub = 0;
                                                                tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                if (oItem_Finance_sub != null)
                                                                {
                                                                    dItemWAvgCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                    dLowestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                    dHighestCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                    dBoMCost_sub = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_sub.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_sub);
                                                                }

                                                                tbl_prodTxJobCard_Material oNewMat_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, 0, oBoM.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, dBoMCost_sub, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_sub * dTotalQty_sub), false, (dItemWAvgCost_sub * dTotalQty_sub), 1);
                                                                oNewMat_Semi.Insert();

                                                                //Substitute Materials for Semi Finisheds Saving
                                                                frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                                if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                    {
                                                                        int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0));
                                                                        string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                        string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                        decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                        decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                        decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                        string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                        decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                        decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                        decimal dItemWAvgCost_substitute_Semi = 0;
                                                                        decimal dLowestCost_substitute_Semi = 0;
                                                                        decimal dHighestCost_substitute_Semi = 0;
                                                                        decimal dBoMcost_substitute_Semi = 0;
                                                                        tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                        tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                        if (oItem_Finance_substitute_Semi != null)
                                                                        {
                                                                            dItemWAvgCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                            dLowestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Lowest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                            dHighestCost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Highest_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                            dBoMcost_substitute_Semi = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.BoM_Cost, oItem_Finance_substitute_Semi.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Semi);
                                                                        }

                                                                        tbl_prodTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prodTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oBoM.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, dBoMcost_substitute_Semi, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
                                                                        oNewMat_Substitute_Semi.Insert();
                                                                    }
                                                                }

                                                            }

                                                        }

                                                        //Substitute Materials Saving
                                                        if (frmSubtitute_Main.dtMeterialReq.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row_substitute_Main in frmSubtitute_Main.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0));
                                                                string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                                string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                                decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                                decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                                decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                                string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                                decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                                decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                                decimal dItemWAvgCost_substitute_Main = 0;
                                                                decimal dLowestCost_substitute_Main = 0;
                                                                decimal dHighestCost_substitute_Main = 0;
                                                                decimal dBoMCost_substitute_Main = 0;
                                                                tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                if (oItem_Finance_substitute_Main != null)
                                                                {
                                                                    dItemWAvgCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                    dLowestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                    dHighestCost_substitute_Main = Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode.Weighted_Avg_Cost, oItem_Finance_substitute_Main.Item_ID, dtItemCost_EditAfterApproved_Mode, oItem_Finance_substitute_Main);
                                                                    dBoMCost_substitute_Main = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance_substitute_Main.Item_ID));
                                                                }

                                                                tbl_prodTxJobCard_Material oNewMat_Substitute_Main = new tbl_prodTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oBoM.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, dBoMCost_substitute_Main, (int)prod_Costing_Mode.Weighted_Avg_Cost, (dItemWAvgCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                                oNewMat_Substitute_Main.Insert();
                                                            }
                                                        }
                                                        #endregion

                                                    }

                                                }
                                                #endregion

                                                foreach (tbl_prodTxJobCard_WIPFlow oObj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                                {
                                                    tbl_prodTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);
                                                }

                                                tbl_prodTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);

                                                #endregion
                                            }

                                            #region WIP Flow
                                            foreach (DataRow row in dtWIP_Flow.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                string sInSection_ID = clsValidate.ValidateRowValue(row, "InSection_ID", "default");
                                                string sOutSection_ID = clsValidate.ValidateRowValue(row, "OutSection_ID", "default");
                                                List<cls_BoMDetailMaterial> lstMats = row.Field<List<cls_BoMDetailMaterial>>("Materials");
                                                bool bSubOut = clsValidate.ValidateRowValue(row, "isSubOut", false);

                                                decimal dItemWAvgCost = 0;
                                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                if (oItem_Finance != null)
                                                    dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;


                                                tbl_prodTxJobCard_WIPFlow oSF_WIP = new tbl_prodTxJobCard_WIPFlow(iLine_no, oBoM.ProdJob_ID, sItem_ID, sUoM_ID, dQty, 0, dItemWAvgCost, 0, (dQty * dItemWAvgCost), sInSection_ID, sOutSection_ID, bSubOut);
                                                oSF_WIP.Insert();

                                                foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => !r.BIsWIP_SF))
                                                {
                                                    tbl_prodTxJobCard_Material oProdMat = tbl_prodTxJobCard_Material.Select(oMat.ILineNo, oMat.ILine_No_Sub1, oMat.ILine_No_Sub2, oBoM.ProdJob_ID);
                                                    if (oProdMat != null)
                                                    {
                                                        tbl_prodTxJobCard_WIPFlow oSF_WIP_ForUpdateMats = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No == oSF_WIP.Line_No && r.Item_ID == oSF_WIP.Item_ID).FirstOrDefault();
                                                        oProdMat.Wipout_sf_Index = oSF_WIP_ForUpdateMats.Sf_Index;
                                                        oProdMat.Update();
                                                    }
                                                }
                                            }

                                            foreach (tbl_prodTxJobCard_WIPFlow oWIP_Obj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                            {
                                                DataRow row = dtWIP_Flow.Select("LineNo = " + oWIP_Obj.Line_No + " AND  Item_ID = '" + oWIP_Obj.Item_ID + "'").FirstOrDefault();
                                                if (row != null)
                                                {
                                                    List<cls_BoMDetailMaterial> lstMats = row.Field<List<cls_BoMDetailMaterial>>("Materials");
                                                    foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => r.BIsWIP_SF))
                                                    {
                                                        DataRow row_detail = dtWIP_Flow.Select("LineNo = " + oMat.ILineNo + " AND  Item_ID = '" + oMat.SItem_ID + "'").FirstOrDefault();
                                                        if (row_detail != null)
                                                        {
                                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row_detail, "LineNo", 0));
                                                            string sItem_ID = clsValidate.ValidateRowValue(row_detail, "Item_ID", "default");
                                                            tbl_prodTxJobCard_WIPFlow oWIP_Obj_Detail = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No == iLine_no && r.Item_ID == sItem_ID).FirstOrDefault();

                                                            if (oWIP_Obj_Detail != null)
                                                            {
                                                                tbl_prodTxJobCard_WIPFlow_Detail oWIPFlow_Detail = new tbl_prodTxJobCard_WIPFlow_Detail(oWIP_Obj.Sf_Index, oWIP_Obj_Detail.Sf_Index, sItem_ID);
                                                                oWIPFlow_Detail.Insert();
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region SMV & Other Cost
                                            decimal dTotSMV = 0;
                                            foreach (DataRow row in dtSMV_BreakDown.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                                string sOperation_ID = clsValidate.ValidateRowValue(row, "Operation_ID", "default");
                                                decimal dSMV_PerPC = clsValidate.ValidateRowValue(row, "SMV_PerPC", 0m);

                                                tbl_prodTxJobCard_ProductionOperation oProdOperation = tbl_prodTxJobCard_ProductionOperation.Select(iLine_no, txtProdJobID.Text);
                                                if (oProdOperation != null)
                                                {
                                                    oProdOperation.Smv_Per_Pc = dSMV_PerPC;
                                                    dTotSMV += dSMV_PerPC;
                                                    oProdOperation.Update();
                                                }
                                            }
                                            foreach (tbl_prodTxJobCard_CostCenter oProdCostCenter in tbl_prodTxJobCard_CostCenter.SelectAllByProdJob_ID(txtProdJobID.Text))
                                            {
                                                oProdCostCenter.Smv = dTotSMV;
                                                oProdCostCenter.Update();
                                            }
                                            #endregion

                                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

                                            #endregion
                                        }
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
                                sProdJob_ID = oBoM.ProdJob_ID;
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
                    FillDetails(sProdJob_ID);
                }

            }
        }


        private void btn_Approved_click(object sender, RoutedEventArgs e)
        {
            try
            {
                #region Job Approval
                if (SEACC_Form.CheckPermission_ToApproved())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
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
                                                oJob.ProdJobStatus = (int)prod_BoM_Status.BoMFin;
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
                                        FillDetails(oJob.ProdJob_ID);
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
                #endregion
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
                        glb_dtsBoMs.Clear();
                        string sDraft = "", sCanceled = "", sDuplicateCopy = "";
                        bool bDuplicateCopy = false;
                        int iDuplcateCopyCount = 0;

                        tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.ProdApparel_BoMDetail);
                        tbl_securityFunctionMaster_Permission oUserPermission = tbl_securityFunctionMaster_Permission.Select(clsSecurity.BranchID, clsSecurity.UserIDLoged, oReport.Function_ID);

                        if (oReport != null && oUserPermission != null)
                        {
                            tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(txtProdJobID.Text.Trim());
                            if (oBoM != null)
                            {
                                #region Detail Report
                                clsHelpMethods_Prod.PrintCount_Update(SEACC_Form.enmFormName, enum_ReportName.ProdApparel_BoMDetail, oBoM.ProdJob_ID, ref bDuplicateCopy, ref iDuplcateCopyCount);
                                if (bDuplicateCopy)
                                    sDuplicateCopy = "Duplicate Copy " + iDuplcateCopyCount;

                                if (oBoM.IsCanceled)
                                {
                                    sCanceled = "CANCELLED";
                                    sDuplicateCopy = "";
                                }

                                glb_dtsBoMs.dt_prodJob.Adddt_prodJobRow(oBoM.ProdJob_ID, oBoM.ProdJobDate, "", oBoM.Salesman_ID,
                                                        oBoM.Customer_ID, clsGenaralName.getName_Customer(oBoM.Customer_ID),
                                                        oBoM.CustomerOrder_ID, oBoM.Item_ID_FG, clsGenaralName.getName_Item(oBoM.Item_ID_FG), clsGenaralName.getDescription_Item(oBoM.Item_ID_FG),
                                                        clsGenaralName.getCode_Item(oBoM.Item_ID_FG), oBoM.ProdStartDate, oBoM.ExfactoryDate, oBoM.FGoodQty,
                                                        oBoM.Uom_ID, oBoM.IsApproved1, oBoM.IsApproved2, oBoM.IsApproved3, oBoM.IsLocked,
                                                        "", 0,
                                                        "", clsGenaralName.getName_ItemClass(oBoM.JobType_ID), clsGenaralName.getName_ItemType(oBoM.ProdRange_ID),
                                                        clsGenaralName.getName_ItemCategory(oBoM.ProdCategory_ID), clsGenaralName.getName_Tag3(oBoM.ProdSize_ID),
                                                        clsGenaralName.getName_Colour(oBoM.Colour_ID),
                                                        "", oBoM.Remarks + " " + oBoM.Remarks2, oBoM.CustomerOrder_Qty,
                                                        oBoM.Item_ID_Previous == "default" ? "-" : oBoM.Item_ID_Previous + " - " + clsGenaralName.getName_Item(clsGenaralName.getID_ApparelBoM_FinishedGood(oBoM.Item_ID_Previous)),
                                                        sDraft, sDuplicateCopy, sCanceled,
                                                        clsGenaralName.getName_User(oBoM.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oBoM.DateCreate),
                                                        clsGenaralName.getName_User(oBoM.Checked2User_ID), clsHelpMethods_Prod.Format_DateTime(oBoM.DateChecked2),
                                                        clsGenaralName.getName_User(oBoM.Approved2User_ID), clsHelpMethods_Prod.Format_DateTime(oBoM.DateApproved2));

                                foreach (tbl_prodTxJobCard_Material oJob_Meterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No_Sub1 == 0 && r.Line_No_Sub2 == 0))
                                {
                                    int iCount = tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oBoM.ProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 == 0 && r.Line_No_Sub2 != 0).Count();
                                    string sSubstituteItemCount = iCount == 0 ? "1 Option" : (iCount + 1) + " Options";

                                    glb_dtsBoMs.dt_prodJob_material.Adddt_prodJob_materialRow(oJob_Meterial.Line_No, oJob_Meterial.ProdJob_ID, oJob_Meterial.IsSemiFinishItem,
                                                        oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID),
                                                        oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
                                                        oJob_Meterial.InputQty,
                                                        oJob_Meterial.Section_ID, clsGenaralName.getName_Section(oJob_Meterial.Section_ID),
                                                        "", 0, 0, 0, 0, 0, 0, "", oJob_Meterial.Smv_TimeMinutes, sSubstituteItemCount);
                                }


                                foreach (tbl_prodTxJobCard_WIPFlow obj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                {
                                    glb_dtsBoMs.dt_prodJob_wipflow.Adddt_prodJob_wipflowRow(obj.Line_No,
                                        oBoM.ProdJob_ID,
                                        obj.Item_ID,
                                        clsGenaralName.getName_Item(obj.Item_ID),
                                        obj.InSectionID,
                                        clsGenaralName.getName_Section(obj.InSectionID),
                                         obj.OutSectionID,
                                        clsGenaralName.getName_Section(obj.OutSectionID));
                                }

                                foreach (tbl_prodTxJobCard_ProductionOperation oProdOperation in tbl_prodTxJobCard_ProductionOperation.SelectAllByProdJob_ID(oBoM.ProdJob_ID))
                                {
                                    tbl_prodMasProductionOperation oMasOper = tbl_prodMasProductionOperation.Select(oProdOperation.Operation_ID);
                                    if (oMasOper != null)
                                    {
                                        glb_dtsBoMs.dt_prodJob_smv.Adddt_prodJob_smvRow(oProdOperation.Line_No, oBoM.ProdJob_ID, oProdOperation.Operation_ID, oMasOper.Description, oProdOperation.Smv_Per_Pc);
                                    }
                                }
                                #endregion

                                #region Company Details Fill
                                glb_dtsBoMs.dt_company.Adddt_companyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.CompanyName, clsSecurity.CompanyAddress1, clsSecurity.CompanyAddress2, Digiteq_Logic.clsCommon.getCompanyImage(), oReport.DisplayName, oReport.DisplayName2, "", clsSecurity.UserNameLoged, "");
                                #endregion

                                frm_ReportViewer rpt = new frm_ReportViewer();
                                rpt.print(oReport.ReportPath, glb_dtsBoMs, glb_dts_ExportReport.dt_rptParameter, oUserPermission);
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
                #region Job Cancel
                if (SEACC_Form.CheckPermission_ToCancel())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
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
                                                oJob.ProdJobStatus = (int)prod_BoM_Status.Cancelled;
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
                #endregion
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
            RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionMaterials, true);
            RowDataSearch.RowSelected += RowMaterialSearch_RowSelected;
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_MererialReq.SelectedItem;
            bool bDeleteItem = true;

            if (selectedItem != null)
            {
                string sLineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;

                foreach (DataRow dr in dtWIP_Flow.Rows)
                {
                    List<cls_BoMDetailMaterial> lstOMats = dr.Field<List<cls_BoMDetailMaterial>>("Materials");
                    if (lstOMats.Count > 0)
                    {
                        bDeleteItem = false;
                        break;
                    }
                }

                if (!bDeleteItem)
                    bDeleteItem = (SEACCMessageBox.Show("Are you sure to remove the material? ", "Meterials have been already linked to WIP Flow and Sub In Grids. When you delete a material, all WIP Flow links and Sub In links will be cleared.", MessageBoxButton.YesNo, "Red"));

                if (bDeleteItem)
                {
                    DataRow[] items = dtMeterialReq.Select("LineNo ='" + sLineNo + "'");
                    if (items.Length > 0)
                    {
                        foreach (DataRow item in items)
                            dtMeterialReq.Rows.Remove(item);
                    }
                    clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterialReq);

                    foreach (DataRow dr in dtWIP_Flow.Rows)
                    {
                        dr["Material_Count"] = "0 Materials";
                        dr["Materials"] = new List<cls_BoMDetailMaterial>();
                    }


                    #region Semi / Sub In
                    DataRow[] drSFs = dtSubIn_Items.Select();
                    if (drSFs.Length > 0)
                    {
                        foreach (DataRow SF in drSFs)
                            dtSubIn_Items.Rows.Remove(SF);
                    }
                    clsHelpMethods_Prod.OrderBy_DataGrid(dtSubIn_Items);
                    #endregion
                }
            }
        }

        #endregion

        #region WIP Flow Grid - Buttons
        private void btnWIPItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frm_search frmWIP_SF_search = new frm_search();
            frmWIP_SF_search.Show(Digiteq_Logic.Search.Prod_SemiFiniseds_FinishedGoods, true);
            frmWIP_SF_search.RowSelected += FrmWIP_SF_Search_RowSelected;
        }

        private void btnWIPItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_WIPFlow.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_WIPFlow.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtWIP_Flow.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtWIP_Flow.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtWIP_Flow);
            }

        }
        #endregion

        #endregion

        #region Clear Fields

        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            Attachments.Clear(SEACC_Form.Function_ID);

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, false, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerInquiry, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCOSO, false, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtReEditComments, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishedGoodItemDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesCode, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodEstWastage, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodPlannedQty, false, true, false);
            #region Colappsed in UI
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM1, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM2, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM3, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM4, true, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty1, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty2, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty3, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty4, true, true, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage1, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage2, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage3, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage4, true, true, false);

            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty1, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty2, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty3, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty4, true, true, false);
            #endregion
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtTotSMVTimeMins, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPreviousBoMTemplate, true, false, true);

            txtProdJobID.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFinishedGoodItemDescription.Tag = null;
            txtFinishGoodSalesCode.Tag = null;
            txtFinishGoodSalesName.Tag = null;
            txtFinishGoodUOM.Tag = null;
            #region Collaped in UI
            txtUoM1.Tag = null;
            txtUoM2.Tag = null;
            txtUoM3.Tag = null;
            txtUoM4.Tag = null;
            txtFGQty1.Tag = null;
            txtFGQty2.Tag = null;
            txtFGQty3.Tag = null;
            txtFGQty4.Tag = null;
            txtEstWastage1.Tag = null;
            txtEstWastage2.Tag = null;
            txtEstWastage3.Tag = null;
            txtEstWastage4.Tag = null;
            txtPlannedQty1.Tag = null;
            txtPlannedQty2.Tag = null;
            txtPlannedQty3.Tag = null;
            txtPlannedQty4.Tag = null;
            #endregion
            txtTotSMVTimeMins.Tag = null;
            txtPreviousBoMTemplate.Tag = null;

            txtCustomer.Uid = "";
            txtFinishGoodSalesName.ToolTip = null;

            txtProdJobID.Text = "";
            txtCustomer.Text = "";
            txtCustomerInquiry.Text = "";
            txtCustomerCOSO.Text = "";
            txtFinishedGoodItemDescription.Text = "";
            txtFinishGoodSalesCode.Text = "";
            txtFinishGoodSalesName.Text = "";
            txtFinishGoodUOM.Text = "";
            txtComments.Text = "";
            txtReEditComments.Text = "";
            txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);   // "0.000";
            txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity); // "0.000";
            txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity); // "0.000";

            txtPreviousBoMTemplate.Text = "";

            #region Collaped in UI
            txtUoM1.Text = "";
            txtUoM2.Text = "";
            txtUoM3.Text = "";
            txtUoM4.Text = "";
            txtFGQty1.Text = "";
            txtFGQty2.Text = "";
            txtFGQty3.Text = "";
            txtFGQty4.Text = "";
            txtEstWastage1.Text = "";
            txtEstWastage2.Text = "";
            txtEstWastage3.Text = "";
            txtEstWastage4.Text = "";
            txtPlannedQty1.Text = "";
            txtPlannedQty2.Text = "";
            txtPlannedQty3.Text = "";
            txtPlannedQty4.Text = "";
            #endregion

            txtTotSMVTimeMins.Text = "0.00";

            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpExFac_Date.SetTime(DateTime.Now);
            dtpProductionStart_Date.SetTime(DateTime.Now);

            dtMeterialReq.Clear();
            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;

            dtWIP_Flow.Clear();
            dgr_WIPFlow.ItemsSource = dtWIP_Flow.DefaultView;

            dtSubIn_Items.Clear();
            dgr_SubInItem.ItemsSource = dtSubIn_Items.DefaultView;

            dtSMV_BreakDown.Clear();
            dgr_SmvBreakDown.ItemsSource = dtSMV_BreakDown.DefaultView;

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_BoM_Status));
            cmbProdJobStatus.SetSelectedIndex((int)prod_BoM_Status.BoMProd);

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
                dgr_Main.dt.Clear();

                //List<tbl_prodTxJobCard> lstProdJobs;
                //if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                //    lstProdJobs = tbl_prodTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_BoM_Status.Obsolete && p.ProdJob_ID != "default" && p.IsApproved2).OrderByDescending(o => o.DateCreate).ToList();
                //else
                //    lstProdJobs = tbl_prodTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_BoM_Status.Obsolete && p.ProdJob_ID != "default" && p.IsApproved1).OrderByDescending(o => o.DateCreate).ToList();

                //int iCount = 0;
                //foreach (tbl_prodTxJobCard oJob in lstProdJobs)
                //{
                //    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                //    if (oItem != null)
                //    {
                //        //decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oJob.Item_ID_FG, oItem.ItemCategorySub_ID, "default", "0", "0");
                //        dgr_Main.dt.Rows.Add(++iCount, oJob.ProdJob_ID, oJob.ProdJobDate.ToString(clsValidation.Format_Date), 
                //            clsGenaralName.getName_Item(oJob.Item_ID_FG), clsGenaralName.getName_Customer(oJob.Customer_ID), 
                //            clsGenaralName.getName_User(oJob.CreateUser_ID), clsHelpMethods_Prod.Format_DateTime(oJob.DateCreate),
                //            clsGenaralName.getName_User(oJob.ModifiedUser_ID), clsHelpMethods_Prod.Format_DateTime(oJob.DateModified),
                //            clsGenaralName.getName_User(oJob.Approved2User_ID), clsHelpMethods_Prod.Format_DateTime(oJob.DateApproved2),
                //            oJob.IsCanceled);
                //    }
                //}

                if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                    dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_BOMDetails_EditAfterApprove_production").Tables[0]);
                else
                    dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_BOMDetails_production").Tables[0]);


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
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (CheckEditAfterApprovePermision())
                    {
                        if (Check_WIPFlow())
                        {
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtProdJobID.Text))
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

            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishedGoodItemDescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOM))
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

                tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        private bool CheckEditAfterApprovePermision()
        {
            bool bStatus = true;
            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                if (!string.IsNullOrWhiteSpace(txtReEditComments.TextBox1.Text))
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "All BoM costing data is going to be reset\n  Are you sure you want to edit this BOM?", MessageBoxButton.YesNo, "#FF5B6B76");
                    if (bMessegeBoxResult)
                    {
                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                        frmTwoStepVerify.ShowDialog();
                        if (frmTwoStepVerify.bVerified)
                        {
                            bEditAfterApproved_Mode = true;
                        }
                        else
                        {
                            bEditAfterApproved_Mode = false;
                            bStatus = false;
                        }
                        frmTwoStepVerify.Close();
                    }
                    else
                    {
                        bEditAfterApproved_Mode = false;
                        bStatus = false;
                    }
                }
                else
                {
                    SEACCMessageBox.Show("Why do you edit?", "Please, add a comment....", MessageBoxButton.OK, "Red");
                    txtReEditComments.Focus();
                    bStatus = false;
                }
            }
            return bStatus;
        }

        private bool Check_WIPFlow()
        {
            bool bStatus = true;
            if (dtWIP_Flow.Rows.Count > 0)
            {
                var vIncompletedRows = dtWIP_Flow.Select("InSection_ID = 'default' OR OutSection_ID = 'default' ");
                if (vIncompletedRows != null && vIncompletedRows.Count() > 0)
                {
                    bStatus = false;
                    SEACCMessageBox.Show("Incompleted WIP Flow", "Please select WIP Semi Finished In and Out sections correctly", MessageBoxButton.OK, "Red");
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
                Cursor = Cursors.Wait;

                ClearFields();
                tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(sID);
                if (oBoM != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtProdJobID.Tag = oBoM.ProdJob_ID;
                    txtCustomer.Tag = oBoM.Customer_ID;
                    txtCustomerInquiry.Tag = oBoM.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oBoM.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Tag = oBoM.Item_ID_FG;
                    txtFinishGoodSalesCode.Tag = oBoM.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oBoM.Uom_ID;
                    txtPreviousBoMTemplate.Tag = oBoM.Item_ID_Previous;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oBoM.Customer_ID);
                    txtFinishGoodSalesName.ToolTip = oBoM.Item_ID_FG;

                    txtProdJobID.Text = oBoM.ProdJob_ID;
                    txtComments.Text = oBoM.Remarks;
                    txtReEditComments.Text = oBoM.Remarks2;
                    txtCustomer.Text = oBoM.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oBoM.Customer_ID);
                    txtCustomerInquiry.Text = oBoM.CustomerInquiry_ID == "default" ? "-" : oBoM.CustomerInquiry_ID == "default" ? "" : oBoM.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oBoM.CustomerOrder_ID == "default" ? "-" : oBoM.CustomerOrder_ID == "default" ? "" : oBoM.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Text = clsGenaralName.getDescription_Item(oBoM.Item_ID_FG);
                    txtFinishGoodSalesCode.Text = clsGenaralName.getCode_Item(oBoM.Item_ID_FG);
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oBoM.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oBoM.Uom_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oBoM.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(oBoM.WastePercent, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(oBoM.FGoodQty, clsConfig.sDecimalPlaces_Quantity);
                    txtPreviousBoMTemplate.Text = oBoM.Item_ID_Previous == "default" ? "-" : oBoM.Item_ID_Previous + "\n" + clsGenaralName.getName_Item(clsGenaralName.getID_ApparelBoM_FinishedGood(oBoM.Item_ID_Previous)); ;

                    dtpProdJob_Date.SetTime(oBoM.ProdJobDate);
                    dtpExFac_Date.SetTime(oBoM.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oBoM.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex(oBoM.ProdJobStatus);

                    if (oBoM.Item_ID_Previous == "default")
                        txtPreviousBoMTemplate.IsEnabled = true;
                    else
                        txtPreviousBoMTemplate.IsEnabled = false;


                    if (oBoM.IsApproved2)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oBoM.IsChecked2)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    FillMaterialGrid(oBoM.ProdJob_ID);
                    FillWIP_Flow(oBoM.ProdJob_ID);
                    FillSub_InGrid(dtMeterialReq, dtWIP_Flow);

                    FillProdOperationGrid(oBoM.ProdJob_ID);

                    txtFinishedGoodEstWastage_LostFocus(null, null);

                    Attachments.FillDetails(oBoM.ProdJob_ID, false);
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

        private void FillMaterialGrid(string sProdJob_ID)
        {
            dtMeterialReq.Clear();
            foreach (tbl_prodTxJobCard_Material oJob_Meterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No_Sub1 == 0 && r.Line_No_Sub2 == 0))
            {
                frm_RawMeterial_SemiFinished frmSubstitute_Main = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);
                frm_RawMeterial_SemiFinished frmSemi = new frm_RawMeterial_SemiFinished("Raw Meterial List for Semi-Finished Item ", false);

                //Substitute Items for Main
                foreach (tbl_prodTxJobCard_Material oJob_Meterial_ForSubstitute_Main in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 == 0 && r.Line_No_Sub2 != 0))
                {
                    frmSubstitute_Main.dtMeterialReq.Rows.Add(oJob_Meterial_ForSubstitute_Main.Line_No_Sub2,
                        oJob_Meterial_ForSubstitute_Main.Item_ID, clsGenaralName.getName_Item(oJob_Meterial_ForSubstitute_Main.Item_ID),
                        oJob_Meterial_ForSubstitute_Main.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSubstitute_Main.Uom_ID),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.InputQty, clsConfig.sDecimalPlaces_Quantity),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                       oJob_Meterial_ForSubstitute_Main.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSubstitute_Main.Section_ID),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.Smv_TimeMinutes, 2),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.TotalLabour, 2));
                }
                //clsHelpMethods_Prod.OrderBy_DataGrid(frmSubstitute_Main.dtMeterialReq);
                string sSubstituteItemCount = frmSubstitute_Main.dtMeterialReq.Rows.Count == 0 ? "1 Option" : (frmSubstitute_Main.dtMeterialReq.Rows.Count + 1) + " Options";

                //Main Item Add
                dtMeterialReq.Rows.Add(oJob_Meterial.Line_No, oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID), oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
                    cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                    oJob_Meterial.Section_ID, clsGenaralName.getName_Section(oJob_Meterial.Section_ID),
                    cls_Formater.FormatDecimal(oJob_Meterial.Smv_TimeMinutes, 2),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalLabour, 2),
                    oJob_Meterial.IsSemiFinishItem, frmSemi, frmSubstitute_Main, sSubstituteItemCount);


                //Raw Materials adding for Semi Finished
                foreach (tbl_prodTxJobCard_Material oJob_Meterial_ForSemi in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 != 0 && r.Line_No_Sub2 == 0))
                {
                    frm_RawMeterial_SemiFinished frmSubstitute_Semi = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);

                    //Substitute Items for Materials which is relavant to Semi Finisheds
                    foreach (tbl_prodTxJobCard_Material oJob_Meterial_ForSubstitute_Semi in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial_ForSemi.Line_No && r.Line_No_Sub1 == oJob_Meterial_ForSemi.Line_No_Sub1 && r.Line_No_Sub2 != 0))
                    {
                        frmSubstitute_Semi.dtMeterialReq.Rows.Add(oJob_Meterial_ForSubstitute_Semi.Line_No_Sub2, oJob_Meterial_ForSubstitute_Semi.Item_ID,
                            clsGenaralName.getName_Item(oJob_Meterial_ForSubstitute_Semi.Item_ID),
                            oJob_Meterial_ForSubstitute_Semi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSubstitute_Semi.Uom_ID),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                            oJob_Meterial_ForSubstitute_Semi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSubstitute_Semi.Section_ID),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.Smv_TimeMinutes, 2),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.TotalLabour, 2));
                    }
                    //clsHelpMethods_Prod.OrderBy_DataGrid(frmSubstitute_Semi.dtMeterialReq);
                    string sSubstituteItemCount_ForSemi = frmSubstitute_Semi.dtMeterialReq.Rows.Count == 0 ? "1 Option" : (frmSubstitute_Semi.dtMeterialReq.Rows.Count + 1) + " Options";

                    //Semi Finished Main Material Add
                    frmSemi.dtMeterialReq.Rows.Add(oJob_Meterial_ForSemi.Line_No_Sub1, oJob_Meterial_ForSemi.Item_ID, clsGenaralName.getName_Item(oJob_Meterial_ForSemi.Item_ID), oJob_Meterial_ForSemi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSemi.Uom_ID),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                        oJob_Meterial_ForSemi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSemi.Section_ID),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.Smv_TimeMinutes, 2),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalLabour, 2), frmSubstitute_Semi, sSubstituteItemCount_ForSemi);
                }
            }

            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;
        }

        private void FillWIP_Flow(string sProdJob_ID)
        {
            dtWIP_Flow.Rows.Clear();
            foreach (tbl_prodTxJobCard_WIPFlow obj in tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(sProdJob_ID))
            {
                List<cls_BoMDetailMaterial> lstMatList = new List<cls_BoMDetailMaterial>();

                foreach (tbl_prodTxJobCard_WIPFlow_Detail objDetail in tbl_prodTxJobCard_WIPFlow_Detail.SelectAllBySf_Index(obj.Sf_Index))
                {
                    tbl_prodTxJobCard_WIPFlow oJobCard_WIPFlow = tbl_prodTxJobCard_WIPFlow.Select(objDetail.Wipout_sf_Index);
                    if (oJobCard_WIPFlow != null)
                    {
                        cls_BoMDetailMaterial oBoMDetailMaterial = new cls_BoMDetailMaterial();
                        oBoMDetailMaterial.BIsWIP_SF = true;
                        oBoMDetailMaterial.ILineNo = oJobCard_WIPFlow.Line_No;
                        oBoMDetailMaterial.SItem_ID = objDetail.Item_ID;
                        lstMatList.Add(oBoMDetailMaterial);
                    }
                }

                foreach (tbl_prodTxJobCard_Material oMat in tbl_prodTxJobCard_Material.SelectAllByWipout_sf_Index(obj.Sf_Index).Where(r => r.Line_No_Sub2 == 0))//Skip Substitute Materials (Only Main Material )
                {
                    cls_BoMDetailMaterial oBoMDetailMaterial = new cls_BoMDetailMaterial();
                    oBoMDetailMaterial.BIsWIP_SF = false;
                    oBoMDetailMaterial.ILineNo = oMat.Line_No;
                    oBoMDetailMaterial.ILine_No_Sub1 = oMat.Line_No_Sub1;
                    oBoMDetailMaterial.ILine_No_Sub2 = oMat.Line_No_Sub2;
                    oBoMDetailMaterial.SItem_ID = oMat.Item_ID;
                    lstMatList.Add(oBoMDetailMaterial);
                }

                dtWIP_Flow.Rows.Add(obj.Line_No,
                    obj.Item_ID,
                    clsGenaralName.getName_Item(obj.Item_ID),
                    obj.Uom_ID,
                    clsGenaralName.getName_Uom(obj.Uom_ID),
                    cls_Formater.FormatDecimal(obj.OutQty, clsConfig.sDecimalPlaces_Quantity),
                    obj.InSectionID,
                    clsGenaralName.getName_Section(obj.InSectionID),
                     obj.OutSectionID,
                    clsGenaralName.getName_Section(obj.OutSectionID),
                    (lstMatList.Count == 1 ? lstMatList.Count + " Material" : lstMatList.Count + " Materials"),
                    lstMatList,
                    obj.IsSubOut
                    );
            }
        }

        private void FillProdOperationGrid(string sProdJob_ID)
        {
            dtSMV_BreakDown.Clear();
            foreach (tbl_prodTxJobCard_ProductionOperation oProdOperation in tbl_prodTxJobCard_ProductionOperation.SelectAllByProdJob_ID(sProdJob_ID))
            {
                tbl_prodMasProductionOperation oMasOper = tbl_prodMasProductionOperation.Select(oProdOperation.Operation_ID);
                if (oMasOper != null)
                {
                    dtSMV_BreakDown.Rows.Add(oProdOperation.Line_No, oProdOperation.Operation_ID, oMasOper.Description, cls_Formater.FormatDecimal(oProdOperation.Smv_Per_Pc, 2));
                }
            }
            dgr_SmvBreakDown.ItemsSource = dtSMV_BreakDown.DefaultView;

            CalculateTotalSMVTime();
        }

        private void FillSub_InGrid(DataTable dtMatTable, DataTable dtWIP_SF)
        {
            var vDrItems = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Tag.ToString());
            if (vDrItems == null || vDrItems.Count() == 1)
            {
                foreach (DataRow drItem in dtMatTable.Select("IsSemiFinished = true"))
                {
                    int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(drItem, "LineNo", 0));
                    string sItem_ID = clsValidate.ValidateRowValue(drItem, "Item_ID", "default");
                    string sItem_Name = clsValidate.ValidateRowValue(drItem, "ItemName", "");
                    string sUoM_ID = clsValidate.ValidateRowValue(drItem, "UoM_ID", "default");
                    string sUoM = clsValidate.ValidateRowValue(drItem, "UoM", "");
                    decimal dTotalQty = clsValidate.ValidateRowValue(drItem, "TotalQty", 0);
                    string sSection_ID = clsValidate.ValidateRowValue(drItem, "SectionID", "default");
                    string sSectionName = clsValidate.ValidateRowValue(drItem, "SectionName", "");
                    frm_RawMeterial_SemiFinished frmSemi = drItem.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");

                    frm_MaterialSelection_SubIn frmSubOutMat = new frm_MaterialSelection_SubIn();
                    foreach (DataRow dr_SubOut_Mat in frmSemi.dtMeterialReq.Rows)
                    {
                        int iLine_no_SubOut = Convert.ToInt32(clsValidate.ValidateRowValue(dr_SubOut_Mat, "LineNo", 0));
                        string sItem_ID_SubOut = clsValidate.ValidateRowValue(dr_SubOut_Mat, "Item_ID", "default");
                        string sItem_Name_SubOut = clsValidate.ValidateRowValue(dr_SubOut_Mat, "ItemName", "default");

                        frmSubOutMat.dtMeterial_Req.Rows.Add(iLine_no_SubOut, "\uE0A2", sItem_ID_SubOut, sItem_Name_SubOut);
                    }

                    foreach (DataRow dr_SubOut_SF in dtWIP_SF.Select("isSubOut = true "))//AND OutSection_ID = '" + sSection_ID + "' 
                    {
                        int iLine_no_SubOut = Convert.ToInt32(clsValidate.ValidateRowValue(dr_SubOut_SF, "LineNo", 0));
                        string sItem_ID_SubOut = clsValidate.ValidateRowValue(dr_SubOut_SF, "Item_ID", "default");
                        string sItem_Name_SubOut = clsValidate.ValidateRowValue(dr_SubOut_SF, "ItemName", "default");

                        frmSubOutMat.dtWIP_SF_Req.Rows.Add(iLine_no_SubOut, "\uE0A2", sItem_ID_SubOut, sItem_Name_SubOut);
                    }

                    int iMatCout = frmSubOutMat.dtMeterial_Req.Rows.Count + frmSubOutMat.dtWIP_SF_Req.Rows.Count;
                    dtSubIn_Items.Rows.Add("0", iLine_no, sItem_ID, sItem_Name, sUoM_ID, sUoM, dTotalQty, sSection_ID, sSectionName, iMatCout + " Material(s)", frmSubOutMat);
                }
            }
            else
            {
                FillSub_InGrid_New();
            }
            
        }

        private void fillDetails_fromPreviousJob(string sID)
        {
            try
            {
                tbl_prodTxJobCard oPrevJob = tbl_prodTxJobCard.Select(sID);
                if (oPrevJob != null)
                {
                    tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                    if (oJob.Item_ID_Previous == "default")
                    {
                        txtFinishedGoodEstWastage.Text = oPrevJob.WasteQty.ToString();
                        txtFinishedGoodPlannedQty.Text = oPrevJob.FGoodQty.ToString();

                        FillMaterialGrid(oPrevJob.ProdJob_ID);
                        FillWIP_Flow(oPrevJob.ProdJob_ID);
                        FillSub_InGrid(dtMeterialReq, dtWIP_Flow);
                        FillProdOperationGrid(oPrevJob.ProdJob_ID);

                        //txtPreviousBoMTemplate.IsEnabled = false;
                    }
                    else
                        SEACCMessageBox.Show("Information...!", "Already added " + oJob.Item_ID_Previous + " BOM template to this Transaction", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FillSub_InGrid_New()
        {
            var vDrItems = tbl_prodTxJobCard_SubIn_SFG.SelectAllByProdJob_ID(txtProdJobID.Tag.ToString());
            if (vDrItems.Count() > 1)
            {

                foreach (tbl_prodTxJobCard_SubIn_SFG oDrItem in vDrItems)
                {
                    frm_MaterialSelection_SubIn frmSubOutMat = new frm_MaterialSelection_SubIn();
                    foreach (tbl_prodTxJobCard_SubIn_SFG_Material dr_SubOut_Mat in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID_Line_no(oDrItem.ProdJob_ID, oDrItem.Line_no).Where(r => r.IsSubOutRawMaterial))
                    {

                        string sSelect = "\uE003";
                        if (dr_SubOut_Mat.IsSelect)
                            sSelect = "\uE0A2";

                        frmSubOutMat.dtMeterial_Req.Rows.Add(dr_SubOut_Mat.Line_no_detail, sSelect, dr_SubOut_Mat.Item_ID, clsGenaralName.getName_Item(dr_SubOut_Mat.Item_ID));
                    }

                    foreach (tbl_prodTxJobCard_SubIn_SFG_Material dr_SubOut_WipSF in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID_Line_no(oDrItem.ProdJob_ID, oDrItem.Line_no).Where(r => !r.IsSubOutRawMaterial))
                    {

                        string sSelect = "\uE003";
                        if (dr_SubOut_WipSF.IsSelect)
                            sSelect = "\uE0A2";

                        frmSubOutMat.dtWIP_SF_Req.Rows.Add(dr_SubOut_WipSF.Line_no_detail, sSelect, dr_SubOut_WipSF.Item_ID, clsGenaralName.getName_Item(dr_SubOut_WipSF.Item_ID));
                    }

                    int iDataMaterials = 0;
                    var vDataMaterials = frmSubOutMat.dtMeterial_Req.Select("IsSelect = '\uE0A2'");
                    if (vDataMaterials != null)
                        iDataMaterials = vDataMaterials.Count();

                    int iDataWIP_SF = 0;
                    var vDataWIP_SF = frmSubOutMat.dtWIP_SF_Req.Select("IsSelect = '\uE0A2'");
                    if (vDataWIP_SF != null)
                        iDataWIP_SF = vDataWIP_SF.Count();

                    int iMatCout = iDataMaterials + iDataWIP_SF;
                    dtSubIn_Items.Rows.Add(oDrItem.Line_no, oDrItem.MaterialGrid_line_no, oDrItem.SubIn_item_ID, clsGenaralName.getName_Item(oDrItem.SubIn_item_ID), oDrItem.Uom_ID, clsGenaralName.getName_Uom(oDrItem.Uom_ID), cls_Formater.FormatDecimal(oDrItem.Qty, clsConfig.sDecimalPlaces_Quantity), oDrItem.SubIn_Section, clsGenaralName.getName_Section(oDrItem.SubIn_Section), iMatCout + " Material(s)", frmSubOutMat);
                }
            }
            //else if (vDrItems.Count() == 1)
            //{
            //    foreach (tbl_prodTxJobCard_SubIn_SFG oDrItem in vDrItems)
            //    {
            //        frm_MaterialSelection_SubIn frmSubOutMat = new frm_MaterialSelection_SubIn();
            //        foreach (tbl_prodTxJobCard_SubIn_SFG_Material dr_SubOut_Mat in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID(oDrItem.ProdJob_ID).Where(r => r.IsSubOutRawMaterial))
            //        {

            //            string sSelect = "\uE003";
            //            if (dr_SubOut_Mat.IsSelect)
            //                sSelect = "\uE0A2";

            //            frmSubOutMat.dtMeterial_Req.Rows.Add(dr_SubOut_Mat.Line_no_detail, sSelect, dr_SubOut_Mat.Item_ID, clsGenaralName.getName_Item(dr_SubOut_Mat.Item_ID));
            //        }

            //        foreach (tbl_prodTxJobCard_SubIn_SFG_Material dr_SubOut_WipSF in tbl_prodTxJobCard_SubIn_SFG_Material.SelectAllByProdJob_ID(oDrItem.ProdJob_ID).Where(r => !r.IsSubOutRawMaterial))
            //        {

            //            string sSelect = "\uE003";
            //            if (dr_SubOut_WipSF.IsSelect)
            //                sSelect = "\uE0A2";

            //            frmSubOutMat.dtWIP_SF_Req.Rows.Add(dr_SubOut_WipSF.Line_no_detail, sSelect, dr_SubOut_WipSF.Item_ID, clsGenaralName.getName_Item(dr_SubOut_WipSF.Item_ID));
            //        }

            //        int iDataMaterials = 0;
            //        var vDataMaterials = frmSubOutMat.dtMeterial_Req.Select("IsSelect = '\uE0A2'");
            //        if (vDataMaterials != null)
            //            iDataMaterials = vDataMaterials.Count();

            //        int iDataWIP_SF = 0;
            //        var vDataWIP_SF = frmSubOutMat.dtWIP_SF_Req.Select("IsSelect = '\uE0A2'");
            //        if (vDataWIP_SF != null)
            //            iDataWIP_SF = vDataWIP_SF.Count();

            //        int iMatCout = iDataMaterials + iDataWIP_SF;
            //        dtSubIn_Items.Rows.Add(oDrItem.Line_no, oDrItem.MaterialGrid_line_no, oDrItem.SubIn_item_ID, clsGenaralName.getName_Item(oDrItem.SubIn_item_ID), oDrItem.Uom_ID, clsGenaralName.getName_Uom(oDrItem.Uom_ID), cls_Formater.FormatDecimal(oDrItem.Qty, clsConfig.sDecimalPlaces_Quantity), oDrItem.SubIn_Section, clsGenaralName.getName_Section(oDrItem.SubIn_Section), iMatCout + " Material(s)", frmSubOutMat);
            //    }
            //}
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
                if ((vDG_Cell.Column.SortMemberPath == "IsSemiFinished") && bSemiFinished)
                {
                    try
                    {
                        frm_RawMeterial_SemiFinished frmSemi = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                        if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                            frmSemi.btnGridItemDelete.Visibility = Visibility.Hidden;
                        frmSemi.sSection_ID = dtMeterialReq.Rows[irowID].Field<string>("SectionID");
                        frmSemi.sSection_Name = dtMeterialReq.Rows[irowID].Field<string>("SectionName");
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
                else if ((vDG_Cell.Column.SortMemberPath == "ItemName" || vDG_Cell.Column.SortMemberPath == "MatOption_Count") && !bSemiFinished)
                {
                    frm_RawMeterial_SemiFinished frmSubstitute = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                    if (frmSubstitute != null)
                    {
                        if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                            frmSubstitute.btnGridItemDelete.Visibility = Visibility.Hidden;

                        frmSubstitute.sSection_ID = dtMeterialReq.Rows[irowID].Field<string>("SectionID");
                        frmSubstitute.sSection_Name = dtMeterialReq.Rows[irowID].Field<string>("SectionName");
                        int iSubstituteMats = frmSubstitute.ShowDialogBox();
                        dtMeterialReq.Rows[irowID]["MatOption_Count"] = iSubstituteMats == 0 ? "1 Option" : (iSubstituteMats + 1) + " Options";
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
            if (sColumnSortMember == "Qty" || sColumnSortMember == "Wastage" || sColumnSortMember == "LabourCount" || sColumnSortMember == "EstTime")
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

        private void dgr_MererialReq_MaterialChecked(object sender, EventArgs e)
        {
            object oSelection = dgr_MererialReq.SelectedItem;
            try
            {
                if (oSelection != null)
                {
                    string sGrid_LineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(oSelection) as TextBlock).Text;
                    string sGrid_ItemID = (dgr_MererialReq.SelectedCells[1].Column.GetCellContent(oSelection) as TextBlock).Text;
                    DataRow[] drExisting = dtSubIn_Items.Select("MatGrid_LineNo = " + int.Parse(sGrid_LineNo));
                    if (!drExisting.Any())
                    {
                        DataRow drItem = dtMeterialReq.Select("LineNo = " + int.Parse(sGrid_LineNo) + " AND Item_ID = '" + sGrid_ItemID + "'").FirstOrDefault();
                        if (drItem != null)
                        {
                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(drItem, "LineNo", 0));
                            string sItem_ID = clsValidate.ValidateRowValue(drItem, "Item_ID", "default");
                            string sItem_Name = clsValidate.ValidateRowValue(drItem, "ItemName", "");
                            string sUoM_ID = clsValidate.ValidateRowValue(drItem, "UoM_ID", "default");
                            string sUoM = clsValidate.ValidateRowValue(drItem, "UoM", "");
                            decimal dTotalQty = clsValidate.ValidateRowValue(drItem, "TotalQty", 0m);
                            string sSection_ID = clsValidate.ValidateRowValue(drItem, "SectionID", "default");
                            string sSectionName = clsValidate.ValidateRowValue(drItem, "SectionName", "");
                            frm_RawMeterial_SemiFinished frmSemi = drItem.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");

                            frm_MaterialSelection_SubIn frmSubOutMat = new frm_MaterialSelection_SubIn();
                            foreach (DataRow dt_SubOut in frmSemi.dtMeterialReq.Rows)
                            {
                                int iLine_no_SubOut = Convert.ToInt32(clsValidate.ValidateRowValue(dt_SubOut, "LineNo", 0));
                                string sItem_ID_SubOut = clsValidate.ValidateRowValue(dt_SubOut, "Item_ID", "default");
                                string sItem_Name_SubOut = clsValidate.ValidateRowValue(dt_SubOut, "ItemName", "default");

                                frmSubOutMat.dtMeterial_Req.Rows.Add(iLine_no_SubOut, "\uE0A2", sItem_ID_SubOut, sItem_Name_SubOut);
                            }

                            int iMatCout = frmSubOutMat.dtMeterial_Req.Rows.Count + frmSubOutMat.dtWIP_SF_Req.Rows.Count;
                            dtSubIn_Items.Rows.Add("0", iLine_no, sItem_ID, sItem_Name, sUoM_ID, sUoM, dTotalQty, sSection_ID, sSectionName, iMatCout + " Material(s)", frmSubOutMat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_MererialReq_MaterialUnchecked(object sender, EventArgs e)
        {
            object oSelection = dgr_MererialReq.SelectedItem;
            try
            {
                if (oSelection != null)
                {
                    string sGrid_LineNo = (dgr_MererialReq.SelectedCells[0].Column.GetCellContent(oSelection) as TextBlock).Text;
                    string sGrid_ItemID = (dgr_MererialReq.SelectedCells[1].Column.GetCellContent(oSelection) as TextBlock).Text;
                    DataRow[] drExisting = dtSubIn_Items.Select("MatGrid_LineNo = " + int.Parse(sGrid_LineNo));
                    foreach (DataRow dr in drExisting)
                        dtSubIn_Items.Rows.Remove(dr);

                    clsHelpMethods_Prod.OrderBy_DataGrid(dtSubIn_Items);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region SMV Grid
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

        #region WIP Flow Grid
        private void dgr_WIPFlow_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtWIP_Flow);
        }

        private void dgr_WIPFlow_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "Qty")
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

        private void dgr_WIPFlow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_WIPFlow.SelectedIndex;
            var vDG_Cell = dgr_WIPFlow.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "Material_Count")
                {
                    try
                    {
                        decimal dSF_Qty = clsValidation.Validate_DecimalNumber(dtWIP_Flow.Rows[irowID].Field<string>("Qty"));
                        if (dSF_Qty > 0)
                        {
                            string sItem_WIP_Semi_LineNo = (dtWIP_Flow.Rows[irowID].Field<string>("LineNo"));
                            string sInSect_ID = (dtWIP_Flow.Rows[irowID].Field<string>("InSection_ID"));
                            string sOutSect_ID = (dtWIP_Flow.Rows[irowID].Field<string>("OutSection_ID"));

                            if (sInSect_ID != "default" && sOutSect_ID != "default")
                            {
                                List<cls_BoMDetailMaterial> lstMatList = dtWIP_Flow.Rows[irowID].Field<List<cls_BoMDetailMaterial>>("Materials");

                                DataTable dtMats = new DataTable();
                                var vMatRows = dtMeterialReq.Select("SectionID = '" + sOutSect_ID + "'");
                                if (vMatRows != null && vMatRows.Count() > 0)
                                    dtMats = vMatRows.AsEnumerable().CopyToDataTable();

                                DataTable dtRelavant_WIP_flowSemis = new DataTable();
                                var vRelavant_WIP_FlowSemis = dtWIP_Flow.Select("InSection_ID = '" + sOutSect_ID + "' AND LineNo <> '" + sItem_WIP_Semi_LineNo + "' ");
                                if (vRelavant_WIP_FlowSemis != null && vRelavant_WIP_FlowSemis.Count() > 0)
                                    dtRelavant_WIP_flowSemis = vRelavant_WIP_FlowSemis.AsEnumerable().CopyToDataTable();

                                frm_MaterialSelection frmSemi = new frm_MaterialSelection();
                                lstMatList = frmSemi.Show(dtMats, dtRelavant_WIP_flowSemis, lstMatList);

                                dtWIP_Flow.Rows[irowID]["Material_Count"] = lstMatList.Count == 1 ? lstMatList.Count + " Material" : lstMatList.Count + " Materials";
                                dtWIP_Flow.Rows[irowID]["Materials"] = lstMatList;
                            }
                            else
                            {
                                SEACCMessageBox.Show("Sections selection is incompleted.", "Please select WIP Semi Finished In and Out sections correctly", MessageBoxButton.OK, "Red");
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Semi Finished Qty. Not Set", "Please enter correct semi finished Qty.", MessageBoxButton.OK, "Red");
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                }
                else if (vDG_Cell.Column.SortMemberPath == "InSection_Name")
                {
                    try
                    {
                        frm_search RowDataSearch = new frm_search();
                        RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                        if (RowDataSearch.DialogResult == true)
                        {
                            dtWIP_Flow.Rows[irowID]["InSection_ID"] = lstResult[0];
                            dtWIP_Flow.Rows[irowID]["InSection_Name"] = lstResult[1];
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                }
                else if (vDG_Cell.Column.SortMemberPath == "OutSection_Name")
                {
                    try
                    {
                        frm_search RowDataSearch = new frm_search();
                        RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
                        if (RowDataSearch.DialogResult == true)
                        {
                            dtWIP_Flow.Rows[irowID]["OutSection_ID"] = lstResult[0];
                            dtWIP_Flow.Rows[irowID]["OutSection_Name"] = lstResult[1];
                        }
                    }
                    catch (Exception ex)
                    {
                        SEACCExeption.Show(ex);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Sub In Items
        private void dgr_SubInItem_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtSubIn_Items);
        }

        private void dgr_SubInItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_SubInItem.SelectedIndex;
            var vDG_Cell = dgr_SubInItem.CurrentCell;
            if (vDG_Cell.Column.SortMemberPath == "Material_Count")
            {
                try
                {
                    frm_MaterialSelection_SubIn frmMatList = dtSubIn_Items.Rows[irowID].Field<frm_MaterialSelection_SubIn>("Materials");
                    string sSection_ID = dtSubIn_Items.Rows[irowID].Field<string>("Section_ID");
                    dtSubIn_Items.Rows[irowID]["Material_Count"] = frmMatList.Show(sSection_ID, ref dtWIP_Flow).ToString() + " Material(s)";
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
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
        #region Collapsed In UI
        private void txtUoM1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoM1);
        }

        private void txtUoM2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoM2);
        }

        private void txtUoM3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoM3);
        }

        private void txtUoM4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoM4);
        }

        private void UoM_search(SEACC_TextBox txtUoM)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtUoM.Tag = lstResult[0];
                txtUoM.Text = lstResult[1] + " - " + lstResult[2];
            }
        }
        #endregion

        private void RowMaterialSearch_RowSelected(List<string> lstResult)
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
                        frm_RawMeterial_SemiFinished frmSemi = new frm_RawMeterial_SemiFinished("Raw Meterial List for Semi-Finished Item ", false);
                        if (oItem.IsSemiFinishGood)
                        {
                            tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).FirstOrDefault();
                            if (oProdJob != null)
                            {
                                foreach (tbl_prodTxJobCard_Material oProJobMaterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oProdJob.ProdJob_ID).Where(r => r.Line_No_Sub2 == 0))
                                {
                                    frm_RawMeterial_SemiFinished frmSubstituteMats_SemiFG = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);

                                    foreach (tbl_prodTxJobCard_Material oSubstituteJobMat in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(oProJobMaterial.ProdJob_ID).Where(r => r.Line_No == oProJobMaterial.Line_No && r.Line_No_Sub1 == oProJobMaterial.Line_No_Sub1 && r.Line_No_Sub2 != 0))
                                    {
                                        frmSubstituteMats_SemiFG.dtMeterialReq.Rows.Add(oSubstituteJobMat.Line_No_Sub2, oSubstituteJobMat.Item_ID,
                                            clsGenaralName.getName_Item(oSubstituteJobMat.Item_ID),
                                            oSubstituteJobMat.Uom_ID, clsGenaralName.getName_Uom(oSubstituteJobMat.Uom_ID),
                                            cls_Formater.FormatDecimal(oSubstituteJobMat.InputQty, clsConfig.sDecimalPlaces_Quantity),
                                            cls_Formater.FormatDecimal(oSubstituteJobMat.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                                            cls_Formater.FormatDecimal(oSubstituteJobMat.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                                            oSubstituteJobMat.Section_ID, clsGenaralName.getName_Section(oSubstituteJobMat.Section_ID),
                                            cls_Formater.FormatDecimal(oSubstituteJobMat.Smv_TimeMinutes, 2),
                                            cls_Formater.FormatDecimal(oSubstituteJobMat.TotalLabour, 2)
                                            );
                                    }
                                    string sSubstituteItemCount_ForSemi = frmSubstituteMats_SemiFG.dtMeterialReq.Rows.Count == 0 ? "1 Option" : (frmSubstituteMats_SemiFG.dtMeterialReq.Rows.Count + 1) + " Options";


                                    frmSemi.dtMeterialReq.Rows.Add("", oProJobMaterial.Item_ID,
                                        clsGenaralName.getName_Item(oProJobMaterial.Item_ID),
                                        oItem.Uom_ID, clsGenaralName.getName_Uom(oProJobMaterial.Uom_ID),
                                        cls_Formater.FormatDecimal(oProJobMaterial.InputQty, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(oProJobMaterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                                        oProJobMaterial.Section_ID, clsGenaralName.getName_Section(oProJobMaterial.Section_ID),
                                        cls_Formater.FormatDecimal(oProJobMaterial.Smv_TimeMinutes, 2),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalLabour, 2),
                                        frmSubstituteMats_SemiFG, sSubstituteItemCount_ForSemi
                                        );
                                }
                                clsHelpMethods_Prod.OrderBy_DataGrid(frmSemi.dtMeterialReq);
                            }
                        }

                        frm_RawMeterial_SemiFinished frmSubstituteMats = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);
                        dtMeterialReq.Rows.Add("0", oItem.Item_ID, clsGenaralName.getName_Item(oItem.Item_ID), oItem.Uom_ID, clsGenaralName.getName_Uom(oItem.Uom_ID),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                            "default",
                            "<Select Section>",
                            "0.00",
                            "0.00",
                            oItem.IsSemiFinishGood, frmSemi, frmSubstituteMats, "1 Option");
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FrmWIP_SF_Search_RowSelected(List<string> lstResult)
        {
            try
            {
                bool bAddItem = false;
                DataRow[] items = dtWIP_Flow.Select("Item_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Item Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    dtWIP_Flow.Rows.Add("0", lstResult[0], lstResult[2],
                        lstResult[6], clsGenaralName.getName_Uom(lstResult[6]),
                        cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity),
                        "default", "<Select Section>", "default", "<Select Section>",
                        "0 Materials", new List<cls_BoMDetailMaterial>(), false);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
            }
        }

        private void txtPreviousFG_Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (txtProdJobID.Tag != null)
            {
                frm_search RowDataSearch = new frm_search();
                RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionBoMJobs);
                if (RowDataSearch.DialogResult == true)
                {
                    txtPreviousBoMTemplate.Text = lstResult[3];
                    tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.Select(lstResult[0]);
                    if (oProdJob != null)
                    {
                        fillDetails_fromPreviousJob(oProdJob.ProdJob_ID);
                        txtPreviousBoMTemplate.Tag = oProdJob.ProdJob_ID;
                        txtPreviousBoMTemplate.Text = oProdJob.ProdJob_ID + "\n" + clsGenaralName.getName_Item(clsGenaralName.getID_ApparelBoM_FinishedGood(oProdJob.ProdJob_ID)); ;
                    }
                    else
                    {
                        SEACCMessageBox.Show("Can not Fill...", "Selected Item doesn't have a created BoM", MessageBoxButton.OK, "Red");
                        ClearFields();
                    }
                }
            }
        }
        #endregion

        #region Other Text Box Events
        private void txtFinishedGoodEstWastage_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal dInputQty = decimal.Parse(txtFinishGoodOrderedQty.Text);
            decimal dWastagePct = decimal.Parse(txtFinishedGoodEstWastage.TextBox1.Text);
            decimal dPlannedQty = (dInputQty * (dWastagePct + 100) / 100);
            txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(dPlannedQty, clsConfig.sDecimalPlaces_Quantity);
        }

        private void txtFinishedGoodEstWastage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtFinishedGoodEstWastage_LostFocus(sender, e);
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

        #region Other Events

        private void lblNextUI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_BOM_Finance UC;
            if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOM_Finance(txtProdJobID.Tag.ToString(), FormName.Prod_BOMDetails_Production_SpecialPermission);
                else
                    UC = new UC_BOM_Finance(FormName.Prod_BOMDetails_Production_SpecialPermission);
            }
            else
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOM_Finance(txtProdJobID.Tag.ToString(), FormName.Prod_BOMCosting_Finance);
                else
                    UC = new UC_BOM_Finance(FormName.Prod_BOMCosting_Finance);
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
                    decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                    decimal dwastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                    row["TotalQty"] = cls_Formater.FormatDecimal(dQty * (100 + dwastage_Pct) / 100, clsConfig.sDecimalPlaces_Quantity);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private DataTable Get_ItemCosting_ForEditAfterApproved(string sBoM_ID, bool bIsEditAfterApprovedMode)
        {
            DataTable dtBoMPrvCostingInMat = null;

            if (bIsEditAfterApprovedMode)
            {
                dtBoMPrvCostingInMat = new DataTable();
                dtBoMPrvCostingInMat.Columns.Add("Item_ID");
                dtBoMPrvCostingInMat.Columns.Add("Weighted_cost");
                dtBoMPrvCostingInMat.Columns.Add("Height_cost");
                dtBoMPrvCostingInMat.Columns.Add("Lowest_cost");
                dtBoMPrvCostingInMat.Columns.Add("BoM_cost");

                foreach (tbl_prodTxJobCard_Material oMat in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).OrderBy(r => r.Item_ID))
                {
                    DataRow[] drItems = dtBoMPrvCostingInMat.Select("Item_ID = '" + oMat.Item_ID + "'");
                    if (drItems.Length == 0)
                    {
                        dtBoMPrvCostingInMat.Rows.Add(oMat.Item_ID, oMat.WeightedAvgCost, oMat.HighestCost, oMat.LowestCost, oMat.BomCost);
                    }
                }
            }
            return dtBoMPrvCostingInMat;
        }

        private decimal Get_ItemPriceCost_ForEditAfterApproved(prod_Costing_Mode enumCostingMode, string sItem_ID, DataTable dtItemGridWithCost, tbl_genItemMaster_Pricing oItem_Finance)
        {
            decimal dCost = 0;
            DataRow[] drItems = dtItemGridWithCost.Select("Item_ID = '" + sItem_ID + "'");
            if (drItems.Length > 0)
            {
                switch (enumCostingMode)
                {
                    case prod_Costing_Mode.Weighted_Avg_Cost:
                        dCost = clsValidation.Validate_DecimalNumber(drItems[0]["Weighted_cost"].ToString());
                        break;
                    case prod_Costing_Mode.Lowest_Cost:
                        dCost = clsValidation.Validate_DecimalNumber(drItems[0]["Height_cost"].ToString());
                        break;
                    case prod_Costing_Mode.Highest_Cost:
                        dCost = clsValidation.Validate_DecimalNumber(drItems[0]["Lowest_cost"].ToString());
                        break;
                    case prod_Costing_Mode.BoM_Cost:
                        dCost = clsValidation.Validate_DecimalNumber(drItems[0]["BoM_cost"].ToString());
                        break;
                    default:
                        dCost = 0;
                        break;
                }
            }
            else
            {
                switch (enumCostingMode)
                {
                    case prod_Costing_Mode.Weighted_Avg_Cost:
                        dCost = oItem_Finance.WeightedAverageCostPrice;
                        break;
                    case prod_Costing_Mode.Lowest_Cost:
                        dCost = oItem_Finance.LowestPurchaseCostPrice;
                        break;
                    case prod_Costing_Mode.Highest_Cost:
                        dCost = oItem_Finance.HighestPurchaseCostPrice;
                        break;
                    case prod_Costing_Mode.BoM_Cost:
                        dCost = clsHelpMethods_Prod.Get_UnitCostWithoutTax_BoM(clsHelpMethods_Prod.Get_BoM_formFinishedGood(oItem_Finance.Item_ID));
                        break;
                    default:
                        dCost = 0;
                        break;
                }
            }

            return dCost;
        }

        private void Save_SubIn_Data()
        {
            foreach (DataRow drItem in dtSubIn_Items.Rows)
            {
                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(drItem, "LineNo", 0));
                int iMatGrid_LineNo = Convert.ToInt32(clsValidate.ValidateRowValue(drItem, "MatGrid_LineNo", 0));
                string sItem_ID = clsValidate.ValidateRowValue(drItem, "Item_ID", "default");
                string sUoM_ID = clsValidate.ValidateRowValue(drItem, "UoM_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(drItem, "Qty", 0m);
                string sSection_ID = clsValidate.ValidateRowValue(drItem, "Section_ID", "default");
                frm_MaterialSelection_SubIn frmMatList = drItem.Field<frm_MaterialSelection_SubIn>("Materials");

                tbl_prodTxJobCard_SubIn_SFG oBoM_SIN = new tbl_prodTxJobCard_SubIn_SFG(txtProdJobID.Tag.ToString(), iLine_no, sItem_ID, sUoM_ID, dQty, sSection_ID, iMatGrid_LineNo);
                oBoM_SIN.Insert();

                if (frmMatList != null)
                {
                    foreach (DataRow drRowMat in frmMatList.dtMeterial_Req.Rows)
                    {
                        int iLine_no_drRowMat = Convert.ToInt32(clsValidate.ValidateRowValue(drRowMat, "LineNo", 0));
                        bool bIsSelect_drRowMat = clsValidate.ValidateRowValue(drRowMat, "IsSelect", "\uE003") == "\uE003" ? false : true;
                        string sItem_ID_drRowMat = clsValidate.ValidateRowValue(drRowMat, "Item_ID", "default");

                        tbl_prodTxJobCard_SubIn_SFG_Material oMaterial = new tbl_prodTxJobCard_SubIn_SFG_Material(oBoM_SIN.ProdJob_ID, oBoM_SIN.Line_no, iLine_no_drRowMat, true, sItem_ID_drRowMat, bIsSelect_drRowMat);
                        oMaterial.Insert();
                    }

                    foreach (DataRow drWipSF in frmMatList.dtWIP_SF_Req.Rows)
                    {
                        int iLine_no_drWipSF = Convert.ToInt32(clsValidate.ValidateRowValue(drWipSF, "LineNo", 0));
                        bool bIsSelect_drWipSF = clsValidate.ValidateRowValue(drWipSF, "IsSelect", "\uE003") == "\uE003" ? false : true;
                        string sItem_ID_drWipSF = clsValidate.ValidateRowValue(drWipSF, "Item_ID", "default");

                        tbl_prodTxJobCard_SubIn_SFG_Material oMaterial = new tbl_prodTxJobCard_SubIn_SFG_Material(oBoM_SIN.ProdJob_ID, oBoM_SIN.Line_no, iLine_no_drWipSF, false, sItem_ID_drWipSF, bIsSelect_drWipSF);
                        oMaterial.Insert();

                        if (!oMaterial.IsSubOutRawMaterial && oMaterial.IsSelect)
                        {
                            tbl_prodTxJobCard_WIPFlow oWIP_Flow = tbl_prodTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Tag.ToString()).Where(r => r.Item_ID == sItem_ID_drWipSF).FirstOrDefault();
                            oWIP_Flow.IsSubOut = true;
                            oWIP_Flow.Update();
                        }
                    }
                }
            }
        }

        private void Delete_SubInb_Data()
        {
            tbl_prodTxJobCard_SubIn_SFG_Material.DeleteAllByProdJob_ID(txtProdJobID.Tag.ToString());
            tbl_prodTxJobCard_SubIn_SFG.DeleteAllByProdJob_ID(txtProdJobID.Tag.ToString());
        }

        #endregion

    }
}
