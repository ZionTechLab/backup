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
    public partial class frm_bpsPettyCashIOUDetails : Form
    {

        #region Variable
        public string gblIOUID;
        public string gblPettyCash;
        public int gbllineNumber;
       
        int iline;
        #endregion

        #region Form Load
        public frm_bpsPettyCashIOUDetails()
        {
            InitializeComponent();
        }

        private void frm_bpsPettyCashIOUDetails_Load(object sender, EventArgs e)
        {
            //clsFormatter.setFormatForm(this, "Iou", 2);
            RefreshGrid();
            CusDataGridViewFormat();
            txtIOUID.Text = gblIOUID;
            tbl_bpsPettyCashAccount_IOU detail = tbl_bpsPettyCashAccount_IOU.Select(gblIOUID);
            txtIOUName.Text = detail.Remark;
        } 
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRownew;
            dgvDetail.Rows.Clear();
            decimal dBalance = 0;

            List<tbl_bpsPettyCashAccount_IOU_Detail> details = tbl_bpsPettyCashAccount_IOU_Detail.SelectAllByIouAccount_ID(gblIOUID);
            foreach (tbl_bpsPettyCashAccount_IOU_Detail detail in details)
            {
                dgvDetail.Rows.Add();
                iRownew = dgvDetail.Rows.Count - 1;

                dgvDetail["DateCreated", iRownew].Value = detail.IouDate.ToShortDateString();
                dgvDetail["DateCreated", iRownew].Tag = detail.IouDate;
                dgvDetail["Narration", iRownew].Value = detail.Remark;
                dgvDetail["line_No", iRownew].Value = detail.Line_NoIOU;
                //dgvDetail["User", iRownew].Value = detail.SpentUserName;

                if (detail.IsIncome)
                {
                    dgvDetail["Income", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance + detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
                }
                else if (detail.IsExpenditure)
                {
                    dgvDetail["Expendicher", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(detail.Amount);
                    dBalance = dBalance - detail.Amount;
                    dgvDetail["Balance", iRownew].Value = clsFormatter.FormatToCurrecyWithThousendSep(dBalance);
                }
            }
        }
         #endregion

        #region btn Close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region btn Refresh
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        } 
        #endregion

        #region Btn Delete
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (clsSecurity.PermissionToDeletePettyCash(gblPettyCash, clsSecurity.UserIDLoged))
                {

                    //delete one record
                    string strMessage = "";
                    Cursor = Cursors.WaitCursor;
                    if (iline >= 0)
                    {

                        tbl_bpsPettyCashAccount_IOU_Detail detail = tbl_bpsPettyCashAccount_IOU_Detail.Select(iline,gblIOUID);
                        if (detail != null)
                        {
                            DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (msgResult == DialogResult.Yes)
                            {
                                //detail.IsDeleted = true;
                                detail.Delete();
                            }
                            else if (msgResult == DialogResult.No)
                            {
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshGrid();
                    }
                    else
                    {
                        strMessage += "\n" + "Plase select the recode ";
                        MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else //if no permission to delete
                {
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            iline = int.Parse(dgvDetail["line_No", e.RowIndex].Value.ToString());
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion
    }
}
