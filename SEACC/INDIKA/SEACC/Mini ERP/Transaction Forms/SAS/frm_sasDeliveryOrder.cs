using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Zion.ERP.Reports.DataSets.SAS;
using Zion.ERP.Reports.DataSets;

using SEACC.DATA.Data;
using SEACC.DATA.Data.SAS;
using SEACC.DATA.Domain;
using SEACC.DATA.Data.SCS;
using SEACC.DATA.Data.MAS;
using ZION.ERP.Reports.DataSets.SAS;
//using Microsoft.Office.Interop.Word;

namespace Digiteq
{
    public partial class frm_sasDeliveryOrder : SEACC_Form
    {
         

        bool isTemp = false;
        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbCustomerOrderID = "", glbDeliveryOrderID = "", glbSalesRep = "";

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;

        //Data Set
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_DeliveryOrders glb_dts_DeliveryOrders = new dts_DeliveryOrders();

        //for handle Duplicate Item  Validations
        public DataTable dt_ItemGrouped = new DataTable();
    
        SasDeliveryOrder_data data = new SasDeliveryOrder_data();
        InventoryTxnData oData = new InventoryTxnData();
        RouteLockData routeValidation = new RouteLockData();
        clsAlerts_Email email = new clsAlerts_Email();
        #region Form Load
        public frm_sasDeliveryOrder(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
            bHasPermissionToLineDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_LineDiscount));
        }

        private void frm_sasCustomerDeliveryOrder_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();

            ClearFields();
        //    dgvDetail.Columns["carton_no"].Visible = clsConfig.bCartonNo_GridViewColumn;
            dgvDetail.Columns["Weight"].Visible = clsConfig.bShowQtyANDWeightColumns_DO;
            //CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
            CusDataGirdViewFormatForWeight(dgvGenaral, !chkUnitPricing.Checked, "GenWeight", "GenQuantity");

            if (glbCustomerOrderID.Length > 0)
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(glbCustomerOrderID);
                if (detail != null)
                {
                    txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                    txtCustomerOrderID.Text = detail.CustomerOrder_ID;

                    btnAddCustomerOrder_Click(sender, new EventArgs());
                }
            }
            else if (glbDeliveryOrderID.Length > 0)
                FillDetails(glbDeliveryOrderID);
        }
        #endregion

        #region Btn New
        private void frm_sasDeliveryOrder_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbcChequeManagement.SelectedTab == tbpGenaral)
                {
                    if (dgvDetail.SelectedCells.Count != 0)
                    {
                        if (dgvDetail.Rows.Count > 0)
                        {
                            dgvDetail.Rows.RemoveAt(dgvDetail.SelectedCells[0].RowIndex);
                            CalcualteSubTotal();
                            CalculateTaxesAndGrandTotal();
                        }
                    }
                }
                else if (tbcChequeManagement.SelectedTab == tbpBreakdown)
                {
                    if (dgvBreakdown.SelectedCells.Count != 0)
                    {
                        if (dgvBreakdown.Rows.Count > 0)
                            dgvBreakdown.Rows.RemoveAt(dgvBreakdown.SelectedCells[0].RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void frm_sasDeliveryOrder_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                bool bstatus = false;
                try
                {
                    Cursor = Cursors.WaitCursor;

                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    if (true)
                    {
                     
                        var parm = new SEACC.DATA.Domain.SAS.Para_DeliveryOrder_Save();
                        parm.Detail = new List<SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail>();
                        #region Insert Header
                        parm.Header = new SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder();

                        parm.Header.deliveryOrder_ID = txtDeliveryOrderID.Text.Trim();
                        parm.Header.deliveryOrderDate = dtpDODate.Value;
                        parm.Header.remark = txtRemark.Text.Trim();
                        parm.Header.deliveryAddress = txtAddress.Text.Trim();
                        parm.Header.vehicle_No = txtVehicalNo.Text;
                        parm.Header.dateIn = clsSecurity.getServerDateTime();
                        parm.Header.dateOut = dtpTimeOut.Value;
                        parm.Header.customerDeliveryDate = dtpReceivedDate.Value;
                        parm.Header.receiptBy = txtReceiptBy.Text.Trim();
                        parm.Header.customer_ID = txtCustomerID.Tag.ToString();
                        parm.Header.customerOrder_ID = txtCustomerOrderID.Tag.ToString();
                        parm.Header.quotation_ID = txtQuotationID.Tag.ToString();
                        parm.Header.job_ID = txtJobCode.Tag.ToString();
                        parm.Header.driver_ID = txtDriverID.Tag.ToString();
                        parm.Header.vehicle_ID = txtVehicleID.Tag.ToString();
                        parm.Header.assitant_ID = txtAssistantID.Tag.ToString();
                        parm.Header.store_ID = "default";
                        parm.Header.employee_ID = txtSalesExecutiveID.Tag.ToString();
                        parm.Header.orderRefNo_ID = glbOrderRefNo;
                        parm.Header.currency_ID = txtCurrencyID.Tag.ToString();
                        parm.Header.salesNoteType_ID = txtSalesNoteType.Tag.ToString();
                        parm.Header.currencyRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        parm.Header.discountPercentage = decimal.Parse(txtPercentageDiscount.Text.Trim());
                        parm.Header.nbtPercentage = decimal.Parse(txtPercentageNBT.Text.Trim());
                        parm.Header.vatPercentage = decimal.Parse(txtPercentageVat.Text.Trim());
                        parm.Header.otherTaxPercentage = decimal.Parse(txtPercentageOtherTax.Text.Trim());
                        parm.Header.subTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate);
                        parm.Header.discountTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate);
                        parm.Header.nbtTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate);
                        parm.Header.vatTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate);
                        parm.Header.otherTaxTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate);
                        parm.Header.grandTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate);
                        parm.Header.isWeightCalculation = !chkUnitPricing.Checked;
                        parm.Header.isTaxReverseCalulation = chkReverseCalculation.Checked;
                        parm.Header.isFreeOrder = chkFreeOrder.Checked;
                        parm.Header.isVAT = clsHelpMethods.isTaxActiveNote(txtVat);
                        parm.Header.isSVAT = clsHelpMethods.isTaxActiveNote(txtOtherTax);
                        parm.Header.batchNo = txtBatchNo.Text.Trim();
                        parm.Header.branch_ID = txtCustomerBranchID.Tag.ToString();
                        parm.Header.isReplacementOrder = chkIsReplasement.Checked;
                        parm.Header.itemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                        parm.Header.companyID = clsSecurity.CompanyID;
                        parm.Header.companyBranch_ID = clsSecurity.BranchID;
                        parm.Header.route_ID = int.Parse(lblRoute.Tag.ToString());
                        #endregion

                        #region Insert Detail
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {                          
                            try
                            {
                                var item = new SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail();

                                item.line_No = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                                            item.deliveryOrder_ID = txtDeliveryOrderID.Text.Trim();
                                item.item_ID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                item.customerOrder_ID = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default");
                                item.quotation_ID = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                item.job_ID = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                item.packingUom_ID = "default";
                                item.carton_No = clsValidate.ValidateGridValue(dgvDetail, "carton_no", row.Index, "");
                                item.qty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                item.weight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                item.unitPrice = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                item.weightPrice = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                item.bIsFreeItem = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                item.discountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                item.discountAmount = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));
                                item.tatalAmount = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                item.remark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                item.isWeightCalculation = !chkUnitPricing.Checked;
                                item.store_ID = clsValidate.ValidateGridTag(dgvDetail, "store_ID", row.Index, "");

                         
                                parm.Detail.Add(item);
                            }
                            catch (Exception ex)
                            {
                                clsValidate.WriteErrorLog("", iFormID, ex);
                                SEACCException.Show(ex);
                            }
                        }
                        #endregion

                        parm.User_ID = clsSecurity.UserIDLoged;
                        parm.Terminal_ID = clsSecurity.TerminalID;
                        parm.IsUpdate = IsUpdate;
                        parm.configForm_ID = sFormConfigCode;

                        var result=       data.Save_DO(parm);
                        if (result.IsSuccess)
                        {
                            txtDeliveryOrderID.Text = result.ReturnValue;

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {

                        #region Update
                        if (IsUpdate)
                        {
                            tbl_sasDeliveryOrder oldRecord = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                            if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                            {
                                if (ValidateForDependancies(oldRecord.DeliveryOrder_ID))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtDeliveryOrderID.Text))
                                    {
                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                        {
                                            if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                            {

                                                {
                                                 //   List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();
                                                    //Write Audit Trial Log
                                                    clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder), oldRecord.DeliveryOrder_ID, "Delivery Order");

                                                    #region Update Breakdown

                                                    int Gen_LineNo = -1;
                                                    string Gen_ItemID = "default",
                                                        sItemSubCategoryID = "",
                                                        sItemSubCategoryID2 = "",
                                                        sItemSerialNo = "",
                                                        sItemSerialNo2 = "";
                                                    decimal Gen_TotWeight = 0, Gen_TotQty = 0;
                                                    bool Gen_HasABreakdown = false;

                                                    if (dgvGenaral.SelectedRows.Count > 0)
                                                    {
                                                        int sRow = dgvGenaral.SelectedRows[0].Index;
                                                        Gen_LineNo =
                                                            clsValidate.ValidateGridValue(dgvGenaral, "GenLineNo", sRow, -1);
                                                        Gen_ItemID = clsValidate.ValidateGridValue(dgvGenaral, "GenItemCode",
                                                            sRow, "default");
                                                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvGenaral,
                                                            "gItemSubCategoryID", sRow, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvGenaral,
                                                            "gItemSubCategoryID2", sRow, "default");
                                                        sItemSerialNo = clsValidate.ValidateGridValue(dgvGenaral,
                                                            "gItemSerialNo", sRow, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvGenaral,
                                                            "gItemSerialNo2", sRow, "0");
                                                    }

                                                    tbl_sasDeliveryOrder_DetailBreakdown
                                                        .DeleteAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(
                                                            txtDeliveryOrderID.Text.Trim(), Gen_ItemID,
                                                            sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                            sItemSerialNo2);

                                                    foreach (DataGridViewRow row in dgvBreakdown.Rows)
                                                    {
                                                        try
                                                        {
                                                            string sItemCode = "", sSerialNo = "", sRemark = "";
                                                            decimal dQuantity = 0, dWeight = 0;
                                                            int iLineNo = '0';

                                                            iLineNo = clsValidate.ValidateGridValue(dgvBreakdown, "BrkLineNo",
                                                                row.Index, int.Parse("-1"));
                                                            sItemCode = clsValidate.ValidateGridValue(dgvBreakdown,
                                                                "BrkItemCode", row.Index, "");
                                                            sSerialNo = clsValidate.ValidateGridValue(dgvBreakdown,
                                                                "BrkSerialNo", row.Index, "");
                                                            dQuantity = clsValidate.ValidateGridValue(dgvBreakdown,
                                                                "BrkQuantity", row.Index, decimal.Parse("0.00"));
                                                            dWeight = clsValidate.ValidateGridValue(dgvBreakdown, "BrkWeight",
                                                                row.Index, decimal.Parse("0.00"));
                                                            sRemark = clsValidate.ValidateGridValue(dgvBreakdown, "BrkRemarks",
                                                                row.Index, "");

                                                            if (clsConfig.sSoftwareModel.Trim() ==
                                                                SoftwareModel_Sales.akt.ToString())
                                                            {
                                                                decimal dPack = clsValidate.ValidateGridValue(dgvBreakdown,
                                                                    "BrkSerialNo", row.Index, decimal.Parse("0.00"));
                                                                Gen_TotQty += dQuantity * dPack;
                                                                if (oldRecord.IsWeightCalculation)
                                                                    Gen_TotWeight += dWeight * dPack * dQuantity;

                                                                else
                                                                {
                                                                    dWeight = clsValidate.ValidateGridValue(dgvBreakdown,
                                                                        "BrkItemName", row.Index, decimal.Parse("0.00"));
                                                                    Gen_TotWeight += dWeight;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Gen_TotQty += dQuantity;
                                                                Gen_TotWeight += dWeight;
                                                            }

                                                            if (sItemCode.Length > 0)
                                                            {
                                                                tbl_sasDeliveryOrder_DetailBreakdown items =
                                                                    new tbl_sasDeliveryOrder_DetailBreakdown(row.Index, iLineNo,
                                                                        txtDeliveryOrderID.Text.Trim(), sItemCode,
                                                                        sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                                        sItemSerialNo2, sSerialNo, dQuantity, dWeight, sRemark, "");

                                                                items.Insert();
                                                                Gen_HasABreakdown = true;
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            SEACCException.Show(ex);
                                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                                        }
                                                    }

                                                    #endregion

                                                    #region rollback StoreStock

                                                    foreach (tbl_sasDeliveryOrder_Detail oUpdatedRecore in
                                                        tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(
                                                            txtDeliveryOrderID.Text.Trim()))
                                                    {
                                                        decimal dWeightedAverageCostPrice = 0;
                                                        //clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                        //    oldRecord.DeliveryOrder_ID, oldRecord.DeliveryOrderDate,
                                                        //    oUpdatedRecore.Item_ID, "0", txtStoreID.Tag.ToString(),
                                                        //    oUpdatedRecore.Qty, oUpdatedRecore.Weight,
                                                        //    oUpdatedRecore.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);

                                                        oUpdatedRecore.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecore.Item_ID);
                                                        oUpdatedRecore.Update();
                                                    }

                                                    #endregion

                                                    #region Update Detail

                                                    if (Gen_HasABreakdown)
                                                    {
                                                        foreach (DataGridViewRow dRow in dgvDetail.Rows)
                                                        {
                                                            if (dgvDetail["ItemCode", dRow.Index].Value.ToString() ==
                                                                Gen_ItemID &&
                                                                dgvDetail["ItemSubCategoryID", dRow.Index].Tag.ToString() ==
                                                                sItemSubCategoryID &&
                                                                dgvDetail["ItemSubCategoryID2", dRow.Index].Tag.ToString() ==
                                                                sItemSubCategoryID2 &&
                                                                dgvDetail["ItemSerialNo", dRow.Index].Value.ToString() ==
                                                                sItemSerialNo &&
                                                                dgvDetail["ItemSerialNo2", dRow.Index].Value.ToString() ==
                                                                sItemSerialNo2)
                                                            {
                                                                dgvDetail["Quantity", dRow.Index].Value = Gen_TotQty;
                                                                dgvDetail["Weight", dRow.Index].Value = Gen_TotWeight;
                                                                DataGridViewCellEventArgs ar =
                                                                    new DataGridViewCellEventArgs(
                                                                        dgvDetail["Quantity", dRow.Index].ColumnIndex,
                                                                        dRow.Index);
                                                                dgvDetail_CellEndEdit(sender, ar);
                                                            }
                                                        }
                                                    }

                                                    #region Delete all DO Detail
                                                    foreach (tbl_sasDeliveryOrder_Detail oldDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim()))
                                                    {
                                                        #region Update Customer Order

                                                        if (oldDoDetail.CustomerOrder_ID != "default" &&
                                                            !oldDoDetail.HasBreakdown)
                                                        {
                                                            tbl_sasCustomerOrder_Detail CoItem =
                                                                tbl_sasCustomerOrder_Detail.Select(oldDoDetail.Line_No,
                                                                    oldDoDetail.CustomerOrder_ID, oldDoDetail.Item_ID,
                                                                    oldDoDetail.ItemSubCategory_ID,
                                                                    oldDoDetail.ItemSubCategory2_ID, oldDoDetail.ItemSerialNo,
                                                                    oldDoDetail.ItemSerialNo2);
                                                            if (CoItem != null)
                                                            {
                                                                if (chkUnitPricing.Checked)
                                                                    CoItem.QtySettle_DeliveryOrder =
                                                                        CoItem.QtySettle_DeliveryOrder - oldDoDetail.Qty;
                                                                else
                                                                    CoItem.WeightSettle_DeliveryOrder =
                                                                        CoItem.WeightSettle_DeliveryOrder - oldDoDetail.Weight;
                                                                CoItem.Update();
                                                            }

                                                            clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(
                                                                oldDoDetail.CustomerOrder_ID, chkUnitPricing);
                                                        }

                                                        #endregion

                                                        if (!oldDoDetail.HasBreakdown)
                                                            oldDoDetail.Delete();
                                                        else
                                                            MessageBox.Show(
                                                                "Item: " + clsGenaralName.getName_Item(oldDoDetail.Item_ID) +
                                                                " Contain Breakdown Data!" + Environment.NewLine +
                                                                "So Cannot Modify this Item", clsFormatter.GetMessageCaption(),
                                                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                    }
                                                    #endregion

                                                    #region Insert Newly Added Detail
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        int iLineNo = 0;
                                                        string
                                                            sItemCode = "",
                                                            sUom = "default",
                                                            sCusOrderCode = "",
                                                            sQuotationCode = "",
                                                            sJobCode = "",
                                                            sRemarks = "",
                                                            sCartonNo = "";
                                                        decimal dWidth = 0,
                                                            dHeight = 0,
                                                            dGauge = 0,
                                                            dGusset = 0,
                                                            dWeightPrice = 0,
                                                            dUnitPrice = 0,
                                                            dQuantity = 0,
                                                            dWeight = 0,
                                                            dAmount = 0,
                                                            dRecommendedUnitPrice = 0,
                                                            dRecommendedWeightPrice = 0,
                                                            dRecommendedAmount = 0,
                                                            dDiscountPresentage = 0,
                                                            dDiscountValue = 0;
                                                        bool bIsFreeIssue = false;

                                                        iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                            row.Index, "");
                                                        sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode",
                                                            row.Index, "default");
                                                        sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,
                                                            "QuotationCode", row.Index, "default");
                                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                            row.Index, "default");
                                                        dWidth = clsValidate.ValidateGridValue(dgvDetail, "Width", row.Index,
                                                            decimal.Parse("0.00"));
                                                        dHeight = clsValidate.ValidateGridValue(dgvDetail, "Height", row.Index,
                                                            decimal.Parse("0.00"));
                                                        dGauge = clsValidate.ValidateGridValue(dgvDetail, "Gauge", row.Index,
                                                            decimal.Parse("0.00"));
                                                        dGusset = clsValidate.ValidateGridValue(dgvDetail, "Gusset", row.Index,
                                                            decimal.Parse("0.00"));
                                                        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice",
                                                            row.Index, decimal.Parse("0.00"));
                                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                            row.Index, decimal.Parse("0.00"));
                                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                            decimal.Parse("0.00"));
                                                        sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index,
                                                            "default");
                                                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
                                                            row.Index, decimal.Parse("0.00"));

                                                        bIsFreeIssue =
                                                            clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") ==
                                                            "True"
                                                                ? true
                                                                : false;
                                                        dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail,
                                                            "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                                        dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue",
                                                            row.Index, decimal.Parse("0.00"));

                                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index,
                                                            decimal.Parse("0.00"));
                                                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail,
                                                            "ItemSubCategoryID", row.Index, "default");
                                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail,
                                                            "ItemSubCategoryID2", row.Index, "default");
                                                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo",
                                                            row.Index, "0");
                                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail,
                                                            "ItemSerialNo2", row.Index, "0");
                                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks",
                                                            row.Index, "");
                                                        sCartonNo = clsValidate.ValidateGridValue(dgvDetail, "carton_no",
                                                            row.Index, "");
                                                        dRecommendedUnitPrice =
                                                            clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode,
                                                                sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                                sItemSerialNo2, txtCustomerID.Tag.ToString());
                                                        dRecommendedWeightPrice =
                                                            clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                                        if (chkUnitPricing.Checked)
                                                            dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                                        else
                                                            dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                                        //Get Unit Price with Exchange rate to save
                                                        dUnitPrice =
                                                            clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                        dWeightPrice =
                                                            clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                                        dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                                        if (sItemCode.Length > 0)
                                                        {
                                                            tbl_sasDeliveryOrder_Detail items = new tbl_sasDeliveryOrder_Detail(
                                                                iLineNo, txtDeliveryOrderID.Text.Trim(), sItemCode,
                                                                sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                                                sCusOrderCode, sQuotationCode, sJobCode,
                                                                txtbrk_PackingUom.Tag.ToString(), sCartonNo, dQuantity, 0, 0, 0,
                                                                dWeight, 0, 0, 0,
                                                                dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage,
                                                                dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                                                dRecommendedWeightPrice, dRecommendedAmount, sRemarks, false,
                                                                !chkUnitPricing.Checked, false, 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                            items.Insert();

                                                            #region Update Customer Order
                                                            if (sCusOrderCode != "default")
                                                            {
                                                                tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(iLineNo, sCusOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                                if (CoItem != null && CoItem.CustomerOrder_ID != "default")
                                                                {
                                                                    if (chkUnitPricing.Checked)
                                                                        CoItem.QtySettle_DeliveryOrder += dQuantity;
                                                                    else
                                                                        CoItem.WeightSettle_DeliveryOrder += dWeight;
                                                                    CoItem.Update();
                                                                }

                                                                clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(
                                                                    sCusOrderCode, chkUnitPricing);
                                                            }
                                                            #endregion

                                                            #region Pass Value to Inventory Detail
                                                         //   tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtDeliveryOrderID.Text.Trim(), dtpDODate.Value,
                                                         //                               "", "", "", "", txtCustomerID.Tag.ToString(), "default", txtStoreID.Tag.ToString(),
                                                         //                               sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                                         ////   oListInventory.Add(oInventoryDetail);
                                                            #endregion

                                                        }
                                                    }
                                                    #endregion

                                                    //*************
                                                    #endregion

                                                    #region Update Header

                                                    tbl_sasDeliveryOrder dDetail = new tbl_sasDeliveryOrder(
                                                        txtDeliveryOrderID.Text.Trim(), dtpDODate.Value, txtRemark.Text.Trim(),
                                                        txtAddress.Text.Trim(), txtVehicalNo.Text,
                                                        clsSecurity.getServerDateTime(), dtpTimeOut.Value,
                                                        dtpReceivedDate.Value, txtReceiptBy.Text.Trim(),
                                                        txtCustomerID.Tag.ToString(),
                                                        txtCustomerOrderID.Tag.ToString(), txtQuotationID.Tag.ToString(),
                                                        txtJobCode.Tag.ToString(), txtDriverID.Tag.ToString(),
                                                        txtVehicleID.Tag.ToString(),
                                                        txtAssistantID.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                        txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo,
                                                        oldRecord.CancelReason_ID_DO,
                                                        txtCurrencyID.Tag.ToString(), oldRecord.GlPosting_ID,
                                                        oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID,
                                                        txtSalesNoteType.Tag.ToString(),
                                                        decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                        decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                                        decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                        decimal.Parse(txtPercentageVat.Text.Trim()),
                                                        decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                        clsHelpMethods_Local.getSavePrice(
                                                            decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(
                                                            decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()),
                                                            txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()),
                                                            txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(
                                                            decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(
                                                            decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate),
                                                        decimal.Parse(txtSubTotal_Rec.Text.Trim()),
                                                        decimal.Parse(txtGrandTotal_Rec.Text.Trim()), oldRecord.CreateUser_ID,
                                                        clsSecurity.UserIDLoged,
                                                        oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                        oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                        oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                        oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                        oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                                        glbApprovedDate, clsSecurity.getServerDateTime(),
                                                        clsSecurity.getServerDateTime(), oldRecord.IsChecked,
                                                        oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                                        oldRecord.IsLocked, oldRecord.IsSeattled, !chkUnitPricing.Checked,
                                                        oldRecord.PrintCount, oldRecord.IsPriceEnabled,
                                                        chkReverseCalculation.Checked,
                                                        chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat),
                                                        clsHelpMethods.isTaxActiveNote(txtOtherTax), txtBatchNo.Text.Trim(),
                                                        txtCustomerBranchID.Tag.ToString(), chkIsReplasement.Checked,
                                                        ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, oldRecord.CompanyID,
                                                        oldRecord.CompanyBranch_ID, int.Parse(lblRoute.Tag.ToString()));
                                                    dDetail.Update();

                                                    #endregion

                                                    #region Update Store Stock

                                                    foreach (tbl_sasDeliveryOrder_Detail oUpdatedRecord in
                                                        tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(
                                                            txtDeliveryOrderID.Text.Trim()))
                                                    {
                                                        decimal dWeightedAverageCostPrice = 0;
                                                        //decimal dCostFifo = clsHelpMethods_Local.UpdateStoreStock(iFormID,
                                                        //    dDetail.DeliveryOrder_ID, dDetail.DeliveryOrderDate,
                                                        //    oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(),
                                                        //    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                        //    oUpdatedRecord.TatalAmount, false, false, false, ref dWeightedAverageCostPrice);

                                                        //oUpdatedRecord.Cost_FIFO = dCostFifo;
                                                        oUpdatedRecord.Update();
                                                    }

                                                    #endregion

                                                    #region Update Inventory
                                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDeliveryOrderID.Text.Trim(), dtpDODate.Value, txtRemark.Text.Trim(),
                                                    //    txtCustomerID.Tag.ToString(), "default", txtSalesNoteType.Tag.ToString(), int.Parse(lblRoute.Tag.ToString()), decimal.Parse(txtGrandTotal.Text.Trim()),
                                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                                    #endregion

                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    isTemp = false;
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCode, txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID);
                            if (clsValidate.CheckValidity_TransactionCodeLength(txtDeliveryOrderID.Text)) //if (txtDeliveryOrderID.Text.Trim().Length > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                            {
                                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                if (oDO == null)
                                {
                                 //   List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                    if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                    {
                                        glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                                        tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-", "default", txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                                        orf.Insert();
                                    }

                                    var data = new SasDeliveryOrder_data();

                                    #region Insert Header
                                    var parm = new SEACC.DATA.Domain.SAS.Para_DeliveryOrder_Save();

                                    //      var detail = new SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder();
                                    parm.Header = new SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder();

                                    parm.Header.deliveryOrder_ID = txtDeliveryOrderID.Text.Trim();
                                    parm.Header.deliveryOrderDate = dtpDODate.Value;
                                    parm.Header.remark = txtRemark.Text.Trim();
                                    parm.Header.deliveryAddress = txtAddress.Text.Trim();
                                    parm.Header.vehicle_No = txtVehicalNo.Text;
                                    parm.Header.dateIn = clsSecurity.getServerDateTime();
                                    parm.Header.dateOut = dtpTimeOut.Value;
                                    parm.Header.customerDeliveryDate = dtpReceivedDate.Value;
                                    parm.Header.receiptBy = txtReceiptBy.Text.Trim();
                                    parm.Header.customer_ID = txtCustomerID.Tag.ToString();
                                    parm.Header.customerOrder_ID = txtCustomerOrderID.Tag.ToString();
                                    parm.Header.quotation_ID = txtQuotationID.Tag.ToString();
                                    parm.Header.job_ID = txtJobCode.Tag.ToString();
                                    parm.Header.driver_ID = txtDriverID.Tag.ToString();
                                    parm.Header.vehicle_ID = txtVehicleID.Tag.ToString();
                                    parm.Header.assitant_ID = txtAssistantID.Tag.ToString();
                                    parm.Header.store_ID = txtStoreID.Tag.ToString();
                                    parm.Header.employee_ID = txtSalesExecutiveID.Tag.ToString();
                                    parm.Header.orderRefNo_ID = glbOrderRefNo;
                                    parm.Header.currency_ID = txtCurrencyID.Tag.ToString();
                                    parm.Header.salesNoteType_ID = txtSalesNoteType.Tag.ToString();
                                    parm.Header.currencyRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                                    parm.Header.discountPercentage = decimal.Parse(txtPercentageDiscount.Text.Trim());
                                    parm.Header.nbtPercentage = decimal.Parse(txtPercentageNBT.Text.Trim());
                                    parm.Header.vatPercentage = decimal.Parse(txtPercentageVat.Text.Trim());
                                    parm.Header.otherTaxPercentage = decimal.Parse(txtPercentageOtherTax.Text.Trim());
                                    parm.Header.subTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate);
                                    parm.Header.discountTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate);
                                    parm.Header.nbtTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate);
                                    parm.Header.vatTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate);
                                    parm.Header.otherTaxTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate);
                                    parm.Header.grandTotal = clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate);
                                    parm.Header.isWeightCalculation = !chkUnitPricing.Checked;
                                    parm.Header.isTaxReverseCalulation = chkReverseCalculation.Checked;
                                    parm.Header.isFreeOrder = chkFreeOrder.Checked;
                                    parm.Header.isVAT = clsHelpMethods.isTaxActiveNote(txtVat);
                                    parm.Header.isSVAT = clsHelpMethods.isTaxActiveNote(txtOtherTax);
                                    parm.Header.batchNo = txtBatchNo.Text.Trim();
                                    parm.Header.branch_ID = txtCustomerBranchID.Tag.ToString();
                                    parm.Header.isReplacementOrder = chkIsReplasement.Checked;
                                    parm.Header.itemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                                    parm.Header.companyID = clsSecurity.CompanyID;
                                    parm.Header.companyBranch_ID = clsSecurity.BranchID;
                                    parm.Header.route_ID = int.Parse(lblRoute.Tag.ToString());

                                    #endregion

                                    #region Insert Detail
                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                    {
                                        //to do
                                        //line discount for F/C txn
                                        //write a sql function to get recomended price

                                        //tbl_audFifoTransaction calc
                                        //tbl_scsInventoryTxnDetail
                                        //save mesege
                                        //serial no

                                        try
                                        {
                                            var item = new SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail();

                                            item.line_No = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                            item.deliveryOrder_ID = txtDeliveryOrderID.Text.Trim();
                                            item.item_ID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                            item.customerOrder_ID = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default");
                                            item.quotation_ID = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                            item.job_ID = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                            item.packingUom_ID = "default";
                                            item.carton_No = clsValidate.ValidateGridValue(dgvDetail, "carton_no", row.Index, "");
                                            item.qty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                            item.weight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                            item.unitPrice = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                            item.weightPrice = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                            item.bIsFreeItem = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                            item.discountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                            item.discountAmount = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));
                                            item.tatalAmount = clsHelpMethods_Local.getSavePrice(clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00")), txtCurrencyRate);
                                            item.remark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                            item.isWeightCalculation = !chkUnitPricing.Checked;

                                            parm.Detail = new List<SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail>();
                                            parm.Detail.Add(item);

                                            //int iLineNo = 0;
                                            //string sItemCode = "", sCusOrderCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sCartonNo = "";//sUom = "default",
                                            //decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0, dDiscountPresentage = 0, dDiscountValue = 0;//dWidth = 0, dHeight = 0, dGauge = 0, dGusset = 0,
                                            //bool bIsFreeIssue = false;

                                            //iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, 0);
                                            //sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                            //sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default");
                                            //sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                            //sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                            //dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                            //dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                            //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                            //dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                                            //bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                            //dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                            //dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                                            //dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                            //sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                            //sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                            //sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                            //sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                            //sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                            //sCartonNo = clsValidate.ValidateGridValue(dgvDetail, "carton_no", row.Index, "");
                                            // dRecommendedUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtCustomerID.Tag.ToString());
                                            //dRecommendedWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                            //if (chkUnitPricing.Checked)
                                            //    dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                            //else
                                            //    dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                            ////Get Unit Price with Exchange rate to save
                                            //dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                            //dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                            //dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                            //if (sItemCode.Trim().Length > 0)
                                            //{
                                            //    tbl_sasDeliveryOrder_Detail items = new tbl_sasDeliveryOrder_Detail(iLineNo, txtDeliveryOrderID.Text.Trim(), sItemCode, sItemSubCategoryID,
                                            //        sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, sCusOrderCode, sQuotationCode, sJobCode, "default", sCartonNo, dQuantity, 0, 0, 0, dWeight, 0, 0, 0,
                                            //         dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, false, !chkUnitPricing.Checked, false, 0, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                            //    items.Insert();

                                            //#region Update Customer Order
                                            //if (sCusOrderCode != "default")
                                            //{
                                            //    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(iLineNo, sCusOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                            //    if (CoItem != null)
                                            //    {
                                            //        if (chkUnitPricing.Checked)
                                            //            CoItem.QtySettle_DeliveryOrder += dQuantity;
                                            //        else
                                            //            CoItem.WeightSettle_DeliveryOrder += dWeight;
                                            //        CoItem.Update();
                                            //        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(sCusOrderCode, chkUnitPricing);
                                            //    }
                                            //}
                                            //   #endregion

                                            //      decimal dWeightedAverageCostPrice = 0;

                                            // decimal dCostFifo = clsHelpMethods_Local.UpdateStoreStock(iFormID, detail.deliveryOrder_ID, detail.deliveryOrderDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQuantity, dWeight, items.TatalAmount, false, false, false, ref dWeightedAverageCostPrice);

                                            //    items.Cost_FIFO = dCostFifo;
                                            //   items.Update();

                                            //#region Pass Value to Inventory Detail
                                            //tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, iLineNo, 0, txtDeliveryOrderID.Text.Trim(), dtpDODate.Value,
                                            //                            "", "", "", "", txtCustomerID.Tag.ToString(), "default", txtStoreID.Tag.ToString(),
                                            //                            sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), 0, dQuantity, dUnitPrice, 0, false);
                                            //oListInventory.Add(oInventoryDetail);
                                            //#endregion
                                            // }
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        }
                                    }
                                    #endregion
                                    parm.User_ID = clsSecurity.UserIDLoged;
                                    parm.Terminal_ID = clsSecurity.TerminalID;
                                    data.Save_DO(parm);



                                    Attachments.Insert(txtDeliveryOrderID.Text.ToString());

                                    #region Update Inventory
                                    //tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtDeliveryOrderID.Text.Trim(), dtpDODate.Value, txtRemark.Text.Trim(),
                                    //    txtCustomerID.Tag.ToString(), "default", txtSalesNoteType.Tag.ToString(), int.Parse(lblRoute.Tag.ToString()), decimal.Parse(txtGrandTotal.Text.Trim()),
                                    //    "", "", "", "", false, clsSecurity.UserIDLoged);

                                    //clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                    #endregion

                                    email.Email_DO(txtDeliveryOrderID.Text.Trim(), enum_Alerts.DeliveryOrderCreate);
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("This ID is already added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    bstatus = false;
                                }
                            }
                            //else
                            //    MessageBox.Show("Delivery Order " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion}

                    }
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    if (!bstatus)
                    {
                        tbl_sasDeliveryOrder oldRecord = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                        if (oldRecord != null)
                            FillDetails(txtDeliveryOrderID.Text.Trim());
                    }
                }
            }
        }
        #endregion

        #region Btn Option
        private void frm_sasDeliveryOrder_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.DeliveryOrder_ID))
                                    {
                                        if (!detail.IsLocked)
                                        {
                                            if (!detail.IsDeleted)
                                            {
                                                frmCancel_DO frm = new frmCancel_DO();
                                                frm.glbNoteID = "D/O Number : " + txtDeliveryOrderID.Text.Trim();
                                                frm.ShowDialog();

                                                if (frm.glbValied)
                                                {
                                                    //Update Other Tables
                                                    #region Update Other Tables
                                                    foreach (var Dodetail in tbl_sasDeliveryOrder_Detail_Ex.SelectAllByDeliveryOrder_ID2(txtDeliveryOrderID.Text.Trim()))
                                                    {
                                                        if (Dodetail.Item_ID != null)
                                                        {
                                                            #region Unsettle Customer Order

                                                            #region Get Canceled Reson Properties
                                                            bool bTotalCancel = false;
                                                            if (frm.glbSystemReson)
                                                            {
                                                                tbl_zCancelReson_DO cancelDO = tbl_zCancelReson_DO.Select(frm.glbSystemResonID);
                                                                if (cancelDO != null)
                                                                {
                                                                    if (cancelDO.IsPermanentCancel)
                                                                        bTotalCancel = true;
                                                                    else if (cancelDO.IsRepeatDelivery)
                                                                        bTotalCancel = false;
                                                                }
                                                            }
                                                            else
                                                                bTotalCancel = true;
                                                            #endregion

                                                            if (Dodetail.CustomerOrder_ID != null && Dodetail.CustomerOrder_ID != "default")
                                                            {
                                                                if (bTotalCancel)
                                                                {
                                                                    tbl_sasCustomerOrder cOrder = tbl_sasCustomerOrder.Select(Dodetail.CustomerOrder_ID);
                                                                    if (cOrder != null)
                                                                    {
                                                                        cOrder.IsSeattled = true;
                                                                        cOrder.Update();
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(Dodetail.Line_No, Dodetail.CustomerOrder_ID, Dodetail.Item_ID,
                                                                        Dodetail.ItemSubCategory_ID, Dodetail.ItemSubCategory2_ID, Dodetail.ItemSerialNo, Dodetail.ItemSerialNo2);
                                                                    if (CoItem != null)
                                                                    {
                                                                        if (!Dodetail.IsWeightCalculation)
                                                                            CoItem.QtySettle_DeliveryOrder -= Dodetail.Qty;
                                                                        else
                                                                            CoItem.WeightSettle_DeliveryOrder -= Dodetail.Weight;
                                                                        CoItem.Update();
                                                                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(Dodetail.CustomerOrder_ID, chkUnitPricing);
                                                                    }
                                                                }
                                                            }
                                                            #endregion

                                                            #region Update Store Stock
                                                            decimal dWeightedAverageCostPrice = 0;
                                                          //  clsHelpMethods_Local.UpdateStoreStock(iFormID, Dodetail.DeliveryOrder_ID, detail.DeliveryOrderDate, Dodetail.Item_ID, "0", Dodetail.store_ID, Dodetail.Qty, Dodetail.Weight, Dodetail.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);

                                                            Dodetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(Dodetail.Item_ID);
                                                            Dodetail.Update();
                                                            //   clsHelpMethods_Local.RollBackFifo_Stock(iFormID, Dodetail.DeliveryOrder_ID, Dodetail.Qty);
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion

                                                    if (frm.glbSystemReson)
                                                        detail.CancelReason_ID_DO = frm.glbSystemResonID;
                                                    else
                                                        detail.CancelReason_ID_DO = "default";

                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();
                                                    detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                    detail.IsDeleted = true;
                                                    detail.DateModified = clsSecurity.getServerDateTime();
                                                    detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.Update();

                                                    //  clsHelpMethods.Delete_Inventory(iFormID, 0, txtDeliveryOrderID.Text.Trim());
                                                    var responce = oData.Delete_InventoryTxn(iFormID, txtDeliveryOrderID.Text.Trim());
                                                    if (!responce.IsSuccess)
                                                    {
                                                        clsValidate.WriteErrorLog(txtDeliveryOrderID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                                    }

                                                

                                                    email.Email_DO(txtDeliveryOrderID.Text.Trim(), enum_Alerts.DeliveryOrderCancel);
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    ClearFields();
                                                }
                                            }
                                            else
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Btn Print
        private void frm_sasDeliveryOrder_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasDeliveryOrder_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_sasDeliveryOrder_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasDeliveryOrder_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasDeliveryOrder_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Add Quotation
        private void btnAddQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Length > 0)
                {
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                    if (detail != null)
                    {
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;

                        //fill customer, branch and route
                        FillDetailsCustomer(detail.Customer_ID);
                        if (detail.Branch_ID != "default")
                        {
                            tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(detail.Customer_ID, int.Parse(detail.Branch_ID));
                            if (oBranch != null)
                            {
                                txtCustomerBranchID.Text = oBranch.BranchName;
                                txtCustomerBranchID.Tag = detail.Branch_ID;

                                lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(oBranch.Route_ID);
                                lblRoute.Tag = oBranch.Route_ID;
                            }
                        }

                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();

                        //add item details
                        RefreshGridByQuotationID(detail.Quotation_ID);
                        btnAddCustomerOrder.Enabled = false;
                        btnAddQuotation.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Add Customer Order
        private void btnAddCustomerOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerOrderID.Tag != null && txtCustomerOrderID.Tag.ToString().Length > 0)
                {
                    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Tag.ToString());
                    if (detail != null)
                    {
                        tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                        if (customer != null && !customer.IsDeleted)
                        {
                            chkUnitPricing.Checked = !detail.IsWeightCalculation;
                            chkFreeOrder.Checked = detail.IsFreeOrder;

                            FillDetailsCustomer(detail.Customer_ID);

                            tbl_zOrderRefNo orf = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                            if (orf != null)
                            {
                                txtSalesExecutiveID.Tag = orf.Employee_ID;
                                txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(orf.Employee_ID);
                            }

                            if (detail.Branch_ID != "default")
                            {
                                tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(detail.Customer_ID, int.Parse(detail.Branch_ID));
                                if (oBranch != null)
                                {
                                    txtCustomerBranchID.Text = oBranch.BranchName;
                                    txtCustomerBranchID.Tag = detail.Branch_ID;

                                    lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(oBranch.Route_ID);
                                    lblRoute.Tag = oBranch.Route_ID;
                                }
                            }

                            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerOrderID, false);

                            glbCustomerOrderID = detail.CustomerOrder_ID;
                            glbOrderRefNo = detail.OrderRefNo_ID;
                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                            txtJobCode.Tag = clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID);
                            txtJobCode.Text = clsCommon.GetForeignKeyValue(clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID));

                            txtStoreID.Tag = detail.Store_ID;
                            txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);

                            dtpReceivedDate.Value = detail.DeliveryDate;

                            if (clsConfig.sSoftwareModel != SoftwareModel_Sales.ePackWithSubCategory.ToString())
                            {
                                txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                                txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                            }

                            if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                            {
                                foreach (ComboBoxItem d in cmbItemPrice.Items)
                                {
                                    if (d.Value == detail.ItemPriceCategory)
                                    {
                                        cmbItemPrice.SelectedItem = d;
                                        break;
                                    }
                                }
                            }

                            //add currency detail
                            FillDetailsCurrency(detail.Currency_ID);
                            txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                            FillTaxDetailByCustomerOrderID(detail.CustomerOrder_ID);

                            RefreshGridByCustomerOrderID(detail.CustomerOrder_ID);

                            btnAddCustomerOrder.Enabled = false;
                            btnAddQuotation.Enabled = false;
                        }
                        else
                        {
                            txtCustomerOrderID.Tag = null;
                            txtCustomerOrderID.Text = "";
                            MessageBox.Show("Sorry...! \nCannot Raised Delivery Order for Deactivated Customers", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Add JobCode
        private void btnAddJobCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
                {
                    //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtJobCode.Tag.ToString());
                    //if (detail != null)
                    //{
                    //    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(detail.CustomerOrder_ID);
                    //    if (oCO != null && oCO.CustomerOrder_ID != "default")
                    //    {
                    //        txtCustomerOrderID.Tag = oCO.CustomerOrder_ID;
                    //        txtCustomerOrderID.Text = oCO.CustomerOrder_ID;

                    //        btnAddCustomerOrder_Click(sender, e);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Tag.ToString().Trim());
                    if (detail != null)
                    {
                        if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0 && txtCustomerID.Tag.ToString().Trim() != "default")
                        {
                            if (clsValidate.Validate_CustomerWise_ItemPricing_Enable(txtCustomerID.Tag.ToString().Trim(), detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim()))
                            {
                                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                                clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                                RefreshGridByItemID(detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim());
                            }
                        }
                        else
                            MessageBox.Show("Please Select The Customer Before Add Items", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Customer Viewer
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            {
                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                frm.glbCustomerID = txtCustomerID.Tag.ToString();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    frm.Show();
            }
        }
        #endregion

        #region Btn Temp
        private void frm_sasDeliveryOrder_SF_tempButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                {
                    //set the flag and enble the id
                    isTemp = true;

                    IsUpdate = false;
                    tbcChequeManagement.SelectedTab = tbpGenaral;

                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesExecutiveID, clsConfig.bEnableSalesman_DO);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerOrderID, true);

                    clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

                    txtDeliveryOrderID.Tag = null;
                    dtpDODate.Value = clsSecurity.getServerDateTime();

                    //Reset User Details
                    bHasApproved = false;
                    bHasChecked = false;
                    userDetailsColorChanges();

                    //Reset Order Ref No
                    txtOrderRefNo.Tag = null;
                    txtOrderRefNo.Clear();
                    glbOrderRefNo = "";

                    //Reset Primary Key
                    clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID, IsUpdate);

                    if (txtDeliveryOrderID.Enabled)
                    {
                        txtDeliveryOrderID.SelectAll();
                        txtDeliveryOrderID.Focus();
                    }

                    Attachments.Clear();
                    ucSasProcessFlow.ClearFlow();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Create Invoice
        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Tag.ToString());
                    if (detail != null && detail.DeliveryOrder_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledDeliveryOrder)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Delivery Order Before Create an Invoice";
                            }
                        }
                        if (clsConfig.bSettleEnabledDeliveryOrder)
                        {
                            if (detail.IsSeattled)
                            {
                                bAllowDetail = false;
                                message = "ALREADY INVOICED \n\nInvoice(s) have been already Generated to this Delivery Order";
                            }
                        }

                        if (bAllowDetail)
                        {
                            int iFormID_Inv2 = (int)FormName.SalesInvoice2;
                            tbl_securityFormMaster oForm = tbl_securityFormMaster.Select(iFormID_Inv2);
                            if (oForm.IsEnable == true)
                            {
                                frm_sasInvoice2 frm = new frm_sasInvoice2((FormName)iFormID_Inv2);
                                frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                                frm.glbOrderRefNo = detail.OrderRefNo_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                            else
                            {
                                FormName fornName = FormName.VATInvoice;
                                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, (int)FormName.Invoice_TAXReverced, false, false))
                                    fornName = FormName.Invoice_TAXReverced;

                                frm_sasInvoice frm = new frm_sasInvoice(fornName);
                                frm.glbDeliveryOrderID = detail.DeliveryOrder_ID;
                                frm.glbOrderRefNo = detail.OrderRefNo_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                        }
                        else
                            MessageBox.Show(message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
          //  clsFormatter.ApplyGridFormatModify(dgvBreakdown, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
         //  clsFormatter.ApplyGridFormat(dgvGenaral, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);
           
            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            dgvDetail.Columns["store_ID"].Width = 78;
            //Grid Locks
            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_DO ? true : false;
            dgvDetail.Columns["Quantity"].ReadOnly = clsConfig.bEnableGridLock_Quantity_DO ? true : false;

            dgvDetail.Columns["Free"].Visible = clsConfig.bShowGrid_FreeColumn_DO; // free column hide

            if (bHasPermissionToLineDiscount)
            {
                dgvDetail.Columns["DiscuntPresentage"].ReadOnly = false;
                dgvDetail.Columns["DiscountValue"].ReadOnly = false;
            }
            else
            {
                dgvDetail.Columns["DiscuntPresentage"].ReadOnly = true;
                dgvDetail.Columns["DiscountValue"].ReadOnly = true;
            }
            dgvDetail.Columns["Free"].ReadOnly = true;

        }
        private void CusDataGirdViewFormatForCalucation(DataGridView dgv, bool bWeightCalculation)
        {
            if (bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = true;
                dgv.Columns["WeightPrice"].Visible = true;
                dgv.Columns["Quantity"].Visible = false;
                dgv.Columns["UnitPrice"].Visible = false;
            }
            else if (!bWeightCalculation)
            {
                dgv.Columns["Weight"].Visible = false;
                dgv.Columns["WeightPrice"].Visible = false;
                dgv.Columns["Quantity"].Visible = true;
                dgv.Columns["UnitPrice"].Visible = true;
            }

            if (clsConfig.bPriceDetailsHide_DeliveryOrder)
            {
                dgvDetail.Columns["UnitPrice"].Visible = false;
                dgvDetail.Columns["WeightPrice"].Visible = false;
                dgvDetail.Columns["DiscuntPresentage"].Visible = false;
                dgvDetail.Columns["DiscountValue"].Visible = false;
                dgvDetail.Columns["Amount"].Visible = false;

                dgvDetail.Columns["RowCount"].Width = 20;
                dgvDetail.Columns["ItemCode"].Width = 100;
                dgvDetail.Columns["ItemName"].Width = 310;
                dgvDetail.Columns["Free"].Width = 40;
                dgvDetail.Columns["Quantity"].Width = 90;
                z2.Visible = false;
              //  zpanalNoPrice.Visible = true;
            }

        }
        private void CusDataGirdViewFormatForWeight(DataGridView dgv, bool bWeightCalculation, string sWeight, string sQty)
        {
            if (bWeightCalculation)
            {
                dgv.Columns[sWeight].Visible = true;
                dgv.Columns[sQty].Visible = false;

            }
            else if (!bWeightCalculation)
            {
                dgv.Columns[sWeight].Visible = false;
                dgv.Columns[sQty].Visible = true;
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            isTemp = false;

            IsUpdate = false;
            x2.Enabled = true;
            lblCancelled.Visible = false;
            tbcChequeManagement.SelectedTab = tbpGenaral;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesExecutiveID, clsConfig.bEnableSalesman_DO);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

            txtDeliveryOrderID.Tag = null;
            txtCustomerID.Tag = null;
            txtCustomerOrderID.Tag = null;
            txtQuotationID.Tag = null;
            txtDriverID.Tag = null;
            txtAssistantID.Tag = null;
            txtVehicleID.Tag = null;
            txtJobCode.Tag = null;
            txtStoreID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtOrderRefNo.Tag = null;
            lblRoute.Tag = null;
            txtTownID.Tag = null;
            txtCustomerBranchID.Tag = null;
            txtSalesNoteType.Tag = null;

            lblRoute.Text = "";
            txtOrderRefNo.Clear();
            glbOrderRefNo = "";
            txtTownID.Clear();
            txtSalesExecutiveID.Clear();
            txtStoreID.Clear();
            txtItemID.Clear();
            txtCustomerID.Clear();
            txtCustomerOrderID.Clear();
            txtQuotationID.Clear();
            txtDriverID.Clear();
            txtJobCode.Clear();
            txtAssistantID.Clear();
            txtVehicleID.Clear();
            txtAddress.Clear();
            txtReceiptBy.Clear();
            txtRemark.Clear();
            txtVehicalNo.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtBatchNo.Clear();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkFreeOrder.Checked = true;
            chkPrintWithAmounts.Checked = false;
            chkPrintWithBreakdown.Checked = false;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;
            chkIsReplasement.Checked = false;

            btnBarcode.Visible = false;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            btnAddCustomerOrder.Enabled = true;
            btnAddQuotation.Enabled = true;
            dt_ItemGrouped.Clear();

            dtpDODate.Enabled = !clsConfig.bLock_TransactionDate_SAS;

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            lblInquiryID.Visible = false;
            txtJobCode.Visible = false;
            btnAddJobCode.Visible = false;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            txtCustomerBranchID.Clear();
            txtSalesNoteType.Clear();

            dtpDateOut.Value = clsSecurity.getServerDateTime();
            dtpDODate.Value = clsSecurity.getServerDateTime();
            dtpReceivedDate.Value = clsSecurity.getServerDateTime();

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
            txtSubTotal.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtVat.Text = "0.00";
            txtGrandTotal.Text = "0.00";

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;

            txtbrk_WeightGeneral.Clear();
            txtbrk_QtyGeneral.Clear();
            dgvDetail.Rows.Clear();
            dgvGenaral.Rows.Clear();

            ClearFieldBreakdown();
            DisableMoneyControls();

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;
            chkDiscount.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;

            if (clsConfig.bHide_PriceCategory_DO)
            {
                cmbItemPrice.Visible = false;
                label37.Visible = false;
            }
            if (clsConfig.bHide_Fields_DO)
            {
                txtItemID.Visible = false;
                label15.Visible = false;
                btnF5.Visible = false;
                btnAddItem.Visible = false;
                txtCurrencyID.Visible = false;
                label23.Visible = false;
           //     label22.Visible = false;
                txtCurrencyRate.Visible = false;
                txtCurrencyCode.Visible = false;
            }

            if (!clsConfig.bDO_HideSettingsPanel)
            {
           //   //  zPanelNoSettings.Visible = false;
           //     chkSettings2.Visible = true;
            }

            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID, IsUpdate);

            if (txtDeliveryOrderID.Enabled)
            {
                txtDeliveryOrderID.SelectAll();
                txtDeliveryOrderID.Focus();
            }

            if (clsConfig.bHideBreakDownDetail_DO)
                tbcChequeManagement.TabPages.Remove(tbpBreakdown);

            ucSasProcessFlow.ClearFlow();
            Attachments.Clear();
        }
        #endregion

        #region Clear Fields Breakdown
        private void ClearFieldBreakdown()
        {
            txtbrk_PackingUom.Tag = null;
            txtbrk_PackingUom.Clear();
            txtbrk_QtyBreakdown.Clear();

            txtbrk_QtyPack.Clear();
            txtbrk_WeightBreakdown.Clear();

            dgvBreakdown.Rows.Clear();
            dgvBreakdown.Rows.Add();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sDeliveryOrderID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                var details = data.SelectAllByDeliveryOrder_ID(sDeliveryOrderID).OrderBy(p => p.line_No).ToList();
                foreach (SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail_View detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.item_ID);
                    if (item != null)
                    {
                        decimal dCOQty = 0;
                        tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrderID);
                        if (oDO.CustomerOrder_ID != "default" && oDO.CustomerOrder_ID != null)
                        {
                            List<tbl_sasCustomerOrder_Detail> coDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oDO.CustomerOrder_ID).Where(p => p.Item_ID == detail.item_ID).ToList();
                            dCOQty = coDetails.FirstOrDefault().Qty;
                        }

                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;

                        Fill_Datagrid(true, iRow, detail.line_No, detail.item_ID, detail.customerOrder_ID, detail.quotation_ID, detail.job_ID, item.Uom_ID, detail.unitPrice, detail.weightPrice, detail.bIsFreeItem, detail.discountPresentage, detail.discountAmount, detail.tatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.weight, dCOQty, detail.qty, "O", 
                         //   detail.itemSubCategory_ID, detail.itemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                            detail.remark, detail.carton_No, bHasSettledBefore, dExRate,detail.store_ID,detail.storeName);
                        if (detail.isLocked)
                            dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = clsCommon.ColourForLockedRecord;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

        }
        private void RefreshGridBreakdownGenaral(string sDeliveryOrderID)
        {
            try
            {
                int iRow;
                dgvGenaral.Rows.Clear();

               var details = tbl_sasDeliveryOrder_Detail_Ex.SelectAllByDeliveryOrder_ID2(sDeliveryOrderID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasDeliveryOrder_Detail detail in details)
                {
                    dgvGenaral.Rows.Add();
                    iRow = dgvGenaral.Rows.Count - 1;
                    dgvGenaral["GenLineNo", iRow].Value = detail.Line_No.ToString();
                    dgvGenaral["GenItemCode", iRow].Value = detail.Item_ID;
                    dgvGenaral["GenItemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvGenaral["GenUOMPacking", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(detail.PackingUom_ID));
                    dgvGenaral["GenUOMPacking", iRow].Tag = detail.PackingUom_ID;
                    dgvGenaral["GenWeight", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                    dgvGenaral["GenQuantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);

                    dgvGenaral["gItemSubCategoryID", iRow].Tag = detail.ItemSubCategory_ID;
                    dgvGenaral["gItemSubCategoryID", iRow].Value = clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID);
                    dgvGenaral["gItemSubCategoryID2", iRow].Tag = detail.ItemSubCategory2_ID;
                    dgvGenaral["gItemSubCategoryID2", iRow].Value = clsGenaralName.getName_ItemSubCategory2(detail.ItemSubCategory2_ID);
                    dgvGenaral["gItemSerialNo", iRow].Value = detail.ItemSerialNo;
                    dgvGenaral["gItemSerialNo2", iRow].Value = detail.ItemSerialNo2;


                    if (detail.IsLocked)
                        dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = clsCommon.ColourForLockedRecord;
                }
                if (dgvGenaral.SelectedRows.Count > 0)
                {
                    FillDetailBreakdown_General(dgvGenaral);

                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvBreakdown.Columns["BrkWeight"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);
                            dgvBreakdown.Columns["BrkWeight"].ReadOnly = true;
                            dgvBreakdown.Columns["BrkItemName"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                            dgvBreakdown.Columns["BrkItemName"].ReadOnly = false;
                        }
                        else
                        {
                            dgvBreakdown.Columns["BrkWeight"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Window);
                            dgvBreakdown.Columns["BrkWeight"].ReadOnly = false;
                            dgvBreakdown.Columns["BrkItemName"].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control);
                            dgvBreakdown.Columns["BrkItemName"].ReadOnly = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridBreakdownDetail(string sDeliveryOrderID, int iLineNo, string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sItemSerialNo, string sItemSerialNo2)
        {
            try
            {
                int iRow;
                dgvBreakdown.Rows.Clear();

                List<tbl_sasDeliveryOrder_DetailBreakdown> details = tbl_sasDeliveryOrder_DetailBreakdown.SelectAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(
                    sDeliveryOrderID, sItemID, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasDeliveryOrder_DetailBreakdown detail in details)
                {
                    if (detail.Line_No == iLineNo && detail.Item_ID == sItemID)
                    {
                        dgvBreakdown.Rows.Add();
                        iRow = dgvBreakdown.Rows.Count - 1;
                        dgvBreakdown["BrkLineNo", iRow].Value = detail.Line_No.ToString();
                        dgvBreakdown["BrkSerialNo", iRow].Value = detail.SerialNo;
                        dgvBreakdown["BrkRemarks", iRow].Value = detail.Remark;
                        dgvBreakdown["BrkItemCode", iRow].Value = detail.Item_ID;
                        dgvBreakdown["BrkWeight", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                        dgvBreakdown["BrkQuantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())//For AKT
                        {
                            decimal dTmpQty = clsValidate.ValidateGridValue(dgvBreakdown, "BrkQuantity", iRow, decimal.Parse("0.00"));
                            decimal dTmpWeight = clsValidate.ValidateGridValue(dgvBreakdown, "BrkWeight", iRow, decimal.Parse("0.00"));
                            decimal dTmpPack = clsValidate.ValidateGridValue(dgvBreakdown, "BrkSerialNo", iRow, decimal.Parse("0.00"));
                            decimal dTmpWeightTotal = dTmpWeight * dTmpQty * dTmpPack;
                            dgvBreakdown["BrkItemName", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dTmpWeightTotal);

                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrderID);
                            if (oDO != null && !oDO.IsWeightCalculation)
                            {
                                dgvBreakdown["BrkWeight", iRow].Value = "N/A";
                                dgvBreakdown["BrkItemName", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                            }
                        }
                    }
                }
                dgvBreakdown.Rows.Add();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByCustomerOrderID(string sCustomerOrderID)
        {
            try
            {
                int iRow;
                List<tbl_sasCustomerOrder_Detail> details = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasCustomerOrder_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        string store_ID = "", Store_Name = "";

                        if (clsConfig.bDisplay_DeliveredQuantity_DeliveryOrderItems)
                            if (detail.Qty <= 0)
                                continue;

                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle_DeliveryOrder > 0 || detail.WeightSettle_DeliveryOrder > 0)
                            bHasSettledBefore = true;

                        //var responce = data.GetAvailableStore(detail.Item_ID, detail.Qty);
                        //if (responce.IsSuccess)
                        //{ 
                        //    store_ID = responce.Value1;
                        //    Store_Name = responce.Value2;
                        //}

                        Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.CustomerOrder_ID, detail.Quotation_ID, "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_DeliveryOrder), detail.Qty, (detail.Qty - detail.QtySettle_DeliveryOrder), "N",
                          //  detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                            detail.Remark, "", bHasSettledBefore, dExRate, store_ID,Store_Name);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByQuotationID(string sQuotaion)
        {
            try
            {
                int iRow;
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotaion).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasQuotation_Detail detail in details)
                {
                    string store_ID = "", Store_Name = "";

                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle_CustomerOrder > 0 || detail.WeightSettle_CustomerOrder > 0)
                            bHasSettledBefore = true;

                        //var responce = data.GetAvailableStore(detail.Item_ID, detail.Qty);
                        //if (responce.IsSuccess)
                        //{
                        //    store_ID = responce.Value1;
                        //    Store_Name = responce.Value2;
                        //}

                        Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, "default", detail.Quotation_ID, "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_CustomerOrder), 0, (detail.Qty - detail.QtySettle_CustomerOrder), "N",
                          //  detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
                            detail.Remark, "", bHasSettledBefore, dExRate, store_ID, Store_Name);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItemID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
                string store_ID = "", Store_Name = "";

                int iRoute = int.Parse(lblRoute.Tag.ToString());
                int iRow;
                string sCustomerID = txtCustomerID.Tag != null ? txtCustomerID.Tag.ToString().Trim() : "";

                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemID);
                if (detail != null && oItemF != null)
                {
                    decimal dExRate = 0;
                    if (txtCurrencyRate.Text.Trim().Length > 0)
                        dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = 1, dAmount = oItemF.SellingPrice1 * dQty;
                    decimal dWeight = clsHelpMethods_Local.GetWeightByItemID(detail.Item_ID, 1);
                    decimal dUnitPrice = new masRouteWiseItemPricingData().GetRouteWisePrice(iRoute, sItemID);   //clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, sCustomerID);
                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);
                    bool bHasSettledBefore = true;


                    //var responce = data.GetAvailableStore(detail.Item_ID, 1);
                    //if (responce.IsSuccess)
                    //{
                    //    store_ID = responce.Value1;
                    //    Store_Name = responce.Value2;
                    //}

                    var MaxID = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(false, iRow, MaxID + 1, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, dAmount, detail.Width, detail.Height, detail.Thickness, detail.Gusset, dWeight, 0, dQty, "N",
                      //  sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2,
                        detail.Description, "", bHasSettledBefore, dExRate, store_ID, Store_Name);
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, false);
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCustomerOrderID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStore, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtTownID.Tag = order.Town_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                            txtTownID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(order.Town_ID));
                        }

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtJobCode.Tag = detail.Job_ID;
                        txtDriverID.Tag = detail.Driver_ID;
                        txtAssistantID.Tag = detail.Assitant_ID;
                        txtVehicleID.Tag = detail.Vehicle_ID;
                        txtStoreID.Tag = detail.Store_ID;
                        txtDeliveryOrderID.Tag = detail.DeliveryOrder_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                        {
                            foreach (ComboBoxItem d in cmbItemPrice.Items)
                            {
                                if (d.Value == detail.ItemPriceCategory)
                                {
                                    cmbItemPrice.SelectedItem = d;
                                    break;
                                }
                            }
                        }

                        txtCustomerOrderID.Text = clsCommon.GetForeignKeyValue(detail.CustomerOrder_ID);
                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtDriverID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Driver(detail.Driver_ID));
                        txtDriverNIC.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_DriverNIC(detail.Driver_ID));
                        txtAssistantID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Assistant(detail.Assitant_ID));
                        txtVehicleID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Vahicle(detail.Vehicle_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        txtDeliveryOrderID.Text = detail.DeliveryOrder_ID;
                        txtRemark.Text = detail.Remark;
                        txtVehicalNo.Text = detail.Vehicle_No;
                        dtpDateOut.Value = detail.DateOut;
                        dtpTimeOut.Value = detail.DateOut;
                        dtpDODate.Value = detail.DeliveryOrderDate;
                        dtpReceivedDate.Value = detail.CustomerDeliveryDate;
                        txtAddress.Text = detail.DeliveryAddress;
                        txtRemark.Text = detail.Remark;
                        txtReceiptBy.Text = detail.ReceiptBy;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        txtBatchNo.Text = detail.BatchNo;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        //CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        #region Customer Branch and Route
                        if (detail.Branch_ID != "default")
                        {
                            txtCustomerBranchID.Text = clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID));
                            txtCustomerBranchID.Tag = detail.Branch_ID;
                            lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(detail.Route_ID);
                            lblRoute.Tag = detail.Route_ID;
                        }
                        #endregion


                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;

                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                        }
                        userDetailsColorChanges();

                        //fill item details
                        RefreshGrid(detail.DeliveryOrder_ID);
                        RefreshGridBreakdownGenaral(detail.DeliveryOrder_ID);

                        //Asign Taxes

                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();

                        chkIsReplasement.Checked = detail.IsReplacementOrder;
                        //Set Flow
                        ucSasProcessFlow.SetProcessFlowByDeliveryOrder(detail.DeliveryOrder_ID);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Customer Detials
        private void FillDetailsCustomer(string sCustomerID)
        {
            try
            {
                txtCustomerID.Tag = null;
                txtCustomerID.Clear();
                txtAddress.Clear();

                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = customer.CustomerName;
                    txtAddress.Text = customer.AddressDelivery;

                    if (customer.SalesRep_ID != null && customer.SalesRep_ID != "default")
                    {
                        txtSalesExecutiveID.Tag = customer.SalesRep_ID;
                        txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);
                    }

                    if (customer.Town_ID != null && customer.Town_ID != "default")
                    {
                        txtTownID.Tag = customer.Town_ID;
                        txtTownID.Text = clsGenaralName.getName_Town(customer.Town_ID);
                    }
                    if (customer.Currency_ID != null && customer.Currency_ID != "default")
                    {
                        FillDetailsCurrency(customer.Currency_ID);
                    }

                    chkOtherTax.Checked = customer.IsSVATenable ? true : false;
                    chkVat.Checked = customer.IsVATenable ? true : false;
                    chkNBT.Checked = customer.IsNBTenable ? true : false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrencyID.Tag = null;
                txtCurrencyID.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrencyID.Tag = currency.Currency_ID;
                        txtCurrencyID.Text = currency.CurrencyName;
                        txtCurrencyRate.Text = currency.CurrencyRate.ToString();
                        txtCurrencyCode.Text = currency.CurrencyCode;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Breakdown Details
        private void FillDetailBreakdown_General(DataGridView dgvMyDatagrid)
        {
            try
            {
                ClearFieldBreakdown();

                string slineNo = dgvMyDatagrid["GenLineNo", dgvMyDatagrid.SelectedRows[0].Index].Value.ToString();
                string sItemID = dgvMyDatagrid["GenItemCode", dgvMyDatagrid.SelectedRows[0].Index].Value.ToString();
                string sItemSubCategoryID = dgvMyDatagrid["gItemSubCategoryID", dgvMyDatagrid.SelectedCells[0].RowIndex].Tag.ToString();
                string sItemSubCategoryID2 = dgvMyDatagrid["gItemSubCategoryID2", dgvMyDatagrid.SelectedCells[0].RowIndex].Tag.ToString();
                string sItemSerialNo = dgvMyDatagrid["gItemSerialNo", dgvMyDatagrid.SelectedCells[0].RowIndex].Value.ToString();
                string sItemSerialNo2 = dgvMyDatagrid["gItemSerialNo2", dgvMyDatagrid.SelectedCells[0].RowIndex].Value.ToString();

                int iLineNo = -1;
                if (int.TryParse(slineNo, out iLineNo))
                    iLineNo = int.Parse(slineNo);
                else
                    iLineNo = -1;

                RefreshGridBreakdownDetail(txtDeliveryOrderID.Text.Trim(), iLineNo, sItemID, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                FillDetailBreakdown_Breakdown(dgvBreakdown);

                txtbrk_PackingUom.Text = dgvMyDatagrid["GenUOMPacking", dgvGenaral.SelectedRows[0].Index].Value.ToString();
                txtbrk_PackingUom.Tag = dgvMyDatagrid["GenUOMPacking", dgvGenaral.SelectedRows[0].Index].Tag.ToString();
                txtbrk_WeightGeneral.Text = dgvMyDatagrid["GenWeight", dgvGenaral.SelectedRows[0].Index].Value.ToString();
                txtbrk_QtyGeneral.Text = dgvMyDatagrid["GenQuantity", dgvGenaral.SelectedRows[0].Index].Value.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailBreakdown_Breakdown(DataGridView dDataGrid)
        {
            try
            {
                decimal dQty = 0, dWeight = 0, dCount = 0;
                foreach (DataGridViewRow row in dDataGrid.Rows)
                {
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    {
                        decimal dTmpQty = clsValidate.ValidateGridValue(dDataGrid, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                        decimal dTmpPack = clsValidate.ValidateGridValue(dDataGrid, "BrkSerialNo", row.Index, decimal.Parse("0.00"));
                        dQty += (dTmpQty * dTmpPack);
                        dWeight += clsValidate.ValidateGridValue(dDataGrid, "BrkItemName", row.Index, decimal.Parse("0.00"));
                        dCount += clsValidate.ValidateGridValue(dDataGrid, "BrkSerialNo", row.Index, decimal.Parse("0.00"));
                    }
                    else
                    {
                        dQty += clsValidate.ValidateGridValue(dDataGrid, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                        dWeight += clsValidate.ValidateGridValue(dDataGrid, "BrkWeight", row.Index, decimal.Parse("0.00"));
                        dCount++;
                    }
                }

                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() && (dWeight > 0 || dQty > 0))
                {
                    dgvGenaral["GenWeight", dgvGenaral.SelectedRows[0].Index].Value = dWeight;
                    dgvGenaral["GenQuantity", dgvGenaral.SelectedRows[0].Index].Value = dQty;

                    dgvDetail["Quantity", 0].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQty);
                    dgvDetail["Weight", 0].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(0, 0));
                }

                txtbrk_WeightBreakdown.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
                txtbrk_QtyBreakdown.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQty);
                txtbrk_QtyPack.Text = clsFormatter.FormatDecimalPlaces_Quantity(dCount);


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(bool IsUpdateMode, int iRow, int lineNo, string ItemID, string CusOrderID, string QuotationID, string JobID, string Uom_ID, decimal UnitPrice, decimal WeightPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
                            decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal COQty, decimal Qty, string sItemStatus, 
                         //   string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, 
                            string Remark, string cartonNo, bool bHasSettled, decimal dExRate,string Store_ID,String Store_Name)
        {
            try
            {
                if (!IsUpdateMode)
                {
                    #region Check Duplicate items
                    if (!clsConfig.bAllow_user_to_Dupplicate_items_SAS_Transactions)
                    {
                        List<string> lstItems = dgvDetail.Rows
                             .OfType<DataGridViewRow>()
                             .Where(x => x.Cells["ItemCode"].Value != null)
                             .Select(r => r.Cells["ItemCode"].Value.ToString())
                             .ToList();

                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                            int iLineNo = lineNo;

                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, lineNo);
                            sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                            sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                            sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                            sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                            sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                            if (ItemID == sItemID //&& ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2
                                )
                            {
                                if (lstItems.Where(r => r == sItemID).Count() > 1)
                                {
                                    MessageBox.Show("Cannot add already duplicated items..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvDetail.Rows.RemoveAt(dgvDetail.Rows.Count - 1);
                                    return;
                                }

                                dgvDetail.Rows.RemoveAt(iRow);
                                lineNo = iLineNo;
                                Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                iRow = row.Index;
                            }
                        }
                    }
                    #endregion
                }

                #region Load zero qty items
                if (!clsConfig.bLoadZeroQtyItems_DOGrid)
                {
                    if (Qty == 0)
                    {
                        if (dgvDetail.RowCount > 1)
                        {
                            dgvDetail.Rows.RemoveAt(dgvDetail.Rows.Count - 1);
                            return;
                        }
                        dgvDetail.Rows.RemoveAt(iRow);
                        return;
                    }
                }
                #endregion

                //Get Unit Price with Exchange rate to save
                UnitPrice = clsHelpMethods_Local.getDisplayPrice(UnitPrice, dExRate);
                WeightPrice = clsHelpMethods_Local.getDisplayPrice(WeightPrice, dExRate);
                GrossTotal = clsHelpMethods_Local.getDisplayPrice(GrossTotal, dExRate);

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                string sPLU = clsHelpMethods.GetPLU(txtCustomerID.Tag.ToString(), ItemID);
                dgvDetail["ItemName", iRow].Value = sPLU == "" || sPLU == "-" ? clsGenaralName.getName_Item(ItemID) : clsGenaralName.getName_Item(ItemID) + " - [" + sPLU + "]";
                dgvDetail["CusOrderCode", iRow].Value = CusOrderID;//add by thilina
                dgvDetail["QuotationCode", iRow].Value = QuotationID;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(Uom_ID);
                dgvDetail["UOM", iRow].Tag = Uom_ID;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;
              //  dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
             //   dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
              //  dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
             //   dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
             //   dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
             //   dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["Remarks", iRow].Value = Remark;
                dgvDetail["carton_no", iRow].Value = cartonNo;

                dgvDetail["Width", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Width);
                dgvDetail["Height", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Height);
                dgvDetail["Gauge", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gauge);
                dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);

                dgvDetail["COQuantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(COQty);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);

                dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                dgvDetail["UnitPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice); //make advance later                
                dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);
                dgvDetail["WeightPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice); //make advance later

                dgvDetail["Free", iRow].Value = isFreeItem;
                dgvDetail["DiscuntPresentage", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountPresentage);
                dgvDetail["DiscuntPresentage", iRow].Tag = DiscountPresentage;
                dgvDetail["DiscountValue", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountAmount);
                dgvDetail["DiscountValue", iRow].Tag = DiscountAmount;
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(GrossTotal);
                dgvDetail["Amount", iRow].Tag = GrossTotal;
                
                dgvDetail["Amount", iRow].Tag = GrossTotal;

            
                dgvDetail["store_ID", iRow].Value = Store_Name;
                dgvDetail["store_ID", iRow].Tag = Store_ID;
             
                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion
                if (bHasSettled)
                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));

           //     dgvDetail["View", iRow].Value = "";
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By CustomerOrderID
        private void FillTaxDetailByCustomerOrderID(string CustomerOrderID)
        {
            try
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(CustomerOrderID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                    chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();

                    txtRemark.Text = detail.Remark;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            //For CheckItemSettleValidity and  CheckStockValidity
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            bool bStatus = false;



            if (CheckValidity_EmptyField())
            {
                var s = routeValidation.CheckValidity_RouteLock(int.Parse(lblRoute.Tag.ToString()));
                if (!s.IsSuccess)
                {
                    if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 111))
                    {
                        DialogResult msgResult = MessageBox.Show("The route is locked /nDo you need to overide?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (msgResult == DialogResult.Yes)
                            bStatus = true;
                    }
                    else
                        MessageBox.Show("Sorry! The route is locked");

                    if (!bStatus)
                        return bStatus;
                }

                if (CheckNumberValidity())
                {
                    if (CheckValidity_ItemDiscount())
                    {
                        if (CheckPackingSizeValidity())
                        {
                            if (CheckItemSettleValidity())
                            {
                                if (clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                                {
                                    if (CheckValidity_ProductionBatchQty())
                                    {
                                        //     if (CheckStockValidity())
                                        {
                                            if (CheckValidity_QuntityExceededPercentage())
                                            {
                                                if (CheckOutstandingValidity())
                                                {
                                                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                                                    {
                                                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                                        {
                                                            //      if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                                            {
                                                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                                                                {
                                                                    if (CheckGrandTotal_Minus())
                                                                    {
                                                                        if (IsUpdate)
                                                                        {
                                                                            tbl_sasDeliveryOrder oldRecord = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                                                            if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                                            {
                                                                                if (ValidateForDependancies(oldRecord.DeliveryOrder_ID))
                                                                                {
                                                                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtDeliveryOrderID.Text))
                                                                                    {
                                                                                        if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                                                        {
                                                                                            if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                                                                            {
                                                                                                if (CheckValidity_Posting())
                                                                                                {
                                                                                                    bStatus = true;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                                        }
                                                                                        else
                                                                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                            bStatus = true;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return bStatus;
        }
        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            if (clsConfig.bAutoPostingEnable)
            {
                var Items = new List<StringArray>();
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");

                    Items.Add(new StringArray { S = sItemCode });
                }

                var responce = oData.Validate_Ledger_PurchaceAcc(Items);
                if (!responce.IsSuccess)
                {
                    MessageBox.Show(responce.OutMsg, clsFormatter.GetMessageCaption(), System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    bStatus = false;
                }
                else
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name "))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerBranchID, "Customer Branch ID"))
                {
                  //  if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name "))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                            bStatus = true;
                    }
                }
            }
            return bStatus;
        }
        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sLineNo = "", sItemCode = "", sCoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dQuantity = 0, dWeight = 0;

            if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.DeliveryOrder)) && (!IsUpdate))
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        sCoCode = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        tbl_sasCustomerOrder_Detail CoDetail = tbl_sasCustomerOrder_Detail.Select(int.Parse(sLineNo), sCoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (CoDetail != null)
                        {
                            if (chkUnitPricing.Checked)
                            {
                                if (IsUpdate)
                                {
                                    if (CoDetail.Qty < dQuantity)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Ordered Quantity  \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (CoDetail.Qty < (CoDetail.QtySettle_DeliveryOrder + dQuantity))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Ordered Quantity  \n";
                                        rtn = false;
                                    }
                                }
                            }
                            else
                            {
                                if (IsUpdate)
                                {
                                    if (CoDetail.Weight < dWeight)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight cannot Exceed the Ordered Weightt \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (CoDetail.Weight < (CoDetail.WeightSettle_DeliveryOrder + dWeight))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight cannot Exceed the Ordered Weight \n";
                                        rtn = false;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                }
                if (!rtn)
                {
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return rtn;
        }
        //private bool CheckStockValidity()
        //{

        //    bool bStatus = true;
        //    try
        //    {
        //        string strMessage = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
        //        decimal dWeight = 0;
        //        decimal dQty = 0;
        //        foreach (DataRow row in dt_ItemGrouped.Rows)
        //        {
        //            #region Stock Validation
        //            sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
        //            dWeight = clsValidate.ValidateRowValue(row, "Weight", decimal.Parse("0.00"));
        //            dQty = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));
        //            sItemStatus = clsValidate.ValidateRowValue(row, "ItemStatus", "");
        //            sJobCode = clsValidate.ValidateRowValue(row, "JobCode", "default");
        //            sItemSubCategoryID = clsValidate.ValidateRowValue(row, "ItemSubCategoryID", "default");
        //            sItemSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
        //            sItemSerialNo = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
        //            sItemSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

        //            if (!clsHelpMethods_Local.IsNonInventoryItem(sItemCode))
        //            {
        //                tbl_genStore_Stock oStoreStock;
        //                oStoreStock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
        //                if (oStoreStock == null)
        //                {
        //                    oStoreStock = new tbl_genStore_Stock(txtStoreID.Tag.ToString(), sItemCode, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
        //                    oStoreStock.Insert();
        //                }

        //                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(txtStoreID.Tag.ToString());
        //                if (oStoreStock != null && oStore != null)
        //                {
        //                    #region if the item is old and check stock for more than one time
        //                    if (sItemStatus.ToLower() == "o")
        //                    {
        //                        decimal dOldQty = 0, dOldWeight = 0;
        //                        foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim()).Where(p => p.Item_ID == sItemCode && p.ItemSubCategory_ID == sItemSubCategoryID && p.ItemSubCategory2_ID == sItemSubCategoryID2))
        //                        {
        //                            dOldQty += oDoDetail.Qty;
        //                            dOldWeight += oDoDetail.Weight;
        //                        }

        //                        #region Old Items Quantity Validation
        //                        if (clsConfig.bStockValidateQty_DeliveryOrder)
        //                        {
        //                            if (oStoreStock.Qty + dOldQty < dQty)
        //                            {
        //                                strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
        //                                bStatus = false;
        //                            }
        //                        }
        //                        #endregion

        //                        #region Old Items Weight Validation
        //                        if (clsConfig.bStockValidateWeight_DeliveryOrder)
        //                        {
        //                            if (oStoreStock.Weight + dOldWeight < dWeight)
        //                            {
        //                                strMessage += "Required Weight of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in  store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
        //                                bStatus = false;
        //                            }
        //                        }
        //                        #endregion

        //                        if (!oStore.IsAllowMinusStock)
        //                        {
        //                            if (oStoreStock.Qty + dOldQty - dQty < 0)
        //                            {
        //                                strMessage += "Minus Quantities not allowed - \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
        //                                bStatus = false;
        //                            }
        //                        }
        //                    }
        //                    #endregion
        //                    #region first time added item ant have to check stock
        //                    else
        //                    {
        //                        #region Weight Validation
        //                        if (oStoreStock.Weight < dWeight && clsConfig.bStockValidateWeight_DeliveryOrder)
        //                        {
        //                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
        //                            bStatus = false;
        //                        }
        //                        #endregion

        //                        #region New Item Quantity Validation
        //                        if (oStoreStock.Qty < dQty && clsConfig.bStockValidateQty_DeliveryOrder)
        //                        {
        //                            strMessage += "Required Quantity of Item: \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" is not Availabe in store :\"" + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
        //                            bStatus = false;
        //                        }
        //                        #endregion

        //                        if (!oStore.IsAllowMinusStock)
        //                        {
        //                            if (oStoreStock.Qty - dQty < 0)
        //                            {
        //                                strMessage += "Minus Quantities not allowed - \"" + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "\" in store : " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\"\n";
        //                                bStatus = false;
        //                            }
        //                        }
        //                    }
        //                    #endregion
        //                }
        //                else
        //                {
        //                    if ((clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder) && !clsHelpMethods_Local.IsNonInventoryItem(sItemCode) && (clsConfig.sSoftwareModel.Trim() != SoftwareModel_Sales.akt.ToString()))
        //                    {
        //                        strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
        //                        bStatus = false;
        //                    }
        //                }
        //            }
        //            #endregion
        //        }
        //        if (bStatus == false)
        //            MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID, ex);
        //        SEACCException.Show(ex);
        //    }
        //    return bStatus;
        //}
        private bool CheckPackingSizeValidity()
        {
            bool bStatus = true;

            try
            {
                string sItemCode = "", strMessage = "";//, sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                                                       //  decimal dWeight = 0;
                decimal dQty = 0;

                foreach (DataRow row in dt_ItemGrouped.Rows)
                {
                    #region Stock Validation
                    sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
                    dQty = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));

                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemCode);
                    if (oItem != null)
                    {
                        if (oItem.Qty != 0)
                        {
                            decimal remain = dQty % oItem.Qty;
                            if (remain > 0)
                            {
                                strMessage += sItemCode + " - " + oItem.ItemName + " <" + oItem.Qty + ">\n";
                                bStatus = false;
                            }
                        }

                    }
                    #endregion
                }
                if (bStatus == false)
                    MessageBox.Show("Not allowed to deliver less than packing size \n\n" + strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_QuntityExceededPercentage()
        {
            bool bStatus = true;
            try
            {
                string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
                decimal dWeight = 0;
                decimal dQty = 0;
                if (clsConfig.isEnable_QuantityExceedPercentageLock)
                {
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                        sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");
                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        if (dQty == 0)
                        {
                            bStatus = false;
                            strMessage += "Delivery Qty Should be Greater than 0....!";
                        }

                        else
                        {
                            decimal dExceedPacentage = (clsCommon.isLocalCustomer(txtCustomerID.Tag.ToString()) ? decimal.Parse(clsConfig.sMaximumQuntityExceededPercentage_localOrders) : decimal.Parse(clsConfig.sMaximumQuntityExceededPercentage_ExportOrders));
                            if (IsUpdate)
                            {
                                #region Old Record
                                if (chkUnitPricing.Checked)  // Qty
                                {
                                    decimal dOldDeliveryQty = 0;
                                    List<tbl_sasDeliveryOrder_Detail> oldDoDetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim());
                                    foreach (tbl_sasDeliveryOrder_Detail oldDoDetail in oldDoDetails)
                                    {
                                        if (oldDoDetail.Line_No == int.Parse(sLineNo) && oldDoDetail.Item_ID == sOriginalItemCode && oldDoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldDoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDoDetail.ItemSerialNo == sItemSerialNo && oldDoDetail.ItemSerialNo2 == sItemSerialNo2)
                                            dOldDeliveryQty = oldDoDetail.Qty;
                                    }
                                    List<tbl_sasCustomerOrder_Detail> oldCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());
                                    foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                                    {
                                        if (oldCoDetail.Item_ID == sOriginalItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                                        {
                                            decimal dDeliveryQty = (oldCoDetail.QtySettle_DeliveryOrder - dOldDeliveryQty) + dQty;
                                            if (dDeliveryQty > oldCoDetail.Qty) //qty is exceeding the order qty
                                            {
                                                decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldCoDetail.Qty;
                                                if (dMaxValue < dDeliveryQty)
                                                {
                                                    bStatus = false;
                                                    strMessage += "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                                }
                                            }
                                        }
                                    }

                                }
                                else
                                {

                                    decimal dOldDeliveryWeight = 0;
                                    List<tbl_sasDeliveryOrder_Detail> oldDoDetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim());
                                    foreach (tbl_sasDeliveryOrder_Detail oldDoDetail in oldDoDetails)
                                    {
                                        if (oldDoDetail.Item_ID == sOriginalItemCode && oldDoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldDoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDoDetail.ItemSerialNo == sItemSerialNo && oldDoDetail.ItemSerialNo2 == sItemSerialNo2)
                                            dOldDeliveryWeight = oldDoDetail.Weight;
                                    }

                                    List<tbl_sasCustomerOrder_Detail> oldCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());
                                    foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                                    {
                                        if (oldCoDetail.Line_No == int.Parse(sLineNo) && oldCoDetail.Item_ID == sOriginalItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                                        {
                                            decimal dDeliveryWeight = (oldCoDetail.WeightSettle_DeliveryOrder - dOldDeliveryWeight) + dWeight;
                                            if (dDeliveryWeight > oldCoDetail.Weight) //qty is exceeding the order qty
                                            {
                                                decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldCoDetail.Weight;
                                                if (dMaxValue < dDeliveryWeight)
                                                {
                                                    bStatus = false;
                                                    strMessage += "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                                }
                                            }
                                        }
                                    }
                                }
                                #endregion
                            }
                            else // insert
                            {
                                #region New Record
                                if (chkUnitPricing.Checked)  // Qty
                                {
                                    List<tbl_sasCustomerOrder_Detail> oldCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());

                                    foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                                    {
                                        if (oldCoDetail.Line_No == int.Parse(sLineNo) && oldCoDetail.Item_ID == sOriginalItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                                        {
                                            decimal dDeliveryQty = dQty + oldCoDetail.QtySettle_DeliveryOrder;
                                            if (dDeliveryQty > oldCoDetail.Qty) //qty is exceeding the order qty
                                            {
                                                decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldCoDetail.Qty;
                                                if (dMaxValue < dDeliveryQty)
                                                {
                                                    bStatus = false;
                                                    strMessage += "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                                }
                                            }
                                        }
                                    }
                                }
                                else   // weight
                                {
                                    List<tbl_sasCustomerOrder_Detail> oldCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());
                                    foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                                    {
                                        if (oldCoDetail.Line_No == int.Parse(sLineNo) && oldCoDetail.Item_ID == sOriginalItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2
                                            && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                                        {

                                            decimal dDeliveryWeight = dWeight + oldCoDetail.WeightSettle_DeliveryOrder;
                                            if (dDeliveryWeight > oldCoDetail.Weight) //Weight is exceeding the order qty
                                            {
                                                decimal dMaxValue = ((dExceedPacentage + 100) / 100) * oldCoDetail.Weight;
                                                if (dMaxValue < dDeliveryWeight)
                                                {
                                                    bStatus = false;
                                                    strMessage += "Delivery Qty Can't Exceed the the Ordered QTY....!";
                                                }
                                            }

                                        }
                                    }
                                }
                                #endregion
                            }
                        }

                        if (bStatus == false)
                        {
                            MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckValidity_ProductionBatchQty()
        {
            bool bStatus = true;
            try
            {
                if (clsProcessMethods.CheckProductionApparel_Enable())
                {
                    foreach (DataRow row in dt_ItemGrouped.Rows)
                    {
                        string sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
                        decimal dQty = clsValidate.ValidateRowValue(row, "Quantity", 0m);

                        //bStatus = clsValidate.Check_AcceptedFGQty_ProdApparel(txtCustomerOrderID.Tag.ToString(), sItemCode, dQty);
                        //if (!bStatus)
                        //    break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;

        }
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (!clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                {
                    strMessage += "\n Sub Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                {
                    strMessage += "\n Discount Pasentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtVat.Text.Trim()))
                {
                    strMessage += "\n VAT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n VAT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtNBT.Text.Trim()))
                {
                    strMessage += "\n NBT Total";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                {
                    strMessage += "\n NBT pacentage";
                    bStatus = false;
                }
                if (!clsCommon.isCurrency(txtGrandTotal.Text.Trim()))
                {
                    strMessage += "\n Grand Total";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            return bStatus;
        }
        private bool CheckOutstandingValidity()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                    if (customer != null && customer.Customer_ID != "default")
                    {
                        if (customer.IsBlacklisted)
                        {
                            bOk = false;
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                        {
                            if (clsConfig.bCreditBalanceDeliveryOrder_Message) //security 1 - Message
                            {
                                dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                if (txtGrandTotal.TextLength > 0)
                                    dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
                                if (dCreditBalance < dAmountDue) //Condition
                                {
                                    bOk = false;
                                    if (clsConfig.bCreditBalanceDeliveryOrder_Lock) //security 2 - Lock
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    else
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            bOk = true;
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bOk;
        }
        private bool CheckValidity_ItemDiscount()
        {
            bool bValue = true;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                decimal dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                decimal dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                tbl_genItemMaster_Discount oDiscount = tbl_genItemMaster_Discount.Select(sItemCode);
                if (oDiscount != null)
                {
                    if ((oDiscount.MaxDiscountAmt > 0) && (dDiscountValue > oDiscount.MaxDiscountAmt))
                    {
                        bValue = false;
                        MessageBox.Show("Maximum Discount Amount " + clsFormatter.FormatDecimal(oDiscount.MaxDiscountAmt, 2) + " Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }

                    if ((oDiscount.MaxDiscountPct > 0) && (dDiscountPresentage > oDiscount.MaxDiscountPct))
                    {
                        bValue = false;
                        MessageBox.Show("Maximum Discount Pecentage " + clsFormatter.FormatDecimal(oDiscount.MaxDiscountAmt, 2) + "% Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }

                }
            }

            return bValue;
        }


        string sInvoiceID;
        private bool ValidateForDependancies(string sDeliveryOrderID)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_sasInvoice_Detail oIn in tbl_sasInvoice_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID))
                {
                    sInvoiceID = oIn.Invoice_ID;
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(oIn.Invoice_ID);
                    if (detail != null && detail.Invoice_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.Invoice_ID + "] Invoice is already created for this Delivery Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }
                if (bValue)
                {
                    foreach (tbl_sasSalesReturnedNote_Detail oIn in tbl_sasSalesReturnedNote_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID))
                    {
                        tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(oIn.Invoice_ID);
                        if (detail != null && detail.SalesReturnedNote_ID != "default" && !detail.IsDeleted)
                        {
                            bValue = false;
                            MessageBox.Show("Record Is Locked! \n\n[" + oIn.SalesReturnedNote_ID + "] SRN is already created for this Delivery Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        private bool CheckGrandTotal_Minus()
        {
            bool bStatus = true;

            if (decimal.Parse(txtGrandTotal.Text) < 0)
                bStatus = false;

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.EnterMinusValues), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtCustomerOrderID);
            clsCommon.ValidateForeignKey(ref txtQuotationID);
            clsCommon.ValidateForeignKey(ref txtTownID);
            clsCommon.ValidateForeignKey(ref txtJobCode);

            clsCommon.ValidateForeignKey(ref txtbrk_PackingUom);
            clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
            clsCommon.ValidateForeignKey(ref txtCustomerBranchID);

            ValidateVehicle();
            ValidateDriverAndNIC();
            ValidateAssistant();
        }
        #endregion

        #region Validate Vehicle
        private void ValidateVehicle()
        {
            try
            {
                string sVehicleID = "";
                if (txtVehicleID.Tag == null || txtVehicleID.Tag.ToString().Trim() == "default")
                {
                    if (txtVehicleID.TextLength > 0)
                    {
                        List<tbl_zVehicle> details = tbl_zVehicle.SelectAll();
                        foreach (tbl_zVehicle detail in details)
                        {
                            //veheicle name - check with the database 
                            if (txtVehicleID.Text.Trim().ToLower() == detail.VehicleNumber.Trim().ToLower())
                            {
                                sVehicleID = detail.Vehicle_ID;
                                txtVehicleID.Tag = sVehicleID;
                                break;
                            }
                        }
                        if (sVehicleID.Length == 0)
                        {
                            //create new vehicle
                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                sVehicleID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ZVehicle));
                            tbl_zVehicle vehicle = new tbl_zVehicle(sVehicleID, txtVehicleID.Text.Trim().ToUpper(), txtVehicleID.Text.Trim().ToUpper());
                            vehicle.Insert();
                            txtVehicleID.Tag = sVehicleID;
                        }
                    }
                    else
                        txtVehicleID.Tag = "default";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate Driver
        private void ValidateDriverAndNIC()
        {
            try
            {
                string sDriver = "";
                if (txtDriverID.Tag == null || txtDriverID.Tag.ToString().Trim() == "default")
                {
                    if (txtDriverID.TextLength > 0)
                    {
                        List<tbl_zDriver> details = tbl_zDriver.SelectAll();
                        foreach (tbl_zDriver detail in details)
                        {
                            //veheicle name - check with the database 
                            if (txtDriverID.Text.Trim().ToLower() == detail.DriverName.Trim().ToLower() && txtDriverNIC.Text.Trim().ToLower() == detail.NicNo.ToLower())
                            {
                                sDriver = detail.Driver_ID;
                                txtDriverID.Tag = sDriver;
                                break;
                            }
                        }
                        if (sDriver.Length == 0)
                        {
                            //create new vehicle
                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                sDriver = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ZDriver));
                            tbl_zDriver drive = new tbl_zDriver(sDriver, txtDriverID.Text.Trim().ToUpper(), txtDriverNIC.Text.Trim());
                            drive.Insert();
                            txtDriverID.Tag = sDriver;
                        }
                    }
                    else
                        txtDriverID.Tag = "default";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate Assistant
        private void ValidateAssistant()
        {
            try
            {
                string sAssistant = "";
                if (txtAssistantID.Tag == null || txtAssistantID.Tag.ToString().Trim() == "default")
                {
                    if (txtAssistantID.TextLength > 0)
                    {
                        List<tbl_zAssistant> details = tbl_zAssistant.SelectAll();
                        foreach (tbl_zAssistant detail in details)
                        {
                            //veheicle name - check with the database 
                            if (txtAssistantID.Text.Trim().ToLower() == detail.AssistantName.Trim().ToLower())
                            {
                                sAssistant = detail.Assistant_ID;
                                txtAssistantID.Tag = sAssistant;
                                break;
                            }
                        }
                        if (sAssistant.Length == 0)
                        {
                            //create new vehicle
                            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                sAssistant = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.ZAssistant));
                            tbl_zAssistant assi = new tbl_zAssistant(sAssistant, txtAssistantID.Text.Trim().ToUpper());
                            assi.Insert();
                            txtAssistantID.Tag = sAssistant;
                        }
                    }
                    else
                        txtAssistantID.Tag = "default";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validite Customer
        private bool CheckValiditeCustomerAndStore()
        {
            bool rtn = true;
            if (txtCustomerID.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Customer Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
            }
            if (false)
            {
                if (txtStoreID.Tag == null)
                {
                    rtn = false;
                    MessageBox.Show("Please Select the Store Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStoreID.Focus();
                }
            }
            return rtn;
        }
        #endregion

        #region Events ValueChanged
        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
            // dtpTimeIn.Value = dtpDateIn.Value;
        }

        private void dtpDateOut_ValueChanged(object sender, EventArgs e)
        {
            dtpTimeOut.Value = dtpDateOut.Value;
        }
        #endregion

        #region Events KeyDown
        private void txtDeliveryOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DeliveryOrderID();
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Job();
            }
        }
        private void txtCustomerOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerOrderID(sender);
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_QuotationID();
            }
        }
        private void txtVehicleID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_VehicleID();
            }
        }
        private void txtDriverID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DriverID();
            }
        }
        private void txtAssistantID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AssistantID();
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        private void txtbrk_Pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_UomID();
            }
        }
        private void frm_sasCustomerDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Search_SalesExecutiveID();
            }
        }
        private void txtTownID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterTown(ref txtTownID);
            }
        }
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        private void txtSalesNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesNoteType();
        }

        private void txtCustomerBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerBranch();
        }
        #endregion

        #region Events Double Click
        private void txtDeliveryOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrderID();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Job();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerOrderID(sender);
        }
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            Search_QuotationID();
        }
        private void txtVehicleID_DoubleClick(object sender, EventArgs e)
        {
            Search_VehicleID();
        }
        private void txtDriverID_DoubleClick(object sender, EventArgs e)
        {
            Search_DriverID();
        }
        private void txtAssistantID_DoubleClick(object sender, EventArgs e)
        {
            Search_AssistantID();
        }
        private void txtbrk_Pack_DoubleClick(object sender, EventArgs e)
        {
            Search_UomID();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtTownID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTownID);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtCustomerBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerBranch();
        }

        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                CalculateTaxesAndGrandTotal();
                chkVat.Checked = true;
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;
                CalculateTaxesAndGrandTotal();
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;
                CalculateTaxesAndGrandTotal();
            }
            else
                CalculateTaxesAndGrandTotal();
        }
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            //CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
            //CusDataGirdViewFormatForWeight(dgvGenaral, !chkUnitPricing.Checked, "GenWeight", "GenQuantity");

            ////call cellend events for all records
            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
            //    dgvDetail_CellEndEdit(sender, ar);
            //}
        }
        private void chkReverseCalculation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReverseCalculation.Checked)
            {
                chkReverseCalculation.Enabled = false;
                frm_sasTaxTypeSelect frm = new frm_sasTaxTypeSelect();
                frm.ShowDialog();
                chkNBT.Checked = frm.bCheckNBT;
                chkVat.Checked = frm.bCheckVat;
                chkNBT.Enabled = false;
                chkVat.Enabled = false;
                chkOtherTax.Enabled = false;
                chkDiscount.Enabled = false;
                VatNBTReverceCalculation(clsCommon.getPesentageVAT(), clsCommon.getPesentageNBT());
                x2.Enabled = false;
            }
        }
        private void chkSettings2_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSettings2.Checked)
            //{
            //    zpnlSetting1.SendToBack();
            //    chkSettings2.Image = Digiteq.Properties.Resources.settings;
            //}
            //else
            //{
            //    zRemark.SendToBack();
            //    chkSettings2.Image = Digiteq.Properties.Resources.security;
            //}
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clsEvent.SalesGrid_CellDoubleClick(sender, e, dgvDetail);
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();

                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks" && sColName != "carton_no"
                    && sColName != "Free" && sColName != "DiscuntPresentage" && sColName != "DiscountValue" && sColName != "View")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                       "default", "default",
                        "0", "0");
                }

                //if (sColName == "View")
                //{
                //    //MessageBox.Show("OK", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    frmComponentList frm = new frmComponentList();
                //    frm.MdiParent = this.ParentForm.MdiParent;
                //    frm.Show();

                //}

                if (sColName == "Free")
                {
                    if (bHasPermissionToFreeIssures)
                    {
                        bool bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                        dgvDetail["Free", e.RowIndex].Value = bIsFreeItem ? false : true;
                        dgvDetail_CellEndEdit(sender, e);
                    }
                }
            }
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SalesGrid_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
        }
        private void dgvGenaral_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillDetailBreakdown_General(dgvGenaral);
        }
        private void dgvGenaral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvGenaral_CellClick(sender, e);
        }
        private void dgvBreakdown_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvGenaral.SelectedRows.Count > 0)
                {
                    if (clsEvent.Grid_CellEndEditBreakdown(sender, e, dgvBreakdown, dgvGenaral, !chkUnitPricing.Checked))
                        FillDetailBreakdown_Breakdown(dgvBreakdown);
                }
                FillDetailBreakdown_Breakdown(dgvBreakdown);
            }
        }
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;


                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks")
                {
                    Cursor = Cursors.Hand;
                }
            }
        }
        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;


                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks")
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        #endregion

        #region Events Leave
        private void txtDriverID_Leave(object sender, EventArgs e)
        {
            try
            {
                bool bHasFound = false;
                if (txtDriverID.TextLength > 0)
                {
                    List<tbl_zDriver> details = tbl_zDriver.SelectAll();
                    foreach (tbl_zDriver detail in details)
                    {
                        //veheicle name - check with the database 
                        if (txtDriverID.Text.Trim().ToLower() == detail.DriverName.Trim().ToLower())
                        {
                            txtDriverID.Tag = detail.Driver_ID;
                            txtDriverID.Text = detail.DriverName;
                            txtDriverNIC.Text = detail.NicNo;
                            bHasFound = true;
                            break;
                        }
                    }

                    if (!bHasFound)
                    {
                        txtDriverID.Tag = null;
                        txtDriverNIC.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events SelectedIndexChanged
        private void tbcChequeManagement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tbcChequeManagement.SelectedTab == tbpBreakdown)
            {
                if (IsUpdate)
                {
                    RefreshGridBreakdownGenaral(txtDeliveryOrderID.Text.Trim());
                }
                else
                {
                    //    MessageBox.Show("Please Save The Delivery Note Before Add Breakdown Details", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    tbcChequeManagement.SelectedTab = tbpGenaral;
                }
            }
        }
        #endregion

        #region Search Methods
        private void Search_DeliveryOrderID()
        {
            clsSearch.Search_TransactionDeliveryOrder_Direct(ref txtDeliveryOrderID, chkShowSettle.Checked,0);
            if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtDeliveryOrderID.Tag.ToString());
        }
        private void Search_QuotationID()
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, txtCustomerID.Tag.ToString(), false);
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerOrderID(object objSender)
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                string Customer_ID = "";
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    Customer_ID = txtCustomerID.Tag.ToString();

                clsSearch.Search_TransactionCustomerOrder_Use(ref txtCustomerOrderID, Customer_ID, false);

                if (txtCustomerOrderID.Tag != null && txtCustomerOrderID.Tag.ToString().Length > 0)
                {
                    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Tag.ToString());
                    if (detail != null)
                    {
                        btnAddCustomerOrder_Click(objSender, new EventArgs());
                    }
                }
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID, IsUpdate);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                bool bIsEnableCustomerChange = true;

                if (isTemp)
                {
                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        int i = (int)enum_CustomerPrice_Mode.Customer_Wise_Price;
                        if (oCustomer.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price && dgvDetail.Rows.Count > 0)
                        {
                            bIsEnableCustomerChange = false;
                            MessageBox.Show("Customer Wise pricing enabled. Please remove items to change customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                if (bIsEnableCustomerChange == true)
                {
                    //clsSearch.Search_MasterCustomer_New(ref txtCustomerID);
                    string sCustomerID = "";
                    clsSearch.Search_MasterCustomerID_New(ref sCustomerID, false);

                    if (dgvDetail.Rows.Count > 0 && !isTemp)
                    {
                        MessageBox.Show("Please remove items to change customer..!"); // comment this for new search
                        //ClearFields();
                        //txtCustomerID.Text = frmSearchMaster.s_SearchText;
                        //txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                    }
                    else
                    {
                        //Form frmhelpsearch = new frmSearchMaster();
                        //clsSearch.passValue_CustomerMaster();
                        //frmhelpsearch.ShowDialog();

                        if (sCustomerID.Length > 0)
                        {
                            tbl_genCustomerMaster oCustomer2 = tbl_genCustomerMaster.Select(sCustomerID);
                            if (oCustomer2 != null && oCustomer2.Customer_ID != "default")
                            {
                                if (isTemp && oCustomer2.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price && dgvDetail.Rows.Count > 0)
                                {
                                    bIsEnableCustomerChange = false;
                                    MessageBox.Show("Customer Wise pricing enabled. Please remove items to change customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    //ClearFields();
                                    //if (frmSearchMaster.s_SearchText.Length > 0)
                                    //    txtCustomerID.Text = frmSearchMaster.s_SearchText;
                                    if (sCustomerID.Length > 0)
                                    {
                                        //    txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                                        FillDetailsCustomer(sCustomerID);

                                        //Add Branch
                                        List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
                                        if (Detail.Count > 1)
                                            Search_CustomerBranch();
                                        else
                                        {
                                            txtCustomerBranchID.Text = Detail.FirstOrDefault().BranchName;
                                            txtCustomerBranchID.Tag = Detail.FirstOrDefault().Line_No;

                                            txtAddress.Text = Detail.FirstOrDefault().Address;

                                            lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(Detail.FirstOrDefault().Route_ID);
                                            lblRoute.Tag = Detail.FirstOrDefault().Route_ID.ToString();
                                        }

                                        //   if (!clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                                        //     ClearFields();
                                    }
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Job()
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
            {
                clsSearch.Search_TransactionProductionJobRegisterByCustomerID_Use(ref txtJobCode, txtCustomerID.Tag.ToString());
            }
            else
                clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, false, true);

            if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
            {
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtJobCode.Tag.ToString());
                //if (detail != null)
                //{

                //    FillDetailsCustomer(detail.Customer_ID);
                //    FillTaxDetailByCustomerOrderID(detail.CustomerOrder_ID);
                //    btnAddJobCode_Click(null, new EventArgs());
                //}
            }
        }
        private void Search_DriverID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Driver();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtDriverID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtDriverID.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_AssistantID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Assistant();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtAssistantID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtAssistantID.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_VehicleID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Vehicle();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtVehicleID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtVehicleID.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_UomID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_UomForPacking();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtbrk_PackingUom.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                        txtbrk_PackingUom.Tag = frmSearchMaster.s_SearchID;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ItemID()
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.Search_ItemMaster(ref txtItemID, null, null, null, false);
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
            if (txtCurrencyID.Tag != null)
                FillDetailsCurrency(txtCurrencyID.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);
                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.passValue_EmpSalesRep();
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchText.Length > 0)
                //    txtSalesExecutiveID.Text = frmSearchMaster.s_SearchText;
                //if (frmSearchMaster.s_SearchID.Length > 0)
                //    txtSalesExecutiveID.Tag = frmSearchMaster.s_SearchID;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerBranch()
        {
            if (txtCustomerID.Tag != null)
            {
                clsSearch.Search_CustomerBranch(ref txtCustomerBranchID, txtCustomerID.Tag.ToString());
                if (txtCustomerID.Tag != null && txtCustomerBranchID.Tag != null)
                {
                    tbl_genCustomerMaster_Branches Detail = tbl_genCustomerMaster_Branches.Select(txtCustomerID.Tag.ToString(), int.Parse(txtCustomerBranchID.Tag.ToString()));
                    if (Detail != null)
                    {
                        lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(Detail.Route_ID);
                        lblRoute.Tag = Detail.Route_ID.ToString();
                        txtAddress.Text = Detail.Address;
                    }
                }
            }

        }
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID, IsUpdate);
        }
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            if (CheckValiditeCustomerAndStore())
            {
                if (e.KeyCode == Keys.F1)
                {
                    if ((clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder) && !clsConfig.bSingleItemStockEnabled)
                    {
                        //clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);

                        clsSearch.Search_TransactionByItemCodeItemMaster(ref txtItemID);//, txtStoreID.Tag.ToString());
                        if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        {
                            txtItemSubCategory.Tag = "default";
                            txtItemSerialNo.Tag = "0";
                            btnAddItem_Click(btnAddItem, new EventArgs());
                        }
                    }
                    else
                    {
                        //clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                        clsSearch.Search_TransactionByItemCodeItemMaster(ref txtItemID);//, txtStoreID.Tag.ToString());
                        if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        {
                            txtItemSubCategory.Tag = "default";
                            txtItemSerialNo.Tag = "0";
                            btnAddItem_Click(sender, new EventArgs());
                        }
                    }
                }
                //else if (e.KeyCode == Keys.F5)
                //{
                //    frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
                //    string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                //    frm.glb_sItemPriceCategory = sItemPriceCategory;
                //    frm.glb_sStoreID = txtStoreID.Tag.ToString();
                //    frm.ShowDialog();

                //    if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                //    {
                //        foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
                //        {
                //            dgvDetail.Rows.Add();
                //            int iRow = dgvDetail.Rows.Count - 1;
                //            decimal dExRate = 0;
                //            if (txtCurrencyRate.Text.Trim().Length > 0)
                //                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                //            bool bHasSettledBefore = true;
                //          //  Fill_Datagrid(false, iRow, iRow, oItem.sItemID, "default", "default", "default", oItem.sUOMID, oItem.dUnitPrice, oItem.dWeightPrice, false, 0, 0, oItem.dTotalAmount, 0, 0, 0, 0, oItem.dWeight, 0, oItem.dQty, "N", oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "", "", bHasSettledBefore, dExRate);
                //        }
                //    }
                //}
                else
                {
                    //clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                    clsSearch.Search_TransactionItemMasterByStore(ref txtItemID, txtStoreID.Tag.ToString());
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    {
                        txtItemSubCategory.Tag = "default";
                        txtItemSerialNo.Tag = "0";
                        btnAddItem_Click(sender, new EventArgs());
                    }
                }

            }
        }

        #endregion

        #region Disable Money Controls
        private void DisableMoneyControls()
        {
            txtDiscount.Enabled = false;
            txtPercentageDiscount.Enabled = false;
            txtPercentageVat.Enabled = false;
            txtPercentageNBT.Enabled = false;
            txtPercentageOtherTax.Enabled = false;
            txtOtherTax.Enabled = false;
        }
        #endregion

        #region Calcualte Values
        private void CalcualteSubTotal()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (dgvDetail["Amount", x].Value != null && dgvDetail["Amount", x].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Value.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Value.ToString());
                    }
                }
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                txtSubTotal.Tag = Amount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }

        #endregion

        #region Vat/NBT Revers calculation
        private void VatNBTReverceCalculation(decimal dVatRate, decimal dNBTRate)
        {
            dVatRate = chkVat.Checked ? dVatRate : 0;
            dNBTRate = chkNBT.Checked ? dNBTRate : 0;
            if (dVatRate >= 0 && dNBTRate >= 0)
            {
                decimal dAfterVAT = 0;
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    decimal dUnitPrice = 0, dWeightPrice = 0, dQty = 0, dWeight = 0;//dVatAmount = 0
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));

                    #region Tax Amount Calculation
                    if (chkUnitPricing.Checked)
                    {
                        dAfterVAT = (dUnitPrice / (100 + dVatRate)) * 100;
                        dUnitPrice = (dAfterVAT / (100 + dNBTRate)) * 100;
                    }
                    else
                    {
                        dAfterVAT = (dWeightPrice / (100 + dVatRate)) * 100;
                        dWeightPrice = (dAfterVAT / (100 + dNBTRate)) * 100;
                    }
                    #endregion

                    #region Assign New Value
                    if (clsCommon.IsCustomerizedGrid())
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice;// clsFormatter.FormatToNumberWithTwoDecimalPlaces(dWeightPrice);                            
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["WeightPrice"].Index, row.Index));
                        }
                    }
                    else
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice.ToString();
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice.ToString();
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["WeightPrice"].Index, row.Index));
                        }
                    }
                    #endregion
                }

                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }

        }
        #endregion

        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Qty Adjustment
        private void chkQtyAdjustment_CheckedChanged(object sender, EventArgs e)
        {
            //   CusDataGirdViewFormatForAdjustmnetWeight(dgvGenaral, chkAdjustmentQtyWeight.Checked, "AdjustWeight", "AdjustQty");
        }
        #endregion

        #region Print Method
        private void print(bool bIsDraft)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                {
                    string sDuplicateCopy = "";

                    #region dataset
                    try
                    {
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sDeliveryAddress = "", sVatRegi = "", sDeliveryTel = "";
                        bool bApprovalDone = true, bCheckingDone = true;
                        DateTime dtOrderDate = DateTime.MinValue; decimal dCustomerOrderQty = 0;
                        if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            bool bPermissinOkToPrint = true;
                            if (chkPrintOriginal.Checked)
                                bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder));

                            if (bPermissinOkToPrint)
                            {
                                tbl_sasDeliveryOrder oDelOrder = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text);
                                if (oDelOrder != null)
                                {
                                    if (oDelOrder.PrintCount > 0)
                                    {
                                        if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 1101, true, false))
                                        {
                                            MessageBox.Show("Access Denied ! \n\nUser does not have access to Print duplicates, Please get permission from the system administrator ");
                                            return;
                                        }
                                    }
                                    if (!bIsDraft)
                                    {
                                        #region Validate Approval
                                        if (clsConfig.bApprovalNeedToPrintDeliveryOrder)
                                        {
                                            if (!oDelOrder.IsApproved)
                                            {
                                                bApprovalDone = false;
                                                MessageBox.Show("Please Approve the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        #endregion
                                        #region Validate Checking
                                        if (clsConfig.bCheckingNeedToPrintDeliveryOrder)
                                        {
                                            if (!oDelOrder.IsChecked)
                                            {
                                                bCheckingDone = false;
                                                MessageBox.Show("Please Check the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        #endregion
                                        #region Old
                                        //#region Validate Approval
                                        //if (clsConfig.bApprovalNeedToPrintDeliveryOrder)
                                        //{
                                        //    if (oDelOrder.IsApproved)
                                        //        bApprovalDone = true;
                                        //    else
                                        //        MessageBox.Show("Please Approve the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //}
                                        //else
                                        //    bApprovalDone = true;
                                        //#endregion

                                        //#region Validate Checking
                                        //if (clsConfig.bCheckingNeedToPrintDeliveryOrder)
                                        //{
                                        //    if (oDelOrder.IsChecked)
                                        //        bCheckingDone = true;
                                        //    else
                                        //        MessageBox.Show("Please Check the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        //}
                                        //else
                                        //    bCheckingDone = true;
                                        //#endregion 
                                        #endregion
                                    }

                                    if (bApprovalDone && bCheckingDone)
                                    {
                                        glb_dts_DeliveryOrders.Clear();
                                        glb_dtsReportExport.Clear();
                                        Cursor = Cursors.WaitCursor;

                                        #region Set Duplicate, Draft and Cancelled note
                                        if (!bIsDraft)
                                        {
                                            if (!chkPrintOriginal.Checked)
                                                sDuplicateCopy = oDelOrder.PrintCount > 0 ? "Duplicate Copy " + oDelOrder.PrintCount : "";

                                            oDelOrder.PrintCount++;
                                            oDelOrder.DatePrinted = clsSecurity.getServerDateTime();
                                            oDelOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
                                            oDelOrder.PrintedUser_ID = clsSecurity.UserIDLoged;
                                            oDelOrder.Update();
                                        }

                                        if (oDelOrder.IsDeleted)
                                            sDuplicateCopy = "";
                                        #endregion

                                        #region Set User Details
                                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                                        sCreateUser = "[ " + clsGenaralName.getName_User(oDelOrder.CreateUser_ID) + " ] [ " + oDelOrder.DateCreate.ToShortDateString() + " ]";
                                        if (oDelOrder.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(oDelOrder.CheckedUser_ID) + " ] [ " + oDelOrder.DateChecked.ToShortDateString() + " ]";
                                        if (oDelOrder.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(oDelOrder.ApprovedUser_ID) + " ] [ " + oDelOrder.DateApproved.ToShortDateString() + " ]";
                                        #endregion

                                        #region Set User Details(For Cellcius)
                                        string sCreateUserCel = "", sCheckedUserCel = "", sCreatedate = "", sChequeDate = "";
                                        sCreateUserCel = "[ " + clsGenaralName.getName_User(oDelOrder.CreateUser_ID) + " ] ";
                                        sCreatedate = "[" + oDelOrder.DateCreate.ToShortDateString() + "]";
                                        if (oDelOrder.CheckedUser_ID != "default")
                                            sCheckedUserCel = "[ " + clsGenaralName.getName_User(oDelOrder.CheckedUser_ID) + " ] ";
                                        sChequeDate = "[" + oDelOrder.DateChecked.ToShortDateString() + "]";
                                        #endregion

                                        #region Set Delivery Address
                                        if (clsConfig.bShow_ManuallyEnter_DeliveryAddress)
                                            sDeliveryAddress = oDelOrder.DeliveryAddress;
                                        else
                                            sDeliveryAddress = clsGenaralName.getName_CustomerDeliveryAddress(oDelOrder.Customer_ID);
                                        #endregion

                                        #region Get PO No & CustomerOrderdate
                                        string sPoNO = "-";
                                        tbl_sasCustomerOrder oCo = tbl_sasCustomerOrder.Select(oDelOrder.CustomerOrder_ID);
                                        if (oCo.PurchaseOrder_ID != "default")
                                            sPoNO = oCo.PurchaseOrder_ID;
                                        dtOrderDate = oCo.CustomerOrderDate;
                                        #endregion

                                        #region Set VatRegi.No
                                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oDelOrder.Customer_ID);
                                        if (oCustomer != null)
                                        {
                                            sVatRegi = oCustomer.VatRegistrationNo;
                                        }
                                        #endregion

                                        #region Set Delivery Tel No
                                        tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oDelOrder.Customer_ID, Convert.ToInt16(oDelOrder.Branch_ID));
                                        if (oBranch != null)
                                        {
                                            sDeliveryTel = oBranch.Telephone;
                                        }
                                        #endregion

                                        glb_dts_DeliveryOrders.dt_deliveryOrderHeader.Adddt_deliveryOrderHeaderRow(oDelOrder.DeliveryOrder_ID, oDelOrder.DeliveryOrderDate, oDelOrder.Remark,
                                            oDelOrder.Customer_ID, clsGenaralName.getName_Customer(oDelOrder.Customer_ID), sDeliveryAddress, sPoNO, clsGenaralName.getName_BranchCustomer(oDelOrder.Customer_ID, oDelOrder.Branch_ID == "default" ? 29949 : int.Parse(oDelOrder.Branch_ID)),
                                            clsGenaralName.getName_CustomerTelephone(oDelOrder.Customer_ID), oDelOrder.Store_ID, clsGenaralName.getName_Store(oDelOrder.Store_ID), clsGenaralName.getAddress_Store(oDelOrder.Store_ID), clsGenaralName.getName_OrderRefNo(oDelOrder.OrderRefNo_ID), oDelOrder.Vehicle_No,
                                            oDelOrder.SubTotal, oDelOrder.DiscountTotal, oDelOrder.DiscountPercentage, oDelOrder.NbtTotal, oDelOrder.NbtPercentage, oDelOrder.VatTotal, oDelOrder.VatPercentage, oDelOrder.OtherTaxTotal, oDelOrder.OtherTaxPercentage, oDelOrder.GrandTotal,
                                            oDelOrder.Employee_ID, oDelOrder.IsWeightCalculation, clsGenaralName.getName_Employee(oDelOrder.Employee_ID), oDelOrder.IsDeleted, 0, dtOrderDate, oDelOrder.DeliveryAddress, clsGenaralName.getName_Assistant(oDelOrder.Assitant_ID), clsGenaralName.getName_Driver(oDelOrder.Driver_ID), clsGenaralName.getName_DriverNIC(oDelOrder.Driver_ID), oDelOrder.CustomerOrder_ID, sVatRegi, sDeliveryTel);



                                        foreach (SEACC.DATA.Domain.SAS.tbl_sasDeliveryOrder_Detail_View oDetails_DO in data.SelectAllByDeliveryOrder_ID(oDelOrder.DeliveryOrder_ID))
                                        {
                                            dCustomerOrderQty = 0;
                                            #region Set CustomerOrder Qty
                                            tbl_sasCustomerOrder_Detail oCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oDetails_DO.customerOrder_ID).Where(p => p.Item_ID == oDetails_DO.item_ID).FirstOrDefault();
                                            if (oCoDetails != null)
                                                dCustomerOrderQty = oCoDetails.Qty;
                                            #endregion

                                            #region Set Plu Code
                                            tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(oDetails_DO.item_ID);
                                            #endregion
                                            glb_dts_DeliveryOrders.dt_deliveryOrderDetail.Adddt_deliveryOrderDetailRow(oDetails_DO.deliveryOrder_ID, "0", oDetails_DO.item_ID, clsGenaralName.getName_Item(oDetails_DO.item_ID), oDetails_DO.remark, oDetails_DO.carton_No, oDetails_DO.qty, oDetails_DO.weight, clsGenaralName.getName_ItemUOMName(oDetails_DO.item_ID), oDetails_DO.unitPrice, oDetails_DO.bIsFreeItem, oDetails_DO.discountPresentage, oDetails_DO.discountAmount, oDetails_DO.tatalAmount, dCustomerOrderQty, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID),oDetails_DO.store_ID,oDetails_DO.storeName);
                                        }

                                        #region Fill Company details
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle_Main, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyBusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SVAT", clsCommon.getCompanySVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CustomerAddress", clsCommon.getCompanyBusinessRegisterNo(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oDelOrder.IsDeleted ? "CANCELLED" : "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreatedate, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sChequeDate, true);

                                        #region Fill Data Into Formula Fields(Cell)
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserCel", sCreateUserCel, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserCel", sCheckedUserCel, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDateCel", sCreatedate, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDateCel", sChequeDate, true);
                                        #endregion

                                        #region Company Details Fill
                                        string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                        byte[] bCompanyImage = clsCommon.getCompanyImage();
                                        if (bIsDraft)
                                        {
                                            if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                            {
                                                sCompanyName = "";
                                                sCompanyAddress1 = "";
                                                sCompanyAddress2 = "";
                                                bCompanyImage = null;

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyBusinessRegNo", "", true);

                                            }
                                        }
                                        glb_dts_DeliveryOrders.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                        #endregion
                                        #endregion

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dts_DeliveryOrders, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder));
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        glb_dts_DeliveryOrders.Clear();
                        glb_dtsReportExport.Clear();
                        Cursor = Cursors.Default;
                    }
                    #endregion
                }
                else
                    MessageBox.Show("Please Select the Delivery Note To Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void doPrintWithBrackDown(string sDuplicateCopy)
        {
            string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sReceiveUser = "", s_Path = "";
            tbl_sasDeliveryOrder oOrder = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
            if (oOrder != null && oOrder.DeliveryOrder_ID != "default")
            {
                sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ] [ " + oOrder.DateCreate.ToShortDateString() + " ]";
                if (oOrder.CheckedUser_ID != "default")
                    sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ] [ " + oOrder.DateChecked.ToShortDateString() + " ]";
                if (oOrder.ApprovedUser_ID != "default")
                    sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ] [ " + oOrder.DateApproved.ToShortDateString() + " ]";
                if (oOrder.ReceiptBy != "default")
                    sReceiveUser = "[ " + oOrder.ReceiptBy + " ]";


                #region Print The Doc
                {

                    Cursor = Cursors.WaitCursor;
                    string sReportTitle = "Delivery Note / Gate Pass", sFormula = "";
                    if (txtDeliveryOrderID.TextLength > 0)
                        sFormula = "{vw_rpt_sasDeliveryOrder.deliveryOrder_ID} = '" + txtDeliveryOrderID.Text.Trim() + "'";

                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");


                    if (chkPrintWithBreakdown.Checked)
                    {
                        string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder_BrackDown));
                        if (sGetRptPath != null && sGetRptPath.Length > 0)
                            s_Path += sGetRptPath;
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrderWithBreakDown.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.aktN2.ToString())
                        {
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_AKT_Full.rpt";
                            sFormula = "{vw_rpt_sasDeliveryOrder_DetailBreakdown.deliveryOrder_ID} = '" + txtDeliveryOrderID.Text.Trim() + "'";
                        }
                    }
                    else
                    {
                        string sGetRptPath = clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder));
                        if (sGetRptPath != null && sGetRptPath.Length > 0)
                            s_Path += sGetRptPath;
                        else
                        {
                            if (chkPrintWithAmounts.Checked)
                                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrderWithBreakDownWithPrice.rpt";
                            else
                            {
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_AKT.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.aktN2.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_AKTN2.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WOD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WSC.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WSC.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_ITCPrePrint.rpt";
                                else
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WSC.rpt";
                            }
                        }
                    }

                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                    //   clsSecurity.LogonServer(ref RD);
                    RD.Refresh();

                    if ((clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                        && (!chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked))
                        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                    try
                    {

                        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                        RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                        RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(oOrder.Customer_ID));

                        RD.DataDefinition.FormulaFields["StoreName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_Store(oOrder.Store_ID));
                        RD.DataDefinition.FormulaFields["StoreAddress"].Text = clsCommon.fncsetstring(clsGenaralName.getAddress_Store(oOrder.Store_ID));
                    }
                    catch (Exception)
                    {
                    }

                    if (oOrder.IsDeleted)
                    {
                        RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("CANCELLED");
                    }
                    else
                        RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("");


                    //FOR AKHTARI TRADES D/O
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString() && !chkPrintWithBreakdown.Checked)
                    {
                        System.Text.StringBuilder noOfPacks = new System.Text.StringBuilder();
                        System.Text.StringBuilder runningNumber = new System.Text.StringBuilder();
                        System.Text.StringBuilder QxW = new System.Text.StringBuilder();
                        System.Text.StringBuilder combination = new System.Text.StringBuilder();
                        System.Text.StringBuilder itemSize = new System.Text.StringBuilder();

                        List<tbl_sasDeliveryOrder_Detail> oOrderDetails = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oOrder.DeliveryOrder_ID.ToString());
                        foreach (tbl_sasDeliveryOrder_Detail oOrderDetail in oOrderDetails)
                        {
                            if (oOrderDetail.Item_ID != "default")
                            {
                                int iCount = 0;

                                List<tbl_sasDeliveryOrder_DetailBreakdown> oOrderDetailBreakDowns = tbl_sasDeliveryOrder_DetailBreakdown.SelectAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(
                                    oOrderDetail.DeliveryOrder_ID, oOrderDetail.Item_ID, oOrderDetail.ItemSubCategory_ID, oOrderDetail.ItemSubCategory2_ID, oOrderDetail.ItemSerialNo, oOrderDetail.ItemSerialNo2);
                                foreach (tbl_sasDeliveryOrder_DetailBreakdown oOrderDetailBreakDown in oOrderDetailBreakDowns)
                                {
                                    iCount++;
                                    if (iCount < 4)
                                    {
                                        noOfPacks.Append(" | " + oOrderDetailBreakDown.SerialNo);
                                        runningNumber.Append(" | " + oOrderDetailBreakDown.Remark);
                                        QxW.Append(" | " + clsFormatter.FormatDecimalPlaces_Quantity(oOrderDetailBreakDown.Qty));
                                    }
                                }
                                tbl_genItemMaster oItem = tbl_genItemMaster.Select(oOrderDetail.Item_ID);
                                RD.DataDefinition.FormulaFields["size"].Text = clsCommon.fncsetstring(clsHelpMethods_Local.GetItemSizeByItemID(oOrderDetail.Item_ID));
                                string sQtyOrWeight = oOrder.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oOrderDetail.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oOrderDetail.Qty);
                                RD.DataDefinition.FormulaFields["Qty"].Text = clsCommon.fncsetstring(sQtyOrWeight);
                                RD.DataDefinition.FormulaFields["UOM"].Text = clsCommon.fncsetstring(clsGenaralName.getName_Uom(oItem.Uom_ID));
                                break;
                            }
                        }
                        string sPONo = oOrder.Job_ID != "default" ? clsHelpMethods_Local.GetPONoByProductionJobID(oOrder.Job_ID) : clsHelpMethods_Local.GetPONoByCustomerOrderID(oOrder.CustomerOrder_ID);
                        sPONo = sPONo == "default" ? "" : sPONo;
                        string sOrderRefNo = txtOrderRefNo.Text.Trim();

                        try
                        {
                            RD.DataDefinition.FormulaFields["NumberOfPacks"].Text = clsCommon.fncsetstring(noOfPacks.ToString());
                            RD.DataDefinition.FormulaFields["RunningNo"].Text = clsCommon.fncsetstring(runningNumber.ToString());
                            RD.DataDefinition.FormulaFields["QtyPack"].Text = clsCommon.fncsetstring(QxW.ToString());
                           // RD.DataDefinition.FormulaFields["Combination"].Text = clsCommon.fncsetstring(clsHelpMethods_Local.getCombinationMaterialByProductionJobID(oOrder.Job_ID.ToString()));
                           // RD.DataDefinition.FormulaFields["Gauge"].Text = clsCommon.fncsetstring(clsHelpMethods_Local.getCombinationMaterialThicknessByProductionJobID(oOrder.Job_ID.ToString()));
                            RD.DataDefinition.FormulaFields["PONo"].Text = clsCommon.fncsetstring(sPONo != "" ? sPONo : sOrderRefNo);
                            RD.DataDefinition.FormulaFields["BatchNo"].Text = clsCommon.fncsetstring(oOrder.BatchNo);
                        }
                        catch (Exception)
                        {

                        }
                    }

                    if ((clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.production.ToString()) && !chkPrintWithBreakdown.Checked)
                    {
                        RD.DataDefinition.FormulaFields["StoreName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_Store(oOrder.Store_ID));
                        RD.DataDefinition.FormulaFields["StoreAddress"].Text = clsCommon.fncsetstring(clsGenaralName.getAddress_Store(oOrder.Store_ID));
                    }

                    if (clsConfig.bDirectPrint_NP_DeliveryOrder) //Direct Print
                    {
                        RD.DataDefinition.RecordSelectionFormula = sFormula;
                        clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder), ref RD);
                        RD.PrintToPrinter(1, false, 0, 0);

                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DucumentPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else //View And Print
                    {
                        viewer.crystalReportViewer1.ReportSource = RD;
                        viewer.crystalReportViewer1.SelectionFormula = sFormula;
                        viewer.crystalReportViewer1.Visible = true;
                        viewer.crystalReportViewer1.DisplayToolbar = true;
                        viewer.crystalReportViewer1.CloseView(false);
                        viewer.WindowState = FormWindowState.Maximized;
                        viewer.ShowDialog();
                    }

                    RD.Close();
                    RD.Dispose();
                }
            }
            #endregion
        }
        #endregion

        private void dgvBreakdown_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //if (e.RowIndex >= 0)
            //{
            //    string sColName = "";
            //    DataGridView dgv = (DataGridView)sender;
            //    if (e.ColumnIndex >= 0)
            //        sColName = dgv.Columns[e.ColumnIndex].Name;
            //}
        }
        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (txtCustomerBranchID.Tag != null && txtCustomerBranchID.Tag.ToString().Trim().Length > 0)
            {
                if (txtCustomerBranchID.Tag.ToString() != "default")
                {
                    // frmSetCustomerBranch frm = new frmSetCustomerBranch();
                    //  int iBranchCode = int.Parse(txtCustomerBranchID.Tag.ToString());
                    //frm.glbBranchCode = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                    //  frm.glbBranchCode = txtCustomerBranchID.Tag.ToString();
                    //  frm.glbBranchName = txtCustomerBranchID.Text.Trim();
                    //frm.MdiParent = this.MdiParent;
                    //  frm.Show();
                }
            }
        }
        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (txtDeliveryOrderID.Text == "" && txtDeliveryOrderID.Tag == null && txtDeliveryOrderID.Text != "<Auto Generate>")
                MessageBox.Show("Please select a DO", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                frm_scsAddNewBarcode bc = new frm_scsAddNewBarcode();
                bc.show(txtDeliveryOrderID.Text.ToString(), iFormID);
            }
        }
        private void txtSalesRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }
        private void frm_sasDeliveryOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDeliveryOrderID.Text != null && txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForApproved), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetApproved login = new frmSetApproved();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetApproved.bChecked)
                                {
                                    bHasApproved = true;
                                    glbApprovedDate = clsSecurity.getServerDateTime();
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_sasDeliveryOrder objDO = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsApproved = true;
                                            objDO.DateApproved = clsSecurity.getServerDateTime();
                                            objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objDO.Update();
                                        }
                                    }
                                }
                                else if (frmSetApproved.bReset)
                                    bHasApproved = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtDeliveryOrderID.Text != null && txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForChecked), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                frmSetChecked login = new frmSetChecked();
                                login.iFormID = iFormID;
                                login.userID = clsSecurity.UserIDLoged;
                                login.ShowDialog();
                                if (frmSetChecked.bChecked)
                                {
                                    bHasChecked = true;
                                    glbCheckedDate = clsSecurity.getServerDateTime();

                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_sasDeliveryOrder objDO = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsChecked = true;
                                            objDO.DateChecked = clsSecurity.getServerDateTime();
                                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDO.Update();
                                        }
                                    }

                                }
                                else if (frmSetChecked.bReset)
                                    bHasChecked = false;
                            }
                        }
                        else
                            MessageBox.Show("Please Fill Details to Check", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void UserDetails()
        {
            try
            {
                if (txtDeliveryOrderID.Text != "" || txtDeliveryOrderID.Text != "<Auto Generate>")
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text);
                    if (detail != null)
                    {
                        DataTable dt_UserDetails = new DataTable();
                        dt_UserDetails.Columns.Add("usertype", typeof(string));
                        dt_UserDetails.Columns.Add("Column1", typeof(string));
                        dt_UserDetails.Columns.Add("user", typeof(string));
                        dt_UserDetails.Columns.Add("Column2", typeof(string));
                        dt_UserDetails.Columns.Add("datetime", typeof(string));

                        dt_UserDetails.Rows.Add("Created By", ":", clsGenaralName.getName_User(detail.CreateUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateCreate));

                        if (detail.DateCreate != detail.DateModified)
                            dt_UserDetails.Rows.Add("Last Modified By", ":", clsGenaralName.getName_User(detail.ModifiedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateModified));

                        if (detail.IsChecked)
                            dt_UserDetails.Rows.Add("Checked By", ":", clsGenaralName.getName_User(detail.CheckedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateChecked));

                        if (detail.IsApproved)
                            dt_UserDetails.Rows.Add("Approved By", ":", clsGenaralName.getName_User(detail.ApprovedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateApproved));

                        if (detail.IsDeleted)
                            dt_UserDetails.Rows.Add("Cancelled by", ":", clsGenaralName.getName_User(detail.DeletedUser_ID), "|", clsFormatter.FormatDate_Short_WithTime(detail.DateDeleted));

                        Point startPoint = this.PointToScreen(new Point());

                        frmApprovedCheckedValidity frm = new frmApprovedCheckedValidity();
                        frm.ShowWindow(startPoint.X, (startPoint.Y + this.Size.Height), dt_UserDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Settings Panel Events
        public override void SettingsClick()
        {
            if (xSetting.Visible == true)
                xSetting.Visible = false;
            else
            {
                xSetting.Visible = true;
                xSetting.Focus();
            }
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion

        private void SalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountedPrice = 0, dAmount = 0;
                bool bIsFreeItem = false;
                decimal UnitOrWaitedPrice = 0, dQty = 0, dWet = 0;

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                dDiscountPresentage = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscuntPresentage", e.RowIndex, decimal.Parse("0.00")));
                dDiscountedPrice = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscountValue", e.RowIndex, decimal.Parse("0.00")));

                //if (!bWeightCalculation)
                //{
                dQty = dQuantity = clsFormatter.RoundDecimalPlaces_Quantity(clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00")));
                //UnitOrWaitedPrice = 
                dUnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00")));
                //}
                //else if (bWeightCalculation)
                //{
                dWet = dWeight = clsFormatter.RoundDecimalPlaces_Weight(clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00")));
                //UnitOrWaitedPrice = 
                dWeightPrice = clsFormatter.RoundDecimalPlaces_WeightPrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00")));
                //}

                #region Discounts
                if (sColName == "DiscountValue")
                    dDiscountPresentage = clsFormatter.RoundDecimalPlaces(dDiscountedPrice * 100 / dUnitPrice);
                else if (sColName == "DiscuntPresentage")
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(dUnitPrice * dDiscountPresentage / 100);
                else
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(dUnitPrice * dDiscountPresentage / 100);
                #endregion

                #region Free Item
                if (bIsFreeItem)
                {
                    dDiscountPresentage = 100;
                    dDiscountedPrice = dUnitPrice;

                    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                else
                {
                    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                }
                #endregion

                //dAmount = clsFormatter.RoundDecimalPlaces((UnitOrWaitedPrice - dDiscountedPrice) * dQty);

                dAmount = clsFormatter.RoundDecimalPlaces((dUnitPrice - dDiscountedPrice) * dQty);

                dgvDetail["Quantity", e.RowIndex].Tag = dQuantity;
                dgvDetail["Quantity", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                dgvDetail["Weight", e.RowIndex].Tag = dWeight;
                dgvDetail["Weight", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeight);
                dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);


                dgvDetail["DiscuntPresentage", e.RowIndex].Tag = dDiscountPresentage;
                dgvDetail["DiscountValue", e.RowIndex].Tag = dDiscountedPrice;

                dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}