using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataTire;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Reflection;
using System.Data;
//using SEACC_WPFControls;

namespace Digiteq_Logic
{
    public class clsHelpMethods
    {
        #region Invoice Settled - With Credit Note
        public static decimal AutoSettledInvoiceWithCreditNote(string sInvoiceID, string sCreditNoteID, decimal dSetaleAmount, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            decimal dInvSettledAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWithCreditNote))
                {
                    decimal dInvoiceToBeSettled = 0, dCreditNoteAvailableAmount = 0;

                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(sCreditNoteID);
                    if (oInvoice != null && oCreditNote != null)
                    {
                        string sSettlement_ID = "";
                        #region Allocation Date
                        DateTime dtmAllocationDate = oInvoice.InvoiceDate;
                        if (oCreditNote.CreditNoteDate > oInvoice.InvoiceDate)
                            dtmAllocationDate = oCreditNote.CreditNoteDate;
                        #endregion

                        dInvoiceToBeSettled = (dSetaleAmount != 0) ? dSetaleAmount : (oInvoice.GrandTotal - oInvoice.SeattleAmount);
                        dCreditNoteAvailableAmount = oCreditNote.TotalAmount - oCreditNote.SeattleAmount;

                        #region MyRegion
                        if (dCreditNoteAvailableAmount > 0 && dInvoiceToBeSettled > 0)
                        {
                            if (dInvoiceToBeSettled <= dCreditNoteAvailableAmount) //if Credit Note has enough cash to settled
                            {
                                oInvoice.SeattleAmount += dInvoiceToBeSettled;
                                oCreditNote.SeattleAmount += dInvoiceToBeSettled;

                                oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
                                oCreditNote.IsSeattled = oCreditNote.TotalAmount == oCreditNote.SeattleAmount ? true : false;

                                oInvoice.Update();
                                oCreditNote.Update();

                                sSettlement_ID = clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, "default", "default", sCreditNoteID, "default", "default", -1, "default", dtmAllocationDate, (dSetaleAmount != 0) ? dSetaleAmount : dInvoiceToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);

                                dInvSettledAmount = dInvoiceToBeSettled;
                            }
                            else //if Invoice amount is greter than credit note amount
                            {
                                oInvoice.SeattleAmount += dCreditNoteAvailableAmount;
                                oCreditNote.SeattleAmount += dCreditNoteAvailableAmount;

                                oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
                                oCreditNote.IsSeattled = oCreditNote.TotalAmount == oCreditNote.SeattleAmount ? true : false;

                                oInvoice.Update();
                                oCreditNote.Update();

                                sSettlement_ID = clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, "default", "default", sCreditNoteID, "default", "default", -1, "default", dtmAllocationDate, dCreditNoteAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);

                                dInvSettledAmount = dCreditNoteAvailableAmount;
                            }
                        }
                        #endregion

