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
    public partial class frm_bpsReceiptTracer : Form
    {
        #region Variables

        //form manage
        string sFormConfigCode;
        string sFormConfigCodeReceipt;
           public int iFormID;

        //for handle counter
        int cSettled = 0, cUnSettled = 0, cDelete = 0;

        //for security handle
        public bool bNoAccess;

        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";
        #endregion

        #region Form Load
        public frm_bpsReceiptTracer()
        {
            iFormID = clsSecurity.getFormID(FormName.bpsReceiptTracer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsReceiptTracer_Load(object sender, EventArgs e)
        {
            //set Title
            clsFormatter.setFormatForm(this, "Receipt Tracer [RT]", 2, iFormID);

            //add data to the datagrid and format            
            CusDataGridViewFormat();

            CreateDataTable();
            dgvDetail.DataSource = source;
            ClearFields();
            RefreshGrid();
        }

        #endregion


        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
          //  frm_bpsReceipt_Sales R = new frm_bpsReceipt_Sales();
          //  R.MdiParent = this.MdiParent;
          //  R.Show();
        }
        #endregion

        #region Btn Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }
        #endregion


        #region ClearFields
        private void ClearFields()
        {
            txtReceiptNo.Clear();
            txtCustomerName.Clear();
            txtDate.Clear();

            ChkReceiptNo.Checked = false;
            chkCustomerName.Checked = false;
            chkDate.Checked = false;
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
               // bool bOk = true;
                int iRecords = 0;
                dtAllRecodes.Clear();
                List<vw_search_bssReceipt> details = vw_search_bssReceipt.SelectAll();
                foreach (vw_search_bssReceipt detail in details)
                {
                    if (detail.Receipt_ID != "default")
                    {
                        if (!chkViewAll.Checked)
                        {
                            if (detail.IsSeattled == false && detail.IsDeleted == false)
                                dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);
                                                        
                            iRecords++;
                            
                        }
                        else
                        {                            
                            if (detail.IsDeleted == true)
                                dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);
                            else
                            {
                                if (detail.IsSeattled == false)
                                    dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);

                                if (detail.IsSeattled == true)
                                    dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);

                            }
                            iRecords++;
                        }                        
                    }
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
            dtAllRecodes.Columns.Add("ReceiptNo", typeof(string));
            dtAllRecodes.Columns.Add("CustomerName", typeof(string));
            dtAllRecodes.Columns.Add("Date", typeof(string));
            dtAllRecodes.Columns.Add("ChequeAmount", typeof(decimal));
            dtAllRecodes.Columns.Add("CashAmount", typeof(decimal));
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


        #region Event DoubleClick
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchReceipt_ID();
        }
        #endregion

        #region Event KeyUp
        private void txtReceiptNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtReceiptNo);
        }

        private void txtCustomerName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtCustomerName);
        }

        private void txtDate_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtDate);
        }

        #endregion

        #region Event checkChanged
        private void ChkReceiptNo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkReceiptNo.Checked)
            {
                txtReceiptNo.Enabled = false;
            }
            else
            {
                txtReceiptNo.Enabled = true;
                txtReceiptNo.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtReceiptNo);
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


        private void chkViewAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
            if (chkViewAll.Checked)
                chkViewAll.Enabled = false;

        }
        #endregion

        #region Event VisibleChanged
        private void frm_bpsReceiptTracer_VisibleChanged(object sender, EventArgs e)
        {
            changeGridColor();
        }
        #endregion


        #region Search
        private void SearchReceipt_ID()
        {
            try
            {
                string sReceiptID = "";
                sReceiptID = dgvDetail[0, dgvDetail.CurrentCell.RowIndex].Value.ToString().Trim();
                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                if (detail != null)
                {
                    if (detail.IsSalesReceipt)
                    {
                        //frm_bpsReceipt_Sales R = new frm_bpsReceipt_Sales();
                      //  R.gReceiptID = detail.Receipt_ID;
                      //  R.MdiParent = this.MdiParent;
                      //  R.Show();
                    }
                    else
                    {
                        //frm_bpsReceipt_Interim R = new frm_bpsReceipt_Interim();
                        //R.gReceiptID = detail.Receipt_ID;
                        //R.MdiParent = this.MdiParent;
                        //R.Show();
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

        #region changeGridColor
        private void changeGridColor()
        {
            for (int i = 0; i < dgvDetail.Rows.Count; i++)
            {
                dgvDetail.Rows[i].DefaultCellStyle.ForeColor = GetColorForInquiry(dgvDetail.Rows[i].Cells["ReceiptNo"].Value.ToString());
            }
            SetCounter();            
        }              
        #endregion

        #region GetColorForInquiry
        private Color GetColorForInquiry(string sReceiptNo)
        {
            Color col = Color.Red;
            tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptNo);
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
                if (ChkReceiptNo.Checked && argText.Name != "txt")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ReceiptNo LIKE '%" + txtReceiptNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ReceiptNo LIKE '%" + txtReceiptNo.Text.Trim() + "%'";
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


                if (argText.Name == "txtReceiptNo")
                    sTemp = " ReceiptNo LIKE '%" + txtReceiptNo.Text.Trim() + "%'";
                if (argText.Name == "txtCustomerName")
                    sTemp = " CustomerName LIKE '%" + txtCustomerName.Text.Trim() + "%'";
                if (argText.Name == "txtDate")
                    sTemp = " Date LIKE '%" + txtDate.Text.Trim() + "%'";

                if (argText.Name == txtColourInProgress.Name )
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

                if (!(ChkReceiptNo.Checked || chkCustomerName.Checked || chkDate.Checked ))
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
            dgvDetail.Columns["CustomerName"].Width = 290;
            if (dgvDetail.Rows.Count > 22)
                dgvDetail.Columns["CustomerName"].Width -= 15;
            else
                dgvDetail.Columns["CustomerName"].Width = 290;
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

        #region fill Inquiry
        private void fillInquiry(TextBox txt)
        {
            dtAllRecodes.Clear();
            List<vw_search_bssReceipt> details = vw_search_bssReceipt.SelectAll();
            if (txt.Name == "txtColourInProgress")
            {
                foreach (vw_search_bssReceipt detail in details)
                {
                    if (detail.IsSeattled == false && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == "txtColourCompleted")
            {
                foreach (vw_search_bssReceipt detail in details)
                {
                    if (detail.IsSeattled == true && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);
                }            
            }
            if (txt.Name == "txtColourDeleted")
            {
                foreach (vw_search_bssReceipt detail in details)
                {
                    if (detail.IsDeleted == true)
                        dtAllRecodes.Rows.Add(detail.Receipt_ID, detail.CustomerName, detail.ReceiptDate, clsFormatter.FormatToCurrecyWithThousendSep(detail.ChequeAmount), clsFormatter.FormatToCurrecyWithThousendSep(detail.CashAmount), detail.IsSeattled, detail.IsDeleted);
                                        
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
