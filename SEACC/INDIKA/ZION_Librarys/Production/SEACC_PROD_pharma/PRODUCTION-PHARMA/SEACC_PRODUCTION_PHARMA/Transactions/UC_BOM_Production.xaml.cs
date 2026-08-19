using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_PRODUCTION_PHARMA.Controls;
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
    /// Developed by Gayan
    /// On 2017-05-04
    /// </summary>
    public partial class UC_BOM_Production : UserControl
    {
        #region Class Variables
        DataTable dtMeterialReq = new DataTable();
        DataTable dtSMV_BreakDown = new DataTable();
        DataTable dtWIP_Flow = new DataTable();
        BrushConverter bc = new BrushConverter();
        private bool bIsSpecialPermission_EditBoM = false;
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
            dtMeterialReq.Columns.Add("LineNo");
            dtMeterialReq.Columns.Add("Item_ID");
            dtMeterialReq.Columns.Add("ItemName");
            dtMeterialReq.Columns.Add("UoM_ID");
            dtMeterialReq.Columns.Add("UoM");
            dtMeterialReq.Columns.Add("Qty");
            dtMeterialReq.Columns.Add("Wastage");
            dtMeterialReq.Columns.Add("TotalQty");
            dtMeterialReq.Columns.Add("SectionID");
            dtMeterialReq.Columns.Add("SectionName");
            dtMeterialReq.Columns.Add("ActivityID");
            dtMeterialReq.Columns.Add("ActivityName");
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
            dtWIP_Flow.Columns.Add("InActivity_ID");
            dtWIP_Flow.Columns.Add("InActivity_Name");
            dtWIP_Flow.Columns.Add("OutSection_ID");
            dtWIP_Flow.Columns.Add("OutSection_Name");
            dtWIP_Flow.Columns.Add("OutActivity_ID");
            dtWIP_Flow.Columns.Add("OutActivity_Name");
            dtWIP_Flow.Columns.Add("Material_Count");
            dtWIP_Flow.Columns.Add("Materials", typeof(List<cls_BoMDetailMaterial>));
            #endregion

            #region SMV Break Down
            dtSMV_BreakDown.Columns.Add("LineNo");
            dtSMV_BreakDown.Columns.Add("Operation_ID");
            dtSMV_BreakDown.Columns.Add("Operation_Name");
            dtSMV_BreakDown.Columns.Add("SMV_PerPC");
            #endregion

            #region Main Table
            dgr_Main.dt.Columns.Add("LINE_NO");
            dgr_Main.dt.Columns.Add("JOB_ID");
            dgr_Main.dt.Columns.Add("JOB_DATE");
            dgr_Main.dt.Columns.Add("ITEM");
            dgr_Main.dt.Columns.Add("STATUS");
            dgr_Main.dt.Columns.Add("ORDERED_QTY");
            dgr_Main.dt.Columns.Add("STORES_QTY");
            dgr_Main.dt.Columns.Add("CUSTOMER");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("APPROVED_BY");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            dgr_Main.dt.Columns.Add("IS_LOCKED");
            #endregion
            #endregion

            #region Initialize Action Buttons
            if (SEACC_Form.enmFormName == FormName.ProdPharma_BOMDetails_SpecialPermission)
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
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LINE_NO", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job #", "JOB_ID", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JOB_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Description", "ITEM", 200);
            dgr_Main.Add_DatagridColoumn("BoM Status", "STATUS", 100);
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
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (oJob.IsApproved1 || bIsSpecialPermission_EditBoM)
                                {
                                    if ((!oJob.IsApproved2 && !oJob.IsApproved3) || bIsSpecialPermission_EditBoM)
                                    {
                                        int iBoM_Status = 0;
                                        if (oJob.ProdJobStatus < (int)prod_BoM_Status.BoMProd)
                                            iBoM_Status = (int)prod_BoM_Status.BoMProd;
                                        else
                                            iBoM_Status = oJob.ProdJobStatus;

                                        #region BoM Header Table Update
                                        tbl_prod_pharmaTxJobCard oOldJob = new tbl_prod_pharmaTxJobCard(
                                                                            oJob.ProdJob_ID, dtpProdJob_Date.GetDateTime(), iBoM_Status,// cmbProdJobStatus.GetSelectedIndex(),
                                                                            oJob.Salesman_ID,
                                                                            oJob.Customer_ID,
                                                                            txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                                                            txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                                                            txtComments.Text,
                                                                            txtReEditComments.Text,
                                                                            oJob.JobType_ID, oJob.ProdRange_ID, oJob.ProdCategory_ID, oJob.ProdSize_ID, oJob.Colour_ID, oJob.Item_ID_Previous, oJob.Item_ID_FG,
                                                                            txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                                                            oJob.Item_Length, oJob.Item_Length_UoM_ID, oJob.Item_Width, oJob.Item_Weight_UoM_ID, oJob.Item_Height, oJob.Item_Height_UoM_ID, oJob.Item_Diameter, oJob.Item_Diameter_UoM_ID, oJob.Item_Radius, oJob.Item_Radius_UoM_ID, oJob.Item_Thickness, oJob.Item_Thickness_UoM_ID, oJob.Item_Weight, oJob.Item_Weight_UoM_ID,
                                                                            decimal.Parse(txtFinishGoodOrderedQty.Text), decimal.Parse(txtFinishedGoodPlannedQty.Text), decimal.Parse(txtFinishedGoodEstWastage.Text), oJob.WasteQty, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
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
                                                                            oJob.CanceledUserTerminal_ID, oJob.LockedUserTerminal_ID, oJob.CompanyID, oJob.CompanyBranchID, oJob.CustomerOrder_Qty, chkTemporaryBoM.IsChecked);
                                        oOldJob.Update();
                                        #endregion

                                        if (clsHelpMethods_Prod.BatchCount_ForBoM(oJob.ProdJob_ID) < 1)//Check Batch Count and There is no any batch related to the BoM
                                        {
                                            #region Delete Exist Data
                                            foreach (tbl_prod_pharmaTxJobCard_Material_Outsource oItem_Outsource in tbl_prod_pharmaTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtProdJobID.Text))
                                            {
                                                oItem_Outsource.Delete();
                                            }

                                            tbl_prod_pharmaTxJobCard_Material.DeleteAllByProdJob_ID(oJob.ProdJob_ID);

                                            foreach (tbl_prod_pharmaTxJobCard_WIPFlow oObj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID))
                                                tbl_prod_pharmaTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);

                                            tbl_prod_pharmaTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oJob.ProdJob_ID);

                                            #endregion

                                            #region BoM Material Insert
                                            foreach (DataRow row in dtMeterialReq.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                string sActivity_ID = clsValidate.ValidateRowValue(row, "ActivityID", "default");
                                                decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
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
                                                tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                                if (oItem_Finance != null)
                                                {
                                                    dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;
                                                    dLowestCost = oItem_Finance.LowestPurchaseCostPrice;
                                                    dHighestCost = oItem_Finance.HighestPurchaseCostPrice;
                                                }

                                                decimal dSelectedCost = 0;
                                                int iSelectedCost = 0;
                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                {
                                                    case "0":
                                                        dSelectedCost = dItemWAvgCost;
                                                        iSelectedCost = 0;
                                                        break;
                                                    case "1":
                                                        dSelectedCost = dLowestCost;
                                                        iSelectedCost = 1;
                                                        break;
                                                    case "2":
                                                        dSelectedCost = dHighestCost;
                                                        iSelectedCost = 2;
                                                        break;
                                                }

                                                //Edited cost default set to selected cost
                                                decimal dEditedCost = (dSelectedCost * dTotalQty);
                                                #region Total Cost Without Tax for Semi Finisheds
                                                if (IsSemiFinished)
                                                    dEditedCost = clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(clsHelpMethods_Prod.GetBoM_formFinishedGood(sItem_ID)) * dTotalQty;
                                                dEditedCost = dEditedCost == 0 ? (dSelectedCost * dTotalQty) : dEditedCost;
                                                #endregion

                                                tbl_prod_pharmaTxJobCard_Material oNewProdMaterial = new tbl_prod_pharmaTxJobCard_Material(iLine_no, 0, 0, oJob.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, sActivity_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, iSelectedCost, (dSelectedCost * dTotalQty), false, dEditedCost, 1);
                                                oNewProdMaterial.Insert();

                                                #region Semi Finisheds Outsource Rate

                                                if (IsSemiFinished && oNewProdMaterial != null)
                                                {
                                                    List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                    decimal dSF_MaxOutsouceRate = 0;
                                                    if (oList_ItemOutsource.Count > 0)
                                                        dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                    tbl_prod_pharmaTxJobCard_Material_Outsource oSF_Outsource = new tbl_prod_pharmaTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                    oSF_Outsource.Insert();
                                                }
                                                #endregion

                                                //Semi Finished Item Saving
                                                frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                {
                                                    foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                    {
                                                        int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0m));
                                                        string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                        string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                        decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                        decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                        decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                        string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                        string sActivity_ID_sub = clsValidate.ValidateRowValue(row_semi, "ActivityID", "default");
                                                        decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                        decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                        decimal dItemWAvgCost_sub = 0;
                                                        decimal dLowestCost_sub = 0;
                                                        decimal dHighestCost_sub = 0;
                                                        tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                        tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                        if (oItem_Finance_sub != null)
                                                        {
                                                            dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                            dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                            dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                        }

                                                        decimal dSelectedCost_Semi = 0;
                                                        int iSelectedCost_Sub = 0;
                                                        switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                        {
                                                            case "0":
                                                                dSelectedCost_Semi = dItemWAvgCost_sub;
                                                                iSelectedCost_Sub = 0;
                                                                break;
                                                            case "1":
                                                                dSelectedCost_Semi = dLowestCost_sub;
                                                                iSelectedCost_Sub = 1;
                                                                break;
                                                            case "2":
                                                                dSelectedCost_Semi = dHighestCost_sub;
                                                                iSelectedCost_Sub = 2;
                                                                break;
                                                        }
                                                        //Edited cost default set to selected cost
                                                        decimal dEditedCost_Semi = (dSelectedCost_Semi * dTotalQty_sub);
                                                        tbl_prod_pharmaTxJobCard_Material oNewDelivery_Sub = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_sub, 0, oJob.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, sActivity_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, iSelectedCost_Sub, (dSelectedCost_Semi * dTotalQty_sub), false, dEditedCost_Semi, 1);
                                                        oNewDelivery_Sub.Insert();

                                                        //Substitute Materials for Semi Finisheds Saving
                                                        frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                        if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                        {
                                                            foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                            {
                                                                int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0m));
                                                                string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                string sActivity_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "ActivityID", "default");
                                                                decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                decimal dItemWAvgCost_substitute_Semi = 0;
                                                                decimal dLowestCost_substitute_Semi = 0;
                                                                decimal dHighestCost_substitute_Semi = 0;
                                                                tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                if (oItem_Finance_substitute_Semi != null)
                                                                {
                                                                    dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                    dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                    dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                }
                                                                decimal dSelectedCostSubstitute_Semi = 0;
                                                                int iSelectedCostSubstitute_Semi = 0;
                                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                {
                                                                    case "0":
                                                                        dSelectedCostSubstitute_Semi = dItemWAvgCost_substitute_Semi;
                                                                        iSelectedCostSubstitute_Semi = 0;
                                                                        break;
                                                                    case "1":
                                                                        dSelectedCostSubstitute_Semi = dLowestCost_substitute_Semi;
                                                                        iSelectedCostSubstitute_Semi = 1;
                                                                        break;
                                                                    case "2":
                                                                        dSelectedCostSubstitute_Semi = dHighestCost_substitute_Semi;
                                                                        iSelectedCostSubstitute_Semi = 2;
                                                                        break;
                                                                }
                                                                //Edited cost default set to selected cost
                                                                decimal dEditedCostSubstitute_Semi = (dSelectedCostSubstitute_Semi * dTotalQty_substitute_Semi);

                                                                tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oJob.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, sActivity_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, iSelectedCostSubstitute_Semi, dEditedCostSubstitute_Semi, false, 0, 1);
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
                                                        int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0m));
                                                        string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                        string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                        decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                        decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                        decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                        string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                        string sActivity_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "ActivityID", "default");
                                                        decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                        decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                        decimal dItemWAvgCost_substitute_Main = 0;
                                                        decimal dLowestCost_substitute_Main = 0;
                                                        decimal dHighestCost_substitute_Main = 0;
                                                        tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                        tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                        if (oItem_Finance_substitute_Main != null)
                                                        {
                                                            dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                            dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                            dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                        }
                                                        decimal dSelectedCostSubstitute_Main = 0;
                                                        int iSelectedCostSubstitute_Main = 0;
                                                        switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                        {
                                                            case "0":
                                                                dSelectedCostSubstitute_Main = dItemWAvgCost_substitute_Main;
                                                                iSelectedCostSubstitute_Main = 0;
                                                                break;
                                                            case "1":
                                                                dSelectedCostSubstitute_Main = dLowestCost_substitute_Main;
                                                                iSelectedCostSubstitute_Main = 1;
                                                                break;
                                                            case "2":
                                                                dSelectedCostSubstitute_Main = dHighestCost_substitute_Main;
                                                                iSelectedCostSubstitute_Main = 2;
                                                                break;
                                                        }
                                                        //Edited cost default set to selected cost
                                                        decimal dEditedCostSubstitute_Main = (dSelectedCostSubstitute_Main * dTotalQty_substitute_Main);
                                                        tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Main = new tbl_prod_pharmaTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oJob.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, sActivity_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, iSelectedCostSubstitute_Main, dEditedCostSubstitute_Main, false, 0, 1);
                                                        oNewMat_Substitute_Main.Insert();
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                        else //There are any available batches related to the BoM
                                        {
                                            #region Update Exist Data

                                            #region Raw Materials
                                            foreach (DataRow row in dtMeterialReq.Rows)
                                            {
                                                int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                                string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                                string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                                decimal dConsumption = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                                decimal dWastage_Pct = clsValidate.ValidateRowValue(row, "Wastage", 0m);
                                                decimal dTotalQty = clsValidate.ValidateRowValue(row, "TotalQty", 0m);
                                                string sSection_ID = clsValidate.ValidateRowValue(row, "SectionID", "default");
                                                string sActivity_ID = clsValidate.ValidateRowValue(row, "ActivityID", "default");
                                                decimal dSMV_Time = clsValidate.ValidateRowValue(row, "EstTime", 0m);
                                                decimal dLabourCount = clsValidate.ValidateRowValue(row, "LabourCount", 0m);
                                                bool IsSemiFinished = clsValidate.ValidateRowValue(row, "IsSemiFinished", false);
                                                frm_RawMeterial_SemiFinished frmSemi = row.Field<frm_RawMeterial_SemiFinished>("SemiFinished_RawMeterials");
                                                frm_RawMeterial_SemiFinished frmSubtitute_Main = row.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                tbl_prod_pharmaTxJobCard_Material oMaterial = tbl_prod_pharmaTxJobCard_Material.Select(iLine_no, 0, 0, txtProdJobID.Text.Trim());

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
                                                    }
                                                    decimal dSelectedCost = 0;
                                                    int iSelectedCost = 0;
                                                    switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                    {
                                                        case "0":
                                                            dSelectedCost = oMaterial.WeightedAvgCost;
                                                            iSelectedCost = 0;
                                                            break;
                                                        case "1":
                                                            dSelectedCost = oMaterial.LowestCost;
                                                            iSelectedCost = 1;
                                                            break;
                                                        case "2":
                                                            dSelectedCost = oMaterial.HighestCost;
                                                            iSelectedCost = 2;
                                                            break;
                                                    }

                                                    //Edited cost default set to selected cost
                                                    #region Total Cost (Without Tax for Semi Finisheds)
                                                    decimal dEditedCost = (dSelectedCost * dTotalQty);
                                                    if (IsSemiFinished)
                                                        dEditedCost = clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(clsHelpMethods_Prod.GetBoM_formFinishedGood(sItem_ID));
                                                    dEditedCost = dEditedCost == 0 ? (oMaterial.WeightedAvgCost * dTotalQty) : dEditedCost;

                                                    oMaterial.CostTypeSelection = iSelectedCost;
                                                    oMaterial.Cost = dEditedCost;
                                                    oMaterial.EditedCost = dEditedCost;
                                                    #endregion

                                                    oMaterial.Update();
                                                    #endregion

                                                    #region SF Item's Materials
                                                    if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                    {
                                                        foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0m));
                                                            string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                            string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                            decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                            decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                            decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                            string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                            string sActivity_ID_sub = clsValidate.ValidateRowValue(row_semi, "ActivityID", "default");
                                                            decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                            decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);
                                                            frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");

                                                            tbl_prod_pharmaTxJobCard_Material oNewMat_Semi = tbl_prod_pharmaTxJobCard_Material.Select(iLine_no, iLine_no_semi, 0, txtProdJobID.Text.Trim());
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
                                                                }

                                                                decimal dSelectedCost_semi = 0;
                                                                int iSelectedCost_semi = 0;
                                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                {
                                                                    case "0":
                                                                        dSelectedCost_semi = oNewMat_Semi.WeightedAvgCost;
                                                                        iSelectedCost_semi = 0;
                                                                        break;
                                                                    case "1":
                                                                        dSelectedCost_semi = oNewMat_Semi.LowestCost;
                                                                        iSelectedCost_semi = 1;
                                                                        break;
                                                                    case "2":
                                                                        dSelectedCost_semi = oNewMat_Semi.HighestCost;
                                                                        iSelectedCost_semi = 2;
                                                                        break;
                                                                }

                                                                oNewMat_Semi.CostTypeSelection = iSelectedCost_semi;
                                                                oNewMat_Semi.Cost = (dSelectedCost_semi * dTotalQty_sub);
                                                                oNewMat_Semi.EditedCost = oNewMat_Semi.Cost;

                                                                oNewMat_Semi.Update();
                                                                #endregion

                                                                #region Substitutes of SF Raw Materilas
                                                                if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                    {
                                                                        int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0m));
                                                                        string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                        string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                        decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                        decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                        decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                        string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                        string sActivity_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "ActivityID", "default");
                                                                        decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                        decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                        tbl_prod_pharmaTxJobCard_Material oSubstitute_Mat_Semi = tbl_prod_pharmaTxJobCard_Material.Select(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, txtProdJobID.Text.Trim());
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
                                                                            }
                                                                            decimal dSelectedCost_Substitute_Mat_Semi = 0;
                                                                            int iSelectedCost_Substitute_Mat_Semi = 0;
                                                                            switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                            {
                                                                                case "0":
                                                                                    dSelectedCost_Substitute_Mat_Semi = oSubstitute_Mat_Semi.WeightedAvgCost;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 0;
                                                                                    break;
                                                                                case "1":
                                                                                    dSelectedCost_Substitute_Mat_Semi = oSubstitute_Mat_Semi.LowestCost;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 1;
                                                                                    break;
                                                                                case "2":
                                                                                    dSelectedCost_Substitute_Mat_Semi = oSubstitute_Mat_Semi.HighestCost;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 2;
                                                                                    break;
                                                                            }

                                                                            oSubstitute_Mat_Semi.CostTypeSelection = iSelectedCost_Substitute_Mat_Semi;
                                                                            oSubstitute_Mat_Semi.Cost = (dSelectedCost_Substitute_Mat_Semi * dTotalQty_substitute_Semi);
                                                                            oSubstitute_Mat_Semi.EditedCost = oSubstitute_Mat_Semi.Cost;

                                                                            oSubstitute_Mat_Semi.Update();
                                                                            #endregion
                                                                        }
                                                                        else
                                                                        {
                                                                            decimal dItemWAvgCost_substitute_Semi = 0;
                                                                            decimal dLowestCost_substitute_Semi = 0;
                                                                            decimal dHighestCost_substitute_Semi = 0;
                                                                            tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                            if (oItem_Finance_substitute_Semi != null)
                                                                            {
                                                                                dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                                dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                                dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                            }
                                                                            decimal dSelectedCost_Substitute_Mat_Semi = 0;
                                                                            int iSelectedCost_Substitute_Mat_Semi = 0;
                                                                            switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                            {
                                                                                case "0":
                                                                                    dSelectedCost_Substitute_Mat_Semi = dItemWAvgCost_substitute_Semi;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 0;
                                                                                    break;
                                                                                case "1":
                                                                                    dSelectedCost_Substitute_Mat_Semi = dLowestCost_substitute_Semi;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 1;
                                                                                    break;
                                                                                case "2":
                                                                                    dSelectedCost_Substitute_Mat_Semi = dHighestCost_substitute_Semi;
                                                                                    iSelectedCost_Substitute_Mat_Semi = 2;
                                                                                    break;
                                                                            }

                                                                            tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oJob.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, sActivity_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, iSelectedCost_Substitute_Mat_Semi, (dSelectedCost_Substitute_Mat_Semi * dTotalQty_substitute_Semi), false, 0, 1);
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
                                                                tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                                tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                                if (oItem_Finance_sub != null)
                                                                {
                                                                    dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                    dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                    dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                                }
                                                                decimal dSelectedCost_Sub = 0;
                                                                int iSelectedCost_Sub = 0;
                                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                {
                                                                    case "0":
                                                                        dSelectedCost_Sub = dItemWAvgCost_sub;
                                                                        iSelectedCost_Sub = 0;
                                                                        break;
                                                                    case "1":
                                                                        dSelectedCost_Sub = dLowestCost_sub;
                                                                        iSelectedCost_Sub = 1;
                                                                        break;
                                                                    case "2":
                                                                        dSelectedCost_Sub = dHighestCost_sub;
                                                                        iSelectedCost_Sub = 2;
                                                                        break;
                                                                }

                                                                tbl_prod_pharmaTxJobCard_Material oNewMat_forSemi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_semi, 0, oJob.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, sActivity_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, iSelectedCost_Sub, (dSelectedCost_Sub * dTotalQty_sub), false, (dSelectedCost_Sub * dTotalQty_sub), 1);
                                                                oNewMat_forSemi.Insert();

                                                                //Substitute Materials for New Semi Finisheds Saving
                                                                if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                                {
                                                                    foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                    {
                                                                        int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0m));
                                                                        string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                        string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                        decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                        decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                        decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                        string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                        string sActivity_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "ActivityID", "default");
                                                                        decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                        decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                        decimal dItemWAvgCost_substitute_Semi = 0;
                                                                        decimal dLowestCost_substitute_Semi = 0;
                                                                        decimal dHighestCost_substitute_Semi = 0;
                                                                        tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                        tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                        if (oItem_Finance_substitute_Semi != null)
                                                                        {
                                                                            dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                            dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                            dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                        }
                                                                        decimal dSelectedCost_substitute_Semi = 0;
                                                                        int iSelectedCost_substitute_Semi = 0;
                                                                        switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                        {
                                                                            case "0":
                                                                                dSelectedCost_substitute_Semi = dItemWAvgCost_substitute_Semi;
                                                                                iSelectedCost_substitute_Semi = 0;
                                                                                break;
                                                                            case "1":
                                                                                dSelectedCost_substitute_Semi = dLowestCost_substitute_Semi;
                                                                                iSelectedCost_substitute_Semi = 1;
                                                                                break;
                                                                            case "2":
                                                                                dSelectedCost_substitute_Semi = dHighestCost_substitute_Semi;
                                                                                iSelectedCost_substitute_Semi = 2;
                                                                                break;
                                                                        }

                                                                        tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_semi, iLine_no_substitute_Semi, oJob.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, sActivity_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, iSelectedCost_substitute_Semi, (dSelectedCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
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
                                                            int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0m));
                                                            string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                            string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                            decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                            decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                            decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                            string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                            string sActivity_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "ActivityID", "default");
                                                            decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                            decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                            tbl_prod_pharmaTxJobCard_Material oSubstituteMeterial = tbl_prod_pharmaTxJobCard_Material.Select(iLine_no, 0, iLine_no_substitute_Main, txtProdJobID.Text.Trim());
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
                                                                }
                                                                decimal dSelectedCost_sub_Main = 0;
                                                                int iSelectedCost_sub_Main = 0;
                                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                {
                                                                    case "0":
                                                                        dSelectedCost_sub_Main = oSubstituteMeterial.WeightedAvgCost;
                                                                        iSelectedCost_sub_Main = 0;
                                                                        break;
                                                                    case "1":
                                                                        dSelectedCost_sub_Main = oSubstituteMeterial.LowestCost;
                                                                        iSelectedCost_sub_Main = 1;
                                                                        break;
                                                                    case "2":
                                                                        dSelectedCost_sub_Main = oSubstituteMeterial.HighestCost;
                                                                        iSelectedCost_sub_Main = 2;
                                                                        break;
                                                                }

                                                                oSubstituteMeterial.CostTypeSelection = iSelectedCost_sub_Main;
                                                                oSubstituteMeterial.Cost = (dSelectedCost_sub_Main * dTotalQty_substitute_Main);
                                                                oSubstituteMeterial.EditedCost = oSubstituteMeterial.Cost;

                                                                oSubstituteMeterial.Update();
                                                                #endregion
                                                            }
                                                            else
                                                            {
                                                                decimal dItemWAvgCost_substitute_Main = 0;
                                                                decimal dLowestCost_substitute_Main = 0;
                                                                decimal dHighestCost_substitute_Main = 0;
                                                                tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                                tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                                if (oItem_Finance_substitute_Main != null)
                                                                {
                                                                    dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                                    dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                                    dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                                }
                                                                decimal dSelectedCost_substitute_Main = 0;
                                                                int iSelectedCost_substitute_Main = 0;
                                                                switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                {
                                                                    case "0":
                                                                        dSelectedCost_substitute_Main = dItemWAvgCost_substitute_Main;
                                                                        iSelectedCost_substitute_Main = 0;
                                                                        break;
                                                                    case "1":
                                                                        dSelectedCost_substitute_Main = dLowestCost_substitute_Main;
                                                                        iSelectedCost_substitute_Main = 1;
                                                                        break;
                                                                    case "2":
                                                                        dSelectedCost_substitute_Main = dHighestCost_substitute_Main;
                                                                        iSelectedCost_substitute_Main = 2;
                                                                        break;
                                                                }
                                                                tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Main = new tbl_prod_pharmaTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oJob.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, sActivity_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, iSelectedCost_substitute_Main, (dSelectedCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
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
                                                    decimal dSelectedCost = 0;
                                                    int iSelectedCost = 0;
                                                    switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                    {
                                                        case "0":
                                                            dSelectedCost = dItemWAvgCost;
                                                            iSelectedCost = 0;
                                                            break;
                                                        case "1":
                                                            dSelectedCost = dLowestCost;
                                                            iSelectedCost = 1;
                                                            break;
                                                        case "2":
                                                            dSelectedCost = dHighestCost;
                                                            iSelectedCost = 2;
                                                            break;
                                                    }

                                                    #region Total Cost Without Tax for Semi Finisheds
                                                    decimal dEditedCost = (dSelectedCost * dTotalQty);
                                                    if (IsSemiFinished)
                                                        dEditedCost = clsHelpMethods_Prod.GetUnitCostWithoutTax_BoM(clsHelpMethods_Prod.GetBoM_formFinishedGood(sItem_ID));
                                                    dEditedCost = dEditedCost == 0 ? (dSelectedCost * dTotalQty) : dEditedCost;
                                                    #endregion

                                                    tbl_prod_pharmaTxJobCard_Material oNewProdMaterial = new tbl_prod_pharmaTxJobCard_Material(iLine_no, 0, 0, oJob.ProdJob_ID, sItem_ID, sUoM_ID, IsSemiFinished, dConsumption, dConsumption, true, dWastage_Pct, 0, dTotalQty, sSection_ID, sActivity_ID, dSMV_Time, dLabourCount, dLowestCost, dHighestCost, dItemWAvgCost, iSelectedCost, (dSelectedCost * dTotalQty), false, dEditedCost, 1);
                                                    oNewProdMaterial.Insert();

                                                    #region Semi Finisheds Outsource Rate

                                                    if (IsSemiFinished && oNewProdMaterial != null)
                                                    {
                                                        List<tbl_genItemMaster_Outsorce> oList_ItemOutsource = tbl_genItemMaster_Outsorce.SelectAllByItem_ID(oNewProdMaterial.Item_ID);
                                                        decimal dSF_MaxOutsouceRate = 0;
                                                        if (oList_ItemOutsource.Count > 0)
                                                            dSF_MaxOutsouceRate = oList_ItemOutsource.Max(r => r.Outsource_Rate);

                                                        tbl_prod_pharmaTxJobCard_Material_Outsource oSF_Outsource = new tbl_prod_pharmaTxJobCard_Material_Outsource(oNewProdMaterial.Line_No, oNewProdMaterial.Line_No_Sub1, oNewProdMaterial.Line_No_Sub2, oNewProdMaterial.ProdJob_ID, oNewProdMaterial.Item_ID, oNewProdMaterial.Uom_ID, oNewProdMaterial.Consumption, dSF_MaxOutsouceRate, (oNewProdMaterial.Consumption * dSF_MaxOutsouceRate));
                                                        oSF_Outsource.Insert();
                                                    }
                                                    #endregion

                                                    //Semi Finished Items Saving
                                                    if (frmSemi.dtMeterialReq.Rows.Count > 0 && IsSemiFinished)
                                                    {
                                                        foreach (DataRow row_semi in frmSemi.dtMeterialReq.Rows)
                                                        {
                                                            int iLine_no_sub = Convert.ToInt32(clsValidate.ValidateRowValue(row_semi, "LineNo", 0m));
                                                            string sItem_ID_sub = clsValidate.ValidateRowValue(row_semi, "Item_ID", "default");
                                                            string sUoM_ID_sub = clsValidate.ValidateRowValue(row_semi, "UoM_ID", "default");
                                                            decimal dQty_sub = clsValidate.ValidateRowValue(row_semi, "Qty", 0m);
                                                            decimal dWastage_Pct_sub = clsValidate.ValidateRowValue(row_semi, "Wastage", 0m);
                                                            decimal dTotalQty_sub = clsValidate.ValidateRowValue(row_semi, "TotalQty", 0m);
                                                            string sSection_ID_sub = clsValidate.ValidateRowValue(row_semi, "SectionID", "default");
                                                            string sActivity_ID_sub = clsValidate.ValidateRowValue(row_semi, "ActivityID", "default");
                                                            decimal dSMV_Time_sub = clsValidate.ValidateRowValue(row_semi, "EstTime", 0m);
                                                            decimal dLabourCount_sub = clsValidate.ValidateRowValue(row_semi, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_sub = 0;
                                                            decimal dLowestCost_sub = 0;
                                                            decimal dHighestCost_sub = 0;
                                                            tbl_genItemMaster oItem_sub = tbl_genItemMaster.Select(sItem_ID_sub);
                                                            tbl_genItemMaster_Pricing oItem_Finance_sub = tbl_genItemMaster_Pricing.Select(sItem_ID_sub);
                                                            if (oItem_Finance_sub != null)
                                                            {
                                                                dItemWAvgCost_sub = oItem_Finance_sub.WeightedAverageCostPrice;
                                                                dLowestCost_sub = oItem_Finance_sub.LowestPurchaseCostPrice;
                                                                dHighestCost_sub = oItem_Finance_sub.HighestPurchaseCostPrice;
                                                            }
                                                            decimal dSelectedCost_sub = 0;
                                                            int iSelectedCost_sub = 0;
                                                            switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                            {
                                                                case "0":
                                                                    dSelectedCost_sub = dItemWAvgCost_sub;
                                                                    iSelectedCost_sub = 0;
                                                                    break;
                                                                case "1":
                                                                    dSelectedCost_sub = dLowestCost_sub;
                                                                    iSelectedCost_sub = 1;
                                                                    break;
                                                                case "2":
                                                                    dSelectedCost_sub = dHighestCost_sub;
                                                                    iSelectedCost_sub = 2;
                                                                    break;
                                                            }

                                                            tbl_prod_pharmaTxJobCard_Material oNewMat_Semi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_sub, 0, oJob.ProdJob_ID, sItem_ID_sub, sUoM_ID_sub, false, dQty_sub, 0, true, dWastage_Pct_sub, 0, dTotalQty_sub, sSection_ID_sub, sActivity_ID_sub, dSMV_Time_sub, dLabourCount_sub, dLowestCost_sub, dHighestCost_sub, dItemWAvgCost_sub, iSelectedCost_sub, (dSelectedCost_sub * dTotalQty_sub), false, (dSelectedCost_sub * dTotalQty_sub), 1);
                                                            oNewMat_Semi.Insert();

                                                            //Substitute Materials for Semi Finisheds Saving
                                                            frm_RawMeterial_SemiFinished frmSubtitute_Semi = row_semi.Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                                                            if (frmSubtitute_Semi.dtMeterialReq.Rows.Count > 0)
                                                            {
                                                                foreach (DataRow row_substitute_Semi in frmSubtitute_Semi.dtMeterialReq.Rows)
                                                                {
                                                                    int iLine_no_substitute_Semi = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Semi, "LineNo", 0m));
                                                                    string sItem_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Item_ID", "default");
                                                                    string sUoM_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "UoM_ID", "default");
                                                                    decimal dQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Qty", 0m);
                                                                    decimal dWastage_Pct_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "Wastage", 0m);
                                                                    decimal dTotalQty_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "TotalQty", 0m);
                                                                    string sSection_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "SectionID", "default");
                                                                    string sActivity_ID_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "ActivityID", "default");
                                                                    decimal dSMV_Time_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "EstTime", 0m);
                                                                    decimal dLabourCount_substitute_Semi = clsValidate.ValidateRowValue(row_substitute_Semi, "LabourCount", 0m);

                                                                    decimal dItemWAvgCost_substitute_Semi = 0;
                                                                    decimal dLowestCost_substitute_Semi = 0;
                                                                    decimal dHighestCost_substitute_Semi = 0;
                                                                    tbl_genItemMaster oItem_substitute_Semi = tbl_genItemMaster.Select(sItem_ID_substitute_Semi);
                                                                    tbl_genItemMaster_Pricing oItem_Finance_substitute_Semi = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Semi);
                                                                    if (oItem_Finance_substitute_Semi != null)
                                                                    {
                                                                        dItemWAvgCost_substitute_Semi = oItem_Finance_substitute_Semi.WeightedAverageCostPrice;
                                                                        dLowestCost_substitute_Semi = oItem_Finance_substitute_Semi.LowestPurchaseCostPrice;
                                                                        dHighestCost_substitute_Semi = oItem_Finance_substitute_Semi.HighestPurchaseCostPrice;
                                                                    }
                                                                    decimal dSelectedCost_substitute_Semi = 0;
                                                                    int iSelectedCost_substitute_Semi = 0;
                                                                    switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                                    {
                                                                        case "0":
                                                                            dSelectedCost_substitute_Semi = dItemWAvgCost_substitute_Semi;
                                                                            iSelectedCost_substitute_Semi = 0;
                                                                            break;
                                                                        case "1":
                                                                            dSelectedCost_substitute_Semi = dLowestCost_substitute_Semi;
                                                                            iSelectedCost_substitute_Semi = 1;
                                                                            break;
                                                                        case "2":
                                                                            dSelectedCost_substitute_Semi = dHighestCost_substitute_Semi;
                                                                            iSelectedCost_substitute_Semi = 2;
                                                                            break;
                                                                    }

                                                                    tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Semi = new tbl_prod_pharmaTxJobCard_Material(iLine_no, iLine_no_sub, iLine_no_substitute_Semi, oJob.ProdJob_ID, sItem_ID_substitute_Semi, sUoM_ID_substitute_Semi, false, dQty_substitute_Semi, 0, true, dWastage_Pct_substitute_Semi, 0, dTotalQty_substitute_Semi, sSection_ID_substitute_Semi, sActivity_ID_substitute_Semi, dSMV_Time_substitute_Semi, dLabourCount_substitute_Semi, dLowestCost_substitute_Semi, dHighestCost_substitute_Semi, dItemWAvgCost_substitute_Semi, iSelectedCost_substitute_Semi, (dSelectedCost_substitute_Semi * dTotalQty_substitute_Semi), false, 0, 1);
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
                                                            int iLine_no_substitute_Main = Convert.ToInt32(clsValidate.ValidateRowValue(row_substitute_Main, "LineNo", 0m));
                                                            string sItem_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Item_ID", "default");
                                                            string sUoM_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "UoM_ID", "default");
                                                            decimal dQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Qty", 0m);
                                                            decimal dWastage_Pct_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "Wastage", 0m);
                                                            decimal dTotalQty_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "TotalQty", 0m);
                                                            string sSection_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "SectionID", "default");
                                                            string sActivity_ID_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "ActivityID", "default");
                                                            decimal dSMV_Time_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "EstTime", 0m);
                                                            decimal dLabourCount_substitute_Main = clsValidate.ValidateRowValue(row_substitute_Main, "LabourCount", 0m);

                                                            decimal dItemWAvgCost_substitute_Main = 0;
                                                            decimal dLowestCost_substitute_Main = 0;
                                                            decimal dHighestCost_substitute_Main = 0;
                                                            tbl_genItemMaster oItem_substitute_Main = tbl_genItemMaster.Select(sItem_ID_substitute_Main);
                                                            tbl_genItemMaster_Pricing oItem_Finance_substitute_Main = tbl_genItemMaster_Pricing.Select(sItem_ID_substitute_Main);
                                                            if (oItem_Finance_substitute_Main != null)
                                                            {
                                                                dItemWAvgCost_substitute_Main = oItem_Finance_substitute_Main.WeightedAverageCostPrice;
                                                                dLowestCost_substitute_Main = oItem_Finance_substitute_Main.LowestPurchaseCostPrice;
                                                                dHighestCost_substitute_Main = oItem_Finance_substitute_Main.HighestPurchaseCostPrice;
                                                            }
                                                            decimal dSelectedCost_substitute_Main = 0;
                                                            int iSelectedCost_substitute_Main = 0;
                                                            switch (clsConfig.sProd_Pharma_DefaultCostType)
                                                            {
                                                                case "0":
                                                                    dSelectedCost_substitute_Main = dItemWAvgCost_substitute_Main;
                                                                    iSelectedCost_substitute_Main = 0;
                                                                    break;
                                                                case "1":
                                                                    dSelectedCost_substitute_Main = dLowestCost_substitute_Main;
                                                                    iSelectedCost_substitute_Main = 1;
                                                                    break;
                                                                case "2":
                                                                    dSelectedCost_substitute_Main = dHighestCost_substitute_Main;
                                                                    iSelectedCost_substitute_Main = 2;
                                                                    break;
                                                            }

                                                            tbl_prod_pharmaTxJobCard_Material oNewMat_Substitute_Main = new tbl_prod_pharmaTxJobCard_Material(iLine_no, 0, iLine_no_substitute_Main, oJob.ProdJob_ID, sItem_ID_substitute_Main, sUoM_ID_substitute_Main, false, dQty_substitute_Main, 0, true, dWastage_Pct_substitute_Main, 0, dTotalQty_substitute_Main, sSection_ID_substitute_Main, sActivity_ID_substitute_Main, dSMV_Time_substitute_Main, dLabourCount_substitute_Main, dLowestCost_substitute_Main, dHighestCost_substitute_Main, dItemWAvgCost_substitute_Main, iSelectedCost_substitute_Main, (dSelectedCost_substitute_Main * dTotalQty_substitute_Main), false, 0, 1);
                                                            oNewMat_Substitute_Main.Insert();
                                                        }
                                                    }
                                                    
                                                }
                                                #endregion

                                            }
                                            #endregion

                                            foreach (tbl_prod_pharmaTxJobCard_WIPFlow oObj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID))
                                                tbl_prod_pharmaTxJobCard_WIPFlow_Detail.DeleteAllBySf_Index(oObj.Sf_Index);

                                            tbl_prod_pharmaTxJobCard_WIPFlow.DeleteAllByProdJob_ID(oJob.ProdJob_ID);

                                            #endregion
                                        }

                                        #region WIP Flow
                                        foreach (DataRow row in dtWIP_Flow.Rows)
                                        {
                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                            string sItem_ID = clsValidate.ValidateRowValue(row, "Item_ID", "default");
                                            string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                            decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                            string sInSection_ID = clsValidate.ValidateRowValue(row, "InSection_ID", "default");
                                            string sInActivity_ID = clsValidate.ValidateRowValue(row, "InActivity_ID", "default");
                                            string sOutSection_ID = clsValidate.ValidateRowValue(row, "OutSection_ID", "default");
                                            string sOutActivty_ID = clsValidate.ValidateRowValue(row, "OutActivity_ID", "default");
                                            List<cls_BoMDetailMaterial> lstMats = row.Field<List<cls_BoMDetailMaterial>>("Materials");

                                            decimal dItemWAvgCost = 0;
                                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                                            tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select(sItem_ID);
                                            if (oItem_Finance != null)
                                                dItemWAvgCost = oItem_Finance.WeightedAverageCostPrice;


                                            tbl_prod_pharmaTxJobCard_WIPFlow oSF_WIP = new tbl_prod_pharmaTxJobCard_WIPFlow(iLine_no, oJob.ProdJob_ID, sItem_ID, sUoM_ID, dQty, 0, dItemWAvgCost, 0, (dQty * dItemWAvgCost), sInSection_ID, sInActivity_ID, sOutSection_ID, sOutActivty_ID);
                                            oSF_WIP.Insert();

                                            foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => !r.BIsWIP_SF))
                                            {
                                                tbl_prod_pharmaTxJobCard_Material oProdMat = tbl_prod_pharmaTxJobCard_Material.Select(oMat.ILineNo, oMat.ILine_No_Sub1, oMat.ILine_No_Sub2, oJob.ProdJob_ID);
                                                if (oProdMat != null)
                                                {
                                                    tbl_prod_pharmaTxJobCard_WIPFlow oSF_WIP_ForUpdateMats = tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.Line_No == oSF_WIP.Line_No && r.Item_ID == oSF_WIP.Item_ID).FirstOrDefault();
                                                    oProdMat.Wipout_sf_Index = oSF_WIP_ForUpdateMats.Sf_Index;
                                                    oProdMat.Update();
                                                }
                                            }
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_WIPFlow oWIP_Obj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID))
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
                                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row_detail, "LineNo", 0m));
                                                        string sItem_ID = clsValidate.ValidateRowValue(row_detail, "Item_ID", "default");
                                                        tbl_prod_pharmaTxJobCard_WIPFlow oWIP_Obj_Detail = tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(oJob.ProdJob_ID).Where(r => r.Line_No == iLine_no && r.Item_ID == sItem_ID).FirstOrDefault();

                                                        if (oWIP_Obj_Detail != null)
                                                        {
                                                            tbl_prod_pharmaTxJobCard_WIPFlow_Detail oWIPFlow_Detail = new tbl_prod_pharmaTxJobCard_WIPFlow_Detail(oWIP_Obj.Sf_Index, oWIP_Obj_Detail.Sf_Index, sItem_ID);
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
                                            int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                            string sOperation_ID = clsValidate.ValidateRowValue(row, "Operation_ID", "default");
                                            decimal dSMV_PerPC = clsValidate.ValidateRowValue(row, "SMV_PerPC", 0m);

                                            tbl_prod_pharmaTxJobCard_ProductionOperation oProdOperation = tbl_prod_pharmaTxJobCard_ProductionOperation.Select(iLine_no, txtProdJobID.Text);
                                            if (oProdOperation != null)
                                            {
                                                oProdOperation.Smv_Per_Pc = dSMV_PerPC;
                                                dTotSMV += dSMV_PerPC;
                                                oProdOperation.Update();
                                            }
                                        }
                                        foreach (tbl_prod_pharmaTxJobCard_CostCenter oProdCostCenter in tbl_prod_pharmaTxJobCard_CostCenter.SelectAllByProdJob_ID(txtProdJobID.Text))
                                        {
                                            oProdCostCenter.Smv = dTotSMV;
                                            oProdCostCenter.Update();
                                        }
                                        #endregion

                                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                    }
                                    else
                                    {
                                        if (SEACC_Form.enmFormName != FormName.ProdPharma_BOMDetails_SpecialPermission)
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
                    FillDetails(sProdJob_ID);
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
                            tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Tag.ToString());
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
                                                //oJob.ProdJobStatus = (int)prod_BoM_Status.BoMFin;
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
                            tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Tag.ToString());
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
            RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionMaterials, true);
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
                    bDeleteItem = (SEACCMessageBox.Show("Are you sure to remove the material? ", "Meterials have been already linked to WIP Flow. When you delete a material, all WIP Flow links will be cleared.", MessageBoxButton.YesNo, "Red"));

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
                }
            }
        }

        #endregion

        #region WIP Flow Grid - Buttons
        private void btnWIPItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frm_search frmWIP_SF_search = new frm_search();
            frmWIP_SF_search.Show(Digiteq_Logic.Search.ProdPharma_SemiFiniseds_FinishedGoods, true);
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
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodEstWastage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodPlannedQty, true, true, false);
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

            chkTemporaryBoM.IsChecked = false;

            txtTotSMVTimeMins.Text = "0.00";

            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpExFac_Date.SetTime(DateTime.Now);
            dtpProductionStart_Date.SetTime(DateTime.Now);

            dtMeterialReq.Clear();
            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;

            dtWIP_Flow.Clear();
            dgr_WIPFlow.ItemsSource = dtWIP_Flow.DefaultView;

            dtSMV_BreakDown.Clear();
            dgr_SmvBreakDown.ItemsSource = dtSMV_BreakDown.DefaultView;

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_BoM_Status));
            cmbProdJobStatus.SetSelectedIndex((int)prod_BoM_Status.BoMProd);
            cmbProdJobStatus.comboBox.IsEnabled = false;

            if (SEACC_Form.enmFormName == FormName.ProdPharma_BOMDetails_SpecialPermission)
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

                List<tbl_prod_pharmaTxJobCard> lstProdJobs;
                if (SEACC_Form.enmFormName == FormName.ProdPharma_BOMDetails_SpecialPermission)
                    lstProdJobs = tbl_prod_pharmaTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_BoM_Status.Obsolete && p.ProdJob_ID != "default" && p.IsApproved2).OrderByDescending(o => o.DateCreate).ToList();
                else
                    lstProdJobs = tbl_prod_pharmaTxJobCard.SelectAll().Where(p => p.ProdJobStatus != (int)prod_BoM_Status.Obsolete && p.ProdJob_ID != "default" && p.IsApproved1).OrderByDescending(o => o.DateCreate).ToList();

                int iCount = 0;
                foreach (tbl_prod_pharmaTxJobCard oJob in lstProdJobs)
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                    if (oItem != null)
                    {
                        decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oJob.Item_ID_FG, "default", "default", "0", "0");
                        dgr_Main.dt.Rows.Add(++iCount, oJob.ProdJob_ID,
                            oJob.ProdJobDate.ToString(clsValidation.Format_Date),
                            clsGenaralName.getName_Item(oJob.Item_ID_FG),
                            clsHelpMethods_Prod.GetEnumDescription((prod_BoM_Status)oJob.ProdJobStatus),
                            clsFormatter.FormatDecimalPlaces_Quantity(oJob.OrderedQty),
                            clsFormatter.FormatDecimalPlaces_Quantity(dStockQty),
                            clsGenaralName.getName_Customer(oJob.Customer_ID),
                            clsGenaralName.getName_User(oJob.CreateUser_ID),
                            clsGenaralName.getName_User(oJob.Approved2User_ID), oJob.IsCanceled, oJob.IsLocked);
                    }
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
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (clsValidate.CheckValidity_TransactionCodeLength(txtProdJobID.Text))
                    {
                        if (CheckEditAfterApprovePermision())
                        {
                            if (Check_WIPFlow())
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
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodSalesName))
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

                tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Text);
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
            if (SEACC_Form.enmFormName == FormName.ProdPharma_BOMDetails_SpecialPermission)
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
                            bIsSpecialPermission_EditBoM = true;
                        }
                        else
                        {
                            bIsSpecialPermission_EditBoM = false;
                            bStatus = false;
                        }

                        frmTwoStepVerify.Close();
                    }
                    else
                    {
                        bIsSpecialPermission_EditBoM = false;
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
                tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(sID);
                if (oJob != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesCode.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oJob.Uom_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID);
                    txtFinishGoodSalesName.ToolTip = oJob.Item_ID_FG;

                    txtProdJobID.Text = oJob.ProdJob_ID;
                    txtComments.Text = oJob.Remarks;
                    txtReEditComments.Text = oJob.Remarks2;
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID == "default" ? "" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID == "default" ? "" : oJob.CustomerOrder_ID;
                    txtFinishedGoodItemDescription.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesCode.Text = clsGenaralName.getCode_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(oJob.WastePercent, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(oJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    chkTemporaryBoM.IsChecked = oJob.IsTemporaryBoM;

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    if (oJob.IsApproved2)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oJob.IsChecked2)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    FillMaterialGrid(oJob.ProdJob_ID);
                    FillWIP_Flow(oJob.ProdJob_ID);
                    FillProdOperationGrid(oJob.ProdJob_ID);

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

        private void FillMaterialGrid(string sProdJob_ID)
        {
            dtMeterialReq.Clear();
            foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No_Sub1 == 0 && r.Line_No_Sub2 == 0))
            {
                frm_RawMeterial_SemiFinished frmSubstitute_Main = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);
                frm_RawMeterial_SemiFinished frmSemi = new frm_RawMeterial_SemiFinished("Raw Meterial List for Semi-Finished Item ", false);

                //Substitute Items for Main
                foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial_ForSubstitute_Main in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 == 0 && r.Line_No_Sub2 != 0))
                {
                    frmSubstitute_Main.dtMeterialReq.Rows.Add(oJob_Meterial_ForSubstitute_Main.Line_No_Sub2,
                        oJob_Meterial_ForSubstitute_Main.Item_ID, clsGenaralName.getName_Item(oJob_Meterial_ForSubstitute_Main.Item_ID),
                        oJob_Meterial_ForSubstitute_Main.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSubstitute_Main.Uom_ID),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.InputQty, clsConfig.sDecimalPlaces_Quantity),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                       oJob_Meterial_ForSubstitute_Main.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSubstitute_Main.Section_ID),
                       oJob_Meterial_ForSubstitute_Main.Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial_ForSubstitute_Main.Activity_ID),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.Smv_TimeMinutes, 2),
                       cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Main.TotalLabour, 2));
                }

                string sSubstituteItemCount = frmSubstitute_Main.dtMeterialReq.Rows.Count == 0 ? "1 Option" : (frmSubstitute_Main.dtMeterialReq.Rows.Count + 1) + " Options";

                //Main Item Add
                dtMeterialReq.Rows.Add("", oJob_Meterial.Item_ID, clsGenaralName.getName_Item(oJob_Meterial.Item_ID), oJob_Meterial.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID),
                    cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                    oJob_Meterial.Section_ID, clsGenaralName.getName_Section(oJob_Meterial.Section_ID),
                    oJob_Meterial.Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial.Activity_ID),
                    cls_Formater.FormatDecimal(oJob_Meterial.Smv_TimeMinutes, 2),
                    cls_Formater.FormatDecimal(oJob_Meterial.TotalLabour, 2),
                    oJob_Meterial.IsSemiFinishItem, frmSemi, frmSubstitute_Main, sSubstituteItemCount);

                foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial_ForSemi in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial.Line_No && r.Line_No_Sub1 != 0 && r.Line_No_Sub2 == 0))
                {
                    frm_RawMeterial_SemiFinished frmSubstitute_Semi = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);

                    //Substitute Items for Materials which is relavant to Semi Finisheds
                    foreach (tbl_prod_pharmaTxJobCard_Material oJob_Meterial_ForSubstitute_Semi in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.Line_No == oJob_Meterial_ForSemi.Line_No && r.Line_No_Sub1 == oJob_Meterial_ForSemi.Line_No_Sub1 && r.Line_No_Sub2 != 0))
                    {
                        frmSubstitute_Semi.dtMeterialReq.Rows.Add(oJob_Meterial_ForSubstitute_Semi.Line_No_Sub2, oJob_Meterial_ForSubstitute_Semi.Item_ID,
                            clsGenaralName.getName_Item(oJob_Meterial_ForSubstitute_Semi.Item_ID),
                            oJob_Meterial_ForSubstitute_Semi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSubstitute_Semi.Uom_ID),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                            oJob_Meterial_ForSubstitute_Semi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSubstitute_Semi.Section_ID),
                            oJob_Meterial_ForSubstitute_Semi.Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial_ForSubstitute_Semi.Activity_ID),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.Smv_TimeMinutes, 2),
                            cls_Formater.FormatDecimal(oJob_Meterial_ForSubstitute_Semi.TotalLabour, 2));
                    }

                    string sSubstituteItemCount_ForSemi = frmSubstitute_Semi.dtMeterialReq.Rows.Count == 0 ? "1 Option" : (frmSubstitute_Semi.dtMeterialReq.Rows.Count + 1) + " Options";

                    //Semi Finished Main Material Add
                    frmSemi.dtMeterialReq.Rows.Add(oJob_Meterial_ForSemi.Line_No_Sub1, oJob_Meterial_ForSemi.Item_ID, clsGenaralName.getName_Item(oJob_Meterial_ForSemi.Item_ID), oJob_Meterial_ForSemi.Uom_ID, clsGenaralName.getName_Uom(oJob_Meterial_ForSemi.Uom_ID),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.InputQty, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.WastagePercent, clsConfig.sDecimalPlaces_Quantity),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalInputQty, clsConfig.sDecimalPlaces_Quantity),
                        oJob_Meterial_ForSemi.Section_ID, clsGenaralName.getName_Section(oJob_Meterial_ForSemi.Section_ID),
                        oJob_Meterial_ForSemi.Activity_ID, clsGenaralName.getName_PharmaSectionActivity(oJob_Meterial_ForSemi.Activity_ID),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.Smv_TimeMinutes, 2),
                        cls_Formater.FormatDecimal(oJob_Meterial_ForSemi.TotalLabour, 2), frmSubstitute_Semi, sSubstituteItemCount_ForSemi);
                }

            }

            dgr_MererialReq.ItemsSource = dtMeterialReq.DefaultView;
        }

        private void FillWIP_Flow(string sProdJob_ID)
        {
            dtWIP_Flow.Rows.Clear();
            foreach (tbl_prod_pharmaTxJobCard_WIPFlow obj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(sProdJob_ID))
            {
                List<cls_BoMDetailMaterial> lstMatList = new List<cls_BoMDetailMaterial>();

                foreach (tbl_prod_pharmaTxJobCard_WIPFlow_Detail objDetail in tbl_prod_pharmaTxJobCard_WIPFlow_Detail.SelectAllBySf_Index(obj.Sf_Index))
                {
                    tbl_prod_pharmaTxJobCard_WIPFlow oJobCard_WIPFlow = tbl_prod_pharmaTxJobCard_WIPFlow.Select(objDetail.Wipout_sf_Index);
                    if (oJobCard_WIPFlow != null)
                    {
                        cls_BoMDetailMaterial oBoMDetailMaterial = new cls_BoMDetailMaterial();
                        oBoMDetailMaterial.BIsWIP_SF = true;
                        oBoMDetailMaterial.ILineNo = oJobCard_WIPFlow.Line_No;
                        oBoMDetailMaterial.SItem_ID = objDetail.Item_ID;
                        lstMatList.Add(oBoMDetailMaterial);
                    }
                }

                foreach (tbl_prod_pharmaTxJobCard_Material oMat in tbl_prod_pharmaTxJobCard_Material.SelectAllByWipout_sf_Index(obj.Sf_Index))
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
                    obj.InActivityID,
                    clsGenaralName.getName_PharmaSectionActivity(obj.InActivityID),
                    obj.OutSectionID,
                    clsGenaralName.getName_Section(obj.OutSectionID),
                    obj.OutActivityID,
                    clsGenaralName.getName_PharmaSectionActivity(obj.OutActivityID),
                    (lstMatList.Count == 1 ? lstMatList.Count + " Material" : lstMatList.Count + " Materials"),
                    lstMatList
                    );
            }
        }

        private void FillProdOperationGrid(string sProdJob_ID)
        {
            dtSMV_BreakDown.Clear();
            foreach (tbl_prod_pharmaTxJobCard_ProductionOperation oProdOperation in tbl_prod_pharmaTxJobCard_ProductionOperation.SelectAllByProdJob_ID(sProdJob_ID))
            {
                tbl_prod_pharmaMasProductionOperation oMasOper = tbl_prod_pharmaMasProductionOperation.Select(oProdOperation.Operation_ID);
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
                //Locked BoM
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[11].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#a0ffa0");
                }

                //Canceled BoM
                else if (Convert.ToBoolean(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[10].ToString()))
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
                        frmSemi.sSection_ID = dtMeterialReq.Rows[irowID]["SectionID"].ToString();
                        frmSemi.sSection_Name = dtMeterialReq.Rows[irowID]["SectionName"].ToString();
                        frmSemi.sActivity_ID = dtMeterialReq.Rows[irowID]["ActivityID"].ToString();
                        frmSemi.sActivity_Name = dtMeterialReq.Rows[irowID]["ActivityName"].ToString();
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
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtMeterialReq.Rows[irowID]["SectionID"] = lstResult[0];
                        dtMeterialReq.Rows[irowID]["SectionName"] = lstResult[1];
                    }
                }
                else if (vDG_Cell.Column.SortMemberPath == "ActivityName")
                {
                    string sSection_ID = dtMeterialReq.Rows[irowID]["SectionID"].ToString();
                    List<string> lstParameeters = new List<string>();
                    if (sSection_ID != "default" && sSection_ID != "")
                        lstParameeters.Add(sSection_ID);

                    frm_search RowDataSearch = new frm_search(lstParameeters);
                    RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                    RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                    List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSectionActivities);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dtMeterialReq.Rows[irowID]["ActivityID"] = lstResult[2];
                        dtMeterialReq.Rows[irowID]["ActivityName"] = lstResult[3];
                    }
                }
                else if ((vDG_Cell.Column.SortMemberPath == "MatOption_Count") && !bSemiFinished)
                {
                    frm_RawMeterial_SemiFinished frmSubstitute = dtMeterialReq.Rows[irowID].Field<frm_RawMeterial_SemiFinished>("Substitute_RawMeterials");
                    if (frmSubstitute != null)
                    {
                        if (SEACC_Form.enmFormName == FormName.Prod_BOMDetails_Production_SpecialPermission)
                            frmSubstitute.btnGridItemDelete.Visibility = Visibility.Hidden;

                        frmSubstitute.sSection_ID = dtMeterialReq.Rows[irowID].Field<string>("SectionID");
                        frmSubstitute.sSection_Name = dtMeterialReq.Rows[irowID].Field<string>("SectionName");
                        frmSubstitute.sActivity_ID = dtMeterialReq.Rows[irowID].Field<string>("ActivityID");
                        frmSubstitute.sActivity_Name = dtMeterialReq.Rows[irowID].Field<string>("ActivityName");
                        int iSubstituteMats = frmSubstitute.ShowDialogBox();
                        dtMeterialReq.Rows[irowID]["MatOption_Count"] = iSubstituteMats == 0 ? "1 Option" : (iSubstituteMats + 1) + " Options";
                    }
                }
            }
            catch (Exception)
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
                            string sInActiviyt_ID = (dtWIP_Flow.Rows[irowID].Field<string>("InActivity_ID"));
                            string sOutSect_ID = (dtWIP_Flow.Rows[irowID].Field<string>("OutSection_ID"));
                            string sOutActivity_ID = (dtWIP_Flow.Rows[irowID].Field<string>("OutActivity_ID"));


                            if (sInSect_ID != "default" && sOutSect_ID != "default")
                            {
                                if (sInActiviyt_ID != "default" && sOutActivity_ID != "default")
                                {
                                    List<cls_BoMDetailMaterial> lstMatList = dtWIP_Flow.Rows[irowID].Field<List<cls_BoMDetailMaterial>>("Materials");

                                    DataTable dtMats = new DataTable();
                                    var vMatRows = dtMeterialReq.Select("SectionID = '" + sOutSect_ID + "' AND ActivityID = '" + sOutActivity_ID + "' ");
                                    if (vMatRows != null && vMatRows.Count() > 0)
                                        dtMats = vMatRows.AsEnumerable().CopyToDataTable();

                                    DataTable dtRelavant_WIP_flowSemis = new DataTable();
                                    var vRelavant_WIP_FlowSemis = dtWIP_Flow.Select("InSection_ID = '" + sOutSect_ID + "' AND InActivity_ID = '" + sOutActivity_ID + "' AND LineNo <> '" + sItem_WIP_Semi_LineNo + "' ");
                                    if (vRelavant_WIP_FlowSemis != null && vRelavant_WIP_FlowSemis.Count() > 0)
                                        dtRelavant_WIP_flowSemis = vRelavant_WIP_FlowSemis.AsEnumerable().CopyToDataTable();

                                    frm_MaterialSelection frmSemi = new frm_MaterialSelection();
                                    lstMatList = frmSemi.Show(dtMats, dtRelavant_WIP_flowSemis, lstMatList);

                                    dtWIP_Flow.Rows[irowID]["Material_Count"] = lstMatList.Count == 1 ? lstMatList.Count + " Material" : lstMatList.Count + " Materials";
                                    dtWIP_Flow.Rows[irowID]["Materials"] = lstMatList;
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Activity selection is incompleted.", "Please select WIP Semi Finished In and Out Activities correctly", MessageBoxButton.OK, "Red");
                                }
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
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
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
                else if (vDG_Cell.Column.SortMemberPath == "InActivity_Name")
                {
                    try
                    {
                        string sSection_ID = dtWIP_Flow.Rows[irowID]["InSection_ID"].ToString();
                        List<string> lstParameeters = new List<string>();
                        if (sSection_ID != "default" && sSection_ID != "")
                            lstParameeters.Add(sSection_ID);

                        frm_search RowDataSearch = new frm_search(lstParameeters);
                        RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                        RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSectionActivities);
                        if (RowDataSearch.DialogResult == true)
                        {
                            dtWIP_Flow.Rows[irowID]["InActivity_ID"] = lstResult[2];
                            dtWIP_Flow.Rows[irowID]["InActivity_Name"] = lstResult[3];
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
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProcductionSections);
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
                else if (vDG_Cell.Column.SortMemberPath == "OutActivity_Name")
                {
                    try
                    {
                        string sSection_ID = dtWIP_Flow.Rows[irowID]["OutSection_ID"].ToString();
                        List<string> lstParameeters = new List<string>();
                        if (sSection_ID != "default" && sSection_ID != "")
                            lstParameeters.Add(sSection_ID);

                        frm_search RowDataSearch = new frm_search(lstParameeters);
                        RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
                        RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
                        List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionSectionActivities);
                        if (RowDataSearch.DialogResult == true)
                        {
                            dtWIP_Flow.Rows[irowID]["OutActivity_ID"] = lstResult[2];
                            dtWIP_Flow.Rows[irowID]["OutActivity_Name"] = lstResult[3];
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
                            tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.SelectAllByItem_ID_FG(oItem.Item_ID).FirstOrDefault();
                            if (oProdJob != null)
                            {
                                foreach (tbl_prod_pharmaTxJobCard_Material oProJobMaterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oProdJob.ProdJob_ID))
                                {
                                    frm_RawMeterial_SemiFinished frmSubstituteMats_SemiFG = new frm_RawMeterial_SemiFinished("Substituting Meterial List ", true);

                                    foreach (tbl_prod_pharmaTxJobCard_Material oSubstituteJobMat in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(oProJobMaterial.ProdJob_ID).Where(r => r.Line_No == oProJobMaterial.Line_No && r.Line_No_Sub1 == oProJobMaterial.Line_No_Sub1 && r.Line_No_Sub2 != 0))
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
                                        "default", "-",
                                        cls_Formater.FormatDecimal(oProJobMaterial.Smv_TimeMinutes, 2),
                                        cls_Formater.FormatDecimal(oProJobMaterial.TotalLabour, 2), 
                                        frmSubstituteMats_SemiFG, sSubstituteItemCount_ForSemi);
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
                            "default",
                            "<Select Activity>",
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
                        "default", "<Select Section>",
                        "default", "<Select Activity>",
                        "default", "<Select Section>",
                        "default", "<Select Activity>",
                        "0 Materials", new List<cls_BoMDetailMaterial>());
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
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
            if (SEACC_Form.enmFormName == FormName.ProdPharma_BOMDetails_SpecialPermission)
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOM_Finance(txtProdJobID.Tag.ToString(), FormName.ProdPharma_BOMCosting_SpecialPermission);
                else
                    UC = new UC_BOM_Finance(FormName.ProdPharma_BOMCosting_SpecialPermission);
            }
            else
            {
                if (txtProdJobID.Tag != null)
                    UC = new UC_BOM_Finance(txtProdJobID.Tag.ToString(), FormName.ProdPharma_BOMCosting_Finance);
                else
                    UC = new UC_BOM_Finance(FormName.ProdPharma_BOMCosting_Finance);
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

        #endregion
    }
}
