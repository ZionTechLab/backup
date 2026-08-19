using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Common;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_PRODUCTION_PHARMA.Transactions;
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

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Developped By Gayan
    /// On 2017-04-29
    /// </summary>
    /// 
    public partial class UC_BOM_Sales : UserControl
    {
        #region Class Variable
        DataTable dtDeliveryPlan = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_BOM_Sales()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_BOMCreation_Sales;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables

            #region dtDeliveryPlan
            dtDeliveryPlan.Columns.Add("LineNo");
            dtDeliveryPlan.Columns.Add("Date");
            dtDeliveryPlan.Columns.Add("BranchNo");
            dtDeliveryPlan.Columns.Add("Branch");
            dtDeliveryPlan.Columns.Add("Address");
            dtDeliveryPlan.Columns.Add("Qty");
            dtDeliveryPlan.Columns.Add("UoM_ID");
            dtDeliveryPlan.Columns.Add("UoM");
            dtDeliveryPlan.Columns.Add("DeliveryTerms");
            #endregion

            #region Initialize Data Table
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
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "LINE_NO", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job#", "JOB_ID", 80);
            dgr_Main.Add_DatagridColoumn("Job Date", "JOB_DATE", 80);
            dgr_Main.Add_DatagridColoumn("Finished Good Sales Name", "ITEM", 200);
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
                            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oBoM != null)
                            {
                                if (!oBoM.IsLocked)
                                {
                                    decimal dSO_Qty = 0;
                                    if (txtCustomerCOSO.Tag != null && txtCustomerCOSO.Tag.ToString() != "default")
                                        foreach (tbl_sasCustomerOrder_Detail OFG_Item in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerCOSO.Tag.ToString()).Where(r => r.Item_ID == txtFinishGoodSalesCode.Tag.ToString()))
                                            dSO_Qty += OFG_Item.Qty;

                                    tbl_prod_pharmaTxJobCard oOldJob = new tbl_prod_pharmaTxJobCard(
                                     oBoM.ProdJob_ID, dtpProdJob_Date.GetDateTime(), oBoM.ProdJobStatus, //cmbProdJobStatus.GetSelectedIndex(),
                                     txtSalesMan.Tag != null ? txtSalesMan.Tag.ToString() : "default",
                                     txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                     txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                     txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                     txtComments.Text,
                                     oBoM.Remarks2,
                                     oBoM.JobType_ID,
                                     oBoM.ProdRange_ID,
                                     oBoM.ProdCategory_ID,
                                     oBoM.ProdSize_ID,
                                     oBoM.Colour_ID,
                                     oBoM.Item_ID_Previous,
                                     oBoM.Item_ID_FG,
                                     txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                     oBoM.Item_Length, oBoM.Item_Length_UoM_ID, oBoM.Item_Width, oBoM.Item_Weight_UoM_ID, oBoM.Item_Height, oBoM.Item_Height_UoM_ID, oBoM.Item_Diameter, oBoM.Item_Diameter_UoM_ID, oBoM.Item_Radius, oBoM.Item_Radius_UoM_ID, oBoM.Item_Thickness, oBoM.Item_Thickness_UoM_ID, oBoM.Item_Weight, oBoM.Item_Weight_UoM_ID,
                                     decimal.Parse(txtFinishGoodOrderedQty.Text), oBoM.FGoodQty, oBoM.WastePercent, oBoM.WasteQty, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
                                     oBoM.EstProdHrs,
                                     oBoM.IsChecked1, oBoM.IsChecked2, oBoM.IsChecked2,
                                     oBoM.IsApproved1, oBoM.IsApproved2, oBoM.IsApproved2,
                                     oBoM.IsCanceled, oBoM.IsLocked,
                                     oBoM.CreateUser_ID, clsSecurity.UserIDLoged,
                                     oBoM.Checked1User_ID, oBoM.Checked2User_ID, oBoM.Checked3User_ID,
                                     oBoM.Approved1User_ID, oBoM.Approved2User_ID, oBoM.Approved3User_ID,
                                     oBoM.CanceldUser_ID, oBoM.LockedUser_ID,
                                     oBoM.DateCreate, clsSecurity.getServerDateTime(), oBoM.DateChecked1, oBoM.DateChecked2, oBoM.DateChecked3,
                                     oBoM.DateApproved1, oBoM.DateApproved2, oBoM.DateApproved3,
                                     oBoM.DateCanceled, oBoM.DateLocked,
                                     oBoM.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                     oBoM.Checked1UserTerminal_ID, oBoM.Checked2UserTerminal_ID, oBoM.Checked3UserTerminal_ID,
                                     oBoM.Approved1UserTerminal_ID, oBoM.Approved2UserTerminal_ID, oBoM.Approved3UserTerminal_ID,
                                     oBoM.CanceledUserTerminal_ID, oBoM.LockedUserTerminal_ID, oBoM.CompanyID, oBoM.CompanyBranchID, dSO_Qty, oBoM.IsTemporaryBoM);
                                    oOldJob.Update();

                                    tbl_prod_pharmaTxJobCard_Delivery.DeleteAllByProdJob_ID(oBoM.ProdJob_ID);
                                    foreach (DataRow row in dtDeliveryPlan.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                        DateTime dtmDeliver = clsValidate.ValidateRowValue(row, "Date", clsValidation.defaultDateTime);
                                        int iBranch_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BranchNo", 0m));
                                        string sDeliverAddress = clsValidate.ValidateRowValue(row, "Address", "");
                                        decimal dDeliverQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        string sDeliverTerms = clsValidate.ValidateRowValue(row, "DeliveryTerms", "");

                                        tbl_prod_pharmaTxJobCard_Delivery oNewDelivery = new tbl_prod_pharmaTxJobCard_Delivery(iLine_no, oBoM.ProdJob_ID, dtmDeliver, iBranch_no, sDeliverAddress, dDeliverQty, sUoM_ID, sDeliverTerms, "");
                                        oNewDelivery.Insert();
                                    }

                                    tbl_genItemMaster oItem_FG = tbl_genItemMaster.Select(txtFinishGoodDescription.Tag.ToString());
                                    oItem_FG.IsSemiFinishGood = chkIsSemiFinished.IsChecked;
                                    oItem_FG.IsFinishGood = chkIsFinishedGood.IsChecked;
                                    oItem_FG.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Cannot Update..", "Selected BoM has already been locked", MessageBoxButton.OK, "Red");
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
                            decimal dLength = 0, dWidth = 0, dHeight = 0, dDiameter = 0, dRadius = 0, dThickness = 0, dWeight = 0;
                            string sLenghtUoM = "default", sWidthUoM = "default", sHeightUoM = "default", sDiameterUoM = "default", sRadiusUoM = "default", sThicknessUoM = "default", sWeightUoM = "default";

                            tbl_prod_pharmaTxFinishedGoodSpecsSheet oFG_Spec = tbl_prod_pharmaTxFinishedGoodSpecsSheet.Select(txtFinishGoodDescription.Tag.ToString());
                            tbl_genItemMaster oItem_FG = tbl_genItemMaster.Select(txtFinishGoodDescription.Tag.ToString());
                            if (oFG_Spec != null && oItem_FG != null)
                            {
                                #region Size Variables
                                tbl_zItemTag3 oProductSize = tbl_zItemTag3.Select(oFG_Spec.Tag3_ID);
                                if (oProductSize != null)
                                {
                                    dLength = oProductSize.Length;
                                    dWidth = oProductSize.Width;
                                    dHeight = oProductSize.Height;
                                    dDiameter = oProductSize.Diameter;
                                    dRadius = oProductSize.Radius;
                                    dThickness = oProductSize.Thickness;
                                    dWeight = oProductSize.Weight;

                                    sLenghtUoM = oProductSize.Uom_ID_length;
                                    sWidthUoM = oProductSize.Uom_ID_width;
                                    sHeightUoM = oProductSize.Uom_ID_height;
                                    sDiameterUoM = oProductSize.Uom_ID_diameter;
                                    sRadiusUoM = oProductSize.Uom_ID_radius;
                                    sThicknessUoM = oProductSize.Uom_ID_thickness;
                                    sWeightUoM = oProductSize.Uom_ID_weight;
                                }
                                #endregion

                                if (oFG_Spec.Item_ID_FG != "default")
                                {
                                    decimal dSO_Qty = 0;
                                    if (txtCustomerCOSO.Tag != null && txtCustomerCOSO.Tag.ToString() != "default")
                                        foreach (tbl_sasCustomerOrder_Detail OFG_Item in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerCOSO.Tag.ToString()).Where(r => r.Item_ID == txtFinishGoodSalesCode.Tag.ToString()))
                                            dSO_Qty += OFG_Item.Qty;

                                    #region Job / BoM Header
                                    tbl_prod_pharmaTxJobCard oNewJob = new tbl_prod_pharmaTxJobCard(
                                                                   txtProdJobID.Text, dtpProdJob_Date.GetDateTime(), (int)prod_BoM_Status.BoMSales,  //cmbProdJobStatus.GetSelectedIndex(),
                                                                   txtSalesMan.Tag != null ? txtSalesMan.Tag.ToString() : "default",
                                                                   txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                                                   txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                                                   txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                                                   txtComments.Text,
                                                                   "",//Remark 2
                                                                   oItem_FG.ItemClass_ID,
                                                                   oItem_FG.ItemType_ID,
                                                                   oItem_FG.ItemCategory_ID,
                                                                   oFG_Spec.Tag3_ID,
                                                                   oFG_Spec.Colour_ID,
                                                                   txtPreviousBoMTemplate.Tag != null ? txtPreviousBoMTemplate.Tag.ToString() : "default",
                                                                   txtFinishGoodSalesCode.Tag.ToString(),
                                                                   txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default",
                                                                   dLength, sLenghtUoM, dWidth, sWidthUoM, dHeight, sHeightUoM, dDiameter, sDiameterUoM, dRadius, sRadiusUoM, dThickness, sThicknessUoM, dWeight, sWeightUoM,
                                                                  decimal.Parse(txtFinishGoodOrderedQty.Text), decimal.Parse(txtFinishGoodOrderedQty.Text), 0, 0, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
                                                                   0,
                                                                   false, false, false, false, false, false, false, false,
                                                                   clsSecurity.UserIDLoged, "default",
                                                                   "default", "default", "default",
                                                                   "default", "default", "default",
                                                                   "default", "default",
                                                                   clsSecurity.getServerDateTime(), clsValidation.defaultDateTime,
                                                                   clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                                                   clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                                                   clsValidation.defaultDateTime, clsValidation.defaultDateTime,
                                                                   clsSecurity.TerminalID, "default",
                                                                   "default", "default", "default",
                                                                   "default", "default", "default",
                                                                   "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID, dSO_Qty, false);
                                    oNewJob.Insert();
                                    #endregion

                                    #region Delivery Plan
                                    foreach (DataRow row in dtDeliveryPlan.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0m));
                                        DateTime dtmDeliver = clsValidate.ValidateRowValue(row, "Date", clsValidation.defaultDateTime);
                                        int iBranch_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BranchNo", 0m));
                                        string sDeliverAddress = clsValidate.ValidateRowValue(row, "Address", "");
                                        decimal dDeliverQty = clsValidate.ValidateRowValue(row, "Qty", 0m);
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        string sDeliverTerms = clsValidate.ValidateRowValue(row, "DeliveryTerms", "");

                                        tbl_prod_pharmaTxJobCard_Delivery oNewDelivery = new tbl_prod_pharmaTxJobCard_Delivery(iLine_no, txtProdJobID.Text, dtmDeliver, iBranch_no, sDeliverAddress, dDeliverQty, sUoM_ID, sDeliverTerms, "");
                                        oNewDelivery.Insert();
                                    }
                                    #endregion

                                    #region Template BoMs
                                    if (txtPreviousBoMTemplate.Tag != null)
                                    {
                                        foreach (tbl_prod_pharmaTxJobCard_Material oMeterial in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_Material oNewMeterial = new tbl_prod_pharmaTxJobCard_Material(oMeterial.Line_No, oMeterial.Line_No_Sub1, oMeterial.Line_No_Sub2, txtProdJobID.Text, oMeterial.Item_ID, oMeterial.Uom_ID,
                                                oMeterial.IsSemiFinishItem, oMeterial.InputQty, oMeterial.Consumption, oMeterial.IsWastagePercent, oMeterial.WastagePercent, oMeterial.WastageQty, oMeterial.TotalInputQty, oMeterial.Section_ID, oMeterial.Activity_ID, oMeterial.Smv_TimeMinutes, oMeterial.TotalLabour,
                                                oMeterial.LowestCost, oMeterial.HighestCost, oMeterial.WeightedAvgCost, oMeterial.CostTypeSelection, oMeterial.Cost, oMeterial.AllowCostEdit, oMeterial.EditedCost, 1);
                                            oNewMeterial.Insert();
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_Material_Outsource oSF_Outsource in tbl_prod_pharmaTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_Material_Outsource oNewSF_Outsorce = new tbl_prod_pharmaTxJobCard_Material_Outsource(oSF_Outsource.Line_No, oSF_Outsource.Line_No_Sub1, oSF_Outsource.Line_No_Sub2, txtProdJobID.Text, oSF_Outsource.Item_ID, oSF_Outsource.Uom_ID, oSF_Outsource.Qty_Outsource, oSF_Outsource.Max_OutsourceRate, oSF_Outsource.Max_OutsourceCost);
                                            oNewSF_Outsorce.Insert();
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_Labour oLabour in tbl_prod_pharmaTxJobCard_Labour.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_Labour oNewLabour = new tbl_prod_pharmaTxJobCard_Labour(oLabour.Line_No, txtProdJobID.Text, oLabour.ProdSection_ID, oLabour.ProdActivity_ID, oLabour.Shifts_Day, oLabour.ShiftMinutes_Day, oLabour.Labours_Day, oLabour.LabourRatePerHour_Day,
                                                oLabour.Shifts_Night, oLabour.ShiftMinutes_Night, oLabour.Labours_Night, oLabour.LabourRatePerHour_Night, oLabour.OhRatePerHour, oLabour.OtherCostRatePerHour, oLabour.ProdMinutes, oLabour.CostTotal);
                                            oNewLabour.Insert();
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_ProductionOperation oTxProdOperation in tbl_prod_pharmaTxJobCard_ProductionOperation.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_ProductionOperation oNewTxOperation = new tbl_prod_pharmaTxJobCard_ProductionOperation(oTxProdOperation.Line_No, txtProdJobID.Text, oTxProdOperation.Operation_ID, oTxProdOperation.Smv_Per_Pc);
                                            oNewTxOperation.Insert();
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_CostCenter oProdCostCenter in tbl_prod_pharmaTxJobCard_CostCenter.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_CostCenter oNewTxCostCenter = new tbl_prod_pharmaTxJobCard_CostCenter(oProdCostCenter.Line_No, txtProdJobID.Text, oProdCostCenter.Cost_Center_ID, oProdCostCenter.Smv, oProdCostCenter.Smv_rate, oProdCostCenter.Cost);
                                            oNewTxCostCenter.Insert();
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_CostFooter oCostFooter in tbl_prod_pharmaTxJobCard_CostFooter.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_pharmaTxJobCard_CostFooter oNewTxCostFooter = new tbl_prod_pharmaTxJobCard_CostFooter(oCostFooter.Line_No, txtProdJobID.Text, oCostFooter.Footer_ID, oCostFooter.Percentage, oCostFooter.Amount);
                                            oNewTxCostFooter.Insert();
                                        }


                                        #region WIP Flow Template

                                        DataTable dtWIP_Flow = new DataTable();
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

                                        #region Fill Table
                                        foreach (tbl_prod_pharmaTxJobCard_WIPFlow obj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtPreviousBoMTemplate.Tag.ToString()))
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
                                                obj.InSectionID, clsGenaralName.getName_Section(obj.InSectionID),
                                                obj.InActivityID, clsGenaralName.getName_PharmaSectionActivity(obj.InActivityID),
                                                obj.OutSectionID, clsGenaralName.getName_Section(obj.OutSectionID),
                                                obj.OutActivityID, clsGenaralName.getName_PharmaSectionActivity(obj.OutActivityID),
                                                (lstMatList.Count == 1 ? lstMatList.Count + " Material" : lstMatList.Count + " Materials"),
                                                lstMatList
                                                );
                                        }
                                        #endregion

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


                                            tbl_prod_pharmaTxJobCard_WIPFlow oSF_WIP = new tbl_prod_pharmaTxJobCard_WIPFlow(iLine_no, txtProdJobID.Text, sItem_ID, sUoM_ID, dQty, 0, dItemWAvgCost, 0, (dQty * dItemWAvgCost), sInSection_ID, sInActivity_ID, sOutSection_ID, sOutActivty_ID);
                                            oSF_WIP.Insert();

                                            foreach (cls_BoMDetailMaterial oMat in lstMats.Where(r => !r.BIsWIP_SF))
                                            {
                                                tbl_prod_pharmaTxJobCard_Material oProdMat = tbl_prod_pharmaTxJobCard_Material.Select(oMat.ILineNo, oMat.ILine_No_Sub1, oMat.ILine_No_Sub2, txtProdJobID.Text);
                                                if (oProdMat != null)
                                                {
                                                    tbl_prod_pharmaTxJobCard_WIPFlow oSF_WIP_ForUpdateMats = tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.Line_No == oSF_WIP.Line_No && r.Item_ID == oSF_WIP.Item_ID).FirstOrDefault();
                                                    oProdMat.Wipout_sf_Index = oSF_WIP_ForUpdateMats.Sf_Index;
                                                    oProdMat.Update();
                                                }
                                            }
                                        }

                                        foreach (tbl_prod_pharmaTxJobCard_WIPFlow oWIP_Obj in tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text))
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
                                                        tbl_prod_pharmaTxJobCard_WIPFlow oWIP_Obj_Detail = tbl_prod_pharmaTxJobCard_WIPFlow.SelectAllByProdJob_ID(txtProdJobID.Text).Where(r => r.Line_No == iLine_no && r.Item_ID == sItem_ID).FirstOrDefault();

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
                                    }
                                    #endregion

                                    #region New BoMs
                                    else
                                    {
                                        int iline = 0;
                                        foreach (tbl_prod_pharmaMasProductionOperation oProdOperation in tbl_prod_pharmaMasProductionOperation.SelectAll().Where(r => r.Operation_ID != "default"))
                                        {
                                            tbl_prod_pharmaTxJobCard_ProductionOperation oTxOperation = new tbl_prod_pharmaTxJobCard_ProductionOperation(++iline, txtProdJobID.Text, oProdOperation.Operation_ID, oProdOperation.Smv_Per_Pc);
                                            oTxOperation.Insert();
                                        }

                                        int iline2 = 0;
                                        foreach (tbl_prod_pharmaMasCostCenter oProdCostCenter in tbl_prod_pharmaMasCostCenter.SelectAll().Where(r => r.Cost_Center_ID != "default"))
                                        {
                                            tbl_prod_pharmaTxJobCard_CostCenter oTxCostCenter = new tbl_prod_pharmaTxJobCard_CostCenter(++iline2, txtProdJobID.Text, oProdCostCenter.Cost_Center_ID, 0, 0, 0);
                                            oTxCostCenter.Insert();
                                        }
                                    }
                                    #endregion

                                    oItem_FG.IsSemiFinishGood = chkIsSemiFinished.IsChecked;
                                    oItem_FG.IsFinishGood = chkIsFinishedGood.IsChecked;
                                    oItem_FG.Update();

                                    Attachments.Insert(txtProdJobID.Tag.ToString());
                                    sProdJob_ID = oNewJob.ProdJob_ID;
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                }
                            }
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
                    if (txtProdJobID.Tag != null)
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (!oJob.IsApproved1 && !oJob.IsApproved2 && !oJob.IsApproved3)
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
                                if (!oJob.IsApproved1)
                                {
                                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Approval_Confirmation);
                                    if (bMessegeBoxResult)
                                    {
                                        frm_TwoStepVerification frmTwoStepVerify = new frm_TwoStepVerification();
                                        frmTwoStepVerify.ShowDialog();
                                        if (frmTwoStepVerify.bVerified)
                                        {
                                            oJob.IsApproved1 = true;
                                            //oJob.ProdJobStatus = (int)prod_BoM_Status.BoMProd;
                                            oJob.DateApproved1 = clsSecurity.getServerDateTime();
                                            oJob.Approved1User_ID = clsSecurity.UserIDLoged;
                                            oJob.Approved1UserTerminal_ID = clsSecurity.TerminalID;
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #region Delivery Grid Buttons

        private void SEACC_Button_AddDevliveryLocations_Click(object sender, RoutedEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCustomer.Tag != null && txtCustomer.Text != "")
                lstParameeters.Add(txtCustomer.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.CustomerBranches);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_genCustomerMaster_Branches oCusBranch = tbl_genCustomerMaster_Branches.Select(lstResult[1], int.Parse(lstResult[0]));
                if (oCusBranch != null)
                    dtDeliveryPlan.Rows.Add("", dtpProdJob_Date.GetDateTime().AddDays(10).ToString(clsValidation.Format_Date), oCusBranch.Line_No, oCusBranch.BranchName, oCusBranch.Address, "0.000", txtFinishGoodUOM.Tag != null ? txtFinishGoodUOM.Tag.ToString() : "default", txtFinishGoodUOM.Uid, "");
            }
        }
        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_DeliveryPlan.SelectedItem;
            if (selectedItem != null)
            {
                string sLineNo = (dgr_DeliveryPlan.SelectedCells[0].Column.GetCellContent(selectedItem) as TextBlock).Text;
                DataRow[] items = dtDeliveryPlan.Select("LineNo ='" + sLineNo + "'");
                if (items.Length > 0)
                {
                    foreach (DataRow item in items)
                        dtDeliveryPlan.Rows.Remove(item);
                }
                clsHelpMethods_Prod.OrderBy_DataGrid(dtDeliveryPlan);
            }
        }
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            Attachments.Clear(SEACC_Form.Function_ID);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesMan, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerInquiry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCOSO, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPreviousBoMTemplate, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodDescription, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesCode, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodSalesName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOM, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtTotalDeliveryOrderedQty, false, true);

            txtSalesMan.Tag = null;
            txtProdJobID.Tag = null;
            txtComments.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFinishGoodDescription.Tag = null;
            txtFinishGoodSalesCode.Tag = null;
            txtFinishGoodSalesName.Tag = null;
            txtFinishGoodUOM.Tag = null;
            txtPreviousBoMTemplate.Tag = null;
            txtTotalDeliveryOrderedQty.Tag = null;

            txtCustomer.ToolTip = null;
            txtFinishGoodSalesName.ToolTip = null;

            txtCustomer.Uid = "";
            txtFinishGoodUOM.Uid = "";

            txtSalesMan.Text = "";
            txtProdJobID.Text = "";
            txtComments.Text = "";
            txtCustomer.Text = "";
            txtCustomerInquiry.Text = "";
            txtCustomerCOSO.Text = "";

            txtPreviousBoMTemplate.Text = "";
            txtFinishGoodDescription.Text = "";
            txtFinishGoodSalesCode.Text = "";
            txtFinishGoodSalesName.Text = "";
            txtFinishGoodUOM.Text = "";
            txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity);
            txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity);

            dtpExFac_Date.SetTime(DateTime.Now);
            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpProductionStart_Date.SetTime(DateTime.Now);

            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(Digiteq_Logic.prod_BoM_Status));
            cmbProdJobStatus.SetSelectedIndex((int)prod_BoM_Status.BoMSales);
            cmbProdJobStatus.comboBox.IsEnabled = false;

            dtDeliveryPlan.Clear();
            dgr_DeliveryPlan.ItemsSource = dtDeliveryPlan.DefaultView;

            txtFinishGoodSalesCode.IsEnabled = true;
            txtFinishGoodDescription.IsEnabled = true;
            txtSalesMan.IsEnabled = true;
            txtComments.IsEnabled = true;
            txtCustomerInquiry.IsEnabled = true;
            txtTotalDeliveryOrderedQty.IsEnabled = true;
            dtpProdJob_Date.IsEnabled = true;
            dtpExFac_Date.IsEnabled = true;
            dtpProductionStart_Date.IsEnabled = true;
            cmbProdJobStatus.IsEnabled = true;
            btnGridItemDelete.IsEnabled = true;
            btnGridItemAdd.IsEnabled = true;
            chkIsSemiFinished.IsChecked = false;
            chkIsFinishedGood.IsChecked = true;

            SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#FF6161");
            SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#FF6161");

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtProdJobID.setReadOnlyStatus(true);
                txtProdJobID.Text = "<Auto Generate>";
            }
            else
                txtProdJobID.setReadOnlyStatus(false);
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
                foreach (tbl_prod_pharmaTxJobCard oBoM in tbl_prod_pharmaTxJobCard.SelectAll().Where(p => p.ProdJob_ID != "default" && p.ProdJobStatus != (int)prod_BoM_Status.Obsolete).OrderByDescending(o => o.DateCreate))
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oBoM.Item_ID_FG);
                    if (oItem != null)
                    {
                        decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oBoM.Item_ID_FG, "default", "default", "0", "0");
                        dgr_Main.dt.Rows.Add(++iCount, oBoM.ProdJob_ID, oBoM.ProdJobDate.ToString(clsValidation.Format_Date),
                            clsGenaralName.getName_Item(oBoM.Item_ID_FG),
                            clsHelpMethods_Prod.GetEnumDescription((prod_BoM_Status)oBoM.ProdJobStatus),
                            clsFormatter.FormatDecimalPlaces_Quantity(oBoM.OrderedQty),
                            clsFormatter.FormatDecimalPlaces_Quantity(dStockQty),
                            clsGenaralName.getName_Customer(oBoM.Customer_ID),
                            clsGenaralName.getName_User(oBoM.CreateUser_ID), clsGenaralName.getName_User(oBoM.Approved1User_ID), oBoM.IsCanceled, oBoM.IsLocked);
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
                if (Check_BoM_Exsiting())
                {
                    if (CheckValidity_DuplicateFiled())
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
            //if (!clsValidation.Validate_EmptyValue(txtFinishGoodDescription))
            //    bStatus = false;
            //if (!clsValidation.Validate_EmptyValue(txtFinishGoodSalesCode))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodSalesName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOM))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodOrderedQty))
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

                tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(txtProdJobID.Text);
                if (oJob != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool Check_BoM_Exsiting()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                string sExist_BoM = "";
                List<string> lstBoMs = new List<string>();
                foreach (tbl_prod_pharmaTxJobCard oJob in tbl_prod_pharmaTxJobCard.SelectAll().Where(r => !r.IsCanceled
                                                                                            && (r.ProdJobStatus != (int)prod_BoM_Status.Obsolete)
                                                                                            && r.Item_ID_FG == txtFinishGoodDescription.Tag.ToString()))
                {
                    lstBoMs.Add(oJob.ProdJob_ID);
                    sExist_BoM += "\n" + oJob.ProdJob_ID;
                }

                if (lstBoMs.Count > 0)
                {
                    bStatus = SEACCMessageBox.Show("BoM Already Exist", "Already Finished Good has BoM No : " + sExist_BoM + " \n Are you sure to replace new BoM to BoM No :" + sExist_BoM, MessageBoxButton.YesNo, "Red");
                    if (bStatus)
                    {
                        foreach (string sBoM in lstBoMs)
                        {
                            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(sBoM);
                            if (oBoM != null)
                            {
                                oBoM.ProdJobStatus = (int)prod_BoM_Status.Obsolete;
                                //oBoM.IsCanceled = true;
                                oBoM.DateCanceled = clsSecurity.getServerDateTime();
                                oBoM.CanceldUser_ID = clsSecurity.UserIDLoged;
                                oBoM.CanceledUserTerminal_ID = clsSecurity.TerminalID;
                                oBoM.Update();
                            }
                        }
                    }
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

                tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(sID);
                if (oJob != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSalesMan.Tag = oJob.Salesman_ID;
                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtPreviousBoMTemplate.Tag = oJob.Item_ID_Previous;
                    txtFinishGoodDescription.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesCode.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesName.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oJob.Uom_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID.Trim());
                    txtFinishGoodUOM.Uid = clsGenaralName.getName_Uom(oJob.Uom_ID);

                    txtCustomer.ToolTip = txtCustomer.Uid;
                    txtFinishGoodSalesName.ToolTip = oJob.Item_ID_FG;

                    txtSalesMan.Text = oJob.Salesman_ID == "default" ? "-" : clsGenaralName.getName_SalesRep(oJob.Salesman_ID);
                    txtProdJobID.Text = oJob.ProdJob_ID.Trim();
                    txtComments.Text = oJob.Remarks.Trim();
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID;
                    txtPreviousBoMTemplate.Text = (oJob.Item_ID_Previous == "default") ? "-" : oJob.Item_ID_Previous;
                    txtFinishGoodDescription.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesCode.Text = clsGenaralName.getCode_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    FillDeliveryGrid(oJob.ProdJob_ID, oJob.Customer_ID);

                    txtPreviousBoMTemplate.IsEnabled = false;
                    txtFinishGoodDescription.IsEnabled = false;
                    txtFinishGoodSalesCode.IsEnabled = false;
                    txtFinishGoodSalesName.IsEnabled = false;
                    txtFinishGoodUOM.IsEnabled = false;

                    if (oJob.IsApproved1)
                    {
                        SEACC_Form.btn_Approved.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                        txtSalesMan.IsEnabled = false;
                        txtComments.IsEnabled = false;
                        txtCustomerInquiry.IsEnabled = false;
                        txtFinishGoodOrderedQty.IsEnabled = false;
                        txtTotalDeliveryOrderedQty.IsEnabled = false;

                        dtpProdJob_Date.IsEnabled = false;
                        dtpExFac_Date.IsEnabled = false;
                        dtpProductionStart_Date.IsEnabled = false;

                        cmbProdJobStatus.IsEnabled = false;

                        btnGridItemDelete.IsEnabled = false;
                        btnGridItemAdd.IsEnabled = false;
                    }

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                    chkIsFinishedGood.IsChecked = false;
                    chkIsSemiFinished.IsChecked = false;
                    if (oItem != null)
                    {
                        chkIsFinishedGood.IsChecked = oItem.IsFinishGood;
                        chkIsSemiFinished.IsChecked = oItem.IsSemiFinishGood;
                    }

                    if (oJob.IsChecked1)
                        SEACC_Form.btn_Checked.Background = (Brush)bc.ConvertFrom("#3DFF3D");

                    Attachments.FillDetails(oJob.ProdJob_ID);
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

        private void fillDetails_fromPreviousJob(string sID)
        {
            try
            {
                tbl_prod_pharmaTxJobCard oJob = tbl_prod_pharmaTxJobCard.Select(sID);
                if (oJob != null)
                {
                    txtSalesMan.Tag = oJob.Salesman_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;

                    txtFinishGoodDescription.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesCode.Tag = oJob.Item_ID_FG;
                    txtFinishGoodSalesName.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOM.Tag = oJob.Uom_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID.Trim());
                    txtFinishGoodUOM.Uid = clsGenaralName.getName_Uom(oJob.Uom_ID);

                    txtCustomer.ToolTip = txtCustomer.Uid;
                    txtFinishGoodSalesName.ToolTip = oJob.Item_ID_FG;

                    txtSalesMan.Text = oJob.Salesman_ID == "default" ? "-" : clsGenaralName.getName_SalesRep(oJob.Salesman_ID.Trim());
                    txtComments.Text = oJob.Remarks.Trim();
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : clsGenaralName.getName_Customer(oJob.Customer_ID.Trim());
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID.Trim();
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID.Trim();

                    txtFinishGoodDescription.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG.Trim());
                    txtFinishGoodSalesCode.Text = clsGenaralName.getCode_Item(oJob.Item_ID_FG);
                    txtFinishGoodSalesName.Text = clsGenaralName.getName_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_Uom(oJob.Uom_ID.Trim());
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex((int)prod_BoM_Status.BoMSales);

                    FillDeliveryGrid(oJob.ProdJob_ID, oJob.Customer_ID);

                    txtPreviousBoMTemplate.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void FillDeliveryGrid(string sProdJob_ID, string sCustomer_ID)
        {
            dtDeliveryPlan.Clear();
            foreach (tbl_prod_pharmaTxJobCard_Delivery oJob_Delivery in tbl_prod_pharmaTxJobCard_Delivery.SelectAllByProdJob_ID(sProdJob_ID))
            {
                dtDeliveryPlan.Rows.Add("", oJob_Delivery.DeliverDateTime.ToString(clsValidation.Format_Date), oJob_Delivery.CustomerBranch_Line_No, clsGenaralName.getName_BranchCustomer(sCustomer_ID, oJob_Delivery.CustomerBranch_Line_No), oJob_Delivery.DeliverAddress, clsFormatter.FormatDecimalPlaces_Quantity(oJob_Delivery.DeliverQty), oJob_Delivery.DeliverUoM, clsGenaralName.getName_Uom(oJob_Delivery.DeliverUoM), oJob_Delivery.DeliverTerms);
            }
            dgr_DeliveryPlan.ItemsSource = dtDeliveryPlan.DefaultView;

            if (dtDeliveryPlan.Rows.Count > 0)
            {
                CalculateTotalDeliveyQty();
            }
            else
            {
                txtTotalDeliveryOrderedQty.Text = "0.000";
            }
        }
        #endregion

        #region Search Events

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Customer);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Uid = lstResult[2];
                txtCustomer.ToolTip = lstResult[2];
                txtCustomer.Text = lstResult[1];

                txtCustomerCOSO.Tag = null;
                txtCustomerCOSO.Text = "";
            }
        }

        private void txtPreviousFG_Item_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                txtPreviousBoMTemplate.Text = lstResult[3];
                tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(lstResult[0]);
                if (oProdJob != null)
                {
                    ClearFields();
                    fillDetails_fromPreviousJob(oProdJob.ProdJob_ID);
                    txtPreviousBoMTemplate.Tag = oProdJob.ProdJob_ID;
                    txtPreviousBoMTemplate.Text = oProdJob.ProdJob_ID;
                }
                else
                {
                    SEACCMessageBox.Show("Can not Fill..", "Selected Item doesn't have a created BoM", MessageBoxButton.OK, "Red");
                    ClearFields();
                }
            }
        }

        private void txtFinishGoodDescription_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionFinishedGoods);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishGoodDescription.Tag = lstResult[0];
                txtFinishGoodSalesCode.Tag = lstResult[0];
                txtFinishGoodSalesName.Tag = lstResult[0];

                txtFinishGoodSalesName.ToolTip = lstResult[0];

                txtFinishGoodSalesCode.Text = lstResult[1];
                txtFinishGoodSalesName.Text = lstResult[2];
                txtFinishGoodDescription.Text = lstResult[3];

                tbl_prod_pharmaTxFinishedGoodSpecsSheet oProdSpecs = tbl_prod_pharmaTxFinishedGoodSpecsSheet.Select(lstResult[0]);
                if (oProdSpecs != null)
                {
                    txtFinishGoodUOM.Tag = oProdSpecs.Uom_ID;
                    txtFinishGoodUOM.Uid = clsGenaralName.getName_Uom(oProdSpecs.Uom_ID);
                    txtFinishGoodUOM.Text = clsGenaralName.getName_UomAndCode(oProdSpecs.Uom_ID);

                    txtCustomer.Tag = oProdSpecs.Customer_ID;
                    txtCustomer.Text = oProdSpecs.Customer_ID == "default" ? "-" : clsGenaralName.getName_Customer(oProdSpecs.Customer_ID);
                }
            }
        }

        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails(lstResult[0]);
            }
        }

        private void txtCustomerInquiry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.CustomerInquary);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerInquiry.Tag = lstResult[0];
                txtCustomerInquiry.Text = lstResult[0];
            }
        }

        private void txtCustomerCOSO_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCustomer.Tag != null && txtCustomer.Text != "")
                lstParameeters.Add(txtCustomer.Tag.ToString());

            frm_search RowDataSearch = new frm_search(lstParameeters);
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_ProdCustomerOrder);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCOSO.Tag = lstResult[0];
                txtCustomerCOSO.Text = lstResult[0];

                txtCustomer.Tag = lstResult[2];
                txtCustomer.Uid = lstResult[3];
                txtCustomer.ToolTip = lstResult[3];
                txtCustomer.Text = lstResult[4];
                txtCustomer.IsEnabled = false;
            }
        }

        private void txtSalesMan_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.SalesRep);
            if (RowDataSearch.DialogResult == true)
            {
                txtSalesMan.Tag = lstResult[0];
                txtSalesMan.Text = lstResult[1];
            }
        }

        private void txtFinishGoodUOM_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishGoodUOM.Tag = lstResult[0];
                txtFinishGoodUOM.Uid = lstResult[2];
                txtFinishGoodUOM.Text = lstResult[1] + " - " + lstResult[2];
            }
        }

        #endregion

        #region Grid Events
        #region Main Grid Events

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock)?.Text;
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
                //Locked BoM
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[11].ToString()))
                {
                    e.Row.Foreground = (Brush)bc.ConvertFrom("#a0ffa0");
                }

                //Canceled BoM
                else if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[10].ToString()))
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

        #region Delivery Grid Events

        private void dgr_DeliveryPlan_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtDeliveryPlan);
        }

        private void dgr_DeliveryPlan_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string sColumnName = e.Column.SortMemberPath;
            int irowID = dgr_Main.SelectedIndex;
            TextBox t;
            if (sColumnName == "Qty")
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
            if (sColumnName == "Date")
            {
                t = e.EditingElement as TextBox;
                DateTime dtmTime = dtpProductionStart_Date.GetDateTime();
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

            CalculateTotalDeliveyQty();
        }

        #endregion
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

        private void txt_TextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtFinishGoodID_TextBox_TextChanged(object sender, EventArgs e)
        {
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
            UC_BOM_Production UC;
            if (txtProdJobID.Tag != null)
                UC = new UC_BOM_Production(txtProdJobID.Tag.ToString(), FormName.Prod_BOMDetails_Production);
            else
                UC = new UC_BOM_Production(FormName.Prod_BOMDetails_Production);
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            SW.ShowDialog();
        }
        #endregion

        #region Help Method
        private void CalculateTotalDeliveyQty()
        {
            try
            {
                string sSum = dtDeliveryPlan.AsEnumerable().Sum(x => decimal.Parse(x.Field<string>("Qty"))).ToString();
                txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(decimal.Parse(sSum.ToString()), clsConfig.sDecimalPlaces_Quantity);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Key Press Event
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
