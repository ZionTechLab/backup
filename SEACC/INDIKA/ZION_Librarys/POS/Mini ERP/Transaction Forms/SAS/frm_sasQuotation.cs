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
using Digiteq_Logic;
using Digiteq.DataSets;
using Digiteq.DataSets.SAS;

namespace Digiteq
{
    public partial class frm_sasQuotation : SEACC_Form
    {
        #region Variables

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbQuotationID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_sasQuotation glb_dts_sasQuotation = new dts_sasQuotation();

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;

        bool bHasPermissionToFreeIssures = false;
        #endregion

        #region Form Load
        public frm_sasQuotation(FormName _enmForm)
        {
            //sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusQuotation);
            //iFormID = clsSecurity.getFormID(FormName.CusQuotation);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //format Form
            //clsFormatter.setFormatForm(this, "Customer Quotation [QUOT]", 2, iFormID);
            //clsFormatter.FormatProcessFlow(txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder, txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
            userDetailsColorChanges();

            dgvDetail.Columns["ItemName"].HeaderText = "Item Name";
            dgvDetail.Columns["Remarks"].HeaderText = "Item Description";
            dgvDetail.Columns["UnitPrice"].ReadOnly = false;

            //if the order generated from a inquiry
            if (glbInquiryID.Length > 0)
            {
                tbl_sasInquiry detail = tbl_sasInquiry.Select(glbInquiryID);
                if (detail != null)
                {
                    txtInquiryCode.Tag = detail.Inquiry_ID;
                    btnAddInquiry_Click(sender, new EventArgs());
                }
            }
            else if (glbQuotationID.Length > 0)
            {
                FillDetails(glbQuotationID);
            }

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
        }
        #endregion

        #region Button Actions
        #region Btn New
        private void frm_sasQuotation_SF_newButton_Click(object sender, EventArgs e)
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
                if (dgvDetail.Rows.Count > 0)
                    cmbItemPrice.Enabled = false;
                else
                    cmbItemPrice.Enabled = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void frm_sasQuotation_SF_saveButton_Click(object sender, EventArgs e)
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
                        tbl_sasQuotation oldRecord = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount) //&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                            )
                        {
                            if (ValidateForDependancies(oldRecord.Quotation_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtQuotationID.Text))
                                        {

                                            //Quotation Detail      
                                            //-----------------------------

                                            #region Update Old Quotaion items

                                            List<tbl_sasQuotation_Detail> oldCoDetails =
                                                tbl_sasQuotation_Detail.SelectAllByQuotation_ID(
                                                    txtQuotationID.Text.Trim());
                                            foreach (tbl_sasQuotation_Detail oldCoDetail in oldCoDetails)
                                            {
                                                decimal dQuantity = 0, dWeight = 0;
                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                        row.Index, decimal.Parse("0.00"));

                                                    #region Quotation update

                                                    #region Update Inquiry

                                                    if (oldCoDetail.Inquiry_ID != "default")
                                                    {
                                                        tbl_sasInquiry_Detail inqItem =
                                                            tbl_sasInquiry_Detail.Select(oldCoDetail.Inquiry_ID,
                                                                oldCoDetail.Item_ID, oldCoDetail.ItemSubCategory_ID,
                                                                oldCoDetail.ItemSubCategory2_ID,
                                                                oldCoDetail.ItemSerialNo, oldCoDetail.ItemSerialNo);
                                                        if (inqItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked)
                                                                inqItem.QtySettle =
                                                                    (inqItem.QtySettle - oldCoDetail.Qty) + dQuantity;
                                                            else
                                                                inqItem.WeightSettle =
                                                                    (inqItem.WeightSettle - oldCoDetail.Weight) +
                                                                    dWeight;
                                                            inqItem.Update();
                                                            clsProcessMethods.SetSettle_Inquiry(oldCoDetail.Inquiry_ID,
                                                                chkUnitPricing);
                                                        }
                                                    }

                                                    #endregion
                                                }

                                                oldCoDetail.Delete();

                                                #endregion

                                                #region Old

                                                //string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sUOM = "", sLineNo = "";
                                                //decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0;
                                                //bool bHasItemInDB = false;

                                                //foreach (DataGridViewRow row in dgvDetail.Rows)
                                                //{

                                                //    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                                //    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                //    sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                                                //    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                                //    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                //    sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                                //    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                //    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                //    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                //    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                //    dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                //    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                //    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                //    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                //    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                //    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");


                                                //    if (oldCoDetail.Quotation_ID == txtQuotationID.Text.Trim() && oldCoDetail.Item_ID == sItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                                //    oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                                                //    {
                                                //        bHasItemInDB = true;
                                                //        dgvDetail.Rows.RemoveAt(row.Index);
                                                //        break; //database contain this item
                                                //    }

                                                //}

                                                //if (bHasItemInDB)
                                                //{
                                                //    //////Update Inquiry 
                                                //    // Don't put this region, under the old recode update statment
                                                //    #region Update Inquiry
                                                //    if (sInquiryCode != "default")
                                                //    {
                                                //        tbl_sasInquiry_Detail inqItem = tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                //        if (inqItem != null)
                                                //        {
                                                //            if (chkUnitPricing.Checked)
                                                //                inqItem.QtySettle = (inqItem.QtySettle - oldCoDetail.Qty) + dQuantity;
                                                //            else
                                                //                inqItem.WeightSettle = (inqItem.WeightSettle - oldCoDetail.Weight) + dWeight;
                                                //            inqItem.Update();
                                                //            clsProcessMethods.SetSettle_Inquiry(sInquiryCode, chkUnitPricing);
                                                //        }
                                                //    }
                                                //    #endregion

                                                //    oldCoDetail.Line_No = int.Parse(sLineNo);
                                                //    oldCoDetail.Item_ID = sItemCode;
                                                //    oldCoDetail.Inquiry_ID = sInquiryCode;
                                                //    oldCoDetail.Quotation_ID = sQuotationCode;
                                                //    oldCoDetail.Job_ID = sJobCode;
                                                //    oldCoDetail.Qty = dQuantity;
                                                //    oldCoDetail.Weight = dWeight;
                                                //    oldCoDetail.UnitPrice = dUnitPrice;
                                                //    oldCoDetail.WeightPrice = dWeightPrice;
                                                //    oldCoDetail.TatalAmount = dAmount;
                                                //    oldCoDetail.Remark = sRemarks;
                                                //    oldCoDetail.Uom_ID = sUOM;
                                                //    oldCoDetail.Update();
                                                //}
                                                //else
                                                //{
                                                //    oldCoDetail.Delete();
                                                //}

