using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frm_scsItemViewer_CombinationMaterial : Form
    {

        
        //to manage update and insert
       // static bool IsUpdate = false;

        //to keep form detail       
       // string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        public string glbItemID = "";
        int iRow;


        #region Form Load
        public frm_scsItemViewer_CombinationMaterial()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerCombinationMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Item Viewer Combination Material", 2, iFormID);
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


        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbItemID.Length > 0)
                FillDetails(glbItemID);
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
            lblLaminationType.Text = "";
            lblMaterialID.Text = "";
            lblMaterialName.Text = "";
            lblMaterialThikness.Text = "";
            lblMaterialUOM.Text = "";
            lblMaterialWith.Text = "";
            lblPolythene.Text = "";
            lblPolythineType.Text = "";

            chkCommercial.Checked = false;
            chkPrinted.Checked = false;
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode)
        {
            List<tbl_genItemMaster_CombinationMaterail> MaterailDetails = tbl_genItemMaster_CombinationMaterail.SelectAllByItem_ID(sItemCode);
            foreach (tbl_genItemMaster_CombinationMaterail Rdetail in MaterailDetails)
            {
                lblMaterialID.Text = Rdetail.Item_ID;
                tbl_genItemMaster Itemdetail = tbl_genItemMaster.Select(Rdetail.Item_ID);
                lblMaterialUOM.Text = clsGenaralName.getName_Uom(Itemdetail.Uom_ID); 
                lblMaterialName.Text = clsGenaralName.getName_Item(Rdetail.Item_ID);
                lblMaterialThikness.Text = Rdetail.Thickness.ToString();
                lblMaterialWith.Text = Rdetail.Width.ToString();
                lblPolythene.Text = clsGenaralName.getName_PolytheneMaterailType(Rdetail.PolytheneMaterailType_ID);
                lblPolythineType.Text = clsGenaralName.getName_PolytheneType(Rdetail.PolytheneType_ID);
                lblLaminationType.Text = clsGenaralName.getName_LaminationType(Rdetail.LaminationMaterailType_ID);
                //chkCommercial.Checked = Rdetail.Is; This one have to fill later
                chkPrinted.Checked = Rdetail.IsPrinted;
            }        

        }
        #endregion

        #region Refresh Grid
        private void RefreshGridStoreStock()
        {
            try
            {
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
                        dgvDetailStore["DamagedQuantity", iRow].Value = detail.DamageWeight ;
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
