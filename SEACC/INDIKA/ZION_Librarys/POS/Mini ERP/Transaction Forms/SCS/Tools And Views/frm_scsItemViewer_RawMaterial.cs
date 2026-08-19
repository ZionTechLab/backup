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
    public partial class frm_scsItemViewer_RawMaterial : Form
    {

        #region Variables
    
           public int iFormID;
        public bool bNoAccess;
        public string glbItemID = "";

        int iRow;
        #endregion

        #region Form Load
        public frm_scsItemViewer_RawMaterial()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerRawMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent(); 
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Item Viewer Row Material", 2, iFormID);
            ClearFields();
            if (glbItemID.Length > 0)
            {
                FillDetails(glbItemID);
                RefreshGridStoreStock();
                RefreshGridSectionStock();
                RefreshGridDepartmentStock();
            }
            CusDataGridViewFormat();
        } 
        #endregion


        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbItemID.Length > 0)
                FillDetails(glbItemID);
        }
        #endregion

        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailStore, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            lblMaterialCategory.Text = "";
            lblMaterialClass.Text = "";
            lblMaterialID.Text = "";
            lblMaterialName.Text = "";
            lblMaterialType.Text = "";
            lblMaterialType.Text = "";
            lblMaterialUom.Text = "";
            lblMaterialWith.Text = "";
            lblSubCategory.Text = "";
            lblThickness.Text = "";
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode)
        {
            tbl_genItemMaster Details = tbl_genItemMaster.Select(sItemCode);
            lblMaterialCategory.Text = clsGenaralName.getName_ItemCategory(Details.ItemCategory_ID);
            lblMaterialClass.Text = clsGenaralName.getName_ItemClass(Details.ItemClass_ID); 
            lblMaterialID.Text = Details.Item_ID;
            lblMaterialName.Text = clsGenaralName.getName_Item(Details.Item_ID);
            lblMaterialType.Text = clsGenaralName.getName_ItemType(Details.ItemType_ID);
            lblMaterialUom.Text =clsGenaralName.getName_Uom(Details.Uom_ID);
            lblMaterialWith.Text = Details.Width.ToString();
            lblSubCategory.Text = Details.ItemCategorySub_ID;
            lblThickness.Text = Details.Thickness.ToString();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGridStoreStock()
        {
            try
            {
                dgvDetailStore.Rows.Clear();
                List<tbl_genStore_Stock> SoreStokeDetails = tbl_genStore_Stock.SelectAllByItem_ID(glbItemID);
                foreach (tbl_genStore_Stock detail in SoreStokeDetails)
                {
                    if (detail.Store_ID != "default")
                    {

                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Store_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Store(detail.Store_ID);
                        dgvDetailStore["AvailableQuantity", iRow].Value = detail.Qty;
                        dgvDetailStore["ActualQuantity", iRow].Value = detail.Weight;
                        dgvDetailStore["DamagedQuantity", iRow].Value = detail.DamageWeight;
                        dgvDetailStore["WasteageQuantity", iRow].Value = detail.WasteageWeight;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridSectionStock()
        {
            try
            {
                List<tbl_genSection_Stock> SoreStokeDetails = tbl_genSection_Stock.SelectAllByItem_ID(glbItemID);
                foreach (tbl_genSection_Stock detail in SoreStokeDetails)
                {
                    if (detail.Section_ID != "default")
                    {
                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Section_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Section(detail.Section_ID);
                        dgvDetailStore["AvailableQuantity", iRow].Value = detail.Qty;
                        dgvDetailStore["ActualQuantity", iRow].Value = detail.Weight;
                        dgvDetailStore["DamagedQuantity", iRow].Value = detail.DamageWeight;
                        dgvDetailStore["WasteageQuantity", iRow].Value = detail.WasteageWeight;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void RefreshGridDepartmentStock()
        {
            try
            {
                List<tbl_genDepartment_Stock> SoreStokeDetails = tbl_genDepartment_Stock.SelectAllByItem_ID(glbItemID);
                foreach (tbl_genDepartment_Stock detail in SoreStokeDetails)
                {
                    if (detail.Department_ID != "default")
                    {
                        dgvDetailStore.Rows.Add();
                        iRow = dgvDetailStore.Rows.Count - 1;
                        dgvDetailStore["StoreID", iRow].Value = detail.Department_ID;
                        dgvDetailStore["StoreName", iRow].Value = clsGenaralName.getName_Department(detail.Department_ID);
                        dgvDetailStore["AvailableQuantity", iRow].Value = detail.Qty;
                        dgvDetailStore["ActualQuantity", iRow].Value = detail.Weight;
                        dgvDetailStore["DamagedQuantity", iRow].Value = detail.DamageWeight;
                        dgvDetailStore["WasteageQuantity", iRow].Value = detail.WasteageWeight;
                    }
                }
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
