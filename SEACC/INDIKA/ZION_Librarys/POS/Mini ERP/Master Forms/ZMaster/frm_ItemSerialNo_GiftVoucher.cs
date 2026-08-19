using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_ItemSerialNo_GiftVoucher : MettroForm
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
     //   string s_FileName;
           public int iFormID;
        public bool bNoAccess;
        Byte[] img = new byte[0];
        #endregion

        #region Form Load
        public frm_ItemSerialNo_GiftVoucher()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.zGiftVoucherMaster);
            iFormID = clsSecurity.getFormID(FormName.zGiftVoucherMaster);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_ItemSerialNo_GiftVoucher_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "Gift Voucher Master Form", 1, iFormID);

            //add data to the datagrid and format
            RefreshGrid();
            CusDataGridViewFormat();
            txtItemSerialNo_TextChanged(sender, e);
            ClearFields();
        }
        #endregion


        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtItemSerialNo.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {                        
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_zItemSerialNo_GiftVoucher detail = tbl_zItemSerialNo_GiftVoucher.Select(txtItemSerialNo.Text.Trim());
                        if (detail != null && !detail.IsDeleted && !detail.IsRedeem)
                        {
                            detail.Delete();

                            tbl_zItemSerialNo detailPK = tbl_zItemSerialNo.Select(txtItemSerialNo.Text.Trim());
                            if (detailPK != null && !detailPK.IsDeleted)
                            {
                                detailPK.Delete();
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        Cursor = Cursors.Default;
                        ClearFields();
                        RefreshGrid();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (PrimaryKeyValidity())
                    {
                        if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                        {
                            try
                            {
                                Cursor = Cursors.WaitCursor;
                                if (txtItemSerialNo.TextLength > 0)
                                {
                                    if (IsUpdate)  //update records
                                    {
                                        //tbl_zItemSerialNo
                                        tbl_zItemSerialNo oldRecord2 = tbl_zItemSerialNo.Select(txtItemSerialNo.Text.Trim());

                                        if (oldRecord2 != null)
                                        {
                                            tbl_zItemSerialNo oItemSerialNo = new tbl_zItemSerialNo(txtItemSerialNo.Text.Trim(), txtItemName.Tag.ToString(), "default", "default", "default", clsSecurity.getServerDateTime(),
                                                txtDescription.Text.Trim(), "", "", "", "", "", 0, decimal.Parse(txtVoucherAmount.Text.Trim()), decimal.Parse(txtVoucherAmount.Text.Trim()), 0, 0, false, false, false,
                                                oldRecord2.CreateUser_ID, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, oldRecord2.CreateTerminal_ID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                                oldRecord2.DateCreate, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false);
                                            oItemSerialNo.Update();
                                        }

                                        //Item SerialNo_GiftVoucher
                                        tbl_zItemSerialNo_GiftVoucher oldRecord = tbl_zItemSerialNo_GiftVoucher.Select(txtItemSerialNo.Text.Trim());
                                        if (oldRecord != null)
                                        {
                                            tbl_zItemSerialNo_GiftVoucher detail = new tbl_zItemSerialNo_GiftVoucher(txtItemSerialNo.Text, txtItemName.Tag.ToString(), txtDescription.Text.Trim(),
                                            dtpDateValidFrom.Value.Date, dtpDateValidTill.Value.Date, decimal.Parse(txtVoucherAmount.Text.Trim()), oldRecord.CreateUser_ID, oldRecord.ModifiedUser_ID, oldRecord.CheckedUser_ID,
                                            oldRecord.ApprovedUser_ID, oldRecord.DeletedUser_ID, oldRecord.PrintedUser_ID, oldRecord.CreateTerminal_ID, oldRecord.ModifiedTerminal_ID,
                                            oldRecord.DeletedTerminal_ID, oldRecord.PrintedTerminal_ID, oldRecord.DateCreate, clsSecurity.getServerDateTime(), oldRecord.DateChecked, oldRecord.DateApproved,
                                            oldRecord.DateDeleted, oldRecord.DatePrinted, oldRecord.IsChecked, oldRecord.IsApproved, oldRecord.IsFinished, oldRecord.IsSold, oldRecord.IsRedeem, oldRecord.IsLocked, oldRecord.IsDeleted, oldRecord.PrintCount);
                                            detail.Update();
                                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else  //insert records
                                    {
                                        if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                            txtItemSerialNo.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                        //tbl_zItemSerialNo
                                        tbl_zItemSerialNo oItemSerialNo = new tbl_zItemSerialNo(txtItemSerialNo.Text.Trim(), txtItemName.Tag.ToString(), "default", "default", "default", clsSecurity.getServerDateTime(),
                                            txtDescription.Text.Trim(), "", "", "", "", "", 0, decimal.Parse(txtVoucherAmount.Text.Trim()), decimal.Parse(txtVoucherAmount.Text.Trim()), 0, 0, false, false, false,
                                            clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                            clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false);
                                        oItemSerialNo.Insert();                                      

                                        //Item SerialNo_GiftVoucher                               
                                        tbl_zItemSerialNo_GiftVoucher detail = new tbl_zItemSerialNo_GiftVoucher(txtItemSerialNo.Text, txtItemName.Tag.ToString(), txtDescription.Text.Trim(),
                                        dtpDateValidFrom.Value.Date, dtpDateValidTill.Value.Date, decimal.Parse(txtVoucherAmount.Text.Trim()), clsSecurity.UserIDLoged, clsSecurity.UserIDLoged,
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.TerminalID,
                                        clsSecurity.TerminalID, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false, false, false, false, false, false, 0);
                                        detail.Insert();

                                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(" Gift Voucher " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            catch (Exception ex)
                            {
                                SEACCException.Show(ex);
                            }
                            finally
                            {
                                Cursor = Cursors.Default;
                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
        }
        #endregion
     

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorAdminHeaderColour, clsFormatter.colorDigiteqTheamColorAdminForColour);            
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtItemSerialNo, true);
            clsCommon.SetEnableDisable_NormalLabel(lblItemSerialNo, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtItemName, false);

            txtItemSerialNo.Tag = null;
            txtItemSerialNo.Clear();
            txtItemName.Tag = clsConfig.sGiftVoucherCode;
            txtItemName.Text = clsGenaralName.getName_Item(clsConfig.sGiftVoucherCode);
            txtDescription.Clear();
            txtVoucherAmount.Text = "0.00";
            dtpDateValidFrom.Text = clsSecurity.getServerDateTime().ToString();
            dtpDateValidTill.Text = clsSecurity.getServerDateTime().ToString();

           
            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtItemSerialNo.Text = "<Auto Generate>";
            else
                txtItemSerialNo.Clear();

            if (txtItemSerialNo.Enabled)
            {
                txtItemSerialNo.SelectAll();
                txtItemSerialNo.Focus();
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_zItemSerialNo_GiftVoucher detail = tbl_zItemSerialNo_GiftVoucher.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtItemSerialNo, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblItemSerialNo, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtItemName, false);

                    //asign values
                    txtItemSerialNo.Tag = detail.ItemSerialNo;
                    txtItemSerialNo.Text = detail.ItemSerialNo;
                    txtItemName.Tag = detail.Item_ID;
                    txtItemName.Text = clsGenaralName.getName_Item(detail.Item_ID);
                    txtDescription.Text = detail.Description;
                    txtVoucherAmount.Text = clsFormatter.FormatDecimalPlaces_Price(detail.VoucherAmount);
                    dtpDateValidFrom.Text = detail.DateValidFrom.ToString();
                    dtpDateValidTill.Text = detail.DateValidTill.ToString();
                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            int iRow;
            dgvDetail.Rows.Clear();

            foreach (tbl_zItemSerialNo_GiftVoucher detail in tbl_zItemSerialNo_GiftVoucher.SelectAll())            
            {
                if (detail.ItemSerialNo != "default")
                {
                    dgvDetail.Rows.Add();
                    iRow = dgvDetail.Rows.Count - 1;
                    dgvDetail["itemSerialNo", iRow].Value = detail.ItemSerialNo;
                    dgvDetail["item_ID", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvDetail["description", iRow].Value = detail.Description;
                    dgvDetail["dateValidFrom", iRow].Value = detail.DateValidFrom.ToString("dd/MM/yyyy");
                    dgvDetail["dateValidTill", iRow].Value = detail.DateValidTill.ToString("dd/MM/yyyy");
                    dgvDetail["voucherAmount", iRow].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(detail.VoucherAmount);                    
                }
            }
           
        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";// strMessage2 = "";           
            bool bStatus = true;

            if (txtItemSerialNo.TextLength == 0)
            {
                strMessage += "\n" + "Item Serial No";
                bStatus = false;
            }
            if (txtItemName.TextLength == 0)
            {
                strMessage += "\n" + "Item Name";
                bStatus = false;
            }
            if (! (decimal.Parse( txtVoucherAmount.Text) > 0))
            {
                strMessage += "\n" + "The Voucher Amount should be greater than zero.. ";
                bStatus = false;
            }         

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool PrimaryKeyValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {
                foreach (tbl_zItemSerialNo_GiftVoucher oGiftVoucher in tbl_zItemSerialNo_GiftVoucher.SelectAll().Where(p => !p.IsDeleted && !p.IsLocked))
                {
                    if (Convert.ToInt32(oGiftVoucher.ItemSerialNo) == Convert.ToInt32(txtItemSerialNo.Text.Trim()))
                    {
                        bStatus = false;
                        strMessage = "This Item Serial No. has used before. Please enter a different Serial No...";
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(strMessage, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Events KeyDown
        private void txtItemSerialNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                clsSearch.Search_ItemSerialNo_GiftVoucher(ref txtItemSerialNo);

                if (txtItemSerialNo.TextLength > 0 && txtItemSerialNo.Tag != null)
                {
                    FillDetails(txtItemSerialNo.Tag.ToString());
                }
            }
        }
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_ItemMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtItemName.Tag = frmSearchMaster.s_SearchID;
                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtItemName.Text = frmSearchMaster.s_SearchText;
            }
        }
        private void frm_mtrUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events KeyPress
        private void txtVoucherAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtVoucherAmount.Text, e);
        }    
        #endregion

        #region Events DoubleClick
        private void txtUserID_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemSerialNo_GiftVoucher();
        }
        private void txtGroupName_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemName();
        }
        #endregion

        #region Events Datagrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sID = dgvDetail["itemSerialNo", e.RowIndex].Value.ToString();
                if (sID.Length > 0)
                {
                    FillDetails(sID.Trim());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetail_CellClick(sender, e);
        }
        #endregion

        #region Search Methods
        private void Search_ItemSerialNo_GiftVoucher()
        {
            clsSearch.Search_ItemSerialNo_GiftVoucher(ref txtItemSerialNo);
            if (txtItemSerialNo.TextLength > 0 && txtItemSerialNo.Tag != null)
            {
                FillDetails(txtItemSerialNo.Tag.ToString());
            }
        }
        private void Search_ItemName()
        {
            Form frmhelpsearch = new frmSearchMaster();
            clsSearch.passValue_ItemMaster();
            frmhelpsearch.ShowDialog();

            if (frmSearchMaster.s_SearchID.Length > 0)
                txtItemName.Tag = frmSearchMaster.s_SearchID;
            if (frmSearchMaster.s_SearchText.Length > 0)
                txtItemName.Text = frmSearchMaster.s_SearchText;
        }
        #endregion       

        private void txtItemSerialNo_TextChanged(object sender, EventArgs e)
        {
            int Max = 0;
            foreach (tbl_zItemSerialNo_GiftVoucher oGiftVoucher in tbl_zItemSerialNo_GiftVoucher.SelectAll().Where(p=>!p.IsDeleted && !p.IsLocked))
            {
                if (Convert.ToInt32(oGiftVoucher.ItemSerialNo) > Max)
                    Max = Convert.ToInt32(oGiftVoucher.ItemSerialNo);
            }
            lblHighestReceiptNo.Text = Max.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblHighestReceiptNo_Click(object sender, EventArgs e)
        {

        }

        private void txtItemSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            clsValidate.AllowDecimal(txtVoucherAmount.Text, e);
        }
    }
}
