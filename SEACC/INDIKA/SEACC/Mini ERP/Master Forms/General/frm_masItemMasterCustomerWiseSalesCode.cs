using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_masItemMasterCustomerWiseSalesCode : MettroForm
    {
        #region Variables
        //to manage update and insert
     



        private BindingSource bindingSource = new BindingSource();
        private DataTable dtItemRecodes = new DataTable();

        #endregion

        #region Form Load
        public frm_masItemMasterCustomerWiseSalesCode()
        {
            #region Initialize From
            iFormID = clsSecurity.getFormID(FormName.ItemMasterCustomerWiseSalesCode);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
            clsFormatter.setFormatForm(this, clsGenaralName.getName_FormMaster(iFormID), 2, iFormID);
            #endregion
            IsUpdate = true;
            #region Initialize Data Table 
            dtItemRecodes.Columns.Add("item_ID", typeof(string));
            dtItemRecodes.Columns.Add("ItemName", typeof(string));
            dtItemRecodes.Columns.Add("itemSubCategory_ID", typeof(string));
            dtItemRecodes.Columns.Add("itemSubCategory2_ID", typeof(string));
            dtItemRecodes.Columns.Add("serialNo1", typeof(string));
            dtItemRecodes.Columns.Add("serialNo2", typeof(string));
            dtItemRecodes.Columns.Add("itemClass", typeof(string));
            dtItemRecodes.Columns.Add("itemType", typeof(string));
            dtItemRecodes.Columns.Add("itemCategory", typeof(string));
            dtItemRecodes.Columns.Add("pluCode", typeof(string));
            #endregion

            #region Initialize Data Grid
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            this.dgvDetail.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.dgvUserDetails_RowPostPaint);
            dgvDetail.DataSource = bindingSource;
            #endregion

            ClearFields();
        }
        #endregion



        #region Clear Fields
        private void ClearFields()
        {
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCustomer, true);

            txtCustomer.Tag = null;
            txtBranchID.Tag = null;

            txtCustomer.Text = "<Select a Customer>";
            txtBranchID.Clear();
            txtItemID.Clear();
            txtItemName.Clear();
            txtItemClass.Clear();
            txtItemType.Clear();
            txtItemCategory.Clear();

            chkItemID.Checked = false;
            chkItemName.Checked = false;
            chkItemClass.Checked = false;
            chkItemType.Checked = false;
            chkItemCatagory.Checked = false;

            txtItemID.Enabled = false;
            txtItemName.Enabled = false;
            txtItemClass.Enabled = false;
            txtItemType.Enabled = false;
            txtItemCategory.Enabled = false;

            dtItemRecodes.Clear();
        }
        #endregion

        #region Action Buttons
        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckValidity_Customer())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;

                            string sitem_ID = "", sitemSubCategory_ID = "", sitemSubCategory2_ID = "", sitemSerialNo = "", sitemSerialNo2 = "", sPLU_Code = "", sBranchID = "default";

                            if (txtCustomer.Tag != null)
                            {
                                foreach (DataGridViewRow row in dgvDetail.Rows)
                                {
                                    sitem_ID = clsValidate.ValidateGridValue(dgvDetail, "item_ID", row.Index, "default");
                                    sitemSubCategory_ID = clsValidate.ValidateGridValue(dgvDetail, "itemSubCategory_ID", row.Index, "default");
                                    sitemSubCategory2_ID = clsValidate.ValidateGridValue(dgvDetail, "itemSubCategory2_ID", row.Index, "default");
                                    sitemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "serialNo1", row.Index, "0");
                                    sitemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "serialNo2", row.Index, "0");
                                    sPLU_Code = clsValidate.ValidateGridValue(dgvDetail, "pluCode", row.Index, "");

                                    #region Update Finanace Customer Table
                                    tbl_genItemMaster_Finance_Customer detailsCustomer = tbl_genItemMaster_Finance_Customer.Select(txtCustomer.Tag.ToString(), sBranchID, sitem_ID, sitemSubCategory_ID, sitemSubCategory2_ID, sitemSerialNo, sitemSerialNo2);
                                    if (detailsCustomer != null)
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), sitem_ID, "Item Master Finance - Update PLU Code : " + sPLU_Code + " Customer : " + txtCustomer.Text.Trim());

                                        //Update Record
                                        detailsCustomer.PluCode = sPLU_Code;
                                        detailsCustomer.Update();
                                    }
                                    else
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), sitem_ID, "Item Master Finance - Update PLU Code : " + sPLU_Code + " Customer : " + txtCustomer.Text.Trim());

                                        //Insert Records Customer
                                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                                        tbl_genItemMaster_Finance_Customer insertDetailsCustomer = new tbl_genItemMaster_Finance_Customer(txtCustomer.Tag.ToString(), sBranchID, sitem_ID, sitemSubCategory_ID,
                                            sitemSubCategory2_ID, sitemSerialNo, sitemSerialNo2, 0, 0,
                                            (oCustomer != null ? oCustomer.IsVATenable : false),
                                            (oCustomer != null ? oCustomer.IsNBTenable : false), 0, sPLU_Code);
                                        insertDetailsCustomer.Insert();
                                    }
                                    #endregion
                                }
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(" It is not Allowed to Save without a Customer\n Please Select The Customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            RefreshGrid(txtCustomer.Tag.ToString(), "default");
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn close
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion 
        #endregion

        #region Refresh Grid
        private void RefreshGrid(string sCustomer_ID, string sBranch_ID)
        {
            try
            {
                dtItemRecodes.Rows.Clear();
                //string sPLU_Code = "";
                //foreach (tbl_genItemMaster oItem in tbl_genItemMaster.SelectAll().Where(r => r.IsSalesItem && !r.IsDeleted))
                //{
                //    sPLU_Code = "";
                //    tbl_genItemMaster_Finance_Customer oItemCustomer = tbl_genItemMaster_Finance_Customer.Select(sCustomer_ID, sBranch_ID, oItem.Item_ID, oItem.ItemCategorySub_ID, "default", "0", "0");
                //    if (oItemCustomer != null)
                //        sPLU_Code = oItemCustomer.PluCode;

                //    dtItemRecodes.Rows.Add(oItem.Item_ID, oItem.ItemName, oItem.ItemCategorySub_ID, "default", "0", "0", clsGenaralName.getName_ItemClass(oItem.ItemClass_ID), clsGenaralName.getName_ItemType(oItem.ItemType_ID), clsGenaralName.getName_ItemCategory(oItem.ItemCategory_ID), sPLU_Code);
                //}
                string sQuary = "Exec sp_PLUCodeDetails '"+ sCustomer_ID + "', '"+ sBranch_ID + "'";
                dtItemRecodes.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);

                bindingSource.DataSource = dtItemRecodes;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckValidity_Customer()
        {
            bool bStatus = true;
            try
            {
                if (clsConfig.bIsCustomerMandatory_ItemFinanceScreen)
                {
                    if (txtCustomer.Tag == null || txtCustomer.Tag.ToString().Trim().Length == 0 || txtCustomer.Tag.ToString().Trim() == "default")
                    {
                        bStatus = false;
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
                MessageBox.Show(" It is not Allowed to Save without a Customer\n Please Select The Customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Checked Changed
        private void chkItemID_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemID.Checked)
            {
                txtItemID.Enabled = false;
            }
            else
            {
                txtItemID.Enabled = true;
            }
            createFilterQuary(txtItemID);
        }
        private void chkItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemName.Checked)
                txtItemName.Enabled = false;
            else
                txtItemName.Enabled = true;

            createFilterQuary(txtItemName);
        }
        private void chkItemClass_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemClass.Checked)
                txtItemClass.Enabled = false;
            else
                txtItemClass.Enabled = true;

            createFilterQuary(txtItemClass);
        }
        private void chkItemType_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemType.Checked)
                txtItemType.Enabled = false;
            else
                txtItemType.Enabled = true;

            createFilterQuary(txtItemType);
        }
        private void chkItemCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkItemCatagory.Checked)
                txtItemCategory.Enabled = false;
            else
                txtItemCategory.Enabled = true;

            createFilterQuary(txtItemCategory);
        }
        private void chkItemSubCategory_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Search Event Double Click
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
            if (txtCustomer.Tag != null)
            {
                tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                if (oCustomer != null)
                    RefreshGrid(oCustomer.Customer_ID, "default");
            }
        }
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {
            //Search_CustomerBranch();
            //if (txtBranchID.Tag != null)
            //{
            //    RefreshGrid();
            //}
        }
        #endregion

        #region Search Event KeyDown
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                txtCustomer_DoubleClick(sender, e);
            }
        }
        private void txtBranchID_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Event KeyUp      
        private void txtItemID_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemID);
        }
        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemName);
        }
        private void txtItemClass_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemClass);
        }
        private void txtItemType_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemType);
        }
        private void txtItemCategory_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemCategory);
        }
        private void txtSubCategory2_KeyUp(object sender, KeyEventArgs e)
        {

        }
        #endregion

        #region Grid Events
        private void dgvUserDetails_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(clsFormatter.colorDigiteqTheamColorSales1ForColour))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString().PadLeft(4, ' '), e.InheritedRowStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }
        #endregion

        #region Help Methods

        #region Binding Source Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sFinalQuary = "";

                if (chkItemID.Checked)
                {
                    if (sFinalQuary.Trim().Length > 0)
                        sFinalQuary += " AND item_ID LIKE '%" + txtItemID.Text.Trim() + "%'";
                    else
                        sFinalQuary = " item_ID LIKE '%" + txtItemID.Text.Trim() + "%'";
                }
                if (chkItemName.Checked)
                {
                    if (sFinalQuary.Trim().Length > 0)
                        sFinalQuary += " AND ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                    else
                        sFinalQuary = " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                }
                if (chkItemClass.Checked)
                {
                    if (sFinalQuary.Trim().Length > 0)
                        sFinalQuary += " AND itemClass LIKE '%" + txtItemClass.Text.Trim() + "%'";
                    else
                        sFinalQuary = " itemClass LIKE '%" + txtItemClass.Text.Trim() + "%'";
                }
                if (chkItemType.Checked)
                {
                    if (sFinalQuary.Trim().Length > 0)
                        sFinalQuary += " AND itemType LIKE '%" + txtItemType.Text.Trim() + "%'";
                    else
                        sFinalQuary = " itemType LIKE '%" + txtItemType.Text.Trim() + "%'";
                }
                if (chkItemCatagory.Checked)
                {
                    if (sFinalQuary.Trim().Length > 0)
                        sFinalQuary += " AND itemCategory LIKE '%" + txtItemCategory.Text.Trim() + "%'";
                    else
                        sFinalQuary = " itemCategory LIKE '%" + txtItemCategory.Text.Trim() + "%'";
                }

                bindingSource.Filter = "";
                if (sFinalQuary.Trim().Length > 0)
                    bindingSource.Filter = sFinalQuary;

                if (!(chkItemID.Checked || chkItemName.Checked || chkItemClass.Checked || chkItemType.Checked || chkItemCatagory.Checked))
                {
                    sFinalQuary = "";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Search Methods
        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomer.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomer.Tag = frmSearchMaster.s_SearchID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }

        private void Search_CustomerBranch()
        {
            if (txtCustomer.Tag != null)
            {
                clsSearch.Search_CustomerBranch(ref txtBranchID, txtCustomer.Tag.ToString());

                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.Search_CustomerBranch(txtCustomer.Tag.ToString());
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //    txtBranchID.Tag = frmSearchMaster.s_SearchID;
                //if (frmSearchMaster.s_SearchText.Length > 0)
                //    txtBranchID.Text = frmSearchMaster.s_SearchText;
            }

        }
        #endregion
        #endregion
    }
}
