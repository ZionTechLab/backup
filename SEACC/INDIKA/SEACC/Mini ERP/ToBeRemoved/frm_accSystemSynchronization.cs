using DataTire;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.ACC
{
    public partial class frm_accSystemSynchronization : Form
    {
        
        public int iFormID;
        public bool bNoAccess;
        DataTable dt_Result = new DataTable();


        #region Form Load
        public frm_accSystemSynchronization()
        {
            iFormID = clsSecurity.getFormID(FormName.accSystemSynchronization);

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            #region Init Dataset
            string qry_SRN = "exec sync_system_synchronization";
            dt_Result = DBHandling.ExecQuery(qry_SRN).Tables[0]; 
            #endregion

            InitializeComponent();
        }

        private void frm_accSystemSynchronization_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Synchronization", 2, iFormID);
        //    cmbNoteType.DataSource = Enum.GetNames(typeof(SynchronizableNoteTypes));

            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);

            dgvDetail.DataSource = dt_Result;
            ClearFields();
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, false))
            {
                Cursor = Cursors.WaitCursor;
                List<DataRow> dt_Rows_Post = new List<DataRow>();
                foreach (DataGridViewRow row in dgvDetail.Rows)
                {
                    try
                    {
                        //if (clsValidate.ValidateGridValue(dgvDetail, "IsSelect", row.Index, false))
                        //{
                        //    string sTrasectionID = clsValidate.ValidateGridValue(dgvDetail, "TransactionNo", row.Index, "");
                        //    string sTrasectionType = clsValidate.ValidateGridValue(dgvDetail, "TransactionType", row.Index, "");
                        //    string sTrasectionRemark = clsValidate.ValidateGridValue(dgvDetail, "Remarks", row.Index, "");

                        //    if (sTrasectionID != null && sTrasectionID.Length > 0)
                        //        switch (((SynchronizableNoteTypes)Enum.Parse(typeof(SynchronizableNoteTypes), sTrasectionType)))
                        //        {
                        //            case SynchronizableNoteTypes.INVOICE:
                        //                tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(sTrasectionID);
                        //                oInvoice.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //                oInvoice.Update();

                        //                oInvoice.Invoice_ID = "SYNC/" + oInvoice.Invoice_ID;//This statement for Testing purpose only - More Information for Calling Gayan

                        //                oInvoice.Sync_Insert();
                        //                break;

                        //            case SynchronizableNoteTypes.RECEIPT:
                        //                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(sTrasectionID);
                        //                oReceipt.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //                oReceipt.Update();

                        //                oReceipt.Receipt_ID = "SYNC/" + oReceipt.Invoice_ID;//This statement for Testing purpose only

                        //                oReceipt.Sync_Insert();
                        //                break;

                        //            case SynchronizableNoteTypes.SRN:
                        //                tbl_sasSalesReturnedNote oSRN = tbl_sasSalesReturnedNote.Select(sTrasectionID);
                        //                oSRN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //                oSRN.Update();

                        //                oSRN.SalesReturnedNote_ID = "SYNC/" + oSRN.SalesReturnedNote_ID;//This statement for Testing purpose only

                        //                oSRN.Sync_Insert();
                        //                break;

                        //            case SynchronizableNoteTypes.APN:
                        //                tbl_accAccountPayableNote oAPN = tbl_accAccountPayableNote.Select(sTrasectionID);
                        //                oAPN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //                oAPN.Update();

                        //                oAPN.AccountPayableNote_ID = "SYNC/" + oAPN.AccountPayableNote_ID;//This statement for Testing purpose only

                        //                oAPN.Sync_Insert();
                        //                break;

                        //            case SynchronizableNoteTypes.CRN:
                        //                tbl_bpsCreditNote oCRN = tbl_bpsCreditNote.Select(sTrasectionID);
                        //                oCRN.PostingStatus_ID = clsAutocode.getGLPostingStatusID(GLPostingStatus.Posted);
                        //                oCRN.Update();

                        //                oCRN.CreditNote_ID = "SYNC/" + oCRN.CreditNote_ID;//This statement for Testing purpose only

                        //                oCRN.Sync_Insert();
                        //                break;
                        //        }

                        //    dt_Rows_Post.Add(dt_Result.Select("TransactionNo = '" + sTrasectionID + "'").FirstOrDefault());
                        //}
                    }
                    catch (Exception ex)
                    {
                        SEACCException.Show(ex);
                    }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }

                #region Remove Posting Transactions form table
                foreach (DataRow r in dt_Rows_Post)
                    r.Delete();
                #endregion

            }

        }
        #endregion

        #region btn Load
        private void btnLoad_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dtpStartDate.Value = clsSecurity.getServerDateTime();
            dtpEndDate.Value = clsSecurity.getServerDateTime();
            chkShowAll.Checked = true;
            cmbNoteType.SelectedIndex = 0;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            string sFilter = "";

            if (cmbNoteType.SelectedIndex != 0)
                sFilter = "TransactionType = '" + cmbNoteType.SelectedValue + "'";

            if (!chkShowAll.Checked)
                sFilter += ((sFilter != "") ? " AND " : "") + "Date >= #" + dtpStartDate.Value.Date + "# AND Date <= #" + dtpEndDate.Value.Date + "#";

            dt_Result.DefaultView.RowFilter = sFilter;
        }
        #endregion

        #region Grid Event
        private void dgvTransactions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                if (sColName == "TransactionType" || sColName == "TransactionNo" || sColName == "Amount")
                {
                    string sTrasectionID = dgvDetail["TransactionNo", e.RowIndex].Value.ToString();
                    string sTrasectionType = dgvDetail["TransactionType", e.RowIndex].Value.ToString();

                   // if (sTrasectionID != null && sTrasectionID.Length > 0)
                        //switch (((SynchronizableNoteTypes)Enum.Parse(typeof(SynchronizableNoteTypes), sTrasectionType)))
                        //{
                        //    case SynchronizableNoteTypes.INVOICE:
                        //        frm_sasInvoice2 oInvoice = new frm_sasInvoice2(FormName.SalesInvoice2);
                        //        oInvoice.glbInvoiceID = sTrasectionID;
                        //        //oInvoice.ShowDialog();
                        //        break;

                        //    case SynchronizableNoteTypes.RECEIPT:
                        //        frm_bpsReceipt_Sales oReceipt = new frm_bpsReceipt_Sales();
                        //        oReceipt.gReceiptID = sTrasectionID;
                        //        oReceipt.ShowDialog();
                        //        break;

                        //    case SynchronizableNoteTypes.SRN:
                        //        frm_sasSalseReturnNote oSRN = new frm_sasSalseReturnNote();
                        //        oSRN.glbSalesReturnedNoteID = sTrasectionID;
                        //        oSRN.ShowDialog();
                        //        break;

                        //    case SynchronizableNoteTypes.APN:
                        //        frm_accAccountpayableNote oAPN = new frm_accAccountpayableNote();
                        //        oAPN.glbAPNID = sTrasectionID;
                        //        oAPN.ShowDialog();
                        //        break;

                        //    case SynchronizableNoteTypes.CRN:
                        //        frm_bpsCreditNote oCRN = new frm_bpsCreditNote();
                        //        oCRN.glbCreditNoteID = sTrasectionID;
                        //        oCRN.ShowDialog();
                        //        break;
                        //}
                }

                if (sColName == "IsSelect")
                {
                    bool bIsSelect = (clsValidate.ValidateGridValue(dgvDetail, "IsSelect", e.RowIndex, false) == true) ? true : false;
                    dgvDetail["IsSelect", e.RowIndex].Value = bIsSelect ? false : true;
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Events Filter Changed

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cmbNoteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        #endregion
    }
}