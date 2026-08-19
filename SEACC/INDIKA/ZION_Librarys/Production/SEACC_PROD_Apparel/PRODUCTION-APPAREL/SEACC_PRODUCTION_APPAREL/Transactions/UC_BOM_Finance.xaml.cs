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
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace SEACC_PRODUCTION_APPAREL.Transactions
{
    /// <summary>
    /// Initial Developed by Gayan
    /// on 2017-05-08
    /// </summary>

    /* <2018-07-26 - Janith>
     * 1 - Ordered Qty, Stores Qty column remove from main grid
     * 2 - Add Modified User details and date and time to main grid
     * 3 - Add prepared, approved date and time
     * */

    public partial class UC_BOM_Finance : UserControl
    {
        #region Class Variables
        DataTable dtRawMeterialCost = new DataTable();
        DataTable dtSemiFinishedCost = new DataTable();
        DataTable dtOH_LabourCost_SectionActivities = new DataTable();
        DataTable dtOH_Labour_CostSMV = new DataTable();
        DataTable dtCostFooter = new DataTable();
        BrushConverter bc = new BrushConverter();
        private bool bIsSpecialPermission_EditBoM = false;

        #region Footer Variables
        string sRawMaterialCost_ID = "",
            sSemiFinished_Cost_ID = "",
            sLabourCost_ID = "",
            sProduction_OH_cost_ID = "",
            sOtherCost_ID = "",
            sTotalPrimeCost_ID = "",
            sMarkUp_ID = "",
            sMargin_ID = "",
            sSellingPriceBeforeOtherCost_ID = "",
            sOtherEmbellishmentCost_ID = "",
            sSemiFinished_OutsourceCost_ID = "",
            sOtherCost2_ID = "",
            sTransportCost_ID = "",
            sSellingPriceBeforeTaxes_ID = "",
            sNBT_ID = "",
            sSellingPriceWithNBT_ID = "",
            sVAT_ID = "",
            sSellingPriceWithTax_ID = "";
        #endregion


        #endregion

        #region Form Load
        public UC_BOM_Finance(FormName enmForm)
        {
            AppDomainInitializer(enmForm);
        }

        public UC_BOM_Finance(string sBoM_ID, FormName enmForm)
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

            #region Initialize Raw Meterial Item Table
            dtRawMeterialCost.Columns.Add("LineNo");
            dtRawMeterialCost.Columns.Add("LineNoMain");
            dtRawMeterialCost.Columns.Add("LineNoSub1");
            dtRawMeterialCost.Columns.Add("LineNoSub2");
            dtRawMeterialCost.Columns.Add("InputItemID");
            dtRawMeterialCost.Columns.Add("InputItemName");
            dtRawMeterialCost.Columns.Add("UoM");
            dtRawMeterialCost.Columns.Add("Qty");
            dtRawMeterialCost.Columns.Add("Consumption");
            dtRawMeterialCost.Columns.Add("WeiAvg");
            dtRawMeterialCost.Columns.Add("Lowest");
            dtRawMeterialCost.Columns.Add("Highest");
            dtRawMeterialCost.Columns.Add("BoMCost");
            dtRawMeterialCost.Columns.Add("CostSelection", typeof(int));
            dtRawMeterialCost.Columns.Add("Cost");
            dtRawMeterialCost.Columns.Add("Cost_Edit");
            dtRawMeterialCost.Columns.Add("AccCost");
            dtRawMeterialCost.Columns.Add("IsSemiFinished");
            dtRawMeterialCost.Columns.Add("SubstitueGroup");
            #endregion

            #region Initialize Semi Finished Item Table
            dtSemiFinishedCost.Columns.Add("LineNo");
            dtSemiFinishedCost.Columns.Add("LineNoMain");
            dtSemiFinishedCost.Columns.Add("LineNoSub1");
            dtSemiFinishedCost.Columns.Add("LineNoSub2");
            dtSemiFinishedCost.Columns.Add("InputItemID");
            dtSemiFinishedCost.Columns.Add("InputItemName");
            dtSemiFinishedCost.Columns.Add("UoM");
            dtSemiFinishedCost.Columns.Add("Qty");
            dtSemiFinishedCost.Columns.Add("Consumption");
            dtSemiFinishedCost.Columns.Add("WeiAvg");
            dtSemiFinishedCost.Columns.Add("Lowest");
            dtSemiFinishedCost.Columns.Add("Highest");
            dtSemiFinishedCost.Columns.Add("CostSelection", typeof(int));
            dtSemiFinishedCost.Columns.Add("Cost");
            dtSemiFinishedCost.Columns.Add("Cost_Edit");
            dtSemiFinishedCost.Columns.Add("AccCost");
            dtSemiFinishedCost.Columns.Add("IsSemiFinished");
            dtSemiFinishedCost.Columns.Add("OutsourceRate");
            dtSemiFinishedCost.Columns.Add("OutsourceCost");
            dtSemiFinishedCost.Columns.Add("LabourSMV_Cost");
            dtSemiFinishedCost.Columns.Add("OverheadSMV_Cost");
            #endregion

            #region Initialize Data Labour and OH Cost Table - With Section Activities
            dtOH_LabourCost_SectionActivities.Columns.Add("LineNo");
            dtOH_LabourCost_SectionActivities.Columns.Add("Section_ID");
            dtOH_LabourCost_SectionActivities.Columns.Add("Section");
            dtOH_LabourCost_SectionActivities.Columns.Add("SectionActivity_ID");
            dtOH_LabourCost_SectionActivities.Columns.Add("SectionActivity");
            dtOH_LabourCost_SectionActivities.Columns.Add("DayShift");
            dtOH_LabourCost_SectionActivities.Columns.Add("HrsDayShift");
            dtOH_LabourCost_SectionActivities.Columns.Add("LaboursDay");
            dtOH_LabourCost_SectionActivities.Columns.Add("LabourRateDay");
            dtOH_LabourCost_SectionActivities.Columns.Add("NightShift");
            dtOH_LabourCost_SectionActivities.Columns.Add("HrsNightShift");
            dtOH_LabourCost_SectionActivities.Columns.Add("LaboursNight");
            dtOH_LabourCost_SectionActivities.Columns.Add("LabourRateNight");
            dtOH_LabourCost_SectionActivities.Columns.Add("ProdHrs");
            dtOH_LabourCost_SectionActivities.Columns.Add("OHRate");
            dtOH_LabourCost_SectionActivities.Columns.Add("OtherRate");
            dtOH_LabourCost_SectionActivities.Columns.Add("Total");
            dtOH_LabourCost_SectionActivities.Columns.Add("AccumTotal");
            #endregion

            #region Initialize Data Labour and OH Cost Table - With Section SMV
            dtOH_Labour_CostSMV.Columns.Add("LineNo");
            dtOH_Labour_CostSMV.Columns.Add("CostCenterID");
            dtOH_Labour_CostSMV.Columns.Add("CostCenterName");
            dtOH_Labour_CostSMV.Columns.Add("SMV");
            dtOH_Labour_CostSMV.Columns.Add("SMV_Rate");
            dtOH_Labour_CostSMV.Columns.Add("Cost");
            #endregion

            #region Initialize Cost -Footer
            dtCostFooter.Columns.Add("LineNo");
            dtCostFooter.Columns.Add("FooterID");
            dtCostFooter.Columns.Add("FooterName");
            dtCostFooter.Columns.Add("Percentage");
            dtCostFooter.Columns.Add("Cost");
            #endregion

            #region Initialize Data Main Table
            dgr_Main.dt.Columns.Add("LN");
            dgr_Main.dt.Columns.Add("JOBNO");
            dgr_Main.dt.Columns.Add("JOB_DATE");
            dgr_Main.dt.Columns.Add("ITEM");
            dgr_Main.dt.Columns.Add("CUSTOMER");
            dgr_Main.dt.Columns.Add("PREPARED_BY");
            dgr_Main.dt.Columns.Add("PREPARED_DATE");
            dgr_Main.dt.Columns.Add("MODIFIED_BY");
            dgr_Main.dt.Columns.Add("MODIFIED_DATE");
            dgr_Main.dt.Columns.Add("APPROVED3_BY");
            dgr_Main.dt.Columns.Add("APPROVED3_DATE");
            dgr_Main.dt.Columns.Add("LOCKED_BY");
            dgr_Main.dt.Columns.Add("LOCKED_DATE");
            dgr_Main.dt.Columns.Add("IS_CANCELLED");
            #endregion

            #region Initialize Action Buttons
            if (SEACC_Form.enmFormName == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
            {
                SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, true);
                SEACC_Form.btn_Checked.Content = "Locked";
                SEACC_Form.btn_New.Click += btn_New_Click;
                SEACC_Form.btn_Save.Click += btn_Save_Click;
                //SEACC_Form.btn_Print.Click += btn_Print_Click;
                //SEACC_Form.btn_Checked.Click += btn_Lock_Click;
                //SEACC_Form.btn_Approved.Click += btn_Approved_click;
                SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            }
            else
            {
                SEACC_Form.SetVisibility_ActionButons(true, true, true, true, true, true);
                SEACC_Form.btn_Checked.Content = "Locked";
                SEACC_Form.btn_New.Click += btn_New_Click;
                SEACC_Form.btn_Save.Click += btn_Save_Click;
                SEACC_Form.btn_Print.Click += btn_Print_Click;
                SEACC_Form.btn_Checked.Click += btn_Lock_Click;
                SEACC_Form.btn_Approved.Click += btn_Approved_click;
                SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            }
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LN", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job#", "JOBNO", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JOB_DATE", 80);
            dgr_Main.Add_DatagridColoumn("FG Item", "ITEM", 100);
            dgr_Main.Add_DatagridColoumn("Customer", "CUSTOMER", 100);
            dgr_Main.Add_DatagridColoumn("Prepared By", "PREPARED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Prepared Date", "PREPARED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Modified By", "MODIFIED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Modified Date", "MODIFIED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Approved By", "APPROVED3_BY", 100);
            dgr_Main.Add_DatagridColoumn("Approved Date", "APPROVED3_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Locked By", "LOCKED_BY", 100);
            dgr_Main.Add_DatagridColoumn("Locked Date", "LOCKED_DATE", 100);
            dgr_Main.Add_DatagridColoumn("Is Cancelled", "IS_CANCELLED", 100, false);
            dgr_Main.RefreshGrid();
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
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if ((!oJob.IsApproved3 && !oJob.IsLocked) || bIsSpecialPermission_EditBoM)
                                {
                                    int iBoM_Status = 0;
                                    if (oJob.ProdJobStatus < (int)prod_BoM_Status.BoMFin)
                                        iBoM_Status = (int)prod_BoM_Status.BoMFin;
                                    else
                                        iBoM_Status = oJob.ProdJobStatus;

                                    #region Production BoM / Job Header
                                    tbl_prodTxJobCard oOldJob = new tbl_prodTxJobCard(
                                                                oJob.ProdJob_ID, dtpProdJob_Date.GetDateTime(), iBoM_Status,  //cmbProdJobStatus.GetSelectedIndex(),
                                                                oJob.Salesman_ID,
                                                                oJob.Customer_ID,
                                                                txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                                                txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                                                txtComments.Text,
                                                                oJob.Remarks2,
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
                                                                oJob.CanceledUserTerminal_ID, oJob.LockedUserTerminal_ID, oJob.CompanyID, oJob.CompanyBranchID, oJob.CustomerOrder_Qty);
                                    oOldJob.Update();
                                    #endregion

                                    #region Raw Material Table
                                    foreach (DataRow row in dtRawMeterialCost.Rows)
                                    {
                                        int iLineNoMain = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoMain", 0));
                                        int iLineNoSub1 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub1", 0));
                                        int iLineNoSub2 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub2", 0));
                                        decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                        decimal dConsumption = clsValidate.ValidateRowValue(row, "Consumption", 0m);
                                        decimal dWeiAvg = clsValidate.ValidateRowValue(row, "WeiAvg", 0m);
                                        decimal dLowest = clsValidate.ValidateRowValue(row, "Lowest", 0m);
                                        decimal dHighest = clsValidate.ValidateRowValue(row, "Highest", 0m);
                                        decimal dBoMCost = clsValidate.ValidateRowValue(row, "BoMCost", 0m);
                                        int iCostSelection = Convert.ToInt32(clsValidate.ValidateRowValue(row, "CostSelection", 0));
                                        decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0m);
                                        decimal dCost_Edit = clsValidate.ValidateRowValue(row, "Cost_Edit", 0m);

                                        tbl_prodTxJobCard_Material oMeterial = tbl_prodTxJobCard_Material.Select(iLineNoMain, iLineNoSub1, iLineNoSub2, oOldJob.ProdJob_ID);
                                        if (oMeterial != null)
                                        {
                                            oMeterial.TotalInputQty = dQty;
                                            oMeterial.Consumption = dConsumption;
                                            oMeterial.WeightedAvgCost = dWeiAvg;
                                            oMeterial.LowestCost = dLowest;
                                            oMeterial.HighestCost = dHighest;
                                            oMeterial.BomCost = dBoMCost;
                                            oMeterial.CostTypeSelection = iCostSelection;
                                            oMeterial.Cost = dCost;
                                            oMeterial.EditedCost = dCost_Edit;
                                            oMeterial.Update();
                                        }
                                    }
                                    #endregion

                                    #region Semi Finished Item Table
                                    foreach (DataRow row in dtSemiFinishedCost.Rows)
                                    {
                                        int iLineNoMain = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoMain", 0));
                                        int iLineNoSub1 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub1", 0));
                                        int iLineNoSub2 = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNoSub2", 0));
                                        decimal dQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                        decimal dConsumption = clsValidate.ValidateRowValue(row, "Consumption", 0m);
                                        decimal dWeiAvg = clsValidate.ValidateRowValue(row, "WeiAvg", 0m);
                                        decimal dLowest = clsValidate.ValidateRowValue(row, "Lowest", 0m);
                                        decimal dHighest = clsValidate.ValidateRowValue(row, "Highest", 0m);
                                        int iCostSelection = Convert.ToInt32(clsValidate.ValidateRowValue(row, "CostSelection", 0m));
                                        decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0m);
                                        decimal dCost_Edit = clsValidate.ValidateRowValue(row, "Cost_Edit", 0m);
                                        decimal dOutsourceRate = clsValidate.ValidateRowValue(row, "OutsourceRate", 0m);
                                        decimal dOutsourceCost = clsValidate.ValidateRowValue(row, "OutsourceCost", 0m);

                                        tbl_prodTxJobCard_Material oMeterial = tbl_prodTxJobCard_Material.Select(iLineNoMain, iLineNoSub1, iLineNoSub2, oOldJob.ProdJob_ID);
                                        if (oMeterial != null)
                                        {
                                            oMeterial.TotalInputQty = dQty;
                                            oMeterial.Consumption = dConsumption;
                                            oMeterial.WeightedAvgCost = dWeiAvg;
                                            oMeterial.LowestCost = dLowest;
                                            oMeterial.HighestCost = dHighest;
                                            oMeterial.CostTypeSelection = iCostSelection;
                                            oMeterial.Cost = dCost;
                                            oMeterial.EditedCost = dCost_Edit;
                                            oMeterial.Update();

                                            tbl_prodTxJobCard_Material_Outsource oOld_SF_Outsource = tbl_prodTxJobCard_Material_Outsource.Select(oMeterial.Line_No, oMeterial.Line_No_Sub1, oMeterial.Line_No_Sub2, oMeterial.ProdJob_ID);
                                            if (oOld_SF_Outsource != null)
                                            {
                                                tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oMeterial.Line_No, oMeterial.Line_No_Sub1, oMeterial.Line_No_Sub2, oMeterial.ProdJob_ID, oMeterial.Item_ID, oMeterial.Uom_ID, oMeterial.Consumption, dOutsourceRate, dOutsourceCost);
                                                oSF_Outsource.Update();
                                            }
                                            else
                                            {
                                                tbl_prodTxJobCard_Material_Outsource oSF_Outsource = new tbl_prodTxJobCard_Material_Outsource(oMeterial.Line_No, oMeterial.Line_No_Sub1, oMeterial.Line_No_Sub2, oMeterial.ProdJob_ID, oMeterial.Item_ID, oMeterial.Uom_ID, oMeterial.Consumption, dOutsourceRate, dOutsourceCost);
                                                oSF_Outsource.Insert();
                                            }
                                        }
                                    }
                                    #endregion

                                    #region Labour Cost Activity Wise Table
                                    tbl_prodTxJobCard_Labour.DeleteAllByProdJob_ID(oOldJob.ProdJob_ID);
                                    clsHelpMethods_Prod.OrderBy_DataGrid(dtOH_LabourCost_SectionActivities);
                                    foreach (DataRow row in dtOH_LabourCost_SectionActivities.Rows)
                                    {
                                        int iLineNo = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sSection_ID = clsValidate.ValidateRowValue(row, "Section_ID", "default");
                                        string sSectionActivity_ID = clsValidate.ValidateRowValue(row, "SectionActivity_ID", "default");
                                        decimal dDayShift = clsValidate.ValidateRowValue(row, "DayShift", 0m);
                                        decimal dHrsDayShift = clsValidate.ValidateRowValue(row, "HrsDayShift", 0m);
                                        decimal dLaboursDay = clsValidate.ValidateRowValue(row, "LaboursDay", 0m);
                                        decimal dLabourRatePerHour_Day = clsValidate.ValidateRowValue(row, "LabourRateDay", 0m);
                                        decimal dNightShift = clsValidate.ValidateRowValue(row, "NightShift", 0m);
                                        decimal dHrsNightShift = clsValidate.ValidateRowValue(row, "HrsNightShift", 0m);
                                        decimal dLaboursNight = clsValidate.ValidateRowValue(row, "LaboursNight", 0m);
                                        decimal dLabourRatePerHour_Night = clsValidate.ValidateRowValue(row, "LabourRateNight", 0m);
                                        decimal dProdHrs = clsValidate.ValidateRowValue(row, "ProdHrs", 0m);
                                        decimal dOHRate = clsValidate.ValidateRowValue(row, "OHRate", 0m);
                                        decimal dOtherRate = clsValidate.ValidateRowValue(row, "OtherRate", 0m);
                                        decimal dTotal_Cost = clsValidate.ValidateRowValue(row, "Total", 0m);

                                        tbl_prodTxJobCard_Labour oProdJob_Labour = new tbl_prodTxJobCard_Labour(
                                            iLineNo, oOldJob.ProdJob_ID, sSection_ID, sSectionActivity_ID, dDayShift, (dHrsDayShift * 60), dLaboursDay, dLabourRatePerHour_Day,
                                            dNightShift, (dHrsNightShift * 60), dLaboursNight, dLabourRatePerHour_Night, dOHRate, dOtherRate, (dProdHrs * 60), dTotal_Cost);
                                        oProdJob_Labour.Insert();
                                    }
                                    #endregion

                                    #region Labour Cost SMV Table
                                    foreach (DataRow row in dtOH_Labour_CostSMV.Rows)
                                    {
                                        int iLineNo = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sCostCenterID = clsValidate.ValidateRowValue(row, "CostCenterID", "default");
                                        decimal dSMV = clsValidate.ValidateRowValue(row, "SMV", 0m);
                                        decimal dSMV_Rate = clsValidate.ValidateRowValue(row, "SMV_Rate", 0m);
                                        decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0m);

                                        tbl_prodTxJobCard_CostCenter oCostCenter = tbl_prodTxJobCard_CostCenter.Select(iLineNo, txtProdJobID.Text);
                                        if (oCostCenter != null)
                                        {
                                            oCostCenter.Smv = dSMV;
                                            oCostCenter.Smv_rate = dSMV_Rate;
                                            oCostCenter.Cost = dCost;
                                            oCostCenter.Update();
                                        }
                                    }
                                    #endregion

                                    #region Cost Footer
                                    tbl_prodTxJobCard_CostFooter.DeleteAllByProdJob_ID(oJob.ProdJob_ID);
                                    foreach (DataRow row in dtCostFooter.Rows)
                                    {
                                        int iLineNo = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        string sFooterID = clsValidate.ValidateRowValue(row, "FooterID", "default");
                                        string sPercentage = clsValidate.ValidateRowValue(row, "Percentage", "0.00%").Replace("%", "");
                                        decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0m);

                                        tbl_prodTxJobCard_CostFooter oProd_Footer = new tbl_prodTxJobCard_CostFooter(iLineNo, oJob.ProdJob_ID, sFooterID, clsValidation.Validate_DecimalNumber(sPercentage), dCost);
                                        oProd_Footer.Insert();
                                    }
                                    #endregion

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);

                                }
                                else
                                {
                                    if (SEACC_Form.enmFormName != FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
                                        SEACCMessageBox.Show("Cannot Update..", "Selected BoM has already been approved or locked", MessageBoxButton.OK, "Red");
                                }
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            //Insert
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
                    RefreshGrid();
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

        private void btn_Lock_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.CheckPermission_ToChecked())
                {
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (oJob.IsApproved3)
                                {
                                    if (!oJob.IsLocked)
                                    {
                                        if (clsHelpMethods_Prod.IsJobType_MakeToOder(oJob.JobType_ID) && (txtCustomerCOSO.Tag == null || txtCustomerCOSO.Tag.ToString() == "default"))
                                        {
                                            SEACCMessageBox.Show("Can not lock without a confirmed order !", "Please request Sales Team to enter the Customer Order# in the BoM...!", MessageBoxButton.OK, "Red");
                                        }
                                        else
                                        {
                                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Locked_Confirmation);
                                            if (bMessegeBoxResult)
                                            {
                                                frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                                frmTwoStepVerify.ShowDialog();
                                                if (frmTwoStepVerify.bVerified)
                                                {
                                                    oJob.ProdJobStatus = (int)prod_BoM_Status.WIP;
                                                    oJob.IsLocked = true;
                                                    oJob.DateLocked = clsSecurity.getServerDateTime();
                                                    oJob.LockedUser_ID = clsSecurity.UserIDLoged;
                                                    oJob.LockedUserTerminal_ID = clsSecurity.TerminalID;
                                                    oJob.Update();
                                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Locked);
                                                }
                                                frmTwoStepVerify.Close();
                                            }
                                        }

                                        ClearFields();
                                        RefreshGrid();
                                        FillDetails(oJob.ProdJob_ID);
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show("Alreay Locked", "Selected BoM has already been locked", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Not Approved", "Selected BoM hasn't been approved", MessageBoxButton.OK, "Red");
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
                            tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oBoM != null)
                            {
                                if (oBoM.IsApproved2)
                                {
                                    if (!oBoM.IsApproved3)//Financial Approve
                                    {
                                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                        if (bMessegeBoxResult)
                                        {
                                            frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                            frmTwoStepVerify.ShowDialog();
                                            if (frmTwoStepVerify.bVerified)
                                            {
                                                oBoM.IsApproved3 = true;
                                                oBoM.DateApproved3 = clsSecurity.getServerDateTime();
                                                oBoM.Approved3User_ID = clsSecurity.UserIDLoged;
                                                oBoM.Approved3UserTerminal_ID = clsSecurity.TerminalID;
                                                oBoM.Update();
                                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Approved);
                                            }
                                            frmTwoStepVerify.Close();
                                        }
                                        ClearFields();
                                        RefreshGrid();
                                        FillDetails(oBoM.ProdJob_ID);
                                    }
                                    else
                                    {
                                        SEACCMessageBox.Show("Alreay Approved", "Selected BoM has already been approved", MessageBoxButton.OK, "Red");
                                    }
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Not Approved from Production Team", "Selected BoM hasn't been approved by production team", MessageBoxButton.OK, "Red");
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
                            tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (!oJob.IsApproved3)
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

        private void btnUpdateCosting_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.IsUpdateMode == true && txtProdJobID.Tag != null)
            {
                tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(txtProdJobID.Tag.ToString());
                if (oBoM != null)
                {
                    if ((!oBoM.IsApproved3 && !oBoM.IsLocked) || (SEACC_Form.enmFormName == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission))
                    {
                        try
                        {
                            string sQuary = " exec sp_update_material_cost '" + oBoM.ProdJob_ID + "'";
                            DBHandling.ExecQuery(sQuary);
                        }
                        catch (Exception ex)
                        {
                            SEACCExeption.Show(ex);
                        }
                        finally
                        {
                            FillDetails(oBoM.ProdJob_ID);
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Alreay Approved", "Selected BoM has already been approved and you can not change its costing details", MessageBoxButton.OK, "Red");
                    }
                }
            }
        }

        #region OH and Labour Cost Section Activity Grid Buttons
        private void btnAddActivity_Click(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductionSectionActivities);
            if (RowDataSearch.DialogResult == true)
            {
                bool bAddItem = false;
                DataRow[] items = dtOH_LabourCost_SectionActivities.Select("SectionActivity_ID ='" + lstResult[2] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Activity Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    tbl_prodMasSectionActivity oSecActivity = tbl_prodMasSectionActivity.Select(lstResult[2]);
                    if (oSecActivity != null)
                        dtOH_LabourCost_SectionActivities.Rows.Add("",
                            lstResult[0],
                            lstResult[1],
                            lstResult[2],
                            lstResult[3],
                            cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // No of DayShifts
                            cls_Formater.FormatDecimal(oSecActivity.ShiftMinutes_Day / 60, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // Hrs per Day Shift
                            cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // No of Labours in Day
                            cls_Formater.FormatDecimal(oSecActivity.LabourRatePerHour_Day, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // Labour Rate Per Hour for Day
                            cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // No of NightShifts
                            cls_Formater.FormatDecimal(oSecActivity.ShiftMinutes_Night / 60, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // Hrs per Night Shift
                            cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // No of Labours in Night
                            cls_Formater.FormatDecimal(oSecActivity.LabourRatePerHour_Night, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // Labour Rate Per Hour for Night
                            "0", //ProdHrs
                            cls_Formater.FormatDecimal(oSecActivity.OHRatePerHour, clsConfig.sCurrencyDecimalPlaces_UnitPrice), //OH Rate
                            cls_Formater.FormatDecimal(oSecActivity.OtherCostRatePerHour, clsConfig.sCurrencyDecimalPlaces_UnitPrice), //Other Rate
                            "0", //Total
                            "0"  //AccumTotal
                            );
                }
            }
            CaculateAccumilatedCost_OHLabour_SectionActivities();
        }


        private void btnActivityDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_OH_LabourCost_SectionActivities.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_OH_LabourCost_SectionActivities.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtOH_LabourCost_SectionActivities.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtOH_LabourCost_SectionActivities.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtOH_LabourCost_SectionActivities);
            }
            CaculateAccumilatedCost_OHLabour_SectionActivities();
        }
        #endregion

        #region OH and Labour Cost Section SMV Grid Buttons
        private void btnAddSection_Click(object sender, RoutedEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProcductionSections);
            if (RowDataSearch.DialogResult == true)
            {
                bool bAddItem = false;
                DataRow[] items = dtOH_Labour_CostSMV.Select("Section_ID ='" + lstResult[0] + "'");
                if (items.Length == 0)
                    bAddItem = true;
                else
                {
                    string sLineNo = items[0]["LineNo"].ToString();
                    if (SEACCMessageBox.Show("Section Already Exist in Line No: " + sLineNo, "Do you need to add it again? ", MessageBoxButton.YesNo, "Red"))
                        bAddItem = true;
                }

                if (bAddItem)
                {
                    dtOH_Labour_CostSMV.Rows.Add("",
                        lstResult[0],
                        lstResult[1],
                        cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // SMV
                        cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice), // SMV_Rate
                        "0", //Cost
                        "0"  //AccumCost
                        );
                }
            }
            CaculateAccumilatedCost_OHLabour_SMV();
        }

        private void btnSectionDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_OH_LabourCost_SMV.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_OH_LabourCost_SMV.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtOH_Labour_CostSMV.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtOH_Labour_CostSMV.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtOH_Labour_CostSMV);
            }
            CaculateAccumilatedCost_OHLabour_SMV();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtInv1, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtInv2, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtInv3, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesCode, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodEstWastage, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishedGoodPlannedQty, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtReEditComments, true, false, true);

            #region Collaped in UI
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM1, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM2, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM3, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoM4, false, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty1, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty2, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty3, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtFGQty4, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage1, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage2, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage3, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtEstWastage4, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty1, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty2, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty3, false, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtPlannedQty4, false, true, false);
            #endregion

            txtProdJobID.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFinishGoodDescription.Tag = null;
            txtFinishGoodSalesCode.Tag = null;
            txtFinishGoodSalesName.Tag = null;
            txtFinishGoodUOM.Tag = null;
            #region Collaped in UI
            txtInv1.Tag = null;
            txtInv2.Tag = null;
            txtInv3.Tag = null;
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

            txtCustomer.Uid = "";
            txtFinishGoodSalesName.ToolTip = null;

            txtProdJobID.Text = "";
            txtCustomer.Text = "";
            txtCustomerInquiry.Text = "";
            txtCustomerCOSO.Text = "";
            txtComments.Text = "";
            txtReEditComments.Text = "";
            txtFinishGoodDescription.Text = "";
            txtFinishGoodSalesCode.Text = "";
            txtFinishGoodSalesName.Text = "";
            txtFinishGoodUOM.Text = "";
            txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity); //"0.000"; 
            txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity); //"0.000"; 
            txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity); //"0.000"; 
            #region Collapsed in UI
            txtInv1.Text = "";
            txtInv2.Text = "";
            txtInv3.Text = "";
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

            dtRawMeterialCost.Clear();
            //dgr_RawMeterialCost.ItemsSource = dtRawMeterialCost.DefaultView;
            CollectionViewSource mycollection = new CollectionViewSource();
            mycollection.Source = dtRawMeterialCost;
            mycollection.GroupDescriptions.Add(new PropertyGroupDescription("SubstitueGroup"));
            dgr_RawMeterialCost.ItemsSource = mycollection.View;


            dtSemiFinishedCost.Clear();
            dgr_SemiFinishedCost.ItemsSource = dtSemiFinishedCost.DefaultView;

            dtOH_LabourCost_SectionActivities.Clear();
            dgr_OH_LabourCost_SectionActivities.ItemsSource = dtOH_LabourCost_SectionActivities.DefaultView;

            dtOH_Labour_CostSMV.Clear();
            dgr_OH_LabourCost_SMV.ItemsSource = dtOH_Labour_CostSMV.DefaultView;

            Fill_GridFooter();
            ClearUnWantedDataInFooterGrid();

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(prod_BoM_Status));
            cmbProdJobStatus.SetSelectedIndex((int)prod_BoM_Status.BoMFin);

            if (SEACC_Form.enmFormName == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
                txtReEditComments.Visibility = Visibility.Visible;
            else
                txtReEditComments.Visibility = Visibility.Collapsed;

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

            sRawMaterialCost_ID = "PCF/001";
            sSemiFinished_Cost_ID = "PCF/018";
            sLabourCost_ID = "PCF/002";
            sProduction_OH_cost_ID = "PCF/003";
            sOtherCost_ID = "PCF/004";
            sTotalPrimeCost_ID = "PCF/005";
            sMarkUp_ID = "PCF/006";
            sMargin_ID = "PCF/007";
            sSellingPriceBeforeOtherCost_ID = "PCF/008";
            sOtherEmbellishmentCost_ID = "PCF/009";
            sSemiFinished_OutsourceCost_ID = "PCF/010";
            sOtherCost2_ID = "PCF/011";
            sTransportCost_ID = "PCF/012";
            sSellingPriceBeforeTaxes_ID = "PCF/013";
            sNBT_ID = "PCF/014";
            sSellingPriceWithNBT_ID = "PCF/015";
            sVAT_ID = "PCF/016";
            sSellingPriceWithTax_ID = "PCF/017";
        }

        private void ClearUnWantedDataInFooterGrid()
        {
            SetValueTo_FooterTable(sRawMaterialCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sSemiFinished_Cost_ID, "Percentage", "");
            SetValueTo_FooterTable(sLabourCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sProduction_OH_cost_ID, "Percentage", "");
            SetValueTo_FooterTable(sOtherCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sTotalPrimeCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sMargin_ID, "Cost", "");
            SetValueTo_FooterTable(sSellingPriceBeforeOtherCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sOtherEmbellishmentCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sSemiFinished_OutsourceCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sOtherCost2_ID, "Percentage", "");
            SetValueTo_FooterTable(sTransportCost_ID, "Percentage", "");
            SetValueTo_FooterTable(sSellingPriceBeforeTaxes_ID, "Percentage", "");
            SetValueTo_FooterTable(sSellingPriceWithNBT_ID, "Percentage", "");
            SetValueTo_FooterTable(sSellingPriceWithTax_ID, "Percentage", "");
        }

        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                if (SEACC_Form.enmFormName == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
                    dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_BOMDetails_EditAfterApprove_finance").Tables[0]);
                else
                    dgr_Main.dt.Merge(DBHandling.ExecQuery("Exec sp_BOMDetails_finance").Tables[0]);

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
                    if (CheckPermissionEditAfterApprove())
                    {
                        if (clsValidate.CheckValidity_TransactionCodeLength(txtProdJobID.Text))
                        {
                            bStatus = true;
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
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodDescription))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodOrderedQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishedGoodPlannedQty))
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

        private bool CheckPermissionEditAfterApprove()
        {
            bool bStatus = true;
            if (SEACC_Form.enmFormName == FormName.Prod_Prod_BOMCosting_Finance_SpecialPermission)
            {
                if (!string.IsNullOrWhiteSpace(txtReEditComments.TextBox1.Text))
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure you want to edit this BOM?", MessageBoxButton.YesNo, "#FF5B6B76");
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

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                Cursor = Cursors.Wait;
                ClearFields();
                tbl_prodTxJobCard oJob = tbl_prodTxJobCard.Select(sID);
                if (oJob != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtFinishGoodDescription.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesCode.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oJob.Uom_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID);
                    txtFinishGoodSalesName.ToolTip = oJob.Item_ID_FG;

                    txtProdJobID.Text = oJob.ProdJob_ID;
                    txtCustomer.Text = txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID;
                    txtComments.Text = oJob.Remarks;
                    txtReEditComments.Text = oJob.Remarks2;
                    txtFinishGoodDescription.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesCode.Text = clsGenaralName.getCode_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodEstWastage.Text = cls_Formater.FormatDecimal(oJob.WastePercent, clsConfig.sDecimalPlaces_Quantity);
                    txtFinishedGoodPlannedQty.Text = cls_Formater.FormatDecimal(oJob.FGoodQty, clsConfig.sDecimalPlaces_Quantity);

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    if (oJob.IsApproved3)
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");
                    if (oJob.IsLocked)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    FillRawMaterialGrid(oJob.ProdJob_ID);
                    FillSemiFinishedGrid(oJob.ProdJob_ID);
                    Fill_OH_LabourGrid_SectionActivities(oJob.ProdJob_ID);
                    Fill_OH_LabourGrid_CostSMV(oJob.ProdJob_ID);
                    Fill_GridFooter_fromProdJob(oJob.ProdJob_ID);

                    Attachments.FillDetails(oJob.ProdJob_ID, false);
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

        private void FillRawMaterialGrid(string sProdJob_ID)
        {
            dtRawMeterialCost.Clear();
            string sItemGroup_Name = "";
            foreach (tbl_prodTxJobCard_Material oJob_Meterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r1 => !r1.IsSemiFinishItem).OrderBy(r2 => r2.Line_No).ThenBy(r3 => r3.Line_No_Sub1))
            {
                //Main Item
                tbl_prodTxJobCard_Material oSelectedMat = tbl_prodTxJobCard_Material.Select(oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, 0, oJob_Meterial.ProdJob_ID);
                if (oSelectedMat.IsSemiFinishItem)
                    continue;

                string sItemName = clsGenaralName.getName_Item(oJob_Meterial.Item_ID);
                string sUoMName = clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID);
                string sTotalInputQty = cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity);
                string sConsumption = cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity);
                string sdItemWAvgCost = cls_Formater.FormatDecimal(oJob_Meterial.WeightedAvgCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sLowestCost = cls_Formater.FormatDecimal(oJob_Meterial.LowestCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sHighestCost = cls_Formater.FormatDecimal(oJob_Meterial.HighestCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sBoMCost = cls_Formater.FormatDecimal(oJob_Meterial.BomCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sCost = cls_Formater.FormatDecimal(oJob_Meterial.Cost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sCost_Edited = cls_Formater.FormatDecimal(oJob_Meterial.EditedCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                //int iCostSeclection = !oJob_Meterial.IsSemiFinishItem ? oJob_Meterial.CostTypeSelection : -1;
                int iCostSeclection = oJob_Meterial.CostTypeSelection;

                if (oJob_Meterial.Line_No_Sub2 == 0)
                    sItemGroup_Name = sItemName + " - (" + oJob_Meterial.Line_No + ")"; ;

                dtRawMeterialCost.Rows.Add("0",
                                    oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.Line_No_Sub2,
                                    oJob_Meterial.Item_ID, sItemName, sUoMName,
                                    sTotalInputQty, sConsumption, sdItemWAvgCost, sLowestCost, sHighestCost, sBoMCost,
                                    iCostSeclection, "0", sCost_Edited, "0", oJob_Meterial.IsSemiFinishItem, sItemGroup_Name);

            }

            CollectionViewSource mycollection = new CollectionViewSource();
            mycollection.Source = dtRawMeterialCost;
            mycollection.GroupDescriptions.Add(new PropertyGroupDescription("SubstitueGroup"));
            dgr_RawMeterialCost.ItemsSource = mycollection.View;
        }

        private void FillSemiFinishedGrid(string sProdJob_ID)
        {
            dtSemiFinishedCost.Clear();
            foreach (tbl_prodTxJobCard_Material oJob_Meterial in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sProdJob_ID).Where(r => r.IsSemiFinishItem))//r.Item_ID != txtFinishGoodDescription.Tag.ToString() &&
            {
                string sItemName = clsGenaralName.getName_Item(oJob_Meterial.Item_ID);
                string sUoMName = clsGenaralName.getName_Uom(oJob_Meterial.Uom_ID);
                string sTotalInputQty = cls_Formater.FormatDecimal(oJob_Meterial.TotalInputQty, clsConfig.sDecimalPlaces_Quantity);
                string sConsumption = cls_Formater.FormatDecimal(oJob_Meterial.InputQty, clsConfig.sDecimalPlaces_Quantity);
                string sdItemWAvgCost = cls_Formater.FormatDecimal(oJob_Meterial.WeightedAvgCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sLowestCost = cls_Formater.FormatDecimal(oJob_Meterial.LowestCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sHighestCost = cls_Formater.FormatDecimal(oJob_Meterial.HighestCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sCost = cls_Formater.FormatDecimal(oJob_Meterial.Cost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sCost_Edited = cls_Formater.FormatDecimal(oJob_Meterial.EditedCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                int iCostSeclection = oJob_Meterial.CostTypeSelection;

                tbl_prodTxJobCard_Material_Outsource oSF_Outsource = tbl_prodTxJobCard_Material_Outsource.Select(oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.Line_No_Sub2, oJob_Meterial.ProdJob_ID);
                string sSF_OutsourceRate = cls_Formater.FormatDecimal(oSF_Outsource != null ? oSF_Outsource.Max_OutsourceRate : 0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sSF_OutsourceAmount = cls_Formater.FormatDecimal(oSF_Outsource != null ? oSF_Outsource.Max_OutsourceCost : 0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                string sSemiFG_BoM_ID = clsHelpMethods_Prod.Get_BoM_formFinishedGood(oJob_Meterial.Item_ID);
                string sLabourSMV_Cost = cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_ProdCostCenterSMV_Cost(sSemiFG_BoM_ID, "PCC/001"), clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                string sOverheadSMV_Cost = cls_Formater.FormatDecimal(clsHelpMethods_Prod.Get_ProdCostCenterSMV_Cost(sSemiFG_BoM_ID, "PCC/002"), clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                if (oJob_Meterial.Item_ID == txtFinishGoodDescription.Tag.ToString())
                {
                    dtSemiFinishedCost.Rows.Add("0",
                                        oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.Line_No_Sub2,
                                        oJob_Meterial.Item_ID, sItemName, sUoMName,
                                        sTotalInputQty, sConsumption, sdItemWAvgCost, sLowestCost, sHighestCost, -1, 0, 0, "0",
                                        oJob_Meterial.IsSemiFinishItem, sSF_OutsourceRate, sSF_OutsourceAmount, "0", "0");

                }
                else
                {
                    dtSemiFinishedCost.Rows.Add("0",
                                        oJob_Meterial.Line_No, oJob_Meterial.Line_No_Sub1, oJob_Meterial.Line_No_Sub2,
                                        oJob_Meterial.Item_ID, sItemName, sUoMName,
                                        sTotalInputQty, sConsumption, sdItemWAvgCost, sLowestCost, sHighestCost, iCostSeclection, sCost, sCost_Edited, "0",
                                        oJob_Meterial.IsSemiFinishItem, sSF_OutsourceRate, sSF_OutsourceAmount, sLabourSMV_Cost, sOverheadSMV_Cost);
                }

            }
            dgr_SemiFinishedCost.ItemsSource = dtSemiFinishedCost.DefaultView;
        }

        private void Fill_OH_LabourGrid_SectionActivities(string sProdJob_ID)
        {
            dtOH_LabourCost_SectionActivities.Clear();
            foreach (tbl_prodTxJobCard_Labour oJob_labour in tbl_prodTxJobCard_Labour.SelectAllByProdJob_ID(sProdJob_ID))
            {
                dtOH_LabourCost_SectionActivities.Rows.Add("",
                    oJob_labour.ProdSection_ID,
                     clsGenaralName.getName_Section(oJob_labour.ProdSection_ID),
                     oJob_labour.ProdActivity_ID,
                     clsGenaralName.getName_ApparelSectionActivity(oJob_labour.ProdActivity_ID),
                     cls_Formater.FormatDecimal(oJob_labour.Shifts_Day, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.ShiftMinutes_Day / 60, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.Labours_Day, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.LabourRatePerHour_Day, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.Shifts_Night, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.ShiftMinutes_Night / 60, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.Labours_Night, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.LabourRatePerHour_Night, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.ProdMinutes / 60, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.OhRatePerHour, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.OtherCostRatePerHour, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                     cls_Formater.FormatDecimal(oJob_labour.CostTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice)
                    );
            }
            dgr_OH_LabourCost_SectionActivities.ItemsSource = dtOH_LabourCost_SectionActivities.DefaultView;
            CaculateAccumilatedCost_OHLabour_SectionActivities();
        }

        private void Fill_OH_LabourGrid_CostSMV(string sProdJob_ID)
        {
            dtOH_Labour_CostSMV.Clear();
            foreach (tbl_prodTxJobCard_CostCenter oJob_CostCenter in tbl_prodTxJobCard_CostCenter.SelectAllByProdJob_ID(sProdJob_ID))
            {
                tbl_prodMasCostCenter oCostCenter = tbl_prodMasCostCenter.Select(oJob_CostCenter.Cost_Center_ID);
                if (oCostCenter != null)
                    dtOH_Labour_CostSMV.Rows.Add(oJob_CostCenter.Line_No,
                        oJob_CostCenter.Cost_Center_ID,
                         oCostCenter.Description,
                         cls_Formater.FormatDecimal(oJob_CostCenter.Smv, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                         cls_Formater.FormatDecimal(oJob_CostCenter.Smv_rate, clsConfig.sCurrencyDecimalPlaces_UnitPrice),
                         cls_Formater.FormatDecimal(oJob_CostCenter.Cost, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
            }
            dgr_OH_LabourCost_SMV.ItemsSource = dtOH_Labour_CostSMV.DefaultView;
            CaculateAccumilatedCost_OHLabour_SMV();
        }

        private void Fill_GridFooter_fromProdJob(string sProdJob_ID)
        {
            dtCostFooter.Rows.Clear();
            foreach (tbl_prodTxJobCard_CostFooter oCostFooter in tbl_prodTxJobCard_CostFooter.SelectAllByProdJob_ID(sProdJob_ID).OrderBy(o => o.Line_No))
            {
                tbl_prodMasCostFooter oFooter = tbl_prodMasCostFooter.Select(oCostFooter.Footer_ID);
                dtCostFooter.Rows.Add(oCostFooter.Line_No, oCostFooter.Footer_ID, oFooter.Description, cls_Formater.FormatDecimal(oCostFooter.Percentage, clsConfig.sCurrencyDecimalPlaces_UnitPrice) + "%", cls_Formater.FormatDecimal(oCostFooter.Amount, clsConfig.sCurrencyDecimalPlaces_UnitPrice));
            }

            if (dtCostFooter.Rows.Count < 1)
            {
                Fill_GridFooter();
            }

            ClearUnWantedDataInFooterGrid();
        }

        private void Fill_GridFooter()
        {
            dtCostFooter.Clear();
            dgr_CostingFooter.ItemsSource = dtCostFooter.DefaultView;
            foreach (tbl_prodMasCostFooter oCFooter in tbl_prodMasCostFooter.SelectAll().Where(r => r.IsEnable).OrderBy(r => r.Line_No))
            {
                string sPercentage = "0.00%";
                if (oCFooter.IsTax)
                {
                    tbl_zTax oTax = tbl_zTax.Select(oCFooter.Tax_ID);
                    if (oTax != null)
                        sPercentage = cls_Formater.FormatDecimal(oTax.TaxPesentage, clsConfig.sCurrencyDecimalPlaces_UnitPrice) + "%";
                }
                dtCostFooter.Rows.Add(oCFooter.Line_No, oCFooter.Footer_ID, oCFooter.Description, sPercentage, "0.00");
            }
        }
        #endregion

        #region Grid Events

        #region Main Grid Event
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
                if (Convert.ToBoolean(((System.Data.DataRowView)(e.Row.DataContext)).Row["IS_CANCELLED"].ToString()))
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

        #region Raw Meterial Cost Grid Events

        private void dgr_DirectCost_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_RawMeterialCost.CurrentCell;
                int irowID = dgr_RawMeterialCost.SelectedIndex;

                object item = dgr_RawMeterialCost.SelectedItem;
                string sLineNo2 = "";
                if (item != null)
                {
                    sLineNo2 = (dgr_RawMeterialCost.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                }

                if (vDG_Cell.Column.SortMemberPath == "Cost" && sLineNo2.Trim() == "0")
                {
                    dtRawMeterialCost.Rows[irowID]["Cost_Edit"] = dtRawMeterialCost.Rows[irowID]["Cost"].ToString();
                }
                CaculateAccumilatedCost_DirectMaterial();
            }
            catch (Exception ex)
            { }
        }

        private void dgr_DirectMeterialCost_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtRawMeterialCost);
            try
            {
                if (Convert.ToBoolean(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[17].ToString()))
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#a6a6a6");
                    e.Row.IsEnabled = false;
                }
                else if (Convert.ToInt16(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[2].ToString()) > 0)
                {
                    //e.Row.Background = (Brush)bc.ConvertFrom("#c7c7c7");
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_DirectMeterialCost_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumn = e.Column.SortMemberPath;
            TextBox t;
            if (sColumn == "Cost_Edit" || sColumn == "Consumption")
            {
                t = e.EditingElement as TextBox;
                decimal dQty = 0m;
                try
                {
                    dQty = decimal.Parse(t.Text);
                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK, "Red");
                }

                if (sColumn == "Cost_Edit")
                {
                    object item = dgr_RawMeterialCost.SelectedItem;
                    string sLineNo2 = "";
                    if (item != null)
                    {
                        sLineNo2 = (dgr_RawMeterialCost.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                    }

                    if (sLineNo2.Trim() == "0")
                        t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                    else
                    {
                        SEACCMessageBox.Show("Oops..!", "Can not change optional material cost...", MessageBoxButton.OK, "Red");
                        t.Text = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                    }
                }
                if (sColumn == "Consumption")
                    t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sDecimalPlaces_Quantity);
            }

            else if (sColumn == "OutsourceRate")
            {
                t = e.EditingElement as TextBox;
                decimal dRate = 0m;
                decimal dOutsource_cost = 0;
                object item = dgr_SemiFinishedCost.SelectedItem;
                string sConsumption = (dgr_SemiFinishedCost.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
                try
                {
                    dRate = decimal.Parse(t.Text);
                    dOutsource_cost = clsValidation.Validate_DecimalNumber(sConsumption) * dRate;

                }
                catch (Exception)
                {
                    SEACCMessageBox.Show("Oops..!", "Please enter numeric value", MessageBoxButton.OK);
                }
                t.Text = cls_Formater.FormatDecimal(dRate, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                (dgr_SemiFinishedCost.SelectedCells[18].Column.GetCellContent(item) as TextBlock).Text = cls_Formater.FormatDecimal(dOutsource_cost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }

            CaculateAccumilatedCost_DirectMaterial();
            CaculateAccumilatedCost_SemiItems();
        }

        private void ComboBox_DirectMeterialCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (DataRow row in dtRawMeterialCost.Rows)
            {
                decimal dGrossQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                decimal dWeighted_cost = clsValidate.ValidateRowValue(row, "WeiAvg", 0m);
                decimal dLowest_cost = clsValidate.ValidateRowValue(row, "Lowest", 0m);
                decimal dHighest_cost = clsValidate.ValidateRowValue(row, "Highest", 0m);
                decimal dBoM_cost = clsValidate.ValidateRowValue(row, "BoMCost", 0m);
                int iSelectedIndex_ComboBox = Convert.ToInt32(clsValidate.ValidateRowValue(row, "CostSelection", 0));
                decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0m);

                row["Cost"] = cls_Formater.FormatDecimal(dCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                switch (iSelectedIndex_ComboBox)
                {
                    case (int)prod_Costing_Mode.Weighted_Avg_Cost:
                        row["Cost"] = cls_Formater.FormatDecimal(dWeighted_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                        break;
                    case (int)prod_Costing_Mode.Lowest_Cost:
                        row["Cost"] = cls_Formater.FormatDecimal(dLowest_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                        break;
                    case (int)prod_Costing_Mode.Highest_Cost:
                        row["Cost"] = cls_Formater.FormatDecimal(dHighest_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                        break;
                    case (int)prod_Costing_Mode.BoM_Cost:
                        row["Cost"] = cls_Formater.FormatDecimal(dBoM_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                        break;
                    default:
                        row["Cost"] = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                        break;
                }

                //if (dCost != clsValidation.Validate_DecimalNumber(row["Cost"].ToString()))
                //    row["Cost_Edit"] = row["Cost"];
            }

            CaculateAccumilatedCost_DirectMaterial();
        }

        #endregion

        #region Semi Finished Item Cost Grid Event

        private void dgr_SemiMeterialCost_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_SemiFinishedCost.CurrentCell;
                int irowID = dgr_SemiFinishedCost.SelectedIndex;

                if (vDG_Cell.Column.SortMemberPath == "Cost")
                {
                    dtSemiFinishedCost.Rows[irowID]["Cost_Edit"] = dtSemiFinishedCost.Rows[irowID]["Cost"].ToString();
                }
                CaculateAccumilatedCost_SemiItems();
            }
            catch (Exception ex)
            { }
        }

        private void ComboBox_SemiFinishedCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* Commented by Gayan
             * on 20th April 2018
             * This is not relavant for Semi Finisehd Costing
             * Costing happen using SF Raw Materials and Its SMVs 
             */
            //foreach (DataRow row in dtSemiFinishedCost.Rows)
            //{
            //    decimal dGrossQty = clsValidate.ValidateRowValue(row, "Qty", 0);
            //    decimal dWeighted_cost = clsValidate.ValidateRowValue(row, "WeiAvg", 0);
            //    decimal dLowest_cost = clsValidate.ValidateRowValue(row, "Lowest", 0);
            //    decimal dHighest_cost = clsValidate.ValidateRowValue(row, "Highest", 0);
            //    int iSelectedIndex_ComboBox = Convert.ToInt32(clsValidate.ValidateRowValue(row, "CostSelection", 0));
            //    decimal dCost = clsValidate.ValidateRowValue(row, "Cost", 0);

            //    row["Cost"] = cls_Formater.FormatDecimal(dCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            //    switch (iSelectedIndex_ComboBox)
            //    {
            //        case 0:
            //            row["Cost"] = cls_Formater.FormatDecimal(dWeighted_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            //            break;
            //        case 1:
            //            row["Cost"] = cls_Formater.FormatDecimal(dLowest_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            //            break;
            //        case 2:
            //            row["Cost"] = cls_Formater.FormatDecimal(dHighest_cost * dGrossQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            //            break;
            //        default:
            //            row["Cost"] = cls_Formater.FormatDecimal(0, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            //            break;
            //    }

            //    if (dCost != clsValidation.Validate_DecimalNumber(row["Cost"].ToString()))
            //        row["Cost_Edit"] = row["Cost"];

            //}
            CaculateAccumilatedCost_SemiItems();
        }

        private void dgr_SemiMeterialCost_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtSemiFinishedCost);
        }

        #endregion

        #region OH & Labour Cost Section Activity Grid Events

        private void dgr_OH_LabourCost_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtOH_LabourCost_SectionActivities);
        }

        private void dgr_OH_LabourCost_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumn = e.Column.SortMemberPath;
            TextBox t;
            if (sColumn == "DayShift" || sColumn == "LaboursDay" || sColumn == "LabourRateDay" || sColumn == "NightShift" || sColumn == "LaboursNight" || sColumn == "LabourRateNight")
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
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CaculateAccumilatedCost_OHLabour_SectionActivities();
        }

        #endregion

        #region OH & Labour Cost Section SMV Grid Events
        private void dgr_OH_LabourCost_SMV_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumn = e.Column.SortMemberPath;
            TextBox t;
            if (sColumn == "SMV" || sColumn == "SMV_Rate")
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
                t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CaculateAccumilatedCost_OHLabour_SMV();
        }

        private void dgr_OH_LabourCost_SMV_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }
        #endregion

        #region Cost Footer Grid
        private void dgr_CostingFooter_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                string sFooter_ID = (((DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString());
                if (sFooter_ID == sRawMaterialCost_ID || sFooter_ID == sSemiFinished_Cost_ID || sFooter_ID == sLabourCost_ID || sFooter_ID == sProduction_OH_cost_ID ||
                    sFooter_ID == sTotalPrimeCost_ID || sFooter_ID == sMargin_ID || sFooter_ID == sSemiFinished_OutsourceCost_ID || sFooter_ID == sSellingPriceBeforeOtherCost_ID ||
                    sFooter_ID == sSellingPriceBeforeTaxes_ID || sFooter_ID == sNBT_ID || sFooter_ID == sSellingPriceWithNBT_ID ||
                    sFooter_ID == sVAT_ID || sFooter_ID == sSellingPriceWithTax_ID)
                {
                    e.Row.Background = (Brush)bc.ConvertFrom("#a6a6a6");
                    e.Row.IsEnabled = false;
                }

                if (sFooter_ID == sTotalPrimeCost_ID || sFooter_ID == sSellingPriceBeforeOtherCost_ID
                    || sFooter_ID == sSellingPriceBeforeTaxes_ID || sFooter_ID == sSellingPriceWithTax_ID)
                {
                    e.Row.FontWeight = FontWeights.Bold;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_CostingFooter_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnSortMember = e.Column.SortMemberPath;
            TextBox t;
            if (sColumnSortMember == "Percentage" || sColumnSortMember == "Cost")
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
                if (sColumnSortMember == "Percentage")
                    t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice) + "%";
                else
                    t.Text = cls_Formater.FormatDecimal(dQty, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CalculateCostingTotals();
        }
        #endregion

        #endregion

        #region Search Events
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
        #endregion

        #region Texbox Other Events
        private void txtTotals_LostFocus(object sender, RoutedEventArgs e)
        {
            CalculateCostingTotals();
        }

        private void txtTotals_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CalculateCostingTotals();
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

        #region Help Methods

        private void CaculateAccumilatedCost_DirectMaterial()
        {
            decimal dAccumilatedCost = 0;
            foreach (DataRow row in dtRawMeterialCost.Rows)
            {
                decimal dCost = clsValidate.ValidateRowValue(row, "Cost_Edit", 0m);
                dAccumilatedCost += dCost;
                row["AccCost"] = cls_Formater.FormatDecimal(dAccumilatedCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CalculateCostingTotals();
        }

        private void CaculateAccumilatedCost_SemiItems()
        {
            decimal dAccumilatedCost = 0;
            foreach (DataRow row in dtSemiFinishedCost.Rows)
            {
                decimal dCost = clsValidate.ValidateRowValue(row, "Cost_Edit", 0m);
                dAccumilatedCost += dCost;
                row["AccCost"] = cls_Formater.FormatDecimal(dAccumilatedCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CalculateCostingTotals();
        }

        private void CaculateAccumilatedCost_OHLabour_SMV()
        {
            foreach (DataRow row in dtOH_Labour_CostSMV.Rows)
            {
                decimal dSMV = clsValidate.ValidateRowValue(row, "SMV", 0m);
                decimal dSMV_Rate = clsValidate.ValidateRowValue(row, "SMV_Rate", 0m);
                decimal dCost = dSMV * dSMV_Rate;
                row["Cost"] = cls_Formater.FormatDecimal(dCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CalculateCostingTotals();
        }

        private void CaculateAccumilatedCost_OHLabour_SectionActivities()
        {
            decimal dAccumilatedCost = 0;
            foreach (DataRow row in dtOH_LabourCost_SectionActivities.Rows)
            {
                decimal dDayShifts = clsValidate.ValidateRowValue(row, "DayShift", 0m);
                decimal dHrsDayShift = clsValidate.ValidateRowValue(row, "HrsDayShift", 0m);
                decimal dLaboursDay = clsValidate.ValidateRowValue(row, "LaboursDay", 0m);
                decimal dLabourRateDay = clsValidate.ValidateRowValue(row, "LabourRateDay", 0m);
                decimal dNightShifts = clsValidate.ValidateRowValue(row, "NightShift", 0m);
                decimal dHrsNightShift = clsValidate.ValidateRowValue(row, "HrsNightShift", 0m);
                decimal dLaboursNight = clsValidate.ValidateRowValue(row, "LaboursNight", 0m);
                decimal dLabourRateNight = clsValidate.ValidateRowValue(row, "LabourRateNight", 0m);
                decimal dOHRate = clsValidate.ValidateRowValue(row, "OHRate", 0m);
                decimal dOtherRate = clsValidate.ValidateRowValue(row, "OtherRate", 0m);

                decimal dProdHrs = (dDayShifts * dHrsDayShift * dLaboursDay) + (dNightShifts * dHrsNightShift * dLaboursNight);
                decimal dTotal = (dDayShifts * dHrsDayShift * dLaboursDay * dLabourRateDay) + (dNightShifts * dHrsNightShift * dLaboursNight * dLabourRateNight) + ((dOHRate + dOtherRate) * dProdHrs);
                dAccumilatedCost += dTotal;

                row["ProdHrs"] = cls_Formater.FormatDecimal(dProdHrs, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                row["Total"] = cls_Formater.FormatDecimal(dTotal, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
                row["AccumTotal"] = cls_Formater.FormatDecimal(dAccumilatedCost, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
            }
            CalculateCostingTotals();
        }

        private void CalculateCostingTotals()
        {
            try
            {
                decimal dRawMaterialCost = 0, dSemiFinished_Cost = 0, dLabourCost = 0, dProduction_OH_cost = 0, dOtherCost = 0, dTotalPrimeCost = 0, dMarkup_percentage = 0, dMarkUp = 0, dMargin_Percentage = 0,
                    dSellingPriceBeforeOtherCost = 0, dOtherEmbellishmentCost = 0, dSemiFinished_OutSource_Cost = 0, dOtherCost2 = 0, dTransportCost = 0, dSellingPriceBeforeTaxes = 0,
                    dNbt_Percentage = 0, dNBT = 0, dSellingPriceWithNBT = 0,
                    dVat_Percentage = 0, dVAT = 0,
                    dSellingPriceWithTax = 0;

                if (dtRawMeterialCost.Rows.Count > 0)
                {
                    string sSum = dtRawMeterialCost.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("Cost_Edit"))).ToString();
                    dRawMaterialCost = decimal.Parse(sSum.ToString());
                    SetValueTo_FooterTable(sRawMaterialCost_ID, "Cost", dRawMaterialCost);
                }

                if (dtSemiFinishedCost.Rows.Count > 0)
                {
                    string sSum_SF_Outsource = dtSemiFinishedCost.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("OutsourceCost"))).ToString();
                    dSemiFinished_OutSource_Cost = decimal.Parse(sSum_SF_Outsource.ToString());
                    SetValueTo_FooterTable(sSemiFinished_OutsourceCost_ID, "Cost", dSemiFinished_OutSource_Cost);

                    string sSum_SemiFinished = dtSemiFinishedCost.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("Cost_Edit"))).ToString();
                    dSemiFinished_Cost = decimal.Parse(sSum_SemiFinished.ToString());
                    SetValueTo_FooterTable(sSemiFinished_Cost_ID, "Cost", dSemiFinished_Cost);
                }

                if (dtOH_Labour_CostSMV.Rows.Count > 0)
                {
                    dLabourCost = GetCostFromSMV_CostTable("PCC/001");
                    dProduction_OH_cost = GetCostFromSMV_CostTable("PCC/002");

                    if (dtSemiFinishedCost.Rows.Count > 0)
                    {
                        string sSum_SFSMV_Labour = dtSemiFinishedCost.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("LabourSMV_Cost"))).ToString();
                        string sSum_SFSMV_Overhead = dtSemiFinishedCost.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("OverheadSMV_Cost"))).ToString();

                        dLabourCost += decimal.Parse(sSum_SFSMV_Labour.ToString());
                        dProduction_OH_cost += decimal.Parse(sSum_SFSMV_Overhead.ToString());
                    }

                    SetValueTo_FooterTable(sLabourCost_ID, "Cost", dLabourCost);
                    SetValueTo_FooterTable(sProduction_OH_cost_ID, "Cost", dProduction_OH_cost);
                }

                int iCurrencyDecimals = clsConfig.sCurrencyDecimalPlaces_UnitPrice;// int.Parse(clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                dOtherCost = decimal.Round(GetValueFrom_FooterTable(sOtherCost_ID, "Cost"), iCurrencyDecimals);
                dTotalPrimeCost = decimal.Round(dRawMaterialCost + dSemiFinished_Cost + dLabourCost + dProduction_OH_cost + dOtherCost, iCurrencyDecimals);
                SetValueTo_FooterTable(sTotalPrimeCost_ID, "Cost", dTotalPrimeCost);

                dMarkup_percentage = GetValueFrom_FooterTable(sMarkUp_ID, "Percentage");
                dMarkUp = decimal.Round(dTotalPrimeCost * dMarkup_percentage / 100, iCurrencyDecimals);
                SetValueTo_FooterTable(sMarkUp_ID, "Cost", dMarkUp);

                dSellingPriceBeforeOtherCost = decimal.Round(dTotalPrimeCost + dMarkUp, iCurrencyDecimals);
                SetValueTo_FooterTable(sSellingPriceBeforeOtherCost_ID, "Cost", dSellingPriceBeforeOtherCost);

                dMargin_Percentage = dSellingPriceBeforeOtherCost != 0 ? (dMarkUp * 100 / dSellingPriceBeforeOtherCost) : 0;
                SetValueTo_FooterTable(sMargin_ID, "Percentage", cls_Formater.FormatDecimal(dMargin_Percentage, iCurrencyDecimals) + "%");

                dOtherEmbellishmentCost = GetValueFrom_FooterTable(sOtherEmbellishmentCost_ID, "Cost");
                dOtherCost2 = GetValueFrom_FooterTable(sOtherCost2_ID, "Cost");
                dTransportCost = GetValueFrom_FooterTable(sTransportCost_ID, "Cost");
                dSellingPriceBeforeTaxes = decimal.Round(dSellingPriceBeforeOtherCost + dOtherEmbellishmentCost + dSemiFinished_OutSource_Cost + dOtherCost2 + dTransportCost, iCurrencyDecimals);
                SetValueTo_FooterTable(sSellingPriceBeforeTaxes_ID, "Cost", dSellingPriceBeforeTaxes);

                dNbt_Percentage = GetValueFrom_FooterTable(sNBT_ID, "Percentage");
                dNBT = decimal.Round(dSellingPriceBeforeTaxes * dNbt_Percentage / 100, iCurrencyDecimals);
                SetValueTo_FooterTable(sNBT_ID, "Cost", dNBT);

                dSellingPriceWithNBT = decimal.Round(dSellingPriceBeforeTaxes + dNBT, iCurrencyDecimals);
                SetValueTo_FooterTable(sSellingPriceWithNBT_ID, "Cost", dSellingPriceWithNBT);

                dVat_Percentage = GetValueFrom_FooterTable(sVAT_ID, "Percentage");
                dVAT = decimal.Round(dSellingPriceWithNBT * dVat_Percentage / 100, iCurrencyDecimals);
                SetValueTo_FooterTable(sVAT_ID, "Cost", dVAT);

                dSellingPriceWithTax = decimal.Round(dSellingPriceWithNBT + dVAT, iCurrencyDecimals);
                SetValueTo_FooterTable(sSellingPriceWithTax_ID, "Cost", dSellingPriceWithTax);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                ClearUnWantedDataInFooterGrid();
            }
        }

        private decimal GetValueFrom_FooterTable(string sFooterID, string sColumnName)
        {
            decimal dValue = 0;
            DataRow dr = dtCostFooter.Select("FooterID = '" + sFooterID + "'").FirstOrDefault();
            if (dr != null)
                dValue = clsValidation.Validate_DecimalNumber(dr[sColumnName].ToString().Replace("%", ""));

            return dValue;
        }

        private void SetValueTo_FooterTable(string sFooterID, string sColumnName, decimal dValue)
        {
            DataRow dr = dtCostFooter.Select("FooterID = '" + sFooterID + "'").FirstOrDefault();
            if (dr != null)
                dr[sColumnName] = cls_Formater.FormatDecimal(dValue, clsConfig.sCurrencyDecimalPlaces_UnitPrice);
        }

        private void SetValueTo_FooterTable(string sFooterID, string sColumnName, string sValue)
        {
            DataRow dr = dtCostFooter.Select("FooterID = '" + sFooterID + "'").FirstOrDefault();
            if (dr != null)
                dr[sColumnName] = sValue;
        }

        private decimal GetCostFromSMV_CostTable(string sCostCenterID)
        {
            decimal dValue = 0;
            DataRow dr = dtOH_Labour_CostSMV.Select("CostCenterID = '" + sCostCenterID + "'").FirstOrDefault();
            if (dr != null)
                dValue = clsValidation.Validate_DecimalNumber(dr["Cost"].ToString());

            return dValue;
        }

        #endregion
    }
}
