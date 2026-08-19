using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using System.Reflection;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using Zion.ERP.Reports.DataSets.SAS;
using ZION.ERP.Reports.DataSets.SAS;

namespace Digiteq
{
    public partial class frm_sasProformaInvoice : SEACC_Form
    {
        
        //to keep glob ref no        
        public string glbOrderRefNo = "", glbQuotationID = "", glbProformaInvoiceID = "", glbInquiryID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;

        dts_sasInvoice glb_dtsSasInvoice = new dts_sasInvoice();
     

        #region Form Load
        public frm_sasProformaInvoice(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusProformaInvoice);
            //sFormConfigCode2 = clsAutocode.getFormConfigCode(FormName.CusProformaInvoice);
            //iFormID = clsSecurity.getFormID(FormName.VATInvoice);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
            bHasPermissionToLineDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_LineDiscount));
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, false, true, true, true, true, true, true);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            if (glbInquiryID.Length > 0)
            {
                tbl_sasInquiry detail = tbl_sasInquiry.Select(glbInquiryID);
                if (detail != null)
                {
                    chkUnitPricing.Checked = !detail.IsWeightCalculation;
                    FillDetailsCustomer(detail.Customer_ID);
                    glbOrderRefNo = detail.OrderRefNo_ID;
                    txtInquiryCode.Tag = detail.Inquiry_ID;
                    FillTaxDetailByInquiry(glbInquiryID);
                    btnAddInquiry_Click(sender, new EventArgs());
                }
            }
            else if (glbQuotationID.Length > 0)
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(glbQuotationID);
                if (detail != null)
                {
                    chkUnitPricing.Checked = !detail.IsWeightCalculation;
                    FillDetailsCustomer(detail.Customer_ID);
                    glbOrderRefNo = detail.OrderRefNo_ID;
                    txtQuotationID.Tag = detail.Quotation_ID;
                    FillTaxDetailByQuotationID(glbQuotationID);
                    btnAddQuotation_Click(sender, new EventArgs());
                }
            }
            else if (glbProformaInvoiceID.Length > 0)
            {
                FillDetails(glbProformaInvoiceID);
            }

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        #endregion

        #region Btn New
        private void frm_sasProformaInvoice_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion      

        #region Btn Save
        private void frm_sasProformaInvoice_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    if (IsUpdate)  //update records
                    {
                        #region Update
                        tbl_sasProformaInvoice oldRecord = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount)// && clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                            )
                        {
                            if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                            {
                                if (!oldRecord.IsChecked ||
                                    (oldRecord.IsChecked &&
                                     clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                {
                                    if (clsValidate.CheckValidity_TransactionCodeLength(txtProformaInvoiceID.Text))
                                    {

                                        //Invoice Detail                                   

                                        #region Update old Details

                                        List<tbl_sasProformaInvoice_Detail> oldInvDetails =
                                            tbl_sasProformaInvoice_Detail.SelectAllByProformaInvoice_ID(
                                                txtProformaInvoiceID.Text.Trim());
                                        foreach (tbl_sasProformaInvoice_Detail oldInvDetail in oldInvDetails)
                                        {
                                            string sItemCode = "",
                                                sQuotationCode = "",
                                                sJobCode = "",
                                                sUOM = "",
                                                sItemSubCategoryID = "",
                                                sItemSubCategoryID2 = "",
                                                sItemSerialNo = "",
                                                sItemSerialNo2 = "",
                                                sRemarks = "",
                                                sLineNo = "";
                                            decimal dWeightPrice = 0,
                                                dUnitPrice = 0,
                                                dQuantity = 0,
                                                dWeight = 0,
                                                dAmount = 0,
                                                dDiscountPresentage = 0,
                                                dDiscountValue = 0;
                                            bool bHasInvoInDB = false;
                                            bool bIsFreeIssue = false;

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                    "0");
                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                    row.Index, "");
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

                                                if (oldInvDetail.ProformaInvoice_ID ==
                                                    txtProformaInvoiceID.Text.Trim() &&
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
                                                //////Update Delivery Order 

                                                #region Update Delivery Order

                                                if (sQuotationCode != "default")
                                                {
                                                    tbl_sasQuotation_Detail DoItem =
                                                        tbl_sasQuotation_Detail.Select(int.Parse(sLineNo),
                                                            sQuotationCode, sItemCode, sItemSubCategoryID,
                                                            sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                    if (DoItem != null)
                                                    {
                                                        if (chkUnitPricing.Checked)
                                                            DoItem.QtySettle_PInvoice =
                                                                (DoItem.QtySettle_PInvoice - oldInvDetail.Qty) +
                                                                dQuantity;
                                                        else
                                                            DoItem.WeightSettle_PInvoice =
                                                                (DoItem.WeightSettle_PInvoice - oldInvDetail.Weight) +
                                                                dWeight;
                                                        DoItem.Update();
                                                        //  clsProcessMethods.SetSettle_DeliveryOrder(sDeliveryOrderCode, chkUnitPricing);
                                                    }
                                                }

                                                #endregion

                                                oldInvDetail.Line_No = int.Parse(sLineNo);
                                                oldInvDetail.Item_ID = sItemCode;
                                                oldInvDetail.Quotation_ID = sQuotationCode;
                                                oldInvDetail.Job_ID = sJobCode;
                                                oldInvDetail.Qty = dQuantity;
                                                oldInvDetail.Weight = dWeight;
                                                oldInvDetail.UnitPrice = dUnitPrice;
                                                oldInvDetail.BIsFreeItem = bIsFreeIssue;
                                                oldInvDetail.DiscountPresentage = dDiscountPresentage;
                                                oldInvDetail.DiscountAmount = dDiscountValue;
                                                oldInvDetail.WeightPrice = dWeightPrice;
                                                oldInvDetail.TatalAmount = dAmount;
                                                oldInvDetail.Remark = sRemarks;
                                                oldInvDetail.Uom_ID = sUOM;
                                                oldInvDetail.Update();
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
                                            string sItemCode = "",
                                                sQuotationCode = "",
                                                sJobCode = "",
                                                sUOM = "",
                                                sItemSubCategoryID = "",
                                                sItemSubCategoryID2 = "",
                                                sItemSerialNo = "",
                                                sItemSerialNo2 = "",
                                                sRemarks = "",
                                                sLineNo = "";
                                            decimal dWeightPrice = 0,
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

                                            sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                "0");
                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index,
                                                "");
                                            sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode",
                                                row.Index, "default");
                                            sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index,
                                                "default");
                                            sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                            dWeightPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice",
                                                row.Index, decimal.Parse("0.00"));
                                            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index,
                                                decimal.Parse("0.00"));
                                            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                decimal.Parse("0.00"));
                                            dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index,
                                                decimal.Parse("0.00"));

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
                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2",
                                                row.Index, "0");
                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index,
                                                "");
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

                                            if (sItemCode.Length > 0)
                                            {
                                                tbl_sasProformaInvoice_Detail items = new tbl_sasProformaInvoice_Detail(
                                                    int.Parse(sLineNo), txtProformaInvoiceID.Text.Trim(), sItemCode,
                                                    sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                    sItemSerialNo2, sQuotationCode, sJobCode, dQuantity, 0, dWeight, 0,
                                                    dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage,
                                                    dDiscountValue, dAmount, dRecommendedUnitPrice,
                                                    dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM);
                                                items.Insert();

                                                //////Update Delivery Order 

                                                #region Update Delivery Order

                                                //if (sDeliveryOrderCode != "default")
                                                //{
                                                //    tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                //    if (chkUnitPricing.Checked)
                                                //        DoItem.QtySettle = DoItem.QtySettle + dQuantity;
                                                //    else
                                                //        DoItem.WeightSettle = DoItem.WeightSettle + dWeight;
                                                //    DoItem.Update();
                                                //    clsProcessMethods.SetSettle_DeliveryOrder(sDeliveryOrderCode, chkUnitPricing);
                                                //}

                                                #endregion
                                            }
                                        }

                                        #endregion

                                        //Invoice Header

                                        #region Update Invoice Header

                                        bool bIsLocked = oldRecord.IsLocked;
                                        if (chkReverseCalculation.Checked)
                                            bIsLocked = true;

                                        tbl_sasProformaInvoice detail = new tbl_sasProformaInvoice(
                                            txtProformaInvoiceID.Text.Trim(), dtpInvoiceDate.Value,
                                            txtRemark.Text.Trim(),
                                            txtCustomerID.Tag.ToString(), txtInquiryCode.Tag.ToString(),
                                            txtQuotationID.Tag.ToString(), txtJobCode.Tag.ToString(), glbOrderRefNo,
                                            txtPaymentTerms.Text.Trim(), txtPaymentMode.Tag.ToString(),
                                            txtCreditPeriod.Text.Trim(), dtpDueDate.Value, txtCurrencyID.Tag.ToString(),
                                            oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                            oldRecord.FinancialYear_ID, oldRecord.AccountNumber, oldRecord.CompanyID,
                                            decimal.Parse(txtCurrencyRate.Text.Trim()),
                                            decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                            decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            decimal.Parse(txtPercentageVat.Text.Trim()),
                                            decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                            decimal.Parse(txtSubTotal.Tag.ToString()),
                                            decimal.Parse(txtDiscount.Tag.ToString()),
                                            decimal.Parse(txtNBT.Tag.ToString()), decimal.Parse(txtVat.Tag.ToString()),
                                            decimal.Parse(txtOtherTax.Tag.ToString()),
                                            decimal.Parse(txtGrandTotal.Text.Trim()),
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
                                            oldRecord.IsDeleted, bIsLocked, oldRecord.IsSeattled,
                                            !chkUnitPricing.Checked, oldRecord.PrintCount, oldRecord.IsPriceEnabled,
                                            chkReverseCalculation.Checked,
                                            chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat),
                                            clsHelpMethods.isTaxActiveNote(txtOtherTax), "default");
                                        detail.Update();

                                        #endregion

                                        //Attachments.Insert(iFormID, oldRecord.ProformaInvoice_ID);
                                        //Attachments.Remove(iFormID, oldRecord.ProformaInvoice_ID);

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
                        #endregion
                    }
                    else  //insert records
                    {
                        #region Insert

                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtProformaInvoiceID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);


                        if (clsValidate.CheckValidity_TransactionCodeLength(txtProformaInvoiceID.Text)) //if (txtProformaInvoiceID.TextLength > 0)
                        {
                            bool bIsLocked = false;
                            if (chkReverseCalculation.Checked)
                                bIsLocked = true;

                            //Invoice Header
                            #region Invoice Header
                            tbl_sasProformaInvoice detail = new tbl_sasProformaInvoice(txtProformaInvoiceID.Text.Trim(), dtpInvoiceDate.Value, txtRemark.Text.Trim(),
                                                    txtCustomerID.Tag.ToString(), txtInquiryCode.Tag.ToString(), txtQuotationID.Tag.ToString(), txtJobCode.Tag.ToString(), glbOrderRefNo,
                                                    txtPaymentTerms.Text.Trim(), txtPaymentMode.Tag.ToString(), txtCreditPeriod.Text.Trim(), dtpDueDate.Value, txtCurrencyID.Tag.ToString(),
                                                    "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtAccNo.Tag.ToString(), clsSecurity.CompanyID,
                                                    decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                    decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Tag.ToString()),
                                                    decimal.Parse(txtDiscount.Tag.ToString()), decimal.Parse(txtNBT.Tag.ToString()), decimal.Parse(txtVat.Tag.ToString()), decimal.Parse(txtOtherTax.Tag.ToString()),
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), decimal.Parse(txtSubTotal_Rec.Text.Trim()), decimal.Parse(txtGrandTotal_Rec.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                    "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                                                    false, bIsLocked, false, !chkUnitPricing.Checked, 0, false, chkReverseCalculation.Checked, chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), "default");
                            detail.Insert();
                            #endregion

                            //Invoice  Detail                                
                            #region Invoice Details
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sItemCode = "", sUOM = "default", sQuotationCode = "", sJobCode = "",
                                         sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sLineNo = "";
                                    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dRecommendedUnitPrice = 0,
                                        dRecommendedWeightPrice = 0, dRecommendedAmount = 0, dDiscountPresentage = 0, dDiscountValue = 0;
                                    bool bIsFreeIssue = false;

                                    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
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

                                    if (sItemCode.Length > 0)
                                    {
                                        tbl_sasProformaInvoice_Detail items = new tbl_sasProformaInvoice_Detail(int.Parse(sLineNo), txtProformaInvoiceID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                            sQuotationCode, sJobCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, dRecommendedUnitPrice,
                                            dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM);
                                        items.Insert();

                                        //////Update Quotaion
                                        #region Update Quotation
                                        if (sQuotationCode != "default")
                                        {
                                            tbl_sasQuotation_Detail DoItem = tbl_sasQuotation_Detail.Select(int.Parse(sLineNo), sQuotationCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                            if (chkUnitPricing.Checked)
                                                DoItem.QtySettle_PInvoice = DoItem.QtySettle_PInvoice + dQuantity;
                                            else
                                                DoItem.WeightSettle_PInvoice = DoItem.WeightSettle_PInvoice + dWeight;
                                            DoItem.Update();
                                            // clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(sDeliveryOrderCode, chkUnitPricing);
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

                            Attachments.Insert(txtProformaInvoiceID.Text.ToString());

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Invoice " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        #endregion
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
                    tbl_sasProformaInvoice detail = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
                    if (detail != null)
                        FillDetails(detail.ProformaInvoice_ID);
                }
            }
        }
        #endregion

        #region Btn Cancel
        private void frm_sasProformaInvoice_SF_cancelButton_Click(object sender, EventArgs e)
        {
            cancelProformaInvoice();
        }

        #region Cancel ProformaInvoice
        private void cancelProformaInvoice()
        {
            try
            {
                if (txtProformaInvoiceID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_sasProformaInvoice detail = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
                        if (detail != null)
                        {
                            if (!detail.IsLocked)
                            {
                                if (!detail.IsDeleted)
                                {
                                    // if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                    {
                                        DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Invoice : " + detail.ProformaInvoice_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult == DialogResult.Yes)
                                        {
                                            //////Update Other Tables 
                                            #region Update Other Tables
                                            //List<tbl_sasProformaInvoice_Detail> Invdetails = tbl_sasProformaInvoice_Detail.SelectAllByProformaInvoice_ID(txtProformaInvoiceID.Text.Trim());
                                            //foreach (tbl_sasProformaInvoice_Detail Invdetail in Invdetails)
                                            //{
                                            //    if (Invdetail.Item_ID != null)
                                            //    {
                                            //        //////Unsettle Quotation
                                            //        #region Unsettle Quotation
                                            //        if (Invdetail.Quotation_ID != null && Invdetail.Quotation_ID != "default")
                                            //        {
                                            //            tbl_sasQuotation_Detail QuotationItem = tbl_sasQuotation_Detail.Select(Invdetail.Quotation_ID, Invdetail.Item_ID,
                                            //                Invdetail.ItemSubCategory_ID, Invdetail.ItemSubCategory2_ID, Invdetail.ItemSerialNo, Invdetail.ItemSerialNo2);
                                            //            if (!Invdetail.IsWeightCalculation)
                                            //                QuotationItem.QtySettle = (QuotationItem.QtySettle - Invdetail.Qty);
                                            //            else
                                            //                QuotationItem.WeightSettle = (QuotationItem.WeightSettle - Invdetail.Weight);
                                            //            QuotationItem.Update();
                                            //            clsProcessMethods.SetSettle_Quotation(Invdetail.Quotation_ID, chkUnitPricing);
                                            //        }
                                            //        #endregion
                                            //    }
                                            //}
                                            #endregion

                                            detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                            detail.DateDeleted = clsSecurity.getServerDateTime();
                                            detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                            detail.IsDeleted = true;
                                            detail.DateModified = clsSecurity.getServerDateTime();
                                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                            detail.Update();

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            ClearFields();
                                        }
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

        #endregion

        #region Btn Print
        private void frm_sasProformaInvoice_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasProformaInvoice_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_sasProformaInvoice_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasProformaInvoice_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasProformaInvoice_SF_History_Click(object sender, EventArgs e)
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
                        //add order ref detail
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //add Branch detail
                        if (detail.Branch_ID != "default")
                        {
                            txtBranch.Tag = detail.Branch_ID;
                            txtBranch.Text = clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID));
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

        #region Btn Add Inquiry
        private void btnAddInquiry_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInquiryCode.Tag != null && txtInquiryCode.Tag.ToString().Length > 0)
                {
                    tbl_sasInquiry detail = tbl_sasInquiry.Select(txtInquiryCode.Tag.ToString());
                    if (detail != null)
                    {
                        //add order ref detail
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //add Branch detail
                        if (detail.Branch_ID != "default")
                        {
                            txtBranch.Tag = detail.Branch_ID;
                            txtBranch.Text = clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID));
                        }

                        //add item details
                        RefreshGridByInquiryID(detail.Inquiry_ID);
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

        #region Btn Add Job
        private void btnAddJobCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
                {
                    //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtJobCode.Tag.ToString());
                    //if (detail != null)
                    //{
                    //    //add order ref detail
                    //    glbOrderRefNo = detail.OrderRefNo_ID;

                    //    RefreshGridByJobIDID(detail.ProductionJob_ID);
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
                        //frm.MdiParent = this.MdiParent;
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

        #region Btn Option
        private void btnOption_Click(object sender, EventArgs e)
        {
            frmOption op = new frmOption();
            op.ShowDialog();

            if (frmOption.bEMail)
            {
                sendEmail();
            }
            else if (frmOption.bSMS)
            {

            }
            else if (frmOption.bCancel)
            {
                cancelProformaInvoice();
            }
            else if (frmOption.bPrint)
            {

            }
            else
            {

            }
        }
        #endregion

        #region Btn Temp
        private void frm_sasProformaInvoice_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtProformaInvoiceID.TextLength > 0 && txtProformaInvoiceID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProformaInvoiceID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);

                txtProformaInvoiceID.Tag = null;
                dtpInvoiceDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtProformaInvoiceID.Text = "<Auto Generate>";
                else
                    txtProformaInvoiceID.Clear();
                if (txtProformaInvoiceID.Enabled)
                {
                    txtProformaInvoiceID.SelectAll();
                    txtProformaInvoiceID.Focus();
                }

                ucSasProcessFlow.ClearFlow();
                Attachments.Clear();
            }
        }

        #endregion

        #region Btn Branch
        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
            {
                if (txtBranch.Tag.ToString() != "default")
                {
                    // frmSetCustomerBranch frm = new frmSetCustomerBranch();
                    int iBranchCode = int.Parse(txtBranch.Tag.ToString());
                    //frm.glbBranchCode = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                    //  frm.glbBranchCode = txtBranch.Tag.ToString();
                    //  frm.glbBranchName = txtBranch.Text.Trim();
                    //  frm.Show();
                }
            }
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            //price
            if (clsConfig.bEnableGridLock_Price_ProformaInvoice)
                dgvDetail.Columns["UnitPrice"].ReadOnly = true;
            else
                dgvDetail.Columns["UnitPrice"].ReadOnly = false;
            //qty
            if (clsConfig.bEnableGridLock_Quantity_ProformaInvoice)
                dgvDetail.Columns["Quantity"].ReadOnly = true;
            else
                dgvDetail.Columns["Quantity"].ReadOnly = false;


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
            //set the flag and enble the id
            IsUpdate = false;
            x2.Enabled = true;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProformaInvoiceID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);

            txtProformaInvoiceID.Tag = null;
            txtCustomerID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtQuotationID.Tag = null;
            txtInquiryCode.Tag = null;
            txtJobCode.Tag = null;
            txtBranch.Tag = null;
            txtAccNo.Tag = null;
            txtPaymentMode.Tag = null;

            txtCustomerID.Clear();
            txtSalesExecutiveID.Clear();
            txtQuotationID.Clear();
            txtInquiryCode.Clear();
            txtJobCode.Clear();
            dtpDueDate.Value = clsSecurity.getServerDateTime().AddDays(30);
            txtPaymentMode.Clear();
            txtPaymentTerms.Clear();
            txtCreditPeriod.Clear();
            txtRemark.Clear();
            glbOrderRefNo = "";
            dtpInvoiceDate.Value = clsSecurity.getServerDateTime();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            txtBranch.Clear();
            txtAccNo.Clear();

            txtDiscount.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtSubTotal.Text = "0.00";
            txtVat.Text = "0.00";

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            bHasApproved = false;
            bHasChecked = false;
            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;
            chkDiscount.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;
            chkFreeOrder.Checked = false;
            chkSettings2.Checked = true;

            dtpInvoiceDate.Enabled = !clsConfig.bLock_TransactionDate_SAS;
            userDetailsColorChanges();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtProformaInvoiceID.Text = "<Auto Generate>";
            else
                txtProformaInvoiceID.Clear();
            if (txtProformaInvoiceID.Enabled)
            {
                txtProformaInvoiceID.SelectAll();
                txtProformaInvoiceID.Focus();
            }

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

                List<tbl_sasProformaInvoice_Detail> details = tbl_sasProformaInvoice_Detail.SelectAllByProformaInvoice_ID(sInvoiceID);
                foreach (tbl_sasProformaInvoice_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.Quotation_ID, detail.Job_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount,
                            detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
                //dgvDetail.Rows.Clear();
                List<tbl_sasCustomerOrder_Detail> details = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID);
                foreach (tbl_sasCustomerOrder_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle_DeliveryOrder > 0 || detail.WeightSettle_DeliveryOrder > 0)
                            bHasSettledBefore = true;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.Quotation_ID, clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID),
                            item.Uom_ID, detail.UnitPrice, 0, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty,
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
        private void RefreshGridByJobIDID(string sJobID)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                string sCustomerID = txtCustomerID.Tag != null ? txtCustomerID.Tag.ToString().Trim() : "";
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sJobID);
                //if (detail != null)
                //{
                //    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (item != null)
                //    {
                //        dgvDetail.Rows.Add();
                //        iRow = dgvDetail.Rows.Count - 1;
                //        decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(detail.Item_ID, "default", "default", "0", "0", sCustomerID);
                //        decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(detail.Item_ID);
                //        decimal dAmount = dUnitPrice * detail.Weight;
                //        bool bHasSettledBefore = false;

                //        var MaxID = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                //        Fill_Datagrid(iRow, MaxID + 1, detail.Item_ID, "default", detail.ProductionJob_ID, detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0,
                //            dAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, "default", "default", "0", "0", item.Description, bHasSettledBefore);

                //        CalcualteSubTotal();
                //        CalculateTaxesAndGrandTotal();
                //    }
                //}
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
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotaion);
                foreach (tbl_sasQuotation_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle_PInvoice > 0 || detail.WeightSettle_PInvoice > 0)
                            bHasSettledBefore = true;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.Quotation_ID, "default",
                            item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_PInvoice), (detail.Qty - detail.QtySettle_PInvoice),
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
        private void RefreshGridByInquiryID(string sInquiryID)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_sasInquiry_Detail> details = tbl_sasInquiry_Detail.SelectAllByInquiry_ID(sInquiryID);
                foreach (tbl_sasInquiry_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0)
                            bHasSettledBefore = true;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, "default", "default",
                            item.Uom_ID, detail.UnitPrice, 0, false, 0, 0, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty,
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
                //dgvDetail.Rows.Clear();
                List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrder);
                foreach (tbl_sasDeliveryOrder_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0)
                            bHasSettledBefore = true;
                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.Quotation_ID, detail.Job_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount,
                            detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle), (detail.Qty - detail.QtySettle),
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_sasProformaInvoice detail = tbl_sasProformaInvoice.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtProformaInvoiceID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtInquiryCode.Tag = detail.Inquiry_ID;
                        txtJobCode.Tag = detail.Job_ID;
                        txtProformaInvoiceID.Tag = detail.ProformaInvoice_ID;

                        //fill Branch detials
                        if (detail.Branch_ID != "default")
                        {
                            txtBranch.Tag = detail.Branch_ID;
                            int iBranchCode = int.Parse(detail.Branch_ID);
                            txtBranch.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                        }

                        if (detail.AccountNumber != "default")
                        {
                            txtAccNo.Text = detail.AccountNumber;
                            txtAccNo.Tag = detail.AccountNumber;
                        }
                        else
                            txtAccNo.Text = "-";

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }
                        txtInquiryCode.Text = clsCommon.GetForeignKeyValue(detail.Inquiry_ID);
                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));

                        txtProformaInvoiceID.Text = detail.ProformaInvoice_ID;
                        txtRemark.Text = detail.Remark;
                        dtpInvoiceDate.Value = detail.ProformaInvoiceDate;
                        dtpDueDate.Value = detail.PaymentDueDate;

                        txtPaymentMode.Text = clsGenaralName.getName_PaymentMethod(detail.PaymentMode);
                        txtPaymentMode.Tag = detail.PaymentMode;

                        txtPaymentTerms.Text = detail.PaymentTerms;
                        txtCreditPeriod.Text = detail.CreditPeriod;
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkSettings2.Checked = false;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        //Tax Details
                        if (detail.DiscountTotal > 0)
                        {
                            chkDiscount.Checked = true;
                            txtDiscount.Tag = detail.DiscountTotal;
                            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberNoDecimal(detail.DiscountPercentage);
                        }
                        else
                            chkDiscount.Checked = false;
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

                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);

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
                        RefreshGrid(detail.ProformaInvoice_ID);
                        //  FillDetailsCustomer(detail.Customer_ID);
                        //clsHelpMethods_Local.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                        //       txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);

                        ucSasProcessFlow.SetProcessFlowByProformaInvoice(detail.ProformaInvoice_ID);

                        //Asign tax values after all calculation
                        txtSubTotal.Tag = detail.SubTotal;
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                        txtDiscount.Tag = detail.DiscountTotal;
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                        txtNBT.Tag = detail.NbtTotal;
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                        txtVat.Tag = detail.VatTotal;
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);
                        txtOtherTax.Tag = detail.OtherTaxTotal;
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);

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
                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = clsGenaralName.getName_Customer(customer.Customer_ID);
                    txtSalesExecutiveID.Text = clsGenaralName.getName_SalesRep(customer.SalesRep_ID);

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

        #region Fill Tax Detail By Inquiry
        private void FillTaxDetailByInquiry(string InquiryID)
        {
            try
            {
                tbl_sasInquiry detail = tbl_sasInquiry.Select(InquiryID);
                if (detail != null)
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);

                    if (detail.DiscountTotal > 0)
                        chkDiscount.Checked = true;
                    else
                        chkDiscount.Checked = false;
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

        #region Fill Tax Detail By QuotationID
        private void FillTaxDetailByQuotationID(string sQuotationID)
        {
            try
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(sQuotationID);

                if (detail != null)
                {
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountTotal);
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal);
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtTotal);
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.SubTotal);
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatTotal);


                    if (detail.DiscountTotal > 0)
                        chkDiscount.Checked = true;
                    else
                        chkDiscount.Checked = false;
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
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_EmptyField_AccountNo())
                {
                    if (CheckNumberValidity())
                    {
                        if (CheckItemSettleValidity())
                        {
                            if (clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                            {
                                if (CheckOutstandingValidity())
                                {
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpInvoiceDate.Value.Date))
                                    {
                                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                        {
                                            bIsOk = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return bIsOk;
        }
        private bool CheckValidity_EmptyField_AccountNo()
        {
            bool bStatus = false;

            if (clsConfig.bEnableProformaInvoice_AccountNo)
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtAccNo, "Account No."))
                {
                    bStatus = true;
                }
            }
            else
            {
                bStatus = true;
                if (txtAccNo.Text == "")
                    txtAccNo.Tag = "default";
            }

            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "Customer Name"))
            {
                bStatus = true;
            }

            return bStatus;
        }
        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sItemCode = "", sDoCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
            decimal dQuantity = 0, dWeight = 0;

            if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.Invoice)) && (!IsUpdate))
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

                        // tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (DoDetail != null)
                        {
                            if (chkUnitPricing.Checked)
                            {
                                if (IsUpdate)
                                {
                                    if (DoDetail.Qty < dQuantity)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (DoDetail.Qty < (DoDetail.QtySettle + dQuantity))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity cannot Exceed the Delivery Order Quantity  \n";
                                        rtn = false;
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
        private bool CheckOutstandingValidity()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (clsConfig.bCreditBalanceInvoice_Message) //security 1 - Message
                {
                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bOk;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtInquiryCode);
                clsCommon.ValidateForeignKey(ref txtQuotationID);
                clsCommon.ValidateForeignKey(ref txtJobCode);
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtPaymentMode);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        

        #region Events KeyDown
        private void txtProformaInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ProformaInvoiceID();
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_QuotationID(sender);
            }
        }
        private void txtInquiryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Inquiry(sender);
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

        private void frm_sasCustomerInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
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
            {
                Search_SalesExecutiveID();
            }
        }
        private void txtPaymentMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
            }
        }
        private void txtAccNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.SearchMaster_CompanyAccount(ref txtAccNo, "", "");
            }
        }
        #endregion

        #region Events Double Click
        private void txtProformaInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_ProformaInvoiceID();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            Search_QuotationID(sender);
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
        private void txtInquiryCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Inquiry(sender);
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtAccNo_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.SearchMaster_CompanyAccount(ref txtAccNo, "", "");
        }
        private void txtPaymentMode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPaymentMethod(ref txtPaymentMode);
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
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0.00";
                txtDiscount.Tag = "0";
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
            CalculateTaxesAndGrandTotal();
        }

        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                txtPercentageOtherTax.Enabled = true;
                chkVat_CheckedChanged(chkVat, new EventArgs());
                CalculateTaxesAndGrandTotal();
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtPercentageOtherTax.Text = clsCommon.getPesentageOtherTax().ToString();
                chkVat_CheckedChanged(chkVat, new EventArgs());
                txtOtherTax.Text = "0";
                CalculateTaxesAndGrandTotal();
            }
        }

        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //call cellend events for all records
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
            if (chkSettings2.Checked)
            {
                pnlSetting1.Visible = true;
                pnlSetting1.BringToFront();
                chkSettings2.Image = Digiteq.Properties.Resources.security;
            }
            else
            {
                pnlSetting1.Visible = false;
                pnlSetting1.SendToBack();
                chkSettings2.Image = Digiteq.Properties.Resources.settings;
            }
        }
        #endregion

        #region Events Datagried
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvDetail_CellDoubleClick(sender, e);
            }
        }
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                clsEvent.SalesGrid_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
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


        #region Event Leave
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            // decimal dDiscount = 0;
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
        private void Search_ProformaInvoiceID()
        {
            try
            {
                clsSearch.Search_TransactionPerfomanceInvoice(ref txtProformaInvoiceID, "", false, chkShowSettle.Checked, chkShowSettle.Checked);
                if (txtProformaInvoiceID.Tag != null && txtProformaInvoiceID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtProformaInvoiceID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Inquiry(object objSender)
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionInquiry_Use(ref txtInquiryCode, txtCustomerID.Tag.ToString(), false);
                else
                    clsSearch.Search_TransactionInquiry_Use(ref txtInquiryCode, "", false);
                if (txtInquiryCode.Tag != null)
                {
                    tbl_sasInquiry detail = tbl_sasInquiry.Select(txtInquiryCode.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCustomer(detail.Customer_ID);
                        FillTaxDetailByInquiry(txtInquiryCode.Tag.ToString());
                        btnAddInquiry_Click(objSender, new EventArgs());
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_QuotationID(object objSender)
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    //clsSearch.Search_TransactionQuotationByCustomerID_Use(ref txtInquiryCode, txtCustomerID.Tag.ToString(), hasOrderRefNo, glbOrderRefNo);
                    clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, txtCustomerID.Tag.ToString(), false);
                else
                    clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, "", false);
                if (txtQuotationID.Tag != null)
                {
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCustomer(detail.Customer_ID);
                        FillTaxDetailByQuotationID(txtQuotationID.Tag.ToString());
                        btnAddQuotation_Click(objSender, new EventArgs());
                    }
                }
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
                clsSearch.Search_MasterCustomer(ref txtCustomerID, false);
                if (txtCustomerID.Tag != null && txtCustomerID.TextLength > 0)
                {
                    FillDetailsCustomer(txtCustomerID.Tag.ToString());

                    //Add Branch
                    List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
                    if (Detail.Count > 0)
                        Search_CustomerBranch();
                    else
                    {
                        txtBranch.Clear();
                        txtBranch.Tag = null;
                    }
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
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);

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
                clsSearch.Search_CustomerBranch(ref txtBranch, txtCustomerID.Tag.ToString());
                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.passValue_CustomerBranch(txtCustomerID.Tag.ToString());
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //    txtBranch.Tag = frmSearchMaster.s_SearchID;
                //if (frmSearchMaster.s_SearchText.Length > 0)
                //    txtBranch.Text = frmSearchMaster.s_SearchText;
            }

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
                    decimal dUnitPrice = 0, dWeightPrice = 0, dQty = 0, dWeight = 0;//, dVatAmount = 0
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

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int lineNo, string ItemID, string QuotationID, string JobID, string Uom_ID, decimal UnitPrice, decimal KiloPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled)
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
                            string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                            int iLineNo = lineNo;

                            iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, lineNo);
                            sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                            sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                            sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                            sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                            sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                            if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
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

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["QuotationCode", iRow].Value = QuotationID;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(Uom_ID);
                dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
                dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["Remarks", iRow].Value = Remark;


                dgvDetail["Width", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Width);
                dgvDetail["Height", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Height);
                dgvDetail["Gauge", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gauge);
                dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);// add by thilina

                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                if (isNewItem)
                {
                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                }
                if (isNewItem)
                {
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);
                    dgvDetail["WeightPrice", iRow].Tag = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);
                }

                dgvDetail["Free", iRow].Value = isFreeItem;
                dgvDetail["DiscuntPresentage", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountPresentage);
                dgvDetail["DiscuntPresentage", iRow].Tag = DiscountPresentage;
                dgvDetail["DiscountValue", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountAmount);
                dgvDetail["DiscountValue", iRow].Tag = DiscountAmount;
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(GrossTotal);
                dgvDetail["Amount", iRow].Tag = GrossTotal;

                //dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);
                //dgvDetail["Amount", iRow].Tag = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);
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

        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        #region Send E-Mail
        public void sendEmail()
        {
            //    frmEmail oEmail = new frmEmail();
            //   oEmail.Show();
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            #region New Code
            if (true)
            {
                if (txtProformaInvoiceID.TextLength > 0 && txtProformaInvoiceID.Text != "<Auto Generate>")
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        glb_dtsSasInvoice.dt_sasInvoice.Rows.Clear();
                        glb_dtsSasInvoice.dt_sasInvoice_Detail.Rows.Clear();

                        int count = 0;
                        String sVatPrecentage = "", sDuplicateCopy = "";

                        tbl_sasProformaInvoice Detail = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text);
                        if (Detail != null)
                        {
                            if (!bIsDraft)
                            {
                                if (Detail.PrintCount > 0)
                                    sDuplicateCopy = "Duplicate Copy " + Detail.PrintCount;

                                Detail.PrintCount++;
                                Detail.Update();
                            }

                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(Detail.Customer_ID);
                            if (oCustomer != null)
                            {
                                string sSalesmanID = "", sSalesmanName = "", sOrderRefNo = "";
                                tbl_zOrderRefNo oRef = tbl_zOrderRefNo.Select(Detail.OrderRefNo_ID);
                                if (oRef != null && oRef.OrderRefNo_ID != "default")
                                {
                                    sSalesmanID = oRef.Employee_ID;
                                    sSalesmanName = clsGenaralName.getName_SalesRep(oRef.Employee_ID);
                                    sOrderRefNo = oRef.OrderRefNo;
                                }
                                sVatPrecentage = (Detail.VatTotal == 0) ? "-" : clsFormatter.FormatDecimalPlaces_Quantity(Detail.VatPercentage).ToString() + "%";
                                DateTime dtDoDate = DateTime.MinValue;
                                glb_dtsSasInvoice.dt_sasInvoice.Adddt_sasInvoiceRow(Detail.ProformaInvoice_ID, Detail.ProformaInvoiceDate, Detail.Customer_ID, oCustomer.CustomerName, oCustomer.NbtRegistrationNo, 
                                    "", "", "", "", "", sSalesmanName, "", "", "", Detail.IsDeleted, "", "", Detail.SubTotal, Detail.DiscountPercentage, Detail.DiscountTotal, 0, 0, 0, Detail.VatPercentage, Detail.VatTotal, 0, 0, 
                                    Detail.GrandTotal, "", sOrderRefNo, "", oCustomer.VatRegistrationNo, "", "", "", false, dtDoDate, 0, 0, 0, 0, 0, 0, "", "", "", "", Detail.IsSVAT, Detail.IsVAT, Detail.PaymentTerms, Detail.Remark, 
                                    Detail.Currency_ID, clsGenaralName.getName_CurrencyCode(Detail.Currency_ID), Detail.PaymentDueDate);
                            }
                        }
                        //fill invoice details
                        foreach (tbl_sasProformaInvoice_Detail Detail1 in tbl_sasProformaInvoice_Detail.SelectAllByProformaInvoice_ID(Detail.ProformaInvoice_ID).OrderBy(p => p.Line_No).ToList())
                        {
                            tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(Detail1.Item_ID);
                            tbl_zUom oUom = tbl_zUom.Select(Detail1.Uom_ID);

                            if (oUom != null && oItmaster != null)
                            {
                                count++;
                                glb_dtsSasInvoice.dt_sasInvoice_Detail.Adddt_sasInvoice_DetailRow(Detail1.ProformaInvoice_ID, Detail1.Item_ID,
                                    oItmaster.Brand_ID, Detail1.UnitPrice, Detail1.Qty, oItmaster.ItemName, Detail1.Remark, oUom.UomCode, count, "", 0, Detail1.DiscountAmount, Detail1.TatalAmount, false, 0, "");
                            }
                        }

                        print("\\reports\\SAS\\NotePrinting\\rpt_sasProformaInvoice.rpt", " Sales Invoice ", glb_dtsSasInvoice, sDuplicateCopy, bIsDraft, Detail.IsDeleted);
                    }
                    catch (Exception)
                    {
                        glb_dtsSasInvoice.dt_sasInvoice.Rows.Clear();
                        glb_dtsSasInvoice.dt_sasInvoice_Detail.Rows.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }
            #endregion

            #region Old Code
            //else
            //{
            //    try
            //    {
            //        if (txtProformaInvoiceID.TextLength > 0 && txtProformaInvoiceID.Text != "<Auto Generate>")
            //        {
            //            //update receipt
            //            Cursor = Cursors.WaitCursor;
            //            string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
            //            bool bOkToPrint = false, bApprovalDone = false, bCheckingDone = false;
            //            tbl_sasProformaInvoice oOrder = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
            //            if (oOrder != null)
            //            {
            //                #region Validate Approval
            //                if (clsConfig.bApprovalNeedToPrintInvoice)
            //                {
            //                    if (oOrder.IsApproved)
            //                        bApprovalDone = true;
            //                    else
            //                        MessageBox.Show("Please Approve the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //                else
            //                    bApprovalDone = true;
            //                #endregion

            //                #region Validate Checking
            //                if (clsConfig.bCheckingNeedToPrintInvoice)
            //                {
            //                    if (oOrder.IsChecked)
            //                        bCheckingDone = true;
            //                    else
            //                        MessageBox.Show("Please Check the Invoice Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //                else
            //                    bCheckingDone = true;
            //                #endregion

            //                if (bApprovalDone && bCheckingDone)
            //                {
            //                    if (oOrder.PrintCount > 0) // if already printed before
            //                    {
            //                        sDuplicateCopy = "Duplicate Copy";
            //                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
            //                        {
            //                            bOkToPrint = true;
            //                            if (chkPrintOriginal.Checked)
            //                                sDuplicateCopy = "";
            //                        }
            //                        else
            //                        {
            //                            frmSetApproved login = new frmSetApproved();
            //                            login.iFormID = iFormID;
            //                            login.ShowDialog();
            //                            if (frmSetApproved.bChecked)
            //                            {
            //                                bOkToPrint = true;
            //                                if (chkPrintOriginal.Checked)
            //                                    sDuplicateCopy = "";
            //                            }
            //                        }
            //                    }
            //                    else
            //                        bOkToPrint = true;

            //                    sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ] [ " + oOrder.DateCreate.ToShortDateString() + " ]";
            //                    if (oOrder.CheckedUser_ID != "default")
            //                        sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ] [ " + oOrder.DateChecked.ToShortDateString() + " ]";
            //                    if (oOrder.ApprovedUser_ID != "default")
            //                        sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ] [ " + oOrder.DateApproved.ToShortDateString() + " ]";

            //                    #region Print The Doc
            //                    if (bOkToPrint && bApprovalDone)
            //                    {
            //                        oOrder.PrintCount++;
            //                        oOrder.DatePrinted = clsSecurity.getServerDateTime();
            //                        oOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
            //                        oOrder.PrintedUser_ID = clsSecurity.UserIDLoged;

            //                        oOrder.Update();

            //                        string s_Path = "", sReportTitle = "TAX INVOICE", sFormula = "";
            //                        if (txtProformaInvoiceID.TextLength > 0)
            //                            sFormula = "{vw_rpt_sasInvoice.invoice_ID} = '" + txtProformaInvoiceID.Text.Trim() + "'";
            //                        ReportDocument RD = new ReportDocument();
            //                        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
            //                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WD.rpt";
            //                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WD.rpt";
            //                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WOD.rpt";
            //                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WSC.rpt";
            //                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WSC.rpt";
            //                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WR.rpt";
            //                        else
            //                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvoice_WSC.rpt";

            //                        frm_ReportViewer viewer = new frm_ReportViewer();
            //                        viewer.crystalReportViewer1.ShowExportButton = false;
            //                        RD.Load(s_Path);
            //                        clsSecurity.LogonServer(ref RD);
            //                        RD.Refresh();

            //                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            //                        {
            //                            RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
            //                            RD.DataDefinition.FormulaFields["Outstanding"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_All(txtCustomerID.Tag.ToString())));
            //                            RD.DataDefinition.FormulaFields["Cheques-In-Hand"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerChequesInHand(txtCustomerID.Tag.ToString())));
            //                        }

            //                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
            //                        {
            //                            RD.DataDefinition.FormulaFields["company VAT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
            //                            RD.DataDefinition.FormulaFields["company NBT"].Text = clsCommon.fncsetstring(clsCommon.getCompanyNBT());
            //                            RD.DataDefinition.FormulaFields["CompanyAddress3"].Text = "'Email :'" + clsCommon.fncsetstring(clsCommon.getCompanyEmail()) + "'  WEB :'" + clsCommon.fncsetstring(clsCommon.getCompanyWeb());
            //                        }

            //                        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
            //                        RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
            //                        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
            //                        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
            //                        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
            //                        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
            //                        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
            //                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
            //                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
            //                        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
            //                        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
            //                        RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(oOrder.Customer_ID));

            //                        if (clsConfig.bDirectPrint_NP_ProforemaInvoice) //Direct Print
            //                        {
            //                            RD.DataDefinition.RecordSelectionFormula = sFormula;
            //                            clsHelpMethods.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_ProformaInvoice), ref RD);
            //                            RD.PrintToPrinter(1, false, 0, 0);

            //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DucumentPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                        else //View And Print
            //                        {
            //                            viewer.crystalReportViewer1.ReportSource = RD;
            //                            viewer.crystalReportViewer1.SelectionFormula = sFormula;
            //                            viewer.crystalReportViewer1.Visible = true;
            //                            viewer.crystalReportViewer1.DisplayToolbar = true;
            //                            viewer.crystalReportViewer1.CloseView(false);
            //                            viewer.WindowState = FormWindowState.Maximized;
            //                            viewer.ShowDialog();
            //                        }

            //                        RD.Close();
            //                        RD.Dispose();
            //                    }
            //                    #endregion
            //                }
            //            }
            //        }
            //        else
            //            MessageBox.Show("Please Select the Invoice To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    catch (Exception ex)
            //    {
            //        SEACCException.Show(ex);
            //        clsValidate.WriteErrorLog("", iFormID,ex);
            //    }
            //    finally
            //    {
            //        Cursor = Cursors.Default;
            //    }
            //} 
            #endregion
        }
        #endregion

        #region Print report
        private void print(string path, string sReportTitle, DataSet ojbDataSet, string sDuplicateCopy, bool bIsDraft, bool bIsCancelled)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "";// sHeaderTitle = "Standed Reports", sReportFilter = "";
                ReportDocument objRpt = new ReportDocument();

                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(ojbDataSet); //(glbDtsBills);

                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);

                objRpt.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                objRpt.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";
                objRpt.DataDefinition.FormulaFields["IsDraft"].Text = bIsCancelled ? "CANCELLED" : "";

                if (bIsDraft)
                {
                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                    {
                        objRpt.DataDefinition.FormulaFields["CompanyName"].Text = "";
                        objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                        objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                    }
                }


                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
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
        #endregion

        private void frm_sasProformaInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
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
                        if (txtProformaInvoiceID.Text != null && txtProformaInvoiceID.TextLength > 0 && txtProformaInvoiceID.Text != "<Auto Generate>")
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

                                        tbl_sasProformaInvoice objDO = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
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
                        if (txtProformaInvoiceID.Text != null && txtProformaInvoiceID.TextLength > 0 && txtProformaInvoiceID.Text != "<Auto Generate>")
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

                                        tbl_sasProformaInvoice objDO = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text.Trim());
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
                if (txtProformaInvoiceID.Text != "" || txtProformaInvoiceID.Text != "<Auto Generate>")
                {
                    tbl_sasProformaInvoice detail = tbl_sasProformaInvoice.Select(txtProformaInvoiceID.Text);
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
        //        this.btnApproved.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnChecked.ForeColor = System.Drawing.SystemColors.ControlText;
        //        this.btnApproved.BackColor = System.Drawing.Color.LightGray;
        //        this.btnChecked.BackColor = System.Drawing.Color.LightGray;
        //        btnApproved.Enabled = true;
        //        btnChecked.Enabled = true;
        //    }
        //}


        #endregion

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

#region Events Mouseclick
//private void txtFlowInquiry_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Inquiry(sender, e, glbOrderRefNo);
//}

//private void txtFlowQuotaion_MouseClick(object sender, MouseEventArgs e)
//{

//}

//private void txtFlowSalesReturned_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
//}
//private void txtFlowCustomerOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowProductionJob_MouseClick(object sender, MouseEventArgs e)
//{

//}

//private void txtFlowDeliveryOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_DeliveryOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowInvoice_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Invoice(sender, e, glbOrderRefNo);
//}

//private void txtFlowReceipt_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Receipt(sender, e, glbOrderRefNo);
//}
#endregion