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
    public partial class frm_sasInquiryViewer : Form
    {
        
     
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";

        string sFormConfigCode;
           public int iFormID;

        //for handle counter
        int cSettled = 0, cUnSettled = 0, cDelete = 0;

        //for security handle
        public bool bNoAccess;
    

        #region Form Load
        public frm_sasInquiryViewer()
        {
            iFormID = clsSecurity.getFormID(FormName.sasInquiryViewer);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasInquiryViewer_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Inquiry Viewer [CO]", 2, iFormID);
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
            frm_sasInquiry frm = new frm_sasInquiry(FormName.sasInquiry);
            clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
        }
        #endregion

        #region ClearFields
        private void ClearFields()
        {
            txtInquiryCode.Clear();
            txtCustomerID.Clear();
            txtDate.Clear();
            txtRefNo.Clear();
                       
            chkInquiryCode.Checked = false;
            chkCustomerID.Checked = false;
            chkDate.Checked = false;
            chkRefNo.Checked = false;
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
                bool bOk = true;
                dtAllRecodes.Clear();
                List<vw_search_sasInquiry> details = vw_search_sasInquiry.SelectAll();
                foreach (vw_search_sasInquiry detail in details)
                {
                    if (detail.Inquiry_ID !="default")
                    {
                        if (!chkViewAll.Checked)
                        {
                            if (detail.IsSeattled || detail.IsDeleted)
                                bOk = false;
                        }
                        if (bOk)
                            dtAllRecodes.Rows.Add(detail.Inquiry_ID, detail.CustomerName, detail.InquiryDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                        bOk = true; 
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
            dtAllRecodes.Columns.Add("InquiryCode", typeof(string));
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
        private void chkInquiryCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInquiryCode.Checked)
            {
                txtInquiryCode.Enabled = false;
            }
            else
            {
                txtInquiryCode.Enabled = true;
                txtInquiryCode.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtInquiryCode);
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

        private void chkCustomerID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCustomerID.Checked)
            {
                txtCustomerID.Enabled = false;
            }
            else
            {
                txtCustomerID.Enabled = true;
                txtCustomerID.Text = "";
                sFilteQuary = "";
                createFilterQuary(txtCustomerID);
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
            Search_Inquiry();
        }
        #endregion
               
        #region Events VisibleChanged
        private void frm_sasInquiryViewer_VisibleChanged(object sender, EventArgs e)
        {
            changeGridColor();
        }
        #endregion                                                                          

        #region Events KeyUp
        private void txtInquiryCode_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtInquiryCode);
        }

        

        private void txtCustomerID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtCustomerID);
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


        #region Search
        private void Search_Inquiry()
        {
            try
            {
                frm_sasInquiry frm = new frm_sasInquiry(FormName.sasInquiry);
                frm.glbInquiryID = dgvDetail[0, dgvDetail.CurrentCell.RowIndex].Value.ToString().Trim();
                clsHelpMethods_Local.DisplayForm(frm, clsFormatter.colorSales, this.MdiParent);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
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
                if (chkInquiryCode.Checked && argText.Name != "txtInquiryCode")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND InquiryCode LIKE '%" + txtInquiryCode.Text.Trim() + "%'";
                    else
                        sFilteQuary = " InquiryCode LIKE '%" + txtInquiryCode.Text.Trim() + "%'";
                }
                if (chkCustomerID.Checked && argText.Name != "txtCustomerID")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
                    else
                        sFilteQuary = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
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


                if (argText.Name == "txtInquiryCode")
                    sTemp = " InquiryCode LIKE '%" + txtInquiryCode.Text.Trim() + "%'";
                if (argText.Name == "txtCustomerID")
                    sTemp = " CustomerName LIKE '%" + txtCustomerID.Text.Trim() + "%'";
                if (argText.Name == "txtDate")
                    sTemp = " Date LIKE '%" + txtDate.Text.Trim() + "%'";
                if (argText.Name == "txtRefNo")
                    sTemp = " OrderRefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";

                if (argText.Name == "txtColourInProgress")
                    sTemp = " isSeattled = false AND isDeleted = false ";
                if (argText.Name == "txtColourCompleted")
                    sTemp = " isSeattled = true ";
                if (argText.Name == "txtColourDeleted")
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

                if (!(chkInquiryCode.Checked || chkCustomerID.Checked || chkDate.Checked || chkRefNo.Checked))
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
                dgvDetail.Rows[i].DefaultCellStyle.ForeColor = GetColorForInquiry(dgvDetail.Rows[i].Cells["RegisterCode"].Value.ToString());
            }
            SetCounter();

        }
        #endregion

        #region GetColorForInquiry
        private Color GetColorForInquiry(string sRegisterID)
        {
            Color col = Color.Red;
            tbl_sasInquiry detail = tbl_sasInquiry.Select(sRegisterID);
            if (detail != null)
            {
                if (detail.IsSeattled)
                {
                    col = clsFormatter.colorCompleted;
                    ++cSettled;
                }
                else
                {
                    col = clsFormatter.colorInProgress;
                    ++cUnSettled;
                }
                if (detail.IsDeleted)
                {
                    col = clsFormatter.colorDeleted;
                    ++cDelete;
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
            dgvDetail.Columns["Grandtotal"].Width = 110;
            if (dgvDetail.Rows.Count > 22)
                dgvDetail.Columns["Grandtotal"].Width -= 15;
            else
                dgvDetail.Columns["Grandtotal"].Width = 110;
        }
        #endregion

        #region fill Inquiry 
        private void fillInquiry(TextBox txt)
        {
            dtAllRecodes.Clear();
            List<vw_search_sasInquiry> details = vw_search_sasInquiry.SelectAll();
            if (txt.Name == "txtColourInProgress")
            {
                foreach (vw_search_sasInquiry detail in details)
                {
                    if (detail.IsSeattled == false && detail.IsDeleted == false)
                        dtAllRecodes.Rows.Add(detail.Inquiry_ID, detail.CustomerName, detail.InquiryDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == "txtColourCompleted")
            {
                foreach (vw_search_sasInquiry detail in details)
                {
                    if (detail.IsSeattled == true)
                        dtAllRecodes.Rows.Add(detail.Inquiry_ID, detail.CustomerName, detail.InquiryDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
                }
            }
            if (txt.Name == "txtColourDeleted")
            {
                foreach (vw_search_sasInquiry detail in details)
                {
                    if (detail.IsDeleted == true)
                        dtAllRecodes.Rows.Add(detail.Inquiry_ID, detail.CustomerName, detail.InquiryDate, detail.OrderRefNo, clsFormatter.FormatToCurrecyWithThousendSep(detail.GrandTotal), detail.IsSeattled, detail.IsDeleted);
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
