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
using Digiteq.DataSets.SAS;
using Digiteq.DataSets;

namespace Digiteq
{
    public partial class frm_sasSalseReturnNote : SEACC_Form
    {
        #region Variables
        bool isTemp = false;
        //to keep glob ref no        
        public string glbOrderRefNo = "";
        public string glbSalesReturnedNoteID = "", glbDeliveryOrderID = "";

        //for security handle

        bool bHasPermissionToFreeIssures = false;
        bool bHasPermissionToLineDiscount = false;

        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;

        //Data Set
        dts_sasSalesReturn glb_dts_sasSalesReturn = new dts_sasSalesReturn();
        dts_ReportExport glb_dtsReportExport = new dts_ReportExport();

        //For Draft Print
        bool bisDraft = false;
        #endregion

        #region Form Load
        public frm_sasSalseReturnNote(FormName _enmForm)
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
            clsFill.Fill_ItemPrices(ref cmbItemPrice);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);

            //if the order genarated from a Delivery Order
            if (glbDeliveryOrderID.Length > 0)
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(glbDeliveryOrderID);
                if (detail != null)
                {
                    chkUnitPricing.Checked = !detail.IsWeightCalculation;
                    FillDetailsCustomer(detail.Customer_ID);
                    glbOrderRefNo = detail.OrderRefNo_ID;
                    txtDOID.Tag = detail.DeliveryOrder_ID;
                    btnAddDeliveryOrder_Click(sender, new EventArgs());
                }
            }
            else if (glbSalesReturnedNoteID.Length > 0)
                FillDetails(glbSalesReturnedNoteID);
        }
        #endregion

        #region Btn New
        private void frm_sasSalseReturnNote_SF_newButton_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void frm_sasSalseReturnNote_SF_cancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSRNID.Text.Trim().Length > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                            {
                                Cursor = Cursors.WaitCursor;
                                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                                if (detail != null)
                                {
                                    if (ValidateForDependancies(detail.SalesReturnedNote_ID))
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Sales Return Note : " + detail.SalesReturnedNote_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                #region Update Other Table
                                                foreach (tbl_sasSalesReturnedNote_Detail SRNdetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text.Trim()))
                                                {
                                                    if (SRNdetail.Item_ID != null)
                                                    {
                                                        decimal dWeightedAverageCostPrice = 0;
                                                        clsHelpMethods.UpdateStoreStock(iFormID, SRNdetail.SalesReturnedNote_ID, detail.SalesReturnedNoteDate, SRNdetail.Item_ID, "0", txtStoreID.Tag.ToString(), SRNdetail.Qty, SRNdetail.Weight, SRNdetail.TatalAmount, true, true, false, ref dWeightedAverageCostPrice);
                                                        SRNdetail.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(SRNdetail.Item_ID);
                                                        SRNdetail.Update();

                                                        #region Update Delivery Order
                                                        if (txtDOID.Tag != null && txtDOID.Tag.ToString().Trim().Length > 0)
                                                        {
                                                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(txtDOID.Tag.ToString());
                                                            if (oDO != null)
                                                            {
                                                                tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(SRNdetail.Line_No, SRNdetail.DeliveryOrder_ID, SRNdetail.Item_ID, SRNdetail.ItemSubCategory_ID, SRNdetail.ItemSubCategory2_ID, SRNdetail.ItemSerialNo, SRNdetail.ItemSerialNo2);
                                                                if (DoItem != null)
                                                                {
                                                                    //Update D/O
                                                                    DoItem.QtyReturned = DoItem.QtyReturned - SRNdetail.Qty;
                                                                    DoItem.WeightReturned = DoItem.WeightReturned - SRNdetail.Weight;
                                                                    DoItem.Update();

                                                                    //Update C/O
                                                                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                                                    if (CoItem != null && detail.IsReturnable)
                                                                    {
                                                                        CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder + SRNdetail.Qty;
                                                                        CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder + SRNdetail.Weight;

                                                                        CoItem.Update();
                                                                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oDO.CustomerOrder_ID, chkUnitPricing);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                }

                                                #region Update Credit Note and Settle Invoice
                                                foreach (tbl_bpsCreditNote oldCNote in tbl_bpsCreditNote.SelectAllBySalesReturnedNote_ID(txtSRNID.Text.Trim()))
                                                {
                                                    clsHelpMethods.RemoveSattlementsFrom_CreditNoteID(oldCNote.CreditNote_ID);

                                                    tbl_bpsCreditNote CRN = tbl_bpsCreditNote.Select(oldCNote.CreditNote_ID);
                                                    if (CRN != null && CRN.CreditNote_ID != "default")
                                                    {
                                                        CRN.IsDeleted = true;
                                                        CRN.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                        CRN.DateModified = clsSecurity.getServerDateTime();
                                                        CRN.Update();
                                                    }
                                                }
                                                #endregion

                                                #endregion

                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                detail.IsDeleted = true;
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.Update();

                                                clsHelpMethods.Delete_Inventory(iFormID, 0, txtSRNID.Text.Trim());

                                                clsAlerts_Email.createEmail_SalesReturn(txtSRNID.Text.Trim(), enum_Alerts.SalesReternCancel);
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
        private void frm_sasSalseReturnNote_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();
                    if (glbOrderRefNo.Length <= 0)
                        glbOrderRefNo = "default";

                    #region Update
                    if (IsUpdate)
                    {
                        tbl_sasSalesReturnedNote oldRecord = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                        if (oldRecord != null && CheckPrintingValidity(oldRecord.PrintCount))
                        {
                            if (ValidateForDependancies(oldRecord.SalesReturnedNote_ID))
                            {
                                if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                {
                                    if (!oldRecord.IsChecked ||
                                        (oldRecord.IsChecked &&
                                         clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID)))
                                    {
                                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSRNID.Text))
                                        {
                                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                                            clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned), oldRecord.SalesReturnedNote_ID, "Sales Return");

                                            #region old code

                                            //#region Rollback Store Stock
                                            //foreach (tbl_sasSalesReturnedNote_Detail oUpdatedRecord in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text.Trim()))
                                            //{
                                            //    clsHelpMethods.UpdateStoreStock(iFormID, oUpdatedRecord.SalesReturnedNote_ID, oldRecord.SalesReturnedNoteDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.TatalAmount, true, true, false);
                                            //}
                                            //#endregion

                                            ////Sales Returned Detail                                   
                                            //#region Update old Details
                                            //List<tbl_sasSalesReturnedNote_Detail> oldSRNDetails = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text.Trim());
                                            //foreach (tbl_sasSalesReturnedNote_Detail oldSRNDetail in oldSRNDetails)
                                            //{
                                            //    string sItemCode = "", sDeliveryOrderCode = "", sInvoiceCode = "", sRemarks = "",
                                            //        sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
                                            //    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dunitCost = 0, dTatalCost_FIFO = 0, dDiscountPresentage = 0, dDiscountValue = 0;
                                            //    bool bHasInvoInDB = false;
                                            //    bool bIsFreeIssue = false;

                                            //    foreach (DataGridViewRow row in dgvDetail.Rows)
                                            //    {
                                            //        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                            //        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                            //        sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                                            //        sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                            //        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                            //        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                            //        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                            //        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                                            //        bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                            //        dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                            //        dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                                            //        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                            //        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                            //        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                            //        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                            //        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                            //        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                            //        dunitCost = clsValidate.ValidateGridValue(dgvDetail, "unitCost", row.Index, decimal.Parse("0.00"));
                                            //        dTatalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "TatalCost_FIFO", row.Index, decimal.Parse("0.00"));


                                            //        if (oldSRNDetail.Line_No.ToString() == sLineNo && oldSRNDetail.SalesReturnedNote_ID == txtSRNID.Text.Trim() && oldSRNDetail.Item_ID == sItemCode && oldSRNDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                            //                oldSRNDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldSRNDetail.ItemSerialNo == sItemSerialNo && oldSRNDetail.ItemSerialNo2 == sItemSerialNo2 && oldSRNDetail.DeliveryOrder_ID == sDeliveryOrderCode)
                                            //        {
                                            //            bHasInvoInDB = true;
                                            //            dgvDetail.Rows.RemoveAt(row.Index);
                                            //            break; //database contain this item
                                            //        }
                                            //    }

                                            //    if (bHasInvoInDB)
                                            //    {
                                            //        //Get Unit Price with Exchange rate to save
                                            //        dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                            //        dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                                            //        dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                                            //        //////Update Other Tables
                                            //        #region Update Delivery Order
                                            //        bool bDeliveryOrderOK = (clsConfig.bSRN_StockUpdate_NeedChecking) ? oldRecord.IsChecked : true;
                                            //        if (bDeliveryOrderOK)
                                            //        {
                                            //            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrderCode);
                                            //            if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                            //            {
                                            //                tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                            //                if (DoItem != null)
                                            //                {
                                            //                    //Update D/O                                                                    
                                            //                    DoItem.QtyReturned = (DoItem.QtyReturned - oldSRNDetail.Qty) + dQuantity;
                                            //                    DoItem.WeightReturned = (DoItem.WeightReturned - oldSRNDetail.Weight) + dWeight;
                                            //                    DoItem.Update();
                                            //                    clsProcessMethods.SetSettle_DeliveryOrder(oDO.DeliveryOrder_ID, chkUnitPricing, true);

                                            //                    //Update C/O
                                            //                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                            //                    if (CoItem != null && rdoReturnable.Checked)
                                            //                    {
                                            //                        CoItem.QtySettle_DeliveryOrder = (CoItem.QtySettle_DeliveryOrder + oldSRNDetail.Qty) - dQuantity;
                                            //                        CoItem.WeightSettle_DeliveryOrder = (CoItem.WeightSettle_DeliveryOrder + oldSRNDetail.Weight) - dWeight;
                                            //                        CoItem.Update();
                                            //                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oDO.CustomerOrder_ID, chkUnitPricing);
                                            //                    }
                                            //                }
                                            //            }


                                            //        }
                                            //        #endregion

                                            //        #region old SRN Detail
                                            //        oldSRNDetail.Line_No = int.Parse(sLineNo);
                                            //        oldSRNDetail.Item_ID = sItemCode;
                                            //        oldSRNDetail.ItemSubCategory_ID = sItemSubCategoryID;
                                            //        oldSRNDetail.ItemSubCategory2_ID = sItemSubCategoryID2;
                                            //        oldSRNDetail.ItemSerialNo = sItemSerialNo;
                                            //        oldSRNDetail.ItemSerialNo2 = sItemSerialNo2;
                                            //        oldSRNDetail.Invoice_ID = sInvoiceCode;
                                            //        oldSRNDetail.DeliveryOrder_ID = sDeliveryOrderCode;
                                            //        oldSRNDetail.Qty = dQuantity;
                                            //        oldSRNDetail.Weight = dWeight;
                                            //        oldSRNDetail.UnitPrice = dUnitPrice;
                                            //        oldSRNDetail.KiloPrice = dWeightPrice;
                                            //        oldSRNDetail.BIsFreeItem = bIsFreeIssue;
                                            //        oldSRNDetail.DiscountPresentage = dDiscountPresentage;
                                            //        oldSRNDetail.DiscountAmount = dDiscountValue;
                                            //        oldSRNDetail.TatalAmount = dAmount;
                                            //        oldSRNDetail.Remark = sRemarks;

                                            //        oldSRNDetail.Update();
                                            //        #endregion


                                            //    }
                                            //    else
                                            //    {

                                            //        bool bUpdateOk = (clsConfig.bSRN_StockUpdate_NeedChecking) ? bHasChecked : true;

                                            //        oldSRNDetail.Delete();
                                            //    }
                                            //}
                                            //#endregion

                                            //#region Newlly Added Items insert
                                            //foreach (DataGridViewRow row in dgvDetail.Rows)
                                            //{
                                            //    string sItemCode = "", sUom = "default", sDeliveryOrderCode = "", sInvoiceCode = "", sJobCode = "",
                                            //         sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "", sLineNo = "";
                                            //    decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dunitCost = 0, dDiscountPresentage = 0, dDiscountValue = 0, dTatalCost_FIFO = 0;
                                            //    bool bIsFreeIssue = false;

                                            //    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                            //    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                            //    sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                                            //    sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                            //    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                            //    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                            //    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                            //    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                            //    sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index, "default");
                                            //    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                                            //    bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                            //    dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                            //    dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                                            //    dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                            //    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                            //    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                            //    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                            //    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                            //    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                            //    dunitCost = clsValidate.ValidateGridValue(dgvDetail, "unitCost", row.Index, decimal.Parse("0.00"));
                                            //    dTatalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "TatalCost_FIFO", row.Index, decimal.Parse("0.00"));

                                            //    //Get Unit Price with Exchange rate to save
                                            //    dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                            //    dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                                            //    dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                                            //    if (sItemCode.Length > 0)
                                            //    {

                                            //        tbl_sasSalesReturnedNote_Detail items = new tbl_sasSalesReturnedNote_Detail(int.Parse(sLineNo), txtSRNID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                            //            sInvoiceCode, sDeliveryOrderCode, dQuantity, dWeight, 0, dWeightPrice, dUnitPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, dunitCost, dTatalCost_FIFO, sRemarks);
                                            //        items.Insert();

                                            //        //////Update Other Tables
                                            //        #region Update Other Tables
                                            //        bool bDeliveryOrderOK = (clsConfig.bSRN_StockUpdate_NeedChecking) ? oldRecord.IsChecked : true;
                                            //        if (bDeliveryOrderOK)
                                            //        {
                                            //            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrderCode);
                                            //            if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                            //            {
                                            //                //Update D/O
                                            //                tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                            //                if (DoItem != null && DoItem.Item_ID != "default")
                                            //                {
                                            //                    DoItem.QtyReturned = DoItem.QtyReturned + dQuantity;
                                            //                    DoItem.WeightReturned = DoItem.WeightReturned + dWeight;
                                            //                    DoItem.Update();
                                            //                }

                                            //                //Update C/O
                                            //                tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                            //                if (CoItem != null && rdoReturnable.Checked)
                                            //                {
                                            //                    CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder - dQuantity;
                                            //                    CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder - dWeight;
                                            //                    CoItem.Update();
                                            //                    clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oDO.CustomerOrder_ID, chkUnitPricing);
                                            //                }
                                            //            }
                                            //        }
                                            //        #endregion
                                            //    }
                                            //}
                                            //#endregion

                                            ////UPDATE SRN Header
                                            //#region Update SRN Header
                                            //tbl_sasSalesReturnedNote detail = new tbl_sasSalesReturnedNote(txtSRNID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                            //    txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), txtDOID.Tag.ToString(), glbOrderRefNo, oldRecord.CreditNote_ID, txtStoreID.Tag.ToString(),
                                            //    oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID, txtCurrencyID.Tag.ToString(), txtSalesNoteType.Tag.ToString(),
                                            //    decimal.Parse(txtCurrencyRate.Text.Trim()), 0, decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                            //    decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate),
                                            //    clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                            //    clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                            //    oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled,
                                            //    oldRecord.PrintCount, !chkUnitPricing.Checked, oldRecord.IsTaxReverseCalulation, oldRecord.IsReturnable, oldRecord.IsRefundable, oldRecord.IsExcess, txtCustomerBranchID.Tag.ToString(), chkEnteranceError.Checked, oldRecord.CompanyID, oldRecord.CompanyBranch_ID, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, int.Parse(lblRoute.Tag.ToString()));
                                            //detail.Update();
                                            //#endregion

                                            //#region Update Store Stock
                                            //foreach (tbl_sasSalesReturnedNote_Detail oUpdatedRecord in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text.Trim()))
                                            //{
                                            //    clsHelpMethods.UpdateStoreStock(iFormID, detail.SalesReturnedNote_ID, detail.SalesReturnedNoteDate, oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(), oUpdatedRecord.Qty, oUpdatedRecord.Weight, oUpdatedRecord.TatalAmount, false, true, false);
                                            //}
                                            //#endregion

                                            ////Credit Note Creatation
                                            //#region Credit Note Creatation
                                            //if (clsConfig.bSRN_AutoCreditNoteCreateEnable && rdoRefundable.Checked)
                                            //{
                                            //    bool bCreditNoteOk = (clsConfig.bSRN_AutoCreditNoteCreateEnable_NeedApproval) ? detail.IsApproved : true;
                                            //    if (bCreditNoteOk)
                                            //    {
                                            //        string sCRN_ID = detail.CreditNote_ID;
                                            //        if (detail.CreditNote_ID == "default")
                                            //        {
                                            //            if (clsAutocode.IsAutoGenerated(clsAutocode.getFormConfigCode(FormName.bssCreditNote)))
                                            //                sCRN_ID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.bssCreditNote));
                                            //        }

                                            //        //Credit Note Header
                                            //        tbl_bpsCreditNote oldCreditNote = tbl_bpsCreditNote.Select(sCRN_ID);
                                            //        if (oldCreditNote == null)
                                            //        {
                                            //            tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID, detail.SalesReturnedNoteDate, detail.Remark, detail.SalesReturnedNote_ID,
                                            //            "default", detail.Customer_ID, "default", detail.OrderRefNo_ID, "default", clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal),
                                            //            "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, clsConfig.sLocalCurrencyCode, txtSalesNoteType.Tag.ToString(), 1,
                                            //            detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.SubTotal, detail.DiscountTotal,
                                            //            detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                            //            clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                            //            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, !chkUnitPricing.Checked, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, false);
                                            //            cNote.Insert();
                                            //        }
                                            //        else
                                            //        {
                                            //            tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldCreditNote.GlPosting_ID);

                                            //            tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID, detail.SalesReturnedNoteDate, detail.Remark, detail.SalesReturnedNote_ID,
                                            //            "default", detail.Customer_ID, "default", detail.OrderRefNo_ID, "default", clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal),
                                            //            oldCreditNote.GlPosting_ID, oldCreditNote.PostingStatus_ID, oldCreditNote.FinancialYear_ID, oldCreditNote.Currency_ID, txtSalesNoteType.Tag.ToString(), oldCreditNote.CurrencyRate,
                                            //            detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.SubTotal, detail.DiscountTotal,
                                            //            detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, oldCreditNote.CreateUser_ID, clsSecurity.UserIDLoged, oldCreditNote.CheckedUser_ID, oldCreditNote.ApprovedUser_ID,
                                            //            oldCreditNote.CreateTerminal_ID, oldCreditNote.ModifiedTerminal_ID, oldCreditNote.DeletedTerminal_ID, oldCreditNote.PrintedTerminal_ID,
                                            //            oldCreditNote.DateCreate, clsSecurity.getServerDateTime(), oldCreditNote.DateChecked, oldCreditNote.DateApproved, oldCreditNote.IsChecked,
                                            //            oldCreditNote.IsApproved, oldCreditNote.IsFinished, oldCreditNote.IsDeleted, oldCreditNote.IsLocked, !chkUnitPricing.Checked, oldCreditNote.SeattleAmount, oldCreditNote.IsSeattled, oldCreditNote.PrintCount, oldCreditNote.CompanyID, oldCreditNote.CompanyBranch_ID, oldCreditNote.Is_WriteOff);
                                            //            cNote.Update();
                                            //        }

                                            //        //Credit Note Details
                                            //        tbl_bpsCreditNote_Detail.DeleteAllByCreditNote_ID(sCRN_ID);

                                            //        foreach (tbl_sasSalesReturnedNote_Detail objSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(detail.SalesReturnedNote_ID))
                                            //        {
                                            //            tbl_bpsCreditNote_Detail items = new tbl_bpsCreditNote_Detail(objSRNDetail.Line_No, sCRN_ID, objSRNDetail.Item_ID, objSRNDetail.ItemSubCategory_ID,
                                            //                objSRNDetail.ItemSubCategory2_ID, objSRNDetail.ItemSerialNo, objSRNDetail.ItemSerialNo2, objSRNDetail.Qty, objSRNDetail.Weight, objSRNDetail.UnitPrice,
                                            //                objSRNDetail.KiloPrice, objSRNDetail.DiscountAmount, (objSRNDetail.DiscountAmount * objSRNDetail.Qty), objSRNDetail.TatalAmount, objSRNDetail.Remark);
                                            //            items.Insert();
                                            //        }

                                            //        oldRecord.CreditNote_ID = sCRN_ID;
                                            //        oldRecord.Update();
                                            //        //   }
                                            //    }
                                            //}
                                            //#endregion 

                                            #endregion

                                            #region Rollback Store Stock

                                            foreach (tbl_sasSalesReturnedNote_Detail oUpdatedRecord in
                                                tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(
                                                    txtSRNID.Text.Trim()))
                                            {
                                                decimal dWeightedAverageCostPrice = 0;
                                                clsHelpMethods.UpdateStoreStock(iFormID,
                                                    oUpdatedRecord.SalesReturnedNote_ID,
                                                    oldRecord.SalesReturnedNoteDate, oUpdatedRecord.Item_ID, "0",
                                                    txtStoreID.Tag.ToString(), oUpdatedRecord.Qty,
                                                    oUpdatedRecord.Weight, oUpdatedRecord.TatalAmount, true, true,
                                                    false, ref dWeightedAverageCostPrice);

                                                oUpdatedRecord.WeightedAvgCost = clsProcessMethods.GetItemWeightedAvarageCostPrice(oUpdatedRecord.Item_ID);
                                                oUpdatedRecord.Update();
                                            }

                                            #endregion

                                            #region Reverce Old SRN details

                                            List<tbl_sasSalesReturnedNote_Detail> oldSRNDetails =
                                                tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(
                                                    txtSRNID.Text.Trim());
                                            foreach (tbl_sasSalesReturnedNote_Detail oldSRNDetail in oldSRNDetails)
                                            {
                                                bool bDeliveryOrderOK = (clsConfig.bSRN_StockUpdate_NeedChecking)
                                                    ? oldRecord.IsChecked
                                                    : true;
                                                if (bDeliveryOrderOK)
                                                {
                                                    tbl_sasDeliveryOrder oDO =
                                                        tbl_sasDeliveryOrder.Select(oldSRNDetail.DeliveryOrder_ID);
                                                    if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                                    {
                                                        tbl_sasDeliveryOrder_Detail DoItem =
                                                            tbl_sasDeliveryOrder_Detail.Select(oldSRNDetail.Line_No,
                                                                oldSRNDetail.DeliveryOrder_ID, oldSRNDetail.Item_ID,
                                                                oldSRNDetail.ItemSubCategory_ID,
                                                                oldSRNDetail.ItemSubCategory2_ID,
                                                                oldSRNDetail.ItemSerialNo, oldSRNDetail.ItemSerialNo2);
                                                        if (DoItem != null)
                                                        {
                                                            #region Update DO      

                                                            DoItem.QtyReturned = DoItem.QtyReturned - oldSRNDetail.Qty;
                                                            DoItem.WeightReturned =
                                                                DoItem.WeightReturned - oldSRNDetail.Weight;
                                                            DoItem.Update();
                                                            clsProcessMethods.SetSettle_DeliveryOrder(
                                                                oDO.DeliveryOrder_ID, chkUnitPricing, true);

                                                            #endregion

                                                            #region Update CO

                                                            tbl_sasCustomerOrder_Detail CoItem =
                                                                tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No,
                                                                    oDO.CustomerOrder_ID, DoItem.Item_ID,
                                                                    DoItem.ItemSubCategory_ID,
                                                                    DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo,
                                                                    DoItem.ItemSerialNo2);
                                                            if (CoItem != null && rdoReturnable.Checked)
                                                            {
                                                                CoItem.QtySettle_DeliveryOrder =
                                                                    CoItem.QtySettle_DeliveryOrder + oldSRNDetail.Qty;
                                                                CoItem.WeightSettle_DeliveryOrder =
                                                                    CoItem.WeightSettle_DeliveryOrder +
                                                                    oldSRNDetail.Weight;
                                                                CoItem.Update();
                                                                clsProcessMethods
                                                                    .SetSettle_CustomerOrderFrom_DeliveryOrder(
                                                                        oDO.CustomerOrder_ID, chkUnitPricing);
                                                            }

                                                            #endregion
                                                        }
                                                    }
                                                }

                                                oldSRNDetail.Delete();
                                            }

                                            #endregion

                                            #region Insert Salese Return Detail AND Update other tables

                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                            {
                                                try
                                                {
                                                    #region Get grid values

                                                    string sItemCode = "",
                                                        sUom = "default",
                                                        sDeliveryOrderCode = "",
                                                        sInvoiceCode = "",
                                                        sJobCode = "",
                                                        sRemarks = "",
                                                        sItemSubCategoryID = "",
                                                        sItemSubCategoryID2 = "",
                                                        sItemSerialNo = "",
                                                        sItemSerialNo2 = "",
                                                        sLineNo = "";
                                                    decimal dWeightPrice = 0,
                                                        dUnitPrice = 0,
                                                        dQuantity = 0,
                                                        dWeight = 0,
                                                        dAmount = 0,
                                                        dunitCost = 0,
                                                        dTatalCost_FIFO = 0,
                                                        dDiscountPresentage = 0,
                                                        dDiscountValue = 0;
                                                    bool bIsFreeIssue = false;

                                                    sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo",
                                                        row.Index, "0");
                                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode",
                                                        row.Index, "");
                                                    sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "DeliveryOrderCode", row.Index, "default");
                                                    sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail,
                                                        "InvoiceCode", row.Index, "default");
                                                    sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode",
                                                        row.Index, "default");
                                                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail,
                                                        "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight",
                                                        row.Index, decimal.Parse("0.00"));
                                                    sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index,
                                                        "default");
                                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice",
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
                                                    dunitCost = clsValidate.ValidateGridValue(dgvDetail, "unitCost",
                                                        row.Index, decimal.Parse("0.00"));
                                                    dTatalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail,
                                                        "TatalCost_FIFO", row.Index, decimal.Parse("0.00"));

                                                    //Get Unit Price with Exchange rate to save
                                                    dUnitPrice =
                                                        clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                    dWeightPrice =
                                                        clsHelpMethods.getSavePrice(dWeightPrice,
                                                            txtCurrencyRate);
                                                    dAmount = clsHelpMethods.getSavePrice(dAmount,
                                                        txtCurrencyRate);

                                                    #endregion

                                                    if (sItemCode.Length > 0)
                                                    {
                                                        #region Insert SRN Detail

                                                        tbl_sasSalesReturnedNote_Detail items =
                                                            new tbl_sasSalesReturnedNote_Detail(int.Parse(sLineNo),
                                                                txtSRNID.Text.Trim(), sItemCode, sItemSubCategoryID,
                                                                sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                                                sInvoiceCode, sDeliveryOrderCode, dQuantity, dWeight, 0,
                                                                dWeightPrice, dUnitPrice, bIsFreeIssue,
                                                                dDiscountPresentage, dDiscountValue, dAmount, dunitCost,
                                                                dTatalCost_FIFO, sRemarks, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                                        items.Insert();

                                                        #endregion

                                                        bool bDeliveryOrderOK =
                                                            (clsConfig.bSRN_StockUpdate_NeedChecking)
                                                                ? oldRecord.IsChecked
                                                                : true;
                                                        if (bDeliveryOrderOK)
                                                        {
                                                            tbl_sasDeliveryOrder oDO =
                                                                tbl_sasDeliveryOrder.Select(sDeliveryOrderCode);
                                                            if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                                            {
                                                                tbl_sasDeliveryOrder_Detail DoItem =
                                                                    tbl_sasDeliveryOrder_Detail.Select(
                                                                        int.Parse(sLineNo), sDeliveryOrderCode,
                                                                        sItemCode, sItemSubCategoryID,
                                                                        sItemSubCategoryID2, sItemSerialNo,
                                                                        sItemSerialNo2);
                                                                if (DoItem != null && DoItem.Item_ID != "default")
                                                                {

                                                                    #region Update DO

                                                                    DoItem.QtyReturned = DoItem.QtyReturned + dQuantity;
                                                                    DoItem.WeightReturned =
                                                                        DoItem.WeightReturned + dWeight;
                                                                    DoItem.Update();
                                                                    bool bHasInvoice =
                                                                        txtInvoiceID.Text.Trim().Length > 0
                                                                            ? true
                                                                            : false;
                                                                    clsProcessMethods.SetSettle_DeliveryOrder(
                                                                        oDO.DeliveryOrder_ID, chkUnitPricing,
                                                                        bHasInvoice);

                                                                    #endregion

                                                                    #region Update CO

                                                                    tbl_sasCustomerOrder_Detail CoItem =
                                                                        tbl_sasCustomerOrder_Detail.Select(
                                                                            DoItem.Line_No, oDO.CustomerOrder_ID,
                                                                            DoItem.Item_ID, DoItem.ItemSubCategory_ID,
                                                                            DoItem.ItemSubCategory2_ID,
                                                                            DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                                                    if (CoItem != null && rdoReturnable.Checked)
                                                                    {
                                                                        CoItem.QtySettle_DeliveryOrder =
                                                                            CoItem.QtySettle_DeliveryOrder - dQuantity;
                                                                        CoItem.WeightSettle_DeliveryOrder =
                                                                            CoItem.WeightSettle_DeliveryOrder - dWeight;
                                                                        CoItem.Update();
                                                                        clsProcessMethods
                                                                            .SetSettle_CustomerOrderFrom_DeliveryOrder(
                                                                                oDO.CustomerOrder_ID, chkUnitPricing);
                                                                    }

                                                                    #endregion
                                                                }
                                                            }
                                                        }

                                                        #region Pass Value to Inventory Detail
                                                        tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtSRNID.Text.Trim(), dtpSRNDate.Value,
                                                                                    "", "", "", "", txtCustomerID.Tag.ToString(), "default", txtStoreID.Tag.ToString(),
                                                                                    sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0, dUnitPrice, 0, false);
                                                        oListInventory.Add(oInventoryDetail);
                                                        #endregion
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    clsValidate.WriteErrorLog("", iFormID, ex);
                                                    SEACCException.Show(ex);
                                                }
                                            }

                                            #endregion

                                            #region Update SRN Header

                                            tbl_sasSalesReturnedNote detail = new tbl_sasSalesReturnedNote(
                                                txtSRNID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                                txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(),
                                                txtDOID.Tag.ToString(), glbOrderRefNo, oldRecord.CreditNote_ID,
                                                txtStoreID.Tag.ToString(),
                                                oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID,
                                                oldRecord.FinancialYear_ID, txtCurrencyID.Tag.ToString(),
                                                txtSalesNoteType.Tag.ToString(),
                                                decimal.Parse(txtCurrencyRate.Text.Trim()), 0,
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
                                                oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID,
                                                oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                                                oldRecord.CreateTerminal_ID, clsSecurity.TerminalID,
                                                oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate,
                                                glbApprovedDate, clsSecurity.getServerDateTime(),
                                                clsSecurity.getServerDateTime(), oldRecord.IsChecked,
                                                oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                                oldRecord.IsLocked, oldRecord.SeattleAmount, oldRecord.IsSeattled,
                                                oldRecord.PrintCount, !chkUnitPricing.Checked,
                                                oldRecord.IsTaxReverseCalulation, oldRecord.IsReturnable,
                                                oldRecord.IsRefundable, oldRecord.IsExcess,
                                                txtCustomerBranchID.Tag.ToString(), chkEnteranceError.Checked,
                                                oldRecord.CompanyID, oldRecord.CompanyBranch_ID,
                                                ((ComboBoxItem) cmbItemPrice.SelectedItem).Value,
                                                int.Parse(lblRoute.Tag.ToString()));
                                            detail.Update();

                                            #endregion

                                            #region Update Store Stock

                                            foreach (tbl_sasSalesReturnedNote_Detail oUpdatedRecord in
                                                tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(
                                                    txtSRNID.Text.Trim()))
                                            {
                                                decimal dWeightedAverageCostPrice = 0;
                                                clsHelpMethods.UpdateStoreStock(iFormID,
                                                    detail.SalesReturnedNote_ID, detail.SalesReturnedNoteDate,
                                                    oUpdatedRecord.Item_ID, "0", txtStoreID.Tag.ToString(),
                                                    oUpdatedRecord.Qty, oUpdatedRecord.Weight,
                                                    oUpdatedRecord.TatalAmount, false, true, false, ref dWeightedAverageCostPrice);
                                            }

                                            #endregion

                                            #region Credit Note Creatation

                                            if (clsConfig.bSRN_AutoCreditNoteCreateEnable && rdoRefundable.Checked)
                                            {
                                                bool bCreditNoteOk =
                                                    (clsConfig.bSRN_AutoCreditNoteCreateEnable_NeedApproval)
                                                        ? detail.IsApproved
                                                        : true;
                                                if (bCreditNoteOk)
                                                {
                                                    string sCRN_ID = detail.CreditNote_ID;
                                                    if (detail.CreditNote_ID == "default")
                                                    {
                                                        if (clsAutocode.IsAutoGenerated(
                                                            clsAutocode.getFormConfigCode(FormName.bssCreditNote)))
                                                            sCRN_ID = clsAutocode.getAutoGeneratedCode(
                                                                clsAutocode.getFormConfigCode(FormName.bssCreditNote));
                                                    }

                                                    //Credit Note Header
                                                    tbl_bpsCreditNote oldCreditNote = tbl_bpsCreditNote.Select(sCRN_ID);
                                                    if (oldCreditNote == null)
                                                    {
                                                        tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID,
                                                            detail.SalesReturnedNoteDate, detail.Remark,
                                                            detail.SalesReturnedNote_ID,
                                                            "default", detail.Customer_ID, "default",
                                                            detail.OrderRefNo_ID, "default",
                                                            clsAutocode.getCreditNoteTypeID(CreditNoteType
                                                                .SalesReturnsLocal),
                                                            "default",
                                                            clsAutocode.getGLPostingStatusID(GLPostingStatus
                                                                .NewTransaction), clsSecurity.FinancialYearID,
                                                            clsConfig.sLocalCurrencyCode,
                                                            txtSalesNoteType.Tag.ToString(), 1,
                                                            detail.DiscountPercentage, detail.NbtPercentage,
                                                            detail.VatPercentage, detail.OtherTaxPercentage,
                                                            detail.SubTotal, detail.DiscountTotal,
                                                            detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal,
                                                            detail.GrandTotal, clsSecurity.UserIDLoged,
                                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                                            clsSecurity.UserIDLoged,
                                                            clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                            clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                            clsSecurity.getServerDateTime(),
                                                            clsSecurity.getServerDateTime(), glbCheckedDate,
                                                            glbApprovedDate, false, false, false, false, false,
                                                            !chkUnitPricing.Checked, 0, false, 0, clsSecurity.CompanyID,
                                                            clsSecurity.BranchID, false, (-1), (-1));
                                                        cNote.Insert();
                                                    }
                                                    else
                                                    {
                                                        tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oldCreditNote
                                                            .GlPosting_ID);

                                                        tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID,
                                                            detail.SalesReturnedNoteDate, detail.Remark,
                                                            detail.SalesReturnedNote_ID,
                                                            "default", detail.Customer_ID, "default",
                                                            detail.OrderRefNo_ID, "default",
                                                            clsAutocode.getCreditNoteTypeID(CreditNoteType
                                                                .SalesReturnsLocal),
                                                            oldCreditNote.GlPosting_ID, oldCreditNote.PostingStatus_ID,
                                                            oldCreditNote.FinancialYear_ID, oldCreditNote.Currency_ID,
                                                            txtSalesNoteType.Tag.ToString(), oldCreditNote.CurrencyRate,
                                                            detail.DiscountPercentage, detail.NbtPercentage,
                                                            detail.VatPercentage, detail.OtherTaxPercentage,
                                                            detail.SubTotal, detail.DiscountTotal,
                                                            detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal,
                                                            detail.GrandTotal, oldCreditNote.CreateUser_ID,
                                                            clsSecurity.UserIDLoged, oldCreditNote.CheckedUser_ID,
                                                            oldCreditNote.ApprovedUser_ID,
                                                            oldCreditNote.CreateTerminal_ID,
                                                            oldCreditNote.ModifiedTerminal_ID,
                                                            oldCreditNote.DeletedTerminal_ID,
                                                            oldCreditNote.PrintedTerminal_ID,
                                                            oldCreditNote.DateCreate, clsSecurity.getServerDateTime(),
                                                            oldCreditNote.DateChecked, oldCreditNote.DateApproved,
                                                            oldCreditNote.IsChecked,
                                                            oldCreditNote.IsApproved, oldCreditNote.IsFinished,
                                                            oldCreditNote.IsDeleted, oldCreditNote.IsLocked,
                                                            !chkUnitPricing.Checked, oldCreditNote.SeattleAmount,
                                                            oldCreditNote.IsSeattled, oldCreditNote.PrintCount,
                                                            oldCreditNote.CompanyID, oldCreditNote.CompanyBranch_ID,
                                                            oldCreditNote.Is_WriteOff,
                                                            oldCreditNote.PosReturnTransaction_Index,
                                                            oldCreditNote.AdvanceReceived_Index);
                                                        cNote.Update();
                                                    }

                                                    //Credit Note Details
                                                    tbl_bpsCreditNote_Detail.DeleteAllByCreditNote_ID(sCRN_ID);

                                                    foreach (tbl_sasSalesReturnedNote_Detail objSRNDetail in
                                                        tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(
                                                            detail.SalesReturnedNote_ID))
                                                    {
                                                        tbl_bpsCreditNote_Detail items = new tbl_bpsCreditNote_Detail(
                                                            objSRNDetail.Line_No, sCRN_ID, objSRNDetail.Item_ID,
                                                            objSRNDetail.ItemSubCategory_ID,
                                                            objSRNDetail.ItemSubCategory2_ID, objSRNDetail.ItemSerialNo,
                                                            objSRNDetail.ItemSerialNo2, objSRNDetail.Qty,
                                                            objSRNDetail.Weight, objSRNDetail.UnitPrice,
                                                            objSRNDetail.KiloPrice, objSRNDetail.DiscountAmount,
                                                            (objSRNDetail.DiscountAmount * objSRNDetail.Qty),
                                                            objSRNDetail.TatalAmount, objSRNDetail.Remark);
                                                        items.Insert();
                                                    }

                                                    oldRecord.CreditNote_ID = sCRN_ID;
                                                    oldRecord.Update();
                                                    //   }
                                                }
                                            }

                                            #endregion

                                            #region Update Inventory
                                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSRNID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                                txtCustomerID.Tag.ToString(), "default", txtSalesNoteType.Tag.ToString(), int.Parse(lblRoute.Tag.ToString()), decimal.Parse(txtGrandTotal.Text.Trim()),
                                                "", "", "", "", false, clsSecurity.UserIDLoged);

                                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                                            #endregion

                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone),
                                                clsFormatter.GetMessageCaption(), MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
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
                    #endregion

                    #region Insert
                    else
                    {
                        clsAutocode.getAutoGeneratedCode_Advanced(sFormConfigCode, txtSalesNoteType.Tag.ToString(), ref txtSRNID);

                        string sCRN_ID = "default";

                        #region OrderRefNo
                        if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                        {
                            glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                            tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text != "" ? txtOrderRefNo.Text.Trim() : "-", "default", "default", txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                            orf.Insert();
                        }
                        #endregion

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtSRNID.Text)) //if (txtSRNID.TextLength > 0)
                        {
                            List<tbl_scsInventoryTxnDetail> oListInventory = new List<tbl_scsInventoryTxnDetail>();

                            #region Sales Return Header
                            tbl_sasSalesReturnedNote detail = new tbl_sasSalesReturnedNote(txtSRNID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                txtInvoiceID.Tag.ToString(), txtCustomerID.Tag.ToString(), txtDOID.Tag.ToString(), glbOrderRefNo, "default", txtStoreID.Tag.ToString(),
                                "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, txtCurrencyID.Tag.ToString(), txtSalesNoteType.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), 0, decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate),
                                clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, "default", "default", clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false, false, false, 0, false,
                                0, !chkUnitPricing.Checked, chkReverseCalculation.Checked, rdoReturnable.Checked, rdoRefundable.Checked, rdoExcess.Checked, txtCustomerBranchID.Tag.ToString(), chkEnteranceError.Checked, clsSecurity.CompanyID, clsSecurity.BranchID, ((ComboBoxItem)cmbItemPrice.SelectedItem).Value, int.Parse(lblRoute.Tag.ToString()));
                            detail.Insert();
                            #endregion

                            #region Credit Note Creatation
                            if (clsConfig.bSRN_AutoCreditNoteCreateEnable && rdoRefundable.Checked)
                            {
                                bool bCreditNoteOk = (clsConfig.bSRN_AutoCreditNoteCreateEnable_NeedApproval) ? detail.IsApproved : true;
                                if (bCreditNoteOk)
                                {
                                    if (clsAutocode.IsAutoGenerated(clsAutocode.getFormConfigCode(FormName.bssCreditNote)))
                                        sCRN_ID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.bssCreditNote));

                                    #region Credit note header
                                    tbl_bpsCreditNote cNote = new tbl_bpsCreditNote(sCRN_ID, detail.SalesReturnedNoteDate, detail.Remark, detail.SalesReturnedNote_ID,
                                    detail.Invoice_ID, detail.Customer_ID, detail.DeliveryOrder_ID, detail.OrderRefNo_ID, "default", clsAutocode.getCreditNoteTypeID(CreditNoteType.SalesReturnsLocal),
                                    "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, detail.Currency_ID, txtSalesNoteType.Tag.ToString(), detail.CurrencyRate,
                                    detail.DiscountPercentage, detail.NbtPercentage, detail.VatPercentage, detail.OtherTaxPercentage, detail.SubTotal, detail.DiscountTotal,
                                    detail.NbtTotal, detail.VatTotal, detail.OtherTaxTotal, detail.GrandTotal, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                    clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, false, false, false, false, false, !chkUnitPricing.Checked, 0, false, 0, clsSecurity.CompanyID, clsSecurity.BranchID, false, (-1), (-1));
                                    cNote.Insert();

                                    #endregion

                                    #region Update SRN
                                    tbl_sasSalesReturnedNote oldSRN = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                                    if (oldSRN != null)
                                    {
                                        oldSRN.CreditNote_ID = sCRN_ID;
                                        oldSRN.Update();
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                            #region Salese Return Detail and CreditNote Detail
                            if (true)
                            {
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    try
                                    {
                                        string sItemCode = "", sUom = "default", sDeliveryOrderCode = "", sInvoiceCode = "", sJobCode = "", sRemarks = "",
                                             sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
                                        decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dunitCost = 0, dTatalCost_FIFO = 0, dDiscountPresentage = 0, dDiscountValue = 0;
                                        bool bIsFreeIssue = false;

                                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                        sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                                        sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                        sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                        sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index, "default");
                                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));

                                        bIsFreeIssue = clsValidate.ValidateGridValue(dgvDetail, "Free", row.Index, "") == "True" ? true : false;
                                        dDiscountPresentage = clsValidate.ValidateGridTag(dgvDetail, "DiscuntPresentage", row.Index, decimal.Parse("0.00"));
                                        dDiscountValue = clsValidate.ValidateGridTag(dgvDetail, "DiscountValue", row.Index, decimal.Parse("0.00"));

                                        dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                        sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                        dunitCost = clsValidate.ValidateGridValue(dgvDetail, "unitCost", row.Index, decimal.Parse("0.00"));
                                        dTatalCost_FIFO = clsValidate.ValidateGridValue(dgvDetail, "TatalCost_FIFO", row.Index, decimal.Parse("0.00"));

                                        //Get Unit Price with Exchange rate to save
                                        dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                                        dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                                        dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                                        if (sItemCode.Length > 0)
                                        {
                                            //Insert SRN Detail
                                            tbl_sasSalesReturnedNote_Detail items = new tbl_sasSalesReturnedNote_Detail(int.Parse(sLineNo), txtSRNID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                                sInvoiceCode, sDeliveryOrderCode, dQuantity, dWeight, 0, dWeightPrice, dUnitPrice, bIsFreeIssue, dDiscountPresentage, dDiscountValue, dAmount, dunitCost, dTatalCost_FIFO, sRemarks, clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode));
                                            items.Insert();

                                            //////Update Other Tables
                                            #region Update DeliveryOrder / CustomerOrder
                                            bool bDeliveryOrderOK = (clsConfig.bSRN_StockUpdate_NeedChecking) ? detail.IsChecked : true;
                                            if (bDeliveryOrderOK)
                                            {
                                                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrderCode);
                                                if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                                {
                                                    tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDeliveryOrderCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                                                    if (DoItem != null && DoItem.Item_ID != "default")
                                                    {
                                                        //Update D/O
                                                        DoItem.QtyReturned = DoItem.QtyReturned + dQuantity;
                                                        DoItem.WeightReturned = DoItem.WeightReturned + dWeight;
                                                        DoItem.Update();
                                                        bool bHasInvoice = txtInvoiceID.Text.Trim().Length > 0 ? true : false;
                                                        clsProcessMethods.SetSettle_DeliveryOrder(oDO.DeliveryOrder_ID, chkUnitPricing, bHasInvoice);

                                                        //Update C/O
                                                        tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                                        //tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(iLineNo, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                                        if (CoItem != null && rdoReturnable.Checked)
                                                        {
                                                            CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder - dQuantity;
                                                            CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder - dWeight;
                                                            CoItem.Update();
                                                            clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oDO.CustomerOrder_ID, chkUnitPricing);
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion

                                            #region Insert CreditNote Detail
                                            if (clsConfig.bSRN_AutoCreditNoteCreateEnable && rdoRefundable.Checked)
                                            {
                                                bool bCreditNoteOk = (clsConfig.bSRN_AutoCreditNoteCreateEnable_NeedApproval) ? detail.IsApproved : true;
                                                if (bCreditNoteOk)
                                                {
                                                    tbl_bpsCreditNote_Detail cItems = new tbl_bpsCreditNote_Detail(row.Index, sCRN_ID, sItemCode, sItemSubCategoryID, sItemSubCategoryID2,
                                                        sItemSerialNo, sItemSerialNo2, dQuantity, dWeight, dUnitPrice, dWeightPrice, 0, 0, dAmount, sRemarks);
                                                    cItems.Insert();
                                                }
                                            }
                                            #endregion

                                            #region Update Store Stock
                                            decimal dWeightedAverageCostPrice = 0;
                                            clsHelpMethods.UpdateStoreStock(iFormID, detail.SalesReturnedNote_ID, detail.SalesReturnedNoteDate, sItemCode, "0", txtStoreID.Tag.ToString(), dQuantity, dWeight, items.TatalAmount, false, true, false, ref dWeightedAverageCostPrice);
                                           
                                            #endregion

                                            #region Pass Value to Inventory Detail
                                            tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(iFormID, int.Parse(sLineNo), 0, txtSRNID.Text.Trim(), dtpSRNDate.Value,
                                                                        "", "", "", "", txtCustomerID.Tag.ToString(), "default", txtStoreID.Tag.ToString(),
                                                                        sItemCode, clsGenaralName.getName_ItemUOMID(sItemCode), dQuantity, 0,dUnitPrice, 0, false);
                                            oListInventory.Add(oInventoryDetail);
                                            #endregion
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        clsValidate.WriteErrorLog("", iFormID, ex);
                                        SEACCException.Show(ex);
                                    }//error may come because last row of the grid may not have information
                                }
                            }
                            #endregion

                            Attachments.Insert(txtSRNID.Text.ToString());

                            #region Update Inventory
                            tbl_scsInventoryTxnHeader oHeader = new tbl_scsInventoryTxnHeader(iFormID, 0, txtSRNID.Text.Trim(), dtpSRNDate.Value, txtRemark.Text.Trim(),
                                txtCustomerID.Tag.ToString(), "default", txtSalesNoteType.Tag.ToString(), int.Parse(lblRoute.Tag.ToString()), decimal.Parse(txtGrandTotal.Text.Trim()),
                                "", "", "", "", false, clsSecurity.UserIDLoged);

                            clsHelpMethods.Update_Inventory(oHeader, oListInventory);
                            #endregion

                            clsAlerts_Email.createEmail_SalesReturn(txtSRNID.Text.Trim(), enum_Alerts.SalesReternCreated);
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //    MessageBox.Show("Sales Return Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                    if (detail != null)
                        FillDetails(detail.SalesReturnedNote_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void frm_sasSalseReturnNote_SF_printButton_Click(object sender, EventArgs e)
        {
            Print(false);
        }
        #endregion

        #region Btn Draft
        private void frm_sasSalseReturnNote_SF_draftButton_Click(object sender, EventArgs e)
        {
            Print(true);
        }
        #endregion

        #region Btn Temp
        private void frm_sasSalseReturnNote_SF_tempButton_Click(object sender, EventArgs e)
        {
            if (txtSRNID.TextLength > 0 && txtSRNID.Text != "<Auto Generate>")
            {
                isTemp = true;
                //set the flag and enble the id
                IsUpdate = false;
                lblCancelled.Visible = false;

                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSRNID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDOID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);

                clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, true);

                txtSRNID.Tag = null;
                dtpSRNDate.Value = clsSecurity.getServerDateTime();

                bHasApproved = false;
                bHasChecked = false;
                userDetailsColorChanges();

                //Reset Order Ref No
                txtOrderRefNo.Tag = null;
                txtOrderRefNo.Clear();
                glbOrderRefNo = "";

                //Reset Primary Key
                clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtSRNID, IsUpdate);

                if (txtSRNID.Enabled)
                {
                    txtSRNID.SelectAll();
                    txtSRNID.Focus();
                }

                ucSasProcessFlow.ClearFlow();
                Attachments.Clear();
            }
        }
        #endregion

        #region Btn Checked, Approved and History
        private void frm_sasSalseReturnNote_SF_checkButton_Click(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void frm_sasSalseReturnNote_SF_approveButton_Click(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void frm_sasSalseReturnNote_SF_History_Click(object sender, EventArgs e)
        {
            UserDetails();
        }
        #endregion

        #region Btn Add DeliveryOrder
        private void btnAddDeliveryOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDOID.Tag != null && txtDOID.Tag.ToString().Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDOID.Tag.ToString());
                    if (detail != null)
                    {
                        //add order ref detail
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                        txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);


                        //fill customer, branches and route
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

                        chkUnitPricing.Checked = !detail.IsWeightCalculation;

                        txtSalesNoteType.Tag = detail.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

                        //add currency detail
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        FillTaxDetailByDeliveryOrderID(detail.DeliveryOrder_ID);

                        //add item details
                        RefreshGridByDeliveryOrderID(detail.DeliveryOrder_ID);
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

        #region Fill Invoice Details
        private void btnAddDetails_ByInvoice()
        {
            try
            {
                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                {
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (oInvoice != null)
                    {
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oInvoice.OrderRefNo_ID);
                        if (order != null)
                        {
                            glbOrderRefNo = oInvoice.OrderRefNo_ID;
                            txtOrderRefNo.Tag = oInvoice.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(oInvoice.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        //add customer, branch and route
                        FillDetailsCustomer(oInvoice.Customer_ID);
                        if (oInvoice.Branch_ID != "default")
                        {
                            tbl_genCustomerMaster_Branches oBranch = tbl_genCustomerMaster_Branches.Select(oInvoice.Customer_ID, int.Parse(oInvoice.Branch_ID));
                            if (oBranch != null)
                            {
                                txtCustomerBranchID.Text = oBranch.BranchName;
                                txtCustomerBranchID.Tag = oInvoice.Branch_ID;

                                lblRoute.Text = clsGenaralName.getCode_Route(oBranch.Route_ID);
                                lblRoute.Tag = oBranch.Route_ID;
                            }
                        }

                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        chkUnitPricing.Checked = !oInvoice.IsWeightCalculation;

                        FillDetailsCurrency(oInvoice.Currency_ID);
                        txtCurrencyRate.Text = oInvoice.CurrencyRate.ToString();
                        FillTaxDetailByInvoice_ID(oInvoice.Invoice_ID);

                        txtSalesNoteType.Tag = oInvoice.SalesNoteType_ID;
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID));

                        //add item details
                        RefreshGridByInvoiceID(oInvoice.Invoice_ID);

                        if (clsConfig.bEnableSalesReturn_DirectPosting)
                        {
                            chkVat.Enabled = false;
                            chkNBT.Enabled = false;
                            chkOtherTax.Enabled = false;
                        }

                        //Discount
                        if (oInvoice.DiscountPercentage > 0 || oInvoice.DiscountPercentage1 > 0 || oInvoice.DiscountPercentage2 > 0 || oInvoice.DiscountPercentage3 > 0)
                        {
                            decimal dTotalDiscount = oInvoice.DiscountTotal + oInvoice.DiscountTotal1 + oInvoice.DiscountTotal2 + oInvoice.DiscountTotal3;
                            decimal dPerDis = (dTotalDiscount) / oInvoice.SubTotal * 100;

                            chkDiscount.Checked = true;
                            txtPercentageDiscount.Tag = dPerDis;
                            txtDiscount.Tag = dTotalDiscount;
                            txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dPerDis);
                            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalDiscount);
                        }

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

        #region Btn Lnk CreditNote
        private void lnkCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCreditNoteID.Text.Trim().Length > 0 && txtCreditNoteID.Text.Trim() != "default")
                {
                    tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(txtCreditNoteID.Text.Trim());
                    if (detail != null)
                    {
                        if (detail.CreditNote_ID != null && detail.CreditNote_ID.Length > 0 && detail.CreditNote_ID != "default")
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                            {
                                //frm_bpsCreditNote_PolyPS frm = new frm_bpsCreditNote_PolyPS();
                                //frm.glbCreditNoteID = detail.CreditNote_ID;
                                //frm.glbOrderRefNo = detail.OrderRefNo_ID;
                                //frm.Show();
                            }
                            else
                            {
                                frm_bpsCreditNote2 frm = new frm_bpsCreditNote2(FormName.bssCreditNote);
                                frm.glbCreditNoteID = detail.CreditNote_ID;
                                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                            }

                        }
                        else
                            MessageBox.Show("There is no credit note available for this sales returned note......", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    frm.Show();
                }
            }
        }
        #endregion

        #region Btn Create Receipt
        private void btnCreateCreditNote_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSRNID.Text.Trim().Length > 0 && txtSRNID.Text.Trim() != "default")
                {
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                    if (detail != null)
                    {
                        if (detail.CreditNote_ID != null && detail.CreditNote_ID.Length > 0 && detail.CreditNote_ID != "default")
                        {
                            //frm_bpsCreditNote_PolyPS frm = new frm_bpsCreditNote_PolyPS();
                            //frm.glbCreditNoteID = detail.CreditNote_ID;
                            //frm.glbOrderRefNo = detail.OrderRefNo_ID;
                            //frm.Show();
                        }
                        else
                            MessageBox.Show("There is no credit note available for this sales returned note......", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        #region Validation with DO
                        if (clsConfig.bSRn_Item_Validation_With_DO)
                        {
                            frm_sasMultipleItemSelect_SRN frm = new frm_sasMultipleItemSelect_SRN();
                            frm.glb_sCustomerID = txtCustomerID.Tag.ToString().Trim();
                            frm.glb_sItemID = detail.Item_ID;
                            frm.glb_sItemSubCategoryID = txtItemSubCategory.Tag.ToString();
                            frm.glb_sItemSubCategoryID2 = txtItemSubCategory.Text.Trim();
                            frm.glb_sItemSerialNo = txtItemSerialNo.Tag.ToString();
                            frm.glb_sItemSerialNo2 = txtItemSerialNo.Text.Trim();
                            frm.ShowDialog();

                            string sSalesNoteTypeID = "", sOrderRefID = "";
                            if (frm.lstclsTmpSelectedItems.Count > 0)
                            {
                                foreach (clsTmpSelectedItems oDO in frm.lstclsTmpSelectedItems)
                                {
                                    dgvDetail.Rows.Add();
                                    int iRow = dgvDetail.Rows.Count - 1;
                                    decimal dTotalAmount = oDO.dUnitPrice * oDO.dQty;

                                    var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                                    Fill_Datagrid(true, iRow, oDO.iLineNo, detail.Item_ID, oDO.sDONo, oDO.sInvoiceNo, oDO.sJobNo, detail.Uom_ID, oDO.dUnitPrice, 0, false, 0, 0, dTotalAmount, detail.Width, detail.Height, detail.Thickness, detail.Gusset, oDO.dWeight, oDO.dQty, oDO.dUnitPrice, dTotalAmount,
                                       txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), oDO.sRemarks, decimal.Parse(txtCurrencyRate.Text.Trim()));

                                    if (oDO.sSaleNoteID.Length > 0 && oDO.sSaleNoteID != "default")
                                        sSalesNoteTypeID = oDO.sSaleNoteID;

                                    if (oDO.sOrderRefID.Length > 0 && oDO.sOrderRefID != "default")
                                        sOrderRefID = oDO.sOrderRefID;
                                }

                                if (sSalesNoteTypeID.Length > 0)
                                {
                                    txtSalesNoteType.Tag = sSalesNoteTypeID;
                                    txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(sSalesNoteTypeID));
                                }
                                if (sOrderRefID.Length > 0)
                                {
                                    glbOrderRefNo = sOrderRefID;
                                    txtOrderRefNo.Tag = sOrderRefID;
                                    txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(sOrderRefID));
                                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);
                                }
                                CalculateTaxesAndGrandTotal();
                            }
                        }
                        #endregion
                        else
                        {
                            dgvDetail.Rows.Add();
                            int iRow = dgvDetail.Rows.Count - 1;
                            var maxLineNo = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));

                            decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(txtItemID.Tag.ToString(), "default", "default", "0", "0", txtCustomerID.Tag.ToString());

                            Fill_Datagrid(false, iRow, maxLineNo + 1, txtItemID.Tag.ToString(), "default", "default", "default", detail.Uom_ID, dUnitPrice, 0, false, 0, 0, 0, detail.Width, detail.Height, detail.Thickness, detail.Gusset, 0, 1, 0, 0,
                                txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim(), "", decimal.Parse(txtCurrencyRate.Text.Trim()));
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

        #region Btn F5
        private void btnF5_Click(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F5));
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat_New(dgvDetail, clsFormatter.colorGrid, UI_Color);
            clsHelpMethods.FormatGrid_Sales(dgvDetail);

            if (clsConfig.bWrap_ItemGrid_ItemName)
            {
                this.dgvDetail.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }

            //Grid Locks
            dgvDetail.Columns["UnitPrice"].ReadOnly = clsConfig.bEnableGridLock_Price_SRN ? true : false;
            dgvDetail.Columns["Quantity"].ReadOnly = clsConfig.bEnableGridLock_Quantity_SRN ? true : false;

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
            isTemp = false;
            //set the flag and enble the id
            IsUpdate = false;
            x2.Enabled = true;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSRNID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDOID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, true);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, true);

            clsCommon.SetEnableDisable_NormalRadioButton(rdoRefundable, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnable, true);
            clsCommon.SetEnableDisable_NormalRadioButton(rdoExcess, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkUnitPricing, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkEnteranceError, true);

            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, true);
            clsCommon.SetEnableDisable_NormalLabel(lblRoute, true);

            txtSRNID.Tag = null;
            txtCustomerID.Tag = null;
            txtDOID.Tag = null;
            txtInvoiceID.Tag = null;

            txtSalesExecutiveID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtStoreID.Tag = null;
            txtCustomerBranchID.Tag = null;
            txtSalesNoteType.Tag = null;
            txtItemID.Tag = null;
            txtItemSerialNo.Tag = null;
            txtItemSubCategory.Tag = null;
            lblRoute.Tag = null;

            lblRoute.Text = "";
            txtCustomerID.Clear();
            txtDOID.Clear();
            txtInvoiceID.Clear();
            txtRemark.Clear();
            glbOrderRefNo = "";
            dtpSRNDate.Value = clsSecurity.getServerDateTime();
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            txtSalesExecutiveID.Clear();
            txtOrderRefNo.Clear();
            txtStoreID.Clear();
            txtCreditNoteID.Clear();
            txtCustomerBranchID.Clear();
            txtSalesNoteType.Clear();
            txtItemID.Clear();
            txtItemSerialNo.Clear();
            txtItemSubCategory.Clear();

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
            dgvDetail.Rows.Clear();
            DisableMoneyControls();
            chkShowSettle.Checked = false;
            rdoRefundable.Checked = true;
            rdoReturnable.Checked = false;
            rdoExcess.Checked = false;
            chkPrintOriginal.Checked = false;

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            chkOtherTax.Enabled = true;
            chkDiscount.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;
            chkSettings2.Checked = true;
            chkEnteranceError.Checked = false;

            dtpSRNDate.Enabled = !clsConfig.bLock_TransactionDate_SAS;

            lnkCreditNote.Visible = true;

            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtSRNID, IsUpdate);

            if (clsConfig.bShow_GridViewColumn_Remarks)
                dgvDetail.Columns["Remarks"].Visible = true;
            else
                dgvDetail.Columns["Remarks"].Visible = false;

            if (txtSRNID.Enabled)
            {
                txtSRNID.SelectAll();
                txtSRNID.Focus();
            }

            cmbItemPrice.Enabled = true;
            foreach (ComboBoxItem d in cmbItemPrice.Items)
            {
                if (d.Value == clsConfig.sItemUnitPriceCode_Default)
                {
                    cmbItemPrice.SelectedItem = d;
                    break;
                }
            }

            if (!clsConfig.bSRn_Item_Validation_With_DO)
                txtSalesNoteType.Enabled = true;

            ucSasProcessFlow.ClearFlow();
            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sSalesRetrunNoteID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                tbl_sasSalesReturnedNote oSRN = tbl_sasSalesReturnedNote.Select(sSalesRetrunNoteID);
                if (oSRN != null && oSRN.SalesReturnedNote_ID != "default")
                {
                    List<tbl_sasSalesReturnedNote_Detail> details = tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(sSalesRetrunNoteID).OrderBy(p => p.Line_No).ToList();
                    foreach (tbl_sasSalesReturnedNote_Detail detail in details)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, detail.Invoice_ID, "default", item.Uom_ID, detail.UnitPrice, detail.KiloPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount,
                                detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, detail.UnitCost, detail.TatalCost_FIFO, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, oSRN.CurrencyRate);
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
        private void RefreshGridByInvoiceID(string sInvoiceID)
        {
            try
            {

                int iRow;
                //dgvDetail.Rows.Clear();
                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                if (oInvoice != null && oInvoice.Invoice_ID != "default")
                {
                    List<tbl_sasInvoice_Detail> details = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoiceID);
                    foreach (tbl_sasInvoice_Detail detail in details)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            decimal dUnitCose = 0;
                            try { dUnitCose = detail.TatalCost_FIFO / detail.Qty; }
                            catch (Exception ex) { clsValidate.WriteErrorLog("", iFormID, ex); }

                            Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, detail.Invoice_ID, clsHelpMethods.GetProductionJobIDByCustomerOrderID(detail.CustomerOrder_ID),
                                item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount, detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty, dUnitCose, detail.TatalCost_FIFO,
                                detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, oInvoice.CurrencyRate);
                        }
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
        private void RefreshGridByDeliveryOrderID(string sDeliveryOrder)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(sDeliveryOrder);
                if (oDO != null && oDO.DeliveryOrder_ID != "default")
                {
                    List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrder).OrderBy(p => p.Line_No).ToList(); ;
                    foreach (tbl_sasDeliveryOrder_Detail detail in details)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(true, iRow, detail.Line_No, detail.Item_ID, detail.DeliveryOrder_ID, "default", detail.Job_ID, item.Uom_ID, detail.UnitPrice, detail.WeightPrice, detail.BIsFreeItem, detail.DiscountPresentage, detail.DiscountAmount,
                                detail.TatalAmount, item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightReturned), (detail.Qty - detail.QtyReturned), detail.Qty == 0 ? 0 : (detail.TatalCost_FIFO / detail.Qty), detail.TatalCost_FIFO,
                                detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, oDO.CurrencyRate);
                        }
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
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sID);
                    if (detail != null)
                    {
                        IsUpdate = true;

                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;

                        if (detail.IsRefundable)
                            lnkCreditNote.Visible = false;

                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtSRNID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSalesNoteType, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblInvoiceID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStore, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblSalesNoteType, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDOID, false);

                        clsCommon.SetEnableDisable_NormalCheckBox(chkUnitPricing, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoRefundable, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoReturnable, false);
                        clsCommon.SetEnableDisable_NormalRadioButton(rdoExcess, false);
                        clsCommon.SetEnableDisable_NormalCheckBox(chkEnteranceError, false);


                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerBranchID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerBranch, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblRoute, false);

                        if (detail.Invoice_ID != "default" && clsConfig.bEnableSalesReturn_DirectPosting)
                        {
                            lnkCreditNote.Visible = false;

                            chkVat.Enabled = false;
                            chkNBT.Enabled = false;
                            chkOtherTax.Enabled = false;
                        }

                        txtCustomerID.Tag = detail.Customer_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        txtDOID.Tag = detail.DeliveryOrder_ID;
                        txtSRNID.Tag = detail.Invoice_ID;
                        txtStoreID.Tag = detail.Store_ID;
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

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }

                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                        txtDOID.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));

                        txtSRNID.Text = detail.SalesReturnedNote_ID;
                        txtRemark.Text = detail.Remark;
                        dtpSRNDate.Value = detail.SalesReturnedNoteDate;
                        //chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;                   
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        glbOrderRefNo = detail.OrderRefNo_ID;
                        rdoRefundable.Checked = detail.IsRefundable;
                        rdoReturnable.Checked = detail.IsReturnable;
                        rdoExcess.Checked = detail.IsExcess;
                        chkSettings2.Checked = false;
                        txtCreditNoteID.Text = clsCommon.GetForeignKeyValue(detail.CreditNote_ID);
                        txtSalesNoteType.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesNoteType(detail.SalesNoteType_ID));

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
                        RefreshGrid(detail.SalesReturnedNote_ID);

                        //Asign Taxes
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

                        ucSasProcessFlow.SetProcessFlowBySalesReturnNote(detail.SalesReturnedNote_ID);

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
                    txtSalesExecutiveID.Tag = customer.SalesRep_ID;

                    if (customer.Currency_ID != null && customer.Currency_ID != "default")
                        FillDetailsCurrency(customer.Currency_ID);

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

        #region Fill Tax Detail By Invoice_ID
        private void FillTaxDetailByInvoice_ID(string Invoice_ID)
        {
            try
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(Invoice_ID);
                if (detail != null)
                {
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

        #region Fill Tax Detail By DeliveryOrderID
        private void FillTaxDetailByDeliveryOrderID(string DeliveryOrderID)
        {
            try
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(DeliveryOrderID);
                if (detail != null)
                {
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
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckNumberValidity())
                {
                    if (CheckValidity_Item())
                    {
                        if (CheckValidity_CreditNote())
                        {

                            if (clsValidate.CheckGridCountValidity(dgvDetail.RowCount, iFormID))
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        if (clsSecurity.permissionToSave_Store(clsSecurity.UserIDLoged, txtStoreID.Tag.ToString(), IsUpdate))
                                            bStatus = true;
                                    }
                                }
                            }
                        }
                    }
                }
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
                    if (clsValidate.ValidateTextBox_EmptyValue(txtStoreID, "Store Name"))
                    {
                        if (clsValidate.ValidateTextBox_EmptyValue(txtSalesNoteType, "Note Type"))
                        {
                            if (clsValidate.ValidateTextBox_EmptyValue(txtRemark, "Remarks"))
                                bStatus = true;
                        }
                    }
                }
            }
            return bStatus;
        }
        private bool CheckValidity_Item()
        {
            bool rtn = true;
            try
            {
                string sItemCode = "", sDoCode = "", sInvoiceCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sLineNo = "";
                decimal dQuantity = 0, dWeight = 0;

                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        sLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, "0");
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        sDoCode = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                        sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        if (clsConfig.bSRn_Item_Validation_With_DO)
                        {
                            #region Validate Delivery Order Codes
                            if (sDoCode == "default")
                            {
                                rtn = false;
                                strMessage = "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " doesn't have a Delivery Order Code \n";
                            }
                            #endregion

                            #region Validate Invoice Code
                            if (rdoRefundable.Checked)
                            {
                                if (sInvoiceCode == "default")
                                {
                                    rtn = false;
                                    strMessage = "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " doesn't have a Invoice Code As This is a Refundable SRN \n";
                                }
                            }
                            #endregion
                        }


                        #region QTY/Weight Type Validation
                        tbl_sasDeliveryOrder oDelivery = tbl_sasDeliveryOrder.Select(sDoCode);
                        if (oDelivery != null && oDelivery.DeliveryOrder_ID != "default")
                        {
                            if (oDelivery.IsWeightCalculation)
                            {
                                if (chkUnitPricing.Checked)
                                {
                                    rtn = false;
                                    strMessage = "Sales Return is Not Allow to Change The QTY/Weight Type From Delivery Order........! ";
                                }
                            }
                        }
                        #endregion

                        if (dQuantity == 0)
                        {
                            rtn = false;
                            strMessage += "Quantity Should be Greater than 0....!";
                        }
                        else
                        {
                            #region Qty Validation with the DeliveryOrder
                            tbl_sasDeliveryOrder_Detail DoDetail = tbl_sasDeliveryOrder_Detail.Select(int.Parse(sLineNo), sDoCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                            if (DoDetail != null)
                            {
                                #region old
                                //if (chkUnitPricing.Checked)
                                //{
                                //    if (IsUpdate)
                                //    {
                                //        if ((DoDetail.Qty) < dQuantity)
                                //        {
                                //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Delivery Order Quantity \n";
                                //            rtn = false;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        if (DoDetail.Qty < (DoDetail.QtyReturned + dQuantity))
                                //        {
                                //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Delivery Order Quantity \n";
                                //            rtn = false;
                                //        }
                                //    }

                                //}
                                //else
                                //{
                                //    if (IsUpdate)
                                //    {
                                //        if (DoDetail.Weight < dWeight)
                                //        {
                                //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Delivery Order Weight \n";
                                //            rtn = false;
                                //        }
                                //    }
                                //    else
                                //    {
                                //        if (DoDetail.Weight < (DoDetail.WeightReturned + dWeight))
                                //        {
                                //            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Delivery Order Weight \n";
                                //            rtn = false;
                                //        }
                                //    }
                                //} 
                                #endregion

                                if (chkUnitPricing.Checked)
                                {
                                    if (IsUpdate)
                                    {
                                        decimal dOldReturnedQty = 0;
                                        foreach (tbl_sasSalesReturnedNote_Detail SRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text).Where(p => p.Line_No == int.Parse(sLineNo)))
                                        {
                                            dOldReturnedQty += SRNDetail.Qty;
                                        }

                                        if (DoDetail.Qty < (DoDetail.QtyReturned - dOldReturnedQty) + dQuantity)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Available Delivery Order Quantity \n";
                                            rtn = false;
                                        }
                                    }
                                    else
                                    {
                                        if (DoDetail.Qty < (DoDetail.QtyReturned + dQuantity))
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Quantity is Exceed the Delivery Order Quantity \n";
                                            rtn = false;
                                        }
                                    }

                                }
                                else
                                {
                                    if (IsUpdate)
                                    {
                                        decimal dOldReturnedWeight = 0;
                                        foreach (tbl_sasSalesReturnedNote_Detail SRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(txtSRNID.Text).Where(p => p.Line_No == int.Parse(sLineNo)))
                                        {
                                            dOldReturnedWeight += SRNDetail.Weight;
                                        }

                                        if (DoDetail.Weight < (DoDetail.WeightReturned - dOldReturnedWeight) + dWeight)
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Available Delivery Order Weight \n";
                                            rtn = false;
                                        }
                                    }
                                    else
                                    {
                                        if (DoDetail.Weight < (DoDetail.WeightReturned + dWeight))
                                        {
                                            strMessage += "Item: " + sItemCode + " - " + clsGenaralName.getName_Item(sItemCode) + " Weight is Exceed the Delivery Order Weight \n";
                                            rtn = false;
                                        }
                                    }
                                }
                            }
                            #endregion
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
                    MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
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
        private bool CheckAmountValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            decimal dFCharges = 0, dGrandTotal = 0;
            try
            {
                if (txtInvoiceID.TextLength > 0)
                {
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Text.Trim());
                    if (detail != null)
                    {
                        if (clsCommon.isCurrency(txtGrandTotal.Text.Trim()))
                            dGrandTotal = decimal.Parse(txtGrandTotal.Text.Trim());

                        decimal dInvoiceAmount = (detail.GrandTotal - detail.SeattleAmount);
                        decimal dCrediNoteAmount = (dFCharges + dGrandTotal);

                        if (dInvoiceAmount < dCrediNoteAmount)
                        {
                            strMessage += "Customer Name ";
                            bStatus = false;
                        }
                    }
                }
                else
                {
                    strMessage = "";
                    bStatus = false;
                }

                if (bStatus == false)
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }
        private bool CheckValidity_CreditNote()
        {
            bool bStatus = true;
            return bStatus;
        }
        private bool CheckPrintingValidity(int iPrintCount)
        {
            bool bOk = true;
            try
            {
                if (iPrintCount > 0)
                {
                    bOk = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bOk;
        }
        private bool ValidateForDependancies(string sSRNId)
        {
            bool bValue = true;
            try
            {
                foreach (tbl_bpsCreditNote oCN in tbl_bpsCreditNote.SelectAllBySalesReturnedNote_ID(sSRNId).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                {
                    bValue = false;
                    MessageBox.Show("Record Is Locked! \n\n[" + oCN.CreditNote_ID + "] Credit Note is already created for this SRN", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return bValue;
        }
        private bool CheckValiditeCustomer()
        {
            bool rtn = true;
            if (txtCustomerID.Tag == null || txtCustomerID.Tag.ToString() == "default")
            {
                rtn = false;
                MessageBox.Show("Please Select the Customer Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCustomerID.Focus();
            }
            return rtn;
        }
        private bool CheckValidity_Posting()
        {
            bool bStatus = false;
            try
            {
                if (clsConfig.bAutoPostingEnable)
                {
                    string sAccountCode_Sales = "default";

                    if (clsConfig.sInvoice_SalesAccount_Type == "1")
                    {
                        tbl_zSalesNoteType oSalesNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
                        if (oSalesNoteType != null)
                            sAccountCode_Sales = oSalesNoteType.Gl_ID;
                    }
                    else
                    {
                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                        if (oCustomer != null)
                            sAccountCode_Sales = oCustomer.Sales_Gl_ID;
                    }

                    bool bSlotStatus_Customer = clsMethods_GL.CheckAccountLink_Customer(txtCustomerID.Tag.ToString());
                    bool bSlotStatus_debit = clsMethods_GL.CheckAccountValidity(sAccountCode_Sales);
                    bool bSlotStatus_NBT = clsMethods_GL.CheckAccountLink_NBTReceivable();
                    bool bSlotStatus_VAT = clsMethods_GL.CheckAccountLink_VATReceivable();

                    if (bSlotStatus_Customer && bSlotStatus_debit && bSlotStatus_NBT && bSlotStatus_VAT)
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
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtInvoiceID);
                clsCommon.ValidateForeignKey(ref txtDOID);
                clsCommon.ValidateForeignKey(ref txtStoreID);
                clsCommon.ValidateForeignKey(ref txtCustomerBranchID);

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events KeyDown
        private void txtSRNID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_SalesReturnedNote();
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerID();
        }
        private void txtDOID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_DeliveryOrderID(sender);
        }
        private void txtInvoiceID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_InvoiceID(sender);
        }
        private void txtStoreID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                clsSearch.Search_MasterStore(ref txtStoreID, true);
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
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_ItemID(sender, e);
        }

        private void txtCustomerBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_CustomerBranch();
        }
        #endregion

        #region Events Double Click
        private void txtSRNID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesReturnedNote();
        }

        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }

        private void txtDOID_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrderID(sender);
        }

        private void txtInvoiceID_DoubleClick(object sender, EventArgs e)
        {
            Search_InvoiceID(sender);
        }

        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }

        private void txtSalesExecutiveID_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }

        private void txtStoreID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtStoreID, true);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        private void txtSalesNoteType_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesNoteType();
        }
        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID(sender, new KeyEventArgs(Keys.F1));
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
                CalcualteFIFOCost(sender, e);
            }
        }
        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e, dgvDetail);

            //string sColName = "";
            //DataGridView dgv = (DataGridView)sender;
            //if (e.ColumnIndex >= 0)
            //    sColName = dgv.Columns[e.ColumnIndex].Name;

            //int iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", e.RowIndex, 0);
            //string sDO = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", e.RowIndex, "");
            //string sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
            //decimal dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));

            //decimal dAvailableQty = 0;

            //if (IsUpdate)
            //{
            //    if (sColName == "Quantity")
            //    {
            //        tbl_sasDeliveryOrder_Detail oDODetail = tbl_sasDeliveryOrder_Detail.Select(iLineNo, sDO, sItemID, "default", "default", "0", "0");
            //        if (oDODetail != null)
            //        {
            //            dAvailableQty = oDODetail.Qty - oDODetail.QtyReturned;
            //            //if (dAvailableQty < dQuantity)
            //            if (dAvailableQty < decimal.Parse(e.Value.ToString()))
            //                MessageBox.Show("Qty Cannot Be Greater Than Available Qty (" + clsFormatter.FormatDecimalPlaces_Quantity(dAvailableQty) + ")", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
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
        private void dgvDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{left}");
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
        private void Search_SalesReturnedNote()
        {
            try
            {
                clsSearch.Search_TransactionSalesReturnNote(ref txtSRNID, "", false, chkShowSettle.Checked, chkShowSettle.Checked);
                if (txtSRNID.Tag != null && txtSRNID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtSRNID.Tag.ToString());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #region Store
        public static void Search_MasterStore(ref TextBox txtBox)
        {
            clsSearch.Search_MasterStore(ref txtBox, true);
        }
        #endregion
        private void Search_InvoiceID(object oSender)
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), hasOrderRefNo, glbOrderRefNo, true, false, false, false, true, "");
                else
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, "", hasOrderRefNo, glbOrderRefNo, true, false, false, false, true, "");

                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Trim().Length > 0 && txtInvoiceID.Tag.ToString() != "default")
                {
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null)
                    {
                        //fill do detail
                        txtDOID.Tag = detail.DeliveryOrder_ID;
                        txtDOID.Text = clsCommon.GetForeignKeyValue(detail.DeliveryOrder_ID);
                        btnAddDetails_ByInvoice();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtSRNID, IsUpdate);
        }
        private void Search_DeliveryOrderID(object objSender)
        {
            try
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDOID, txtCustomerID.Tag.ToString(), true);
                else
                    clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDOID, "", true);

                if (txtDOID.Tag != null && txtDOID.Tag.ToString().Length > 0)
                {
                    tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(txtDOID.Tag.ToString());
                    if (detail != null)
                    {
                        btnAddDeliveryOrder_Click(objSender, new EventArgs());

                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtDOID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtInvoiceID, false);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtSRNID, IsUpdate);
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

                                lblRoute.Text = "Route Code - " + clsGenaralName.getCode_Route(Detail.FirstOrDefault().Route_ID);
                                lblRoute.Tag = Detail.FirstOrDefault().Route_ID.ToString();
                            }
                        }
                    }
                }
                #endregion
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
        private void Search_Currency()
        {
            try
            {
                clsSearch.Search_MasterCurrency(ref txtCurrencyID);
                if (txtCurrencyID.Tag != null)
                    FillDetailsCurrency(txtCurrencyID.Tag.ToString());
                else
                    FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
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
        private void Search_SalesNoteType()
        {
            clsSearch.Search_MasterSalesNoteType(ref txtSalesNoteType);
            clsAutocode.IsAutoGenerated_Advanced(sFormConfigCode, (txtSalesNoteType.Tag == null) ? "default" : txtSalesNoteType.Tag.ToString(), ref txtSRNID, IsUpdate);

            if (txtCustomerID.Tag != null)
                FillDetailsCustomer(txtCustomerID.Tag.ToString());

            tbl_zSalesNoteType oNoteType = tbl_zSalesNoteType.Select(txtSalesNoteType.Tag.ToString());
            if (oNoteType != null)
            {
                if (!((oNoteType.IsPostingEnable_NBT && oNoteType.IsPostingEnable_VAT)
                    //&& (chkNBT.Checked || chkVat.Enabled)
                    ))
                {
                    chkNBT.Checked = false;
                    chkVat.Checked = false;
                }
            }
        }
        private void Search_ItemID(object sender, KeyEventArgs e)
        {
            try
            {
                if (CheckValiditeCustomer())
                {
                    if (CheckValidity_EmptyField())
                    {
                        if (e.KeyCode == Keys.F1)
                        {
                            clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
                                btnAddItem_Click(null, new EventArgs());
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

                                    var maxLine = dgvDetail.Rows.Cast<DataGridViewRow>().Max(r => Convert.ToInt32(r.Cells["LineNo"].Value));
                                    Fill_Datagrid(false, iRow, maxLine + 1, oItem.sItemID, "default", "default", "default", oItem.sUOMID, oItem.dUnitPrice, oItem.dWeightPrice, false, 0, 0, oItem.dTotalAmount, 0, 0, 0, 0, oItem.dWeight, oItem.dQty, oItem.dUnitPrice, 0, oItem.sItemSubCategoryID, oItem.sItemSubCategoryID2, oItem.sItemSerialNo, oItem.sItemSerialNo2, "", dExRate);
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

        #region Calcualte Values
        private void CalculateTaxesAndGrandTotal()
        {
            txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance_Round(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
                txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
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
        private void CalcualteFIFOCost(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = "";
                decimal dQuantity = 0, dUnitCost = 0;
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if ((sColName == "Quantity" || sColName == "unitCost"))
                {
                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                    dUnitCost = clsValidate.ValidateGridValue(dgvDetail, "unitCost", e.RowIndex, decimal.Parse("0.00"));
                    dgvDetail["TatalCost_FIFO", e.RowIndex].Value = dUnitCost * dQuantity;
                }
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
        #endregion

        #region Vat Revers calculation
        private void VatReverceCalculation(decimal dVatRate)
        {
            try
            {
                if (!isDonVatReversCalculation)
                {
                    if (dVatRate > 0)
                    {
                        decimal dTotalVat = 0;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            decimal dUnitPrice = 0, dWeightPrice = 0, dVatAmount = 0;
                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                            #region Tax Amount Calculation
                            if (chkUnitPricing.Checked)
                            {
                                dVatAmount = (dUnitPrice / (100 + dVatRate)) * 100;
                                dVatAmount = dUnitPrice - Math.Round(dVatAmount, 2);
                                dUnitPrice = dUnitPrice - Math.Round(dVatAmount, 2);
                                dTotalVat += Math.Round(dVatAmount, 2);
                            }
                            else
                            {
                                dVatAmount = (dWeightPrice / (100 + dVatRate)) * 100;
                                dVatAmount = dWeightPrice - Math.Round(dVatAmount, 2);
                                dWeightPrice = dWeightPrice - Math.Round(dVatAmount, 2);
                                dTotalVat += Math.Round(dVatAmount, 2);
                            }
                            #endregion

                            #region Assign New Value
                            if (clsCommon.IsCustomerizedGrid())
                            {
                                if (chkUnitPricing.Checked)
                                    dgvDetail["UnitPrice", row.Index].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dUnitPrice);
                                else
                                    dgvDetail["WeightPrice", row.Index].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dWeightPrice);
                            }
                            else
                            {
                                if (chkUnitPricing.Checked)
                                    dgvDetail["UnitPrice", row.Index].Value = dUnitPrice.ToString();
                                else
                                    dgvDetail["WeightPrice", row.Index].Value = dWeightPrice.ToString();
                            }
                            #endregion

                            isDonVatReversCalculation = true;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalVat);
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

        #region Nbt Revers Calculation
        private void NbtReverceCalculation(decimal dNbtRate)
        {
            try
            {
                if (!isDonNbtReversCalculation)
                {
                    if (dNbtRate > 0)
                    {
                        decimal dTotalNbt = 0;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            decimal dUnitPrice = 0, dWeightPrice = 0, dNbtAmount = 0;
                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                            #region Tax Amount Calculation
                            if (chkUnitPricing.Checked)
                            {
                                dNbtAmount = (dUnitPrice / (100 + dNbtRate)) * 100;
                                dNbtAmount = dUnitPrice - Math.Round(dNbtAmount, 2);
                                dUnitPrice = dUnitPrice - Math.Round(dNbtAmount, 2);
                                dTotalNbt += Math.Round(dNbtAmount, 2);
                            }
                            else
                            {
                                dNbtAmount = (dWeightPrice / (100 + dNbtRate)) * 100;
                                dNbtAmount = dWeightPrice - Math.Round(dNbtAmount, 2);
                                dWeightPrice = dWeightPrice - Math.Round(dNbtAmount, 2);
                                dTotalNbt += Math.Round(dNbtAmount, 2); ;
                            }
                            #endregion

                            #region Assign New Value
                            if (clsCommon.IsCustomerizedGrid())
                            {
                                if (chkUnitPricing.Checked)
                                    dgvDetail["UnitPrice", row.Index].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dUnitPrice);
                                else
                                    dgvDetail["WeightPrice", row.Index].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dWeightPrice);
                            }
                            else
                            {
                                if (chkUnitPricing.Checked)
                                    dgvDetail["UnitPrice", row.Index].Value = dUnitPrice.ToString();
                                else
                                    dgvDetail["WeightPrice", row.Index].Value = dWeightPrice.ToString();
                            }
                            #endregion

                            isDonNbtReversCalculation = true;
                            dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["UnitPrice"].Index, row.Index));
                        }
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(dTotalNbt);
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
        private void Fill_Datagrid(bool IsUpdateMode, int iRow, int lineNo, string ItemID, string DeliveryOrderID, string InvoiceID, string JobID, string Uom_ID, decimal UnitPrice, decimal KiloPrice, bool isFreeItem, decimal DiscountPresentage, decimal DiscountAmount, decimal GrossTotal,
        decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, decimal dUnitCost, decimal dTatalCost_FIFO, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, decimal dExRate)
        {
            try
            {
                bool isNewItem = true;
                bool bValidItem = true;

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
                            if (ItemID == clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, ""))
                            {
                                string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "", sDONo = "";
                                int iLineNo = lineNo;

                                iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, lineNo);
                                sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                                sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                sDONo = clsValidate.ValidateGridValue(dgvDetail, "DeliveryOrderCode", row.Index, "default");
                                sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");

                                if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2 && sDONo == DeliveryOrderID)
                                {
                                    if (lstItems.Where(r => r == sItemID).Count() > 1)
                                    {
                                        MessageBox.Show("Cannot add already duplicated items..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dgvDetail.Rows.RemoveAt(dgvDetail.Rows.Count - 1);
                                        return;
                                    }

                                    dgvDetail.Rows.RemoveAt(iRow);
                                    lineNo = iLineNo;
                                    bValidItem = false;
                                    MessageBox.Show("Duplicate Item \nItem ID " + ItemID + " In D/O No. " + DeliveryOrderID + " is Already Existing in the Data Grid", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }

                if (bValidItem)
                {
                    //Get Unit Price with Exchange rate to save
                    UnitPrice = clsHelpMethods.getDisplayPrice(UnitPrice, dExRate);
                    KiloPrice = clsHelpMethods.getDisplayPrice(KiloPrice, dExRate);
                    GrossTotal = clsHelpMethods.getDisplayPrice(GrossTotal, dExRate);

                    dgvDetail["LineNo", iRow].Value = lineNo;
                    dgvDetail["ItemCode", iRow].Value = ItemID;
                    dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                    dgvDetail["DeliveryOrderCode", iRow].Value = DeliveryOrderID;//add by thilina
                    dgvDetail["InvoiceCode", iRow].Value = InvoiceID;//add by thilina                
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

                    dgvDetail["unitCost", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitCost);
                    dgvDetail["tatalCost_FIFO", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dTatalCost_FIFO);

                    dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                    dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);
                    if (isNewItem)
                        dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);

                    if (isNewItem)
                        dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(KiloPrice);



                    //Anoj Please check this -Asanka
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

                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Calculate SubTotal With NBT
        private decimal GetSubTotalWithNbt()
        {
            decimal dSubtotal = 0;
            try
            {
                decimal dPesentageNBT = 0, dDiscount = 0;
                if (clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                    dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
                if (clsCommon.isCurrency(txtDiscount.Text.Trim()))
                    dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                dSubtotal -= dDiscount;
                if (chkNBT.Checked)
                {
                    if (dSubtotal > 0)
                    {
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
                        if (clsCommon.isCurrency(txtPercentageNBT.Text.Trim()))
                        {
                            dPesentageNBT = decimal.Parse(txtPercentageNBT.Text.Trim());
                            if (dPesentageNBT > 0)
                                dSubtotal += (dSubtotal * dPesentageNBT) / 100;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return dSubtotal;
        }
        #endregion

        #region Calculate Subtotal with Other Tax
        private decimal GetSubTotalWithOtherTax()
        {
            decimal dSubtotal = GetSubTotalWithNbt();
            try
            {
                decimal dPesentageOtherTax = 0;
                if (chkOtherTax.Checked)
                {
                    if (dSubtotal > 0)
                    {
                        if (clsCommon.isCurrency(txtPercentageOtherTax.Text.Trim()))
                        {
                            dPesentageOtherTax = decimal.Parse(txtPercentageOtherTax.Text.Trim());
                            if (dPesentageOtherTax > 0)
                            {
                                dSubtotal += (dSubtotal * dPesentageOtherTax) / 100;
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
            return dSubtotal;
        }
        #endregion

        #region Calculate SubTotal With Vat
        private decimal GetSubTotalWithVat()
        {
            decimal dSubtotal = GetSubTotalWithOtherTax();
            try
            {
                decimal dPesentageVAT = 0;
                if (chkVat.Checked)
                {
                    if (dSubtotal > 0)
                    {
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());
                        if (clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                        {
                            dPesentageVAT = decimal.Parse(txtPercentageVat.Text.Trim());
                            if (dPesentageVAT > 0)
                                dSubtotal += (dSubtotal * dPesentageVAT) / 100;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            return dSubtotal;
        }
        #endregion

        #region Print Method
        private void Print(bool bisDraft)
        {
            if (txtSRNID.TextLength > 0 && txtSRNID.Text != "<Auto Generate>")
            {
                try
                {
                    bool bApprovalDone = true, bCheckingDone = true;
                    Cursor = Cursors.WaitCursor;
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sJobNo = "", sPONo = "", sCustomerAddress = "";
                    string sDuplicate = "";

                    // glb_dts_sasSalesReturn.dt_sasSalesReturnedNote.Rows.Clear();
                    //  glb_dts_sasSalesReturn.dt_sasSalesReturnedNoteDetail.Rows.Clear();
                    glb_dts_sasSalesReturn.Clear();

                    bool bPermissinOkToPrint = true;
                    if (chkPrintOriginal.Checked)
                        bPermissinOkToPrint = clsSecurity.PermissionToPrintOriginal_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_SalesReturnNote));

                    if (bPermissinOkToPrint)
                    {
                        tbl_sasSalesReturnedNote order = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                        if (order != null)
                        {
                            if (!bisDraft)
                            {
                                #region Validate Approval
                                if (clsConfig.bApprovalNeedToPrintSalesReturned)
                                {
                                    if (!order.IsApproved)
                                    {
                                        bApprovalDone = false;
                                        MessageBox.Show("Please Approve the Sales Return Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                                #region Validate Checking
                                if (clsConfig.bCheckingNeedToPrintSalesReturned)
                                {
                                    if (!order.IsChecked)
                                    {
                                        bCheckingDone = false;
                                        MessageBox.Show("Please Check the Sales Return Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                #endregion
                            }

                            if (bApprovalDone && bCheckingDone)
                            {
                                clsLog.Process_Print(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned), order.SalesReturnedNote_ID);

                                if (!bisDraft)
                                {
                                    if (!chkPrintOriginal.Checked)
                                        sDuplicate = (order.PrintCount > 0) ? "Duplicate Copy " + order.PrintCount : "";

                                    order.PrintCount++;
                                    order.DatePrinted = clsSecurity.getServerDateTime();
                                    order.PrintedTerminal_ID = clsSecurity.TerminalID;
                                    order.PrintedUser_ID = clsSecurity.UserIDLoged;
                                    order.Update();
                                }

                                sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToString("yyyy-MMM-dd") + " ]";
                                if (order.CheckedUser_ID != "default")
                                    sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToString("yyyy-MMM-dd") + " ]";
                                if (order.ApprovedUser_ID != "default")
                                    sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToString("yyyy-MMM-dd") + " ]";


                                tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(order.DeliveryOrder_ID);
                                if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                {
                                    sJobNo = oDO.Job_ID != "default" ? oDO.Job_ID : "N/A";
                                    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oDO.CustomerOrder_ID);
                                    sPONo = oCO != null && oCO.CustomerOrder_ID != "default" ? oCO.PurchaseOrder_ID : "N/A";
                                    sCustomerAddress = oCO.DeliveryAddress; ;
                                }

                                if (sCustomerAddress == "")
                                {
                                    sCustomerAddress = clsGenaralName.getName_CustomerRegisterAddress(order.Customer_ID);
                                    sPONo = clsGenaralName.getName_OrderRefNo(order.OrderRefNo_ID);
                                }

                                //For main Logo
                                tbl_genCompanyImage oCompaneyImage = tbl_genCompanyImage.Select("Company1");
                                glb_dts_sasSalesReturn.dt_sasCompanyDetail.Adddt_sasCompanyDetailRow(oCompaneyImage.MainLogo);
                                glb_dts_sasSalesReturn.dt_sasSalesReturnedNote.Adddt_sasSalesReturnedNoteRow(clsGenaralName.getName_Customer(order.Customer_ID), sCustomerAddress, clsGenaralName.getName_BranchCustomer(order.Customer_ID, int.Parse(order.Branch_ID)), order.SalesReturnedNote_ID, order.DeliveryOrder_ID, order.CreditNote_ID, sPONo, order.Invoice_ID, sJobNo, order.SalesReturnedNoteDate, order.Store_ID, clsGenaralName.getName_Store(order.Store_ID), order.SubTotal, order.DiscountTotal, order.DiscountPercentage, order.NbtTotal, order.NbtPercentage, order.VatTotal, order.VatPercentage, order.OtherTaxTotal, order.OtherTaxPercentage, order.GrandTotal, order.Remark, order.IsDeleted);

                                foreach (tbl_sasSalesReturnedNote_Detail oOderes in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(order.SalesReturnedNote_ID).Where(p => p.SalesReturnedNote_ID != "default"))
                                {
                                    string sItemSizeRemark = "-";
                                    tbl_genItemMaster item = tbl_genItemMaster.Select(oOderes.Item_ID);
                                    if (item != null && item.Item_ID != "default")
                                        sItemSizeRemark = clsHelpMethods.GetItemSizeByItemID(item.Item_ID);

                                    tbl_sasSalesReturnedNote oSalesReturn = tbl_sasSalesReturnedNote.Select(oOderes.SalesReturnedNote_ID.Trim());
                                    if (oSalesReturn != null && oSalesReturn.SalesReturnedNote_ID != "default")
                                        glb_dts_sasSalesReturn.dt_sasSalesReturnedNoteDetail.Adddt_sasSalesReturnedNoteDetailRow(order.SalesReturnedNote_ID, oOderes.Item_ID, clsGenaralName.getName_Item(oOderes.Item_ID), clsGenaralName.getName_ItemUOM(oOderes.Item_ID), oOderes.Qty, oOderes.Weight, oOderes.UnitPrice - oOderes.DiscountAmount, oOderes.Remark, sItemSizeRemark, oOderes.TatalAmount);
                                }

                                #region PrintSection
                                string s_Path = "", sReportTitle = "Sales Returned Note";

                                string sGetRptPath = clsHelpMethods.GetReportPath(clsAutocode.getReportID(enum_ReportName.NP_SalesReturnNote));
                                if (sGetRptPath.Length > 0 && sGetRptPath != null)
                                    s_Path = sGetRptPath;
                                //     else
                                //       s_Path = "\\reports\\SAS\\NotePrinting\\rpt_sasSalesReturned_AKTDataset.rpt";

                                //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                //{
                                //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("JobNo", sJobNo, true,false);
                                //    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("PONo", sPONo, true,false);
                                //}

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ReportTitle", sReportTitle, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", clsSecurity.CompanyName, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", clsSecurity.CompanyAddress1, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", clsSecurity.CompanyAddress2, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", clsSecurity.DigiteqName, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", clsCommon.getCompanyEmail(), true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("UserName", clsSecurity.UserNameLoged, true, false);

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CreateUserName", sCreateUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CheckUserName", sCheckedUser, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("ApproveUserName", sApprovedUser, true, false);

                                try
                                {
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", clsCommon.getCompanyBusinessRegisterNo(), true, false);
                                    glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", clsCommon.getCompanyVAT(), true, false);
                                }
                                catch { }

                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", sDuplicate, true, false);
                                glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("isDraft", bisDraft ? "DRAFT" : "", true, false);

                                if (bisDraft)
                                {
                                    if (!clsConfig.isVisibleCompanyInfoInDraftPrint)
                                    {
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyName", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress1", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyAddress2", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyEmail", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqName", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DigiteqEmail", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("DuplicateCopy", "", true, false);

                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("BusinessRegNo", "", true, false);
                                        glb_dtsReportExport.dt_rptParameter.Adddt_rptParameterRow("CompanyVatNo", "", true, false);
                                    }
                                }

                                frm_ReportViewer_New ReportViewer = new frm_ReportViewer_New();
                                ReportViewer.print(s_Path, glb_dts_sasSalesReturn, glb_dtsReportExport.dt_rptParameter, clsAutocode.getReportID(enum_ReportName.NP_SalesReturnNote));
                                #endregion
                            }
                        }

                        clsAlerts_Email.createEmail_SalesReturn(txtSRNID.Text.Trim(), enum_Alerts.SalesReturnNotePrint);
                    }
                }
                catch (Exception ex)
                {

                    SEACCException.Show(ex);
                    clsValidate.WriteErrorLog("", iFormID, ex);
                }
                finally
                {
                    glb_dts_sasSalesReturn.dt_sasSalesReturnedNote.Rows.Clear();
                    glb_dts_sasSalesReturn.dt_sasSalesReturnedNoteDetail.Rows.Clear();
                    Cursor = Cursors.Default;
                }

            }
            else
                MessageBox.Show("Please Select the SRN To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region User Checked Approve Details
        private void Search_ApprovedBy()
        {
            try
            {
                if (IsUpdate)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                        {
                            if (CheckValidity_Posting())
                            {
                                if (txtSRNID.Text != null && txtSRNID.TextLength > 0 && txtSRNID.Text != "<Auto Generate>")
                                {
                                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                                    if (detail != null)
                                    {
                                        if (!detail.IsDeleted)
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

                                                    userDetailsColorChanges();

                                                    string sCreditNoteID = "";
                                                    if (clsProcessMethods.Update_Approval_SRN(txtSRNID.Text.Trim(), frmSetApproved.sApprovedUserID, ref sCreditNoteID, rdoRefundable.Checked))
                                                    {
                                                        if (sCreditNoteID.Length > 0)
                                                        {
                                                            txtCreditNoteID.Tag = sCreditNoteID;
                                                            txtCreditNoteID.Text = sCreditNoteID;

                                                            MessageBox.Show("Credit Note Has Created Successfully......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                        }
                                                    }
                                                }
                                                else if (frmSetApproved.bReset)
                                                    bHasApproved = false;
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                }
                                else
                                    MessageBox.Show("Please Fill Details to Approve", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
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
                bool bPermisstionOK = false;
                if (rdoReturnable.Checked)
                    bPermisstionOK = clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, clsSecurity.getFormID(FormName.SalesReturndForReturnable));
                else
                    bPermisstionOK = clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID);

                if (bPermisstionOK)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpSRNDate.Value.Date))
                    {
                        if (txtSRNID.Text != null && txtSRNID.TextLength > 0 && txtSRNID.Text != "<Auto Generate>")
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
                                    if (IsUpdate)
                                    {
                                        bHasChecked = true;
                                        glbCheckedDate = clsSecurity.getServerDateTime();
                                        userDetailsColorChanges();

                                        tbl_sasSalesReturnedNote objDO = tbl_sasSalesReturnedNote.Select(txtSRNID.Text.Trim());
                                        if (objDO != null)
                                        {
                                            objDO.IsChecked = true;
                                            objDO.DateChecked = clsSecurity.getServerDateTime();
                                            objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                            objDO.Update();

                                            if (clsAlerts.Update_AfterChecking_SRN(txtSRNID.Text.Trim(), clsSecurity.UserIDLoged))
                                                MessageBox.Show("Stock Has Updated Successfully......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                if (txtSRNID.Text != "" || txtSRNID.Text != "<Auto Generate>")
                {
                    tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(txtSRNID.Text);
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
    }
}