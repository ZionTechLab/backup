using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;
using System.Windows.Forms;

namespace Digiteq_Logic
{
    public class clsMethods_Fin
    {
        #region Get Credit Period
        public static decimal GetCustomerCreditPeriod(string sCustomerID)
        {
            decimal dCreditPeriod = 0;
            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sCustomerID);
            if (finance != null && finance.Customer_ID != "default")
                dCreditPeriod = finance.CreditPeriod;

            return dCreditPeriod;
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

            //overpayments
            dTotalDues -= GetCustomerTotal_UnsettledPayements(sCustomerID);

            return dTotalDues;
        }
        #endregion

        #region Get Customer Cheques In Hand
        public static decimal GetCustomerChequesInHand(string sCustomerID)
        {
            decimal dAmount = 0;
            foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReconcilied && !p.IsReturned && !p.IsReIssued))//p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReconcilied && !p.IsReIssued
            {
                if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    dAmount += detail.Amount; //detail.ChequeAmount - detail.SetteledAmount;   
                }
            }
            return dAmount;
        }
        #endregion


        //Asing Values
        #region Net Sales & Debit Value
        public static void assingValues_NetSalesAndDebitValue(ref decimal dNetSales_ForTheDay, ref decimal dNetSales_ForTheMonth, ref decimal dDebitValue_ForTheDay, ref decimal dDebitValue_ForTheMonth, DateTime dtNow, string sCompanyBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            List<tbl_sasInvoice> oInv;
            if (sCompanyBranchID != "default")
                oInv = tbl_sasInvoice.SelectAllByCompanyBranch_ID(sCompanyBranchID);
            else
                oInv = tbl_sasInvoice.SelectAll();

            foreach (tbl_sasInvoice oInvoice in oInv.Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsDebitNote && !p.IsOpeningBalance && !p.IsReturnedCheque && p.InvoiceDate >= dtFirstDayOfThisMonth && p.OtherTaxTotal == 0))
            {
                decimal dNetValue = 0, dDebitValue = 0;
                if (!oInvoice.IsDebitNote)
                    dNetValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage);
                else
                    dDebitValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage);

                if (oInvoice.InvoiceDate.Date == dtNow.Date)
                {
                    dNetSales_ForTheDay += dNetValue;
                    dDebitValue_ForTheDay += dDebitValue;
                }

                dNetSales_ForTheMonth += dNetValue;
                dDebitValue_ForTheMonth += dDebitValue;

            }
        }

        public static void assingValues_NetSalesAndDebitValue_UptoDate(ref decimal dNetSales_ForTheDay, ref decimal dNetSales_ForTheMonth, ref decimal dDebitValue_ForTheDay, ref decimal dDebitValue_ForTheMonth, DateTime dtFromDate, DateTime dtToDate, string sCompanyBranchID)
        {
            //DateTime dtFirstDayOfThisMonth = new DateTime(dtToDate.Year, dtToDate.Month, 1);

            List<tbl_sasInvoice> oInv;
            if (sCompanyBranchID != "default")
                oInv = tbl_sasInvoice.SelectAllByCompanyBranch_ID(sCompanyBranchID);
            else
                oInv = tbl_sasInvoice.SelectAll();

            //foreach (tbl_sasInvoice oInvoice in oInv.Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsDebitNote && !p.IsOpeningBalance && !p.IsReturnedCheque && p.InvoiceDate.Date >= dtFromDate.Date && p.InvoiceDate.Date <= dtToDate.Date && p.OtherTaxTotal == 0))
            foreach (tbl_sasInvoice oInvoice in oInv.Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsDebitNote && !p.IsOpeningBalance && !p.IsReturnedCheque && p.InvoiceDate.Date <= dtToDate.Date && p.OtherTaxTotal == 0))
            {
                decimal dNetValue = 0, dDebitValue = 0;
                if (!oInvoice.IsDebitNote)
                    dNetValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage);
                else
                    dDebitValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInvoice.GrandTotal, oInvoice.VatPercentage, oInvoice.NbtPercentage);

                //if (oInvoice.InvoiceDate.Date == dtNow.Date)
                //{
                //    dNetSales_ForTheDay += dNetValue;
                //    dDebitValue_ForTheDay += dDebitValue;
                //}

                dNetSales_ForTheMonth += dNetValue;
                dDebitValue_ForTheMonth += dDebitValue;

            }
        }
        #endregion

        #region Credit Note
        public static void assingValues_CreditNote_WithoutTaxes(ref decimal dCreditNote_Value_ForTheMonth, ref decimal dCreditNote_Value_ForTheDay, DateTime dtNow, string sBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            List<tbl_bpsCreditNote> oCRNs;
            if (sBranchID != "default")
                oCRNs = tbl_bpsCreditNote.SelectAll().Where(p => p.CompanyBranch_ID == sBranchID).ToList();
            else
                oCRNs = tbl_bpsCreditNote.SelectAll();

            foreach (tbl_bpsCreditNote oCRN in oCRNs.Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && p.CreditNoteDate.Date >= dtFirstDayOfThisMonth.Date && p.CreditNoteType_ID != clsAutocode.getCreditNoteTypeID(CreditNoteType.ReturnedChequeDeposit)))
            {
                int iRecordCount = 0;
                foreach (tbl_bpsCreditNote_Invoice oCRNInvoice in tbl_bpsCreditNote_Invoice.SelectAllByCreditNote_ID(oCRN.CreditNote_ID))
                {
                    tbl_sasInvoice_Sattled oInvStl = tbl_sasInvoice_Sattled.Select(oCRNInvoice.Invoice_ID, "default", "default", oCRN.CreditNote_ID, "default", "default", "default");
                    if (oInvStl != null)
                    {
                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRNInvoice.Invoice_ID);
                        if (oInvoice != null)
                        {
                            decimal dNetValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInvStl.SattledAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage);

                            if (oCRN.CreditNoteDate.Date == dtNow.Date)
                                dCreditNote_Value_ForTheDay += dNetValue;

                            dCreditNote_Value_ForTheMonth += dNetValue;
                            iRecordCount++;
                        }
                    }
                }
                if (iRecordCount == 0 && oCRN.Invoice_ID != "default")// If No Invoice record available
                {
                    decimal dNetValue = 0;
                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oCRN.Invoice_ID);
                    if (oInvoice != null)
                        dNetValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCRN.TotalAmount, oInvoice.VatPercentage, oInvoice.NbtPercentage);
                    else
                        dNetValue = clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCRN.TotalAmount, oCRN.VatPercentage, oCRN.NbtPercentage);

                    if (oCRN.CreditNoteDate.Date == dtNow.Date)
                        dCreditNote_Value_ForTheDay += dNetValue;

                    dCreditNote_Value_ForTheMonth += dNetValue;
                    iRecordCount++;
                }
            }
        }
        #endregion

        #region Collection
        public static void assingValues_Collection(ref decimal dReceipt_Cash_ForTheDay, ref decimal dReceipt_Cash_ForTheMonth, ref decimal dReceipt_Cheque_ForTheDay, ref decimal dReceipt_Cheque_ForTheMonth, DateTime dtNow, string sBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            List<tbl_bpsReceipt> oRec;
            if (sBranchID != "default")
                oRec = tbl_bpsReceipt.SelectAllByCompanyBranch_ID(sBranchID);
            else
                oRec = tbl_bpsReceipt.SelectAll();

            foreach (tbl_bpsReceipt oReceipt in oRec.Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate >= dtFirstDayOfThisMonth))
            {
                decimal dNetValue = oReceipt.CashAmount;
                if (oReceipt.ReceiptDate.Date == dtNow.Date)
                {
                    //Cash


                    //Cheque
                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                    {
                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            dReceipt_Cheque_ForTheDay += oCheque.Amount;
                            dReceipt_Cheque_ForTheMonth += oCheque.Amount;
                        }
                        else
                        {
                            dReceipt_Cash_ForTheDay += dNetValue;
                            dReceipt_Cash_ForTheMonth += dNetValue;
                        }
                    }
                }
                else
                {
                    //Cash
                    dReceipt_Cash_ForTheMonth += dNetValue;

                    //Cheque
                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                    {
                        dReceipt_Cheque_ForTheMonth += oCheque.Amount;
                    }
                }
            }
        }

        public static void assingValues_Collection_ForDateRange(ref decimal dReceipt_Cash_ForTheDay, ref decimal dReceipt_Cash_ForTheMonth, ref decimal dReceipt_Cheque_ForTheDay, ref decimal dReceipt_Cheque_ForTheMonth, DateTime dtFromDate, DateTime dtToDate, string sBranchID)
        {
            List<tbl_bpsReceipt> oReceipts = tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date >= dtFromDate && p.ReceiptDate.Date <= dtToDate).ToList();
            foreach (tbl_bpsReceipt oReceipt in oReceipts)
            {


                foreach (tbl_bpsChequeRegister oChequeRegister in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted))
                {
                    if (oChequeRegister.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                    {
                        dReceipt_Cheque_ForTheMonth += oChequeRegister.Amount;
                    }
                    else
                    { dReceipt_Cash_ForTheMonth += oReceipt.CashAmount; }
                }
            }

            #region Old
            ////DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            //List<tbl_bpsReceipt> oRec;
            //if (sBranchID != "default")
            //    oRec = tbl_bpsReceipt.SelectAllByCompanyBranch_ID(sBranchID);
            //else
            //    oRec = tbl_bpsReceipt.SelectAll();

            //foreach (tbl_bpsReceipt oReceipt in oRec.Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate >= dtFromDate && p.ReceiptDate <= dtToDate))
            //{
            //    decimal dNetValue = oReceipt.CashAmount;
            //    //if (oReceipt.ReceiptDate.Date == dtNow.Date)
            //    //{
            //    //    //Cash
            //    //    dReceipt_Cash_ForTheDay += dNetValue;
            //    //    dReceipt_Cash_ForTheMonth += dNetValue;

            //    //    //Cheque
            //    //    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
            //    //    {
            //    //        dReceipt_Cheque_ForTheDay += oCheque.ChequeAmount;
            //    //        dReceipt_Cheque_ForTheMonth += oCheque.ChequeAmount;
            //    //    }
            //    //}
            //    //else
            //    //{
            //        //Cash
            //        //dReceipt_Cash_ForTheMonth += dNetValue;
            //    dReceipt_Cash_ForTheMonth += oReceipt.CashAmount; 

            //        //Cheque
            //        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
            //        {
            //            dReceipt_Cheque_ForTheMonth += oCheque.ChequeAmount;
            //        }
            //    //}
            //} 
            #endregion
        }
        #endregion

        #region Cash Deposit
        public static void assingValues_CashDeposit(ref decimal dDeposit_Cash_ForTheDay, ref decimal dDeposit_Cash_ForTheMonth, DateTime dtNow)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);
            foreach (tbl_bpsCashDeposit oDeposit in tbl_bpsCashDeposit.SelectAll().Where(p => p.CashDeposit_ID != "default" && p.DateDeposit >= dtFirstDayOfThisMonth))
            {

                decimal dNetValue = oDeposit.TotalAmount;
                if (oDeposit.DateDeposit.Date == dtNow.Date)
                {
                    dDeposit_Cash_ForTheDay += dNetValue;
                    dDeposit_Cash_ForTheMonth += dNetValue;
                }
                else
                    dDeposit_Cash_ForTheMonth += dNetValue;
            }
        }

        public static void assingValues_CashDeposit(ref decimal dDeposit_Cash_ForTheDay, ref decimal dDeposit_Cash_ForTheMonth, DateTime dtNow, string sBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);
            foreach (tbl_bpsCashDeposit oDeposit in tbl_bpsCashDeposit.SelectAll().Where(p => p.CashDeposit_ID != "default" && p.DateDeposit >= dtFirstDayOfThisMonth))
            {
                foreach (tbl_bpsCashDeposit_Detail detail in tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(oDeposit.CashDeposit_ID))
                {
                    tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                    if (oReceipt.Receipt_ID != "default" || oReceipt != null)
                    {
                        if (sBranchID != "default")
                        {
                            if (oReceipt.CompanyBranch_ID != sBranchID)
                                continue;
                        }

                        decimal dNetValue = oReceipt.CashAmount;
                        if (oDeposit.DateDeposit.Date == dtNow.Date)
                            dDeposit_Cash_ForTheDay += dNetValue;

                        dDeposit_Cash_ForTheMonth += dNetValue;
                    }
                }

                //decimal dNetValue = oDeposit.TotalAmount;
                //if (oDeposit.DateDeposit.Date == dtNow.Date)
                //{
                //    dDeposit_Cash_ForTheDay += dNetValue;
                //    dDeposit_Cash_ForTheMonth += dNetValue;
                //}
                //else
                //    dDeposit_Cash_ForTheMonth += dNetValue;
            }
        }
        #endregion

        #region Cheque Deposit
        public static void assingValues_ChequeDeposit(ref decimal dDeposit_Cheque_ForTheDay, ref decimal dDeposit_Cheque_ForTheMonth, DateTime dtNow, string sBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            List<tbl_bpsChequeRegister> oChe;
            if (sBranchID != "default")
                oChe = tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sBranchID);
            else
                oChe = tbl_bpsChequeRegister.SelectAll();

            foreach (tbl_bpsChequeRegister oDeposit in oChe.Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && p.IsDepositted && p.DateDeposited >= dtFirstDayOfThisMonth))
            {
                if (oDeposit.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    decimal dNetValue = oDeposit.Amount;
                    if (oDeposit.DateDeposited.Date == dtNow.Date)
                    {
                        dDeposit_Cheque_ForTheDay += dNetValue;
                        dDeposit_Cheque_ForTheMonth += dNetValue;
                    }
                    else
                        dDeposit_Cheque_ForTheMonth += dNetValue;
                }
            }
        }
        #endregion

        #region Cheque Reconcile
        public static void assingValues_ChequeReconcile(ref decimal dReturned_Cheque_ForTheDay, ref decimal dReturned_Cheque_ForTheMonth, ref decimal dRealized_Cheque_ForTheDay, ref decimal dRealized_Cheque_ForTheMonth, DateTime dtNow, string sBranchID)
        {
            DateTime dtFirstDayOfThisMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            foreach (tbl_bpsChequeReconciliation oRecon in tbl_bpsChequeReconciliation.SelectAll().Where(p => !p.IsDeleted && p.Reconciliation_ID != "default" && p.DateReconciliation >= dtFirstDayOfThisMonth))
            {
                if (oRecon.DateReconciliation.Date == dtNow.Date)
                {
                    #region For The Day
                    foreach (tbl_bpsChequeReconciliation_Detail oCheques in tbl_bpsChequeReconciliation_Detail.SelectAllByReconciliation_ID(oRecon.Reconciliation_ID))
                    {
                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oCheques.ChequeRegister_ID);
                        if (oCheque != null)
                        {
                            if (sBranchID != "default")
                            {
                                if (oCheque.CompanyBranch_ID != sBranchID)
                                    continue;
                            }

                            decimal dNetValue = oCheque.Amount;
                            if (oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O))
                            {
                                dReturned_Cheque_ForTheDay += dNetValue;
                                dReturned_Cheque_ForTheMonth += dNetValue;

                            }
                            else if (oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))
                            {
                                dRealized_Cheque_ForTheDay += dNetValue;
                                dRealized_Cheque_ForTheMonth += dNetValue;
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region For The Month
                    foreach (tbl_bpsChequeReconciliation_Detail oCheques in tbl_bpsChequeReconciliation_Detail.SelectAllByReconciliation_ID(oRecon.Reconciliation_ID))
                    {
                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oCheques.ChequeRegister_ID);
                        if (oCheque != null)
                        {
                            if (sBranchID != "default")
                            {
                                if (oCheque.CompanyBranch_ID != sBranchID)
                                    continue;
                            }

                            decimal dNetValue = oCheque.Amount;
                            if (oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_R) || oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_C) || oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Returned_NR_O))
                                dReturned_Cheque_ForTheMonth += dNetValue;
                            else if (oCheques.ChequeStatus_ID == clsAutocode.getChequeStatusID(ChequeStatus.Realized))
                                dRealized_Cheque_ForTheMonth += dNetValue;
                        }
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Outstanding
        public static void assingValues_Outstanding(ref decimal dChequeInHand, ref decimal dTotalOutstanding, ref decimal dTotalOutstandingOver90, ref decimal dDepositedButUnrealized, ref decimal dHoldingCheques, string sBranchID)
        {
            List<tbl_bpsChequeRegister> oCheque;
            if (sBranchID != "default")
                oCheque = tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sBranchID);
            else
                oCheque = tbl_bpsChequeRegister.SelectAll();


            //Cheque in hand
            foreach (tbl_bpsChequeRegister detail in oCheque.Where(p => !p.IsDeleted && !p.IsReconcilied && !p.IsReIssued && p.AccountReceipt_ID == "default"))
            {
                if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    if (!detail.IsDepositted)
                    {
                        if (detail.DateCheque <= clsSecurity.getServerDateTime())
                            dHoldingCheques += detail.Amount; //For Holding Cheques
                        else
                            dChequeInHand += detail.Amount; //For Cheque In Hand
                    }

                    if (detail.IsDepositted && !detail.IsReconcilied)
                    {
                        dDepositedButUnrealized += detail.Amount;
                    }
                }
            }

            //Outstanding 
            decimal dTotalDues = 0, dTotalPayments = 0, dTotalDuesOver90Days = 0;
            foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsSeattled))
            {
                dTotalDues += detail.GrandTotal - detail.SeattleAmount;
                decimal dDays = clsCommon.getDaysUptoDate(detail.InvoiceDate);
                if (dDays > 90)
                    dTotalDuesOver90Days += detail.GrandTotal - detail.SeattleAmount;
            }

            //Cash            
            foreach (tbl_bpsReceipt cash in tbl_bpsReceipt.SelectAll().Where(p => !p.IsSeattled && p.Receipt_ID != "default" && !p.IsDeleted && p.CashAmount > p.SeattleAmount))
            {
                dTotalPayments += (cash.CashAmount - cash.SeattleAmount);
            }
            //Cheques            
            foreach (tbl_bpsChequeRegister cheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsSetteled && !p.IsDeleted && p.Amount > p.SetteledAmount && p.AccountReceipt_ID == "default"))
            {
                dTotalPayments += (cheque.Amount - cheque.SetteledAmount);
            }
            //Credit Notes            
            foreach (tbl_bpsCreditNote credit in tbl_bpsCreditNote.SelectAll().Where(p => !p.IsSeattled && p.CreditNote_ID != "default" && !p.IsDeleted && p.TotalAmount > p.SeattleAmount))
            {
                dTotalPayments += (credit.TotalAmount - credit.SeattleAmount);
            }

            dTotalOutstanding = dTotalDues - dTotalPayments;
            dTotalOutstandingOver90 = dTotalDuesOver90Days;
        }

        public static void assingValues_Outstanding_ForDateRange(ref decimal dChequeInHand, ref decimal dTotalOutstanding, ref decimal dTotalOutstandingOver90, ref decimal dDepositedButUnrealized, ref decimal dHoldingCheques, DateTime dtFromDate, DateTime dtToDate, string sBranchID)
        {
            List<tbl_genCustomerMaster> ocustomers = tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default").ToList();
            foreach (tbl_genCustomerMaster ocustomer in ocustomers)
            {
                var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(ocustomer.Customer_ID, "", Convert.ToDateTime("01/01/2001"), dtToDate, true);
                foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                {
                    if (oDetail.IsChecueInHand)
                        dChequeInHand += oDetail.Outstanding;
                    else
                        dTotalOutstanding += oDetail.Outstanding;


                    //gbl_dts_bssOutstandingLedger.bssCustomerOutstanding.AddbssCustomerOutstandingRow(oDetail.Customer_ID, ocustomer.CustomerName, oDetail.TransactionType, oDetail.Transaction_ID,
                    //    oDetail.TransactionDate, oDetail.TransactionAmount, oDetail.Outstanding, oDetail.Remarks, oDetail.IsCredit, oDetail.IsChecueInHand, false, sSalesRep_ID, oDetail.Age, oDetail.DeliveryOrder_ID, oDetail.PurchaseOrder_ID, "", oDetail.CurrencyCode, oDetail.CurrencyRate, oDetail.IsAdvance, oDetail.OrderRefNo);

                }
            }

            List<tbl_bpsChequeRegister> oCheque;
            if (sBranchID != "default")
                oCheque = tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sBranchID);
            else
                oCheque = tbl_bpsChequeRegister.SelectAll();

            //Cheque in hand
            foreach (tbl_bpsChequeRegister detail in oCheque.Where(p => !p.IsDeleted && !p.IsReconcilied && !p.IsReIssued && p.AccountReceipt_ID == "default" && p.DateDeposited.Date >= dtFromDate.Date && p.DateDeposited.Date <= dtToDate.Date))
            {
                if (detail.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                {
                    if (detail.IsDepositted && !detail.IsReconcilied)
                    {
                        dDepositedButUnrealized += detail.Amount;
                    }
                }
            }

            #region Old
            //List<tbl_bpsChequeRegister> oCheque;
            //if (sBranchID != "default")
            //    oCheque = tbl_bpsChequeRegister.SelectAllByCompanyBranch_ID(sBranchID);
            //else
            //    oCheque = tbl_bpsChequeRegister.SelectAll();


            ////Cheque in hand
            //foreach (tbl_bpsChequeRegister detail in oCheque.Where(p => !p.IsDeleted && !p.IsReconcilied && !p.IsReIssued && p.AccountReceipt_ID == "default" && p.DateDeposited.Date >= dtFromDate.Date && p.DateDeposited.Date <= dtToDate.Date))
            //{

            //    //if (!detail.IsDepositted)
            //    //{
            //    //    if (detail.DateCheque <= clsSecurity.getServerDateTime())
            //    //        dHoldingCheques += detail.ChequeAmount; //For Holding Cheques
            //    //    else
            //    //        dChequeInHand += detail.ChequeAmount; //For Cheque In Hand
            //    //}

            //    if (!detail.IsDepositted)
            //        dChequeInHand += detail.ChequeAmount; //For Cheque In Hand               

            //    if (detail.IsDepositted && !detail.IsReconcilied)
            //    {
            //        dDepositedButUnrealized += detail.ChequeAmount;
            //    }
            //}

            ////Outstanding 
            //decimal dTotalDues = 0, dTotalPayments = 0, dTotalDuesOver90Days = 0;
            //foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsSeattled && p.InvoiceDate.Date <= dtToDate.Date))
            //{
            //    dTotalDues += detail.GrandTotal - detail.SeattleAmount;
            //    decimal dDays = clsCommon.getDaysUptoDate(detail.InvoiceDate);
            //    if (dDays > 90)
            //        dTotalDuesOver90Days += detail.GrandTotal - detail.SeattleAmount;
            //}

            ////Cash            
            //foreach (tbl_bpsReceipt cash in tbl_bpsReceipt.SelectAll().Where(p => !p.IsSeattled && p.Receipt_ID != "default" && !p.IsDeleted && p.CashAmount > p.SeattleAmount && p.ReceiptDate.Date <= dtToDate.Date))
            //{
            //    dTotalPayments += (cash.CashAmount - cash.SeattleAmount);
            //}
            ////Cheques            
            //foreach (tbl_bpsChequeRegister cheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsSetteled && !p.IsDeleted && p.ChequeAmount > p.SetteledAmount && p.AccountReceipt_ID == "default" && p.DateDeposited.Date <= dtToDate.Date))
            //{
            //    dTotalPayments += (cheque.ChequeAmount - cheque.SetteledAmount);
            //}
            ////Credit Notes            
            //foreach (tbl_bpsCreditNote credit in tbl_bpsCreditNote.SelectAll().Where(p => !p.IsSeattled && p.CreditNote_ID != "default" && !p.IsDeleted && p.TotalAmount > p.SeattleAmount && p.CreditNoteDate.Date <= dtToDate.Date))
            //{
            //    dTotalPayments += (credit.TotalAmount - credit.SeattleAmount);
            //}

            //dTotalOutstanding = dTotalDues - dTotalPayments;
            //dTotalOutstandingOver90 = dTotalDuesOver90Days; 
            #endregion
        }
        #endregion
    }
}
