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
    public partial class frm_scsItemViewer_FinishedGood : Form
    {

        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;

        //to keep form detail       
        //string sFormConfigCode;
           public int iFormID;

        public bool bNoAccess;
        public string glbItemID = "";

        int iRow;
        #endregion

        #region Form Load
        public frm_scsItemViewer_FinishedGood()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerFinishedGood);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Item Viewer Finished", 2, iFormID);
            ClearFields();
            if (glbItemID.Length > 0){
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
            lblGoodName.Text = "";
            lblBranchaName.Text = "";
            lblGoodID.Text = "";
            lblCustomerName.Text = "";
            lblItemGussest.Text = "";
            lblItemHeight.Text = "";
            lblItemThickness.Text = "";
            lblItemUOM.Text = "";
            lblItemWith.Text = "";
            lblPolytheneType.Text = "";
            lblSealingType.Text = "";
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemID)
        {

            List<tbl_genItemMaster_FinishedGood> MaterailDetails = tbl_genItemMaster_FinishedGood.SelectAllByItem_ID(sItemID);
            foreach (tbl_genItemMaster_FinishedGood detail in MaterailDetails)
            {
                lblGoodName.Text = clsGenaralName.getName_Item(detail.Item_ID);
                lblBranchaName.Text = detail.Brand_ID;
                lblGoodID.Text = detail.Item_ID;
                lblCustomerName.Text =clsGenaralName.getName_Customer(detail.Customer_ID);
                lblItemGussest.Text = detail.Gusset.ToString();
                lblItemHeight.Text = detail.Height.ToString();
                lblItemThickness.Text = detail.Thickness.ToString();
                tbl_genItemMaster Itemdetail = tbl_genItemMaster.Select(detail.Item_ID);
                lblItemUOM.Text = clsGenaralName.getName_Uom(Itemdetail.Uom_ID);
                lblItemWith.Text = detail.Width.ToString();
                lblPolytheneType.Text = clsGenaralName.getName_PolytheneType(detail.PolytheneType_ID);
                lblSealingType.Text = clsGenaralName.getName_SealingType(detail.SealingType_ID);
                chkPrinted.Checked = detail.IsPrinted;
                //chkCommercial = detail  This one have to fill later
            }
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
