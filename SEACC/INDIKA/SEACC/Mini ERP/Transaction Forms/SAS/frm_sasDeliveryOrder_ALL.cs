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
using SEACC.DATA.Data.BSS;

namespace Digiteq
{
    public partial class frm_sasDeliveryOrder_ALL : SEACC_Form
    {
        #region Variables

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
        #endregion

        SasDeliveryOrder_data data = new SasDeliveryOrder_data();
        InventoryTxnData oData = new InventoryTxnData();
        RouteLockData routeValidation = new RouteLockData();
        dts_sasInvoice glb_dtsSasInvoice = new dts_sasInvoice();

        string sFormConfigCodeVAT = clsAutocode.getFormConfigCode(FormName.VATInvoice);
        string sFormConfigCodeNonTax = clsAutocode.getFormConfigCode(FormName.NonTaxInvoice);
        string sFormConfigCodeSVAT = clsAutocode.getFormConfigCode(FormName.SVATInvoice);

        clsAlerts_Email email = new clsAlerts_Email();

        #region Form Load
        public frm_sasDeliveryOrder_ALL(FormName _enmForm)
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
            CusDataGridViewFormat();

            ClearFields();
            dgvDetail.Columns["Weight"].Visible = clsConfig.bShowQtyANDWeightColumns_DO;
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
                        parm.Header.job_ID = "";
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
                        parm.Header.itemPriceCategory = "";
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
                                item.uom_ID = clsValidate.ValidateGridTag(dgvDetail, "UOM", row.Index, "default");

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
                        //    parm.configForm_ID = sFormConfigCode;
                        parm.orderRefNo = txtOrderRefNo.Text;

                        //if (chkVat.Checked)
                        //    parm.configForm_ID = sFormConfigCodeVAT;
                        //else if (chkOtherTax.Checked)
                        //    parm.configForm_ID = sFormConfigCodeSVAT;
                        //else
                            parm.configForm_ID = sFormConfigCodeNonTax;

                        var result = data.Save_AllInDO(parm);
                        if (result.IsSuccess)
                        {
                            clsMethods_GL.PostTransaction_Invoice(result.ReturnValue);
                            txtDeliveryOrderID.Text = result.ReturnValue;

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Cancle
        private void frm_sasDeliveryOrder_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength == 0)
                    return;

