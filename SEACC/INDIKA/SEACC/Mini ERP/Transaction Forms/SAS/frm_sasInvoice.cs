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
    public partial class frm_sasInvoice : SEACC_Form
    {
        

        //form manage
        string sFormConfigCodeVAT;
        string sFormConfigCodeNonTax;
        string sFormConfigCodeSVAT;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbDeliveryOrderID = "", glbCustomerOrderID = "", glbInvoiceID = "";

        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;
        bool bIsOverriddenInvoice_30Days_CrExeed = false;
        bool bIsOverriddenInvoice_60Days_CrExeed = false;

        dts_sasInvoice glb_dtsSasInvoice = new dts_sasInvoice();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        public DataTable dt_ItemGrouped = new DataTable();
        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_sasInvoice(FormName _enmForm)
        {
            sFormConfigCodeVAT = clsAutocode.getFormConfigCode(FormName.VATInvoice);
            sFormConfigCodeNonTax = clsAutocode.getFormConfigCode(FormName.NonTaxInvoice);
            sFormConfigCodeSVAT = clsAutocode.getFormConfigCode(FormName.SVATInvoice);

            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
            bHasPermissionToLineDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_LineDiscount));
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true,false, false, false, false, false, true, false);

            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            clsFill.Fill_ItemPrices(ref cmbItemPrice);

            if (glbDeliveryOrderID.Length > 0)
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(glbDeliveryOrderID);
                if (detail != null)
                {
                    txtDeliveryOrder.Tag = detail.DeliveryOrder_ID;
                    txtDeliveryOrder.Text = detail.DeliveryOrder_ID;
                    btnAddDeliveryOrder_Click(sender, new EventArgs());
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
        private void frm_sasInvoice_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void frm_sasInvoice_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    ValidateEmptyForeignKey();

                    bool bIsTaxReversedInvoice = (FormName)iFormID == FormName.Invoice_TAXReverced;
                    bool bIsVatInvoice = bIsTaxReversedInvoice ? clsHelpMethods.isTaxActiveNote(lblVAT) : clsHelpMethods.isTaxActiveNote(txtVat);
                    bool bIsSvatInvoice = bIsTaxReversedInvoice ? clsHelpMethods.isTaxActiveNote(lblSVAT) : clsHelpMethods.isTaxActiveNote(txtOtherTax);

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_sasInvoice oldRecord = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) && !oldRecord.IsTaxReverseCalulation)//&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID2) &&
                        {
                            if (ValidateForDependancies(oldRecord.Invoice_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted && oldRecord.SeattleAmount == 0)
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtInvoiceID.Text))
                                        {
                                            clsMethods_GL.GLPosting_Delete(oldRecord.GlPosting_ID);
                                            //Write Audit Trial Log
                                            clsLog.Process_Modify(iFormID,
                                                clsAutocode.GetProcessNoteID(ProcessNote.Invoice), oldRecord.Invoice_ID,
                                                "Invoice");

                                            //Invoice Detail                                   

                                            #region Update old Details

                                            List<tbl_sasInvoice_Detail> oldInvDetails =tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim());
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
                                                    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo",                                                        row.Index, "0");
                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",                                                        row.Index, "");
                                                    sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail,                                                        "DeliveryOrderCode", row.Index, "default");
                                                    sCusOrderCode = clsValidate.ValidateGridValue(dgvDetail,                                                        "CusOrderCode", row.Index, "default");
                                                    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,                                                        "QuotationCode", row.Index, "default");
                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",                                                        row.Index, "default");
                                                    sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index,                                                        "default");
                                                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice",                                                        row.Index, decimal.Parse("0.00"));
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",                                                        row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice",                                                        row.Index, decimal.Parse("0.00"));


                                                    bIsFreeIssue =                                                        clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index,
                                                            "") == "True"
                                                            ? true
                                                            : false;
                                                    dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail,                                                        "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                                    dDiscountValue = clsValidate.ValidateGridTag(dgvDetail,                                                        "DiscountValue", row.Index, decimal.Parse("0.00"));

                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount",                                                        row.Index, decimal.Parse("0.00"));
                                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail,                                                        "ItemSubCategoryID", row.Index, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail,                                                        "ItemSubCategoryID2", row.Index, "default");
                                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail,                                                        "ItemSerialNo", row.Index, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail,                                                        "ItemSerialNo2", row.Index, "0");
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks",                                                        row.Index, "");

                                                    if (oldInvDetail.Invoice_ID == txtInvoiceID.Text.Trim() &&
                                                        oldInvDetail.Item_ID == sItemCode &&
                                                        oldInvDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                                        oldInvDetail.ItemSubCategory2_ID == sItemSubCategoryID2 &&
                                                        oldInvDetail.ItemSerialNo == sItemSerialNo &&
                                                        oldInvDetail.ItemSerialNo2 == sItemSerialNo2)
                                                    {
                                                        bHasInvoInDB = true;

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
                                                        tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo),
                                                                sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
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
                                                }
                                                else
                                                    oldInvDetail.Delete();

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
                                            string     store_ID = clsValidate.ValidateGridTag(dgvDetail, "store_ID", row.Index, "default");
                                              
                                                if (sItemCode.Length > 0)
                                                {
                                                    var items = new tbl_sasInvoice_Detail_Ex(
                                                        int.Parse(sLineNo), txtInvoiceID.Text.Trim(), sItemCode,
                                                        sItemSubCategoryID, sItemSubCategoryID2,
                                                        sItemSerialNo, sItemSerialNo2, sDeliveryOrderCode,
                                                        txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode,
                                                        sJobCode, dQuantity, 0, dWeight, 0,
                                                        dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage,
                                                        dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                                        dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode), store_ID);
                                                    items.Insert2();

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
                                                }
                                            }

                                            #endregion

                                            #region Update Invoice Header

                                            bool bIsLocked = oldRecord.IsLocked;

                                            tbl_sasInvoice detail = new tbl_sasInvoice(txtInvoiceID.Text.Trim(),
                                                "default", dtpInvoiceDate.Value, txtRemark.Text.Trim(),
                                                txtAddress.Text.Trim(), txtAmountInWord.Text.Trim(),
                                                txtCustomerID.Tag.ToString(), txtQuotationID.Tag.ToString(),
                                                txtCustomerOrderID.Tag.ToString(),
                                                txtDeliveryOrder.Tag.ToString(), txtJobCode.Tag.ToString(),
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
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate),
                                                decimal.Parse(txtSubTotal_Rec.Text.Trim()),
                                                decimal.Parse(txtGrandTotal_Rec.Text.Trim()), oldRecord.CreateUser_ID,
                                                clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                                oldRecord.ApprovedUser_ID,
                                                oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                                glbApprovedDate, oldRecord.DateDeleted, oldRecord.DatePrinted,
                                                oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                                                oldRecord.IsDeleted, txtPaymentTerms.Text.Trim(),
                                                txtPaymentMode.Text.Trim(), txtCreditPeriod.Text.Trim(),
                                                dtpDueDate.Value,
                                                bIsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled,
                                                oldRecord.IsSeattled_DO, oldRecord.PrintCount, oldRecord.IsDebitNote,
                                                oldRecord.IsOpeningBalance, oldRecord.IsReturnedCheque,
                                                oldRecord.IsPartPayment, oldRecord.IsAdvancePayment,
                                                !chkUnitPricing.Checked, chkReverseCalculation.Checked, bIsVatInvoice,
                                                bIsSvatInvoice, txtCustomerBranchID.Tag.ToString(), txtGrnNO.Text,
                                                ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, false,
                                                oldRecord.CompanyID, oldRecord.CompanyBranch_ID,
                                                bIsTaxReversedInvoice, decimal.Parse(lblPercentageNBT.Text.Trim()),
                                                decimal.Parse(lblPercentageVAT.Text.Trim()),
                                                decimal.Parse(lblPercentageSVAT.Text.Trim()),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(lblTaxExcludingValue.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(decimal.Parse(lblNBT.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(decimal.Parse(lblVAT.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(decimal.Parse(lblSVAT.Tag.ToString()),
                                                    txtCurrencyRate),
                                                clsHelpMethods_Local.getSavePrice(
                                                    decimal.Parse(lblGrandTotal.Tag.ToString()), txtCurrencyRate),
                                                decimal.Parse(txtAdvanceReceived.Text),
                                                int.Parse(lblRoute.Tag.ToString()));
                                            detail.Update();

                                            #endregion

                                            clsMethods_GL.PostTransaction_Invoice(txtInvoiceID.Text);

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
                        enum_SerialType ST = enum_SerialType.Standerd;
                        if (clsAutocode.IsAutoGenerated_Advanced(sFormConfigCodeVAT, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, ref ST, IsUpdate, true))
                        {

                            if (ST == enum_SerialType.other)
                            {
                                if ((FormName)iFormID == FormName.Invoice_TAXReverced)
                                {
                                    if (chkVAT2.Checked)
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeVAT, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                    else if (chkSVAT2.Checked)
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeSVAT, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                    else
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeNonTax, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                }
                                else
                                {
                                    if (chkVat.Checked)
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeVAT, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                    else if (chkOtherTax.Checked)
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeSVAT, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                    else
                                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeNonTax, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                                }
                            }
                            else
                                clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCodeVAT, txtSalesNoteType.Tag.ToString(), ref txtInvoiceID);
                        }
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtInvoiceID.Text)) //if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text.Trim() != "<Auto Generate>")
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                            if (oInvoice == null)
                            {
                                bool bIsLocked = false;

                                #region Invoice header
                                tbl_sasInvoice detail = new tbl_sasInvoice(txtInvoiceID.Text.Trim(), "default", dtpInvoiceDate.Value, txtRemark.Text.Trim(),
                                                        txtAddress.Text.Trim(), txtAmountInWord.Text.Trim(), txtCustomerID.Tag.ToString(), txtQuotationID.Tag.ToString(), txtCustomerOrderID.Tag.ToString(),
                                                        txtDeliveryOrder.Tag.ToString(), txtJobCode.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                                         txtCurrencyID.Tag.ToString(), "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtSalesNoteType.Tag.ToString(),
                                                         decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageDisc1.Text.Trim()), decimal.Parse(txtPercentageDisc2.Text.Trim()), decimal.Parse(txtPercentageDisc3.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                        decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc1.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc2.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDisc3.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), decimal.Parse(txtSubTotal_Rec.Text.Trim()), decimal.Parse(txtGrandTotal_Rec.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                        "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                                        false, txtPaymentTerms.Text.Trim(), txtPaymentMode.Text.Trim(), txtCreditPeriod.Text.Trim(), dtpDueDate.Value, bIsLocked, 0, false, false, 0, false,
                                                        false, false, false, false, !chkUnitPricing.Checked, chkReverseCalculation.Checked, bIsVatInvoice, bIsSvatInvoice, txtCustomerBranchID.Tag.ToString(), txtGrnNO.Text, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, false, clsSecurity.CompanyID, clsSecurity.BranchID,
                                                        bIsTaxReversedInvoice, decimal.Parse(lblPercentageNBT.Text.Trim()), decimal.Parse(lblPercentageVAT.Text.Trim()), decimal.Parse(lblPercentageSVAT.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(lblTaxExcludingValue.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(lblNBT.Tag.ToString()), txtCurrencyRate),
                                                        clsHelpMethods_Local.getSavePrice(decimal.Parse(lblVAT.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(lblSVAT.Tag.ToString()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(lblGrandTotal.Tag.ToString()), txtCurrencyRate), decimal.Parse(txtAdvanceReceived.Text), int.Parse(lblRoute.Tag.ToString()));
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
                                        string store_ID = clsValidate.ValidateGridTag(dgvDetail, "store_ID", row.Index, "default");
                                        if (sItemCode.Length > 0)
                                        {
                                            var items = new tbl_sasInvoice_Detail_Ex(int.Parse(sLineNo), txtInvoiceID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                               sDeliveryOrderCode, txtCustomerID.Tag.ToString(), sQuotationCode, sCusOrderCode, sJobCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, 0, 0, dRecommendedUnitPrice,
                                               dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode), store_ID);
                                           
                                            items.Insert2();

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

                                clsMethods_GL.PostTransaction_Invoice(txtInvoiceID.Text);

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
                                MessageBox.Show("This ID is alredy added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Btn Cancel
        private void frm_sasInvoice_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                int Route = -1;
                int.TryParse(lblRoute.Tag.ToString(), out Route);

                if (txtInvoiceID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, Route))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.Invoice_ID))
                                    {
                                        if (!detail.IsLocked)
                                        {
                                            if (detail.SeattleAmount == 0)
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
                                                    //  }
                                                }
                                                else
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                            }
                                            else
                                                MessageBox.Show("This invoice is alredy settled", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void frm_sasInvoice_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasInvoice_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_sasInvoice_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasInvoice_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasInvoice_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
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
                        FillTaxDetailByDeliveryOrderID(glbDeliveryOrderID);

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
                   //     RefreshGridByQuotationID(detail.Quotation_ID);
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
                if (txtDeliveryOrder.Tag != null && txtDeliveryOrder.Tag.ToString().Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrder.Tag.ToString());
                    if (detail != null)
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

                        txtJobCode.Tag = detail.Job_ID;
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);

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
                        FillTaxDetailByDeliveryOrderID(detail.DeliveryOrder_ID);

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            FillDetailsCustomer(detail.Customer_ID);

                        //add item details
                        RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);

                        //add order ref detail
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtSalesExecutiveID.Tag = detail.Employee_ID;
                        txtSalesExecutiveID.Text = clsGenaralName.getName_Employee(detail.Employee_ID);

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                        if (oNoteType != null)
                        {
                            if (!((oNoteType.IsPostingEnable_NBT && oNoteType.IsPostingEnable_VAT)
                                && (chkNBT.Checked || chkVat.Enabled)
                                && (chkNBT2.Checked || chkVAT2.Enabled)))
                            {
                                chkNBT.Checked = false;
                                chkNBT2.Checked = false;
                                chkVat.Checked = false;
                                chkVAT2.Checked = false;

                                lblNBT.Text = "0.00";
                                lblVAT.Text = "0.00";
                                lblNBT.Tag = "0.00";
                                lblVAT.Tag = "0.00";

                                txtNBT.Text = "0.00";
                                txtVat.Text = "0.00";
                                txtNBT.Tag = "0.00";
                                txtVat.Tag = "0.00";

                              
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
        #endregion

        #region Btn Add CustomerOrder
        private void btnAddCustomerOrder_Click(object sender, EventArgs e)
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

                            //add order ref detail

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

                            //add currency detail
                            FillDetailsCurrency(detail.Currency_ID);
                            FillTaxDetailByCustomerOrderID(detail.CustomerOrder_ID);

                            //add item details
                            RefreshGridByCustomerOrderID(detail.CustomerOrder_ID);

                            glbOrderRefNo = detail.OrderRefNo_ID;
                            txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                            txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                            tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                            if (oNoteType != null)
                            {
                                if (!((oNoteType.IsPostingEnable_NBT && oNoteType.IsPostingEnable_VAT)
                                    && (chkNBT.Checked || chkVat.Enabled)
                                    && (chkNBT2.Checked || chkVAT2.Enabled)))
                                {
                                    chkNBT.Checked = false;
                                    chkNBT2.Checked = false;
                                    chkVat.Checked = false;
                                    chkVAT2.Checked = false;

                                    lblNBT.Text = "0.00";
                                    lblVAT.Text = "0.00";
                                    lblNBT.Tag = "0.00";
                                    lblVAT.Tag = "0.00";

                                }
                            }
                        }
                        clsAutocode.IsAutoGenerated_Advanced(sFormConfigCodeVAT, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
                      //  if (!clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                     //       ClearFields();
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
        #endregion

        #region Btn Customer View
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                {
                    frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
                    frm.glbCustomerID = txtCustomerID.Tag.ToString();
                    if (frm.bNoAccess)
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        frm.Show();
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
        private void frm_sasInvoice_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);

                txtInvoiceID.Tag = null;
                dtpInvoiceDate.Value = clsSecurity.getServerDateTime();

                //Reset User Details
                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCodeVAT) && clsAutocode.IsAutoGenerated(sFormConfigCodeNonTax) && clsAutocode.IsAutoGenerated(sFormConfigCodeSVAT))
                    txtInvoiceID.Text = "<Auto Generate>";
                else
                    txtInvoiceID.Clear();
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
                    int iBranchCode = int.Parse(txtCustomerBranchID.Tag.ToString());
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);
            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

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
            chkReverseCalculation.Visible = true;
            pnlTax.Visible = true;
            pnlTaxExclude.Visible = false;
            if ((FormName)iFormID == FormName.Invoice_TAXReverced)
            {
                chkReverseCalculation.Visible = false;
                pnlTax.Visible = false;
                pnlTaxExclude.Visible = true;
            }

            if (clsConfig.bHide_SpecialSettings_Invoice)
                xSetting.Visible = false;

            //set the flag and enble the id
            IsUpdate = false;
            x2.Enabled = true;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);

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

            txtInvoiceID.Tag = null;
            txtCustomerID.Tag = null;
            txtDeliveryOrder.Tag = null;
            txtCustomerOrderID.Tag = null;
            txtQuotationID.Tag = null;
            txtJobCode.Tag = null;
            txtCustomerBranchID.Tag = null;
            txtSalesNoteType.Tag = null;
            lblRoute.Tag = null;

            lblRoute.Text = "";
            txtCustomerID.Clear();
            txtDeliveryOrder.Clear();
            txtCustomerOrderID.Clear();
            txtQuotationID.Clear();
            txtJobCode.Clear();
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
            chkReverseCalculation.Checked = false;
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

            lblPercentageNBT.Text = "0.00";
            lblPercentageVAT.Text = "0.00";
            lblPercentageSVAT.Text = "0.00";
            lblSVAT.Text = "0.00";
            lblVAT.Text = "0.00";
            lblNBT.Text = "0.00";

            lblTaxExcludingValue.Text = "0.00";
            lblGrandTotal.Text = "0.00";

            lblPercentageNBT.Tag = 0;
            lblPercentageVAT.Tag = 0;
            lblPercentageSVAT.Tag = 0;
            lblSVAT.Tag = 0;
            lblVAT.Tag = 0;
            lblNBT.Tag = 0;

            lblTaxExcludingValue.Tag = 0;
            lblGrandTotal.Tag = 0;

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

            lblPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            lblPercentageSVAT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            lblPercentageVAT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;
            chkPrintWithoutHeader.Checked = false;

            chkNBT2.Checked = false;
            chkVAT2.Checked = false;
            chkSVAT2.Checked = false;

            chkNBT2.Enabled = true;
            chkVAT2.Enabled = true;
            chkSVAT2.Enabled = true;

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;

            chkReverseCalculation.Enabled = true;

            txtDiscount.Enabled = true;
            txtPercentageDiscount.Enabled = true;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            txtInvoiceID.Clear();
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCodeVAT, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);

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

            ucSasProcessFlow.ClearFlow();
            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sInvoiceID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                foreach (var detail in tbl_sasInvoice_Detail_Ex.SelectAllByInvoice_ID_WithStore(sInvoiceID).OrderBy(p => p.Line_No))
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
                             detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate, detail.store_ID);
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
            MessageBox.Show("This method is not implemented");
            //try
            //{
            //    int iRow;
            //    foreach (tbl_sasCustomerOrder_Detail detail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID).OrderBy(p => p.Line_No))
            //    {
            //        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
            //        if (item != null)
            //        {
            //            decimal dExRate = 0;
            //            if (txtCurrencyRate.Text.Trim().Length > 0)
            //                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            //            dgvDetail.Rows.Add();
            //            iRow = dgvDetail.Rows.Count - 1;
            //            bool bHasSettledBefore = false;
            //            if (detail.QtySettle_Invoice > 0 || detail.WeightSettle_Invoice > 0)
            //                bHasSettledBefore = true;

            //            Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, "default", detail.CustomerOrder_ID, detail.Quotation_ID, clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID),
            //                item.Uom_ID, detail.UnitPrice, 0, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_Invoice), (detail.Qty - detail.QtySettle_Invoice),
            //                detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
            //        }
            //    }
            //    CalcualteSubTotal();
            //    CalculateTaxesAndGrandTotal();

            //    btnAddDeliveryOrder.Enabled = false;
            //    txtDeliveryOrder.Enabled = false;
            //    btnAddCustomerOrder.Enabled = false;
            //    txtCustomerOrderID.Enabled = false;
            //}
            //catch (Exception ex)
            //{
            //    SEACCException.Show(ex);
            //    clsValidate.WriteErrorLog("", iFormID, ex);
            //}
        }
      
        private void RefreshGridByDeliveryOrderID(string sDeliveryOrder)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
             List<   tbl_sasDeliveryOrder_Detail_Ex> details = tbl_sasDeliveryOrder_Detail_Ex.SelectAllByDeliveryOrder_ID2(sDeliveryOrder).OrderBy(p => p.Line_No).ToList();
                foreach (var detail in details)
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
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0 || detail.QtyReturned > 0)
                            bHasSettledBefore = true;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, detail.CustomerOrder_ID, detail.Quotation_ID, detail.Job_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem,
                             detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle - detail.WeightReturned), (detail.Qty - detail.QtySettle - detail.QtyReturned),
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate,detail.store_ID);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();

                if (!clsConfig.bAllow_Multiple_DO_For_Invoice)
                {
                    btnAddDeliveryOrder.Enabled = false;
                    txtDeliveryOrder.Enabled = false;
                    btnAddCustomerOrder.Enabled = false;
                    txtCustomerOrderID.Enabled = false;
                }
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

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                        txtDeliveryOrder.Tag = detail.DeliveryOrder_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtJobCode.Tag = detail.Job_ID;
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
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
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
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;

                        txtAmountInWord.Text = detail.TatalAmountInWord;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtAddress.Text = detail.Address;

                        #region Customer Branch and Route
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

                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;

                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

                        #region MyRegion
                        if (detail.NbtTotal_EX > 0)
                            chkNBT2.Checked = true;
                        else
                            chkNBT2.Checked = false;

                        if (detail.VatTotal_EX > 0)
                            chkVAT2.Checked = true;
                        else
                            chkVAT2.Checked = false;

                        if (detail.OtherTaxTotal_EX > 0)
                            chkSVAT2.Checked = true;
                        else
                            chkSVAT2.Checked = false;

                        lblPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage_EX);
                        lblPercentageSVAT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage_EX);
                        lblPercentageVAT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage_EX);
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

                        RefreshGrid(detail.Invoice_ID);

                        //process flow
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

                        lblTaxExcludingValue.Tag = clsHelpMethods_Local.getDisplayPrice(detail.SubTotal_EX, detail.CurrencyRate);
                        lblTaxExcludingValue.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal_EX, detail.CurrencyRate));
                        lblNBT.Tag = clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal_EX, detail.CurrencyRate);
                        lblNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal_EX, detail.CurrencyRate));
                        lblVAT.Tag = clsHelpMethods_Local.getDisplayPrice(detail.VatTotal_EX, detail.CurrencyRate);
                        lblVAT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal_EX, detail.CurrencyRate));
                        lblSVAT.Tag = clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal_EX, detail.CurrencyRate);
                        lblSVAT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal_EX, detail.CurrencyRate));
                        lblGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal_EX, detail.CurrencyRate));
                        lblGrandTotal.Tag = clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal_EX, detail.CurrencyRate);

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

                    if ((FormName)iFormID == FormName.Invoice_TAXReverced)
                    {
                        chkSVAT2.Checked = customer.IsSVATenable ? true : false;
                        chkVAT2.Checked = customer.IsVATenable ? true : false;
                        chkNBT2.Checked = customer.IsNBTenable ? true : false;
                    }
                    else
                    {
                        chkOtherTax.Checked = customer.IsSVATenable ? true : false;
                        chkVat.Checked = customer.IsVATenable ? true : false;
                        chkNBT.Checked = customer.IsNBTenable ? true : false;
                    }
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

        #region Fill Tax Detail By DeliveryOrderID
        private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        {
            try
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DeliveryOrderID);

                if (detail != null)
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);

                    if (detail.DiscountTotal > 0)
                        chkDiscount.Checked = true;
                    else
                        chkDiscount.Checked = false;

                    if ((FormName)iFormID != FormName.Invoice_TAXReverced)
                    {
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));

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

                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;

                        #region MyRegion
                        if (detail.NbtTotal > 0)
                            chkNBT2.Checked = true;
                        else
                            chkNBT2.Checked = false;

                        if (detail.VatTotal > 0)
                            chkVAT2.Checked = true;
                        else
                            chkVAT2.Checked = false;

                        if (detail.OtherTaxTotal > 0)
                            chkSVAT2.Checked = true;
                        else
                            chkSVAT2.Checked = false;

                        lblPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                        lblPercentageSVAT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                        lblPercentageVAT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
                        #endregion
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

        #region Fill Tax Detail By CustomerOrderID
        private void FillTaxDetailByCustomerOrderID(string sCustomerOrderID)
        {
            try
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCustomerOrderID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));

                    if (detail.DiscountTotal > 0)
                        chkDiscount.Checked = true;
                    else
                        chkDiscount.Checked = false;

                    if ((FormName)iFormID != FormName.Invoice_TAXReverced)
                    {
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));

                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;
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

        #region Fill Tax Detail By Quotation ID
        private void FillTaxDetailByQuotationID(string sQuotationID)
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
                chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);
        
            int Route = -1;
            int.TryParse(lblRoute.Tag.ToString(),out Route);
          
            bool bStatus = false;

            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    //   if (CheckValidity_RouteWiseDiscount())
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

                                                                    if (clsSecurity.Permission_Route(clsSecurity.UserIDLoged, Route))
                                                                    {
                                                                        if (CheckGrandTotal_Minus())
                                                                        {
                                                                          //  if (clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
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
            if (clsConfig.bAutoPostingEnable)
            {
                #region Check  Account validity
                bool bSlotStatus_NBT = false, bSlotStatus_VAT = false, bSlotStatus_SubTotal = false;
                bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                #endregion

                tbl_zSalesNoteType oSalesNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                if (oSalesNoteType != null)
                {

                    bSlotStatus_NBT = clsMethods_GL.CheckAccountLink_NBTReceivable();
                    bSlotStatus_VAT = clsMethods_GL.CheckAccountLink_VATReceivable();

                    if (oSalesNoteType.Gl_ID != null && clsMethods_GL.CheckAccountValidity(oSalesNoteType.Gl_ID))
                        bSlotStatus_SubTotal = true;
                    else
                        MessageBox.Show("Please Link account to Sub Total", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (bSlotStatus_Customer && bSlotStatus_NBT && bSlotStatus_VAT && bSlotStatus_SubTotal)
                    bStatus = true;
            }
            else
                bStatus = true;

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
                clsCommon.ValidateForeignKey(ref txtJobCode);
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtCustomerBranchID);

                if (glbOrderRefNo.Length <= 0)
                    glbOrderRefNo = "default";
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
            string sItemCode = "", sSubCategory1 = "", sSubCategory2 = "", sSerial1 = "", sSerial2 = "", sDeliveryOrderCode = "", sSubCategory1Name = "", sSubCategory2Name = "";
            bool bHasEnoughQty = false;
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
                        foreach (tbl_sasInvoice_Detail oldRecord in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sSubCategory1 && r.ItemSubCategory2_ID == sSubCategory2 && r.ItemSerialNo == sSerial1 && r.ItemSerialNo2 == sSerial2 && r.DeliveryOrder_ID == sDeliveryOrderCode))
                            dQty += oldRecord.Qty;


                        if (dRadiusedQTY > dQty)
                            dRadiusedQTY = dRadiusedQTY - dQty;
                        else
                            bHasEnoughQty = true;
                    }
                    #endregion
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
            return bHasEnoughQty;
        }
        #endregion

        #region FIFO Cost Price Validate
        public bool FIFOCostPriceValidate()
        {
            string sItemCode = "", sSubCategory1 = "", sSubCategory2 = "", sSerial1 = "", sSerial2 = "", sDeliveryOrderCode = "";
            bool bValidateFIFOCostPrice = false;
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
                        foreach (tbl_sasInvoice_Detail oldRecord in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtInvoiceID.Text.Trim()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sSubCategory1 && r.ItemSubCategory2_ID == sSubCategory2 && r.ItemSerialNo == sSerial1 && r.ItemSerialNo2 == sSerial2 && r.DeliveryOrder_ID == sDeliveryOrderCode))
                            dQty += oldRecord.Qty;

                        if (dRadiusedQTY > dQty)
                        {
                            dRadiusedQTY = dRadiusedQTY - dQty;
                        }
                    }
                    #endregion
                }

                #region FIFO Cost Price Validate
                if (txtSubTotal.TextLength >= 0 && txtDiscount.TextLength >= 0)
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
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_ApprovedBy();
        }
        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            else if (e.Control && e.KeyCode == Keys.D)
                pnlDiscounts_Click(null, null);

        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionProductionJobRegisterByCustomerID_Use(ref txtJobCode, txtCustomerID.Tag.ToString());
                else
                    clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, false, true);
            }
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
            {
                clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
            }
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
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                clsSearch.Search_TransactionProductionJobRegisterByCustomerID_Use(ref txtJobCode, txtCustomerID.Tag.ToString());
            else
                clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, false, true);
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
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {

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
            CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
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
        private void chkReverseCalculation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReverseCalculation.Checked)
            {
                chkReverseCalculation.Enabled = false;
                if (!IsUpdate)
                {
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

                    if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks"
                         && sColName != "Free" && sColName != "DiscuntPresentage" && sColName != "DiscountValue")
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
                clsEvent.SalesGrid_CellEndEdit_Invoice_Old(sender, e, dgvDetail, !chkUnitPricing.Checked);
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

        #region Events MouseMove
        private void Text_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Hand;
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
            chkDup2.Checked = false;
            try
            {
                clsSearch.Search_TransactionInvoice_Direct(ref txtInvoiceID, chkShowSettle.Checked, (FormName)iFormID == FormName.Invoice_TAXReverced, false);
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
                clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, "", true);
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
                    clsSearch.Search_TransactionCustomerOrder_Use(ref txtCustomerOrderID, txtCustomerID.Tag.ToString(), true);
                else
                    clsSearch.Search_TransactionCustomerOrder_Use(ref txtCustomerOrderID, "", true);
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
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrder.Tag.ToString());
                    if (detail != null)
                    {
                        btnAddDeliveryOrder_Click(objSender, new EventArgs());

                        //if (!clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                       //     ClearFields();
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
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCodeVAT, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
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
                    string sCustomerID = "";
                    clsSearch.Search_MasterCustomerID_New(ref sCustomerID, false);

                    if (sCustomerID.Length > 0)
                    {
                        tbl_genCustomerMaster oCustomer2 = tbl_genCustomerMaster.Select(sCustomerID);
                        if (oCustomer2 != null && oCustomer2.Customer_ID != "default")
                        {
                            if (oCustomer2.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price && dgvDetail.Rows.Count > 0)
                            {
                                bIsEnableCustomerChange = false;
                                MessageBox.Show("Customer Wise pricing enabled. Please remove items to change customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                if (oCustomer2.Customer_ID.Length > 0)
                                {
                                    txtCustomerID.Tag = oCustomer2.Customer_ID;
                                    FillDetailsCustomer(oCustomer2.Customer_ID);

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

                                    tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                                    if (oNoteType != null)
                                    {
                                        chkVat.Enabled = oNoteType.IsPostingEnable_VAT ? true : false;
                                        chkNBT.Enabled = oNoteType.IsPostingEnable_NBT ? true : false;
                                        chkVat.Checked = oNoteType.IsPostingEnable_VAT ? true : false;
                                        chkNBT.Checked = oNoteType.IsPostingEnable_NBT ? true : false;

                                        chkVAT2.Enabled = oNoteType.IsPostingEnable_VAT ? true : false;
                                        chkNBT2.Enabled = oNoteType.IsPostingEnable_NBT ? true : false;
                                        chkVAT2.Checked = oNoteType.IsPostingEnable_VAT ? true : false;
                                        chkNBT2.Checked = oNoteType.IsPostingEnable_NBT ? true : false;
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
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);
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
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCodeVAT, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtInvoiceID, IsUpdate);
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
                    if (dgvDetail["Amount", x].Tag != null && dgvDetail["Amount", x].Tag.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetail["Amount", x].Tag.ToString()))
                            Amount += decimal.Parse(dgvDetail["Amount", x].Tag.ToString());
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
                    decimal dUnitPrice = 0, dWeightPrice = 0, dQty = 0, dWeight = 0; //decimal dVatAmount = 0;
                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
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
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice;// clsFormatter.FormatToNumberWithTwoDecimalPlaces(dUnitPrice);
                            dgvDetail["UnitPrice", row.Index].Tag = dUnitPrice;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice;// clsFormatter.FormatToNumberWithTwoDecimalPlaces(dWeightPrice);
                            dgvDetail["WeightPrice", row.Index].Tag = dWeightPrice;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["WeightPrice"].Index, row.Index));
                        }
                    }
                    else
                    {
                        if (chkUnitPricing.Checked)
                        {
                            dgvDetail["UnitPrice", row.Index].Value = dUnitPrice.ToString();
                            dgvDetail["UnitPrice", row.Index].Tag = dUnitPrice.ToString();
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        else
                        {
                            dgvDetail["WeightPrice", row.Index].Value = dWeightPrice.ToString();
                            dgvDetail["WeightPrice", row.Index].Tag = dWeightPrice.ToString();
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
            decimal dDiscountTotal = 0, dDiscountPresent = 0;
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotal_WithMultiplediscount(txtSubTotal,
                 txtDiscount, txtPercentageDiscount, chkDiscount,
                 txtDisc1, txtPercentageDisc1, chkDisc1,
                 txtDisc2, txtPercentageDisc2, chkDisc2,
                 txtDisc3, txtPercentageDisc3, chkDisc3,
                 txtNBT, txtPercentageNBT, chkNBT,
                 txtVat, txtPercentageVat, chkVat,
                 txtOtherTax, txtPercentageOtherTax, chkOtherTax,
                 ref dDiscountTotal, ref dDiscountPresent));

            txtAmountInWord.Text = clsCommon.CurrencyToWord(decimal.Parse(txtGrandTotal.Text.Trim()));

            lblDiscountTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountTotal);
            lblDiscountPresentTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresent);

            lblGrandTotal.Tag = txtGrandTotal.Text;
            CalculateTaxesAndGrandTotal_TaxEx();
        }
        #endregion

        #region Calculate Taxes and Grand Total
        private void CalculateTaxesAndGrandTotal_TaxEx()
        {
            clsHelpMethods.CalculateGrandTotalReverce(lblGrandTotal, ref lblVAT, lblPercentageVAT, chkVAT2, ref lblSVAT, lblPercentageSVAT, chkSVAT2, ref lblNBT, lblPercentageNBT, chkNBT2, ref lblTaxExcludingValue);
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int lineNo, string ItemID, string DeliveryOrderID, string CusOrderID, string QuotationID, string JobID, string Uom_ID, decimal UnitPrice, decimal KiloPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled, decimal dExRate,string store_ID)
        {
            try
            {
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

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
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
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(GrossTotal);
                dgvDetail["Amount", iRow].Tag = GrossTotal;
 
                dgvDetail["store_ID", iRow].Tag = store_ID;
                dgvDetail["store_ID", iRow].Value =clsGenaralName.getName_Store(store_ID);
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
        private void chkNBT2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal_TaxEx();
        }

        private void chkVAT2_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal_TaxEx();
        }

        private void chkSVAT2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSVAT2.Checked)
                chkVAT2.Checked = false;

            CalculateTaxesAndGrandTotal_TaxEx();
        }

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

        #region Print Method
        private void print(bool bIsDraft)
        {
            #region dataset
            try
            {
                string sBranchId = "", s_Path = "", sCusAddress = "", sStoreID = "default", sStoreName = "", sRoute = "", sSalesmanContact = "", sReportID = clsAutocode.getReportID(enum_ReportName.NP_Invoice);
                decimal dCreditBalance = 0, dGrandTotal = 0;
                bool bCheckingDone = true, bApprovalDone = true, bPermissinOkToPrint = false, bPermissinOkToPrintOriginal = true, bCreditLimitOK = false;
                Cursor = Cursors.WaitCursor;

                if (txtInvoiceID.TextLength > 0 && txtInvoiceID.Text != "<Auto Generate>")
                {
                    glb_dtsSasInvoice.Clear();
                    glb_dtsReportExport.Clear();

                    int count = 0;
                    String sDuplicateCopy = "";
                    String sDeliveryOrders = "";

                    tbl_sasInvoice Detail = tbl_sasInvoice.Select(txtInvoiceID.Text);
                    if (Detail != null)
                    {

                        if (Detail.PrintCount > 0)
                        {
                            if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 1101, true, false))
                            {
                                MessageBox.Show("Access Denied ! \n\nUser does not have access to Print duplicates, Please get permission from the system administrator ");
                                return;
                            }
                        }


                        if (Detail.IsTaxExcludedInvoice)
                            sReportID = clsAutocode.getReportID(enum_ReportName.NP_Invoice_2);

                        s_Path = clsHelpMethods_Local.GetReportPath(sReportID);
                        if (chkPrintOriginal.Checked)
                        {
                            bPermissinOkToPrintOriginal = clsSecurity.PermissionToPrintOriginal_WithMessage(sReportID);
                            bPermissinOkToPrint = bPermissinOkToPrintOriginal;
                        }

                        if (bPermissinOkToPrintOriginal)
                        {
                            if (!bIsDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintInvoice)
                                {
                                    if (!Detail.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintInvoice)
                                {
                                    if (!Detail.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            #region Check Credit Balance
                            dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                            dGrandTotal = Detail.GrandTotal;
                            if (clsConfig.bCreditBalanceInvoice_Check)
                            {
                                if (dGrandTotal < dCreditBalance || Detail.IsApproved)
                                    bCreditLimitOK = true;
                                else
                                    bCreditLimitOK = false;
                            }
                            else
                                bCreditLimitOK = true;
                            #endregion

                            if (bCreditLimitOK) //Condition
                            {
                                if (bApprovalDone && bCheckingDone)
                                {
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(Detail.Customer_ID);
                                    if (oCustomer != null)
                                    {
                                        string sSalesmanID = "", sSalesmanName = "", sInvoiceType = "";
                                        #region Get PO No / Date
                                        string sPoNO = "-";
                                        string sPoDate = "   -";
                                        foreach (tbl_sasCustomerOrder oCo in tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(Detail.OrderRefNo_ID))
                                        {
                                            if (oCo.PurchaseOrder_ID != "default")
                                                sPoNO = oCo.PurchaseOrder_ID;

                                            sPoDate = clsFormatter.FormatDate_Short(oCo.CustomerOrderDate);
                                        }
                                        #endregion

                                        #region Get Customer Branch
                                        sCusAddress = Detail.Address != "" ? Detail.Address : oCustomer.AddressDelivery;
                                        if (Detail.Branch_ID != null && Detail.Branch_ID != "default")
                                        {
                                            tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oCustomer.Customer_ID, Convert.ToInt16(Detail.Branch_ID));
                                            sBranchId = oBranch.BranchName;

                                            tbl_genRoute oRoute = tbl_genRoute.Select(oBranch.Route_ID);
                                            if (oRoute != null)
                                            {
                                                sRoute = oRoute.RouteName;
                                            }

                                        }
                                        #endregion

                                        #region Get Salesman
                                        tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(Detail.OrderRefNo_ID);
                                        if (oRef != null && oRef.OrderRefNo_ID != "default")
                                        {
                                            sSalesmanID = oRef.Employee_ID;
                                            sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);

                                            tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oRef.Employee_ID);
                                            if (oEmployee != null)
                                                sSalesmanContact = oEmployee.Mobile;

                                        }
                                        #endregion

                                        #region Invoice Type
                                        if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                            sInvoiceType = clsGenaralName.getName_SalesNoteType(Detail.SalesNoteType_ID);
                                        else if (Detail.Job_ID != "default")
                                            sInvoiceType = clsGenaralName.getName_ProductionJobType(Detail.Job_ID);
                                        #endregion

                                        #region Tax Type
                                        string sTaxType = "";
                                        if (Detail.IsVatInvoice)
                                        {
                                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                                sTaxType = "TAX";
                                            else
                                                sTaxType = "VAT";
                                        }
                                        else if (Detail.IsSVatInvoice)
                                            sTaxType = "SVAT";
                                        else
                                            sTaxType = "NON TAX";
                                        #endregion

                                        #region Invoice Detail
                                        decimal dTotall = 0;
                                        List<tbl_sasInvoice_Detail_Ex> oOrderDetails = tbl_sasInvoice_Detail_Ex.SelectAllByInvoice_ID_WithStore(Detail.Invoice_ID);
                                        foreach (tbl_sasInvoice_Detail_Ex Detail1 in oOrderDetails.OrderBy(p => p.Line_No))
                                        {
                                            tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(Detail1.Item_ID);
                                            tbl_zUom oUom = tbl_zUom.Select(Detail1.Uom_ID);
                                            decimal dUnitPrice = 0, dQTY = 0;
                                            if (oUom != null && oItmaster != null)
                                            {
                                                count++;
                                                if (Detail.IsWeightCalculation)
                                                {
                                                    dUnitPrice = clsHelpMethods_Local.getDisplayPrice(Detail1.WeightPrice, Detail.CurrencyRate);
                                                    dQTY = Detail1.Weight;
                                                }
                                                else
                                                {
                                                    dUnitPrice = clsHelpMethods_Local.getDisplayPrice(Detail1.UnitPrice, Detail.CurrencyRate);
                                                    dQTY = Detail1.Qty;
                                                }

                                                dTotall += (Detail1.Qty * Detail1.UnitPrice) - Detail.DiscountTotal;//For SDB No 2 Account, Amount in Word

                                                glb_dtsSasInvoice.dt_sasInvoice_Detail.Adddt_sasInvoice_DetailRow(Detail1.Invoice_ID, Detail1.Item_ID,
                                                    clsGenaralName.getName_Brand(oItmaster.Brand_ID), dUnitPrice, dQTY, oItmaster.ItemName, Detail1.Remark, oUom.UomCode, count,clsGenaralName.getName_Store_Short( Detail1.store_ID), Detail1.DiscountPresentage, clsHelpMethods_Local.getDisplayPrice(Detail1.DiscountAmount, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail1.TatalAmount, Detail.CurrencyRate), Detail1.BIsFreeItem, clsHelpMethods_Local.getDisplayPrice(Detail1.DiscountAmount, Detail.CurrencyRate) * dQTY, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID));
                                            }
                                        }

                                        int iDoCount = 0;
                                        foreach (var oDeliveryOrder in oOrderDetails.OrderBy(k => k.DeliveryOrder_ID).GroupBy(cm => new { cm.DeliveryOrder_ID }, (key, group) => new { DeliveryID = key.DeliveryOrder_ID }))
                                        {
                                            sDeliveryOrders += oDeliveryOrder.DeliveryID + " | ";
                                            iDoCount++;
                                        }
                                        sDeliveryOrders = sDeliveryOrders.Substring(0, sDeliveryOrders.Length - 3);
                                        #endregion

                                        #region Get Do Date
                                        DateTime dtmDoDate = DateTime.MinValue;

                                        tbl_sasDeliveryOrder oDo = tbl_sasDeliveryOrder.Select(Detail.DeliveryOrder_ID);
                                        if (oDo != null && oDo.DeliveryOrder_ID != "default")
                                            dtmDoDate = oDo.DeliveryOrderDate;
                                        #endregion

                                        #region Get Payment Method
                                        string sPaymentMethod = " -";
                                        tbl_zPaymentMethod oPaymentMethod = tbl_zPaymentMethod.Select(Detail.PaymentMode);
                                        if (oPaymentMethod != null && oPaymentMethod.PaymentMethod_ID != "default")
                                            sPaymentMethod = oPaymentMethod.PaymentMethodName != "" ? oPaymentMethod.PaymentMethodName : " -";
                                        #endregion

                                        #region Get Totals
                                        decimal dNbtAmout = 0, dvatAmount = 0, dSvatAmount = 0, dGrandToatal = 0, dnbtPresentage = 0, dVatPreasentage = 0, dSvatPresentage = 0;
                                        if (!Detail.IsTaxExcludedInvoice)
                                        {
                                            dNbtAmout = clsHelpMethods_Local.getDisplayPrice(Detail.NbtTotal, Detail.CurrencyRate);
                                            dvatAmount = clsHelpMethods_Local.getDisplayPrice(Detail.VatTotal, Detail.CurrencyRate);
                                            dSvatAmount = clsHelpMethods_Local.getDisplayPrice(Detail.OtherTaxTotal, Detail.CurrencyRate);
                                            dGrandToatal = clsHelpMethods_Local.getDisplayPrice(Detail.GrandTotal, Detail.CurrencyRate);
                                            dnbtPresentage = clsHelpMethods_Local.getDisplayPrice(Detail.NbtPercentage, Detail.CurrencyRate);
                                            dVatPreasentage = clsHelpMethods_Local.getDisplayPrice(Detail.VatPercentage, Detail.CurrencyRate);
                                            dSvatPresentage = clsHelpMethods_Local.getDisplayPrice(Detail.OtherTaxPercentage, Detail.CurrencyRate);
                                        }
                                        else
                                        {
                                            dNbtAmout = clsHelpMethods_Local.getDisplayPrice(Detail.NbtTotal_EX, Detail.CurrencyRate);
                                            dvatAmount = clsHelpMethods_Local.getDisplayPrice(Detail.VatTotal_EX, Detail.CurrencyRate);
                                            dSvatAmount = clsHelpMethods_Local.getDisplayPrice(Detail.OtherTaxTotal_EX, Detail.CurrencyRate);
                                            dSvatAmount = clsHelpMethods_Local.getDisplayPrice(Detail.OtherTaxTotal_EX, Detail.CurrencyRate);
                                            dGrandToatal = clsHelpMethods_Local.getDisplayPrice(Detail.GrandTotal_EX, Detail.CurrencyRate);
                                            dnbtPresentage = clsHelpMethods_Local.getDisplayPrice(Detail.NbtPercentage_EX, Detail.CurrencyRate);
                                            dVatPreasentage = clsHelpMethods_Local.getDisplayPrice(Detail.VatPercentage_EX, Detail.CurrencyRate);
                                            dSvatPresentage = clsHelpMethods_Local.getDisplayPrice(Detail.OtherTaxPercentage_EX, Detail.CurrencyRate);
                                        }

                                        #endregion

                                        #region Get user Details
                                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                                        sCreateUser = "[ " + clsGenaralName.getName_User(Detail.CreateUser_ID) + " ] [ " + Detail.DateCreate.ToShortDateString() + " ]";
                                        if (Detail.CheckedUser_ID != "default")
                                            sCheckedUser = "[ " + clsGenaralName.getName_User(Detail.CheckedUser_ID) + " ] [ " + Detail.DateChecked.ToShortDateString() + " ]";
                                        if (Detail.ApprovedUser_ID != "default")
                                            sApprovedUser = "[ " + clsGenaralName.getName_User(Detail.ApprovedUser_ID) + " ] [ " + Detail.DateApproved.ToShortDateString() + " ]";
                                        #endregion

                                        #region Header
                                        string sCOID = Detail.CustomerOrder_ID, sOrderNum = "";
                                        if (sCOID == "default")
                                        {
                                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(Detail.DeliveryOrder_ID);
                                            if (oDO != null)
                                            {
                                                sCOID = oDO.CustomerOrder_ID;
                                                sStoreID = oDO.Store_ID;
                                                if (sStoreID != "default")
                                                    sStoreName = clsGenaralName.getName_Store(sStoreID);

                                                tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCOID);
                                                if (oCO != null)
                                                {
                                                    sOrderNum = clsGenaralName.getName_OrderRefNo(oCO.OrderRefNo_ID);
                                                }
                                            }
                                            else
                                                sCOID = "-";
                                        }
                                        else
                                        {
                                            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCOID);
                                            if (oCO != null)
                                            {
                                                sOrderNum = clsGenaralName.getName_OrderRefNo(oCO.OrderRefNo_ID);
                                            }
                                        }

                                        glb_dtsSasInvoice.dt_sasInvoice.Adddt_sasInvoiceRow(Detail.Invoice_ID, Detail.InvoiceDate, Detail.Customer_ID, oCustomer.CustomerName, sCusAddress, oCustomer.Telephone, sBranchId, sRoute,
                                        sStoreID, sStoreName, sSalesmanName, sSalesmanContact, "", "", Detail.IsDeleted, (iDoCount == 1) ? sDeliveryOrders : "", sInvoiceType, clsHelpMethods_Local.getDisplayPrice(Detail.SubTotal, Detail.CurrencyRate),
                                            clsHelpMethods_Local.getDisplayPrice(Detail.DiscountPercentage, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail.DiscountTotal, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail.SubTotal_EX, Detail.CurrencyRate),
                                            dnbtPresentage, dNbtAmout, dVatPreasentage, dvatAmount, dSvatPresentage, dSvatAmount, dGrandToatal, sCOID, clsHelpMethods_Local.getCustomerPurchaseOrderID(Detail.OrderRefNo_ID), sOrderNum,
                                            Detail.IsSVatInvoice ? oCustomer.SvatRegistrationNo : oCustomer.VatRegistrationNo, oCustomer.SvatRegistrationNo, oCustomer.NbtRegistrationNo, sTaxType, Detail.IsWeightCalculation, dtmDoDate,
                                                clsHelpMethods_Local.getDisplayPrice(Detail.DiscountPercentage1, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail.DiscountPercentage2, Detail.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(Detail.DiscountPercentage3, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail.DiscountTotal1, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail.DiscountTotal2, Detail.CurrencyRate),
                                                clsHelpMethods_Local.getDisplayPrice(Detail.DiscountTotal3, Detail.CurrencyRate), sPoNO, Detail.TatalAmountInWord, sPoDate, sPaymentMethod, Detail.IsSVatInvoice,
                                                Detail.IsVatInvoice, Detail.PaymentTerms, Detail.Remark, Detail.Currency_ID, clsGenaralName.getName_CurrencyCode(Detail.Currency_ID), Detail.PaymentDueDate);

                                        #endregion

                                        #region Update Print Count and Duplicate Copy
                                        if (!bIsDraft)
                                        {
                                            if (!chkPrintOriginal.Checked)
                                                sDuplicateCopy = (Detail.PrintCount > 0) ? "Duplicate Copy " + Detail.PrintCount : "";

                                            Detail.PrintCount++;
                                            Detail.DatePrinted = clsSecurity.getServerDateTime();
                                            Detail.PrintedTerminal_ID = clsSecurity.TerminalID;
                                            Detail.PrintedUser_ID = clsSecurity.UserIDLoged;
                                            Detail.Update();
                                        }
                                        #endregion

                                        #region Get Outstanding Amount / Chq In Hand Amount
                                        DataTable dtOSL = DBHandling.ExecQuery("sp_bssCustomerOutstanding '" + "%%" + "', '" + "%%" + "', '" + "%%" + "', '"
                                            + Detail.Customer_ID + "', '" + "%%" + "', '" + "%%" + "' , '" + "2001-01-01', '" + clsSecurity.getServerDateTime().Date + "', "
                                            + false + ",  " + true + "  , " + false).Tables[0];

                                        decimal dTotalOutstanding = 0;
                                        bool bIsChequeInHand = false;
                                        decimal dChqInHandAmount = 0;

                                        foreach (DataRow dr in dtOSL.Rows)
                                        {
                                            bIsChequeInHand = bool.Parse(dr["IsChequeInHand"].ToString()); ;

                                            if (!bIsChequeInHand)
                                                dTotalOutstanding += decimal.Parse(dr["Amount"].ToString());
                                            else
                                                dChqInHandAmount += decimal.Parse(dr["Amount"].ToString());
                                        }

                                        #endregion

                                        #region Get Credit Limit
                                        DataTable dtCL = DBHandling.ExecQuery("select creditLimit from tbl_genCustomerFinance where customer_ID = '"
                                            + Detail.Customer_ID + "' ").Tables[0];

                                        decimal dCrLimit = 0;
                                        dCrLimit = dtCL.Rows[0].Field<decimal>("creditLimit");
                                                                                
                                        #endregion

                                        #region Parameters
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("TotalOutstanding", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreditLimit", clsFormatter.FormatDecimalPlaces_Price(dCrLimit), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ChqInHand", clsFormatter.FormatDecimalPlaces_Price(dChqInHandAmount), true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true);

                                        if (!bPermissinOkToPrint)
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DeliveryOrder2", iDoCount == 1 ? "" : sDeliveryOrders, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PurchaseOrderNo", sPoNO, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyNBT", clsCommon.getCompanyNBT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true);

                                        try
                                        {
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("AmountInWord", clsCommon.CurrencyToWord(decimal.Parse(dTotall.ToString())), true);
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PriceCategory", clsFill.GetItemPriceName(Detail.ItemPriceCategory), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BisRegNo", clsCommon.getCompanyBusinessRegisterNo(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("OurVATNo", clsCommon.getCompanyVAT(), true);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sTaxType + " INVOICE", true);

                                        try
                                        {
                                            foreach (tbl_zDiscount oDiscounts in tbl_zDiscount.SelectAll())
                                            {
                                                switch (oDiscounts.Discount_Id)
                                                {
                                                    case "D001":
                                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Discount1", oDiscounts.DiscountName, true);
                                                        break;
                                                    case "D002":
                                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Discount2", oDiscounts.DiscountName, true);
                                                        break;
                                                    case "D003":
                                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Discount3", oDiscounts.DiscountName, true);
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                        catch (Exception) { }
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
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyNBT", "", true);
                                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", "", true);
                                            }
                                        }
                                        glb_dtsSasInvoice.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " INVOICE", "", "", clsSecurity.UserNameLoged, "");
                                        #endregion

                                        #region Print Section
                                        frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                        rpt.print(s_Path, glb_dtsSasInvoice, glb_dtsReportExport.dt_rptParameter, sReportID);
                                        #endregion
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Customer's available Credit Limit is Lower than Entered Amount.... \n  Please approve before printing this invoice", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            #endregion
        }
        #endregion

        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{left}");
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


        #region User Checked Approve Details
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
                                    glbApprovedDate = clsSecurity.getServerDateTime();
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
                                    glbCheckedDate = clsSecurity.getServerDateTime();

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
        private void UserDetails()
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
    }
}