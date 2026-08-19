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

using Digiteq;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;


namespace Digiteq_Logic
{
    public class clsHelpMethods
    {
        public static bool CheckOutstandingValidity_CreditPeriodAndLimit(ref TextBox txtCustomer, ref TextBox txtGrandTotal)
        {
            bool bOk_CreditPeriod = true, bOK_CreditLimit = true;

            tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
            if (customer != null && customer.Customer_ID != "default")
            {
                #region Check For Blacklisted customers
                if (customer.IsBlacklisted)
                {
                    bOk_CreditPeriod = false;
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CustomerIsBlackListed), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                #endregion
                else
                {
                    decimal dCreditPeriod = 0, dCreditLimit = 0;
                    tbl_genCustomerFinance oCusFinance = tbl_genCustomerFinance.Select(txtCustomer.Tag.ToString());
                    if (oCusFinance != null)
                    {
                        dCreditPeriod = oCusFinance.CreditPeriod;
                        dCreditLimit = oCusFinance.CreditLimit;
                    }

                    #region Credit period
                    if (clsConfig.bValidate_InvoiceCreditPeriod_Block || clsConfig.bValidate_InvoiceCreditPeriod_Messege)
                    {
                        int iNOofInvoices = 0;
                        string sInvoices = "";
                        decimal dTot = 0;

                        foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByCustomer_ID(txtCustomer.Tag.ToString()).Where(p => p.Invoice_ID != "default" && !p.IsDeleted && !p.IsSeattled && p.GrandTotal > 0))
                        {
                            int iDays = clsCommon.getDaysUptoDate(oInvoice.InvoiceDate.Date);
                            if (iDays <= oCusFinance.CreditPeriod)
                                continue;

                            dTot += oInvoice.GrandTotal - oInvoice.SeattleAmount;
                            iNOofInvoices++;
                            sInvoices += oInvoice.Invoice_ID + ", ";
                        }

                        if (iNOofInvoices > 0)
                        {
                            bOk_CreditPeriod = false;
                            //string sMsg = "This customer has " + iNOofInvoices + " Credit period exceeded invoices (" + clsFormatter.FormatDecimalPlaces_Price(dTot) + ")";
                            string sMsg = "This customer has " + iNOofInvoices + " unsettled invoice/s : \n" + sInvoices;
                            if (clsConfig.bValidate_InvoiceCreditPeriod_Block)
                                MessageBox.Show(sMsg, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            else
                            {
                                DialogResult msgResult = MessageBox.Show(sMsg + " \nDo you want to proceed?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                if (msgResult == DialogResult.Yes)
                                    bOk_CreditPeriod = true;
                            }
                        }
                    }
                    #endregion

                    #region Credit Limit
                    if (bOk_CreditPeriod)
                    {
                        if (clsConfig.bValidate_CreditBalance_Message || clsConfig.bValidate_CreditBalance_Block)
                        {
                            decimal dAmountDue = 0;
                            if (txtGrandTotal.TextLength > 0)
                                dAmountDue = decimal.Parse(txtGrandTotal.Text.Trim());

                            if ((GetCustomerTotalDues_All(txtCustomer.Tag.ToString()) + dAmountDue) > dCreditLimit)
                            {
                                bOK_CreditLimit = false;
                                if (clsConfig.bValidate_CreditBalance_Block)
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedLock), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                else
                                {
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.CreditLimitExceedMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                    if (msgResult == DialogResult.Yes)
                                        bOK_CreditLimit = true;
                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            return (bOk_CreditPeriod && bOK_CreditLimit);
        }
        public static void InsertTransactionHistory(int form_Id, string transaction_Id, TxnActivity enmActivity)
        {
            tbl_txnUpdateHistory oTrans = new tbl_txnUpdateHistory(form_Id, transaction_Id, (int)enmActivity, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.TerminalID);
            oTrans.Insert();
        }
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

        public static void Update_Inventory(tbl_scsInventoryTxnHeader oHeader, List<tbl_scsInventoryTxnDetail> oListDetail)
        {
            tbl_scsInventoryTxnHeader oOldDetail = tbl_scsInventoryTxnHeader.Select(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID);
            if (oOldDetail != null)
            {
                tbl_scsInventoryTxnHeader oInventoryHeader = new tbl_scsInventoryTxnHeader(oOldDetail.TxnType, oOldDetail.TxnIndex, oOldDetail.TxnID, oHeader.TxnDate, oHeader.Remarks,
                    oHeader.Customer_ID, oHeader.Supplier_ID, oHeader.SalesNoteType_ID, oHeader.Route_ID,
                    oHeader.TotalAmount, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", oHeader.IsDeleted, clsSecurity.UserIDLoged);
                oInventoryHeader.Update();

                tbl_scsInventoryTxnDetail.DeleteAllByTxnType_TxnIndex_TxnID(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID);
            }
            else
            {
                tbl_scsInventoryTxnHeader oInventoryHeader = new tbl_scsInventoryTxnHeader(oHeader.TxnType, oHeader.TxnIndex, oHeader.TxnID, oHeader.TxnDate, oHeader.Remarks,
                    oHeader.Customer_ID, oHeader.Supplier_ID, oHeader.SalesNoteType_ID, oHeader.Route_ID,
                    oHeader.TotalAmount, clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default", oHeader.IsDeleted, clsSecurity.UserIDLoged);
                oInventoryHeader.Insert();
            }

            foreach (tbl_scsInventoryTxnDetail oDetail in oListDetail)
            {
                tbl_scsInventoryTxnDetail oInventoryDetail = new tbl_scsInventoryTxnDetail(oDetail.TxnType, oDetail.Line_No, oDetail.TxnIndex, oDetail.TxnID, oDetail.TxnDate,
                    clsSecurity.CompanyID, clsSecurity.BranchID, "default", "default",
                    oDetail.Customer_ID, oDetail.Supplier_ID, oDetail.Store_ID, oDetail.Item_ID, oDetail.Uom_ID, oDetail.ReceivedQty, oDetail.IssuedQty, oDetail.UnitPrice, oDetail.WeightedAvgPrice, oDetail.IsDeleted);
                oInventoryDetail.Insert();
            }
        }

        public static void Delete_Inventory(int iTxnType, int iTxnIndex, string sTxnID)
        {
            tbl_scsInventoryTxnHeader oOldDetail = tbl_scsInventoryTxnHeader.Select(iTxnType, iTxnIndex, sTxnID);
            if (oOldDetail != null)
            {
                oOldDetail.IsDeleted = true;
                oOldDetail.Update();

                List<tbl_scsInventoryTxnDetail> oDetailList = tbl_scsInventoryTxnDetail.SelectAllByTxnType_TxnIndex_TxnID(iTxnType, iTxnIndex, sTxnID);
                foreach (tbl_scsInventoryTxnDetail oDetail in oDetailList)
                {
                    oDetail.IsDeleted = true;
                    oDetail.Update();
                }
            }
        }

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
            foreach (tbl_proProductionPlan_Job detail in tbl_proProductionPlan_Job.SelectAllByProductionPlan_ID(sProductionPlanID).Where(p => p.ProductionJob_ID != "default" && p.Line_No >= iMaxNo))
            {
                iMaxNo = detail.Line_No + 1;
            }
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
        public static void Fill_StockDatagrid(DataGridView dgvDetail, int iRow, int iLineNo, string sItemID, string sUom_ID,
           string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
           string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
           string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
           string sSerial1, string sSerial2, string sItemStatus, decimal dUnitPrice, decimal dTotalAmount, string sRemarks, decimal dFlowStockQty)
        {

            decimal dWeightAvg = 0;
            clsHelpMethods.AddMultipleItems_Grid(dgvDetail, sItemID, ref iRow, ref iLineNo, ref dQuantity, ref dUnitPrice, ref dWeight, ref dWeightAvg);

            //if (!bItemExist)
            //{
            dgvDetail["LineNo", iRow].Value = iLineNo;
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
            dgvDetail["Remarks", iRow].Value = sRemarks;

            dgvDetail["FloorStockQty", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dFlowStockQty);

            dgvDetail["Quantity", iRow].Selected = true;

            #region Set Row Count
            dgvDetail["RowCount", iRow].Value = iRow + 1;
            #endregion
        }

        public static void Fill_StockDatagrid_GTN(DataGridView dgvDetail, int iRow, int lineNo, string sItemID, string sUom_ID,
                   string sJobCode, string sSelectArea_ID, string sDepartment_ID, string sSection_ID, string sStore_ID,
                   string sDepartmentNote_ID, string sSectionNote_ID, string sStoreNote_ID, string sGoodsFrom,
                   string sNoteID, decimal dQuantity, decimal dWeight, string sItemSubCategory1, string sItemSubCategory2,
                   string sSerial1, string sSerial2, string sItemStatus, decimal dUnitPrice, decimal dTotalAmount)
        {
            bool bItemExist = false;

            if (!clsConfig.bAllow_user_to_Dupplicate_items_SCS_Transactions)
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sTmpItemID = "", sTmpItemSub = "", sTmpItemSub2 = "", sTmpSerial = "", sTmpSerial2 = "";
                    int iLineNo = lineNo;

                    iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, lineNo);
                    sTmpItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sTmpItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                    sTmpItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sTmpSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                    sTmpSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (sItemID == sTmpItemID && sItemSubCategory1 == sTmpItemSub && sItemSubCategory2 == sTmpItemSub2 && sSerial1 == sTmpSerial && sSerial2 == sTmpSerial2)
                    {
                        bItemExist = true;
                        dgvDetail.Rows.RemoveAt(iRow);
                        lineNo = iLineNo;
                        iRow = row.Index;
                        break;
                    }
                }

            if (!bItemExist)
            {
                dgvDetail["LineNo", iRow].Value = lineNo;
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


                dgvDetail["ItemSubCategoryID", iRow].Tag = sItemSubCategory1;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(sItemSubCategory1));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = sItemSubCategory2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(sItemSubCategory2));
                dgvDetail["ItemSerialNo", iRow].Value = sSerial1;
                dgvDetail["ItemSerialNo2", iRow].Value = sSerial2;

                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight);

                dgvDetail["ItemUnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(dUnitPrice);
                dgvDetail["ItemTotalValue", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dTotalAmount);

                dgvDetail["Quantity", iRow].Selected = true;

                #region Set Row Count
                dgvDetail["RowCount", iRow].Value = iRow + 1;
                #endregion
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



        #region Update/Insert Stock
        #region Update/Insert Store Stock
        public static decimal UpdateStoreStock(int FormID, string transaction_ID, DateTime transaction_date, string Item_Code, string SerialNo, string StoreID, decimal Qty, decimal dWeight, decimal TotalAmount, bool bIsRollBack, bool bIsIncreseStock, bool EnableCostCalculation, ref decimal dWeightedAverageCostPrice)
        {
            decimal dFifoCost = 0;
            decimal dFlowStockQty_Old = 0;
            decimal dLowerstCostPrice = 0;
            decimal dHighestPurchaseCostPrice = 0;
            decimal dUnitCost = 0;

            if (Qty != 0)
                dUnitCost = (TotalAmount / Qty);

            #region validate stock record
            tbl_genStore_Stock Detail = tbl_genStore_Stock.Select(StoreID, Item_Code, "default", "default", "default", "0", "0");
            if (Detail == null)
            {
                tbl_genStore_Stock newStock = new tbl_genStore_Stock(StoreID, Item_Code, "default", "default", "default", "0", "0", 0, 0, 0, 0, 0, 0, 0, 0);
                newStock.Insert();
            }
            #endregion

            #region Update Store Stock
            if (!bIsIncreseStock)
            {
                Qty = Qty * -1;
                dWeight = dWeight * -1;
            }

            if (bIsRollBack)
            {
                Qty = Qty * -1;
                dWeight = dWeight * -1;
            }

            foreach (tbl_genStore_Stock oStock in tbl_genStore_Stock.SelectAllByItem_ID(Item_Code))//  .Select(StoreID, Item_Code, "default", "default", "default", "0", "0");
            {
                dFlowStockQty_Old += oStock.Qty;

                if (oStock.Store_ID == StoreID)
                {
                    oStock.Qty += Qty;
                    oStock.Weight += dWeight;
                    oStock.Update();
                }
            }
            #endregion

            if (EnableCostCalculation)
            {
                #region Update Fifo Table
                if (!bIsRollBack)
                {
                    tbl_audFifoTransaction oFIFO = new tbl_audFifoTransaction(FormID, transaction_ID, transaction_date, StoreID, Item_Code, SerialNo, Qty, dUnitCost, bIsIncreseStock);
                    oFIFO.Insert();
                }
                else
                {
                    tbl_audFifoTransaction.DeleteAllByForm_ID_Transaction_ID(FormID, transaction_ID);
                }
                #endregion

                tbl_genItemMaster_Pricing oItem = tbl_genItemMaster_Pricing.Select(Item_Code);
                if (oItem != null)
                {
                    dFifoCost = GetFifoCost(Item_Code, 0);

                    if (FormID == clsSecurity.getFormID(FormName.scsGRNSupplier))
                    {
                        if (oItem.LowestPurchaseCostPrice > dUnitCost)
                            dLowerstCostPrice = dUnitCost;
                        else
                            dLowerstCostPrice = oItem.LowestPurchaseCostPrice;

                        if (oItem.HighestPurchaseCostPrice < dUnitCost)
                            dHighestPurchaseCostPrice = dUnitCost;
                        else
                            dHighestPurchaseCostPrice = oItem.HighestPurchaseCostPrice;

                        oItem.LowestPurchaseCostPrice = dLowerstCostPrice;
                        oItem.HighestPurchaseCostPrice = dHighestPurchaseCostPrice;
                    }

                    if (dFlowStockQty_Old + Qty != 0)
                        dWeightedAverageCostPrice = ((dFlowStockQty_Old * oItem.WeightedAverageCostPrice) + (Qty * dUnitCost)) / (dFlowStockQty_Old + Qty);


                    oItem.FifoCostPrice = dFifoCost;
                    oItem.WeightedAverageCostPrice = dWeightedAverageCostPrice;

                    oItem.Update();
                }
            }
            return dFifoCost;
        }

        public static decimal GetFifoCost(string sItemCode, decimal dQuantity)
        {
            return DBHandling.ExecQuery_ReturnDecimal("select  dbo.[GetFifoCost]('" + sItemCode + "', " + dQuantity + ")");
        }


        #endregion


        #region Add New Store Stock
        //public static bool Store_NewStock(string sStoreID, string sItemCode, string sJobID, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2, decimal dWeight, decimal dAvailableWeight, decimal dQuantity, decimal dAvailableQuantity, decimal dMeters, decimal dAvailableMeters, decimal dWasteageWeight, decimal dDamageWeight)
        //{
        //    bool rtn = false;
        //    tbl_genStore_Stock stock = tbl_genStore_Stock.Select(sStoreID, sItemCode, sJobID, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
        //    if (stock == null)
        //    {
        //        tbl_genStore_Stock newStock = new tbl_genStore_Stock(sStoreID, sItemCode, sJobID, sSubCategory1, sSubCategory2, sSerial1, sSerial2, dQuantity, dAvailableQuantity, dWeight, dAvailableWeight, dMeters, dAvailableMeters, dWasteageWeight, dDamageWeight);
        //        newStock.Insert();
        //    }
        //    return rtn;
        //}
        #endregion

        #region Add New Section Stock
        public static bool Section_NewStock(string sSectionID, string sItemCode, string sJobID, decimal dWeight, decimal dQuantity, decimal dMeters, decimal dWasteageWeight, decimal dDamageWeight)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock == null)
            {
                tbl_genSection_Stock newStock = new tbl_genSection_Stock(sSectionID, sItemCode, sJobID, "default", "default", "0", "0", dQuantity, 0, dWeight, 0, dMeters, 0, dWasteageWeight, dDamageWeight);
                newStock.Insert();
            }
            return rtn;
        }
        #endregion
        #endregion



        #region Increase/Decrease Section Stock
        #region Increase Section Stock Weight
        public static bool Section_StockWeightIncrease(string sSectionID, string sItemCode, string sJobID, decimal dWeightActual)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.Weight = stock.Weight + dWeightActual;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion

        #region Decrease Section Stock Weight
        public static bool Section_StockWeightDecrease(string sSectionID, string sItemCode, string sJobID, decimal dWeightActual)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.Weight = stock.Weight - dWeightActual;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion

        #region Increase Section Stock Wasteage
        public static bool Section_StockWasteageIncrease(string sSectionID, string sItemCode, string sJobID, decimal dWasteage)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.WasteageWeight = stock.WasteageWeight + dWasteage;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion

        #region Decrease Section Stock Wasteage
        public static bool Section_StockWasteageDecrease(string sSectionID, string sItemCode, string sJobID, decimal dWWasteage)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.WasteageWeight = stock.WasteageWeight - dWWasteage;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion

        #region Increase Section Stock Quantity
        public static bool Section_StockQuantityIncrease(string sSectionID, string sItemCode, string sJobID, decimal dQty)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.Qty = stock.Qty + dQty;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion

        #region Decrease Section Stock Quantity
        public static bool Section_StockQuantityDecrease(string sSectionID, string sItemCode, string sJobID, decimal dQty)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
            {
                stock.Qty = stock.Qty - dQty;
                stock.Update();
                rtn = true;
            }
            return rtn;
        }
        #endregion
        #endregion

        //Check Stock Availability

        #region Check Store Stock Availability
        public static bool isStore_StockAvailabel(string sStoreID, string sItemCode, string sJobID, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        {
            bool rtn = false;
            tbl_genStore_Stock stock = tbl_genStore_Stock.Select(sStoreID, sItemCode, sJobID, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
            if (stock != null)
                rtn = true;

            return rtn;
        }
        #endregion

        #region Check Section Stock Availability
        public static bool isSection_StockAvailabel(string sSectionID, string sItemCode, string sJobID)
        {
            bool rtn = false;
            tbl_genSection_Stock stock = tbl_genSection_Stock.Select(sSectionID, sItemCode, sJobID, "default", "default", "0", "0");
            if (stock != null)
                rtn = true;

            return rtn;
        }
        #endregion

        #region Get StoreStockBalance Qty
        public static decimal Get_StoreStockBalance_Qty(string sStoreID, string sItemCode, string sJobID, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        {
            decimal rtn = 0;
            tbl_genStore_Stock stock = tbl_genStore_Stock.Select(sStoreID, sItemCode, sJobID, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
            if (stock != null)
                rtn = stock.Qty;

            return rtn;
        }

        #endregion


        // Get Qty or Weight
        #region Get StoreStockBalance Weight
        public static decimal Get_PendingGRN_Weight(string sItemCode, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        {
            decimal rtn = 0;
            foreach (tbl_scsPurchaseOrder_Detail detail in tbl_scsPurchaseOrder_Detail.SelectAllByItem_ID(sItemCode)
                .Where(p => p.ItemSerialNo == sSerial1 && p.ItemSerialNo2 == sSerial2 && p.ItemSubCategory_ID == sSubCategory1 && p.ItemSubCategory2_ID == sSubCategory2 && p.Weight > p.WeightSettle))
            {
                rtn = (detail.Weight - detail.WeightSettle);
            }
            return rtn;
        }

        #endregion


        //Item Master

        #region Search Item Advance
        public static void SearchItemAdvance(ref TextBox ItemID, ref TextBox SubCategoryID, ref TextBox SerialNo)
        {
            try
            {
                SubCategoryID.Tag = "default";
                SubCategoryID.Text = "default";
                SerialNo.Tag = "0";
                SerialNo.Text = "0";

                if (clsConfig.sItemSearchType == ItemSearchType.Basic.ToString())
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);
                else if (clsConfig.sItemSearchType == ItemSearchType.Transaction.ToString())
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);
                //SearchBYItemCode
                else if (clsConfig.sItemSearchType == ItemSearchType.Transaction_SearchBYItemCode.ToString())
                    clsSearch.Search_TransactionByItemCodeItemMaster(ref ItemID);
                //else if (clsConfig.sItemSearchType == ItemSearchType.Advance1.ToString())
                //    clsSearch.Search_AdvanceItemMaster1(ref ItemID, ref SubCategoryID, ref SerialNo);
                //else if (clsConfig.sItemSearchType == ItemSearchType.Advance2.ToString())
                //    clsSearch.Search_AdvanceItemMaster2(ref ItemID, ref SubCategoryID, ref SerialNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SearchItemAdvanceStock(ref TextBox ItemID, ref TextBox SubCategoryID, ref TextBox SerialNo, string sStoreID, string sSectionID, string sDepartmentID)
        {
            try
            {
                SubCategoryID.Tag = "default";
                SubCategoryID.Text = "default";
                SerialNo.Tag = "0";
                SerialNo.Text = "0";

                if (clsConfig.sItemSearchType == ItemSearchType.Advance1.ToString())
                    clsSearch.Search_AdvanceItemMasterStock(ref ItemID, ref SubCategoryID, ref SerialNo, sStoreID, sSectionID, sDepartmentID);
                else if (clsConfig.sItemSearchType == ItemSearchType.Advance2.ToString())
                    clsSearch.Search_AdvanceItemMasterStock(ref ItemID, ref SubCategoryID, ref SerialNo, sStoreID, sSectionID, sDepartmentID);
                else
                {
                    if (sSectionID.Length > 0)
                        clsSearch.Search_TransactionSectionStockItem(ref ItemID, sSectionID);
                    else if (sStoreID.Length > 0)
                        clsSearch.Search_TransactionStoreStockItem(ref ItemID, sStoreID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SearchItemAdvanceStock(ref TextBox ItemID, ref TextBox SubCategoryID, ref TextBox SerialNo, string sStoreID)
        {
            try
            {
                SubCategoryID.Tag = "default";
                SubCategoryID.Text = "default";
                SerialNo.Tag = "0";
                SerialNo.Text = "0";

                if (clsConfig.sItemSearchType == ItemSearchType.Basic.ToString())
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);
                else if (clsConfig.sItemSearchType == ItemSearchType.Transaction.ToString())
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);

                //else if (clsConfig.sItemSearchType == ItemSearchType.Advance1.ToString())
                //    clsSearch.Search_AdvanceItemMaster1(ref ItemID, ref SubCategoryID, ref SerialNo);
                //else if (clsConfig.sItemSearchType == ItemSearchType.Advance2.ToString())
                //    clsSearch.Search_AdvanceItemMaster2(ref ItemID, ref SubCategoryID, ref SerialNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SearchItemAdvanceByKeyPress(ref TextBox ItemID, ref TextBox SubCategoryID, ref TextBox SerialNo, KeyEventArgs key)
        {
            try
            {
                if (key.KeyCode == Keys.F1)
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);
                else if (key.KeyCode == Keys.F2)
                    clsSearch.Search_ItemMaster(ref ItemID, null, null, null, false);
                //else if (key.KeyCode == Keys.F3)
                //    clsSearch.Search_AdvanceItemMaster1(ref ItemID, ref SubCategoryID, ref SerialNo);
                //else if (key.KeyCode == Keys.F4)
                //    clsSearch.Search_AdvanceItemMaster2(ref ItemID, ref SubCategoryID, ref SerialNo);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Search Item By ItemTypID
        public static string ItemSearchByItemTypeID(string sItemTypeID, int iFormID, bool bAutoFill)
        {
            string sItemID = "";
            try
            {
                if (sItemTypeID.Length > 0)
                {
                    if (sItemTypeID == clsAutocode.getItemTypeID(ItemTypes.FinishGood))
                    {
                        //if (Application.ProductName.ToLower() == "epack")
                        //{
                        //    frm_masItemCreation_FinishedGood frm = new frm_masItemCreation_FinishedGood();
                        //    if (frm.bNoAccess)
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    else
                        //    {
                        //        frm.bglbAutoFill = bAutoFill;
                        //        frm.ShowDialog();
                        //        tbl_genItemMaster item = tbl_genItemMaster.Select(frm_masItemCreation_FinishedGood.glbItemID);
                        //        if (item != null)
                        //            sItemID = item.Item_ID;
                        //    }
                        //}
                        //    if (Application.ProductName.ToLower() == "crystal")
                        //    {
                        //        frm_masItemCreation_FinishedGood_Pvc frm = new frm_masItemCreation_FinishedGood_Pvc();
                        //        if (frm.bNoAccess)
                        //            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        else
                        //        {
                        //            frm.ShowDialog();
                        //            tbl_genItemMaster item = tbl_genItemMaster.Select(frm_masItemCreation_FinishedGood_Pvc.glbItemID);
                        //            if (item != null)
                        //                sItemID = item.Item_ID;
                        //        }
                        //    }
                        //}
                        //else if (sItemTypeID == clsAutocode.getItemTypeID(ItemTypes.SemiFinishedGood))
                        //{
                        //    frm_masItemCreation_SemiFinishedGood frm = new frm_masItemCreation_SemiFinishedGood();
                        //    if (frm.bNoAccess)
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    else
                        //    {
                        //        frm.ShowDialog();
                        //        tbl_genItemMaster item = tbl_genItemMaster.Select(frm_masItemCreation_SemiFinishedGood.glbItemID);
                        //        if (item != null)
                        //            sItemID = item.Item_ID;
                        //    }
                        //}
                        //else if (sItemTypeID == clsAutocode.getItemTypeID(ItemTypes.CombinationMaterial))
                        //{
                        //    frm_masItemCreation_CombinationMaterial frm = new frm_masItemCreation_CombinationMaterial();
                        //    if (frm.bNoAccess)
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    else
                        //    {
                        //        frm.ShowDialog();
                        //        tbl_genItemMaster item = tbl_genItemMaster.Select(frm_masItemCreation_CombinationMaterial.glbItemID);
                        //        if (item != null)
                        //            sItemID = item.Item_ID;
                        //    }
                        //}
                        //else if (sItemTypeID == clsAutocode.getItemTypeID(ItemTypes.LaminatedMaterial))
                        //{
                        //    frm_masItemCreation_LaminatedMaterialSingle frm = new frm_masItemCreation_LaminatedMaterialSingle();
                        //    if (frm.bNoAccess)
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    else
                        //    {
                        //        frm.ShowDialog();
                        //        tbl_genItemMaster item = tbl_genItemMaster.Select(frm_masItemCreation_LaminatedMaterialSingle.glbItemID);
                        //        if (item != null)
                        //            sItemID = item.Item_ID;
                        //    }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return sItemID;
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
                    //sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Thickness / dTranslateValue).ToString() + " X ";
                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Gusset / dTranslateValue).ToString() + " X ";
                    sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(oItem.Height / dTranslateValue).ToString() + "  " + clsGenaralName.getName_ItemJobMeasurementTypeName(sItem_ID);
                }
            }
            return sValue;
        }
        #endregion


        //prodcution Job

        #region Get ProductionJobID By CustomerID
        public static string GetProductionJobIDByCustomerOrderID(string sCustomerOrderID) //not Recomended method
        {
            string value = "default";
            try
            {
                List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(sCustomerOrderID);
                foreach (tbl_pmsProductionJobRegister detail in details)
                {
                    value = detail.ProductionJob_ID;
                    break;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return value;
        }
        #endregion

        #region Get Combination Material By ProductionJob_ID
        public static string getCombinationMaterialByProductionJobID(string sProductionJob_ID)
        {
            string sValue = "";
            tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
            if (oJR != null)
            {
                List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
                foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
                {
                    if (oJRMaterial.IsPolythine)
                    {
                        if (oJRMaterial.PolytheneMaterailType_ID != "default")
                        {
                            tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
                            sValue += pmt.PolytheneMaterailTypeName.ToString() + " + ";
                        }
                    }
                    if (oJRMaterial.IsLamination)
                    {
                        if (oJRMaterial.LaminationMaterailType_ID != "default")
                        {
                            tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
                            sValue += lmt.LaminationMaterailTypeName.ToString() + " + ";
                        }
                    }
                }
            }
            return sValue;
        }
        public static string getCombinationMaterialThicknessByProductionJobID(string sProductionJob_ID)
        {
            string sValue = "";
            tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
            if (oJR != null)
            {
                List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
                foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
                {
                    decimal dThickness = oJR.ProductionJobType_ID == "PJT/003" || oJR.ProductionJobType_ID == "PJT/004" ? (oJRMaterial.Thickness * 4) : oJRMaterial.Thickness;
                    if (oJRMaterial.IsPolythine)
                    {
                        if (oJRMaterial.PolytheneMaterailType_ID != "default")
                        {
                            tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
                            sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + " + ";
                        }
                    }
                    if (oJRMaterial.IsLamination)
                    {
                        if (oJRMaterial.LaminationMaterailType_ID != "default")
                        {
                            tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
                            sValue += clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + " + ";
                        }
                    }
                }
            }
            return sValue;
        }
        public static List<string> getCombinationMaterialListByProductionJobID(string sProductionJob_ID, bool bShowWeight)
        {
            List<string> sValue = new List<string>();
            tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
            if (oJR != null)
            {
                List<tbl_sasJobRegister_Material> oJRMaterials = tbl_sasJobRegister_Material.SelectAllByJob_ID(oJR.Job_ID);
                foreach (tbl_sasJobRegister_Material oJRMaterial in oJRMaterials)
                {
                    decimal dThickness = oJR.ProductionJobType_ID == "PJT/003" || oJR.ProductionJobType_ID == "PJT/004" ? (oJRMaterial.Thickness * 4) : oJRMaterial.Thickness;
                    string sWeight = bShowWeight ? " - " + clsFormatter.FormatToCurrecyWithThreeDecimalPlaces(oJRMaterial.Width) + "kg" : "";
                    if (oJRMaterial.IsPolythine)
                    {
                        if (oJRMaterial.PolytheneMaterailType_ID != "default")
                        {
                            tbl_zJobPolytheneMaterialType pmt = tbl_zJobPolytheneMaterialType.Select(oJRMaterial.PolytheneMaterailType_ID);
                            if (pmt != null)
                                sValue.Add(pmt.PolytheneMaterailTypeName.ToString() + "  -  " + clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + sWeight);
                        }
                    }
                    if (oJRMaterial.IsLamination)
                    {
                        if (oJRMaterial.LaminationMaterailType_ID != "default")
                        {
                            tbl_zJobLaminationMaterialType lmt = tbl_zJobLaminationMaterialType.Select(oJRMaterial.LaminationMaterailType_ID);
                            if (lmt != null)
                                sValue.Add(lmt.LaminationMaterailTypeName.ToString() + "  -  " + clsFormatter.FormatToNumberWithTwoDecimalPlaces(dThickness) + sWeight);
                        }
                    }
                }
            }
            return sValue;
        }
        #endregion

        #region Get Customer PO No By ProductionJobID
        public static string GetPONoByProductionJobID(string sProductionJob_ID)
        {
            string sValue = "";
            tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
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
        public static string getProductionJobType_Simple(string sProductionJob_ID)
        {

            string sValue = "";
            tbl_pmsProductionJobRegister oJR = tbl_pmsProductionJobRegister.Select(sProductionJob_ID);
            if (oJR != null)
            {
                tbl_zJobProductionJobType oProductionJobType = tbl_zJobProductionJobType.Select(oJR.ProductionJobType_ID);
                if (oProductionJobType != null)
                {

                    switch (oProductionJobType.ProductionJobType_ID)
                    {
                        case "PJT/001":
                            sValue = "KDDN";
                            break;
                        case "PJT/002":
                            sValue = "KDDN";
                            break;
                        case "PJT/003":
                            sValue = "PTDN";
                            break;
                        case "PJT/004":
                            sValue = "PTDN";
                            break;
                        case "PJT/007":
                            sValue = "KDDN";
                            break;
                        case "PJT/008":
                            sValue = "PTDN";
                            break;
                        case "default":
                            sValue = "";
                            break;
                    }
                }

            }
            return sValue;
        }
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
        public static decimal GetJobStandardWeightBy_CustomerOrderID(string sCustomerOrderID)
        {
            decimal dValue = 0;
            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCustomerOrderID);
            if (oCO != null && oCO.Job_ID != null)
            {
                foreach (tbl_sasJobRegister_Material oMaterial in tbl_sasJobRegister_Material.SelectAllByJob_ID(oCO.Job_ID))
                {
                    dValue += oMaterial.Width;
                }
            }
            return dValue;
        }
        public static decimal GetJobStandardWeightBy_SalesJobID(string sSalesJobID)
        {
            decimal dValue = 0;
            foreach (tbl_sasJobRegister_Material oMaterial in tbl_sasJobRegister_Material.SelectAllByJob_ID(sSalesJobID))
            {
                dValue += oMaterial.Width;
            }
            return dValue;
        }
        #endregion
        // Cheque
        //public static void FillSectionDetailFromGRN_ID(string sGRN_ID, TextBox myTextBox)
        //{
        //    tbl_scsSectionGoodReceiveNote detail = tbl_scsSectionGoodReceiveNote.Select(sGRN_ID);
        //    if (detail != null)
        //    {
        //        myTextBox.Tag = detail.ToSection_ID;
        //        myTextBox.Text = clsGenaralName.getName_Section(detail.ToSection_ID);
        //    }
        //}
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

        // Invoice Sattlement

        #region Settelements
        public static decimal AutoSettledJEWithCash(string sJournalEntryID, int LineNo_JE, string sChqRegisterID, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            decimal dAllocatedAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
                {
                    decimal dJeToBeSettled = 0, dReceiptAvailableAmount = 0;

                    List<tbl_accJournalEntry_Detail> JE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Line_No == LineNo_JE).ToList();
                    tbl_accJournalEntry_Detail JournalEntry = JE.FirstOrDefault();
                    tbl_bpsChequeRegister oReceipt = tbl_bpsChequeRegister.Select(sChqRegisterID);
                    if (JournalEntry != null && oReceipt != null)
                    {
                        #region Allocation Date
                        DateTime dtmAllocationDate = oReceipt.DateRegister;
                        tbl_accJournalEntry oJE = tbl_accJournalEntry.Select(JournalEntry.JournalEntry_ID);
                        if (oJE != null)
                        {
                            if (oJE.JournalEntryDate > dtmAllocationDate)
                                dtmAllocationDate = oJE.JournalEntryDate;
                        }
                        #endregion

                        dReceiptAvailableAmount = (oReceipt.Amount - oReceipt.SetteledAmount);
                        // if (dAmountToBeSettled > 0 && (oInvoice.GrandTotal - oInvoice.SeattleAmount) >= dAmountToBeSettled)
                        //     dJeToBeSettled = dAmountToBeSettled;
                        // else
                        dJeToBeSettled = JournalEntry.Amount - JournalEntry.SeattleAmount;

                        if (dReceiptAvailableAmount > 0 && dJeToBeSettled > 0)
                        {
                            if (dJeToBeSettled <= dReceiptAvailableAmount) //if Receipt has enough cash to settled
                            {
                                dAllocatedAmount = dJeToBeSettled;

                                JournalEntry.SeattleAmount += dJeToBeSettled;
                                oReceipt.SetteledAmount += dJeToBeSettled;

                                JournalEntry.IsSeattled = (JournalEntry.Amount == JournalEntry.SeattleAmount) ? true : false;
                                oReceipt.IsSetteled = (oReceipt.Amount == oReceipt.SetteledAmount) ? true : false;

                                JournalEntry.Update();
                                oReceipt.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, "default", sChqRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cash).ToString(), dtmAllocationDate, dJeToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);
                            }
                            else //if Invoice amount is greter than receipt amount
                            {
                                dAllocatedAmount = dReceiptAvailableAmount;
                                JournalEntry.SeattleAmount += dReceiptAvailableAmount;
                                oReceipt.SetteledAmount += dReceiptAvailableAmount;

                                JournalEntry.IsSeattled = (JournalEntry.Amount == JournalEntry.SeattleAmount) ? true : false;
                                oReceipt.IsSetteled = (oReceipt.Amount == oReceipt.SetteledAmount) ? true : false;

                                JournalEntry.Update();
                                oReceipt.Update();

                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, "default", sChqRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cash).ToString(), dtmAllocationDate, dReceiptAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
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
            return dAllocatedAmount;
        }
        public static decimal AutoSettledJEWithCheque(string sJournalEntryID, int LineNo_JE, string sChequeRegisterID, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            decimal dAllocatedAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
                {
                    decimal dJEToBeSettled = 0, dChequeAvailableAmount = 0;
                    List<tbl_accJournalEntry_Detail> JE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Line_No == LineNo_JE).ToList();
                    tbl_accJournalEntry_Detail JournalEntry = JE.FirstOrDefault();
                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                    if (JournalEntry != null && oCheque != null)
                    {
                        #region Allocation Date
                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCheque.Receipt_ID);
                        DateTime dtmAllocationDate = oReceipt.ReceiptDate;
                        tbl_accJournalEntry oJE = tbl_accJournalEntry.Select(JournalEntry.JournalEntry_ID);
                        if (oJE != null)
                        {
                            if (oJE.JournalEntryDate > dtmAllocationDate)
                                dtmAllocationDate = oJE.JournalEntryDate;
                        }
                        #endregion

                        dJEToBeSettled = JournalEntry.Amount - JournalEntry.SeattleAmount;
                        //  if (dAmountToBeSettled > 0 && (oInvoice.GrandTotal - oInvoice.SeattleAmount) >= dAmountToBeSettled)
                        //      dJEToBeSettled = dAmountToBeSettled;
                        dChequeAvailableAmount = oCheque.Amount - oCheque.SetteledAmount;

                        if (dChequeAvailableAmount > 0 && dJEToBeSettled > 0)
                        {
                            if (dJEToBeSettled <= dChequeAvailableAmount) //if Receipt has enough cash to settled
                            {
                                dAllocatedAmount = dJEToBeSettled;
                                JournalEntry.SeattleAmount += dJEToBeSettled;
                                oCheque.SetteledAmount += dJEToBeSettled;

                                JournalEntry.IsSeattled = (JournalEntry.Amount == JournalEntry.SeattleAmount) ? true : false;
                                oCheque.IsSetteled = oCheque.Amount == oCheque.SetteledAmount ? true : false;

                                JournalEntry.Update();
                                oCheque.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, oCheque.Receipt_ID, sChequeRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dJEToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);
                            }
                            else //if Invoice amount is greter than receipt amount
                            {
                                dAllocatedAmount = dChequeAvailableAmount;
                                JournalEntry.SeattleAmount += dChequeAvailableAmount;
                                oCheque.SetteledAmount += dChequeAvailableAmount;

                                JournalEntry.IsSeattled = JournalEntry.Amount == JournalEntry.SeattleAmount ? true : false;
                                oCheque.IsSetteled = oCheque.Amount == oCheque.SetteledAmount ? true : false;

                                JournalEntry.Update();
                                oCheque.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, oCheque.Receipt_ID, sChequeRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dChequeAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
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
            return dAllocatedAmount;
        }
        public static decimal AutoSettledJEWithCreditNote(string sJournalEntryID, int LineNo_JE, string sCreditNoteID, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            decimal dInvSettledAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWithCreditNote))
                {
                    decimal dJEToBeSettled = 0, dCreditNoteAvailableAmount = 0;

                    List<tbl_accJournalEntry_Detail> JE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Line_No == LineNo_JE).ToList();
                    tbl_accJournalEntry_Detail JournalEntry = JE.FirstOrDefault();

                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(sCreditNoteID);
                    if (JournalEntry != null && oCreditNote != null)
                    {
                        string sSettlement_ID = "";

                        #region Allocation Date
                        DateTime dtmAllocationDate = oCreditNote.CreditNoteDate; ;
                        tbl_accJournalEntry oJE = tbl_accJournalEntry.Select(JournalEntry.JournalEntry_ID);
                        if (oJE != null)
                        {
                            if (oJE.JournalEntryDate > dtmAllocationDate)
                                dtmAllocationDate = oJE.JournalEntryDate;
                        }
                        #endregion

                        dJEToBeSettled = JournalEntry.Amount - JournalEntry.SeattleAmount;
                        dCreditNoteAvailableAmount = oCreditNote.TotalAmount - oCreditNote.SeattleAmount;

                        #region MyRegion
                        if (dCreditNoteAvailableAmount > 0 && dJEToBeSettled > 0)
                        {
                            if (dJEToBeSettled <= dCreditNoteAvailableAmount) //if Credit Note has enough cash to settled
                            {
                                JournalEntry.SeattleAmount += dJEToBeSettled;
                                oCreditNote.SeattleAmount += dJEToBeSettled;

                                JournalEntry.IsSeattled = JournalEntry.Amount == JournalEntry.SeattleAmount ? true : false;
                                oCreditNote.IsSeattled = oCreditNote.TotalAmount == oCreditNote.SeattleAmount ? true : false;

                                JournalEntry.Update();
                                oCreditNote.Update();

                                sSettlement_ID = clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, "default", "default", sCreditNoteID, "default", "default", -1, "default", dtmAllocationDate, dJEToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);

                                dInvSettledAmount = dJEToBeSettled;
                            }
                            else //if Invoice amount is greter than credit note amount
                            {
                                JournalEntry.SeattleAmount += dCreditNoteAvailableAmount;
                                oCreditNote.SeattleAmount += dCreditNoteAvailableAmount;

                                JournalEntry.IsSeattled = JournalEntry.Amount == JournalEntry.SeattleAmount ? true : false;
                                oCreditNote.IsSeattled = oCreditNote.TotalAmount == oCreditNote.SeattleAmount ? true : false;

                                JournalEntry.Update();
                                oCreditNote.Update();

                                sSettlement_ID = clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntry.JournalEntry_ID, JournalEntry.Line_No, "default", "default", sCreditNoteID, "default", "default", -1, "default", dtmAllocationDate, dCreditNoteAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);

                                dInvSettledAmount = dCreditNoteAvailableAmount;
                            }
                        }
                        #endregion

                        //     clsMethods_GL.PostTransaction_Allocation(sSettlement_ID);
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
        public static decimal AutoSettledJEWithJE(string sJournalEntryID_DR, int LineNo_JEDR, string sJournalEntryID_CR, int LineNo_JECR, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment, string sCustomerID)
        {
            decimal dAllocatedAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
                {
                    decimal dJEDRToBeSettled = 0, dJEAvailableAmount = 0;
                    List<tbl_accJournalEntry_Detail> JEDR = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID_DR).Where(p => p.Line_No == LineNo_JEDR).ToList();
                    tbl_accJournalEntry_Detail JournalEntryDR = JEDR.FirstOrDefault();

                    List<tbl_accJournalEntry_Detail> JECR = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID_CR).Where(p => p.Line_No == LineNo_JECR).ToList();
                    tbl_accJournalEntry_Detail JournalEntryCR = JECR.FirstOrDefault();

                    if (JournalEntryDR != null && JournalEntryCR != null)
                    {
                        #region Allocation Date
                        DateTime dtmAllocationDate = DateTime.Now;
                        tbl_accJournalEntry oJEDR = tbl_accJournalEntry.Select(JournalEntryDR.JournalEntry_ID);
                        if (oJEDR != null)
                            dtmAllocationDate = oJEDR.JournalEntryDate;

                        tbl_accJournalEntry oJECR = tbl_accJournalEntry.Select(JournalEntryCR.JournalEntry_ID);
                        if (oJECR != null)
                        {
                            if (oJECR.JournalEntryDate > dtmAllocationDate)
                                dtmAllocationDate = oJECR.JournalEntryDate;
                        }
                        #endregion

                        dJEDRToBeSettled = JournalEntryDR.Amount - JournalEntryDR.SeattleAmount;
                        dJEAvailableAmount = JournalEntryCR.Amount - JournalEntryCR.SeattleAmount;

                        if (dJEAvailableAmount > 0 && dJEDRToBeSettled > 0)
                        {
                            if (dJEDRToBeSettled <= dJEAvailableAmount)
                            {
                                dAllocatedAmount = dJEDRToBeSettled;
                                JournalEntryDR.SeattleAmount += dJEDRToBeSettled;
                                JournalEntryCR.SeattleAmount += dJEDRToBeSettled;

                                JournalEntryDR.IsSeattled = (JournalEntryDR.Amount == JournalEntryDR.SeattleAmount) ? true : false;
                                JournalEntryCR.IsSeattled = (JournalEntryCR.Amount == JournalEntryCR.SeattleAmount) ? true : false;

                                JournalEntryDR.Update();
                                JournalEntryCR.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntryDR.JournalEntry_ID, JournalEntryDR.Line_No, "default", "default", "default", "default", JournalEntryCR.JournalEntry_ID, LineNo_JECR, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dAllocatedAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
                            }
                            else
                            {
                                dAllocatedAmount = dJEAvailableAmount;
                                JournalEntryDR.SeattleAmount += dJEAvailableAmount;
                                JournalEntryCR.SeattleAmount += dJEAvailableAmount;

                                JournalEntryDR.IsSeattled = JournalEntryDR.Amount == JournalEntryDR.SeattleAmount ? true : false;
                                JournalEntryCR.IsSeattled = JournalEntryCR.Amount == JournalEntryCR.SeattleAmount ? true : false;

                                JournalEntryDR.Update();
                                JournalEntryCR.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord("default", JournalEntryDR.JournalEntry_ID, JournalEntryDR.Line_No, "default", "default", "default", "default", JournalEntryCR.JournalEntry_ID, LineNo_JECR, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dAllocatedAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
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
            return dAllocatedAmount;
        }
        #endregion

        #region Invoice Settled - With Cash
        //public static decimal AutoSettledInvoiceWithCash(string sInvoiceID, string sReceiptID, decimal dAmountToBeSettled, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        //{
        //    decimal dAllocatedAmount = 0;
        //    try
        //    {
        //        if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
        //        {
        //            decimal dInvoiceToBeSettled = 0, dReceiptAvailableAmount = 0;
        //            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
        //            tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
        //            if (oInvoice != null && oReceipt != null)
        //            {
        //                #region Allocation Date
        //                DateTime dtmAllocationDate = oInvoice.InvoiceDate;
        //                if (oReceipt.ReceiptDate > oInvoice.InvoiceDate)
        //                    dtmAllocationDate = oReceipt.ReceiptDate;
        //                #endregion

        //                dReceiptAvailableAmount = oReceipt.CashAmount - oReceipt.SeattleAmount;
        //                if (dAmountToBeSettled > 0 && (oInvoice.GrandTotal - oInvoice.SeattleAmount) >= dAmountToBeSettled)
        //                    dInvoiceToBeSettled = dAmountToBeSettled;
        //                else
        //                    dInvoiceToBeSettled = oInvoice.GrandTotal - oInvoice.SeattleAmount;

        //                if (dReceiptAvailableAmount > 0 && dInvoiceToBeSettled > 0)
        //                {
        //                    if (dInvoiceToBeSettled <= dReceiptAvailableAmount) //if Receipt has enough cash to settled
        //                    {
        //                        dAllocatedAmount = dInvoiceToBeSettled;

        //                        oInvoice.SeattleAmount += dInvoiceToBeSettled;
        //                        oReceipt.SeattleAmount += dInvoiceToBeSettled;

        //                        oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
        //                        oReceipt.IsSeattled = oReceipt.CashAmount == oReceipt.SeattleAmount ? true : false;

        //                        oInvoice.Update();
        //                        oReceipt.Update();
        //                        clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID,"default",-1, sReceiptID, "default", "default", "default", "default",-1, clsConfig.sPaymentMethod_Cash, dtmAllocationDate, dInvoiceToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);
        //                    }
        //                    else //if Invoice amount is greter than receipt amount
        //                    {
        //                        dAllocatedAmount = dReceiptAvailableAmount;
        //                        oInvoice.SeattleAmount += dReceiptAvailableAmount;
        //                        oReceipt.SeattleAmount += dReceiptAvailableAmount;

        //                        oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
        //                        oReceipt.IsSeattled = oReceipt.CashAmount == oReceipt.SeattleAmount ? true : false;

        //                        oInvoice.Update();
        //                        oReceipt.Update();
        //                        clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, sReceiptID, "default", "default", "default", "default",-1, clsConfig.sPaymentMethod_Cash, dtmAllocationDate, dReceiptAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", 0,ex);
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return dAllocatedAmount;
        //}
        #endregion

        #region Invoice Settled - With Cheque
        public static decimal AutoSettledInvoiceWithCheque(string sInvoiceID, string sChequeRegisterID, decimal dAmountToBeSettled, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment)
        {
            decimal dAllocatedAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
                {
                    decimal dInvoiceToBeSettled = 0, dChequeAvailableAmount = 0;
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                    if (oInvoice != null && oCheque != null)
                    {
                        DateTime dtmAllocationDate = oInvoice.InvoiceDate;
                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCheque.Receipt_ID);
                        if (oReceipt != null)
                        {
                            #region Allocation Date
                            if (oReceipt.ReceiptDate > oInvoice.InvoiceDate)
                                dtmAllocationDate = oReceipt.ReceiptDate;
                            #endregion
                        }

                        dInvoiceToBeSettled = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                        if (dAmountToBeSettled > 0 && (oInvoice.GrandTotal - oInvoice.SeattleAmount) >= dAmountToBeSettled)
                            dInvoiceToBeSettled = dAmountToBeSettled;
                        dChequeAvailableAmount = oCheque.Amount - oCheque.SetteledAmount;

                        if (dChequeAvailableAmount > 0 && dInvoiceToBeSettled > 0)
                        {
                            if (dInvoiceToBeSettled <= dChequeAvailableAmount) //if Receipt has enough cash to settled
                            {
                                dAllocatedAmount = dInvoiceToBeSettled;
                                oInvoice.SeattleAmount += dInvoiceToBeSettled;
                                oCheque.SetteledAmount += dInvoiceToBeSettled;

                                oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
                                oCheque.IsSetteled = oCheque.Amount == oCheque.SetteledAmount ? true : false;

                                oInvoice.Update();
                                oCheque.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, oCheque.Receipt_ID, sChequeRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dInvoiceToBeSettled, sAllocationID, bIsAdvancePayment, bIsOverPayment);
                            }
                            else //if Invoice amount is greter than receipt amount
                            {
                                dAllocatedAmount = dChequeAvailableAmount;
                                oInvoice.SeattleAmount += dChequeAvailableAmount;
                                oCheque.SetteledAmount += dChequeAvailableAmount;

                                oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
                                oCheque.IsSetteled = oCheque.Amount == oCheque.SetteledAmount ? true : false;

                                oInvoice.Update();
                                oCheque.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, oCheque.Receipt_ID, sChequeRegisterID, "default", "default", "default", -1, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dChequeAvailableAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
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
            return dAllocatedAmount;
        }
        #endregion

        #region Invoice Settled - With Journal Entry
        public static decimal AutoSettledInvoiceWithJE(string sInvoiceID, string sJournalEntryID, int LineNo_JE, string sAllocationID, bool bIsAdvancePayment, bool bIsOverPayment, string sCustomerID)
        {
            decimal dAllocatedAmount = 0;
            try
            {
                if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
                {
                    decimal dInvoiceToBeSettled = 0, dJEAvailableAmount = 0;
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);

                    List<tbl_accJournalEntry_Detail> JE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Line_No == LineNo_JE).ToList();
                    tbl_accJournalEntry_Detail JournalEntry = JE.FirstOrDefault();

                    if (oInvoice != null && JournalEntry != null)
                    {
                        #region Allocation Date
                        DateTime dtmAllocationDate = oInvoice.InvoiceDate;
                        tbl_accJournalEntry oJE = tbl_accJournalEntry.Select(JournalEntry.JournalEntry_ID);
                        if (oJE != null)
                        {
                            if (oJE.JournalEntryDate > oInvoice.InvoiceDate)
                                dtmAllocationDate = oJE.JournalEntryDate;
                        }
                        #endregion

                        dInvoiceToBeSettled = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                        dJEAvailableAmount = JournalEntry.Amount - JournalEntry.SeattleAmount;

                        if (dJEAvailableAmount > 0 && dInvoiceToBeSettled > 0)
                        {
                            if (dInvoiceToBeSettled <= dJEAvailableAmount)
                            {
                                dAllocatedAmount = dInvoiceToBeSettled;
                                oInvoice.SeattleAmount += dInvoiceToBeSettled;
                                JournalEntry.SeattleAmount += dInvoiceToBeSettled;

                                oInvoice.IsSeattled = (oInvoice.GrandTotal == oInvoice.SeattleAmount) ? true : false;
                                JournalEntry.IsSeattled = (JournalEntry.Amount == JournalEntry.SeattleAmount) ? true : false;

                                oInvoice.Update();
                                JournalEntry.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, "default", "default", "default", "default", JournalEntry.JournalEntry_ID, LineNo_JE, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dAllocatedAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
                            }
                            else
                            {
                                dAllocatedAmount = dJEAvailableAmount;
                                oInvoice.SeattleAmount += dJEAvailableAmount;
                                JournalEntry.SeattleAmount += dJEAvailableAmount;

                                oInvoice.IsSeattled = oInvoice.GrandTotal == oInvoice.SeattleAmount ? true : false;
                                JournalEntry.IsSeattled = JournalEntry.Amount == JournalEntry.SeattleAmount ? true : false;

                                oInvoice.Update();
                                JournalEntry.Update();
                                clsHelpMethods.InsertInvoiceSettlementRecord(sInvoiceID, "default", -1, "default", "default", "default", "default", JournalEntry.JournalEntry_ID, LineNo_JE, ((int)PaymentMethod.Cheque).ToString(), dtmAllocationDate, dAllocatedAmount, sAllocationID, bIsAdvancePayment, bIsOverPayment);
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
            return dAllocatedAmount;
        }
        #endregion

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



        #region Settle APN To Debit Note
        public static decimal AutoSettleDebitNoteWithAPN(string sAPnID, string sDBNID, DateTime dtmDateAllocation, decimal dAmountToBeSettled, string sAllocationID, int lineNo, ref bool bIsEnoughDbnAmountToSettledApn)
        {
            tbl_accDebitNote oDebitNote = tbl_accDebitNote.Select(sDBNID);
            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPnID);
            decimal dDebitNoteAvailableAmount = 0, dDBN_AmountToBeSettled = 0, dAllocationAmount = 0;
            bool bIsDBNSettled = false;

            if (oDebitNote != null && oAPN != null)
            {
                if (oDebitNote.DebitNote_ID != "default" && oAPN.AccountPayableNote_ID != "default")
                {
                    dDebitNoteAvailableAmount = oDebitNote.GrandTotal - oDebitNote.SettledAmount;

                    if (dDebitNoteAvailableAmount >= dAmountToBeSettled)
                    {
                        if (dAmountToBeSettled > 0 && (oAPN.GrandTotal - oAPN.SettledAmount) >= dAmountToBeSettled)
                            dDBN_AmountToBeSettled = dAmountToBeSettled;
                        else
                            dDBN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;

                        if (dDebitNoteAvailableAmount >= dDBN_AmountToBeSettled)//Debit Note Have enough amount to settle apn
                        {
                            dAllocationAmount = dDBN_AmountToBeSettled;
                            oAPN.SettledAmount += dAllocationAmount;
                            oAPN.IsSeattled = (oAPN.GrandTotal <= oAPN.SettledAmount) ? true : false;
                            oAPN.Update();

                            oDebitNote.SettledAmount += dAllocationAmount;
                            bIsDBNSettled = oDebitNote.IsSettled = (oDebitNote.GrandTotal <= oDebitNote.SettledAmount) ? true : false;
                            oDebitNote.Update();
                        }
                        else//Debit Note doesn't Have enough amount to settle apn
                        {
                            dAllocationAmount = dDebitNoteAvailableAmount;
                            oAPN.SettledAmount += dAllocationAmount;
                            oAPN.IsSeattled = (oAPN.GrandTotal <= oAPN.SettledAmount) ? true : false;
                            oAPN.Update();

                            oDebitNote.SettledAmount += dAllocationAmount;
                            bIsDBNSettled = oDebitNote.IsSettled = (oDebitNote.GrandTotal <= oDebitNote.SettledAmount) ? true : false;
                            oDebitNote.Update();
                        }

                        tbl_accPaymentVoucher_Detail oPVDetail_Update = new tbl_accPaymentVoucher_Detail(lineNo, "default", oAPN.AccountPayableNote_ID, "default", oDebitNote.DebitNote_ID, "default", "default", -1, "default", -1, oAPN.Narration, dAllocationAmount, bIsDBNSettled);
                        oPVDetail_Update.Insert();

                    }
                    else
                    {
                        bIsEnoughDbnAmountToSettledApn = false;
                        MessageBox.Show("DBN Amount Not Enough to Settle APN......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            return dAllocationAmount;
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


        #region Remove Settlements - From ReceiptID - Cash
        public static void RemoveSattlementsFrom_ReceiptID_OnlyCash(string sReceiptID)
        {
            try
            {
                decimal dSattledAmount = 0;
                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
                if (oReceipt != null)
                {
                    foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => p.ChequeRegister_ID == "default"))
                    {
                        //validate record
                        if (settlement.Invoice_ID != "default" && settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID == "default")
                        {
                            dSattledAmount = settlement.SattledAmount;
                            if (dSattledAmount > 0)
                            {
                                //update cheque detail
                                oReceipt.SeattleAmount -= dSattledAmount;
                                oReceipt.IsSeattled = false;
                                oReceipt.Update();

                                //update invoice detail
                                tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                                if (oldInvoice != null && dSattledAmount > 0)
                                {
                                    oldInvoice.SeattleAmount -= dSattledAmount;
                                    oldInvoice.IsSeattled = false;
                                    oldInvoice.Update();
                                }

                                //delete receipt invoice settlement details
                                tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oReceipt.Receipt_ID);

                                //remove Sattlement record
                                settlement.Delete();
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
        }
        public static void RemoveSattlementsFrom_ReceiptID_CashAndCheque(string sReceiptID)
        {
            try
            {
                decimal dSattledAmount = 0;
                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sReceiptID);
                if (oReceipt != null)
                {
                    List<tbl_sasInvoice_Sattled> settlements = tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(oReceipt.Receipt_ID);
                    foreach (tbl_sasInvoice_Sattled settlement in settlements)
                    {
                        //validate record
                        //#region Cash
                        //if (settlement.Invoice_ID != "default" && settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID == "default")
                        //{
                        //    dSattledAmount = settlement.SattledAmount;
                        //    if (dSattledAmount > 0)
                        //    {
                        //        //update cheque detail
                        //        oReceipt.SeattleAmount -= dSattledAmount;
                        //        oReceipt.IsSeattled = false;
                        //        oReceipt.Update();

                        //        //update invoice detail
                        //        tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                        //        if (oldInvoice != null && dSattledAmount > 0)
                        //        {
                        //            oldInvoice.SeattleAmount -= dSattledAmount;
                        //            oldInvoice.IsSeattled = false;
                        //            oldInvoice.Update();
                        //        }

                        //        //delete receipt invoice settlement details
                        //        tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oReceipt.Receipt_ID);

                        //        //remove Sattlement record
                        //        settlement.Delete();
                        //    }
                        //}
                        //#endregion

                        #region Cheque
                        if (settlement.Invoice_ID != "default" && settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID != "default")
                        {
                            dSattledAmount = settlement.SattledAmount;
                            if (dSattledAmount > 0)
                            {
                                //update cheque detail
                                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                                if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                                {
                                    oCheque.SetteledAmount -= dSattledAmount;
                                    oCheque.IsSetteled = false;
                                    oCheque.Update();
                                }

                                //update invoice detail
                                tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                                if (oldInvoice != null && dSattledAmount > 0)
                                {
                                    oldInvoice.SeattleAmount -= dSattledAmount;
                                    oldInvoice.IsSeattled = false;
                                    oldInvoice.Update();
                                }

                                //delete receipt invoice settlement details
                                tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oReceipt.Receipt_ID);

                                //remove Sattlement record
                                settlement.Delete();
                            }
                        }
                        #endregion

                        #region JE CASH
                        if ((settlement.JournalEntry_ID_CR != "default" || settlement.JournalEntry_ID_DR != "default") && settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID == "default")
                        {
                            dSattledAmount = settlement.SattledAmount;
                            if (dSattledAmount > 0)
                            {
                                //update cheque detail
                                oReceipt.SeattleAmount -= dSattledAmount;
                                oReceipt.IsSeattled = false;
                                oReceipt.Update();

                                List<tbl_accJournalEntry_Detail> oDetail = null;
                                if (settlement.JournalEntry_ID_CR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                                else if (settlement.JournalEntry_ID_DR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                                //update JE detail
                                foreach (tbl_accJournalEntry_Detail oldJE in oDetail)
                                {
                                    oldJE.SeattleAmount -= dSattledAmount;
                                    oldJE.IsSeattled = false;
                                    oldJE.Update();
                                }

                                //delete receipt invoice settlement details
                                tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oReceipt.Receipt_ID);

                                //remove Sattlement record
                                settlement.Delete();
                            }
                        }
                        #endregion

                        #region JE CHEQUE
                        if ((settlement.JournalEntry_ID_CR != "default" || settlement.JournalEntry_ID_DR != "default") && settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID != "default")
                        {
                            dSattledAmount = settlement.SattledAmount;
                            if (dSattledAmount > 0)
                            {
                                //update cheque detail
                                oReceipt.SeattleAmount -= dSattledAmount;
                                oReceipt.IsSeattled = false;
                                oReceipt.Update();

                                List<tbl_accJournalEntry_Detail> oDetail = null;
                                if (settlement.JournalEntry_ID_CR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                                else if (settlement.JournalEntry_ID_DR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                                //update JE detail
                                foreach (tbl_accJournalEntry_Detail oldJE in oDetail)
                                {
                                    oldJE.SeattleAmount -= dSattledAmount;
                                    oldJE.IsSeattled = false;
                                    oldJE.Update();
                                }

                                //delete receipt invoice settlement details
                                tbl_bpsReceipt_Invoice.DeleteAllByReceipt_ID(oReceipt.Receipt_ID);

                                //remove Sattlement record
                                settlement.Delete();
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Remove Settlements - From ChequeID
        public static void RemoveSattlementsFrom_ChequeID(string sChequeRegisterID)
        {
            try
            {
                decimal dSattledAmount = 0;
                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(sChequeRegisterID);
                if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                {
                    foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                    {
                        //validate record
                        if (settlement.Invoice_ID != "default" && settlement.ChequeRegister_ID != "default")
                        {
                            dSattledAmount = settlement.SattledAmount;
                            if (dSattledAmount > 0)
                            {
                                //update cheque detail
                                oCheque.SetteledAmount -= dSattledAmount;
                                oCheque.IsSetteled = false;
                                oCheque.Update();

                                //update invoice detail
                                tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                                if (oldInvoice != null && dSattledAmount > 0)
                                {
                                    oldInvoice.SeattleAmount -= dSattledAmount;
                                    oldInvoice.IsSeattled = false;
                                    oldInvoice.Update();
                                }

                                //remove Sattlement record
                                settlement.Delete();
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
        }
        #endregion

        #region Remove Settlements - From CreditNoteID
        public static bool RemoveSattlementsFrom_CreditNoteID(string sCreditNoteID)
        {
            bool bIsSettlementOk = true;
            try
            {
                tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.Select(sCreditNoteID);
                if (oCRN != null && oCRN.CreditNote_ID != "default")
                {
                    tbl_bpsCreditNote_Invoice.DeleteAllByCreditNote_ID(sCreditNoteID);

                    foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCRN.CreditNote_ID))
                    {
                        if (settlement.Invoice_ID != "default" && settlement.CreditNote_ID != "default")
                        {
                            tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                            if (oldInvoice != null)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    oCRN.SeattleAmount -= settlement.SattledAmount;
                                    oCRN.IsSeattled = false;
                                    oCRN.Update();

                                    oldInvoice.SeattleAmount -= settlement.SattledAmount;
                                    oldInvoice.IsSeattled = false;
                                    oldInvoice.Update();

                                    settlement.Delete();

                                    clsMethods_GL.GLPosting_Delete(settlement.GlPosting_ID);
                                }
                            }
                        }

                        else if ((settlement.JournalEntry_ID_CR != "default" || settlement.JournalEntry_ID_DR != "default") && settlement.CreditNote_ID != "default")
                        {
                            List<tbl_accJournalEntry_Detail> oDetail = null;
                            if (settlement.JournalEntry_ID_CR != "default")
                                oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                            else if (settlement.JournalEntry_ID_DR != "default")
                                oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                            foreach (tbl_accJournalEntry_Detail oJE in oDetail)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    oCRN.SeattleAmount -= settlement.SattledAmount;
                                    oCRN.IsSeattled = false;
                                    oCRN.Update();

                                    oJE.SeattleAmount -= settlement.SattledAmount;
                                    oJE.IsSeattled = false;
                                    oJE.Update();

                                    settlement.Delete();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                bIsSettlementOk = false;
            }
            return bIsSettlementOk;
        }
        #endregion

        #region Remove Settlements - From JournalEntryID
        public static bool RemoveSattlementsFrom_JournalEntryID(string sJournalEntryID)
        {
            bool bIsSettlementOk = true;
            try
            {
                #region Remove Invoice Settlement
                foreach (tbl_accJournalEntry_Detail JEDetail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Customer_ID != "default"))
                {
                    List<tbl_sasInvoice_Sattled> oInvSettle = null;
                    if (JEDetail.IsCredit)
                        oInvSettle = tbl_sasInvoice_Sattled.SelectAll().Where(p => p.JournalEntry_ID_CR == sJournalEntryID && p.LineNo_JECR == JEDetail.Line_No).ToList();
                    else
                        oInvSettle = tbl_sasInvoice_Sattled.SelectAll().Where(p => p.JournalEntry_ID_DR == sJournalEntryID && p.LineNo_JEDR == JEDetail.Line_No).ToList();

                    foreach (tbl_sasInvoice_Sattled settlement in oInvSettle)
                    {
                        #region Invoice
                        //if (settlement.Invoice_ID != "default" && settlement.JournalEntry_ID_DR != "default")
                        if (settlement.Invoice_ID != "default")
                        {
                            tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                            if (oldInvoice != null)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    JEDetail.SeattleAmount -= settlement.SattledAmount;
                                    JEDetail.IsSeattled = false;
                                    JEDetail.Update();

                                    oldInvoice.SeattleAmount -= settlement.SattledAmount;
                                    oldInvoice.IsSeattled = false;
                                    oldInvoice.Update();

                                    settlement.Delete();
                                }
                            }
                        }
                        #endregion

                        #region Receipt
                        ////if (settlement.Receipt_ID != "default" && settlement.JournalEntry_ID_DR != "default")
                        //if (settlement.Receipt_ID != "default" && settlement.ChequeRegister_ID == "default")
                        //{
                        //    tbl_bpsReceipt oldReceipt = tbl_bpsReceipt.Select(settlement.Receipt_ID);
                        //    if (oldReceipt != null)
                        //    {
                        //        if (settlement.SattledAmount > 0)
                        //        {
                        //            JEDetail.SeattleAmount -= settlement.SattledAmount;
                        //            JEDetail.IsSeattled = false;
                        //            JEDetail.Update();

                        //            oldReceipt.SeattleAmount -= settlement.SattledAmount;
                        //            oldReceipt.IsSeattled = false;
                        //            oldReceipt.Update();

                        //            settlement.Delete();
                        //        }
                        //    }
                        //}
                        #endregion

                        #region Cheque
                        //if (settlement.ChequeRegister_ID != "default" && settlement.JournalEntry_ID_DR != "default")
                        if (settlement.ChequeRegister_ID != "default" && settlement.Receipt_ID != "default")
                        {
                            tbl_bpsChequeRegister oldCheque = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                            if (oldCheque != null)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    JEDetail.SeattleAmount -= settlement.SattledAmount;
                                    JEDetail.IsSeattled = false;
                                    JEDetail.Update();

                                    oldCheque.SetteledAmount -= settlement.SattledAmount;
                                    oldCheque.IsSetteled = false;
                                    oldCheque.Update();

                                    settlement.Delete();
                                }
                            }
                        }
                        #endregion

                        #region Credit Note
                        //if (settlement.CreditNote_ID != "default" && settlement.JournalEntry_ID_DR != "default")
                        if (settlement.CreditNote_ID != "default")
                        {
                            tbl_bpsCreditNote oldCreditNote = tbl_bpsCreditNote.Select(settlement.CreditNote_ID);
                            if (oldCreditNote != null)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    JEDetail.SeattleAmount -= settlement.SattledAmount;
                                    JEDetail.IsSeattled = false;
                                    JEDetail.Update();

                                    oldCreditNote.SeattleAmount -= settlement.SattledAmount;
                                    oldCreditNote.IsSeattled = false;
                                    oldCreditNote.Update();

                                    settlement.Delete();
                                }
                            }
                        }
                        #endregion

                        #region JE Creditor
                        //if (settlement.JournalEntry_ID_CR != "default" && settlement.JournalEntry_ID_DR != "default")
                        if (settlement.JournalEntry_ID_CR != "default" && settlement.JournalEntry_ID_DR != "default")
                        {
                            List<tbl_accJournalEntry_Detail> oJE = null;
                            if (settlement.JournalEntry_ID_CR == sJournalEntryID)
                                oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => p.Line_No == settlement.LineNo_JEDR).ToList();
                            else if (settlement.JournalEntry_ID_DR == sJournalEntryID)
                                oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_CR).Where(p => p.Line_No == settlement.LineNo_JECR).ToList();

                            foreach (tbl_accJournalEntry_Detail oldJOurnalEntry in oJE)
                            {
                                if (settlement.SattledAmount > 0)
                                {
                                    JEDetail.SeattleAmount -= settlement.SattledAmount;
                                    JEDetail.IsSeattled = false;
                                    JEDetail.Update();

                                    oldJOurnalEntry.SeattleAmount -= settlement.SattledAmount;
                                    oldJOurnalEntry.IsSeattled = false;
                                    oldJOurnalEntry.Update();

                                    settlement.Delete();
                                }
                            }
                        }
                        #endregion

                    }
                }
                #endregion

                #region Remove Creditor Settlement
                foreach (tbl_accJournalEntry_Detail JEDetail in tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJournalEntryID).Where(p => p.Supplier_ID != "default"))
                {
                    List<tbl_accPaymentVoucher_Detail> oCrSettle = tbl_accPaymentVoucher_Detail.SelectAll().Where(p => p.IsSettled).ToList();
                    if (JEDetail.IsCredit)
                        oCrSettle = tbl_accPaymentVoucher_Detail.SelectAll().Where(p => p.JournalEntry_ID_CR == sJournalEntryID && p.LineNo_JECR == JEDetail.Line_No).ToList();
                    else
                        oCrSettle = tbl_accPaymentVoucher_Detail.SelectAll().Where(p => p.JournalEntry_ID_DR == sJournalEntryID && p.LineNo_JEDR == JEDetail.Line_No).ToList();

                    foreach (tbl_accPaymentVoucher_Detail settlementCR in oCrSettle)
                    {
                        #region APN
                        if (settlementCR.AccountPayableNote_ID != "default")
                        {
                            tbl_accAccountPayableNote oldAPN = tbl_accAccountPayableNote.Select(settlementCR.AccountPayableNote_ID);
                            if (oldAPN != null)
                            {
                                if (settlementCR.SettleAmount > 0)
                                {
                                    //JEDetail.SeattleAmount = 0;
                                    //JEDetail.IsSeattled = false;
                                    //JEDetail.Update();

                                    oldAPN.SettledAmount -= settlementCR.SettleAmount;
                                    oldAPN.IsSeattled = false;
                                    oldAPN.Update();

                                    settlementCR.IsSettled = false;
                                    settlementCR.SettleAmount = 0;
                                    settlementCR.Update();
                                }
                            }
                        }
                        #endregion

                        #region PV
                        if (settlementCR.PaymentVoucher_ID != "default")
                        {
                            tbl_accPaymentVoucher oldPV = tbl_accPaymentVoucher.Select(settlementCR.PaymentVoucher_ID);
                            if (oldPV != null)
                            {
                                if (settlementCR.SettleAmount > 0)
                                {
                                    //JEDetail.SeattleAmount -= settlementCR.SattledAmount;
                                    //JEDetail.IsSeattled = false;
                                    //JEDetail.Update();

                                    oldPV.SettledAmount -= settlementCR.SettleAmount;
                                    oldPV.IsSeattled = false;
                                    oldPV.Update();

                                    settlementCR.IsSettled = false;
                                    settlementCR.SettleAmount = 0;
                                    settlementCR.Update();
                                }
                            }
                        }
                        #endregion

                        #region Debit Note
                        if (settlementCR.DebitNote_ID != "default")
                        {
                            tbl_accDebitNote oldDebitNote = tbl_accDebitNote.Select(settlementCR.DebitNote_ID);
                            if (oldDebitNote != null)
                            {
                                if (settlementCR.SettleAmount > 0)
                                {
                                    //JEDetail.SeattleAmount -= settlementCR.SattledAmount;
                                    //JEDetail.IsSeattled = false;
                                    //JEDetail.Update();

                                    oldDebitNote.SettledAmount -= settlementCR.SettleAmount;
                                    oldDebitNote.IsSettled = false;
                                    oldDebitNote.Update();

                                    settlementCR.IsSettled = false;
                                    settlementCR.SettleAmount = 0;
                                    settlementCR.Update();
                                }
                            }
                        }
                        #endregion

                        #region JE Creditor
                        if (settlementCR.JournalEntry_ID_CR != "default" && settlementCR.JournalEntry_ID_DR != "default")
                        {
                            List<tbl_accJournalEntry_Detail> oJE = null;
                            if (settlementCR.JournalEntry_ID_CR == sJournalEntryID)
                                oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlementCR.JournalEntry_ID_DR).Where(p => p.Line_No == settlementCR.LineNo_JEDR).ToList();
                            else if (settlementCR.JournalEntry_ID_DR == sJournalEntryID)
                                oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlementCR.JournalEntry_ID_CR).Where(p => p.Line_No == settlementCR.LineNo_JECR).ToList();

                            foreach (tbl_accJournalEntry_Detail oldJOurnalEntry in oJE)
                            {
                                if (settlementCR.SettleAmount > 0)
                                {
                                    //JEDetail.SeattleAmount -= settlementCR.SattledAmount;
                                    //JEDetail.IsSeattled = false;
                                    //JEDetail.Update();

                                    oldJOurnalEntry.SeattleAmount -= settlementCR.SettleAmount;
                                    oldJOurnalEntry.IsSeattled = false;
                                    oldJOurnalEntry.Update();

                                    settlementCR.IsSettled = false;
                                    settlementCR.SettleAmount = 0;
                                    settlementCR.Update();
                                }
                            }
                        }
                        #endregion

                        JEDetail.SeattleAmount = 0;
                        JEDetail.IsSeattled = false;
                        JEDetail.Update();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                bIsSettlementOk = false;
            }
            return bIsSettlementOk;
        }

        #endregion

        #region Remove Settlements - From InvoiceID
        public static void RemoveSattlementsFrom_InvoiceID(string sInvoiceID)
        {
            try
            {
                decimal dSattledAmount = 0;
                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                if (oInvoice != null && oInvoice.Invoice_ID != "default")
                {
                    foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                    {
                        dSattledAmount = settlement.SattledAmount;
                        if (dSattledAmount > 0)
                        {
                            //update cheque or cash detail
                            if (settlement.ChequeRegister_ID != "default" && settlement.Receipt_ID != "default") //update cheque detail
                            {
                                tbl_bpsChequeRegister oRc = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                                if (oRc != null)
                                {
                                    oRc.SetteledAmount -= dSattledAmount;
                                    oRc.IsSetteled = false;
                                    oRc.Update();
                                }
                            }

                            else if (settlement.CreditNote_ID != "default")
                            {
                                tbl_bpsCreditNote oCR = tbl_bpsCreditNote.Select(settlement.CreditNote_ID);
                                if (oCR != null)
                                {
                                    oCR.SeattleAmount -= dSattledAmount;
                                    oCR.IsSeattled = false;
                                    oCR.Update();
                                }
                            }

                            //JE
                            else if (settlement.JournalEntry_ID_CR != "default" || settlement.JournalEntry_ID_DR != "default")
                            {
                                List<tbl_accJournalEntry_Detail> oDetail = null;
                                if (settlement.JournalEntry_ID_CR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_CR).Where(p => p.IsCredit).ToList();
                                else if (settlement.JournalEntry_ID_DR != "default")
                                    oDetail = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => !p.IsCredit).ToList();

                                foreach (tbl_accJournalEntry_Detail oJE in oDetail)
                                {
                                    oJE.SeattleAmount -= dSattledAmount;
                                    oJE.IsSeattled = false;
                                    oJE.Update();
                                }
                            }

                            //update invoice detail
                            tbl_sasInvoice oldInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                            if (oldInvoice != null && dSattledAmount > 0)
                            {
                                oldInvoice.SeattleAmount -= dSattledAmount;
                                oldInvoice.IsSeattled = false;
                                oldInvoice.Update();
                            }

                            //remove Sattlement record
                            settlement.Delete();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Remove Settelements
        public static bool RemoveSattlementsFrom_DebitNoteWithAPN(string paymentVoucher_ID, string accountPayableNote_ID, string chequeRegister_ID, string debitNote_ID, string customerRefundableNote_ID)
        {
            bool isOK = true;
            foreach (tbl_accPaymentVoucher_Detail oPVDetail in tbl_accPaymentVoucher_Detail.SelectAllByAccountPayableNote_ID(accountPayableNote_ID).Where(p => p.DebitNote_ID == debitNote_ID))
            {
                decimal dTotalSettledAmount = 0;

                if (oPVDetail != null)
                {
                    try
                    {
                        dTotalSettledAmount = oPVDetail.SettleAmount;

                        if (dTotalSettledAmount > 0)
                        {
                            tbl_accDebitNote oDebitNote = tbl_accDebitNote.Select(debitNote_ID);
                            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(accountPayableNote_ID);

                            //Remove Settlement from APN
                            oAPN.SettledAmount -= dTotalSettledAmount;
                            oAPN.IsSeattled = (oAPN.GrandTotal <= oAPN.SettledAmount) ? true : false;
                            oAPN.Update();

                            //Remove Settlement from DBN
                            oDebitNote.SettledAmount -= dTotalSettledAmount;
                            oDebitNote.IsSettled = (oDebitNote.GrandTotal <= oDebitNote.SettledAmount) ? true : false;
                            oDebitNote.Update();

                            //Remove Settlement 
                            oPVDetail.Delete();
                        }
                    }
                    catch (Exception)
                    {
                        isOK = false;
                    }

                }
            }
            return isOK;
        }

        #endregion

        #region Remove Settlements
        public static void RemoveSattlementsFrom_AllocationID(string sAllocationID, bool bShowMessage)
        {
            try
            {
                decimal dSattledAmount = 0;
                foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAll().Where(p => p.AllocationID == sAllocationID))
                {
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                    if (oInvoice != null && oInvoice.Invoice_ID != "default")
                    {
                        dSattledAmount = settlement.SattledAmount;
                        if (dSattledAmount > 0)
                        {
                            //update cheque or cash detail
                            if (settlement.ChequeRegister_ID != "default" && settlement.Receipt_ID != "default") //update cheque detail
                            {
                                tbl_bpsChequeRegister oRc = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                                if (oRc != null)
                                {
                                    oRc.SetteledAmount -= dSattledAmount;
                                    oRc.IsSetteled = false;
                                    oRc.Update();
                                }
                            }
                            else if (settlement.Receipt_ID != "default")
                            {
                                tbl_bpsReceipt oRc = tbl_bpsReceipt.Select(settlement.Receipt_ID);
                                if (oRc != null)
                                {
                                    oRc.SeattleAmount -= dSattledAmount;
                                    oRc.IsSeattled = false;
                                    oRc.Update();
                                }
                            }
                            else if (settlement.CreditNote_ID != "default")
                            {
                                tbl_bpsCreditNote oCR = tbl_bpsCreditNote.Select(settlement.CreditNote_ID);
                                if (oCR != null)
                                {
                                    oCR.SeattleAmount -= dSattledAmount;
                                    oCR.IsSeattled = false;
                                    oCR.Update();

                                    if (settlement.GlPosting_ID != "default")
                                        clsMethods_GL.GLPosting_Delete(settlement.GlPosting_ID);
                                }
                            }

                            //remove invoice settlment details
                            oInvoice.SeattleAmount -= dSattledAmount;
                            oInvoice.IsSeattled = false;
                            oInvoice.Update();

                            //remove Sattlement record
                            settlement.Delete();
                        }
                    }
                }

                if (bShowMessage)
                    MessageBox.Show("The settlements has been removed successfully......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void RemoveSattlementsFrom_ReceiptID(string ReceiptID)
        {
            try
            {
                foreach (tbl_sasInvoice_Sattled settlement in tbl_sasInvoice_Sattled.SelectAllByReceipt_ID(ReceiptID))
                {
                    if (settlement.SattledAmount > 0)
                    {
                        #region Invoice
                        if (settlement.Invoice_ID != "default")
                        {
                            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(settlement.Invoice_ID);
                            if (oInvoice != null && oInvoice.Invoice_ID != "default")
                            {
                                #region Update Cheque Register
                                if (settlement.ChequeRegister_ID != "default" && settlement.Receipt_ID != "default")
                                {
                                    tbl_bpsChequeRegister oRc = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                                    if (oRc != null)
                                    {
                                        oRc.SetteledAmount -= settlement.SattledAmount;
                                        oRc.IsSetteled = false;
                                        oRc.Update();
                                    }
                                }
                                #endregion

                                #region Update invoice
                                oInvoice.SeattleAmount -= settlement.SattledAmount;
                                oInvoice.IsSeattled = false;
                                oInvoice.Update();
                                #endregion

                                settlement.Delete();
                            }
                        }
                        #endregion
                        #region JE DR
                        else
                        {
                            tbl_accJournalEntry_Detail oJED = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(settlement.JournalEntry_ID_DR).Where(p => p.Line_No == settlement.LineNo_JEDR).FirstOrDefault();
                            if (oJED != null && oJED.JournalEntry_ID != "default")
                            {
                                #region Update Cheque Register
                                if (settlement.ChequeRegister_ID != "default" && settlement.Receipt_ID != "default")
                                {
                                    tbl_bpsChequeRegister oRc = tbl_bpsChequeRegister.Select(settlement.ChequeRegister_ID);
                                    if (oRc != null)
                                    {
                                        oRc.SetteledAmount -= settlement.SattledAmount;
                                        oRc.IsSetteled = false;
                                        oRc.Update();
                                    }
                                }
                                #endregion
                                #region Update invoice
                                oJED.SeattleAmount -= settlement.SattledAmount;
                                oJED.IsSeattled = false;
                                oJED.Update();
                                #endregion

                                settlement.Delete();
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //APN Settlement

        #region APN Settled - With Payment Voucher - Cheque
        public static void AutoSettledAPN_WithCheque_PV(string sPVID)
        {
            try
            {
                tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
                if (oPV != null && !oPV.IsDeleted && oPV.PaymentVoucher_ID != "default" && !oPV.IsSeattled)
                {
                    decimal dPVAmountToBeSettled = 0;
                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(oPV.PaymentVoucher_ID))
                    {
                        dPVAmountToBeSettled = oPV.TotalAmount - oPV.SettledAmount;
                        if (oPvDetail.AccountPayableNote_ID != "default")
                        {
                            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(oPvDetail.AccountPayableNote_ID);
                            if (oAPN != null && oAPN.AccountPayableNote_ID != "default" && oAPN.GrandTotal > oAPN.SettledAmount)
                            {
                                decimal dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;

                                if (dAPN_AmountToBeSettled <= oPvDetail.SettleAmount)
                                {
                                    oAPN.SettledAmount += dAPN_AmountToBeSettled;
                                    oAPN.IsSeattled = true;
                                    oPV.SettledAmount += dAPN_AmountToBeSettled;
                                }
                                //if (dAPN_AmountToBeSettled <= dPVAmountToBeSettled)
                                //{
                                //    oAPN.SettledAmount += dAPN_AmountToBeSettled;
                                //    oAPN.IsSeattled = true;
                                //    oPvDetail.SettleAmount = dAPN_AmountToBeSettled;
                                //    oPV.SettledAmount += dAPN_AmountToBeSettled;
                                //}
                                else
                                {
                                    oAPN.SettledAmount += oPvDetail.SettleAmount;
                                    oPV.SettledAmount += oPvDetail.SettleAmount;

                                    //oAPN.SettledAmount += dPVAmountToBeSettled;
                                    //oPvDetail.SettleAmount = dPVAmountToBeSettled;
                                    //oPV.SettledAmount += dPVAmountToBeSettled;
                                }

                                if (oPV.SettledAmount >= oPV.TotalAmount)
                                    oPV.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oPV.Update();
                                oAPN.Update();
                                oPvDetail.Update();
                            }
                        }
                        else if (oPvDetail.CustomerRefundableNote_ID != "default")
                        {
                            tbl_bpsDebitNote oDbn = tbl_bpsDebitNote.Select(oPvDetail.CustomerRefundableNote_ID);
                            if (oDbn != null && oDbn.DebitNote_ID != "default" && oDbn.TotalAmount > oDbn.SeattleAmount)
                            {
                                decimal dDBN_AmountToBeSettled = oDbn.TotalAmount - oDbn.SeattleAmount;
                                if (dDBN_AmountToBeSettled <= dPVAmountToBeSettled)
                                {
                                    oDbn.SeattleAmount += dDBN_AmountToBeSettled;
                                    oDbn.IsSeattled = true;
                                    oPvDetail.SettleAmount = dDBN_AmountToBeSettled;
                                    oPV.SettledAmount += dDBN_AmountToBeSettled;
                                }
                                else
                                {
                                    oDbn.SeattleAmount += dPVAmountToBeSettled;
                                    oPvDetail.SettleAmount = dPVAmountToBeSettled;
                                    oPV.SettledAmount += dPVAmountToBeSettled;
                                }

                                if (oPV.SettledAmount >= oPV.TotalAmount)
                                    oPV.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oPV.Update();
                                oDbn.Update();
                                oPvDetail.Update();
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
            //decimal dAllocatedAmount = 0, dPV_AvailableAmount = 0, dAPN_AmountToBeSettled = 0;
            //try
            //{
            //    if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
            //    {
            //        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
            //        tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
            //        tbl_accPaymentVoucher_Detail oPVDetail = tbl_accPaymentVoucher_Detail.Select(sPVID, sAPNID, sChequeRegisterID, "default");
            //        if (oAPN != null && oPV != null && oPVDetail != null && oAPN.AccountPayableNote_ID != "default" && oPV.PaymentVoucher_ID != "default")
            //        {
            //            dPV_AvailableAmount = oPV.ChequeAmount - oPV.SettledAmount;
            //            if (dAmountToBeSettled > 0 && (oAPN.GrandTotal - oAPN.SettledAmount) >= dAmountToBeSettled)
            //                dAPN_AmountToBeSettled = dAmountToBeSettled;
            //            else
            //                dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;

            //            if (dPV_AvailableAmount >= dAPN_AmountToBeSettled) //if payment voucher has enough money to settle 
            //            {
            //                dAllocatedAmount = dAPN_AmountToBeSettled;
            //                oAPN.SettledAmount += dAllocatedAmount;
            //                oPVDetail.SettleAmount += dAllocatedAmount;
            //                oPV.SettledAmount += dAllocatedAmount;

            //                oPVDetail.IsSettled = true;
            //                oAPN.IsSeattled = oAPN.GrandTotal <= oAPN.SettledAmount ? true : false;
            //                oPV.IsSeattled = oPV.ChequeAmount <= oPV.SettledAmount ? true : false;

            //                oAPN.Update();
            //                oPVDetail.Update();
            //                oPV.Update();

            //            }
            //            else //if APN amount is grater than PV amount
            //            {
            //                dAllocatedAmount = dPV_AvailableAmount;
            //                oAPN.SettledAmount += dAllocatedAmount;
            //                oPVDetail.SettleAmount += dAllocatedAmount;
            //                oPV.SettledAmount += dAllocatedAmount;

            //                oPVDetail.IsSettled = true;
            //                oAPN.IsSeattled = oAPN.GrandTotal <= oAPN.SettledAmount ? true : false;
            //                oPV.IsSeattled = oPV.ChequeAmount <= oPV.SettledAmount ? true : false;

            //                oAPN.Update();
            //                oPVDetail.Update();
            //                oPV.Update();
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", 0,ex);
            //    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //return dAllocatedAmount;
        }
        #endregion

        //2017-07-21 Thilini
        #region APN Auto settle PV / Debit Note
        public static void AutoSettledAPN_WithPV(string sPVID, string sAPNID)
        {
            try
            {
                tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
                if (oPV != null && !oPV.IsDeleted && oPV.PaymentVoucher_ID != "default" && !oPV.IsSeattled)
                {
                    decimal dPVAmountToBeSettled = 0;
                    //   int iLineNo = LineNo;

                    List<tbl_accPaymentVoucher_Detail> oPVDetails = tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(oPV.PaymentVoucher_ID);
                    if (oPVDetails == null || oPVDetails.Count == 0)
                    {
                        string sRegisterID = "default";
                        List<tbl_accChequeRegister> oCheque = tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(sPVID);
                        if (oCheque.Count != 0)
                            sRegisterID = oCheque.FirstOrDefault().ChequeRegister_ID;

                        int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                        tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iLineNo, sPVID, sAPNID, sRegisterID, "default", "default", "default", -1, "default", -1, "", 0, false);
                        objPVDetail.Insert();
                    }
                    else
                    {
                        int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                        tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iLineNo + 1, sPVID, sAPNID, oPVDetails.FirstOrDefault().ChequeRegister_ID, "default", "default", "default", -1, "default", -1, "", 0, false);
                        objPVDetail.Insert();
                    }

                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(oPV.PaymentVoucher_ID).Where(p => !p.IsSettled))
                    {
                        dPVAmountToBeSettled = oPV.TotalAmount - oPV.SettledAmount;
                        if (oPvDetail.AccountPayableNote_ID != "default")
                        {
                            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
                            if (oAPN != null && oAPN.AccountPayableNote_ID != "default" && oAPN.GrandTotal > oAPN.SettledAmount)
                            {
                                decimal dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;
                                if (dAPN_AmountToBeSettled <= dPVAmountToBeSettled)
                                {
                                    oAPN.SettledAmount += dAPN_AmountToBeSettled;
                                    oAPN.IsSeattled = true;
                                    oPvDetail.SettleAmount = dAPN_AmountToBeSettled;
                                    oPV.SettledAmount += dAPN_AmountToBeSettled;
                                }
                                else
                                {
                                    oAPN.SettledAmount += dPVAmountToBeSettled;
                                    oPvDetail.SettleAmount = dPVAmountToBeSettled;
                                    oPV.SettledAmount += dPVAmountToBeSettled;
                                }

                                if (oPV.SettledAmount >= oPV.TotalAmount)
                                    oPV.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oPV.Update();
                                oAPN.Update();
                                oPvDetail.Update();
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

        }

        public static void AutoSettledAPN_WithDebitNote(string sDBNID, string sAPNID)
        {
            try
            {
                tbl_accDebitNote oDBN = tbl_accDebitNote.Select(sDBNID);
                if (oDBN != null && !oDBN.IsDeleted && oDBN.DebitNote_ID != "default" && !oDBN.IsSettled)
                {
                    decimal dPVAmountToBeSettled = 0;
                    // int iLineNo = LineNo;

                    List<tbl_accPaymentVoucher_Detail> oDBNDetails = tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDBN.DebitNote_ID);
                    if (oDBNDetails == null || oDBNDetails.Count == 0)
                    {
                        int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                        tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iLineNo, "default", sAPNID, "default", sDBNID, "default", "default", -1, "default", -1, "", 0, false);
                        objPVDetail.Insert();
                    }
                    else
                    {
                        int iLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                        tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iLineNo + 1, "default", sAPNID, oDBNDetails.FirstOrDefault().ChequeRegister_ID, sDBNID, "default", "default", -1, "default", -1, "", 0, false);
                        objPVDetail.Insert();
                    }

                    //foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(oDBN.PaymentVoucher_ID).Where(p => !p.IsSettled))
                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDBN.DebitNote_ID).Where(p => !p.IsSettled))
                    {
                        dPVAmountToBeSettled = oDBN.GrandTotal - oDBN.SettledAmount;
                        if (oPvDetail.AccountPayableNote_ID != "default")
                        {
                            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
                            if (oAPN != null && oAPN.AccountPayableNote_ID != "default" && oAPN.GrandTotal > oAPN.SettledAmount)
                            {
                                decimal dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;
                                if (dAPN_AmountToBeSettled <= dPVAmountToBeSettled)
                                {
                                    oAPN.SettledAmount += dAPN_AmountToBeSettled;
                                    oAPN.IsSeattled = true;
                                    oPvDetail.SettleAmount = dAPN_AmountToBeSettled;
                                    oDBN.SettledAmount += dAPN_AmountToBeSettled;
                                }
                                else
                                {
                                    oAPN.SettledAmount += dPVAmountToBeSettled;
                                    oPvDetail.SettleAmount = dPVAmountToBeSettled;
                                    oDBN.SettledAmount += dPVAmountToBeSettled;
                                }

                                if (oDBN.SettledAmount >= oDBN.GrandTotal)
                                    oDBN.IsSettled = true;

                                oPvDetail.IsSettled = true;
                                oDBN.Update();
                                oAPN.Update();
                                oPvDetail.Update();
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

        }

        public static void AutoSettledAPN_WithJournalEntryDR(string sJEID_DR, int LineNo, string sAPNID, string sSupplierID)
        {
            try
            {
                tbl_accJournalEntry_Detail oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJEID_DR).Where(p => p.Line_No == LineNo).FirstOrDefault();
                if (oJE != null && oJE.JournalEntry_ID != "default" && !oJE.IsSeattled)
                {
                    decimal dJEAmountToBeSettled = 0;
                    //int iLineNo = 0;
                    int iPVLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                    tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iPVLineNo, "default", sAPNID, "default", "default", "default", sJEID_DR, LineNo, "default", -1, "", 0, false);
                    objPVDetail.Insert();


                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByLineNo_JEDR_JournalEntry_ID_DR(oJE.Line_No, oJE.JournalEntry_ID).Where(p => p.AccountPayableNote_ID == sAPNID && !p.IsSettled))
                    {
                        dJEAmountToBeSettled = oJE.Amount - oJE.SeattleAmount;
                        if (oPvDetail.AccountPayableNote_ID != "default")
                        {
                            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
                            if (oAPN != null && oAPN.AccountPayableNote_ID != "default" && oAPN.GrandTotal > oAPN.SettledAmount)
                            {
                                decimal dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;
                                if (dAPN_AmountToBeSettled <= dJEAmountToBeSettled)
                                {
                                    oAPN.SettledAmount += dAPN_AmountToBeSettled;
                                    oAPN.IsSeattled = true;
                                    oPvDetail.SettleAmount = dAPN_AmountToBeSettled;
                                    oJE.SeattleAmount += dAPN_AmountToBeSettled;
                                }
                                else
                                {
                                    oAPN.SettledAmount += dJEAmountToBeSettled;
                                    oPvDetail.SettleAmount = dJEAmountToBeSettled;
                                    oJE.SeattleAmount += dJEAmountToBeSettled;
                                }

                                if (oJE.SeattleAmount >= oJE.Amount)
                                    oJE.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oJE.Update();
                                oAPN.Update();
                                oPvDetail.Update();
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

        }
        #endregion

        #region Auto Settled JECR
        public static void AutoSettledJECR_WithPV(string sJEID_CR, int LineNo, string sPVID)
        {
            try
            {
                tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
                if (oPV != null && oPV.PaymentVoucher_ID != "default" && !oPV.IsSeattled)
                {
                    decimal dPVAmountToBeSettled = 0;
                    //  int iLineNo = 0;
                    int iPVLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                    tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iPVLineNo, sPVID, "default", "default", "default", "default", "default", -1, sJEID_CR, LineNo, "", 0, false);
                    objPVDetail.Insert();


                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(oPV.PaymentVoucher_ID).Where(p => p.LineNo_JECR == LineNo && p.JournalEntry_ID_CR == sJEID_CR && !p.IsSettled))
                    {
                        dPVAmountToBeSettled = oPV.TotalAmount - oPV.SettledAmount;
                        if (oPvDetail.PaymentVoucher_ID != "default")
                        {
                            tbl_accJournalEntry_Detail oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJEID_CR).Where(p => p.Line_No == LineNo).FirstOrDefault();
                            if (oJE != null && oJE.JournalEntry_ID != "default" && oJE.Amount > oJE.SeattleAmount)
                            {
                                decimal dJE_AmountToBeSettled = oJE.Amount - oJE.SeattleAmount;
                                if (dJE_AmountToBeSettled <= dPVAmountToBeSettled)
                                {
                                    oJE.SeattleAmount += dJE_AmountToBeSettled;
                                    oJE.IsSeattled = true;
                                    oPvDetail.SettleAmount = dJE_AmountToBeSettled;
                                    oPV.SettledAmount += dJE_AmountToBeSettled;
                                }
                                else
                                {
                                    oJE.SeattleAmount += dPVAmountToBeSettled;
                                    oPvDetail.SettleAmount = dPVAmountToBeSettled;
                                    oPV.SettledAmount += dPVAmountToBeSettled;
                                }

                                if (oPV.SettledAmount >= oPV.TotalAmount)
                                    oPV.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oPV.Update();
                                oJE.Update();
                                oPvDetail.Update();
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

        }

        public static void AutoSettledJECR_WithDebitNote(string sJEID_CR, int LineNo, string sDBNID)
        {
            try
            {
                tbl_accDebitNote oDBN = tbl_accDebitNote.Select(sDBNID);
                if (oDBN != null && oDBN.DebitNote_ID != "default" && !oDBN.IsSettled)
                {
                    decimal dDBNAmountToBeSettled = 0;
                    //   int iLineNo = 0;
                    int iPVLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                    tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iPVLineNo, "default", "default", "default", sDBNID, "default", "default", -1, sJEID_CR, LineNo, "", 0, false);
                    objPVDetail.Insert();


                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByDebitNote_ID(oDBN.DebitNote_ID).Where(p => p.LineNo_JECR == LineNo && p.JournalEntry_ID_CR == sJEID_CR && !p.IsSettled))
                    {
                        dDBNAmountToBeSettled = oDBN.GrandTotal - oDBN.SettledAmount;
                        if (oPvDetail.DebitNote_ID != "default")
                        {
                            tbl_accJournalEntry_Detail oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJEID_CR).Where(p => p.Line_No == LineNo).FirstOrDefault();
                            if (oJE != null && oJE.JournalEntry_ID != "default" && oJE.Amount > oJE.SeattleAmount)
                            {
                                decimal dJE_AmountToBeSettled = oJE.Amount - oJE.SeattleAmount;
                                if (dJE_AmountToBeSettled <= dDBNAmountToBeSettled)
                                {
                                    oJE.SeattleAmount += dJE_AmountToBeSettled;
                                    oJE.IsSeattled = true;
                                    oPvDetail.SettleAmount = dJE_AmountToBeSettled;
                                    oDBN.SettledAmount += dJE_AmountToBeSettled;
                                }
                                else
                                {
                                    oJE.SeattleAmount += dDBNAmountToBeSettled;
                                    oPvDetail.SettleAmount = dDBNAmountToBeSettled;
                                    oDBN.SettledAmount += dDBNAmountToBeSettled;
                                }

                                if (oDBN.SettledAmount >= oDBN.GrandTotal)
                                    oDBN.IsSettled = true;

                                oPvDetail.IsSettled = true;
                                oDBN.Update();
                                oJE.Update();
                                oPvDetail.Update();
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

        }

        public static void AutoSettledJECR_WithJournalEntryDR(string sJEID_CR, int LineNo, string sJEID_DR, int LineNo_DR)
        {
            try
            {
                tbl_accJournalEntry_Detail oJE_DR = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJEID_DR).Where(p => p.Line_No == LineNo_DR).FirstOrDefault();
                if (oJE_DR != null && oJE_DR.JournalEntry_ID != "default" && !oJE_DR.IsSeattled)
                {
                    decimal dJEDRAmountToBeSettled = 0;
                    // int iLineNo = 0;
                    int iPVLineNo = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.accCreditorSettlement)));
                    tbl_accPaymentVoucher_Detail objPVDetail = new tbl_accPaymentVoucher_Detail(iPVLineNo, "default", "default", "default", "default", "default", sJEID_DR, LineNo_DR, sJEID_CR, LineNo, "", 0, false);
                    objPVDetail.Insert();


                    foreach (tbl_accPaymentVoucher_Detail oPvDetail in tbl_accPaymentVoucher_Detail.SelectAllByLineNo_JEDR_JournalEntry_ID_DR(oJE_DR.Line_No, oJE_DR.JournalEntry_ID).Where(p => p.LineNo_JECR == LineNo && p.JournalEntry_ID_CR == sJEID_CR && !p.IsSettled))
                    {
                        dJEDRAmountToBeSettled = oJE_DR.Amount - oJE_DR.SeattleAmount;
                        if (oPvDetail.JournalEntry_ID_DR != "default")
                        {
                            tbl_accJournalEntry_Detail oJE = tbl_accJournalEntry_Detail.SelectAllByJournalEntry_ID(sJEID_CR).Where(p => p.Line_No == LineNo).FirstOrDefault();
                            if (oJE != null && oJE.JournalEntry_ID != "default" && oJE.Amount > oJE.SeattleAmount)
                            {
                                decimal dJE_AmountToBeSettled = oJE.Amount - oJE.SeattleAmount;
                                if (dJE_AmountToBeSettled <= dJEDRAmountToBeSettled)
                                {
                                    oJE.SeattleAmount += dJE_AmountToBeSettled;
                                    oJE.IsSeattled = true;
                                    oPvDetail.SettleAmount = dJE_AmountToBeSettled;
                                    oJE_DR.SeattleAmount += dJE_AmountToBeSettled;
                                }
                                else
                                {
                                    oJE.SeattleAmount += dJEDRAmountToBeSettled;
                                    oPvDetail.SettleAmount = dJEDRAmountToBeSettled;
                                    oJE_DR.SeattleAmount += dJEDRAmountToBeSettled;
                                }

                                if (oJE_DR.SeattleAmount >= oJE_DR.Amount)
                                    oJE_DR.IsSeattled = true;

                                oPvDetail.IsSettled = true;
                                oJE_DR.Update();
                                oJE.Update();
                                oPvDetail.Update();
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

        }

        #endregion

        #region APN Settled - With Payment Voucher - Cash
        //public static decimal AutoSettledAPN_WithCash_PV(string sAPNID, string sPVID, decimal dAmountToBeSettled)
        //{
        //    decimal dAllocatedAmount = 0, dPV_AvailableAmount = 0, dAPN_AmountToBeSettled = 0;
        //    try
        //    {
        //        if (clsAutocode.getConfigStatus(ConfigStatus.AutoInvoiceSettleWhenCashReceipt))
        //        {
        //            tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sAPNID);
        //            tbl_accPaymentVoucher oPV = tbl_accPaymentVoucher.Select(sPVID);
        //            tbl_accPaymentVoucher_Detail oPVDetail = tbl_accPaymentVoucher_Detail.Select(sPVID, sAPNID, "default", "default", "default");
        //            if (oAPN != null && oPV != null && oPVDetail != null && oAPN.AccountPayableNote_ID != "default" && oPV.PaymentVoucher_ID != "default")
        //            {
        //                dPV_AvailableAmount = oPV.CashAmount - oPV.SettledAmount;
        //                if (dAmountToBeSettled > 0 && (oAPN.GrandTotal - oAPN.SettledAmount) >= dAmountToBeSettled)
        //                    dAPN_AmountToBeSettled = dAmountToBeSettled;
        //                else
        //                    dAPN_AmountToBeSettled = oAPN.GrandTotal - oAPN.SettledAmount;

        //                if (dPV_AvailableAmount >= dAPN_AmountToBeSettled) //if payment voucher has enough money to settle 
        //                {
        //                    dAllocatedAmount = dAPN_AmountToBeSettled;
        //                    oAPN.SettledAmount += dAllocatedAmount;
        //                    oPVDetail.SettleAmount += dAllocatedAmount;
        //                    oPV.SettledAmount += dAllocatedAmount;

        //                    oPVDetail.IsSettled = true;
        //                    oAPN.IsSeattled = oAPN.GrandTotal <= oAPN.SettledAmount ? true : false;
        //                    oPV.IsSeattled = oPV.CashAmount <= oPV.SettledAmount ? true : false;

        //                    oAPN.Update();
        //                    oPVDetail.Update();
        //                    oPV.Update();

        //                }
        //                else //if APN amount is grater than PV amount
        //                {
        //                    dAllocatedAmount = dPV_AvailableAmount;
        //                    oAPN.SettledAmount += dAllocatedAmount;
        //                    oPVDetail.SettleAmount += dAllocatedAmount;
        //                    oPV.SettledAmount += dAllocatedAmount;

        //                    oPVDetail.IsSettled = true;
        //                    oAPN.IsSeattled = oAPN.GrandTotal <= oAPN.SettledAmount ? true : false;
        //                    oPV.IsSeattled = oPV.CashAmount <= oPV.SettledAmount ? true : false;

        //                    oAPN.Update();
        //                    oPVDetail.Update();
        //                    oPV.Update();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", 0,ex);
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return dAllocatedAmount;
        //}
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


        //Loan Settlement

        #region create Settled - LoanInOut
        public static void AutoSettledLoanInOut_Create(string sAllocationID, string sLoanOut_ID, string sLoanIN_ID)
        {
            try
            {
                decimal dLoanInQty = 0, dLoanOutQty = 0;
                tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(sLoanIN_ID);
                tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(sLoanOut_ID);
                if (oLoanIn != null && oLoanOut != null && oLoanIn.IsWeightCalculation == oLoanOut.IsWeightCalculation)
                {
                    dLoanInQty = oLoanIn.IsWeightCalculation ? oLoanIn.TotalWeight : oLoanIn.TotalQty;
                    dLoanOutQty = oLoanOut.IsWeightCalculation ? oLoanOut.TotalWeight : oLoanIn.TotalQty;
                    if (dLoanOutQty > 0 && dLoanInQty > 0)
                    {
                        if (dLoanInQty <= dLoanOutQty) //if Receipt has enough cash to settled
                        {
                            oLoanIn.SeattleAmount += dLoanInQty;
                            oLoanOut.SeattleAmount += dLoanInQty;

                            oLoanIn.IsSeattled = true;
                            if (dLoanInQty == dLoanOutQty)
                                oLoanOut.IsSeattled = true;

                            oLoanIn.Update();
                            oLoanOut.Update();
                            clsHelpMethods.InsertLoanInOutSettlementRecord(sAllocationID, sLoanIN_ID, sLoanOut_ID, 0, 0, oLoanIn.IsWeightCalculation ? 0 : dLoanInQty, oLoanIn.IsWeightCalculation ? dLoanInQty : 0);
                        }
                        else //if Invoice amount is greter than receipt amount
                        {
                            oLoanIn.SeattleAmount += dLoanOutQty;
                            oLoanOut.SeattleAmount += dLoanOutQty;

                            oLoanOut.IsSeattled = true;
                            oLoanIn.Update();
                            oLoanOut.Update();
                            clsHelpMethods.InsertLoanInOutSettlementRecord(sAllocationID, sLoanIN_ID, sLoanOut_ID, 0, 0, oLoanIn.IsWeightCalculation ? 0 : dLoanOutQty, oLoanIn.IsWeightCalculation ? dLoanOutQty : 0);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Remove Settled - LoanInOut
        public static void AutoSettledLoanInOut_Remove(string sAllocationID, string sLoanOut_ID, string sLoanIN_ID)
        {
            try
            {
                decimal dSettleQty = 0;
                tbl_scsLoanIn oLoanIn = tbl_scsLoanIn.Select(sLoanIN_ID);
                tbl_scsLoanOut oLoanOut = tbl_scsLoanOut.Select(sLoanOut_ID);
                tbl_scsLoanSettle detail = tbl_scsLoanSettle.Select(sAllocationID);
                if (detail != null)
                {
                    dSettleQty = oLoanIn.IsWeightCalculation ? detail.WeightSettle : detail.QtySettle;

                    //Remove From LoanIn
                    oLoanIn.SeattleAmount -= dSettleQty;
                    oLoanIn.Update();

                    //Remove From LoanOut
                    oLoanOut.SeattleAmount -= dSettleQty;
                    oLoanOut.Update();

                    //delete settlement record
                    detail.Delete();
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Insert LoanIn/Out Sattlement Record
        /* Ask From Asanka
        public static void InsertLoanInOutSettlementRecord(string sLoanIn_ID, string sLoanOut_ID, decimal dUnitPrice, decimal dWeightPrice, decimal dQty, decimal dWeight)
        {
            try
            {
                tbl_scsLoanSettle detail = tbl_scsLoanSettle.Select(sLoanIn_ID, sLoanOut_ID);
                if (detail != null)
                {
                    detail.UnitPriceSettle = dUnitPrice;
                    detail.WeightPriceSettle = dWeightPrice;
                    detail.QtySettle = dQty;
                    detail.WeightSettle = dWeight;
                }
                else
                {
                    tbl_scsLoanSettle oSettle = new tbl_scsLoanSettle(sLoanIn_ID, sLoanOut_ID, dQty, dWeight, dUnitPrice, dWeightPrice);
                    oSettle.Insert();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       */
        public static void InsertLoanInOutSettlementRecord(string sAllocatiionID, string sLoanIn_ID, string sLoanOut_ID, decimal dUnitPrice, decimal dWeightPrice, decimal dQty, decimal dWeight)
        {
            try
            {
                tbl_scsLoanSettle detail = tbl_scsLoanSettle.Select(sAllocatiionID);
                if (detail != null)
                {
                    detail.UnitPriceSettle = dUnitPrice;
                    detail.WeightPriceSettle = dWeightPrice;
                    detail.QtySettle = dQty;
                    detail.WeightSettle = dWeight;
                }
                else
                {
                    tbl_scsLoanSettle oSettle = new tbl_scsLoanSettle(sAllocatiionID, sLoanIn_ID, sLoanOut_ID, dQty, dWeight, dUnitPrice, dWeightPrice, detail.AllocationDate, detail.IsQtyAllocation, false);
                    oSettle.Insert();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        //Datagird Custormized

        #region Format Drid Columns - Sales
        public static void FormatGrid_Sales(DataGridView dgv)
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.ePackWithDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.akt);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.aktN2.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.aktN2);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.ePackWithoutDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.ePackWithSubCategory);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSerialNumber.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.ePackWithSerialNumber);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.ceilingAndWallPanal);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.idealWheels);
            //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
            //    clsHelpMethods.FormatGridColumns_Sales(dgv, SoftwareModel_Sales.gem);
            else
                clsHelpMethods.FormatGridColumns_Sales(dgv);
        }

        public static void FormatGridColumns_Sales(DataGridView dgv, SoftwareModel_Sales model)
        {
            if (clsConfig.bSerialNumberActive)
            {//ItemSerialNo1
                dgv.Columns["ItemCode"].Width = 100;
                dgv.Columns["ItemName"].Width = 300;
                dgv.Columns["ItemSubCategoryID"].Width = 124;
                dgv.Columns["ItemSerialNo"].Width = 124;
                dgv.Columns["Width"].Width = 50;
                dgv.Columns["Height"].Width = 50;
                dgv.Columns["Gauge"].Width = 50;
                dgv.Columns["Gusset"].Width = 50;
                dgv.Columns["UOM"].Width = 50;
                dgv.Columns["Quantity"].Width = 80;
                dgv.Columns["Weight"].Width = 80;
                dgv.Columns["UnitPrice"].Width = 80;
                dgv.Columns["WeightPrice"].Width = 80;
                dgv.Columns["Amount"].Width = 90;

                dgv.Columns["ItemSubCategoryID"].Visible = true;
                dgv.Columns["ItemSerialNo"].Visible = true;
                dgv.Columns["Width"].Visible = false;
                dgv.Columns["Height"].Visible = false;
                dgv.Columns["Gauge"].Visible = false;
                dgv.Columns["Gusset"].Visible = false;
                dgv.Columns["Remarks"].Visible = true; //Ask Asanka Aiya

                dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                dgv.Columns["Weight"].HeaderText = "Weight";
                dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                dgv.Columns["ItemSerialNo"].HeaderText = "Item Serial No";
            }
            else
            {
                switch (model)
                {
                    case SoftwareModel_Sales.ePackWithDimension:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 224;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = true;
                        dgv.Columns["Height"].Visible = true;
                        dgv.Columns["Gauge"].Visible = true;
                        dgv.Columns["Gusset"].Visible = true;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;
                    case SoftwareModel_Sales.akt:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 224;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = true;
                        dgv.Columns["Height"].Visible = true;
                        dgv.Columns["Gauge"].Visible = true;
                        dgv.Columns["Gusset"].Visible = true;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;
                    case SoftwareModel_Sales.aktN2:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 224;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = true;
                        dgv.Columns["Height"].Visible = true;
                        dgv.Columns["Gauge"].Visible = true;
                        dgv.Columns["Gusset"].Visible = true;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;
                    case SoftwareModel_Sales.ePackWithoutDimension:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 424;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;

                    case SoftwareModel_Sales.ePackWithSubCategory:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 300;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = true;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;

                    case SoftwareModel_Sales.idealWheels:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 300;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = true;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;

                    case SoftwareModel_Sales.ePackWithSerialNumber:
                        dgv.Columns["ItemCode"].Width = 100;
                        dgv.Columns["ItemName"].Width = 300;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = true;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;

                    case SoftwareModel_Sales.ePackWithRemark:
                        dgv.Columns["ItemCode"].Width = 90;
                        dgv.Columns["ItemName"].Width = 260;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 80;
                        dgv.Columns["UnitPrice"].Width = 80;
                        dgv.Columns["WeightPrice"].Width = 80;
                        dgv.Columns["Amount"].Width = 90;
                        dgv.Columns["Remarks"].Width = 174;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Weight";
                        dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
                        break;

                    case SoftwareModel_Sales.ceilingAndWallPanal:
                        dgv.Columns["ItemCode"].Width = 82;
                        dgv.Columns["ItemName"].Width = 220;
                        dgv.Columns["ItemSubCategoryID"].Width = 124;
                        dgv.Columns["ItemSerialNo"].Width = 124;
                        dgv.Columns["Width"].Width = 50;
                        dgv.Columns["Height"].Width = 50;
                        dgv.Columns["Gauge"].Width = 50;
                        dgv.Columns["Gusset"].Width = 50;
                        dgv.Columns["UOM"].Width = 40;
                        dgv.Columns["Quantity"].Width = 75;
                        dgv.Columns["Weight"].Width = 75;
                        dgv.Columns["UnitPrice"].Width = 75;
                        dgv.Columns["WeightPrice"].Width = 75;
                        dgv.Columns["Amount"].Width = 80;
                        dgv.Columns["Remarks"].Width = 125;

                        dgv.Columns["ItemSubCategoryID"].Visible = false;
                        dgv.Columns["ItemSerialNo"].Visible = false;
                        dgv.Columns["Width"].Visible = false;
                        dgv.Columns["Height"].Visible = false;
                        dgv.Columns["Gauge"].Visible = false;
                        dgv.Columns["Gusset"].Visible = false;
                        dgv.Columns["Remarks"].Visible = true;

                        dgv.Columns["Remarks"].HeaderText = "Item Remarks";
                        dgv.Columns["Weight"].HeaderText = "Square Feet";
                        dgv.Columns["WeightPrice"].HeaderText = "Sq.Ft. Price";
                        break;
                }
            }
        }
        public static void FormatGridColumns_Sales(DataGridView dgv)
        {
            //dgv.Columns["ItemCode"].Width = 100;
            dgv.Columns["ItemCode"].Width = 90; //Changed by Gayan 2016-12-02 for Adjustting datagrid after adding line discount columns
            dgv.Columns["ItemName"].Width = 255;
            //dgv.Columns["ItemName"].Width = 300;
            dgv.Columns["UOM"].Width = 50;
            dgv.Columns["Quantity"].Width = 80;
            dgv.Columns["Weight"].Width = 80;
            dgv.Columns["UnitPrice"].Width = 80;
            dgv.Columns["WeightPrice"].Width = 80;
            dgv.Columns["Amount"].Width = 90;

            dgv.Columns["ItemSubCategoryID"].Width = 124;
            dgv.Columns["ItemSerialNo"].Width = 124;
            dgv.Columns["Remarks"].Width = 124;

            dgv.Columns["Width"].Visible = false;
            dgv.Columns["Height"].Visible = false;
            dgv.Columns["Gauge"].Visible = false;
            dgv.Columns["Gusset"].Visible = false;
            //dgv.Columns["ItemStatus"].Visible = false;
            dgv.Columns["ItemSubCategoryID"].Visible = false;
            dgv.Columns["ItemSerialNo"].Visible = false;
            dgv.Columns["Remarks"].Visible = true;

            if (clsConfig.bItemSerialNo_Active)
                dgv.Columns["ItemSerialNo"].Visible = true;
            else if (clsConfig.bItemSubCategoryEnable)
                dgv.Columns["ItemSubCategoryID"].Visible = true;
            //else
            //    dgv.Columns["Remarks"].Visible = true;

            dgv.Columns["Remarks"].HeaderText = "Item Remarks";
            dgv.Columns["Weight"].HeaderText = "Weight";
            dgv.Columns["WeightPrice"].HeaderText = "Weight Price";
            dgv.Columns["ItemSerialNo"].HeaderText = "Item Serial No";
        }
        #endregion

        #region Format Drid Columns - Internal Stock
        public static void FormatGrid_Stock(DataGridView dgv)
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.ePackWithDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.akt);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.aktN2.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.aktN2);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.ePackWithoutDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.ePackWithSubCategory);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSerialNumber.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.ePackWithSerialNumber);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ceilingAndWallPanal.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.ceilingAndWallPanal);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.idealWheels);
            //else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
            //    clsHelpMethods.FormatGridColumns_Stock(dgv, SoftwareModel_Sales.gem);
        }
        public static void FormatGridColumns_Stock(DataGridView dgv, SoftwareModel_Sales model)
        {
            if (clsConfig.bSerialNumberActive)
            {//ItemSerialNo1
                dgv.Columns["ItemCode"].Width = 95;
                dgv.Columns["ItemName"].Width = 250;
                dgv.Columns["ItemSerialNo1"].Width = 100;
                dgv.Columns["UOM"].Width = 80;
                dgv.Columns["Quantity"].Width = 100;
                dgv.Columns["Weight"].Width = 100;

                dgv.Columns["GoodsFrom"].Width = 165;
                dgv.Columns["Note_ID"].Width = 100;
                dgv.Columns["ItemSubCategoryID1"].Width = 140;
                dgv.Columns["Remarks"].Width = 100;


                dgv.Columns["GoodsFrom"].Visible = false;
                dgv.Columns["Note_ID"].Visible = true;
                dgv.Columns["Remarks"].Visible = false;
                dgv.Columns["JobCode"].Visible = false;
                dgv.Columns["ItemSerialNo1"].Visible = true;
                dgv.Columns["ItemSerialNo1"].HeaderText = "Item Serial No";
            }
            else
            {
                switch (model)
                {
                    case SoftwareModel_Sales.ePackWithDimension:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = false;
                        dgv.Columns["GoodsFrom"].Visible = true;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.akt:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = false;
                        dgv.Columns["GoodsFrom"].Visible = true;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.aktN2:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = false;
                        dgv.Columns["GoodsFrom"].Visible = true;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.ePackWithoutDimension:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = false;
                        dgv.Columns["GoodsFrom"].Visible = true;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.ceilingAndWallPanal:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;


                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = false;
                        dgv.Columns["GoodsFrom"].Visible = false;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = true;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.ePackWithSubCategory:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;


                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = true;
                        dgv.Columns["GoodsFrom"].Visible = false;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.idealWheels:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = true;
                        dgv.Columns["GoodsFrom"].Visible = false;
                        dgv.Columns["Note_ID"].Visible = true;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;

                    case SoftwareModel_Sales.ePackWithSerialNumber:
                        dgv.Columns["ItemCode"].Width = 95;
                        dgv.Columns["ItemName"].Width = 250;
                        dgv.Columns["UOM"].Width = 50;
                        dgv.Columns["Quantity"].Width = 80;
                        dgv.Columns["Weight"].Width = 90;

                        dgv.Columns["GoodsFrom"].Width = 165;
                        dgv.Columns["Note_ID"].Width = 95;
                        dgv.Columns["ItemSubCategoryID1"].Width = 165;
                        dgv.Columns["Remarks"].Width = 165;

                        dgv.Columns["ItemSubCategoryID1"].Visible = true;
                        dgv.Columns["GoodsFrom"].Visible = false;
                        dgv.Columns["Note_ID"].Visible = false;
                        dgv.Columns["Remarks"].Visible = false;
                        dgv.Columns["JobCode"].Visible = false;
                        break;
                }
            }
        }
        #endregion

        #region Format Drid Columns - External Stock
        public static void FormatGrid_Stock_External(DataGridView dgv)
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.ePackWithDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.akt);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.aktN2.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.aktN2);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.ePackWithoutDimension);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.ePackWithSubCategory);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSerialNumber.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.ePackWithSerialNumber);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithRemark.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.ePackWithRemark);
            else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                clsHelpMethods.FormatGridColumns_Stock_External(dgv, SoftwareModel_Sales.idealWheels);
        }
        public static void FormatGridColumns_Stock_External(DataGridView dgv, SoftwareModel_Sales model)
        {
            switch (model)
            {
                case SoftwareModel_Sales.ePackWithDimension:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;

                case SoftwareModel_Sales.akt:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 235;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;

                case SoftwareModel_Sales.aktN2:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;

                case SoftwareModel_Sales.ePackWithoutDimension:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;

                case SoftwareModel_Sales.ePackWithSubCategory:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = true;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = false;
                    break;

                case SoftwareModel_Sales.idealWheels:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = true;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = false;
                    break;

                case SoftwareModel_Sales.ePackWithSerialNumber:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;

                case SoftwareModel_Sales.ePackWithRemark:
                    dgv.Columns["ItemCode"].Width = 95;
                    dgv.Columns["ItemName"].Width = 255;
                    dgv.Columns["Quantity"].Width = 80;
                    dgv.Columns["UnitPrice"].Width = 80;
                    dgv.Columns["Weight"].Width = 80;
                    dgv.Columns["WeightPrice"].Width = 80;
                    dgv.Columns["ItemSubCategoryID1"].Width = 165;
                    dgv.Columns["Remarks"].Width = 165;

                    dgv.Columns["ItemSubCategoryID1"].Visible = false;
                    dgv.Columns["Quantity"].Visible = true;
                    dgv.Columns["UnitPrice"].Visible = true;
                    dgv.Columns["Weight"].Visible = false;
                    dgv.Columns["WeightPrice"].Visible = false;
                    dgv.Columns["Remarks"].Visible = true;
                    break;
            }
        }
        #endregion

        #region Format Drid Columns - Document Checking or Approval
        public static void FormatGrid_DocumentCheckingOrApproval(DataGridView dgv, ProcessNote fProcessNote)
        {
            if (true)
                FormatGridColumns_DocumentCheckingOrApproval(dgv, fProcessNote);

        }
        public static void FormatGridColumns_DocumentCheckingOrApproval(DataGridView dgv, ProcessNote fProcessNote)
        {
            switch (fProcessNote)
            {
                case ProcessNote.CustomerOrder:
                    //total size 825
                    dgv.Columns["CustomerID"].Width = 100;
                    dgv.Columns["CustomerName"].Width = 215;
                    dgv.Columns["Age30to60"].Width = 70;
                    dgv.Columns["Age60to90"].Width = 70;
                    dgv.Columns["Age90plus"].Width = 70;
                    dgv.Columns["ChequesInHand"].Width = 70;
                    dgv.Columns["ReturnedOutstanding"].Width = 70;
                    dgv.Columns["NoteNumber"].Width = 70;
                    dgv.Columns["NoteDate"].Width = 70;
                    dgv.Columns["Amount"].Width = 70;
                    dgv.Columns["Check"].Width = 50;

                    dgv.Columns["CustomerID"].Visible = false;
                    dgv.Columns["CustomerName"].Visible = true;
                    dgv.Columns["Age30to60"].Visible = true;
                    dgv.Columns["Age60to90"].Visible = true;
                    dgv.Columns["Age90plus"].Visible = true;
                    dgv.Columns["ChequesInHand"].Visible = true;
                    dgv.Columns["ReturnedOutstanding"].Visible = true;
                    dgv.Columns["NoteNumber"].Visible = true;
                    dgv.Columns["NoteDate"].Visible = true;
                    dgv.Columns["Amount"].Visible = true;
                    dgv.Columns["Check"].Visible = true;

                    dgv.Columns["CustomerID"].HeaderText = "";
                    dgv.Columns["CustomerName"].HeaderText = "Customer Name";
                    dgv.Columns["Age30to60"].HeaderText = "30 - 60";
                    dgv.Columns["Age60to90"].HeaderText = "60 - 90";
                    dgv.Columns["Age90plus"].HeaderText = "90 Plus";
                    dgv.Columns["ChequesInHand"].HeaderText = "Ch. In-Hand";
                    dgv.Columns["ReturnedOutstanding"].HeaderText = "RC Total";
                    dgv.Columns["NoteNumber"].HeaderText = "Note No";
                    dgv.Columns["NoteDate"].HeaderText = "Note Date";
                    dgv.Columns["Amount"].HeaderText = "Amount";

                    dgv.Columns["ChequesInHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgv.Columns["ReturnedOutstanding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    break;
                case ProcessNote.ProductionJob:
                    dgv.Columns["CustomerID"].Width = 100;
                    dgv.Columns["CustomerName"].Width = 240;
                    dgv.Columns["Age30to60"].Width = 200;
                    dgv.Columns["Age60to90"].Width = 70;
                    dgv.Columns["Age90plus"].Width = 70;
                    dgv.Columns["ChequesInHand"].Width = 210;
                    dgv.Columns["ReturnedOutstanding"].Width = 165;
                    dgv.Columns["NoteNumber"].Width = 80;
                    dgv.Columns["NoteDate"].Width = 80;
                    dgv.Columns["Amount"].Width = 70;
                    dgv.Columns["Check"].Width = 50;

                    dgv.Columns["CustomerID"].Visible = false;
                    dgv.Columns["CustomerName"].Visible = true;
                    dgv.Columns["Age30to60"].Visible = false;
                    dgv.Columns["Age60to90"].Visible = false;
                    dgv.Columns["Age90plus"].Visible = false;
                    dgv.Columns["ChequesInHand"].Visible = true;
                    dgv.Columns["ReturnedOutstanding"].Visible = true;
                    dgv.Columns["NoteNumber"].Visible = true;
                    dgv.Columns["NoteDate"].Visible = true;
                    dgv.Columns["Amount"].Visible = false;
                    dgv.Columns["Check"].Visible = true;

                    dgv.Columns["CustomerID"].HeaderText = "Customer Code";
                    dgv.Columns["CustomerName"].HeaderText = "Customer Name";
                    dgv.Columns["Age30to60"].HeaderText = "30 - 60";
                    dgv.Columns["Age60to90"].HeaderText = "60 - 90";
                    dgv.Columns["Age90plus"].HeaderText = "90 Plus";
                    dgv.Columns["ChequesInHand"].HeaderText = "Item Name";
                    dgv.Columns["ReturnedOutstanding"].HeaderText = "Item Size";
                    dgv.Columns["NoteNumber"].HeaderText = "Job No";
                    dgv.Columns["NoteDate"].HeaderText = "Job Date";
                    dgv.Columns["Amount"].HeaderText = "Amount";

                    dgv.Columns["ChequesInHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns["ReturnedOutstanding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;
                case ProcessNote.iSR_Dept:
                    dgv.Columns["CustomerID"].Width = 140;
                    dgv.Columns["CustomerName"].Width = 140;
                    dgv.Columns["Age30to60"].Width = 200;
                    dgv.Columns["Age60to90"].Width = 70;
                    dgv.Columns["Age90plus"].Width = 70;
                    dgv.Columns["ChequesInHand"].Width = 140;
                    dgv.Columns["ReturnedOutstanding"].Width = 195;
                    dgv.Columns["NoteNumber"].Width = 80;
                    dgv.Columns["NoteDate"].Width = 80;
                    dgv.Columns["Amount"].Width = 70;
                    dgv.Columns["Check"].Width = 50;

                    dgv.Columns["CustomerID"].Visible = true;
                    dgv.Columns["CustomerName"].Visible = true;
                    dgv.Columns["Age30to60"].Visible = false;
                    dgv.Columns["Age60to90"].Visible = false;
                    dgv.Columns["Age90plus"].Visible = false;
                    dgv.Columns["ChequesInHand"].Visible = true;
                    dgv.Columns["ReturnedOutstanding"].Visible = true;
                    dgv.Columns["NoteNumber"].Visible = true;
                    dgv.Columns["NoteDate"].Visible = true;
                    dgv.Columns["Amount"].Visible = false;
                    dgv.Columns["Check"].Visible = true;

                    dgv.Columns["CustomerID"].HeaderText = "Requesting Department";
                    dgv.Columns["CustomerName"].HeaderText = "Requesting User Name";
                    dgv.Columns["Age30to60"].HeaderText = "30 - 60";
                    dgv.Columns["Age60to90"].HeaderText = "60 - 90";
                    dgv.Columns["Age90plus"].HeaderText = "90 Plus";
                    dgv.Columns["ChequesInHand"].HeaderText = "Issuing Location";
                    dgv.Columns["ReturnedOutstanding"].HeaderText = "Remarks";
                    dgv.Columns["NoteNumber"].HeaderText = "iSR Code";
                    dgv.Columns["NoteDate"].HeaderText = "iSR Date";
                    dgv.Columns["Amount"].HeaderText = "Amount";

                    dgv.Columns["ChequesInHand"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    dgv.Columns["ReturnedOutstanding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    break;
            }
        }
        #endregion



        //Pending Approval

        #region Display Pending Order Count
        public static decimal DisplayPendingOrder()
        {
            decimal count = 0;
            // count += GetInquiryCount();
            count += GetCustomerOrderCount();
            // count += GetDeliveryOrderCount();
            //  count += GetInvoiceCount();
            return count;
        }
        #endregion

        #region Pending Approved Count
        private static int GetInquiryCount()
        {
            int Count = 0;
            try
            {
                List<tbl_sasInquiry> details = tbl_sasInquiry.SelectAll();
                foreach (tbl_sasInquiry detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && detail.Inquiry_ID != "default")
                    {
                        Count++;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Count;
        }
        private static int GetCustomerOrderCount()
        {
            int Count = 0;
            try
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && detail.CustomerOrder_ID != "default")
                    {
                        Count++;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Count;
        }
        private static int GetDeliveryOrderCount()
        {
            int Count = 0;
            try
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && detail.DeliveryOrder_ID != "default")
                    {
                        Count++;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Count;
        }
        private static int GetInvoiceCount()
        {
            int Count = 0;
            try
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && detail.Invoice_ID != "default")
                    {
                        Count++;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Count;
        }
        #endregion


        //update Approval Status

        #region Update Approval Inquriy
        public static void UpdateApprovalInquiry(string sNoteID, string sUserID, DateTime dtpApprovedDate)
        {
            tbl_sasInquiry detail = tbl_sasInquiry.Select(sNoteID);
            if (detail != null && detail.Inquiry_ID != "default")
            {
                detail.IsApproved = true;
                detail.ApprovedUser_ID = sUserID;
                detail.DateApproved = dtpApprovedDate;
                detail.Update();
            }
        }
        #endregion

        #region Update Approval CustomerOrder
        public static void UpdateApprovalCustomerOrder(string sNoteID, string sUserID, DateTime dtpApprovedDate)
        {
            tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sNoteID);
            if (detail != null && detail.CustomerOrder_ID != "default")
            {
                detail.IsApproved = true;
                detail.ApprovedUser_ID = sUserID;
                detail.DateApproved = dtpApprovedDate;
                detail.Update();
            }
        }
        #endregion

        #region Update Approval DeliveryOrder
        public static void UpdateApprovalDeliveryOrder(string sNoteID, string sUserID, DateTime dtpApprovedDate)
        {
            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sNoteID);
            if (detail != null && detail.DeliveryOrder_ID != "default")
            {
                detail.IsApproved = true;
                detail.ApprovedUser_ID = sUserID;
                detail.DateApproved = dtpApprovedDate;
                detail.Update();
            }
        }
        #endregion

        #region Update Approval Invoice
        public static void UpdateApprovalInvoice(string sNoteID, string sUserID, DateTime dtpApprovedDate)
        {
            tbl_sasInvoice detail = tbl_sasInvoice.Select(sNoteID);
            if (detail != null && detail.Invoice_ID != "default")
            {
                detail.IsApproved = true;
                detail.ApprovedUser_ID = sUserID;
                detail.DateApproved = dtpApprovedDate;
                detail.Update();
            }
        }
        #endregion


        //Set Process Flow



        #region Set Process Flow - Stock - External
        //public static void SetProcessFlow_Stock_External(string sIssuedRefNo, TextBox txtRequisition, TextBox txtPurchaseOrder, TextBox txtGoodReceive, TextBox txtPurchaseReturned, CheckBox chkSettings)
        public static void SetProcessFlow_Stock_External(string sIssuedRefNo, TextBox txtRequisition, TextBox txtPurchaseOrder, TextBox txtGoodReceive, TextBox txtPurchaseReturned)
        {
            try
            {
                //chkSettings.Checked = false;
                bool bRequsition = false, bPurchseOrder = false, bGoodReceive = false, bPurchaseReturned = false;

                //Purchase Requsition
                List<tbl_scsPurchaseRequisition> oPR = tbl_scsPurchaseRequisition.SelectAllByIssuedRefNo_ID(sIssuedRefNo);
                if (oPR.Count > 0)
                    bRequsition = true;

                //Purchase Order
                List<tbl_scsPurchaseOrder> oPO = tbl_scsPurchaseOrder.SelectAllByIssuedRefNo_ID(sIssuedRefNo);
                if (oPO.Count > 0)
                    bPurchseOrder = true;

                //Good Receive
                List<tbl_scsExternalGoodReceivedNote> oGRN = tbl_scsExternalGoodReceivedNote.SelectAllByIssuedRefNo_ID(sIssuedRefNo);
                if (oGRN.Count > 0)
                    bGoodReceive = true;

                //PRN
                List<tbl_scsPurchaseReturnedNote> oPRN = tbl_scsPurchaseReturnedNote.SelectAllByIssuedRefNo_ID(sIssuedRefNo);
                if (oPRN.Count > 0)
                    bPurchaseReturned = true;


                //clear text boxes colour
                txtRequisition.ForeColor = Color.Gray;
                txtPurchaseOrder.ForeColor = Color.Gray;
                txtGoodReceive.ForeColor = Color.Gray;
                txtPurchaseReturned.ForeColor = Color.Gray;


                //asign colours
                if (bRequsition)
                    txtRequisition.ForeColor = Color.Red;
                if (bPurchseOrder)
                    txtPurchaseOrder.ForeColor = Color.Red;
                if (bGoodReceive)
                    txtGoodReceive.ForeColor = Color.Red;
                if (bPurchaseReturned)
                    txtPurchaseReturned.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Set Process Flow Stock Internal
        public static void SetProcessFlow_Stock_Internal(string sOrderRefID, TextBox txtFlowSR, TextBox txtFlowGIN, TextBox txtFlowGRN)
        {
            try
            {
                //chkSettings.Checked = false;
                bool bStoreReqositionNote = false, bSectionReqositionNote = false, bDepartmentReqositionNote = false, bStoreGoodIssueNote = false, bSectionGoodIssueNote = false,
                     bStoreGoodReceiveNote = false, bSectionGoodReceiveNote = false;

                //Store Reqosition Note
                List<tbl_scsStoreReqositionNote> oStoreReqositionNote = tbl_scsStoreReqositionNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oStoreReqositionNote.Count > 0)
                    bStoreReqositionNote = true;

                //Section Reqosition Note
                List<tbl_scsSectionReqositionNote> oSectionReqositionNote = tbl_scsSectionReqositionNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oSectionReqositionNote.Count > 0)
                    bSectionReqositionNote = true;

                //Department Reqosition Note
                List<tbl_scsDepartmentReqositionNote> oDepartmentReqositionNote = tbl_scsDepartmentReqositionNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oDepartmentReqositionNote.Count > 0)
                    bDepartmentReqositionNote = true;

                // Store Good IssueNote
                List<tbl_scsStoreGoodIssueNote> oStoreGoodIssueNote = tbl_scsStoreGoodIssueNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oStoreGoodIssueNote.Count > 0)
                    bStoreGoodIssueNote = true;

                // Store Good IssueNote
                List<tbl_scsSectionGoodIssueNote> oSectionGoodIssueNote = tbl_scsSectionGoodIssueNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oSectionGoodIssueNote.Count > 0)
                    bSectionGoodIssueNote = true;

                // Store Good IssueNote
                List<tbl_scsStoreGoodReceiveNote> oStoreGoodReceiveNote = tbl_scsStoreGoodReceiveNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oStoreGoodReceiveNote.Count > 0)
                    bStoreGoodReceiveNote = true;

                // Store Good IssueNote
                List<tbl_scsSectionGoodReceiveNote> oSectionGoodReceiveNote = tbl_scsSectionGoodReceiveNote.SelectAllByIssuedRefNo_ID(sOrderRefID);
                if (oSectionGoodReceiveNote.Count > 0)
                    bSectionGoodReceiveNote = true;


                //clear text boxes colour
                txtFlowSR.ForeColor = Color.Gray;
                txtFlowGIN.ForeColor = Color.Gray;
                txtFlowGRN.ForeColor = Color.Gray;

                //asign colours
                if (bStoreReqositionNote || bSectionReqositionNote || bDepartmentReqositionNote)
                    txtFlowSR.ForeColor = Color.Red;

                if (bStoreGoodIssueNote || bSectionGoodIssueNote)
                    txtFlowGIN.ForeColor = Color.Red;

                if (bSectionGoodReceiveNote || bStoreGoodReceiveNote)
                    txtFlowGRN.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Set Process Flow - Payment SubAgent
        public static void SetProcessFlow_PaymentSubAgent(TextBox txtReceipt, TextBox txtPAdvice, bool bPAdviced, TextBox txtPaid, bool bPaymentPaid)
        {
            try
            {
                bool bReceipt = true;

                //clear text boxes colour
                txtReceipt.ForeColor = Color.Gray;
                txtPAdvice.ForeColor = Color.Gray;
                txtPaid.ForeColor = Color.Gray;

                //asign colours
                if (bReceipt)
                    txtReceipt.ForeColor = Color.Red;
                if (bPAdviced)
                    txtPAdvice.ForeColor = Color.Red;
                if (bPaymentPaid)
                    txtPaid.ForeColor = Color.Red;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //Clear

        #region Recursive Clear All TextBox
        public static void RecursiveClearTextBoxes(Control.ControlCollection cc)
        {
            foreach (Control ctrl in cc)
            {
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                {
                    tb.Clear();
                    tb.Tag = null;
                }
                else
                    RecursiveClearTextBoxes(ctrl.Controls);
            }
        }
        #endregion


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


        // Customer Outstandings

        #region Get Credit Limit
        public static decimal GetCustomerCreditLimit(string sCustomerID)
        {
            decimal dCreditBalance = 0;
            tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(sCustomerID);
            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sCustomerID);
            if (detail != null && finance != null)
            {
                dCreditBalance = finance.CreditLimit + finance.DepositAmount;
            }
            return dCreditBalance;
        }
        #endregion

        #region Get Total Credit Balance
        public static decimal GetCustomerCreditBalance(string sCustomerID)
        {
            decimal dCreditBalance = 0, dTotalIncome = 0, dTotalDues = 0;
            tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(sCustomerID);
            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sCustomerID);
            if (detail != null && finance != null)
            {
                dTotalIncome = finance.CreditLimit + finance.DepositAmount;
                dTotalDues = GetCustomerTotalDues_All(sCustomerID);
                dCreditBalance = dTotalIncome - dTotalDues;
            }
            return dCreditBalance;
        }
        #endregion

        #region Get Total Dues - Invoice
        public static decimal GetCustomerTotalDues_Invoice(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice30till(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 30 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 60)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice30to60(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 30 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 60)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice60to90(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 60 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 90)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice90plus(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 90)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total Dues - Openiing Balnace
        public static decimal GetCustomerTotalDues_OpeningBalance(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && detail.IsOpeningBalance)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total Dues - Returned Cheques
        public static decimal GetCustomerTotalDues_ReturnedCheque(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && detail.IsReturnedCheque)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total - Over Payments
        public static decimal GetCustomerTotal_UnsettledPayements(string sCustomerID)
        {
            decimal dTotalPayments = 0;

            //Cash         
            //foreach (tbl_bpsReceipt cash in tbl_bpsReceipt.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsSeattled && p.CashAmount > p.SeattleAmount))
            //{
            //    dTotalPayments += (cash.CashAmount - cash.SeattleAmount);
            //}

            //Cheques
            foreach (tbl_bpsChequeRegister cheque in tbl_bpsChequeRegister.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsSetteled && p.Amount > p.SetteledAmount))
            {
                dTotalPayments += (cheque.Amount - cheque.SetteledAmount);
            }

            //Credit Notes
            foreach (tbl_bpsCreditNote credit in tbl_bpsCreditNote.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && !p.IsSeattled && p.TotalAmount > p.SeattleAmount))
            {
                dTotalPayments += (credit.TotalAmount - credit.SeattleAmount);
            }
            return dTotalPayments;
        }
        #endregion

        #region Get Total Dues - All
        public static decimal GetCustomerTotalDues_All(string sCustomerID)
        {
            decimal dTotalDues = 0;
            foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsSeattled))
            {
                dTotalDues += detail.GrandTotal - detail.SeattleAmount;
            }

            dTotalDues -= GetCustomerTotal_UnsettledPayements(sCustomerID);

            return dTotalDues;
        }
        #endregion

        #region Get Customer Cheques In Hand
        public static decimal GetCustomerChequesInHand(string sCustomerID)
        {
            decimal dAmount = 0;
            foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReconcilied && !p.IsReIssued))
            {
                if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    dAmount += detail.Amount; //detail.ChequeAmount - detail.SetteledAmount;   
                }
            }
            return dAmount;
        }
        #endregion




        #region Get Qty - All Store Balance
        public static decimal GetQty_AllStoresBalance(string sItemCode, string sSubCategogry1, string sSubCategogry2, string sSerial1, string sSerial2)
        {
            decimal dRtn = 0;
            List<tbl_genStore_Stock> oStores = tbl_genStore_Stock.SelectAllByItem_ID(sItemCode);
            foreach (tbl_genStore_Stock oStore in oStores)
            {
                if (oStore.ItemSubCategory_ID == sSubCategogry1 && oStore.ItemSubCategory2_ID == sSubCategogry2 && oStore.ItemSerialNo == sSerial1 && oStore.ItemSerialNo2 == sSerial2)
                    dRtn += oStore.Qty;
            }

            List<tbl_genSection_Stock> oSections = tbl_genSection_Stock.SelectAllByItem_ID(sItemCode);
            foreach (tbl_genSection_Stock oSection in oSections)
            {
                if (oSection.ItemSubCategory_ID == sSubCategogry1 && oSection.ItemSubCategory2_ID == sSubCategogry2 && oSection.ItemSerialNo == sSerial1 && oSection.ItemSerialNo2 == sSerial2)
                    dRtn += oSection.Qty;
            }
            return dRtn;
        }
        #endregion

        #region Get Qty - Minimum PR Qty
        public static decimal GetQty_MinimumPR(string sItemCode, string sSubCategogry1, string sSubCategogry2, string sSerial1, string sSerial2)
        {
            decimal dRtn = 0;

            //From Item Finance
            //tbl_genItemMaster_Pricing item = tbl_genItemMaster_Pricing.Select(sItemCode, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
            //if (item != null)
            //{
            //    idecimal dAllBalance = GetQty_AllStoresBalance(sItemCode, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
            //    dRtn = oItemMaster.ReReoverLevel + oItemMaster.ReOrderQty - dAllBalance;
            //}

            //From Item Master
            tbl_genItemMaster oItemMaster = tbl_genItemMaster.Select(sItemCode);
            if (oItemMaster != null)
            {
                decimal dAllBalance = GetQty_AllStoresBalance(sItemCode, sSubCategogry1, sSubCategogry2, sSerial1, sSerial2);
                dRtn = dAllBalance - (oItemMaster.ReReoverLevel + oItemMaster.ReOrderQty);
            }
            return dRtn;
        }
        #endregion


        //Process Note
        #region Fill Process Notes
        public static void FillProcessNotes(string sOrderRefNo, DataGridView dgv, ProcessNote pn)
        {
            dgv.Rows.Clear();
            int iRow;
            switch (pn)
            {
                case ProcessNote.Inquiry:
                    foreach (tbl_sasInquiry objinquiry in tbl_sasInquiry.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, "", objinquiry.Inquiry_ID, objinquiry.InquiryDate.ToShortDateString(), objinquiry.GrandTotal, dgv);
                    }
                    break;
                case ProcessNote.Quotation:
                    foreach (tbl_sasQuotation objQuotation in tbl_sasQuotation.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, "", objQuotation.Quotation_ID, objQuotation.QuotationDate.ToShortDateString(), objQuotation.GrandTotal, dgv);
                    }
                    break;
                case ProcessNote.ProforemaInvoice:
                    foreach (tbl_sasProformaInvoice objPInvoice in tbl_sasProformaInvoice.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, "", objPInvoice.ProformaInvoice_ID, objPInvoice.ProformaInvoiceDate.ToShortDateString(), objPInvoice.GrandTotal, dgv);
                    }
                    break;
                case ProcessNote.CustomerOrder:
                    foreach (tbl_sasCustomerOrder objCustomerOrder in tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, "", objCustomerOrder.CustomerOrder_ID, objCustomerOrder.CustomerOrderDate.ToShortDateString(), objCustomerOrder.GrandTotal, dgv);
                    }
                    break;
                case ProcessNote.DeliveryOrder:
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                    {
                        foreach (tbl_sasInvDeliveryOrder objDeliveryOrder in tbl_sasInvDeliveryOrder.SelectAllByOrderRefNo_ID(sOrderRefNo))
                        {
                            dgv.Rows.Add();
                            iRow = dgv.Rows.Count - 1;
                            clsHelpMethods.Fill_NoteDatagrid(iRow, "", objDeliveryOrder.IDeliveryOrder_ID, objDeliveryOrder.IDeliveryOrderDate.ToShortDateString(), objDeliveryOrder.GrandTotal, dgv);
                        }
                    }
                    else
                    {
                        foreach (tbl_sasDeliveryOrder objDeliveryOrder in tbl_sasDeliveryOrder.SelectAllByOrderRefNo_ID(sOrderRefNo))
                        {
                            dgv.Rows.Add();
                            iRow = dgv.Rows.Count - 1;
                            clsHelpMethods.Fill_NoteDatagrid(iRow, objDeliveryOrder.CustomerOrder_ID, objDeliveryOrder.DeliveryOrder_ID, objDeliveryOrder.DeliveryOrderDate.ToShortDateString(), objDeliveryOrder.GrandTotal, dgv);
                        }
                    }
                    break;
                case ProcessNote.Invoice:
                    foreach (tbl_sasInvoice objInvoice in tbl_sasInvoice.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, objInvoice.DeliveryOrder_ID, objInvoice.Invoice_ID, objInvoice.InvoiceDate.ToShortDateString(), objInvoice.GrandTotal, dgv);
                    }
                    break;
                case ProcessNote.Receipt:
                    foreach (tbl_bpsReceipt_Invoice objReceipt in tbl_bpsReceipt_Invoice.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        tbl_bpsReceipt detail = tbl_bpsReceipt.Select(objReceipt.Receipt_ID);
                        if (detail != null && detail.Receipt_ID != "default")
                        {
                            dgv.Rows.Add();
                            iRow = dgv.Rows.Count - 1;
                            clsHelpMethods.Fill_NoteDatagrid(iRow, detail.Invoice_ID, detail.Receipt_ID, detail.ReceiptDate.ToShortDateString(), detail.TotalAmount, dgv);
                        }
                    }
                    break;
                case ProcessNote.SalesReturned:
                    foreach (tbl_sasSalesReturnedNote objSalesReturned in tbl_sasSalesReturnedNote.SelectAllByOrderRefNo_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, objSalesReturned.Invoice_ID, objSalesReturned.SalesReturnedNote_ID, objSalesReturned.SalesReturnedNoteDate.ToShortDateString(), objSalesReturned.GrandTotal, dgv);
                    }
                    break;

                //APN
                case ProcessNote.PaymentVoucher:
                    foreach (tbl_accPaymentVoucher_Detail objPaymentVoucher in tbl_accPaymentVoucher_Detail.SelectAllByPaymentVoucher_ID(sOrderRefNo))
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(objPaymentVoucher.AccountPayableNote_ID);
                        clsHelpMethods.Fill_NoteDatagrid(iRow, objPaymentVoucher.PaymentVoucher_ID, objPaymentVoucher.AccountPayableNote_ID, oAPN.BillDate.ToShortDateString(), objPaymentVoucher.SettleAmount, dgv);
                    }
                    break;
            }
        }

        public static void FillProcessNotes(List<string> sOrderRefNos, DataGridView dgv, ProcessNote pn)
        {
            dgv.Rows.Clear();
            int iRow;
            switch (pn)
            {
                case ProcessNote.Inquiry:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasInquiry> objInquiries = tbl_sasInquiry.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasInquiry objinquiry in objInquiries)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, "", objinquiry.Inquiry_ID, objinquiry.InquiryDate.ToShortDateString(), objinquiry.GrandTotal, dgv);
                            }
                        }
                    }
                    break;
                case ProcessNote.Quotation:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasQuotation> objQuotations = tbl_sasQuotation.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasQuotation objQuotation in objQuotations)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, "", objQuotation.Quotation_ID, objQuotation.QuotationDate.ToShortDateString(), objQuotation.GrandTotal, dgv);
                            }
                        }
                    }
                    break;
                case ProcessNote.ProforemaInvoice:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasProformaInvoice> objPInvoices = tbl_sasProformaInvoice.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasProformaInvoice objPInvoice in objPInvoices)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, "", objPInvoice.ProformaInvoice_ID, objPInvoice.ProformaInvoiceDate.ToShortDateString(), objPInvoice.GrandTotal, dgv);
                            }
                        }
                    }
                    break;
                case ProcessNote.CustomerOrder:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasCustomerOrder> objCustomerOrders = tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasCustomerOrder objCustomerOrder in objCustomerOrders)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, "", objCustomerOrder.CustomerOrder_ID, objCustomerOrder.CustomerOrderDate.ToShortDateString(), objCustomerOrder.GrandTotal, dgv);
                            }
                        }
                    }
                    break;
                case ProcessNote.DeliveryOrder:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            {
                                List<tbl_sasInvDeliveryOrder> objDeliveryOrders = tbl_sasInvDeliveryOrder.SelectAllByOrderRefNo_ID(sOrderRefNo);
                                foreach (tbl_sasInvDeliveryOrder objDeliveryOrder in objDeliveryOrders)
                                {
                                    dgv.Rows.Add();
                                    iRow = dgv.Rows.Count - 1;
                                    clsHelpMethods.Fill_NoteDatagrid(iRow, "", objDeliveryOrder.IDeliveryOrder_ID, objDeliveryOrder.IDeliveryOrderDate.ToShortDateString(), objDeliveryOrder.GrandTotal, dgv);
                                }
                            }
                            else
                            {
                                List<tbl_sasDeliveryOrder> objDeliveryOrders = tbl_sasDeliveryOrder.SelectAllByOrderRefNo_ID(sOrderRefNo);
                                foreach (tbl_sasDeliveryOrder objDeliveryOrder in objDeliveryOrders)
                                {
                                    dgv.Rows.Add();
                                    iRow = dgv.Rows.Count - 1;
                                    clsHelpMethods.Fill_NoteDatagrid(iRow, "", objDeliveryOrder.DeliveryOrder_ID, objDeliveryOrder.DeliveryOrderDate.ToShortDateString(), objDeliveryOrder.GrandTotal, dgv);
                                }
                            }
                        }
                    }
                    break;
                case ProcessNote.Invoice:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasInvoice> objInvoices = tbl_sasInvoice.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasInvoice objInvoice in objInvoices)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, objInvoice.DeliveryOrder_ID, objInvoice.Invoice_ID, objInvoice.InvoiceDate.ToShortDateString(), objInvoice.GrandTotal, dgv);
                            }
                        }
                    }
                    break;
                case ProcessNote.Receipt:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        List<tbl_bpsReceipt_Invoice> objReceipts = tbl_bpsReceipt_Invoice.SelectAllByOrderRefNo_ID(sOrderRefNo);
                        foreach (tbl_bpsReceipt_Invoice objReceipt in objReceipts)
                        {
                            if (sOrderRefNo != "default")
                            {
                                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(objReceipt.Receipt_ID);
                                if (detail != null)
                                {
                                    dgv.Rows.Add();
                                    iRow = dgv.Rows.Count - 1;
                                    clsHelpMethods.Fill_NoteDatagrid(iRow, detail.Invoice_ID, detail.Receipt_ID, detail.ReceiptDate.ToShortDateString(), detail.TotalAmount, dgv);
                                }
                            }
                        }
                    }
                    break;
                case ProcessNote.SalesReturned:
                    foreach (string sOrderRefNo in sOrderRefNos)
                    {
                        if (sOrderRefNo != "default")
                        {
                            List<tbl_sasSalesReturnedNote> objSalesReturneds = tbl_sasSalesReturnedNote.SelectAllByOrderRefNo_ID(sOrderRefNo);
                            foreach (tbl_sasSalesReturnedNote objSalesReturned in objSalesReturneds)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, objSalesReturned.Invoice_ID, objSalesReturned.SalesReturnedNote_ID, objSalesReturned.SalesReturnedNoteDate.ToShortDateString(), objSalesReturned.GrandTotal, dgv);
                            }
                        }
                    }
                    break;

            }
        }
        public static void FillProcessNotes(string sOrderRefNo, DataGridView dgv, ProcessNote pn, bool bSelect)
        {
            dgv.Rows.Clear();
            int iRow;
            switch (pn)
            {
                case ProcessNote.Invoice:
                    List<tbl_sasInvoice> objInvoices = tbl_sasInvoice.SelectAllByOrderRefNo_ID(sOrderRefNo);
                    foreach (tbl_sasInvoice objInvoice in objInvoices)
                    {
                        dgv.Rows.Add();
                        iRow = dgv.Rows.Count - 1;
                        clsHelpMethods.Fill_NoteDatagrid(iRow, objInvoice.Invoice_ID, objInvoice.InvoiceDate.ToShortDateString(), objInvoice.GrandTotal, bSelect, dgv);
                    }
                    break;
            }
        }
        public static void FillProcessNotes(List<string> sNotes, DataGridView dgv, ProcessNote pn, bool bSelect)
        {
            dgv.Rows.Clear();
            int iRow;
            switch (pn)
            {
                case ProcessNote.Invoice:
                    foreach (string sNote in sNotes)
                    {
                        if (sNote != "default")
                        {
                            tbl_sasInvoice objInvoice = tbl_sasInvoice.Select(sNote);
                            if (sNote != null)
                            {
                                dgv.Rows.Add();
                                iRow = dgv.Rows.Count - 1;
                                clsHelpMethods.Fill_NoteDatagrid(iRow, objInvoice.Invoice_ID, objInvoice.InvoiceDate.ToShortDateString(), objInvoice.GrandTotal, bSelect, dgv);
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Fill Process Note Datagrid
        public static void Fill_NoteDatagrid(int iRow, string sBaseNoteID, string sNoteID, string sDate, decimal dAmount, DataGridView dgvDetail)
        {
            try
            {
                if (sNoteID.Length > 0 && sNoteID != "default")
                {
                    dgvDetail["NoteID2", iRow].Value = sBaseNoteID;
                    dgvDetail["NoteID", iRow].Value = sNoteID;
                    dgvDetail["NoteDate", iRow].Value = sDate;
                    dgvDetail["NoteAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Fill_NoteDatagrid(int iRow, string sNoteID, string sDate, decimal dAmount, bool bSelect, DataGridView dgvDetail)
        {
            try
            {
                if (sNoteID.Length > 0 && sNoteID != "default")
                {
                    dgvDetail["NoteID", iRow].Value = sNoteID;
                    dgvDetail["NoteDate", iRow].Value = sDate;
                    dgvDetail["NoteAmount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["Select", iRow].Value = bSelect;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        //Terminal

        #region Get Host Name
        public static string GetHostName()
        {
            string macAddresses = Dns.GetHostName();
            return macAddresses;
        }
        #endregion

        #region Get Mac Address
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        #endregion

        #region Get IP Address
        public static string GetIPAddress()
        {
            string sIPAddress = "";
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (clsValidate.CheckValidityIPAddress(curAdd.ToString()))
                    {
                        sIPAddress = curAdd.ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
            return sIPAddress;
        }
        #endregion


        //Security Form 

        #region Get Form Name
        public static string getFormName(int iFormID)
        {
            string sFormName = "";
            tbl_securityFormMaster formMaster = tbl_securityFormMaster.Select(iFormID);
            if (formMaster != null)
                sFormName = formMaster.FormName;
            return sFormName;
        }
        #endregion

        //Petty Cash

        #region get Max lineno Petty Cash Transaction
        public static int GetMaxzimumLineNo_PettyCashTransaction(string sPettyCashAccountID)
        {
            int iMaxNo = 0;
            List<tbl_bpsPettyCashAccount_Transaction> details = tbl_bpsPettyCashAccount_Transaction.SelectAllByPettyCashAccount_ID(sPettyCashAccountID);
            foreach (tbl_bpsPettyCashAccount_Transaction detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return (iMaxNo + 1);
        }
        #endregion


        // Pending Approval / Checking / Auditing

        #region Get Pending Approval Count - Note Wise
        public static int GetPendingApprovalCount_ProcessNote(int sNoteID)
        {
            int iCount = 0;

            #region Sales
            //for Delivery Order            
            if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                        iCount++;
                }
            }
            //for Delivery Order
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DeliveryOrder_ID != "default")
                        iCount++;
                }
            }
            //for Invoice
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Invoice))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && !detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                        iCount++;
                }
            }
            //for Receipt
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Receipt))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.Receipt_ID != "default")
                        iCount++;
                }
            }
            //for Sales Returned
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.SalesReturnedNote_ID != "default")
                        iCount++;
                }
            }
            #endregion

            #region Stock
            //PO
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder))
            {
                List<tbl_scsPurchaseOrder> details = tbl_scsPurchaseOrder.SelectAll();
                foreach (tbl_scsPurchaseOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseOrder_ID != "default")
                        iCount++;
                }
            }
            //GRN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodReceivedNote))
            {
                List<tbl_scsExternalGoodReceivedNote> details = tbl_scsExternalGoodReceivedNote.SelectAll();
                foreach (tbl_scsExternalGoodReceivedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodReceivedNote_ID != "default")
                        iCount++;
                }
            }
            //GIN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodIssuedNote))
            {
                List<tbl_scsExternalGoodIssueNote> details = tbl_scsExternalGoodIssueNote.SelectAll();
                foreach (tbl_scsExternalGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodIssueNote_ID != "default")
                        iCount++;
                }
            }
            //PRN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseReturned))
            {
                List<tbl_scsPurchaseReturnedNote> details = tbl_scsPurchaseReturnedNote.SelectAll();
                foreach (tbl_scsPurchaseReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseReturnedNote_ID != "default")
                        iCount++;
                }
            }
            //PRN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.PurchaseRequisition))
            {
                List<tbl_scsPurchaseRequisition> details = tbl_scsPurchaseRequisition.SelectAll();
                foreach (tbl_scsPurchaseRequisition detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseRequisitionNote_ID != "default")
                        iCount++;
                }
            }
            //Adjustment
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment))
            {
                List<tbl_scsStockAdjustment> details = tbl_scsStockAdjustment.SelectAll();
                foreach (tbl_scsStockAdjustment detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StockAdjustment_ID != "default")
                        iCount++;
                }
            }
            //Split Note
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ItemSplitNote))
            {
                List<tbl_scsItemSpred> details = tbl_scsItemSpred.SelectAll();
                foreach (tbl_scsItemSpred detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ItemSpred_ID != "default")
                        iCount++;
                }
            }
            //DGN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DamageGoodNote))
            {
                List<tbl_scsDamagedGoodNote> details = tbl_scsDamagedGoodNote.SelectAll();
                foreach (tbl_scsDamagedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DamagedGoodNote_ID != "default")
                        iCount++;
                }
            }
            //DisGN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote))
            {
                List<tbl_scsDiscardedGoodNote> details = tbl_scsDiscardedGoodNote.SelectAll();
                foreach (tbl_scsDiscardedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DiscardedGoodNote_ID != "default")
                        iCount++;
                }
            }
            //iGRN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iGRN_Store))
            {
                List<tbl_scsStoreGoodReceiveNote> details = tbl_scsStoreGoodReceiveNote.SelectAll();
                foreach (tbl_scsStoreGoodReceiveNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodReceiveNote_ID != "default")
                        iCount++;
                }
            }
            //iGIN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iGIN_Store))
            {
                List<tbl_scsStoreGoodIssueNote> details = tbl_scsStoreGoodIssueNote.SelectAll();
                foreach (tbl_scsStoreGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodIssueNote_ID != "default")
                        iCount++;
                }
            }
            //iSRN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Store))
            {
                List<tbl_scsStoreReqositionNote> details = tbl_scsStoreReqositionNote.SelectAll();
                foreach (tbl_scsStoreReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreRecositionNote_ID != "default")
                        iCount++;
                }
            }
            //GTN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.GoodsTransferNote))
            {
                List<tbl_scsGoodTransferNote> details = tbl_scsGoodTransferNote.SelectAll();
                foreach (tbl_scsGoodTransferNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.GoodTransferNote_ID != "default")
                        iCount++;
                }
            }
            //FGTN
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote))
            {
                List<tbl_scsStoreProduction> details = tbl_scsStoreProduction.SelectAll();
                foreach (tbl_scsStoreProduction detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreProduction_ID != "default")
                        iCount++;
                }
            }
            #endregion

            #region Bills
            //for CreditNote
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CreditNote))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CreditNote_ID != "default")
                        iCount++;
                }
            }
            //for Cheque Register
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Cheque))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (!detail.IsDeleted && detail.ChequeRegister_ID != "default")
                        iCount++;
                }
            }
            #endregion
            //for Production Job
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob))
            {
                List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAll();
                foreach (tbl_pmsProductionJobRegister detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ProductionJob_ID != "default")
                        iCount++;
                }
            }
            //for Department Requisition
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept))
            {
                List<tbl_scsDepartmentReqositionNote> details = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DepartmentReqositionNote_ID != "default")
                        iCount++;
                }
            }

            return iCount;
        }
        #endregion

        #region Get Pending Approval Count - Cateogry Wise
        public static int GetPendingApprovalCount_ProcessNoteCategory(int iProcessNoteCategoryID)
        {
            int iCount = 0;

            #region Sales
            //for Customer Order
            tbl_securityProcessNoteMaster objProcessNote_CO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder));
            if (objProcessNote_CO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_CO.ProcessNote_ID))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                        iCount++;
                }
            }

            //for Delivery Order
            tbl_securityProcessNoteMaster objProcessNote_DO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder));
            if (objProcessNote_DO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_DO.ProcessNote_ID))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DeliveryOrder_ID != "default")
                        iCount++;
                }
            }
            //for Invoice
            tbl_securityProcessNoteMaster objProcessNote_Invoice = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Invoice));
            if (objProcessNote_Invoice.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Invoice.ProcessNote_ID))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && !detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                        iCount++;
                }
            }
            //for Receipt
            tbl_securityProcessNoteMaster objProcessNote_Receipt = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Receipt));
            if (objProcessNote_Receipt.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Receipt.ProcessNote_ID))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.Receipt_ID != "default")
                        iCount++;
                }
            }
            //for Sales Returned
            tbl_securityProcessNoteMaster objProcessNote_SalesReturned = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned));
            if (objProcessNote_SalesReturned.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_SalesReturned.ProcessNote_ID))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.SalesReturnedNote_ID != "default")
                        iCount++;
                }
            }
            #endregion

            #region Bills
            //for CreditNote
            tbl_securityProcessNoteMaster objProcessNote_CreditNote = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CreditNote));
            if (objProcessNote_CreditNote.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_CreditNote.ProcessNote_ID))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.CreditNote_ID != "default")
                        iCount++;
                }
            }
            //for Cheque Register
            tbl_securityProcessNoteMaster objProcessNote_Cheques = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Cheque));
            if (objProcessNote_Cheques.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Cheques.ProcessNote_ID))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (!detail.IsDeleted && detail.ChequeRegister_ID != "default")
                        iCount++;
                }
            }
            #endregion

            #region Stock
            //PO
            tbl_securityProcessNoteMaster objProcessNote_PO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.PurchaseOrder));
            if (objProcessNote_PO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_PO.ProcessNote_ID))
            {
                List<tbl_scsPurchaseOrder> details = tbl_scsPurchaseOrder.SelectAll();
                foreach (tbl_scsPurchaseOrder detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseOrder_ID != "default")
                        iCount++;
                }
            }
            //GRN
            tbl_securityProcessNoteMaster objProcessNote_GRN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodReceivedNote));
            if (objProcessNote_GRN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_GRN.ProcessNote_ID))
            {
                List<tbl_scsExternalGoodReceivedNote> details = tbl_scsExternalGoodReceivedNote.SelectAll();
                foreach (tbl_scsExternalGoodReceivedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodReceivedNote_ID != "default")
                        iCount++;
                }
            }
            //GIN
            tbl_securityProcessNoteMaster objProcessNote_GIN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.ExternalGoodIssuedNote));
            if (objProcessNote_GIN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_GIN.ProcessNote_ID))
            {
                List<tbl_scsExternalGoodIssueNote> details = tbl_scsExternalGoodIssueNote.SelectAll();
                foreach (tbl_scsExternalGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ExternalGoodIssueNote_ID != "default")
                        iCount++;
                }
            }
            //PRN
            tbl_securityProcessNoteMaster objProcessNote_PRN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.PurchaseReturned));
            if (objProcessNote_PRN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_PRN.ProcessNote_ID))
            {
                List<tbl_scsPurchaseReturnedNote> details = tbl_scsPurchaseReturnedNote.SelectAll();
                foreach (tbl_scsPurchaseReturnedNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseReturnedNote_ID != "default")
                        iCount++;
                }
            }
            //PRN
            tbl_securityProcessNoteMaster objProcessNote_PRQ = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.PurchaseRequisition));
            if (objProcessNote_PRQ.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_PRQ.ProcessNote_ID))
            {
                List<tbl_scsPurchaseRequisition> details = tbl_scsPurchaseRequisition.SelectAll();
                foreach (tbl_scsPurchaseRequisition detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.PurchaseRequisitionNote_ID != "default")
                        iCount++;
                }
            }
            //Adjustment
            tbl_securityProcessNoteMaster objProcessNote_Adj = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.StockAdjustment));
            if (objProcessNote_Adj.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Adj.ProcessNote_ID))
            {
                List<tbl_scsStockAdjustment> details = tbl_scsStockAdjustment.SelectAll();
                foreach (tbl_scsStockAdjustment detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StockAdjustment_ID != "default")
                        iCount++;
                }
            }
            //Split Note
            tbl_securityProcessNoteMaster objProcessNote_Split = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.ItemSplitNote));
            if (objProcessNote_Split.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Split.ProcessNote_ID))
            {
                List<tbl_scsItemSpred> details = tbl_scsItemSpred.SelectAll();
                foreach (tbl_scsItemSpred detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ItemSpred_ID != "default")
                        iCount++;
                }
            }
            //DGN
            tbl_securityProcessNoteMaster objProcessNote_DGN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.DamageGoodNote));
            if (objProcessNote_DGN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_DGN.ProcessNote_ID))
            {
                List<tbl_scsDamagedGoodNote> details = tbl_scsDamagedGoodNote.SelectAll();
                foreach (tbl_scsDamagedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DamagedGoodNote_ID != "default")
                        iCount++;
                }
            }
            //Dis.GN
            tbl_securityProcessNoteMaster objProcessNote_DisGN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.DisGoodNote));
            if (objProcessNote_DisGN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_DisGN.ProcessNote_ID))
            {
                List<tbl_scsDiscardedGoodNote> details = tbl_scsDiscardedGoodNote.SelectAll();
                foreach (tbl_scsDiscardedGoodNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DiscardedGoodNote_ID != "default")
                        iCount++;
                }
            }
            //iGRN
            tbl_securityProcessNoteMaster objProcessNote_iGRN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.iGRN_Store));
            if (objProcessNote_iGRN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_iGRN.ProcessNote_ID))
            {
                List<tbl_scsStoreGoodReceiveNote> details = tbl_scsStoreGoodReceiveNote.SelectAll();
                foreach (tbl_scsStoreGoodReceiveNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodReceiveNote_ID != "default")
                        iCount++;
                }
            }
            //iGIN
            tbl_securityProcessNoteMaster objProcessNote_iGIN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.iGIN_Store));
            if (objProcessNote_iGIN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_iGIN.ProcessNote_ID))
            {
                List<tbl_scsStoreGoodIssueNote> details = tbl_scsStoreGoodIssueNote.SelectAll();
                foreach (tbl_scsStoreGoodIssueNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreGoodIssueNote_ID != "default")
                        iCount++;
                }
            }
            //iSRN
            tbl_securityProcessNoteMaster objProcessNote_iSRN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.iSR_Store));
            if (objProcessNote_iSRN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_iSRN.ProcessNote_ID))
            {
                List<tbl_scsStoreReqositionNote> details = tbl_scsStoreReqositionNote.SelectAll();
                foreach (tbl_scsStoreReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreRecositionNote_ID != "default")
                        iCount++;
                }
            }
            //GTN
            tbl_securityProcessNoteMaster objProcessNote_GTN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.GoodsTransferNote));
            if (objProcessNote_GTN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_GTN.ProcessNote_ID))
            {
                List<tbl_scsGoodTransferNote> details = tbl_scsGoodTransferNote.SelectAll();
                foreach (tbl_scsGoodTransferNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.GoodTransferNote_ID != "default")
                        iCount++;
                }
            }
            //FGTN
            tbl_securityProcessNoteMaster objProcessNote_FGTN = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.FinishedGoodsTransferNote));
            if (objProcessNote_FGTN.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_FGTN.ProcessNote_ID))
            {
                List<tbl_scsStoreProduction> details = tbl_scsStoreProduction.SelectAll();
                foreach (tbl_scsStoreProduction detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.StoreProduction_ID != "default")
                        iCount++;
                }
            }
            #endregion

            //for Production Job
            tbl_securityProcessNoteMaster objProcessNote_ProductionJobs = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob));
            if (objProcessNote_ProductionJobs.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_ProductionJobs.ProcessNote_ID))
            {
                List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAll();
                foreach (tbl_pmsProductionJobRegister detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.ProductionJob_ID != "default")
                        iCount++;
                }
            }
            //for Department iSR
            tbl_securityProcessNoteMaster objProcessNote_Department_iSRs = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept));
            if (objProcessNote_Department_iSRs.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToApproveProcessNote(clsSecurity.UserIDLoged, objProcessNote_Department_iSRs.ProcessNote_ID))
            {
                List<tbl_scsDepartmentReqositionNote> details = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote detail in details)
                {
                    if (!detail.IsApproved && !detail.IsDeleted && !detail.IsFinished && detail.DepartmentReqositionNote_ID != "default")
                        iCount++;
                }
            }
            return iCount;
        }
        #endregion




        #region Get Pending Checking Count - Note Wise
        public static int GetPendingCheckingCount_ProcessNote(int sNoteID)
        {
            int iCount = 0;

            //for Customer Order
            if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                        iCount++;
                }
            }
            //for Delivery Order
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.DeliveryOrder_ID != "default")
                        iCount++;
                }
            }
            //for Invoice
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Invoice))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && !detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                        iCount++;
                }
            }
            //for Receipt
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Receipt))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.Receipt_ID != "default")
                        iCount++;
                }
            }
            //for Sales Returned
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.SalesReturnedNote_ID != "default")
                        iCount++;
                }
            }
            //for CreditNote
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CreditNote))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CreditNote_ID != "default")
                        iCount++;
                }
            }
            //for Cheque Register
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Cheque))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (!detail.IsDeleted && detail.ChequeRegister_ID != "default")
                        iCount++;
                }
            }
            //for Production Job
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob))
            {
                List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAll();
                foreach (tbl_pmsProductionJobRegister detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.ProductionJob_ID != "default")
                        iCount++;
                }
            }
            //for Department iSR
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept))
            {
                List<tbl_scsDepartmentReqositionNote> details = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.DepartmentReqositionNote_ID != "default")
                        iCount++;
                }
            }
            return iCount;
        }
        #endregion

        #region Get Pending Checking Count - Cateogry Wise
        public static int GetPendingCheckingCount_ProcessNoteCategory(int iProcessNoteCategoryID)
        {
            int iCount = 0;

            //for Customer Order
            tbl_securityProcessNoteMaster objProcessNote_CO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder));
            if (objProcessNote_CO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_CO.ProcessNote_ID))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                        iCount++;
                }
            }
            //for Delivery Order
            tbl_securityProcessNoteMaster objProcessNote_DO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder));
            if (objProcessNote_DO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_DO.ProcessNote_ID))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.DeliveryOrder_ID != "default")
                        iCount++;
                }
            }
            //for Invoice
            tbl_securityProcessNoteMaster objProcessNote_Invoice = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Invoice));
            if (objProcessNote_Invoice.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_Invoice.ProcessNote_ID))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && !detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                        iCount++;
                }
            }
            //for Receipt
            tbl_securityProcessNoteMaster objProcessNote_Receipt = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Receipt));
            if (objProcessNote_Receipt.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_Receipt.ProcessNote_ID))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.Receipt_ID != "default")
                        iCount++;
                }
            }
            //for Sales Returned
            tbl_securityProcessNoteMaster objProcessNote_SalesReturned = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned));
            if (objProcessNote_SalesReturned.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_SalesReturned.ProcessNote_ID))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.SalesReturnedNote_ID != "default")
                        iCount++;
                }
            }
            //for CreditNote
            tbl_securityProcessNoteMaster objProcessNote_CreditNote = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CreditNote));
            if (objProcessNote_CreditNote.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_CreditNote.ProcessNote_ID))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CreditNote_ID != "default")
                        iCount++;
                }
            }
            //for Cheque Register
            tbl_securityProcessNoteMaster objProcessNote_Cheques = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Cheque));
            if (objProcessNote_Cheques.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_Cheques.ProcessNote_ID))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (!detail.IsDeleted && detail.ChequeRegister_ID != "default")
                        iCount++;
                }
            }
            //for Production Job
            tbl_securityProcessNoteMaster objProcessNote_ProductionJobs = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.ProductionJob));
            if (objProcessNote_ProductionJobs.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_ProductionJobs.ProcessNote_ID))
            {
                List<tbl_pmsProductionJobRegister> details = tbl_pmsProductionJobRegister.SelectAll();
                foreach (tbl_pmsProductionJobRegister detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.ProductionJob_ID != "default")
                        iCount++;
                }
            }
            //for Department iSR
            tbl_securityProcessNoteMaster objProcessNote_Department_iSRs = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.iSR_Dept));
            if (objProcessNote_Department_iSRs.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToCheckProcessNote(clsSecurity.UserIDLoged, objProcessNote_Department_iSRs.ProcessNote_ID))
            {
                List<tbl_scsDepartmentReqositionNote> details = tbl_scsDepartmentReqositionNote.SelectAll();
                foreach (tbl_scsDepartmentReqositionNote detail in details)
                {
                    if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.DepartmentReqositionNote_ID != "default")
                        iCount++;
                }
            }
            return iCount;
        }
        #endregion


        #region Get Pending Audit Count - Note Wise
        public static int GetPendingAuditCount_ProcessNote(int sNoteID, bool bIsCanceled)
        {
            int iCount = 0;

            //for Customer Order
            if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    //tbl_audtra
                    //if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                    //    iCount++;
                }
            }
            //for Delivery Order
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (detail.DeliveryOrder_ID != "default")
                    {
                        tbl_audTransactioin_DeliveryOrder audDetail = tbl_audTransactioin_DeliveryOrder.Select(detail.DeliveryOrder_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Invoice
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Invoice))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                    {
                        tbl_audTransactioin_Invoice audDetail = tbl_audTransactioin_Invoice.Select(detail.Invoice_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Receipt
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Receipt))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (detail.Receipt_ID != "default")
                    {
                        tbl_audTransactioin_Receipt audDetail = tbl_audTransactioin_Receipt.Select(detail.Receipt_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Sales Returned
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (detail.SalesReturnedNote_ID != "default")
                    {
                        tbl_audTransactioin_SalesReturned audDetail = tbl_audTransactioin_SalesReturned.Select(detail.SalesReturnedNote_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for CreditNote
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.CreditNote))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (detail.CreditNote_ID != "default")
                    {
                        tbl_audTransactioin_CreditNote audDetail = tbl_audTransactioin_CreditNote.Select(detail.CreditNote_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Cheque Register
            else if (sNoteID == clsAutocode.GetProcessNoteID(ProcessNote.Cheque))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (detail.ChequeRegister_ID != "default")
                    {
                        tbl_audTransactioin_ChequeRegister audDetail = tbl_audTransactioin_ChequeRegister.Select(detail.ChequeRegister_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            return iCount;
        }
        #endregion

        #region Get Pending Audit Count - Cateogry Wise
        public static int GetPendingAuditCount_ProcessNoteCategory(int iProcessNoteCategoryID, bool bIsCanceled)
        {
            int iCount = 0;

            //for Customer Order
            tbl_securityProcessNoteMaster objProcessNote_CO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CustomerOrder));
            if (objProcessNote_CO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_CO.ProcessNote_ID))
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    //if (!detail.IsChecked && !detail.IsDeleted && !detail.IsFinished && detail.CustomerOrder_ID != "default")
                    //    iCount++;
                }
            }
            //for Delivery Order
            tbl_securityProcessNoteMaster objProcessNote_DO = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.DeliveryOrder));
            if (objProcessNote_DO.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_DO.ProcessNote_ID))
            {
                List<tbl_sasDeliveryOrder> details = tbl_sasDeliveryOrder.SelectAll();
                foreach (tbl_sasDeliveryOrder detail in details)
                {
                    if (detail.DeliveryOrder_ID != "default")
                    {
                        tbl_audTransactioin_DeliveryOrder audDetail = tbl_audTransactioin_DeliveryOrder.Select(detail.DeliveryOrder_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Invoice
            tbl_securityProcessNoteMaster objProcessNote_Invoice = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Invoice));
            if (objProcessNote_Invoice.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_Invoice.ProcessNote_ID))
            {
                List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAll();
                foreach (tbl_sasInvoice detail in details)
                {
                    if (!detail.IsOpeningBalance && !detail.IsReturnedCheque && detail.Invoice_ID != "default")
                    {
                        tbl_audTransactioin_Invoice audDetail = tbl_audTransactioin_Invoice.Select(detail.Invoice_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Receipt
            tbl_securityProcessNoteMaster objProcessNote_Receipt = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Receipt));
            if (objProcessNote_Receipt.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_Receipt.ProcessNote_ID))
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (detail.Receipt_ID != "default")
                    {
                        tbl_audTransactioin_Receipt audDetail = tbl_audTransactioin_Receipt.Select(detail.Receipt_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Sales Returned
            tbl_securityProcessNoteMaster objProcessNote_SalesReturned = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.SalesReturned));
            if (objProcessNote_SalesReturned.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_SalesReturned.ProcessNote_ID))
            {
                List<tbl_sasSalesReturnedNote> details = tbl_sasSalesReturnedNote.SelectAll();
                foreach (tbl_sasSalesReturnedNote detail in details)
                {
                    if (detail.SalesReturnedNote_ID != "default")
                    {
                        tbl_audTransactioin_SalesReturned audDetail = tbl_audTransactioin_SalesReturned.Select(detail.SalesReturnedNote_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for CreditNote
            tbl_securityProcessNoteMaster objProcessNote_CreditNote = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.CreditNote));
            if (objProcessNote_CreditNote.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_CreditNote.ProcessNote_ID))
            {
                List<tbl_bpsCreditNote> details = tbl_bpsCreditNote.SelectAll();
                foreach (tbl_bpsCreditNote detail in details)
                {
                    if (detail.CreditNote_ID != "default")
                    {
                        tbl_audTransactioin_CreditNote audDetail = tbl_audTransactioin_CreditNote.Select(detail.CreditNote_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            //for Cheque Register
            tbl_securityProcessNoteMaster objProcessNote_Cheques = tbl_securityProcessNoteMaster.Select(clsAutocode.GetProcessNoteID(ProcessNote.Cheque));
            if (objProcessNote_Cheques.ProcessNoteCategory_ID == iProcessNoteCategoryID && clsSecurity.PermissionToAuditProcessNote(clsSecurity.UserIDLoged, objProcessNote_Cheques.ProcessNote_ID))
            {
                List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
                foreach (tbl_bpsChequeRegister detail in details)
                {
                    if (detail.ChequeRegister_ID != "default")
                    {
                        tbl_audTransactioin_ChequeRegister audDetail = tbl_audTransactioin_ChequeRegister.Select(detail.ChequeRegister_ID, clsSecurity.UserIDLoged, bIsCanceled);
                        if (audDetail == null)
                            iCount++;
                    }
                }
            }
            return iCount;
        }
        #endregion



        // Oldest Invoice Date

        #region Get Olded Invoice Date
        public static DateTime getOldedInvoiceDate(List<string> invoiceIDs)
        {
            DateTime date = clsSecurity.getServerDateTime();
            foreach (string sInvoiceID in invoiceIDs)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoiceID);
                if (detail != null)
                {
                    if (date > detail.InvoiceDate)
                        date = detail.InvoiceDate;
                }
            }
            return date;
        }
        #endregion

        #region Get Invoice List
        public static string getInvoiceList(List<string> invoiceIDs)
        {
            string sInvoiceList = "";
            foreach (string sInvoiceID in invoiceIDs)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoiceID);
                if (detail != null)
                {
                    string sInvoiceNo = detail.Invoice_ID;
                    try
                    {
                        int y = detail.Invoice_ID.LastIndexOf("(");
                        int x = detail.Invoice_ID.LastIndexOf("/");
                        x++;

                        if (y > 0)
                            sInvoiceNo = detail.Invoice_ID.Substring(y);
                        else if (x > 0)
                            sInvoiceNo = detail.Invoice_ID.Substring(x);

                    }
                    catch (Exception) { }

                    if (sInvoiceList.Length > 0)
                        sInvoiceList += "," + sInvoiceNo;
                    else
                        sInvoiceList += sInvoiceNo;
                }
            }

            if (sInvoiceList.Length > 0)
                sInvoiceList = "[" + sInvoiceList + "]";
            return sInvoiceList;
        }
        #endregion

        //Get Max Line No
        #region Get Max LineNo - Store-isr
        public static int GetMaxzimumLineNoStoreReqositionNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sGinID);
            foreach (tbl_scsStoreReqositionNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - Section-isr
        public static int GetMaxzimumLineNoSectionReqositionNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsStoreReqositionNote_Detail> details = tbl_scsStoreReqositionNote_Detail.SelectAllByStoreRecositionNote_ID(sGinID);
            foreach (tbl_scsStoreReqositionNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - Department-isr
        public static int GetMaxzimumLineNoDepartmentReqositionNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsDepartmentReqositionNote_Detail> details = tbl_scsDepartmentReqositionNote_Detail.SelectAllByDepartmentReqositionNote_ID(sGinID);
            foreach (tbl_scsDepartmentReqositionNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - E-GIN
        public static int GetMaxzimumLineNoExternalGoodIssueNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsExternalGoodIssueNote_Detail> details = tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(sGinID);
            foreach (tbl_scsExternalGoodIssueNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - PO
        public static int GetMaxzimumLineNoPurchaseOrder(string sGrnID)
        {
            int iMaxNo = 0;
            List<tbl_scsPurchaseOrder_Detail> details = tbl_scsPurchaseOrder_Detail.SelectAllByPurchaseOrder_ID(sGrnID);
            foreach (tbl_scsPurchaseOrder_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - DGN
        public static int GetMaxzimumLineNoDameagedGoodsNote(string sDgnID)
        {
            int iMaxNo = 0;
            List<tbl_scsDamagedGoodNote_Detail> details = tbl_scsDamagedGoodNote_Detail.SelectAllByDamagedGoodNote_ID(sDgnID);
            foreach (tbl_scsDamagedGoodNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo - Double Entry Slot
        public static int GetMaxzimumLineNoDoubleEntrySlot(int pid)
        {
            int iMaxNo = 0;
            List<tbl_accDoubleEntrySlotDetails> details = tbl_accDoubleEntrySlotDetails.SelectAllBySlot_ID(pid);
            foreach (tbl_accDoubleEntrySlotDetails detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;

        }
        #endregion

        #region Get Max LineNO DiscardedGoodNote
        public static int GetMaxzimumLineNoDiscardedGoodNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsDiscardedGoodNote_Detail> details = tbl_scsDiscardedGoodNote_Detail.SelectAllByDiscardedGoodNote_ID(sGinID);
            foreach (tbl_scsDiscardedGoodNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo PRN
        public static int GetMaxzimumLineNoPurchaseReturnNote(string sPrnID)
        {
            int iMaxNo = 0;
            List<tbl_scsPurchaseReturnedNote_Detail> details = tbl_scsPurchaseReturnedNote_Detail.SelectAllByPurchaseReturnedNote_ID(sPrnID);
            foreach (tbl_scsPurchaseReturnedNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo LoanIn
        public static int GetMaxzimumLineNoLoanIN(string sLoanIn)
        {
            int iMaxNo = 0;
            List<tbl_scsLoanIn_Detail> details = tbl_scsLoanIn_Detail.SelectAllByLoanIn_ID(sLoanIn);
            foreach (tbl_scsLoanIn_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo LoanOut
        public static int GetMaxzimumLineNoLoanOut(string sLoanOut)
        {
            int iMaxNo = 0;
            List<tbl_scsLoanOut_Detail> details = tbl_scsLoanOut_Detail.SelectAllByLoanOut_ID(sLoanOut);
            foreach (tbl_scsLoanOut_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo E-GRN
        public static int GetMaxzimumLineNoExternalGoodReceiveNote(string sGrnID)
        {
            int iMaxNo = 0;
            List<tbl_scsExternalGoodReceivedNote_Detail> details = tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sGrnID);
            foreach (tbl_scsExternalGoodReceivedNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        public static int GetMaxzimumLineNoExternalGoodReceiveNote_Gem(string sGrnID)
        {
            int iMaxNo = 0;
            //List<tbl_scsExternalGoodReceivedNote_Detail_Gem> details = tbl_scsExternalGoodReceivedNote_Detail_Gem.SelectAllByExternalGoodReceivedNote_ID(sGrnID);
            //foreach (tbl_scsExternalGoodReceivedNote_Detail_Gem detail in details)
            //{
            //    if (detail.Line_No > iMaxNo)
            //        iMaxNo = detail.Line_No;
            //}
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Sec-GRN
        public static int GetMaxzimumLineNoSectionGoodReceiveNote(string sGrnID)
        {
            int iMaxNo = 0;
            List<tbl_scsSectionGoodReceiveNote_Detail> details = tbl_scsSectionGoodReceiveNote_Detail.SelectAllBySectionGoodReceiveNote_ID(sGrnID);
            foreach (tbl_scsSectionGoodReceiveNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Store-GRN
        public static int GetMaxzimumLineNoStoreGoodReceiveNote(string sGrnID)
        {
            int iMaxNo = 0;
            List<tbl_scsStoreGoodReceiveNote_Detail> details = tbl_scsStoreGoodReceiveNote_Detail.SelectAllByStoreGoodReceiveNote_ID(sGrnID);
            foreach (tbl_scsStoreGoodReceiveNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Store-GIN
        public static int GetMaxzimumLineNoStoreGoodIssueNote(string sGinID)
        {
            int iMaxNo = 0;
            List<tbl_scsStoreGoodIssueNote_Detail> details = tbl_scsStoreGoodIssueNote_Detail.SelectAllByStoreGoodIssueNote_ID(sGinID);
            foreach (tbl_scsStoreGoodIssueNote_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Store-GTN
        public static int GetMaxzimumLineNoGoodsTransferNote(string sGTNID)
        {
            int iMaxNo = 0;

            foreach (tbl_scsGoodTransferNote_Detail detail in tbl_scsGoodTransferNote_Detail.SelectAllByGoodTransferNote_ID(sGTNID))
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Inquiry
        public static int GetMaxzimumLineNo_Inquiry(string sID)
        {
            int iMaxNo = 0;
            List<tbl_sasInquiry_Detail> details = tbl_sasInquiry_Detail.SelectAllByInquiry_ID(sID);
            foreach (tbl_sasInquiry_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Quotation
        public static int GetMaxzimumLineNo_Quotation(string sID)
        {
            int iMaxNo = 0;
            List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sID);
            foreach (tbl_sasQuotation_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Customer Order
        public static int GetMaxzimumLineNo_CustomerOrder(string sID)
        {
            int iMaxNo = 0;
            List<tbl_sasCustomerOrder_Detail> details = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sID);
            foreach (tbl_sasCustomerOrder_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Delivery Order
        public static int GetMaxzimumLineNo_DeliveryOrder(string sID)
        {
            int iMaxNo = 0;
            List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sID);
            foreach (tbl_sasDeliveryOrder_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Invoice
        public static int GetMaxzimumLineNo_Invoice(string sID)
        {
            int iMaxNo = 0;
            List<tbl_sasInvoice_Detail> details = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sID);
            foreach (tbl_sasInvoice_Detail detail in details)
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo Company Branch
        public static int GetMaxzimumLineNo_CompanyBranch(string sID)
        {
            int iMaxNo = 0;
            foreach (tbl_genCompanyBranchMaster detail in tbl_genCompanyBranchMaster.SelectAllByCompanyCountry_ID(sID))
            {
                if (detail.LineNO > iMaxNo)
                    iMaxNo = detail.LineNO;
            }
            return iMaxNo + 1;
        }
        #endregion

        #region Get Max LineNo CreditNote
        public static int GetMaxzimumLineNo_CreditNote(string sID)
        {
            int iMaxNo = 0;

            foreach (tbl_bpsCreditNote_Invoice detail in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(sID))
            {
                if (detail.Line_No > iMaxNo)
                    iMaxNo = detail.Line_No;
            }
            return iMaxNo + 1;
        }
        #endregion

        // Get Purchase Order Number
        #region Get Customer PO ID
        public static string GetCustomerPurchaseOrderID(string sOrefNo)
        {
            string sPONo = "";
            List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(sOrefNo);// tbl_scsExternalGoodIssueNote_Detail.SelectAllByExternalGoodIssueNote_ID(sGinID);

            foreach (tbl_sasCustomerOrder detail in details)
            {
                if (detail.PurchaseOrder_ID != null)
                    sPONo = detail.PurchaseOrder_ID;
                break;
            }
            return sPONo;
        }
        #endregion

        #region Get Customer Order Date
        public static string getCustomerOrderDate(string sOrderReference_ID)
        {
            string value = "";
            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(sOrderReference_ID);
            if (order != null)
            {
                List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAllByOrderRefNo_ID(sOrderReference_ID);
                foreach (tbl_sasCustomerOrder detail in details)
                {
                    if (detail.Customer_ID != "default")
                        value = clsFormatter.FormatDate_Short(detail.CustomerOrderDate);
                    break;
                }
            }
            return value;
        }
        #endregion

        // Reports
        #region Get Printer Name
        public static string GetPrinterName(string sReportID)
        {
            string sPrinterName = "", sPirnterID = "";
            tbl_securityReportMaster report = tbl_securityReportMaster.Select(sReportID);
            if (report != null && report.Report_ID != "0")
            {
                if (report.IsSetPrinter)
                {
                    //search setting
                    List<tbl_securityReportSetting> pSettings = tbl_securityReportSetting.SelectAllByReport_ID(sReportID);
                    foreach (tbl_securityReportSetting pSetting in pSettings)
                    {
                        if (clsSecurity.UserIDLoged == pSetting.User_ID && clsSecurity.TerminalID == pSetting.Terminal_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            break;
                        }
                        else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            break;
                        }
                        else if (clsSecurity.UserIDLoged == pSetting.User_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            break;
                        }
                    }

                    //get printer name
                    tbl_zPrinterMaster pritner = tbl_zPrinterMaster.Select(sPrinterName);
                    if (pritner != null && pritner.Printer_ID != "default")
                    {
                        sPrinterName = pritner.PrinterName;
                    }
                }
                else
                    sPrinterName = GetDefaultPrinter();

            }
            return sPrinterName;
        }
        #endregion

        #region Set Printer Setting
        public static void SetPrinterSetting(string iReportID, ref ReportDocument RD)
        {
            try
            {
                tbl_securityReportMaster report = tbl_securityReportMaster.Select(iReportID);
                if (report != null)
                {
                    string sPirnterID = "", sPaperID = "";

                    if (report.IsSetPaper)
                    {
                        List<tbl_securityReportSetting> pSettings = tbl_securityReportSetting.SelectAllByReport_ID(iReportID);
                        foreach (tbl_securityReportSetting pSetting in pSettings)
                        {
                            if (clsSecurity.UserIDLoged == pSetting.User_ID && clsSecurity.TerminalID == pSetting.Terminal_ID)
                            {
                                sPaperID = pSetting.Paper_ID;
                                break;
                            }
                            else if (clsSecurity.UserIDLoged == pSetting.User_ID)
                                sPaperID = pSetting.Paper_ID;
                            else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
                                sPaperID = pSetting.Paper_ID;


                            tbl_zPaperMaster paper = tbl_zPaperMaster.Select(sPaperID);
                            if (paper != null && paper.Paper_ID != "default")
                            {
                                SetPaperSize(ref RD, paper.PaperName);
                            }
                        }
                    }

                    if (report.IsSetPrinter)
                    {
                        List<tbl_securityReportSetting> pSettings = tbl_securityReportSetting.SelectAllByReport_ID(iReportID);
                        foreach (tbl_securityReportSetting pSetting in pSettings)
                        {
                            if (clsSecurity.UserIDLoged == pSetting.User_ID && clsSecurity.TerminalID == pSetting.Terminal_ID)
                            {
                                sPirnterID = pSetting.Printer_ID;
                                break;
                            }
                            else if (clsSecurity.UserIDLoged == pSetting.User_ID)
                                sPirnterID = pSetting.Printer_ID;
                            else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
                                sPirnterID = pSetting.Printer_ID;


                            tbl_zPrinterMaster pritner = tbl_zPrinterMaster.Select(sPirnterID);
                            if (pritner != null && pritner.Printer_ID != "default")
                            {
                                RD.PrintOptions.PrinterName = pritner.PrinterName;
                            }
                            else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
                            {
                                sPirnterID = pSetting.Printer_ID;
                                sPaperID = pSetting.Paper_ID;
                                break;
                            }

                            else
                                RD.PrintOptions.PrinterName = GetDefaultPrinter();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SetPrinterSetting(string iReportID, ref PrintDocument PD)
        {
            string sPirnterID = "", sPaperID = "";// string sPrinterName = "";
            tbl_securityReportMaster report = tbl_securityReportMaster.Select(iReportID);
            if (report != null && report.Report_ID != "0")
            {
                if (report.IsSetPrinter)
                {
                    //search setting
                    List<tbl_securityReportSetting> pSettings = tbl_securityReportSetting.SelectAllByReport_ID(iReportID);
                    foreach (tbl_securityReportSetting pSetting in pSettings)
                    {
                        if (clsSecurity.UserIDLoged == pSetting.User_ID && clsSecurity.TerminalID == pSetting.Terminal_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            sPaperID = pSetting.Paper_ID;
                            break;
                        }
                        else if (clsSecurity.UserIDLoged == pSetting.User_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            sPaperID = pSetting.Paper_ID;
                            break;
                        }
                        else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
                        {
                            sPirnterID = pSetting.Printer_ID;
                            sPaperID = pSetting.Paper_ID;
                            break;
                        }

                        else
                        {
                            sPirnterID = pSetting.Printer_ID;
                            sPaperID = pSetting.Paper_ID;
                            break;
                        }
                    }

                    //set printer name
                    tbl_zPrinterMaster pritner = tbl_zPrinterMaster.Select(sPirnterID);
                    if (pritner != null && pritner.Printer_ID != "default")
                    {
                        PD.PrinterSettings.PrinterName = pritner.PrinterName;
                    }
                }
                else
                    PD.PrinterSettings.PrinterName = GetDefaultPrinter();

                if (report.IsSetPaper)
                {
                    //set paper name
                    tbl_zPaperMaster paper = tbl_zPaperMaster.Select(sPaperID);
                    if (paper != null && paper.Paper_ID != "default")
                    {
                        SetPaperSize(ref PD, paper.PaperName);
                    }
                }
            }
        }
        #endregion

        #region Set Paper Size
        public static void SetPaperSize(ref ReportDocument RD, string sPaperName)
        {
            PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            int i;
            int rawKind = 0;

            for (i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                if (printDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperName)
                {
                    rawKind = (int)clsSecurity.GetField(printDoc.PrinterSettings.PaperSizes[i], "kind");

                }
            }
            RD.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
        }
        public static void SetPaperSize(ref PrintDocument PD, string sPaperName)
        {
            PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            int i;
            for (i = 0; i < printDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                if (printDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperName)
                {
                    PD.PrinterSettings.DefaultPageSettings.PaperSize = printDoc.PrinterSettings.PaperSizes[i];
                    break;
                }
            }
        }
        #endregion

        #region Get Default Printer
        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;
                if (settings.IsDefaultPrinter)
                    return printer;
            }
            return string.Empty;
        }
        #endregion

        // Currency
        #region Price Convertion
        public static decimal getSavePrice(TextBox txtPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtPrice.Text.Trim().Length > 0)
                dUnitPrice = decimal.Parse(txtPrice.Text.Trim());

            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            return (dUnitPrice * dExRate);
        }

        public static decimal getSavePrice(decimal dPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            dUnitPrice = dPrice * dExRate;
            return Math.Round(dUnitPrice, 2);
        }

        public static decimal getSavePrice(decimal dPrice, decimal dCurrencyRate)
        {
            decimal dUnitPrice = 0;

            dUnitPrice = dPrice * dCurrencyRate;
            return Math.Round(dUnitPrice, 2);
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
        //Tax

        #region Set VAT and NBT Values From GrandTotal

        #endregion
        // Stock Location - Select Area

        #region Get Select Area ID
        public static string getSelectAreaID(TextBox txtDepartmentID, TextBox txtSectionID, TextBox txtStoreID)
        {
            string rtn = "default";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Department);
            else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Section);
            else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim() != "default")
                rtn = clsAutocode.getSelectAreaCode(SelectArea.Store);

            return rtn;
        }

        #endregion

        #region Get ToLocation Name
        public static string GetToLocationName(string sSelectAreaID, string sDepartmentNoteID, string sSectionNoteID, string sStoreNoteID)
        {
            string value = "";
            if (clsAutocode.getSelectAreaCode(SelectArea.Default) == sSelectAreaID)
                value = "";
            if (clsAutocode.getSelectAreaCode(SelectArea.Department) == sSelectAreaID)
                value = clsGenaralName.getName_Department(sDepartmentNoteID);
            if (clsAutocode.getSelectAreaCode(SelectArea.Section) == sSelectAreaID)
                value = clsGenaralName.getName_Section(sSectionNoteID);
            if (clsAutocode.getSelectAreaCode(SelectArea.Store) == sSelectAreaID)
                value = clsGenaralName.getName_Store(sStoreNoteID);
            return value;
        }
        public static string getToLocationName(TextBox txtDepartmentID, TextBox txtSectionID, TextBox txtStoreID)
        {
            string rtn = "N/A";
            if (txtDepartmentID.Tag != null && txtDepartmentID.Tag.ToString().Trim() != "default")
                rtn = clsGenaralName.getName_Department(txtDepartmentID.Tag.ToString().Trim());
            else if (txtSectionID.Tag != null && txtSectionID.Tag.ToString().Trim() != "default")
                rtn = clsGenaralName.getName_Section(txtSectionID.Tag.ToString().Trim());
            else if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim() != "default")
                rtn = clsGenaralName.getName_Store(txtStoreID.Tag.ToString().Trim());
            return rtn;
        }
        #endregion

        #region Get Location Name And ID
        public static string getLocationNameAndID_FromDeptSecStore(string sDepartmentID, string sSectionID, string sStoreID, ref string sLocationID, ref string sLocationName)
        {
            string rtn = "N/A";
            if (sDepartmentID != "default")
            {
                sLocationID = sDepartmentID;
                sLocationName = clsGenaralName.getName_Department(sDepartmentID);
            }
            else if (sSectionID != "default")
            {
                sLocationID = sSectionID;
                sLocationName = clsGenaralName.getName_Section(sSectionID);
            }
            else if (sStoreID != "default")
            {
                sLocationID = sStoreID;
                sLocationName = clsGenaralName.getName_Store(sStoreID);
            }
            return rtn;
        }
        #endregion

        #region Get Select Area Note ID
        public static string GetSelectAreaNoteID(string sSelectAreaID, string sDepartmentNoteID, string sSectionNoteID, string sStoreNoteID)
        {
            string value = "N/A";
            if (clsAutocode.getSelectAreaCode(SelectArea.Default) == sSelectAreaID)
                value = "N/A";
            if (clsAutocode.getSelectAreaCode(SelectArea.Department) == sSelectAreaID)
                value = sDepartmentNoteID;
            if (clsAutocode.getSelectAreaCode(SelectArea.Section) == sSelectAreaID)
                value = sSectionNoteID;
            if (clsAutocode.getSelectAreaCode(SelectArea.Store) == sSelectAreaID)
                value = sStoreNoteID;
            return value;
        }
        #endregion

        #region Set Printer Setting
        public static void SetPrinterSetting(int iReportID, ref ReportDocument RD)
        {
            //string sPrinterName = "", sPirnterID = "", sPaperID = "";
            //tbl_securityReportMaster report = tbl_securityReportMaster.Select(iReportID);
            //if (report != null && report.Report_ID != 0)
            //{
            //    if (report.IsSetPrinter)
            //    {
            //        //search setting
            //        List<tbl_securityReportSetting> pSettings = tbl_securityReportSetting.SelectAllByReport_ID(iReportID);
            //        foreach (tbl_securityReportSetting pSetting in pSettings)
            //        {
            //            if (clsSecurity.UserIDLoged == pSetting.User_ID && clsSecurity.TerminalID == pSetting.Terminal_ID)
            //            {
            //                sPirnterID = pSetting.Printer_ID;
            //                sPaperID = pSetting.Paper_ID;
            //                break;
            //            }
            //            else if (clsSecurity.UserIDLoged == pSetting.User_ID)
            //            {
            //                sPirnterID = pSetting.Printer_ID;
            //                sPaperID = pSetting.Paper_ID;
            //                break;
            //            }
            //            else if (clsSecurity.TerminalID == pSetting.Terminal_ID)
            //            {
            //                sPirnterID = pSetting.Printer_ID;
            //                sPaperID = pSetting.Paper_ID;
            //                break;
            //            }

            //            else
            //            {
            //                sPirnterID = pSetting.Printer_ID;
            //                sPaperID = pSetting.Paper_ID;
            //                break;
            //            }
            //        }

            //        //set printer name
            //        tbl_zPrinterMaster pritner = tbl_zPrinterMaster.Select(sPirnterID);
            //        if (pritner != null && pritner.Printer_ID != "default")
            //        {
            //            RD.PrintOptions.PrinterName = pritner.PrinterName;
            //        }
            //    }
            //    else
            //        RD.PrintOptions.PrinterName = GetDefaultPrinter();

            //    if (report.IsSetPaper)
            //    {
            //        //set paper name
            //        tbl_zPaperMaster paper = tbl_zPaperMaster.Select(sPaperID);
            //        if (paper != null && paper.Paper_ID != "default")
            //        {
            //            SetPaperSize(ref RD, paper.PaperName);
            //        }
            //    }
            //}
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
        //Branch
        #region Get Main StoreID by Company BranchID
        public static string GetMainStoreIDBy_BranchID(string sBranchID)
        {
            string value = "default";
            //foreach (tbl_genStoreMaster detail in tbl_genStoreMaster.SelectAllByCompanyBranch_ID(sBranchID).Where(p => !p.IsDeleted && p.Store_ID != "default" && p.IsMainStore))
            foreach (tbl_genStoreMaster detail in tbl_genStoreMaster.SelectAll().Where(p => p.CompanyBranch_ID == sBranchID && !p.IsDeleted && p.Store_ID != "default" && p.IsMainStore))
            {
                value = detail.Store_ID;
                break;
            }
            return value;
        }
        #endregion

        // SMS 




        public static bool Check_ProdApparel_Enable()
        {
            bool bStatus = false;

            tbl_cfgModule oModule = tbl_cfgModule.Select("PROD/016");
            if (oModule != null)
                bStatus = oModule.IsEnable;

            return bStatus;
        }
        #region Get Report Path
        public static string GetReportPath(string ReportID)
        {
            string s_Path = "";
            try
            {
                tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ReportID);
                if (detail != null)
                {
                    s_Path = detail.ReportPath.Trim();

                    tbl_securityReportMaster_CompanyBranch oRptBranchWice = tbl_securityReportMaster_CompanyBranch.Select(ReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oRptBranchWice != null)
                        s_Path = oRptBranchWice.ReportPath.Trim();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return s_Path;
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
        public static bool GetReportPath(string ReportID, ref string ReportName, ref string ReportName2, ref string s_Path)
        {
            ReportName = "";
            ReportName2 = "";
            try
            {
                tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ReportID);
                if (detail != null)
                {
                    s_Path = detail.ReportPath.Trim();
                    ReportName = detail.DisplayName.Trim();
                    if (detail.DisplayName2 != null)
                        ReportName2 = detail.DisplayName2.Trim();

                    tbl_securityReportMaster_CompanyBranch oRptBranchWice = tbl_securityReportMaster_CompanyBranch.Select(ReportID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oRptBranchWice != null)
                    {
                        s_Path = oRptBranchWice.ReportPath.Trim();
                        ReportName = oRptBranchWice.DisplayName.Trim();
                        if (oRptBranchWice.DisplayName2 != null)
                            ReportName2 = oRptBranchWice.DisplayName2.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

            if (s_Path == null || s_Path.Length <= 0)
            {
                MessageBox.Show("Report is not linked.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Get Report Display Name
        public static string GetReportDisplayName(string ReportID)
        {
            string s_DisplayName = "";
            tbl_securityReportMaster detail = tbl_securityReportMaster.Select(ReportID);
            if (detail != null)
                //s_DisplayName = detail.DisplayName2.Trim();

                //2017-05-08 Thilini
                s_DisplayName = detail.DisplayName;
            return s_DisplayName;
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

        //Progress Bar
        #region Start Progress Bar
        public static void startProgressBar(int minVal, int maxVal, int incrementVal, ProgressBar PB)
        {
            try
            {
                PB.Minimum = minVal;
                PB.Maximum = maxVal;

                PB.Value = PB.Value + incrementVal;
            }
            catch (Exception Ex)
            {
              //  MessageBox.Show(Ex.ToString(), "Progress Bar Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion





        #region Get Attachment ID
        public static int GetAttachmentID(string sTx_ID)
        {
            int i = 1;
            //string sTx_ID_Rev = sTx_ID.Replace("/", "-!");
            //sTx_ID_Rev = sTx_ID_Rev.Replace("\\", "-!");
            if (clsConfig.sAttachmentPath_Server == "")
                MessageBox.Show("Attachment saved path is Empty, Please Contact System Administrator...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string[] files = System.IO.Directory.GetFiles(clsConfig.sAttachmentPath_Server, sTx_ID + "-" + i + ".*");
                while (files.Length != 0)
                {
                    i++;
                    files = System.IO.Directory.GetFiles(clsConfig.sAttachmentPath_Server, sTx_ID + "-" + i + ".*");
                }
            }

            return i;
        }
        #endregion

        #region Add Multiple Items Grid
        public static void AddMultipleItems_Grid(DataGridView dgvDetail, string ItemID, ref int iRow, ref int iLineNo, ref decimal Qty, ref decimal UnitPrice, ref decimal Weight, ref decimal WeightAvg)
        {
            if (!clsConfig.bAllow_user_to_Dupplicate_items_SAS_Transactions)
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                    if (ItemID == sItemID)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);

                        iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                        UnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.0000"));
                        WeightAvg = clsValidate.ValidateGridValue(dgvDetail, "WeightAvg", row.Index, decimal.Parse("0.0000"));
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }
            }
        }
        #endregion

        #region Grid Line No Change
        public static void Grid_LineNoChange(DataGridView dgvDetail)
        {
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dgvDetail["RowCount", row.Index].Value = row.Index + 1;
            }
        }
        #endregion

        #region Get FloorStock Quantity
        public static decimal GetFlowStock_Qty(DateTime dtTodate, string sItem_ID, string sStore_ID)
        {
            decimal dFlowStockQty = 0;
            List<srh_scsFlowStock> oDetail = srh_scsFlowStock.Select(dtTodate.Date, sItem_ID, "0", clsSecurity.BranchID,true);
            var oStock = oDetail.Where(p => p.Store_ID == sStore_ID).GroupBy(cm =>
            new { cm.Item_ID }, (key, group) => new
            {
                itemId = key.Item_ID,
                qty = group.Sum(p => p.Qty)
            }).FirstOrDefault();

            if (oStock != null)
                dFlowStockQty = oStock.qty;

            return dFlowStockQty;
        }
        #endregion


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
}
