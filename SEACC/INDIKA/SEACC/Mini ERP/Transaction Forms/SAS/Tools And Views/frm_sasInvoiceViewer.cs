using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasInvoiceViewer : Form
    {
        #region Variable
        //form manage        
           public int iFormID;

        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        //for handle counter
        int cSettled = 0, cUnSettled = 0, cDelete = 0;

        //for security handle
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_sasInvoiceViewer()
        {
            iFormID = clsSecurity.getFormID(FormName.sasInvoiceViewer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasInvoiceViewer_Load(object sender, EventArgs e)
        {
            //Format Form
            clsFormatter.setFormatForm(this, "Invoice Viewer [IV]", 2, iFormID);
            CusDataGridViewFormat();

            CreateDataTable();
            dgvDetail.DataSource = source;
            RefreshGrid();
            ClearFields();
        }
        #endregion


        #region Event Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
        }
        #endregion

        #region ClearFields
        private void ClearFields()
        {
            txtInvoiceNo.Clear();
            txtCustomerName.Clear();
            txtDate.Clear();
            txtRefNo.Clear();

            chkInvoiceNo.Checked = false;
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
                List<vw_search_sasInvoice> details = vw_search_sasInvoice.SelectAll();
                foreach (vw_search_sasInvoice detail in details)
                {

                    if (!chkViewAll.Checked)
                    {
                        if (detail.IsSeattled == false && detail.IsDeleted == false)
                            dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                       // iRecords++;

                    }
                    else
                    {
                        if (detail.IsDeleted == true)
                            dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                        else
                        {
                            if (detail.IsSeattled == false)
                                dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                            if (detail.IsSeattled == true)
                                dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                        }
                        //iRecords++;
                    }

                    //if (detail.Invoice_ID != "default")
                    //{
                    //    if (!chkViewAll.Checked)
                    //    {
                    //        if (detail.IsSeattled||detail.IsDeleted||detail.IsFinished)
                    //            bOk = false;
                    //    }
                    //    if (bOk)
                    //        dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                    //    bOk = true;
                    //}
                }                
                source.Filter = "";
                source.DataSource = dtAllRecodes;
                changeGridColor();
                ResetGridColumn();
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
            dtAllRecodes.Columns.Add("InvoiceNo", typeof(string));
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
                        

        #region Event CheckedChanged
        private void chkInvoiceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInvoiceNo.Checked)
            {
                txtInvoiceNo.Enabled = false;
            }
            else
            {
                txtInvoiceNo.Enabled = true;
                txtInvoiceNo.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtInvoiceNo);
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

        private void chkViewAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
            if (chkViewAll.Checked)
                chkViewAll.Enabled = false;
        }
        #endregion

        #region Event DoubleClick
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchInvoice_ID();
        }
        #endregion

        #region KeyUp
        private void txtInvoiceNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtInvoiceNo);
        }
        
        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtCustomerName);
        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtDate);
        }

        private void txtRefNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtRefNo);
        }
        #endregion

        #region Event VisibleChanged
        private void frm_sasInvoiceViewer_VisibleChanged(object sender, EventArgs e)
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

        #region Txt Click
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
        #endregion
                
        
        #region Search()
        private void SearchInvoice_ID()
        {
            try
            {
                frm_sasInvoice frm = new frm_sasInvoice(FormName.VATInvoice);
                frm.glbInvoiceID = dgvDetail[0, dgvDetail.CurrentCell.RowIndex].Value.ToString().Trim();
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
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
                dgvDetail.Rows[i].DefaultCellStyle.ForeColor = GetColorForInvoiceOrder(dgvDetail.Rows[i].Cells["InvoiceNo"].Value.ToString());
            }
            SetCounter();  
        }
        #endregion

        #region GetColorForInvoiceOrder
        private Color GetColorForInvoiceOrder(string sRegisterID)
        {
            Color col = Color.Red;
            tbl_sasInvoice detail = tbl_sasInvoice.Select(sRegisterID);
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

        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                if (chkInvoiceNo.Checked && argText.Name != "txtInvoiceNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = " InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (chkCustomerName.Checked && argText.Name != "chkCustomerName")
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


                if (argText.Name == "txtInvoiceNo")
                    sTemp = " InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
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

                if (!(chkInvoiceNo.Checked || chkCustomerName.Checked || chkDate.Checked || chkRefNo.Checked))
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

        #region ResetGridColumn
        private void ResetGridColumn()
        {
            dgvDetail.Columns["Grandtotal"].Width = 108;
            if (dgvDetail.Rows.Count > 22)
                dgvDetail.Columns["Grandtotal"].Width -= 15;
            else
                dgvDetail.Columns["Grandtotal"].Width = 108;
        }
        #endregion

        #region fill Inquiry
        private void fillInquiry(TextBox txt)
        {
            dtAllRecodes.Clear();
            List<vw_search_sasInvoice> details = vw_search_sasInvoice.SelectAll();
            if (txt.Name == txtColourInProgress.Name)
            {
                foreach (vw_search_sasInvoice detail in details)
                {
                    if (detail.IsSeattled == false && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == txtColourCompleted.Name)
            {
                foreach (vw_search_sasInvoice detail in details)
                {
                    if (detail.IsSeattled == true && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == txtColourDeleted.Name)
            {
                foreach (vw_search_sasInvoice detail in details)
                {
                    if (detail.IsDeleted == true)
                        dtAllRecodes.Rows.Add(detail.Invoice_ID, detail.CustomerName, detail.InvoiceDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);

                }
            }
            source.Filter = "";
            source.DataSource = dtAllRecodes;
            changeGridColor();
            ResetGridColumn();

        }
        #endregion

        
    }
}
