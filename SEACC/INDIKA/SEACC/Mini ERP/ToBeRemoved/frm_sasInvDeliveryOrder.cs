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
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frm_sasInvDeliveryOrder : Form
    {
        
        //to manage update and insert
        static bool IsUpdate = false;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
   //     DateTime glbApprovedDate = clsSecurity.getServerDateTime();
   //     DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        //to keep glob ref no        
        public string glbOrderRefNo = "", glbInvoiceID = "", glbDeliveryOrderID = "";
        

        //for handle Revers Calculation
        bool isDonVatReversCalculation = false;
        bool isDonNbtReversCalculation = false;
   

        #region Form Load
        public frm_sasInvDeliveryOrder()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusDeliveryOrder);
            iFormID = clsSecurity.getFormID(FormName.CusDeliveryOrder);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_sasCustomerDeliveryOrder_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Sales Delivery Order", 2, iFormID);
          //  clsFormatter.FormatProcessFlow(txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder, txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);
            CusDataGridViewFormat();

            ClearFields();
            CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);            

            //if the D/O genarated from a customer order
            if (glbInvoiceID.Length > 0)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(glbInvoiceID);
                if (detail != null)
                {
                    chkUnitPricing.Checked = !detail.IsWeightCalculation;
                    FillDetailsCustomer(detail.Customer_ID);
                    glbOrderRefNo = detail.OrderRefNo_ID;
                    txtInvoiceID.Tag = detail.Invoice_ID;
                    btnAddInvoice_Click(sender, new EventArgs());
                    FillTaxDetailByInvoiceID(glbInvoiceID);           
                }
            }
            else if (glbDeliveryOrderID.Length > 0)
            {
                FillDetails(glbDeliveryOrderID);
            }
        } 
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0)
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                        {
                            //delete one record
                            Cursor = Cursors.WaitCursor;
                            tbl_sasInvDeliveryOrder detail = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                            if (detail != null)
                            {
                                if (!detail.IsLocked)
                                {
                                    if (!detail.IsDeleted)
                                    {
                                        if (true)//clsValidate.CheckPostingValidity(detail.PostingStatus_ID))
                                        {
                                            frmCancel_DO frm = new frmCancel_DO();
                                            frm.glbNoteID = "D/O Number : " + txtDeliveryOrderID.Text.Trim();
                                            frm.ShowDialog();

                                            if (frm.glbValied)
                                            {
                                                //////Update Other Tables 
                                                #region Update Other Tables
                                                List<tbl_sasInvDeliveryOrder_Detail> Dodetails = tbl_sasInvDeliveryOrder_Detail.SelectAllByIDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim());
                                                foreach (tbl_sasInvDeliveryOrder_Detail Dodetail in Dodetails)
                                                {
                                                    if (Dodetail.Item_ID != null)
                                                    {
                                                        //////Unsettle Customer Order
                                                        #region Unsettle Customer Order
                                                        #region Get Canceled Reson Properties
                                                        bool bTotalCancel = false;
                                                        if (frm.glbSystemReson)
                                                        {
                                                            tbl_zCancelReson_DO cancelDO = tbl_zCancelReson_DO.Select(frm.glbSystemResonID);
                                                            if (cancelDO != null)
                                                            {
                                                                if (cancelDO.IsPermanentCancel)
                                                                    bTotalCancel = true;
                                                                else if (cancelDO.IsRepeatDelivery)
                                                                    bTotalCancel = false;
                                                            }
                                                        }
                                                        else
                                                            bTotalCancel = true;
                                                        #endregion

                                                        if (Dodetail.Invoice_ID != null && Dodetail.Invoice_ID != "default")
                                                        {
                                                            if (bTotalCancel)
                                                            {
                                                                tbl_sasInvoice cOrder = tbl_sasInvoice.Select(Dodetail.Invoice_ID);
                                                                if (cOrder != null)
                                                                {
                                                                    cOrder.IsSeattled = true;
                                                                    cOrder.Update();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                tbl_sasInvoice_Detail CoItem = tbl_sasInvoice_Detail.Select(Dodetail.Line_No, Dodetail.Invoice_ID, Dodetail.Item_ID,
                                                                    Dodetail.ItemSubCategory_ID, Dodetail.ItemSubCategory2_ID, Dodetail.ItemSerialNo, Dodetail.ItemSerialNo2, "default");
                                                                if (CoItem != null)
                                                                {
                                                                    if (!detail.IsWeightCalculation)
                                                                        CoItem.QtySettle = CoItem.QtySettle - Dodetail.Qty;
                                                                    else
                                                                        CoItem.WeightSettle = CoItem.WeightSettle - Dodetail.Weight;
                                                                    CoItem.Update();
                                                                    clsProcessMethods.SetSettle_InvoiceFrom_DeliveryOrder(Dodetail.Invoice_ID, chkUnitPricing);
                                                                }
                                                            }
                                                        }
                                                        #endregion

                                                        ////Update Store Stock
                                                        #region Update Store Stock
                                                        string sTmpJobCode = "", sOldItemCode = Dodetail.Item_ID, sOldItemSubCategoryID = Dodetail.ItemSubCategory_ID,
                                                            sOldItemSubCategoryID2 = Dodetail.ItemSubCategory2_ID, sOldItemSerialNo = Dodetail.ItemSerialNo, sOldItemSerialNo2 = Dodetail.ItemSerialNo2;
                                                        sTmpJobCode = "default";

                                                        //check whether single item stock enabled - qty
                                                        if (clsConfig.bSingleItemStockEnabled)
                                                        {
                                                            if (!clsHelpMethods_Local.IsItemRawMaterial(sOldItemCode))
                                                            {
                                                                sOldItemCode = clsConfig.sSingleItemStockItemID;
                                                                sOldItemSubCategoryID = clsConfig.sSingleItemStockItemSubCategoryID;
                                                                sOldItemSubCategoryID2 = clsConfig.sSingleItemStockItemSubCategory2ID;
                                                                sOldItemSerialNo = clsConfig.sSingleItemStockItemSerialNo;
                                                                sOldItemSerialNo2 = clsConfig.sSingleItemStockItemSerialNo2;
                                                            }
                                                        }

                                                        //update stock detail
                                                        if (clsHelpMethods_Local.isStore_StockAvailabel(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2))
                                                        {
                                                           // if (clsConfig.bStockValidateQty_DeliveryOrder)
                                                             //   clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Qty);
                                                          //  if (clsConfig.bStockValidateWeight_DeliveryOrder)
                                                              //  clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Weight);
                                                        }
                                                        //else
                                                         //   clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Weight, 0, Dodetail.Qty, 0, 0, 0, 0, 0);
                                                        #endregion
                                                    }
                                                }
                                                #endregion

                                                if (frm.glbSystemReson)
                                                    detail.CancelReason_ID_DO = frm.glbSystemResonID;
                                                else
                                                    detail.CancelReason_ID_DO = "default";
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.Update();

                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else //if no permission to delete
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                        CalcualteGrandTotal();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
                    {
                        if (CheckStockValidity())
                        {
                            if (CheckOutstandingValidity())
                            {
                                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryDate.Value.Date))
                                {
                                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                                    {
                                        try
                                        {
                                            Cursor = Cursors.WaitCursor;
                                            ValidateEmptyForeignKey();
                                            if (glbOrderRefNo.Length <= 0)
                                                glbOrderRefNo = "default";

                                            if (IsUpdate)  //update records
                                            {
                                                #region Update
                                                tbl_sasInvDeliveryOrder oldRecord = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                                if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                                                {
                                                    if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                                                    {

                                                        int Gen_LineNo = -1;
                                                        string Gen_ItemID = "default", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                                                        decimal Gen_TotWeight = 0, Gen_TotQty = 0;
                                                        bool Gen_HasABreakdown = false;

                                                        #region Update Old Detail
                                                        List<tbl_sasInvDeliveryOrder_Detail> oldDoDetails = tbl_sasInvDeliveryOrder_Detail.SelectAllByIDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim());
                                                        foreach (tbl_sasInvDeliveryOrder_Detail oldDoDetail in oldDoDetails)
                                                        {
                                                            string sItemCode = "", sUom = "default", sInvoiceCode = "", sQuotationCode = "", sJobCode = "", sRemarks = "";
                                                            decimal dWidth = 0, dHeight = 0, dGauge = 0, dGusset = 0, dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0,
                                                                dWeight = 0, dAmount = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0;
                                                            bool bHasDoInDB = false;

                                                            foreach (DataGridViewRow row in dgvDetail.Rows)
                                                            {
                                                                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                                sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                                                sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                                                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                                dWidth = clsValidate.ValidateGridValue(dgvDetail, "Width", row.Index, decimal.Parse("0.00"));
                                                                dHeight = clsValidate.ValidateGridValue(dgvDetail, "Height", row.Index, decimal.Parse("0.00"));
                                                                dGauge = clsValidate.ValidateGridValue(dgvDetail, "Gauge", row.Index, decimal.Parse("0.00"));
                                                                dGusset = clsValidate.ValidateGridValue(dgvDetail, "Gusset", row.Index, decimal.Parse("0.00"));
                                                                dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                                sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index, "default");
                                                                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                                dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                                sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                                sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                                dRecommendedUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtCustomerID.Tag.ToString());
                                                                dRecommendedWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                                                if (chkUnitPricing.Checked)
                                                                    dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                                                else
                                                                    dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                                                if (oldDoDetail.IDeliveryOrder_ID == txtDeliveryOrderID.Text.Trim() && oldDoDetail.Item_ID == sItemCode && oldDoDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                                                                oldDoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDoDetail.ItemSerialNo == sItemSerialNo && oldDoDetail.ItemSerialNo2 == sItemSerialNo2)
                                                                {
                                                                    bHasDoInDB = true;
                                                                    //////Update DO Detail
                                                                    tbl_sasInvDeliveryOrder_Detail items = new tbl_sasInvDeliveryOrder_Detail(row.Index, txtDeliveryOrderID.Text.Trim(), sItemCode, sItemSubCategoryID,
                                                                    sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, sInvoiceCode, dQuantity, oldDoDetail.QtySettle, dWeight, oldDoDetail.WeightSettle,
                                                                         dUnitPrice, dWeightPrice, 0, 0, dAmount, 0, 0, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks);
                                                                    items.Update();

                                                                    dgvDetail.Rows.RemoveAt(row.Index);
                                                                    break; //database contain this item                                                                    
                                                                }
                                                            }
                                                            //If old Recode Excest in Database
                                                            if (bHasDoInDB)
                                                            {
                                                                //Get Unit Price with Exchange rate to save
                                                                dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                                dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                                                dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                                                if (sItemCode.Trim().Length > 0)
                                                                {

                                                                    //////Update Invoice
                                                                    #region Update Customer Order
                                                                    if (sInvoiceCode != "default")
                                                                    {
                                                                        tbl_sasInvoice_Detail CoItem = tbl_sasInvoice_Detail.Select(0, sInvoiceCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, "default");
                                                                        if (CoItem != null)
                                                                        {
                                                                            if (chkUnitPricing.Checked)
                                                                                CoItem.QtySettle = (CoItem.QtySettle - oldDoDetail.Qty) + dQuantity;
                                                                            else
                                                                                CoItem.WeightSettle = (CoItem.WeightSettle - oldDoDetail.Weight) + dWeight;
                                                                            CoItem.Update();
                                                                            clsProcessMethods.SetSettle_InvoiceFrom_DeliveryOrder(sInvoiceCode, chkUnitPricing);
                                                                        }
                                                                    }
                                                                    #endregion

                                                                    ////Update store stock when user modify the old recode
                                                                    #region Update Store Stock
                                                                    string sTmpJobCode = "";
                                                                    if (!clsConfig.bStoreStockWithJobID)
                                                                        sTmpJobCode = "default";
                                                                    else
                                                                        sTmpJobCode = sJobCode;

                                                                    //check whether single item stock enabled - qty
                                                                    if (clsConfig.bSingleItemStockEnabled)
                                                                    {
                                                                        if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
                                                                            clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
                                                                    }

                                                                    //update stock detail
                                                                    if (clsHelpMethods_Local.isStore_StockAvailabel(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2))
                                                                    {
                                                                        if (clsConfig.bStockValidateQty_DeliveryOrder) //check whether stock enabled - qty    
                                                                        {
                                                                         //   if (clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, oldDoDetail.Qty))
                                                                       //         clsHelpMethods_Local.Store_StockQuantityDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity);
                                                                        }
                                                                        if (clsConfig.bStockValidateWeight_DeliveryOrder) //check whether stock enabled - weight
                                                                        {
                                                                       //     if (clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, oldDoDetail.Weight))
                                                                       //         clsHelpMethods_Local.Store_StockWeightDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dWeight);
                                                                        }
                                                                    }
                                                                  //  else
                                                                      //  clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dWeight, 0, dQuantity, 0, 0, 0, 0, 0);

                                                                    #endregion

                                                                    oldDoDetail.Item_ID = sItemCode;
                                                                    oldDoDetail.Invoice_ID = sInvoiceCode;
                                                                    oldDoDetail.Qty = dQuantity;
                                                                    oldDoDetail.Weight = dWeight;
                                                                    oldDoDetail.UnitPrice = dUnitPrice;
                                                                    oldDoDetail.WeightPrice = dWeightPrice;
                                                                    oldDoDetail.TatalAmount = dAmount;
                                                                    oldDoDetail.Remark = sRemarks;
                                                                    oldDoDetail.Update();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                //Update Store Stock if user delete old inserted item
                                                                #region Update Store Stock If User Delete the old Input
                                                                string sTmpJobCode = "", sOldItemCode = oldDoDetail.Item_ID, sOldItemSubCategoryID = oldDoDetail.ItemSubCategory_ID,
                                                                    sOldItemSubCategoryID2 = oldDoDetail.ItemSubCategory2_ID, sOldItemSerialNo = oldDoDetail.ItemSerialNo, sOldItemSerialNo2 = oldDoDetail.ItemSerialNo2;
                                                                if (!clsConfig.bStoreStockWithJobID)
                                                                    sTmpJobCode = "default";

                                                                //check whether single item stock enabled - qty
                                                                if (clsConfig.bSingleItemStockEnabled)
                                                                {
                                                                    if (!clsHelpMethods_Local.IsItemRawMaterial(sOldItemCode))
                                                                        clsHelpMethods_Local.AssignSingleStockItemDetail(ref sOldItemCode, ref sOldItemSubCategoryID, ref sOldItemSubCategoryID2, ref sOldItemSerialNo, ref sOldItemSerialNo2);
                                                                }

                                                                //update stock detail
                                                                if (clsHelpMethods_Local.isStore_StockAvailabel(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2))
                                                                {
                                                                //    if (clsConfig.bStockValidateQty_DeliveryOrder) //check whether stock enabled - qty   
                                                                //        clsHelpMethods_Local.Store_StockQuantityIncrease(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, oldDoDetail.Qty);
                                                                //    if (clsConfig.bStockValidateWeight_DeliveryOrder) //check whether stock enabled - weight
                                                                //        clsHelpMethods_Local.Store_StockWeightIncrease(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, oldDoDetail.Weight);
                                                                }
                                                              //  else
                                                                 //   clsHelpMethods_Local.Store_NewStock(txtStoreID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, oldDoDetail.Weight, 0, oldDoDetail.Qty, 0, 0, 0, 0, 0);
                                                                #endregion
                                                                oldDoDetail.Delete();
                                                            }
                                                        }
                                                        #endregion

                                                        #region Insert Newly Added Detail
                                                        foreach (DataGridViewRow row in dgvDetail.Rows)
                                                        {
                                                            string sItemCode = "", sUom = "default", sInvoiceCode = "", sQuotationCode = "", sJobCode = "", sRemarks = "";
                                                            decimal dWidth = 0, dHeight = 0, dGauge = 0, dGusset = 0, dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0,
                                                                dWeight = 0, dAmount = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0;

                                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                            sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                                            sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                                            sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                            dWidth = clsValidate.ValidateGridValue(dgvDetail, "Width", row.Index, decimal.Parse("0.00"));
                                                            dHeight = clsValidate.ValidateGridValue(dgvDetail, "Height", row.Index, decimal.Parse("0.00"));
                                                            dGauge = clsValidate.ValidateGridValue(dgvDetail, "Gauge", row.Index, decimal.Parse("0.00"));
                                                            dGusset = clsValidate.ValidateGridValue(dgvDetail, "Gusset", row.Index, decimal.Parse("0.00"));
                                                            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                            sUom = clsValidate.ValidateGridTag(dgvDetail, "Uom", row.Index, "default");
                                                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                            dRecommendedUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtCustomerID.Tag.ToString());
                                                            dRecommendedWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                                            if (chkUnitPricing.Checked)
                                                                dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                                            else
                                                                dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                                            //Get Unit Price with Exchange rate to save
                                                            dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                            dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                                            dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                                            if (sItemCode.Length > 0)
                                                            {
                                                                tbl_sasInvDeliveryOrder_Detail items = new tbl_sasInvDeliveryOrder_Detail(row.Index, txtDeliveryOrderID.Text.Trim(), sItemCode, sItemSubCategoryID,
                                                                     sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, sInvoiceCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, 0, 0, dAmount, 0, 0,
                                                                     dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks);
                                                                items.Insert();

                                                                //////Update Customer Order
                                                                #region Update Customer Order
                                                                if (sInvoiceCode != "default")
                                                                {
                                                                    tbl_sasInvoice_Detail CoItem = tbl_sasInvoice_Detail.Select(0, sInvoiceCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, "default");
                                                                    if (chkUnitPricing.Checked)
                                                                        CoItem.QtySettle = CoItem.QtySettle + dQuantity;
                                                                    else
                                                                        CoItem.WeightSettle = CoItem.WeightSettle + dWeight;
                                                                    CoItem.Update();
                                                                    clsProcessMethods.SetSettle_InvoiceFrom_DeliveryOrder(sInvoiceCode, chkUnitPricing);
                                                                }
                                                                #endregion

                                                                ////Update Store Stock
                                                                #region Update Store Stock
                                                                string sTmpJobCode = "";
                                                                if (!clsConfig.bStoreStockWithJobID)
                                                                    sTmpJobCode = "default";
                                                                else
                                                                    sTmpJobCode = sJobCode;

                                                                //check whether single item stock enabled - qty
                                                                if (clsConfig.bSingleItemStockEnabled)
                                                                {
                                                                    if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
                                                                        clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
                                                                }

                                                                //update stock detail                                                           
                                                              //  if (clsConfig.bStockValidateQty_DeliveryOrder) //check whether stock enabled - qty   
                                                              //      clsHelpMethods_Local.Store_StockQuantityDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity);
                                                             //   if (clsConfig.bStockValidateWeight_DeliveryOrder) //check whether stock enabled - weight
                                                             //       clsHelpMethods_Local.Store_StockWeightDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dWeight);
                                                                #endregion
                                                            }
                                                        }
                                                        #endregion

                                                        //Attachments.Insert(iFormID, oldRecord.IDeliveryOrder_ID);
                                                        //Attachments.Remove(iFormID, oldRecord.IDeliveryOrder_ID);
                                                        //*************


                                                        #region Update Header
                                                        //tbl_sasInvDeliveryOrder dDetail = new tbl_sasInvDeliveryOrder(txtDeliveryOrderID.Text.Trim(), dtpDeliveryDate.Value, txtRemark.Text.Trim(),
                                                        //    txtAddress.Text.Trim(), clsSecurity.getServerDateTime(), dtpTimeOut.Value, dtpReceivedDate.Value, txtReceiptBy.Text.Trim(), txtCustomerID.Tag.ToString(),
                                                        //    txtInvoiceID.Tag.ToString(), txtDriverID.Tag.ToString(), txtVehicleID.Tag.ToString(),
                                                        //    txtAssistantID.Tag.ToString(), txtStoreID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, oldRecord.CancelReason_ID_DO,
                                                        //    txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                        //    decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate),
                                                        //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate),
                                                        //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                                        //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), decimal.Parse(txtSubTotal_Rec.Text.Trim()), decimal.Parse(txtGrandTotal_Rec.Text.Trim()), oldRecord.CreateUser_ID, clsSecurity.UserIDLoged,
                                                        //    oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID,
                                                        //    oldRecord.DateCreate, clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsDeleted,
                                                        //    oldRecord.IsLocked, oldRecord.IsSeattled, !chkUnitPricing.Checked, oldRecord.PrintCount, oldRecord.IsPriceEnabled, chkReverseCalculation.Checked);
                                                        //dDetail.Update();
                                                        #endregion

                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                #endregion
                                            }
                                            else  //insert records
                                            {
                                                #region Insert
                                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                                    txtDeliveryOrderID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                                //create order ref number
                                                if (glbOrderRefNo.Length <= 0 || glbOrderRefNo == "default")
                                                {
                                                    glbOrderRefNo = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                                                    tbl_zOrderRefNo orf = new tbl_zOrderRefNo(glbOrderRefNo, txtOrderRefNo.Text.Trim(), txtRouteID.Tag.ToString(), txtTownID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCustomerID.Tag.ToString(), false);
                                                    orf.Insert();
                                                }

                                                if (txtDeliveryOrderID.Text.Trim().Length > 0)
                                                {
                                                    #region Insert Header
                                                    //tbl_sasInvDeliveryOrder detail = new tbl_sasInvDeliveryOrder(txtDeliveryOrderID.Text.Trim(), dtpDeliveryDate.Value, txtRemark.Text.Trim(),
                                                    //    txtAddress.Text.Trim(), clsSecurity.getServerDateTime(), dtpTimeOut.Value, dtpReceivedDate.Value, txtReceiptBy.Text.Trim(), txtCustomerID.Tag.ToString(),
                                                    //    txtInvoiceID.Tag.ToString(), txtDriverID.Tag.ToString(), txtVehicleID.Tag.ToString(),
                                                    //    txtAssistantID.Tag.ToString(), txtStoreID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), glbOrderRefNo, "default",
                                                    //    txtCurrencyID.Tag.ToString(), decimal.Parse(txtCurrencyRate.Text.Trim()), decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()),
                                                    //    decimal.Parse(txtPercentageVat.Text.Trim()), decimal.Parse(txtPercentageOtherTax.Text.Trim()), decimal.Parse(txtSubTotal.Text.Trim()),
                                                    //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate),
                                                    //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods_Local.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                                                    //    clsHelpMethods_Local.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), decimal.Parse(txtSubTotal_Rec.Text.Trim()), decimal.Parse(txtGrandTotal_Rec.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(),
                                                    //     clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                    //    clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                                    //    bHasChecked, bHasApproved, false, false, false, false, !chkUnitPricing.Checked, 0, false, chkReverseCalculation.Checked);
                                                    //detail.Insert();
                                                    #endregion

                                                    #region Insert Detail
                                                    foreach (DataGridViewRow row in dgvDetail.Rows)
                                                    {
                                                        try
                                                        {
                                                            string sItemCode = "", sInvoiceCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";// sUom = "default",
                                                            decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dRecommendedUnitPrice = 0, dRecommendedWeightPrice = 0, dRecommendedAmount = 0;//dWidth = 0, dHeight = 0, dGauge = 0, dGusset = 0,

                                                            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                                            sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                                                            sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                                                            sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                                                            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                                            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                                            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                                            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                                            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                                            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                                            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                                            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                                            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                                            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                                                            dRecommendedUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtCustomerID.Tag.ToString());
                                                            dRecommendedWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemCode);
                                                            if (chkUnitPricing.Checked)
                                                                dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                                                            else
                                                                dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                                                            //Get Unit Price with Exchange rate to save
                                                            dUnitPrice = clsHelpMethods_Local.getSavePrice(dUnitPrice, txtCurrencyRate);
                                                            dWeightPrice = clsHelpMethods_Local.getSavePrice(dWeightPrice, txtCurrencyRate);
                                                            dAmount = clsHelpMethods_Local.getSavePrice(dAmount, txtCurrencyRate);

                                                            if (sItemCode.Trim().Length > 0)
                                                            {
                                                                tbl_sasInvDeliveryOrder_Detail items = new tbl_sasInvDeliveryOrder_Detail(row.Index, txtDeliveryOrderID.Text.Trim(), sItemCode, sItemSubCategoryID,
                                                                    sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, sInvoiceCode, dQuantity, 0, dWeight, 0, dUnitPrice, dWeightPrice, 0, 0, dAmount, 0, 0,
                                                                    dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks);
                                                                items.Insert();

                                                                //////Update Customer Order
                                                                #region Update Customer Order
                                                                if (sInvoiceCode != "default")
                                                                {
                                                                    tbl_sasInvoice_Detail CoItem = tbl_sasInvoice_Detail.Select(0, sInvoiceCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, "default");
                                                                    if (CoItem != null)
                                                                    {
                                                                        if (chkUnitPricing.Checked)
                                                                            CoItem.QtySettle = CoItem.QtySettle + dQuantity;
                                                                        else
                                                                            CoItem.WeightSettle = CoItem.WeightSettle + dWeight;
                                                                        CoItem.Update();
                                                                        clsProcessMethods.SetSettle_InvoiceFrom_DeliveryOrder(sInvoiceCode, chkUnitPricing);
                                                                    }
                                                                }
                                                                #endregion

                                                                ////Update Store Stock
                                                                #region Update Store Stock
                                                                string sTmpJobCode = "";
                                                                if (!clsConfig.bStoreStockWithJobID)
                                                                    sTmpJobCode = "default";
                                                                else
                                                                    sTmpJobCode = sJobCode;

                                                                //check whether single item stock enabled
                                                                if (clsConfig.bSingleItemStockEnabled)
                                                                {
                                                                    if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
                                                                        clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
                                                                }

                                                                //update stock detail                                                           
                                                              //  if (clsConfig.bStockValidateQty_DeliveryOrder) //check whether stock enabled - qty                                                                                                                           
                                                               //     clsHelpMethods_Local.Store_StockQuantityDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dQuantity);
                                                               // if (clsConfig.bStockValidateWeight_DeliveryOrder) //check whether stock enabled - weight                                                            
                                                               //     clsHelpMethods_Local.Store_StockWeightDecrease(txtStoreID.Tag.ToString(), sItemCode, sTmpJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, dWeight);
                                                                #endregion
                                                            }
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                                            SEACCException.Show(ex);
                                                        }
                                                    }
                                                    #endregion

                                                    Attachments.Insert(txtDeliveryOrderID.Text.ToString());
                                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Delivery Order " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                                #endregion
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            clsValidate.WriteErrorLog("", iFormID,ex);
                                            SEACCException.Show(ex);
                                        }
                                        finally
                                        {
                                            Cursor = Cursors.Default;
                                            tbl_sasInvDeliveryOrder oldRecord = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                                            if (oldRecord != null)
                                                FillDetails(txtDeliveryOrderID.Text.Trim());
                                        }
                                    }
                                }
                            }//Outstanding Validity
                        }//Stock Validity
                    }//weight/Quntity Settle validity
                }
            }
        }
        #endregion


        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
                {
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "", sReceiveUser = "", sDuplicateCopy = "";
                    bool bOkToPrint = false, bApprovalDone = false, bCheckingDone = false;
                    tbl_sasInvDeliveryOrder order = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                    if (order != null)
                    {

                        #region Validate Approval
                        if (clsConfig.bApprovalNeedToPrintDeliveryOrder)
                        {
                            if (order.IsApproved)
                                bApprovalDone = true;
                            else
                                MessageBox.Show("Please Approve the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            bApprovalDone = true;
                        #endregion

                        #region Validate Checking
                        if (clsConfig.bCheckingNeedToPrintDeliveryOrder)
                        {
                            if (order.IsChecked)
                                bCheckingDone = true;
                            else
                                MessageBox.Show("Please Check the Delivery Note Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            bCheckingDone = true;
                        #endregion

                        if (bApprovalDone && bCheckingDone)
                        {
                            if (order.PrintCount > 0) // if already printed before
                            {
                                sDuplicateCopy = "Duplicate Copy";
                                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                                {
                                    bOkToPrint = true;
                                    if (chkPrintOriginal.Checked)
                                        sDuplicateCopy = "";
                                }
                                else
                                {
                                    frmSetApproved login = new frmSetApproved();
                                    login.iFormID = iFormID;
                                    login.ShowDialog();
                                    if (frmSetApproved.bChecked)
                                    {
                                        bOkToPrint = true;
                                        if (chkPrintOriginal.Checked)
                                            sDuplicateCopy = "";
                                    }
                                }
                            }
                            else
                                bOkToPrint = true;

                            sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                            if (order.CheckedUser_ID != "default")
                                sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                            if (order.ApprovedUser_ID != "default")
                                sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                            if (order.ReceiptBy != "default")
                                sReceiveUser = "[ " + order.ReceiptBy + " ]";

                            #region Print The Doc
                            if (bOkToPrint)
                            {
                                order.PrintCount++;
                                order.Update();

                                Cursor = Cursors.WaitCursor;
                                string s_Path = "", sReportTitle = "Delivery Note", sFormula = "";
                                if (txtDeliveryOrderID.TextLength > 0)
                                    sFormula = "{vw_rpt_sasInvDeliveryOrder.iDeliveryOrder_ID} = '" + txtDeliveryOrderID.Text.Trim() + "'";

                                ReportDocument RD = new ReportDocument();
                                s_Path = Application.StartupPath.Replace("\\Mini ERP\\bin\\Debug", "\\ZION.ERP.Reports");

                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WOD.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryOrder_WSC.rpt";
                                else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvDeliveryOrder_WSC.rpt";
                                else
                                    s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasInvDeliveryOrder_WSC.rpt";


                                frm_ReportViewer viewer = new frm_ReportViewer();
                                RD.Load(s_Path); Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                                //    clsSecurity.LogonServer(ref RD);
                                RD.Refresh();

                                if ((clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString()))
                                    RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                                RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                                RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                                RD.DataDefinition.FormulaFields["DuplicateCopy"].Text = clsCommon.fncsetstring(sDuplicateCopy);
                                RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(clsGenaralName.getName_User(order.CreateUser_ID));
                                RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                                RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                                RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                                RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                                RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                                RD.DataDefinition.FormulaFields["CompanyEmail"].Text = clsCommon.fncsetstring(clsCommon.getCompanyEmail());
                                RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                                RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                                RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(order.Customer_ID));
                                RD.DataDefinition.FormulaFields["CompanyRegNo"].Text = clsCommon.fncsetstring(clsCommon.getCompanyBusinessRegisterNo());

                                if (clsConfig.bDirectPrint_NP_DeliveryOrder) //Direct Print
                                {
                                    RD.DataDefinition.RecordSelectionFormula = sFormula;
                                    clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_DeliveryOrder), ref RD);
                                    RD.PrintToPrinter(1, false, 0, 0);

                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DucumentPrinted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else //View And Print
                                {
                                    viewer.crystalReportViewer1.ReportSource = RD;
                                    viewer.crystalReportViewer1.SelectionFormula = sFormula;
                                    viewer.crystalReportViewer1.Visible = true;
                                    viewer.crystalReportViewer1.DisplayToolbar = true;
                                    viewer.crystalReportViewer1.CloseView(false);
                                    viewer.WindowState = FormWindowState.Maximized;
                                    viewer.ShowDialog();
                                }

                                RD.Close();
                                RD.Dispose();
                            }
                            #endregion
                        }
                    }
                }
                else
                    MessageBox.Show("Please Select the Delivery Note To Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Add Quotation
        private void btnAddQuotation_Click(object sender, EventArgs e)
        {
            if (txtQuotationID.Tag != null && txtQuotationID.Tag.ToString().Length > 0)
            {
                tbl_sasQuotation detail = tbl_sasQuotation.Select(txtQuotationID.Tag.ToString());
                if (detail != null)
                {
                    //add order ref detail
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
                }
            }
        }
        #endregion

        #region Btn Add Customer Order
        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                if (detail != null)
                {
                    //add order ref detail
                    glbOrderRefNo = detail.OrderRefNo_ID;
                    txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                    txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                    clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                    //add currency detail
                    FillDetailsCurrency(detail.Currency_ID);
                    txtCurrencyRate.Text = detail.CurrencyRate.ToString();

                    //add item details
                    RefreshGridByInvoiceID(detail.Invoice_ID);
                }
            }
        } 
        #endregion

        #region Btn Add JobCode
        private void btnAddJobCode_Click(object sender, EventArgs e)
        {
            if (txtJobCode.Tag != null && txtJobCode.Tag.ToString().Length > 0)
            {
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(txtJobCode.Tag.ToString());
                //if (detail != null)
                //{
                //    RefreshGridByJobIDID(detail.ProductionJob_ID);
                //}
            }
        }
        #endregion

        #region Btn Add Item
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(txtItemID.Tag.ToString().Trim());
                if (detail != null)
                {
                    clsCommon.ValidateForeignKey(ref txtItemSubCategory);
                    clsCommon.ValidateForeignKey(ref txtItemSerialNo, "0");
                    RefreshGridByItemID(detail.Item_ID, txtItemSubCategory.Tag.ToString(), txtItemSubCategory.Text.Trim(), txtItemSerialNo.Tag.ToString(), txtItemSerialNo.Text.Trim());
                }
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
                   MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption()+" ["+frm.iFormID+"]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    frm.MdiParent = this.MdiParent;
                    frm.Show();
                }
            }
        }
        #endregion

        #region Btn DCP
        private void btnDCP_Click(object sender, EventArgs e)
        {
            if (txtDeliveryOrderID.TextLength > 0 && txtDeliveryOrderID.Text != "<Auto Generate>")
            {
                //set the flag and enble the id
                IsUpdate = false;               
                clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
                clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
                clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
                clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);

                txtPreparedBy.Tag = null;
                txtCheckedBy.Tag = null;
                txtApprovedBy.Tag = null;
                txtOrderRefNo.Tag = null;

                txtApprovedBy.Clear();
                txtCheckedBy.Clear();
                txtPreparedBy.Clear();
                txtOrderRefNo.Clear();

                bHasApproved = false;
                bHasChecked = false;
                chkSettings.Checked = true;
                glbOrderRefNo = "";

                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                    txtDeliveryOrderID.Text = "<Auto Generate>";
                else
                    txtDeliveryOrderID.Clear();
                if (txtDeliveryOrderID.Enabled)
                {
                    txtDeliveryOrderID.SelectAll();
                    txtDeliveryOrderID.Focus();
                }             
            }
        } 
        #endregion

        #region Btn Checking
        private void btnChecking_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
            {
                bHasChecked = true;
                //glbCheckedDate = clsSecurity.getServerDateTime();
                dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                txtCheckedBy.Text = clsSecurity.UserNameLoged;
                txtCheckedBy.Tag = clsSecurity.UserIDLoged;
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                if (IsUpdate)
                {
                    tbl_sasInvDeliveryOrder objDO = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                    if (objDO != null)
                    {
                        objDO.IsChecked = true;
                        objDO.DateChecked = clsSecurity.getServerDateTime();
                        objDO.CheckedUser_ID = clsSecurity.UserIDLoged;
                        objDO.Update();
                    }
                }
            }
            else
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion

        #region Btn Approval
        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
            {
                bHasApproved = true;
               // glbApprovedDate = clsSecurity.getServerDateTime();
                dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                txtApprovedBy.Text = clsSecurity.UserNameLoged;
                txtApprovedBy.Tag = clsSecurity.UserIDLoged;
                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);

                if (IsUpdate)
                {
                    tbl_sasInvDeliveryOrder objDO = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                    if (objDO != null)
                    {
                        objDO.IsApproved = true;
                        objDO.DateChecked = clsSecurity.getServerDateTime();
                        objDO.ApprovedUser_ID = clsSecurity.UserIDLoged;
                        objDO.Update();
                    }
                }
            }
            else
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);            
            clsHelpMethods_Local.FormatGrid_Sales(dgvDetail);

            //price
            if (clsConfig.bEnableGridLock_Price_DO)            
                dgvDetail.Columns["UnitPrice"].ReadOnly = true;            
            else            
                dgvDetail.Columns["UnitPrice"].ReadOnly = false;            
            //qty
            if (clsConfig.bEnableGridLock_Quantity_DO)            
                dgvDetail.Columns["Quantity"].ReadOnly = true;            
            else            
                dgvDetail.Columns["Quantity"].ReadOnly = false;
            
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
        private void CusDataGirdViewFormatForAdjustmnetWeight(DataGridView dgv, bool bWeightCalculation, string sWeight, string sQty)
        {
            //if (bWeightCalculation)
            //{
            //    dgv.Columns[sWeight].Visible = true;
            //    dgv.Columns[sQty].Visible = false;

            //}
            //else if (!bWeightCalculation)
            //{
            //    dgv.Columns[sWeight].Visible = false;
            //    dgv.Columns[sQty].Visible = true;
            //}
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;           
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, true);
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblStore, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);

            txtDeliveryOrderID.Tag = null;
            txtCustomerID.Tag = null;
            txtInvoiceID.Tag = null;
            txtQuotationID.Tag = null;
            txtDriverID.Tag = null;
            txtAssistantID.Tag = null;
            txtVehicleID.Tag = null;
            txtPreparedBy.Tag = null;
            txtCheckedBy.Tag = null;
            txtApprovedBy.Tag = null;
            txtJobCode.Tag = null;
            txtStoreID.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtSalesExecutiveID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtRouteID.Tag = null;
            txtTownID.Tag = null;

            txtOrderRefNo.Clear();
            glbOrderRefNo = "";
            txtRouteID.Clear();
            txtTownID.Clear();
            txtSalesExecutiveID.Clear();
            txtStoreID.Clear();
            txtItemID.Clear();
            txtCustomerID.Clear();
            txtInvoiceID.Clear();
            txtQuotationID.Clear();
            txtDriverID.Clear();
            txtDriverNIC.Clear();
            txtJobCode.Clear();
            txtAssistantID.Clear();
            txtVehicleID.Clear();
            txtAddress.Clear();
            txtReceiptBy.Clear();
            txtRemark.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();
            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;          
            chkShowSettle.Checked = false;
            chkPrintOriginal.Checked = false;
            FillDetailsCurrency(clsConfig.sLocalCurrencyCode);
                        
            dtpDateOut.Value = clsSecurity.getServerDateTime();
            dtpDeliveryDate.Value = clsSecurity.getServerDateTime();
            dtpReceivedDate.Value = clsSecurity.getServerDateTime();
         
            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            txtPreparedBy.Clear();
            txtDiscount.Text = "0";
            txtGrandTotal.Text = "0.00";
            txtNBT.Text = "0";
            txtOtherTax.Text = "0";
            txtPercentageDiscount.Text = "0";
            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
            txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
            txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());
            txtSubTotal.Text = "0";
            txtVat.Text = "0";           

            bHasApproved = false;
            bHasChecked = false;
            chkDiscount.Checked = false;
            chkNBT.Checked = false;
            chkOtherTax.Checked = false;
            chkVat.Checked = false;

            dgvDetail.Rows.Clear();
            DisableMoneyControls();

            chkVat.Enabled = true;
            chkNBT.Enabled = true;
            isDonNbtReversCalculation = false;
            isDonVatReversCalculation = false;
            chkReverseCalculation.Enabled = true;
            chkSettings.Checked = true;
            chkSettings2.Checked = true;

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDeliveryOrderID.Text = "<Auto Generate>";
            else
                txtDeliveryOrderID.Clear();
            if (txtDeliveryOrderID.Enabled)
            {
                txtDeliveryOrderID.SelectAll();
                txtDeliveryOrderID.Focus();
            }

            Attachments.Clear();
        }
        #endregion



        #region Refresh Grid
        private void RefreshGrid(string sDeliveryOrderID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();

                List<tbl_sasInvDeliveryOrder_Detail> details = tbl_sasInvDeliveryOrder_Detail.SelectAllByIDeliveryOrder_ID(sDeliveryOrderID);
                foreach (tbl_sasInvDeliveryOrder_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;

                        Fill_Datagrid(iRow, detail.Item_ID, detail.Invoice_ID, detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, detail.Weight, detail.Qty,"O", detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            
        }       
        private void RefreshGridByInvoiceID(string sInvoiceID)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_sasInvoice_Detail> details = tbl_sasInvoice_Detail.SelectAllByInvoice_ID(sInvoiceID);
                foreach (tbl_sasInvoice_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        decimal dExRate = 0;
                        if (txtCurrencyRate.Text.Trim().Length > 0)
                            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        bool bHasSettledBefore = false;
                        if (detail.QtySettle > 0 || detail.WeightSettle > 0)
                            bHasSettledBefore = true;

                        Fill_Datagrid(iRow, detail.Item_ID, detail.Invoice_ID, detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle), (detail.Qty - detail.QtySettle),"N", 
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }               
                CalcualteSubTotal();
                CalcualteGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByQuotationID(string sQuotaion)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                List<tbl_sasQuotation_Detail> details = tbl_sasQuotation_Detail.SelectAllByQuotation_ID(sQuotaion);
                foreach (tbl_sasQuotation_Detail detail in details)
                {
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

                        Fill_Datagrid(iRow, detail.Item_ID, "default", detail.UnitPrice, detail.WeightPrice, detail.TatalAmount,
                            item.Width, item.Height, item.Thickness, item.Gusset, (detail.Weight - detail.WeightSettle_CustomerOrder), (detail.Qty - detail.QtySettle_CustomerOrder), "N",
                            detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, detail.Remark, bHasSettledBefore, dExRate);
                    }
                }               
                CalcualteSubTotal();
                CalcualteGrandTotal();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByJobIDID(string sJobID)
        {
            try
            {
                int iRow;
                //dgvDetail.Rows.Clear();
                //tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sJobID);
                //if (detail != null)
                //{
                //    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (item != null)
                //    {
                //        decimal dExRate = 0;
                //        if (txtCurrencyRate.Text.Trim().Length > 0)
                //            dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                //        dgvDetail.Rows.Add();
                //        iRow = dgvDetail.Rows.Count - 1;
                //        decimal dUnitPrice = 0;
                //        decimal dAmount = dUnitPrice * detail.Weight;
                //        bool bHasSettledBefore = false;

                //        Fill_Datagrid(iRow, detail.Item_ID, "default", dUnitPrice, 0, dAmount, item.Width, item.Height, item.Thickness,
                //            item.Gusset, detail.Weight, detail.Qty, "N", "default", "default", "0", "0", item.Description, bHasSettledBefore, dExRate);
                //        CalcualteSubTotal();
                //        CalcualteGrandTotal();
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridByItemID(string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sSerialNo, string sSerialNo2)
        {
            try
            {
                int iRow;
                string sCustomerID = txtCustomerID.Tag != null ? txtCustomerID.Tag.ToString().Trim() : "";
                //dgvDetail.Rows.Clear();
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    decimal dExRate = 0;
                    if (txtCurrencyRate.Text.Trim().Length > 0)
                        dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    decimal dQty = 1, dAmount = 0;// detail.SellingPrice1 * dQty;
                    decimal dWeight = clsHelpMethods_Local.GetWeightByItemID(detail.Item_ID, 1);
                    decimal dUnitPrice = clsProcessMethods.GetRecommendedUnitPrice_Advance(sItemID, sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, sCustomerID);
                    decimal dWeightPrice = clsProcessMethods.GetRecommendedWeightPrice(sItemID);
                    bool bHasSettledBefore = true;

                    Fill_Datagrid(iRow, detail.Item_ID, "default", dUnitPrice, dWeightPrice,
                        dAmount, detail.Width, detail.Height, detail.Thickness, detail.Gusset, dWeight, dQty, "N", sItemSubCategoryID, sItemSubCategoryID2, sSerialNo, sSerialNo2, detail.Description, bHasSettledBefore, dExRate);

                }
                CalcualteSubTotal();
                CalcualteGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    tbl_sasInvDeliveryOrder detail = tbl_sasInvDeliveryOrder.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryOrderID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomerID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblDeliveryOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblStore, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtStoreID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtSalesExecutiveID.Tag = order.Employee_ID;
                            txtRouteID.Tag = order.Route_ID;
                            txtTownID.Tag = order.Town_ID;

                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                            txtSalesExecutiveID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                       //     txtRouteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(order.Route_ID));
                            txtTownID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(order.Town_ID));
                        }

                        //asign values
                        txtCustomerID.Tag = detail.Customer_ID;
                        txtInvoiceID.Tag = detail.Invoice_ID;
                        //txtQuotationID.Tag = detail.Quotation_ID;
                       // txtJobCode.Tag = detail.Job_ID;
                        txtDriverID.Tag = detail.Driver_ID;
                        txtAssistantID.Tag = detail.Assitant_ID;
                        txtVehicleID.Tag = detail.Vehicle_ID;
                        txtStoreID.Tag = detail.Store_ID;
                        txtDeliveryOrderID.Tag = detail.IDeliveryOrder_ID;                        

                        txtInvoiceID.Text = clsCommon.GetForeignKeyValue(detail.Invoice_ID);
                       // txtQuotationID.Text = clsCommon.GetForeignKeyValue(detail.Quotation_ID);
                       // txtJobCode.Text = clsCommon.GetForeignKeyValue(detail.Job_ID);
                        txtCustomerID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        txtDriverID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Driver(detail.Driver_ID));
                        txtDriverNIC.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_DriverNIC(detail.Driver_ID));
                        txtAssistantID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Assistant(detail.Assitant_ID));
                        txtVehicleID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Vahicle(detail.Vehicle_ID));                        
                        txtStoreID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));

                        txtDeliveryOrderID.Text = detail.IDeliveryOrder_ID;
                        txtRemark.Text = detail.Remark;                        
                        dtpDateOut.Value = detail.DateOut;
                        dtpTimeOut.Value = detail.DateOut;
                        dtpDeliveryDate.Value = detail.IDeliveryOrderDate;
                        dtpReceivedDate.Value = detail.CustomerDeliveryDate;
                        txtAddress.Text = detail.DeliveryAddress;
                        txtRemark.Text = detail.Remark;                        
                        txtReceiptBy.Text = detail.ReceiptBy;
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkReverseCalculation.Checked = detail.IsTaxReverseCalulation;
                        FillDetailsCurrency(detail.Currency_ID);
                        txtCurrencyRate.Text = detail.CurrencyRate.ToString();
                        chkSettings.Checked = false;
                        chkSettings2.Checked = false;
                        CusDataGirdViewFormatForCalucation(dgvDetail, !chkUnitPricing.Checked);
                        glbOrderRefNo = detail.OrderRefNo_ID;

                        //Tax Details
                        if (detail.DiscountTotal > 0)
                            chkDiscount.Checked = true;
                        else
                            chkDiscount.Checked = false;
                        if (detail.NbtTotal > 0)
                            chkNBT.Checked = true;
                        else
                            chkNBT.Checked = false;
                        if (detail.VatTotal > 0)
                            chkVat.Checked = true;
                        else
                            chkVat.Checked = false;
                        if (detail.OtherTaxTotal > 0)
                            chkOtherTax.Checked = true;
                        else
                            chkOtherTax.Checked = false;
                        txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                        txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                        txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                        txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                        txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                        txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                        txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
                        txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                        txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));
                        
                        
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));
                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                      //      glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            dtpTimeApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                            txtApprovedBy.Tag = detail.ApprovedUser_ID;
                            txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            //glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                            txtCheckedBy.Tag = detail.CheckedUser_ID;
                            txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        }

                        
                        
                        //fill item details
                        RefreshGrid(detail.IDeliveryOrder_ID);
                       // FillDetailsCustomer(detail.Customer_ID);
                      //  clsHelpMethods_Local.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                       //   txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);
                        
                        
                        Attachments.FillAttachments( sID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                    txtAddress.Text = customer.AddressDelivery;

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
                }

                List<tbl_genCustomerMaster_Route> cusRoutes = tbl_genCustomerMaster_Route.SelectAllByCustomer_ID(sCustomerID);
                foreach (tbl_genCustomerMaster_Route cusRoute in cusRoutes)
                {
                    if (cusRoute.Route_ID != "default")
                    {
                        txtRouteID.Tag = cusRoute.Route_ID;
                    //    txtRouteID.Text = clsGenaralName.getName_Route(cusRoute.Route_ID);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Tax Detail By InvoiceID
        private void FillTaxDetailByInvoiceID(string sInvoiceID)
        {
            tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoiceID);

            if (detail != null)
            {
                txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate));
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate));
                txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate));
                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate));
                txtPercentageDiscount.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.DiscountPercentage);
                txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.NbtPercentage);
                txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.OtherTaxPercentage);
                txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.VatPercentage);
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.SubTotal, detail.CurrencyRate));
                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep(clsHelpMethods_Local.getDisplayPrice(detail.VatTotal, detail.CurrencyRate));

                if (detail.DiscountTotal > 0)
                    chkDiscount.Checked = true;
                else
                    chkDiscount.Checked = false;
                if (detail.NbtTotal > 0)
                    chkNBT.Checked = true;
                else
                    chkNBT.Checked = false;
                if (detail.VatTotal > 0)
                    chkVat.Checked = true;
                else
                    chkVat.Checked = false;
                if (detail.OtherTaxTotal > 0)
                    chkOtherTax.Checked = true;
                else
                    chkOtherTax.Checked = false;

                txtRemark.Text = detail.Remark;
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try{
            if (txtCustomerID.Text.Trim().Length <= 0)
            {
                strMessage += "\n" + "Customer Name ";
                bStatus = false;
            }
            if (txtStoreID.Tag == null)
            {
                strMessage += "\n" + "Store Name ";
                bStatus = false;
            }
            if (txtOrderRefNo.TextLength == 0)
            {
                strMessage += "\n" + "Order Ref No ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
    
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            return bStatus;
        }

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
            string sItemCode = "", sInvoiceCode = "", strMessage = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dQuantity = 0, dWeight = 0;

            if ((!clsAutocode.getItemExceed(ConfigItemExceedLock.DeliveryOrder)) && (!IsUpdate))
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "InvoiceCode", row.Index, "default");
                        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                        tbl_sasInvoice_Detail CoDetail = tbl_sasInvoice_Detail.Select(0,sInvoiceCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, "default");
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
                                    if (CoDetail.Qty < (CoDetail.QtySettle + dQuantity))
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
                                    if (CoDetail.Weight < (CoDetail.WeightSettle + dWeight))
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
                        clsValidate.WriteErrorLog("", iFormID,ex);
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

        private bool CheckStockValidity()
        {
            string strMessage = "", sOriginalItemCode = "", sItemCode = "", sItemStatus = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
            decimal dWeight = 0;
            decimal dQty = 0;
            bool bStatus = true;

            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                #region Stock Validation
                sOriginalItemCode = sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                sItemStatus = clsValidate.ValidateGridValue(dgvDetail, "ItemStatus", row.Index, "");
                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                if (!clsConfig.bStoreStockWithJobID)
                    sJobCode = "default";

                //check whether single item stock enabled - qty
                if (clsConfig.bSingleItemStockEnabled)
                {
                    if (!clsHelpMethods_Local.IsItemRawMaterial(sItemCode))
                        clsHelpMethods_Local.AssignSingleStockItemDetail(ref sItemCode, ref sItemSubCategoryID, ref sItemSubCategoryID2, ref sItemSerialNo, ref sItemSerialNo2);
                }

                tbl_genStore_Stock stock = tbl_genStore_Stock.Select(txtStoreID.Tag.ToString(), sItemCode, sJobCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                if (stock != null)
                {
                    if (sItemStatus.ToLower() == "o")//if the item is old and check stock for more than one time
                    {
                        // This place use to valiedate the old stock
                        #region Old Items Stock Validation
                        List<tbl_sasInvDeliveryOrder_Detail> oldDoDetails = tbl_sasInvDeliveryOrder_Detail.SelectAllByIDeliveryOrder_ID(txtDeliveryOrderID.Text.Trim());
                        foreach (tbl_sasInvDeliveryOrder_Detail oldDoDetail in oldDoDetails)
                        {
                            if (oldDoDetail.Item_ID == sOriginalItemCode)
                            {
                                decimal dVeriance = 0;
                                if (clsConfig.bStockValidateQty_DeliveryOrder)
                                {
                                    #region Old Items Quantity Validation
                                    if (oldDoDetail.Qty < dQty)
                                        dVeriance = dQty - oldDoDetail.Qty;

                                    if (stock.Qty < dVeriance)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                    #endregion
                                }
                                if (clsConfig.bStockValidateWeight_DeliveryOrder)
                                {
                                    ////weight part
                                    #region Old Items Weight Validation
                                    if (oldDoDetail.Weight < dWeight)
                                        dVeriance = dWeight - oldDoDetail.Weight;

                                    if (stock.Weight < dVeriance)
                                    {
                                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                                        bStatus = false;
                                    }
                                    #endregion
                                }

                            }
                        }
                        #endregion
                    }
                    else//first time added item ant have to check stock
                    {
                        #region New Item Stock Validation
                        #region New Item Weight Validation
                        if (stock.Weight < dWeight && clsConfig.bStockValidateWeight_DeliveryOrder)
                        {
                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + " Required Weight Is Not Availabe As IT Is In  " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                            bStatus = false;
                        }
                        #endregion

                        #region New Item Quantity Validation
                        if (stock.Qty < dQty && clsConfig.bStockValidateQty_DeliveryOrder)
                        {
                            strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Required Quantity Is Not Availabe As IT Is In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + "\n";
                            bStatus = false;
                        }
                        #endregion
                        #endregion
                    }
                }
                else
                {
                    if (clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder)
                    {
                        //No stock in selected store
                        strMessage += "Item: " + clsGenaralName.getName_Item(sItemCode) + "  Is Not Available In " + clsGenaralName.getName_Store(txtStoreID.Tag.ToString()) + " Stock\n";
                        bStatus = false;
                    }
                }
                #endregion
            }
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckOutstandingValidity()
        {
            bool bOk = true;
            decimal dCreditBalance = 0, dAmountDue = 0;
            try
            {
                if (clsConfig.bCreditBalanceDeliveryOrder_Message) //security 1 - Message
                {
                    if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Trim().Length > 0)
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

            return bOk;
        }      
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtInvoiceID);
            clsCommon.ValidateForeignKey(ref txtQuotationID);
            clsCommon.ValidateForeignKey(ref txtTownID);
            clsCommon.ValidateForeignKey(ref txtRouteID);
            clsCommon.ValidateForeignKey(ref txtJobCode);
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);            
            clsCommon.ValidateForeignKey(ref txtSalesExecutiveID);

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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
            if (txtStoreID.Tag == null)
            {
                rtn = false;
                MessageBox.Show("Please Select the Store Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStoreID.Focus();
            }
            return rtn;
        }
        #endregion


        #region Events ValueChanged
        private void dtpDateIn_ValueChanged(object sender, EventArgs e)
        {
           // dtpTimeIn.Value = dtpDateIn.Value;
        }

        private void dtpDateOut_ValueChanged(object sender, EventArgs e)
        {
            dtpTimeOut.Value = dtpDateOut.Value;
        } 
        #endregion

        #region Events KeyDown
        private void txtDeliveryOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DeliveryOrderID();
            }
        }
        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && CheckValiditeCustomerAndStore())
            {
                if ((clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder) && !clsConfig.bSingleItemStockEnabled)
                {
                    clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, txtStoreID.Tag.ToString(), "", "");
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else
                {
                    clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(sender, new EventArgs());
                }
            }
            else
            {
                clsHelpMethods_Local.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
                if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                    btnAddItem_Click(sender, new EventArgs());
            }
        }
        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)                
                    clsSearch.Search_TransactionProductionJobRegisterByCustomerID_Use(ref txtJobCode, txtCustomerID.Tag.ToString());                
                else
                    clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, false, true);
            }
        }
        private void txtCustomerOrderID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_InvoiceID(sender);
            }
        }
        private void txtQuotationID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_QuotationID();
            }
        }
        private void txtVehicleID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_VehicleID();
            }
        }
        private void txtDriverID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_DriverID();
            }
        }
        private void txtAssistantID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_AssistantID();
            }
        }
        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }
        private void frm_sasCustomerDeliveryOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
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
            {
                Search_SalesExecutiveID();
            }
        }
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterRoute(ref txtRouteID);
            }
        }
        private void txtTownID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterTown(ref txtTownID);
            }
        }
        private void txtCurrencyID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
                Search_Currency();
        }
        #endregion

        #region Events Double Click
        private void txtDeliveryOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_DeliveryOrderID();
        }
        private void txtJobCode_DoubleClick(object sender, EventArgs e)
        {
            if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                clsSearch.Search_TransactionProductionJobRegisterByCustomerID_Use(ref txtJobCode, txtCustomerID.Tag.ToString());            
            else
                clsSearch.Search_TransactionProductionJobRegister_Use(ref txtJobCode, false, true);
        }
        private void txtCustomerID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtCustomerOrderID_DoubleClick(object sender, EventArgs e)
        {
            Search_InvoiceID(sender);
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
            if (CheckValiditeCustomerAndStore())
            {
                if ((clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder) && !clsConfig.bSingleItemStockEnabled)
                {
                    clsHelpMethods_Local.SearchItemAdvanceStock(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, txtStoreID.Tag.ToString(), "", "");
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(btnAddItem, new EventArgs());
                }
                else
                {
                    clsHelpMethods_Local.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
                    if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                        btnAddItem_Click(sender, new EventArgs());
                }
            }
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
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterRoute(ref txtRouteID);
        }
        private void txtCurrencyID_DoubleClick(object sender, EventArgs e)
        {
            Search_Currency();
        }
        #endregion

        #region Events KeyUp
        private void txtPercentageOtherTax_KeyUp(object sender, KeyEventArgs e)
        {
            decimal dOtherTaxPesentage = 0;
            if (clsCommon.isCurrency(txtPercentageOtherTax.Text.Trim()))
            {
                dOtherTaxPesentage = decimal.Parse(txtPercentageOtherTax.Text.Trim());
                if (dOtherTaxPesentage > 0)
                {
                    CalculateOtherTax();
                    CalcualteGrandTotal();
                }
                else
                {
                    txtPercentageOtherTax.Text = "0";
                    txtOtherTax.Text = "0";
                }
            }
            else
            {
                txtPercentageOtherTax.Text = "0";
                txtOtherTax.Text = "0";
            }
            CalculateOtherTax();
            chkVat_CheckedChanged(chkVat, new EventArgs());
            CalcualteGrandTotal();

        }
        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            decimal dDiscount = 0;
            if (clsCommon.isCurrency(txtDiscount.Text.Trim()))
            {
                dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                if (dDiscount > 0)
                {
                    CalculateDiscount();
                    CalcualteGrandTotal();
                }
                else
                {
                    txtPercentageDiscount.Text = "0";
                    txtDiscount.Text = "0";
                }
            }
            else
            {
                txtPercentageDiscount.Text = "0";
                txtOtherTax.Text = "0";
            }
            CalculateDiscount();
            CalcualteGrandTotal();
        }
        private void txtPercentageDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            decimal dDiscountPesentage = 0;
            if (clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
            {
                dDiscountPesentage = decimal.Parse(txtPercentageDiscount.Text.Trim());
                if (dDiscountPesentage > 0)
                {
                    CalculateDiscount();
                    CalcualteGrandTotal();
                }
                else
                {
                    txtPercentageDiscount.Text = "0";
                    txtDiscount.Text = "0";
                }
            }
            else
            {
                txtPercentageDiscount.Text = "0";
                txtOtherTax.Text = "0";
            }
        }
        #endregion

        #region Events CheckedChanged
        private void chkDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDiscount.Checked)
            {
                txtPercentageDiscount.Enabled = true;
                txtDiscount.Enabled = true;
                CalculateDiscount();
                CalcualteGrandTotal();
            }
            else
            {
                txtPercentageDiscount.Enabled = false;
                txtDiscount.Enabled = false;
                txtPercentageDiscount.Text = "0";
                txtDiscount.Text = "0";
                CalcualteGrandTotal();
            }
        }

        private void chkNBT_CheckedChanged(object sender, EventArgs e)
        {
            CalculateNBT();
            CalcualteGrandTotal();
            if (!chkReverseCalculation.Checked)
            {
                if (chkNBT.Checked)
                    chkVat.Checked = true;
            }
            chkVat_CheckedChanged(chkVat, new EventArgs());
        }

        private void chkVat_CheckedChanged(object sender, EventArgs e)
        {
            CalculateVAT();
            CalcualteGrandTotal();
            if (!chkReverseCalculation.Checked)
            {
                if (!chkVat.Checked)
                    chkNBT.Checked = false;
            }
        }

        private void chkOtherTax_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOtherTax.Checked)
            {
                txtPercentageOtherTax.Enabled = true;
                chkVat_CheckedChanged(chkVat, new EventArgs());
                CalculateOtherTax();
                CalcualteGrandTotal();
            }
            else
            {
                txtPercentageOtherTax.Enabled = false;
                txtPercentageOtherTax.Text = clsCommon.getPesentageOtherTax().ToString();
                chkVat_CheckedChanged(chkVat, new EventArgs());
                txtOtherTax.Text = "0";
                CalcualteGrandTotal();
            }
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
                chkReverseCalculation.Enabled = false;
        }

        private void chkSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSettings.Checked)
            {
                xFlow.SendToBack();
                chkSettings.Image = Digiteq.Properties.Resources.security;
            }
            else
            {
                xSetting.SendToBack();
                chkSettings.Image = Digiteq.Properties.Resources.settings;
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
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.SalesGrid_CellDoubleClick(sender, e, dgvDetail);
            CalcualteSubTotal();
            CalcualteGrandTotal();
        }

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            clsEvent.SalesGrid_CellEndEdit(sender, e, dgvDetail, !chkUnitPricing.Checked);
            CalcualteSubTotal();
            CalcualteGrandTotal();
        }

        private void dgvDetail_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            clsEvent.SalesGrid_CellParsing(sender, e,dgvDetail);
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

        #region Events Mouseclick
        //private void txtFlowInquiry_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_Inquiry(sender, e, glbOrderRefNo);
        //}

        //private void txtFlowQuotaion_MouseClick(object sender, MouseEventArgs e)
        //{

        //}
        //private void txtFlowSalesReturned_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_SalesReturned(sender, e, glbOrderRefNo);
        //}
        //private void txtFlowCustomerOrder_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_CustomerOrder(sender, e, glbOrderRefNo);
        //}

        //private void txtFlowProductionJob_MouseClick(object sender, MouseEventArgs e)
        //{

        //}

        //private void txtFlowDeliveryOrder_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_DeliveryOrder(sender, e, glbOrderRefNo);
        //}

        //private void txtFlowInvoice_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_Invoice(sender, e, glbOrderRefNo);
        //}

        //private void txtFlowReceipt_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (glbOrderRefNo.Length > 0)
        //        clsHelpMethods_Local.MouseClick_Receipt(sender, e, glbOrderRefNo);
        //}
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
                        //veheicle name - check with the database 
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion



        #region Search Methods
        private void Search_DeliveryOrderID()
        {            
            clsSearch.Search_TransactionInvDeliveryOrder_Direct(ref txtDeliveryOrderID, chkShowSettle.Checked);
            if (txtDeliveryOrderID.Tag != null && txtDeliveryOrderID.Tag.ToString().Trim().Length > 0)                            
                FillDetails(txtDeliveryOrderID.Tag.ToString());            
        }
        private void Search_QuotationID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.passValue_QuotationByCustomerID(txtCustomerID.Tag.ToString());
                    frmhelpsearch.ShowDialog();

                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        txtQuotationID.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        txtQuotationID.Tag = frmSearchTransaction.s_SearchID;
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_InvoiceID(object objSender)
        {
            try
            {
                bool hasOrderRefNo = false;
                if (glbOrderRefNo.Length > 0)
                    hasOrderRefNo = true;

                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                    clsSearch.Search_TransactionInvoiceByCustomerID_Use(ref txtInvoiceID, txtCustomerID.Tag.ToString(), hasOrderRefNo, glbOrderRefNo, false, false, false,false, true,"");
                else
                    clsSearch.Search_TransactionInvoice_Use(ref txtInvoiceID, hasOrderRefNo, glbOrderRefNo, false, false, false, true);

                if (txtInvoiceID.Tag != null && txtInvoiceID.Tag.ToString().Length > 0)
                {
                    tbl_sasInvoice detail = tbl_sasInvoice.Select(txtInvoiceID.Tag.ToString());
                    if (detail != null)
                    {
                        FillDetailsCustomer(detail.Customer_ID);
                        FillTaxDetailByInvoiceID(txtInvoiceID.Tag.ToString());
                        btnAddInvoice_Click(objSender, new EventArgs());
                    }
                }               
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    ClearFields();
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomerID.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomerID.Tag = frmSearchMaster.s_SearchID;
                        FillDetailsCustomer(frmSearchMaster.s_SearchID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ItemID()
        {
            try
            {                
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.Search_ItemMaster(ref txtItemID, null, null, null, false);
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_ApprovedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryDate.Value.Date))
                {
                    frmSetApproved login = new frmSetApproved();
                    login.iFormID = iFormID;
                    login.ShowDialog();
                    if (frmSetApproved.bChecked)
                    {
                        bHasApproved = true;
                        //glbApprovedDate = clsSecurity.getServerDateTime();
                        dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                        dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                        txtApprovedBy.Text = frmSetApproved.sApprovedUserName;
                        txtApprovedBy.Tag = frmSetApproved.sApprovedUserID;
                        clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);

                        if (IsUpdate)
                        {
                            tbl_sasInvDeliveryOrder objDO = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                            if (objDO != null)
                            {
                                objDO.IsApproved = true;
                                objDO.DateChecked = clsSecurity.getServerDateTime();
                                objDO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                                objDO.Update();
                            }
                        }

                    }
                    else if (frmSetApproved.bReset)
                    {
                        txtDateApprovedBy.Visible = true;
                        txtApprovedBy.Text = "";
                        txtApprovedBy.Tag = null;
                        bHasApproved = false;
                        clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryDate.Value.Date))
                {
                    frmSetChecked login = new frmSetChecked();
                    login.iFormID = iFormID;
                    login.ShowDialog();
                    if (frmSetChecked.bChecked)
                    {
                        bHasChecked = true;
                        //glbCheckedDate = clsSecurity.getServerDateTime();
                        dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                        dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                        txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
                        txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
                        clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);

                        if (IsUpdate)
                        {
                            tbl_sasInvDeliveryOrder objDO = tbl_sasInvDeliveryOrder.Select(txtDeliveryOrderID.Text.Trim());
                            if (objDO != null)
                            {
                                objDO.IsChecked = true;
                                objDO.DateChecked = clsSecurity.getServerDateTime();
                                objDO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                                objDO.Update();
                            }
                        }

                    }
                    else if (frmSetChecked.bReset)
                    {
                        txtCheckedBy.Text = "";
                        txtCheckedBy.Tag = null;
                        bHasChecked = false;
                        clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
        private void Search_JobID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                if (txtCustomerID.Tag != null && txtCustomerID.Tag.ToString().Length > 0)
                {
                    clsSearch.passValue_ConfirmedJobRegisterByCustomerID(txtCustomerID.Tag.ToString());
                    frmhelpsearch.ShowDialog();

                    if (frmSearchTransaction.s_SearchText.Length > 0)
                        txtJobCode.Text = frmSearchTransaction.s_SearchID;
                    if (frmSearchTransaction.s_SearchID.Length > 0)
                        txtJobCode.Tag = frmSearchTransaction.s_SearchID;
                }
                else
                    MessageBox.Show("Please Enter Select the Customer First..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
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
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
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
        private void CalculateDiscount()
        {
            try
            {
                if (chkDiscount.Checked)
                {

                    decimal dSubtotal = 0;
                    decimal dPesentageDiscount = 0;
                    decimal dDiscount = 0;
                    if (clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                        dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
                    if (dSubtotal > 0)
                    {
                        if (txtPercentageDiscount.Enabled)
                        {
                            if (clsCommon.isCurrency(txtPercentageDiscount.Text.Trim()))
                            {
                                dPesentageDiscount = decimal.Parse(txtPercentageDiscount.Text.Trim());
                                if (dPesentageDiscount > 0)
                                {
                                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep((dSubtotal * dPesentageDiscount) / 100);
                                }
                            }
                        }
                        else if (txtDiscount.Enabled)
                        {
                            if (clsCommon.isCurrency(txtDiscount.Text.Trim()))
                            {
                                dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                                if (dDiscount > 0)
                                {
                                    txtDiscount.Text = clsFormatter.FormatToCurrecyWithThousendSep(dDiscount);
                                }
                            }
                        }

                    }
                }
                else
                {
                    txtPercentageDiscount.Text = "0";
                    txtOtherTax.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void CalculateNBT()
        {
            try
            {
                if (chkNBT.Checked)
                {
                    if (chkReverseCalculation.Checked)
                    {
                        chkVat.Checked = true;
                        chkVat_CheckedChanged(chkVat, new EventArgs());
                        #region Revers Calculation
                        chkNBT.Enabled = false; 
                        #endregion
                    }
                    else
                    {
                        #region Normal Calculation
                        decimal dSubtotal = 0;
                        decimal dPesentageNBT = 0;
                        if (clsCommon.isCurrency(txtSubTotal.Text.Trim()))
                            dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
                        if (dSubtotal > 0)
                        {
                            txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
                            if (clsCommon.isCurrency(txtPercentageNBT.Text.Trim()))
                            {
                                dPesentageNBT = decimal.Parse(txtPercentageNBT.Text.Trim());
                                if (dPesentageNBT > 0)
                                {
                                    txtNBT.Text = clsFormatter.FormatToCurrecyWithThousendSep((dSubtotal * dPesentageNBT) / 100);
                                }
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    txtPercentageNBT.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageNBT());
                    txtNBT.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        private void CalculateVAT()
        {
            try
            {
                if (chkVat.Checked)
                {
                    if (chkReverseCalculation.Checked)
                    {
                        #region Revers Calculation
                        decimal dNbtRate=0, dVatRate = 0;
                        if (chkVat.Checked && clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                            dVatRate = decimal.Parse(txtPercentageVat.Text.Trim());

                        if (chkNBT.Checked && clsCommon.isCurrency(txtPercentageNBT.Text.Trim()))
                            dNbtRate = decimal.Parse(txtPercentageNBT.Text.Trim());

                        VatReverceCalculation(dVatRate);
                        NbtReverceCalculation(dNbtRate);
                        chkVat.Enabled = false;
                        #endregion
                    }
                    else
                    {
                        #region Normal Calculation
                        decimal dPesentageVAT = 0;
                        txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());
                        if (clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                        {
                            dPesentageVAT = decimal.Parse(txtPercentageVat.Text.Trim());
                            if (dPesentageVAT > 0)
                            {
                                txtVat.Text = clsFormatter.FormatToCurrecyWithThousendSep((GetSubTotalWithOtherTax() * dPesentageVAT) / 100);
                            }
                        }
                        //} 


                        #endregion
                    }
                }
                else
                {
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());                    
                    txtVat.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void CalculateOtherTax()
        {
            try
            {
                if (chkOtherTax.Checked)
                {

                    decimal dPesentageOtherTax = 0;
                        if (clsCommon.isCurrency(txtPercentageOtherTax.Text.Trim()))
                        {
                            dPesentageOtherTax = decimal.Parse(txtPercentageOtherTax.Text.Trim());
                            if (dPesentageOtherTax > 0)
                            {
                                txtOtherTax.Text = clsFormatter.FormatToCurrecyWithThousendSep((GetSubTotalWithNbt() * dPesentageOtherTax) / 100);
                            }
                        }
                    //}
                }
                else
                {
                    txtPercentageOtherTax.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageOtherTax());
                    txtOtherTax.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void CalcualteGrandTotal()
        {
            try
            {
                if (chkReverseCalculation.Checked)
                {
                    decimal dSubtotal = 0;
                    decimal dDiscount = 0;
                    decimal dNBT = 0;
                    decimal dVAT = 0;
                    decimal dOtherTax = 0;
                    if (clsCommon.isCurrency(txtSubTotal.Text))
                        dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
                    if (clsCommon.isCurrency(txtDiscount.Text.Trim()))
                        dDiscount = decimal.Parse(txtDiscount.Text.Trim());
                    if (clsCommon.isCurrency(txtNBT.Text.Trim()))
                        dNBT = decimal.Parse(txtNBT.Text.Trim());
                    if (clsCommon.isCurrency(txtVat.Text.Trim()))
                        dVAT = decimal.Parse(txtVat.Text.Trim());
                    if (clsCommon.isCurrency(txtOtherTax.Text.Trim()))
                        dOtherTax = decimal.Parse(txtOtherTax.Text.Trim());
                    decimal dGrandTotal = (dSubtotal - dDiscount) + dNBT + dVAT + dOtherTax;
                }
                else
                {
                    decimal dGrandTotal = GetSubTotalWithVat();//(dSubtotal + dNBT + dVAT + dOtherTax) - dDiscount;
                    txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(dGrandTotal);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
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
                txtSubTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }
       
        #endregion

        #region Vat Revers calculation
        private void VatReverceCalculation(decimal dVatRate)
        {
            if (!isDonVatReversCalculation)
            {
                if (dVatRate > 0)
                {
                    decimal dTotalVat = 0;
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        decimal dUnitPrice = 0, dWeightPrice = 0, dVatAmount = 0, dQty = 0, dWeight = 0;
                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));

                        #region Tax Amount Calculation
                        if (chkUnitPricing.Checked)
                        {
                            dVatAmount = (dUnitPrice / (100 + dVatRate)) * 100;
                            dVatAmount = dUnitPrice - dVatAmount;
                            dUnitPrice = dUnitPrice - dVatAmount;
                            dVatAmount *= dQty;
                            dTotalVat += Math.Round(dVatAmount, 2);
                        }
                        else
                        {
                            dVatAmount = (dWeightPrice / (100 + dVatRate)) * 100;
                            dVatAmount = dWeightPrice - dVatAmount;
                            dWeightPrice = dWeightPrice - dVatAmount;
                            dVatAmount *= dWeight;
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
        #endregion

        #region Nbt Revers Calculation
        private void NbtReverceCalculation(decimal dNbtRate)
        {
            if (!isDonNbtReversCalculation)
            {
                if (dNbtRate > 0)
                {
                    decimal dTotalNbt = 0;
                    foreach (DataGridViewRow row in dgvDetail.Rows)
                    {
                        decimal dUnitPrice = 0, dWeightPrice = 0, dNbtAmount = 0, dQty = 0, dWeight = 0;
                        dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));

                        #region Tax Amount Calculation
                        if (chkUnitPricing.Checked)
                        {
                            dNbtAmount = (dUnitPrice / (100 + dNbtRate)) * 100;
                            dNbtAmount = dUnitPrice - dNbtAmount;
                            dUnitPrice = dUnitPrice - dNbtAmount;
                            dNbtAmount *= dQty;
                            dTotalNbt += Math.Round(dNbtAmount, 2);
                        }
                        else
                        {
                            dNbtAmount = (dWeightPrice / (100 + dNbtRate)) * 100;
                            dNbtAmount = dWeightPrice - dNbtAmount;
                            dWeightPrice = dWeightPrice -dNbtAmount;
                            dNbtAmount *= dWeight;
                            dTotalNbt += Math.Round(dNbtAmount, 2);
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
        #endregion


                


        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string InvoiceID, decimal UnitPrice, decimal WeightPrice, decimal TatalAmount,
decimal Width, decimal Height, decimal Gauge, decimal Gusset, decimal Weight, decimal Qty, string sItemStatus, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string Remark, bool bHasSettled, decimal dExRate)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");

                    if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
                    {
                        dgvDetail.Rows.RemoveAt(iRow);
                        Weight += clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        Qty += clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        iRow = row.Index;
                    }
                }

                //Get Unit Price with Exchange rate to save
                UnitPrice = clsHelpMethods_Local.getDisplayPrice(UnitPrice, dExRate);
                WeightPrice = clsHelpMethods_Local.getDisplayPrice(WeightPrice, dExRate);
                TatalAmount = clsHelpMethods_Local.getDisplayPrice(TatalAmount, dExRate);

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);
                dgvDetail["InvoiceCode", iRow].Value = InvoiceID;//add by thilina               
                dgvDetail["ItemStatus", iRow].Value = sItemStatus;
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
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(Weight);
                dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(UnitPrice);
                dgvDetail["UnitPrice", iRow].Tag = UnitPrice;
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatToNumberNoDecimal(Qty);
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);
                dgvDetail["WeightPrice", iRow].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(WeightPrice);
                dgvDetail["WeightPrice", iRow].Tag = WeightPrice;


                if (bHasSettled)
                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Calculate SubTotal With NBT
        private decimal GetSubTotalWithNbt()
        {
            decimal dSubtotal = 0;
            decimal dPesentageNBT = 0, dDiscount = 0;
            //decimal dNbtAmount = 0;
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
                        {
                            dSubtotal += (dSubtotal * dPesentageNBT) / 100;
                        }
                    }
                }
            }
            return dSubtotal;
        } 
        #endregion

        #region Calculate Subtotal with Other Tax
        private decimal GetSubTotalWithOtherTax()
        {
            decimal dSubtotal = GetSubTotalWithNbt();
            decimal dPesentageOtherTax = 0;
            //if (clsCommon.isCurrency(txtSubTotal.Text.Trim()))
            //    dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
            if (chkOtherTax.Checked)
            {
                if (dSubtotal > 0)
                {
                    //txtPercentageOtherTax.Text = clsCommon.getPesentageOtherTax().ToString();
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
            return dSubtotal;
        } 
        #endregion

        #region Calculate SubTotal With Vat
        private decimal GetSubTotalWithVat()
        {
            decimal dSubtotal = GetSubTotalWithOtherTax();
            decimal dPesentageVAT = 0;
            //if (clsCommon.isCurrency(txtSubTotal.Text.Trim()))
            //    dSubtotal = decimal.Parse(txtSubTotal.Text.Trim());
            if (chkVat.Checked)
            {
                if (dSubtotal > 0)
                {
                    txtPercentageVat.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(clsCommon.getPesentageVAT());
                    if (clsCommon.isCurrency(txtPercentageVat.Text.Trim()))
                    {
                        dPesentageVAT = decimal.Parse(txtPercentageVat.Text.Trim());
                        if (dPesentageVAT > 0)
                        {
                            dSubtotal += (dSubtotal * dPesentageVAT) / 100;
                        }
                    }
                }
            }
            return dSubtotal;
        } 
        #endregion

        private void frm_sasInvDeliveryOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }

    }
}