                if (!clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                    return;

                if (!clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    return;

                int Route = -1;
                int.TryParse(lblRoute.Tag.ToString(), out Route);
                if (!clsSecurity.Permission_Route(clsSecurity.UserIDLoged, Route))
                    return;

                if (!clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                    return;

                Cursor = Cursors.WaitCursor;
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                tbl_sasInvoice Inv = tbl_sasInvoice.Select(txtDeliveryOrderID.Text.Trim());
                tbl_sasCustomerOrder Co = tbl_sasCustomerOrder.Select(txtDeliveryOrderID.Text.Trim());
                if (detail != null && Inv != null && Co != null)
                {
                    if (Inv.SeattleAmount == 0)
                    {
                        if (ValidateForDependancies(detail.DeliveryOrder_ID))
                        {
                            if (!detail.IsLocked)
                            {
                                if (!detail.IsDeleted)
                                {
                                    // frmCancel_DO frm = new frmCancel_DO();
                                    // frm.glbNoteID = "D/O Number : " + txtDeliveryOrderID.Text.Trim();
                                    // frm.ShowDialog();

                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Invoice : " + detail.DeliveryOrder_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        #region INV
                                        clsMethods_GL.GLPosting_Delete(Inv.GlPosting_ID);
                                        clsHelpMethods_Local.RemoveSattlementsFrom_InvoiceID(Inv.Invoice_ID);

                                        #region Update Other Tables
                                        List<tbl_sasInvoice_Detail> Invdetails = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(txtDeliveryOrderID.Text.Trim());
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

                                        Inv.DeletedUser_ID = clsSecurity.UserIDLoged;
                                        Inv.DateDeleted = clsSecurity.getServerDateTime();
                                        Inv.DeletedTerminal_ID = clsSecurity.TerminalID;
                                        Inv.IsDeleted = true;
                                        Inv.DateModified = clsSecurity.getServerDateTime();
                                        Inv.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        Inv.Update();

                                        //  clsAlerts_Email.createEmail_Invoice(txtDeliveryOrderID.Text.Trim(), enum_Alerts.InvoiceCanceled);
                                        //    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        // ClearFields(); 
                                        #endregion

                                        #region DO
                                        //Update Other Tables
                                        #region Update Other Tables
                                        foreach (var Dodetail in tbl_sasDeliveryOrder_Detail_Ex.SelectAllByDeliveryOrder_ID2(txtDeliveryOrderID.Text.Trim()))
                                        {
                                            if (Dodetail.Item_ID != null)
                                            {
                                                #region Unsettle Customer Order

                                                #region Get Canceled Reson Properties
                                                bool bTotalCancel = false;
                                                //if (frm.glbSystemReson)
                                                //{
                                                //    tbl_zCancelReson_DO cancelDO = tbl_zCancelReson_DO.Select(frm.glbSystemResonID);
                                                //    if (cancelDO != null)
                                                //    {
                                                //        if (cancelDO.IsPermanentCancel)
                                                //            bTotalCancel = true;
                                                //        else if (cancelDO.IsRepeatDelivery)
                                                //            bTotalCancel = false;
                                                //    }
                                                //}
                                                //else
                                                //    bTotalCancel = true;
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
                                            //    clsHelpMethods_Local.UpdateStoreStock(iFormID, Dodetail.DeliveryOrder_ID, detail.DeliveryOrderDate, Dodetail.Item_ID, "0", Dodetail.store_ID, Dodetail.Qty, Dodetail.Weight, Dodetail.TatalAmount, true, false, false, ref dWeightedAverageCostPrice);

                                                Dodetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(Dodetail.Item_ID);
                                                Dodetail.Update();
                                                //   clsHelpMethods_Local.RollBackFifo_Stock(iFormID, Dodetail.DeliveryOrder_ID, Dodetail.Qty);
                                                #endregion
                                            }
                                        }
                                        #endregion

                                        //if (frm.glbSystemReson)
                                        //    detail.CancelReason_ID_DO = frm.glbSystemResonID;
                                        //else
                                        //    detail.CancelReason_ID_DO = "default";

                                        detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                        detail.DateDeleted = clsSecurity.getServerDateTime();
                                        detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                        detail.IsDeleted = true;
                                        detail.DateModified = clsSecurity.getServerDateTime();
                                        detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        detail.Update();

                                        var responce = oData.Delete_InventoryTxn(11, txtDeliveryOrderID.Text.Trim());
                                        if (!responce.IsSuccess)
                                        {
                                            clsValidate.WriteErrorLog(txtDeliveryOrderID.Text.Trim() + " - " + responce.OutMsg, iFormID, null);
                                        }
                                        #endregion

                                        #region CO
                                        #region Update Other Tables
                                        List<tbl_sasCustomerOrder_Detail> Codetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtDeliveryOrderID.Text.Trim());
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

                                        Co.DeletedUser_ID = clsSecurity.UserIDLoged;
                                        Co.DateDeleted = clsSecurity.getServerDateTime();
                                        Co.DeletedTerminal_ID = clsSecurity.TerminalID;
                                        //-K-

                                        Co.IsDeleted = true;
                                        Co.DateModified = clsSecurity.getServerDateTime();
                                        Co.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                        Co.Update();
                                        #endregion


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
                    else
                        MessageBox.Show("This invoice is alredy settled", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                            //   txtJobCode.Tag = clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID);
                            //    txtJobCode.Text = clsCommon.GetForeignKeyValue(clsHelpMethods_Local.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID));

                            txtStoreID.Tag = detail.Store_ID;
                            txtStoreID.Text = clsGenaralName.getName_Store(detail.Store_ID);

                            dtpReceivedDate.Value = detail.DeliveryDate;

                            if (clsConfig.sSoftwareModel != SoftwareModel_Sales.ePackWithSubCategory.ToString())
                            {
                                txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                                txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));
                            }

                            //if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                            //{
                            //    foreach (ComboBoxItem d in cmbItemPrice.Items)
                            //    {
                            //        if (d.Value == detail.ItemPriceCategory)
                            //        {
                            //          //  cmbItemPrice.SelectedItem = d;
                            //            break;
                            //        }
                            //    }
                            //}

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
                // if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
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
                        if (detail.isBlackList)
                        {
                            MessageBox.Show("BlackListed Items cannot add to the customer order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0 && txtCustomerID.Tag.ToString().Trim() != "default")
                        {
                            if (clsValidate.Validate_CustomerWise_ItemPricing_Enable(txtCustomerID.Tag.ToString().Trim(), detail.Item_ID, "", "", "0", "0"))
                            {
                                RefreshGridByItemID(detail.Item_ID, "", "", "0", "0");
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
                    clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, "default", ref txtDeliveryOrderID, IsUpdate);

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
          //  dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_DO ? true : false;
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
            //  txtJobCode.Tag = null;
            txtStoreID.Tag = null;
            txtItemID.Tag = null;
            // txtItemSubCategory.Tag = null;
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
            //txtJobCode.Clear();
            txtAssistantID.Clear();
            txtVehicleID.Clear();
            txtAddress.Clear();
            txtReceiptBy.Clear();
            txtRemark.Clear();
            txtVehicalNo.Clear();
            // txtItemSubCategory.Clear();
            // txtItemSerialNo.Clear();
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

            //foreach (ComboBoxItem d in cmbItemPrice.Items)
            //{
            //    if (d.Value == clsConfig.sItemUnitPriceCode_Default)
            //    {
            //        cmbItemPrice.SelectedItem = d;
            //        break;
            //    }
            //}

            //    lblInquiryID.Visible = false;
            //   txtJobCode.Visible = false;
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
                //  cmbItemPrice.Visible = false;
                //  label37.Visible = false;
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

            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, "default", ref txtDeliveryOrderID, IsUpdate);

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

                        Fill_Datagrid(true,ref iRow, detail.line_No, detail.item_ID, detail.customerOrder_ID, detail.quotation_ID, detail.job_ID, item.Uom_ID, detail.unitPrice, detail.weightPrice, detail.bIsFreeItem, detail.discountPresentage, detail.discountAmount, detail.tatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.weight, dCOQty, detail.qty, "O",
                            detail.remark, detail.carton_No, bHasSettledBefore, dExRate, detail.store_ID, detail.storeName);
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

                        Fill_Datagrid(true,ref iRow, detail.Line_No, detail.Item_ID, detail.CustomerOrder_ID, detail.Quotation_ID, "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_DeliveryOrder), detail.Qty, (detail.Qty - detail.QtySettle_DeliveryOrder), "N",
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

                        Fill_Datagrid(true,ref iRow, detail.Line_No, detail.Item_ID, "default", detail.Quotation_ID, "default", item.Uom_ID, detail.UnitPrice, detail.WeightPrice, false, 0, 0, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_CustomerOrder), 0, (detail.Qty - detail.QtySettle_CustomerOrder), "N",
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

                    dgvDetail.Focus();
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = detail.Qty==0?1: detail.Qty;
                    decimal dAmount = oItemF.SellingPrice1 * dQty;
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
                  Fill_Datagrid(false,ref iRow, MaxID + 1, detail.Item_ID, "default", "default", "default", detail.Uom_ID, dUnitPrice, dWeightPrice, false, 0, 0, dAmount, detail.Width, detail.Height, detail.Thickness, detail.Gusset, dWeight, 0, dQty, "N",
                        detail.Description, "", bHasSettledBefore, dExRate, store_ID, Store_Name);
                    dgvDetail.CurrentCell = dgvDetail.Rows[iRow].Cells["Quantity"];
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
                        //   txtJobCode.Tag = detail.Job_ID;
                        txtDriverID.Tag = detail.Driver_ID;
                        txtAssistantID.Tag = detail.Assitant_ID;
                        txtVehicleID.Tag = detail.Vehicle_ID;
                        txtStoreID.Tag = detail.Store_ID;
                        txtDeliveryOrderID.Tag = detail.DeliveryOrder_ID;
                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;

                        if (detail.ItemPriceCategory.Length > 0 && detail.ItemPriceCategory != "default")
                        {
                            //foreach (ComboBoxItem d in cmbItemPrice.Items)
                            //{
                            //    if (d.Value == detail.ItemPriceCategory)
                            //    {
                            //        cmbItemPrice.SelectedItem = d;
                            //        break;
                            //    }
                            //}
                        }

                        txtCustomerOrderID.Text = clsCommon.GetForeignKeyValue(detail.CustomerOrder_ID);
                        txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                        //     txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
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
                    txtAddress.Text = customer.AddressRegister;

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
        private void Fill_Datagrid(bool IsUpdateMode,ref int iRow, int lineNo, string ItemID, string CusOrderID, string QuotationID, string JobID, string Uom_ID, decimal UnitPrice, decimal WeightPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
                            decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal COQty, decimal Qty, string sItemStatus, string Remark, string cartonNo, bool bHasSettled, decimal dExRate, string Store_ID, String Store_Name)
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
            dt_ItemGrouped = clsCommon.DataGridViewToDataTable_ItemGrouped(dgvDetail);

            bool bStatus = false;


            if (!CheckValidity_EmptyField())
                return false;

            var s = routeValidation.CheckValidity_RouteLock(int.Parse(lblRoute.Tag.ToString()));
            if (!s.IsSuccess)
            {
                if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 111))
                {
                    DialogResult msgResult = MessageBox.Show("The route is locked /nDo you need to overide?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (msgResult != DialogResult.Yes)
                        return false;
                }
                else
                {
                    MessageBox.Show("Sorry! The route is locked");
                    return false;
                }
            }

            if (!CheckNumberValidity())
                return false;

            if (!CheckPackingSizeValidity())
                return false;

            if (!CheckValidity_RouteWiseDiscount())
                return false;

            if (!CheckValidity_ItemDiscount())
                return false;

            if (!CheckItemSettleValidity())
                return false;

            if (!clsValidate.ValidateSellpriceVsCostPrice(dgvDetail))
                return false;

            if (!clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                return false;

            if (!clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                return false;

            if (!clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                return false;

            if (!CheckGrandTotal_Minus())
                return false;

            //if (!CheckValidity_QuntityExceededPercentage())
            //    return false;

            if (!CheckValidity_OrderRef())
                return false;

            if (!CheckOutstandingValidity())
                return false;

            //  var oretChq = tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomerID.Tag.ToString()).;

            decimal oldTotal = 0;


            if (IsUpdate)
            {
                tbl_sasDeliveryOrder oldRecord = tbl_sasDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                {
                    oldTotal = oldRecord.GrandTotal;
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



    //        if (!clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit( txtCustomerID,  txtGrandTotal, oldTotal))
     //           return false;
            decimal GrandTot = 0;
            decimal.TryParse(txtGrandTotal.Text, out GrandTot);
            var x = data.sp_CheckValidity_Order(txtCustomerID.Tag.ToString(), GrandTot, oldTotal);
            if (!x.IsSuccess)
            {
                MessageBox.Show(x.OutMsg);
                ClearFields();
            }


            return bStatus;
        }

        private bool CheckValidity_OrderRef()
        {
            bool bStatus = false;
            int iStatus = 0;
            int iRoute = -1;
            int.TryParse(lblRoute.Tag.ToString(), out iRoute);

            if (IsUpdate)
            {
                bStatus = true;
            }
            else
            {

                iStatus = DBHandling.ExecQuery_ReturnInt("select dbo.GetOrderRefStatus('" + txtOrderRefNo.Text + "'," + iRoute + ")");
                if (iStatus == 1)
                { bStatus = true; }
                else
                {
                    MessageBox.Show("Invalid Order Reference id ");
                }
            }

            return bStatus;
        }
        //public static bool CheckOutstandingValidity_CreditPeriodAndLimit(ref TextBox txtCustomer, ref TextBox txtGrandTotal)
        //{
        //    bool bOk_CreditPeriod = true, bOK_CreditLimit = true;

        //    tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
        //    if (customer != null && customer.Customer_ID != "default")
        //    {
        //        #region Check For Blacklisted customers
        //        if (customer.IsBlacklisted)
        //        {
        //            bOk_CreditPeriod = false;
        //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        }
        //        #endregion
        //        else
        //        {
        //            decimal dCreditPeriod = 0, dCreditLimit = 0;
        //            tbl_genCustomerFinance oCusFinance = tbl_genCustomerFinance.Select(txtCustomer.Tag.ToString());
        //            if (oCusFinance != null)
        //            {
        //                dCreditPeriod = oCusFinance.CreditPeriod;
        //                dCreditLimit = oCusFinance.CreditLimit;
        //            }

        //            #region Credit period
        //            if (clsConfig.bValidate_InvoiceCreditPeriod_Block || clsConfig.bValidate_InvoiceCreditPeriod_Messege)
        //            {
        //                int iNOofInvoices = 0;
        //                string sInvoices = "";
        //                decimal dTot = 0;

        //                foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.GrandTotal > 0))
        //                {
        //                    int iDays = clsCommon.getDaysUptoDate(oInvoice.InvoiceDate.Date);
        //                    if (iDays <= oCusFinance.CreditPeriod)
        //                        continue;

        //                    dTot += oInvoice.GrandTotal - oInvoice.SeattleAmount;
        //                    iNOofInvoices++;
        //                    sInvoices += oInvoice.Invoice_ID + ", ";
        //                }

        //                if (iNOofInvoices > 0)
        //                {
        //                    bOk_CreditPeriod = false;
        //                    //string sMsg = "This customer has " + iNOofInvoices + " Credit period exceeded invoices (" + clsFormatter.FormatDecimalPlaces_Price(dTot) + ")";
        //                    string sMsg = "This customer has " + iNOofInvoices + " unsettled invoice/s : \n" + sInvoices;
        //                    if (clsConfig.bValidate_InvoiceCreditPeriod_Block)
        //                        MessageBox.Show(sMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //                    else
        //                    {
        //                        DialogResult msgResult = MessageBox.Show(sMsg + " \nDo you want to proceed?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        //                        if (msgResult == DialogResult.Yes)
        //                            bOk_CreditPeriod = true;
        //                    }
        //                }
        //            }
        //            #endregion

        //            #region Credit Limit
        //            if (bOk_CreditPeriod)
        //            {
        //                if (clsConfig.bValidate_CreditBalance_Message || clsConfig.bValidate_CreditBalance_Block)
        //                {
        //                    var data = new DebtorOutstandingData();
        //                    var dt = data.GetDetails(customer.Customer_ID);

        //                    decimal total = dt.Sum(item => item.Amount);

        //                    decimal dAmountDue = 0;
        //                    if (txtGrandTotal.TextLength > 0)
        //                        dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());

        //                    //   if ((GetCustomerTotalDues_All(txtCustomer.Tag.ToString()) + dAmountDue) > dCreditLimit)
        //                    if ((total + dAmountDue) > dCreditLimit)
        //                    {
        //                        bOK_CreditLimit = false;

        //                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, 900, true, false))
        //                        {
        //                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
        //                            if (msgResult == DialogResult.Yes)
        //                                bOK_CreditLimit = true;
        //                        }
        //                        else
        //                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);

        //                    }
        //                }
        //            }
        //            #endregion
        //        }
        //    }
        //    return (bOk_CreditPeriod && bOK_CreditLimit);
        //}
        private bool CheckValidity_RouteWiseDiscount()
        {
            bool bValue = true;

            int route = int.Parse(lblRoute.Tag.ToString());
            decimal DisPresent = 0;
            decimal dDiscountUI = decimal.Parse(txtDiscount.Text);
            decimal dSubTot = decimal.Parse(txtSubTotal.Text);
            if (dSubTot != 0)
                DisPresent = dDiscountUI * 100 / dSubTot;

            var Discount = new RouteWiseItemDiscData().GetDiscount(route);

            if (DisPresent > Discount)
            {
                MessageBox.Show("Maximum Discount for the route exceeded", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                bValue = false;
            }

            return bValue;
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
                    if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                        bStatus = true;
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
                int route = int.Parse(lblRoute.Tag.ToString());

                var MaxDisc = new masRouteWiseItemPricingData().GetMaxDiscount(route, sItemCode);


                //  tbl_genItemMaster_Discount oDiscount = tbl_genItemMaster_Discount.Select(sItemCode);
                //   if (oDiscount != null)
                {
                    //if ((MaxDisc > 0) && (dDiscountValue > MaxDisc))
                    //{
                    //    bValue = false;
                    //    MessageBox.Show("Maximum Discount Amount " + clsFormatter.FormatDecimal(MaxDisc, 2) + " Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
                    //        clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    break;
                    //}

                    if ((dDiscountPresentage > MaxDisc))
                    {
                        bValue = false;
                        MessageBox.Show("Maximum Discount Pecentage " + clsFormatter.FormatDecimal(MaxDisc, 2) + "% Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
                            clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }

                }
            }

            return bValue;
            //bool bValue = true;

            //foreach (DataGridViewRow row in dgvDetail.Rows)
            //{
            //    string sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
            //    string sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row.Index, "");
            //    decimal dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
            //    decimal dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

            //    tbl_genItemMaster_Discount oDiscount = tbl_genItemMaster_Discount.Select(sItemCode);
            //    if (oDiscount != null)
            //    {
            //        if ((oDiscount.MaxDiscountAmt > 0) && (dDiscountValue > oDiscount.MaxDiscountAmt))
            //        {
            //            bValue = false;
            //            MessageBox.Show("Maximum Discount Amount " + clsFormatter.FormatDecimal(oDiscount.MaxDiscountAmt, 2) + " Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
            //                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            break;
            //        }

            //        if ((oDiscount.MaxDiscountPct > 0) && (dDiscountPresentage > oDiscount.MaxDiscountPct))
            //        {
            //            bValue = false;
            //            MessageBox.Show("Maximum Discount Pecentage " + clsFormatter.FormatDecimal(oDiscount.MaxDiscountAmt, 2) + "% Exceeded...\nItem : <<" + sItemCode + ">> - " + sItemName,
            //                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            break;
            //        }

            //    }
            //}

            //return bValue;
        }


        //    string sInvoiceID;
        private bool ValidateForDependancies(string sDeliveryOrderID)
        {
            bool bValue = true;
            try
            {
                //  bool bValue = true;
                foreach (tbl_sasSalesReturnedNote_Detail oSR in tbl_sasSalesReturnedNote_Detail.SelectAllByInvoice_ID(sDeliveryOrderID))
                {
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(oSR.SalesReturnedNote_ID);
                    if (detail != null && detail.SalesReturnedNote_ID != "default" && !detail.IsDeleted)
                    {
                        bValue = false;
                        MessageBox.Show("Record Is Locked! \n\n[" + detail.SalesReturnedNote_ID + "] SRN is already created for this Invoice", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }

                }


                //foreach (tbl_sasInvoice_Detail oIn in tbl_sasInvoice_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID))
                //{
                //    sInvoiceID = oIn.Invoice_ID;
                //    tbl_sasInvoice detail = tbl_sasInvoice.Select(oIn.Invoice_ID);
                //    if (detail != null && detail.Invoice_ID != "default" && !detail.IsDeleted)
                //    {
                //        bValue = false;
                //        MessageBox.Show("Record Is Locked! \n\n[" + detail.Invoice_ID + "] Invoice is already created for this Delivery Order", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        break;
                //    }

                //}
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
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.EnterMinusValues), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtCustomerOrderID);
            clsCommon.ValidateForeignKey(ref txtQuotationID);
            clsCommon.ValidateForeignKey(ref txtTownID);
            //    clsCommon.ValidateForeignKey(ref txtJobCode);

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
                Search_CustomerID();
        }

        private void txtCustomerOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerOrderID(sender);
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_QuotationID();

        }
        private void txtVehicleID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_VehicleID();
        }
        private void txtDriverID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DriverID();
        }
        private void txtAssistantID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_AssistantID();
        }

        private void txtbrk_Pack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_UomID();
        }
        private void frm_sasCustomerDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
            if (e.KeyCode == Keys.F5)
            {
                MessageBox.Show("F%");
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
                Search_SalesExecutiveID();
        }
        private void txtTownID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterTown(ref txtTownID);
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

                if (sColName == "Free")
                {
                    if (bHasPermissionToFreeIssures)
                    {
                        bool bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                        dgvDetail["Free", e.RowIndex].Value = bIsFreeItem ? false : true;
                        dgvDetail_CellEndEdit(sender, e);
                    }
                }
                if (sColName == "DiscuntPresentage")
                {
                    var detail = tbl_genItemMaster_Discount.Select(txtItemID.Tag.ToString().Trim());
                    if (detail != null)
                    {
                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = detail.MaxDiscountPct*100;
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
                    RefreshGridBreakdownGenaral(txtDeliveryOrderID.Text.Trim());

                else
                    tbcChequeManagement.SelectedTab = tbpGenaral;

            }
        }
        #endregion

        #region Search Methods
        private void Search_DeliveryOrderID()
        {
            clsSearch.Search_TransactionDeliveryOrder_Direct(ref txtDeliveryOrderID, chkShowSettle.Checked, 1);

            if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtDeliveryOrderID.Tag.ToString());
        }
        private void Search_QuotationID()
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionQuotation_Use(ref txtQuotationID, txtCustomerID.Tag.ToString(), false);

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
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, "default", ref txtDeliveryOrderID, IsUpdate);
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
                #region TEMP
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
                                {
                                    FillDetailsCustomer(sCustomerID);
                                }
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

                                var add = Detail.FirstOrDefault().Address;
                                if (add != "")
                                    txtAddress.Text = add;

                                var RouteName = clsGenaralName.getCode_Route(Detail.FirstOrDefault().Route_ID);
                                lblRoute.Text = "Route Code - " + RouteName;
                                lblRoute.Tag = Detail.FirstOrDefault().Route_ID.ToString();

                                var s = routeValidation.CheckValidity_RouteLock(int.Parse(lblRoute.Tag.ToString()));
                                if (!s.IsSuccess)
                                {
                                    if (clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, 111))
                                    {
                                        DialogResult msgResult = MessageBox.Show("The route is locked /nDo you need to overide?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                        if (msgResult != DialogResult.Yes)
                                            ClearFields();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry! The route is locked");
                                        ClearFields();
                                    }
                                }

                                txtSalesNoteType.Tag = clsGenaralName.getSalesNoteType_ByRoute(RouteName);
                                txtSalesNoteType.Text = RouteName;
                                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtDeliveryOrderID, IsUpdate);

                            }
                            decimal invAmount = 0;
                            if (txtGrandTotal.TextLength > 0)
                                invAmount = decimal.Parse(txtGrandTotal.Text.Trim());

                            decimal GrandTot = 0;
                            decimal.TryParse(txtGrandTotal.Text, out GrandTot);
                            
                            var x = data.sp_CheckValidity_Order(txtCustomerID.Tag.ToString(), GrandTot, invAmount);
                            if (!x.IsSuccess)
                            {
                                MessageBox.Show(x.OutMsg);
                                ClearFields();
                            }
                        

                           // if (!clsHelpMethods_Local.CheckOutstandingValidity_CreditPeriodAndLimit( txtCustomerID,  txtGrandTotal, invAmount))
                            //    ClearFields();
                            //else
                            //{
                            //    var x = data.CheckForUnsettledReturnCheques(txtCustomerID.Tag.ToString());
                            //    if (x.OutMsg != "0")
                            //    {
                            //        string sMsg = "This customer has unsettled return cheques";
                            //        MessageBox.Show(sMsg);
                            //        ClearFields();
                            //    }
                            //}
                        }
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
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
            if (!CheckValiditeCustomerAndStore())
                return;

            if (e.KeyCode == Keys.F1)
            {
                if ((clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder) && !clsConfig.bSingleItemStockEnabled)
                {
                    clsSearch.Search_TransactionItemMasterByStore(ref txtItemID, "");

                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else
                {
                    //clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                    clsSearch.Search_TransactionByItemCodeItemMaster(ref txtItemID);//, txtStoreID.Tag.ToString());
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    {
                        //  txtItemSubCategory.Tag = "default";
                        //  txtItemSerialNo.Tag = "0";
                        btnAddItem_Click(sender, new EventArgs());
                    }
                }
            }
            //               else if (e.KeyCode == Keys.F5)
            //               {
            //                   frm_sasMultipleItemSelect frm = new frm_sasMultipleItemSelect();
            //                   string sItemPriceCategory = "";
            //                   frm.glb_sItemPriceCategory = sItemPriceCategory;
            //                   frm.glb_sStoreID = txtStoreID.Tag.ToString();
            //                   frm.ShowDialog();

            //                   if (frm.lstclsTmpMultipleSelectedItems.Count > 0)
            //                   {
            //                       foreach (clsTmpMultipleSelectedItems oItem in frm.lstclsTmpMultipleSelectedItems)
            //                       {
            //                           dgvDetail.Rows.Add();
            //                           int iRow = dgvDetail.Rows.Count - 1;
            //                           decimal dExRate = 0;
            //                           if (txtCurrencyRate.Text.Trim().Length > 0)
            //                               dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());
            //                           bool bHasSettledBefore = true;
            //                         //  Fill_Datagrid(false, iRow, iRow, oItem.sItemID, "default", "default", "default", oItem.sUOMID, oItem.dUnitPrice, oItem.dWeightPrice, false, 0, 0, oItem.dTotalAmount, 0, 0, 0, 0, oItem.dWeight, 0, oItem.dQty, "N", oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "", "", bHasSettledBefore, dExRate);
            //                       }
            //                   }
            //               }
            //               else
            //               {
            //clsSearch.Search_TransactionItemMasterByStore(ref txtItemID, txtStoreID.Tag.ToString());
            //                   if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
            //                   {
            //                       btnAddItem_Click(sender, new EventArgs());
            //                   }
            //               }


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

        #region Print Method
        private void print(bool bIsDraft)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                {
                    if (!chkPrintInvoice.Checked)
                    {
                        #region dataset
                        try
                        {
                            string sBranchId = "", s_Path = "", sCusAddress = "", sStoreID = "default", sStoreName = "", sRoute = "", sSalesmanContact = "", sReportID = clsAutocode.getReportID(enum_ReportName.NP_Invoice);
                            decimal dCreditBalance = 0, dGrandTotal = 0;
                            bool bCheckingDone = true, bApprovalDone = true, bPermissinOkToPrint = false, bPermissinOkToPrintOriginal = true, bCreditLimitOK = false;
                            Cursor = Cursors.WaitCursor;

                            if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                            {
                                glb_dtsSasInvoice.Clear();
                                glb_dtsReportExport.Clear();

                                int count = 0;
                                String sDuplicateCopy = "";
                                String sDeliveryOrders = "";

                                tbl_sasInvoice Detail = tbl_sasInvoice.Select(txtDeliveryOrderID.Text);
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
                                                                clsGenaralName.getName_Brand(oItmaster.Brand_ID), dUnitPrice, dQTY, oItmaster.ItemName, Detail1.Remark, oUom.UomCode, count, clsGenaralName.getName_Store_Short(Detail1.store_ID), Detail1.DiscountPresentage, clsHelpMethods_Local.getDisplayPrice(Detail1.DiscountAmount, Detail.CurrencyRate), clsHelpMethods_Local.getDisplayPrice(Detail1.TatalAmount, Detail.CurrencyRate), Detail1.BIsFreeItem, clsHelpMethods_Local.getDisplayPrice(Detail1.DiscountAmount, Detail.CurrencyRate) * dQTY, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID));
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

                                email.createEmail_Invoice(txtDeliveryOrderID.Text.Trim(), enum_Alerts.InvoicePrinted);
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
                    else
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
                                                glb_dts_DeliveryOrders.dt_deliveryOrderDetail.Adddt_deliveryOrderDetailRow(oDetails_DO.deliveryOrder_ID, "0", oDetails_DO.item_ID, clsGenaralName.getName_Item(oDetails_DO.item_ID), oDetails_DO.remark, oDetails_DO.carton_No, oDetails_DO.qty, oDetails_DO.weight, clsGenaralName.getName_ItemUOMName(oDetails_DO.item_ID), oDetails_DO.unitPrice, oDetails_DO.bIsFreeItem, oDetails_DO.discountPresentage, oDetails_DO.discountAmount, oDetails_DO.tatalAmount, dCustomerOrderQty, clsHelpMethods.GetPLU(oCustomer.Customer_ID, oItmaster.Item_ID), oDetails_DO.store_ID, oDetails_DO.storeName);
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

        #endregion

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
        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }

        #region User Checked Approve Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (!clsMethods_GL.CheckValidity_FinancialYear(dtpDODate.Value.Date))
                    return;

                if (txtDeliveryOrderID.Text == null || txtDeliveryOrderID.TextLength == 0 || txtDeliveryOrderID.Text == "<Auto Generate>")
                {
                    MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                tbl_genCustomerFinance oCus = tbl_genCustomerFinance.Select(txtCustomerID.Tag.ToString());
                if (oCus != null)
                {
                    if (oCus.CreditPeriod <= 30)
                    {
                        if (!clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                        {
                            MessageBox.Show(
                                "Access Denied ! \n\nUser does not have access to Approve records [ Credit Period - " + oCus.CreditPeriod + "], Please get permission from the system administrator", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else if (oCus.CreditPeriod <=45)
                    {
                        if (!clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, 11001))
                        {
                            MessageBox.Show(
                                "Access Denied ! \n\nUser does not have access to Approve records [ Credit Period - " + oCus.CreditPeriod + "], Please get permission from the system administrator", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else if (oCus.CreditPeriod <= 60)
                    {
                        if (!clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, 11002))
                        {
                            MessageBox.Show(
                                "Access Denied ! \n\nUser does not have access to Approve records [ Credit Period - " + oCus.CreditPeriod + "], Please get permission from the system administrator", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else if (oCus.CreditPeriod > 60)
                    {
                        if (!clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, 11003))
                        {
                            MessageBox.Show(
                                "Access Denied ! \n\nUser does not have access to Approve records [ Credit Period - " + oCus.CreditPeriod + "], Please get permission from the system administrator", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                                "Access Denied ! \n\nUser does not have access to Approve records [ Credit Period - " + oCus.CreditPeriod + "], Please get permission from the system administrator", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

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
                            tbl_sasInvoice objInv = tbl_sasInvoice.Select(txtDeliveryOrderID.Text.Trim());

                            if (objInv != null)
                            {
                                objInv.IsApproved = true;
                                objInv.DateApproved = clsSecurity.getServerDateTime();
                                objInv.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                objInv.Update();
                            }
                        }
                    }
                    else if (frmSetApproved.bReset)
                        bHasApproved = false;
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
                                        tbl_sasInvoice objInv = tbl_sasInvoice.Select(txtDeliveryOrderID.Text.Trim());
                                        if (objInv != null)
                                        {
                                            objInv.IsChecked = true;
                                            objInv.DateChecked = clsSecurity.getServerDateTime();
                                            objInv.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objInv.Update();
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



        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                Search_ItemID(sender, new KeyEventArgs(Keys.F1));

           
        }

        private void dgvDetail_KeyPress(object sender, KeyPressEventArgs e)
        {
            //var Item = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", dgvDetail.SelectedRows[0].Index, "");
            //if (Item == "Total")
            //    e.Handled = true;
        }

        private void dgvDetail_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            string sColName = "";
            if (e.ColumnIndex >= 0)
                sColName = dgvDetail.Columns[e.ColumnIndex].Name;

            if (sColName == "UnitPrice")
            {
                var Item = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", dgvDetail.SelectedCells[0].RowIndex, "");
                if (Item != "TOTAL")
                    //   e.Handled = true;
                    e.Cancel = true;
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

                dQty = dQuantity = clsFormatter.RoundDecimalPlaces_Quantity(clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00")));

                dUnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00")));

                dWet = dWeight = clsFormatter.RoundDecimalPlaces_Weight(clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00")));
                dWeightPrice = clsFormatter.RoundDecimalPlaces_WeightPrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00")));

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