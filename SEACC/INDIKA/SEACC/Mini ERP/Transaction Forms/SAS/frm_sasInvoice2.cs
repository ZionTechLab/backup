using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataTire;
using Zion.ERP.Reports.DataSets.SAS;
using Zion.ERP.Reports.DataSets;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using CrystalDecisions.CrystalReports.Engine;

using SEACC.DATA.Data;
using SEACC.DATA.Data.MAS;
using ZION.ERP.Reports.DataSets.SAS;

namespace Digiteq
{
    public partial class frm_sasInvoice2 : SEACC_Form
    {
        
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbDeliveryOrderID = "", glbCustomerOrderID = "", glbInvoiceID = "";

        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;
        bool bIsOverriddenInvoice_30Days_CrExeed = false;
        bool bIsOverriddenInvoice_60Days_CrExeed = false;

        dts_sasInvoice glb_dtsSasInvoice = new dts_sasInvoice();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //for handle Duplicate Item  Validations
        public DataTable dt_ItemGrouped = new DataTable();
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_sasInvoice2(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
            bHasPermissionToLineDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_LineDiscount));
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);

            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsFormatter.ApplyGridFormat_New(dgr_delivaryOrder, clsFormatter.colorGrid, UI_Color);

            ClearFields();
            FormatDataGridView();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            clsFill.Fill_ItemPrices(ref cmbItemPrice);

            if (glbDeliveryOrderID.Length > 0)
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(glbDeliveryOrderID);
                if (detail != null)
                {
                    FillDetails_DeliveryOrder(detail.DeliveryOrder_ID);
                }
            }
            else if (glbCustomerOrderID.Length > 0)
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(glbCustomerOrderID);
                if (detail != null)
                {
                    txtCustomerOrderID.Text = detail.CustomerOrder_ID;
                    txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                    btnAddCustomerOrder_Click(sender, new EventArgs());
                }
            }
            else if (glbInvoiceID.Length > 0)
                FillDetails(glbInvoiceID);


            #region Load Discount names
            foreach (tbl_zDiscount oDiscount in tbl_zDiscount.SelectAll())
            {
                switch (oDiscount.Discount_Id)
                {
                    case "D001":
                        chkDisc1.Text = oDiscount.DiscountName;
                        break;
                    case "D002":
                        chkDisc2.Text = oDiscount.DiscountName;
                        break;
                    case "D003":
                        chkDisc3.Text = oDiscount.DiscountName;
                        break;
                    default:
                        break;
                }
            }
            #endregion
        }
        #endregion

        #region Btn New
        private void frm_sasInvoice2_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Remove
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void frm_sasInvoice2_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    #region Tax Type Flags
                    //if some one change the tax type then this flags are gone  wrong.(2018-07-05)
                    bool bIsVatInvoice = chkVat.Checked ? true : false;
                    bool bIsSvatInvoice = chkOtherTax.Checked ? true : false;

                    //bool bIsVatInvoice = clsHelpMethods.isTaxActiveNote(txtVat);
                    //bool bIsSvatInvoice = clsHelpMethods.isTaxActiveNote(txtOtherTax); 
                    #endregion

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_sasInvoice oldRecord = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) && !oldRecord.IsTaxReverseCalulation)//&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID2) &&
                        {
                            if (ValidateForDependancies(oldRecord.Invoice_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtInvoiceID.Text))
                                        {

                                            //tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldRecord.GlPosting_ID);
                                            clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                            //Write Audit Trial Log
                                            clsLog.Process_Modify(iFormID,
                                                clsAutocode.GetProcessNoteID(ProcessNote.Invoice), oldRecord.Invoice_ID,
                                                "Invoice");

                                            //Invoice Detail                                   

                                            #region Update old Details

                                            List<tbl_sasInvoice_Detail> oldInvDetails =
                                                tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim());
                                            foreach (tbl_sasInvoice_Detail oldInvDetail in oldInvDetails)
                                            {
                                                string sLineNo = "",
                                                    sItemCode = "",
                                                    sDeliveryOrderCode = "",
                                                    sCusOrderCode = "",
                                                    sQuotationCode = "",
                                                    sJobCode = "",
                                                    sItemSubCategoryID = "",
                                                    sItemSubCategoryID2 = "",
                                                    sItemSerialNo = "",
                                                    sItemSerialNo2 = "",
                                                    sRemarks = "",
                                                    sUOM = "";
                                                decimal dWeightPrice = 0,
                                                    dUnitPrice = 0,
                                                    dQuantity = 0,
                                                    dWeight = 0,
                                                    dDiscountPresentage = 0,
                                                    dDiscountValue = 0,
                                                    dAmount = 0;
                                                bool bHasInvoInDB = false, bIsFreeIssue = false;

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo",
                                                        row.Index, "0");
                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                        row.Index, "");
                                                    sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "DeliveryOrderCode", row.Index, "default");
                                                    sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "CusOrderCode", row.Index, "default");
                                                    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "QuotationCode", row.Index, "default");
                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                        row.Index, "default");
                                                    sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index,
                                                        "default");
                                                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice",
                                                        row.Index, decimal.Parse("0.00"));


                                                    bIsFreeIssue =
                                                        clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index,
                                                            "") == "True"
                                                            ? true
                                                            : false;
                                                    dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail,
                                                        "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                                    dDiscountValue = clsValidate.ValidateGridTag(dgvDetail,
                                                        "DiscountValue", row.Index, decimal.Parse("0.00"));

                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount",
                                                        row.Index, decimal.Parse("0.00"));
                                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail,
                                                        "ItemSubCategoryID", row.Index, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail,
                                                        "ItemSubCategoryID2", row.Index, "default");
                                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail,
                                                        "ItemSerialNo", row.Index, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail,
                                                        "ItemSerialNo2", row.Index, "0");
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks",
                                                        row.Index, "");

                                                    if (oldInvDetail.Invoice_ID == txtInvoiceID.Text.Trim() &&
                                                        oldInvDetail.Item_ID == sItemCode &&
                                                        oldInvDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                                        oldInvDetail.ItemSubCategory2_ID == sItemSubCategoryID2 &&
                                                        oldInvDetail.ItemSerialNo == sItemSerialNo &&
                                                        oldInvDetail.ItemSerialNo2 == sItemSerialNo2)
                                                    {
                                                        bHasInvoInDB = true;

                                                        #region FIFO Price Calculation

                                                        //   clsProcessMethods.FIFOPriceCalculation(int.Parse(sLineNo), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, oldInvDetail.Invoice_ID, oldInvDetail.DeliveryOrder_ID, ProcessNote.Invoice, false, false, true);

                                                        #endregion

                                                        dgvDetail.Rows.RemoveAt(row.Index);
                                                        break; //database contain this item
                                                    }
                                                }

                                                if (bHasInvoInDB)
                                                {
                                                    //Get Unit Price with Exchange rate to save
                                                    dUnitPrice =
                                                        clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                    dWeightPrice =
                                                        clsHelpMethods_Local.getSavePrice(dWeightPrice,
                                                            txtCurrencyRate);
                                                    dAmount = clsHelpMethods_Local.getSavePrice(dAmount,
                                                        txtCurrencyRate);

                                                    //////Update Other Tables

                                                    #region Update Delivery Order

                                                    if (sDeliveryOrderCode != "default")
                                                    {
                                                        tbl_sasDeliveryOrder_Detail DoItem =
                                                            tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo),
                                                                sDeliveryOrderCode, sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                        if (DoItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked)
                                                                DoItem.QtySettle =
                                                                    (DoItem.QtySettle - oldInvDetail.Qty) + dQuantity;
                                                            else
                                                                DoItem.WeightSettle =
                                                                    (DoItem.WeightSettle - oldInvDetail.Weight) +
                                                                    dWeight;
                                                            DoItem.Update();
                                                            clsProcessMethods.SetSettle_DeliveryOrder(
                                                                sDeliveryOrderCode, chkUnitPricing, false);
                                                        }
                                                    }

                                                    #endregion

                                                    #region Update Customer Order

                                                    if (sCusOrderCode != "default")
                                                    {
                                                        tbl_sasCustomerOrder_Detail CoItem =
                                                            tbl_sasCustomerOrder_Detail.Select(int.Parse(sLineNo),
                                                                sCusOrderCode, sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                        if (CoItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked)
                                                                CoItem.QtySettle_Invoice =
                                                                    (CoItem.QtySettle_Invoice - oldInvDetail.Qty) +
                                                                    dQuantity;
                                                            else
                                                                CoItem.WeightSettle_Invoice =
                                                                    (CoItem.WeightSettle_Invoice -
                                                                     oldInvDetail.Weight) + dWeight;
                                                            CoItem.Update();
                                                            //clsProcessMethods.SetSettle_CustomerOrderFrom_Invoice(sCusOrderCode, chkUnitPricing);
                                                        }
                                                    }

                                                    #endregion


                                                    //////Update Invoice Detail Table

                                                    #region Update Invoice Detail Table

                                                    oldInvDetail.Line_No = int.Parse(sLineNo);
                                                    oldInvDetail.Item_ID = sItemCode;
                                                    oldInvDetail.Customer_ID = txtCustomerID.Tag.ToString();
                                                    oldInvDetail.Quotation_ID = sQuotationCode;
                                                    oldInvDetail.CustomerOrder_ID = sCusOrderCode;
                                                    oldInvDetail.DeliveryOrder_ID = sDeliveryOrderCode;
                                                    oldInvDetail.Job_ID = sJobCode;
                                                    oldInvDetail.Qty = dQuantity;
                                                    oldInvDetail.Weight = dWeight;
                                                    oldInvDetail.UnitPrice = dUnitPrice;
                                                    oldInvDetail.WeightPrice = dWeightPrice;
                                                    oldInvDetail.BIsFreeItem = bIsFreeIssue;
                                                    oldInvDetail.DiscountPresentage = dDiscountPresentage;
                                                    oldInvDetail.DiscountAmount = dDiscountValue;
                                                    oldInvDetail.TatalAmount = dAmount;
                                                    oldInvDetail.Remark = sRemarks;
                                                    oldInvDetail.Uom_ID = sUOM;
                                                    oldInvDetail.Update();

                                                    #endregion

                                                    #region FIFO Price Calculation

                                                    //    clsProcessMethods.FIFOPriceCalculation(int.Parse(sLineNo), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, oldInvDetail.Invoice_ID, sDeliveryOrderCode, ProcessNote.Invoice, false, true, false);

                                                    #endregion
                                                }
                                                else
                                                {
                                                    oldInvDetail.Delete();
                                                }
                                            }

                                            #endregion

                                            #region Newlly Added Items insert

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                string sLineNo = "",
                                                    sItemCode = "",
                                                    sDeliveryOrderCode = "",
                                                    sCusOrderCode = "",
                                                    sQuotationCode = "",
                                                    sJobCode = "",
                                                    sItemSubCategoryID = "",
                                                    sItemSubCategoryID2 = "",
                                                    sItemSerialNo = "",
                                                    sItemSerialNo2 = "",
                                                    sRemarks = "",
                                                    sUOM = "";
                                                decimal dWeightPrice = 0,
                                                    dUnitPrice = 0,
                                                    dQuantity = 0,
                                                    dWeight = 0,
                                                    dDiscountPresentage = 0,
                                                    dDiscountValue = 0,
                                                    dAmount = 0,
                                                    dRecommendedUnitPrice = 0,
                                                    dRecommendedWeightPrice = 0,
                                                    dRecommendedAmount = 0;

                                                bool bIsFreeIssue = false;

                                                sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                    "0");
                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                    row.Index, "");
                                                sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail,
                                                    "DeliveryOrderCode", row.Index, "default");
                                                sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode",
                                                    row.Index, "default");
                                                sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,
                                                    "QuotationCode", row.Index, "default");
                                                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                    row.Index, "default");
                                                sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index,
                                                    "default");
                                                dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice",
                                                    row.Index, decimal.Parse("0.00"));
                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                    decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice",
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

                                                dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index,
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
                                                    //tbl_sasInvoice_Detail items = new tbl_sasInvoice_Detail(clsHelpMethods.GetMaxzimumLineNo_Invoice(txtInvoiceID.Text.Trim()), txtInvoiceID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2,
                                                    //    sItemSerialNo, sItemSerialNo2, sDeliveryOrderCode, txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode, sJobCode, dQuantity, 0, dWeight, 0,
                                                    //    dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM);
                                                    tbl_sasInvoice_Detail items = new tbl_sasInvoice_Detail(
                                                        int.Parse(sLineNo), txtInvoiceID.Text.Trim(), sItemCode,
                                                        sItemSubCategoryID, sItemSubCategoryID2,
                                                        sItemSerialNo, sItemSerialNo2, sDeliveryOrderCode,
                                                        txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode,
                                                        sJobCode, dQuantity, 0, dWeight, 0,
                                                        dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage,
                                                        dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                                        dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                    items.Insert();

                                                    //////Update Other Table

                                                    #region Update Delivery Order

                                                    if (sDeliveryOrderCode != "default")
                                                    {
                                                        tbl_sasDeliveryOrder_Detail DoItem =
                                                            tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo),
                                                                sDeliveryOrderCode, sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                        if (DoItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked)
                                                                DoItem.QtySettle = DoItem.QtySettle + dQuantity;
                                                            else
                                                                DoItem.WeightSettle = DoItem.WeightSettle + dWeight;
                                                            DoItem.Update();
                                                        }

                                                        clsProcessMethods.SetSettle_DeliveryOrder(sDeliveryOrderCode,
                                                            chkUnitPricing, false);
                                                    }

                                                    #endregion

                                                    #region Update Customer Order

                                                    if (sCusOrderCode != "default")
                                                    {
                                                        tbl_sasCustomerOrder_Detail CoItem =
                                                            tbl_sasCustomerOrder_Detail.Select(int.Parse(sLineNo),
                                                                sCusOrderCode, sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                        if (CoItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked)
                                                                CoItem.QtySettle_Invoice =
                                                                    CoItem.QtySettle_Invoice + dQuantity;
                                                            else
                                                                CoItem.WeightSettle_Invoice =
                                                                    CoItem.WeightSettle_Invoice + dWeight;
                                                            CoItem.Update();
                                                            //clsProcessMethods.SetSettle_CustomerOrderFrom_Invoice(sCusOrderCode, chkUnitPricing);
                                                        }
                                                    }

                                                    #endregion

                                                    #region FIFO Price Calculation

                                                    //  clsProcessMethods.FIFOPriceCalculation(int.Parse(sLineNo), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, txtInvoiceID.Text.Trim(), sDeliveryOrderCode, ProcessNote.Invoice, true, false, false);

                                                    #endregion
                                                }
                                            }

                                            #endregion

                                            //Attachments.Insert(iFormID, oldRecord.Invoice_ID);
                                            //Attachments.Remove(iFormID, oldRecord.Invoice_ID);

                                            //Invoice Header

                                            #region Update Invoice Header

                                            bool bIsLocked = oldRecord.IsLocked;
                                            //if (chkReverseCalculation.Checked)
                                            //    bIsLocked = true;

                                            tbl_sasInvoice detail = new tbl_sasInvoice(txtInvoiceID.Text.Trim(),
                                                sFormConfigCode, dtpInvoiceDate.Value, txtRemark.Text.Trim(),
                                                txtAddress.Text.Trim(), txtAmountInWord.Text.Trim(),
                                                txtCustomerID.Tag.ToString(), txtQuotationID.Tag.ToString(),
                                                txtCustomerOrderID.Tag.ToString(),
                                                txtDeliveryOrder.Tag.ToString(), "default",
                                                txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo,
                                                oldRecord.ChequeRegister_ID,
                                                txtCurrencyID.Tag.ToString(), oldRecord.GlPosting_ID,
                                                oldRecord.PostingStatus_ID, oldRecord.PostingStatus_ID2,
                                                oldRecord.FinancialYear_ID, txtSalesNoteType.Tag.ToString(),
                                                decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                                decimal.Parse(txtPercentageDisc1.Text.Trim()),
                                                decimal.Parse(txtPercentageDisc2.Text.Trim()),
                                                decimal.Parse(txtPercentageDisc3.Text.Trim()),
                                                decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                decimal.Parse(txtPercentageVat.Text.Trim()),
                                                decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtDisc1.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtDisc2.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtDisc3.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), 0, 0,
                                                oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                oldRecord.DateCreate, clsSecurity.getServerDateTime(),
                                                oldRecord.DateChecked, oldRecord.DateApproved, oldRecord.DateDeleted,
                                                oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved,
                                                oldRecord.IsFinished,
                                                oldRecord.IsDeleted, txtPaymentTerms.Text.Trim(),
                                                txtPaymentMode.Text.Trim(), txtCreditPeriod.Text.Trim(),
                                                dtpDueDate.Value,
                                                bIsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled,
                                                oldRecord.IsSeattled_DO, oldRecord.PrintCount, oldRecord.IsDebitNote,
                                                oldRecord.IsOpeningBalance, oldRecord.IsReturnedCheque,
                                                oldRecord.IsPartPayment, oldRecord.IsAdvancePayment,
                                                !chkUnitPricing.Checked, false, bIsVatInvoice, bIsSvatInvoice,
                                                txtCustomerBranchID.Tag.ToString(), txtGrnNO.Text,
                                                ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, false,
                                                oldRecord.CompanyID, oldRecord.CompanyBranch_ID,
                                                false, 0, 0, 0, 0, 0,
                                                0, 0, 0, decimal.Parse(txtAdvanceReceived.Text),
                                                int.Parse(lblRoute.Tag.ToString()));
                                            detail.Update();
                                            //if (chkMultipleDiscount.Checked)
                                            //{
                                            //    oDiscount.sInvoice_ID = txtInvoiceID.Text.Trim();
                                            //    oDiscount.Update();
                                            //}

                                            #endregion

                                            clsMethods_GL.PostTransaction_Invoice2(txtInvoiceID.Text);

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
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
                    #endregion

                    #region Insert
                    else
                    {
                        #region Get invoice ID
                        clsAutocode.getAutoGeneratedCode_Invoice(sFormConfigCode, cmbTaxType.SelectedIndex, ref txtInvoiceID);
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtInvoiceID.Text)) //if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text.Trim() != "<Auto Generate>")
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                            if (oInvoice == null)
                            {
                                bool bIsLocked = false;

                                #region Invoice header
                                decimal dCurrancyRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                                tbl_sasInvoice detail = new tbl_sasInvoice(txtInvoiceID.Text.Trim(), sFormConfigCode, dtpInvoiceDate.Value, txtRemark.Text.Trim(), txtAddress.Text.Trim(), txtAmountInWord.Text.Trim(), txtCustomerID.Tag.ToString(), txtQuotationID.Tag.ToString(), txtCustomerOrderID.Tag.ToString(), txtDeliveryOrder.Tag.ToString(),
                                                        "default", txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default", txtCurrencyID.Tag.ToString(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                                                        txtSalesNoteType.Tag.ToString(), dCurrancyRate, decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageDisc1.Text.Trim()), decimal.Parse(txtPercentageDisc2.Text.Trim()), decimal.Parse(txtPercentageDisc3.Text.Trim()),
                                                        decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc1.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc2.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc3.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), 0, 0, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                        clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                                        false, txtPaymentTerms.Text.Trim(), txtPaymentMode.Text.Trim(), txtCreditPeriod.Text.Trim(), dtpDueDate.Value, bIsLocked, 0, false, false, 0, false, false, false, false, false, !chkUnitPricing.Checked, false, bIsVatInvoice, bIsSvatInvoice, txtCustomerBranchID.Tag.ToString(),
                                                        txtGrnNO.Text, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0, decimal.Parse(txtAdvanceReceived.Text), int.Parse(lblRoute.Tag.ToString()));
                                detail.Insert();
                                #endregion

                                #region Invoice Detail
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        string sLineNo = "", sItemCode = "", sUOM = "default", sDeliveryOrderCode = "", sCusOrderCode = "", sQuotationCode = "", sJobCode = "",
                                             sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                        decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountValue = 0, dAmount = 0, dRecommendedUnitPrice = 0,
                                            dRecommendedWeightPrice = 0, dRecommendedAmount = 0;
                                        bool bIsFreeIssue = false;

                                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                        sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                                        sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail, "CusOrderCode", row.Index, "default");
                                        sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                        dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                        sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                        dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                                        bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                        dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                        dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));
                                        dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));

                                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                        dRecommendedUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtCustomerID.Tag.ToString());
                                        dRecommendedWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                        if (chkUnitPricing.Checked)
                                            dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                        else
                                            dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                        //Get Unit Price with Exchange rate to save
                                        dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                        dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                        dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                        if (sItemCode.Length > 0)
                                        {
                                            //tbl_sasInvoice_Detail items = new tbl_sasInvoice_Detail(clsHelpMethods.GetMaxzimumLineNo_Invoice(txtInvoiceID.Text.Trim()), txtInvoiceID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                            //    sDeliveryOrderCode, txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode, sJobCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                            //    dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM);
                                            tbl_sasInvoice_Detail items = new tbl_sasInvoice_Detail(int.Parse(sLineNo), txtInvoiceID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                               sDeliveryOrderCode, txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode, sJobCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                               dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                            items.Insert();

                                            //////Update Other Tables
                                            #region Update Delivery Order
                                            if (sDeliveryOrderCode != "default")
                                            {
                                                tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                if (chkUnitPricing.Checked)
                                                    DoItem.QtySettle = DoItem.QtySettle + dQuantity;
                                                else
                                                    DoItem.WeightSettle = DoItem.WeightSettle + dWeight;
                                                DoItem.Update();
                                                clsProcessMethods.SetSettle_DeliveryOrder(sDeliveryOrderCode, chkUnitPricing, false);
                                            }
                                            #endregion

                                            #region Update Customer Order
                                            //else if (sCusOrderCode != "default")
                                            if (sCusOrderCode != "default")
                                            {
                                                tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(int.Parse(sLineNo), sCusOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                if (CoItem != null)
                                                {
                                                    if (chkUnitPricing.Checked)
                                                        CoItem.QtySettle_Invoice = CoItem.QtySettle_Invoice + dQuantity;
                                                    else
                                                        CoItem.WeightSettle_Invoice = CoItem.WeightSettle_Invoice + dWeight;
                                                    CoItem.Update();
                                                    //clsProcessMethods.SetSettle_CustomerOrderFrom_Invoice(sCusOrderCode, chkUnitPricing);
                                                }
                                            }
                                            #endregion

                                            #region FIFO Price Calculation Insert
                                            //    clsProcessMethods.FIFOPriceCalculation(int.Parse(sLineNo), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, detail.Invoice_ID, detail.DeliveryOrder_ID, ProcessNote.Invoice, true, false, false);
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }//error may come because last row of the grid may not have information
                                }
                                #endregion

                                Attachments.Insert(txtInvoiceID.Text.ToString());

                                clsMethods_GL.PostTransaction_Invoice2(txtInvoiceID.Text);

                                #region Send Alerts
                                try
                                {
                             
                                    //Email
                                    email.createEmail_Invoice(txtInvoiceID.Text.Trim(), enum_Alerts.InvoiceCreated);
                                    if (bIsOverriddenInvoice_30Days_CrExeed)
                                        email.createEmail_Warning_Alert_Exceeded_Credit_Days(txtInvoiceID.Text.Trim(), 30, enum_Alerts.Invoice_CreaditDaysExeedAlert);
                                    if (bIsOverriddenInvoice_60Days_CrExeed)
                                        email.createEmail_Warning_Alert_Exceeded_Credit_Days(txtInvoiceID.Text.Trim(), 60, enum_Alerts.Invoice_CreaditDaysExeedAlert);

                                    //SMS
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                                    {
                                        tbl_genEmployeeMaster oEmp = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID);
                                        if (oEmp != null && oEmp.Employee_ID != "default" && oEmp.Mobile.Trim().Length > 0)
                                        {
                                            string sMsg = "SEACC Alert - Invoiced Created - INV#:" + txtInvoiceID.Text.Trim() + " / Amount:" + clsGenaralName.getName_CurrencyCode(txtCurrencyID.Tag.ToString()) + txtGrandTotal.Text.Trim() + " / Name:" + oCustomer.CustomerName.Trim();
                                            clsUtil.CreateSMS_InvoiceCreate(enum_Alerts.sms_CreateInvoice, oEmp.Mobile, sMsg);
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    SEACCException.Show(ex);
                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                }
                                #endregion

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is alredy Exist...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Invoice " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID, ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                    if (detail != null)
                        FillDetails(detail.Invoice_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_sasInvoice2_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        public void print(bool isDraftPrint)
        {
            #region Tax Type Selection
            bool bTaxTypeSelection_OK = false;

            frm_TaxSelecion oTax = new frm_TaxSelecion(true);
            switch (cmbTaxType.SelectedIndex)
            {
                case 0:
                    bTaxTypeSelection_OK = true;
                    break;
                case 1:
                    oTax.ShowDialog();
                    if (oTax.DialogResult == DialogResult.OK)
                        bTaxTypeSelection_OK = true;
                    break;
                case 2:
                    bTaxTypeSelection_OK = true;
                    oTax.bSVatSelected = true;
                    oTax.bNbtSelected = true;
                    break;
            }
            #endregion

            if (bTaxTypeSelection_OK)
            {
                try
                {
                    if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
                    {
                        Cursor = Cursors.WaitCursor;

                        glb_dtsSasInvoice.Clear();
                        glb_dtsReportExport.Clear();

                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sExRate = "", sDuplicateCopy = "";
                        string sCreateUser = "[ None ]", sCheckedUser = "[ None ]", sCreateUserName = "[ None ]", sCheckedUserName = "[ None ]", sApprovedUser = "[ None ]", sCreateDate = "", sCheckedDate = "";
                        bool bCheckingDone = true, bApprovalDone = true, bPermissinOkToPrintOriginal = true, bCreditLimitOK = true;
                        string sPoNO = "-", sCusAddress = "", sDeliveryAddress = "", sDeliveryTel = "", sSalesmanName = "", sBranchId = "";

                        string sReportID = clsAutocode.getReportID(enum_ReportName.NP_Invoice_2);
                        if (oTax.bIsPrePrint)
                            sReportID = clsAutocode.getReportID(enum_ReportName.NP_Invoice_Preprint);

                        if (clsHelpMethods_Local.GetReportPath(sReportID, ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(txtInvoiceID.Text);
                            if (oInvoice != null)
                            {
                                if (oInvoice.PrintCount > 0)
                                {
                                    if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 1101, true, false))
                                    {
                                        MessageBox.Show("Access Denied ! \n\nUser does not have access to Print duplicates, Please get permission from the system administrator ");
                                        return;
                                    }
                                }

                                #region Validation
                                if (!isDraftPrint)
                                {
                                    #region Validate Approval
                                    if (clsConfig.bApprovalNeedToPrintInvoice)
                                    {
                                        if (!oInvoice.IsApproved)
                                        {
                                            bApprovalDone = false;
                                            MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion
                                    #region Validate Checking
                                    if (clsConfig.bCheckingNeedToPrintInvoice)
                                    {
                                        if (!oInvoice.IsChecked)
                                        {
                                            bCheckingDone = false;
                                            MessageBox.Show("Please Check the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion
                                    #region Validate Credit Limit
                                    decimal dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                    if (clsConfig.bCreditBalanceInvoice_Check)
                                    {
                                        if (oInvoice.GrandTotal < dCreditBalance || oInvoice.IsApproved)
                                            bCreditLimitOK = true;
                                        else
                                        {
                                            bCreditLimitOK = false;
                                            MessageBox.Show("Customer's available Credit Limit is Lower than Entered Amount.... \n  Please approve before printing this invoice", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        }
                                    }
                                    #endregion
                                    #region Validate Print Original
                                    if (chkPrintOriginal.Checked)
                                        bPermissinOkToPrintOriginal = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_Invoice_2));
                                    #endregion
                                }
                                #endregion

                                if (bApprovalDone && bCheckingDone && bCreditLimitOK && bPermissinOkToPrintOriginal)
                                {
                                    #region Draft print
                                    if (!isDraftPrint)
                                    {
                                        if (!chkPrintOriginal.Checked)
                                            sDuplicateCopy = (oInvoice.PrintCount > 0) ? "Duplicate Copy " + oInvoice.PrintCount : "";

                                        oInvoice.PrintCount++;
                                        oInvoice.DatePrinted = clsSecurity.getServerDateTime();
                                        oInvoice.PrintedTerminal_ID = clsSecurity.TerminalID;
                                        oInvoice.PrintedUser_ID = clsSecurity.UserIDLoged;
                                        oInvoice.Update();
                                    }
                                    #endregion

                                    #region Tax type selection
                                    bool bistaxInvoice = false;
                                    string sTaxType = "";

                                    if (cmbTaxType.SelectedIndex == 0)
                                        sTaxType = "COMMERCIAL";
                                    else if (oTax.bSVatSelected)
                                        sTaxType = "SVAT";
                                    else if (!oTax.bVatSelected && !oTax.bNbtSelected && !oTax.bSVatSelected)
                                        sTaxType = "NON TAX";
                                    else
                                    {
                                        sTaxType = "TAX";
                                        bistaxInvoice = true;
                                    }
                                    #endregion

                                    #region User Details
                                    sCreateUser = "[ " + clsGenaralName.getName_User(oInvoice.CreateUser_ID) + " ] [ " + oInvoice.DateCreate.ToShortDateString() + " ]";
                                    if (oInvoice.IsChecked)
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(oInvoice.CheckedUser_ID) + " ] [ " + oInvoice.DateChecked.ToShortDateString() + " ]";
                                    if (oInvoice.IsApproved)
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oInvoice.ApprovedUser_ID) + " ] [ " + oInvoice.DateApproved.ToShortDateString() + " ]";

                                    sCreateUserName = "[ " + clsGenaralName.getName_User(oInvoice.CreateUser_ID) + " ]";
                                    sCreateDate = oInvoice.DateCreate.ToString("dd/MM/yyyy hh:mm:ss tt");
                                    if (oInvoice.IsChecked)
                                    {
                                        sCheckedUserName = "[ " + clsGenaralName.getName_User(oInvoice.CheckedUser_ID) + " ]";
                                        sCheckedDate = oInvoice.DateChecked.ToString("dd/MM/yyyy hh:mm:ss tt");
                                    }
                                    if (oInvoice.IsApproved)
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oInvoice.ApprovedUser_ID) + " ] [ " + oInvoice.DateApproved.ToShortDateString() + " ]";

                                    #endregion

                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                                    if (oCustomer != null)
                                    {
                                        #region Get PO No
                                        foreach (tbl_sasCustomerOrder oCo in tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(oInvoice.OrderRefNo_ID))
                                        {
                                            if (oCo.PurchaseOrder_ID != "default")
                                                sPoNO = oCo.PurchaseOrder_ID;
                                        }
                                        #endregion

                                        #region Get Customer Branch
                                        if (oInvoice.Branch_ID != null && oInvoice.Branch_ID != "default")
                                        {
                                            tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oCustomer.Customer_ID, Convert.ToInt16(oInvoice.Branch_ID));
                                            sBranchId = oBranch.BranchName;
                                            //sDeliveryAddress = oBranch.Address != "" ? oBranch.Address : sDeliveryAddress;
                                            sDeliveryAddress = oBranch.Address;
                                            sDeliveryTel = oBranch.Telephone;
                                        }
                                        #endregion

                                        #region Customer Address / Tel No
                                        if (sDeliveryAddress == "")
                                        {
                                            sDeliveryAddress = oCustomer.AddressRegister;
                                            sDeliveryTel = oCustomer.Telephone;
                                        }
                                        #endregion

                                        #region Get Salesman
                                        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                                        if (oRef != null && oRef.OrderRefNo_ID != "default")
                                        {
                                            sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                        }
                                        #endregion

                                        #region Header
                                        decimal dDiscountTotal = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;

                                        decimal dDiscountPresentage = (oInvoice.SubTotal == 0) ? 0 : (dDiscountTotal * 100 / oInvoice.SubTotal);
                                        decimal dSubTotal = clsHelpMethods_Local.getDisplayPrice(oInvoice.SubTotal, oInvoice.CurrencyRate);
                                        dDiscountTotal = clsHelpMethods_Local.getDisplayPrice(dDiscountTotal, oInvoice.CurrencyRate);
                                        decimal dNbtAmout = clsHelpMethods_Local.getDisplayPrice(oInvoice.NbtTotal, oInvoice.CurrencyRate);
                                        decimal dvatAmount = clsHelpMethods_Local.getDisplayPrice(oInvoice.VatTotal, oInvoice.CurrencyRate);
                                        decimal dSvatAmount = clsHelpMethods_Local.getDisplayPrice(oInvoice.OtherTaxTotal, oInvoice.CurrencyRate);
                                        decimal dGrandToatal = clsHelpMethods_Local.getDisplayPrice(oInvoice.GrandTotal, oInvoice.CurrencyRate);

                                        clsHelpMethods.CalculateGrandTotalReverce(dGrandToatal, ref dvatAmount, oInvoice.VatPercentage, oTax.bVatSelected, ref dSvatAmount, oInvoice.OtherTaxPercentage, oTax.bSVatSelected, ref dNbtAmout, oInvoice.NbtPercentage, oTax.bNbtSelected, ref dDiscountTotal, dDiscountPresentage, ref dSubTotal);

                                        string sCOID = "";
                                        string sDOID = "";
                                        List<tbl_sasInvoice_Detail> oDOList = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID);
                                        var oDOs = oDOList.GroupBy(gb => new { gb.DeliveryOrder_ID }, (Key, group) => new { DOID = Key.DeliveryOrder_ID });
                                        foreach (var oDO in oDOs.OrderBy(p => (p.DOID)))
                                        {
                                            sDOID += oDO.DOID + " ";
                                        }

                                        var oCOs = oDOList.GroupBy(gb => new { gb.CustomerOrder_ID }, (Key, group) => new { COID = Key.CustomerOrder_ID });
                                        foreach (var oCO in oCOs.OrderBy(p => (p.COID)))
                                        {
                                            sCOID += oCO.COID + " ";
                                        }

                                        glb_dtsSasInvoice.dt_sasInvoice.Adddt_sasInvoiceRow(oInvoice.Invoice_ID, oInvoice.InvoiceDate, oInvoice.Customer_ID, oCustomer.CustomerName, oCustomer.AddressRegister,
                                            oCustomer.Telephone, sBranchId, "", "", "", sSalesmanName, "", sDeliveryAddress, sDeliveryTel, oInvoice.IsDeleted,
                                                "", "", dSubTotal, dDiscountPresentage, dDiscountTotal, dSubTotal, oInvoice.NbtPercentage, dNbtAmout, oInvoice.VatPercentage, dvatAmount,
                                                oInvoice.OtherTaxPercentage, dSvatAmount, dGrandToatal, oInvoice.CustomerOrder_ID, clsHelpMethods_Local.getCustomerPurchaseOrderID(oInvoice.OrderRefNo_ID), "",
                                                oCustomer.VatRegistrationNo, oCustomer.SvatRegistrationNo, oCustomer.NbtRegistrationNo, sTaxType, oInvoice.IsWeightCalculation, DateTime.Now,
                                                clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountPercentage1, oInvoice.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountPercentage2,
                                                oInvoice.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountPercentage3, oInvoice.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountTotal1, oInvoice.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountTotal2, oInvoice.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(oInvoice.DiscountTotal3, oInvoice.CurrencyRate), sPoNO, oInvoice.TatalAmountInWord, "", "",
                                                oInvoice.IsSVatInvoice, bistaxInvoice, oInvoice.PaymentTerms, oInvoice.Remark, oInvoice.Currency_ID, clsGenaralName.getName_CurrencyCode(oInvoice.Currency_ID), oInvoice.PaymentDueDate);
                                        #endregion

                                        #region Invoice Detail
                                        decimal dInvoiceSubTotal = clsHelpMethods_Local.getDisplayPrice(oInvoice.SubTotal, oInvoice.CurrencyRate);
                                        foreach (tbl_sasInvoice_Detail Detail1 in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID).OrderBy(p => p.Line_No))
                                        {
                                            decimal dUnitPrice = 0;

                                            tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(Detail1.Item_ID);
                                            tbl_zUom oUom = tbl_zUom.Select(Detail1.Uom_ID);
                                            if (oUom != null && oItmaster != null)
                                            {
                                                decimal dAmount = clsHelpMethods_Local.getDisplayPrice(Detail1.TatalAmount, oInvoice.CurrencyRate);
                                                decimal dLineDiscount = Detail1.DiscountAmount;
                                                dUnitPrice = Detail1.UnitPrice;

                                                if (!Detail1.BIsFreeItem)
                                                {
                                                    decimal dRatio = (dInvoiceSubTotal != 0) ? (dAmount / dInvoiceSubTotal) : 0;
                                                    dAmount = dSubTotal * dRatio;
                                                    dLineDiscount = (dAmount * Detail1.DiscountPresentage) / (100 - Detail1.DiscountPresentage);
                                                    dUnitPrice = (dAmount + dLineDiscount) / Detail1.Qty;
                                                }
                                                else
                                                {
                                                    if (!oTax.bNbtSelected)
                                                    {
                                                        dUnitPrice = dUnitPrice * (100 + oInvoice.NbtPercentage) / 100;
                                                    }
                                                    if (!oTax.bVatSelected)
                                                    { dUnitPrice = dUnitPrice * (100 + oInvoice.VatPercentage) / 100; }
                                                    //if (cmbTaxType.SelectedIndex == 0)
                                                    //    sTaxType = "COMMERCIAL";
                                                    //else if (oTax.bSVatSelected)
                                                    //    sTaxType = "SVAT";
                                                    //else if (!oTax.bVatSelected && !oTax.bNbtSelected && !oTax.bSVatSelected)
                                                    //    sTaxType = "NON TAX";
                                                    //else
                                                    //{
                                                    //    sTaxType = "TAX";
                                                    //    bistaxInvoice = true;
                                                    //}

                                                    //if (oTax.bNbtSelected)
                                                    //    dUnitPrice = dUnitPrice * (100 + oInvoice.NbtPercentage);
                                                    //if (oTax.bSVatSelected)
                                                    //    dUnitPrice = dUnitPrice * (100 + oInvoice.VatPercentage);
                                                }

                                                glb_dtsSasInvoice.dt_sasInvoice_Detail.Adddt_sasInvoice_DetailRow(Detail1.Invoice_ID, Detail1.Item_ID,
                                                oItmaster.Brand_ID, dUnitPrice, Detail1.Qty, oItmaster.ItemName, Detail1.Remark, oUom.UomCode, 0, "", Detail1.DiscountPresentage, dLineDiscount, dAmount, Detail1.BIsFreeItem, clsHelpMethods_Local.getDisplayPrice(Detail1.DiscountAmount, oInvoice.CurrencyRate) * Detail1.Qty, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID));
                                            }
                                        }
                                        #endregion

                                        #region Currency Rate
                                        tbl_zCurrency oCurrency = tbl_zCurrency.Select(oInvoice.Currency_ID);
                                        sExRate = clsFormatter.FormatDecimalPlaces_Price(oCurrency.CurrencyRate);
                                        #endregion

                                        #region Get Outstanding Amount

                                        decimal dTotalOutstanding = 0;
                                        //bool bIsChequeInHand = false;

                                        //DataTable dtOSL = DBHandling.ExecQuery("sp_bssCustomerOutstanding '" + "%" + "', '" + "%" + "', '" + "%" + "', '" 
                                        //    + oInvoice.Customer_ID + "', '" + "%" + "', '" + "%" + "' , '" + "2001-01-01', '" + clsSecurity.getServerDateTime().Date + "', "
                                        //    + false + ",  " + true + "  , " + false).Tables[0];

                                        //foreach (DataRow dr in dtOSL.Rows)
                                        //{                                            
                                        //    bIsChequeInHand = bool.Parse(dr["IsChequeInHand"].ToString()); ;

                                        //    if (!bIsChequeInHand)
                                        //        dTotalOutstanding += decimal.Parse(dr["Amount"].ToString());
                                        //}

                                        #endregion

                                        #region Parameters
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TotalOutstanding", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreateDate, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sCheckedDate, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", isDraftPrint ? "DRAFT" : "", true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ExchangeRate", sExRate, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CONumber", sCOID, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DONumber", sDOID, true);
                                        #endregion

                                        #region Company Details Fill
                                        string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                        byte[] bCompanyImage = clsCommon.getCompanyImage();
                                        if (isDraftPrint)
                                        {
                                            if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                            {
                                                sCompanyName = "";
                                                sCompanyAddress1 = "";
                                                sCompanyAddress2 = "";
                                                bCompanyImage = null;

                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", "", true);
                                            }
                                        }
                                        glb_dtsSasInvoice.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " " + sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                        #endregion

                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(sReportPath, glb_dtsSasInvoice, glb_dtsReportExport.dt_rptParameter, false, sReportID);
                                    }
                                }
                            }
                        }

                        email.createEmail_Invoice(txtInvoiceID.Text.Trim(), enum_Alerts.InvoicePrinted);
                    }
                    else
                        MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID, ex);
                }
                finally
                {
                    glb_dtsSasInvoice.dt_sasInvoice.Rows.Clear();
                    glb_dtsSasInvoice.dt_sasInvoice_Detail.Rows.Clear();
                    glb_dtsReportExport.dt_rptParameter.Rows.Clear();
                    Cursor = Cursors.Default;
                }
            }
        }
        private void frm_sasInvoice2_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Cancel
        private void frm_sasInvoice2_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                            if (detail != null)
                            {
                                if (ValidateForDependancies(detail.Invoice_ID))
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Invoice : " + detail.Invoice_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                clsMethods_GL.GLPosting_Delete(detail.GlPosting_ID);
                                                clsHelpMethods_Local.RemoveSattlementsFrom_InvoiceID(detail.Invoice_ID);

                                                #region Update Other Tables
                                                List<tbl_sasInvoice_Detail> Invdetails = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim());
                                                foreach (tbl_sasInvoice_Detail Invdetail in Invdetails)
                                                {
                                                    if (Invdetail.Item_ID != null)
                                                    {
                                                        //////Unsettle Delivery Order
                                                        #region Unsettle Delivery Order
                                                        if (Invdetail.DeliveryOrder_ID != null && Invdetail.DeliveryOrder_ID != "default")
                                                        {
                                                            tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(Invdetail.Line_No, Invdetail.DeliveryOrder_ID, Invdetail.Item_ID, Invdetail.ItemSubCategory_ID, Invdetail.ItemSubCategory2_ID, Invdetail.ItemSerialNo, Invdetail.ItemSerialNo2);
                                                            if (!detail.IsWeightCalculation)
                                                                DoItem.QtySettle = (DoItem.QtySettle - Invdetail.Qty);
                                                            else
                                                                DoItem.WeightSettle = (DoItem.WeightSettle - Invdetail.Weight);
                                                            DoItem.Update();
                                                            clsProcessMethods.SetSettle_DeliveryOrder(Invdetail.DeliveryOrder_ID, chkUnitPricing, false);
                                                        }
                                                        #endregion

                                                        //////Unsettle Customer Order
                                                        #region Unsettle Customer Order
                                                        //if (Invdetail.CustomerOrder_ID != null && Invdetail.CustomerOrder_ID != "default" && Invdetail.DeliveryOrder_ID == "default")
                                                        if (Invdetail.CustomerOrder_ID != null && Invdetail.CustomerOrder_ID != "default")
                                                        {
                                                            tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(Invdetail.Line_No, Invdetail.CustomerOrder_ID, Invdetail.Item_ID,
                                                                    Invdetail.ItemSubCategory_ID, Invdetail.ItemSubCategory2_ID, Invdetail.ItemSerialNo, Invdetail.ItemSerialNo2);
                                                            if (CoItem != null)
                                                            {
                                                                if (!detail.IsWeightCalculation)
                                                                    CoItem.QtySettle_Invoice = CoItem.QtySettle_Invoice - Invdetail.Qty;
                                                                else
                                                                    CoItem.WeightSettle_Invoice = CoItem.WeightSettle_Invoice - Invdetail.Weight;
                                                                CoItem.Update();
                                                                //clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(Invdetail.CustomerOrder_ID, chkUnitPricing);
                                                            }
                                                        }
                                                        #endregion

                                                        #region FIFO Price Calculation
                                                        //    clsProcessMethods.FIFOPriceCalculation(Invdetail.Line_No, Invdetail.Item_ID, Invdetail.ItemSubCategory_ID, Invdetail.ItemSubCategory2_ID, Invdetail.ItemSerialNo, Invdetail.ItemSerialNo2, Invdetail.Qty, Invdetail.Weight, Invdetail.Invoice_ID, Invdetail.DeliveryOrder_ID, ProcessNote.Invoice, false, false, true);
                                                        #endregion
                                                    }
                                                }
                                                #endregion

                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();

                                                email.createEmail_Invoice(txtInvoiceID.Text.Trim(), enum_Alerts.InvoiceCanceled);
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
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        foreach (ComboBoxItem d in cmbItemPrice.Items)
                        {
                            if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                            {
                                cmbItemPrice.SelectedItem = d;
                                break;
                            }
                        }

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

                        FillDetailsCurrency(detail.Currency_ID);
                        //  FillTaxDetailByDeliveryOrderID(glbDeliveryOrderID);
                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            FillDetailsCustomer(detail.Customer_ID);

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                        {
                            txtSalesNoteType.Tag = "Nt001";
                            txtSalesNoteType.Text = "Genaral";
                        }
                        else
                        {
                            txtSalesNoteType.Tag = "default";
                            txtSalesNoteType.Text = "default";
                        }
                        //add item details
                        RefreshGridByQuotationID(detail.Quotation_ID);
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

        #region Btn Add DeliveryOrder
        private void btnAddDeliveryOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrder, txtCustomerID.Tag.ToString(), false);
                else
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrder, "", false);

                if (txtDeliveryOrder.Tag != null && txtDeliveryOrder.Tag.ToString().Length > 0)
                    FillDetails_DeliveryOrder(txtDeliveryOrder.Tag.ToString());

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
            }
        }
        #endregion

        #region Btn Add CustomerOrder
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
                            bool bOktoProceed = true;
                            if ((FormName)iFormID == FormName.Invoice_TAXReverced)
                            {
                                if (detail.VatTotal > 0 || detail.NbtTotal > 0 || detail.OtherTaxTotal > 0)
                                {
                                    bOktoProceed = false;
                                    MessageBox.Show("Please remove Taxes from customer order to place tax inclusive invoice", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            if (bOktoProceed)
                            {
                                chkUnitPricing.Checked = !detail.IsWeightCalculation;

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

                                glbOrderRefNo = detail.OrderRefNo_ID;

                                txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                                txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                                //fill customer, branch and routes
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

                                FillDetailsCurrency(detail.Currency_ID);
                                FillTaxDetailByCustomerOrderID(detail.CustomerOrder_ID);

                                //add item details
                                RefreshGridByCustomerOrderID(detail.CustomerOrder_ID);
                            }
                            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
                        }
                        else
                        {
                            txtCustomerOrderID.Tag = null;
                            txtCustomerOrderID.Text = "";
                            MessageBox.Show("Sorry...! \nCannot Raised Invoice for Deactivated Customers", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Customer View
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            {
                frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                frm.glbCustomerID = txtCustomerID.Tag.ToString();
                if (frm.bNoAccess)
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    //frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
        }
        #endregion

        #region Btn Create Receipt
        private void btnCreateReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null && detail.Invoice_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledInvoice)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Invoice Before Create a Receipt";
                            }
                        }
                        if (clsConfig.bSettleEnabledInvoice)
                        {
                            if (detail.IsSeattled)
                            {
                                bAllowDetail = false;
                                message = "ALREADY SETTLED \n\nThis Invoice has already settled with a Receipt(s)";
                            }
                        }

                        if (bAllowDetail)
                        {
                            UC_bpsReceiptSales frm = new UC_bpsReceiptSales(FormName.UCReceipt);
                            frm.glbInvoiceID = detail.Invoice_ID;
                            //frm.glbOrderRefNo = detail.OrderRefNo_ID;
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
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

        #region Btn Create Receipt
        private void btnCreateDeliveryOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null && detail.Invoice_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledInvoice)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Invoice Before Create a Receipt";
                            }
                        }
                        if (clsConfig.bSettleEnabledInvoice)
                        {
                            if (detail.IsSeattled_DO)
                            {
                                bAllowDetail = false;
                                message = "ALREADY DELIVERED!! \n\nThis Invoice Quantity has already being issued by Delivery Order(s)";
                            }
                        }

                        if (bAllowDetail)
                        {
                            frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                            //frm.glbInvoiceID = detail.Invoice_ID;
                            frm.glbOrderRefNo = detail.OrderRefNo_ID;
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
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

        #region Btn Temp
        private void frm_sasInvoice2_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                clsCommon.SetEnableDisable_NormalComboBox(cmbTaxType, true);

                txtInvoiceID.Tag = null;
                dtpInvoiceDate.Value = clsSecurity.getServerDateTime();

                //Reset User Details
                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);

                if (txtInvoiceID.Enabled)
                {
                    txtInvoiceID.SelectAll();
                    txtInvoiceID.Focus();
                }

                Attachments.Clear();
                ucSasProcessFlow.ClearFlow();
            }
        }
        #endregion

        #region Btn Branch
        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (txtCustomerBranchID.Tag != null && txtCustomerBranchID.Tag.ToString().Trim().Length > 0)
            {
                if (txtCustomerBranchID.Tag.ToString() != "default")
                {
                    // frmSetCustomerBranch frm = new frmSetCustomerBranch();
                    int iBranchCode = int.Parse(txtCustomerBranchID.Tag.ToString());
                    //  frm.glbBranchCode = txtCustomerBranchID.Tag.ToString();
                    //  frm.glbBranchName = txtCustomerBranchID.Text.Trim();
                    //frm.MdiParent = this.MdiParent;
                    //frm.Show();
                }
            }
        }
        #endregion

        #region Datagrid Format

        private void FormatDataGridView()
        {
            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_Invoice ? true : false;
            dgvDetail.Columns["Quantity"].ReadOnly = clsConfig.bEnableGridLock_Quantity_Invoice ? true : false;

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgr_delivaryOrder, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            //clsHelpMethods_Local.FormatGrid_Sales(dgr_delivaryOrder);

            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            //Grid Locks
            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_Invoice ? true : false;
            dgvDetail.Columns["Quantity"].ReadOnly = clsConfig.bEnableGridLock_Quantity_Invoice ? true : false;

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
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            if (clsConfig.bHide_SpecialSettings_Invoice)
                xSetting.Visible = false;

            IsUpdate = false;
            x2.Enabled = true;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
            clsCommon.SetEnableDisable_NormalComboBox(cmbTaxType, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            if (clsConfig.bHide_NoteType_Invoice)
            {
                txtSalesNoteType.Visible = false;
                lblSalesNoteType.Visible = false;
            }

            txtInvoiceID.Tag = null;
            txtCustomerID.Tag = null;
            txtDeliveryOrder.Tag = null;
            txtCustomerOrderID.Tag = null;
            txtQuotationID.Tag = null;

            txtCustomerBranchID.Tag = null;
            txtSalesNoteType.Tag = null;
            lblRoute.Tag = null;

            lblRoute.Text = "";
            txtCustomerID.Clear();
            txtDeliveryOrder.Clear();
            txtCustomerOrderID.Clear();
            txtQuotationID.Clear();

            txtPaymentMode.Clear();
            txtPaymentTerms.Clear();
            txtCreditPeriod.Clear();
            txtAddress.Clear();
            txtRemark.Clear();
            txtAmountInWord.Clear();
            glbOrderRefNo = "";
            dtpInvoiceDate.Value = clsSecurity.getServerDateTime();
            dtpDueDate.Value = clsSecurity.getServerDateTime().AddDays(30);
            chkUnitPricing.Checked = true;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            txtCustomerBranchID.Clear();
            txtSalesNoteType.Clear();

            txtGrnNO.Clear();

            txtGrandTotal.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtVat.Text = "0.00";
            txtAdvanceReceived.Text = "0.00";

            txtPercentageDiscount.Text = "0";
            txtPercentageDisc1.Text = "0";
            txtPercentageDisc2.Text = "0";
            txtPercentageDisc3.Text = "0";

            txtPercentageDiscount.Tag = 0;
            txtPercentageDisc1.Tag = 0;
            txtPercentageDisc2.Tag = 0;
            txtPercentageDisc3.Tag = 0;

            txtDiscount.Tag = 0;
            txtDisc1.Tag = 0;
            txtDisc2.Tag = 0;
            txtDisc3.Tag = 0;

            txtDiscount.Text = "0.00";
            txtDisc1.Text = "0.00";
            txtDisc2.Text = "0.00";
            txtDisc3.Text = "0.00";

            chkDiscount.Enabled = true;
            SetCustomerWiceDiscount("default");

            chkDiscount.Checked = false;

            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            cmbTaxType.SelectedIndex = 1;
            TaxTypeSelection();
            //  chkNBT.Checked = false;
            // chkOtherTax.Checked = false;
            //  chkVat.Checked = false;

            //  chkVat.Enabled = false;
            // chkNBT.Enabled = false;
            //  chkOtherTax.Enabled = false;


            //  pnlNbt.Visible = true;
            //  pnlVat.Visible = true;
            //   pnlSvat.Visible = true;

            dgvDetail.Rows.Clear();
            dgr_delivaryOrder.Rows.Clear();
            DisableMoneyControls();
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            //   chkSettings.Checked = true;
            chkSettings2.Checked = true;

            txtDiscount.Enabled = true;
            txtPercentageDiscount.Enabled = true;

            txtInvoiceID.Clear();
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);

            dt_ItemGrouped.Clear();
            btnAddDeliveryOrder.Enabled = true;
            txtDeliveryOrder.Enabled = true;
            btnAddCustomerOrder.Enabled = true;
            txtCustomerOrderID.Enabled = true;

            dtpInvoiceDate.Enabled = !clsConfig.bLock_TransactionDate_SAS;

            if (txtInvoiceID.Enabled)
            {
                txtInvoiceID.SelectAll();
                txtInvoiceID.Focus();
            }

            bIsOverriddenInvoice_30Days_CrExeed = false;
            bIsOverriddenInvoice_60Days_CrExeed = false;

            Attachments.Clear();

            ucSasProcessFlow.ClearFlow();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sInvoiceID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                foreach (tbl_sasInvoice_Detail detail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoiceID).OrderBy(p => p.Line_No))
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, detail.CustomerOrder_ID, detail.Quotation_ID, detail.Job_ID, clsCommon.GetForeignKeyValue(detail.Uom_ID), detail.UnitPrice, detail.WeightPrice,
                             detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
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
                foreach (tbl_sasCustomerOrder_Detail detail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID).OrderBy(p => p.Line_No))
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle_Invoice > 0 || detail.WeightSettle_Invoice > 0)
                            bHasSettledBefore = true;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, "default", detail.CustomerOrder_ID, detail.Quotation_ID, clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID),
                            item.Uom_ID, detail.UnitPrice, 0, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_Invoice), (detail.Qty - detail.QtySettle_Invoice),
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();

                //btnAddDeliveryOrder.Enabled = false;
                txtDeliveryOrder.Enabled = false;
                btnAddCustomerOrder.Enabled = false;
                txtCustomerOrderID.Enabled = false;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByQuotationID(string sQuotaion)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotaion).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasQuotation_Detail detail in details)
                {
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

                        decimal dQty = (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString()) ? detail.Qty : (detail.Qty - detail.QtySettle_Invoice);
                        decimal dWeight = (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString()) ? detail.Weight : (detail.Weight - detail.WeightSettle_Invoice);

                        Fill_Datagrid(iRow, iRow, detail.Item_ID, "default", "default", detail.Quotation_ID, "default",
                            detail.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, dWeight, dQty,
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
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
        private void RefreshGridByDeliveryOrderID(string sDeliveryOrder)
        {
            try
            {
                int iRow;
                foreach (tbl_sasDeliveryOrder_Detail detail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrder).OrderBy(p => p.Line_No))
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(detail.Item_ID);
                    if (oItem != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0 || detail.QtyReturned > 0)
                            bHasSettledBefore = true;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, detail.CustomerOrder_ID, detail.Quotation_ID, detail.Job_ID, oItem.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem,
                             detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, oItem.Width, oItem.Height, oItem.Thickness, oItem.Gusset, (detail.Weight - detail.WeightSettle - detail.WeightReturned), (detail.Qty - detail.QtySettle - detail.QtyReturned),
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
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

        private void RefreshDOGrid(string sDeliveryOrder, DateTime DeliveryOrderDate)
        {
            try
            {
                int iRow;

                dgr_delivaryOrder.Rows.Add();
                iRow = dgr_delivaryOrder.Rows.Count - 1;

                dgr_delivaryOrder["DONo", iRow].Value = sDeliveryOrder;
                dgr_delivaryOrder["date", iRow].Value = clsFormatter.FormatDate_Short(DeliveryOrderDate);
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
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalComboBox(cmbTaxType, false);

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                        txtDeliveryOrder.Tag = detail.DeliveryOrder_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;

                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtGrnNO.Text = detail.CustomerGrnNo;

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        SetCustomerWiceDiscount(detail.Customer_ID);

                        txtCustomerOrderID.Text = clsCommon.GetForeignKeyValue(detail.CustomerOrder_ID);
                        txtDeliveryOrder.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);

                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        #region Price catagory
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
                        #endregion

                        txtInvoiceID.Text = detail.Invoice_ID;
                        txtRemark.Text = detail.Remark;
                        dtpInvoiceDate.Value = detail.InvoiceDate;
                        dtpDueDate.Value = detail.PaymentDueDate;
                        txtPaymentMode.Text = detail.PaymentMode;
                        txtPaymentTerms.Text = detail.PaymentTerms;
                        txtCreditPeriod.Text = detail.CreditPeriod;

                        chkUnitPricing.Checked = !detail.IsWeightCalculation;

                        txtAmountInWord.Text = detail.TatalAmountInWord;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        //chkSettings.Checked = false;
                        chkSettings2.Checked = false;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtAddress.Text = detail.Address;

                        #region Customer Branch
                        if (detail.Branch_ID != "default")
                        {
                            txtCustomerBranchID.Text = clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID));
                            txtCustomerBranchID.Tag = detail.Branch_ID;
                            lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(detail.Route_ID);
                            lblRoute.Tag = detail.Route_ID;
                        }
                        #endregion

                        #region discount
                        if (detail.DiscountTotal > 0)
                        {
                            chkDiscount.Checked = true;
                            txtDiscount.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate);
                            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        }

                        if (detail.DiscountTotal1 > 0)
                        {
                            chkDisc1.Checked = true;
                            txtDisc1.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal1, detail.CurrencyRate);
                            txtDisc1.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal1, detail.CurrencyRate));
                            txtPercentageDisc1.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage1);
                        }

                        if (detail.DiscountTotal2 > 0)
                        {
                            chkDisc2.Checked = true;
                            txtDisc2.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal2, detail.CurrencyRate);
                            txtDisc2.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal2, detail.CurrencyRate));
                            txtPercentageDisc2.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage2);
                        }

                        if (detail.DiscountTotal3 > 0)
                        {
                            chkDisc3.Checked = true;
                            txtDisc3.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal3, detail.CurrencyRate);
                            txtDisc3.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal3, detail.CurrencyRate));
                            txtPercentageDisc3.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage3);
                        }
                        #endregion

                        if (detail.IsVatInvoice)
                            cmbTaxType.SelectedIndex = 1;
                        else if (detail.IsSVatInvoice)
                            cmbTaxType.SelectedIndex = 2;
                        else
                            cmbTaxType.SelectedIndex = 0;

                        TaxTypeSelection();

                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);


                        if (detail.IsApproved)
                            bHasApproved = true;

                        if (detail.IsChecked)
                            bHasChecked = true;

                        userDetailsColorChanges();

                        RefreshGrid(detail.Invoice_ID);

                        dgr_delivaryOrder.Rows.Clear();
                        foreach (var oDetailDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(detail.Invoice_ID).GroupBy(r => r.DeliveryOrder_ID).Select(grp => grp.Key))
                        {
                            tbl_sasDeliveryOrder oDo = tbl_sasDeliveryOrder.Select(oDetailDetail);
                            if (oDo != null)
                            {
                                RefreshDOGrid(oDo.DeliveryOrder_ID, oDo.DeliveryOrderDate);
                                txtDeliveryOrder.Tag = oDo.DeliveryOrder_ID;
                                txtDeliveryOrder.Text = clsCommon.GetForeignKeyValue(oDo.DeliveryOrder_ID);
                            }
                        }

                        if (!clsConfig.benable_multipleDO_Invoice)
                        {
                            txtDeliveryOrder.Enabled = false;
                            btnAddDeliveryOrder.Enabled = false;
                        }

                        //clsHelpMethods_Local.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                        //      txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);

                        ucSasProcessFlow.SetProcessFlowByInvoice(detail.Invoice_ID);

                        //Asign tax values after all calculation
                        txtSubTotal.Tag = clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate);
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtDisc1.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal1, detail.CurrencyRate);
                        txtDisc1.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal1, detail.CurrencyRate));
                        txtDisc2.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal2, detail.CurrencyRate);
                        txtDisc2.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal2, detail.CurrencyRate));
                        txtDisc3.Tag = clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal3, detail.CurrencyRate);
                        txtDisc3.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal3, detail.CurrencyRate));
                        txtNBT.Tag = clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate);
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtVat.Tag = clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate);
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtOtherTax.Tag = clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate);
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                        txtAdvanceReceived.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DAmount_AdvancePayment);

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
                    txtCustomerID.Text = clsGenaralName.getName_Customer(customer.Customer_ID);
                    txtAddress.Text = customer.AddressRegister;
                    txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);
                    tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(customer.Customer_ID);
                    if (finance != null)
                        dtpDueDate.Value = clsSecurity.getServerDateTime().AddDays(double.Parse(finance.CreditPeriod.ToString()));

                    if (customer.Currency_ID != null && customer.Currency_ID != "default")
                        FillDetailsCurrency(customer.Currency_ID);


                    //   chkOtherTax.Checked = customer.IsSVATenable ? true : false;
                    //  chkVat.Checked = customer.IsVATenable ? true : false;
                    //   chkNBT.Checked = customer.IsNBTenable ? true : false;
                    SetCustomerWiceDiscount(sCustomerID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        public void SetCustomerWiceDiscount(string Customer_ID)
        {
            try
            {
                chkDisc1.Enabled = clsConfig.bIsEnabledMultiple_Discount;
                chkDisc2.Enabled = clsConfig.bIsEnabledMultiple_Discount;
                chkDisc3.Enabled = clsConfig.bIsEnabledMultiple_Discount;

                chkDisc1.Checked = false;
                chkDisc2.Checked = false;
                chkDisc3.Checked = false;

                txtDisc1.Enabled = false;
                txtDisc2.Enabled = false;
                txtDisc3.Enabled = false;

                txtPercentageDisc1.Enabled = false;
                txtPercentageDisc2.Enabled = false;
                txtPercentageDisc3.Enabled = false;

                if (clsConfig.bIsEnabledMultiple_Discount)
                {
                    foreach (tbl_genCustomerDiscount oDiscount in tbl_genCustomerDiscount.SelectAllByCustomer_ID(Customer_ID))
                    {
                        switch (oDiscount.Discount_Id)
                        {
                            case "D001":
                                txtPercentageDisc1.Text = oDiscount.DiscountPresentage.ToString();
                                txtPercentageDisc1.Tag = oDiscount.DiscountPresentage;
                                txtPercentageDisc1.Enabled = !oDiscount.IsRateLocked;
                                chkDisc1.Checked = oDiscount.IsActive;
                                break;
                            case "D002":
                                txtPercentageDisc2.Enabled = !oDiscount.IsRateLocked;
                                txtPercentageDisc2.Tag = oDiscount.DiscountPresentage;
                                txtPercentageDisc2.Text = oDiscount.DiscountPresentage.ToString();
                                chkDisc2.Checked = oDiscount.IsActive;
                                break;
                            case "D003":
                                txtPercentageDisc3.Enabled = !oDiscount.IsRateLocked;
                                txtPercentageDisc3.Text = oDiscount.DiscountPresentage.ToString();
                                txtPercentageDisc3.Tag = oDiscount.DiscountPresentage;
                                chkDisc3.Checked = oDiscount.IsActive;
                                break;
                            default:
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

        #region Fill Delivery Order Details
        private void FillDetails_DeliveryOrder(string DelevaryOrder_ID)
        {
            try
            {
                if (DelevaryOrder_ID.Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DelevaryOrder_ID);
                    if (detail != null)
                    {
                        #region Row count = 1
                        if (dgr_delivaryOrder.RowCount == 0)
                        {
                            chkUnitPricing.Checked = !detail.IsWeightCalculation;

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

                            glbOrderRefNo = detail.OrderRefNo_ID;

                            txtSalesExecutiveID.Tag = detail.Employee_ID;
                            txtSalesExecutiveID.Text = clsGenaralName.getName_Employee(detail.Employee_ID);

                            txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                            txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                            //add currency detail
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

                            FillDetailsCurrency(detail.Currency_ID);
                            RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);
                            RefreshDOGrid(detail.DeliveryOrder_ID, detail.DeliveryOrderDate);
                        }
                        #endregion

                        #region DO  grid row count > i
                        else if (dgr_delivaryOrder.RowCount > 0)
                        {
                            string sOldDONo = "";
                            bool bOkToAddDo = true;

                            #region Check for duplicates
                            foreach (DataGridViewRow row in dgr_delivaryOrder.Rows)
                            {
                                sOldDONo = clsValidate.ValidateGridValue(dgr_delivaryOrder, "DONo", row.Index, "");

                                if (sOldDONo == DelevaryOrder_ID)
                                {
                                    bOkToAddDo = false;
                                    MessageBox.Show("Can not add this DO as it is already added ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                            #endregion

                            if (bOkToAddDo)
                            {
                                tbl_sasDeliveryOrder oDO_Old = tbl_sasDeliveryOrder.Select(sOldDONo);
                                if (oDO_Old != null)
                                {
                                    if (detail.SalesNoteType_ID == oDO_Old.SalesNoteType_ID && detail.CurrencyRate == oDO_Old.CurrencyRate && detail.Currency_ID == oDO_Old.Currency_ID)
                                    {
                                        chkUnitPricing.Checked = !detail.IsWeightCalculation;

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

                                        glbOrderRefNo = detail.OrderRefNo_ID;

                                        txtSalesExecutiveID.Tag = detail.Employee_ID;
                                        txtSalesExecutiveID.Text = clsGenaralName.getName_Employee(detail.Employee_ID);

                                        //txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                                        //txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                                        //fill customer, branch and routes
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

                                        //FillDetailsCurrency(detail.Currency_ID);

                                        RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);
                                        RefreshDOGrid(detail.DeliveryOrder_ID, detail.DeliveryOrderDate);
                                    }
                                    else
                                        MessageBox.Show("Can not add this DO ... \nNote type or Currency not match ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        #endregion
                    }

                    if (!clsConfig.benable_multipleDO_Invoice)
                    {
                        txtDeliveryOrder.Enabled = false;
                        btnAddDeliveryOrder.Enabled = false;
                    }

                    txtCustomerID.Enabled = false;
                    lblCustomerID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By DeliveryOrderID
        //private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        //{
        //    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DeliveryOrderID);

        //    if (detail != null)
        //    {
        //        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
        //        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
        //        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
        //        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
        //        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
        //        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
        //        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
        //        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
        //        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
        //        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));

        //        if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
        //        {
        //            foreach (ComboBoxItem d in cmbItemPrice.Items)
        //            {
        //                if (d.Value == detail.ItemPriceCategory)
        //                {
        //                    cmbItemPrice.SelectedItem = d;
        //                    break;
        //                }
        //            }
        //        }

        //        if (detail.DiscountTotal > 0)
        //            chkDiscount.Checked = true;
        //        else
        //            chkDiscount.Checked = false;
        //        if (detail.NbtTotal > 0)
        //            chkNBT.Checked = true;
        //        else
        //            chkNBT.Checked = false;
        //        if (detail.VatTotal > 0)
        //            chkVat.Checked = true;
        //        else
        //            chkVat.Checked = false;
        //        if (detail.OtherTaxTotal > 0)
        //            chkOtherTax.Checked = true;
        //        else
        //            chkOtherTax.Checked = false;

        //        #region MyRegion

        //        #endregion
        //    }
        //}
        #endregion

        #region Fill Tax Detail By CustomerOrderID
        private void FillTaxDetailByCustomerOrderID(string sCustomerOrderID)
        {
            try
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCustomerOrderID);
                if (detail != null)
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));


                    //if (detail.DiscountTotal > 0)
                    //    chkDiscount.Checked = true;
                    //else
                    //    chkDiscount.Checked = false;
                    //if (detail.NbtTotal > 0)
                    //    chkNBT.Checked = true;
                    //else
                    //    chkNBT.Checked = false;
                    //if (detail.VatTotal > 0)
                    //    chkVat.Checked = true;
                    //else
                    //    chkVat.Checked = false;
                    //if (detail.OtherTaxTotal > 0)
                    //    chkOtherTax.Checked = true;
                    //else
                    //    chkOtherTax.Checked = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By Quotation ID
        private void FillTaxDetailByQuotationID(string sQuotationID)
        {
            try
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(sQuotationID);
                if (detail != null)
                {
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                    chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                    //  chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                    //  chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                    //  chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;
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
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            bool bStatus = false;

            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                  //  if (CheckValidity_RouteWiseDiscount())
                    {
                        if (CheckValidity_ItemDiscount())
                        {
                            if (CheckItemSettleValidity())
                            {
                                if (clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                                {
                                    if (CheckOutstandingValidity_Creaditlimit())
                                    {
                                        if (CheckOutstandingValidity_Aging())
                                        {
                                            if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                                            {
                                                if (HasEnoughFIFOQTY())
                                                {
                                                    if (FIFOCostPriceValidate())
                                                    {
                                                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                                                        {
                                                            if (CheckValidity_Posting())
                                                            {
                                                                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                                                {
                                                                    if (CheckGrandTotal_Minus())
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

            return bStatus;
        }
        private bool CheckValidity_RouteWiseDiscount()
        {
            bool bValue = true;

            int route = int.Parse(lblRoute.Tag.ToString());

            decimal dDiscountUI = decimal.Parse(txtDiscount.Text);
            decimal dSubTot = decimal.Parse(txtSubTotal.Text);
            decimal DisPresent = dDiscountUI * 100 / dSubTot;

            var Discount = new RouteWiseItemDiscData().GetDiscount(route);

            if (DisPresent > Discount)
            {
                MessageBox.Show("Maximum Discount for the route exceeded", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                bValue = false;
            }

            return bValue;
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
                int route = int.Parse(lblRoute.Tag.ToString());

                var Data = new masCustomerWiseItemPricingData();
                var result = Data.CheckValidity(txtCustomerID.Tag.ToString(), route, sItemCode, dDiscountPresentage);
                if (!result.IsSuccess)
                {
                    bValue = false;
                    MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                }


                if (false)
                {
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
            }

            return bValue;
        }

        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            try
            {
                if (clsConfig.bAutoPostingEnable)
                {
                    #region Check  Account validity
                    bool bSlotStatus_NBT = false, bSlotStatus_VAT = false, bSlotStatus_SubTotal = false;
                    bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                    #endregion

                    if (clsConfig.sInvoice_SalesAccount_Type == "1")
                    {
                        tbl_zSalesNoteType oSalesNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                        if (oSalesNoteType != null)
                        {
                            if (oSalesNoteType.Gl_ID != null && clsMethods_GL.CheckAccountValidity(oSalesNoteType.Gl_ID))
                                bSlotStatus_SubTotal = true;
                            else
                                MessageBox.Show("Please Link account to Sales note Type", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        tbl_genCustomerMaster oCust = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                        if (oCust != null)
                        {
                            if (oCust.Sales_Gl_ID != "default" && clsMethods_GL.CheckAccountValidity(oCust.Sales_Gl_ID))
                                bSlotStatus_SubTotal = true;
                            else
                                MessageBox.Show("Please Link account to Sales", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    //  tbl_zSalesNoteType oSalesNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                    // if (oSalesNoteType != null)
                    // {
                    bSlotStatus_NBT = clsMethods_GL.CheckAccountLink_NBTReceivable();
                    bSlotStatus_VAT = clsMethods_GL.CheckAccountLink_VATReceivable();

                    //if (oSalesNoteType.Gl_ID != null && clsMethods_GL.CheckAccountValidity(oSalesNoteType.Gl_ID))
                    //    bSlotStatus_SubTotal = true;
                    //else
                    //    MessageBox.Show("Please Link account to Sub Total", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //  }

                    if (bSlotStatus_Customer && bSlotStatus_NBT && bSlotStatus_VAT && bSlotStatus_SubTotal)
                        bStatus = true;
                }
                else
                    bStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerBranchID, "Customer Branch ID"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                        bStatus = true;
                }
            }

            return bStatus;
        }

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sItemCode = "", sDoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
            decimal dQuantity = 0, dWeight = 0;
            bool bItemExceedLock_Active = !clsAutocode.getItemExceed(ConfigItemExceedLock.Invoice);
            bool bItemLessLock_Active = clsConfig.bAllowInvoiceLessThanDO_Qty;

            if (bItemExceedLock_Active || bItemLessLock_Active)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        sDoCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (DoDetail != null)
                        {
                            if (chkUnitPricing.Checked)
                            {
                                if (IsUpdate)
                                {
                                    if (bItemExceedLock_Active)
                                    {
                                        if (DoDetail.Qty < dQuantity)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity \n";
                                            rtn = false;
                                        }
                                    }
                                    if (bItemLessLock_Active)
                                    {
                                        if (DoDetail.Qty > dQuantity)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Less Than the Delivery Order Quantity \n";
                                            rtn = false;
                                        }
                                    }
                                }
                                else
                                {
                                    if (bItemExceedLock_Active)
                                    {
                                        if (DoDetail.Qty < (DoDetail.QtySettle + dQuantity))
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity  \n";
                                            rtn = false;
                                        }
                                    }
                                    if (bItemLessLock_Active)
                                    {
                                        if (DoDetail.Qty > (DoDetail.QtySettle + dQuantity))
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Less the Delivery Order Quantity  \n";
                                            rtn = false;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (IsUpdate)
                                {
                                    if (DoDetail.Weight < dWeight)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (DoDetail.Weight < (DoDetail.WeightSettle + dWeight))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Weight cannot Exceed the Delivery Order Weight\n";
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
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckOutstandingValidity_Aging()
        {
            bool bOk = false;
            try
            {
                if (clsConfig.bOutstandingBalance_InvoiceLock_Aging)
                {
                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    {
                        decimal dAmountOver30 = 0, dAmountOver60 = 0;

                        var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(txtCustomerID.Tag.ToString(), "", Convert.ToDateTime("01/01/2000"), DateTime.Now.Date, true);
                        foreach (srh_bssCustomerOutstanding oDetail in oDetails.Where(p => p.TransactionType != 5))
                        {
                            int days = clsCommon.getDaysUptoDate(oDetail.TransactionDate);

                            if (days > 30 && days <= 60)
                                dAmountOver30 += oDetail.Outstanding;
                            else if (days > 60)
                                dAmountOver60 += oDetail.Outstanding;
                        }

                        if (dAmountOver60 > 0)
                        {
                            DialogResult msgResult = MessageBox.Show("Customer's outstanding credit amount (" + clsFormatter.FormatToCurrecyWithThousendSep(dAmountOver60) + ") exceeds more than 60 days....\nDo You Still Want To Proceed ???", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                            if (msgResult == DialogResult.Yes)
                            {
                                bOk = true;
                                bIsOverriddenInvoice_60Days_CrExeed = true;
                            }
                        }
                        else if (dAmountOver30 > 0)
                        {
                            DialogResult msgResult = MessageBox.Show("Customer's outstanding credit amount (" + clsFormatter.FormatToCurrecyWithThousendSep(dAmountOver30) + ") exceeds more than 30 days....\nDo You Still Want To Proceed ???", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                            if (msgResult == DialogResult.Yes)
                            {
                                bOk = true;
                                bHasApproved = true;
                                bHasChecked = true;
                                bIsOverriddenInvoice_30Days_CrExeed = true;
                            }
                        }
                        else
                        {
                            bOk = true;
                            bHasApproved = true;
                            bHasChecked = true;
                        }
                    }
                }
                else
                    bOk = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bOk;
        }

        private bool CheckOutstandingValidity_Creaditlimit()
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
                            if (clsConfig.bCreditBalanceInvoice_Message) //security 1 - Message
                            {
                                dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                                if (txtGrandTotal.TextLength > 0)
                                    dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
                                if (dCreditBalance < dAmountDue) //Condition
                                {
                                    bOk = false;
                                    if (clsConfig.bCreditBalanceInvoice_Lock) //security 2 - Lock
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

        private bool CheckValidityPosting()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                if (txtCustomerID.TextLength == 0)
                {
                    strMessage += "\n" + " Cancel not allowed for GL Posted transactions. Please contact your Accountant..! ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool ValidateForDependancies(string sInvoiceID)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_sasSalesReturnedNote_Detail oSR in tbl_sasSalesReturnedNote_Detail.SelectAllByInvoice_ID(sInvoiceID))
                {
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(oSR.SalesReturnedNote_ID);
                    if (detail != null && detail.SalesReturnedNote_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.SalesReturnedNote_ID + "] SRN is already created for this Invoice", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
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
            try
            {
                clsCommon.ValidateForeignKey(ref txtCustomerOrderID);
                clsCommon.ValidateForeignKey(ref txtQuotationID);
                clsCommon.ValidateForeignKey(ref txtDeliveryOrder);

                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtCustomerBranchID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fifo Qty Validate
        public bool HasEnoughFIFOQTY()
        {
            bool bHasEnoughQty = false;

            try
            {
                string sItemCode = "", sSubCategory1 = "", sSubCategory2 = "", sSerial1 = "", sSerial2 = "", sDeliveryOrderCode = "", sSubCategory1Name = "", sSubCategory2Name = "";
                decimal dRadiusedQTY = 0, dRadiusedWeight = 0, dSettleQty = 0, dSettleWeight = 0, dWeight = 0;
                if (clsConfig.bValidate_InvoiceFIFO_QTY)
                {
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        dRadiusedQTY = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sSubCategory1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sSubCategory2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sSerial1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                        sSubCategory1Name = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sSubCategory2Name = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID2", row.Index, "default");

                        #region Update
                        if (IsUpdate)
                        {
                            decimal dQty = 0;
                            // tbl_sasInvoice_Detail oldRecord = tbl_sasInvoice_Detail.Select(txtInvoiceID.Text.Trim(), sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, sDeliveryOrderCode);
                            foreach (tbl_sasInvoice_Detail oldRecord in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sSubCategory1 && r.ItemSubCategory2_ID == sSubCategory2 && r.ItemSerialNo == sSerial1 && r.ItemSerialNo2 == sSerial2 && r.DeliveryOrder_ID == sDeliveryOrderCode))
                                dQty += oldRecord.Qty;


                            if (dRadiusedQTY > dQty)
                                dRadiusedQTY = dRadiusedQTY - dQty;
                            else
                                bHasEnoughQty = true;

                        }
                        #endregion

                        //#region Has Enough GRN QTY
                        //List<tbl_scsExternalGoodReceivedNote_Detail_FIFO> details = tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
                        //foreach (tbl_scsExternalGoodReceivedNote_Detail_FIFO detail in details)
                        //{
                        //    if (!detail.IsSeattled)
                        //    {
                        //        if ((detail.Qty - detail.SettleQty) >= dRadiusedQTY)// has enaught SettleQty Qty
                        //        {
                        //            bHasEnoughQty = true;
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            dSettleQty = detail.Qty - detail.SettleQty;
                        //            dSettleWeight = detail.Weight - detail.SettleWeight;

                        //            dRadiusedQTY = dRadiusedQTY - dSettleQty;
                        //            dRadiusedWeight = dRadiusedWeight - dSettleWeight;
                        //        }
                        //    }
                        //}
                        //#endregion
                    }
                }
                else
                {
                    bHasEnoughQty = true;
                }

                if (bHasEnoughQty == false)
                {
                    MessageBox.Show(" Unable to save this Invoice. Insufficent quantity in  \n Item Name:  " + sItemCode + " . Brand Name:   " + sSubCategory1Name, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bHasEnoughQty;
        }
        #endregion

        #region FIFO Cost Price Validate
        public bool FIFOCostPriceValidate()
        {
            bool bValidateFIFOCostPrice = false;

            try
            {
                string sItemCode = "", sSubCategory1 = "", sSubCategory2 = "", sSerial1 = "", sSerial2 = "", sDeliveryOrderCode = "";
                decimal dRadiusedQTY = 0, dSettleQty = 0,// dSettleWeight = 0,dRadiusedWeight = 0, 
                    dWeight = 0, dinvoiceCost = 0;
                decimal dSubtotal = 0, dDiscount = 0, dNBT = 0;

                if (clsConfig.bValidate_InvoiceFIFOCostPrice)
                {
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        dRadiusedQTY = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sSubCategory1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sSubCategory2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sSerial1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");

                        #region Update
                        if (IsUpdate)
                        {
                            decimal dQty = 0;
                            //tbl_sasInvoice_Detail oldRecord = tbl_sasInvoice_Detail.Select(txtInvoiceID.Text.Trim(), sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, sDeliveryOrderCode);
                            foreach (tbl_sasInvoice_Detail oldRecord in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sSubCategory1 && r.ItemSubCategory2_ID == sSubCategory2 && r.ItemSerialNo == sSerial1 && r.ItemSerialNo2 == sSerial2 && r.DeliveryOrder_ID == sDeliveryOrderCode))
                                dQty += oldRecord.Qty;

                            if (dRadiusedQTY > dQty)
                            {
                                //List<tbl_sasInvoice_Detail_FIFO> INVdetails = tbl_sasInvoice_Detail_FIFO.SelectAllByInvoice_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2_DeliveryOrder_ID(txtInvoiceID.Text.Trim(), sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, sDeliveryOrderCode);
                                //foreach (tbl_sasInvoice_Detail_FIFO INVdetail in INVdetails)
                                //{
                                //    dinvoiceCost += INVdetail.TatalCost_FIFO;
                                //}
                                dRadiusedQTY = dRadiusedQTY - dQty;
                            }
                            else
                            {
                                //List<tbl_sasInvoice_Detail_FIFO> INVdetails = tbl_sasInvoice_Detail_FIFO.SelectAllByInvoice_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2_DeliveryOrder_ID(txtInvoiceID.Text.Trim(), sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2, sDeliveryOrderCode);
                                //foreach (tbl_sasInvoice_Detail_FIFO INVdetail in INVdetails)
                                //{
                                //    dinvoiceCost += (INVdetail.QtyPrice * dRadiusedQTY);
                                //    dRadiusedQTY = 0;
                                //}
                            }

                        }
                        #endregion

                        #region Calculate newly Add Cost
                        //List<tbl_scsExternalGoodReceivedNote_Detail_FIFO> details = tbl_scsExternalGoodReceivedNote_Detail_FIFO.SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(sItemCode, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
                        //foreach (tbl_scsExternalGoodReceivedNote_Detail_FIFO detail in details)
                        //{
                        //    if (!detail.IsSeattled)
                        //    {
                        //        if ((detail.Qty - detail.SettleQty) >= dRadiusedQTY)// has enaught SettleQty Qty
                        //        {
                        //            dinvoiceCost = dinvoiceCost + (dRadiusedQTY * detail.QtyPrice);
                        //            break;
                        //        }
                        //        else
                        //        {
                        //            dinvoiceCost = dinvoiceCost + ((detail.Qty - detail.SettleQty) * detail.QtyPrice);
                        //            dSettleQty = detail.Qty - detail.SettleQty;
                        //            dRadiusedQTY = dRadiusedQTY - dSettleQty;

                        //            //dSettleWeight = detail.Weight - detail.SettleWeight;
                        //            //dRadiusedWeight = dRadiusedWeight - dSettleWeight;
                        //        }
                        //    }
                        //}
                        #endregion
                    }

                    #region FIFO Cost Price Validate
                    if (txtSubTotal.Text.Length >= 0 && txtDiscount.TextLength >= 0)
                    {
                        dDiscount = decimal.Parse(txtDiscount.Text);
                        dSubtotal = decimal.Parse(txtSubTotal.Text);
                        dNBT = decimal.Parse(txtNBT.Text);// (dSubtotal / 102) * 100;

                        if (dinvoiceCost < ((dSubtotal - dDiscount) - dNBT))
                        {
                            bValidateFIFOCostPrice = true;
                        }
                    }
                    #endregion

                }
                else
                    bValidateFIFOCostPrice = true;

                if (bValidateFIFOCostPrice == false)
                    MessageBox.Show(" Unable to save this Invoice.. \n Total cost of items exceed invoice amount ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValidateFIFOCostPrice;
        }
        #endregion

        #region Events KeyDown
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_InvoiceID();
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DeliveryOrderID(sender);
        }
        private void txtCustomerOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CusotmerOrderID();
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_QuotationID();
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            else if (e.Control && e.KeyCode == Keys.D)
                pnlDiscounts_Click(null, null);
        }

        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search_SalesExecutiveID();
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
        private void txtPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
        }

        private void txtCustomerBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerBranch();
        }
        #endregion

        #region Events Double Click
        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_InvoiceID();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null)
                Search_CustomerID();
            else
                MessageBox.Show("Please select Customer Order / Delivery Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void txtDeliveryOrder_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrderID(sender);
        }
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_CusotmerOrderID();
        }
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            Search_QuotationID();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtPaymentMode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
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

        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtCreditPeriod_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal iCreditPeriod = 0;
                DateTime dtInvoiceDate = dtpInvoiceDate.Value;
                iCreditPeriod = decimal.Parse(txtCreditPeriod.Text);
                DateTime dtDuteDate = dtInvoiceDate.AddDays(int.Parse(iCreditPeriod.ToString()));
                dtpDueDate.Value = dtDuteDate.Date;
            }
            catch (Exception)
            { }
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0.00";
                txtDiscount.Tag = "0";
            }
            CalculateTaxesAndGrandTotal();
        }
        private void chkDisc1_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDisc1.Checked)
            {
                txtDisc1.Text = "0.00";
                txtDisc1.Tag = "0";
            }
            CalculateTaxesAndGrandTotal();
        }

        private void chkDisc2_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDisc2.Checked)
            {
                txtDisc2.Text = "0.00";
                txtDisc2.Tag = "0";
            }
            CalculateTaxesAndGrandTotal();
        }

        private void chkDisc3_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkDisc3.Checked)
            {
                txtDisc3.Text = "0.00";
                txtDisc3.Tag = "0";
            }
            CalculateTaxesAndGrandTotal();
        }

        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
                chkVat.Checked = true;

            CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
                chkOtherTax.Checked = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
                chkVat.Checked = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
            }
        }


        private void chkSettings2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSettings2.Checked)
            {
                pnlSetting1.Visible = true;
                pnlSetting1.BringToFront();
                chkSettings2.Image = Digiteq.Properties.Resources.security;
            }
            else
            {
                pnlSetting1.Visible = false;
                pnlSetting1.BringToFront();
                chkSettings2.Image = Digiteq.Properties.Resources.settings;
            }
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    clsEvent.SalesGrid_CellDoubleClick(sender, e, dgvDetail);
                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();

                    string sColName = "";
                    if (e.ColumnIndex >= 0)
                        sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                    if (sColName == "ItemCode" && sColName != "ItemName")
                    {
                        clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                            dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                            dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                    }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clsEvent.SalesGrid_CellEndEdit_Invoice(sender, e, dgvDetail, !chkUnitPricing.Checked);
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);
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
                    Cursor = Cursors.Hand;
            }
        }

        #endregion

        #region Events MouseLeave
        private void Text_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        #endregion

        #region Events Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (txtDiscount.TextLength > 0 && clsCommon.isCurrency(txtDiscount.Text.Trim()) && decimal.Parse(txtDiscount.Text.Trim()) > 0)
            {
                txtDiscount.Tag = txtDiscount.Text.Trim();
                txtPercentageDiscount.Text = "0";
            }
            else
                txtDiscount.Tag = "0";

            CalculateTaxesAndGrandTotal();
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

        #region Search Methods
        private void Search_InvoiceID()
        {
            try
            {
                clsSearch.Search_TransactionInvoice_Direct(ref txtInvoiceID, chkShowSettle.Checked, (FormName)iFormID == FormName.Invoice_TAXReverced, true);
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtInvoiceID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_QuotationID()
        {
            try
            {
                clsSearch.Search_TransactionQuotation_Direct(ref txtQuotationID, true);
                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim() != "default")
                    btnAddQuotation_Click(null, null);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CusotmerOrderID()
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionCustomerOrder_Use(ref txtCustomerOrderID, txtCustomerID.Tag.ToString(), false);
                else
                    clsSearch.Search_TransactionCustomerOrder_Use(ref txtCustomerOrderID, "", false);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_DeliveryOrderID(object objSender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrder, txtCustomerID.Tag.ToString(), false);
                else
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDeliveryOrder, "", false);

                if (txtDeliveryOrder.Tag != null && txtDeliveryOrder.Tag.ToString().Length > 0)
                {
                    btnAddDeliveryOrder_Click(objSender, new EventArgs());

                    if (!clsConfig.benable_multipleDO_Invoice)
                    {
                        txtDeliveryOrder.Enabled = false;
                        btnAddDeliveryOrder.Enabled = false;
                    }

                    txtCustomerID.Enabled = false;
                    lblCustomerID.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                bool bIsEnableCustomerChange = true;
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

                if (bIsEnableCustomerChange == true)
                {
                    Form frmhelpsearch = new frmSearchMaster();
                    clsSearch.passValue_CustomerMaster();
                    frmhelpsearch.ShowDialog();

                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        tbl_genCustomerMaster oCustomer2 = tbl_genCustomerMaster.Select(frmSearchMaster.s_SearchID);
                        if (oCustomer2 != null && oCustomer2.Customer_ID != "default")
                        {
                            if (oCustomer2.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price && dgvDetail.Rows.Count > 0)
                            {
                                bIsEnableCustomerChange = false;
                                MessageBox.Show("Customer Wise pricing enabled. Please remove items to change customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (frmSearchMaster.s_SearchText.Length > 0)
                                    txtCustomerID.Text = frmSearchMaster.s_SearchText;
                                if (frmSearchMaster.s_SearchID.Length > 0)
                                {
                                    txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                                    FillDetailsCustomer(frmSearchMaster.s_SearchID);

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
        private void Search_CustomerBranch()
        {
            try
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtInvoiceID.Text != null && txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
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
                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_sasInvoice objDO = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtInvoiceID.Text != null && txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
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

                                    if (IsUpdate)
                                    {
                                        userDetailsColorChanges();

                                        tbl_sasInvoice objDO = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
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
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtCurrencyID);
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
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
        }
        #endregion

        #region Calcualte Values
        private void CalcualteSubTotal()
        {
            try
            {
                decimal Amount = 0;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    if (dgvDetail["Amount", row.Index].Tag != null && dgvDetail["Amount", row.Index].Tag.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", row.Index].Tag.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", row.Index].Tag.ToString());
                    }
                }
                Amount = clsFormatter.RoundDecimalPlaces(Amount);
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                txtSubTotal.Tag = Amount;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            try
            {
                decimal dDiscountTotal = 0, dDiscountPresent = 0;
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsFormatter.RoundDecimalPlaces(clsHelpMethods.CalculateGrandTotal_WithMultiplediscount(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                     txtDisc1, txtPercentageDisc1, chkDisc1, txtDisc2, txtPercentageDisc2, chkDisc2, txtDisc3, txtPercentageDisc3, chkDisc3,
                    txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax, ref dDiscountTotal, ref dDiscountPresent)));
                txtAmountInWord.Text = clsCommon.CurrencyToWord(decimal.Parse(txtGrandTotal.Text.Trim()));

                lblDiscountTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountTotal);
                lblDiscountPresentTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresent);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int lineNo, string ItemID, string DeliveryOrderID, string CusOrderID, string QuotationID, string JobID, string Uom_ID, decimal UnitPrice, decimal KiloPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled, decimal dExRate)
        {
            try
            {
                //if the item already in the datagrid, only update weight and qty of the item.
                bool isNewItem = true;

                if (!clsConfig.bAllow_user_to_Dupplicate_items_SAS_Transactions)
                {
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        if (ItemID == clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, ""))
                        {
                            string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "", sDeliveryOrderID = "";
                            int iLineNo = lineNo;

                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, lineNo);
                            sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                            sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                            sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                            sDeliveryOrderID = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                            sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                            sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                            if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2 && sDeliveryOrderID == DeliveryOrderID)
                            {
                                dgvDetail.Rows.RemoveAt(iRow);
                                lineNo = iLineNo;
                                Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                iRow = row.Index;
                            }
                        }
                    }
                }

                //Get Unit Price with Exchange rate to save
                UnitPrice = clsHelpMethods_Local.getDisplayPrice(UnitPrice, dExRate);
                KiloPrice = clsHelpMethods_Local.getDisplayPrice(KiloPrice, dExRate);
                GrossTotal = clsHelpMethods_Local.getDisplayPrice(GrossTotal, dExRate);
                //  SubTotalAmount = clsHelpMethods.getDisplayPrice(SubTotalAmount, dExRate);

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;

                string sPLU = clsHelpMethods.GetPLU(txtCustomerID.Tag.ToString(), ItemID);
                dgvDetail["ItemName", iRow].Value = sPLU == "" || sPLU == "-" ? clsGenaralName.getName_Item(ItemID) : clsGenaralName.getName_Item(ItemID) + " - [" + sPLU + "]";
                dgvDetail["DeliveryOrderCode", iRow].Value = DeliveryOrderID;//add by thilina
                dgvDetail["CusOrderCode", iRow].Value = CusOrderID;//add by thilina
                dgvDetail["QuotationCode", iRow].Value = QuotationID;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(Uom_ID);
                dgvDetail["UOM", iRow].Tag = Uom_ID;
                dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
                dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["Remarks", iRow].Value = Remark;


                dgvDetail["Width", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Width);
                dgvDetail["Height", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Height);
                dgvDetail["Gauge", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gauge);
                dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);// add by thilina

                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);

                if (isNewItem)
                {
                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;

                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);
                    dgvDetail["WeightPrice", iRow].Tag = KiloPrice;
                }

                //Anoj Please check this -Asanka
                dgvDetail["Free", iRow].Value = isFreeItem;
                dgvDetail["DiscuntPresentage", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountPresentage);
                dgvDetail["DiscuntPresentage", iRow].Tag = DiscountPresentage;
                dgvDetail["DiscountValue", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountAmount);
                dgvDetail["DiscountValue", iRow].Tag = DiscountAmount;
                //   SubTotalAmount -= DiscountAmount;
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(GrossTotal);
                dgvDetail["Amount", iRow].Tag = GrossTotal;

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion

                if (bHasSettled)
                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Changed
        private void pnlDiscounts_Click(object sender, EventArgs e)
        {
            if (pnlDiscBrackdown.Visible == true)
                pnlDiscBrackdown.Visible = false;
            else
                pnlDiscBrackdown.Visible = true;
        }

        private void handleDigiteValues(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;
        }
        #endregion

        #region User Checked Approve Details
        private void frm_sasInvoice2_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasInvoice2_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void frm_sasInvoice2_SF_History_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.Text != "" || txtInvoiceID.Text != "<Auto Generate>")
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Text);
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

        #region User Details Color Changes
        //private void userDetailsColorChanges()
        //{
        //    if (bHasApproved)
        //    {
        //        this.btnApproved.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        this.btnChecked.BackColor = System.Drawing.Color.DarkGray;
        //        btnApproved.Enabled = false;
        //        btnChecked.Enabled = false;

        //    }
        //    if (bHasChecked)
        //    {
        //        this.btnChecked.BackColor = System.Drawing.Color.FromArgb(3, 87, 11);
        //        btnChecked.Enabled = false;
        //    }
        //    if (!bHasApproved && !bHasChecked)
        //    {
        //        this.btnApproved.ForeColor = System.Drawing.Color.Red;
        //        this.btnChecked.ForeColor = System.Drawing.Color.Red;
        //        this.btnApproved.BackColor = System.Drawing.Color.White;
        //        this.btnChecked.BackColor = System.Drawing.Color.White;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}
        #endregion

        #endregion

        #region Setting Panel Events
        public override void SettingsClick()
        {
            xSetting.Visible = true;
            xSetting.Focus();
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

        #region Tax Type Selected Index Changed
        private void cmbTaxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TaxTypeSelection();
            CalculateTaxesAndGrandTotal();
        }
        private void TaxTypeSelection()
        {
            //if some one change the tax type then change then save method also. (2018-07-05)

            chkNBT.Checked = false;
            chkVat.Checked = false;
            chkOtherTax.Checked = false;

            pnlNbt.Visible = true;
            pnlVat.Visible = true;
            pnlSvat.Visible = true;

            switch (cmbTaxType.SelectedIndex)
            {
                case 0://non tax
                    break;
                case 1://tax
                    chkNBT.Checked = true;
                    chkVat.Checked = true;
                    break;
                case 2://other tax
                    chkNBT.Checked = true;
                    chkOtherTax.Checked = true;
                    break;
            }
            if (chkNBT.Checked == false)
                pnlNbt.Visible = false;
            if (chkVat.Checked == false)
                pnlVat.Visible = false;
            if (chkOtherTax.Checked == false)
                pnlSvat.Visible = false;
        }
        #endregion

    }
}