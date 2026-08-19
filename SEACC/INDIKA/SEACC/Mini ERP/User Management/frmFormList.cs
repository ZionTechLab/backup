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
    public partial class frmFormList : Form
    {
        

        //to keep glob ref no
        public string glbOrderRefNo = "", glbHeader = "", glbReturnNoteID = "", glbSub = "", glbPamentVoucherNo="";
        public List<string> glbOrderRefNos = new List<string>();
        public ProcessNote pn;

        


        #region Form Load
        public frmFormList()
        {
            InitializeComponent();
        }

        private void frmFormList_Load(object sender, EventArgs e)
        {
            CusDataGridViewFormat();
            glbReturnNoteID = "";
            clsFormatter.setFormatForm(this, "", 2,0);

            if (glbOrderRefNo.Length > 0 && glbOrderRefNo != "default")
            {
                tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(glbOrderRefNo);
                if (order != null && pn != null)
                    clsHelpMethods_Local.FillProcessNotes(order.OrderRefNo_ID, dgvDetail, pn);
            }
            else if (glbOrderRefNos.Count > 0)
            {
                clsHelpMethods_Local.FillProcessNotes(glbOrderRefNos, dgvDetail, pn);
            }

            else if (glbPamentVoucherNo.Length > 0 && glbPamentVoucherNo != "default")
            {
                tbl_accPaymentVoucher pv = tbl_accPaymentVoucher.Select(glbPamentVoucherNo);
                if (pv != null && pn != null)
                {
                    clsHelpMethods_Local.FillProcessNotes(pv.PaymentVoucher_ID, dgvDetail, pn);
                }
            }

        }

       
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Btn Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                glbReturnNoteID = clsValidate.ValidateGridValue(dgvDetail, "NoteID", dgvDetail.SelectedRows[0].Index, "");
                this.Close();
            }
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
          //  clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSales2, clsFormatter.colorDigiteqTheamColorSales2ForColour);           

            //Change Grid Headers
            if (glbHeader.Length > 0)
            {
                if (glbSub == "")
                {
                    dgvDetail.Columns["NoteID2"].Visible = false;
                    this.Width = 285;
                }
                else
                    dgvDetail.Columns["NoteID2"].HeaderText = glbSub + " ID";
               
                dgvDetail.Columns["NoteID"].HeaderText = glbHeader + " ID";
                dgvDetail.Columns["NoteDate"].HeaderText = glbHeader + " Date";
                dgvDetail.Columns["NoteAmount"].HeaderText = glbHeader + " Amount";
            }
        }
        #endregion

        #region Datagrid Events
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        Cursor = Cursors.WaitCursor;
            //        string sColName = "";
            //        if (e.ColumnIndex >= 0)
            //            sColName = dgvDetail.Columns[e.ColumnIndex].Name;
            //        if (sColName == "NoteID")
            //        {
            //            string sAPNID = clsValidate.ValidateGridValue(dgvDetail, "NoteID", e.RowIndex, "");
            //            if (sAPNID.Length > 0)
            //            {
            //                frm_accAccountpayableNote frm = new frm_accAccountpayableNote();
            //                frm.glbAPNID = sAPNID;
            //                if (frm.bNoAccess)
            //                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                else
            //                {
            //                    frm.MdiParent = MdiParent;
            //                    frm.Show();
            //                }
            //            }
            //        }

            //        Cursor = Cursors.Default;
            //    }
            //    else { }
            //}
            //catch (Exception ex)
            //{
            //    clsValidate.WriteErrorLog("", 0,ex);
            //    SEACCException.Show(ex);
            //}
            //finally
            //{
            //    Cursor = Cursors.Default;
            //}
        }
        #endregion

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {                
                glbReturnNoteID = clsValidate.ValidateGridValue(dgvDetail, "NoteID", e.RowIndex, "");
                this.Close();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

    }
}
