using DataTire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.ACC.Tools_And_Views
{
    public partial class frm_accCheckPosting : MettroForm
    {
        public frm_accCheckPosting()
        {
            InitializeComponent();
        }

        #region Invoice
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            txtDetail.Clear();
            dgvDetail.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            StringBuilder sbInvList = new StringBuilder();
            foreach (tbl_sasInvoice oInv in tbl_sasInvoice.SelectAll())
            {
                if (sbInvList.Length > 0)
                    sbInvList.Append(",");

                sbInvList.AppendLine("'" + oInv.Invoice_ID + "'");

                List<tbl_accGLPosting_Detail> oPost = tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oInv.Invoice_ID);
                if (oInv.IsOpeningBalance)
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oInv.Invoice_ID + " posted OPBL");
                }
                else if (oInv.IsDeleted)
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oInv.Invoice_ID + " posted Deleted Note");
                }
                else if (oInv.IsReturnedCheque)
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oInv.Invoice_ID + " posted Returned chq");
                }
                else if (oInv.Invoice_ID == "default")
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oInv.Invoice_ID + " posted Default record");
                }
                //    if (!oInv.IsOpeningBalance && !oInv.IsDeleted && !oInv.IsReturnedCheque)
                else
                {
                    if (oPost.Count == 0)
                        sb.AppendLine(oInv.Invoice_ID + " Not Posted");
                    else
                    {
                        decimal dCr = 0, dDr = 0;
                        foreach (tbl_accGLPosting_Detail oPosti in oPost)
                        {
                            if (oPosti.IsCredit)
                                dCr += oPosti.Amount;
                            else
                                dDr += oPosti.Amount;
                        }

                        if (dDr != oInv.GrandTotal)
                        {
                            sb.AppendLine(oInv.Invoice_ID + " Grand total mismatch");
                        }
                        if ((oInv.NbtTotal + oInv.VatTotal + oInv.SubTotal - oInv.DiscountTotal - oInv.DiscountTotal1 - oInv.DiscountTotal2 - oInv.DiscountTotal3) != dCr)
                        {
                            sb.AppendLine(oInv.Invoice_ID + " CR mismatch");
                        }
                    }

                }
            }
            txtDetail.Text = sb.ToString();
            string Q1 = "select* from[dbo].[tbl_accGLPosting_Detail] where[slot_ID] in(1,2,31,35,36) and[transaction_ID] not in (" + sbInvList.ToString() + ")";
            DataTable dt = DBHandling.ExecQuery(Q1).Tables[0];
            dgvDetail.DataSource = dt.DefaultView;

            //   MessageBox.Show(sbInvList.ToString());
            MessageBox.Show("done");
        }
        #endregion

        #region Credit Note
        private void btnCRN_Click(object sender, EventArgs e)
        {
            txtDetail.Clear();
            dgvDetail.Rows.Clear();

            StringBuilder sb = new StringBuilder();
            StringBuilder sbCRNList = new StringBuilder();
            foreach (tbl_bpsCreditNote oCRN in tbl_bpsCreditNote.SelectAll().Where(p=> p.PosReturnTransaction_Index == -1 && p.AdvanceReceived_Index == -1))
            {
                if (sbCRNList.Length > 0)
                    sbCRNList.Append(",");

                sbCRNList.AppendLine("'" + oCRN.CreditNote_ID + "'");

                List<tbl_accGLPosting_Detail> oPost = tbl_accGLPosting_Detail.SelectAllByTransaction_ID(oCRN.CreditNote_ID);
               
                if (oCRN.CreditNoteType_ID == "default") // OPBL
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " posted OPBL");
                }
                else if (oCRN.IsDeleted)
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " posted Deleted Note");
                }
                else if (oCRN.ChequeRegister_ID != "default" && oCRN.CreditNoteType_ID == "TP/003") // Redeposite Cheque
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " posted Redeposite chq");
                }
                else if (oCRN.CreditNoteType_ID == "TP/002") // Sales Return
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " posted Sales Return CRN");
                }
                else if (oCRN.CreditNote_ID == "default")
                {
                    if (oPost.Count != 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " posted Default record");
                }
                
                else
                {
                    if (oPost.Count == 0)
                        sb.AppendLine(oCRN.CreditNote_ID + " Not Posted");
                    else
                    {
                        decimal dCr = 0, dDr = 0;
                        foreach (tbl_accGLPosting_Detail oPosti in oPost)
                        {
                            if (oPosti.IsCredit)
                                dCr += oPosti.Amount;
                            else
                                dDr += oPosti.Amount;
                        }

                        if (dDr != oCRN.TotalAmount)
                        {
                            sb.AppendLine(oCRN.CreditNote_ID + " Grand total mismatch");
                        }
                        if ((oCRN.NbtTotal + oCRN.VatTotal + oCRN.SubTotal - oCRN.DiscountTotal) != dCr)
                        {
                            sb.AppendLine(oCRN.CreditNote_ID + " CR mismatch");
                        }
                    }

                }
            }
            txtDetail.Text = sb.ToString();
            string Q1 = "select* from[dbo].[tbl_accGLPosting_Detail] where[slot_ID] = 12 and[transaction_ID] not in (" + sbCRNList.ToString() + ")";
            DataTable dt = DBHandling.ExecQuery(Q1).Tables[0];
            dgvDetail.DataSource = dt.DefaultView;

            //   MessageBox.Show(sbInvList.ToString());
            MessageBox.Show("done");
        } 
        #endregion
    }
}
