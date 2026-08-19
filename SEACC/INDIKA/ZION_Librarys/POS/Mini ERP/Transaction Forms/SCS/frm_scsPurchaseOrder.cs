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
using Digiteq.DataSets.SCS;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_scsPurchaseOrder : SEACC_Form
    {
        #region Variables

        public string glbOrderRefNo = "", glbPurchaseRequistionID = "", glbPurchaseOrderID = "";

        dts_scsPurchaseOrder glb_dtsSasPurchaseOrder = new dts_scsPurchaseOrder();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();
        #endregion

        #region Form Load
        public frm_scsPurchaseOrder(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(true, true, true, true, true, true, true, true, true);

            ClearFields();
            CusDataGridViewFormat();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            if (glbPurchaseRequistionID.Length > 0)
            {
                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(glbPurchaseRequistionID);
                if (detail != null)
                {
                    txtPurchaseRequisitionID.Tag = detail.PurchaseRequisitionNote_ID;
                    btnAddSR_Click(sender, e);
                }
            }
            else if (glbPurchaseOrderID.Length > 0)
            {
                FillDetails(glbPurchaseOrderID);
            }
        }
        #endregion

        #region Btn New
        private void frm_scsPurchaseOrder_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_scsPurchaseOrder_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPOID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpPoDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            Cursor = Cursors.WaitCursor;
                            tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                            if (detail != null)
                            {
                                if (ValidateForDependancies(detail.PurchaseOrder_ID))
                                {
                                    List<tbl_scsExternalGoodReceivedNote> oGRN = tbl_scsExternalGoodReceivedNote.SelectAllByIssuedRefNo_ID(detail.IssuedRefNo_ID).Where(p => !p.IsDeleted).ToList();
                                    if (oGRN.Count == 0)
                                    {
                                        if (!detail.IsLocked && !detail.IsFinished && !detail.IsDeleted)
                                        {
                                            {
                                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " PO : " + txtPOID.Text), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                                if (msgResult == DialogResult.Yes)
                                                {
                                                    if (CheckSupplierSaveValidity(detail.Supplier_ID))//Check Supplier Validity
                                                    {
                                                        detail.IsDeleted = true;
                                                        detail.DateModified = clsSecurity.getServerDateTime();
                                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                        detail.Update();

                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        ClearFields();
                                                    }
                                                }
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.GRNdoneForPO), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
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
                        clsHelpMethods.Grid_LineNoChange(dgvDetail);
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
        private void frm_scsPurchaseOrder_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                bool bFillDetails = false;
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    validateAccountCode2();

                    if (IsUpdate)
                    {
                        #region Update Data
                        tbl_scsPurchaseOrder oldRecord = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                        if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (ValidateForDependancies(oldRecord.PurchaseOrder_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (!oldRecord.IsChecked || (oldRecord.IsChecked && clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPOID.Text))
                                        {
                                            #region Update Old PO Items
                                            List<tbl_scsPurchaseOrder_Detail> oldDetails = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(txtPOID.Text.Trim());
                                            foreach (tbl_scsPurchaseOrder_Detail oldDetail in oldDetails)
                                            {
                                                string sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = ""; decimal dQty = 0, dUnitPrice = 0,
dWeight = 0, dMeter = 0, dAmount = 0, dWeidhtPrice = 0;
                                                int iLineNo = 0;
                                                bool bHasItemInDB = false;

                                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                                {
                                                    iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                    sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                    dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dMeter = clsValidate.ValidateGridValue(dgvDetail, "Meter", row.Index, decimal.Parse("0.00"));
                                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                    if (oldDetail.PurchaseOrder_ID == txtPOID.Text.Trim() && oldDetail.Line_No == iLineNo && oldDetail.Item_ID == sItemCode && oldDetail.ItemSubCategory_ID == sItemSubCategoryID1 &&
                                                        oldDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDetail.ItemSerialNo == sItemSerialNo1 && oldDetail.ItemSerialNo2 == sItemSerialNo2)
                                                    {
                                                        bHasItemInDB = true;
                                                        dgvDetail.Rows.RemoveAt(row.Index);
                                                        break;
                                                    }
                                                }

                                                if (bHasItemInDB)
                                                {
                                                    #region Update old item details

                                                    dUnitPrice = getSavePrice(dUnitPrice);
                                                    dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                                    dAmount = getSavePrice(dAmount);

                                                    oldDetail.Item_ID = sItemCode;
                                                    oldDetail.ItemSubCategory_ID = sItemSubCategoryID1;
                                                    oldDetail.ItemSubCategory2_ID = sItemSubCategoryID2;
                                                    oldDetail.ItemSerialNo = sItemSerialNo1;
                                                    oldDetail.ItemSerialNo2 = sItemSerialNo2;
                                                    oldDetail.Qty = dQty;
                                                    oldDetail.Weight = dWeight;
                                                    oldDetail.Meters = dMeter;
                                                    oldDetail.UnitPrice = dUnitPrice;
                                                    oldDetail.KiloPrice = dWeidhtPrice;
                                                    oldDetail.TatalAmount = dAmount;
                                                    oldDetail.Remark = sRemarks;
                                                    oldDetail.Update();

                                                    #region Update Purchase Requistion

                                                    if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Trim() != "default")
                                                    {
                                                        foreach (tbl_scsPurchaseRequisition_Detail oPR in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(txtPurchaseRequisitionID.Tag.ToString().Trim()).Where(p => p.Item_ID == sItemCode))
                                                        {
                                                            oPR.QtySettle = (oldDetail.Qty);
                                                            oPR.WeightSettle = (oldDetail.Weight);
                                                            oPR.Update();
                                                            clsProcessMethods.SetSettle_PurchaseRequisition(txtPurchaseRequisitionID.Tag.ToString().Trim());
                                                        }
                                                    }
                                                    #endregion

                                                    #region Update Quotation

                                                    if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim() != "default")
                                                    {
                                                        tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(txtQuotationID.Tag.ToString()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sItemSubCategoryID1 &&
            r.ItemSubCategory2_ID == sItemSubCategoryID2 && r.ItemSerialNo == sItemSerialNo1 && r.ItemSerialNo2 == sItemSerialNo2).FirstOrDefault();
                                                        if (inqItem != null)
                                                        {
                                                            if (chkUnitPricing.Checked) inqItem.QtySettle_Invoice = (inqItem.QtySettle_Invoice - oldDetail.Qty) + dQty;
                                                            else
                                                                inqItem.WeightSettle_Invoice = (inqItem.WeightSettle_Invoice - oldDetail.Weight) + dWeight;
                                                            inqItem.Update();
                                                            clsProcessMethods.SetSettle_QuotationFrom_Invoice(txtQuotationID.Tag.ToString().Trim(), chkUnitPricing);
                                                        }
                                                    }

                                                    #endregion

                                                    #endregion
                                                }
                                                else
                                                {
                                                    #region Delete old item details

                                                    oldDetail.Delete();

                                                    #endregion
                                                }
                                            }

                                            #endregion

                                            #region Insert Newly Added items

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                string sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "",
                                                    sItemSerialNo2 = "", sRemarks = "";
                                                decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dMeter = 0,
                                                    dAmount = 0, dWeidhtPrice = 0;
                                                int iLineNo = 0;

                                                iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                dMeter = clsValidate.ValidateGridValue(dgvDetail, "Meter", row.Index, decimal.Parse("0.00"));
                                                dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                                //Get Unit Price with Exchange rate to save
                                                dUnitPrice = getSavePrice(dUnitPrice);
                                                dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                                dAmount = getSavePrice(dAmount);

                                                if (sItemCode.Trim().Length > 0)
                                                {
                                                    tbl_scsPurchaseOrder_Detail poDetail = new tbl_scsPurchaseOrder_Detail(iLineNo, txtPOID.Text.Trim(),
                                                            sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2,
                                                            dQty, 0, dWeight, 0, dMeter, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks);
                                                    poDetail.Insert();
                                                }

                                                #region Update Purchase Requistion

                                                if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Trim() != "default")
                                                {
                                                    foreach (tbl_scsPurchaseRequisition_Detail oPR in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(txtPurchaseRequisitionID.Tag.ToString().Trim())
                                                            .Where(p => p.Item_ID == sItemCode))
                                                    {
                                                        oPR.QtySettle = oPR.QtySettle + dQty;
                                                        oPR.WeightSettle = oPR.WeightSettle + dWeight;
                                                        oPR.Update();
                                                        clsProcessMethods.SetSettle_PurchaseRequisition(txtPurchaseRequisitionID.Tag.ToString().Trim());
                                                    }
                                                }

                                                #endregion

                                                #region Update Quotation

                                                if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim() != "default")
                                                {
                                                    tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(txtQuotationID.Tag.ToString()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sItemSubCategoryID1 &&
r.ItemSubCategory2_ID == sItemSubCategoryID2 && r.ItemSerialNo == sItemSerialNo1 && r.ItemSerialNo2 == sItemSerialNo2).FirstOrDefault();
                                                    if (inqItem != null)
                                                    {
                                                        if (chkUnitPricing.Checked) inqItem.QtySettle_Invoice = inqItem.QtySettle_Invoice + dQty;
                                                        else
                                                            inqItem.WeightSettle_Invoice = inqItem.WeightSettle_Invoice + dWeight;
                                                        inqItem.Update();
                                                        clsProcessMethods.SetSettle_QuotationFrom_Invoice(txtQuotationID.Tag.ToString(), chkUnitPricing);
                                                    }
                                                }
                                                #endregion
                                            }

                                            #endregion

                                            #region Assign Value

                                            decimal dAdvanceAmount = 0,
                                                dOnDelivery = 0,
                                                dBalanceDays = 0,
                                                dForexRate = 0;
                                            if (txtAdvanceAmount.Text.Trim().Length > 0)
                                                dAdvanceAmount = decimal.Parse(txtAdvanceAmount.Text.Trim());
                                            if (txtOnDeliveryAmount.Text.Trim().Length > 0)
                                                dOnDelivery = decimal.Parse(txtOnDeliveryAmount.Text.Trim());
                                            if (txtBalanceDays.Text.Trim().Length > 0)
                                                dBalanceDays = decimal.Parse(txtBalanceDays.Text.Trim());
                                            if (txtForExRate.Text.Trim().Length > 0)
                                                dForexRate = decimal.Parse(txtForExRate.Text.Trim());

                                            #endregion

                                            #region Update po Header

                                            tbl_scsPurchaseOrder po = new tbl_scsPurchaseOrder(oldRecord.PurchaseOrder_ID, dtpPoDate.Value, txtIssuedRefNo.Tag.ToString(), txtPayMode.Tag.ToString(), txtPurchaseRequisitionID.Tag.ToString(), txtQuotationID.Tag.ToString(),
                                                txtStockNoteType.Tag.ToString(), txtRemark.Text.Trim(), txtDeliveryAddress.Text.Trim(), dtpDueDate.Value, txtDeliveryTerms.Text.Trim(), txtOrderBy.Text.Trim(), "", "", dAdvanceAmount, dOnDelivery, dBalanceDays, dForexRate,
                                                txtCurrency.Tag.ToString(), txtSupplierID.Tag.ToString(), txtQuotationNo.Text.Trim(), oldRecord.GlPosting_ID, txtCostCenter.Tag.ToString(), oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID,
                                                decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()),
                                                getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtDiscount.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtNBT.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtVat.Tag.ToString().Trim())),
                                                getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim())), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled, oldRecord.PrintCount,
                                                oldRecord.IsWeightCalculation, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), chkTIEP.Checked, oldRecord.CompanyID, oldRecord.CompanyBranch_ID);
                                            po.Update();

                                            #endregion


                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
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
                    else
                    {
                        #region Insert Data
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        {
                            if (clsConfig.bStockNoteType_SerialNoActiveFor_PurchaseOrder)
                            {
                                if (txtStockNoteType.Tag != null && txtStockNoteType.Tag.ToString().Trim().Length > 0 && txtStockNoteType.Tag.ToString().Trim() != "default")
                                    txtPOID.Text = clsAutocode.getAutoGeneratedCode_PurchaseOrder(txtStockNoteType.Tag.ToString());
                                else
                                    MessageBox.Show("Please select the Stock Note Type before you save the record. " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                txtPOID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                        }

                        #region Create Issued Ref ID
                        if (txtIssuedRefNo.Tag == null || txtIssuedRefNo.Tag.ToString().Trim().Length == 0 || txtIssuedRefNo.Tag.ToString().Trim() == "default")
                        {
                            txtIssuedRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zIssuedRefNo));
                            tbl_zIssuedRefNo orf = new tbl_zIssuedRefNo(txtIssuedRefNo.Tag.ToString(), txtIssuedRefNo.Text != "" ? txtIssuedRefNo.Text.Trim() : "-");
                            orf.Insert();
                        }
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtPOID.Text))
                        {
                            tbl_scsPurchaseOrder oIGIN = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                            if (oIGIN == null)
                            {
                                #region Assign Value
                                decimal dAdvanceAmount = 0, dOnDelivery = 0, dBalanceDays = 0, dForexRate = 0;
                                if (txtAdvanceAmount.Text.Trim().Length > 0)
                                    dAdvanceAmount = decimal.Parse(txtAdvanceAmount.Text.Trim());
                                if (txtOnDeliveryAmount.Text.Trim().Length > 0)
                                    dOnDelivery = decimal.Parse(txtOnDeliveryAmount.Text.Trim());
                                if (txtBalanceDays.Text.Trim().Length > 0)
                                    dBalanceDays = decimal.Parse(txtBalanceDays.Text.Trim());
                                if (txtForExRate.Text.Trim().Length > 0)
                                    dForexRate = decimal.Parse(txtForExRate.Text.Trim());
                                #endregion

                                #region Insert Po Header
                                tbl_scsPurchaseOrder po = new tbl_scsPurchaseOrder(txtPOID.Text.Trim(), dtpPoDate.Value, txtIssuedRefNo.Tag.ToString(), txtPayMode.Tag.ToString(), txtPurchaseRequisitionID.Tag.ToString(), txtQuotationID.Tag.ToString(), txtStockNoteType.Tag.ToString(), txtRemark.Text.Trim(), txtDeliveryAddress.Text.Trim(), dtpDueDate.Value,
                                        txtDeliveryTerms.Text.Trim(), txtOrderBy.Text.Trim(), "", "", dAdvanceAmount, dOnDelivery, dBalanceDays, dForexRate, txtCurrency.Tag.ToString(), txtSupplierID.Tag.ToString(),
                                        txtQuotationNo.Text.Trim(), "default", txtCostCenter.Tag.ToString(), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,
                                        decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), getSavePrice(decimal.Parse(txtSubTotal.Tag.ToString().Trim())),
                                        getSavePrice(decimal.Parse(txtDiscount.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtNBT.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtVat.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtOtherTax.Tag.ToString().Trim())), getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim())),
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default",
                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false, 0, false, 0, !chkUnitPricing.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax), chkTIEP.Checked, clsSecurity.CompanyID, clsSecurity.BranchID);
                                po.Insert();
                                #endregion

                                #region Insert PO Detail
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    string sItemCode = "", sItemSubCategoryID1 = "", sItemSubCategoryID2 = "", sItemSerialNo1 = "", sItemSerialNo2 = "", sRemarks = "";
                                    decimal dQty = 0, dUnitPrice = 0, dWeight = 0, dMeter = 0, dAmount = 0, dWeidhtPrice = 0;
                                    int iLineNo = 0;

                                    iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                    sItemSubCategoryID1 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                    sItemSerialNo1 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                    dUnitPrice = clsValidate.ValidateGridTag(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.0000"));
                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    dWeidhtPrice = clsValidate.ValidateGridTag(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.0000"));
                                    dMeter = clsValidate.ValidateGridValue(dgvDetail, "Meter", row.Index, decimal.Parse("0.00"));
                                    dAmount = clsValidate.ValidateGridTag(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                    //Get Unit Price with Exchange rate to save
                                    dUnitPrice = getSavePrice(dUnitPrice);
                                    dWeidhtPrice = getSavePrice(dWeidhtPrice);
                                    dAmount = getSavePrice(dAmount);

                                    if (sItemCode.Trim().Length > 0)
                                    {

                                        tbl_scsPurchaseOrder_Detail poDetail = new tbl_scsPurchaseOrder_Detail(iLineNo, txtPOID.Text.Trim(), sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2,
                                            dQty, 0, dWeight, 0, dMeter, dWeidhtPrice, dUnitPrice, 0, 0, dAmount, sRemarks);
                                        poDetail.Insert();

                                        #region Update Purchase Requistion
                                        if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Trim() != "default")
                                        {
                                            foreach (tbl_scsPurchaseRequisition_Detail oPR in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(txtPurchaseRequisitionID.Tag.ToString().Trim()).Where(p => p.Item_ID == sItemCode))
                                            {
                                                oPR.QtySettle = oPR.QtySettle + dQty;
                                                oPR.WeightSettle = oPR.WeightSettle + dWeight;
                                                oPR.Update();
                                                clsProcessMethods.SetSettle_PurchaseRequisition(txtPurchaseRequisitionID.Tag.ToString().Trim());
                                            }
                                        }
                                        #endregion
                                        #region Update Quotation
                                        if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim() != "default")
                                        {
                                            //sItemCode, sItemSubCategoryID1, sItemSubCategoryID2, sItemSerialNo1, sItemSerialNo2)
                                            tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(txtQuotationID.Tag.ToString()).Where(r => r.Item_ID == sItemCode && r.ItemSubCategory_ID == sItemSubCategoryID1 && r.ItemSubCategory2_ID == sItemSubCategoryID2 && r.ItemSerialNo == sItemSerialNo1 && r.ItemSerialNo2 == sItemSerialNo2).FirstOrDefault();
                                            if (inqItem != null)
                                            {
                                                if (chkUnitPricing.Checked)
                                                    inqItem.QtySettle_Invoice = inqItem.QtySettle_Invoice + dQty;
                                                else
                                                    inqItem.WeightSettle_Invoice = inqItem.WeightSettle_Invoice + dWeight;
                                                inqItem.Update();
                                                clsProcessMethods.SetSettle_QuotationFrom_Invoice(txtQuotationID.Tag.ToString(), chkUnitPricing);
                                            }
                                        }
                                        #endregion
                                    }
                                }
                                #endregion

                                Attachments.Insert(txtPOID.Text.ToString());

                                bFillDetails = true;
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("This ID is alredy added", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

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
                    if (bFillDetails || IsUpdate)
                    {
                        tbl_scsPurchaseOrder oldRecord = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                        if (oldRecord != null)
                            FillDetails(oldRecord.PurchaseOrder_ID);
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_scsPurchaseOrder_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_scsPurchaseOrder_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Add Item
        private void btnAddCustomerOrder_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Length > 0)
                RefreshGridByItemID(txtItemID.Tag.ToString().Trim());
        }
        #endregion

        #region Btn Add SR
        private void btnAddSR_Click(object sender, EventArgs e)
        {
            if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Length > 0)
                FillDetailsFromPR_ID(txtPurchaseRequisitionID.Tag.ToString().Trim());
        }
        #endregion

        #region Btn Add Quotation
        private void btnAddQuotation_Click(object sender, EventArgs e)
        {
            if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Length > 0)
                FillDetailsFromQuotation_ID(txtQuotationID.Tag.ToString().Trim());
        }
        #endregion

        #region Btn GRN
        private void btnGRN_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPOID.TextLength > 0 && txtPOID.Text.Trim() != "default")
                {
                    tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                    if (detail != null && detail.PurchaseOrder_ID != "default" && !detail.IsDeleted)
                    {
                        bool bAllowDetail = true;
                        string message = "";

                        if (clsConfig.bApprovalEnabledPurchaseOrder)
                        {
                            if (!detail.IsApproved)
                            {
                                bAllowDetail = false;
                                message = "APPROVAL NEEDED \n\nUser has to Approve the Purchase Order Before Create an Goods Received Note";
                            }
                        }

                        if (bAllowDetail)
                        {
                            frm_scsExternalGoodReceiveNote frm = new frm_scsExternalGoodReceiveNote(FormName.scsGRNSupplier);
                            frm.glbPurchaseOrderID = detail.PurchaseOrder_ID;
                            frm.glbOrderRefNo = detail.IssuedRefNo_ID;
                            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorStock, (this.Parent as Form).MdiParent);
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
        private void frm_scsPurchaseOrder_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtPOID.TextLength > 0 && txtPOID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPOID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtIssuedRefNo, true);

                clsCommon.SetEnableDisable_NormalLabel(lblPOID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

                txtPOID.Tag = null;
                dtpPoDate.Value = clsSecurity.getServerDateTime();

                setEnableArea_PO(true);

                txtStockNoteType.Tag = null;
                txtStockNoteType.Clear();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtIssuedRefNo.Tag = null;
                txtIssuedRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtPOID.Text = "<Auto Generate>";
                else
                    txtPOID.Clear();
                if (txtPOID.Enabled)
                {
                    txtPOID.SelectAll();
                    txtPOID.Focus();
                }

                Attachments.Clear();
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPOID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtIssuedRefNo, true);

            clsCommon.SetEnableDisable_NormalLabel(lblPOID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            setEnableArea_PO(true);

            lblSubAccount2.Visible = false;
            txtCostCenter.Visible = false;

            txtPOID.Tag = null;
            txtSupplierID.Tag = null;
            txtPurchaseRequisitionID.Tag = null;
            txtItemID.Tag = null;
            txtIssuedRefNo.Tag = null;
            txtCurrency.Tag = null;
            txtPayMode.Tag = null;
            txtQuotationID.Tag = null;
            txtStockNoteType.Tag = null;
            txtCostCenter.Tag = null;

            glbOrderRefNo = "";

            txtIssuedRefNo.Clear();
            txtSupplierID.Clear();
            txtPurchaseRequisitionID.Clear();
            txtItemID.Clear();
            txtCurrency.Clear();
            txtPayMode.Clear();
            txtRemark.Clear();
            txtQuotationNo.Clear();
            txtDeliveryAddress.Clear();
            txtOrderBy.Clear();
            txtDeliveryTerms.Clear();
            txtAdvanceAmount.Clear();
            txtOnDeliveryAmount.Clear();
            txtBalanceDays.Clear();
            txtForExRate.Clear();
            txtQuotationID.Clear();
            txtStockNoteType.Clear();
            txtCostCenter.Clear();
            dtpPoDate.Value = clsSecurity.getServerDateTime();
            dtpDueDate.Value = clsSecurity.getServerDateTime();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkReverseCalculation.Enabled = true;
            chkShowSettle.Checked = false;
            //chkSettings.Checked = true;
            chkSettings2.Checked = true;

            if (clsConfig.bChange_Name_lblTerms)
                lblTerms.Text = "Payment Terms";
            else
                lblTerms.Text = "Shipping / Packing Terms";

            txtDiscount.Text = "0";
            txtGrandTotal.Text = "0";
            txtNBT.Text = "0";
            txtOtherTax.Text = "0";
            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(clsCommon.getPesentageVAT());
            txtSubTotal.Text = "0";
            txtVat.Text = "0";
            txtForExRate.Text = "0.00";
            txtAdvanceAmount.Text = "0.00";
            txtOnDeliveryAmount.Text = "0.00";
            txtBalanceDays.Text = "0.00";

            txtDiscount.Tag = 0;
            txtNBT.Tag = 0;
            txtVat.Tag = 0;
            txtOtherTax.Tag = 0;
            txtSubTotal.Tag = 0;

            bHasApproved = false;
            bHasChecked = false;
            userDetailsColorChanges();

            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;
            dgvDetail.Rows.Clear();
            DisableMoneyControls();


            dtpPoDate.Enabled = !clsConfig.bLock_TransactionDate_SCS;

            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPOID.Text = "<Auto Generate>";
            else
                txtPOID.Clear();
            if (txtPOID.Enabled)
            {
                txtPOID.SelectAll();
                txtPOID.Focus();
            }

            chkTIEP.Checked = false;

            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sPoID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                foreach (tbl_scsPurchaseOrder_Detail detail in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(sPoID).OrderBy(p => p.Line_No))
                {
                    tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 1;
                        if (txtForExRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtForExRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Qty, detail.UnitPrice, detail.Weight, detail.KiloPrice, detail.Meters, item.WeightedAverageCostPrice, detail.TatalAmount, detail.Remark, dExRate);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItemID(string sItemID)
        {
            try
            {
                bool bStatus = true;
                if (clsConfig.bCheckValidation_BudgetExceed)
                    bStatus = clsMethods_GL.CheckAccountLink_Item(sItemID);

                if (bStatus)
                {
                    int iRow;
                    tbl_genItemMaster_Pricing detail = tbl_genItemMaster_Pricing.Select(sItemID);
                    if (detail != null)
                    {
                        decimal dExRate = 1;
                        if (txtForExRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtForExRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        clsCommon.ValidateItemSubCategoryAndSerialNo(ref txtItemSubCategory, ref txtItemSerialNo, "0");
                        var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                        Fill_Datagrid(iRow, maxLineNo + 1, detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), 0, detail.CostPrice1, 0, 0, 0, detail.WeightedAverageCostPrice, 0, "", dExRate);
                    }
                    CalcualteSubTotal();
                    CalculateTaxesAndGrandTotal();
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
        }
        private void RefreshGridByPurchaseRequisition_ID(string sPR_ID)
        {
            try
            {
                int iRow;
                foreach (tbl_scsPurchaseRequisition_Detail detail in tbl_scsPurchaseRequisition_Detail.SelectAllByPurchaseRequisitionNote_ID(sPR_ID).OrderBy(p => p.Line_No))
                {
                    tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 1;
                        if (txtForExRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtForExRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        ValidateEmptyForeignKey();
                        string sFromLocation = clsGenaralName.getName_Section(detail.FromSection_ID);
                        string sFromNoteID = detail.SectionReqositionNote_ID;
                        decimal dQty = detail.Qty - detail.QtySettle, dWeight = detail.Weight - detail.WeightSettle;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, dQty, item.CostPrice1, dWeight, 0, 0, item.WeightedAverageCostPrice, 0,detail.Remark, dExRate);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByQuotation_ID(string sQuotation_ID)
        {
            try
            {
                int iRow;
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotation_ID).OrderBy(p => p.Line_No).ToList();
                foreach (tbl_sasQuotation_Detail detail in details)
                {
                    tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 1;
                        if (txtForExRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtForExRate.Text.Trim());
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        ValidateEmptyForeignKey();
                        decimal dQty = detail.Qty - detail.QtySettle_Invoice, dWeight = detail.Weight - detail.QtySettle_Invoice;

                        Fill_Datagrid(iRow, detail.Line_No, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, dQty, detail.UnitPrice, dWeight, detail.WeightPrice, 0, item.WeightedAverageCostPrice, 0, "", dExRate);
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

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                        {
                            lblCancelled.Visible = true;
                            //btndraft.Enabled = false;
                        }
                        else
                            //btnDraft.Enabled = true;

                            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPOID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblPOID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSupplierID, true);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStockNoteType, true);
                        clsCommon.SetEnableDisable_NormalTextbox(txtIssuedRefNo, true);

                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, true);
                        clsCommon.SetEnableDisable_NormalLabel(lblStockNoteType, true);

                        setEnableArea_PO(false);

                        //fill order detials
                        tbl_zIssuedRefNo Issued = tbl_zIssuedRefNo.Select(detail.IssuedRefNo_ID);
                        if (Issued != null)
                        {
                            txtIssuedRefNo.Tag = detail.IssuedRefNo_ID;
                            txtIssuedRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                            glbOrderRefNo = detail.IssuedRefNo_ID;
                        }

                        //asign values
                        txtPOID.Tag = detail.PurchaseOrder_ID;
                        txtSupplierID.Tag = detail.Supplier_ID;
                        txtPurchaseRequisitionID.Tag = detail.PurchaseRequisitionNote_ID;
                        txtQuotationID.Tag = detail.Quotation_ID;
                        txtStockNoteType.Tag = detail.StockNoteType_ID;
                        txtCostCenter.Tag = detail.CostCenter;

                        dtpPoDate.Value = detail.PurchaseOrderDate;
                        dtpDueDate.Value = detail.DueDate;
                        txtPOID.Text = detail.PurchaseOrder_ID;
                        txtSupplierID.Text = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                        txtPurchaseRequisitionID.Text = clsCommon.GetForeignKeyValue(detail.PurchaseRequisitionNote_ID);
                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                        txtQuotationNo.Text = detail.QuotaionNo;
                        txtDeliveryAddress.Text = detail.DeliveryAddress;
                        txtOrderBy.Text = detail.OrderdBy;
                        txtDeliveryTerms.Text = detail.DeliveryTerms;
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        txtAdvanceAmount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.AdvanceAmount);
                        txtOnDeliveryAmount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OnDeliveryAmount);
                        txtBalanceDays.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.BalanceDays);
                        txtForExRate.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.ForexRate);
                        txtCurrency.Tag = detail.Currency_ID;
                        txtCurrency.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Currency(detail.Currency_ID));
                        txtPayMode.Tag = detail.PaymentMethod_ID;
                        txtPayMode.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_PaymentMethod(detail.PaymentMethod_ID));
                        txtRemark.Text = detail.Remark;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        //chkSettings.Checked = false;
                        chkSettings2.Checked = false;
                        txtCostCenter.Text = clsGenaralName.getName_AccCostCenter1(detail.CostCenter);

                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VatPercentage);


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
                        RefreshGrid(detail.PurchaseOrder_ID);

                        //Fill Process Flow
                        clsHelpMethods.SetProcessFlow_Stock_External(detail.IssuedRefNo_ID, txtFlowPR, txtFlowPO, txtFlowGRN, txtFlowPRN);

                        //Asign tax values after all calculation
                        txtSubTotal.Tag = getDisplayUnitPrice(detail.SubTotal, detail.ForexRate);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.SubTotal, detail.ForexRate));
                        txtDiscount.Tag = getDisplayUnitPrice(detail.DiscountTotal, detail.ForexRate);
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.DiscountTotal, detail.ForexRate));
                        txtNBT.Tag = getDisplayUnitPrice(detail.NbtTotal, detail.ForexRate);
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.NbtTotal, detail.ForexRate));
                        txtVat.Tag = getDisplayUnitPrice(detail.VatTotal, detail.ForexRate);
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.VatTotal, detail.ForexRate));
                        txtOtherTax.Tag = getDisplayUnitPrice(detail.OtherTaxTotal, detail.ForexRate);
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.OtherTaxTotal, detail.ForexRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(getDisplayUnitPrice(detail.GrandTotal, detail.ForexRate));

                        chkTIEP.Checked = detail.IsTIEP;


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
        private void FillDetailsFromPR_ID(string sPR_ID)
        {
            try
            {
                tbl_scsPurchaseRequisition detail = tbl_scsPurchaseRequisition.Select(sPR_ID);
                if (detail != null)
                {
                    if (detail.IsApproved)
                    {
                        txtPurchaseRequisitionID.Tag = detail.PurchaseRequisitionNote_ID;
                        txtPurchaseRequisitionID.Text = detail.PurchaseRequisitionNote_ID;
                        txtStockNoteType.Tag = detail.StockNoteType_ID;
                        txtStockNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_StockNoteType(detail.StockNoteType_ID));

                        //add order ref detail           
                        txtIssuedRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.IssuedRefNo_ID));
                        txtIssuedRefNo.Tag = detail.IssuedRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtIssuedRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);

                        setEnableArea_PO(false);

                        RefreshGridByPurchaseRequisition_ID(detail.PurchaseRequisitionNote_ID);
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void FillDetailsFromQuotation_ID(string sQuotation_ID)
        {
            try
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(sQuotation_ID);
                if (detail != null)
                {

                    txtQuotationID.Tag = detail.Quotation_ID;
                    txtQuotationID.Text = detail.Quotation_ID;

                    //add order ref detail           
                    //txtIssuedRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_IssuedRefNo(detail.OrderRefNo_ID));
                    //txtIssuedRefNo.Tag = null;
                    //clsCommon.SetEnableDisable_NormalTextbox(txtIssuedRefNo, false);
                    //clsCommon.SetEnableDisable_NormalLabel(lblIssuedRefNo, false);

                    setEnableArea_PO(false);

                    RefreshGridByQuotation_ID(detail.Quotation_ID);
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
            bool bStatus = false;
            if (CheckValidity_EmptyField())
                if (CheckNumberValidity())
                    if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                        if (CheckAdavanceValidity())
                            if (CheckSupplierSaveValidity(txtSupplierID.Tag.ToString()))
                                if (CheckValidity_TIEP())
                                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpPoDate.Value.Date))
                                        if (CheckValidity_CostPrice())
                                            if (CheckValidity_Budget())
                                                if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                                    bStatus = true;


            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtSupplierID, "Supplier Name"))
            {
                if (clsValidate.ValidateTextBox_EmptyValue(txtStockNoteType, "Stock Note Type"))
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }
        private bool CheckAdavanceValidity()
        {
            bool rtn = true;
            decimal dAdvance = 0, dOnDelivery = 0;
            if (txtAdvanceAmount.Text.Trim().Length > 0)
                dAdvance = decimal.Parse(txtAdvanceAmount.Text.Trim());
            if (txtOnDeliveryAmount.Text.Trim().Length > 0)
                dOnDelivery = decimal.Parse(txtOnDeliveryAmount.Text.Trim());
            if ((dAdvance + dOnDelivery) > 100)
            {
                rtn = false;
                MessageBox.Show("On Delivery and Balance CANNOT EXCEED 100%", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return rtn;
        }
        private void validateAccountCode2()
        {
            if (txtCostCenter.Tag == null)
            {
                txtCostCenter.Tag = "default";
                txtCostCenter.Text = "default";
            }
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
        private bool CheckSupplierSaveValidity(string sSupplierID)
        {
            bool rtn = true;
            if (clsValidate.isSupplierBlackListed(sSupplierID))
                rtn = false;
            else if (clsValidate.isSupplierSuspended(sSupplierID))
                rtn = false;
            return rtn;
        }
        private bool ValidateForDependancies(string sPurchaseOrder)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_scsExternalGoodReceivedNote_Detail oEGR in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByPurchaseOrder_ID(sPurchaseOrder))
                {
                    tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(oEGR.ExternalGoodReceivedNote_ID);
                    if (detail != null && detail.ExternalGoodReceivedNote_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.ExternalGoodReceivedNote_ID + "] External Goods Received Note is already created for this Purchase Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private bool CheckValidity_TIEP()
        {
            bool bValid = true;
            if (chkTIEP.Checked)
            {
                if (decimal.Parse(txtNBT.Text.ToString()) > 0 || decimal.Parse(txtVat.Text.ToString()) > 0)
                {
                    bValid = false;
                    MessageBox.Show("NBT Or VAT Is Not Allowed in TIEP Purchase Order......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return bValid;
        }
        private bool CheckValidity_CostPrice()
        {
            bool bStatus = true, bShowMessage = false;

            try
            {
                string strMessage = "";
                string sItem = "";

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                    string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
                    decimal dCostPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                    decimal dWeightedAvg = clsValidate.ValidateGridValue(dgvDetail, "WeightAvg", row.Index, decimal.Parse("0.00"));

                    if (dWeightedAvg > 0)
                    {
                        decimal dWeightedAvgPer = dWeightedAvg + ((dWeightedAvg * decimal.Parse(clsConfig.sWeightedAvg_Percentage)) / 100);

                        if (dCostPrice > dWeightedAvgPer)
                        {
                            sItem += sItemCode + " - " + sItemName + "\n";
                            bShowMessage = true;
                            continue;
                        }
                    }
                }

                if (bShowMessage == true)
                {
                    strMessage = "Entered Cost Price is greater than the previous Weighted Average \nfor following Items. \nDo you want to continue? \n";

                    DialogResult msgResult = MessageBox.Show(strMessage + sItem, clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                        bStatus = true;
                    else
                        bStatus = false;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }

            return bStatus;
        }
        private bool CheckValidity_Budget()
        {
            bool bStatus = true;

            try
            {
                if (clsConfig.bCheckValidation_BudgetExceed)
                {

                    #region Variables
                    decimal dControllAccAmount = 0, dPOAmount = 0, dBudgetMonthAmount = 0;
                    string sControllAcc = "";
                    #endregion

                    #region Get Date, Get Relevant Month, Set From Date n To Date
                    DateTime dtPO_Date = dtpPoDate.Value;
                    int iMonth = dtPO_Date.Month;
                    DateTime dtFromDate = new DateTime(dtPO_Date.Year, dtPO_Date.Month, 1);
                    DateTime dtLastDate = dtFromDate.AddMonths(1).AddDays(-1);
                    #endregion

                    #region Intialize Data Table
                    DataTable dtControllAcc = new DataTable();
                    dtControllAcc.Columns.Add("LineNo", typeof(int));
                    dtControllAcc.Columns.Add("ItemID", typeof(string));
                    dtControllAcc.Columns.Add("ControlAcc", typeof(string));
                    dtControllAcc.Columns.Add("Amount", typeof(decimal));
                    #endregion

                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        int iIndex = dgvDetail.Rows.IndexOf(row);
                        string sItemCode = row.Cells["ItemCode"].Value.ToString();
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemCode);
                        if (oItem != null)
                            dtControllAcc.Rows.Add(iIndex, sItemCode, oItem.ControlAcc, row.Cells["Amount"].Value);
                    }

                    var query = from row in dtControllAcc.AsEnumerable()
                                group row by row.Field<string>("ControlAcc") into grp
                                orderby grp.Key
                                select new
                                {
                                    ControlAcc = grp.Key,
                                    Total = grp.Sum(r => r.Field<decimal>("Amount"))
                                };

                    foreach (var data in query)
                    {
                        dPOAmount = data.Total;
                        dControllAccAmount = DBHandling.ExecQuery_ReturnDecimal("select Total from Func_POItems_ControlAccAmounts('" + data.ControlAcc + "','" + dtFromDate.Date + "','" + dtLastDate.Date + "')");

                        tbl_accBudget_detail oDetail = tbl_accBudget_detail.Select(clsMethods_GL.getFinancialYear_ID(dtPO_Date), data.ControlAcc);
                        if (oDetail != null)
                        {
                            #region Select Value
                            switch (iMonth)
                            {
                                case 1:
                                    dBudgetMonthAmount = oDetail.Value_Jan;
                                    break;
                                case 2:
                                    dBudgetMonthAmount = oDetail.Value_Feb;
                                    break;
                                case 3:
                                    dBudgetMonthAmount = oDetail.Value_Mar;
                                    break;
                                case 4:
                                    dBudgetMonthAmount = oDetail.Value_Apr;
                                    break;
                                case 5:
                                    dBudgetMonthAmount = oDetail.Value_May;
                                    break;
                                case 6:
                                    dBudgetMonthAmount = oDetail.Value_Jun;
                                    break;
                                case 7:
                                    dBudgetMonthAmount = oDetail.Value_Jul;
                                    break;
                                case 8:
                                    dBudgetMonthAmount = oDetail.Value_Aug;
                                    break;
                                case 9:
                                    dBudgetMonthAmount = oDetail.Value_Sep;
                                    break;
                                case 10:
                                    dBudgetMonthAmount = oDetail.Value_Oct;
                                    break;
                                case 11:
                                    dBudgetMonthAmount = oDetail.Value_Nov;
                                    break;
                                case 12:
                                    dBudgetMonthAmount = oDetail.Value_Dec;
                                    break;
                            }
                            #endregion
                        }

                        if (dBudgetMonthAmount < (dPOAmount + dControllAccAmount))
                        {
                            bStatus = false;
                            sControllAcc += (sControllAcc != "" ? "\n" : "") + data.ControlAcc + " - " + clsGenaralName.getName_AccountName(data.ControlAcc);
                        }
                    }

                    if (bStatus == false)
                    {
                        DialogResult msgResult = MessageBox.Show("Budget Exceed for following Accounts \n" + sControllAcc + "\nAllocated Budget - '" + dBudgetMonthAmount + "'\n\nDo you want to Continue? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (msgResult == DialogResult.Yes)
                            bStatus = true;
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtItemID);
                clsCommon.ValidateForeignKey(ref txtSupplierID);
                clsCommon.ValidateForeignKey(ref txtPurchaseRequisitionID);
                clsCommon.ValidateForeignKey(ref txtCurrency);
                clsCommon.ValidateForeignKey(ref txtPayMode);
                clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                clsCommon.ValidateForeignKey(ref txtItemSerialNo);
                clsCommon.ValidateForeignKey(ref txtQuotationID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtPOID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_PoID();
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SupplierID();
        }
        private void txtCurrency_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CheckedBy();
        }
        private void txtCheckBy_KeyDown(object sender, KeyEventArgs e)
        {
            txtCheckedBy_KeyDown(sender, e);
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
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Item();
        }
        private void txtPayMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterPaymentMethod(ref txtPayMode);
        }
        private void txtSrID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_PurchaseRequestionNote();
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Quotation();
        }
        private void txtStockNoteType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }

        private void txtSubAccount2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                if (e.KeyCode == Keys.F1)
                    txtSubAccount2_DoubleClick(null, null);
        }
        #endregion

        #region Events Double Click
        private void txtPOID_DoubleClick(object sender, EventArgs e)
        {
            Search_PoID();
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_SupplierID();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtCheckByMouseDoublrClick(object sender, MouseEventArgs e)
        {
            txtCheckedBy_DoubleClick(sender, e);
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_Item();
        }
        private void txtCurrency_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtPayMode_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterPaymentMethod(ref txtPayMode);
        }
        private void txtSrID_DoubleClick(object sender, EventArgs e)
        {
            Search_PurchaseRequestionNote();
        }
        private void txtQuotationID_DoubleClick(object sender, EventArgs e)
        {
            Search_Quotation();
        }
        private void txtStockNoteType_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStockNoteType(ref txtStockNoteType);
        }
        private void txtSubAccount2_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_costCenter1(ref txtCostCenter);
        }
        #endregion

        #region Event Key Press
        private void txtAdvance_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtAdvanceAmount, e, 12, 2);
        }

        private void txtDelivery_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtOnDeliveryAmount, e, 12, 2);
        }

        private void txtBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtBalanceDays, e, 12, 2);
        }

        private void txtForExRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtForExRate, e, 4, 2);
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
                txtDiscount.Tag = "0";
                CalculateTaxesAndGrandTotal();
            }
        }
        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNBT.Checked)
            {
                txtPercentageNBT.Enabled = true;
                chkVat.Checked = true;
                if (chkVat.Checked)
                    txtPercentageVat.Enabled = true;
            }
            else
                txtPercentageNBT.Enabled = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVat.Checked)
            {
                chkOtherTax.Checked = false;
                txtPercentageVat.Enabled = true;
            }
            else
                txtPercentageVat.Enabled = false;

            CalculateTaxesAndGrandTotal();
        }
        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                chkVat.Checked = false;
                txtPercentageOtherTax.Enabled = true;
            }
            else
                txtPercentageOtherTax.Enabled = false;

            CalculateTaxesAndGrandTotal();
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

        private void txtPercentageNBT_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void txtPercentageVat_TextChanged(object sender, EventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        #region Events Datagried
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.StockGrid_External_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
            CalcualteSubTotal();
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
        private void Search_PoID()
        {
            if (txtStockNoteType.Tag != null)
                clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPOID, chkShowSettle.Checked, txtStockNoteType.Tag.ToString());
            else
                clsSearch.Search_TransactionPurchaseOrder_Direct(ref txtPOID, "", chkShowSettle.Checked, false);

            if (txtPOID.Tag != null && txtPOID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtPOID.Tag.ToString());
        }
        private void Search_Item()
        {
            if (CheckValidity_EmptyField())
            {
                clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                    btnAddCustomerOrder_Click(btnAddItem, new EventArgs());
            }
        }
        private void Search_SupplierID()
        {
            try
            {
                clsSearch.Search_MasterSupplier(ref txtSupplierID);
                if (txtSupplierID.Tag != null)
                {
                    tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(txtSupplierID.Tag.ToString());
                    if (oSupplier != null)
                    {
                        FillDetailsCurrency(oSupplier.Currency_ID);
                        chkOtherTax.Checked = oSupplier.IsSVATenable ? true : false;
                        chkVat.Checked = oSupplier.IsVATenable ? true : false;
                        chkNBT.Checked = oSupplier.IsNBTenable ? true : false;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_Currency()
        {
            if (dgvDetail.Rows.Count > 0)
                MessageBox.Show("Please remove items to change currency..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            else
            {
                clsSearch.Search_MasterCurrency(ref txtCurrency);
                if (txtCurrency.Tag != null)
                    FillDetailsCurrency(txtCurrency.Tag.ToString());
                else
                    FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            }
        }
        private void Search_PurchaseRequestionNote()
        {
            clsSearch.Search_TransactionPurchaseReqositionNote_Use(ref txtPurchaseRequisitionID);
            if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Trim() != "default")
                btnAddSR_Click(null, null);

        }
        private void Search_Quotation()
        {
            clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, "", false);
            if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Trim() != "default")
                btnAddQuotation_Click(null, null);

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
                txtSubTotal.Text = Amount.ToString();
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

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, int iLineNo, string ItemID, string ItemSubCategoryID1, string ItemSubCategoryID2, string ItemSerialNo1, string ItemSerialNo2, decimal Quantity, decimal UnitPrice, decimal Weight, decimal WeightPrice,
            decimal Meter, decimal WeightAvg, decimal Amount, string sRemars, decimal dExRate)
        {
            try
            {
                clsHelpMethods.AddMultipleItems_Grid(dgvDetail, ItemID, ref iRow, ref iLineNo, ref Quantity, ref UnitPrice, ref Weight, ref WeightAvg);

                UnitPrice = getDisplayUnitPrice(UnitPrice, dExRate);
                WeightPrice = getDisplayUnitPrice(WeightPrice, dExRate);
                WeightAvg = getDisplayUnitPrice(WeightAvg, dExRate);
                Amount = getDisplayUnitPrice(Amount, dExRate);

                dgvDetail["LineNo", iRow].Value = iLineNo;
                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemSubCategoryID1", iRow].Tag = ItemSubCategoryID1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = ItemSubCategoryID2;
                dgvDetail["ItemSerialNo1", iRow].Value = ItemSerialNo1;
                dgvDetail["ItemSerialNo2", iRow].Value = ItemSerialNo2;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_ItemUOM(ItemID);

                dgvDetail["Remarks", iRow].Value = sRemars;

                if (clsCommon.IsCustomerizedGrid())
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Quantity);
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Meter", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(Meter);// add by thilina
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(Amount);
                    dgvDetail["Amount", iRow].Tag = Amount;

                    dgvDetail["UnitPrice", iRow].Value = (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 2) ? clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice) : clsFormatter.FormatToCurrecyWithFourDecimalPlaces(UnitPrice);
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["WeightPrice", iRow].Value = (clsConfig.sCurrencyDecimalPlaces_WeightPrice == 2) ? clsFormatter.FormatToCurrecyWithThousendSep(WeightPrice) : clsFormatter.FormatToCurrecyWithFourDecimalPlaces(WeightPrice);
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = (clsConfig.sCurrencyDecimalPlaces_UnitPrice == 2) ? clsFormatter.FormatToCurrecyWithThousendSep(WeightAvg) : clsFormatter.FormatToCurrecyWithFourDecimalPlaces(WeightAvg);
                    dgvDetail["WeightAvg", iRow].Tag = WeightAvg;
                }
                else
                {
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(System.Convert.ToDecimal(Quantity));
                    dgvDetail["UnitPrice", iRow].Value = UnitPrice.ToString();
                    dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(System.Convert.ToDecimal(Weight));
                    dgvDetail["WeightPrice", iRow].Value = WeightPrice.ToString();
                    dgvDetail["WeightPrice", iRow].Tag = WeightPrice;
                    dgvDetail["WeightAvg", iRow].Value = WeightAvg.ToString();
                    dgvDetail["WeightAvg", iRow].Tag = WeightAvg;
                    dgvDetail["Amount", iRow].Value = Amount.ToString();
                    dgvDetail["Amount", iRow].Tag = Amount;
                    dgvDetail["Meter", iRow].Value = Meter.ToString();
                }

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            finally
            {
                dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Rows[iRow].Cells["UnitPrice"].ColumnIndex, dgvDetail.Rows[iRow].Cells["UnitPrice"].RowIndex));
            }
        }
        #endregion

        #region Fill Currency Detials
        private void FillDetailsCurrency(string sCurrencyID)
        {
            try
            {
                txtCurrency.Tag = null;
                txtCurrency.Clear();

                if (sCurrencyID.Length > 0)
                {
                    tbl_zCurrency currency = tbl_zCurrency.Select(sCurrencyID);
                    if (currency != null)
                    {
                        txtCurrency.Tag = currency.Currency_ID;
                        txtCurrency.Text = currency.CurrencyName;
                        txtForExRate.Text = currency.CurrencyRate.ToString();
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

            clsHelpMethods.FormatGrid_Stock_External(dgvDetail);
            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            dgvDetail.Columns["ItemSubCategoryID1"].HeaderText = clsConfig.sItemSubCategory;
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

        #region Event CheckChange
        private void chkUnitPricing_CheckedChanged(object sender, EventArgs e)
        {
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                DataGridViewCellEventArgs ar = new DataGridViewCellEventArgs(0, row.Index);
                dgvDetail_CellEndEdit(sender, ar);
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

        #region Price Convertion
        public decimal getSavePrice(decimal dEnteredPrice)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtForExRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtForExRate.Text.Trim());

            dUnitPrice = dEnteredPrice * dExRate;
            return dUnitPrice;
        }

        public decimal getDisplayUnitPrice(decimal dEnteredUnitPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dEnteredUnitPrice / dExRate;
            return dUnitPrice;
        }
        #endregion

        #region Set Enable/Disable Area
        private void setEnableArea_PO(bool bActive)
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtPurchaseRequisitionID, bActive);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtQuotationID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblPurchaseRequisitionID, bActive);
            clsCommon.SetEnableDisable_NormalLabel(lblQuotationID, bActive);
            btnAddSR.Enabled = bActive;
            btnAddQuotation.Enabled = bActive;
        }
        #endregion

        #region Print Method
        private void Print(bool bIsDraft)
        {
            try
            {
                if (txtPOID.TextLength > 0 && txtPOID.Text != "<Auto Generate>")
                {
                    Cursor = Cursors.WaitCursor;

                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = true, bCheckingDone = true;

                    tbl_scsPurchaseOrder order = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                    if (order != null)
                    {
                        if (!bIsDraft)
                        {
                            #region Validate Approval
                            if (clsConfig.bApprovalNeedToPrintPO)
                            {
                                if (!order.IsApproved)
                                {
                                    bApprovalDone = false;
                                    MessageBox.Show("Please Approve the PO Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            #endregion
                            #region Validate Checking
                            if (clsConfig.bCheckingNeedToPrintPO)
                            {
                                if (!order.IsChecked)
                                {
                                    bCheckingDone = false;
                                    MessageBox.Show("Please Check the PO Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            #endregion
                        }

                        clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder), order.PurchaseOrder_ID);

                        #region Checked users
                        sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                        if (order.IsChecked && order.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                        if (order.IsApproved && order.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                        #endregion

                        if (bApprovalDone && bCheckingDone)
                        {
                            #region Validate Original Print and Duplicate Print
                            if (!bIsDraft)
                            {
                                #region Check Original Print
                                if (chkPrintOriginal.Checked)
                                {
                                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                                        bOkToPrint = true;
                                    else
                                    {
                                        frmSetApproved login = new frmSetApproved();
                                        login.iFormID = iFormID;
                                        login.ShowDialog();
                                        if (frmSetApproved.bChecked)
                                        {
                                            bOkToPrint = true;
                                        }
                                    }
                                }
                                else
                                {
                                    bOkToPrint = true;
                                    sDuplicateCopy = order.PrintCount > 0 ? "Duplicate Copy " + order.PrintCount : "";

                                    order.PrintCount++;
                                    order.Update();
                                }
                                #endregion
                            }
                            else
                                bOkToPrint = true;

                            if (order.IsDeleted)
                            {
                                bOkToPrint = true;
                                sDuplicateCopy = "";
                            }
                            #endregion

                            if (clsConfig.bDateSetActive_PurchaseOrderPrint)
                            {
                                #region DataSet
                                glb_dtsSasPurchaseOrder.Clear();
                                glb_dtsSasPurchaseOrder.Clear();

                                tbl_genSupplierMaster oSupplier = tbl_genSupplierMaster.Select(order.Supplier_ID);
                                tbl_zCurrency oCurrency = tbl_zCurrency.Select(order.Currency_ID);
                                tbl_zIssuedRefNo oRef = tbl_zIssuedRefNo.Select(order.IssuedRefNo_ID);

                                #region Purchase Order Header
                                if (oSupplier != null && oCurrency != null)
                                    glb_dtsSasPurchaseOrder.dt_scsPurchaseOrder.Adddt_scsPurchaseOrderRow(order.PurchaseOrder_ID, order.PurchaseOrderDate,
                                        "Seylan Bank PLC.,", "Kadawatha Branch, Kadawatha, \n(Postal Code :GQ11850), \nSri Lanka.", "0280 02208803001",
                                        getDisplayUnitPrice(order.SubTotal, order.ForexRate), order.DiscountPercentage, getDisplayUnitPrice(order.DiscountTotal, order.ForexRate),
                                        order.VatPercentage, getDisplayUnitPrice(order.VatTotal, order.ForexRate), getDisplayUnitPrice(order.GrandTotal, order.ForexRate),
                                        oSupplier.Supplier_ID, oSupplier.SupplierName, oSupplier.AddressRegister, oSupplier.Telephone, oSupplier.Fax, oSupplier.Remark,
                                        clsGenaralName.getName_StockNoteType(order.StockNoteType_ID), clsGenaralName.getName_PaymentMethod(order.PaymentMethod_ID), order.DeliveryAddress, order.DeliveryTerms, oCurrency.CurrencyCode,
                                        order.DeliveryTerms, order.DeliveryAddress, order.Remark, order.ForexRate, order.StockNoteType_ID, order.DateCreate, order.GlPosting_ID,
                                        order.OrderdBy, order.DueDate, order.QuotaionNo, order.PurchaseRequisitionNote_ID, oRef.IssuedRefNo, order.IsDeleted, order.CreateUser_ID,
                                        order.ApprovedUser_ID, order.DateCreate, order.DateApproved, 0, order.NbtPercentage, getDisplayUnitPrice(order.NbtTotal, order.ForexRate), order.OtherTaxTotal);

                                #endregion

                                #region Purchase Order Detail
                                foreach (tbl_scsPurchaseOrder_Detail Detail1 in tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(order.PurchaseOrder_ID).OrderBy(p => p.Line_No))
                                {
                                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(Detail1.Item_ID);
                                    tbl_zUom oUOM = tbl_zUom.Select(oItem.Uom_ID);
                                    if (oItem != null && oUOM != null)
                                    {
                                      //  string sRemarks = Detail1.Remark != "" ? Detail1.Remark : oItem.Remark;

                                        glb_dtsSasPurchaseOrder.dt_scsPurchaseOrder_Detail.Adddt_scsPurchaseOrder_DetailRow(Detail1.PurchaseOrder_ID, Detail1.Qty,
                                            oUOM.UomCode, getDisplayUnitPrice(Detail1.UnitPrice, order.ForexRate), getDisplayUnitPrice(Detail1.TotalDiscount, order.ForexRate), getDisplayUnitPrice(Detail1.TatalAmount, order.ForexRate),
                                            Detail1.Item_ID, oItem.ItemName, Detail1.Remark, Detail1.ItemSubCategory_ID, clsGenaralName.getName_ItemUOMName(Detail1.Item_ID), Detail1.Qty,
                                            Detail1.Weight, getDisplayUnitPrice(Detail1.UnitPrice, order.ForexRate), Detail1.KiloPrice);
                                    }
                                }
                                #endregion

                                #region Report Export Parameters

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("AmountsInWords", clsCommon.CurrencyToWord(decimal.Parse(clsFormatter.FormatDecimalPlaces_Price(getDisplayUnitPrice(order.GrandTotal, order.ForexRate)))), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyWebSite", clsCommon.getCompanyWeb(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("SVAT", clsCommon.getCompanySVAT(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVAT", clsCommon.getCompanyVAT(), true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", clsCommon.getCompanyEmail(), true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicateCopy, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("IsDraft", bIsDraft ? "DRAFT" : "", true,false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true,false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true,false);
                                #endregion

                                #region Company Details Fill
                                string sCompanyName = clsSecurity.CompanyName, sCompanyAddress1 = clsSecurity.CompanyAddress1, sCompanyAddress2 = clsSecurity.CompanyAddress2;
                                byte[] bCompanyImage = clsCommon.getCompanyImage();
                                string sCompanyVAT = clsCommon.getCompanyVAT(), sCompanySVAT = clsCommon.getCompanySVAT(), sCompanyBRNo = clsCommon.getCompanyBusinessRegisterNo();
                                if (bIsDraft)
                                {
                                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                    {
                                        sCompanyName = "";
                                        sCompanyAddress1 = "";
                                        sCompanyAddress2 = "";
                                        bCompanyImage = null;

                                        sCompanyVAT = "";
                                        sCompanySVAT = "";
                                        sCompanyBRNo = "";

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true,false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true,false);

                                    }
                                }
                                glb_dtsSasPurchaseOrder.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, sCompanyName, sCompanyAddress1, sCompanyAddress2, bCompanyImage, "PURCHASE ORDER", "Purchase Order", "", clsSecurity.UserNameLoged, "", sCompanyVAT, sCompanySVAT, sCompanyBRNo);
                                #endregion

                                #region Set Report Path and Datasets
                                frm_ReportViewer_New rpt = new frm_ReportViewer_New();
                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_PurchaseOrder));
                                rpt.print(sGetRptPath, glb_dtsSasPurchaseOrder, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_PurchaseOrder));
                                #endregion
                                #endregion
                            }
                            else
                            {
                                //#region Print The Doc
                                ////if ((bOkToPrint && bApprovalDone) || (bOkToPrint && bApprovalDone))
                                //if (bOkToPrint)
                                //{
                                //    #region Get print path and view
                                //    string s_Path = "", sReportTitle = "PURCHASE ORDER", sFormula = "";
                                //    if (txtPOID.TextLength > 0)
                                //        sFormula = "{vw_rpt_scsPurchaseOrder.purchaseOrder_ID} = '" + txtPOID.Text.Trim() + "'";
                                //    ReportDocument RD = new ReportDocument();
                                //    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                                //    string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_PurchaseOrder));
                                //    if (sGetRptPath != null && sGetRptPath.Length > 0)
                                //        s_Path += sGetRptPath;
                                //    else
                                //    {
                                //        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNote_WSC.rpt";
                                //        else
                                //            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNote_WSC.rpt";
                                //        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNote_WD.rpt";
                                //        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNote_WD.rpt";
                                //        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNoteITC.rpt";
                                //        else
                                //            s_Path += "\\reports\\SCS\\NotePrinting\\rpt_scsPurchaseOrderNote.rpt";
                                //    }

                                //    frm_ReportViewer viewer = new frm_ReportViewer();
                                //    viewer.crystalReportViewer1.ShowExportButton = true;
                                //    RD.Load(s_Path);
                                //    clsSecurity.LogonServer(ref RD);
                                //    RD.Refresh();
                                //    #endregion

                                //    #region Set TIEP
                                //    try
                                //    {
                                //        bool isTIEP = order.IsTIEP;
                                //        if (isTIEP)
                                //            RD.DataDefinition.FormulaFields["TIEP"].Text = clsCommon.fncsetstring("TIEP");
                                //    }
                                //    catch (Exception) { }
                                //    #endregion

                                //    #region Report Method
                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                //        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                //        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                                //    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                //    //{
                                //    //    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);
                                //    //    RD.DataDefinition.FormulaFields["Outstanding"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerTotalDues_All(txtCustomerID.Tag.ToString())));
                                //    //    RD.DataDefinition.FormulaFields["Cheques-In-Hand"].Text = clsCommon.fncsetstring(clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.GetCustomerChequesInHand(txtCustomerID.Tag.ToString())));
                                //    //    RD.DataDefinition.FormulaFields["PurchaseOrderNo"].Text = clsCommon.fncsetstring(clsHelpMethods.getCustomerPurchaseOrderID(order.OrderRefNo_ID));
                                //    //}

                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                //        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())// && !chkPrintWithAmounts.Checked && !chkPrintWithBreakdown.Checked)
                                //        RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);


                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //    {
                                //        RD.DataDefinition.FormulaFields["Com_VAT_No"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                                //        RD.DataDefinition.FormulaFields["Com_SVAT_No"].Text = clsCommon.fncsetstring(clsCommon.getCompanySVAT());
                                //    }

                                //    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //    {
                                //        if (txtQuotationID.Tag.ToString() == "default" && txtPurchaseRequisitionID.Tag.ToString() == "default")
                                //        {
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTColoumn"].Text = clsCommon.fncsetstring("P.R.No");
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTValue"].Text = clsCommon.fncsetstring("N/A");
                                //        }
                                //        else if (txtPurchaseRequisitionID.Tag != null && txtPurchaseRequisitionID.Tag.ToString().Length > 0 && txtPurchaseRequisitionID.Tag.ToString() != "default")
                                //        {
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTColoumn"].Text = clsCommon.fncsetstring("P.R.No");
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTValue"].Text = clsCommon.fncsetstring(order.PurchaseRequisitionNote_ID != "default" ? order.PurchaseRequisitionNote_ID : "");
                                //        }
                                //        else if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Length > 0 && txtQuotationID.Tag.ToString() != "default")
                                //        {
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTColoumn"].Text = clsCommon.fncsetstring("Q.U.T.No ");
                                //            RD.DataDefinition.FormulaFields["DyanmicPRNQTValue"].Text = clsCommon.fncsetstring(order.Quotation_ID != "default" ? order.Quotation_ID : "");
                                //        }
                                //    }


                                //    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                                //    //    RD.DataDefinition.FormulaFields["ProjectType"].Text = clsCommon.fncsetstring("c");

                                //    RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                //    RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                //    RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                                //    RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                //    RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                //    RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                //    RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                //    RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                //    RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                //    RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                //    RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                //    RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getSupplerTelephoneAndFax(order.Supplier_ID));
                                //    RD.DataDefinition.FormulaFields["OurVATNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyVAT());
                                //    RD.DataDefinition.FormulaFields["OurSVATNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanySVAT());
                                //    RD.DataDefinition.FormulaFields["BisRegNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo());

                                //    RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                                //    RD.DataDefinition.FormulaFields["IsDraft"].Text = bIsDraft ? "DRAFT" : "";

                                //    if (bIsDraft)
                                //    {
                                //        if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                //        {
                                //            RD.DataDefinition.FormulaFields["CompanyName"].Text = "";
                                //            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = "";
                                //            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = "";
                                //            RD.DataDefinition.FormulaFields["CompanyEmail"].Text = "";
                                //            RD.DataDefinition.FormulaFields["TelphoneFax"].Text = "";
                                //            RD.DataDefinition.FormulaFields["OurVATNo"].Text = "";
                                //            RD.DataDefinition.FormulaFields["OurSVATNo"].Text = "";
                                //            RD.DataDefinition.FormulaFields["BisRegNo"].Text = "";
                                //        }
                                //    }


                                //    viewer.crystalReportViewer1.ReportSource = RD;
                                //    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                //    viewer.crystalReportViewer1.Visible = true;
                                //    viewer.crystalReportViewer1.DisplayToolbar = true;
                                //    viewer.crystalReportViewer1.CloseView(false);
                                //    viewer.WindowState = FormWindowState.Maximized;

                                //    viewer.ShowDialog();

                                //    RD.Close();
                                //    RD.Dispose();
                                //    #endregion
                                //}
                                //#endregion
                            }
                        }
                    }
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
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region User Checked Approve Details
        private void frm_scsPurchaseOrder_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_scsPurchaseOrder_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        #region Approved and Checked Search
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPoDate.Value.Date))
                {
                    if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPOID.Text != null && txtPOID.TextLength > 0 && txtPOID.Text != "<Auto Generate>")
                        {
                            if (CheckValidity_Budget())
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

                                            tbl_scsPurchaseOrder objPO = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                                            if (objPO != null)
                                            {
                                                objPO.IsApproved = true;
                                                objPO.DateApproved = clsSecurity.getServerDateTime();
                                                objPO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                                objPO.Update();
                                            }
                                        }
                                    }
                                    else if (frmSetApproved.bReset)
                                        bHasApproved = false;
                                }
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
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpPoDate.Value.Date))
                {
                    if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                    {
                        if (txtPOID.Text != null && txtPOID.TextLength > 0 && txtPOID.Text != "<Auto Generate>")
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

                                        tbl_scsPurchaseOrder objPO = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
                                        if (objPO != null)
                                        {
                                            objPO.IsChecked = true;
                                            objPO.DateChecked = clsSecurity.getServerDateTime();
                                            objPO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objPO.Update();
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

        private void frm_scsPurchaseOrder_SF_History_Click(object sender, EventArgs e)
        {
            if (txtPOID.Text != "" || txtPOID.Text != "<Auto Generate>")
            {
                tbl_scsPurchaseOrder detail = tbl_scsPurchaseOrder.Select(txtPOID.Text.Trim());
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

        #region Setting Panel Events
        public override void SettingsClick()
        {
            xSetting.Visible = true;
            xSetting.Focus();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }

        private void xSetting_Leave(object sender, EventArgs e)
        {
            xSetting.Visible = false;
        }
        #endregion
    }
}