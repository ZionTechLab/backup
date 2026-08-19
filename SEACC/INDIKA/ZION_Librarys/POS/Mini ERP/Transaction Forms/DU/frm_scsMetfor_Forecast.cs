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
using System.Threading.Tasks;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_scsMetfor_Forecast : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        static bool bIsWeightCalculation = false;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        //to keep glob ref no        
        public string glbMRP_ID = "";

        //form manage
        string sFormConfigCode;
           public int iFormID;
        #endregion 

        #region Form Load
        public frm_scsMetfor_Forecast()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.MatforForecast);
            iFormID = clsSecurity.getFormID(FormName.MatforForecast);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_scsMetfor_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format  
            clsFormatter.setFormatForm(this, "MRP Forecast - [Material Requirement Planning]", 4, iFormID);
            //clsFormatter.FormatProcessFlow(txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder, txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);

            ClearFields();
            if (glbMRP_ID.Length > 0)
            {
                FillDetails(glbMRP_ID);
            }

            CusDataGridViewFormat();
        } 
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
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
                        //tbl_sasCustomerOrder oldRecord = tbl_sasCustomerOrder.Select(txtCustomerOrderID.Text.Trim());
                        //if (oldRecord != null && clsValidate.CheckPrintingValidity(oldRecord.PrintCount))
                        //{
                        //    if (!oldRecord.IsLocked && !oldRecord.IsApproved && !oldRecord.IsFinished && !oldRecord.IsDeleted)
                        //    {
                        //        //Customer Order Detail      
                        //        //-----------------------------
                        //        #region Update Old Co items
                        //        List<tbl_sasCustomerOrder_Detail> oldCoDetails = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(txtCustomerOrderID.Text.Trim());
                        //        foreach (tbl_sasCustomerOrder_Detail oldCoDetail in oldCoDetails)
                        //        {
                        //            string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                        //            decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0;
                        //            bool bHasItemInDB = false;

                        //            foreach (DataGridViewRow row in dgvDetail.Rows)
                        //            {


                        //                sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        //                sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                        //                sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                        //                sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                        //                dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        //                dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        //                dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        //                dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        //                dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                        //                sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        //                sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        //                sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        //                sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        //                sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");


                        //                if (oldCoDetail.CustomerOrder_ID == txtCustomerOrderID.Text.Trim() && oldCoDetail.Item_ID == sItemCode && oldCoDetail.ItemSubCategory_ID == sItemSubCategoryID &&
                        //                oldCoDetail.ItemSubCategory2_ID == sItemSubCategoryID2 && oldCoDetail.ItemSerialNo == sItemSerialNo && oldCoDetail.ItemSerialNo2 == sItemSerialNo2)
                        //                {
                        //                    bHasItemInDB = true;
                        //                    dgvDetail.Rows.RemoveAt(row.Index);
                        //                    break; //database contain this item
                        //                }

                        //            }

                        //            if (bHasItemInDB)
                        //            {
                        //                //Get Unit Price with Exchange rate to save
                        //                dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                        //                dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                        //                dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                        //                //////Update Inquiry/Quotation 
                        //                // Don't put this region, under the old recode update statment
                        //                #region Update Inquiry/Quotation
                        //                if (sInquiryCode != "default")
                        //                {
                        //                    tbl_sasInquiry_Detail inqItem = tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        //                    if (inqItem != null)
                        //                    {
                        //                        if (chkUnitPricing.Checked)
                        //                            inqItem.QtySettle = (inqItem.QtySettle - oldCoDetail.Qty) + dQuantity;
                        //                        else
                        //                            inqItem.WeightSettle = (inqItem.WeightSettle - oldCoDetail.Weight) + dWeight;
                        //                        inqItem.Update();
                        //                        clsProcessMethods.SetSettle_Inquiry(sInquiryCode, chkUnitPricing);
                        //                    }
                        //                }
                        //                if (sQuotationCode != "default")
                        //                {
                        //                    tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.Select(sQuotationCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        //                    if (inqItem != null)
                        //                    {
                        //                        if (chkUnitPricing.Checked)
                        //                            inqItem.QtySettle_CustomerOrder = (inqItem.QtySettle_CustomerOrder - oldCoDetail.Qty) + dQuantity;
                        //                        else
                        //                            inqItem.WeightSettle_CustomerOrder = (inqItem.WeightSettle_CustomerOrder - oldCoDetail.Weight) + dWeight;
                        //                        inqItem.Update();
                        //                        clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(sQuotationCode, chkUnitPricing);
                        //                    }
                        //                }
                        //                #endregion

                        //                oldCoDetail.Item_ID = sItemCode;
                        //                oldCoDetail.PurchaseOrder_ID = txtPurchaseOrder.Text.Trim();
                        //                oldCoDetail.Inquiry_ID = sInquiryCode;
                        //                oldCoDetail.Quotation_ID = sQuotationCode;
                        //                oldCoDetail.Job_ID = sJobCode;
                        //                oldCoDetail.Qty = dQuantity;
                        //                oldCoDetail.Weight = dWeight;
                        //                oldCoDetail.UnitPrice = dUnitPrice;
                        //                oldCoDetail.WeightPrice = dWeightPrice;
                        //                oldCoDetail.TatalAmount = dAmount;
                        //                oldCoDetail.Remark = sRemarks;
                        //                oldCoDetail.IsWeightCalculation = !chkUnitPricing.Checked;
                        //                oldCoDetail.Update();
                        //            }
                        //            else
                        //            {
                        //                oldCoDetail.Delete();
                        //            }
                        //        }
                        //        #endregion

                        //        #region insert Newly Added Data
                        //        foreach (DataGridViewRow row in dgvDetail.Rows)
                        //        {
                        //            string sItemCode = "", sInquiryCode = "", sQuotationCode = "", sJobCode = "", sRemarks = "",
                        //                sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "";
                        //            decimal dUnitPrice = 0, dQuantity = 0, dWeight = 0, dAmount = 0, dWeightPrice = 0, dRecommendedUnitPrice = 0,
                        //                dRecommendedWeightPrice = 0, dRecommendedAmount = 0;

                        //            sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                        //            sInquiryCode = clsValidate.ValidateGridValue(dgvDetail, "InquiryCode", row.Index, "default");
                        //            sQuotationCode = clsValidate.ValidateGridValue(dgvDetail, "QuotationCode", row.Index, "default");
                        //            sJobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", row.Index, "default");
                        //            dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                        //            dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                        //            dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", row.Index, decimal.Parse("0.00"));
                        //            dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", row.Index, decimal.Parse("0.00"));
                        //            dAmount = clsValidate.ValidateGridValue(dgvDetail, "Amount", row.Index, decimal.Parse("0.00"));
                        //            sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                        //            sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                        //            sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                        //            sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                        //            sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");
                        //            dRecommendedUnitPrice = clsHelpMethods.GetRecommendedUnitPrice(sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        //            dRecommendedWeightPrice = clsHelpMethods.GetRecommendedWeightPrice(sItemCode);
                        //            if (chkUnitPricing.Checked)
                        //                dRecommendedAmount = dRecommendedUnitPrice * dQuantity;
                        //            else
                        //                dRecommendedAmount = dRecommendedWeightPrice * dWeight;

                        //            //Get Unit Price with Exchange rate to save
                        //            dUnitPrice = clsHelpMethods.getSavePrice(dUnitPrice, txtCurrencyRate);
                        //            dWeightPrice = clsHelpMethods.getSavePrice(dWeightPrice, txtCurrencyRate);
                        //            dAmount = clsHelpMethods.getSavePrice(dAmount, txtCurrencyRate);

                        //            if (sItemCode.Length > 0)
                        //            {
                        //                tbl_sasCustomerOrder_Detail items = new tbl_sasCustomerOrder_Detail(row.Index, txtCustomerOrderID.Text.Trim(), sItemCode,
                        //                    sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2, txtPurchaseOrder.Text.Trim(), sInquiryCode, "default", sQuotationCode, sJobCode, dQuantity, 0, 0,
                        //                    dWeight, 0, 0, dUnitPrice, dWeightPrice, 0, 0, dAmount, dRecommendedUnitPrice, dRecommendedWeightPrice, dRecommendedAmount, sRemarks, false, !chkUnitPricing.Checked);
                        //                items.Insert();

                        //                //////Update Inquiry/Quotation
                        //                #region Update Inquiry/Quotation
                        //                if (sInquiryCode != "default")
                        //                {
                        //                    tbl_sasInquiry_Detail inqItem = tbl_sasInquiry_Detail.Select(sInquiryCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        //                    if (chkUnitPricing.Checked)
                        //                        inqItem.QtySettle = inqItem.QtySettle + dQuantity;
                        //                    else
                        //                        inqItem.WeightSettle = inqItem.WeightSettle + dWeight;
                        //                    inqItem.Update();
                        //                    clsProcessMethods.SetSettle_Inquiry(sInquiryCode, chkUnitPricing);
                        //                }
                        //                if (sQuotationCode != "default")
                        //                {
                        //                    tbl_sasQuotation_Detail inqItem = tbl_sasQuotation_Detail.Select(sQuotationCode, sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2);
                        //                    if (chkUnitPricing.Checked)
                        //                        inqItem.QtySettle_CustomerOrder = inqItem.QtySettle_CustomerOrder + dQuantity;
                        //                    else
                        //                        inqItem.WeightSettle_CustomerOrder = inqItem.WeightSettle_CustomerOrder + dWeight;
                        //                    inqItem.Update();
                        //                    clsProcessMethods.SetSettle_QuotationFrom_CustomerOrder(sQuotationCode, chkUnitPricing);
                        //                }
                        //                #endregion
                        //            }
                        //        }
                        //        #endregion

                        //        //--------------------------------
                        //        //Customer Order Header
                        //        #region Update Co Header

                        //        tbl_sasCustomerOrder detail = new tbl_sasCustomerOrder(txtCustomerOrderID.Text.Trim(), dtpCustomerOrderDate.Value, txtRemark.Text.Trim(),
                        //            txtAddressDelivery.Text.Trim(), dtpDeliveryDate.Value, oldRecord.OrderRefNo_ID, txtCustomerID.Tag.ToString(), txtPurchaseOrder.Text.Trim(),
                        //            "default", "default", txtQuotationID.Tag.ToString(), txtJobCode.Tag.ToString(), txtStoreID.Tag.ToString(), txtSalesExecutiveID.Tag.ToString(), txtCurrencyID.Tag.ToString(),
                        //            oldRecord.GlPosting_ID, oldRecord.PostingStatus_ID, oldRecord.FinancialYear_ID, oldRecord.CompanyID, decimal.Parse(txtCurrencyRate.Text.Trim()),
                        //            decimal.Parse(txtPercentageDiscount.Text.Trim()), decimal.Parse(txtPercentageNBT.Text.Trim()), decimal.Parse(txtPercentageVat.Text.Trim()),
                        //            decimal.Parse(txtPercentageOtherTax.Text.Trim()), clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtDiscount.Text.Trim()), txtCurrencyRate),
                        //            clsHelpMethods.getSavePrice(decimal.Parse(txtNBT.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtVat.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtOtherTax.Text.Trim()), txtCurrencyRate),
                        //            clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtAdvanceAmount.Text.Trim()), txtCurrencyRate),
                        //            clsHelpMethods.getSavePrice(decimal.Parse(txtSubTotal_Rec.Text.Trim()), txtCurrencyRate), clsHelpMethods.getSavePrice(decimal.Parse(txtGrandTotal_Rec.Text.Trim()), txtCurrencyRate), oldRecord.CreateUser_ID,
                        //            clsSecurity.UserIDLoged, oldRecord.CheckedUser_ID, oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID,
                        //                            oldRecord.CreateTerminal_ID, clsSecurity.TerminalID, oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate,
                        //            clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished,
                        //            oldRecord.IsDeleted, oldRecord.IsLocked, oldRecord.IsDoneProductionJob, oldRecord.IsSeattled, !chkUnitPricing.Checked, oldRecord.PrintCount, chkReverseCalculation.Checked,
                        //            chkFreeOrder.Checked, clsHelpMethods.isTaxActiveNote(txtVat), clsHelpMethods.isTaxActiveNote(txtOtherTax));
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
                            txtMRPID.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                        //create order ref number
                        if (txtOrderRefNo.Tag == null || txtOrderRefNo.Tag.ToString().Trim() == "default")
                        {
                            txtOrderRefNo.Tag = clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.zOrderRefNo));
                            tbl_zOrderRefNo orf = new tbl_zOrderRefNo(txtOrderRefNo.Tag.ToString(), txtOrderRefNo.Text.Trim(), "default", "default", "default", "default", true);
                            orf.Insert();
                        }

                        if (txtMRPID.TextLength > 0)
                        {                            
                            #region Insert Header
                            tbl_scsMatfor detail = new tbl_scsMatfor(txtMRPID.Text.Trim(), clsSecurity.getServerDateTime(), txtRemark.Text.Trim(), txtMRPTitle.Text.Trim(), 
                                dtpMRPDateStart.Value, dtpMRPDateEnd.Value, txtMRPCategory.Tag.ToString(), txtOrderRefNo.Tag.ToString(),
                                clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                bHasChecked, bHasApproved, false, false, false, false, !chkUnitPricing.Checked, 0);
                            detail.Insert();
                            #endregion
                                                     
                            #region Insert Detail
                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                try
                                {
                                    string sItemCode = "", sItemSubCategoryID = "", sItemSubCategoryID2 = "", sItemSerialNo = "", sItemSerialNo2 = "", sRemarks = "";
                                    decimal dPlannedQty = 0, dQuantity = 0, dWeight = 0, dPlannedWeight = 0;

                                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", row.Index, "");
                                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", row.Index, decimal.Parse("0.00"));
                                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", row.Index, decimal.Parse("0.00"));
                                    sItemSubCategoryID = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", row.Index, "default");
                                    sItemSubCategoryID2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", row.Index, "default");
                                    sItemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", row.Index, "0");
                                    sItemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", row.Index, "0");
                                    sRemarks = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                                    dPlannedQty = clsValidate.DecimalValidate(txtTotalQty);
                                    dPlannedWeight = clsValidate.DecimalValidate(txtTotalWeight);

                                    if (sItemCode.Length > 0)
                                    {
                                        tbl_scsMatfor_Detail items = new tbl_scsMatfor_Detail(row.Index, txtMRPID.Text.Trim(), sItemCode, sItemSubCategoryID, sItemSubCategoryID2, sItemSerialNo, sItemSerialNo2,
                                            dPlannedQty, 0, dQuantity, 0, dPlannedWeight, 0, dWeight, 0, sRemarks);
                                        items.Insert();


                                    }
                                }
                                catch (Exception ex)
                                {
                                    clsValidate.WriteErrorLog("", iFormID,ex);
                                    SEACCException.Show(ex);
                                }//error may come because last row of the grid may not have information
                            } 
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("MRP Code " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                    tbl_scsMatfor oldRecord = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                    ClearFields();
                    if (oldRecord != null)
                        FillDetails(oldRecord.Mrp_ID);
                }
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMRPID.TextLength > 0 && txtMRPID.Text != "<Auto Generate>")
                {
                    //update receipt
                    string sCreateUser = "", sCheckedUser = "", sApprovedUser = "";
                    tbl_scsMatfor oOrder = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                    if (oOrder != null)
                    {
                        oOrder.PrintCount++;
                        oOrder.DatePrinted = clsSecurity.getServerDateTime();
                        oOrder.PrintedTerminal_ID = clsSecurity.TerminalID;
                        oOrder.PrintedUser_ID = clsSecurity.UserIDLoged;

                        sCreateUser = "[ " + clsGenaralName.getName_User(oOrder.CreateUser_ID) + " ] [ " + oOrder.DateCreate.ToShortDateString() + " ]";
                        if (oOrder.CheckedUser_ID != "default")
                            sCheckedUser = "[ " + clsGenaralName.getName_User(oOrder.CheckedUser_ID) + " ] [ " + oOrder.DateChecked.ToShortDateString() + " ]";
                        if (oOrder.ApprovedUser_ID != "default")
                            sApprovedUser = "[ " + clsGenaralName.getName_User(oOrder.ApprovedUser_ID) + " ] [ " + oOrder.DateApproved.ToShortDateString() + " ]";
                        oOrder.Update();
                    }

                    Cursor = Cursors.WaitCursor;
                    string s_Path = "", sReportTitle = "CUSTOMER ORDER", sFormula = "";
                    if (txtMRPID.TextLength > 0)
                        sFormula = "{vw_rpt_sasCustomerOrder.customerOrder_ID} = '" + txtMRPID.Text.Trim() + "'";

                    ReportDocument RD = new ReportDocument();
                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithDimension.ToString())
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderWD.rpt";
                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderWD.rpt";
                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithoutDimension.ToString())
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderWOD.rpt";
                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.ePackWithSubCategory.ToString())
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderWSC.rpt";
                    else if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderAPL.rpt";
                    else
                        s_Path += "\\reports\\SAS\\NotePrinting\\rpt_sasCustomerOrderWSC.rpt";


                    frm_ReportViewer viewer = new frm_ReportViewer();
                    RD.Load(s_Path);
                    clsSecurity.LogonServer(ref RD);
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
                    

                    if (clsConfig.bDirectPrint_NP_CustomerOrder) //Direct Print
                    {
                        RD.DataDefinition.RecordSelectionFormula = sFormula;
                        clsHelpMethods.SetPrinterSetting(clsAutocode.getReportID(enum_ReportName.NP_CustomerOrder), ref RD);
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
                else
                    MessageBox.Show("Please Select the Customer Order To Print Report", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region Btn Option
        private void btnOption_Click(object sender, EventArgs e)
        {
            frmOption op = new frmOption();
            op.ShowDialog();

            if (frmOption.bEMail)
            {
                //sendEmail();
            }
            else if (frmOption.bSMS)
            {

            }
            else if (frmOption.bCancel)
            {
                //cancelOrder();
            }
            else if (frmOption.bPrint)
            {

            }
            else
            {

            }
        } 
        #endregion

        #region Btn Checking
        private void btnChecking_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToChecked(clsSecurity.UserIDLoged, iFormID))
            {
                bHasChecked = true;
                glbCheckedDate = clsSecurity.getServerDateTime();
                dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                txtCheckedBy.Text = clsSecurity.UserNameLoged;
                txtCheckedBy.Tag = clsSecurity.UserIDLoged;
                clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);

                if (IsUpdate)
                {
                    tbl_scsMatfor objCO = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                    if (objCO != null)
                    {
                        objCO.IsChecked = true;
                        objCO.DateChecked = clsSecurity.getServerDateTime();
                        objCO.CheckedUser_ID = clsSecurity.UserIDLoged;
                        objCO.Update();
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
                glbApprovedDate = clsSecurity.getServerDateTime();
                dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                txtApprovedBy.Text = clsSecurity.UserNameLoged;
                txtApprovedBy.Tag = clsSecurity.UserIDLoged;
                clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);

                if (IsUpdate)
                {
                    tbl_scsMatfor objCO = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                    if (objCO != null)
                    {
                        objCO.IsApproved = true;
                        objCO.DateApproved = clsSecurity.getServerDateTime();
                        objCO.ApprovedUser_ID = clsSecurity.UserIDLoged;
                        objCO.Update();
                    }
                }

            }
            else
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToApprove), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Stop);
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



        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            clsFormatter.ApplyGridFormat(dgvCustomerWise, clsFormatter.colorDigiteqTheamColorStock2, clsFormatter.colorDigiteqTheamColorStockForColour);           

            //Change Grid Format            
            dgvDetail.Columns["Weight"].Visible = true;
            dgvDetail.Columns["Quantity"].Visible = false;
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            lblCancelled.Visible = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtMRPID, true);            
            clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblMPRID, true);            
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, true);

            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);


            txtMRPCategory.Tag = null;
            txtItemID.Tag = null;
            txtItemSubCategory.Tag = null;
            txtItemSerialNo.Tag = null;
            txtOrderRefNo.Tag = null;
            txtPreparedBy.Tag = null;
            txtCheckedBy.Tag = null;
            txtApprovedBy.Tag = null;
      
          
            txtItemID.Clear();
            txtMRPCategory.Clear();
            txtMRPTitle.Text = "MRP - " + clsSecurity.getServerDateTime().ToString("dd-MM-yyyy");
            txtOrderRefNo.Clear();
            txtRemark.Clear();         
            txtOrderRefNo.Clear();
            txtItemID.Clear();
            txtItemSubCategory.Clear();
            txtItemSerialNo.Clear();

            chkUnitPricing.Checked = true;
            chkReverseCalculation.Checked = false;
            chkShowSettle.Checked = false;
            dtpMRPDateStart.Value = clsSecurity.getServerDateTime();
            dtpMRPDateEnd.Value = clsSecurity.getServerDateTime().AddMonths(1);

            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            txtPreparedBy.Clear();
          
            dgvDetail.Rows.Clear();
            dgvCustomerWise.Rows.Clear();
         
            chkReverseCalculation.Enabled = true;
            chkSettings.Checked = true;
           

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtMRPID.Text = "<Auto Generate>";
            else
                txtMRPID.Clear();
            if (txtMRPID.Enabled)
            {
                txtMRPID.SelectAll();
                txtMRPID.Focus();
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sMRP_ID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_scsMatfor_Detail> details = tbl_scsMatfor_Detail.SelectAllByMrp_ID(sMRP_ID);
                foreach (tbl_scsMatfor_Detail detail in details)
                {
                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        dgvDetail.Rows.Add();
                        iRow = dgvDetail.Rows.Count - 1;                       
                        Fill_Datagrid(iRow, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2, item.Uom_ID, detail.WeightAdjusted, detail.QtyAdjusted, item.MinStockLevel, detail.Remark);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void RefreshGridByItemIDandMRPID(string sItem_ID, string sSubCategory_ID, string sSubCategory2_ID, string sSerialNo, string sSerialNo2, string sMRP_ID)
        {
            try
            {
                int iRow;
                dgvDetail.Rows.Clear();
                List<tbl_scsMatfor_Entry_Detail_RwMaterial> details = tbl_scsMatfor_Entry_Detail_RwMaterial.SelectAllByMrp_ID_itemID_itemSubCategoryID_itemSubCategory2ID_itemSerialNo_ItemSerialNo2(sMRP_ID, sItem_ID, sSubCategory_ID, sSubCategory2_ID, sSerialNo, sSerialNo2);
                foreach (tbl_scsMatfor_Entry_Detail_RwMaterial detail in details)
                {
                    tbl_scsMatfor_Entry_Detail oEntry = tbl_scsMatfor_Entry_Detail.Select(detail.Line_No, detail.Employee_ID, detail.Mrp_ID);
                    if (oEntry != null)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null)
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            Fill_Datagrid_Customers(iRow, oEntry.Customer_ID, oEntry.BrandName, detail.Qty, detail.Weight, oEntry.Employee_ID, detail.Weight > 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void RefreshGridByItemID(string sItem_ID, string sSubCategory_ID, string sSubCategory2_ID, string sSerialNo, string sSerialNo2)
        {
            try
            {
                int iRow;
                dgvCustomerWise.Rows.Clear();

                tbl_genItemMaster item = tbl_genItemMaster.Select(sItem_ID);
                if (item != null)
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    Fill_Datagrid(iRow, sItem_ID, sSubCategory_ID, sSubCategory2_ID, sSerialNo, sSerialNo2, item.Uom_ID, 0, 0, item.MinStockLevel, "");
                }              
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
                    tbl_scsMatfor detail = tbl_scsMatfor.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        if (detail.IsDeleted)
                            lblCancelled.Visible = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtMRPID, false);
                        clsCommon.SetEnableDisable_NormalTextbox(txtOrderRefNo, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblMPRID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefNo, false);

                        //fill order detials
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(detail.OrderRefNo_ID);
                        if (order != null)
                        {
                            txtOrderRefNo.Tag = detail.OrderRefNo_ID;
                            txtOrderRefNo.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_OrderRefNo(detail.OrderRefNo_ID));
                          }

                        //asign values
                        txtMRPCategory.Tag = detail.MrpCategory_ID;
                        txtMRPCategory.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_MRPCateogry(detail.MrpCategory_ID));

                        txtMRPID.Text = detail.Mrp_ID;
                        txtRemark.Text = detail.Remark;
                        txtMRPTitle.Text = detail.MrpTitle;
                       
                        dtpMRPDateStart.Value = detail.MrpStartDate;
                        dtpMRPDateEnd.Value = detail.MrpEndDate;                       
                        chkUnitPricing.Checked = !detail.IsWeightCalculation;
                        chkSettings.Checked = false;


                        //User Security
                        txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));
                        dtpDatePreparedBy.Value = detail.DateCreate;
                        dtpTimePreparedBy.Value = detail.DateCreate;

                        if (detail.IsApproved)
                        {
                            bHasApproved = true;
                            glbApprovedDate = detail.DateApproved;
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
                            glbCheckedDate = detail.DateChecked;
                            dtpDateCheckedBy.Value = detail.DateChecked;
                            dtpTimeCheckedBy.Value = detail.DateChecked;
                            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                            txtCheckedBy.Tag = detail.CheckedUser_ID;
                            txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                        }

                        //fill item details
                        RefreshGrid(detail.Mrp_ID);                       

                        ////Set Flow
                        //clsHelpMethods.SetProcessFlow(detail.OrderRefNo_ID, txtFlowInquiry, txtFlow2Quotation, txtFlow2PInvoice, txtFlowCustomerOrder, txtFlow2CustomerOrder,
                        //   txtFlowDeliveryOrder, txtFlow3DeliveryOrder, txtFlowInvoice, txtFlow3Invoice, txtFlowReceipt, txtFlowProductionJob, txtFlowSalesReturned, chkSettings);
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

        #region Fill Datagrid
        private void Fill_Datagrid(int iRow, string ItemID, string ItemSubCategoryID, string ItemSubCategoryID2, string SerialNo, string SerialNo2, string UomID, decimal Weight, decimal Qty, decimal MinReOrderLevel, string Remark)
        {
            try
            {
                //if the item already in the datagrid, only update weight and qty of the item.
               // bool isNewItem = true;
                decimal dGRNPendingQty = 0, dStockBalance = 0;
                //dStockBalance = clsHelpMethods.Get_StoreStockBalance_Weight_AllStores(ItemID, ItemSubCategoryID, ItemSubCategoryID2, SerialNo, SerialNo2);
                dGRNPendingQty = clsHelpMethods.Get_PendingGRN_Weight(ItemID, ItemSubCategoryID, ItemSubCategoryID2, SerialNo, SerialNo2);
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

                dgvDetail["ItemCode", iRow].Value = ItemID;
                dgvDetail["ItemName", iRow].Value = clsGenaralName.getName_Item(ItemID);              
                dgvDetail["UOM", iRow].Value = clsGenaralName.getName_Uom(UomID);
                dgvDetail["ItemSubCategoryID", iRow].Tag = ItemSubCategoryID;
                dgvDetail["ItemSubCategoryID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(ItemSubCategoryID));
                dgvDetail["ItemSubCategoryID2", iRow].Tag = ItemSubCategoryID2;
                dgvDetail["ItemSubCategoryID2", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(ItemSubCategoryID2));
                dgvDetail["ItemSerialNo", iRow].Value = SerialNo;
                dgvDetail["ItemSerialNo2", iRow].Value = SerialNo2;
                dgvDetail["Remarks", iRow].Value = Remark;


                dgvDetail["PendingGRNQty", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dGRNPendingQty);
                dgvDetail["MinREOLevel", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(MinReOrderLevel);
                dgvDetail["StockBalanceQty", iRow].Value = clsFormatter.FormatToNumberWithOneDecimalPlaces(dStockBalance);
                dgvDetail["Weight", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(Weight);
                dgvDetail["Quantity", iRow].Value = clsFormatter.FormatDecimalPlaces_Quantity(Qty);                

                //if (bHasSettled)
                //    dgvDetail_CellEndEdit(dgvDetail, new DataGridViewCellEventArgs(dgvDetail.Columns["Quantity"].Index, iRow));
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Fill_Datagrid_Customers(int iRow, string sCustomerName, string sFGBrandName, decimal dForecastQty, decimal dForecastWeight, string sSalesMan, bool bIsWeightCalculation)
        {
            try
            {                
                dgvCustomerWise["CustomerID", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(sCustomerName));
                dgvCustomerWise["SalesRep", iRow].Tag = SalesRep;
                dgvCustomerWise["SalesRep", iRow].Value = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(sSalesMan));
                dgvCustomerWise["FGBrand", iRow].Value = FGBrand;
                if (bIsWeightCalculation)
                    dgvCustomerWise["PlannedQty", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dForecastWeight);
                else
                    dgvCustomerWise["PlannedQty", iRow].Value = clsFormatter.FormatDecimalPlaces_Weight(dForecastQty);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool ValidateSave()
        {
            bool bIsOk = false;
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (CheckItemSettleValidity())
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

            if (txtMRPTitle.TextLength == 0)
            {
                strMessage += "\n" + "MRP Title ";
                bStatus = false;
            }          
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckItemSettleValidity()
        {
            bool rtn = true;
           
            return rtn;
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


        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtMRPCategory);
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



        #region Events KeyDown
        private void txtMRPID_KeyDown(object sender, KeyEventArgs e)
        {
            Search_MRPID();
        }

        private void txtItemID_KeyDown(object sender, KeyEventArgs e)
        {
            clsHelpMethods.SearchItemAdvanceByKeyPress(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo, e);
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                btnAddItem_Click(sender, new EventArgs());
        }

        private void txtMRPCategory_KeyDown(object sender, KeyEventArgs e)
        {
            Search_MRPCategory();
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

        private void frm_scsMetfor_Forecast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        #region Events DoubleClick
        private void txtMRPID_DoubleClick(object sender, EventArgs e)
        {
            Search_MRPID();
        }

        private void txtItemID_DoubleClick(object sender, EventArgs e)
        {
            clsHelpMethods.SearchItemAdvance(ref txtItemID, ref txtItemSubCategory, ref txtItemSerialNo);
            if (txtItemID.Tag != null && txtItemID.Tag.ToString().Trim().Length > 0) //call add button
                btnAddItem_Click(sender, new EventArgs());
        }

        private void txtMRPCategory_DoubleClick(object sender, EventArgs e)
        {
            Search_MRPCategory();
        }

        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }

        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        } 
        #endregion

        #region Events Datagried
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

            }
        }
        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {              

                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName != "Quantity" && sColName != "Weight")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                        dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                        dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
            }
        }
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                DataGridView dgv = (DataGridView)sender;
                if (e.ColumnIndex >= 0)
                    sColName = dgv.Columns[e.ColumnIndex].Name;


                if (sColName != "Quantity" && sColName != "Weight" )
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


                if (sColName != "Quantity" && sColName != "Weight")
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion



        #region Search Methods
        private void Search_MRPID()
        {
            try
            {
                clsSearch.Search_TransactionMRP_Direct(ref txtMRPID, chkShowSettle.Checked);
                if (txtMRPID.Text.Trim().Length > 0 && txtMRPID.Text.Trim() != "<Auto Generate>")
                    FillDetails(txtMRPID.Text.Trim());
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_MRPCategory()
        {
            clsSearch.Search_MasterMRPCategory(ref txtMRPCategory);          
        }
        private void Search_ApprovedBy()
        {
            try
            {
                frmSetApproved login = new frmSetApproved();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetApproved.bChecked)
                {
                    bHasApproved = true;
                    glbApprovedDate = clsSecurity.getServerDateTime();
                    dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                    txtApprovedBy.Text = frmSetApproved.sApprovedUserName;
                    txtApprovedBy.Tag = frmSetApproved.sApprovedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                    if (IsUpdate)
                    {
                        tbl_scsMatfor objCO = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                        if (objCO != null)
                        {
                            objCO.IsApproved = true;
                            objCO.DateApproved = clsSecurity.getServerDateTime();
                            objCO.ApprovedUser_ID = frmSetApproved.sApprovedUserID;
                            objCO.Update();
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
                frmSetChecked login = new frmSetChecked();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetChecked.bChecked)
                {
                    bHasChecked = true;
                    glbCheckedDate = clsSecurity.getServerDateTime();
                    dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                    txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
                    txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);

                    if (IsUpdate)
                    {
                        tbl_scsMatfor objCO = tbl_scsMatfor.Select(txtMRPID.Text.Trim());
                        if (objCO != null)
                        {
                            objCO.IsChecked = true;
                            objCO.DateChecked = clsSecurity.getServerDateTime();
                            objCO.CheckedUser_ID = frmSetChecked.sCheckedUserID;
                            objCO.Update();
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
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

       #region Calculate Planned Qty and Weight
		private void CalculatePlannedQtyAndWeight()
       {
           decimal dQty = 0, dWeight = 0;
           foreach(DataGridViewRow Row in dgvCustomerWise.Rows)
           {
               dQty += clsValidate.DecimalValidate(txtTotalQty);
               dWeight += clsValidate.DecimalValidate(txtTotalWeight);
           }

           txtTotalQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQty);
           txtTotalWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(dWeight);
        } 
	    #endregion

       


    }
}
