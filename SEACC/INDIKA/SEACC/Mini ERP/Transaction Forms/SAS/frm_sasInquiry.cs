using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Zion.ERP.Reports.DataSets;
using Zion.ERP.Reports.DataSets.SAS;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using ZION.ERP.Reports.DataSets.SAS;

namespace Digiteq
{
    public partial class frm_sasInquiry : SEACC_Form
    {
        

        //to keep glob ref no
        public string glbOrderRefNo = "", glbInquiryID = "";

        //for security handle
        //public bool bNoAccess;
        //public bool bHasChecked;
        //public bool bHasApproved;
        //   DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        //   DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        dts_sasInquiry glb_dts_sasInquiry = new dts_sasInquiry();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;
   

        #region Form Load
        public frm_sasInquiry(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }
        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            //format Form
            //clsFormatter.setFormatForm(this, "Inquiry [INQ]", 2, iFormID);
            //clsFormatter.FormatProcessFlow(txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder, txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);
            CusDataGridViewFormat();

            ClearFields();

            if (glbInquiryID.Length > 0)
                FillDetails(glbInquiryID);
        }
        #endregion

        #region Button Action
        #region Btn New
        private void frm_sasInquiry_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void frm_sasInquiry_SF_saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateSave())
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    if (IsUpdate)  //update records
                    {
                        #region Update
                        tbl_sasInquiry oldRecord = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (ValidateForDependancies(oldRecord.Inquiry_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted //&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                                    )
                                {
                                    if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        //Inquiry Detail         
                                        //-------------------------------------
                                        try
                                        {
                                            if (clsValidate.CheckValidity_TransactionCodeLength(txtInquiryID.Text))
                                            {

                                                #region Update Old Inquiry Details

                                                List<tbl_sasInquiry_Detail> oldInqDetails =
                                                    tbl_sasInquiry_Detail.SelectAllByInquiry_ID(
                                                        txtInquiryID.Text.Trim());
                                                foreach (tbl_sasInquiry_Detail oldInq in oldInqDetails)
                                                {
                                                    string sItemCode = "",
                                                        sInquiryCode = "",
                                                        sItemSubCategoryID = "",
                                                        sItemSubCategoryID2 = "",
                                                        sItemSerialNo = "",
                                                        sItemSerialNo2 = "",
                                                        sRemarks = "";
                                                    decimal dUnitPrice = 0,
                                                        dQuantity = 0,
                                                        dWeight = 0,
                                                        dAmount = 0,
                                                        dWeightPrice = 0;
                                                    bool bHasInqInDB = false;
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {

                                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                            row.Index, "");
                                                        sInquiryCode = clsValidate.ValidateGridValue(dgvDetail,
                                                            "InquiryCode", row.Index, "default");
                                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                            row.Index, decimal.Parse("0.00"));
                                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                            row.Index, decimal.Parse("0.00"));
                                                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail,
                                                            "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail,
                                                            "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount",
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

                                                        if (oldInq.Inquiry_ID == txtInquiryID.Text.Trim() &&
                                                            oldInq.Item_ID == sItemCode && oldInq.ItemSubCategory_ID ==
                                                            sItemSubCategoryID &&
                                                            oldInq.ItemSubCategory2_ID == sItemSubCategoryID2 &&
                                                            oldInq.ItemSerialNo == sItemSerialNo &&
                                                            oldInq.ItemSerialNo2 == sItemSerialNo2)
                                                        {
                                                            bHasInqInDB = true;
                                                            dgvDetail.Rows.RemoveAt(row.Index);
                                                            break;
                                                        }

                                                    }

                                                    if (bHasInqInDB)
                                                    {
                                                        //Get Unit Price with Exchange rate to save
                                                        dUnitPrice =
                                                            clsHelpMethods_Local.getSavePrice(dUnitPrice,
                                                                txtCurrencyRate);
                                                        dWeightPrice =
                                                            clsHelpMethods_Local.getSavePrice(dWeightPrice,
                                                                txtCurrencyRate);
                                                        dAmount = clsHelpMethods_Local.getSavePrice(dAmount,
                                                            txtCurrencyRate);

                                                        oldInq.Qty = dQuantity;
                                                        oldInq.Weight = dWeight;
                                                        oldInq.UnitPrice = dUnitPrice;
                                                        oldInq.WeightPrice = dWeightPrice;
                                                        oldInq.TatalAmount = dAmount;
                                                        oldInq.Remark = sRemarks;
                                                        oldInq.IsWeightCalculation = !chkUnitPricing.Checked;
                                                        oldInq.Update();
                                                    }
                                                    else
                                                    {
                                                        oldInq.Delete();
                                                    }
                                                }

                                                #endregion

                                                #region Insert Newly Added Items

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    string sItemCode = "",
                                                        sInquiryCode = "",
                                                        sQuotationCode = "",
                                                        sJobCode = "",
                                                        sRemarks = "",
                                                        sItemSubCategoryID = "",
                                                        sItemSubCategoryID2 = "",
                                                        sItemSerialNo = "",
                                                        sItemSerialNo2 = "";
                                                    decimal dUnitPrice = 0,
                                                        dQuantity = 0,
                                                        dWeight = 0,
                                                        dAmount = 0,
                                                        dWeightPrice = 0,
                                                        dRecommendedUnitPrice = 0,
                                                        dRecommendedWeightPrice = 0,
                                                        dRecommendedAmount = 0;
                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                        row.Index, "");
                                                    sInquiryCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "InquiryCode", row.Index, "default");
                                                    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "QuotationCode", row.Index, "default");
                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                        row.Index, "default");
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail,
                                                        "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount",
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
                                                        clsHelpMethods_Local.getSavePrice(dWeightPrice,
                                                            txtCurrencyRate);
                                                    dAmount = clsHelpMethods_Local.getSavePrice(dAmount,
                                                        txtCurrencyRate);

                                                    if (sItemCode.Length > 0)
                                                    {
                                                        tbl_sasInquiry_Detail items = new tbl_sasInquiry_Detail(
                                                            clsHelpMethods_Local.GetMaxzimumLineNo_Inquiry(
                                                                txtInquiryID.Text.Trim()), txtInquiryID.Text.Trim(),
                                                            sItemCode,
                                                            sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                            sItemSerialNo2, dQuantity, 0, dWeight, 0, dUnitPrice,
                                                            dWeightPrice, 0, 0, dAmount, dRecommendedUnitPrice,
                                                            dRecommendedWeightPrice, dRecommendedAmount, sRemarks,
                                                            !chkUnitPricing.Checked);
                                                        items.Insert();
                                                    }
                                                }

                                                #endregion

                                                //-------------------------
                                                //Inquiry Order Header

                                                #region Update Inquiry Header

                                                tbl_sasInquiry detail = new tbl_sasInquiry(txtInquiryID.Text.Trim(),
                                                    dtpInquiryDate.Value, txtRemark.Text.Trim(),
                                                    txtCustomerID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(),
                                                    oldRecord.OrderRefNo_ID, txtCurrencyID.Tag.ToString(),
                                                    oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                                    oldRecord.FinancialYear_ID, oldRecord.CompanyID,
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
                                                    clsHelpMethods_Local.getSavePrice(
                                                        decimal.Parse(txtAdvanceAmount.Text.Trim()), txtCurrencyRate),
                                                    clsHelpMethods_Local.getSavePrice(
                                                        decimal.Parse(txtSubTotal_Rec.Text.Trim()), txtCurrencyRate),
                                                    clsHelpMethods_Local.getSavePrice(
                                                        decimal.Parse(txtGrandTotal_Rec.Text.Trim()), txtCurrencyRate),
                                                    oldRecord.CreateUser_ID,
                                                    clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                                    oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID,
                                                    oldRecord.PrintedUser_ID,
                                                    oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                    oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                    oldRecord.DateCreate,
                                                    clsSecurity.getServerDateTime(), oldRecord.DateChecked,
                                                    oldRecord.DateApproved, oldRecord.DateDeleted,
                                                    oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved,
                                                    oldRecord.IsFinished,
                                                    oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsSeattled,
                                                    !chkUnitPricing.Checked, oldRecord.PrintCount,
                                                    chkReverseCalculation.Checked, chkFreeOrder.Checked,
                                                    clsHelpMethods.isTaxActiveNote(txtVat),
                                                    clsHelpMethods.isTaxActiveNote(txtOtherTax),
                                                    txtBranch.Tag.ToString());
                                                detail.Update();

                                                #endregion


                                                //Attachments.Insert(iFormID, oldRecord.Inquiry_ID);
                                                //Attachments.Remove(iFormID, oldRecord.Inquiry_ID);

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                    clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                    MessageBoxIcon.Information);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID, ex);
                                            SEACCException.Show(ex);
                                        } //error may come because last row of the grid may not have information

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
                            txtInquiryID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        //create order ref number
                        glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                        tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text.Trim(), txtRouteID.Tag.ToString(), txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                        orf.Insert();

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtInquiryID.Text)) //if (txtInquiryID.TextLength > 0)
                        {
                            tbl_sasInquiry detail = new tbl_sasInquiry(txtInquiryID.Text.Trim(), dtpInquiryDate.Value, txtRemark.Text.Trim(),
                               txtCustomerID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, txtCurrencyID.Tag.ToString(),
                               "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsSecurity.CompanyID,
                               decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                               decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate),
                               clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                               clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtAdvanceAmount.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal_Rec.Text.Trim()), txtCurrencyRate),
                               clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal_Rec.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                               clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                               clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                               bHasChecked, bHasApproved, false, false, false, false, !chkUnitPricing.Checked, 0, chkReverseCalculation.Checked, chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), txtBranch.Tag.ToString());
                            detail.Insert();

                            //Inquiry Detail                                
                            #region Inquiry Details
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sRemarks = "",
                                        sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                                    decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0, dRecommendedUnitPrice = 0,
                                        dRecommendedWeightPrice = 0, dRecommendedAmount = 0;

                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                    sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                                    sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
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

                                    //Get Unit Price with Exchange rate to save
                                    dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                    dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                    dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                    if (sItemCode.Length > 0)
                                    {
                                        tbl_sasInquiry_Detail items = new tbl_sasInquiry_Detail(clsHelpMethods_Local.GetMaxzimumLineNo_Inquiry(txtInquiryID.Text.Trim()), txtInquiryID.Text.Trim(), sItemCode,
                                            sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity, 0, dWeight, 0,
                                            dUnitPrice, dWeightPrice, 0, 0, dAmount, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, !chkUnitPricing.Checked);
                                        items.Insert();
                                    }
                                }

                                catch (Exception ex)
                                {
                                    clsValidate.WriteErrorLog("", iFormID,ex);
                                    SEACCException.Show(ex);
                                }//error may come because last row of the grid may not have information
                            }
                            #endregion

                            Attachments.Insert(txtInquiryID.Text.ToString());
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Inquiry" + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                tbl_sasInquiry oldRecord = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
                if (oldRecord != null)
                    FillDetails(txtInquiryID.Text.Trim());
            }
        }
        #endregion

        #region Btn Print
        private void frm_sasInquiry_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasInquiry_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region btn Cancel
        private void frm_sasInquiry_SF_cancelButton_Click(object sender, EventArgs e)
        {
            cancelInquiry();
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_sasInquiry_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasInquiry_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasInquiry_SF_History_Click(object sender, EventArgs e)
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

        #region Btn Customer Viewer
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

        #region Btn Create Customer Order
        private void btnCreateCustomerOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInquiryID.Tag != null && txtInquiryID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasInquiry detail = tbl_sasInquiry.Select(txtInquiryID.Tag.ToString());
                    if (detail != null && detail.Inquiry_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledInquiry)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED!! \n\nUser has to Approve the Customer Order Before Create a Delivery Order.";
                            }
                        }
                        if (bAllowDetail && clsConfig.bSettleEnabledInquiry)
                        {
                            if (detail.IsSeattled)
                            {
                                MessageBox.Show("ALREADY C/O GENERATED!! \n\n But, You may Generate More Customer Order(s) to this General Inquiry.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        if (bAllowDetail)
                        {
                            frm_sasCustomerOrder frm = new frm_sasCustomerOrder(FormName.CustomerOrder);
                            frm.glbInquiryID = detail.Inquiry_ID;
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                cancelInquiry();
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
        private void frm_sasInquiry_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtInquiryID.TextLength > 0 && txtInquiryID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInquiryID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

                txtInquiryID.Tag = null;
                dtpInquiryDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtInquiryID.Text = "<Auto Generate>";
                else
                    txtInquiryID.Clear();
                if (txtInquiryID.Enabled)
                {
                    txtInquiryID.SelectAll();
                    txtInquiryID.Focus();
                }

                ucSasProcessFlow.ClearFlow();
                Attachments.Clear();
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            //clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);            
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            //Change Grid Headers
            dgvDetail.Columns["ItemSubCategoryID"].HeaderText = clsConfig.sItemSubCategory;

            dgvDetail.Columns["Weight"].ReadOnly = false;
            dgvDetail.Columns["WeightPrice"].ReadOnly = false;
            dgvDetail.Columns["Quantity"].ReadOnly = false;
            dgvDetail.Columns["UnitPrice"].ReadOnly = false;

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
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInquiryID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            txtInquiryID.Tag = null;
            txtCustomerID.Tag = null;
            txtItemID.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtOrderRefNo.Tag = null;
            txtRouteID.Tag = null;
            txtTownID.Tag = null;
            txtBranch.Tag = null;

            btnAddItem.Enabled = true;
            txtItemID.Enabled = true;

            txtCustomerID.Clear();
            txtItemID.Clear();
            txtSalesExecutiveID.Clear();
            txtRemark.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtRouteID.Clear();
            txtTownID.Clear();
            txtBranch.Clear();

            txtOrderRefNo.Clear();
            glbOrderRefNo = "";
            dtpInquiryDate.Value = clsSecurity.getServerDateTime();
            txtItemID.Clear();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkSettings2.Checked = true;
            chkFreeOrder.Checked = false;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;
            txtAdvanceAmount.Tag = 0;

            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());
            txtSubTotal.Text = "0.00";
            txtDiscount.Text = "0.00";
            txtNBT.Text = "0.00";
            txtOtherTax.Text = "0.00";
            txtVat.Text = "0.00";
            txtGrandTotal.Text = "0.00";
            txtAdvanceAmount.Text = "0.00";


            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            chkShowSettle.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;
            chkDiscount.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtInquiryID.Text = "<Auto Generate>";
            else
                txtInquiryID.Clear();
            if (txtInquiryID.Enabled)
            {
                txtInquiryID.SelectAll();
                txtInquiryID.Focus();
            }

            ucSasProcessFlow.ClearFlow();

            Attachments.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_sasInquiry detail = tbl_sasInquiry.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInquiryID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtRouteID.Tag = order.Route_ID;
                            txtTownID.Tag = order.Town_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                         //   txtRouteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(order.Route_ID));
                            txtTownID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(order.Town_ID));
                        }

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtInquiryID.Tag = detail.Inquiry_ID;

                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtInquiryID.Text = detail.Inquiry_ID;
                        txtRemark.Text = detail.Remark;
                        dtpInquiryDate.Value = detail.InquiryDate;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        chkSettings2.Checked = false;

                        if (detail.Branch_ID != "default")
                        {
                            txtBranch.Tag = detail.Branch_ID;
                            int iBranchCode = int.Parse(detail.Branch_ID);
                            txtBranch.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                        }

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
                        RefreshGrid(detail.Inquiry_ID);

                        //Asign Taxes
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
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

                        //Set Flow
                        //clsHelpMethods_Local.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                        //  txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);

                        ucSasProcessFlow.SetProcessFlowByInquiry(detail.Inquiry_ID);

                        Attachments.FillAttachments(sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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

                if (sCustomerID.Length > 0)
                {
                    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                    if (customer != null)
                    {
                        txtCustomerID.Tag = customer.Customer_ID;
                        txtCustomerID.Text = customer.CustomerName;
                        chkNBT.Checked = customer.IsNBTenable;
                        chkVat.Checked = customer.IsVATenable;
                        chkOtherTax.Checked = customer.IsSVATenable;

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
                      //      txtRouteID.Text = clsGenaralName.getName_Route(cusRoute.Route_ID);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string inquiryID, string QuotationCode, string JobID, string UomID, decimal UnitPrice, decimal WeightPrice, int LineNo, decimal TatalAmount,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, decimal dExRate)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                    if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }

                //Get Unit Price with Exchange rate to save
                UnitPrice = clsHelpMethods_Local.getDisplayPrice(UnitPrice, dExRate);
                WeightPrice = clsHelpMethods_Local.getDisplayPrice(WeightPrice, dExRate);
                TatalAmount = clsHelpMethods_Local.getDisplayPrice(TatalAmount, dExRate);

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["InquiryCode", iRow].Value = inquiryID;//add by thilina
                dgvDetail["QuotationCode", iRow].Value = QuotationCode;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina                
                dgvDetail["LineNo", iRow].Value = LineNo.ToString();
                dgvDetail["UOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(UomID));
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
                dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);

                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);

                dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sInquiryID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_sasInquiry_Detail> details = tbl_sasInquiry_Detail.SelectAllByInquiry_ID(sInquiryID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasInquiry_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, detail.Item_ID, detail.Inquiry_ID, "default", "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.Line_No,
                            detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.ItemSubCategory_ID,
                            detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, dExRate);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void RefreshGridByItemID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
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
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, sCustomerID);
                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);

                    Fill_Datagrid(iRow, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, 0, dAmount, detail.Width,
                        detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, dExRate);
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        #endregion

        #region Events keyDown
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (CheckValiditeCustomer())
                    Search_SalesExecutiveID();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && CheckValiditeCustomer())
            {
                clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(sender, new EventArgs());
            }
            else
            {
                clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
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
        private void frm_stkCustomerOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtInquiryID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionInquiry_Direct(ref txtInquiryID, chkShowSettle.Checked);
                if (txtInquiryID.Tag != null && txtInquiryID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtInquiryID.Tag.ToString());
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
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
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
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditeCustomer())
                Search_SalesExecutiveID();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            if (CheckValiditeCustomer())
            {
                clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(sender, new EventArgs());
            }
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtInquiryID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionInquiry_Direct(ref txtInquiryID, chkShowSettle.Checked);
            if (txtInquiryID.Tag != null && txtInquiryID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtInquiryID.Tag.ToString());
        }
        private void txtTownID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTownID);
        }
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRouteID);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtBranch_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerBranch();
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
                btnAddItem.Enabled = false;
                txtItemID.Enabled = false;
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
                if (sColName != "UOM" && sColName != "Quantity" && sColName != "Weight" && sColName != "UnitPrice" && sColName != "WeightPrice" && sColName != "Remarks")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                        dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                        dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
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

        #region Check Validity
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckDateValidity())
                    {
                        if (CheckOutstandingValidity())
                        {
                            if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpInquiryDate.Value.Date))
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
            return bIsOk;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerID, "CustomerName"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtOrderRefNo, "Order Ref No"))
                {
                    bStatus = true;
                }
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
                if (!clsCommon.isCurrency(txtAdvanceAmount.Text.Trim()))
                {
                    strMessage += "\n Advance Amount";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckDateValidity()
        {
            bool bStatus = true;
            try
            {
                ////backdate error
                //if (clsValidate.ValidateProcessNoteBackDate(clsAutocode.GetProcessNoteID(ProcessNote.Inquiry), dtpInquiryDate.Value))
                //{
                //    MessageBox.Show(clsFormatter.GetMessageError(MessageTypes_GenaralError.BackDateError), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    bStatus = false;
                //}
                ////forward date error
                //else if (clsValidate.ValidateProcessNoteForwardDate(clsAutocode.GetProcessNoteID(ProcessNote.Inquiry), dtpInquiryDate.Value))
                //{
                //    MessageBox.Show(clsFormatter.GetMessageError(MessageTypes_GenaralError.ForwardDateError), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    bStatus = false;
                //}
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            return bStatus;
        }
        private bool CheckOutstandingValidity()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (clsConfig.bCreditBalanceInquiry_Message) //security 1 - Message
                {
                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
                    {
                        dCreditBalance = clsHelpMethods_Local.GetCustomerCreditBalance(txtCustomerID.Tag.ToString());
                        if (txtGrandTotal.TextLength > 0)
                            dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());
                        if (dCreditBalance < dAmountDue) //Condition
                        {
                            bOk = false;
                            if (clsConfig.bCreditBalanceInquiry_Lock) //security 2 - Lock
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

            return bOk;
        }
        private bool ValidateForDependancies(string sInquiryID)
        {
            bool bValue = true;
            foreach (tbl_sasCustomerOrder_Detail oCO in tbl_sasCustomerOrder_Detail.SelectAllByInquiry_ID(sInquiryID))
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(oCO.CustomerOrder_ID);
                if (detail != null && detail.CustomerOrder_ID != "default" && !detail.IsDeleted)
                {
                    bValue = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + detail.CustomerOrder_ID + "] Customer Order is already created for this inquiry", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }

            }
            if (bValue)
            {
                //TODO - SelectAllByInquiry_ID SP Need To Create
                //foreach (tbl_sasQuotation_Detail detail in tbl_sasQuotation_Detail.SelectAllByInquiry_ID(sInquiryID).Where(p => !p.IsDeleted && p.Quotation_ID != "default"))
                //{
                //    bValue = false;
                //    MessageBox.Show("Record Cannot Be Deleted! \nA Quotation is already Created For This Inquiry", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    break;
                //}
            }
            return bValue;
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

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtTownID);
                clsCommon.ValidateForeignKey(ref txtRouteID);
                clsCommon.ValidateForeignKey(ref txtBranch);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion        

        #region Search Methods
        private void Search_JobID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.passValue_ConfirmedJobRegisterByCustomerID(txtCustomerID.Tag.ToString());
                    frmhelpsearch.ShowDialog();

                    //if (frmSearchTransaction.s_SearchText.Length > 0)
                    //    txtJobCode.Text = frmSearchTransaction.s_SearchID;
                    //if (frmSearchTransaction.s_SearchID.Length > 0)
                    //    txtJobCode.Tag = frmSearchTransaction.s_SearchID;
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomerID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                        FillDetailsCustomer(frmSearchMaster.s_SearchID);

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
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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

        private void Search_Currency()
        {
            clsSearch.Search_MasterCurrency(ref txtCurrencyID);
            if (txtCurrencyID.Tag != null)
                FillDetailsCurrency(txtCurrencyID.Tag.ToString());
            else
                FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    decimal dUnitPrice = 0, dWeightPrice = 0, dQty = 0, dWeight = 0;//dVatAmount = 0,
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
            //   frmEmail oEmail = new frmEmail();
            //   oEmail.Show();
        }
        #endregion

        #region Cancel Inquiry
        private void cancelInquiry()
        {
            try
            {
                if (txtInquiryID.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_sasInquiry detail = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
                        if (detail != null)
                        {
                            if (ValidateForDependancies(detail.Inquiry_ID))
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {

                                        // if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Inquiry : " + detail.Inquiry_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
            try
            {
                if (txtInquiryID.TextLength > 0 && txtInquiryID.Text != "<Auto Generate>")
                {

                    if (true)
                    {

                        #region Dataset
                        glb_dts_sasInquiry.Clear();
                        glb_dtsReportExport.Clear();
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicate = "",sCustomerTel=""; 
                        bool bApprovalDone = true, bCheckingDone = true;
                        if (clsHelpMethods_Local.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_SalesInquiry), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            tbl_sasInquiry oInquiry = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
                            if (oInquiry != null)
                            {
                                if (!bIsDraft)
                                {
                                    #region Validate Approval
                                    if (clsConfig.bApprovalNeedToPrintInquiry)
                                    {
                                        if (!oInquiry.IsApproved)
                                        {
                                            bApprovalDone = false;
                                            MessageBox.Show("Please Approve the Customer Order Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion

                                    #region Validate Checking
                                    if (clsConfig.bCheckingNeedToPrintInquiry)
                                    {
                                        if (!oInquiry.IsChecked)
                                        {
                                            bCheckingDone = false;
                                            MessageBox.Show("Please Check the Customer Order Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    #endregion
                                }
                                if (bApprovalDone && bCheckingDone)
                                {
                                    sCreateUser = "[ " + clsGenaralName.getName_User(oInquiry.CreateUser_ID) + " ] [ " + oInquiry.DateCreate.ToShortDateString() + " ]";
                                    if (oInquiry.CheckedUser_ID != "default")
                                        sCheckedUser = "[ " + clsGenaralName.getName_User(oInquiry.CheckedUser_ID) + " ] [ " + oInquiry.DateChecked.ToShortDateString() + " ]";
                                    if (oInquiry.ApprovedUser_ID != "default")
                                        sApprovedUser = "[ " + clsGenaralName.getName_User(oInquiry.ApprovedUser_ID) + " ] [ " + oInquiry.DateApproved.ToShortDateString() + " ]";
                                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInquiry.Customer_ID);
                                    if(oCustomer!=null)
                                    {
                                        sCustomerTel = oCustomer.Telephone;
                                    }

                                    glb_dts_sasInquiry.dt_Inquiry.Adddt_InquiryRow(oInquiry.Inquiry_ID, oInquiry.InquiryDate, oInquiry.OrderRefNo_ID, clsGenaralName.getName_Customer(oInquiry.Customer_ID),clsGenaralName.getName_SalesRep(oInquiry.Employee_ID), oInquiry.IsDeleted, "", oInquiry.Employee_ID, 0, "", oInquiry.Customer_ID, oInquiry.DiscountPercentage, oInquiry.NbtPercentage, oInquiry.VatPercentage, oInquiry.OtherTaxPercentage, oInquiry.DiscountTotal, oInquiry.NbtTotal, oInquiry.VatTotal, oInquiry.OtherTaxTotal,oInquiry.GrandTotal, sCustomerTel, clsGenaralName.getName_BranchCustomer(oInquiry.Customer_ID, int.Parse(oInquiry.Branch_ID)), oInquiry.AdvanceAmount,oInquiry.IsWeightCalculation);

                                    if (!bIsDraft)
                                    {
                                        sDuplicate = oInquiry.PrintCount > 0 ? "Duplicate Copy " + oInquiry.PrintCount : "";

                                        oInquiry.PrintCount++;
                                        oInquiry.DatePrinted = clsSecurity.getServerDateTime();
                                        oInquiry.PrintedTerminal_ID = clsSecurity.TerminalID;
                                        oInquiry.PrintedUser_ID = clsSecurity.UserIDLoged;

                                        oInquiry.Update();
                                    }

                                    foreach (tbl_sasInquiry_Detail oDInquiry in tbl_sasInquiry_Detail.SelectAllByInquiry_ID(oInquiry.Inquiry_ID))
                                    {
                                        glb_dts_sasInquiry.dt_InquiryDetail.Adddt_InquiryDetailRow(oDInquiry.Item_ID,clsGenaralName.getName_Item(oDInquiry.Item_ID), oDInquiry.Qty, clsGenaralName.getName_ItemUOMName(oDInquiry.Item_ID), oDInquiry.UnitPrice, oDInquiry.TatalAmount, oDInquiry.Inquiry_ID,clsGenaralName.getName_ItemCategorySub(oDInquiry.Item_ID));
                                    }

                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oInquiry.IsDeleted ? "CANCELLED" : "", true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true);

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
                                        }
                                    }
                                    glb_dts_sasInquiry.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                    #endregion
                                    frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                    rpt.print(sReportPath, glb_dts_sasInquiry, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_SalesInquiry));
                                }
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region Old
                        bool isDuplicate = false;//
                                                 //update receipt
                        string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                        tbl_sasInquiry oInquiry = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());//-K- // oOrder
                        if (oInquiry != null)
                        {
                            if (oInquiry.PrintCount > 0)
                                isDuplicate = true;

                            oInquiry.PrintCount++;
                            oInquiry.DatePrinted = clsSecurity.getServerDateTime();
                            oInquiry.PrintedTerminal_ID = clsSecurity.TerminalID;
                            oInquiry.PrintedUser_ID = clsSecurity.UserIDLoged;
                            oInquiry.Update();

                            sCreateUser = "[ " + clsGenaralName.getName_User(oInquiry.CreateUser_ID) + " ] [ " + oInquiry.DateCreate.ToShortDateString() + " ]";
                            if (oInquiry.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(oInquiry.CheckedUser_ID) + " ] [ " + oInquiry.DateChecked.ToShortDateString() + " ]";
                            if (oInquiry.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(oInquiry.ApprovedUser_ID) + " ] [ " + oInquiry.DateApproved.ToShortDateString() + " ]";
                        }

                        Cursor = Cursors.WaitCursor;
                        string s_Path = "", sReportTitle = "INQUIRY", sFormula = "";
                        if (txtInquiryID.TextLength > 0)
                            sFormula = "{vw_rpt_sasInquiry.inquiry_ID} = '" + txtInquiryID.Text.Trim() + "'";

                        ReportDocument RD = new ReportDocument();
                        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WD.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WD.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WOD.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WSC.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WSC.rpt";
                        else
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInquiry_WSC.rpt";

                        frm_ReportViewer viewer = new frm_ReportViewer();
                        RD.Load(s_Path);
                       // clsSecurity.LogonServer(ref RD);
                        RD.Refresh();

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                        RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                        RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(oInquiry.Customer_ID));

                        if (isDuplicate)
                            RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring("Duplicate Copy");

                        if (oInquiry.IsDeleted)
                            RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("CANCELLED");
                        else
                            RD.DataDefinition.FormulaFields["isDel"].Text = clsCommon.fncsetstring("");

                        if (clsConfig.bDirectPrint_NP_Inquiry) //Direct Print
                        {
                            RD.DataDefinition.RecordSelectionFormula = sFormula;
                            clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_SalesInquiry), ref RD);
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
                        RD.Dispose();// 
                        #endregion
                    }
                }
                else
                    MessageBox.Show("Please Select the Inquiry To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            finally
            {
                Cursor = Cursors.Default;
                glb_dts_sasInquiry.Clear();
                glb_dtsReportExport.Clear();
            }
        }
        #endregion

        private void btnBranch_Click(object sender, EventArgs e)
        {
            if (txtBranch.Tag != null && txtBranch.Tag.ToString().Trim().Length > 0)
            {
                if (txtBranch.Tag.ToString() != "default")
                {
                    // frmSetCustomerBranch frm = new frmSetCustomerBranch();
                    int iBranchCode = int.Parse(txtBranch.Tag.ToString());
                    //frm.glbBranchCode = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                    // frm.glbBranchCode = txtBranch.Tag.ToString();                
                    // frm.glbBranchName = txtBranch.Text.Trim();
                    //  frm.Show();
                }

                //if (frm.bNoAccess)
                //   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //else
                //{
                //    frm.MdiParent = this.MdiParent;
                //    frm.Show();
                //}
            }
        }

        #region User Checked Approve Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpInquiryDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtInquiryID.Text != null && txtInquiryID.TextLength > 0 && txtInquiryID.Text != "<Auto Generate>")
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

                                        tbl_sasInquiry objDO = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpInquiryDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtInquiryID.Text != null && txtInquiryID.TextLength > 0 && txtInquiryID.Text != "<Auto Generate>")
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

                                        tbl_sasInquiry objDO = tbl_sasInquiry.Select(txtInquiryID.Text.Trim());
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void UserDetails()
        {
            try
            {
                if (txtInquiryID.Text != "" || txtInquiryID.Text != "<Auto Generate>")
                {
                    tbl_sasInquiry detail = tbl_sasInquiry.Select(txtInquiryID.Text);
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

        private void txtInquiryID_TextChanged(object sender, EventArgs e)
        {

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
//        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
//}

//private void txtFlowCustomerOrder_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
//}

//private void txtFlowPInvoice_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_ProformaInvoice(sender, e, glbOrderRefNo);
//}

//private void txtFlowProductionJob_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
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
//private void txtFlowSalesReturned_MouseClick(object sender, MouseEventArgs e)
//{
//    if (glbOrderRefNo.Length > 0)
//        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
//}
#endregion