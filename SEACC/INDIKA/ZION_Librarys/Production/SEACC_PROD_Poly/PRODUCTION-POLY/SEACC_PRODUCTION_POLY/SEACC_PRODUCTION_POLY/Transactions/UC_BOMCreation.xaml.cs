using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Common;
using SEACC_PRODUCTION_POLY.Search;
using SEACC_PRODUCTION_POLY.Transactions;
using SEACC_PRODUCTION_POLY.UserManagement;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEACC_PRODUCTION_POLY
{
    /// <summary>
    /// Developped By Gayan
    /// On 2017-10-06
    /// </summary>
    /// 
    public partial class UC_BOMCreation : UserControl
    {
        #region Class Variable
        DataTable dtDeliveryPlan = new DataTable();
        DataTable dt_Items = new DataTable();
        BrushConverter bc = new BrushConverter();
        #endregion

        #region Form Load
        public UC_BOMCreation()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_BOMCreation_Sales;
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
            dtDeliveryPlan.Columns.Add("Weight");
            dtDeliveryPlan.Columns.Add("WeightUoM_ID");
            dtDeliveryPlan.Columns.Add("WeightUoM");
            dtDeliveryPlan.Columns.Add("DeliveryTerms");
            #endregion

            #region Initialize Data Table
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
            SEACC_Form.SetVisibility_ActionButons(true, true, true, false, true, true);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Approved.Click += btn_Approved_click;
            SEACC_Form.btn_Print.Click += btn_Print_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn(ColoumnType.Numaric, "##", "##", 25, true, true);
            dgr_Main.Add_DatagridColoumn("BoM/Job#", "JOB#", 80);
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
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
                            if (oJob != null)
                            {
                                if (!oJob.IsLocked)
                                {
                                    tbl_prod_polyTxJobCard oOldJob = new tbl_prod_polyTxJobCard(
                                     oJob.ProdJob_ID, dtpProdJob_Date.GetDateTime(), cmbProdJobStatus.GetSelectedIndex(),
                                     txtSalesMan.Tag != null ? txtSalesMan.Tag.ToString() : "default",
                                     txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                     txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                     txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                     txtComments.Text,
                                     oJob.Remarks2,
                                     oJob.JobType_ID,
                                     oJob.ProdRange_ID,
                                     oJob.ProdCategory_ID,
                                     oJob.ProdSize_ID,
                                     oJob.Colour_ID,
                                     oJob.Item_ID_Previous,
                                     oJob.Item_ID_FG,
                                     txtFinishGoodUOMQty.Tag != null ? txtFinishGoodUOMQty.Tag.ToString() : "default",
                                     oJob.Item_Length, oJob.Item_Length_UoM_ID, oJob.Item_Width, oJob.Item_Weight_UoM_ID, oJob.Item_Height, oJob.Item_Height_UoM_ID, oJob.Item_Diameter, oJob.Item_Diameter_UoM_ID, oJob.Item_Radius, oJob.Item_Radius_UoM_ID, oJob.Item_Thickness, oJob.Item_Thickness_UoM_ID, oJob.Item_Weight,
                                     txtFinishGoodOrderedWeight.Tag != null ? txtFinishGoodOrderedWeight.Tag.ToString() : "default",
                                     clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedQty.Text),
                                     clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedWeight.Text),
                                     oJob.FGoodQty,
                                     oJob.FGoodWeight,
                                     oJob.WastePercent,
                                     oJob.WasteQty,
                                     oJob.WasteWeight,
                                     dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(),
                                     oJob.EstProdHrs,
                                     oJob.IsChecked1, oJob.IsChecked2, oJob.IsChecked2,
                                     oJob.IsApproved1, oJob.IsApproved2, oJob.IsApproved2,
                                     oJob.IsCanceled, oJob.IsLocked,
                                     oJob.CreateUser_ID, clsSecurity.UserIDLoged,
                                     oJob.Checked1User_ID, oJob.Checked2User_ID, oJob.Checked3User_ID,
                                     oJob.Approved1User_ID, oJob.Approved2User_ID, oJob.Approved3User_ID,
                                     oJob.CanceldUser_ID, oJob.LockedUser_ID,
                                     oJob.DateCreate, clsSecurity.getServerDateTime(), oJob.DateChecked1, oJob.DateChecked2, oJob.DateChecked3,
                                     oJob.DateApproved1, oJob.DateApproved2, oJob.DateApproved3,
                                     oJob.DateCanceled, oJob.DateLocked,
                                     oJob.CreateUserTerminal_ID, clsSecurity.TerminalID,
                                     oJob.Checked1UserTerminal_ID, oJob.Checked2UserTerminal_ID, oJob.Checked3UserTerminal_ID,
                                     oJob.Approved1UserTerminal_ID, oJob.Approved2UserTerminal_ID, oJob.Approved3UserTerminal_ID,
                                     oJob.CanceledUserTerminal_ID, oJob.LockedUserTerminal_ID, oJob.CompanyID, oJob.CompanyBranchID);
                                    oOldJob.Update();

                                    tbl_prod_polyTxJobCard_Delivery.DeleteAllByProdJob_ID(oJob.ProdJob_ID);
                                    foreach (DataRow row in dtDeliveryPlan.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        DateTime dtmDeliver = clsValidate.ValidateRowValue(row, "Date", clsValidation.defaultDateTime);
                                        int iBranch_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BranchNo", 0));
                                        string sDeliverAddress = clsValidate.ValidateRowValue(row, "Address", "");
                                        decimal dDeliverQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        decimal dWeight = clsValidate.ValidateRowValue(row, "Weight", 0);
                                        string sWeightUoM_ID = clsValidate.ValidateRowValue(row, "WeightUoM_ID", "default");
                                        string sDeliverTerms = clsValidate.ValidateRowValue(row, "DeliveryTerms", "");

                                        tbl_prod_polyTxJobCard_Delivery oNewDelivery = new tbl_prod_polyTxJobCard_Delivery(iLine_no, oJob.ProdJob_ID, dtmDeliver, iBranch_no, sDeliverAddress, dDeliverQty, dWeight, sUoM_ID, sWeightUoM_ID, sDeliverTerms, "");
                                        oNewDelivery.Insert();
                                    }
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Cannot Update..", "Selected BoM has already been locked", MessageBoxButton.OK, "Red");
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
                            decimal dLength = 0, dWidth = 0, dHeight = 0, dDiameter = 0, dRadius = 0, dThickness = 0, dWeight = 0;
                            string sLenghtUoM = "default", sWidthUoM = "default", sHeightUoM = "default", sDiameterUoM = "default", sRadiusUoM = "default", sThicknessUoM = "default", sWeightUoM = "default";
                            if (txtFinishedGood_ID.Tag != null)
                            {
                                tbl_prod_polyTxFinishedGoodSpecsSheet oFG_Item = tbl_prod_polyTxFinishedGoodSpecsSheet.Select(txtFinishedGood_ID.Tag.ToString());
                                if (oFG_Item != null)
                                {
                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oFG_Item.Item_ID_FG);
                                    tbl_zItemTag3 oProductSize = tbl_zItemTag3.Select(oFG_Item.Tag3_ID);
                                    if (oProductSize != null)
                                    {
                                        dLength = oProductSize.Length;
                                        dWidth = oProductSize.Width;
                                        dHeight = oProductSize.Height;
                                        dDiameter = oProductSize.Diameter;
                                        dRadius = oProductSize.Radius;
                                        dThickness = oProductSize.Thickness;

                                        sLenghtUoM = oProductSize.Uom_ID_length;
                                        sWidthUoM = oProductSize.Uom_ID_width;
                                        sHeightUoM = oProductSize.Uom_ID_height;
                                        sDiameterUoM = oProductSize.Uom_ID_diameter;
                                        sRadiusUoM = oProductSize.Uom_ID_radius;
                                        sThicknessUoM = oProductSize.Uom_ID_thickness;
                                    }

                                    dWeight = clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedWeight.Text);
                                    sWeightUoM = txtFinishGoodUOMWeight.Tag != null ? txtFinishGoodUOMWeight.Tag.ToString() : "default";

                                    tbl_prod_polyTxJobCard oNewJob = new tbl_prod_polyTxJobCard(
                                        txtProdJobID.Text, dtpProdJob_Date.GetDateTime(), cmbProdJobStatus.GetSelectedIndex(),
                                        txtSalesMan.Tag != null ? txtSalesMan.Tag.ToString() : "default",
                                        txtCustomer.Tag != null ? txtCustomer.Tag.ToString() : "default",
                                        txtCustomerInquiry.Tag != null ? txtCustomerInquiry.Tag.ToString() : "default",
                                        txtCustomerCOSO.Tag != null ? txtCustomerCOSO.Tag.ToString() : "default",
                                        txtComments.Text,
                                        "",//Remark 2
                                        oItem.ItemClass_ID,
                                        oItem.ItemType_ID,
                                        oItem.ItemCategory_ID,
                                        oFG_Item.Tag3_ID,
                                        oFG_Item.Colour_ID,//Colour
                                        txtJobTemplate.Tag != null ? txtJobTemplate.Tag.ToString() : "default",
                                        txtFinishedGood_ID.Tag.ToString(),
                                        txtFinishGoodUOMQty.Tag != null ? txtFinishGoodUOMQty.Tag.ToString() : "default",
                                        dLength, sLenghtUoM, dWidth, sWidthUoM, dHeight, sHeightUoM, dDiameter, sDiameterUoM, dRadius, sRadiusUoM, dThickness, sThicknessUoM, dWeight, sWeightUoM,
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedWeight.Text),
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedQty.Text),
                                        clsValidation.Validate_DecimalNumber(txtFinishGoodOrderedWeight.Text),
                                        0, 0, 0, dtpExFac_Date.GetDateTime(), dtpProductionStart_Date.GetDateTime(), 0,
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
                                        "default", "default", clsSecurity.CompanyID, clsSecurity.BranchID);
                                    oNewJob.Insert();

                                    foreach (DataRow row in dtDeliveryPlan.Rows)
                                    {
                                        int iLine_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "LineNo", 0));
                                        DateTime dtmDeliver = clsValidate.ValidateRowValue(row, "Date", clsValidation.defaultDateTime);
                                        int iBranch_no = Convert.ToInt32(clsValidate.ValidateRowValue(row, "BranchNo", 0));
                                        string sDeliverAddress = clsValidate.ValidateRowValue(row, "Address", "");
                                        decimal dDeliverQty = clsValidate.ValidateRowValue(row, "Qty", 0);
                                        string sUoM_ID = clsValidate.ValidateRowValue(row, "UoM_ID", "default");
                                        decimal dDevliverWeight = clsValidate.ValidateRowValue(row, "Weight", 0);
                                        string sWeightUoM_ID = clsValidate.ValidateRowValue(row, "WeightUoM_ID", "default");
                                        string sDeliverTerms = clsValidate.ValidateRowValue(row, "DeliveryTerms", "");

                                        tbl_prod_polyTxJobCard_Delivery oNewDelivery = new tbl_prod_polyTxJobCard_Delivery(iLine_no, txtProdJobID.Text, dtmDeliver, iBranch_no, sDeliverAddress, dDeliverQty, dDevliverWeight, sUoM_ID, sWeightUoM_ID, sDeliverTerms, "");
                                        oNewDelivery.Insert();
                                    }

                                    if (txtJobTemplate.Tag != null)
                                    {
                                        foreach (tbl_prod_polyTxJobCard_Material oMeterial in tbl_prod_polyTxJobCard_Material.SelectAllByProdJob_ID(txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_Material oNewMeterial = new tbl_prod_polyTxJobCard_Material(oMeterial.Line_No, oMeterial.Line_No_Sub1, oMeterial.Line_No_Sub2, txtProdJobID.Text, oMeterial.Item_ID, oMeterial.Uom_ID, oMeterial.Uom_ID_Weight,
                                                oMeterial.IsSemiFinishItem, oMeterial.InputQty, oMeterial.InputWeight, oMeterial.Consumption, oMeterial.IsWastagePercent, oMeterial.WastagePercent, oMeterial.WastageQty, oMeterial.TotalInputQty, oMeterial.Section_ID, oMeterial.Smv_TimeMinutes, oMeterial.TotalLabour,
                                                oMeterial.LowestCost, oMeterial.HighestCost, oMeterial.WeightedAvgCost, oMeterial.CostTypeSelection, oMeterial.Cost, oMeterial.AllowCostEdit);
                                            oNewMeterial.Insert();
                                        }

                                        foreach (tbl_prod_polyTxJobCard_Material_Outsource oSF_Outsource in tbl_prod_polyTxJobCard_Material_Outsource.SelectAll().Where(r => r.ProdJob_ID == txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_Material_Outsource oNewSF_Outsorce = new tbl_prod_polyTxJobCard_Material_Outsource(oSF_Outsource.Line_No, oSF_Outsource.Line_No_Sub1, oSF_Outsource.Line_No_Sub2, txtProdJobID.Text, oSF_Outsource.Item_ID, oSF_Outsource.Uom_ID, oSF_Outsource.Uom_ID_Weight, oSF_Outsource.Qty_Outsource, oSF_Outsource.Weight_Outsource, oSF_Outsource.Max_OutsourceRate, oSF_Outsource.Max_OutsourceCost);
                                            oNewSF_Outsorce.Insert();
                                        }

                                        foreach (tbl_prod_polyTxJobCard_Labour oLabour in tbl_prod_polyTxJobCard_Labour.SelectAllByProdJob_ID(txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_Labour oNewLabour = new tbl_prod_polyTxJobCard_Labour(oLabour.Line_No, txtProdJobID.Text, oLabour.ProdSection_ID, oLabour.ProdActivity_ID, oLabour.Shifts_Day, oLabour.ShiftMinutes_Day, oLabour.Labours_Day, oLabour.LabourRatePerHour_Day,
                                                oLabour.Shifts_Night, oLabour.ShiftMinutes_Night, oLabour.Labours_Night, oLabour.LabourRatePerHour_Night, oLabour.OhRatePerHour, oLabour.OtherCostRatePerHour, oLabour.ProdMinutes, oLabour.CostTotal);
                                            oNewLabour.Insert();
                                        }

                                        foreach (tbl_prod_polyTxJobCard_ProductionOperation oTxProdOperation in tbl_prod_polyTxJobCard_ProductionOperation.SelectAllByProdJob_ID(txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_ProductionOperation oNewTxOperation = new tbl_prod_polyTxJobCard_ProductionOperation(oTxProdOperation.Line_No, txtProdJobID.Text, oTxProdOperation.Operation_ID, oTxProdOperation.Smv_Per_Pc);
                                            oNewTxOperation.Insert();
                                        }

                                        foreach (tbl_prod_polyTxJobCard_CostCenter oProdCostCenter in tbl_prod_polyTxJobCard_CostCenter.SelectAllByProdJob_ID(txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_CostCenter oNewTxCostCenter = new tbl_prod_polyTxJobCard_CostCenter(oProdCostCenter.Line_No, txtProdJobID.Text, oProdCostCenter.Cost_Center_ID, oProdCostCenter.Smv, oProdCostCenter.Smv_rate, oProdCostCenter.Cost);
                                            oNewTxCostCenter.Insert();
                                        }

                                        foreach (tbl_prod_polyTxJobCard_CostFooter oCostFooter in tbl_prod_polyTxJobCard_CostFooter.SelectAllByProdJob_ID(txtJobTemplate.Tag.ToString()))
                                        {
                                            tbl_prod_polyTxJobCard_CostFooter oNewTxCostFooter = new tbl_prod_polyTxJobCard_CostFooter(oCostFooter.Line_No, txtProdJobID.Text, oCostFooter.Footer_ID, oCostFooter.Percentage, oCostFooter.Amount);
                                            oNewTxCostFooter.Insert();
                                        }
                                    }
                                    else
                                    {
                                        int iline = 0;
                                        foreach (tbl_prod_polyMasProductionOperation oProdOperation in tbl_prod_polyMasProductionOperation.SelectAll().Where(r => r.Operation_ID != "default"))
                                        {
                                            tbl_prod_polyTxJobCard_ProductionOperation oTxOperation = new tbl_prod_polyTxJobCard_ProductionOperation(++iline, txtProdJobID.Text, oProdOperation.Operation_ID, oProdOperation.Smv_Per_Pc);
                                            oTxOperation.Insert();
                                        }

                                        int iline2 = 0;
                                        foreach (tbl_prod_polyMasCostCenter oProdCostCenter in tbl_prod_polyMasCostCenter.SelectAll().Where(r => r.Cost_Center_ID != "default"))
                                        {
                                            tbl_prod_polyTxJobCard_CostCenter oTxCostCenter = new tbl_prod_polyTxJobCard_CostCenter(++iline2, txtProdJobID.Text, oProdCostCenter.Cost_Center_ID, 0, 0, 0);
                                            oTxCostCenter.Insert();
                                        }
                                    }

                                    Attachments.Insert(txtProdJobID.Tag.ToString());
                                    sProdJob_ID = oNewJob.ProdJob_ID;
                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                                }
                                else
                                {
                                    SEACCMessageBox.Show("Cannot Insert..", "Finished Good is not available in Finished Good Specification Sheet", MessageBoxButton.OK, "Red");
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
                    fillDetails(sProdJob_ID);
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
                    if (CheckValidity())
                    {
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Tag.ToString());
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
                                            oJob.ProdJobStatus = (int)prod_JobStatus.BoMProd;
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
                                    fillDetails(oJob.ProdJob_ID);
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
                    dtDeliveryPlan.Rows.Add("", dtpProdJob_Date.GetDateTime().AddDays(10).ToString(clsValidation.Format_Date), oCusBranch.Line_No, oCusBranch.BranchName, oCusBranch.Address, "0.000", txtFinishGoodUOMQty.Tag != null ? txtFinishGoodUOMQty.Tag.ToString() : "default", txtFinishGoodUOMQty.Uid, "0.000", txtFinishGoodUOMWeight.Tag != null ? txtFinishGoodUOMWeight.Tag.ToString() : "default", txtFinishGoodUOMWeight.Uid, "");
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

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalesMan, true, false, true);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtProdJobID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerInquiry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCOSO, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtComments, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtJobTemplate, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishedGood_ID, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedQty, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFinishGoodOrderedWeight, true, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOMQty, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtFinishGoodUOMWeight, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtTotalDeliveryOrderedQty, false, true);

            txtSalesMan.Tag = null;
            txtProdJobID.Tag = null;
            txtCustomer.Tag = null;
            txtCustomerInquiry.Tag = null;
            txtCustomerCOSO.Tag = null;
            txtFinishedGood_ID.Tag = null;
            txtFinishGoodUOMQty.Tag = null;
            txtFinishGoodUOMWeight.Tag = null;
            txtJobTemplate.Tag = null;

            txtFinishGoodUOMQty.Uid = "";
            txtFinishGoodUOMWeight.Uid = "";

            txtSalesMan.Text = "";
            txtProdJobID.Text = "";
            txtCustomer.Text = "";
            txtCustomerInquiry.Text = "";
            txtCustomerCOSO.Text = "";
            txtComments.Text = "";
            txtJobTemplate.Text = "";
            txtFinishedGood_ID.Text = "";
            txtFinishGoodUOMQty.Text = "";
            txtFinishGoodUOMWeight.Text = "";
            txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity); //"0.000";
            txtFinishGoodOrderedWeight.Text = cls_Formater.FormatDecimal(1, clsConfig.sDecimalPlaces_Quantity); //"0.000";
            txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(0, clsConfig.sDecimalPlaces_Quantity); //"0.000";;

            dtpExFac_Date.SetTime(DateTime.Now);
            dtpProdJob_Date.SetTime(DateTime.Now);
            dtpProductionStart_Date.SetTime(DateTime.Now);

            cmbProdJobStatus.IsEnabled = true;
            cmbProdJobStatus.comboBox.ItemsSource = clsHelpMethods_Prod.GetEnumDescription_List(typeof(Digiteq_Logic.prod_JobStatus));
            cmbProdJobStatus.SetSelectedIndex((int)prod_JobStatus.BoMSales);

            dtDeliveryPlan.Clear();
            dgr_DeliveryPlan.ItemsSource = dtDeliveryPlan.DefaultView;

            dtpProdJob_Date.IsEnabled = true;
            dtpExFac_Date.IsEnabled = true;
            dtpProductionStart_Date.IsEnabled = true;

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
                Cursor = Cursors.Wait;

                dgr_Main.dt.Clear();
                int iCount = 0;
                foreach (tbl_prod_polyTxJobCard oJob in tbl_prod_polyTxJobCard.SelectAll().Where(p => p.ProdJob_ID != "default" && p.ProdJobStatus != (int)prod_JobStatus.Obsolete).OrderByDescending(o => o.DateCreate))
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(oJob.Item_ID_FG);
                    if (oItem != null)
                    {
                        decimal dStockQty = clsProcessMethods.Get_StoreStockBalance_Qty_AllStores(oJob.Item_ID_FG, oItem.ItemCategorySub_ID, "default", "0", "0");
                        dgr_Main.dt.Rows.Add(++iCount, oJob.ProdJob_ID, oJob.ProdJobDate.ToString(clsValidation.Format_Date), clsGenaralName.getDescription_Item(oJob.Item_ID_FG), clsFormatter.FormatDecimalPlaces_Quantity(oJob.OrderedQty), clsFormatter.FormatDecimalPlaces_Quantity(dStockQty), clsGenaralName.getName_Customer(oJob.Customer_ID), clsGenaralName.getName_User(oJob.CreateUser_ID), clsGenaralName.getName_User(oJob.Approved1User_ID), oJob.IsCanceled);
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

            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtProdJobID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishedGood_ID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOMQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodOrderedQty))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodUOMWeight))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFinishGoodOrderedWeight))
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

                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(txtProdJobID.Text);
                if (oJob != null)
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
                Cursor = Cursors.Wait;

                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sID);
                if (oJob != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSalesMan.Tag = oJob.Salesman_ID;
                    txtProdJobID.Tag = oJob.ProdJob_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtFinishedGood_ID.Tag = oJob.Item_ID_FG;
                    txtJobTemplate.Tag = oJob.Item_ID_Previous;
                    txtFinishGoodUOMQty.Tag = oJob.Uom_ID;
                    txtFinishGoodUOMWeight.Tag = oJob.Item_Weight_UoM_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID.Trim());
                    txtFinishGoodUOMQty.Uid = clsGenaralName.getName_Uom(oJob.Uom_ID);
                    txtFinishGoodUOMWeight.Uid = clsGenaralName.getName_Uom(oJob.Item_Weight_UoM_ID);

                    txtSalesMan.Text = oJob.Salesman_ID == "default" ? "-" : clsGenaralName.getName_SalesRep(oJob.Salesman_ID);
                    txtProdJobID.Text = oJob.ProdJob_ID.Trim();
                    txtComments.Text = oJob.Remarks.Trim();
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID;
                    txtFinishedGood_ID.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtJobTemplate.Text = oJob.Item_ID_Previous == "default" ? "-" : oJob.Item_ID_Previous;
                    txtFinishGoodUOMQty.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodUOMWeight.Text = clsGenaralName.getName_UomAndCode(oJob.Item_Weight_UoM_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex(oJob.ProdJobStatus);

                    fillDeliveryGrid(oJob.ProdJob_ID, oJob.Customer_ID);

                    txtFinishGoodUOMQty.IsEnabled = false;
                    txtFinishGoodUOMWeight.IsEnabled = false;

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
                Cursor = Cursors.Wait;

                tbl_prod_polyTxJobCard oJob = tbl_prod_polyTxJobCard.Select(sID);
                if (oJob != null)
                {
                    txtSalesMan.Tag = oJob.Salesman_ID;
                    txtCustomer.Tag = oJob.Customer_ID;
                    txtCustomerInquiry.Tag = oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Tag = oJob.CustomerOrder_ID;
                    txtFinishedGood_ID.Tag = oJob.Item_ID_FG;
                    txtFinishGoodUOMQty.Tag = oJob.Uom_ID;
                    txtFinishGoodUOMWeight.Tag = oJob.Item_Weight_UoM_ID;

                    txtCustomer.Uid = clsGenaralName.getName_CustomerCode(oJob.Customer_ID.Trim());
                    txtFinishGoodUOMQty.Uid = clsGenaralName.getName_Uom(oJob.Uom_ID);
                    txtFinishGoodUOMWeight.Uid = clsGenaralName.getName_Uom(oJob.Item_Weight_UoM_ID);
                    txtFinishGoodUOMQty.Uid = clsGenaralName.getName_Uom(oJob.Uom_ID);

                    txtSalesMan.Text = oJob.Salesman_ID == "default" ? "-" : clsGenaralName.getName_SalesRep(oJob.Salesman_ID);
                    txtComments.Text = oJob.Remarks.Trim();
                    txtCustomer.Text = oJob.Customer_ID == "default" ? "-" : txtCustomer.Uid + " - " + clsGenaralName.getName_Customer(oJob.Customer_ID);
                    txtCustomerInquiry.Text = oJob.CustomerInquiry_ID == "default" ? "-" : oJob.CustomerInquiry_ID;
                    txtCustomerCOSO.Text = oJob.CustomerOrder_ID == "default" ? "-" : oJob.CustomerOrder_ID;
                    txtFinishedGood_ID.Text = clsGenaralName.getDescription_Item(oJob.Item_ID_FG);
                    txtFinishGoodUOMQty.Text = clsGenaralName.getName_UomAndCode(oJob.Uom_ID);
                    txtFinishGoodUOMWeight.Text = clsGenaralName.getName_UomAndCode(oJob.Item_Weight_UoM_ID);
                    txtFinishGoodOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);
                    txtTotalDeliveryOrderedQty.Text = cls_Formater.FormatDecimal(oJob.OrderedQty, clsConfig.sDecimalPlaces_Quantity);

                    dtpProdJob_Date.SetTime(oJob.ProdJobDate);
                    dtpExFac_Date.SetTime(oJob.ExfactoryDate);
                    dtpProductionStart_Date.SetTime(oJob.ProdStartDate);

                    cmbProdJobStatus.SetSelectedIndex((int)prod_JobStatus.BoMSales);

                    fillDeliveryGrid(oJob.ProdJob_ID, oJob.Customer_ID);
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

        private void fillDeliveryGrid(string sProdJob_ID, string sCustomer_ID)
        {
            dtDeliveryPlan.Clear();
            foreach (tbl_prod_polyTxJobCard_Delivery oJob_Delivery in tbl_prod_polyTxJobCard_Delivery.SelectAllByProdJob_ID(sProdJob_ID))
            {
                dtDeliveryPlan.Rows.Add("", oJob_Delivery.DeliverDateTime.ToString(clsValidation.Format_Date),
                    oJob_Delivery.CustomerBranch_Line_No,
                    clsGenaralName.getName_BranchCustomer(sCustomer_ID, oJob_Delivery.CustomerBranch_Line_No),
                    oJob_Delivery.DeliverAddress,
                    clsFormatter.FormatDecimalPlaces_Quantity(oJob_Delivery.DeliverQty), oJob_Delivery.Uom_Qty, clsGenaralName.getName_Uom(oJob_Delivery.Uom_Qty), clsFormatter.FormatDecimalPlaces_Quantity(oJob_Delivery.DeliverWeight), oJob_Delivery.Uom_Weight, clsGenaralName.getName_Uom(oJob_Delivery.Uom_Weight), oJob_Delivery.DeliverTerms);
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

        

        #region Grid Events
        #region Main Grid Events

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
            if (sColumnName == "Qty" || sColumnName == "Weight")
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

        private void dgr_Main_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(((DataRowView)(e.Row.DataContext)).Row.ItemArray[9].ToString()))
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

        #region Search Events

        private void UoM_search(SEACC_TextBox txtUoM)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtUoM.Tag = lstResult[0];
                txtUoM.Text = lstResult[1];
            }
        }

        private void txtProdJobID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
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
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProdCustomerOrder);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCOSO.Tag = lstResult[0];
                txtCustomerCOSO.Text = lstResult[0];

                txtCustomer.Tag = lstResult[2];
                txtCustomer.Uid = lstResult[3];
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
                txtFinishGoodUOMQty.Tag = lstResult[0];
                txtFinishGoodUOMQty.Uid = lstResult[2];
                txtFinishGoodUOMQty.Text = lstResult[1] + " - " + lstResult[2];
            }
        }

        private void txtJobTemplate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionBoMJobs);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails_fromPreviousJob(lstResult[0]);
                txtJobTemplate.Tag = lstResult[0];
                txtJobTemplate.Text = lstResult[0];
            }
        }

        private void txtFinishedGood_ID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_PolyProductionFinishedGoods);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishedGood_ID.Tag = lstResult[0];
                txtFinishedGood_ID.Text = lstResult[3];

                tbl_prod_polyTxFinishedGoodSpecsSheet oProdSpecs = tbl_prod_polyTxFinishedGoodSpecsSheet.Select(lstResult[0]);
                if (oProdSpecs != null)
                {
                    txtFinishGoodUOMQty.Tag = oProdSpecs.Uom_ID;
                    txtFinishGoodUOMQty.Uid = clsGenaralName.getName_Uom(oProdSpecs.Uom_ID);
                    txtFinishGoodUOMQty.Text = clsGenaralName.getName_UomAndCode(oProdSpecs.Uom_ID);

                    txtFinishGoodUOMWeight.Tag = oProdSpecs.Uom_ID_Weight;
                    txtFinishGoodUOMWeight.Uid = clsGenaralName.getName_Uom(oProdSpecs.Uom_ID_Weight);
                    txtFinishGoodUOMWeight.Text = clsGenaralName.getName_UomAndCode(oProdSpecs.Uom_ID_Weight);

                    txtCustomer.Tag = oProdSpecs.Customer_ID;
                    txtCustomer.Text = oProdSpecs.Customer_ID == "default" ? "-" : clsGenaralName.getName_Customer(oProdSpecs.Customer_ID);
                }
            }
        }

        private void txtFinishGoodUOMWeight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtFinishGoodUOMWeight.Tag = lstResult[0];
                txtFinishGoodUOMWeight.Uid = lstResult[2];
                txtFinishGoodUOMWeight.Text = lstResult[1] + " - " + lstResult[2];
            }
        }

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.CustomerList);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Uid = lstResult[2];
                txtCustomer.Text = lstResult[1];

                txtCustomerCOSO.Tag = null;
                txtCustomerCOSO.Text = "";
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

        private void txtFinishGoodID_TextBox_TextChanged(object sender, EventArgs e)
        {
            /* This is commented by Gayan
             * on 2017-05-30
             * Meeting Discussion Result
             */
            //pop_Items.IsOpen = true;
            //string sFinalQuary = "";

            //sFinalQuary = " ItemDescription LIKE '%" + txtFinishGoodDescription.TextBox1.Text + "%'";

            //try
            //{
            //    dt_Items.DefaultView.RowFilter = sFinalQuary;
            //    if (dgr_Items.Items.Count < 1)
            //        pop_Items.IsOpen = false;
            //}
            //catch (Exception ex)
            //{
            //    SEACCExeption.Show(ex);
            //}
        }

        #endregion

        #region Other Events
        private void lblNextUI_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_BOMDetails UC;
            if (txtProdJobID.Tag != null)
                UC = new UC_BOMDetails(txtProdJobID.Tag.ToString(), FormName.Prod_BOMDetails_Production);
            else
                UC = new UC_BOMDetails(FormName.Prod_BOMDetails_Production);
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

        #region Key Event
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