                        //if (oCreditNote.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit))
                        //    clsMethods_GL.PostTransaction_Allocation(sSettlement_ID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dInvSettledAmount;
        }
        #endregion

        #region Insert Invoice Sattlement Record
        public static string InsertInvoiceSettlementRecord(string invoice_ID, string sJE_DR, int lineNo_JEDR, string receipt_ID, string chequeRegister_ID, string sCreditNoteID, string sDebitNoteID, string sJE_CR, int lineNo_JECR, string sPaymentMethodID, DateTime sattledDate, decimal sattledAmount, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            string sSettledID = "";
            try
            {
                sSettledID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.bssInvoiceSettlement));
                if (sSettledID.Length > 0)
                {
                    tbl_sasInvoice_Sattled detail = new tbl_sasInvoice_Sattled(sSettledID, invoice_ID, sJE_DR, lineNo_JEDR, "default", receipt_ID, "default", chequeRegister_ID, sCreditNoteID, sDebitNoteID, sJE_CR, lineNo_JECR, sPaymentMethodID, "default", sattledDate, sattledAmount, true, sattledDate, sAllocationID, bIsAdvancePayment, bIsOverPayment, clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), "default");
                    detail.Insert();
                    if (receipt_ID != "default" && invoice_ID != "default")
                    {
                        //update Receipt Invoices
                        tbl_bpsReceipt_Invoice receiptInvoice = tbl_bpsReceipt_Invoice.Select(receipt_ID, invoice_ID);
                        if (receiptInvoice == null)
                        {
                            tbl_sasInvoice objInvoice = tbl_sasInvoice.Select(invoice_ID);
                            if (objInvoice != null)
                            {
                                List<tbl_bpsReceipt_Invoice> invs = tbl_bpsReceipt_Invoice.SelectAllByReceipt_ID(receipt_ID);
                                int iLineNo = invs.Count + 1;
                                tbl_bpsReceipt_Invoice newReceiptInvoice = new tbl_bpsReceipt_Invoice(iLineNo, receipt_ID, invoice_ID, false, objInvoice.OrderRefNo_ID);
                                newReceiptInvoice.Insert();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sSettledID;
        }
        #endregion

        #region Remove APN Settlements - From PaymentVoucher ID
        public static bool RemoveAPNSattlementsFrom_PaymentVoucherID(string sPVID)
        {
            try
            {
                foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(sPVID).Where(p => p.IsSettled))
                {
                    if (detail.AccountPayableNote_ID != "default")
                    {
                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(detail.AccountPayableNote_ID);
                        if (oAPN != null && oAPN.AccountPayableNote_ID != "default")
                        {
                            oAPN.SettledAmount -= detail.SettleAmount;
                            oAPN.IsSeattled = false;
                            oAPN.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    else if (detail.CustomerRefundableNote_ID != "default")
                    {
                        tbl_bpsDebitNote oDBN = tbl_bpsDebitNote.Select(detail.CustomerRefundableNote_ID);
                        if (oDBN != null && oDBN.DebitNote_ID != "default")
                        {
                            oDBN.SeattleAmount -= detail.SettleAmount;
                            oDBN.IsSeattled = false;
                            oDBN.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }

                    #region Journal Entry
                    else if (detail.JournalEntry_ID_CR != "default" || detail.JournalEntry_ID_DR != "default")
                    {
                        List<tbl_accJournalEntry_Detail> oDetail = null;
                        if (detail.JournalEntry_ID_CR != "default")
                            oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(detail.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                        else if (detail.JournalEntry_ID_DR != "default")
                            oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(detail.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                        foreach (tbl_accJournalEntry_Detail oJE in oDetail)
                        {
                            oJE.SeattleAmount -= detail.SettleAmount;
                            oJE.IsSeattled = false;
                            oJE.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    #endregion

                }
                tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
                if (oPV != null && oPV.PaymentVoucher_ID != "default")
                {
                    oPV.SettledAmount = 0;
                    oPV.IsSeattled = false;
                    oPV.Update();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public static bool RemovePVSattlementsFrom_APNID(string sAPNID)
        {
            try
            {
                foreach (tbl_accPaymentVoucher_Detail detail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(sAPNID).Where(p => p.IsSettled))
                {
                    if (detail.PaymentVoucher_ID != "default")
                    {
                        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(detail.PaymentVoucher_ID);
                        if (oPV != null && oPV.PaymentVoucher_ID != "default")
                        {
                            oPV.SettledAmount -= detail.SettleAmount;
                            oPV.IsSeattled = false;
                            oPV.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    #region Refundable Note
                    else if (detail.CustomerRefundableNote_ID != "default")
                    {
                        tbl_bpsDebitNote oDBN = tbl_bpsDebitNote.Select(detail.CustomerRefundableNote_ID);
                        if (oDBN != null && oDBN.DebitNote_ID != "default")
                        {
                            oDBN.SeattleAmount -= detail.SettleAmount;
                            oDBN.IsSeattled = false;
                            oDBN.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    #endregion

                    #region Debit Note
                    else if (detail.DebitNote_ID != "default")
                    {
                        tbl_accDebitNote oDBN = tbl_accDebitNote.Select(detail.DebitNote_ID);
                        if (oDBN != null && oDBN.DebitNote_ID != "default")
                        {
                            oDBN.SettledAmount -= detail.SettleAmount;
                            oDBN.IsSettled = false;
                            oDBN.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    #endregion

                    #region Journal Entry
                    else if (detail.JournalEntry_ID_CR != "default" || detail.JournalEntry_ID_DR != "default")
                    {
                        List<tbl_accJournalEntry_Detail> oDetail = null;
                        if (detail.JournalEntry_ID_CR != "default")
                            oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(detail.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                        else if (detail.JournalEntry_ID_DR != "default")
                            oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(detail.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                        foreach (tbl_accJournalEntry_Detail oJE in oDetail)
                        {
                            oJE.SeattleAmount -= detail.SettleAmount;
                            oJE.IsSeattled = false;
                            oJE.Update();

                            detail.SettleAmount = 0;
                            detail.IsSettled = false;
                            detail.Update();
                        }
                    }
                    #endregion
                }
                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
                if (oAPN != null && oAPN.AccountPayableNote_ID != "default")
                {
                    oAPN.SettledAmount = 0;
                    oAPN.IsSeattled = false;
                    oAPN.Update();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        #endregion

        public static void SetVATandNBTValues_FromGrandTotal(decimal dGrandTotal, decimal dVATPasantage, decimal dNBTPasantage, ref decimal dWithNBTAmount, ref decimal dSubTotal, ref decimal dNBTAmount, ref decimal dVATAmount)
        {
            dWithNBTAmount = dGrandTotal * 100 / (100 + dVATPasantage);
            dSubTotal = dWithNBTAmount * 100 / (100 + dNBTPasantage);
            dNBTAmount = dWithNBTAmount - dSubTotal;
            dVATAmount = dGrandTotal - dWithNBTAmount;
        }

        public static void CalculateGrandTotalReverce(decimal dGrandTotal, ref decimal dVATAmount, decimal bVATRate, bool bVatEnable, ref decimal dSVATAmount, decimal bSVATRAte, bool bSVatEnable, ref decimal dNBTAmount, decimal dNBTRate, bool bNBTEnable, ref decimal dDiscountTotal, decimal dDiscRate, ref decimal dSubTotal)
        {
            dVATAmount = 0; dNBTAmount = 0;
            decimal dWithNBTAmount = 0, dwithDiscountAmount = 0;

            dGrandTotal = Math.Round(dGrandTotal, 2);
            dwithDiscountAmount = dWithNBTAmount = dSubTotal = dGrandTotal;

            if (bVatEnable)
            {
                dVATAmount = (dGrandTotal * bVATRate) / (bVATRate + 100);
                dVATAmount = Math.Round(dVATAmount, 2);
                dSubTotal = dwithDiscountAmount = dWithNBTAmount = (dGrandTotal - dVATAmount);
            }

            if (bNBTEnable)
            {
                dNBTAmount = (dWithNBTAmount * dNBTRate) / (dNBTRate + 100);
                dNBTAmount = Math.Round(dNBTAmount, 2);
                dSubTotal = dwithDiscountAmount = dWithNBTAmount - dNBTAmount;
            }


            if (bSVatEnable)
            {
                dSVATAmount = dGrandTotal * bSVATRAte / 100;
                dSVATAmount = Math.Round(dSVATAmount, 2);
            }

            if (dDiscRate > 0)
            {
                dDiscountTotal = (dwithDiscountAmount * dDiscRate) / (100 - dDiscRate);
                dDiscountTotal = Math.Round(dDiscountTotal, 2);
                dSubTotal = dwithDiscountAmount + dDiscountTotal;
            }

            dSubTotal = Math.Round(dSubTotal, 2);
        }


        #region WA Tollarance
        public static DataTable GroupByItemsInGrid_WATollarance(DataTable dtGrid)
        {
            #region Variable
            DataTable dtGroupedItemsinGrid = new DataTable();
            dtGroupedItemsinGrid.Columns.Add("LineNo");
            dtGroupedItemsinGrid.Columns.Add("ItemCode");
            dtGroupedItemsinGrid.Columns.Add("Quantity");
            dtGroupedItemsinGrid.Columns.Add("UnitPrice");
            #endregion

            DataView dvItem = new DataView(dtGrid);
            DataTable dtDistinctItem = dvItem.ToTable(true, "ItemCode");
            int iLineNo = 0;

            foreach (DataRow drGridItemRow in dtDistinctItem.Rows)
            {
                string sGridItem_ID = drGridItemRow["ItemCode"].ToString();

                decimal dWC_GridItem = 0m;
                decimal dTC_GridItem = 0m;
                decimal dTQ_GridItem = 0m;

                foreach (DataRow drDtGrid in dtGrid.Select("ItemCode = '" + sGridItem_ID + "'"))
                {
                    //string sItemCode = drDtGrid["ItemCode"].ToString();
                    decimal dQty = decimal.Parse(drDtGrid["Quantity"].ToString());
                    decimal dUnitPrice = decimal.Parse(drDtGrid["UnitPrice"].ToString());

                    dTC_GridItem += (dQty * dUnitPrice);
                    dTQ_GridItem += dQty;
                }

                if (dTQ_GridItem != 0)
                    dWC_GridItem = Math.Round((dTC_GridItem / dTQ_GridItem), clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                dtGroupedItemsinGrid.Rows.Add(++iLineNo, sGridItem_ID, dTQ_GridItem, dWC_GridItem);
            }

            return dtGroupedItemsinGrid;
        }
        public static List<tbl_Detail> GroupByItemsInDB_WATollarance(List<tbl_Detail> DB)
        {
            List<tbl_Detail> lstGroupedItemsinDB = new List<tbl_Detail>();
            int iLineNo = 0;

            var dbDistinctItem = DB.Select(c => c.Item_ID).Distinct().ToList();
            foreach (string sItem_ID in dbDistinctItem)
            {
                decimal dWC_DBItem = 0m;
                decimal dTC_DBItem = 0m;
                decimal dTQ_DBItem = 0m;

                foreach (tbl_Detail oDetail in DB.Where(r => r.Item_ID == sItem_ID))
                {
                    dTC_DBItem += (oDetail.Qty * oDetail.UnitPrice);
                    dTQ_DBItem += oDetail.Qty;
                }

                if (dTQ_DBItem != 0)
                    dWC_DBItem = Math.Round((dTC_DBItem / dTQ_DBItem), clsConfig.sCurrencyDecimalPlaces_UnitPrice);

                tbl_Detail oGroupedDetail = new tbl_Detail(++iLineNo, sItem_ID, dTQ_DBItem, dWC_DBItem);
                lstGroupedItemsinDB.Add(oGroupedDetail);
            }

            return lstGroupedItemsinDB;
        }
        public static bool CheckValidity_WATollarance(DataTable dtItemsinGrid, List<tbl_Detail> lstItemsInDB)
        {
            bool bStatus = true;
            string sMsg = "";
            DataTable dtGroupedItemsinGrid = GroupByItemsInGrid_WATollarance(dtItemsinGrid);
            List<tbl_Detail> lstGroupedItemsInDB = GroupByItemsInDB_WATollarance(lstItemsInDB);

            foreach (DataRow dr in dtGroupedItemsinGrid.Rows)
            {
                //int iLineNo = int.Parse(dr["LineNo"].ToString());

                string sItemCode = dr["ItemCode"].ToString();
                decimal dQty = decimal.Parse(dr["Quantity"].ToString());
                decimal dUnitPrice = decimal.Parse(dr["UnitPrice"].ToString());

                decimal dWAPrice = clsProcessMethods.GetItemWeightedAvarageCostPrice(sItemCode);
                decimal dFlowStockQty_Old = 0, dWeightedAverageCostPrice = 0;

                foreach (tbl_genStore_Stock stock in tbl_genStore_Stock.SelectAllByItem_ID(sItemCode))
                {
                    dFlowStockQty_Old += stock.Qty;
                }

                #region Roalback old stock
                foreach (tbl_Detail oldDetail in lstGroupedItemsInDB)
                {
                    //if (oldDetail.Line_No == iLineNo && oldDetail.Item_ID == sItemCode)
                    if (oldDetail.Item_ID == sItemCode)
                    {

                        if (dFlowStockQty_Old - oldDetail.Qty != 0)
                            dWAPrice = ((dFlowStockQty_Old * dWAPrice) - (oldDetail.Qty * oldDetail.UnitPrice)) / (dFlowStockQty_Old - oldDetail.Qty);

                        lstGroupedItemsInDB.Remove(oldDetail);
                        dFlowStockQty_Old -= oldDetail.Qty;
                        break;
                    }
                }
                #endregion

                if (dFlowStockQty_Old + dQty != 0)
                    dWeightedAverageCostPrice = ((dFlowStockQty_Old * dWAPrice) + (dQty * dUnitPrice)) / (dFlowStockQty_Old + dQty);

                if (dWAPrice != 0)
                {
                    if (Math.Abs((dWAPrice - dWeightedAverageCostPrice) / dWAPrice * 100) > clsConfig.bStockValidation_waTollarance)
                    {
                        sMsg += (sMsg != "" ? "\n" : "") + "<" + sItemCode + " | " + clsGenaralName.getName_Item(sItemCode) + " | WA =   " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice) + " >";
                        bStatus = false;
                    }
                }
                else
                {
                    sMsg += (sMsg != "" ? "\n" : "") + "<" + sItemCode + ">   " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice);
                    bStatus = false;
                }

            }

            #region Check Removed items
            foreach (tbl_Detail oldDetail in lstGroupedItemsInDB)
            {
                decimal dFlowStockQty_Old = 0, dWeightedAverageCostPrice = 0;
                decimal dWAPrice = clsProcessMethods.GetItemWeightedAvarageCostPrice(oldDetail.Item_ID);

                foreach (tbl_genStore_Stock stock in tbl_genStore_Stock.SelectAllByItem_ID(oldDetail.Item_ID))
                {
                    dFlowStockQty_Old += stock.Qty;
                }

                if (dFlowStockQty_Old - oldDetail.Qty != 0)
                    dWeightedAverageCostPrice = ((dFlowStockQty_Old * dWAPrice) - (oldDetail.Qty * oldDetail.UnitPrice)) / (dFlowStockQty_Old - oldDetail.Qty);
                if (dWAPrice != 0)
                {
                    if (Math.Abs((dWAPrice - dWeightedAverageCostPrice) / dWAPrice * 100) > clsConfig.bStockValidation_waTollarance)
                    {
                        sMsg += (sMsg != "" ? "\n" : "") + "<" + oldDetail.Item_ID + ">    " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice);
                        bStatus = false;
                    }
                }
                else
                {
                    sMsg += (sMsg != "" ? "\n" : "") + "<" + oldDetail.Item_ID + ">    " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice);
                    bStatus = false;
                }
            }
            #endregion
            if (!bStatus)
            {
                DialogResult msgResult = MessageBox.Show("After save this transaction weighted average price for following items getting unrealistic amounts\n" + sMsg + "\n\nDo you want to proceed...?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgResult == DialogResult.Yes)
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }
        #endregion

        //Cancel Validation Message
        public static bool CheckCancelValidity_WATollarance(List<tbl_Detail> lstItemsInDB)
        {
            bool bStatus = true;
            string sMsg = "";

            List<tbl_Detail> lstGroupedItemsInDB = GroupByItemsInDB_WATollarance(lstItemsInDB);

            #region Check Removed items
            foreach (tbl_Detail oldDetail in lstGroupedItemsInDB)
            {
                decimal dFlowStockQty_Old = 0, dWeightedAverageCostPrice = 0;
                decimal dWAPrice = clsProcessMethods.GetItemWeightedAvarageCostPrice(oldDetail.Item_ID);

                foreach (tbl_genStore_Stock stock in tbl_genStore_Stock.SelectAllByItem_ID(oldDetail.Item_ID))
                {
                    dFlowStockQty_Old += stock.Qty;
                }

                if (dFlowStockQty_Old - oldDetail.Qty != 0)
                    dWeightedAverageCostPrice = ((dFlowStockQty_Old * dWAPrice) - (oldDetail.Qty * oldDetail.UnitPrice)) / (dFlowStockQty_Old - oldDetail.Qty);
                if (dWAPrice != 0)
                {
                    if (Math.Abs((dWAPrice - dWeightedAverageCostPrice) / dWAPrice * 100) > clsConfig.bStockValidation_waTollarance)
                    {
                        sMsg += (sMsg != "" ? "\n" : "") + "<" + oldDetail.Item_ID + ">    " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice);
                        bStatus = false;
                    }
                }
                else
                {
                    sMsg += (sMsg != "" ? "\n" : "") + "<" + oldDetail.Item_ID + ">    " + clsFormatter.FormatDecimalPlaces_Price(dWeightedAverageCostPrice);
                    bStatus = false;
                }
            }
            #endregion


            if (!bStatus)
            {
                DialogResult msgResult = MessageBox.Show("After Cancel this transaction weighted average price for following items getting unrealistic amounts\n" + sMsg + "\n\nDo you want to proceed...?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgResult == DialogResult.Yes)
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }

        //public static void Update_Inventory(tbl_scsInventoryTxnHeader oHeader, List<tbl_scsInventoryTxnDetail> oListDetail)
        //{
        //    tbl_scsInventoryTxnHeader oOldDetail = tbl_scsInventoryTxnHeader.Select(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID);
        //    if (oOldDetail != null)
        //    {
        //        tbl_scsInventoryTxnHeader oInventoryHeader = new tbl_scsInventoryTxnHeader(oOldDetail.TxnType, oOldDetail.TxnIndex, oOldDetail.TxnID, oHeader.TxnDate, oHeader.Remarks,
        //            oHeader.Customer_ID, oHeader.Supplier_ID, oHeader.SalesNoteType_ID, oHeader.Route_ID,
        //            oHeader.TotalAmount, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", oHeader.IsDeleted, clsSecurity.UserIDLoged);
        //        oInventoryHeader.Update();

        //        tbl_scsInventoryTxnDetail.DeleteAllByTxnType_TxnIndex_TxnID(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID);
        //    }
        //    else
        //    {
        //        tbl_scsInventoryTxnHeader oInventoryHeader = new tbl_scsInventoryTxnHeader(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID, oHeader.TxnDate, oHeader.Remarks,
        //            oHeader.Customer_ID, oHeader.Supplier_ID, oHeader.SalesNoteType_ID, oHeader.Route_ID,
        //            oHeader.TotalAmount, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", oHeader.IsDeleted, clsSecurity.UserIDLoged);
        //        oInventoryHeader.Insert();
        //    }

        //    foreach (tbl_scsInventoryTxnDetail oDetail in oListDetail)
        //    {
        //        tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(oDetail.TxnType, oDetail.Line_No, oDetail.TxnIndex, oDetail.TxnID, oDetail.TxnDate,
        //            clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default",
        //            oDetail.Customer_ID, oDetail.Supplier_ID, oDetail.Store_ID, oDetail.Item_ID, oDetail.Uom_ID, oDetail.ReceivedQty, oDetail.IssuedQty, oDetail.UnitPrice, oDetail.WeightedAvgPrice, oDetail.IsDeleted);
        //        oInventoryDetail.Insert();
        //    }
        //}

        //public static void Delete_Inventory(int iTxnType, int iTxnIndex, string sTxnID)
        //{
        //    tbl_scsInventoryTxnHeader oOldDetail = tbl_scsInventoryTxnHeader.Select(iTxnType, iTxnIndex, sTxnID);
        //    if (oOldDetail != null)
        //    {
        //        oOldDetail.IsDeleted = true;
        //        oOldDetail.Update();

        //        List<tbl_scsInventoryTxnDetail> oDetailList = tbl_scsInventoryTxnDetail.SelectAllByTxnType_TxnIndex_TxnID(iTxnType, iTxnIndex, sTxnID);
        //        foreach (tbl_scsInventoryTxnDetail oDetail in oDetailList)
        //        {
        //            oDetail.IsDeleted = true;
        //            oDetail.Update();
        //        }
        //    }
        //}

        public static void Update_Inventory_Summary(string sCompany_ID, string sCompanyBranch_ID, string sStore_ID, string sItem_ID, DateTime dtmTx_Date, decimal dQty)
        {
            DBHandling.ExecQuery("Exec sp_update_inventory_summary '" + sCompany_ID + "' , '" + sCompanyBranch_ID + "', '" + dtmTx_Date.Date.ToString("YYYY-MM-DD") + "', '" + sStore_ID + "', '" + sItem_ID + "', '" + dQty + "' ");
        }

        //public static void Calculate_OpeningAndClosingStock()
        //{
        //    foreach (tbl_accFinancialYearMaster_Month oFinMonth in tbl_accFinancialYearMaster_Month.SelectAll())
        //    {

        //    }
        //}

        #region Calculate Taxes And GrandTotal
        public static decimal CalculateGrandTotal_WithMultiplediscount(Label txtSubTotal, TextBox txtDiscount, TextBox txtDiscountRate, CheckBox chkDiscount, TextBox txtDiscount1, TextBox txtDiscountRate1, CheckBox chkDiscount1, TextBox txtDiscount2, TextBox txtDiscountRate2, CheckBox chkDiscount2, TextBox txtDiscount3, TextBox txtDiscountRate3, CheckBox chkDiscount3, TextBox txtNbt, TextBox txtNbtRate, CheckBox chkNbt, TextBox txtVat, TextBox txtVatRate, CheckBox chkVat, TextBox txtOtherTax, TextBox txtOtherTaxRate, CheckBox chkOtherTax, ref decimal dTotalDiscount, ref decimal dTotalDiscountPresent)
        {
            decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dDiscount = 0, dDicountRate = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0,
             dDicountRate1 = 0, dDiscount1 = 0, dDicountRate2 = 0, dDiscount2 = 0, dDicountRate3 = 0, dDiscount3 = 0;

            if (txtSubTotal.Tag != null && txtSubTotal.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Tag.ToString().Trim()))
                dSubTotal = (dSubTotalRunning = decimal.Parse(txtSubTotal.Tag.ToString().Trim()));
            dSubTotal = Math.Round(dSubTotal, 2);

            #region Discount
            if (chkDiscount.Checked)
            {
                if (txtDiscountRate.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate.Text.Trim()))
                    dDicountRate = decimal.Parse(txtDiscountRate.Text.Trim());
                if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount.Tag.ToString().Trim()))
                    dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

                if (dDicountRate > 0)
                    dDiscount = ((dSubTotalRunning * dDicountRate) / 100);
                dDiscount = Math.Round(dDiscount, 2);

                if (dSubTotalRunning > 0 && dDiscount > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount);
            }
            txtDiscount.Tag = dDiscount;
            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount);
            dTotalDiscount += dDiscount;

            if (chkDiscount1.Checked)
            {
                if (txtDiscountRate1.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate1.Text.Trim()))
                    dDicountRate1 = decimal.Parse(txtDiscountRate1.Text.ToString());
                if (txtDiscount1.Tag != null && txtDiscount1.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount1.Tag.ToString().Trim()))
                    dDiscount1 = decimal.Parse(txtDiscount1.Tag.ToString().Trim());

                if (dDicountRate1 > 0)
                    dDiscount1 = ((dSubTotalRunning * dDicountRate1) / 100);
                dDiscount1 = Math.Round(dDiscount1, 2);

                if (dSubTotalRunning > 0 && dDiscount1 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount1);
            }
            txtDiscount1.Tag = dDiscount1;
            txtDiscount1.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount1);
            dTotalDiscount += dDiscount1;
            if (chkDiscount2.Checked)
            {
                if (txtDiscountRate2.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate2.Text.Trim()))
                    dDicountRate2 = decimal.Parse(txtDiscountRate2.Text.ToString());
                if (txtDiscount2.Tag != null && txtDiscount2.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount2.Tag.ToString().Trim()))
                    dDiscount2 = decimal.Parse(txtDiscount2.Tag.ToString().Trim());

                if (dDicountRate2 > 0)
                    dDiscount2 = ((dSubTotalRunning * dDicountRate2) / 100);
                dDiscount2 = Math.Round(dDiscount2, 2);

                if (dSubTotalRunning > 0 && dDiscount2 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount2);
            }
            txtDiscount2.Tag = dDiscount2;
            txtDiscount2.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount2);
            dTotalDiscount += dDiscount2;
            if (chkDiscount3.Checked)
            {
                if (txtDiscountRate3.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate3.Text.Trim()))
                    dDicountRate3 = decimal.Parse(txtDiscountRate3.Text.ToString());
                if (txtDiscount3.Tag != null && txtDiscount3.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount3.Tag.ToString().Trim()))
                    dDiscount3 = decimal.Parse(txtDiscount3.Tag.ToString().Trim());
                dDiscount3 = Math.Round(dDiscount3, 2);

                if (dDicountRate3 > 0)
                    dDiscount3 = ((dSubTotalRunning * dDicountRate3) / 100);

                if (dSubTotalRunning > 0 && dDiscount3 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount3);
            }
            txtDiscount3.Tag = dDiscount3;
            txtDiscount3.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount3);
            dTotalDiscount += dDiscount3;
            if (dSubTotal > 0)
                dTotalDiscountPresent = dTotalDiscount / dSubTotal * 100;

            //else if (chkMultipleDiscount.Checked)
            //{
            //    if (txtDiscountRate.Tag.ToString().Length > 0 && clsCommon.isCurrency(txtDiscountRate.Tag.ToString().Trim()))
            //        dDicountRate = decimal.Parse(txtDiscountRate.Tag.ToString().Trim());
            //    if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount.Tag.ToString().Trim()))
            //        dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

            //    if (dDicountRate > 0)
            //        dDiscount = ((dSubTotalRunning * dDicountRate) / 100);

            //    if (dSubTotalRunning > 0 && dDiscount > 0)
            //        dSubTotalRunning = (dSubTotalRunning - dDiscount);
            //}
            //Assign Values


            #endregion

            #region NBT
            if (chkNbt.Checked)
            {
                if (txtNbtRate.TextLength > 0 && clsCommon.isCurrency(txtNbtRate.Text.Trim()))
                    dNbtRate = decimal.Parse(txtNbtRate.Text.Trim());

                if (dNbtRate > 0)
                    dNbt = ((dSubTotalRunning * dNbtRate) / 100);
                dNbt = Math.Round(dNbt, 2);

                if (dSubTotalRunning > 0 && dNbt > 0)
                    dSubTotalRunning = (dSubTotalRunning + dNbt);
            }

            txtNbt.Tag = dNbt;
            txtNbt.Text = clsFormatter.FormatToCurrecyWithThousendSep(dNbt);
            #endregion

            #region VAT
            if (chkVat.Checked)
            {
                if (txtVatRate.TextLength > 0 && clsCommon.isCurrency(txtVatRate.Text.Trim()))
                    dVatRate = decimal.Parse(txtVatRate.Text.Trim());

                if (dVatRate > 0)
                    dVat = ((dSubTotalRunning * dVatRate) / 100);
                dVat = Math.Round(dVat, 2);

                if (dSubTotalRunning > 0 && dVat > 0)
                    dSubTotalRunning = (dSubTotalRunning + dVat);
            }
            txtVat.Tag = dVat;
            txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dVat);
            #endregion

            #region Other Tax
            if (chkOtherTax.Checked)
            {
                if (txtOtherTaxRate.TextLength > 0 && clsCommon.isCurrency(txtOtherTaxRate.Text.Trim()))
                    dOtherTaxRate = decimal.Parse(txtOtherTaxRate.Text.Trim());


                if (dOtherTaxRate > 0)
                    dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);
                dOtherTax = Math.Round(dOtherTax, 2);
                //if (dSubTotalRunning > 0 && dOtherTax > 0)
                //{
                //    dSubTotalRunning = (dSubTotalRunning + dOtherTax);
                //}

                //Assign Values
                txtOtherTax.Tag = dOtherTax;
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTax);
            }
            txtOtherTax.Tag = dOtherTax;
            txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTax);
            #endregion

            #region Grand Total
            dGrandTotal = (dSubTotalRunning);
            #endregion

            return dGrandTotal;
        }

        public static decimal CalculateGrandTotal_WithMultiplediscount(TextBox txtSubTotal, TextBox txtDiscount, TextBox txtDiscountRate, CheckBox chkDiscount, TextBox txtDiscount1, TextBox txtDiscountRate1, CheckBox chkDiscount1, TextBox txtDiscount2, TextBox txtDiscountRate2, CheckBox chkDiscount2, TextBox txtDiscount3, TextBox txtDiscountRate3, CheckBox chkDiscount3, TextBox txtNbt, TextBox txtNbtRate, CheckBox chkNbt, TextBox txtVat, TextBox txtVatRate, CheckBox chkVat, TextBox txtOtherTax, TextBox txtOtherTaxRate, CheckBox chkOtherTax, ref decimal dTotalDiscount, ref decimal dTotalDiscountPresent)
        {
            decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dDiscount = 0, dDicountRate = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0,
             dDicountRate1 = 0, dDiscount1 = 0, dDicountRate2 = 0, dDiscount2 = 0, dDicountRate3 = 0, dDiscount3 = 0;

            if (txtSubTotal.Tag != null && txtSubTotal.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Tag.ToString().Trim()))
                dSubTotal = (dSubTotalRunning = decimal.Parse(txtSubTotal.Tag.ToString().Trim()));
            dSubTotal = Math.Round(dSubTotal, 2);

            #region Discount
            if (chkDiscount.Checked)
            {
                if (txtDiscountRate.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate.Text.Trim()))
                    dDicountRate = decimal.Parse(txtDiscountRate.Text.Trim());
                if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount.Tag.ToString().Trim()))
                    dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

                if (dDicountRate > 0)
                    dDiscount = ((dSubTotalRunning * dDicountRate) / 100);
                dDiscount = Math.Round(dDiscount, 2);

                if (dSubTotalRunning > 0 && dDiscount > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount);
            }
            txtDiscount.Tag = dDiscount;
            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount);
            dTotalDiscount += dDiscount;

            if (chkDiscount1.Checked)
            {
                if (txtDiscountRate1.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate1.Text.Trim()))
                    dDicountRate1 = decimal.Parse(txtDiscountRate1.Text.ToString());
                if (txtDiscount1.Tag != null && txtDiscount1.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount1.Tag.ToString().Trim()))
                    dDiscount1 = decimal.Parse(txtDiscount1.Tag.ToString().Trim());

                if (dDicountRate1 > 0)
                    dDiscount1 = ((dSubTotalRunning * dDicountRate1) / 100);
                dDiscount1 = Math.Round(dDiscount1, 2);

                if (dSubTotalRunning > 0 && dDiscount1 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount1);
            }
            txtDiscount1.Tag = dDiscount1;
            txtDiscount1.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount1);
            dTotalDiscount += dDiscount1;
            if (chkDiscount2.Checked)
            {
                if (txtDiscountRate2.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate2.Text.Trim()))
                    dDicountRate2 = decimal.Parse(txtDiscountRate2.Text.ToString());
                if (txtDiscount2.Tag != null && txtDiscount2.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount2.Tag.ToString().Trim()))
                    dDiscount2 = decimal.Parse(txtDiscount2.Tag.ToString().Trim());

                if (dDicountRate2 > 0)
                    dDiscount2 = ((dSubTotalRunning * dDicountRate2) / 100);
                dDiscount2 = Math.Round(dDiscount2, 2);

                if (dSubTotalRunning > 0 && dDiscount2 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount2);
            }
            txtDiscount2.Tag = dDiscount2;
            txtDiscount2.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount2);
            dTotalDiscount += dDiscount2;
            if (chkDiscount3.Checked)
            {
                if (txtDiscountRate3.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate3.Text.Trim()))
                    dDicountRate3 = decimal.Parse(txtDiscountRate3.Text.ToString());
                if (txtDiscount3.Tag != null && txtDiscount3.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount3.Tag.ToString().Trim()))
                    dDiscount3 = decimal.Parse(txtDiscount3.Tag.ToString().Trim());
                dDiscount3 = Math.Round(dDiscount3, 2);

                if (dDicountRate3 > 0)
                    dDiscount3 = ((dSubTotalRunning * dDicountRate3) / 100);

                if (dSubTotalRunning > 0 && dDiscount3 > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount3);
            }
            txtDiscount3.Tag = dDiscount3;
            txtDiscount3.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount3);
            dTotalDiscount += dDiscount3;
            if (dSubTotal > 0)
                dTotalDiscountPresent = dTotalDiscount / dSubTotal * 100;

            //else if (chkMultipleDiscount.Checked)
            //{
            //    if (txtDiscountRate.Tag.ToString().Length > 0 && clsCommon.isCurrency(txtDiscountRate.Tag.ToString().Trim()))
            //        dDicountRate = decimal.Parse(txtDiscountRate.Tag.ToString().Trim());
            //    if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount.Tag.ToString().Trim()))
            //        dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

            //    if (dDicountRate > 0)
            //        dDiscount = ((dSubTotalRunning * dDicountRate) / 100);

            //    if (dSubTotalRunning > 0 && dDiscount > 0)
            //        dSubTotalRunning = (dSubTotalRunning - dDiscount);
            //}
            //Assign Values


            #endregion

            #region NBT
            if (chkNbt.Checked)
            {
                if (txtNbtRate.TextLength > 0 && clsCommon.isCurrency(txtNbtRate.Text.Trim()))
                    dNbtRate = decimal.Parse(txtNbtRate.Text.Trim());

                if (dNbtRate > 0)
                    dNbt = ((dSubTotalRunning * dNbtRate) / 100);
                dNbt = Math.Round(dNbt, 2);

                if (dSubTotalRunning > 0 && dNbt > 0)
                    dSubTotalRunning = (dSubTotalRunning + dNbt);
            }

            txtNbt.Tag = dNbt;
            txtNbt.Text = clsFormatter.FormatToCurrecyWithThousendSep(dNbt);
            #endregion

            #region VAT
            if (chkVat.Checked)
            {
                if (txtVatRate.TextLength > 0 && clsCommon.isCurrency(txtVatRate.Text.Trim()))
                    dVatRate = decimal.Parse(txtVatRate.Text.Trim());

                if (dVatRate > 0)
                    dVat = ((dSubTotalRunning * dVatRate) / 100);
                dVat = Math.Round(dVat, 2);

                if (dSubTotalRunning > 0 && dVat > 0)
                    dSubTotalRunning = (dSubTotalRunning + dVat);
            }
            txtVat.Tag = dVat;
            txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dVat);
            #endregion

            #region Other Tax
            if (chkOtherTax.Checked)
            {
                if (txtOtherTaxRate.TextLength > 0 && clsCommon.isCurrency(txtOtherTaxRate.Text.Trim()))
                    dOtherTaxRate = decimal.Parse(txtOtherTaxRate.Text.Trim());


                if (dOtherTaxRate > 0)
                    dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);
                dOtherTax = Math.Round(dOtherTax, 2);
                //if (dSubTotalRunning > 0 && dOtherTax > 0)
                //{
                //    dSubTotalRunning = (dSubTotalRunning + dOtherTax);
                //}

                //Assign Values
                txtOtherTax.Tag = dOtherTax;
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTax);
            }
            txtOtherTax.Tag = dOtherTax;
            txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTax);
            #endregion

            #region Grand Total
            dGrandTotal = (dSubTotalRunning);
            #endregion

            return dGrandTotal;
        }

        public static decimal CalculateGrandTotalAdvance_Round(TextBox txtSubTotal, TextBox txtDiscount, TextBox txtDiscountRate, CheckBox chkDiscount, TextBox txtNbt, TextBox txtNbtRate, CheckBox chkNbt, TextBox txtVat, TextBox txtVatRate, CheckBox chkVat, TextBox txtOtherTax, TextBox txtOtherTaxRate, CheckBox chkOtherTax)
        {
            decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dDiscount = 0, dDicountRate = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0;

            //Assign SubTotal
            if (txtSubTotal.Tag != null && txtSubTotal.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtSubTotal.Tag.ToString().Trim()))
                dSubTotal = dSubTotalRunning = clsFormatter.RoundDecimalPlaces(decimal.Parse(txtSubTotal.Text.Trim()));

            //Discount Calculation
            #region Discount
            if (chkDiscount.Checked)
            {
                if (txtDiscountRate.TextLength > 0 && clsCommon.isCurrency(txtDiscountRate.Text.Trim()))
                    dDicountRate = decimal.Parse(txtDiscountRate.Text.Trim());
                if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && clsCommon.isCurrency(txtDiscount.Tag.ToString().Trim()))
                    dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

                if (dDicountRate > 0)
                    dDiscount = ((dSubTotalRunning * dDicountRate) / 100);

                dDiscount = clsFormatter.RoundDecimalPlaces(dDiscount);

                if (dSubTotalRunning > 0 && dDiscount > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount);
            }
            //Assign Values
            txtDiscount.Tag = dDiscount;
            txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount);

            #endregion

            //NBT Calculation
            #region NBT
            if (chkNbt.Checked)
            {
                if (txtNbtRate.TextLength > 0 && clsCommon.isCurrency(txtNbtRate.Text.Trim()))
                    dNbtRate = decimal.Parse(txtNbtRate.Text.Trim());

                if (dNbtRate > 0)
                    dNbt = ((dSubTotalRunning * dNbtRate) / 100);

                dNbt = clsFormatter.RoundDecimalPlaces(dNbt);

                if (dSubTotalRunning > 0 && dNbt > 0)
                    dSubTotalRunning = (dSubTotalRunning + dNbt);
            }
            //Assign Values
            txtNbt.Tag = dNbt;
            txtNbt.Text = clsFormatter.FormatToCurrecyWithThousendSep(dNbt);
            #endregion

            //VAT Calculation
            #region VAT
            if (chkVat.Checked)
            {
                if (txtVatRate.TextLength > 0 && clsCommon.isCurrency(txtVatRate.Text.Trim()))
                    dVatRate = decimal.Parse(txtVatRate.Text.Trim());

                if (dVatRate > 0)
                    dVat = ((dSubTotalRunning * dVatRate) / 100);

                dVat = clsFormatter.RoundDecimalPlaces(dVat);

                if (dSubTotalRunning > 0 && dVat > 0)
                    dSubTotalRunning = (dSubTotalRunning + dVat);
            }
            //Assign Values
            txtVat.Tag = dVat;
            txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dVat);
            #endregion

            //Other Tax Calculation
            #region Other Tax
            if (chkOtherTax.Checked)
            {
                if (txtOtherTaxRate.TextLength > 0 && clsCommon.isCurrency(txtOtherTaxRate.Text.Trim()))
                    dOtherTaxRate = decimal.Parse(txtOtherTaxRate.Text.Trim());

                if (dOtherTaxRate > 0)
                    dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);

                dOtherTax = clsFormatter.RoundDecimalPlaces(dOtherTax);
            }
            //Assign Values
            txtOtherTax.Tag = dOtherTax;
            txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTax);
            #endregion

            //Calculate Grand Total
            #region Grand Total
            dGrandTotal = (dSubTotal - dDiscount + dNbt + dVat);
            #endregion

            return dGrandTotal;
        }

        public static decimal CalculateGrandTotalAdvance_Round1(ref decimal dSubTotal, ref decimal dDiscount, decimal dDicountRate, bool chkDiscount, ref decimal dNbt, decimal dNbtRate, bool chkNbt, ref decimal dVat, decimal dVatRate, bool chkVat, ref decimal dOtherTax, decimal dOtherTaxRate, bool chkOtherTax)
        {
            decimal dGrandTotal = 0, dSubTotalRunning = 0;
            dSubTotal = dSubTotalRunning = clsFormatter.RoundDecimalPlaces(dSubTotal);

            #region Discount
            if (chkDiscount)
            {
                if (dDicountRate > 0)
                    dDiscount = ((dSubTotalRunning * dDicountRate) / 100);

                dDiscount = clsFormatter.RoundDecimalPlaces(dDiscount);

                if (dSubTotalRunning > 0 && dDiscount > 0)
                    dSubTotalRunning = (dSubTotalRunning - dDiscount);
            }
            #endregion

            #region NBT
            if (chkNbt)
            {
                if (dNbtRate > 0)
                    dNbt = ((dSubTotalRunning * dNbtRate) / 100);

                dNbt = clsFormatter.RoundDecimalPlaces(dNbt);

                if (dSubTotalRunning > 0 && dNbt > 0)
                    dSubTotalRunning = (dSubTotalRunning + dNbt);
            }
            #endregion

            #region VAT
            if (chkVat)
            {
                if (dVatRate > 0)
                    dVat = ((dSubTotalRunning * dVatRate) / 100);

                dVat = clsFormatter.RoundDecimalPlaces(dVat);

                if (dSubTotalRunning > 0 && dVat > 0)
                    dSubTotalRunning = (dSubTotalRunning + dVat);
            }
            #endregion

            #region Other Tax
            if (chkOtherTax)
            {
                if (dOtherTaxRate > 0)
                    dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);

                dOtherTax = clsFormatter.RoundDecimalPlaces(dOtherTax);
            }
            #endregion

            #region Grand Total
            dGrandTotal = (dSubTotal - dDiscount + dNbt + dVat);
            #endregion

            return dGrandTotal;
        }

        public static void CalculateGrandTotalReverce(Label lblGrandTotal, ref Label lblVat, Label lblVatRate, CheckBox chkVat, ref Label lblOtherTax, Label lblOtherTaxRate, CheckBox chkOtherTax, ref Label lblNbt, Label lblNbtRate, CheckBox chkNbt, ref Label lblSubTotal)
        {
            decimal dGrandTotal = 0, dWithNBTAmount = 0, dVATRate = 0, dVATAmount = 0, dNBTRate = 0, dNBTAmount = 0, dSubTotal = 0, dSVATAmount = 0, dSVATRAte = 0;

            if (lblGrandTotal.Tag.ToString().Length > 0 && clsCommon.isCurrency(lblGrandTotal.Tag.ToString().Trim()))
            {
                dGrandTotal = decimal.Parse(lblGrandTotal.Tag.ToString().Trim());
                dGrandTotal = Math.Round(dGrandTotal, 2);
                dWithNBTAmount = dSubTotal = dGrandTotal;
            }
            if (lblVatRate.Text.Length > 0 && clsCommon.isCurrency(lblVatRate.Text.Trim()))
                dVATRate = decimal.Parse(lblVatRate.Text.Trim());

            if (lblOtherTaxRate.Text.Length > 0 && clsCommon.isCurrency(lblOtherTaxRate.Text.Trim()))
                dSVATRAte = decimal.Parse(lblOtherTaxRate.Text.Trim());

            if (lblNbtRate.Text.Length > 0 && clsCommon.isCurrency(lblNbtRate.Text.Trim()))
                dNBTRate = decimal.Parse(lblNbtRate.Text.Trim());


            if (chkVat.Checked)
            {
                dVATAmount = (dGrandTotal * dVATRate) / (dVATRate + 100);
                dVATAmount = Math.Round(dVATAmount, 2);
                dSubTotal = dWithNBTAmount = dGrandTotal - dVATAmount;
            }

            if (chkNbt.Checked)
            {
                dNBTAmount = (dWithNBTAmount * dNBTRate) / (dNBTRate + 100);
                dNBTAmount = Math.Round(dNBTAmount, 2);
                dSubTotal = dWithNBTAmount - dNBTAmount;
            }

            if (chkOtherTax.Checked)
            {
                dSVATAmount = (dGrandTotal * dSVATRAte) / (dSVATRAte + 100);
                // dSVATAmount = dWithNBTAmount - dSVATAmount;
            }

            lblGrandTotal.Tag = dGrandTotal;
            lblVat.Tag = dVATAmount;
            lblNbt.Tag = dNBTAmount;
            lblOtherTax.Tag = dSVATAmount;
            lblSubTotal.Tag = dSubTotal;

            lblGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dGrandTotal);
            lblVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(dVATAmount);
            lblNbt.Text = clsFormatter.FormatToCurrecyWithThousendSep(dNBTAmount);
            lblOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(dSVATAmount);
            lblSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dSubTotal);
        }


        //public static void CalculateGrandTotalForCustomerOrder(ref decimal dSubTotal, decimal dDiscountRate, ref decimal dDiscount, decimal dNbtRate, ref decimal dNbt, decimal dVatRate, ref decimal dVat, ref decimal dOtherTax, ref decimal dGrandTotal, string sCustomerOrderID)
        //{
        //    tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCustomerOrderID);
        //    if (detail != null)
        //    {
        //        //Assign SubTotal
        //        decimal dSubTotalRunning = dSubTotal;

        //        //Discount Calculation
        //        if (detail.DiscountTotal > 0 && dDiscountRate > 0)
        //        {
        //            dDiscount = ((dSubTotalRunning * dDiscountRate) / 100);

        //            if (dSubTotalRunning > 0 && dDiscount > 0)
        //            {
        //                dSubTotalRunning = (dSubTotalRunning - dDiscount);
        //            }
        //        }

        //        //NBT Calculation          
        //        if (detail.NbtTotal > 0 && dNbtRate > 0)
        //        {
        //            dNbt = ((dSubTotalRunning * dNbtRate) / 100);

        //            if (dSubTotalRunning > 0 && dNbt > 0)
        //            {
        //                dSubTotalRunning = (dSubTotalRunning + dNbt);
        //            }
        //        }

        //        //VAT Calculation           
        //        if (detail.VatTotal > 0 && dVatRate > 0)
        //        {
        //            dVat = ((dSubTotalRunning * dVatRate) / 100);

        //            if (dSubTotalRunning > 0 && dVat > 0)
        //            {
        //                dSubTotalRunning = (dSubTotalRunning + dVat);
        //            }
        //        }

        //        //Other Tax Calculation           
        //        if (detail.OtherTaxTotal > 0 && dOtherTax > 0)
        //        {
        //            dOtherTax = ((dSubTotalRunning * dOtherTax) / 100);

        //            //if (dSubTotalRunning > 0 && dOtherTax > 0)
        //            //{
        //            //    dSubTotalRunning = (dSubTotalRunning + dOtherTax);
        //            //}
        //        }

        //        //Calculate Grand Total          
        //        dGrandTotal = (dSubTotal - dDiscount + dNbt + dVat);
        //    }
        //}

        public static bool isTaxActiveNote(TextBox txtTax)
        {
            bool bIsTaxActive = false;
            if (txtTax.Text.Trim().Length > 0 && clsCommon.isCurrency(txtTax.Text.Trim()))
            {
                if (decimal.Parse(txtTax.Text.Trim()) > 0)
                    bIsTaxActive = true;
            }
            return bIsTaxActive;
        }

        public static bool isTaxActiveNote(Label txtTax)
        {
            bool bIsTaxActive = false;
            if (txtTax.Text.Trim().Length > 0 && clsCommon.isCurrency(txtTax.Text.Trim()))
            {
                if (decimal.Parse(txtTax.Text.Trim()) > 0)
                    bIsTaxActive = true;
            }
            return bIsTaxActive;
        }


        //public static bool isTaxActiveNote(TextBox txtTax1, TextBox txtTax2)
        //{
        //    bool bIsTaxActive = false;
        //    if (txtTax1.Text.Trim().Length > 0 && clsCommon.isCurrency(txtTax1.Text.Trim()))
        //    {
        //        if (decimal.Parse(txtTax1.Text.Trim()) > 0)
        //            bIsTaxActive = true;
        //    }
        //    if (txtTax2.Text.Trim().Length > 0 && clsCommon.isCurrency(txtTax2.Text.Trim()))
        //    {
        //        if (decimal.Parse(txtTax2.Text.Trim()) > 0)
        //            bIsTaxActive = true;
        //    }
        //    return bIsTaxActive;
        //}
        #endregion

        #region Get Reverse Weighted Average Cost Price
        //public static decimal GetReverseWeightedAverageCostPrice(string sItemCode, decimal dUnitPrice, decimal dGRNqty, string sSubCategogry1, string sSubCategogry2, string sSerial1, string sSerial2)
        //{
        //    decimal dRtn = dUnitPrice;
        //    decimal dGrandQtyStock = 0;
        //    List<tbl_genStore_Stock> Stocks = tbl_genStore_Stock.SelectAllByItem_ID(sItemCode);
        //    foreach (tbl_genStore_Stock Stock in Stocks)
        //    {
        //        if (Stock.Item_ID == sItemCode && Stock.ItemSubCategory_ID == sSubCategogry1 && Stock.ItemSubCategory2_ID == sSubCategogry2 && Stock.ItemSerialNo == sSerial1 && Stock.ItemSerialNo2 == sSerial2)
        //            dGrandQtyStock += Stock.Qty;
        //    }
        //    if (dGrandQtyStock > 0)
        //    {
        //        tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(sItemCode, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
        //        if (item != null)
        //        {
        //            if ((dGrandQtyStock - dGRNqty) > 0)
        //                dRtn = ((dGrandQtyStock * item.WeightedAverageCostPrice) - (dGRNqty * dUnitPrice)) / (dGrandQtyStock - dGRNqty);
        //            else
        //                dRtn = 0;
        //        }
        //    }

        //    return dRtn;
        //}
        #endregion

        #region GL Line No
        public static int GetMaxzimumLineNoSubGL(string sCode)
        {
            int iMaxNo = 0;
            foreach (tbl_zAccGLMaster_SubCatagory detail in tbl_zAccGLMaster_SubCatagory.SelectAllByGlMainCatagory_ID(sCode).Where(p => p.GlSubCatagory_ID != "default" && p.Line_No > iMaxNo))
            {
                iMaxNo = detail.Line_No;
            }
            return iMaxNo;
        }
        public static int GetMaxzimumLineNoAcctType(string sCode)
        {
            int iMaxNo = 0;
            foreach (tbl_zAccGLMaster_AccountType detail in tbl_zAccGLMaster_AccountType.SelectAllByGlSubCatagory_ID(sCode).Where(p => p.GlAccountType_ID != "default" && p.Line_No > iMaxNo))
            {
                iMaxNo = detail.Line_No;
            }
            return iMaxNo;
        }
        public static int GetMaxzimumLineNoAcctCode(string sCode)
        {
            int iMaxNo = 0;
            foreach (tbl_accGLMaster detail in tbl_accGLMaster.SelectAllByGlAccountType_ID(sCode).Where(p => !p.IsDeleted && p.Gl_ID != "default" && p.Line_No > iMaxNo))
            {
                iMaxNo = detail.Line_No;
            }
            return iMaxNo;
        }
        public static int GetMaxzimumLineNoCurrencyMasterHistory(string sCode)
        {
            int iMaxNo = 0;
            foreach (tbl_zCurrency_History detail in tbl_zCurrency_History.SelectAllByCurrency_ID(sCode).Where(p => p.Currency_ID != "default"))
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
                else
                {
                    iMaxNo = detail.Line_No + 1;
                }
            }
            return iMaxNo;
        }
        public static int GetMaximumLineNo_ProductionPlanJob(string sProductionPlanID)
        {
            int iMaxNo = 1;
            //foreach (tbl_proProductionPlan_Job detail in tbl_proProductionPlan_Job.SelectAllByProductionPlan_ID(sProductionPlanID).Where(p => p.ProductionJob_ID != "default" && p.Line_No >= iMaxNo))
            //{
            //    iMaxNo = detail.Line_No + 1;
            //}
            return iMaxNo;
        }
        #endregion

        #region GL Line No

        public static int GetMaximumLineNoGLMaster(string main, string sub, string account)
        {
            int iMaxNo = 1;
            foreach (tbl_accGLMaster detail in tbl_accGLMaster.SelectAllByGlAccountType_ID(account).Where(p => !p.IsDeleted && p.Gl_ID != "default" && p.Line_No >= iMaxNo))
            {
                iMaxNo = detail.Line_No + 1;
            }
            return iMaxNo;
        }
        #endregion

        #region Get UnitPrice
        public static decimal GetUnitPrice(decimal dWidth, decimal dLength, decimal dGauge, decimal dGussest, decimal dKiloPrice, string sUomID)
        {
            decimal dUnitPrice = 0;
            try
            {
                if (clsHelpMethods.IsUomCalculationBag(sUomID))
                    dUnitPrice = (((dWidth * dLength * dGauge * dGussest) / 3300) * dKiloPrice) / 1000;
                else if (clsHelpMethods.IsUomCalculationKilogram(sUomID))
                    dUnitPrice = dKiloPrice;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dUnitPrice;
        }
        #endregion

        #region Get Kilo Price
        public static decimal GetKiloPrice(decimal dWidth, decimal dLength, decimal dGauge, decimal dGussest, decimal dUnitPrice, string sUomID)
        {
            decimal dKiloPrice = 0;
            try
            {
                if (clsHelpMethods.IsUomCalculationBag(sUomID))
                    dKiloPrice = (dUnitPrice * 1000) / ((dWidth * dLength * dGauge * dGussest) / 3300);
                else if (clsHelpMethods.IsUomCalculationKilogram(sUomID))
                    dKiloPrice = dUnitPrice;
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dKiloPrice;
        }
        #endregion

        #region Get Weight
        public static decimal GetWeight(decimal dWidth, decimal dLength, decimal dGauge, decimal dGussest, decimal dQuantity, string sUomID)
        {
            decimal dWeight = 0;
            try
            {
                if (clsHelpMethods.IsUomCalculationBag(sUomID))
                {
                    decimal dBagSize = (clsValidate.ValidateBagSize(dWidth)) * (clsValidate.ValidateBagSize(dLength)) *
                            (clsValidate.ValidateBagSize(dGauge)) * (clsValidate.ValidateBagSize(dGussest));
                    dWeight = ((dBagSize / 3300) * dQuantity) / 1000;
                }
                else if (clsHelpMethods.IsUomCalculationKilogram(sUomID))
                    dWeight = dQuantity;
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dWeight;
        }
        public static decimal GetWeightByItemID(string sItemID, decimal dQuantity)
        {
            decimal dWeight = 0;
            try
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    if (clsHelpMethods.IsUomCalculationBag(detail.Uom_ID))
                    {
                        decimal dBagSize = (clsValidate.ValidateBagSize(detail.Width)) * (clsValidate.ValidateBagSize(detail.Height)) *
                            (clsValidate.ValidateBagSize(detail.Thickness)) * (clsValidate.ValidateBagSize(detail.Gusset));
                        dWeight = ((dBagSize / 3300) * dQuantity) / 1000;
                    }
                    //else
                    //    dWeight = dQuantity;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dWeight;
        }
        #endregion

        #region Get Quantity
        public static decimal GetQuantityByItemID(string sItemID, decimal dWeight)
        {
            decimal dQuantity = 0;
            try
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    if (clsHelpMethods.IsUomCalculationBag(detail.Uom_ID))
                        dQuantity = (dWeight * 3300 * 1000) / (detail.Width * detail.Height * detail.Thickness * detail.Gusset); //(((detail.Width * detail.Height * detail.Thickness * detail.Gusset) / 3300) * dQuantity) / 1000;
                    //else
                    //    dQuantity = dWeight;
                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dQuantity;
        }
        public static decimal GetQuantityBySquarFt(string sItemID, decimal dSqFt)
        {
            decimal dQuantity = 0;
            try
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    dQuantity = dSqFt / detail.CalculationRate_LFeet;
                    dQuantity = Math.Ceiling(dQuantity);

                }
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dQuantity;
        }
        #endregion

        #region Get UOM Type
        public static bool IsUomTypeSales(string sUomID)
        {
            bool value = false;
            tbl_zUom detail = tbl_zUom.Select(sUomID);
            if (detail != null)
            {
                value = detail.IsForSales;
            }
            return value;
        }
        public static bool IsUomTypePacking(string sUomID)
        {
            bool value = false;
            tbl_zUom detail = tbl_zUom.Select(sUomID);
            if (detail != null)
            {
                value = detail.IsForPacking;
            }
            return value;
        }
        #endregion

        #region Get UOM Calculation Type
        public static bool IsUomCalculationKilogram(string sUomID)
        {
            bool value = false;
            tbl_zUom detail = tbl_zUom.Select(sUomID);
            if (detail != null)
            {
                value = detail.IsForKiloCalculation;
            }
            return value;
        }
        public static bool IsUomCalculationBag(string sUomID)
        {
            bool value = false;
            tbl_zUom detail = tbl_zUom.Select(sUomID);
            if (detail != null)
            {
                value = detail.IsForBagCalculation;
            }
            return value;
        }
        #endregion

        #region Get PLU
        public static string GetPLU(string sCusID, string sItemID)
        {
            string sValue = "";
            tbl_genCustomerMaster oCus = tbl_genCustomerMaster.Select(sCusID);
            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
            if (oCus != null && oItem != null && oCus.IsCustomerWiseItemCode)
            {
                tbl_genItemMaster_Finance_Customer oFinCus = tbl_genItemMaster_Finance_Customer.Select(oCus.Customer_ID, "default", oItem.Item_ID, "default", "default", "0", "0");
                if (oFinCus != null)
                    sValue = oFinCus.PluCode;
            }
            else
            {
                sValue = "-";
            }
            return sValue;
        }
        #endregion

        #region Stock Goods Are from Where

        #endregion

        #region Fill Stock Datagrid
        public static void Fill_StockDatagrid(DataGridView dgvDetail, int iRow, string sItemID, string sUom_ID,
           string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
           string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
           string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
           string sSerial1, string sSerial2, string sItemStatus, decimal dUnitPrice, decimal dTotalAmount)
        {
            bool bItemExist = false;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                if (sItemID == sTmpItemID && sItemSubCategory1 == sTmpItemSub && sItemSubCategory2 == sTmpItemSub2 && sSerial1 == sTmpSerial && sSerial2 == sTmpSerial2)
                {
                    bItemExist = true;
                    dgvDetail.Rows.RemoveAt(iRow);
                    iRow = row.Index;
                    break;
                }
            }

            if (!bItemExist)
            {
                dgvDetail["ItemCode", iRow].Value = sItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(sItemID);
                dgvDetail["UOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(sUom_ID));
                dgvDetail["UOM", iRow].Tag = sUom_ID;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                dgvDetail["SelectArea_ID", iRow].Value = sSelectArea_ID;
                dgvDetail["Department_ID", iRow].Value = sDepartment_ID;
                dgvDetail["Section_ID", iRow].Value = sSection_ID;
                dgvDetail["Store_ID", iRow].Value = sStore_ID;
                dgvDetail["DepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
                dgvDetail["SectionNote_ID", iRow].Value = sSectionNote_ID;
                dgvDetail["StoreNote_ID", iRow].Value = sStoreNote_ID;
                dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
                dgvDetail["GoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
                dgvDetail["Note_ID", iRow].Value = clsCommon.GetForeignKeyValue(sNoteID);


                dgvDetail["ItemSubCategoryID1", iRow].Tag = sItemSubCategory1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                dgvDetail["ItemSerialNo1", iRow].Value = sSerial1;
                dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);

                dgvDetail["ItemUnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dUnitPrice);
                dgvDetail["ItemTotalValue", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dTotalAmount);

                dgvDetail["Quantity", iRow].Selected = true;
            }
            else
                MessageBox.Show("User is not allowed to add same item again...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Fill_StockDatagridBreakDawn(DataGridView dgvDetail, int iRow, string sItemID, string sUom_ID,
            string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
            string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
            string sNoteID, string sQuantity, decimal dWeight, decimal dWeightActual, decimal dLength, decimal dGauge, int iLineNo)
        {

            dgvDetail["BItemCode", iRow].Value = sItemID;
            dgvDetail["BItemName", iRow].Value = clsGenaralName.getName_Item(sItemID);
            dgvDetail["BUOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(sUom_ID));
            dgvDetail["BUOM", iRow].Tag = sUom_ID;

            dgvDetail["BSelectArea_ID", iRow].Value = sSelectArea_ID;
            dgvDetail["BDepartment_ID", iRow].Value = sDepartment_ID;
            dgvDetail["BSection_ID", iRow].Value = sSection_ID;
            dgvDetail["BStore_ID", iRow].Value = sStore_ID;
            dgvDetail["BDepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
            dgvDetail["BSectionNote_ID", iRow].Value = sSectionNote_ID;
            dgvDetail["BStoreNote_ID", iRow].Value = sStoreNote_ID;
            dgvDetail["BJobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
            dgvDetail["BGoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
            dgvDetail["BNote_ID", iRow].Value = clsCommon.GetForeignKeyValue(sNoteID);
            dgvDetail["BQuantity", iRow].Value = sQuantity;
            dgvDetail["BWeight", iRow].Value = dWeight.ToString();
            dgvDetail["BWeightActual", iRow].Value = dWeightActual.ToString();
            dgvDetail["BLength", iRow].Value = dLength.ToString();
            dgvDetail["BGauge", iRow].Value = dGauge.ToString();
            dgvDetail["LineNo", iRow].Value = iLineNo.ToString();
        }

        public static void Fill_StockDatagridItemGem(DataGridView dgvDetail, int iRow, string sItemID, string sUom_ID,
           string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
           string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
           string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
           string sSerial1, string sSerial2, string sItemStatus, string sMettle, string sGem, decimal dSellingPrice, decimal dCostPrice)
        {
            bool bItemExist = false;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                if (sItemID == sTmpItemID && sItemSubCategory1 == sTmpItemSub && sItemSubCategory2 == sTmpItemSub2 && sSerial1 == sTmpSerial && sSerial2 == sTmpSerial2)
                {
                    bItemExist = true;
                    dgvDetail.Rows.RemoveAt(iRow);
                    iRow = row.Index;
                    break;
                }
            }

            if (!bItemExist)
            {
                dgvDetail["ItemCode", iRow].Value = sItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(sItemID);
                dgvDetail["UOM", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(sUom_ID));
                dgvDetail["UOM", iRow].Tag = sUom_ID;
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;

                dgvDetail["SelectArea_ID", iRow].Value = sSelectArea_ID;
                dgvDetail["Department_ID", iRow].Value = sDepartment_ID;
                dgvDetail["Section_ID", iRow].Value = sSection_ID;
                dgvDetail["Store_ID", iRow].Value = sStore_ID;
                dgvDetail["DepartmentNote_ID", iRow].Value = sDepartmentNote_ID;
                dgvDetail["SectionNote_ID", iRow].Value = sSectionNote_ID;
                dgvDetail["StoreNote_ID", iRow].Value = sStoreNote_ID;
                dgvDetail["JobCode", iRow].Value = clsCommon.GetForeignKeyValue(sJobCode);
                dgvDetail["GoodsFrom", iRow].Value = clsCommon.GetForeignKeyValue(sGoodsFrom);
                dgvDetail["Note_ID", iRow].Value = clsCommon.GetForeignKeyValue(sNoteID);


                dgvDetail["ItemSubCategoryID1", iRow].Tag = sItemSubCategory1;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                dgvDetail["ItemSerialNo1", iRow].Value = sSerial1;
                dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
                dgvDetail["MettleDetail", iRow].Value = sMettle;
                dgvDetail["GemDetail", iRow].Value = sGem;
                dgvDetail["CostPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(dCostPrice);
                dgvDetail["TotalCostPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(dCostPrice * dQuantity);
                dgvDetail["SellingPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(dSellingPrice);

                dgvDetail["Quantity", iRow].Selected = true;
            }
            else
                MessageBox.Show("User is not allowed to add same item again...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Get ProductionJobID By CustomerID
        //public static string GetProductionJobIDByCustomerOrderID(string sCustomerOrderID) //not Recomended method
        //{
        //    string value = "default";
        //    try
        //    {
        //        List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(sCustomerOrderID);
        //        foreach (tbl_pmsProductionJobRegister detail in details)
        //        {
        //            value = detail.ProductionJob_ID;
        //            break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", 0, ex);
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return value;
        //}
        #endregion

        #region Get Combination Material By ProductionJob_ID
        //public static string getCombinationMaterialByProductionJobID(string sProductionJob_ID)
        //{
        //    string sValue = "";
        //    tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
        //    if (oJR != null)
        //    {
        //        List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
        //        foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
        //        {
        //            if (oJRMaterial.IsPolythine)
        //            {
        //                if (oJRMaterial.PolytheneMaterailType_ID != "default")
        //                {
        //                    tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
        //                    sValue += pmt.PolytheneMaterailTypeName.ToString() + " + ";
        //                }
        //            }
        //            if (oJRMaterial.IsLamination)
        //            {
        //                if (oJRMaterial.LaminationMaterailType_ID != "default")
        //                {
        //                    tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
        //                    sValue += lmt.LaminationMaterailTypeName.ToString() + " + ";
        //                }
        //            }
        //        }
        //    }
        //    return sValue;
        //}
        //public static string getCombinationMaterialThicknessByProductionJobID(string sProductionJob_ID)
        //{
        //    string sValue = "";
        //    tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
        //    if (oJR != null)
        //    {
        //        List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
        //        foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
        //        {
        //            decimal dThickness = oJR.ProductionJobType_ID == "PJT/003" || oJR.ProductionJobType_ID == "PJT/004" ? (oJRMaterial.Thickness * 4) : oJRMaterial.Thickness;
        //            if (oJRMaterial.IsPolythine)
        //            {
        //                if (oJRMaterial.PolytheneMaterailType_ID != "default")
        //                {
        //                    tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
        //                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + " + ";
        //                }
        //            }
        //            if (oJRMaterial.IsLamination)
        //            {
        //                if (oJRMaterial.LaminationMaterailType_ID != "default")
        //                {
        //                    tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
        //                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + " + ";
        //                }
        //            }
        //        }
        //    }
        //    return sValue;
        //}
        //public static List<string> getCombinationMaterialListByProductionJobID(string sProductionJob_ID, bool bShowWeight)
        //{
        //    List<string> sValue = new List<string>();
        //    tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
        //    if (oJR != null)
        //    {
        //        List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
        //        foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
        //        {
        //            decimal dThickness = oJR.ProductionJobType_ID == "PJT/003" || oJR.ProductionJobType_ID == "PJT/004" ? (oJRMaterial.Thickness * 4) : oJRMaterial.Thickness;
        //            string sWeight = bShowWeight ? " - " + clsFormatter.FormatToCurrecyWithThreeDecimalPlaces(oJRMaterial.Width) + "kg" : "";
        //            if (oJRMaterial.IsPolythine)
        //            {
        //                if (oJRMaterial.PolytheneMaterailType_ID != "default")
        //                {
        //                    tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
        //                    if (pmt != null)
        //                        sValue.Add(pmt.PolytheneMaterailTypeName.ToString() + "  -  " + clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + sWeight);
        //                }
        //            }
        //            if (oJRMaterial.IsLamination)
        //            {
        //                if (oJRMaterial.LaminationMaterailType_ID != "default")
        //                {
        //                    tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
        //                    if (lmt != null)
        //                        sValue.Add(lmt.LaminationMaterailTypeName.ToString() + "  -  " + clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + sWeight);
        //                }
        //            }
        //        }
        //    }
        //    return sValue;
        //}
        #endregion

        #region Get Customer PO No By ProductionJobID
        //public static string GetPONoByProductionJobID(string sProductionJob_ID)
        //{
        //    string sValue = "";
        //    tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
        //    if (oJR != null)
        //    {
        //        tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oJR.CustomerOrder_ID);
        //        if (oCO != null)
        //        {
        //            sValue = oCO.PurchaseOrder_ID;
        //        }
        //    }
        //    return sValue;
        //}
        #endregion

        #region Get Customer PO No By DeliverOrderID
        public static string GetPONoByDeliveryOrderID(string sDeliverOrderID)
        {
            string sValue = "";
            tbl_sasDeliveryOrder oJR = tbl_sasDeliveryOrder.Select(sDeliverOrderID);
            if (oJR != null)
            {
                tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oJR.CustomerOrder_ID);
                if (oCO != null)
                {
                    sValue = oCO.PurchaseOrder_ID;
                }
            }
            return sValue;
        }
        #endregion

        #region Get Customer PO No By CustomerOrderID
        public static string GetPONoByCustomerOrderID(string sCustomerOrderID)
        {
            string sValue = "";
            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCustomerOrderID);
            if (oCO != null)
            {
                sValue = oCO.PurchaseOrder_ID;
            }
            return sValue;
        }
        #endregion

        #region Get Production JobType Simple
        //public static string getProductionJobType_Simple(string sProductionJob_ID)
        //{

        //    string sValue = "";
        //    tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
        //    if (oJR != null)
        //    {
        //        tbl_zJobProductionJobType oProductionJobType = tbl_zJobProductionJobType.Select(oJR.ProductionJobType_ID);
        //        if (oProductionJobType != null)
        //        {

        //            switch (oProductionJobType.ProductionJobType_ID)
        //            {
        //                case "PJT/001":
        //                    sValue = "KDDN";
        //                    break;
        //                case "PJT/002":
        //                    sValue = "KDDN";
        //                    break;
        //                case "PJT/003":
        //                    sValue = "PTDN";
        //                    break;
        //                case "PJT/004":
        //                    sValue = "PTDN";
        //                    break;
        //                case "PJT/007":
        //                    sValue = "KDDN";
        //                    break;
        //                case "PJT/008":
        //                    sValue = "PTDN";
        //                    break;
        //                case "default":
        //                    sValue = "";
        //                    break;
        //            }
        //        }

        //    }
        //    return sValue;
        //}
        #endregion

        #region Get Ordered Qty By CustomerOrder ID
        public static decimal GetOrderdQtyBy_CustomerOrderID(string sCustomerOrderID)
        {
            decimal dValue = 0;
            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCustomerOrderID);
            if (oCO != null)
            {
                foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID))
                {
                    if (oCO.IsWeightCalculation)
                        dValue += oCODetail.Weight;
                    else
                        dValue += oCODetail.Qty;
                }
            }
            return dValue;
        }
        #endregion

        #region Get Job Standard Weight By CustomerOrder ID or Sales Job ID
        //public static decimal GetJobStandardWeightBy_CustomerOrderID(string sCustomerOrderID)
        //{
        //    decimal dValue = 0;
        //    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCustomerOrderID);
        //    if (oCO != null && oCO.Job_ID != null)
        //    {
        //        foreach (tbl_sasJobRegister_Material oMaterial in tbl_sasJobRegister_Material.SelectAllByJob_ID(oCO.Job_ID))
        //        {
        //            dValue += oMaterial.Width;
        //        }
        //    }
        //    return dValue;
        //}
        //public static decimal GetJobStandardWeightBy_SalesJobID(string sSalesJobID)
        //{
        //    decimal dValue = 0;
        //    foreach (tbl_sasJobRegister_Material oMaterial in tbl_sasJobRegister_Material.SelectAllByJob_ID(sSalesJobID))
        //    {
        //        dValue += oMaterial.Width;
        //    }
        //    return dValue;
        //}
        #endregion

        #region Fill Department Detail From Note_ID
        public static void FillDepartmentDetailFromGIN_ID(string sGIN_ID, TextBox myTextBox)
        {
            tbl_scsDepartmentGoodIssueNote detail = tbl_scsDepartmentGoodIssueNote.Select(sGIN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromDepartment_ID;
                myTextBox.Text = clsGenaralName.getName_Department(detail.FromDepartment_ID);
            }
        }
        public static void FillDepartmentDetailFromGRN_ID(string sGRN_ID, TextBox myTextBox)
        {
            tbl_scsDepartmentGoodReceiveNote detail = tbl_scsDepartmentGoodReceiveNote.Select(sGRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.ToDepartment_ID;
                myTextBox.Text = clsGenaralName.getName_Department(detail.ToDepartment_ID);
            }
        }
        public static void FillDepartmentDetailFromDRN_ID(string sDRN_ID, TextBox myTextBox)
        {
            tbl_scsDepartmentReqositionNote detail = tbl_scsDepartmentReqositionNote.Select(sDRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromDepartment_ID;
                myTextBox.Text = clsGenaralName.getName_Department(detail.FromDepartment_ID);
            }
        }
        #endregion

        #region Fill Section Detail From Note_ID
        public static void FillSectionDetailFromGIN_ID(string sGIN_ID, TextBox myTextBox)
        {
            tbl_scsSectionGoodIssueNote detail = tbl_scsSectionGoodIssueNote.Select(sGIN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromSection_ID;
                myTextBox.Text = clsGenaralName.getName_Section(detail.FromSection_ID);
            }
        }
        public static void FillSectionDetailFromGRN_ID(string sGRN_ID, TextBox myTextBox)
        {
            tbl_scsSectionGoodReceiveNote detail = tbl_scsSectionGoodReceiveNote.Select(sGRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.ToSection_ID;
                myTextBox.Text = clsGenaralName.getName_Section(detail.ToSection_ID);
            }
        }
        public static void FillSectionDetailFromSRN_ID(string sSRN_ID, TextBox myTextBox)
        {
            tbl_scsSectionReqositionNote detail = tbl_scsSectionReqositionNote.Select(sSRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromSection_ID;
                myTextBox.Text = clsGenaralName.getName_Section(detail.FromSection_ID);
            }
        }
        #endregion

        #region Fill Store Detail From Note_ID
        public static void FillStoreDetailFromGIN_ID(string sGIN_ID, TextBox myTextBox)
        {
            tbl_scsStoreGoodIssueNote detail = tbl_scsStoreGoodIssueNote.Select(sGIN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromStore_ID;
                myTextBox.Text = clsGenaralName.getName_Store(detail.FromStore_ID);
            }
        }
        public static void FillStoreDetailFromGRN_ID(string sGRN_ID, TextBox myTextBox)
        {
            tbl_scsStoreGoodReceiveNote detail = tbl_scsStoreGoodReceiveNote.Select(sGRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.ToStore_ID;
                myTextBox.Text = clsGenaralName.getName_Store(detail.ToStore_ID);
            }
        }
        public static void FillStoreDetailFromSRN_ID(string sSRN_ID, TextBox myTextBox)
        {
            tbl_scsStoreReqositionNote detail = tbl_scsStoreReqositionNote.Select(sSRN_ID);
            if (detail != null)
            {
                myTextBox.Tag = detail.FromStore_ID;
                myTextBox.Text = clsGenaralName.getName_Store(detail.FromStore_ID);
            }
        }
        #endregion

        #region Price Convertion
        public static decimal getSavePrice(decimal dPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            dUnitPrice = dPrice * dExRate;
            return dUnitPrice;
        }
        public static decimal getSavePrice(decimal dPrice, decimal dCurrencyRate)
        {
            decimal dUnitPrice = 0;

            dUnitPrice = dPrice * dCurrencyRate;
            return dUnitPrice;
        }
        public static decimal getDisplayPrice(decimal dPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dPrice / dExRate;
            return dUnitPrice;
        }
        public static decimal getDisplayPrice(decimal dPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            if (dExRate > 0)
                dUnitPrice = dPrice / dExRate;
            return dUnitPrice;
        }
        #endregion

        #region Is Item Raw Material
        public static bool IsItemRawMaterial(string sItemID)
        {
            bool bIsRawMaterial = false;
            try
            {
                if (sItemID.Length > 0)
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                    if (detail != null)
                    {
                        if (detail.ItemType_ID == clsAutocode.getItemTypeID(ItemTypes.RawMaterial))
                            bIsRawMaterial = true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bIsRawMaterial;
        }
        #endregion

        #region Is Item Raw Material
        public static bool IsNonInventoryItem(string sItemID)
        {
            bool bIsNonInventoryItem = false;
            try
            {
                if (sItemID.Length > 0)
                {
                    tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                    if (detail != null && detail.Item_ID != "default")
                        bIsNonInventoryItem = detail.IsServiceItem;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return bIsNonInventoryItem;
        }
        #endregion

        #region Assign Single Stock Item Detail
        public static void AssignSingleStockItemDetail(ref string sItemCode, ref string sItemSubCategoryID, ref string sItemSubCategoryID2, ref string sItemSerialNo, ref string sItemSerialNo2)
        {
            sItemCode = clsConfig.sSingleItemStockItemID;
            sItemSubCategoryID = clsConfig.sSingleItemStockItemSubCategoryID;
            sItemSubCategoryID2 = clsConfig.sSingleItemStockItemSubCategory2ID;
            sItemSerialNo = clsConfig.sSingleItemStockItemSerialNo;
            sItemSerialNo2 = clsConfig.sSingleItemStockItemSerialNo2;
        }
        #endregion

        #region Get Item Size By ItemID
        public static string GetItemSizeByItemID(string sItem_ID)
        {
            string sValue = "";
            decimal dTranslateValue = clsHelpMethods.GetJobMeasurementUomConvertValue(sItem_ID);
            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
            if (oItem != null)
            {
                if (oItem.Width != 0 || oItem.Height != 0 || oItem.Gusset != 0)
                {
                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Width / dTranslateValue).ToString() + " X ";
                    //sValue += clsCommon.FormatToNumberWithTwoDecimalPlaces(oItem.Thickness / dTranslateValue).ToString() + " X ";
                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Gusset / dTranslateValue).ToString() + " X ";
                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Height / dTranslateValue).ToString() + "  " + clsGenaralName.getName_ItemJobMeasurementTypeName(sItem_ID);
                }
            }
            return sValue;
        }
        #endregion

        //Reorder Level Method
        public static bool Is_ReachtoReOrderLevel(string sItem_ID)
        {
            bool bReachLevel = false;
            foreach (tbl_genStore_Stock oStoreStock in tbl_genStore_Stock.SelectAllByItem_ID(sItem_ID))
            {
                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oStoreStock.Store_ID);
                if (oStore != null)
                {
                    if (!oStore.IsDeleted)
                    {
                        tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(oStoreStock.Item_ID);
                        if (oItemMaster != null && oItemMaster.ReReoverLevel >= oStoreStock.Qty)
                        {
                            bReachLevel = true;
                            break;
                        }
                    }
                }
            }

            return bReachLevel;
        }

        public static DataTable GetItemList_ReachtoReOrderLevel(string sItem_ID)
        {
            DataTable dtItemStock = new DataTable();
            dtItemStock.Columns.Add("Item_ID");
            dtItemStock.Columns.Add("Item_Name");
            dtItemStock.Columns.Add("Store_ID");
            dtItemStock.Columns.Add("Store_Name");
            dtItemStock.Columns.Add("UoM_ID");
            dtItemStock.Columns.Add("UoM_Name");
            dtItemStock.Columns.Add("ReorderLevelQty");
            dtItemStock.Columns.Add("CurrentQty");

            foreach (tbl_genStore_Stock oStoreStock in tbl_genStore_Stock.SelectAllByItem_ID(sItem_ID))
            {
                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oStoreStock.Store_ID);
                if (oStore != null)
                {
                    if (!oStore.IsDeleted)
                    {
                        tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(oStoreStock.Item_ID);
                        if (oItemMaster != null && oItemMaster.ReReoverLevel >= oStoreStock.Qty)
                        {
                            dtItemStock.Rows.Add(
                                oItemMaster.Item_ID, oItemMaster.ItemName,
                                oStore.Store_ID, oStore.StoreName,
                                oItemMaster.Uom_ID, clsGenaralName.getName_Uom(oItemMaster.Uom_ID),
                                clsFormatter.FormatDecimal(oItemMaster.ReReoverLevel, clsConfig.sDecimalPlaces_Quantity),
                             clsFormatter   .FormatDecimal(oStoreStock.Qty, clsConfig.sDecimalPlaces_Quantity));
                        }
                    }
                }
            }

            return dtItemStock;
        }

        // Mesurment

        #region Measurement Type
        public static decimal GetJobMeasurementUomConvertValue(string sItemID)
        {
            decimal value = 1;
            tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
            if (detail != null)
                value = GetJobMeasurementTranslateValue(detail.MeasureType_ID);
            return value;
        }

        public static decimal GetJobMeasurementTranslateValue(string sMeasureTypeID)
        {
            decimal value = 1;
            tbl_zJobMeasurementType type = tbl_zJobMeasurementType.Select(sMeasureTypeID);
            if (type != null)
                value = type.TranslateValue;
            return value;
        }
        #endregion

        // Cheque

        #region Get EmployeeID From ReceiptID
        public static string getEmployeeIDFromReceiptID(string sReceiptID)
        {
            string sEmployeeID = "default";
            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
            if (detail != null)
            {
                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(detail.Customer_ID);
                if (customer != null)
                    sEmployeeID = customer.SalesRep_ID;

            }
            return sEmployeeID;
        }
        #endregion

        #region Get Store Requisition Pending Qty
        public static decimal Get_StoreRequisition_PendingQty(string sSRNID, string sItemID, decimal dSRQty)
        {
            decimal dValue = 0, dGINQty = 0;
            foreach (tbl_scsStoreGoodIssueNote oGIN in tbl_scsStoreGoodIssueNote.SelectAll().Where(p => p.StoreRequisitionNote_ID == sSRNID))
            {
                List<tbl_scsStoreGoodIssueNote_Detail> oGINDetail = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(oGIN.StoreGoodIssueNote_ID).Where(p => p.Item_ID == sItemID).ToList();
                foreach (tbl_scsStoreGoodIssueNote_Detail detail in oGINDetail)
                    dGINQty += detail.Qty;
            }

            if (dSRQty > 0 && dGINQty > 0)
                dValue = dSRQty - dGINQty;

            return dValue;
        }
        #endregion

        #region Insert Transaction History
        public static void InsertTransactionHistory(int form_Id, string transaction_Id, TxnActivity enmActivity)
        {
            tbl_txnUpdateHistory oTrans = new tbl_txnUpdateHistory(form_Id, transaction_Id, (int)enmActivity, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.TerminalID);
            oTrans.Insert();
        }
        #endregion
        public static string CheckValue(string value)
        {
            StringBuilder sBuilder = new StringBuilder(value);
            string pattern = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";
            Regex expression = new Regex(pattern);

            if (expression.IsMatch(value))
            {
                sBuilder.Replace("[", "[[]");
                sBuilder.Replace("]", "[]]");
                sBuilder.Replace("[[[]]", "[[]");

                sBuilder.Replace("'", "''");
                sBuilder.Replace("*", "[*]");
                sBuilder.Replace("%", "[%]");
            }
            return sBuilder.ToString();
        }

        public static bool Check_ProdApparel_Enable()
        {
            bool bStatus = false;

            tbl_cfgModule oModule = tbl_cfgModule.Select("PROD/016");
            if (oModule != null)
                bStatus = oModule.IsEnable;

            return bStatus;
        }

        #region Get Enum Description
        public static List<string> GetEnumDescription(Type enumType)
        {
            List<string> lPeriod = new List<string>();
            foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (
                Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            }).OrderBy(item => item.value).ToList())
            {
                lPeriod.Add(record.Description);
            }
            return lPeriod;
        }
        #endregion

        public static string GetEnumDescription_Name(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

       
    }
}

public class tbl_Detail
{
    public int Line_No;
    public string Item_ID;
    public decimal Qty;
    public decimal UnitPrice;

    public tbl_Detail(int _Line_No, string _Item_ID, decimal _Qty, decimal _UnitPrice)
    {
        Line_No = _Line_No;
        Item_ID = _Item_ID;
        Qty = _Qty;
        UnitPrice = _UnitPrice;
    }
}