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
using System.IO;
using SEACC.DATA.Data.SAS;

namespace Digiteq
{
    public partial class frm_ToolUpdateOldestInvoiceDate : MettroForm
    {
        public int iFormID;

        public frm_ToolUpdateOldestInvoiceDate()
        {
            InitializeComponent();
        }

        #region Form Load
        private void frmQuickLogin_Load(object sender, EventArgs e)
        {
        }
        #endregion

        #region Btn Execute
        private void btnLogon_Click(object sender, EventArgs e)
        {
            try
            {
                decimal dSettledAmount = 0;
                foreach (tbl_sasInvoice invoice in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted))
                {
                    dSettledAmount = 0;
                    foreach (tbl_sasInvoice_Sattled invSettled in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(invoice.Invoice_ID))
                    {
                        dSettledAmount += invSettled.SattledAmount;
                    }
                    if (dSettledAmount != invoice.SeattleAmount)
                    {
                        invoice.SeattleAmount = dSettledAmount;
                        invoice.Update();
                    }
                }
                MessageBox.Show("updated succesfully");
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnExecute2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                tbl_genCompanyInfo oInfo = tbl_genCompanyInfo.Select(clsSecurity.getRegDBComapanyName());
                if (oInfo != null && oInfo.CompanyID != "default")
                {
                    string sCompanyName = clsSecurity.decryptPassword(oInfo.CompanyName);
                    string sAddress = clsSecurity.decryptPassword(oInfo.Address);

                    oInfo.CompanyName = clsCript.Encrypt(sCompanyName);
                    oInfo.Address = clsCript.Encrypt(sAddress);
                    oInfo.Update();
                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }


        private void btnExecute4_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                //Insert/Update Payment Methods
                #region Cash
                tbl_zPaymentMethod oPayment = tbl_zPaymentMethod.Select("PMD/001");
                if (oPayment != null)
                {
                    oPayment.PaymentMethodName = "Cash";
                    oPayment.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/001", "Cash");
                    oPaymentNew.Insert();
                }
                #endregion

                #region Cheque
                tbl_zPaymentMethod oPayment2 = tbl_zPaymentMethod.Select("PMD/002");
                if (oPayment2 != null)
                {
                    oPayment2.PaymentMethodName = "Cheque";
                    oPayment2.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/002", "Cheque");
                    oPaymentNew.Insert();
                }
                #endregion

                #region Visa
                tbl_zPaymentMethod oPayment3 = tbl_zPaymentMethod.Select("PMD/003");
                if (oPayment3 != null)
                {
                    oPayment3.PaymentMethodName = "Visa";
                    oPayment3.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/003", "Visa");
                    oPaymentNew.Insert();
                }
                #endregion

                #region Master
                tbl_zPaymentMethod oPayment4 = tbl_zPaymentMethod.Select("PMD/004");
                if (oPayment4 != null)
                {
                    oPayment4.PaymentMethodName = "Master";
                    oPayment4.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/004", "Master");
                    oPaymentNew.Insert();
                }
                #endregion

                #region LoyalityCard
                tbl_zPaymentMethod oPayment5 = tbl_zPaymentMethod.Select("PMD/005");
                if (oPayment5 != null)
                {
                    oPayment5.PaymentMethodName = "Loyality Card";
                    oPayment5.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/005", "Loyality Card");
                    oPaymentNew.Insert();
                }
                #endregion

                #region Voucher
                tbl_zPaymentMethod oPayment6 = tbl_zPaymentMethod.Select("PMD/006");
                if (oPayment6 != null)
                {
                    oPayment6.PaymentMethodName = "Voucher";
                    oPayment6.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/006", "Voucher");
                    oPaymentNew.Insert();
                }
                #endregion

                #region BankTransfer
                tbl_zPaymentMethod oPayment7 = tbl_zPaymentMethod.Select("PMD/007");
                if (oPayment7 != null)
                {
                    oPayment7.PaymentMethodName = "Bank Transfer";
                    oPayment7.Update();
                }
                else
                {
                    tbl_zPaymentMethod oPaymentNew = new tbl_zPaymentMethod("PMD/007", "Bank Transfer");
                    oPaymentNew.Insert();
                }
                #endregion

                //update invoice settled table
                foreach (tbl_sasInvoice_Sattled detail in tbl_sasInvoice_Sattled.SelectAll().Where(p => p.Settled_ID != "default"))
                {
                    //if (detail.ChequeRegister_ID != "default")
                    //    detail.PaymentMethod_ID = clsConfig.sPaymentMethod_Cheque;
                    //else if (detail.ChequeRegister_ID == "default" && detail.Receipt_ID != "default")
                    //    detail.PaymentMethod_ID = clsConfig.sPaymentMethod_Cash;

                    //detail.Update2();
                }
                MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion








        private void button5_Click(object sender, EventArgs e)
        {
            foreach (tbl_accDebitNote oDBN in tbl_accDebitNote.SelectAll())
            {
                //foreach (tbl_accGLPosting_Detail_Tmp oPosting in tbl_accGLPosting_Detail_Tmp.SelectAll().Where(p => p.Transaction_ID == oDBN.DebitNote_ID))
                //{
                //    oPosting.TransactionDate = oDBN.DebitNote_Date;
                //    oPosting.Update();
                //}
            }
        }



        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To create Pv tempary postings?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                int sSlotID = clsAutocode.getAccSlotID(AccSlot.PaymetVoucher);
                #region  Posting
                foreach (tbl_accPaymentVoucher oTXN in tbl_accPaymentVoucher.SelectAll().Where(p => p.PaymentVoucher_ID != "default" && p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction)))
                {
                    DateTime dtmPostingDate1 = oTXN.PaymentVoucherDate;
                    if (clsConfig.bPV_UseChequeDate_As_PVPostingDate)
                    {
                        foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(oTXN.PaymentVoucher_ID))
                        {
                            dtmPostingDate1 = oCheque.DateCheque;
                        }
                    }
                    //  string sGLPostingID = clsMethods_Fin.GLPostingHeaderTempInsert(dtmPostingDate1, oTXN.Narration);
                    // if (sGLPostingID != "")
                    {
                        foreach (tbl_accPaymentVoucher_SubTotal oTxnDetail in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(oTXN.PaymentVoucher_ID))
                        {
                            //   clsMethods_Fin.GLPostingDetailTemp(oTxnDetail.Line_No, sGLPostingID, sSlotID, oTXN.AccountPayableNote_ID, oTxnDetail.Gl_ID, oTxnDetail.CostCenter1_ID, oTxnDetail.CostCenter2_ID, "default", "default", oTxnDetail.Employee_ID, "default", "-", oTxnDetail.PaymentVoucher_ID, oTxnDetail.PaymentVoucher_ID, dtmPostingDate1, "", oTxnDetail.Amount, oTxnDetail.IsCredit, "", "");
                        }

                        //   oTXN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //   oTXN.GlPosting_ID = sGLPostingID;
                        //  oTXN.Update();
                    }
                }
                #endregion
            }
        }

        private void btn_CheckDepositCorect_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Do You Want To Recreate Cheque deposit Postings ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //if (result == DialogResult.Yes)
            //{
            //    try
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        foreach (tbl_bpsChequeDeposit_Detail oDeposit_Detail in tbl_bpsChequeDeposit_Detail.SelectAll().Where(p => p.PostingStatus_ID == clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted) && !p.IsRedeposit))
            //        {
            //            tbl_bpsChequeDeposit oDeposit = tbl_bpsChequeDeposit.Select(oDeposit_Detail.ChequeDeposit_ID);
            //            if (oDeposit != null)
            //            {
            //                foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oDeposit_Detail.ChequeRegister_ID).Where(p => p.Slot_ID == 13))
            //                {
            //                    oPosting.Delete();
            //                }

            //                tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oDeposit_Detail.ChequeRegister_ID);
            //                if (oCheque != null)
            //                {
            //                    oCheque.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
            //                    oCheque.Update();
            //                }
            //                clsMethods_Fin.PostTransaction_chequeDeposit(oDeposit_Detail.ChequeDeposit_ID, oDeposit_Detail.ChequeRegister_ID, oDeposit.DateDeposit, oCheque.Amount, oCheque.DepositedAccountNumber);
            //            }
            //        }
            //        MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        SEACCException.Show(ex);
            //    }
            //    finally
            //    {
            //        Cursor = Cursors.Default;
            //    }
            //}
        }

        private void btn_CashDep_postingCorrection_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To Recreate Cash deposit Postings ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    foreach (tbl_bpsCashDeposit_Detail oDeposit_Detail in tbl_bpsCashDeposit_Detail.SelectAll().Where(p => p.GlPosting_ID != "default"))
                    {
                        tbl_bpsCashDeposit oDeposit = tbl_bpsCashDeposit.Select(oDeposit_Detail.CashDeposit_ID);
                        if (oDeposit != null)
                        {
                            foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oDeposit_Detail.CashDeposit_ID).Where(p => p.Slot_ID == 25))
                            {
                                oPosting.Delete();
                            }
                            foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oDeposit_Detail.Receipt_ID).Where(p => p.Slot_ID == 25))
                            {
                                oPosting.Delete();
                            }
                            decimal dAmount = 0;

                            tbl_bpsReceipt Rdetail = tbl_bpsReceipt.Select(oDeposit_Detail.Receipt_ID);
                            if (Rdetail != null && Rdetail.Receipt_ID != "default")
                            {
                                dAmount = Rdetail.CashAmount;
                                Rdetail.PostingStatus_ID2 = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                                Rdetail.Update();
                            }
                            tbl_accAccountReceipt ARdetail = tbl_accAccountReceipt.Select(oDeposit_Detail.Receipt_ID);
                            if (ARdetail != null && ARdetail.AccountReceipt_ID != "default")
                            {
                                dAmount = ARdetail.CashAmount;

                            }
                            clsMethods_GL.PostTransaction_cashDeposit(oDeposit_Detail.Receipt_ID, oDeposit_Detail.CashDeposit_ID, oDeposit.DateDeposit, dAmount, oDeposit.AccountNumber);
                        }
                    }
                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want update cheque # in payment voucher postings ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    foreach (tbl_accGLPosting_Detail oPosting in tbl_accGLPosting_Detail.SelectAll().Where(p => p.Slot_ID == 7 && p.Cheq_No == ""))
                    {
                        foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(oPosting.Transaction_ID))
                        {
                            oPosting.Cheq_No = oCheque.ChequeNumber;
                            oPosting.Update();
                        }
                    }

                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btn_POSTING_Rem_CUSREFUND_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Remove postings for Customer Refundable Note ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    Cursor = Cursors.WaitCursor;

                    foreach (tbl_bpsDebitNote oDBN in tbl_bpsDebitNote.SelectAll().Where(p => p.IsCustomerRefundableNote && p.DebitNoteDate.Date > (new DateTime(2017, 01, 01)) && p.GlPosting_ID != "default" && !p.IsDeleted))
                    {
                        tbl_accGLPosting_Detail.DeleteAllByGlPosting_ID(oDBN.GlPosting_ID);

                        oDBN.GlPosting_ID = "default";
                        oDBN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction);
                        oDBN.Update();
                    }

                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btn_GLPostingTblUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want to Update the table  [tbl_accGLPosting] ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    Cursor = Cursors.WaitCursor;
                    foreach (tbl_accGLPosting oPosting in tbl_accGLPosting.SelectAll().Where(p => p.GlPosting_ID != "default"))
                    {
                        foreach (tbl_accGLPosting_Detail oPostingDetail in tbl_accGLPosting_Detail.SelectAllByGlPosting_ID(oPosting.GlPosting_ID))
                        {
                            string sCustomerID = "", sSupplierID = "";

                            #region Receipt
                            if (oPostingDetail.Slot_ID == 3 || oPostingDetail.Slot_ID == 4 || oPostingDetail.Slot_ID == 5 || oPostingDetail.Slot_ID == 6)
                            {
                                tbl_bpsReceipt oTxn = tbl_bpsReceipt.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region payment voucher
                            else if (oPostingDetail.Slot_ID == 7)
                            {
                                tbl_accPaymentVoucher oTxn = tbl_accPaymentVoucher.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sSupplierID = oTxn.Supplier_ID;
                                }
                            }
                            #endregion

                            #region Account Payable Note
                            else if (oPostingDetail.Slot_ID == 9)
                            {
                                tbl_accAccountPayableNote oTxn = tbl_accAccountPayableNote.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sSupplierID = oTxn.Supplier_ID;
                                }
                            }
                            #endregion

                            #region Debit Note
                            if (oPostingDetail.Slot_ID == 11)
                            {
                                tbl_bpsDebitNote oTxn = tbl_bpsDebitNote.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Credit Note
                            if (oPostingDetail.Slot_ID == 12)
                            {
                                tbl_bpsCreditNote oTxn = tbl_bpsCreditNote.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Cheque Deposit
                            if (oPostingDetail.Slot_ID == 13 || oPostingDetail.Slot_ID == 34)
                            {
                                tbl_bpsChequeRegister oTxn = tbl_bpsChequeRegister.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Sales Return
                            if (oPostingDetail.Slot_ID == 14)
                            {
                                tbl_sasSalesReturnedNote oTxn = tbl_sasSalesReturnedNote.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Cash Deposit
                            if (oPostingDetail.Slot_ID == 25)
                            {
                                tbl_bpsReceipt oTxn = tbl_bpsReceipt.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Cheque Returned
                            if (oPostingDetail.Slot_ID == 28)
                            {
                                tbl_bpsChequeRegister oTxn = tbl_bpsChequeRegister.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            #region Supplier Debit Note
                            else if (oPostingDetail.Slot_ID == 29)
                            {
                                tbl_accDebitNote oTxn = tbl_accDebitNote.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sSupplierID = oTxn.Supplier_ID;
                                }
                            }
                            #endregion

                            #region Cheque Deposit
                            if (oPostingDetail.Slot_ID == 35)
                            {
                                tbl_sasInvoice oTxn = tbl_sasInvoice.Select(oPostingDetail.Transaction_ID);
                                if (oTxn != null)
                                {
                                    sCustomerID = oTxn.Customer_ID;
                                }
                            }
                            #endregion

                            oPosting.Slot_ID = oPostingDetail.Slot_ID;
                            oPosting.Transaction_ID = oPostingDetail.Transaction_ID;
                            oPosting.TransactionDate = oPostingDetail.TransactionDate;
                            oPosting.Customer_ID = sCustomerID;
                            oPosting.Supplier_ID = sSupplierID;
                            oPosting.Update();
                        }
                    }

                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btn_CRNPosting_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To Recreate CRN Postings ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    DateTime fromdate = new DateTime(2021, 03, 01);
                    DateTime Todate = new DateTime(2021, 03, 01);

                    foreach (tbl_bpsCreditNote OCRN in tbl_bpsCreditNote.SelectAll().Where(p => !p.IsDeleted && p.CreditNoteType_ID != "TP/003" && p.CreditNote_ID != "default" && p.CreditNoteDate.Date>= fromdate && p.CreditNoteDate.Date<= Todate))
                    {

                        clsMethods_GL.GLPosting_Delete(OCRN.GlPosting_ID);

                        //    if (OCRN.CreditNoteType_ID == "TP/002")
                        //       clsMethods_Fin.PostTransaction_CustomerCRN_BySRN(OCRN.CreditNote_ID);
                        //  else
                       // clsMethods_GL.PostTransaction_CustomerCRN(OCRN.CreditNote_ID);

                        OCRN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        OCRN.Update();

                    }
                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnSalesReceipt_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do You Want To update invoice posting ?", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    var oData = new SasDeliveryOrder_data();
                    var inv = oData.Get_DeliveryOrder_ALL_In_ONE();

                    foreach (var x in inv)
                    {
                        clsMethods_GL.PostTransaction_Invoice(x.deliveryOrder_ID);
                    }

                    MessageBox.Show("Successfully Executed.........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }
    }
}