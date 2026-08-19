using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using Digiteq_Logic;
using Digiteq.DataSets;
using Digiteq.DataSets.SAS;
using System.IO;
using System.Drawing;

namespace Digiteq
{
    public partial class frm_sasCustomerOrder : SEACC_Form
    {
        #region Variables
        bool isTemp = false;

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInquiryID = "", glbCustomerOrderID = "", glbQuotationID = "";

        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        dts_sasCustomerOrder glb_dts_sasCustomerOrder = new dts_sasCustomerOrder();

        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;


        //for handle Duplicate Item  Validations
        public DataTable dt_ItemGrouped = new DataTable();
        #endregion

        #region Form Load
        public frm_sasCustomerOrder(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();

            bHasPermissionToFreeIssures = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_FreeIssues));
            bHasPermissionToLineDiscount = clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.Invoice_LineDiscount));
        }

        private void frmCustomerOrder_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //if the order genarated from a inquiry
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
                tbl_sasQuotation detail = tbl_sasQuotation.Select(glbQuotationID);
                if (detail != null)
                {
                    txtQuotationID.Tag = detail.Quotation_ID;
                    btnAddQuotation_Click(sender, new EventArgs());
                }
            }
            else if (glbCustomerOrderID.Length > 0)
            {
                FillDetails(glbCustomerOrderID);
            }

            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                btnCreateDeliveryOrder.Text = "Invoice";
            else
                btnCreateDeliveryOrder.Text = "D/O  ";
        }
        #endregion

        #region Btn New
        private void frm_sasCustomerOrder_SF_newButton_Click(object sender, EventArgs e)
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
                        if (txtJobCode.Text != "")
                            txtJobCode.Clear();
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Btn Save
        private void frm_sasCustomerOrder_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (ValidateSave())
            {
                bool bFillDetails = false;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    //bool bIsOK = true;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    #region Check Customer outstanding credit period

                    #endregion

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_sasCustomerOrder oldRecord = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (ValidateForDependancies(oldRecord.CustomerOrder_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsFinished && !oldRecord.IsApproved && !oldRecord.IsDeleted && !oldRecord.IsDoneProductionJob //&& clsValidate.CheckPostingValidity(oldRecord.PostingStatus_ID)
                                    )
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtCustomerOrderID.Text))
                                        {
                                            clsLog.Process_Modify(iFormID,
                                                clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder),
                                                oldRecord.CustomerOrder_ID, "Customer Order");

                                            #region Reverce Old Co items

                                            List<tbl_sasCustomerOrder_Detail> oldCoDetails =
                                                tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(
                                                    txtCustomerOrderID.Text.Trim());
                                            foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                                            {
                                                #region Update Inquiry/Quotation

                                                if (oldCoDetail.Inquiry_ID != "default")
                                                {
                                                    tbl_sasInquiry_Detail inqItem =
                                                        tbl_sasInquiry_Detail.Select(oldCoDetail.Inquiry_ID,
                                                            oldCoDetail.Item_ID, oldCoDetail.ItemSubCategory_ID,
                                                            oldCoDetail.ItemSubCategory2_ID, oldCoDetail.ItemSerialNo,
                                                            oldCoDetail.ItemSerialNo2);
                                                    if (inqItem != null)
                                                    {
                                                        if (chkUnitPricing.Checked)
                                                            inqItem.QtySettle = inqItem.QtySettle - oldCoDetail.Qty;
                                                        else
                                                            inqItem.WeightSettle =
                                                                inqItem.WeightSettle - oldCoDetail.Weight;
                                                        inqItem.Update();
                                                        clsProcessMethods.SetSettle_Inquiry(oldCoDetail.Inquiry_ID,
                                                            chkUnitPricing);
                                                    }
                                                }

                                                if (oldCoDetail.Quotation_ID != "default")
                                                {
                                                    tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.Select(
                                                        oldCoDetail.Line_No, oldCoDetail.Quotation_ID,
                                                        oldCoDetail.Item_ID, oldCoDetail.ItemSubCategory_ID,
                                                        oldCoDetail.ItemSubCategory2_ID, oldCoDetail.ItemSerialNo,
                                                        oldCoDetail.ItemSerialNo2);
                                                    if (inqItem != null)
                                                    {
                                                        if (chkUnitPricing.Checked)
                                                            inqItem.QtySettle_CustomerOrder =
                                                                inqItem.QtySettle_CustomerOrder - oldCoDetail.Qty;
                                                        else
                                                            inqItem.WeightSettle_CustomerOrder =
                                                                inqItem.WeightSettle_CustomerOrder - oldCoDetail.Weight;
                                                        inqItem.Update();
                                                        clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(
                                                            oldCoDetail.Quotation_ID, chkUnitPricing);
                                                    }
                                                }

                                                #endregion

                                                #region Update Prod Apparel BoM

                                                //Revise BOM Sales => CO_ID
                                                if (CheckStatus_UpdateApparelBoM(oldRecord.IsChecked,
                                                    oldRecord.IsApproved))
                                                    Apparel_BoM_Update("default", oldCoDetail.Job_ID);

                                                #endregion

                                                oldCoDetail.Delete();
                                            }

                                            #endregion

                                            #region Insert Newly Added Data

                                            //int iLineNo = 0; 
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
                                                    sItemSerialNo2 = "",
                                                    sLineNo = "";
                                                decimal dUnitPrice = 0,
                                                    dQuantity = 0,
                                                    dWeight = 0,
                                                    dAmount = 0,
                                                    dWeightPrice = 0,
                                                    dDiscountPresentage = 0,
                                                    dDiscountValue = 0,
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
                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index,
                                                    decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
                                                    row.Index, decimal.Parse("0.00"));
                                                dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice",
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
                                                    clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                dWeightPrice =
                                                    clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                                                dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                                                if (sItemCode.Length > 0)
                                                {
                                                    tbl_sasCustomerOrder_Detail items = new tbl_sasCustomerOrder_Detail(
                                                        int.Parse(sLineNo), txtCustomerOrderID.Text.Trim(), sItemCode,
                                                        sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                        sItemSerialNo2, txtPurchaseOrder.Text.Trim(), sInquiryCode,
                                                        "default", sQuotationCode, sJobCode, dQuantity, 0, 0,
                                                        dWeight, 0, 0, dUnitPrice, dWeightPrice, bIsFreeIssue,
                                                        dDiscountPresentage, dDiscountValue, dAmount,
                                                        dRecommendedUnitPrice, dRecommendedWeightPrice,
                                                        dRecommendedAmount, sRemarks, false, !chkUnitPricing.Checked);
                                                    items.Insert();

                                                    //iLineNo++;

                                                    #region Update Inquiry/Quotation

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

                                                    if (sQuotationCode != "default")
                                                    {
                                                        tbl_sasQuotation_Detail inqItem =
                                                            tbl_sasQuotation_Detail.Select(int.Parse(sLineNo),
                                                                sQuotationCode, sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                        if (chkUnitPricing.Checked)
                                                            inqItem.QtySettle_CustomerOrder =
                                                                inqItem.QtySettle_CustomerOrder + dQuantity;
                                                        else
                                                            inqItem.WeightSettle_CustomerOrder =
                                                                inqItem.WeightSettle_CustomerOrder + dWeight;
                                                        inqItem.Update();
                                                        clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(
                                                            sQuotationCode, chkUnitPricing);
                                                    }

                                                    #endregion

                                                    #region MyRegion

                                                    //Update BOM Sales => CO_ID
                                                    if (CheckStatus_UpdateApparelBoM(oldRecord.IsChecked,
                                                        oldRecord.IsApproved))
                                                        Apparel_BoM_Update(txtCustomerOrderID.Text.Trim(), sJobCode);

                                                    #endregion

                                                }
                                            }

                                            #endregion

                                            #region Update Co Header

                                            tbl_sasCustomerOrder detail = new tbl_sasCustomerOrder(
                                                txtCustomerOrderID.Text.Trim(), dtpCustomerOrderDate.Value,
                                                txtRemark.Text.Trim(),
                                                txtAddressDelivery.Text.Trim(), dtpDeliveryDate.Value,
                                                oldRecord.OrderRefNo_ID, txtCustomerID.Tag.ToString(),
                                                txtPurchaseOrder.Text.Trim(),
                                                txtInquiryCode.Tag.ToString(), "default", txtQuotationID.Tag.ToString(),
                                                txtJobCode.Tag.ToString(), txtStoreID.Tag.ToString(),
                                                txtSalesExecutiveID.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                                                oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                                oldRecord.FinancialYear_ID, txtSalesNoteType.Tag.ToString(),
                                                decimal.Parse(txtCurrencyRate.Text.Trim()),
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()),
                                                decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                decimal.Parse(txtPercentageVat.Text.Trim()),
                                                decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()),
                                                    txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()),
                                                    txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtAdvanceAmount.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtSubTotal_Rec.Text.Trim()), txtCurrencyRate),
                                                clsHelpMethods.getSavePrice(
                                                    decimal.Parse(txtGrandTotal_Rec.Text.Trim()), txtCurrencyRate),
                                                oldRecord.CreateUser_ID,
                                                clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID,
                                                oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID,
                                                oldRecord.PrintedUser_ID,
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
                                                clsHelpMethods.isTaxActiveNote(txtOtherTax),
                                                txtCustomerBranchID.Tag.ToString(),
                                                decimal.Parse(txtComRate.Text.Trim()),
                                                ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, oldRecord.CompanyID,
                                                oldRecord.CompanyBranch_ID, int.Parse(lblRoute.Tag.ToString()));
                                            detail.Update();

                                            #endregion

                                            #region Order Ref

                                            if (oldRecord.OrderRefNo_ID.Length > 0 ||
                                                oldRecord.OrderRefNo_ID != "default")
                                            {
                                                tbl_zOrderRefNo oOrderRefNo =
                                                    tbl_zOrderRefNo.Select(oldRecord.OrderRefNo_ID);
                                                if (oOrderRefNo != null)
                                                {
                                                    tbl_zOrderRefNo orf = new tbl_zOrderRefNo(oOrderRefNo.OrderRefNo_ID,
                                                        oOrderRefNo.OrderRefNo, oOrderRefNo.Route_ID,
                                                        txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(),
                                                        txtCustomerID.Tag.ToString(), oOrderRefNo.IsActive);
                                                    orf.Update();
                                                }
                                            }

                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                                            isTemp = false;

                                            #region CO line discount alert

                                            bool bDisAmnt = false;
                                            foreach (tbl_sasCustomerOrder_Detail oldCoDetail in
                                                tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(
                                                    txtCustomerOrderID.Text.Trim()))
                                            {
                                                if (oldCoDetail.DiscountAmount != 0)
                                                {
                                                    bDisAmnt = true;
                                                    break;
                                                }
                                            }

                                            if (bDisAmnt)
                                                clsAlerts_Email.Email_CO_DiscountedItem(txtCustomerOrderID.Text.Trim(),
                                                    enum_Alerts.CustomerOrderDiscountedItemCreate);

                                            #endregion
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
                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCode, txtSalesNoteType.Tag.ToString(), ref txtCustomerOrderID);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtCustomerOrderID.Text)) //if (txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
                        {
                            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                            if (oCO == null)
                            {
                                #region Order Ref
                                if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                {
                                    glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                                    tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-", "default", txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                                    orf.Insert();
                                }
                                #endregion

                                //change foregin key
                                #region Customer Order Header
                                tbl_sasCustomerOrder detail = new tbl_sasCustomerOrder(txtCustomerOrderID.Text.Trim(), dtpCustomerOrderDate.Value, txtRemark.Text.Trim(),
                            txtAddressDelivery.Text.Trim(), dtpDeliveryDate.Value, glbOrderRefNo, txtCustomerID.Tag.ToString(), txtPurchaseOrder.Text.ToString(),
                            txtInquiryCode.Tag.ToString(), "default", txtQuotationID.Tag.ToString(), txtJobCode.Tag.ToString(), txtStoreID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                            "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtSalesNoteType.Tag.ToString(),
                            decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                            decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate),
                            clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate),
                            clsHelpMethods.getSavePrice(decimal.Parse(txtAdvanceAmount.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal_Rec.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal_Rec.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(),
                            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, false, false,
                            !chkUnitPricing.Checked, 0, chkReverseCalculation.Checked, chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), txtCustomerBranchID.Tag.ToString(), decimal.Parse(txtComRate.Text.Trim()), ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, clsSecurity.CompanyID, clsSecurity.BranchID, int.Parse(lblRoute.Tag.ToString()));
                                detail.Insert();
                                #endregion

                                #region Customer Order Detail
                                //int iLineNo = 0;
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sLineNo = "";
                                        decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0, dDiscountPresentage = 0, dDiscountValue = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0;
                                        bool bIsFreeIssue = false;

                                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                        sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                                        sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
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

                                        //Get Unit Price with Exchange rate to save
                                        dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                        dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                                        dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                                        if (sItemCode.Length > 0)
                                        {
                                            tbl_sasCustomerOrder_Detail items = new tbl_sasCustomerOrder_Detail(int.Parse(sLineNo), txtCustomerOrderID.Text.Trim(), sItemCode,
                                                          sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtPurchaseOrder.Text.Trim(), sInquiryCode, "default", sQuotationCode, sJobCode, dQuantity, 0, 0,
                                                          dWeight, 0, 0, dUnitPrice, dWeightPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, false, !chkUnitPricing.Checked);
                                            items.Insert();
                                            //iLineNo++;

                                            #region Update Inquiry/Quotqtion
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
                                            if (sQuotationCode != "default")
                                            {
                                                tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.Select(int.Parse(sLineNo), sQuotationCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                if (inqItem != null)
                                                {
                                                    if (chkUnitPricing.Checked)
                                                        inqItem.QtySettle_CustomerOrder = inqItem.QtySettle_CustomerOrder + dQuantity;
                                                    else
                                                        inqItem.WeightSettle_CustomerOrder = inqItem.WeightSettle_CustomerOrder + dWeight;
                                                    inqItem.Update();
                                                    clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(sQuotationCode, chkUnitPricing);
                                                }
                                            }
                                            #endregion

                                            #region Update Prod Apparel BOm
                                            //Update BOM Sales => CO_ID
                                            if (CheckStatus_UpdateApparelBoM(detail.IsChecked, detail.IsApproved))
                                                Apparel_BoM_Update(txtCustomerOrderID.Text.Trim(), sJobCode);
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        SEACCException.Show(ex);
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }//error may come because last row of the grid may not have information
                                }
                                #endregion



                                clsAlerts_Email.Email_CO(txtCustomerOrderID.Text.Trim(), enum_Alerts.CustomerOrderCreate);

                                Attachments.Insert(txtCustomerOrderID.Text);

                                bFillDetails = true;

                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                                bool bDisAmnt = false;
                                foreach (tbl_sasCustomerOrder_Detail oldCoDetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim()))
                                {
                                    if (oldCoDetail.DiscountAmount != 0)
                                    {
                                        bDisAmnt = true;
                                        break;
                                    }
                                }

                                if (bDisAmnt)
                                    clsAlerts_Email.Email_CO_DiscountedItem(txtCustomerOrderID.Text.Trim(), enum_Alerts.CustomerOrderDiscountedItemCreate);
                            }
                            else
                                MessageBox.Show("This ID is alredy added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Customer Order " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID, ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                    if (bFillDetails)
                    {
                        tbl_sasCustomerOrder oldRecord = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                        if (oldRecord != null)
                            FillDetails(txtCustomerOrderID.Text.Trim());
                    }
                }
            }
        }
        #endregion

        #region Btn Cancel
        private void frm_sasCustomerOrder_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerOrderID.Text.Trim().Length > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                            if (detail != null)
                            {
                                if (ValidateForDependancies(detail.CustomerOrder_ID))
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            //if (clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                            {
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Customer Order : " + detail.CustomerOrder_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    //////Update Other Tables 
                                                    #region Update Other Tables
                                                    List<tbl_sasCustomerOrder_Detail> Codetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());
                                                    foreach (tbl_sasCustomerOrder_Detail Codetail in Codetails)
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
                                                                    if (!Codetail.IsWeightCalculation)
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
                                                    List<tbl_sasCustomerOrder_Detail> Qodetails = tbl_sasCustomerOrder_Detail.SelectAllByQuotation_ID(txtQuotationID.Text.Trim());
                                                    foreach (tbl_sasCustomerOrder_Detail Qodetail in Qodetails)
                                                    {
                                                        if (Qodetail.Item_ID != null)
                                                        {
                                                            //////Unsettle Quotation
                                                            #region Unsettle Quotation
                                                            if (Qodetail.Quotation_ID != null && Qodetail.Quotation_ID != "default")
                                                            {
                                                                tbl_sasQuotation_Detail QuoItem = tbl_sasQuotation_Detail.Select(Qodetail.Line_No, Qodetail.Inquiry_ID, Qodetail.Item_ID, Qodetail.ItemSubCategory_ID,
                                                                    Qodetail.ItemSubCategory2_ID, Qodetail.ItemSerialNo, Qodetail.ItemSerialNo2);
                                                                if (QuoItem != null)
                                                                {
                                                                    if (!Qodetail.IsWeightCalculation)
                                                                        QuoItem.QtySettle_CustomerOrder = QuoItem.QtySettle_CustomerOrder - Qodetail.Qty;
                                                                    else
                                                                        QuoItem.WeightSettle_CustomerOrder = QuoItem.WeightSettle_CustomerOrder - Qodetail.Weight;
                                                                    QuoItem.Update();
                                                                    clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(Qodetail.Inquiry_ID, chkUnitPricing);
                                                                }
                                                            }
                                                            #endregion
                                                        }
                                                    }
                                                    #endregion

                                                    detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                    detail.DateDeleted = clsSecurity.getServerDateTime();
                                                    detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                    //-K-

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
        private void frm_sasCustomerOrder_SF_printButton_Click(object sender, EventArgs e)
        {
            print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasCustomerOrder_SF_draftButton_Click(object sender, EventArgs e)
        {
            print(true);
        }
        #endregion

        #region Btn Checked, Approved n History Details
        private void frm_sasCustomerOrder_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasCustomerOrder_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasCustomerOrder_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
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
                        if (detail.IsSalesItem)
                        {
                            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0 && txtCustomerID.Tag.ToString().Trim() != "default")
                            {
                                if (clsValidate.Validate_CustomerWise_ItemPricing_Enable(txtCustomerID.Tag.ToString().Trim(), detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Tag.ToString(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Tag.ToString()))
                                {
                                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                                    RefreshGridByItemID(detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Tag.ToString(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Tag.ToString());
                                }
                            }
                            else
                                MessageBox.Show("Please Select The Customer Before Add Items", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Please Select a sales item..!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Btn Production Job
        private void btnProductionJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetail.SelectedCells.Count > 0 && dgvDetail.SelectedCells[0].RowIndex >= 0)
                {

                    string sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", dgvDetail.SelectedCells[0].RowIndex, "0");
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", dgvDetail.SelectedCells[0].RowIndex, "");
                    string sItemSubCategoryID = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID", dgvDetail.SelectedCells[0].RowIndex, "default");
                    string sItemSubCategoryID2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSubCategoryID2", dgvDetail.SelectedCells[0].RowIndex, "default");
                    string sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", dgvDetail.SelectedCells[0].RowIndex, "0");
                    string sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", dgvDetail.SelectedCells[0].RowIndex, "0");

                    tbl_sasCustomerOrder_Detail detail = tbl_sasCustomerOrder_Detail.Select(int.Parse(sLineNo), txtCustomerOrderID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                    if (detail != null)
                    {
                        //if (detail.Job_ID != "default")
                        //{
                        //    frm_pmsProductionJobRegister frm = new frm_pmsProductionJobRegister();
                        //    if (frm.bNoAccess)
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    else
                        //    {
                        //        frm.glbCustomerOrderID = txtCustomerOrderID.Text.Trim();
                        //        frm.glbLineNo = dgvDetail.SelectedCells[0].RowIndex;
                        //        frm.glbItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", dgvDetail.SelectedCells[0].RowIndex, "");
                        //        frm.glbCustomerOrderQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", dgvDetail.SelectedCells[0].RowIndex, decimal.Parse("0.00"));
                        //        frm.glbItemSubCategoryID = sItemSubCategoryID;
                        //        frm.glbItemSubCategoryID2 = sItemSubCategoryID2;
                        //        frm.glbItemSerialNo = sItemSerialNo;
                        //        frm.glbItemSerialNo2 = sItemSerialNo2;
                        //        if (txtOrderRefNo.Tag != null && txtOrderRefNo.Tag.ToString().Trim().Length > 0)
                        //            frm.glbOrderRefNo = txtOrderRefNo.Tag.ToString();
                        //        else
                        //            frm.glbOrderRefNo = "default";
                        //        frm.ShowDialog();
                        //    }
                        //}
                        //else
                        //    MessageBox.Show("User Cannot Create A Production Job For This Item.... Please Select The Item With A Job Number", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        #region Btn Delivery Order
        private void btnCreateDeliveryOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCustomerOrderID.Tag != null && txtCustomerOrderID.Tag.ToString().Trim().Length > 0)
                {
                    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Tag.ToString());
                    if (detail != null && detail.CustomerOrder_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";
                        if (clsConfig.bApprovalEnabledCustomerOrder)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Customer Order Before Create an Delivery Order";
                            }
                        }

                        if (bAllowDetail)
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            {
                                frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                                frm.glbCustomerOrderID = detail.CustomerOrder_ID;
                                frm.glbOrderRefNo = detail.OrderRefNo_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, (this.Parent as Form).MdiParent);
                            }
                            else
                            {
                                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                                frm.glbCustomerOrderID = detail.CustomerOrder_ID;
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

                        FillDetailsCustomer(detail.Customer_ID);

                        if (detail.Branch_ID != "default")
                        {
                            tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(detail.Customer_ID, detail.Branch_ID != "default" ? int.Parse(detail.Branch_ID) : -1);
                            if (oBranch != null)
                            {
                                txtCustomerBranchID.Text = oBranch.BranchName;
                                txtCustomerBranchID.Tag = detail.Branch_ID;

                                lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(oBranch.Route_ID);
                                lblRoute.Tag = oBranch.Route_ID;
                            }
                        }

                        //add order ref detail
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;

                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByQuotation(detail.Quotation_ID);

                        //add item details
                        RefreshGridByQuotationID(detail.Quotation_ID);

                        btnAddQuotation.Enabled = false;
                        txtQuotationID.Enabled = false;
                        btnAddJobCode.Enabled = false;
                        txtJobCode.Enabled = false;
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
                        //add order ref detail
                        glbInquiryID = detail.Inquiry_ID;
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

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

                                RefreshGridByJobID(oItem.Item_ID, oItem.ItemCategorySub_ID, "default", "0", "0", oProdJob.ProdJob_ID, clsProcessMethods.GetProdApparel_ItemUnitPrice_FromBoM(oProdJob.ProdJob_ID));
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

                                RefreshGridByJobID(oItem.Item_ID, oItem.ItemCategorySub_ID, "default", "0", "0", oProdJob.ProdJob_ID, clsProcessMethods.GetProdPharma_ItemUnitPrice_FromBoM(oProdJob.ProdJob_ID));
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

        #region Btn Temp
        private void frm_sasCustomerOrder_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
            {
                isTemp = true;
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCustomerOrderID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);

                txtCustomerOrderID.Tag = null;
                dtpCustomerOrderDate.Value = clsSecurity.getServerDateTime();

                //Reset User Details
                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtCustomerOrderID, IsUpdate);

                if (txtCustomerOrderID.Enabled)
                {
                    txtCustomerOrderID.SelectAll();
                    txtCustomerOrderID.Focus();
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
                    ///./   frmSetCustomerBranch frm = new frmSetCustomerBranch();
                    int iBranchCode = int.Parse(txtCustomerBranchID.Tag.ToString());
                    //frm.glbBranchCode = clsCommon.GetForeignKeyValue(clsGenaralName.getName_BranchCustomer(txtCustomerID.Tag.ToString(), iBranchCode));
                    //   frm.glbBranchCode = txtCustomerBranchID.Tag.ToString();
                    //   frm.glbBranchName = txtCustomerBranchID.Text.Trim();
                    //   frm.Show();
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

            //Grid Locks
            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_CO ? true : false;
            dgvDetail.Columns["Quantity"].ReadOnly = clsConfig.bEnableGridLock_Quantity_CO ? true : false;

            //Line Discount
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

            //Free Issue
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
        //private void CreateDataTable()
        //{
        //    dt_UserDetails.Columns.Add("usertype", typeof(string));
        //    dt_UserDetails.Columns.Add("Column1", typeof(string));
        //    dt_UserDetails.Columns.Add("user", typeof(string));
        //    dt_UserDetails.Columns.Add("Column2", typeof(string));
        //    dt_UserDetails.Columns.Add("datetime", typeof(string));
        //    //dgvUserDetails.DataSource = dt_UserDetails.DefaultView;

        //    //DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
        //    ////this.dgvUserDetails["action", 0] = cell;
        //    ////DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
        //    ////DataGridViewButtonCell cell = new DataGridViewButtonCell();
        //    //this.dgvUserDetails["action", 1] = cell;
        //}
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            isTemp = false;
            x2.Enabled = true;
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCustomerOrderID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

            cmbItemPrice.Enabled = true;

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            //clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            //clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            //clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            //clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);


            btnAddQuotation.Enabled = true;
            txtQuotationID.Enabled = true;
            btnAddJobCode.Enabled = true;
            txtJobCode.Enabled = true;

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


            txtCustomerOrderID.Tag = null;
            txtCustomerID.Tag = null;
            txtItemID.Tag = null;
            txtQuotationID.Tag = null;
            //txtInvoiceID.Tag = null;            
            txtSalesExecutiveID.Tag = null;
            txtJobCode.Tag = null;
            txtInquiryCode.Tag = null;
            txtItemSubCategory.Tag = null;
            txtOrderRefNo.Tag = null;
            lblRoute.Tag = null;
            txtTownID.Tag = null;
            txtStoreID.Tag = null;
            txtCustomerBranchID.Tag = null;
            txtSalesNoteType.Tag = null;

            lblRoute.Text = "";
            txtCustomerID.Clear();
            txtItemID.Clear();
            txtQuotationID.Clear();
            txtInquiryCode.Clear();
            txtOrderRefNo.Clear();
            glbOrderRefNo = "";
            txtJobCode.Clear();
            txtSalesExecutiveID.Clear();
            txtAddressDelivery.Clear();
            txtRemark.Clear();
            txtPurchaseOrder.Clear();
            txtOrderRefNo.Clear();
            dtpDeliveryDate.Value = clsSecurity.getServerDateTime();
            dtpCustomerOrderDate.Value = clsSecurity.getServerDateTime();
            txtItemID.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            txtTownID.Clear();
            txtStoreID.Clear();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkShowSettle.Checked = false;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            txtCustomerBranchID.Clear();
            txtSalesNoteType.Clear();

            dtpCustomerOrderDate.Enabled = !clsConfig.bLock_TransactionDate_SAS;

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


            txtComRate.Text = "0.00";

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

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
            chkReverseCalculation.Enabled = true;
            chkFreeOrder.Checked = false;
            chkSettings2.Checked = true;
            chkPrintOriginal.Checked = false;

            dt_ItemGrouped.Clear();
            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            string sTmpStoreID = "", sTmpStoreName = "";
            if (clsProcessMethods.getStore_MainStore_ByBranchID(clsSecurity.BranchID, ref sTmpStoreID, ref sTmpStoreName))
            {
                txtStoreID.Tag = sTmpStoreID;
                txtStoreID.Text = sTmpStoreName;
            }

            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtCustomerOrderID, IsUpdate);

            if (txtCustomerOrderID.Enabled)
            {
                txtCustomerOrderID.SelectAll();
                txtCustomerOrderID.Focus();
            }

            ucSasProcessFlow.ClearFlow();
            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sCustomerOrderID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_sasCustomerOrder_Detail> details = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasCustomerOrder_Detail detail in details)
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

                        Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.Inquiry_ID, detail.Quotation_ID, detail.Job_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount,
                             item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, "0", detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID,
                            detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
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

                        //var MaxID = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                        Fill_Datagrid(true, iRow, detail.Line_No, item.Item_ID, detail.Inquiry_ID, detail.Quotation_ID, "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount, item.Width,
                            item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_CustomerOrder), (detail.Qty - detail.QtySettle_CustomerOrder), "N", detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID,
                            detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByItemID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
                int iRow;
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                tbl_genItemMaster_Pricing oItemF = tbl_genItemMaster_Pricing.Select(sItemID);
                if (detail != null && oItemF != null)
                {
                    decimal dExRate = 0;
                    if (txtCurrencyRate.Text.Trim().Length > 0)
                        dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = 1;
                    // decimal   dAmount = oItemF.SellingPrice1 * dQty;
                    decimal dWeight = clsHelpMethods.GetWeightByItemID(detail.Item_ID, 1);
                    //    decimal dUnitPrice = 0;

                    #region get unit price
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, txtCustomerID.Tag.ToString());
                    #endregion

                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);

                    bool bHasSettledBefore = true;

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(false, iRow, maxLineNo + 1, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, 0, detail.Width,
                        detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, "N", sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, bHasSettledBefore, dExRate);
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByJobID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2, string sProdBoM, decimal dUnitPrice)
        {
            try
            {
                int iRow;
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
                    decimal dWeight = clsHelpMethods.GetWeightByItemID(detail.Item_ID, 1);
                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);
                    bool bHasSettledBefore = true;

                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                    Fill_Datagrid(true, iRow, maxLineNo + 1, detail.Item_ID, "default", "default", sProdBoM, detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, dAmount, detail.Width,
                        detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, "N", sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, bHasSettledBefore, dExRate);
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
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
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0)
                            bHasSettledBefore = true;

                        Fill_Datagrid(true, iRow, detail.Line_No, item.Item_ID, detail.Inquiry_ID, "default", "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount, item.Width,
                            item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle), (detail.Qty - detail.QtySettle), "N", detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID,
                            detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
                CalcualteSubTotal();
                CalculateTaxesAndGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCustomerOrderID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
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
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtJobCode.Tag = detail.Job_ID;
                        txtCustomerOrderID.Tag = detail.CustomerOrder_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtStoreID.Tag = detail.Store_ID;
                        txtInquiryCode.Tag = detail.Inquiry_ID;
                        txtInquiryCode.Text = detail.Inquiry_ID != "default" ? detail.Inquiry_ID : "";

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

                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                        txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));

                        txtCustomerOrderID.Text = detail.CustomerOrder_ID;
                        txtRemark.Text = detail.Remark;
                        txtPurchaseOrder.Text = detail.PurchaseOrder_ID;
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        dtpDeliveryDate.Value = detail.DeliveryDate;
                        dtpCustomerOrderDate.Value = detail.CustomerOrderDate;
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        chkFreeOrder.Checked = detail.IsFreeOrder;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        chkSettings2.Checked = false;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

                        #region Customer Branch and Route
                        if (detail.Branch_ID != "default")
                        {
                            txtCustomerBranchID.Text = clsGenaralName.getName_BranchCustomer(detail.Customer_ID, int.Parse(detail.Branch_ID));
                            txtCustomerBranchID.Tag = detail.Branch_ID;
                            lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(detail.Route_ID);
                            lblRoute.Tag = detail.Route_ID;
                        }
                        #endregion

                        //fill item details
                        RefreshGrid(detail.CustomerOrder_ID);

                        //Assign Taxes
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
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

                        Attachments.FillAttachments(sID);//attachment

                        ucSasProcessFlow.SetProcessFlowByCustomerOrder(detail.CustomerOrder_ID);//process flow
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtAddressDelivery.Clear();

                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(sCustomerID);
                if (customer != null)
                {
                    txtCustomerID.Tag = customer.Customer_ID;
                    txtCustomerID.Text = customer.CustomerName;
                    txtAddressDelivery.Text = customer.AddressRegister;

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
                        FillDetailsCurrency(customer.Currency_ID);

                    chkOtherTax.Checked = customer.IsSVATenable ? true : false;
                    chkVat.Checked = customer.IsVATenable ? true : false;
                    chkNBT.Checked = customer.IsNBTenable ? true : false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Fill Tax Detail By Quotation
        private void FillTaxDetailByQuotation(string sQuotationID)
        {
            try
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(sQuotationID);
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

        #region Fill Datagrid
        private void Fill_Datagrid(bool IsUpdateMode, int iRow, int lineNo, string ItemID, string inquiryID, string QuotationCode, string JobID, string UomID, decimal UnitPrice, decimal WeightPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
            decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string sItemStatus, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled, decimal dExRate)
        {
            try
            {
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
                            sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

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

                //Get Unit Price with Exchange rate to save
                UnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsHelpMethods.getDisplayPrice(UnitPrice, dExRate));
                WeightPrice = clsHelpMethods.getDisplayPrice(WeightPrice, dExRate);
                GrossTotal = clsHelpMethods.getDisplayPrice(GrossTotal, dExRate);

                dgvDetail["LineNo", iRow].Value = lineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                string sPLU = clsHelpMethods.GetPLU(txtCustomerID.Tag.ToString(), ItemID);
                dgvDetail["ItemName", iRow].Value = sPLU == "" || sPLU == "-" ? clsGenaralName.getName_Item(ItemID) : clsGenaralName.getName_Item(ItemID) + " - [" + sPLU + "]";
                dgvDetail["InquiryCode", iRow].Value = inquiryID;//add by thilina
                dgvDetail["QuotationCode", iRow].Value = QuotationCode;//add by thilina
                dgvDetail["JobCode", iRow].Value = JobID;//add by thilina              
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(UomID);
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;
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
                dgvDetail["Gusset", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Gusset);

                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                if (isNewItem)
                {
                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                    dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);
                }


                dgvDetail["Free", iRow].Value = isFreeItem;
                dgvDetail["DiscuntPresentage", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountPresentage);
                dgvDetail["DiscuntPresentage", iRow].Tag = DiscountPresentage;
                dgvDetail["DiscountValue", iRow].Value = isFreeItem ? "" : clsFormatter.FormatDecimalPlaces_UnitPrice(DiscountAmount);
                dgvDetail["DiscountValue", iRow].Tag = DiscountAmount;
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        #region Check Validity
        private bool ValidateSave()
        {
            //For CheckItemSettleValidity and  CheckStockValidity
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            bool bIsOk = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
                    {
                        if (clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                        {
                            if (CheckProductionJobAvailbility())
                            {
                                if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                                {
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpCustomerOrderDate.Value.Date))
                                    {
                                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                        {
                                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                            {
                                                if (CheckGrandTotal_Minus())
                                                {
                                                    if (clsHelpMethods.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                                                        bIsOk = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            //  }
                            // }
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
                if (clsValidate.ValidateTextBox_EmptyValue(txtCustomerBranchID, "Customer Branch ID"))
                {
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store"))
                        {
                            bStatus = true;
                        }
                    }
                }
            }

            if (txtInquiryCode.Tag == null)
                txtInquiryCode.Tag = "default";
            return bStatus;
        }
        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sItemCode = "", sInquiryCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dQuantity = 0, dWeight = 0;


            if (!clsAutocode.getItemExceed(ConfigItemExceedLock.CustomerOrder))
            {
                foreach (DataRow row in dt_ItemGrouped.Rows)
                {
                    try
                    {
                        sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "");
                        sInquiryCode = clsValidate.ValidateRowValue(row, "InquiryCode", "default");
                        dQuantity = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateRowValue(row, "Weight", decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateRowValue(row, "ItemSubCategoryID", "default");
                        sItemSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
                        sItemSerialNo = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
                        sItemSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

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
                        SEACCException.Show(ex);
                        clsValidate.WriteErrorLog("", iFormID, ex);
                        //SEACCException.Show(ex);MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (!rtn)
                {
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return rtn;
        }
        private bool CheckStockValidity()
        {
            bool bStatus = true;
            try
            {
                string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                decimal dWeight = 0;
                decimal dQty = 0;
                foreach (DataRow row in dt_ItemGrouped.Rows)
                {
                    #region Stock Validation
                    sOriginalItemCode = sItemCode = clsValidate.ValidateRowValue(row, "ItemCode", "default");
                    dWeight = clsValidate.ValidateRowValue(row, "Weight", decimal.Parse("0.00"));
                    dQty = clsValidate.ValidateRowValue(row, "Quantity", decimal.Parse("0.00"));
                    sItemStatus = clsValidate.ValidateRowValue(row, "ItemStatus", "");
                    sJobCode = clsValidate.ValidateRowValue(row, "JobCode", "default");
                    sItemSubCategoryID = clsValidate.ValidateRowValue(row, "ItemSubCategoryID", "default");
                    sItemSubCategoryID2 = clsValidate.ValidateRowValue(row, "ItemSubCategoryID2", "default");
                    sItemSerialNo = clsValidate.ValidateRowValue(row, "ItemSerialNo", "0");
                    sItemSerialNo2 = clsValidate.ValidateRowValue(row, "ItemSerialNo2", "0");

                    if (!clsConfig.bStoreStockWithJobID)
                        sJobCode = "default";

                    //check whether single item stock enabled - qty
                    if (clsConfig.bSingleItemStockEnabled)
                    {
                        if (!clsHelpMethods.IsItemRawMaterial(sItemCode))
                            clsHelpMethods.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
                    }

                    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                    if (stock != null)
                    {
                        if (sItemStatus.ToLower() == "o")//if the item is old and check stock for more than one time
                        {
                            // This place use to valiedate the old stock
                            #region Old Items Stock Validation
                            List<tbl_sasCustomerOrder_Detail> oldDoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerID.Text.Trim());
                            foreach (tbl_sasCustomerOrder_Detail oldDoDetail in oldDoDetails)
                            {
                                if (oldDoDetail.Item_ID == sOriginalItemCode && oldDoDetail.ItemSubCategory_ID == sItemSubCategoryID && oldDoDetail.ItemSubCategory2_ID == sItemSubCategoryID2
                                    && oldDoDetail.ItemSerialNo == sItemSerialNo && oldDoDetail.ItemSerialNo2 == sItemSerialNo2)
                                {
                                    decimal dVeriance = 0;
                                    if (clsConfig.bStockValidateQty_CustomerOrder && !clsHelpMethods.IsNonInventoryItem(oldDoDetail.Item_ID))
                                    {
                                        #region Old Items Quantity Validation
                                        if (oldDoDetail.Qty < dQty)
                                            dVeriance = dQty - oldDoDetail.Qty;

                                        if (stock.Qty < dVeriance)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required quantity is not currently available in " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " \n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }
                                    if (clsConfig.bStockValidateWeight_CustomerOrder && !clsHelpMethods.IsNonInventoryItem(oldDoDetail.Item_ID))
                                    {
                                        ////weight part
                                        #region Old Items Weight Validation
                                        if (oldDoDetail.Weight < dWeight)
                                            dVeriance = dWeight - oldDoDetail.Weight;

                                        if (stock.Weight < dVeriance)
                                        {
                                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required quantity is not currently available in " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                            bStatus = false;
                                        }
                                        #endregion
                                    }

                                }
                            }
                            #endregion
                        }
                        else//first time added item ant have to check stock
                        {
                            #region New Item Stock Validation
                            #region New Item Weight Validation
                            if (stock.Weight < dWeight && clsConfig.bStockValidateWeight_CustomerOrder && !clsHelpMethods.IsNonInventoryItem(sItemCode))
                            {
                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required quantity is not currently available in " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock. You may try this item in another stores or a replacement item.\n";
                                bStatus = false;
                            }
                            #endregion

                            #region New Item Quantity Validation
                            if (stock.Qty < dQty && clsConfig.bStockValidateQty_CustomerOrder && !clsHelpMethods.IsNonInventoryItem(sItemCode))
                            {
                                strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required quantity is not currently available in " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock. You may try this item in another stores or a replacement item.\n";
                                bStatus = false;
                            }
                            #endregion
                            #endregion
                        }
                    }
                    else
                    {
                        if ((clsConfig.bStockValidateQty_CustomerOrder || clsConfig.bStockValidateWeight_CustomerOrder) && !clsHelpMethods.IsNonInventoryItem(sItemCode))
                        {
                            //No stock in selected store
                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock. You may try this item in another stores or a replacement item.\n";
                            bStatus = false;
                        }
                    }
                    #endregion
                }
                if (bStatus == false)
                {
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckProductionJobAvailbility()
        {
            bool bIsValidate = true;
            try
            {
                bool isJobIDActive = false;
                if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
                    isJobIDActive = true;

                int iCount = 0;
                if (txtCustomerOrderID.Tag != null && txtCustomerOrderID.Tag.ToString().Length > 0)
                {
                    foreach (tbl_pmsProductionJobRegister oDetail in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Tag.ToString()))
                    {
                        if (isJobIDActive)
                        {
                            if (oDetail.Job_ID == txtJobCode.Tag.ToString())
                            {
                                iCount++;
                                break;
                            }
                        }
                    }

                    if (iCount > 0)
                        bIsValidate = false;
                    else
                        bIsValidate = true;
                }

                if (!bIsValidate)
                {
                    MessageBox.Show("This CustomerOrder Cano't Change,this one Already allocated for Production....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bIsValidate;

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
                if (!clsCommon.isCurrency(txtComRate.Text.Trim()))
                {
                    strMessage += "\n commission Rate";
                    bStatus = false;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool ValidateForDependancies(string sCustomerOrderID)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_sasDeliveryOrder_Detail oDO in tbl_sasDeliveryOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID))
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(oDO.DeliveryOrder_ID);
                    if (detail != null && detail.DeliveryOrder_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.DeliveryOrder_ID + "] Delivery Order is already created for this Customer Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);
                clsCommon.ValidateForeignKey(ref txtTownID);
                clsCommon.ValidateForeignKey(ref txtQuotationID);
                clsCommon.ValidateForeignKey(ref txtJobCode);
                clsCommon.ValidateForeignKey(ref txtInquiryCode);
                //  clsCommon.ValidateForeignKey(ref txtCheckedBy);
                // clsCommon.ValidateForeignKey(ref txtApprovedBy);
                clsCommon.ValidateForeignKey(ref txtCustomerBranchID);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
        private void txtCustomerOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                txtCustomerOrderID_DoubleClick(null, null);
        }
        private void txtInquiryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Inquiry(sender);
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtSalesExecutiveID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesExecutiveID();
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_JobID();
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_QuotationID();
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
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
        private void txtTownID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterTown(ref txtTownID);
        }

        private void frm_sasCustomerOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
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

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            //comented by Gayan 2016-08-05
            //CalculateTaxesAndGrandTotal();
        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region Events DoubleClick
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionCustomerOrder_Direct(ref txtCustomerOrderID, chkShowSettle.Checked);
            if (txtCustomerOrderID.Tag != null && txtCustomerOrderID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtCustomerOrderID.Tag.ToString());
        }
        private void txtInquiryCode_DoubleClick(object sender, EventArgs e)
        {
            Search_Inquiry(sender);
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            Search_JobID();
        }
        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            Search_QuotationID();
            if (txtQuotationID.Tag != null)
                btnAddQuotation_Click(null, null);
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
        }

        private void txtTownID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterTown(ref txtTownID);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
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

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellDoubleClick(sender, e);
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
                        string sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                        if (sItemID != "")
                        {
                            clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                                dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                                dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                        }
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
                    btnAddInquiry_Click(objSender, new EventArgs());
                }
            }
        }
        private void Search_QuotationID()
        {
            try
            {
                //Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, txtCustomerID.Tag.ToString(), false);

                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
                    if (dgvDetail.Rows.Count > 0 && !isTemp)
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
                                if (isTemp && oCustomer2.ItemPriceMode == (int)enum_CustomerPrice_Mode.Customer_Wise_Price && dgvDetail.Rows.Count > 0)
                                {
                                    bIsEnableCustomerChange = false;
                                    MessageBox.Show("Customer Wise pricing enabled. Please remove items to change customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    FillDetailsCustomer(sCustomerID);
                            }
                        }

                        //Add Branch
                        if (txtCustomerID.Tag != null)
                        {
                            List<tbl_genCustomerMaster_Branches> Detail = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString());
                            if (Detail.Count > 1)
                                Search_CustomerBranch();
                            else
                            {
                                txtCustomerBranchID.Text = Detail.FirstOrDefault().BranchName;
                                txtCustomerBranchID.Tag = Detail.FirstOrDefault().Line_No;

                                txtAddressDelivery.Text = Detail.FirstOrDefault().Address;

                                lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(Detail.FirstOrDefault().Route_ID);
                                lblRoute.Tag = Detail.FirstOrDefault().Route_ID.ToString();
                            }


                            if (!clsHelpMethods.CheckOutstandingValidity_CreditPeriodAndLimit(ref txtCustomerID, ref txtGrandTotal))
                                ClearFields();
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
        private void Search_CustomerBranch()
        {
            try
            {
                if (txtCustomerID.Tag != null)
                {
                    clsSearch.Search_CustomerBranch(ref txtCustomerBranchID, txtCustomerID.Tag.ToString());
                    if (txtCustomerID.Tag != null && txtCustomerBranchID.Tag != null)
                    {
                        tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(txtCustomerID.Tag.ToString(), int.Parse(txtCustomerBranchID.Tag.ToString()));
                        if (oBranch != null)
                        {
                            lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(oBranch.Route_ID);
                            lblRoute.Tag = oBranch.Route_ID.ToString();
                            txtAddressDelivery.Text = oBranch.Address;

                            //if (oBranch.IsBillltoHeadOffice != true)
                            //{
                            //    txtAddressDelivery.Text = oBranch.Address;
                            //}
                            //else
                            //{
                            //    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                            //    if (oCustomer != null)
                            //    {
                            //        txtAddressDelivery.Text = oCustomer.AddressRegister;
                            //    }
                            //}
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
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSalesExecutiveID);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            if (CheckValiditeCustomer())
            {
                if (e.KeyCode == Keys.F1)
                {
                    txtItemID.Tag = null;
                    txtItemID.Clear();

                    if (clsConfig.bLoadItemSearch_ByStore)
                    {
                        if (CheckValidity_EmptyField())
                            clsSearch.Search_TransactionItemMasterByStore(ref txtItemID, txtStoreID.Tag.ToString());
                    }
                    else
                        clsSearch.Search_ItemMasterByBranch(ref txtItemID);

                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                    {
                        txtItemSubCategory.Tag = "default";
                        txtItemSerialNo.Tag = "0";
                        btnAddItem_Click(sender, new EventArgs());
                    }
                }

                else if (e.KeyCode == Keys.F5)
                {
                    frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
                    string sItemPriceCategory = ((ComboBoxItem)cmbItemPrice.SelectedItem).Value;
                    frm.glb_sItemPriceCategory = sItemPriceCategory;
                    frm.glb_bStockValidate_ManuallyDisable = true;
                    frm.ShowDialog();

                    if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
                    {
                        foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
                        {
                            dgvDetail.Rows.Add();
                            int iRow = dgvDetail.Rows.Count - 1;
                            decimal dExRate = 0;
                            if (txtCurrencyRate.Text.Trim().Length > 0)
                                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
                            bool bHasSettledBefore = true;

                            var MaxID = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                            Fill_Datagrid(false, iRow, MaxID + 1, oItem.sItemID, "default", "default", "default", oItem.sUOMID, oItem.dUnitPrice, oItem.dWeightPrice, false, 0, 0, oItem.dTotalAmount, 0, 0, 0, 0, oItem.dWeight, oItem.dQty, "N", oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "", bHasSettledBefore, dExRate);
                        }
                    }
                }
                else
                {
                    txtItemID.Tag = null; txtItemID.Clear();
                    clsHelpMethods.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(sender, new EventArgs());
                }
            }
            if (dgvDetail.Rows.Count > 0)
                cmbItemPrice.Enabled = false;
            else
                cmbItemPrice.Enabled = true;

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
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtCustomerOrderID, IsUpdate);
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
                Amount = clsFormatter.RoundDecimalPlaces(Amount);
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
                txtSubTotal.Tag = Amount;
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                dVatRate = chkVat.Checked ? dVatRate : 0;
                dNBTRate = chkNBT.Checked ? dNBTRate : 0;

                if (dVatRate >= 0 && dNBTRate >= 0)
                {
                    decimal dAfterVAT = 0;
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        decimal dUnitPrice = 0, dWeightPrice = 0, dWeight = 0, dQty = 0;// dVatAmount = 0,
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

        #region Print Method
        private void print(bool bIsDraft)
        {
            try
            {
                if (txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
                {
                    try
                    {
                        string sDuplicate = "";
                        string sReportTitle_Main = "", sReportTitle_Sub = "", sReportPath = "", sDeliveryAddress = "", sDeliveryTel = "", sBranchId = "", sExRate = "", sCusType = "", sCusCategory = "";
                        bool bApprovalDone = true, bCheckingDone = true;
                        decimal dCreditLimit = 0, dCreditPeriod = 0;

                        if (clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_CustomerOrder), ref sReportTitle_Main, ref sReportTitle_Sub, ref sReportPath))
                        {
                            bool bPermissinOkToPrint = true;
                            if (chkPrintOriginal.Checked)
                                bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_CustomerOrder));
                            if (bPermissinOkToPrint)
                            {
                                tbl_sasCustomerOrder oCusOrder = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text);
                                if (oCusOrder != null)
                                {
                                    if (!bIsDraft)
                                    {
                                        #region Validate Approval
                                        if (clsConfig.bApprovalNeedToPrintCustomerOrder)
                                        {
                                            if (!oCusOrder.IsApproved)
                                            {
                                                bApprovalDone = false;
                                                MessageBox.Show("Please Approve the Customer Order Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        #endregion
                                        #region Validate Checking
                                        if (clsConfig.bCheckingNeedToPrintCustomerOrder)
                                        {
                                            if (!oCusOrder.IsChecked)
                                            {
                                                bCheckingDone = false;
                                                MessageBox.Show("Please Check the Customer Order Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        #endregion
                                    }

                                    if (bApprovalDone && bCheckingDone)
                                    {
                                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCusOrder.Customer_ID);
                                        if (oCustomer != null)
                                        {
                                            glb_dts_sasCustomerOrder.Clear();
                                            glb_dtsReportExport.Clear();
                                            Cursor = Cursors.WaitCursor;

                                            tbl_genCustomerFinance oCusFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                                            if (oCusFin != null)
                                            {
                                                dCreditLimit = oCusFin.CreditLimit;
                                                dCreditPeriod = oCusFin.CreditPeriod;
                                            }

                                            #region Get Customer Branch
                                            //if (oCusOrder.Branch_ID != null && oCusOrder.Branch_ID != "default")
                                            //{
                                            //    tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oCustomer.Customer_ID, Convert.ToInt16(oCusOrder.Branch_ID));
                                            //    sBranchId = oBranch.BranchName;
                                            //    sDeliveryAddress = oBranch.Address;
                                            //    sDeliveryTel = oBranch.Telephone;
                                            //}

                                            #region Get Customer Branch
                                            if (oCusOrder.Branch_ID != null && oCusOrder.Branch_ID != "default")
                                            {
                                                var oCusBranches = tbl_genCustomerMaster_Branches.SelectAllByCustomer_ID(oCustomer.Customer_ID);
                                                if (oCusBranches != null && oCusBranches.Count > 1)
                                                {
                                                    tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oCustomer.Customer_ID, Convert.ToInt16(oCusOrder.Branch_ID));

                                                    if (oBranch != null)
                                                    {
                                                        if (oBranch.BranchName != null && oBranch.BranchName.Trim() != "")
                                                        {
                                                            //Branch Exist
                                                            sBranchId = oBranch.BranchName;
                                                            sDeliveryTel = oBranch.Telephone;

                                                            if (oBranch.Address != null && oBranch.Address.Trim() != "")
                                                            {
                                                                //Branch Address Exist
                                                                sDeliveryAddress = oBranch.Address;
                                                            }
                                                            else
                                                            {
                                                                //No Address Exist
                                                                sDeliveryAddress = "";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            //No Branch
                                                            sBranchId = oCustomer.CustomerName;
                                                            sDeliveryAddress = oCustomer.AddressRegister;
                                                            sDeliveryTel = oCustomer.Telephone;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //No Branch
                                                        sBranchId = oCustomer.CustomerName;
                                                        sDeliveryAddress = oCustomer.AddressRegister;
                                                        sDeliveryTel = oCustomer.Telephone;
                                                    }
                                                }
                                                else
                                                {
                                                    //No Branch
                                                    sBranchId = oCustomer.CustomerName;
                                                    sDeliveryAddress = oCustomer.AddressRegister;
                                                    sDeliveryTel = oCustomer.Telephone;
                                                }
                                            }
                                            else
                                            {
                                                //No Branch
                                                sBranchId = oCustomer.CustomerName;
                                                sDeliveryAddress = oCustomer.AddressRegister;
                                                sDeliveryTel = oCustomer.Telephone;
                                            }
                                            #endregion


                                            #endregion

                                            #region Customer Type / Category
                                            tbl_zCustomerType oType = tbl_zCustomerType.Select(oCustomer.CustomerType_ID);
                                            if (oType != null)
                                                sCusType = oType.TypeName;

                                            tbl_zCustomerCategory oCat = tbl_zCustomerCategory.Select(oCustomer.CustomerCategory_ID);
                                            if (oCat != null)
                                                sCusCategory = oCat.CategoryName;
                                            #endregion

                                            //if (sDeliveryAddress == "")
                                            //{
                                            //    sDeliveryAddress = oCustomer.AddressRegister;
                                            //    sDeliveryTel = oCustomer.Telephone;
                                            //}

                                            if (!bIsDraft)
                                            {
                                                if (!chkPrintOriginal.Checked)
                                                    sDuplicate = (oCusOrder.PrintCount > 0) ? "Duplicate Copy " + oCusOrder.PrintCount : "";

                                                oCusOrder.PrintCount++;
                                                oCusOrder.DatePrinted = clsSecurity.getServerDateTime();
                                                oCusOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
                                                oCusOrder.PrintedUser_ID = clsSecurity.UserIDLoged;

                                                oCusOrder.Update();
                                            }

                                            if (oCusOrder.IsDeleted)
                                                sDuplicate = "";

                                            string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sCreateUserName = "[ None ]", sCheckedUserName = "[ None ]", sCreateDate = "", sCheckedDate = "";
                                            sCreateUser = "[ " + clsGenaralName.getName_User(oCusOrder.CreateUser_ID) + " ] [ " + oCusOrder.DateCreate.ToShortDateString() + " ]";
                                            if (oCusOrder.CheckedUser_ID != "default")
                                                sCheckedUser = "[ " + clsGenaralName.getName_User(oCusOrder.CheckedUser_ID) + " ] [ " + oCusOrder.DateChecked.ToShortDateString() + " ]";
                                            if (oCusOrder.ApprovedUser_ID != "default")
                                                sApprovedUser = "[ " + clsGenaralName.getName_User(oCusOrder.ApprovedUser_ID) + " ] [ " + oCusOrder.DateApproved.ToShortDateString() + " ]";

                                            sCreateUserName = "[ " + clsGenaralName.getName_User(oCusOrder.CreateUser_ID) + " ]";
                                            sCreateDate = "[" + oCusOrder.DateCreate.ToString("dd/MM/yyyy hh:mm:ss tt") + " ]";
                                            if (oCusOrder.IsChecked)
                                            {
                                                sCheckedUserName = "[ " + clsGenaralName.getName_User(oCusOrder.CheckedUser_ID) + " ]";
                                                sCheckedDate = "[" + oCusOrder.DateChecked.ToString("dd/MM/yyyy hh:mm:ss tt") + " ]";
                                            }

                                            glb_dts_sasCustomerOrder.dt_sasCustomerOrder.Adddt_sasCustomerOrderRow(
                                                oCusOrder.CustomerOrder_ID,
                                                oCusOrder.CustomerOrderDate,
                                                oCusOrder.DeliveryDate.Date,
                                                sDeliveryAddress,
                                                sDeliveryTel,
                                                oCustomer.CustomerName,
                                                oCustomer.AddressRegister,
                                                oCustomer.Telephone,
                                                clsGenaralName.getName_BranchCustomer(oCusOrder.Customer_ID, int.Parse(oCusOrder.Branch_ID)),
                                                dCreditLimit,
                                                Convert.ToInt32(dCreditPeriod),
                                                sBranchId,
                                                clsGenaralName.getName_Employee(oCusOrder.Employee_ID),
                                                oCusOrder.Remark,
                                                oCusOrder.Customer_ID,
                                                "p_Date",
                                                clsHelpMethods.getDisplayPrice(oCusOrder.GrandTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.SubTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.DiscountTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.NbtTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.VatTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.OtherTaxTotal, oCusOrder.CurrencyRate),
                                                clsHelpMethods.getDisplayPrice(oCusOrder.AdvanceAmount, oCusOrder.CurrencyRate),
                                                clsCommon.CurrencyToWord(decimal.Parse(txtGrandTotal.Text)),
                                                oCusOrder.Quotation_ID, oCusOrder.PurchaseOrder_ID, oCusOrder.DiscountPercentage, oCusOrder.NbtPercentage, oCusOrder.VatPercentage, oCusOrder.OtherTaxPercentage, "", "",
                                                oCusOrder.IsWeightCalculation, oCusOrder.IsSeattled, oCusOrder.IsDeleted, oCusOrder.IsApproved, "", "", "", "", oCusOrder.Employee_ID, clsGenaralName.getName_OrderRefNo(oCusOrder.OrderRefNo_ID), sCreateUser, sCheckedUser, sApprovedUser, oCusOrder.Currency_ID, clsGenaralName.getName_CurrencyCode(oCusOrder.Currency_ID),
                                                oCusOrder.Store_ID, clsGenaralName.getName_Store(oCusOrder.Store_ID), oCusOrder.IsSVAT ? oCustomer.SvatRegistrationNo : oCustomer.VatRegistrationNo, oCustomer.NbtRegistrationNo,
                                                oCustomer.CustomerType_ID, sCusType, oCustomer.CustomerCategory_ID, sCusCategory, ((ComboBoxItem)cmbItemPrice.SelectedItem).ToString(), oCusOrder.DateCreate);

                                            foreach (tbl_sasCustomerOrder_Detail oDetails_CO in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCusOrder.CustomerOrder_ID))
                                            {

                                                glb_dts_sasCustomerOrder.dt_sasCustomerOrderDetail.Adddt_sasCustomerOrderDetailRow(oDetails_CO.CustomerOrder_ID, oDetails_CO.Item_ID, clsGenaralName.getName_Item(oDetails_CO.Item_ID), oDetails_CO.Qty, oDetails_CO.Weight,
                                                    clsHelpMethods.getDisplayPrice(oDetails_CO.UnitPrice, oCusOrder.CurrencyRate)
                                                    , oDetails_CO.BIsFreeItem,
                                                    oDetails_CO.DiscountPresentage,
                                                    clsHelpMethods.getDisplayPrice(oDetails_CO.DiscountAmount, oCusOrder.CurrencyRate),
                                                    oDetails_CO.Remark,
                                                    clsHelpMethods.getDisplayPrice(oDetails_CO.TatalAmount, oCusOrder.CurrencyRate),
                                                    "", 0, 0, 0,
                                                    clsGenaralName.getName_ItemUOMName(oDetails_CO.Item_ID), oDetails_CO.WeightPrice, oDetails_CO.QtySettle_DeliveryOrder, clsGenaralName.getName_ItemCategorySub(oDetails_CO.ItemSubCategory_ID), clsHelpMethods.GetPLU(oCusOrder.Customer_ID, oDetails_CO.Item_ID));
                                            }

                                            sExRate = clsFormatter.FormatDecimalPlaces_Price(oCusOrder.CurrencyRate);

                                            #region Report parameters
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDel", oCusOrder.IsDeleted ? "CANCELLED" : "", true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUser", sCreateUserName, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUser", sCheckedUserName, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateDate", sCreateDate, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckedDate", sCheckedDate, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanySVAT", clsCommon.getCompanySVAT(), true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true, false);
                                            glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ExchangeRate", sExRate, true, false);
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
                                                }
                                            }
                                            glb_dts_sasCustomerOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, sReportTitle_Main, sReportTitle_Sub, "", clsSecurity.UserNameLoged, "");
                                            #endregion

                                            frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                            rpt.print(sReportPath, glb_dts_sasCustomerOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_CustomerOrder));
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
                    finally
                    {
                        glb_dts_sasCustomerOrder.Clear();
                        glb_dtsReportExport.Clear();
                        Cursor = Cursors.Default;
                    }
                }
                else
                    MessageBox.Show("Please Select the Customer Order To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{left}");
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }

        #region Texbox Leave
        //Added by Gayan 2016-08-05
        //This is develop according to Invoice Discout Mechanism
        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            // decimal dDiscount = 0;
            #region Old Code
            if (txtDiscount.TextLength > 0 && clsCommon.isCurrency(txtDiscount.Text.Trim()) && decimal.Parse(txtDiscount.Text.Trim()) > 0)
            {
                txtDiscount.Tag = txtDiscount.Text.Trim();
                txtPercentageDiscount.Text = "0";
            }
            else
                txtDiscount.Tag = "0";
            #endregion

            CalculateTaxesAndGrandTotal();
        }
        #endregion

        #region User Details
        #region Search Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpCustomerOrderDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtCustomerOrderID.Text != null && txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
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

                                        tbl_sasCustomerOrder objCO = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                                        if (objCO != null)
                                        {
                                            objCO.IsApproved = true;
                                            objCO.DateApproved = clsSecurity.getServerDateTime();
                                            objCO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                            objCO.Update();

                                            //Update BOM Sales => CO_ID
                                            if (CheckStatus_UpdateApparelBoM(objCO.IsChecked, objCO.IsApproved))
                                                Apparel_BoM_Update(objCO.CustomerOrder_ID, objCO.Job_ID);
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpCustomerOrderDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtCustomerOrderID.Text != null && txtCustomerOrderID.TextLength > 0 && txtCustomerOrderID.Text != "<Auto Generate>")
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

                                        tbl_sasCustomerOrder objCO = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                                        if (objCO != null)
                                        {                                            
                                            objCO.IsChecked = true;
                                            objCO.DateChecked = clsSecurity.getServerDateTime();
                                            objCO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objCO.Update();

                                            //Update BOM Sales => CO_ID
                                            if (CheckStatus_UpdateApparelBoM(objCO.IsChecked, objCO.IsApproved))
                                                Apparel_BoM_Update(objCO.CustomerOrder_ID, objCO.Job_ID);
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
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        #endregion

        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            UserDetails();
        }

        private void UserDetails()
        {
            try
            {
                if (txtCustomerOrderID.Text != "" || txtCustomerOrderID.Text != "<Auto Generate>")
                {
                    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text);
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

        #region Help Methods - Prod Apparel BOM
        private void Apparel_BoM_Update(string sCO_ID, string sBoM_ID)
        {
            if (clsHelpMethods.Check_ProdApparel_Enable())
            {
                tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(sBoM_ID);
                if (oBoM != null && oBoM.ProdJob_ID != "default" && !oBoM.IsLocked)
                {
                    oBoM.CustomerOrder_ID = sCO_ID;
                    oBoM.Update();
                }
            }
        }

        private bool CheckStatus_UpdateApparelBoM(bool bIsCO_Checked, bool bIsCO_Approved)
        {
            return ((!clsConfig.bBoM_CustomerOrderIDUpdate_NeedApproval && !clsConfig.bBoM_CustomerOrderIDUpdate_NeedChecking) ||
                     (clsConfig.bBoM_CustomerOrderIDUpdate_NeedChecking && bIsCO_Checked) ||
                     (clsConfig.bBoM_CustomerOrderIDUpdate_NeedApproval && bIsCO_Approved));
        }
        #endregion
    }
}