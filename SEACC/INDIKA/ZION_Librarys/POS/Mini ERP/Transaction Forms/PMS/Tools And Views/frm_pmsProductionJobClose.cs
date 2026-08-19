using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_pmsProductionJobClose : Form
    {

        #region Variables
           public int iFormID;
        public bool bNoAccess;
        public List<string> glb_lstProductionJobList = new List<string>();
        #endregion

        #region From Load
        public frm_pmsProductionJobClose()
        {
            iFormID = clsSecurity.getFormID(FormName.ProductionJobClose);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frmItemSearch_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Production Job Close", 2, iFormID);            

            ClearFields();
            
        } 
        #endregion

        #region Btn Sales Job View
        private void btnViewJob_Click(object sender, EventArgs e)
        {

            if (txtProductionJobID.Tag != null)
            {
                frm_sasJobViewer detail = new frm_sasJobViewer();
                tbl_pmsProductionJobRegister JobID = tbl_pmsProductionJobRegister.Select(txtProductionJobID.Tag.ToString());
                if (JobID != null)
                {
                    detail.glbJobID = JobID.Job_ID;
                    detail.glbProductionJobID = txtProductionJobID.Tag.ToString();
                    detail.ShowDialog();
                }
            }
        }
        #endregion

        #region Btn Production Job View
        private void btnViewProductionJob_Click(object sender, EventArgs e)
        {
            frm_sasViewerCustomerOrder oCusOrder = new frm_sasViewerCustomerOrder();
            if (txtProductionJobID.Text != "")
            {
                oCusOrder.glbJobNo = txtProductionJobID.Text;
                oCusOrder.ShowDialog();
            }
        } 
        #endregion


        #region Btn Sales\Production Job Close
        private void btnSelect_Click(object sender, EventArgs e)
        {
           if (txtProductionJobID.Tag != null && txtProductionJobID.Tag.ToString().Trim().Length > 0)
            {
                if (txtProductionJobID.Tag.ToString().Trim() == "selected")
                {
                    if (glb_lstProductionJobList.Count > 0)
                    {
                        DialogResult msgResult = MessageBox.Show("Do You Want To Close Multiple Production Jobs and Sales Orders " + glb_lstProductionJobList.Count.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                         if (msgResult == DialogResult.Yes)
                         {
                             foreach (string item in glb_lstProductionJobList)
                             {
                                 if (clsProcessMethods.CloseProductionJob_ByProductionJobID(item, true, true, "Manual Close"))
                                 {
                                     decimal dOverHead = 0, dMarkup = 0;
                                     dOverHead = decimal.Parse(txtGeneralOverhead.Text);
                                     dMarkup = decimal.Parse(txtmarkUp.Text);
                                //     clsAlerts.createEmail_ProductionJobClose(item, dOverHead, dMarkup, rdoDutyFreeReport.Checked, rdoSVatReport.Checked, rdoAllInclusiveReport.Checked);
                                 }                                
                             }
                             ClearFields();
                         }
                    }
                }
                else
                {
                    DialogResult msgResult = MessageBox.Show("Do You Want To Close Both Production Job and Sales Order? " + txtProductionJobID.Text.Trim(), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        if (clsProcessMethods.CloseProductionJob_ByProductionJobID(txtProductionJobID.Text.Trim(), true, true, "Manual Close"))
                        {
                            decimal dOverHead = 0, dMarkup = 0;
                            dOverHead = decimal.Parse(txtGeneralOverhead.Text);
                            dMarkup = decimal.Parse(txtmarkUp.Text);
                         //   clsAlerts.createEmail_ProductionJobClose(txtProductionJobID.Text.Trim(), dOverHead, dMarkup, rdoDutyFreeReport.Checked, rdoSVatReport.Checked, rdoAllInclusiveReport.Checked);
                        }
                        ClearFields();
                    }
                }
            }
        }
        #endregion

        #region Btn Production Job Close
        private void btnJobClose_Click(object sender, EventArgs e)
        {
            if (txtProductionJobID.Tag != null && txtProductionJobID.Tag.ToString().Trim().Length > 0)
            {
                if (txtProductionJobID.Tag.ToString().Trim() == "selected")
                {
                    if (glb_lstProductionJobList.Count > 0)
                    {
                        DialogResult msgResult = MessageBox.Show("Do You Want To Close Multiple Jobs andy Only Job Close? Total Jobs " + glb_lstProductionJobList.Count.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (msgResult == DialogResult.Yes)
                        {
                            foreach (string item in glb_lstProductionJobList)
                            {
                                if (clsProcessMethods.CloseProductionJob_ByProductionJobID(item, true, false, "Manual Close"))
                                {
                                    decimal dOverHead = 0, dMarkup = 0;

                                    dOverHead = decimal.Parse(txtGeneralOverhead.Text);
                                    dMarkup = decimal.Parse(txtmarkUp.Text);
                             //       clsAlerts.createEmail_ProductionJobClose(item, dOverHead, dMarkup, rdoDutyFreeReport.Checked, rdoSVatReport.Checked, rdoAllInclusiveReport.Checked);
                                }                                
                            }
                            ClearFields();
                        }
                    }
                }
                else
                {
                    DialogResult msgResult = MessageBox.Show("Do You Want To Close Only Job? " + txtProductionJobID.Text.Trim(), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (msgResult == DialogResult.Yes)
                    {
                        if (clsProcessMethods.CloseProductionJob_ByProductionJobID(txtProductionJobID.Text.Trim(), true, false, "Manual Close"))
                        {
                            decimal dOverHead = 0, dMarkup = 0;
                            dOverHead = decimal.Parse(txtGeneralOverhead.Text);
                            dMarkup = decimal.Parse(txtmarkUp.Text);
                    //        clsAlerts.createEmail_ProductionJobClose(txtProductionJobID.Text.Trim(), dOverHead, dMarkup, rdoDutyFreeReport.Checked, rdoSVatReport.Checked, rdoAllInclusiveReport.Checked);
                     //       //  clsAlerts.createEmail_ProductionJobClose2(txtProductionJobID.Text.Trim(), dOverHead, dMarkup, rdoDutyFreeReport.Checked, rdoSVatReport.Checked, rdoAllInclusiveReport.Checked);
                        }
                        ClearFields();
                    }
                }
            }
        }
        #endregion
        
        #region Btn Job Open
        private void btnJobOpen_Click(object sender, EventArgs e)
        {
            if (txtProductionJobID.Text.Trim().Length > 0)
            {
                DialogResult msgResult = MessageBox.Show("Do You Want To Open This Job? " + txtProductionJobID.Text.Trim(), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (msgResult == DialogResult.Yes)
                {
                    clsProcessMethods.OpenProductionJob_ByProductionJobID(txtProductionJobID.Text.Trim(), "Manual Open");
                    ClearFields();
                }
            }
        }
        #endregion
        
        #region Btn Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            txtProductionJobID.Tag = null;
            txtProductionJobID.Clear();

            lblItemID.Text = "";
            lblCustomerCode.Text = "";
            lblDeliveryDate.Text = "";          
            lblCustomerCategory.Text = "";
            lblCustomerName.Text = "";           
            lblOrderQty.Text = "";
            lblPendingDeliveryQty.Text = "";

            lblOrderNo.Text = "";
            lblOrderDate.Text = "";           
            lblUOM.Text = "";
            lblUOM1.Text = ""; 
            lblTotalDOWaight.Text = "";
            lblTotalDOQty.Text = "";
            lblTotalSRNWaigth.Text = "";
            lblTotalSRNQty.Text = "";

            glb_lstProductionJobList.Clear();
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {

                tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sID);
                if (detail != null)
                {
                    lblItemID.Text = detail.Item_ID;
                    lblCustomerCategory.Text = clsGenaralName.getName_Item(detail.Item_ID);
                    lblCustomerCode.Text = detail.Customer_ID;
                    lblCustomerName.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                    lblUOM.Text = clsGenaralName.getName_ItemUOM(detail.Item_ID);
                    lblUOM1.Text = clsGenaralName.getName_ItemUOM(detail.Item_ID);

                    #region Order details
                    tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(detail.CustomerOrder_ID);
                    if (oCO != null && oCO.CustomerOrder_ID != "default")
                    {
                        lblOrderNo.Text = oCO.CustomerOrder_ID;
                        lblOrderDate.Text = clsFormatter.FormatDate_Short(oCO.CustomerOrderDate);
                        lblDeliveryDate.Text = clsFormatter.FormatDate_Short(oCO.DeliveryDate);
                        foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                        {
                            lblOrderQty.Text = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oCODetail.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oCODetail.Qty);// clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(oCODetail.Qty.ToString()));
                            lblPendingDeliveryQty.Text = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oCODetail.Weight - oCODetail.WeightSettle_DeliveryOrder) : clsFormatter.FormatDecimalPlaces_Quantity(oCODetail.Qty - oCODetail.QtySettle_DeliveryOrder);                          
                        }
                        decimal dDOTotWaight = 0, dDOTotQty = 0, dSrnTotQty = 0, dSrnTotWaight = 0;
                        foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                        {                            
                            foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                            { 
                                dDOTotWaight += oDoDetail.Weight;
                                dDOTotQty += oDoDetail.Qty;
                            } 
                            foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))
                            {
                                tbl_sasSalesReturnedNote oSRN = tbl_sasSalesReturnedNote.Select(oSRNDetail.SalesReturnedNote_ID);
                                if (oSRN != null && oSRN.SalesReturnedNote_ID != "default")
                                {
                                    dSrnTotQty += oSRNDetail.Qty;
                                    dSrnTotWaight += oSRNDetail.Weight;
                                }
                            }                           
                        }
                        lblTotalDOWaight.Text = clsFormatter.FormatDecimalPlaces_Weight(dDOTotWaight);
                        lblTotalDOQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dDOTotQty);
                        lblTotalSRNWaigth.Text = clsFormatter.FormatDecimalPlaces_Weight(dSrnTotQty);
                        lblTotalSRNQty.Text = clsFormatter.FormatDecimalPlaces_Quantity(dSrnTotWaight);                       
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Double Click
        private void txtProductionJobID_DoubleClick(object sender, EventArgs e)
        {
            search_ProductionJob();
        }
        #endregion

        #region Key Down
        private void txtProductionJobID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                search_ProductionJob();
            }
        } 
        #endregion

        #region Events Key Press
        private void txtGeneralOverhead_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtGeneralOverhead, e, 15, 2);
        }

        private void txtmarkUp_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimalWithLength(txtmarkUp, e, 15, 2);
        } 
        #endregion

        private void search_ProductionJob()
        {
            if (chkMultipleSelect.Checked)
            {
                glb_lstProductionJobList.Clear();
                frmSearchMaster_Multiple_ProductionJob frmSearch = new frmSearchMaster_Multiple_ProductionJob();
                frmSearch.ShowDialog();
                if (frmSearchMaster_Multiple_ProductionJob.glbSelectedList.Count > 0)
                {
                    glb_lstProductionJobList = frmSearchMaster_Multiple_ProductionJob.glbSelectedList;
                    txtProductionJobID.Text = frmSearchMaster_Multiple_ProductionJob.glbSelectedList.Count + " Items Selected";
                    txtProductionJobID.Tag = "selected";
                }
            }
            else
            {
                clsSearch.Search_TransactionProductionJobRegisterAllJobs(ref txtProductionJobID, true, true);
                if (txtProductionJobID.TextLength > 0)
                    FillDetails(txtProductionJobID.Text.Trim());
            }
            
           
        }
    }
}
