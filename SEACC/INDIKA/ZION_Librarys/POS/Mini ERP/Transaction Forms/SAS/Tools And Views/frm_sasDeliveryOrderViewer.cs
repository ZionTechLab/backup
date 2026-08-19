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
    public partial class frm_sasDeliveryOrderViewer : Form
    {
        #region Variables

        //form manage        
           public int iFormID;

        //for handle counter
        int cSettled = 0, cUnSettled = 0, cDelete = 0;

        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_sasDeliveryOrderViewer()
        {
            iFormID = clsSecurity.getFormID(FormName.sasDeliveryOrderViewer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }	
	 
        private void frm_sasDeliveryOrderViewer_Load(object sender, EventArgs e)
        {
            //Format Form
            clsFormatter.setFormatForm(this, "Delivery Order Viewer [COV]", 2, iFormID);
            CusDataGridViewFormat();

            CreateDataTable();
            dgvDetail.DataSource = source;
            RefreshGrid();
            ClearFields();
        }
        #endregion


        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
            else
            {
                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
        }
        #endregion                       


        #region ClearFields
        private void ClearFields()
        {
            txtDeliveryNoteNo.Clear();
            txtCustomerName.Clear();
            txtDate.Clear();
            txtRefNo.Clear();

            chkDeliveryNoteNo.Checked = false;
            chkCustomerName.Checked = false;
            chkDate.Checked = false;
            chkRefNo.Checked = false;
            chkViewAll.Enabled = true;
            chkViewAll.Checked = false;

            txtColourInProgress.ForeColor = clsFormatter.colorInProgress;
            txtColourCompleted.ForeColor = clsFormatter.colorCompleted;            
            txtColourDeleted.ForeColor = clsFormatter.colorDeleted;
        }
        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                
                dtAllRecodes.Clear();
                List<vw_search_sasDeliveryOrder> details = vw_search_sasDeliveryOrder.SelectAll();
                foreach (vw_search_sasDeliveryOrder detail in details)
                {

                    if (!chkViewAll.Checked)
                    {
                        if (detail.IsSeattled == false && detail.IsDeleted == false)
                            dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                        // iRecords++;

                    }
                    else
                    {
                        if (detail.IsDeleted == true)
                            dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                        else
                        {
                            if (detail.IsSeattled == false)
                                dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                            if (detail.IsSeattled == true)
                                dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                        }
                        //iRecords++;
                    }

                    //if (detail.DeliveryOrder_ID != "default")
                    //{
                    //    if (!chkViewAll.Checked)
                    //    {
                    //        if (detail.IsSeattled || detail.IsDeleted)
                    //            bOk = false;
                    //    }
                    //    if (bOk)
                    //    {                            
                    //        dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                    //    }
                    //    bOk = true; 
                    //}
                }
                ResetGridColumn();
                source.Filter = "";
                source.DataSource = dtAllRecodes;
                changeGridColor();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }        
        
        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("DelOrderCode", typeof(string));
            dtAllRecodes.Columns.Add("CustomerName", typeof(string));
            dtAllRecodes.Columns.Add("Date", typeof(string));
            dtAllRecodes.Columns.Add("OrderRefNo", typeof(string));
            dtAllRecodes.Columns.Add("GrandTotal", typeof(string));
            dtAllRecodes.Columns.Add("isSeattled", typeof(bool));
            dtAllRecodes.Columns.Add("isDeleted", typeof(bool));
        }
        #endregion        

        #region DataGridViewFormat
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales2BackColour); 
        }
        #endregion                


        #region Event KeyUp
        private void txtDeliveryNoteNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtDeliveryNoteNo);
        }
                

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtDate);
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtCustomerName);
        }

        private void txtRefNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtRefNo);
        }
        #endregion

        #region Event CheckedChanged
        private void chkDeliveryNoteNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDeliveryNoteNo.Checked)
            {
                txtDeliveryNoteNo.Enabled = false;
            }
            else
            {
                txtDeliveryNoteNo.Enabled = true;
                txtDeliveryNoteNo.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtDeliveryNoteNo);
            }
        }

        private void chkCustomerName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerName.Checked)
            {
                txtCustomerName.Enabled = false;
            }
            else
            {
                txtCustomerName.Enabled = true;
                txtCustomerName.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtCustomerName);
            }
        }

        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                txtDate.Enabled = false;
            }
            else
            {
                txtDate.Enabled = true;
                txtDate.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtDate);
            }
        }

        private void chkRefNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRefNo.Checked)
            {
                txtRefNo.Enabled = false;
            }
            else
            {
                txtRefNo.Enabled = true;
                txtRefNo.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtRefNo);
            }
        }

        private void chkViewAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
            if (chkViewAll.Checked)
                chkViewAll.Enabled = false;
        }
        #endregion

        #region Event Doubleclick 
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_DeliveryOrder();            
        }
        #endregion

        #region VisibleChanged
        private void frm_sasDeliveryOrderViewer_VisibleChanged(object sender, EventArgs e)
        {
            changeGridColor();
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

        #region Events CellMouseMove
        private void DataGrid_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0)
                Cursor = Cursors.Hand;
        }
        #endregion

        #region Events CellMouseLeave
        private void DataGrid_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
                Cursor = Cursors.Default;
        }
        #endregion


        #region Search
        private void Search_DeliveryOrder()
        {
            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.idealWheels.ToString())
            {
                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                frm.glbDeliveryOrderID = dgvDetail[0, dgvDetail.CurrentCell.RowIndex].Value.ToString().Trim();
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
            else
            {
                frm_sasDeliveryOrder frm = new frm_sasDeliveryOrder(FormName.CusDeliveryOrder);
                frm.glbDeliveryOrderID = dgvDetail[0, dgvDetail.CurrentCell.RowIndex].Value.ToString().Trim();
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
        }
        #endregion                

        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                if (chkDeliveryNoteNo.Checked && argText.Name != "txtDeliveryNoteNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND DelOrderCode LIKE '%" + txtDeliveryNoteNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = "DelOrderCode LIKE '%" + txtDeliveryNoteNo.Text.Trim() + "%'";
                }
                if (chkCustomerName.Checked && argText.Name != "txtCustomerName")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                    else
                        sFilteQuary = " CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                }
                if (chkDate.Checked && argText.Name != "txtDate")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND Date LIKE '%" + txtDate.Text.Trim() + "%'";
                    else
                        sFilteQuary = " Date LIKE '%" + txtDate.Text.Trim() + "%'";
                }
                if (chkRefNo.Checked && argText.Name != "txtRefNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND OrderRefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = " OrderRefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";
                }


                if (argText.Name == "txtDeliveryNoteNo")
                    sTemp = " DelOrderCode LIKE '%" + txtDeliveryNoteNo.Text.Trim() + "%'";
                if (argText.Name == "txtCustomerName")
                    sTemp = " CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                if (argText.Name == "txtDate")
                    sTemp = " Date LIKE '%" + txtDate.Text.Trim() + "%'";
                if (argText.Name == "txtRefNo")
                    sTemp = " OrderRefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";

                if (argText.Name == txtColourInProgress.Name)
                    sTemp = " isSeattled = false AND isDeleted = false ";
                if (argText.Name == txtColourCompleted.Name)
                    sTemp = " isSeattled = true  AND isDeleted = false ";
                if (argText.Name == txtColourDeleted.Name)
                    sTemp = " isDeleted = true ";

                if (sTemp.Trim().Length > 0)
                {
                    if (sFilteQuary.Trim().Length > 0)
                    {
                        sFinalQuary = sFilteQuary + " AND " + sTemp;
                    }
                    else
                    {
                        sFinalQuary = sTemp;
                    }
                }
                source.Filter = "";
                if (sFinalQuary.Trim().Length > 0)
                    source.Filter = sFinalQuary;
                else
                    source.Filter = sTemp;

                if (!(chkDeliveryNoteNo.Checked || chkCustomerName.Checked || chkDate.Checked || chkRefNo.Checked))
                {
                    sFilteQuary = "";
                }
                changeGridColor();
                ResetGridColumn();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }                
        #endregion

        #region changeGridColor
        private void changeGridColor()
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].DefaultCellStyle.ForeColor = GetColorForDelOrder(dgvDetail.Rows[i].Cells["RegisterCode"].Value.ToString());
            }
            SetCounter(); 
        }
        #endregion

        #region GetColorForDelOrder
        private Color GetColorForDelOrder(string sRegisterID)
        {
            Color col = Color.Red;
            tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sRegisterID);
            if (detail != null)
            {
                if (detail.IsDeleted)
                {
                    col = clsFormatter.colorDeleted;
                    ++cDelete;
                }
                else
                {
                    if (detail.IsSeattled == true)
                    {
                        col = clsFormatter.colorCompleted;
                        ++cSettled;
                    }
                    if (detail.IsSeattled == false)
                    {
                        col = clsFormatter.colorInProgress;
                        ++cUnSettled;
                    }
                }
            }
            return col;
        }
        #endregion                               

        #region SetCounter
        private void SetCounter()
        {
            textBox4.Text = Convert.ToString(dgvDetail.Rows.Count);
            textBox1.Text = Convert.ToString(cUnSettled);
            textBox2.Text = Convert.ToString(cSettled);
            textBox3.Text = Convert.ToString(cDelete);
            cDelete = 0;
            cSettled = 0;
            cUnSettled = 0;
        }
        #endregion

        #region ResetGridColumn
        private void ResetGridColumn()
        {
            dgvDetail.Columns["Grandtotal"].Width = 117;
            if (dgvDetail.Rows.Count > 22)
                dgvDetail.Columns["Grandtotal"].Width -= 15;
            else
                dgvDetail.Columns["Grandtotal"].Width = 117;
        }
        #endregion

        #region fill Inquiry
        private void fillInquiry(TextBox txt)
        {
            dtAllRecodes.Clear();
            List<vw_search_sasDeliveryOrder> details = vw_search_sasDeliveryOrder.SelectAll();
            if (txt.Name == txtColourInProgress.Name)
            {
                foreach (vw_search_sasDeliveryOrder detail in details)
                {
                    if (detail.IsSeattled == false && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == txtColourCompleted.Name)
            {
                foreach (vw_search_sasDeliveryOrder detail in details)
                {
                    if (detail.IsSeattled == true && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == txtColourDeleted.Name)
            {
                foreach (vw_search_sasDeliveryOrder detail in details)
                {
                    if (detail.IsDeleted == true)
                        dtAllRecodes.Rows.Add(detail.DeliveryOrder_ID, detail.CustomerName, detail.DeliveryOrderDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                }
            }
            source.Filter = "";
            source.DataSource = dtAllRecodes;
            changeGridColor();
            ResetGridColumn();

        }
        #endregion

        private void txtColourInProgress_Click(object sender, EventArgs e)
        {
            if (chkViewAll.Checked)
                createFilterQuary(txtColourInProgress);
            else
                fillInquiry(txtColourInProgress);
        }

        private void txtColourCompleted_Click(object sender, EventArgs e)
        {
            if (chkViewAll.Checked)
                createFilterQuary(txtColourCompleted);
            else
                fillInquiry(txtColourCompleted);
        }

        private void txtColourDeleted_Click(object sender, EventArgs e)
        {
            if (chkViewAll.Checked)
                createFilterQuary(txtColourDeleted);
            else
                fillInquiry(txtColourDeleted);
        }
    }
}
