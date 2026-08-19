using System;
using System.Collections.Generic;
using System.Data;
using Digiteq_Logic;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frmItemSearchStock : Form
    {
        #region Variables
        public static string glbItemID = "";
        public static string glbItemSubCategory = "default";
        public static string glbItemSubCategory2 = "default";
        public static string glbSerialNo = "0";
        public static string glbSerialNo2 = "0";

        public string sStoreID = "";
        public string sSectionID = "";
        public string sDepartmentID = "";

        private BindingSource source = new BindingSource();
        public DataTable dtAllRecodes = new DataTable();
        private string sFilteQuary = "";
        #endregion

        #region From Load
        public frmItemSearchStock()
        {
            InitializeComponent();
        }

        private void frmItemSearch_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "", 5,0);
            CusDataGridViewFormat();

            dgvDetail.DataSource = source;
            CreateDataTable();           
            ClearFields();
            RefreshGrid();  
        }

        
        #endregion


        #region Btn Select
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvDetail.SelectedRows.Count > 0)
            {
                glbItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", dgvDetail.SelectedRows[0].Index, "");
                glbItemSubCategory = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", dgvDetail.SelectedRows[0].Index, "default");
                glbItemSubCategory2 = clsValidate.ValidateGridValue(dgvDetail, "SubCategoryID", dgvDetail.SelectedRows[0].Index, "default");
                glbSerialNo = clsValidate.ValidateGridValue(dgvDetail, "PartNo", dgvDetail.SelectedRows[0].Index, "");
                glbSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "SerialNo", dgvDetail.SelectedRows[0].Index, "");
                this.Close();
            }
        }
        #endregion

        #region Search
        private void Search_Item()
        {
           
        }
        #endregion
                

        #region Btn Close
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetail, clsFormatter.colorDigiteqTheamColorSearchHeaderColour, clsFormatter.colorDigiteqTheamColorSearchForColour);

            //Change Grid Headers
            dgvDetail.Columns["CategoryName"].HeaderText = clsConfig.sItemSubCategory;
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            txtDepartmentID.Tag = null;
            txtSectionID.Tag = null;
            txtStoreID.Tag = null;

            txtItemCode.Clear();
            txtItemName.Clear();         
            txtSubCategory.Clear();            
            txtDepartmentID.Clear();
            txtSectionID.Clear();
            txtStoreID.Clear();

            chkItemCode.Checked = false;
            chkItemName.Checked = false;
            chkItemSubCategory.Checked = false;

            if (sStoreID.Length > 0)
            {
                txtStoreID.Tag = sStoreID;
                txtStoreID.Text = clsGenaralName.getName_Store(sStoreID);
            }
            if (sSectionID.Length > 0)
            {
                txtSectionID.Tag = sSectionID;
                txtSectionID.Text = clsGenaralName.getName_Section(sSectionID);
            }
            if (sDepartmentID.Length > 0)
            {
                txtDepartmentID.Tag = sDepartmentID;
                txtDepartmentID.Text = clsGenaralName.getName_Department(sDepartmentID);
            }
           
        }

        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgvDetail.Rows.Clear();
                int iCount = 0;
                dgvDetail.Columns["ItemName"].Width = 227;
                if (txtStoreID.Tag != null && txtStoreID.Tag.ToString().Trim().Length > 0)
                {
                    List<tbl_genStore_Stock> details = tbl_genStore_Stock.SelectAllByStore_ID(txtStoreID.Tag.ToString());
                    foreach (tbl_genStore_Stock detail in details)
                    {
                        tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                        if (item != null && (detail.Qty > 0 || detail.Weight > 0))
                        {
                            iCount++;
                            dtAllRecodes.Rows.Add(detail.Item_ID, clsGenaralName.getName_Item(detail.Item_ID),
                               detail.ItemSubCategory_ID, clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory(detail.ItemSubCategory_ID)),
                               detail.ItemSubCategory2_ID, clsCommon.GetForeignKeyValue(clsGenaralName.getName_ItemSubCategory2(detail.ItemSubCategory2_ID)),
                                detail.ItemSerialNo, detail.ItemSerialNo2, clsFormatter.FormatToNumberWithOneDecimalPlaces(detail.Qty), 
                                clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight));

                            source.DataSource = dtAllRecodes;
                        }
                    } 
                }
                if (iCount > 20)
                    dgvDetail.Columns["ItemName"].Width -= 16;

            }
            catch (Exception ex)
            {
                //SEACCException.Show(ex);
                clsValidate.WriteErrorLog("", 0,ex);
            }
        }

        private void CreateDataTable()
        {
            dtAllRecodes.Columns.Clear();
            dtAllRecodes.Columns.Add("ItemCode", typeof(string));
            dtAllRecodes.Columns.Add("ItemName", typeof(string));
            dtAllRecodes.Columns.Add("CategoryID", typeof(string));
            dtAllRecodes.Columns.Add("CategoryName", typeof(string));
            dtAllRecodes.Columns.Add("SubCategoryID", typeof(string));
            dtAllRecodes.Columns.Add("SubCategoryName", typeof(string)); 
            dtAllRecodes.Columns.Add("PartNo", typeof(string));
            dtAllRecodes.Columns.Add("SerialNo", typeof(string));
            dtAllRecodes.Columns.Add("Qty", typeof(string));
            dtAllRecodes.Columns.Add("Weight", typeof(string));
        }
        #endregion

        #region Fill Detail
        private void FillDetail()
        {
            if (sStoreID.Length > 0)
            {
                tbl_genStoreMaster detail = tbl_genStoreMaster.Select(sStoreID);
                if (detail != null)
                {
                    txtStoreID.Tag = detail.Store_ID;
                    txtStoreID.Text = detail.StoreName;
                }
            }
            else if (sSectionID.Length > 0)
            {
                tbl_genSectionMaster detail = tbl_genSectionMaster.Select(sSectionID);
                if (detail != null)
                {
                    txtSectionID.Tag = detail.Section_ID;
                    txtSectionID.Text = detail.SectionName;
                }
            }
            else if (sDepartmentID.Length > 0)
            {
                tbl_genDepartmentMaster detail = tbl_genDepartmentMaster.Select(sDepartmentID);
                if (detail != null)
                {
                    txtDepartmentID.Tag = detail.Department_ID;
                    txtDepartmentID.Text = detail.DepartmentName;
                }
            }
        }
        #endregion


        #region Event KeyUp
        private void txtItemCode_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemCode);
        }

        private void txtSubCategory_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtSubCategory);
        }

        private void txtItemName_KeyUp(object sender, KeyEventArgs e)
        {
            createFilterQuary(txtItemName);
        }

     
        #endregion

        #region Events DataGrid
        private void dgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    glbItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                    glbItemSubCategory = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID", e.RowIndex, "default");
                    glbItemSubCategory2 = clsValidate.ValidateGridTag(dgvDetail, "ItemSubCategoryID2", e.RowIndex, "default");
                    glbSerialNo = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo", e.RowIndex, "0");
                    glbSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "ItemSerialNo2", e.RowIndex, "0");
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                //SEACCException.Show(ex);
            }
        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Search_Item();
        }
        #endregion
                
        #region Event CheckedChanged
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
                
        private void chkItemSubCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkItemSubCategory.Checked)
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
        #endregion


        #region BindingSource Filtering
        private void createFilterQuary(TextBox argText)
        {
            try
            {
                string sTemp = "";
                string sFinalQuary = "";
                if (chkItemCode.Checked && argText.Name != "txtItemCode")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ItemCode LIKE '%" + txtItemCode.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ItemCode LIKE '%" + txtItemCode.Text.Trim() + "%'";
                }
                if (chkItemName.Checked && argText.Name != "txtItemName")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                    else
                        sFilteQuary = " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                }
                if (chkItemSubCategory.Checked && argText.Name != "txtDate")
                {
                    if (sFilteQuary.Trim().Length > 0)
                        sFilteQuary += " AND CategoryName LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                    else
                        sFilteQuary = " CategoryName LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                }

                if (argText.Name == "txtItemCode")
                    sTemp = " ItemCode LIKE '%" + txtItemCode.Text.Trim() + "%'";
                if (argText.Name == "txtItemName")
                    sTemp = " ItemName LIKE '%" + txtItemName.Text.Trim() + "%'";
                if (argText.Name == "txtSubCategory")
                    sTemp = " CategoryName LIKE '%" + txtSubCategory.Text.Trim() + "%'";
                

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

                if (!(chkItemCode.Checked || chkItemName.Checked || chkItemSubCategory.Checked))
                {
                    sFilteQuary = "";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                //SEACCException.Show(ex);
            }
        }
        #endregion  

        #region MyRegion
        private void dgvDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    glbItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                    glbItemSubCategory = clsValidate.ValidateGridValue(dgvDetail, "CategoryID", e.RowIndex, "default");
                    glbItemSubCategory2 = clsValidate.ValidateGridValue(dgvDetail, "SubCategoryID", e.RowIndex, "default");
                    glbSerialNo = clsValidate.ValidateGridValue(dgvDetail, "PartNo", e.RowIndex, "");
                    glbSerialNo2 = clsValidate.ValidateGridValue(dgvDetail, "SerialNo", e.RowIndex, "");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                //SEACCException.Show(ex);
            }
        } 
        #endregion


    }
}
