using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_bpsCashDepositSummary : Form
    {
        public frm_bpsCashDepositSummary(string sDepositeID)
        {
            InitializeComponent();
            FillDepositeDetails(sDepositeID);
        }

        #region Fill Details
        private void FillDepositeDetails(string sDepositeID)
        {
            try
            {
                lblDepositeDate.Text = "";
                lblDepositeAmount.Text = "";
                lblNpofReceipts.Text = "";
                lblRemarks.Text = "";
                int iRow;
                dgvDetail.Rows.Clear();

                tbl_bpsCashDeposit oDeposit = tbl_bpsCashDeposit.Select(sDepositeID);
                if (oDeposit != null)
                {
                    lblDepositeID.Tag = sDepositeID;
                    lblDepositeID.Text = sDepositeID;
                    lblDepositeDate.Text = clsFormatter.FormatDate_Short(oDeposit.DateDeposit);
                    lblDepositeAmount.Text = clsFormatter.FormatDecimalPlaces_Price(oDeposit.DepositedAmount);
                    //  lblNpofReceipts.Text = oDeposit.TotalReceipt.ToString();
                    lblRemarks.Text = oDeposit.Remark;

                    #region Grid Fill
                    foreach (tbl_bpsCashDeposit_Detail detail in tbl_bpsCashDeposit_Detail.SelectAllByCashDeposit_ID(sDepositeID))
                    {
                        tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(detail.Receipt_ID);
                        tbl_accAccountReceipt oAccReceipt = tbl_accAccountReceipt.Select(detail.Receipt_ID);
                        if (oReceipt != null)
                        {
                            decimal dAmount = 0;
                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID).Where(p => p.PaymentMethod_ID == 0))
                            {
                                dAmount += oCheque.Amount;
                            }

                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            dgvDetail["ReceiptID", iRow].Value = detail.Receipt_ID;
                            dgvDetail["ReceiptDate", iRow].Value = clsFormatter.FormatDate_Short(oReceipt.ReceiptDate);
                            dgvDetail["CustomerName", iRow].Value = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                            dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(dAmount);
                            dgvDetail["DepositedAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.DepositedAmount);
                            dgvDetail["InvoiceList", iRow].Value = oReceipt.InvoiceList;
                            dgvDetail["CSdate", iRow].Value = oReceipt.ReceiptDate;
                        }
                        
                        else if (oAccReceipt != null)
                        {
                            decimal dAmount = 0;
                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByAccountReceipt_ID(detail.Receipt_ID).Where(p => p.PaymentMethod_ID == 0))
                            {
                                dAmount += oCheque.Amount;
                            }

                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;

                            dgvDetail["ReceiptID", iRow].Value = detail.Receipt_ID;
                            dgvDetail["ReceiptDate", iRow].Value = clsFormatter.FormatDate_Short(oAccReceipt.AccountReceiptDate);
                            dgvDetail["CustomerName", iRow].Value = clsGenaralName.getName_Customer(oAccReceipt.Customer_ID);
                            dgvDetail["Amount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(dAmount);
                            dgvDetail["DepositedAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price(detail.DepositedAmount);
                            dgvDetail["InvoiceList", iRow].Value = "";
                            dgvDetail["CSdate", iRow].Value = oAccReceipt.AccountReceiptDate;
                        }
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetail_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
             
                if (sColName == "ReceiptID")
                {
                   string sTransactionID = clsValidate.ValidateGridValue(dgvDetail, "ReceiptID", e.RowIndex, "");
                    if (sTransactionID != "")
                    {
                        tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sTransactionID);
                        if (detail != null)
                        {
                            if (detail.IsSalesReceipt)
                            {
                                UC_bpsReceiptSales cheque = new UC_bpsReceiptSales(FormName.UCReceipt);
                                cheque.glbReceiptID = detail.Receipt_ID;
                                cheque.Show();
                              //  clsHelpMethods_Local.DisplayForm(cheque, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                            }
                            else
                            {
                                UC_bpsReceiptSales cheque = new UC_bpsReceiptSales(FormName.InterimReceipt);
                                cheque.glbReceiptID = detail.Receipt_ID;
                                cheque.Show();
                                //   clsHelpMethods_Local.DisplayForm(cheque, clsFormatter.colorBills, (this.Parent as Form).MdiParent);
                            }
                        }
                    }
                }
            }
        }
    }
}