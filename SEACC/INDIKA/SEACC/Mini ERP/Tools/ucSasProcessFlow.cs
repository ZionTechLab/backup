using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic; 
using SEACC.WinFormControls.Forms;
using System.ComponentModel.Design;

namespace Digiteq
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucSasProcessFlow : UserControl
    {
        DataTable dt;
        public ucSasProcessFlow()
        {
            InitializeComponent();
            ClearFlow();
        }

        #region Clear Flows
        public void ClearFlow()
        {
            lnkFlowInquiry.Enabled = false;
            lnkFlowQuotation.Enabled = false;
            lnkFlowCustomerOrder.Enabled = false;
            lnkFlowDeliveryOrder.Enabled = false;
            lnkFlowInvoice.Enabled = false;
            lnkFlowReceipt.Enabled = false;
            lnkFlowProfomaInvoice.Enabled = false;
            lnkFlowSalesReturned.Enabled = false;

            lnkFlowInquiry.LinkColor = Color.Gray;
            lnkFlowQuotation.LinkColor = Color.Gray;
            lnkFlowCustomerOrder.LinkColor = Color.Gray;
            lnkFlowDeliveryOrder.LinkColor = Color.Gray;
            lnkFlowInvoice.LinkColor = Color.Gray;
            lnkFlowReceipt.LinkColor = Color.Gray;
            lnkFlowProfomaInvoice.LinkColor = Color.Gray;
            lnkFlowSalesReturned.LinkColor = Color.Gray;
        } 
        #endregion

        #region Set Process Flows
        public void SetProcessFlowByCustomerOrder(string CustomerOrder_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByCustomerOrder] '" + CustomerOrder_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);//blue
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(27, 84, 121);//dark blue
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowByDeliveryOrder(string DeliveryOrder_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByDeliveryOrder] '" + DeliveryOrder_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowByInvoice(string Invoice_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByInvoice] '" + Invoice_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowBySalesReceipt(string SalesReceipt_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByReceipt] '" + SalesReceipt_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowBySalesReturnNote(string SalesReturn_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowBySalesReturnNote] '" + SalesReturn_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(27, 84, 121);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowByProformaInvoice(string ProformaInvoice_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByProformaInvoice] '" + ProformaInvoice_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowByInquiry(string Inquiry_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByInquiry] '" + Inquiry_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SetProcessFlowByQuotation(string Quotation_ID)
        {
            try
            {
                ClearFlow();

                string sQuery = "exec [sp_SetProcessFlowByQuotation] '" + Quotation_ID + "'";
                dt = DBHandling.ExecQuery(sQuery).Tables[0];

                int iInquiryCount = dt.AsEnumerable().Where(x => x["inquiry_ID"].ToString() != "default" && x["inquiry_ID"] != DBNull.Value).ToList().Count;
                if (iInquiryCount > 0)
                {
                    lnkFlowInquiry.Enabled = true;
                    lnkFlowInquiry.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iQuotationCount = dt.AsEnumerable().Where(x => x["quotation_ID"].ToString() != "default" && x["quotation_ID"] != DBNull.Value).ToList().Count;
                if (iQuotationCount > 0)
                {
                    lnkFlowQuotation.Enabled = true;
                    lnkFlowQuotation.LinkColor = Color.FromArgb(27, 84, 121);
                }

                int iCOCount = dt.AsEnumerable().Where(x => x["customerOrder_ID"].ToString() != "default" && x["customerOrder_ID"] != DBNull.Value).ToList().Count;
                if (iCOCount > 0)
                {
                    lnkFlowCustomerOrder.Enabled = true;
                    lnkFlowCustomerOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iDOCount = dt.AsEnumerable().Where(x => x["deliveryOrder_ID"].ToString() != "default" && x["deliveryOrder_ID"] != DBNull.Value).ToList().Count;
                if (iDOCount > 0)
                {
                    lnkFlowDeliveryOrder.Enabled = true;
                    lnkFlowDeliveryOrder.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iInvCount = dt.AsEnumerable().Where(x => x["invoice_ID"].ToString() != "default" && x["invoice_ID"] != DBNull.Value).ToList().Count;
                if (iInvCount > 0)
                {
                    lnkFlowInvoice.Enabled = true;
                    lnkFlowInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iRceiptCount = dt.AsEnumerable().Where(x => x["receipt_ID"].ToString() != "default" && x["receipt_ID"] != DBNull.Value).ToList().Count;
                if (iRceiptCount > 0)
                {
                    lnkFlowReceipt.Enabled = true;
                    lnkFlowReceipt.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iPFInvCount = dt.AsEnumerable().Where(x => x["proformaInvoice_ID"].ToString() != "default" && x["proformaInvoice_ID"] != DBNull.Value).ToList().Count;
                if (iPFInvCount > 0)
                {
                    lnkFlowProfomaInvoice.Enabled = true;
                    lnkFlowProfomaInvoice.LinkColor = Color.FromArgb(45, 139, 201);
                }

                int iSRNCount = dt.AsEnumerable().Where(x => x["salesReturnedNote_ID"].ToString() != "default" && x["salesReturnedNote_ID"] != DBNull.Value).ToList().Count;
                if (iSRNCount > 0)
                {
                    lnkFlowSalesReturned.Enabled = true;
                    lnkFlowSalesReturned.LinkColor = Color.FromArgb(45, 139, 201);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region Inquiry
        private void lnkFlowInquiry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.AsEnumerable()
           .GroupBy(r => new { Col1 = r["inquiryDate"], Col2 = r["inquiryAmount"] })
           .Select(g => g.OrderBy(r => r["inquiry_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["inquiry_ID"].ColumnName = "txnID";
            dt1.Columns["inquiryDate"].ColumnName = "TxnDate";
            dt1.Columns["inquiryAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "INQ. ID", "INQ. Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasInquiry detail = new frm_sasInquiry(FormName.sasInquiry);
                detail.glbInquiryID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Quotation
        private void lnkFlowQuotation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.AsEnumerable()
           .GroupBy(r => new { Col0 = r["quotation_ID"], Col1 = r["quotationDate"], Col2 = r["quotationAmount"] })
           .Select(g => g.OrderBy(r => r["quotation_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["quotation_ID"].ColumnName = "txnID";
            dt1.Columns["quotationDate"].ColumnName = "TxnDate";
            dt1.Columns["quotationAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "Quotation ID", "Quotation Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasQuotation detail = new frm_sasQuotation(FormName.CusQuotation);
                detail.glbQuotationID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Proforma Invoice
        private void lnkFlowProfomaInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.AsEnumerable()
           .GroupBy(r => new { Col1 = r["proformaInvoiceDate"], Col2 = r["proformaInvoiceAmount"] })
           .Select(g => g.OrderBy(r => r["proformaInvoice_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["proformaInvoice_ID"].ColumnName = "txnID";
            dt1.Columns["proformaInvoiceDate"].ColumnName = "TxnDate";
            dt1.Columns["proformaInvoiceAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "PF. INV. ID", "PF. INV. Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasProformaInvoice detail = new frm_sasProformaInvoice(FormName.CusProformaInvoice);
                detail.glbProformaInvoiceID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Customer Order
        private void lnlFlowCustomerOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.Select("customerOrder_ID is not null").CopyToDataTable().AsEnumerable()
           .GroupBy(r => new { Col0 = r["customerOrder_ID"],Col1 = r["customerOrderDate"], Col2 = r["customerOrderAmount"] })
           .Select(g => g.OrderBy(r => r["customerOrder_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["customerOrder_ID"].ColumnName = "txnID";
            dt1.Columns["customerOrderDate"].ColumnName = "TxnDate";
            dt1.Columns["customerOrderAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "CO ID", "CO Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasCustomerOrder detail = new frm_sasCustomerOrder(FormName.CustomerOrder);
                detail.glbCustomerOrderID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Delivery Order
        private void lnlFlowDeliveryOrder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.Select("deliveryOrder_ID is not null").CopyToDataTable().AsEnumerable()
              .GroupBy(r => new { Co0 = r["deliveryOrder_ID"] , Col1 = r["deliveryOrderDate"], Col2 = r["deliveryOrderAmount"]})
              .Select(g => g.OrderBy(r => r["deliveryOrder_ID"]).First())
              .CopyToDataTable();

            dt1.Columns["deliveryOrder_ID"].ColumnName = "txnID";
            dt1.Columns["deliveryOrderDate"].ColumnName = "TxnDate";
            dt1.Columns["deliveryOrderAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "DO ID", "DO Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasDeliveryOrder_ALL detail = new frm_sasDeliveryOrder_ALL(FormName.CusDeliveryOrder);
                detail.glbDeliveryOrderID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Invoice
        private void lnlFlowInvoice_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.Select("invoice_ID is not null").CopyToDataTable().AsEnumerable()
           .GroupBy(r => new { Col0 = r["invoice_ID"], Col1 = r["invoiceDate"], Col2 = r["invoiceAmount"] })
           .Select(g => g.OrderBy(r => r["invoice_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["invoice_ID"].ColumnName = "txnID";
            dt1.Columns["invoiceDate"].ColumnName = "TxnDate";
            dt1.Columns["invoiceAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "Invoice ID", "Invoice Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                //frm_sasInvoice detail = new frm_sasInvoice(FormName.VATInvoice);
                //detail.glbInvoiceID = sResult;
                //clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);

                int iFormID_Inv2 = (int)FormName.SalesInvoice2;
                tbl_securityFormMaster oForm = tbl_securityFormMaster.Select(iFormID_Inv2);
                if (oForm.IsEnable == true)
                {
                    frm_sasInvoice2 frm = new frm_sasInvoice2((FormName)iFormID_Inv2);
                    frm.glbInvoiceID = sResult;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, oTxnLst.ParentForm);
                }
                else
                {
                    FormName fornName = FormName.VATInvoice;
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, (int)FormName.Invoice_TAXReverced, false, false))
                        fornName = FormName.Invoice_TAXReverced;

                    frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                    frm.glbInvoiceID = sResult;
                    clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, oTxnLst.ParentForm);
                }

            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Receipt
        private void lnlFlowReceipt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.Select("receipt_ID is not null").CopyToDataTable().AsEnumerable()
           .GroupBy(r => new { Col0 = r["receipt_ID"],Col1 = r["receiptDate"], Col2 = r["receiptAmount"] })
           .Select(g => g.OrderBy(r => r["receipt_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["receipt_ID"].ColumnName = "txnID";
            dt1.Columns["receiptDate"].ColumnName = "TxnDate";
            dt1.Columns["receiptAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "Receipt. ID", "Receipt. Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                UC_bpsReceiptSales detail = new UC_bpsReceiptSales(FormName.UCReceipt);
                detail.glbReceiptID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

        #region Sales Returned Note
        private void lnkFlowSalesReturned_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt1 = dt.Select("salesReturnedNote_ID is not null").CopyToDataTable().AsEnumerable()
           .GroupBy(r => new { Col0 = r["salesReturnedNote_ID"], Col1 = r["salesReturnedNoteDate"], Col2 = r["salesReturnNoteAmount"] })
           .Select(g => g.OrderBy(r => r["salesReturnedNote_ID"]).First())
           .CopyToDataTable();

            dt1.Columns["salesReturnedNote_ID"].ColumnName = "txnID";
            dt1.Columns["salesReturnedNoteDate"].ColumnName = "TxnDate";
            dt1.Columns["salesReturnNoteAmount"].ColumnName = "Amount";

            string[] ColumnHeaders = { "SRN. ID", "SRN. Date", "Amount" };

            frmTransactionList oTxnLst = new frmTransactionList(dt1, ColumnHeaders, "");

            oTxnLst.Selection += delegate(string sResult)
            {
                frm_sasSalseReturnNote detail = new frm_sasSalseReturnNote(FormName.sasSalesReturenNote);
                detail.glbSalesReturnedNoteID = sResult;
                clsHelpMethods_Local.DisplayForm(detail, clsFormatter.colorSales, oTxnLst.ParentForm);
            };
            oTxnLst.MdiParent = this.ParentForm.MdiParent;
            oTxnLst.Show();
        }
        #endregion

    }
}
