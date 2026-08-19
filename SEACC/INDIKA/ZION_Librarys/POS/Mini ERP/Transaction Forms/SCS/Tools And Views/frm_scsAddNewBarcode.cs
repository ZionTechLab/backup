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
    public partial class frm_scsAddNewBarcode : Form
    {
        #region Variables
        //form manage
        string sFormConfigCode;
        public int iFormID;

        //for security handle
        public bool bNoAccess;


        DataTable dtBarcode = new DataTable();
        #endregion

        #region Form Load
        public frm_scsAddNewBarcode()
        {
            InitializeComponent();
        }

        public void show(string TransactionID, int iFormID)
        {   
            this.iFormID = iFormID;
            ClearFields();
            txtTransactionID.Text = TransactionID;
            RefreshGridItem(TransactionID);
            this.ShowDialog();
        }

        private void frm_scsAddNewBarcode_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Add Barcode", 2, iFormID);
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.scsAddBarcode);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {            
            //set the flag and enble the id            
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtTransactionID, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtBatchNo, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtSerialNo, true);
            clsCommon.SetEnableDisable_NormalCheckBox(chkCopytoNext, false);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpLocalDate, false);
            clsCommon.SetEnableDisable_NormalDateTimePicker(dtpOEMDate, !false);

            this.ActiveControl = txtSerialNo;            

            txtTransactionID.Tag = null;
            txtBatchNo.Tag = null;
            
            txtBatchNo.Clear();
            txtSerialNo.Clear();
            txtTransactionID.Clear();

            txtTransactionID.Text = "";
            txtSerialNo.Text = "";
            txtBatchNo.Text = "";

            dtpLocalDate.Value = clsSecurity.getServerDateTime();
            dtpOEMDate.Value = clsSecurity.getServerDateTime();

          //  dgvItem.Rows.Clear();
         //   dgvBarcode.Rows.Clear();

            if (this.iFormID != 129)
                pnlGRN.Visible = false;
        }
        #endregion

        #region Clear Method
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Refresh Grid
        #region Refresh Item Grid
        private void RefreshGridItem(string sTransactionCode)
        {
            try
            {
                int iRow;
                dgvItem.Rows.Clear();

                if (this.iFormID == 129)
                {
                    foreach (tbl_scsExternalGoodReceivedNote_Detail detail in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(sTransactionCode).OrderBy(p => p.Line_No))
                    {
                        dgvItem.Rows.Add();
                        iRow = dgvItem.Rows.Count - 1;
                        dgvItem["itemID", iRow].Value = detail.Item_ID;
                        dgvItem["itemDescription", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                        dgvItem["itemQty", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);
                    }
                }
                else
                {
                    foreach (tbl_sasDeliveryOrder_Detail detail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(sTransactionCode).OrderBy(p => p.Line_No))
                    {
                        dgvItem.Rows.Add();
                        iRow = dgvItem.Rows.Count - 1;
                        dgvItem["itemID", iRow].Value = detail.Item_ID;
                        dgvItem["itemDescription", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                        dgvItem["itemQty", iRow].Value = clsFormatter.FormatToNumberNoDecimal(detail.Qty);
                    }
                }
                dgvItem.Rows[0].Selected = true;
                RefreshGridBarcode();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Refresh Barcode Grid
        private void RefreshGridBarcode()
        {
            try
            {
                int iRow = dgvItem.SelectedRows[0].Index; ;
                string sItemID = dgvItem["itemID", iRow].Value.ToString();

                string sQuary = "exec [sp_ItemMaster_Barcode_SelectAll] '" + sItemID + "','" + txtTransactionID.Text + "'";
                dtBarcode = DBHandling.ExecQuery(sQuary).Tables[0];
                dgvBarcode.DataSource = dtBarcode;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #endregion



        #region Cell click event
        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {          
            RefreshGridBarcode();
        }

        private void dgvBarcode_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (dgvBarcode.SelectedCells.Count != 0)
                {
                    int iRow = dgvItem.SelectedRows[0].Index; ;
                    string sItemID = dgvItem["itemID", iRow].Value.ToString();
                    int iBarcodeID = int.Parse(dgvBarcode["barcode_ID", e.RowIndex].Value.ToString());

                    tbl_genItemMaster_Barcode detail = tbl_genItemMaster_Barcode.Select(iBarcodeID);
                    if (detail != null)
                    {
                        bool bisOkTodelete = true;
                        tbl_scsFixedAsset oFA = tbl_scsFixedAsset.Select(iBarcodeID);
                        if (oFA != null)
                        {
                            if (!oFA.IsDeleted)
                            { 
                                bisOkTodelete = false;
                                MessageBox.Show("Sorry, You cannot delete this serial number...!");
                            }
                        }
                        if (bisOkTodelete)
                        {
                            bool bOkToProseed = true;
                            if (this.iFormID == 129)
                            {
                                if (!detail.IsDelivered)
                                {
                                    DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (msgResult == DialogResult.Yes)
                                    {
                                        tbl_scsDocument_Barcode.DeleteAllByBarcode_ID(iBarcodeID);

                                        tbl_genItemMaster_Barcode itmBcd = tbl_genItemMaster_Barcode.Select(iBarcodeID);
                                        if (itmBcd != null)
                                        {
                                            itmBcd.Delete();
                                        }

                                        dgvBarcode.Rows.RemoveAt(dgvBarcode.SelectedCells[0].RowIndex);
                                    }
                                }
                            }
                            else
                            {
                                DialogResult msgResult = MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.AskForDelete, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (msgResult == DialogResult.Yes)
                                {
                                    tbl_scsDocument_Barcode oDocBarcode = tbl_scsDocument_Barcode.Select(iFormID.ToString(), txtTransactionID.Text, sItemID, iBarcodeID);
                                    if (oDocBarcode != null)
                                        oDocBarcode.Delete();

                                    tbl_genItemMaster_Barcode oItemBarcode = tbl_genItemMaster_Barcode.Select(iBarcodeID);
                                    if (oItemBarcode != null)
                                    {
                                        oItemBarcode.IsDelivered = false;
                                        oItemBarcode.Update();
                                    }

                                    dgvBarcode.Rows.RemoveAt(dgvBarcode.SelectedCells[0].RowIndex);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (txtSerialNo.Text != "")
                    {
                        if (txtTransactionID.Text.Trim().Length > 0)
                        {
                            if (dgvItem.SelectedRows.Count > 0)
                            {
                                int iRow = dgvItem.SelectedRows[0].Index; ;
                                string sItemID = dgvItem["itemID", iRow].Value.ToString();
                                int iTotalQty = int.Parse(dgvItem["itemQty", iRow].Value.ToString());

                                if (iTotalQty > dgvBarcode.RowCount)
                                {
                                    if (this.iFormID == 129)
                                    {
                                        tbl_genItemMaster_Barcode detail = tbl_genItemMaster_Barcode.Select(sItemID, txtSerialNo.Text);
                                        if (detail != null)
                                        {
                                            MessageBox.Show("Serial No already exist..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            int sBarcodeID = int.Parse(clsAutocode.getAutoGeneratedCode(sFormConfigCode));

                                            dtBarcode.Rows.Add(sBarcodeID, txtSerialNo.Text, txtSerialNo.Text, txtBatchNo.Text, clsFormatter.FormatDate_Short(dtpOEMDate.Value), clsFormatter.FormatDate_Short(dtpLocalDate.Value.Date));

                                            tbl_genItemMaster_Barcode itemBarcode = new tbl_genItemMaster_Barcode(sBarcodeID, sItemID, txtSerialNo.Text, "", txtBatchNo.Text, dtpOEMDate.Value, dtpLocalDate.Value, false, false, "");
                                            itemBarcode.Insert();

                                            tbl_scsDocument_Barcode DocBarcode = new tbl_scsDocument_Barcode(iFormID.ToString(), txtTransactionID.Text, sItemID, sBarcodeID);
                                            DocBarcode.Insert();


                                            #region Clear Fields
                                            if (!chkCopytoNext.Checked)
                                            {
                                                dtpLocalDate.Value = clsSecurity.getServerDateTime();
                                                dtpOEMDate.Value = clsSecurity.getServerDateTime();

                                                txtBatchNo.Clear();
                                            }
                                            txtSerialNo.Clear();
                                            txtSerialNo.Select();
                                            #endregion
                                        }
                                    }
                                    else
                                    {
                                        tbl_genItemMaster_Barcode detail = tbl_genItemMaster_Barcode.Select(sItemID, txtSerialNo.Text);
                                        if (detail != null)
                                        {
                                            if (!detail.IsDelivered)
                                            {
                                                dtBarcode.Rows.Add(detail.Barcode_ID, txtSerialNo.Text, txtSerialNo.Text, txtBatchNo.Text, clsFormatter.FormatDate_Short(dtpOEMDate.Value), clsFormatter.FormatDate_Short(dtpLocalDate.Value.Date));

                                                tbl_scsDocument_Barcode DocBarcode = new tbl_scsDocument_Barcode(iFormID.ToString(), txtTransactionID.Text, sItemID, detail.Barcode_ID);
                                                DocBarcode.Insert();

                                                detail.IsDelivered = true;
                                                detail.Update();
                                            }
                                            else
                                            {
                                                MessageBox.Show("Selected Serial already deliverd..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Serial No not exist..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                }
                                else
                                    MessageBox.Show("You have already filled the total qty..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show("Please select an item to proceed..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Transaction ID Cannot Be Empty..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Serial No. Cannot Be Empty..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog("", iFormID,ex);
                    SEACCException.Show(ex);
                }
            }
        }
    }
}