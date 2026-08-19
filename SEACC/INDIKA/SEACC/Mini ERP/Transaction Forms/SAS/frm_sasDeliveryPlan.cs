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
    public partial class frm_sasDeliveryPlan : Form
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
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
  

        #region Form Load
        public frm_sasDeliveryPlan()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.DeliveryPlan);
            iFormID = clsSecurity.getFormID(FormName.DeliveryPlan);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_sasDeliveryPlan_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Delivery Order Plan [DOP]", 2, iFormID);
            CusDataGridViewFormat();


            ClearFields();
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
                try
                {
                    if (txtDeliveryPlanID.Text.Trim().Length > 0)
                    {
                        if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryPlanDate.Value.Date))
                        {
                            if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                            {
                                //delete one record
                                Cursor = Cursors.WaitCursor;
                                tbl_sasDeliveryPlan detail = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                                if (detail != null)
                                {
                                    if (!detail.IsLocked)
                                    {
                                        if (!detail.IsDeleted)
                                        {
                                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, " Delivery Plan ID : " + detail.DeliveryPlan_ID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                                            if (msgResult == DialogResult.Yes)
                                            {
                                                //////Update Other Tables
                                                List<tbl_sasDeliveryPlan_CustomerOrder> oDOP_COs = tbl_sasDeliveryPlan_CustomerOrder.SelectAllByDeliveryPlan_ID(detail.DeliveryPlan_ID);
                                                foreach (tbl_sasDeliveryPlan_CustomerOrder oDOP_CO in oDOP_COs)
                                                {
                                                    #region If - Checked
                                                    if (detail.IsChecked)
                                                    {
                                                        #region Delete DO
                                                        tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oDOP_CO.DeliveryOrder_ID);
                                                        if (oDO != null && oDO.DeliveryOrder_ID != "default")
                                                        {
                                                            oDO.IsDeleted = true;
                                                            oDO.DateModified = clsSecurity.getServerDateTime();
                                                            oDO.ModifiedUser_ID = clsSecurity.UserIDLoged;

                                                            oDO.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                            oDO.DateDeleted = clsSecurity.getServerDateTime();
                                                            oDO.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                            oDO.Update();
                                                        }
                                                        #endregion

                                                        #region Update Other Tables
                                                        List<tbl_sasDeliveryPlan_CustomerOrder_Items> Dodetails = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID_CustomerOrder_ID(oDOP_CO.DeliveryPlan_ID, oDOP_CO.CustomerOrder_ID);
                                                        foreach (tbl_sasDeliveryPlan_CustomerOrder_Items Dodetail in Dodetails)
                                                        {
                                                            if (Dodetail.Item_ID != null)
                                                            {
                                                                #region Unsettle Customer Order
                                                                if (Dodetail.CustomerOrder_ID != null && Dodetail.CustomerOrder_ID != "default")
                                                                {
                                                                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(Dodetail.Line_No, Dodetail.CustomerOrder_ID, Dodetail.Item_ID,
                                                                        Dodetail.ItemSubCategory_ID, Dodetail.ItemSubCategory2_ID, Dodetail.ItemSerialNo, Dodetail.ItemSerialNo2);
                                                                    if (CoItem != null)
                                                                    {
                                                                        if (!Dodetail.IsWeightCalculation)
                                                                            CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder - Dodetail.Qty;
                                                                        else
                                                                            CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder - Dodetail.Weight;
                                                                        CoItem.Update();
                                                                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(Dodetail.CustomerOrder_ID, chkUnitPricing);
                                                                    }
                                                                }
                                                                #endregion

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
                                                                if (clsHelpMethods_Local.isStore_StockAvailabel(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2))
                                                                {
                                                                    if (clsConfig.bStockValidateQty_DeliveryOrder)
                                                                    {
                                                                      //  clsHelpMethods_Local.Store_StockQuantityIncrease(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Qty);
                                                                      //  clsHelpMethods_Local.Store_StockQuantityIncrease_Available(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Qty);
                                                                    }
                                                                    if (clsConfig.bStockValidateWeight_DeliveryOrder)
                                                                    {
                                                                      //  clsHelpMethods_Local.Store_StockWeightIncrease(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Weight);
                                                                      //  clsHelpMethods_Local.Store_StockWeightIncrease_Available(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Weight);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                 //   if (clsConfig.bStockValidateQty_DeliveryOrder || clsConfig.bStockValidateWeight_DeliveryOrder)
                                                                      //  clsHelpMethods_Local.Store_NewStock(txtSoteID.Tag.ToString(), sOldItemCode, sTmpJobCode, sOldItemSubCategoryID, sOldItemSubCategoryID2, sOldItemSerialNo, sOldItemSerialNo2, Dodetail.Weight, Dodetail.Weight, Dodetail.Qty, Dodetail.Qty, 0, 0, 0, 0);
                                                                }
                                                                #endregion
                                                            }
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion

                                                    #region If - Approved
                                                    if (detail.IsApproved)
                                                    {
                                                        #region Delete Invoice
                                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(oDOP_CO.Invoice_ID);
                                                        if (oInvoice != null && oInvoice.Invoice_ID != "default")
                                                        {
                                                            oInvoice.IsDeleted = true;
                                                            oInvoice.DateModified = clsSecurity.getServerDateTime();
                                                            oInvoice.ModifiedUser_ID = clsSecurity.UserIDLoged;

                                                            oInvoice.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                            oInvoice.DateDeleted = clsSecurity.getServerDateTime();
                                                            oInvoice.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                            oInvoice.Update();
                                                        }
                                                        #endregion
                                                    }
                                                    #endregion


                                                }
                                                detail.IsDeleted = true;
                                                detail.DateModified = clsSecurity.getServerDateTime();
                                                detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DeletedUser_ID = clsSecurity.UserIDLoged;
                                                detail.DateDeleted = clsSecurity.getServerDateTime();
                                                detail.DeletedTerminal_ID = clsSecurity.TerminalID;
                                                detail.Update();
                                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                ClearFields();
                                            }
                                        }
                                        else
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AlreadyDeleted), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    }
                                    else
                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLockedCantDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
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
            if (ValidateSave())
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    ValidateEmptyForeignKey();

                    if (IsUpdate)  //update records
                    {
                        #region Update
                        //tbl_sasDeliveryPlan oldRecord = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                        //if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        //{
                        //    if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                        //    {

                        //        #region Update Old Co items
                        //        List<tbl_sasDeliveryPlan_CustomerOrder_Items> oldDPDetails = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID(txtDeliveryPlanID.Text.Trim());
                        //        foreach (tbl_sasDeliveryPlan_CustomerOrder_Items oldDPDetail in oldDPDetails)
                        //        {
                        //            string sCustomerOrderID = "", sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                        //            decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0;
                        //            bool bHasItemInDB = false, bIsHeader;

                        //            foreach (DataGridViewRow row in dgvDetail.Rows)
                        //            {

                        //                bIsHeader = bool.Parse(dgvDetail["IsHeader", row.Index].Value.ToString());
                        //                sCustomerOrderID = clsValidate.ValidateGridValue(dgvDetail, "CustomerOrderID", row.Index, "default");
                        //                //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        //                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        //                dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        //                dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                        //                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                        //                sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                        //                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        //                sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                        //                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        //                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row.Index, decimal.Parse("0.00"));

                        //                if (oldDPDetail.CustomerOrder_ID == sCustomerOrderID && oldDPDetail.Item_ID == sItemCode && oldDPDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                        //                oldDPDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldDPDetail.ItemSerialNo == sItemSerialNo && oldDPDetail.ItemSerialNo2 == sItemSerialNo2)
                        //                {
                        //                    bHasItemInDB = true;
                        //                    dgvDetail.Rows.RemoveAt(row.Index);
                        //                    break; //database contain this item
                        //                }
                        //            }
                        //            if (bHasItemInDB)
                        //            {
                        //                oldDPDetail.Item_ID = sItemCode;
                        //                oldDPDetail.Qty = dQuantity;
                        //                oldDPDetail.Weight = dWeight;
                        //                oldDPDetail.UnitPrice = dUnitPrice;
                        //                oldDPDetail.WeightPrice = dWeightPrice;
                        //                oldDPDetail.TatalAmount = dAmount;
                        //                oldDPDetail.Remark = sRemarks;
                        //                oldDPDetail.IsWeightCalculation = !chkUnitPricing.Checked;
                        //                oldDPDetail.Update();
                        //            }
                        //            else
                        //            {
                        //                oldDPDetail.Delete();
                        //            }
                        //        }
                        //        #endregion

                        //        #region insert Newly Added Data
                        //        foreach (DataGridViewRow row in dgvDetail.Rows)
                        //        {
                        //            string sCustomerOrderID = "", sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "",
                        //                sItemSerialNo2 = "", sRemarks = "";
                        //            decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0;
                        //            bool bIsHeader;

                        //            bIsHeader = bool.Parse(dgvDetail["IsHeader", row.Index].Value.ToString());
                        //            sCustomerOrderID = clsValidate.ValidateGridValue(dgvDetail, "CustomerOrderID", row.Index, "default");
                        //            //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        //            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        //            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        //            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                        //            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                        //            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                        //            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        //            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                        //            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        //            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row.Index, decimal.Parse("0.00"));

                        //            if (bIsHeader)
                        //            {
                        //                #region Delivery Plan CustomerOrder
                        //                //tbl_sasDeliveryPlan_CustomerOrder ORDetail = new tbl_sasDeliveryPlan_CustomerOrder(txtDeliveryPlanID.Text.ToString(), sCustomerOrderID);
                        //                //ORDetail.up;
                        //                #endregion
                        //            }
                        //            else
                        //            {
                        //                if (sItemCode.Length > 0)
                        //                {
                        //                    #region DeliveryPlan_CustomerOrder_Items
                        //                    tbl_sasDeliveryPlan_CustomerOrder_Items items = new tbl_sasDeliveryPlan_CustomerOrder_Items(
                        //                        row.Index, txtDeliveryPlanID.Text.Trim(), sCustomerOrderID, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                        //                        sItemSerialNo2, dQuantity, dWeight, dUnitPrice, dWeightPrice, dAmount, sRemarks, !chkUnitPricing.Checked);
                        //                    items.Update();
                        //                    #endregion
                        //                }
                        //            }
                        //        }
                        //        #endregion

                        //        #region Delivery Plan Header
                        //        tbl_sasDeliveryPlan detail = new tbl_sasDeliveryPlan(txtDeliveryPlanID.Text.Trim(), dtpDeliveryPlanDate.Value, txtRemark.Text.Trim(),
                        //         txtSoteID.Tag.ToString(), "default", 0, decimal.Parse(txtGrandTotal.Text.Trim()), oldRecord.CreateUser_ID,
                        //         clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                        //         oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                        //         clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                        //         oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsSeattled, !chkUnitPricing.Checked, oldRecord.PrintCount);
                        //        detail.Update();
                        //        #endregion

                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    }
                        //    else
                        //        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.RecordLocked), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        #endregion
                    }
                    else  //insert records
                    {
                        #region Insert
                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                            txtDeliveryPlanID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        if (clsValidate.CheckValidity_TransactionCodeLength(txtDeliveryPlanID.Text)) //if (txtDeliveryPlanID.TextLength > 0)
                        {
                            #region Delivery Plan Header
                            tbl_sasDeliveryPlan detail = new tbl_sasDeliveryPlan(txtDeliveryPlanID.Text.Trim(), dtpDeliveryPlanDate.Value, txtRemark.Text.Trim(),
                                txtSoteID.Tag.ToString(), "default", 0, decimal.Parse(txtGrandTotal.Text.Trim()), clsSecurity.UserIDLoged,
                                clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(),
                                clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                bHasChecked, bHasApproved, false, false, false, false, !chkUnitPricing.Checked, 0);
                            detail.Insert();
                            #endregion

                            #region Delivery Plan Detail
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sCustomerOrderID = "", sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                    decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0, dDiscountPesentage, dNBTPesentage, dVATPesentage, dOtherTaxPesentage, dDiscountTotal, dNBTTotal, dVATTotal, dOtherTaxTotal, dGrandTotal;
                                    bool bIsHeader = false, bIsSelect = false;

                                    bIsHeader = bool.Parse(dgvDetail["IsHeader", row.Index].Value.ToString());
                                    bIsSelect = bool.Parse(dgvDetail["IsSelect", row.Index].Value.ToString());
                                    sCustomerOrderID = clsValidate.ValidateGridValue(dgvDetail, "CustomerOrderID", row.Index, "default");
                                    //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                                    dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "0");
                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row.Index, decimal.Parse("0.00"));
                                    dDiscountTotal = clsValidate.ValidateGridValue(dgvDetail, "discountPercentage", row.Index, decimal.Parse("0.00"));
                                    dNBTTotal = clsValidate.ValidateGridValue(dgvDetail, "nbtPercentage", row.Index, decimal.Parse("0.00"));
                                    dVATTotal = clsValidate.ValidateGridValue(dgvDetail, "vatPercentage", row.Index, decimal.Parse("0.00"));
                                    dOtherTaxTotal = clsValidate.ValidateGridValue(dgvDetail, "otherTaxPercentage", row.Index, decimal.Parse("0.00"));
                                    dDiscountPesentage = clsValidate.ValidateGridTag(dgvDetail, "discountPercentage", row.Index, decimal.Parse("0.00"));
                                    dNBTPesentage = clsValidate.ValidateGridTag(dgvDetail, "nbtPercentage", row.Index, decimal.Parse("0.00"));
                                    dVATPesentage = clsValidate.ValidateGridTag(dgvDetail, "vatPercentage", row.Index, decimal.Parse("0.00"));
                                    dOtherTaxPesentage = clsValidate.ValidateGridTag(dgvDetail, "otherTaxPercentage", row.Index, decimal.Parse("0.00"));
                                    dGrandTotal = clsValidate.ValidateGridValue(dgvDetail, "grandTotal", row.Index, decimal.Parse("0.00"));

                                    if (bIsHeader && bIsSelect)
                                    {
                                        #region Delivery Plan CustomerOrder
                                        tbl_sasDeliveryPlan_CustomerOrder ORDetail = new tbl_sasDeliveryPlan_CustomerOrder(txtDeliveryPlanID.Text.ToString(), sCustomerOrderID, txtRouteID.Tag.ToString(),
                                            "default", "default", dDiscountPesentage, dNBTPesentage, dVATPesentage, dOtherTaxPesentage, dAmount, dDiscountTotal, dNBTTotal, dVATTotal, dOtherTaxTotal, dGrandTotal, 0, 0);                                            
                                        ORDetail.Insert();
                                        #endregion
                                    }
                                    else
                                    {
                                        if (sItemCode.Length > 0 && bIsSelect)
                                        {
                                            #region DeliveryPlan_CustomerOrder_Items
                                            tbl_sasDeliveryPlan_CustomerOrder_Items items = new tbl_sasDeliveryPlan_CustomerOrder_Items(
                                                row.Index, txtDeliveryPlanID.Text.Trim(), sCustomerOrderID, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo,
                                                sItemSerialNo2, dQuantity, dWeight, dUnitPrice, dWeightPrice, dAmount, sRemarks, !chkUnitPricing.Checked);
                                            items.Insert();
                                            #endregion
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    clsValidate.WriteErrorLog("", iFormID,ex);
                                    SEACCException.Show(ex);
                                }//error may come because last row of the grid may not have information
                            }
                            #endregion

                            Attachments.Insert(txtDeliveryPlanID.Text.ToString());

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //else
                        //{
                        //    MessageBox.Show("Delivery Plan " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        #endregion
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
                    tbl_sasDeliveryPlan oldRecord = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                    if (oldRecord != null)
                        FillDetails(txtDeliveryPlanID.Text.Trim());
                }

            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryPlanID.TextLength > 0 && txtDeliveryPlanID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    bool IsValid = false;
                    tbl_sasDeliveryPlan order = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                    if (order != null)
                    {
                        order.PrintCount++;
                        sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                        if (order.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                        if (order.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";
                        order.Update();

                        if (order.IsApproved)
                            IsValid = true;
                        else
                            MessageBox.Show("Please Approve the DOP Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                    if (IsValid)
                    {
                        Cursor = Cursors.WaitCursor;

                        #region Print Detail
                        for (int x = 0; x < 2; x++)
                        {
                            string s_Path = "", sReportTitle = "Delivery Plan", sFormula = "";
                            if (txtDeliveryPlanID.TextLength > 0)
                                sFormula = "{vw_rpt_sasDeliveryPlan.deliveryPlan_ID} = '" + txtDeliveryPlanID.Text.Trim() + "'";

                            ReportDocument RD = new ReportDocument();
                            s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");

                            if (x == 0)
                                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan1.rpt";
                            else if (x == 1)
                                s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan_Items.rpt";

                            frm_ReportViewer viewer = new frm_ReportViewer();
                            RD.Load(s_Path);
                            Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                            RD.Refresh();

                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                                RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                            RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                            RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                            RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                            RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                            RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                            RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                            RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                            RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                            RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                            RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                            // RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(order.Customer_ID));

                            if (clsConfig.bDirectPrint_NP_Invoice) //Direct Print
                            {
                                RD.DataDefinition.RecordSelectionFormula = sFormula;
                                clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_SalesInvoice), ref RD);
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
                else
                    MessageBox.Show("Please Select the Delivery Order Plan To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Draft
        private void btnDraft_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDeliveryPlanID.TextLength > 0 && txtDeliveryPlanID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    bool IsValid = false;
                    tbl_sasDeliveryPlan order = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                    if (order != null)
                    {
                        sCreateUser = "[ " + clsGenaralName.getName_User(order.CreateUser_ID) + " ] [ " + order.DateCreate.ToShortDateString() + " ]";
                        if (order.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(order.CheckedUser_ID) + " ] [ " + order.DateChecked.ToShortDateString() + " ]";
                        if (order.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(order.ApprovedUser_ID) + " ] [ " + order.DateApproved.ToShortDateString() + " ]";

                        if (order.IsChecked)
                            IsValid = true;
                        else
                            MessageBox.Show("Please Check the DOP Before Print", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (IsValid)
                    {
                        Cursor = Cursors.WaitCursor;
                        string s_Path = "", sReportTitle = "Delivery Plan", sFormula = "";
                        if (txtDeliveryPlanID.TextLength > 0)
                            sFormula = "{vw_rpt_sasDeliveryPlan.deliveryPlan_ID} = '" + txtDeliveryPlanID.Text.Trim() + "'";

                        ReportDocument RD = new ReportDocument();
                        s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";
                        else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";
                        else
                            s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasDeliveryPlan.rpt";


                        frm_ReportViewer viewer = new frm_ReportViewer();
                        RD.Load(s_Path);
                        Digiteq.Classes.ReportHelper.LogonServer(ref RD);
                        RD.Refresh();

                        if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString() || clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                            RD.DataDefinition.FormulaFields["SubCategory"].Text = clsCommon.fncsetstring(clsConfig.sItemSubCategory);

                        RD.DataDefinition.FormulaFields["ReportTitle"].Text = clsCommon.fncsetstring(sReportTitle);
                        RD.DataDefinition.FormulaFields["DateRange"].Text = clsCommon.fncsetstring(clsSecurity.getServerDateTime().ToShortDateString());
                        RD.DataDefinition.FormulaFields["CreateUserName"].Text = clsCommon.fncsetstring(sCreateUser);
                        RD.DataDefinition.FormulaFields["CheckUserName"].Text = clsCommon.fncsetstring(sCheckedUser);
                        RD.DataDefinition.FormulaFields["ApproveUserName"].Text = clsCommon.fncsetstring(sApprovedUser);
                        RD.DataDefinition.FormulaFields["CompanyName"].Text = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        RD.DataDefinition.FormulaFields["CompanyAddress1"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress1);
                        RD.DataDefinition.FormulaFields["CompanyAddress2"].Text = clsCommon.fncsetstring(clsSecurity.CompanyAddress2);
                        RD.DataDefinition.FormulaFields["DigiteqName"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqName);
                        RD.DataDefinition.FormulaFields["DigiteqEmail"].Text = clsCommon.fncsetstring(clsSecurity.DigiteqEmail);
                        // RD.DataDefinition.FormulaFields["TelphoneFax"].Text = clsCommon.fncsetstring(clsCommon.getCustomerTelephoneAndFax(order.Customer_ID));
                        RD.DataDefinition.FormulaFields["IsDraft"].Text = "'DRAFT'";

                        if (clsConfig.bDirectPrint_NP_Invoice) //Direct Print
                        {
                            RD.DataDefinition.RecordSelectionFormula = sFormula;
                            clsHelpMethods_Local.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_SalesInvoice), ref RD);
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
                }
                else
                    MessageBox.Show("Please Select the Delivery Order Plan To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Checking
        private void btnChecking_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
                {
                    bHasChecked = true;
                    glbCheckedDate = clsSecurity.getServerDateTime();
                    dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                    txtCheckedBy.Text = clsSecurity.UserNameLoged;
                    txtCheckedBy.Tag = clsSecurity.UserIDLoged;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);


                    tbl_sasDeliveryPlan objDO = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                    if (objDO != null)
                    {   
                        bool bUpdateOk = false;
                        if (!objDO.IsChecked) //validate whether it has not checked before
                            bUpdateOk = true;

                        if (bUpdateOk)
                        {
                            //Save Delivery Order
                            AutoSaveDeliveryOrder();

                            #region Update Store Stock
                            List<tbl_sasDeliveryPlan_CustomerOrder_Items> Details = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID(objDO.DeliveryPlan_ID);
                            foreach (tbl_sasDeliveryPlan_CustomerOrder_Items Detail in Details)
                            {
                                if (clsHelpMethods_Local.isStore_StockAvailabel(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2))
                                {
                                    if (chkUnitPricing.Checked)
                                    {
                                      //  clsHelpMethods_Local.Store_StockQuantityDecrease(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Qty);
                                       // clsHelpMethods_Local.Store_StockQuantityDecrease_Available(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Qty);
                                    }
                                    else
                                    {
                                      //  clsHelpMethods_Local.Store_StockWeightDecrease(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Weight);
                                      //  clsHelpMethods_Local.Store_StockWeightDecrease_Available(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Weight);
                                    }
                                }
                               // else
                                 //   clsHelpMethods_Local.Store_NewStock(txtSoteID.Tag.ToString(), Detail.Item_ID, "default", Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Weight, Detail.Weight, Detail.Qty, Detail.Qty, 0, 0, 0, 0);
                            }
                            #endregion
                        }
                        objDO.IsChecked = true;
                        objDO.DateChecked = clsSecurity.getServerDateTime();
                        objDO.CheckedUser_ID = clsSecurity.UserIDLoged;
                        objDO.Update();
                    }
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToCheck), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region Btn Approval
        private void btnApproval_Click(object sender, EventArgs e)
        {
            if (IsUpdate)
            {
                if (clsSecurity.PermissionToApproved(clsSecurity.UserIDLoged, iFormID))
                {
                    bHasApproved = true;
                    glbApprovedDate = clsSecurity.getServerDateTime();
                    dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                    txtApprovedBy.Text = clsSecurity.UserNameLoged;
                    txtApprovedBy.Tag = clsSecurity.UserIDLoged;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);


                    tbl_sasDeliveryPlan oDOP = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
                    if (oDOP != null)
                    {

                        AutoSaveInvoice();

                        oDOP.IsApproved = true;
                        oDOP.DateChecked = clsSecurity.getServerDateTime();
                        oDOP.ApprovedUser_ID = clsSecurity.UserIDLoged;
                        oDOP.Update();
                    }
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region Btn Invoice
        private void btnCreateInvoices_Click(object sender, EventArgs e)
        {
            List<string> sNote = new List<string>();
            List<tbl_sasDeliveryPlan_Invoice> details = tbl_sasDeliveryPlan_Invoice.SelectAllByDeliveryPlan_ID(txtDeliveryPlanID.Text.Trim());
            foreach (tbl_sasDeliveryPlan_Invoice detail in details)
            {
                sNote.Add(detail.Invoice_ID);
            }

            frmFormListPrint frm = new frmFormListPrint();
            frm.glbNotes = sNote;
            frm.pn = ProcessNote.Invoice;
            frm.glbHeader = "Invoice";
            frm.ShowDialog();

            if (frm.glbReturnNoteID.Length > 0)
            {
                frm_sasInvoice inv = new frm_sasInvoice(FormName.VATInvoice);
                inv.glbInvoiceID = frm.glbReturnNoteID;
                clsHelpMethods_Local.DisplayForm(inv, clsFormatter.colorSales, this.MdiParent);
            }
        } 
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsFormatter.ApplyGridFormatModify(dgvDetail2, clsFormatter.colorDigiteqTheamColorSales2, clsFormatter.colorDigiteqTheamColorSales2ForColour, clsFormatter.colorDigiteqTheamColorSales2BackColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryPlanID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtRouteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSoteID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblstoreName, true);

            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);


            txtPreparedBy.Tag = null;
            txtCheckedBy.Tag = null;
            txtApprovedBy.Tag = null;
            txtRouteID.Tag = null;
            txtSoteID.Tag = null;

            txtRouteID.Clear();
            txtRemark.Clear();
            dtpDeliveryPlanDate.Value = clsSecurity.getServerDateTime();
            txtRouteID.Clear();
            txtSoteID.Clear();
            chkShowSettle.Checked = false;

            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            txtPreparedBy.Clear();
            bHasApproved = false;
            bHasChecked = false;
            dgvDetail.Rows.Clear();
            dgvDetail2.Rows.Clear();



            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtDeliveryPlanID.Text = "<Auto Generate>";
            else
                txtDeliveryPlanID.Clear();
            if (txtDeliveryPlanID.Enabled)
            {
                txtDeliveryPlanID.SelectAll();
                txtDeliveryPlanID.Focus();
            }

            Attachments.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sDeliveryPlanID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_sasDeliveryPlan_CustomerOrder> oldDPDetails = tbl_sasDeliveryPlan_CustomerOrder.SelectAllByDeliveryPlan_ID(sDeliveryPlanID);
                foreach (tbl_sasDeliveryPlan_CustomerOrder oldDPDetail in oldDPDetails)
                {
                    tbl_sasCustomerOrder CODetail = tbl_sasCustomerOrder.Select(oldDPDetail.CustomerOrder_ID);
                    if (CODetail != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;

                        Fill_Datagrid(iRow, CODetail.CustomerOrder_ID, CODetail.Customer_ID, "", 0, 0, CODetail.SubTotal, 0, CODetail.OrderRefNo_ID, clsGenaralName.getName_OrderRefNo(CODetail.OrderRefNo_ID), "", "", CODetail.CustomerOrderDate.ToString("dd MMM yyyy"), true,
                            CODetail.DiscountPercentage, CODetail.NbtPercentage, CODetail.VatPercentage, CODetail.OtherTaxPercentage);
                        dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.DimGray;
                        dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 212, 212);

                    }
                    List<tbl_sasDeliveryPlan_CustomerOrder_Items> oldDPIDetails = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID_CustomerOrder_ID(txtDeliveryPlanID.Text.Trim(), oldDPDetail.CustomerOrder_ID);
                    foreach (tbl_sasDeliveryPlan_CustomerOrder_Items oldDPIDetail in oldDPIDetails)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(oldDPIDetail.Item_ID);
                        if (item != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid(iRow, oldDPIDetail.CustomerOrder_ID, oldDPIDetail.Item_ID, item.Uom_ID, oldDPIDetail.UnitPrice,
                            oldDPIDetail.Line_No, oldDPIDetail.TatalAmount, oldDPIDetail.Qty, oldDPIDetail.ItemSubCategory_ID, oldDPIDetail.ItemSubCategory2_ID,
                            oldDPIDetail.ItemSerialNo, oldDPIDetail.ItemSerialNo2, "", false, 0, 0, 0, 0);
                        }
                    }
                    CalcualteGrandTotalForCustomerOrder(oldDPDetail.CustomerOrder_ID);
                }


                CalcualteGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void RefreshGridCustomerOrderID(string sCustomerOrderID)
        {
            try
            {
                int iRow;
                tbl_sasCustomerOrder CODetail = tbl_sasCustomerOrder.Select(sCustomerOrderID);
                if (CODetail != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;

                    Fill_Datagrid(iRow, CODetail.CustomerOrder_ID, CODetail.Customer_ID, "", 0, 0, CODetail.SubTotal, 0, clsGenaralName.getName_TownIDByCustomerID(CODetail.Customer_ID),
                        clsGenaralName.getName_OrderRefNo(CODetail.OrderRefNo_ID), "", "", CODetail.CustomerOrderDate.ToString("dd MMM yyyy"), true, CODetail.DiscountPercentage, CODetail.NbtPercentage, CODetail.VatPercentage, CODetail.OtherTaxPercentage);
                    dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.DimGray;
                    dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 212, 212);
                }
                List<tbl_sasCustomerOrder_Detail> CusDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCustomerOrderID);
                foreach (tbl_sasCustomerOrder_Detail CusDetail in CusDetails)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(CusDetail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;
                        Fill_Datagrid(iRow, CusDetail.CustomerOrder_ID, CusDetail.Item_ID, item.Uom_ID, CusDetail.UnitPrice,
                        CusDetail.Line_No, CusDetail.TatalAmount, (CusDetail.Qty - CusDetail.QtySettle_DeliveryOrder), CusDetail.ItemSubCategory_ID, CusDetail.ItemSubCategory2_ID,
                        CusDetail.ItemSerialNo, CusDetail.ItemSerialNo2, "", false, 0, 0, 0, 0);
                    }
                }
                CalcualteGrandTotal();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }        
        private void RefreshGridItems()
        {
            dgvDetail2.Rows.Clear();
            dgvDetail2.Columns["ItemName2"].Width = 200;
            dgvDetail2.Columns["ItemSubCategory2ID1"].Width = 103;
            dgvDetail2.Columns["OrderQty2"].Width = 75;
            int iRecords = 0;
            foreach (DataGridViewRow row1 in dgvDetail.Rows)
            {
                string sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sItemName = "";
                decimal dQuantity = 0;
                bool bHasItemInDB = false, bIsHeader = false, bIsSelect = false;


                bIsHeader = bool.Parse(dgvDetail["IsHeader", row1.Index].Value.ToString());
                bIsSelect = bool.Parse(dgvDetail["IsSelect", row1.Index].Value.ToString());
                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row1.Index, "default");
                sItemName = clsValidate.ValidateGridValue(dgvDetail, "ItemName", row1.Index, "");
                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row1.Index, decimal.Parse("0.00"));
                sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row1.Index, "default");
                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row1.Index, "default");
                sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row1.Index, "0");
                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row1.Index, "0");

                if (!bIsHeader && bIsSelect)
                {
                    foreach (DataGridViewRow row2 in dgvDetail2.Rows)
                    {
                        string s2ItemCode = "", s2ItemSubCategoryID = "", s2ItemSubCategoryID2 = "", s2ItemSerialNo = "", s2ItemSerialNo2 = "";
                        decimal d2Quantity = 0;
                        s2ItemCode = clsValidate.ValidateGridValue(dgvDetail2, "ItemCode2", row2.Index, "default");
                        s2ItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail2, "ItemSubCategory2ID1", row2.Index, "default");
                        s2ItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail2, "ItemSubCategory2ID2", row2.Index, "default");
                        s2ItemSerialNo = clsValidate.ValidateGridValue(dgvDetail2, "ItemSerialNo21", row2.Index, "0");
                        s2ItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail2, "ItemSerialNo22", row2.Index, "0");
                        if (sItemCode == s2ItemCode && sItemSubCategoryID == s2ItemSubCategoryID && sItemSubCategoryID2 == s2ItemSubCategoryID2 && sItemSerialNo == s2ItemSerialNo && sItemSerialNo2 == s2ItemSerialNo2)
                        {
                            d2Quantity = dQuantity + clsValidate.ValidateGridValue(dgvDetail2, "OrderQty2", row2.Index, decimal.Parse("0.00"));
                            dgvDetail2["OrderQty2", row2.Index].Value = d2Quantity;
                            bHasItemInDB = true;
                            break; //database contain this item
                        }
                    }
                    if (!bHasItemInDB)
                    {
                        int iRow;
                        dgvDetail2.Rows.Add();
                        iRow = dgvDetail2.Rows.Count - 1;
                        dgvDetail2["ItemCode2", iRow].Value = sItemCode;
                        dgvDetail2["OrderQty2", iRow].Value = dQuantity;
                        dgvDetail2["ItemName2", iRow].Value = sItemName;
                        dgvDetail2["ItemSubCategory2ID1", iRow].Tag = sItemSubCategoryID;
                        dgvDetail2["ItemSubCategory2ID1", iRow].Value = clsGenaralName.getName_ItemSubCategory(sItemSubCategoryID);
                        dgvDetail2["ItemSubCategory2ID2", iRow].Tag = sItemSubCategoryID2;
                        dgvDetail2["ItemSerialNo21", iRow].Value = sItemSerialNo;
                        dgvDetail2["ItemSerialNo22", iRow].Value = sItemSerialNo2;
                        iRecords++;
                    }

                }
            }
            if (iRecords > 3)
            {
                dgvDetail2.Columns["ItemName2"].Width -= 6;
                dgvDetail2.Columns["ItemSubCategory2ID1"].Width -= 5;
                dgvDetail2.Columns["OrderQty2"].Width -= 5;
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
                    tbl_sasDeliveryPlan detail = tbl_sasDeliveryPlan.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtDeliveryPlanID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtRouteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerOrderID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblCustomerID, false);
                        clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtSoteID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblstoreName, false);

                        //asign values
                        List<tbl_sasDeliveryPlan_CustomerOrder> detailDPs = tbl_sasDeliveryPlan_CustomerOrder.SelectAllByDeliveryPlan_ID(sID);
                        foreach (tbl_sasDeliveryPlan_CustomerOrder detailDP in detailDPs)
                        {
                            txtRouteID.Tag = detailDP.Route_ID;
                      //      txtRouteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(detailDP.Route_ID));
                        }

                        txtDeliveryPlanID.Tag = detail.DeliveryPlan_ID;
                        txtSoteID.Tag = detail.Store_ID;
                        txtDeliveryPlanID.Text = detail.DeliveryPlan_ID;
                        txtRemark.Text = detail.Remark;
                        dtpDeliveryPlanDate.Value = detail.DeliveryPlanDate;
                        txtSoteID.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Store(detail.Store_ID));

                        //User Security
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));
                        dtpDatePreparedBy.Value = detail.DateCreate;


                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
                            dtpDateApprovedBy.Value = detail.DateApproved;
                            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                            txtApprovedBy.Tag = detail.ApprovedUser_ID;
                            txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                        }
                        if (detail.IsChecked)
                        {
                            bHasChecked = true;
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            txtCheckedBy.Tag = detail.CheckedUser_ID;
                            txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        }

                        //fill item details
                        RefreshGrid(detail.DeliveryPlan_ID);
                        RefreshGridItems();

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

        #region Fill Route
        private void FillDetailsFromRoute(string sRouteID)
        {
            try
            {
                tbl_genRouteMaster route = tbl_genRouteMaster.Select(sRouteID);
                if (route != null && route.Route_ID != "default")
                {
                    List<tbl_sasCustomerOrder> details = tbl_sasCustomerOrder.SelectAll();
                    foreach (tbl_sasCustomerOrder detail in details)
                    {
                        if (detail.CustomerOrder_ID != "default" && !detail.IsDeleted && !detail.IsSeattled)
                        {


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
        #endregion



        #region Grid Event
        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "", sColName = "";
                decimal dUnitPrice = 0, dQuantity = 0;
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName == "OrderQty" || sColName == "IsSelect")
                {
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", e.RowIndex, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", e.RowIndex, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", e.RowIndex, "0");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", e.RowIndex, "0");

                    //Update Stock Balance
                    UpdateGridItemStockBalance(sItemID, sItemSub, sItemSub2, sSerial, sSerial2);

                    //Validate Order Qty exceeds
                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", e.RowIndex, decimal.Parse("0.00"));
                    tbl_sasCustomerOrder_Detail order = tbl_sasCustomerOrder_Detail.Select( 0, dgvDetail["CustomerOrderID", e.RowIndex].Value.ToString(), sItemID, sItemSub, sItemSub2, sSerial, sSerial2);
                    if (order != null && dQuantity > (order.Qty - order.QtySettle_DeliveryOrder))
                    {
                        dgvDetail["OrderQty", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(order.Qty - order.QtySettle_DeliveryOrder);
                    }

                    //Unslect all
                    if (bool.Parse(dgvDetail["IsHeader", e.RowIndex].Value.ToString()))
                    {
                        if (!bool.Parse(dgvDetail["IsSelect", e.RowIndex].Value.ToString()))
                            SelectOrUnselectForCustomerOrder(dgvDetail["CustomerOrderID", e.RowIndex].Value.ToString(), false);
                        //else
                        //    SelectOrUnselectForCustomerOrder(dgvDetail["CustomerOrderID", e.RowIndex].Value.ToString(), false);
                    }
                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00"));                   

                    if (dQuantity <= 0)
                        dgvDetail["IsSelect", e.RowIndex].Value = false;

                    dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                    dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                    dgvDetail["Amount", e.RowIndex].Tag = GetTotalPrice(dUnitPrice, dQuantity);
                    dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(GetTotalPrice(dUnitPrice, dQuantity));

                    CalcualteGrandTotalForCustomerOrder(dgvDetail["CustomerOrderID", e.RowIndex].Value.ToString());
                    CalcualteGrandTotal();
                    RefreshGridItems();
                }


                
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        private void dgvDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //dgvDetail_CellEndEdit(sender, e);
        }
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1")
                {

                    tbl_genItemMaster detail = tbl_genItemMaster.Select(dgvDetail["ItemCode", e.RowIndex].Value.ToString());
                    if (detail != null)
                    {
                        clsAlerts.DisplayItemViewer(detail.Item_ID, dgvDetail["ItemSubCategoryID1", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                        dgvDetail["ItemSerialNo1", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                    }
                }
            }
        }
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1")
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


                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1")
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Events DoubleClick
        private void txtSoteID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_MasterStore(ref txtSoteID, true);
        }

        private void FillDetailsByRoute(string sRoute)
        {
            List<tbl_sasCustomerOrder> oCOs = tbl_sasCustomerOrder.SelectAll();
            foreach (tbl_sasCustomerOrder oCO in oCOs)
            {
                if (!oCO.IsDeleted && !oCO.IsSeattled && !oCO.IsFinished && !ValidateCustomerOrder(oCO.CustomerOrder_ID))
                {
                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oCO.Customer_ID);
                    if (oCustomer != null)
                    {
                        bool bTownValid = false;
                        List<tbl_genRouteMaster_Town> oTowns = tbl_genRouteMaster_Town.SelectAllByRoute_ID(sRoute);
                        foreach (tbl_genRouteMaster_Town oTown in oTowns)
                        {
                            if (oCustomer.Town_ID == oTown.Town_ID)
                            {
                                bTownValid = true;
                                break;
                            }
                        }
                        if (bTownValid)
                        {
                            RefreshGridCustomerOrderID(oCO.CustomerOrder_ID);
                        }
                    }
                }

            }
        }
        private void txtRouteID_DoubleClick(object sender, EventArgs e)
        {
            if (txtSoteID.Tag != null)
            {
                clsSearch.Search_MasterRoute(ref txtRouteID);
                if (txtRouteID != null && txtRouteID.TextLength > 0)
                {
                    FillDetailsByRoute(txtRouteID.Tag.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please Select the Store Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoteID.Focus();
            }
        }
        private void txtRoot_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteID();
        }
        private void txtDeliveryPlanID_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_TransactionDeliveryPlan_Direct(ref txtDeliveryPlanID, chkShowSettle.Checked);
            if (txtDeliveryPlanID.Tag != null && txtDeliveryPlanID.Tag.ToString().Trim().Length > 0)
                FillDetails(txtDeliveryPlanID.Tag.ToString());
        }
        #endregion

        #region Events KeyDown
        private void txtRoot_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_RouteID();
            }
        }
        private void txtSoteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_MasterStore(ref txtSoteID, true);
            }
        }
        private void txtRouteID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                if (txtSoteID.Tag != null)
                {
                    clsSearch.Search_MasterRoute(ref txtRouteID);
                    if (txtRouteID != null && txtRouteID.TextLength > 0)
                    {
                        FillDetailsByRoute(txtRouteID.Tag.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Please Select the Store Name..........", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSoteID.Focus();
                }
            }
        }
        private void txtDeliveryPlanID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_TransactionDeliveryPlan_Direct(ref txtDeliveryPlanID, chkShowSettle.Checked);
                if (txtDeliveryPlanID.Tag != null && txtDeliveryPlanID.Tag.ToString().Trim().Length > 0)
                    FillDetails(txtDeliveryPlanID.Tag.ToString());
            }
        }
        #endregion





        #region Search Methods
        private void Search_RouteID()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_Route();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchText.Length > 0)
                txtRouteID.Text = frmSearchMaster.s_SearchText;
            if (frmSearchMaster.s_SearchID.Length > 0)
                txtRouteID.Tag = frmSearchMaster.s_SearchID;
        }
        #endregion

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string CustomerOrderID, string ItemID_Customer, string UomID, decimal UnitPrice, int LineNo, decimal TatalAmount, decimal Qty, string ItemSubCategoryID_Town, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string OrderRefdate, bool isHeader,
            decimal dDiscountPesentage, decimal dNBTPesentage, decimal dVATPesentage, decimal dOtherTaxPesentage)
        {
            try
            {
                //if the item already in the datagrid, only update weight and qty of the item.
                bool isNewItem = true;

                dgvDetail["CustomerOrderID", iRow].Value = CustomerOrderID;
                dgvDetail["ItemCode", iRow].Value = ItemID_Customer;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID_Customer);
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(UomID);
                dgvDetail["ItemSubCategoryID1", iRow].Tag = ItemSubCategoryID_Town;
                dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID_Town));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                dgvDetail["ItemSerialNo1", iRow].Value = SerialNo;
                dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["IsHeader", iRow].Value = isHeader;

                if (isNewItem)
                {
                    dgvDetail["UnitPrice", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(UnitPrice);
                }
                dgvDetail["OrderQty", iRow].Value = clsFormatter.FormatToNumberNoDecimal(Qty);
                dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);

                if (isHeader)
                {
                    dgvDetail["OrderQty", iRow].Value = ItemSubCategoryID2;
                    dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Customer(ItemID_Customer);
                    dgvDetail["ItemCode", iRow].Value = CustomerOrderID;
                    dgvDetail["BalanceQty", iRow].Value = OrderRefdate;
                    dgvDetail["IsHeader", iRow].Value = isHeader;
                    dgvDetail["IsSelect", iRow].Value = false;
                    dgvDetail["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(TatalAmount);
                    dgvDetail["ItemSubCategoryID1", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(ItemSubCategoryID_Town));

                    dgvDetail["discountPercentage", iRow].Tag = dDiscountPesentage;
                    dgvDetail["nbtPercentage", iRow].Tag = dNBTPesentage;
                    dgvDetail["vatPercentage", iRow].Tag = dVATPesentage;
                    dgvDetail["otherTaxPercentage", iRow].Tag = dOtherTaxPesentage;                    
                }
                else
                {
                    dgvDetail["IsSelect", iRow].Value = true;
                    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["OrderQty"].Index, iRow));
                }
                UpdateGridItemStockBalance(ItemID_Customer, ItemSubCategoryID_Town, ItemSubCategoryID2, SerialNo, SerialNo2);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtRouteID);
                clsCommon.ValidateForeignKey(ref txtCheckedBy);
                clsCommon.ValidateForeignKey(ref txtApprovedBy);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsMethods_GL.CheckValidity_FinancialYear(dtpDeliveryPlanDate.Value.Date))
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            bIsOk = true;
                        }
                    }
                }
            }
            return bIsOk;
        }
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;


            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        private bool ValidateCustomerOrder(string sCustomerOrderID)
        {         
            bool bExist = false;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                if (bool.Parse(dgvDetail["IsHeader", row.Index].Value.ToString()) && sCustomerOrderID == dgvDetail["CustomerOrderID", row.Index].Value.ToString())
                    bExist = true;
            }            

            if (bExist == true)
            {
               // MessageBox.Show("This Route is Already Existing In the DOP", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bExist;
        }
       
        #endregion

        #region Calculate Grand Total
        private void CalcualteGrandTotal()
        {
            try
            {
                decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (!bool.Parse(dgvDetail["IsHeader", x].Value.ToString()))
                    {
                        if (!bool.Parse(dgvDetail["IsHeader", x].Value.ToString()) && bool.Parse(dgvDetail["IsSelect", x].Value.ToString()))
                        {
                            if (clsCommon.isCurrency(dgvDetail["Amount", x].Value.ToString()))
                                Amount += decimal.Parse(dgvDetail["Amount", x].Value.ToString());
                        }
                    }
                }
                txtGrandTotal.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        } 
        #endregion

        #region Save Delivery Order
        private void AutoSaveDeliveryOrder()
        {
            tbl_sasDeliveryPlan oDOP = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
            if (oDOP != null)
            {
                ValidateEmptyForeignKey();
                List<tbl_sasDeliveryPlan_CustomerOrder> oDOPCOs = tbl_sasDeliveryPlan_CustomerOrder.SelectAllByDeliveryPlan_ID(txtDeliveryPlanID.Text.Trim());
                foreach (tbl_sasDeliveryPlan_CustomerOrder oDOPCO in oDOPCOs)
                {
                    string sDeliveryOrderID = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.CusDeliveryOrder));
                    string sInvoice = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.VATInvoice));
                    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oDOPCO.CustomerOrder_ID);
                    if (oCO != null)
                    {
                        #region Insert Delivery Order Header
                        tbl_sasDeliveryOrder oDO = new tbl_sasDeliveryOrder(sDeliveryOrderID, clsSecurity.getServerDateTime(), txtRemark.Text.Trim(),
                            oCO.DeliveryAddress,"", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), "", oCO.Customer_ID,
                            oDOPCO.CustomerOrder_ID, "default", "default", "default", "default", "default", txtSoteID.Tag.ToString(), oCO.Employee_ID, oCO.OrderRefNo_ID, "default",
                            oCO.Currency_ID, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID,  "default",
                            oCO.CurrencyRate, oDOPCO.DiscountPercentage, oDOPCO.NbtPercentage, oDOPCO.VatPercentage, oDOPCO.OtherTaxPercentage, oDOPCO.SubTotal,
                            oDOPCO.DiscountTotal, oDOPCO.NbtTotal, oDOPCO.VatTotal, oDOPCO.OtherTaxTotal, oDOPCO.GrandTotal, 0, 0, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(),
                             clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                            bHasChecked, bHasApproved, false, false, false, false, oCO.IsWeightCalculation, 0, false, false, oCO.IsFreeOrder, oCO.IsVAT, oCO.IsSVAT, "", "default", false, clsConfig.sItemUnitPriceCode_Default, clsSecurity.CompanyID, clsSecurity.BranchID, -1);
                        oDO.Insert();
                        #endregion

                        #region Update DeliveryPlan CustomerOrder
                        oDOPCO.DeliveryOrder_ID = sDeliveryOrderID;
                        oDOPCO.Update(); 
                        #endregion

                        #region Insert Delivery Order Detail
                        List<tbl_sasDeliveryPlan_CustomerOrder_Items> Details = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID_CustomerOrder_ID(txtDeliveryPlanID.Text.Trim(), oCO.CustomerOrder_ID);
                        foreach (tbl_sasDeliveryPlan_CustomerOrder_Items Detail in Details)
                        {
                            
                            if (Detail.Item_ID.Length > 0)
                            {
                                //tbl_sasDeliveryOrder_Detail items = new tbl_sasDeliveryOrder_Detail(1, sDeliveryOrderID, Detail.Item_ID, Detail.ItemSubCategory_ID,
                                //    Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, oCO.CustomerOrder_ID, "default", "default","default","", Detail.Qty, 0, 0, 0, Detail.Weight, 0, 0, 0,
                                //     Detail.UnitPrice, Detail.WeightPrice,false, 0, 0, Detail.TatalAmount, 0, 0, 0, 0, 0, "", false, !chkUnitPricing.Checked, false);
                                //items.Insert();

                                //////Update Customer Order
                                #region Update Customer Order
                                if (oCO.CustomerOrder_ID != "default")
                                {
                                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(Detail.Line_No, oCO.CustomerOrder_ID, Detail.Item_ID, Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2);
                                    if (CoItem != null)
                                    {
                                        if (chkUnitPricing.Checked)
                                            CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder + Detail.Qty;
                                        else
                                            CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder + Detail.Weight;
                                        CoItem.Update();
                                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oCO.CustomerOrder_ID, chkUnitPricing);
                                    }
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }               
            }
        }
        private void AutoSaveInvoice()
        {
            tbl_sasDeliveryPlan oDOP = tbl_sasDeliveryPlan.Select(txtDeliveryPlanID.Text.Trim());
            if (oDOP != null)
            {
                ValidateEmptyForeignKey();
                List<tbl_sasDeliveryPlan_CustomerOrder> oDOPCOs = tbl_sasDeliveryPlan_CustomerOrder.SelectAllByDeliveryPlan_ID(txtDeliveryPlanID.Text.Trim());
                foreach (tbl_sasDeliveryPlan_CustomerOrder oDOPCO in oDOPCOs)
                {                    
                    string sInvoice = "";
                    if (oDOPCO.OtherTaxTotal > 0)
                        sInvoice = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.SVATInvoice));
                    else if (oDOPCO.VatTotal > 0)
                        sInvoice = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.VATInvoice));
                    else
                        sInvoice = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.NonTaxInvoice));
                    
                    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oDOPCO.CustomerOrder_ID);
                    if (oCO != null)
                    {
                        #region Invoice Header
                        tbl_sasInvoice oInvoice = new tbl_sasInvoice(sInvoice, "default", clsSecurity.getServerDateTime(), txtRemark.Text.Trim(),
                            oCO.DeliveryAddress, clsCommon.CurrencyToWord(oDOPCO.GrandTotal), oCO.Customer_ID, "default", "default", oDOPCO.DeliveryOrder_ID, "default", oCO.Employee_ID, oCO.OrderRefNo_ID, "default",
                            oCO.Currency_ID, "default", clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsAutocode.getGLPostingStatusID(GLPostingStatus.NewTransaction), clsSecurity.FinancialYearID, "default",
                             oCO.CurrencyRate, oDOPCO.DiscountPercentage,0,0,0,oDOPCO.NbtPercentage, oDOPCO.VatPercentage, oDOPCO.OtherTaxPercentage, oDOPCO.SubTotal,
                            oDOPCO.DiscountTotal,0,0,0, oDOPCO.NbtTotal, oDOPCO.VatTotal, oDOPCO.OtherTaxTotal, oDOPCO.GrandTotal, 0, 0, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(),
                             clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), bHasChecked, bHasApproved, false,
                            false, "", "", "", clsSecurity.getServerDateTime().AddDays(60), false, 0, false, false, 0, false, false, false, false, false, oCO.IsWeightCalculation, false, oCO.IsVAT, oCO.IsSVAT, "default", "", "default",false, clsSecurity.CompanyID, clsSecurity.BranchID, false, 0, 0, 0, 0, 0, 0, 0, 0,0, -1);
                        oInvoice.Insert();
                        #endregion

                        #region Update DeliveryPlan CustomerOrder
                        oDOPCO.Invoice_ID = sInvoice;
                        oDOPCO.Update();
                        #endregion

                        #region Insert Invoice Detail
                        List<tbl_sasDeliveryPlan_CustomerOrder_Items> Details = tbl_sasDeliveryPlan_CustomerOrder_Items.SelectAllByDeliveryPlan_ID_CustomerOrder_ID(txtDeliveryPlanID.Text.Trim(), oCO.CustomerOrder_ID);
                        foreach (tbl_sasDeliveryPlan_CustomerOrder_Items Detail in Details)
                        {                            
                            if (Detail.Item_ID.Length > 0)
                            {
                              decimal  dAmmount = CalculateItemTotalPrice(Detail.Qty, Detail.UnitPrice);

                                tbl_sasInvoice_Detail items = new tbl_sasInvoice_Detail(1, sInvoice, Detail.Item_ID, Detail.ItemSubCategory_ID,
                                    Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, oDOPCO.DeliveryOrder_ID, oCO.Customer_ID, "default", "default", "default",
                                    Detail.Qty, 0, Detail.Weight, 0, Detail.UnitPrice, Detail.WeightPrice,false, 0, 0, dAmmount, 0, 0, 0, 0, 0, "", "default", 0);
                                items.Insert();

                                #region FIFO Price Calculation Insert
                             //   clsProcessMethods.FIFOPriceCalculation(0, Detail.Item_ID, Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2, Detail.Qty, Detail.Weight, sInvoice, oDOPCO.DeliveryOrder_ID, ProcessNote.Invoice, true, false, false);
                                #endregion

                                //////Update Other Tables
                                #region Update Delivery Order
                                if (oDOPCO.DeliveryOrder_ID != "default")
                                {
                                    //tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(oDOPCO.DeliveryOrder_ID, Detail.Item_ID, Detail.ItemSubCategory_ID, Detail.ItemSubCategory2_ID, Detail.ItemSerialNo, Detail.ItemSerialNo2);
                                    tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDOPCO.DeliveryOrder_ID).Where(r => r.Item_ID == Detail.Item_ID && r.ItemSubCategory_ID == Detail.ItemSubCategory_ID && r.ItemSubCategory2_ID == Detail.ItemSubCategory2_ID && r.ItemSerialNo == Detail.ItemSerialNo && r.ItemSerialNo2 == Detail.ItemSerialNo2).FirstOrDefault();
                                    if (chkUnitPricing.Checked)
                                        DoItem.QtySettle = DoItem.QtySettle + Detail.Qty;
                                    else
                                        DoItem.WeightSettle = DoItem.WeightSettle + Detail.Weight;
                                    DoItem.Update();
                                    clsProcessMethods.SetSettle_DeliveryOrder(oDOPCO.DeliveryOrder_ID, chkUnitPricing, false);
                                }
                                #endregion
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        private decimal CalculateItemTotalPrice(decimal dQty, decimal dUnitPrice)
        {
            return (dQty * dUnitPrice);
        }
        #endregion

        #region Calculate Metoeds
        private void CalcualteGrandTotalForCustomerOrder(string sCustomerOrder)
        {
            try
            {
                decimal dSubTotal = 0, dDiscountTotal = 0, dNBTTotal = 0, dVATTotal = 0, dOtherTaxTotal = 0, dGrandTotal = 0 ;                
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCustomerOrder);
                if (detail != null)
                {
                    for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    {
                        if (sCustomerOrder == dgvDetail["CustomerOrderID", x].Value.ToString())
                        {
                            if (!bool.Parse(dgvDetail["IsHeader", x].Value.ToString()) && bool.Parse(dgvDetail["IsSelect", x].Value.ToString()))
                            {
                                if (dgvDetail["Amount", x].Value != null && dgvDetail["Amount", x].Value.ToString().Length > 0)
                                {
                                    if (clsCommon.isCurrency(dgvDetail["Amount", x].Value.ToString()))
                                        dSubTotal += decimal.Parse(dgvDetail["Amount", x].Value.ToString());
                                }
                            }
                            else
                            {
                                dgvDetail["Amount", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                            }
                        }
                    }

                    //Calculate SubTotal, Taxes and Grand Total
                    //clsHelpMethods.CalculateGrandTotalForCustomerOrder(ref dSubTotal, detail.DiscountPercentage, ref dDiscountTotal, detail.NbtPercentage, ref dNBTTotal, detail.VatPercentage, ref dVATTotal, ref dOtherTaxTotal, ref dGrandTotal, detail.CustomerOrder_ID);


                    //Update the Customer Order Header
                    for (int x = 0; x < dgvDetail.Rows.Count; x++)
                    {
                        if (sCustomerOrder == dgvDetail["CustomerOrderID", x].Value.ToString() && bool.Parse(dgvDetail["IsHeader", x].Value.ToString()))
                        {
                            dgvDetail["Amount", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dSubTotal);

                            dgvDetail["discountPercentage", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountTotal);
                            dgvDetail["nbtPercentage", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dNBTTotal);
                            dgvDetail["vatPercentage", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dVATTotal);
                            dgvDetail["otherTaxPercentage", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dOtherTaxTotal);
                            dgvDetail["grandTotal", x].Value = clsFormatter.FormatToCurrecyWithThousendSep(dGrandTotal);

                            dgvDetail["discountPercentage", x].Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.DiscountPercentage);
                            dgvDetail["nbtPercentage", x].Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.NbtPercentage);
                            dgvDetail["vatPercentage", x].Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.VatPercentage);
                            dgvDetail["otherTaxPercentage", x].Tag = clsFormatter.FormatToCurrecyWithThousendSep(detail.OtherTaxTotal);                            
                            
                            if (dSubTotal > 0)
                                dgvDetail["IsSelect", x].Value = true;
                            else
                                dgvDetail["IsSelect", x].Value = false;
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
        private void SelectOrUnselectForCustomerOrder(string sCustomerOrder, bool bSelect)
        {
            try
            {
                //decimal Amount = 0;
                for (int x = 0; x < dgvDetail.Rows.Count; x++)
                {
                    if (sCustomerOrder == dgvDetail["CustomerOrderID", x].Value.ToString())
                    {
                        if (!bool.Parse(dgvDetail["IsHeader", x].Value.ToString()))
                            dgvDetail["IsSelect", x].Value = bSelect;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private static decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }
        private void UpdateGridItemStockBalance(string ItemID, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2)
        {
            decimal dGridItemQTY = 0, dBalanceQty = 0, dGridbalanceQTY, dGridQuantity;
            if (txtSoteID.Tag != null)
            {
                dBalanceQty = clsHelpMethods_Local.Get_StoreStockBalance_Qty(txtSoteID.Tag.ToString(), ItemID, "default", ItemSubCategoryID, ItemSubCategoryID2, SerialNo, SerialNo2);
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    string sItemID = "", sItemSub = "", sItemSub2 = "", sSerial = "", sSerial2 = "";
                    bool bIsSelect;
                    sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "default");
                    sItemSub = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID1", row.Index, "default");
                    sItemSub2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                    sSerial = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo1", row.Index, "");
                    sSerial2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "");
                    bIsSelect = bool.Parse(dgvDetail["IsSelect", row.Index].Value.ToString());
                    dGridQuantity = clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row.Index, decimal.Parse("0.00"));

                    if (ItemID == sItemID && ItemSubCategoryID == sItemSub && ItemSubCategoryID2 == sItemSub2 && SerialNo == sSerial && SerialNo2 == sSerial2)
                    {
                        if (ItemID.Length > 0)
                        {
                            dgvDetail["BalanceQty", row.Index].Value = clsFormatter.FormatToNumberNoDecimal(dBalanceQty - dGridItemQTY);
                            if (bIsSelect)
                                dGridItemQTY += clsValidate.ValidateGridValue(dgvDetail, "OrderQty", row.Index, decimal.Parse("0.00"));
                            else
                                dgvDetail["BalanceQty", row.Index].Value = clsFormatter.FormatToNumberNoDecimal(dBalanceQty - dGridItemQTY);

                            dGridbalanceQTY = clsValidate.ValidateGridValue(dgvDetail, "BalanceQty", row.Index, decimal.Parse("0.00"));

                            if (dGridbalanceQTY >= dGridQuantity)
                            {
                                //dgvDetail["BalanceQty", row.Index].Value = clsFormatter.FormatToNumberNoDecimal(dbalanceQTY);
                                //dgvDetail["IsSelect", row.Index].Value = true;
                            }
                            else
                            {
                                dgvDetail["IsSelect", row.Index].Value = false;
                                dgvDetail["BalanceQty", row.Index].Value = clsFormatter.FormatToNumberNoDecimal(0);
                            }

                        }
                    }
                }
            }
        }
        #endregion

        private void frm_sasDeliveryPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            Attachments.Close();
        }
    }
}