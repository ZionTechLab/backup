using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;


namespace Digiteq
{
    public partial class frm_sasMultipleItemSelect_SRN : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        public string glb_sItemID = "", glb_sItemSubCategoryID = "default", glb_sItemSubCategoryID2 = "default", glb_sItemSerialNo = "0", glb_sItemSerialNo2 = "0";
        public string glb_sCustomerID = "";
        public List<clsTmpSelectedItems> lstclsTmpSelectedItems = new List<clsTmpSelectedItems>();
        #endregion

        #region Form Load
        public frm_sasMultipleItemSelect_SRN()
        {
            InitializeComponent();
        }

        private void frm_sasOpeningBalance_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Add Multiple Items", 2, 0);
            CusDataGridViewFormat();

            if (glb_sItemID.Length > 0 && glb_sItemID != "default" && glb_sCustomerID.Length > 0)
                RefreshGrid(glb_sCustomerID, glb_sItemID, glb_sItemSubCategoryID, glb_sItemSubCategoryID2, glb_sItemSerialNo, glb_sItemSerialNo2);

        } 
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Validate_SRNQty())
            {
                lstclsTmpSelectedItems.Clear();
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    dgvDetail.Rows[row.Index].Selected = true;
                    int iLineNo = clsValidate.ValidateGridValue(dgvDetail, "LineNo", row.Index, int.Parse("0"));
                    string sDeliveryOrderCode = clsValidate.ValidateGridValue(dgvDetail, "gDONo", row.Index, "default");
                    string sInvoiceCode = clsValidate.ValidateGridValue(dgvDetail, "gInvoiceNo", row.Index, "default");
                    string sJobNo = clsValidate.ValidateGridValue(dgvDetail, "gJobNo", row.Index, "default");
                    string sSalesNoteTypeID = clsValidate.ValidateGridValue(dgvDetail, "gSalesNoteTypeID", row.Index, "default");
                    string sOrderRefID = clsValidate.ValidateGridValue(dgvDetail, "gOrderRefID", row.Index, "default");
                    string sRemarks = clsValidate.ValidateGridValue(dgvDetail, "gRemarks", row.Index, "default");
                    decimal dQuantity = clsValidate.ValidateGridValue(dgvDetail, "gQty_SRN", row.Index, decimal.Parse("0.00"));
                    decimal dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "gUnitPrice", row.Index, decimal.Parse("0.00"));
                    decimal dWeight = clsValidate.ValidateGridValue(dgvDetail, "gWeight", row.Index, decimal.Parse("0.00"));

                    if (dQuantity > 0 && sDeliveryOrderCode != "default")
                    {
                        clsTmpSelectedItems oclsTmpSelectedItems = new clsTmpSelectedItems();
                        oclsTmpSelectedItems.iLineNo = iLineNo;
                        oclsTmpSelectedItems.dQty = dQuantity;
                        oclsTmpSelectedItems.sDONo = sDeliveryOrderCode;
                        oclsTmpSelectedItems.dUnitPrice = dUnitPrice;
                        oclsTmpSelectedItems.dWeight = dWeight;
                        oclsTmpSelectedItems.sInvoiceNo = sInvoiceCode;
                        oclsTmpSelectedItems.sJobNo = sJobNo;
                        oclsTmpSelectedItems.sSaleNoteID = sSalesNoteTypeID;
                        oclsTmpSelectedItems.sOrderRefID = sOrderRefID;
                        oclsTmpSelectedItems.sRemarks = sRemarks;
                        lstclsTmpSelectedItems.Add(oclsTmpSelectedItems);
                    }


                }
                this.Close(); 
            }
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            lstclsTmpSelectedItems.Clear();
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dgvDetail["gQty_SRN", row.Index].Value = "0";
            }
        }
        #endregion     


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);            
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sCustomerID, string sItemID, string sItemSubCategoryID, string sItemSubCategoryID2, string sItemSerialNo, string sItemSerialNo2)
        {
            try
            {
                dgvDetail.Rows.Clear();
                int iMonths = int.Parse(clsConfig.sTotalMonths_ForLastValidDO_ForSRN);
                DateTime dtmServerDate = clsSecurity.getServerDateTime();

                foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAllByCustomer_ID(sCustomerID).Where(p=> !p.IsDeleted && p.DeliveryOrder_ID != "default" && p.DeliveryOrderDate > dtmServerDate.AddMonths(-iMonths)).OrderByDescending(o=> o.DeliveryOrderDate))
                {
                    string sInvoiceID = "";
                    decimal dDiscountPercentage = 0;
                    foreach (tbl_sasInvoice item in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID).Where(p=> p.Invoice_ID != "default" && !p.IsDeleted))
                    {
                        sInvoiceID = item.Invoice_ID;
                        dDiscountPercentage = item.DiscountPercentage;
                        break;
                    }
                    foreach(tbl_sasDeliveryOrder_Detail detail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDO.DeliveryOrder_ID))                    
                    {
                        if (sItemID == detail.Item_ID && sItemSubCategoryID == detail.ItemSubCategory_ID && sItemSubCategoryID2 == detail.ItemSubCategory2_ID && sItemSerialNo == detail.ItemSerialNo && sItemSerialNo2 == detail.ItemSerialNo2)
                        {
                            dgvDetail.Rows.Add();
                            int iRow = dgvDetail.Rows.Count - 1;
                            dgvDetail["LineNo", iRow].Value = detail.Line_No;
                            dgvDetail["gDONo", iRow].Value = oDO.DeliveryOrder_ID;
                            dgvDetail["gDODate", iRow].Value = clsFormatter.FormatDate_Short(oDO.DeliveryOrderDate);
                            dgvDetail["gQty", iRow].Value = oDO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Quantity(detail.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                            
                            dgvDetail["gQty_Returned", iRow].Value = oDO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(detail.WeightReturned) : clsFormatter.FormatDecimalPlaces_Quantity(detail.QtyReturned);
                            dgvDetail["gQty_Available", iRow].Value = oDO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(detail.Weight - detail.WeightReturned) : clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty - detail.QtyReturned);
                            dgvDetail["gQty_SRN", iRow].Value = "0";
                            dgvDetail["gWeight", iRow].Value = detail.Weight;
                            dgvDetail["gInvoiceNo", iRow].Value = sInvoiceID;
                            dgvDetail["gJobNo", iRow].Value = oDO.Job_ID;
                            dgvDetail["gSalesNoteTypeID", iRow].Value = oDO.SalesNoteType_ID;
                            dgvDetail["gOrderRefID", iRow].Value = oDO.OrderRefNo_ID;
                            dgvDetail["gRemarks", iRow].Value = detail.Remark;

                            decimal dUnitPrice = oDO.IsWeightCalculation ? detail.WeightPrice : detail.UnitPrice;
                            if (dDiscountPercentage > 0)
                                dUnitPrice = clsProcessMethods.ReduceDiscountPacentage_FromItemUnitPrice(dUnitPrice, dDiscountPercentage);
                            dgvDetail["gUnitPrice", iRow].Value = oDO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice) : clsFormatter.FormatDecimalPlaces_WeightPrice(dUnitPrice);
                        }
                    }
                }

                if (dgvDetail.Rows.Count > 11)
                {
                    dgvDetail.Columns["gDONo"].Width -= 10;
                    dgvDetail.Columns["gDODate"].Width -= 6;
                }
                if (dgvDetail.Rows.Count > 0)
                    dgvDetail["gQty_SRN", 0].Selected = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }

        }
        #endregion

        private bool Validate_SRNQty()
        {
            bool bValue = true;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                decimal dAvailableQty = clsValidate.ValidateGridValue(dgvDetail, "gQty_Available", row.Index, decimal.Parse("0.00"));
                decimal dSRNQty = clsValidate.ValidateGridValue(dgvDetail, "gQty_SRN", row.Index, decimal.Parse("0.00"));
                string sDONo = clsValidate.ValidateGridValue(dgvDetail, "gDONo", row.Index, "");
                
                if (dSRNQty > 0)
                {
                    if (dAvailableQty < dSRNQty)
                    {
                        bValue = false;
                        MessageBox.Show("SRN Qty Cannot Be Greater Than Balance Qty for " + sDONo, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }
            return bValue;
        }
       

        #region Events KeyDown
        private void frm_sasMultipleItemSelect_SRN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnNew_Click(sender, new EventArgs());
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnSave_Click(sender, new EventArgs());
            }
        } 
        #endregion

        private void dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal dQuantity = 0;
            foreach (DataGridViewRow row in dgvDetail.Rows)
            {
                dQuantity += clsValidate.ValidateGridValue(dgvDetail, "gQty_SRN", row.Index, decimal.Parse("0.00"));
            }
            txtSubTotal.Text = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
        }
    }

    public class clsTmpSelectedItems
    {
        public int iLineNo;
        public string sDONo;
        public decimal dQty;
        public decimal dUnitPrice;
        public decimal dWeight;
        public string sInvoiceNo;
        public string sJobNo;
        public string sSaleNoteID;
        public string sOrderRefID;
        public string sRemarks;
    }
}