                                                #endregion

                                            }

                                            #endregion

                                            #region insert Newly Added Data

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                string sItemCode = "",
                                                    sInquiryCode = "",
                                                    sQuotationCode = "",
                                                    sJobCode = "",
                                                    sRemarks = "",
                                                    sUOM = "",
                                                    sItemSubCategoryID = "",
                                                    sItemSubCategoryID2 = "",
                                                    sItemSerialNo = "",
                                                    sItemSerialNo2 = "",
                                                    sLineNo = "";
                                                decimal dUnitPrice = 0,
                                                    dQuantity = 0,
                                                    dWeight = 0,
                                                    dAmount = 0,
                                                    dDiscountPresentage = 0,
                                                    dDiscountValue = 0,
                                                    dWeightPrice = 0,
                                                    dRecommendedUnitPrice = 0,
                                                    dRecommendedWeightPrice = 0,
                                                    dRecommendedAmount = 0;
                                                bool bIsFreeIssue = false;

                                                sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index,
                                                    "0");
                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                    row.Index, "");
                                                sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode",
                                                    row.Index, "default");
                                                sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,
                                                    "QuotationCode", row.Index, "default");
                                                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                    row.Index, "default");
                                                sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index,
                                                    "default");
                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
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

                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice",
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
                                                    tbl_sasQuotation_Detail items = new tbl_sasQuotation_Detail(
                                                        int.Parse(sLineNo), txtQuotationID.Text.Trim(), sItemCode,
                                                        sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                        sItemSerialNo2, sInquiryCode, sJobCode, dQuantity, 0, 0, 0,
                                                        dWeight, 0, 0, 0, dUnitPrice, dWeightPrice, 0, 0, bIsFreeIssue,
                                                        dDiscountPresentage, dDiscountValue, dAmount,
                                                        dRecommendedUnitPrice, dRecommendedWeightPrice,
                                                        dRecommendedAmount, sRemarks, sUOM);
                                                    items.Insert();

                                                    //////Update Inquiry 

                                                    #region Update Inquiry

                                                    if (sInquiryCode != "default")
                                                    {
                                                        tbl_sasInquiry_Detail inqItem =
                                                            tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode,
                                                                sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                                sItemSerialNo2);
                                                        if (chkUnitPricing.Checked)
                                                            inqItem.QtySettle = inqItem.QtySettle + dQuantity;
                                                        else
                                                            inqItem.WeightSettle = inqItem.WeightSettle + dWeight;
                                                        inqItem.Update();
                                                        clsProcessMethods.SetSettle_Inquiry(sInquiryCode,
                                                            chkUnitPricing);
                                                    }

                                                    #endregion
                                                }
                                            }

                                            #endregion

                                            //-----------------------------
                                            //Quotation Header

                                            #region Update Quotation Header

                                            tbl_sasQuotation detail = new tbl_sasQuotation(txtQuotationID.Text.Trim(),
                                                dtpQuotationDate.Value, txtRemark.Text.Trim(),
                                                txtValidityPeriod.Text.Trim(), txtDeliveryPeriod.Text.Trim(),
                                                txtPaymentTerms.Text.Trim(), txtQuotaionSubject.Text.Trim(),
                                                int.Parse(txtAttentionTo.Tag.ToString()), txtAttentionTo.Text.Trim(),
                                                oldRecord.OrderRefNo_ID, txtCustomerID.Tag.ToString(),
                                                txtInquiryCode.Tag.ToString(),
                                                txtJobCode.Tag.ToString(), txtQuotationType.Tag.ToString(),
                                                txtSalesExecutiveID.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                                                oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                                oldRecord.FinancialYear_ID, oldRecord.CompanyID,
                                                oldRecord.CompanyBranch_ID, decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                                decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                decimal.Parse(txtPercentageVat.Text.Trim()),
                                                decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                decimal.Parse(txtSubTotal.Text.Trim()),
                                                decimal.Parse(txtDiscount.Text.Trim()),
                                                decimal.Parse(txtNBT.Text.Trim()), decimal.Parse(txtVat.Text.Trim()),
                                                decimal.Parse(txtOtherTax.Text.Trim()),
                                                decimal.Parse(txtGrandTotal.Text.Trim()),
                                                decimal.Parse(txtSubTotal_Rec.Text.Trim()),
                                                decimal.Parse(txtGrandTotal_Rec.Text.Trim()),
                                                oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                oldRecord.DateCreate,
                                                clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate,
                                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                                                oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsDoneProductionJob,
                                                oldRecord.IsSeattled, !chkUnitPricing.Checked, oldRecord.PrintCount,
                                                chkReverseCalculation.Checked,
                                                chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat),
                                                clsHelpMethods.isTaxActiveNote(txtOtherTax), txtBranch.Tag.ToString(),
                                                txtCustomerAddress.Text.Trim(), txtQuotationTerms.Text,
                                                lblAccountNo.Tag.ToString(),
                                                ((ComboBoxItem)cmbItemPrice.SelectedItem).Value);
                                            detail.Update();

                                            #endregion

                                            //Attachments.Insert(iFormID, oldRecord.Quotation_ID);
                                            //Attachments.Remove(iFormID, oldRecord.Quotation_ID);

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
                        #endregion
                    }
                    else  //insert records
                    {
                        #region Insert
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtQuotationID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        //create order ref number
                        if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                        {
                            glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                            tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-", txtRouteID.Tag.ToString(), txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                            orf.Insert();
                        }

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtQuotationID.Text)) //if (txtQuotationID.TextLength > 0)
                        {
                            //Quotation Header
                            #region Header
                            tbl_sasQuotation detail = new tbl_sasQuotation(txtQuotationID.Text.Trim(), dtpQuotationDate.Value, txtRemark.Text.Trim(),
                                                    txtValidityPeriod.Text.Trim(), txtDeliveryPeriod.Text.Trim(), txtPaymentTerms.Text.Trim(), txtQuotaionSubject.Text.Trim(), int.Parse(txtAttentionTo.Tag.ToString()), txtAttentionTo.Text.Trim(),
                                                    glbOrderRefNo, txtCustomerID.Tag.ToString(), txtInquiryCode.Tag.ToString(), txtJobCode.Tag.ToString(), txtQuotationType.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                                                    "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID, clsSecurity.BranchID, decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                    decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                                                    decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Text.Trim()), decimal.Parse(txtDiscount.Text.Trim()),
                                                    decimal.Parse(txtNBT.Text.Trim()), decimal.Parse(txtVat.Text.Trim()), decimal.Parse(txtOtherTax.Text.Trim()), decimal.Parse(txtGrandTotal.Text.Trim()),
                                                    decimal.Parse(txtSubTotal_Rec.Text.Trim()), decimal.Parse(txtGrandTotal_Rec.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                                    clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(),
                                                    clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, false, false,
                                                    !chkUnitPricing.Checked, 0, chkReverseCalculation.Checked, chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), txtBranch.Tag.ToString(), txtCustomerAddress.Text.Trim(), txtQuotationTerms.Text, lblAccountNo.Tag.ToString(), ((ComboBoxItem)cmbItemPrice.SelectedItem).Value);
                            detail.Insert();
                            #endregion

                            //Quotation Detail                                
                            #region Details
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sUOM = "", sLineNo = "";
                                    decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0, dDiscountPresentage = 0, dDiscountValue = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0;
                                    bool bIsFreeIssue = false;

                                    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                    sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                                    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                    sUOM = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");
                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));

                                    bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                    dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                    dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
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
                                        //clsHelpMethods.GetMaxzimumLineNo_Quotation(txtQuotationID.Text.Trim())
                                        tbl_sasQuotation_Detail items = new tbl_sasQuotation_Detail(int.Parse(sLineNo), txtQuotationID.Text.Trim(), sItemCode,
                                                      sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, sInquiryCode, sJobCode, dQuantity, 0, 0, 0,
                                                      dWeight, 0, 0, 0, dUnitPrice, dWeightPrice, 0, 0, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, sUOM);
                                        items.Insert();
                                        //////Update Inquiry 
                                        #region Update Inquiry
                                        if (sInquiryCode != "default")
                                        {
                                            tbl_sasInquiry_Detail inqItem = tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                            if (inqItem != null)
                                            {
                                                if (chkUnitPricing.Checked)
                                                    inqItem.QtySettle = inqItem.QtySettle + dQuantity;
                                                else
                                                    inqItem.WeightSettle = inqItem.WeightSettle + dWeight;
                                                inqItem.Update();
                                                clsProcessMethods.SetSettle_Inquiry(sInquiryCode, chkUnitPricing);
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

                            Attachments.Insert(txtQuotationID.Text.ToString());
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Quotation " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_sasQuotation oldRecord = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
                    if (oldRecord != null)
                        FillDetails(txtQuotationID.Text.Trim());
                }

            }
        }
        #endregion

        #region Btn Cancel
        private void frm_sasQuotation_SF_cancelButton_Click(object sender, EventArgs e)
        {
            cancelQuotation();
        }
        #endregion

        #region Btn Print
        private void frm_sasQuotation_SF_printButton_Click(object sender, EventArgs e)
        {
            tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
            if (detail != null && detail.IsApproved)
            {
                Print(false);
            }
            else
            {
                MessageBox.Show("Please Approve the Quotation Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Draft
        private void frm_sasQuotation_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Checked, Approved and Cancel
        private void frm_sasQuotation_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasQuotation_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasQuotation_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion 
        #endregion

        #region Btn add Item
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
                        {
                            MessageBox.Show("Please Select The Customer Before Add Items", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;
                        FillDetailsCustomer(detail.Customer_ID);

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

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByInquiry(glbInquiryID);

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

        #region Btn Proforma Invoice
        private void btnCreateProformaInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                    if (detail != null && detail.Quotation_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledQuotation)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Quotation Before Creating a Proforma Invoice(s)";
                            }
                        }
                        if (clsConfig.bSettleEnabledQuotation)
                        {
                            if (detail.IsSeattled)
                            {
                                MessageBox.Show("ALREADY PI GENERATED!! \n\n But, You may Generate More Proforma Invoice(s) to this General Quotation.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (bAllowDetail)
                        {
                            frm_sasProformaInvoice frm = new frm_sasProformaInvoice(FormName.CusProformaInvoice);
                            frm.glbQuotationID = detail.Quotation_ID;
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

        #region Btn Customer Viewer
        private void btnCustomerViewer_Click(object sender, EventArgs e)
        {
            //if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
            //{
            //    frm_sasViewerCustomer frm = new frm_sasViewerCustomer();
            //    frm.glbCustomerID = txtCustomerID.Tag.ToString();
            //    if (frm.bNoAccess)
            //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    else
            //    {
            //        //frm.MdiParent = this.MdiParent;
            //        frm.Show();
            //    }
            //}
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
                else
                {
                    frm_masCustomerMaster.glb_sCustomerID = string.Empty;

                    frm_masCustomerMaster frm = new frm_masCustomerMaster(FormName.CustomerMaster);
                    frm.glb_bIsCustomerOrderMode = true;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);

                    if (frm_masCustomerMaster.glb_sCustomerID != string.Empty)
                    {
                        txtCustomerID.Tag = frm_masCustomerMaster.glb_sCustomerID;
                        txtCustomerID.Text = clsGenaralName.getName_Customer(frm_masCustomerMaster.glb_sCustomerID);
                        FillDetailsCustomer(frm_masCustomerMaster.glb_sCustomerID);
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

        #region Btn Customer Order
        private void btnCreateCustomerOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                    if (detail != null && detail.Quotation_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledQuotation)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Quotation Before Creating a Customer Order(s)";
                            }
                        }
                        if (clsConfig.bSettleEnabledQuotation)
                        {
                            if (detail.IsSeattled)
                            {
                                MessageBox.Show("ALREADY C/O GENERATED!! \n\n But, You may Generate More Customer Order(s) to this General Quotation.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (bAllowDetail)
                        {
                            frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                            frm.glbQuotationID = detail.Quotation_ID;
                            frm.glbOrderRefNo = detail.OrderRefNo_ID;

                            //   Form uu = (this.Parent as Form).MdiParent;
                            //   object dd = frm.ParentForm;
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

        #region Btn Add JobCode
        private void btnAddJobCode_Click(object sender, EventArgs e)
        {
            try
            {
                string sCustomer = "";
                if (txtCustomerID.Tag != null)
                    sCustomer = txtCustomerID.Tag.ToString();

                tbl_cfgModule oProdModule = tbl_cfgModule.SelectAll().Where(r => r.Module_ID.Contains("PROD/") && r.IsEnable).FirstOrDefault();

                if (oProdModule != null && oProdModule.Module_ID == "PROD/016")
                {
                    clsSearch.SearchProdApparel_ItemFromProdJobBom_CostApproved(ref txtJobCode, sCustomer, "");

                    if (txtJobCode.Tag != null)
                    {
                        tbl_prodTxJobCard oProdJob = tbl_prodTxJobCard.Select(txtJobCode.Tag.ToString());
                        if (oProdJob != null)
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oProdJob.Item_ID_FG);
                            if (oItem != null)
                            {
                                txtCustomerID.Tag = oProdJob.Customer_ID;
                                txtCustomerID.Text = clsGenaralName.getName_Customer(oProdJob.Customer_ID);

                                RefreshGridByJobID(oItem.Item_ID, oItem.ItemCategorySub_ID, "default", "0", "0", clsProcessMethods.GetProdApparel_ItemUnitPrice_FromBoM(oProdJob.ProdJob_ID));
                            }
                        }
                    }
                }
                else if (oProdModule != null && oProdModule.Module_ID == "PROD/018")
                {
                    clsSearch.SearchProdPhama_ItemFromProdJobBom_CostApproved(ref txtJobCode, sCustomer, "");

                    if (txtJobCode.Tag != null)
                    {
                        tbl_prod_pharmaTxJobCard oProdJob = tbl_prod_pharmaTxJobCard.Select(txtJobCode.Tag.ToString());
                        if (oProdJob != null)
                        {
                            tbl_genItemMaster oItem = tbl_genItemMaster.Select(oProdJob.Item_ID_FG);
                            if (oItem != null)
                            {
                                txtCustomerID.Tag = oProdJob.Customer_ID;
                                txtCustomerID.Text = clsGenaralName.getName_Customer(oProdJob.Customer_ID);

                                RefreshGridByJobID(oItem.Item_ID, oItem.ItemCategorySub_ID, "default", "0", "0", clsProcessMethods.GetProdPharma_ItemUnitPrice_FromBoM(oProdJob.ProdJob_ID));
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
        }
        #endregion

        #region Btn Email
        private void btnEmail_Click(object sender, EventArgs e)
        {
            //    frmEmail frm = new frmEmail();
            //   frm.ShowDialog();
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
                cancelQuotation();
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
        private void frm_sasQuotation_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtQuotationID.TextLength > 0 && txtQuotationID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtQuotationID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

                txtQuotationID.Tag = null;
                dtpQuotationDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtQuotationID.Text = "<Auto Generate>";
                else
                    txtQuotationID.Clear();
                if (txtQuotationID.Enabled)
                {
                    txtQuotationID.SelectAll();
                    txtQuotationID.Focus();
                }

                ucSasProcessFlow.ClearFlow();
                Attachments.Clear();
            }
        }
        #endregion

        #region Btn Account Details
        private void btnAccountDetails_Click(object sender, EventArgs e)
        {
            Search_BankAccount(lblAccountNo);
        }
        #endregion

        #region Btn Branch
        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
            {
                if (txtBranch.Tag.ToString() != "default")
                {
                    //frmSetCustomerBranch frm = new frmSetCustomerBranch();
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
            clsHelpMethods.FormatGrid_Sales(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["Weight"].ReadOnly = false;
            dgvDetail.Columns["WeightPrice"].ReadOnly = false;
            dgvDetail.Columns["Quantity"].ReadOnly = false;
            //dgvDetail.Columns["UnitPrice"].ReadOnly = false;

            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_Quotation ? true : false;
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
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtQuotationID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            txtQuotationID.Tag = null;
            txtCustomerID.Tag = null;
            txtItemID.Tag = null;
            txtAttentionTo.Tag = null;
            txtSalesExecutiveID.Tag = null;

            txtJobCode.Tag = null;
            txtInquiryCode.Tag = null;
            txtItemSubCategory.Tag = null;
            txtOrderRefNo.Tag = null;
            txtRouteID.Tag = null;
            txtTownID.Tag = null;
            txtQuotationType.Tag = null;
            txtBranch.Tag = null;

            txtCustomerID.Clear();
            txtItemID.Clear();
            txtInquiryCode.Clear();
            txtOrderRefNo.Clear();
            glbOrderRefNo = "";
            txtJobCode.Clear();
            txtSalesExecutiveID.Clear();
            txtRemark.Clear();
            txtPurchaseOrder.Clear();
            txtOrderRefNo.Clear();
            dtpQuotationDate.Value = clsSecurity.getServerDateTime();
            txtItemID.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtRouteID.Clear();
            txtTownID.Clear();
            txtQuotationType.Clear();
            txtQuotaionSubject.Text = clsConfig.sCmp_qQuotationSubject;
            txtPaymentTerms.Text = clsConfig.sCmp_qPaymentTerms;
            txtDeliveryPeriod.Text = clsConfig.sCmp_qDeliveryPeriod;
            txtValidityPeriod.Text = clsConfig.sCmp_qValidityPeriod;
            txtAttentionTo.Clear();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkFreeOrder.Checked = false;
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;
            txtBranch.Clear();

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;
            txtAdvanceAmount.Tag = 0;

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
            txtAdvanceAmount.Text = "0.00";

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

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;
            chkDiscount.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;
            chkSettings2.Checked = true;

            txtQuotationTerms.Tag = null;
            txtQuotationTerms.Text = "";

            txtCustomerAddress.Text = "";

            lblAccountNo.Text = "-";
            lblBank.Text = "-";
            lblBankBranch.Text = "-";

            dtpQuotationDate.Enabled = !clsConfig.bLock_TransactionDate_SAS;
            userDetailsColorChanges();

            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            #region Set Visible / Hide Job Selection
            txtJobCode.Visible = false;
            lblInquiryID.Visible = false;
            btnAddJobCode.Visible = false;
            if (clsProcessMethods.CheckProductionApparel_Enable())
            {
                txtJobCode.Visible = true;
                lblInquiryID.Visible = true;
                btnAddJobCode.Visible = true;
            }
            #endregion

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtQuotationID.Text = "<Auto Generate>";
            else
                txtQuotationID.Clear();
            if (txtQuotationID.Enabled)
            {
                txtQuotationID.SelectAll();
                txtQuotationID.Focus();
            }

            ucSasProcessFlow.ClearFlow();

            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sQuotationID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotationID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasQuotation_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.Inquiry_ID, detail.Quotation_ID, detail.Job_ID, detail.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount,
                            detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID,
                            detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByItemID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
                int iRow;
                string sCustomerID = txtCustomerID.Tag != null ? txtCustomerID.Tag.ToString().Trim() : "";
                //dgvDetail.Rows.Clear();
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemID);
                if (detail != null && oItemF != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = 1, dAmount = oItemF.SellingPrice1 * dQty;
                    decimal dWeight = clsHelpMethods.GetWeightByItemID(detail.Item_ID, 1);
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, sCustomerID);
                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);
                    bool bHasSettledBefore = true;

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(false, iRow, maxLineNo + 1, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, dAmount, detail.Width,
                        detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, bHasSettledBefore);
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
        private void RefreshGridByJobID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2, decimal dUnitPrice)
        {
            try
            {
                int iRow;
                string sCustomerID = txtCustomerID.Tag != null ? txtCustomerID.Tag.ToString().Trim() : "";
                //dgvDetail.Rows.Clear();
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemID);
                if (detail != null && oItemF != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = 1, dAmount = oItemF.SellingPrice1 * dQty;
                    decimal dWeight = clsHelpMethods.GetWeightByItemID(detail.Item_ID, 1);

                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);
                    bool bHasSettledBefore = true;

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(true, iRow, maxLineNo + 1, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, dAmount, detail.Width,
                        detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, bHasSettledBefore);
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

        //private void RefreshGridByJobIDID(string sJobID)
        //{
        //    try
        //    {
        //        int iRow;
        //        //dgvDetail.Rows.Clear();
        //        tbl_sasJobRegister detail = tbl_sasJobRegister.Select(sJobID);
        //        if (detail != null)
        //        {
        //            tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
        //            if (item != null)
        //            {
        //                dgvDetail.Rows.Add();
        //                iRow = dgvDetail.Rows.Count - 1;
        //                decimal dUnitPrice = detail.KiloPrice; //clsHelpMethods.GetUnitPrice(item.Width, item.Height, item.Thickness, item.Gusset, detail.KiloPrice, detail.Uom_ID);
        //                decimal dAmount = dUnitPrice * detail.Weight;
        //                bool bHasSettledBefore = true;

        //                var MaxID = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
        //                Fill_Datagrid(iRow, MaxID + 1, detail.Item_ID, detail.Inquiry_ID, "default", detail.Job_ID, detail.Uom_ID, dUnitPrice, dUnitPrice, false, 0, 0,
        //                    dAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, "default", "default", "0", "0", item.Description, bHasSettledBefore);

        //                CalcualteSubTotal();
        //                CalculateTaxesAndGrandTotal();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        SEACCException.Show(ex);
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //    }
        //}
        private void RefreshGridByInquiryID(string sInquiryID)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_sasInquiry_Detail> details = tbl_sasInquiry_Detail.SelectAllByInquiry_ID(sInquiryID).OrderBy(p => p.Line_No).ToList();
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

                        Fill_Datagrid(true, iRow, detail.Line_No, item.Item_ID, detail.Inquiry_ID, "default", "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount, item.Width,
                            item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle), (detail.Qty - detail.QtySettle), detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID,
                            detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore);
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
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtQuotationID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtRouteID.Tag = order.Route_ID;
                            txtTownID.Tag = order.Town_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                            txtRouteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(order.Route_ID));
                            txtTownID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(order.Town_ID));
                        }

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtJobCode.Tag = detail.Job_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtAttentionTo.Tag = detail.ContactLine_No;
                        txtQuotationType.Tag = detail.QuotationType_ID;

                        if (detail.Branch_ID != "default")
                        {
                            txtBranch.Tag = detail.Branch_ID;
                            int iBranchCode = int.Parse(detail.Branch_ID);
                            txtBranch.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
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

                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtQuotationType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_QuotationType(detail.QuotationType_ID));
                        txtQuotationID.Text = detail.Quotation_ID;
                        txtRemark.Text = detail.Remark;
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtQuotaionSubject.Text = detail.QuotationSubject;
                        txtPaymentTerms.Text = detail.PaymentPeriod;
                        txtDeliveryPeriod.Text = detail.DeliveryPeriod;
                        txtValidityPeriod.Text = detail.ValiedPeriod;
                        txtAttentionTo.Text = detail.ContactName;
                        dtpQuotationDate.Value = detail.QuotationDate;
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;
                        chkSettings2.Checked = false;

                        txtQuotationTerms.Text = detail.QuotationTerms;
                        //txtQuotationTerms.Text = detail.QuotationTerms != "default" ? clsGenaralName.getName_QuotationTerms(detail.QuotationTerms) : "-";

                        txtCustomerAddress.Text = detail.DeliveryAddress;

                        lblAccountNo.Text = detail.BankAccount != "default" ? detail.BankAccount : "-";
                        tbl_genCompanyAccount odetail = tbl_genCompanyAccount.Select(detail.BankAccount);
                        if (odetail != null && odetail.AccountNumber != "default")
                        {
                            tbl_zBank oBank = tbl_zBank.Select(odetail.Bank_ID);
                            if (oBank != null)
                            {
                                lblBank.Text = oBank.BankName;
                                lblBank.Tag = oBank.Bank_ID;
                            }
                            tbl_zBankBranches oBankBranch = tbl_zBankBranches.Select(odetail.Branch_ID);
                            if (oBankBranch != null)
                            {
                                lblBankBranch.Text = oBankBranch.BranchName;
                                lblBankBranch.Tag = oBankBranch.Branch_ID;
                            }
                        }

                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

                        //Tax Details
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
                        RefreshGrid(detail.Quotation_ID);

                        //Asign Taxes
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

                        chkDiscount.Checked = (detail.DiscountTotal > 0) ? true : false;
                        chkNBT.Checked = (detail.NbtTotal > 0) ? true : false;
                        chkVat.Checked = (detail.VatTotal > 0) ? true : false;
                        chkOtherTax.Checked = (detail.OtherTaxTotal > 0) ? true : false;

                        CalcualteSubTotal();
                        CalculateTaxesAndGrandTotal();

                        //Set Flow
                        //clsHelpMethods.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                        //   txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);

                        ucSasProcessFlow.SetProcessFlowByQuotation(detail.Quotation_ID);

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
                    txtCustomerID.Text = customer.CustomerName;
                    txtCustomerAddress.Text = customer.AddressRegister;

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

                List<tbl_genCustomerMaster_Route> cusRoutes = tbl_genCustomerMaster_Route.SelectAllByCustomer_ID(sCustomerID);
                foreach (tbl_genCustomerMaster_Route cusRoute in cusRoutes)
                {
                    if (cusRoute.Route_ID != "default")
                    {
                        txtRouteID.Tag = cusRoute.Route_ID;
                        txtRouteID.Text = clsGenaralName.getName_Route(cusRoute.Route_ID);
                        break;
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

        #region Fill Datagrid
        private void Fill_Datagrid(bool IsUpdateMode, int iRow, int lineNo, string ItemID, string inquiryID, string QuotationCode, string JobID, string UomID, decimal UnitPrice, decimal WeightPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal TatalAmount,
            decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled)
        {
            try
            {
                //if the item already in the datagrid, only update weight and qty of the item.
                bool isNewItem = true;

                if (!IsUpdateMode)
                {
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
                            sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                            if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
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
                }

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["InquiryCode", iRow].Value = inquiryID;//add by thilina
                dgvDetail["QuotationCode", iRow].Value = QuotationCode;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina              
                //dgvDetail["LineNo", iRow].Value = LineNo.ToString();
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(UomID);
                dgvDetail["UOM", iRow].Tag = UomID;
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
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);
                }

                dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(TatalAmount);

                //bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
                dgvDetail["Free", iRow].Value = isFreeItem;
                dgvDetail["DiscuntPresentage", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountPresentage);
                dgvDetail["DiscuntPresentage", iRow].Tag = DiscountPresentage;
                dgvDetail["DiscountValue", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountAmount);
                dgvDetail["DiscountValue", iRow].Tag = DiscountAmount;

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

        #region Fill Tax Detail By Inquiry
        private void FillTaxDetailByInquiry(string InquiryID)
        {
            try
            {
                tbl_sasInquiry detail = tbl_sasInquiry.Select(InquiryID);
                if (detail != null)
                {
                    txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);
                    txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                    txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                    txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));

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

        #region Fill Bank and Branch Details
        private void FillBankAndBranch(string sAccountNo)
        {
            try
            {
                tbl_genCompanyAccount odetail = tbl_genCompanyAccount.Select(sAccountNo);
                if (odetail != null)
                {
                    tbl_zBank detail = tbl_zBank.Select(odetail.Bank_ID);
                    if (detail != null)
                    {
                        lblBank.Text = detail.BankName;
                        lblBank.Tag = detail.Bank_ID;
                    }
                    tbl_zBankBranches details = tbl_zBankBranches.Select(odetail.Branch_ID);
                    if (detail != null)
                    {
                        lblBankBranch.Text = details.BranchName;
                        lblBankBranch.Tag = details.Branch_ID;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Check Validity
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
                    {
                        if (clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                        {
                            //  if (clsHelpMethods.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                            {
                                if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                                {
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpQuotationDate.Value.Date))
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

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "CustomerName"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtQuotationTerms, "Quotation Terms"))
                    bStatus = true;
            }
            return bStatus;
        }

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sItemCode = "", sInquiryCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dQuantity = 0, dWeight = 0;

            if (!clsAutocode.getItemExceed(ConfigItemExceedLock.CustomerOrder))
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        tbl_sasInquiry_Detail inqDetail = tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        if (inqDetail != null)
                        {
                            if (chkUnitPricing.Checked)
                            {
                                if (IsUpdate)
                                {
                                    if (inqDetail.Qty < dQuantity)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Inquiry Quantity \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (inqDetail.Qty < (inqDetail.QtySettle + dQuantity))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Inquiry Quantity \n";
                                        rtn = false;
                                    }
                                }
                            }
                            else
                            {
                                if (IsUpdate)
                                {
                                    if (inqDetail.Weight < dWeight)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Inquiry Weight \n";
                                        rtn = false;
                                    }
                                }
                                else
                                {
                                    if (inqDetail.Weight < (inqDetail.WeightSettle + dWeight))
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Inquiry Weight \n";
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

        //private bool CheckOutstandingValidity()
        //{
        //    bool bOk = true;
        //    decimal dCreditBalance = 0, dAmountDue = 0;
        //    try
        //    {
        //        if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
        //        {
        //            tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
        //            if (customer != null && customer.Customer_ID != "default")
        //            {
        //                if (customer.IsBlacklisted)
        //                {
        //                    bOk = false;
        //                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                }
        //                else
        //                {

        //                    if (clsConfig.bValidate_CreditBalance_Message) //security 1 - Message
        //                    {
        //                        dCreditBalance = clsHelpMethods.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
        //                        if (txtGrandTotal.TextLength > 0)

        //                            dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
        //                        if (dCreditBalance < dAmountDue) //Condition
        //                        {
        //                            bOk = false;
        //                            if (clsConfig.bValidate_CreditBalance_Block) //security 2 - Lock
        //                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                            else
        //                            {
        //                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        //                                if (msgResult == DialogResult.Yes)
        //                                {
        //                                    bOk = true;
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", iFormID,ex);
        //        SEACCException.Show(ex);
        //    }

        //    return bOk;
        //}

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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool ValidateForDependancies(string sQuotationID)
        {
            bool bValue = true;
            foreach (tbl_sasCustomerOrder_Detail oCO in tbl_sasCustomerOrder_Detail.SelectAllByQuotation_ID(sQuotationID))
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(oCO.CustomerOrder_ID);
                if (detail != null && detail.CustomerOrder_ID != "default" && !detail.IsDeleted)
                {
                    bValue = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + detail.CustomerOrder_ID + "] Customer Order is already created for this Quotation", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            //if (bValue)
            //{
            //    foreach (tbl_scsPurchaseOrder_Detail oEG in tbl_scsPurchaseOrder_Detail.SelectAllByQuotationID(sQuotationID))
            //    {
            //        //TODO - SelectAllByInquiry_ID SP Need To Create
            //        tbl_scsExternalGoodReceivedNote detail1 = tbl_scsExternalGoodReceivedNote.Select(oEG.PurchaseOrder_ID);
            //        if (detail1 != null && detail1.PurchaseOrder_ID != "default" && !detail.IsDeleted)
            //        {
            //            bValue = false;
            //            MessageBox.Show("Record Cannot Be Deleted! \nA Quotation is already Created For This Quotation", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            break;
            //        }
            //    }
            //}
            return bValue;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtRouteID);
                clsCommon.ValidateForeignKey(ref txtTownID);
                clsCommon.ValidateForeignKey(ref txtJobCode);
                clsCommon.ValidateForeignKey(ref txtInquiryCode);
                clsCommon.ValidateForeignKey(ref txtQuotationType);
                clsCommon.ValidateForeignKey(ref txtBranch);
                clsCommon.ValidateForeignKey(ref lblAccountNo);

                //if (txtAttentionTo.Tag == null || txtAttentionTo.Text.Trim().Length == 0)
                //{
                //    txtAttentionTo.Tag = 0;
                //    txtAttentionTo.Text = "";
                //}

                if (txtAttentionTo.Text.Trim().Length == 0)
                {
                    txtAttentionTo.Tag = 0;
                    txtAttentionTo.Text = "";
                }
                else
                {
                    txtAttentionTo.Tag = 0;
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
        private bool CheckValiditeCustomer()
        {
            bool rtn = true;
            if (txtCustomerID.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Customer Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
            }
            return rtn;
        }
        #endregion

        #region Events keyDown
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionQuotation_Direct(ref txtQuotationID, chkShowSettle.Checked);
                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtQuotationID.Tag.ToString());
            }
        }
        private void txtInquiryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Inquiry(sender);
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtAttentionTo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerContactPerson();
            }
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_SalesExecutiveID();
            }
        }
        private void txtQuotationType_KeyDown(object sender, KeyEventArgs e)
        {
            Search_QuotationType();
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_JobID();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (CheckValiditeCustomer())
            {
                clsHelpMethods.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(sender, new EventArgs());
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
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterRoute(ref txtRouteID);
            }
        }
        private void txtTownID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterTown(ref txtTownID);
            }
        }
        private void frm_stkCustomerOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtQuotationTerms_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterQuotationTerms(ref txtQuotationTerms);
            }
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

        #region Events DoubleClick
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionQuotation_Direct(ref txtQuotationID, chkShowSettle.Checked);
            if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtQuotationID.Tag.ToString());
        }

        private void txtInquiryCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Inquiry(sender);
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtAttentionTo_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerContactPerson();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            Search_JobID();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtQuotationType_DoubleClick(object sender, EventArgs e)
        {
            Search_QuotationType();
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditeCustomer())
            {
                clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(sender, new EventArgs());
            }
        }
        private void txtTownID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTownID);
        }
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRouteID);
        }
        private void txtQuotationTerms_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterQuotationTerms(ref txtQuotationTerms);
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

        #region Search Methods
        private void Search_JobID()
        {
            btnAddJobCode_Click(null, null);
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
        private void Search_QuotationType()
        {
            clsSearch.Search_MasterQuotationType(ref txtQuotationType);
        }
        //private void Search_ProformaInvoiceID()
        //{
        //    Form frmhelpsearch = new frmSearchTransaction();
        //    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
        //    {
        //        clsSearch.passValue_ProformaInvoiceByCustomerID(txtCustomerID.Tag.ToString());
        //        frmhelpsearch.ShowDialog();

        //        if (frmSearchTransaction.s_SearchText.Length > 0)
        //            txtInvoiceID.Text = frmSearchTransaction.s_SearchID;
        //        if (frmSearchTransaction.s_SearchID.Length > 0)
        //            txtInvoiceID.Tag = frmSearchTransaction.s_SearchID;
        //    }
        //    else
        //        MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        private void Search_CustomerID()
        {
            //try
            //{
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.passValue_CustomerMaster();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //        if (frmSearchMaster.s_SearchText.Length > 0 && frmSearchMaster.s_SearchID.Length > 0)
            //        {
            //            txtCustomerID.Text = frmSearchMaster.s_SearchText;
            //            txtCustomerID.Tag = frmSearchMaster.s_SearchID;
            //            FillDetailsCustomer(frmSearchMaster.s_SearchID);
            //        }

            //        //Add Branch
            //        List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
            //        if (Detail.Count > 0)
            //            Search_CustomerBranch(frmSearchMaster.s_SearchID);
            //        else
            //        {
            //            txtBranch.Clear();
            //            txtBranch.Tag = null;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", iFormID, ex);
            //    SEACCException.Show(ex);
            //}

            try
            {
                bool bIsEnableCustomerChange = true;

                if (txtCustomerID.Tag != null)
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
                    if (dgvDetail.Rows.Count > 0)
                        MessageBox.Show("Please remove items to change customer..!");
                    else
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
                                    FillDetailsCustomer(sCustomerID);
                            }
                        }

                        //Add Branch
                        //if (txtCustomerID.Tag != null)
                        //{
                        //    List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
                        //    if (Detail.Count > 1)
                        //        Search_CustomerBranch(txtCustomerID.Tag.ToString());
                        //    else
                        //    {
                        //        txtBranch.Text = Detail.FirstOrDefault().BranchName;
                        //        txtBranch.Tag = Detail.FirstOrDefault().Line_No;

                        //        txtCustomerAddress.Text = Detail.FirstOrDefault().Address;

                        //        txtRouteID.Text = "Route Code - " + clsGenaralName.getCode_Route(Detail.FirstOrDefault().Route_ID);
                        //        txtRouteID.Tag = Detail.FirstOrDefault().Route_ID.ToString();
                        //    }


                        //    //if (!clsHelpMethods.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                        //    //    ClearFields();
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }

        }
        private void Search_CustomerContactPerson()
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_MasterContactPersonByCustomerID(ref txtAttentionTo, txtCustomerID.Tag.ToString());
                else
                    MessageBox.Show("Please Select The Customer Name First..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void Search_ItemID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtItemID.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtItemID.Text = frmSearchMaster.s_SearchText;
        }
        private void Search_CustomerBranch(string sCustomerID)
        {
            try
            {
                if (txtCustomerID.Tag != null)
                {
                    clsSearch.Search_CustomerBranch(ref txtBranch, sCustomerID);

                    //Form frmhelpsearch = new frmSearchMaster();
                    //clsSearch.passValue_CustomerBranch(txtCustomerID.Tag.ToString());
                    //frmhelpsearch.ShowDialog();

                    if (txtBranch.Tag != null && txtBranch.Text.Length > 0)
                    {
                        //txtBranch.Tag = frmSearchMaster.s_SearchID;
                        //txtBranch.Text = frmSearchMaster.s_SearchText;

                        tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(sCustomerID, int.Parse(txtBranch.Tag.ToString()));
                        if (oBranch != null)
                        {
                            if (oBranch.IsBillltoHeadOffice != true)
                            {
                                txtCustomerAddress.Text = oBranch.Address;
                            }
                            else
                            {
                                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                                if (oCustomer != null)
                                {
                                    txtCustomerAddress.Text = oCustomer.AddressRegister;
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
        private void Search_BankAccount(Label myLabel)
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_CompanyAccount();

                frmhelpsearch.ShowDialog();
                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        myLabel.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        myLabel.Tag = frmSearchTransaction.s_SearchID;

                    FillBankAndBranch(myLabel.Tag.ToString());
                }
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);

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
                    decimal dUnitPrice = 0, dWeightPrice = 0, dQty = 0, dWeight = 0;
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

        #region Send E-Mail
        public void sendEmail()
        {
            //    frmEmail oEmail = new frmEmail();
            //    oEmail.Show();
        }
        #endregion

        #region Cancel Quotation
        private void cancelQuotation()
        {
            try
            {
                if (txtQuotationID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
                        if (detail != null)
                        {
                            if (ValidateForDependancies(detail.Quotation_ID))
                            {
                                var vCOs = tbl_sasCustomerOrder.SelectAllByQuotation_ID(detail.Quotation_ID).Where(r => !r.IsDeleted).ToList();
                                if (vCOs.Count < 1)
                                {
                                    detail.IsLocked = false;
                                }

                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        //  if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Quotation : " + detail.Quotation_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                //////Update Other Tables 
                                                #region Update Other Tables
                                                List<tbl_sasQuotation_Detail> Codetails = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(txtQuotationID.Text.Trim());
                                                foreach (tbl_sasQuotation_Detail Codetail in Codetails)
                                                {
                                                    if (Codetail.Item_ID != null)
                                                    {
                                                        //////Unsettle Inquiry
                                                        #region Unsettle Inquiry
                                                        if (Codetail.Inquiry_ID != null && Codetail.Inquiry_ID != "default")
                                                        {
                                                            tbl_sasInquiry_Detail inqItem = tbl_sasInquiry_Detail.Select(Codetail.Inquiry_ID, Codetail.Item_ID, Codetail.ItemSubCategory_ID,
                                                                Codetail.ItemSubCategory2_ID, Codetail.ItemSerialNo, Codetail.ItemSerialNo2);
                                                            if (inqItem != null)
                                                            {
                                                                if (!detail.IsWeightCalculation)
                                                                    inqItem.QtySettle = inqItem.QtySettle - Codetail.Qty;
                                                                else
                                                                    inqItem.WeightSettle = inqItem.WeightSettle - Codetail.Weight;
                                                                inqItem.Update();
                                                                clsProcessMethods.SetSettle_Inquiry(Codetail.Inquiry_ID, chkUnitPricing);
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

        #region Print Method
        private void Print(bool bIsDraft)
        {
            bool bTaxTypeSelection_OK = false;
            frm_TaxSelecion oTax = new frm_TaxSelecion(true);
            #region Tax Type Selection
            if (clsConfig.benable_TaxSelection_Quotation)
            {
                if (chkOtherTax.Checked == true)
                {
                    bTaxTypeSelection_OK = true;
                    oTax.bSVatSelected = true;
                    oTax.bNbtSelected = true;
                }
                else
                {
                    oTax.ShowDialog();
                    if (oTax.DialogResult == DialogResult.OK)
                        bTaxTypeSelection_OK = true;
                }
            }
            else
                bTaxTypeSelection_OK = true;

            #endregion

            if (bTaxTypeSelection_OK)
            {
                #region views
                if (false)
                {
                    //try
                    //{
                    //    bool isDuplicate = false;
                    //    if (txtQuotationID.TextLength > 0 && txtQuotationID.Text != "<Auto Generate>")
                    //    {
                    //        //update receipt
                    //        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    //        tbl_sasQuotation oOrder = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
                    //        if (oOrder != null)
                    //        {
                    //            if (oOrder.PrintCount > 0)
                    //                isDuplicate = true;
                    //            oOrder.PrintCount++;
                    //            oOrder.DatePrinted = clsSecurity.getServerDateTime();
                    //            oOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
                    //            oOrder.PrintedUser_ID = clsSecurity.UserIDLoged;

                    //            sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ]";
                    //            if (oOrder.CheckedUser_ID != "default")
                    //                sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ]";
                    //            if (oOrder.ApprovedUser_ID != "default")
                    //                sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ]";
                    //            oOrder.Update();
                    //        }

                    //        Cursor = Cursors.WaitCursor;
                    //        string s_Path = "", sReportTitle = "QUOTATION", sFormula = "";
                    //        if (txtQuotationID.TextLength > 0)
                    //            sFormula = "{vw_rpt_sasQuotation.quotation_ID} = '" + txtQuotationID.Text.Trim() + "'";

                    //        ReportDocument RD = new ReportDocument();
                    //        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                    //        string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_Quotation));
                    //        if (sGetRptPath != null && sGetRptPath.Length > 0)
                    //            s_Path += sGetRptPath;
                    //        else
                    //        {
                    //            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_WSC.rpt";
                    //            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_AKT.rpt";
                    //            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_WSC.rpt";
                    //            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_WSC.rpt";
                    //            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_WSC.rpt";
                    //            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_CWP.rpt";
                    //            else
                    //                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasQuotation_WSC.rpt";
                    //        }


                    //        frm_ReportViewer viewer = new frm_ReportViewer();
                    //        RD.Load(s_Path);
                    //        clsSecurity.LogonServer(ref RD);
                    //        RD.Refresh();

                    //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    //            RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                    //        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                    //        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                    //        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                    //        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                    //        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                    //        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    //        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                    //        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                    //        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                    //        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                    //        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                    //        RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(oOrder.Customer_ID));
                    //        if (isDuplicate)
                    //            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");


                    //        if (oOrder.IsDeleted)
                    //        {
                    //            RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("CANCELLED");
                    //        }
                    //        else
                    //            RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("");


                    //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                    //            RD.DataDefinition.FormulaFields["ProjectType"].Text = clsCommon.fncsetstring("c");
                    //        //else
                    //        //    RD.DataDefinition.FormulaFields["ProjectType"].Text = clsCommon.fncsetstring("r");

                    //        if (clsConfig.bDirectPrint_NP_Quotation) //Direct Print
                    //        {
                    //            RD.DataDefinition.RecordSelectionFormula = sFormula;
                    //            clsHelpMethods.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_CustomerQuotation), ref RD);
                    //            RD.PrintToPrinter(1, false, 0, 0);

                    //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DucumentPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        }
                    //        else //View And Print
                    //        {
                    //            viewer.crystalReportViewer1.ReportSource = RD;
                    //            viewer.crystalReportViewer1.SelectionFormula = sFormula;
                    //            viewer.crystalReportViewer1.Visible = true;
                    //            viewer.crystalReportViewer1.DisplayToolbar = true;
                    //            viewer.crystalReportViewer1.CloseView(false);
                    //            viewer.WindowState = FormWindowState.Maximized;
                    //            viewer.ShowDialog();
                    //        }

                    //        RD.Close();
                    //        RD.Dispose();
                    //    }
                    //    else
                    //        MessageBox.Show("Please Select the Quotation To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    //catch (Exception ex)
                    //{
                    //    SEACCException.Show(ex);
                    //    clsValidate.WriteErrorLog("", iFormID,ex);
                    //}
                    //finally
                    //{
                    //    Cursor = Cursors.Default;
                    //}
                }
                #endregion

                #region DataSet
                else
                {
                    try
                    {
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "";
                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", LastModifiedDate = "", sTaxType = "", sSalesMan = "";
                        string sDuplicate = "";
                        if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_Quotation), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            glb_dts_sasQuotation.Clear();
                            glb_dtsReportExport.Clear();
                            Cursor = Cursors.WaitCursor;

                            bool bPermissinOkToPrint = true;
                            if (chkPrintOriginal.Checked)
                                bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_Quotation));
                            if (bPermissinOkToPrint)
                            {
                                tbl_sasQuotation oQuotation = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                                if (oQuotation != null)
                                {
                                    if (!bIsDraft)
                                    {
                                        //if (oQuotation.PrintCount > 0)
                                        //    sDuplicate = "Duplicate Copy " + oQuotation.PrintCount;

                                        if (!chkPrintOriginal.Checked)
                                            sDuplicate = (oQuotation.PrintCount > 0) ? "Duplicate Copy " + oQuotation.PrintCount : "";

                                        oQuotation.PrintCount++;

                                        oQuotation.DatePrinted = clsSecurity.getServerDateTime();
                                        oQuotation.PrintedTerminal_ID = clsSecurity.TerminalID;
                                        oQuotation.PrintedUser_ID = clsSecurity.UserIDLoged;

                                        oQuotation.Update();
                                    }

                                    LastModifiedDate = clsFormatter.FormatDate_SL(oQuotation.DateModified);

                                    if (clsConfig.benable_TaxSelection_Quotation)
                                    {
                                        decimal dSubTotal = clsHelpMethods.getDisplayPrice(oQuotation.SubTotal, oQuotation.CurrencyRate);
                                        decimal dDiscountTotal = clsHelpMethods.getDisplayPrice(oQuotation.DiscountTotal, oQuotation.CurrencyRate);
                                        decimal dNbtAmout = clsHelpMethods.getDisplayPrice(oQuotation.NbtTotal, oQuotation.CurrencyRate);
                                        decimal dvatAmount = clsHelpMethods.getDisplayPrice(oQuotation.VatTotal, oQuotation.CurrencyRate);
                                        decimal dSvatAmount = clsHelpMethods.getDisplayPrice(oQuotation.OtherTaxTotal, oQuotation.CurrencyRate);
                                        decimal dGrandToatal = clsHelpMethods.getDisplayPrice(oQuotation.GrandTotal, oQuotation.CurrencyRate);
                                        //decimal dnbtPresentage = clsHelpMethods.getDisplayPrice(oQuotation.NbtPercentage, oQuotation.CurrencyRate);
                                        //decimal dVatPreasentage = clsHelpMethods.getDisplayPrice(oQuotation.VatPercentage, oQuotation.CurrencyRate);
                                        //decimal dSvatPresentage = clsHelpMethods.getDisplayPrice(oQuotation.OtherTaxPercentage, oQuotation.CurrencyRate);

                                        clsHelpMethods.CalculateGrandTotalReverce(dGrandToatal, ref dvatAmount, oQuotation.VatPercentage, oTax.bVatSelected, ref dSvatAmount, oQuotation.OtherTaxPercentage, oTax.bSVatSelected, ref dNbtAmout, oQuotation.NbtPercentage, oTax.bNbtSelected, ref dDiscountTotal, oQuotation.DiscountPercentage, ref dSubTotal);

                                        glb_dts_sasQuotation.Quotation.AddQuotationRow(oQuotation.Quotation_ID, oQuotation.QuotationDate, "", clsGenaralName.getName_SalesRep(oQuotation.Employee_ID), "", oQuotation.OrderRefNo_ID, oQuotation.ContactName, oQuotation.Customer_ID, clsGenaralName.getName_Customer(oQuotation.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(oQuotation.Customer_ID), clsGenaralName.getName_BranchCustomer(oQuotation.Customer_ID, int.Parse(oQuotation.Branch_ID)), "", "", "", oQuotation.ValiedPeriod, oQuotation.PaymentPeriod, oQuotation.DeliveryPeriod, dSubTotal, oQuotation.DiscountPercentage, dDiscountTotal, dSubTotal, oQuotation.NbtPercentage, dNbtAmout, oQuotation.VatPercentage, dvatAmount, oQuotation.OtherTaxPercentage, dSvatAmount, dGrandToatal, oQuotation.Remark, 0, true);

                                        if (oTax.bVatSelected && oTax.bNbtSelected)
                                            sTaxType = "TAX";
                                        if (oTax.bNbtSelected)
                                            sTaxType = "TAX";
                                        if (oTax.bSVatSelected && oTax.bNbtSelected)
                                            sTaxType = "SVAT";
                                        else if (!oTax.bVatSelected && !oTax.bNbtSelected && !oTax.bSVatSelected)
                                            sTaxType = "NON TAX";

                                        tbl_genEmployeeMaster oSalesman = tbl_genEmployeeMaster.Select(oQuotation.Employee_ID);
                                        sSalesMan = "[ " + oSalesman.EmployeeName + ", " + oSalesman.Telephone + " | " + oSalesman.Email + " ]";
                                        decimal dInvoiceSubTotal = clsHelpMethods.getDisplayPrice(oQuotation.SubTotal, oQuotation.CurrencyRate);

                                        foreach (tbl_sasQuotation_Detail oQDetail in tbl_sasQuotation_Detail.SelectAllByQuotation_ID(oQuotation.Quotation_ID))
                                        {
                                            decimal dUnitPrice = 0, dQTY = 0;

                                            tbl_genItemMaster oItmaster = tbl_genItemMaster.Select(oQDetail.Item_ID);
                                            tbl_zUom oUom = tbl_zUom.Select(oQDetail.Uom_ID);
                                            if (oUom != null && oItmaster != null)
                                            {
                                                decimal dAmount = clsHelpMethods.getDisplayPrice(oQDetail.TatalAmount, oQuotation.CurrencyRate);
                                                decimal dRatio = dAmount / dInvoiceSubTotal;
                                                dAmount = dSubTotal * dRatio;
                                                decimal dLineDiscount = 0;
                                                if (dAmount > 0)
                                                    dLineDiscount = (dAmount * oQDetail.DiscountPresentage) / (100 - oQDetail.DiscountPresentage);
                                                dUnitPrice = (dAmount + dLineDiscount) / oQDetail.Qty;
                                                dQTY = oQDetail.Qty;

                                                glb_dts_sasQuotation.QuotationDetail.AddQuotationDetailRow(oQDetail.Quotation_ID, oQDetail.Item_ID, oItmaster.ItemName, oQDetail.Remark, oUom.UomCode, dQTY, dUnitPrice, dAmount);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        glb_dts_sasQuotation.Quotation.AddQuotationRow(oQuotation.Quotation_ID, oQuotation.QuotationDate, "", clsGenaralName.getName_SalesRep(oQuotation.Employee_ID), "", oQuotation.OrderRefNo_ID, oQuotation.ContactName, oQuotation.Customer_ID, clsGenaralName.getName_Customer(oQuotation.Customer_ID), clsGenaralName.getName_CustomerDeliveryAddress(oQuotation.Customer_ID), "", "", "", "", oQuotation.ValiedPeriod, oQuotation.PaymentPeriod, oQuotation.DeliveryPeriod, oQuotation.SubTotal, oQuotation.DiscountPercentage, oQuotation.DiscountTotal, 0, oQuotation.NbtPercentage, oQuotation.NbtTotal, oQuotation.VatPercentage, oQuotation.VatTotal, 0, 0, oQuotation.GrandTotal, oQuotation.Remark, 0, oQuotation.IsDeleted);
                                        tbl_genEmployeeMaster oSalesman = tbl_genEmployeeMaster.Select(oQuotation.Employee_ID);
                                        sSalesMan = "[ " + oSalesman.EmployeeName + ", " + oSalesman.Telephone + " | " + oSalesman.Email + " ]";

                                        foreach (tbl_sasQuotation_Detail oQDetail in tbl_sasQuotation_Detail.SelectAllByQuotation_ID(oQuotation.Quotation_ID))
                                        {
                                            //glb_dts_sasQuotation.QuotationDetail.AddQuotationDetailRow(oQDetail.Quotation_ID, oQDetail.Item_ID, clsGenaralName.getName_Item(oQDetail.Item_ID), oQDetail.Remark, clsGenaralName.getName_ItemUOM(oQDetail.Item_ID), oQDetail.Qty, oQDetail.UnitPrice, oQDetail.TatalAmount);
                                            glb_dts_sasQuotation.QuotationDetail.AddQuotationDetailRow(oQDetail.Quotation_ID, oQDetail.Item_ID, clsGenaralName.getName_Item(oQDetail.Item_ID), oQDetail.Remark, clsGenaralName.getName_ItemUOM(oQDetail.Item_ID), oQDetail.Qty, oQDetail.UnitPrice - oQDetail.DiscountAmount, oQDetail.TatalAmount);
                                        }
                                    }

                                    sCreateUser = "[ " + clsGenaralName.getName_User(oQuotation.CreateUser_ID) + " | " + oQuotation.DateCreate + " ]";
                                    if (oQuotation.CheckedUser_ID != "default")
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(oQuotation.CheckedUser_ID) + " | " + oQuotation.DateChecked + "]";
                                    if (oQuotation.ApprovedUser_ID != "default")
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oQuotation.ApprovedUser_ID) + " | " + oQuotation.DateApproved + "]";
                                }

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("Salesman", sSalesMan, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("LastModifiedDate", LastModifiedDate, true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DupicateCopy", sDuplicate, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oQuotation.IsDeleted ? "CANCELLED" : "", true, false);

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

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true, false);
                                    }
                                }
                                glb_dts_sasQuotation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sTaxType + " " + sReportTitle_Main, "", "", clsSecurity.UserNameLoged, "");
                                #endregion

                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                rpt.print(sReportPath, glb_dts_sasQuotation, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_Quotation));
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
                        glb_dts_sasQuotation.Clear();
                        glb_dtsReportExport.Clear();
                        Cursor = Cursors.Default;
                    }
                }
                #endregion
            }
        }
        #endregion

        private void frm_sasQuotation_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

        #region User Checked Approve Details

        #region Search and Approved Methods
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpQuotationDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtQuotationID.Text != null && txtQuotationID.TextLength > 0 && txtQuotationID.Text != "<Auto Generate>")
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

                                        tbl_sasQuotation objDO = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpQuotationDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtQuotationID.Text != null && txtQuotationID.TextLength > 0 && txtQuotationID.Text != "<Auto Generate>")
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

                                        tbl_sasQuotation objDO = tbl_sasQuotation.Select(txtQuotationID.Text.Trim());
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
        #endregion

        private void UserDetails()
        {
            try
            {
                if (txtQuotationID.Text != "" || txtQuotationID.Text != "<Auto Generate>")
                {
                    tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Text);
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

        private void btnQuotationTermsCretion_Click(object sender, EventArgs e)
        {
            try
            {
               

                frm_masCustomerMaster frm = new frm_masCustomerMaster(FormName.CustomerMaster);
                frm.glb_bIsCustomerOrderMode = true;
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);

                if (frm_masCustomerMaster.glb_sCustomerID != string.Empty)
                {
                    txtCustomerID.Tag = frm_masCustomerMaster.glb_sCustomerID;
                    txtCustomerID.Text = clsGenaralName.getName_Customer(frm_masCustomerMaster.glb_sCustomerID);
                    FillDetailsCustomer(frm_masCustomerMaster.glb_sCustomerID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
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
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_Quotation(sender, e, glbOrderRefNo);
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
//private void txtFlowPInvoice_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_ProformaInvoice(sender, e, glbOrderRefNo);
//}

#endregion