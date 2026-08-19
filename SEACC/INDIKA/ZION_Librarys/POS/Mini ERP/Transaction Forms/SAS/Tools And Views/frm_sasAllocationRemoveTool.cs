using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_sasAllocationRemoveTool : MettroForm
    {
        public int iFormID=0;
        public bool bNoAccess = false;  
        public frm_sasAllocationRemoveTool()
        {
            iFormID = clsSecurity.getFormID(FormName.sasAllocationRemove);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do You Want To Remove Allocation (Tagging)? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
                try
                {
                    if (txtAllocationID.Text != "" || txtAllocationID.Tag != null)
                    {
                        Cursor = Cursors.WaitCursor;
                        clsHelpMethods.RemoveSattlementsFrom_AllocationID(txtAllocationID.Text.Trim(), true);
                        Cursor = Cursors.Default;
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Please Select the Allocation to be Removed", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information); 
                        txtAllocationID.Focus();
                    }
                }
                catch(Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
            }

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void frm_sasAllocationRemoveTool_Load(object sender, EventArgs e)
        {
           
                ClearFields();
                clsFormatter.ApplyGridFormat(dgvDetail);
                dgvDetail.ScrollBars = ScrollBars.Both;
        }
        private void txtReceiptID_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_ReceiptID();
        }
        private void txtsettelment_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_Settelment();
            RefreshGridbySettlementID(txtAllocationID.Text.Trim());
        }
        private void txtReceiptID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ReceiptID();
            }
        }
        private void txtsettelment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_Settelment();
                RefreshGridbySettlementID(txtAllocationID.Text.Trim());
            }
        }

        #region Field Clear
        private void ClearFields()
        {
           
            txtReceiptID.Text = "";
            txtReceiptID.Tag = null;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, false);
            clsCommon.SetEnableDisable_NormalLabel(lblReceiptID, false);

            txtAllocationID.Text = "";
            txtAllocationID.Tag = null;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAllocationID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblAlocationID, true);

            txtInvoiceNo.Text="";
            txtInvoiceNo.Tag = null;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtInvoiceNo, false);
            clsCommon.SetEnableDisable_NormalLabel(lblInvoiceNo, false);

            txtCreaditNoteNo.Text = "";
            txtCreaditNoteNo.Tag = null;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtCreaditNoteNo, false);
            clsCommon.SetEnableDisable_NormalLabel(lblCreaditNoteNo, false);

            txtAllocationID.Focus();
            dgvDetail.Rows.Clear();
        } 
        #endregion

        #region Search Method
        private void Search_ReceiptID()
        {
            try
            {
                clsSearch.Search_TransactionReceipt_Direct(ref txtReceiptID, false, true, false, clsConfig.bEnableReceiptSort_ByReceiptID);
                if (txtReceiptID.TextLength > 0)
                {
                    Search_ReceiptID_Formatting(txtReceiptID.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }

        private void Search_Settelment()
        {
            try
            {
                clsSearch.Search_Settelment(ref txtAllocationID);
                if (txtReceiptID.TextLength > 0)
                {
                    Search_Settelment_Formatting(txtAllocationID.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }

        }

        #endregion

        #region Formatting Fields
        private void Search_ReceiptID_Formatting(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtReceiptID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblReceiptID, false);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        private void Search_Settelment_Formatting(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtAllocationID, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblAlocationID, false);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Grids
        private void RefreshGridbySettlementID(string sAllocationID)
        {
            int iRow = 0;
            dgvDetail.Rows.Clear();
            if (sAllocationID != "<Settlement ID>")
            {
                List<tbl_sasInvoice_Sattled> oItems = tbl_sasInvoice_Sattled.SelectAll();
                //We should Create a SP to Select using Settled_ID
                foreach (tbl_sasInvoice_Sattled oItem in oItems.Where(p => p.AllocationID.Trim() == sAllocationID.Trim()))
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["allocationiD", iRow].Value = oItem.AllocationID;
                    dgvDetail["invoiceid", iRow].Value = oItem.Invoice_ID;
                    dgvDetail["AllocationDate", iRow].Value = oItem.AllocationDate;
                    dgvDetail["SettledDate", iRow].Value = oItem.SattledDate;
                    dgvDetail["receiptid", iRow].Value = oItem.Receipt_ID;
                    dgvDetail["sattledAmount", iRow].Value = clsFormatter.FormatDecimalPlaces_Price( oItem.SattledAmount);
                    dgvDetail["isAdvancePayment", iRow].Value = oItem.IsAdvancePayment;
                    dgvDetail["isOverPayment", iRow].Value = oItem.IsOverPayment;
                }
            }
        }

        private void RefreshGridbyRecipt(string ReciptID)
        {
            int iRow = 0;
            dgvDetail.Rows.Clear();
            if (ReciptID != "<Settlement ID>")
            {
                List<tbl_bpsReceipt> oItems = tbl_bpsReceipt.SelectAll();
                //We should Create a SP to Select using Settled_ID
                foreach (tbl_bpsReceipt oItem in oItems.Where(p => p.Receipt_ID == ReciptID))
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail[0, iRow].Value = oItem.Receipt_ID;
                    dgvDetail[1, iRow].Value = clsGenaralName.getName_Customer(oItem.Customer_ID);
                    dgvDetail[2, iRow].Value = oItem.TotalAmount;
                    dgvDetail[3, iRow].Value = oItem.ReceiptDate;
                }

            }
        }
        
        #endregion

  
     
        
    }
}
