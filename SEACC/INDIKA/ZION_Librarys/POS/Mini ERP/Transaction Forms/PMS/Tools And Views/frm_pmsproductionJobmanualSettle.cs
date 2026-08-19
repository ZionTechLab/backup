using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_pmsproductionJobmanualSettle : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        static bool bIsWeightCalculation = false;

        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        #endregion

        #region Form Load
        public frm_pmsproductionJobmanualSettle()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.ProductionJobManualSettle);
            iFormID = clsSecurity.getFormID(FormName.ProductionJobManualSettle);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
            
        private void frm_pmsproductionJobmanualSettle_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Old Sales’ Production Job Closure", 2, iFormID);
            CusDataGridViewFormat();

            ClearFields();
        }
        #endregion


        #region Btn Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpDateFrom, false);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpDateTo, false);
            RefreshGrid();
        } 
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool iStatus = false;
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
            {
                try
                {int i=clsCommon.getDays(dtpDateFrom.Value, clsSecurity.getServerDateTime());
                    if ( i > 365)
                    {
                        Cursor = Cursors.WaitCursor;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {

                            if (clsValidate.ValidateGridValue(dgvDetail, "select", row.Index, false))
                            {
                                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(clsValidate.ValidateGridValue(dgvDetail, "order_id", row.Index, ""));
                                if (detail != null)
                                {
                                    //update customer order
                                    detail.IsSeattled = true;
                                    detail.Update();

                                    //update manual settle
                                    tbl_pmsProductionJobManualSettle oProSettle = new tbl_pmsProductionJobManualSettle(clsSecurity.getServerDateTime(), "", clsSecurity.UserIDLoged,
                                        "default", "default", "default", "default", clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                        false, false, false, false, false);
                                    oProSettle.Insert();

                                    //update manual settle detail
                                    oProSettle = tbl_pmsProductionJobManualSettle.SelectAll().OrderBy(p => p.Settle_ID).Last();
                                    tbl_pmsProductionJobManualSettle_Detail oProSettledetail = new tbl_pmsProductionJobManualSettle_Detail(oProSettle.Settle_ID, detail.CustomerOrder_ID, true);
                                    oProSettledetail.Insert();

                                    iStatus = true;
                                }

                            }
                        }
                        if (iStatus == true)
                        {
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearFields();
                        }
                    }
                    else
                        MessageBox.Show("To Date should be greater than 365 days", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clsValidate.WriteErrorLog("", iFormID,ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion


        #region ClearFields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            bIsWeightCalculation = false;

            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpDateFrom, true);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpDateTo, true);

            dgvDetail.Rows.Clear();

            dtpDateFrom.Select();
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
        }
        //private void FormatGridView(bool bIsWeightCalculation)
        //{
        //    //if (bIsWeightCalculation)
        //    //{
        //    //    dgvDetail.Columns["Quantity"].Visible = false;
        //    //    dgvDetail.Columns["Weight"].Visible = true;
        //    //    dgvDetail.Columns["QuantityDO"].Visible = false;
        //    //    dgvDetail.Columns["WeightDO"].Visible = true;
        //    //    dgvDetail.Columns["QuantityInvoice"].Visible = false;
        //    //    dgvDetail.Columns["WeightInvoice"].Visible = true;
        //    //    dgvDetail.Columns["EditQuantity"].Visible = false;
        //    //    dgvDetail.Columns["EditWeight"].Visible = true;
        //    //}
        //    //else
        //    //{
        //    //    dgvDetail.Columns["Quantity"].Visible = true;
        //    //    dgvDetail.Columns["Weight"].Visible = false;
        //    //    dgvDetail.Columns["QuantityDO"].Visible = true;
        //    //    dgvDetail.Columns["WeightDO"].Visible = false;
        //    //    dgvDetail.Columns["QuantityInvoice"].Visible = true;
        //    //    dgvDetail.Columns["WeightInvoice"].Visible = false;
        //    //    dgvDetail.Columns["EditQuantity"].Visible = true;
        //    //    dgvDetail.Columns["EditWeight"].Visible = false;
        //    //}

        //    clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);

        //}
        #endregion

        #region Refresh
        private void RefreshGrid()
        {
            try
            {
                if (CheckValidity())
                {
                    int iRow;
                    dgvDetail.Rows.Clear();

                    foreach (tbl_sasCustomerOrder detail in tbl_sasCustomerOrder.SelectAll().Where(p => !p.IsDeleted && p.CustomerOrder_ID != "default" && p.CustomerOrderDate >= dtpDateFrom.Value.Date && p.CustomerOrderDate <= dtpDateTo.Value.Date && !p.IsSeattled))
                    {
                        string sDOId = "";
                        string sOrderQty = "";
                        decimal dDeliveredQty = 0;
                        string sJobNo = "";
                        string sItemname = "";
                        string sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                        foreach (tbl_sasCustomerOrder_Detail oCusOdrDtl in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
                        {
                            sOrderQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oCusOdrDtl.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oCusOdrDtl.Qty);
                            sItemname += clsGenaralName.getName_Item(oCusOdrDtl.Item_ID);
                        }
                        foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
                        {
                            sJobNo = oJob.ProductionJob_ID;
                            break;
                        }
                        foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                        {
                            sDOId = oDo.DeliveryOrder_ID;
                           
                            foreach (tbl_sasDeliveryOrder_Detail oDod in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                dDeliveredQty += oDo.IsWeightCalculation ? oDod.Weight - oDod.WeightReturned : oDod.Qty - oDod.QtyReturned;
                        }
                        if (sJobNo.Length > 0 && sJobNo != "default")
                        {
                            dgvDetail.Rows.Add();
                            iRow = dgvDetail.Rows.Count - 1;
                            dgvDetail["order_id", iRow].Value = detail.CustomerOrder_ID;
                            dgvDetail["Do_id", iRow].Value = sDOId;
                            dgvDetail["job_ID", iRow].Value = sJobNo;
                            dgvDetail["customer_name", iRow].Value = sCustomerName;
                            dgvDetail["Item_name", iRow].Value = sItemname;
                            dgvDetail["order_qty", iRow].Value = sOrderQty;
                            dgvDetail["delivered_qty", iRow].Value = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dDeliveredQty) : clsFormatter.FormatDecimalPlaces_Quantity(dDeliveredQty);
                            dgvDetail["select", iRow].Value = "false";
                        }
                    }
                    dgvDetail.Columns["Item_name"].Width =250;
                    if (dgvDetail.Rows.Count >= 16)
                        dgvDetail.Columns["Item_name"].Width -= 16;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
           string strMessage = "";
           bool bStatus = true;
           if (dtpDateFrom.Value.Date <= dtpDateTo.Value.Date)
           {
               bStatus = true;
           }
           else
           {
               strMessage += "\n" + "Date";
               bStatus =false;
               MessageBox.Show("FROM DATE cannot be greater then TO DATE ...", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }


        #endregion

        #region Event DoubleClick
        #endregion

        #region Search Methods
        #endregion
    }
}
