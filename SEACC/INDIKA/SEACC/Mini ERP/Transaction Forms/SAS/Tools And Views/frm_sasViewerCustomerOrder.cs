using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Zion.ERP.Reports.DataSets.PMS;

namespace Digiteq
{
    public partial class frm_sasViewerCustomerOrder : Form
    {

        

           public int iFormID;
        public bool bNoAccess;
        public string glbJobNo = "";
        public string sUom = "";

        decimal dDOTotWaight = 0, dDOTotQty = 0, dSrnTotQty = 0, dSrnTotWaight = 0, dInvTotAmount = 0, dInvTotQty = 0, dInvBallance = 0;
        decimal dCashTotal = 0, dCreditnoteTotal = 0, dChequeTotal = 0;
     //   dts_Jobdetail glb_dts_Jobdetail = new dts_Jobdetail();
    

        #region Form Load
        public frm_sasViewerCustomerOrder()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCustomerOrder);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            btnRefresh_Click(sender, new EventArgs());
        }
        #endregion

        #region Btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbJobNo.Length > 0)
            {
                FillDetails(glbJobNo);
            }
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Print
        private void btnprint_Click(object sender, EventArgs e)
        {
            if (lblItemID.Text != null && lblItemID.Text.ToString().Trim().Length > 0)
            {
                if (clsSecurity.PermissionToPrint_WithMessage(clsAutocode.getReportID(enum_ReportName.NP_JobViewer)))
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                      //  glb_dts_Jobdetail.dt_Pms_JobDetail.Rows.Clear();
                      //  glb_dts_Jobdetail.dt_Pms_JobDetail_Delivery.Rows.Clear();

                        //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(glbJobNo);
                        //if (oJob != null && oJob.ProductionJob_ID != "default")
                        //{
                        //    #region Order details
                        //    string sItemName = "", sCustomerName = "", sOrderNo = "",  sPoNo = "", sProJobNo = "";
                        //    DateTime dtmDeliveryDate = DateTime.MinValue, dtmOrderDate = DateTime.MinValue;
                        //    decimal dCO_Qty = 0, dDO_Qty = 0, dGlDO_Qty = 0, dDO_Weight = 0, dGlDO_Weight = 0, dSRN_Qty = 0, dTotSRN_Qty = 0, dSRN_Weight = 0, dTotSRN_Weight = 0, dUnitPrice = 0;

                        //    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oJob.CustomerOrder_ID);
                        //    if (oCO != null && oCO.CustomerOrder_ID != "default")
                        //    {
                        //        sProJobNo = oJob.ProductionJob_ID;
                        //        sItemName = clsGenaralName.getName_Item(oJob.Item_ID);
                        //        sCustomerName = clsGenaralName.getName_Customer(oCO.Customer_ID);
                        //        sOrderNo = oCO.CustomerOrder_ID;
                        //        dtmOrderDate = oCO.CustomerOrderDate.Date;
                        //        dtmDeliveryDate = oJob.DeliveryDate.Date;
                        //        sPoNo = oCO.PurchaseOrder_ID;
                        //        sUom = clsGenaralName.getName_Uom(oJob.Uom_ID);

                        //        foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                        //        {
                        //            dUnitPrice = oCO.IsWeightCalculation ? oCODetail.WeightPrice : oCODetail.UnitPrice;
                        //            dCO_Qty = oCO.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;
                        //        }

                        //        List<string> sInvoiceList = new List<string>();
                        //        foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                        //        {
                        //            #region Do
                        //            dDO_Qty = 0;
                        //            dDO_Weight = 0;
                        //            foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                        //            {
                        //                dDO_Weight += oDoDetail.Weight;
                        //                dGlDO_Weight += oDoDetail.Weight;
                        //                dDO_Qty += oDoDetail.Qty;
                        //                dGlDO_Qty += oDoDetail.Qty;
                        //            }
                                    
                        //            #endregion

                        //            #region SRN
                        //            int iCount = 0;

                        //            foreach (tbl_sasSalesReturnedNote oSRN in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                        //            {
                        //                dSRN_Qty = 0;
                        //                dSRN_Weight = 0;
                        //                foreach (tbl_sasSalesReturnedNote_Detail oSRNdetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSRN.SalesReturnedNote_ID))
                        //                {
                        //                    dSRN_Qty += oSRNdetail.Qty;
                        //                    dTotSRN_Qty += oSRNdetail.Qty;
                        //                    dSRN_Weight += oSRNdetail.Weight;
                        //                    dTotSRN_Weight += oSRNdetail.Weight;
                        //                }
                        //                glb_dts_Jobdetail.dt_Pms_JobDetail_Delivery.Adddt_Pms_JobDetail_DeliveryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, (iCount == 0) ? dDO_Weight : 0, (iCount == 0) ? dDO_Qty : 0, "", oSRN.SalesReturnedNote_ID, oSRN.SalesReturnedNoteDate, dSRN_Weight, dSRN_Qty);
                        //                iCount++;
                        //            }
                        //            if (iCount == 0)
                        //                glb_dts_Jobdetail.dt_Pms_JobDetail_Delivery.Adddt_Pms_JobDetail_DeliveryRow(oDO.DeliveryOrder_ID, oDO.DeliveryOrderDate, dDO_Weight, dDO_Qty, "", "", DateTime.MinValue, 0, 0);
                        //            #endregion
                        //        }
                        //        decimal dPendingQty = 0;
                        //        if (oCO.IsWeightCalculation)
                        //            dPendingQty = dCO_Qty - (dGlDO_Weight - dTotSRN_Weight);
                        //        else
                        //            dPendingQty = dCO_Qty - (dGlDO_Qty - dTotSRN_Qty);

                        //        glb_dts_Jobdetail.dt_Pms_JobDetail.Adddt_Pms_JobDetailRow(sItemName.ToString(), sCustomerName.ToString(), dCO_Qty, dPendingQty, sProJobNo, sOrderNo, sPoNo, dUnitPrice, dtmOrderDate, dtmDeliveryDate, sUom, oCO.IsWeightCalculation);

                        //    }
                        //    #endregion
                        //}

                     //   print("\\Reports\\PMS\\Standard\\rpt_pmsReportView.rpt", "Job Detail Report", glb_dts_Jobdetail);
                    }
                    catch (Exception ex)
                    {
                        clsValidate.WriteErrorLog("", iFormID,ex);
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                    //    glb_dts_Jobdetail.dt_Pms_JobDetail.Rows.Clear();
                     //   glb_dts_Jobdetail.dt_Pms_JobDetail_Delivery.Rows.Clear();
                        Cursor = Cursors.Default;
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDelivary, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvReturn, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvInvoice, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
            clsFormatter.ApplyGridFormat(dgvPayment, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //Header lables
            lblItemID.Text = "";
            lblCustomerCode.Text = "";
            lblDeliveryDate.Text = "";
            lblProJobNo.Text = "";
            lblCustomerCategory.Text = "";
            lblCustomerName.Text = "";
            lblPoNo.Text = "";
            lblOrderQty.Text = "";
            lblPendingDeliveryQty.Text = "";
           
            lblOrderNo.Text = "";
            lblOrderDate.Text = "";
            lblUnitPrice.Text = "";
            lblTotalPrice.Text = "";
            lblUOM.Text = "";
            lblCurrency.Text = "";
            //D/o
            lblTotalDOWaight.Text = "";
            lblTotalDOQty.Text = "";

            //SRN
            lblTotalSRNWaigth.Text = "";
            lblTotalSRNQty.Text = "";

            //Invoise
            lblTotInvQty.Text = "";
            lblTotInvAmount.Text = "";
            lblInvbalance.Text = "";

            //Payment
            lblCNCashTot.Text = "";
            lblCRNCheque.Text = "";
            lblCRNTotal.Text = "";

            //claer data grid
            dgvDelivary.Rows.Clear();
            dgvReturn.Rows.Clear();
            dgvInvoice.Rows.Clear();
            dgvPayment.Rows.Clear();
            flpStoryBook.Controls.Clear();

            dDOTotWaight = 0;
            dDOTotQty = 0;
            dSrnTotQty = 0;
            dSrnTotWaight = 0;
            dInvTotAmount = 0;
            dInvTotQty = 0;
            dInvBallance = 0;
            dCashTotal = 0;
            dCreditnoteTotal = 0;
            dChequeTotal = 0;
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sJobCode)
        {
            string sUom = "";
            try
            {
                List<clsStoryBook> oStoryBook = new List<clsStoryBook>();
                //tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(glbJobNo);
                //if (oJob != null && oJob.ProductionJob_ID != "default")
                //{
                //    #region Order details
                //    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oJob.CustomerOrder_ID);
                //    if (oCO != null && oCO.CustomerOrder_ID != "default")
                //    {
                //        lblProJobNo.Text = oJob.ProductionJob_ID;
                //        lblSalesJobNo.Text = oCO.Job_ID;
                //        lblItemID.Text = oJob.Item_ID;
                //        lblCustomerCategory.Text = clsGenaralName.getName_Item(oJob.Item_ID);
                //        lblCustomerCode.Text = oCO.Customer_ID;
                //        lblCustomerName.Text = clsGenaralName.getName_Customer(oCO.Customer_ID);
                //        lblOrderNo.Text = oCO.CustomerOrder_ID;
                //        lblOrderDate.Text = clsFormatter.FormatDate_Short(oCO.CustomerOrderDate);
                //        lblDeliveryDate.Text = clsFormatter.FormatDate_Short(oJob.DeliveryDate);
                //        lblUOM.Text = clsGenaralName.getName_Currency(oCO.Currency_ID);
                //        lblPoNo.Text = oCO.PurchaseOrder_ID;
                //        sUom = clsGenaralName.getName_Uom(oJob.Uom_ID);
                //        lblUOM.Text = sUom;
                //        lblCurrency.Text = clsGenaralName.getName_CurrencyCode(oJob.Currency_ID);
                        
                //        oStoryBook.Add(new clsStoryBook("C/O Created", oCO.DateCreate, Color.DarkGreen));
                //        oStoryBook.Add(new clsStoryBook("P.Job Created", oJob.DateCreate, Color.DarkBlue));
                //        oStoryBook.Add(new clsStoryBook("Job Approved", oJob.DateApproved,Color.DarkBlue));                        
                //        int iCloseCount = 0;
                //        //foreach (tbl_pmsProductionJobManualSettle_Detail oJobCloses in tbl_pmsProductionJobManualSettle_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                //        //{
                //        //    tbl_pmsProductionJobManualSettle oJobClose = tbl_pmsProductionJobManualSettle.Select(oJobCloses.Settle_ID);
                //        //    if (oJobClose != null)
                //        //    {
                //        //        iCloseCount++;
                //        //        oStoryBook.Add(new clsStoryBook("Job" + oJobClose.Remark, oJobClose.DateCreate, Color.DarkRed));
                //        //    }
                //        //}
                //        //if (oJob.IsJobClosed && iCloseCount != 0)
                //        //    oStoryBook.Add(new clsStoryBook("Job Closed", oJob.DateModified, Color.DarkRed));

                //        //foreach (tbl_pmsPrePlan oPlan in tbl_pmsPrePlan.SelectAllByProductionJob_ID(oJob.ProductionJob_ID))
                //        //{
                //        //    oStoryBook.Add(new clsStoryBook("Pre Plan Created", oPlan.DateCreate, Color.DarkBlue));
                //        //    if (oPlan.IsDeleted)
                //        //        oStoryBook.Add(new clsStoryBook("Pre Plan Deleted", oPlan.DateModified, Color.DarkOrange));
                //        //}

                //        foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                //        {
                //            lblOrderQty.Text = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oCODetail.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oCODetail.Qty);// clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(oCODetail.Qty.ToString()));
                //            lblPendingDeliveryQty.Text = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oCODetail.Weight - oCODetail.WeightSettle_DeliveryOrder) : clsFormatter.FormatDecimalPlaces_Quantity(oCODetail.Qty - oCODetail.QtySettle_DeliveryOrder);
                //            lblUnitPrice.Text = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_WeightPrice(oCODetail.WeightPrice) : clsFormatter.FormatDecimalPlaces_UnitPrice(oCODetail.UnitPrice);
                //            lblTotalPrice.Text = clsFormatter.FormatDecimalPlaces_Price(oCO.GrandTotal);
                //        }

                //        int iRowDO;

                //        List<string> sInvoiceList = new List<string>();
                //        foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p=> !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                //        {
                //            #region Do
                //            oStoryBook.Add(new clsStoryBook("D/O Created", oDO.DateCreate, Color.DarkBlue));
                //            foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                //            {
                //                dgvDelivary.Rows.Add();
                //                iRowDO = dgvDelivary.Rows.Count - 1;
                //                dgvDelivary["DelivaryID", iRowDO].Value = oDO.DeliveryOrder_ID;
                //                dgvDelivary["DelivaryDate", iRowDO].Value = clsFormatter.FormatDate_Short(oDO.DeliveryOrderDate);
                //                dgvDelivary["DelivaryWaight", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Weight(oDoDetail.Weight);
                //                dgvDelivary["DelivaryQty", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Quantity(oDoDetail.Qty);
                //                dgvDelivary["UOMCode", iRowDO].Value = sUom;

                //                dDOTotWaight += oDoDetail.Weight;
                //                dDOTotQty += oDoDetail.Qty;
                //            }
                //            #endregion

                //            #region SRN
                //            foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                //            {
                //                tbl_sasSalesReturnedNote oSRN = tbl_sasSalesReturnedNote.Select(oSRNDetail.SalesReturnedNote_ID);
                //                if (oSRN != null && oSRN.SalesReturnedNote_ID != "default" && !oSRN.IsDeleted && oSRN.IsChecked)
                //                {
                //                    dgvReturn.Rows.Add();
                //                    iRowDO = dgvReturn.Rows.Count - 1;
                //                    dgvReturn["SRNDeliveryID", iRowDO].Value = oSRN.DeliveryOrder_ID;
                //                    dgvReturn["SRNReturnedID", iRowDO].Value = oSRN.SalesReturnedNote_ID;
                //                    dgvReturn["SRNReturnDate", iRowDO].Value = clsFormatter.FormatDate_Short(oSRN.SalesReturnedNoteDate);
                //                    dgvReturn["SRNReturnWaight", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Weight(oSRNDetail.Weight);
                //                    dgvReturn["SRNReturnQty", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Quantity(oSRNDetail.Qty);
                //                    dgvReturn["SRNUOM", iRowDO].Value = sUom;

                //                    dSrnTotQty += oSRNDetail.Qty;
                //                    dSrnTotWaight += oSRNDetail.Weight;
                //                }
                //            }
                //            #endregion

                //            #region Invoice And Payments
                //            foreach (tbl_sasInvoice_Detail oTemInvoices in tbl_sasInvoice_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                //            {
                //                if (!sInvoiceList.Contains(oTemInvoices.Invoice_ID))
                //                    sInvoiceList.Add(oTemInvoices.Invoice_ID);
                //            }
                //            #endregion                            
                //        }

                //        #region Invoice And Payments
                //        foreach (string sInvoiceID in sInvoiceList)
                //        {
                //            tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sInvoiceID);
                //            if (oInvoice != null && oInvoice.Invoice_ID != "default" && !oInvoice.IsDeleted)
                //            {
                //                #region Invoice
                //                oStoryBook.Add(new clsStoryBook("Invoice Created", oInvoice.DateCreate, Color.DarkBlue));
                //                foreach (tbl_sasInvoice_Detail oInvDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                //                {
                //                    dgvInvoice.Rows.Add();
                //                    iRowDO = dgvInvoice.Rows.Count - 1;
                //                    dgvInvoice["iDeliveryId", iRowDO].Value = oInvoice.DeliveryOrder_ID;
                //                    dgvInvoice["InvoiceID", iRowDO].Value = oInvoice.Invoice_ID;
                //                    dgvInvoice["InvoiceDate", iRowDO].Value = clsFormatter.FormatDate_Short(oInvoice.InvoiceDate.Date);
                //                    dgvInvoice["InvoiceQTY", iRowDO].Value = oInvoice.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oInvDetail.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oInvDetail.Qty);
                //                    dgvInvoice["UOM1", iRowDO].Value = sUom;
                //                    dgvInvoice["GrandTotal", iRowDO].Value = oInvoice.GrandTotal;
                //                    dgvInvoice["Balance_Amount", iRowDO].Value = oInvDetail.TatalAmount;
                //                    dInvTotQty += oInvoice.IsWeightCalculation ? oInvDetail.Weight : oInvDetail.Qty;                                   
                //                }
                //                dInvTotAmount += oInvoice.GrandTotal;                               
                //                dInvBallance += (oInvoice.GrandTotal - oInvoice.SeattleAmount);
                //                #endregion

                //                #region Payments
                //                foreach (tbl_sasInvoice_Sattled oInvSettlement in tbl_sasInvoice_Sattled.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                //                {
                //                    dgvPayment.Rows.Add();
                //                    iRowDO = dgvPayment.Rows.Count - 1;
                //                    dgvPayment["AllocatedInvo", iRowDO].Value = oInvSettlement.Invoice_ID;
                //                    dgvPayment["AlocatedAmount", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Price(oInvSettlement.SattledAmount);
                //                    //tbl_bpsReceipt oRecipt = tbl_bpsReceipt.Select(oInvSettlement.Receipt_ID);
                //                    //if (oRecipt != null && oRecipt.Receipt_ID != "default")
                //                    //{
                                      
                //                    //}
                //                    tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oInvSettlement.ChequeRegister_ID);
                //                    if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                //                    {
                //                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                //                        {
                //                            dgvPayment["ChequeNo", iRowDO].Value = oCheque.ChequeNumber;
                //                            dgvPayment["ChequeAmount", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount);
                //                            dgvPayment["AlocatedAmount", iRowDO].Value = clsFormatter.FormatDecimalPlaces_Price(oCheque.SetteledAmount);
                //                            dChequeTotal += oCheque.Amount;
                //                        }
                //                        else
                //                        {
                //                            dgvPayment["ReceiptNo", iRowDO].Value = oInvSettlement.Receipt_ID;
                //                            dgvPayment["ReceiptDate", iRowDO].Value = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                //                            dCashTotal += oCheque.Amount;
                //                        }
                //                    }
                //                    tbl_bpsCreditNote oCreditNote = tbl_bpsCreditNote.Select(oInvSettlement.CreditNote_ID);
                //                    if (oCreditNote != null && oCreditNote.CreditNote_ID != "default")
                //                    {
                //                        dgvPayment["CreditNote_No", iRowDO].Value = oInvSettlement.CreditNote_ID;
                //                        dgvPayment["ReceiptDate", iRowDO].Value = clsFormatter.FormatDate_Short(oCreditNote.CreditNoteDate);
                //                        dCreditnoteTotal += oCreditNote.TotalAmount;
                //                    }
                //                }
                //                #endregion
                //            }
                //        }
                //        #endregion

                //        lblTotalDOWaight.Text = clsFormatter.FormatDecimalPlaces_Weight(dDOTotWaight);
                //        lblTotalDOQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dDOTotQty);
                //        lblTotalSRNWaigth.Text = clsFormatter.FormatDecimalPlaces_Weight(dSrnTotWaight);
                //        lblTotalSRNQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dSrnTotQty);
                //        lblTotInvQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dInvTotQty);
                //        lblTotInvAmount.Text = clsFormatter.FormatDecimalPlaces_Price(dInvTotAmount);
                //        lblInvbalance.Text = clsFormatter.FormatDecimalPlaces_Price(dInvBallance);
                //        lblCNCashTot.Text = clsFormatter.FormatDecimalPlaces_Price(dCashTotal);
                //        lblCRNCheque.Text = clsFormatter.FormatDecimalPlaces_Price(dChequeTotal);
                //        lblCRNTotal.Text = clsFormatter.FormatDecimalPlaces_Price(dCreditnoteTotal);
                //    }
                //    #endregion
                //}

                

                int iCount = 0;
                if (oStoryBook.Count > 8)
                    this.AutoScroll = true;
                foreach (clsStoryBook oStory in oStoryBook.OrderBy(p=> p.DtmTransactionDate))
                {
                    iCount++;
                    PictureBox pbxImage = new PictureBox();
                    pbxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pbxImage.Image = Digiteq.Properties.Resources.A_RIGHT;
                    pbxImage.Size = new Size(40, 41);
                    Label lblItem = new Label();
                    lblItem.Font = new Font("calibri", 7, FontStyle.Bold);
                    lblItem.TextAlign = ContentAlignment.BottomCenter;
                    lblItem.ForeColor = oStory.FontColour;
                    lblItem.BorderStyle = BorderStyle.FixedSingle;
                    lblItem.AutoSize = false;
                    lblItem.Size = new Size(81, 41);
                    lblItem.Text = oStory.STransaction + "\n" + clsFormatter.FormatDate_Short(oStory.DtmTransactionDate) + "\n" + clsFormatter.FormatTime_Short(oStory.DtmTransactionDate);

                    flpStoryBook.Controls.Add(lblItem);
                    if (iCount != oStoryBook.Count)
                        flpStoryBook.Controls.Add(pbxImage);
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

            CusDataGridViewFormat();
        }
        #endregion

        #region Calculation

        #endregion


        #region Grid Events
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string sInvoiceID = "";
            //sInvoiceID = dgvDelivary["InvoiceNo", e.RowIndex].Value.ToString();

            //if (sInvoiceID.Length > 0)
            //{
            //    frm_sasInvoice invoice = new frm_sasInvoice();
            //    invoice.glbInvoiceID = sInvoiceID;
            //    invoice.MdiParent = this.MdiParent;
            //    invoice.Show();
            //}
        }
        #endregion        

        #region Events DoubleClisk
        private void flpStoryBook_DoubleClick(object sender, EventArgs e)
        {
            flpStoryBook.Size = new Size(888, 300);
        } 
        #endregion

        #region Print Method
        private void print(string path, string sReportTitle, DataSet objDataTable)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string s_Path = "", sHeaderTitle = "PMS Reports";
                CrystalDecisions.CrystalReports.Engine.ReportDocument objRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                s_Path += path;

                objRpt.Load(s_Path);
                objRpt.SetDataSource(objDataTable); //(glbDtsSales)

                objRpt.DataDefinition.FormulaFields["HeaderTitle"].Text = clsCommon.fncsetstring(sHeaderTitle);
                objRpt.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                //objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring("From : " + dtpFrom.Value.ToString("dd MMM yyyy") + "      To : " + dtpTo.Value.ToString("dd MMM yyyy"));
                //objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                objRpt.DataDefinition.FormulaFields["UserName"].Text = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                objRpt.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                objRpt.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                objRpt.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                objRpt.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                objRpt.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);

                frm_ReportViewer ReportViewer = new frm_ReportViewer();
                ReportViewer.crystalReportViewer1.ReportSource = objRpt;
                ReportViewer.crystalReportViewer1.Refresh();
                ReportViewer.crystalReportViewer1.DisplayToolbar = true;
                ReportViewer.crystalReportViewer1.CloseView(false);
                ReportViewer.WindowState = FormWindowState.Maximized;
                ReportViewer.ShowDialog();

                objRpt.Close();
                objRpt.Dispose();
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

        #region Get CustomerOrderStatus & ClosedDate
        public static void getCustomerOrderStatusAndClosedDate(string sCOID, ref string sStatus, ref string sClosedDate)
        {
            tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(sCOID);
            if (oCO != null && oCO.Customer_ID != "default")
            {
                if (oCO.IsSeattled)
                {
                    sStatus = "Closed";
                    //foreach (tbl_pmsProductionJobManualSettle_Detail detail in tbl_pmsProductionJobManualSettle_Detail.SelectAllByCustomerOrder_ID(sCOID).OrderBy(p => p.Settle_ID))
                    //{
                    //    tbl_pmsProductionJobManualSettle oHeader = tbl_pmsProductionJobManualSettle.Select(detail.Settle_ID);
                    //    if (oHeader != null)
                    //    {
                    //        sStatus = oHeader.Remark;
                    //        sClosedDate = clsFormatter.FormatDate_Short(oHeader.DateCreate);
                    //    }
                    //}
                }
                else
                {
                    sStatus = "In-Progress";
                    sClosedDate = "";
                }
            }
        }
        #endregion
     
    }

    class clsStoryBook
    {
        string sTransaction;
        DateTime dtmTransactionDate;
        Color fontColour;

        public Color FontColour
        {
            get { return fontColour; }
            set { fontColour = value; }
        }
        public string STransaction
        {
            get { return sTransaction; }
            set { sTransaction = value; }
        }
        public DateTime DtmTransactionDate
        {
            get { return dtmTransactionDate; }
            set { dtmTransactionDate = value; }
        }
        public clsStoryBook(string sTransaction, DateTime dtmTransactionDate, Color fontColour)
        {
            this.sTransaction = sTransaction;
            this.dtmTransactionDate = dtmTransactionDate;
            this.fontColour = fontColour;
        }

    }
}
