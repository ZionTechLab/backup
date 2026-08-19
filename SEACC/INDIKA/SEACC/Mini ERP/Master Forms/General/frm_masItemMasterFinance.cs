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
    public partial class frm_masItemMasterFinance : MettroForm
    {

        #region Variables
        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";
        #endregion

        #region Form Load
        public frm_masItemMasterFinance()
        {
            iFormID = clsSecurity.getFormID(FormName.ItemMasterFinance);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
 
            InitializeComponent();
        }
        private void frm_masItemMasterFinance_Load(object sender, EventArgs e)
        {
            Refresh_Searchlabel();
            //format Form
            clsFormatter.setFormatForm(this, "Item Master Finance [IMF]", 2, iFormID);

            //add data to the datagrid and format
            dgvDetail.Columns["itemSubCategory_ID"].HeaderText = clsConfig.sItemSubCategory;
            dgvDetail.Columns["itemSubCategory2_ID"].HeaderText = clsConfig.sItemSubCategory2;
            chkItemSubCategory1.Text = clsConfig.sItemSubCategory;
            chkItemSubCategory2.Text = clsConfig.sItemSubCategory2;
            dgvDetail.DataSource = source;
            CreateDataTable();

            RefreshGrid();
            CusDataGridViewFormat();
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            txtCustomer.Tag = null;
            txtBranchID.Tag = null;
            txtItemName.Tag = null;
            txtSubCategory.Tag = null;

            txtCustomer.Clear();
            txtBranchID.Clear();
            txtItemName.Clear();
            txtSubCategory.Clear();

            dtAllRecodes.Clear();

            chkItemName.Checked = false;
            chkItemSubCategory1.Checked = false;

            RefreshGrid();
        }
        #endregion

        private void Refresh_Searchlabel()
        {
            chkItemName.Text = "Item Name";
            chkItemSubCategory1.Text = "Sub Category 1";
            chkPartNo.Text = "Part No";
            chkRefNo.Text = "Ref No";
            lblCustomerName.Text = "Customer Name";
            label2.Text = "Branch Name";
            chkItemCode.Text = "Item Code";
        }

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

                            string sitem_ID = "", sitemSubCategory_ID = "", sitemSubCategory2_ID = "", sitemSerialNo = "", sitemSerialNo2 = "";//sItemName = "",
                            decimal dcostPriceReal = 0, dcostPrice = 0, dkiloPrice = 0, dsellingPrice1 = 0, dsellingPrice2 = 0, dsellingPrice3 = 0, dsellingPrice4 = 0, dsellingPrice5 = 0, dwholesalePrice = 0;
                            bool bIsVATInclusive = false, bIsNBTInclusive = false;
                            int sortOrder = 0;

                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                sitem_ID = clsValidate.ValidateGridValue(dgvDetail, "item_ID", row.Index, "");
                                sitemSubCategory_ID = clsValidate.ValidateGridValue(dgvDetail, "SubCategoryNameTag", row.Index, "");
                                sitemSubCategory2_ID = clsValidate.ValidateGridValue(dgvDetail, "SubCategoryName2Tag", row.Index, "");
                                sitemSerialNo = clsValidate.ValidateGridValue(dgvDetail, "itemSerialNo", row.Index, "");
                                sitemSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "itemSerialNo2", row.Index, "");

                                dcostPriceReal = clsValidate.ValidateGridValue(dgvDetail, "costPriceReal", row.Index, decimal.Parse("0.00"));
                                dcostPrice = clsValidate.ValidateGridValue(dgvDetail, "costPrice", row.Index, decimal.Parse("0.00"));
                                dkiloPrice = clsValidate.ValidateGridValue(dgvDetail, "kiloPrice", row.Index, decimal.Parse("0.00"));
                                dsellingPrice1 = clsValidate.ValidateGridValue(dgvDetail, "sellingPrice1", row.Index, decimal.Parse("0.00"));
                                dsellingPrice2 = clsValidate.ValidateGridValue(dgvDetail, "sellingPrice2", row.Index, decimal.Parse("0.00"));
                                dsellingPrice3 = clsValidate.ValidateGridValue(dgvDetail, "sellingPrice3", row.Index, decimal.Parse("0.00"));
                                dsellingPrice4 = clsValidate.ValidateGridValue(dgvDetail, "sellingPrice4", row.Index, decimal.Parse("0.00"));
                                dsellingPrice5 = clsValidate.ValidateGridValue(dgvDetail, "sellingPrice5", row.Index, decimal.Parse("0.00"));
                                dwholesalePrice = clsValidate.ValidateGridValue(dgvDetail, "wholesalePrice", row.Index, decimal.Parse("0.00"));
                                bIsVATInclusive = clsValidate.ValidateGridValue(dgvDetail, "IsVATInclusive", row.Index, false);
                                bIsNBTInclusive = clsValidate.ValidateGridValue(dgvDetail, "IsNBTInclusive", row.Index, false);
                                sortOrder = clsValidate.ValidateGridValue(dgvDetail, "Sort Order", row.Index, 0);

                                if (txtCustomer.Tag != null)
                                {
                                    string sBranchID = "default";
                                    if (txtBranchID.Tag != null && txtBranchID.Tag.ToString().Trim().Length > 0)
                                        sBranchID = txtBranchID.Tag.ToString().Trim();

                                    #region Update Finanace Customer Table
                                    tbl_genItemMaster_Finance_Customer detailsCustomer = tbl_genItemMaster_Finance_Customer.Select(txtCustomer.Tag.ToString(), sBranchID, sitem_ID, sitemSubCategory_ID, sitemSubCategory2_ID, sitemSerialNo, sitemSerialNo2);
                                    if (detailsCustomer != null)
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), sitem_ID, "Item Master Finance - Update - 1 : " + dsellingPrice1 + " 2 : " + dsellingPrice2 + " Customer : " + txtCustomer.Text.Trim() + " Branch: " + txtBranchID.Text.Trim());

                                        detailsCustomer.SellingPrice1 = dsellingPrice1;
                                        detailsCustomer.SellingPrice2 = dsellingPrice2;
                                        detailsCustomer.IsVATinclusive = bIsVATInclusive;
                                        detailsCustomer.IsNBTinclusive = bIsNBTInclusive;
                                        detailsCustomer.SortOrder = sortOrder;
                                        detailsCustomer.Branch_ID = sBranchID;
                                        detailsCustomer.Update();
                                    }
                                    else //Insert Records Customer
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), sitem_ID, "Item Master Finance - Insert - 1 : " + dsellingPrice1 + " 2 : " + dsellingPrice2 + " Customer : " + txtCustomer.Text.Trim() + " Branch: " + txtBranchID.Text.Trim());

                                        tbl_genItemMaster_Finance_Customer insertDetailsCustomer = new tbl_genItemMaster_Finance_Customer(txtCustomer.Tag.ToString(), sBranchID, sitem_ID, sitemSubCategory_ID,
                                            sitemSubCategory2_ID, sitemSerialNo, sitemSerialNo2, dsellingPrice1, dsellingPrice2, bIsVATInclusive, bIsNBTInclusive, sortOrder, "");
                                        insertDetailsCustomer.Insert();
                                    }
                                    #endregion

                                }
                                else
                                {
                                    #region Update Finance Table
                                    tbl_genItemMaster_Pricing detail = tbl_genItemMaster_Pricing.Select(sitem_ID);
                                    if (detail != null)
                                    {
                                        //Write Audit Trial Log
                                        clsLog.Process_Modify(iFormID, clsAutocode.GetProcessNoteID(ProcessNote.ItemMaster), sitem_ID, "Item Master Finance - Update - 1 : " + dsellingPrice1 + " 2 : " + dsellingPrice2 + " SubCategory : " + sitemSubCategory_ID + " SerialNo: " + sitemSerialNo);

                                        detail.SellingPrice1 = dsellingPrice1;
                                        detail.SellingPrice2 = dsellingPrice2;
                                        detail.CostPrice1 = dcostPrice;
                                        detail.IsVATinclusive = bIsVATInclusive;
                                        detail.IsNBTinclusive = bIsNBTInclusive;
                                        detail.Update();
                                    }
                                    #endregion
                                }

                                #region Update Item SerialNo
                                tbl_zItemSerialNo oSerial = tbl_zItemSerialNo.Select(sitemSerialNo);
                                if (oSerial != null)
                                {
                                    oSerial.SellingPrice = dsellingPrice1;
                                    oSerial.CostPrice = dcostPrice;
                                    oSerial.Update();
                                }
                                #endregion
                            }

                            #region Update Customer Table
                            if (txtCustomer.Tag != null && txtCustomer.Tag.ToString().Trim().Length > 0)
                            {
                                tbl_genCustomerMaster customer = tbl_genCustomerMaster.Select(txtCustomer.Tag.ToString());
                                if (customer != null)
                                {
                                    customer.IsCustomerPricingEnable = true;
                                    customer.ItemPriceMode = (int)enum_CustomerPrice_Mode.Customer_Wise_Price;
                                    customer.ItemPriceCategory = "default";
                                    customer.Update();
                                }
                            }
                            #endregion

                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID, ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            RefreshGrid();
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

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormatModify(dgvDetail, clsFormatter.colorDigiteqTheamColorSales1, clsFormatter.colorDigiteqTheamColorSales1ForColour, clsFormatter.colorDigiteqTheamColorSales1BackColour);
            dgvDetail.Columns["itemSubCategory_ID"].Visible = clsConfig.bItemSubCategoryID_GridViewColumn;
            dgvDetail.Columns["itemSerialNo"].Visible = clsConfig.bSerialNo_GridViewColumn;
            dgvDetail.Columns["costPrice"].Visible = clsConfig.bCostPrice_GridViewColumn;
            dgvDetail.Columns["RefNo"].Visible = clsConfig.bRefNo_GridViewColumn;

            //Hide ColoumnitemSerialNo
            dgvDetail.Columns["LineNo"].Visible = false;
            dgvDetail.Columns["itemSerialNo"].Visible = false;
            dgvDetail.Columns["itemSubCategory_ID"].Visible = false;
            dgvDetail.Columns["itemSubCategory2_ID"].Visible = false;
            dgvDetail.Columns["itemSerialNo2"].Visible = false;
            dgvDetail.Columns["costPriceReal"].Visible = false;
            dgvDetail.Columns["costPrice"].Visible = false;
            dgvDetail.Columns["kiloPrice"].Visible = false;
            dgvDetail.Columns["sellingPrice2"].Visible = false;
            dgvDetail.Columns["sellingPrice3"].Visible = false;
            dgvDetail.Columns["sellingPrice4"].Visible = false;
            dgvDetail.Columns["sellingPrice5"].Visible = false;
            dgvDetail.Columns["wholesalePrice"].Visible = false;
            dgvDetail.Columns["SubCategoryNameTag"].Visible = false;
            dgvDetail.Columns["SubCategoryName2Tag"].Visible = false;
            dgvDetail.Columns["sellingPriceRs"].Visible = false;
            dgvDetail.Columns["IsVATInclusive"].Visible = false;
            dgvDetail.Columns["IsNBTInclusive"].Visible = false;
            dgvDetail.Columns["Sort Order"].Visible = false;
            dgvDetail.Columns["RefNo"].Visible = false;

        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                //decimal Rate = 0;
                //tbl_zCurrency Currency = tbl_zCurrency.Select("CUR/001");
                //if (Currency != null)
                //    Rate = Currency.CurrencyRate;

                //// int iRow;
                //int count = 0;
                //bool bIsVATInclusive = false, bIsNBTInclusive = false;
                //int sortOrder = 0;
                //dtAllRecodes.Rows.Clear();

                //List<srh_Item_Standard_Plus> details = srh_Item_Standard_Plus.SelectAll();
                //foreach (srh_Item_Standard_Plus detail in details)
                //{
                //    #region Skip Other Branches' Items
                //    tbl_genItemMaster oBranchItem = tbl_genItemMaster.Select(detail.Item_ID);
                //    if (oBranchItem.CompanyBranch_ID != clsSecurity.BranchID)
                //        continue;
                //    #endregion

                //    string sRefNo = "default";
                //    decimal dSalesPrice1 = 0;
                //    if (txtCustomer.Tag != null)
                //    {
                //        string sBranchID = "default";
                //        if (txtBranchID.Tag != null && txtBranchID.Tag.ToString().Trim().Length > 0)
                //            sBranchID = txtBranchID.Tag.ToString().Trim();

                //        tbl_genItemMaster_Finance_Customer detailsCustomer = tbl_genItemMaster_Finance_Customer.Select(txtCustomer.Tag.ToString(), sBranchID, detail.Item_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2);
                //        if (detailsCustomer != null)
                //        {
                //            dSalesPrice1 = detailsCustomer != null ? detailsCustomer.SellingPrice1 : 0;
                //            bIsVATInclusive = detailsCustomer.IsVATinclusive;
                //            bIsNBTInclusive = detailsCustomer.IsNBTinclusive;
                //            sortOrder = detailsCustomer.SortOrder;
                //        }
                //    }
                //    else
                //    {
                //        dSalesPrice1 = detail.SellingPrice1;
                //        bIsVATInclusive = detail.IsVATinclusive;
                //        bIsNBTInclusive = detail.IsNBTinclusive;
                //        //sortOrder = detail.s
                //    }

                //    //if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.gem.ToString())
                //    //{
                //    //    tbl_genItemMaster_Gem oIGem = tbl_genItemMaster_Gem.Select(detail.Item_ID);
                //    //    if (oIGem != null)
                //    //        sRefNo = oIGem.RefNo;
                //    //}

                //    dtAllRecodes.Rows.Add(
                //        detail.Item_ID,
                //        detail.ItemName,
                //        sRefNo,
                //        clsCommon.GetForeignKeyValue(detail.ItemSubCategoryName), "",
                //        detail.ItemSerialNo, 
                //        detail.ItemSerialNo2, 
                //        detail.ItemSubCategory_ID, 
                //        detail.ItemSubCategory2_ID,
                //        clsFormatter.FormatToCurrecyWithThousendSep(dSalesPrice1), 
                //        clsFormatter.FormatToCurrecyWithThousendSep(detail.CostPrice1), 
                //        count++.ToString(), 
                //        clsFormatter.FormatToCurrecyWithThousendSep(Rate * dSalesPrice1), 
                //        bIsVATInclusive, bIsNBTInclusive, sortOrder.ToString());
                //}

                dtAllRecodes.Rows.Clear();
                if (txtCustomer.Tag == null)
                {
                    string sQuary = "Exec sp_ItemFinDetails 'default', 'default', '" + clsSecurity.BranchID + "'";
                    dtAllRecodes.Merge(DBHandling
                        .ExecQuery(sQuary)
                        .Tables[0]);
                }
                else
                {
                    string sQuary = "Exec sp_ItemFinDetails '"
                                    + txtCustomer.Tag.ToString() + "', '"
                                    + "default" + "', '" + clsSecurity.BranchID + "'";
                    dtAllRecodes.Merge(DBHandling.ExecQuery(sQuary).Tables[0]);
                }




                source.DataSource = dtAllRecodes;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("item_ID", typeof(string));
            dtAllRecodes.Columns.Add("ItemName", typeof(string));
            dtAllRecodes.Columns.Add("RefNo", typeof(string));
            dtAllRecodes.Columns.Add("itemSubCategory_ID", typeof(string));
            dtAllRecodes.Columns.Add("itemSubCategory2_ID", typeof(string));
            dtAllRecodes.Columns.Add("itemSerialNo", typeof(string));
            dtAllRecodes.Columns.Add("itemSerialNo2", typeof(string));
            dtAllRecodes.Columns.Add("SubCategoryNameTag", typeof(string));
            dtAllRecodes.Columns.Add("SubCategoryName2Tag", typeof(string));
            dtAllRecodes.Columns.Add("sellingPrice1", typeof(string));
            dtAllRecodes.Columns.Add("costPrice", typeof(string));
            dtAllRecodes.Columns.Add("LineNo", typeof(string));
            dtAllRecodes.Columns.Add("sellingPriceRs", typeof(string));
            dtAllRecodes.Columns.Add("IsVATInclusive", typeof(bool));
            dtAllRecodes.Columns.Add("IsNBTInclusive", typeof(bool));
            dtAllRecodes.Columns.Add("Sort Order", typeof(int));
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
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(" It is not Allowed to Save Item Prices without a Customer\n Please Select The Customer..", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Binding Source Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";

                if (chkItemCode.Checked && argText.Name != "txtItemName")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND item_ID LIKE '%" + txtItemCode.Text.Trim() + "%'";
                    else
                        sFilteQuary = " item_ID LIKE '%" + txtItemCode.Text.Trim() + "%'";
                }
                if (chkItemName.Checked && argText.Name != "txtItemName")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                }
                if (chkItemSubCategory2.Checked && argText.Name != "txtDate")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND itemSubCategory_ID LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                    else
                        sFilteQuary = " itemSubCategory_ID LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                }
                if (chkItemSubCategory1.Checked && argText.Name != "txtRefNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND itemSubCategory2_ID LIKE '%" + txtSubCategory2.Text.Trim() + "%'";
                    else
                        sFilteQuary = " itemSubCategory2_ID LIKE '%" + txtSubCategory2.Text.Trim() + "%'";
                }
                if (chkPartNo.Checked && argText.Name != "txtPartNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND itemSerialNo LIKE '%" + txtPartNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = " itemSerialNo LIKE '%" + txtPartNo.Text.Trim() + "%'";
                }
                if (chkRefNo.Checked && argText.Name != "txtRefNo")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND RefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";
                    else
                        sFilteQuary = " RefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";
                }

                if (argText.Name == "txtItemCode")
                    sTemp = " item_ID LIKE '%" + txtItemCode.Text.Trim() + "%'";
                if (argText.Name == "txtItemName")
                    sTemp = " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                if (argText.Name == "txtSubCategory")
                    sTemp = " itemSubCategory_ID LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                if (argText.Name == "txtSubCategory2")
                    sTemp = " itemSubCategory2_ID LIKE '%" + txtSubCategory2.Text.Trim() + "%'";
                if (argText.Name == "txtPartNo")
                    sTemp = " itemSerialNo LIKE '%" + txtPartNo.Text.Trim() + "%'";
                if (argText.Name == "txtRefNo")
                    sTemp = " RefNo LIKE '%" + txtRefNo.Text.Trim() + "%'";


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

                if (!(chkItemName.Checked || chkItemSubCategory2.Checked || chkItemSubCategory1.Checked || chkPartNo.Checked || chkItemCode.Checked))
                {
                    sFilteQuary = "";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCException.Show(ex);
            }
        }

        #endregion

        #region Checked Changed
        private void chkItemSubCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemSubCategory2.Checked)
            {
                txtSubCategory.Enabled = false;
            }
            else
            {
                txtSubCategory.Enabled = true;
                txtSubCategory.Text = "";
            }
        }

        private void chkItemSubCategory2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemSubCategory1.Checked)
            {
                txtSubCategory.Enabled = false;
            }
            else
            {
                txtSubCategory.Enabled = true;
                txtSubCategory.Text = "";
            }
        }
        private void chkItemName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemName.Checked)
            {
                txtItemName.Enabled = false;
            }
            else
            {
                txtItemName.Enabled = true;
                txtItemName.Text = "";
            }
        }
        private void chkPartNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPartNo.Checked)
            {
                txtPartNo.Enabled = false;
            }
            else
            {
                txtPartNo.Enabled = true;
                txtPartNo.Text = "";
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
            }
        }
        #endregion

        #region Event Double Click
        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
            if (txtCustomer.Tag != null)
            {
                RefreshGrid();
            }
        }
        private void txtBranchID_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerBranch();
            if (txtBranchID.Tag != null)
            {
                RefreshGrid();
            }
        }
        #endregion

        #region Event KeyDown
        private void txtCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
                if (txtCustomer.Tag != null)
                {
                    RefreshGrid();
                }
            }
        }
        private void txtBranchID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerBranch();
                if (txtBranchID.Tag != null)
                {
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Event KeyUp
        private void txtSubCategory_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtSubCategory);
        }

        private void txtSubCategory2_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtSubCategory2);
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemName);
        }

        private void txtPartNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtPartNo);
        }

        private void txtRefNo_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtRefNo);
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
                        //FillDetailsCustomer(frmSearchMaster.s_SearchID);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerBranch()
        {
            if (txtCustomer.Tag != null)
            {
                clsSearch.Search_CustomerBranch(ref txtBranchID, txtCustomer.Tag.ToString());

                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.Search_CustomerBranch(Customer.Tag.ToString());
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //    txtBranchID.Tag = frmSearchMaster.s_SearchID;
                //if (frmSearchMaster.s_SearchText.Length > 0)
                //    txtBranchID.Text = frmSearchMaster.s_SearchText;
            }

        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                clsEvent.StockGridBinding_CellDoubleClick(sender, e, dgvDetail);
                string sItemCode = dgvDetail["item_ID", dgvDetail.SelectedCells[0].RowIndex].Value.ToString();

            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", iFormID, ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void xpanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chkItemCode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemCode.Checked)
            {
                txtItemCode.Enabled = false;
            }
            else
            {
                txtItemCode.Enabled = true;
                txtItemCode.Text = "";
            }
        }

        private void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemCode);
        }
    }
}
