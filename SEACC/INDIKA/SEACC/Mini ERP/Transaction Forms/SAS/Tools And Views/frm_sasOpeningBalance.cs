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
    public partial class frm_sasOpeningBalance : Form
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
        

        public frm_sasOpeningBalance()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.CusDeliveryOrder);
            iFormID = clsSecurity.getFormID(FormName.CusDeliveryOrder);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasOpeningBalance_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Customer Balance Adjustment", 2, iFormID);
            CusDataGridViewFormat();

            RefreshGrid();
        
        }

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour);           
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
               // int iRow;
                dgvDetail.Rows.Clear();

                //List<tbl_sasDeliveryOrder_Detail> details = tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sDeliveryOrderID);
                //foreach (tbl_sasDeliveryOrder_Detail detail in details)
                //{
                //    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (item != null)
                //    {
                        dgvDetail.Rows.Add();
                        //iRow = dgvDetail.Rows.Count - 1;

                dgvDetail["InvoiceID", 0].Value = "Opening Balance";
                dgvDetail["InvoiceDate", 0].Value = clsSecurity.getServerDateTime().ToShortDateString();
                dgvDetail["InvoiceAmount", 0].Value = "785000.00";
                dgvDetail["DueAmount", 0].Value = "785000.00";

                dgvDetail.Rows.Add();

                dgvDetail["InvoiceID", 1].Value = "INV/A/001";
                dgvDetail["InvoiceDate", 1].Value = clsSecurity.getServerDateTime().ToShortDateString();
                dgvDetail["InvoiceAmount", 1].Value = "55000.00";
                dgvDetail["DueAmount", 1].Value = "50000.00";

                dgvDetail.Rows.Add();
                dgvDetail["InvoiceID", 2].Value = "INV/A/002";
                dgvDetail["InvoiceDate", 2].Value = clsSecurity.getServerDateTime().ToShortDateString();
                dgvDetail["InvoiceAmount", 2].Value = "45000.00";
                dgvDetail["DueAmount", 2].Value = "45000.00";
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }
        #endregion
    }
}
