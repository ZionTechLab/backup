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
    public partial class frm_scsItemViewer_LaminatedMaterial : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;
        public string glbItemID = "";

        int iRow;
        #endregion

        #region Form Load
        public frm_scsItemViewer_LaminatedMaterial()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerLaminatedMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Item Viewer Laminated Material", 2, iFormID);
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


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailStore, clsFormatter.colorDigiteqTheamColor1, clsFormatter.colorDigiteqTheamColorSales1ForColour);
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemID)
        {

            //List<tbl_genItemMaster_FinishedGood> MaterailDetails = tbl_genItemMaster_FinishedGood.SelectAllByItem_ID(sItemID);
            //foreach (tbl_genItemMaster_FinishedGood detail in MaterailDetails)
            //{

            //}
        }
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //lblRegisterCode.Text = "";
            //lblRegisterDate.Text = "";
            //lblReceiptNo.Text = "";
            //lblReceiptDate.Text = "";
          
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
